using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using TREC.ECommerce;
using TRECommon;
using TREC.Entity;
using TREC.Config;

namespace TREC.Web.Suppler.ajax
{
    /// <summary>
    /// ajaxSupplerValidator 的摘要说明
    /// </summary>
    public class ajaxSupplerValidator : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            switch (GetParams("type", context))
            {
                case "checkcompanytitle":
                    context.Response.Write(GetCompanyTitle(GetParams("txttitle", context)));
                    break;
                case "checkcompanytitle2":
                    context.Response.Write(GetCompanyTitle(GetParams("txtcompanytitle", context)));
                    break;
                case "checkbrandtitle":
                    context.Response.Write(GetBrandTitle(GetParams("txttitle", context)));
                    break;
                case "checkbrandtitlecompany":
                    context.Response.Write(GetBrandTitleCompany(GetParams("txttitle", context), GetParams("CompanyID", context), GetParams("ID", context)));
                    break;
                case "checkbrandtitle2":
                    context.Response.Write(GetBrandTitle(GetParams("txtbrandtitle", context)));
                    break;
                case "checkbrandtitleletter":
                    context.Response.Write(GetBrandTitleLetter(GetParams("txtletter", context)));
                    break;
                case "checkbrandtitleletter2":
                    context.Response.Write(GetBrandTitleLetter(GetParams("txtbrandletter", context)));
                    break;
                case "checkbrandstitle":
                    context.Response.Write(GetBrandsTitle(GetParams("txttitle", context)));
                    break;
                case "checkproductsku":
                    context.Response.Write(GetProductSku(GetParams("txtsku", context)));
                    break;
                case "checkshoptitle":
                    context.Response.Write(GetShopTitle(GetParams("txttitle", context)));
                    break;
                case "checkdealer":
                    context.Response.Write(GetDealerTitle(GetParams("txttitle", context)));
                    break;
                case "checkmarkettitle":
                    context.Response.Write(GetMarketTitle(GetParams("txtmarkettitle", context)));
                    break;
                case "checkmarkettitle2":
                    context.Response.Write(GetMarketTitle(GetParams("txttitle", context)));
                    break;
                case "checkmarketletter":
                    context.Response.Write(GetMarketLetter(GetParams("txtletter", context)));
                    break;
                default:
                    context.Response.Write("找不到数据读取类型");
                    break;
            }
            context.Response.End();
        }

        protected string GetMarketLetter(string letter)
        {
            if (ECMarket.ExitMarketLetter(letter) == 0)
                return letter + " 卖场索引可以添加";
            return letter + " 卖场索引存在!";
        }

        protected string GetMarketTitle(string title)
        {
            if (ECMarket.ExitMarket(title) == 0)
                return title + " 卖场名称可以添加";
            return title + " 卖场名称存在!";
        }
        protected string GetDealerTitle(string title)
        {
            if (ECDealer.ExitDealer(title) == 0)
                return title + " 经销商名称可以添加";
            return title + " 经销商名称被占用!";
        }

        protected string GetCompanyTitle(string title)
        {
            if (ECCompany.ExitComapnyTitle(title) == 0)
                return "该厂商名称可以注册!";
            return "该用厂商名称己存在!";
        }

        protected string GetBrandTitle(string title)
        {
            if (ECBrand.ExitBrandTitle(title) == 0)
                return "该品牌名称可以添加!";
            return "该品牌名称己存在!";
        }
        /// <summary>
        /// 检查厂商品牌重复
        /// </summary>
        /// <param name="title">品牌名</param>
        /// <param name="companyid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetBrandTitleCompany(string title, string companyid, string id)
        {
            string sql = string.Format(" where companyid={0} and id<>{1} and title='{2}' ", companyid, id, title.Trim());
            if (ECBrand.GetBrandInfo(sql) == null)
                return "该品牌名称可以添加!";
            return "该品牌名称己存在!";
        }

        protected string GetBrandTitleLetter(string letter)
        {
            if (ECBrand.ExitBrandTitleLetter(letter) == 0)
                return "该品牌索引可以添加!";
            return "该品牌索引己存在!";
        }

        protected string GetBrandsTitle(string title)
        {
            if (ECBrand.ExitBrandsTitle(title) == 0)
                return "该系列名称可以添加!";
            return "该系列名称己存在!";
        }

        protected string GetProductSku(string sku)
        {
            if (ECProduct.ExitProductSku(sku) == 0)
                return sku + " 产品编号可以添加!";
            return sku + " 产品编号己被占用!";
        }

        protected string GetShopTitle(string title)
        {
            if (ECShop.ExitShopTitle(title) == 0)
                return title + " 店铺名称可以添加!";
            return title + " 店铺名称己被占用!";
        }

        protected string GetParams(string name, HttpContext context)
        {
            return context.Request.QueryString[name] == null ? context.Request.Params[name] == null ? context.Request.Form[name] == null ? "" : context.Request.Form[name].ToString() : context.Request.Params[name].ToString() : context.Request.QueryString[name].ToString();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}