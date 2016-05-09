using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Admin.dealer
{
    public partial class dealerlist : AdminPageBase
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
                if (!string.IsNullOrEmpty(Request["txtDealerTitle"]))
                    txtDealerTitle.Text = Request["txtDealerTitle"].ToString();
                if (!string.IsNullOrEmpty(Request["txtBrandTitle"]))
                    txtBrandTitle.Text = Request["txtBrandTitle"].ToString();
                #endregion
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECDealer.DeleteDealer(TypeConverter.StrToInt(ECommon.QueryId));
            }
            string strWhere = " 1=1 ";
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
            //工厂名称
            if (!string.IsNullOrEmpty(txtDealerTitle.Text.Trim()))
            {
                strWhere += " and title like '%" + txtDealerTitle.Text.Trim() + "%'";
            }
            //品牌名称
            if (!string.IsNullOrEmpty(txtBrandTitle.Text.Trim()))
            {
                strWhere += " and BrandTitle like '%" + txtBrandTitle.Text.Trim() + "%'";
            }
            string areacode = Request.Form["ddlareacode_value"] == null ? Request.Params["ddlareacode_value"] == null ? "" : Request.Params["ddlareacode_value"].ToString() : Request.Form["ddlareacode_value"];
            //地址
            if (!string.IsNullOrEmpty(areacode) && areacode != "0")
            {
                strWhere += " and areacode ='" + areacode + "'";
            }
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern =
                string.Format("dealerlist.aspx?ddlauditstatus={0}&ddllinestatus={1}&txtDealerTitle={2}&txtBrandTitle={3}&page={4}",
            ddlauditstatus.SelectedValue, ddllinestatus.SelectedValue, txtDealerTitle.Text, txtBrandTitle.Text, "{0}");
            rptList.DataSource = ECDealer.GetAdminDealerList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
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
                ECDealer.DeleteDealerByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}