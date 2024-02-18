using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DALayer
{
    public class Student
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Image { get; set; }

        public Student(string name, string email, string password, string mobile, string image)
        {
            this.Name = name;
            this.EmailId = email;
            this.Password = password;
            this.Mobile = mobile;
            this.Image = image;
        }
        public Student() { }

        private readonly string connString = ConfigurationManager.ConnectionStrings["dbRahulConn"].ConnectionString.ToString();

        #region Get Student List
        public DataTable StudentLst()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("CRUD_Student", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@query", 1);

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                ErrorLogger.WriteLog("StudentLst() executed successfully");
                return dt;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog("Error : " + ex.Message);
                throw ex;
            }
        }
        #endregion


        #region Get Student by Id
        public DataTable GetStudentDatabyId(int id)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("CRUD_Student", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@query", 4);

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                ErrorLogger.WriteLog("GetStudentDatabyId() executed successfully");
                return dt;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog("Error : " + ex.Message);
                throw ex;
            }
        }
        #endregion

        #region Delete Student By Id
        public string DeleteStudent(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("CRUD_Student", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@query", 2);

                string response = cmd.ExecuteNonQuery().ToString();
                ErrorLogger.WriteLog("DeleteStudent() executed successfully");
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog("Error : " + ex.Message);
                return ex.Message;
            }
        }
        #endregion

        #region Register Student
        public string RegisterStudent(Student student)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("CRUD_Student", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@emailId", student.EmailId);
                cmd.Parameters.AddWithValue("@password", student.Password);
                cmd.Parameters.AddWithValue("@mobile", student.Mobile);
                cmd.Parameters.AddWithValue("@image", student.Image);
                cmd.Parameters.AddWithValue("@query", 3);

                string response = cmd.ExecuteNonQuery().ToString();
                ErrorLogger.WriteLog("RegisterStudent() executed successfully");
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog("Error : " + ex.Message);
                return ex.Message;
            }
        }
        #endregion

        #region Edit Student
        public string EditStudent(Student student)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("CRUD_Student", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", student.Id);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@password", student.Password);
                cmd.Parameters.AddWithValue("@mobile", student.Mobile);
                cmd.Parameters.AddWithValue("@image", student.Image);
                cmd.Parameters.AddWithValue("@query", 5);

                string response = cmd.ExecuteNonQuery().ToString();
                ErrorLogger.WriteLog("EditStudent() executed successfully");
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog("Error : " + ex.Message);
                return ex.Message;
            }
        }
        #endregion
    }
}