<%@ Page Title="FAQs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="faqs.aspx.cs" Inherits="FYP_DFB.FAQs" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="MainContent1" runat="server">
   
    <div class="main-banner wow fadeIn" id="top" data-wow-duration="1s" data-wow-delay="0.5s">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-6 align-self-center">
                            <div class="left-content show-up header-text wow fadeInLeft" data-wow-duration="1s" data-wow-delay="1s">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <h6>Digital Food Bank</h6>
                                        <div class="section-heading">
                                            <h4>Frequently Asked Questions</h4>
                                            <div class="line-dec" style="background-color: #fa65b1;"></div>
                                            <br /><br /><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/faqs-background.png" alt="" style="transform: scale(1.15); opacity: 0.9;">
                            </div>
                        </div>
                    </div>                                       
                </div>
            </div>
        </div> 
    </div>

    <div id="blog" class="blog">
        <div class="container">
            <div class="row">
                <div class="row wow fadeInUp" data-wow-duration="1s" data-wow-delay="0.5s">   
                    <details>
                        <summary>How can I donate to Digital Food Bank?</summary>
                        <div class="answer">
                            At Digital Food Bank, we appreciate any and all forms of donations. <br />
                            If you would like to donate <b>money</b>, please click <a href="donate.aspx"><u>here</u></a> to proceed to our monetary donation page. <br />
                            If you wish to donate <b>food</b>, we kindly ask you to provide the details of your donation <a href="food_donation_form.aspx"><u>here</u></a>. Your information will assist us in efficiently processing and utilizing your donation to its fullest potential. <br />
                            If you are interested in making a meaningful impact as a <b>volunteer</b>, please click <a href="volunteer_form.aspx"><u>here</u></a> to learn more about our volunteer opportunities. <br />
                            Thank you again for considering to support our cause. Your contribution will make a significant difference in the lives of those in need.
                        </div>
                    </details>
                    <details>
                        <summary>What types of food donation does the food bank accept?</summary>
                        <div class="answer">
                            We welcome both non-perishable food items such as canned goods, pasta, rice, and cereal, as well as perishable food such as fresh produce and dairy products. To ensure the safety of our recipients, <b>the food items must be fully unopened and have not yet passed their expiration date. </b><br />
                            Please refrain from donating homemade or partially used food items due to food safety regulations. <br />
                            We appreciate your attention to these guidelines as they help us ensure the safety and quality of the food we distribute to our recipients.</div>
                    </details>
                    <details>
                        <summary>How does the food bank address food safety concerns?</summary>
                        <div class="answer">At Digital Food Bank, we take food safety very seriously. All donated food is carefully inspected and sorted by our trained staff to ensure that it is safe for consumption. We follow strict food handling and storage protocols to prevent contamination and spoilage. We also conduct regular inspections of our facilities and equipment to maintain a safe and hygienic environment.</div>
                    </details>
                    <details>
                        <summary>Who is eligible to receive food assistance from Digital Food Bank?</summary>
                        <div class="answer">We aim to provide food assistance to anyone who is experiencing food insecurity. We understand that circumstances can arise unexpectedly, and our mission is to support those in need. If you are experiencing difficulties in accessing adequate food, we encourage you to request for food assistance by submitting a <a href="food_assistance_form.aspx"><u>Food Assistance Request Form</u></a>. We will review your request in a timely manner and respond as soon as possible. We value the privacy and dignity of our recipients, and our food assistance programs are designed to be inclusive and non-discriminatory.</div>
                    </details>
                    <details>
                        <summary>How much time do I need to commit as a volunteer?</summary>
                        <div class="answer">The amount of time you need to commit as a volunteer at Digital Food Bank depends on your availability and the type of volunteer work you are interested in. We have various volunteering opportunities available, ranging from one-time events to ongoing programs. We appreciate any time you can give to support our mission.</div>
                    </details>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>
