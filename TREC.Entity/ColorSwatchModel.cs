using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    /// <summary>
    /// 色板数据类
    /// </summary>
    public class ColorSwatchModel
    {
        /// <summary>
        /// 色板id
        /// </summary>
        public int csid { get; set; }

        /// <summary>
        /// 色板名称
        /// </summary>
        public string SwatchName { get; set; }

        /// <summary>
        /// 类别id
        /// </summary>
        public int CategroyId { get; set; }

        /// <summary>
        /// 色板图片
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// 用户名（创建人）
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 系列名称
        /// </summary>
        public string SeriesName { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategroyName { get; set; }

        /// <summary>
        /// 系列id
        /// </summary>
        public int SeriesId { get; set; }

        /// <summary>
        /// 品牌id
        /// </summary>
        public int BrandId { get; set; }
    }
}