using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.aspx.shop
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion
      
      
    public partial class address :ShopPageBase
    {
        public static EnMember memberInfo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ShopPageBase.setvalue = "-99";
            pageTitle = "-" + shopInfo.title + "-经销店铺-联系地址";
            _shopproduct1.brandid = shopInfo.ShopBrandInfo.id;

            EnCompany companyInfo = ECCompany.GetCompanyInfo(" where id=" + ShopPageBase.shopInfo.cid);
            if (companyInfo != null)
            {
                memberInfo = ECMember.GetMemberInfo(" where id= " + companyInfo.mid);
            }
        }
        protected global::TREC.Web.aspx.ascx._shopproduct _shopproduct1;
    }
}