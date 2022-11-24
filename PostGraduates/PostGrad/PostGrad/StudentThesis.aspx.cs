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
    public partial class StudentThesis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("viewThesis", conn);
            view.CommandType = CommandType.StoredProcedure;

            view.Parameters.Add(new SqlParameter("@sid", SqlDbType.Int)).Value = (Session["UserId"]);
        


            conn.Open();
            view.ExecuteNonQuery();
            
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable tb = new DataTable();
            DataRow dr;
            tb.Columns.Add("SerialNumber", typeof(int));
            tb.Columns.Add("Title", typeof(string));
            tb.Columns.Add("Field", typeof(string));
            tb.Columns.Add("Type", typeof(string));
            tb.Columns.Add("Start_Date", typeof(string));
            tb.Columns.Add("End_Date", typeof(string));
            tb.Columns.Add("NoOfExtensions", typeof(string));
            tb.Columns.Add("Defense_Date", typeof(string));
            tb.Columns.Add("Years", typeof(string));
            tb.Columns.Add("Grade", typeof(String));
           
            while (rdr.Read())
            {
                int sn = rdr.GetInt32(rdr.GetOrdinal("serialNumber"));
                


                dr = tb.NewRow();
                dr["SerialNumber"]=sn;
                
                String f = "";
                String t = "";
                String ty = "";
                String sd="";
                String ed="" ;
                String dd="";
                String y = "";
                String g = "";
                String no = "";
                if (!rdr.IsDBNull(rdr.GetOrdinal("field")))
                {
                    f = rdr.GetString(rdr.GetOrdinal("field"));
                    

                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("type")))
                {
                   t = rdr.GetString(rdr.GetOrdinal("type"));


                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("type")))
                {
                    ty = rdr.GetString(rdr.GetOrdinal("type"));


                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("startDate")))
                {
                    
                    DateTime s = rdr.GetDateTime(rdr.GetOrdinal("startDate"));
                    sd = s.ToString();


                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("endDate")))
                {
                    DateTime s = rdr.GetDateTime(rdr.GetOrdinal("endDate"));
                    ed = s.ToString();


                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("defenseDate")))
                {
                    DateTime s = rdr.GetDateTime(rdr.GetOrdinal("defenseDate"));
                    dd = s.ToString();


                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("years")))
                {
                    int year = rdr.GetInt32(rdr.GetOrdinal("years"));
                    y = year.ToString();


                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("grade")))
                {
                   decimal gr = rdr.GetDecimal(rdr.GetOrdinal("grade"));
                    g = gr.ToString();


                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("noOfExtensions")))
                {
                    int ex = rdr.GetInt32(rdr.GetOrdinal("noOfExtensions"));
                    no = ex.ToString();
                }
               

                dr["Title"] = t;
                dr["Field"] = f;
                dr["Start_Date"] = sd;
                dr["End_Date"] = ed;
                dr["NoOfExtensions"] = no;
                dr["Defense_Date"] = dd;
                dr["Years"] = y;
                dr["Grade"] = g;

                tb.Rows.Add(dr);
            }

            GridView1.DataSource = tb;
            GridView1.DataBind();
            ViewState["table8"] = tb;
          
            Thesis.Text = Session["ThesisInUse"].ToString();
            Thesis.Attributes.Add("ReadOnly", "true");
            conn.Close();

        }

        protected void progress_Click(object sender, EventArgs e)
        {
            if (Session["ThesisInUse"].ToString() == "")
            {
                MessageBox.Show("You don't have a current thesis to add report to!", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                Session["ThesisInUse"] = Int32.Parse(Thesis.Text);
                Response.Redirect("StudentProgressReports.aspx");
            }
        }

        protected void publication_Click(object sender, EventArgs e)
        {
            if (Session["ThesisInUse"].ToString() == "")
            {
                MessageBox.Show("You don't have a current thesis to add publication to!", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                Session["ThesisInUse"] = Int32.Parse(Thesis.Text);
                Response.Redirect("StudentPublication.aspx");
            }
        }
    }
}