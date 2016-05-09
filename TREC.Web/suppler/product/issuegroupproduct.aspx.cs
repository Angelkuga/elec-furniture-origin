using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using System.Text;
using System.Collections;
using System.IO;

namespace TREC.Web.Suppler.product
{
    public partial class issuegroupproduct : SupplerPageBase
    {
        protected string productNo = string.Empty;//产品编号
        protected int gpId = 0;//组合产品id
        protected string shopStr = string.Empty;
        protected int pagequantity = 10;//每页信息数
        protected string pageStr = string.Empty;//分页
        protected int currentPage = 1;//当前索引页
        protected int isGroup = -1;
        protected float price = 0.0f;
        protected string gpName = string.Empty;//产品名称
        protected string shopids = string.Empty;//店铺id
        protected string singleproid = string.Empty;//单品id
        protected int brandsId = 0;//系列id
        protected int smallCategoryId = 0;//小类id
        protected int bigCategoryId = 0;//大类id
        public int companyid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string oldFilePath = "\"E:\\Code\\work\\jiajuks\\trunk\\TREC.Web\\upload\product\thumb\35\20141215155618444987.jpg\"";
                //string newFilePath = string.Empty;
                //if (oldFilePath != "")
                //{
                //    var str1=oldFilePath.Substring(0, oldFilePath.IndexOf("thumb")+6);
                //    var str2 = oldFilePath.Substring(str1.Length, oldFilePath.Length - str1.Length);
                //    newFilePath = str1 + 45 + "/" + str2.Substring(str2.LastIndexOf("/"), str2.Length - str2.LastIndexOf("/"));
                //}
                if (!string.IsNullOrEmpty(Request["gpId"]))
                {
                    int.TryParse(Request["gpId"].Trim(), out gpId);
                    //if (gpId <= 0)
                    //    MessageUtil.ShowTipMessageAlter("抱歉，传递参数有误！", false);
                }
                //选中左边菜单栏目
                if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
                {
                    Master.menuName = "groupproductlist";
                }
                else
                {
                    Master.menuName = "issuegroupproduct";
                }
                string userName = CookiesHelper.GetCookie("mname");
                #region 绑定产品属性

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


                ddlstyle.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品风格);
                ddlstyle.DataTextField = "title";
                ddlstyle.DataValueField = "value";
                ddlstyle.DataBind();
                ddlstyle.Items.Insert(0, new ListItem("选择风格", ""));

