using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Suppler
{
    public partial class Member : System.Web.UI.MasterPage
    {
        protected string _menuName = string.Empty;//菜单名称
        public string EnterpriseName = "";
        public string CompanyLogo = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //  new SupplerPageBase().mySupplerPageBase();
                    EnMember memberinfo = SupplerPageBase.memberInfo;
                    if (memberinfo == null)
                    {
                        if (memberinfo.type != 105)//更改为集团标识
                        {

                        }
                        Response.Redirect(ECommon.WebUrl + "index.aspx");
                    }
                    #region 判断用户类型

                    switch (memberinfo.type)
                    {
                        case (int)EnumMemberType.集团:
                            SupplerPageBase.menuList = ECMenu.GetMenuList("", " where module=21", "");
                            if (SupplerPageBase.marketInfo != null)
                            {
                                EnterpriseName = SupplerPageBase.marketInfo.title;
                                CompanyLogo = GetCompnyLogo((int)EnumMemberType.集团);
                            }
                            else
                                EnterpriseName = string.Empty;
                            break;
                        case (int)EnumMemberType.工厂企业:
                            #region 工厂企业

                            //if (SupplerPageBase.companyInfo != null && SupplerPageBase.companyInfo.id != 0)
                            //{
                            //if (SupplerPageBase.companyInfo.title == null || SupplerPageBase.companyInfo.title == "" || SupplerPageBase.companyInfo.phone == null || SupplerPageBase.companyInfo.phone == "" || SupplerPageBase.companyInfo.address == null || SupplerPageBase.companyInfo.address == "")
                            //{
                            //    Response.Redirect("f_company/setup1.aspx");
                            //}

                            //if (SupplerPageBase.brandidlist == "0" || SupplerPageBase.brandList == null || SupplerPageBase.brandList.Count <= 0)
                            //{
                            //    Response.Redirect("f_company/setup2.aspx");
                            //}

                            //if (SupplerPageBase.brandidlist == "0" || ECBrand.GetBrandsList(" brandid in (" + SupplerPageBase.brandidlist + ")").Count <= 0)
                            //{
                            //    Response.Redirect("f_company/setup3.aspx");
                            //}

                            //}
                            //else
                            //{
                            //    Response.Redirect("supplerindex.aspx");
                            //}
                            SupplerPageBase.menuList = ECMenu.GetMenuList("", " where module=15", "");
                            if (SupplerPageBase.companyInfo != null)
                            {
                                EnterpriseName = SupplerPageBase.companyInfo.title;
                                CompanyLogo = GetCompnyLogo((int)EnumMemberType.工厂企业);
                            }
                            else
                                EnterpriseName = string.Empty;
                            break;
                            #endregion

                        case (int)EnumMemberType.经销商:
                            #region 经销商

                            //if (SupplerPageBase.dealerInfo != null && SupplerPageBase.dealerInfo.id != 0)
                            //{
                            //    if (SupplerPageBase.dealerInfo.title == null || SupplerPageBase.dealerInfo.title == "" || SupplerPageBase.dealerInfo.phone == null || SupplerPageBase.dealerInfo.phone == "" || SupplerPageBase.dealerInfo.address == null || SupplerPageBase.dealerInfo.address == "")
                            //    {
                            //        Response.Redirect("f_dealer/setup1.aspx");
                            //    }

                            //    //if (SupplerPageBase.brandList == null || SupplerPageBase.brandList.Count <= 0)
                            //    //{

                            //    //    Response.Redirect("f_dealer/setup2.aspx");
                            //    //}

                            //    //if (SupplerPageBase.brandidlist == "0")// || ECBrand.GetBrandsList(" brandid in (" + SupplerPageBase.brandidlist + ")").Count <= 0)
                            //    //{
                            //    //    Response.Redirect("f_dealer/setup3.aspx");
                            //    //}

                            //}
                            //else
                            //{
                            //    Response.Redirect("supplerindex.aspx");
                            //}

                            SupplerPageBase.menuList = ECMenu.GetMenuList("", " where module=16", "");
                            if (SupplerPageBase.dealerInfo != null)
                            {
                                EnterpriseName = SupplerPageBase.dealerInfo.title;
                                CompanyLogo = GetCompnyLogo((int)EnumMemberType.经销商);
                            }
                            else
                                EnterpriseName = string.Empty;
                            break;
                            #endregion
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
                    #endregion

                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('帐号异常,请重新登陆');location.href='/loginuser.aspx';</script>");
            }
        }


        public string ShowOrderList()
        {
            try
            {
                EnMember memberinfo = SupplerPageBase.memberInfo;
                string noread = string.Empty;
                if (SupplerPageBase.getOrderNoRead != "0")
                {
                    noread = "<span style='color:red;margin-left:20px;'>[" + SupplerPageBase.getOrderNoRead + "笔未查看]</span>";
                }
                //string div = "<div style=\"position:relative;display:none;\" id=\"divshowpay\"> <div style=\"position:absolute;\" class='paystat'>您还未开通会员权限，无法查看！</div></div>";
                string div = " ";
                string payuser = "<li><a href=\"/suppler/market/orderListmanage.aspx\">查看订单</a>" + noread + "</li>";

                string nopay = div + "<li   onclick=\"messagedshow(event)\"><a href=\"javascript:void(0);\" >查看订单" + noread + "</a> </li>";

                if (SupplerPageBase.IsPayMember())
                {
                    return payuser;
                }
                else
                {
                    return nopay;
                }
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 权限访问设置
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string ShowOrderList(string url)
        {
            try
            {
                if (SupplerPageBase.IsPayMember())
                {
                    return "<a href=\"" + url + "\">";
                }
                else
                {
                    return "<a href='javascript:void(0);'  onclick=\"messagedshow(event)\">";
                }
            }
            catch {
                return "<a href=\"" + url + "\">";
            }
        }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string menuName
        {
            get { return _menuName; }
            set { _menuName = value; }
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
                    output =ebrand.logo.ToLower().Contains("http:")?ebrand.logo.TrimEnd(','): "/upload/brand/logo/" + ebrand.id.ToString() + "/" + ebrand.logo.TrimEnd(',');
            }
            else if (types == (int)EnumMemberType.经销商)
            {
                EnAppBrand eappbrand = ECommerce.ECAppBrand.GetAppBrandList(" dealerid=" + SupplerPageBase.dealerInfo.id).FirstOrDefault();
                if (eappbrand != null)
                {
                    EnBrand ebrand = ECommerce.ECBrand.GetBrandList(" logo<>'' and id=" + eappbrand.brandid).FirstOrDefault();
                    if (ebrand != null && ebrand.logo != null)
                        output =ebrand.logo.ToLower().Contains("http:")?ebrand.logo.TrimEnd(','): "/upload/brand/logo/" + ebrand.id.ToString() + "/" + ebrand.logo.TrimEnd(',');
                }
            }
            else if (types == (int)EnumMemberType.卖场)
            {
                EnMarket emarker = ECommerce.ECMarket.GetMarketInfo(" where id =" + SupplerPageBase.marketInfo.id);
                if (emarker != null && emarker.logo != null)
                {
                    output = emarker.logo.ToLower().Contains("http:") ? emarker.logo.TrimEnd(',') : "/upload/market/logo/" + emarker.id.ToString() + "/" + emarker.logo.TrimEnd(',');
                }
            }
            else if (types == (int)EnumMemberType.集团)
            {
                EnMember memberinfo = SupplerPageBase.memberInfo;
             EnMarketClique   model = ECommerce.ECMarketClique.GetMarketCliqueByWhere("WHERE createmid=" + memberinfo.id);
             if (model != null && model.LogImg!=null)
             {
                 output = model.LogImg.Contains("http:") ? model.LogImg.TrimEnd(',') : "";
             }
            }
            return output;
        }
    }
}