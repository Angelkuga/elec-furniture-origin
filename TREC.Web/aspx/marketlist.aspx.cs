using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;

namespace TREC.Web.aspx
{
    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    using System.Text;
    using System.Data;
    #endregion

    public partial class marketlist : WebPageBase
    {
        /// <summary>
        /// 下一页连接
        /// </summary>
        public string NextUrl
        {
            get
            {
                if (ECommon.QueryPageIndex == AspNetPager1.PageCount)
                {
                    return "#";

                }
                else
                {
                    string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    return string.Format(EnUrls.MarketListSearch, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1, ECommon.QuerySearchArea);
                }
            }
        }

        //上一页连接
        public string PrvUrl
        {
            get
            {
                if (ECommon.QueryPageIndex == 1)
                {
                    return "#";

                }
                else
                {
                    string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    return string.Format(EnUrls.MarketListSearch, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex - 1, ECommon.QuerySearchArea);
                }
            }
        }

        //优质商家
        public string shangjia = "";
        public string adv = "";
        public string sortTitle = "按&nbsp;名&nbsp;称";
        public string sortDate = "按&nbsp;时&nbsp;间";
        public string sortHot = "推荐店铺";
        private string hot = "http://www.jiajuks.com";

        public string getImg(string path, object imgcolumn)
        {
            if (imgcolumn == null)
            {
                return path.Replace(",","");
            }
            else
            {
                if (imgcolumn.ToString().ToLower().Contains("http://"))
                {
                    return imgcolumn.ToString().Replace(",", "");
                }
                else
                {
                    return path.Replace(",", "");
                }
            }
        }
        #region 集团数据展示
        /// <summary>
        /// 集团数据展示
        /// </summary>
        public string MarketCliqueShow = string.Empty;

