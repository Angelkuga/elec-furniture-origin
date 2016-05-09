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
    public class ECProductCategory
    {
        public static int UpConFilePath(string con, int id)
        {
            return DataCommon.UpdateValue(TableName.TBProductCategory, "descript", con, " where id=" + id);
        }


        #region  Method-ProductCategory
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditProductCategory(EnProductCategory model)
        {
            return ProductCategorys.EditProductCategory(model);
            
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnProductCategory GetProductCategoryInfo(string strWhere)
        {
            return ProductCategorys.GetProductCategoryInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnProductCategory> GetProductCategoryList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return ProductCategorys.GetProductCategoryList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnProductCategory> GetProductCategoryList(string strWhere, out int pageCount)
        {
            return GetProductCategoryList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnProductCategory> GetProductCategoryList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetProductCategoryList(-1, 0, strWhere, out tmpPageCount);
        }

        ///获取数据列表
        public static List<EnProductCategory> GetProductCategoryListToDDL(string strWhere)
        {
            List<EnProductCategory> list = ProductCategorys.GetProductCategoryList("", strWhere);
            foreach (EnProductCategory c in list)
            {
                string sp = "";
                for (int i = 0; i < c.lev; i++)
                {
                    sp = sp + "--";
                }
                c.title = "|" + sp + c.title;

            }
            return list;
        }




        //获取数据列表
        public static List<EnProductCategory> GetProductCategoryList(string fields, string strWhere)
        {
            return ProductCategorys.GetProductCategoryList(fields, strWhere);
        }



        //获取数据列表ToDataTable
        public static DataTable GetProductCategoryListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBProductCategory, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }



        ///删除对象
        public static int DeleteProductCategory(int id)
        {
            return DeleteProductCategory(" where id=" + id);
        }
        ///删除对象
        public static int DeleteProductCategoryByIdList(string idList)
        {
            return DeleteProductCategory(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteProductCategory(string strWhere)
        {
            return DataCommon.Delete(TableName.TBProductCategory, strWhere);
        }
        #endregion


        #region 
        /// <summary>
        /// 获取所有产品类型
        /// shen 2015-02-04
        /// </summary>
        public void ProductCategoryList() {
            ProductCategorys.ProductCategoryList();
        }
        #endregion
    }
}
