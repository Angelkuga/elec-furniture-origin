using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TREC.Entity;
using TREC.Data;
using TRECommon;


namespace TREC.ECommerce
{
    public class ECProductAttribute
    {

           #region 删除多余的产品属性信息
        /// <summary>
        /// 删除多余的产品属性信息
        /// </summary>
        /// <param name="strwhere">where 条件 where id='</param>
        /// <returns></returns>
        public static int DelProductAttribute(string strwhere)
        {
            return ProductAttributes.DelProductAttribute(strwhere);
        }
           #endregion
        #region  Method-ProductAttribute
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditProductAttribute(EnProductAttribute model)
        {
            return ProductAttributes.EditProductAttribute(model);
            
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="strWhere">where 条件（where id=11）</param>
        /// <returns></returns>
        public static EnProductAttribute GetProductAttributeInfo(string strWhere)
        {
            return ProductAttributes.GetProductAttributeInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnProductAttribute> GetProductAttributeList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return ProductAttributes.GetProductAttributeList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnProductAttribute> GetProductAttributeList(string strWhere, out int pageCount)
        {
            return GetProductAttributeList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnProductAttribute> GetProductAttributeList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetProductAttributeList(-1, 0, strWhere, out tmpPageCount);
        }

        ///按照shopid获取数据列表
        public static List<EnProductAttribute> GetProductAttributeListByShopId(string shopId)
        {
            return ProductAttributes.GetProductAttributeListByShopId(shopId);
        }

        //获取数据列表ToDataTable
        public static DataTable GetProductAttributeListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBProductAttribute, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteProductAttribute(int id)
        {
            return DeleteProductAttribute(" where id=" + id);
        }
        ///删除对象
        public static int DeleteProductAttributeByIdList(string idList)
        {
            return DeleteProductAttribute(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteProductAttribute(string strWhere)
        {
            return DataCommon.Delete(TableName.TBProductAttribute, strWhere);
        }
        #endregion
    }
}
