using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

namespace FYP_DFB
{
    public partial class FoodDonationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DonateDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
            
            DateTime maxDate = DateTime.Today.AddMonths(2); // Set maximum date to 2 months from today
            DonateDate.Attributes["max"] = maxDate.ToString("yyyy-MM-dd");

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            // Read donation form count
            string query1 = "select count(*) from DONATION_FORM";
            SqlCommand cmd1 = new SqlCommand(query1, dbconnection1);

            int record_donation = Convert.ToInt32(cmd1.ExecuteScalar().ToString().Replace(" ", ""));
            if (record_donation < 1)
            {
                FormCount.Text = "1";
            }
            else
            {
                int form_count = record_donation + 1;
                FormCount.Text = form_count.ToString();
            }

            if (Session["member_email"] == null)
            {
                member_id = null;
            }
            else if (Session["member_email"] != null)
            {
                // Get member email
                SqlDataAdapter da1 = new SqlDataAdapter("select * from MEMBER where member_email = '" + Session["member_email"] + "'", dbconnection1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                member_id.Text = dt1.Rows[0][0].ToString();
            }

            dbconnection1.Close();

            if (Session["member_role"] != null)
            {
                if (Session["member_role"].ToString() == "individual")
                {
                    individualFields.Style["display"] = "block";
                    organizationFields.Style["display"] = "none";

                    // Disable the organization radio button
                    ListItem roleItem = RadioButtonListRole.Items.FindByValue("Organization");
                    if (roleItem != null)
                    {
                        roleItem.Enabled = false;
                    }

                    PopulateIndividualDetails();
                }

                else if (Session["member_role"].ToString() == "organization")
                {
                    individualFields.Style["display"] = "none";
                    organizationFields.Style["display"] = "block";

                    // Disable the individual radio button
                    ListItem roleItem = RadioButtonListRole.Items.FindByValue("Individual");
                    if (roleItem != null)
                    {
                        roleItem.Enabled = false;
                        ListItem organizationListItem = RadioButtonListRole.Items.FindByValue("Organization");
                        organizationListItem.Selected = true;
                    }

                    PopulateOrganizationDetails();
                }

                SetFieldsReadOnly();
            }

            if (verified.Text != "Yes")
            {
                pickup_service.Enabled = false;
            }
        }

        private void PopulateIndividualDetails()
        {
            email.Text = Session["member_email"].ToString();

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            // Display user details
            SqlDataAdapter da2 = new SqlDataAdapter("select * from DONOR where member_id = '" + member_id.Text + "'", dbconnection1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            individual_first_name.Text = dt2.Rows[0][1].ToString();
            individual_last_name.Text = dt2.Rows[0][2].ToString();
            contact_no.Text = dt2.Rows[0][6].ToString();
            street_address.Text = dt2.Rows[0][7].ToString();
            postal_code.Text = dt2.Rows[0][8].ToString();
            city.Text = dt2.Rows[0][9].ToString();
            DropDownListState.Text = dt2.Rows[0][10].ToString();
            verified.Text = dt2.Rows[0][11].ToString();

            dbconnection1.Close();
        }

        private void PopulateOrganizationDetails()
        {
            email.Text = Session["member_email"].ToString();

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            // Display user details
            SqlDataAdapter da2 = new SqlDataAdapter("select * from DONOR where member_id = '" + member_id.Text + "'", dbconnection1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            org_name.Text = dt2.Rows[0][3].ToString();
            org_num.Text = dt2.Rows[0][4].ToString();
            person_in_charge.Text = dt2.Rows[0][5].ToString();
            contact_no.Text = dt2.Rows[0][6].ToString();
            street_address.Text = dt2.Rows[0][7].ToString();
            postal_code.Text = dt2.Rows[0][8].ToString();
            city.Text = dt2.Rows[0][9].ToString();
            DropDownListState.Text = dt2.Rows[0][10].ToString();
            verified.Text = dt2.Rows[0][11].ToString();

            dbconnection1.Close();
        }

        private void SetFieldsReadOnly()
        {
            individual_first_name.ReadOnly = true;
            individual_last_name.ReadOnly = true;
            org_name.ReadOnly = true;
            org_num.ReadOnly = true;
            person_in_charge.ReadOnly = true;
            contact_no.ReadOnly = true;
            email.ReadOnly = true;
            street_address.ReadOnly = true;
            postal_code.ReadOnly = true;
            city.ReadOnly = true;
            DropDownListState.Enabled = false; // Disable dropdownlist
        }

        protected void RadioButtonListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonListRole.SelectedValue == "Individual") 
            {
                individualFields.Style["display"] = "block";
                organizationFields.Style["display"] = "none";
            }
            else if (RadioButtonListRole.SelectedValue == "Organization")
            {
                individualFields.Style["display"] = "none";
                organizationFields.Style["display"] = "block";
            }
        }

