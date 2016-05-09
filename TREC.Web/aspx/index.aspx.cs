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
    using System.Data;
    using Haojibiz;
    using System.Text;
    #endregion


    public partial class index : WebPageBase
    {


        #region wj
        public List<t_advertising> newBrand = new List<t_advertising>(); //品牌推荐数据/……
        public List<t_advertising> timeLimiBuy = new List<t_advertising>(); //限时抢购数据/……
        public List<t_advertising> timeLimiBuyB = new List<t_advertising>(); //限时抢购B数据/……

        public List<EnProductCategory> prodCateList = new List<EnProductCategory>(); //淘宝贝 产品系列数据/……
        public EnWebProduct[] prodList = new EnWebProduct[] { }; //淘宝贝 产品数据/……
        public List<EnProductCategory> prodCateDetListA = new List<EnProductCategory>(); //淘宝贝 产品系列子分类数据A/……
        #endregion

        public Hashtable _htb = new Hashtable();//数据统计

        #region [优惠促销]
        protected Dpromotions dpromotions = new Dpromotions();
        protected List<Mpromotions> promotionslist = new List<Mpromotions>();
        protected List<Mshop> promotionsshop = new List<Mshop>();
        protected List<Mmarket> promotionsmarket = new List<Mmarket>();
        #endregion

        #region [新闻资讯]
        //protected Dnews dnews = new Dnews();
        //protected List<NewsInfo> newslist = new List<NewsInfo>();
        #endregion


        #region shen 2015-01-30
        List<t_advertising> listt_advertising = new List<t_advertising>();

        public List<t_advertising> list1 = new List<t_advertising>();//品牌推荐
        public List<t_advertising> list2 = new List<t_advertising>();//限时抢购
        public List<t_advertising> list3 = new List<t_advertising>();//本周特价
        public List<t_advertising> list4 = new List<t_advertising>();//商家活动

        public BrandAndMarket bm = new BrandAndMarket();
        //搜搜快报
        public DataTable promsdt = new DataTable();

        List<EnArea> listArea = new List<EnArea>();//区域

        public string strArea = "";
        public string tbbdl = "";
        public string tbbxlxq = "";
        public string tbbxlxq2 = "";
        public string xlb = ""; //左边小菜单+广告
        public System.Text.StringBuilder strb = new System.Text.StringBuilder();
        public System.Text.StringBuilder builder = new System.Text.StringBuilder();

        public string dgtitle = "";

        public System.Text.StringBuilder strbdt = new System.Text.StringBuilder();
        #endregion


        public string checkurl(string logo, string id, string img)
        {
            if (!string.IsNullOrEmpty(img))
            {
                return img;
            }
            else
            {
                return "/upload/brand/logo/" + id + "/" + logo.Replace(",", "");
            }
        }

        public string getBrandProc(string brandId,string url)
        {

            DataSet dt = new DataSet();
            dt = ECBrand.GetDataSet("t_product", " top 4 *", " where linestatus=1 AND  auditstatus=1 AND brandid=" + brandId, " order by  id desc");

            int i=0;
            StringBuilder _value=new StringBuilder(string.Empty);
            string dis = "";
            foreach (DataRow r in dt.Tables[0].Rows)
            {
                if (i == 0)
                { 
                    dis="display:block;";
                }
                else
                {
                    dis = "display:block;";
                }
                _value.Append("<li style=\"width: 100%;" + dis + "\"><a href=\"" + url + "\"><img src=\"/upload/product/thumb/" + r["Id"].ToString() + "/" + r["thumb"].ToString().Replace(",", "") + "\"  style=\"width:336px;height:176px;\"></a></li>");
                
            }

            return _value.ToString();
        }
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();

        public string groupbyloplist = string.Empty;
        public string groupbylogdefault1 = string.Empty;
        public string groupbylogdefImg1 = string.Empty;

        public string groupbylogdefault2 = string.Empty;
        public string groupbylogdefImg2= string.Empty;

        /// <summary>
        /// 团购信息处理
        /// </summary>
        private void groupbuydes()
        {
            List<GroupBuy> _listlog = new List<GroupBuy>();
            _listlog = EntityOper.GroupBuy.OrderByDescending(o => o.Orderby).ToList();

            StringBuilder _valuelop = new StringBuilder(string.Empty);

            int i = 0;
            int r = 0;


            foreach (GroupBuy g in _listlog)
            {
                string img = (string.IsNullOrEmpty(g.ImgUrl) ? "/upload/brand/logo/" + g.brandId + "/" + g.brandImgUrl.TrimEnd(',') : g.ImgUrl);
                if (g.isdefault!=null && g.isdefault.Value == true)
                {
                    if (r == 0)
                    {
                        groupbylogdefault1 = "<a href=\"/51/default.aspx#brand" + g.Id + "\"><img src=\"" + img + "\"  style=\"width:183px;height:41px;\"/></a>";
                        groupbylogdefImg1 = getBrandProc(g.brandId.ToString(),"/51/default.aspx#brand" + g.Id);
                        r++;
                    }
                    else if(r==1)
                    {
                        groupbylogdefault2 = "<a href=\"/51/default.aspx#brand" + g.Id + "\"><img src=\"" + img + "\"  style=\"width:183px;height:41px;\"/></a>";
                        groupbylogdefImg2 = getBrandProc(g.brandId.ToString(), "/51/default.aspx#brand" + g.Id);
                    }
                }
                else
                {
                    i++;
                    if (i <= 15)
                    {

                        _valuelop.Append("<li class=\"tglog\" onclick=\"javascript:location.href='/51/default.aspx#brand" + g.Id + "'\">");
                        _valuelop.Append(" <center><div><img src=\"" + img + "\" style=\"width:144px;height:52px;\" /> </div> </center>");
                        _valuelop.Append("<span class=\"tglogspan\">" + g.brandName + "</span>");
                        _valuelop.Append("<span class=\"tglogred\" style=\"color:#D23E4A;\">" + g.DiscountResult2 + "折起</span>");
                        _valuelop.Append("</li>");
                    }
                }
            }
            groupbyloplist=_valuelop.ToString();
        }

        public string getEnterUser(string brind, int t, object d)
        {
            int fd = 0;
            try
            {
                fd = SubmitMeth.getInt(d.ToString());
            }
            catch
            {

            }
            if (t == 0)
            {
                return (SubmitMeth.getInt(ECBrand.EnterUser(brind).Tables[t].Rows[0][0].ToString()) + fd).ToString();
            }
            else
            {
                return (SubmitMeth.getInt(ECBrand.EnterUser(brind).Tables[0].Rows[0][0].ToString()) + SubmitMeth.getInt(ECBrand.EnterUser(brind).Tables[1].Rows[0][0].ToString()) + fd).ToString();
            }
        }
        public string indbrandLetter = string.Empty;
        public string indbrandtitle = string.Empty;
        public string indbrandurl = string.Empty;
        public string firstBrandTitle = string.Empty;
        public string brand_adleft = "", brand_ad1 = "", brand_ad2 = "", brand_ad3 = "", brand_ad4 = "", brand_ad5 = "", market_adtop = "";

        private void IndexBrand()
        {
            string letter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            
            DataSet ds = new DataSet();
            ds = ECBrand.Brandindex();
            StringBuilder _titleList = new StringBuilder(string.Empty);
            StringBuilder _brandUrl = new StringBuilder(string.Empty);
            
            string display = "block";
            foreach (char let in letter)
            {
                if (let == 'A')
                {
                    display = "block";
                }
                else
                {
                    display = "none";
                }
                _titleList.Append("<div id=\"divbrand_" + let + "\" style=\"display:" + display + ";\">");
                if (ds.Tables[0].Select(" letter='" + let + "'").Length > 0)
                {
                    indbrandLetter = indbrandLetter + "<span onmouseover=\"showbrandletter('divbrand_"+let+"')\">" + let + "</span>";
                }
                else
                {
                    indbrandLetter = indbrandLetter + "<span style=\"color:#D1CBCB;\" onmouseover=\"showbrandletter('divbrand_" + let + "')\">" + let + "</span>";
                }

                foreach (DataRow r in ds.Tables[1].Select(" letter='" + let + "'"))
                {
                    if (string.IsNullOrEmpty(firstBrandTitle))
                    {
                        firstBrandTitle = r["title"].ToString();
                    }
                    _titleList.Append("<a target='_blank' href=\"/ShopBrand.aspx?bname=" + HttpContext.Current.Server.UrlEncode(r["title"].ToString()) + "\" onmouseover=\"searchbrna('" + r["title"].ToString() + "')\">" + r["title"].ToString() + "</a>");
                }
                _titleList.Append("</div>");
            }

            // {'欧妮亚':{ 'name': '欧妮亚', 'id': '1' }, '帕堤欧': { 'name': '帕堤欧', 'id': '2'} };
            foreach (DataRow r in ds.Tables[2].Rows)
            {
                string u=r["indexdata"].ToString();
                string address = u.Split('↑')[2].Replace(" ", "");
                string areacode = u.Split('↑')[3];
               
               string area=TREC.ECommerce.ECommon.getAreaAll(areacode);

               address = area.Replace("市辖区", "") + address.Replace(area, "").Replace("市辖区", "");


               _brandUrl.Append("'" + r["title"].ToString() + "':{ 'name': '" + r["title"].ToString() + "', 'url': '" + u.Split('↑')[0] + "','company':'" + u.Split('↑')[1] + "','address':'" + address + "','phone':'" + u.Split('↑')[4] + "','style':'" + r["stylename"].ToString() + "','material':'" + r["materialname"].ToString() + "','bannel':'" + u.Split('↑')[5].Split(',')[0] + "','logo':'" + "/upload/brand/logo/" + r["id"].ToString() + "/" + r["logo"].ToString().Replace(",", "") + "' },");
            }
            indbrandurl = "{" + _brandUrl.ToString().TrimEnd(',') + "};";
            indbrandtitle = _titleList.ToString();

        }

        private void indexbrandtop()
        {
            Repeater_brand2.DataSource = ECBrand.BrandIndextop(10, "", "t1.sort desc");//大牌推荐
            Repeater_brand2.DataBind();

            Repeater_brand3.DataSource = ECBrand.BrandIndextop(10, "", "t1.hits desc");//人气品牌
            Repeater_brand3.DataBind();

            //Repeater_brand4.DataSource = ECBrand.BrandIndextop(25, "", "");
            //Repeater_brand4.DataBind();

            Repeater_brand5.DataSource = ECBrand.BrandIndextop(25, " and t1.style=48 ", "");//现代
            Repeater_brand5.DataBind();

            Repeater_brand6.DataSource = ECBrand.BrandIndextop(25, " and t1.style=50 ", "");//田园
            Repeater_brand6.DataBind();

            Repeater_brand7.DataSource = ECBrand.BrandIndextop(25, " and t1.style=53 ", "");//美式
            Repeater_brand7.DataBind();

            Repeater_brand8.DataSource = ECBrand.BrandIndextop(25, " and (t1.style=51 or t1.style=46) ", "");//北欧宜家
            Repeater_brand8.DataBind();

            Repeater_brand9.DataSource = ECBrand.BrandIndextop(25, " and t1.material=21 ", "");//全实木
            Repeater_brand9.DataBind();

            //Repeater_brand10.DataSource = ECBrand.BrandIndextop(25, " and t1.material=12 ", "");//实木框架
            //Repeater_brand10.DataBind();

            //Repeater_brand11.DataSource = ECBrand.BrandIndextop(25, " and t1.material=13 ", "");//板式
            //Repeater_brand11.DataBind();

            //Repeater_brand12.DataSource = ECBrand.BrandIndextop(25, " and t1.material=18 ", "");//布艺
            //Repeater_brand12.DataBind();

            //Repeater_brand13.DataSource = ECBrand.BrandIndextop(25, " and t1.material=16 ", "");//藤艺
            //Repeater_brand13.DataBind();

            //Repeater_brand14.DataSource = ECBrand.BrandIndextop(25, " and t1.material=19 ", "");//皮艺
            //Repeater_brand14.DataBind();

            //Repeater_gd.DataSource = ECBrand.BrandAdver();
            //Repeater_gd.DataBind();
            Repeater_brandmarket.DataSource = ECBrand.brandAdverMarket();
            Repeater_brandmarket.DataBind();
            List<t_advertising> _list = new List<t_advertising>();

            _list = TREC.ECommerce.ECAdvertisement.AdvertisingList(" and t.id in (234,233,232,231,230,229,235) ");
            string url = "";
            if (_list.Where(p => p.id == 229).FirstOrDefault() != null)
            {
                brand_adleft = "<a href=\"" + _list.Where(p => p.id == 229).FirstOrDefault().linkurl + "\" target=\"_blank\"><img src=\""+url + _list.Where(p => p.id == 229).FirstOrDefault().imgurl.Replace(",","") + "\" /> </a>";
            }
            if (_list.Where(p => p.id == 230).FirstOrDefault() != null)
            {
                brand_ad1 = "<a href=\"" + _list.Where(p => p.id == 230).FirstOrDefault().linkurl + "\" target=\"_blank\"><img src=\""+url + _list.Where(p => p.id == 230).FirstOrDefault().imgurl.Replace(",", "") + "\"  style=\"width:239px;height:239px;\" border=\"0\"/></a>";
            }
            if (_list.Where(p => p.id == 231).FirstOrDefault() != null)
            {
                brand_ad2 = "<a href=\"" + _list.Where(p => p.id == 231).FirstOrDefault().linkurl + "\" target=\"_blank\"><img src=\""+url + _list.Where(p => p.id == 231).FirstOrDefault().imgurl.Replace(",", "") + "\"  style=\"width:239px;height:239px;\" border=\"0\"/></a>";
            }
            if (_list.Where(p => p.id == 232).FirstOrDefault() != null)
            {
                brand_ad3 = "<a href=\"" + _list.Where(p => p.id == 232).FirstOrDefault().linkurl + "\" target=\"_blank\"><img src=\""+url + _list.Where(p => p.id == 232).FirstOrDefault().imgurl.Replace(",", "") + "\"  style=\"width:239px;height:239px;\" border=\"0\"/></a>";
            }
            if (_list.Where(p => p.id == 233).FirstOrDefault() != null)
            {
                brand_ad4 = "<a href=\"" + _list.Where(p => p.id == 233).FirstOrDefault().linkurl + "\" target=\"_blank\"><img src=\""+url + _list.Where(p => p.id == 233).FirstOrDefault().imgurl.Replace(",", "") + "\"  style=\"width:239px;height:239px;\" border=\"0\"/></a>";
            }
            if (_list.Where(p => p.id == 234).FirstOrDefault() != null)
            {
                brand_ad5 = "<a href=\"" + _list.Where(p => p.id == 234).FirstOrDefault().linkurl + "\" target=\"_blank\"><img src=\""+url + _list.Where(p => p.id == 234).FirstOrDefault().imgurl.Replace(",", "") + "\"  style=\"width:241px;height:239px;\" border=\"0\"/></a>";
            }
             if (_list.Where(p => p.id == 235).FirstOrDefault() != null)
            {
                market_adtop = " <a href=\"" + _list.Where(p => p.id == 235).FirstOrDefault().linkurl + "\" target=\"_blank\">  <img src=\""+url + _list.Where(p => p.id == 235).FirstOrDefault().imgurl.Replace(",", "") + "\"  style=\"width:1200px;height:325px;\"  border=\"0\"/></a>";
             }
           
        }
        /// <summary>
        /// 二级域名url跳转 http://www.jiajuks.com/
        /// </summary>
        private void urlreturn()
        {
            try
            {
                IpAddress _getIP = new IpAddress();
                string url = Request.Url.ToString().ToLower().Replace("http://", "");
                string ip = url.Split('.')[0];
                if (ip != "www" && ip != "jiajuks")
                {
                    _getIP = EntityOper.IpAddress.Where(p => p.Ip.ToLower() == ip.ToLower()).FirstOrDefault();
                    if (_getIP != null)
                    {
                        Response.Redirect(_getIP.Url);
                    }
                }
            }
            catch
            { 
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            urlreturn();
            indexbrandtop();
            IndexBrand();
           // groupbuydes();
            #region wj
            int pcount = 0;

            //获取所有广告列表
            listt_advertising = TREC.ECommerce.ECAdvertisement.AdvertisingList(" and tg.id in (17,18,19,20,42,43,44,46,47,48) ");



            newBrand = listt_advertising.Where(x => x.categoryid == 42).Take(14).ToList();//主站首页-品牌推荐
            timeLimiBuy = listt_advertising.Where(x => x.categoryid == 43).Take(6).ToList();//主站首页-限时抢购
            timeLimiBuyB = listt_advertising.Where(x => x.categoryid == 44).Take(6).ToList();//主站首页-本周特价


            prodCateList = ECProductCategory.GetProductCategoryList(-1, 0, "parentid=0 or id in (select id from t_productcategory where parentid=9)", out pcount).OrderBy(c => c.id).ToList();

            prodCateDetListA = prodCateList.Where(c => c.parentid == 9).OrderBy(c => c.title).ToList();
            prodCateList = prodCateList.Where(c => c.parentid == 0).ToList();

            prodList = ECProduct.GetWebProductList(1, 12, " and categoryid in (select id from t_productcategory where parentid=7)", "id", "asc", out pcount).ToArray();
            #endregion


            promsdt = TREC.ECommerce.ECommerce.GetTable("EXEC proc_t_promotions 6 ");

            #region shen

            list1 = listt_advertising.Where(x => x.categoryid == 17).Take(1).ToList();//首页-品牌推荐左边广告位
            list2 = listt_advertising.Where(x => x.categoryid == 18).Take(2).ToList();//首页-限时抢购右边广告位
            list3 = listt_advertising.Where(x => x.categoryid == 19).Take(2).ToList();//首页-本周特价右边广告位
            list4 = listt_advertising.Where(x => x.categoryid == 20).ToList();//首页-商家活动导购

            if (null == TRECommon.DataCache.GetCache("brandandmarket"))
            {
                TREC.ECommerce.ECBrand.GetBrand();
            }
            bm = TRECommon.DataCache.GetCache("brandandmarket") as BrandAndMarket;



            listArea = TREC.ECommerce.ECArea.EnAreaList();

            /*
             * 根据用户选择的城市选择区
             */

            //获取用户选择的城市名

            EnArea area = listArea.Find(x => (x.areaname == "上海" || x.areaname == "上海市"));


            #region  商家活动导购
            //导航标题
            List<t_advertising> dg1 = list4.FindAll(x => string.IsNullOrEmpty(x.adcode)).ToList();
            List<t_advertising> dg2;
            //Dictionary<int, string> dic = new Dictionary<int, string>();

            //foreach (t_advertising item in dg1)
            //{
            //    System.Text.StringBuilder strbdt1 = new System.Text.StringBuilder();
            //    dg2 = list4.FindAll(x => x.adcode == item.id.ToString()).ToList();
            //    strbdt1.Append(
            //}


            #region 导购查询
            System.Text.StringBuilder strbdtdg = new System.Text.StringBuilder();
            strbdtdg.Append("<div class='fr shortcut'>");
            strbdtdg.Append("<div class='tit b f16 tc'>");
            strbdtdg.Append("<i></i>商家活动查询</div>");
            strbdtdg.Append("<dl>");
            strbdtdg.Append("    <dt><a href='#' target='_blank'>卖场</a></dt>");
            strbdtdg.Append("    <dd>");


            //前4个卖场
            for (int mcindex = 0; mcindex < bm.marketlist.Count; mcindex++)
            {
                if (mcindex < 4)
                    strbdtdg.Append("    <a href='/guide.aspx?mid=" + bm.marketlist[mcindex].id + "' target='_blank'>" + bm.marketlist[mcindex].title + "</a>");
            }
            strbdtdg.Append("    <a href='/guide.aspx' target='_blank' class='a0' >更多</a>");

            strbdtdg.Append("    </dd>");
            strbdtdg.Append("</dl>");

            strbdtdg.Append("<dl>");
            strbdtdg.Append("    <dt><a href='#' target='_blank'>品牌</a></dt>");
            strbdtdg.Append("    <dd>");
            //前4个品牌
            for (int ppindex = 0; ppindex < bm.brandlist.Count; ppindex++)
            {
                if (ppindex < 11)
                    strbdtdg.Append("    <a href='/guide.aspx?bid=" + bm.brandlist[ppindex].id + "' target='_blank'>" + bm.brandlist[ppindex].title + "</a>");
            }
            strbdtdg.Append("     <a href='guide.aspx' target='_blank' class='a0' >更多</a>");
            strbdtdg.Append("    </dd>");
            strbdtdg.Append("</dl>");
            strbdtdg.Append("<dl>");
            strbdtdg.Append("    <dt><a href='#' target='_blank'>厂商</a></dt>");
            strbdtdg.Append("    <dd>");

            //前四个厂商
            for (int cindex = 0; cindex < bm.companylist.Count; cindex++)
            {
                if (cindex < 4)//改为id查询?
                    strbdtdg.Append("	<a href='##' onclick='javascript:var d =escape('" + bm.companylist[cindex].title + "');this.href='/guide.aspx?cid='+d;' target='_blank'>" + bm.companylist[cindex].title + "</a>");

            }
            //strbdtdg.Append("	<a href='##' onclick='javascript:var d =escape('<%=items.title %>');this.href='guide.aspx?cid='+d;' target='_blank'><%=items.title%></a>");

            strbdtdg.Append("	<a href='guide.aspx' target='_blank' class='a0' >更多</a>");
            strbdtdg.Append("    </dd>");
            strbdtdg.Append("</dl>");
            strbdtdg.Append("<a href='/guide.aspx' class='block shortcut-more b f16 tc' target='_blank'>更多查询条件</a>");
            strbdtdg.Append("</div>");
            #endregion




            for (int i = 0; i < dg1.Count; i++)
            {
                //if (i == 0)
                //    dgtitle += " <li class='on'>" + dg1[i].title + "</li>";
                //else
                    dgtitle += " <li>" + dg1[i].title + "</li> ";


                if (i == 0)
                    strbdt.Append("  <div class='item'>"); //div1 start
                else
                    strbdt.Append("  <div class='item hide'>"); //div1 start

                strbdt.Append("<div class='active-guild' style='padding-bottom: 10px; margin-bottom: 10px;'>");//div2 start
                strbdt.Append("<div class='w'>");//div3 start
                strbdt.Append("<div class='bd'>");//div4 start


                System.Text.StringBuilder strbdt1 = new System.Text.StringBuilder();
                dg2 = list4.FindAll(x => x.adcode == dg1[i].id.ToString()).ToList();

                if (dg2.Count < 7)
                {
                    for (int j = 0; j < 7 - dg2.Count; j++)
                    {
                        t_advertising t_adv = new t_advertising();
                        t_adv.adcode = dg1[i].id.ToString();
                        t_adv.categoryid = dg1[i].categoryid;
                        t_adv.imgurl = "/resource/content/images/nopic.jpg";
                        t_adv.linkurl = "###";
                        dg2.Add(t_adv);
                    }
                }
                #region 第一行数据
                strbdt.Append("<div class='d1 clearfix'>");
                strbdt.Append("<div class='fl'>");
                strbdt.Append("<a href='" + dg2[0].linkurl + "' target='_blank'>");
                strbdt.Append("<img style='width: 795px; height: 298px' src='" + dg2[0].imgurl + "' alt='' class='block' />");
                strbdt.Append("</a>");
                strbdt.Append("</div>");
                strbdt.Append("<div class='fr'>");
                strbdt.Append("<a href='" + dg2[1].linkurl + "' target='_blank'>");
                strbdt.Append("<img style='width: 392px; height: 298px' src='" + dg2[1].imgurl + "' alt='' class='block' />");
                strbdt.Append("</a>");
                strbdt.Append("</div>");
                strbdt.Append("</div>");
                #endregion

                #region 第二行数据
                strbdt.Append("<div class='d2 clearfix'>");
                strbdt.Append("<div class='fl'>");
                strbdt.Append("<a href='" + dg2[2].linkurl + "' target='_blank' class='fl'>");
                strbdt.Append("<img style='width: 392px; height: 298px' src='" + dg2[2].imgurl + "' alt='' class='block' />");
                strbdt.Append("</a><a href='" + dg2[3].linkurl + "' target='_blank' class='fr'>");
                strbdt.Append("<img style='width: 392px; height: 298px' src='" + dg2[3].imgurl + "' alt='' class='block' />");
                strbdt.Append("</a>");
                strbdt.Append("</div>");
                strbdt.Append("<div class='fr'>");
                strbdt.Append("<a href='" + dg2[4].linkurl + "' target='_blank'>");
                strbdt.Append("<img style='width: 392px; height: 298px' src='" + dg2[4].imgurl + "' alt='' class='block' />");
                strbdt.Append("</a>");
                strbdt.Append("</div>");
                strbdt.Append("</div>");
                #endregion

                #region 3
                strbdt.Append("<div class='d3 clearfix'>");
                strbdt.Append("<div class='fl'>");
                strbdt.Append("<a href='" + dg2[5].linkurl + "' target='_blank' class='fl'>");
                strbdt.Append("<img style='width: 392px; height: 298px' src='" + dg2[5].imgurl + "' alt='' class='block' /></a>");
                strbdt.Append("<a href='" + dg2[6].linkurl + "' target='_blank' class='fr'>");
                strbdt.Append("<img style='width: 392px; height: 298px' src='" + dg2[6].imgurl + "' alt='' class='block' /></a>");
                strbdt.Append("</div>");

                #region 导购查询

                strbdt.Append(strbdtdg.ToString());
                //strbdt.Append("<div class='fr shortcut'>");
                //strbdt.Append("<div class='tit b f16 tc'>");
                //strbdt.Append("<i></i>商家活动查询</div>");
                //strbdt.Append("<dl>");
                //strbdt.Append("    <dt><a href='#' target='_blank'>卖场</a></dt>");
                //strbdt.Append("    <dd>");


                ////前4个卖场
                //for (int mcindex = 0; mcindex <  bm.marketlist.Count; mcindex++)
                //{
                //    if(mcindex<4)
                //        strbdt.Append("    <a href='/guide.aspx?mid=" + bm.marketlist[mcindex].id + "' target='_blank'>" + bm.marketlist[mcindex].title + "</a>");
                //}
                //strbdt.Append("    <a href='/guide.aspx' target='_blank' class='a0' >更多</a>");

                //strbdt.Append("    </dd>");
                //strbdt.Append("</dl>");

                //strbdt.Append("<dl>");
                //strbdt.Append("    <dt><a href='#' target='_blank'>品牌</a></dt>");
                //strbdt.Append("    <dd>");
                ////前4个品牌
                //for (int ppindex = 0; ppindex < bm.brandlist.Count; ppindex++)
                //{
                //    if (ppindex < 11)
                //        strbdt.Append("    <a href='/guide.aspx?bid=" + bm.brandlist[ppindex].id + "' target='_blank'>" + bm.brandlist[ppindex].title + "</a>");
                //}
                //strbdt.Append("     <a href='guide.aspx' target='_blank' class='a0' >更多</a>");
                //strbdt.Append("    </dd>");
                //strbdt.Append("</dl>");
                //strbdt.Append("<dl>");
                //strbdt.Append("    <dt><a href='#' target='_blank'>厂商</a></dt>");
                //strbdt.Append("    <dd>");

                ////前四个厂商
                // for (int cindex = 0; cindex < bm.companylist.Count; cindex++)
                //{
                //    if (cindex < 4)//改为id查询?
                //        strbdt.Append("	<a href='##' onclick='javascript:var d =escape('" + bm.companylist[cindex].title + "');this.href='/guide.aspx?cid='+d;' target='_blank'>" + bm.companylist[cindex].title + "</a>");

                // }
                ////strbdt.Append("	<a href='##' onclick='javascript:var d =escape('<%=items.title %>');this.href='guide.aspx?cid='+d;' target='_blank'><%=items.title%></a>");

                //strbdt.Append("	<a href='guide.aspx' target='_blank' class='a0' >更多</a>");
                //strbdt.Append("    </dd>");
                //strbdt.Append("</dl>");
                //strbdt.Append("<a href='/guide.aspx' class='block shortcut-more b f16 tc'>更多查询条件</a>");
                //strbdt.Append("</div>");
                #endregion

                strbdt.Append("</div>");
                #endregion

                strbdt.Append("</div>");//div4 end
                strbdt.Append("</div>");//div3 end
                strbdt.Append("</div>");//div2 end
                strbdt.Append("</div>");//div1 end

                //循环子类广告

            }

            #endregion

            //首页淘宝贝
            DataSet ds = TREC.ECommerce.ECAdvertisement.TBBSearch(0, 0);
            DataTable dt = ds.Tables[0];

            string dtitles = "";



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtitles += dt.Rows[i]["dtitle"].ToString() + ",";
            }

            //淘宝贝大类别
            string[] npt = TRECommon.StringOperation.RemoveSame(dtitles, ",").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            #region

            //添加大类别
            for (int i = 0; i < npt.Length; i++)
            {
                if (i == 0)
                    tbbdl = "<li class='on'>" + npt[i] + "</li>";
                else
                    tbbdl += "<li>" + npt[i] + "</li>";
            }


            string xlbr = "";

            tbbxlxq = "";
            tbbxlxq2 = "";
            int itemindex = 0;

            int did = 0;


            #region
            List<t_advertising> listtbb = listt_advertising.Where(x => x.tgtitle == "页面-淘宝贝左边广告图").ToList();
            List<t_advertising> listtbbtemp;
            #endregion

            foreach (string item in npt)
            {
                xlb = "";
                xlbr = "";
                tbbxlxq = "";
                string xlbttemp = "";
                #region

                DataTable dtr = ds.Tables[1];

                DataTable tempdt = dtr.Clone();

                tempdt.Clear();

                //详情表中该大类下的小类
                tempdt = dtr.Select(" dtitle='" + item + "' ").CopyToDataTable();

                #region

                foreach (DataRow row in dt.Rows)
                {
                    if (row["dtitle"].ToString() == item)
                    {
                        did = Convert.ToInt32(row["did"]);
                        //查询小类型数量
                        DataRow[] rs = dtr.Select("  xtitle = '" + row["xtitle"].ToString() + "'");
                        //xlb += "<span><a target='_blank' href='/productlisttbb.aspx?did=" + row["did"].ToString() + "&xid=" + row["xid"].ToString() + "'>" + row["xtitle"].ToString() + "(" + rs.Length.ToString() + ")</a></span>";

                        xlb += "<span><a href='###' onclick='getdid(" + row["did"].ToString() + "," + row["xid"].ToString() + ");' >" + row["xtitle"].ToString() + "(" + rs.Length.ToString() + ")</a></span>";
                    }
                }
                string imgname = "ktxl.png";
                if (item.Contains("餐厅"))
                {
                    imgname = "ctxl.png";
                }
                else if (item.Contains("书房"))
                {
                    imgname = "sfxl.png";
                }
                else if (item.Contains("卧室"))
                {
                    imgname = "wsxl.png";
                }
                else if (item.Contains("儿童"))
                {
                    imgname = "etxl.png";
                }
                else
                    imgname = "ktxl.png";


                xlb = "<div class='focus fl focus-change pb10' style='  margin-bottom:9px;'>" +
                "<div class='tit'>" +
                "<a href='#'><img style='width:118px;height:29px;' src='../../../resource/content/img/index/" + imgname + "' alt='' /></a>" +
                "</div>" +
                "<div class='links clearfix mb10'>" +
                xlb +
                "</div>" +
                "<a href='###' class='block f14 b focus-choose' id='hrefdid" + did + "' onclick='getdid(" + did + ",0);' >没中意？ 换一批淘一淘</a></div>";

                listtbbtemp = listtbb.FindAll(x => x.adcode == did.ToString()).Take(2).ToList();

                if (listtbbtemp.Count == 2)
                    xlb += "<br />" +
                        "<div class='focus fl' style='margin-top:9px; margin-bottom:9px;'>" +
                        "<a href='" + listtbbtemp[0].linkurl + "' target='_blank'><img style='width:265px;height:326px' rid='" + listtbbtemp[0].id + "' src='" + listtbbtemp[0].imgurl + "' alt=''></a>" +
                        "</div>" +
                        "<br />" +
                        "<div class='focus fl' style='margin-top:9px; ' >" +
                        "<a href='" + listtbbtemp[1].linkurl + "' target='_blank'><img src='" + listtbbtemp[1].imgurl + "' rid='" + listtbbtemp[1].id + "' alt='' style='width:265px;height:326px'></a>" +
                        "</div>";
                else if (listtbbtemp.Count == 1)
                    xlb += "<br />" +
                   "<div class='focus fl' style='margin-top:9px; margin-bottom:9px;'>" +
                   "<a href='" + listtbbtemp[0].linkurl + "' target='_blank'><img style='width:265px;height:326px' rid='" + listtbbtemp[0].id + "' src='" + listtbbtemp[0].imgurl + "' alt=''></a>" +
                   "</div>" +
                   "<br />" +
                   "<div class='focus fl' style='margin-top:9px; ' >" +
                   "<a href='" + listtbbtemp[0].linkurl + "' target='_blank'><img src='" + listtbbtemp[0].imgurl + "' rid='" + listtbbtemp[0].id + "' alt='' style='width:265px;height:326px'></a>" +
                   "</div>";
                else
                    xlb += "<br />" +
                   "<div class='focus fl' style='margin-top:9px; margin-bottom:9px;'>" +
                   "<a href='#' target='_blank'><img style='width:265px;height:326px' src='#' alt='' rid='0'></a>" +
                   "</div>" +
                   "<br />" +
                   "<div class='focus fl' style='margin-top:9px; ' >" +
                   "<a href='#' target='_blank'><img src='#' alt=''></a>" +
                   "</div>";
                #endregion




                xlbr = "";

                //
                //int[] rowid = GetRandomSequence2(tempdt.Rows.Count);


                #region 随机获取淘宝贝里12个产品,不足十二位以0补足

                int acount = (tempdt.Rows.Count < 12) ? tempdt.Rows.Count : 12;
                int[] rowid = new int[acount];
                //= TRECommon.StringOperation.differSamenessRandomNum((tempdt.Rows.Count < 12) ? tempdt.Rows.Count : 12, 0, tempdt.Rows.Count);

                for (int k = 0; k < acount; k++)
                {
                    rowid[k] = k;
                }
                int[] row1 = new int[4] { 0, 1, 2, 3 };
                int[] row2 = new int[4] { 4, 5, 6, 7 };
                int[] row3 = new int[4] { 8, 9, 10, 11 };

                List<int> alist = rowid.ToList();

                if (alist.Count < 12)
                {
                    int c = 12 - alist.Count;
                    //for (int i = 0; i < c; i++)
                    //{
                    //    alist.Add(0);
                    //}
                    for (int i = 0; i < c; i++)
                    {
                        DataRow row = tempdt.NewRow();
                        #region

                        //DataRow dr = tempdt.Rows[0];
                        //dr["rowNum"] = -1;
                        // tempdt.Rows.Add(dr.ItemArray);

                        row["brandid"] = "-1";
                        row["ptitle"] = "-1";
                        row["materialname"] = "-1";
                        row["storage"] = "-1";
                        row["logo"] = "-1";
                        row["buyprice"] = "-1";
                        row["markprice"] = "-1";
                        row["saleprice"] = "-1";
                        row["thumb"] = "-1";
                        row["proid"] = "-1";
                        row["id"] = "-1";
                        row["xtitle"] = "-1";
                        row["dtitle"] = "-1";
                        row["did"] = "-1";
                        row["xid"] = "-1";
                        row["rowNum"] = "-1";
                        tempdt.Rows.Add(row);
                        #endregion
                    }
                }

                //for (int rowindex = 0; rowindex < 4; rowindex++)
                //{
                //    row1[rowindex] = alist[rowindex];
                //    row2[rowindex] = alist[rowindex + 4];
                //    row3[rowindex] = alist[rowindex + 8];
                //}

                #endregion

                xlbttemp = "";
                #region
                //1-4
                foreach (int index in row1)
                {
                    DataRow dr = tempdt.Rows[index];

                    #region


                    if (Convert.ToInt32(dr["rowNum"]) == -1)
                    {
                        xlbttemp += "<li>" +
                         "<div class='d1'>" +
                         "  <a href='#' target='_blank'><img    src='/resource/content/images/nopic.jpg' /></a>" +
                         "</div>" +
                         "<div class='d2 b'><a href='#' target='_blank'></a></div>" +
                         "<div class='d3'></div>" +
                         "<div class='d4 clearfix'>" +
                         "  <div class='price fl yahei'>" +
                         "      <p class='p1'></p>" +
                         "      <p class='p2'></p>" +
                         "  </div>" +
                         "  <div class='btn fr'>" +
                         "      <a href='' class='block'></a>" +
                         "  </div>" +
                         "</div>" +
                         "<div class='d5'>" +
                         "" +
                         "</div>" +
                         "</li>";
                    }
                    else
                    {
                        double qcj = 0;
                        double.TryParse(dr["buyprice"].ToString(), out qcj);
                        string qcjstr = qcj > 0 ? "清仓价：￥" + dr["buyprice"].ToString() : "&nbsp;";
                        xlbttemp += "<li>" +
                             "<div class='d1'>" +
                             "<a href='product/" + dr["proid"].ToString() + "/info.aspx' target='_blank'  style='height:195px;width:210px;'><img  src='upload/product/thumb/" + dr["proid"].ToString() + "/" + dr["thumb"].ToString().Replace(",", "").Replace(".", "_230-173.") + "' /></a>" +
                             "</div>" +
                             "<div class='d2 b'>" +
                             "<a href='product/" + dr["proid"].ToString() + "/info.aspx' target='_blank' title='" + dr["ptitle"].ToString() + "' >" +
                             StringOperation.CutString(dr["ptitle"].ToString(), 0, 18) + "</a></div>" +
                             "<div class='d3'>" + dr["materialname"].ToString() + "</div>" +
                             "<div class='d4 clearfix'>" +
                             "<div class='price fl yahei'>" +

                             "<p class='p1'>" + qcjstr + "</p>" +
                           
                             "<p class='p2'>库存：" + dr["storage"].ToString() + "</p>" +
                             "</div>" +
                             "<div class='btn fr'>" +
                             "<a href='javascript:;' onclick=\"addBAOMING(" + dr["id"] + ",'" + Server.UrlEncode(dr["ptitle"].ToString()) + "'," + dr["proid"].ToString() + ")\" class='block'>立即抢购</a>" +
                             "</div>" +
                             "</div>" +
                             "<div class='d5'>" +
                             "" +
                             "</div>" +
                             "</li>";
                    }
                    #endregion

                }

                xlbr = "<div class='list fr' style='margin-top: 0px; float:right' >" +
                      "<ul class='clearfix'>" + xlbttemp +
                      "</ul></div>";

                xlbttemp = "";
                //5-8
                foreach (int index in row2)
                {
                    DataRow dr = tempdt.Rows[index];
                    #region
                    if (Convert.ToInt32(dr["rowNum"]) == -1)
                    {
                        xlbttemp += "<li>" +
                               "<div class='d1'>" +
                               "<a href='###' target='_blank'><img    src='/resource/content/images/nopic.jpg' /></a>" +
                               "</div>" +
                               "<div class='d2 b'>" +
                               "<a href='#' target='_blank'></a></div>" +
                               "<div class='d3'></div>" +
                               "<div class='d4 clearfix'>" +
                               "<div class='price fl yahei'>" +
                               "<p class='p1'></p>" +
                               "<p class='p2'></p>" +
                               "</div>" +
                               "<div class='btn fr'>" +
                               "<a href=''   class='block'></a>" +
                               "</div>" +
                               "</div>" +
                               "<div class='d5'>" +
                               "" +
                               " </div>" +
                               "</li>";
                    }
                    else
                    {
                        string qcj2 = SubmitMeth.getdouble(dr["buyprice"].ToString()) > 0 ? "<p class='p1'>清仓价：￥" + dr["buyprice"].ToString() + "</p>" : "<p class='p1'></p>"; 
                        xlbttemp += "<li>" +
                             "<div class='d1'>" +
                             "<a href='product/" + dr["proid"].ToString() + "/info.aspx' target='_blank'  style='height:195px;width:210px;'><img  src='upload/product/thumb/" + dr["proid"].ToString() + "/" + dr["thumb"].ToString().Replace(",", "").Replace(".", "_230-173.") + "' /></a>" +
                             "</div>" +
                             "<div class='d2 b'>" +
                             "<a href='product/" + dr["proid"].ToString() + "/info.aspx' target='_blank' title='" + dr["ptitle"].ToString() + "' >" +
                             StringOperation.CutString(dr["ptitle"].ToString(), 0, 18) + "</a></div>" +
                             "<div class='d3'>" + dr["materialname"].ToString() + "</div>" +
                             "<div class='d4 clearfix'>" +
                             "<div class='price fl yahei'>" +

                         qcj2 +
                             "<p class='p2'>库存：" + dr["storage"].ToString() + "</p>" +
                             "</div>" +
                             "<div class='btn fr'>" +
                             "<a href='javascript:;' onclick=\"addBAOMING(" + dr["id"] + ",'" + Server.UrlEncode(dr["ptitle"].ToString()) + "'," + dr["proid"].ToString() + ")\" class='block'>立即抢购</a>" +
                             "</div>" +
                             "</div>" +
                             "<div class='d5' >"+
                             "" +
                             "</div>" +
                             "</li>";
                    }
                    #endregion
                }
                xlbr += "<div class='list fr' style='margin-top: 18px; float:right' >" +
                      "<ul class='clearfix'>" + xlbttemp +
                      "</ul></div>";
                xlbttemp = "";
                //9-12
                foreach (int index in row3)
                {
                    DataRow dr = tempdt.Rows[index];
                    #region
                    if (Convert.ToInt32(dr["rowNum"]) == -1)
                    {
                        xlbttemp += "<li>" +
                              "<div class='d1'>" +
                              "<a href='###'><img    src='/resource/content/images/nopic.jpg' /></a>" +
                              "</div>" +
                              "<div class='d2 b'>" +
                              "<a href='#' target='_blank'></a></div>" +
                              "<div class='d3'></div>" +
                              "<div class='d4 clearfix'>" +
                              "<div class='price fl yahei'>" +
                              "<p class='p1'></p>" +
                              "<p class='p2'></p>" +
                              "</div>" +
                              "<div class='btn fr'>" +
                              "<a href='###'  class='block'></a>" +
                              "</div>" +
                              "</div>" +
                              "<div class='d5'>" +
                              "" +
                              " </div>" +
                              "</li>";
                    }
                    else
                    {
                        string qcj2 = SubmitMeth.getdouble(dr["buyprice"].ToString()) > 0 ? "<p class='p1'>清仓价：￥" + dr["buyprice"].ToString() + "</p>" : "<p class='p1'></p>"; 

                        xlbttemp += "<li>" +
                             "<div class='d1'>" +
                             "<a href='product/" + dr["proid"].ToString() + "/info.aspx' target='_blank'  style='height:195px;width:210px;'><img  src='upload/product/thumb/" + dr["proid"].ToString() + "/" + dr["thumb"].ToString().Replace(",", "").Replace(".", "_230-173.") + "' /></a>" +
                             "</div>" +
                             "<div class='d2 b'>" +
                             "<a href='product/" + dr["proid"].ToString() + "/info.aspx' target='_blank' title='" + dr["ptitle"].ToString() + "' >" +
                             StringOperation.CutString(dr["ptitle"].ToString(), 0, 18) + "</a></div>" +
                             "<div class='d3'>" + dr["materialname"].ToString() + "</div>" +
                             "<div class='d4 clearfix'>" +
                             "<div class='price fl yahei'>" +
                            qcj2+
                             "<p class='p2'>库存：" + dr["storage"].ToString() + "</p>" +
                             "</div>" +
                             "<div class='btn fr'>" +
                             "<a href='javascript:;' onclick=\"addBAOMING(" + dr["id"] + ",'" + Server.UrlEncode(dr["ptitle"].ToString()) + "'," + dr["proid"].ToString() + ")\" class='block'>立即抢购</a>" +
                             "</div>" +
                             "</div>" +
                             "<div class='d5'>" +
                             "" +
                             "</div>" +
                             "</li>";
                    }
                    #endregion
                }
                #endregion

                xlbr += "<div class='list fr' style='margin-top: 18px; float:right' >" +
                        "<ul class='clearfix'>" + xlbttemp +
                        "</ul></div>";



                if (itemindex == 0)
                {
                    tbbxlxq = "<div class='item'>" +
                            "<table border='0' style='background-color:#F2F2F2;;vertical-align:top;margin:0 auto; width:1180px;' align='center' cellpadding='0px' >" +
                            "<tr>" +
                            "<td valign='top' style='vertical-align: top;' >" + xlb +
                            "</td>" +
                            "<td style='vertical-align: top;'>" +
                            "<div style='margin-top:0px; margin-bottom:0px; float:right' id='divinfo" + did + "' >" + xlbr +
                            "</div>" +
                            "</td></tr></table></div>";
                }
                else
                {
                    tbbxlxq = "<div class='item hide'>" +
                            "<table border='0' style='background-color:#F2F2F2;;vertical-align:top;margin:0 auto; width:1180px;' align='center' cellpadding='0px' >" +
                            "<tr>" +
                            "<td valign='top' style='vertical-align: top;' >" + xlb +
                            "</td>" +
                            "<td style='vertical-align: top;'>" +
                            "<div style='margin-top:0px; margin-bottom:0px; float:right' id='divinfo" + did + "' >" + xlbr +
                            "</div>" +
                            " </td></tr></table></div>";
                }

                itemindex = 1;

                tbbxlxq2 += tbbxlxq;

                #endregion


            }

            string s = tbbxlxq2;


            #endregion


            #endregion

            #region
            List<t_advertising> listmc = listt_advertising.Where(x => x.categoryid == 47).ToList();//首页-逛卖场图片
            List<t_advertising> listmc2 = listt_advertising.Where(x => x.categoryid == 48).ToList();//首页-逛卖场轮播图片

            //取出adcode
            string areas = "";
            foreach (t_advertising item in listmc2)
            {
                areas += item.adcode + ",";
            }

            areas = TRECommon.StringOperation.RemoveSame(areas, ",");
            DataTable dtarea = TREC.ECommerce.ECommerce.GetTable("SELECT areaname,areacode FROM t_area WHERE areacode IN (" + areas + ") ORDER BY sort ASC  ");


            DataRow drarea;
            for (int i = 0; i < dtarea.Rows.Count; i++)
            {
                drarea = dtarea.Rows[i];
                strb.Append(" <li>" + drarea["areaname"] + "</li>");
                //if (i == 0)
                //{
                //    strb.Append(" <li class='on'>" + drarea["areaname"] + "</li>");
                //}
                //else
                //{
                //    strb.Append(" <li>" + drarea["areaname"] + "</li>");
                //}


                List<t_advertising> t1 = listmc.FindAll(x => x.adcode == drarea["areacode"].ToString());
                List<t_advertising> t2 = listmc2.FindAll(x => x.adcode == drarea["areacode"].ToString());
                if (i == 0)
                    builder.Append("  <div class='item'>");
                else
                    builder.Append("  <div class='item hide'>");

                builder.Append("    <div class='d1 clearfix mb5'>");
                builder.Append("	<div class='focus fl'>");
                builder.Append("	    <a href='" + t1[0].linkurl + "' target='_blank'>");
                builder.Append("		<img src='" + (t1.Count > 0 ? t1[0].imgurl : "") + "' alt='' class='block' />");
                builder.Append("		<img src='../../../resource/content/img/index/h1.png' alt='' class='trim block' />");
                builder.Append("	    </a>");
                builder.Append("	</div>");
                builder.Append("	<div style='float: right;' id='navindex_" + i + "'>");

                builder.Append("	    <!--切换广告-->");

                builder.Append("<div class='yx-rotaion'><ul class='rotaion_list'>");

                foreach (t_advertising adv in t2)
                {
                    builder.Append("<li><a href='" + adv.linkurl + "'  ><img  border='0'  src='" + adv.imgurl + "' style='width:760px;height:325px;' /></a></li>");
                }

                builder.Append("</ul></div>");
                builder.Append("	    <!--切换广告-->");

                builder.Append("	</div>");
                builder.Append("    </div>");
                builder.Append("    <div class='d2 w'>");
                builder.Append("	<ul class='clearfix'>");
                builder.Append("	    <li><a href='" + t1[1].linkurl + "' target='_blank'>");
                builder.Append("		<img src='" + (t1.Count > 1 ? t1[1].imgurl : "") + "' alt='' />");
                builder.Append("	    </a></li>");
                builder.Append("	    <li><a href='" + t1[2].linkurl + "' target='_blank'>");
                builder.Append("		<img src='" + (t1.Count > 2 ? t1[2].imgurl : "") + "' alt='' />");
                builder.Append("	    </a></li>");
                builder.Append("	    <li><a href='" + t1[3].linkurl + "' target='_blank'>");
                builder.Append("		<img src='" + (t1.Count > 3 ? t1[3].imgurl : "") + "' alt='' />");
                builder.Append("	    </a></li>");
                builder.Append("	    <li><a href='" + t1[4].linkurl + "' target='_blank'>");
                builder.Append("		<img src='" + (t1.Count > 4 ? t1[4].imgurl : "") + "' alt='' />");
                builder.Append("	    </a></li>");
                builder.Append("	</ul>");
                builder.Append("    </div>");
                builder.Append("</div>");

            }
            #endregion

        }
        /// <summary>

        /// Designed by eaglet

        /// </summary>

        /// <param name="total"></param>

        /// <returns></returns>

        public int[] GetRandomSequence2(int total)
        {



            int[] sequence = new int[total];

            int[] output = new int[total];



            for (int i = 0; i < total; i++)
            {

                sequence[i] = i;

            }



            Random random = new Random();



            int end = total - 1;



            for (int i = 0; i < total; i++)
            {

                int num = random.Next(0, end + 1);

                output[i] = sequence[num];

                sequence[num] = sequence[end];

                end--;

            }
            return output;

        }
        /// <summary>
        /// 新闻信息类
        /// </summary>
        protected class NewsInfo : Haojibiz.Model.Mnews
        {
            public int companyid { get; set; }
            public string companytitle { get; set; }
        }

        protected global::System.Web.UI.WebControls.Repeater Repeater_brand2;
        protected global::System.Web.UI.WebControls.Repeater Repeater_brand3;
        protected global::System.Web.UI.WebControls.Repeater Repeater_brand4;
        protected global::System.Web.UI.WebControls.Repeater Repeater_brand5;
        protected global::System.Web.UI.WebControls.Repeater Repeater_brand6;
        protected global::System.Web.UI.WebControls.Repeater Repeater_brand7;
        protected global::System.Web.UI.WebControls.Repeater Repeater_brand8;
        protected global::System.Web.UI.WebControls.Repeater Repeater_brand9;
        protected global::System.Web.UI.WebControls.Repeater Repeater_brand10;
        protected global::System.Web.UI.WebControls.Repeater Repeater_brand11;
        protected global::System.Web.UI.WebControls.Repeater Repeater_brand12;
        protected global::System.Web.UI.WebControls.Repeater Repeater_brand13;
        protected global::System.Web.UI.WebControls.Repeater Repeater_brand14;
        
        protected global::System.Web.UI.WebControls.Repeater Repeater_gd;
        protected global::System.Web.UI.WebControls.Repeater Repeater_brandmarket;
    }
}