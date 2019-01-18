using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;

namespace langToExcel {
    public partial class Form1 : Form {

        [Serializable]
        public class LangFile {
            public string name;
            public string path;
            public List<string> lines = new List<string>();

            public LangFile(string name, string path, string[] lines) {
                this.name = name;
                this.path = path;
                this.lines = lines.ToList();
            }
        }

        public List<LangFile> Files = new List<LangFile>();

        public Form1() {
            InitializeComponent();
        }

        private void loadLangBtn_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;

            if (dialog.ShowDialog() == DialogResult.OK) {
                DirectoryInfo info = new DirectoryInfo(dialog.SelectedPath);
                FileInfo[] files = info.GetFiles();

                Files.Clear();
                langPathText.Text = dialog.SelectedPath;

                treeView.BeginUpdate();
                treeView.Nodes.Clear();
                treeView.Nodes.Add(info.Name);

                foreach (FileInfo file in files) {
                    if (file.Extension != ".lang")
                        continue;
                    Files.Add(new LangFile(file.Name, file.FullName, File.ReadAllLines(file.FullName)));
                    treeView.Nodes[0].Nodes.Add(file.Name);
                }
                treeView.EndUpdate();
                convertXlsBtn.Enabled = true;
            }
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            string file = e.Node.Text;
            for (int i = 0; i < Files.Count; i++) {
                if (Files[i].name == file) {
                    langPreview.Items.Clear();
                    for (int j = 0; j < Files[i].lines.Count; j++) {
                        langPreview.Items.Add(Files[i].lines[j]);
                    }
                    return;
                }
            }
        }

        private void convertXlsBtn_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            
            if (dialog.ShowDialog() == DialogResult.OK) {

                string filePath = Path.Combine(dialog.SelectedPath, "generated_from_lang.xls");

                using (ExcelPackage excel = new ExcelPackage()) {

                    for (int i = 0; i < Files.Count; i++) {
                        excel.Workbook.Worksheets.Add(Files[i].name);

                        List<string[]> header = new List<string[]> { new string[] {"ID", "Original", "Translation"}};

                        string headerRange = "A1:" + char.ConvertFromUtf32(header[0].Length + 64) + "1";

                        ExcelWorksheet worksheet = excel.Workbook.Worksheets[Files[i].name];
                        worksheet.Cells[headerRange].LoadFromArrays(header);

                        if (formatHeader.Checked) {
                            worksheet.Cells[headerRange].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                            worksheet.Cells[headerRange].Style.Font.Bold = true;
                        }

                        for (int j = 0; j < Files[i].lines.Count; j++) {
                            string[] line = Files[i].lines[j].Split('=');
                            if (line.Length != 2)
                                continue;
                            worksheet.Cells["A" + (j + 2)].Value = line[0];
                            worksheet.Cells["B" + (j + 2)].Value = line[1];
                        }

                        if (scaleColumns.Checked)
                            worksheet.Cells["A2:" + (Files[i].lines.Count + 2)].AutoFitColumns();
                    }

                    try {
                        FileInfo excelFile = new FileInfo(filePath);
                        excel.SaveAs(excelFile);
                    } catch (Exception) {
                        if (MessageBox.Show("Could not create excel file.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry) {
                            convertXlsBtn.PerformClick();
                        }
                        return;
                    }

                    if (openWhenFinished.Checked) {
                        if (Type.GetTypeFromProgID("Excel.Application") != null) {
                            System.Diagnostics.Process.Start(filePath);
                        } else {
                            MessageBox.Show("Excel does not seem to be installed. Cannot open file automatically. Saved at " + filePath, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }
    }
}