        /// <summary>
        /// 是否需要展示地址
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private string isShowurl(string url, string id)
        {
            if (id == "4")
            {
                return url;
            }
            else
            {
                return "javascript:void(0);";
            }
        }
        private string getMarketCstrHide(DataTable dt)
        {
            List<EnMarket> listCom;
            StringBuilder _value = new StringBuilder(string.Empty);
            foreach (DataRow r in dt.Rows)
            {
                string jsclick = "";
                string target = "";
                int c = Int32.Parse(r["c"].ToString());
                listCom = new List<EnMarket>();
                int getc;
                listCom = ECMarket.GetMarketList(1, 20, "   MarketCliqueName='" + r["title"].ToString().Replace("集团", "") + "' and  auditstatus = 1 and linestatus = 1 ", out getc).OrderBy(p=>p.id).ToList();
                //ECMarket.GetMarketList(ECommon.QueryPageIndex, 20, " and  MarketCliqueName='" + r["title"].ToString().Replace("集团", "") + "' ", out tmpPageCount);
                if (r["id"].ToString() == "4")
                {
                   
                    target = "target='_blank'";
                }
                else
                {
                    jsclick = "onclick=\"messagedshow(event)\"";
                }
                //if (c >= 5)
                //{
                    //_value.Append("<div class=\"mainmc\"  " + jsclick + ">");
                    //_value.Append("<div class=\"mainmcz\">");
                    //_value.Append("<div class=\"mainmcz1\">");
                    //_value.Append("<a href='" + isShowurl("/market/marketclique.aspx?id=" + r["Id"].ToString(), r["Id"].ToString()) + "' "+  target +"><img width=\"218\" height=\"67\" src=\"" + r["LogImg"].ToString().Split(',')[0] + "\"  border='0'></a> ");
                    //_value.Append("<span>" + r["Title"].ToString() + "集团</span><br>");
                    //_value.Append("地址：<a href='#' title='" + r["address"].ToString().Split(',')[0].Replace("市辖区", "") + "'>" + SubmitMeth.bSubstring(r["address"].ToString().Replace("市辖区", ""), 24) + "</a><br>");
                    //_value.Append("电话：" + r["phone"].ToString() + " </div>");
                    //_value.Append("<div class=\"mainmcz2\">");
                    //_value.Append("<a href='" + isShowurl("/market/marketclique.aspx?id=" + r["Id"].ToString(), r["Id"].ToString()) + "' "+  target +"><img width=\"447\" height=\"199\" src=\"" + r["thumbimg"].ToString().Split(',')[0] + "\" border='0'></a><br>");
                    //_value.Append("<span>集团简介</span><br>");
                    //_value.Append("" + SubmitMeth.bSubstring(SubmitMeth.DisposeHtml(r["Descript"].ToString()), 240) + " </div></div>");
                    //_value.Append("<div class=\"mainmcy\">");
                    //_value.Append("<h1>旗下卖场</h1>");
                    //_value.Append("<input type=\"hidden\" value=\"" + listCom.Count.ToString() + "\" id=\"funcount"+r["id"].ToString()+"\"/>");
                    //int i = 0;
                    //string zindex = string.Empty;

                    //foreach (EnMarket en in listCom)
                    //{
                    //    i++;
                    //    if (i == 0)
                    //    {
                    //        zindex = "500";
                    //    }
                    //    else
                    //    {
                    //        zindex = "0";
                    //    }
                    //    //if (i <= 6)
                    //    //{
                    //        string iphone = string.IsNullOrEmpty(en.lphone) ? "" : " 电话：" + en.lphone;
                    //        _value.Append("<div style=\"position:relative;overflow:hidden;width:435px;height:260px;\">");
                    //        _value.Append("<div class=\"mainmcp\" style=\"position:absolute;z-index:" + zindex + ";\" id=\"divid_" + r["id"].ToString()+"_"+en.id+ "\">");
                    //        _value.Append("<a href=\"" + isShowurl("/market/" + en.id + "/index.aspx", r["Id"].ToString()) + "\" "+  target +"><img width=\"209\" height=\"94\" src=\"" + getImg(hot + "/upload/market/surface/" + en.id + "/" + en.surface, en.surface) + "\"></a>");
                    //        _value.Append("<div class=\"mainmcp1\"><a href=\"" + isShowurl("/market/" + en.id + "/about.aspx", r["Id"].ToString()) + "\" "+  target +">卖场介绍</a> <a href=\"" + isShowurl("/market/" + en.id + "/index.aspx", r["Id"].ToString()) + "\" "+  target +">卖场品牌</a><a href=\"" + isShowurl("/market/" + en.id + "/product.aspx", r["Id"].ToString()) + "\" "+  target +">卖场产品</a></div>");
                    //        _value.Append("<div class=\"mainmcp2\">" + en.title + "</div>");
                    //        _value.Append("<div class=\"mainmcp3\" title='" + en.address.Replace(" ", "").Replace("市辖区", "") + iphone + "'>" + SubmitMeth.bSubstring(en.address.Replace(" ", "").Replace("市辖区", ""), 30) + "</div></div>");
                    //        _value.Append("</div>");
                    //   // }
                    //}

                    //_value.Append("</div></div>");

                //}
                //else if (c > 2 && c <= 4)
                //{
                //    _value.Append("<div class=\"mainmc\"  " + jsclick + ">");
                //    _value.Append("<div class=\"mainmcz\">");
                //    _value.Append("<div class=\"mainmcz1\">");
                //    _value.Append("<a href='" + isShowurl("/market/marketclique.aspx?id=" + r["Id"].ToString(), r["Id"].ToString()) + "' "+  target +"><img width=\"218\" height=\"67\"  src=\"" + r["LogImg"].ToString().Split(',')[0] + "\"  border='0'></a>");
                //    _value.Append("<span>" + r["Title"].ToString() + "集团</span><br>地址：<a href='#' title='" + r["address"].ToString().Split(',')[0].Replace("市辖区", "") + "'>" + SubmitMeth.bSubstring(r["address"].ToString().Split(',')[0].Replace("市辖区", ""), 24) + "</a><br>");
                //    _value.Append(" 电话：" + r["phone"].ToString() + " </div>");
                //    _value.Append(" <div class=\"mainmcz2 mainmcz2z \">");
                //    _value.Append("<a href='" + isShowurl("/market/marketclique.aspx?id=" + r["Id"].ToString(), r["Id"].ToString()) + "' "+  target +"><img width=\"447\" height=\"199\"  src=\"" + r["thumbimg"].ToString().Split(',')[0] + "\" border='0'></a>");
                //    _value.Append(" <span>集团简介</span><br>");
                //    _value.Append("" + SubmitMeth.bSubstring(SubmitMeth.DisposeHtml(r["Descript"].ToString()), 240) + "</div></div>");
                //    _value.Append("<div class=\"mainmcy\">");
                //    _value.Append("<h1>旗下卖场</h1>");
                //    int i = 0;
                //    foreach (EnMarket en in listCom)
                //    {
                //        i++;
                //        if (i <= 4)
                //        {
                //            string iphone = string.IsNullOrEmpty(en.lphone) ? "" : " 电话：" + en.lphone;
                //            _value.Append("<div class=\"mainmcp\">");
                //            _value.Append("<a href=\"" + isShowurl("/market/" + en.id + "/index.aspx", r["Id"].ToString()) + "\" "+  target +"><img width=\"209\" height=\"94\" src=\"" + getImg(hot + "/upload/market/surface/" + en.id + "/" + en.surface, en.surface) + "\"></a>");
                //            _value.Append("<div class=\"mainmcp1\"><a href=\"" + isShowurl("/market/" + en.id + "/about.aspx", r["Id"].ToString()) + "\" "+  target +"></a><a href=\"" + isShowurl("/market/" + en.id + "/about.aspx", r["Id"].ToString()) + "\" "+  target +">卖场介绍</a> <a href=\"" + isShowurl("/market/" + en.id + "/index.aspx", r["Id"].ToString()) + "\" "+  target +">卖场品牌</a><a href=\"" + isShowurl("/market/" + en.id + "/product.aspx", "") + "\" "+  target +">卖场产品</a></div>");
                //            _value.Append("<div class=\"mainmcp2\">" + en.title + "</div> <div class=\"mainmcp3\" title='" + en.address.Replace(" ", "").Replace("市辖区", "") + iphone + "'>" + SubmitMeth.bSubstring(en.address.Replace(" ", "").Replace("市辖区", ""), 28) + "</div> </div>");
                //        }
                //    }

                //    _value.Append("</div></div>");

                //}
                //else if (c > 1 && c <= 2)
                //{
                //    _value.Append("<div class=\"mainmc\" " + jsclick + " >");
                //    _value.Append("<div class=\"mainmcz\">");
                //    _value.Append("<div class=\"mainmcz1\">");
                //    _value.Append("<a href='" + isShowurl("/market/marketclique.aspx?id=" + r["Id"].ToString(), r["Id"].ToString()) + "' "+  target +"><img width=\"218\" height=\"67\"   src=\"" + r["LogImg"].ToString().Split(',')[0] + "\" border='0'></a>");
                //    _value.Append("<span>" + r["Title"].ToString() + "集团</span><br>");
                //    _value.Append(" 地址：<a href='#' title='" + r["address"].ToString().Split(',')[0].Replace("市辖区", "") + "'>" + SubmitMeth.bSubstring(r["address"].ToString().Replace("市辖区", ""), 24) + "</a><br>");
                //    _value.Append("电话：" + r["phone"].ToString() + " </div>");
                //    _value.Append("<div class=\"mainmcz2 mainmcz2z \">");
                //    _value.Append("<a href='" + isShowurl("/market/marketclique.aspx?id=" + r["Id"].ToString(), r["Id"].ToString()) + "' "+  target +"><img width=\"447\" height=\"199\"  src=\"" + r["thumbimg"].ToString().Split(',')[0] + "\" border='0'></a> ");
                //    _value.Append("<span>集团简介</span><br>");
                //    _value.Append("" + SubmitMeth.bSubstring(SubmitMeth.DisposeHtml(r["Descript"].ToString()), 210) + "</div></div>");
                //    _value.Append("<div class=\"mainmcy\"><h1>旗下卖场</h1>");

                //    int i = 0;
                //    foreach (EnMarket en in listCom)
                //    {
                //        i++;
                //        if (i <= 2)
                //        {
                //            string iphone = string.IsNullOrEmpty(en.lphone) ? "" : " 电话：" + en.lphone;
                //            _value.Append("<div class=\"mainmcp mainmcpp\">");
                //            _value.Append("<a href=\"" + isShowurl("/market/" + en.id + "/index.aspx", r["Id"].ToString()) + "\" "+  target +"><img width=\"209\" height=\"94\"  src=\"" + getImg(hot + "/upload/market/surface/" + en.id + "/" + en.surface, en.surface) + "\"></a>");
                //            _value.Append("<div class=\"mainmcp1\"><a href=\"" + isShowurl("/market/" + en.id + "/about.aspx", r["Id"].ToString()) + "\" "+  target +">卖场介绍</a> <a href=\"" + isShowurl("/market/" + en.id + "/index.aspx", r["Id"].ToString()) + "\" "+  target +">卖场品牌</a><a href=\"" + isShowurl("/market/" + en.id + "/product.aspx", r["Id"].ToString()) + "\" "+  target +">卖场产品</a></div>");
                //            _value.Append("<div class=\"mainmcp2 mainmcp22\">" + SubmitMeth.bSubstring(en.title, 28) + "</div>");
                //            _value.Append("<div class=\"mainmcp3\" title='" + en.address.Replace(" ", "").Replace("市辖区", "") + iphone + "'>" + SubmitMeth.bSubstring(en.address.Replace(" ", "").Replace("市辖区", ""), 28) + "</div></div>");
                //        }
                //    }

                //    _value.Append("</div></div>");

                //}
                //else if (c == 1)
                //{
                    _value.Append("<div class=\"mainmc\" >");
                    _value.Append("<div class=\"mainmcz\" " + jsclick + ">");
                    _value.Append(" <div class=\"mainmcz1\">");
                    _value.Append("<a href='" + isShowurl("/market/marketclique.aspx?id=" + r["Id"].ToString(), r["Id"].ToString()) + "' " + target + "><img width=\"218\" height=\"67\"  src=\"" + r["LogImg"].ToString().Split(',')[0] + "\" border='0'></a> ");
                    _value.Append("<span>" + r["Title"].ToString() + "集团</span><br>");
                    _value.Append(" 地址：<a href='#' title='" + r["address"].ToString().Split(',')[0] + "'>" + SubmitMeth.bSubstring(r["address"].ToString().Replace("市辖区", ""), 24) + "</a> <br>");
                    _value.Append("电话：" + r["phone"].ToString() + " </div>");
                    _value.Append("<div class=\"mainmcz2 mainmcz2z \">");
                    _value.Append("<a href='" + isShowurl("/market/marketclique.aspx?id=" + r["Id"].ToString(), r["Id"].ToString()) + "' " + target + "><img width=\"447\" height=\"199\"   src=\"" + r["thumbimg"].ToString().Split(',')[0] + "\" border='0'></a> ");
                    _value.Append("<span>集团简介</span><br>");
                    _value.Append(SubmitMeth.bSubstring(SubmitMeth.DisposeHtml(r["Descript"].ToString()), 240) + "</div></div>");
                    _value.Append("<div class=\"mainmcy\">");
                    _value.Append("<h1>旗下卖场</h1>");
                    _value.Append("<input type=\"hidden\" value=\"" + listCom.Count.ToString() + "\" id=\"funcount" + r["id"].ToString() + "\"/>");
                    _value.Append("<input type=\"hidden\" value=\"1\" id=\"pageindex" + r["id"].ToString() + "\"/>");
                    int i = 0;
                    _value.Append("<div style=\"position:relative;overflow:hidden;width:440px;height:260px;\">");
                    if (listCom.Count > 1)
                    {
                        _value.Append("<div style=\"position:absolute;z-index:600;left:0px;padding-top:110px;\"><img src='/resource/images/left.jpg' style='cursor:pointer'  onclick=\"funnpra('pageindex" + r["id"].ToString() + "','funcount" + r["id"].ToString() + "','divid_" + r["id"].ToString() + "_" + "')\"></div>");
                        _value.Append("<div style=\"position:absolute;z-index:600;right:0px;padding-top:110px;\"><img src='/resource/images/right.jpg' style='cursor:pointer' onclick=\"funnext('pageindex" + r["id"].ToString() + "','funcount" + r["id"].ToString() + "','divid_" + r["id"].ToString() + "_" + "')\"></div>");
                    }
                    foreach (EnMarket en in listCom)
                    {
                        //if (i == 1)
                        //{
                         string zindex = string.Empty;

                    
                        i++;
                        if (i == 0)
                        {
                            zindex = "500";
                        }
                        else
                        {
                            zindex = "0";
                        }
                            string iphone = string.IsNullOrEmpty(en.lphone) ? "" : " 电话：" + en.lphone;

                            _value.Append("<div class=\"mainmcp mainmcppp\" style=\"position:absolute;z-index:" + zindex + ";\" id=\"divid_" + r["id"].ToString() + "_" + i + "\">");
                            _value.Append("<a href=\"" + isShowurl("/market/" + en.id + "/index.aspx", r["Id"].ToString()) + "\" " + target + "><img width=\"209\" height=\"94\" alt=\"\" src=\"" + getImg(hot + "/upload/market/surface/" + en.id + "/" + en.surface, en.surface) + "\" " + jsclick + "></a>");
                            _value.Append("<div class=\"mainmcp1 mainmcp11\" " + jsclick + "><a href=\"" + isShowurl("/market/" + en.id + "/about.aspx", r["Id"].ToString()) + "\" " + target + ">卖场介绍</a> <a href=\"" + isShowurl("/market/" + en.id + "/index.aspx", r["Id"].ToString()) + "\" " + target + ">卖场品牌</a><a href=\"" + isShowurl("/market/" + en.id + "/product.aspx", r["Id"].ToString()) + "\" " + target + ">卖场产品</a></div>");
                            _value.Append("<div class=\"mainmcp2 mainmcp22\">" + en.title + "</div><div class=\"mainmcp3\" style='background-color:#ffffff;'>" + en.address.Replace("市辖区", "").Replace(" ", "") + iphone + "</div></div>");
                           
                        // }
                    }
                    _value.Append("</div>");
                    _value.Append("</div></div>");

                //}
            }

            return _value.ToString();
        }
        private string getMarketCstr(DataTable dt)
        {
            List<EnMarket> listCom;
            StringBuilder _value=new StringBuilder(string.Empty);
            foreach (DataRow r in dt.Rows)
            {
                int c = Int32.Parse(r["c"].ToString());
                listCom = new List<EnMarket>();
                int getc;
                listCom = ECMarket.GetMarketList(1, 20, "   MarketCliqueName='" + r["title"].ToString().Replace("集团", "") + "' and  auditstatus = 1 and linestatus = 1 ", out getc);
                //ECMarket.GetMarketList(ECommon.QueryPageIndex, 20, " and  MarketCliqueName='" + r["title"].ToString().Replace("集团", "") + "' ", out tmpPageCount);
                if(c>=5)
                {
                    _value.Append("<div class=\"mainmc\">");
                    _value.Append("<div class=\"mainmcz\">");
                    _value.Append("<div class=\"mainmcz1\">");
                    _value.Append("<a href='/market/marketclique.aspx?id=" + r["Id"].ToString() + "'><img width=\"218\" height=\"67\" src=\"" + r["LogImg"].ToString().Split(',')[0] + "\"  border='0'></a> ");
                    _value.Append("<span>" + r["Title"].ToString() + "集团</span><br>");
                    _value.Append("地址：<a href='#' title='" + r["address"].ToString().Split(',')[0].Replace("市辖区", "") + "'>" + SubmitMeth.bSubstring(r["address"].ToString().Replace("市辖区", ""), 24) + "</a><br>");
                    _value.Append("电话：" + r["phone"].ToString() + " </div>");
                    _value.Append("<div class=\"mainmcz2\">");
                    _value.Append("<a href='/market/marketclique.aspx?id=" + r["Id"].ToString() + "'><img width=\"447\" height=\"199\" src=\"" + r["thumbimg"].ToString().Split(',')[0] + "\" border='0'></a><br>");
                    _value.Append("<span>集团简介</span><br>");
                    _value.Append("" + SubmitMeth.bSubstring(SubmitMeth.DisposeHtml(r["Descript"].ToString()), 240) + " </div></div>");
                    _value.Append("<div class=\"mainmcy\">");
                    _value.Append("<h1>旗下卖场</h1>");
                    int i = 0;
                    foreach (EnMarket en in listCom)
                    {
                        i++;
                        if (i <= 6)
                        {
                            string iphone = string.IsNullOrEmpty(en.lphone) ? "" : " 电话：" + en.lphone;
                            _value.Append("<div class=\"mainmcp\" onmousemove=\"messagedshow(event)\">");
                            _value.Append("<a href=\"/market/" + en.id + "/index.aspx\"><img width=\"209\" height=\"94\" src=\"" + getImg(hot + "/upload/market/surface/" + en.id + "/" + en.surface,en.surface) + "\"></a>");
                            _value.Append("<div class=\"mainmcp1\"><a href=\"/market/" + en.id + "/about.aspx\">卖场介绍</a> <a href=\"/market/" + en.id + "/index.aspx\">卖场品牌</a><a href=\"/market/" + en.id + "/product.aspx\">卖场产品</a></div>");
                            _value.Append("<div class=\"mainmcp2\">"+en.title+"</div>");
                            _value.Append("<div class=\"mainmcp3\" title='" + en.address.Replace(" ", "").Replace("市辖区", "")+iphone + "'>" + SubmitMeth.bSubstring(en.address.Replace(" ", "").Replace("市辖区", ""), 30) + "</div></div>");
                        }
                    }

                    _value.Append("</div></div>");

                }
                else if (c >2 && c <= 4)
                {
                    _value.Append("<div class=\"mainmc\">");
                    _value.Append("<div class=\"mainmcz\">");
                    _value.Append("<div class=\"mainmcz1\">");
                    _value.Append("<a href='/market/marketclique.aspx?id=" + r["Id"].ToString() + "'><img width=\"218\" height=\"67\"  src=\"" + r["LogImg"].ToString().Split(',')[0] + "\"  border='0'></a>");
                    _value.Append("<span>" + r["Title"].ToString() + "集团</span><br>地址：<a href='#' title='" + r["address"].ToString().Split(',')[0].Replace("市辖区", "") + "'>" + SubmitMeth.bSubstring(r["address"].ToString().Split(',')[0].Replace("市辖区", ""), 24) + "</a><br>");
                    _value.Append(" 电话：" + r["phone"].ToString() + " </div>");
                    _value.Append(" <div class=\"mainmcz2 mainmcz2z \">");
                    _value.Append("<a href='/market/marketclique.aspx?id=" + r["Id"].ToString() + "'><img width=\"447\" height=\"199\"  src=\"" +  r["thumbimg"].ToString().Split(',')[0] + "\" border='0'></a>");
                    _value.Append(" <span>集团简介</span><br>");
                    _value.Append("" + SubmitMeth.bSubstring(SubmitMeth.DisposeHtml(r["Descript"].ToString()), 240) + "</div></div>");
                    _value.Append("<div class=\"mainmcy\">");
                    _value.Append("<h1>旗下卖场</h1>");
                    int i = 0;
                    foreach (EnMarket en in listCom)
                    {
                        i++;
                        if (i <= 4)
                        {
                            string iphone = string.IsNullOrEmpty(en.lphone) ? "" : " 电话：" + en.lphone;
                            _value.Append("<div class=\"mainmcp\">");
                            _value.Append("<a href=\"/market/" + en.id + "/index.aspx\"><img width=\"209\" height=\"94\" src=\"" + getImg(hot + "/upload/market/surface/" + en.id + "/" + en.surface, en.surface) + "\"></a>");
                            _value.Append("<div class=\"mainmcp1\"><a href=\"/market/" + en.id + "/about.aspx\"></a><a href=\"/market/" + en.id + "/about.aspx\">卖场介绍</a> <a href=\"/market/" + en.id + "/index.aspx\">卖场品牌</a><a href=\"/market/" + en.id + "/product.aspx\">卖场产品</a></div>");
                            _value.Append("<div class=\"mainmcp2\">" + en.title + "</div> <div class=\"mainmcp3\" title='" + en.address.Replace(" ", "").Replace("市辖区", "") +iphone+ "'>" + SubmitMeth.bSubstring(en.address.Replace(" ", "").Replace("市辖区", ""), 28) + "</div> </div>");
                        }
                    }

                    _value.Append("</div></div>");

                }
                else if (c >1 && c <=2)
                {
                    _value.Append("<div class=\"mainmc\">");
                    _value.Append("<div class=\"mainmcz\">");
                    _value.Append("<div class=\"mainmcz1\">");
                    _value.Append("<a href='/market/marketclique.aspx?id=" + r["Id"].ToString() + "'><img width=\"218\" height=\"67\"   src=\"" + r["LogImg"].ToString().Split(',')[0] + "\" border='0'></a>");
                    _value.Append("<span>" + r["Title"].ToString() + "集团</span><br>");
                    _value.Append(" 地址：<a href='#' title='" + r["address"].ToString().Split(',')[0].Replace("市辖区", "") + "'>" + SubmitMeth.bSubstring(r["address"].ToString().Replace("市辖区", ""), 24) + "</a><br>");
                    _value.Append("电话：" + r["phone"].ToString() + " </div>");
                    _value.Append("<div class=\"mainmcz2 mainmcz2z \">");
                    _value.Append("<a href='/market/marketclique.aspx?id=" + r["Id"].ToString() + "'><img width=\"447\" height=\"199\"  src=\"" + r["thumbimg"].ToString().Split(',')[0] + "\" border='0'></a> ");
                    _value.Append("<span>集团简介</span><br>");
                    _value.Append("" + SubmitMeth.bSubstring(SubmitMeth.DisposeHtml(r["Descript"].ToString()), 210) + "</div></div>");
                    _value.Append("<div class=\"mainmcy\"><h1>旗下卖场</h1>");

                    int i = 0;
                    foreach (EnMarket en in listCom)
                    {
                        i++;
                        if (i <= 2)
                        {
                            string iphone = string.IsNullOrEmpty(en.lphone) ? "" : " 电话：" + en.lphone;
                            _value.Append("<div class=\"mainmcp mainmcpp\">");
                            _value.Append("<a href=\"/market/" + en.id + "/index.aspx\"><img width=\"209\" height=\"94\"  src=\"" + getImg(hot + "/upload/market/surface/" + en.id + "/" + en.surface, en.surface) + "\"></a>");
                            _value.Append("<div class=\"mainmcp1\"><a href=\"/market/" + en.id + "/about.aspx\">卖场介绍</a> <a href=\"/market/" + en.id + "/index.aspx\">卖场品牌</a><a href=\"/market/" + en.id + "/product.aspx\">卖场产品</a></div>");
                            _value.Append("<div class=\"mainmcp2 mainmcp22\">" +SubmitMeth.bSubstring(en.title,28) + "</div>");
                            _value.Append("<div class=\"mainmcp3\" title='" + en.address.Replace(" ", "").Replace("市辖区", "")+iphone + "'>" + SubmitMeth.bSubstring(en.address.Replace(" ", "").Replace("市辖区", ""), 28) + "</div></div>");
                        }
                    }

                    _value.Append("</div></div>");

                }
                else if (c == 1)
                {
                    _value.Append("<div class=\"mainmc\">");
                    _value.Append("<div class=\"mainmcz\">");
                    _value.Append(" <div class=\"mainmcz1\">");
                    _value.Append("<a href='/market/marketclique.aspx?id=" + r["Id"].ToString() + "'><img width=\"218\" height=\"67\"  src=\"" + r["LogImg"].ToString().Split(',')[0] + "\" border='0'></a> ");
                    _value.Append("<span>" + r["Title"].ToString() + "集团</span><br>");
                    _value.Append(" 地址：<a href='#' title='" + r["address"].ToString().Split(',')[0] + "'>" + SubmitMeth.bSubstring(r["address"].ToString().Replace("市辖区", ""), 24) + "</a> <br>");
                    _value.Append("电话：" + r["phone"].ToString() + " </div>");
                    _value.Append("<div class=\"mainmcz2 mainmcz2z \">");
                    _value.Append("<a href='/market/marketclique.aspx?id=" + r["Id"].ToString() + "'><img width=\"447\" height=\"199\"   src=\"" + r["thumbimg"].ToString().Split(',')[0] + "\" border='0'></a> ");
                    _value.Append("<span>集团简介</span><br>");
                    _value.Append(SubmitMeth.bSubstring(SubmitMeth.DisposeHtml(r["Descript"].ToString()), 240) + "</div></div>");
                    _value.Append("<div class=\"mainmcy\">");
                    _value.Append("<h1>旗下卖场</h1>");

                    int i = 0;
                    foreach (EnMarket en in listCom)
                    {
                        i++;
                        if (i == 1)
                        {
                            string iphone = string.IsNullOrEmpty(en.lphone) ? "" : " 电话：" + en.lphone;
                            _value.Append("<div class=\"mainmcp mainmcppp\">");
                            _value.Append("<a href=\"/market/" + en.id + "/index.aspx\"><img width=\"209\" height=\"94\" alt=\"\" src=\"" + getImg(hot + "/upload/market/surface/" + en.id + "/" + en.surface, en.surface) + "\"></a>");
                            _value.Append("<div class=\"mainmcp1 mainmcp11\"><a href=\"/market/" + en.id + "/about.aspx\">卖场介绍</a> <a href=\"/market/" + en.id + "/index.aspx\">卖场品牌</a><a href=\"/market/" + en.id + "/product.aspx\">卖场产品</a></div>");
                            _value.Append("<div class=\"mainmcp2 mainmcp22\">" + en.title + "</div><div class=\"mainmcp3\">" + en.address.Replace("市辖区", "").Replace(" ", "") + iphone + "</div></div>");
                        }
                    }
                    _value.Append("</div></div>");

                }
            }

            return _value.ToString();
        }
        #endregion

