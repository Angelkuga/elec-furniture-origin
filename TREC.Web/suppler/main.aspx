<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Member.Master" CodeBehind="main.aspx.cs" Inherits="TREC.Web.Suppler.main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maintitle"><h1><u>系统中心</u></h1></div> 
<div class="quickmenu">
        <div>
            <ul>
                
                <li><a href="brand/brandlist.aspx" class="b">
                    <img src="images/btn_my.gif" width="32" height="32" alt="" /><br />
                    <span class="f_red">管理品牌</span></a></li>
                
                <li><a href="brand/brandslist.aspx" class="b">
                    <img src="images/btn_message.gif" width="32" height="32" alt="" /><br />
                    管理系列</a></li>
                <li><a href="product/productInfo.aspx" class="b">
                    <img src="images/btn_style.gif" width="32" height="32" alt="" /><br />
                    添加产品</a></li>
                <li><a href="product/productList.aspx" class="b">
                    <img src="images/btn_edit.gif" width="32" height="32" alt="" /><br />
                    管理产品</a></li>
                <li><a href="shop/shopList.aspx" class="b">
                    <img src="images/btn_edit.gif" width="32" height="32" alt="" /><br />
                    管理店铺</a></li>
                
                <li><a href="member/memberInfo.aspx" class="b">
                    <img src="images/btn_favorite.gif" width="32" height="32" alt="" /><br />
                    修改联系人信息</a></li>
                
            </ul>
			<div class="clear"></div>
        </div>
</div>
<br />
<br />
<br />

<div class="pop bord">
<h1><u>提示信息</u><i>X</i></h1>
<div class="popcon">
<h2><img src="images/gz.gif" width="25" height="26" align="absmiddle" />注册已成功!</h2>
<p>欢迎来到家具快搜供应商中心，现在您可以<a href="product/productInfo.aspx">添加产品</a>了。</p>

<div class="btnone">
<input type="button" value="确定" class="btnlitl" />
<input name="button" type="button" value="取消" class="btnlitr" />
</div>
</div>
</div>
<div class="infotip">
（1）您有<span class="numred">1</span>个招商信息未通过审核。<br />
（2）您有<span class="numred">3</span>个待处理订单。<br />
（3）您有<span class="numred">5</span>条促销信息即将在3天内到期。</div>
</asp:Content>