using System.IO;
using BALayer;
using DALayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentCore
{
    public partial class RegistrationStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            ErrorLogger.WriteLog("BtnRegister_Click() called.");

            string name = Name.Text;
            string email = Email.Text;
            string password = Password.Text;
            string mobile = Mobile.Text;
            string imageName = "default.jpg";

            if (name.Length <= 0)
            {
                lblErrorMsg.Text = "Name field is required.";
                ErrorLogger.WriteLog("Error: Name field is required.");
                return;
            }
            else if (email.Length <= 0)
            {
                lblErrorMsg.Text = "Email field is required.";
                ErrorLogger.WriteLog("Error: Email field is required.");
                return;
            }
            else if (password.Length <= 0)
            {
                lblErrorMsg.Text = "Password field is required.";
                ErrorLogger.WriteLog("Error: Password field is required.");
                return;
            }
            else if (mobile.Length <= 0)
            {
                lblErrorMsg.Text = "Mobile field is required.";
                ErrorLogger.WriteLog("Error: Mobile field is required.");
                return;
            }
            else
            {
                lblErrorMsg.Text = String.Empty;
            }

            if (Image.HasFile)
            {
                HttpPostedFile httpFile = Image.PostedFile;

                string path = Server.MapPath("~/Images");
                string imgExtension = Path.GetExtension(Image.FileName);
                Random random = new Random();
                imageName = name.Substring(0, 3).ToLower().Trim() + random.Next() + imgExtension;
                string fullPath = Path.Combine(path, imageName);

                httpFile.SaveAs(fullPath);
            }

            Student student = new Student(name, email, password, mobile, imageName);
            StudentBAL studentBAL = new StudentBAL();

            string response = studentBAL.RegisterStudent(student);
            if (Convert.ToInt32(response) > 0)
            {
                ErrorLogger.WriteLog("BtnRegister_Click() Executed & Student Registered.");
                Response.Redirect("StudentGrid.aspx");
            }
            ErrorLogger.WriteLog("Error in BtnRegister_Click().");
        }
    }
}