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
    public partial class menulist : AdminPageBase
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
                ECMenu.DeleteMenu(TypeConverter.StrToInt(ECommon.QueryId));
            }
            if (Request.QueryString["mid"] != null && Request.QueryString["mid"].ToString() != "")
            {
                rptList.DataSource = ECMenu.GetMenuList("", " where module=" + Request.QueryString["mid"], "");
                rptList.DataBind();
                AspNetPager1.RecordCount = tmpPageCount;
            }
            else
            {
                rptList.Visible = false;
                AspNetPager1.Visible = false;
            }
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
                ECMenu.DeleteMenuByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }
    }
}