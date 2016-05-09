using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TREC.ECommerce;
using TREC.Payment;
using Haojibiz;
using Com.Alipay;

namespace TREC.Web.template.web.default3
{
	public partial class OrderNumber : System.Web.UI.Page
	{
        public string showNumber = "";
        public string PaymentCount = "";
        public string PaymentMinCount = "";
        Secret _sec = new Secret();

        /// <summary>
        /// 新生成定单
        /// </summary>
        private void Newpay()
        {
            if (Request.Form["IdsNumber"] != null)
            {
                string CustomerUserId = TRECommon.CookiesHelper.GetCookieCustomer("cid");
                if (CustomerUserId != "")
                {


                    DataTable dt = new DataTable();
                    string IdsNumber = Request.Form["IdsNumber"].Trim();//定单号+Ids
                    string checkAddressId = Request.Form["checkAddressId"];//@AddressId
                    string inputyf1 = Request.Form["inputyf1"];//运费 @Freight
                    string inputyf2 = Request.Form["inputyf2"];//安装费  @InstallationFee
                    string sendgroup = Request.Form["sendgroup"];//@TransportMeth  配送方式
                    string checkInvoice = Request.Form["checkInvoice"];//@InvoiceClaim 是否开发票
                    string InvoiceTop = Request.Form["InvoiceTop"].Trim();//@InvoiceTop 发票抬头
                    string InvoiceAddress = Request.Form["InvoiceAddress"].Trim();//@InvoiceAddress 发票地址
                    string InvoiceZipcode = Request.Form["InvoiceZipcode"].Trim();// @InvoiceZipcode 发票邮编
                    string Description = Request.Form["Description"].Trim();

                    checkInvoice = checkInvoice == "on" ? "1" : "0";
                    string ids = IdsNumber.Split('|')[1];
                    string orderNumber = IdsNumber.Split('|')[0];
                    if (orderNumber.Length > 5)
                    {
                        txt_number.Text = orderNumber;
                        dt = EcShoppingPay.CreateOrderNumber(ids, orderNumber, EcShoppingPay.getInt(CustomerUserId), EcShoppingPay.getInt(checkAddressId)
                            , EcShoppingPay.getDouble(inputyf1), EcShoppingPay.getDouble(inputyf2), EcShoppingPay.getInt(sendgroup), EcShoppingPay.getInt(checkInvoice)
                            , InvoiceTop, InvoiceAddress, InvoiceZipcode, Description);
                        if (dt.Rows[0][0].ToString() == orderNumber)
                        {
                            showNumber = orderNumber;
                            PaymentCount = dt.Rows[0]["PaymentCount"].ToString();
                            PaymentMinCount = dt.Rows[0]["PaymentMinCount"].ToString();
                            string id = dt.Rows[0]["Id"].ToString();
                            string key = id + ",0," + PaymentCount + "," + PaymentMinCount + ",0,0,0,0"; //key=Id,Pid,全款，定金,成功支付金额,paytype,result,submittype
                                                                                                      //submittype 提交类型 1全款支付 2定金支付 3余款支付
                            OrderList _list = new OrderList();
                            _list = EntityOper.OrderList.Where(p => p.OrderNumber == showNumber).FirstOrDefault();
                            _list.PId = 0;
                            _list.extra_common_param = _sec.Encryption(key, 4);//生成加密字段
                            EntityOper.SubmitChanges();
                        }
                        else
                        {
                            showNumber = "<span style='color:red;'>生成定单失败</span>";
                        }
                    }
                    else
                    {
                        showNumber = "<span style='color:red;'>生成定单失败</span>";
                    }
                }
                else
                {
                    Response.Redirect("/loginuser.aspx");
                }

            }
        }

        private void Repayoper()
        {
            OrderList _order = new OrderList();
            _order = EntityOper.OrderList.Where(p => p.OrderNumber == Request["repayNumber"].Trim()).FirstOrDefault();

            if (_order != null)
            {
                showNumber = _order.OrderNumber;
                PaymentCount = _order.PaymentCount.ToString();
                PaymentMinCount = _order.PaymentMinCount.ToString();
                txt_number.Text = showNumber;
            }
        }
   
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Request["repayNumber"] != null)
            {
                Repayoper();
            }
            else
            {
 
            }

            Newpay();
            

		}
        private void sendMail(string content, string mail)
        {
            string mailsubject = content;

            bool rsmail = EmailHelper.SendEmail("用户在线支付定单提醒", mail, mailsubject);
        }
        protected void imgbng_Click(object sender, ImageClickEventArgs e)
        {

            string orderNumberClick = txt_number.Text;
            
           
            //_list.PId = 0;
            //_list.extra_common_param = _sec.Encryption(key, 4);//生成加密字段
            //EntityOper.SubmitChanges();

           

            OrderList _list = new OrderList();
            _list = EntityOper.OrderList.Where(p => p.OrderNumber == orderNumberClick).FirstOrDefault();
            

            string key = _sec.Decryption(_list.extra_common_param,4);
            List<string> _keylist = new List<string>();

            foreach (string s in key.Split(','))
            {
                _keylist.Add(s);
            }
            string PaymentCount = _keylist[2];
            string PaymentMinCount = _keylist[3];
            string paytype = Request["orderpaytype"];
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

           // paymoney = "0.01";

            string keysend = string.Empty;
            foreach (string sc in _keylist)
            {
                keysend = keysend + sc + ",";
            }
            keysend = keysend.TrimEnd(',');
            string mailcode = TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/Ucenter/OrderListInforMail.aspx?OrderNumber=" + orderNumberClick + "&c=" + _list.CustomerUserId;
            //Alipay_NotifyCur _pay = new Alipay_NotifyCur();
            //Response.Write(_pay.ShowAliPay(orderNumberClick, paymoney, _sec.Encryption(keysend, 4)));
            string Description = "用户定单号：" + orderNumberClick + ",定单金额：" + paymoney + "<a href='" + mailcode + "' target='_blank'>查看定单详情</a>";
            sendMail(Description, "angela@jiajuks.com");
            sendMail(Description, "liujing@jiajuks.com");

            string requrl = "http://pay.jiajuks.com/";
           // string requrl = "http://192.168.1.115:8085/";
            ////////////////////////////////////////////请求参数////////////////////////////////////////////
            //    //string notify_url = "http://192.168.1.115:84/BankUrl/Alipay_NotifyCur.aspx";
            //    ////服务器返回url（Alipay_Return.aspx文件所在路经），必须是完整的路径地址
            //    //string return_url = "http://192.168.1.115:84/BankUrl/Alipay_ReturnCur.aspx";
            //支付类型
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
            string show_url ="";
            

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
        //key=Id,Pid,全款，定金,成功支付金额,paytype,result
	}
}