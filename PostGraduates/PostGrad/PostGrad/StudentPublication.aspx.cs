using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PostGrad
{
    public partial class StudentPublication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
    }

        protected void Button1_Click(object sender, EventArgs e)

          
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String tit = title.Text;
            String d =date.Text ;
            String h = host.Text;
            String p = place.Text;
            bool a = accepted.Checked;
            if(tit=="" | d=="" | h=="" | p == "")
            {
                System.Windows.Forms.MessageBox.Show("Invalid publication , You have to fill all fields", "Warning", System.Windows.Forms.MessageBoxButtons.OK);
                return;
            }

            SqlCommand pub = new SqlCommand("addPublication", conn);
            pub.CommandType = CommandType.StoredProcedure;

            pub.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar)).Value = tit;
            pub.Parameters.Add(new SqlParameter("@pubDate", SqlDbType.DateTime)).Value = d;
            pub.Parameters.Add(new SqlParameter("@host", SqlDbType.VarChar)).Value = h;
            pub.Parameters.Add(new SqlParameter("@place", SqlDbType.VarChar)).Value = p;
            pub.Parameters.Add(new SqlParameter("@accepted", SqlDbType.Bit)).Value = a;
            SqlParameter id = pub.Parameters.Add("@id", SqlDbType.Int);
            id.Direction = System.Data.ParameterDirection.Output;
            conn.Open();
            pub.ExecuteNonQuery();
            conn.Close();


            SqlCommand add = new SqlCommand("linkPubThesis", conn);
             add.CommandType = CommandType.StoredProcedure;



             add.Parameters.Add(new SqlParameter("@PubID", SqlDbType.Int)).Value = id.Value;
             add.Parameters.Add(new SqlParameter("@thesisSerialNo", SqlDbType.Int)).Value = Session["ThesisInUse"];


                
                 conn.Open();
                 add.ExecuteNonQuery();
                 conn.Close();
            

            System.Windows.Forms.MessageBox.Show("Publication Added Successfully", "Confirmation", System.Windows.Forms.MessageBoxButtons.OK);
            Response.Redirect("StudentPublication.aspx");
          

            
            

        }
    }
}