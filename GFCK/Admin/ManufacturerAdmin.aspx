<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManufacturerAdmin.aspx.cs" Inherits="GFCK.Admin.ManufacturerAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1>Manufacturer Admin</h1>
<div>
    <asp:Label ID="lblDeleteSuccessfull" runat="server" Text="Deleted manufacturer successfully." Visible="false" />
    <asp:Label ID="lblDeleteError" runat="server" Text="Cannot delete manufacturer at this time." Visible="false" />
    <asp:Label ID="lblError" runat="server" Text="An error has occured." Visible="false" />
</div>
<table>
    <tr><td><a href="/Admin/ManufacturerAction.aspx?Mode=Add">Add Manufacturer</a></td></tr>
    <asp:Repeater ID="rptManufacuturers" runat="server">
        <HeaderTemplate>
            <thead>Manufacturer Name</thead>
            <thead>Email</thead>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><label id="lblManufacturerName" runat="server" /></td>
                <td><label id="lblEmail" runat="server" /></td>
                <td>
                    <a id="A1" href="/Admin/ManufacturerAction.aspx?Mode=Edit&ManufacturerID={0}" runat="server">Edit</a> | 
                    <a id="A2" href="/Admin/ManufacturerAction.aspx?Mode=View&ManufacturerID={0}" runat="server">View</a> | 
                    <asp:LinkButton id="lnkDelete" CommandName="Delete" Text="Delete" runat="server" />
                </td>
            </tr>
        </ItemTemplate>

        <AlternatingItemTemplate>
            <tr>
                <td><label id="lblManufacturerName" runat="server" /></td>
                <td><label id="lblEmail" runat="server" /></td>
                <td>
                    <a id="A1" href="/Admin/ManufacturerAction.aspx?Mode=Edit&ManufacturerID={0}" runat="server">Edit</a> | 
                    <a id="A2" href="/Admin/ManufacturerAction.aspx?Mode=View&ManufacturerID={0}" runat="server">View</a> | 
                    <asp:LinkButton id="lnkDelete" CommandName="Delete" Text="Delete" runat="server" />
                </td>
            </tr>
        </AlternatingItemTemplate>

        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
</table>



</asp:Content>
