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
    public partial class roleinfo : AdminPageBase
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
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnRole model = ECRole.GetRoleInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txttitle.Text = model.title;
                    this.txtmark.Text = model.mark;
                    this.txtdescript.Text = model.descript;
                    this.txtsort.Text = model.sort.ToString();
                }

            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            TREC.Entity.EnRole model = new TREC.Entity.EnRole();

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
                    model = new EnRole();
                }
            }


            string title = this.txttitle.Text;
            string mark = this.txtmark.Text;
            string descript = this.txtdescript.Text;
            int sort = int.Parse(this.txtsort.Text);

            model.title = title;
            model.mark = mark;
            model.descript = descript;
            model.sort = sort;

            int aid = ECRole.EditRole(model); 
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}