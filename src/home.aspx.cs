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
    public partial class Default : Page
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
            if (Session["MessageBoxMessage"] != null)
            {
                string message = Session["MessageBoxMessage"].ToString();
                ShowMessageBox(message);
                Session["MessageBoxMessage"] = null;
            }

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            //read contact form count
            string query1 = "select count(*) from CONTACT_FORM";
            SqlCommand cmd1 = new SqlCommand(query1, dbconnection1);

            int record_contact = Convert.ToInt32(cmd1.ExecuteScalar().ToString().Replace(" ", ""));
            if (record_contact < 1)
            {
                FormCount.Text = "1";
            }
            else
            {
                int form_count = record_contact + 1;
                FormCount.Text = form_count.ToString();
            }

            dbconnection1.Close();
        }

        private void ShowMessageBox(string message)
        {
            string script = $@"<script type='text/javascript'>alert('{message}');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "MessageBox", script, false);
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconnection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection2.Open();

                if (Message.Text.Length < 10)
                {
                    LabelMessageLengthError.Visible = true;
                    LabelMessageLengthError.ForeColor = System.Drawing.Color.Red;
                    LabelMessageLengthError.Text = "Message must be more than 10 characters.";
                }
                else if (FormCount.Text != "" && Name.Text != "" && Email.Text != ""
                    && RegularExpressionValidatorEmail.IsValid && Subject.Text != ""
                    && Message.Text != "" && Message.Text.Length > 10)
                {
                    //create record in table
                    string query2 = "insert into CONTACT_FORM (contact_id, contact_name, contact_email, contact_subject, contact_message, contact_status) values (@id, @name, @email, @subject, @message, @status) ";
                    SqlCommand cmd2 = new SqlCommand(query2, dbconnection2);
                    cmd2.Parameters.AddWithValue("@id", "CF" + FormCount.Text);
                    cmd2.Parameters.AddWithValue("@name", Name.Text);
                    cmd2.Parameters.AddWithValue("@email", Email.Text);
                    cmd2.Parameters.AddWithValue("@subject", Subject.Text);
                    cmd2.Parameters.AddWithValue("@message", Message.Text);
                    cmd2.Parameters.AddWithValue("@status", "Pending");
                    cmd2.ExecuteNonQuery();
                }
                dbconnection2.Close();
            }

            catch (Exception ex)
            {
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
                LabelErrorMessage.Text = "Form submission not successful!" + ex.ToString();
                return;
            }
        }

    }
}
