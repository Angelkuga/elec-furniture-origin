using System;
namespace TREC.Entity
{
    /// <summary>
    /// sys_action:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class EnPromotionAppBrand
    {
        public EnPromotionAppBrand()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _letter;
        private int? _bid;
        private string _blogo;
        private string _fordio;
        private string _thumb;
        private string _banner;
        private string _htmltitle;
        private string _descript;
        private int? _appcount = 0;
        private int? _sort = 0;
        private bool _isRecommend;
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecommend
        {
            get { return _isRecommend; }
            set { _isRecommend = value; }
        }

        private int _discount;
        /// <summary>
        /// 折扣力度
        /// </summary>
        public int Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }
        private int _period;
        /// <summary>
        /// 第几期团购
        /// </summary>
        public int Period
        {
            get { return _period; }
            set { _period = value; }
        }

        private int _style;
        /// <summary>
        /// 风格
        /// </summary>
        public int Style
        {
            get { return _style; }
            set { _style = value; }
        }

        private string _stylevalue;
        /// <summary>
        /// 风格
        /// </summary>
        public string Stylevalue
        {
            get { return _stylevalue; }
            set { _stylevalue = value; }
        }

        private int _percount;
        /// <summary>
        /// 购买过的人数
        /// </summary>
        public int Percount
        {
            get { return _percount; }
            set { _percount = value; }
        }

        private string _brandABC;
        /// <summary>
        /// 品牌的配音简称
        /// </summary>
        public string BrandABC
        {
            get { return _brandABC; }
            set { _brandABC = value; }
        }
        private string _template;
        /// <summary>
        /// 产品介绍
        /// </summary>
        public string Template
        {
            get { return _template; }
            set { _template = value; }
        }
        private string _rulesInfo;
        /// <summary>
        /// 规则介绍
        /// </summary>
        public string RulesInfo
        {
            get { return _rulesInfo; }
            set { _rulesInfo = value; }
        }
        private DateTime _starttime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Starttime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }
        private DateTime _endtime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime Endtime
        {
            get { return _endtime; }
            set { _endtime = value; }
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
        public int? bid
        {
            set { _bid = value; }
            get { return _bid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string blogo
        {
            set { _blogo = value; }
            get { return _blogo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fordio
        {
            set { _fordio = value; }
            get { return _fordio; }
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
        public string banner
        {
            set { _banner = value; }
            get { return _banner; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string htmltitle
        {
            set { _htmltitle = value; }
            get { return _htmltitle; }
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
        public int? appcount
        {
            set { _appcount = value; }
            get { return _appcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        #endregion Model

    }
}

