<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManufacturerAction.aspx.cs" Inherits="GFCK.Admin.ManufacturerActionAction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="divAddManufacturer" runat="server">
<h1>Add Manufacturer</h1>
</div>
<div id="divEditManufacturer" runat="server">
<h1>Edit Manufacturer</h1>
</div>
<div id="divViewManufacturer" runat="server">
<h1>View Manufacturer</h1>
</div>

<div>
    <asp:Label ID="lblAddSuccessfull" runat="server" CssClass="messageStackError" Text="Added manufacturer successfully." Visible="false" />
    <asp:Label ID="lblEditSuccessfull" runat="server" CssClass="messageStackError" Text="Updated manufacturer successfully." Visible="false" />
    <asp:Label ID="lblError" runat="server" CssClass="messageStackError" Text="An error has occured." Visible="false" />
</div>

<table id="tblAccountinfo" runat="server">
<tr colspan="2"><td><b>Account Information</b></td></tr>
<tr><td>User Name:</td><td><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td></tr>
<tr><td>Password</td><td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td></tr>
<tr><td>Confirm Password</td><td><asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox></td></tr>
</table>

<table>
<tr colspan="2"><td><b>Profile Information</b></td></tr>
<tr><td>Manufacturer Name:</td><td><asp:TextBox ID="txtManufacturerName" runat="server"></asp:TextBox></td></tr>
<tr><td>First Name:</td><td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td></tr>
<tr><td>LastName:</td><td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td></tr>
<tr><td>Email:</td><td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td></tr>
<tr><td>Phone Number:</td><td><asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox></td></tr>
<tr><td>Address:</td><td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td></tr>
<tr><td>Description:</td><td><asp:TextBox ID="txtDescription" textMode="MultiLine" runat="server"></asp:TextBox></td></tr>
</table>


<asp:Button ID="btnSave" runat="server" Text="Save" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" PostBackUrl="/Admin/ManufacturerAdmin.aspx" />

</asp:Content>
