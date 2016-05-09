using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Web.Code;
using System.IO;

namespace TREC.Web.template.web
{
	public partial class SJupfile : System.Web.UI.Page
	{
        public string filePath = string.Empty;
        public string ParentTxtName;
        AliyunImg img = new AliyunImg();
        public string requestFile = string.Empty;
        public string showtxt = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["showtxt"] != null)
            {
                showtxt = Request["showtxt"];
            }
        }

        protected void bnt_upfile_Click(object sender, EventArgs e)
        {
            string ExtenName = "|.JPG|.JPEG|.GIF|.PNG|".ToUpper();
            string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName).ToUpper(); //获取扩展名
            string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName); //获取文件名（不包括扩展名）

            if (ExtenName.Contains("|" + Extension + "|"))
            {
                // filePath = requestFile + fileName + "_" + DateTime.Now.ToString("yyMMddhhmmss") + Extension;
                //  FileUpload1.SaveAs(Server.MapPath(filePath));
                string filetye = Path.GetExtension(FileUpload1.PostedFile.FileName).ToUpper(); //获取扩展名

                filePath = img.SendImgToAliyun(FileUpload1.FileContent, filetye);
               // Response.Write(filePath);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "T2", "alert('上传图片格式有误');", true);
            }
        }
	}
}