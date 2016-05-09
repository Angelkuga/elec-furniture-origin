using System;
using System.Collections;
using System.Collections.Generic;

namespace TREC.Entity
{
    /// <summary>
    /// admin:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class EnBrand
    {
        public EnBrand()
        { }
        #region Model
        private int _id;
        private int? _companyid = 0;
        private string _title;
        private string _letter;
        private int? _groupid = 0;
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
        private int? _hits = 0;
        private int? _sort = 0;
        private int? _createmid = 0;
        private int? _lasteditid;
        private DateTime _lastedittime = DateTime.Now;
        private int _auditstatus = 0;
        private int _linestatus = 0;

        private string _companyTitle;
        /// <summary>
        /// 后台组合的品牌名称
        /// </summary>
        public string CompanyTitle
        {
            set { _companyTitle = value; }
            get { return _companyTitle; }
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
        /// 主页地址
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
        /// 模版ID
        /// </summary>
        public string template
        {
            set { _template = value; }
            get { return _template; }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        public int? hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// 排序
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
        /// 最后个改
        /// </summary>
        public DateTime lastedittime
        {
            set { _lastedittime = value; }
            get { return _lastedittime; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int auditstatus
        {
            set { _auditstatus = value; }
            get { return _auditstatus; }
        }
        /// <summary>
        /// 在线状态
        /// </summary>
        public int linestatus
        {
            set { _linestatus = value; }
            get { return _linestatus; }
        }
        #endregion Model

    }

    /// <summary>
    /// 2015-02-02 shen
    /// </summary>
    [Serializable]
    public class t_brand
    {
        public t_brand()
        {

        }

        /// <summary> 
        /// 
        /// </summary>
        public const string TableName = "t_brand";

        #region

        public const string Field_id = "id";
        public const string Field_companyid = "companyid";
        public const string Field_title = "title";
        public const string Field_letter = "letter";
        public const string Field_groupid = "groupid";
        public const string Field_attribute = "attribute";
        public const string Field_productcategory = "productcategory";
        public const string Field_homepage = "homepage";
        public const string Field_productcount = "productcount";
        public const string Field_spread = "spread";
        public const string Field_material = "material";
        public const string Field_style = "style";
        public const string Field_color = "color";
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
        public const string Field_createmid = "createmid";
        public const string Field_lasteditid = "lasteditid";
        public const string Field_lastedittime = "lastedittime";
        public const string Field_auditstatus = "auditstatus";
        public const string Field_linestatus = "linestatus";
        public const string Field_Createtime = "Createtime";
        public const string Field_sortstr = "sortstr";
        public const string Field_IsPay = "IsPay";
        #endregion

        #region

        /// <summary> 
        /// 
        /// <para>10</para>
        /// </summary>
        public int id
        { get; set; }
        /// <summary> 
        /// 
        /// 10
        /// </summary>
        public int companyid
        { get; set; }
        /// <summary> 
        /// 
        /// 80
        /// </summary>
        public string title
        { get; set; }
        /// <summary> 
        /// 
        /// 20
        /// </summary>
        public string letter
        { get; set; }
        /// <summary> 
        /// 
        /// 20
        /// </summary>
        public string letter2
        { get; set; }
        /// <summary> 
        /// 
        /// 10
        /// </summary>
        public int groupid
        { get; set; }
        /// <summary> 
        /// 
        /// 100
        /// </summary>
        public string attribute
        { get; set; }
        /// <summary> 
        /// 
        /// 50
        /// </summary>
        public string productcategory
        { get; set; }
        /// <summary> 
        /// 主页地址
        /// 50
        /// </summary>
        public string homepage
        { get; set; }
        /// <summary> 
        /// 
        /// 10
        /// </summary>
        public int productcount
        { get; set; }
        /// <summary> 
        /// 
        /// 30
        /// </summary>
        public string spread
        { get; set; }
        /// <summary> 
        /// 
        /// 50
        /// </summary>
        public string material
        { get; set; }
        /// <summary> 
        /// 
        /// 50
        /// </summary>
        public string style
        { get; set; }
        /// <summary> 
        /// 
        /// 50
        /// </summary>
        public string color
        { get; set; }
        /// <summary> 
        /// 
        /// 200
        /// </summary>
        public string surface
        { get; set; }
        /// <summary> 
        /// 
        /// 40
        /// </summary>
        public string logo
        { get; set; }
        /// <summary> 
        /// 
        /// 40
        /// </summary>
        public string thumb
        { get; set; }
        /// <summary> 
        /// 
        /// 300
        /// </summary>
        public string bannel
        { get; set; }
        /// <summary> 
        /// 
        /// 400
        /// </summary>
        public string desimage
        { get; set; }
        /// <summary> 
        /// 
        /// 1073741823
        /// </summary>
        public string descript
        { get; set; }
        /// <summary> 
        /// 
        /// 200
        /// </summary>
        public string keywords
        { get; set; }
        /// <summary> 
        /// 模版ID
        /// 50
        /// </summary>
        public string template
        { get; set; }
        /// <summary> 
        /// 点击量
        /// 10
        /// </summary>
        public int hits
        { get; set; }
        /// <summary> 
        /// 排序
        /// 10
        /// </summary>
        public int sort
        { get; set; }
        /// <summary> 
        /// 
        /// 10
        /// </summary>
        public int createmid
        { get; set; }
        /// <summary> 
        /// 
        /// 10
        /// </summary>
        public int lasteditid
        { get; set; }
        /// <summary> 
        /// 最后个改
        /// 23
        /// </summary>
        public DateTime lastedittime
        { get; set; }
        /// <summary> 
        /// 审核状态
        /// 10
        /// </summary>
        public int auditstatus
        { get; set; }
        /// <summary> 
        /// 在线状态
        /// 10
        /// </summary>
        public int linestatus
        { get; set; }
        /// <summary> 
        /// 
        /// 23
        /// </summary>
        public DateTime Createtime
        { get; set; }
        /// <summary> 
        /// 
        /// 50
        /// </summary>
        public string sortstr
        { get; set; }
        /// <summary> 
        /// 
        /// 1
        /// </summary>
        public bool IsPay
        { get; set; }
        #endregion


        /// <summary>
        /// 是否推荐品牌
        /// </summary>
        public int Recommend { get; set; }
        /// <summary>
        /// 推荐品牌次序
        /// </summary>
        public int RecommendSort { get; set; }
        /// <summary>
        /// 是否显示在首页导航条上
        /// </summary>
        public int ShowNav { get; set; }


        public static void FillData(System.Data.DataRow dr, out t_brand info)
        {
            #region

            info = new t_brand();
            if (dr.Table.Columns.Contains("Recommend"))
                info.Recommend = DBNull.Value == dr["Recommend"] ? default(int) : (int)dr["Recommend"];
            if (dr.Table.Columns.Contains("RecommendSort"))
                info.RecommendSort = DBNull.Value == dr["RecommendSort"] ? default(int) : (int)dr["RecommendSort"];
            if (dr.Table.Columns.Contains("ShowNav"))
                info.ShowNav = DBNull.Value == dr["ShowNav"] ? default(int) : (int)dr["ShowNav"];

            if (dr.Table.Columns.Contains(Field_id))
                info.id = DBNull.Value == dr[Field_id] ? default(int) : (int)dr[Field_id];
            if (dr.Table.Columns.Contains(Field_companyid))
                info.companyid = DBNull.Value == dr[Field_companyid] ? default(int) : (int)dr[Field_companyid];
            if (dr.Table.Columns.Contains(Field_title))
                info.title = DBNull.Value == dr[Field_title] ? default(string) : (string)dr[Field_title];
            if (dr.Table.Columns.Contains(Field_letter))
                info.letter = DBNull.Value == dr[Field_letter] ? default(string) : (string)dr[Field_letter];
            if (dr.Table.Columns.Contains("letter2"))
                info.letter2 = DBNull.Value == dr["letter2"] ? default(string) : (string)dr["letter2"];
            if (dr.Table.Columns.Contains(Field_groupid))
                info.groupid = DBNull.Value == dr[Field_groupid] ? default(int) : (int)dr[Field_groupid];
            if (dr.Table.Columns.Contains(Field_attribute))
                info.attribute = DBNull.Value == dr[Field_attribute] ? default(string) : (string)dr[Field_attribute];
            if (dr.Table.Columns.Contains(Field_productcategory))
                info.productcategory = DBNull.Value == dr[Field_productcategory] ? default(string) : (string)dr[Field_productcategory];
            if (dr.Table.Columns.Contains(Field_homepage))
                info.homepage = DBNull.Value == dr[Field_homepage] ? default(string) : (string)dr[Field_homepage];
            if (dr.Table.Columns.Contains(Field_productcount))
                info.productcount = DBNull.Value == dr[Field_productcount] ? default(int) : (int)dr[Field_productcount];
            if (dr.Table.Columns.Contains(Field_spread))
                info.spread = DBNull.Value == dr[Field_spread] ? default(string) : (string)dr[Field_spread];
            if (dr.Table.Columns.Contains(Field_material))
                info.material = DBNull.Value == dr[Field_material] ? default(string) : (string)dr[Field_material];
            if (dr.Table.Columns.Contains(Field_style))
                info.style = DBNull.Value == dr[Field_style] ? default(string) : (string)dr[Field_style];
            if (dr.Table.Columns.Contains(Field_color))
                info.color = DBNull.Value == dr[Field_color] ? default(string) : (string)dr[Field_color];
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
            if (dr.Table.Columns.Contains(Field_createmid))
                info.createmid = DBNull.Value == dr[Field_createmid] ? default(int) : (int)dr[Field_createmid];
            if (dr.Table.Columns.Contains(Field_lasteditid))
                info.lasteditid = DBNull.Value == dr[Field_lasteditid] ? default(int) : (int)dr[Field_lasteditid];
            if (dr.Table.Columns.Contains(Field_lastedittime))
                info.lastedittime = DBNull.Value == dr[Field_lastedittime] ? default(DateTime) : (DateTime)dr[Field_lastedittime];
            if (dr.Table.Columns.Contains(Field_auditstatus))
                info.auditstatus = DBNull.Value == dr[Field_auditstatus] ? default(int) : (int)dr[Field_auditstatus];
            if (dr.Table.Columns.Contains(Field_linestatus))
                info.linestatus = DBNull.Value == dr[Field_linestatus] ? default(int) : (int)dr[Field_linestatus];
            if (dr.Table.Columns.Contains(Field_Createtime))
                info.Createtime = DBNull.Value == dr[Field_Createtime] ? default(DateTime) : (DateTime)dr[Field_Createtime];
            if (dr.Table.Columns.Contains(Field_sortstr))
                info.sortstr = DBNull.Value == dr[Field_sortstr] ? default(string) : (string)dr[Field_sortstr];
            if (dr.Table.Columns.Contains(Field_IsPay))
                info.IsPay = DBNull.Value == dr[Field_IsPay] ? default(bool) : (bool)dr[Field_IsPay];
            #endregion

        }

    }
    /// <summary>
    /// 2015-02-02 shen
    /// </summary>
    public class BrandAndMarket
    {
        /// <summary>
        /// 品牌列表
        /// </summary>
        public List<t_brand> brandlist = new List<t_brand>();
        /// <summary>
        /// 市场
        /// </summary>
        public List<t_market> marketlist = new List<t_market>();
        //店铺
        public List<t_shop> shoplist = new List<t_shop>();
        //工厂
        public List<t_company> companylist = new List<t_company>();
        //经销商
        public List<t_dealer> dealerlist = new List<t_dealer>();


    }


}

