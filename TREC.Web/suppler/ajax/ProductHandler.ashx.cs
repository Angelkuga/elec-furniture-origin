using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TREC.ECommerce;
using Newtonsoft.Json;
using TREC.Entity;
using TRECommon;
using System.Web.SessionState;

namespace TREC.Web.Suppler.ajax
{
    /// <summary>
    /// ProductHandler 的摘要说明
    /// </summary>
    public class ProductHandler : IHttpHandler,IRequiresSessionState
    {
            public void ProcessRequest(HttpContext context)
            {
                context.Response.ContentType = "text/plain";
                string Action = string.Empty;
                string userName = CookiesHelper.GetCookie("mname");
                if (!string.IsNullOrEmpty(context.Request["Action"]) && !string.IsNullOrEmpty(userName))
                {
                    Action = context.Request["Action"].Trim();
                    switch (Action)
                    {
                        case "copyshop":
                            //GetCopyShopDb(context, userName);
                            break;
                        case "series":
                            // GetBrandSeriesDb(context);
                            break;
                        case "categroy":
                            // GetSmallCategroyDb(context);
                            break;
                        case "smallcate":
                            // SaveSmallCategroy(context, userName);
                            break;
                        case "swatchname":
                            //  SaveSwatchName(context, userName);
                            break;
                        case "color":
                            //  GetColorDb(context);
                            break;
                        case "savepp":
                            // SaveProductProperty(context, userName);
                            break;
                        case "getpp":
                            // GetProductProperty(context, userName);
                            break;
                        case "delpp":
                            //   DeleteProductProperty(context, userName);
                            break;
                        case "editorpp":
                            //  EditorProductProperty(context, userName);
                            break;
                        case "savecopyshop":
                            //   SaveCopyShopDb(context);
                            break;
                        case "dopp":
                            // DoProductProperty(context);
                            break;
                        case "geteditorproductdb":
                            //  GetEditorProductDb(context, userName);
                            break;
                        case "copyproduct":
                            // CopyProductByNo(context);
                            break;
                        case "copypptopp":
                            // CopyPpToPp(context, userName);
                            break;
                        case "getcopypp":
                            // GetCopyPp(context, userName);
                            break;
                        case "dorecyclepp":
                            // DoRecyclePp(context);
                            break;
                        case "searchgroupproduct":
                            SearchGroupProductDb(context, userName);
                            break;
                        case "dogp":
                            // DoGroupProduct(context);
                            break;
                        case "savegroupcopyshop":
                            // SaveGroupCopyShop(context);
                            break;
                        case "dorecyclegp":
                            // DoRecycleGp(context);
                            break;
                        case "editorgroupproduct":
                            // EditorGroupProduct(context);
                            break;
                        case "copygroupproduct":
                            // CopyGroupProductByNo(context);
                            break;
                        case "brandseries":
                            // BrandSeriesDb(context,userName);
                            break;
                        case "productshop":
                            //  ProductShopDb(context, userName);
                            break;
                        case "setprice":
                            // SetPriceDb(context, userName);
                            break;
                        case "savetype":
                            // SaveType(context,userName);
                            break;
                        case "savecolor":
                            // SaveColor(context, userName);
                            break;
                        case "gettype":
                            //  GetType(context);
                            break;
                        default:
                            break;
                    }
                }
            }

            ///// <summary>
            ///// 获得将产品复制店铺的店铺数据
            ///// </summary>
            ///// <param name="c"></param>
            ///// <param name="userName">会员名</param>
            //private void GetCopyShopDb(HttpContext c, string userName)
            //{
            //    Dictionary<int, string> ShopDict = ShopBll.QueryCopyProductToShopDb(userName);
            //    if (ShopDict != null)
            //    {
            //        if (0 < ShopDict.Count)
            //        {
            //            string myShop = "";
            //            foreach (KeyValuePair<int, string> kvp in ShopDict)
            //                myShop += "<li><input type=\"checkbox\" name=\"shopId\" value=\"" + kvp.Key + "\" />" + kvp.Value + "</li>";
            //            c.Response.Write(myShop);
            //        }
            //        else
            //            c.Response.Write("");
            //    }
            //    else
            //        c.Response.Write(null);
            //}

