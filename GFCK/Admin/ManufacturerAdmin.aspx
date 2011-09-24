<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManufacturerAdmin.aspx.cs" Inherits="GFCK.Admin.ManufacturerAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1>Manufacturer Admin</h1>
<div>
    <asp:Label ID="lblDeleteSuccessfull" runat="server" CssClass="messageStackError" Text="Deleted manufacturer successfully." Visible="false" />
    <asp:Label ID="lblDeleteError" runat="server" CssClass="messageStackError"  Text="Cannot delete manufacturer at this time." Visible="false" />
    <asp:Label ID="lblError" runat="server" CssClass="messageStackError" Text="An error has occured." Visible="false" />
</div>
<div>
<a href="/Admin/ManufacturerAction.aspx?Mode=Add">Add Manufacturer</a>
</div>
<table>
    <asp:Repeater ID="rptManufacuturers" runat="server">
        <HeaderTemplate>
        <tr>
            <thead><b>Manufacturer Name</b></thead>
            <thead><b>Email</b></thead>
            <thead><b>Action</b></thead>
        </tr>
            
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><asp:label id="lblManufacturerName" runat="server" /></td>
                <td><asp:label id="lblEmail" runat="server" /></td>
                <td>
                    <a id="lnkEdit" href="/Admin/ManufacturerAction.aspx?Mode=Edit&ManufacturerID={0}" runat="server">Edit</a> | 
                    <a id="lnkView" href="/Admin/ManufacturerAction.aspx?Mode=View&ManufacturerID={0}" runat="server">View</a> | 
                    <asp:LinkButton id="lnkDelete" CommandName="Delete" Text="Delete" runat="server" />
                </td>
            </tr>
        </ItemTemplate>

        <AlternatingItemTemplate>
            <tr>
                <td><asp:label id="lblManufacturerName" runat="server" /></td>
                <td><asp:label id="lblEmail" runat="server" /></td>
                <td>
                    <a id="lnkEdit" href="/Admin/ManufacturerAction.aspx?Mode=Edit&ManufacturerID={0}" runat="server">Edit</a> | 
                    <a id="lnkView" href="/Admin/ManufacturerAction.aspx?Mode=View&ManufacturerID={0}" runat="server">View</a> | 
                    <asp:LinkButton id="lnkDelete" CommandName="Delete" Text="Delete" runat="server" />
                </td>
            </tr>
        </AlternatingItemTemplate>

        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
</table>



</asp:Content>
