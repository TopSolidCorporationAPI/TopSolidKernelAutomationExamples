using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TopSolid.Kernel.Automating;
using TopSolid.Cad.Design.Automating;

namespace FamilyManager
{
    public partial class Form1 : Form
    {

        List<DocumentId> checkedDocuments;

        public Form1()
        {
            InitializeComponent();

            checkedDocuments = new List<DocumentId>();
        }

        private void btGetFirstFileName_Click(object sender, EventArgs e)
        {
            checkedDocuments = new List<DocumentId>();

            //get all selected files              
            GetCheckedDocuments(pdmTreeView1.Nodes, ref checkedDocuments);

            if (checkedDocuments.Count > 0)
            {
                tbFamilyName.Text = TopSolidHost.Documents.GetName(checkedDocuments.First());
            }
        }

        /// <summary>
        /// method to get selected documents from treeview checked nodes
        /// </summary>
        /// <param name="nodeCollection"></param>
        /// <param name="checkedDocuments"></param>
        private void GetCheckedDocuments(TreeNodeCollection nodeCollection, ref List<DocumentId> checkedDocuments)
        {
            foreach (TreeNode node in nodeCollection)
            {
                if (node.Checked)
                {
                    if (node.ImageKey == "file" || node.ImageIndex == 1)
                    {
                        if (node.Tag != null)
                        {
                            PdmObjectId pdmObject = (PdmObjectId)node.Tag;
                            if (pdmObject.IsEmpty) continue;

                            DocumentId documentId = TopSolidHost.Documents.GetDocument(pdmObject);
                            if (documentId.IsEmpty) continue;

                            checkedDocuments.Add(documentId);
                        }
                    }
                }
                if (node.Nodes.Count > 0)
                {
                    GetCheckedDocuments(node.Nodes, ref checkedDocuments);
                }
            }
        }

        /// <summary>
        /// method to get selected documents from treeview checked nodes
        /// </summary>
        /// <param name="nodeCollection"></param>
        /// <param name="checkedDocuments"></param>
        private void GetCheckedDocuments(TreeNodeCollection nodeCollection,string documentExtension, ref List<DocumentId> checkedDocuments)
        {
            foreach (TreeNode node in nodeCollection)
            {
                if (node.Checked)
                {
                    if (node.ImageKey == documentExtension || node.ImageIndex == 1)
                    {
                        if (node.Tag != null)
                        {
                            PdmObjectId pdmObject = (PdmObjectId)node.Tag;
                            if (pdmObject.IsEmpty) continue;

                            DocumentId documentId = TopSolidHost.Documents.GetDocument(pdmObject);
                            if (documentId.IsEmpty) continue;

                            checkedDocuments.Add(documentId);
                        }
                    }
                }
                if (node.Nodes.Count > 0)
                {
                    GetCheckedDocuments(node.Nodes, documentExtension, ref checkedDocuments);
                }
            }
        }

        private void btCreateExplicitFamily_Click(object sender, EventArgs e)
        {
            checkedDocuments=new List<DocumentId>();
            if (pdmTreeView1.Nodes.Count > 0)
            {
                GetCheckedDocuments(pdmTreeView1.Nodes, ref checkedDocuments);
            }

            if (checkedDocuments.Count == 0) return;

            string redundantName = string.Empty;
            if (chkUseRedundantName.Checked)
            {
                redundantName = GetRedundantText(checkedDocuments);
            }
            else
            {
                redundantName=tbFamilyName.Text.Trim();
            }

            PdmObjectId familyDocument = TopSolidHost.Pdm.CreateDocument(TopSolidHost.Pdm.GetCurrentProject(), ".TopFam", true);

            if (familyDocument.IsEmpty) return;

            TopSolidHost.Pdm.SetName(familyDocument, redundantName == string.Empty ? TopSolidHost.Documents.GetName(checkedDocuments.First()) : redundantName);

            TopSolidHost.Pdm.Save(familyDocument, true);

            SetFamilyAsExplicit(familyDocument);

            SetGenericDocument(familyDocument);

            AddInstances(familyDocument, GetRedundantText(checkedDocuments));

            if (chkPurgeOriginalFiles.Checked)
            {
                PurgeDocuments();
            }
        }

        private void PurgeDocuments()
        {
            if (!checkedDocuments.First().IsEmpty && chkPurgeOriginalFiles.Checked)
            {
                List<PdmObjectId> objectsToDelete = new List<PdmObjectId>();
                for (int i = 1; i < checkedDocuments.Count; ++i)
                {
                    objectsToDelete.Add(TopSolidHost.Documents.GetPdmObject(checkedDocuments[i]));
                }
                if (objectsToDelete.Count != 0)
                {
                    TopSolidHost.Pdm.DeleteSeveral(objectsToDelete);
                }
            }
        }

