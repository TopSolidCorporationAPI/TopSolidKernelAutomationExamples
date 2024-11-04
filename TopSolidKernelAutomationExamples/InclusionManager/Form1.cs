using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TopSolid.Cad.Design.Automating;
using TopSolid.Kernel.Automating;

namespace InclusionManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btDrop_Click(object sender, EventArgs e)
        {
            PdmObjectId currentProject = TopSolidHost.Pdm.GetCurrentProject();
            if (currentProject.IsEmpty) return;

            //creates new document then fill it with a sketch and a shape
            PdmObjectId newDocumentPdmId = CreateAndFillPartDocument(currentProject);
            DocumentId newDocument = TopSolidHost.Documents.GetDocument(newDocumentPdmId);
            if (newDocument.IsEmpty) return;

            //3 - create a new assembly document in order to drop the part into it
            PdmObjectId assemblyDocumentPdm = TopSolidHost.Pdm.CreateDocument(currentProject, ".TopAsm", true);
            if (assemblyDocumentPdm.IsEmpty) return;

            TopSolidHost.Pdm.SetName(assemblyDocumentPdm, "AssemblyDocumentWithDroppedDocument");

            //4 - drop newly created part document
            //open assembly document then drop the part into it
            DocumentId assemblyDocumentToOpen = TopSolidHost.Documents.GetDocument(assemblyDocumentPdm);
            TopSolidHost.Documents.Open(ref assemblyDocumentToOpen);

            //then drop
            TopSolidHost.Documents.Drop(newDocument);
        }


        private void btCreateInclusion_Click(object sender, EventArgs e)
        {
            PdmObjectId currentProject = TopSolidHost.Pdm.GetCurrentProject();
            if (currentProject.IsEmpty) return;

            //creates document to use if not existing into current project
            PdmObjectId documentToUsePdmId = TopSolidHost.Pdm.SearchDocumentByName(currentProject, "PartDocumentToInclude").FirstOrDefault<PdmObjectId>();
            if (documentToUsePdmId.IsEmpty)
            {
                documentToUsePdmId = CreateAndFillPartDocument(currentProject);
            }
            if (documentToUsePdmId.IsEmpty) return;

            DocumentId newDocumentToUse = TopSolidHost.Documents.GetDocument(documentToUsePdmId);
            if (newDocumentToUse.IsEmpty) return;

            //3 - create a new assembly document in order to include the part into it
            PdmObjectId assemblyDocumentPdm = TopSolidHost.Pdm.SearchDocumentByName(currentProject, "AssemblyDocumentWithInclusion").FirstOrDefault<PdmObjectId>();
            if (assemblyDocumentPdm.IsEmpty)
            {
                assemblyDocumentPdm = TopSolidHost.Pdm.CreateDocument(currentProject, ".TopAsm", true);
                TopSolidHost.Pdm.SetName(assemblyDocumentPdm, "AssemblyDocumentWithInclusion");
            }

            DocumentId newAssemblyDocumentId = TopSolidHost.Documents.GetDocument(assemblyDocumentPdm);
            if (newAssemblyDocumentId.IsEmpty) return;

            //start document modification

            try
            {
                TopSolidHost.Application.StartModification("Make a basic inclusion", false);
                TopSolidHost.Documents.EnsureIsDirty(ref newAssemblyDocumentId);

                //create a new positioning before inclusion
                ElementId positioningId = TopSolidDesignHost.Assemblies.CreatePositioning(newAssemblyDocumentId);

                TopSolidDesignHost.Assemblies.CreateInclusion(newAssemblyDocumentId, positioningId, null, newDocumentToUse, null, null, null, true,
                    ElementId.Empty, ElementId.Empty, false, false, false, false, Transform3D.Identity, false);

                //end modification
                TopSolidHost.Application.EndModification(true, true);
            }
            catch (Exception ee)
            {
                TopSolidHost.Application.EndModification(false, false);
            }

            //save document
            TopSolidHost.Pdm.Save(assemblyDocumentPdm, false);

        }


        private void btSlottedMushrooms_Click(object sender, EventArgs e)
        {
            PdmObjectId currentProject = TopSolidHost.Pdm.GetCurrentProject();

            //search library into referenced project. If not added, search library and add it to reference. If it does not exist, throw an error
            PdmObjectId topSolidMechanicalProject = PdmObjectId.Empty;
            if (!ManageTopSolidMechanicalAddition(currentProject, topSolidMechanicalProject))
            {
                throw new Exception("You need to add TopSolid Mechanical Library in order to use this command.");
            }

            //gets family from library
            //if needed you can add the family you wish
            PdmObjectId familyDocumentPdmId = new PdmObjectId("35_6a3bf5c3-631c-47a7-b281-ea0d9b6d7875&393217_54040");
            if (familyDocumentPdmId.IsEmpty)
            {
                throw new Exception("Can't find family document!");
            }

            DocumentId currentDocument = TopSolidHost.Documents.EditedDocument;

            if (!TopSolidHost.Documents.GetTypeFullName(currentDocument).Contains("AssemblyDocument")) return;
            DocumentId familyDocument = TopSolidHost.Documents.GetDocument(familyDocumentPdmId);

            try
            {
                //start document modification
                TopSolidHost.Application.StartModification("Check family", false);
                TopSolidHost.Documents.EnsureIsDirty(ref currentDocument);

                //getting codes from family document
                List<string> codesList = TopSolidHost.Families.GetCodes(familyDocument);
                Frame3D frameOrigo = new Frame3D(Point3D.P0, Direction3D.DX, Direction3D.DY, Direction3D.DZ);
                ElementId frameOrigoPoint = ElementId.Empty;

                Frame3D frameBest = new Frame3D(Point3D.P0, Direction3D.DX, Direction3D.DY, Direction3D.DZ);
                ElementId frameBestPoint = ElementId.Empty;

                ElementId positioningId = ElementId.Empty;
                ElementId insertedElement = ElementId.Empty;

                //insertion of each code
                for (int j = 0; j < codesList.Count; j++)
                {
                    string code = codesList[j];

                    //positioning creation (empty for now)
                    positioningId = TopSolidDesignHost.Assemblies.CreatePositioning(currentDocument);

                    //basic inclusion creation
                    insertedElement = TopSolidDesignHost.Assemblies.CreateInclusion2(currentDocument, positioningId, code, familyDocument, code, new List<string>(),
                    new List<SmartObject>(), new List<string>(), new List<SmartDesignObject>(), true, ElementId.Empty,
                    ElementId.Empty, false, true, true, true, Transform3D.Identity, false);

                    if (!insertedElement.IsEmpty)
                    {
                        //getting the inclusion child
                        ElementId insertedElementId = TopSolidDesignHost.Assemblies.GetInclusionChildOccurrence(insertedElement);

                        //looking for published frames
                        DocumentId instanceDocument = TopSolidDesignHost.Assemblies.GetOccurrenceDefinition(insertedElementId);
                        var publishings = TopSolidHost.Entities.GetPublishings(instanceDocument);
                        foreach (ElementId function in TopSolidHost.Entities.GetFunctions(instanceDocument))
                        {
                            foreach (ElementId publishing in TopSolidHost.Entities.GetFunctionPublishings(function))
                            {
                                if (TopSolidHost.Elements.GetTypeFullName(publishing).Contains("FrameEntity"))
                                {
                                    //as for slotted mushroom, we are looking for top frame.
                                    //if needed, you can adapt to any other frame of a custom family
                                    if (TopSolidHost.Elements.GetFriendlyName(publishing).Contains("Top"))
                                    {
                                        ElementId corresponding = TopSolidDesignHost.Assemblies.GetOccurrencePublishing(insertedElementId, publishing);
                                        frameBestPoint = corresponding;
                                        break;
                                    }
                                }
                            }
                        }

                        //begining from second occurence, juxtapose occurences by adding frame on frame constraint.
                        //previous enclosing box is used
                        if (j > 0)
                        {
                            SmartFrame3D frameDestination = new SmartFrame3D(frameOrigoPoint, false);
                            SmartFrame3D frameSource = new SmartFrame3D(frameBestPoint, false);
                            SmartReal offsetDistance = new SmartReal(UnitType.Length, 0);
                            SmartReal rotationAngle = new SmartReal(UnitType.Angle, 0);
                            SmartReal yRotationAngle = new SmartReal(UnitType.Angle, 0);
                            SmartReal zRotationAngle = new SmartReal(UnitType.Angle, 0);

                            TopSolidDesignHost.Assemblies.CreateFrameOnFrameConstraint(positioningId, frameSource, frameDestination, offsetDistance, true, rotationAngle,
                                false, yRotationAngle, false, zRotationAngle, false, false);
                        }

                        //look for enclosing box limit on X axis
                        double Xmax = 0;
                        double Xmin = 0;
                        foreach (ElementId element in TopSolidHost.Elements.GetConstituents(insertedElementId))
                        {
                            if (TopSolidHost.Elements.GetTypeFullName(element).Contains("ShapeEntity"))
                            {
                                foreach (ElementItemId face in TopSolidHost.Shapes.GetFaces(element))
                                {
                                    TopSolidHost.Shapes.GetFaceEnclosingCoordinatesWithGivenFrame(face, Frame3D.OXYZ,
                                        out double xmin, out double xmax, out _, out _, out _, out _);
                                    if (xmax > Xmax)
                                        Xmax = xmax;
                                    if (xmin < Xmin)
                                        Xmin = xmin;
                                }
                            }
                        }

                        //create new frame which will be used for next code
                        Frame3D frameBestNew = new Frame3D(new Point3D(frameBest.Origin.X + (Xmax - Xmin)+0.005, frameBest.Origin.Y, frameBest.Origin.Z), Direction3D.DX, Direction3D.DY, Direction3D.DZ);
                        frameOrigoPoint = TopSolidHost.Geometries3D.CreateFrame(currentDocument, frameBestNew);

                        frameBest = frameBestNew;

                    }
                }
                TopSolidHost.Application.EndModification(true, true);
            }
            catch (Exception ee)
            {
                TopSolidHost.Application.EndModification(false, false);
            }


        }



        #region private methods
        /// <summary>
        /// Private method to create a part document and add a sketch and an extruded shape
        /// </summary>
        /// <param name="currentProject"></param>
        /// <returns></returns>
        private PdmObjectId CreateAndFillPartDocument(PdmObjectId currentProject)
        {
            //1-first, create a new part document
            PdmObjectId newDocPdm = TopSolidHost.Pdm.CreateDocument(currentProject, ".TopPrt", true);
            if (newDocPdm.IsEmpty) return PdmObjectId.Empty;

            TopSolidHost.Pdm.SetName(newDocPdm, "PartDocumentToInclude");

            //2 - then, create a rectangle shaped sketch
            DocumentId newDocument = TopSolidHost.Documents.GetDocument(newDocPdm);
            if (newDocument.IsEmpty) return PdmObjectId.Empty;

            try
            {
                //start document modification
                TopSolidHost.Application.StartModification("sketch a rectangle", false);
                TopSolidHost.Documents.EnsureIsDirty(ref newDocument);

                ElementId newSketch = TopSolidHost.Sketches2D.CreateSketchIn3D(newDocument, new SmartPlane3D(TopSolidHost.Geometries3D.GetAbsoluteXYPlane(newDocument), false),
                                            new SmartPoint3D(TopSolidHost.Geometries3D.GetAbsoluteOriginPoint(newDocument)),
                                            false,
                                            new SmartDirection3D(TopSolidHost.Geometries3D.GetAbsoluteYAxis(newDocument),
                                                false));
                if (newSketch.IsEmpty) return PdmObjectId.Empty;

                //start sketch modification
                TopSolidHost.Sketches2D.StartModification(newSketch);

                //define points
                Point2D pt1 = new Point2D(0, 0);
                Point2D pt2 = new Point2D(0, 0.05);
                Point2D pt3 = new Point2D(0.07, 0.05);
                Point2D pt4 = new Point2D(0.07, 0);

                //creates corresponding vertexes
                ElementItemId pt1_Vertex = TopSolidHost.Sketches2D.CreateVertex(pt1);
                ElementItemId pt2_Vertex = TopSolidHost.Sketches2D.CreateVertex(pt2);
                ElementItemId pt3_Vertex = TopSolidHost.Sketches2D.CreateVertex(pt3);
                ElementItemId pt4_Vertex = TopSolidHost.Sketches2D.CreateVertex(pt4);

                List<ElementItemId> segments = new List<ElementItemId>();
                segments.Add(TopSolidHost.Sketches2D.CreateLineSegment(pt1_Vertex, pt2_Vertex));
                segments.Add(TopSolidHost.Sketches2D.CreateLineSegment(pt2_Vertex, pt3_Vertex));
                segments.Add(TopSolidHost.Sketches2D.CreateLineSegment(pt3_Vertex, pt4_Vertex));
                segments.Add(TopSolidHost.Sketches2D.CreateLineSegment(pt4_Vertex, pt1_Vertex));

                TopSolidHost.Sketches2D.CreateProfile(segments);

                //end sketch modification
                TopSolidHost.Sketches2D.EndModification();

                //extrude the sketch to create a part
                TopSolidHost.Shapes.CreateExtrudedShape(newDocument, new SmartSection3D(newSketch), SmartDirection3D.DZ, new SmartReal(UnitType.Length, 0.05), new SmartReal(UnitType.Angle, 0), false, false);

                //end modification
                TopSolidHost.Application.EndModification(true, true);
            }
            catch (Exception ee)
            {
                TopSolidHost.Application.EndModification(false, false);
            }

            //save document
            TopSolidHost.Pdm.Save(newDocPdm, false);

            return newDocPdm;
        }

        //this methods adds target project to reference if it is not already added
        private static bool ManageTopSolidMechanicalAddition(PdmObjectId currentProject, PdmObjectId outTopSolidMechanicalProject)
        {
            foreach (PdmObjectId referencedProject in TopSolidHost.Pdm.GetReferencedProjects(currentProject))
            {
                string name = TopSolidHost.Pdm.GetName(referencedProject);
                if (TopSolidHost.Pdm.IsLibraryProject(referencedProject) && TopSolidHost.Pdm.GetName(referencedProject) == "TopSolid AFNOR Mechanical")
                {
                    outTopSolidMechanicalProject = referencedProject;
                    return true;
                }
            }
            foreach (PdmObjectId referencePdmProject in TopSolidHost.Pdm.GetProjects(false, true))
            {
                if (TopSolidHost.Pdm.GetName(referencePdmProject) == "TopSolid AFNOR Mechanical")
                {
                    outTopSolidMechanicalProject = referencePdmProject;
                    TopSolidHost.Pdm.AddReferencedProjects(currentProject, new List<PdmObjectId> { outTopSolidMechanicalProject });
                    return true;
                }
            }

            return false;
        }
        #endregion


    }
}
