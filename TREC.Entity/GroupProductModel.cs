using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    /// <summary>
    /// 套组合产品数据类
    /// </summary>
    public class GroupProductModel
    {
        /// <summary>
        /// 产品id
        /// </summary>
        public int gpId { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 品牌id
        /// </summary>
        public int brandId { get; set; }

        /// <summary>
        /// 大类id
        /// </summary>
        public int bigCateId { get; set; }
        /// <summary>
        /// 小类id
        /// </summary>
        public int smallCateId { get; set; }
        /// <summary>
        /// 风格id
        /// </summary>
        public int styleId { get; set; }

        /// <summary>
        /// 材质id
        /// </summary>
        public int MaterialId { get; set; }

        /// <summary>
        /// 系列id
        /// </summary>
        public int SeriesId { get; set; }

        /// <summary>
        /// 色系id
        /// </summary>
        public int ColorId { get; set; }

        /// <summary>
        /// 是否组装（1表示组装）
        /// </summary>
        public int IsGroup { get; set; }

        /// <summary>
        /// 套餐价（套组合价）
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// 整体图
        /// </summary>
        public string thumb { get; set; }

        /// <summary>
        /// 局部图
        /// </summary>
        public string bannel { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        public string Descript { get; set; }

        /// <summary>
        /// 发布人
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 最后一次修改人
        /// </summary>
        public string ModifyUser { get; set; }

        /// <summary>
        /// 最后一次修改日期
        /// </summary>
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 状态（0表示已下线；1表示申请上线中；2表示已上线）
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 所属店铺id
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// 销量
        /// </summary>
        public int Sale { get; set; }

        /// <summary>
        /// 库存（-1表示长期供货）
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        ///创建人id
        /// </summary>
        public int createmid { get; set; }
        /// <summary>
        ///公司id
        /// </summary>
        public int companyid { get; set; }
        /// <summary>
        /// 参加活动id
        /// </summary>
        public int groupProductPromotion { get; set; }
        /// <summary>
        /// 套组合 产品推荐属性
        /// </summary>
        public string Attribute { get; set; }
        /// <summary>
        /// 套组合 产品排序
        /// </summary>
        public int Sort { get; set; }
         
    }
}