        protected void submit_button_Click(object sender, EventArgs e)
        {
            try
            {
                String pickup = "";

                if (pickup_service.Checked)
                {
                    pickup = "Yes";
                }
                else
                {
                    pickup = "No";
                }

                SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection1.Open();

                if (FormCount.Text != "" && contact_no.Text != "" 
                    && email.Text != "" && street_address.Text != "" && postal_code.Text != "" 
                    && city.Text != "" && RegularExpressionValidatorEmail.IsValid && !string.IsNullOrEmpty(DonateDate.Text))
                {
                    if (RadioButtonListRole.SelectedValue == "Individual")
                    {
                        if (individual_first_name.Text != "" && individual_last_name.Text != "")
                        {
                            // Create record in DONATION_FORM table
                            string query3 = "insert into DONATION_FORM (donation_id, donation_status, donation_role, donation_first_name, donation_last_name, donation_contact_no, donation_email, donation_street_address, donation_postal_code, donation_city, donation_state, donation_fruits_quantity, donation_vegetables_quantity, donation_dairy_egg_quantity, donation_meat_quantity, donation_seafood_quantity, donation_bread_cereal_quantity, donation_sweet_snack_quantity, donation_canned_quantity, donation_shelf_life, donation_date, donation_time, donation_message, donation_pickup_service) values (@donation_id, @status, @role, @first_name, @last_name, @contact_no, @email, @street_address, @postal_code, @city, @state, @fruits, @vegetables, @dairy_egg, @meat, @seafood, @bread_cereal, @sweet_snack, @canned, @shelf_life, @date, @time, @message, @pickup) ";
                            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                            cmd3.Parameters.AddWithValue("@donation_id", "DF" + FormCount.Text);
                            cmd3.Parameters.AddWithValue("@status", "In Progress");
                            cmd3.Parameters.AddWithValue("@role", "individual");
                            cmd3.Parameters.AddWithValue("@first_name", individual_first_name.Text);
                            cmd3.Parameters.AddWithValue("@last_name", individual_last_name.Text);
                            cmd3.Parameters.AddWithValue("@contact_no", contact_no.Text);
                            cmd3.Parameters.AddWithValue("@email", email.Text);
                            cmd3.Parameters.AddWithValue("@street_address", street_address.Text);
                            cmd3.Parameters.AddWithValue("@postal_code", postal_code.Text);
                            cmd3.Parameters.AddWithValue("@city", city.Text);
                            cmd3.Parameters.AddWithValue("@state", DropDownListState.SelectedValue);
                            cmd3.Parameters.AddWithValue("@fruits", Fruits_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@vegetables", Vegetables_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@dairy_egg", Dairy_and_Eggs_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@meat", Meat_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@seafood", Seafood_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@bread_cereal", Breads_and_Cereals_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@sweet_snack", Sweets_Snacks_Beverages_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@canned", Canned_Products_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@shelf_life", DropDownListShelfLife.SelectedValue);
                            cmd3.Parameters.AddWithValue("@date", DonateDate.Text);
                            cmd3.Parameters.AddWithValue("@time", DonateTime_DropDownList.SelectedValue);
                            cmd3.Parameters.AddWithValue("@message", other_messages_textbox.Text);
                            cmd3.Parameters.AddWithValue("@pickup", pickup);
                            cmd3.ExecuteNonQuery();

                            if (member_id != null)
                            {
                                string query4 = "update DONATION_FORM set donation_member_id = '" + member_id.Text + "' where donation_id = 'DF" + FormCount.Text + "'";
                                SqlCommand cmd4 = new SqlCommand(query4, dbconnection1); 
                                cmd4.ExecuteNonQuery();
                            }

                            dbconnection1.Close();
                        }
                    }

                    else if (RadioButtonListRole.SelectedValue == "Organization")
                    {
                        if (org_name.Text != "" && org_num.Text != "")
                        {
                            // Create record in DONATION_FORM table
                            string query3 = "insert into DONATION_FORM (donation_id, donation_status, donation_role, donation_org_name, donation_org_no, donation_pic_name, donation_contact_no, donation_email, donation_street_address, donation_postal_code, donation_city, donation_state, donation_fruits_quantity, donation_vegetables_quantity, donation_dairy_egg_quantity, donation_meat_quantity, donation_seafood_quantity, donation_bread_cereal_quantity, donation_sweet_snack_quantity, donation_canned_quantity, donation_shelf_life, donation_date, donation_time, donation_message, donation_pickup_service) values (@donation_id, @status, @role, @org_name, @org_no, @pic_name, @contact_no, @email, @street_address, @postal_code, @city, @state, @fruits, @vegetables, @dairy_egg, @meat, @seafood, @bread_cereal, @sweet_snack, @canned, @shelf_life, @date, @time, @message, @pickup) ";
                            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                            cmd3.Parameters.AddWithValue("@donation_id", "DF" + FormCount.Text);
                            cmd3.Parameters.AddWithValue("@status", "In Progress");
                            cmd3.Parameters.AddWithValue("@role", "organization");
                            cmd3.Parameters.AddWithValue("@org_name", org_name.Text);
                            cmd3.Parameters.AddWithValue("@org_no", org_num.Text);
                            cmd3.Parameters.AddWithValue("@pic_name", person_in_charge.Text);
                            cmd3.Parameters.AddWithValue("@contact_no", contact_no.Text);
                            cmd3.Parameters.AddWithValue("@email", email.Text);
                            cmd3.Parameters.AddWithValue("@street_address", street_address.Text);
                            cmd3.Parameters.AddWithValue("@postal_code", postal_code.Text);
                            cmd3.Parameters.AddWithValue("@city", city.Text);
                            cmd3.Parameters.AddWithValue("@state", DropDownListState.SelectedValue);
                            cmd3.Parameters.AddWithValue("@fruits", Fruits_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@vegetables", Vegetables_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@dairy_egg", Dairy_and_Eggs_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@meat", Meat_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@seafood", Seafood_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@bread_cereal", Breads_and_Cereals_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@sweet_snack", Sweets_Snacks_Beverages_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@canned", Canned_Products_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@shelf_life", DropDownListShelfLife.SelectedValue);
                            cmd3.Parameters.AddWithValue("@date", DonateDate.Text);
                            cmd3.Parameters.AddWithValue("@time", DonateTime_DropDownList.SelectedValue);
                            cmd3.Parameters.AddWithValue("@message", other_messages_textbox.Text);
                            cmd3.Parameters.AddWithValue("@pickup", pickup);
                            cmd3.ExecuteNonQuery();

                            if (member_id != null)
                            {
                                string query4 = "update DONATION_FORM set donation_member_id = '" + member_id.Text + "' where donation_id = 'DF" + FormCount.Text + "'";
                                SqlCommand cmd4 = new SqlCommand(query4, dbconnection1);
                                cmd4.ExecuteNonQuery();
                            }

                            dbconnection1.Close();
                        }
                    }

                    string recipientEmail = email.Text;
                    string subject = "Thank You for Your Donation Intent!";
                    string body = "We hope this email finds you well. <br>On behalf of Digital Food Bank, we would like to express our heartfelt appreciation for your generous intent to donate. Your willingness to support our cause and make a difference in the lives of those in need is truly commendable. <br> We would like to assure you that your donation intent has been received and noted. Should you have any specific instructions or requirements regarding your donation, please feel free to reach out to us. <br>Once again, we extend our sincere gratitude for your generosity and compassion. Together, we can make a significant difference in the lives of individuals and families in our community. We are incredibly grateful for your support.";
                    SendEmail(recipientEmail, subject, body);


                    Response.Redirect("food_donation_form.aspx");
                }
            }
            catch (Exception ex)
            {
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
                LabelErrorMessage.Text = "Form Submission not sucessful!" + ex.ToString();
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