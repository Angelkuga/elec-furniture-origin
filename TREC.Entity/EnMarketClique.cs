using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    /// <summary>
    /// 卖场集团类
    /// </summary>
    public class EnMarketClique
    {
        /// <summary>
        /// 集团ID
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 集团的主卖场ID
        /// </summary>
        public int MarketId { set; get; }

        /// <summary>
        /// 集团名称
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// 董事长
        /// </summary>
        public string Chairman { set; get; }

        /// <summary>
        /// 董事长致辞
        /// </summary>
        public string ChairmanOration { set; get; }

        /// <summary>
        /// 集团描述
        /// </summary>
        public string Descript { set; get; }

        /// <summary>
        /// 审核状态 待审核=0,正在审核=-1,通过=1,未通过=-99,
        /// </summary>
        public int Auditstatus { set; get; }

        /// <summary>
        /// 董事长照片
        /// </summary>
        public string ChairmanImg { set; get; }

        /// <summary>
        /// 集团缩略图
        /// </summary>
        public string ThumbImg { set; get; }

        /// <summary>
        /// 集团形象大图
        /// </summary>
        public string InfoImg { set; get; }

        public string LogImg { set; get; }
        
        /// <summary>
        /// 创建用户ID
        /// </summary>
        public int CreateMid { set; get; }

        public int Mid { set; get; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastediTime { set; get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { set; get; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
