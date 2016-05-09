<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DealerteladdressCon.ascx.cs" Inherits="TREC.Web.template.web.ascx.DealerteladdressCon" %>


  <%if (isPay)
    { %>
        <div class="homebraRight1 homebraRight2">
    	    <div class="promotions">厂家联系方式</div>
    	    <div class="homebraRight21">
    	     <%=showaddress%>
              
              </div>
        </div>

         <div class="homebraRight1 homebraRight2">
<div class="promotions">
    店铺联系方式</div>
    <% int i=0; %>
    <%if (list.Count > 0 )
      { 
          %>
        <%foreach (Haojibiz.t_shop s in list)
          {
              i++; %>
          <table border="0" style="margin:10px;">
         
          <tr><td valign="top" colspan="2" ><strong><a href="/shop/<%=s.id %>/index.aspx" target="_blank"><%=s.title %></a></strong> 
            <%if (!string.IsNullOrEmpty(s.qq))
              { %>
          <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=<%=s.qq %>&site=qq&menu=yes" style="margin-left:3px;"><img border="0"  src="http://wpa.qq.com/pa?p=2:<%=s.qq %>:41" alt="点击这里给我发消息" title="点击这里给我发消息" style="vertical-align:middle;height:16px;"></a>
          <% }%>
          </td></tr>
      
          <tr><td valign="top">地址：</td><td><%=s.address%></td> </tr>
          <tr><td style="width:40px;" valign="top">电话：</td><td><%=s.phone%></td></tr>
         
          <%if (!string.IsNullOrEmpty(s.qq))
       { %>
          <tr style="display:none;"><td valign="top"></td><td>
         
          </td></tr>
          <%} %>
          </table>
         <%if (i < list.Count)
           { %>
      <div style="border-bottom:1px solid #e7e7e7;margin:13px 10px 10px;">
    </div>
    <% }
          }
      }  %>
   
</div>
        
 <%} %>
