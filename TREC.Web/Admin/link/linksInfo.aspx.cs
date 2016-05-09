using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Admin.link
{
    public partial class linksInfo : AdminPageBase
    {
        protected string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];

            if (!IsPostBack)
            {
                ddllinestatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumLineStatus), ddllinestatus);
                ddllinestatus.Items.Insert(0, new ListItem("请选择", ""));

                ShowData();
            }

        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnLinks model = ECLinks.GetMLinksInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    tbTitle.Text = model.Title;
                    tblink.Text = model.Link;
                    ddllinestatus.SelectedValue = model.Linestatus.ToString();
                }
                else
                {
                    UiCommon.JscriptPrint(this.Page, "抱歉。该友情连接不存在!", Request.Url.AbsoluteUri, "Success");
                    return;
                }
            }
        }


        /// <summary>
        /// Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EnLinks model = new EnLinks();
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model.Id = Convert.ToInt32(ECommon.QueryId);
            }
            model.Title = tbTitle.Text;
            model.Link = tblink.Text;
            model.Linestatus = Convert.ToInt32(ddllinestatus.SelectedValue);

            int aid = ECLinks.EditLinks(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "恭喜。新增友情连接成功!", Request.Url.AbsoluteUri, "Success");
                return;
            }
            else
            {
                UiCommon.JscriptPrint(this.Page, "抱歉。新增友情连接失败!", Request.Url.AbsoluteUri, "Success");
                return;
            }
        }
    }
}