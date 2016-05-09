using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TREC.Entity;
using TRECommon;

namespace TREC.ECommerce
{
    public class SupplerPageBase:System.Web.UI.Page
    {
        public static EnMember memberInfo = null;
        public static EnCompany companyInfo = null;
        public static EnDealer dealerInfo = null;
        public static EnMarket marketInfo = null;
        public static EnShop shopInfo = null;
        public static List<EnBrand> brandList = new List<EnBrand>();
        public static string _memberType;

        public static string memberTypeName
        {
            get
            {
                if (memberInfo == null) { return "未登陆"; }
                return _memberType;
            }
            set
            {
                _memberType = value;
            }
        }
        public int tmpPageCount = 0;
        public static string brandidlist = "";
        public string dealerCreateBrandIdList = "";
        public int memberObjId = 0;
        public static List<EnMenu> menuList = new List<EnMenu>();


        public SupplerPageBase()
        {
            try
            {
                if (CookiesHelper.GetCookie("mid") == "" ||
                    CookiesHelper.GetCookie("mname") == "" ||
                    CookiesHelper.GetCookie("mpwd") == "")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(),
                        System.Guid.NewGuid().ToString(),
                        "<script>window.top.location.href='" + ECommon.WebUrl + "/login.aspx" + "'</script>"
                        );
                    return;
                }

                memberInfo = ECMember.GetMemberInfo(" where id=" + CookiesHelper.GetCookie("mid") + " and password='" + CookiesHelper.GetCookie("mpwd") + "'");
                if (memberInfo == null)
                {
                    HttpContext.Current.Response.Redirect(ECommon.WebUrl + "loginout.aspx");
                    return;
                }

