<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.BankUrl.Alipay_Return" %>

<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="System.IO" %>
<%@ Register Src="../ascx/_head.ascx" TagName="_head" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_nav.ascx" TagName="_nav" TagPrefix="uc4" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <uc2:_resource ID="_resource1" runat="server" />
</head>
<body>
    <uc2:_head ID="_head1" runat="server" />
    <uc4:_nav ID="_nav1" runat="server" />
    <%
      
        string orderCode = string.Empty;
        string orderId = string.Empty;
        bool isSuccessed = true;

        string alipayNotifyURL = "https://mapi.alipay.com/gateway.do?service=notify_verify";
        //string alipayNotifyURL = "http://notify.alipay.com/trade/notify_query.do?";//此路径是在上面链接地址无法起作用时替换使用。
        string key = "2088201363427732";                            //partner 的对应交易安全校验码（必须填写）
        string partner = "upmquh9vjvqid4innz8mww9730c7xld6"; 		//partner合作伙伴id（必须填写）
        string _input_charset = "utf-8";//编码类型，完全根据客户自身的项目的编码格式而定，千万不要填错。否则极其容易造成MD5加密错误。

        alipayNotifyURL = alipayNotifyURL + "&partner=" + partner + "&notify_id=" + Request.QueryString["notify_id"];

        //获取支付宝ATN返回结果，true是正确的订单信息，false 是无效的
        string responseTxt = TREC.Payment.AliPay.Get_Http(alipayNotifyURL, 120000);

        //*******加密签名程序开始//*******
        int i;
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.QueryString;

        // Get names of all forms into a string array.
        String[] requestarr = coll.AllKeys;

        //进行排序；
        string[] Sortedstr = TREC.Payment.AliPay.BubbleSort(requestarr);

        //构造待md5摘要字符串 ；

        StringBuilder prestr = new StringBuilder();

        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (Request.Form[Sortedstr[i]] != "" && Sortedstr[i] != "sign" && Sortedstr[i] != "sign_type")
            {
                if (i == Sortedstr.Length - 1)
                {
                    prestr.Append(Sortedstr[i] + "=" + Request.QueryString[Sortedstr[i]]);
                }
                else
                {
                    prestr.Append(Sortedstr[i] + "=" + Request.QueryString[Sortedstr[i]] + "&");

                }
            }
        }

        prestr.Append(key);

        //生成Md5摘要；
        string mysign = TREC.Payment.AliPay.GetMD5(prestr.ToString(), _input_charset);
        //*******加密签名程序结束*******

        string sign = Request.QueryString["sign"];

        //Response.Write(prestr.ToString());  //调试用，支付宝服务器返回时的完整路径。
        orderCode = Request.QueryString["out_trade_no"];//订单号
        string strPrice = Request.QueryString["total_fee"];//金额
        string strTradeStatus = Request.QueryString["TRADE_STATUS"];//订单状态
        if (!string.IsNullOrEmpty(sign) && !string.IsNullOrEmpty(orderCode) && !string.IsNullOrEmpty(strPrice) && !string.IsNullOrEmpty(strTradeStatus))   //验证支付发过来的消息，签名是否正确
        {
            isSuccessed = true;

            //更新自己数据库的订单语句，请自己填写一下
           

            Response.Write("<div style=\"height:300px; width:990px;margin:10px auto; border:1px solid #54902C;\">");
            Response.Write("<p style=\"text-align:center; height:25px; font-size:31px; font-weight:bold; color:#54902C; padding-top:100px;\">");
            Response.Write("<img src=\"" + TREC.ECommerce.ECommon.WebResourceUrl + "/web/images/common/ture.jpg\" style=\"padding-right:10px;\"/>本次充值成功</p>");
            Response.Write("<p style=\" text-align:center; padding-top:50px;\">您的订单号：<span style=\"color:#005EAC\">" + orderCode + "</span></p>");
            Response.Write("</div>");
            Response.Write("<div style=\"text-align:center; line-height:25px;\"><img src=\"" + TREC.ECommerce.ECommon.WebResourceUrl + "/web/images/common/cztp.jpg\" style=\"padding-right:10px;\"/>");
            Response.Write("温馨提示：如有疑问，请拨打400 6066 818</div>");

        }
        else
        {
            isSuccessed = false;
            Response.Write("<div style=\"height:300px; width:990px;margin:10px auto; border:1px solid #FAC6B5;\">");
            Response.Write("<p style=\"text-align:center; height:25px; font-size:31px; font-weight:bold; color:#5D5D5D; padding-top:100px;\">");
            Response.Write("<img src=\"" + TREC.ECommerce.ECommon.WebResourceUrl + "/web/images/common/faile.jpg\" style=\"padding-right:10px;\"/>本次充值失败</p>");
            Response.Write("<p style=\" text-align:center; padding-top:50px;\">您的订单号：<span style=\"color:#005EAC\">" + orderCode + "</span></p>");
            Response.Write("</div>");
            Response.Write("<div style=\"text-align:center; line-height:25px;\"><img src=\"" + TREC.ECommerce.ECommon.WebResourceUrl + "/web/images/common/cztp.jpg\" style=\"padding-right:10px;\"/>");
            Response.Write("温馨提示：如有疑问，请拨打400 6066 818</div>");
        }
    %>
    <uc4:_foot ID="_foot1" runat="server" />
</body>
</html>
