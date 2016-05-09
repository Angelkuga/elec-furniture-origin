using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Suppler.market
{
    public partial class setmarketstoryshop : SupplerPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.menuName = "setmarketstoryshop";
                ShowData();
            }
        }
        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECMarketStoreyShop.DeleteMarketStoreyShop(TypeConverter.StrToInt(ECommon.QueryId));
               // UiCommon.JscriptPrint(this.Page, "删除除功!", Request.Url.AbsoluteUri, "Success");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "click", "alert('删除除功！');location.href='setmarketstoryshop.aspx';", true);
            }

            if (ECommon.QueryEdit == "3" && ECommon.QueryId != "" && ECommon.QueryValue != "")
            {
                ECMarketStoreyShop.UpMarketShopTop(ECommon.QueryId, ECommon.QueryValue);
                //UiCommon.JscriptPrint(this.Page, "置顶成功!", Request.Url.AbsoluteUri, "Success");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "click", "alert('置顶成功！');location.href='setmarketstoryshop.aspx';", true);
            }

            if (ECommon.QueryEdit == "4" && ECommon.QueryId != "" && ECommon.QueryValue != "")
            {
                ECMarketStoreyShop.UpMarketShopRecommend(ECommon.QueryId, ECommon.QueryValue);
                //UiCommon.JscriptPrint(this.Page, "推荐成功!", Request.Url.AbsoluteUri, "Success");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "click", "alert('推荐成功！');location.href='setmarketstoryshop.aspx';", true);
            }

            string strWhere = " marketid=" + marketInfo.id;
            rptList.DataSource = ECMarketStoreyShop.GetMarketStoreyShopList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
        }

        protected void lbtnUpLev_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                TextBox txtlev = (TextBox)rptList.Items[i].FindControl("txtlev");
                if (cb.Checked)
                {
                    ECMarketStoreyShop.UpMarketShopLev(id, txtlev.Text == "" ? "0" : txtlev.Text);
                }
            }
            //UiCommon.JscriptPrint(this.Page, "级别更新成功!", Request.Url.AbsoluteUri, "Success");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "click", "alert('级别更新成功！');location.href='setmarketstoryshop.aspx';", true);
        }
    }
}