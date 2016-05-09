using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Entity;
using TREC.ECommerce;
using TRECommon;
using System.Text;

namespace TREC.Web.Suppler.product
{
    public partial class DelProductList : SupplerPageBase
    {
        protected string productNo = string.Empty;//产品编号
        protected int pagequantity = 10;//每页信息数
        protected string pageStr = string.Empty;//分页
        protected int currentPage = 1;//当前索引页
        #region 页面加载事件
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //选中左边菜单栏目
            Master.menuName = "productlist";

            List<EnProductCategory> CateList = ECProductCategory.GetProductCategoryListToDDL("");
            if (CateList != null)
            {
                if (0 < CateList.Count)
                {
                    var result = from q in CateList
                                 where q.parentid == 0
                                 select new
                                 {
                                     title = q.title,
                                     id = q.id
                                 };
                    if (result != null)
                    {
                        if (0 < result.Count())
                        {
                            RptBigCate.DataSource = result;
                            RptBigCate.DataBind();
                        }
                    }
                }
            }

            //品牌
            if (brandList != null)
            {
                if (0 < brandList.Count)
                {
                    rptBrand.DataSource = brandList;
                    rptBrand.DataBind();
                }
            }

            //Add    :rafer
            //Date   :4-24
            //Remarks:新增系列的搜索条件
            List<EnBrands> SeriesList = ECBrand.GetBrandsList(" createmid=" + memberInfo.id);
            if (SeriesList != null)
            {
                if (0 < SeriesList.Count)
                {
                    RptSeries.DataSource = SeriesList;
                    RptSeries.DataBind();
                }
            }
            ShowData();      
        }
        #endregion

