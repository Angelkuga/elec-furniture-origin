using System;
namespace TREC.Entity
{
	/// <summary>
	/// admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class EnPromotionStage
	{
        public EnPromotionStage()
		{}
        #region Model
        private int _id;
        private string _title;
        private int _pid;
        private int _did;
        private int _stype;
        private int _smodle;
        private string _svaluemin;
        private string _svaluemax;
        private int? _pmodule;
        private string _prolue;
        private string _pvalue;
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
        public int did
        {
            set { _did = value; }
            get { return _did; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int stype
        {
            set { _stype = value; }
            get { return _stype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int smodle
        {
            set { _smodle = value; }
            get { return _smodle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string svaluemin
        {
            set { _svaluemin = value; }
            get { return _svaluemin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string svaluemax
        {
            set { _svaluemax = value; }
            get { return _svaluemax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pmodule
        {
            set { _pmodule = value; }
            get { return _pmodule; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string prolue
        {
            set { _prolue = value; }
            get { return _prolue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pvalue
        {
            set { _pvalue = value; }
            get { return _pvalue; }
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

