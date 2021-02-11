using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
   public class ApplicantSkillRepository : BaseAdo, IDataRepository<ApplicantSkillPoco>
    {
       
        public void Add(params ApplicantSkillPoco[] items)
        {
          using  SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (ApplicantSkillPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Skills]
                                   ([Id]
                                   ,[Applicant]
                                   ,[Skill]
                                   ,[Skill_Level]
                                   ,[Start_Month]
                                   ,[Start_Year]
                                   ,[End_Month]
                                   ,[End_Year])
                             VALUES
                                   (@Id,
                                    @Applicant,
                                    @Skill,
                                    @SkillLevel,
                                    @StartMonth,
                                    @StartYear,
                                    @EndMonth,
                                    @EndYear)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Skill", item.Skill);
                cmd.Parameters.AddWithValue("@SkillLevel", item.SkillLevel);
                cmd.Parameters.AddWithValue("@StartMonth", item.StartMonth);
                cmd.Parameters.AddWithValue("@StartYear", item.StartYear);
                cmd.Parameters.AddWithValue("@EndMonth", item.EndMonth);
                cmd.Parameters.AddWithValue("@EndYear", item.EndYear);
                conn.Open();
                int rowEffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT *
                                  
                              FROM [dbo].[Applicant_Skills]";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                  int counter = 0;
                ApplicantSkillPoco[] Pocos = new ApplicantSkillPoco[1000];
                while (rdr.Read())
                {
                    ApplicantSkillPoco Poco = new ApplicantSkillPoco();
                    Poco.Id = rdr.GetGuid(0);
                    Poco.Applicant = rdr.GetGuid(1);
                    Poco.Skill = rdr.GetString(2);
                    Poco.SkillLevel = rdr.GetString(3);
                    Poco.StartMonth = (byte)rdr[4];
                    Poco.StartYear = rdr.GetInt32(5);
                    Poco.EndMonth = (byte)rdr[6];
                    Poco.EndYear = rdr.GetInt32(7);
                    Poco.TimeStamp = (byte[])rdr[8];
                    Pocos[counter] = Poco;
                    counter++;

                }
                conn.Close();
                return Pocos.Where(p => p != null).ToList();
            }
        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantSkillPoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
               
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(ApplicantSkillPoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Skills]
                                       WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(ApplicantSkillPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Skills]
                                   SET [Id] = @Id
                                      ,[Applicant] = @Applicant
                                      ,[Skill] = @Skill
                                      ,[Skill_Level] = @SkillLevel
                                      ,[Start_Month] = @StartMonth
                                      ,[Start_Year] = @StartYear
                                      ,[End_Month] = @EndMonth
                                      ,[End_Year] = @EndYear
                                 WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("Skill", item.Skill);
                    cmd.Parameters.AddWithValue("SkillLevel", item.SkillLevel);
                    cmd.Parameters.AddWithValue("StartMonth", item.StartMonth);
                    cmd.Parameters.AddWithValue("StartYear", item.StartYear);
                    cmd.Parameters.AddWithValue("EndMonth", item.EndMonth);
                    cmd.Parameters.AddWithValue("EndYear", item.EndYear);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
