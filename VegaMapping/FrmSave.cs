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

namespace VegaMapping
{
    public partial class FrmSave : Form
    {
        List<KeyMapping> Keymappings;
        public FrmSave()
        {
            InitializeComponent();
        }

        public FrmSave(List<KeyMapping> keymappings):this()
        {
            Keymappings = keymappings;
            cboMachineMode.Items.Add((int)GameMapping.MachineModel.kb48);
            cboMachineMode.Items.Add((int)GameMapping.MachineModel.kb128);
            cboMachineMode.SelectedIndex = 0;
            saveDialog.Filter = "ZX key map file (.zxk)|*.zxk";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMapping();
        }

        private void SaveMapping()
        {
            GameMapping gm = new GameMapping()
            {
                GameTitle = txtGameTitle.Text,
                FileName = txtFilename.Text,
                KeyMappings = Keymappings
            };
            if (cboMachineMode.SelectedIndex > -1)
            {
                gm.Modle = (GameMapping.MachineModel)(int)cboMachineMode.SelectedItem;
            }

            string validationErrors = string.Empty;
            if(!gm.Validate(ref validationErrors))
            {
                MessageBox.Show(validationErrors, "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                saveDialog.FileName = string.Concat(gm.GameTitle, ".zxk");

                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    File.WriteAllText(saveDialog.FileName, gm.ToString());
                    this.Close();
                    this.Dispose();
                }
            }
        }
    }
}
