using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using System.Collections;

namespace TREC.Web.Suppler.shop
{
    public partial class DelShopList : SupplerPageBase
    {
        protected int pagequantity = 20;//每页信息数
        protected string pageStr = string.Empty;//分页
        protected int currentPage = 1;//当前索引页

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string memberId = CookiesHelper.GetCookie("mid");
                if (string.IsNullOrEmpty(memberId))
                {
                    Response.Write("<script>top.document.location.href='" + ECommon.WebUrl + "index.aspx" + "';</script>");
                    Response.End();
                }
                //选中左边菜单栏目
                Master.menuName = "shoplist";
                ShowData(memberId);
            }
        }

        protected void ShowData(string memberId)
        {
            string strWhere = " createmid = " + memberId;
            List<EnShop> shopList = ECShop.GetRecycleShopList(ECommon.QueryPageIndex, pagequantity, strWhere, out tmpPageCount);
            if (shopList != null)
            {
                if (0 < shopList.Count())
                {
                    rptList.DataSource = shopList;
                    rptList.DataBind();

                    int totalPage = 0;
                    //计算总页数
                    if (tmpPageCount % pagequantity != 0)
                        totalPage = (tmpPageCount - tmpPageCount % pagequantity) / pagequantity + 1;
                    else
                        totalPage = tmpPageCount / pagequantity;

                    pageStr = commonMemberPageSub(tmpPageCount, totalPage, pagequantity, currentPage, "shoplist.aspx?", 5, "个", "店铺");
                }
                shopList.Clear();
                shopList = null;
            }
        }

        public string GetBrandOfShopId(object id)
        {
            string _ref = string.Empty;
            if (id == null)
            {
                return _ref;
            }
            int shopid = Convert.ToInt32(id);
            int i = 0;
            foreach (Hashtable m in ECShop.GetReaderShopBrandList(shopid))
            {
                if (i == 0) _ref = m["BrandName"].ToString();
                else _ref += "，" + m["BrandName"];
                i++;
            }

            return _ref;
        }
    }
}