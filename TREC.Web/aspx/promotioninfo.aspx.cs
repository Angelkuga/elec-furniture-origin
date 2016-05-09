using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.aspx
{
    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion

    public partial class promotioninfo : WebPageBase
    {
        public EnWebPromotion promotionInfo = new EnWebPromotion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ECommon.QueryPId != "")
            {
                promotionInfo = ECPromotion.GetWebPromotionList(1, 1, " and id=" + ECommon.QueryPId, "", "", out tmpPageCount)[0];
            }

            pageTitle = "-活动列表";
        }

     
    }
}