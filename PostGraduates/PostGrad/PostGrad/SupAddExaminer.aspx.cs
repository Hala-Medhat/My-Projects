using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;

namespace PostGrad
{
    public partial class SupAddExaminer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (string.IsNullOrWhiteSpace(tsn.Text) || string.IsNullOrWhiteSpace(dd.Text) || string.IsNullOrWhiteSpace(en.Text) || string.IsNullOrWhiteSpace(fow.Text) || string.IsNullOrWhiteSpace(p.Text))
            {
                string message = "Please enter valid information";
                string title = "Warning";
                MessageBox.Show(message, title);

            }
            else
            {

                int thesisserialnum = Int32.Parse(tsn.Text);
                String defensedate = dd.Text;
                String exname = en.Text;
                String work = fow.Text;
                String pass = p.Text;
                bool nat = national.Checked;

                SqlCommand addex = new SqlCommand("AddExaminer", conn);
                addex.CommandType = CommandType.StoredProcedure;

                addex.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = thesisserialnum;
                addex.Parameters.Add(new SqlParameter("@DefenseDate", SqlDbType.DateTime)).Value = defensedate;
                addex.Parameters.Add(new SqlParameter("@ExaminerName", SqlDbType.VarChar)).Value = exname;
                addex.Parameters.Add(new SqlParameter("@fieldOfWork", SqlDbType.VarChar)).Value = work;
                addex.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar)).Value = pass;
                addex.Parameters.Add(new SqlParameter("@National", SqlDbType.Bit)).Value = nat;
                try
                {
                    conn.Open();
                    if (addex.ExecuteNonQuery() == 0)
                    {
                        string message = "Wrong Informaton";
                        string title = "Warning";
                        MessageBox.Show(message, title);
                    }
                    else
                    {
                        string message = "Examiner Added Succcessfully";
                        string title = "Confirmation";
                        MessageBox.Show(message, title);
                    }
                    conn.Close();
                }
                catch(SqlException ex)
                {
                    tsn.Text = "";
                    MessageBox.Show("This Thesis Number dosen't exist", "Warning", MessageBoxButtons.OK);
                }
            }
        }
    }
}