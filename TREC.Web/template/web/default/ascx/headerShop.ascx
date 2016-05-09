<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headerShop.ascx.cs"
    Inherits="TREC.Web.aspx.ascx.headerShop" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/oms_autocomplate.js"></script>
<script>
    $(function () {
        var url = document.URL.toLowerCase();
        $("#searchKey").oms_autocomplate({ url: "/ajax/search.ashx", inputWidth: 339, inputHeight: 32, paramTypeSelector: "#searchTypeList>a.Searcha" });
        $('#kslkcon>.inner,#ksbrandcon>inner').html('正在加载数据中...');
 
        //搜索条 绑定类型为产品搜索
        $("#topSearchBtn").click(function () {
            //window.top.location = "<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>" + "/search.aspx?type=product&key=" + encodeURIComponent($("#searchKey").val().replace(/\-/g, "abc111"));


            window.location.href = "<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlist.aspx?k=" + escape($("#searchKey").val());

        });
    });
</script>
<div class="header">
    <div class="hd w">
        <ul class="clearfix fl left">
            <li class="li1">给您最全的家具购买资讯</li>
            <li class="li4"><a href="##" onclick='addToFavorite();'>收藏</a></li>
              <li class="li7">

          <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=2285277787&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:2285277787:41" alt="点击这里给我发消息" title="点击这里给我发消息" style="margin-top:3px;"/></a>
            </li>
        </ul>
        <ul class="fr clearfix right">
            <li>欢迎您来到家具快搜 &nbsp;|&nbsp;</li>
            <%if (TRECommon.CookiesHelper.GetCookieCustomer("cid") != "")
              { %>
                <li><strong style="color: #0000FF;">[<%=TRECommon.CookiesHelper.GetCookieCustomer("cname")%>]</strong></li>
                <li></li>
                <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/logoutuser.aspx">[退出]</a>
            <%}
              else if (TRECommon.CookiesHelper.GetCookie("mid") != "" && TRECommon.CookiesHelper.GetCookie("mname") != "")
              { %>
                <li><a href="<%=TREC.ECommerce.ECommon.WebSupplerUrl.TrimEnd('/') %>/suppler/index.aspx">
                <strong>[<%=TRECommon.CookiesHelper.GetCookie("mname") != "" && TRECommon.CookiesHelper.GetCookie("mname").Length > 7 ? TRECommon.CookiesHelper.GetCookie("mname").Substring(0, 7) + ".." : TRECommon.CookiesHelper.GetCookie("mname")%>]</strong>
                </a></li>
                <li></li>
                <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/loginout.aspx">[退出]</a></li>
            <%}else{ %>
                <li><a href="/loginuser.aspx">登录</a> &nbsp;|&nbsp; </li>
                <li><a href="/reguser.aspx">注册</a> </li>
            <%} %>
        </ul>
    </div>
</div>
<div class="header-box">
    <div class="w clearfix header-border">

        <div class="logo fl">
        <a href='/' style="position: absolute; top: 5px; left: 5px; width: 140px; height: 45px;
                z-index: 2px;"></a>
            <div class="citys">
                <a class="a0" href="#">上海</a>
                <ul class="clearfix">
                    <li>全国</li>
                    <li>上海</li>
                    <li>广州</li>
                    <li>深圳</li>
                </ul>
            </div>
        </div>
        <div class="fl search">
            <input type="text" class="text" name="searchKey" id="searchKey" placeholder="明星家具盛惠，1元拍爆款家具，抢码最高省4500！" /><input
                class="button" type="button" name="topSearchBtn" id="topSearchBtn" value="搜索" />
            <div class="hot" style="border: 0px solid #cacaca;">

                 <a class="a-on" target="_blank"  href="/Dealer/index.aspx?did=84">楷模</a>  <a target="_blank" href="/company/210/index.aspx">北欧E家</a> 
            <a href="/51/default.aspx" target="_blank"> 品牌团购</a> <a target="_blank" href="/productlisttbb.aspx">名品折扣</a> 
             <a target="_blank" href="/productlist.aspx?did=7">家具精选</a>  <a target="_blank" href="/productlisttbb.aspx?xid=50&did=11">特价书柜</a>
                    </div>
        </div>
        <%--<div class="fr f14 box-r b">
            <span style='border-right:none'><a href='<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/reg.aspx'>供应商登录</a></span> <a   href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/reg.aspx">申请入驻 </a>
        </div>--%>
         <div class="fr f14 box-r b">
            <a  style="border-left:1px solid #c5c5c4;" href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/reg.aspx">供应商登录</a><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/reg.aspx">申请入驻 </a>
        </div>
    </div>
    <div class="w clearfix">
        <h4 class="yahei fl">
            <%=shopInfo.title %></h4>
        <%foreach (ShopBrand b in shopInfo.ShopBrandList)
          { %>
        <a class="fr" title="<%=shopInfo.BrandName.Replace(",", " ")%>" href="<%=string.Format(EnUrls.CompanyInfoBrandList,b.companyid,b.id)%>"
            target="_blank">
            <img alt="<%=shopInfo.BrandName.Replace(",", " ")%>" src="<%=EnFilePath.GetBrandLogoPath(b.id,b.thumb) %>"
                width="105" height="38" /></a>
        <%} %>
    </div>
</div>
<div class="nav seller-nav">
    <div class="nav-box w clearfix">
        <div class="main-nav fl" id="j_navTab">
        </div>

    
        <ul class="nav-title fl" id="j_menuTab">
            <li class="on"><a href="<%=string.Format(EnUrls.ShopInfoIndex,ECommon.QuerySId) %>"
                class="nav-item">首 页</a> </li>
            <li class="nav-brand"><a target="_blank" href="/company/<%=shopInfo.ShopBrandInfo.companyid %>/index.aspx" class="nav-item">工厂</a> </li>
            <li><a target="_blank" href="<%=string.Format(EnUrls.CompanyInfoIndex, shopInfo.ShopBrandInfo.companyid) %>" class="nav-item">品牌介绍</a> </li>
            <li><a href="<%=string.Format(EnUrls.ShopInfoProduct,ECommon.QuerySId) %>" class="nav-item">
                全部产品</a></li>
            <li style="display:none;"><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/company/<%=shopInfo.ShopBrandInfo.companyid %>/Merchants.aspx" class="nav-item">招商信息</a></li>
            <li><a href="<%=string.Format(EnUrls.ShopInfoPromotions, ECommon.QuerySId) %>" class="nav-item">
                促销活动</a></li>
            <li><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/news/list.aspx" class="nav-item" style="display:none;">公司新闻</a></li>
            <li><a href="<%=string.Format(EnUrls.ShopInfoAddress,ECommon.QuerySId) %>" class="nav-item">
                交通乘车路线</a></li>
        </ul>
     
    </div>
</div>
