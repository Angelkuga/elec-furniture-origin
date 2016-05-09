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
    public partial class promotiondefinfo : AdminPageBase
    {

        public EnPromotion modelPInfo = new EnPromotion();

        protected void Page_Load(object sender, EventArgs e)
        {

            modelPInfo = ECPromotion.GetPromotionInfo("  where id=" + ECommon.QueryPId);

            if (!IsPostBack)
            {


                ddltype.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumPromotionDefType), ddltype);
                ddltype.Items.Insert(0, new ListItem("请选择", ""));

                chkattribute.Items.Clear();
                WebControlBind.CheckBoxListBind(typeof(EnumAttribute), chkattribute);

                ddlvalue.Items.Insert(0, new ListItem("请查找", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {

            if (ECommon.QueryPId == "")
            {
                UiCommon.JscriptPrint(this.Page, "参数不正确，请刷新数据得新查看!", Request.Url.AbsoluteUri, "Success");
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnPromotionDef model = ECPromotionDef.GetPromotionDefInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    WebControlBind.CheckBoxListSetSelected(chkattribute, model.attribute);
                    ddltype.SelectedValue = model.type;
                    ddlvalue.Items.Clear();
                    ddlvalue.Items.Insert(0, new ListItem(model.valuetitle + "/" + model.valueletter + "_" + model.fordio, model.value));

                    this.hfthumb.Value = model.thumb;
                    this.hfbannel.Value = model.banner;
                    this.txtdescript.Text = model.descript;
                    this.txtsort.Text = model.sort.ToString();
                    this.txttitle.Text = model.title;
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           


            EnPromotionDef model = null;

            int pid=0;
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECPromotionDef.GetPromotionDefInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }
            if (model == null)
            {


                model = new EnPromotionDef();
                model.curcountmoney = "0";
                model.curcountpeople = "0";
                model.curstage = "0";
                model.fordio = "1";
            }
            pid = TypeConverter.StrToInt(ECommon.QueryPId);


            string attribute = WebControlBind.CheckBoxListSelected(chkattribute);
            string type = ddltype.SelectedValue;
            string value = ddlvalue.SelectedValue;
            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value;
            string descript = this.txtdescript.Text;
            int sort = int.Parse(this.txtsort.Text);

            model.title = txttitle.Text;
            model.pid = pid;
            model.attribute = attribute;
            model.type = type;
            model.value = value;
            model.valuetitle = ddlvalue.SelectedItem.Text.Substring(0, ddlvalue.SelectedItem.Text.IndexOf("/"));
            model.valueletter = ddlvalue.SelectedItem.Text.Substring(ddlvalue.SelectedItem.Text.IndexOf("/") + 1, ddlvalue.SelectedItem.Text.IndexOf("_") - ddlvalue.SelectedItem.Text.IndexOf("/") - 1);
            model.thumb = thumb;
            model.banner = bannel;
            model.descript = descript;
            model.sort = sort;
            model.fordio = ddlvalue.SelectedItem.Text.Substring(ddlvalue.SelectedItem.Text.IndexOf("_") + 1, ddlvalue.SelectedItem.Text.Length - ddlvalue.SelectedItem.Text.IndexOf("_") - 1);



            if (ECPromotionDef.ExistsDef(model) > 0 & ECommon.QueryId == "" && ECommon.QueryEdit == "")
            {
                UiCommon.JscriptPrint(this.Page, "信息己存在，请重新设置!", Request.Url.AbsoluteUri, "Error");
                return;
            }


            int aid = ECPromotionDef.EditPromotionDef(model);
            if (aid > 0)
            {

                ECUpLoad ecUpload = new ECUpLoad();

                if (thumb.Length > 0)
                {
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.PromotionDef, aid, EnFilePath.Thumb));
                }
                if (bannel.Length > 0)
                {
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.PromotionDef, aid, EnFilePath.Banner));
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
                        ECPromotionDef.UpConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.PromotionDef, aid, EnFilePath.ConImage)), aid);
                        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.PromotionDef, aid, EnFilePath.ConImage));
                    }
                }

                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text != "")
            {
                 switch (TypeConverter.StrToInt(ddltype.SelectedValue))
                {
                     case (int)EnumPromotionDefType.品牌:
                         ddlvalue.DataSource = ECBrand.GetWebAllBrandList(-1, 0, " title like '%" + txtsearch.Text + "%'", out tmpPageCount);
                         ddlvalue.DataTextField = "title";
                         ddlvalue.DataValueField = "brandid";
                         ddlvalue.DataBind();
                        break;
                 }
                
            }
            else
            {

                ddlvalue.Items.Insert(0, new ListItem("请输入查找", ""));
            }
            
        }
    }
}