using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Entity;
using System.Collections.Specialized;
using System.Text;
using Haojibiz;
using Com.Alipay;

namespace Com.Alipiay
{
    public partial class notify_url : System.Web.UI.Page
	{
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string alipayNotifyURL = "https://mapi.alipay.com/gateway.do?service=notify_verify";
        //    //string alipayNotifyURL = "http://notify.alipay.com/trade/notify_query.do?";//此路径是在上面链接地址无法起作用时替换使用。
        //    string partner = "2088201363427732"; 		        //partner合作伙伴id（必须填写）
        //    string key = "upmquh9vjvqid4innz8mww9730c7xld6";    //partner 的对应交易安全校验码（必须填写）
        //    string _input_charset = "utf-8";//编码类型，完全根据客户自身的项目的编码格式而定，千万不要填错。否则极其容易造成MD5加密错误。

        //    alipayNotifyURL = alipayNotifyURL + "&partner=" + partner + "&notify_id=" + Request.Form["notify_id"];

        //    //获取支付宝ATN返回结果，true是正确的订单信息，false 是无效的
        //    string responseTxt = TREC.Payment.AliPay.Get_Http(alipayNotifyURL, 120000);

        //    //*******加密签名程序开始*******
        //    int i;
        //    NameValueCollection coll;
        //    //Load Form variables into NameValueCollection variable.
        //    coll = Request.Form;

        //    // Get names of all forms into a string array.
        //    String[] requestarr = coll.AllKeys;

        //    //进行排序；
        //    string[] Sortedstr = TREC.Payment.AliPay.BubbleSort(requestarr);


        //    //构造待md5摘要字符串 ；
        //    StringBuilder prestr = new StringBuilder();

        //    for (i = 0; i < Sortedstr.Length; i++)
        //    {
        //        if (Request.Form[Sortedstr[i]] != "" && Sortedstr[i] != "sign" && Sortedstr[i] != "sign_type")
        //        {
        //            if (i == Sortedstr.Length - 1)
        //            {
        //                prestr.Append(Sortedstr[i] + "=" + Request.Form[Sortedstr[i]]);
        //            }
        //            else
        //            {
        //                prestr.Append(Sortedstr[i] + "=" + Request.Form[Sortedstr[i]] + "&");

        //            }
        //        }
        //    }

        //    prestr.Append(key);

        //    string mysign = TREC.Payment.AliPay.GetMD5(prestr.ToString(), _input_charset);
        //    //*******加密签名程序结束*******

        //    string sign = Request.Form["sign"];

        //    if (mysign == sign && responseTxt == "true")   //验证支付发过来的消息，签名是否正确，只要成功进如这个判断里，则表示该页面已被支付宝服务器成功调用
        //    //但判断内出现自身编写的程序相关错误导致通知给支付宝并不是发送success的消息或没有更新客户自身的数据库的情况，请自身程序编写好应对措施，否则查明原因时困难之极
        //    {
               

        //        if (Request.Form["trade_status"] == "TRADE_FINISHED" || Request.Form["trade_status"] == "TRADE_SUCCESS")//   判断支付状态_交易成功结束（文档中有枚举表可以参考）   
        //        {
        //            //更新自己数据库的订单语句，请自己填写一下
        //            string strOrderNO = Request.Form["out_trade_no"];//订单号
        //            string strPrice = Request.Form["total_fee"];//金额 
        //            //Woesoft.BLL.OrderBLL.UpdateOrderStatus(strOrderNO, "10");

        //            OrderList _list = new OrderList();
        //            _list = EntityOper.OrderList.Where(p => p.OrderNumber == strOrderNO).FirstOrDefault();
        //            _list.body = "答名正确";
        //            EntityOper.SubmitChanges();
                   

        //        }
        //        else
        //        {
        //            //更新自己数据库的订单语句，请自己填写一下
        //        }

        //        Response.Write("success");     //返回给支付宝消息，成功，请不要改写这个success
        //        //success与fail及其他字符的区别在于，支付宝的服务器若遇到success时，则不再发送请求通知（即不再调用该页面，让该页面再次运行起来），
        //        //若不是success，则支付宝默认没有收到成功的信息，则会反复不停地调用该页面直到失效，有效调用时间是24小时以内。

        //        //最好写TXT文件，以记录下是否异步返回记录。

        //        //写文本，纪录支付宝返回消息，比对md5计算结果（如网站不支持写txt文件，可改成写数据库）
              
        //    }
        //    else
        //    {
        //        Response.Write("fail");

        //        //最好写TXT文件，以记录下是否异步返回记录。

        //        //写文本，纪录支付宝返回消息，比对md5计算结果（如网站不支持写txt文件，可改成写数据库）
        //        string TOEXCELLR = "MD5结果:mysign=" + mysign + ",sign=" + sign + ",responseTxt=" + responseTxt;
               
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            SortedDictionary<string, string> sPara = GetRequestPost();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码


                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                    //商户订单号

                    string out_trade_no = Request.Form["out_trade_no"];

                    //支付宝交易号

                    string trade_no = Request.Form["trade_no"];

                    //交易状态
                    string trade_status = Request.Form["trade_status"];


                    if (Request.Form["trade_status"] == "TRADE_FINISHED")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序

                        //注意：
                        //退款日期超过可退款期限后（如三个月可退款），支付宝系统发送该交易状态通知
                    }
                    else if (Request.Form["trade_status"] == "TRADE_SUCCESS")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序

                        //注意：
                        //付款完成后，支付宝系统发送该交易状态通知
                    }
                    else
                    {
                    }

                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                    Response.Write("success");  //请不要修改或删除

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("无通知参数");
            }
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }
	}
}