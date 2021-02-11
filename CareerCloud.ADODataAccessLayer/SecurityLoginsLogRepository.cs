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
   public class SecurityLoginsLogRepository : BaseAdo, IDataRepository<SecurityLoginsLogPoco>
    {
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(SecurityLoginsLogPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins_Log]
                                       ([Id]
                                       ,[Login]
                                       ,[Source_IP]
                                       ,[Logon_Date]
                                       ,[Is_Succesful])
                                 VALUES
                                       (@Id
                                       ,@Login
                                       ,@SourceIP
                                       ,@LogonDate
                                       ,@IsSuccesful)";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Login", item.Login);
                    cmd.Parameters.AddWithValue("SourceIP", item.SourceIP);
                    cmd.Parameters.AddWithValue("LogonDate", item.LogonDate);
                    cmd.Parameters.AddWithValue("IsSuccesful", item.IsSuccesful);
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

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT *
                                  
                              FROM [dbo].[Security_Logins_Log]";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int counter = 0;
                SecurityLoginsLogPoco[] Pocos = new SecurityLoginsLogPoco[10000];
                while(rdr.Read())
                {
                    SecurityLoginsLogPoco Poco = new SecurityLoginsLogPoco();
                    Poco.Id = rdr.GetGuid(0);
                    Poco.Login = rdr.GetGuid(1);
                    Poco.SourceIP = rdr.GetString(2);
                    Poco.LogonDate = (DateTime)rdr[3];
                    Poco.IsSuccesful = rdr.GetBoolean(4);

                    Pocos[counter] = Poco;
                    counter++;

                }
                conn.Close();
                return Pocos.Where(p => p != null).ToList();
            }
        }

        public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsLogPoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(SecurityLoginsLogPoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Security_Logins_Log]
                                        WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(SecurityLoginsLogPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Security_Logins_Log]
                                       SET [Id] = @Id
                                          ,[Login] = @Login
                                          ,[Source_IP] = @SourceIP
                                          ,[Logon_Date] = @LogonDate
                                          ,[Is_Succesful] = @IsSuccesful
                                     WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Login", item.Login);
                    cmd.Parameters.AddWithValue("SourceIP", item.SourceIP);
                    cmd.Parameters.AddWithValue("LogonDate", item.LogonDate);
                    cmd.Parameters.AddWithValue("IsSuccesful", item.IsSuccesful);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
