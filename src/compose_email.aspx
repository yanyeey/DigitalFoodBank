<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Admin.Master" AutoEventWireup="true" CodeBehind="compose_email.aspx.cs" Inherits="FYP_DFB.compose_email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent1" runat="server">
        
    <div class="main-banner wow fadeIn" id="top" data-wow-duration="1s" data-wow-delay="0.5s">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row" style="margin-top: -6rem;">
                        <div class="col-lg-6 align-self-center">
                            <div class="left-content show-up header-text wow fadeInLeft" data-wow-duration="1s" data-wow-delay="1s">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <h6>Digital Food Bank</h6>
                                        <div class="section-heading">
                                            <h4>Compose Group Email</h4>
                                            <div class="line-dec" style="background-color: #fa65b1;"></div>
                                            <br />
                                            <br /><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/email.png" alt="" style="transform: scale(0.8)">
                            </div>
                        </div>
                    </div>                                       
                </div>
            </div>
        </div> 
    </div>

    <div id="blog" class="blog">
        <div class="container" style="margin-bottom: 12rem;">
            <div class="row">
                <div class="col-lg-6 offset-lg-3  wow fadeInDown" data-wow-duration="1s" data-wow-delay="0.2s">
                    <div class="section-heading">
                        <h4><em>Compose Group Email</em></h4>
                        <div class="line-dec"></div>
                    </div>
                </div>
                <div class="row wow fadeInUp" data-wow-duration="0.8s" data-wow-delay="0.4s">   
                    <div class="col-lg-6 offset-lg-3">                        
                        <table style="margin-left: 2rem;">
                            <tr>
                                <td style="width: 350px; white-space: nowrap;">
                                    <asp:Label runat="server" Text="Email Subject: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="email_subject" runat="server" Height="50px" Width="350px" Placeholder=" E.g. Message Subject"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="subject_validator" runat="server" ErrorMessage="*Please Enter Subject." ControlToValidate="email_subject" Display="Dynamic" Text="*Please Enter Subject." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px; white-space: nowrap;">
                                    <asp:Label runat="server" Text="Email Body: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="email_body" runat="server" Height="50px" Width="350px" Placeholder=" Email Content" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>                           
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="body_validator" runat="server" ErrorMessage="*Please Enter Email Content." ControlToValidate="email_body" Display="Dynamic" Text="*Please Enter Email Body." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px; white-space: nowrap;">
                                    <asp:Label runat="server" Text="Send to:" Font-Bold="True"></asp:Label>
                                </td>
                                <td style="width: 350px;">
                                    <asp:CheckBoxList ID="Sendto_CheckBoxList" runat="server">
                                        <asp:ListItem Text="&nbsp;&nbsp;&nbsp;Donors" Value="donor" />
                                        <asp:ListItem Text="&nbsp;&nbsp;&nbsp;Recepients" Value="recipient" />
                                        <asp:ListItem Text="&nbsp;&nbsp;&nbsp;Potential Volunteers" Value="all_volunteer" />
                                    </asp:CheckBoxList>
                                    <asp:CustomValidator ID="SendtoValidator" runat="server" ErrorMessage="Please select at least one option."
                                        Display="Dynamic" OnServerValidate="SendtoValidator_ServerValidate" ForeColor="Red" ValidateEmptyText="true" />
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                        </table>
                        <br /><br />
                        <asp:Button ID="submit_button" runat="server" Text="Send Email" ForeColor="#FA65B1" BorderColor="#FA65B1" CssClass="asp-submit-button" OnClick="submit_button_Click" style="margin-left: 15rem;" />
                        <asp:Label ID="LabelErrorMessage" runat="server" Text="Error Message" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
        </div> 
    </div>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>
