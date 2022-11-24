using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostGrad
{
    public partial class EditExaminer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void edit(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            String firstname = fname.Text;
            String lastname = lname.Text;
            String fieldof = field.Text;
            //String id = TextBox1.Text;

            SqlCommand editproc = new SqlCommand("editexaminerprofile", conn);
            editproc.CommandType = CommandType.StoredProcedure;
            editproc.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar)).Value = Session["UserId"];
            editproc.Parameters.Add(new SqlParameter("@fname", SqlDbType.VarChar)).Value = firstname;
            editproc.Parameters.Add(new SqlParameter("@lname", SqlDbType.VarChar)).Value = lastname;
            editproc.Parameters.Add(new SqlParameter("@fieldOfWork", SqlDbType.VarChar)).Value = fieldof;
           

            conn.Open();
            editproc.ExecuteNonQuery();
            conn.Close();
            
            Response.Redirect("ExaminerView.aspx");
        }
    }
}