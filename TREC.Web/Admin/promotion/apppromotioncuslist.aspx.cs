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
    public partial class apppromotioncuslist : AdminPageBase
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


                ddluser.DataSource = ECAppPromotion.GetAppCustomerListUsers();
                ddluser.DataTextField = "name";
                ddluser.DataValueField = "name";
                ddluser.DataBind();
                ddluser.Items.Insert(0, new ListItem("请选择", ""));


                ddlarea.DataSource = ECAppPromotion.GetAppCustomerListAreas();
                ddlarea.DataTextField = "address";
                ddlarea.DataValueField = "address";
                ddlarea.DataBind();
                ddlarea.Items.Insert(0, new ListItem("请选择", "-1"));
                ddlarea.Items.Insert(1, new ListItem("未填写", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECAppPromotion.DeleteAppBrandCustomer(TypeConverter.StrToInt(ECommon.QueryId));
            }

            string strWhere = "";
            if (ddlbrand.SelectedValue != "")
            {
                strWhere += " and aid in (select id from t_promotionappbrand where bid=" + ddlbrand.SelectedValue + ")";
            }
            if (ddluser.SelectedValue != "")
            {
                strWhere += " and name='" + ddluser.SelectedValue + "'";
            }
            if (ddlarea.SelectedValue != "-1" && ddlarea.SelectedValue != "0" && ddlarea.SelectedValue != "")
            {
                strWhere += " and address='" + ddlarea.SelectedValue + "'";
            }
            if (ddlarea.SelectedValue == "0" && ddlarea.SelectedValue == "")
            {
                strWhere += " and ( address='' or address='0' or address is null)";
            }

            strWhere = strWhere != "" && strWhere != null ? strWhere.Substring(4, strWhere.Length - 4) : strWhere;

            rptList.DataSource = ECAppPromotion.GetAppBrandCustomerList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
            lbcount.Text = "结果数量：" + tmpPageCount;
        }

        protected void rptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
               Label lb_aid=e.Item.FindControl("lb_aid") as Label;

               EnPromotionAppBrand m = ECAppPromotion.GetPromotionAppBrandInfo(" where id=" + lb_aid.Text);
               if (m!=null && m.title != null)
               {
                   lb_aid.Text = m.title;
               }
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
                ECAppPromotion.DeleteAppBrandCustomerByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void ddlarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        protected void ddluser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();

        }

        protected void ddlbrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}