using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G
{
    public partial class FormAddCandidate : Form
    {
        public FormAddCandidate()
        {
            InitializeComponent();
        }

        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            Candidate.add(guna2TextBox1.Text, ComboBoxTables.SelectedIndex,Convert.ToInt32(guna2TextBox2.Text), guna2CheckBox1.Enabled, guna2CheckBox2.Enabled, guna2CheckBox3.Enabled,Convert.ToDecimal(guna2TextBox3.Text));
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