        private void AddInstances(PdmObjectId familyDocument, string redundantName)
        {
            DocumentId currentDocument = TopSolidHost.Documents.GetDocument(familyDocument);
            if (currentDocument != DocumentId.Empty)
            {
                if (TopSolidHost.Families.IsExplicit(currentDocument))
                {
                    int indexDocument = 1;
                    foreach (DocumentId instanceDoc in checkedDocuments)
                    {
                        try
                        {
                            TopSolidHost.Application.StartModification("set generic document", false);
                            TopSolidHost.Documents.EnsureIsDirty(ref currentDocument);

                            string instanceDocName = TopSolidHost.Documents.GetName(instanceDoc); ;
                            string code = indexDocument.ToString();
                            if (chkRemoveRedundantName.Checked && redundantName != string.Empty && checkedDocuments.Count>1)
                            {
                                redundantName = GetRedundantText(checkedDocuments);
                                code = RemoveSubstring(instanceDocName, redundantName);
                            }
                            TopSolidHost.Families.AddExplicitInstance(currentDocument, code, instanceDoc);


                            TopSolidHost.Application.EndModification(true, true);
                        }
                        catch (Exception ee)
                        {
                            TopSolidHost.Application.EndModification(false, false);
                        }
                        TopSolidHost.Pdm.Save(TopSolidHost.Documents.GetPdmObject(currentDocument), true);

                        indexDocument++;
                    }
                }
            }
        }

        private void SetGenericDocument(PdmObjectId familyDocument)
        {
            DocumentId familyDocumentId = TopSolidHost.Documents.GetDocument(familyDocument);
            if (familyDocumentId != DocumentId.Empty)
            {
                if (!checkedDocuments.First().IsEmpty)
                {
                    try
                    {
                        TopSolidHost.Application.StartModification("set generic document", false);
                        TopSolidHost.Documents.EnsureIsDirty(ref familyDocumentId);
                        DocumentId genericDoc = checkedDocuments.First();

                        TopSolidHost.Families.SetGenericDocument(familyDocumentId, genericDoc, DocumentId.Empty);

                        TopSolidHost.Application.EndModification(true, true);
                    }
                    catch (Exception ee)
                    {
                        TopSolidHost.Application.EndModification(false, false);
                    }

                    TopSolidHost.Pdm.Save(TopSolidHost.Documents.GetPdmObject(familyDocumentId), true);
                }
            }
        }

        private static void SetFamilyAsExplicit(PdmObjectId familyDocument)
        {
            DocumentId document = TopSolidHost.Documents.GetDocument(familyDocument);

            if (document.IsEmpty) return;

            //first: set as explicit
            try
            {
                TopSolidHost.Application.StartModification("set as explicit family", false);
                TopSolidHost.Documents.EnsureIsDirty(ref document);

                TopSolidHost.Families.SetAsExplicit(document);

                TopSolidHost.Application.EndModification(true, true);
            }
            catch (Exception ee)
            {
                TopSolidHost.Application.EndModification(false, false);
            }

            TopSolidHost.Pdm.Save(TopSolidHost.Documents.GetPdmObject(document), true);
        }

        private string GetRedundantText(List<DocumentId> checkedDocumentList)
        {
            if (checkedDocumentList.Count == 0)
                return string.Empty;

            List<string> documentNames = new List<string>();
            foreach (DocumentId document in checkedDocumentList) 
            {
                if (document.IsEmpty) continue;
                documentNames.Add(TopSolidHost.Documents.GetName(document));
            }

            // On prend la première chaîne comme base de comparaison
            string reference = documentNames[0];

            for (int i = 0; i < reference.Length; i++)
            {
                for (int j = reference.Length; j > i; j--)
                {
                    // Substring de référence
                    string substring = reference.Substring(i, j - i);

                    // Vérifier si ce sous-ensemble est commun à toutes les chaînes
                    bool isCommon = true;
                    foreach (string str in documentNames)
                    {
                        if (!str.Contains(substring))
                        {
                            isCommon = false;
                            break;
                        }
                    }

                    // Si une chaîne commune a été trouvée, la retourner
                    if (isCommon)
                        return substring;
                }
            }

            return string.Empty; // Pas de chaîne commune
        }

        // Méthode pour retirer une sous-chaîne d'une chaîne principale
        static string RemoveSubstring(string original, string toRemove)
        {
            if (string.IsNullOrEmpty(original) || string.IsNullOrEmpty(toRemove))
                return original;

            // Utilisation de la méthode Replace pour retirer toutes les occurrences de 'toRemove'
            return original.Replace(toRemove, string.Empty);
        }

