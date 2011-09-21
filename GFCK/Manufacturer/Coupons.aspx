<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Coupons.aspx.cs" Inherits="GFCK.Manufacturer.Coupons" %>

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
    <tr><td><a href="/Admin/CouponAction.aspx?Mode=Add">Add Coupon</a></td></tr>
    <asp:Repeater ID="rptCoupons" runat="server">
        <HeaderTemplate>
            <thead>Value</thead>
            <thead>Discount</thead>
            <thead>Start Date</thead>
            <thead>Expiration Date</thead>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><label id="lblValue" runat="server" /></td>
                <td><label id="lblDiscount" runat="server" /></td>
                <td><label id="lblStartDate" runat="server" /></td>
                <td><label id="lblExpirationDate" runat="server" /></td>
                <td>
                    <a id="lnkEdit" href="/Admin/CouponAction.aspx?Mode=Edit&CouponID={0}" runat="server">Edit</a> | 
                    <a id="lnkView" href="/Admin/CouponAction.aspx?Mode=View&CouponID={0}" runat="server">View</a> | 
                    <asp:LinkButton id="lnkDelete" CommandName="Delete" Text="Delete" runat="server" />
                </td>
            </tr>
        </ItemTemplate>

        <AlternatingItemTemplate>
            <tr>
                <td><label id="lblManufacturerName" runat="server" /></td>
                <td><label id="lblEmail" runat="server" /></td>
                <td>
                    <a id="lnkEdit" href="/Admin/CouponAction.aspx?Mode=Edit&CouponID={0}" runat="server">Edit</a> | 
                    <a id="lnkView" href="/Admin/CouponAction.aspx?Mode=View&CouponID={0}" runat="server">View</a> | 
                    <asp:LinkButton id="lnkDelete" CommandName="Delete" Text="Delete" runat="server" />
                </td>
            </tr>
        </AlternatingItemTemplate>

        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
</table>



</asp:Content>
