<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="OrderInforpabe.aspx.cs" Inherits="TREC.Web.Suppler.market.OrderInforpabe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/resource/content/css/ucerter.css" rel="stylesheet" type="text/css">
    <link href="/resource/content/css/supplier.css" rel="stylesheet" type="text/css">
   <style type="text/css">
   .kbody {
	border-width : 1px;
	border-color : #D2D2D2;
	border-style : solid;
    }
     .kbody1
     {
         height:35px;
         border-bottom-color : #543016;
	    border-bottom-width : 1px;
	    border-bottom-style : solid;
	    width:100%;
      }
     .kbody_address
     {
         margin-left:10px;
         margin-right:10px;   
         height:auto;
         
          border-bottom-color : #D2D2D2;
	    border-bottom-width : 1px;
	    border-bottom-style : solid; 
	    padding-bottom:10px;
	    padding-top:10px;
     }
      .kbody_address td
      {
          padding-top:3px;
          padding-bottom:3px;
      }
      .kbody_proct
      {
           border-bottom-color : #543016;
	    border-bottom-width : 1px;
	   border-bottom-style : dotted;
      }
     .kbody_proc_c
      {
          background-color:#FCF9F2;
           border-bottom-color : #D9D9D9;
	    border-bottom-width : 1px;
	   border-bottom-style:solid;
      }
     .kbody_result
     {
         height:auto;
         background-color:#E5E5E5;
        
         width:675px;
         margin-top:10px;
         padding-top:20px;
         padding-bottom:20px;
     }
    
   </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentInner" style="text-align:left;">
  <div class="inner">
    <div class="supplier">

<!---begin--->

<div style="width:875px;height:auto;margin-top:10px;margin-left:10px;">
<div  style="width:875px;height:auto;" class="kbody">
  <div class="kbody1">
  <div style="padding-left:10px;padding-top:10px;"><table border="0" cellpadding="0" cellspacing="0"><tr><td style="width:300px;font-size:13px;font-weight:bold;color:#333333">定单号：<%=_order.OrderNumber %></td><td  style="color:#B31629;">状态：<%=results%></td></tr> </table> </div>
  </div>


  <div class="kbody1">
  <div style="padding-left:10px;padding-top:10px;"><table border="0" cellpadding="0" cellspacing="0"><tr><td style="width:300px;font-size:13px;font-weight:bold;color:#333333">定单信息</td>
  </tr> </table> </div>
  </div>

  <div class="kbody_address">
  <div style="font-size:13px;font-weight:bold;color:#333333;">收货人信息</div>
  <div>
  <table border="0" style="color:#555555;">
  <tr><td style="width:350px;">收货人：<%=_order.Consignee %></td> <td>手机号码：<%=_order.Mobile %></td></tr> 
   <tr><td>固定电话：<%=_order.Phone %></td> <td>电子邮件：<%=_order.Email %></td></tr> 
    <tr><td colspan="2">地址：<%=_order.Address %></td> </tr> 
  </table>
  </div>
  </div>

  <div class="kbody_address">
   <div style="font-size:13px;font-weight:bold;color:#333333">配送方式</div>
   <div style="color:#555555;padding-top:5px;">
   <%=getTransportMeth(_order.TransportMeth)%>
   </div>
  </div>

  
  <div class="kbody_address" >
   <div style="font-size:13px;font-weight:bold;color:#333333">是否开发票</div>
   <div style="color:#555555;padding-top:5px;">
   <%=(_order.InvoiceClaim.Value ? "不开发票" : "开发票，发票抬头：" + _order.InvoiceTop)%>
   </div>
  </div>

    <div class="kbody_address" style="border-bottom-width : 0px;">
   <div style="font-size:13px;font-weight:bold;color:#333333">定单备注</div>
   <div style="color:#555555;padding-top:5px;">
   <%=string.IsNullOrEmpty(_order.Description) ? "无备注" : _order.Description%>
   </div>
  </div>

     </div>


     <div  style="width:875px;height:auto;margin-top:15px;" class="kbody">

     <div class="kbody1">
  <div style="padding-left:10px;padding-top:10px;"><table border="0" cellpadding="0" cellspacing="0"><tr><td style="width:300px;font-size:13px;font-weight:bold;color:#333333">定单支付信息</td>
  </tr> </table> </div>
  </div>

<div class="kbody_address" style="border-bottom-width:0px;">
  <div>
  <table border="0" style="color:#555555;">
  <tr><td style="width:250px;" align="center">支付金额</td> <td style="width:250px;" align="center">支付日期</td><td style="width:200px;" align="center">支付状态</td></tr> 
 <%=paystr%>
  </table>
  </div>
  </div>

     </div>



     <div  style="width:875px;height:auto;margin-top:15px;" class="kbody">

     <div class="kbody1">
  <div style="padding-left:10px;padding-top:10px;"><table border="0" cellpadding="0" cellspacing="0"><tr><td style="width:300px;font-size:13px;font-weight:bold;color:#333333">产品信息</td>
  </tr> </table> </div>
  </div>

<div class="kbody_address" style="border-bottom-width:0px;">
  <div>
  <table border="0" style="color:#555555;">
  <tr class="kbody_proct"><td style="width:80px;" align="center">产品编号</td> <td style="width:480px;" align="center">产品名称</td><td style="width:250px;" align="center">尺寸(长X宽X高)mm</td>
  <td style="width:50px;">颜色</td>
  <td style="width:50px;">单价</td>
   <td style="width:50px;">数量(件)</td>
  </tr>
      <asp:Repeater ID="Repeater_list" runat="server">
      <ItemTemplate>
      <tr class="kbody_proc_c"><td  align="center"><%#Eval("productsku")%></td> <td  align="center"><a target="_blank" class="a1" href='/productinfo.aspx?id=<%#Eval("proid") %>'><%#Eval("Title") %></a></td>
      <td  align="center"><%#Eval("Big") %></td>
  <td ><%#Eval("productcolortitle")%></td>
  <td >￥<%#Eval("resultPrice")%></td>
   <td  align="center"><%#Eval("Procount")%></td>
  </tr>
      </ItemTemplate>
      </asp:Repeater>
  

  </table>
  </div>
  </div>

     </div>

     <div class="kbody_result" style="width:875px;">
     
     <table border="0" style="margin-left:20px;">
     <tr  style="font-size:14px;font-weight:bold;"><td style="width:350px;">总金额：￥<%=showpric%></td><td>未支状态：<span style="color:Red;"><%=results%></span></td></tr>
   <tr><td colspan="2"><span>安装费：<%=_order.InstallationFee.Value%></span><span style="margin-left:20px;">运费：<%=_order.Freight.Value%></span></td></tr> 
     </table>
     </div>
      <div style="margin-top:10px;padding-left:10px;" id="divoper" runat="server"><center>
      <table><tr><td>定单发货操作</td><td style="padding-right:10px;padding-left:10px;"> <asp:DropDownList ID="drop_oper" runat="server">
          
          </asp:DropDownList></td> 
      <td style="padding-right:10px;padding-left:10px;"> 
          <asp:Button ID="bnt_save" runat="server" Text="确定"  onclick="bnt_save_Click" Width="68px" /> </td>
      </tr> </table> </center></div>
     <div style="margin-top:10px;"><center>
  <a href="orderListmanage.aspx"><img src="/resource/content/images/ucenter/payresult.jpg"  border="0"/> </a> 
      
     </center>  </div>
<!---end--->
 </div>                     
  </div>
  </div>

</div>
</asp:Content>
