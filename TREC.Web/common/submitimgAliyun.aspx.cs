using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Web.Code;
using System.IO;

namespace TREC.Web.common
{
    public partial class submitimgAliyun : System.Web.UI.Page
    {
        public string filePath = string.Empty;
        public string ParentTxtName;
        AliyunImg img = new AliyunImg();
        public string requestFile = string.Empty;
        public string showtxt = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bnt_bd_Click(object sender, EventArgs e)
        {
            string ExtenName = "|.JPG|.JPEG|.GIF|.PNG|".ToUpper();
            string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName).ToUpper(); //获取扩展名
            string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName); //获取文件名（不包括扩展名）

            if (ExtenName.Contains("|" + Extension + "|"))
            {

                string filetye = Path.GetExtension(FileUpload1.PostedFile.FileName).ToUpper(); //获取扩展名
                filePath = img.SendImgToAliyun(FileUpload1.FileContent, filetye);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "T2", "alert('上传图片格式有误');", true);
            }
        }

        protected void bnt_yc_Click(object sender, EventArgs e)
        {
            filePath = img.SendImgToAliyun(txt_yc.Text.Trim());
        }
    }
}