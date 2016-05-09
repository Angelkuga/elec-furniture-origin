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
      
      
    public partial class promotion :ShopPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShopPageBase.setvalue = "-99";
            pageTitle = "-" + shopInfo.title + "-经销店铺-促销信息";
        }
    }
}