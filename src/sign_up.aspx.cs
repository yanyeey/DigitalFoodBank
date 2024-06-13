using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_DFB
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Display field for Individual Donor
            if (RadioButtonListRole.SelectedValue == "Individual" && RadioButtonListType.SelectedValue == "Donor")
            {
                individualFields.Style["display"] = "block";
                organizationFields.Style["display"] = "none";
                IndividualRecipient.Style["display"] = "none";
                RecipientUpload.Style["display"] = "none";
            }
            // Display field for Individual Recipient
            else if (RadioButtonListRole.SelectedValue == "Individual" && RadioButtonListType.SelectedValue == "Recipient")
            {
                individualFields.Style["display"] = "block";
                organizationFields.Style["display"] = "none";
                IndividualRecipient.Style["display"] = "block";
                RecipientUpload.Style["display"] = "block";
            }
            // Display field for Organization Donor
            else if (RadioButtonListRole.SelectedValue == "Organization" && RadioButtonListType.SelectedValue == "Donor")
            {
                individualFields.Style["display"] = "none";
                organizationFields.Style["display"] = "block";
                IndividualRecipient.Style["display"] = "none";
                RecipientUpload.Style["display"] = "none";
            }
            // Display field for Organization Recipient
            else if (RadioButtonListRole.SelectedValue == "Organization" && RadioButtonListType.SelectedValue == "Recipient")
            {
                individualFields.Style["display"] = "none";
                organizationFields.Style["display"] = "block";
                IndividualRecipient.Style["display"] = "none";
                RecipientUpload.Style["display"] = "block";
            }

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            // Read donor count
            string query1 = "select count (*) from MEMBER where member_type = 'donor'";
            SqlCommand cmd1 = new SqlCommand(query1, dbconnection1); 

            // Read recipient count
            string query2 = "select count (*) from MEMBER where member_type = 'recipient'";
            SqlCommand cmd2 = new SqlCommand(query2, dbconnection1);


            // For new table with zero record
            // Donor
            int record_donor = Convert.ToInt32(cmd1.ExecuteScalar().ToString().Replace(" ", ""));
            if (record_donor < 1)
            {
                DonorCount.Text = "1";
            }
            else
            {
                int donor_count = record_donor + 1;
                DonorCount.Text = donor_count.ToString();
            }

            // Recipient
            int record_recipient = Convert.ToInt32(cmd2.ExecuteScalar().ToString().Replace(" ", ""));
            if (record_recipient < 1)
            {
                RecipientCount.Text = "1";
            }
            else
            {
                int recipient_count = record_recipient + 1;
                RecipientCount.Text = recipient_count.ToString();
            }
        }

        protected void RadioButtonListRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display field for Individual Donor
            if (RadioButtonListRole.SelectedValue == "Individual" && RadioButtonListType.SelectedValue == "Donor")
            {
                individualFields.Style["display"] = "block";
                organizationFields.Style["display"] = "none";
                IndividualRecipient.Style["display"] = "none";
                RecipientUpload.Style["display"] = "none";
            }
            // Display field for Individual Recipient
            else if (RadioButtonListRole.SelectedValue == "Individual" && RadioButtonListType.SelectedValue == "Recipient")
            {
                individualFields.Style["display"] = "block";
                organizationFields.Style["display"] = "none";
                IndividualRecipient.Style["display"] = "block";
                RecipientUpload.Style["display"] = "block";
            }
            // Display field for Organization Donor
            else if (RadioButtonListRole.SelectedValue == "Organization" && RadioButtonListType.SelectedValue == "Donor")
            {
                individualFields.Style["display"] = "none";
                organizationFields.Style["display"] = "block";
                IndividualRecipient.Style["display"] = "none";
                RecipientUpload.Style["display"] = "none";
            }
            // Display field for Organization Recipient
            else if (RadioButtonListRole.SelectedValue == "Organization" && RadioButtonListType.SelectedValue == "Recipient")
            {
                individualFields.Style["display"] = "none";
                organizationFields.Style["display"] = "block";
                IndividualRecipient.Style["display"] = "none";
                RecipientUpload.Style["display"] = "block";
            }
        }
        protected void RadioButtonListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display field for Individual Donor
            if (RadioButtonListRole.SelectedValue == "Individual" && RadioButtonListType.SelectedValue == "Donor")
            {
                individualFields.Style["display"] = "block";
                organizationFields.Style["display"] = "none";
                IndividualRecipient.Style["display"] = "none";
                RecipientUpload.Style["display"] = "none";
            }
            // Display field for Individual Recipient
            else if (RadioButtonListRole.SelectedValue == "Individual" && RadioButtonListType.SelectedValue == "Recipient")
            {
                individualFields.Style["display"] = "block";
                organizationFields.Style["display"] = "none";
                IndividualRecipient.Style["display"] = "block";
                RecipientUpload.Style["display"] = "block";
            }
            // Display field for Organization Donor
            else if (RadioButtonListRole.SelectedValue == "Organization" && RadioButtonListType.SelectedValue == "Donor")
            {
                individualFields.Style["display"] = "none";
                organizationFields.Style["display"] = "block";
                IndividualRecipient.Style["display"] = "none";
                RecipientUpload.Style["display"] = "none";
            }
            // Display field for Organization Recipient
            else if (RadioButtonListRole.SelectedValue == "Organization" && RadioButtonListType.SelectedValue == "Recipient")
            {
                individualFields.Style["display"] = "none";
                organizationFields.Style["display"] = "block";
                IndividualRecipient.Style["display"] = "none";
                RecipientUpload.Style["display"] = "block";
            }
        }

        protected void signup_button_Click(object sender, EventArgs e)
        {
            try
            {   
                // Open Database Connection
                SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection1.Open();

                string query1 = "select count(*) from MEMBER where member_email = '" + email.Text + "'";
                SqlCommand cmd1 = new SqlCommand(query1, dbconnection1);

                int check1 = Convert.ToInt32(cmd1.ExecuteScalar().ToString());

                // Check whether email is taken
                if (check1 > 0)
                {
                    LabelEmailTakenError.Visible = true;
                    LabelEmailTakenError.ForeColor = System.Drawing.Color.Red;
                    LabelEmailTakenError.Text = "This email has been registered.";
                }

                // Check whether password length is between 8 to 16 characters
                if (password.Text.Length < 8 || password.Text.Length > 16)
                {
                    LabelPasswordLengthError.Visible = true;
                    LabelPasswordLengthError.ForeColor = System.Drawing.Color.Red;
                    LabelPasswordLengthError.Text = "Password must be between 8 to 16 characters.";
                }

                // Check whether password input equals to confirm password input
                else if (password.Text != confirm_password.Text)
                {
                    LabelPasswordMatchError.Visible = true;
                    LabelPasswordMatchError.ForeColor = System.Drawing.Color.Red;
                    LabelPasswordMatchError.Text = "Password Does Not Match!";
                }

                // If input is valid
                if (check1 == 0 && DonorCount.Text != "" && RecipientCount.Text != ""
                    && contact_no.Text != "" && email.Text != "" && street_address.Text != ""
                    && postal_code.Text != "" && city.Text != "" && RegularExpressionValidatorEmail.IsValid
                    && password.Text.Length > 7 && password.Text.Length < 16 && password.Text == confirm_password.Text)
                {
                    // Signing up as Individual Donor
                    if (RadioButtonListRole.SelectedValue == "Individual" && RadioButtonListType.SelectedValue == "Donor")
                    {
                        if (individual_first_name.Text != "" && individual_last_name.Text != "")
                        {
                            // Create record in MEMBER table
                            string query3 = "insert into MEMBER (member_id, member_role, member_type, member_email, member_password) values (@id, @role, @type, @email, @password) ";
                            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                            cmd3.Parameters.AddWithValue("@id", "ID" + DonorCount.Text);
                            cmd3.Parameters.AddWithValue("@role", "individual");
                            cmd3.Parameters.AddWithValue("@type", "donor");
                            cmd3.Parameters.AddWithValue("@email", email.Text);
                            cmd3.Parameters.AddWithValue("@password", password.Text);
                            cmd3.ExecuteNonQuery();

                            // Create record in DONOR table
                            string query4 = "insert into DONOR (member_id, donor_first_name, donor_last_name, donor_contact_no, donor_street_address, donor_postal_code, donor_city, donor_state, donor_verified) values (@id, @first_name, @last_name, @contact_no, @street_address, @postal_code, @city, @state, @verified) ";
                            SqlCommand cmd4 = new SqlCommand(query4, dbconnection1);
                            cmd4.Parameters.AddWithValue("@id", "ID" + DonorCount.Text);
                            cmd4.Parameters.AddWithValue("@first_name", individual_first_name.Text);
                            cmd4.Parameters.AddWithValue("@last_name", individual_last_name.Text);
                            cmd4.Parameters.AddWithValue("@contact_no", contact_no.Text);
                            cmd4.Parameters.AddWithValue("@street_address", street_address.Text);
                            cmd4.Parameters.AddWithValue("@postal_code", postal_code.Text);
                            cmd4.Parameters.AddWithValue("@city", city.Text);
                            cmd4.Parameters.AddWithValue("@state", DropDownListState.SelectedValue);
                            cmd4.Parameters.AddWithValue("@verified", "No");
                            cmd4.ExecuteNonQuery();
                            dbconnection1.Close();

                            // Send Welcome Email
                            string recipientEmail = email.Text;
                            string subject = "Welcome to Digital Food Bank - Thank You for Signing Up!";
                            string body = "A warm welcome to you as a valued member of our community! Thank you for signing up with us. Your decision to join us is greatly appreciated, and we are excited to have you on board. <br><br> As a donor, your contributions will directly impact the lives of individuals and families facing food insecurity. We are grateful for your commitment to making a difference in the community. <br><br> As a recipient, we understand the importance of providing support during challenging times. We are here to assist you and ensure that you receive the necessary food assistance and support. Your well-being and satisfaction are of utmost importance to us, and we are dedicated to serving you with empathy and care. <br><br> At Digital Food Bank, we strive to create a supportive and inclusive environment for all our members. We encourage you to explore the resources and opportunities available to you as part of our community. If you have any questions, feedback, or specific needs, please don't hesitate to reach out to us. Our team is here to assist you and address any concerns you may have. <br><br> Once again, thank you for choosing to be a part of Digital Food Bank. We are excited to embark on this journey with you!";
                            SendEmail(recipientEmail, subject, body);

                            Response.Redirect("login.aspx");
                        }
                    }

                    // Signing up as Individual Recipient
                    else if (RadioButtonListRole.SelectedValue == "Individual" && RadioButtonListType.SelectedValue == "Recipient")
                    {
                        if (individual_first_name.Text != "" && individual_last_name.Text != ""
                            && identification_number.Text != "" && RecipientFileUpload.FileName != "")
                        {
                            // Create record in MEMBER table
                            string query3 = "insert into MEMBER (member_id, member_role, member_type, member_email, member_password) values (@id, @role, @type, @email, @password) ";
                            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                            cmd3.Parameters.AddWithValue("@id", "IR" + RecipientCount.Text);
                            cmd3.Parameters.AddWithValue("@role", "individual");
                            cmd3.Parameters.AddWithValue("@type", "recipient");
                            cmd3.Parameters.AddWithValue("@email", email.Text);
                            cmd3.Parameters.AddWithValue("@password", password.Text);
                            cmd3.ExecuteNonQuery();

                            // Create record in RECIPIENT table
                            string query4 = "insert into RECIPIENT (member_id, recipient_first_name, recipient_last_name, recipient_identification_no, recipient_identification_document, recipient_contact_no, recipient_street_address, recipient_postal_code, recipient_city, recipient_state, recipient_verified) values (@id, @first_name, @last_name, @identification_no, @identification_document, @contact_no, @street_address, @postal_code, @city, @state, @verified) ";
                            SqlCommand cmd4 = new SqlCommand(query4, dbconnection1);
                            cmd4.Parameters.AddWithValue("@id", "IR" + RecipientCount.Text);
                            cmd4.Parameters.AddWithValue("@first_name", individual_first_name.Text);
                            cmd4.Parameters.AddWithValue("@last_name", individual_last_name.Text);
                            cmd4.Parameters.AddWithValue("@identification_no", identification_number.Text);

                            // File Upload
                            string folderPath = Server.MapPath("~/Identification_Documents/");
                            RecipientFileUpload.SaveAs(folderPath + Path.GetFileName(RecipientFileUpload.FileName));
                            IdentificationImage.ImageUrl = "~/Identification_Documents/" + Path.GetFileName(RecipientFileUpload.FileName);
                            cmd4.Parameters.AddWithValue("@identification_document", IdentificationImage.ImageUrl);
                            
                            cmd4.Parameters.AddWithValue("@contact_no", contact_no.Text);
                            cmd4.Parameters.AddWithValue("@street_address", street_address.Text);
                            cmd4.Parameters.AddWithValue("@postal_code", postal_code.Text);
                            cmd4.Parameters.AddWithValue("@city", city.Text);
                            cmd4.Parameters.AddWithValue("@state", DropDownListState.SelectedValue);
                            cmd4.Parameters.AddWithValue("@verified", "No");
                            cmd4.ExecuteNonQuery();
                            dbconnection1.Close();

                            // Send Welcome Email
                            string recipientEmail = email.Text;
                            string subject = "Welcome to Digital Food Bank - Thank You for Signing Up!";
                            string body = "A warm welcome to you as a valued member of our community! Thank you for signing up with us. Your decision to join us is greatly appreciated, and we are excited to have you on board. <br><br> As a donor, your contributions will directly impact the lives of individuals and families facing food insecurity. We are grateful for your commitment to making a difference in the community. <br><br> As a recipient, we understand the importance of providing support during challenging times. We are here to assist you and ensure that you receive the necessary food assistance and support. Your well-being and satisfaction are of utmost importance to us, and we are dedicated to serving you with empathy and care. <br><br> At Digital Food Bank, we strive to create a supportive and inclusive environment for all our members. We encourage you to explore the resources and opportunities available to you as part of our community. If you have any questions, feedback, or specific needs, please don't hesitate to reach out to us. Our team is here to assist you and address any concerns you may have. <br><br> Once again, thank you for choosing to be a part of Digital Food Bank. We are excited to embark on this journey with you!";
                            SendEmail(recipientEmail, subject, body);

                            Response.Redirect("login.aspx");
                        }
                    }

                    // Signing up as Organization Donor
                    else if (RadioButtonListRole.SelectedValue == "Organization" && RadioButtonListType.SelectedValue == "Donor")
                    {
                        if (org_name.Text != "" && org_no.Text != "")
                        {
                            // Create record in MEMBER table
                            string query3 = "insert into MEMBER (member_id, member_role, member_type, member_email, member_password) values (@id, @role, @type, @email, @password) ";
                            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                            cmd3.Parameters.AddWithValue("@id", "OD" + DonorCount.Text);
                            cmd3.Parameters.AddWithValue("@role", "organization");
                            cmd3.Parameters.AddWithValue("@type", "donor");
                            cmd3.Parameters.AddWithValue("@email", email.Text);
                            cmd3.Parameters.AddWithValue("@password", password.Text);
                            cmd3.ExecuteNonQuery();

                            // Create record in DONOR table
                            string query4 = "insert into DONOR (member_id, donor_org_name, donor_org_no, donor_pic_name, donor_contact_no, donor_street_address, donor_postal_code, donor_city, donor_state, donor_verified) values (@id, @org_name, @org_no, @pic_name, @contact_no, @street_address, @postal_code, @city, @state, @verified) ";
                            SqlCommand cmd4 = new SqlCommand(query4, dbconnection1);
                            cmd4.Parameters.AddWithValue("@id", "OD" + DonorCount.Text);
                            cmd4.Parameters.AddWithValue("@org_name", org_name.Text);
                            cmd4.Parameters.AddWithValue("@org_no", org_no.Text);
                            cmd4.Parameters.AddWithValue("@pic_name", person_in_charge.Text);
                            cmd4.Parameters.AddWithValue("@contact_no", contact_no.Text);
                            cmd4.Parameters.AddWithValue("@street_address", street_address.Text);
                            cmd4.Parameters.AddWithValue("@postal_code", postal_code.Text);
                            cmd4.Parameters.AddWithValue("@city", city.Text);
                            cmd4.Parameters.AddWithValue("@state", DropDownListState.SelectedValue);
                            cmd4.Parameters.AddWithValue("@verified", "No");
                            cmd4.ExecuteNonQuery();
                            dbconnection1.Close();

                            // Send Welcome Email
                            string recipientEmail = email.Text;
                            string subject = "Welcome to Digital Food Bank - Thank You for Signing Up!";
                            string body = "A warm welcome to you as a valued member of our community! Thank you for signing up with us. Your decision to join us is greatly appreciated, and we are excited to have you on board. <br><br> As a donor, your contributions will directly impact the lives of individuals and families facing food insecurity. We are grateful for your commitment to making a difference in the community. <br><br> As a recipient, we understand the importance of providing support during challenging times. We are here to assist you and ensure that you receive the necessary food assistance and support. Your well-being and satisfaction are of utmost importance to us, and we are dedicated to serving you with empathy and care. <br><br> At Digital Food Bank, we strive to create a supportive and inclusive environment for all our members. We encourage you to explore the resources and opportunities available to you as part of our community. If you have any questions, feedback, or specific needs, please don't hesitate to reach out to us. Our team is here to assist you and address any concerns you may have. <br><br> Once again, thank you for choosing to be a part of Digital Food Bank. We are excited to embark on this journey with you!";
                            SendEmail(recipientEmail, subject, body);

                            Response.Redirect("login.aspx");
                        }
                    }

                    // Signing up as Organization Recipient
                    else if (RadioButtonListRole.SelectedValue == "Organization" && RadioButtonListType.SelectedValue == "Recipient")
                    {
                        if (org_name.Text != "" && org_no.Text != "" && person_in_charge.Text != "" && RecipientFileUpload.FileName != "")
                        {
                            // Create record in MEMBER table
                            string query3 = "insert into MEMBER (member_id, member_role, member_type, member_email, member_password) values (@id, @role, @type, @email, @password) ";
                            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                            cmd3.Parameters.AddWithValue("@id", "OR" + RecipientCount.Text);
                            cmd3.Parameters.AddWithValue("@role", "organization");
                            cmd3.Parameters.AddWithValue("@type", "recipient");
                            cmd3.Parameters.AddWithValue("@email", email.Text);
                            cmd3.Parameters.AddWithValue("@password", password.Text);
                            cmd3.ExecuteNonQuery();

                            // Create record in RECIPIENT table
                            string query4 = "insert into RECIPIENT (member_id, recipient_org_name, recipient_org_no, recipient_pic_name, recipient_identification_document, recipient_contact_no, recipient_street_address, recipient_postal_code, recipient_city, recipient_state, recipient_verified) values (@id, @org_name, @org_no, @pic_name, @identification_document, @contact_no, @street_address, @postal_code, @city, @state, @verified) ";
                            SqlCommand cmd4 = new SqlCommand(query4, dbconnection1);
                            cmd4.Parameters.AddWithValue("@id", "OR" + RecipientCount.Text);
                            cmd4.Parameters.AddWithValue("@org_name", org_name.Text);
                            cmd4.Parameters.AddWithValue("@org_no", org_no.Text);
                            cmd4.Parameters.AddWithValue("@pic_name", person_in_charge.Text);

                            // File Upload
                            string folderPath = Server.MapPath("~/Identification_Documents/");
                            RecipientFileUpload.SaveAs(folderPath + Path.GetFileName(RecipientFileUpload.FileName));
                            IdentificationImage.ImageUrl = "~/Identification_Documents/" + Path.GetFileName(RecipientFileUpload.FileName);
                            cmd4.Parameters.AddWithValue("@identification_document", IdentificationImage.ImageUrl);

                            cmd4.Parameters.AddWithValue("@contact_no", contact_no.Text);
                            cmd4.Parameters.AddWithValue("@street_address", street_address.Text);
                            cmd4.Parameters.AddWithValue("@postal_code", postal_code.Text);
                            cmd4.Parameters.AddWithValue("@city", city.Text);
                            cmd4.Parameters.AddWithValue("@state", DropDownListState.SelectedValue);
                            cmd4.Parameters.AddWithValue("@verified", "No");
                            cmd4.ExecuteNonQuery();
                            dbconnection1.Close();

                            // Send Welcome Email
                            string recipientEmail = email.Text;
                            string subject = "Welcome to Digital Food Bank - Thank You for Signing Up!";
                            string body = "A warm welcome to you as a valued member of our community! Thank you for signing up with us. Your decision to join us is greatly appreciated, and we are excited to have you on board. <br><br> As a donor, your contributions will directly impact the lives of individuals and families facing food insecurity. We are grateful for your commitment to making a difference in the community. <br><br> As a recipient, we understand the importance of providing support during challenging times. We are here to assist you and ensure that you receive the necessary food assistance and support. Your well-being and satisfaction are of utmost importance to us, and we are dedicated to serving you with empathy and care. <br><br> At Digital Food Bank, we strive to create a supportive and inclusive environment for all our members. We encourage you to explore the resources and opportunities available to you as part of our community. If you have any questions, feedback, or specific needs, please don't hesitate to reach out to us. Our team is here to assist you and address any concerns you may have. <br><br> Once again, thank you for choosing to be a part of Digital Food Bank. We are excited to embark on this journey with you!";
                            SendEmail(recipientEmail, subject, body);

                            Response.Redirect("login.aspx");
                        }
                    }
                    dbconnection1.Close();


                }
            }
            catch (Exception ex)
            {
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
                LabelErrorMessage.Text = "Registration not sucessful!" + ex.ToString();
                return;
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