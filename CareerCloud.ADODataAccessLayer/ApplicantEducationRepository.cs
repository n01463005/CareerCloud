using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
   public class ApplicantEducationRepository : BaseAdo, IDataRepository<ApplicantEducationPoco>
    {
        
        public void Add(params ApplicantEducationPoco[] items)
        {
          using  SqlConnection conn = new SqlConnection(_connStr);
            { 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

                foreach (ApplicantEducationPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Educations]
                                   ([Id]
                                   ,[Applicant]
                                   ,[Major]
                                   ,[Certificate_Diploma]
                                   ,[Start_Date]
                                   ,[Completion_Date]
                                   ,[Completion_Percent])
                             VALUES
                                   (@Id,
                                    @Applicant,
                                    @Major,
                                    @CertificateDiploma,
                                    @StartDate,
                                    @CompletionDate,
                                    @CompletionPercent)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@CertificateDiploma", item.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@StartDate", item.StartDate);
                    cmd.Parameters.AddWithValue("@CompletionDate", item.CompletionDate);
                    cmd.Parameters.AddWithValue("@CompletionPercent", item.CompletionPercent);
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

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
               
                
                    cmd.CommandText = @"SELECT *
                                     
                                  FROM [dbo].[Applicant_Educations]";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int counter = 0;
                ApplicantEducationPoco[] Pocos = new ApplicantEducationPoco[1000];
                while(rdr.Read())
                  {
                    ApplicantEducationPoco Poco = new ApplicantEducationPoco();
                    Poco.Id = rdr.GetGuid(0);
                    Poco.Applicant = rdr.GetGuid(1);
                    Poco.Major = rdr.GetString(2);
                    Poco.CertificateDiploma = rdr.GetString(3);
                    Poco.StartDate = rdr.IsDBNull(4) ? (DateTime?) null : rdr.GetDateTime(4);
                    Poco.CompletionDate = (DateTime?)rdr[5];
                    Poco.CompletionPercent = (byte?)rdr[6];
                    Poco.TimeStamp = (byte[])rdr[7];
                    Pocos[counter] = Poco;
                    counter++;
                  }
                conn.Close();
                return Pocos.Where(P => P != null).ToList();
            }
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
         using    SqlConnection conn = new SqlConnection(_connStr);
            { 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

                foreach (ApplicantEducationPoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM[dbo].[Applicant_Educations]
                WHERE [Id] = @Id ";

                    cmd.Parameters.AddWithValue("Id", item.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {

            using SqlConnection conn = new SqlConnection(_connStr) ;
            { 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

                foreach (ApplicantEducationPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Educations]
                                   SET 
                                      [Applicant] = @Applicant, 
                                      [Major] = @Major, 
                                      [Certificate_Diploma] = @CertificateDiploma,
                                      [Start_Date] = @StartDate,
                                      [Completion_Date] = @CompletionDate,
                                      [Completion_Percent] = @CompletionPercent
                                 WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@CertificateDiploma", item.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@StartDate", item.StartDate);
                    cmd.Parameters.AddWithValue("@CompletionDate", item.CompletionDate);
                    cmd.Parameters.AddWithValue("@CompletionPercent", item.CompletionPercent);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }

            }
        }
    }
}
