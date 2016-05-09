using System;
namespace TREC.Entity
{
	/// <summary>
	/// admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnAdvertisementCategory
	{
        public EnAdvertisementCategory()
		{}

        #region Model
        private int _id;
        private int _parentid;
        private int _moduleid;
        private string _modulevalue;
        private string _title;
        private string _img;
        private int _height;
        private int _width;
        private int? _isopen;
        private int _adtype;
        private DateTime _starttime;
        private DateTime _endtime;
        private string _descript;
        private string _template;
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
        public int parentid
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int moduleid
        {
            set { _moduleid = value; }
            get { return _moduleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string modulevalue
        {
            set { _modulevalue = value; }
            get { return _modulevalue; }
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
        public string img
        {
            set { _img = value; }
            get { return _img; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int width
        {
            set { _width = value; }
            get { return _width; }
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
        public int adtype
        {
            set { _adtype = value; }
            get { return _adtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime starttime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime endtime
        {
            set { _endtime = value; }
            get { return _endtime; }
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
        public string template
        {
            set { _template = value; }
            get { return _template; }
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