            ///// <summary>
            ///// 获得品牌下面的系列数据
            ///// </summary>
            ///// <param name="c"></param>
            //private void GetBrandSeriesDb(HttpContext c)
            //{
            //    int brandId=0;
            //    if (!string.IsNullOrEmpty(c.Request["brandId"]))
            //        int.TryParse(c.Request["brandId"].Trim(), out brandId);
            //    Dictionary<int, string> DictSeries = BrandBll.QueryBrandBelongSeriesDb(brandId);
            //    if (DictSeries != null)
            //    {
            //        string mySeries = "";
            //        foreach (KeyValuePair<int, string> kvp in DictSeries)
            //            mySeries += "<option value=\""+kvp.Key+"\">"+kvp.Value+"</option>";
            //        DictSeries.Clear();
            //        DictSeries = null;
            //        c.Response.Write(mySeries);
            //    }
            //    else
            //        c.Response.Write(null);
            //}

            ///// <summary>
            ///// 获得产品小类数据
            ///// </summary>
            ///// <param name="c"></param>
            //private void GetSmallCategroyDb(HttpContext c)
            //{
            //    int bigCategroyId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["bigCategroyId"]))
            //        int.TryParse(c.Request["bigCategroyId"].Trim(), out bigCategroyId);
            //    if (0 < bigCategroyId)
            //    {
            //        Dictionary<int, string> DictCate = CategoryBll.QueryCategroyListDb(bigCategroyId);
            //        if (DictCate != null)
            //        {
            //            string smallCate = "";
            //            foreach (KeyValuePair<int, string> kvp in DictCate)
            //                smallCate += "<option value=\"" + kvp.Key + "\">" + kvp.Value + "</option>";
            //            c.Response.Write(smallCate);
            //        }
            //        else
            //            c.Response.Write(null);
            //    }
            //}



            ///// <summary>
            ///// 保存会员上传色板数据
            ///// </summary>
            ///// <param name="c"></param>
            ///// <param name="userName">会员名</param>
            //private void SaveSwatchName(HttpContext c, string userName)
            //{ 
            //    //色板名称
            //    string SwatchName = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["SwatchName"]))
            //        SwatchName = c.Server.UrlDecode(c.Request["SwatchName"].Trim());
            //    //类别
            //    int myCategroy = 0;
            //    if (!string.IsNullOrEmpty(c.Request["myCategroy"]))
            //        int.TryParse(c.Request["myCategroy"].Trim(), out myCategroy);
            //    //色板图片
            //    string picture = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["picture"]))
            //        picture = c.Request["picture"].Trim();
            //    if (!string.IsNullOrEmpty(SwatchName) && 0 < myCategroy && !string.IsNullOrEmpty(picture))
            //    {
            //        picture = "series/" + picture;
            //        ColorSwatchModel model = new ColorSwatchModel();
            //        //色板名称
            //        model.SwatchName = SwatchName;
            //        //类别id
            //        model.CategroyId = myCategroy;
            //        //色板图片
            //        model.Picture = picture;
            //        //用户名
            //        model.CreateUser = userName;
            //        bool isSave = BrandBll.SaveColorSwatchDb(model);
            //        model = null;
            //        if (isSave)
            //            c.Response.Write("success");
            //        else
            //            c.Response.Write(null);
            //    }
            //}

            ///// <summary>
            ///// 获得颜色数据
            ///// </summary>
            ///// <param name="c"></param>
            //private void GetColorDb(HttpContext c)
            //{
            //    Dictionary<int, string> DictColor = ProductBll.QueryColorDb();
            //    if (DictColor != null)
            //    {
            //        string myColor = string.Empty;
            //        foreach (KeyValuePair<int, string> kvp in DictColor)
            //            myColor += "<option value=\""+kvp.Key+"\">"+kvp.Value+"</option>";
            //        c.Response.Write(myColor);
            //    }
            //    else
            //        c.Response.Write(null);
            //}

            ///// <summary>
            ///// 保存产品属性数据
            ///// </summary>
            ///// <param name="c"></param>
            ///// <param name="userName">会员名</param>
            //private void SaveProductProperty(HttpContext c, string userName)
            //{
            //    int productId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["productId"]))
            //        int.TryParse(c.Request["productId"].Trim(), out productId);
            //    if (productId < 0)
            //        productId = 0;

