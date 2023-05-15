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
    public partial class UcCandidate : UserControl
    {
        public Candidate candidate { get; set; }
        public Project project { get; set; }
        public Form1 parent { get; set; }
        public UcCandidate(Candidate candidate, Project project, Form1 parent)
        {
            InitializeComponent();
            this.candidate = candidate;
            this.parent = parent;
            this.project = project;
            textBox1.Text = candidate.candidate_name;
            textBox2.Text = candidate.qualification.ToString();
            textBox4.Text = candidate.character_exp.ToString();
            bunifuCheckbox1.Enabled = candidate.character_teamw;
            textBox5.Text = candidate.character_tarif.ToString() ;
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            parent.SetCandidateToProject(candidate, project);
        }
    }
}
