using System;
namespace TREC.Entity
{
	/// <summary>
	/// sys_action:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class EnMarketStoreyShop
	{
       public EnMarketStoreyShop()
		{}
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
		private string _position;
		private int? _linestatus;
		private int? _source;
        private DateTime _createtime;

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
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int marketid
		{
			set{ _marketid=value;}
			get{return _marketid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string markettitle
		{
			set{ _markettitle=value;}
			get{return _markettitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int storeyid
		{
			set{ _storeyid=value;}
			get{return _storeyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string storeytitle
		{
			set{ _storeytitle=value;}
			get{return _storeytitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int shopid
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shoptitle
		{
			set{ _shoptitle=value;}
			get{return _shoptitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brandidlist
		{
			set{ _brandidlist=value;}
			get{return _brandidlist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brandtitlelist
		{
			set{ _brandtitlelist=value;}
			get{return _brandtitlelist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? istop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isrecommend
		{
			set{ _isrecommend=value;}
			get{return _isrecommend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? lev
		{
			set{ _lev=value;}
			get{return _lev;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? lastedid
		{
			set{ _lastedid=value;}
			get{return _lastedid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lastedittime
		{
			set{ _lastedittime=value;}
			get{return _lastedittime;}
		}
		/// <summary>
		/// 店铺所在位置
		/// </summary>
		public string position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 0未上线，1申请中，2已上线
		/// </summary>
		public int? linestatus
		{
			set{ _linestatus=value;}
			get{return _linestatus;}
		}
		/// <summary>
		/// 商家来源：1店铺，2卖场
		/// </summary>
		public int? source
		{
			set{ _source=value;}
			get{return _source;}
		}
        public int PavilionId { get; set; }
		#endregion Model

	
	}
}