using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Net.Mail;
using System.Net;

namespace FYP_DFB
{
    public partial class details_donation_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!IsPostBack)
            {
                if (Request.QueryString["donationID"] != null && Request.QueryString["memberID"] != null)
                {
                    string donationID = Request.QueryString["donationID"];
                    string donationEmail = Request.QueryString["donationEmail"];

                    form_id.Text = donationID;
                    email.Text = donationEmail;

                    SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    dbconnection1.Open();

                    SqlDataAdapter da6 = new SqlDataAdapter("SELECT donation_role FROM DONATION_FORM where donation_id = '" + donationID + "'", dbconnection1);
                    DataTable dt6 = new DataTable();
                    da6.Fill(dt6);
                    donation_role.Text = dt6.Rows[0]["donation_role"].ToString();

                    if (donation_role.Text == "individual")
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

                    else if (donation_role.Text == "organization")
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

                else
                {
                    Response.Redirect("manage_donation_form.aspx");
                }
            }
        }

        private void PopulateIndividualDetails()
        {
            string donationID = Request.QueryString["donationID"];
            string memberID = Request.QueryString["memberID"];

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            if (memberID != "")
            {
                SqlDataAdapter da5 = new SqlDataAdapter("select * from MEMBER where member_id = '" + memberID + "'", dbconnection1);
                DataTable dt5 = new DataTable();
                da5.Fill(dt5);
                email.Text = dt5.Rows[0][3].ToString();

                SqlDataAdapter da6 = new SqlDataAdapter("select * from DONOR where member_id = '" + memberID + "'", dbconnection1);
                DataTable dt6 = new DataTable();
                da6.Fill(dt6);
                verified.Text = dt6.Rows[0][11].ToString();
            }

            // Display record from second table
            SqlDataAdapter da2 = new SqlDataAdapter("select * from DONATION_FORM where donation_id = '" + donationID + "'", dbconnection1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            status.Text = dt2.Rows[0][2].ToString();
            individual_first_name.Text = dt2.Rows[0][4].ToString();
            individual_last_name.Text = dt2.Rows[0][5].ToString();
            contact_no.Text = dt2.Rows[0][9].ToString();
            street_address.Text = dt2.Rows[0][11].ToString();
            postal_code.Text = dt2.Rows[0][12].ToString();
            city.Text = dt2.Rows[0][13].ToString();
            DropDownListState.Text = dt2.Rows[0][14].ToString();
            Fruits_Quantity.Text = dt2.Rows[0][15].ToString();
            Vegetables_Quantity.Text = dt2.Rows[0][16].ToString();
            Dairy_and_Eggs_Quantity.Text = dt2.Rows[0][17].ToString();
            Meat_Quantity.Text = dt2.Rows[0][18].ToString();
            Seafood_Quantity.Text = dt2.Rows[0][19].ToString();
            Breads_and_Cereals_Quantity.Text = dt2.Rows[0][20].ToString();
            Sweets_Snacks_Beverages_Quantity.Text = dt2.Rows[0][21].ToString();
            Canned_Products_Quantity.Text = dt2.Rows[0][22].ToString();
            DropDownListShelfLife.Text = dt2.Rows[0][23].ToString();
            DisplayDate.Text = Convert.ToDateTime(dt2.Rows[0][24]).ToShortDateString();
            DonateTime_DropDownList.Text = dt2.Rows[0][25].ToString();
            other_messages_textbox.Text = dt2.Rows[0][26].ToString();
            string pickupService = dt2.Rows[0][27].ToString();

            dbconnection1.Close();

            if (pickupService == "Yes")
            {
                pickup_service.Checked = true;
            }
            else
            {
                pickup_service.Checked = false;
            }

            if (status.Text == "Confirmed" || pickup_service.Checked == false)
            {
                confirmButton.Visible = false;
            }
            
            if (status.Text == "Closed" || status.Text == "Completed" || status.Text == "Cancelled")
            {
                confirmButton.Visible = false;
                completeButton.Visible = false;
                closeButton.Visible = false;
            }  
        }

        private void PopulateOrganizationDetails()
        {
            string donationID = Request.QueryString["donationID"];
            string memberID = Request.QueryString["memberID"];

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            if (memberID != "")
            {
                SqlDataAdapter da5 = new SqlDataAdapter("select * from MEMBER where member_id = '" + memberID + "'", dbconnection1);
                DataTable dt5 = new DataTable();
                da5.Fill(dt5);
                email.Text = dt5.Rows[0][3].ToString();

                SqlDataAdapter da6 = new SqlDataAdapter("select * from DONOR where member_id = '" + memberID + "'", dbconnection1);
                DataTable dt6 = new DataTable();
                da6.Fill(dt6);
                verified.Text = dt6.Rows[0][11].ToString();
            }

            // Display record from second table
            SqlDataAdapter da2 = new SqlDataAdapter("select * from DONATION_FORM where donation_id = '" + donationID + "'", dbconnection1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            status.Text = dt2.Rows[0][2].ToString();
            org_name.Text = dt2.Rows[0][6].ToString();
            org_num.Text = dt2.Rows[0][7].ToString();
            person_in_charge.Text = dt2.Rows[0][8].ToString();
            contact_no.Text = dt2.Rows[0][9].ToString();
            street_address.Text = dt2.Rows[0][11].ToString();
            postal_code.Text = dt2.Rows[0][12].ToString();
            city.Text = dt2.Rows[0][13].ToString();
            DropDownListState.Text = dt2.Rows[0][14].ToString();
            Fruits_Quantity.Text = dt2.Rows[0][15].ToString();
            Vegetables_Quantity.Text = dt2.Rows[0][16].ToString();
            Dairy_and_Eggs_Quantity.Text = dt2.Rows[0][17].ToString();
            Meat_Quantity.Text = dt2.Rows[0][18].ToString();
            Seafood_Quantity.Text = dt2.Rows[0][19].ToString();
            Breads_and_Cereals_Quantity.Text = dt2.Rows[0][20].ToString();
            Sweets_Snacks_Beverages_Quantity.Text = dt2.Rows[0][21].ToString();
            Canned_Products_Quantity.Text = dt2.Rows[0][22].ToString();
            DropDownListShelfLife.Text = dt2.Rows[0][23].ToString();
            DisplayDate.Text = Convert.ToDateTime(dt2.Rows[0][24]).ToShortDateString();
            DonateTime_DropDownList.Text = dt2.Rows[0][25].ToString();
            other_messages_textbox.Text = dt2.Rows[0][26].ToString();
            string pickupService = dt2.Rows[0][27].ToString();
            if (pickupService == "Yes")
            {
                pickup_service.Checked = true;
            }
            else
            {
                pickup_service.Checked = false;
            }

            dbconnection1.Close();

            if (pickupService == "Yes")
            {
                pickup_service.Checked = true;
            }
            else
            {
                pickup_service.Checked = false;
                confirmButton.Visible = false;
            }

            if (status.Text == "Confirmed")
            {
                confirmButton.Visible = false;
            }
            else if (status.Text == "Closed" || status.Text == "Completed" || status.Text == "Cancelled")
            {
                confirmButton.Visible = false;
                completeButton.Visible = false;
                closeButton.Visible = false;
            }

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
            DropDownListShelfLife.Enabled = false;
            DisplayDate.ReadOnly = true;
            DonateTime_DropDownList.Enabled = false;
            other_messages_textbox.ReadOnly = true;
            if (verified.Text == "No")
            {
                pickup_service.Enabled = false;
            }
        }


        protected void confirmButton_Click(object sender, EventArgs e)
        {
            string donationID = Request.QueryString["donationID"];

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            string query3 = "update DONATION_FORM set donation_status = 'Confirmed' where donation_id = '" + donationID + "'";
            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
            cmd3.ExecuteNonQuery();
            dbconnection1.Close();

            Response.Redirect(Request.Url.AbsoluteUri);

        }

        protected void completeButton_Click(object sender, EventArgs e)
        {
            string donationID = Request.QueryString["donationID"];

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            string query3 = "update DONATION_FORM set donation_status = 'Completed' where donation_id = '" + donationID + "'";
            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
            cmd3.ExecuteNonQuery();


            // Retrieve the current inventory quantities from the database
            SqlDataAdapter da4 = new SqlDataAdapter("select * from INVENTORY", dbconnection1);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            int fruit = int.Parse(dt4.Rows[0][0].ToString());
            int vegetable = int.Parse(dt4.Rows[0][1].ToString());
            int dairy_egg = int.Parse(dt4.Rows[0][2].ToString());
            int meat = int.Parse(dt4.Rows[0][3].ToString());
            int seafood = int.Parse(dt4.Rows[0][4].ToString());
            int bread_cereal = int.Parse(dt4.Rows[0][5].ToString());
            int sweet_snack = int.Parse(dt4.Rows[0][6].ToString());
            int canned = int.Parse(dt4.Rows[0][7].ToString());

            // Convert the input quantities to integers
            int inputFruitsQuantity = int.Parse(Fruits_Quantity.Text);
            int inputVegetablesQuantity = int.Parse(Vegetables_Quantity.Text);
            int inputDairyAndEggsQuantity = int.Parse(Dairy_and_Eggs_Quantity.Text);
            int inputMeatQuantity = int.Parse(Meat_Quantity.Text);
            int inputSeafoodQuantity = int.Parse(Seafood_Quantity.Text);
            int inputBreadsCerealsQuantity = int.Parse(Breads_and_Cereals_Quantity.Text);
            int inputSweetsSnacksBeveragesQuantity = int.Parse(Sweets_Snacks_Beverages_Quantity.Text);
            int inputCannedProductsQuantity = int.Parse(Canned_Products_Quantity.Text);

            // Add the input quantities from the current inventory quantities
            int updatedFruitsQuantity = fruit + inputFruitsQuantity;
            int updatedVegetablesQuantity = vegetable + inputVegetablesQuantity;
            int updatedDairyAndEggsQuantity = dairy_egg + inputDairyAndEggsQuantity;
            int updatedMeatQuantity = meat + inputMeatQuantity;
            int updatedSeafoodQuantity = seafood + inputSeafoodQuantity;
            int updatedBreadsandCerealsQuantity = bread_cereal + inputBreadsCerealsQuantity;
            int updatedSweetsSnacksBeveragesQuantity = sweet_snack + inputSweetsSnacksBeveragesQuantity;
            int updatedCannedProductsQuantity = canned + inputCannedProductsQuantity;

            // Update the inventory quantities in the database
            string query4 = "update INVENTORY set inventory_fruit_quantity = '" + updatedFruitsQuantity + "', inventory_vegetable_quantity = '" + updatedVegetablesQuantity + "', inventory_dairy_egg_quantity = '" + updatedDairyAndEggsQuantity + "', inventory_meat_quantity = '" + updatedMeatQuantity + "', inventory_seafood_quantity = '" + updatedSeafoodQuantity + "', inventory_bread_cereal_quantity = '" + updatedBreadsandCerealsQuantity + "', inventory_sweet_snack_quantity = '" + updatedSweetsSnacksBeveragesQuantity + "', inventory_canned_quantity = '" + updatedCannedProductsQuantity + "'";
            SqlCommand cmd4 = new SqlCommand(query4, dbconnection1);
            cmd4.ExecuteNonQuery();

            dbconnection1.Close();

            string recipientEmail = email.Text;
            string subject = "Thank You for Your Generous Donation!";
            string body = "We wanted to take a moment to express our deepest gratitude for your recent donation. Your generosity and support have made a significant impact on our ability to provide vital assistance to those in need. <br> Once again, thank you for your generosity and for being an essential part of our mission. Together, we can create positive change and improve the lives of those in need. We look forward to your continued support and making a difference together.";
            SendEmail(recipientEmail, subject, body);

            Response.Redirect(Request.Url.AbsoluteUri);

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

        protected void closeButton_Click(object sender, EventArgs e)
        {
            string donationID = Request.QueryString["donationID"];

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            string query3 = "update DONATION_FORM set donation_status = 'Closed' where donation_id = '" + donationID + "'";
            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
            cmd3.ExecuteNonQuery();
            dbconnection1.Close();

            Response.Redirect(Request.Url.AbsoluteUri);

        }
    }
}