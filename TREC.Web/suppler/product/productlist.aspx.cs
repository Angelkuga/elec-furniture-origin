using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using System.Text;

namespace TREC.Web.Suppler.product
{
    public partial class productlist : SupplerPageBase
    {
        protected string productNo = string.Empty;//产品编号
        protected int pagequantity = 40;//每页信息数
        protected string pageStr = string.Empty;//分页
        protected int currentPage = 1;//当前索引页

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (memberInfo == null)
                {
                    Response.Write("<script>top.document.location.href='" + ECommon.WebUrl + "index.aspx" + "';</script>");
                    Response.End();
                }
                ////如果不是品牌厂商
                //if (memberInfo.type != 101)
                //{
                //    HttpContext.Current.Response.Redirect(ECommon.WebUrl + "/suppler/index.aspx");                   
                //}


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

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECProduct.DeleteProduct(TypeConverter.StrToInt(ECommon.QueryId));


                string deltitle = "产品ID" + ECommon.QueryId;
                string mailsubject = string.Format(@"
                        <p>商家: {0} <p>产品删除：" + deltitle + "</p>"
                                  , memberInfo.username);
                string[] mailto = TREC.ECommerce.ECommon.ServiceMail.Split(',');
                foreach (string items in mailto)
                {
                    bool rsmail = EmailHelper.SendEmail("家具快搜 商家产品删除通知提示", items, mailsubject);
                }

            }

            string strWhere ="";

            switch (memberInfo.type)
            {
                case (int)EnumMemberType.工厂企业:
                    strWhere += " and companyid=" + companyInfo.id;
                    // strWhere += " and createmid="+memberInfo.id;
                    break;
                case (int)EnumMemberType.经销商:
                    //if (!string.IsNullOrEmpty(Request["brandid"]))
                    //{
                    //    int brandid = 0;
                    //    int.TryParse(Request["brandid"].Trim(), out brandid);
                    //    if (0 < brandid)
                    //    {
                    //        strWhere += " and brandid=" + brandid+" and ";
                    //    }
                    //}
                    //else
                    //{
                    if (brandidlist.Length > 0)
                    {
                        strWhere = " and brandid in (" + brandidlist + ") and brandid!=0";
                    }
                    // }
                    //  strWhere += " and companyid=" + companyInfo.id;
                    break;


            }
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

            if (!string.IsNullOrEmpty(Request["brandid"]))
            {
                int brandid = 0;
                int.TryParse(Request["brandid"].Trim(), out brandid);
                if (0 < brandid)
                {
                    strWhere += " and brandid=" + brandid;
                }
            }

            //Add    :rafer
            //Date   :4-24
            //Remarks:新增系列的搜索条件
            if (!string.IsNullOrEmpty(Request["SeriesId"]))
            {
                int brandsid = 0;
                int.TryParse(Request["SeriesId"].Trim(), out brandsid);
                if (0 < brandsid)
                {
                    strWhere += " and brandsid=" + brandsid;
                }
            }