        #region 加载数据
        
        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECProduct.DeleteProduct(TypeConverter.StrToInt(ECommon.QueryId));
            }

            string strWhere = "";
            #region 判断会员类型
            
            switch (memberInfo.type)
            {
                case (int)EnumMemberType.工厂企业:
                    strWhere += " and companyid=" + companyInfo.id;
                    break;
                case (int)EnumMemberType.经销商:
                   
                    if (brandidlist.Length > 0)
                    {
                        strWhere = " and brandid in (" + brandidlist + ") and brandid!=0";
                    }                  
                    break;


            }
            #endregion

            #region 获取搜索条件

            //大类
            if (!string.IsNullOrEmpty(Request["bigCateId"]))
            {
                int bigCateId = 0;
                int.TryParse(Request["bigCateId"].Trim(), out bigCateId);
                if (0 < bigCateId)
                {
                    //大类
                    List<EnProductCategory> catagoryList = ECProductCategory.GetProductCategoryListToDDL("");
                    var bigCate = from bc in catagoryList where bc.parentid == bigCateId select new { bc.id, bc.title };
                    string smallids = string.Empty;
                    foreach (var item in catagoryList)
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
                        //根据大类获取小类id
                        strWhere += " and categoryid in(" + smallids + ")";
                    }

                }
            }


            if (!string.IsNullOrEmpty(Request["smallCateId"]))
            {
                int categoryid = 0;
                int.TryParse(Request["smallCateId"].Trim(), out categoryid);
                if (0 < categoryid)
                {
                    strWhere += " and categoryid=" + categoryid;
                }
            }

            if (!string.IsNullOrEmpty(Request["SeriesId"]))
            {
                int brandid = 0;
                int.TryParse(Request["SeriesId"].Trim(), out brandid);
                if (0 < brandid)
                {
                    strWhere += " and brandsid=" + brandid;
                }
            }

            ////Add    :rafer
            ////Date   :4-24
            ////Remarks:新增系列的搜索条件
            //if (!string.IsNullOrEmpty(Request["brandsid"]))
            //{
            //    int brandsid = 0;
            //    int.TryParse(Request["brandsid"].Trim(), out brandsid);
            //    if (0 < brandsid)
            //    {
            //        strWhere += " and brandsid=" + brandsid;
            //    }
            //}

            if (!string.IsNullOrEmpty(Request["productNo"]))
                productNo = Request["productNo"].Trim();
            if (!string.IsNullOrEmpty(productNo))
            {
                strWhere += " and (isnull(sku,'')+isnull(title,'')+isnull(shottitle,'')+isnull(brandtitle,'') like '%" + productNo + "%')";
                //strWhere += " and title like '%" + txtProductName.Text + "%'";
            }
            if (!string.IsNullOrEmpty(Request["Status"]))
            {
                int Status = 0;
                int.TryParse(Request["Status"].Trim(), out Status);
                //if (0 < Status)
                //{
                    strWhere += " and linestatus=" + Status;
                //}
            }
            //子账号只能管理自己所属的店铺产品
            if (memberInfo.shopid != null && memberInfo.shopid != 0 && memberInfo.parentid != null && memberInfo.parentid != 0)
            {
                strWhere += " and shopid=" + memberInfo.shopid;
            }
            #endregion

            strWhere = strWhere.Length > 0 ? strWhere.Substring(4, strWhere.Length - 4) : strWhere;

            if (!string.IsNullOrEmpty(Request["Page"]))
            {
                int.TryParse(Request["Page"].Trim(), out currentPage);
                if (currentPage <= 0)
                    currentPage = 1;
            }
            int Counts = 0;
            List<EnProduct> productList = ECProduct.GetproductrecyclerecycleList(currentPage, pagequantity, strWhere, out Counts);
            if (productList != null)
            {
                if (0 < productList.Count)
                {
                    RptProductList.DataSource = productList;
                    RptProductList.DataBind();
                    int totalPage = 0;
                    //计算总页数
                    if (Counts % pagequantity != 0)
                        totalPage = (Counts - Counts % pagequantity) / pagequantity + 1;
                    else
                        totalPage = Counts / pagequantity;
                    pageStr = commonMemberPageSub(Counts, totalPage, pagequantity, currentPage, "DelProductList.aspx?", 5, "个", "产品");
                }
            }
            
          //  List<EnProduct> productList = ECProduct.GetProductList(currentPage, pagequantity, strWhere, out Counts);
           
        }
        #endregion

        #region 获取产品尺寸
        public string GetWebProduct(object pid)
        {
            StringBuilder sb = new StringBuilder();
            EnWebProduct productInfo = new EnWebProduct();
            productInfo = ECProduct.GetWebProducInfo(" where id=" + pid.ToString());
            if (productInfo != null && productInfo.HtSize.Keys.Count != 0)
            {
                foreach (object s in productInfo.HtSize.Keys)
                {
                    sb.Append(s.ToString());
                }
            }
            else
            {
                sb.Append("暂无尺寸");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取产品尺寸
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public string getProductSize(object pid)
        {
            List<EnProductAttribute> listproductattribute = ECProductAttribute.GetProductAttributeList(" productid='" + pid.ToString() + "'");
            if (listproductattribute != null && listproductattribute.Count > 0)
            {
                return listproductattribute[0].productlength + "*" + listproductattribute[0].productwidth + "*" + listproductattribute[0].productheight;
            }
            else
            {
                return "暂无";
            }

        }
        #endregion

        #region 获取产品库存
        public string getProductStorage(object pid)
        {
            List<EnProductAttribute> listproductattribute = ECProductAttribute.GetProductAttributeList(" productid='" + pid.ToString() + "'");
            if (listproductattribute != null && listproductattribute.Count > 0)
            {
                return listproductattribute[0].storage.ToString();
            }
            else
            {
                return "0";
            }

        }
        #endregion

        #region 获取产品审核状态

        public string GetStatusStr(object obj)
        {
            string str = string.Empty;
            if (obj == null)
            {
                return str;
            }
            switch (obj.ToString())
            {
                case "-1":
                    str = "<a class=\"oncheck\">审核中</a>";
                    break;
                case "0":
                    str = "<a class=\"offline\">已下线</a>";
                    break;
                case "1":
                    str = "<a class=\"oncheck\">申请中</a>";
                    break;
                case "2":
                    str = "<a class=\"online\">已上线</a>";
                    break;
                case "-99":
                    str = "<a class=\"offline\">已下线</a>";
                    break;
            }
            return str;
        }
        #endregion
        #region 获取店铺名称
        public string GetShopName(object obj)
        {
            // ECShop.GetShopList(" createmid = " + memberId.ToString(), out shopRecord);
            int myId = 0;
            int.TryParse(obj.ToString(), out myId);
            EnShop shopModel = ECShop.GetShopInfo(" where id=" + myId);
            if (shopModel != null)
            {
                return shopModel.title;
            }
            else
            {
                return "";
            }

        }
        #endregion
    }
}