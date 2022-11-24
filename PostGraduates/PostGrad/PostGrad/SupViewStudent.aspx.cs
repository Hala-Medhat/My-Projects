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
    public partial class viewstudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand supviewstu = new SqlCommand("ViewSupStudentsYears", conn);
            supviewstu.CommandType = CommandType.StoredProcedure;

            supviewstu.Parameters.Add(new SqlParameter("@supervisorID", SqlDbType.Int)).Value = Session["UserId"];


            supviewstu.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader rdr = supviewstu.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable tb = new DataTable();
            DataRow dr;
            tb.Columns.Add("firstName", typeof(string));
            tb.Columns.Add("lastName", typeof(string));
            tb.Columns.Add("years", typeof(int));

            while (rdr.Read())
            {
                int yea = rdr.GetInt32(rdr.GetOrdinal("years"));
                String fname;
                String lname;
                String g = "NAN";

                dr = tb.NewRow();
                dr["years"] = yea;
                if (!rdr.IsDBNull(rdr.GetOrdinal("firstName")))
                {
                    fname = rdr.GetString(rdr.GetOrdinal("firstName"));
                    dr["firstName"] = fname;
                }
                else
                {
                    dr["firstName"] = g;
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("lastName")))
                {
                    lname = rdr.GetString(rdr.GetOrdinal("lastName"));
                    dr["lastName"] = lname;
                }
                else
                {
                    dr["lastName"] = g;
                   
                }
                tb.Rows.Add(dr);

            }
            GridView1.DataSource = tb;
            GridView1.DataBind();
            ViewState["table"] = tb;
        }

        }
      
    }
