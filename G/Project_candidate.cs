using G;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G
{
    public class Project_candidate
    {
        public int prodect_candidate_id { get; set; }
        public int project_id { get; set; }
        public int candidate_id { get; set; }
      
        public Candidate candidate { get; set; }
        public Project project { get; set; }
  
        public Project_candidate(DataRow row)
        {
            prodect_candidate_id = Convert.ToInt32(row["prodect_candidate_id"]);
            project_id = Convert.ToInt32(row["project_id"]);
            candidate_id = Convert.ToInt32(row["candidate_id"]);
            candidate = new Candidate
            {
                candidate_id = Convert.ToInt32(row["candidate_id"]),
                candidate_name = Convert.ToString(row["candidate_name"]),
                qualification = Convert.ToInt32(row["qualification"]),
                character_exp = Convert.ToInt32(row["character_exp"]),
                character_teamw = Convert.ToBoolean(row["character_teamw"]),
                character_organize = Convert.ToBoolean(row["character_organize"]),
                character_punctuality = Convert.ToBoolean(row["character_punctuality"]),
                character_tarif = Convert.ToDecimal(row["character_tarif"]),
            };
            project = new Project
            {
                project_id = Convert.ToInt32(row["project_id"]),
                project_budget = Convert.ToDecimal(row["project_budget"]),
                project_name = Convert.ToString(row["project_name"]),
                project_period = Convert.ToInt32(row["project_period"]),
                project_skill = Convert.ToInt32(row["project_skill"]),
            };
         

        }
        public Project_candidate() { }
        public static List<Project_candidate> select()
        {
            DataTable table = Sqlconnect.select("SELECT * FROM `project_candidate` LEFT JOIN candidate ON project_candidate.candidate_id = candidate.candidate_id LEFT JOIN project ON project_candidate.project_id = project.project_id ", new List<DbParameter>());
            List<Project_candidate> students = new List<Project_candidate>();
            foreach (DataRow row in table.Rows)
                students.Add(new Project_candidate(row));
            return students;
        }
        public static List<Project_candidate> search(string colName, string colValue)
        {
            DataTable table = Sqlconnect.select($"SELECT * FROM `project_candidate` LEFT JOIN candidate ON project_candidate.candidate_id = candidate.candidate_id LEFT JOIN project ON project_candidate.project_id = project.project_id where `{colName}` like @colValue", new List<DbParameter>() { new DbParameter() { name = "colValue", value = "%" + colValue + "%" } });
            List<Project_candidate> students = new List<Project_candidate>();
            foreach (DataRow row in table.Rows)
                students.Add(new Project_candidate(row));
            return students;
        }
        public void delete()
        {
            Sqlconnect.select("DELETE FROM `project_candidate` WHERE `prodect_candidate_id` = @prodect_candidate_id", new List<DbParameter>() { new DbParameter { name = "@prodect_candidate_id", value = prodect_candidate_id } });
        }
        public static Project_candidate add(int project_id, int candidate_id)
        {
            Project_candidate subject = new Project_candidate();
            subject.project_id = project_id;
            subject.candidate_id = candidate_id;
        
            var par = new List<DbParameter> {
                new DbParameter { name = "@project_id", value = project_id},       
                new DbParameter { name = "@candidate_id", value = candidate_id},       
                
            };
            subject.prodect_candidate_id = Sqlconnect.getscalar("INSERT INTO `project_candidate` ( `project_id`,  `candidate_id`) VALUES (@project_id,@candidate_id);SELECT LAST_INSERT_ID();", par);
            return subject;
        }
        public static Project_candidate update(int prodect_candidate_id, int project_id, int candidate_id)
        {
            Project_candidate subject = new Project_candidate();
            subject.prodect_candidate_id = prodect_candidate_id;
            subject.project_id = project_id;
            subject.candidate_id = candidate_id;
            
            var par = new List<DbParameter> {
                new DbParameter { name = "@prodect_candidate_id", value = prodect_candidate_id},
                new DbParameter { name = "@project_id", value = project_id},
                new DbParameter { name = "@candidate_id", value = candidate_id},
            };
            Sqlconnect.select("UPDATE `project_candidate` SET  `project_id` = @project_id, `candidate_id` = @candidate_id WHERE `prodect_candidate_id` = @prodect_candidate_id;", par);
            return subject;
        }
    }
}

