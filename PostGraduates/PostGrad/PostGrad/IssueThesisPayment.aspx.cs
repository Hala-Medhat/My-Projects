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
    public partial class Issue_Thesis_Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Payment(object sender, EventArgs e)
        {
            if (Thesis.Text == "" || Amount.Text == "" || NoInstallments.Text == "" || FundPercentage.Text == "")
            {
                MessageBox.Show("PLEASE FILL ALL THE FIELDS!!", "Warning", MessageBoxButtons.OK);
                return;
            }
            
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int serNo = Int32.Parse(Thesis.Text);
            decimal amount = Decimal.Parse(Amount.Text);
            int noinstall = Int32.Parse(NoInstallments.Text);
            decimal fundperc = Decimal.Parse(FundPercentage.Text);


            SqlCommand thesispayment = new SqlCommand("AdminIssueThesisPayment", conn);
            thesispayment.CommandType = CommandType.StoredProcedure;


            thesispayment.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = serNo;
            thesispayment.Parameters.Add(new SqlParameter("@amount", SqlDbType.Decimal)).Value = amount;
            thesispayment.Parameters.Add(new SqlParameter("@noOfInstallments", SqlDbType.VarChar)).Value = noinstall;
            thesispayment.Parameters.Add(new SqlParameter("@fundPercentage", SqlDbType.Decimal)).Value = fundperc;

            SqlParameter success = thesispayment.Parameters.Add("@out", SqlDbType.Bit);
            success.Direction = System.Data.ParameterDirection.Output;
            
            conn.Open();
            thesispayment.ExecuteNonQuery();
            conn.Close();

            if (success.Value.ToString() == "True")
            {
                MessageBox.Show("The Thesis payment has been issued successfully!!", "Confirmation", MessageBoxButtons.OK);
                Response.Redirect("AdminHome.aspx");
            }
            else
            {
                MessageBox.Show("Enter a valid thesis serial number!!", "Warning", MessageBoxButtons.OK);
                Thesis.Text = "";
            }
        }
    }
}