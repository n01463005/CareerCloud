using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantJobApplicationRepository : BaseAdo, IDataRepository<ApplicantJobApplicationPoco>
    {
        
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
           using SqlConnection conn = new SqlConnection(_connStr);
            { 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

                foreach (ApplicantJobApplicationPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Job_Applications]
                                       ([Id]
                                       ,[Applicant]
                                       ,[Job]
                                       ,[Application_Date])
                                 VALUES
                                       (@Id,
                                        @Applicant,
                                        @Job,
                                        @ApplicationDate)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@ApplicationDate", item.ApplicationDate);
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

        public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT*
                              FROM [dbo].[Applicant_Job_Applications]
                            ";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int counter = 0;
                ApplicantJobApplicationPoco[] Pocos = new ApplicantJobApplicationPoco[10000];
                while (rdr.Read())
                {
                    ApplicantJobApplicationPoco Poco = new ApplicantJobApplicationPoco();
                    Poco.Id = rdr.GetGuid(0);
                    Poco.Applicant = rdr.GetGuid(1);
                    Poco.Job = rdr.GetGuid(2);
                    Poco.ApplicationDate = (DateTime)rdr[3];
                    Poco.TimeStamp = (byte[])rdr[4];
                    Pocos [counter] = Poco;
                    counter++;

                }
                conn.Close();
                return Pocos.Where(P => P != null).ToList();
            }
        }

        public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantJobApplicationPoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
           using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach (ApplicantJobApplicationPoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Job_Applications]
                                      WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
           using  SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach (ApplicantJobApplicationPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Job_Applications]
                                       SET [Id] = @Id,
                                           [Applicant] = @Applicant,
                                           [Job] = @Job,
                                           [Application_Date] = @ApplicationDate
                                     WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@ApplicationDate", item.ApplicationDate);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
