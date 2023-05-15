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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadProjects();
        }
        void loadProjects()
        {
            panel13.Controls.Clear();
            var projects = Project.select();
            foreach (var project in projects)
            {
                UcProject uc = new UcProject(project,this);
                uc.Parent = panel13;
                uc.Dock = DockStyle.Top;
            }
        }
        internal void SetProject(Project project)
        {
            lbCandTr.Text = project.project_cand_count.ToString();
            var projCands = Project_candidate.select().Where(pc => pc.project_id == project.project_id);
            var cands = projCands.Select(pc => pc.candidate).ToList();
            var candRemained = project.project_cand_count - projCands.Count();
            decimal budget= project.project_budget;
            foreach (var projCand in projCands)
            {
                var candidate = projCand.candidate;
                budget -= candidate.character_tarif * projCand.project.project_period ;
            }
            label7.Text = project.project_budget.ToString();
            label6.Text = budget.ToString();
            lbCandF.Text = projCands.Count().ToString();
            
            label13.Text = project.project_period.ToString();
            label14.Text = project.project_skill.ToString();
            List<Candidate> suitableCandidates = Candidate.select()
            .Where(c => c.qualification >= project.project_skill)
            .Where(c => c.character_tarif * project.project_period <= budget)
            .ToList();
            panel14.Controls.Clear();
            foreach (var suitableCandidate in suitableCandidates)
            {
                if (cands.FirstOrDefault(c=>c.candidate_id== suitableCandidate.candidate_id)==null)
                {
                    UcCandidate uc = new UcCandidate(suitableCandidate, project, this);
                    uc.Parent = panel14;
                    uc.Dock = DockStyle.Top;
                }          
            }
        }

        internal void SetCandidateToProject(Candidate candidate, Project project)
        {
            Project_candidate.add(project.project_id, candidate.candidate_id);
            SetProject(project);
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            FormAddProject form = new FormAddProject();
            if (form.ShowDialog() == DialogResult.OK)
            {
                loadProjects();
            }
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            FormAddCandidate form = new FormAddCandidate();
            if (form.ShowDialog() == DialogResult.OK)
            {
                loadProjects();
            }
        }
    }
}
