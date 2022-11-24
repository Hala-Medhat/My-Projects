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
    public partial class Installments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand pay = new SqlCommand("ViewUpcomingInstallments", conn);
            pay.CommandType = CommandType.StoredProcedure;

            pay.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = (Session["UserId"]);



            conn.Open();
            pay.ExecuteNonQuery();
            
            SqlDataReader rdr = pay.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable tb = new DataTable();
            DataRow dr;
            tb.Columns.Add("Date", typeof(string));
            tb.Columns.Add("Amount", typeof(decimal));
            

            while (rdr.Read())
            {
                DateTime d = rdr.GetDateTime(rdr.GetOrdinal("Date of Installment"));
                Decimal inst = rdr.GetDecimal(rdr.GetOrdinal("Amount"));

               


                dr = tb.NewRow();
                dr["Date"] = d.ToString();
                dr["Amount"] = inst;
                


                tb.Rows.Add(dr);
            }

            GridView1.DataSource = tb;
            GridView1.DataBind();
            ViewState["table5"] = tb;

            conn.Close();
            SqlCommand up = new SqlCommand("ViewMissedInstallments", conn);
            up.CommandType = CommandType.StoredProcedure;

            up.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = (Session["UserId"]);



            conn.Open();
            up.ExecuteNonQuery();
           
            SqlDataReader rd = up.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable tb1 = new DataTable();
            DataRow dr1;
            tb1.Columns.Add("Date", typeof(string));
            tb1.Columns.Add("Amount", typeof(decimal));
            


            while (rd.Read())
            {
                DateTime d = rd.GetDateTime(rd.GetOrdinal("Date of Installment"));
                Decimal inst = rd.GetDecimal(rd.GetOrdinal("Amount"));

                dr1 = tb1.NewRow();
                dr1["Date"] = d.ToString();
                dr1["Amount"] = inst;



                tb1.Rows.Add(dr1);
            }

            GridView2.DataSource = tb1;
            GridView2.DataBind();
            ViewState["table4"] = tb1;
            conn.Close();

        }
    }
}