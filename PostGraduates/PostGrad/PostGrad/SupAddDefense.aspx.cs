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
    public partial class SupAddDefense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            if (string.IsNullOrWhiteSpace(serialno.Text) || string.IsNullOrWhiteSpace(date.Text)|| string.IsNullOrWhiteSpace(location.Text))
            {
                string message = "Please enter valid information";
                string title = "Warning";
                MessageBox.Show(message, title);

            }
            else
            {

                int serialnum = Int32.Parse(serialno.Text);
                DateTime datee = DateTime.Parse(date.Text);
                String locationn = location.Text;
                bool guc = gucian.Checked;


                if (gucian.Checked == true)
                {

                    SqlCommand subdef = new SqlCommand("AddDefenseGucian", conn);
                    subdef.CommandType = CommandType.StoredProcedure;

                    subdef.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = serialnum;
                    subdef.Parameters.Add(new SqlParameter("@DefenseDate", SqlDbType.DateTime)).Value = datee;
                    subdef.Parameters.Add(new SqlParameter("@DefenseLocation", SqlDbType.VarChar)).Value = locationn;

                    try
                    {
                        conn.Open();
                        if (subdef.ExecuteNonQuery() == 0)
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
                    catch
                    {
                        serialno.Text = "";
                        MessageBox.Show("This Thesis Number dosen't exist", "Warning", MessageBoxButtons.OK);
                    }
                }
           
                else
                {
                    SqlCommand subdefnon = new SqlCommand("AddDefenseNonGucian", conn);
                    subdefnon.CommandType = CommandType.StoredProcedure;

                    subdefnon.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = serialnum;
                    subdefnon.Parameters.Add(new SqlParameter("@DefenseDate", SqlDbType.DateTime)).Value = datee;
                    subdefnon.Parameters.Add(new SqlParameter("@DefenseLocation", SqlDbType.VarChar)).Value = locationn;

                    try
                    {
                        conn.Open();
                        if (subdefnon.ExecuteNonQuery() == 0)
                        {
                            string message = "Wrong Informaton";
                            string title = "Warning";
                            MessageBox.Show(message, title);
                        }
                        else
                        {
                            string message = "Defense Added Succcessfully";
                            string title = "Confirmation";
                            MessageBox.Show(message, title);
                        }
                        conn.Close();
                    }
                    catch (SqlException ex)
                    {
                        serialno.Text = "";
                        MessageBox.Show("This Thesis Number dosen't exist", "Warning", MessageBoxButtons.OK);
                    }
            }
            }
        }
    }
}