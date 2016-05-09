using System;
namespace TREC.Entity
{
	/// <summary>
	/// admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnShop
	{
        public EnShop()
		{}
        #region Model
        private int _id;
        private int _mid = 0;
        private string _title;
        private string _letter;
        private int _groupid;
        private string _attribute;
        private string _industry;
        private string _productcategory;
        private int? _vip = 0;
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
        private int? _cid = 0;
        private int? _ctype = 0;
        private int? _createmid = 0;
        private int? _lastedid = 0;
        private DateTime _lastedittime;
        private int _auditstatus;
        private int _linestatus;
        private string _qq;
        private string _position;
        private int? _isshopshare = 0;

        /// <summary>
        /// 店铺是否共享
        /// </summary>
        public int? isshopshare
        {
            set { _isshopshare = value; }
            get { return _isshopshare; }
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
        /// <summary>
        /// 客服QQ
        /// </summary>
        public string qq
        {
            set { _qq = value; }
            get { return _qq; }
        }
        public string position
        {
            set { _position = value; }
            get { return _position; }
        }

        public string ShopContact { get; set; }
        public string FirstClerkMobile { get; set; }
        public string SecondClerk { get; set; }
        public string SecondClerkMobile { get; set; }
        public int IsPay { get; set; }
        public int PavilionId { get; set; }
        #endregion Model
	}
    /// <summary>
    /// shen 2015-02-02
    /// </summary>
    [Serializable]
    public class t_shop
    {
        public t_shop()
        {

        }

        /// <summary> 
        /// 
        /// </summary>
        public const string TableName = "t_shop";

        #region

        public const string Field_id = "id";
        public const string Field_mid = "mid";
        public const string Field_title = "title";
        public const string Field_letter = "letter";
        public const string Field_groupid = "groupid";
        public const string Field_attribute = "attribute";
        public const string Field_industry = "industry";
        public const string Field_productcategory = "productcategory";
        public const string Field_vip = "vip";
        public const string Field_areacode = "areacode";
        public const string Field_address = "address";
        public const string Field_mapapi = "mapapi";
        public const string Field_staffsize = "staffsize";
        public const string Field_regyear = "regyear";
        public const string Field_regcity = "regcity";
        public const string Field_buy = "buy";
        public const string Field_sell = "sell";
        public const string Field_linkman = "linkman";
        public const string Field_phone = "phone";
        public const string Field_mphone = "mphone";
        public const string Field_fax = "fax";
        public const string Field_email = "email";
        public const string Field_postcode = "postcode";
        public const string Field_homepage = "homepage";
        public const string Field_domain = "domain";
        public const string Field_domainip = "domainip";
        public const string Field_icp = "icp";
        public const string Field_surface = "surface";
        public const string Field_logo = "logo";
        public const string Field_thumb = "thumb";
        public const string Field_bannel = "bannel";
        public const string Field_desimage = "desimage";
        public const string Field_descript = "descript";
        public const string Field_keywords = "keywords";
        public const string Field_template = "template";
        public const string Field_hits = "hits";
        public const string Field_sort = "sort";
        public const string Field_marketid = "marketid";
        public const string Field_cid = "cid";
        public const string Field_ctype = "ctype";
        public const string Field_createmid = "createmid";
        public const string Field_lastedid = "lastedid";
        public const string Field_lastedittime = "lastedittime";
        public const string Field_auditstatus = "auditstatus";
        public const string Field_linestatus = "linestatus";
        public const string Field_qq = "qq";
        public const string Field_sortstr = "sortstr";
        public const string Field_IsPay = "IsPay";
        public const string Field_SecondClerk = "SecondClerk";
        public const string Field_ShopContact = "ShopContact";
        public const string Field_FirstClerkMobile = "FirstClerkMobile";
        public const string Field_SecondClerkMobile = "SecondClerkMobile";
        public const string Field_isshopshare = "isshopshare";
        public const string Field_PavilionId = "PavilionId";
        #endregion

        #region

        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int id
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int mid
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 80</para>
        /// </summary>
        public string title
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 20</para>
        /// </summary>
        public string letter
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int groupid
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 100</para>
        /// </summary>
        public string attribute
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 50</para>
        /// </summary>
        public string industry
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 50</para>
        /// </summary>
        public string productcategory
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int vip
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public string areacode
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 60</para>
        /// </summary>
        public string address
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 80</para>
        /// </summary>
        public string mapapi
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int staffsize
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 7</para>
        /// </summary>
        public string regyear
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public string regcity
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 300</para>
        /// </summary>
        public string buy
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 300</para>
        /// </summary>
        public string sell
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 20</para>
        /// </summary>
        public string linkman
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 20</para>
        /// </summary>
        public string phone
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 20</para>
        /// </summary>
        public string mphone
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 20</para>
        /// </summary>
        public string fax
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 50</para>
        /// </summary>
        public string email
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 15</para>
        /// </summary>
        public string postcode
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 50</para>
        /// </summary>
        public string homepage
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 50</para>
        /// </summary>
        public string domain
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 50</para>
        /// </summary>
        public string domainip
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 50</para>
        /// </summary>
        public string icp
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 200</para>
        /// </summary>
        public string surface
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 40</para>
        /// </summary>
        public string logo
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 40</para>
        /// </summary>
        public string thumb
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 300</para>
        /// </summary>
        public string bannel
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 400</para>
        /// </summary>
        public string desimage
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 1073741823</para>
        /// </summary>
        public string descript
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 200</para>
        /// </summary>
        public string keywords
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 50</para>
        /// </summary>
        public string template
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int hits
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int sort
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int marketid
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int cid
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int ctype
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int createmid
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int lastedid
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 23</para>
        /// </summary>
        public DateTime lastedittime
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int auditstatus
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int linestatus
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 20</para>
        /// </summary>
        public string qq
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 50</para>
        /// </summary>
        public string sortstr
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 1</para>
        /// </summary>
        public bool IsPay
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 20</para>
        /// </summary>
        public string SecondClerk
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 20</para>
        /// </summary>
        public string ShopContact
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 30</para>
        /// </summary>
        public string FirstClerkMobile
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 30</para>
        /// </summary>
        public string SecondClerkMobile
        { get; set; }
        /// <summary> 
        /// 启用店铺资源共享（1表示已共享；0表示未共享）
        /// <para> 10</para>
        /// </summary>
        public int isshopshare
        { get; set; }
        public int PavilionId { get; set; }
        #endregion

        public static void FillData(System.Data.DataRow dr, out t_shop info)
        {
            #region

            info = new t_shop();
            if (dr.Table.Columns.Contains(Field_id))
                info.id = DBNull.Value == dr[Field_id] ? default(int) : (int)dr[Field_id];
            if (dr.Table.Columns.Contains(Field_mid))
                info.mid = DBNull.Value == dr[Field_mid] ? default(int) : (int)dr[Field_mid];
            if (dr.Table.Columns.Contains(Field_title))
                info.title = DBNull.Value == dr[Field_title] ? default(string) : (string)dr[Field_title];
            if (dr.Table.Columns.Contains(Field_letter))
                info.letter = DBNull.Value == dr[Field_letter] ? default(string) : (string)dr[Field_letter];
            if (dr.Table.Columns.Contains(Field_groupid))
                info.groupid = DBNull.Value == dr[Field_groupid] ? default(int) : (int)dr[Field_groupid];
            if (dr.Table.Columns.Contains(Field_attribute))
                info.attribute = DBNull.Value == dr[Field_attribute] ? default(string) : (string)dr[Field_attribute];
            if (dr.Table.Columns.Contains(Field_industry))
                info.industry = DBNull.Value == dr[Field_industry] ? default(string) : (string)dr[Field_industry];
            if (dr.Table.Columns.Contains(Field_productcategory))
                info.productcategory = DBNull.Value == dr[Field_productcategory] ? default(string) : (string)dr[Field_productcategory];
            if (dr.Table.Columns.Contains(Field_vip))
                info.vip = DBNull.Value == dr[Field_vip] ? default(int) : (int)dr[Field_vip];
            if (dr.Table.Columns.Contains(Field_areacode))
                info.areacode = DBNull.Value == dr[Field_areacode] ? default(string) : (string)dr[Field_areacode];
            if (dr.Table.Columns.Contains(Field_address))
                info.address = DBNull.Value == dr[Field_address] ? default(string) : (string)dr[Field_address];
            if (dr.Table.Columns.Contains(Field_mapapi))
                info.mapapi = DBNull.Value == dr[Field_mapapi] ? default(string) : (string)dr[Field_mapapi];
            if (dr.Table.Columns.Contains(Field_staffsize))
                info.staffsize = DBNull.Value == dr[Field_staffsize] ? default(int) : (int)dr[Field_staffsize];
            if (dr.Table.Columns.Contains(Field_regyear))
                info.regyear = DBNull.Value == dr[Field_regyear] ? default(string) : (string)dr[Field_regyear];
            if (dr.Table.Columns.Contains(Field_regcity))
                info.regcity = DBNull.Value == dr[Field_regcity] ? default(string) : (string)dr[Field_regcity];
            if (dr.Table.Columns.Contains(Field_buy))
                info.buy = DBNull.Value == dr[Field_buy] ? default(string) : (string)dr[Field_buy];
            if (dr.Table.Columns.Contains(Field_sell))
                info.sell = DBNull.Value == dr[Field_sell] ? default(string) : (string)dr[Field_sell];
            if (dr.Table.Columns.Contains(Field_linkman))
                info.linkman = DBNull.Value == dr[Field_linkman] ? default(string) : (string)dr[Field_linkman];
            if (dr.Table.Columns.Contains(Field_phone))
                info.phone = DBNull.Value == dr[Field_phone] ? default(string) : (string)dr[Field_phone];
            if (dr.Table.Columns.Contains(Field_mphone))
                info.mphone = DBNull.Value == dr[Field_mphone] ? default(string) : (string)dr[Field_mphone];
            if (dr.Table.Columns.Contains(Field_fax))
                info.fax = DBNull.Value == dr[Field_fax] ? default(string) : (string)dr[Field_fax];
            if (dr.Table.Columns.Contains(Field_email))
                info.email = DBNull.Value == dr[Field_email] ? default(string) : (string)dr[Field_email];
            if (dr.Table.Columns.Contains(Field_postcode))
                info.postcode = DBNull.Value == dr[Field_postcode] ? default(string) : (string)dr[Field_postcode];
            if (dr.Table.Columns.Contains(Field_homepage))
                info.homepage = DBNull.Value == dr[Field_homepage] ? default(string) : (string)dr[Field_homepage];
            if (dr.Table.Columns.Contains(Field_domain))
                info.domain = DBNull.Value == dr[Field_domain] ? default(string) : (string)dr[Field_domain];
            if (dr.Table.Columns.Contains(Field_domainip))
                info.domainip = DBNull.Value == dr[Field_domainip] ? default(string) : (string)dr[Field_domainip];
            if (dr.Table.Columns.Contains(Field_icp))
                info.icp = DBNull.Value == dr[Field_icp] ? default(string) : (string)dr[Field_icp];
            if (dr.Table.Columns.Contains(Field_surface))
                info.surface = DBNull.Value == dr[Field_surface] ? default(string) : (string)dr[Field_surface];
            if (dr.Table.Columns.Contains(Field_logo))
                info.logo = DBNull.Value == dr[Field_logo] ? default(string) : (string)dr[Field_logo];
            if (dr.Table.Columns.Contains(Field_thumb))
                info.thumb = DBNull.Value == dr[Field_thumb] ? default(string) : (string)dr[Field_thumb];
            if (dr.Table.Columns.Contains(Field_bannel))
                info.bannel = DBNull.Value == dr[Field_bannel] ? default(string) : (string)dr[Field_bannel];
            if (dr.Table.Columns.Contains(Field_desimage))
                info.desimage = DBNull.Value == dr[Field_desimage] ? default(string) : (string)dr[Field_desimage];
            if (dr.Table.Columns.Contains(Field_descript))
                info.descript = DBNull.Value == dr[Field_descript] ? default(string) : (string)dr[Field_descript];
            if (dr.Table.Columns.Contains(Field_keywords))
                info.keywords = DBNull.Value == dr[Field_keywords] ? default(string) : (string)dr[Field_keywords];
            if (dr.Table.Columns.Contains(Field_template))
                info.template = DBNull.Value == dr[Field_template] ? default(string) : (string)dr[Field_template];
            if (dr.Table.Columns.Contains(Field_hits))
                info.hits = DBNull.Value == dr[Field_hits] ? default(int) : (int)dr[Field_hits];
            if (dr.Table.Columns.Contains(Field_sort))
                info.sort = DBNull.Value == dr[Field_sort] ? default(int) : (int)dr[Field_sort];
            if (dr.Table.Columns.Contains(Field_marketid))
                info.marketid = DBNull.Value == dr[Field_marketid] ? default(int) : (int)dr[Field_marketid];
            if (dr.Table.Columns.Contains(Field_cid))
                info.cid = DBNull.Value == dr[Field_cid] ? default(int) : (int)dr[Field_cid];
            if (dr.Table.Columns.Contains(Field_ctype))
                info.ctype = DBNull.Value == dr[Field_ctype] ? default(int) : (int)dr[Field_ctype];
            if (dr.Table.Columns.Contains(Field_createmid))
                info.createmid = DBNull.Value == dr[Field_createmid] ? default(int) : (int)dr[Field_createmid];
            if (dr.Table.Columns.Contains(Field_lastedid))
                info.lastedid = DBNull.Value == dr[Field_lastedid] ? default(int) : (int)dr[Field_lastedid];
            if (dr.Table.Columns.Contains(Field_lastedittime))
                info.lastedittime = DBNull.Value == dr[Field_lastedittime] ? default(DateTime) : (DateTime)dr[Field_lastedittime];
            if (dr.Table.Columns.Contains(Field_auditstatus))
                info.auditstatus = DBNull.Value == dr[Field_auditstatus] ? default(int) : (int)dr[Field_auditstatus];
            if (dr.Table.Columns.Contains(Field_linestatus))
                info.linestatus = DBNull.Value == dr[Field_linestatus] ? default(int) : (int)dr[Field_linestatus];
            if (dr.Table.Columns.Contains(Field_qq))
                info.qq = DBNull.Value == dr[Field_qq] ? default(string) : (string)dr[Field_qq];
            if (dr.Table.Columns.Contains(Field_sortstr))
                info.sortstr = DBNull.Value == dr[Field_sortstr] ? default(string) : (string)dr[Field_sortstr];
            if (dr.Table.Columns.Contains(Field_IsPay))
                info.IsPay = DBNull.Value == dr[Field_IsPay] ? default(bool) : (bool)dr[Field_IsPay];
            if (dr.Table.Columns.Contains(Field_SecondClerk))
                info.SecondClerk = DBNull.Value == dr[Field_SecondClerk] ? default(string) : (string)dr[Field_SecondClerk];
            if (dr.Table.Columns.Contains(Field_ShopContact))
                info.ShopContact = DBNull.Value == dr[Field_ShopContact] ? default(string) : (string)dr[Field_ShopContact];
            if (dr.Table.Columns.Contains(Field_FirstClerkMobile))
                info.FirstClerkMobile = DBNull.Value == dr[Field_FirstClerkMobile] ? default(string) : (string)dr[Field_FirstClerkMobile];
            if (dr.Table.Columns.Contains(Field_SecondClerkMobile))
                info.SecondClerkMobile = DBNull.Value == dr[Field_SecondClerkMobile] ? default(string) : (string)dr[Field_SecondClerkMobile];
            if (dr.Table.Columns.Contains(Field_isshopshare))
                info.isshopshare = DBNull.Value == dr[Field_isshopshare] ? default(int) : (int)dr[Field_isshopshare];
            if (dr.Table.Columns.Contains(Field_PavilionId))
                info.PavilionId = DBNull.Value == dr[Field_PavilionId] ? default(int) : (int)dr[Field_PavilionId];
            #endregion

        }

    }
}

