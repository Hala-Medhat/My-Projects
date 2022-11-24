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
    public partial class SupervisorRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void register(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String fname = FName.Text;
            String lname = LName.Text;
            String email = Email.Text;
            String pass =   Password.Text;
      
            String fac = DropDownList1.SelectedItem.Text;


            SqlCommand regProc = new SqlCommand("supervisorRegister", conn);
            regProc.CommandType = CommandType.StoredProcedure;

            regProc.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar)).Value = fname;
            regProc.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar)).Value = lname;
            regProc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = pass;
            regProc.Parameters.Add(new SqlParameter("@faculty", SqlDbType.VarChar)).Value = fac;
            regProc.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = email;

            conn.Open();
            regProc.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("login.aspx");
        }
    }
}