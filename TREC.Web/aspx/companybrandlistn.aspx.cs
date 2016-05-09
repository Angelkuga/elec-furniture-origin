using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace TREC.Web.aspx
{
    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    using System.Text.RegularExpressions;
    using System.Collections;
    using System.Data;
    using System.IO;
    #endregion

    public partial class companybrandlistn : WebPageBase
    {
        public string hletter = "";
        public string sfg = "";
        public string scz = "";
        public string market = "";
        public string selectfg = "";
        public string selectcz = "";



        public string rightletter = "";
        public string rightletter2 = "";


        public string tuijian = "";
        public string shangjia = "";
        public string adv = "";
        public string allmc = "";

        /// <summary>
        /// 右侧品牌广告 
        /// </summary>
        /// <returns></returns>
        private string getBrandAdver()
        {
            string sql = " SELECT TOP 43  dbo.f_BrandUrl(id) as url, * FROM t_brand WHERE auditstatus=1 and linestatus=1  ORDER BY id DESC";
            System.Data.DataTable dt = TREC.ECommerce.ECommerce.GetTable(sql);

            StringBuilder _value = new StringBuilder(string.Empty);
            foreach (DataRow r in dt.Rows)
            {
                _value.Append(" <a href=\"" + r["url"].ToString() + "\" target=\"_blank\"><img src=\"http://www.jiajuks.com/upload/brand/logo/" + r["Id"].ToString() + "/" + r["logo"].ToString().Replace(",","") + "\" style=\"width: 196px;height:80px;\"></a>&nbsp;&nbsp;<br>");
            }

            return _value.ToString();
        }

        public string bname
        {
            get
            {
                if (Request["bname"] != null)
                {
                    return Request["bname"];
                }
                else
                {
                    //
                    return "";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            

            #region
            if (null == TRECommon.DataCache.GetCache("brandandmarket"))
            {
                ECBrand.GetBrand();
            }
            BrandAndMarket brandm = new BrandAndMarket();
            brandm = TRECommon.DataCache.GetCache("brandandmarket") as BrandAndMarket;

           List<t_brand> brandlist = brandm.brandlist;
            StringBuilder strb = new StringBuilder();
            StringBuilder strb2 = new StringBuilder();
            StringBuilder strb3 = new StringBuilder();
           
            string letter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            List<t_brand> tempt_brand;

            List<string> checkBrandName = new List<string>();
            foreach (char let in letter)
            {
                tempt_brand = brandlist.FindAll(x => x.letter2.ToUpper() == let.ToString()).ToList();
                if (tempt_brand.Count == 0)
                {
                    strb.Append(" <li><a class='a' href='###'>" + let.ToString() + " </a></li>");

                    rightletter += "<li class='none'>" + let.ToString() + "</li> ";


                }
                else
                {
                    strb.Append("<li><a class='a' href='###'>" + let.ToString() + "  </a>");
                    strb.Append("<div data-alpha='" + let.ToString() + "'>");
                    strb.Append("<ul class='clearfix'>");
                    strb2.Length = 0;


                    strb3.Length = 0;
                    strb3.Append("<li class='root'><b>" + let.ToString() + " <s>(" + tempt_brand.Count + ")</s><a name='" + let.ToString() + "' href='###'></a></b><ul>");
                    foreach (t_brand item in tempt_brand)
                    {
                        if (!checkBrandName.Contains(item.title))
                        {
                           // strb2.Append(" <li><a href='" + TREC.ECommerce.ECommon.WebUrl + "company/" + item.companyid + "/index.aspx'>" + item.title + "</a></li>");
                            strb2.Append(" <li><a href='/ShopBrand.aspx?bname=" + Server.UrlEncode(item.title) + "'  target=\"_blank\">" + item.title + "</a></li>");
                            strb3.Append("<li><a target='_blank' href='" + TREC.ECommerce.ECommon.WebUrl + "/company/" + item.companyid + "/index.aspx'><big>" + item.title + "</big></a></li>");
                        }

                        checkBrandName.Add(item.title);
                    }
                    strb3.Append("</ul></li>");
                    rightletter2 += strb3.ToString();

                    strb.Append(strb2);
                    strb.Append("</ul></div></li>");

                    rightletter += " <li><a href='#" + let.ToString() + "'>" + let.ToString() + "</a></li>";

                }

            }
            hletter = strb.ToString();


            List<t_market> marketlist = brandm.marketlist;

            List<t_market> tempt_market;
            strb.Length = 0;
            strb.Append("<li class='on'><a class='on' href='###' onclick='setchk(this,\"tab_conbox\",\"mc\",\"\")' onmouseover=\"javascript:$('#divmc').show();\" >不限 </a>");

            strb.Append("</li>");

            #region 所有卖场

            strb3.Length = 0;
            strb3.Append("<div class='drop' id='divmc' style='width:800px;border: 0px solid #ffffff' onmouseover='javascript:$(this).show();' onmouseout='javascript:$(this).hide();'>");
            strb3.Append("<table border='0' style='text-align:top' valign='top'>");
            strb3.Append("<tr>");
            strb3.Append("<td>");

            strb3.Append("<div style='width:800px; height:100px; overflow:auto; border:0px solid #000000;overflow-y: auto; overflow-x:hidden;'>");
            strb3.Append("<div >");

            int brandcount = marketlist.Count;
            //显示付费或者前20条
            brandcount = marketlist.Count > 10 ? 10 : marketlist.Count;

            for (int k = 0; k < brandcount; k++)
            {
                strb3.Append("<a href='###' onclick='setchk(this,\"tab_conbox2\",\"mc\",\"" + marketlist[k].id + "\")' >" + marketlist[k].title + "</a> ");
            }
            strb3.Append("</div>");
            strb3.Append("<div id='divbrand' style='display:none;width:700px;overflow-y: auto; overflow-x:hidden; border: 0px solid #ffffff;'>");
            //显示剩下的内容
            for (int k = brandcount; k < marketlist.Count; k++)
            {
                strb3.Append("<a href='###' onclick='setchk(this,\"tab_conbox2\",\"mc\",\"" + marketlist[k].id + "\")' >" + marketlist[k].title + "</a> ");
            }
            strb3.Append("</div>");
            strb3.Append("</div>");
            strb3.Append("</td>");
            //strb3.Append("<td  style='text-align:center' valign='top'>&nbsp;&nbsp;&nbsp;&nbsp;");
            //strb3.Append("<label style='color:#f89a05' onclick='javascript:if($(this).html()==\"展开\"){$(\"#divbrand\").show();$(this).html(\"收起\");}else{$(this).html(\"展开\");$(\"#divbrand\").hide();};' style='cursor:pointer'>展开</label>");
            //strb3.Append("</td>");
            strb3.Append("</tr>");
            strb3.Append("</table>");

            strb3.Append("</div>");
            allmc = strb3.ToString();
            #endregion




            foreach (char let in letter)
            {
                tempt_market = marketlist.FindAll(x => x.letter2.ToUpper() == let.ToString()).ToList();



                strb.Append("<li  >");
                if (tempt_market.Count > 0)
                    strb.Append("<a class='a0' href='###' onmouseover=\"javascript:$('#divmc').hide();\" >" + let.ToString() + "<i></i></a>");
                else
                    strb.Append("<a class='a0' href='#' style='color: #c5c5c5;cursor: default' >" + let.ToString() + "<i></i></a>");

                if (tempt_market.Count > 0)
                    strb.Append("<div class='drop' style='width:780px; border: 0px solid #ffffff;' >");
                else
                    strb.Append("<div class='drop' style='width:0px; border: 0px solid #ffffff;' >");

                strb2.Length = 0;
                foreach (t_market item in tempt_market)
                {
                    strb2.Append("<a href='###' onclick='setchk(this,\"tab_conbox\",\"mc\",\"" + item.id + "\")'>" + item.title + "</a> ");
                }
                strb.Append(strb2);
                strb.Append("</div></li>");
            }
            market = strb.ToString();

            #endregion


            #region
            List<TREC.Entity.producttype> list = new List<producttype>();
            if (TRECommon.DataCache.GetCache("producttype") == null)
            { ECProduct.GetProductType(); }
            list = TRECommon.DataCache.GetCache("producttype") as List<producttype>;

            List<TREC.Entity.tconfigtype> temp = new List<tconfigtype>();

            //风格
            temp = list[0].listtconfigtype.FindAll(x => x.cttype == Convert.ToInt32(EnumProductConType.材质工艺).ToString() && x.id == Convert.ToInt32(EnumConfigByProduct.产品风格)).ToList();

            strb.Length = 0;

            strb.Append("<dd id='ddfg' >");
            strb.Append("<a href='###' id='ddfgall' class='arrow-on' onclick='setchk(this,\"ddfg\",\"fg\",\"\")' >不限</a> ");

            int i = 0;

            foreach (tconfigtype item in temp)
            {
                strb.Append("<a href='###' onclick='setchk(this,\"ddfg\",\"fg\",\"" + item.cid + "\")' >" + item.ctitle + "</a> ");
                i++;
               // if (i % 14 == 0 && i != temp.Count + 1)
                    //    strb.Append("<br />");
               selectfg += "<option value='" + item.cid + "'>" + item.ctitle + "</option>";

            }
            strb.Append("</dd>");
            sfg = strb.ToString();
            selectfg = "<select id='selectfg' onchange='selval(\"fg\",\"selectfg\")' class='inp' style='width: 105px;'><option value='0' >所有风格</option>" + selectfg + "</select>";

            //材质  
            temp = list[0].listtconfigtype.FindAll(x => x.cttype == Convert.ToInt32(EnumProductConType.材质工艺).ToString() && x.id == Convert.ToInt32(EnumConfigByProduct.产品选材)).ToList();

            strb.Length = 0;
            i = 0;
            strb.Append("<dd id='ddcz'>");
            strb.Append("<a href='###' class='on' id='ddczall' onclick='setchk(this,\"ddcz\",\"cz\",\"\")'>不限</a> ");
            foreach (tconfigtype item in temp)
            {
                strb.Append("<a href='###' onclick='setchk(this,\"ddcz\",\"cz\",\"" + item.cid + "\")' >" + item.ctitle + "</a> ");

                i++;
              //  if (i % 13 == 0 && i != temp.Count + 1)
              //     strb.Append("<br />");

               selectcz += "<option value='" + item.cid + "'>" + item.ctitle + "</option>";
            }
            strb.Append("</dd>");
            scz = strb.ToString();

            selectcz = "<select class='inp' id='selectcz' onchange='selval(\"cz\",\"selectcz\")' style='width: 105px;'><option value='0'>所有材质</option>" + selectcz + "</select>";
            #endregion


            #region 广告
            //获取所有广告列表
            List<t_advertising> listt_advertising = TREC.ECommerce.ECAdvertisement.AdvertisingList("   AND tg.id IN (24,25,26)  ");
            //品牌搜索页-右边推荐品牌
            List<t_advertising> list1 = listt_advertising.Where(x => x.categoryid == 24).Take(8).ToList();//"品牌搜索页-右边推荐品牌"
            //右边底部广告
            List<t_advertising> list2 = listt_advertising.Where(x => x.categoryid ==25 ).Take(1).ToList();//"品牌搜索页-右边底部广告"
            //优质商家
            List<t_advertising> list3 = listt_advertising.Where(x => x.categoryid ==26).Take(1).ToList();// "品牌搜索页-优质商家"

            StringBuilder strb1 = new StringBuilder();

            int tjcount = 0;
            foreach (t_advertising item in list1)
            {
                if (!string.IsNullOrEmpty(item.imgurl))
                {
                    tjcount++;
                    strb1.Append("<a target='_blank' href='" + item.linkurl + "' >");

                    //if (tjcount % 2 == 1)
                    strb1.Append("<img style='width: 196px;height:80px;' src='" + item.imgurl + "'/></a>&nbsp;&nbsp;");
                    //else
                    //    strb1.Append("<img style='width: 100px; height: 80px;' src='" + item.imgurl + "'/></a>");

                    //if (tjcount % 2 == 0 && tjcount != 0 && tjcount != list1.Count)
                    //{
                    strb1.Append("<br />");
                    //}
                }

            }

            //tuijian = strb1.ToString();
            tuijian = getBrandAdver();
            //轮播广告
            strb1.Length = 0;
            foreach (t_advertising item in list2)
            {
                if (!string.IsNullOrEmpty(item.imgurl))
                {
                    strb1.Append("<a href='" + item.linkurl + "' target='_blank'><img style='width: 232px; height: 286px;' src='" + item.imgurl + "' /></a>");
                }
            }
            adv = strb1.ToString();
            //优质商家
            //adcode存储产品表id号码  根据id获取商家logo和简介
            strb1.Length = 0;
            if (list3.Count > 0)
            {
                string sql=@" SELECT t_product.id,t_brand.companyid,t_company.descript,   t_brand.logo, brandid,t_brand.title as brandtitle,t_product.title
                        ,dbo.t_product.thumb,(SELECT TOP 1 saleprice  FROM t_productattribute WHERE productid = t_product.id  ) AS price  

                          FROM dbo.t_product 
                        INNER JOIN dbo.t_brand ON t_brand.id =  t_product.brandid
                        INNER JOIN dbo.t_company ON t_company.id = t_brand.companyid 
                         WHERE t_product.id= " + list3[0].adcode;
                System.Data.DataTable dt = TREC.ECommerce.ECommerce.GetTable(sql);

                if (dt.Rows.Count == 1)
                {

                    if (!string.IsNullOrEmpty(dt.Rows[0]["thumb"] as string))
                    {
                        strb1.Append("<ul class='clearfix'>");
                        strb1.Append("<a target='_blank' href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/productinfo.aspx?id=" + dt.Rows[0]["id"] + "'>");
                        strb1.Append("<img  src='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/upload/product/thumb/" + dt.Rows[0]["id"] + "/" + dt.Rows[0]["thumb"] + "'");
                        strb1.Append("style='width: 223px; height: 165px;' /><br />");
                        strb1.Append("<p style=' padding:0 6px'>" + dt.Rows[0]["title"] + "</p>");
                        strb1.Append("<p style='padding:0 6px'>");
                        strb1.Append("参考价：¥" + dt.Rows[0]["price"] + "</p>");
                        strb1.Append("</a>");
                        strb1.Append("</ul>");
                        strb1.Append("<table style='text-align:center;' >");
                        strb1.Append("<tr>");
                        strb1.Append("<td valign='top'   style='vertical-align:top; padding-left:6px;'>");
                        strb1.Append("<a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/company/" + dt.Rows[0]["companyid"] + "/brand-" + dt.Rows[0]["brandid"] + ".aspx' target='_blank'>");
                        strb1.Append("<img src='/upload/brand/logo/" + dt.Rows[0]["brandid"] + "/" + dt.Rows[0]["logo"].ToString().Split(',')[0] + "' style='height: 32px; width: 84px' />");
                        strb1.Append("</a>");
                        strb1.Append("</td>");
                        strb1.Append("<td valign='top'   align='left' style=' padding-right6px;'>");
                        strb1.Append("<a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/company/" + dt.Rows[0]["companyid"] + "/brand-" + dt.Rows[0]["brandid"] + ".aspx' target='_blank'>");
                        strb1.Append("<label>");
                        strb1.Append(TRECommon.StringOperation.GetString(dt.Rows[0]["descript"].ToString(), 65, "..."));
                        strb1.Append("</label></a>");
                        strb1.Append("</td>");
                        strb1.Append("</tr>");
                        strb1.Append("</table>");
                    }
                }
                shangjia = strb1.ToString();
            }


            #endregion

        }


       // protected global::System.Web.UI.WebControls.Repeater Repeater_brandshop;
    }


}