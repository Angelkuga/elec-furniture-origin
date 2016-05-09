using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.permission
{
    public partial class actioninfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
            ddlMoudle.DataSource = ECModule.GetModuleList("");
            ddlMoudle.DataTextField = "title";
            ddlMoudle.DataValueField = "id";
            ddlMoudle.DataBind();
            ddlMoudle.Items.Insert(0, new ListItem("请选择", "0"));

            WebControlBind.RadioBind(typeof(EnumActionType), raActionType);
            raActionType.Items.Insert(0, new ListItem("所有", "0"));
            raActionType.Items[0].Selected = true;

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnAction model = ECAction.GetActionInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {

                    this.txttitle.Text = model.title;
                    this.txtmark.Text = model.mark;
                    this.txtdescript.Text = model.descript;
                    this.txtsort.Text = model.sort.ToString();
                    this.ddlMoudle.SelectedValue = model.mid.ToString();
                    this.raActionType.SelectedValue = model.actype.ToString();
                }
            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            TREC.Entity.EnAction model = new TREC.Entity.EnAction();

            string strErr = "";
            if (this.txttitle.Text.Trim().Length == 0)
            {
                strErr += "title不能为空！\\n";
            }
            if (this.txtmark.Text.Trim().Length == 0)
            {
                strErr += "mark不能为空！\\n";
            }

            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
                if (model == null)
                {
                    model =new EnAction();
                }
            }


            string title = this.txttitle.Text;
            string mark = this.txtmark.Text;
            int mid = TypeConverter.StrToInt(ddlMoudle.SelectedValue);
            int actype = TypeConverter.StrToInt(raActionType.SelectedValue);
            string descript = this.txtdescript.Text;
            int sort = int.Parse(this.txtsort.Text);

            model.title = title;
            model.mark = mark;
            model.mid = mid;
            model.actype = actype;
            model.descript = descript;
            model.sort = sort;

            int aid = ECAction.EditAction(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}