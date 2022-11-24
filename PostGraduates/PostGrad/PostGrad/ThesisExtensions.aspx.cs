using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PostGrad
{
    public partial class Thesis_Extensions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Extension(object sender, EventArgs e)
        {
            if (Thesis.Text == "")
            {
                MessageBox.Show("PLEASE FILL ALL THE FIELDS!!", "Warning", MessageBoxButtons.OK);
                return;
            }

            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int serNo = Int32.Parse(Thesis.Text);

            SqlCommand extensions = new SqlCommand("AdminUpdateExtension", conn);
            extensions.CommandType = CommandType.StoredProcedure;

            extensions.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = serNo;

            SqlParameter success = extensions.Parameters.Add("@success", SqlDbType.Bit);
            success.Direction = System.Data.ParameterDirection.Output;


            conn.Open();
            extensions.ExecuteNonQuery();
            conn.Close();

            //Response.Redirect("AdminHome.aspx", false);
            if (success.Value.ToString() == "True")
            {


                MessageBox.Show("The thesis has been extended successfully", "Confirmation", MessageBoxButtons.OK);
                Response.Redirect("AdminHome.aspx");

            }
            else
            {
                MessageBox.Show("Enter a valid thesis serial number", "Warning", MessageBoxButtons.OK);
                Thesis.Text = "";


            }

        }
    }
}