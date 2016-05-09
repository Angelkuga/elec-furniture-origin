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
using System.IO;


namespace TREC.Web.Suppler.product
{
    public partial class productinfo : SupplerPageBase
    {
        protected string ColorSwatch = string.Empty;//色板
        protected int productId = 0;//复制同类时产品id
        protected int ppId = 0;//编辑时产品属性id
        protected string shopStr = string.Empty;
        protected string typeIdOption = string.Empty;//类型
        protected string myColorOption = string.Empty;//颜色
        protected string styleOption = string.Empty;//风格
        protected string colorOption = string.Empty;//色系
        protected string materialOption = string.Empty;//材质
        protected string ColorSwatchList = string.Empty;//色板
        public List<EnProductCon> conlist = new List<EnProductCon>();
        public List<EnProductAttribute> listproductattribute = null;
        public bool IsClass = false;
        public int PageIndex = 1;
        public int shopid = 0;
        protected string colorswatchids = string.Empty; //产品色板id
        public int companyid = 0;

        public bool ispay = false;

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // ispay = SupplerPageBase.IsPayMember();
                ispay = true;
                if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
                {
                    Master.menuName = "productlist";
                }
                else
                {
                    Master.menuName = "productinfo";
                }
                string memberId = CookiesHelper.GetCookie("mid");
                if (string.IsNullOrEmpty(memberId))
                {
                    Response.Write("<script>top.document.location.href='" + ECommon.WebUrl + "index.aspx" + "';</script>");
                    Response.End();
                }
                //产品品牌
                ddlbrand.DataSource = brandList;
                ddlbrand.DataTextField = "title";
                ddlbrand.DataValueField = "id";
                ddlbrand.DataBind();
                ddlbrand.Items.Insert(0, new ListItem("选择品牌", ""));



                //ddltype.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品类型);
                ddltype.DataTextField = "title";
                ddltype.DataValueField = "value";
                ddltype.DataBind();
                ddltype.Items.Insert(0, new ListItem("请选择", ""));

                //大类
                List<EnProductCategory> catagoryList = ECProductCategory.GetProductCategoryListToDDL("");
                var bigCate = from bc in catagoryList where bc.parentid == 0 select new { bc.id, bc.title };

                ddlBigCategory.DataSource = bigCate;
                ddlBigCategory.DataTextField = "title";
                ddlBigCategory.DataValueField = "id";
                ddlBigCategory.DataBind();
                ddlBigCategory.Items.Insert(0, new ListItem("选择大类", ""));

                ddlstyle.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品风格);
                ddlstyle.DataTextField = "title";
                ddlstyle.DataValueField = "value";
                ddlstyle.DataBind();
                ddlstyle.Items.Insert(0, new ListItem("选择风格", ""));



