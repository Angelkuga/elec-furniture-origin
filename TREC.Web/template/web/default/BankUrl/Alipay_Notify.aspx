<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.BankUrl.Alipay_Notify" %>

<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
</head>
<body>
     <%
      
         string alipayNotifyURL = "https://mapi.alipay.com/gateway.do?service=notify_verify";
         //string alipayNotifyURL = "http://notify.alipay.com/trade/notify_query.do?";//此路径是在上面链接地址无法起作用时替换使用。
         string partner = "2088201363427732"; 		        //partner合作伙伴id（必须填写）
         string key = "upmquh9vjvqid4innz8mww9730c7xld6";    //partner 的对应交易安全校验码（必须填写）
         string _input_charset = "utf-8";//编码类型，完全根据客户自身的项目的编码格式而定，千万不要填错。否则极其容易造成MD5加密错误。

         alipayNotifyURL = alipayNotifyURL + "&partner=" + partner + "&notify_id=" + Request.Form["notify_id"];

         //获取支付宝ATN返回结果，true是正确的订单信息，false 是无效的
         string responseTxt = TREC.Payment.AliPay.Get_Http(alipayNotifyURL, 120000);

         //*******加密签名程序开始*******
         int i;
         NameValueCollection coll;
         //Load Form variables into NameValueCollection variable.
         coll = Request.Form;

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
                     prestr.Append(Sortedstr[i] + "=" + Request.Form[Sortedstr[i]]);
                 }
                 else
                 {
                     prestr.Append(Sortedstr[i] + "=" + Request.Form[Sortedstr[i]] + "&");

                 }
             }
         }

         prestr.Append(key);

         string mysign = TREC.Payment.AliPay.GetMD5(prestr.ToString(), _input_charset);
         //*******加密签名程序结束*******

         string sign = Request.Form["sign"];

         if (mysign == sign && responseTxt == "true")   //验证支付发过来的消息，签名是否正确，只要成功进如这个判断里，则表示该页面已被支付宝服务器成功调用
         //但判断内出现自身编写的程序相关错误导致通知给支付宝并不是发送success的消息或没有更新客户自身的数据库的情况，请自身程序编写好应对措施，否则查明原因时困难之极
         {
             if (Request.Form["trade_status"] == "TRADE_FINISHED" || Request.Form["trade_status"] == "TRADE_SUCCESS")//   判断支付状态_交易成功结束（文档中有枚举表可以参考）   
             {
                 //更新自己数据库的订单语句，请自己填写一下
                 string strOrderNO = Request.Form["out_trade_no"];//订单号
                 string strPrice = Request.Form["total_fee"];//金额 
                 //Woesoft.BLL.OrderBLL.UpdateOrderStatus(strOrderNO, "10");
                 
                 EnPayMent model = new EnPayMent();
                 model = ECPayMent.GetPayMent(" where OrderCode='" + strOrderNO + "' and Price=" + strPrice);
                 if (ECPayMent.InsertPayMentLog(model) > 0)
                 {
                     ECPayMent.DeletePayMent(" where OrderCode='" + strOrderNO + "' and Price=" + strPrice);
                 }
                 
                 EnMember _member = ECMember.GetMemberInfo(" Where id=" + model.Mid);
                 if (_member != null)
                 {
                     //修改客户充值状态
                     EnMember Member = new EnMember();
                     Member.overprice = 0;
                     Member.useprice = Convert.ToDecimal(strPrice);
                     Member.Isrecharge = true;
                     Member.RegStatcTime = DateTime.Now;
                     Member.id = _member.id;
                     if (_member.VipLevel == 0)
                     { Member.VipLevel = 1; }
                     else
                     { Member.VipLevel = _member.VipLevel; }
                     DateTime RegEndTime = _member.RegEndTime;
                     DateTime DateNow = DateTime.Now;
                     TimeSpan ts1 = new TimeSpan(DateNow.Ticks);
                     TimeSpan ts2 = new TimeSpan(RegEndTime.Ticks);
                     
                     if (RegEndTime > DateNow)
                     {
                         Member.RegEndTime = RegEndTime.AddMonths(model.Types);
                     }
                     else
                     {
                         Member.RegEndTime = DateNow.AddMonths(model.Types);
                     }

                     ECMember.ModifyMenber(Member);
                 }

             }
             else
             {
                 //更新自己数据库的订单语句，请自己填写一下
             }

             Response.Write("success");     //返回给支付宝消息，成功，请不要改写这个success
             //success与fail及其他字符的区别在于，支付宝的服务器若遇到success时，则不再发送请求通知（即不再调用该页面，让该页面再次运行起来），
             //若不是success，则支付宝默认没有收到成功的信息，则会反复不停地调用该页面直到失效，有效调用时间是24小时以内。

             //最好写TXT文件，以记录下是否异步返回记录。

             //写文本，纪录支付宝返回消息，比对md5计算结果（如网站不支持写txt文件，可改成写数据库）
             string TOEXCELLR = "MD5结果:mysign=" + mysign + ",sign=" + sign + ",responseTxt=" + responseTxt;
             StreamWriter fs = new StreamWriter(Server.MapPath("Message2") + ".txt", false, System.Text.Encoding.Default);
             fs.Write(TOEXCELLR);
             fs.Close();
         }
         else
         {
             Response.Write("fail");

             //最好写TXT文件，以记录下是否异步返回记录。

             //写文本，纪录支付宝返回消息，比对md5计算结果（如网站不支持写txt文件，可改成写数据库）
             string TOEXCELLR = "MD5结果:mysign=" + mysign + ",sign=" + sign + ",responseTxt=" + responseTxt;
             StreamWriter fs = new StreamWriter(Server.MapPath("Message2") + ".txt", false, System.Text.Encoding.Default);
             fs.Write(TOEXCELLR);
             fs.Close();
         }
    %>
</body>
</html>
