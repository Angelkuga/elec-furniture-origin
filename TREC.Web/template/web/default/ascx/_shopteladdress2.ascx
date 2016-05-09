<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_shopteladdress.ascx.cs"
    Inherits="TREC.Web.aspx.ascx._shopteladdress" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>

  <%if (isPay)
    { %>
<div class="fd-t f14">
    联系方式</div>
<div class="fd">

 <p style="color:#333">
 <strong>
       <%=ShopPageBase.shopInfo.title%>
        <%if (!string.IsNullOrEmpty(ShopPageBase.shopInfo.qq))
          { %>
      <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=<%=ShopPageBase.shopInfo.qq%>&site=qq&menu=yes">
            <img border="0" src="http://wpa.qq.com/pa?p=2:<%=ShopPageBase.shopInfo.qq%>:41" alt="点击这里给我发消息"
                title="点击这里给我发消息" style="height:18px;"></a>
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
<%}%>