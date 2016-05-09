using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using System.Collections;
using System.Text;
using TREC.Entity;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace TREC.Web.aspx.ascx
{
    public class header : System.Web.UI.UserControl
    {
        public Hashtable _htb = new Hashtable();//数据统计

        public string brand = "";

        public string xilie = "";
        public string nid = "";
        string letter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        protected void Page_Load(object sender, EventArgs e)
        {
            //string n = Request.QueryString["n"];
            #region
            string url = Request.Url.LocalPath.ToLower();

            switch (url)
            {
                case "/template/web/default/index.aspx":
                    nid = "1";
                    break;
                case "/template/web/default/companybrandlist.aspx":
                    nid = "2";
                    break;
                case "/template/web/default/marketlist.aspx":
                    nid = "3";
                    break;
                case "/template/web/default/.aspx":
                    nid = "4";
                    break;
                case "/template/web/default/productlisttbb.aspx":
                    nid = "5";
                    break;
                case "/template/web/default/...aspx":
                    nid = "6";
                    break;
                case "/template/web/default/guide.aspx":
                    nid = "7";
                    break;
                case "/template/web/default/news.aspx":
                    nid = "8";
                    break;

            }
            #endregion

            _htb = ECProduct.GetIndexCount().FirstOrDefault();


            StringBuilder strb = new StringBuilder();
            StringBuilder strb2 = new StringBuilder();

            List<TREC.Entity.producttype> list = TRECommon.DataCache.GetCache("producttype") as List<TREC.Entity.producttype>;

            if (list == null)
                list = TREC.ECommerce.ECProduct.GetProductType();



            if (null == TRECommon.DataCache.GetCache("brandandmarket"))
                ECBrand.GetBrand();
            BrandAndMarket bm = TRECommon.DataCache.GetCache("brandandmarket") as BrandAndMarket;

            #region
            strb.Length = 0;
            List<t_brand> brandlist = bm.brandlist;

            List<t_brand> tempt_brand;
            foreach (char let in letter)
            {
                tempt_brand = brandlist.FindAll(x => x.letter2.ToUpper() == let.ToString()).ToList();

                if (tempt_brand.Count == 0)
                {
                    strb.Append("<a style='vertical-align:middle;display:inline-block;padding:0 6px;color: #c5c5c5;cursor: inherit;font-family:Arial, Helvetica, sans-serif;font-size:12px;'>" + let + "</a>&nbsp;");

                    strb2.Append("<div class='item hide' title='" + let + "'><div class='inner'  ></div></div>");

                }
                else
                {
                    strb.Append("<span>" + let + "</span>&nbsp;");

                    strb2.Append("<div class='item hide' style='font-size:12px;'>");
                    strb2.Append("<div class='inner' title='" + let + "'>");
                    strb2.Append("<ul>");
                    List<string> brandlistc = new List<string>();

                    foreach (t_brand item in tempt_brand)
                    {
                       // strb2.Append("<li style='line-height:25px'><a target='_blank' href='" + ECommon.WebUrl.TrimEnd('/') + "/company/" + item.companyid + "/index.aspx'>" + item.title + "</a></li> ");
                        if (!brandlistc.Contains(item.title))
                        {
                            strb2.Append("<li style='line-height:25px'><a target='_blank' href='/ShopBrand.aspx?bname=" + HttpContext.Current.Server.UrlEncode(item.title) + "'>" + item.title + "</a></li> ");
                        }

                        brandlistc.Add(item.title);
                    }
                    strb2.Append("</ul></div></div>");
                }
            }
            brand = "<dt>" + strb.ToString() + "</dt><dd>" + strb2.ToString() + "</dd>";
            #endregion


            #region
            strb.Length = 0;
            strb2.Length = 0;
            //产品分类
            List<producttype> listcategory;
            //产品属性信息
            List<producttype> listcategory2 = TRECommon.DataCache.GetCache("producttypeall") as List<TREC.Entity.producttype>;
            if (listcategory2 == null)
                listcategory2 = TREC.ECommerce.ECProduct.GetProductTypeAll();


            listcategory = list;
            List<producttype> listcategorytemp = listcategory.FindAll(x => x.tpshow == 1);
          
            producttype pttemp;
            List<producttype> listcategorytemp2;


            List<t_navigationbrand> navbrand = TREC.ECommerce.ECAdvertisement.t_navigationbrandList();

            List<t_advertising> listt_advertising = TREC.ECommerce.ECAdvertisement.AdvertisingList(" AND tg.id  in (45) ");

            int stylecount = 2;

            foreach (producttype item in listcategorytemp)
            {
                stylecount++;

                strb.Append("<li class='li" + stylecount + "'>");
                strb.Append("<a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/productlist.aspx?did=" + item.tp2id + "' class='nav-item'>" + item.tp2title + "</a> ");
                strb.Append("<a href='#' class='trim'></a>");
                strb.Append("    <dl class='hide'  style=' min-height:300px'>");
                strb.Append("	<dd>");
                strb.Append("	    <div class='item'>");
                strb.Append("		<div class='inner' style=' min-height:145px;' >");

                strb.Append("		    <table border='0'>");
                strb.Append("			<tr>");
                strb.Append("			    <td style='width: 50px' align='right'>");

                //套组合
                pttemp = item.listxl.Find(x => x.tpshow == 1 && x.tp2id == item.tp2id && x.ptype == 2);

                if (pttemp != null)
                    strb.Append("				<a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/productlist2.aspx?did=" + item.tp2id + "&ty=" + Server.UrlEncode(pttemp.tptitle) + "'  style='color: #9f1121'>" + pttemp.tptitle + "</a>");

                strb.Append("			    </td>");
                strb.Append("			    <td style='font-size: 12px; font-family: 宋体;'>");
                strb.Append("				&nbsp;");
                strb.Append("			    </td>");
                strb.Append("			</tr>");
                strb.Append("		    </table>");


                listcategorytemp2 = item.listxl.FindAll(x => x.tpshow == 1 && x.tp2id == item.tp2id && x.ptype == 1).ToList();//listcategory.FindAll(x => x.ptype ==1 && x.tp2id == item.tp2id && x.tpshow == 1).ToList();

                foreach (producttype pt in listcategorytemp2)
                {
                    strb.Append("		    <table>");
                    strb.Append("			<tr>");
                    strb.Append("			    <td style='width: 50px' align='right'>");
                    strb.Append("				<a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/productlist.aspx?xid=" + pt.tpid + "&did=" + item.tp2id + "' style='color: #9f1121'>" + pt.tptitle + "</a>");
                    strb.Append("			    </td>");
                    strb.Append("			    <td style='font-size: 12px; font-family: 宋体;'>");

                    //读取config
                    List<producttype> listconfig = listcategory2.FindAll(x => x.ptype == 1 && x.parentid == item.tp2id && x.tpid == pt.tpid && x.tpshow == 1 && x.configtype == "103" && x.configtypeid == "11").ToList();

                    foreach (producttype lc in listconfig)
                    {
                        strb.Append("				<a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/productlist.aspx?xid=" + pt.tpid + "&did=" + item.tp2id + "&tid=" + lc.value + "'>" + lc.configtitle + "</a> ");
                    }

                    strb.Append("			    </td>");
                    strb.Append("			</tr>");
                    strb.Append("		    </table>");

                }


                strb.Append("		</div>");
                strb.Append("		<div class='inner-img'>");


                //List<t_navigationbrand> listnav = navbrand.FindAll(x => x.ntype == 3 && x.ntypeid == item.tp2id).Take(8).ToList();

                List<t_advertising> listnav = listt_advertising.FindAll(x => x.adcode == item.tp2id.ToString());

                foreach (t_advertising nav in listnav)
                {
                    //  strb.Append("		    <a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/company/" + nav.companyid + "/index.aspx'><img src='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/upload/brand/logo/"+nav.brandid+"/"+nav.logo+"' /></a>");
                    strb.Append("		    <a href='" + nav.linkurl + "'><img style='width: 120px; height: 45px;' src='" + nav.imgurl + "' /></a>");
                }
                strb.Append("		</div>");
                strb.Append("	    </div>");
                strb.Append("	</dd>");
                strb.Append("    </dl>");
                strb.Append("</li>");
               
            }

            xilie = strb.ToString();

            #endregion

        }
    }
}



