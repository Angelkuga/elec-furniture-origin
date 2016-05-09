using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz.Model;
using Haojibiz.DAL;
using Haojibiz.Data;


namespace TREC.Web.aspx
{
    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    using System.Collections;
    using System.Text;
    #endregion

    public partial class guide : WebPageBase
    {
        #region shen
        List<t_advertising> listt_advertising = new List<t_advertising>();

        public List<t_advertising> list1 = new List<t_advertising>();//商家活动
        public List<t_advertising> list2 = new List<t_advertising>();//商家活动

        public string stradv = "";
        public string brandlet = "";
        public string marketlet = "";
        public string brand = "";
        public string market = "";
        public string recbrand = "";//推荐品牌
        public string recmarket = "";//推荐卖场
        //卖场信息
        BrandAndMarket brandm = new BrandAndMarket();

        //品牌
        public List<t_brand> listbrand = new List<t_brand>();
        public List<EnArea> listarea = new List<EnArea>();
        public List<t_market> listmarket = new List<t_market>();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            StringBuilder strb = new StringBuilder();
            //获取所有广告列表
           // listt_advertising = TREC.ECommerce.ECAdvertisement.AdvertisingList("");

            listt_advertising = TREC.ECommerce.ECAdvertisement.AdvertisingList(" and tg.id in (21,22) ");



            list1 = listt_advertising.Where(x => x.categoryid == 21).ToList();//商家活动页面-右边广告图
            list2 = listt_advertising.Where(x => x.categoryid == 22).ToList();//顶部"商家活动页面-顶部广告图"
            stradv = "[";
            int i = 0;
            foreach (t_advertising item in list2)
            {

                stradv += "{ Title: '" + item.title + "', Href: '" + item.linkurl + "', Target: '_blank', Img: '" + item.imgurl + "' }";
                if (i < list2.Count - 1)
                    stradv += ",";
                i++;
            }
            stradv += "]";

            if (null == TRECommon.DataCache.GetCache("brandandmarket"))
            {
                ECBrand.GetBrand();
            }
            brandm = TRECommon.DataCache.GetCache("brandandmarket") as BrandAndMarket;
            

            //根据付款情况, 显示前几位品牌; 或者显示主要品牌.
            listbrand = brandm.brandlist;
            //根据付款情况, 显示前几位卖场; 或者显示主要卖场.
            listmarket = brandm.marketlist;
 


            /*
             * 根据用户选择的城市选择区
             */

            //获取用户选择的城市名
            EnArea area = TREC.ECommerce.ECArea.EnAreaList().Find(x => (x.areaname == "上海" || x.areaname == "上海市"));
            listarea = area.CountyList;


            //setchk(this,"dlbid","bid","");

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
                    brandlet += "<li ><a href='###' style=' padding:0 7px;' >" + let + "</a></li>";
                }
                else
                    brandlet += "<li ><a href='###' style='color: #c5c5c5;cursor: default;padding:0 7px;' >" + let + "</a></li>";

                strb.Append("<li class='tab_con'>");

