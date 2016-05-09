<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headNoLog.ascx.cs" Inherits="TREC.Web.Suppler.ascx.headNoLog" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
    <div class="head headFrame" style="height: 65px;">
        <div class="Fcon">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td width="195" height="55">
                        <a href="<%=TREC.ECommerce.ECommon.WebSupplerUrl.TrimEnd('/') %>/suppler/index.aspx"><img src="<%=TREC.ECommerce.ECommon.WebSupplerUrl.TrimEnd('/') %>/suppler/images/logo.jpg" title="商务中心首页" /></a>
                    </td>
                    <td>
                        <div class="head_user">
                            <strong class="px14" style="color: #555555;"><%=EnterpriseName %></strong>(
                            <%if (SupplerPageBase.memberInfo.type == (int)EnumMemberType.工厂企业)
                              {%>
                                品牌厂商 
                             <%}
                              else if (SupplerPageBase.memberInfo.type == (int)EnumMemberType.经销商)
                              {  %>
                                 经销商
                              <%}
                              else if (SupplerPageBase.memberInfo.type == (int)EnumMemberType.卖场)
                              { %>
                                卖场
                              <%} %>
                            <a href="#" title="点击隐身"><span class="f_green">在线</span></a>) &nbsp;&nbsp;&nbsp;<%-- [ <a href="default.aspx" class="b">我的商务室</a> ]--%>
                        </div>
                    </td>
                    <td class="head_sch">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="clear"></div>