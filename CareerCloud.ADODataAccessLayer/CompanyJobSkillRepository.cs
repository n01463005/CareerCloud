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
  public  class CompanyJobSkillRepository : BaseAdo, IDataRepository<CompanyJobSkillPoco>
    {
        public void Add(params CompanyJobSkillPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(CompanyJobSkillPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Job_Skills]
                                       ([Id]
                                       ,[Job]
                                       ,[Skill]
                                       ,[Skill_Level]
                                       ,[Importance])
                                 VALUES
                                       (@Id
                                       ,@Job
                                       ,@Skill
                                       ,@SkillLevel
                                       ,@Importance)";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Job", item.Job);
                    cmd.Parameters.AddWithValue("Skill", item.Skill);
                    cmd.Parameters.AddWithValue("SkillLevel", item.SkillLevel);
                    cmd.Parameters.AddWithValue("Importance", item.Importance);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                        cmd.CommandText = @"SELECT *
                                          
                                      FROM [dbo].[Company_Job_Skills]";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int counter = 0;
                CompanyJobSkillPoco[] Pocos = new CompanyJobSkillPoco[10000];
                while(rdr.Read())
                {
                    CompanyJobSkillPoco Poco = new CompanyJobSkillPoco();
                    Poco.Id = rdr.GetGuid(0);
                    Poco.Job = rdr.GetGuid(1);
                    Poco.Skill = rdr.GetString(2);
                    Poco.SkillLevel = rdr.GetString(3);
                    Poco.Importance = rdr.GetInt32(4);
                    Poco.TimeStamp = (byte[])rdr[5];

                    Pocos[counter] = Poco;
                    counter++;
                }
                conn.Close();
                return Pocos.Where(P => P != null).ToList();
            }
        }

        public IList<CompanyJobSkillPoco> GetList(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobSkillPoco GetSingle(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobSkillPoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobSkillPoco[] items)
        {

            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(CompanyJobSkillPoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Company_Job_Skills]
                                       WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params CompanyJobSkillPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(CompanyJobSkillPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Job_Skills]
                                       SET [Id] = @Id
                                          ,[Job] = @Job
                                          ,[Skill] = @Skill
                                          ,[Skill_Level] = @SkillLevel
                                          ,[Importance] = @Importance
                                     WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Job", item.Job);
                    cmd.Parameters.AddWithValue("Skill", item.Skill);
                    cmd.Parameters.AddWithValue("SkillLevel", item.SkillLevel);
                    cmd.Parameters.AddWithValue("Importance", item.Importance);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
    }
}
