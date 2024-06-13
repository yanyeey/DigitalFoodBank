using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace FYP_DFB
{
    public partial class volunteer_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DOB.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            //read volunteer form count
            string query1 = "select count(*) from VOLUNTEER_FORM";
            SqlCommand cmd1 = new SqlCommand(query1, dbconnection1);

            int record_volunteer = Convert.ToInt32(cmd1.ExecuteScalar().ToString().Replace(" ", ""));
            if (record_volunteer < 1)
            {
                FormCount.Text = "1";
            }
            else
            {
                int form_count = record_volunteer + 1;
                FormCount.Text = form_count.ToString();
            }

            dbconnection1.Close();
        }

        protected void InterestAreaValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Check if at least one item is selected in the CheckBoxList
            args.IsValid = InterestArea_CheckBoxList.SelectedItem != null;

            // Check if more than three items are selected
            if (InterestArea_CheckBoxList.Items.Cast<ListItem>().Count(li => li.Selected) > 3)
            {
                args.IsValid = false;
                InterestArea_Validator.Text = "Please select at most 3 options.";
            }
        }

        protected void PreferredDaysValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Check if at least one item is selected in the CheckBoxList
            args.IsValid = PreferredDays_CheckBoxList.SelectedItem != null;
        }

        protected void submit_button_Click(object sender, EventArgs e)
        {
            // If the CheckBoxList is valid
            if (Page.IsValid)
            {
                try
                {
                    SqlConnection dbconnection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    dbconnection2.Open();

                    if (FormCount.Text != "" && individual_first_name.Text != "" && individual_last_name.Text != ""
                        && DOB.Text != "" && contact_no.Text != "" && email.Text != "" && city.Text != ""
                        && RegularExpressionValidatorEmail.IsValid)
                    {

                        String str_days = "";
                        for (int idays = 0; idays <= PreferredDays_CheckBoxList.Items.Count - 1; idays++)
                        {
                            if (PreferredDays_CheckBoxList.Items[idays].Selected)
                            {
                                if (str_days == "")
                                {
                                    str_days = PreferredDays_CheckBoxList.Items[idays].Value;
                                }
                                else
                                {
                                    str_days += ", " + PreferredDays_CheckBoxList.Items[idays].Value;
                                }
                            }
                        }

                        String str_areas = "";
                        for (int iareas = 0; iareas <= InterestArea_CheckBoxList.Items.Count - 1; iareas++)
                        {
                            if (InterestArea_CheckBoxList.Items[iareas].Selected)
                            {
                                if (str_areas == "")
                                {
                                    str_areas = InterestArea_CheckBoxList.Items[iareas].Value;
                                }
                                else
                                {
                                    str_areas += ", " + InterestArea_CheckBoxList.Items[iareas].Value;
                                }
                            }
                        }
                        //create record in table
                        string query2 = "insert into VOLUNTEER_FORM (volunteer_id, volunteer_first_name, volunteer_last_name, volunteer_gender, volunteer_dob, volunteer_contact_no, volunteer_email, volunteer_city, volunteer_state, volunteer_preferred_days, volunteer_interest_area, volunteer_message) values (@id, @first_name, @last_name, @gender, @dob, @contact_no, @email, @city, @state, @preferred_days, @interest_area, @message) ";
                        SqlCommand cmd2 = new SqlCommand(query2, dbconnection2);
                        cmd2.Parameters.AddWithValue("@id", "VF" + FormCount.Text);
                        cmd2.Parameters.AddWithValue("@first_name", individual_first_name.Text);
                        cmd2.Parameters.AddWithValue("@last_name", individual_last_name.Text);
                        cmd2.Parameters.AddWithValue("@gender", RadioButtonListType.SelectedItem.ToString());
                        cmd2.Parameters.AddWithValue("@dob", DOB.Text);
                        cmd2.Parameters.AddWithValue("@contact_no", contact_no.Text);
                        cmd2.Parameters.AddWithValue("@email", email.Text);
                        cmd2.Parameters.AddWithValue("@city", city.Text);
                        cmd2.Parameters.AddWithValue("@state", DropDownListState.SelectedValue);
                        cmd2.Parameters.AddWithValue("@preferred_days", str_days);
                        cmd2.Parameters.AddWithValue("@interest_area", str_areas);
                        cmd2.Parameters.AddWithValue("@message", other_messages_textbox.Text);
                        cmd2.ExecuteNonQuery();
                        dbconnection2.Close();

                        string recipientEmail = email.Text;
                        string subject = "Thank You for Expressing Interest in Volunteering!";
                        string body = "Dear " + individual_last_name.Text + ", <br>" + "<br>We hope this email finds you well. On behalf of Digital Food Bank, we would like to extend our heartfelt gratitude for your interest in volunteering with us. <br>Your willingness to contribute your time and skills towards our cause is greatly appreciated. We want to assure you that your interest in volunteering has not gone unnoticed. <br> Our team is currently reviewing your application and matching it with suitable volunteer opportunities. We understand the importance of your time and are working diligently to find the best fit for your skills and interests.";
                        SendEmail(recipientEmail, subject, body);
                    }
                    Response.Redirect("volunteer_form.aspx");
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