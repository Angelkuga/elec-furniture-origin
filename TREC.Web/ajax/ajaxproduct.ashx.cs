using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Data;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using Haojibiz;


namespace TREC.Web.ajax
{
    /// <summary>
    /// ajaxproduct 的摘要说明
    /// </summary>
    public class ajaxproduct : IHttpHandler
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = "";
            string value = "";
            string value2 = "";
            string value3 = "";
            string t = "";
            string c = "";

            if (context.Request["type"] != null)
            {
                type = context.Request["type"];
            }
            else
            {
                type = context.Request.Params["type"];
            }

            if (context.Request.QueryString["v"] != null)
            {
                value = context.Request.QueryString["v"];
            }
            else
            {
                value = context.Request.Params["v"];
            }

            if (context.Request.QueryString["v2"] != null)
            {
                value2 = context.Request.QueryString["v2"];
            }
            else
            {
                value2 = context.Request.Params["v2"];
            }
            if (context.Request.QueryString["v3"] != null)
            {
                value3 = context.Request.QueryString["v3"];
            }
            else
            {
                value3 = context.Request.Params["v3"];
            }

            if (context.Request.QueryString["t"] != null)
            {
                t = context.Request.QueryString["t"];
            }
            else
            {
                t = context.Request.Params["t"];
            }
            if (context.Request.QueryString["c"] != null)
            {
                c = context.Request.QueryString["c"];
            }
            else
            {
                c = context.Request.Params["c"];
            }


