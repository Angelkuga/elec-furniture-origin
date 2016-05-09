using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Admin.product
{
    public partial class productlist : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlproductcategory.Items.Clear();
                ddlproductcategory.DataSource = ECProductCategory.GetProductCategoryListToDDL("");
                ddlproductcategory.DataTextField = "title";
                ddlproductcategory.DataValueField = "id";
                ddlproductcategory.DataBind();
                ddlproductcategory.Items.Insert(0, new ListItem("请选择分类", ""));


                ddlproductbigcategory.Items.Clear();
                ddlproductbigcategory.DataSource = ECProductCategory.GetProductCategoryList(" parentid=0 ");
                ddlproductbigcategory.DataTextField = "title";
                ddlproductbigcategory.DataValueField = "id";
                ddlproductbigcategory.DataBind();
                ddlproductbigcategory.Items.Insert(0, new ListItem("请选择大类", ""));


                ddlbrand.DataSource = ECBrand.GetBrandList("").OrderBy(c => c.title);
                ddlbrand.DataTextField = "title";
                ddlbrand.DataValueField = "id";
                ddlbrand.DataBind();
                ddlbrand.Items.Insert(0, new ListItem("请选择品牌", ""));

                ddlattribute.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumAttribute), ddlattribute);
                ddlattribute.Items.Insert(0, new ListItem("请选择", ""));
                ddlattribute.Items.Remove(new ListItem("精华", "104"));
                ddlattribute.Items.Remove(new ListItem("幻灯", "105"));
                ddlattribute.Items.Remove(new ListItem("高亮", "106"));

                #region 活动类型数据
                List<TREC.Entity.t_promotionstype> promType = TREC.ECommerce.t_promotionstypeBLL.GetPromotionTypeList();
                ddlPT.DataSource = promType;
                ddlPT.DataTextField = "title";
                ddlPT.DataValueField = "id";
                ddlPT.DataBind();
                ddlPT.Items.Insert(0, new ListItem("请选择活动", ""));
                #endregion


                #region 分页条件设置
                if (!string.IsNullOrEmpty(Request["ddlproductcategory"]))
                    ddlproductcategory.SelectedValue = Request["ddlproductcategory"].ToString();
                if (!string.IsNullOrEmpty(Request["ddlbrand"]))
                    ddlbrand.SelectedValue = Request["ddlbrand"].ToString();
                if (!string.IsNullOrEmpty(Request["ddlauditstatus"]))
                    ddlauditstatus.SelectedValue = Request["ddlauditstatus"].ToString();
                if (!string.IsNullOrEmpty(Request["ddllinestatus"]))
                    ddllinestatus.SelectedValue = Request["ddllinestatus"].ToString();
                if (!string.IsNullOrEmpty(Request["ddlPT"]))
                    ddlPT.SelectedValue = Request["ddlPT"].ToString();
                if (!string.IsNullOrEmpty(Request["txtProductName"]))
                    txtProductName.Text = Request["txtProductName"].ToString();
                if (!string.IsNullOrEmpty(Request["ddlattribute"]))
                    ddlattribute.SelectedValue = Request["ddlattribute"].ToString();
                if (!string.IsNullOrEmpty(Request["ddlproductbigcategory"]))
                    ddlproductbigcategory.SelectedValue = Request["ddlproductbigcategory"].ToString();
                #endregion
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
            if (ddlproductcategory.SelectedValue != "" && ddlproductcategory.SelectedValue != "0")
            {
                strWhere += " and categoryid=" + ddlproductcategory.SelectedValue;
            }
            if (ddlproductbigcategory.SelectedValue != "" && ddlproductbigcategory.SelectedValue != "0")
            {
                strWhere += string.Format(" and categoryid in (select id from dbo.t_productcategory where parentid={0}) ", ddlproductbigcategory.SelectedValue);
            }
            if (ddlbrand.SelectedValue != "" && ddlbrand.SelectedValue != "0")
            {
                strWhere += " and brandid=" + ddlbrand.SelectedValue;
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
            //活动类型数据
            if (!string.IsNullOrEmpty(ddlPT.SelectedValue))
            {
                strWhere += " and id in (select productid from t_productattribute where ProductAttributePromotion=" + ddlPT.SelectedValue + ")";
            }
            if (!string.IsNullOrEmpty(ddlattribute.SelectedValue))
            {
                strWhere += string.Format(" and  ','+attribute+',' like '%,{0},%'", ddlattribute.SelectedValue);
            }
            if (txtProductName.Text != "")
            {
                strWhere += " and (isnull(sku,'')+isnull(title,'')+isnull(shottitle,'')+isnull(brandtitle,'') like '%" + txtProductName.Text + "%')";
            }
            //strWhere = strWhere.Length > 0 ? strWhere.Substring(4, strWhere.Length - 4) : strWhere;

            int pageCount = 0;
            rptList.DataSource = ECProduct.GetProductList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out pageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = pageCount;
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern = string.Format("productlist.aspx?ddlproductcategory={0}&ddlbrand={1}&ddlauditstatus={2}&ddllinestatus={3}&ddlPT={4}&txtProductName={5}&ddlattribute={6}&ddlproductbigcategory={7}&page={8}",
                ddlproductcategory.SelectedValue, ddlbrand.SelectedValue, ddlauditstatus.SelectedValue, ddllinestatus.SelectedValue, ddlPT.SelectedValue, txtProductName.Text, ddlattribute.SelectedValue, ddlproductbigcategory.SelectedValue, "{0}");
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
                ECProduct.DeleteProductByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void lkBtnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
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
                ECProduct.ModifyProductlinestatusByID(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist, "1,1", "auditstatus,linestatus");
                UiCommon.JscriptPrint(this.Page, "批量审核通过并且上线成功!", Request.Url.AbsoluteUri, "Success");
            }
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
                ECProduct.ModifyProductlinestatusByID(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist, "0,0", "auditstatus,linestatus");
                UiCommon.JscriptPrint(this.Page, "批量下线并且未通过审核成功!", Request.Url.AbsoluteUri, "Success");
            }
        }
    }
}