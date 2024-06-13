<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="FYP_DFB.About" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="MainContent1" runat="server">

    <!-- About Us -->
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
                                            <h4>About Us</h4>
                                            <div class="line-dec" style="background-color: #fa65b1;"></div>
                                            <br />
                                            <p>Digital Food Bank is a non-profit, charitable organization dedicated to creating a sustainable future by addressing the United Nations' Sustainable Development Goals of Zero Hunger (Goal 2) and Responsible Consumption and Production (Goal 12). We believe that everyone deserves access to nutritious food, and we are committed to reducing food waste while providing essential food and resources to those in need.</p>                      
                                            <br /><br /><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/united-nation-goals.jpg" alt="" style="margin-top: 3rem;">
                            </div>
                        </div>
                    </div>                                       
                </div>
            </div>
        </div> 
    </div>

    <!-- How does DFB Works -->
    <div class="cards-2">
        <div class="container">
            <div class="row" style="margin-top: 6rem;">
                <div class="col-lg-12 wow fadeIn" data-wow-duration="1.2s" data-wow-delay="0.2s">
                    <h2>How does Digital Food Bank<em style="font-style: normal;color: #726ae3;"> operates</em>?</h2>
                    <div style="width: 50px; height: 3px; background-color: #726ae3; margin: 0 auto; margin-top: -4rem; margin-bottom: 5rem;"></div>
                </div>
                <div class="counter" style="z-index: 10;">
                    <div class="container">
                        <div class="row wow fadeIn" data-wow-duration="1.2s" data-wow-delay="0.4s">
                            <div class="col-lg-12" style="margin-top: -10.5rem;">
                                <p>Our team of dedicated volunteers and staff work tirelessly to collect, check, sort, store, and distribute the surplus food received. We understand the importance of food safety and take great care to ensure that all donated items are safe to be consumed before being distributed to our partner organizations and individuals in need within the community. By doing so, we hope to not only address the issue of food waste but also provide essential nourishment to those who need it.</p>                                    
                                <br />
                                <img src="../Customised_Design/Images/dfb-process.jpg"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 wow fadeInUp" data-wow-duration="1s" data-wow-delay="0.5s"></div>
                </div>
            </div>
        </div>
    </div>

    <!-- Statistics -->
    <div id="blog" class="blog" style="margin-top: -5.5rem;">
        <div class="container">
            <div class="row">
                <div class="col-lg-4 offset-lg-4  wow fadeInDown" data-wow-duration="1s" data-wow-delay="0.2s">
                    <div class="section-heading">
                        <h6>Statistics</h6>
                        <h4>Discover Our <em>Impact</em></h4>
                        <div class="line-dec"></div>
                    </div>
                </div>
                <div class="counter" style="z-index: 10;">
                    <div class="container">
                        <div class="row wow fadeInUp" data-wow-duration="1s" data-wow-delay="0.5s">
                            <div class="col-lg-12" style="margin-top: -10.5rem; margin-bottom: 10rem;">
                                <p>Thanks to our donors and volunteers, we are able to provide crucial support to those in need, distributing over 20,000 kgs of food and diverting more than 12,000 kgs of food from going to waste. We are committed to continuing our positive impact in promoting a more sustainable food system and in creating a future where healthy, nutritious food is accessible to all. 
                                    <br />Join us in our mission and make an impact today by donating or volunteering with us!</p>                                    
                            </div>
                        </div>
                        <div class="row wow fadeIn" data-wow-duration="1s" data-wow-delay="0.7s">
                            <div class="col-lg-12">
                                <!-- Counter Start-->
                                <div class="counter-item" id="counter" style="margin-bottom: 1.4rem;">
                                    <div class="cell">
                                        <i class="fa fa-users"></i>
                                        <p class="counter-info" id="counter-info">Registered Members</p>
                                        <div class="counter-value number-count" data-count="996">1</div>
                                    </div>
                                    <div class="cell">
                                        <i class="fa fa-heart yellow"></i>
                                        <p class="counter-info">Registered Volunteers</p>
                                        <div class="counter-value number-count" data-count="150">1</div>
                                    </div>
                                    <div class="cell">
                                        <i class="fa fa-archive red"></i>
                                        <p class="counter-info">Food Parcels Collected</p>
                                        <div class="counter-value number-count" data-count="12002">1</div>
                                    </div>
                                    <div class="cell">
                                        <i class="fa fa-archive green"></i>
                                        <p class="counter-info">Food Parcels Distributed</p>
                                        <div class="counter-value number-count" data-count="9032">1</div>
                                    </div>
                                    <div class="cell">
                                        <i class="fa fa-child pink"></i>
                                        <p class="counter-info">Total People Served</p>
                                        <div class="counter-value number-count" data-count="8507">1</div>
                                    </div>
                                </div>
                                <!-- Counter End -->
                                <div class="col-lg-12">
                                    <div class="border-second-button scroll-to-section">
                                        <a href="volunteer_form.aspx" style="margin-right: 1rem;">Register as Volunteer</a>
                                        <a href="donate.aspx">Donate Now</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>

