using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using DALayer;

namespace BALayer
{
    public class StudentBAL
    {
        Student student = new Student();

        //Get Student List
        public DataTable StudentLst()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = student.StudentLst();
                return dt;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex.Message);
                throw;
            }
        }


        //Get Student Data by Id
        public DataTable GetStudentDatabyId( int id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = student.GetStudentDatabyId(id);
                return dt;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog("Error : " + ex.Message);
                throw;
            }
        }

        // Delete Student
        public string DeleteStudent(int id)
        {
            try
            {
                string result = string.Empty;
                result = student.DeleteStudent(id);
                return result;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex.Message);
                return ex.Message;
            }
        }

        //Register Student
        public string RegisterStudent(Student student)
        {
            try
            {
                string result = string.Empty;
                //Make Password Encrypted
                student.Password = Encryption(student.Password);

                result = student.RegisterStudent(student);
                return result;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex.Message);
                return ex.Message;
            }
        }

        public string EditStudent(Student student)
        {
            try
            {
                string result = string.Empty;
                //Make Password Encrypted
                student.Password = Encryption(student.Password);

                result = student.EditStudent(student);
                return result;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex.Message);
                return ex.Message;
            }
        }

        // Encryption
        public string Encryption(string str)
        {
            TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            Encoding encoding = Encoding.UTF8;

            string secretKey = "$Password@2024$";

            tripleDes.Key = MD5.ComputeHash(encoding.GetBytes(secretKey));
            tripleDes.Mode = CipherMode.ECB;

            byte[] dataToEncrypt = encoding.GetBytes(str);

            try
            {
                ICryptoTransform encryptor = tripleDes.CreateEncryptor();
                byte[] result = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length); 

                return Convert.ToBase64String(result);
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog($"Error: {ex.Message}");
                return ex.Message;
            }
            finally
            {
                MD5.Clear();
                tripleDes.Clear();
            }
        } 
        
        // Decryption
        public string Decryption(string str)
        {
            TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            Encoding encoding = Encoding.UTF8;

            string secretKey = "$Password@2024$";

            tripleDes.Key = MD5.ComputeHash(encoding.GetBytes(secretKey));
            tripleDes.Mode = CipherMode.ECB;

            byte[] dataToDecrypt = Convert.FromBase64String(str);

            try
            {
                ICryptoTransform decryptor = tripleDes.CreateDecryptor();
                byte[] result = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length); 

                return encoding.GetString(result);
            }   
            catch (Exception ex)
            {
                ErrorLogger.WriteLog($"Error: {ex.Message}");
                return ex.Message;
            }
            finally
            {
                MD5.Clear();
                tripleDes.Clear();
            }
        }
    }
}