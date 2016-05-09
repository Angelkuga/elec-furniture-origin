<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_shopteladdress.ascx.cs"
    Inherits="TREC.Web.aspx.ascx._shopteladdress" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%--<%if (memberInfo != null && memberInfo.RegEndTime > DateTime.Now)
  {%>--%>
  <style type="text/css">
  
  .lxfs
  {
      padding-left: 15px;
color: #b9003c;
height: 32px;
line-height: 32px;
border: 1px solid #ccc;
font-family: 微软雅黑;
background: #fcfcfc;
font-weight: bold;

  }
  .fd{padding:5px 20px 10px;border:1px solid #d8d8d8;border-top:0;color:#666;background:#f5f5f5}
  .fd p
  {
      margin-top:5px;
  }
  </style>

  <%if (isPay)
    { %>
  <div class="cont-r fr" style="margin-top:10px;width:230px;">
<div class="lxfs">
    联系方式</div>
<div class="fd">

 <p style="color:#333">
 <strong>
       <%=ShopPageBase.shopInfo.title%>
        <%if (!string.IsNullOrEmpty(ShopPageBase.shopInfo.qq))
          { %>
      <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=<%=ShopPageBase.shopInfo.qq%>&site=qq&menu=yes">
            <img border="0" src="http://wpa.qq.com/pa?p=2:<%=ShopPageBase.shopInfo.qq%>:41" alt="点击这里给我发消息"  style="height:18px;"
                title="点击这里给我发消息"></a>
                  <%} %>
      </strong>
       </p>
       <p>
    地址：

    <%=ECommon.GetAreaName(ShopPageBase.shopInfo.areacode) + ShopPageBase.shopInfo.address%>

    </p>

    <p>
        电话：
        <%=ShopPageBase.shopInfo.phone%>
        </p>
</div>
</div>
<%}%>