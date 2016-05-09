using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TREC.Config;
using System.Net;
using System.IO;

namespace TREC.Payment
{
    public class Alipay_Notify
    {

        string service = "create_direct_pay_by_user";                       //服务名称，这个是识别是何接口实现何功能的标识，请勿修改

        string seller_email = "service@fordio.com";                         //商家签约时的支付宝帐号，即收款的支付宝帐号
        string sign_type = "MD5";                                           //加密类型,签名方式“不用改”
        string key = "upmquh9vjvqid4innz8mww9730c7xld6";                    //安全校验码，与partner是一组，获取方式是：用签约时支付宝帐号登陆支付宝网站www.alipay.com，在商家服务我的商家里即可查到。
        string partner = "2088201363427732";                                //商户ID，合作身份者ID，合作伙伴ID
        string _input_charset = "utf-8";                                    //编码类型，完全根据客户自身的项目的编码格式而定，千万不要填错。否则极其容易造成MD5加密错误。

        string subject = "家具快搜充值";                              //商品名称，也可称为订单名称，该接口并不是单一的只能买一样东西，可把一次支付当作一次下订单
        string body = "家具快搜充值。";                               //商品描述，即备注

        //支付宝消息验证地址
        private string Https_veryfy_url = "https://mapi.alipay.com/gateway.do?service=notify_verify&";

        //产品订单支付
        public string ShowAliPay(string ordercode, string TotalMoney)
        {
            //业务参数赋值；
            //string gateway = "https://mapi.alipay.com/gateway.do?";	//支付接口

            string show_url = "http://www.alipay.com/";                         //展示地址，即在支付页面时，商品名称旁边的“详情”的链接地址。

            string out_trade_no = ordercode;                   //客户自己的订单号，订单号必须在自身订单系统中保持唯一性
            TotalMoney = "0.01";
            string total_fee = TotalMoney;                  //商品价格，也可称为订单的总金额

            //服务器通知url（Alipay_Notify.aspx文件所在路经），必须是完整的路径地址
            string notify_url = "" + WebConfigs.GetConfig().WebSupplerUrl + "/BankUrl/Alipay_Notify.aspx";
            //服务器返回url（Alipay_Return.aspx文件所在路经），必须是完整的路径地址
            string return_url = "" + WebConfigs.GetConfig().WebSupplerUrl + "/BankUrl/Alipay_Return.aspx";

            //构造数组；
            //以下数组即是参与加密的参数，若参数的值不允许为空，若该参数为空，则不要成为该数组的元素
            string[] para ={
            "service="+service,
            "partner=" + partner,
            "seller_email=" + seller_email,
            "out_trade_no=" + out_trade_no,
            "subject=" + subject,
            "body=" + body,
            "total_fee=" + total_fee, 
            "show_url=" + show_url,
            "payment_type=1",
            "notify_url=" + notify_url,
            "return_url=" + return_url,
            "_input_charset="+_input_charset
            };
            //支付URL生成
            string aliay_url = AliPay.CreatUrl(
                //gateway,//GET方式传递参数时请去掉注释
                para,
                _input_charset,
                sign_type,
                key
                );
            StringBuilder sb = new StringBuilder();

            //以下是POST方式传递参数
            sb.Append("<form name='alipaysubmit' method='post' action='https://mapi.alipay.com/gateway.do?_input_charset=utf-8' >");
            sb.Append("<input type='hidden' name='service' value=" + service + ">");
            sb.Append("<input type='hidden' name='partner' value=" + partner + ">");
            sb.Append("<input type='hidden' name='seller_email' value=" + seller_email + ">");
            sb.Append("<input type='hidden' name='out_trade_no' value=" + out_trade_no + ">");
            sb.Append("<input type='hidden' name='subject' value=" + subject + ">");
            sb.Append("<input type='hidden' name='body' value=" + body + ">");
            sb.Append("<input type='hidden' name='total_fee' value=" + total_fee + ">");
            sb.Append("<input type='hidden' name='show_url' value=" + show_url + ">");
            sb.Append("<input type='hidden' name='return_url' value=" + return_url + ">");
            sb.Append("<input type='hidden' name='notify_url' value=" + notify_url + ">");
            sb.Append("<input type='hidden' name='payment_type' value=1>");
            sb.Append("<input type='hidden' name='sign' value=" + aliay_url + ">");
            sb.Append("<input type='hidden' name='sign_type' value=" + sign_type + ">");
            sb.Append("</form>");
            sb.Append("<script>");
            sb.Append("document.alipaysubmit.submit()");
            sb.Append("</script>");

            return sb.ToString();
        }

