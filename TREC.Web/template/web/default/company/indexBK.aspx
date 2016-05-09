<%@ Page Language="C#" AutoEventWireup="true"  Inherits="TREC.Web.aspx.company.index" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Linq" %>
<%@ Register src="../ascx/_headA.ascx" tagname="_headA" tagprefix="uc1" %>
<%@ Register src="../ascx/_resource.ascx" tagname="_resource" tagprefix="uc2" %>
<%@ Register src="../ascx/_companynav.ascx" tagname="_companynav" tagprefix="uc3" %>
<%@ Register src="../ascx/_foot.ascx" tagname="_foot" tagprefix="uc4" %>
<%@ Register src="../ascx/_companyproduct.ascx" tagname="_companyproduct" tagprefix="uc5" %>
<%@ Register src="../ascx/_companykeys.ascx" tagname="_companykeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_teladdress.ascx" tagname="_teladdress" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_companykeys ID="_companykeys1" Title="-厂家首页" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
    <script type="text/javascript">
    myFocus.set({
        id: 'fjwcontainer', //焦点图盒子ID
        pattern: 'mF_taobao2010', //风格应用的名称
        path: '<%=ECommon.WebResourceUrl.TrimEnd('/') %>/script/pattern/',
        time: 6, //切换时间间隔(秒)
        trigger: 'mouseover', //触发切换模式:'click'(点击)/'mouseover'(悬停)
        width: 757, //设置图片区域宽度(像素)
        height: 331, //设置图片区域高度(像素)
        txtHeight: 0//文字层高度设置(像素),'default'为默认高度，0为隐藏
    });
    $(function () {
        $(window).scrollTop(1).scrollTop(0);
    });
    </script>
</head>
<body>

