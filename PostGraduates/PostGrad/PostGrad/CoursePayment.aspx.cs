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
    public partial class CoursePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand pay = new SqlCommand("ViewCoursePayments", conn);
            pay.CommandType = CommandType.StoredProcedure;

            pay.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = (Session["UserId"]);
           


            conn.Open();
            pay.ExecuteNonQuery();
            SqlDataReader rdr = pay.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable tb = new DataTable();
            DataRow dr;
            tb.Columns.Add("Payment Number", typeof(int));
            tb.Columns.Add("Amount of Payment", typeof(decimal));
            tb.Columns.Add("fund", typeof(decimal));
            tb.Columns.Add("Number of installments", typeof(int));

            while (rdr.Read())
            {
                int no = rdr.GetInt32(rdr.GetOrdinal("Payment Number"));
                int inst = rdr.GetInt32(rdr.GetOrdinal("Number of installments"));
                
                Decimal amount = rdr.GetDecimal(rdr.GetOrdinal("Amount of Payment"));
                Decimal fund = rdr.GetDecimal(rdr.GetOrdinal("Percentage of fund for payment"));
          

                dr = tb.NewRow();
                dr["Payment Number"] = no;
                dr["Amount of Payment"] = amount;
                dr["fund"] = fund;
                dr["Number of installments"] = inst;

                
                tb.Rows.Add(dr);
            }

            GridView1.DataSource = tb;
            GridView1.DataBind();
            ViewState["table7"] = tb;
            conn.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseInstallment.aspx");
        }
    }
}