using Entites;
using INoteBookDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB
{
    public class NoteDaoDB : INoteBookDao
    {
        private string connectionString = "Data Source=DESKTOP-60HJP9E;Initial Catalog=NoteBook;Integrated Security=True";

        public int Add(Note value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddNote", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", value.FirstName);
                cmd.Parameters.AddWithValue("@LastName", value.LastName);
                cmd.Parameters.AddWithValue("@YearOfBirth", value.YearOfBirth);
                cmd.Parameters.AddWithValue("@PhoneNumber", value.PhoneNumber);
                var id = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Output,
                    ParameterName = "@Id",
                    DbType = System.Data.DbType.Int32
                };
                cmd.Parameters.Add(id);

                connection.Open();

                cmd.ExecuteNonQuery();

                return (int)id.Value;
            }
        }

        public void Edit(Note value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditNote", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", value.Id);
                cmd.Parameters.AddWithValue("@FirstName", value.FirstName);
                cmd.Parameters.AddWithValue("@LastName", value.LastName);
                cmd.Parameters.AddWithValue("@YearOfBirth", value.YearOfBirth);
                cmd.Parameters.AddWithValue("@PhoneNumber", value.PhoneNumber);

                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Note> GetAll()
        {
            var result = new List<Note>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("GetAllNotes", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var note = new Note
                    {
                        Id = (int?)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        YearOfBirth = (int)reader["YearOfBirth"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                    };

                    result.Add(note);
                }
            }

            return result;
        }

        public Note GetById(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("GetById", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var note = new Note
                    {
                        Id = (int?)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        YearOfBirth = (int)reader["YearOfBirth"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                    };
                    return note;
                }

            }
            return null;
        }

        public void Remove(int index)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("RemoveNote", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", index);

                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Note> SearchByLastName(string LastName)
        {
            var result = new List<Note>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllByLastName", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LastName", LastName);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var note = new Note
                    {
                        Id = (int?)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        YearOfBirth = (int)reader["YearOfBirth"],
                        PhoneNumber = (string)reader["PhoneNumber"],

                    };

                    result.Add(note);
                }
            }

            return result;
        }

        public IEnumerable<Note> SearchByName(string Name)
        {
            var result = new List<Note>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllByName", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", Name);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var note = new Note
                    {
                        Id = (int?)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        YearOfBirth = (int)reader["YearOfBirth"],
                        PhoneNumber = (string)reader["PhoneNumber"],

                    };

                    result.Add(note);
                }
            }

            return result;
        }

        public IEnumerable<Note> SearchByPhoneNum(string PhoneNum)
        {
            var result = new List<Note>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllByPhone", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PhoneNum", PhoneNum);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var note = new Note
                    {
                        Id = (int?)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        YearOfBirth = (int)reader["YearOfBirth"],
                        PhoneNumber = (string)reader["PhoneNumber"],

                    };

                    result.Add(note);
                }
            }

            return result;
        }

        public IEnumerable<Note> SortByLastName()
        {
            var result = new List<Note>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SortByLastName", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var note = new Note
                    {
                        Id = (int?)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        YearOfBirth = (int)reader["YearOfBirth"],
                        PhoneNumber = (string)reader["PhoneNumber"],

                    };
                    result.Add(note);
                }
            }
            return result;
        }

        public IEnumerable<Note> SortByYear()
        {
            var result = new List<Note>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SortByYear", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var note = new Note
                    {
                        Id = (int?)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        YearOfBirth = (int)reader["YearOfBirth"],
                        PhoneNumber = (string)reader["PhoneNumber"],

                    };
                    result.Add(note);
                }
            }
            return result;
        }

    }
}
