using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Entity;
using TREC.ECommerce;
using TRECommon;

namespace TREC.Web.Suppler.product
{
    public partial class DelGroupProductList : SupplerPageBase
    {
        protected string productNo = string.Empty;//产品编号
        protected int pagequantity = 10;//每页信息数
        protected string pageStr = string.Empty;//分页
        protected int currentPage = 1;//当前索引页
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //选中左边菜单栏目
             //   Master.menuName = "gpproduct";
             //   string userName = CookiesHelper.GetCookie("mname");
                //产品品牌
                ddlbrand.DataSource = brandList;
                ddlbrand.DataTextField = "title";
                ddlbrand.DataValueField = "id";
                ddlbrand.DataBind();
                ddlbrand.Items.Insert(0, new ListItem("选择品牌", ""));
                //大类            
                List<EnProductCategory> catagoryList = ECProductCategory.GetProductCategoryListToDDL("");
                var bigCate = from bc in catagoryList where bc.parentid == 0 select new { bc.id, bc.title };

                ddlBigCategory.DataSource = bigCate;
                ddlBigCategory.DataTextField = "title";
                ddlBigCategory.DataValueField = "id";
                ddlBigCategory.DataBind();
                ddlBigCategory.Items.Insert(0, new ListItem("选择大类", ""));

               
                //Remarks:系列的搜索条件
                List<EnBrands> SeriesList = ECBrand.GetBrandsList(" createmid=" + memberInfo.id);
                if (SeriesList != null)
                {
                    if (0 < SeriesList.Count)
                    {
                        RptSeries.DataSource = SeriesList;
                        RptSeries.DataBind();
                    }
                }
                string userName = CookiesHelper.GetCookie("mname");
                //showGroupProductList(userName);
                showGroupProductList(userName);
            }
        }

     
        /// <summary>
        /// 显示套组合列表数据
        /// </summary>
        /// <param name="userName"></param>
        private void showGroupProductList(string userName)
        {
            //查询条件
            string Where = string.Empty;
            string myurl = "DelGroupProductList.aspx?";
            //查询条件
          //  string Where = string.Empty;
            // string myurl = "groupproductlist.aspx?";
            #region 获取参数
            
            //产品编号
            if (!string.IsNullOrEmpty(Request["productNo"]))
            {
                myurl += "productNo=" + productNo + "&";
                // productNo = PageUtil.filterSearchKeyWord(Request["productNo"].Trim());
            }

            int myId = 0;
            //大类
            if (!string.IsNullOrEmpty(Request["bigCateId"]))
            {
                int.TryParse(Request["bigCateId"].Trim(), out myId);
                if (0 < myId)
                {
                    myurl += "bigCateId=" + myId + "&";
                    Where += " AND bigCateId= " + myId;
                }
            }
            //品牌
            if (!string.IsNullOrEmpty(Request["brandId"]))
            {
                int.TryParse(Request["brandId"].Trim(), out myId);
                if (0 < myId)
                {
                    myurl += "brandId=" + myId + "&";
                    Where += " AND brandId= " + myId;
                }
            }

            //系列
            if (!string.IsNullOrEmpty(Request["SeriesId"]))
            {
                int.TryParse(Request["SeriesId"].Trim(), out myId);
                if (0 < myId)
                {
                    myurl += "SeriesId=" + myId + "&";
                    Where += " AND SeriesId= " + myId;
                }
            }
            //状态
            if (!string.IsNullOrEmpty(Request["Status"]))
            {
                int.TryParse(Request["Status"].Trim(), out myId);
                if (0 <= myId)
                {
                    myurl += "Status=" + myId + "&";
                    Where += " AND Status=" + myId;
                }
            }
            //子账号只能管理自己所属的店铺产品
            if (memberInfo.shopid != null && memberInfo.shopid != 0 && memberInfo.parentid != null && memberInfo.parentid != 0)
            {
                Where += " and ShopId=" + memberInfo.shopid;
            }

            //销量排序(1表示降序；0表示升序)
            int Sale = 1;
            if (!string.IsNullOrEmpty(Request["Sale"]))
                int.TryParse(Request["Sale"].Trim(), out Sale);
            if (Sale != 1)
                Sale = 0;

            //库存排序(1表示降序；0表示升序)
            int Stock = 1;
            if (!string.IsNullOrEmpty(Request["Stock"]))
                int.TryParse(Request["Stock"].Trim(), out Stock);
            if (Stock != 1)
                Stock = 0;

            //状态排序(1表示降序；0表示升序)
            int Sorder = 0;
            if (!string.IsNullOrEmpty(Request["Sorder"]))
                int.TryParse(Request["Sorder"].Trim(), out Sorder);
            if (Sorder != 1)
                Sorder = 0;

            //每页信息数
            if (!string.IsNullOrEmpty(Request["pq"]))
                int.TryParse(Request["pq"].Trim(), out pagequantity);
            if (pagequantity != 20 && pagequantity != 30 && pagequantity != 50)
                pagequantity = 10;
            else if (pagequantity != 10)
                myurl += "pq=" + pagequantity + "&";

            //当前索引页
            if (!string.IsNullOrEmpty(Request["Page"]))
                int.TryParse(Request["Page"].Trim(), out currentPage);
            if (currentPage < 0)
                currentPage = 1;
            #endregion

            //总记录数
            int Counts = 0;
            List<GroupProductModel> productList = ProductBll.QueryRecycleGroupProductListDb(Where, productNo, userName, Sale, Stock, Sorder, pagequantity, currentPage, out Counts);
            if (productList != null)
            {
                if (0 < Counts)
                {
                    //总页数
                    int PageCount = 0;
                    //计算总页数
                    if (Counts % pagequantity != 0)
                        PageCount = (Counts - Counts % pagequantity) / pagequantity + 1;
                    else
                        PageCount = Counts / pagequantity;
                    RptProductList.DataSource = productList;
                    RptProductList.DataBind();
                    pageStr = commonMemberPageSub(Counts, PageCount, pagequantity, currentPage, myurl, 5, "个", "产品");
                }
                productList.Clear();
                productList = null;
            }
        
           
        }

        #region 获得产品状态描述
        
        /// <summary>
        /// 获得产品状态描述
        /// </summary>
        /// <param name="Status">产品状态</param>
        /// <returns></returns>
        public string GetProductStatus(string Status)
        {
            if (Status == "2")
                return "<a class=\"online\">已上线</a>";
            else if (Status == "1")
                return "<a class=\"oncheck\">申请中</a>";
            else
                return "<a class=\"offline\">已下线</a>";
        }
        #endregion

    }
}