            //    int ppId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["ppId"]))
            //        int.TryParse(c.Request["ppId"].Trim(), out ppId);
            //    if (ppId < 0)
            //        ppId = 0;

            //    //类型id
            //    int typeId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["typeId"]))
            //        int.TryParse(c.Request["typeId"].Trim(), out typeId);
            //    if (typeId < 0)
            //        typeId = 0;

            //    ProductPropertyModel model = new ProductPropertyModel();
            //    model.ppId = ppId;
            //    //产品id
            //    model.ProductId = productId;
            //    //会员名
            //    model.userName = userName;
            //    //长
            //    model.Long = float.Parse(c.Request["Long"].Trim());
            //    //宽
            //    model.Width = float.Parse(c.Request["Width"].Trim());
            //    //高
            //    model.Height = float.Parse(c.Request["Height"].Trim());
            //    //体积
            //    model.Volume = float.Parse(c.Request["Volume"].Trim());
            //    //库存
            //    model.Stock = int.Parse(c.Request["Stock"].Trim());
            //    //颜色id
            //    model.ColorId = int.Parse(c.Request["colorId"].Trim());
            //    //详细材质说明
            //    model.MaterialDescript = c.Server.UrlDecode(c.Request["MaterialDescript"].Trim());
            //    //市场价
            //    model.MarketPrice = float.Parse(c.Request["MarketPrice"].Trim());
            //    //销售价
            //    model.SalePrice = float.Parse(c.Request["SalePrice"].Trim());
            //    //促销价
            //    model.PromoPrice = float.Parse(c.Request["PromoPrice"].Trim());
            //    //类型id
            //    model.typeId = typeId;
            //    int pid = 0;
            //    bool isSave=ProductBll.SaveProductPropertyDb(model,out pid);
            //    model = null;
            //    if (isSave)
            //        c.Response.Write(pid);
            //    else
            //        c.Response.Write(null);
            //}

            ///// <summary>
            ///// 获得属性数据
            ///// </summary>
            ///// <param name="c"></param>
            ///// <param name="userName">会员名</param>
            //private void GetProductProperty(HttpContext c, string userName)
            //{
            //    int productId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["productId"]))
            //        int.TryParse(c.Request["productId"].Trim(), out productId);
            //    if (productId < 0)
            //        productId = 0;

            //    int ppId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["ppId"]))
            //        int.TryParse(c.Request["ppId"].Trim(), out ppId);
            //    if (ppId < 0)
            //        ppId = 0;

            //    List<ProductPropertyModel> PPList = ProductBll.QueryProductPropertyDb(productId, ppId,userName);
            //    if (PPList != null)
            //    {
            //        string pp = string.Empty;
            //        foreach (ProductPropertyModel model in PPList)
            //        {
            //            pp += "<tr id=\"pp-" + model.ppId + "\">";
            //            pp += "<td height=\"40\">"+GetPpCode(model.ppId)+"</td>";
            //            pp += "<td>"+model.Long+"*"+model.Width+"*"+model.Height+"</td>";
            //            pp += "<td>"+model.Volume+"</td>";
            //            pp += "<td>" + model.MaterialDescript + "</td>";
            //            pp += "<td>" + model.ColorName + "</td>";
            //            pp += "<td>" + (model.Stock == -1 ? "长期供货" : model.Stock.ToString()) + "</td>";
            //            pp += "<td>" + model.MarketPrice + "</td>";
            //            pp += "<td>" + model.SalePrice + "</td>";
            //            pp += "<td>" + model.PromoPrice + "</td>";
            //            pp += "<td><a class=\"myhander\" onclick=\"EditorProductProp(" + model.ppId + ");\"><img src=\"../Images/bianji.png\" alt=\"编辑\" width=\"16\" height=\"16\" border=\"0\" /></a></td>";
            //            pp += "<td><a class=\"myhander\" onclick=\"DeleteProductProp(" + model.ppId + ");\"><img src=\"../Images/del.png\" alt=\"删除\" width=\"16\" height=\"16\" border=\"0\" /></a></td>";
            //            pp += "</tr>";
            //        }
            //        c.Response.Write(pp);
            //    }
            //    else
            //        c.Response.Write(null);
            //}

