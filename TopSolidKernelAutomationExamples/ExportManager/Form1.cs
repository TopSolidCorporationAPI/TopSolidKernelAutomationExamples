using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TopSolid.Kernel.Automating;
using TopSolid.Cad.Design.Automating;


namespace ExportManager
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> exporterDictionary;

        public Form1()
        {
            InitializeComponent();

            PopulateExporterList();
            PopulatePrintLists();

            toolTip1.SetToolTip(btExport, "Export selected documents using selected format");
            toolTip1.SetToolTip(lbAvailableExportFormats, "Available export formats");
            toolTip1.SetToolTip(cmbRepresentation, "Available representations");
            toolTip1.SetToolTip(txtExportPath, "Export path");
            toolTip1.SetToolTip(pdmTreeView1, "Current project treeview");
            toolTip1.SetToolTip(btBrowse, "Browse...");
            toolTip1.SetToolTip(btPrint, "Print selected document with chosen settings");
            toolTip1.IsBalloon = true;
        }

        //this method populates print lists
        private void PopulatePrintLists()
        {
            cmbPrinterNames.Items.Clear();
            foreach (string printerName in TopSolidHost.Application.PrinterNames)
            {
                cmbPrinterNames.Items.Add(printerName);
            }
            if (cmbPrinterNames.Items.Count > 0) { cmbPrinterNames.SelectedIndex = 0; }

            cmbPrinterFormats.Items.Clear();
            foreach (string paperFormat in TopSolidHost.Application.PaperFormats)
            {
                cmbPrinterFormats.Items.Add(paperFormat);
            }
            if (cmbPrinterFormats.Items.Count > 0) { cmbPrinterFormats.SelectedIndex = 0; }

            cmbPrintColorMapping.SelectedIndex = 0;
        }

        //this method populates exporter lists
        private void PopulateExporterList()
        {
            lbAvailableExportFormats.Items.Clear();

            exporterDictionary = new Dictionary<string, int>();

            //gets available export formats
            for (int i = 0; i < TopSolidHost.Application.ExporterCount; i++)
            {
                //checks if license is valid for this exporter
                if (TopSolidHost.Application.IsExporterValid(i))
                {
                    string fileType = "";
                    string[] fileExtension = null;
                    TopSolidHost.Application.GetExporterFileType(i, out fileType, out fileExtension);

                    List<string> extensions = fileExtension.ToList().ConvertAll(d => d.ToUpper());

                    foreach (string extension in extensions)
                    {
                        if (!exporterDictionary.TryGetValue(extension, out _))
                        {
                            exporterDictionary.Add(extension, i);
                        }
                    }
                }
            }

            //sort list by alphabetical order
            var listSorted = exporterDictionary.OrderBy(x => x.Key).ToList();

            foreach (KeyValuePair<string, int> exporterData in listSorted)
            {
                lbAvailableExportFormats.Items.Add(exporterData);
            }
        }

        #region private methods
        private void btBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified directory
                    string filePath = folderBrowserDialog.SelectedPath;

                    this.txtExportPath.Text = folderBrowserDialog.SelectedPath;
                }
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
                    if (node.ImageKey != "folder" && node.ImageIndex != 0)
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
        #endregion

        private void btExport_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.txtExportPath.Text))
            {
                throw new Exception("Selected folder does not exist!");
            }

            //get all selected files then export to target browser
            List<DocumentId> checkedDocuments = new List<DocumentId> ();
            GetCheckedDocuments(pdmTreeView1.Nodes,ref checkedDocuments);

            //gets importer index from dictionary
            KeyValuePair<string, int> selectedItem = (KeyValuePair<string,int>)(lbAvailableExportFormats.SelectedItem);
            if (exporterDictionary.TryGetValue(selectedItem.Key, out int exporterIndex))
            {
                foreach (DocumentId documentToExport in checkedDocuments)
                {
                    //checks if the document can be exported with this format
                    if (TopSolidHost.Documents.CanExport(exporterIndex, documentToExport))
                    {
                        string filefullPath =System.IO.Path.Combine(txtExportPath.Text, TopSolidHost.Documents.GetName(documentToExport)+selectedItem.Key);

                        if (File.Exists(filefullPath))
                        {
                            DialogResult dr = MessageBox.Show("File already exist! Do you want to overwrite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dr==DialogResult.No)
                            {
                                continue;
                            }
                        }

                        if (chkChooseRepresentation.Checked) //export with options
                        {
                            //search representation to export
                            ElementId representationToExport = TopSolidDesignHost.Representations.GetRepresentations(documentToExport).FirstOrDefault(x => TopSolidHost.Elements.GetName(x).Contains(cmbRepresentation.SelectedItem.ToString()));
                            if (representationToExport.IsEmpty) continue;
                            
                            List<KeyValue> inOptions = new List<KeyValue>();
                            inOptions.Add(new KeyValue("REPRESENTATION_ID", representationToExport.Id.ToString()));
                            TopSolidHost.Documents.ExportWithOptions(exporterIndex, inOptions, documentToExport, filefullPath);
                        }
                        else //export without options 
                        {                            
                            TopSolidHost.Documents.Export(exporterIndex, documentToExport, filefullPath);
                        }

                        MessageBox.Show(String.Format("Exported with success : {0}",filefullPath));
                    }
                }
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            //get all selected files then print 
            List<DocumentId> checkedDocuments = new List<DocumentId>();
            GetCheckedDocuments(pdmTreeView1.Nodes, ref checkedDocuments);

            //gets settings from UI
            PrintColorMapping printColorMapping = PrintColorMapping.Color;
            switch (cmbPrintColorMapping.SelectedIndex)
            {
                case 1:
                    printColorMapping = PrintColorMapping.GreyLevels;
                    break;
                case 2:
                    printColorMapping = PrintColorMapping.BlackAndWhite;
                    break;
                default:
                    break;
            }

            TopSolidHost.Application.CurrentPrinterName = cmbPrinterNames.SelectedItem.ToString();
            TopSolidHost.Application.CurrentPaperFormat = cmbPrinterFormats.SelectedItem.ToString();

            foreach (DocumentId documentToPrint in checkedDocuments)
            {
                if (TopSolidHost.Documents.CanPrint(documentToPrint))
                {
                    TopSolidHost.Documents.Print(documentToPrint, printColorMapping, 300);
                }
            }
        }

        private void chkChooseRepresentation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChooseRepresentation.Checked) { cmbRepresentation.Enabled = true; }
            else { cmbRepresentation.Enabled = false; }
        }
    }
}
