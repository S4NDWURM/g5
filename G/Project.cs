using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G
{
    public class Project
    {
        public int project_id { get; set; }
        public decimal project_budget { get; set; }
        public int project_cand_count { get; set; }
        public string project_name { get; set; }
        public int project_period { get; set; }
        public int project_skill { get; set; }


        public Project(DataRow row)
        {
            project_id = Convert.ToInt32(row["project_id"]);
            project_name = Convert.ToString(row["project_name"]);
            project_cand_count = Convert.ToInt32(row["project_cand_count"]);
            project_budget = Convert.ToDecimal(row["project_budget"]);
            project_period = Convert.ToInt32(row["project_period"]);
            project_skill = Convert.ToInt32(row["project_skill"]);

        }
        public Project() { }
        public static List<Project> select()
        {
            DataTable table = Sqlconnect.select("SELECT * FROM `project` ", new List<DbParameter>());
            List<Project> students = new List<Project>();
            foreach (DataRow row in table.Rows)
            {
                students.Add(new Project(row));
            }

            return students;
        }
        public static List<Project> search(string colName, string colValue)
        {
            DataTable table = Sqlconnect.select($"SELECT * FROM `project`  where `{colName}` like @colValue", new List<DbParameter>() { new DbParameter() { name = "colValue", value = "%" + colValue + "%" } });
            List<Project> students = new List<Project>();
            foreach (DataRow row in table.Rows)
            {
                students.Add(new Project(row));
            }

            return students;
        }
        public void delete()
        {
            Sqlconnect.select("DELETE FROM `project` WHERE `project_id` = @project_id", new List<DbParameter>() { new DbParameter { name = "@project_id", value = project_id } });


        }
        public static Project add(decimal project_budget,int project_cand_count, string project_name, int project_period, int project_skill)
        {
            Project subject = new Project();
            subject.project_budget = project_budget;
            subject.project_cand_count = project_cand_count;
            subject.project_name = project_name;
            subject.project_period = project_period;
            subject.project_skill = project_skill;

            var par = new List<DbParameter> {
                  new DbParameter { name = "@project_budget", value = project_budget} ,new DbParameter { name = "@project_cand_count", value = project_cand_count} ,    new DbParameter { name = "@project_name", value = project_name} ,       new DbParameter { name = "@project_period", value = project_period} ,       new DbParameter { name = "@project_skill", value = project_skill} ,
        };

            subject.project_id = Sqlconnect.getscalar("INSERT INTO `project` ( `project_budget`,`project_cand_count`, `project_name`,  `project_period`,  `project_skill`) VALUES (@project_budget,@project_cand_count,@project_name,@project_period,@project_skill);SELECT LAST_INSERT_ID();", par);

            return subject;
        }
        public static Project update(int project_id,int project_cand_count, decimal project_budget,string project_name, int project_period, int project_skill)
        {
            Project subject = new Project();
            subject.project_id = project_id;
            subject.project_cand_count = project_cand_count;
            subject.project_name = project_name;
            subject.project_budget = project_budget;
            subject.project_period = project_period;
            subject.project_skill = project_skill;


            var par = new List<DbParameter> {
          new DbParameter { name = "@project_id", value = project_id} ,
                   new DbParameter { name = "@project_budget", value = project_budget} ,new DbParameter { name = "@project_cand_count", value = project_cand_count} , new DbParameter { name = "@project_name", value = project_name} ,       new DbParameter { name = "@project_period", value = project_period} ,       new DbParameter { name = "@project_skill", value = project_skill} ,

           };
            Sqlconnect.select("UPDATE `project` SET  `project_budget` = @project_budget,`project_cand_count` = @project_cand_count, `project_period` = @project_period, `project_name` = @project_name, `project_skill` = @project_skill WHERE `project_id` = @project_id;", par);

            return subject;
        }
    }
}