            /// <summary>
            /// 获得编号
            /// </summary>
            /// <param name="ppId">属性id</param>
            /// <returns></returns>
            public string GetPpCode(int ppId)
            {
                if (ppId < 10)
                    return "00" + ppId.ToString();
                else if (ppId < 100)
                    return "0" + ppId.ToString();
                else
                    return ppId.ToString();
            }

            ///// <summary>
            ///// 删除产品属性数据
            ///// </summary>
            ///// <param name="c"></param>
            ///// <param name="userName">会员名</param>
            //private void DeleteProductProperty(HttpContext c, string userName)
            //{
            //    int ppId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["ppId"]))
            //    {
            //        int.TryParse(c.Request["ppId"].Trim(), out ppId);
            //        if (0 < ppId)
            //        {
            //            int productId = 0;
            //            if (!string.IsNullOrEmpty(c.Request["productId"]))
            //                int.TryParse(c.Request["productId"].Trim(), out productId);
            //            if (productId < 0)
            //                productId = 0;
            //            bool IsDelete = ProductBll.DeleteProductPropertyDb(ppId,productId,userName);
            //            if (IsDelete)
            //                c.Response.Write("success");
            //            else
            //                c.Response.Write("fail");
            //        }
            //    }
            //}

            ///// <summary>
            ///// 查询编辑产品属性xml
            ///// </summary>
            ///// <param name="c"></param>
            ///// <param name="userName">会员名</param>
            //private void EditorProductProperty(HttpContext c, string userName)
            //{
            //    if (!string.IsNullOrEmpty(c.Request["ppId"]))
            //    {
            //        int ppId = 0;
            //        int.TryParse(c.Request["ppId"].Trim(), out ppId);
            //        if (0 < ppId)
            //        {
            //            int productId = 0;
            //            if (!string.IsNullOrEmpty(c.Request["productId"]))
            //                int.TryParse(c.Request["productId"].Trim(), out productId);
            //            if (productId < 0)
            //                productId = 0;
            //            string back = ProductBll.QueryEditorProductPropertyXml(userName,ppId,productId);
            //            c.Response.Write(back);
            //        }
            //    }
            //}

            ///// <summary>
            ///// 保存复制店铺数据
            ///// </summary>
            ///// <param name="c"></param>
            //private void SaveCopyShopDb(HttpContext c)
            //{
            //    //产品id
            //    string productId = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["productId"]))
            //        productId = c.Request["productId"].Trim();

            //    //店铺id
            //    string shopId = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["shopId"]))
            //        shopId = c.Request["shopId"].Trim();

            //    if(!string.IsNullOrEmpty(productId) && !string.IsNullOrEmpty(shopId))
            //    {
            //        productId = productId.TrimEnd(',').Trim();
            //        shopId = shopId.TrimEnd(',').Trim();
            //        int quantity = 0;
            //        bool IsCopy = ProductBll.SaveCopyProductToShopDb(productId,shopId,out quantity);
            //        if (IsCopy)
            //            c.Response.Write(quantity);
            //        else
            //            c.Response.Write(null);
            //    }
            //    else
            //        c.Response.Write(null);
            //}

            ///// <summary>
            ///// 上线（下线、删除）产品
            ///// </summary>
            ///// <param name="c"></param>
            //private void DoProductProperty(HttpContext c)
            //{
            //    string ppId = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["ppId"]))
            //        ppId = c.Request["ppId"].TrimEnd(',').Trim();
            //    string Type = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["Type"]))
            //        Type = c.Request["Type"].Trim();
            //    if (!string.IsNullOrEmpty(ppId) && !string.IsNullOrEmpty(Type))
            //    {
            //        if (Type == "up" || Type == "down" || Type == "delete")
            //        {
            //            bool IsDo = ProductBll.DoProductProperty(ppId,Type);
            //            if (IsDo)
            //                c.Response.Write("success");
            //            else
            //                c.Response.Write("fail");
            //        }
            //    }
            //}

