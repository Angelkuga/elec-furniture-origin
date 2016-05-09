using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    public class EnWebCompanyBrand
    {
        #region Model
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
        private int? _createmid;
        private int? _lastedid;
        private DateTime _lastedittime;
        private int _auditstatus;
        private int _linestatus;
        private int? _brandid;
        private string _brandtitle;
        private string _brandthumb;
        private string _bthumb;
        private string _stylevalue;
        private string _materialvalue;
        private string _spreadvalue;
        private int? _brandlinestatus;
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
        /// <summary>
        /// 
        /// </summary>
        public int? brandid
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
        /// <summary>
        /// 以前的错误，应该是Brandlog
        /// </summary>
        public string brandthumb
        {
            set { _brandthumb = value; }
            get { return _brandthumb; }
        }

         /// <summary>
        /// 为了不和brandthumb起冲突，是t_brand表中的thunb
        /// </summary>
        public string bthumb
        {
            set { _bthumb = value; }
            get { return _bthumb; }
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
        public string materialvalue
        {
            set { _materialvalue = value; }
            get { return _materialvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spreadvalue
        {
            set { _spreadvalue = value; }
            get { return _spreadvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? brandlinestatus
        {
            set { _brandlinestatus = value; }
            get { return _brandlinestatus; }
        }
        #endregion Model
    }
}
