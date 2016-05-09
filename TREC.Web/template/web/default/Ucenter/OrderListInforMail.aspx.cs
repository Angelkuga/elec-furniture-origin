using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Payment;
using Haojibiz;
using TREC.Web.Code;
using System.Text;
using TREC.ECommerce;
using Com.Alipay;

namespace TREC.Web.template.web.Ucenter
{
    public partial class OrderListInforMail : PayBase
	{
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        Secret _sec = new Secret();

        public string getOrderNumber
        {
            get
            {
                if (Request["OrderNumber"] != null)
                {
                    if (Request["pid"] != null)
                    {
                        OrderList orp = new OrderList();
                        orp = EntityOper.OrderList.Where(p => p.Id == SubmitMeth.getInt(Request["pid"])).FirstOrDefault();
                        return orp.OrderNumber;
                    }
                    else
                    {
 
                    }
                    return Request["OrderNumber"];
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public int CustomerUserId
        {
            get
            {
                if (Request["c"] != null)
                {
                    return SubmitMeth.getInt(Request["c"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        public string getTransportMeth(object t)
        {
            if (t != null)
            {
               return TransportMeth.Where(p => p.Key == t.ToString()).First().Value;
            }
            else
            {
                return string.Empty;
            }
        }
        public string getResult(int v)
        {
            if (v >= 1 && v <= 3)
            {
                return Result.Where(p => p.Key == v.ToString()).FirstOrDefault().Value;
            }
            else
            {
                return "未支付";
            }
        }
        public string paystr = string.Empty;

        public OrderList _order = new OrderList();
        public string results = string.Empty;
        //EcShoppingPay

        public string nopay = string.Empty;

        private string getpay(string result, string seckey, string number)
        {
            Secret _sec = new Secret();
            if (result == "0")
            {
                string[] key = _sec.Decryption(seckey, 4).Split(',');
                if (key[7] == "0")
                {
                    return " <a   href=\"/OrderNumber.aspx?repayNumber=" + number + "\"><img src=\"/resource/content/images/ucenter/paysubmit.jpg\"  border=\"0\" style=\"margin-right:20px;\"/> </a>";//没有转到支付宝前
                }
                else if (key[7] == "1")//全款支付
                {
                    return "<a   href=\"/Ucenter/Repay.aspx?numberNumber=" + number + "&s=1\"><img src=\"/resource/content/images/ucenter/paysubmit.jpg\"  border=\"0\" style=\"margin-right:20px;\"/></a>";
                }
                else if (key[7] == "2")//定金支付
                {
                    return "<a   href=\"/Ucenter/Repay.aspx?numberNumber=" + number + "&s=2\"><img src=\"/resource/content/images/ucenter/paysubmit.jpg\"  border=\"0\" style=\"margin-right:20px;\"/></a>";
                }
            }
            else if (result == "1")//余款支付
            {
                return "<a   href=\"/Ucenter/Repay.aspx?numberNumber=" + number + "&s=3\"><img src=\"/resource/content/images/ucenter/paysubmit.jpg\"  border=\"0\" style=\"margin-right:20px;\"/></a>";
            }
            else
            {
                return "";
            }
            return "";
        }

        public string getplayurl = string.Empty;

		protected void Page_Load(object sender, EventArgs e)
		{
           
              
                _order = EntityOper.OrderList.Where(p => p.OrderNumber == getOrderNumber && p.CustomerUserId == CustomerUserId).FirstOrDefault();
                StringBuilder _value = new StringBuilder(string.Empty);
                if (_order.Result > 0)
                {
                    _value.Append(" <tr style=\"color:#333333;\"><td align=\"center\">" + _order.total_fee + "</td> <td align=\"center\">" + _order.gmt_create + "</td><td align=\"center\">" + getResult(_order.Result.Value) + "</td></tr> ");
                    if(Request["pid"] != null)
                    {
                        OrderList orp = new OrderList();
                        orp = EntityOper.OrderList.Where(p => p.Id == SubmitMeth.getInt(Request["pid"])).FirstOrDefault();
                        _value.Append(" <tr style=\"color:#333333;\"><td align=\"center\">" + orp.total_fee + "</td> <td align=\"center\">" + orp.gmt_create + "</td><td align=\"center\">" + getResult(orp.Result.Value) + "</td></tr> ");
                    }
                }
                else
                {
                    _value.Append(" <tr style=\"color:#333333;\"><td align=\"center\" colspan=\"3\">无支付信息</td> </tr> ");
                }
                paystr = _value.ToString();
                results = getResult(_order.Result.Value);
                Repeater_list.DataSource = EcShoppingPay.ShoppingTrolleyList(CustomerUserId, getOrderNumber);
                Repeater_list.DataBind();
                getplayurl = getpay(_order.Result.Value.ToString(), _order.extra_common_param, _order.OrderNumber);
                switch (_order.Result.Value)
                {
                    case 0: nopay = _order.PaymentCount.ToString(); break;
                    case 1: nopay = (_order.PaymentCount - _order.PaymentMinCount).ToString(); break;
                    default: nopay = "0"; break;
                }
           
           
		}

      
	}
}