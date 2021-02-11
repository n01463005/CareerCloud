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
   public class ApplicantWorkHistoryRepository :BaseAdo, IDataRepository<ApplicantWorkHistoryPoco>
    {
        
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (ApplicantWorkHistoryPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Work_History]
           ([Id]
           ,[Applicant]
           ,[Company_Name]
           ,[Country_Code]
           ,[Location]
           ,[Job_Title]
           ,[Job_Description]
           ,[Start_Month]
           ,[Start_Year]
           ,[End_Month]
           ,[End_Year])
     VALUES
           (@Id,
            @Applicant,
            @CompanyName,
            @CountryCode,
            @Location,
            @JobTitle,
            @JobDescription,
            @StartMonth,
            @StartYear,
            @EndMonth,
            @EndYear)";

                cmd.Parameters.AddWithValue("@Id", item.Id); 
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@CompanyName", item.CompanyName);
                cmd.Parameters.AddWithValue("@CountryCode", item.CountryCode);
                cmd.Parameters.AddWithValue("@Location", item.Location);
                cmd.Parameters.AddWithValue("@JobTitle", item.JobTitle);
                cmd.Parameters.AddWithValue("@JobDescription", item.JobDescription);
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

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                  ,[Applicant]
                                  ,[Company_Name]
                                  ,[Country_Code]
                                  ,[Location]
                                  ,[Job_Title]
                                  ,[Job_Description]
                                  ,[Start_Month]
                                  ,[Start_Year]
                                  ,[End_Month]
                                  ,[End_Year]
                                  ,[Time_Stamp]
                              FROM [dbo].[Applicant_Work_History]";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int counter = 0;
                ApplicantWorkHistoryPoco[] Pocos = new ApplicantWorkHistoryPoco[1000];
                while(rdr.Read())
                {
                    ApplicantWorkHistoryPoco Poco = new ApplicantWorkHistoryPoco();
                    Poco.Id = rdr.GetGuid(0);
                    Poco.Applicant = rdr.GetGuid(1);
                    Poco.CompanyName = rdr.GetString(2);
                    Poco.CountryCode = rdr.GetString(3);
                    Poco.Location = rdr.GetString(4);
                    Poco.JobTitle = rdr.GetString(5);
                    Poco.JobDescription = rdr.GetString(6);
                    Poco.StartMonth = rdr.GetInt16(7);
                    Poco.StartYear = rdr.GetInt32(8);
                    Poco.EndMonth = rdr.GetInt16(9);
                    Poco.EndYear = rdr.GetInt32(10);
                    Poco.TimeStamp = (byte[])rdr[11];
                    Pocos[counter] = Poco;
                    counter++;

                }
                conn.Close();
                return Pocos.Where(P => P != null).ToList();

            }
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(ApplicantWorkHistoryPoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Work_History]
                                       WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantWorkHistoryPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Work_History]
                                   SET [Id] = @Id
                                      ,[Applicant] = @Applicant
                                      ,[Company_Name] = @CompanyName
                                      ,[Country_Code] = @CountryCode
                                      ,[Location] = @Location
                                      ,[Job_Title] = @JobTitle
                                      ,[Job_Description] = @JobDescription
                                      ,[Start_Month] = @StartMonth
                                      ,[Start_Year] = @StartYear
                                      ,[End_Month] = @EndMonth
                                      ,[End_Year] = @EndYear
                                 WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("CompanyName", item.CompanyName);
                    cmd.Parameters.AddWithValue("CountryCode", item.CountryCode);
                    cmd.Parameters.AddWithValue("Location", item.Location);
                    cmd.Parameters.AddWithValue("JobTitle", item.JobTitle);
                    cmd.Parameters.AddWithValue("JobDescription", item.JobDescription);
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
