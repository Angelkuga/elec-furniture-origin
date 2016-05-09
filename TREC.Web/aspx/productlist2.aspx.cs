using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz.Data;
using Haojibiz.DAL;
using Haojibiz.Model;
using System.Text;

namespace TREC.Web.aspx
{
    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    using System.Data;
    #endregion


    public partial class productlist2 : WebPageBase
    {
        List<t_advertising> listt_advertising = new List<t_advertising>();
        List<t_advertising> list1 = new List<t_advertising>();//热卖推荐

        public string remai = "";
        public string leftmenu = "";
        public string lx = "";
        public string brand = "";
        public string market = "";

        public string xlid = "8";//床
        public string dlid = "7";
        public string key = "";

        public string recbrand = "";//推荐品牌
        public string recmarket = "";//推荐卖场
        public string brandlet = "";
        public string marketlet = "";
        string slx = "";//类型
        string sfg = "";//风格
        string scz = "";//材质
        string spp = "";//品牌
        string ssc = "";//色彩
        public string leixing = ""; public string tj = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 热卖推荐
            listt_advertising = TREC.ECommerce.ECAdvertisement.AdvertisingList("    AND tg.id IN (23,36)   ");
            list1 = listt_advertising.Where(x => x.categoryid == 23).ToList();

            StringBuilder strb = new StringBuilder();
            foreach (t_advertising item in list1.Take(3).ToList())
            {
                strb.Append("<dl>");
                strb.Append("<dt><a href='/productinfo.aspx?id=" + item.adcode + "'> <img src='" + item.imgurl + "' width='159' height='106' alt='' /></a></dt>");
                strb.Append("<dd>");
                strb.Append("<a href='" + item.linkurl + "'>" + item.title + "</a><br>");
                strb.Append("本站价：<span>￥" + item.price + "</span><br>");
                strb.Append("<img src='../../../resource/content/images/qg.jpg' onclick=\"addBAOMING(" + item.adcode + ",'" + Server.UrlEncode(item.title) + "'," + item.adcode + ")\" width='80' height='25' alt='' /></dd>");
                strb.Append("</dl>");
            }
            remai = strb.ToString();
            list1 = listt_advertising.Where(x => x.categoryid == 36).ToList();
            foreach (t_advertising item in list1)
            {
                tj += "<a href='" + item.linkurl + "' target='_blank'><img src='" + item.imgurl + "' /></a>";
            }
            #endregion


            #region 菜单导航

            try
            {
                xlid = string.IsNullOrEmpty(Request.QueryString["xid"]) ? "" : Request.QueryString["xid"].Replace("#", "");
                dlid = string.IsNullOrEmpty(Request.QueryString["did"]) ? "7" : Request.QueryString["did"].Replace("#", "");
                leixing = string.IsNullOrEmpty(Request.QueryString["tid"]) ? "" : Request.QueryString["tid"];

                int.Parse(dlid);
            }
            catch { xlid = "8"; dlid = "7"; }



            List<TREC.Entity.producttype> list = new List<producttype>();
            if (TRECommon.DataCache.GetCache("producttype") == null)
            { ECProduct.GetProductType(); }
            list = TRECommon.DataCache.GetCache("producttype") as List<producttype>;

            strb.Length = 0;



            int i = 0;
            int j = 0;
            foreach (producttype item in list)
            {


                if (item.tp2id.ToString() == dlid)
                {
                    strb.Append("<li class='hove'>");
                }
                else
                    strb.Append("<li>");


                strb.Append("<a href='?did=" + item.tp2id + "' t='d' >" + item.tp2title + "</a>");


                if (item.tp2id.ToString() == dlid)
                {
                    strb.Append("<div class='linu clearfix' style='display: block'>");
                }
                else
                    strb.Append("<div class='linu clearfix'  style='display: none'>");


                foreach (producttype xl in item.listxl)
                {
                    strb.Append("<a t='x' href='../productlist.aspx?xid=" + xl.tpid + "&dld=" + xl.tp2id + "'>" + xl.tptitle + "</a>");

                }
                strb.Append("</div>");
                strb.Append("</li>");


            }

            leftmenu = strb.ToString();

            #endregion


            #region





            //根据小类获取各种属性

            //产品类型
            List<TREC.Entity.tconfigtype> temp = new List<tconfigtype>();

            //风格


            //temp = list.Find(x => x.tp2id == int.Parse(dlid)).listxl.Find(x => x.tpid == int.Parse(xlid)).listattr.FindAll(x => x.configtype == Convert.ToInt32(EnumProductConType.材质工艺).ToString() && x.configtypeid == Convert.ToInt32(EnumConfigByProduct.产品风格).ToString()).ToList();


            temp = list[0].listtconfigtype.FindAll(x => x.cttype == Convert.ToInt32(EnumProductConType.材质工艺).ToString() && x.id == Convert.ToInt32(EnumConfigByProduct.产品风格)).ToList();

