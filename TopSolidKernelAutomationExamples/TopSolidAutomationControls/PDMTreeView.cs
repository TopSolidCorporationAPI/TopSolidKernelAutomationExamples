using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//automation
using TopSolid.Kernel.Automating;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static TopSolidAutomationControls.DocumentSelector;
using TreeView = System.Windows.Forms.TreeView;

namespace TopSolidAutomationControls
{
    [ToolboxItem(true)]
    public partial class PDMTreeView : TreeView
    {
        private bool multipleCheck = false;
        private TreeNode _firstCheckedNode; // Stocke le premier nœud coché

        [Browsable(true)]
        [Category("TopSolidAutomation")]
        [Description("True if user can select multiple items.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(false)]
        public bool MultipleCheck
        {
            get { return multipleCheck; }
            set
            {
                multipleCheck = value;
                this.Invalidate();
            }
        }

        private string[] documentTypes = new string[0];

        [Browsable(true)]
        [Category("TopSolidAutomation")]
        [Description("If not empty, used to filter document types to show")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string[] DocumentTypes
        {
            get { return documentTypes; }
            set
            {
                documentTypes = value;
                InitializeTreeView();
                this.Invalidate();
            }
        }

        private ContextMenuStrip contextMenuStrip1; // Menu contextuel

        private ImageList imageList1;

        private System.Windows.Forms.AutoScaleMode autoScaleMode = AutoScaleMode.Font;

        [Browsable(false)]
        [Category("TopSolidAutomation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(AutoScaleMode.Font)]
        public System.Windows.Forms.AutoScaleMode AutoScaleMode
        {
            get { return autoScaleMode; }
            set
            {
                autoScaleMode = value;
                this.Invalidate();
            }
        }

        public PDMTreeView()
        {
            //InitializeTreeView();

            InitializeContextMenu();
        }

        private void InitializeTreeView()
        {
            // Initialisation de l'ImageList
            InitializeImageList();
            this.ImageList = imageList1;

            // Abonnement de l'événement AfterCheck
            this.AfterCheck += new TreeViewEventHandler(treeView1_AfterCheck);

            FillTreeView();

            // Abonnement de l'événement MouseDown pour gérer le clic droit
            this.MouseDown += ProjectTreeview_MouseDown;
        }

        private void InitializeContextMenu()
        {
            // Création du menu contextuel
            contextMenuStrip1 = new ContextMenuStrip();

            // Ajout des éléments de menu
            ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Update TreeView");
            menuItem1.Click += UpdateTreeView_Click;
            contextMenuStrip1.Items.Add(menuItem1);

            // Associer le menu contextuel au contrôle TreeView
            this.ContextMenuStrip = contextMenuStrip1;
        }

        private void UpdateTreeView_Click(object sender, EventArgs e)
        {
            FillTreeView();
        }

        private void ProjectTreeview_MouseDown(object sender, MouseEventArgs e)
        {
            // Vérifier si le clic est effectué avec le bouton droit de la souris
            if (e.Button == MouseButtons.Right)
            {
                // Obtenir les coordonnées du clic
                Point p = new Point(e.X, e.Y);

                // Convertir les coordonnées du contrôle en coordonnées de l'écran
                p = this.PointToScreen(p);

                // Afficher le menu contextuel à la position du curseur
                contextMenuStrip1.Show(p);
            }
        }

        private void InitializeImageList()
        {
            // Création et configuration de l'ImageList
            imageList1 = new ImageList();            

            // Obtenir toutes les ressources à partir de la classe Properties.Resources
            var resManager = new ResourceManager(typeof(Properties.Resources));

            try
            {
                imageList1.Images.Add("folder", Properties.Resources.folderNEW);
                imageList1.Images.Add("file", Properties.Resources.fileNew);
               
                //imageList1.Images.Add(".TopPrt", Properties.Resources.PartDocument);
                //imageList1.Images.Add(".TopAsm", Properties.Resources.AssemblyDocument);
                //imageList1.Images.Add(".TopFam", Properties.Resources.FamilyDocument);

                foreach (var resource in typeof(Properties.Resources).GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    // Vérifier que la ressource est une icône ou une image
                    if (resource.PropertyType == typeof(Icon))
                    {
                        string resourceName = resource.Name;

                        // Ajouter l'icône à l'ImageList
                        Icon icon = (Icon)resource.GetValue(null, null);
                        imageList1.Images.Add("."+resourceName,icon);
                    }                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des images : " + ex.Message);
            }
        }

        private void FillTreeView()
        {
            this.Nodes.Clear();

            if (TopSolidHost.IsConnected)
            {
                TreeNode rootNode;
                PdmObjectId currentProject = TopSolidHost.Pdm.GetCurrentProject();

                if (currentProject.IsEmpty) return;

                rootNode = new TreeNode(TopSolidHost.Pdm.GetName(currentProject));
                rootNode.Tag = currentProject;

                TopSolidHost.Pdm.GetConstituents(currentProject, out List<PdmObjectId> outFolderIds, out List<PdmObjectId> outDocumentIds);

                //Get all documents of all levels except the first one
                foreach (PdmObjectId objectId in outFolderIds)
                {
                    TreeNode treeNode = new TreeNode(TopSolidHost.Pdm.GetName(objectId), 0, 0);
                    treeNode.ImageIndex = 0;
                    treeNode.ImageKey = "folder";
                    treeNode.SelectedImageIndex = 0;
                    treeNode.Tag = objectId;
                    this.Nodes.Add(treeNode);
                    GetAllSubDocuments(objectId, ref treeNode);
                }
                foreach (PdmObjectId objectId in outDocumentIds)
                {
                    bool showFile = true;
                    TopSolidHost.Pdm.GetType(objectId, out string extension);
                    if (documentTypes.Count() > 0 && !documentTypes.Contains(extension))
                    {
                        showFile = false;
                    }

                    if (showFile)
                    {
                        TopSolidHost.Pdm.GetType(objectId, out string extensionPdmObject);
                        string imageKey = extensionPdmObject==null? "file":extensionPdmObject.ToString();
                        List<string> extensionList = new List<string> { ".TopPrt", ".TopAsm", ".TopFam" };

                        TreeNode treeNode = new TreeNode(TopSolidHost.Pdm.GetName(objectId), 1, 1)
                        {
                            ImageIndex = 1,
                            Tag = objectId,
                            SelectedImageKey = extensionList.Contains(imageKey) ? imageKey : "file",
                            ImageKey = extensionList.Contains(imageKey)? imageKey :"file"
                        };

                        this.Nodes.Add(treeNode);
                    }
                }
            }
        }

        private void GetAllSubDocuments(PdmObjectId folderId, ref TreeNode inNode)
        {
            List<PdmObjectId> outFoldersList;
            List<PdmObjectId> outDocumentList;

            //Get all documents and all folders of the first level
            TopSolidHost.Pdm.GetConstituents(folderId, out outFoldersList, out outDocumentList);

            //Get all documents of the first level
            foreach (PdmObjectId objectId in outDocumentList)
            {
                bool showFile = true;
                TopSolidHost.Pdm.GetType(objectId, out string extension);
                if (documentTypes.Count() > 0 && !documentTypes.Contains(extension))
                {
                    showFile = false;
                }

                if (showFile)
                {
                    TopSolidHost.Pdm.GetType(objectId, out string extensionPdmObject);
                    string imageKey = extensionPdmObject == null ? "file" : extensionPdmObject.ToString();
                    List<string> extensionList = new List<string> { ".TopPrt", ".TopAsm", ".TopFam" };

                    TreeNode treeNode = new TreeNode(TopSolidHost.Pdm.GetName(objectId), 1, 1)
                    {
                        ImageIndex = 1,
                        Tag = objectId,
                        SelectedImageKey = extensionList.Contains(imageKey) ? imageKey : "file",
                        ImageKey = extensionList.Contains(imageKey) ? imageKey : "file"
                    };

                    //treeNode.Tag = objectId;
                    //treeNode.ImageKey = extensionList.Contains(imageKey) ? imageKey : "file";
                    //treeNode.SelectedImageKey = extensionList.Contains(imageKey) ? imageKey : "file";
                    //treeNode.ImageIndex = 1;


                    inNode.Nodes.Add(treeNode);
                }
            }

            //Redo the method to get all sub sub documents
            foreach (PdmObjectId objectId in outFoldersList)
            {
                TreeNode treeNode = new TreeNode(TopSolidHost.Pdm.GetName(objectId), 0, 0);
                treeNode.Tag = objectId;
                treeNode.ImageKey = "folder";
                treeNode.ImageIndex = 0;
                treeNode.SelectedImageIndex =0;
                inNode.Nodes.Add(treeNode);
                GetAllSubDocuments(objectId, ref treeNode);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // Prevent recursive event triggering
            this.AfterCheck -= treeView1_AfterCheck;

            if (ModifierKeys.HasFlag(Keys.Shift) && _firstCheckedNode != null)
            {
                // Sélectionner tous les nœuds entre le premier et le nœud actuel
                CheckNodesBetween(_firstCheckedNode, e.Node, e.Node.Checked);
            }
            else
            {
                // Si ce n'est pas la touche Shift, mémoriser le premier nœud coché
                _firstCheckedNode = e.Node;

                if (e.Node.Checked)
                {
                    if (this.CheckBoxes == true && !multipleCheck)
                    {
                        UncheckAllNodes(this.Nodes, e.Node);
                    }
                }
                if (multipleCheck)
                {
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
                }
            }

            // Reattach the event handler
            this.AfterCheck += treeView1_AfterCheck;
        }

        // Méthode pour cocher/décocher tous les nœuds entre le premier et le dernier sélectionné
        private void CheckNodesBetween(TreeNode startNode, TreeNode endNode, bool isChecked)
        {
            TreeNode parentNode = startNode.Parent ?? this.Nodes[0]; // Récupérer le parent des nœuds sélectionnés
            TreeNodeCollection nodeCollection = parentNode.Nodes;

            // Récupérer les indices des nœuds de début et de fin
            int startIndex = nodeCollection.IndexOf(startNode);
            int endIndex = nodeCollection.IndexOf(endNode);

            // Assurer l'ordre des indices
            if (startIndex > endIndex)
            {
                (startIndex, endIndex) = (endIndex, startIndex);
            }

            // Boucle pour cocher/décocher les nœuds entre les deux
            for (int i = startIndex; i <= endIndex; i++)
            {
                nodeCollection[i].Checked = isChecked; // Cocher ou décocher selon l'état du nœud actuel
            }
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

    }
}
