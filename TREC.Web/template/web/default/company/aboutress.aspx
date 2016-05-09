<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.company.aboutress" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_companynav.ascx" TagName="_companynav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../ascx/_companyproduct.ascx" TagName="_companyproduct" TagPrefix="uc5" %>
<%@ Register src="../ascx/_companykeys.ascx" tagname="_companykeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_teladdress.ascx" tagname="_teladdress" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_companykeys ID="_companykeys1" Title="-工厂-联系地址" runat="server" />
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
    <script type="text/javascript">
        $(function () {
            var sb = '<%=TREC.ECommerce.ECommon.QuerySearchBrand.ToLower()%>';
            if (sb.indexOf("_a") >= 0) {
                sb = sb.replace("_a", "");
            }
            else if (sb.indexOf("_b") >= 0) {
                sb = sb.replace("_b", "");
            }
            else {
                sb = '<%=TREC.ECommerce.ECommon.QuerySearchBrand %>';
            }
            if (sb == "") {
                $($("#brandNav li:first-child a")).addClass("brandjs1a")
            }
        })
    </script>
</head>
<body>
    <uc1:_headA ID="_headA1" runat="server" />
    <uc3:_companynav ID="_companynav1" runat="server" />
    <div class="homebrandsc">
        <div class="topNav992">
            <div class="homebraLift">
                <div class="homebraLi2" style="margin-top: 0;">
                    <%--<div class="brandsDealer-map" id="maps"></div>
             <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2"></script>
            <script type="text/javascript">
                var map = new BMap.Map("maps");
                map.centerAndZoom(new BMap.Point(116.404, 39.915), 11);
                var local = new BMap.LocalSearch(map, {
                    renderOptions: { map: map }
                });
                local.search("<%=ECommon.GetTrueCodeNameNew(ECommon.GetAreaName(companyInfo.areacode)+companyInfo.address) %>");
            </script>--%>
                    <div class="braAbout c61f38">
                        <div class="braabtitle">
                            联系方式</div>
                        <div class="braAboutlx">
                            电话 ：<%=companyInfo.phone%><br />
                            传真 ：<%=companyInfo.fax%><br />
                            邮箱 ：<%=companyInfo.email%><br />
                            地址：<%=ECommon.GetAreaName(companyInfo.areacode) + companyInfo.address%><br />
                            网址 ：<%if (!string.IsNullOrEmpty(companyInfo.homepage) && companyInfo.homepage.IndexOf("http") > 0)
                                  { %>
                            <a target="_blank" href="<%=companyInfo.homepage%>">
                                <%=companyInfo.homepage%></a>
                            <%}
                                  else
                                  { %>
                            <a target="_blank" href="<%=string.IsNullOrEmpty(companyInfo.homepage)?"#":(companyInfo.homepage.ToLower().Contains("http://")?companyInfo.homepage:"http://"+companyInfo.homepage)%>">
                                <%=companyInfo.homepage%></a>
                            <%} %>
                        </div>
                    </div>
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
