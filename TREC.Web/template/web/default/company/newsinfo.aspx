<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsinfo.aspx.cs" Inherits="TREC.Web.aspx.company.newsinfo" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
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
   <uc6:_companykeys ID="_companykeys1" Title="-公司新闻" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
</head>
<body>
    <uc1:_headA ID="_headA1" runat="server" />
    <uc3:_companynav ID="_companynav1" runat="server" />
    <div style="width:0; height:6px;"></div>
    <div class="homebrandsc">
        <div class="topNav992">
            <div class="homebraLift">
                <div class="promotionsR1" style="height: auto; border-bottom: 0;">
                    <div class="promotions">
                        <span><a href="<%=string.Format(EnUrls.CompanyInfoNews, ECommon.QueryCid) %>">返回列表页</a></span></div>
                </div>
                <div style="width:0; height:6px;"></div>
                <div class="news">
                    <div class="newsitem">
                        <span class="newsitemdate"><%=mnews.createtime.ToString("yyyy.MM.dd") %></span>
                        <h2><a><%=mnews.title %></a></h2>
                        <%if (mnews.ismember)
                          { %>
                        <p><span class="C50913 pleft">[品牌厂家]</span><span class="pright2"><a class="company" target="_blank" href="<%=string.Format(EnUrls.CompanyInfoIndex, mnews.companyid) %>"><%=mnews.companytitle%></a></span></p>
                        <%}
                          else
                          { %>
                        <p><span class="C848484 pleft">[导读]</span><span class="pright"><%=mnews.intro.Length > 56 ? mnews.intro.Substring(0, 56) : mnews.intro %></span></p>
                        <%} %>
                    </div>
                    <div class="promotionsinfodes"><%=mnews.descript %></div>
                </div>
            </div>
            <div class="homebraRight">
                <uc5:_companyproduct ID="_companyproduct1" runat="server" />
               <uc7:_teladdress ID="_teladdress1" runat="server" />
            </div>
        </div>
    </div>
    <uc4:_foot runat="server" />
</body>
</html>
