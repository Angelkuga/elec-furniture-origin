using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using LitJson;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using System.Collections;


namespace TREC.Web.Admin.product
{
    public partial class productinfo : AdminPageBase
    {
        public List<EnProductCon> conlist = new List<EnProductCon>();
        public List<EnProductAttribute> listproductattribute = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddlauditstatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumAuditStatus), ddlauditstatus);
                ddlauditstatus.Items.Insert(0, new ListItem("请选择", ""));

                ddllinestatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumLineStatus), ddllinestatus);
                ddllinestatus.Items.Insert(0, new ListItem("请选择", ""));


                chkattribute.Items.Clear();
                WebControlBind.CheckBoxListBind(typeof(EnumAttribute), chkattribute);
                chkattribute.Items.Remove(new ListItem("精华", "104"));
                chkattribute.Items.Remove(new ListItem("幻灯", "105"));
                chkattribute.Items.Remove(new ListItem("高亮", "106"));

                ddlproductcategory.Items.Clear();
                ddlproductcategory.DataSource = ECProductCategory.GetProductCategoryListToDDL("");
                ddlproductcategory.DataTextField = "title";
                ddlproductcategory.DataValueField = "id";
                ddlproductcategory.DataBind();

                ddlbrand.DataSource = ECBrand.GetBrandList("").OrderBy(c => c.title);
                ddlbrand.DataTextField = "title";
                ddlbrand.DataValueField = "id";
                ddlbrand.DataBind();
                ddlbrand.Items.Insert(0, new ListItem("请选择品牌", ""));


                ddlbrands.DataSource = ECBrand.GetBrandList("");
                ddlbrands.Items.Insert(0, new ListItem("请选择系列", ""));


                ddlstyle.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品风格);
                ddlstyle.DataTextField = "title";
                ddlstyle.DataValueField = "value";
                ddlstyle.DataBind();
                ddlstyle.Items.Insert(0, new ListItem("请选择风格", ""));



                ddlmaterial.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品选材);
                ddlmaterial.DataTextField = "title";
                ddlmaterial.DataValueField = "value";
                ddlmaterial.DataBind();
                ddlmaterial.Items.Insert(0, new ListItem("请选择选材", ""));


                ddlcolor.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品颜色 + " and id between 143 and 148");
                ddlcolor.DataTextField = "title";
                ddlcolor.DataValueField = "value";
                ddlcolor.DataBind();
                ddlcolor.Items.Insert(0, new ListItem("请选择色系", ""));

                ddltype.Items.Insert(0, new ListItem("请选择", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnProduct model = ECProduct.GetProductInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    WebControlBind.CheckBoxListSetSelected(chkattribute, model.attribute);
                    this.txttitle.Text = model.title;
                    this.txtsku.Text = model.sku;

                    ddlproductcategory.SelectedValue = model.categoryid.ToString();

                    ddlbrand.SelectedValue = model.brandid.ToString();

                    ddlbrands.DataSource = ECBrand.GetBrandsList(" brandid=" + model.brandid);
                    ddlbrands.DataTextField = "title";
                    ddlbrands.DataValueField = "id";
                    ddlbrands.DataBind();
                    ddlbrands.Items.Insert(0, new ListItem("请选择", ""));
                    ddlbrands.SelectedValue = model.brandsid.ToString();

                    ddlstyle.SelectedValue = model.stylevalue;
                    ddlcolor.SelectedValue = model.colorvalue;
                    ddlmaterial.SelectedValue = model.materialvalue;
                    racustomize.SelectedValue = model.customize.ToString();

                    ddltype.Items.Clear();
                    ddltype.DataSource = ECConfig.GetConfigList(" type=" + (int)EnumConfigByProduct.产品类型 + " and value in(" + ECPCategoryPTyp.GetProductCategoryTypeValueList(model.categoryid) + ")");
                    ddltype.DataTextField = "title";
                    ddltype.DataValueField = "value";
                    ddltype.DataBind();
                    ddltype.Items.Insert(0, new ListItem("请选择", ""));


                    this.hfsurface.Value = model.surface;
                    this.hflogo.Value = model.logo;
                    this.hfthumb.Value = model.thumb;
                    this.hfbannel.Value = model.bannel;
                    this.hfdesimage.Value = model.desimage;
                    this.hfhomepageimg.Value = model.HomePageImg;
                    this.txtlastedittime.Text = model.lastedittime.ToString();
                    
                    ddlauditstatus.SelectedValue = model.auditstatus.ToString();
                    ddllinestatus.SelectedValue = model.linestatus.ToString();
                    txtFID.Text = model.FID.ToString();
                    conlist = ECProduct.GetProductConList(" productid=" + model.id);
                    txtsort.Text = model.sort.ToString();
                    if (conlist.Count > 0)
                    {
                        txt101.Text = conlist.Where(x => x.contype == (int)EnumProductConType.风格特点).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.风格特点).ToList()[0].con : "";
                        txt102.Text = conlist.Where(x => x.contype == (int)EnumProductConType.产品细节).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.产品细节).ToList()[0].con : "";
                        txt103.Text = conlist.Where(x => x.contype == (int)EnumProductConType.材质工艺).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.材质工艺).ToList()[0].con : "";
                        txt104.Text = conlist.Where(x => x.contype == (int)EnumProductConType.保养说明).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.保养说明).ToList()[0].con : "";
                        txt105.Text = conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).ToList()[0].con : "";
                    }
                    txtdescript.Text = model.descript;
                    listproductattribute = ECProductAttribute.GetProductAttributeList(" productno='" + model.no + "'");


                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnProduct model = null;

            string strErr = "";


            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECProduct.GetProductInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }

            if (model == null)
            {
                model = new EnProduct();
                model.createmid = 0;
                model.no = "";
                model.hits = 0;
                model.sort = 0;

            }

            string attribute = WebControlBind.CheckBoxListSelected(chkattribute);
            string title = this.txttitle.Text;
            string shottitle = "";
            string tcolor = "";
            string sku = this.txtsku.Text;
            string letter = "";
            int categoryid = int.Parse(ddlproductcategory.SelectedValue);
            string categorytitle = ddlproductcategory.SelectedItem.Text.Replace("-", "").Replace("|", "");
            string subcategoryidlist = "";
            string subcategorytitlelist = "";
            int brandid = int.Parse(ddlbrand.SelectedValue);
            string brandtitle = ddlbrand.SelectedItem.Text;
            int brandsid = int.Parse(Request.Params["ddlbrands"].ToString());
            string brandstitle = ddlbrands.SelectedItem.Text;
            string stylevalue = ddlstyle.SelectedValue;
            string stylename = ddlstyle.SelectedItem.Text;
            string colorvalue = ddlcolor.SelectedValue;
            string colorname = ddlcolor.SelectedItem.Text;
            string materialvalue = ddlmaterial.SelectedValue;
            string materialname = ddlmaterial.SelectedItem.Text;
            string unit = "张";
            string localitycode = "";
            string shipcode = "";
            string descript = txtdescript.Text;
            int customize = int.Parse(racustomize.SelectedValue);
            string surface = this.hfsurface.Value;
            string logo = this.hflogo.Value;
            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value;
            string desimage = this.hfdesimage.Value;
            string homepageimg = this.hfhomepageimg.Value;
            string tob2c = "";
            int comopanyid = 0;
            string companyname = "";
            int lastedid = 0;
            DateTime lastedittime = DateTime.Now;
            int auditstatus = int.Parse(ddlauditstatus.SelectedValue);
            int linestatus = int.Parse(ddllinestatus.SelectedValue);
            int fid = int.Parse(txtFID.Text.Trim());

            model.attribute = attribute;
            model.title = title;
            model.shottitle = shottitle;
            model.tcolor = tcolor;
            model.sku = sku;
            model.letter = letter;
            model.categoryid = categoryid;
            model.categorytitle = categorytitle;
            model.subcategoryidlist = subcategoryidlist;
            model.subcategorytitlelist = subcategorytitlelist;
            model.brandid = brandid;
            model.brandtitle = brandtitle;
            model.brandsid = brandsid;
            model.brandstitle = brandstitle;
            model.stylevalue = stylevalue;
            model.stylename = stylename;
            model.colorname = colorname;
            model.colorvalue = colorvalue;
            model.materialvalue = materialvalue;
            model.materialname = materialname;
            model.unit = unit;
            model.localitycode = localitycode;
            model.shipcode = shipcode;
            model.customize = customize;
            model.surface = surface;
            model.logo = logo;
            model.thumb = thumb;
            model.bannel = bannel;
            model.desimage = desimage;
            model.HomePageImg = homepageimg;
            //model.descript = descript;
            model.tob2c = tob2c;
            model.companyid = comopanyid;
            model.companyname = companyname;
            model.lastedid = lastedid;
            model.lastedittime = lastedittime;
            model.auditstatus = auditstatus;
            model.linestatus = linestatus;
            model.FID = fid;
            model.sort = int.Parse(txtsort.Text);

            int aid = ECProduct.EditProduct(model);
            if (aid > 0)
            {

                ECUpLoad ecUpload = new ECUpLoad();

                #region 处理规格
                if (hfproductattribute.Value != "")
                {
                    string objJson = "[" + hfproductattribute.Value.Substring(0, hfproductattribute.Value.Length - 1) + "]";
                    JsonData jd = JsonMapper.ToObject(objJson);
                    foreach (JsonData j in jd)
                    {
                        JsonData i = j;
                        EnProductAttribute m = new EnProductAttribute();
                        m.productid = aid;
                        m.productno = "";
                        m.productsku = model.sku;
                        m.typevalue = i["typeid"].ToString();
                        m.typename = i["typename"].ToString();
                        m.productstyle = "";
                        m.productmaterial = i["pmaterial"].ToString();
                        m.productcolorimg = i["pcimg"].ToString().EndsWith(",") ? i["pcimg"].ToString().Substring(0, i["pcimg"].ToString().Length - 1) : i["pcimg"].ToString();
                        if (m.productcolorimg != "")
                        {
                            ecUpload.MoveContentFiles(m.productcolorimg.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.ProductAttributeColorImg));
                        }
                        m.productcolortitle = i["pcolortitle"].ToString();
                        m.productcolorvalue = i["pacolor"].ToString();
                        m.productwidth = TypeConverter.StrToDeimal(i["pwidth"].ToString());
                        m.productheight = TypeConverter.StrToDeimal(i["pheight"].ToString());
                        m.productlength = TypeConverter.StrToDeimal(i["plength"].ToString());
                        m.productcbm = TypeConverter.StrToDeimal(i["pcbm"].ToString());
                        m.buyprice = 0;
                        m.markprice = TypeConverter.StrToDeimal(i["pmprice"].ToString());
                        m.saleprice = 0;
                        m.otherinfo = "";
                        m.storage = 0;
                        m.sort = 0;
                        m.isdefault = 0;
                        ECProductAttribute.EditProductAttribute(m);
                    }

                }

                #endregion

                #region 处理图片


                if (surface.Length > 0)
                {
                    surface = surface.StartsWith(",") ? surface.Substring(1, surface.Length - 1) : surface;
                    surface = surface.EndsWith(",") ? surface.Substring(0, surface.Length - 1) : surface;
                    ecUpload.MoveFiles(surface.Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.Surface));
                }
                if (thumb.Length > 0)
                {
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._550_410);
                    alst1.Add(ecUpload._230_173);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._1_1);
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.Thumb), alst1, alst2, true);
                }
                if (bannel.Length > 0)
                {
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._750_2000);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._1_1);
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.Banner), alst1, alst2, true);
                }

                StringBuilder imglist = Utils.GetImgUrl(txt101.Text + txt102.Text + txt103.Text + txt104.Text + txt105.Text);

                if (imglist.ToString().Length > 0)
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
                        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.ConImage));
                    }
                }

                if (homepageimg.Length > 0)
                {
                    homepageimg = homepageimg.StartsWith(",") ? homepageimg.Substring(1, homepageimg.Length - 1) : homepageimg;
                    homepageimg = homepageimg.EndsWith(",") ? homepageimg.Substring(0, homepageimg.Length - 1) : homepageimg;
                    ecUpload.MoveFiles(homepageimg.Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.HomePageImg));
                }


                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
                #endregion

                #region 处理内容
                txt101.Text = txt101.Text.Replace(TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Product, aid, EnFilePath.ConImage));
                txt102.Text = txt102.Text.Replace(TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Product, aid, EnFilePath.ConImage));
                txt103.Text = txt103.Text.Replace(TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Product, aid, EnFilePath.ConImage));
                txt104.Text = txt104.Text.Replace(TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Product, aid, EnFilePath.ConImage));
                txt105.Text = txt105.Text.Replace(TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Product, aid, EnFilePath.ConImage));

                conlist = ECProduct.GetProductConList(" productid=" + model.id);
                EnProductCon m1 = new EnProductCon();
                m1.productid = aid;
                m1.contype = (int)EnumProductConType.风格特点;
                m1.con = txt101.Text;

                if (conlist.Where(x => x.contype == (int)EnumProductConType.风格特点).Count() > 0)
                {
                    m1.id = conlist.Where(x => x.contype == (int)EnumProductConType.风格特点).ToList()[0].id;
                    ECProduct.EditProductCon(m1);
                }
                else if (txt101.Text != "")
                {
                    ECProduct.EditProductCon(m1);
                }

                EnProductCon m2 = new EnProductCon();
                m2.productid = aid;
                m2.contype = (int)EnumProductConType.产品细节;
                m2.con = txt102.Text;
                if (conlist.Where(x => x.contype == (int)EnumProductConType.产品细节).Count() > 0)
                {
                    m2.id = conlist.Where(x => x.contype == (int)EnumProductConType.产品细节).ToList()[0].id;
                    ECProduct.EditProductCon(m2);
                }
                else if (txt102.Text != "")
                {
                    ECProduct.EditProductCon(m2);
                }

                EnProductCon m3 = new EnProductCon();
                m3.productid = aid;
                m3.contype = (int)EnumProductConType.材质工艺;
                m3.con = txt103.Text;
                if (conlist.Where(x => x.contype == (int)EnumProductConType.材质工艺).Count() > 0)
                {
                    m3.id = conlist.Where(x => x.contype == (int)EnumProductConType.材质工艺).ToList()[0].id;
                    ECProduct.EditProductCon(m3);
                }
                else if (txt103.Text != "")
                {
                    ECProduct.EditProductCon(m3);
                }


                EnProductCon m4 = new EnProductCon();
                m4.productid = aid;
                m4.contype = (int)EnumProductConType.保养说明;
                m4.con = txt104.Text;
                if (conlist.Where(x => x.contype == (int)EnumProductConType.保养说明).Count() > 0)
                {
                    m4.id = conlist.Where(x => x.contype == (int)EnumProductConType.保养说明).ToList()[0].id;
                    ECProduct.EditProductCon(m4);
                }
                else if (txt104.Text != "")
                {
                    ECProduct.EditProductCon(m4);
                }


                EnProductCon m5 = new EnProductCon();
                m5.productid = aid;
                m5.contype = (int)EnumProductConType.配送周期;
                m5.con = txt105.Text;
                if (conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).Count() > 0)
                {
                    m5.id = conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).ToList()[0].id;
                    ECProduct.EditProductCon(m5);
                }
                else if (txt105.Text != "")
                {
                    ECProduct.EditProductCon(m5);
                }


                #endregion

            }


        }

        /// <summary>
        /// 获取活动名称
        /// </summary>
        /// <param name="productAttributePromotion"></param>
        /// <returns></returns>
        protected string GetProdAttrPromName(int productAttributePromotion)
        {
            t_promotionstype pAPN = t_promotionstypeBLL.GetPromotionTypeById(productAttributePromotion);
            if (pAPN != null)
                return pAPN.title;
            else
                return "";
        }
    }
}