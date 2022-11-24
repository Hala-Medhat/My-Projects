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
    public partial class CourseInstallment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand pay = new SqlCommand("ViewCoursePaymentsInstall", conn);
            pay.CommandType = CommandType.StoredProcedure;

            pay.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = (Session["UserId"]);



            conn.Open();
            pay.ExecuteNonQuery();
            SqlDataReader rdr = pay.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable tb = new DataTable();
            DataRow dr;
            tb.Columns.Add("Payment Number", typeof(int));
            tb.Columns.Add("Installment Amount", typeof(decimal));
            tb.Columns.Add("Installment date", typeof(DateTime));
            tb.Columns.Add("Done", typeof(string));

            while (rdr.Read())
            {
                int no = rdr.GetInt32(rdr.GetOrdinal("Payment Number"));
                Decimal inst = rdr.GetDecimal(rdr.GetOrdinal("Installment Amount"));

                DateTime date = rdr.GetDateTime(rdr.GetOrdinal("Installment date"));
                bool done = rdr.GetBoolean(rdr.GetOrdinal("Installment done or not"));


                dr = tb.NewRow();
                dr["Payment Number"] = no;
                dr["Installment Amount"] = inst;
                dr["Installment date"] = date;
                dr["Done"] = done.ToString();


                tb.Rows.Add(dr);
            }

            GridView1.DataSource = tb;
            GridView1.DataBind();
            ViewState["table1"] = tb;
            conn.Close();
        }


    }
}
