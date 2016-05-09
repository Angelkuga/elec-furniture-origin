using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Entity;
using TREC.Data;
using TRECommon;
using TREC.Data.Provide;

namespace TREC.ECommerce
{
    /// <summary>
    /// 活动类型BLL
    /// </summary>
    public class t_promotionstypeBLL
    {
        /// <summary>
        /// 获取活动类型数据
        /// </summary>
        /// <returns></returns>
        public static List<t_promotionstype> GetPromotionTypeList()
        {
            return t_promotionstypeDAL.GetPromotionTypeList();
        }

        /// <summary>
        /// 根据id获取活动类型数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static t_promotionstype GetPromotionTypeById(int ids)
        {
            return t_promotionstypeDAL.GetPromotionTypeById(ids);
        }
    }
}
