<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.company.brand" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/headerCompany.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<%@ Register Src="../ascx/_companyproduct.ascx" TagName="_companyproduct" TagPrefix="uc5" %>
<%@ Register src="../ascx/_companykeys.ascx" tagname="_companykeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_teladdress.ascx" tagname="_teladdress" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <uc6:_companykeys ID="_companykeys1" Title="-厂家品牌" runat="server" />
       <ucnewresource:newresource ID="newresource1" runat="server" />
    <title><%=pageTitle %></title>
    <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/factory/factory.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/factory/factory.js"></script>
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
    <script type="text/javascript">
        $(function () {
            if ("<%=ECommon.QuerySearchBrand %>" == "") {
                $($("#brandNav li:first-child a")).addClass("brandjs1a")
            }
        })
    </script>
</head>
<body> 
    <uc1:header ID="header1" runat="server" />
    <div class="site"><a href="/">家具快搜</a> > <a href="/companybrandlist.aspx">品牌</a> >  品牌介绍</div>
    <div class="homebrandsc">
        <div class="topNav992">

        <div class="homebraLift">
                <div class="homebraLi2">
                    <h3>
                    品牌介绍</h3>
                    <div class="jies">
                    
                    <div class="shopindex0">
                    <div class="Brand">
                        <div class="BrandLeft">
                            <p>
                                <span>品牌：</span><a target="_blank" href="<%=string.Format(EnUrls.CompanyInfoIndex, companyInfo.id) %>"><strong><%=currentBrand.title %></strong></a></p>
                            <p style="border-bottom: 1px dotted #C0C0C0;">
                                <span>厂商：</span><%=companyInfo != null ? companyInfo.title : "暂无" %>
                                &nbsp;&nbsp;&nbsp;<span>风格：</span><%=ECConfig.GetConfigInfoNew(" type=3 and value in(" + StyleString + ")")%></p>
                            <p>
                                <%=TRECommon.HTMLUtils.GetAllTextFromHTML(companyInfo.descript).Length > 76 ? TRECommon.HTMLUtils.GetAllTextFromHTML(companyInfo.descript).Substring(0, 76) + "..." : TRECommon.HTMLUtils.GetAllTextFromHTML(companyInfo.descript)%></p>
                        </div>
                        <div class="BrandRight" style="position: relative;">
                            <div style="height: 70px;">
                                <img alt="<%=currentBrand.title %>" src="<%=EnFilePath.GetBrandLogoPath(currentBrand.id, currentBrand.logo) %>"
                                    width="196" height="70" />
                            </div>
                            <div class="productView" style="display: block; margin-top: 3px; width: 197px; position: relative;
                                right: 0;">
                                <div class="br-gcs">
                                    <ul>
    <li style="margin-right: 2px;"><a href="<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId, currentBrand.id, "", "", "", "", "", "", "", "", "", "", "")%>" class="btn">所有产品</a> </li>
    <li><a href="<%=string.Format(EnUrls.CompanyInfoAddress, companyInfo.id) %>" class="btn">所有店铺</a> </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <br />
                       <%=BrandDescript %>

                    </div>
                   
                    
                </div>
            </div>

            <div class="homebraRight">
                <uc5:_companyproduct ID="_companyproduct1" runat="server" />
                <uc7:_teladdress ID="_teladdress1" runat="server" />
            </div>
        </div>
    </div>
    <ucfooter:footer ID="header2" runat="server" />
</body>
</html>
