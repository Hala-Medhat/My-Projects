using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;

namespace PostGrad
{
    public partial class SupUpdateInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(faculty.Text))
            {
                string message = "Please enter valid information";
                string title = "Warning";
                MessageBox.Show(message, title);

            }
            else
            {
                String supname = name.Text;
                String supfaculty = faculty.Text;

                SqlCommand uppro = new SqlCommand("UpdateSupProfile", conn);
                uppro.CommandType = CommandType.StoredProcedure;

                uppro.Parameters.Add(new SqlParameter("@supervisorID", SqlDbType.Int)).Value = Session["UserId"];
                uppro.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar)).Value = supname;
                uppro.Parameters.Add(new SqlParameter("@faculty", SqlDbType.VarChar)).Value = supfaculty;

                conn.Open();
                uppro.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}