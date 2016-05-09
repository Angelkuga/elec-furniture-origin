using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using Com.Alipay;
using TREC.Payment;
using TRECommon;
namespace TREC.Web.Suppler.Payment
{
    public partial class RegPayment : SupplerPageBase
    {
        public string username = string.Empty;
        public string RegEndTime = string.Empty;

       

        protected string markprice = "1500";
        protected string outprice = "1500";

        Secret _sec = new Secret();
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            //选中左边菜单栏目
            Master.menuName = "Payment";
            

            username = memberInfo.username;
            if (memberInfo.RegEndTime != null && memberInfo.RegEndTime != DateTime.Parse("0001/1/1 0:00:00"))
            {
                RegEndTime ="您的会员有效期："+( memberInfo.RegEndTime < DateTime.Now ? "已经到期" : memberInfo.RegEndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                RegEndTime = "未付费新会员";
            }

            rptList.DataSource = EntityOper.Company_pay.Where(p => p.MemberId == SubmitMeth.getInt(CookiesHelper.GetCookie("mid"))).OrderByDescending(p => p.Id).ToList();
            rptList.DataBind();
        }

        private void pay(string usertype, string paymoney,string body,int month )
        {

            EcShoppingPay _shoppingPay = new EcShoppingPay();

           
            string key = CookiesHelper.GetCookie("mid") + "," + usertype + ","+month+"," + DateTime.Now;//会员ID,VIP类型,年份
             string requrl = "http://pay.jiajuks.com/";
           // string requrl = "http://192.168.1.115:8085/";
            string payment_type = "1";
            //必填，不能修改
            //服务器异步通知页面路径
            string notify_url = requrl + "/Company_notify_url.aspx";
            //需http://格式的完整路径，不能加?id=123这类自定义参数

            //页面跳转同步通知页面路径
            string return_url = requrl + "/Company_return_url.aspx";
            //需http://格式的完整路径，不能加?id=123这类自定义参数，不能写成http://localhost/

            //商户订单号
            string out_trade_no = _shoppingPay.OrderNumber;
            //商户网站订单系统中唯一订单号，必填

            //订单名称
            string subject = "家具快搜在线充值";
            //必填

            //付款金额
            string total_fee = paymoney;
            //必填

            //订单描述

            
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
            sParaTemp.Add("partner", Com.Alipay.Config.Partner);
            sParaTemp.Add("seller_email", Com.Alipay.Config.Seller_email);
            sParaTemp.Add("_input_charset", Com.Alipay.Config.Input_charset.ToLower());
            sParaTemp.Add("service", "create_direct_pay_by_user");
            sParaTemp.Add("payment_type", payment_type);
            sParaTemp.Add("notify_url", notify_url);
            sParaTemp.Add("return_url", return_url);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", body);
            sParaTemp.Add("extra_common_param", _sec.Encryption(key, 4));


            //建立请求
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            Response.Write(sHtmlText);
            Response.End();
        }

        public string getusertype(string t)
        {
            Dictionary<string, string> dicuser = new Dictionary<string, string>();
            dicuser.Add("0", "新会员");
            dicuser.Add("1", "新会员");
            dicuser.Add("10", "增值服务");

            return dicuser.Where(p => p.Key == t).FirstOrDefault().Value;
        }
        private void sendMail(string content, string mail)
        {
            string mailsubject = content;

            bool rsmail = EmailHelper.SendEmail("商家充值提醒", mail, mailsubject);
        }
        protected void btn_OK_Click(object sender, ImageClickEventArgs e)
        {
              string usertype = radio_usertype.SelectedValue;
              string body = string.Empty;
                string price="6000";

              int paycount = 6000;
              int month = 12;
              string checktime = Radio_time.SelectedValue;
              switch (checktime)
              {
                  case "1": paycount = 2000; month = 3; break;
                  case "2": paycount = 3500; month = 6; break;
                  case "3": paycount = 6000; month = 12; break;
              }
              if (check_other.Checked)
              {
                  paycount = paycount + 500;
              }

              if (usertype == "10" && SubmitMeth.getdouble(txt_prce.Text.Trim()) < 1)
              {
                  Response.Write("<script>alert('充值金额不能小于1元！');location.href='" + Request.Url.ToString() + "';</script>");
              }
              else
              {
                  if (usertype == "10")
                  {
                      price = txt_prce.Text.Trim();
                  }
                  else
                  {
                      price = paycount.ToString();
                  }
                  body = "充值类型：" + radio_usertype.SelectedItem.Text + ",充值金额：" + price + ",商家帐号ID:" + CookiesHelper.GetCookie("mid") + ",商家名称：" + username + "，备注说明：" + txt_descript.Text.Trim();
                  sendMail(body, "angela@jiajuks.com");
                  sendMail(body, "liujing@jiajuks.com");
                  //price = "0.01";
                  pay(usertype, price, body, month);
              }
        }
    }
}