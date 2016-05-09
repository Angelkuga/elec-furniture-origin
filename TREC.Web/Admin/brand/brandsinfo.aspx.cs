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


namespace TREC.Web.Admin.brand
{
    public partial class brandsinfo : AdminPageBase
    {
        public string areaCode = "";
        public EnBrand _brandInfo = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlbrand.Items.Clear();
                ddlbrand.DataSource = ECBrand.GetBrandList("").OrderBy(c => c.title);
                ddlbrand.DataTextField = "title";
                ddlbrand.DataValueField = "id";
                ddlbrand.DataBind();
                ddlbrand.Items.Insert(0, new ListItem("请选择", ""));

                //ddlauditstatus.Items.Clear();
                //WebControlBind.DrpBind(typeof(EnumAuditStatus), ddlauditstatus);
                //ddlauditstatus.Items.Insert(0, new ListItem("请选择", ""));



                //ddllinestatus.Items.Clear();
                //WebControlBind.DrpBind(typeof(EnumAuditStatus), ddllinestatus);
                //ddllinestatus.Items.Insert(0, new ListItem("请选择", ""));
                //Add :rafer
                //date:2012-4-24
                //Remarks:系列新增（材质，风格，色系）三项，初始化三项
                //风格
                ddlstyle.Items.Clear();
                ddlstyle.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品风格);
                ddlstyle.DataTextField = "title";
                ddlstyle.DataValueField = "value";
                ddlstyle.DataBind();
                ddlstyle.Items.Insert(0, new ListItem("选择风格", ""));
                //选材
                ddlmaterial.Items.Clear();
                ddlmaterial.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品选材);
                ddlmaterial.DataTextField = "title";
                ddlmaterial.DataValueField = "value";
                ddlmaterial.DataBind();
                ddlmaterial.Items.Insert(0, new ListItem("选择选材", ""));
                //色系
                ddlcolor.Items.Clear();
                ddlcolor.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品颜色);
                ddlcolor.DataTextField = "title";
                ddlcolor.DataValueField = "value";
                ddlcolor.DataBind();
                ddlcolor.Items.Insert(0, new ListItem("选择颜色", ""));
                chkattribute.Items.Clear();
                WebControlBind.CheckBoxListBind(typeof(EnumAttribute), chkattribute);


                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnBrands model = ECBrand.GetBrandsInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    if (model != null && model.brandid != 0)
                    {
                        _brandInfo = ECBrand.GetBrandInfo(" where id=" + model.brandid);
                        this.ddlbrand.Items.Clear();
                        this.ddlbrand.Items.Insert(0, new ListItem(_brandInfo.title, model.brandid.ToString()));
                        this.ddlbrand.Enabled = false;
                    }


                    txttitle.Text = model.title;
                    //this.txtletter.Text = model.letter;
                    WebControlBind.CheckBoxListSetSelected(chkattribute, model.attribute);

                    //新增三项
                    //add:rafer
                    //date:4-24
                    this.ddlstyle.SelectedValue = model.style;
                    this.ddlmaterial.SelectedValue = model.material;
                    this.ddlcolor.SelectedValue = model.color;

                    //this.hfsurface.Value = model.surface;
                    //this.hflogo.Value = model.logo;
                    //this.hfthumb.Value = model.thumb;
                    //this.hfbannel.Value = model.bannel;
                    //this.hfdesimage.Value = model.desimage;

                    //this.txtdescript.Text = model.descript;
                    //this.txtkeywords.Text = model.keywords;
                    //this.ddltemplate.SelectedValue = model.template;
                    //this.txthits.Text = model.hits.ToString();
                    //this.txtsort.Text = model.sort.ToString();
                    //this.txtlastedittime.Text = model.lastedittime.ToString();
                    //this.ddlauditstatus.SelectedValue = model.auditstatus.ToString();
                    //this.ddllinestatus.SelectedValue = model.linestatus.ToString();

                   

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnBrands model = null;

            string strErr = "";


            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }




            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECBrand.GetBrandsInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
                if (model == null)
                {
                    model = new EnBrands();
                }
            }
            else
            {
                model = new EnBrands();
                model.createmid = 0;
                model.productcount = 0;
                model.style = "";
                model.spread = "";
                model.material = "";

            }


            int brandid = TypeConverter.StrToInt(ddlbrand.SelectedValue);
            string title = txttitle.Text;
            //string letter = this.txtletter.Text;
            string attribute = WebControlBind.CheckBoxListSelected(chkattribute);
            
            
           
            
            //string icp = this.txticp.Text;
            //string surface = this.hfsurface.Value;
            //string logo = this.hflogo.Value;
            //string thumb = this.hfthumb.Value;
            //string bannel = this.hfbannel.Value;
            //string desimage = this.hfdesimage.Value;
            //string descript = this.txtdescript.Text;
            //string keywords = this.txtkeywords.Text;
            //string template = ddltemplate.SelectedValue;
            //int hits = TypeConverter.StrToInt(this.txthits.Text);
            //int sort = TypeConverter.StrToInt(this.txtsort.Text);
            DateTime lastedittime = DateTime.Now;
            //int auditstatus = TypeConverter.StrToInt(ddlauditstatus.SelectedValue);
            //int linestatus = TypeConverter.StrToInt(ddllinestatus.SelectedValue);
            string material = Request.Form["ddlmaterial"]; //ddlmaterial.SelectedValue;
            string style = Request.Form["ddlstyle"]; //ddlstyle.SelectedValue;
            string color = Request.Form["ddlcolor"]; //ddlcolor.SelectedValue;

            model.brandid = brandid;
            model.title = title;
            //model.letter = letter;
            model.attribute = attribute;


            //model.surface = surface;
            //model.logo = logo;
            //model.thumb = thumb;
            //model.bannel = bannel;
            //model.desimage = desimage;
            //model.descript = descript;
            //model.keywords = keywords;
            //model.template = template;
            //model.hits = hits;
            //model.sort = sort;

            model.lasteditid = adminId;
            model.lastedittime = lastedittime;
            //model.auditstatus = auditstatus;
            //model.linestatus = linestatus;

            model.style = style;
            model.material = material;
            model.color = color;

            int aid = ECBrand.EditBrands(model);
            if (aid > 0)
            {
                //ECUpLoad ecUpload = new ECUpLoad();


                //if (surface.Length > 0)
                //{
                //    surface = surface.StartsWith(",") ? surface.Substring(1, surface.Length - 1) : surface;
                //    surface = surface.EndsWith(",") ? surface.Substring(0, surface.Length - 1) : surface;
                //    ecUpload.MoveFiles(surface.Split(','), string.Format(EnFilePath.Brands, aid, EnFilePath.Surface));
                //}
                //if (thumb.Length > 0)
                //{
                //    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Brands, aid, EnFilePath.Thumb));
                //}
                //if (logo.Length > 0)
                //{
                //    ecUpload.MoveFiles(logo.Split(','), string.Format(EnFilePath.Brands, aid, EnFilePath.Logo));
                //}
                //if (bannel.Length > 0)
                //{
                //    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Brands, aid, EnFilePath.Banner));
                //}
                //if (desimage.Length > 0)
                //{
                //    ecUpload.MoveFiles(desimage.Split(','), string.Format(EnFilePath.Brands, aid, EnFilePath.DesImage));
                //}

                //StringBuilder imglist = Utils.GetImgUrl(model.descript);

                //if (Utils.GetImgUrl(model.descript).Length > 0)
                //{
                //    string strConFilePath = "";
                //    foreach (string s in imglist.ToString().Split(','))
                //    {
                //        if (s.Contains(TREC.Entity.EnFilePath.tmpRootPath))
                //        {
                //            strConFilePath += s + ",";
                //        }
                //    }

                //    if (strConFilePath.Length > 0) {
                //        ECBrand.UpBrandsConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Brands, aid, EnFilePath.ConImage)), aid);
                //        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Brands, aid, EnFilePath.ConImage));
                //    }
                //}


                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}