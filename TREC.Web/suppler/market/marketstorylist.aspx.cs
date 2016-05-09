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
    public partial class marketstorylist : SupplerPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.menuName = "marketstorylist";
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECMarketStorey.DeleteMarketStorey(TypeConverter.StrToInt(ECommon.QueryId));
            }

            string strWhere = " marketid=" + marketInfo.id;
            rptList.DataSource = ECMarketStorey.GetMarketStoreyList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            string idlist="";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    idlist += id + ",";
                }
            }
            if (idlist.Length > 0)
            {
                ECMarketStorey.DeleteMarketStoreyByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
               // UiCommon.JscriptPrint(this.Page, "删除成功!", Request.Url.AbsoluteUri, "Success");
               // ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "dd", "alert('删除成功！');location.href='marketstorylist.aspx;", true);
                ScriptUtils.ShowAndRedirect("删除成功!", "marketstorylist.aspx");
            }
        }
    }
}