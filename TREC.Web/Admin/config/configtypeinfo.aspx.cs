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
    public partial class configtypeinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //模块绑定
                ddltype.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumConfigModule), ddltype);
                ddltype.Items.Insert(0, new ListItem("请选择", ""));
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnConfigType model = ECConfig.GetConfigTypeInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txttitle.Text = model.title;
                    this.txtmark.Text = model.mark;
                    this.txtletter.Text = model.letter;
                    ddltype.SelectedValue = model.type.ToString();
                    this.txtsort.Text = model.sort.ToString();
                    this.txtcount.Text = model.count.ToString();
                    this.txtdescript.Text = model.descript;
                    this.txtmark.Enabled = false;
                }
            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {



            TREC.Entity.EnConfigType model = null;

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
                model = ECConfig.GetConfigTypeInfo(" where id=" + ECommon.QueryId);
                
            }
            if (model == null)
            {
                model = new EnConfigType();
            }


            string title = this.txttitle.Text;
            string mark = this.txtmark.Text;
            string letter = this.txtletter.Text;
            string type = ddltype.SelectedValue;
            int sort = int.Parse(this.txtsort.Text);
            int count = int.Parse(this.txtcount.Text);
            string descript = this.txtdescript.Text;

            model.title = title;
            model.mark = mark;
            model.letter = letter;
            model.type = type;
            model.sort = sort;
            model.count = count;
            model.descript = descript;

            int aid = ECConfig.EditConfigType(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}