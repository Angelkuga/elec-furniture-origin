using System;
namespace TREC.Entity
{
    /// <summary>
    /// admin:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class EnAdvertisement
    {
        public EnAdvertisement()
        { }
        #region Model
        private int _id;
        private int _categoryid;
        private string _title;
        private string _linkurl;
        private string _flashurl;
        private string _imgurl;
        private string _videourl;
        private string _adtext;
        private string _adcode;
        private int? _isopen;
        private string _adlinkman;
        private string _adlinkphone;
        private string _adlinkemail;
        private DateTime _lastedittime;
        private int _lasteditaid;
        private string _price;
        private DateTime _starttime;
        private DateTime _endtime;
        private string _orgprice;
        private string _imgurlfull;
        private int _sort;
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
        public int categoryid
        {
            set { _categoryid = value; }
            get { return _categoryid; }
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
        public string linkurl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flashurl
        {
            set { _flashurl = value; }
            get { return _flashurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string imgurl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string videourl
        {
            set { _videourl = value; }
            get { return _videourl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string adtext
        {
            set { _adtext = value; }
            get { return _adtext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string adcode
        {
            set { _adcode = value; }
            get { return _adcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isopen
        {
            set { _isopen = value; }
            get { return _isopen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string adlinkman
        {
            set { _adlinkman = value; }
            get { return _adlinkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string adlinkphone
        {
            set { _adlinkphone = value; }
            get { return _adlinkphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string adlinkemail
        {
            set { _adlinkemail = value; }
            get { return _adlinkemail; }
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
        public int lasteditaid
        {
            set { _lasteditaid = value; }
            get { return _lasteditaid; }
        }
        public string Price
        {
            set { _price = value; }
            get { return _price; }
        }
        public DateTime EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        public DateTime StarTtime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        public string OrgPrice
        {
            set { _orgprice = value; }
            get { return _orgprice; }
        }
        public string ImgUrlFull
        {
            set { _imgurlfull = value; }
            get { return _imgurlfull; }
        }
        #endregion Model

    }

    /// <summary>
    /// 广告类
    /// 2015-01-29 shen
    /// </summary>
    [Serializable]
    public class t_advertising
    {
        public t_advertising()
        {

        }

        /// <summary> 
        /// 
        /// </summary>
        public const string TableName = "t_advertising";

        #region

        public const string Field_id = "id";
        public const string Field_categoryid = "categoryid";
        public const string Field_title = "title";
        public const string Field_linkurl = "linkurl";
        public const string Field_flashurl = "flashurl";
        public const string Field_imgurl = "imgurl";
        public const string Field_videourl = "videourl";
        public const string Field_adtext = "adtext";
        public const string Field_adcode = "adcode";
        public const string Field_isopen = "isopen";
        public const string Field_adlinkman = "adlinkman";
        public const string Field_adlinkphone = "adlinkphone";
        public const string Field_adlinkemail = "adlinkemail";
        public const string Field_lastedittime = "lastedittime";
        public const string Field_lasteditaid = "lasteditaid";
        public const string Field_width = "width";
        public const string Field_height = "height";
        public const string Field_sort = "sort";
        public const string Field_advstate = "advstate";
        public const string Field_starttime = "starttime";
        public const string Field_endtime = "endtime";
        #endregion





        #region

        /// <summary>
        /// 抢购价/特价
        /// </summary>
        public string orgprice { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string price { get; set; }
        /// <summary> 
        /// 
        /// 10
        /// </summary>
        public int id
        { get; set; }
        /// <summary> 
        /// 
        /// 10
        /// </summary>
        public int categoryid
        { get; set; }
        /// <summary> 
        /// 
        /// 50
        /// </summary>
        public string title
        { get; set; }
        /// <summary> 
        /// 
        /// 50
        /// </summary>
        public string tgtitle
        { get; set; }
        /// <summary> 
        /// 
        /// 100
        /// </summary>
        public string linkurl
        { get; set; }
        /// <summary> 
        /// 
        /// 100
        /// </summary>
        public string flashurl
        { get; set; }
        /// <summary> 
        /// 
        /// 100
        /// </summary>
        public string imgurl
        { get; set; }
        /// <summary> 
        /// 
        /// 100
        /// </summary>
        public string videourl
        { get; set; }
        /// <summary> 
        /// 
        /// 2000
        /// </summary>
        public string adtext
        { get; set; }
        /// <summary> 
        /// 
        /// 2000
        /// </summary>
        public string adcode
        { get; set; }
        /// <summary> 
        /// 
        /// 10
        /// </summary>
        public int isopen
        { get; set; }
        /// <summary> 
        /// 
        /// 20
        /// </summary>
        public string adlinkman
        { get; set; }
        /// <summary> 
        /// 
        /// 20
        /// </summary>
        public string adlinkphone
        { get; set; }
        /// <summary> 
        /// 
        /// 20
        /// </summary>
        public string adlinkemail
        { get; set; }
        /// <summary> 
        /// 
        /// 23
        /// </summary>
        public DateTime lastedittime
        { get; set; }
        /// <summary> 
        /// 
        /// 10
        /// </summary>
        public int lasteditaid
        { get; set; }
        /// <summary> 
        /// 
        /// 10
        /// </summary>
        public int width
        { get; set; }
        /// <summary> 
        /// 
        /// 10
        /// </summary>
        public int height
        { get; set; }
        /// <summary> 
        /// 
        /// 10
        /// </summary>
        public int sort
        { get; set; }
        /// <summary> 
        /// 
        /// 10
        /// </summary>
        public int advstate
        { get; set; }
        /// <summary> 
        /// 
        /// 23
        /// </summary>
        public DateTime starttime
        { get; set; }
        /// <summary> 
        /// 
        /// 23
        /// </summary>
        public DateTime endtime
        { get; set; }
        #endregion

        public static void FillData(System.Data.DataRow dr, out t_advertising info)
        {
            #region

            info = new t_advertising();
            info.id = DBNull.Value == dr[Field_id] ? default(int) : (int)dr[Field_id];
            info.categoryid = DBNull.Value == dr[Field_categoryid] ? default(int) : (int)dr[Field_categoryid];
            info.title = DBNull.Value == dr[Field_title] ? default(string) : (string)dr[Field_title];
            info.linkurl = DBNull.Value == dr[Field_linkurl] ? default(string) : (string)dr[Field_linkurl];

            if (dr.Table.Columns.Contains("orgprice"))
                info.orgprice  = DBNull.Value == dr["orgprice"] ? default(string) : (string)dr["orgprice"];
            if (dr.Table.Columns.Contains("tgtitle"))
                info.tgtitle = DBNull.Value == dr["tgtitle"] ? default(string) : (string)dr["tgtitle"];
            if (dr.Table.Columns.Contains(Field_flashurl))
                info.flashurl = DBNull.Value == dr[Field_flashurl] ? default(string) : (string)dr[Field_flashurl];
            if (dr.Table.Columns.Contains(Field_imgurl))
                info.imgurl = DBNull.Value == dr[Field_imgurl] ? default(string) : (string)dr[Field_imgurl];

            if (dr.Table.Columns.Contains(Field_videourl))
                info.videourl = DBNull.Value == dr[Field_videourl] ? default(string) : (string)dr[Field_videourl];
            if (dr.Table.Columns.Contains(Field_adtext))
                info.adtext = DBNull.Value == dr[Field_adtext] ? default(string) : (string)dr[Field_adtext];
            if (dr.Table.Columns.Contains(Field_adcode))
                info.adcode = DBNull.Value == dr[Field_adcode] ? default(string) : (string)dr[Field_adcode];
            if (dr.Table.Columns.Contains(Field_isopen))
                info.isopen = DBNull.Value == dr[Field_isopen] ? default(int) : (int)dr[Field_isopen];
            if (dr.Table.Columns.Contains(Field_adlinkman))
                info.adlinkman = DBNull.Value == dr[Field_adlinkman] ? default(string) : (string)dr[Field_adlinkman];
            if (dr.Table.Columns.Contains(Field_adlinkphone))
                info.adlinkphone = DBNull.Value == dr[Field_adlinkphone] ? default(string) : (string)dr[Field_adlinkphone];
            if (dr.Table.Columns.Contains(Field_adlinkemail))
                info.adlinkemail = DBNull.Value == dr[Field_adlinkemail] ? default(string) : (string)dr[Field_adlinkemail];
            if (dr.Table.Columns.Contains(Field_lastedittime))
                info.lastedittime = DBNull.Value == dr[Field_lastedittime] ? default(DateTime) : (DateTime)dr[Field_lastedittime];
            if (dr.Table.Columns.Contains(Field_lasteditaid))
                info.lasteditaid = DBNull.Value == dr[Field_lasteditaid] ? default(int) : (int)dr[Field_lasteditaid];
            if (dr.Table.Columns.Contains(Field_width))
                info.width = DBNull.Value == dr[Field_width] ? default(int) : (int)dr[Field_width];
            if (dr.Table.Columns.Contains(Field_height)) info.height = DBNull.Value == dr[Field_height] ? default(int) : (int)dr[Field_height];
            if (dr.Table.Columns.Contains(Field_sort)) info.sort = DBNull.Value == dr[Field_sort] ? default(int) : (int)dr[Field_sort];
            if (dr.Table.Columns.Contains(Field_advstate)) info.advstate = DBNull.Value == dr[Field_advstate] ? default(int) : (int)dr[Field_advstate];
            if (dr.Table.Columns.Contains(Field_starttime)) info.starttime = DBNull.Value == dr[Field_starttime] ? default(DateTime) : (DateTime)dr[Field_starttime];
            if (dr.Table.Columns.Contains(Field_endtime)) info.endtime = DBNull.Value == dr[Field_endtime] ? default(DateTime) : (DateTime)dr[Field_endtime];
            if (dr.Table.Columns.Contains("price")) info.price = DBNull.Value == dr["price"] ? default(string) : (string)dr["price"];

            #endregion

        }

    }


    [Serializable]
    public class t_navigationbrand
    {
        /// <summary>
        /// 1卖场id,2品牌id,3产品分类大类id
        /// </summary>
        public int ntype { get; set; }
        /// <summary>
        /// 1卖场id,2品牌id,3产品分类大类id
        /// </summary>
        public int ntypeid { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>
        public int brandid { get; set; }
        /// <summary>
        /// 公司id
        /// </summary>
        public int companyid { get; set; }
        public string logo { get; set; }

        public static void FillData(System.Data.DataRow dr, out t_navigationbrand info)
        {
            info = new t_navigationbrand();
            if (dr.Table.Columns.Contains("ntype"))
                info.ntype = DBNull.Value == dr["ntype"] ? default(int) : (int)dr["ntype"];
            if (dr.Table.Columns.Contains("ntypeid"))
                info.ntypeid = DBNull.Value == dr["ntypeid"] ? default(int) : (int)dr["ntypeid"];
            if (dr.Table.Columns.Contains("brandid"))
                info.brandid = DBNull.Value == dr["brandid"] ? default(int) : (int)dr["brandid"];
            if (dr.Table.Columns.Contains("companyid"))
                info.companyid = DBNull.Value == dr["companyid"] ? default(int) : (int)dr["companyid"];
            if (dr.Table.Columns.Contains("logo"))
                info.logo = DBNull.Value == dr["logo"] ? default(string) : (string)dr["logo"];
        }
    }

}

