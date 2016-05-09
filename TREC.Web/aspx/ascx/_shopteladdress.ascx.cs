using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Entity;
using TREC.ECommerce;

namespace TREC.Web.aspx.ascx
{
    public partial class _shopteladdress : System.Web.UI.UserControl
    {
        public static EnMember memberInfo = null;
        public bool isPay = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            EnCompany companyInfo = ECCompany.GetCompanyInfo(" where id=" + ShopPageBase.shopInfo.cid);
            if (companyInfo != null)
            {
                memberInfo = ECMember.GetMemberInfo(" where id= " + companyInfo.mid);
                isPay = SupplerPageBase.IsPayMember(CompanyPageBase.companyInfo.mid.ToString());
            }
        }
    }
}