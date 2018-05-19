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
        //connectionString change Data Source = your computer name/server
        private string connectionString = "Data Source=DESKTOP-60HJP9E;Initial Catalog=NoteBook;Integrated Security=True";

        public int Add(Note value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //StoredProcedure, which add note
                SqlCommand cmd = new SqlCommand("AddNote", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", value.FirstName);
                cmd.Parameters.AddWithValue("@LastName", value.LastName);
                cmd.Parameters.AddWithValue("@YearOfBirth", value.YearOfBirth);
                cmd.Parameters.AddWithValue("@PhoneNumber", value.PhoneNumber);
                var id = new SqlParameter
                {//getting number of the id from ms sql autoincrement
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
                //StoredProcedure, which edit note
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
            //StoredProcedure, which get all the notes
            var result = new List<Note>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("GetAllNotes", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                //read from the db parameters, generate new note and add it to the result
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
                // Seek the note by id, if it wasn't found return null
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
                // Remove note by index
                SqlCommand cmd = new SqlCommand("RemoveNote", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", index);

                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Note> SearchByLastName(string LastName)
        {
            // the same like getall, but procedure SearchByLastName
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
            // the same like getall, but procedure SearchByName
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
            // the same like getall, but procedure SearchByPhoneNum
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
            // SortByLastName notes by the procedure  
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
            // SortByYear notes by the procedure 
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
