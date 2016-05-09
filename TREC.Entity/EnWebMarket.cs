using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace TREC.Entity
{
    [Serializable]
    public class EnWebMarket
    {
        #region Model
        private int? _shopcount;
        private string _shopxml;
        private string _brandxml;
        private string _marketstoreyxml;
        private int _id;
        private int _mid;
        private string _title;
        private string _letter;
        private int _groupid;
        private string _attribute;
        private string _industry;
        private string _productcategory;
        private int? _vip;
        private string _areacode;
        private string _address;
        private string _mapapi;
        private int? _staffsize;
        private string _regyear;
        private string _regcity;
        private string _buy;
        private string _sell;
        private decimal? _cbm;
        private string _lphone;
        private string _zphone;
        private string _busroute;
        private string _hours;
        private string _linkman;
        private string _phone;
        private string _mphone;
        private string _fax;
        private string _email;
        private string _postcode;
        private string _homepage;
        private string _domain;
        private string _domainip;
        private string _icp;
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
        private int? _lastedid;
        private DateTime _lastedittime;
        private int _auditstatus;
        private int _linestatus;
        /// <summary>
        /// 
        /// </summary>
        public int? shopcount
        {
            set { _shopcount = value; }
            get { return _shopcount; }
        }
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
        public string brandxml
        {
            set { _brandxml = value; }
            get { return _brandxml; }
        }
        public string marketstoreyxml
        {
            set { _marketstoreyxml = value; }
            get { return _marketstoreyxml; }
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
        public int mid
        {
            set { _mid = value; }
            get { return _mid; }
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
        public int groupid
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
        public string industry
        {
            set { _industry = value; }
            get { return _industry; }
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
        public int? vip
        {
            set { _vip = value; }
            get { return _vip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string areacode
        {
            set { _areacode = value; }
            get { return _areacode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mapapi
        {
            set { _mapapi = value; }
            get { return _mapapi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? staffsize
        {
            set { _staffsize = value; }
            get { return _staffsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string regyear
        {
            set { _regyear = value; }
            get { return _regyear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string regcity
        {
            set { _regcity = value; }
            get { return _regcity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string buy
        {
            set { _buy = value; }
            get { return _buy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sell
        {
            set { _sell = value; }
            get { return _sell; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cbm
        {
            set { _cbm = value; }
            get { return _cbm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lphone
        {
            set { _lphone = value; }
            get { return _lphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zphone
        {
            set { _zphone = value; }
            get { return _zphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string busroute
        {
            set { _busroute = value; }
            get { return _busroute; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hours
        {
            set { _hours = value; }
            get { return _hours; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string linkman
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mphone
        {
            set { _mphone = value; }
            get { return _mphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string postcode
        {
            set { _postcode = value; }
            get { return _postcode; }
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
        public string domain
        {
            set { _domain = value; }
            get { return _domain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string domainip
        {
            set { _domainip = value; }
            get { return _domainip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string icp
        {
            set { _icp = value; }
            get { return _icp; }
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
        public string MarketCliqueName { get; set; }
        public string Stitle { get; set; }
        #endregion Model

        

        public MarketShop MarketShopInfo
        {
            get
            {
                if (MarketShopList.Count > 0)
                {
                    return MarketShopList[0];
                }
                return new MarketShop();
            }
        }
        public List<MarketShop> MarketShopList
        {
            get
            {
                if (!string.IsNullOrEmpty(shopxml))
                {
                    List<MarketShop> list = new List<MarketShop>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(shopxml, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            MarketShop m = new MarketShop();
                            GroupCollection gc = match.Groups;
                            list.Add((MarketShop)TRECommon.SerializationHelper.DeSerialize(typeof(MarketShop), "<MarketShop>" + gc["g"].Value + "</MarketShop>"));
                        }
                    }
                    return list;
                }
                return new List<MarketShop>();
            }
        }

        public MarketBrand MarketBrandInfo
        {
            get
            {
                if (MarketBrandList.Count > 0)
                {
                    return MarketBrandList[0];
                }
                return new MarketBrand();
            }
        }
        public List<MarketBrand> MarketBrandList
        {
            get
            {
                if (!string.IsNullOrEmpty(brandxml))
                {
                    List<MarketBrand> list = new List<MarketBrand>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(brandxml, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            MarketBrand m = new MarketBrand();
                            GroupCollection gc = match.Groups;
                            list.Add((MarketBrand)TRECommon.SerializationHelper.DeSerialize(typeof(MarketBrand), "<MarketBrand>" + gc["g"].Value + "</MarketBrand>"));
                        }
                    }
                    return list;
                }
                return new List<MarketBrand>();
            }
        }

        
        public List<MarketStorey> MarketStoreyList
        {
            get
            {
                if (!string.IsNullOrEmpty(marketstoreyxml))
                {
                    List<MarketStorey> list = new List<MarketStorey>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(marketstoreyxml, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            MarketStorey m = new MarketStorey();
                            GroupCollection gc = match.Groups;
                            list.Add((MarketStorey)TRECommon.SerializationHelper.DeSerialize(typeof(MarketStorey), "<MarketStorey>" + gc["g"].Value + "</MarketStorey>"));
                        }
                    }
                    return list;
                }
                return new List<MarketStorey>();
            }
        }

        
        [Serializable]
        public class MarketBrand
        {
            public string id { get; set; }
            public string title { get; set; }
            public string logo { get; set; }
            public string storeytitle { get; set; }
            public string companyid { get; set; }


        }
        [Serializable]
        public class MarketShop
        {
            public string id { get; set; }
            public string title { get; set; }
            public string thumb { get; set; }
            public string map { get; set; }
            public string linkman { get; set; }
            public string phone { get; set; }
            public string areacode { get; set; }
            public string address { get; set; }
            public string brandid{ get; set; }
            public string brandletter{ get; set; }
            public string branddescript { get; set; }
            public string brandmaterial { get; set; }
            public string brandthumb { get; set; }
            public string brandlogo{ get; set; }
            public string brandtitle { get; set; }
            public string brandstylename { get; set; }
            public string marketstorey { get; set; }
            public string position { get; set; }
            public string PavilionId { get; set; }
        }

        [Serializable]
        public class MarketStorey
        {
            public string id { get; set; }
            public string title { get; set; }
            public string thumb { get; set; }
            public string number { get; set; }
            public string surface { get; set; }
            public string logo { get; set; }
            public string bannel { get; set; }
            public string desimage { get; set; }
            public string descript { get; set; }

        }
        
    }
}
