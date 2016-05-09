using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.aspx.ascx
{
    public partial class _teladdress : System.Web.UI.UserControl
    {
        public static EnMember memberInfo = null;
        public EnWebCompany companyInfo = new EnWebCompany();

        public string addressList = string.Empty;
        public  EnWebCompany _companyInfo = new EnWebCompany();
        public int BrandId = 0;
        public List<EnWebShop> list = new List<EnWebShop>();

        public bool isPay = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            string strWhere = string.Empty;
            if (ECommon.QueryCId == "" || ECommon.QueryCId == "0")
            {
                Response.Redirect(ECommon.WebUrl);
            }

            
            companyInfo = ECCompany.GetWebCompanyInfo(" where id=" + ECommon.QueryCId);
            if (CompanyPageBase.companyInfo != null)
            {
                memberInfo = ECMember.GetMemberInfo(" where id= " + CompanyPageBase.companyInfo.mid);

                isPay = SupplerPageBase.IsPayMember(CompanyPageBase.companyInfo.mid.ToString());
            int pageCount = 0;
            string sortKey = "lastedittime";
            string orderType = "desc";
           // BrandId = TypeConverter.StrToInt(companyInfo.CompanyBrandList[0].id);
            BrandId = SubmitMeth.getInt(companyInfo.CompanyBrandList[0].id);
            strWhere += " and (brandxml like '%<id>" + BrandId + "</id>%'";
            for (var i = 1; i < companyInfo.CompanyBrandList.Count; i++)
            {
                strWhere += " or brandxml like '%<id>" + companyInfo.CompanyBrandList[i].id + "</id>%' ";
            }
            strWhere += ") and  areacode IN (SELECT areacode FROM dbo.t_area WHERE parentcode='310000' OR areacode='310000' OR parentcode='310100')";
            list = ECShop.GetWebShopList(1, 50, strWhere, sortKey, orderType, out pageCount);

            }

           
        }
    }
}