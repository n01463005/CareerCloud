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
    public class ApplicantResumeRepository : BaseAdo, IDataRepository<ApplicantResumePoco>
    {
       
        
        public void Add(params ApplicantResumePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (ApplicantResumePoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Resumes]
                                       ([Id]
                                       ,[Applicant]
                                       ,[Resume]
                                       ,[Last_Updated])
                                 VALUES
                                       (@Id,
                                       @Applicant,
                                       @Resume,
                                       @LastUpdated)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Resume", item.Resume);
                cmd.Parameters.AddWithValue("@LastUpdated", item.LastUpdated);
                conn.Open();
                int rowEffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
                public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT *                                
                              FROM [dbo].[Applicant_Resumes]
                            ";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int counter = 0;
                ApplicantResumePoco[] Pocos = new ApplicantResumePoco[1000];
                while (rdr.Read())
                {
                    ApplicantResumePoco Poco = new ApplicantResumePoco();
                    Poco.Id = rdr.GetGuid(0);
                    Poco.Applicant = rdr.GetGuid(1);
                    Poco.Resume = rdr.GetString(2);
                    DateTime last;
                    DateTime.TryParse(rdr["Last_Updated"].ToString(), out last);
                    Poco.LastUpdated = last;
                    Pocos[counter] = Poco;
                    counter++;
 
                }

                conn.Close();
                return Pocos.Where(p => p != null).ToList();

            }
        }

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantResumePoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantResumePoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Resumes]
                                   WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantResumePoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Resumes]
                                   SET [Id] = @Id
                                      ,[Applicant] = @Applicant
                                      ,[Resume] = @Resume
                                      ,[Last_Updated] = @LastUpdated
                                 WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("Resume", item.Resume);
                    cmd.Parameters.AddWithValue("LastUpdated", item.LastUpdated);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
