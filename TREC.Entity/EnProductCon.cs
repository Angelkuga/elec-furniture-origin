using System;
namespace TREC.Entity
{
	/// <summary>
	/// admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class EnProductCon
	{
        public EnProductCon()
		{}
        #region Model
        private int _id;
        private int? _productid;
        private int? _contype;
        private string _con;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? productid
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? contype
        {
            set { _contype = value; }
            get { return _contype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string con
        {
            set { _con = value; }
            get { return _con; }
        }
        #endregion Model

	}
}

