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


namespace TREC.Web.Admin.product
{
    public partial class productcategoryinfo : AdminPageBase
    {
        public string areaCode = "";
        public EnCompany _companyInfo = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddllinestatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumAuditStatus), ddllinestatus);
                ddllinestatus.Items.Insert(0, new ListItem("请选择", ""));


                ddlparent.DataSource = ECProductCategory.GetProductCategoryListToDDL("");
                ddlparent.DataTextField="title";
                ddlparent.DataValueField = "id";
                ddlparent.DataBind();
                ddlparent.DataBind();
                ddlparent.Items.Insert(0, new ListItem("根级", "0"));


                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnProductCategory model = ECProductCategory.GetProductCategoryInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txttitle.Text = model.title;
                    this.txtletter.Text = model.letter;
                    this.txtrewritetitle.Text = model.rewritetitle;
                    this.ddlparent.SelectedValue = model.parentid.ToString();
                    this.hfsurface.Value = model.surface;
                    this.hfthumb.Value = model.thumb;
                    this.hfbannel.Value = model.bannel;
                    this.txtdescript.Text = model.descript;
                    this.txtkeywords.Text = model.keywords;
                    this.txttemplate.Text = model.template;
                    this.txthits.Text = model.hits.ToString();
                    this.txtsort.Text = model.sort.ToString();
                    this.txtlastedittime.Text = model.lastedittime.ToString();
                    this.ddllinestatus.SelectedValue = model.linestatus.ToString();
                    string producttypelist = ECPCategoryPTyp.GetProductCategoryTypeValueList(model.id);
                    if (producttypelist.Length > 0)
                    {
                        ECommon.ListBoxBindToProductType(box1View, " and value not in(" + producttypelist + ")");
                        ECommon.ListBoxBindToProductType(box2View, " and value in(" + producttypelist + ")");
                    }
                    ddlparent.Enabled = false;

                }
            }
            else
            {
                ECommon.ListBoxBindToProductType(box1View, "");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnProductCategory model = null;

            string strErr = "";


            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }



            int? lft = 0;
            int? rgt = 0;
            int? lev = 1;
            string depth = "";

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECProductCategory.GetProductCategoryInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
                lft = model.lft;
                rgt = model.rgt;
                lev = model.lev;
                depth = model.depth;
            }

            if (model == null)
            {
                model = new EnProductCategory();
                model.createmid = 0;

            }

            string title = this.txttitle.Text;
            string letter = this.txtletter.Text;
            string rewritetitle = this.txtrewritetitle.Text;
            int parentid = int.Parse(this.ddlparent.SelectedValue);
            string surface = this.hfsurface.Value;
            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value;

            string descript = this.txtdescript.Text;
            string keywords = this.txtkeywords.Text;
            string template = this.txttemplate.Text;
            int hits = int.Parse(this.txthits.Text);
            int sort = int.Parse(this.txtsort.Text);
            int lastedid = adminId;
            DateTime lastedittime = DateTime.Now;
            int linestatus = TypeConverter.StrToInt(ddllinestatus.SelectedValue);

            model.title = title;
            model.letter = letter;
            model.rewritetitle = rewritetitle;
            model.parentid = parentid;
            model.lft = lft;
            model.rgt = rgt;
            model.lev = lev;
            model.depth = depth;
            model.surface = surface;
            model.thumb = thumb;
            model.bannel = bannel;
            model.descript = descript;
            model.keywords = keywords;
            model.template = template;
            model.hits = hits;
            model.sort = sort;
            model.lastedid = lastedid;
            model.lastedittime = lastedittime;
            model.linestatus = linestatus;
           


            int aid = ECProductCategory.EditProductCategory(model);
            if (aid > 0)
            {
                string typelist = Request.Params["box2View"];
                if (typelist != null && typelist.Length > 0)
                {
                    List<EnPCategoryPTyp> list = new List<EnPCategoryPTyp>();
                    foreach (string s in typelist.Split(','))
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            EnPCategoryPTyp m = new EnPCategoryPTyp();
                            m.productcategoryid = aid;
                            m.producttypeid = TypeConverter.StrToInt(s);
                            list.Add(m);
                        }
                    }

                    ECPCategoryPTyp.EditPCategoryPTyp(list);
                }

                ECUpLoad ecUpload = new ECUpLoad();

                if (surface.Length > 0)
                {
                    surface = surface.StartsWith(",") ? surface.Substring(1, surface.Length - 1) : surface;
                    surface = surface.EndsWith(",") ? surface.Substring(0, surface.Length - 1) : surface;
                    ecUpload.MoveFiles(surface.Split(','), string.Format(EnFilePath.ProductCategory, aid, EnFilePath.Surface));
                }
                if (thumb.Length > 0)
                {
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.ProductCategory, aid, EnFilePath.Thumb));
                }
                if (bannel.Length > 0)
                {
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.ProductCategory, aid, EnFilePath.Banner));
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

                    if (strConFilePath.Length > 0) {
                        ECProductCategory.UpConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.ProductCategory, aid, EnFilePath.ConImage)), aid);
                        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.ProductCategory, aid, EnFilePath.ConImage));
                    }
                }


                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}