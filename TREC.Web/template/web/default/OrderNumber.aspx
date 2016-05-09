<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderNumber.aspx.cs" Inherits="TREC.Web.template.web.default3.OrderNumber" EnableViewStateMac= "false" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <script src="/resource/content/js/jquery-1.4.1.min.js"></script>
       <script src="/resource/content/js/core.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:header ID="header1" runat="server" />
       <link href="/resource/ShoppingCss/shopping.css" rel="stylesheet" type="text/css" />
    <!--菜单结束-->
<div class="site" ><a href="#">首页</a> > 购物车</div>


<div class="contentInner">
                    <div class="inner">
                        <div class="shopping">
                            <!--step start-->
                            <div class="buystep buybg03">
                                <ul>
                                    <li class="wordn"><span>1.</span>我的购物车</li>
                                    <li class="wordn"><span>2.</span>填写核对订单信息</li>
                                    <li class="wordh"><span>3.</span>成功提交订单</li>
                                </ul>
                            </div>
                            <!--step end-->
                            <div class="buycon">
                                <div class="succful">
                                    <img src="/resource/ShoppingCss/duigou.gif" width="61" height="54" original="/images/shopping/duigou.gif">
                                    <p><span>订单提交成功，请您尽快付款！</span><br>
                                  订单号：<b><%=showNumber%><input type="hidden" name="payordercode" value="20150320002"></b></p>
                                    <div class="clear"></div>
                              </div>
                                <h2 class="choicepay" id="paytype" style="font-size:16px;">选择支付类型：&nbsp;&nbsp;<input value="1" name="orderpaytype" type="radio" checked="checked">&nbsp;<font>全额付款</font>&nbsp;&nbsp;￥<%=PaymentCount %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input value="2" name="orderpaytype" type="radio" id="Radio1">&nbsp;<font>预付订金</font>&nbsp;&nbsp;￥<%=PaymentMinCount%></h2>
                                <h2 class="choicepay">选择支付方式</h2>
                                <div class="shrinfo">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tbody><tr>
                                    <td width="13%" align="right">在线支付：</td>
                                    <td width="87%"><input name="payType" class="payType" type="radio" value="1" checked="">即时到账，支持绝大部分银行借记卡及部门银行信用卡。</td>
                                </tr>
                                <tr id="online_1" class="onlinelist">
                                    <td align="right">&nbsp;</td>
                                    <td><div class="pay">
                                      <div class="alipay">
                                         <input type="radio" class="radio" value="Alipay" checked="checked" onclick="chkAlipay(this,0);" name="RadioGroup1"><img src="/resource/ShoppingCss/index-10.jpg" id="alipay" onclick="chkAlipay(this,1);" alt="支付宝" width="111" height="51" original="/images/shopping/zhifubao.jpg">
                                        <p> 户名：上海福美娜家具有限公司<br>账号：service@fordio.com</p>
                                        <div class="clear"></div>
                                        <div class="xuanbank">
                                        <h3>您已选择支付宝进行支付</h3>
                                        <ul class="list-h"><li>
                                          <div class="bank-logo" style=" border:none;"><img src="/resource/ShoppingCss/zhifubao.jpg" alt="支付宝" original="/images/shopping/zhifubao.jpg"></div></li></ul>
					                  <div class="clear"></div>
                                    </div>
                                    </div><div class="clear"></div>
                                    </div></td>
                                </tr>
                                <tr id="paybt">
                                    <td colspan="2"><div class="paynow" style="position:relative;"> 
                                    <div style="display:none;">
                                        <asp:TextBox ID="txt_number" runat="server"></asp:TextBox> </div>
                                    <asp:ImageButton  
                                            ID="imgbng" ImageUrl="/resource/ShoppingCss/ljzf.gif" runat="server" 
                                            onclick="imgbng_Click" />
&nbsp;<div class="paytip"><b>温馨提示：</b> 当您支付完成后请勿立即关闭页面，系统会自动跳转至支付成功页面。</div></div></td>
                                </tr><input type="hidden" name="payCode" value="201503200021"><input type="hidden" name="bPrice" value="3580">
                                </tbody></table>
                                <div class="info"></div>
                          </div></div></div>
                    </div>
                    <!--content end-->
                </div>
     <uc2:footer runat="server" ID="footer1" />
    </form>
</body>
</html>
