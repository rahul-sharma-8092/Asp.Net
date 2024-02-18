using BALayer;
using DALayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace StudentCore
{
    public partial class EditStudent : System.Web.UI.Page
    {
        StudentBAL studentBAL = new StudentBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                GetStudentDatabyId(id);
            }
        }

        private void GetStudentDatabyId(int id)
        {
            DataTable dt = new DataTable();
            dt = studentBAL.GetStudentDatabyId(id);

            Repeater2.DataSource = dt;
            Repeater2.DataBind();
            ErrorLogger.WriteLog("GetStudentDatabyId() Executed Successfully.");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            RepeaterItem item = Repeater2.Items[0];

            TextBox txtName = (TextBox)item.FindControl("Name");
            TextBox txtEmail = (TextBox)item.FindControl("Email");
            TextBox txtPassword = (TextBox)item.FindControl("Password");
            TextBox txtMobile = (TextBox)item.FindControl("Mobile");
            Image prevImage = (Image)item.FindControl("prevImage");
            FileUpload fileImage = (FileUpload)item.FindControl("currImage");

            int id = Convert.ToInt32(Request.QueryString["id"]);
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string mobile = txtMobile.Text;
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

            if (fileImage.HasFile)
            {
                HttpPostedFile httpFile = fileImage.PostedFile;

                string path = Server.MapPath("~/Images");

                string imgExtension = Path.GetExtension(fileImage.FileName);

                Random random = new Random();
                imageName = name.Substring(0, 3).ToLower().Trim() + random.Next() + imgExtension;

                string fullPath = Path.Combine(path, imageName);

                httpFile.SaveAs(fullPath);
            }
            else
            {
                imageName = prevImage.ImageUrl.Substring(7);
            }

            Student student = new Student(name, email, password, mobile, imageName);
            student.Id = id;

            string response = studentBAL.EditStudent(student);
            if (Convert.ToInt32(response) > 0)
            {
                ErrorLogger.WriteLog("User updated Successfully");
                Response.Redirect("StudentGrid.aspx");
            }
            else
            {
                lblErrorMsg.Text = response;
            }

        }
    }
}