<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ucenter.ascx.cs" Inherits="TREC.Web.template.web.ascx.Ucenter" %>
<div class="spL">
    <div class="spFocus">
        <h2>您好  <%=userName%></h2>
        <p class="p0">欢迎您回来</p>
        <p class="p2">
        <a href="/logoutuser.aspx"><img src="/resource/content/images/ucenter/user1.jpg" /></a>
          </p>           
        <p class="p1 p1Trim1">
            
            <span style="display:none;">上次登陆时间 :2015-4-6 10:06:40</span>
        </p>
    </div>
    <div id="leftURLControl" class="spColumn">
        <div class="block1">
            <h2>购物管理</h2>
            <div class="d1">
                <p><a href="/Ucenter/UserOrderList.aspx" class="a1 cur">我的订单</a></p>
                <p><a href="/Ucenter/UserOrderList.aspx" class="a1 ">我的团购订单</a></p>
            </div>
        </div>
        
        
        <div class="block1">
            <h2>账户管理</h2>
            <div class="d1">
                
                <p><a href="/Ucenter/Default.aspx" class="a1 ">收货地址</a></p>
                <p><a href="/Ucenter/ModifyPwd.aspx" class="a1 ">修改密码</a></p>
            </div>
        </div>
        <div class="block1">
            <h2>服务中心</h2>
            <div class="d1">
                <p><a class="" href="http://www.jiajuks.com/service/default.aspx">帮助中心</a></p>
            </div>
        </div>
    </div>
</div>