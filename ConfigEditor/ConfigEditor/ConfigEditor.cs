using System;
using System.Windows.Forms;
using ConfigEditor.XML;

namespace ConfigEditor
{
    public partial class ConfigEditor : Form
    {
        public ConfigEditor()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    lblFileName.Text = string.Empty;
                    IConfigEditorXml cex = new ConfigEditorXml();
                    if (cex.ValidateXmlFile(ofd.FileName))
                        cex.OpenXmlFile(ofd.FileName);
                    else
                    {
                        MessageBox.Show($"Fehler beim Validieren der Datei '{ofd.FileName}'!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    lblFileName.Text = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ausnahme beim Öffnen des XML-Files! Ausnahme: '{ex.Message}'");
            }
        }
    }
}
