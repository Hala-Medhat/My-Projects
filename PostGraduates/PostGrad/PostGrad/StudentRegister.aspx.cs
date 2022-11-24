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
    public partial class StudentRegister : System.Web.UI.Page
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
            String pass = Password.Text;

            String fac = DropDownList1.SelectedItem.Text;
            String address = Address.Text;
            bool gucian = Gucian.Checked;
            if (fname == "" | lname == "" | email == "" | pass == "" |fac==""|address=="")
            {
                System.Windows.Forms.MessageBox.Show("Invalid profile , You have to fill all fields", "Warning", System.Windows.Forms.MessageBoxButtons.OK);
                return;
            }


            SqlCommand regProc = new SqlCommand("studentRegister", conn);
            regProc.CommandType = CommandType.StoredProcedure;

            regProc.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar)).Value = fname;
            regProc.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar)).Value = lname;
            regProc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = pass;
            regProc.Parameters.Add(new SqlParameter("@faculty", SqlDbType.VarChar)).Value = fac;
            regProc.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = email;
            regProc.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar)).Value = address;
            regProc.Parameters.Add(new SqlParameter("@Gucian", SqlDbType.Bit)).Value = gucian;



            conn.Open();
            regProc.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}