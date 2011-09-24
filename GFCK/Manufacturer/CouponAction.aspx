<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CouponAction.aspx.cs" Inherits="GFCK.Manufacturer.CouponAction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="divAddCoupon" runat="server">
<h1>Add Coupon</h1>
</div>
<div id="divEditCoupon" runat="server">
<h1>Edit Coupon</h1>
</div>
<div id="divViewCoupon" runat="server">
<h1>View coupon</h1>
</div>

<div>
    <asp:Label ID="lblAddSuccessfull" runat="server" CssClass="messageStackError" Text="Added manufacturer successfully." Visible="false" />
    <asp:Label ID="lblEditSuccessfull" runat="server" CssClass="messageStackError" Text="Updated manufacturer successfully." Visible="false" />
    <asp:Label ID="lblError" runat="server" CssClass="messageStackError" Text="An error has occured." Visible="false" />
</div>

<table>
<tr><td>Template:</td><td><asp:DropDownList ID="ddlTemplate" runat="server"></asp:DropDownList></td></tr>
<tr><td>Category:</td><td><asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList></td></tr>
<tr><td>Image:</td><td><asp:FileUpload ID="imgUpload" runat="server" /></td></tr>
<tr><td>Value:</td><td><asp:TextBox ID="txtValue" runat="server"></asp:TextBox></td></tr>
<tr><td>Discount:</td><td><asp:TextBox ID="txtDiscount" runat="server"></asp:TextBox></td></tr>
<tr><td>Details:</td><td><asp:TextBox ID="txtDetails" runat="server"></asp:TextBox></td></tr>
<tr><td>Terms:</td><td><asp:TextBox ID="txtTerms" runat="server"></asp:TextBox></td></tr>
<tr><td>Start Date:</td><td><asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox></td></tr>
<tr><td>Expiration Date:</td><td><asp:TextBox ID="txtExpirationDate" runat="server"></asp:TextBox></td></tr>
<tr><td>Gluten Free Faclility:</td><td><asp:CheckBox ID="chkGlutenFreeFacility" runat="server" /></td></tr>
<tr><td>Contain Gluten 20PPM:</td><td><asp:CheckBox ID="chkContainGluten20PPM" runat="server" /></td></tr>
<tr><td>Less Than 5PPM:</td><td><asp:CheckBox ID="chkLessThan5PPM" runat="server" /></td></tr>
<tr><td>Casein Free:</td><td><asp:CheckBox ID="chkCaseinFree" runat="server" /></td></tr>
<tr><td>Soy Free:</td><td><asp:CheckBox ID="chkSoyFree" runat="server" /></td></tr>
<tr><td>Nut Free:</td><td><asp:CheckBox ID="chkNutFree" runat="server" /></td></tr>
<tr><td>Egg Free:</td><td><asp:CheckBox ID="chkEggFree" runat="server" /></td></tr>
<tr><td>Corn Free:</td><td><asp:CheckBox ID="chkCornFree" runat="server" /></td></tr>
<tr><td>Yeast Free:</td><td><asp:CheckBox ID="chkYeastFree" runat="server" /></td></tr>
<tr><td>Barcode 1 Enabled:</td><td><asp:CheckBox ID="chkBarcode1Enabled" runat="server" /></td></tr>
<tr><td>Barcode 1 Type:</td><td><asp:DropDownList ID="ddlBarcode1TypeID" runat="server"></asp:DropDownList></td></tr>
<tr><td>Barcode 1 Value:</td><td><asp:TextBox ID="txtBarcode1Value" runat="server"></asp:TextBox></td></tr>
<tr><td>Barcode 2 Enabled:</td><td><asp:CheckBox ID="chkBarcode2Enabled" runat="server" /></td></tr>
<tr><td>Barcode 2 Type:</td><td><asp:DropDownList ID="ddlBarcode2TypeID" runat="server"></asp:DropDownList></td></tr>
<tr><td>Barcode 2 Value:</td><td><asp:TextBox ID="txtBarcode2Value" runat="server"></asp:TextBox></td></tr>
<tr><td>Number of Coupons</td><td><asp:TextBox ID="txtNumberOfCoupons" runat="server"></asp:TextBox></td></tr>
<tr><td>Bottom Advertisement</td><td><asp:TextBox ID="txtBottomAdvertisement" runat="server"></asp:TextBox></td></tr>
</table>


<asp:Button ID="btnSave" runat="server" Text="save" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" PostBackUrl="/Admin/ManufacturerAdmin.aspx" />

</asp:Content>
