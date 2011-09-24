<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="GFCK.UserControls.Header" %>
<div class="col1">
    <img src="/images/pixel_trans.gif" alt="" width="1" height="16" /><br />
    <a href="/default.aspx">
        <img src="/images/logo.jpg" alt="" height="64" /></a><br />
</div>
<div class="col2 user_menu">
    <img src="/images/pixel_trans.gif" alt="" width="1" height="48" /><br />
    <ul>
        <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
            <AnonymousTemplate>
                <li class="last"><a href="~/Account/Login.aspx" id="HeadLoginStatus" runat="server">Log In</a></li>
            </AnonymousTemplate>
            <LoggedInTemplate>
                <li class="last">Welcome <span class="bold">
                    <asp:LoginName ID="HeadLoginName" runat="server" />
                </span>!    [<asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutText="Log Out"
                        LogoutPageUrl="~/" />]</li>
            </LoggedInTemplate>
        </asp:LoginView>
    </ul>
    <div class="clear">
    </div>
</div>
<div class="clear">
</div>