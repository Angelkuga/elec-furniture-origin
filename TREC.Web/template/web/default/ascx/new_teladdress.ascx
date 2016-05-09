<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_teladdress.ascx.cs"
    Inherits="TREC.Web.aspx.ascx._teladdress" %>

  <%if (isPay)
    { %>
<div class="fd-t f14">
    工厂联系方式</div>
<div class="fd" style="padding:10px;">

    <table border="0">
    <tr><td style="width:40px;" valign="top">厂商：</td><td><%=companyInfo.title%></td> </tr> 
    <tr><td valign="top">地址：</td><td> <%=TREC.ECommerce.ECommon.getAreaAll(companyInfo.areacode).Replace("市辖区", "") + (companyInfo.address == null ? "" : companyInfo.address.Replace(TREC.ECommerce.ECommon.getAreaAll(companyInfo.areacode), "").Replace("市辖区", ""))%></td></tr>
    <tr><td valign="top">电话：</td><td><span><%=companyInfo.phone%></span></td> </tr>
        </table>
     
</div>

<br />
<div class="fd-t f14">
    店铺联系方式</div>
<div class="fd"  style="padding:10px;">
     <% int i = 0; %>
    <%if (list.Count > 0)
      { %>
        <%foreach (TREC.Entity.EnWebShop s in list)
          {
              i++; %>
          <table border="0">
          
           <tr><td valign="top" colspan="2"><strong><a href="/shop/<%=s.id %>/index.aspx" target="_blank"><%=s.title%></a></strong>
           <%if (!string.IsNullOrEmpty(s.qq))
             { %>
           <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=<%=s.qq %>&site=qq&menu=yes" style="margin-left:3px;"><img border="0" style="height:16px;" src="http://wpa.qq.com/pa?p=2:<%=s.qq %>:41" alt="点击这里给我发消息" title="点击这里给我发消息"></a>
           <% }%>
           </td></tr>
      
          <tr><td valign="top">地址：</td><td><%=s.address%></td> </tr>
          <tr><td style="width:40px;" valign="top">电话：</td><td><%=s.phone%></td></tr>
         
          <%if (!string.IsNullOrEmpty(s.qq))
            { %>
          <tr style="display:none;"><td valign="top"></td><td>
          
          </td></tr>
          <%}  %>
          </table>
          <%if (i < list.Count)
            { %>
    <div style="border-bottom:1px solid  #e7e7e7;margin:10px 0 13px;">
    </div>
    <% }
          }
      }  %>
    

    

</div>
<% }%>

