using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Admin.grouporder
{
    public partial class grouporderpaylist : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECGroupOrderPay.DeleteGroupOrderPay(TypeConverter.StrToInt(ECommon.QueryId));
            }
            //if (Request.QueryString["mid"] != null && Request.QueryString["mid"].ToString() != "")
            //{
            //    rptList.DataSource = ECGroupOrderPay.GetGroupOrderPayList(ECommon.QueryPageIndex, AspNetPager1.PageSize, "", out tmpPageCount);
            //    rptList.DataBind();
            //    AspNetPager1.RecordCount = tmpPageCount;
            //}
            //else
            //{
            //    rptList.Visible = false;
            //    AspNetPager1.Visible = false;
            //}
            string strWhere = "";

            if (ECommon.QueryPId != "")
            {
                strWhere += " and grouporderid=" + ECommon.QueryPId;
            }

            strWhere = strWhere != "" ? strWhere.Substring(4, strWhere.Length - 4) : strWhere;


            rptList.DataSource = ECGroupOrderPay.GetGroupOrderPayList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
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
                ECGroupOrderPay.DeleteGroupOrderPayByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }
    }
}