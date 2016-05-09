using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using System.Data;
using System.Text;

namespace TREC.Web.Suppler.ajax
{
    /// <summary>
    /// MemberHandler 的摘要说明
    /// </summary>
    public class MemberHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string memberId = CookiesHelper.GetCookie("mid");
            string Action = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["Action"]))
                Action = context.Request["Action"].Trim();
            if (string.IsNullOrEmpty(memberId))
                context.Response.Write("login");
            else if (string.IsNullOrEmpty(Action))
                context.Response.Write("perror");
            else
            {
                #region 其他操作

                //1、品牌相关操作
                if (!string.IsNullOrEmpty(context.Request["brandId"]))
                {
                    string brandId = context.Request["brandId"].TrimEnd(',').Trim();
                    if (Action != "setprice")
                    {
                       // handleBrandDb(context, Action, brandId);
                    }
                }

                //2、回收站品牌相关操作
                if (!string.IsNullOrEmpty(context.Request["recyclebrandId"]))
                {
                    string brandId = context.Request["recyclebrandId"].TrimEnd(',').Trim();
                    handleRecycleBrandDb(context, Action, brandId);
                }

                //3、系列相关操作
                if (!string.IsNullOrEmpty(context.Request["seriesbrandId"]))
                {
                    int seriesbrandId = 0;
                    int.TryParse(context.Request["seriesbrandId"].Trim(), out seriesbrandId);
                    if (0 < seriesbrandId)
                    {
                        if (Action == "chkseriesname")
                        {
                            int SeriesId = int.Parse(context.Request["SeriesId"].Trim());
                            string SeriesName = context.Request["SeriesName"].Trim();
                            if (0 <= SeriesId && !string.IsNullOrEmpty(SeriesName))
                                checkBrandSeriesName(context, SeriesId, SeriesName, seriesbrandId);
                        }
                    }
                }
                #endregion

                #region 判断类型

                //4、保存色板数据
                if (Action == "saveswatch")
                    saveSwatchDb(context);

                //5、将品牌系列删除至回收站中
                if (Action == "delseries")
                    deleteBrandSeriesToRecycle(context, memberId);

                //6、系列回收站相关操作
                if (!string.IsNullOrEmpty(context.Request["recycleId"]))
                {
                    string recycleId = context.Request["recycleId"].TrimEnd(',').Trim();
                    if (!string.IsNullOrEmpty(recycleId))
                    {
                        doBrandSeriesRecycle(context, recycleId, Action, memberId);
                    }
                }

                //7、查询店铺时，卖场信息
                if (Action == "market")
                {
                    queryShopMarketDb(context);
                }

                //8、店铺操作
                if (Action == "doshop")
                    handleShopDb(context);

                //9、回收站店铺操作
                if (Action == "doshoprecycle")
                    handleShopRecycle(context);

                //10、修改商务信息推荐
                if (Action == "updaterc")
                    updateRecommendSort(context, memberId);

                //修改商务信息状态
                if (Action == "handleinfo")
                    handlePromotionsInfoStatus(context, memberId);

                //添加颜色
                if (Action == "savecolor")
                    saveProductAttributeColor(context, memberId);
                //获取颜色
                if (Action == "getcolor")
                    getProductAttributeColor(context, memberId);
                //添加类型
                if (Action == "savetype")
                    saveProductAttributeType(context, memberId);
                //搜索套组合单品
                if (Action == "searchgroupproduct")
                {
                    SearchGroupProductDb(context);
                }
                //搜索套组合单品byid
                if (Action == "searchproductbyid")
                {
                    SearchProductById(context);
                }
                //编辑是加载套组合信息
                if (Action == "editgroupproduct")
                {
                    editgroupproduct(context);
                }
                #endregion

                #region 判断类型1

                //获取复制套组合产品数据
                if (Action == "copygroupproduct")
                {
                    copygroupproduct(context);
                }
                //获取套组合单个信息
                if (Action == "getcopygroupproduct")
                {
                    copyProductGroup(context);
                }
                //复制套组合时加载套组合描述信息，由于描述里面可能包含html代码，所有要单独获取

                if (Action == "getcopygroupproductdescript")
                {
                    getcopygroupproductDescript(context);
                }
                //复制单品时加载单品描述信息，由于描述里面可能包含html代码，所有要单独获取

                if (Action == "getcopyproductdescript")
                {
                    getcopyproductDescript(context);
                }


                //添加单品时获取合单品信息列表
                if (Action == "copyproduct")
                {
                    copyproduct(context);
                }
                //获取单品详细信息
                if (Action == "copypptopp")
                {
                    copypptopp(context);
                }
                //获取单品属性详细信息
                if (Action == "getproductattr")
                {
                    getProductAttrbuteHTML(context);
                }
                //自动加载品牌信息
                if (Action == "searchbrand")
                {
                    searchbrand(context);
                }
                #endregion

                //根据小类，获取产品类型
                if (Action == "gettype")
                {
                    gettype(context);
                }
                //根据系列id获取系列详细信息
                if (Action == "getbrandsmodel")
                {
                    getbrandsModel(context);
                }
                //删除色板数据到回收站
                if (Action == "delsw")
                {
                    delsw(context);
                }
                //还原回收站色板数据
                if (Action == "revertswrecycle")
                {
                    RevertColorSwatchRecycle(context);
                }

                //删除回收站色板数据
                if (Action == "delswrecycle")
                {
                    DelColorSwatchRecycle(context);
                }
                //调价管理
                if (Action == "setprice")
                {
                    SetPriceDb(context);
                }

                //按id列表 搜索卖场
                if (Action == "searchmarketbyid")
                {
                    Searchmarketbyid(context);
                }
                //按关键字 列表 搜索卖场
                if (Action == "searchmarketbykey")
                {
                    Searchmarketbykey(context);
                }
                switch (Action)
                {
                    case "bfs"://品牌厂商
                        BrandFactorySettled(context);
                        break;
                    case "ds"://经销商
                        DealerSettled(context);
                        break;
                    case "ms": //MarketSeller 卖场
                        MarketSettled(context);
                        break;
                    default:
                        break;
                }

            }
        }

        private void SearchProductById(HttpContext c)
        {
            //查询条件
            string Where = string.Format(" id in ({0}) ", c.Request["IdList"].Trim());

            int currentPage = 1;

            #region 读取绑定数据

            //总记录数
            int Counts = 0;
            //每页显示记录数
            int pagequantity = 100;
            List<EnProduct> productList = ECProduct.GetProductList(currentPage, pagequantity, Where, out Counts);
            string back = "";
            if (productList != null)
            {
                //总页数
                int PageCount = 0;
                //计算总页数
                if (Counts % pagequantity != 0)
                    PageCount = (Counts - Counts % pagequantity) / pagequantity + 1;
                else
                    PageCount = Counts / pagequantity;
                back = "<tr><th align=\"center\" nowrap><a onclick=\"chkboxAll(this,'msgtableSelect');\">选择</a></th><th nowrap align=\"center\">编号"
                    + "</th><th align=\"center\" nowrap>分类名称</th><th align=\"center\" nowrap>图片</th><th align=\"center\" nowrap>"
                        + "名称</th><th align=\"center\" nowrap>尺寸</th><th align=\"center\" nowrap>状态</th><th align=\"center\" nowrap>上/下线</th></tr>";
                foreach (EnProduct model in productList)
                {
                    back += "<tr><td><input type=\"checkbox\" value=\"" + model.id + "\" /></td>" +
                        "<td>" + model.sku + "</td>" + "<td>" + model.categorytitle + "</td><td><a>" +
"<img width=\"100\" height=\"60\" src=\"" + TREC.Entity.EnFilePath.GetProductThumbPath("" + model.id.ToString() + "", model.thumb != null ? model.thumb : "" + "", "upload") + "\"></a></td>" + "<td>" + model.title + "</td><td>" + getProductSize(model.id) + "</td>" +
                       "<td>" + GetStatusStr(model.auditstatus) + "</td><td>" + GetLine(model.linestatus) + "</td></tr>";
                }
                back += "$" + PageCount;
                productList.Clear();
                productList = null;
            #endregion

            }
            else
            {
                back = "no";
            }
            c.Response.Write(back);
        }


        #region 调价管理
        private void SetPriceDb(HttpContext c)
        {
            if (!string.IsNullOrEmpty(c.Request["pricetype"]))
            {
                //调整类型（1表示根据市场价调整销售价；0表示根据销售价调整市场价）
                int pricetype = -1;
                int.TryParse(c.Request["pricetype"].Trim(), out pricetype);
                //百分比
                int pp = 0;
                if (!string.IsNullOrEmpty(c.Request["pp"]))
                    int.TryParse(c.Request["pp"].Trim(), out pp);
                if (pp != 0)
                {
                    //品牌id
                    int brandId = 0;
                    if (!string.IsNullOrEmpty(c.Request["brandId"]))
                        int.TryParse(c.Request["brandId"].Trim(), out brandId);
                    //系列id
                    int seriesId = 0;
                    if (!string.IsNullOrEmpty(c.Request["seriesId"]))
                        int.TryParse(c.Request["seriesId"].Trim(), out seriesId);
                    //店铺id
                    int shopId = 0;
                    if (!string.IsNullOrEmpty(c.Request["shopId"]))
                        int.TryParse(c.Request["shopId"].Trim(), out shopId);
                    bool IsDo = ProductBll.SetProductPrice(brandId, seriesId, shopId, pricetype, pp, CookiesHelper.GetCookie("mid"));
                    if (IsDo)
                        c.Response.Write("success");
                    else
                        c.Response.Write("fail");
                }
            }
        }
        #endregion

        #region 删除回收站中色板数据
        /// <summary>
        /// 删除回收站中色板数据
        /// </summary>
        /// <param name="c"></param>
        /// <param name="swId">色板id</param>        
        private void DelColorSwatchRecycle(HttpContext c)
        {
            string swid = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["swId"]))
            {
                swid = c.Request["swId"].Trim();
            }

            if (ColorSwatchBll.DelColorSwatchRecycle(swid) > 0)
            {
                c.Response.Write("success");
            }
            else
            {
                c.Response.Write("fail");
            }
        }
        #endregion
        #region 删除色板

        private void delsw(HttpContext c)
        {
            string swid = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["swId"]))
            {
                swid = c.Request["swId"].Trim();
            }
            if (ColorSwatchBll.DelColorSwatchDbBySwId(swid.TrimEnd(',').Trim()) > 0)
            {
                c.Response.Write("success");
            }
            else
            {
                c.Response.Write("fail");
            }

        }
        #endregion
        /// <summary>
        /// 还原回收站中色板数据
        /// </summary>
        /// <param name="c"></param>                
        private void RevertColorSwatchRecycle(HttpContext c)
        {
            string swid = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["swId"]))
            {
                swid = c.Request["swId"].Trim();
            }
            if (ColorSwatchBll.RevertColorSwatchRecycle(swid) > 0)
            {
                c.Response.Write("success");
            }
            else
            {
                c.Response.Write("fail");
            }
        }
        #region 还原色板回收站数据

        #endregion

        #region 卖场入住
        private void MarketSettled(HttpContext c)
        {
            string title = c.Request["mMarkName"] + c.Request["stitle"];
            int id = -1;

            EnMarket _market = ECMarket.GetMarketList(" title='" + title.Replace("集团", "") + "'").FirstOrDefault();
            if (_market == null)
            {
                id = 0;
            }
            else
            {
                if (_market.mid > 0)
                {
                    id = -1;
                }
                else if(_market.mid==0&&_market.createmid>0) 
                {
                    id = _market.id;
                }
            }
            EnMember memberInfoModel = ECMember.GetMemberInfo(" where id=" + CookiesHelper.GetCookie("mid") + " and password='" + CookiesHelper.GetCookie("mpwd") + "'");
            if (id > -1)
            {
                if (memberInfoModel != null)
                {
                    #region 接收参数
                    memberInfoModel.tname = c.Request["mContact"];
                    memberInfoModel.phone = c.Request["mTel"];
                    //  memberInfoModel.mobile = c.Request["mTel"];
                    memberInfoModel.email = c.Request["mEmail"];
                    memberInfoModel.career = c.Request["mDuty"];
                    memberInfoModel.lastedittime = DateTime.Now;
                    memberInfoModel.qq = c.Request["mQQWeiBo"];
                    memberInfoModel.address = c.Request["mAddress"];
                    memberInfoModel.areacode = c.Request["mDistrict"];
                    string ismMarketClique = c.Request["ismMarketClique"];//是否为卖场集团
                    memberInfoModel.type = 101;
                    #endregion
                    if (ECMember.EditMember(memberInfoModel) > 0)
                    {
                        #region 卖场

                        EnMarket _marketInfo = new EnMarket();
                        _marketInfo.id = id;
                        _marketInfo.mid = memberInfoModel.id;
                        _marketInfo.createmid = memberInfoModel.id;
                        _marketInfo.title = title;
                        _marketInfo.Stitle = c.Request["stitle"];
                        _marketInfo.MarketCliqueName = c.Request["mMarkName"].Replace("集团", "");
                        _marketInfo.letter = "";
                        _marketInfo.groupid = 0;
                        _marketInfo.attribute = "";
                        _marketInfo.industry = "";
                        _marketInfo.productcategory = "";
                        _marketInfo.vip = 0;
                        _marketInfo.areacode = memberInfoModel.areacode;
                        _marketInfo.address = memberInfoModel.address;
                        _marketInfo.staffsize = 0;
                        _marketInfo.regyear = "2000";
                        _marketInfo.regcity = "";
                        _marketInfo.buy = "";
                        _marketInfo.sell = "";
                        _marketInfo.linkman = memberInfoModel.tname;
                        _marketInfo.phone = memberInfoModel.phone;
                        _marketInfo.mphone = memberInfoModel.mobile;
                        _marketInfo.fax = "";
                        _marketInfo.email = memberInfoModel.email;
                        _marketInfo.postcode = "";
                        _marketInfo.homepage = "";
                        _marketInfo.domain = "";
                        _marketInfo.domainip = "";
                        _marketInfo.icp = "";
                        _marketInfo.surface = "";
                        _marketInfo.logo = "";
                        _marketInfo.thumb = "";
                        _marketInfo.bannel = "";
                        _marketInfo.desimage = "";
                        _marketInfo.descript = "";
                        _marketInfo.keywords = "";
                        _marketInfo.template = "1";
                        _marketInfo.busroute = "";
                        _marketInfo.cbm = 0;
                        _marketInfo.hours = "";
                        _marketInfo.zphone = "";
                        _marketInfo.hits = 0;
                        _marketInfo.sort = 0;
                        _marketInfo.lastedid = memberInfoModel.id;
                        _marketInfo.lastedittime = DateTime.Now;
                        _marketInfo.auditstatus = 0;
                        _marketInfo.linestatus = 0;

                        int aid = 0;
                        aid = ECMarket.EditMarket(_marketInfo);

                        if (aid > 0)
                        {
                            //Remarks:注册邮件
                            EmailHelper.SendEmailReg(_marketInfo.title, null, "卖场", memberInfoModel.phone, memberInfoModel.tname, memberInfoModel.qq);
                        }

                        #endregion

                        #region 集团卖场身份 补充集团资料 2015-03-20
                        if (ismMarketClique == "1")
                        {
                            EnMarketClique _mc = new EnMarketClique();
                            _mc.Title = _marketInfo.title;
                            _mc.CreateMid = memberInfoModel.id;
                            _mc.CreateTime = DateTime.Now;
                            _mc.MarketId = aid;
                            _mc.Auditstatus = 0;
                            _mc.LastediTime = DateTime.Now;
                            ECMarketClique.EditMarketClique(_mc);
                        }
                        #endregion

                        #region 通知客服邮件
                        string mailsubject = string.Format(@"
                        <p>新注册卖场 {0} 用户名：{1}</p> 
                        <p>商家id:{2} 商家身份:{3}</p>"
                                , _marketInfo.title, memberInfoModel.username, aid, 103);
                        if (ismMarketClique == "1")
                        {
                            mailsubject += "<p>商家属于卖场集团身份</p>";
                        }
                        string[] mailto = TREC.ECommerce.ECommon.ServiceMail.Split(',');
                        foreach (string items in mailto)
                        {
                            bool rsmail = EmailHelper.SendEmail("家具快搜 卖场商家注册提示", items, mailsubject);
                        }
                        #endregion

                        c.Response.Write("Success");
                    }
                    else
                    {
                        c.Response.Write("Fail");
                    }

                }
            }
            else
            {
                c.Response.Write("卖场已经存在，不能重复添加");
            }
        }
        #endregion

        #region 经销商入住


        private void DealerSettled(HttpContext c)
        {

            #region MyRegion

            //联系人(E-mail)为必填项
            //int fillQuantity = 2;

            //代理品牌
            // model.brandName = c.Server.UrlDecode(c.Request["dBrandName"].Trim());
            //工厂名称
            // model.myName = c.Server.UrlDecode(c.Request["dFactoryName"].Trim());
            //店铺名称
            //model.shopName = c.Server.UrlDecode(c.Request["dShopName"].Trim());
            ////会员名
            //model.UserName = CookiesHelper.GetCookie("mname");

            //Model_Account cmodel = new Model_Account();
            ////负责人
            //cmodel.Contact = c.Server.UrlDecode(c.Request["dContact"].Trim());
            ////职位
            //cmodel.Duty = c.Server.UrlDecode(c.Request["dDuty"].Trim());
            //if (cmodel.Duty != "")
            //    ++fillQuantity;
            ////电话
            //cmodel.Tel = c.Server.UrlDecode(c.Request["dTel"].Trim());
            //if (cmodel.Tel != "")
            //    ++fillQuantity;
            ////手机
            //cmodel.Mobile = c.Server.UrlDecode(c.Request["dMobile"].Trim());
            //if (cmodel.Mobile != "")
            //    ++fillQuantity;
            ////QQ/微博
            //cmodel.QQWeiBo = c.Server.UrlDecode(c.Request["dQQWeiBo"].Trim());
            //if (cmodel.QQWeiBo != "")
            //    ++fillQuantity;
            ////E-mail
            //cmodel.Email = c.Server.UrlDecode(c.Request["dEmail"].Trim());
            //if (model == null)
            //{
            //    model = new EnDealer();
            //    model.mapapi = "";
            //    model.createmid = 0;
            //}
            #endregion
            EnMember memberInfoModel = ECMember.GetMemberInfo(" where id=" + CookiesHelper.GetCookie("mid") + " and password='" + CookiesHelper.GetCookie("mpwd") + "'");
            EnDealer model = new EnDealer();
            if (memberInfoModel != null)
            {
                #region 接收参数
                memberInfoModel.tname = c.Request["dContact"].Trim();
                memberInfoModel.phone = c.Request["dTel"].Trim();
                //memberInfoModel.mobile = c.Request["dTel"].Trim();
                memberInfoModel.email = c.Request["dEmail"].Trim();
                memberInfoModel.career = c.Request["dDuty"].Trim();
                memberInfoModel.lastedittime = DateTime.Now;
                memberInfoModel.qq = c.Request["dQQWeiBo"].Trim();
                memberInfoModel.address = c.Request["ddAddress"].Trim();
                memberInfoModel.areacode = c.Request["dAreacode"].Trim();
                memberInfoModel.type = 102;
                #endregion
                if (ECMember.EditMember(memberInfoModel) > 0)
                {

                    #region 实体赋值

                    model.mid = memberInfoModel.id;
                    model.title = c.Server.UrlDecode(c.Request["dContact"].Trim());
                    model.areacode = c.Server.UrlDecode(c.Request["dAreacode"].Trim());
                    model.address = c.Server.UrlDecode(c.Request["ddAddress"].Trim());
                    model.staffsize = 0;
                    model.regyear = "";
                    model.regcity = c.Server.UrlDecode(c.Request["dCity"].Trim());
                    model.sell = "";
                    model.linkman = c.Server.UrlDecode(c.Request["dContact"].Trim());
                    model.phone = c.Server.UrlDecode(c.Request["dTel"].Trim()); ;
                    model.mphone = c.Server.UrlDecode(c.Request["dMobile"].Trim());
                    model.fax = "";
                    model.email = c.Server.UrlDecode(c.Request["dEmail"].Trim());
                    model.postcode = "";
                    model.homepage = "";
                    model.thumb = "";
                    model.bannel = "";
                    model.descript = "";
                    model.lastedid = model.mid;
                    model.lastedittime = DateTime.Now;
                    model.auditstatus = 0;
                    model.dbook = "";
                    model.template = "1";
                    int myid = 0;
                    int.TryParse(c.Request["dDtype"], out myid);
                    model.dealertype = myid;
                    int dealerid = ECDealer.EditDealer(model);
                    #endregion

                    #region 通知客服邮件
                    string mailsubject = string.Format(@"
                        <p>新注册经销商 {0} 用户名：{1}</p> 
                        <p>商家id:{2} 商家身份:{3}</p>"
                            , model.title, memberInfoModel.username, dealerid, 103);
                    string[] mailto = TREC.ECommerce.ECommon.ServiceMail.Split(',');
                    foreach (string items in mailto)
                    {
                        bool rsmail = EmailHelper.SendEmail("家具快搜 经销商商家注册提示", items, mailsubject);
                    }
                    #endregion

                    if (dealerid > 0)
                    {
                        #region 添加品牌

                        if (c.Server.UrlDecode(c.Request["dBrandName"].Trim()) != null)
                        {
                            #region 品牌基本信息
                            DateTime lastedittime = DateTime.Now;
                            EnBrand brandModel = new EnBrand();
                            brandModel.createmid = memberInfoModel.id;
                            brandModel.productcount = 0;
                            brandModel.attribute = "";
                            brandModel.keywords = "";
                            brandModel.template = "default";
                            brandModel.homepage = "";
                            brandModel.hits = 0;
                            brandModel.sort = 0;
                            brandModel.auditstatus = 1;
                            brandModel.linestatus = 0;
                            brandModel.companyid = 0;
                            brandModel.title = c.Server.UrlDecode(c.Request["dBrandName"].Trim());
                            brandModel.letter = "";
                            brandModel.productcategory = "";
                            brandModel.style = "";
                            brandModel.material = "";
                            brandModel.spread = "";
                            brandModel.color = "";
                            brandModel.surface = "";
                            brandModel.logo = "";
                            brandModel.thumb = "";
                            brandModel.bannel = "";
                            brandModel.desimage = "";
                            brandModel.descript = "";
                            brandModel.lastedittime = lastedittime;
                            int brandId = ECBrand.EditBrand(brandModel);
                            if (brandId > 0)
                            {
                                #region 品牌申请

                                EnAppBrand appmodel = new EnAppBrand();
                                appmodel.id = 0;
                                appmodel.dealerid = dealerid;
                                appmodel.dealetitle = model.title;
                                appmodel.brandid = brandId;
                                appmodel.brandtitle = brandModel.title;
                                appmodel.companyid = 0;
                                appmodel.companytitle = "";
                                appmodel.shopid = 0;
                                appmodel.shoptitle = "";
                                appmodel.appmodule = (int)EnumAppBrandModule.经销商申请;
                                appmodel.apptype = (int)EnumAppBrandType.申请新建品牌;
                                appmodel.apptime = DateTime.Now;
                                appmodel.createmid = memberInfoModel.id;
                                appmodel.lastedittime = DateTime.Now;
                                appmodel.auditstatus = 0;
                                #endregion

                                int aid = ECAppBrand.EditAppBrand(appmodel);
                            }
                            #endregion
                        }
                        #endregion
                        EmailHelper.SendEmailReg(model.title, model.email, "经销商", model.mphone, model.linkman, null);
                        c.Response.Write("Success");
                    }
                }
                else
                {
                    c.Response.Write("Fail");
                }

            }

        }
        #endregion

        #region 品牌厂商入住
        private void BrandFactorySettled(HttpContext c)
        {
            EnMember memberInfoModel = ECMember.GetMemberInfo(" where id=" + CookiesHelper.GetCookie("mid") + " and password='" + CookiesHelper.GetCookie("mpwd") + "'");
            if (memberInfoModel != null)
            {

                #region 接收参数
                memberInfoModel.tname = c.Request["cfContact"].Trim();
                memberInfoModel.phone = c.Request["cfTel"].Trim();
                //memberInfoModel.mobile = c.Request["cfTel"].Trim();
                memberInfoModel.email = c.Request["cfEmail"].Trim();
                memberInfoModel.career = c.Request["cfDuty"].Trim();
                memberInfoModel.lastedittime = DateTime.Now;
                memberInfoModel.qq = c.Request["cfQQWeiBo"].Trim();
                memberInfoModel.address = c.Request["cfAddress"].Trim();
                memberInfoModel.areacode = c.Request["cfDistrict"].Trim();
                memberInfoModel.type = 101;
                #endregion
                if (ECMember.EditMember(memberInfoModel) > 0)
                {
                    #region 工厂企业
                    EnCompany _companyInfo = null;
                    EnCompany companyInfo = ECCompany.GetCompanyInfo(" where mid=" + memberInfoModel.id);
                    if (_companyInfo != null)
                    {
                        _companyInfo = companyInfo;
                    }
                    else
                    {
                        _companyInfo = new EnCompany();
                        _companyInfo.id = 0;
                        _companyInfo.mid = memberInfoModel.id;
                        _companyInfo.title = c.Request["bFactoryName"].Trim();
                        _companyInfo.letter = "";
                        _companyInfo.groupid = 0;
                        _companyInfo.attribute = "";
                        _companyInfo.industry = "";
                        _companyInfo.productcategory = "";
                        _companyInfo.vip = 0;
                        _companyInfo.areacode = memberInfoModel.areacode;
                        _companyInfo.address = memberInfoModel.address;
                        _companyInfo.staffsize = 0;
                        _companyInfo.regyear = "2000";
                        _companyInfo.regcity = "";
                        _companyInfo.buy = "";
                        _companyInfo.sell = "";
                        _companyInfo.linkman = memberInfoModel.tname;
                        _companyInfo.phone = memberInfoModel.phone;
                        _companyInfo.mphone = memberInfoModel.mobile;
                        _companyInfo.fax = "";
                        _companyInfo.email = memberInfoModel.email;
                        _companyInfo.postcode = "";
                        _companyInfo.homepage = "";
                        _companyInfo.domain = "";
                        _companyInfo.domainip = "";
                        _companyInfo.icp = "";
                        _companyInfo.surface = "";
                        _companyInfo.logo = "";
                        _companyInfo.thumb = "";
                        _companyInfo.bannel = "";
                        _companyInfo.desimage = "";
                        _companyInfo.descript = "";
                        _companyInfo.keywords = "";
                        _companyInfo.template = "1";
                        _companyInfo.hits = 0;
                        _companyInfo.sort = 0;
                        _companyInfo.lastedid = memberInfoModel.id;
                        _companyInfo.lastedittime = DateTime.Now;
                        _companyInfo.auditstatus = 0;
                        _companyInfo.linestatus = 0;
                        _companyInfo.QQWeiBo = memberInfoModel.qq;
                        _companyInfo.Duty = memberInfoModel.career;
                        _companyInfo.BrandInfo = c.Request["bfBrand"].Trim();

                        int aid = 0;
                        aid = ECCompany.EditCompany(_companyInfo);
                        if (aid > 0)
                        {
                            //EmailHelper.SendEmailReg(_companyInfo.title, null, "工厂企业", memberInfoModel.phone, memberInfoModel.tname, memberInfoModel.qq);
                            //ScriptUtils.RedirectFrame(this.Page, "index.aspx");
                        }

                        #region 通知客服邮件
                        string mailsubject = string.Format(@"
                        <p>新注册品牌商家: {0} 用户名：{1}</p> 
                        <p>商家id:{2} 商家身份:{3}</p>"
                                , _companyInfo.title, memberInfoModel.username, aid, 101);
                        string[] mailto = TREC.ECommerce.ECommon.ServiceMail.Split(',');
                        foreach (string items in mailto)
                        {
                            bool rsmail = EmailHelper.SendEmail("家具快搜 品牌商家注册提示", items, mailsubject);
                        }
                        #endregion
                    }
                    #endregion

                    #region 添加品牌
                    if (c.Server.UrlDecode(c.Request["dBrandName"]) != null)
                    {
                        EnBrand model = new EnBrand();
                        model.companyid = _companyInfo.id;
                        model.title = c.Server.UrlDecode(c.Request["dBrandName"]);
                        model.letter = "";
                        model.productcategory = "";

                        model.style = "";
                        model.material = "";
                        model.spread = "";
                        model.color = "";

                        model.surface = "";
                        model.logo = "";
                        model.thumb = "";
                        model.bannel = "";
                        model.desimage = "";
                        model.descript = "";
                        model.lastedittime = DateTime.Now;
                        int aid = ECBrand.EditBrand(model);
                    }
                    #endregion




                    c.Response.Write("Success");
                }
                else
                {
                    c.Response.Write("Fail");
                }
            }

        }

        #endregion

        #region 根据系列id获取系列详细信息

        private void getbrandsModel(HttpContext c)
        {
            int myId = 0;
            if (!string.IsNullOrEmpty(c.Request["brandsid"]))
            {
                int.TryParse(c.Request["brandsid"].Trim(), out myId);
            }
            EnBrands model = new EnBrands();
            model = ECBrand.GetBrandsInfo(string.Format(" where id={0}", myId)); ;
            StringBuilder retuJsonBrands = new StringBuilder();
            if (model != null)
            {
                retuJsonBrands.Append("{");
                retuJsonBrands.Append("style:'" + model.style + "',");
                retuJsonBrands.Append("color:'" + model.color + "',");
                retuJsonBrands.Append("material:'" + model.material + "'");
                retuJsonBrands.Append("}");

            }
            c.Response.Write(retuJsonBrands.ToString());

        }
        #endregion

        #region 根据小类，获取产品类型
        private void gettype(HttpContext c)
        {
            int myId = 0;

            if (!string.IsNullOrEmpty(c.Request["smallCID"]))
            {
                int.TryParse(c.Request["smallCID"].Trim(), out myId);
            }
            string producttypelist = ECPCategoryPTyp.GetProductCategoryTypeValueList(myId);
            List<EnConfig> typeList = ECConfig.GetConfigList(" type=" + (int)EnumConfigByProduct.产品类型 + " and value in(" + producttypelist + ")");
            StringBuilder strType = new StringBuilder();
            //if (typeList != null)
            //{
            //    foreach (var item in typeList)
            //    {
            //        if (strType.ToString()=="")
            //        {
            //        strType.Append("{\"id\":\"" + item.id + "\",\"title\":\"" + item.title + "\"}");
            //        }
            //        else
            //        {
            //            strType.Append(",{\"id\":\"" + item.id + "\",\"title\":\"" + item.title + "\"}");
            //        }

            //    }
            //}
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            c.Response.Write(js.Serialize(typeList));
            // c.Response.Write("["+strType.ToString()+"]");
        }
        #endregion

        #region 自动搜索品牌


        private void searchbrand(HttpContext c)
        {
            string kye = c.Request["key"].ToString().Replace(",", "");
            string strWhere = " 1=1";
            if (kye != "")
            {
                strWhere += "  and  (title like '%" + kye + "%') ";
            }
            List<EnBrand> brandList = ECBrand.GetBrandList(strWhere);
            StringBuilder strProAttr = new StringBuilder();
            foreach (var item in brandList)
            {
                if (strProAttr.ToString() == "")
                {
                    strProAttr.Append("{");
                    strProAttr.Append("\"value\":" + "'" + item.title + "'");
                    strProAttr.Append(",\"label\":" + "'" + item.id + "'");
                    strProAttr.Append(",\"redirecturl\":" + "'" + item.title + "'");
                    strProAttr.Append("}");
                }
                else
                {
                    strProAttr.Append(",{");
                    strProAttr.Append("\"value\":" + "'" + item.title + "'");
                    strProAttr.Append(",\"label\":" + "'" + item.id + "'");
                    strProAttr.Append(",\"redirecturl\":" + "'" + item.title + "'");
                    strProAttr.Append("}");
                }

            }
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            c.Response.Write(js.Serialize(brandList));
            //c.Response.Write("["+brandList+"]");  
        }
        #endregion

        #region 复制单品时加载描述信息，由于描述里面可能包含html代码，所有要单独获取

        private void getcopyproductDescript(HttpContext c)
        {
            int myId = 0;
            //单品id
            if (!string.IsNullOrEmpty(c.Request["productId"]))
            {
                int.TryParse(c.Request["productId"].Trim(), out myId);
            }
            StringBuilder retuJson = new StringBuilder();
            if (myId > 0)
            {
                EnProduct pmodel = ECProduct.GetProductInfo("  where id=" + myId);
                if (pmodel != null)
                {
                    retuJson.Append(pmodel.descript);
                }
            }
            c.Response.Write(retuJson.ToString());
        }
        #endregion

        #region 复制套组合时加载套组合描述信息，由于描述里面可能包含html代码，所有要单独获取

        private void getcopygroupproductDescript(HttpContext c)
        {
            int myId = 0;
            //11.所属套组合
            if (!string.IsNullOrEmpty(c.Request["gpId"]))
            {
                int.TryParse(c.Request["gpId"].Trim(), out myId);
            }
            StringBuilder retuDesc = new StringBuilder();
            if (myId > 0)
            {
                GroupProductModel gpmodel = new GroupProductModel();
                gpmodel = ProductBll.GetModel(myId);
                if (gpmodel != null)
                {
                    retuDesc.Append(gpmodel.Descript);
                }
            }
            c.Response.Write(retuDesc.ToString());
        }
        #endregion

        #region 复制单品时获取单品详细信息
        private void copypptopp(HttpContext c)
        {
            int myId = 0;
            //单品id
            if (!string.IsNullOrEmpty(c.Request["productId"]))
            {
                int.TryParse(c.Request["productId"].Trim(), out myId);
            }
            StringBuilder retuJson = new StringBuilder();
            if (myId > 0)
            {
                EnProduct pmodel = ECProduct.GetProductInfo("  where id=" + myId);
                if (pmodel != null)
                {
                    // back = gpmodel.Name;
                    retuJson.Append("{");
                    retuJson.Append("pId:'" + pmodel.id + "',");
                    retuJson.Append("pSku:'" + pmodel.sku + "',");
                    retuJson.Append("pName:'" + pmodel.title + "',");
                    retuJson.Append("pBrandId:'" + pmodel.brandid + "',");
                    retuJson.Append("pBigCateId:'" + getBigCateId(pmodel.categoryid) + "',");
                    retuJson.Append("pSmallCateId:'" + pmodel.categoryid + "',");
                    retuJson.Append("pCategorytitle:'" + pmodel.categorytitle + "',");
                    retuJson.Append("pStyleId:'" + pmodel.stylevalue + "',");
                    retuJson.Append("pMaterialId:'" + pmodel.materialvalue + "',");
                    retuJson.Append("pBrandsId:'" + pmodel.brandsid + "',");

                    retuJson.Append("pIsGroup:'" + pmodel.assemble + "',");
                    retuJson.Append("pColorId:'" + pmodel.colorvalue + "',");
                    retuJson.Append("pThumb:'" + pmodel.thumb + "',");
                    retuJson.Append("pBannel:'" + pmodel.bannel + "',");
                    // retuJson.Append("pDescript:'" + pmodel.descript + "',");
                    retuJson.Append("pShopids:'" + Getshopids(pmodel.id) + "',");
                    retuJson.Append("pProductAttr:" + "'" + getProductAttrbute(pmodel.id) + "'");
                    //  retuJson.Append("pProductAttrHTML:" + getProductAttrbuteHTML(pmodel.id));
                    retuJson.Append("}");
                }
            }
            c.Response.Write(retuJson.ToString());
        }
        #endregion

        #region 复制单品时 获取单品属性HTML信息
        public void getProductAttrbuteHTML(HttpContext c)
        {
            int pid = 0;
            if (!string.IsNullOrEmpty(c.Request["pid"]))
                int.TryParse(c.Request["pid"], out pid);
            List<EnProductAttribute> listproductattribute = ECProductAttribute.GetProductAttributeList(" productid='" + pid + "'");
            StringBuilder strProAttr = new StringBuilder();
            string proattbute = string.Empty;
            if (listproductattribute != null)
            {
                #region 返回值
                int rowCount = 1;
                string productAttributePromotionName = string.Empty;
                foreach (var item in listproductattribute)
                {
                    strProAttr.Append("<tr id=" + rowCount + " txttitle='" + getProductAttrbuteByStrWhere(" id=" + item.id, rowCount) + "'><td height=\"40\">" + item.productlength + "*" + item.productwidth + "*" + item.productheight + "</td>");
                    strProAttr.Append("<td>" + item.productcbm + "</td>");
                    strProAttr.Append("<td>" + item.productmaterial + "</td>");
                    strProAttr.Append("<td>" + item.productcolortitle + "</td>");
                    strProAttr.Append("<td>" + item.storage + "</td>");
                    strProAttr.Append("<td>" + item.markprice + "</td>");
                    strProAttr.Append("<td>" + item.saleprice + "</td>");
                    strProAttr.Append("<td>" + item.buyprice + "</td>");
                    t_promotionstype pAPN = t_promotionstypeBLL.GetPromotionTypeById(item.productAttributePromotion);
                    if (pAPN != null)
                        productAttributePromotionName = pAPN.title;
                    strProAttr.Append("<td>" + productAttributePromotionName + "</td>");
                    strProAttr.Append("<td><a class=\"myhander\" onclick=\"EditorProductProp(this);\"><img src=\"../Images/bianji.png\" alt=\"编辑\" width=\"16\" height=\"16\" border=\"0\" /><a class=\"myhander\" alt=\"删除\"  onclick=\"DeleteProductProp(this);\"><img src=\"../Images/del.png\"  width='16' height=\"16\" border=\"0\" /></a></td></tr>");
                    rowCount++;

                }
                #endregion


            }

            c.Response.Write(strProAttr.ToString());
        }
        #endregion

        #region 复制单品时 获取单品属性信息
        public string getProductAttrbute(int pid)
        {
            List<EnProductAttribute> listproductattribute = ECProductAttribute.GetProductAttributeList(" productid='" + pid + "'");
            StringBuilder strProAttr = new StringBuilder();
            string proattbute = string.Empty;
            if (listproductattribute != null)
            {
                #region 返回值
                int rowCount = 1;
                foreach (var item in listproductattribute)
                {
                    strProAttr.Append("{");
                    strProAttr.Append("\"rowNum\":" + '"' + rowCount + '"');
                    strProAttr.Append(",\"attrid\":" + '"' + item.id + '"');
                    strProAttr.Append(",\"typeid\":" + "\"" + item.typevalue + "\"");
                    strProAttr.Append(",\"typename\":" + "\"" + item.typename + "\"");
                    strProAttr.Append(",\"productAttributePromotion\":" + "\"" + item.productAttributePromotion + "\"");
                    strProAttr.Append(",\"productAttributePromotionName\":" + "\"\"");
                    strProAttr.Append(",\"pmaterial\":" + "\"" + item.productmaterial + "\"");
                    strProAttr.Append(",\"pacolor\":" + "\"" + item.productcolorvalue + "\"");
                    strProAttr.Append(",\"pcolortitle\":" + "\"" + item.productcolortitle + "\"");
                    strProAttr.Append(",\"plength\":" + "\"" + item.productlength + "\"");
                    strProAttr.Append(",\"pwidth\":" + "\"" + item.productwidth + "\"");
                    strProAttr.Append(",\"pheight\":" + "\"" + item.productheight + "\"");
                    strProAttr.Append(",\"pcbm\":" + "\"" + item.productcbm + "\"");
                    strProAttr.Append(",\"pmprice\":" + "\"" + item.markprice + "\"");
                    strProAttr.Append(",\"SalePrice\":" + "\"" + item.saleprice + "\"");
                    strProAttr.Append(",\"PromoPrice\":" + "\"" + item.buyprice + "\"");
                    strProAttr.Append(",\"Stock\":" + "\"" + item.storage + "\"");
                    strProAttr.Append("},");
                    rowCount++;
                    #region 暂时不用

                    //if (strProAttr.ToString() == "")
                    //{
                    //    strProAttr.Append("{");
                    //    strProAttr.Append("\"rowNum\":" + '"' + rowCount + '"');
                    //    strProAttr.Append(",\"typeid\":" + "\"" + item.typevalue + "\"");
                    //    strProAttr.Append(",\"typename\":" +"\""+ item.typename+"\"" );
                    //    strProAttr.Append(",\"pmaterial\":" + "\""+item.productmaterial+"\""  );
                    //    strProAttr.Append(",\"pacolor\":" +"\""+item.productcolorvalue+"\"" );
                    //    strProAttr.Append(",\"pcolortitle\":" + "\"" + item.productcolortitle + "\"");
                    //    strProAttr.Append(",\"plength\":" + "\""+item.productlength+"\""  );
                    //    strProAttr.Append(",\"pwidth\":" +"\""+item.productwidth+"\""   );
                    //    strProAttr.Append(",\"pheight\":" + "\""+ item.productheight+"\"" );
                    //    strProAttr.Append(",\"pcbm\":" + "\""+item.productcbm+"\""  );
                    //    strProAttr.Append(",\"pmprice\":" +"\""+item.markprice+"\""   );
                    //    strProAttr.Append(",\"SalePrice\":" +"\""+item.saleprice+"\""   );
                    //    strProAttr.Append(",\"PromoPrice\":" +"\""+item.buyprice+"\""   );
                    //    strProAttr.Append(",\"Stock\":" + "\""+item.storage+"\""  );                        
                    //    strProAttr.Append("}");
                    //    rowCount++;
                    //}
                    //else
                    //{
                    //    strProAttr.Append(",{");
                    //    strProAttr.Append("\"rowNum\":" + '"' + rowCount + '"');
                    //    strProAttr.Append(",\"typeid\":" + "\"" + item.typevalue + "\"");
                    //    strProAttr.Append(",\"typename\":" + "\"" + item.typename + "\"");
                    //    strProAttr.Append(",\"pmaterial\":" + "\"" + item.productmaterial + "\"");
                    //    strProAttr.Append(",\"pacolor\":" + "\"" + item.productcolorvalue + "\"");
                    //    strProAttr.Append(",\"pcolortitle\":" + "\"" + item.productcolortitle + "\"");
                    //    strProAttr.Append(",\"plength\":" + "\"" + item.productlength + "\"");
                    //    strProAttr.Append(",\"pwidth\":" + "\"" + item.productwidth + "\"");
                    //    strProAttr.Append(",\"pheight\":" + "\"" + item.productheight + "\"");
                    //    strProAttr.Append(",\"pcbm\":" + "\"" + item.productcbm + "\"");
                    //    strProAttr.Append(",\"pmprice\":" + "\"" + item.markprice + "\"");
                    //    strProAttr.Append(",\"SalePrice\":" + "\"" + item.saleprice + "\"");
                    //    strProAttr.Append(",\"PromoPrice\":" + "\"" + item.buyprice + "\"");
                    //    strProAttr.Append(",\"Stock\":" + "\"" + item.storage + "\""); 
                    //    strProAttr.Append("}");
                    //    rowCount++;
                    //}
                    #endregion

                #endregion

                }
            }

            return strProAttr.ToString();
        }
        #endregion

        #region 复制单品时 获取单品属性信息
        public string getProductAttrbuteByStrWhere(string strWhere, int rowCount)
        {
            List<EnProductAttribute> listproductattribute = ECProductAttribute.GetProductAttributeList(strWhere);
            StringBuilder strProAttr = new StringBuilder();
            string proattbute = string.Empty;
            if (listproductattribute != null)
            {
                #region 返回值
                foreach (var item in listproductattribute)
                {
                    strProAttr.Append("{");
                    strProAttr.Append("\"rowNum\":" + '"' + rowCount + '"');
                    strProAttr.Append(",\"attrid\":" + '"' + item.id + '"');
                    strProAttr.Append(",\"typeid\":" + "\"" + item.typevalue + "\"");
                    strProAttr.Append(",\"typename\":" + "\"" + item.typename + "\"");
                    strProAttr.Append(",\"productAttributePromotion\":" + '"' + item.productAttributePromotion + '"');
                    strProAttr.Append(",\"productAttributePromotionName\":" + '"' + string.Empty + '"');
                    strProAttr.Append(",\"pmaterial\":" + "\"" + item.productmaterial + "\"");
                    strProAttr.Append(",\"pacolor\":" + "\"" + item.productcolorvalue + "\"");
                    strProAttr.Append(",\"pcolortitle\":" + "\"" + item.productcolortitle + "\"");
                    strProAttr.Append(",\"plength\":" + "\"" + item.productlength + "\"");
                    strProAttr.Append(",\"pwidth\":" + "\"" + item.productwidth + "\"");
                    strProAttr.Append(",\"pheight\":" + "\"" + item.productheight + "\"");
                    strProAttr.Append(",\"pcbm\":" + "\"" + item.productcbm + "\"");
                    strProAttr.Append(",\"pmprice\":" + "\"" + item.markprice + "\"");
                    strProAttr.Append(",\"SalePrice\":" + "\"" + item.saleprice + "\"");
                    strProAttr.Append(",\"PromoPrice\":" + "\"" + item.buyprice + "\"");
                    strProAttr.Append(",\"Stock\":" + "\"" + item.storage + "\"");
                    strProAttr.Append("},");
                    rowCount++;
                    #region 暂时不用

                    //if (strProAttr.ToString() == "")
                    //{
                    //    strProAttr.Append("{");
                    //    strProAttr.Append("\"rowNum\":" + '"' + rowCount + '"');
                    //    strProAttr.Append(",\"typeid\":" + "\"" + item.typevalue + "\"");
                    //    strProAttr.Append(",\"typename\":" + "\"" + item.typename + "\"");
                    //    strProAttr.Append(",\"pmaterial\":" + "\"" + item.productmaterial + "\"");
                    //    strProAttr.Append(",\"pacolor\":" + "\"" + item.productcolorvalue + "\"");
                    //    strProAttr.Append(",\"pcolortitle\":" + "\"" + item.productcolortitle + "\"");
                    //    strProAttr.Append(",\"plength\":" + "\"" + item.productlength + "\"");
                    //    strProAttr.Append(",\"pwidth\":" + "\"" + item.productwidth + "\"");
                    //    strProAttr.Append(",\"pheight\":" + "\"" + item.productheight + "\"");
                    //    strProAttr.Append(",\"pcbm\":" + "\"" + item.productcbm + "\"");
                    //    strProAttr.Append(",\"pmprice\":" + "\"" + item.markprice + "\"");
                    //    strProAttr.Append(",\"SalePrice\":" + "\"" + item.saleprice + "\"");
                    //    strProAttr.Append(",\"PromoPrice\":" + "\"" + item.buyprice + "\"");
                    //    strProAttr.Append(",\"Stock\":" + "\"" + item.storage + "\"");
                    //    strProAttr.Append("}");
                    //    rowCount++;
                    //}
                    //else
                    //{
                    //    strProAttr.Append(",{");
                    //    strProAttr.Append("\"rowNum\":" + '"' + rowCount + '"');
                    //    strProAttr.Append(",\"typeid\":" + "\"" + item.typevalue + "\"");
                    //    strProAttr.Append(",\"typename\":" + "\"" + item.typename + "\"");
                    //    strProAttr.Append(",\"pmaterial\":" + "\"" + item.productmaterial + "\"");
                    //    strProAttr.Append(",\"pacolor\":" + "\"" + item.productcolorvalue + "\"");
                    //    strProAttr.Append(",\"pcolortitle\":" + "\"" + item.productcolortitle + "\"");
                    //    strProAttr.Append(",\"plength\":" + "\"" + item.productlength + "\"");
                    //    strProAttr.Append(",\"pwidth\":" + "\"" + item.productwidth + "\"");
                    //    strProAttr.Append(",\"pheight\":" + "\"" + item.productheight + "\"");
                    //    strProAttr.Append(",\"pcbm\":" + "\"" + item.productcbm + "\"");
                    //    strProAttr.Append(",\"pmprice\":" + "\"" + item.markprice + "\"");
                    //    strProAttr.Append(",\"SalePrice\":" + "\"" + item.saleprice + "\"");
                    //    strProAttr.Append(",\"PromoPrice\":" + "\"" + item.buyprice + "\"");
                    //    strProAttr.Append(",\"Stock\":" + "\"" + item.storage + "\"");
                    //    strProAttr.Append("}");
                    //    rowCount++;
                    //}
                    #endregion

                #endregion

                }
            }

            return strProAttr.ToString();
        }
        #endregion

        #region 获取店铺ids
        public string Getshopids(int pid)
        {
            string shopids = string.Empty;
            List<EnProductShopPrice> listpsp = ECProductShopPrice.GetProductShopPriceListByWhere(" productid=" + pid);
            if (listpsp != null && listpsp.Count > 0)
            {
                foreach (var item in listpsp)
                {
                    if (shopids == "")
                    {
                        shopids = item.Shopid.ToString();
                    }
                    else
                    {
                        shopids += "," + item.Shopid.ToString();
                    }
                }
            }
            return shopids;
        }
        #endregion

        #region 根据小类获取大类id
        public int getBigCateId(int smallCateId)
        {
            //大类
            List<EnProductCategory> catagoryList = ECProductCategory.GetProductCategoryListToDDL("");
            var bigCate = from bc in catagoryList where bc.id == smallCateId select bc.parentid.ToString();
            int myid = 0;
            if (bigCate.ToList<string>().Count > 0)
            {
                int.TryParse(bigCate.ToList<string>()[0], out myid);
            }

            return myid;
        }

        #endregion

        #region 添加单品时获取合单品信息列表

        private void copyproduct(HttpContext c)
        {
            string productNo = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["productNo"]))
            {
                productNo = c.Server.UrlDecode(c.Request["productNo"].Trim());
                string back = string.Empty;
                try
                {
                    List<EnProduct> modelList = ECProduct.GetProductList(string.Format(" createmid={0} and sku like '%{1}%'", CookiesHelper.GetCookie("mid"), productNo));
                    if (modelList != null && modelList.Count > 0)
                    {
                        foreach (var proItem in modelList)
                        {
                            back += "<tr><td><input name='mypId' type=\"radio\" value=\"" + proItem.id + "\" /></td>" +
                                "<td>" + proItem.title + "</td>" +
                                "<td>" + proItem.sku + "</td></tr>";
                        }
                    }
                    else
                    {
                        back = "no";
                    }


                }
                catch (Exception)
                {
                    back = "no";
                }

                c.Response.Write(back);
            }
        }
        #endregion

        #region 复制套组合
        private void copygroupproduct(HttpContext c)
        {
            string productNo = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["productNo"]))
                productNo = c.Server.UrlDecode(c.Request["productNo"].Trim());

            DataTable dt = ProductBll.GetgroupProductCountList(CookiesHelper.GetCookie("mname"), productNo);
            // List<GroupProductModel> producgrouptList = ProductBll.QueryGroupProductListDb(" No="+productNo, productNo, CookiesHelper.GetCookie("mname"), 0, 0, 0, -1, 1, out Counts);
            string back = string.Empty;
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow gpRow in dt.Rows)
                {
                    back += "<tr><td><input name='group' type=\"radio\" value=\"" + gpRow["gpid"] + "\" /></td>" +
                        "<td>" + gpRow["name"] + "</td>" +
                        "<td>" + gpRow["no"] + "</td><td>" + gpRow["shopname"] + "</td></tr>";
                }
            }

            c.Response.Write(back);
        }
        #endregion

        #region 编辑是加载套组合信息

        /// <summary>
        /// 编辑是加载套组合信息
        /// </summary>
        /// <param name="context"></param>
        private void editgroupproduct(HttpContext c)
        {
            //查询条件
            string Where = " 1=1 ";
            string productNo = string.Empty;//产品编号
            #region 查询条件
            int myId = 0;
            int currentPage = 1;
            if (!string.IsNullOrEmpty(c.Request["Page"]))
            {
                int.TryParse(c.Request["Page"].Trim(), out currentPage);
                if (currentPage <= 0)
                    currentPage = 1;
            }
            #endregion
            string myChecked = string.Empty;
            //11.所属套组合
            if (!string.IsNullOrEmpty(c.Request["gpId"]))
            {
                int.TryParse(c.Request["gpId"].Trim(), out myId);
                if (0 < myId)
                {
                    myChecked = " checked";
                    Where += " AND id IN (SELECT ppId FROM GroupProductProperty WHERE gpId = " + myId + " ) ";
                }
            }
            #region 读取绑定数据

            //总记录数
            int Counts = 0;
            //每页显示记录数
            int pagequantity = 5;
            List<EnProduct> productList = ECProduct.GetProductList(currentPage, pagequantity, Where, out Counts);
            string back = "";
            if (productList != null)
            {
                //总页数
                int PageCount = 0;
                //计算总页数
                if (Counts % pagequantity != 0)
                    PageCount = (Counts - Counts % pagequantity) / pagequantity + 1;
                else
                    PageCount = Counts / pagequantity;
                foreach (EnProduct model in productList)
                {
                    back += "<tr><td><input type=\"checkbox\" value=\"" + model.id + "\" /></td>" +
                        "<td>" + model.sku + "</td>" + "<td>" + model.categorytitle + "</td><td><a>" +
"<img width=\"100\" height=\"60\" src=\"" + TREC.Entity.EnFilePath.GetProductThumbPath("" + model.id.ToString() + "", model.thumb != null ? model.thumb : "" + "", "upload") + "\"></a></td>" + "<td>" + model.title + "</td><td>" + getProductSize(model.id) + "</td>" +
                       "<td>" + GetStatusStr(model.auditstatus) + "</td><td>" + GetLine(model.linestatus) + "</td></tr>";
                }
                back += "$" + PageCount;
                productList.Clear();
                productList = null;
            #endregion

            }
            c.Response.Write(back);
        }
        #endregion

        #region 发布套组合时查询单品

        /// <summary>
        /// 发布套组合时查询单品
        /// </summary>
        /// <param name="c"></param>
        /// <param name="userName"></param>
        private void SearchGroupProductDb(HttpContext c)
        {
            //查询条件
            string Where = " 1=1 ";
            string productNo = string.Empty;//产品编号
            #region 查询条件

            //1.产品编号
            if (!string.IsNullOrEmpty(c.Request["productNo"]))
                productNo = c.Request["productNo"].Trim();
            int myId = 0;
            ////2.大类
            //if (!string.IsNullOrEmpty(c.Request["bigCateId"]))
            //{
            //    int.TryParse(c.Request["bigCateId"].Trim(), out myId);
            //    if (0 < myId)
            //        Where += " AND categoryid= " + myId;
            //}


            string myChecked = string.Empty;
            //11.所属套组合
            if (!string.IsNullOrEmpty(c.Request["gpId"]))
            {
                int.TryParse(c.Request["gpId"].Trim(), out myId);
                if (0 < myId)
                {
                    myChecked = " checked";
                    Where += " AND id IN (SELECT ppId FROM GroupProductProperty WHERE gpId = " + myId + " ) ";
                }
            }
            else
            {

                //3.品牌
                if (!string.IsNullOrEmpty(c.Request["brandId"]))
                {
                    int.TryParse(c.Request["brandId"].Trim(), out myId);
                    if (0 < myId)
                        Where += " AND brandid= " + myId;
                }
                ////4.小类
                if (!string.IsNullOrEmpty(c.Request["smallCateId"]))
                {
                    int.TryParse(c.Request["smallCateId"].Trim(), out myId);
                    if (0 < myId)
                        Where += " AND categoryid = " + myId;
                }
                //5.系列
                if (!string.IsNullOrEmpty(c.Request["SeriesId"]))
                {
                    int.TryParse(c.Request["SeriesId"].Trim(), out myId);
                    if (0 < myId)
                        Where += " AND brandsid= " + myId;
                }
                //6.色系
                if (!string.IsNullOrEmpty(c.Request["ColorId"]))
                {
                    int.TryParse(c.Request["ColorId"].Trim(), out myId);
                    if (0 < myId)
                        Where += " AND colorvalue = " + myId;
                }
                //7.是否组装
                if (!string.IsNullOrEmpty(c.Request["IsGroup"]))
                {
                    int.TryParse(c.Request["IsGroup"].Trim(), out myId);
                    if (myId != 1)
                        myId = 0;
                    Where += " AND assemble = " + myId;
                }
                //8.风格
                if (!string.IsNullOrEmpty(c.Request["styleId"]))
                {
                    int.TryParse(c.Request["styleId"].Trim(), out myId);
                    if (0 < myId)
                        Where += " AND stylevalue = " + myId;
                }
                //9.材质
                if (!string.IsNullOrEmpty(c.Request["MaterialId"]))
                {
                    int.TryParse(c.Request["MaterialId"].Trim(), out myId);
                    if (0 < myId)
                        Where += " AND materialvalue = " + myId;
                }
                //10.当前页
                int Page = 1;
                if (!string.IsNullOrEmpty(c.Request["Page"]))
                {
                    int.TryParse(c.Request["Page"].Trim(), out Page);
                    if (Page <= 0)
                        Page = 1;
                }
            }

            if (!string.IsNullOrEmpty(c.Request["productNo"]))
                productNo = c.Request["productNo"].Trim();
            if (!string.IsNullOrEmpty(productNo))
            {
                Where += " and (isnull(sku,'') like '%" + productNo + "%')";
                //strWhere += " and title like '%" + txtProductName.Text + "%'";
            }
            #endregion

            #region 查询条件

            #region 声明变量，获取登陆用户信息

            EnMember memberInfo = null;
            List<EnBrand> brandList = new List<EnBrand>();
            EnCompany companyInfo = null;
            EnDealer dealerInfo = null;
            string brandidlist = "";
            string dealerCreateBrandIdList = "";
            if (CookiesHelper.GetCookie("mid") != "" && CookiesHelper.GetCookie("mname") != "" && CookiesHelper.GetCookie("mpwd") != "")
            {
                memberInfo = ECMember.GetMemberInfo(" where id=" + CookiesHelper.GetCookie("mid") + " and password='" + CookiesHelper.GetCookie("mpwd") + "'");
            }
            #endregion

            #region 转换用户类型
            int id = 0;
            switch (memberInfo.type)
            {
                #region 品牌工厂

                case (int)EnumMemberType.工厂企业:
                    int.TryParse(memberInfo.parentid.ToString(), out id);
                    if (id == 0)
                    {
                        id = memberInfo.id;
                    }
                    companyInfo = ECCompany.GetCompanyInfo(" where mid=" + id);

                    Where += " and companyid=" + companyInfo.id;
                    break;
                #endregion

                #region 经销商

                case (int)EnumMemberType.经销商:
                    int.TryParse(memberInfo.parentid.ToString(), out id);
                    if (id == 0)
                    {
                        id = memberInfo.id;
                    }
                    dealerInfo = ECDealer.GetDealerInfo(" where mid=" + id);
                    if (dealerInfo == null)
                    {
                        HttpContext.Current.Response.Redirect(ECommon.WebUrl + "loginout.aspx");
                        return;
                    }
                    List<EnAppBrand> appList = ECAppBrand.GetAppBrandList(" dealerid=" + dealerInfo.id);
                    brandidlist = "";
                    foreach (EnAppBrand b in appList)
                    {
                        if (b.appmodule == (int)EnumAppBrandModule.经销商申请 && b.apptype == (int)EnumAppBrandType.申请新建品牌)
                        {
                            dealerCreateBrandIdList += b.brandid + ",";
                        }
                        brandidlist += b.brandid + ",";
                    }
                    brandidlist = brandidlist.Length > 0 && brandidlist.EndsWith(",") ? brandidlist.Substring(0, brandidlist.Length - 1) : brandidlist;
                    dealerCreateBrandIdList = dealerCreateBrandIdList.Length > 0 && dealerCreateBrandIdList.EndsWith(",") ? dealerCreateBrandIdList.Substring(0, dealerCreateBrandIdList.Length - 1) : dealerCreateBrandIdList;
                    if (brandidlist.Length > 0)
                    {
                        brandList = ECBrand.GetBrandList(" id in(" + brandidlist + ")");
                    }
                    else
                    {
                        brandList = null;
                        brandList = new List<EnBrand>();
                    }
                    brandidlist = string.IsNullOrEmpty(brandidlist) ? "0" : brandidlist;
                    if (brandidlist.Length > 0)
                    {
                        Where += " and brandid in (" + brandidlist + ") and brandid!=0";
                    }
                    break;
                #endregion
            }

            #endregion


            int currentPage = 1;
            if (!string.IsNullOrEmpty(c.Request["Page"]))
            {
                int.TryParse(c.Request["Page"].Trim(), out currentPage);
                if (currentPage <= 0)
                    currentPage = 1;
            }
            #endregion

            #region 读取绑定数据

            //大类条件
            if (!string.IsNullOrEmpty(c.Request["bigCateId"]))
            {
                int bigCateId = 0;
                int.TryParse(c.Request["bigCateId"].Trim(), out bigCateId);
                if (bigCateId > 0)
                {
                    //大类
                    List<EnProductCategory> catagoryList = ECProductCategory.GetProductCategoryListToDDL(string.Format(" where parentid ={0}", bigCateId));
                    string smallids = string.Empty;
                    foreach (var item in catagoryList)
                    {
                        smallids += item.id.ToString() + ",";
                    }
                    if (smallids != "")
                    {
                        //根据大类获取小类id
                        Where += " and categoryid in(" + smallids.TrimEnd(',') + ")";
                    }

                }
            }
            //品牌条件
            if (!string.IsNullOrEmpty(c.Request["brandId"]))
            {
                Where += " and brandid =" + c.Request["brandId"];
            }
            //总记录数
            int Counts = 0;
            //每页显示记录数
            int pagequantity = 6;
            List<EnProduct> productList = ECProduct.GetProductList(currentPage, pagequantity, Where, out Counts);
            string back = "";
            if (productList != null)
            {
                //总页数
                int PageCount = 0;
                //计算总页数
                if (Counts % pagequantity != 0)
                    PageCount = (Counts - Counts % pagequantity) / pagequantity + 1;
                else
                    PageCount = Counts / pagequantity;
                foreach (EnProduct model in productList)
                {
                    back += "<tr><td><input" + myChecked + " type=\"checkbox\" value=\"" + model.id + "\" /></td>" +
                        "<td>" + model.sku + "</td>" + "<td>" + model.categorytitle + "</td><td><a>" +
"<img width=\"100\" height=\"60\" src=\"" + TREC.Entity.EnFilePath.GetProductThumbPath("" + model.id.ToString() + "", model.thumb != null ? model.thumb : "" + "", "upload") + "\"></a></td>" + "<td>" + model.title + "</td><td>" + getProductSize(model.id) + "</td>" +
                       "<td>" + GetStatusStr(model.auditstatus) + "</td><td>" + GetLine(model.linestatus) + "</td></tr>";
                }
                back += "$" + PageCount;
                productList.Clear();
                productList = null;
            #endregion

                #region 暂时注释

                //if (0 < productList.Count)
                //{  model.id.ToString()  model.thumb!= null ? model.thumb : ''
                //    rptList.DataSource = productList;
                //    rptList.DataBind();
                //    int totalPage = 0;
                //    //计算总页数
                //    if (Counts % pagequantity != 0)
                //        totalPage = (Counts - Counts % pagequantity) / pagequantity + 1;
                //    else
                //        totalPage = Counts / pagequantity;
                //    pageStr = commonMemberPageSub(Counts, totalPage, pagequantity, currentPage, "issuegroupproduct.aspx?", 5, "个", "产品");
                //}
                #endregion

            }
            else
            {
                back = "no";
            }
            c.Response.Write(back);
            #region 暂时注释

            //List<ECProductAttribute> productList = ProductBll.queryProductListDb(Where, productNo, userName, 1, 1, 0, pagequantity, Page, out Counts);
            //if (productList != null)
            //{
            //    string back = "";
            //    if (0 < Counts)
            //    {
            //        //总页数
            //        int PageCount = 0;
            //        //计算总页数
            //        if (Counts % pagequantity != 0)
            //            PageCount = (Counts - Counts % pagequantity) / pagequantity + 1;
            //        else
            //            PageCount = Counts / pagequantity;
            //        foreach (ProductPropertyModel model in productList)
            //        {
            //            back += "<tr><td><input" + myChecked + " type=\"checkbox\" value=\"" + model.ppId + "\" /></td><td>" + model.productNo + "</td><td>" + model.smallCateName + "</td><td><a><img width=\"100\" height=\"60\" src=\"" + (model.picture == "" ? "../Images/noshop.jpg" : ("/files/product/" + model.picture)) + "\"></a></td><td>" + model.productName + "</td><td>" + model.Long + "*" + model.Width + "*" + model.Height + "</td><td>" + (model.Stock == -1 ? "长期供应" : model.Stock.ToString()) + "</td><td>" + GetProductStatus(model.Status.ToString()) + "</td></tr>";
            //        }
            //        back += "$" + PageCount;
            //        productList.Clear();
            //        productList = null;
            //    }
            //    else
            //        back = "no";

            //    c.Response.Write(back);
            //}
            //else
            //    c.Response.Write(null);
            #endregion

        }
        #endregion

        #region 获取产品尺寸

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

        #region 获取产品状态
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
        /// <summary>
        /// 获取产品上下线
        /// </summary>
        /// <returns></returns>
        public string GetLine(object obj)
        {
            string str = string.Empty;
            if (obj == null)
            {
                return str;
            }
            if (obj.ToString() == "0")
            {
                str = "下线";
            }
            else
            {
                str = "上线";
            }
            return str;
        }

        #endregion

        #region 复制套组合时返回json数据
        private void copyProductGroup(HttpContext c)
        {
            int myId = 0;
            //11.所属套组合
            if (!string.IsNullOrEmpty(c.Request["gpId"]))
            {
                int.TryParse(c.Request["gpId"].Trim(), out myId);
            }
            StringBuilder retuJson = new StringBuilder();
            if (myId > 0)
            {


                GroupProductModel gpmodel = new GroupProductModel();
                gpmodel = ProductBll.GetModel(myId);

                if (gpmodel != null)
                {
                    // back = gpmodel.Name;
                    retuJson.Append("{");
                    retuJson.Append("gpId:'" + gpmodel.gpId + "',");
                    retuJson.Append("gpNo:'" + gpmodel.No + "',");
                    retuJson.Append("gpName:'" + gpmodel.Name + "',");
                    retuJson.Append("gpBrandId:'" + gpmodel.brandId + "',");
                    retuJson.Append("gpBigCateId:'" + gpmodel.bigCateId + "',");
                    retuJson.Append("gpStyleId:'" + gpmodel.styleId + "',");
                    retuJson.Append("gpMaterialId:'" + gpmodel.MaterialId + "',");
                    retuJson.Append("gpBrandsId:'" + gpmodel.SeriesId + "',");
                    //retuJson.Append("gpsmallCateId:'" + gpmodel.bigCateId + "',");
                    retuJson.Append("gpIsGroup:'" + gpmodel.IsGroup + "',");
                    retuJson.Append("gpColorId:'" + gpmodel.ColorId + "',");
                    retuJson.Append("gpSingePids:'" + getGroupProductIDs(gpmodel.gpId) + "',");
                    retuJson.Append("gpPrice:'" + gpmodel.Price + "',");
                    retuJson.Append("gpThumb:'" + gpmodel.thumb + "',");
                    retuJson.Append("gpBannel:'" + gpmodel.bannel + "',");
                    // retuJson.Append("gpDescript:'" + ChangeString(gpmodel.Descript) + "',");
                    retuJson.Append("gpShopId:'" + gpmodel.ShopId + "'");
                    retuJson.Append("}");
                }
            }
            c.Response.Write(retuJson.ToString());
        }
        #region 处理字符串中包含的html代码
        /// <summary>
        /// 把含有html标签的元素进行转换
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string ChangeString(string str)
        {
            //str含有HTML标签的文本
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("\n", "<br>");
            str = str.Replace("&", "&amp;");
            return str;
        }
        #endregion

        #region 获取套组合单个单品id
        public string getGroupProductIDs(int gpid)
        {
            //获取单品id
            string singleproid = string.Empty;
            List<GroupProductProperty> listsinglepro = ProductBll.GetGroupProductPropertyByWhere(" gpId=" + gpid);
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
            return singleproid;
        }
        #endregion
        #endregion
        /// <summary>
        /// 处理品牌相关数据
        /// </summary>
        /// <param name="c">httpcontext对象</param>
        /// <param name="Action">操作类型</param>
        /// <param name="brandId">品牌id（存在多个）</param>
        private void handleBrandDb(HttpContext c, string Action, string brandId)
        {
            if (Action == "del")
            {
                //删除品牌操作
                bool isDelToRecycle = ECBrand.DeleteBrandToRecycle(brandId);
                if (isDelToRecycle)
                    c.Response.Write("sccuess");
                else
                    c.Response.Write("fail");
            }
            else
            {
                int type = -99;
                if (Action == "up")
                    type = 0;
                int handleRow = ECBrand.ModifyBrandlinestatusByID(brandId, type);
                if (handleRow > -1)
                    c.Response.Write("sccuess");
                else
                    c.Response.Write("fail");
            }
        }

        /// <summary>
        /// 操作回收站中品牌数据
        /// </summary>
        /// <param name="c">httpcontext对象</param>
        /// <param name="Action">操作类型（revertbrandrecycle表示还原；delbrandrecycle表示删除）</param>
        /// <param name="brandId">品牌id（存在多个）</param>
        private void handleRecycleBrandDb(HttpContext c, string Action, string brandId)
        {
            bool isHandleSuccess = false;
            if (Action == "delbrandrecycle")
                isHandleSuccess = ECBrand.delBrandRecycle(brandId);
            else if (Action == "revertbrandrecycle")
                isHandleSuccess = ECBrand.revertBrandRecycle(brandId);
            if (isHandleSuccess)
                c.Response.Write("success");
            else
                c.Response.Write("fail");
        }

        /// <summary>
        /// 判断品牌下面的系列是否重复
        /// </summary>
        /// <param name="SeriesId">系列id</param>
        /// <param name="SeriesName">系列名称</param>
        /// <param name="brandId">品牌id</param>
        private void checkBrandSeriesName(HttpContext c, int SeriesId, string SeriesName, int brandId)
        {
            bool isExists = ECBrand.checkBrandSeriesNameIsExists(SeriesId, SeriesName, brandId);
            if (isExists)
                c.Response.Write("yes");
            else
                c.Response.Write("no");
        }

        /// <summary>
        /// 保存色板数据
        /// </summary>
        /// <param name="c"></param>
        private void saveSwatchDb(HttpContext c)
        {
            string CreateId = CookiesHelper.GetCookie("mid");
            int bSeriesId = 0;
            int.TryParse(c.Request["SeriesId"].Trim(), out bSeriesId);
            string SwatchName = c.Request["SeriesName"].Trim();
            string CategroyId = c.Request["myCategroy"].Trim();
            if (string.IsNullOrEmpty(CategroyId))
                CategroyId = "0";
            string Picture = c.Request["hfthumb"].Trim();
            if (!string.IsNullOrEmpty(Picture))
                Picture = Picture.TrimEnd(',');
            string ColorSwatch = string.Empty;//色板
            bool isSave = ECBrand.saveColorSwatchDb(bSeriesId, SwatchName, CategroyId, Picture, CreateId, 0);
            if (isSave)
            {
                Dictionary<int, string> SwatchDic = ECBrand.GetSwatchName(CreateId, bSeriesId);
                if (0 < SwatchDic.Count())
                {
                    string SwatchId = string.Empty;
                    SwatchName = "";
                    foreach (KeyValuePair<int, string> kvp in SwatchDic)
                    {
                        ColorSwatch += "<input name=\"ColorSwatch\" type=\"checkbox\" value=\"" + kvp.Key + "\" />\r\n" + kvp.Value + "&nbsp;&nbsp;";
                        // SwatchName += kvp.Value + "、";
                        // SwatchId += kvp.Key + ",";
                    }

                    //SwatchName = SwatchName.TrimEnd('、');
                    //SwatchId = SwatchId.TrimEnd(',');

                    //  c.Response.Write(SwatchName + "<input type=\"checkbox\" id=\"mySwatchName\" value=\"" + SwatchId + "\">");
                    c.Response.Write(ColorSwatch);

                }
            }
            else
                c.Response.Write(null);
        }

        /// <summary>
        /// 将品牌系列删除至回收站中
        /// </summary>
        /// <param name="c"></param>
        private void deleteBrandSeriesToRecycle(HttpContext c, string memberId)
        {
            if (!string.IsNullOrEmpty(c.Request["seriesId"]))
            {
                string seriesId = c.Request["seriesId"].TrimEnd(',').Trim();
                bool isDo = ECBrand.deleteBrandSeriesToRecycle(seriesId, memberId);
                if (isDo)
                    c.Response.Write("success");
                else
                    c.Response.Write("fail");
            }
        }

        /// <summary>
        /// 操作品牌系列回收站中数据
        /// </summary>
        /// <param name="c"></param>
        /// <param name="recycleId">系列id</param>
        /// <param name="Action">操作类型</param>
        private void doBrandSeriesRecycle(HttpContext c, string recycleId, string Action, string memberId)
        {
            bool isDo = false;
            if (Action == "delbrandseriesrecycle")
                isDo = ECBrand.delBrandSeriesRecycleDb(recycleId);
            else if (Action == "revertbrandseriesrecycle")
                isDo = ECBrand.revertBrandSeriesRecycle(recycleId, memberId);
            if (isDo)
                c.Response.Write("success");
            else
                c.Response.Write("fail");
        }

        /// <summary>
        /// 加载店铺卖场信息
        /// </summary>
        /// <param name="c"></param>
        private void queryShopMarketDb(HttpContext c)
        {
            string marketList = string.Empty;
            string pcode = c.Request["pcode"].Trim();
            string ccode = c.Request["ccode"].Trim();
            string dcode = c.Request["dcode"].Trim();
            if (!string.IsNullOrEmpty(pcode) || !string.IsNullOrEmpty(ccode) || !string.IsNullOrEmpty(dcode))
            {
                List<EnMarket> mList = ECBrand.queryShopMarketDb(pcode, ccode, dcode);
                if (mList != null)
                {
                    if (0 < mList.Count())
                    {
                        foreach (var item in mList)
                        {
                            marketList += "<li class=\"\"><a onclick=\"loadAddress('" + item.address + "'," + item.id + ");\" title=\"" + item.title + "\" href=\"Javascript:void();\">" + item.title + "</a></li>";
                        }
                    }
                }
            }
            c.Response.Write(marketList);
        }

        /// <summary>
        /// 处理店铺数据
        /// </summary>
        /// <param name="c"></param>
        private void handleShopDb(HttpContext c)
        {
            string shopId = c.Request["shopId"].TrimEnd(',').Trim();
            string Type = c.Request["Type"].Trim();
            if (!string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(Type))
            {
                bool isHandle = ECShop.handleShopDb(shopId, Type);
                if (isHandle)
                    c.Response.Write("success");
                else
                    c.Response.Write("fail");
            }
        }

        /// <summary>
        /// 处理回收站店铺数据
        /// </summary>
        /// <param name="c"></param>
        private void handleShopRecycle(HttpContext c)
        {
            string shopId = c.Request["shopId"].TrimEnd(',').Trim();
            string Type = c.Request["Type"].Trim();
            if (!string.IsNullOrEmpty(shopId) && !string.IsNullOrEmpty(Type))
            {
                bool isHandle = ECShop.handleRecycleShopDb(shopId, Type);
                if (isHandle)
                    c.Response.Write("success");
                else
                    c.Response.Write("fail");
            }
        }

        /// <summary>
        /// 修改商务信息排序
        /// </summary>
        /// <param name="c">httpcontext对象</param>
        /// <param name="memberId">会员id</param>
        private void updateRecommendSort(HttpContext c, string memberId)
        {
            int infoId = 0;
            if (!string.IsNullOrEmpty(c.Request["infoId"]))
                int.TryParse(c.Request["infoId"].Trim(), out infoId);
            int Recommend = 0;
            if (!string.IsNullOrEmpty(c.Request["Recommend"]))
                int.TryParse(c.Request["Recommend"].Trim(), out Recommend);

            if (0 < infoId && -1 < Recommend)
            {
                bool isUpdate = ECPromotion.updatePromotionsSortDb(infoId, Recommend, memberId);
                if (isUpdate)
                    c.Response.Write("success");
                else
                    c.Response.Write("fail");
            }
        }

        /// <summary>
        /// 修改商务信息状态
        /// </summary>
        /// <param name="c">httpcontext对象</param>
        /// <param name="memberId">会员id</param>
        private void handlePromotionsInfoStatus(HttpContext c, string memberId)
        {
            string infoId = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["infoId"]))
                infoId = c.Request["infoId"].TrimEnd(',').Trim();
            string type = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["type"]))
                type = c.Request["type"].Trim();
            if (!string.IsNullOrEmpty(infoId) && !string.IsNullOrEmpty(type))
            {
                bool isHandle = ECPromotion.doPromotionsDb(type, infoId, memberId);
                if (isHandle)
                    c.Response.Write("success");
                else
                    c.Response.Write("exception");
            }
            else
                c.Response.Write("perror");
        }
        #region 获取颜色列表
        /// <summary>
        /// 保存产品属性颜色
        /// </summary>
        /// <param name="c">httpcontext对象</param>
        /// <param name="memberId">会员id</param>
        private void getProductAttributeColor(HttpContext c, string memberId)
        {
            //(ishide is null or ishide=0) 审核之后的条件
            List<EnConfig> listColor = ECConfig.GetConfigList("   module=103 and type=13");
            string colorList = string.Empty;
            if (listColor != null && listColor.Count > 0)
            {
                foreach (var colorItem in listColor)
                {
                    colorList += "<option value=" + colorItem.id + ">" + colorItem.title + "</option>";
                }

            }
            c.Response.Write(colorList);
        }

        #endregion
        /// <summary>
        /// 保存产品属性颜色
        /// </summary>
        /// <param name="c">httpcontext对象</param>
        /// <param name="memberId">会员id</param>
        private void saveProductAttributeColor(HttpContext c, string memberId)
        {
            //颜色名称
            string ppTypeName = c.Server.UrlDecode(c.Request["ppTypeName"].Trim());
            //说明
            string ppTypeInfo = c.Request["ppTypeInfo"].Trim();
            if (!string.IsNullOrEmpty(ppTypeInfo))
                ppTypeInfo = c.Server.UrlDecode(ppTypeInfo);
            if (string.IsNullOrEmpty(ppTypeName))
                c.Response.Write("perror");
            else
            {
                bool isSave = ECProduct.SaveProductAttributeColorDb(ppTypeName, ppTypeInfo, memberId);
                if (isSave)
                    c.Response.Write("success");
                else
                    c.Response.Write("fail");
            }
        }

        /// <summary>
        /// 保存产品类型
        /// </summary>
        /// <param name="c"></param>
        /// <param name="memberId"></param>
        private void saveProductAttributeType(HttpContext c, string memberId)
        {
            //颜色名称
            string ppTypeName = c.Server.UrlDecode(c.Request["ppTypeName"].Trim());
            //说明
            string ppTypeInfo = c.Request["ppTypeInfo"].Trim();
            if (!string.IsNullOrEmpty(ppTypeInfo))
                ppTypeInfo = c.Server.UrlDecode(ppTypeInfo);
            if (string.IsNullOrEmpty(ppTypeName))
                c.Response.Write("perror");
            else
            {
                bool isSave = ECProduct.SaveProductAttributeTypeDb(ppTypeName, ppTypeInfo, memberId);
                if (isSave)
                    c.Response.Write("success");
                else
                    c.Response.Write("fail");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void Searchmarketbyid(HttpContext c)
        {
            //查询条件
            string Where = string.Format(" id in ({0}) ", c.Request["IdList"].Trim());

            int currentPage = 1;

            #region 读取绑定数据

            //总记录数
            int Counts = 0;
            //每页显示记录数
            int pagequantity = 100;
            List<EnMarket> marketList = ECMarket.GetMarketList(currentPage, pagequantity, Where, out Counts);
            string back = "";
            if (marketList != null)
            {
                //总页数
                int PageCount = 0;
                //计算总页数
                if (Counts % pagequantity != 0)
                    PageCount = (Counts - Counts % pagequantity) / pagequantity + 1;
                else
                    PageCount = Counts / pagequantity;
                foreach (EnMarket model in marketList)
                {
                    back += "<label class=\"marketlist\"><input type=\"checkbox\" value=\"" + model.id + "\" />" + model.title + " <b>(" +
                    ((EnumAuditStatus)System.Enum.Parse(typeof(EnumAuditStatus), model.auditstatus.ToString())).ToString() + ")</b></label>";
                }
                marketList.Clear();
                marketList = null;
            #endregion

            }
            else
            {
                back = "no";
            }
            c.Response.Write(back);
        }


        public void Searchmarketbykey(HttpContext c)
        {
            //查询条件
            string Where = string.Format(" title like  '%{0}%' ", c.Request["marketName"].Trim());

            int currentPage = 1;

            #region 读取绑定数据

            //总记录数
            int Counts = 0;
            //每页显示记录数
            int pagequantity = 40;
            List<EnMarket> marketList = ECMarket.GetMarketList(currentPage, pagequantity, Where, out Counts);
            string back = "";
            if (marketList != null)
            {
                //总页数
                int PageCount = 0;
                //计算总页数
                if (Counts % pagequantity != 0)
                    PageCount = (Counts - Counts % pagequantity) / pagequantity + 1;
                else
                    PageCount = Counts / pagequantity;
                foreach (EnMarket model in marketList)
                {
                    back += "<label class=\"marketlist\"><input type=\"checkbox\" value=\"" + model.id + "\" />" + model.title + " <b>(" +
                    ((EnumAuditStatus)System.Enum.Parse(typeof(EnumAuditStatus), model.auditstatus.ToString())).ToString() + ")</b></label>";
                }
                marketList.Clear();
                marketList = null;
            #endregion

            }
            else
            {
                back = "no";
            }
            c.Response.Write(back);
        }
    }
}