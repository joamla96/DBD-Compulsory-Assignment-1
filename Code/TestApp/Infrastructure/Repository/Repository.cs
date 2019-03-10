using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Infrastructure.Repository
{
    public class Repository : IRepository
    {
        private string _connectionString;
        public Repository()
        {
            _connectionString = new Database().GetConnectionString();
        }

        public Depatment Create(Depatment obj)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_CreateDepartment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DName", SqlDbType.VarChar).Value = obj.Name;
                    cmd.Parameters.Add("@MgrSSN", SqlDbType.VarChar).Value = obj.MgrSSN;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return null;
        }

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_DeleteDepartment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNumber", SqlDbType.VarChar).Value = id;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Depatment Get(int id)
        {
            Depatment temp = null;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetDepartment", con))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNumber", SqlDbType.VarChar).Value = id;

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        temp = (new Depatment()
                        {
                            Name = String.Format("{0}", reader["DName"]),
                            Id = int.Parse(String.Format("{0}", reader["DNumber"])),
                            MgrSSN = int.Parse(String.Format("{0}", reader["MgrSSN"]))
                        });
                    }
                }
            }
            return temp;
        }

        public List<Depatment> Get()
        {
            var temp = new List<Depatment>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllDepartments ", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        temp.Add(new Depatment()
                        {
                            Name = String.Format("{0}", reader["DName"]),
                            Id = int.Parse(String.Format("{0}", reader["DNumber"])),
                            MgrSSN = int.Parse(String.Format("{0}", reader["MgrSSN"]))
                        });
                    }

                }
            }
            return temp;
        }

        public Depatment UpdateManager(Depatment obj)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UpdateDepartmentManager", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DName", SqlDbType.VarChar).Value = obj.Name;
                    cmd.Parameters.Add("@MgrSSN", SqlDbType.VarChar).Value = obj.MgrSSN;

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader["id"]));
                    }
                }
            }
            return null;
        }

        public Depatment UpdateName(Depatment obj)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UpdateDepartmentName", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DName", SqlDbType.VarChar).Value = obj.Name;
                    cmd.Parameters.Add("@DNumber", SqlDbType.VarChar).Value = obj.Id;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return null;
        }
    }
}
