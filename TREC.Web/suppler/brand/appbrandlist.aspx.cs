using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Suppler.brand
{
    public partial class appbrandlist : SupplerPageBase
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
                ECBrand.DeleteBrand(TypeConverter.StrToInt(ECommon.QueryId));
            }
            string strWhere="";

            switch (memberInfo.type)
            {
                case (int)EnumMemberType.经销商:
                    strWhere += " dealerid=" + dealerInfo.id;
                    break;
                case (int)EnumMemberType.工厂企业:
                    strWhere += " companyid=" + companyInfo.id;
                    break;
            }

            rptList.DataSource = ECAppBrand.GetAppBrandList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
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
                ECAppBrand.DeleteAppBrandByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected bool GetEdit(string bid)
        {
            if (dealerCreateBrandIdList.Contains(bid))
                return true;
            return false;
        }

        public string GetStatusStr(object obj)
        {
            string str = string.Empty;
            if (obj == null)
            {
                return str;
            }
            EnBrand _enb = ECBrand.GetBrandInfo("where id = " + obj.ToString());
            if (_enb == null)
            {
                return str;
            }
            switch (_enb.linestatus.ToString())
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

        public string GetStatusStrA(object obj)
        {
            string str = string.Empty;
            if (obj == null)
            {
                return str;
            }
            EnBrand _enb = ECBrand.GetBrandInfo("where id = " + obj.ToString());
            if (_enb == null)
            {
                return str;
            }
            switch (_enb.auditstatus.ToString())
            {
                case "-1":
                    str = "审核中";
                    break;
                case "0":
                    str = "待审核";
                    break;
                case "1":
                    str = "审核通过";
                    break;
                case "-99":
                    str = "未通过";
                    break;
            }
            return str;
        }

        /// <summary>
        /// 上线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnUp_Click(object sender, EventArgs e)
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
                ECBrand.ModifyBrandlinestatusByID(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist, 1);
                UiCommon.JscriptPrint(this.Page, "上线成功!", Request.Url.AbsoluteUri, "Success");
            }
            else
            {
                UiCommon.JscriptPrint(this.Page, "请选择要上线的品牌!", Request.Url.AbsoluteUri, "Success");
            }
        }

        /// <summary>
        /// 下线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDon_Click(object sender, EventArgs e)
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
                ECBrand.ModifyBrandlinestatusByID(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist, 0);
                UiCommon.JscriptPrint(this.Page, "下线成功!", Request.Url.AbsoluteUri, "Success");
            }
            else
            {
                UiCommon.JscriptPrint(this.Page, "请选择要下线的品牌!", Request.Url.AbsoluteUri, "Success");
            }
        }
    }
}