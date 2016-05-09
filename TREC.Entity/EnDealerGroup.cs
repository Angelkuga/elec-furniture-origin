using System;
namespace TREC.Entity
{
	/// <summary>
	/// admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class EnDealerGroup
	{
        public EnDealerGroup()
		{}
        #region Model
        private int _id;
        private string _title;
        private string _color;
        private string _avatar;
        private decimal? _integral;
        private decimal? _money;
        private int? _adcount;
        private int? _shopcount;
        private int? _brandcount;
        private int? _promotioncount;
        private int? _adrecommend;
        private int? _shoprecommend;
        private int? _brandrecommend;
        private int? _promotionrecommend;
        private string _permissions;
        private int? _lev;
        private string _descript;
        private int? _sort;
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
        public string color
        {
            set { _color = value; }
            get { return _color; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string avatar
        {
            set { _avatar = value; }
            get { return _avatar; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? integral
        {
            set { _integral = value; }
            get { return _integral; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? adcount
        {
            set { _adcount = value; }
            get { return _adcount; }
        }
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
        public int? brandcount
        {
            set { _brandcount = value; }
            get { return _brandcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? promotioncount
        {
            set { _promotioncount = value; }
            get { return _promotioncount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? adrecommend
        {
            set { _adrecommend = value; }
            get { return _adrecommend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? shoprecommend
        {
            set { _shoprecommend = value; }
            get { return _shoprecommend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? brandrecommend
        {
            set { _brandrecommend = value; }
            get { return _brandrecommend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? promotionrecommend
        {
            set { _promotionrecommend = value; }
            get { return _promotionrecommend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string permissions
        {
            set { _permissions = value; }
            get { return _permissions; }
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
        public string descript
        {
            set { _descript = value; }
            get { return _descript; }
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

