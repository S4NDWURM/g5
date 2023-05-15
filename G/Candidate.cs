using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G
{
    public class Candidate
    {
        public int candidate_id { get; set; }
        public string candidate_name { get; set; }
        public int qualification { get; set; }
        public int character_exp { get; set; }
        public bool character_teamw { get; set; }
        public bool character_organize { get; set; }
        public bool character_punctuality { get; set; }
        public decimal character_tarif { get; set; }
 

        public Candidate(DataRow row)
        {
            candidate_id = Convert.ToInt32(row["candidate_id"]);
            candidate_name = Convert.ToString(row["candidate_name"]);
            qualification = Convert.ToInt32(row["qualification"]);
            character_exp = Convert.ToInt32(row["character_exp"]);
            character_teamw = Convert.ToBoolean(row["character_teamw"]);
            character_organize = Convert.ToBoolean(row["character_organize"]);
            character_punctuality = Convert.ToBoolean(row["character_punctuality"]);
            character_tarif = Convert.ToDecimal(row["character_tarif"]);
           

        }
        public Candidate() { }
        public static List<Candidate> select()
        {
            DataTable table = Sqlconnect.select("SELECT * FROM `candidate` ", new List<DbParameter>());
            List<Candidate> students = new List<Candidate>();
            foreach (DataRow row in table.Rows)
            {
                students.Add(new Candidate(row));
            }

            return students;
        }
        public static List<Candidate> search(string colName, string colValue)
        {
            DataTable table = Sqlconnect.select($"SELECT * FROM `candidate`  where `{colName}` like @colValue", new List<DbParameter>() { new DbParameter() { name = "colValue", value = "%" + colValue + "%" } });
            List<Candidate> students = new List<Candidate>();
            foreach (DataRow row in table.Rows)
            {
                students.Add(new Candidate(row));
            }

            return students;
        }
        public void delete()
        {
            Sqlconnect.select("DELETE FROM `candidate` WHERE `candidate_id` = @candidate_id", new List<DbParameter>() { new DbParameter { name = "@candidate_id", value = candidate_id } });


        }
        public static Candidate add(string candidate_name, int qualification, int character_exp, bool character_teamw, bool character_organize, bool character_punctuality, decimal character_tarif)
        {
            Candidate subject = new Candidate();
            subject.candidate_name = candidate_name;
            subject.qualification = qualification;
            subject.character_exp = character_exp;
            subject.character_teamw = character_teamw;
            subject.character_organize = character_organize;
            subject.character_punctuality = character_punctuality;
            subject.character_tarif = character_tarif;

            var par = new List<DbParameter> {
                  new DbParameter { name = "@candidate_name", value = candidate_name} ,       new DbParameter { name = "@qualification", value = qualification} ,     new DbParameter { name = "@character_exp", value = character_exp} ,     new DbParameter { name = "@character_teamw", value = character_teamw} ,     new DbParameter { name = "@character_organize", value = character_organize} ,       new DbParameter { name = "@character_punctuality", value = character_punctuality} ,     new DbParameter { name = "@character_tarif", value = character_tarif}  ,
        };

            subject.candidate_id = Sqlconnect.getscalar("INSERT INTO `candidate` ( `candidate_name`,  `qualification`,  `character_exp`,  `character_teamw`,  `character_organize`,  `character_punctuality`,  `character_tarif`) VALUES (@candidate_name,@qualification,@character_exp,@character_teamw,@character_organize,@character_punctuality,@character_tarif);SELECT LAST_INSERT_ID();", par);

            return subject;
        }
        public static Candidate update(int candidate_id, string candidate_name, int qualification, int character_exp, bool character_teamw, bool character_organize, bool character_punctuality, decimal character_tarif)
        {
            Candidate subject = new Candidate();
            subject.candidate_id = candidate_id;
            subject.candidate_name = candidate_name;
            subject.qualification = qualification;
            subject.character_exp = character_exp;
            subject.character_teamw = character_teamw;
            subject.character_organize = character_organize;
            subject.character_punctuality = character_punctuality;
            subject.character_tarif = character_tarif;
           


            var par = new List<DbParameter> {
          new DbParameter { name = "@candidate_id", value = candidate_id} ,
                   new DbParameter { name = "@candidate_name", value = candidate_name} ,       new DbParameter { name = "@qualification", value = qualification} ,     new DbParameter { name = "@character_exp", value = character_exp} ,     new DbParameter { name = "@character_teamw", value = character_teamw} ,     new DbParameter { name = "@character_organize", value = character_organize} ,       new DbParameter { name = "@character_punctuality", value = character_punctuality} ,     new DbParameter { name = "@character_tarif", value = character_tarif} ,     

           };
            Sqlconnect.select("UPDATE `candidate` SET  `candidate_name` = @candidate_name, `qualification` = @qualification, `character_exp` = @character_exp, `character_teamw` = @character_teamw, `character_organize` = @character_organize, `character_punctuality` = @character_punctuality, `character_tarif` = @character_tarif WHERE `candidate_id` = @candidate_id;", par);

            return subject;
        }
    }
}