                //材质、色系
                ddlmaterial.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品选材);
                ddlmaterial.DataTextField = "title";
                ddlmaterial.DataValueField = "value";
                ddlmaterial.DataBind();
                ddlmaterial.Items.Insert(0, new ListItem("选择选材", ""));


                ddlcolor.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品颜色);
                ddlcolor.DataTextField = "title";
                ddlcolor.DataValueField = "value";
                ddlcolor.DataBind();
                ddlcolor.Items.Insert(0, new ListItem("选择色系", ""));

                //品牌价位
                ddlspread.Items.Clear();
                ddlspread.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品价位);
                ddlspread.DataTextField = "title";
                ddlspread.DataValueField = "value";
                ddlspread.DataBind();
                ddlspread.Items.Insert(0, new ListItem("请选择", ""));


                #region 活动类型数据
                List<TREC.Entity.t_promotionstype> promType = TREC.ECommerce.t_promotionstypeBLL.GetPromotionTypeList();
                ddlGroupProductPromotion.DataSource = promType;
                ddlGroupProductPromotion.DataTextField = "title";
                ddlGroupProductPromotion.DataValueField = "id";
                ddlGroupProductPromotion.DataBind();
                ddlGroupProductPromotion.Items.Insert(0, new ListItem("选择活动", ""));
                #endregion

                if (memberInfo.type == (int)EnumMemberType.工厂企业)
                {
                    companyid = companyInfo.id;
                }

                #endregion

                #region 赋值

                GroupProductModel gpmodel = new GroupProductModel();
                gpmodel = ProductBll.GetModel(gpId);
                if (gpmodel != null)
                {
                    productNo = gpmodel.No;
                    gpName = gpmodel.Name;
                    ddlmaterial.SelectedValue = gpmodel.MaterialId.ToString();
                    ddlstyle.SelectedValue = gpmodel.styleId.ToString();
                    ddlBigCategory.SelectedValue = gpmodel.bigCateId.ToString();
                    ddlbrand.SelectedValue = gpmodel.brandId.ToString();
                    ddlcolor.SelectedValue = gpmodel.ColorId.ToString();
                    brandsId = gpmodel.SeriesId;
                    smallCategoryId = gpmodel.bigCateId;
                    hiddSmallCate.Value = gpmodel.bigCateId.ToString();
                    bigCategoryId = ECProduct.GetBigCateBysmallID(gpmodel.bigCateId);
                    ddlBigCategory.SelectedValue = bigCategoryId.ToString();
                    isGroup = gpmodel.IsGroup;
                    price = gpmodel.Price;
                    this.hfthumb.Value = gpmodel.thumb;
                    string bannel = gpmodel.bannel;
                    if (!string.IsNullOrEmpty(bannel))
                        bannel = bannel.Trim().TrimEnd(',') + ",";
                    this.hfbannel.Value = bannel;
                    txtdescript.Text = gpmodel.Descript;
                    shopids = gpmodel.ShopId.ToString();

                    //选定的小类
                    smallCategoryId = gpmodel.smallCateId;
                    //选定的活动
                    ddlGroupProductPromotion.SelectedValue = gpmodel.groupProductPromotion.ToString();

                    //获取单品id

                    List<GroupProductProperty> listsinglepro = ProductBll.GetGroupProductPropertyByWhere(" gpId=" + gpmodel.gpId);
                    if (listsinglepro != null && listsinglepro.Count > 0)
                    {
                        foreach (var item in listsinglepro)
                        {
                            if (singleproid == "")
                            {
                                singleproid = item.ppId.ToString();
                            }
                            else
                            {
                                singleproid += "," + item.ppId.ToString();
                            }
                        }
                    }
                    hiddSingProductID.Value = singleproid;

                    //店铺关联表是单品的
                    //套组合店铺设置为数据表GroupProduct.的值 不用关联表
                    //List<EnProductShopPrice> listpsp = ECProductShopPrice.GetProductShopPriceListByWhere(" productid=" + gpmodel.gpId);
                    //if (listpsp != null && listpsp.Count > 0)
                    //{
                    //    foreach (var item in listpsp)
                    //    {
                    //        if (shopids == "")
                    //        {
                    //            shopids = item.Shopid.ToString();
                    //        }
                    //        else
                    //        {
                    //            shopids += "," + item.Shopid.ToString();
                    //        }
                    //    }
                    //}
                }
                #endregion
                initDb(userName);
                queryShopList(CookiesHelper.GetCookie("mid"));


            }
        }

        #region 搜索数据

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            initDb(CookiesHelper.GetCookie("mname"));
            //  ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "click", "alert('保存套组合产品成功！');", true);
        }
        #endregion

        #region 显示数据

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void initDb(string userName)
        {


            #region 查询条件

            // string myurl = "groupproductList.aspx?";
            string strWhere = "";

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

            if (!string.IsNullOrEmpty(Request["categoryid"]))
            {
                int categoryid = 0;
                int.TryParse(Request["categoryid"].Trim(), out categoryid);
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
            if (!string.IsNullOrEmpty(Request["brandsid"]))
            {
                int brandsid = 0;
                int.TryParse(Request["brandsid"].Trim(), out brandsid);
                if (0 < brandsid)
                {
                    strWhere += " and brandsid=" + brandsid;
                }
            }

            //if (!string.IsNullOrEmpty(Request["productNo"]))
            //    productNo = Request["productNo"].Trim();
            //if (!string.IsNullOrEmpty(productNo))
            //{
            //    strWhere += " and (isnull(sku,'')+isnull(title,'')+isnull(shottitle,'')+isnull(brandtitle,'') like '%" + productNo + "%')";
            //    //strWhere += " and title like '%" + txtProductName.Text + "%'";
            //}
            if (gpId != 0)
            {
                strWhere += " AND id IN (SELECT ppId FROM GroupProductProperty WHERE gpId = " + gpId + " ) ";
            }

            strWhere = strWhere.Length > 0 ? strWhere.Substring(4, strWhere.Length - 4) : strWhere;

            if (!string.IsNullOrEmpty(Request["Page"]))
            {
                int.TryParse(Request["Page"].Trim(), out currentPage);
                if (currentPage <= 0)
                    currentPage = 1;
            }
            #endregion

            int Counts = 0;
            List<EnProduct> productList = ECProduct.GetProductList(currentPage, pagequantity, strWhere, out Counts);
            //if (productList != null)
            //{
            //    if (0 < productList.Count)
            //    {
            //        rptList.DataSource = productList;
            //        rptList.DataBind();
            //        int totalPage = 0;
            //        //计算总页数
            //        if (Counts % pagequantity != 0)
            //            totalPage = (Counts - Counts % pagequantity) / pagequantity + 1;
            //        else
            //            totalPage = Counts / pagequantity;
            //        pageStr = commonMemberPageSub(Counts, totalPage, pagequantity, currentPage, "issuegroupproduct.aspx?", 5, "个", "产品");
            //    }
            //}
        }
        #endregion

        #region 绑定其他数据
        /// <summary>
        /// 查询店铺数据
        /// </summary>
        /// <param name="memberId">会员id</param>
        private void queryShopList(string memberId)
        {
            int shopRecord = 0;
            List<EnShop> shopList = ECShop.GetShopList(" createmid = " + memberId.ToString(), out shopRecord);
            if (shopList != null)
            {
                if (0 < shopRecord)
                {
                    foreach (EnShop model in shopList)
                    {
                        if (shopids != "" && shopids.IndexOf("" + model.id.ToString() + "") > -1)
                        {
                            shopStr += "<li><input type=\"radio\" checked=\"checked\" value=\"" + model.id.ToString() + "\" name=\"shopId\">" + model.title + "</li>";
                        }
                        else
                        {
                            shopStr += "<li><input type=\"radio\" value=\"" + model.id.ToString() + "\" name=\"shopId\">" + model.title + "</li>";
                        }
                    }
                }
                shopList.Clear();
                shopList = null;
            }
        }
        #region 绑定其他数据


        /// <summary>
        /// 获得下拉菜单option
        /// </summary>
        /// <param name="optionStr"></param>
        /// <param name="module"></param>
        /// <param name="type"></param>
        private void fillDdlByConfig(out string optionStr, int module, int type)
        {
            optionStr = string.Empty;
            List<EnConfig> fList = ECConfig.GetConfigList(" (ishide is null or ishide=0) and module=" + module.ToString() + " and type=" + type.ToString());
            if (fList != null)
            {
                foreach (EnConfig model in fList)
                    optionStr += "<option value=" + model.value.Trim() + ">" + model.title.Trim() + "</option>";
                fList.Clear();
                fList = null;
            }
        }
        ///// <summary>
        ///// 加载色板数据
        ///// </summary>
        ///// <param name="memberId">会员id</param>
        //private void loadColorSwatchList(string memberId)
        //{
        //    Dictionary<int, string> dictCs = ECBrand.GetSwatchName(memberId, 0);
        //    if (dictCs != null)
        //    {
        //        foreach (KeyValuePair<int, string> kvp in dictCs)
        //            ColorSwatchList += "<input type=\"checkbox\" value=\"" + kvp.Key.ToString() + "\" name=\"ColorSwatch\">" + kvp.Value + "&nbsp;&nbsp;";
        //        dictCs.Clear();
        //        dictCs = null;
        //    }
        //}
        #endregion
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
                    str = "<a class=\"oncheck\">待审核</a>";
                    break;
                case "1":
                    str = "<a class=\"online\">已上线</a>";
                    break;
                case "-99":
                    str = "<a class=\"offline\">已下线</a>";
                    break;
            }
            return str;
        }
        #endregion

        #region 保存组合产品

        protected void BtnSaveGroupProduct_Click(object sender, EventArgs e)
        {
            if (memberInfo.type == (int)EnumMemberType.工厂企业)
            {
                companyid = companyInfo.id;
            }

            //保存组合产品
            GroupProductModel model = new GroupProductModel();


            #region wengjie 2015-3-3 产品加入活动后 状态设为待审核
            if (!string.IsNullOrEmpty(ddlGroupProductPromotion.SelectedValue))
            {
                if (model.groupProductPromotion != int.Parse(ddlGroupProductPromotion.SelectedValue))
                {
                    model.Status = 0;
                }

            }
            #endregion

            //产品编号
            model.No = Request["groupProductNo"].Trim();
            //产品名称
            model.Name = Request["groupProductName"].Trim();
            int myId = 0;
            //品牌id
            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value.Trim();
            int.TryParse(ddlbrand.SelectedValue, out myId);
            model.brandId = myId;
            ////大类id
            int.TryParse(ddlBigCategory.SelectedValue, out myId);
            model.bigCateId = myId;
            ////小类
            int.TryParse(hiddSmallCate.Value, out myId);
            model.smallCateId = myId;

            ////营销活动
            int.TryParse(ddlGroupProductPromotion.SelectedValue, out myId);
            model.groupProductPromotion = myId;
            model.companyid = companyid;
            //int.TryParse(hiddSmallCate.Value, out myId);
            //model.bigCateId = myId;

            //风格
            if (!string.IsNullOrEmpty(ddlstyle.SelectedValue))
            {
                int.TryParse(ddlstyle.SelectedValue, out myId);
                model.styleId = myId;
            }
            else
                model.styleId = 0;
            //材质
            if (!string.IsNullOrEmpty(ddlmaterial.SelectedValue))
            {
                int.TryParse(ddlmaterial.SelectedValue, out myId);
                model.MaterialId = myId;
            }
            else
                model.MaterialId = 0;
            ////系列
            int.TryParse(hiddBrands.Value, out myId);
            model.SeriesId = myId;
            //if (!string.IsNullOrEmpty(Request["SeriesId"]))
            //{
            //    int.TryParse(Request["SeriesId"].Trim(), out myId);
            //    model.SeriesId = myId;
            //}
            //else
            //    model.SeriesId = 0;
            //是否组装
            int IsGroup = 0;
            if (!string.IsNullOrEmpty(Request["IsGroup"]))
                int.TryParse(Request["IsGroup"].Trim(), out IsGroup);
            model.IsGroup = IsGroup;
            //色系
            if (!string.IsNullOrEmpty(ddlcolor.SelectedValue))
            {
                int.TryParse(ddlcolor.SelectedValue, out myId);
                model.ColorId = myId;
            }
            else
                model.ColorId = 0;
            //选择单品id（多个单品可能）
            string singleproductId = hiddSingProductID.Value;
            //如果是子账号添加的产品
            if (memberInfo.parentid != null && memberInfo.parentid != 0)
            {
                model.createmid = int.Parse(memberInfo.parentid.ToString());
            }
            else
            {
                model.createmid = memberInfo.id;
            }
            // model.createmid = memberInfo.id; 
            // string singleproductId = Request["singleproduct"].TrimEnd(',').TrimStart(',').Trim();
            //套组合价格
            model.Price = float.Parse(Request["groupPrice"].Trim());
            //整体图
            model.thumb = thumb;
            //局部图
            model.bannel = bannel;
            //产品描述
            model.Descript = txtdescript.Text;
            //店铺id
            string ShopIdStr = "";
            if (!string.IsNullOrEmpty(Request["shopId"]))
                ShopIdStr = Request["shopId"].TrimEnd(',').Trim();
            if (ShopIdStr == "")
            {
                ShopIdStr = memberInfo.shopid.ToString();

            }
            //产品属性名称            
            if (Request["PropertyName"] != null)
            {
                model.PropertyName = Request["PropertyName"].Trim().Replace("|----", ""); ;
            }
            else
            {
                model.PropertyName = "";
            }


            //发布人（编辑人）
            model.userName = CookiesHelper.GetCookie("mname");
            model.createmid = int.Parse(CookiesHelper.GetCookie("mid"));
            int gpid = 0;
            if (!string.IsNullOrEmpty(Request["gpId"]))
            {
                int.TryParse(Request["gpId"].Trim(), out gpId);
                model.gpId = gpId;
                gpid = ProductBll.SaveEditorGroupProductDb(model, singleproductId, ShopIdStr);
            }
            else
                gpid = ProductBll.SaveIssueGroupProductDb(model, singleproductId, ShopIdStr);

            #region 通知客服邮件
            if (model.gpId == 0)
            {
                string mailsubject = string.Format(@"
                        <p>商家: {0} 用户名：{5}</p>
                        <p>添加了套组合产品。</p>
                        <p>产品id:{1} 产品名称:{2}</p>
                        <p>商家id:{3} 商家身份:{4}</p>"
                        , companyInfo.title, gpid, model.Name, companyInfo.id, memberInfo.type, memberInfo.username);
                string[] mailto = TREC.ECommerce.ECommon.ServiceMail.Split(',');
                foreach (string items in mailto)
                {
                    bool rsmail = EmailHelper.SendEmail("家具快搜 商家添加套组合产品通知提示", items, mailsubject);
                }
            }
            #endregion
            if (gpid > 0)
            {


                #region 添加店铺
                //店铺id


                //店铺关联表是单品的
                //套组合店铺设置为数据表GroupProduct.的值 不用关联表
                string shopsid = string.Empty;
                //if (!string.IsNullOrEmpty(Request["shopId"]))
                //{
                //    shopsid = Request["shopId"].TrimEnd(',').Trim();
                //    EnProductShopPrice modelShop = new EnProductShopPrice();
                //    string[] arrshops = shopsid.Split(',');
                //    for (int i = 0; i < arrshops.Length; i++)
                //    {
                //        modelShop.Productid = gpid;
                //        modelShop.Shopid = int.Parse(arrshops[i]);
                //        //品牌
                //        int.TryParse(ddlbrand.SelectedValue, out myId);
                //        modelShop.Brandid = myId;
                //        //系列
                //        if (!string.IsNullOrEmpty(Request["SeriesId"]))
                //        {
                //            int.TryParse(Request["SeriesId"].Trim(), out myId);
                //            model.SeriesId = myId;
                //        }
                //        modelShop.Brandsid = myId;
                //        modelShop.Lastedittime = DateTime.Now;
                //        ECProductShopPrice.EditProductShopPrice(modelShop);
                //    }
                //}
                #endregion

                ECUpLoad ecUpload = new ECUpLoad();
                #region 处理图片

                if (thumb.Length > 0)
                {
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._550_410);
                    alst1.Add(ecUpload._230_173);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._1_1);
                    // string name = FileUpload1.PostedFile.FileName;                  // 客户端文件路径
                    // FileInfo file = new FileInfo(thumb);  upload/product/thumb/22063//20141209174801608977.jpg      
                    string oldFilePath = string.Empty;
                    string newFilePath = string.Empty;
                    string newFilePath2 = string.Empty;


                    if (hiddgpid.Value != "")
                    {
                        #region 如果是复制套组合，则不需要保存图片，复制图片
                        oldFilePath = Server.MapPath("~/upload/productgroup/thumb/" + hiddgpid.Value + "/" + thumb);
                        if (oldFilePath != "" && File.Exists(oldFilePath))
                        {
                            var str1 = oldFilePath.Substring(0, oldFilePath.IndexOf("thumb") + 6);
                            var str2 = oldFilePath.Substring(str1.Length, oldFilePath.Length - str1.Length);
                            newFilePath = str1 + gpid + "\\" + str2.Substring(str2.LastIndexOf("\\"), str2.Length - str2.LastIndexOf("\\"));
                            newFilePath2 = str1 + gpid + "\\";
                            try
                            {
                                if (!Directory.Exists(newFilePath2))
                                {
                                    Directory.CreateDirectory(newFilePath2);
                                }

                                DirectoryInfo dinfo = new DirectoryInfo(Server.MapPath("~/upload/productgroup/thumb/" + hiddgpid.Value + "/"));//注，这里面传的是路径，并不是文件，所以不能保含带后缀的文件
                                foreach (FileSystemInfo f in dinfo.GetFileSystemInfos())
                                {
                                    File.Copy(oldFilePath, newFilePath, true);//true代表可以覆盖同名文件
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }
                        else
                        {
                            ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.ProductGroup, gpid, EnFilePath.Thumb), alst1, alst2, true);
                        }
                        #endregion
                    }
                    else
                    {
                        ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.ProductGroup, gpid, EnFilePath.Thumb), alst1, alst2, true);
                    }

                }
                //if (desimage.Length > 0)
                //{
                //    ecUpload.MoveFiles(desimage.Split(','), string.Format(EnFilePath.Product, aid, EnFilePath.DesImage));
                //}
                if (bannel.Length > 0)
                {
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._750_2000);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._1_1);

                    string oldFilePath = string.Empty;
                    string newFilePath = string.Empty;
                    string newFilePath2 = string.Empty;
                    if (hiddgpid.Value != "")
                    {
                        #region 如果是复制套组合，则不需要保存图片，复制图片
                        //var dd = bannel.Substring(bannel.Length-1, bannel.Length);
                        //if (bannel.Substring(bannel.Length-1,bannel.Length)==",")
                        //{
                        //    bannel = bannel.Substring(0,bannel.Length-1);
                        //}
                        string[] bannelArr = bannel.Split(',');
                        for (int i = 0; i < bannelArr.Length; i++)
                        {
                            if (bannelArr[i] != "")
                            {
                                oldFilePath = Server.MapPath("~/upload/productgroup/banner/" + hiddgpid.Value + "/" + bannelArr[i]);
                                var str1 = oldFilePath.Substring(0, oldFilePath.IndexOf("banner") + 7);
                                var str2 = oldFilePath.Substring(str1.Length, oldFilePath.Length - str1.Length);
                                newFilePath = str1 + gpid + "\\" + str2.Substring(str2.LastIndexOf("\\"), str2.Length - str2.LastIndexOf("\\"));
                                newFilePath2 = str1 + gpid + "\\";

                                if (oldFilePath != "" && File.Exists(oldFilePath))
                                {
                                    #region 开始复制

                                    try
                                    {
                                        if (!Directory.Exists(newFilePath2))
                                        {
                                            Directory.CreateDirectory(newFilePath2);
                                        }

                                        DirectoryInfo dinfo = new DirectoryInfo(Server.MapPath("~/upload/productgroup/banner/" + hiddgpid.Value + "/"));//注，这里面传的是路径，并不是文件，所以不能保含带后缀的文件
                                        foreach (FileSystemInfo f in dinfo.GetFileSystemInfos())
                                        {
                                            File.Copy(oldFilePath, newFilePath, true);//true代表可以覆盖同名文件
                                        }
                                    }
                                    catch (Exception)
                                    {

                                        throw;
                                    }
                                    #endregion
                                }
                                else
                                {
                                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.ProductGroup, gpid, EnFilePath.Banner), alst1, alst2, true);
                                }
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.ProductGroup, gpid, EnFilePath.Banner), alst1, alst2, true);
                    }
                    // ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Product, gpid, EnFilePath.Banner), alst1, alst2, true);
                }

                #endregion
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "click", "alert('保存套组合产品成功！');location.href='groupproductList.aspx';", true);
            }
        }
        #endregion


    }

}