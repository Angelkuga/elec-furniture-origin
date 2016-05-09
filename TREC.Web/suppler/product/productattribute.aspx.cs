using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using System.Text;

namespace TREC.Web.Suppler.product
{
    public partial class productattribute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddltype.Items.Clear();
                ddltype.DataSource = ECProductCategory.GetProductCategoryListToDDL("");
                ddltype.DataTextField = "title";
                ddltype.DataValueField = "id";
                ddltype.DataBind();
                ddltype.Items.Insert(0, new ListItem("请选择分类", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (Request.QueryString["id"]!="")
            {
                ddltype.SelectedValue = Request.QueryString["id"];
            }

        }

    }
}