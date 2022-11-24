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
    public partial class List_Theses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand listtheses = new SqlCommand("AdminViewAllTheses", conn);
            listtheses.CommandType = CommandType.StoredProcedure;


            SqlCommand listongoing = new SqlCommand("AdminViewOnGoingTheses", conn);
            listongoing.CommandType = CommandType.StoredProcedure;

            SqlParameter ontheses = new SqlParameter();
            ontheses.ParameterName = "@thesesCount";
            ontheses.SqlDbType = System.Data.SqlDbType.Int;
            ontheses.Direction = System.Data.ParameterDirection.Output;

            listongoing.Parameters.Add(ontheses);
            //listongoing.Parameters.Add("@thesesCount", SqlDbType.Int);
            //ontheses.Direction = ParameterDirection.Output;

            conn.Open();
           
            listongoing.ExecuteNonQuery();

            string ongo = ontheses.Value.ToString();
            mylabel.Text = "Count of Ongoing Theses:  " + ongo;

            conn.Close();

            /*
            SqlDataReader rdr2 = listongoing.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr2.Read())
            {
                String ongo = rdr2.GetString(rdr2.GetOrdinal("@thesesCount"));
                Label ongoing = new Label();
                ongoing.Font.Bold = true;
                ongoing.Font.Name = "verdana";
                ongoing.Font.Overline = false;
                ongoing.Font.Size = 18;
                ongoing.Font.Strikeout = false;

                ongoing.Text = "Count of Ongoing Theses:  " + ongo;

                form2.Controls.Add(ongoing);
            }
            */


            conn.Open();

            listtheses.ExecuteNonQuery();
            SqlDataReader rdr = listtheses.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable tb = new DataTable();
            DataRow dr;
            tb.Columns.Add("Serial Number", typeof(int));
            tb.Columns.Add("Field Of Work", typeof(string));
            tb.Columns.Add("Type", typeof(string));
            tb.Columns.Add("Title", typeof(string));
            tb.Columns.Add("Start Date", typeof(string));
            tb.Columns.Add("End Date", typeof(string));
            tb.Columns.Add("Defense Date", typeof(string));
            tb.Columns.Add("Years", typeof(int));
            tb.Columns.Add("Grade", typeof(string));
            tb.Columns.Add("Payment ID", typeof(string));
            tb.Columns.Add("Number of Extensions", typeof(string));


            while (rdr.Read())
            {
                int serialno = rdr.GetInt32(rdr.GetOrdinal("serialNumber"));
                String field = rdr.GetString(rdr.GetOrdinal("field"));
                String type = rdr.GetString(rdr.GetOrdinal("type"));
                String title = rdr.GetString(rdr.GetOrdinal("title"));
                DateTime start = rdr.GetDateTime(rdr.GetOrdinal("startDate"));
                DateTime end = rdr.GetDateTime(rdr.GetOrdinal("endDate"));
               
                int years = rdr.GetInt32(rdr.GetOrdinal("years"));

                String pa = "NULL";
                String ex = "NULL";

                String df = "NULL";
                String g = "NULL";

                
                dr = tb.NewRow();
                dr["Serial Number"] = serialno;
                dr["Field Of Work"] = field;
                dr["Type"] = type;
                dr["Title"] = title;
                dr["Start Date"] = start;
                dr["End Date"] = end;
                
                dr["Years"] = years;
                
                

                if (!rdr.IsDBNull(rdr.GetOrdinal("grade")))
                {
                    decimal grade = rdr.GetDecimal(rdr.GetOrdinal("grade"));
                    g = grade.ToString();
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("payment_id")))
                {
                    int payid = rdr.GetInt32(rdr.GetOrdinal("payment_id"));
                    pa = payid.ToString();
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("noOfExtensions")))
                {
                    int extensions = rdr.GetInt32(rdr.GetOrdinal("noOfExtensions"));
                    ex = extensions.ToString();
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("defenseDate")))
                {
                    DateTime defdate = rdr.GetDateTime(rdr.GetOrdinal("defenseDate"));
                    df = defdate.ToString();
                }
                dr["Payment ID"] = pa;
                dr["Defense Date"] = df;
                dr["Grade"] = g;
                dr["Number of Extensions"] = ex;
                tb.Rows.Add(dr);
            }

            Gv2.DataSource = tb;
            Gv2.DataBind();
            ViewState["table"] = tb;

            conn.Close();
        }
    }
    }
