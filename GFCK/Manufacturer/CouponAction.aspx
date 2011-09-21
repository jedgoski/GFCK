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
    <asp:Label ID="lblAddSuccessfull" runat="server" Text="Added manufacturer successfully." Visible="false" />
    <asp:Label ID="lblEditSuccessfull" runat="server" Text="Updated manufacturer successfully." Visible="false" />
    <asp:Label ID="lblError" runat="server" Text="An error has occured." Visible="false" />
</div>

Template: <asp:DropDownList ID="ddlTemplate" runat="server"></asp:DropDownList>
Category: <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
Image: 
Value:<asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
Discount:<asp:TextBox ID="txtDiscount" runat="server"></asp:TextBox>
Details:<asp:TextBox ID="txtDetails" runat="server"></asp:TextBox>
Terms:<asp:TextBox ID="txtTerms" runat="server"></asp:TextBox>
Start Date:<asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
Expiration Date: <asp:TextBox ID="txtExpirationDate" runat="server"></asp:TextBox>
Gluten Free Faclility: <asp:CheckBox ID="chkGlutenFreeFacility" runat="server" />
Contain Gluten 20PPM: <asp:CheckBox ID="chkContainGluten20PPM" runat="server" />
Less Than 5PPM: <asp:CheckBox ID="chkLessThan5PPM" runat="server" />
Casein Free: <asp:CheckBox ID="chkCaseinFree" runat="server" />
Soy Free: <asp:CheckBox ID="chkSoyFree" runat="server" />
Nut Free: <asp:CheckBox ID="chkNutFree" runat="server" />
Egg Free: <asp:CheckBox ID="chkEggFree" runat="server" />
Corn Free: <asp:CheckBox ID="chkCornFree" runat="server" />
Yeast Free: <asp:CheckBox ID="chkYeastFree" runat="server" />
Barcode 1 Enabled: <asp:CheckBox ID="chkBarcode1Enabled" runat="server" />
Barcode 1 Type: <asp:DropDownList ID="ddlBarcode1TypeID" runat="server"></asp:DropDownList>
Barcode 1 Value: <asp:TextBox ID="txtBarcode1Value" runat="server"></asp:TextBox>
Barcode 2 Enabled: <asp:CheckBox ID="chkBarcode2Enabled" runat="server" />
Barcode 2 Type: <asp:DropDownList ID="ddlBarcode2TypeID" runat="server"></asp:DropDownList>
Barcode 2 Value: <asp:TextBox ID="txtBarcode2Value" runat="server"></asp:TextBox>
Number of Coupons <asp:TextBox ID="txtNumberOfCoupons" runat="server"></asp:TextBox>
Bottom Advertisement <asp:TextBox ID="txtBottomAdvertisement" runat="server"></asp:TextBox>

<asp:Button ID="btnSave" runat="server" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" PostBackUrl="/Admin/ManufacturerAdmin.aspx" />

</asp:Content>
