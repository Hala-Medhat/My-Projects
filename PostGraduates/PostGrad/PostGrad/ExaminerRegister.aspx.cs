﻿using System;
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
    public partial class ExaminerRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String fname = FName.Text;
            String lname = LName.Text;
            String email = Email.Text;
            String pass = Password.Text;

            String Work = work.Text ;
        
            bool nat = National.Checked;
            if (fname == "" | lname == "" | email == "" | pass == ""|Work=="")
            {
                System.Windows.Forms.MessageBox.Show("Invalid profile , You have to fill all fields", "Warning", System.Windows.Forms.MessageBoxButtons.OK);
                return;
            }


            SqlCommand regProc = new SqlCommand("examinerRegister", conn);
            regProc.CommandType = CommandType.StoredProcedure;

            regProc.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar)).Value = fname;
            regProc.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar)).Value = lname;
            regProc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = pass;
      
            regProc.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = email;
            regProc.Parameters.Add(new SqlParameter("@field", SqlDbType.VarChar)).Value = Work;
            regProc.Parameters.Add(new SqlParameter("@national", SqlDbType.Bit)).Value = nat;



            conn.Open();
            regProc.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("login.aspx");
        }
    }
    }
