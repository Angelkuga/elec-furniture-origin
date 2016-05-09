using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.dealer
{
    public partial class menuinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlmodule.DataSource = ECModule.GetModuleList("");
                ddlmodule.DataTextField = "title";
                ddlmodule.DataValueField = "id";
                ddlmodule.DataBind();
                ddlmodule.Items.Insert(0, new ListItem("请选择", ""));

                ddlparent.Items.Add(new ListItem("请选择模块", ""));
                ddlparent.Items.Add(new ListItem("一级菜单", "0"));


                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnMenu model = ECMenu.GetMenuInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txttitle.Text = model.title;
                    this.txtmark.Text = model.mark;
                    this.txtlev.Text = model.lev.ToString();
                    this.txturl.Text = model.url;
                    ddlmodule.SelectedValue = model.module.ToString();
                    this.txtdescript.Text = model.descript;
                    this.txtsort.Text = model.sort.ToString();
                    if (model.module != 0)
                    {
                        ddlparent.DataSource = ECMenu.GetMenuList(" parent=0 and module=" + model.module);
                        ddlparent.DataTextField = "title";
                        ddlparent.DataValueField = "id";
                        ddlparent.DataBind();
                        ddlparent.Items.Insert(0,new ListItem("请选择模块", ""));
                        ddlparent.Items.Insert(1, new ListItem("一级菜单", "0"));
                        ddlparent.SelectedValue = model.parent.ToString();

                    }

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnMenu model = null;

            string strErr = "";
            

            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            string title = this.txttitle.Text;
            string type = "";
            string mark = this.txtmark.Text;
            int parent = TypeConverter.StrToInt(Request.Params["ddlparent"].ToString());
            int lev = int.Parse(this.txtlev.Text);
            string path = "";
            string url = this.txturl.Text;
            int module = TypeConverter.StrToInt(ddlmodule.SelectedValue);
            int action = 0;
            string descript = this.txtdescript.Text;
            int sort = int.Parse(this.txtsort.Text);

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECMenu.GetMenuInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }

            if (model == null)
            {
                model = new EnMenu();
            }

            model.title = title;
            model.type = type;
            model.mark = mark;
            model.parent = parent;
            model.lev = lev;
            model.path = path;
            model.url = url;
            model.module = module;
            model.action = action;
            model.descript = descript;
            model.sort = sort;


            int aid = ECMenu.EditMenu(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}