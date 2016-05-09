using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TREC.Entity
{
    [Serializable]
    public class EnWebProduct
    {
        #region Model
        private string _shopxml;
        private string _attributexml;
        private string _shopprice;
        private string _spreadname;
        private int _id;
        private string _attribute;
        private string _title;
        private string _shottitle;
        private string _tcolor;
        private string _sku;
        private string _no;
        private string _letter;
        private int _categoryid;
        private string _categorytitle;
        private string _subcategoryidlist;
        private string _subcategorytitlelist;
        private int _brandid;
        private string _brandtitle;
        private string _brandlogo;
        private int? _brandsid;
        private string _brandstitle;
        private string _stylevalue;
        private string _stylename;
        private string _colorname;
        private string _colorvalue;
        private string _materialvalue;
        private string _materialname;
        private string _unit;
        private string _localitycode;
        private string _shipcode;
        private int? _customize;
        private string _surface;
        private string _logo;
        private string _thumb;
        private string _bannel;
        private string _desimage;
        private string _descript;
        private string _tob2c;
        private int? _companyid;
        private string _companyname;
        private int _createmid;
        private int? _hits;
        private int? _sort;
        private int? _lastedid;
        private DateTime _lastedittime;
        private int _auditstatus;
        private int _linestatus;
        private int _fid = 0;

        /// <summary>
        /// 产品类型，1为普通产品，2为套组合产品，3为夸系列组合产品
        /// shen 2015-02-11
        /// </summary>
        public int ptype { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string shopxml
        {
            set { _shopxml = value; }
            get { return _shopxml; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attributexml
        {
            set { _attributexml = value; }
            get { return _attributexml; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shopprice
        {
            set { _shopprice = value; }
            get { return _shopprice; }
        }
        public string spreadname
        {
            set { _spreadname = value; }
            get { return _spreadname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attribute
        {
            set { _attribute = value; }
            get { return _attribute; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shottitle
        {
            set { _shottitle = value; }
            get { return _shottitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tcolor
        {
            set { _tcolor = value; }
            get { return _tcolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sku
        {
            set { _sku = value; }
            get { return _sku; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string no
        {
            set { _no = value; }
            get { return _no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string letter
        {
            set { _letter = value; }
            get { return _letter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int categoryid
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string categorytitle
        {
            set { _categorytitle = value; }
            get { return _categorytitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string subcategoryidlist
        {
            set { _subcategoryidlist = value; }
            get { return _subcategoryidlist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string subcategorytitlelist
        {
            set { _subcategorytitlelist = value; }
            get { return _subcategorytitlelist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int brandid
        {
            set { _brandid = value; }
            get { return _brandid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brandtitle
        {
            set { _brandtitle = value; }
            get { return _brandtitle; }
        }
        public string brandlogo
        {
            set { _brandlogo = value; }
            get { return _brandlogo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? brandsid
        {
            set { _brandsid = value; }
            get { return _brandsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brandstitle
        {
            set { _brandstitle = value; }
            get { return _brandstitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stylevalue
        {
            set { _stylevalue = value; }
            get { return _stylevalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stylename
        {
            set { _stylename = value; }
            get { return _stylename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string colorname
        {
            set { _colorname = value; }
            get { return _colorname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string colorvalue
        {
            set { _colorvalue = value; }
            get { return _colorvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string materialvalue
        {
            set { _materialvalue = value; }
            get { return _materialvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string materialname
        {
            set { _materialname = value; }
            get { return _materialname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string localitycode
        {
            set { _localitycode = value; }
            get { return _localitycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shipcode
        {
            set { _shipcode = value; }
            get { return _shipcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? customize
        {
            set { _customize = value; }
            get { return _customize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string surface
        {
            set { _surface = value; }
            get { return _surface; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string logo
        {
            set { _logo = value; }
            get { return _logo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string thumb
        {
            set { _thumb = value; }
            get { return _thumb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bannel
        {
            set { _bannel = value; }
            get { return _bannel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string desimage
        {
            set { _desimage = value; }
            get { return _desimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string descript
        {
            set { _descript = value; }
            get { return _descript; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tob2c
        {
            set { _tob2c = value; }
            get { return _tob2c; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? companyid
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string companyname
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int createmid
        {
            set { _createmid = value; }
            get { return _createmid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? lastedid
        {
            set { _lastedid = value; }
            get { return _lastedid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime lastedittime
        {
            set { _lastedittime = value; }
            get { return _lastedittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int auditstatus
        {
            set { _auditstatus = value; }
            get { return _auditstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int linestatus
        {
            set { _linestatus = value; }
            get { return _linestatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FID
        {
            set { _fid = value; }
            get { return _fid; }
        }
        #endregion Model

        public string shopMapapi = "";
        public string HtmlProductName
        {
            get
            {
                return brandtitle + " " + categorytitle + " " + sku + " " + materialname;
            }
        }
        public ProductShop ProductShopInfo
        {
            get
            {
                if (ProductShopList.Count > 0)
                {
                    return ProductShopList[0];
                }
                return new ProductShop();
            }
        }
        /// <summary>
        /// 卖场下的店铺
        /// </summary>
        public List<ProductShop> ProductShopInfoBymarket
        {
            get
            {
                if (ProductShopList.Count > 0)
                {
                  
                    return ProductShopList;
                }
                return new List<ProductShop>();
            }
        }


      
        /// <summary>
        /// 新的产品推荐店铺排序
        /// </summary>
        public ProductShop ProductShopInfoNew
        {
            get
            {
                List<ProductShop> lst = new List<ProductShop>();
                //lst = ProductShopList.FindAll(delegate(ProductShop s) { return s.ispay == "1"; });
                lst = ProductShopList.FindAll(delegate(ProductShop s) { return s.id != ""; });
                if (lst.Count > 0)
                {
                    if (lst.Count == 1)
                    {
                        return lst[0];
                    }
                    else
                    {
                        Random rd = new Random();
                        int h = rd.Next(0, lst.Count);
                        return lst[h];
                    }
                }
                return new ProductShop();
            }
        }

        public List<ProductShop> ProductShopList
        {
            get
            {
                if (!string.IsNullOrEmpty(shopxml))
                {
                    List<ProductShop> list = new List<ProductShop>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(shopxml, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            ProductShop m = new ProductShop();
                            GroupCollection gc = match.Groups;
                            list.Add((ProductShop)TRECommon.SerializationHelper.DeSerialize(typeof(ProductShop), "<ProductShop>" + gc["g"].Value + "</ProductShop>"));
                            if (!string.IsNullOrEmpty(m.map)) { shopMapapi += m.map + "|"; }
                        }
                    }
                    return list;
                }
                return new List<ProductShop>();
            }
        }

        public List<ProductShop> ProductShopListNew
        {
            get
            {
                if (!string.IsNullOrEmpty(shopxml))
                {
                    List<ProductShop> list = new List<ProductShop>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(shopxml, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            ProductShop m = new ProductShop();
                            GroupCollection gc = match.Groups;
                            list.Add((ProductShop)TRECommon.SerializationHelper.DeSerialize(typeof(ProductShop), "<ProductShop>" + gc["g"].Value + "</ProductShop>"));
                            if (!string.IsNullOrEmpty(m.map)) { shopMapapi += m.map + "|"; }
                        }
                    }
                    return list.FindAll(delegate(ProductShop s) { return s.ispay == "1"; });
                }
                return new List<ProductShop>();
            }
        }
        public ProductAttribute ProductAttributeInfo
        {
            get
            {
                if (ProductAttributeList.Count > 0)
                {
                    return ProductAttributeList[0];
                }
                return new ProductAttribute();
            }
        }
        public List<ProductAttribute> ProductAttributeList
        {
            get
            {
                if (!string.IsNullOrEmpty(attributexml))
                {
                    List<ProductAttribute> list = new List<ProductAttribute>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(attributexml, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            ProductAttribute m = new ProductAttribute();
                            GroupCollection gc = match.Groups;
                            list.Add((ProductAttribute)TRECommon.SerializationHelper.DeSerialize(typeof(ProductAttribute), "<ProductAttribute>" + gc["g"].Value + "</ProductAttribute>"));
                        }
                    }
                    return list;
                }
                return new List<ProductAttribute>();
            }
        }
        public ProducShopPrice ProducShopPriceInfo
        {
            get
            {
                if (ProducShopPriceList.Count > 0)
                {
                    return ProducShopPriceList[0];
                }
                return new ProducShopPrice();
            }
        }
        public List<ProducShopPrice> ProducShopPriceList
        {
            get
            {
                if (!string.IsNullOrEmpty(shopprice))
                {
                    List<ProducShopPrice> list = new List<ProducShopPrice>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(shopprice, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            ProducShopPrice m = new ProducShopPrice();
                            GroupCollection gc = match.Groups;
                            list.Add((ProducShopPrice)TRECommon.SerializationHelper.DeSerialize(typeof(ProducShopPrice), "<ProducShopPrice>" + gc["g"].Value + "</ProducShopPrice>"));
                        }
                    }
                    return list;
                }
                return new List<ProducShopPrice>();
            }
        }
        public Hashtable HtMaterial
        {
            get
            {
                Hashtable ht = new Hashtable();
                if (ProductAttributeList != null)
                {

                    foreach (ProductAttribute a in ProductAttributeList)
                    {
                        if (!ht.ContainsKey(a.productmaterial))
                        {
                            ht.Add(a.productmaterial, a.productmaterial);
                        }
                    }
                }

                return ht;
            }
        }

        public Hashtable HtSize
        {
            get
            {
                Hashtable ht = new Hashtable();
                if (ProductAttributeList != null)
                {

                    foreach (ProductAttribute a in ProductAttributeList)
                    {
                        if (a.productlength != "0" && a.productlength != "0" && a.productlength != "0")
                        {
                            if (!ht.ContainsKey(a.productlength + "*" + a.productwidth + "*" + a.productheight))
                            {
                                ht.Add(a.productlength + "*" + a.productwidth + "*" + a.productheight, a.productlength + "*" + a.productwidth + "*" + a.productheight);
                            }
                        }
                    }
                }

                return ht;
            }
        }

    }

    [Serializable]
    public class ProductShop
    {
        public string id { get; set; }
        public string title { get; set; }
        public string thumb { get; set; }
        public string map { get; set; }
        public string linkman { get; set; }
        public string phone { get; set; }
        public string areacode { get; set; }
        public string address { get; set; }
        public string qq { get; set; }
        public string ispay { get; set; }
        public string price { get; set; }
        public string dollprice { get; set; }
        public string marketid { get; set; }
    }
    [Serializable]
    public class ProductAttribute
    {
        public string id { get; set; }
        public string typevalue { get; set; }
        public string typename { get; set; }
        public string productstyle { get; set; }
        public string productmaterial { get; set; }
        public string productwidth { get; set; }
        public string productlength { get; set; }
        public string productheight { get; set; }
        public string productcbm { get; set; }
        public string productcolorimg { get; set; }
        public string productcolortitle { get; set; }
        public string productcolorvalue { get; set; }
        public string buyprice { get; set; }
        public string markprice { get; set; }
        public string saleprice { get; set; }
        public string isdefault { get; set; }
        public string sort { get; set; }

    }
    [Serializable]
    public class ProducShopPrice
    {
        public string shopid { get; set; }
        public string productid { get; set; }
        public string attributeid { get; set; }
        public string markprice { get; set; }
        public string saleprice { get; set; }
        public string buyprice { get; set; }

    }



    /// <summary>
    /// shen 2015-02-13
    /// 产品小类属性集合
    /// </summary>
    [Serializable]
    public class producttype
    {
        /// <summary>
        /// 2:套组合产品
        /// </summary>
        public int ptype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int parentid { get; set; }
        /// <summary>
        /// 小类id
        /// </summary>
        public int tpid { get; set; }
        /// <summary>
        /// 小类名
        /// </summary>
        public string tptitle { get; set; }
        /// <summary>
        /// 类型详细名称
        /// </summary>
        public string configtitle { get; set; }
        /// <summary>
        /// 类型值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 类型名
        /// </summary>
        public string configtypetitle { get; set; }
        /// <summary>
        /// 类型名对应的值
        /// </summary>
        public string configtype { get; set; }
        /// <summary>
        /// 类型表id
        /// </summary>
        public string configtypeid { get; set; }

         /// <summary>
        /// 产品类型表大类id
        /// </summary>
        public int tp2id { get; set; }
           /// <summary>
        /// 产品类型表大类名
        /// </summary>
        public string tp2title { get; set; }
        /// <summary>
        /// t_config.id
        /// </summary>
        public string configid { get; set; }
        /// <summary>
        /// t_config.ishow是否显示在导航菜单上
        /// </summary>
        public int configshow { get; set; }
        /// <summary>
        /// t_productcategory.ishow是否显示在导航菜单上
        /// </summary>
        public int tpshow { get; set; }
        /// <summary>
        /// 小类
        /// </summary>
        public List<producttype> listxl = new List<producttype>();
        /// <summary>
        /// 小类对应的属性
        /// </summary>
        public List<producttype> listattr = new List<producttype>();


        public List<tconfigtype> listtconfigtype = new List<tconfigtype>();

    }
    [Serializable]
    public class tconfigtype { 
        public int id{get;set;}
        /// <summary>
        /// 类型分类
        /// </summary>
        public string cttitle{get;set;}

        public string cttype{get;set;}

        public string cid{get;set;}
        /// <summary>
        /// 类型名
        /// </summary>
        public string ctitle{get;set;}
        /// <summary>
        /// ishow是否显示在导航菜单上
        /// </summary>
        public int tpshow { get; set; }
    }
}
