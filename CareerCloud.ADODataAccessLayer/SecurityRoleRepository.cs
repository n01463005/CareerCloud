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
   public class SecurityRoleRepository : BaseAdo, IDataRepository<SecurityRolePoco>
    {
        public void Add(params SecurityRolePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(SecurityRolePoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Roles]
                                       ([Id]
                                       ,[Role]
                                       ,[Is_Inactive])
                                 VALUES
                                       (@Id
                                       ,@Role
                                       ,@IsInactive)";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Role", item.Role);
                    cmd.Parameters.AddWithValue("IsInactive", item.IsInactive);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityRolePoco> GetAll(params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            
            
             using SqlConnection conn = new SqlConnection(_connStr);
              {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                  ,[Role]
                                  ,[Is_Inactive]
                              FROM [dbo].[Security_Roles]";
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int counter = 0;
                SecurityRolePoco[] Pocos = new SecurityRolePoco[1000];
                while (rdr.Read())
                {
                    SecurityRolePoco Poco = new SecurityRolePoco();
                    Poco.Id = rdr.GetGuid(0);
                    Poco.Role = rdr.GetString(1);
                    Poco.IsInactive = rdr.GetBoolean(2);
                    Pocos[counter] = Poco;
                    counter++;
                }
                conn.Close();
                return Pocos.Where(P => P != null).ToList();

               

              }
        }
        public IList<SecurityRolePoco> GetList(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityRolePoco GetSingle(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityRolePoco> Pocos = GetAll().AsQueryable();
            return Pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityRolePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityRolePoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Security_Roles]
                                       WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    
                }

            }
        }

        public void Update(params SecurityRolePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityRolePoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Security_Roles]
                                       SET [Id] = @Id
                                          ,[Role] = @Role
                                          ,[Is_Inactive] = @IsInactive
                                     WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("Id", item.Id);
                    cmd.Parameters.AddWithValue("Role", item.Role);
                    cmd.Parameters.AddWithValue("IsInactive", item.IsInactive);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

              }
        }
    }
}
