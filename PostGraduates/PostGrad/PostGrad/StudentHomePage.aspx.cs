using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PostGrad
{
    public partial class StudentHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Session["UserId"]);

            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand ThesisInfo = new SqlCommand("ThesisInfo", conn);
            ThesisInfo.CommandType = CommandType.StoredProcedure;

            ThesisInfo.Parameters.Add(new SqlParameter("@studentId", SqlDbType.Int)).Value = (Session["UserId"]);


            conn.Open();
            ThesisInfo.ExecuteNonQuery();
            SqlDataReader rdr = ThesisInfo.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.Read())
            {

                int sn = rdr.GetInt32(rdr.GetOrdinal("serialNumber"));
                String title = rdr.GetString(rdr.GetOrdinal("title"));
                String s = "";
                String ed = "";
                String n = "";

                if (!rdr.IsDBNull(rdr.GetOrdinal("startDate")))
                {
                   
                    DateTime sd = Convert.ToDateTime(rdr.GetDateTime(rdr.GetOrdinal("startDate")));
                    s = sd.ToString();
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("endDate")))
                {

                    DateTime rd = Convert.ToDateTime(rdr.GetDateTime(rdr.GetOrdinal("endDate")));
                    ed = rd.ToString();
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("noOfExtensions")))
                {
                    int ne = rdr.GetInt32(rdr.GetOrdinal("noOfExtensions"));
                    n = ne.ToString();
                }

                System.Web.UI.WebControls.Label l1 = new System.Web.UI.WebControls.Label();
                l1.Text = sn.ToString();
                System.Web.UI.WebControls.Label l2 = new System.Web.UI.WebControls.Label();
                l2.Text = title;
                System.Web.UI.WebControls.Label l3 = new System.Web.UI.WebControls.Label();
                l3.Text = s.ToString();
                System.Web.UI.WebControls.Label l4 = new System.Web.UI.WebControls.Label();
                l4.Text = ed.ToString();
                System.Web.UI.WebControls.Label l5 = new System.Web.UI.WebControls.Label();
                l5.Text = n.ToString();

                serial.Controls.Add(l1);

                Title.Controls.Add(l2);

                start.Controls.Add(l3);

                end.Controls.Add(l4);

                no.Controls.Add(l5);
                Session["ThesisInUse"] = sn;


            }
            else
            {
                Session["ThesisInUse"] = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand Gucian = new SqlCommand("isGucian", conn);
            Gucian.CommandType = CommandType.StoredProcedure;

            Gucian.Parameters.Add(new SqlParameter("@studentId", SqlDbType.Int)).Value = (Session["UserId"]);
            SqlParameter sucess = Gucian.Parameters.Add("@sucess", SqlDbType.Bit);

            sucess.Direction = System.Data.ParameterDirection.Output;

            conn.Open();
            Gucian.ExecuteNonQuery();
            conn.Close();
            Session["isGucian"] = sucess.Value.ToString();
            Response.Redirect("StudentProfile.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand Gucian = new SqlCommand("isGucian", conn);
            Gucian.CommandType = CommandType.StoredProcedure;

            Gucian.Parameters.Add(new SqlParameter("@studentId", SqlDbType.Int)).Value = (Session["UserId"]);
            SqlParameter sucess = Gucian.Parameters.Add("@sucess", SqlDbType.Bit);

            sucess.Direction = System.Data.ParameterDirection.Output;

            conn.Open();
            Gucian.ExecuteNonQuery();
            conn.Close();
            if(sucess.Value.ToString()=="True")
            {

                MessageBox.Show("Sorry You Don't have any courses to show", "Warning", MessageBoxButtons.OK);
                Response.Redirect("StudentHomePage.aspx");

                
            }
            else
            {
                Response.Redirect("StudentCourses.aspx");

            }
                
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
                Response.Redirect("StudentThesis.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand Gucian = new SqlCommand("isGucian", conn);
            Gucian.CommandType = CommandType.StoredProcedure;

            Gucian.Parameters.Add(new SqlParameter("@studentId", SqlDbType.Int)).Value = (Session["UserId"]);
            SqlParameter sucess = Gucian.Parameters.Add("@sucess", SqlDbType.Bit);

            sucess.Direction = System.Data.ParameterDirection.Output;

            conn.Open();
            Gucian.ExecuteNonQuery();
            conn.Close();
            if(sucess.Value.ToString()=="True")
            {
                MessageBox.Show("Sorry You Don't have any courses payments to show", "Warning", MessageBoxButtons.OK);

            }
            else
            {
                Response.Redirect("CoursePayment.aspx");
            }

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThesisPayment.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Installments.aspx");
        }
    }


}
    

