using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TRECommon;

namespace TREC.Web.Admin.link
{
    public partial class linksList : System.Web.UI.Page
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
                ECProduct.DeleteProduct(TypeConverter.StrToInt(ECommon.QueryId));
            }
            string strWhere = " 1=1 ";
            //上/下线
            if (!string.IsNullOrEmpty(ddllinestatus.SelectedValue))
            {
                strWhere += " and linestatus=" + ddllinestatus.SelectedValue;
            }

            if (txttitle.Text != "")
            {
                strWhere += " and title like '%" + txttitle.Text + "%'";
            }

            int pageCount = 0;
            rptList.DataSource = ECLinks.GetLinksList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out pageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = pageCount;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkBtnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                ECLinks.DeletLinksByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        public string GetStatusStr(object obj)
        {
            string str = string.Empty;
            if (obj == null)
            {
                return str;
            }
            switch (obj.ToString())
            {
                case "-1":
                    str = "审核中";
                    break;
                case "0":
                    str = "下线";
                    break;
                case "1":
                    str = "上线";
                    break;
                case "-99":
                    str = "未通过";
                    break;
            }
            return str;
        }

    }
}