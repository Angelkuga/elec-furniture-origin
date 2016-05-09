<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TREC.Web.template.web.Dealer.index" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Linq" %>

<%@ Register Src="../ascx/HeadDealer.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register src="../ascx/DealerProduct.ascx" tagname="DealerProduct" tagprefix="uc2" %>
<%@ Register src="../ascx/New_DealerProduct.ascx" tagname="New_DealerProduct" tagprefix="uc3" %>
<%@ Register src="../ascx/Dealerteladdress.ascx" tagname="Dealerteladdress" tagprefix="uc4" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7;IE=9;IE=8">
    <link href="/resource/content/css/core.css" rel="stylesheet" />
      <link href="/resource/content/css/index/index.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>

    <link href="/resource/content/css/factory/factory.css" rel="stylesheet" />
    <script src="/resource/content/js/_src/factory/factory.js"></script>
        
  <script src="/resource/content/js/_src/index/index.js"></script>
    <style>
        .btnf
        {
            margin: 0 auto;
            width: 150px;
        }
        
        .btnn
        {
            width: 74px;
            height: 22px;
            background: url(/resource/web/images/img2.gif);
            display: block;
            float: left;
            line-height: 22px;
            margin-right: 1px;
        }
        .btnn:hover
        {
            width: 74px;
            height: 22px;
            background: url(/resource/web/images/img1.gif);
            color: #fff;
        }
        
        .recommend .item li {
margin: 0 4px 10px 4px;float: left;
padding: 5px;
}
.recommend .item li:hover{

border: 1px solid #d9d9d9;box-shadow: 0px 0px 10px #B7B5B5;

}
    </style>

    <title><%=seotitle%></title>
    <%=seokeyword%>
    <%=seokeydescrip%>
    
