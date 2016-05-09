using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using System.Data;
using System.Text;
using TREC.Payment;

namespace TREC.Web.ajax
{
    public partial class ShowOrderList : System.Web.UI.Page
    {
        public Dictionary<string, string> dicResult
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("-1", "已取消");
                _dic.Add("0", "待付款");
                _dic.Add("1", "待付余款");
                _dic.Add("2", "备货中");
                _dic.Add("3", "送货中");
                _dic.Add("4", "已完成");

                return _dic;
            }
        }
        private string getResult(string key)
        {
            if (SubmitMeth.getInt(key) >= -1 && SubmitMeth.getInt(key) <= 4)
            {
                return dicResult.Where(p => p.Key == key).FirstOrDefault().Value;
            }
            else
            {
                return "-";
            }
        }

        private string getpay(string result,string seckey,string number)
        {
              Secret _sec = new Secret();
            if (result=="0")
            {
                string[] key = _sec.Decryption(seckey, 4).Split(',');
                if (key[7] == "0")
                {
                    return "<a  target=\"_blank\" href=\"/OrderNumber.aspx?repayNumber=" + number + "\">继续付款</a>";//没有转到支付宝前
                }
                else if (key[7] == "1")//全款支付
                {
                    return "<a  target=\"_blank\" href=\"/Ucenter/Repay.aspx?numberNumber=" + number + "&s=1\">全款支付</a>";
                }
                else if (key[7] == "2")//定金支付
                {
                    return "<a  target=\"_blank\" href=\"/Ucenter/Repay.aspx?numberNumber=" + number + "&s=2\">定金支付</a>";
                }
            }
            else if (result == "1")//余款支付
            {
                return "<a  target=\"_blank\" href=\"/Ucenter/Repay.aspx?numberNumber=" + number + "&s=3\">余款支付</a>";
            }
            else
            {
                return "-";
            }
            return "-";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int CustomerUserId = Int32.Parse(TRECommon.CookiesHelper.GetCookieCustomer("cid"));
            string pageindex = Request.Form["pageindex"];
            string seltime = Request.Form["seltime"];
            string seltype = Request.Form["seltype"];

            StringBuilder _sqlsearch = new StringBuilder(" and customeruserid="+CustomerUserId);
            if (seltime != "0")
            {
                _sqlsearch.Append(" and createtime>=DATEADD(m,-" + seltime + ",GETDATE()) and pid=0 ");
            }
            if (seltype == "-1")
            {
                _sqlsearch.Append(" AND orderDel=1 ");
            }
            else if (seltype == "0" || seltype == "1")//待付款
            {
                _sqlsearch.Append(" and Result=" + seltype + " and  orderDel=0 and pid=0");
            }
            else if (seltype == "2")//备货中
            {
                _sqlsearch.Append(" and Deliverystatus=1 and  orderDel=0 and pid=0");
            }
            else if (seltype == "3")//送货中
            {
                _sqlsearch.Append(" and Deliverystatus=2 and  orderDel=0 and pid=0");
            }
            else if (seltype == "4")//已完成
            {
                _sqlsearch.Append(" and Deliverystatus=3 and  orderDel=0 and pid=0");
            }
            else if (seltype == "5")//已完成
            {
                _sqlsearch.Append(" ");
            }
            DataSet ds = new DataSet();
            ds = EcShoppingPay.GetOrderList(pageindex, _sqlsearch.ToString());

            StringBuilder _value = new StringBuilder(string.Empty);

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                _value.Append("<tr> <td width='200'><span class=\"tdStrong2\"><a  href=\"OrderListInfor.aspx?OrderNumber=" + r["OrderNumber"].ToString() + "\">" + r["OrderNumber"] as string + "</a></span></td>");
                _value.Append("<td class=\"tdStrong2\" width='100'>￥" + r["PaymentCount"] + "</td>");
                _value.Append("<td width='180'>" + DateTime.Parse(r["createtime"].ToString()).ToString("yyyy-MM-dd HH:mm") + "</td>");
                _value.Append("<td width='100'>" + getResult(r["Result"].ToString()) + "</td>");
                _value.Append(" <td class=\"tdControl\" width='120'>" + getpay(r["Result"].ToString(), r["extra_common_param"].ToString(), r["OrderNumber"].ToString()) + "</td>");
                _value.Append("<td width='120'><a  style=\"color:#31305c;\" href=\"OrderListInfor.aspx?OrderNumber=" + r["OrderNumber"].ToString() + "\">&nbsp;&nbsp;查看</a>&nbsp;|&nbsp;<a style=\"color:#31305c;\" href=\"javascript:onclick=orderdel('" + r["id"].ToString() + "')\">取消</a></td> </tr>");
            }

            Response.Write(_value.ToString() +"■"+ ds.Tables[2].Rows[0][0].ToString());
        }
    }
}