<uc1:_headA ID="_headA1" runat="server" />
<uc3:_companynav ID="_companynav1" runat="server" />
<div class="homebrandsc">
<div class="topNav992">
<%if (CompanyPageBase.IsCount)
  { %>
	<div class="homebraLift">
     <div class="homebraLi1">
     <%if (!string.IsNullOrEmpty(CompanyPageBase.companyInfo.bannel))
       { %>
        <div id="fjwcontainer" class="" >
              <ul class="pic">
                    <%foreach (string s in companyInfo.bannel.Split(','))
                      {
                          if (s != null && s.Length > 0)
                          { %>
                      <li><a title="<%=companyInfo.title %>" target="_blank"><img  height="400" width="767" src="<%=EnFilePath.GetCompanyBannerPath(companyInfo.id.ToString(),s)%>"  alt="<%=companyInfo.title %>" /></a></li>
                    <%}
                      } %>
            </ul>
        </div>
                <%} %>       
     </div>
     <div class="braabtitle"><span class="spana1"><a href="#">查看详细介绍</a></span>旗下品脾</div>
     <%foreach (var c in companyInfo.CompanyBrandList)
       { %>
        <div class="brandsgc">
            <div class="brandsgc0">
                <div class="brandsgc01">
                    <a href="<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId, c.id, "", "", "", "", "", "", "", "", "", "", "") %>" title="<%=string.IsNullOrEmpty(c.keywords) ? c.title : c.keywords.Split('|')[0] %>" target="_blank">
                            <img alt="<%=string.IsNullOrEmpty(c.keywords) ? c.title : c.keywords.Split('|')[0] %>" class="scrollLoading" src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/common/white.gif"
                                data-url="<%=EnFilePath.GetBrandThumbPathNew(c.id.ToString(), c.thumb != null && c.thumb.EndsWith(",") ? c.thumb.Split(',')[0] : c.thumb,"141","106") %>" width="141"
                                height="106" /></a>
                </div>
                <div class="brandsgc02">
                    <h3>
                            <a href="<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId, c.id, "", "", "", "", "", "", "", "", "", "", "") %>" target="_blank">
                                <%=c.title.Replace(",", " ")%></a></h3>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <strong>风格：</strong><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "3", (ECBrand.GetBrandsInfo("where brandid=" + c.id) ?? new EnBrands()).style, ',', " ")%>
                                </td>
                                <td>
                                    <strong>材质：</strong><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "4", (ECBrand.GetBrandsInfo("where brandid=" + c.id) ?? new EnBrands()).material, ',', " ")%>
                                </td>
                                <td>&nbsp;
                                    
                                </td>
                            </tr>
                        </table>
                        <div>
                            <%=c.descript != null && TRECommon.HTMLUtils.GetAllTextFromHTML(c.descript).Length > 100 ? TRECommon.HTMLUtils.GetAllTextFromHTML(c.descript).Substring(0, 99) : TRECommon.HTMLUtils.GetAllTextFromHTML(c.descript)%></div>
                </div>
                <div class="brandsgc03">
                    <a href="<%=string.Format(EnUrls.CompanyInfoBrandList,ECommon.QueryCid,c.id) %>" title="<%=c.title %>" target="_blank">
                            <img style="max-height:70px;" alt="<%=c.title %>" class="scrollLoading" src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/common/white.gif"
                                data-url="<%=EnFilePath.GetBrandLogoPath(c.id, c.logo) %>" /></a>
                    <div class="productView">
                        <div class="br-gcs bd">
                            <ul>
                                <li><a href="#" class="btn" onclick="window.open('<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId, c.id, "", "", "", "", "", "", "", "", "", "", "") %>')">查看产品</a></li>
                                <li><a href="#" class="btn" onclick="window.open('<%=string.Format(EnUrls.CompanyInfoBrandList, ECommon.QueryCId, c.id) %>')">品牌介绍</a></li>
                                <li><a href="#" class="btn" onclick="window.open('<%=string.Format(EnUrls.CompanyInfoAddressList, ECommon.QueryCId, c.id, 1) %>')">店铺地址</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
     <%} %>
     <%--<div class="homebraLi2">
     	<div class="homebraLi21">
        <span class="spana1"><a href="#">更多</a></span>
        <strong>厂商介绍</strong>
        </div>
        <div class="homebraLi22">
            <div style="float:left; margin-right:15px;"><img src="<%=EnFilePath.GetCompanyThumbPath(companyInfo.id.ToString(),companyInfo.thumb) %>" width="141" height="106" /></div>
            <div class="homebraLi221">
              <%=companyInfo.descript != null && companyInfo.descript.Length > 424 ? companyInfo.descript.Substring(0, 423) + ".." : companyInfo.descript%>
            </div>
        </div>
     </div>--%>
     <div class="homebraLi2">
     	<div class="homebraLi21">
        <span class="spana1"><a href="<%=string.Format(EnUrls.CompanyInfoProduct, companyInfo.id) %>">更多</a></span>
        <strong>推荐产品</strong>
        </div>
        <%foreach (EnWebProduct p in ECProduct.GetWebProductList(1, 12, " and brandid in (" + companyInfo.BrandIdList + ")", "sort desc,lastedittime", "desc", out tmpPageCount))
          { %>
        <div class="productPa2 productLit">
             <p>
                 <a style="display: table-cell; vertical-align: middle; text-align: center; width: 230px; height: 170px; font-size:139px;";title="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku   %>" href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank"><img style="vertical-align: middle" alt="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku   %>" src="<%=EnFilePath.GetProductThumbPathNew(p.id.ToString(), p.thumb,"230","173") %>"/></a></p>
             <p class="titlepro" style="height:auto;">
                 <a class="auto_BD182D" href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank"><%=p.brandtitle + " " + p.categorytitle + " " + p.stylename + "风格"%></a></p>
            <p class="titlepro" style="height:auto;"><a class="auto_BD182D" href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
           
              <%if (p.lastedittime > new DateTime(2014, 12, 1))  {%>
               <%=p.materialname + " 家具 "+p.title+" &nbsp;"+ p.sku%>
                                          <%} else{ %>
                                           <%=p.materialname + " 家具 "+" &nbsp;"+ p.sku%>
                                          <%} %>
            </a></p>
             <p>
                                         <span style=" color:#555555;">参考价:￥<%=p.ProductAttributeInfo.markprice %></span>
                                       <%-- 销售价：<%=p.ProductAttributeInfo.saleprice%>元 促销价：<%=p.ProductAttributeInfo.buyprice%>元 --%>
                                       <!--销售价-->
                                      <%if (p.ProductAttributeInfo.buyprice!=null && decimal.Parse(p.ProductAttributeInfo.buyprice) > 0)
                                        {%> 
                          
                            <%if (p.ProductAttributeInfo.buyprice != null && decimal.Parse(p.ProductAttributeInfo.buyprice) > 0){%>
                            <%--  <span style=" color:#555555;">销售价:</span>
                              <span style=" color:#555555;text-decoration:line-through">￥<%=p.ProductAttributeInfo.saleprice%></span> --%>
                           <%}else{ %>
                           <span>￥<%=p.ProductAttributeInfo.saleprice%></span> 
                           <%} %>
                           <%} %>
                           <!--促销价-->
                           <%if (p.ProductAttributeInfo.buyprice != null && decimal.Parse(p.ProductAttributeInfo.buyprice) > 0)
                             {%>
                            <span style=" color:Red"> 促销价:￥<%=p.ProductAttributeInfo.buyprice%></span>  
                             <%} %>
                                        </p>
              <%if (p.ProductShopList != null && p.ProductShopList.Count != 0)
                { %>
                <%if ((p.ProductShopInfoNew != null && !string.IsNullOrEmpty(p.ProductShopInfoNew.price) && p.ProductShopInfoNew.price != "0.00" && p.ProductShopInfoNew.price != "0") || (p.ProductShopInfoNew != null && !string.IsNullOrEmpty(p.ProductShopInfoNew.dollprice) && p.ProductShopInfoNew.dollprice != "0" && p.ProductShopInfoNew.dollprice != "0.00"))
                  { %>
             <p>
                 
                       <%if (p.ProductShopInfoNew.dollprice != "0" && p.ProductShopInfoNew.dollprice != "0.00")
                         { %>
                               <div style="border:1px #ccc solid;border-radius:3px; width:185px;height:25px;line-height:25px;color:#FF0000; font-size:14px; margin:5px 0;">
					                <span style="font-size:13px; color:#666; font-weight:700;padding-left:8px;float:left;">促销报价：</span>
					                <span style="font-size:1.9em;line-height:22px; padding-right:3px; font-weight:700;"><%=p.ProductShopInfoNew.dollprice.Split('.')[0]%></span>元
					            </div>
                       <%}
                         else
                         { %>
                              <div style="border:1px #ccc solid;border-radius:3px; width:185px;height:25px;line-height:25px;color:#FF0000; font-size:14px; margin:5px 0;">
					                <span style="font-size:13px; color:#666; font-weight:700;padding-left:8px;float:left;">本店报价：</span>
					                <span style="font-size:1.9em;line-height:22px; padding-right:3px; font-weight:700;"><%=p.ProductShopInfoNew.price.Split('.')[0]%></span>元
					            </div>
                       <%} %>
                   
             </p>
             <p>
                <span>[店铺]</span><strong><a href="<%=string.Format(EnUrls.ShopInfoIndex, p.ProductShopInfoNew.id)%>"
                                        target="_blank">
                                        <%=p.ProductShopInfoNew.title%></a></strong>
             </p>
             <%}
                } %>

             <%if (p.FID != 0)
                   { %>
                       <p style="padding-top:10px;">
                           <a target="_blank" width="231px" class="gotoimg" height="24px" href="http://www.fujiawang.com/product/<%=p.FID %>/">
                           &nbsp
                           </a>
                       </p>
              <%} %>

             <%--<p>
                 品牌：<span><a href="#"><%=p.brandstitle %></a></span>风格：<span><a href="#"><%=p.stylename %></a></span></p>
                 
             <div class="proList">
                 电话咨询价格，请说来自福家网
                 <div class="productLitc">
                     <div class="productLiph">
                         <h4>
                             <a href="#"><%=p.ProductShopInfo.title %></a>
                             <img src="images/index_117.gif" width="88" height="18" /></h4>
                         <p class="address"><%=p.ProductShopInfo.address %></p>
                         <p class="phone"><%=p.ProductShopInfo.phone %></p>
                     </div>
                     <div class="productLiph2">
                         <a href="#">其他商铺</a><a href="#">促销信息</a><a href="#">品牌介绍</a></div>
                 </div>
             </div>--%>
         </div>

        <%} %>
        
      <div class="homebraLi23"><a href="<%=string.Format(EnUrls.CompanyInfoProduct,companyInfo.id) %>">查看所有产品</a></div>
     </div>
    </div>
	<div class="homebraRight">
    <uc5:_companyproduct ID="_companyproduct1" runat="server" />
    <uc7:_teladdress ID="_teladdress1" runat="server" />
    
</div>
<%}
  else
  { %>
   <div class="productShop productPa1" style="text-align:center;">
        该厂商已经被下线<br />您可以查询其他厂商的产品&nbsp; <a href="<%=TREC.ECommerce.ECommon.WebUrl%>product/list.aspx">去查找</a>&nbsp; &nbsp; <a href="<%=TREC.ECommerce.ECommon.WebUrl%>">去首页</a>
        </div>
  <%} %>
</div>
</div>
<uc4:_foot ID="_foot1" runat="server" />
</body>
</html>
