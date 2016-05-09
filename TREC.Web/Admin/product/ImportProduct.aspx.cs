using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Entity;
using TREC.ECommerce;
using System.Data.OleDb;
using System.Data;
using TRECommon;

namespace TREC.Web.Admin.product
{
    public partial class ImportProduct : System.Web.UI.Page
    {
        public static List<EnBrand> brandList = new List<EnBrand>();
        public static EnMember memberInfo = null;
        public static EnCompany companyInfo = null;
        public static EnDealer dealerInfo = null;
        public static string brandidlist = "";
        public static string EorrStr = "";
        public static int EorrCon = 0;
        public static int ProductCon = 0;
        public static int ProductOldCon = 0;
        public static string ProductOldStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ECommon.QueryId))
            {
                UiCommon.JscriptPrint(this.Page, "对不起。会员不存在!", Request.Url.AbsoluteUri, "Success");
                return;
            }
            LbMsg.Text = "";
            memberInfo = ECMember.GetMemberInfo(" where id=" + ECommon.QueryId);
            if (memberInfo == null)
            {
                UiCommon.JscriptPrint(this.Page, "对不起。会员不存在!", Request.Url.AbsoluteUri, "Success");
                return;
            }

            if (!IsPostBack)
            {
                switch (memberInfo.type)
                {
                    case (int)EnumMemberType.工厂企业:
                        companyInfo = ECCompany.GetCompanyInfo(" where mid=" + memberInfo.id);
                        brandList = ECBrand.GetBrandList(" companyid=" + companyInfo.id);
                        if (brandList.Count <= 0)
                        {
                            brandList = null;
                        }
                        break;
                    case (int)EnumMemberType.经销商:
                        dealerInfo = ECDealer.GetDealerInfo(" where mid=" + memberInfo.id);
                        List<EnAppBrand> appList = ECAppBrand.GetAppBrandList(" dealerid=" + dealerInfo.id);
                        brandidlist = "";
                        foreach (EnAppBrand b in appList)
                        {
                            brandidlist += b.brandid + ",";
                        }
                        brandidlist = brandidlist.Length > 0 && brandidlist.EndsWith(",") ? brandidlist.Substring(0, brandidlist.Length - 1) : brandidlist;
                        if (brandidlist.Length > 0)
                        {
                            brandList = ECBrand.GetBrandList(" id in(" + brandidlist + ")");
                        }
                        else
                        {
                            brandList = null;
                        }
                        break;
                    default:
                        brandList = null;
                        break;
                }

                if (brandList == null)
                {
                    UiCommon.JscriptPrint(this.Page, "对不起。会员不存在!", Request.Url.AbsoluteUri, "Success");
                    return;
                }

                ddlbrand.DataSource = brandList;
                ddlbrand.DataTextField = "title";
                ddlbrand.DataValueField = "id";
                ddlbrand.DataBind();
                ddlbrand.Items.Insert(0, new ListItem("选择品牌", ""));

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


                ddlcolor.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品颜色);
                ddlcolor.DataTextField = "title";
                ddlcolor.DataValueField = "value";
                ddlcolor.DataBind();
                ddlcolor.Items.Insert(0, new ListItem("请选择色系", ""));

            }



        }



        /// <summary>
        /// 上传xls文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            #region 上传文件

            EorrStr = "";
            EorrCon = 0;
            ProductCon = 0;
            ProductOldCon = 0;
            ProductOldStr = "";

            HttpPostedFile _upfile = HttpContext.Current.Request.Files[0];
            if (_upfile == null)
            {
                UiCommon.JscriptPrint(this.Page, "对不起。文件不要存在!", Request.Url.AbsoluteUri, "Success");
                return;
            }
            string _fileExt = _upfile.FileName.Substring(_upfile.FileName.LastIndexOf(".") + 1);
            if (_fileExt != "xls" && _fileExt != "xlsx")
            {
                UiCommon.JscriptPrint(this.Page, "对不起。请上传execl文件!", Request.Url.AbsoluteUri, "Success");
                return;
            }
            string fileNameMin = DateTime.Now.ToString("yyyyMMddHHmmssff") + "." + _fileExt;
            string filepath = HttpContext.Current.Server.MapPath("../../upload/Excel/");
            _upfile.SaveAs(filepath + fileNameMin);
            #endregion

            #region 读取Execl
            string StrConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filepath + fileNameMin + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection MyConn = new OleDbConnection(StrConn);
            // MyConn.Open();
            string StrExcel = "";
            OleDbDataAdapter MyCommand = null;
            DataSet ds = null;
            DataSet ds2 = null;
            StrExcel = "select * from [product$]";
            MyCommand = new OleDbDataAdapter(StrExcel, StrConn);
            ds = new DataSet();
            MyCommand.Fill(ds, "table1");

            StrExcel = "select * from [productattribute$]";
            MyCommand = new OleDbDataAdapter(StrExcel, StrConn);
            ds2 = new DataSet();
            MyCommand.Fill(ds2, "table2");
            #endregion

            if (ds == null || ds.Tables[0] == null)
            {
                UiCommon.JscriptPrint(this.Page, "对不起。请上传有数据的execl文件!", Request.Url.AbsoluteUri, "Success");
                return;
            }
            DataTable dt = ds.Tables[0];

            int i = 0;
            ProductCon = dt.Rows.Count - 1;
            foreach (DataRow item in dt.Rows)
            {
                if (i <= 0)
                {
                    i++;
                    continue;
                }
                i++;
                string productid = item["id"].ToString();
                try
                {
                    #region 产品Model
                    //组合EnProduct----Model
                    string shottitle = "";
                    string tcolor = "";
                    string sku = item["sku"].ToString();
                    if (string.IsNullOrEmpty(sku))
                    {
                        EorrStr += "," + productid;
                        EorrCon++;
                        continue;
                    }

                    EnProduct skuproduct = ECProduct.GetProductInfo(" where sku='" + sku + "'");
                    if (skuproduct != null)
                    {
                        ProductOldStr += "," + productid;
                        ProductOldCon++;
                        continue;
                    }

                    string letter = "";
                    int categoryid = 0;//TODO
                    string categorytitle = item["categorytitle"].ToString();

                    string subcategoryidlist = "";
                    string subcategorytitlelist = "";
                    int brandid = int.Parse(ddlbrand.SelectedValue);
                    string brandtitle = ddlbrand.SelectedItem.Text;
                    int brandsid = int.Parse(Request.Params["ddlbrands"].ToString());
                    string brandstitle = ddlbrands.SelectedItem.Text;

                    string materialname = "";
                    string materialvalue = "";
                    if (string.IsNullOrEmpty(item["materialname"].ToString()))
                    {
                        materialname = ddlmaterial.SelectedItem.Text;
                        materialvalue = ddlmaterial.SelectedValue;
                    }
                    else
                    {
                        materialname = item["materialname"].ToString();
                        bool isMa = true;
                        for (int ddlMa = 0; ddlMa < ddlmaterial.Items.Count; ddlMa++)
                        {
                            if (materialname == ddlmaterial.Items[ddlMa].Text)
                            {
                                materialvalue = ddlmaterial.Items[ddlMa].Value;
                                isMa = false;
                                break;
                            }
                        }
                        if (isMa)
                        {
                            materialname = ddlmaterial.SelectedItem.Text;
                            materialvalue = ddlmaterial.SelectedValue;
                        }
                    }

                    string stylevalue = ""; //ddlstyle.SelectedValue;
                    string stylename = ""; //ddlstyle.SelectedItem.Text;
                    if (string.IsNullOrEmpty(item["stylename"].ToString()))
                    {
                        stylename = ddlstyle.SelectedItem.Text;
                        stylevalue = ddlstyle.SelectedValue;
                    }
                    else
                    {
                        stylename = item["stylename"].ToString();
                        bool isMa = true;
                        for (int ddlMa = 0; ddlMa < ddlstyle.Items.Count; ddlMa++)
                        {
                            if (materialname == ddlstyle.Items[ddlMa].Text)
                            {
                                stylevalue = ddlstyle.Items[ddlMa].Value;
                                isMa = false;
                                break;
                            }
                        }
                        if (isMa)
                        {
                            stylename = ddlstyle.SelectedItem.Text;
                            stylevalue = ddlstyle.SelectedValue;
                        }
                    }
                    string colorvalue = "";// ddlcolor.SelectedValue;
                    string colorname = "";// ddlcolor.SelectedItem.Text;
                    if (string.IsNullOrEmpty(item["colorname"].ToString()))
                    {
                        colorname = ddlcolor.SelectedItem.Text;
                        colorvalue = ddlcolor.SelectedValue;
                    }
                    else
                    {
                        colorname = item["colorname"].ToString();
                        bool isMa = true;
                        for (int ddlMa = 0; ddlMa < ddlcolor.Items.Count; ddlMa++)
                        {
                            if (colorname == ddlcolor.Items[ddlMa].Text)
                            {
                                colorvalue = ddlcolor.Items[ddlMa].Value;
                                isMa = false;
                                break;
                            }
                        }
                        if (isMa)
                        {
                            colorname = ddlcolor.SelectedItem.Text;
                            colorvalue = ddlcolor.SelectedValue;
                        }
                    }
                    string unit = item["unit"].ToString();
                    string localitycode = "";
                    string shipcode = "";
                    string descript = "";
                    int customize = Convert.ToInt32(item["customize"].ToString());
                    string surface = "";
                    string logo = "";
                    string thumb = "";
                    string bannel = "";
                    string desimage = "";
                    string tob2c = "";
                    int comopanyid = 0;
                    string companyname = "";
                    int lastedid = 0;
                    DateTime lastedittime = DateTime.Now;
                    bool assemble = item["assemble"].ToString() == "1";
                    //品牌+类型+型号+风格
                    string title = brandtitle + " " + categorytitle + " " + sku + " " + materialname;

                    EnProduct model = new EnProduct();
                    model.no = "";
                    model.hits = 0;
                    model.sort = 0;
                    model.createmid = memberInfo.id;
                    model.attribute = "";
                    model.auditstatus = 0;
                    model.linestatus = 0;
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
                    model.descript = descript;
                    model.tob2c = tob2c;
                    model.companyid = comopanyid;
                    model.companyname = companyname;
                    model.lastedid = lastedid;
                    model.lastedittime = lastedittime;
                    model.assemble = assemble;
                    #endregion

                    int aid = ECProduct.EditProduct(model);
                    if (aid > 0)
                    {
                        try
                        {
                            #region 处理规格
                            DataTable dt2 = ds2.Tables[0];
                            if (ds2 == null || ds2.Tables[0] == null)
                            {
                                break;
                            }
                            int j = 0;
                            foreach (DataRow item2 in dt2.Rows)
                            {
                                if (j <= 0)
                                {
                                    j++;
                                    continue;
                                }
                                j++;
                                if (item2["productid"].ToString() != productid)
                                {
                                    continue;
                                }

                                EnProductAttribute m = new EnProductAttribute();
                                m.productid = aid;
                                m.productno = "";
                                m.productsku = model.sku;
                                m.typename = item2["typename"].ToString();

                                List<EnConfig> list = new List<EnConfig>();

                                list = ECConfig.GetConfigList(" type=" + (int)EnumConfigByProduct.产品类型 + "  and title='" + m.typename + "'");
                                if (list.Count > 0)
                                { m.typevalue = list[0].id.ToString(); }
                                else
                                { m.typevalue = "0"; }

                                m.productstyle = "";
                                m.productmaterial = item2["productmaterial"].ToString();
                                m.productcolortitle = item2["productcolortitle"].ToString();
                                m.productcolorvalue = item2["productcolorvalue"].ToString();
                                m.productwidth = TypeConverter.StrToDeimal(item2["productwidth"].ToString());
                                m.productheight = TypeConverter.StrToDeimal(item2["productheight"].ToString());
                                m.productlength = TypeConverter.StrToDeimal(item2["productlength"].ToString());
                                m.productcbm = TypeConverter.StrToDeimal(item2["productcbm"].ToString());
                                m.buyprice = 0;
                                m.markprice = TypeConverter.StrToDeimal(item2["markprice"].ToString());
                                m.saleprice = 0;
                                m.otherinfo = "";
                                m.storage = 0;
                                m.sort = 0;
                                m.isdefault = 0;
                                ECProductAttribute.EditProductAttribute(m);
                            }

                            #endregion
                        }
                        catch
                        {
                            ECProduct.DeleteProduct(aid);
                            EorrStr += "," + productid;
                            EorrCon++;
                            continue;
                        }

                        #region 处理内容
                        string m101 = item["m101"].ToString();
                        string m102 = item["m102"].ToString();
                        string m103 = item["m103"].ToString();
                        string m104 = item["m104"].ToString();
                        string m105 = item["m105"].ToString();

                        List<EnProductCon> conlist = new List<EnProductCon>();

                        conlist = ECProduct.GetProductConList(" productid=" + model.id);
                        EnProductCon m1 = new EnProductCon();
                        m1.productid = aid;
                        m1.contype = (int)EnumProductConType.风格特点;
                        m1.con = m101;

                        if (conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).Count() > 0)
                        {
                            m1.id = conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).ToList()[0].id;
                            ECProduct.EditProductCon(m1);
                        }
                        else if (m101 != "")
                        {
                            ECProduct.EditProductCon(m1);
                        }

                        EnProductCon m2 = new EnProductCon();
                        m2.productid = aid;
                        m2.contype = (int)EnumProductConType.产品细节;
                        m2.con = m102;
                        if (conlist.Where(x => x.contype == (int)EnumProductConType.产品细节).Count() > 0)
                        {
                            m2.id = conlist.Where(x => x.contype == (int)EnumProductConType.产品细节).ToList()[0].id;
                            ECProduct.EditProductCon(m2);
                        }
                        else if (m102 != "")
                        {
                            ECProduct.EditProductCon(m2);
                        }

                        EnProductCon m3 = new EnProductCon();
                        m3.productid = aid;
                        m3.contype = (int)EnumProductConType.材质工艺;
                        m3.con = m103;
                        if (conlist.Where(x => x.contype == (int)EnumProductConType.材质工艺).Count() > 0)
                        {
                            m3.id = conlist.Where(x => x.contype == (int)EnumProductConType.材质工艺).ToList()[0].id;
                            ECProduct.EditProductCon(m3);
                        }
                        else if (m103 != "")
                        {
                            ECProduct.EditProductCon(m3);
                        }


                        EnProductCon m4 = new EnProductCon();
                        m4.productid = aid;
                        m4.contype = (int)EnumProductConType.保养说明;
                        m4.con = m104;
                        if (conlist.Where(x => x.contype == (int)EnumProductConType.保养说明).Count() > 0)
                        {
                            m4.id = conlist.Where(x => x.contype == (int)EnumProductConType.保养说明).ToList()[0].id;
                            ECProduct.EditProductCon(m4);
                        }
                        else if (m104 != "")
                        {
                            ECProduct.EditProductCon(m4);
                        }


                        EnProductCon m5 = new EnProductCon();
                        m5.productid = aid;
                        m5.contype = (int)EnumProductConType.配送周期;
                        m5.con = m105;
                        if (conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).Count() > 0)
                        {
                            m5.id = conlist.Where(x => x.contype == (int)EnumProductConType.配送周期).ToList()[0].id;
                            ECProduct.EditProductCon(m5);
                        }
                        else if (m105 != "")
                        {
                            ECProduct.EditProductCon(m5);
                        }


                        #endregion

                    }
                }
                catch
                {
                    EorrStr += "," + productid;
                    EorrCon++;
                    continue;
                }
            }

            LbMsg.Text = "上传完成，成功个数：" + (ProductCon - EorrCon - ProductOldCon) + "，已经存在的产品：" + ProductOldCon + ",存在的商品编号：" + ProductOldStr + "，失败个数：" + EorrCon + "，失败编号：" + EorrStr;

        }
    }
}