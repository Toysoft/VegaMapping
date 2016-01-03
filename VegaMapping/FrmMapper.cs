using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegaMapping
{
    public partial class FrmMapper : Form
    {

        private bool showSecondaryContorls = false;
        private string[] Abbreviations = new string[]
        {
            "EN",
            "SS",
            "CS",
            "SP",
        };


        public FrmMapper()
        {
            InitializeComponent();

            foreach(Control c in panKeys.Controls)
            {
                if(c.GetType() == typeof(ComboBox))
                {
                    ComboBox cb = (ComboBox)c;
                    cb.Items.AddRange(Abbreviations);
                }
            }

        }

        private void btnSecondary_Click(object sender, EventArgs e)
        {
            ToggleSecondaryControls();
        }

        private void ToggleSecondaryControls()
        {
            showSecondaryContorls = !showSecondaryContorls;

            cboA2.Visible = cboB2.Visible = cboC2.Visible =
                cboDown2.Visible = cboFire2.Visible = cboLeft2.Visible =
                cboOne2.Visible = cboRight2.Visible = cboSelect2.Visible =
                cboTwo2.Visible = cboUp2.Visible = showSecondaryContorls;

            txtA2.Enabled = txtB2.Enabled = txtC2.Enabled =
                txtDown2.Enabled = txtFire2.Enabled = txtLeft2.Enabled =
                txtOne2.Enabled = txtRight2.Enabled = txtSelect2.Enabled =
                txtTwo2.Enabled = txtUp2.Enabled = showSecondaryContorls;


            btnSecondary.Text = showSecondaryContorls ? "Hide Secondary" : "Show Secondary";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string mappingErrors = string.Empty;
            List<KeyMapping> maps = BuildKeyMappings();
            foreach(KeyMapping m in maps)
            {
                m.Validate(ref mappingErrors);
            }

            if(mappingErrors.Length > 0)
            {
                if(MessageBox.Show(mappingErrors, "Key mapping errors", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Retry)
                {
                    ShowSaveDialog(maps);
                }
            }
            else
            {
                ShowSaveDialog(maps);
            }
        }

        private void ShowSaveDialog(List<KeyMapping> mappings)
        {
            FrmSave frmSave = new FrmSave(mappings);
            frmSave.ShowDialog();
        }

        private List<KeyMapping> BuildKeyMappings()
        {
            List<KeyMapping> maps = new List<KeyMapping>();

            #region primary keymapping
            KeyMapping primary = new KeyMapping()
            {
                Up = cboUp1.Text,
                Down = cboDown1.Text,
                Left = cboLeft1.Text,
                Right = cboRight1.Text,
                Fire = cboFire1.Text,
                Select = cboSelect1.Text,
                One = cboOne1.Text,
                Two = cboTwo1.Text,
                A = cboA1.Text,
                B = cboB1.Text,
                C = cboC1.Text,
                StartSequence = txtStartSeq.Text,
                Descriptions = new KeyDescriptions()
                {
                    Up = txtUp1.Text,
                    Down = txtDown1.Text,
                    Left = txtLeft1.Text,
                    Right = txtRight1.Text,
                    Fire = txtFire1.Text,
                    Select = txtSelect1.Text,
                    One = txtOne1.Text,
                    Two = txtTwo1.Text,
                    A = txtA1.Text,
                    B = txtB1.Text,
                    C = txtC1.Text
                }
            };

            maps.Add(primary);
            #endregion

            #region secondary keymapping
            if (showSecondaryContorls)
            {
                KeyMapping secondary = new KeyMapping()
                {
                    Up = cboUp2.Text,
                    Down = cboDown2.Text,
                    Left = cboLeft2.Text,
                    Right = cboRight2.Text,
                    Fire = cboFire2.Text,
                    Select = cboSelect2.Text,
                    One = cboOne2.Text,
                    Two = cboTwo2.Text,
                    A = cboA2.Text,
                    B = cboB2.Text,
                    C = cboC2.Text,
                    Descriptions = new KeyDescriptions()
                    {
                        Up = txtUp2.Text,
                        Down = txtDown2.Text,
                        Left = txtLeft2.Text,
                        Right = txtRight2.Text,
                        Fire = txtFire2.Text,
                        Select = txtSelect2.Text,
                        One = txtOne2.Text,
                        Two = txtTwo2.Text,
                        A = txtA2.Text,
                        B = txtB2.Text,
                        C = txtC2.Text
                    }
                };

                maps.Add(secondary);
            }
            #endregion

            return maps;
        }

        private void btnDescriptions_Click(object sender, EventArgs e)
        {
            panDescriptions.Visible = true;
            this.Width = 590;
        }

        private void btnApplyDescriptsion_Click(object sender, EventArgs e)
        {
            panDescriptions.Visible = false;
            this.Width = 457;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panDescriptions.Visible = false;
            this.Width = 457;
        }
    }
}
