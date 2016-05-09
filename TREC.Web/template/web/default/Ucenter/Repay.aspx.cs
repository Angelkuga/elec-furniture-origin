using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz;
using TREC.Payment;
using Com.Alipay;
using TREC.ECommerce;

namespace TREC.Web.template.web.Ucenter
{
	public partial class Repay : System.Web.UI.Page
	{
        Secret _sec = new Secret();
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
		protected void Page_Load(object sender, EventArgs e)
		{
            if(Request["numberNumber"]!=null)
            {
                string orderNumberClick = Request["numberNumber"];

                string stype = Request["s"];

            //_list.PId = 0;
            //_list.extra_common_param = _sec.Encryption(key, 4);//生成加密字段
            //EntityOper.SubmitChanges();



            OrderList _list = new OrderList();
            _list = EntityOper.OrderList.Where(p => p.OrderNumber == orderNumberClick).FirstOrDefault();


            string key = _sec.Decryption(_list.extra_common_param, 4);
            List<string> _keylist = new List<string>();

            foreach (string s in key.Split(','))
            {
                _keylist.Add(s);
            }
            string PaymentCount = _keylist[2];
            string PaymentMinCount = _keylist[3];
            string paytype = stype;
            _keylist[5] = paytype;
            _keylist[7] = paytype;
            string paymoney = string.Empty;
            if (paytype == "1")
            {
                paymoney = PaymentCount;
            }
            else if (paytype == "2")
            {
                paymoney = PaymentMinCount;
            }
            else if (paytype == "3")
            {
                _keylist[1] = _list.Id.ToString();
                paymoney = (SubmitMeth.getdouble(PaymentCount) - SubmitMeth.getdouble(PaymentMinCount)).ToString();
            }

            // paymoney = "0.01";

            string keysend = string.Empty;
            foreach (string sc in _keylist)
            {
                keysend = keysend + sc + ",";
            }
            keysend = keysend.TrimEnd(',');


            if (paytype == "3")//生成新的定单号
            {
                EcShoppingPay _shoppay=new EcShoppingPay();
                orderNumberClick = _shoppay.OrderNumber;
                OrderList _listchild = new OrderList();
                _listchild.PId = _list.Id;
                _listchild.OrderNumber = orderNumberClick;
                _listchild.PayType = 3;
                _listchild.extra_common_param =_sec.Encryption(keysend,4);
                _listchild.ActivitieType = 0;
                _listchild.CustomerUserId = _list.CustomerUserId;
                _listchild.CreateTime = DateTime.Now;
                EntityOper.OrderList.InsertOnSubmit(_listchild);
                EntityOper.SubmitChanges();
                
            }
            //Alipay_NotifyCur _pay = new Alipay_NotifyCur();
            //Response.Write(_pay.ShowAliPay(orderNumberClick, paymoney, _sec.Encryption(keysend, 4)));


            ////////////////////////////////////////////请求参数////////////////////////////////////////////
            //    //string notify_url = "http://192.168.1.115:84/BankUrl/Alipay_NotifyCur.aspx";
            //    ////服务器返回url（Alipay_Return.aspx文件所在路经），必须是完整的路径地址
            //    //string return_url = "http://192.168.1.115:84/BankUrl/Alipay_ReturnCur.aspx";
            //支付类型


            string requrl = "http://pay.jiajuks.com/";
           // string requrl = "http://192.168.1.115:8085/";
            string payment_type = "1";
            //必填，不能修改
            //服务器异步通知页面路径
            string notify_url = requrl+"/notify_url.aspx";
            //需http://格式的完整路径，不能加?id=123这类自定义参数

            //页面跳转同步通知页面路径
            string return_url = requrl+"/return_url.aspx";
            //需http://格式的完整路径，不能加?id=123这类自定义参数，不能写成http://localhost/

            //商户订单号
            string out_trade_no = orderNumberClick;
            //商户网站订单系统中唯一订单号，必填

            //订单名称
            string subject = "家具快搜在线定购";
            //必填

            //付款金额
            string total_fee = paymoney;
            //必填

            //订单描述

            string body = "家具快搜在线定购";
            //商品展示地址
            string show_url = "";


            //防钓鱼时间戳
            string anti_phishing_key = "";
            //若要使用请调用类文件submit中的query_timestamp函数

            //客户端的IP地址
            string exter_invoke_ip = "";
            //非局域网的外网IP地址，如：221.0.0.1


            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("partner", Config.Partner);
            sParaTemp.Add("seller_email", Config.Seller_email);
            sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTemp.Add("service", "create_direct_pay_by_user");
            sParaTemp.Add("payment_type", payment_type);
            sParaTemp.Add("notify_url", notify_url);
            sParaTemp.Add("return_url", return_url);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", body);
            sParaTemp.Add("extra_common_param", _sec.Encryption(keysend, 4));


            //建立请求
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            Response.Write(sHtmlText);
            Response.End();
            }
		}
	}
}