                foreach (t_brand item in tempt_brand)
                {
                    strb.Append("<a href='###' onclick='setchk(this,\"tab_conbox2\",\"bid\",\"" + item.id + "\")' >" + item.title + "</a> ");
                }
                strb.Append("</li>");
            }
            brand = strb.ToString();

            #region 推荐品牌
            //显示两行数据,剩下的点击加号展开
            StringBuilder strbrand = new StringBuilder();
            strbrand.Append("<li class='tab_con'  >");
            strbrand.Append("<table border='0' style='text-align:top' valign='top'>");
            strbrand.Append("<tr>");
            strbrand.Append("<td>");

            strbrand.Append("<div style='width:658px; height:100px; overflow-y: auto; overflow-x:hidden; border:0px solid #000000;'>");
            strbrand.Append("<div id='top20'>");

            int brandcount = brandlist.Count;
            //显示付费或者前20条
            brandcount = brandlist.Count > 20 ? 20 : brandlist.Count;

            for (int k = 0; k < brandcount; k++)
            {
                strbrand.Append("<a href='###' onclick='setchk(this,\"tab_conbox2\",\"bid\",\"" + brandlist[k].id + "\")' >" + brandlist[k].title + "</a> ");
            }
            strbrand.Append("</div>");
            strbrand.Append("<div id='divbrand' style='width:658px;overflow-y: auto; overflow-x:hidden;'>");
            //显示剩下的内容
            for (int k = brandcount; k < brandlist.Count; k++)
            {
                strbrand.Append("<a href='###' onclick='setchk(this,\"tab_conbox2\",\"bid\",\"" + brandlist[k].id + "\")' >" + brandlist[k].title + "</a> ");
            }
            strbrand.Append("</div>");
            strbrand.Append("</div>");
            strbrand.Append("</td>");
           // strbrand.Append("<td  style='text-align:center' valign='top'>&nbsp;&nbsp;");
           // strbrand.Append("<label style='color:#f89a05' onclick='javascript:if($(this).html()==\"展开\"){$(\"#divbrand\").show();$(this).html(\"收起\");}else{$(this).html(\"展开\");$(\"#divbrand\").hide();$(\"#top20\").hide();};' style='cursor:pointer'>收起</label>");
           // strbrand.Append("</td>");
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
                    marketlet += "<li ><a href='###' style='padding:0 7px;' >" + let + "</a></li>";
                }
                else
                    marketlet += "<li ><a href='###' style='color: #c5c5c5;cursor: default;padding:0 7px;' >" + let + "</a></li>";

                strb.Append("<li class='tab_con'>");
                foreach (t_market item in tempt_market)
                {
                    strb.Append("<a href='###' onclick='setchk(this,\"tab_conbox\",\"mid\",\"" + item.id + "\")'>" + item.title + "</a> ");
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

            strbrand.Append("<div style='width:658px; height:100px; overflow-y: auto; overflow-x:hidden;  border:0px solid #000000;'>");
            strbrand.Append("<div>");

            brandcount = marketlist.Count;
            //显示付费或者前20条
            brandcount = marketlist.Count > 10 ? 10 : marketlist.Count;

            for (int k = 0; k < brandcount; k++)
            {
                strbrand.Append("<a href='###' onclick='setchk(this,\"tab_conbox\",\"mc\",\"" + marketlist[k].id + "\")' >" + marketlist[k].title + "</a> ");
            }
            strbrand.Append("</div>");
            strbrand.Append("<div id='divmarket' style='width:600px;'>");
            //显示剩下的内容
            for (int k = brandcount; k < marketlist.Count; k++)
            {
                strbrand.Append("<a href='###' onclick='setchk(this,\"tab_conbox\",\"mc\",\"" + marketlist[k].id + "\")' >" + marketlist[k].title + "</a> ");
            }
            strbrand.Append("</div>");
            strbrand.Append("</div>");
            strbrand.Append("</td>");
            //strbrand.Append("<td  style='text-align:center' valign='top'>&nbsp;&nbsp;");
            //strbrand.Append("<label style='color:#f89a05' onclick='javascript:if($(this).html()==\"展开\"){$(\"#divmarket\").show();$(this).html(\"收起\");}else{$(this).html(\"展开\");$(\"#divmarket\").hide();};' style='cursor:pointer'>收起</label>");
            //strbrand.Append("</td>");
            strbrand.Append("</tr>");
            strbrand.Append("</table>");
            strbrand.Append("</li>");

            recmarket = strbrand.ToString();
            #endregion

            #endregion


        }


        //private void GetCount(EnArea area)
        //{ 
        //  //递归读取,获取最低级别的行政区

        //    foreach (EnArea item in area.CountyList)
        //    {
                
        //    }

        //}


    }
}