        #region 卖场数据顶部展示
        public string marketlet = "";
        public string market = "";
        public string markethide = string.Empty;

        BrandAndMarket brandm = new BrandAndMarket();
        private void MarketTop()
        {
            string letter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (null == TRECommon.DataCache.GetCache("brandandmarket"))
            {
                ECBrand.GetBrand();
            }
            brandm = TRECommon.DataCache.GetCache("brandandmarket") as BrandAndMarket;

           // strb.Length = 0;
            StringBuilder strb = new StringBuilder(string.Empty);
            List<t_market> marketlist = brandm.marketlist;

            List<t_market> tempt_market;
            foreach (char let in letter)
            {
                tempt_market = marketlist.FindAll(x => x.letter2.ToUpper() == let.ToString()).ToList();

                if (tempt_market.Count > 0)
                {
                    marketlet += "<li ><a href='#' style='padding:0 7px;' onmouseover=\"selectletter('" + let + "')\">" + let + "</a></li>";
                }
                else
                    marketlet += "<li ><a href='#' style='color: #c5c5c5;cursor: default;padding:0 7px;' >" + let + "</a></li>";

               
            }


            StringBuilder strbhide =new  StringBuilder(string.Empty);

            foreach (t_market item in marketlist)
            {
                strb.Append("<a href='/market/" + item.id + "/index.aspx' >" + item.title + "</a> ");
                strbhide.Append("<li letter='" + item.letter2.ToUpper() + "'><a href='/market/" + item.id + "/index.aspx' >" + item.title + "</a></li>");
            }
           
           market = strb.ToString();
           markethide = strbhide.ToString();
 
        }
        #endregion

