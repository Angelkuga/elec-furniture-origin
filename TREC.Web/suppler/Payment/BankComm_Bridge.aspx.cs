using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Payment;
using TREC.ECommerce;
using TRECommon;
using TREC.Entity;

namespace TREC.Web.Suppler.Payment
{
    public partial class BankComm_Bridge : SupplerPageBase
    {
        public string PayMentCode = "";
        public string Types = string.Empty;
        public string Bank = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Types = Request.QueryString["t"] == null ? "" : Request.QueryString["t"].ToString();
            Bank = Request.QueryString["b"] == null ? "" : Request.QueryString["b"].ToString();

            decimal price = 0;// Utils.GetPayMentTypes0(Types);

            int moom = 0;
            //充值日期计算-----单位：月
            if (!string.IsNullOrEmpty(Types))
            {
                switch (Types)
                {
                    case "0":
                        moom = 0;
                        break;
                    case "1":
                        moom = 3;
                        break;
                    case "2":
                        moom = 6;
                        break;
                    default:
                        moom = 0;
                        break;
                }
            }

            if (memberInfo.VipLevel == 0)
            {
                price = 1000;// Utils.GetPayMentTypes0(Types); 
            }
            else
            {
                price = Utils.GetPayMentTypes1(Types); 
            }


            if (price == 0)
            {
                Response.Write("对不起。参数不对");
                Response.End();
            }
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            int hours = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;
            int seconds = DateTime.Now.Second;

            string _month = ((month < 10) ? "0" : "") + month.ToString();
            string _day = ((day < 10) ? "0" : "") + day.ToString();
            string _hours = ((hours < 10) ? "0" : "") + hours.ToString();
            string _minutes = ((minutes < 10) ? "0" : "") + minutes.ToString();
            string _seconds = ((seconds < 10) ? "0" : "") + seconds.ToString();

            string orderid = "JT" + (year - 1900).ToString() + _month + _day + _hours + _minutes + _seconds;
            string orderDate = year.ToString() + _month + _day;
            string orderTime = _hours + _minutes + _seconds;

            EnPayMent model = new EnPayMent();
            model.OrderCode = orderid;
            model.Price = price;
            model.Types = moom;
            model.Mid = memberinfo.memberInfo.id;
            model.Bank = Bank;
            ECPayMent.InsertPayMent(model);

            BankComm bk = new BankComm();
            PayMentCode = bk.GetBankCommPayment(orderid, orderDate, orderTime, price, "1", Bank);
        }
    }
}