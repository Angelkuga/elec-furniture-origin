using System;
namespace TREC.Entity
{
	/// <summary>
	/// productattribute:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnProductAttribute
	{
        public EnProductAttribute()
		{}
        #region Model
        private int _id;
        private int? _productid;
        private string _productno;
        private string _productsku;
        private string _typevalue;
        private string _typename;
        private string _productstyle;
        private string _productmaterial;
        private string _productcolorimg;
        private string _productcolortitle;
        private string _productcolorvalue;
        private decimal? _productwidth;
        private decimal? _productheight;
        private decimal? _productlength;
        private decimal? _productcbm;
        private decimal? _buyprice;
        private decimal? _markprice;
        private decimal? _saleprice;
        private string _otherinfo;
        private int? _storage;
        private int? _sort;
        private int _isdefault;
        private int _ProductAttributePromotion;
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
        public int? productid
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productno
        {
            set { _productno = value; }
            get { return _productno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productsku
        {
            set { _productsku = value; }
            get { return _productsku; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string typevalue
        {
            set { _typevalue = value; }
            get { return _typevalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string typename
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productstyle
        {
            set { _productstyle = value; }
            get { return _productstyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productmaterial
        {
            set { _productmaterial = value; }
            get { return _productmaterial; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productcolorimg
        {
            set { _productcolorimg = value; }
            get { return _productcolorimg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productcolortitle
        {
            set { _productcolortitle = value; }
            get { return _productcolortitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productcolorvalue
        {
            set { _productcolorvalue = value; }
            get { return _productcolorvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? productwidth
        {
            set { _productwidth = value; }
            get { return _productwidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? productheight
        {
            set { _productheight = value; }
            get { return _productheight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? productlength
        {
            set { _productlength = value; }
            get { return _productlength; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? productcbm
        {
            set { _productcbm = value; }
            get { return _productcbm; }
        }
        /// <summary>
        /// 促销价
        /// </summary>
        public decimal? buyprice
        {
            set { _buyprice = value; }
            get { return _buyprice; }
        }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal? markprice
        {
            set { _markprice = value; }
            get { return _markprice; }
        }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal? saleprice
        {
            set { _saleprice = value; }
            get { return _saleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string otherinfo
        {
            set { _otherinfo = value; }
            get { return _otherinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? storage
        {
            set { _storage = value; }
            get { return _storage; }
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
        public int isdefault
        {
            set { _isdefault = value; }
            get { return _isdefault; }
        }
        /// <summary>
        /// 促销活动类型
        /// </summary>
        public int productAttributePromotion
        {
            set { _ProductAttributePromotion = value; }
            get { return _ProductAttributePromotion; }
        }
        #endregion Model

	}
}

