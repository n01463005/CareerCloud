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
   public class CompanyProfileRepository : BaseAdo, IDataRepository<CompanyProfilePoco>
    {
        public void Add(params CompanyProfilePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(CompanyProfilePoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Profiles]
                                       ([Id]
                                       ,[Registration_Date]
                                       ,[Company_Website]
                                       ,[Contact_Phone]
                                       ,[Contact_Name]
                                       ,[Company_Logo])
                                 VALUES
                                       (@Id
                                       ,@RegistrationDate
                                       ,@CompanyWebsite
                                       ,@ContactPhone
                                       ,@ContactName
                                       ,@CompanyLogo)";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("RegistrationDate", item.RegistrationDate);
                    cmd.Parameters.AddWithValue("CompanyWebsite", item.CompanyWebsite);
                    cmd.Parameters.AddWithValue("ContactPhone", item.ContactPhone);
                    cmd.Parameters.AddWithValue("ContactName", item.ContactName);
                    cmd.Parameters.AddWithValue("CompanyLogo", item.CompanyLogo);

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

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = @"SELECT [Id]
                                  ,[Registration_Date]
                                  ,[Company_Website]
                                  ,[Contact_Phone]
                                  ,[Contact_Name]
                                  ,[Company_Logo]
                                  ,[Time_Stamp]
                              FROM [dbo].[Company_Profiles]";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int counter = 0;
                CompanyProfilePoco[] Pocos = new CompanyProfilePoco[1000];
                while (rdr.Read())
                {
                    CompanyProfilePoco Poco = new CompanyProfilePoco();
                    Poco.Id = rdr.GetGuid(0);
                    Poco.RegistrationDate = (DateTime)rdr[1];
                    Poco.CompanyWebsite = rdr.IsDBNull(2) ? (string)null : rdr.GetString(2);
                    Poco.ContactPhone = rdr.GetString(3);
                    Poco.ContactName = rdr.IsDBNull(4) ? (string)null : rdr.GetString(4);
                    Poco.CompanyLogo = rdr.IsDBNull(5) ? null : (byte[])rdr[5];
                   // Encoding.ASCII.GetBytes(rdr["Company_Logo"].ToString());
                    Poco.TimeStamp = (byte[])rdr[6];
                    Pocos[counter] = Poco;
                    counter++;
                }
                conn.Close();
                return Pocos.Where(P => P != null).ToList();
            }
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(CompanyProfilePoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Company_Profiles]
                                       WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(CompanyProfilePoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Profiles]
                                   SET [Id] = @Id
                                      ,[Registration_Date] = @RegistrationDate
                                      ,[Company_Website] = @CompanyWebsite
                                      ,[Contact_Phone] = @ContactPhone
                                      ,[Contact_Name] = @ContactName
                                      ,[Company_Logo] = @CompanyLogo
                                 WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("RegistrationDate", item.RegistrationDate);
                    cmd.Parameters.AddWithValue("CompanyWebsite", item.CompanyWebsite);
                    cmd.Parameters.AddWithValue("ContactPhone", item.ContactPhone);
                    cmd.Parameters.AddWithValue("ContactName", item.ContactName);
                    cmd.Parameters.AddWithValue("CompanyLogo", item.CompanyLogo);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
