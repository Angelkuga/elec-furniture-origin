using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
namespace TREC.Web.ajaxtools
{
    /// <summary>
    /// ajaxshow 的摘要说明
    /// </summary>
    public class ajaxshow : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int aid;

            //获得广告位的ID
            if (!int.TryParse(context.Request.Params["id"] as string, out aid))
            {
                context.Response.Write("document.write('错误提示，请勿提交非法字符！');");
                return;
            }

            //检查广告位是否存在
            //DtCms.BLL.Advertising abll = new DtCms.BLL.Advertising();


            if (ECAdvertisementCategory.ExitAdvertisementCategory(aid) <= 0)
            {
                //context.Response.Write("document.write('错误提示，该广告位不存在！');");
                context.Response.Write("document.write('');");
                return;
            }

            //取得该广告位详细信息
            //DtCms.Model.Advertising aModel = abll.GetModel(aid);
            EnAdvertisementCategory aModel = ECAdvertisementCategory.GetAdvertisementCategoryInfo(" where id=" + aid + " and isopen=1 and (datediff(d,starttime,getdate())>=0 and datediff(d,endtime,getdate())<=0 or endtime='1900-1-1 0:00:00' or endtime is null or starttime='1900-1-1 0:00:00' or starttime is null )");


            //输出该广告位下的广告条,不显示未开始、过期、暂停广告

            List<EnAdvertisement> list = ECAdvertisement.GetAdvertisementList(" isopen=1  and categoryid=" + aid);
            if (list.Count < 1 || list == null)
            {
                //context.Response.Write("document.write('该广告位下暂无广告内容');");
                context.Response.Write("document.write('');");
                return;
            }

            //=================判断广告位类别,输出广告条======================

