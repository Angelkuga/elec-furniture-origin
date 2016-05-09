<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.company.about" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_companynav.ascx" TagName="_companynav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>
<%@ Register Src="../ascx/_companyproduct.ascx" TagName="_companyproduct" TagPrefix="uc5" %>
<%@ Register src="../ascx/_companykeys.ascx" tagname="_companykeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_teladdress.ascx" tagname="_teladdress" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_companykeys ID="_companykeys1" Title="-厂家介绍" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
    <script type="text/javascript">
        myFocus.set({
            id: 'fjwcontainer', //焦点图盒子ID
            pattern: 'mF_taobao2010', //风格应用的名称
            path: '<%=ECommon.WebResourceUrl %>/script/pattern/',
            time: 6, //切换时间间隔(秒)
            trigger: 'mouseover', //触发切换模式:'click'(点击)/'mouseover'(悬停)
            width: 767, //设置图片区域宽度(像素)
            height: 331, //设置图片区域高度(像素)
            txtHeight: 0//文字层高度设置(像素),'default'为默认高度，0为隐藏
        });
    </script>
</head>
<body>
    <uc1:_headA ID="_headA1" runat="server" />
    <uc3:_companynav ID="_companynav1" runat="server" />
    <div class="homebrandsc">
        <div class="topNav992">
            <div class="homebraLift">
                <div class="homebraLi2" style="margin-top: 0;">
                    <div class="braAbout">
                        <%--<div class="homebraLi22" style="padding: 3px 7px 7px 7px;">
                            <div class="homebraLi221" style="width: 100%;">
                                <img src="<%=EnFilePath.GetCompanyThumbPath(companyInfo.id.ToString(),companyInfo.thumb) %>" />
                            </div>
                        </div>--%>
                        <div class="homebraLi22">
                            <div class="homebraLi221" style="width: 100%;">
                                <%=companyInfo.descript %>
                            </div>
                        </div>
                    </div>
                    <%--<div class="braAbout">
                        <div class="braabtitle">
                            <%=companyInfo.title %>-简介</div>
                        <div class="homebraLi22">
                            <div style="float: left; margin-right: 15px;">
                                <img src="<%=EnFilePath.GetCompanyThumbPath(companyInfo.id.ToString(),companyInfo.thumb) %>"
                                    width="141" height="106" /></div>
                            <div class="homebraLi221">
                                <%=companyInfo.descript %>
                            </div>
                        </div>
                    </div>
                    <div class="braAbout">
                        <div class="braabtitle">
                            <span class="spana1"><a href="#">查看详细介绍</a></span>旗下品脾</div>
                        <%foreach (CompanyBrand b in companyInfo.CompanyBrandList)
                          { %>
                        <div class="braAbout1">
                            <div class="braAbout10">
                                <div class="braAbout11">
                                    <div class="braAbout111">
                                        <img src="<%=EnFilePath.GetBrandLogoPath(b.id.ToString(),b.thumb) %>" width="105"
                                            height="38" /></div>
                                    <div class="braAbout112">
                                        <%=b.descript %></div>
                                </div>
                                <ul class="braAbout12">
                                    <%foreach (EnWebProduct p in ECProduct.GetWebProductList(1, 4, " and brandid=" + b.id, "", "", out tmpPageCount))
                                      { %>
                                    <li>
                                        <p>
                                            <a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                                <img src="<%=EnFilePath.GetProductThumbPath(p.id.ToString(),p.thumb) %>" width="175"
                                                    height="131" /></a></p>
                                        <p>
                                            <strong><a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                                <%=p.categorytitle %>(<%=p.sku %>)</a></strong></p>
                                    </li>
                                    <%} %>
                                </ul>
                                <div class="productView">
                                    <div class="br-gcs hd">
                                        <ul>
                                            <li><a href="#">品牌介绍</a></li>
                                            <li><a href="#">经销商</a></li>
                                            <li><a href="#">促销信息</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%} %>
                    </div>
                    <div class="braAbout" style="display: none">
                        <div class="braabtitle">
                            <span class="spana1"><a href="#">查看所有证书</a></span>认证证书</div>
                        <div class="braAboutzs" id="braAboutzs">
                            <ul>
                                <li><a href="images/brands_04.jpg">
                                    <img src="images/brands_04.jpg" width="88" height="121" /></a></li>
                                <li><a href="images/brands_04.jpg">
                                    <img src="images/brands_04.jpg" width="88" height="121" /></a></li>
                                <li><a href="images/brands_04.jpg">
                                    <img src="images/brands_04.jpg" width="88" height="121" /></a></li>
                                <li><a href="images/brands_04.jpg">
                                    <img src="images/brands_04.jpg" width="88" height="121" /></a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="braAbout">
                        <div class="braabtitle">
                            联系方式</div>
                        <div class="braAboutlx">
                            <div style="float: right; width: 245px; height: 199px; border: 1px solid gray" id="maps">
                            </div>
                            <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2"></script>
                            <script type="text/javascript">
                                var map = new BMap.Map("maps");
                                map.centerAndZoom(new BMap.Point(116.404, 39.915), 11);
                                var local = new BMap.LocalSearch(map, {
                                    renderOptions: { map: map }
                                });
                                local.search("<%=ECommon.GetAreaName(companyInfo.areacode)+companyInfo.address %>");
                            </script>
                            联系人：
                            <%=companyInfo.title %>
                            <br />
                            电话：
                            <%=companyInfo.phone %>
                            <br />
                            传真：
                            <%=companyInfo.fax %>
                            <br />
                            地址：
                            <%=ECommon.GetAreaName(companyInfo.areacode)+companyInfo.address %><br />
                            公司主页：<a href="<%=companyInfo.homepage %>" style="color: #a61329;"><%=companyInfo.homepage %></a></div>
                    </div>--%>
                </div>
            </div>
            <div class="homebraRight">
                <uc5:_companyproduct ID="_companyproduct1" runat="server" />
               <uc7:_teladdress ID="_teladdress1" runat="server" />
            </div>
        </div>
    </div>
    <uc4:_foot ID="_foot1" runat="server" />
</body>
</html>
