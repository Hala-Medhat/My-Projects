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
    public partial class StudentProgressReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand prg = new SqlCommand("progressReport", conn);
            prg.CommandType = CommandType.StoredProcedure;

            prg.Parameters.Add(new SqlParameter("@sid", SqlDbType.Int)).Value = (Session["UserId"]);
            prg.Parameters.Add(new SqlParameter("@thesis", SqlDbType.Int)).Value = Session["ThesisInUse"];


            conn.Open();
            prg.ExecuteNonQuery();
           
            SqlDataReader rdr = prg.ExecuteReader(CommandBehavior.CloseConnection);
            
            DataTable tb = new DataTable();
            DataRow dr;
            tb.Columns.Add("Progress Report Number", typeof(int));
            tb.Columns.Add("Date", typeof(DateTime));
            tb.Columns.Add("Eval", typeof(string));
            tb.Columns.Add("State", typeof(int));
            tb.Columns.Add("Description", typeof(string));
            tb.Columns.Add("Supervisor", typeof(string));
           

            while (rdr.Read())
            {
                int no = rdr.GetInt32(rdr.GetOrdinal("no"));
                DateTime date = rdr.GetDateTime(rdr.GetOrdinal("date"));
                int evl = 0;
                String el = "NAN";
                int state = rdr.GetInt32(rdr.GetOrdinal("state"));
                String description = rdr.GetString(rdr.GetOrdinal("description"));
                String name = "NAN";

                dr = tb.NewRow();
                dr["Progress Report Number"] = no;
                dr["Date"] = date;
                dr["State"] = state;
                dr["Description"] = description;
                
                if (!rdr.IsDBNull(rdr.GetOrdinal("eval")))
                {
                    evl = rdr.GetInt32(rdr.GetOrdinal("eval"));
                    el= evl.ToString();

                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("name")))
                {
                    name = rdr.GetString(rdr.GetOrdinal("name"));
                   

                }
               

                dr["Eval"] = el;
                dr["Supervisor"] = name;
                tb.Rows.Add(dr);
            }
           
            GridView1.DataSource = tb;
            GridView1.DataBind();
            ViewState["table1"] = tb;
            conn.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int p = Int32.Parse(prn.Text);
            int s = Int32.Parse(state.Text);
            String des = descr.Value;
            if (prn.Text == "" | des == "" | state.Text == "" )
            {
                System.Windows.Forms.MessageBox.Show("Invalid Report , You have to fill all fields", "Warning", System.Windows.Forms.MessageBoxButtons.OK);
                return;
            }

            SqlCommand report = new SqlCommand("FillProgressReport", conn);
            report.CommandType = CommandType.StoredProcedure;

            report.Parameters.Add(new SqlParameter("@thesisSerialNo", SqlDbType.Int)).Value = Session["ThesisInUse"];
            report.Parameters.Add(new SqlParameter("@progressReportNo", SqlDbType.Int)).Value = p;
            report.Parameters.Add(new SqlParameter("@state", SqlDbType.Int)).Value =s;
            report.Parameters.Add(new SqlParameter("@description", SqlDbType.VarChar)).Value =des;
            report.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = Session["UserId"];


            

            DateTime now = DateTime.Now;

            SqlCommand add = new SqlCommand("AddProgressReport", conn);
            add.CommandType = CommandType.StoredProcedure;

            add.Parameters.Add(new SqlParameter("@thesisSerialNo", SqlDbType.Int)).Value = Session["ThesisInUse"];
            add.Parameters.Add(new SqlParameter("@progressReportNo", SqlDbType.Int)).Value = p;
            add.Parameters.Add(new SqlParameter("@progressReportDate", SqlDbType.DateTime)).Value = now;
            add.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = Session["UserId"];

            try
            {
                conn.Open();
                add.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                report.ExecuteNonQuery();
                conn.Close();
                prn.Text = "";
                state.Text = "";
                descr.Value = "";
                System.Windows.Forms.MessageBox.Show("Progress Report Added Successfully", "Confirmation", System.Windows.Forms.MessageBoxButtons.OK);
                Response.Redirect("StudentProgressReports.aspx");
               

            }
            catch (SqlException ex)
            {
                MessageBox.Show("You already have a progress report number with this value, please enter other", "Warning", MessageBoxButtons.OK);
                prn.Text = "";
                
            }
           
           




        }
    }
}