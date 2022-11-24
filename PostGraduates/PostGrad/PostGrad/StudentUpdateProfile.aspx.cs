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
    public partial class StudentUpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            first.Attributes.Add("value",Session["FistName"].ToString());
            last.Attributes.Add("value", Session["LastName"].ToString());
            address.Attributes.Add("value", Session["Address"].ToString());
           
           



        }

        protected void Submit(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String fn =first.Text;
            String ln =last.Text;
            String add = address.Text;
            String type = DropDownList1.SelectedItem.Text;
	    if(fn=="" | ln == "" | add == "")
            {
                
                System.Windows.Forms.MessageBox.Show("Can't enter null values", "Warning", System.Windows.Forms.MessageBoxButtons.OK);
                Response.Redirect("StudentUpdateProfile.aspx");
            }
            SqlCommand check = new SqlCommand("checkType", conn);
            check.CommandType = CommandType.StoredProcedure;
            check.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = Session["UserId"];
            if (type=="NAN")
            {
                check.Parameters.AddWithValue("@type", DBNull.Value);
            }
           else
            {
                check.Parameters.Add(new SqlParameter("@type", SqlDbType.VarChar)).Value = type;
            }
            SqlParameter sucess = check.Parameters.Add("@sucess", SqlDbType.Bit);
            sucess.Direction = System.Data.ParameterDirection.Output;
            conn.Open();
            check.ExecuteNonQuery();
            conn.Close();


            if (sucess.Value.ToString()=="True")
            {
                SqlCommand Edit = new SqlCommand("editMyProfile", conn);
                Edit.CommandType = CommandType.StoredProcedure;

                Edit.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = Session["UserId"];
                Edit.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar)).Value = fn;
                Edit.Parameters.Add(new SqlParameter("@lastName ", SqlDbType.VarChar)).Value = ln;
                Edit.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = Session["Password"];
                Edit.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar)).Value = add;
                Edit.Parameters.Add(new SqlParameter("@type", SqlDbType.VarChar)).Value = type;
                Edit.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = Session["Email"];
                conn.Open();
                Edit.ExecuteNonQuery();
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Profile Updated Successfully ", "Confirmation", System.Windows.Forms.MessageBoxButtons.OK);
                Response.Redirect("StudentProfile.aspx");
                
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Can't change your type ", "Warning", System.Windows.Forms.MessageBoxButtons.OK);
                Response.Redirect("StudentUpdateProfile.aspx");
            }
        }

        protected void Close(object sender, EventArgs e)
        {
            Response.Redirect("StudentProfile.aspx");
        }

        
    }
}