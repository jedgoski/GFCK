<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Coupons.aspx.cs" Inherits="GFCK.Manufacturer.Coupons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1>Manufacturer Admin</h1>
<div>
    <asp:Label ID="lblDeleteSuccessfull" runat="server" CssClass="messageStackError" Text="Deleted manufacturer successfully." Visible="false" />
    <asp:Label ID="lblDeleteError" runat="server" CssClass="messageStackError" Text="Cannot delete manufacturer at this time." Visible="false" />
    <asp:Label ID="lblError" runat="server" CssClass="messageStackError" Text="An error has occured." Visible="false" />
</div>
<div>
    <a href="/Manufacturer/Action.aspx?Mode=Add">Add Coupon</a>
</div>
<table>
    
    <asp:Repeater ID="rptCoupons" runat="server">
        <HeaderTemplate>
        <tr>
            <thead><b>Value</b></thead>
            <thead><b>Discount</b></thead>
            <thead><b>Start Date</b></thead>
            <thead><b>Expiration Date</b></thead>
            <thead><b>Action</b></thead>
        </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><asp:label id="lblValue" runat="server" /></td>
                <td><asp:label id="lblDiscount" runat="server" /></td>
                <td><asp:label id="lblStartDate" runat="server" /></td>
                <td><asp:label id="lblExpirationDate" runat="server" /></td>
                <td>
                    <a id="lnkEdit" href="/Manufacturer/Action.aspx?Mode=Edit&CouponID={0}" runat="server">Edit</a> | 
                    <a id="lnkView" href="/Manufacturer/Action.aspx?Mode=View&CouponID={0}" runat="server">View</a> | 
                    <asp:LinkButton id="lnkDelete" CommandName="Delete" Text="Delete" runat="server" />
                </td>
            </tr>
        </ItemTemplate>

        <AlternatingItemTemplate>
            <tr>
               <td><asp:label id="lblValue" runat="server" /></td>
                <td><asp:label id="lblDiscount" runat="server" /></td>
                <td><asp:label id="lblStartDate" runat="server" /></td>
                <td><asp:label id="lblExpirationDate" runat="server" /></td>
                <td>
                    <a id="lnkEdit" href="/Manufacturer/CouponAction.aspx?Mode=Edit&CouponID={0}" runat="server">Edit</a> | 
                    <a id="lnkView" href="/Manufacturer/CouponAction.aspx?Mode=View&CouponID={0}" runat="server">View</a> | 
                    <asp:LinkButton id="lnkDelete" CommandName="Delete" Text="Delete" runat="server" />
                </td>
            </tr>
        </AlternatingItemTemplate>

        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
</table>



</asp:Content>
