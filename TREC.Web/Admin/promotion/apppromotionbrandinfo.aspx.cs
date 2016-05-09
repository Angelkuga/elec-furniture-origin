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
    public partial class apppromotionbrandinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ddlvalue.Items.Insert(0, new ListItem("请查找", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnPromotionAppBrand model = ECAppPromotion.GetPromotionAppBrandInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.hfthumb.Value = model.thumb;
                    this.hfbannel.Value = model.banner;
                    txthtmltitle.Text = model.htmltitle;
                    txtdescript.Text = model.descript;
                    ddlvalue.Items.Clear();
                    ddlvalue.Items.Insert(0, new ListItem(model.title + "/" + model.letter + "_" + model.fordio, model.bid.ToString()));
                    this.txtsort.Text = model.sort.ToString();
                    this.txtappcount.Text = model.appcount.ToString();

                    this.txtdiscount.Text = model.Discount.ToString();
                    this.txtperiod.Text = model.Period.ToString();
                    this.ckIsRecommend.Checked = model.IsRecommend;
                    this.txtBrandABC.Text = model.BrandABC;
                    this.txtpercount.Text = model.Percount.ToString();
                    this.txttemplate.Text = model.Template;
                    this.txtrulesInfo.Text = model.RulesInfo;

                    this.txtstarttime.Text = model.Starttime.ToString();
                    this.txtendtime.Text = model.Endtime.ToString();
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EnPromotionAppBrand model = null;

            int pid = 0;
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECAppPromotion.GetPromotionAppBrandInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }
            if (model == null)
            {
                model = new EnPromotionAppBrand();
                model.fordio = "1";
            }
            pid = TypeConverter.StrToInt(ECommon.QueryPId);



            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value;
            string value = ddlvalue.SelectedValue;
            string descript = txtdescript.Text;
            string htmltitle = txthtmltitle.Text;
            int sort = int.Parse(this.txtsort.Text);

            int discount = int.Parse(this.txtdiscount.Text);
            int Period = int.Parse(this.txtperiod.Text);
            bool IsRecommend = ckIsRecommend.Checked;
            string BrandABC = txtBrandABC.Text;
            int percount = int.Parse(txtpercount.Text);
            string template = txttemplate.Text;
            string rulesInfo = txtrulesInfo.Text;
            DateTime starttime = DateTime.Parse(txtstarttime.Text);
            DateTime endtime =DateTime.Parse(txtendtime.Text);
            if (endtime <= starttime)
            {
                UiCommon.JscriptPrint(this.Page, "抱歉。结束时间必须大于开始时间!", Request.Url.AbsoluteUri, "Success");
            }
            model.bid = int.Parse(value);
            model.title = ddlvalue.SelectedItem.Text.Substring(0, ddlvalue.SelectedItem.Text.IndexOf("/"));
            model.letter = ddlvalue.SelectedItem.Text.Substring(ddlvalue.SelectedItem.Text.IndexOf("/") + 1, ddlvalue.SelectedItem.Text.IndexOf("_") - ddlvalue.SelectedItem.Text.IndexOf("/") - 1);
            model.sort = sort;
            model.htmltitle = htmltitle;
            model.descript = descript;
            model.thumb = thumb;
            model.banner = bannel;
            model.appcount = int.Parse(txtappcount.Text);
            model.fordio = ddlvalue.SelectedItem.Text.Substring(ddlvalue.SelectedItem.Text.IndexOf("_") + 1, ddlvalue.SelectedItem.Text.Length - ddlvalue.SelectedItem.Text.IndexOf("_") - 1);

            model.Discount = discount;
            model.Period = Period;
            model.IsRecommend = IsRecommend;
            model.Style = 0;
            model.Percount = percount;
            model.BrandABC = BrandABC;
            model.Template = template;
            model.RulesInfo = rulesInfo;
            model.Starttime = starttime;
            model.Endtime = endtime;

            if (model.bid > 0 && model.fordio != "1")
            {
                EnBrand brandmodel = ECBrand.GetBrandInfo(" where id=" + model.bid);

                if (brandmodel != null)
                {
                    if (!string.IsNullOrEmpty(brandmodel.style.Trim()))
                    {
                        model.Style = int.Parse(brandmodel.style);
                        List<EnSearchItem> _ensear = ECCompany.GetSearchItem().Where(x => x.type == "style" && x.value == model.Style.ToString()).ToList();
                        if (_ensear != null && _ensear.Count > 0)
                        {
                            model.Stylevalue = _ensear[0].title;
                        }
                    }
                }
            }

            int aid = ECAppPromotion.EditPromotionAppBrand(model);
            if (aid > 0)
            {

                ECUpLoad ecUpload = new ECUpLoad();

                if (thumb.Length > 0)
                {
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.AppPromotionBrand, aid, EnFilePath.Thumb));
                }
                if (bannel.Length > 0)
                {
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.AppPromotionBrand, aid, EnFilePath.Banner));
                }



                StringBuilder imglist = Utils.GetImgUrl(model.descript);

                if (Utils.GetImgUrl(model.descript).Length > 0)
                {
                    string strConFilePath = "";
                    foreach (string s in imglist.ToString().Split(','))
                    {
                        if (s.Contains(TREC.Entity.EnFilePath.tmpRootPath))
                        {
                            strConFilePath += s + ",";
                        }
                    }

                    if (strConFilePath.Length > 0)
                    {
                        ECAppPromotion.UpConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.AppPromotionBrand, aid, EnFilePath.ConImage)), aid);
                        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.AppPromotionBrand, aid, EnFilePath.ConImage));
                    }
                }



                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text != "")
            {
                ddlvalue.DataSource = ECBrand.GetWebAllBrandList(-1, 0, " title like '%" + txtsearch.Text + "%'", out tmpPageCount);
                ddlvalue.DataTextField = "title";
                ddlvalue.DataValueField = "brandid";
                ddlvalue.DataBind();

            }
            else
            {

                ddlvalue.Items.Insert(0, new ListItem("请输入查找", ""));
            }

        }
    }
}