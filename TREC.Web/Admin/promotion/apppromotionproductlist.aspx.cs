using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Admin.promotion
{
    public partial class apppromotionproductlist : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlbrand.DataSource = ECAppPromotion.GetPromotionAppBrandList("");
                ddlbrand.DataTextField = "title";
                ddlbrand.DataValueField = "bid";
                ddlbrand.DataBind();
                ddlbrand.Items.Insert(0, new ListItem("请选择", ""));


                ddluser.DataSource = ECAppPromotion.GetAppProductListUsers();
                ddluser.DataTextField = "name";
                ddluser.DataValueField = "mid";
                ddluser.DataBind();
                ddluser.Items.Insert(0, new ListItem("请选择", ""));




                ShowData();
            }
        }

        protected void ShowData()
        {
            string strWhere="";
            if (ddlbrand.SelectedValue != "")
            {
                strWhere += " and brandid=" + ddlbrand.SelectedValue;
            }
            if (ddluser.SelectedValue != "")
            {
                strWhere += " and mid=" + ddluser.SelectedValue;
            }

            strWhere = strWhere != "" && strWhere!=null ? strWhere.Substring(4, strWhere.Length - 4) : strWhere;


            rptList.DataSource = ECAppPromotion.GetAppProductList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
            lbcount.Text = "结果数量：" + tmpPageCount;
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
                ECAppPromotion.DeleteAppProductCustomerByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void ddlbrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        protected void ddluser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}