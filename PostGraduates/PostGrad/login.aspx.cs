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

            int id = Int32.Parse(email.Text);
            String pass = password.Text;

            SqlCommand loginProc = new SqlCommand("userlogin", conn);
            loginProc.CommandType = CommandType.StoredProcedure;

            loginProc.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            loginProc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = pass;


            SqlParameter sucess = loginProc.Parameters.Add("@success", SqlDbType.Bit);
            SqlParameter type = loginProc.Parameters.Add("@type", SqlDbType.Int);
            sucess.Direction = System.Data.ParameterDirection.Output;

            conn.Open();
            loginProc.ExecuteNonQuery();
            conn.Close();
            if (sucess.Value.ToString() == "True")
            {
                Session["UserId"] = id;
                if (Int32.Parse(type.Value.ToString()) == 0)
                { }
                else
                {
                    if (Int32.Parse(type.Value.ToString()) == 4)
                    { }
                    else
                    {
                        if (Int32.Parse(type.Value.ToString()) == 1)
                        { }
                        else
                        {
                            if (Int32.Parse(type.Value.ToString()) == 2)
                            { }
                            else
                            {

                            }
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