                #region 转换用户类型
                int id = 0;
                switch (memberInfo.type)
                {
                    #region 个人用户

                    case (int)EnumMemberType.个人成员:
                        memberTypeName = Enum.GetName(typeof(EnumMemberType), EnumMemberType.个人成员);
                        companyInfo = null;
                        dealerInfo = null;
                        marketInfo = null;
                        shopInfo = null;
                        //ScriptUtils.RedirectFrame(this.Page, ECommon.WebUrl);

                        // return;
                        break;
                    #endregion

                    #region 工厂企业

                    case (int)EnumMemberType.工厂企业:
                        memberTypeName = Enum.GetName(typeof(EnumMemberType), EnumMemberType.工厂企业);
                        int.TryParse(memberInfo.parentid.ToString(), out id);
                        if (id == 0)
                        {
                            id = memberInfo.id;
                        }
                        companyInfo = ECCompany.GetCompanyInfo(" where mid=" + id);
                        if (companyInfo == null)
                        {
                            HttpContext.Current.Response.Redirect(ECommon.WebUrl + "loginout.aspx");
                            return;
                        }
                        brandList = ECBrand.GetBrandList(" companyid=" + companyInfo.id);
                        //brandList = ECBrand.GetBrandList("");
                        memberObjId = companyInfo.id;
                        brandidlist = "";
                        if (brandList.Count > 0)
                        {
                            foreach (EnBrand b in brandList)
                            {
                                brandidlist += b.id + ",";
                            }
                            brandidlist = brandidlist.Length > 0 && brandidlist.EndsWith(",") ? brandidlist.Substring(0, brandidlist.Length - 1) : brandidlist;
                        }
                        else
                        {
                            brandList = null;
                            brandList = new List<EnBrand>();
                        }
                        brandidlist = string.IsNullOrEmpty(brandidlist) ? "0" : brandidlist;
                        //Modify：rafer 
                        //Date：2012-4-20
                        List<EnBrands> appCompanyList = ECBrand.GetBrandsList(" createmid=" + id);
                        if (appCompanyList.Count > 0)
                        {
                            foreach (EnBrands b in appCompanyList)
                            {
                                dealerCreateBrandIdList += b.brandid + ",";
                            }
                            dealerCreateBrandIdList = dealerCreateBrandIdList.Length > 0 && dealerCreateBrandIdList.EndsWith(",") ? dealerCreateBrandIdList.Substring(0, dealerCreateBrandIdList.Length - 1) : dealerCreateBrandIdList;
                        }
                        break;
                    #endregion

                    #region 经销商

                    case (int)EnumMemberType.经销商:
                        memberTypeName = Enum.GetName(typeof(EnumMemberType), EnumMemberType.经销商);
                        int.TryParse(memberInfo.parentid.ToString(), out id);
                        if (id == 0)
                        {
                            id = memberInfo.id;
                        }
                        dealerInfo = ECDealer.GetDealerInfo(" where mid=" + id);
                        memberObjId = dealerInfo.id;
                        if (dealerInfo == null)
                        {
                            HttpContext.Current.Response.Redirect(ECommon.WebUrl + "loginout.aspx");
                            return;
                        }
                        List<EnAppBrand> appList = ECAppBrand.GetAppBrandList(" dealerid=" + dealerInfo.id);
                        brandidlist = "";
                        foreach (EnAppBrand b in appList)
                        {
                            if (b.appmodule == (int)EnumAppBrandModule.经销商申请 && b.apptype == (int)EnumAppBrandType.申请新建品牌)
                            {
                                dealerCreateBrandIdList += b.brandid + ",";
                            }
                            brandidlist += b.brandid + ",";
                        }
                        brandidlist = brandidlist.Length > 0 && brandidlist.EndsWith(",") ? brandidlist.Substring(0, brandidlist.Length - 1) : brandidlist;
                        dealerCreateBrandIdList = dealerCreateBrandIdList.Length > 0 && dealerCreateBrandIdList.EndsWith(",") ? dealerCreateBrandIdList.Substring(0, dealerCreateBrandIdList.Length - 1) : dealerCreateBrandIdList;
                        if (brandidlist.Length > 0)
                        {
                            brandList = ECBrand.GetBrandList(" id in(" + brandidlist + ")");
                        }
                        else
                        {
                            brandList = null;
                            brandList = new List<EnBrand>();
                        }
                        brandidlist = string.IsNullOrEmpty(brandidlist) ? "0" : brandidlist;
                        break;
                    #endregion

                    #region 卖场和店铺管理员

                    case (int)EnumMemberType.卖场:
                        memberTypeName = Enum.GetName(typeof(EnumMemberType), EnumMemberType.卖场);
                        marketInfo = ECMarket.GetMarketInfo(" where mid=" + memberInfo.id);
                        break;
                    case (int)EnumMemberType.店铺管理员:
                        memberTypeName = Enum.GetName(typeof(EnumMemberType), EnumMemberType.店铺管理员);
                        shopInfo = ECShop.GetShopInfo(" where mid=" + memberInfo.id);
                        break;
                    #endregion

                }

