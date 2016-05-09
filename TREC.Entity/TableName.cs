using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    public class TableName
    {

        #region 权限
        public static string TBSystemModule = "t_sys_module";
        public static string TBSystemModuleLink = "t_sys_module_link";
        public static string TBSystemAction = "t_sys_action";
        public static string TBSystemRole = "t_sys_role";
        public static string TBRoleActionDef = "t_sys_roleactiondef";
        #endregion

        #region 管理员

        public static string TBAdmin = "t_admin";

        #endregion 

        //广告及广告分类
        public static string TBAdvertisement = "t_advertising";
        public static string TBAdvertisementCategory = "t_advertisingcategory";



        #region 成员
        public static string TBSms = "t_sms";
        public static string TBMsgCollection = "t_MsgCollection";
        public static string TBMember = "t_member"; //登陆账号
        public static string TBMemberRecycle = "t_memberrecycle"; //登陆账号回收站表
        public static string TBCompany = "t_company"; //企业表
        public static string TBDealer = "t_dealer"; //经销商表
        public static string TBShop = "t_shop"; //店铺表
        public static string TBRecycleShop = "t_shoprecycle"; //回收站店铺表
        public static string TBShopBrand = "t_shopbrand";
        public static string TBMarket = "t_market"; //卖场表
        public static string TBMarketStorey = "t_marketstorey"; //卖场楼层表
        public static string TBMarketStoreyShop = "t_marketstoreyshop"; //卖场表楼层店铺


        public static string TBMemberGroup = "t_membergroup"; //登陆账号
        public static string TBCompanyGroup = "t_companygroup"; //企业表
        public static string TBDealerGroup = "t_dealergroup"; //经销商表
        public static string TBShopGroup = "t_shopgroup"; //店铺表
        public static string TBMarketGroup = "t_marketgroup"; //卖场表

        #endregion


        public static string TBArticle = "t_article";
        public static string TVArticle = "v_article";
        public static string TBArticleCategory = "t_articlecategory";
        public static string TPArticleCategoryUp = "MoveArticleNodeUp";
        public static string TBColorswatch = "t_colorswatch";
        public static string TVSeriesSwatch = "V_SeriesSwatch";
        public static string TVSeriesSwatchRecycle = "V_SeriesSwatchRecycle";
        
        

        public static string TBBrand = "t_brand";
        public static string TBRecycleBrand = "t_brandrecycle";
        public static string TBBrands = "t_brands";
        public static string TBViewBrands = "v_brands";
        public static string TBViewRecycleBrands = "v_brandsrecycle";
        public static string TBAppBrand = "t_appbrand";



        public static string TBArea = "t_area";
        public static string TBConfig = "t_config";
        public static string TBConfigType = "t_configtype";
        public static string TBMenu = "t_menu";
        public static string TBLog = "t_log";



        public static string TBAggregation = "t_aggregation";
        public static string TBAggregationType = "t_aggregationtype";
        public static string TBPromotion = "t_promotion";
        public static string TBPromotionDef = "t_promotiondef";
        public static string TBPromotionStage = "t_promotionstage";



        public static string TBProduct = "t_product";
        public static string TBProductShopList = "V_productShopList";
        /// <summary>
        /// 产品回收站
        /// </summary>
        public static string TBproductrecyclerecycle = "t_productrecyclerecycle";//产品回收站        
        public static string TBProductCategory = "t_productcategory";
        public static string TBProductAttribute = "t_productattribute";
        public static string TBProductCon = "t_productcon";

        public static string TBPCategoryPTyp = "t_pcategoryptypedef";


        public static string TBGroupOrder = "t_grouporder";
        public static string TBGroupOrderPay = "t_grouporderpay";
        public static string TBGroupOrderProduct = "t_grouporderproduct";

        public static string TBPromotionAppBrand = "t_promotionappbrand";

        public static string TBAppBrandCustomer = "t_appbrandcustomer";
        public static string TBAppBrandProduct = "t_promotionappproduct";

        public static string TBMerchants = "t_Merchants";
        public static string TBMerchantsMember = "t_MerchantsMember";

        public static string TBLink = "t_links";
        public static string TBProductshopprice = "t_productshopprice";

        #region 视图

        public static string TVBrand = "v_brand";

        public static string TVCompanyList = "v_compalylistByC";
        public static string TVCompanyBrandList = "v_companylistByB";
        public static string TVShopList = "v_shoplistByS";
        public static string TVShopBrandList = "v_shoplistByB";
        public static string TVProduct = "v_product";
        public static string TVMarket = "v_marketlist";
        public static string TVMarketStoreyShop = "v_marketstoreyshoplist";

        public static string TVCompanySearchItem = "v_companysearchitem";
        public static string TVShopSearchItem = "v_shopsearchitem";
        public static string TVProductSearchItem = "v_productsearchitem";
        public static string TVMarketSearchItem = "v_marketsearchitem";
        public static string TVAggregation = "v_aggregation";
        public static string TVPromotion = "v_promotion";
        public static string TVAdvertising="v_advertising";


        public static string TVAllBrand = "v_allbrand";
        public static string TVPromotionInfoList = "v_promotioninfolist";

        public static string TVMerchantsList = "v_MerchantsList";

        #region 后台列表专用视图
        public static string TVAdminCompanyList = "v_Admin_CompanyList";
        public static string TVAdminDealerList = "v_Admin_DealerList";
        public static string TVAdminBrandList = "v_Admin_BrandList";
        public static string TVAdminBrandsList = "v_Admin_BrandsList";
        #endregion

        #endregion
    }
}
