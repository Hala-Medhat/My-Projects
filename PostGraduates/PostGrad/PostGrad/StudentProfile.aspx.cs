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

namespace PostGrad
{
    public partial class StudentProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("viewMyProfile", conn);
            view.CommandType = CommandType.StoredProcedure;

            view.Parameters.Add(new SqlParameter("@studentId", SqlDbType.Int)).Value = (Session["UserId"]);


            conn.Open();
            view.ExecuteNonQuery();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.Read())
            {
                int id = rdr.GetInt32(rdr.GetOrdinal("id"));
                String first = rdr.GetString(rdr.GetOrdinal("firstName"));
                String last = rdr.GetString(rdr.GetOrdinal("lastName"));
                String address = rdr.GetString(rdr.GetOrdinal("address"));
                String type = "NAN";
                if (!rdr.IsDBNull(rdr.GetOrdinal("type")))
                {
                    type = rdr.GetString(rdr.GetOrdinal("type"));
                }
                String faculty = rdr.GetString(rdr.GetOrdinal("faculty"));
                String email = rdr.GetString(rdr.GetOrdinal("email"));
                String under = "";
                if (Session["isGucian"].ToString() == "True")
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("undergradID")))
                    {
                        under = rdr.GetString(rdr.GetOrdinal("undergradID"));
                        
                    }

                }

                Label l1 = new Label();
                l1.Text = id.ToString();
                Label l2 = new Label();
                l2.Text = first;
                Label l3 = new Label();
                l3.Text = last.ToString();
                Label l4 = new Label();
                l4.Text = email.ToString();
                Label l5 = new Label();
                l5.Text = address;
                Label l6 = new Label();
                l6.Text = type;
                Label l7 = new Label();
                l7.Text = faculty;
                var h4 = new HtmlGenericControl("h4");
                Label l9 = new Label();


                ID.Controls.Add(l1);
                fn.Controls.Add(l2);
                ln.Controls.Add(l3);
                em.Controls.Add(l4);
                add.Controls.Add(l5);
                Type.Controls.Add(l6);
                fac.Controls.Add(l7);


                uid.Controls.Add(h4);

                if (Session["isGucian"].ToString() == "True")
                {
                    if (under != "")
                    {
                        TextBox2.Style.Add("display", "none");


                        l9.Text = under.ToString();

                        uid.Controls.Add(l9);
                        btn.Attributes.Add("style", "display:none");



                    }
                }
                else
                {
                    underid.Style.Add("display", "none");
                    TextBox2.Style.Add("display", "none");
                    btn.Attributes.Add("style", "display:none");

                }
                    Session["FistName"] = first;

                    Session["LastName"] = last;
                    Session["Address"] = address;

                    Session["type"] = type;
                }
                conn.Close();

                SqlCommand phone = new SqlCommand("showMobile", conn);
                phone.CommandType = CommandType.StoredProcedure;

                phone.Parameters.Add(new SqlParameter("@studentId", SqlDbType.Int)).Value = (Session["UserId"]);


                conn.Open();
                phone.ExecuteNonQuery();
                SqlDataReader rd = phone.ExecuteReader(CommandBehavior.CloseConnection);
                int x = 1;
                while (rd.Read())
                {
                    Label l = new Label();
                    l.Text = x + "." + rd.GetString(rd.GetOrdinal("phone"));
                    phones.Controls.Add(l);
                    x++;


                }
                conn.Close();



            }
        

            protected void Update(object sender, EventArgs e)
            {
                Response.Redirect("StudentUpdateProfile.aspx");

            }


            protected void Button1_Click(object sender, EventArgs e)
            {
                String p = TextBox1.Text;
                String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand add = new SqlCommand("addMobile", conn);
                add.CommandType = CommandType.StoredProcedure;

                add.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = (Session["UserId"]);
                add.Parameters.Add(new SqlParameter("@mobile_number", SqlDbType.VarChar)).Value = p;
            try
            {
                conn.Open();

                add.ExecuteNonQuery();
                conn.Close();
                TextBox1.Text = "";
                Response.Redirect("StudentProfile.aspx");
            }
            catch (SqlException ex) {
                System.Windows.Forms.MessageBox.Show("This mobile number is already added ", "warning", System.Windows.Forms.MessageBoxButtons.OK);
                TextBox1.Text = "";

            }





            }

            protected void btn_Click(object sender, EventArgs e)
            {
            
                String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand add = new SqlCommand("addUndergradID", conn);
                add.CommandType = CommandType.StoredProcedure;

                add.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = (Session["UserId"]);
                add.Parameters.Add(new SqlParameter("@undergradID", SqlDbType.VarChar)).Value = TextBox2.Text;
                try
                {
                    conn.Open();

                    add.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("please enter a valid id", "Warning", System.Windows.Forms.MessageBoxButtons.OK); ;
                }
            }

       
    }

    
}