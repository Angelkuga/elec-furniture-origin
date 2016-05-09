using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Admin.promotion
{
    public partial class promotionstage : AdminPageBase
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                WebControlBind.DrpBind(typeof(EnumPromotionStageType), ddlstype);
                ddlstype.Items.Insert(0, new ListItem("请选择", ""));

                WebControlBind.DrpBind(typeof(EnumPromotionStageModule), ddlsmodule);
                ddlsmodule.Items.Insert(0, new ListItem("请选择", ""));

                WebControlBind.DrpBind(typeof(EnumPromotionModule), ddlpmodule);
                ddlpmodule.Items.Insert(0, new ListItem("请选择", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {

            if (ECommon.QueryPId == "" || ECommon.QueryDId=="")
            {
                UiCommon.JscriptPrint(this.Page, "参数不正确，请刷新数据得新查看!", Request.Url.AbsoluteUri, "Success");
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnPromotionStage model = ECPromotionStage.GetPromotionStageInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txttitle.Text = model.title;
                    this.ddlstype.SelectedValue = model.stype.ToString();
                    this.ddlsmodule.SelectedValue = model.smodle.ToString();
                    this.txtsvaluemin.Text = model.svaluemin;
                    this.txtsvaluemax.Text = model.svaluemax;
                    this.ddlpmodule.SelectedValue = model.pmodule.ToString();
                    this.txtrule.Text = model.prolue;
                    this.txtpvalue.Text = model.pvalue;
                    this.txtsort.Text = model.sort.ToString();



                }
            }

            rptlist.DataSource = ECPromotionStage.GetPromotionStageList(" pid=" + ECommon.QueryPId + " and did=" + ECommon.QueryDId);
            rptlist.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {



            EnPromotionStage model = null;

            int pid = 0, did = 0;
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECPromotionStage.GetPromotionStageInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }
            if (model == null)
            {


                model = new EnPromotionStage();
            }
            pid = TypeConverter.StrToInt(ECommon.QueryPId);
            did = TypeConverter.StrToInt(ECommon.QueryDId);



            string title = this.txttitle.Text;
            int stype = int.Parse(ddlstype.SelectedValue);
            int smodle = int.Parse(ddlsmodule.SelectedValue);
            string svaluemin = this.txtsvaluemin.Text;
            string svaluemax = this.txtsvaluemax.Text;
            int pmodule = int.Parse(ddlpmodule.SelectedValue);
            string prolue = txtrule.Text;
            string pvalue = this.txtpvalue.Text;
            int sort = int.Parse(this.txtsort.Text);

            model.title = title;
            model.pid = pid;
            model.did = did;
            model.stype = stype;
            model.smodle = smodle;
            model.svaluemin = svaluemin;
            model.svaluemax = svaluemax;
            model.pmodule = pmodule;
            model.prolue = prolue;
            model.pvalue = pvalue;
            model.sort = sort;


            int aid = ECPromotionStage.EditPromotionStage(model);
            if (aid > 0)
            {
                //UiCommon.JscriptPrint(this.Page, "编辑成功!", "promotionstage.aspx?pid=" + ECommon.QueryPId + "&did=" + ECommon.QueryDId, "Success");
                ScriptUtils.ShowAndRedirect("编辑成功!", "promotionstage.aspx?pid=" + ECommon.QueryPId + "&did=" + ECommon.QueryDId);
            }


        }
    }
}