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
    public partial class SupervisorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupViewStudent.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupViewPrePublication.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupAddDE.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupEvalPR.aspx");
        }

        protected void viewpro_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupViewProfile.aspx");
        }

        protected void updateinfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupUpdateInfo.aspx");
        }

    }
}