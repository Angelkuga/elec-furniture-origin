using System;
namespace TREC.Entity
{
	/// <summary>
	/// product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnProduct
	{
        public EnProduct()
		{}
        #region Model
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
        private int? _customize = 0;
        private string _surface;
        private string _logo;
        private string _thumb;
        private string _bannel;
        private string _desimage;
        private string _descript;
        private string _tob2c;
        private int? _companyid;
        private string _companyname;
        private int _createmid = 0;
        private int? _hits;
        private int? _sort;
        private int? _lastedid = 0;
        private DateTime _lastedittime;
        private DateTime _createtime;
        private string _homepageimg;
        
        private int _auditstatus;
        private int _linestatus;
        private bool _assemble;
        private int _fid = 0;
        private int _shopid = 0;
        private int _sale = 0;
        private string _shopName;
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string shopName
        {
            set { _shopName = value; }
            get { return _shopName; }
        }

        /// <summary>
        /// 销量
        /// </summary>
        public int sale
        {
            set { _sale = value; }
            get { return _sale; }
        }
        /// <summary>
        /// 店铺id
        /// </summary>
        public int shopid
        {
            set { _shopid = value; }
            get { return _shopid; }
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
        public DateTime createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
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
        /// 否需要组装
        /// </summary>
        public bool assemble
        {
            set { _assemble = value; }
            get { return _assemble; }
        }
        /// <summary>
        /// 否需要组装
        /// </summary>
        public string HomePageImg
        {
            set { _homepageimg = value; }
            get { return _homepageimg; }
        }
        /// <summary>
        /// 福家网对应ID
        /// </summary>
        public int FID
        {
            set { _fid = value; }
            get { return _fid; }
        }
        #endregion Model

        public string HtmlProductName
        {
            get
            {
                return brandstitle + " " + sku + " " + materialname;
            }
        }

	}
}

