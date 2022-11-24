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
    public partial class List_Supervisors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand listsupervisors = new SqlCommand("AdminListSup", conn);
            listsupervisors.CommandType = CommandType.StoredProcedure;


            conn.Open();
            listsupervisors.ExecuteNonQuery();
            SqlDataReader rdr = listsupervisors.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable tb = new DataTable();
            DataRow dr;
            tb.Columns.Add("ID", typeof(int));
            tb.Columns.Add("Email", typeof(string));
            tb.Columns.Add("Password", typeof(string));
            tb.Columns.Add("Name", typeof(string));
            tb.Columns.Add("Faculty", typeof(string));

            while(rdr.Read())
            {
                int supid = rdr.GetInt32(rdr.GetOrdinal("id"));
                String supemail = rdr.GetString(rdr.GetOrdinal("email"));
                String suppass = rdr.GetString(rdr.GetOrdinal("password"));
                String supname = rdr.GetString(rdr.GetOrdinal("name"));
                String supfaculty = rdr.GetString(rdr.GetOrdinal("faculty"));

                dr = tb.NewRow();
                dr["ID"] = supid;
                dr["Email"] = supemail;
                dr["Password"] = suppass;
                dr["Name"] = supname;
                dr["Faculty"] = supfaculty;
                tb.Rows.Add(dr);
            }

            Gv1.DataSource = tb;
            Gv1.DataBind();
            ViewState["table"] = tb;

            conn.Close();
        }
    }
}