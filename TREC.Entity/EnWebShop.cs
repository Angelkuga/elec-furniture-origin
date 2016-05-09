﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TREC.Entity
{
    public class EnWebShop
    {
        #region Model
        private string _brandxml;
        private int _productcount;
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
        private int? _marketid;
        private string _marketname;
        private int? _cid;
        private int? _ctype;
        private int? _createmid;
        private int? _lastedid;
        private DateTime _lastedittime;
        private int _auditstatus;
        private int _linestatus;
        private string _qq;
        /// <summary>
        /// 客服QQ
        /// </summary>
        public string qq
        {
            set { _qq = value; }
            get { return _qq; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string brandxml
        {
            set { _brandxml = value; }
            get { return _brandxml; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        public int productcount
        {
            set { _productcount = value; }
            get { return _productcount; }
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
        public int? marketid
        {
            set { _marketid = value; }
            get { return _marketid; }
        }
        public string marketname
        {
            set { _marketname = value; }
            get { return _marketname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cid
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ctype
        {
            set { _ctype = value; }
            get { return _ctype; }
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
        #endregion Model

        public string BrandName
        {
            get
            {
                if (ShopBrandList.Count > 0)
                {
                    string t = "";
                    foreach (ShopBrand m in ShopBrandList)
                    {
                        t += m.title + ",";
                    }
                    return t;
                }
                return "";
            }
        }
        public string StyleName
        {
            get
            {
                if (ShopBrandList.Count > 0)
                {
                    string t = "";
                    foreach (ShopBrand m in ShopBrandList)
                    {
                        if (!t.Contains(m.stylevalue + ","))
                        {
                            t += m.stylevalue + ",";
                        }
                    }
                    return t;
                }
                return "";
            }
        }
        public string SpreadName
        {
            get
            {
                if (ShopBrandList.Count > 0)
                {
                    string t = "";
                    foreach (ShopBrand m in ShopBrandList)
                    {
                        if (!t.Contains(m.spreadvalue + ","))
                        {
                            t += m.spreadvalue + ",";
                        }
                    }
                    return t;
                }
                return "";
            }
        }
        public string BrandIdList
        {
            get
            {
                if (ShopBrandList.Count > 0)
                {
                    string t = "";
                    foreach (ShopBrand m in ShopBrandList)
                    {
                        if (!t.Contains(m.id + ","))
                        {
                            t += m.id + ",";
                        }
                    }
                    t = t.EndsWith(",") ? t.Substring(0, t.Length - 1) : t;
                    t = t.StartsWith(",") ? t.Substring(1, t.Length - 1) : t;
                    return t;
                }
                return "0";
            }

        }



        public ShopBrand ShopBrandInfo
        {
            get
            {
                if (ShopBrandList.Count > 0)
                {
                    return ShopBrandList[0];
                }
                return new ShopBrand();
            }
        }
        public List<ShopBrand> ShopBrandList
        {
            get
            {
                if (!string.IsNullOrEmpty(brandxml))
                {
                    List<ShopBrand> list = new List<ShopBrand>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(brandxml, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            ShopBrand m = new ShopBrand();
                            GroupCollection gc = match.Groups;
                            list.Add((ShopBrand)TRECommon.SerializationHelper.DeSerialize(typeof(ShopBrand), "<ShopBrand>" + gc["g"].Value + "</ShopBrand>"));
                        }
                    }
                    return list;
                }
                return new List<ShopBrand>();
            }
        }
    }

    [Serializable]
    public class ShopBrand
    {
        public string id { get; set; }
        public string title { get; set; }
        public string thumb { get; set; }
        public string map { get; set; }
        public string spreadvalue { get; set; }
        public string materialvalue { get; set; }
        public string stylevalue { get; set; }
        public string companyid { get; set; }
    }
}
