<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Member.Master" CodeBehind="index.aspx.cs"
    Inherits="TREC.Web.Suppler.index" %>

<%@ MasterType VirtualPath="Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
               .info {margin-left:150px; margin-top:30px;}
               .info div { text-align:left; margin-top:60px;} 
               .info em{color:#FF0000; font-weight:bolder; font-style:normal;}
                /*
                .info div span { font-size:20px; color:#666666; margin-bottom:20px; display:block;}
                */
                .info div span {
        font-size: 20px;
        color: #343434;
        margin-bottom: 20px;
        display: block;
        }
        .paymsg1
        {
            width:658px;
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
    margin-top:10px;
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
           </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maintitle">
        <h1>
            <u>系统中心</u></h1>
    </div>
    <div class="quickmenu">
         
     <center>
  <div  class="paymsg1">
              <div style="position:relative;">
              <div style="position:absolute;top:46px;right:10px;">
            <a href="/suppler/Payment/RegPayment.aspx"><img src="/resource/images/ucenterpay.jpg"  border="0"/></a>
              </div>
              </div>
              最全的家具购买资讯平台！足不出户逛卖场，让用户第一时间找到您！<a href="/suppler/Payment/RegPayment.aspx">抢先报名>></a><br />
              实现24小时与客户粘度，极大提高曝光率，最大限度确保客户不丢失！<a href="/suppler/Payment/RegPayment.aspx">抢先开通>></a><br />
              帮助您降低运营成本，最大限度开发有效客户实现订单转换！<a href="/suppler/Payment/RegPayment.aspx">抢先开通>></a>
              </div>
            </center> 
        <div class="info"> 
              <div style="color:#009933;margin-top:0px;margin-left:0px;">
              
                   <strong>抢先注册成为家具快搜的商家会员，享受五折优惠！</strong>(6月份之前入驻享受折后价6000元/年)
                    
                </div>
        </div>

        <center>
        <div class="paymsg2">
        <div style="display:none;">您尚未开通会员</div>
        <div style="width:660px;text-align:left;"> <table border="0" cellpadding="0" cellspacing="0"><tr><td>目前有尊贵的知名品牌VIP用户已超过100位，</td><td><a href="/suppler/Payment/RegPayment.aspx"><img src="/resource/images/ucenterpay.jpg"  border="0"/></a></td><td>&nbsp;与他们同享受以下尊贵特权</td>  </tr>  </table>  </div>
        <div style="padding-top:10px;">
        <table border="0" cellpadding="0" cellspacing="0" class="paytable">
        <tr><td style="width:250px;background-color:#A6A6A6;"  valign="middle">功能明细</td>
        <td style="width:190px;background-color:#A6A6A6;"  valign="middle">免费用户</td><td style="width:180px;background-color:#A6A6A6;color:Red;"  valign="middle" >VIP会员(12000元/年)</td> </tr> 
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

        <div style="width:660px;text-align:left;">说明：抢先注册成为家具快搜的会员，现在入驻享受五折优惠价6000元/年 。</div>
        </div>
        </div>
        </center>
      </div>
</asp:Content>
