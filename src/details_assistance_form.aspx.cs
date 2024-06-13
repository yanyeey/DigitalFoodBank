using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace FYP_DFB
{
    public partial class details_assistance_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReceiveDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");

            DateTime maxDate = DateTime.Today.AddMonths(2); // Set maximum date to 2 months from today
            ReceiveDate.Attributes["max"] = maxDate.ToString("yyyy-MM-dd");

            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!IsPostBack)
            {
                if (Request.QueryString["assistanceID"] != null && Request.QueryString["memberID"] != null)
                {
                    string assistanceID = Request.QueryString["assistanceID"];
                    string assistanceEmail = Request.QueryString["assistanceEmail"];

                    form_id.Text = assistanceID;
                    email.Text = assistanceEmail;

                    SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    dbconnection1.Open();

                    SqlDataAdapter da6 = new SqlDataAdapter("SELECT assistance_role FROM ASSISTANCE_FORM where assistance_id = '" + assistanceID + "'", dbconnection1);
                    DataTable dt6 = new DataTable();
                    da6.Fill(dt6);
                    assistance_role.Text = dt6.Rows[0]["assistance_role"].ToString();

                    if (assistance_role.Text == "individual")
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

                    else if (assistance_role.Text == "organization")
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
                    Response.Redirect("manage_assistance_form.aspx");
                }
            }
        }

        private void PopulateIndividualDetails()
        {
            string assistanceID = Request.QueryString["assistanceID"];
            string memberID = Request.QueryString["memberID"];

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            if (memberID != "")
            {
                SqlDataAdapter da5 = new SqlDataAdapter("select * from MEMBER where member_id = '" + memberID + "'", dbconnection1);
                DataTable dt5 = new DataTable();
                da5.Fill(dt5);
                email.Text = dt5.Rows[0][3].ToString();

                SqlDataAdapter da6 = new SqlDataAdapter("select * from RECIPIENT where member_id = '" + memberID + "'", dbconnection1);
                DataTable dt6 = new DataTable();
                da6.Fill(dt6);
                verified.Text = dt6.Rows[0][13].ToString();
            }

            // Display record from second table
            SqlDataAdapter da2 = new SqlDataAdapter("select * from ASSISTANCE_FORM where assistance_id = '" + assistanceID + "'", dbconnection1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            status.Text = dt2.Rows[0][2].ToString();
            individual_first_name.Text = dt2.Rows[0][4].ToString();
            individual_last_name.Text = dt2.Rows[0][5].ToString();
            identification_number.Text = dt2.Rows[0][9].ToString();
            contact_no.Text = dt2.Rows[0][10].ToString();
            street_address.Text = dt2.Rows[0][12].ToString();
            postal_code.Text = dt2.Rows[0][13].ToString();
            city.Text = dt2.Rows[0][14].ToString();
            DropDownListState.Text = dt2.Rows[0][15].ToString();
            Fruits_Quantity.Text = dt2.Rows[0][16].ToString();
            Vegetables_Quantity.Text = dt2.Rows[0][17].ToString();
            Dairy_and_Eggs_Quantity.Text = dt2.Rows[0][18].ToString();
            Meat_Quantity.Text = dt2.Rows[0][19].ToString();
            Seafood_Quantity.Text = dt2.Rows[0][20].ToString();
            Breads_and_Cereals_Quantity.Text = dt2.Rows[0][21].ToString();
            Sweets_Snacks_Beverages_Quantity.Text = dt2.Rows[0][22].ToString();
            Canned_Products_Quantity.Text = dt2.Rows[0][23].ToString();
            string date = dt2.Rows[0][24].ToString();
            string time = dt2.Rows[0][25].ToString();
            other_messages_textbox.Text = dt2.Rows[0][26].ToString();
            string deliveryService = dt2.Rows[0][27].ToString();

            dbconnection1.Close();

            if (deliveryService == "Yes")
            {
                delivery_service.Checked = true;
            }
            else
            {
                delivery_service.Checked = false;
            }

            if (!string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(time))
            {
                DisplayDate.Text = Convert.ToDateTime(dt2.Rows[0][24]).ToShortDateString();
                ReceiveDate.Visible = false;
                ReceiveTime_DropDownList.Text = dt2.Rows[0][25].ToString();
            }
            else
            {
                DisplayDate.Visible = false;
                ReceiveDate.Visible = true;
                ReceiveTime_DropDownList.ClearSelection();
                ReceiveTime_DropDownList.Items.Insert(0, new ListItem("", ""));
                ReceiveTime_DropDownList.Text = string.Empty;
            }

            if (status.Text == "Closed" || status.Text == "Completed" || status.Text == "Cancelled")
            {
                completeButton.Visible = false;
                closeButton.Visible = false;
                assignButton.Visible = false;
            }
        }

        private void PopulateOrganizationDetails()
        {
            string assistanceID = Request.QueryString["assistanceID"];
            string memberID = Request.QueryString["memberID"];

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            if (memberID != "")
            {
                SqlDataAdapter da5 = new SqlDataAdapter("select * from MEMBER where member_id = '" + memberID + "'", dbconnection1);
                DataTable dt5 = new DataTable();
                da5.Fill(dt5);
                email.Text = dt5.Rows[0][3].ToString();

                SqlDataAdapter da6 = new SqlDataAdapter("select * from RECIPIENT where member_id = '" + memberID + "'", dbconnection1);
                DataTable dt6 = new DataTable();
                da6.Fill(dt6);
                verified.Text = dt6.Rows[0][13].ToString();
            }

            // Display record from second table
            SqlDataAdapter da2 = new SqlDataAdapter("select * from ASSISTANCE_FORM where assistance_id = '" + assistanceID + "'", dbconnection1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            status.Text = dt2.Rows[0][2].ToString();
            org_name.Text = dt2.Rows[0][6].ToString();
            org_num.Text = dt2.Rows[0][7].ToString();
            person_in_charge.Text = dt2.Rows[0][8].ToString();
            contact_no.Text = dt2.Rows[0][10].ToString();
            street_address.Text = dt2.Rows[0][12].ToString();
            postal_code.Text = dt2.Rows[0][13].ToString();
            city.Text = dt2.Rows[0][14].ToString();
            DropDownListState.Text = dt2.Rows[0][15].ToString();
            Fruits_Quantity.Text = dt2.Rows[0][16].ToString();
            Vegetables_Quantity.Text = dt2.Rows[0][17].ToString();
            Dairy_and_Eggs_Quantity.Text = dt2.Rows[0][18].ToString();
            Meat_Quantity.Text = dt2.Rows[0][19].ToString();
            Seafood_Quantity.Text = dt2.Rows[0][20].ToString();
            Breads_and_Cereals_Quantity.Text = dt2.Rows[0][21].ToString();
            Sweets_Snacks_Beverages_Quantity.Text = dt2.Rows[0][22].ToString();
            Canned_Products_Quantity.Text = dt2.Rows[0][23].ToString(); 
            string date = dt2.Rows[0][24].ToString();
            string time = dt2.Rows[0][25].ToString();
            other_messages_textbox.Text = dt2.Rows[0][26].ToString();
            string deliveryService = dt2.Rows[0][27].ToString();

            dbconnection1.Close();

            if (deliveryService == "Yes")
            {
                delivery_service.Checked = true;
            }
            else
            {
                delivery_service.Checked = false;
            }

            if (!string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(time))
            {
                DisplayDate.Text = Convert.ToDateTime(dt2.Rows[0][24]).ToShortDateString();
                ReceiveDate.Visible = false;
                ReceiveTime_DropDownList.Text = dt2.Rows[0][25].ToString();
            }
            else
            {
                DisplayDate.Visible = false;
                ReceiveDate.Visible = true;
                ReceiveTime_DropDownList.ClearSelection();
                ReceiveTime_DropDownList.Items.Insert(0, new ListItem("", ""));
                ReceiveTime_DropDownList.Text = string.Empty;
            }

            if (status.Text == "Closed" || status.Text == "Completed" || status.Text == "Cancelled")
            {
                completeButton.Visible = false;
                closeButton.Visible = false;
            }

        }

        private void SetFieldsReadOnly()
        {
            individual_first_name.ReadOnly = true;
            individual_last_name.ReadOnly = true;
            identification_number.ReadOnly = true;
            org_name.ReadOnly = true;
            org_num.ReadOnly = true;
            person_in_charge.ReadOnly = true;
            contact_no.ReadOnly = true;
            email.ReadOnly = true;
            street_address.ReadOnly = true;
            postal_code.ReadOnly = true;
            city.ReadOnly = true;
            DropDownListState.Enabled = false; // Disable dropdownlist
            other_messages_textbox.ReadOnly = true;
            if (verified.Text == "No")
            {
                delivery_service.Enabled = false;
            }
        }

        protected void completeButton_Click(object sender, EventArgs e)
        {
            string assistanceID = Request.QueryString["assistanceID"];

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            string query3 = "update ASSISTANCE_FORM set assistance_status = 'Completed' where assistance_id = '" + assistanceID + "'";
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
            int updatedFruitsQuantity = fruit - inputFruitsQuantity;
            int updatedVegetablesQuantity = vegetable - inputVegetablesQuantity;
            int updatedDairyAndEggsQuantity = dairy_egg - inputDairyAndEggsQuantity;
            int updatedMeatQuantity = meat - inputMeatQuantity;
            int updatedSeafoodQuantity = seafood - inputSeafoodQuantity;
            int updatedBreadsandCerealsQuantity = bread_cereal - inputBreadsCerealsQuantity;
            int updatedSweetsSnacksBeveragesQuantity = sweet_snack - inputSweetsSnacksBeveragesQuantity;
            int updatedCannedProductsQuantity = canned - inputCannedProductsQuantity;

            // Update the inventory quantities in the database
            string query4 = "update INVENTORY set inventory_fruit_quantity = '" + updatedFruitsQuantity + "', inventory_vegetable_quantity = '" + updatedVegetablesQuantity + "', inventory_dairy_egg_quantity = '" + updatedDairyAndEggsQuantity + "', inventory_meat_quantity = '" + updatedMeatQuantity + "', inventory_seafood_quantity = '" + updatedSeafoodQuantity + "', inventory_bread_cereal_quantity = '" + updatedBreadsandCerealsQuantity + "', inventory_sweet_snack_quantity = '" + updatedSweetsSnacksBeveragesQuantity + "', inventory_canned_quantity = '" + updatedCannedProductsQuantity + "'";
            SqlCommand cmd4 = new SqlCommand(query4, dbconnection1);
            cmd4.ExecuteNonQuery();

            dbconnection1.Close();

            string recipientEmail = email.Text;
            string subject = "A Warm Greeting and Well Wishes from Digital Food Bank";
            string body = "We hope this email finds you well. We sincerely hope that the items included in the parcel will bring you comfort and nourishment during these times. <br>Your well-being and satisfaction are of utmost importance to us. If you have any feedback or suggestions regarding the food parcel, we would love to hear from you. Your input will help us improve our services and better meet the needs of our recipients. <br> If there is anything else we can assist you with or if you have any questions, please don't hesitate to reach out to us. Our dedicated team is always ready to lend a helping hand. <br> Once again, we sincerely hope that you enjoy the food parcel and find it helpful. We are grateful for the opportunity to serve you, and we wish you good health, happiness, and success.";
            SendEmail(recipientEmail, subject, body);

            Response.Redirect(Request.Url.AbsoluteUri);

        }

        protected void closeButton_Click(object sender, EventArgs e)
        {
            string assistanceID = Request.QueryString["assistanceID"];

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            string query3 = "update ASSISTANCE_FORM set assistance_status = 'Closed' where assistance_id = '" + assistanceID + "'";
            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
            cmd3.ExecuteNonQuery();
            dbconnection1.Close();

            Response.Redirect(Request.Url.AbsoluteUri);

        }

        protected void assignButton_Click(object sender, EventArgs e)
        {
            string assistanceID = Request.QueryString["assistanceID"];

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            if (!string.IsNullOrEmpty(ReceiveTime_DropDownList.SelectedValue) && !string.IsNullOrEmpty(ReceiveDate.Text))
            {
                if (ReceiveDate.Visible != false)
                {
                    string query3 = "UPDATE ASSISTANCE_FORM SET assistance_date = @DateValue, assistance_time = @TimeValue WHERE assistance_id = @AssistanceID";
                    SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                    cmd3.Parameters.AddWithValue("@DateValue", ReceiveDate.Visible ? ReceiveDate.Text : DisplayDate.Text);
                    cmd3.Parameters.AddWithValue("@TimeValue", ReceiveTime_DropDownList.SelectedValue);
                    cmd3.Parameters.AddWithValue("@AssistanceID", assistanceID);
                    cmd3.ExecuteNonQuery();
                }

                if (delivery_service.Checked == false)
                {
                    string query3 = "update ASSISTANCE_FORM set assistance_delivery_service = 'No' where assistance_id = '" + assistanceID + "'";
                    SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                    cmd3.ExecuteNonQuery();

                    string recipientEmail = email.Text;
                    string subject = "Date & Time For Food Parcel Collection";
                    string body = "Your food assistance request has been processed. Please visit us on " + ReceiveDate.Text + DisplayDate.Text + " during " + ReceiveTime_DropDownList.Text + " to collect your food parcel. <br> We look forward to seeing you soon!";
                    SendEmail(recipientEmail, subject, body);
                }
                else if (delivery_service.Checked == true)
                {
                    string query3 = "update ASSISTANCE_FORM set assistance_delivery_service = 'Yes' where assistance_id = '" + assistanceID + "'";
                    SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                    cmd3.ExecuteNonQuery();

                    string recipientEmail = email.Text;
                    string subject = "Date & Time For Food Parcel Delivery";
                    string body = "Your food assistance request has been processed. We will delivery your food parcel on " + ReceiveDate.Text + DisplayDate.Text + " during " + ReceiveTime_DropDownList.Text + ". <br> We look forward to seeing you soon!";
                    SendEmail(recipientEmail, subject, body);
                }
            }

            else
            {
                this.Error_Message.ForeColor = System.Drawing.Color.Red;
                this.Error_Message.Text = "Update Failed!";
                this.Error_Message.Visible = true;
                return;
            }

            dbconnection1.Close();
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