using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Data;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.ajax
{
    /// <summary>
    /// ajaxsearchbrand 的摘要说明
    /// </summary>
    public class ajaxsearchbrand : IHttpHandler
    {
        string strWhere = "";
        string bstrWhere = "";
        bool blBrandSearch = false;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = "";
            string value = "";

            string style = "";
            string material = "";
            string color = "";
            string TypeSearch = "";

            if (context.Request.QueryString["stypes"] != null)
            {
                type = context.Request.QueryString["stypes"];
            }

            if (context.Request.QueryString["id"] != null)
            {
                value = context.Request.QueryString["id"];
            }

            if (context.Request.QueryString["style"] != null)
            {
                style = context.Request.QueryString["style"];

                string str = "";
                string str2="";
                if (style != "")
                {
                    string t = style.StartsWith("_") ? style.Substring(1, style.Length - 1) : style;
                    t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                    t = t.Replace("_", ",");
                    str += " and stylevalue in (" + t + ") ";
                    str2 += " and style in (" + t + ") ";
                }
                strWhere += str;
                bstrWhere+= str2;
            }
            if (context.Request.QueryString["material"] != null)
            {
                material = context.Request.QueryString["material"];
                string str = "";
                string str2="";
                if (material != "")
                {
                    string t = material.StartsWith("_") ? material.Substring(1, material.Length - 1) : material;
                    t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                    t = t.Replace("_", ",");
                    str += " and materialvalue in (" + t + ") ";
                    str2 += " and material in (" + t + ") ";
                }
                strWhere += str;
                bstrWhere+= str2;
            }
            if (context.Request.QueryString["color"] != null)
            {
                color = context.Request.QueryString["color"];
                string str = "";
                string str2="";
                if (color != "")
                {
                    string t = color.Trim('_').Replace('_', ',');
                    str += " and colorvalue  in(" + t + ")";
                    str2 += " and color  in(" + t + ")";
                }
                strWhere += str;
                bstrWhere+= str2;
            }
            if (context.Request.QueryString["TypeSearch"] != null)
            {
                TypeSearch = context.Request.QueryString["TypeSearch"];

                string str = "";
                if (TypeSearch != "")
                {
                    foreach (string s in TypeSearch.Substring(1, TypeSearch.Length - 1).Split('_'))
                    {
                        str += " or attributexml like '%<typevalue>" + TypeSearch + "</typevalue>%' ";
                    }
                    str = str != "" ? " and ( " + str.Substring(4, str.Length - 4) + " )" : "";
                }
                strWhere += str;
            }
            string ostrWhere = strWhere == "" ? " where 1=1 " : " where 1=1 " + strWhere;
            string obstrWhere = bstrWhere == "" ? " where 1=1 " : " where 1=1 " + bstrWhere;
            //string swhere = " where 1=1 and t_brand.id in( select id from v_product " + ostrWhere
            //            + " and brandid in(select brandid from t_shopbrand where shopid in("
            //            + "select DISTINCT id from t_shop where id in (select DISTINCT shopid from t_marketstoreyshop where 1=1 and marketid="
            //            + value
            //            + ")))union select id from t_brand  " + obstrWhere
            //+ "and id in(select brandid from t_shopbrand where shopid in("
            //+ "select DISTINCT id from t_shop where id in (select DISTINCT shopid from t_marketstoreyshop where 1=1 and marketid="
            //+ value
                
            //            + "))))";
            string swhere = " where 1=1 and t_brand.id in( select brandid from v_product " + ostrWhere
                        + " and brandid in(select brandid from t_shopbrand where shopid in("
                        + "select DISTINCT id from t_shop where id in (select DISTINCT shopid from t_marketstoreyshop where 1=1 and marketid="
                        + value
                        + "))))";
            string fields = " t_brand.id,t_brand.title,substring(t_brand.letter,1,1) as letter,t_brand.companyid,t_brand.material,t_brand.style,t_brand.color ";

            switch (type.ToLower())
            {
                case "getprovince":
                    context.Response.Write(GetProvince(fields, swhere));
                    break;
                default:
                    context.Response.Write("ajax数据读取错误");
                    break;

            }
            context.Response.End();

        }

        public string GetProvince(string field,string strWhere)
        {
            return CreateJsonParameters(GetDataTableBrand(field, strWhere));
        }

        public static DataTable GetDataTableBrand(string field,string strWhere)
        {
            DataTable p = ECBrand.GetMarketBrandLetterList(field,strWhere);
            if (p == null)
                return null;
            return p;
        }

        public static string DataTableToJson(DataTable source)
        {
            if (source.Rows.Count == 0)
                return "";
            StringBuilder sb = new StringBuilder("[");
            foreach (DataRow row in source.Rows)
            {
                sb.Append("[");
                for (int i = 0; i < source.Columns.Count; i++)
                {
                    sb.Append('"' + row[i].ToString() + "\",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("],");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }

        public static string CreateJsonParameters(DataTable dt)
        {
            StringBuilder JsonString = new StringBuilder();
                
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("{ ");
                JsonString.Append("\"T_blog\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]}");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}