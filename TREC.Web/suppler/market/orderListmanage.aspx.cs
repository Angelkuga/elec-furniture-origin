using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Entity;
using TREC.ECommerce;
using TRECommon;
using Haojibiz;
using System.Data;

namespace TREC.Web.Suppler.market
{
    public partial class orderListmanage : SupplerPageBase
    {

        public string getpaystatic(string result)
        {
            string v = string.Empty;
            switch (result)
            {
                case "0": v = "未支付"; break;
                case "1": v = "定金支付完成"; break;
                case "2": v = "全款支付完成"; break;
                case "3": v = "余款支付完成"; break;

            }

            return v;
        }

        public List<string> NoReadOrderList = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SupplerPageBase.IsPayMember())
            {
                Response.Redirect("/suppler/Payment/RegPayment.aspx");
            }
            Master.menuName = "marketstoryshopmanage";
           
            if (!IsPostBack)
            {
               
                ShowData(1);
            }
            
        }


        public string isRead(string orderList)
        {
            if (NoReadOrderList.Contains(orderList))
            {
                return "<span style='color:red;'>未查看</span>";
               
            }
            else
            {
                return "已查看";  
            }
        }
        #region 显示数据

        protected void ShowData(int pageindex)
        {
            int result = -1;
            int Deliverystatus = 0;
            int createmid =SubmitMeth.getInt(CookiesHelper.GetCookie("mid"));
            int OrderDel = 2;

            string s = drop_search.SelectedValue;
            if (s.Contains("Result"))
            {
                result = SubmitMeth.getInt(s.Split(',')[1]);
            }
            else if (s.Contains("Deliverystatus"))
            {
                Deliverystatus = SubmitMeth.getInt(s.Split(',')[1]);
            }
            else if (s.Contains("OrderDel"))
            {
                OrderDel = SubmitMeth.getInt(s.Split(',')[1]);
            }

            DataSet readDS = new DataSet();
            readDS = EcShoppingPay.getCompanyNoRead(CookiesHelper.GetCookie("mid"));

            foreach (DataRow r in readDS.Tables[1].Rows)
            {
                NoReadOrderList.Add(r["ordernumber"].ToString());
            }
            if (IsPayMember())
            {
                rptList.DataSource = EcShoppingPay.getCompanyOrderList(pageindex, result, Deliverystatus, createmid, OrderDel).Tables[0];
                rptList.DataBind();
                AspNetPager1.RecordCount = tmpPageCount;
            }
            
        }
        #endregion

     

  
        #region 搜索数据

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData(1);
        }
        #endregion

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            ShowData(e.NewPageIndex);
        }

      

    }
}