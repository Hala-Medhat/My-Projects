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
    public partial class SupViewPublication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand supviewpub = new SqlCommand("ViewAStudentPublications", conn);
            supviewpub.CommandType = CommandType.StoredProcedure;

            supviewpub.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = Session["StudentId"];


            supviewpub.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader rdr = supviewpub.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable tb = new DataTable();
            DataRow dr;
            tb.Columns.Add("id", typeof(int));
            tb.Columns.Add("title", typeof(string));
            tb.Columns.Add("dateOfPublication", typeof(string));
            tb.Columns.Add("place", typeof(string));
            tb.Columns.Add("accepted", typeof(bool));
            tb.Columns.Add("host", typeof(string));
            
            while (rdr.Read())
            {

                int pid = rdr.GetInt32(rdr.GetOrdinal("id"));
                String title = rdr.GetString(rdr.GetOrdinal("title"));
                DateTime date;
                String place;
                bool acc;
                String host;
                String g = "NAN";

                dr = tb.NewRow();
                dr["id"] = pid;
                dr["title"] = title;
                if (!rdr.IsDBNull(rdr.GetOrdinal("dateOfPublication")))
                {
                    date = rdr.GetDateTime(rdr.GetOrdinal("dateOfPublication"));
                    dr["dateOfPublication"] = date;
                }
                else
                {
                    dr["dateOfPublication"] = g;
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("place")))
                {
                    place = rdr.GetString(rdr.GetOrdinal("place"));
                    dr["place"] = place;
                }
                else
                {
                    dr["place"] = g;
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("accepted")))
                {
                    acc = rdr.GetBoolean(rdr.GetOrdinal("accepted"));
                    dr["accepted"] = acc;
                }
                else
                {
                    dr["accepted"] = g;
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("host")))
                {
                    host = rdr.GetString(rdr.GetOrdinal("host"));
                    dr["host"] = host;
                }
                else
                {
                    dr["host"] = g;
                    
                }
                tb.Rows.Add(dr);
            }
            GridView1.DataSource = tb;
            GridView1.DataBind();
            ViewState["table1"] = tb;
        }
    }
}