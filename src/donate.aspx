<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="donate.aspx.cs" Inherits="FYP_DFB.donate" %>

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
                                            <h4>Donate Now</h4>
                                            <div class="line-dec" style="background-color: #fa65b1;"></div>
                                            <br />
                                            <p>At Digital Food Bank, we appreciate any and all forms of donations.</p>                      
                                            <br /><br /><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/donate-bg.png" alt="" style="transform: scale(0.9)">
                            </div>
                        </div>
                    </div>                                       
                </div>
            </div>
        </div> 
    </div>

    <!-- Monetary Donation -->
    <div class="cards-2">
        <div class="container">
            <div class="row" style="margin-top: 6rem;">
                <div class="col-lg-12 wow fadeIn" data-wow-duration="1.2s" data-wow-delay="0.2s">
                    <h2>Monetary<em style="font-style: normal;color: #726ae3;"> Donations</em></h2>
                    <div style="width: 50px; height: 3px; background-color: #726ae3; margin: 0 auto; margin-top: -4rem; margin-bottom: 5rem;"></div>
                </div>
                <div class="counter" style="z-index: 10;">
                    <div class="container">
                        <div class="row wow fadeIn" data-wow-duration="1.2s" data-wow-delay="0.4s">
                            <div class="col-lg-12" style="margin-top: -10.5rem;">
                                <p>Monetary donations are vital in our mission to alleviate hunger and support those in need. Every contribution, regardless of its amount, has a tangible impact on individuals and families. Your generosity provides us with the flexibility to address the diverse needs of our food bank. With your financial support, we can purchase nutritious food, cover operational costs, and fund essential programs that directly benefit those experiencing food insecurity. We deeply appreciate your contributions and the difference they make in our community.</p>                                    
                                <br />
                                <img src="../Customised_Design/Images/bank-details.png" style="transform: scale(0.6); margin-top: -13rem; margin-bottom: -18rem;" />
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

    <!-- Food Donation -->
    <div class="cards-2">
        <div class="container">
            <div class="row" style="margin-top: 3rem;">
                <div class="col-lg-12 wow fadeIn" data-wow-duration="1.2s" data-wow-delay="0.2s">
                    <h2>Food<em style="font-style: normal;color: #726ae3;"> Donations</em></h2>
                    <div style="width: 50px; height: 3px; background-color: #726ae3; margin: 0 auto; margin-top: -4rem; margin-bottom: 5rem;"></div>
                </div>
                <div class="counter" style="z-index: 10;">
                    <div class="container">
                        <div class="row wow fadeIn" data-wow-duration="1.2s" data-wow-delay="0.4s">
                            <div class="col-lg-12" style="margin-top: -10.5rem;">
                                <p>Food donations are of utmost importance in our efforts to combat hunger and support the community. We greatly appreciate your generosity in considering a food donation. To ensure the safety and suitability of donated items, we kindly request that donors adhere to the following guidelines: </p>                                    
                                <br />
                                <img src="../Customised_Design/Images/do-and-dont.png" style="transform: scale(0.55); margin-top: -18rem; margin-bottom: -20rem;" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 wow fadeInUp" data-wow-duration="1s" data-wow-delay="0.5s"></div>
                </div>
                <div class="col-lg-6" style="margin-left: 3.3rem;">
                    <asp:Button ID="Submit" runat="server" Text="Donate Food" Height="50px" Width="500px" CssClass="asp-submit-button" OnClick="Submit_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>
