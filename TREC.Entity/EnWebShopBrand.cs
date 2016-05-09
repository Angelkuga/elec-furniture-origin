using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace TREC.Entity
{
    public class EnWebShopBrand
    {
        #region Model
        private string _shopxml;
        private string _promotionxml;
        private int _id;
        private int? _companyid;
        private string _title;
        private string _letter;
        private int? _groupid;
        private string _attribute;
        private string _productcategory;
        private string _homepage;
        private int? _productcount;
        private string _spread;
        private string _material;
        private string _style;
        private string _color;
        private string _surface;
        private string _logo;
        private string _thumb;
        private string _bannel;
        private string _desimage;
        private string _descript;
        private string _keywords;
        private string _template;
        private int? _hits;
        private int? _sort;
        private int? _createmid;
        private int? _lasteditid;
        private DateTime _lastedittime;
        private int _auditstatus;
        private int _linestatus;
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
        public string Promotionxml
        {
            set { _promotionxml = value; }
            get { return _promotionxml; }
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
        public int? companyid
        {
            set { _companyid = value; }
            get { return _companyid; }
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
        public string letter
        {
            set { _letter = value; }
            get { return _letter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? groupid
        {
            set { _groupid = value; }
            get { return _groupid; }
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
        public string productcategory
        {
            set { _productcategory = value; }
            get { return _productcategory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string homepage
        {
            set { _homepage = value; }
            get { return _homepage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? productcount
        {
            set { _productcount = value; }
            get { return _productcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spread
        {
            set { _spread = value; }
            get { return _spread; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string material
        {
            set { _material = value; }
            get { return _material; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string style
        {
            set { _style = value; }
            get { return _style; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string color
        {
            set { _color = value; }
            get { return _color; }
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
        public string keywords
        {
            set { _keywords = value; }
            get { return _keywords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string template
        {
            set { _template = value; }
            get { return _template; }
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
        public int? createmid
        {
            set { _createmid = value; }
            get { return _createmid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? lasteditid
        {
            set { _lasteditid = value; }
            get { return _lasteditid; }
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
        #endregion Model



        public BrandShop BrandShopInfo
        {
            get
            {
                if (BrandShopList.Count > 0)
                {
                    return BrandShopList[0];
                }
                return new BrandShop();
            }
        }
        public List<BrandShop> BrandShopList
        {
            get
            {
                if (!string.IsNullOrEmpty(shopxml))
                {
                    List<BrandShop> list = new List<BrandShop>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(shopxml, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            BrandShop m = new BrandShop();
                            GroupCollection gc = match.Groups;
                            list.Add((BrandShop)TRECommon.SerializationHelper.DeSerialize(typeof(BrandShop), "<BrandShop>" + gc["g"].Value + "</BrandShop>"));
                        }
                    }
                    return list;
                }
                return new List<BrandShop>();
            }
        }


        public BrnadPomotion BrandPomotionInfo
        {
            get
            {
                if (BrandPomotionList.Count > 0)
                {
                    return BrandPomotionList[0];
                }
                return new BrnadPomotion();
            }
        }
        public List<BrnadPomotion> BrandPomotionList
        {
            get
            {
                if (!string.IsNullOrEmpty(Promotionxml))
                {
                    List<BrnadPomotion> list = new List<BrnadPomotion>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(Promotionxml, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            BrnadPomotion m = new BrnadPomotion();
                            GroupCollection gc = match.Groups;
                            list.Add((BrnadPomotion)TRECommon.SerializationHelper.DeSerialize(typeof(BrnadPomotion), "<BrnadPomotion>" + gc["g"].Value + "</BrnadPomotion>"));
                        }
                    }
                    return list;
                }
                return new List<BrnadPomotion>();
            }
        }

        public class BrandShop
        {
            public string id { get; set; }
            public string title { get; set; }
            public string thumb { get; set; }
            public string map { get; set; }
            public string linkman { get; set; }
            public string areacode { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
        }

        public class BrnadPomotion
        {
             
            public string id { get; set; }
            public string title { get; set; }
            public string htmltitle { get; set; }
            public string thumb { get; set; }
            public string ptype{ get; set; }
            public string startdatetime{ get; set; }
            public string enddatetime{ get; set; }
            public string areacode{ get; set; }
            public string address { get; set; }

        }
    }
}
