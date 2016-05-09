using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.area
{
    public partial class areainfo : AdminPageBase
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
                EnArea model = ECArea.GetAreaInfo("  where areacode=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txtareacode.Text = model.areacode;
                    this.txtparentcode.Text = model.parentcode;
                    this.txtareaname.Text = model.areaname;
                    this.txtareazipcode.Text = model.areazipcode;
                    this.txtgrouparea.Text = model.grouparea;
                }

            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            TREC.Entity.EnArea model = new TREC.Entity.EnArea();

            string strErr = "";
            if (this.txtareacode.Text.Trim().Length == 0)
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
                model = ECArea.GetAreaInfo("  where areacode=" + ECommon.QueryId);

            }
            else
            {
                model = new EnArea();
            }


            string areacode = this.txtareacode.Text;
            string parentcode = this.txtparentcode.Text;
            string areaname = this.txtareaname.Text;
            string areazipcode = this.txtareazipcode.Text;
            string grouparea = this.txtgrouparea.Text;

            model.areacode = areacode;
            model.parentcode = parentcode;
            model.areaname = areaname;
            model.areazipcode = areazipcode;
            model.grouparea = grouparea;

            int aid = ECArea.EditArea(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}