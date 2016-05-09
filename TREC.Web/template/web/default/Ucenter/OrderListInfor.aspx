<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderListInfor.aspx.cs" Inherits="TREC.Web.template.web.Ucenter.OrderListInfor" %>
<%@ Register Src="../ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<%@ Register src="../ascx/Ucenter.ascx" tagname="Ucenter" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="/resource/content/css/ucerter.css" rel="stylesheet" type="text/css">
    <link href="/resource/content/css/supplier.css" rel="stylesheet" type="text/css">
   <script src="/resource/content/indexnav/jquery.min.js" type="text/javascript"></script>

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
        
         width:975px;
         margin-top:10px;
         padding-top:20px;
         padding-bottom:20px;
     }
    
   </style>
</head>
<body>
    <form id="form1" runat="server">
   <uc1:header ID="header1" runat="server" />
    <div class="site"><a href="#">首页</a> &gt; <a href="#">购物车</a> &gt; 用户中心</div>
    <div class="contentInner">
  <div class="inner">
    <div class="supplier">
                            
<uc2:Ucenter ID="Ucenter1" runat="server" />
        
<!---begin--->
<div style="float:right;width:975px;height:auto;">
<div  style="width:975px;height:auto;" class="kbody">
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


     <div  style="width:975px;height:auto;margin-top:15px;" class="kbody">

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



     <div  style="width:975px;height:auto;margin-top:15px;" class="kbody">

     <div class="kbody1">
  <div style="padding-left:10px;padding-top:10px;"><table border="0" cellpadding="0" cellspacing="0"><tr><td style="width:300px;font-size:13px;font-weight:bold;color:#333333">产品信息</td>
  </tr> </table> </div>
  </div>

<div class="kbody_address" style="border-bottom-width:0px;">
  <div>
  <table border="0" style="color:#555555;">
  <tr class="kbody_proct"><td style="width:80px;" align="center">商品编号</td> <td style="width:400px;" align="center">产品名称</td><td style="width:250px;" align="center">尺寸(长X宽X高)mm</td>
  <td style="width:50px;">颜色</td>
  <td style="width:50px;">单价</td>
   <td style="width:80px;">数量(件)</td>
    <td style="width:80px;">配送状态</td>
  </tr>
      <asp:Repeater ID="Repeater_list" runat="server">
      <ItemTemplate>
      <tr class="kbody_proc_c"><td  align="center"><%#Eval("proid") %></td> <td  align="center"><a target="_blank" class="a1" href='/productinfo.aspx?id=<%#Eval("proid") %>'><%#Eval("Title") %></a></td>
      <td  align="center"><%#Eval("Big") %></td>
  <td ><%#Eval("productcolortitle")%></td>
  <td >￥<%#Eval("resultPrice")%></td>
   <td  align="center"><%#Eval("Procount")%></td>
   <td><%#getsend(Eval("proinforid").ToString())%></td>
  </tr>
      </ItemTemplate>
      </asp:Repeater>
  

  </table>
  </div>
  </div>

     </div>

     <div class="kbody_result">
     
     <table border="0" style="margin-left:20px;">
     <tr  style="font-size:14px;font-weight:bold;"><td style="width:350px;">定单总金额：<%=_order.PaymentCount%></td><td>未支付金额：<span style="color:Red;"><%=nopay %></span></td></tr>
   <tr><td colspan="2"><span>安装费：<%=_order.InstallationFee.Value%></span><span style="margin-left:20px;">运费：<%=_order.Freight.Value%></span></td></tr> 
     </table>
     </div>

     <div style="margin-top:10px;"><center>
   <%=getplayurl%>

         

      <a href="UserOrderList.aspx"><img src="/resource/content/images/ucenter/payresult.jpg"  border="0"/> </a> 
     </center>  </div>
<!---end--->
 </div>                           
                            <div class="clearfix">
                            </div>
                        </div>
  </div>

</div>
    <ucfooter:footer ID="header2" runat="server" />
    </form>
</body>
</html>