            ///// <summary>
            ///// 获得编辑产品时数据
            ///// </summary>
            ///// <param name="c"></param>
            ///// <param name="userName">会员名</param>
            //private void GetEditorProductDb(HttpContext c, string userName)
            //{
            //    int productId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["productId"]))
            //        int.TryParse(c.Request["productId"].Trim(), out productId);
            //    if (productId < 0)
            //        productId = 0;
            //    int ppId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["ppId"]))
            //        int.TryParse(c.Request["ppId"].Trim(), out ppId);
            //    if (ppId < 0)
            //        ppId = 0;
            //    if (0 < productId || 0 < ppId)
            //    {
            //        string myxml = ProductBll.GetEditorProductXmlDb(productId,ppId,userName);
            //        c.Response.Write(myxml);
            //    }
            //}

            ///// <summary>
            ///// 通过产品编号查询产品
            ///// </summary>
            ///// <param name="c"></param>
            //private void CopyProductByNo(HttpContext c)
            //{
            //    int ppId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["ppId"]))
            //        int.TryParse(c.Request["ppId"].Trim(), out ppId);

            //    string productNo = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["productNo"]))
            //        productNo = c.Server.UrlDecode(c.Request["productNo"].Trim());
            //    string pxml = ProductBll.QueryCopyProdcutDbByNo(productNo, ppId);
            //    if (string.IsNullOrEmpty(pxml))
            //        c.Response.Write("no");
            //    else
            //        c.Response.Write(pxml);
            //}

            ///// <summary>
            ///// 将一个产品属性复制另一个产品属性中
            ///// </summary>
            ///// <param name="c"></param>
            //private void CopyPpToPp(HttpContext c, string userName)
            //{
            //    int productId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["productId"]))
            //        int.TryParse(c.Request["productId"].Trim(), out productId);
            //    if (productId < 0)
            //        productId = 0;
            //    int ppId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["ppId"]))
            //        int.TryParse(c.Request["ppId"].Trim(), out ppId);
            //    if (0 < ppId)
            //    {
            //        bool IsCopy = ProductBll.CopyPpToPp(productId,ppId,userName);
            //        if (IsCopy)
            //            c.Response.Write("success");
            //        else
            //            c.Response.Write("fail");
            //    }
            //}

            ///// <summary>
            ///// 获得复制产品后产品属性
            ///// </summary>
            ///// <param name="c"></param>
            ///// <param name="userName">会员名</param>
            //private void GetCopyPp(HttpContext c, string userName)
            //{
            //    int productId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["productId"]))
            //        int.TryParse(c.Request["productId"].Trim(), out productId);
            //    if (productId < 0)
            //        productId = 0;

            //    ProductPropertyModel model = ProductBll.QueryProductPropertyDb(productId, userName);
            //    if (model != null)
            //    {
            //        string pp = string.Empty;
            //        pp += "<tr id=\"pp-" + model.ppId + "\">";
            //        pp += "<td height=\"40\">" + GetPpCode(model.ppId) + "</td>";
            //        pp += "<td>" + model.Long + "*" + model.Width + "*" + model.Height + "</td>";
            //        pp += "<td>" + model.Volume + "</td>";
            //        pp += "<td>" + model.MaterialDescript + "</td>";
            //        pp += "<td>" + model.ColorName + "</td>";
            //        pp += "<td>" + (model.Stock == -1 ? "长期供货" : model.Stock.ToString()) + "</td>";
            //        pp += "<td>" + model.MarketPrice + "</td>";
            //        pp += "<td>" + model.SalePrice + "</td>";
            //        pp += "<td>" + model.PromoPrice + "</td>";
            //        pp += "<td><a class=\"myhander\" onclick=\"EditorProductProp(" + model.ppId + ");\"><img src=\"../Images/bianji.png\" alt=\"编辑\" width=\"16\" height=\"16\" border=\"0\" /></a></td>";
            //        pp += "<td><a class=\"myhander\" onclick=\"DeleteProductProp(" + model.ppId + ");\"><img src=\"../Images/del.png\" alt=\"删除\" width=\"16\" height=\"16\" border=\"0\" /></a></td>";
            //        pp += "</tr>";
            //        model = null;
            //        c.Response.Write(pp);
            //    }
            //    else
            //        c.Response.Write(null);
            //}

