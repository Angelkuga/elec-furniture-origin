using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TRECommon;
using TREC.Entity;

namespace TREC.Web.Suppler.product
{
    public partial class groupproductlist : SupplerPageBase
    {
        protected string productNo = string.Empty;//产品编号
        protected int pagequantity = 10;//每页信息数
        protected string pageStr = string.Empty;//分页
        protected int currentPage = 1;//当前索引页
        #region 页面加载

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //选中左边菜单栏目
                // Master.menuName = "gpproduct";
                //选中左边菜单栏目
                Master.menuName = "groupproductlist";

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

                #region wj增加2/2
                //Remarks:新增店铺的搜索条件
                //子账号只能管理自己所属的店铺产品
                string ShopListWhere = "";
                if (memberInfo.shopid != null && memberInfo.shopid != 0 && memberInfo.parentid != null && memberInfo.parentid != 0)
                {
                    ShopListWhere += " and shopid=" + memberInfo.shopid;
                }
                List<EnShop> ShopList = ECShop.GetShopList(" createmid=" + memberInfo.id + ShopListWhere);
                if (ShopList != null)
                {
                    if (0 < ShopList.Count)
                    {
                        RptShop.DataSource = ShopList;
                        RptShop.DataBind();
                    }
                }

                //活动类型数据
                List<TREC.Entity.t_promotionstype> promType = TREC.ECommerce.t_promotionstypeBLL.GetPromotionTypeList();
                RptPT.DataSource = promType;
                RptPT.DataBind();
                #endregion

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
                showGroupProductList(userName);
            }
        }

        #endregion

        #region 显示套组合列表数据
        /// <summary>
        /// 显示套组合列表数据
        /// </summary>
        /// <param name="userName"></param>
        private void showGroupProductList(string userName)
        {
            //查询条件
            string Where = string.Empty;
            string myurl = "groupproductlist.aspx?";
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
                    // myurl += "bigCateId=" + myId + "&";
                    //Where += " AND bigCateId= " + myId;
                    //大类
                    List<EnProductCategory> catagoryList = ECProductCategory.GetProductCategoryListToDDL("");
                    var bigCate = from bc in catagoryList where bc.parentid == myId select new { bc.id, bc.title };
                    string smallids = string.Empty;
                    foreach (var item in bigCate)
                    {
                        if (smallids == "")
                        {
                            smallids = item.id.ToString();
                        }
                        else
                        {
                            smallids += "," + item.id.ToString();
                        }
                    }
                    if (smallids != "")
                    {
                        myurl += "bigCateId=" + myId + "&";
                        //根据大类获取小类id
                        Where += " and bigCateId in(" + smallids + ")";
                    }
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

            //Add    :wj
            //Date   :2/2
            //Remarks:新增店铺的搜索条件
            if (!string.IsNullOrEmpty(Request["ShopID"]))
            {
                int ShopID = 0;
                int.TryParse(Request["ShopID"].Trim(), out ShopID);
                if (0 < ShopID)
                {
                    myurl += "ShopID=" + ShopID + "&";
                    Where += " and ShopId=" + ShopID;
                }
            }
            //活动类型数据
            if (!string.IsNullOrEmpty(Request["SelPT"]))
            {
                myurl += "SelPT=" + Request["SelPT"] + "&";
                Where += " and GroupProductPromotion=" + Request["SelPT"].Trim();
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

            //总记录数
            int Counts = 0;
            List<GroupProductModel> productList = ProductBll.QueryGroupProductListDb(Where, productNo, userName, Sale, Stock, Sorder, pagequantity, currentPage, out Counts);
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
        #endregion

        #region 获得产品状态描述

        /// <summary>
        /// 获得产品状态描述
        /// </summary>
        /// <param name="Status">产品状态</param>
        /// <returns></returns>
        public string GetProductStatus(string objLineStatus)
        {
            //套组合默认审核上线
            string auditSattus = "1";
            string str = string.Empty;
            if (objLineStatus == null)
            {
                return str;
            }

            if (auditSattus.ToString() == "1")
            {

                switch (objLineStatus.ToString())
                {
                    case "-1":
                        str = "<a class=\"oncheck\">审核中</a>";
                        break;
                    case "0":
                        str = "<a class=\"offline\">下线状态</a>";
                        break;
                    case "1":
                        str = "<a class=\"online\">上线状态</a>";
                        //str = "<a class=\"oncheck\">申请中</a>";
                        break;
                    case "2":
                        str = "<a class=\"online\">已上线</a>";
                        break;
                    case "-99":
                        str = "<a class=\"offline\">已下线</a>";
                        break;
                }
            }
            else
            {
                str = "<a class=\"oncheck\">申请中</a>";
            }
            return str;
        }
        #endregion

    }
}