        private List<EnMarket> marketList = null;
        public List<EnMarket> MarketList
        {
            get
            {
                if (marketList == null)
                {
                    marketList = ECMarket.GetMarketList(string.Empty);
                }
                return marketList;
            }
        }
        private List<EnArea> areaList = null;
        public List<EnArea> AreaList
        {
            get
            {
                if (areaList == null)
                {
                    var s = "";
                    foreach (var a in MarketList.Select(c => c.areacode).Where(c => c != null && c != "").ToArray())
                    {
                        if (s != "")
                        {
                            s += ",";
                        }
                        s += "'" + a + "'";
                    }
                    areaList = ECArea.GetAreaList("areacode in(" + s + ")");
                }
                return areaList;
            }
        }
        public List<EnWebMarket> list = new List<EnWebMarket>();
        public List<Mpromotions> promotions = new List<Mpromotions>();
        public Dpromotions dpromotions = new Dpromotions();
        public List<t_advertising> list_right = new List<t_advertising>();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-家具卖场";
            string orderType = "";
            string orderKey = "";
            string strWhere = "";

            if (ECommon.QuerySearchKey != "")
            {
                string key = ECommon.QuerySearchKey.Replace("abc111", "-").Replace("cba222", "_");
                strWhere += " and (title like '%" + key + "%')";
            }
            if (ECommon.QuerySearchArea != "")
            {
                var qsa = ECommon.QuerySearchArea;
               
                if (qsa.StartsWith("_"))
                {
                    qsa = qsa.Substring(1, qsa.Length - 1);
                }
                strWhere += " and (areacode in('" + qsa.Replace("_", "','") + "'))";
            }
            //strWhere = strWhere != "" ? " and ( " + strWhere.Substring(4, strWhere.Length - 4) + " )" : "";