            ///// <summary>
            ///// 还原（删除）回收站中产品
            ///// </summary>
            ///// <param name="c"></param>
            //private void DoRecyclePp(HttpContext c)
            //{
            //    string ppId = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["ppId"]))
            //    {
            //        ppId = c.Request["ppId"].TrimEnd(',').Trim();
            //        if (!string.IsNullOrEmpty(ppId))
            //        {
            //            if (!string.IsNullOrEmpty(c.Request["Type"]))
            //            {
            //                string Type = c.Request["Type"].Trim();
            //                if (Type == "revertproductrecycle" || Type == "deleteproductrecycle")
            //                {
            //                    if (Type == "revertproductrecycle")
            //                        Type = "revert";
            //                    else
            //                        Type = "delete";
            //                    bool IsDo = ProductBll.DoRecycleProductProperty(ppId,Type);
            //                    if (IsDo)
            //                        c.Response.Write("success");
            //                    else
            //                        c.Response.Write("fail");
            //                }
            //            }
            //        }
            //    }
            //}

            #region 发布套组合时查询单品
            
        /// <summary>
        /// 发布套组合时查询单品
        /// </summary>
        /// <param name="c"></param>
        /// <param name="userName"></param>
            private void SearchGroupProductDb(HttpContext c, string userName)
            {
                //查询条件
                string Where = string.Empty;
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
                //if (!string.IsNullOrEmpty(c.Request["IsGroup"]))
                //{
                //    int.TryParse(c.Request["IsGroup"].Trim(), out myId);
                //    if (myId != 1)
                //        myId = 0;
                //    Where += " AND IsGroup = " + myId;
                //}
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
                string myChecked = string.Empty;
                //11.所属套组合
                if (!string.IsNullOrEmpty(c.Request["gpId"]))
                {
                    int.TryParse(c.Request["gpId"].Trim(), out myId);
                    if (0 < myId)
                    {
                        myChecked = " checked";
                        Where += " AND ppId IN (SELECT ppId FROM GroupProductProperty WHERE gpId = " + myId + " ) ";
                    }
                }
                #endregion

                #region 查询条件

                // string myurl = "groupproductList.aspx?";
               // string strWhere = "";
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

                #region 转换用户类型

                switch (memberInfo.type)
                {
                    #region 工厂企业

                    case (int)EnumMemberType.工厂企业:
                       
                        companyInfo = ECCompany.GetCompanyInfo(" where mid=" + memberInfo.id);
                        
                        brandList = ECBrand.GetBrandList(" companyid=" + companyInfo.id);
                        //brandList = ECBrand.GetBrandList("");                        
                        brandidlist = "";
                        if (brandList.Count > 0)
                        {
                            foreach (EnBrand b in brandList)
                            {
                                brandidlist += b.id + ",";
                            }
                            brandidlist = brandidlist.Length > 0 && brandidlist.EndsWith(",") ? brandidlist.Substring(0, brandidlist.Length - 1) : brandidlist;
                        }
                        else
                        {
                            brandList = null;
                            brandList = new List<EnBrand>();
                        }
                        brandidlist = string.IsNullOrEmpty(brandidlist) ? "0" : brandidlist;
                        //Modify：rafer 
                        //Date：2012-4-20
                        List<EnBrands> appCompanyList = ECBrand.GetBrandsList(" createmid=" + memberInfo.id);
                        if (appCompanyList.Count > 0)
                        {
                            foreach (EnBrands b in appCompanyList)
                            {
                                dealerCreateBrandIdList += b.brandid + ",";
                            }
                            dealerCreateBrandIdList = dealerCreateBrandIdList.Length > 0 && dealerCreateBrandIdList.EndsWith(",") ? dealerCreateBrandIdList.Substring(0, dealerCreateBrandIdList.Length - 1) : dealerCreateBrandIdList;
                        }
                        break;
                    #endregion

                    #region 经销商

                    case (int)EnumMemberType.经销商:
                       
                        dealerInfo = ECDealer.GetDealerInfo(" where mid=" + memberInfo.id);                        
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
                        break;
                    #endregion                  
                }

                #endregion
                switch (memberInfo.type)
                {
                    case (int)EnumMemberType.工厂企业:
                        Where += " and companyid=" + companyInfo.id;
                        break;
                    case (int)EnumMemberType.经销商:
                        if (brandidlist.Length > 0)
                        {
                            Where = " and brandid in (" + brandidlist + ") and brandid!=0";
                        }
                        break;
                }
               

                //if (!string.IsNullOrEmpty(Request["productNo"]))
                //    productNo = Request["productNo"].Trim();
                //if (!string.IsNullOrEmpty(productNo))
                //{
                //    strWhere += " and (isnull(sku,'')+isnull(title,'')+isnull(shottitle,'')+isnull(brandtitle,'') like '%" + productNo + "%')";
                //    //strWhere += " and title like '%" + txtProductName.Text + "%'";
                //}
                //if (gpId != 0)
                //{
                //    strWhere += " AND id IN (SELECT ppId FROM GroupProductProperty WHERE gpId = " + gpId + " ) ";
                //}


               
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
                int currentPage = 1;
                if (!string.IsNullOrEmpty(c.Request["Page"]))
                {
                    int.TryParse(c.Request["Page"].Trim(), out currentPage);
                    if (currentPage <= 0)
                        currentPage = 1;
                }
                #endregion
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
                          back += "<tr><td><input" + myChecked + " type=\"checkbox\" value=\"" + model.id + "\" /></td><td>" + model.no + "</td>"+
                              "<td>" + model.categorytitle + "</td><td><a>"+
  "<img width=\"100\" height=\"60\" src=\"" + TREC.Entity.EnFilePath.GetProductThumbPath("" + model.id.ToString() + "" + model.thumb != null ? model.thumb : "" + "", "", "upload") + "\"></a></td>" +
                             "<td>" + model.title + "</td><td>" + getProductSize(model.id) + "</td>" +
                             "<td>" + GetStatusStr(model.auditstatus) + "</td><td>" + model.linestatus =="0" ?"下线":"上线" + "</td></tr>";
                      }
                      back += "$" + PageCount;
                      productList.Clear();
                      productList = null;
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

