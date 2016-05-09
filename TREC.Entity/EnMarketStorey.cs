using System;
namespace TREC.Entity
{
	/// <summary>
	/// sys_action:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class EnMarketStorey
	{
        public EnMarketStorey()
		{}
        #region Model
		private int _id;
		private int _marketid;
		private string _markettitle;
		private string _title;
		private string _number;
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
		private int? _lastedid=0;
		private DateTime _lastedittime;
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
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string surface
		{
			set{ _surface=value;}
			get{return _surface;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string thumb
		{
			set{ _thumb=value;}
			get{return _thumb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bannel
		{
			set{ _bannel=value;}
			get{return _bannel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string desimage
		{
			set{ _desimage=value;}
			get{return _desimage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string descript
		{
			set{ _descript=value;}
			get{return _descript;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string template
		{
			set{ _template=value;}
			get{return _template;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? hits
		{
			set{ _hits=value;}
			get{return _hits;}
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
		#endregion Model

	}
}

