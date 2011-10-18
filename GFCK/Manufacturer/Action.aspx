<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Manufacturer.Master" CodeBehind="Action.aspx.cs" Inherits="GFCK.Manufacturer.Action" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="/scripts/jquery-barcode-2.0.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#img1").hide();
            $("#MainContent_txtBarcode1Value").blur(function () {
                if ($("#MainContent_txtBarcode1Value").val() == "") {
                    $("#bcTarget1").hide();
                    $("#img1").hide();
                }
                else {
                    $("#bcTarget1").show();
                    if ($("#MainContent_ddlBarcode1Type").val() == "QR code") {
                        $("#bcTarget1").html("");
                        $("#img1").show();
                        $("#img1").attr("src", "http://chart.apis.google.com/chart?cht=qr&chs=100x100&chl=" + $("#MainContent_txtBarcode1Value").val());
                    }
                    else {
                        $("#bcTarget1").barcode($("#MainContent_txtBarcode1Value").val(), $("#MainContent_ddlBarcode1Type").val());
                        $("#img1").hide();
                        $("#bcTarget1").show();
                    }
                }
            });
            $("#MainContent_txtBarcode2Value").blur(function () {
                if ($("#MainContent_txtBarcode2Value").val() == "") {
                    $("#bcTarget2").hide();
                }
                else {
                    $("#bcTarget2").show();
                    $("#bcTarget2").barcode($("#MainContent_txtBarcode2Value").val(), $("#MainContent_ddlBarcode2Type").val());
                }
            });

        });

    </script>

    <script type="text/javascript">
        $(function () {

            // Datepicker
            $('.datepicker').datepicker({
                inline: true
            });

            //hover states on the static widgets
            $('#dialog_link, ul#icons li').hover(
					function () { $(this).addClass('ui-state-hover'); },
					function () { $(this).removeClass('ui-state-hover'); }
				);

        });
		</script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="column-center-background">
    <div class="centerColumn" id="advSearchResultsDefault">

<div id="divAddCoupon" runat="server">
        <div class="title_box">
	        <div class="row1">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><img src="/images/pixel_trans.gif" alt="" width="1" height="1" /></div>
            </div></div></div>
	        <div class="row2">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><div class="title_inner4"><div class="title_inner5"><div class="title_inner6"><div class="title_inner7">
    	            <h2 id="newProductsDefaultHeading">Add Coupon</h2>
                </div></div></div></div></div></div></div>
            </div>
        </div>
</div>
<div id="divEditCoupon" runat="server">
        <div class="title_box">
	        <div class="row1">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><img src="/images/pixel_trans.gif" alt="" width="1" height="1" /></div>
            </div></div></div>
	        <div class="row2">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><div class="title_inner4"><div class="title_inner5"><div class="title_inner6"><div class="title_inner7">
    	            <h2 id="newProductsDefaultHeading">Edit Coupon</h2>
                </div></div></div></div></div></div></div>
            </div>
        </div>
</div>

<div>
    <asp:Label ID="lblAddSuccessfull" runat="server" CssClass="messageStackError" Text="Added coupon successfully." Visible="false" />
    <asp:Label ID="lblEditSuccessfull" runat="server" CssClass="messageStackError" Text="Updated coupon successfully." Visible="false" />
    <asp:Label ID="lblError" runat="server" CssClass="messageStackError" Text="An error has occured." Visible="false" />
</div>

<fieldset id="couponInformation" runat="server">
<legend>Coupon Information</legend>
<div class="alert forward">* Required information</div>
<br class="clearBoth" /> 
 
<label class="inputLabel">Name this coupon:</label>
<asp:TextBox ID="txtName" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
<br />
<label class="inputLabel">Category:</label>
<asp:DropDownList ID="ddlCategory" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
<br />
<label class="inputLabel">Image:</label>
<asp:FileUpload ID="imgUpload" runat="server" CssClass="tblarge" Width="400px" /><span class="alert">*</span><br class="clearBoth" />
 <br />
 <table>
 <tr><td>
<label class="inputLabel">Value:</label>
<asp:TextBox ID="txtValue" runat="server" CssClass="tbsmall" /><span class="alert">*</span><br class="clearBoth" />
 </td>
 <td width="100px"></td>
 <td>
<label class="inputLabel">Start Date:</label>
<asp:TextBox ID="txtStartDate" runat="server" CssClass="datepicker tbsmall" /><span class="alert">*</span><br class="clearBoth" />
</td> </tr></table>
 <table>
 <tr><td>
