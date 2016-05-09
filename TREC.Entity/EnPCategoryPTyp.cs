using System;
namespace TREC.Entity
{
	/// <summary>
	/// admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnPCategoryPTyp
	{
        public EnPCategoryPTyp()
		{}
        #region Model
        private int _productcategoryid;
        private int _producttypeid;
        /// <summary>
        /// 
        /// </summary>
        public int productcategoryid
        {
            set { _productcategoryid = value; }
            get { return _productcategoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int producttypeid
        {
            set { _producttypeid = value; }
            get { return _producttypeid; }
        }
        #endregion Model

	}
}

