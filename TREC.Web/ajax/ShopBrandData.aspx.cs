using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TREC.ECommerce;
using System.Text;
using System.IO;

namespace TREC.Web.ajax
{
    public partial class ShopBrandData : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            string brandName = Request["brandtitle"];
            string p = Request["pageindex"];
            string t = Request["t"];//1. 推荐产品  2.促销产品(buyprice) 查询促销价>0

            StringBuilder _value = new StringBuilder();

            DataSet prods = new DataSet();
            if (t == "1")
            {
                prods = ECProduct.getShopProduct(SubmitMeth.getInt(p), 40, " and brandtitle='" + brandName + "' and  (ShopID=0 or ShopID is null) ", "v_productList");
            }
            else if (t == "2")
            {
                prods = ECProduct.getShopProduct(SubmitMeth.getInt(p), 40, " and brandtitle='" + brandName + "' and (ShopID=0 or ShopID is null) AND   Charindex('buyprice', REPLACE(attributexml,'<buyprice>0.00</buyprice>',''))>0  ", "v_productList");
            }

            foreach (DataRow r in prods.Tables[0].Rows)
            {
                 DataSet dsxml = new DataSet();
                 if (r["attributexml"] != null && !string.IsNullOrEmpty(r["attributexml"].ToString()))
                 {
                     Stream stream = new MemoryStream(Encoding.UTF8.GetBytes("<xml>" + r["attributexml"].ToString() + "</xml>"));

                     dsxml.ReadXml(stream);
                 }

                _value.Append("<li>");
                _value.Append("<center><a href=\"/product/" + r["id"].ToString() + "/info.aspx\" target=\"_blank\"><img src=\"http://www.jiajuks.com//upload/product/thumb/" + r["id"].ToString() + "/" + r["thumb"].ToString().Split(',')[0] + "\"  /> </a> </center>");
                _value.Append("<div class=\"shoppro_title\">" + r["title"].ToString() + "</div>");
                _value.Append(" <div class=\"shoppro_title\">" + r["materialname"].ToString() + " " + r["brandtitle"].ToString() + " " + r["categorytitle"].ToString() + "</div>");

                if (dsxml != null && dsxml.Tables.Count > 0 && dsxml.Tables[0].Rows.Count > 0)
                {
                    if (SubmitMeth.getdouble(dsxml.Tables[0].Rows[0]["markprice"].ToString()) > 0)
                    {
                        _value.Append(" <div class=\"shoppro_p1\">市场参考价：￥" + dsxml.Tables[0].Rows[0]["markprice"].ToString() + "</div>");
                    }
                    if (SubmitMeth.getdouble(dsxml.Tables[0].Rows[0]["saleprice"].ToString()) > 0)
                    {
                        _value.Append(" <div class=\"shoppro_p2\">销售价：￥" + dsxml.Tables[0].Rows[0]["saleprice"].ToString() + "</div>");
                    }
                    if (SubmitMeth.getdouble(dsxml.Tables[0].Rows[0]["buyprice"].ToString()) > 0)
                    {
                        _value.Append("<div class=\"shoppro_p2\">" + r["pricename"].ToString() + "：￥" + dsxml.Tables[0].Rows[0]["buyprice"].ToString() + "</div>");
                    }
                }

                _value.Append(" </li>");
            }

            Response.Write(_value.ToString() + "■" + prods.Tables[1].Rows[0][0].ToString());
        }
    }
}