using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lecture_3.Models.Tables
{
    public class Courses
    {
        SqlConnection conn;
        public Courses(SqlConnection conn) {
            this.conn = conn;
        }
    }
}