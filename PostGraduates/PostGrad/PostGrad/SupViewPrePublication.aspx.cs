using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;

namespace PostGrad
{
    public partial class SupViewPrePublication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sid.Text))
            {
                string message = "Please enter valid information";
                string title = "Warning";
                MessageBox.Show(message, title);

            }
            else
            {
                Session["StudentId"] = sid.Text;
                Response.Redirect("SupViewPublication.aspx");

            }
        }
    }
}