using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_DFB
{
    public partial class compose_email : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }
        protected void SendtoValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Check if at least one item is selected in the CheckBoxList
            args.IsValid = Sendto_CheckBoxList.SelectedItem != null;
        }

        protected void submit_button_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    connection.Open();

                    if (Sendto_CheckBoxList.SelectedItem.Value == "donor")
                    {
                        string query = "SELECT member_email FROM MEMBER where member_type = 'donor'";
                        SqlCommand command = new SqlCommand(query, connection);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string email = reader["member_email"].ToString();

                                // Send email to the retrieved email address
                                string recipientEmail = email;
                                string subject = email_subject.Text;
                                string body = email_body.Text;
                                SendEmail(recipientEmail, subject, body);
                            }
                        }
                    }
                    else if (Sendto_CheckBoxList.SelectedItem.Value == "recipient")
                    {
                        string query = "SELECT member_email FROM MEMBER where member_type = 'recipient'";
                        SqlCommand command = new SqlCommand(query, connection);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string email = reader["member_email"].ToString();

                                // Send email to the retrieved email address
                                string recipientEmail = email;
                                string subject = email_subject.Text;
                                string body = email_body.Text;
                                SendEmail(recipientEmail, subject, body);
                            }
                        }
                    }
                    else if (Sendto_CheckBoxList.SelectedItem.Value == "all_volunteer")
                    {
                        string query = "SELECT volunteer_email FROM VOLUNTEER_FORM";
                        SqlCommand command = new SqlCommand(query, connection);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string email = reader["member_email"].ToString();

                                // Send email to the retrieved email address
                                string recipientEmail = email;
                                string subject = email_subject.Text;
                                string body = email_body.Text;
                                SendEmail(recipientEmail, subject, body);
                            }
                        }
                    }

                    connection.Close();
                }
            }
        }

        protected void SendEmail(string recipientEmail, string subject, string body)
        {
            // Create a new MailMessage
            MailMessage message = new MailMessage();

            // Set the sender email address
            message.From = new MailAddress("dfb.digitalfoodbank@gmail.com");

            // Set the recipient email address
            message.To.Add(new MailAddress(recipientEmail));

            // Set the email subject
            message.Subject = subject;

            // Set the email body
            message.IsBodyHtml = true;
            message.Body = body;

            // Create a new SmtpClient and set its properties
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("dfb.digitalfoodbank@gmail.com", "slboacdmrjuzkajs");

            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred while sending the email: " + ex.Message);
            }

        }
    }
}