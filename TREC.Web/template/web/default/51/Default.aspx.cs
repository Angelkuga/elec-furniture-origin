using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using System.Data;
using System.Text;

namespace TREC.Web.template.web._51
{
	public partial class Default : System.Web.UI.Page
	{

        public string checkurl(string logo,string id, string img)
        {
            if (!string.IsNullOrEmpty(img))
            {
                return img;
            }
            else
            {
                return "/upload/brand/logo/" + id + "/" + logo.Replace(",","");
            }
        }

        //public DataTable getBrandProc(string brandId)
        //{
       
        //    DataSet dt = new DataSet();
        //   // dt = ECBrand.GetDataSet("t_product", " top 4 *", " where linestatus=1 AND  auditstatus=1 AND brandid=" + brandId, " order by  id desc");

        //    return dt.Tables[0];
        //}
        public string getBrandProc(string brandId)
        {

            if (brandId == "28" || brandId == "482")
            {
                DataSet dt = new DataSet();
                // dt = ECBrand.GetDataSet("t_company","", " WHERE id IN(SELECT TOP 1 companyid FROM t_product WHERE  linestatus=1 AND  auditstatus=1  AND brandid=" + brandId + ")","");
                dt = ECBrand.GetDataSet("t_brand", "", " WHERE id =" + brandId, "");
                StringBuilder _value = new StringBuilder(string.Empty);

                if (dt != null && dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    string banner = dt.Tables[0].Rows[0]["desimage"].ToString();
                    foreach (string s in banner.Split(','))
                    {
                        if (s.Length > 2)///upload/brand/desimage/660/20150424150046246858.jpg
                        {
                            _value.Append("<a href=\"/company/" + dt.Tables[0].Rows[0]["companyid"].ToString() + "/index.aspx\" target=\"_blank\"><img src=\"http://www.jiajuks.com/upload/brand/desimage/" + dt.Tables[0].Rows[0]["id"].ToString() + "/" + s + "\" /></a>");
                        }
                    }

                }
                return _value.ToString();
            }
            else
            {
                DataSet dt = new DataSet();
                dt = ECBrand.GetDataSet("t_company", "", " WHERE id IN(SELECT TOP 1 companyid FROM t_product WHERE  linestatus=1 AND  auditstatus=1  AND brandid=" + brandId + ")", "");
                StringBuilder _value = new StringBuilder(string.Empty);

                if (dt != null && dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    string banner = dt.Tables[0].Rows[0]["bannel"].ToString();
                    foreach (string s in banner.Split(','))
                    {
                        if (s.Length > 2)
                        {
                            _value.Append("<a href=\"/company/" + dt.Tables[0].Rows[0]["id"].ToString() + "/index.aspx\" target=\"_blank\"><img src=\"http://www.jiajuks.com/upload/company/banner/" + dt.Tables[0].Rows[0]["id"].ToString() + "/" + s + "\" /></a>");
                        }
                    }

                }

                return _value.ToString();
            }
           
        }
        public string geturl(string brandid)
        {
            // <a href="#">品牌介绍</a><a href="#">查看产品</a>

            DataSet dt = new DataSet();
            dt = ECBrand.GetDataSet("t_product", " top 1 *", " where linestatus=1 AND  auditstatus=1 AND brandid=" + brandid, " order by  id desc");

            if (dt != null && dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
            {
                return " <a target='_blank' href=\"/company/" + dt.Tables[0].Rows[0]["companyid"].ToString() + "/brand-" + dt.Tables[0].Rows[0]["brandid"].ToString() + ".aspx\">品牌介绍</a><a target='_blank' href=\"/company/" + dt.Tables[0].Rows[0]["companyid"].ToString() + "/product-" + dt.Tables[0].Rows[0]["brandid"].ToString() + "-----------.aspx\">查看产品</a>";
               
            }
            else
            {
                return " <a href=\"#\">品牌介绍</a><a href=\"#\">查看产品</a>";
            }
        }

        public string getct(string brandid)
        {
            ///
            ///
            DataSet dt = new DataSet();
            dt = ECBrand.GetDataSet("t_product", " top 1 *", " where linestatus=1 AND  auditstatus=1 AND brandid=" + brandid, " order by  id desc");

            if (dt != null && dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
            {
                //return "<a target='_blank' href=\"/company/product.aspx?cid=" + dt.Tables[0].Rows[0]["companyid"].ToString() + "&tid=4\">立即参团</a>";

                return "<a target='_blank' href=\"/company/" + dt.Tables[0].Rows[0]["companyid"].ToString() + "/product-" + brandid + "-----------.aspx\">立即参团</a>";
            }
            else
            {
                return "<a href=\"#\">立即参团</a>";
            }
        }

        public string getEnterUser(string brind, int t,object d)
        {
            int fd=0;
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

        public string gettopEnterUser(string brind,object d1,object d2)
        {
            int s1=0, s2=0;
            try
            {
                s1 = SubmitMeth.getInt(d1.ToString());
                s2 = SubmitMeth.getInt(d2.ToString());
            }
            catch
            {
 
            }
            return (SubmitMeth.getInt(ECBrand.EnterUser(brind).Tables[0].Rows[0][0].ToString()) + SubmitMeth.getInt(ECBrand.EnterUser(brind).Tables[1].Rows[0][0].ToString()) + s1+s2).ToString();
        }
        public string getEnterSel(string brandid)
        {
            return ECBrand.getEnterSel(brandid);
        }
		protected void Page_Load(object sender, EventArgs e)
		{
            DataSet dt = new DataSet();
            dt = ECBrand.Brand51List();
           
            Repeater_All.DataSource = dt.Tables[0];
            Repeater_All.DataBind();

            Repeater_data1.DataSource = dt.Tables[1];
            Repeater_data1.DataBind();


            Repeater_data2.DataSource = dt.Tables[2];
            Repeater_data2.DataBind();


            Repeater_data3.DataSource = dt.Tables[3];
            Repeater_data3.DataBind();


            Repeater_data4.DataSource = dt.Tables[4];
            Repeater_data4.DataBind();

            Repeater_data5.DataSource = dt.Tables[5];
            Repeater_data5.DataBind();


            Repeater_tuan.DataSource = dt.Tables[0];
            Repeater_tuan.DataBind();
		}

        protected void Repeater_tuan_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{

            //    Repeater rptProduct = (Repeater)e.Item.FindControl("Repeater_img");
            //    //找到分类Repeater关联的数据项
            //    DataRowView rowv = (DataRowView)e.Item.DataItem;
            //    //提取分类ID
            //    string bid = rowv["brandId"].ToString();
            //    //根据分类ID查询该分类下的产品，并绑定产品Repeater
            //    rptProduct.DataSource = getBrandProc(bid);
            //    rptProduct.DataBind();
            //}
        }
	}
}