</head>
<body>
    <form id="form1" runat="server">
   <uc1:header ID="header1" runat="server" />
    <div class="seller-cont clearfix">
        
        <div class="w">
            <div class="cont-l fl">
              
                <div id="j_keynote" class="keynote">
                    <div class="slides_container">
                       <%=getbannelImg%>
                    </div>
                </div>
               


                <div class="brand">
                    <div class="common-hd clearfix">
                        <span class="hd-l fl b f14">品脾</span> <a href="#" class="hd-r fr songti">查看详细介绍 >></a>
                    </div>
                    <asp:Repeater ID="Repeater_brand" runat="server">
                    <ItemTemplate>
                    <table class="bd g10">
                        <tr>
                            <td width="170" class="tc bd-l">
                                <a class="block" href="/Dealer/<%=did %>/product-<%#Eval("Id") %>--------1-----.aspx"
                                    title="<%#Eval("title") %>"
                                    target="_blank">
                                    <img alt="<%#Eval("title") %>"
                                        class="scrollLoading" src="<%#getthumbImg(Eval("id").ToString(),Eval("thumb"))%>"
                                        width="141" height="106" /></a>
                            </td>
                            <td class="bd-c">
                                <h6 class="f14 b">
                                    <a href="/Dealer/<%=did %>/product-<%#Eval("Id") %>--------1-----.aspx"
                                        target="_blank">
                                        <%#Eval("title") %>
                                        </a></h6>
                                <p>
                                    <b>风格：</b><%#Eval("stylename")%><b class="ml10">材质：</b>
                                   <%#Eval("materialname")%>
                                </p>
                                <div class="text">
                                    <%#getdescript(Eval("descript"))%>
                                </div>
                            </td>
                            <td width="240" class="tc">
                                <a class="block" href="#"
                                    title="<%#Eval("title") %>" target="_blank">
                                    <img style="max-height: 70px; height: 70px" alt="<%#Eval("title") %>" class="scrollLoading"
                                        src="<%#getlogImg(Eval("Id").ToString(),Eval("logo"))%>" /></a>
                                <div class="btnf" style="width: 230px">
                                    <a href="/Dealer/<%=did %>/product-<%#Eval("Id") %>--------1-----.aspx" 
                                        class="btnn">查看产品</a> <a href="/Dealer/brand.aspx?did=<%=did %>&bid=<%#Eval("Id")%>" 
                                            class="btnn">品牌介绍</a> <a href="/Dealer/address.aspx?did=<%=did %>&bid=<%#Eval("Id")%>&page=1" 
                                                class="btnn">所有店铺</a>
                                </div>
                            </td>
                        </tr>
                    </table>
                    </ItemTemplate>
                    </asp:Repeater>
                    
                   


                </div>



                <div class="recommend">
                    <div class="step-view w" id="j_stepView" style="margin-top: 2px; padding-top: 2px;
                        width: 947px">
                        <div class="tab">
                            <div class="hd clearfix">
                                <ul style="left:0px;">
                                    <li class="on">推荐产品</li>
                                    <li style="font-size:14px; font-family;微软雅黑; color:#b9003c; font-weight:bold; background:url(/resource/content/img/factory/hot.gif) no-repeat 80px 0px;">促销产品</li>
                                </ul>
                                <a href="#" target="_blank"
                                    class="fr songti more">更多</a>
                            </div>
                            <div class="bd" style='width: 947px'>
                                <div class="item">
                                    <div>
                                        <ul class=" clearfix">
                                            <%
                                                int tmpPageCount = 0;
                                                foreach (EnWebProduct p in ECProduct.GetWebProductList(1, 40, " and createmid=" + getcreatemid + " and  (ShopID=0 or ShopID is null) ", "sort desc,lastedittime", "desc", out tmpPageCount))
                                                  { %>
                                            <li style="height:260px;"><a href="#"><a class="block" title="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku   %>"
                                                href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                                <div style="text-align:center;width: 216px; height: 162px;overflow:hidden;">
                                                <img alt="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku   %>"
                                                    style='' src="<%=EnFilePath.GetProductThumbPathNew(p.id.ToString(), p.thumb,"230","173") %>" />
                                                    </div>
                                            </a>
                                                <p class="p1">
                                                    <a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                                        <%=p.brandtitle + " " + p.categorytitle + " " + p.stylename + "风格"%></a></p>
                                                <p class="p2">
                                                    <a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                                        <%if (p.lastedittime > new DateTime(2014, 12, 1))
                                                              {%>
                                                        <%=TRECommon.StringOperation.CutString(p.materialname + " 家具 "+p.title+" &nbsp;"+ p.sku,0,20)%>
                                                        <%}
                                                              else
                                                              { %>
                                                        <%=TRECommon.StringOperation.CutString(p.materialname + " 家具 "+" &nbsp;"+ p.sku,0,20)%>
                                                        <%} %></a>
                                                </p>
                                                <p class="p3">
                                              
                                                <%if (p.ProductAttributeInfo.markprice != null && decimal.Parse(p.ProductAttributeInfo.markprice) > 0)
                                                              {%>
                                                    市场参考价:￥<%=p.ProductAttributeInfo.markprice %>
                                                     <%} %>
                                                     <br />
                                                    <span>
                                                     
                                                        <%if (p.ProductAttributeInfo.saleprice != null && decimal.Parse(p.ProductAttributeInfo.saleprice) > 0)
                                                              {%>
                                                        销售价:￥<%=p.ProductAttributeInfo.saleprice%>
                                                        <%} %></span><br />
                                                        <span>
                                                     
                                                        <%if (p.ProductAttributeInfo.buyprice != null && decimal.Parse(p.ProductAttributeInfo.buyprice) > 0)
                                                              {%>
                                                        <%=ECProduct.CheckbuypriceName(p.id.ToString()) %>:￥<%=p.ProductAttributeInfo.buyprice%>
                                                        <%} %></span>
                                                </p></li>
                                            <%} %>
                                        </ul>
                                    </div>
                                    <div class="ks-pager">
                                        <table align="center" style="margin: auto">
                                            <tr>
                                                <td>
                                                    <a disabled="disabled" href="/Dealer/<%=did %>/product.aspx">
                                                        <img src="/resource/content/img/factory/comallprod.gif" /></a>
                                                </td>
                                            </tr>
                                        </table>
                                        <%--   

                            <a disabled="disabled">首页</a> <a disabled="disabled">上页</a> <span>1</span> <a href="#">
                                2</a> <a href="#">3</a> <a href="#">4</a> <a href="#">5</a> <a href="#">6</a>
                            <a href="#">7</a> <a href="#">下页</a> <a href="#">最后一页</a>--%>
                                    </div>
                                    <br />
                                </div>
                                <div class="item hide">
                                    <div>
                                        <ul class=" clearfix">
                                            <%
                                                    int pcount = 0;
                                                    foreach (EnWebProduct p in ECProduct.GetWebProductList(1, 40, " and createmid=" + getcreatemid, "sort desc,lastedittime", "desc", out pcount))
                                                  {
                                                      if (string.IsNullOrEmpty(p.attributexml))
                                                          p.attributexml = "-";
                                                      var type = new System.Text.RegularExpressions.Regex("<ProductAttributePromotion>([^<]+)</ProductAttributePromotion>").Match(p.attributexml, 1).Groups[1].Value;

                                                      if (!string.IsNullOrEmpty(type) && int.Parse(type) > 1)
                                                      {
                                                          pcount++; %>
                                            <li><a href="#"><a class="block" title="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku   %>"
                                                href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                                <div style="width: 216px; height: 162px;overflow:hidden;">
                                                <img alt="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku   %>"
                                                    style='' src="<%=EnFilePath.GetProductThumbPathNew(p.id.ToString(), p.thumb,"230","173") %>" /></div>
                                            </a>
                                                <p class="p1">
                                                    <a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                                        <%=p.brandtitle + " " + p.categorytitle + " " + p.stylename + "风格"%></a></p>
                                                <p class="p2">
                                                    <a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                                        <%if (p.lastedittime > new DateTime(2014, 12, 1))
                                                              {%>
                                                        <%=TRECommon.StringOperation.CutString(p.materialname + " 家具 "+p.title+" &nbsp;"+ p.sku,0,20)%>
                                                        <%}
                                                              else
                                                              { %>
                                                        <%=TRECommon.StringOperation.CutString(p.materialname + " 家具 "+" &nbsp;"+ p.sku,0,20)%>
                                                        <%} %></a>
                                                </p>
                                                <p class="p3">
                                                    参考价:￥<%=p.ProductAttributeInfo.markprice %>
                                                    <span>
                                                        <%if (p.ProductAttributeInfo.buyprice != null && decimal.Parse(p.ProductAttributeInfo.buyprice) > 0)
                                                              {%>
                                                        促销价:￥<%=p.ProductAttributeInfo.buyprice%>
                                                        <%} %></span>
                                                </p></li>
                                            <%}} 
                                            %>
                                        </ul>
                                    </div>
                                    <div class="ks-pager">
                                        <table align="center" style="margin: auto">
                                            <tr>
                                                <td>
                                                    <% if (pcount == 0)
                                                        { %>
                                                    <label>
                                                        暂无参加活动的产品<br />
                                                        <br />
                                                    </label>
                                                    <%} %>
                                                    <a disabled="disabled" href="#">
                                                        <img src="/resource/content/img/factory/comallprod.gif" /></a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
               
               <!------>
                <div class="productShop productPa1" style="text-align: center;display:none;">
                    该店铺或者店铺下的品牌已经被下线<br />
                    您可以查询其他店铺的产品&nbsp; <a href="<%=TREC.ECommerce.ECommon.WebUrl%>/product/list.aspx">去查找</a>&nbsp;
                    &nbsp; <a href="<%=TREC.ECommerce.ECommon.WebUrl%>">去首页</a>
                </div>
                 <!------>
            </div>
            <div class="cont-r fr">
                <div class="cont-r-t tc f14 b">
                    共有产品（<%=procunt %>）</div>
                    <uc3:New_DealerProduct ID="New_DealerProduct1" runat="server" />
                    <uc4:Dealerteladdress ID="Dealerteladdress1" runat="server" />
                
            </div>
        </div>
    </div>
    <ucfooter:footer ID="header2" runat="server" />
    </form>
</body>
</html>
