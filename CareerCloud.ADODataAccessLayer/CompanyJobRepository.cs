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
  public  class CompanyJobRepository : BaseAdo, IDataRepository<CompanyJobPoco>
    {
        public void Add(params CompanyJobPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(CompanyJobPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Jobs]
                                       ([Id]
                                       ,[Company]
                                       ,[Profile_Created]
                                       ,[Is_Inactive]
                                       ,[Is_Company_Hidden])
                                 VALUES
                                       (@Id
                                       ,@Company
                                       ,@ProfileCreated
                                       ,@IsInactive
                                       ,@IsCompanyHidden)";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Company", item.Company);
                    cmd.Parameters.AddWithValue("ProfileCreated", item.ProfileCreated);
                    cmd.Parameters.AddWithValue("IsInactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("IsCompanyHidden", item.IsCompanyHidden);
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

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = @"SELECT *
                                  
                              FROM [dbo].[Company_Jobs]";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int counter = 0;
                CompanyJobPoco[] Pocos = new CompanyJobPoco[10000];
                while (rdr.Read()) 
                {
                    CompanyJobPoco Poco = new CompanyJobPoco();
                    Poco.Id = rdr.GetGuid(0);
                    Poco.Company = rdr.GetGuid(1);
                    Poco.ProfileCreated = (DateTime)rdr[2];
                    Poco.IsInactive = (bool)rdr[3];
                    Poco.IsCompanyHidden = (bool)rdr[4];
                    Poco.TimeStamp = (byte[])rdr[5];
                    Pocos[counter] = Poco;
                    counter++;

                }
                conn.Close();
                return Pocos.Where(P => P != null).ToList(); 

            }
        }

        public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobPoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                 foreach(CompanyJobPoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Company_Jobs]
                                      WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params CompanyJobPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                 
                foreach(CompanyJobPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Jobs]
                                   SET [Id] = @Id
                                      ,[Company] = @Company
                                      ,[Profile_Created] = @ProfileCreated
                                      ,[Is_Inactive] = @IsInactive
                                      ,[Is_Company_Hidden] = @IsCompanyHidden
                                 WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Company", item.Company);
                    cmd.Parameters.AddWithValue("ProfileCreated", item.ProfileCreated);
                    cmd.Parameters.AddWithValue("IsInactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("IsCompanyHidden", item.IsCompanyHidden);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
