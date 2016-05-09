using System;
namespace TREC.Entity
{
	/// <summary>
	/// admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnPromotionDef
	{
        public EnPromotionDef()
		{}
        #region Model
        private int _id;
        private string _title;
        private int _pid;
        private string _attribute;
        private string _type;
        private string _value;
        private string _valueletter;
        private string _valuetitle;
        private string _thumb;
        private string _banner;
        private string _descript;
        private string _curcountmoney;
        private string _curcountpeople;
        private string _curstage;
        private string _fordio;
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
        public int pid
        {
            set { _pid = value; }
            get { return _pid; }
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
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value
        {
            set { _value = value; }
            get { return _value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string valueletter
        {
            set { _valueletter = value; }
            get { return _valueletter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string valuetitle
        {
            set { _valuetitle = value; }
            get { return _valuetitle; }
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
        public string descript
        {
            set { _descript = value; }
            get { return _descript; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string curcountmoney
        {
            set { _curcountmoney = value; }
            get { return _curcountmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string curcountpeople
        {
            set { _curcountpeople = value; }
            get { return _curcountpeople; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string curstage
        {
            set { _curstage = value; }
            get { return _curstage; }
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
        public int? sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        #endregion Model


	}
}

