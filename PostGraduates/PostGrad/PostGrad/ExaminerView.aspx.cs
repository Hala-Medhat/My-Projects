using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostGrad
{
    public partial class ExaminerView : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand viewproc = new SqlCommand("viewtableExaminer", conn);
            viewproc.CommandType = CommandType.StoredProcedure;
            viewproc.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar)).Value = Session["UserId"];
            conn.Open();
            viewproc.ExecuteNonQuery();


            SqlDataReader rdr = viewproc.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable tb = new DataTable();
            DataRow dr;
            tb.Columns.Add("Thesis Title", typeof(string));
            tb.Columns.Add("Supervisor Name", typeof(string)); //null is allowed
            tb.Columns.Add("Student", typeof(string)); //null is allowed
            //tb.Columns.Add("Non-Gucian Student", typeof(string)); //null is allowed
            while (rdr.Read())
            {
                String thesis = rdr.GetString(rdr.GetOrdinal("Thesis Title"));
                String supname;
                String Gname;

                String g = "NAN";
                dr = tb.NewRow();
                dr["Thesis Title"] = thesis;
                if (!rdr.IsDBNull(rdr.GetOrdinal("Supervisor Name")))
                {
                    supname = rdr.GetString(rdr.GetOrdinal("Supervisor Name"));
                    dr["Supervisor Name"] = supname;
                }
                else
                {
                    dr["Supervisor Name"] = g;
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("Student")))
                {
                    Gname = rdr.GetString(rdr.GetOrdinal("Student"));
                    dr["Student"] = Gname;
                }
                else
                {
                    dr["Student"] = g;
                }

                tb.Rows.Add(dr);



            }
            GridView1.DataSource = tb;
            GridView1.DataBind();
            ViewState["table"] = tb;


        }

        private void SearchThesis()
        {

            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand searchproc = new SqlCommand("searchThesis", conn);
            searchproc.CommandType = CommandType.StoredProcedure;
            searchproc.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar)).Value = Session["UserId"];
            searchproc.Parameters.AddWithValue("@thesistitle", TextBox1.Text);
            conn.Open();
            searchproc.ExecuteNonQuery();
            using (SqlDataAdapter sda = new SqlDataAdapter(searchproc))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }



        }



        protected void editmyprofile(object sender, EventArgs e)
        {
            Response.Redirect("EditExaminer.aspx");
        }
        protected void AddDefense(object sender, EventArgs e)
        {
            Response.Redirect("AddDefense.aspx");
        }
        protected void AddComment(object sender, EventArgs e)
        {
            Response.Redirect("AddComment.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                this.SearchThesis();


                //not completed yet 
            }
        }
    }
}