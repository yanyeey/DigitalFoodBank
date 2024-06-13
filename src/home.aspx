<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="FYP_DFB.Default" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="MainContent1" runat="server">

    <!-- Intro -->
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
                                        <h2>Addressing Food Waste & Food Insecurity </h2>
                                        <p>We are committed to serving our community with compassion, dignity, and respect. Our platform is launched with the aim of fostering effective communication and collaboration while increasing access to information. Therefore, we sincerely invite you to explore our website and join us in our efforts to reduce food waste and food insecurity. Together, we can work towards building a brighter future for our community!</p>                                    
                                    </div>
                                    <div class="col-lg-12">
                                        <div class="border-first-button scroll-to-section">
                                            <a href="about.aspx">Learn More</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/food-donation-illustration.jpg" alt="" style="opacity:0.85; transform: scale(1.3);">
                            </div>
                        </div>
                    </div>
                </div>
             </div>
        </div>
    </div>

    <div id="about" class="about section" style="margin-top: -4.5rem">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="about-left-image wow fadeInLeft" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/inventory-background.jpg" alt="" >
                            </div>
                        </div>
                        <div class="col-lg-6 align-self-center wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                            <div class="about-right-content">
                                <div class="section-heading">
                                    <h6>Highlights</h6>
                                    <h4>Our <em>Inventory</em></h4>
                                    <div class="line-dec"></div>
                                </div>
                                <p>We believe that by providing inventory visibility, individuals and organizations can make informed decisions regarding food donations and requests for food assistance. This can significantly mitigate the risks of overstocking or understocking of food items, which in turn helps us to deliver a more efficient and effective service to our partners.</p>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="border-second-button scroll-to-section">
                                            <a href="inventory.aspx">Explore Inventory</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Statistics -->
    <div id="blog" class="blog">
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
                                <p>Join us in making a positive impact! Every contribution, no matter how small, can make a difference in building a stronger and more resilient community. In addition, if you're passionate about serving others, we invite you to join our team as a volunteer. Collaboratively, we can strive towards a better world for all!</p>                                    
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

    <!-- Testimonials -->
    <div style="background:url(../Customised_Design/Images/portfolio-left-dec.jpg) left no-repeat, url(../Customised_Design/Images/portfolio-right-dec.jpg) right no-repeat;""> 
        <div class="cards-2">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 wow fadeInDown" data-wow-duration="1s" data-wow-delay="0.2s">
                        <h2>User <em style="font-style: normal;color: #726ae3;">Testimonials</em></h2>
                    </div>
                    <div style="width: 50px; height: 3px; background-color: #726ae3; margin: 0 auto; margin-top: -4rem; margin-bottom: 5rem;"></div>
                </div>
                <div class="row">
                    <div class="col-lg-12 wow fadeInUp" data-wow-duration="1s" data-wow-delay="0.5s">

                        <!-- Card One Start-->
                        <div class="card">
                            <div class="card-image">
                                <i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i>
                                <hr class="testimonial-line">
                            </div>
                            <div class="card-body">
                                <div class="testimonial-text">Digital food bank has been a lifeline for my family during tough times. With their help, we have been able to put nutritious meals on the table when we didn't know where our next meal would come from. The volunteers are kind and compassionate, and the food provided is always fresh and of good quality. We are so grateful for the support and assistance that the food bank has provided to us.</div>
                                <div class="testimonial-author">- Jane Wong</div>
                            </div>
                        </div>
                        <!-- Card One End -->

                        <!-- Card Two Start-->
                        <div class="card">
                            <div class="card-image">
                                <i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i>
                                <hr class="testimonial-line">
                            </div>
                            <div class="card-body">
                                <div class="testimonial-text">The food bank has been a true blessing for my elderly parents. As they struggle with health issues and limited income, the food bank has provided them with much-needed food assistance. The volunteers are always kind and compassionate, and the food provided is of excellent quality. The food bank has helped my parents maintain their dignity and health during a challenging time, and we are incredibly grateful for their support.</div>
                                <div class="testimonial-author">- Kenneth Luck</div>
                            </div>
                        </div>
                        <!-- Card Two end-->

                        <!-- Card Three Start-->
                        <div class="card">
                            <div class="card-image">
                                <i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i>
                                <hr class="testimonial-line">
                            </div>
                            <div class="card-body">
                                <div class="testimonial-text">I cannot thank the food bank enough for their assistance during a recent crisis. When our home was damaged by a natural disaster, we lost our belongings and were left with very little. The food bank stepped in and provided us with food and essential supplies to help us get back on our feet. The generosity and compassion shown by the food bank and its volunteers were overwhelming, and we are deeply appreciative of their support during our time of need.</div>
                                <div class="testimonial-author">- Grace Muller</div>
                            </div>
                        </div>
                        <!-- Card Three end-->

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="contact" class="contact-us section">
       <div class="container">
           <div class="row">
               <div class="col-lg-6 offset-lg-3">
                   <div class="section-heading wow fadeIn" data-wow-duration="1s" data-wow-delay="0.5s">
                       <h6>Contact Us</h6>
                       <h4>Send a Message To <em>Us</em></h4>
                       <div class="line-dec"></div>
                   </div>
               </div>
               <div class="col-lg-12 wow fadeInUp" data-wow-duration="0.5s" data-wow-delay="0.25s">
                   <div id="formWrapper">
                       <form id="contact" action="" method="post" >
                           <div class="row">
                               <div class="col-lg-12">
                                   <div class="contact-dec">
                                       <img src="../Customised_Design/Images/contact-dec.png" alt="" style="opacity:0.85">
                                   </div>
                               </div>
                               <div class="col-lg-5">
                                   <div id="map">
                                       <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3984.146627454418!2d101.69837271475707!3d3.055405697774977!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31cc4abb795025d9%3A0x1c37182a714ba968!2sAsia%20Pacific%20University%20of%20Technology%20%26%20Innovation%20(APU)!5e0!3m2!1sen!2smy!4v1650561714702!5m2!1sen!2smy%22" width="100%" height="636px" frameborder="0" style="border:0" allowfullscreen></iframe>
                                   </div>
                               </div>
                               <div class="col-lg-7">
                                   <div class="fill-form">
                                       <div class="row">
                                           <div class="col-lg-4">
                                               <div class="info-post">
                                                   <div class="icon">
                                                       <img src="../Customised_Design/Images/phone-icon.png" alt="">
                                                       <a href="#">03-8996-1000</a>
                                                   </div>
                                               </div>
                                           </div>
                                           <div class="col-lg-4">
                                               <div class="info-post">
                                                   <div class="icon">
                                                       <img src="../Customised_Design/Images/email-icon.png" alt="">
                                                       <a href="#">digitalfoodbank@gmail.com</a>
                                                   </div>
                                               </div>
                                           </div>
                                           <div class="col-lg-4">
                                               <div class="info-post">
                                                   <div class="icon">
                                                       <img src="../Customised_Design/Images/location-icon.png" alt="">
                                                       <a href="#">Teknology Park Malaysia</a>
                                                   </div>
                                               </div>
                                           </div>
                                           <div class="col-lg-6">
                                               <fieldset>
                                                   <asp:TextBox ID="Name" runat="server" Height="50px" Width="670px" Placeholder="Name"></asp:TextBox>
                                                   <div class="col-lg-6" style="margin-top: 0.5rem;">
                                                       <asp:RequiredFieldValidator ID="ValidatorName" runat="server" ControlToValidate="Name" EnableClientScript="False" ErrorMessage="Please Enter Name." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                                   </div>
                                                   <asp:TextBox ID="Email" runat="server" Height="50px" Width="670px" Placeholder="Email"></asp:TextBox>
                                                   <div class="col-lg-6" style="margin-top: 0.5rem;">
                                                       <asp:RequiredFieldValidator ID="ValidatorEmail" runat="server" ControlToValidate="Email" EnableClientScript="False" ErrorMessage="Please Enter Email." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                                       <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="email" EnableClientScript="False" ErrorMessage="Invalid Email." ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                                                   </div>
                                                   <asp:TextBox ID="Subject" runat="server" Height="50px" Width="670px" Placeholder="Subject"></asp:TextBox>
                                                   <div class="col-lg-6" style="margin-top: 0.5rem;">
                                                       <asp:RequiredFieldValidator ID="ValidatorSubject" runat="server" ControlToValidate="Subject" EnableClientScript="False" ErrorMessage="Please Enter Subject." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                                   </div>
                                                   <asp:TextBox ID="Message" runat="server" Height="50px" Width="670px" Placeholder="Message"></asp:TextBox>
                                                   <div class="col-lg-6" style="margin-top: 0.5rem;">
                                                       <asp:RequiredFieldValidator ID="ValidatorMessage" runat="server" ControlToValidate="Message" EnableClientScript="False" ErrorMessage="Please Enter Message." Width="300px" style="margin-left: -4rem;" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                                       <asp:Label ID="LabelMessageLengthError" runat="server" ForeColor="#FF3300" Text="Message must be more than 10 characters." Width="500px" style="margin-left: -5.8rem;" Visible="False"></asp:Label>
                                                   </div>
                                               </fieldset>
                                           </div>
                                           <div class="col-lg-12" style="z-index: 10;">
                                               <asp:Button ID="Submit" runat="server" Text="Submit Message" Height="50px" Width="650px" BorderStyle="Solid" BorderColor="#FA65B1" ForeColor="#FA65B1" CssClass="mouse-over-cursor" OnClick="Submit_Click" />
                                               <asp:Label runat="server" ID="FormCount" Text="Label" Visible="False"></asp:Label>
                                               <asp:Label ID="LabelErrorMessage" runat="server" Text="Error Message" Visible="False"></asp:Label>
                                           </div>
                                       </div>
                                   </div>
                               </div>
                           </div>
                       </form>
                   </div>
               </div>
           </div>
       </div>
   </div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>
