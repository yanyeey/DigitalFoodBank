using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace FYP_DFB
{
    public partial class change_password : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Check the user's role
            if (Session["member_type"] != null)
            {
                if (Session["member_type"].ToString() == "admin")
                {
                    // Set the master page for admin
                    MasterPageFile = "~/Site.Admin.Master";
                }
                else
                {
                    // Set the default master page for normal members
                    MasterPageFile = "~/Site.Master";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection1.Open();

                SqlDataAdapter da1 = new SqlDataAdapter("select * from MEMBER where member_email = '" + Session["member_email"] + "'", dbconnection1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                member_id.Text = dt1.Rows[0][0].ToString();
                LabelOldPasswordCheck.Text = dt1.Rows[0][4].ToString();

                dbconnection1.Close();

            }
        }

        protected void save_button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconnection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection2.Open();

                if (old_password.Text != LabelOldPasswordCheck.Text)
                {
                    LabelOldPasswordIncorrect.Visible = true;
                    LabelOldPasswordIncorrect.ForeColor = System.Drawing.Color.Red;
                    LabelOldPasswordIncorrect.Text = "Old Password is Incorrect.";
                }

                if (new_password.Text.Length < 8 || new_password.Text.Length > 16)
                {
                    LabelPasswordLengthError.Visible = true;
                    LabelPasswordLengthError.ForeColor = System.Drawing.Color.Red;
                    LabelPasswordLengthError.Text = "Password must be between 8 and 16 characters.";
                }

                if (confirm_new_password.Text != new_password.Text)
                {
                    LabelPasswordMatchError.Visible = true;
                    LabelPasswordMatchError.ForeColor = System.Drawing.Color.Red;
                    LabelPasswordMatchError.Text = "Password Does Not Match!";
                }

                if (new_password.Text.Length > 7 && new_password.Text.Length < 17 && new_password.Text == confirm_new_password.Text)
                {
                    // Update First Table
                    string query1 = "update MEMBER set member_password = '" + new_password.Text + "' where member_id = '" + member_id.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(query1, dbconnection2);
                    cmd1.ExecuteNonQuery();
                    dbconnection2.Close();

                    if (Session["member_type"].ToString() == "donor" || Session["member_type"].ToString() == "recipient")
                    {
                        Response.Redirect("profile_member.aspx");
                    }

                    else if (Session["member_type"].ToString() == "admin")
                    {
                        Response.Redirect("profile_admin.aspx");
                    }

                    
                }
            }
            catch (Exception ex)
            {
                this.LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
                this.LabelErrorMessage.Text = "Failed to Update Password!" + ex.ToString();
                this.LabelErrorMessage.Visible = true;
                return;
            }






            if (Session["member_type"].ToString() == "donor")
            {

            }

            else if (Session["member_type"].ToString() == "recipient")
            {

            }

            else if (Session["member_type"].ToString() == "admin")
            {

            }
        }
    }
}