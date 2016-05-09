<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeadDealer.ascx.cs" Inherits="TREC.Web.template.web.ascx.HeadDealer" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/oms_autocomplate.js"></script>
<script type="text/javascript">
    $(function () {
        var url = document.URL.toLowerCase();
        $("#searchKey").oms_autocomplate({ url: "/ajax/search.ashx", inputWidth: 339, inputHeight: 32, paramTypeSelector: "#searchTypeList>a.Searcha" });
        $('#kslkcon>.inner,#ksbrandcon>inner').html('正在加载数据中...');
        //搜索条 绑定类型为产品搜索
        $("#topSearchBtn").click(function () {
            window.top.location = "<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>" + "/search.aspx?type=product&key=" + encodeURIComponent($("#searchKey").val().replace(/\-/g, "abc111"));
        });
    });
    function addToFavorite() {
        var a = "http://www.jiajuks.com",
b = "家具快搜jiajuks.com-购买家具";
        document.all ? window.external.AddFavorite(a, b) : window.sidebar && window.sidebar.addPanel ? window.sidebar.addPanel(b, a, "") : alert("\u5bf9\u4e0d\u8d77\uff0c\u60a8\u7684\u6d4f\u89c8\u5668\u4e0d\u652f\u6301\u6b64\u64cd\u4f5c!\n\u8bf7\u60a8\u4f7f\u7528\u83dc\u5355\u680f\u6216Ctrl+D\u6536\u85cf\u672c\u7ad9\u3002");
    }
</script>
<!--头部文件开始-->
<style>
.nav-box .pull-down li dd .inner-img img{float: left;width: 110px;height: 36px;margin: 3px;}
</style>
<div class="header">
    <div class="hd w">
        <ul class="clearfix fl left">
            <li class="li1">给您最全的家具购买资讯</li>
            <li class="li2"><span><a href='/company-brand/list.aspx' style='color:Red'  target="_blank">
                <%=_htb["bcount"]%></a></span>个品牌</li>
            <li class="li3"><span><a href='/product/list.aspx' style='color:Red' target="_blank">
                <%=_htb["pcount"]%></a></span>个商品</li>
            <li class="li4"><a href="#" onclick='addToFavorite();'>
                收藏</a></li>
           
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
                <li><img src="/resource/images/400.gif" style="margin-top:6px;padding-left:8px;" /> </li>
            <li><a href="/reg.aspx" style="margin-left:10px;">商家入驻</a> </li>
            <%} %>
        </ul>
    </div>
</div>
<div class="header-box">
    <div class="w clearfix">
        <div class="logo fl" style=' position:relative;' >
        <a href='/' style="position:absolute; top:5px;left:5px; width:140px; height:45px; z-index:2px;"></a>
            <div class="citys">
                <a class="a0" href="#">上海</a>
                <ul class="clearfix">
                    <li><a href='##'>全国</a></li>
                    <li>上海</li>
                    <li>广州</li>
                    <li>深圳</li>
                </ul>
            </div>
        </div>
        <div class="fl search">
            <div class="logo-s-t" id="searchTypeList" style="display: none;">
                <a id="T_product" title="product" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("searchtype", "product", "", "Searcha")%><%=TREC.ECommerce.UiCommon.QueryStringCur("searchtype", "", "", "Searcha")%>">
                    搜产品</a> <a id="T_brand" title="brand" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("searchtype", "brand", "", "Searcha")%>">
                        搜品牌</a> <a id="T_market" title="market" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("searchtype", "market", "", "Searcha")%>">
                            搜卖场</a>
            </div>
            <input type="text" class="text" name="searchKey" id="searchKey" placeholder="明星家具盛惠，1元拍爆款家具，抢码最高省4500！" /><input
                class="button" type="button" name="topSearchBtn" id="topSearchBtn" value="搜索" />
            <div class="hot" style="border: 0px solid #cacaca;">

                <a class="a-on" target="_blank"  href="/Dealer/index.aspx?did=84">楷模</a>  <a target="_blank" href="/company/210/index.aspx">北欧E家</a> 
            <a href="/51/default.aspx" target="_blank"> 品牌团购</a> <a target="_blank" href="/productlisttbb.aspx">名品折扣</a> 
             <a target="_blank" href="/productlist.aspx?did=7">家具精选</a>  <a target="_blank" href="/productlisttbb.aspx?xid=50&did=11">特价书柜</a>
                    
                    </div>
        </div>
        <div class="right fr">
            <a href="http://www.jiajuks.com/product/17781/info.aspx">
                <img src="../../../resource/content/img/common/j1.png" alt="" /></a>
        </div>
    </div>
    <div class="w clearfix" style="border-top-color : #D8D8D8;border-top-style : dashed;border-top-width : 1px;padding-top:15px;margin-top:15px;">
            <h4 class="yahei fl"><%=title%></h4>
        <asp:Repeater ID="Repeater_brand" runat="server">
        <ItemTemplate>
         <a class="fr" title="" href="/Dealer/<%=getdid %>/product-<%#Eval("Id") %>--------1-----.aspx">
                <img alt="" src="/upload/brand/logo/<%#Eval("Id") %>/<%#Eval("logo").ToString().Replace(",","") %>" width="105" height="38" /></a>
        </ItemTemplate>
        </asp:Repeater>
           
          
        </div>
</div>
<!--头部文件结束-->
<!--菜单开始-->
<div class="nav">
    <div class="nav-box w clearfix">        
        <ul class="nav-title fl" id="j_menuTab">
            <li class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "index.aspx", "", "on")%>"><a class="nav-item" href="/Dealer/index.aspx?did=<%=getdid %>">首 页</a></li>
            <li class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "about.aspx", "", "on")%>"><a class="nav-item" href="<%=companyUrl %>" target="_blank">
                   工厂</a></li>
           
                <li class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "brand.aspx", "", "on")%>"><a class="nav-item" href="/Dealer/brand.aspx?did=<%=getdid %>">
                    品牌介绍</a></li>
                <li class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "product.aspx", "", "on")%>"><a class="nav-item" href="/Dealer/<%=getdid %>/product.aspx">
                    全部产品</a></li>
            
            <li class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "merchants.aspx,merchantsInfo.aspx", "", "on")%>" style="display:none;"><a class="nav-item" href="/Dealer/merchants.aspx?did=<%=getdid %>">
                            招商信息</a></li>
            <li class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "promotions.aspx,promotionsinfo.aspx", "", "on") %>"><a class="nav-item" href="/Dealer/promotions.aspx?did=<%=getdid %>">
                            促销活动</a></li>
            <li class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "news.aspx,newsinfo.aspx", "", "on")%>" style="display:none;"><a class="nav-item" href="/news/list.aspx">
                            公司新闻</a></li>
            <li class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "address.aspx", "", "on")%>"><a class="nav-item" href="/Dealer/address.aspx?did=<%=getdid %>" target='_blank'>
                            交通乘车路线</a></li>
        </ul>
    </div>
</div>
<!--菜单结束-->  