            #endregion

          

            ///// <summary>
            ///// 上线（下线、删除）套组合产品
            ///// </summary>
            ///// <param name="c"></param>
            //private void DoGroupProduct(HttpContext c)
            //{
            //    string ppId = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["ppId"]))
            //        ppId = c.Request["ppId"].TrimEnd(',').Trim();
            //    string Type = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["Type"]))
            //        Type = c.Request["Type"].Trim();
            //    if (!string.IsNullOrEmpty(ppId) && !string.IsNullOrEmpty(Type))
            //    {
            //        if (Type == "up" || Type == "down" || Type == "delete")
            //        {
            //            bool IsDo = ProductBll.DoGroupProduct(ppId, Type);
            //            if (IsDo)
            //                c.Response.Write("success");
            //            else
            //                c.Response.Write("fail");
            //        }
            //    }
            //}

            ///// <summary>
            ///// 将套组合产品复制到店铺
            ///// </summary>
            ///// <param name="c"></param>
            //private void SaveGroupCopyShop(HttpContext c)
            //{
            //    //产品id
            //    string productId = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["productId"]))
            //        productId = c.Request["productId"].Trim();

            //    //店铺id
            //    string shopId = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["shopId"]))
            //        shopId = c.Request["shopId"].Trim();

            //    if (!string.IsNullOrEmpty(productId) && !string.IsNullOrEmpty(shopId))
            //    {
            //        productId = productId.TrimEnd(',').Trim();
            //        shopId = shopId.TrimEnd(',').Trim();
            //        int quantity = 0;
            //        bool IsCopy = ProductBll.SaveCopyGroupProductToShopDb(productId, shopId, out quantity);
            //        if (IsCopy)
            //            c.Response.Write(quantity);
            //        else
            //            c.Response.Write(null);
            //    }
            //    else
            //        c.Response.Write(null);
            //}

