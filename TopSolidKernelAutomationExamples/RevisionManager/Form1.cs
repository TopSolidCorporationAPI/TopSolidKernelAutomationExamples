using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TopSolid.Kernel.Automating;

namespace RevisionManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region methods to display revisions and properties of revisions
        private void projectTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                //gets pdm object from treeview node
                PdmObjectId objectSelected = (PdmObjectId)e.Node.Tag;

                //check if selected object is a document
                DocumentId docSelected = TopSolidHost.Documents.GetDocument(objectSelected);
                if (docSelected.IsEmpty) return;

                //clears revision treeview
                revisionTreeView.Nodes.Clear();

                List<PdmMajorRevisionId> majorRevisions = TopSolidHost.Pdm.GetMajorRevisions(objectSelected);
                foreach (PdmMajorRevisionId majorRevision in majorRevisions)
                {
                    TreeNode treeNodeMajorRevision = new TreeNode("Major Revision : "+TopSolidHost.Pdm.GetMajorRevisionText(majorRevision));

                    List<PdmMinorRevisionId> minorRevisions = TopSolidHost.Pdm.GetMinorRevisions(majorRevision);
                    foreach (PdmMinorRevisionId minorRevision in minorRevisions)
                    {
                        TreeNode treeNodeMinorRevision = new TreeNode("Minor Revision : "+TopSolidHost.Pdm.GetMinorRevisionText(minorRevision));
                        treeNodeMinorRevision.Tag = minorRevision;
                        treeNodeMajorRevision.Nodes.Add(treeNodeMinorRevision);
                    }

                    revisionTreeView.Nodes.Add(treeNodeMajorRevision);
                }
            }
        }

        private void revisionTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                PdmMinorRevisionId minorRevisionId = (PdmMinorRevisionId)e.Node.Tag;
                if (minorRevisionId.IsEmpty) return;

                Bitmap previewBitmap = TopSolidHost.Pdm.GetMinorRevisionPreviewBitmap(minorRevisionId);
                if (previewBitmap != null)
                {
                    this.previewPicture.Image = previewBitmap;
                }

                PdmMajorRevisionId majorRevision = TopSolidHost.Pdm.GetMajorRevision(minorRevisionId);
                var revLetter = TopSolidHost.Pdm.GetMajorRevisionText(majorRevision);
                PdmLifeCycleMainState lifeCycleMainState = TopSolidHost.Pdm.GetMajorRevisionLifeCycleMainState(majorRevision);
                UpdateLifeCycleStateBitmap(lifeCycleMainState);
            }
        }
        #endregion

        #region LifeCycleState modifications methods

        private void btObsolete_Click(object sender, EventArgs e)
        {
            PdmMajorRevisionId majorRevision = GetMajorRevisionFromTreeView(revisionTreeView.SelectedNode);

            if (majorRevision.IsEmpty) return;

            if (TopSolidHost.Pdm.GetMajorRevisionLifeCycleMainState(majorRevision) == PdmLifeCycleMainState.Validated)
            {
                //mandatory: checkIn before licycle state modification
                TopSolidHost.Pdm.CheckIn(TopSolidHost.Pdm.GetPdmObject(majorRevision), false);

                TopSolidHost.Pdm.SetMajorRevisionLifeCycleMainState(majorRevision, PdmLifeCycleMainState.Obsolete);

                UpdateLifeCycleStateBitmap(PdmLifeCycleMainState.Obsolete);
            }            
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            PdmMajorRevisionId majorRevision = GetMajorRevisionFromTreeView(revisionTreeView.SelectedNode);

            if (majorRevision.IsEmpty) return;

            if (TopSolidHost.Pdm.GetMajorRevisionLifeCycleMainState(majorRevision) == PdmLifeCycleMainState.Design)
            {
                //mandatory: checkIn before licycle state modification
                TopSolidHost.Pdm.CheckIn(TopSolidHost.Pdm.GetPdmObject(majorRevision), false);

                TopSolidHost.Pdm.SetMajorRevisionLifeCycleMainState(majorRevision, PdmLifeCycleMainState.Deleted);

                UpdateLifeCycleStateBitmap(PdmLifeCycleMainState.Deleted);
            }
        }

        private void btValidate_Click(object sender, EventArgs e)
        {
            PdmMajorRevisionId majorRevision = GetMajorRevisionFromTreeView(revisionTreeView.SelectedNode);

            if (majorRevision.IsEmpty) return;

            if (TopSolidHost.Pdm.GetMajorRevisionLifeCycleMainState(majorRevision) == PdmLifeCycleMainState.Design
                || TopSolidHost.Pdm.GetMajorRevisionLifeCycleMainState(majorRevision) == PdmLifeCycleMainState.Obsolete)
            {
                //mandatory: checkIn before licycle state modification
                TopSolidHost.Pdm.CheckIn(TopSolidHost.Pdm.GetPdmObject(majorRevision), false);

                TopSolidHost.Pdm.SetMajorRevisionLifeCycleMainState(majorRevision, PdmLifeCycleMainState.Validated);

                UpdateLifeCycleStateBitmap(PdmLifeCycleMainState.Validated);

            }
        }

        #endregion

        //method to open specific version of a document
        //if the document is not last minor revision of last major revision, it will be opened in read-only mode
        private void btOpen_Click(object sender, EventArgs e)
        {
            PdmMinorRevisionId minorRevisionId = (PdmMinorRevisionId)revisionTreeView.SelectedNode.Tag;
            if (minorRevisionId.IsEmpty) return;

            DocumentId docId = TopSolidHost.Documents.GetMinorRevisionDocument(minorRevisionId);
            TopSolidHost.Documents.Open(ref docId);
        }

        #region private methods

        private PdmMajorRevisionId GetMajorRevisionFromTreeView(TreeNode inSelectedNode)
        {
            if (revisionTreeView.SelectedNode == null) return PdmMajorRevisionId.Empty;

            PdmMinorRevisionId minorRevisionId = (PdmMinorRevisionId)revisionTreeView.SelectedNode.Tag;
            if (minorRevisionId.IsEmpty) return PdmMajorRevisionId.Empty;

            PdmMajorRevisionId majorRevision = TopSolidHost.Pdm.GetMajorRevision(minorRevisionId);
            if (majorRevision.IsEmpty) return PdmMajorRevisionId.Empty;

            return majorRevision;
        }

        private void UpdateLifeCycleStateBitmap(PdmLifeCycleMainState lifeCycleMainState)
        {
            switch (lifeCycleMainState)
            {
                case PdmLifeCycleMainState.None:
                    break;
                case PdmLifeCycleMainState.Design:
                    this.currentStateImage.Image = Properties.Resources.LifeCycleSubStatesDesign.ToBitmap();
                    break;
                case PdmLifeCycleMainState.Validated:
                    this.currentStateImage.Image = Properties.Resources.ValidateMajorRevisionCommand.ToBitmap();
                    break;
                case PdmLifeCycleMainState.Obsolete:
                    this.currentStateImage.Image = Properties.Resources.MakeObsoleteCommand.ToBitmap();
                    break;
                case PdmLifeCycleMainState.Deleted:
                    this.currentStateImage.Image = Properties.Resources.DeleteCommand.ToBitmap();
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