            switch (ECommon.QuerySearchSort.ToLower())
            {
                case "_t1":
                    orderType = "desc";
                    orderKey = "title";
                    sortTitle = "名称升序";
                    break;
                case "_t2":
                    orderKey = "title";
                    orderType = "asc";
                    sortTitle = "名称排序";
                    break;
                case "_d1":
                    orderKey = "lastedittime";
                    orderType = "desc";
                    sortDate = "由近到远";
                    break;
                case "_d2":
                    orderKey = "lastedittime";
                    orderType = "asc";
                    sortDate = "由远到近";
                    break;
                case "_h1":
                    orderKey = "hits";
                    orderType = "desc";
                    sortHot = "由高到低";
                    break;
                case "_h2":
                    orderKey = "hits";
                    orderType = "asc";
                    sortHot = "由低到高";
                    break;
                default:
                    orderKey = "vip desc,sort ASC,hits";
                    orderType = "desc";
                    break;
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                list = ECMarket.GetWebMarketList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, orderKey, orderType, out tmpPageCount);

                var marketids = list.Select(c => c.id).ToArray();
                if (marketids.Count() > 0)
                {
                    var query = dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(dpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k }).Where(c => c.k.Where(m => marketids.Contains(m.marketid)).Any()).OrderByDescending(c => c.f.IsRecommend).ThenByDescending(c => c.f.createtime);
                    promotions = query.ToList().Select(c => new Mpromotions
                    {
                        id = c.f.id,
                        title = c.f.title,
                        membertype = c.f.membertype,
                        promotionsrelated = c.k.ToList()
                    }).ToList();
                }