                ddlmaterial.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品选材);
                ddlmaterial.DataTextField = "title";
                ddlmaterial.DataValueField = "value";
                ddlmaterial.DataBind();
                ddlmaterial.Items.Insert(0, new ListItem("选择选材", ""));


                ddlcolor.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品颜色 + " and id between 143 and 148");
                ddlcolor.DataTextField = "title";
                ddlcolor.DataValueField = "value";
                ddlcolor.DataBind();
                ddlcolor.Items.Insert(0, new ListItem("选择色系", ""));

                ddlspread.Items.Clear();
                ddlspread.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品价位);
                ddlspread.DataTextField = "title";
                ddlspread.DataValueField = "value";
                ddlspread.DataBind();
                ddlspread.Items.Insert(0, new ListItem("请选择", ""));
                if (memberInfo.type == (int)EnumMemberType.工厂企业)
                {
                    companyid = companyInfo.id;
                }


                #region 活动类型数据
                List<TREC.Entity.t_promotionstype> promType = TREC.ECommerce.t_promotionstypeBLL.GetPromotionTypeList();
                ddlProductAttributePromotion.DataSource = promType;
                ddlProductAttributePromotion.DataTextField = "title";
                ddlProductAttributePromotion.DataValueField = "id";
                ddlProductAttributePromotion.DataBind();
                ddlProductAttributePromotion.Items.Insert(0, new ListItem("选择活动", ""));
                #endregion

                ////色板
                //Dictionary<int, string> DictSw = CategoryBll.QueryColorSwatchDb(userName);
                //if (DictSw != null)
                //{
                //    foreach (KeyValuePair<int, string> kvp in DictSw)
                //        ColorSwatch += "<input name=\"ColorSwatch\" type=\"checkbox\" value=\"" + kvp.Key + "\" />\r\n" + kvp.Value + "&nbsp;&nbsp;";
                //    DictSw.Clear();
                //    DictSw = null;
                //}


                //填充属性颜色下拉菜单
                fillDdlByConfig(out myColorOption, 103, 12);

                ShowData();
                queryShopList(memberId, ECommon.QueryId);
            }
        }
        #endregion

        #region 读取数据
        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnProduct model = ECProduct.GetProductInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    #region 赋值

                    this.productNo.Value = model.sku;
                    productName.Value = model.title;
                    IsClass = model.categoryid > 0;
                    //ddlproductcategory.SelectedValue = model.categoryid.ToString();
                    ddlbrand.SelectedValue = model.brandid.ToString();

                    ddlbrands.DataSource = ECBrand.GetBrandsList(" brandid=" + model.brandid);
                    ddlbrands.DataTextField = "title";
                    ddlbrands.DataValueField = "id";
                    ddlbrands.DataBind();
                    ddlbrands.Items.Insert(0, new ListItem("选择系列", ""));
                    ddlbrands.SelectedValue = model.brandsid.ToString();
                    hiddBrands.Value = model.brandsid.ToString();
                    hiddBrandsName.Value = model.brandstitle;
                    hiddSmallCate.Value = model.categoryid.ToString();
                    hiddSmallName.Value = model.categorytitle;
                    //txtdescript.Text = model.descript;
                    ddlstyle.SelectedValue = model.stylevalue;
                    ddlcolor.SelectedValue = model.colorvalue;
                    ddlmaterial.SelectedValue = model.materialvalue;
                    ppId = model.id;
                    //racustomize.SelectedValue = model.customize.ToString();
                    radAssemble.SelectedValue = model.assemble ? "1" : "0";
                    //大类
                    List<EnProductCategory> catagoryList = ECProductCategory.GetProductCategoryListToDDL("");
                    var smallCate = from bc in catagoryList where bc.id == model.categoryid select new { bc.id, bc.title };

                    smallCateId.DataSource = smallCate;
                    smallCateId.DataTextField = "title";
                    smallCateId.DataValueField = "id";
                    smallCateId.DataBind();
                    smallCateId.SelectedValue = model.categoryid.ToString();
                    ddlBigCategory.SelectedValue = ECProduct.GetBigCateBysmallID(model.categoryid).ToString();
                    this.hfsurface.Value = model.surface;
                    this.hflogo.Value = model.logo;
                    this.hfthumb.Value = model.thumb;
                    string bannel = model.bannel;
                    if (!string.IsNullOrEmpty(bannel))
                        bannel = bannel.Trim().TrimEnd(',') + ",";
                    this.hfbannel.Value = bannel;
                    this.hfdesimage.Value = model.desimage;
                    shopid = model.shopid;
                    #endregion

                    #region 产品属性
                    string prodectColorWsatch = string.Empty;
                    StringBuilder strProAttr = new StringBuilder();
                    listproductattribute = ECProductAttribute.GetProductAttributeList(" productid='" + model.id + "'");
                    int rowCount = 1;
                    foreach (var item in listproductattribute)
                    {

                        prodectColorWsatch = item.productcolorimg;
                        #region 返回值

                        strProAttr.Append("{");
                        strProAttr.Append("\"rowNum\":" + '"' + rowCount + '"');
                        strProAttr.Append(",\"attrid\":" + '"' + item.id + '"');
                        strProAttr.Append(",\"typeid\":" + '"' + item.typevalue + '"');
                        strProAttr.Append(",\"typename\":" + '"' + item.typename + '"');
                        strProAttr.Append(",\"productAttributePromotion\":" + '"' + item.productAttributePromotion + '"');
                        strProAttr.Append(",\"productAttributePromotionName\":" + '"' + string.Empty + '"');
                        strProAttr.Append(",\"pmaterial\":" + '"' + item.productmaterial + '"');
                        strProAttr.Append(",\"pacolor\":" + '"' + item.productcolorvalue + '"');
                        strProAttr.Append(",\"pcolortitle\":" + '"' + item.productcolortitle + '"');
                        strProAttr.Append(",\"plength\":" + '"' + item.productlength + '"');
                        strProAttr.Append(",\"pwidth\":" + '"' + item.productwidth + '"');
                        strProAttr.Append(",\"pheight\":" + '"' + item.productheight + '"');
                        strProAttr.Append(",\"pcbm\":" + '"' + item.productcbm + '"');
                        strProAttr.Append(",\"pmprice\":" + '"' + item.markprice + '"');
                        strProAttr.Append(",\"SalePrice\":" + '"' + item.saleprice + '"');
                        strProAttr.Append(",\"PromoPrice\":" + '"' + item.buyprice + '"');
                        strProAttr.Append(",\"Stock\":" + '"' + item.storage + '"');

                        strProAttr.Append("},");
                        rowCount++;
                        #region 暂时不用

                        //if (strProAttr.ToString() == "")
                        //{
                        //    strProAttr.Append("{");
                        //    strProAttr.Append("\"rowNum\":" + '"' + rowCount + '"');
                        //    strProAttr.Append(",\"typeid\":" +  '"'+item.typevalue+ '"' );
                        //    strProAttr.Append(",\"typename\":" + '"' + item.typename + '"');
                        //    strProAttr.Append(",\"pmaterial\":"+ '"'+item.productmaterial+'"');
                        //    strProAttr.Append(",\"pacolor\":" +'"'+ item.productcolorvalue+ '"');
                        //    strProAttr.Append(",\"pcolortitle\":" + '"' + item.productcolortitle + '"');
                        //    strProAttr.Append(",\"plength\":" +'"'+item.productlength+ '"' );
                        //    strProAttr.Append(",\"pwidth\":" + '"'+item.productwidth+ '"');
                        //    strProAttr.Append(",\"pheight\":" + '"'+item.productheight+ '"');
                        //    strProAttr.Append(",\"pcbm\":" + '"'+item.productcbm+ '"');
                        //    strProAttr.Append(",\"pmprice\":" +'"'+item.markprice+ '"' );
                        //    strProAttr.Append(",\"SalePrice\":" +'"'+ item.saleprice+ '"');
                        //    strProAttr.Append(",\"PromoPrice\":" +'"'+item.buyprice+ '"' );
                        //    strProAttr.Append(",\"Stock\":" + '"' + item.storage + '"');
                        //    strProAttr.Append("}");
                        //    rowCount++;
                        //}
                        //else
                        //{
                        //    strProAttr.Append(",{");
                        //    strProAttr.Append("\"rowNum\":" + '"' + rowCount + '"');
                        //    strProAttr.Append(",\"typeid\":" + '"' + item.typevalue + '"');
                        //    strProAttr.Append(",\"typename\":" + '"' + item.typename + '"');
                        //    strProAttr.Append(",\"pmaterial\":" + '"' + item.productmaterial + '"');
                        //    strProAttr.Append(",\"pacolor\":" + '"' + item.productcolorvalue + '"');
                        //    strProAttr.Append(",\"pcolortitle\":" + '"' + item.productcolortitle + '"');
                        //    strProAttr.Append(",\"plength\":" + '"' + item.productlength + '"');
                        //    strProAttr.Append(",\"pwidth\":" + '"' + item.productwidth + '"');
                        //    strProAttr.Append(",\"pheight\":" + '"' + item.productheight + '"');
                        //    strProAttr.Append(",\"pcbm\":" + '"' + item.productcbm + '"');
                        //    strProAttr.Append(",\"pmprice\":" + '"' + item.markprice + '"');
                        //    strProAttr.Append(",\"SalePrice\":" + '"' + item.saleprice + '"');
                        //    strProAttr.Append(",\"PromoPrice\":" + '"' + item.buyprice + '"');
                        //    strProAttr.Append(",\"Stock\":" + '"' + item.storage + '"');
                        //    strProAttr.Append("}");
                        //    rowCount++;
                        //}
                        #endregion

                        #endregion
                    }
                    hfproductattribute.Value = strProAttr.ToString();
                    #endregion

                    #region 产品规格

                    conlist = ECProduct.GetProductConList(" productid=" + model.id);
                    if (conlist.Count > 0)
                    {
                        string style = conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).ToList()[0].con : "";
                        string productInfo = conlist.Where(x => x.contype == (int)EnumProductConType.风格特点).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.风格特点).ToList()[0].con : "";
                        string materialname = conlist.Where(x => x.contype == (int)EnumProductConType.材质工艺).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.材质工艺).ToList()[0].con : "";
                        string productbaoyang = conlist.Where(x => x.contype == (int)EnumProductConType.保养说明).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.保养说明).ToList()[0].con : "";

                        string peisong = conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).ToList()[0].con : "";

                        //txtdescript.Text = style + productInfo + materialname + productbaoyang + peisong;
                        //conlist.Where(x => x.contype == (int)EnumProductConType.风格特点).ToList()[0].con +
                        //conlist.Where(x => x.contype == (int)EnumProductConType.产品细节).ToList()[0].con +
                        //conlist.Where(x => x.contype == (int)EnumProductConType.材质工艺).ToList()[0].con +
                        // conlist.Where(x => x.contype == (int)EnumProductConType.保养说明).ToList()[0].con;

                        //   conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).ToList()[0].con : "";
                        txt101.Text = conlist.Where(x => x.contype == (int)EnumProductConType.风格特点).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.风格特点).ToList()[0].con : "";
                        txt102.Text = conlist.Where(x => x.contype == (int)EnumProductConType.产品细节).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.产品细节).ToList()[0].con : "";
                        txt103.Text = conlist.Where(x => x.contype == (int)EnumProductConType.材质工艺).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.材质工艺).ToList()[0].con : "";
                        txt104.Text = conlist.Where(x => x.contype == (int)EnumProductConType.保养说明).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.保养说明).ToList()[0].con : "";
                        txt105.Text = conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).Count() > 0 ? conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).ToList()[0].con : "";
                    }

                    //listproductattribute = ECProductAttribute.GetProductAttributeList(" productno='" + model.no + "'");
                    //string prodectColorWsatch = string.Empty;
                    //if (listproductattribute != null)
                    //{
                    //    foreach (var item in listproductattribute)
                    //    {
                    //        if (item.productcolorimg!=null)
                    //        {
                    //            if (prodectColorWsatch=="")
                    //            {
                    //                prodectColorWsatch += item.productcolorimg;
                    //            }
                    //            else
                    //            {
                    //                prodectColorWsatch +=","+item.productcolorimg;
                    //            }

                    //        }
                    //    }
                    //}
                    #endregion

                    #region 色板

                    Dictionary<int, string> SwatchDic = ECBrand.GetSwatchName(CookiesHelper.GetCookie("mid"), 0);
                    if (ColorSwatch != "")
                    {
                        ColorSwatch = "";
                    }
                    if (0 < SwatchDic.Count())
                    {
                        string SwatchId = string.Empty;
                        foreach (KeyValuePair<int, string> kvp in SwatchDic)
                        {

                            if (prodectColorWsatch != null && prodectColorWsatch != "" && prodectColorWsatch.IndexOf("" + kvp.Key + "") > -1)
                            {
                                ColorSwatch += "<input name=\"ColorSwatch\"  checked=\"checked\" type=\"checkbox\" value=\"" + kvp.Key + "\" />\r\n" + kvp.Value + "&nbsp;&nbsp;";
                            }
                            else
                            {
                                ColorSwatch += "<input name=\"ColorSwatch\" type=\"checkbox\" value=\"" + kvp.Key + "\" />\r\n" + kvp.Value + "&nbsp;&nbsp;";
                            }

                        }
                    }
                    SetPermission(model.createmid, model.companyid, 0, 0, 0, 0, (System.Web.UI.WebControls.WebControl)btnSave, (System.Web.UI.HtmlControls.HtmlControl)btnRequest);

                    #endregion


                }
            }
        }
        #endregion

        private bool IsRepeat()
        {
            return true;
            //if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            //{
            //    return (ECProduct.GetProductList(" createmid=" + memberInfo.id + " and brandid=" + ddlbrand.SelectedValue + " and sku='" + productNo.Value.Trim() + "' and id!=" + ECommon.QueryId).ToList().Count == 0);
            //}
            //else
            //{
            //    return (ECProduct.GetProductList(" createmid=" + memberInfo.id + " and brandid=" + ddlbrand.SelectedValue + " and sku='" + productNo.Value.Trim() + "'").ToList().Count == 0);
            //}
        }
        #region 保存产品
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRepeat())
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
                    model.no = "";
                    model.hits = 0;
                    model.sort = 0;
                    //如果是子账号添加的产品
                    if (memberInfo.parentid != null && memberInfo.parentid != 0)
                    {
                        model.createmid = int.Parse(memberInfo.parentid.ToString());
                    }
                    else
                    {
                        model.createmid = memberInfo.id;
                    }

                    model.attribute = "";
                    model.auditstatus = 0;
                    model.linestatus = 0;

                }

                #region 接收参数
                int myId = 0;
                string shottitle = "";
                string tcolor = "";
                string sku = productNo.Value;
                string letter = "";
                int categoryid = int.Parse(hiddSmallCate.Value);

                string categorytitle = hiddSmallName.Value.Replace("-", "").Replace("|", "");
                string subcategoryidlist = "";
                string subcategorytitlelist = "";
                int brandid = int.Parse(ddlbrand.SelectedValue);
                string brandtitle = ddlbrand.SelectedItem.Text;
                if (!string.IsNullOrEmpty(hiddBrands.Value))
                {
                    int.TryParse(hiddBrands.Value, out myId);
                }
                int brandsid = myId;
                string brandstitle = hiddBrandsName.Value;
                if (!string.IsNullOrEmpty(ddlstyle.SelectedValue))
                {
                    int.TryParse(ddlstyle.SelectedValue, out myId);
                }
                string stylevalue = myId.ToString();
                string stylename = ddlstyle.SelectedItem.Text;
                string colorvalue = ddlcolor.SelectedValue;
                string colorname = ddlcolor.SelectedItem.Text;
                string materialvalue = ddlmaterial.SelectedValue;
                string materialname = ddlmaterial.SelectedItem.Text;
                string unit = "";
                string localitycode = "";
                string shipcode = "";
                string descript = "";
                // int customize = int.Parse(racustomize.SelectedValue);
                string surface = this.hfsurface.Value;
                string logo = this.hflogo.Value;
                string thumb = this.hfthumb.Value;
                //string thumb2 = Request["thumb"];

                string bannel = this.hfbannel.Value;
                string desimage = this.hfdesimage.Value;
                string tob2c = "";
                int comopanyid = 0;
                string companyname = "";
                int lastedid = 0;
                DateTime lastedittime = DateTime.Now;
                bool assemble = radAssemble.SelectedValue == "1";
                //品牌+类型+型号+风格
                string title = productName.Value;
                // brandtitle + " " + categorytitle + " " + sku + " " + materialname + " " + productName.Value;

                #endregion

                #region 赋值

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
                model.customize = 0;
                model.surface = surface;
                model.logo = logo;
                model.thumb = thumb;
                model.bannel = bannel;
                model.desimage = desimage;
                model.descript = descript;
                model.tob2c = tob2c;
                model.companyid = comopanyid;
                model.companyname = companyname;
                model.lastedid = lastedid;
                model.lastedittime = lastedittime;
                model.assemble = assemble;
                //model.descript = txtdescript.Text;

                string shopsids = string.Empty;
                int _shopid = 0;
                if (!string.IsNullOrEmpty(Request["shopId"]))
                {
                    shopsids = Request["shopId"].TrimEnd(',').Trim();
                    string[] arrshops = shopsids.Split(',');
                    int.TryParse(arrshops[0], out _shopid);

                }
                if (_shopid == 0)
                {
                    int.TryParse(memberInfo.shopid.ToString(), out _shopid);
                }
                model.shopid = _shopid;

                //else
                //    model.moreShopId = "";
                //整体图
                // model.thumb = Request["Overall"].TrimEnd(',').Trim();
                //局部图
                // model.bannel = Request["Part"].TrimEnd(',').Trim();
                #endregion

                int aid = ECProduct.EditProduct(model);

                #region 通知客服邮件
                if (model.id == 0)
                {
                    try
                    {
                        string mailsubject = string.Format(@"
                        <p>商家: {0} 用户名：{5}</p>
                        <p>添加了产品。</p>
                        <p>产品id:{1} 产品名称:{2}</p>
                        <p>商家id:{3} 商家身份:{4}</p>"
                                , companyInfo.title, aid, model.title, companyInfo.id, memberInfo.type, memberInfo.username);
                        string[] mailto = TREC.ECommerce.ECommon.ServiceMail.Split(',');
                        foreach (string items in mailto)
                        {
                            bool rsmail = EmailHelper.SendEmail("家具快搜 商家添加产品通知提示", items, mailsubject);
                        }
                    }
                    catch
                    {
                    }
                }

                #endregion
                string pricemail = string.Empty;

                if (aid > 0)
                {


                    ECUpLoad ecUpload = new ECUpLoad();
                    decimal price = 0;
                    #region 处理规格
                    if (hfproductattribute.Value != "")
                    {
                        string newAtri = hfproductattribute.Value;
                        if (newAtri.Substring(hfproductattribute.Value.Length - 1, 1) == ",")
                        {
                            newAtri = newAtri.Substring(0, hfproductattribute.Value.Length - 1);
                        }
                        string objJson = "[" + newAtri + "]";
                        JsonData jd = JsonMapper.ToObject(objJson);
                        string arrtids = string.Empty;
                        foreach (JsonData j in jd)
                        {
                            #region 赋值
                            decimal SalePrice = 0, markprice = 0, buyprice = 0;
                            JsonData i = j;
                            EnProductAttribute m = new EnProductAttribute();

                            int attrid = 0;
                            int.TryParse(i["attrid"].ToString(), out attrid);
                            if (attrid > 0)
                            {
                                m = ECProductAttribute.GetProductAttributeInfo(" where id=" + attrid);
                            }
                            m.id = attrid;
                            m.productid = aid;
                            m.productno = "";
                            m.productsku = model.sku;
                            m.typevalue = i["typeid"].ToString();
                            m.typename = i["typename"].ToString().Replace("请选择", "");
                            m.productstyle = "";
                            m.productmaterial = i["pmaterial"].ToString();
                            int productAttributePromotion = 0;
                            int.TryParse(i["productAttributePromotion"].ToString(), out productAttributePromotion);
                            m.productAttributePromotion = productAttributePromotion;
                            //m.productcolorimg = i["pcimg"].ToString().EndsWith(",") ? i["pcimg"].ToString().Substring(0, i["pcimg"].ToString().Length - 1) : i["pcimg"].ToString();
                            //if (m.productcolorimg != "")
                            //{
                            //    ecUpload.MoveContentFiles(m.productcolorimg.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.ProductAttributeColorImg));
                            //}
                            m.productcolortitle = i["pcolortitle"].ToString().Replace("无", "");
                            m.productcolorvalue = i["pacolor"].ToString();
                            m.productwidth = TypeConverter.StrToDeimal(i["pwidth"].ToString());
                            m.productheight = TypeConverter.StrToDeimal(i["pheight"].ToString());
                            m.productlength = TypeConverter.StrToDeimal(i["plength"].ToString());
                            m.productcbm = TypeConverter.StrToDeimal(i["pcbm"].ToString());
                            // m.buyprice = 0;*******
                            if (m.saleprice != null)
                            {
                                SalePrice = m.saleprice.Value;
                            }
                            if (m.markprice != null)
                            {
                                markprice = m.markprice.Value;
                            }
                            if (m.buyprice != null)
                            {
                                buyprice = m.buyprice.Value;
                            }

                            m.markprice = TypeConverter.StrToDeimal(i["pmprice"].ToString());
                            m.saleprice = TypeConverter.StrToDeimal(i["SalePrice"].ToString());
                            m.buyprice = TypeConverter.StrToDeimal(i["PromoPrice"].ToString());

                            if (m.markprice != markprice)
                            {
                                pricemail = pricemail + "市场参考价有改动,原来价格:" + markprice + ",改动后的价格:" + i["pmprice"].ToString();
                            }
                            else if (m.saleprice != SalePrice)
                            {
                                pricemail = pricemail + "销售价有改动,原来价格:" + SalePrice + ",改动后的价格:" + i["SalePrice"].ToString();
                            }
                            else if (m.buyprice != buyprice)
                            {
                                pricemail = pricemail + "促销价有改动,原来价格:" + buyprice + ",改动后的价格:" + i["PromoPrice"].ToString();
                            }
                            m.otherinfo = "";
                            int storage = 0;
                            int.TryParse(i["Stock"].ToString(), out storage);
                            m.storage = storage;
                            m.sort = 0;
                            m.isdefault = 0;

                            price = TypeConverter.StrToDeimal(i["pmprice"].ToString());
                            //色板
                            if (!string.IsNullOrEmpty(Request["ColorSwatch"]))
                            {
                                m.productcolorimg = Request["ColorSwatch"].TrimEnd(',').Trim();
                            }

                            #region wengjie 2015-3-3 产品加入活动后 状态设为待审核
                            if (m.id > 0)
                            {
                                EnProductAttribute oldm = ECProductAttribute.GetProductAttributeInfo(string.Format(" where id={0}", m.id));
                                if (m.productAttributePromotion != oldm.productAttributePromotion)
                                {
                                    EnProduct unlineProd = ECProduct.GetProductInfo(string.Format(" where id={0}", m.productid));
                                    unlineProd.auditstatus = 0;
                                    ECProduct.EditProduct(unlineProd);
                                }
                            }
                            #endregion

                            int atid = ECProductAttribute.EditProductAttribute(m);

                            if (model.id > 0 && !string.IsNullOrEmpty(pricemail))
                            {
                                try
                                {
                                    companyInfo = ECCompany.GetCompanyInfo(" where mid=" + aid);
                                    string mailsubject = string.Format(@"
                        <p>商家: {0} 用户名：{5}</p>
                        <p>价格修改。</p>
                        <p>产品id:{1} 产品名称:{2}</p>
                        <p>商家id:{3} 商家身份:{4}</p><p>价格修改情况：" + pricemail + "</p>"
                                            , companyInfo.title, aid, model.title, companyInfo.id, memberInfo.type, memberInfo.username);
                                    string[] mailto = TREC.ECommerce.ECommon.ServiceMail.Split(',');
                                    foreach (string items in mailto)
                                    {
                                        bool rsmail = EmailHelper.SendEmail("家具快搜 商家价格修改通知提示", items, mailsubject);
                                    }
                                }
                                catch
                                {
                                }
                            }

                            if (atid > 0)
                            {
                                if (arrtids == "")
                                {
                                    arrtids += atid;
                                }
                                else
                                {
                                    arrtids += "," + atid;
                                }
                            }
                            #endregion
                        }
                        if (arrtids != "")
                        {
                            //删除多余的信息
                            ECProductAttribute.DelProductAttribute(string.Format("  id not in({0}) and productid={1}", arrtids, aid));
                        }

                    }

                    #endregion

                    #region 添加店铺
                    //店铺id
                    string shopsid = string.Empty;
                    //清理店铺
                    ECProductShopPrice.DeleteProductShopPrice(string.Format(" where productid={0}", aid));
                    if (!string.IsNullOrEmpty(Request["shopId"]))
                    {


                        shopsid = Request["shopId"].TrimEnd(',').Trim();
                        EnProductShopPrice modelShop = new EnProductShopPrice();
                        string[] arrshops = shopsid.Split(',');
                        for (int i = 0; i < arrshops.Length; i++)
                        {
                            modelShop.Productid = aid;
                            modelShop.Shopid = 0; //int.Parse(arrshops[i]);
                            modelShop.Price = price;
                            modelShop.Brandid = brandid;
                            modelShop.Brandsid = brandsid;
                            modelShop.Lastedittime = DateTime.Now;
                            ECProductShopPrice.EditProductShopPrice(modelShop);
                        }
                    #endregion

                    }

                    #region 处理图片

                    if (thumb.Length > 0)
                    {
                        ArrayList alst1 = new ArrayList();
                        alst1.Add(ecUpload._550_410);
                        alst1.Add(ecUpload._230_173);
                        ArrayList alst2 = new ArrayList();
                        alst2.Add(ecUpload._1_1);
                        string oldFilePath = string.Empty;
                        string newFilePath = string.Empty;
                        string newFilePath2 = string.Empty;


                        if (hiddpid.Value != "")
                        {
                            #region 如果是复制，则不需要保存图片，复制图片
                            oldFilePath = Server.MapPath("~/upload/product/thumb/" + hiddpid.Value + "/" + thumb);
                            if (oldFilePath != "" && File.Exists(oldFilePath))
                            {
                                var str1 = oldFilePath.Substring(0, oldFilePath.IndexOf("thumb") + 6);
                                var str2 = oldFilePath.Substring(str1.Length, oldFilePath.Length - str1.Length);
                                newFilePath = str1 + aid + "\\" + str2.Substring(str2.LastIndexOf("\\"), str2.Length - str2.LastIndexOf("\\"));
                                newFilePath2 = str1 + aid + "\\";
                                try
                                {
                                    if (!Directory.Exists(newFilePath2))
                                    {
                                        Directory.CreateDirectory(newFilePath2);
                                    }

                                    DirectoryInfo dinfo = new DirectoryInfo(Server.MapPath("~/upload/product/thumb/" + hiddpid.Value + "/"));//注，这里面传的是路径，并不是文件，所以不能保含带后缀的文件
                                    foreach (FileSystemInfo f in dinfo.GetFileSystemInfos())
                                    {
                                        File.Copy(oldFilePath, newFilePath, true);//true代表可以覆盖同名文件
                                    }
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                            else
                            {
                                ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.Thumb), alst1, alst2, true);
                            }
                            #endregion
                        }
                        else
                        {
                            ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.Thumb), alst1, alst2, true);
                        }
                        //ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.Thumb), alst1, alst2, true);
                    }
                    //if (desimage.Length > 0)
                    //{
                    //    ecUpload.MoveFiles(desimage.Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.DesImage));
                    //}
                    if (bannel.Length > 0)
                    {
                        ArrayList alst1 = new ArrayList();
                        alst1.Add(ecUpload._750_2000);
                        ArrayList alst2 = new ArrayList();
                        alst2.Add(ecUpload._1_1);
                        string oldFilePath = string.Empty;
                        string newFilePath = string.Empty;
                        string newFilePath2 = string.Empty;
                        if (hiddpid.Value != "")
                        {
                            #region 如果是复制，则不需要保存图片，复制图片
                            //var dd = bannel.Substring(bannel.Length-1, bannel.Length);
                            //if (bannel.Substring(bannel.Length-1,bannel.Length)==",")
                            //{
                            //    bannel = bannel.Substring(0,bannel.Length-1);
                            //}
                            string[] bannelArr = bannel.Split(',');
                            for (int i = 0; i < bannelArr.Length; i++)
                            {
                                if (bannelArr[i] != "")
                                {
                                    oldFilePath = Server.MapPath("~/upload/product/banner/" + hiddpid.Value + "/" + bannelArr[i]);
                                    var str1 = oldFilePath.Substring(0, oldFilePath.IndexOf("banner") + 7);
                                    var str2 = oldFilePath.Substring(str1.Length, oldFilePath.Length - str1.Length);
                                    newFilePath = str1 + aid + "\\" + str2.Substring(str2.LastIndexOf("\\"), str2.Length - str2.LastIndexOf("\\"));
                                    newFilePath2 = str1 + aid + "\\";

                                    if (oldFilePath != "" && File.Exists(oldFilePath))
                                    {
                                        #region 开始复制

                                        try
                                        {
                                            if (!Directory.Exists(newFilePath2))
                                            {
                                                Directory.CreateDirectory(newFilePath2);
                                            }

                                            DirectoryInfo dinfo = new DirectoryInfo(Server.MapPath("~/upload/product/banner/" + hiddpid.Value + "/"));//注，这里面传的是路径，并不是文件，所以不能保含带后缀的文件
                                            foreach (FileSystemInfo f in dinfo.GetFileSystemInfos())
                                            {
                                                File.Copy(oldFilePath, newFilePath, true);//true代表可以覆盖同名文件
                                            }
                                        }
                                        catch (Exception)
                                        {

                                            throw;
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.Banner), alst1, alst2, true);
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.Banner), alst1, alst2, true);
                        }
                        //ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.Banner), alst1, alst2, true);
                    }

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


                    if (memberInfo.type == 101)
                    {

                        Response.Write("<script>alert('保存信息成功！');location.href='productlist.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('保存信息成功！');location.href='productlist.aspx';</script>");
                    }


                }
            }
            else
            {
                Response.Write("<script>alert('产品编号不能重复！');</script>");
            }
        }
        #endregion

        #region 绑定其他数据
        /// <summary>
        /// 查询所属店铺并加载已选择
        /// </summary>
        /// <param name="memberId">会员id</param>
        /// <param name="productID">产品id</param>
        private   void queryShopList(string memberId, string productID)
        {
            int shopRecord = 0;
            if (string.IsNullOrEmpty(productID)) productID = "0";
            //获取会员所属的店铺
            List<EnShop> shopList = ECShop.GetShopList(" createmid = " + memberId.ToString(), out shopRecord);
            //获取产品对应的店铺
            List<EnProductShopPrice> productShops = ECProductShopPrice.GetProductShopPriceListByWhere(string.Format(" productid={0}", productID));
            if (shopList != null)
            {
                if (0 < shopRecord)
                {
                    foreach (EnShop model in shopList)
                    {
                        shopStr += "<li><label><input type=\"checkbox\" value=\"" + model.id.ToString() + "\"";
                        foreach (EnProductShopPrice modelA in productShops)
                        {

                            if (model.id == modelA.Shopid)
                            {
                                shopStr += " checked=\"checked\" ";
                            }

                        }
                        shopStr += " name=\"shopId\">" + model.title + "</label></li>";
                    }
                }
                shopList.Clear();
                shopList = null;
            }
        }

        /// <summary>
        /// 获得下拉菜单option
        /// </summary>
        /// <param name="optionStr"></param>
        /// <param name="module"></param>
        /// <param name="type"></param>
        private void fillDdlByConfig(out string optionStr, int module, int type)
        {
            optionStr = string.Empty;
            List<EnConfig> fList = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品颜色);
            //List<EnConfig> fList = ECConfig.GetConfigList(" module=" + module.ToString() + " and type=" + type.ToString());
            if (fList != null)
            {
                foreach (EnConfig model in fList)
                    optionStr += "<option value=" + model.value.Trim() + ">" + model.title.Trim() + "</option>";
                fList.Clear();
                fList = null;
            }
        }
        /// <summary>
        /// 加载色板数据
        /// </summary>
        /// <param name="memberId">会员id</param>
        private void loadColorSwatchList(string memberId)
        {
            Dictionary<int, string> dictCs = ECBrand.GetSwatchName(memberId, 0);
            if (dictCs != null)
            {
                foreach (KeyValuePair<int, string> kvp in dictCs)
                    ColorSwatchList += "<input type=\"checkbox\" value=\"" + kvp.Key.ToString() + "\" name=\"ColorSwatch\">" + kvp.Value + "&nbsp;&nbsp;";
                dictCs.Clear();
                dictCs = null;
            }
        }
        #endregion
    }
}