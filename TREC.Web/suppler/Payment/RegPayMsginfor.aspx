<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegPayMsginfor.aspx.cs" Inherits="TREC.Web.Suppler.Payment.RegPayMsginfor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
     .paymsg1
        {
            width:795px;
            height:75px;
	 padding:3px; 
    border: 1px solid #FFC176;
    -moz-border-radius: 5px;      /* Gecko browsers */
    -webkit-border-radius: 5px;   /* Webkit browsers */
    border-radius:5px;            /* W3C syntax */
    background-color:#FFFCED;
    font-size:12px;
    text-align:left;
    color:#FF7A20;
        }
        .paymsg2
        {
         font-size:13px;
         color:#575B67;   
         }
         .paytable
         {
	border-top-width : 1px;
	border-left-width : 1px;
	border-top-style : solid;
	border-left-style : solid;
	border-top-color : #DDDDDD;
	border-left-color : #DDDDDD;
             }
             
             .paytable td
             {
	border-right-width : 1px;
	border-bottom-width : 1px;
	border-right-color : #DDDDDD;
	border-bottom-color : #DDDDDD;
	border-right-style : solid;
	border-bottom-style : solid;
	padding-left:10px;
	padding-right:2px;
	padding-top:3px;
	padding-bottom:3px;
	font-size:14px;
             }
        p
        {
            font-size:16px;
            font-weight:bold;
        } 
        .htcon
        {
            font-size:14px;
            line-height:28px;
            
         }  
         .inputclass
         {
             border-width : 0px;
	border-bottom-width : 1px;
	border-bottom-style : solid;
	border-bottom-color : #DDDDDD;
	padding-left:10px;
         }  
         .cptable
         {
             padding-top:30px;
          }
           .cptable td
           {
               padding-top:6px;
               padding-bottom:6px;
           }
           .kuanbody
           {
    border-width : 1px;
	border-style : solid;
	border-color : #DDDDDD;
	margin:0px auto;
	width:700px;
	height:auto;
	padding:10px 10px 10px 10px;
            }
          
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-top:10px;padding-left:10px;">
        <table border="0" cellpadding="0" cellspacing="0" class="paytable">
        <tr><td style="width:250px;background-color:#A6A6A6;"  valign="middle">功能明细</td>
        <td style="width:190px;background-color:#A6A6A6;"  valign="middle">免费用户</td><td style="width:180px;background-color:#A6A6A6;color:Red;"  valign="middle">VIP会员(12000元/年)</td> </tr> 
          <tr><td >获得一个网上店铺</td><td><img src="/resource/images/pcheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
            <tr><td>发布工厂信息</td><td><img src="/resource/images/pcheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
             <tr><td>发布品牌信息</td><td><img src="/resource/images/pcheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
              <tr><td>发布产品信息(可标价可不标价)</td><td><img src="/resource/images/pcheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
               <tr><td>发布联系方式</td><td><img src="/resource/images/pnocheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
                 <tr><td>发布公司新闻</td><td><img src="/resource/images/pnocheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
            <tr><td>发布线下店铺地址</td><td><img src="/resource/images/pnocheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
           <tr><td>发布促销信息</td><td><img src="/resource/images/pnocheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
            <tr><td>发布招商信息</td><td><img src="/resource/images/pnocheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
             <tr><td >开通在线客服功能</td><td><img src="/resource/images/pnocheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
              <tr><td >开通在线促销和订购功能【不含收款】</td><td><img src="/resource/images/pnocheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
               <tr><td >参加团购活动</td><td><img src="/resource/images/pnocheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
                 <tr><td >入驻淘宝贝-库存促销</td><td><img src="/resource/images/pnocheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
                  <tr><td >开通订单查看功能</td><td><img src="/resource/images/pnocheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
                    <tr><td >获得家具快搜的客户资源和有效定单</td><td><img src="/resource/images/pnocheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
                      <tr><td >获得家具快搜的客户浏览，搜索等市场参考数据【功能开发中】</td><td><img src="/resource/images/pnocheck.jpg" /></td><td><img src="/resource/images/pcheck.jpg" /></td> </tr> 
        </table>

        <div style="font-size:15px;padding-top:5px;">说明：抢先注册成为家具快搜的会员，现在入驻享受五折优惠价6000元/年。</div>
        </div>
    </form>
</body>
</html>