        /// <summary>
        ///  验证消息是否是支付宝发出的合法消息
        /// </summary>
        /// <param name="inputPara">通知返回参数数组</param>
        /// <param name="notify_id">通知验证ID</param>
        /// <param name="sign">支付宝生成的签名结果</param>
        /// <returns>验证结果</returns>
        public bool Verify(SortedDictionary<string, string> inputPara, string notify_id, string sign)
        {
            //获取返回时的签名验证结果
            bool isSign = GetSignVeryfy(inputPara, sign);
            //获取是否是支付宝服务器发来的请求的验证结果
            string responseTxt = "true";
            if (notify_id != null && notify_id != "") { responseTxt = GetResponseTxt(notify_id); }

            //写日志记录（若要调试，请取消下面两行注释）
            //string sWord = "responseTxt=" + responseTxt + "\n isSign=" + isSign.ToString() + "\n 返回回来的参数：" + GetPreSignStr(inputPara) + "\n ";
            //Core.LogResult(sWord);

            //判断responsetTxt是否为true，isSign是否为true
            //responsetTxt的结果不是true，与服务器设置问题、合作身份者ID、notify_id一分钟失效有关
            //isSign不是true，与安全校验码、请求时的参数格式（如：带自定义参数等）、编码格式有关
            if (responseTxt == "true" && isSign)//验证成功
            {
                return true;
            }
            else//验证失败
            {
                return false;
            }
        }

        /// <summary>
        /// 获取返回时的签名验证结果
        /// </summary>
        /// <param name="inputPara">通知返回参数数组</param>
        /// <param name="sign">对比的签名结果</param>
        /// <returns>签名验证结果</returns>
        private bool GetSignVeryfy(SortedDictionary<string, string> inputPara, string sign)
        {
            Dictionary<string, string> sPara = new Dictionary<string, string>();

            //过滤空值、sign与sign_type参数
            sPara = Core.FilterPara(inputPara);

            //获取待签名字符串
            string preSignStr = Core.CreateLinkString(sPara);

            //获得签名验证结果
            bool isSgin = false;
            if (sign != null && sign != "")
            {
                switch (sign_type)
                {
                    case "MD5":
                        isSgin = TREC.Payment.AlipayMD5.Verify(preSignStr, sign, key, _input_charset);
                        break;
                    default:
                        break;
                }
            }

            return isSgin;
        }

        /// <summary>
        /// 获取是否是支付宝服务器发来的请求的验证结果
        /// </summary>
        /// <param name="notify_id">通知验证ID</param>
        /// <returns>验证结果</returns>
        private string GetResponseTxt(string notify_id)
        {
            string veryfy_url = Https_veryfy_url + "partner=" + partner + "&notify_id=" + notify_id;

            //获取远程服务器ATN结果，验证是否是支付宝服务器发来的请求
            string responseTxt = Get_Http(veryfy_url, 120000);

            return responseTxt;
        }

        /// <summary>
        /// 获取远程服务器ATN结果
        /// </summary>
        /// <param name="strUrl">指定URL路径地址</param>
        /// <param name="timeout">超时时间设置</param>
        /// <returns>服务器ATN结果</returns>
        private string Get_Http(string strUrl, int timeout)
        {
            string strResult;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                myReq.Timeout = timeout;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.Default);
                StringBuilder strBuilder = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    strBuilder.Append(sr.ReadLine());
                }

                strResult = strBuilder.ToString();
            }
            catch (Exception exp)
            {
                strResult = "错误：" + exp.Message;
            }

            return strResult;
        }
    }
}
