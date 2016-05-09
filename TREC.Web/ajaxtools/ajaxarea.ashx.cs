using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using TRECommon;
using TREC.Entity;
using TREC.ECommerce;

namespace TREC.Web.ajaxtools
{
    /// <summary>
    /// ajaxarea 的摘要说明
    /// </summary>
    public class ajaxarea : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request["type"] == null ? context.Request.Params["type"] == null ? "" : context.Request.Params["type"] : context.Request["type"];
            string select = context.Request["s"] == null ? context.Request.Params["s"] == null ? "" : context.Request.Params["s"] : context.Request["s"];
            string pro = context.Request["p"] == null ? context.Request.Params["p"] == null ? "" : context.Request.Params["p"] : context.Request["p"];
            string city = context.Request["c"] == null ? context.Request.Params["c"] == null ? "" : context.Request.Params["c"] : context.Request["c"];
            string district = context.Request["d"] == null ? context.Request.Params["d"] == null ? "" : context.Request.Params["d"] : context.Request["d"];

            if (type == "p")
            {
                context.Response.Write(GetPro(select));
            }
            if (type == "c")
            {
                context.Response.Write(GetCity(pro, select));
            }
            if (type == "d")
            {
                context.Response.Write(GetDistrict(city, select));
            }
            if (type == "t")
            {
                context.Response.Write(GetTown(district, select));
            }

            if (type == "edit")
            {
                context.Response.Write(GetAllPath(select));
            }


            context.Response.End();
        }

        protected string GetAllPath(string selectvalue)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(selectvalue) && selectvalue.Length == 6)
            {
                EnArea cityinfo = ECArea.GetAreaInfo(" where areacode='" + selectvalue.Substring(0, 4) + "00" + "' ");

                if (cityinfo != null)
                {
                    //sb.Append("{\"type\":\"city\",\"areacode\":\"\",\"areaname\":\"请选择城市\"},");
                    sb.Append("{\"type\":\"city\",\"areacode\":\"" + cityinfo.areacode + "\",\"areaname\":\"" + cityinfo.areaname + "\"}");
                }

                if (selectvalue.Substring(3, 2) != "00")
                {
                    sb.Append(",");
                    EnArea tdinfo = ECArea.GetAreaInfo(" where areacode='" + selectvalue + "'");

                    EnArea pinfo = ECArea.GetAreaInfo(" where areacode='" + tdinfo.parentcode + "'");

                    if (pinfo != null && pinfo.areacode != cityinfo.areacode)
                    {
                        sb.Append("{\"type\":\"district\",\"areacode\":\"" + pinfo.areacode + "\",\"areaname\":\"" + pinfo.areaname + "\"},");
                        sb.Append("{\"type\":\"town\",\"areacode\":\"" + tdinfo.areacode + "\",\"areaname\":\"" + tdinfo.areaname + "\"}");
                    }
                    else
                    {
                        sb.Append("{\"type\":\"district\",\"areacode\":\"" + tdinfo.areacode + "\",\"areaname\":\"" + tdinfo.areaname + "\"}");
                    }
                }

            }

            return "[" + sb.ToString() + "]";
        }


        protected string GetPro(string selectvalue)
        {
            StringBuilder sb = new StringBuilder();

            List<EnArea> _lst = ECArea.GetAreaList(" parentcode=0");
            if (_lst != null && _lst.Count > 0)
            {
                sb.Append("<option value=\"\">请选择省份</option>");
                foreach (EnArea a in ECArea.GetAreaList(" parentcode=0"))
                {
                    if (!string.IsNullOrEmpty(selectvalue) && selectvalue.Length == 6 && a.areacode == selectvalue.Substring(0, 2) + "0000")
                    {
                        sb.Append("<option value=\"" + a.areacode + "\" selected=\"true\">" + a.areaname + "</option>");
                        continue;
                    }
                    sb.Append("<option value=\"" + a.areacode + "\">" + a.areaname + "</option>");
                }
            }
            else
                sb.Append("null");
            return sb.ToString();
        }

        protected string GetCity(string pro, string selectvalue)
        {
            StringBuilder sb = new StringBuilder();
            List<EnArea> _lst = ECArea.GetAreaList(" parentcode=" + pro);
            if (_lst != null && _lst.Count > 0)
            {
                sb.Append("<option value=\"\">请选择城市</option>");
                foreach (EnArea a in ECArea.GetAreaList(" parentcode=" + pro))
                {
                    if (!string.IsNullOrEmpty(selectvalue) && selectvalue.Length == 6 && a.areacode == selectvalue.Substring(0, 4) + "00")
                    {
                        sb.Append("<option value=\"" + a.areacode + "\" selected=\"true\">" + a.areaname + "</option>");
                        continue;
                    }
                    sb.Append("<option value=\"" + a.areacode + "\">" + a.areaname + "</option>");
                }
            }
            else
                sb.Append("null");
            return sb.ToString();
        }

        protected string GetDistrict(string city, string selectvalue)
        {
            StringBuilder sb = new StringBuilder();
            List<EnArea> _lst = ECArea.GetAreaList(" parentcode=" + city);
            if (_lst != null && _lst.Count > 0)
            {
                sb.Append("<option value=\"\">请选择地区</option>");
                foreach (EnArea a in ECArea.GetAreaList(" parentcode=" + city))
                {
                    if (!string.IsNullOrEmpty(selectvalue))
                    {
                        sb.Append("<option value=\"" + a.areacode + "\" selected=\"true\">" + a.areaname + "</option>");
                        continue;
                    }
                    sb.Append("<option value=\"" + a.areacode + "\">" + a.areaname + "</option>");
                }
            }
            else
                sb.Append("null");
            return sb.ToString();
        }


        protected string GetTown(string district, string selectvalue)
        {
            StringBuilder sb = new StringBuilder();

            List<EnArea> list = ECArea.GetAreaList(" parentcode=" + district);
            if (list.Count > 0)
            {
                sb.Append("<option value=\"\">请选择</option>");
                foreach (EnArea a in ECArea.GetAreaList(" parentcode=" + district))
                {
                    if (!string.IsNullOrEmpty(selectvalue))
                    {
                        sb.Append("<option value=\"" + a.areacode + "\" selected=\"true\">" + a.areaname + "</option>");
                        continue;
                    }
                    sb.Append("<option value=\"" + a.areacode + "\">" + a.areaname + "</option>");
                }
            }
            else
            {
                sb.Append("null");
            }
            return sb.ToString();
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