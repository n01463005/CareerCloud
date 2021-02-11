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
  public class SystemLanguageCodeRepository : BaseAdo, IDataRepository<SystemLanguageCodePoco>
    {
        public void Add(params SystemLanguageCodePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(SystemLanguageCodePoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[System_Language_Codes]
                                           ([LanguageID]
                                           ,[Name]
                                           ,[Native_Name])
                                     VALUES
                                           (@LanguageID
                                           ,@Name
                                           ,@NativeName)";
                    cmd.Parameters.AddWithValue("LanguageID", item.LanguageID);
                    cmd.Parameters.AddWithValue("Name", item.Name);
                    cmd.Parameters.AddWithValue("NativeName", item.NativeName);

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

        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT *
                                      
                                  FROM [dbo].[System_Language_Codes]";
                                    
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int counter = 0;
                SystemLanguageCodePoco[] Pocos = new SystemLanguageCodePoco[1000];
                while (rdr.Read())
                {
                    SystemLanguageCodePoco Poco = new SystemLanguageCodePoco();
                    Poco.LanguageID = rdr.GetString(0);
                    Poco.Name = rdr.GetString(1);
                    Poco.NativeName = rdr.GetString(2);

                    Pocos[counter] = Poco;
                    counter++;
                    
               }

                conn.Close();
                return Pocos.Where(p => p != null).ToList();

            }
        }

        public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemLanguageCodePoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {

            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SystemLanguageCodePoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[System_Language_Codes]
                                        WHERE [LanguageID] = @LanguageID";
                    cmd.Parameters.AddWithValue("LanguageID", item.LanguageID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(SystemLanguageCodePoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[System_Language_Codes]
                                       SET [LanguageID] = @LanguageID
                                          ,[Name] = @Name
                                          ,[Native_Name] = @NativeName
                                     WHERE [LanguageId] = @LanguageId";

                    cmd.Parameters.AddWithValue("LanguageID", item.LanguageID);
                    cmd.Parameters.AddWithValue("Name", item.Name);
                    cmd.Parameters.AddWithValue("NativeName", item.NativeName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
