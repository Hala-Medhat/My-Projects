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
    public partial class SupEvalPR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (string.IsNullOrWhiteSpace(supid.Text) || string.IsNullOrWhiteSpace(tsn.Text) || string.IsNullOrWhiteSpace(prn.Text) || string.IsNullOrWhiteSpace(eval.Text))
            {
                string message = "Please enter valid information";
                string title = "Warning";
                MessageBox.Show(message, title);

            }
            else
            {

                int id = Int32.Parse(supid.Text);
                int thesisSN = Int32.Parse(tsn.Text);
                int progressRN = Int32.Parse(prn.Text);
                int evalluation = Int32.Parse(eval.Text);

                SqlCommand evalpr = new SqlCommand("EvaluateProgressReport", conn);
                evalpr.CommandType = CommandType.StoredProcedure;

                evalpr.Parameters.Add(new SqlParameter("@supervisorID", SqlDbType.Int)).Value = id;
                evalpr.Parameters.Add(new SqlParameter("@thesisSerialNo", SqlDbType.Int)).Value = thesisSN;
                evalpr.Parameters.Add(new SqlParameter("@progressReportNo", SqlDbType.Int)).Value = progressRN;
                evalpr.Parameters.Add(new SqlParameter("@evaluation", SqlDbType.Int)).Value = evalluation;

                try
                {
                    conn.Open();
                    evalpr.ExecuteNonQuery();
                    string message = "Evaluated Succcessfully";
                    string title = "Confirmation";
                    MessageBox.Show(message, title);

                    conn.Close();
                }
                catch (SqlException ex)
                {

                    tsn.Text = "";
                    MessageBox.Show("This Thesis Number dosen't exist", "Warning", MessageBoxButtons.OK);
                }
            }

            }
        

        protected void Button2_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (string.IsNullOrWhiteSpace(tsn2.Text))
            {
                string message = "Please enter valid information";
                string title = "Warning";
                MessageBox.Show(message, title);

            }
            else
            {
                int thesisSN = Int32.Parse(tsn2.Text);

                SqlCommand canthe = new SqlCommand("CancelThesis", conn);
                canthe.CommandType = CommandType.StoredProcedure;

                canthe.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = thesisSN;

                try
                {
                    conn.Open();
                    canthe.ExecuteNonQuery();
                        string message = "Canceled Succcessfully";
                        string title = "Confirmation";
                        MessageBox.Show(message, title);
                   
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    tsn2.Text = "";
                    MessageBox.Show("Wrong Serial number or can't cancel such thesis", "Warning", MessageBoxButtons.OK);
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (string.IsNullOrWhiteSpace(tsn2.Text))
            {
                string message = "Please enter valid information";
                string title = "Warning";
                MessageBox.Show(message, title);

            }
            else
            {

                int thesisSN = Int32.Parse(tsn2.Text);

                SqlCommand addgrade = new SqlCommand("AddGrade", conn);
                addgrade.CommandType = CommandType.StoredProcedure;

                addgrade.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = thesisSN;

                try
                {
                    conn.Open();
                    if (addgrade.ExecuteNonQuery() == 0)
                    {
                        string message = "Wrong Informaton";
                        string title = "Warning";
                        MessageBox.Show(message, title);
                    }
                    else
                    {
                        string message = "Grade Added Succcessfully";
                        string title = "Confirmation";
                        MessageBox.Show(message, title);
                    }
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    tsn2.Text = "";
                    MessageBox.Show("This Thesis Number dosen't exist", "Warning", MessageBoxButtons.OK);
                }
            }
        }
    }
}