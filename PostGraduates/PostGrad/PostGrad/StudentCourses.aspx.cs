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
    public partial class StudentCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand course = new SqlCommand("ViewCoursesGrades", conn);
            course.CommandType = CommandType.StoredProcedure;

            course.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = (Session["UserId"]);


            conn.Open();
            course.ExecuteNonQuery();
            SqlDataReader rdr = course.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable tb = new DataTable();
            DataRow dr;
            tb.Columns.Add("Course_Code", typeof(string));
            tb.Columns.Add("Credit_Hours", typeof(int));
            tb.Columns.Add("Grade", typeof(string));

            while (rdr.Read())
            {
                String code = rdr.GetString(rdr.GetOrdinal("code"));
                int credit = rdr.GetInt32(rdr.GetOrdinal("creditHours"));
                decimal grade;
                String g = "NAN";

                dr = tb.NewRow();
                dr["Course_Code"] = code;
                dr["Credit_Hours"] = credit;
                if (!rdr.IsDBNull(rdr.GetOrdinal("grade")))
                {
                    grade = rdr.GetDecimal(rdr.GetOrdinal("grade"));
                    g = grade.ToString();

                }

                dr["Grade"] = g;
                tb.Rows.Add(dr);
            }
            GridView1.DataSource = tb;
            GridView1.DataBind();
            ViewState["table"] = tb;
        }
    }
}