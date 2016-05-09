using System;
namespace TREC.Entity
{
	/// <summary>
	/// t_article:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnArticle
	{
        public EnArticle()
		{}
        #region Model
        private int _id;
        private string _attribute;
        private string _title;
        private string _subtitle;
        private string _letter;
        private int _categoryid;
        private string _subcategoryid;
        private string _ico;
        private string _thumb;
        private string _banner;
        private string _keyword;
        private string _descript;
        private string _context;
        private string _othercon;
        private string _source;
        private string _autho;
        private string _linkurl;
        private int _clickcount = 0;
        private int _sort = 0;
        private DateTime _createtime;
        private int _createid = 0;
        private DateTime _edittime = DateTime.Now;
        private int _editid = 0;

        private string _cletter = "";
        public string cletter
        {
            get { return _cletter; }
            set { _cletter = value; }
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
        public string attribute
        {
            set { _attribute = value; }
            get { return _attribute; }
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
        public string subtitle
        {
            set { _subtitle = value; }
            get { return _subtitle; }
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
        public int categoryid
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string subcategoryid
        {
            set { _subcategoryid = value; }
            get { return _subcategoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ico
        {
            set { _ico = value; }
            get { return _ico; }
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
        public string keyword
        {
            set { _keyword = value; }
            get { return _keyword; }
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
        public string context
        {
            set { _context = value; }
            get { return _context; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string othercon
        {
            set { _othercon = value; }
            get { return _othercon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string autho
        {
            set { _autho = value; }
            get { return _autho; }
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
        public int clickcount
        {
            set { _clickcount = value; }
            get { return _clickcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
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
        public int createid
        {
            set { _createid = value; }
            get { return _createid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime edittime
        {
            set { _edittime = value; }
            get { return _edittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int editid
        {
            set { _editid = value; }
            get { return _editid; }
        }
        #endregion Model

	}
}

