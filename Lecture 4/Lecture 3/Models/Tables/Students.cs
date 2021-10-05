using Lecture_3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lecture_3.Models.Tables
{
    public class Students
    {
        SqlConnection conn;
        public Students(SqlConnection conn) {
            this.conn = conn;
        }
        public void Create(Student s) {
            
            conn.Open();
            string query = String.Format("insert into Students values ('{0}','{1}','{2}',0.0)", s.Name, s.Dob, s.Gender);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<Student> Get() {
            conn.Open();
            string query = "select * from Students";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student s = new Student()
                {

                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Dob = reader.GetString(reader.GetOrdinal("Dob")),
                    Cgpa = (float)reader.GetDouble(reader.GetOrdinal("Cgpa"))

                };
                students.Add(s);
            }

            conn.Close();
            return students;
        }
        public Student Get(int id) {
            conn.Open();
            string query = String.Format("Select * from Students where Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Student s = null;
            while (reader.Read()) {
                s = new Student()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Dob = reader.GetString(reader.GetOrdinal("Dob")),
                    Cgpa = (float)reader.GetDouble(reader.GetOrdinal("Cgpa"))
                };
            }
            conn.Close();
            return s;
        }
    }
}