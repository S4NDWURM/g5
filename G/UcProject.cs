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
    public partial class UcProject : UserControl
    {
        private Project project { get; set; }
        private Form1 parent { get; set; }
        public UcProject(Project project, Form1 parent)
        {
            InitializeComponent();
            this.project = project;
            this.parent = parent;
            guna2TileButton1.Text = project.project_name;
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            parent.SetProject(project);
        }
    }
}
