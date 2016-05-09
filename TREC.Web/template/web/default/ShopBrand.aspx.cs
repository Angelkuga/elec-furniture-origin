using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.template.web
{
	public partial class ShopBrand : System.Web.UI.Page
	{
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
                    return "欧莱思特";
                }
            }
        }
        public string getqq(object o)
        {
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                if (!string.IsNullOrEmpty(o.ToString().Trim()))
                {
                    return "<a href=\"http://wpa.qq.com/msgrd?v=3&amp;uin=" + o.ToString() + "&amp;site=qq&amp;menu=yes\" target=\"_blank\"> <img border=\"0\" title=\"点击这里给我发消息\" alt=\"点击这里给我发消息\" style=\"height:18px;vertical-align:middle;margin-left:2px;\" src=\"http://wpa.qq.com/pa?p=2:" + o.ToString() + ":41\"></a>";
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public string getAddress(object areacode, object address)
        {
            string area = string.Empty; ;


            if (areacode != null)
            {
                area = TREC.ECommerce.ECommon.getAreaAll(areacode.ToString());
            }

            return area.Replace("市辖区", "") + address.ToString().Replace(area, "").Replace("市辖区", "");
        }

        public bool isPay = false;

        public string gethd(object o)
        {
            // isPay = SupplerPageBase.IsPayMember(
            StringBuilder _value = new StringBuilder(string.Empty);
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                if (!string.IsNullOrEmpty(o.ToString()))
                {
                    try
                    {
                        Stream stream = new MemoryStream(Encoding.UTF8.GetBytes("<xml>" + o.ToString() + "</xml>"));
                        DataSet ds = new DataSet();
                        ds.ReadXml(stream);

                        int i=1;
                        string hdtitle = "活动：";
                        foreach (DataRow r in ds.Tables[0].Rows)
                        {
                            if (i == 2)
                            {
                                hdtitle = "活动二：";
                            }
                            if (i == 1)
                            {
                                _value.Append("<div class=\"shopli_td2_h\"><a href=\"" + r["url"].ToString() + "\" target=\"_blank\">" + hdtitle + "" + r["promotionstitle"].ToString() + "</a></div>");
                            }
                                i++;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            return _value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool ispay(object o,string v)
        {
            return true;
      
            //if (o.ToString() == v)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        public string tdarea = string.Empty;

       
        public string companyLog = string.Empty;
        public string companystyle = string.Empty;
        public string companymaterial = string.Empty;
        public string companytitle = string.Empty;
        public string companyaddress = string.Empty;
        public string companyphone = string.Empty;
        public string companybrand = string.Empty;
        public string companyjr="<a href=\"#\" style=\"color:#CC0000;\">进入>></a>";
        private string companyid = "0";
        public string companyurl = "#";
        private void companydata()
        {
            DataSet ds = new DataSet();
           ds=ECShop.getBrandCompany(bname);

           companyLog = "/upload/brand/logo/" + ds.Tables[3].Rows[0]["id"].ToString() + "/" + ds.Tables[3].Rows[0]["logo"].ToString().Replace(",","");
           companystyle = ds.Tables[3].Rows[0]["stylename"].ToString();
           companymaterial = ds.Tables[3].Rows[0]["materialname"].ToString();

           if (ds.Tables[0].Rows.Count > 0)//厂商信息  <a href="#">  上海嘉顺家具有限公司 </a>
           {
               companytitle = "<a href=\"/company/" + ds.Tables[0].Rows[0]["Id"].ToString() + "/index.aspx\" target=\"_blank\">" + ds.Tables[0].Rows[0]["title"].ToString() + "</a>";
               companyurl = "/company/" + ds.Tables[0].Rows[0]["Id"].ToString() + "/index.aspx";
              string area = string.Empty;
              if (ds.Tables[0].Rows[0]["areacode"] != null)
              {
                  area = TREC.ECommerce.ECommon.getAreaAll(ds.Tables[0].Rows[0]["areacode"].ToString());
              }
              companyid = ds.Tables[0].Rows[0]["Id"].ToString();
                 companyaddress = area.Replace("市辖区", "") + ds.Tables[0].Rows[0]["address"].ToString().Replace(area, "").Replace("市辖区", "");
                 companyphone = ds.Tables[0].Rows[0]["phone"].ToString();
                 companybrand = "<a href=\"/company/" + ds.Tables[0].Rows[0]["Id"].ToString() + "/index.aspx\" target=\"_blank\"><img src=\"http://www.jiajuks.com//upload/brand/thumb/" + ds.Tables[3].Rows[0]["Id"].ToString() + "/" + ds.Tables[3].Rows[0]["thumb"].ToString().Replace(",", "") + "\"  style=\"margin:8px;width:218px;height:137px;\"/></a>";
                 companyjr = "<a href=\"/company/" + ds.Tables[0].Rows[0]["Id"].ToString() + "/index.aspx\" target=\"_blank\" style=\"color:#CC0000;\">进入>></a>";
               Repeater_companybrand.DataSource = ds.Tables[1];
                 Repeater_companybrand.DataBind();
           }
           else
           {
               companytitle = "";
                     companybrand = "<img src=\"http://www.jiajuks.com//upload/brand/thumb/" + ds.Tables[3].Rows[0]["Id"].ToString() + "/" + ds.Tables[3].Rows[0]["thumb"].ToString().Replace(",", "") + "\"  style=\"margin:8px;width:218px;height:137px;\"/>";
           }
        }
        StringBuilder strb = new StringBuilder();
        StringBuilder strb2 = new StringBuilder();
        StringBuilder strb3 = new StringBuilder();
        public string hletter;
        public string rightletter = "";
        public string rightletter2 = "";
        private void showletter()
        {
            if (null == TRECommon.DataCache.GetCache("brandandmarket"))
            {
                ECBrand.GetBrand();
            }
            BrandAndMarket brandm = new BrandAndMarket();
            brandm = TRECommon.DataCache.GetCache("brandandmarket") as BrandAndMarket;

            List<t_brand> brandlist = brandm.brandlist;
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
                            strb2.Append(" <li><a href='ShopBrand.aspx?bname=" + Server.UrlEncode(item.title) + "' >" + item.title + "</a></li>");
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

        }
		protected void Page_Load(object sender, EventArgs e)
		{
            companydata();
            DataSet ds = new DataSet();
            ds = ECShop.GetBrandShop(bname);



            if (ds.Tables[0].Rows.Count == 0)
            {
                Response.Redirect("/company/" + companyid + "/index.aspx");
            }
            Repeater_adver.DataSource = ECBrand.getBrandByPid("5", "55");
            Repeater_adver.DataBind();
            showletter();
            
           
            List<string> _checkarea = new List<string>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                if (r["areacode"] != null && !_checkarea.Contains(r["areacode"].ToString()))
                {
                    if (TREC.ECommerce.ECommon.shArea.Contains(r["areacode"].ToString()))
                    {
                        tdarea = tdarea + "<td onmouseover=\"checkareacode('" + r["areacode"].ToString() + "')\" id='btable_td" + r["areacode"].ToString() + "'>" + r["areaname"].ToString() + "</td>";
                        _checkarea.Add(r["areacode"].ToString());
                    }
                }

            }

            Repeater_brandshop.DataSource = ds.Tables[0];
            Repeater_brandshop.DataBind();
		}
	}
}