<label class="inputLabel">Discount:</label>
<asp:TextBox ID="txtDiscount" runat="server" CssClass="tbsmall" /><span class="alert">*</span><br class="clearBoth" />
 </td>
 <td width="100px"></td>
 <td>
<label class="inputLabel">Expiration Date:</label>
<asp:TextBox ID="txtExpirationDate" runat="server" CssClass="datepicker tbsmall" /><span class="alert">*</span><br class="clearBoth" />
 </td> </tr></table>
 <br />
<label class="inputLabel">Number of Coupons:</label>
<asp:TextBox ID="txtNumberOfCoupons" runat="server" CssClass="tbsmall" /><span class="alert">*</span><br class="clearBoth" />
 <br />
<label class="inputLabel">Details:</label>
<asp:TextBox ID="txtDetails" runat="server" CssClass="tblarge" TextMode="MultiLine" /><span class="alert">*</span><br class="clearBoth" />
 <br />
<label class="inputLabel">Terms:</label>
<asp:TextBox ID="txtTerms" runat="server" CssClass="tblarge" TextMode="MultiLine" /><span class="alert">*</span><br class="clearBoth" />
 <br />
 <table width="600px">
 <tr><td width="33%">
<label class="inputLabel">Gluten Free Faclility:</label>
<asp:CheckBox ID="chkGlutenFreeFacility" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td width="33%">
<label class="inputLabel">Contain Gluten 20PPM:</label>
<asp:CheckBox ID="chkContainGluten20PPM" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td width="33%">
<label class="inputLabel">Less Than 5PPM:</label>
<asp:CheckBox ID="chkLessThan5PPM" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 </tr>
 <tr><td>
<label class="inputLabel">Casein Free:</label>
<asp:CheckBox ID="chkCaseinFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td>
<label class="inputLabel">Soy Free:</label>
<asp:CheckBox ID="chkSoyFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td>
<label class="inputLabel">Nut Free:</label>
<asp:CheckBox ID="chkNutFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 </tr>
 <tr>
 <td>
<label class="inputLabel">Egg Free:</label>
<asp:CheckBox ID="chkEggFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td>
<label class="inputLabel">Corn Free:</label>
<asp:CheckBox ID="chkCornFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td>
<label class="inputLabel">Yeast Free:</label>
<asp:CheckBox ID="chkYeastFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td> </tr></table>
 <br />
<label class="inputLabel">Barcode 1:</label>
<select id="ddlBarcode1Type" runat="server">
<option value="std25">std25</option>
<option value="int25">int25</option>
<option value="ean8">ean8</option>
<option value="ean13">ean13</option>
<option value="code11">code11</option>
<option value="code39">code39</option>
<option value="code93">code93</option>
<option value="code128">code128</option>
<option value="codabar">codabar</option>
<option value="QR code">QRcode</option>
<option value="msi">msi</option>
<option value="datamatrix">datamatrix</option>
</select>
<asp:TextBox ID="txtBarcode1Value" runat="server" CssClass="tbsmall" />
<div style="padding-right:50px;float:right;height:65px;"><div id="bcTarget1"><img id="img1" /></div></div><br class="clearBoth" />
 
<label class="inputLabel">Barcode 2:</label>
<select id="ddlBarcode2Type" runat="server">
<option value="std25">std25</option>
<option value="int25">int25</option>
<option value="ean8">ean8</option>
<option value="ean13">ean13</option>
<option value="code11">code11</option>
<option value="code39">code39</option>
<option value="code93">code93</option>
<option value="code128">code128</option>
<option value="codabar">codabar</option>
<option value="msi">msi</option>
<option value="datamatrix">datamatrix</option>
</select>
<asp:TextBox ID="txtBarcode2Value" runat="server" CssClass="tbsmall" />
<div style="padding-right:50px;float:right;height:65px;"><div id="bcTarget2"></div></div><br class="clearBoth" />
 
 <!---
<label class="inputLabel">Bottom Advertisement:</label>
<asp:TextBox ID="txtBottomAdvertisement" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 -->
</fieldset>
<div class="buttonRow forward"><asp:ImageButton ID="btnCancel" runat="server" AlternateText="Cancel" ImageUrl="/images/buttons/english/button_cancel.gif" PostBackUrl="/Manufacturer/default.aspx" /></div>
<div class="buttonRow forward"><asp:ImageButton ID="btnSave" runat="server" AlternateText="Submit" OnClick="btnSave_Click" ImageUrl="/images/buttons/english/button_submit.gif" /></div>

    </div></div><br /><br /><br /><br />
</asp:Content>
