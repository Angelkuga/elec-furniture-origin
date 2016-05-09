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


namespace TREC.Web.Admin.article
{
    public partial class articleinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ECArticle.BindArticleCategory(ddlcategory);
                chkattribute.Items.Clear();
                WebControlBind.CheckBoxListBind(typeof(EnumAttribute), chkattribute);
               
                
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnArticle model = ECArticle.GetArticleInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    WebControlBind.CheckBoxListSetSelected(chkattribute, model.attribute);
                    this.txttitle.Text = model.title;
                    this.txtsubtitle.Text = model.subtitle;
                    this.txtletter.Text = model.letter;
                    this.ddlcategory.SelectedValue = model.categoryid.ToString();
                    this.txtsubcategoryid.Text = model.subcategoryid;
                    this.hfico.Value = model.ico;
                    this.hfthumb.Value = model.thumb;
                    this.hfbanner.Value = model.banner;
                    this.txtkeyword.Text = model.keyword;
                    this.txtdescript.Text = model.descript;
                    this.txtcontext.Text = model.context;
                    this.txtsource.Text = model.source;
                    this.txtautho.Text = model.autho;
                    this.txtlinkurl.Text = model.linkurl;
                    this.txtclickcount.Text = model.clickcount.ToString();
                    this.txtsort.Text = model.sort.ToString();
                }
            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnArticle model = null;

            string strErr = "";
            if (this.txttitle.Text.Trim().Length == 0)
            {
                strErr += "title不能为空！\\n";
            }
            

            if (strErr != "")
            {
                ScriptUtils.ShowMessage(this.Page, "msg", strErr);
                return;
            }
            string attribute = WebControlBind.CheckBoxListSelected(chkattribute);
            string title = this.txttitle.Text;
            string subtitle = this.txtsubtitle.Text;
            string letter = this.txtletter.Text;
            int categoryid = int.Parse(ddlcategory.SelectedValue);
            string subcategoryid = this.txtsubcategoryid.Text;
            string ico = this.hfico.Value;
            string thumb = this.hfthumb.Value != null ? this.hfthumb.Value.EndsWith(",") ? this.hfthumb.Value.Substring(0, this.hfthumb.Value.Length - 1) : this.hfthumb.Value : "";
            string banner = this.hfbanner.Value;
            string keyword = this.txtkeyword.Text;
            string descript = this.txtdescript.Text;
            string context = this.txtcontext.Text;
            string source = this.txtsource.Text;
            string autho = this.txtautho.Text;
            string linkurl = this.txtlinkurl.Text;
            int clickcount = int.Parse(this.txtclickcount.Text);
            int sort = int.Parse(this.txtsort.Text);

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECArticle.GetArticleInfo(" where id=" + ECommon.QueryId);
            }

            if (model == null)
            {
                model = new EnArticle();
                model.othercon = "";
                model.createtime = DateTime.Now;
                model.createid = adminId;
            }

            model.attribute = attribute;
            model.title = title;
            model.subtitle = subtitle;
            model.letter = letter;
            model.categoryid = categoryid;
            model.subcategoryid = subcategoryid;
            model.ico = ico;
            model.thumb = thumb;
            model.banner = banner;
            model.keyword = keyword;
            model.descript = descript;
            model.context = context;
            model.source = source;
            model.autho = autho;
            model.linkurl = linkurl;
            model.clickcount = clickcount;
            model.sort = sort;
            model.edittime = DateTime.Now;
            model.editid = adminId;


            int aid = ECArticle.EditArticle(model);
            if (aid > 0)
            {
                ECUpLoad upload = new ECUpLoad();

                if (thumb.Length > 0)
                {
                    upload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Article, EnFilePath.Thumb, aid));
                }
                if (banner.Length > 0)
                {
                    upload.MoveFiles(banner.Split(','), string.Format(EnFilePath.Article, aid, EnFilePath.Banner, aid));
                }

                StringBuilder imglist = Utils.GetImgUrl(txtcontext.Text);

                if (imglist.ToString().Length > 0)
                {
                    string strConFilePath = "";
                    foreach (string s in imglist.ToString().Split(','))
                    {
                        if (s.Contains(EnFilePath.tmpRootPath))
                        {
                            strConFilePath += s + ",";
                        }
                    }

                    if (strConFilePath.Length > 0)
                    {
                        ECArticle.UpConFilePath(ECommon.RepFilePathContent(model.context, EnFilePath.Article, string.Format(EnFilePath.Article, aid, EnFilePath.ConImage)), aid);
                        
                        upload.MoveContentFiles(strConFilePath.Replace(EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Article, aid, EnFilePath.ConImage));
                    }
                }

                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}