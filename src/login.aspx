<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FYP_DFB.login" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="MainContent1" runat="server">
              
    <style>
        .main-banner:after {
          z-index: -1;
        }
    </style>

    <div class="main-banner wow fadeIn" id="top" data-wow-duration="1s" data-wow-delay="0.5s"> 
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-6 align-self-center" style="margin-left: 3rem;">
                            <div class="section-heading wow fadeIn" data-wow-duration="1s" data-wow-delay="0.5s">
                                <h6 style="color: #fa65b1">Digital Food Bank</h6>
                                <h4>Login</h4>
                                <div class="line-dec" style="background-color: #fa65b1;"></div>
                                <br /><br /><br />
                            </div>
                        </div>
                        <div class="row wow fadeInUp" data-wow-duration="0.5s" data-wow-delay="0.25s">
                            <div id="formWrapper">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="contact-dec">
                                            <img src="../Customised_Design/Images/login-bg.png" alt="" style="opacity:0.85">
                                        </div>
                                    </div>
                                    <div class="col-lg-7">
                                        <img src="../Customised_Design/Images/contact-top-left.png" alt="" style="margin-left: -2rem; width: 726px; height: 78px;">
                                    </div>
                                    <div class="col-lg-7">
                                        <div class="col-lg-6" style="margin-left: 15rem; margin-top: 3rem;">
                                            <asp:Label runat="server" Text="Email: " ></asp:Label>
                                        </div>
                                        <div class="col-lg-6" style="margin-top: -0.75rem; margin-left: 24rem;">
                                            <asp:TextBox ID="email" runat="server" Height="50px" Width="500px" Placeholder="Email"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6" style="margin-top: 1rem; margin-left: 18rem;">
                                            <asp:RequiredFieldValidator ID="Email_RequiredFieldValidator" runat="server" ControlToValidate="Email" EnableClientScript="False" ErrorMessage="Please Enter Email." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-lg-6" style=" margin-left: 16rem; margin-top: 3rem;">
                                            <asp:Label runat="server" Text="Password: " ></asp:Label>
                                        </div>
                                        <div class="col-lg-6" style="margin-top: -0.75rem; margin-left: 24rem;">
                                            <asp:TextBox ID="password" runat="server" Height="50px" Width="500px" Placeholder="Password" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6" style="margin-top: 1rem; margin-left: 19rem; margin-bottom: 1rem;">
                                            <asp:RequiredFieldValidator ID="Password_RequiredFieldValidator" runat="server" ControlToValidate="Password" EnableClientScript="False" ErrorMessage="Please Enter Password." ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>   
                                    </div>
                                    <div class="col-lg-12" style="z-index: 10; margin-top: 1rem; margin-bottom: 1rem;">
                                        <asp:Button ID="Submit" runat="server" Text="Login" Height="50px" Width="350px" BorderStyle="Solid" BorderColor="#FA65B1" ForeColor="#FA65B1" CssClass="mouse-over-cursor" OnClick="Submit_Click" />
                                        <br /><br /><br />
                                        <asp:Label ID="LabelNoAccount" runat="server" Text="No Account? " ForeColor="#717171"></asp:Label>
                                        <a href="sign_up.aspx"><u>Sign Up Here</u></a>
                                        <br /><br />
                                        <asp:Label ID="LabelFeedback" runat="server" Text="Email and Password not match." ForeColor="#FF5050" Visible="False"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <img src="../Customised_Design/Images/contact-bottom-left.png" alt="" style="margin-left: -14rem; width:532px; height: 106px;">
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
