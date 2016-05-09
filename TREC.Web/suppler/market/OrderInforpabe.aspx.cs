using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Payment;
using Haojibiz;
using System.Text;
using TREC.ECommerce;
using System.Data;
using TRECommon;


namespace TREC.Web.Suppler.market
{
    public partial class OrderInforpabe : SupplerPageBase
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
                    return Request["OrderNumber"].Trim();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

      
        public Dictionary<string, string> PayType
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("0", "未支付");
                _dic.Add("1", "全款支付");
                _dic.Add("2", "定金支付");
                _dic.Add("3", "余款支付");

                return _dic;
            }
        }
        public Dictionary<string, string> TransportMeth
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("1", "只工作日送货(双休日假日不送货)");
                _dic.Add("2", "工作日,双休日与节假日均可送货");
                _dic.Add("3", "只双休日节假日送货(工作日不送货)");
                return _dic;
            }
        }
        /// <summary>
        /// 结果处理
        /// </summary>
        public Dictionary<string, string> Result
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("0", "未支付");
                _dic.Add("1", "定金支付完成");
                _dic.Add("2", "全款支付完成");
                _dic.Add("3", "余款支付完成");

                return _dic;
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
                divoper.Style.Add("display", "block");
                return Result.Where(p => p.Key == v.ToString()).FirstOrDefault().Value;
            }
            else
            {
                divoper.Style.Add("display", "none");
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

        private void isread()
        {
            if (EntityOper.OrderListMemberRead.Where(p => p.OrderNumber == getOrderNumber && p.MemberId == SubmitMeth.getInt(CookiesHelper.GetCookie("mid"))).ToList().Count == 0)
            {
                OrderListMemberRead _cread = new OrderListMemberRead();
                _cread.MemberId = SubmitMeth.getInt(CookiesHelper.GetCookie("mid"));
                _cread.OrderNumber = getOrderNumber;
                _cread.CreateTime = DateTime.Now;

                EntityOper.OrderListMemberRead.InsertOnSubmit(_cread);
                EntityOper.SubmitChanges();
            }
        }
        public double allpriceshow = 0;
        public string showpric = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SupplerPageBase.IsPayMember())
            {
                Response.Redirect("/suppler/Payment/RegPayment.aspx");
            }

            if (IsPayMember())
            {
                isread();
                _order = EntityOper.OrderList.Where(p => p.OrderNumber == getOrderNumber).FirstOrDefault();
                StringBuilder _value = new StringBuilder(string.Empty);
                if (_order != null && _order.Result > 0)
                {
                    _value.Append(" <tr style=\"color:#333333;\"><td align=\"center\">" + _order.total_fee + "</td> <td align=\"center\">" + _order.gmt_create + "</td><td align=\"center\">" + getResult(_order.Result.Value) + "</td></tr> ");
                    if (Request["pid"] != null)
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
                DataTable dt = new DataTable();
                dt = EcShoppingPay.ShoppingTrolleyList(_order.CustomerUserId.Value, getOrderNumber, CookiesHelper.GetCookie("mid"));
                foreach (DataRow r in dt.Rows)
                {
                    if (r["resultPrice"] != null)
                    {
                        allpriceshow = allpriceshow + SubmitMeth.getdouble(r["resultPrice"].ToString());
                    }
                }

                showpric = String.Format("{0:F}", allpriceshow); ;
                Repeater_list.DataSource = dt;
                Repeater_list.DataBind();

                List<int> _inforids = new List<int>();
                foreach (DataRow r in dt.Rows)
                {
                    int proinforid = SubmitMeth.getInt(r["proinforid"].ToString());
                    _inforids.Add(proinforid);
                }

                OrderInfor _orderinfor = new OrderInfor();
                _orderinfor = EntityOper.OrderInfor.Where(p => p.CustomerUserId == _order.CustomerUserId && p.OrderNumber == _order.OrderNumber && _inforids.Contains(p.productattributeId.Value)).FirstOrDefault();

                if (_orderinfor != null && _orderinfor.Deliverystatus != null && _orderinfor.Deliverystatus.Value > 0)
                {
                    if (_orderinfor.Deliverystatus.Value == 1)
                    {
                        ListItem item2 = new ListItem();
                        item2.Text = "送货中";
                        item2.Value = "2";

                        ListItem item3 = new ListItem();
                        item3.Text = "已完成";
                        item3.Value = "3";

                        drop_oper.Items.Add(item2);
                        drop_oper.Items.Add(item3);
                    }
                    else if (_orderinfor.Deliverystatus.Value == 2)
                    {

                        ListItem item3 = new ListItem();
                        item3.Text = "已完成";
                        item3.Value = "3";

                        drop_oper.Items.Add(item3);
                    }

                }
                else
                {
                    ListItem item1 = new ListItem();
                    item1.Text = "备货中";
                    item1.Value = "1";

                    ListItem item2 = new ListItem();
                    item2.Text = "送货中";
                    item2.Value = "2";

                    ListItem item3 = new ListItem();
                    item3.Text = "已完成";
                    item3.Value = "3";

                    drop_oper.Items.Add(item1);
                    drop_oper.Items.Add(item2);
                    drop_oper.Items.Add(item3);
                }
                getplayurl = getpay(_order.Result.Value.ToString(), _order.extra_common_param, _order.OrderNumber);
                switch (_order.Result.Value)
                {
                    case 0: nopay = _order.PaymentCount.ToString(); break;
                    case 1: nopay = (_order.PaymentCount - _order.PaymentMinCount).ToString(); break;
                    default: nopay = "0"; break;
                }

            }
        }

        protected void bnt_save_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = EcShoppingPay.ShoppingTrolleyList(_order.CustomerUserId.Value, getOrderNumber, CookiesHelper.GetCookie("mid"));
            //proinforid

           _order = EntityOper.OrderList.Where(p => p.OrderNumber == getOrderNumber).FirstOrDefault();
           List<OrderInfor> _listinfor = new List<OrderInfor>();
           foreach (DataRow r in dt.Rows)
           {
               int proinforid = SubmitMeth.getInt(r["proinforid"].ToString());
               OrderInfor _infors=new OrderInfor();
               _infors=EntityOper.OrderInfor.Where(p=>p.CustomerUserId==_order.CustomerUserId&&p.OrderNumber==_order.OrderNumber&&p.productattributeId==proinforid).FirstOrDefault();
               _infors.Deliverystatus = SubmitMeth.getInt(drop_oper.SelectedValue);

               _listinfor.Add(_infors);
           }
           EntityOper.SubmitChanges();
           Response.Write("<script>alert('操作成功！');location.href='"+Request.Url.ToString()+"';</script>");
        }
    }
}