            strb.Length = 0;
            strb.Append("<dl>");
            strb.Append("<dt><strong>产品风格：</strong> </dt>");
            strb.Append("<dd id='ddfg' >");
            strb.Append("<a href='###' id='ddfgall' class='hove' onclick='setchk(this,\"ddfg\",\"fg\",\"\")' >不限</a> ");
            foreach (tconfigtype item in temp)
            {
                strb.Append("<a href='###' onclick='setchk(this,\"ddfg\",\"fg\",\"" + item.cid + "\")' >" + item.ctitle + "</a> ");
            }
            strb.Append("</dd></dl>");
            sfg = strb.ToString();

            //材质  
            temp = list[0].listtconfigtype.FindAll(x => x.cttype == Convert.ToInt32(EnumProductConType.材质工艺).ToString() && x.id == Convert.ToInt32(EnumConfigByProduct.产品选材)).ToList();

            strb.Length = 0;
            strb.Append("<dl>");
            strb.Append("<dt><strong>产品材质：</strong> </dt>");
            strb.Append("<dd id='ddcz'>");
            strb.Append("<a href='###' class='hove' id='ddczall' onclick='setchk(this,\"ddcz\",\"cz\",\"\")'>不限</a> ");
            foreach (tconfigtype item in temp)
            {
                strb.Append("<a href='###' onclick='setchk(this,\"ddcz\",\"cz\",\"" + item.cid + "\")' >" + item.ctitle + "</a> ");
            }
            strb.Append("</dd></dl>");
            scz = strb.ToString();

            //色系  
            temp = list[0].listtconfigtype.FindAll(x => x.cttype == Convert.ToInt32(EnumProductConType.材质工艺).ToString() && x.id == Convert.ToInt32(EnumConfigByProduct.产品颜色)).ToList();

            strb.Length = 0;
            strb.Append("<dl>");
            strb.Append("<dt><strong>产品色系：</strong> </dt>");
            strb.Append("<dd id='ddys'>");
            strb.Append("<a href='###' class='hove' id='ddysall' onclick='setchk(this,\"ddys\",\"ys\",\"\")'>不限</a> ");
            foreach (tconfigtype item in temp)
            {
                strb.Append("<a href='###' onclick='setchk(this,\"ddys\",\"ys\",\"" + item.cid + "\")'>" + item.ctitle + "</a> ");
            }
            strb.Append("</dd></dl>");
            ssc = strb.ToString();



            //temp = list.Find(x => x.tp2id == int.Parse(dlid)).listxl.Find(x => x.tpid == int.Parse(xlid)).listattr.FindAll(x => x.configtype == Convert.ToInt32(EnumProductConType.材质工艺).ToString() && x.configtypeid == Convert.ToInt32(EnumConfigByProduct.产品颜色).ToString()).ToList();
            //strb.Length = 0;
            //strb.Append("<dl>");
            //strb.Append("<dt><strong>产品色系：</strong> </dt>");
            //strb.Append("<dd>");
            //strb.Append("<a href='###'  class='hove'>不限</a> ");
            //foreach (producttype item in temp)
            //{
            //    strb.Append("<a href='###'>" + item.configtitle + "</a> ");
            //}
            //strb.Append("</dd></dl>");
            //ssc = strb.ToString();

            lx = sfg + scz + ssc;

            #endregion

            if (null == TRECommon.DataCache.GetCache("brandandmarket"))
            {
                ECBrand.GetBrand();
            }
            BrandAndMarket brandm = new BrandAndMarket();
            brandm = TRECommon.DataCache.GetCache("brandandmarket") as BrandAndMarket;

            #region 根据小类查询品牌
            strb.Length = 0;
            List<t_brand> brandlist = brandm.brandlist;
            string letter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            List<t_brand> tempt_brand;
            foreach (char let in letter)
            {
                tempt_brand = brandlist.FindAll(x => x.letter2.ToUpper() == let.ToString()).ToList();


                if (tempt_brand.Count > 0)
                {
                    brandlet += "<li ><a href='###'  >" + let + "</a></li>";
                }
                else
                    brandlet += "<li ><a href='###' style='color: #c5c5c5;cursor: default' >" + let + "</a></li>";

                strb.Append("<li class='tab_con'>");
                foreach (t_brand item in tempt_brand)
                {
                    strb.Append("<a href='###' onclick='setchk(this,\"tab_conbox2\",\"pp\",\"" + item.id + "\")' >" + item.title + "</a> ");
                }
                strb.Append("</li>");
            }
            brand = strb.ToString();

            #region 推荐品牌
            //显示两行数据,剩下的点击加号展开
            StringBuilder strbrand = new StringBuilder();
            strbrand.Append("<li class='tab_con'>");
            strbrand.Append("<table border='0' style='text-align:top' valign='top'>");
            strbrand.Append("<tr>");
            strbrand.Append("<td>");

