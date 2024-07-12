using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//TopSolid Automation Kernel
using TopSolid.Kernel.Automating;

namespace ProjectOrganizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.TopSolid_APP;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //checks if topsolid automation is connected to perform operation
            if (TopSolidHost.IsConnected)
            {
                //Gets all working projects from current PDM
                List<PdmObjectId> allWorkingProjects = TopSolidHost.Pdm.GetProjects(true, false);

                ListViewItem.ListViewSubItem[] projectSubItems;
                ListViewItem projectItem = null;

                List<Tuple<PdmObjectId,string,string>> projectsCompleteData=new List<Tuple<PdmObjectId, string, string>>();

                //retrieve data from projects : name and state - keep id as tag of the item
                foreach (PdmObjectId project in allWorkingProjects)
                {
                    string projectName = TopSolidHost.Pdm.GetName(project);
                    string projectState = TopSolidHost.Pdm.GetState(project).ToString();

                    projectsCompleteData.Add(Tuple.Create(project, projectName, projectState));                    
                }

                //then order project list by alphabetical order
                projectsCompleteData.Sort((x, y) => string.Compare(x.Item2, y.Item2, StringComparison.Ordinal));
                foreach (Tuple<PdmObjectId, string, string> projectData in projectsCompleteData)
                {
                    projectItem = new ListViewItem(projectData.Item2);
                    projectItem.Tag = projectData.Item1;
                    projectSubItems = new ListViewItem.ListViewSubItem[]
                        { new ListViewItem.ListViewSubItem(projectItem, projectData.Item3)};
                    projectItem.SubItems.AddRange(projectSubItems);
                    this.listViewProjects.Items.Add(projectItem);
                }
            }
        }

        private void btOrganizeProjects_Click(object sender, EventArgs e)
        {
            //if documents are opened, close them
            TopSolidHost.Documents.CloseAll(true, false);

            for (int i = 0; i < listViewProjects.CheckedItems.Count; i++)
            {
                PdmObjectId projectToOrganize = (PdmObjectId)listViewProjects.CheckedItems[i].Tag;

                if (projectToOrganize.IsEmpty) continue;

                //gets all documents from the project
                Tuple<List<PdmObjectId>, List<PdmObjectId>> documentsAndFolders = GetAllSubDocuments(projectToOrganize);

                //categorize each document according to its type
                //create a dictionaty to store documents
                Dictionary<string, List<PdmObjectId>> documentsDictionary = new Dictionary<string, List<PdmObjectId>>();

                //then check documents to fill dictionary
                foreach (PdmObjectId document in documentsAndFolders.Item1)
                {
                    TopSolidHost.Pdm.GetType(document, out string extension);
                    List<PdmObjectId> result;
                    if (documentsDictionary.TryGetValue(extension,out result))
                    {
                        documentsDictionary[extension].Add(document);
                    }
                    else
                    {
                        documentsDictionary.Add(extension, new List<PdmObjectId> { document });
                    }
                }

                //create one folder per type of document
                foreach (KeyValuePair<string, List<PdmObjectId>> documentTypeData in documentsDictionary)
                {
                    PdmObjectId folderCreated = TopSolidHost.Pdm.CreateFolder(projectToOrganize, documentTypeData.Key.Remove(0, 1));

                    //then move documents
                    TopSolidHost.Pdm.MoveSeveral(documentTypeData.Value, folderCreated);
                }

                //clean: delete existing folders (they should be empty right now, but we'll check this anyway)
                //at first get project folder templates: as they are part of a synchronize group they shouldn't be deleted!
                TopSolidHost.Pdm.GetProjectTemplates(projectToOrganize, out PdmObjectId outTemplatesFolder, out PdmObjectId outDefaultFolder);
                List<PdmObjectId> folderstoDelete = new List<PdmObjectId>(documentsAndFolders.Item2);
                folderstoDelete.Remove(outTemplatesFolder);
                folderstoDelete.Remove(outDefaultFolder);

                //then delete
                TopSolidHost.Pdm.DeleteSeveral(folderstoDelete);
            }
        }

        /// <summary>
        /// Private method to get subdocuments and folders from a project
        /// </summary>
        /// <param name="inProject">the project To Treat</param>
        /// <returns>a tuple with flat list of documents and folders</returns>
        private Tuple<List<PdmObjectId>,List<PdmObjectId>> GetAllSubDocuments(PdmObjectId inProject)
        {
            List<PdmObjectId> allDocuments = new List<PdmObjectId>();
            List<PdmObjectId> allFolders = new List<PdmObjectId>();

            List<PdmObjectId> outFoldersList;
            List<PdmObjectId> outDocumentList;

            //Get all documents and all folders of the first level
            TopSolidHost.Pdm.GetConstituents(inProject, out outFoldersList, out outDocumentList);

            allDocuments.AddRange(outDocumentList);
            allFolders.AddRange(outFoldersList);

            //Redo the method to get all sub sub documents
            foreach (PdmObjectId objectId in outFoldersList)
            {
                allDocuments.AddRange(GetAllSubDocuments(objectId).Item1);
                allFolders.AddRange(GetAllSubDocuments(objectId).Item2);
            }

            return Tuple.Create(allDocuments,allFolders);
        }

        private void btExportPackage_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < listViewProjects.CheckedItems.Count; i++)
            {
                PdmObjectId projectToOrganize = (PdmObjectId)listViewProjects.CheckedItems[i].Tag;

                if (projectToOrganize.IsEmpty) continue;

                //set file full path
                string pathToFile = System.IO.Path.Combine(@"C:\","temp",TopSolidHost.Pdm.GetName(projectToOrganize) + ".TopPkg");

                TopSolidHost.Pdm.ExportPackage(new List<PdmObjectId> { projectToOrganize }, false, false, pathToFile);
            }      
        } 
    }
}
