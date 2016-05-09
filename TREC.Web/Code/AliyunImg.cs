using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aliyun.OpenServices.OpenStorageService;
using System.IO;
using System.Drawing;
using System.Net;
namespace TREC.Web.Code
{
    public class AliyunImg
    {


        public string accessId = "nEx8ZQsDbO0OKMCf";
        public string accessKey = "sV8PswJ3MzkKzwYv7JuvNvcnkIo6dX";
        public string BucketName = "jiajuks";

        public string imgurl = "http://jiajuks.oss-cn-hangzhou.aliyuncs.com/";

        public string imgPath = DateTime.Now.Year + "_" + DateTime.Now.Month + "/";
        private char[] constant =   
      {   
        '0','1','2','3','4','5','6','7','8','9',  
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
         'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
      };
        public string GenerateRandomNumber(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }

        public string Guid
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMddHHmmssfff") + GenerateRandomNumber(5);
            }
        }
        /// <summary>
        /// 图片缩略图
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public Stream ImgSL(byte[] buf, int width)
        {

            System.IO.Stream Restream;
            MemoryStream ms = new MemoryStream(buf);
            System.Drawing.Image imgy = System.Drawing.Image.FromStream(ms);
            int w = imgy.Width;
            int h = imgy.Height;
            int height = (int)((float)h * ((float)width / (float)w));
            System.Drawing.Image img = new System.Drawing.Bitmap(imgy, width, height);

            MemoryStream mssl = new MemoryStream();
            img.Save(mssl, imgy.RawFormat);
            byte[] bysl = mssl.ToArray();//缩略流

            Restream = new System.IO.MemoryStream(bysl);
            return Restream;

            //string pic = Convert.ToBase64String(bysl);

            //return pic;
        }
        public Stream ImgSL22(byte[] buf, int width)
        {

            System.IO.Stream Restream;
            MemoryStream ms = new MemoryStream(buf);
            System.Drawing.Image img1 = System.Drawing.Image.FromStream(ms);
            int w = img1.Width;
            int h = img1.Height;
            int height = (int)((float)h * ((float)width / (float)w));

            System.Drawing.Image hb = new System.Drawing.Bitmap(width, height);//创建图片对象
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(hb);//创建画板并加载空白图像
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//设置保真模式为高度保真
            g.DrawImage(img1, new Rectangle(0, 0, width, height), 0, 0, img1.Width, img1.Height, GraphicsUnit.Pixel);//开始画图
            MemoryStream mssl = new MemoryStream();
            hb.Save(mssl, img1.RawFormat);
            g.Dispose();
            hb.Dispose();
            img1.Dispose();

            byte[] bysl = mssl.ToArray();//缩略流

            Restream = new System.IO.MemoryStream(bysl);
            return Restream;
        }

        public Stream getImg(string url, ref byte[] getbuf)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AllowAutoRedirect = true;

            WebProxy proxy = new WebProxy();
            proxy.BypassProxyOnLocal = true;
            proxy.UseDefaultCredentials = true;

            request.Proxy = proxy;

            WebResponse response = request.GetResponse();
            System.IO.Stream Restream;


            using (Stream stream = response.GetResponseStream())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    int imgLong = (int)response.ContentLength;
                    Byte[] buffer = new Byte[imgLong];
                    int current = 0;
                    while ((current = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        ms.Write(buffer, 0, current);
                    }
                    // rems = ms;
                    getbuf = ms.ToArray();
                    Restream = new System.IO.MemoryStream(ms.ToArray());
                    //return ms.ToArray();
                }
            }
            return Restream;
            // return rems;
        }

        /// <summary>
        /// 验证扩展名
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public string getImgKz(string img)
        {
            List<string> _list = new List<string>();
            _list.Add("BMP");
            _list.Add("JPG");
            _list.Add("JPEG");
            _list.Add("PNG");
            _list.Add("GIF");

            if (_list.Contains(img.ToUpper()))
            {
                return img;
            }
            else
            {
                return "JPG".ToLower();
            }
        }
        /// <summary>
        /// 通过流的方式向阿里云上传图片
        /// </summary>
        /// <param name="_stream"></param>
        /// <param name="filetype"></param>
        /// <returns></returns>
        public string SendImgToAliyun(Stream _stream, string filetype)
        {
            filetype = getImgKz(filetype.Replace(".", ""));


            string firstName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + GenerateRandomNumber(3);
            string fullName = imgPath + firstName + "." + filetype;

            ObjectMetadata metadata = new ObjectMetadata();
            // 可以设定自定义的metadata。
            metadata.ContentType = "image/" + filetype; //FileUpload2.PostedFile.ContentType;
            OssClient ossClient = new OssClient(accessId, accessKey);

            var ret = ossClient.PutObject(BucketName, fullName, _stream, metadata);
            return imgurl + fullName;
        }


        /// <summary>
        /// 通过Url的方式向阿里云上传图片
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string SendImgToAliyun(string url)
        {
            string firstName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + GenerateRandomNumber(3);
            string filetype = url.Split('.')[url.Split('.').Length - 1];
            filetype = getImgKz(filetype);
            // string lastName = Path.GetExtension(FileUpload2.FileName);
            string fullName = imgPath + firstName + "." + filetype;

            // if (!string.IsNullOrEmpty(c.prefix))
            //   fullName = c.prefix + "/" + fullName;b
            ObjectMetadata metadata = new ObjectMetadata();
            // 可以设定自定义的metadata。
            metadata.ContentType = "image/" + filetype; //FileUpload2.PostedFile.ContentType;
            OssClient ossClient = new OssClient(accessId, accessKey);
            byte[] getbuf = null;
            Stream imgBig = getImg(url, ref getbuf);
            // Stream imgsl = ImgSL(getbuf, 100);
            var ret = ossClient.PutObject(BucketName, fullName, imgBig, metadata);


            return imgurl + fullName;
        }
        /// <summary>
        /// 通过Url生成缩略图
        /// </summary>
        /// <param name="url"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public string SendImgToAliyun(string url, int width)
        {
            string firstName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + GenerateRandomNumber(3);
            string filetype = url.Split('.')[url.Split('.').Length - 1];
            filetype = getImgKz(filetype);
            string fullName = imgPath + firstName + "." + filetype;

            ObjectMetadata metadata = new ObjectMetadata();
            // 可以设定自定义的metadata。
            metadata.ContentType = "image/" + filetype; //FileUpload2.PostedFile.ContentType;
            OssClient ossClient = new OssClient(accessId, accessKey);
            byte[] getbuf = null;
            Stream imgBig = getImg(url, ref getbuf);
            Stream imgsl = ImgSL(getbuf, width);

            var retsl = ossClient.PutObject(BucketName, fullName, imgsl, metadata);

            return imgurl + fullName;
        }

        public string SendImgToAliyun(string filetype, Stream imgStream)
        {
            filetype = getImgKz(filetype);
            string firstName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + GenerateRandomNumber(3);

            string fullName = imgPath + firstName + "." + filetype;

            // if (!string.IsNullOrEmpty(c.prefix))
            //   fullName = c.prefix + "/" + fullName;
            ObjectMetadata metadata = new ObjectMetadata();
            // 可以设定自定义的metadata。
            metadata.ContentType = "image/" + filetype; //FileUpload2.PostedFile.ContentType;
            OssClient ossClient = new OssClient(accessId, accessKey);

            var ret = ossClient.PutObject(BucketName, fullName, imgStream, metadata);


            return imgurl + fullName;
        }

        public string AddImg(string url)
        {
            string firstName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string filetype = url.Split('.')[url.Split('.').Length - 1];
            // string lastName = Path.GetExtension(FileUpload2.FileName);
            string fullName = firstName + "_big." + filetype;
            string fullNamesl = firstName + "_sl." + filetype;
            // if (!string.IsNullOrEmpty(c.prefix))
            //   fullName = c.prefix + "/" + fullName;
            ObjectMetadata metadata = new ObjectMetadata();
            // 可以设定自定义的metadata。
            metadata.ContentType = "image/" + filetype; //FileUpload2.PostedFile.ContentType;
            OssClient ossClient = new OssClient(accessId, accessKey);
            byte[] getbuf = null;
            Stream imgBig = getImg(url, ref getbuf);
            Stream imgsl = ImgSL(getbuf, 100);
            var ret = ossClient.PutObject(BucketName, fullName, imgBig, metadata);
            var retsl = ossClient.PutObject(BucketName, fullNamesl, imgsl, metadata);


            return "原图地址： http://2014zdt.oss-cn-hangzhou.aliyuncs.com/" + fullName + "<br/>缩略图地址：" + "   http://2014zdt.oss-cn-hangzhou.aliyuncs.com/" + fullNamesl;
        }
    }
}