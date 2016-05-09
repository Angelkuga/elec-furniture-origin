using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    public class CacheKey
    {
        public const string BrandLetter = "brandletter"; //品牌按字母索引
        public const string MarketLetter = "marketletter"; //卖场按字母索引
        public const string arealist = "arealist";


        public const string ConfigList = "configlist";
        public const string CompanySearchItemList = "companysearchitemlist";
        public const string ShopSearchItemList = "shopsearchitemlist";
        public const string ProductSearchItemList = "productsearchitemlist";
        public const string MarketProductSearchItemTypeList = "marketproductsearchitemlist_{0}";
        public const string MarketSearchItemList = "marketsearchitemlist";

        public const string IndexAggregation = "indexaggregation";
        public const string CommonAggregation = "commonaggregation";



        //New Cache Name 
        //Add Rafer
        /// <summary>
        /// 根据条件查询工厂信息
        /// </summary>
        public const string webcompanyinfowhere = "webcompanyinfowhere";

    }
}
