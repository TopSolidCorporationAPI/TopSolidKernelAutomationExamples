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

//automation
using TopSolid.Kernel.Automating;

namespace TopSolidAutomationControls
{
    [ToolboxItem(true)]
    public partial class DocumentSelector : ListView
    {

        private string documentExtension = ".TopPrt";

        [Browsable(true)]
        [Category("TopSolidAutomation")]
        [Description("Document extension to use")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(".TopPrt")]
        public string DocumentExtension
        {
            get => this.documentExtension;
            set
            {
                this.documentExtension = value;
                this.InitializeComboBox();
                this.Invalidate();
            }
        }
        public bool ShouldSerializeDocumentExtension()
        {
            return documentExtension != ".TopPrt";
        }

        public void ResetDocumentExtension()
        {
            documentExtension = ".TopPrt";
        }


        private SearchOptions searchOption = SearchOptions.NONE;
        public enum SearchOptions
        {
            CURRENT_PROJECT,
            CURRENT_PROJECT_AND_REFERENCES,
            WORKING_PROJECTS,
            LIBRAIRIES,
            NONE,
            ALL
        }

        [Browsable(true)]
        [Category("TopSolidAutomation")]
        [Description("Search options")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(SearchOptions.NONE)]
        public SearchOptions SearchDocumentOptions
        {
            get { return searchOption; }
            set
            {
                searchOption = value;
                if (searchOption != SearchOptions.NONE)
                {
                    this.InitializeComboBox();
                    this.Invalidate();
                }
            }
        }

        public bool ShouldSerializeSearchDocumentOptions()
        {
            return searchOption != SearchOptions.NONE;
        }

        public void ResetSearchDocumentOptions()
        {
            searchOption = SearchOptions.NONE;
        }


        private System.Windows.Forms.AutoScaleMode autoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

        [Browsable(false)]
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

        public bool ShouldSerializeAutoScaleMode()
        {
            return autoScaleMode != AutoScaleMode.Font;
        }

        public void ResetAutoScaleMode()
        {
            autoScaleMode = AutoScaleMode.Font;
        }


        public DocumentSelector()
        {
            this.View = View.List;
            this.Sorting = SortOrder.Ascending;
        }

        private void InitializeComboBox()
        {
            if (TopSolidHost.IsConnected)
            {
                if (searchOption != SearchOptions.NONE)
                    this.Items.Clear();

                PdmObjectId currentProject = TopSolidHost.Pdm.GetCurrentProject();

                switch (searchOption)
                {
                    case SearchOptions.CURRENT_PROJECT:
                        {
                            if (currentProject.IsEmpty) break;

                            List<PdmObjectId> allWantedDocuments = TopSolidHost.Pdm.SearchObjectsWithProperties(new List<PdmObjectId> { currentProject }, false, new List<string>() { documentExtension }, true, -1);

                            foreach (PdmObjectId document in allWantedDocuments.Distinct().ToList())
                            {
                                PdmObjectType objectType = TopSolidHost.Pdm.GetType(document, out string extension);

                                if (extension == this.DocumentExtension)
                                {
                                    this.Items.Add(new ListViewItem { Text = TopSolidHost.Pdm.GetName(document), Tag = document });
                                }
                            }
                        }
                        break;
                    case SearchOptions.CURRENT_PROJECT_AND_REFERENCES:
                        {
                            if (currentProject.IsEmpty) break;

                            List<PdmObjectId> allWantedDocuments = TopSolidHost.Pdm.SearchObjectsWithProperties(new List<PdmObjectId> { currentProject }, true, new List<string>() { documentExtension }, true, -1);

                            foreach (PdmObjectId document in allWantedDocuments.Distinct().ToList())
                            {
                                PdmObjectType objectType = TopSolidHost.Pdm.GetType(document, out string extension);

                                if (extension == this.DocumentExtension)
                                {
                                    this.Items.Add(new ListViewItem { Text = TopSolidHost.Pdm.GetName(document), Tag = document });
                                }
                            }
                        }
                        break;
                    case SearchOptions.WORKING_PROJECTS:
                        {
                            List<PdmObjectId> projectList = TopSolidHost.Pdm.GetProjects(inGetsWorkingProjects: true, false);

                            List<PdmObjectId> allWantedDocuments = TopSolidHost.Pdm.SearchObjectsWithProperties(projectList, false, new List<string>() { documentExtension }, true, -1);

                            foreach (PdmObjectId document in allWantedDocuments.Distinct().ToList())
                            {
                                if (document.IsEmpty) continue;

                                PdmObjectType objectType = TopSolidHost.Pdm.GetType(document, out string extension);
                                if (extension == this.DocumentExtension)
                                {
                                    this.Items.Add(new ListViewItem { Text = TopSolidHost.Pdm.GetName(document), Tag = document });
                                }
                            }

                        }
                        break;
                    case SearchOptions.LIBRAIRIES:
                        {
                            List<PdmObjectId> projectList = TopSolidHost.Pdm.GetProjects(inGetsWorkingProjects: false, true);

                            List<PdmObjectId> allWantedDocuments = TopSolidHost.Pdm.SearchObjectsWithProperties(projectList, true, new List<string>() { documentExtension }, true, -1);

                            foreach (PdmObjectId document in allWantedDocuments.Distinct().ToList()/*subDocumentsInProject*/)
                            {
                                if (document.IsEmpty) continue;

                                PdmObjectType objectType = TopSolidHost.Pdm.GetType(document, out string extension);
                                if (extension == this.DocumentExtension)
                                {
                                    this.Items.Add(new ListViewItem { Text = TopSolidHost.Pdm.GetName(document), Tag = document });
                                }
                            }
                        }
                        break;
                    case SearchOptions.ALL:
                        {
                            List<PdmObjectId> projectList = TopSolidHost.Pdm.GetProjects(inGetsWorkingProjects: true, true);

                            List<PdmObjectId> allWantedDocuments = TopSolidHost.Pdm.SearchObjectsWithProperties(projectList, false, new List<string>() { documentExtension }, true, -1);

                            foreach (PdmObjectId document in allWantedDocuments.Distinct().ToList())
                            {
                                if (document.IsEmpty) continue;

                                PdmObjectType objectType = TopSolidHost.Pdm.GetType(document, out string extension);
                                if (extension == this.DocumentExtension)
                                {
                                    this.Items.Add(new ListViewItem { Text = TopSolidHost.Pdm.GetName(document), Tag = document });
                                }
                            }

                        }
                        break;
                    default:
                        break;
                }
            }
        }


    }
}
