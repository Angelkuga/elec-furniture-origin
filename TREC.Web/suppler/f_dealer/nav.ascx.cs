using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler.f_dealer
{
    public partial class nav : System.Web.UI.UserControl
    {
        protected string s1css = "", s2css = "", s3css = "", s4css = "", s1url = "javascript:;", s2url = "javascript:;", s3url = "javascript:;", s4url = "javascript:;";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //个人成员不需要先录入信息，直接进入1 2 3 4步。
            if (SupplerPageBase.memberInfo.type == (int)EnumMemberType.个人成员)//modify：Rafer   date：2012-04-20
            {
                s1css = "has";
                s1url = "setup1.aspx";
            }
            else if (SupplerPageBase.dealerInfo != null && SupplerPageBase.dealerInfo.id != 0)
            {
                bool hasCompany = false, hasBrand = false, hasBrands = false;
                s1css = "now";
                s1url = "javascript:;";
                if (SupplerPageBase.dealerInfo.title != null && SupplerPageBase.dealerInfo.title != "" && SupplerPageBase.dealerInfo.phone != null && SupplerPageBase.dealerInfo.phone != "" && SupplerPageBase.dealerInfo.address != null && SupplerPageBase.dealerInfo.address != "")
                {
                    hasCompany = true;
                    s1css = "has";
                    s1url = "setup1.aspx";
                    s2css = "now";
                    s2url = "setup2.aspx";
                }

                if (WebUtils.GetPageName() != "setup1.aspx" && (SupplerPageBase.dealerInfo.title == null || SupplerPageBase.dealerInfo.title == "" || SupplerPageBase.dealerInfo.phone == null || SupplerPageBase.dealerInfo.phone == "" || SupplerPageBase.dealerInfo.address == null || SupplerPageBase.dealerInfo.address == ""))
                {
                    Response.Redirect("setup1.aspx");
                    return;
                }

                if (SupplerPageBase.brandList != null && SupplerPageBase.brandList.Count > 0)
                {
                    hasBrand = true;
                    if (ECBrand.GetBrandList(" createmid=" + SupplerPageBase.memberInfo.id).Count > 0)
                    {

                        s3url = "setup3.aspx";
                        s2css = "has";
                        s3css = "now";
                    }
                    else
                    {

                        s3url = "../index.aspx";
                        s2css = "has";
                        s3css = "";
                    }
                }

                if (WebUtils.GetPageName() != "setup2.aspx" && WebUtils.GetPageName() != "setup1.aspx" && (SupplerPageBase.brandList == null || SupplerPageBase.brandList.Count <= 0))
                {
                    Response.Redirect("setup2.aspx");
                    return;
                }

                if (SupplerPageBase.brandidlist != "0" && ECBrand.GetBrandsList(" brandid in (" + SupplerPageBase.brandidlist + ")").Count > 0)
                {
                    hasBrands = true;
                    s3url = "setup3.aspx";
                    s3css = "has";
                    s4css = "now";
                    s4url = "../index.aspx";
                }

            }
            else
            {
                Response.Redirect("../supplerindex.aspx");
                return;
            }
        }
    }
}