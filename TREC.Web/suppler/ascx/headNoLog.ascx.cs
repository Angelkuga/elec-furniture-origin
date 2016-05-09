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
    public partial class headNoLog : System.Web.UI.UserControl
    {

        public string EnterpriseName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SupplerPageBase.memberInfo == null)
            {
                Response.Redirect(ECommon.WebUrl + "/login.aspx");
                return;
            }
            else
            {
                switch (SupplerPageBase.memberInfo.type)
                {
                    case (int)EnumMemberType.工厂企业:
                        SupplerPageBase.menuList = ECMenu.GetMenuList("", " where module=15", "");
                        if (SupplerPageBase.companyInfo != null)
                            EnterpriseName = SupplerPageBase.companyInfo.title;
                        else
                            EnterpriseName = string.Empty;
                        break;
                    case (int)EnumMemberType.经销商:
                        SupplerPageBase.menuList = ECMenu.GetMenuList("", " where module=16", "");
                        if (SupplerPageBase.dealerInfo != null)
                            EnterpriseName = SupplerPageBase.dealerInfo.title;
                        else
                            EnterpriseName = string.Empty;
                        break;
                    case (int)EnumMemberType.卖场:
                        SupplerPageBase.menuList = ECMenu.GetMenuList("", " where module=17", "");
                        if (SupplerPageBase.marketInfo != null)
                            EnterpriseName = SupplerPageBase.marketInfo.title;
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
        }
    }
}