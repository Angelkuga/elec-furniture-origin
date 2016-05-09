using System;
namespace TREC.Entity
{
	/// <summary>
	/// sys_action:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class EnMenu
	{
        public EnMenu()
		{}
        #region Model
        private int _id;
        private string _title;
        private string _type;
        private string _mark;
        private int? _parent;
        private int? _lev;
        private string _path;
        private string _url;
        private int? _module;
        private int? _action;
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
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mark
        {
            set { _mark = value; }
            get { return _mark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? parent
        {
            set { _parent = value; }
            get { return _parent; }
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
        public string path
        {
            set { _path = value; }
            get { return _path; }
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
        public int? module
        {
            set { _module = value; }
            get { return _module; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? action
        {
            set { _action = value; }
            get { return _action; }
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

