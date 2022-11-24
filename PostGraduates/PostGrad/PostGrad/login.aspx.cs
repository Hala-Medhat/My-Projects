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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String ema = email.Text;
            String pass = password.Text;

            SqlCommand loginProc = new SqlCommand("userlogin", conn);
            loginProc.CommandType = CommandType.StoredProcedure;

            loginProc.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = ema;
            loginProc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = pass;


            SqlParameter sucess = loginProc.Parameters.Add("@success", SqlDbType.Bit);
            SqlParameter type = loginProc.Parameters.Add("@type", SqlDbType.Int);
            SqlParameter id = loginProc.Parameters.Add("@id", SqlDbType.Int);
            sucess.Direction = System.Data.ParameterDirection.Output;
            type.Direction = System.Data.ParameterDirection.Output;
            id.Direction = System.Data.ParameterDirection.Output;

            conn.Open();
            loginProc.ExecuteNonQuery();
            conn.Close();
            if (sucess.Value.ToString() == "True")
            {
                Session["UserId"] = id.Value;
                Session["Email"] = ema;
                Session["Password"] = pass;
                if (Int32.Parse(type.Value.ToString()) == 0)
                {
                    Response.Redirect("StudentHomePage.aspx");
                }
                else
                { 
                    if (Int32.Parse(type.Value.ToString()) == 1)
                    { Response.Redirect("AdminHome.aspx"); }
                    else
                    {
                        if (Int32.Parse(type.Value.ToString()) == 2)
                        {
                            Response.Redirect("SupervisorPage.aspx");
                        }
                        else
                        {
                            Response.Redirect("ExaminerView.aspx");
                        }
                    }
                    }
                }
            else
            {
                Response.Write("<script>alert('Incorrect email or password!');Window.location='login.aspx';</script>");

            }

        }
        protected void register(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}