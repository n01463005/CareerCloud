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
   public class CompanyJobEducationRepository : BaseAdo, IDataRepository<CompanyJobEducationPoco>
    {
     

        public void Add(params CompanyJobEducationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach (CompanyJobEducationPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Job_Educations]
                                       ([Id]
                                       ,[Job]
                                       ,[Major]
                                       ,[Importance])
                                 VALUES
                                       (@Id
                                       ,@Job
                                       ,@Major
                                       ,@Importance)";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Job", item.Job);
                    cmd.Parameters.AddWithValue("Major", item.Major);
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

       

        public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                  ,[Job]
                                  ,[Major]
                                  ,[Importance]
                                  ,[Time_Stamp]
                              FROM [dbo].[Company_Job_Educations]";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int counter = 0;
                CompanyJobEducationPoco[] Pocos = new CompanyJobEducationPoco[10000];
                while(rdr.Read())
                {
                    CompanyJobEducationPoco Poco = new CompanyJobEducationPoco();
                    Poco.Id = rdr.GetGuid(0);
                    Poco.Job = rdr.GetGuid(1);
                    Poco.Major = rdr.GetString(2);
                    Poco.Importance = rdr.GetInt16(3);
                    Poco.TimeStamp = (byte[])rdr[4];
                    Pocos[counter] = Poco;
                    counter++;
                }
                conn.Close();
                return Pocos.Where(P => P != null).ToList();

            }
        }

       

        public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

      

        public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobEducationPoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

       

        public void Remove(params CompanyJobEducationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(CompanyJobEducationPoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Company_Job_Educations]
                                       WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

      
        public void Update(params CompanyJobEducationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(CompanyJobEducationPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Job_Educations]
                                   SET [Id] = @Id
                                      ,[Job] = @Job
                                      ,[Major] = @Major
                                      ,[Importance] = @Importance
                                 WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Job", item.Job);
                    cmd.Parameters.AddWithValue("Major", item.Major);
                    ;
                    cmd.Parameters.AddWithValue("Importance", item.Importance);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
