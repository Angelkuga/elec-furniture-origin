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
    public partial class articlecategoryinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ECArticle.BindArticleCategory(ddlcategory);
                chkattribute.Items.Clear();
                WebControlBind.CheckBoxListBind(typeof(EnumAttribute), chkattribute);

                if (ECommon.QueryPid != "")
                {
                    ddlcategory.SelectedValue = ECommon.QueryPid;
                }
                
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnArticleCategory model = ECArticle.GetArticleCategoryInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    WebControlBind.CheckBoxListSetSelected(chkattribute, model.attribute);
                    this.txttitle.Text = model.title;
                    this.txtsubtitle.Text = model.subtitle;
                    this.txtletter.Text = model.letter;
                    this.ddlcategory.SelectedValue = model.parentid.ToString();
                    this.ddlcategory.Enabled = false;
                    this.hfico.Value = model.ico;
                    this.hfthumb.Value = model.thumb;
                    this.hfbanner.Value = model.banner;
                    this.txtkeyword.Text = model.keyword;
                    this.txtdescript.Text = model.descript;
                    this.txtcontext.Text = model.context;
                    this.txtlinkurl.Text = model.linkurl;
                    this.ddllinktype.SelectedValue = model.linktype.ToString();
                    this.txtindextemplate.Text = model.indextemplate;
                    this.txtlisttemplate.Text = model.listtemplate;
                    this.txtcontemplate.Text = model.contemplate;
                    this.txtsort.Text = model.sort.ToString();

                }
            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnArticleCategory model = null;

            string strErr = "";
            if (this.txttitle.Text.Trim().Length == 0)
            {
                strErr += "分类名称不能为空！\\n";
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
            int parentid = int.Parse(ddlcategory.SelectedValue);
            string ico = this.hfico.Value;
            string thumb = this.hfthumb.Value != null ? this.hfthumb.Value.EndsWith(",") ? this.hfthumb.Value.Substring(0, this.hfthumb.Value.Length - 1) : this.hfthumb.Value : "";
            string banner = this.hfbanner.Value;
            string keyword = this.txtkeyword.Text;
            string descript = this.txtdescript.Text;
            string context = this.txtcontext.Text;
            string linkurl = this.txtlinkurl.Text;
            int sort = int.Parse(this.txtsort.Text);
            int linktype = int.Parse(this.ddllinktype.SelectedValue);
            string indextemplate = this.txtindextemplate.Text;
            string listtemplate = this.txtlisttemplate.Text;
            string contemplate = this.txtcontemplate.Text;



            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECArticle.GetArticleCategoryInfo(" where id=" + ECommon.QueryId);
            }

            if (model == null)
            {
                model = new EnArticleCategory();
                model.othercon = "";
                model.createtime = DateTime.Now;
                model.createid = adminId;
                model.lft = 0;
                model.rgt = 0;
                model.depth = "";
                model.lev = 0;
            }

            model.attribute = attribute;
            model.title = title;
            model.subtitle = subtitle;
            model.letter = letter;
            model.parentid = parentid;
            model.ico = ico;
            model.thumb = thumb;
            model.banner = banner;
            model.keyword = keyword;
            model.descript = descript;
            model.context = context;
            model.linkurl = linkurl;
            model.sort = sort;
            model.edittime = DateTime.Now;
            model.editid = adminId;
            model.linktype = linktype;
            model.parentid = parentid;
            model.indextemplate = indextemplate;
            model.listtemplate = listtemplate;
            model.contemplate = contemplate;
            model.sort = sort;



            int aid = ECArticle.EditArticleCategory(model);
            if (aid > 0)
            {
                ECUpLoad upload = new ECUpLoad();

                if (thumb.Length > 0)
                {
                    upload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.ArticleCategory, EnFilePath.Thumb, aid));
                }
                if (banner.Length > 0)
                {
                    upload.MoveFiles(banner.Split(','), string.Format(EnFilePath.ArticleCategory, aid, EnFilePath.Banner, aid));
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
                        ECArticle.UpCategoryConFilePath(ECommon.RepFilePathContent(model.context, EnFilePath.tmpRootPath, string.Format(EnFilePath.ArticleCategory, aid, EnFilePath.ConImage)), aid);
                        
                        upload.MoveContentFiles(strConFilePath.Replace(EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.ArticleCategory, aid, EnFilePath.ConImage));
                    }
                }

                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}