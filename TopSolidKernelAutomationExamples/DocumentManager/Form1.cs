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

namespace DocumentManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.TopSolid_APP;

            txtPackagePath.Enabled = false;
            btBrowse.Enabled = false;

            treeViewContent.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeViewContent_NodeMouseClick);

    }

    private void rdbImportPackage_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbImportPackage.Checked)
            {
                txtPackagePath.Enabled = true;
                btBrowse.Enabled = true;
                cmbProjectsList.Items.Clear();
            }
            else
            {
                txtPackagePath.Enabled = false;
                btBrowse.Enabled = false;
            }
        }

        private void rdbWorkingProjects_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdbImportPackage.Checked)
            {
                txtPackagePath.Enabled = false;
                btBrowse.Enabled = false;
            }
           PopulateProjectList();
        }

        private void rdbLibrairies_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdbImportPackage.Checked)
            {
                txtPackagePath.Enabled = false;
                btBrowse.Enabled = false;
            }
            PopulateProjectList();
        }

        public class ProjectData
        {
            public string Name { get; set; }
            public PdmObjectId Id { get; set; }
            public ProjectData(string _name, PdmObjectId _id) { Name = _name; Id = _id; }
        }

        private void PopulateProjectList()
        {
            this.cmbProjectsList.Items.Clear();

            List<ProjectData> projectListToAdd = new List<ProjectData>();
            List<PdmObjectId> projectList = TopSolidHost.Pdm.GetProjects(rdbWorkingProjects.Checked, rdbLibrairies.Checked);
            foreach (PdmObjectId project in projectList)
            {
                projectListToAdd.Add(new ProjectData(TopSolidHost.Pdm.GetName(project), project));
            }
            projectListToAdd.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));
            foreach (ProjectData item in projectListToAdd)
            {
                this.cmbProjectsList.Items.Add(new ProjectData(item.Name, item.Id));
            }

        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "TopPkg files (*.TopPkg)|*.TopPkg";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    string filePath = openFileDialog.FileName;

                    this.txtPackagePath.Text = openFileDialog.FileName;
                }
            }

            //import package then update project list
            List<PdmObjectId> importedPdmObjects = TopSolidHost.Pdm.ImportPackageAsDistinctCopy(this.txtPackagePath.Text, false, false);

            if (importedPdmObjects.Count > 0)
            {
                this.cmbProjectsList.Items.Clear();

                List<ProjectData> projectListToAdd = new List<ProjectData>();
                foreach (PdmObjectId pdmObjectId in importedPdmObjects)
                {
                    projectListToAdd.Add(new ProjectData(TopSolidHost.Pdm.GetName(pdmObjectId), pdmObjectId));
                }
                projectListToAdd.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));
                foreach (ProjectData item in projectListToAdd)
                {
                    this.cmbProjectsList.Items.Add(new ProjectData(item.Name, item.Id));
                }
                this.cmbProjectsList.SelectedIndex = 0;
            }
        }

        private void cmbProjectsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PdmObjectId libSelected = (this.cmbProjectsList.SelectedItem as ProjectData).Id;

            treeViewContent.Nodes.Clear();
            PopulateTreeViewWithProjectData(libSelected);
        }

        private void PopulateTreeViewWithProjectData(PdmObjectId currentLib)
        {
            TreeNode rootNode;
            rootNode = new TreeNode(TopSolidHost.Pdm.GetName(currentLib));
            rootNode.Tag = currentLib;

            TopSolidHost.Pdm.GetConstituents(currentLib, out List<PdmObjectId> outFolderIds, out List<PdmObjectId> outDocumentIds);

            //Get all documents of all levels except the first one
            foreach (PdmObjectId objectId in outFolderIds)
            {
                TreeNode treeNode = new TreeNode(TopSolidHost.Pdm.GetName(objectId));
                treeNode.ImageIndex = 0;
                this.treeViewContent.Nodes.Add(treeNode);
                GetAllSubDocuments(objectId, ref treeNode);
            }

            treeViewContent.AfterCheck += new TreeViewEventHandler(treeView1_AfterCheck);
        }

        /// <summary>
        /// Gets all sub documents of a folder.
        /// </summary>
        /// <param name="folderId">The folder identifier.</param>
        private void GetAllSubDocuments(PdmObjectId folderId, ref TreeNode inNode)
        {
            List<PdmObjectId> outFoldersList;
            List<PdmObjectId> outDocumentList;

            //Get all documents and all folders of the first level
            TopSolidHost.Pdm.GetConstituents(folderId, out outFoldersList, out outDocumentList);

            //Get all documents of the first level
            foreach (PdmObjectId objectId in outDocumentList)
            {
                TreeNode treeNode = new TreeNode(TopSolidHost.Pdm.GetName(objectId),1,1);
                treeNode.Tag = objectId;
                treeNode.ImageKey = "file";

                TopSolidHost.Pdm.GetType(objectId, out string extension);
                treeNode.ImageIndex = 1;

                inNode.Nodes.Add(treeNode);
            }

            //Redo the method to get all sub sub documents
            foreach (PdmObjectId objectId in outFoldersList)
            {
                TreeNode treeNode = new TreeNode(TopSolidHost.Pdm.GetName(objectId),0,0);
                treeNode.Tag = objectId;
                treeNode.ImageKey = "folder";

                inNode.Nodes.Add(treeNode);

                GetAllSubDocuments(objectId, ref treeNode);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // Prevent recursive event triggering
            treeViewContent.AfterCheck -= treeView1_AfterCheck;

            if (e.Node.Checked)
            {
                UncheckAllNodes(treeViewContent.Nodes, e.Node);
            }

            // Reattach the event handler
            treeViewContent.AfterCheck += treeView1_AfterCheck;
        }

        private void UncheckAllNodes(TreeNodeCollection nodes, TreeNode exceptionNode)
        {
            foreach (TreeNode node in nodes)
            {
                if (node != exceptionNode)
                {
                    node.Checked = false;
                }

                // Recursively uncheck child nodes
                if (node.Nodes.Count > 0)
                {
                    UncheckAllNodes(node.Nodes, exceptionNode);
                }
            }
        }

        private void treeViewContent_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

    }
}