            ///// <summary>
            ///// 还原（删除）回收站中套组合产品
            ///// </summary>
            ///// <param name="c"></param>
            //private void DoRecycleGp(HttpContext c)
            //{
            //    string ppId = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["ppId"]))
            //    {
            //        ppId = c.Request["ppId"].TrimEnd(',').Trim();
            //        if (!string.IsNullOrEmpty(ppId))
            //        {
            //            if (!string.IsNullOrEmpty(c.Request["Type"]))
            //            {
            //                string Type = c.Request["Type"].Trim();
            //                if (Type == "revertgroupproductrecycle" || Type == "deletegroupproductrecycle")
            //                {
            //                    if (Type == "revertgroupproductrecycle")
            //                        Type = "revert";
            //                    else
            //                        Type = "delete";
            //                    bool IsDo = ProductBll.DoRecycleGroupProduct(ppId, Type);
            //                    if (IsDo)
            //                        c.Response.Write("success");
            //                    else
            //                        c.Response.Write("fail");
            //                }
            //            }
            //        }
            //    }
            //}

            ///// <summary>
            ///// 获得编辑套组合产品数据
            ///// </summary>
            ///// <param name="c"></param>
            //private void EditorGroupProduct(HttpContext c)
            //{
            //    if (!string.IsNullOrEmpty(c.Request["gpId"]))
            //    {
            //        int gpId = 0;
            //        int.TryParse(c.Request["gpId"].Trim(), out gpId);
            //        if (0 < gpId)
            //        {
            //            string gpXml = ProductBll.QueryEditorGroupProductDbXml(gpId);
            //            if (!string.IsNullOrEmpty(gpXml))
            //                c.Response.Write(gpXml);
            //            else
            //                c.Response.Write("no");
            //        }
            //    }
            //    else
            //        c.Response.Write(null);
            //}

            ///// <summary>
            ///// 通过产品编号查询套组合产品
            ///// </summary>
            ///// <param name="c"></param>
            //private void CopyGroupProductByNo(HttpContext c)
            //{
            //    int gpId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["gpId"]))
            //        int.TryParse(c.Request["gpId"].Trim(), out gpId);

            //    string productNo = string.Empty;
            //    if (!string.IsNullOrEmpty(c.Request["productNo"]))
            //        productNo = c.Server.UrlDecode(c.Request["productNo"].Trim());
            //    string pxml = ProductBll.QueryCopyGroupProdcutDbByNo(productNo, gpId);
            //    if (string.IsNullOrEmpty(pxml))
            //        c.Response.Write("no");
            //    else
            //        c.Response.Write(pxml);
            //}

            ///// <summary>
            ///// 查询产品中品牌对应系列数据
            ///// </summary>
            ///// <param name="c"></param>
            ///// <param name="userName">会员名</param>
            //private void BrandSeriesDb(HttpContext c, string userName)
            //{
            //    int brandId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["brandId"]))
            //        int.TryParse(c.Request["brandId"].Trim(), out brandId);
            //    Dictionary<int, string> DictSeries = BrandBll.QueryProductBrandSeriesDb(userName,brandId);
            //    if (DictSeries != null)
            //    {
            //        if (0 < DictSeries.Count)
            //        {
            //            string mySeries = string.Empty;
            //            foreach (KeyValuePair<int, string> kvp in DictSeries)
            //                mySeries += "<option value=\""+kvp.Key+"\">"+kvp.Value+"</option>";
            //            c.Response.Write(mySeries);
            //        }
            //        else
            //            c.Response.Write("no");
            //    }
            //    else
            //        c.Response.Write(null);
            //}

            ///// <summary>
            ///// 查询产品对应的店铺id
            ///// </summary>
            ///// <param name="c"></param>
            ///// <param name="userName">会员名</param>
            //private void ProductShopDb(HttpContext c, string userName)
            //{
            //    int brandId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["brandId"]))
            //        int.TryParse(c.Request["brandId"].Trim(), out brandId);
            //    int seriesId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["seriesId"]))
            //        int.TryParse(c.Request["seriesId"].Trim(), out seriesId);
            //    Dictionary<int, string> DictShop = ShopBll.QueryProductShopDb(userName, brandId, seriesId);
            //    if (DictShop != null)
            //    {
            //        if (0 < DictShop.Count)
            //        {
            //            string myShop = string.Empty;
            //            foreach (KeyValuePair<int, string> kvp in DictShop)
            //                myShop += "<option value=\"" + kvp.Key + "\">" + kvp.Value + "</option>";
            //            c.Response.Write(myShop);
            //        }
            //        else
            //            c.Response.Write("no");
            //    }
            //    else
            //        c.Response.Write(null);
            //}




            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        
    }
}