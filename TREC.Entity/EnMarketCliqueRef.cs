using System;

namespace TREC.Entity
{
    /// <summary>
    /// 卖场集团关系类
    /// </summary>
    public class EnMarketCliqueRef
    {
        /// <summary>
        /// 卖场ID
        /// </summary>
        public int MarketId { set; get; }

        /// <summary>
        /// 集团ID
        /// </summary>
        public int MarketCliqueId { set; get; }
    }
}