            switch (type.Trim())
            {
                case "getcategorytype":
                    context.Response.Write(GetCategoryType(value));
                    break;
                case "deleteproductattribute":
                    context.Response.Write(deleteproductattribute(value));
                    break;
                case "getcompanyproductsearchitem":
                    context.Response.Write(GetProductSearchItem(value, value2, value3, c, "company"));
                    break;
                case "dealerproductsearchitem"://经销商
                    context.Response.Write(GetProductSearchItem(value, value2, value3, c, "dealer"));
                    break;
                case "getshopproductsearchitem":
                    context.Response.Write(GetProductSearchItem(value, value2, value3, c, "shop"));
                    break;
                case "getproductprice":
                    context.Response.Write(GetPriceAttributePrice(value, value2, value3));
                    break;
                case "getmarketbyletter":
                    context.Response.Write(GetMarketByLetter(value));
                    break;
                case "getbrandbyletter":
                    
                    context.Response.Write(GetBrandByLetter(value));
                    break;
                case "savebrands": //保存系列
                    context.Response.Write(SaveBrands(context, value));
                    break;
                case "savethebrand": //保存品牌
                    context.Response.Write(SaveThebrand(context, value));
                    break;
                case "delgroupproduct":
                    context.Response.Write(delGroupProduct(context, value));
                    break;
                case "delmaketshop": //删除卖场店铺
                    context.Response.Write(delmaketshop(context, value));
                    break;
                case "checkmarketposition": //根据卖场楼层和编号，判断是否存在店铺
                    context.Response.Write(checkmarketposition(context, value, value2, value3));
                    break;
                case "searchbrand":
                    context.Response.Write(searchbrand(context, value));
                    break;
                case "dogp":
                    DoGroupProduct(context);
                    break;
                case "getcopyshopdb":
                    GetCopyShopDb(context);
                    break;
                case "savegroupcopyshop":
                    SaveGroupCopyShop(context);
                    break;
                case "dorecyclegp":
                    DoRecycleGp(context);
                    break;
                case "dorecyclepp":
                    DoRecyclePp(context);
                    break;
                case "delproduct":
                    delProduct(context);
                    break;
                case "saveproductcopyshop":
                    saveproductcopyshop(context);
                    break;
                case "updateupanddown":
                    updateupanddown(context);
                    break;
                case "setmarketstorey": //设置楼层数
                    setmarketstorey(context, value);
                    break;
                case "isAddproductRepeat":
                    isAddproductRepeat(context);
                    break;
                default:
                    context.Response.Write("ajax数据读取错误" + type);
                    break;

            }
            context.Response.End();
        }

        private void isAddproductRepeat( HttpContext context)
        {
            string createmid=context.Request["createmid"];
            string brandid=context.Request["brandid"];
            string sku = context.Request["sku"];
            string id = context.Request["id"];
            if (id!="0")
            {
                if (ECProduct.GetProductList(" createmid=" + createmid + " and brandid=" + brandid + " and sku='" + sku + "' and id!=" + ECommon.QueryId).ToList().Count == 0)
                {
                    context.Response.Write("true");
                }
                else
                {
                    context.Response.Write("false");
                }
            }
            else
            {
                if (ECProduct.GetProductList(" createmid=" + createmid + " and brandid=" + brandid + " and sku='" + sku + "'").ToList().Count == 0)
                {
                    context.Response.Write("true");
                }
                else
                {
                    context.Response.Write("false");
                }
            }
        }
        /// <summary>
        /// 保存ajax提交的添加品牌
        /// </summary>
        /// <param name="context"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string SaveThebrand(HttpContext context, string value)
        {
            EnBrand model = new EnBrand();
            int mid = 0;
            model.createmid = int.Parse(TRECommon.CookiesHelper.GetCookie("mid"));
            model.productcount = 0;
            model.attribute = "";
            model.keywords = "";
            model.template = "default";
            model.homepage = "";
            model.hits = 0;
            model.sort = 0;
            model.auditstatus = 0;
            model.linestatus = 0;
            int companyid = 0;
            int.TryParse(context.Request.QueryString["companyid"], out companyid);
            model.companyid = companyid;

            model.letter = "";
            model.productcategory = "";
            model.color = "";
            model.style = "";
            model.material = "";
            model.title = context.Request.QueryString["brandNames"];
            model.spread = context.Request.QueryString["brandSpread"];
            model.descript = context.Request.QueryString["brandInfo"];

            model.lastedittime = DateTime.Now;
            int aid = ECBrand.EditBrand(model);
            if (aid > 0)
            {
                return aid.ToString();
            }
            else
            {
                return "";
            }
        }
        #region 设置卖场楼层数

        private void setmarketstorey(HttpContext context, string vMarketStory)
        {
            EnMarketStorey model = new EnMarketStorey();
            EnMarket marketInfo = ECMarket.GetMarketInfo(" where mid=" + CookiesHelper.GetCookie("mid"));
            if (marketInfo != null)
            {
                //删除多余的楼层
                ECMarketStorey.DeleteMarketStorey(" where marketid=" + marketInfo.id);
                int droptitlecount = Convert.ToInt32(vMarketStory);
                ////判断：如果之前存在的卖场楼层则不添加，不存在的添加，如果重新设置的楼层数小于已经设置的楼层，则删除多余的楼层数：已经设置的楼层数—新设置的楼层数
                //List<EnMarketStorey> mslist = ECMarketStorey.GetMarketStoreyList(" marketid=" + marketInfo.id);
                //if (mslist != null && droptitlecount < mslist.Count)
                //{
                //    for (int i = droptitlecount; i <= mslist.Count; i++)
                //    {
                //        //删除多余的楼层
                //        ECMarketStorey.DeleteMarketStoreyByIdList(mslist[i].id.ToString());   
                //    }                    
                //}
                int aid = 0;
                for (int i = 1; i <= droptitlecount; i++)
                {
                    model = EnMarketStoreyModel(i, marketInfo.id, marketInfo.title);
                    aid = ECMarketStorey.EditMarketStorey(model);
                }
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
            }

        }

        #region 卖场楼层的Model

        /// <summary>
        /// 卖场楼层的Model
        /// </summary>
        /// <returns></returns>
        private EnMarketStorey EnMarketStoreyModel(int StoreyCount, int _marketid, string marketTitle)
        {
            EnMarketStorey model = new EnMarketStorey();
            int marketid = _marketid;
            string markettitle = marketTitle;
            string title = StoreyCount.ToString() + "楼";
            string number = "0";
            string surface = "";
            string logo = "";
            string thumb = "";
            string bannel = "";
            string desimage = "";
            string descript = "";
            string keywords = "";
            string template = "";
            int hits = 0;
            int sort = 0;
            int lastedid = int.Parse(CookiesHelper.GetCookie("mid"));
            DateTime lastedittime = DateTime.Now;

            model.marketid = marketid;
            model.markettitle = markettitle;
            model.title = title;
            model.number = number;
            model.surface = surface;
            model.logo = logo;
            model.thumb = thumb;
            model.bannel = bannel;
            model.desimage = desimage;
            model.descript = descript;
            model.keywords = keywords;
            model.template = template;
            model.hits = hits;
            model.sort = sort;
            model.lastedid = lastedid;
            model.lastedittime = lastedittime;

            return model;
        }
        #endregion

        #endregion

        //******
        private void updateupanddown(HttpContext c)
        {
            string pId = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["pId"]))
            {
                pId = c.Request["pId"].TrimEnd(',').Trim();
                if (!string.IsNullOrEmpty(pId))
                {
                    if (!string.IsNullOrEmpty(c.Request["pType"]))
                    {
                        string pType = c.Request["pType"].Trim();
                        int tp = -1;
                        if (pType == "up")
                        {
                            tp = 1;
                        }
                        if (pType == "down")
                        {
                            tp = 0;
                        }
                        if (tp != -1)
                        {
                            bool IsDo = ECProduct.ModifyProductlinestatusByID(pId, tp) > 0;
                            if (IsDo)
                                if(pType=="down")
                                {
                                    int p;
                                    List<EnProduct> productList = ECProduct.GetProductList(-1, 100, "  id in(" + pId + ")", out p);
                        string deltitle = string.Empty;
                      
                        foreach (EnProduct en in productList)
                        {
                             t_member _member=new t_member();
                        _member=EntityOper.t_member.Where(o=>o.id==en.createmid).FirstOrDefault();
                            string username=string.Empty;
                            string usertype=string.Empty;
                            string userid=string.Empty;

                            if(_member!=null)
                            {
                                username=_member.username;
                                usertype=_member.type.ToString();
                                userid=_member.ToString();
                            }
                           // deltitle = deltitle + "产品ID：" + en.id + ",产品名称：" + en.title;
                            deltitle = deltitle + "<p>商家: " + en.companyname + " 用户名：" + username + "</p><p>下线产品。</p><p>产品id:" + en.id + " 产品名称:" + en.title + "</p><p>商家id:" + userid + " 商家身份:" + usertype + "</p>";
                        }
                        string mailsubject = deltitle;

                        string[] mailto = TREC.ECommerce.ECommon.ServiceMail.Split(',');
                        foreach (string items in mailto)
                        {
                            bool rsmail = EmailHelper.SendEmail("家具快搜 商家产品下线通知提示", items, mailsubject);
                        }
                                }
                             c.Response.Write("success");
                        }
                               
                            else
                                c.Response.Write("fail");
                        }


                    }
                }
            }
    


        #region 开始复制单品到其他店铺信息
        /// <summary>
        /// 将套组合产品复制到店铺
        /// </summary>
        /// <param name="c"></param>
        private void saveproductcopyshop(HttpContext c)
        {
            //产品id
            string productId = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["productId"]))
                productId = c.Request["productId"].Trim();

            //店铺id
            string shopId = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["shopId"]))
                shopId = c.Request["shopId"].Trim();

            if (!string.IsNullOrEmpty(productId) && !string.IsNullOrEmpty(shopId))
            {
                productId = productId.TrimEnd(',').Trim();
                shopId = shopId.TrimEnd(',').Trim();
                string[] shopids = shopId.Split(',');
                int myId = 0;
                for (int i = 0; i < shopids.Length; i++)
                {
                    List<EnProduct> modelList = ECProduct.GetProductList(string.Format(" id in({0})", productId));
                    foreach (EnProduct item in modelList)
                    {
                        if (ECProduct.GetProductList(" companyid=" + item.companyid + " AND shopid=" + shopids[i] + " and brandid=" + item.brandid+" and sku='"+item.sku+"'").ToList().Count == 0)
                        {
                            #region 复制图片和属性
                            int oldId = item.id;
                            EnProduct proModel = new EnProduct();
                            proModel = item;
                            int.TryParse(shopids[i], out myId);
                            proModel.id = 0;
                            proModel.shopid = myId;
                            int aid = ECProduct.EditProduct(proModel);
                            if (aid > 0)
                            {
                                #region 复制图片

                                //复制图片
                                string oldFilePath = string.Empty;
                                string newFilePath = string.Empty;
                                string newFilePath2 = string.Empty;
                                oldFilePath = c.Server.MapPath("~/upload/product/thumb/" + oldId + "/" + item.thumb);
                                //  string newAtri = hfproductattribute.Value;
                                if (oldFilePath.Substring(oldFilePath.Length - 1, 1) == ",")
                                {
                                    oldFilePath = oldFilePath.Substring(0, oldFilePath.Length - 1);
                                }

                                if (oldFilePath != "" && File.Exists(oldFilePath))
                                {
                                    var str1 = oldFilePath.Substring(0, oldFilePath.IndexOf("thumb") + 6);
                                    var str2 = oldFilePath.Substring(str1.Length, oldFilePath.Length - str1.Length);
                                    newFilePath = str1 + aid + "\\" + str2.Substring(str2.LastIndexOf("\\"), str2.Length - str2.LastIndexOf("\\"));
                                    newFilePath2 = str1 + aid + "\\";
                                    try
                                    {
                                        if (!Directory.Exists(newFilePath2))
                                        {
                                            Directory.CreateDirectory(newFilePath2);
                                        }

                                        DirectoryInfo dinfo = new DirectoryInfo(c.Server.MapPath("~/upload/product/thumb/" + oldId + "/"));//注，这里面传的是路径，并不是文件，所以不能保含带后缀的文件
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
                                #endregion

                                #region 复制产品属性
                                //复制产品属性
                                List<EnProductAttribute> listproductattribute = ECProductAttribute.GetProductAttributeList(" productid='" + oldId + "'");
                                foreach (EnProductAttribute patrrModel in listproductattribute)
                                {
                                    EnProductAttribute attrModel = new EnProductAttribute();
                                    attrModel = patrrModel;
                                    attrModel.id = 0;
                                    attrModel.productid = aid;
                                    ECProductAttribute.EditProductAttribute(attrModel);
                                }
                                #endregion

                                c.Response.Write("ok");
                            }
                            else
                            {
                                c.Response.Write(null);
                            }
                        }
                        #endregion
                    }
                }
                // int quantity = 0;
                //bool IsCopy =ProductBll.SaveCopyProductToShopDb(productId, shopId, out quantity);
                //if (IsCopy)
                //    c.Response.Write(quantity);
                //else
                //    c.Response.Write(null);
            }
            else
                c.Response.Write(null);
        }
        #endregion

        #region 删除单品
        private void delProduct(HttpContext c)
        {
            string pId = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["pId"]))
            {
                pId = c.Request["pId"].TrimEnd(',').Trim();
                if (!string.IsNullOrEmpty(pId))
                {
                    int p = 0;
                    List<EnProduct> productList = ECProduct.GetProductList(-1, 100, "  id in(" + pId + ")", out p);
                    string deltitle = string.Empty;

                    foreach (EnProduct en in productList)
                    {
                        t_member _member = new t_member();
                        _member = EntityOper.t_member.Where(o => o.id == en.createmid).FirstOrDefault();
                        string username = string.Empty;
                        string usertype = string.Empty;
                        string userid = string.Empty;

                        if (_member != null)
                        {
                            username = _member.username;
                            usertype = _member.type.ToString();
                            userid = _member.id.ToString();
                        }
                        // deltitle = deltitle + "产品ID：" + en.id + ",产品名称：" + en.title;
                        deltitle = deltitle + "<p>商家: " + en.companyname + " 用户名：" + username + "</p><p>产品删除。</p><p>产品id:" + en.id + " 产品名称:" + en.title + "</p><p>商家id:" + userid + " 商家身份:" + usertype + "</p>";
                    }
                    string mailsubject = deltitle;

                    string[] mailto = TREC.ECommerce.ECommon.ServiceMail.Split(',');
                    foreach (string items in mailto)
                    {
                        bool rsmail = EmailHelper.SendEmail("家具快搜 商家产品删除通知提示", items, mailsubject);
                    }

                    if (ECProduct.deleteProduct(pId))
                    {
                       

                        c.Response.Write("success");
                    }
                    else
                    {
                        c.Response.Write("fail");
                    }

                }
            }
        }
        #endregion

        #region 还原（删除）回收站中产品
        /// <summary>
        /// 还原（删除）回收站中产品
        /// </summary>
        /// <param name="c"></param>
        private void DoRecyclePp(HttpContext c)
        {
            string pId = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["pId"]))
            {
                pId = c.Request["pId"].TrimEnd(',').Trim();
                if (!string.IsNullOrEmpty(pId))
                {
                    if (!string.IsNullOrEmpty(c.Request["pType"]))
                    {
                        string pType = c.Request["pType"].Trim();
                        if (pType == "revertproductrecycle" || pType == "deleteproductrecycle")
                        {
                            if (pType == "revertproductrecycle")
                                pType = "revert";
                            else
                                pType = "delete";
                            bool IsDo = ECProduct.DoRecycleProduct(pId, pType);
                            if (IsDo)
                                c.Response.Write("success");
                            else
                                c.Response.Write("fail");
                        }
                    }
                }
            }
        }
        #endregion

        #region 开始复制套组合产品到其他店铺信息
        /// <summary>
        /// 将套组合产品复制到店铺
        /// </summary>
        /// <param name="c"></param>
        private void SaveGroupCopyShop(HttpContext c)
        {
            //产品id
            string productId = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["productId"]))
                productId = c.Request["productId"].Trim();

            //店铺id
            string shopId = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["shopId"]))
                shopId = c.Request["shopId"].Trim();

            if (!string.IsNullOrEmpty(productId) && !string.IsNullOrEmpty(shopId))
            {
                productId = productId.TrimEnd(',').Trim();
                shopId = shopId.TrimEnd(',').Trim();
                string[] shopids = shopId.Split(',');
                int myId = 0;
                for (int i = 0; i < shopids.Length; i++)
                {
                    List<GroupProductModel> modelList = ProductBll.QueryGroupProductListByWhere(string.Format(" userName='{0}' and gpId in({1})", TRECommon.CookiesHelper.GetCookie("mname"), productId));
                    foreach (GroupProductModel item in modelList)
                    {
                        int oldId = item.gpId;
                        GroupProductModel gpModel = item;
                        gpModel.gpId = 0;
                        int.TryParse(shopids[i], out myId);
                        gpModel.ShopId = myId;
                        int aid = ProductBll.SaveIssueGroupProductDb(gpModel, getGroupProductIds(oldId), myId.ToString());
                        if (aid > 0)
                        {
                            #region 复制图片

                            //复制图片
                            string oldFilePath = string.Empty;
                            string newFilePath = string.Empty;
                            string newFilePath2 = string.Empty;
                            oldFilePath = c.Server.MapPath("~/upload/product/thumb/" + oldId + "/" + item.thumb);
                            //  string newAtri = hfproductattribute.Value;
                            if (oldFilePath.Substring(oldFilePath.Length - 1, 1) == ",")
                            {
                                oldFilePath = oldFilePath.Substring(0, oldFilePath.Length - 1);
                            }

                            if (oldFilePath != "" && File.Exists(oldFilePath))
                            {
                                var str1 = oldFilePath.Substring(0, oldFilePath.IndexOf("thumb") + 6);
                                var str2 = oldFilePath.Substring(str1.Length, oldFilePath.Length - str1.Length);
                                newFilePath = str1 + aid + "\\" + str2.Substring(str2.LastIndexOf("\\"), str2.Length - str2.LastIndexOf("\\"));
                                newFilePath2 = str1 + aid + "\\";
                                try
                                {
                                    if (!Directory.Exists(newFilePath2))
                                    {
                                        Directory.CreateDirectory(newFilePath2);
                                    }

                                    DirectoryInfo dinfo = new DirectoryInfo(c.Server.MapPath("~/upload/product/thumb/" + oldId + "/"));//注，这里面传的是路径，并不是文件，所以不能保含带后缀的文件
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
                            #endregion
                            c.Response.Write("ok");
                        }
                        else
                        {
                            c.Response.Write(null);
                        }
                    }
                }
            }
            else
                c.Response.Write(null);
        }
        #endregion

        #region 获取套组合包含的单个产品id
        public string getGroupProductIds(int gpid)
        {
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

        #region 还原（删除）回收站中套组合产品
        /// <summary>
        /// 还原（删除）回收站中套组合产品
        /// </summary>
        /// <param name="c"></param>
        private void DoRecycleGp(HttpContext c)
        {
            string ppId = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["ppId"]))
            {
                ppId = c.Request["ppId"].TrimEnd(',').Trim();
                if (!string.IsNullOrEmpty(ppId))
                {
                    if (!string.IsNullOrEmpty(c.Request["pType"]))
                    {
                        string pType = c.Request["pType"].Trim();
                        if (pType == "revertgroupproductrecycle" || pType == "deletegroupproductrecycle")
                        {
                            if (pType == "revertgroupproductrecycle")
                                pType = "revert";
                            else
                                pType = "delete";
                            bool IsDo = ProductBll.DoRecycleGroupProduct(ppId, pType);
                            if (IsDo)
                                c.Response.Write("success");
                            else
                                c.Response.Write("fail");
                        }
                    }
                }
            }
        }

        #endregion

        #region 复制产品到其他店铺似时加载店铺信息
        /// <summary>
        /// 获得将产品复制店铺的店铺数据
        /// </summary>
        /// <param name="c"></param>
        /// <param name="userName">会员名</param>
        private void GetCopyShopDb(HttpContext c)
        {
            int shopRecord = 0;
            List<EnShop> shopList = ECShop.GetShopList(" createmid = " + TRECommon.CookiesHelper.GetCookie("mid"), out shopRecord);
            if (shopList != null)
            {
                if (0 < shopList.Count)
                {
                    string myShop = "";
                    foreach (var item in shopList)
                        myShop += "<li><input type=\"checkbox\" name=\"shopId\" value=\"" + item.id + "\" />" + item.title + "</li>";
                    c.Response.Write(myShop);
                }
                else
                    c.Response.Write("");
            }
            else
                c.Response.Write(null);
        }
        #endregion

        #region 产品上下线
        /// <summary>
        /// 上线（下线、删除）套组合产品
        /// </summary>
        /// <param name="c"></param>
        private void DoGroupProduct(HttpContext c)
        {
            string ppId = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["ppId"]))
                ppId = c.Request["ppId"].TrimEnd(',').Trim();
            string pType = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["pType"]))
                pType = c.Request["pType"].Trim();
            if (!string.IsNullOrEmpty(ppId) && !string.IsNullOrEmpty(pType))
            {
                if (pType == "up" || pType == "down" || pType == "delete")
                {
                    if (pType == "down")
                    {
                        int p = 0;
                        List<EnProduct> productList = ECProduct.GetProductList(-1, 100, "  id in(" + ppId + ")", out p);
                        string deltitle = string.Empty;

                        foreach (EnProduct en in productList)
                        {
                            deltitle = deltitle + "产品ID：" + en.id + ",产品名称：" + en.title;
                        }
                        string mailsubject = @"<p>下线产品：" + deltitle + "</p>";
                        string[] mailto = TREC.ECommerce.ECommon.ServiceMail.Split(',');
                        foreach (string items in mailto)
                        {
                            bool rsmail = EmailHelper.SendEmail("家具快搜 商家产品下线通知提示", items, mailsubject);
                        }

                    }

                    bool IsDo = ProductBll.DoGroupProduct(ppId, pType);
                    if (IsDo)
                    {
                        
                        c.Response.Write("success");
                    }
                    else
                    {
                        c.Response.Write("fail");
                    }
                }
            }
        }
        #endregion

        #region 搜索品牌

        private string searchbrand(HttpContext c, string v)
        {
            string strWhere = " 1=1";
            if (v != "")
            {
                strWhere += "  and  (title like '%" + v + "%') ";
            }
            List<EnBrand> brandList = ECBrand.GetBrandList(strWhere);
            StringBuilder strHtml = new StringBuilder();
            foreach (var item in brandList)
            {
                strHtml.Append("<li>" + item.title + "</li>");
            }
            return strHtml.ToString();
        }
        #endregion


        #region 根据卖场楼层和编号，判断是否存在店铺
        public string checkmarketposition(HttpContext c, string v, string v2, string v3)
        {
            try
            {
                if (ECMarketStoreyShop.GetMarketStoreyShopInfo(string.Format(" where marketid={0} and storeyid={1} and position='{2}'", v3, v, v2)) != null)
                {
                    return "ok"; //已经存在
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "ok";

            }


        }
        #endregion

        #region 删除楼层店铺

        private string delmaketshop(HttpContext context, string value)
        {
            try
            {
                if (ECMarketStoreyShop.DeleteMarketStoreyShopByShopIdList(value) > 0)
                {
                    return "ok";
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception)
            {

                return "error";
            }


        }
        #endregion

        /// <summary>
        /// 删除组合产品
        /// </summary>
        private string delGroupProduct(HttpContext c, string value)
        {

            string ppId = string.Empty;
            if (!string.IsNullOrEmpty(value))
                ppId = value;
            string Type = "delete";

            if (!string.IsNullOrEmpty(ppId) && !string.IsNullOrEmpty(Type))
            {
                if (Type == "up" || Type == "down" || Type == "delete")
                {
                    bool IsDo = ProductBll.DoGroupProduct(ppId, Type);
                    if (IsDo)
                        return "success";// c.Response.Write("success");
                    else
                        return "fail";
                }
            }
            return "";

        }
        #region 保存系列

        /// <summary>
        /// 保存系列
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string SaveBrands(HttpContext content, string value)
        {
            EnBrands model = new EnBrands();
            int mid = 0;
            model.createmid = int.Parse(TRECommon.CookiesHelper.GetCookie("mid"));
            model.productcount = 0;
            model.style = "";
            model.color = "";
            model.spread = "";
            model.material = "";
            model.attribute = "";
            model.surface = "";
            model.logo = "";
            model.thumb = "";
            model.bannel = "";
            model.desimage = "";
            model.keywords = "";
            model.template = "";
            model.hits = 0;
            model.auditstatus = 0;
            model.linestatus = 0;
            model.letter = "";
            int.TryParse(content.Request.QueryString["brandid"], out mid);
            model.brandid = mid;
            model.title = content.Request.QueryString["brandsName"];
            model.descript = "";
            model.sort = 0;
            model.lastedittime = DateTime.Now;
            model.style = content.Request.QueryString["StyleSelect"];
            model.material = content.Request.QueryString["material"];
            model.color = content.Request.QueryString["ColorStyleSelect"];
            int aid = ECBrand.EditBrands(model);
            if (aid > 0)
            {
                return aid.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        public string GetPriceAttributePrice(string id, string m, string s)
        {
            EnProductAttribute p = ECProductAttribute.GetProductAttributeInfo(" where productid=" + id + " and replace(productmaterial,'+','')='" + m.Replace(" ", "") + "' and convert(varchar(10),productwidth)+'*'+convert(varchar(10),productlength)+'*'+convert(varchar(10),productheight)='" + s + "'");
            if (p == null)
                return "0";
            return p.markprice.ToString();
        }


        public string deleteproductattribute(string id)
        {
            return !string.IsNullOrEmpty(id) ? ECProductAttribute.DeleteProductAttribute(TypeConverter.StrToInt(id)).ToString() : "0";
        }

        public string GetCategoryType(string categoryid)
        {
            string producttypelist = ECPCategoryPTyp.GetProductCategoryTypeValueList(TypeConverter.StrToInt(categoryid));
            List<EnConfig> list = new List<EnConfig>();
            if (producttypelist.Length > 0)
            {
                list = ECConfig.GetConfigList(" type=" + (int)EnumConfigByProduct.产品类型 + " and value in(" + producttypelist + ")");
            }
            StringBuilder sb = new StringBuilder();
            foreach (EnConfig c in list)
            {
                sb.Append("{\"id\":\"" + c.value + "\",\"title\":\"" + c.title + "\"},");
            }
            if (sb.Length > 0)
            {
                return sb.ToString().Length > 0 && sb.ToString().EndsWith(",") ? "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]" : "[" + sb.ToString() + "]";
            }
            return sb.ToString();
        }

        public string GetProductSearchItem(string v1, string v2, string v3, string c, string type)
        {
            List<EnSearchProductItem> list = new List<EnSearchProductItem>();
            if (type == "company")
            {
                list = ECProduct.GetProductSearchItemByCompanyIdNew(TypeConverter.StrToInt(c), v1, v2);
            }
            if (type == "shop")
            {
                list = ECProduct.GetProductSearchItemByShopIdNew(TypeConverter.StrToInt(c), v1, v2);
            }
            if (type == "dealer")//经销商
            {
                list = ECProduct.GetProductSearchItemByCreatemIdNew(TypeConverter.StrToInt(c), v1, v2);
            }
            StringBuilder sb = new StringBuilder();
            if (list.Count == 0)
            {
                if (!string.IsNullOrEmpty(v1) && !string.IsNullOrEmpty(v2))
                {
                    list = ECProduct.GetProductSearchItemByCompanyIdNew(TypeConverter.StrToInt(c), v1, "");
                }
                if (list.Count == 0)
                {
                    return "{}";
                }
            }
            if (v1 == "" && v2 == "" && v3 == "")
            {
                foreach (EnSearchProductItem item in list)
                {
                    sb.Append("{\"type\":\"" + item.type + "\",\"v\":\"" + item.value + "\",\"n\":\"" + item.title + "\",\"count\":\"" + item.count + "\",\"b\":\"" + item.brandid + "\",\"bs\":\"" + item.brandsid + "\",\"pc\":\"" + item.pcategoryid + "\"},");
                }
            }
            else
            {
                List<EnSearchProductItem> tempList = list.Where(x => x.type == "category").ToList();
                if (v1 != "")
                {
                    tempList = list.Where(x => x.brandid == v1).ToList();
                }
                if (v2 != "")
                {
                    foreach (EnSearchProductItem item in list.Where(x => x.brandsid == v2).ToList())
                    {
                        tempList.Add(item);
                    }
                }
                if (v3 != "")
                {
                    tempList = list.Where(x => x.pcategoryid == v3).ToList();
                }
                else
                {
                    foreach (EnSearchProductItem item in list.Where(x => x.type == "category").ToList())
                    {
                        tempList.Add(item);
                    }
                }

                foreach (EnSearchProductItem item in tempList)
                {
                    sb.Append("{\"type\":\"" + item.type + "\",\"v\":\"" + item.value + "\",\"n\":\"" + item.title + "\",\"count\":\"" + item.count + "\",\"b\":\"" + item.brandid + "\",\"bs\":\"" + item.brandsid + "\",\"pc\":\"" + item.pcategoryid + "\"},");
                }
            }

            if (sb.Length > 0)
            {
                return sb.ToString().Length > 0 && sb.ToString().EndsWith(",") ? "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]" : "[" + sb.ToString() + "]";
            }
            return string.IsNullOrEmpty(sb.ToString()) ? "{}" : sb.ToString();
        }

        public string GetMarketByLetter(string myletter)
        {
            string Where = string.Empty;
            if (!string.IsNullOrEmpty(myletter))
            {
                foreach (string str in myletter.Split(','))
                {
                    if (str.Trim().Length == 1)
                    {
                        if (Where != "")
                            Where += " or ";
                        Where += " substring(letter,1,1) = '" + str.ToLower().Trim() + "' ";
                    }
                }

                if (!string.IsNullOrEmpty(Where))
                    Where = " (" + Where + ") ";
            }

            List<EnWebMarket> MarketList = ECMarket.GetMarketByLetter(Where).OrderBy(c => c.letter).ToList<EnWebMarket>();
            if (MarketList != null)
            {
                StringBuilder JsonString = new StringBuilder();
                if (0 < MarketList.Count)
                {
                    foreach (EnWebMarket model in MarketList)
                    {
                        //if (model.vip != 0)
                            JsonString.Append("<a target=\"_blank\" class=\"myred\" href=\"/market/" + model.id + "/index.aspx\">" + model.title + "</a>");
                        //else
                        //    JsonString.Append("<a target=\"_blank\" class=\"mygray\" href=\"/market/list.aspx\">" + model.title + "</a>");
                    }
                }
                MarketList.Clear();
                MarketList = null;
                return JsonString.ToString();
            }
            else
                return null;
        }

        public string GetBrandByLetter(string myletter)
        {
            string Where = string.Empty;
            if (!string.IsNullOrEmpty(myletter))
            {
                foreach (string str in myletter.Split(','))
                {
                    if (str.Trim().Length == 1)
                    {
                        if (Where != "")
                            Where += " or ";
                        Where += " substring(letter,1,1) = '" + str.ToLower().Trim() + "' ";
                    }
                }

                if (!string.IsNullOrEmpty(Where))
                    Where = " (" + Where + ") ";
            }

            List<EnBrand> BrandList = ECBrand.GetBrandByLetter(Where).OrderBy(c => c.letter).ToList<EnBrand>();
            List<string> _brlist = new List<string>();
            if (BrandList != null)
            {
                StringBuilder JsonString = new StringBuilder();
                if (0 < BrandList.Count)
                {
                    foreach (EnBrand model in BrandList)
                    {
                        if (!_brlist.Contains(model.title))
                        {
                            JsonString.Append("<a target=\"_blank\" href=\"/ShopBrand.aspx?bname=" + HttpContext.Current.Server.UrlEncode(model.title) + "\">" + model.title + "</a>");
                        }
                            _brlist.Add(model.title);
                    }
                    // JsonString.Append("<a target=\"_blank\" href=\"/company/" + model.id + "/index.aspx\">" + model.title + "</a>");
                }

                BrandList.Clear();
                BrandList = null;
                return JsonString.ToString();
            }
            else
                return null;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}