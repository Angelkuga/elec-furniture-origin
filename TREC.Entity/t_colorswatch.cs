using System;
namespace TREC.Entity
{
	/// <summary>
	/// 实体类t_colorswatch 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class t_colorswatch
	{
		public t_colorswatch()
		{}
		#region Model
		private int _csid;
		private string _swatchname;
		private int? _categroyid;
		private string _picture;
		private int _createid;
		private DateTime _createtime;
		private int? _bseriesid;
        private int? _brandid;
        private string _brandsName;
        private string _bName;
        private string _cName;


        /// <summary>
        /// 类别名称
        /// </summary>
        public string cName
        {
            set { _cName = value; }
            get { return _cName; }
        }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string bName
        {
            set { _bName = value; }
            get { return _bName; }
        }

        /// <summary>
        /// 系列名称
        /// </summary>
        public string brandsName
        {
            set { _brandsName = value; }
            get { return _brandsName; }
        }

		/// <summary>
		/// 
		/// </summary>
		public int csid
		{
			set{ _csid=value;}
			get{return _csid;}
		}
        /// <summary>
        /// 品牌id
        /// </summary>
        public int? brandid
        {
            set { _brandid = value; }
            get { return _brandid; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string SwatchName
		{
			set{ _swatchname=value;}
			get{return _swatchname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CategroyId
		{
			set{ _categroyid=value;}
			get{return _categroyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Picture
		{
			set{ _picture=value;}
			get{return _picture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CreateId
		{
			set{ _createid=value;}
			get{return _createid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? bSeriesId
		{
			set{ _bseriesid=value;}
			get{return _bseriesid;}
		}
		#endregion Model

	}
}

