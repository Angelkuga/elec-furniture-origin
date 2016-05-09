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

namespace TREC.Web.Admin.product
{
    public partial class productattributeedit : System.Web.UI.Page
    {
        public EnProductAttribute model = new EnProductAttribute();

        protected void Page_Load(object sender, EventArgs e)
        {
            model = ECProductAttribute.GetProductAttributeInfo(" where id=" + Request.QueryString["id"]);
            hfcimg.Value=model.productcolorimg;
            if(model.typevalue=="0")
            {
                
            }
            else
            {
                ddltype.Items.Clear();
                ddltype.DataSource = ECConfig.GetConfigList(" type=" + (int)EnumConfigByProduct.产品类型 + " and value in(" + ECPCategoryPTyp.GetProductCategoryTypeValueList(TypeConverter.StrToInt(Request.QueryString["c"])) + ")");
                ddltype.DataTextField = "title";
                ddltype.DataValueField = "value";
                ddltype.DataBind();
                ddltype.Items.Insert(0, new ListItem("请选择", ""));

                ddltype.SelectedValue=model.typevalue;
            }
            
            
        }
    }
}