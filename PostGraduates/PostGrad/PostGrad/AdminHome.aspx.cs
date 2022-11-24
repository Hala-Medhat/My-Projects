using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostGrad
{
    public partial class AdminHome : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Theses(object sender, EventArgs e)
        {
            Response.Redirect("ListTheses.aspx");
        }
        protected void Payment(object sender, EventArgs e)
        {
            Response.Redirect("IssueThesisPayment.aspx");
        }
        protected void Installment(object sender, EventArgs e)
        {
            Response.Redirect("IssueInstallment.aspx");
        }
        protected void Supervisors(object sender, EventArgs e)
        {
            Response.Redirect("ListSupervisors.aspx");
        }
        protected void ThesisExtensions(object sender, EventArgs e)
        {
            Response.Redirect("ThesisExtensions.aspx");
        }

    }
}