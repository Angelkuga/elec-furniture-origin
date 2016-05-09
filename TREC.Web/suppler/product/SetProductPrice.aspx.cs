using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler.product
{
    public partial class SetProductPrice : SupplerPageBase
    {
        protected string shopStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //选中左边菜单栏目
            Master.menuName = "SetProductPrice";            
            //产品品牌
            RptBrand.DataSource = brandList;
            RptBrand.DataBind();
            queryShopList();
        }
        #region 查询店铺数据
        
        /// <summary>
        /// 查询店铺数据
        /// </summary>
        /// <param name="memberId">会员id</param>
        private void queryShopList()
        {            
            List<EnShop> shopList = ECShop.GetShopList(" createmid = " +memberInfo.id );
            if (shopList != null)
            {               
                    foreach (EnShop model in shopList)
                    {
                        shopStr += " <option value=\"" + model.id.ToString() + "\">" + model.title + " </option>";
                   //  shopStr += "<li><input type=\"checkbox\" value=\"" + model.id.ToString() + "\" name=\"shopId\">" + model.title + "</li>";
                       
                    }             
            }
        }
        #endregion

    }
}