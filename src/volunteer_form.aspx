<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="volunteer_form.aspx.cs" Inherits="FYP_DFB.volunteer_form" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="MainContent1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>

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
                                            <h4>Volunteer Registration Form</h4>
                                            <div class="line-dec" style="background-color: #fa65b1;"></div>
                                            <br />
                                            <p>Register now and be a part of our dedicated team of volunteers. Together, we can make a significant difference and bring hope to those who need it the most!</p>
                                            <br /><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/form-background.jpeg" alt="" style="opacity: 0.9">
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
                        <h6>Volunteer Registration Form</h6>
                        <h4>Please Fill In Your <em>Details</em></h4>
                        <div class="line-dec"></div>
                    </div>
                </div>
                <div class="row wow fadeInUp" data-wow-duration="0.8s" data-wow-delay="0.4s">   
                    <div class="col-lg-6 offset-lg-3">
                        <table>
                            <tr>
                                <td style="width: 350px; white-space: nowrap;">
                                    <asp:Label runat="server" Text="First Name:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="individual_first_name" runat="server" Height="50px" Width="350px" placeholder=" First Name"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="indiivdual_first_name_validator" runat="server" ErrorMessage="*Please Enter First Name." ControlToValidate="individual_first_name" Display="Dynamic" Text="*Please Enter First Name." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="Last Name:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="individual_last_name" runat="server" Height="50px" Width="350px" placeholder=" Last Name"></asp:TextBox>
                                </td>
                            </tr>  
                            <tr>
                                <td></td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="indiivdual_last_name_validator" runat="server" ErrorMessage="*Please Enter Last Name." ControlToValidate="individual_last_name" Display="Dynamic" Text="*Please Enter Last Name." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="Gender: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonListType" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="&nbsp;Female" Value="Female" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="&nbsp;Male" Value="Male"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px; white-space: nowrap;">
                                    <asp:Label runat="server" Text="Date of Birth: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="DOB" runat="server" type="date" Height="30px" Width="130px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px; white-space: nowrap;">
                                    <asp:Label runat="server" Text="Contact Number: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="contact_no" runat="server" Height="50px" Width="350px" Placeholder=" E.g. 60123456789"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="contact_no_validator" runat="server" ErrorMessage="*Please Enter Contact Number." ControlToValidate="contact_no" Display="Dynamic" Text="*Please Enter Contact Number." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="Email: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="email" runat="server" Height="50px" Width="350px" Placeholder=" Email"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="email_validator" runat="server" ErrorMessage="*Please Enter Email." ControlToValidate="email" Display="Dynamic" Text="*Please Enter Email." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="email" EnableClientScript="False" ErrorMessage="Invalid Email." ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="City: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="city" runat="server" Height="50px" Width="350px" Placeholder=" City"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="city_validator" runat="server" ErrorMessage="*Please Enter City Name." ControlToValidate="city" Display="Dynamic" Text="*Please Enter City Name." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="State:" Font-Bold="True"></asp:Label>
                                </td>
                                <td style="width: 350px;">
                                    <asp:DropDownList runat="server" ID="DropDownListState" Height="40px" Width="150px">
                                        <asp:ListItem Text="Johor" Value="Johor"></asp:ListItem>
                                        <asp:ListItem Text="Kedah" Value="Kedah"></asp:ListItem>
                                        <asp:ListItem Text="Kelantan" Value="Kelantan"></asp:ListItem>
                                        <asp:ListItem Text="Kuala Lumpur" Value="Kuala Lumpur"></asp:ListItem>
                                        <asp:ListItem Text="Melaka" Value="Melaka"></asp:ListItem>
                                        <asp:ListItem Text="Negeri Sembilan" Value="Negeri Sembilan"></asp:ListItem>
                                        <asp:ListItem Text="Pahang" Value="Pahang"></asp:ListItem>
                                        <asp:ListItem Text="Penang" Value="Penang"></asp:ListItem>
                                        <asp:ListItem Text="Perak" Value="Perak"></asp:ListItem>
                                        <asp:ListItem Text="Perlis" Value="Perlis"></asp:ListItem>
                                        <asp:ListItem Text="Sabah" Value="Sabah"></asp:ListItem>
                                        <asp:ListItem Text="Sarawak" Value="Sarawak"></asp:ListItem>
                                        <asp:ListItem Text="Selangor" Value="Selangor"></asp:ListItem>
                                        <asp:ListItem Text="Terengganu" Value="Terengganu"></asp:ListItem>
                                    </asp:DropDownList>                                
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px; white-space: nowrap;">
                                    <asp:Label runat="server" Text="Preferred Days to Volunteer:" Font-Bold="True"></asp:Label>
                                <td>
                                    <asp:CheckBoxList ID="PreferredDays_CheckBoxList" runat="server">
                                        <asp:ListItem Text="&nbsp;&nbsp;&nbsp;Weekdays" Value="Weekdays" />
                                        <asp:ListItem Text="&nbsp;&nbsp;&nbsp;Weekends" Value="Weekends" />
                                    </asp:CheckBoxList>
                                    <asp:CustomValidator ID="PreferredDays_Validator" runat="server" ErrorMessage="Please select at least one option."
                                        Display="Dynamic" OnServerValidate="PreferredDaysValidator_ServerValidate" ForeColor="Red" />
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px; white-space: nowrap;">
                                    <asp:Label runat="server" Text="Areas of Interest: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBoxList ID="InterestArea_CheckBoxList" runat="server">
                                        <asp:ListItem Text="&nbsp;&nbsp;&nbsp;Administration" Value="Administration" />
                                        <asp:ListItem Text="&nbsp;&nbsp;&nbsp;Events" Value="Events" />
                                        <asp:ListItem Text="&nbsp;&nbsp;&nbsp;Fund Raising" Value="FundRaising" />
                                        <asp:ListItem Text="&nbsp;&nbsp;&nbsp;Kitchen" Value="Kitchen" />
                                        <asp:ListItem Text="&nbsp;&nbsp;&nbsp;Logistics" Value="Logistics" />
                                        <asp:ListItem Text="&nbsp;&nbsp;&nbsp;Partner Relations" Value="PartnerRelations" />
                                        <asp:ListItem Text="&nbsp;&nbsp;&nbsp;Photography" Value="Photography" />
                                        <asp:ListItem Text="&nbsp;&nbsp;&nbsp;Warehouse" Value="Warehouse" />
                                    </asp:CheckBoxList>
                                    <asp:CustomValidator ID="InterestArea_Validator" runat="server" ErrorMessage="Please select at least one option."
                                        Display="Dynamic" OnServerValidate="InterestAreaValidator_ServerValidate" ForeColor="Red" />
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="Other Messages: " Font-Bold="True"></asp:Label>
                                 </td>
                                 <td>
                                    <asp:TextBox ID="other_messages_textbox" runat="server" TextMode="MultiLine" Width="450px" Height="100px"></asp:TextBox>
                                 </td>
                            </tr>
                        </table>
                        <br /><br /><br />
                        <asp:Button ID="submit_button" runat="server" Text="Submit" ForeColor="#FA65B1" BorderColor="#FA65B1" CssClass="asp-submit-button" OnClick="submit_button_Click" />
                        <asp:Label ID="member_id" runat="server" Text="member id" Visible="False"></asp:Label>
                        <asp:Label runat="server" ID="FormCount" Text="Label" Visible="False"></asp:Label>
                        <asp:Label ID="LabelErrorMessage" runat="server" Text="Error Message" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
        </div> 
    </div>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>
