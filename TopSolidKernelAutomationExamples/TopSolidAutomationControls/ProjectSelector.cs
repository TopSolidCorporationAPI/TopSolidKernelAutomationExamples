using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopSolid.Kernel.Automating;
using static TopSolidAutomationControls.DocumentSelector;

namespace TopSolidAutomationControls
{
    public partial class ProjectSelector : ComboBox
    {
        private ProjectSelectionOptions projectSelectionOptions = ProjectSelectionOptions.WORKING_PROJECTS;
        public enum ProjectSelectionOptions
        {
            WORKING_PROJECTS,
            LIBRAIRIES,
            ALL
        }

        [Category("TopSolidAutomation")]
        [Description("Project Selection options")]
        [DefaultValue(ProjectSelectionOptions.WORKING_PROJECTS)]
        public ProjectSelectionOptions ProjectSelectionType
        {
            get { return projectSelectionOptions; }
            set { projectSelectionOptions = value; this.Invalidate(); }
        }

        private System.Windows.Forms.AutoScaleMode autoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        public System.Windows.Forms.AutoScaleMode AutoScaleMode
        {
            get { return autoScaleMode; }
            set
            {
                autoScaleMode = value;
                this.Invalidate();
            }
        }


        public ProjectSelector()
        {
            InitializeComponent();

            this.DisplayMember = "Key";

            InitializeCombobox();
        }

        private void InitializeCombobox()
        {
            this.Items.Clear();


            bool selectLibrairies = false;
            bool selectWorkingProjects= true;

            switch (projectSelectionOptions)
            {
                case ProjectSelectionOptions.WORKING_PROJECTS:
                    {
                        selectLibrairies = false;
                        selectWorkingProjects = true;
                    }
                    break;
                case ProjectSelectionOptions.LIBRAIRIES:
                    {
                        selectLibrairies = true;
                        selectWorkingProjects = false;
                    }
                    break;
                case ProjectSelectionOptions.ALL:
                    {
                        selectLibrairies = true;
                        selectWorkingProjects = true;
                    }
                    break;
                default:
                    break;
            }

            try
            {
                List<PdmObjectId> projectList = TopSolidHost.Pdm.GetProjects(selectWorkingProjects, selectLibrairies);
                List<KeyValuePair<string, PdmObjectId>> projectListToAdd = new List<KeyValuePair<string, PdmObjectId>>();
                foreach (PdmObjectId project in projectList)
                {
                    if (project.IsEmpty) continue;
                    projectListToAdd.Add(new KeyValuePair<string, PdmObjectId>(TopSolidHost.Pdm.GetName(project), project));
                }
                projectListToAdd.Sort((x, y) => string.Compare(x.Key, y.Key, StringComparison.Ordinal));
                foreach (KeyValuePair<string, PdmObjectId> item in projectListToAdd)
                {
                    this.Items.Add(new KeyValuePair<string, PdmObjectId>(item.Key, item.Value));
                }
            }catch (Exception ex)
            {
            }
        }
    }
}