            strbrand.Append("<div style='width:700px; height:75px; overflow-y: auto; overflow-x:hidden; border:0px solid #000000;'>");
            strbrand.Append("<div >");

            int brandcount = brandlist.Count;
            //显示付费或者前20条
            brandcount = brandlist.Count > 20 ? 20 : brandlist.Count;

            for (int k = 0; k < brandcount; k++)
            {
                strbrand.Append("<a href='###' onclick='setchk(this,\"tab_conbox2\",\"pp\",\"" + brandlist[k].id + "\")' >" + brandlist[k].title + "</a> ");
            }
            strbrand.Append("</div>");
            strbrand.Append("<div id='divbrand' style='display:none;width:700px;'>");
            //显示剩下的内容
            for (int k = brandcount; k < brandlist.Count; k++)
            {
                strbrand.Append("<a href='###' onclick='setchk(this,\"tab_conbox2\",\"pp\",\"" + brandlist[k].id + "\")' >" + brandlist[k].title + "</a> ");
            }
            strbrand.Append("</div>");
            strbrand.Append("</div>");
            strbrand.Append("</td>");
            strbrand.Append("<td  style='text-align:center' valign='top'>&nbsp;&nbsp;");
            strbrand.Append("<label style='color:#f89a05' onclick='javascript:if($(this).html()==\"展开\"){$(\"#divbrand\").show();$(this).html(\"收起\");}else{$(this).html(\"展开\");$(\"#divbrand\").hide();};' style='cursor:pointer'>展开</label>");
            strbrand.Append("</td>");
            strbrand.Append("</tr>");
            strbrand.Append("</table>");
            strbrand.Append("</li>");

            recbrand = strbrand.ToString();





            #endregion

            #endregion

            #region 根据小类查询卖场
            strb.Length = 0;
            List<t_market> marketlist = brandm.marketlist;

            List<t_market> tempt_market;
            foreach (char let in letter)
            {
                tempt_market = marketlist.FindAll(x => x.letter2.ToUpper() == let.ToString()).ToList();
                if (tempt_market.Count > 0)
                {
                    marketlet += "<li ><a href='###'  >" + let + "</a></li>";
                }
                else
                    marketlet += "<li ><a href='###' style='color: #c5c5c5;cursor: default' >" + let + "</a></li>";
                strb.Append("<li class='tab_con'>");
                foreach (t_market item in tempt_market)
                {
                    strb.Append("<a href='###' onclick='setchk(this,\"tab_conbox\",\"mc\",\"" + item.id + "\")'>" + item.title + "</a> ");
                }
                strb.Append("</li>");
            }
            market = strb.ToString();

            #region 推荐卖场
            strbrand.Length = 0;

            strbrand.Append("<li class='tab_con'>");
            strbrand.Append("<table border='0' style='text-align:top' valign='top'>");
            strbrand.Append("<tr>");
            strbrand.Append("<td>");

            strbrand.Append("<div style='width:700px; height:75px; overflow-y: auto; overflow-x:hidden;  border:0px solid #000000;'>");
            strbrand.Append("<div>");

            brandcount = marketlist.Count;
            //显示付费或者前20条
            brandcount = marketlist.Count > 10 ? 10 : marketlist.Count;

            for (int k = 0; k < brandcount; k++)
            {
                strbrand.Append("<a href='###' onclick='setchk(this,\"tab_conbox\",\"mc\",\"" + marketlist[k].id + "\")' >" + marketlist[k].title + "</a> ");
            }
            strbrand.Append("</div>");
            strbrand.Append("<div id='divmarket' style='display:none;width:700px;'>");
            //显示剩下的内容
            for (int k = brandcount; k < marketlist.Count; k++)
            {
                strbrand.Append("<a href='###' onclick='setchk(this,\"tab_conbox\",\"mc\",\"" + marketlist[k].id + "\")' >" + marketlist[k].title + "</a> ");
            }
            strbrand.Append("</div>");
            strbrand.Append("</div>");
            strbrand.Append("</td>");
            strbrand.Append("<td  style='text-align:center' valign='top'>&nbsp;&nbsp;");
            strbrand.Append("<label style='color:#f89a05' onclick='javascript:if($(this).html()==\"展开\"){$(\"#divmarket\").show();$(this).html(\"收起\");}else{$(this).html(\"展开\");$(\"#divmarket\").hide();};' style='cursor:pointer'>展开</label>");
            strbrand.Append("</td>");
            strbrand.Append("</tr>");
            strbrand.Append("</table>");
            strbrand.Append("</li>");

            recmarket = strbrand.ToString();
            #endregion
            #endregion

        }

        //<li class="tab_con">
        //<a href="#" class="hove">北欧1</a> 
        //<a href="#">现代</a> 
        //<a href="#">休闲</a>
        //</li>



    }
}