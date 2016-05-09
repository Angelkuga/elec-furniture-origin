using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.config
{
    public partial class configinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //模块绑定
                ddlmodule.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumConfigModule), ddlmodule);
                ddlmodule.Items.Insert(0, new ListItem("请选择", ""));

                ddltype.Items.Insert(0, new ListItem("请选择", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnConfig model = ECConfig.GetConfigInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txttitle.Text = model.title;
                    this.txtvalue.Text = model.value;
                    ddlmodule.SelectedValue = model.module.ToString();
                    this.txtsort.Text = model.sort.ToString();

                    if (ddlmodule.SelectedValue != "" && ddlmodule.SelectedValue != "0")
                    {

                        ddltype.Items.Clear();
                        ddltype.DataSource = ECConfig.GetConfigTypeList(" type='" + model.module.ToString() + "'");
                        ddltype.DataTextField = "title";
                        ddltype.DataValueField = "id";
                        ddltype.DataBind();
                    }
                    ddltype.SelectedValue = model.type.ToString();
                }
            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            TREC.Entity.EnConfig model = null;

            string strErr = "";
            if (this.txttitle.Text.Trim().Length == 0)
            {
                strErr += "title不能为空！\\n";
            }

            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
                
            }
            if (model == null)
            {
                model = new EnConfig();
            }


            string title = this.txttitle.Text;
            string value = this.txtvalue.Text;
            int type = TypeConverter.StrToInt(HttpContext.Current.Request.Form["ddltype"] == null ? "0" : HttpContext.Current.Request.Form["ddltype"]);
            int module = TypeConverter.StrToInt(ddlmodule.SelectedValue);
            int sort = TypeConverter.StrToInt(this.txtsort.Text);

            model.title = title;
            model.value = value;
            model.type = type;
            model.module = module;
            model.sort = sort;

            int aid = ECConfig.EditConfig(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}