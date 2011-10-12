<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftCategories.ascx.cs" Inherits="GFCK.UserControls.LeftCategories" %>
<div id="categories" style="width: 202px;" runat="server" class="categories">
<div class="box_head">
    <div class="innerbox1">
        <div class="innerbox2">
            <div class="innerbox3">
                <div class="innerbox4">
                    <div class="innerbox5">
                        <div class="innerbox6">
                            <div class="innerbox7">
                                <div class="innerbox8">
                                    <div class="innerbox9">
                                        Filters:
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="box">
    <div class="box_inner1">
        <div class="background-top-4">
            <div class="background-top-left-4">
                <div class="background-top-right-4">
                    <div class="background-bottom-left-4">
                        <div class="background-bottom-right-4">
                            <div class="background-bottom-right-44">
                                <div class="box-indent">
                                    <div class="box1_body">
                                        <div id="categoriesContent" class="sideBoxContent" style="vertical-align:top;">
                                            <asp:CheckBox ID="chkGF" runat="server" />&nbsp;&nbsp;Gluten Free<br />
                                            <asp:CheckBox ID="chkCF" runat="server" />&nbsp;&nbsp;Casein Free<br />
                                            <asp:CheckBox ID="chkDF" runat="server" />&nbsp;&nbsp;Dairy Free<br />
                                            <asp:CheckBox ID="chkEF" runat="server" />&nbsp;&nbsp;Egg Free<br />
                                            <asp:CheckBox ID="chkNF" runat="server" />&nbsp;&nbsp;Nut Free<br />
                                            <asp:Button ID="btnFilter" runat="server" Text="Apply Filters" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</div>
<div id="manufacturerCategories" style="width: 202px;" runat="server" class="manufacturers">
    <div class="box_head">
        <div class="innerbox1"><div class="innerbox2"><div class="innerbox3"><div class="innerbox4"><div class="innerbox5"><div class="innerbox6"><div class="innerbox7"><div class="innerbox8"><div class="innerbox9">
            <label>Functions</label>
        </div></div></div></div></div></div></div></div></div>
    </div>
    <div class="box">
        <div class="box_inner1"><div class="background-top-4"><div class="background-top-left-4"><div class="background-top-right-4"><div class="background-bottom-left-4"><div class="background-bottom-right-4"><div class="background-bottom-right-44"><div class="box-indent"><div class="box1_body">
            <div id="manufacturersContent" class="sideBoxContent">
                <ul style="margin: 0; padding: 0; list-style-type: none;">
                    <li class="category-top_un"><span class="top-span"><a href="/Manufacturer/">Manufacturer page</a></span></li>
                    <li><span class="top-span"><a href="/Manufacturer/action.aspx?Mode=Add">Add new coupon</a></span></li>
                </ul>
            </div>
        </div></div></div></div></div></div></div></div></div>
    </div>
</div>
<div id="adminCategories" style="width: 202px;" runat="server" class="manufacturers">
    <div class="box_head">
        <div class="innerbox1"><div class="innerbox2"><div class="innerbox3"><div class="innerbox4"><div class="innerbox5"><div class="innerbox6"><div class="innerbox7"><div class="innerbox8"><div class="innerbox9">
            <label>Admin Functions</label>
        </div></div></div></div></div></div></div></div></div>
    </div>
    <div class="box">
        <div class="box_inner1"><div class="background-top-4"><div class="background-top-left-4"><div class="background-top-right-4"><div class="background-bottom-left-4"><div class="background-bottom-right-4"><div class="background-bottom-right-44"><div class="box-indent"><div class="box1_body">
            <div id="manufacturersContent" class="sideBoxContent">
                <ul style="margin: 0; padding: 0; list-style-type: none;">
                    <li class="category-top_un"><span class="top-span"><a href="/Admin/">Admin page</a></span></li>
                    <li><span class="top-span"><a href="/Admin/action.aspx?Mode=Add">Add new manufacturer</a></span></li>
                </ul>
            </div>
        </div></div></div></div></div></div></div></div></div>
    </div>
</div>