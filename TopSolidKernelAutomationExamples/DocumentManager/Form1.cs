using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

//TopSolid Automation Kernel
using TopSolid.Kernel.Automating;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DocumentManager
{
    public partial class Form1 : Form
    {
        //this Dictionary will store parameter names and their types
        Dictionary<string, ParameterType> listOfParams;

        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.TopSolid_APP;

            txtPackagePath.Enabled = false;
            btBrowse.Enabled = false;

            listOfParams = new Dictionary<string, ParameterType>();

            propertiesPanel.Visible = false;
            this.rdbWorkingProjects.Checked = true;
            PopulateProjectList();

        }

        //methods related to project list management into this app
        #region project selection management
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
            txtParameterValue.Clear();
            listEnumValues.Items.Clear();
            listViewParams.Items.Clear();
        }

        private void rdbWorkingProjects_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdbImportPackage.Checked)
            {
                txtPackagePath.Enabled = false;
                btBrowse.Enabled = false;
            }
            txtParameterValue.Clear();
            listEnumValues.Items.Clear();
            listViewParams.Items.Clear();

            PopulateProjectList();
        }

        private void rdbLibrairies_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdbImportPackage.Checked)
            {
                txtPackagePath.Enabled = false;
                btBrowse.Enabled = false;
            }

            txtParameterValue.Clear();
            listEnumValues.Items.Clear();
            listViewParams.Items.Clear();

            PopulateProjectList();
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

        /// <summary>
        /// Browse for a package to import
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                List<ProjectData> projectListToAddDistinct = projectListToAdd.Distinct().ToList();
                foreach (ProjectData item in projectListToAddDistinct)
                {
                    this.cmbProjectsList.Items.Add(new ProjectData(item.Name, item.Id));
                }
                this.cmbProjectsList.SelectedIndex = 0;
            }
        }
        #endregion

        //methods to populate treeview from PDM and handle treeview selected or checked nodes related to PdmObjects
        #region TreeView Management

        private void PopulateTreeViewWithProjectData(PdmObjectId currentLib)
        {
            TreeNode rootNode;
            rootNode = new TreeNode(TopSolidHost.Pdm.GetName(currentLib));
            rootNode.Tag = currentLib;

            TopSolidHost.Pdm.GetConstituents(currentLib, out List<PdmObjectId> outFolderIds, out List<PdmObjectId> outDocumentIds);

            //Get all documents of all levels except the first one
            foreach (PdmObjectId objectId in outFolderIds)
            {
                TreeNode treeNode = new TreeNode(TopSolidHost.Pdm.GetName(objectId), 0, 0);
                treeNode.ImageIndex = 0;
                treeNode.Tag = objectId;
                treeNode.ImageKey = "folder";
                this.treeViewContent.Nodes.Add(treeNode);
                GetAllSubDocuments(objectId, ref treeNode);
            }

            foreach (PdmObjectId objectId in outDocumentIds)
            {
                TreeNode treeNode = new TreeNode(TopSolidHost.Pdm.GetName(objectId), 1, 1);
                treeNode.Tag = objectId;
                treeNode.ImageIndex = 1;
                treeNode.ImageKey = "file";
                this.treeViewContent.Nodes.Add(treeNode);
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
                TreeNode treeNode = new TreeNode(TopSolidHost.Pdm.GetName(objectId), 1, 1);
                treeNode.Tag = objectId;
                treeNode.ImageKey = "file";
                treeNode.ImageIndex = 1;
                inNode.Nodes.Add(treeNode);
            }

            //Redo the method to get all sub sub documents
            foreach (PdmObjectId objectId in outFoldersList)
            {
                TreeNode treeNode = new TreeNode(TopSolidHost.Pdm.GetName(objectId), 0, 0);
                treeNode.Tag = objectId;
                treeNode.ImageKey = "folder";
                treeNode.ImageIndex = 0;
                inNode.Nodes.Add(treeNode);
                GetAllSubDocuments(objectId, ref treeNode);
            }
        }

        private void cmbProjectsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PdmObjectId libSelected = (this.cmbProjectsList.SelectedItem as ProjectData).Id;

            if (!libSelected.IsEmpty)
            {
                treeViewContent.Nodes.Clear();

                txtParameterValue.Clear();
                listEnumValues.Items.Clear();
                listViewParams.Items.Clear();

                PopulateTreeViewWithProjectData(libSelected);
            }
        }

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

        private void GetCheckedFilesNodes(TreeNodeCollection treeViewNodeCollection, ref List<TreeNode> outTreeNodes)
        {
            foreach (TreeNode item in treeViewNodeCollection)
            {
                if (item.Checked)
                {
                    if (item.ImageIndex == 1 || item.ImageKey == "file")
                        outTreeNodes.Add(item);
                }
                if (item.Nodes.Count > 0)
                {
                    GetCheckedFilesNodes(item.Nodes, ref outTreeNodes);
                }
            }
        }

        private void GetCheckedPdmObjectIds(TreeNodeCollection nodeCollection, ref List<PdmObjectId> checkedObjects)
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

                            checkedObjects.Add(pdmObject);
                        }
                    }
                }
                if (node.Nodes.Count > 0)
                {
                    GetCheckedPdmObjectIds(node.Nodes, ref checkedObjects);
                }
            }
        }

        private void GetObjectsToRemove(TreeNodeCollection nodeCollection, ref List<PdmObjectId> objectsToRemove, ref List<TreeNode> nodesToDelete)
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

                            objectsToRemove.Add(pdmObject);
                            nodesToDelete.Add(node);
                        }
                    }
                }
                if (node.Nodes.Count > 0)
                {
                    GetObjectsToRemove(node.Nodes, ref objectsToRemove, ref nodesToDelete);
                }
            }
        }

        #endregion

        //methods relative to treeview UI behavior
        #region Treeview behavior

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeViewContent.AfterCheck -= treeView1_AfterCheck;

            listOfParams.Clear();

            if (e.Node.Checked)
            {
                if (e.Node.ImageIndex == 0 || e.Node.ImageKey == "folder")
                {
                   CheckTreeNodes(e.Node.Nodes);                    
                }
            }
            else if (!e.Node.Checked)
            {
                if (e.Node.ImageIndex == 0 || e.Node.ImageKey == "folder")
                {
                    UnCheckTreeNodes(e.Node.Nodes);
                }
            }

            treeViewContent.AfterCheck += treeView1_AfterCheck;
        }

        public static void CheckTreeNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {                
                node.Checked = true;
                // If the current node has child nodes, recursively call the method
                if (node.Nodes.Count > 0)
                {
                    CheckTreeNodes(node.Nodes);
                }
            }
        }

        public static void UnCheckTreeNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                // If the current node has child nodes, recursively call the method
                if (node.Nodes.Count > 0)
                {
                    UnCheckTreeNodes(node.Nodes);
                }
            }
        }

        private void treeViewContent_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) return;

            listOfParams.Clear();
            txtParameterValue.Clear();
            listEnumValues.Items.Clear();
            listViewParams.Items.Clear();

            UpdatePreview(e);
            UpdateParamsList(e);
        }

        #endregion

        //method to display preview image from PdmObjectId
        #region Preview Image
        private void UpdatePreview(TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                this.picBoxPreview.Image = null;

                PdmObjectId pdmObject = (PdmObjectId)e.Node.Tag;
                if (pdmObject.IsEmpty) return;

                DocumentId docToModify = TopSolidHost.Documents.GetDocument(pdmObject);
                if (docToModify.IsEmpty) return;

                PdmMinorRevisionId minorRevisionId = TopSolidHost.Pdm.GetFinalMinorRevision(pdmObject);
                if (!minorRevisionId.IsEmpty)
                {
                    Bitmap previewBitmap = TopSolidHost.Pdm.GetMinorRevisionPreviewBitmap(minorRevisionId);
                    if (previewBitmap != null)
                    {
                        this.picBoxPreview.Image = previewBitmap;
                    }
                }
            }
        }
        #endregion

        //Base Pdm methods on documents
        #region Pdm methods
        private void btOpen_Click(object sender, EventArgs e)
        {
            List<DocumentId> documentsToOpen = new List<DocumentId>();
            GetCheckedDocuments(treeViewContent.Nodes, ref documentsToOpen);

            if (documentsToOpen.Count > 0)
            {
                for (int i = 0; i < documentsToOpen.Count; i++)
                {
                    DocumentId docToOpn = documentsToOpen[i];
                    if (docToOpn.IsEmpty) continue;

                    TopSolidHost.Documents.Open(ref docToOpn);
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            List<DocumentId> documentsToSave = new List<DocumentId>();
            GetCheckedDocuments(treeViewContent.Nodes, ref documentsToSave);

            if (documentsToSave.Count > 0)
            {
                //refresh UI
                foreach (DocumentId docToSave in documentsToSave)
                {
                    TopSolidHost.Documents.Save(docToSave);
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            this.listViewParams.Items.Clear();
            this.listEnumValues.Items.Clear();
            this.txtParameterValue.Clear();

            List<PdmObjectId> objectsToDelete = new List<PdmObjectId>();
            List<TreeNode> nodesToremove = new List<TreeNode>();

            GetObjectsToRemove(treeViewContent.Nodes, ref objectsToDelete, ref nodesToremove);

            if (objectsToDelete.Count > 0)
            {
                TopSolidHost.Pdm.DeleteSeveral(objectsToDelete);

                //refresh UI
                foreach (TreeNode nodeToRemove in nodesToremove)
                {
                    this.treeViewContent.Nodes.Remove(nodeToRemove);
                }
            }
        }

        private void btCheckIn_Click(object sender, EventArgs e)
        {
            List<PdmObjectId> objectToCheckIn = new List<PdmObjectId>();
            GetCheckedPdmObjectIds(treeViewContent.Nodes, ref objectToCheckIn);

            if (objectToCheckIn.Count > 0)
            {
                TopSolidHost.Pdm.CheckInSeveral(objectToCheckIn, true);
            }
        }

        private void btCheckOut_Click(object sender, EventArgs e)
        {
            List<PdmObjectId> objectsToCheckOut = new List<PdmObjectId>();
            GetCheckedPdmObjectIds(treeViewContent.Nodes, ref objectsToCheckOut);

            if (objectsToCheckOut.Count > 0)
            {
                foreach (PdmObjectId objectToCheckOut in objectsToCheckOut)
                {
                    TopSolidHost.Pdm.CheckOut(objectToCheckOut);
                }
            }
        }

        private void btUndo_Click(object sender, EventArgs e)
        {
            this.listEnumValues.Items.Clear();
            this.txtParameterValue.Clear();

            List<PdmObjectId> objectsToUndoCheckOut = new List<PdmObjectId>();
            GetCheckedPdmObjectIds(treeViewContent.Nodes, ref objectsToUndoCheckOut);

            if (objectsToUndoCheckOut.Count > 0)
            {
                foreach (PdmObjectId objectToUndoCheckOut in objectsToUndoCheckOut)
                {
                    TopSolidHost.Pdm.UndoCheckOut(objectToUndoCheckOut);
                }
            }
        }
        #endregion
    
        //Modify + clear methods for parameters + UI parameter value display handling
        #region parameter methods
        private void btModify_Click(object sender, EventArgs e)
        {
            List<PdmObjectId> docsToModify = new List<PdmObjectId>();
            List<TreeNode> checkedNodes = new List<TreeNode>();
            GetCheckedFilesNodes(treeViewContent.Nodes, ref checkedNodes);
            foreach (var item in checkedNodes.Select(x => x.Tag).ToList())
            {
                if (item == null) continue;
                docsToModify.Add((PdmObjectId)item);
            }

            if (listViewParams.SelectedItems.Count == 0) return;

            foreach (PdmObjectId docToModify in docsToModify)
            {
                DocumentId docIdToModify = TopSolidHost.Documents.GetDocument(docToModify);

                TopSolidHost.Application.StartModification("Modify Parameter", false);
                try
                {
                    TopSolidHost.Documents.EnsureIsDirty(ref docIdToModify);

                    List<ElementId> parameters = TopSolidHost.Parameters.GetParameters(docIdToModify);
                    var findParameter = (from ElementId eltId in parameters
                                         where TopSolidHost.Elements.GetFriendlyName(eltId) == listViewParams.SelectedItems[0].Text
                                         select eltId).ToList();
                    if (findParameter.Count == 1 && listOfParams.TryGetValue(listViewParams.SelectedItems[0].Text, out ParameterType paramType))
                    {
                        if (paramType != ParameterType.Enumeration && paramType != ParameterType.UserEnumeration)
                        {
                            string currentValue = HelperClass.GetParameterValue(findParameter[0], paramType);

                            switch (paramType)
                            {
                                case ParameterType.Real:
                                    if (HelperClass.GetDoubleValue(this.txtParameterValue.Text,out double doubleValue) && currentValue!= doubleValue.ToString())
                                    {
                                        TopSolidHost.Parameters.SetRealValue(findParameter[0], doubleValue);
                                    }
                                    break;
                                case ParameterType.Integer:
                                    if (HelperClass.GetIntValue(this.txtParameterValue.Text, out int intValue) && currentValue != intValue.ToString())
                                    {
                                        TopSolidHost.Parameters.SetIntegerValue(findParameter[0], intValue);
                                    }
                                    break;
                                case ParameterType.Text:
                                    if (HelperClass.GetTextValue(this.txtParameterValue.Text, out string textValue) && currentValue != textValue)
                                    {
                                        TopSolidHost.Parameters.SetTextValue(findParameter[0], textValue);
                                    }
                                    break;
                                case ParameterType.Tolerance:
                                case ParameterType.Color:
                                case ParameterType.Unclassified:
                                case ParameterType.None:
                                case ParameterType.DateTime:
                                case ParameterType.Family:
                                case ParameterType.Code:
                                case ParameterType.Boolean:                               
                                default:
                                    MessageBox.Show("This type of parameter is not supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;

                            }

                        }
                        else
                        {
                            if (paramType == ParameterType.Enumeration)
                            {
                                if (listEnumValues.SelectedIndex!=-1)
                                {
                                    TopSolidHost.Parameters.SetEnumerationValue(findParameter[0], listEnumValues.SelectedIndex + 1);
                                }                              
                            }
                            else if (paramType == ParameterType.UserEnumeration)
                            {
                                if (listEnumValues.SelectedIndex != -1)
                                {
                                    TopSolidHost.Parameters.SetUserEnumerationValue(findParameter[0], listEnumValues.SelectedIndex + 1);
                                }
                            }
                        }
                    }

                    TopSolidHost.Application.EndModification(true, true);
                    //TopSolidHost.Documents.Save(docIdToModify);
                }
                catch
                {
                    TopSolidHost.Application.EndModification(false, false);
                }
            }

        }

        private void btClear_Click(object sender, EventArgs e)
        {
            List<PdmObjectId> docsToModify = new List<PdmObjectId>();
            List<TreeNode> checkedNodes = new List<TreeNode>();
            GetCheckedFilesNodes(treeViewContent.Nodes, ref checkedNodes);
            foreach (var item in checkedNodes.Select(x => x.Tag).ToList())
            {
                if (item == null) continue;
                docsToModify.Add((PdmObjectId)item);
            }

            if (listViewParams.SelectedItems.Count == 0) return;

            foreach (PdmObjectId docToModify in docsToModify)
            {
                DocumentId docIdToModify = TopSolidHost.Documents.GetDocument(docToModify);

                TopSolidHost.Application.StartModification("Modify Parameter", false);
                try
                {
                    TopSolidHost.Documents.EnsureIsDirty(ref docIdToModify);

                    List<ElementId> parameters = TopSolidHost.Parameters.GetParameters(docIdToModify);
                    var findParameter = (from ElementId eltId in parameters
                                         where TopSolidHost.Elements.GetFriendlyName(eltId) == listViewParams.SelectedItems[0].Text
                                         select eltId).ToList();
                    if (findParameter.Count == 1 && listOfParams.TryGetValue(listViewParams.SelectedItems[0].Text, out ParameterType paramType))
                    {
                        if (paramType != ParameterType.Enumeration && paramType != ParameterType.UserEnumeration)
                        {
                            // Nettoyer valeur
                            TopSolidHost.Parameters.ClearValue(findParameter[0]);
                        }                        
                    }

                    TopSolidHost.Application.EndModification(true, true);
                    TopSolidHost.Documents.Save(docIdToModify);
                }
                catch
                {
                    TopSolidHost.Application.EndModification(false, false);
                }
            }

        }

        private void UpdateParamsList(TreeViewEventArgs e)
        {
            PdmObjectId pdmObject = (PdmObjectId)e.Node.Tag;
            if (pdmObject.IsEmpty) return;

            DocumentId docId = TopSolidHost.Documents.GetDocument(pdmObject);
            if (docId.IsEmpty) return;

            propertiesPanel.Visible = true;

            listViewParams.Items.Clear();
            List<ElementId> parameters = TopSolidHost.Parameters.GetParameters(docId);
            foreach (ElementId param in parameters)
            {
                string paramName = TopSolidHost.Elements.GetName(TopSolidHost.Elements.GetOwner(param));
                if (paramName.Contains("System")) // Vérifiez si le paramètre est un paramètre système
                {
                    string friendlyParamName = TopSolidHost.Elements.GetFriendlyName(param);
                    if (friendlyParamName != string.Empty)
                    {
                        ParameterType paramType = TopSolidHost.Parameters.GetParameterType(param);

                        if (paramType != ParameterType.Unclassified && paramType != ParameterType.None)
                        {
                            listViewParams.Items.Add(new ListViewItem(friendlyParamName));
                            if (!listOfParams.TryGetValue(friendlyParamName, out _))
                            {
                                listOfParams.Add(friendlyParamName, paramType);
                            }
                            else
                            {
                                listOfParams[friendlyParamName] = paramType;
                            }
                            listViewParams.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                    }
                }
            }
        }

        private void listViewParams_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtParameterValue.Clear();
            listEnumValues.Items.Clear();

            if (listViewParams.SelectedItems.Count > 0)
            {
                List<TreeNode> checkedNodes = new List<TreeNode>();
                GetCheckedFilesNodes(treeViewContent.Nodes, ref checkedNodes);

                if (treeViewContent.SelectedNode == null && checkedNodes.Count == 0) return;

                PdmObjectId selectedDocId = PdmObjectId.Empty;
                if (treeViewContent.SelectedNode != null)
                {
                    selectedDocId = (PdmObjectId)treeViewContent.SelectedNode.Tag;
                }
                else
                {
                    selectedDocId = (PdmObjectId)checkedNodes[0].Tag;
                }
                DocumentId docId = TopSolidHost.Documents.GetDocument(selectedDocId);

                if (docId != DocumentId.Empty)
                {
                    List<ElementId> parameters = TopSolidHost.Parameters.GetParameters(docId);
                    var findParameter = (from ElementId eltId in parameters
                                         where TopSolidHost.Elements.GetFriendlyName(eltId) == listViewParams.SelectedItems[0].Text
                                         select eltId).ToList();
                    if (findParameter.Count == 1 && listOfParams.TryGetValue(listViewParams.SelectedItems[0].Text, out ParameterType paramType))
                    {
                        if (paramType != ParameterType.Enumeration && paramType != ParameterType.UserEnumeration)
                        {
                            string currentValue = HelperClass.GetParameterValue(findParameter[0], paramType);
                            txtParameterValue.Text = currentValue;

                            txtParameterValue.Enabled = true;
                            listEnumValues.Enabled = false;
                        }
                        else
                        {
                            if (paramType == ParameterType.Enumeration)
                            {
                                Guid definition = TopSolidHost.Parameters.GetEnumerationDefinition(findParameter[0]);
                                TopSolidHost.Parameters.GetEnumerationValues(definition, out List<int> outValues, out List<string> outTexts);

                                for (int i = 0; i < outTexts.Count; i++)
                                {
                                    listEnumValues.Items.Add(outTexts[i]);
                                }

                                //gets actual value and highlight
                                for (int i = 0; i < outValues.Count; i++)
                                {
                                    if (outValues[i] == TopSolidHost.Parameters.GetEnumerationValue(findParameter[0]))
                                    {
                                        listEnumValues.SelectedIndex = (outValues[i]) - 1;
                                    }
                                }
                                listEnumValues.Enabled = true;
                                txtParameterValue.Enabled = false;
                            }
                            else if (paramType == ParameterType.UserEnumeration)
                            {
                                DocumentId definitionDoc = TopSolidHost.Parameters.GetUserEnumerationDefinition(findParameter[0]);
                                if (!definitionDoc.IsEmpty)
                                {
                                    List<int> values = new List<int>();
                                    List<string> texts = new List<string>();
                                    TopSolidHost.Parameters.GetUserEnumerationValues(definitionDoc, out values, out texts);
                                    for (int i = 0; i < texts.Count; i++)
                                    {
                                        listEnumValues.Items.Add(texts[i]);
                                    }
                                    listEnumValues.Enabled = true;
                                    txtParameterValue.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