            //Add    :wj
            //Date   :2/2
            //Remarks:新增店铺的搜索条件
            if (!string.IsNullOrEmpty(Request["ShopID"]))
            {
                int ShopID = 0;
                int.TryParse(Request["ShopID"].Trim(), out ShopID);
                if (ShopID > 0)
                {
                    strWhere += " and shopid=" + ShopID;
                }
                else
                {
                    strWhere += " and (ShopID=0 or ShopID is null) ";
                }
             
            }

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
                switch (Status)
                {
                    case -1:  ///申请中
                        strWhere += " and auditstatus!=1";
                        break;
                    case 0://已下线
                        strWhere += " and auditstatus=1  and linestatus=" + Status;
                        break;
                    case 1:
                        strWhere += " and linestatus=" + Status;
                        break;
                    default:
                        break;
                }
                // strWhere += " and linestatus=" + Status;
                //}
            }
            //子账号只能管理自己所属的店铺产品
            if (memberInfo.shopid != null && memberInfo.shopid != 0 && memberInfo.parentid != null && memberInfo.parentid != 0)
            {
                strWhere += " and shopid=" + memberInfo.shopid;
            }
            //活动类型数据
            if (!string.IsNullOrEmpty(Request["SelPT"]))
            {
                strWhere += " and id in (select productid from t_productattribute where ProductAttributePromotion=" + Request["SelPT"].Trim() + ")";
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
            if (!strWhere.ToLower().Contains("ShopID".ToLower()))
            {
                strWhere = strWhere + " and (ShopID=0 or ShopID is null) ";
            }
            List<EnProduct> productList = ECProduct.GetProductList(currentPage, pagequantity, strWhere, out Counts);
            if (productList != null)
            {
                if (0 < productList.Count)
                {
                    rptList.DataSource = productList;
                    rptList.DataBind();
                    int totalPage = 0;
                    //计算总页数
                    if (Counts % pagequantity != 0)
                        totalPage = (Counts - Counts % pagequantity) / pagequantity + 1;
                    else
                        totalPage = Counts / pagequantity;
                    string pagepara = string.Format("productlist.aspx?SelPT={0}&bigCateId={1}&smallCateId={2}&brandid={3}&SeriesId={4}&ShopID={5}&Status={6}&productNo={7}"
                        , Request["SelPT"], Request["bigCateId"], Request["smallCateId"], Request["brandid"], Request["SeriesId"]
                        , Request["ShopID"], Request["Status"], Request["productNo"]);
                    pageStr = commonMemberPageSub(Counts, totalPage, pagequantity, currentPage, pagepara,5, "个", "产品");
                }
            }
        }
        #region 删除

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            string idlist = "";
            string deltitle = string.Empty;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_pid")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    idlist += id + ",";
                    deltitle =deltitle+ "产品ID" + id + ",产品标题：" + ((Label)rptList.Items[i].FindControl("label_title")).Text; 
                }
            }
            if (idlist.Length > 0)
            {
                ECProduct.deleteProduct(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);

               

                Response.Write("<script>alert('删除成功,请在已删除产品列表查看！');location.href='productlist.aspx';</script>");
            }
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

        #region 获取产品审核状态 linestatus

        public string GetStatusStr(object objLineStatus, object auditSattus)
        {
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

        #region 上线

        /// <summary>
        /// 上线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnUp_Click(object sender, EventArgs e)
        {
            string idlist = "";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_pid")).Text;
                string pids = Request.Form["productid"];
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    idlist += id + ",";
                }
            }
            if (idlist.Length > 0)
            {
                ECProduct.ModifyProductlinestatusByID(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist, 1);
                //  UiCommon.JscriptPrint(this.Page, "上线成功!", Request.Url.AbsoluteUri, "Success");
                Response.Write("<script>alert('上线成功！');location.href='productlist.aspx';</script>");
            }
            else
            {
                //  UiCommon.JscriptPrint(this.Page, "请选择要上线的产品!", Request.Url.AbsoluteUri, "Success");
                Response.Write("<script>alert('请选择要上线的产品！');location.href='productlist.aspx';</script>");
            }
        }
        #endregion


        #region 下线

        /// <summary>
        /// 下线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDon_Click(object sender, EventArgs e)
        {
            string idlist = "";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_pid")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    idlist += id + ",";
                }
            }
            if (idlist.Length > 0)
            {
                ECProduct.ModifyProductlinestatusByID(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist, 0);
                Response.Write("<script>alert('下线成功！');location.href='productlist.aspx';</script>");
                //  UiCommon.JscriptPrint(this.Page, "下线成功!", Request.Url.AbsoluteUri, "Success");
            }
            else
            {
                //UiCommon.JscriptPrint(this.Page, "请选择要下线的产品!", Request.Url.AbsoluteUri, "Success");
                Response.Write("<script>alert('请选择要下线的产品！');location.href='productlist.aspx';</script>");
            }
        }
        #endregion

    }
}