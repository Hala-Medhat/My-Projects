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
    public partial class AddDefense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void add(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

           
            
            //TextBox2.Text = reader.Item("TextBox2").ToString();
           

            SqlCommand add = new SqlCommand("AddDefenseGrade", conn);
            add.CommandType = CommandType.StoredProcedure;

            if (TextBox1.Text.Length == 0)
            {
                Label1.Text = "TEXT BOX IS EMPTY";

            }
            else if (String.IsNullOrEmpty(TextBox2.Text))
            {
                Label3.Text = "TEXT BOX IS EMPTY";
            }
            
            else if (String.IsNullOrEmpty(TextBox3.Text))
            {
                Label2.Text = "TEXT BOX IS EMPTY";
            }
            else
            {
                int grade = Int32.Parse(TextBox3.Text);
                DateTime dateof = Convert.ToDateTime(TextBox2.Text);
                var sqlDate = dateof.Date.ToString("yyyy-MM-dd HH:mm:ss");
                int thesis = Int32.Parse(TextBox1.Text);
                add.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = thesis;
                add.Parameters.Add(new SqlParameter("@grade", SqlDbType.Int)).Value = grade;
                add.Parameters.Add(new SqlParameter("@DefenseDate", SqlDbType.DateTime)).Value = sqlDate;

                conn.Open();
                add.ExecuteNonQuery();
                conn.Close();
             
                Response.Redirect("ExaminerView.aspx");

            }

        }
    }
}