        private void btSetFamilyGenericDocument_Click(object sender, EventArgs e)
        {
            checkedDocuments = new List<DocumentId>();
            if (pdmTreeView1.Nodes.Count > 0 && rdbForSelection.Checked)
            {
                GetCheckedDocuments(pdmTreeView1.Nodes, ".TopFam", ref checkedDocuments);
            }
            else if (pdmTreeView1.Nodes.Count > 0 &&  rdbForAll.Checked)
            {
                GetDocumentsFromTreeView(pdmTreeView1.Nodes,".TopFam", ref checkedDocuments);
            }

            if (checkedDocuments.Count == 0) return;

            foreach (DocumentId family in checkedDocuments)
            {
                if (!TopSolidHost.Families.IsExplicit(family)) return;

                PdmObjectId familyPdmObject = TopSolidHost.Documents.GetPdmObject(family);

                List<string> codes = TopSolidHost.Families.GetCodes(family);

                PdmObjectId assemblyDocument = TopSolidHost.Pdm.CreateDocument(TopSolidHost.Pdm.GetCurrentProject(), ".TopAsm", true);

                if (assemblyDocument.IsEmpty) return;

                DocumentId assDocId = TopSolidHost.Documents.GetDocument(assemblyDocument);
                if (assDocId.IsEmpty) return;


                ElementId inclusionOperation = ElementId.Empty;
                DocumentId familyId = DocumentId.Empty;
                try
                {
                    TopSolidHost.Application.StartModification("assembly doc", false);
                    TopSolidHost.Documents.EnsureIsDirty(ref assDocId);

                    familyId = TopSolidHost.Documents.GetDocument(familyPdmObject);

                    inclusionOperation = TopSolidDesignHost.Assemblies.CreateInclusion2(assDocId, ElementId.Empty, null, familyId, codes[0], new List<string>(), new List<SmartObject>(), new List<string>(), new List<SmartDesignObject>(), true, ElementId.Empty, 
                        ElementId.Empty,false,false,false,false,Transform3D.Identity,false);

                    TopSolidHost.Application.EndModification(true, true);
                }
                catch (Exception ee)
                {
                    TopSolidHost.Application.EndModification(false, false);
                }

                if (inclusionOperation.IsEmpty) return;

                DocumentId inclusionDefDoc = TopSolidDesignHost.Assemblies.GetInclusionDefinitionDocument(inclusionOperation);
                if (inclusionDefDoc.IsEmpty) return;

                TopSolidHost.Documents.Open(ref inclusionDefDoc);                

                try
                {
                    TopSolidHost.Application.StartModification("family doc modification", false);
                    TopSolidHost.Documents.EnsureIsDirty(ref familyId);

                    TopSolidHost.Families.SetGenericDocument(familyId, inclusionDefDoc, DocumentId.Empty);

                    TopSolidHost.Application.EndModification(true, true);
                }
                catch (Exception ee)
                {
                    TopSolidHost.Application.EndModification(false, false);
                }


                TopSolidHost.Pdm.Save(TopSolidHost.Documents.GetPdmObject(familyId), true);
                TopSolidHost.Documents.Close(inclusionDefDoc,false,false);

                TopSolidHost.Pdm.DeleteSeveral(new List<PdmObjectId> { TopSolidHost.Documents.GetPdmObject(assDocId) });
            }
        }

        /// <summary>
        /// method to get  documents of a certain type from treeview checked nodes
        /// </summary>
        /// <param name="nodeCollection"></param>
        ///  <param name="nodeCollection"></param>
        /// <param name="checkedDocuments"></param>
        private void GetDocumentsFromTreeView(TreeNodeCollection nodeCollection,string documentExtension, ref List<DocumentId> checkedDocuments)
        {
            foreach (TreeNode node in nodeCollection)
            {
                
                    if (node.ImageKey == documentExtension || node.ImageIndex == 1)
                    {
                        if (node.Tag != null)
                        {
                            PdmObjectId pdmObject = (PdmObjectId)node.Tag;
                            if (pdmObject.IsEmpty) continue;

                            DocumentId documentId = TopSolidHost.Documents.GetDocument(pdmObject);
                            if (documentId.IsEmpty) continue;

                            checkedDocuments.Add(documentId);
                        }
                    }
                
                if (node.Nodes.Count > 0)
                {
                    GetDocumentsFromTreeView(node.Nodes, documentExtension, ref checkedDocuments);
                }
            }
        }

        private void chkUseRedundantName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseRedundantName.Checked) { tbFamilyName.Enabled = false; }
            else if (!chkUseRedundantName.Checked) { tbFamilyName.Enabled = true; }
        }
    }
}

