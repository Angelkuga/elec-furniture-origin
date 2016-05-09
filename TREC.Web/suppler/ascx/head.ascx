<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="head.ascx.cs" Inherits="TREC.Web.Suppler.ascx.head" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
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