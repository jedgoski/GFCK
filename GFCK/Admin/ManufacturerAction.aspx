<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManufacturerAction.aspx.cs" Inherits="GFCK.Admin.ManufacturerActionAction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<asp:CreateUserWizard ID="createUser" runat="server" />



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
    <asp:Label ID="lblAddSuccessfull" runat="server" Text="Added manufacturer successfully." Visible="false" />
    <asp:Label ID="lblEditSuccessfull" runat="server" Text="Updated manufacturer successfully." Visible="false" />
    <asp:Label ID="lblError" runat="server" Text="An error has occured." Visible="false" />
</div>


Manufacturer Name:<asp:TextBox ID="txtManufacturerName" runat="server"></asp:TextBox>
First Name:<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
LastName:<asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
Email:<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
Phone Number:<asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
Address:<asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
Description<asp:TextBox ID="txtDescription" textMode="MultiLine" runat="server"></asp:TextBox>


<asp:Button ID="btnSave" runat="server" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" PostBackUrl="/Admin/ManufacturerAdmin.aspx" />

</asp:Content>
