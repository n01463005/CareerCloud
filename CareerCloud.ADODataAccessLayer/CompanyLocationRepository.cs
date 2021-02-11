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
   public class CompanyLocationRepository : BaseAdo, IDataRepository<CompanyLocationPoco>
    {
        public void Add(params CompanyLocationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(CompanyLocationPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Locations]
                                       ([Id]
                                       ,[Company]
                                       ,[Country_Code]
                                       ,[State_Province_Code]
                                       ,[Street_Address]
                                       ,[City_Town]
                                       ,[Zip_Postal_Code])
                                 VALUES
                                       (@Id
                                       ,@Company
                                       ,@CountryCode
                                       ,@StateProvinceCode
                                       ,@StreetAddress
                                       ,@CityTown
                                       ,@ZipPostalCode)";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Company", item.Company);
                    cmd.Parameters.AddWithValue("CountryCode", item.CountryCode);
                    cmd.Parameters.AddWithValue("StateProvinceCode", item.Province);
                    cmd.Parameters.AddWithValue("StreetAddress", item.Street);
                    cmd.Parameters.AddWithValue("CityTown", item.City);
                    cmd.Parameters.AddWithValue("ZipPostalCode", item.PostalCode);
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

        public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT *
                                  
                              FROM [dbo].[Company_Locations]
                            ";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int counter = 0;
                CompanyLocationPoco[] Pocos = new CompanyLocationPoco[1000];
                while(rdr.Read())
                {
                    CompanyLocationPoco Poco = new CompanyLocationPoco();
                    Poco.Id = rdr.GetGuid(0);
                    Poco.Company = rdr.GetGuid(1);
                    Poco.CountryCode = rdr.GetString(2);
                    Poco.Province = rdr.GetString(3);
                    Poco.Street = rdr.GetString(4);
                    Poco.City = rdr.IsDBNull(5) ? (string)null : rdr.GetString(5);
                    Poco.PostalCode = rdr.IsDBNull(6) ? (string)null : rdr.GetString(6);
                    Poco.TimeStamp = (byte[])rdr[7];

                    Pocos[counter] = Poco;
                    counter++;
                }
                conn.Close();
                return Pocos.Where(P => P != null).ToList();
            }

        }

        public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyLocationPoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyLocationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(CompanyLocationPoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Company_Locations]
                                       WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params CompanyLocationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(CompanyLocationPoco item in items)
                  {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Locations]
                                   SET [Id] = @Id
                                      ,[Company] = @Company
                                      ,[Country_Code] = @CountryCode
                                      ,[State_Province_Code] = @StateProvinceCode
                                      ,[Street_Address] = @StreetAddress
                                      ,[City_Town] = @CityTown
                                      ,[Zip_Postal_Code] = @ZipPostalCode
                                 WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Company", item.Company);
                    cmd.Parameters.AddWithValue("CountryCode", item.CountryCode);
                    cmd.Parameters.AddWithValue("StateProvinceCode", item.Province);
                    cmd.Parameters.AddWithValue("StreetAddress", item.Street);
                    cmd.Parameters.AddWithValue("CityTown", item.City);
                    cmd.Parameters.AddWithValue("ZipPostalCode", item.PostalCode);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }
    }
}
