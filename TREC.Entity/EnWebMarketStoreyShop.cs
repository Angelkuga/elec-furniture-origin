using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace TREC.Entity
{
    [Serializable]
    public class EnWebMarketStoreyShop
    {
        #region Model
        private int _id;
        private int _marketid;
        private string _markettitle;
        private int _storeyid;
        private string _storeytitle;
        private int _shopid;
        private string _shoptitle;
        private string _brandidlist;
        private string _brandtitlelist;
        private int? _istop;
        private int? _isrecommend;
        private int? _lev;
        private int? _sort;
        private int? _lastedid;
        private DateTime _lastedittime;
        private string _shopthumb;
        private string _shopmap;
        private string _shoplinkman;
        private string _shopphone;
        private string _shopareacode;
        private string _shopaddress;
        private string _brandxml;
        private string _qq;
        private DateTime _createtime;
        
        /// <summary>
        /// 客服QQ
        /// </summary>
        public string qq {
            set { _qq = value; }
            get { return _qq; }
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
        public int marketid
        {
            set { _marketid = value; }
            get { return _marketid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string markettitle
        {
            set { _markettitle = value; }
            get { return _markettitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int storeyid
        {
            set { _storeyid = value; }
            get { return _storeyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string storeytitle
        {
            set { _storeytitle = value; }
            get { return _storeytitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int shopid
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shoptitle
        {
            set { _shoptitle = value; }
            get { return _shoptitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brandidlist
        {
            set { _brandidlist = value; }
            get { return _brandidlist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brandtitlelist
        {
            set { _brandtitlelist = value; }
            get { return _brandtitlelist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? istop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isrecommend
        {
            set { _isrecommend = value; }
            get { return _isrecommend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? lev
        {
            set { _lev = value; }
            get { return _lev; }
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
        public DateTime createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shopthumb
        {
            set { _shopthumb = value; }
            get { return _shopthumb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shopmap
        {
            set { _shopmap = value; }
            get { return _shopmap; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shoplinkman
        {
            set { _shoplinkman = value; }
            get { return _shoplinkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shopphone
        {
            set { _shopphone = value; }
            get
            {
                if (string.IsNullOrEmpty(_shopphone))
                    return "4006066818";
                else
                {
                    return _shopphone;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shopareacode
        {
            set { _shopareacode = value; }
            get { return _shopareacode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shopaddress
        {
            set { _shopaddress = value; }
            get { return _shopaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brandxml
        {
            set { _brandxml = value; }
            get { return _brandxml; }
        }
        #endregion Model


        public string BrandName
        {
            get
            {
                if (MarketStoreyShopBrandList.Count > 0)
                {
                    string t = "";
                    foreach (MarketStoreyShopBrand m in MarketStoreyShopBrandList)
                    {
                        t += m.title + ",";
                    }
                    return t;
                }
                return "";
            }
        }
        public MarketStoreyShopBrand BrandInfo
        {
            get
            {
                if (MarketStoreyShopBrandList.Count > 0)
                {
                    return MarketStoreyShopBrandList[0];
                }
                return new MarketStoreyShopBrand();
            }
        }
        public string StyleName
        {
            get
            {
                if (MarketStoreyShopBrandList.Count > 0)
                {
                    string t = "";
                    foreach (MarketStoreyShopBrand m in MarketStoreyShopBrandList)
                    {
                        if (m.style != null && m.style != "" && !t.Contains(m.style + ","))
                        {
                            if (t.Length > 0)
                            {
                                t += ",";
                            }
                            t += m.style;
                        }
                    }
                    return t;
                }
                return "";
            }
        }


        public List<MarketStoreyShopBrand> MarketStoreyShopBrandList
        {
            get
            {
                if (!string.IsNullOrEmpty(brandxml))
                {
                    List<MarketStoreyShopBrand> list = new List<MarketStoreyShopBrand>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(brandxml, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            MarketStoreyShopBrand m = new MarketStoreyShopBrand();
                            GroupCollection gc = match.Groups;
                            list.Add((MarketStoreyShopBrand)TRECommon.SerializationHelper.DeSerialize(typeof(MarketStoreyShopBrand), "<MarketStoreyShopBrand>" + gc["g"].Value + "</MarketStoreyShopBrand>"));
                        }
                    }
                    return list;
                }
                return new List<MarketStoreyShopBrand>();
            }
        }


        [Serializable]
        public class MarketStoreyShopBrand
        {
            public string id { get; set; }
            public string title { get; set; }
            public string logo { get; set; }
            public string thumb { get; set; }
            public string style { get; set; }
            public string companyid { get; set; }
            public string letter { get; set; }
            public BrandsTypes[] brands { get; set; }
            public class BrandsTypes
            {
                public string brandsmaterialvalue { get; set; }
                public string brandsmaterialtitle { get; set; }
                public string brandsstylevalue { get; set; }
                public string brandsstyletitle { get; set; }
            }
        }
    }
}
