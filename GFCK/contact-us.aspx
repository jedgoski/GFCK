<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="contact-us.aspx.cs" Inherits="GFCK.contact_us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Contact US</h1>

<div>
    <asp:label ID="lblError" runat="server" Text="An error has occoured." Visible="false" />
</div>

<div id="divThankYou" runat="server">
<p>Thank you! Please click <a href="/default.aspx">here</a> to go back to the home page.</p>
</div>

<div id="divForm" runat="server">
<p>If you have any question or comments please contact us using the form below.</p>

FirstName: <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
Last Name: <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
Email: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
Phone Number: <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
Comments:<asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine"></asp:TextBox>

</div>


</asp:Content>
