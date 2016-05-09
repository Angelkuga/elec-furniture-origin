using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Entity;
using TREC.Data;

namespace TREC.ECommerce
{
    public class ECProductShopPrice
    {
        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditProductShopPrice(EnProductShopPrice model)
        {
            return ProductShopPrice.EditProductShopPrice(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnProductShopPrice GetProductShopPriceInfo(string strWhere)
        {
            return ProductShopPrice.GetProductShopPriceInfo(strWhere);
        }

         /// <summary>
        /// 获取店铺ids
        /// </summary>
        /// <param name="strWere">where条件，（id=1 and uid= ）</param>
        /// <returns></returns>
        public static List<EnProductShopPrice> GetProductShopPriceListByWhere(string strWere)
        {
            return ProductShopPrice.GetProductShopPriceListByWhere(strWere);
        }
        /// <summary>
        /// 得到对象实体List
        /// </summary>
        public static List<EnProductShopPrice> GetProductShopPriceListByShopId(string shopid)
        {
            return ProductShopPrice.GetProductShopPriceListByShopId(shopid);
        }


        ///删除对象
        public static int DeletProductShopPriceByIdList(string idList)
        {
            return DeleteProductShopPrice(" where id in (" + idList + ")");
        }

        ///删除对象
        public static int DeleteProductShopPrice(string strWhere)
        {
            return DataCommon.Delete(TableName.TBProductshopprice, strWhere);
        }
        #endregion
    }
}
