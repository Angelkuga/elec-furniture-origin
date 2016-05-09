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
    public partial class marketlist : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 分页条件设置
                if (!string.IsNullOrEmpty(Request["ddlauditstatus"]))
                    ddlauditstatus.SelectedValue = Request["ddlauditstatus"].ToString();
                if (!string.IsNullOrEmpty(Request["ddllinestatus"]))
                    ddllinestatus.SelectedValue = Request["ddllinestatus"].ToString();
                if (!string.IsNullOrEmpty(Request["txttitle"]))
                    txttitle.Text = Request["txttitle"].ToString();
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
            if (!string.IsNullOrEmpty(txttitle.Text))
            {
                strWhere += string.Format(" and title like '%{0}%'", txttitle.Text);
            }
            //审核状态
            if (!string.IsNullOrEmpty(ddlauditstatus.SelectedValue))
            {
                strWhere += " and auditstatus=" + ddlauditstatus.SelectedValue;
            }
            //上/下线
            if (!string.IsNullOrEmpty(ddllinestatus.SelectedValue))
            {
                strWhere += " and linestatus=" + ddllinestatus.SelectedValue;
            }
            string areacode = Request.Form["ddlareacode_value"] == null ? Request.Params["ddlareacode_value"] == null ? "" : Request.Params["ddlareacode_value"].ToString() : Request.Form["ddlareacode_value"];
            //地址
            if (!string.IsNullOrEmpty(areacode) && areacode != "0")
            {
                strWhere += " and areacode ='" + areacode + "'";
            }
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern =
                string.Format("marketlist.aspx?ddlauditstatus={0}&ddllinestatus={1}&txttitle={2}&ddlareacode_value={3}&page={4}",
            ddlauditstatus.SelectedValue, ddllinestatus.SelectedValue, txttitle.Text, areacode, "{0}");
            rptList.DataSource = ECMarket.GetMarketList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
            AspNetPager1.UrlRewritePattern = "marketlist.aspx?page={0}&title=" + txttitle.Text;
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
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
                ECMarket.DeletEnMarketByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        public string GetBrandCount(object Markid)
        {
            string _str = "0";
            if (Markid != null)
            {
                Hashtable hash = ECMarket.GetMarkCount(Markid.ToString())[0];
                if (hash != null)
                {
                    _str = hash["BrandCount"].ToString();
                }
            }
            return _str;
        }

        /// <summary>
        /// 下线并且未通过审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                ModifyTable_auditstatus_linestatus(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist, EnumModifyType.market, false, "id");

                UiCommon.JscriptPrint(this.Page, "批量下线并且未通过审核成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                ModifyTable_auditstatus_linestatus(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist, EnumModifyType.market, true, "id");

                UiCommon.JscriptPrint(this.Page, "批量审核通过并且上线成功!", Request.Url.AbsoluteUri, "Success");
            }
        }
    }
}