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
    public partial class promotioninfo : AdminPageBase
    {
        public string areaCode = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddlauditstatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumAuditStatus), ddlauditstatus);
                ddlauditstatus.Items.Insert(0, new ListItem("请选择", ""));

                ddltype.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumPromotionType), ddltype);
                ddltype.Items.Insert(0, new ListItem("请选择", ""));
                
                ddllinestatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumAuditStatus), ddllinestatus);
                ddllinestatus.Items.Insert(0, new ListItem("请选择", ""));

                chkattribute.Items.Clear();
                WebControlBind.CheckBoxListBind(typeof(EnumAttribute), chkattribute);

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnPromotion model = ECPromotion.GetPromotionInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    areaCode = model.areacode;
                    this.txttitle.Text = model.title;
                    this.txthtmltitle.Text = model.htmltitle;
                    this.txtletter.Text = model.letter;
                    WebControlBind.CheckBoxListSetSelected(chkattribute, model.attribute);
                    this.ddltype.SelectedValue = model.ptype.ToString();
                    this.hfsurface.Value = model.surface;
                    this.hflogo.Value = model.logo;
                    this.hfthumb.Value = model.thumb;
                    this.hfbannel.Value = model.bannel;
                    this.hfdesimage.Value = model.desimage;
                    this.txtdescript.Text = model.descript;
                    this.txtkeywords.Text = model.keywords;
                    this.txttemplate.Text = model.template;
                    this.txthits.Text = model.hits.ToString();
                    this.txtsort.Text = model.sort.ToString();
                    this.ddlauditstatus.SelectedValue = model.auditstatus.ToString();
                    this.ddllinestatus.SelectedValue = model.linestatus.ToString();
                    this.txtstartdatetime.Text = model.startdatetime.ToString();
                    this.txtenddatetime.Text = model.enddatetime.ToString();
                    this.txtaddress.Text = model.address;

                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnPromotion model = null;


            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECPromotion.GetPromotionInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }
            if (model == null)
            {
                model = new EnPromotion();
                int createmid = adminId;
                model.createmid = createmid;
            }
            string title = this.txttitle.Text;
            string htmltitle = this.txthtmltitle.Text;
            string letter = this.txtletter.Text;
            string attribute = WebControlBind.CheckBoxListSelected(chkattribute);
            int ptype = int.Parse(ddltype.SelectedValue);
            string surface = this.hfsurface.Value;
            string logo = this.hflogo.Value;
            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value;
            string desimage = this.hfdesimage.Value;
            string descript = this.txtdescript.Text;
            string keywords = this.txtkeywords.Text;
            string template = this.txttemplate.Text;
            int hits = int.Parse(this.txthits.Text);
            int sort = int.Parse(this.txtsort.Text);
            DateTime lastedittime = DateTime.Now;
            int auditstatus = int.Parse(ddlauditstatus.SelectedValue);
            int linestatus = int.Parse(ddllinestatus.SelectedValue);
            DateTime startdatetime = DateTime.Parse(txtstartdatetime.Text);
            DateTime enddatetime = DateTime.Parse(txtenddatetime.Text);
            string address = txtaddress.Text;

            model.title = title;
            model.htmltitle = htmltitle;
            model.letter = letter;
            model.attribute = attribute;
            model.ptype = ptype;
            model.surface = surface;
            model.logo = logo;
            model.thumb = thumb;
            model.bannel = bannel;
            model.desimage = desimage;
            model.descript = descript;
            model.keywords = keywords;
            model.template = template;
            model.hits = hits;
            model.sort = sort;
            model.lastedittime = lastedittime;
            model.auditstatus = auditstatus;
            model.linestatus = linestatus;
            model.startdatetime = startdatetime;
            model.enddatetime = enddatetime;
            model.address = address;
            


            int aid = ECPromotion.EditPromotion(model);
            if (aid > 0)
            {

                ECUpLoad ecUpload = new ECUpLoad();


                if (surface.Length > 0)
                {
                    surface = surface.StartsWith(",") ? surface.Substring(1, surface.Length - 1) : surface;
                    surface = surface.EndsWith(",") ? surface.Substring(0, surface.Length - 1) : surface;
                    ecUpload.MoveFiles(surface.Split(','), string.Format(EnFilePath.Company, aid, EnFilePath.Surface));
                }
                if (thumb.Length > 0)
                {
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Promotion, aid, EnFilePath.Thumb));
                }
                if (logo.Length > 0)
                {
                    ecUpload.MoveFiles(logo.Split(','), string.Format(EnFilePath.Promotion, aid, EnFilePath.Logo));
                }
                if (bannel.Length > 0)
                {
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Promotion, aid, EnFilePath.Banner));
                }
                if (desimage.Length > 0)
                {
                    ecUpload.MoveFiles(desimage.Split(','), string.Format(EnFilePath.Promotion, aid, EnFilePath.DesImage));
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
                        ECPromotion.UpConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Promotion, aid, EnFilePath.ConImage)), aid);
                        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Promotion, aid, EnFilePath.ConImage));
                    }
                }

                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}