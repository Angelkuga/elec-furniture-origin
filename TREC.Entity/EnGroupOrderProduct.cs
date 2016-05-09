using System;
namespace TREC.Entity
{
	/// <summary>
	/// grouporderproduct:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnGroupOrderProduct
	{
        public EnGroupOrderProduct()
		{}
        #region Model
        private int _id;
        private int? _grouporderid;
        private string _grouporderno;
        private int? _promotionid;
        private int? _promotiondefid;
        private int? _promoteionstageid;
        private string _promoteionstagevalue;
        private int? _productid;
        private int? _productattributeid;
        private string _productcode;
        private string _productname;
        private string _color;
        private string _material;
        private string _size;
        private decimal? _cbm;
        private int? _num;
        private decimal? _price;
        private decimal? _totalmoney;
        private decimal? _proprice;
        private decimal? _prototalmoney;
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
        public int? grouporderid
        {
            set { _grouporderid = value; }
            get { return _grouporderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string grouporderno
        {
            set { _grouporderno = value; }
            get { return _grouporderno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? promotionid
        {
            set { _promotionid = value; }
            get { return _promotionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? promotiondefid
        {
            set { _promotiondefid = value; }
            get { return _promotiondefid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? promoteionstageid
        {
            set { _promoteionstageid = value; }
            get { return _promoteionstageid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string promoteionstagevalue
        {
            set { _promoteionstagevalue = value; }
            get { return _promoteionstagevalue; }
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
        public int? productattributeid
        {
            set { _productattributeid = value; }
            get { return _productattributeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productcode
        {
            set { _productcode = value; }
            get { return _productcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productname
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string color
        {
            set { _color = value; }
            get { return _color; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string material
        {
            set { _material = value; }
            get { return _material; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cbm
        {
            set { _cbm = value; }
            get { return _cbm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? num
        {
            set { _num = value; }
            get { return _num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? totalmoney
        {
            set { _totalmoney = value; }
            get { return _totalmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? proprice
        {
            set { _proprice = value; }
            get { return _proprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? prototalmoney
        {
            set { _prototalmoney = value; }
            get { return _prototalmoney; }
        }
        #endregion Model

	}
}

