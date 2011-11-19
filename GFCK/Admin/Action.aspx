<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Action.aspx.cs" Inherits="GFCK.Admin.Action" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="column-center-background">
    <div class="centerColumn" id="advSearchResultsDefault">

<div id="divAddManufacturer" runat="server">
        <div class="title_box">
	        <div class="row1">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><img src="/images/pixel_trans.gif" alt="" width="1" height="1" /></div>
            </div></div></div>
	        <div class="row2">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><div class="title_inner4"><div class="title_inner5"><div class="title_inner6"><div class="title_inner7">
    	            <h2 id="newProductsDefaultHeading">Add Manufacturer</h2>
                </div></div></div></div></div></div></div>
            </div>
        </div>
</div>
<div id="divEditManufacturer" runat="server">
        <div class="title_box">
	        <div class="row1">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><img src="/images/pixel_trans.gif" alt="" width="1" height="1" /></div>
            </div></div></div>
	        <div class="row2">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><div class="title_inner4"><div class="title_inner5"><div class="title_inner6"><div class="title_inner7">
    	            <h2 id="newProductsDefaultHeading">Edit Manufacturer</h2>
                </div></div></div></div></div></div></div>
            </div>
        </div>
</div>
<div id="divViewManufacturer" runat="server">
        <div class="title_box">
	        <div class="row1">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><img src="/images/pixel_trans.gif" alt="" width="1" height="1" /></div>
            </div></div></div>
	        <div class="row2">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><div class="title_inner4"><div class="title_inner5"><div class="title_inner6"><div class="title_inner7">
    	            <h2 id="newProductsDefaultHeading">View Manufacturer</h2>
                </div></div></div></div></div></div></div>
            </div>
        </div>
</div>

<div>
    <asp:Label ID="lblAddSuccessfull" runat="server" CssClass="messageStackError" Text="Added manufacturer successfully." Visible="false" />
    <asp:Label ID="lblAddUserSuccess" runat="server" CssClass="messageStackError" Text="User added successfully." Visible="false" />
    <asp:Label ID="lblEditSuccessfull" runat="server" CssClass="messageStackError" Text="Updated manufacturer successfully." Visible="false" />
    <asp:Label ID="lblDeleteSuccessfull" runat="server" CssClass="messageStackError" Text="Deleted manufacturer successfully." Visible="false" />
    <asp:Label ID="lblActivateSuccessfull" runat="server" CssClass="messageStackError" Text="Activated manufacturer successfully." Visible="false" />
    <asp:Label ID="lblError" runat="server" CssClass="messageStackError" Text="An error has occured." Visible="false" />
</div>

<fieldset id="accountInformation" runat="server">
<legend>Account Information</legend>
<div class="alert forward">* Required information</div>
<br class="clearBoth" /> 
 
<label class="inputLabel">Login Name:</label>
<asp:TextBox ID="txtUserName" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 <div id="divPassword" runat="server">
<label class="inputLabel">Password:</label>
<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 
<label class="inputLabel">Confirm Password:</label>
<asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 </div>
</fieldset>
 
<fieldset id="addUser" runat="server" visible="false">
<legend>Add another account</legend>
<div class="alert forward">* Required information</div>
<br class="clearBoth" /> 
 
<label class="inputLabel">Login Name:</label>
<asp:TextBox ID="txtNewUserName" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />

<label class="inputLabel">Password:</label>
<asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 
<label class="inputLabel">Confirm Password:</label>
<asp:TextBox ID="txtNewConfirmPassword" runat="server" TextMode="Password" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />

<label class="inputLabel">Email:</label>
<asp:TextBox ID="txtNewEmail" runat="server" CssClass="tblarge" /><span class="alert">*</span>
 <div class="buttonRow forward"><asp:ImageButton ID="btnAddUser" runat="server" AlternateText="Submit" OnClick="btnAddUser_Click" ImageUrl="/images/buttons/english/button_add.gif" /></div>
</fieldset>
 
<fieldset id="profileInformation" runat="server">
<legend>Profile Information</legend>
<div class="alert forward">* Required information</div>
<br class="clearBoth" /> 
 
<label class="inputLabel">Manufacturer Name:</label>
<asp:TextBox ID="txtManufacturerName" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 
<label class="inputLabel">First Name:</label>
<asp:TextBox ID="txtFirstName" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 
<label class="inputLabel">Last Name:</label>
<asp:TextBox ID="txtLastName" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 
<label class="inputLabel">Email:</label>
<asp:TextBox ID="txtEmail" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 
<label class="inputLabel">Phone Number:</label>
<asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 
<label class="inputLabel">Address:</label>
<asp:TextBox ID="txtAddress" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 
<label class="inputLabel">&nbsp;</label>
<asp:TextBox ID="txtAddress2" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 
<label class="inputLabel">City:</label>
<asp:TextBox ID="txtCity" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 
<label class="inputLabel">State:</label>
<asp:TextBox ID="txtState" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 
<label class="inputLabel">Zip:</label>
<asp:TextBox ID="txtZip" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 
<label class="inputLabel">Description:</label>
<asp:TextBox ID="txtDescription" textMode="MultiLine" runat="server" Rows="5" />
</fieldset>
 
<div class="buttonRow forward"><asp:ImageButton ID="btnCancel" runat="server" AlternateText="Cancel" ImageUrl="/images/buttons/english/button_cancel.gif" PostBackUrl="/Admin/default.aspx" /></div>
<div class="buttonRow forward"><asp:ImageButton ID="btnSave" runat="server" AlternateText="Submit" OnClick="btnSave_Click" ImageUrl="/images/buttons/english/button_submit.gif" /></div>


    </div></div><br /><br /><br /><br />
</asp:Content>