                #endregion

            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('帐号异常,请重新登陆');location.href='/loginuser.aspx';</script>");
            }

        }
        #region 设置权限
        
        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <param name="companyInfo"></param>
        /// <param name="dealerInfo"></param>
        /// <param name="marketInfo"></param>
        /// <param name="shopInfo"></param>
        /// <param name="mid"></param>
        /// <param name="companyid"></param>
        /// <param name="dealerid"></param>
        /// <param name="marketid"></param>
        /// <param name="shopid"></param>
        /// <param name="brandid"></param>
        /// <param name="controls"></param>
        public void SetPermission(EnMember memberInfo, EnCompany companyInfo, EnDealer dealerInfo, EnMarket marketInfo, EnShop shopInfo, int? mid, int? companyid, int? dealerid, int? marketid, int? shopid,int? brandid, params System.Web.UI.Control[] controls)
        {
            if (memberInfo != null)
            {

                switch (memberInfo.type)
                {
                    case (int)EnumMemberType.工厂企业:
                        if (companyid != companyInfo.id)
                        {
                            foreach (System.Web.UI.Control c in controls)
                            {
                                c.Visible = false;
                            }
                            UiCommon.setPDialog(this.Page);
                        }
                        break;
                    case (int)EnumMemberType.经销商:
                        if (brandid == 0 && mid != memberInfo.id)
                        {
                            foreach (System.Web.UI.Control c in controls)
                            {
                                c.Visible = false;
                            }
                            UiCommon.setPDialog(this.Page);

                        }
                        if (brandid != 0 && !dealerCreateBrandIdList.Contains(brandid.ToString()))
                        {
                            foreach (System.Web.UI.Control c in controls)
                            {
                                c.Visible = false;
                            }
                            UiCommon.setPDialog(this.Page);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// 是否为充值会员
        /// </summary>
        /// <returns></returns>
        public static bool IsPayMember()
        {
            if (memberInfo.RegEndTime != null && memberInfo.RegEndTime != DateTime.Parse("0001/1/1 0:00:00"))
            {
                if (memberInfo.RegEndTime >= DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool IsPayMember(string id)
        {
           return true;

            //memberInfo = ECMember.GetMemberInfo(" where id=" + id);
            //if (memberInfo != null && memberInfo.RegEndTime != null && memberInfo.RegEndTime != DateTime.Parse("0001/1/1 0:00:00"))
            //{
            //    if (memberInfo.RegEndTime >= DateTime.Now)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
        }

        public static string getOrderNoRead
        {
            get
            {
                return EcShoppingPay.getCompanyNoRead(CookiesHelper.GetCookie("mid")).Tables[0].Rows[0][0].ToString();
            }
        }
        public void SetPermission(int? mid, int? companyid, int? dealerid, int? marketid, int? shopid,int? brandid,params System.Web.UI.Control[] controls)
        {
            SetPermission(memberInfo, companyInfo, dealerInfo, marketInfo, shopInfo, mid, companyid, dealerid, marketid, shopid,brandid, controls);
        }
        #endregion

        #region 通用分页
        
        /// <summary>
        /// 通用分页
        /// </summary>
        /// <param name="recordCount">总记录数</param>
        /// <param name="totalPage">总页数</param>
        /// <param name="pageSize">每页显示数据量</param>
        /// <param name="pageIndex">当前索引</param>
        /// <param name="myUrl">链接的前缀</param>
        /// <param name="isRewriteUrl">是否采用伪静态</param>
        /// <param name="pageNumber">数据间隔</param>
        /// <param name="unit">单位</param>
        /// <param name="descript">描述</param>
        /// <returns></returns>
        public static string commonMemberPageSub(int recordCount, int totalPage, int pageSize, int pageIndex, string myUrl, int pageNumber, string unit, string descript)
        {
            return commonMemberPageSub(recordCount, totalPage, pageSize, pageIndex, myUrl, pageNumber, 0, unit, descript);
        }

        /// <summary>
        /// 通用分页
        /// </summary>
        /// <param name="recordCount">总记录数</param>
        /// <param name="totalPage">总页数</param>
        /// <param name="pageSize">每页显示数据量</param>
        /// <param name="pageIndex">当前索引</param>
        /// <param name="myUrl">链接的前缀</param>
        /// <param name="isRewriteUrl">是否采用伪静态</param>
        /// <param name="pageNumber">数据间隔</param>
        /// <param name="unit">单位</param>
        /// <param name="descript">描述</param>
        /// <returns></returns>
        public static string commonMemberPageSub(int recordCount, int totalPage, int pageSize, int pageIndex, string myUrl, int pageNumber, int isRewriteUrl, string unit, string descript)
        {
            if (totalPage < pageIndex)
                pageIndex = totalPage;

            //URL
            string Url = myUrl.TrimEnd('&') + "&Page={0}";
            if (myUrl.Substring(myUrl.LastIndexOf('?')) == "?")
                Url = myUrl.TrimEnd('&') + "Page={0}";
            if (isRewriteUrl == 1)
                Url = myUrl.TrimEnd('-') + "-{0}.aspx";//重写Url

            StringBuilder sb = new StringBuilder();
            //统计总页面、记录数
            sb.Append("<div class=\"pages\">共" + totalPage + "页，" + recordCount + unit + descript + "&nbsp;&nbsp;&nbsp;");
            //首页(上一页)
            if (pageIndex == 1)
                sb.Append("<span class=\"disabled\">首页</span>\r\n<span class=\"disabled\"> &lt; </span>&nbsp;");
            else
                sb.Append("<a href=\"" + string.Format(Url, "1") + "\">首页</a>\r\n<a href=\"" + string.Format(Url, System.Convert.ToString(pageIndex - 1)) + "\"> &lt; </a>&nbsp;");

            //页码
            int min = 0;//最小页码
            int max = 0;//最大页码

            //
            int maxNum = Convert.ToInt32(Math.Ceiling((double)pageNumber / (double)2)) - 1;
            int minNum = pageNumber - maxNum - 1;

            min = pageIndex - minNum;
            max = pageIndex + maxNum;
            if (max < pageNumber)
                max = pageNumber;

            //这里需要考虑到末页
            if ((totalPage - pageIndex) < maxNum)
                min = totalPage - pageNumber + 1;

            if (min < 1)
                min = 1;
            if (totalPage < max)
                max = totalPage;
            //第一页
            if (min != 1)
                sb.Append("<a href=\"" + string.Format(Url, 1) + "\">1</a>\r\n");
            for (int p = min; p <= max; p++)
            {
                if (p == pageIndex)
                    sb.Append("<span class=\"current\">" + p + "</span>\r\n");
                else
                    sb.Append("<a href=\"" + string.Format(Url, p.ToString()) + "\">" + p + "</a>\r\n");
            }

            if (0 <= (totalPage - 2 - max) && 5 < totalPage)
            {
                sb.Append("...\r\n");
                sb.Append("<a href=\"" + string.Format(Url, totalPage - 1) + "\">" + (totalPage - 1) + "</a>\r\n");
                sb.Append("<a href=\"" + string.Format(Url, totalPage) + "\">" + totalPage + "</a>\r\n");
            }

            //下一页(尾页)
            if (pageIndex == totalPage)
                sb.Append("<span class=\"disabled\"> &gt; </span>\r\n<span class=\"disabled\">尾页</span>");
            else
                sb.Append("<a href=\"" + string.Format(Url, System.Convert.ToString(pageIndex + 1)) + "\"> &gt; </a>\r\n<a href=\"" + string.Format(Url, System.Convert.ToString(totalPage)) + "\">尾页</a>");

            if (pageSize < recordCount)
            {
                sb.Append("&nbsp;&nbsp;&nbsp;跳到\n\r\n\r<input type=\"text\" onblur=\"this.value=this.value.replace(/[^\\d]/g,'')\" value=\"" + totalPage + "\" class=\"tzshuru\" size=\"4\" id=\"doPage\" />\n\r<input type=\"button\" class=\"btngo\" onclick=\"goPage('doPage'," + totalPage.ToString() + ",'" + myUrl + "');\" value=\"GO\" />");
                sb.Append("每页" + descript + "数");
                sb.Append("<label><select onchange=\"changeUrlPara(this,'pq','select');\"><option" + (pageSize == 10 ? " selected" : "") + ">10</option><option" + (pageSize == 20 ? " selected" : "") + ">20</option><option" + (pageSize == 30 ? " selected" : "") + ">30</option><option" + (pageSize == 50 ? " selected" : "") + ">50</option></select></label>");
            }
            sb.Append("</div>");

            return sb.ToString();
        }
        #endregion

    }
}
