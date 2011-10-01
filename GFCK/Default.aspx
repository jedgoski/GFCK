<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="GFCK._Default" %>
<%@ Register Src="/UserControls/Coupon/home.ascx" TagPrefix="uc1" TagName="CouponDisplay" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table class="banner_block">
        <tr>
            <td class="td_banner_block">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <!-- bof BANNERS GROUPSET 1 -->
                            <img src="/images/pixel_trans.gif" alt="" width="1" height="1" /><br />
                            <div>
                                <a href="#">
                                    <img src="/images/banner1.jpg" alt="free shipping" title=" free shipping "
                                        /></a></div>
                            <img src="/images/pixel_trans.gif" alt="" width="1" height="12" /><br />
                            <!-- eof BANNERS GROUPSET 1 -->
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <!--content_center-->
    <div class="centerColumn" id="indexDefault">
        <div id="indexDefaultMainContent" class="content">
        </div>
        <!-- bof: featured products  -->
        <div class="centerBoxWrapper" id="featuredProducts">
            <div class="title_box">
                <div class="row1">
                    <div class="title_inner1">
                        <div class="title_inner2">
                            <div class="title_inner3">
                                <img src="/images/pixel_trans.gif" alt="" width="1" height="1" /></div>
                        </div>
                    </div>
                </div>
                <div class="row2">
                    <div class="title_inner1">
                        <div class="title_inner2">
                            <div class="title_inner3">
                                <div class="title_inner4">
                                    <div class="title_inner5">
                                        <div class="title_inner6">
                                            <div class="title_inner7">
                                                <h2 class="centerBoxHeading">
                                                    Available Coupons</h2>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--                                        <div class="maintep" style="margin-bottom:0px;">
                                                    <div class="row11">
                                                        <div class="inn1">
                                                            <div class="inn2"><img src="/images/pixel_trans.gif" alt="" width="1" height="1" /></div>
                                                        </div>
                                                    </div>
                                                    <div class="row22">
                                                        <div class="inn1">
                                                            <div class="inn2">
 
            -->
                    <asp:Repeater ID="rptCoupons" runat="server" OnItemDataBound="rptCoupons_ItemDataBound" >
                    <ItemTemplate>
                        <uc1:CouponDisplay ID="cd" runat="server" />
                    </ItemTemplate>
                    </asp:Repeater>
            
            <!--
                                                        </div>
                                                    </div></div>
                                                    <div class="row33">
                                                        <div class="inn1">
                                                            <div class="inn2"><img src="/images/pixel_trans.gif" alt="" width="1" height="1" /></div>
                                                    </div>
                                                </div>
                                               </div>
-->
            <!-- eof: featured products  -->
        </div>
        <br />
    </div>
    <!--eof content_center-->
    <div class="clear">
    </div>
</asp:Content>
