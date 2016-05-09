using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.aggregation
{
    public partial class aggregationtypeinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlparent.DataSource = ECAggregation.GetAggregationTypeList(" parentid=0");
                ddlparent.DataTextField = "title";
                ddlparent.DataValueField = "id";
                ddlparent.DataBind();
                ddlparent.Items.Insert(0, new ListItem("根模块", "0"));
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnAggregationType model = ECAggregation.GetAggregationTypeInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.ddlparent.SelectedValue = model.parentid.ToString();
                    this.txttitle.Text = model.title;
                    this.txttitle1.Text = model.title1;
                    this.txtthumb.Text = model.thumb;
                    this.txturl.Text = model.url;
                    this.txtsort.Text = model.sort.ToString();
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnAggregationType model = null;

            string strErr = "";
            

            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECAggregation.GetAggregationTypeInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }

            if (model == null)
            {
                model = new EnAggregationType();
            }


            int parentid = int.Parse(this.ddlparent.SelectedValue);
            string title = this.txttitle.Text;
            string title1 = this.txttitle1.Text;
            string thumb = this.txtthumb.Text;
            string url = this.txturl.Text;
            int sort = int.Parse(this.txtsort.Text);

            model.parentid = parentid;
            model.title = title;
            model.title1 = title1;
            model.thumb = thumb;
            model.url = url;
            model.sort = sort;





            

            int aid = ECAggregation.EditAggregationType(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}