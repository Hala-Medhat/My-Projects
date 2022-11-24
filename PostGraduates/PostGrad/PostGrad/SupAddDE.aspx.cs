using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostGrad
{
    public partial class SupAddDE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupAddDefense.aspx");
        }

       

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("SupAddExaminer.aspx");
        }
    }
}