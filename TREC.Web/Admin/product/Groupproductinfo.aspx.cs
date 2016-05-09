using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using LitJson;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using System.Collections;
using TREC.Data;


namespace TREC.Web.Admin.product
{
    public partial class Groupproductinfo : AdminPageBase
    {
        public GroupProductModel groupmode = new GroupProductModel();
        public List<EnProduct> prodlist = new List<EnProduct>();
        public int gpId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddlauditstatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumAuditStatus), ddlauditstatus);
                ddlauditstatus.Items.Insert(0, new ListItem("请选择", ""));

                ddllinestatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumLineStatus), ddllinestatus);
                ddllinestatus.Items.Insert(0, new ListItem("请选择", ""));


                chkattribute.Items.Clear();
                WebControlBind.CheckBoxListBind(typeof(EnumAttribute), chkattribute);
                chkattribute.Items.Remove(new ListItem("置顶", "101"));
                chkattribute.Items.Remove(new ListItem("精华", "104"));
                chkattribute.Items.Remove(new ListItem("幻灯", "105"));
                chkattribute.Items.Remove(new ListItem("高亮", "106"));


                ddlproductcategory.Items.Clear();
                ddlproductcategory.DataSource = ECProductCategory.GetProductCategoryListToDDL("");
                ddlproductcategory.DataTextField = "title";
                ddlproductcategory.DataValueField = "id";
                ddlproductcategory.DataBind();

                ddlbrand.DataSource = ECBrand.GetBrandList("").OrderBy(c => c.title);
                ddlbrand.DataTextField = "title";
                ddlbrand.DataValueField = "id";
                ddlbrand.DataBind();
                ddlbrand.Items.Insert(0, new ListItem("请选择品牌", ""));


                ddlbrands.DataSource = ECBrand.GetBrandList("");
                ddlbrands.Items.Insert(0, new ListItem("请选择系列", ""));


                ddlstyle.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品风格);
                ddlstyle.DataTextField = "title";
                ddlstyle.DataValueField = "value";
                ddlstyle.DataBind();
                ddlstyle.Items.Insert(0, new ListItem("请选择风格", ""));



                ddlmaterial.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品选材);
                ddlmaterial.DataTextField = "title";
                ddlmaterial.DataValueField = "value";
                ddlmaterial.DataBind();
                ddlmaterial.Items.Insert(0, new ListItem("请选择选材", ""));


                ddlcolor.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品颜色);
                ddlcolor.DataTextField = "title";
                ddlcolor.DataValueField = "value";
                ddlcolor.DataBind();
                ddlcolor.Items.Insert(0, new ListItem("请选择色系", ""));

                //活动类型数据

                ddlPT.DataSource = TREC.ECommerce.t_promotionstypeBLL.GetPromotionTypeList();
                ddlPT.DataTextField = "title";
                ddlPT.DataValueField = "id";
                ddlPT.DataBind();
                ddlPT.Items.Insert(0, new ListItem("请选择活动", ""));
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                gpId = int.Parse(ECommon.QueryId);
                groupmode = ProductBll.QueryGroupProductListByWhere(" gpid=" + ECommon.QueryId).FirstOrDefault();
                if (groupmode != null)
                {
                    prodlist = ECProduct.GetProductList(string.Format(" id in ( select ppId from  GroupProductProperty where gpId={0})", groupmode.gpId));

                    txttitle.Text = groupmode.Name;
                    txtsku.Text = groupmode.No;


                    ddlbrand.SelectedValue = groupmode.brandId.ToString();
                    ddlauditstatus.SelectedValue = groupmode.Status.ToString();
                    ddlstyle.SelectedValue = groupmode.styleId.ToString();
                    ddlproductcategory.SelectedValue = groupmode.bigCateId.ToString();
                    hfthumb.Value = groupmode.thumb;
                    hfbannel.Value = groupmode.bannel;
                    txtDescript.Text = groupmode.Descript;
                    ddlPT.SelectedValue = groupmode.groupProductPromotion.ToString();
                    txtsort.Text = groupmode.Sort.ToString();
                    if (!string.IsNullOrEmpty(groupmode.Attribute))
                    {
                        WebControlBind.CheckBoxListSetSelected(chkattribute, groupmode.Attribute.ToString());
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string attribute = WebControlBind.CheckBoxListSelected(chkattribute);
            string sqlstr = "";
            if (attribute != "")
            {
                sqlstr += string.Format("update dbo.GroupProduct set attribute='{0}' where gpid={1};", attribute, ECommon.QueryId);
            }
            if (txtsort.Text != "")
            {
                sqlstr += string.Format("update dbo.GroupProduct set sort='{0}' where gpid={1};", int.Parse(txtsort.Text), ECommon.QueryId);
            }
            if (ddlauditstatus.SelectedValue != "")
            {
                sqlstr += string.Format("update dbo.GroupProduct set Status={0} where gpid={1};", ddlauditstatus.SelectedValue, ECommon.QueryId);
            }
            if (sqlstr != "")
            {
                DbHelper.ExecuteNonQuery(sqlstr);
                Response.Write("<script>alert('操作完成');window.location.href='Groupproductlist.aspx';</script>");
                Response.End();
            }
        }
    }
}