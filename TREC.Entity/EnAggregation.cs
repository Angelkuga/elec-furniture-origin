using System;
namespace TREC.Entity
{
	/// <summary>
	/// sys_action:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class EnAggregation
	{
        public EnAggregation()
		{}
        #region Model
        private int _id;
        private int? _type;
        private string _title;
        private string _title1;
        private string _title2;
        private string _title3;
        private string _thumb;
        private int? _thumbw = 0;
        private int? _thumbh = 0;
        private string _bannel;
        private string _url;
        private string _url1;
        private string _url2;
        private string _descript;
        private int? _sort;
        private int? _hits;
        private DateTime _lastedittime;
        private int? _createmid;
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
        public int? type
        {
            set { _type = value; }
            get { return _type; }
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
        public string title1
        {
            set { _title1 = value; }
            get { return _title1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title2
        {
            set { _title2 = value; }
            get { return _title2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title3
        {
            set { _title3 = value; }
            get { return _title3; }
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
        public int? thumbw
        {
            set { _thumbw = value; }
            get { return _thumbw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? thumbh
        {
            set { _thumbh = value; }
            get { return _thumbh; }
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
        public string url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string url1
        {
            set { _url1 = value; }
            get { return _url1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string url2
        {
            set { _url2 = value; }
            get { return _url2; }
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
        public DateTime lastedittime
        {
            set { _lastedittime = value; }
            get { return _lastedittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? createmid
        {
            set { _createmid = value; }
            get { return _createmid; }
        }
        #endregion Model

	}
}

