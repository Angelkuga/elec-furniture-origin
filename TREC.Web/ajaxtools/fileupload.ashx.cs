using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using TREC.ECommerce;

namespace TREC.Web.ajaxtools
{
    /// <summary>
    /// fileupload 的摘要说明
    /// </summary>
    public class fileupload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string upFile = context.Request.QueryString["f"];
            string upFileType = context.Request.QueryString["t"];
            string upFileDelType = context.Request.QueryString["dt"] == null ? "" : upFileDelType = context.Request.QueryString["dt"];
            string _iswater = context.Request.QueryString["iswater"];
            if (string.IsNullOrEmpty(upFileType))
            {
                context.Response.Write("[{\"msg\":\"0\",\"msbox\":\"数据错误！\"}]");
            }


            if (upFileType == "add")
            {
                if (string.IsNullOrEmpty(upFile))
                {
                    context.Response.Write("[{\"msg\":\"0\",\"msbox\":\"文件为空,请选择要上传的文件！\"}]");
                    return;
                }

                HttpPostedFile _upfile = context.Request.Files[upFile];

                if (_upfile == null)
                {
                    context.Response.Write("[{\"msg\":\"0\",\"msbox\":\"文件为空,请选择要上传的文件！\"}]");
                    return;
                }
                if (_upfile.ContentLength > 1204 * 1204)
                {
                    context.Response.Write("[{\"msg\":\"0\",\"msbox\":\"文件太大,请上传1M以内的文件！\"}]");
                    return;
                }
                int iswater = 2;
                ECUpLoad ecUpload;
                if (!string.IsNullOrEmpty(_iswater))
                {
                    iswater = Convert.ToInt32(_iswater);
                    ecUpload = new ECUpLoad(iswater);
                }
                else
                {
                    ecUpload = new ECUpLoad();
                }



                string msg = ecUpload.fileSaveAs(_upfile, iswater);

                //返回成功信息
                context.Response.Write(msg);

            }
            else if (upFileType == "del")
            {
                if (!string.IsNullOrEmpty(upFileDelType))
                {
                    if (upFileDelType == "up")
                    {
                        if (File.Exists(HttpContext.Current.Server.MapPath("/upload/" + "/temp/" + upFile)))
                        {
                            File.Delete(HttpContext.Current.Server.MapPath("/upload/" + "/temp/" + upFile));
                            context.Response.Write("{\"msg\":\"1\",\"msbox\":\"删除成功！\"}");
                            return;
                        }
                        else
                        {
                            context.Response.Write("{\"msg\":\"0\",\"msbox\":\"文件不存在！\"}");
                            return;
                        }
                    }
                    if (upFileDelType.IndexOf("edit_") >= 0)
                    {
                        if (File.Exists(HttpContext.Current.Server.MapPath(upFileDelType.Replace("edit_", "") + upFile)))
                        {
                            File.Delete(HttpContext.Current.Server.MapPath(upFileDelType.Replace("edit_", "") + upFile));
                            context.Response.Write("{\"msg\":\"1\",\"msbox\":\"删除成功！\"}");
                            return;
                        }
                        else
                        {
                            context.Response.Write("{\"msg\":\"0\",\"msbox\":\"文件不存在！\"}");
                            return;
                        }
                    }
                }
            }


            context.Response.End();
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