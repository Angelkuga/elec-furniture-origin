using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using System.Collections;

namespace TREC.Web.Admin.market
{
    public partial class marketcliquelist : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 分页条件设置
                if (!string.IsNullOrEmpty(Request["ddlauditstatus"]))
                    ddlauditstatus.SelectedValue = Request["ddlauditstatus"].ToString();
                #endregion
                ShowData();
            }
        }
        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECMarket.DeletEnMarket(TypeConverter.StrToInt(ECommon.QueryId));
            }
            string strWhere = " 1=1 ";
            //审核状态
            if (!string.IsNullOrEmpty(ddlauditstatus.SelectedValue))
            {
                strWhere += " and auditstatus=" + ddlauditstatus.SelectedValue;
            }
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern =
                string.Format("marketcliquelist.aspx?ddlauditstatus={0}&page={1}", ddlauditstatus.SelectedValue, "{0}");
            rptList.DataSource = ECommerce.ECMarketClique.GetMarketCliqueList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
        }

        protected void linkGo_Click(object sender, EventArgs e)
        {
            string idlist = "";
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
                string[] idArr = idlist.TrimEnd(',').Split(',');
                foreach (string items in idArr)
                {
                    ECommerce.ECMarketClique.SetMarketCliqueAuditstatus(items, 1);
                }

                UiCommon.JscriptPrint(this.Page, "批量审核通过成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void lonkNo_Click(object sender, EventArgs e)
        {
            string idlist = "";
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

                ECommerce.ECMarketClique.SetMarketCliqueAuditstatus(idlist.TrimEnd(','), 0);

                UiCommon.JscriptPrint(this.Page, "批量审核不通过成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {

        }
    }
}