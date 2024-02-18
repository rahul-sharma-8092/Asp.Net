using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DALayer;
using BALayer;
using System.Data;

namespace StudentCore
{
    public partial class StudentGrid : System.Web.UI.Page
    {
        StudentBAL studentBAL = new StudentBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StudentList();
            }
        }

        private void StudentList()
        {
            DataTable dt = new DataTable();
            dt = studentBAL.StudentLst();

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            ErrorLogger.WriteLog("StudentList() Executed Successfully.");
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument.ToString();
            Response.Redirect("/EditStudent.aspx?id=" + id);
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int Id = Convert.ToInt32(btn.CommandArgument.ToString());
            studentBAL.DeleteStudent(Id);
            StudentList();
        }
    }
}