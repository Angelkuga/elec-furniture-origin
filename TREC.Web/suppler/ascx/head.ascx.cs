using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler.ascx
{
    public partial class head : System.Web.UI.UserControl
    {

        public string EnterpriseName = "";
        public string CompanyLogo = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SupplerPageBase.memberInfo == null)
            {
                Response.Redirect(ECommon.WebUrl + "/login.aspx");
            }

            switch (SupplerPageBase.memberInfo.type)
            {
                case (int)EnumMemberType.工厂企业:
                    SupplerPageBase.menuList = ECMenu.GetMenuList("", " where module=15", "");
                    if (SupplerPageBase.companyInfo != null)
                    {
                        
                        EnterpriseName = SupplerPageBase.companyInfo.title;
                        CompanyLogo = GetCompnyLogo((int)EnumMemberType.工厂企业);
                    }
                    else
                        EnterpriseName = string.Empty;
                    break;
                case (int)EnumMemberType.经销商:
                    SupplerPageBase.menuList = ECMenu.GetMenuList("", " where module=16", "");
                    if (SupplerPageBase.dealerInfo != null)
                    {
                        EnterpriseName = SupplerPageBase.dealerInfo.title;
                        CompanyLogo = GetCompnyLogo((int)EnumMemberType.经销商);
                    }
                    else
                        EnterpriseName = string.Empty;
                    break;
                case (int)EnumMemberType.卖场:
                    SupplerPageBase.menuList = ECMenu.GetMenuList("", " where module=17", "");
                    if (SupplerPageBase.marketInfo != null)
                    {
                        EnterpriseName = SupplerPageBase.marketInfo.title;
                        CompanyLogo = GetCompnyLogo((int)EnumMemberType.卖场);
                    }
                    else
                        EnterpriseName = string.Empty;
                    break;
                case (int)EnumMemberType.店铺管理员:
                    SupplerPageBase.menuList = ECMenu.GetMenuList("", " where module=18", "");
                    if (SupplerPageBase.shopInfo != null)
                        EnterpriseName = SupplerPageBase.shopInfo.title;
                    else
                        EnterpriseName = string.Empty;
                    break;
            }
        }


        /// <summary>
        /// 用户后台LOGO
        /// </summary>
        /// <param name="types">用户类型</param>
        /// <returns></returns>
        protected string GetCompnyLogo(int types)
        {
            string output = string.Empty;
            if (types == (int)EnumMemberType.工厂企业)
            {
                EnBrand ebrand = ECommerce.ECBrand.GetBrandList(" logo<>'' and companyid=" + SupplerPageBase.companyInfo.id).FirstOrDefault();
                if (ebrand != null && ebrand.logo != null)
                    output = "/upload/brand/logo/" + ebrand.id.ToString() + "/" + ebrand.logo.TrimEnd(',');
            }
            else if (types == (int)EnumMemberType.经销商)
            {
                EnAppBrand eappbrand = ECommerce.ECAppBrand.GetAppBrandList(" dealerid=" + SupplerPageBase.dealerInfo.id).FirstOrDefault();
                if (eappbrand != null)
                {
                    EnBrand ebrand = ECommerce.ECBrand.GetBrandList(" logo<>'' and id=" + eappbrand.brandid).FirstOrDefault();
                    if (ebrand != null && ebrand.logo != null)
                        output = "/upload/brand/logo/" + ebrand.id.ToString() + "/" + ebrand.logo.TrimEnd(',');
                }
            }
            else if (types == (int)EnumMemberType.卖场)
            {
                EnMarket emarker = ECommerce.ECMarket.GetMarketInfo(" where id =" + SupplerPageBase.marketInfo.id);
                if (emarker != null && emarker.logo != null)
                {
                    output = "/upload/market/logo/" + emarker.id.ToString() + "/" + emarker.logo.TrimEnd(',');
                }
            }
            return output;
        }
    }
}