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
   public class ApplicantProfileRepository : BaseAdo, IDataRepository<ApplicantProfilePoco>
    {
      
        public void Add(params ApplicantProfilePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (ApplicantProfilePoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Profiles]
                                   ([Id]
                                   ,[Login]
                                   ,[Current_Salary]
                                   ,[Current_Rate]
                                   ,[Currency]
                                   ,[Country_Code]
                                   ,[State_Province_Code]
                                   ,[Street_Address]
                                   ,[City_Town]
                                   ,[Zip_Postal_Code])
                             VALUES
                                   (@Id,
                                    @Login,
                                    @CurrentSalary,
                                    @CurrentRate,
                                    @Currency,
                                    @Country,
                                    @Province,
                                    @Street,
                                    @City,
                                    @PostalCode)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Login", item.Login);
                cmd.Parameters.AddWithValue("@CurrentSalary", item.CurrentSalary);
                cmd.Parameters.AddWithValue("@CurrentRate", item.CurrentRate);
                cmd.Parameters.AddWithValue("@Currency", item.Currency);
                cmd.Parameters.AddWithValue("@Country", item.Country);
                cmd.Parameters.AddWithValue("@Province", item.Province);
                cmd.Parameters.AddWithValue("@Street", item.Street);
                cmd.Parameters.AddWithValue("@City", item.City);
                cmd.Parameters.AddWithValue("@PostalCode", item.PostalCode);

                conn.Open();
                int rowEffected = cmd.ExecuteNonQuery();
                conn.Close();


            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT *
                                  FROM [dbo].[Applicant_Profiles]";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int counter = 0;
                ApplicantProfilePoco[] Pocos = new ApplicantProfilePoco[1000];
                while (rdr.Read())
                {
                    ApplicantProfilePoco Poco = new ApplicantProfilePoco();
                    Poco.Id = rdr.GetGuid(0);
                    Poco.Login = rdr.GetGuid(1);
                    Poco.CurrentSalary = (Decimal)rdr[2];
                    Poco.CurrentRate = rdr.IsDBNull(3) ? (Decimal?)null : rdr.GetDecimal(3);
                    Poco.Currency = rdr.GetString(4);
                    Poco.Country = rdr.GetString(5);
                    Poco.Province = rdr.GetString(6);
                    Poco.Street = rdr.GetString(7);
                    Poco.City = rdr.GetString(8);
                    Poco.PostalCode = rdr.GetString(9);
                    Poco.TimeStamp = (byte[])rdr[10];
                    Pocos[counter] = Poco;
                    counter++;
                }
                conn.Close();
                return Pocos.Where(P => P != null).ToList();
            }
        }

      

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {

            IQueryable<ApplicantProfilePoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (ApplicantProfilePoco item in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Profiles]
                                          WHERE [Id] = @Id";
                cmd.Parameters.AddWithValue("Id", item.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                                     
            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (ApplicantProfilePoco item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Profiles]
                                   SET [Id] = @Id
                                      ,[Login] = @Login
                                      ,[Current_Salary] = @CurrentSalary
                                      ,[Current_Rate] = @CurrentRate
                                      ,[Currency] = @Currency
                                      ,[Country_Code] = @CountryCode
                                      ,[State_Province_Code] = @StateProvinceCode
                                      ,[Street_Address] = @StreetAddress
                                      ,[City_Town] = @CityTown
                                      ,[Zip_Postal_Code] = @ZipPostalCode
                                 WHERE [Id] = @Id";
                cmd.Parameters.AddWithValue("Id", item.Id);
                cmd.Parameters.AddWithValue("Login", item.Login);
                cmd.Parameters.AddWithValue("CurrentSalary", item.CurrentSalary);
                cmd.Parameters.AddWithValue("CurrentRate", item.CurrentRate);
                cmd.Parameters.AddWithValue("Currency", item.Currency);
                cmd.Parameters.AddWithValue("CountryCode", item.Country);
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
