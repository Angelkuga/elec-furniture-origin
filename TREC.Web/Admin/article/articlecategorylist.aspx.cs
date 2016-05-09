using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Admin.article
{
    public partial class articlecategorylist :AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ECArticle.BindArticleCategory(ddlcategory);
                ddlcategory.Items.Insert(0, new ListItem("请选择", ""));
                WebControlBind.DrpBind(typeof(EnumAttribute), ddlattribute);
                ddlattribute.Items.Insert(0, new ListItem("请选择", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECArticle.DeleteArticleCategory(TypeConverter.StrToInt(ECommon.QueryId));
            }
            if (ECommon.QueryEdit == "3" && ECommon.QueryId != "")
            {
                ECArticle.CategoryArticleNodeUp(TypeConverter.StrToInt(ECommon.QueryId));
            }
            string strWhere = "";
            if (ddlattribute.SelectedValue != "")
            {
                strWhere += " and attribute like '%" + ddlattribute.SelectedValue + ",%'";
            }
            if (ddlcategory.SelectedValue != "" && ddlcategory.SelectedValue != "0")
            {
                strWhere += " and categoryid=" + ddlcategory.SelectedValue;
            }
            if (txtKeywords.Text != "")
            {
                strWhere += " and title like '%" + txtKeywords.Text + "%'";
            }

            rptList.DataSource = ECArticle.GetReaderArticleCategoryList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, "", "lft", "asc", out tmpPageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            ShowData();
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

                ECArticle.DeleteArticleCategoryByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }
    }
}