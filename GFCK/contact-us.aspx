<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="contact-us.aspx.cs" Inherits="GFCK.contact_us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Contact US</h1><br />
<div>
    <asp:label ID="lblError" runat="server" Text="An error has occoured." visible="false" ForeColor="Red"  />
    <asp:ValidationSummary DisplayMode="BulletList" ForeColor="Red" HeaderText="The following fields are required" ID="validationSummary1" runat="server" />
</div>

<div id="divThankYou" runat="server" visible="false">
<p>Thank you! Your message has been sent.</p>
</div>

<div id="divForm" runat="server">
<p>If you have a question or comment, please contact us using the form below.</p>
    <div><span style="color:Red;">Required Field *</span></div><br />
<table class="contactus">
    <tr>
        <td>FirstName:<span style="color:Red;">*</span></td>
        <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="First Name is required." Text="*" /></td>
    </tr>
    <tr><td colspan="2">&nbsp;</td></tr>
    <tr>
        <td>Last Name:<span style="color:Red;">*</span></td>
        <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" Display="Dynamic" ErrorMessage="Last Name is required." Text="*" /></td>
    </tr>
    <tr><td colspan="2">&nbsp;</td></tr>
    <tr>
        <td>Email:<span style="color:Red;">*</span></td>
        <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email is required." Text="*" /></td>
    </tr>
    <tr><td colspan="2">&nbsp;</td></tr>
    <tr>
        <td>Phone Number:  </td>
        <td><asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox></td>
    </tr>
    <tr><td colspan="2">&nbsp;</td></tr>
    <tr>
        <td>Reason For Contacting Us:  </td>
        <td><asp:DropDownList ID="ddlReason" runat="server">
            <asp:ListItem Text="Advertising" Value="advertise" />
            <asp:ListItem Text="Affiliate" Value="affiliate" />
            <asp:ListItem Text="Feedback" Value="feedback" />
            <asp:ListItem Text="Support" Value="support" />
            <asp:ListItem Text="Paypal" Value="paypal" />
        </asp:DropDownList></td>
    </tr>
    <tr><td colspan="2">&nbsp;</td></tr>
    <tr>
        <td>Comments:</td><td><asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="6"></asp:TextBox></td>
    </tr>
    <tr><td colspan="2">&nbsp;</td></tr>
    <tr>
        <td>&nbsp;</td>
        <td><asp:Button ID="btnSend" runat="server" Text="Send" onclick="btnSend_Click" /></td>
    </tr>
    <tr><td colspan="2">&nbsp;</td></tr>
</table>
</div>


</asp:Content>
