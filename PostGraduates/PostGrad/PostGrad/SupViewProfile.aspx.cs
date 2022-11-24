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
    public partial class SupViewProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand supviewpro = new SqlCommand("SupViewProfile", conn);
            supviewpro.CommandType = CommandType.StoredProcedure;

            supviewpro.Parameters.Add(new SqlParameter("@supervisorID", SqlDbType.Int)).Value = Session["UserId"];
            conn.Open();
            SqlDataReader rdr = supviewpro.ExecuteReader(CommandBehavior.CloseConnection);

            DataTable tb = new DataTable();
            DataRow dr;
            tb.Columns.Add("id", typeof(int));
            tb.Columns.Add("email", typeof(string));
            tb.Columns.Add("password", typeof(string));
            tb.Columns.Add("name", typeof(string));
            tb.Columns.Add("faculty", typeof(string));

            while (rdr.Read())
            {

                int sid = rdr.GetInt32(rdr.GetOrdinal("id"));
                String email;
                String password;
                String name;
                String faculty;
                String g = "NAN";

                dr = tb.NewRow();
                dr["id"] = sid;
                if (!rdr.IsDBNull(rdr.GetOrdinal("email")))
                {
                    email = rdr.GetString(rdr.GetOrdinal("email"));
                    dr["email"] = email;
                }
                else
                {
                    dr["email"] = g;
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("password")))
                {
                    password = rdr.GetString(rdr.GetOrdinal("password"));
                    dr["password"] = password;
                }
                else
                {
                    dr["password"] = g;
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("name")))
                {
                    name = rdr.GetString(rdr.GetOrdinal("name"));
                    dr["name"] = name;
                }
                else
                {
                    dr["name"] = g;
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("faculty")))
                {
                    faculty = rdr.GetString(rdr.GetOrdinal("faculty"));
                    dr["faculty"] = faculty;
                }
                else
                {
                    dr["faculty"] = g;

                }
                tb.Rows.Add(dr);
            }
            GridView1.DataSource = tb;
            GridView1.DataBind();
            ViewState["table2"] = tb;
        }
    }
}