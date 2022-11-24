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
    public partial class Issue_Installment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Installments(object sender, EventArgs e)
        {
            if (payId.Text == "" || startdate.Text == "")
            {
                MessageBox.Show("PLEASE FILL ALL THE FIELDS!!", "Warning", MessageBoxButtons.OK);
                return;
            }

            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int paymentID = Int32.Parse(payId.Text);
            DateTime startDate = DateTime.Parse(startdate.Text);

            SqlCommand installpay = new SqlCommand("AdminIssueInstallPayment", conn);
            installpay.CommandType = CommandType.StoredProcedure;


            installpay.Parameters.Add(new SqlParameter("@paymentID", SqlDbType.Int)).Value = paymentID;
            installpay.Parameters.Add(new SqlParameter("@InstallStartDate", SqlDbType.Date)).Value = startDate.Date;

            SqlParameter success = installpay.Parameters.Add("@success", SqlDbType.Bit);
            success.Direction = System.Data.ParameterDirection.Output;

            conn.Open();
            installpay.ExecuteNonQuery();
            conn.Close();

            if (success.Value.ToString() == "True")
            {
                MessageBox.Show("All Installments have been issued successfully!!", "Confirmation", MessageBoxButtons.OK);
                Response.Redirect("AdminHome.aspx");
            }
            else
            {
                MessageBox.Show("Enter a valid payment ID!!", "Warning", MessageBoxButtons.OK);
                payId.Text = "";
            }

        }
    }
}