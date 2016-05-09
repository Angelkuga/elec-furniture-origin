using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.log
{
    public partial class loginfo : AdminPageBase
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
                EnLog model = ECLog.GetLogInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txtmodeule.Text = model.modeule.ToString();
                    this.txtaction.Text = model.action.ToString();
                    this.txtoperateid.Text = model.operateid.ToString();
                    this.txtoperatename.Text = model.operatename;
                    this.txttitle.Text = model.title;
                    this.lblastedittime.Text = model.lastedittime.ToString();
                }
            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            TREC.Entity.EnLog model = null;

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
                model = ECLog.GetLogInfo(" where id=" + ECommon.QueryId);
            }

            if (model == null)
            {
                model = new EnLog();
                model.lastedittime = DateTime.Now;
            }


            int modeule = int.Parse(this.txtmodeule.Text);
            int action = int.Parse(this.txtaction.Text);
            int operateid = int.Parse(this.txtoperateid.Text);
            string operatename = this.txtoperatename.Text;
            string title = this.txttitle.Text;

            model.modeule = modeule;
            model.action = action;
            model.operateid = operateid;
            model.operatename = operatename;
            model.title = title;

            int aid = ECLog.EditLog(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", "loglist.aspx", "Success");
            }


        }
    }
}