            //新增，取得站点配置信息
            //DtCms.Model.WebSet webset = new DtCms.BLL.WebSet().loadConfig(Utils.GetXmlMapPath("Configpath"));
            int pageCout = 0;
            DataTable dt = ECAdvertisement.GetAdvertisementListToTable(-1, 1000, " categoryid=" + aModel.id, out pageCout);
            StringBuilder _sb = new StringBuilder();
            switch (aModel.adtype)
            {
                case (int)EnumAdvertisementinType.文字广告: //文字
                    context.Response.Write("document.write('<ul>');\n");                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        context.Response.Write("document.write('<li>');");
                        _sb.Append("document.write('<a title=\"" + dr["adtext"] + "\" ");
                        if (!string.IsNullOrEmpty(dr[""].ToString()))
                        {
                            _sb.Append("href=\"" + dr["linkurl"] + "\">" + dr["adtext"] + "</a>');");
                        }
                        else
                        {
                            _sb.Append("\">" + dr["adtext"] + "</a>');");
                        }
                        context.Response.Write(_sb.ToString());
                        context.Response.Write("document.write('</li>');\n");
                    }
                    context.Response.Write("document.write('</ul>');\n");
                    break;
                case (int)EnumAdvertisementinType.图片广告: //图片
                    if (dt.Rows.Count == 1)
                    {
                        DataRow dr = dt.Rows[0];
                        string img = dr["imgurl"].ToString();
                        img = img.EndsWith(",") ? img.Substring(0, img.Length - 1) : img;
                        _sb.Append("document.write('<a title=\"" + dr["title"] + "\"");

                        if (!string.IsNullOrEmpty(dr["linkurl"].ToString()))
                        {
                            _sb.Append("href=\"" + dr["linkurl"] + "\">');");
                        }
                        else
                        {
                            _sb.Append("\">');");
                        }
                        context.Response.Write(_sb.ToString());
                        context.Response.Write("document.write('<img src=\"" + string.Format(EnFilePath.Ad, dr["id"].ToString(), EnFilePath.Thumb) + img + "\" width=" + aModel.width + " height=" + aModel.height + " border=0 alt=\"" + dr["title"] + "\" />');");
                        context.Response.Write("document.write('</a>');");
                    }
                    else
                    {
                        context.Response.Write("document.write('<ul>');\n");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //如果超出限制广告数量，则退出循环
                            //if (i >= aModel.AdNum)
                            //    break;
                            DataRow dr = dt.Rows[i];
                            context.Response.Write("document.write('<li>');");
                            _sb.Append("document.write('<a title=\"" + dr["title"] + "\" ");
                            if (!string.IsNullOrEmpty(dr["linkurl"].ToString()))
                            {
                                _sb.Append("  href=\"" + dr["linkurl"] + "\">');");
                            }
                            else
                            {
                                _sb.Append("\">');");
                            }

                            context.Response.Write("document.write('<img src=\"" + dr["imgurl"] + "\" width=" + aModel.width + " height=" + aModel.height + " border=0  alt=\"" + dr["title"] + "\" />');");
                            context.Response.Write("document.write('</a>');\n");
                            context.Response.Write("document.write('</li>');\n");
                        }
                        context.Response.Write("document.write('</ul>');\n");
                    }
                    break;
                case (int)EnumAdvertisementinType.动画广告: //幻灯片
                    StringBuilder picTitle = new StringBuilder();
                    StringBuilder picUrl = new StringBuilder();
                    StringBuilder picLink = new StringBuilder();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //如果超出限制广告数量，则退出循环
                        //if (i >= aModel.AdNum)
                        //    break;
                        DataRow dr = dt.Rows[i];
                        picUrl.Append(dr["imgurl"].ToString());
                        picLink.Append(dr["linkurl"].ToString());
                        if (i < dt.Rows.Count - 1)
                        {
                            picUrl.Append("|");
                            picLink.Append("|");
                        }
                    }
                    context.Response.Write("document.write('<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" d=scriptmain name=scriptmain codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0\" width=\"" + aModel.width + "\" height=\"" + aModel.height + "\">');\n");
                    context.Response.Write("document.write('<param name=\"movie\" value=\"" + ECommon.WebResourceUrl + "/flash/focus.swf?width=" + aModel.width + "&height=" + aModel.height + "&bigSrc=" + picUrl + "&href=" + picLink + "\">');\n");
                    context.Response.Write("document.write('<param name=\"quality\" value=\"high\">');\n");
                    context.Response.Write("document.write('<param name=\"loop\" value=\"false\">');\n");
                    context.Response.Write("document.write('<param name=\"menu\" value=\"false\">');\n");
                    context.Response.Write("document.write('<param name=\"wmode\" value=\"transparent\">');\n");
                    context.Response.Write("document.write('<embed src=\"" + ECommon.WebResourceUrl + "/flash/focus.swf?width=" + aModel.width + "&height=" + aModel.height + "&bigSrc=" + picUrl + "&href=" + picLink + "\" width=\"" + aModel.width + "\" height=\"" + aModel.height + "\" loop=\"false\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" type=\"application/x-shockwave-flash\" wmode=\"transparent\" menu=\"false\"></embed>');\n");
                    context.Response.Write("document.write('</object>');\n");
                    break;
                case (int)EnumAdvertisementinType.Flash广告: //动画
                    if (dt.Rows.Count == 1)
                    {
                        DataRow dr = dt.Rows[0];
                        context.Response.Write("document.write('<object classid=\"clsid:D27CDB6E-AE6D-11CF-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0\" width=\"" + aModel.width + "\" height=\"" + aModel.height + "\">');\n");
                        context.Response.Write("document.write('<param name=\"movie\" value=\"" + dr["flashurl"] + "\">');\n");
                        context.Response.Write("document.write('<param name=\"quality\" value=\"high\">');\n");
                        context.Response.Write("document.write('<param name=\"wmode\" value=\"transparent\">');\n");
                        context.Response.Write("document.write('<param name=\"menu\" value=\"false\">');\n");
                        context.Response.Write("document.write('<embed src=\"" + dr["linkurl"] + "\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"" + aModel.width + "\" height=\"" + aModel.height + "\" quality=\"High\" wmode=\"transparent\">');\n");
                        context.Response.Write("document.write('</embed>');\n");
                        context.Response.Write("document.write('</object>');\n");
                    }
                    else
                    {
                        context.Response.Write("document.write('<ul>');\n");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //如果超出限制广告数量，则退出循环
                            //if (i >= aModel.AdNum)
                            //    break;
                            DataRow dr = dt.Rows[i];
                            context.Response.Write("document.write('<li>');");
                            context.Response.Write("document.write('<object classid=\"clsid:D27CDB6E-AE6D-11CF-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0\" width=\"" + aModel.width + "\" height=\"" + aModel.height + "\">');\n");
                            context.Response.Write("document.write('<param name=\"movie\" value=\"" + dr["flashurl"] + "\">');\n");
                            context.Response.Write("document.write('<param name=\"quality\" value=\"high\">');\n");
                            context.Response.Write("document.write('<param name=\"wmode\" value=\"transparent\">');\n");
                            context.Response.Write("document.write('<param name=\"menu\" value=\"false\">');\n");
                            context.Response.Write("document.write('<embed src=\"" + dr["flashurl"] + "\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"" + aModel.width + "\" height=\"" + aModel.height + "\" quality=\"High\" wmode=\"transparent\">');\n");
                            context.Response.Write("document.write('</embed>');\n");
                            context.Response.Write("document.write('</object>');\n");
                            context.Response.Write("document.write('</li>');\n");
                        }
                        context.Response.Write("document.write('</ul>');\n");
                    }
                    break;
                case (int)EnumAdvertisementinType.视频广告://视频
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //如果超出限制广告数量，则退出循环
                        if (i >= 1)
                            break;
                        DataRow dr = dt.Rows[i];
                        context.Response.Write("document.write('<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0\" width=" + aModel.width + " height=" + aModel.height + " viewastext>');\n");
                        context.Response.Write("document.write('<param name=\"movie\" value=\"" + ECommon.WebResourceUrl + "/flash/Player.swf\" />');\n");
                        context.Response.Write("document.write('<param name=\"quality\" value=\"high\" />');\n");
                        context.Response.Write("document.write('<param name=\"allowFullScreen\" value=\"true\" />');\n");
                        context.Response.Write("document.write('<param name=\"FlashVars\" value=\"vcastr_file=" + dr["videourl"].ToString() + "&LogoText=www.auto.cn&BarTransparent=30&BarColor=0xffffff&IsAutoPlay=1&IsContinue=1\" />');\n");
                        context.Response.Write("document.write('</object>');\n");
                    }
                    break;
                case (int)EnumAdvertisementinType.JS代码广告://代码
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //如果超出限制广告数量，则退出循环
                        if (i >= 1)
                            break;
                        DataRow dr = dt.Rows[i];
                        StringBuilder sb = new StringBuilder(dr["adcode"].ToString());
                        sb.Replace("&lt;", "<");
                        sb.Replace("&gt;", ">");
                        sb.Replace("\"", "'");
                        context.Response.Write("document.write(\"" + sb.ToString() + "\")");
                    }
                    break;
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