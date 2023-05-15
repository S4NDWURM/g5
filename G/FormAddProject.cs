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
    public partial class FormAddProject : Form
    {
        public FormAddProject()
        {
            InitializeComponent();
        }

        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            Project.add(Decimal.Parse(guna2TextBox1.Text), Convert.ToInt32(guna2TextBox2.Text), tb.Text, Convert.ToInt32(guna2TextBox3.Text), ComboBoxTables.SelectedIndex);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
