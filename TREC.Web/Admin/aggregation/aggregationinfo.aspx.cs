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
    public partial class aggregationinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddltype.DataSource = ECAggregation.GetAggregationTypeListToDDL();
                ddltype.DataTextField = "title";
                ddltype.DataValueField = "id";
                ddltype.DataBind();
                ddltype.Items.Insert(0, new ListItem("请选择", "0"));
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnAggregation model = ECAggregation.GetAggregationInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.ddltype.SelectedValue = model.type.ToString();
                    this.txttitle.Text = model.title;
                    this.txttitle1.Text = model.title1;
                    this.txttitle2.Text = model.title2;
                    this.txttitle3.Text = model.title3;
                    this.hfthumb.Value = model.thumb;
                    this.txtthumbw.Text = model.thumbw.ToString();
                    this.txtthumbh.Text = model.thumbh.ToString();
                    this.hfbannel.Value = model.bannel;
                    this.txturl.Text = model.url;
                    this.txturl1.Text = model.url1;
                    this.txturl2.Text = model.url2;
                    this.txtdescript.Text = model.descript;
                    this.txtsort.Text = model.sort.ToString();
                    this.txthits.Text = model.hits.ToString();

                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnAggregation model = null;


            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECAggregation.GetAggregationInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }
            if (model == null)
            {
                model = new EnAggregation();
                int createmid = adminId;
                model.createmid = createmid;
            }

            int type = TypeConverter.StrToInt(ddltype.SelectedValue);
            string title = this.txttitle.Text;
            string title1 = this.txttitle1.Text;
            string title2 = this.txttitle2.Text;
            string title3 = this.txttitle3.Text;
            string thumb = this.hfthumb.Value;
            int thumbw = int.Parse(this.txtthumbw.Text);
            int thumbh = int.Parse(this.txtthumbh.Text);
            string bannel = this.hfbannel.Value;
            string url = this.txturl.Text;
            string url1 = this.txturl1.Text;
            string url2 = this.txturl2.Text;
            string descript = this.txtdescript.Text;
            int sort = int.Parse(this.txtsort.Text);
            int hits = int.Parse(this.txthits.Text);
            DateTime lastedittime = DateTime.Now;

            model.type = type;
            model.title = title;
            model.title1 = title1;
            model.title2 = title2;
            model.title3 = title3;
            model.thumb = thumb;
            model.thumbw = thumbw;
            model.thumbh = thumbh;
            model.bannel = bannel;
            model.url = url;
            model.url1 = url1;
            model.url2 = url2;
            model.descript = descript;
            model.sort = sort;
            model.hits = hits;
            model.lastedittime = lastedittime;


            int aid = ECAggregation.EditAggregation(model);
            if (aid > 0)
            {

                ECUpLoad ecUpload = new ECUpLoad();

                if (thumb.Length > 0)
                {
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Aggregation, aid, EnFilePath.Thumb));
                }
                if (bannel.Length > 0)
                {
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Aggregation, aid, EnFilePath.Banner));
                }
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}