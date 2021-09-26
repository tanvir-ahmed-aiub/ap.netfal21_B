using Lecture_3.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lecture_3.Models
{
    public class Database
    {
        SqlConnection conn;
        public Courses Courses { get; set; }
        public Students Students { get; set; }
        public Departments Departments { get; set; }
        public Database() {
            string connString = @"Server=DESKTOP-NM0ID5F\SQLEXPRESS; Database=UMS; Integrated Security=true";
            conn = new SqlConnection(connString);
            Courses = new Courses(conn);
            Students = new Students(conn);
            Departments = new Departments();

        }
    }
}