                AspNetPager1.RecordCount = tmpPageCount;
                AspNetPager1.EnableUrlRewriting = true;
                string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                AspNetPager1.UrlRewritePattern = string.Format(EnUrls.MarketListSearch, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, "{0}", ECommon.QuerySearchArea);

            }
            else
            {
                int rowscount = 0;
                DataTable dt=new DataTable();
                dt = ECMarket.GetMarketClique(ECommon.QueryPageIndex, ref rowscount);
                MarketCliqueShow = getMarketCstrHide(dt);
                AspNetPager1.RecordCount = rowscount;
                AspNetPager1.EnableUrlRewriting = true;
                AspNetPager1.PageSize = 10;
                string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                AspNetPager1.UrlRewritePattern = string.Format(EnUrls.MarketListSearch, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, "{0}", ECommon.QuerySearchArea);
                
            }
            //顶部卖场
            MarketTop();
            #region 广告
            //获取所有广告列表
            List<t_advertising> listt_advertising = TREC.ECommerce.ECAdvertisement.AdvertisingList(" AND tg.id IN (30,31) ");

            //右边底部广告
            List<t_advertising> list2 = listt_advertising.Where(x => x.categoryid == 30).Take(1).ToList(); //"卖场搜索页-右边底部广告"
            //优质商家
            List<t_advertising> list3 = listt_advertising.Where(x => x.categoryid == 31).Take(1).ToList();//"卖场搜索页-优质商家"
            //推荐卖场
           list_right = TREC.ECommerce.ECAdvertisement.AdvertisingList(" and categoryid=33 ");
            StringBuilder strb1 = new StringBuilder();


            //轮播广告
            strb1.Length = 0;
            foreach (t_advertising item in list2)
            {
                strb1.Append("<a href='" + item.linkurl + "' target='_blank'><img style='width: 228px; height: 170px;' src='" + item.imgurl + "' /></a>");
            }
            adv = strb1.ToString();


            //优质商家
            //adcode存储商家id号码  根据id获取商家logo和简介
            strb1.Length = 0;
            if (list3.Count > 0)
            {

                System.Data.DataTable dt = TREC.ECommerce.ECommerce.GetTable(@" SELECT t_product.id,t_brand.companyid,t_company.descript,   t_brand.logo, brandid,t_brand.title as brandtitle,t_product.title
                        ,dbo.t_product.thumb,(SELECT TOP 1 saleprice  FROM t_productattribute WHERE productid = t_product.id  ) AS price  

                          FROM dbo.t_product 
                        INNER JOIN dbo.t_brand ON t_brand.id =  t_product.brandid
                        INNER JOIN dbo.t_company ON t_company.id = t_brand.companyid 
                         WHERE t_product.id= " + list3[0].adcode);

                if (dt.Rows.Count == 1)
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
                    strb1.Append("<img src='' style='height: 32px; width: 84px' />");
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
                shangjia = strb1.ToString();
            }


            #endregion


        }
        /// <summary>
        /// 通过卖场id获取集团资料
        /// </summary>
        /// <param name="markertId"></param>
        /// <returns></returns>
        protected EnMarketClique GetMarketClique(int markertId)
        {
            return ECMarketClique.GetMarketCliqueBySubMainMarketId(markertId);
        }

        /// <summary>
        /// AspNetPager1 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::Wuqi.Webdiyer.AspNetPager AspNetPager1;

    }
}