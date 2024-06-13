using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_DFB
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            SqlCommand cmd1 = new SqlCommand("select count(*) from MEMBER where member_email = '"
                + email.Text + "' and member_password = '" + password.Text + "'", dbconnection1);
            int count = Convert.ToInt32(cmd1.ExecuteScalar().ToString());

            if (count > 0)
            {
                //Get member type
                SqlCommand cmd2 = new SqlCommand("select member_type from MEMBER where member_email = '" +
                    email.Text + "'", dbconnection1);

                //Get member role
                SqlCommand cmd3 = new SqlCommand("select member_role from MEMBER where member_email = '" +
                    email.Text + "'", dbconnection1);

                //Get member id
                SqlCommand cmd4 = new SqlCommand("select member_id from MEMBER where member_email = '" +
                    email.Text + "'", dbconnection1);

                string type = cmd2.ExecuteScalar().ToString().Replace(" ", "");
                string role = cmd3.ExecuteScalar().ToString().Replace(" ", "");
                string member_id = cmd4.ExecuteScalar().ToString().Replace(" ", "");

                string member_email = email.Text;
                Session["member_id"] = member_id;
                Session["member_email"] = member_email;
                Session["member_type"] = type;
                Session["member_role"] = role;

                if (type == "admin")
                {
                    Session["member_type"] = "admin";
                    Response.Redirect("profile_admin.aspx");
                }
                else if (type == "donor")
                {
                    Session["member_type"] = "donor";
                    Response.Redirect("home.aspx");
                }
                else if (type == "recipient")
                {
                    Session["member_type"] = "recipient";
                    Response.Redirect("home.aspx");
                }
            }
            else
            {
                this.LabelFeedback.ForeColor = System.Drawing.Color.Red;
                this.LabelFeedback.Text = "Login Failed!";
                this.LabelFeedback.Visible = true;
                return;
            }
            dbconnection1.Close();
        }
    }
}