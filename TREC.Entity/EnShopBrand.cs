using System;
namespace TREC.Entity
{
	/// <summary>
	/// admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnShopBrand
	{
        public EnShopBrand()
		{}
        #region Model
        private int _shopid;
        private int _brandid;
        /// <summary>
        /// 
        /// </summary>
        public int shopid
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int brandid
        {
            set { _brandid = value; }
            get { return _brandid; }
        }
        #endregion Model

	}
}

