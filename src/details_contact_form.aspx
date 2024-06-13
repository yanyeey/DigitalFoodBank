<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Admin.Master" AutoEventWireup="true" CodeBehind="details_contact_form.aspx.cs" Inherits="FYP_DFB.details_contact_form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent1" runat="server">

    <div class="main-banner wow fadeIn" id="top" data-wow-duration="1s" data-wow-delay="0.5s">
        <div class="container" style="margin-top: -6rem;">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-6 align-self-center">
                            <div class="left-content show-up header-text wow fadeInLeft" data-wow-duration="1s" data-wow-delay="1s">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <h6>Digital Food Bank</h6>
                                        <div class="section-heading">
                                            <h4>Manage Contact Us Form</h4>
                                            <div class="line-dec" style="background-color: #fa65b1;"></div>
                                            <br /><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/manage.png" alt="" style="transform: scale(0.85);">
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
                <div class="col-lg-6 offset-lg-3  wow fadeInDown" data-wow-duration="1s" data-wow-delay="0.2s">
                    <div class="section-heading">
                        <h4><em>Manage Contact Us Form</em></h4>
                        <div class="line-dec"></div>
                    </div>
                </div>
                <div class="row wow fadeInUp" data-wow-duration="0.8s" data-wow-delay="0.4s">   
                    <div class="col-lg-6 offset-lg-3" style="margin-left: 25rem;">
                        <table>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="Form ID: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="form_id" Text="id"></asp:Label>
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>                            
                            <tr>
                                <td style="width: 350px; white-space:nowrap;">
                                    <asp:Label runat="server" Text="Sender Name: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="name" Text="name"></asp:Label>                                
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="Email: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="email" Text="example@mail.com"></asp:Label>                                
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="Subject:" Font-Bold="True"></asp:Label>
                                </td>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" ID="subject" Text="subject" Width="500px"></asp:Label>                      
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="Message:" Font-Bold="True"></asp:Label>
                                </td>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" ID="message" Text="message"></asp:Label>                      
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                        <br /><br /><br />
                        <asp:Button ID="submit_button" runat="server" Text="Resolve" ForeColor="#FA65B1" Height="50px" Width="350px" BorderColor="#FA65B1" CssClass="asp-submit-button" Style="margin-left: 6rem;" OnClick="submit_button_Click" />
                        <br /><br /><br /><br /><br />
                    </div>
                </div>
            </div>
        </div> 
    </div>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>