/*
<li class='li3'>
<a href='<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlist.aspx?did=7' class='nav-item'>卧室系列</a> 
<a href='#' class='trim'></a>
    <dl class='hide'>
	<dd>
	    <div class='item'>
		<div class='inner'>

		    <table border='0'>
			<tr>
			    <td style='width: 50px' align='right'>
				<a href='/product/list2---------1--7-64.aspx?ty=%u5367%u5BA4%u5957%u7EC4%u5408%20'  style='color: #9f1121'>卧室套组合</a>
			    </td>
			    <td style='font-size: 12px; font-family: 宋体;'>
				&nbsp;
			    </td>
			</tr>
		    </table>
		  

		    <table>
			<tr>
			    <td style='width: 50px' align='right'>
				<a href='/productlist.aspx?xid=16&did=7' style='color: #9f1121'>梳妆</a>
			    </td>
			    <td style='font-size: 12px; font-family: 宋体;'>
				<a href='/productlist.aspx?xid=16&did=7&tid=129'>梳妆台/镜</a> 
				<a href='/productlist.aspx?xid=16&did=7&tid=125'>梳妆镜</a> 
				<a href='/productlist.aspx?xid=16&did=7&tid=124'>梳妆台</a>
			    </td>
			</tr>
		    </table>
		    



		</div>
		<div class='inner-img'>
		    <a href='http://www.jiajuks.com/company/210/index.aspx'><img src='http://www.jiajuks.com/upload/brand/logo/414/20130608105907455896.jpg' /></a>
		  
		</div>
	    </div>
	</dd>
    </dl>
</li>
 * 
 * 
 */