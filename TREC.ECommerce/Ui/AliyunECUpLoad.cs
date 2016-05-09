using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using TRECommon;
using TREC.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using Aliyun.OpenServices.OpenStorageService;

namespace TREC.ECommerce.Ui
{
   public class AliyunECUpLoad
    {
       //    private FordioB2B.Config.ThumbnailInfo thumbnailInfo;
        //    private FordioB2B.Config.SystemInfo systemInfo;
        private string filePath; //上传目录名
        private readonly string fileType; //文件类型
        private readonly int fileSize; //文件大小0为不限制
        private readonly int isWatermark; //0为不加水印，1为文字水印，2为图片水印
        private readonly int waterStatus; //水印位置
        private readonly int waterQuality; //水印图片质量
        private readonly string imgWaterPath; //水印图片地址
        private readonly int waterTransparency; //水印图片透时度
        private readonly string textWater; //水印文字
        private readonly string textWaterFont; //文字水印字体
        private readonly int textFontSize; //文字大小
        #region 上传图片的规格
        public int[] _550_410 = { 550, 410 };
        public int[] _230_173 = { 230, 173 };
        public int[] _1_1 = { 1, 1 };
        public int[] _767_400 = { 767, 400 };
        public int[] _196_70 = { 196, 70 };
        public int[] _141_106 = { 141, 106 };
        public int[] _750_2000 = { 750, 2000 };
        public int[] _992_2000 = { 992, 2000 };
        public int[] _174_188 = { 174, 188 }; 
        #endregion


        #region 压缩和生产固定大小的参数
        public Image ResourceImage;
        private int ImageWidth;
        private int ImageHeight;
        public string ErrorMessage;
        #endregion

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

        public AliyunECUpLoad()
        {
            #region 注释
            //webset = new DtCms.BLL.WebSet().loadConfig(Utils.GetXmlMapPath("Configpath"));
            //thumbnailInfo = FordioB2B.Config.ThumbnailConfigs.GetConfig();
            //systemInfo = FordioB2B.Config.SystemConfigs.GetConfig();
            //filePath = systemInfo.WebPath + thumbnailInfo.WebFilePath;
            //fileType = thumbnailInfo.WebFileType;
            //fileSize = thumbnailInfo.WebFileSize;
            //isWatermark = thumbnailInfo.IsWatermark;
            //waterStatus = thumbnailInfo.WatermarkStatus;
            //waterQuality = thumbnailInfo.ImgQuality;
            //imgWaterPath = systemInfo.WebPath + thumbnailInfo.ImgWaterPath;
            //waterTransparency = thumbnailInfo.ImgWaterTransparency;
            //textWater = thumbnailInfo.WaterText;
            //textWaterFont = thumbnailInfo.WaterFont;
            //textFontSize = thumbnailInfo.FontSize;
            #endregion

            filePath = "/upload/";
            fileType = "doc|jpg|gif|png|jpeg";
            fileSize = 6000000;
            isWatermark = 2;
            waterStatus = 9;
            waterQuality = 50;
            imgWaterPath = "/upload/Water/4324a072.png";
            waterTransparency = 3;
            textWater = "";
            textWaterFont = "";
            textFontSize = 12;
        }

        public AliyunECUpLoad(int isWater)
        {
            #region 注释
            //webset = new DtCms.BLL.WebSet().loadConfig(Utils.GetXmlMapPath("Configpath"));
            //thumbnailInfo = FordioB2B.Config.ThumbnailConfigs.GetConfig();
            //systemInfo = FordioB2B.Config.SystemConfigs.GetConfig();
            //filePath = systemInfo.WebPath + thumbnailInfo.WebFilePath;
            //fileType = thumbnailInfo.WebFileType;
            //fileSize = thumbnailInfo.WebFileSize;
            //isWatermark = thumbnailInfo.IsWatermark;
            //waterStatus = thumbnailInfo.WatermarkStatus;
            //waterQuality = thumbnailInfo.ImgQuality;
            //imgWaterPath = systemInfo.WebPath + thumbnailInfo.ImgWaterPath;
            //waterTransparency = thumbnailInfo.ImgWaterTransparency;
            //textWater = thumbnailInfo.WaterText;
            //textWaterFont = thumbnailInfo.WaterFont;
            //textFontSize = thumbnailInfo.FontSize;
            #endregion

            filePath = "/upload/";
            fileType = "doc|jpg|gif|png|jpeg";
            fileSize = 6000000;
            isWatermark = isWater;
            waterStatus = 9;
            waterQuality = 50;
            imgWaterPath = "/upload/Water/4324a072.png";
            waterTransparency = 3;
            textWater = "";
            textWaterFont = "";
            textFontSize = 12;
        }
        /// <summary>
        /// 新的上传方法
        /// </summary>
        /// <param name="_postedFile"></param>
        /// <param name="_isWater"></param>
        /// <returns></returns>
        //public string fileSaveAs(HttpPostedFile _postedFile, int _isWater)
        //{
        //    //检查保存的路径 是否有/开头结尾
        //    //**if (this.filePath.StartsWith("/") == false) this.filePath = "/" + this.filePath;
        //    //**if (this.filePath.EndsWith("/") == false) this.filePath = this.filePath + "/";

        //    return fileSaveAs(_postedFile, _isWater);
        //}
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
        /// 新的上传方法
        /// </summary>
        /// <param name="_postedFile"></param>
        /// <param name="_isWater"></param>
        /// <param name="savePath"></param>
        /// <param name="IsReducedImage">是否压缩</param>
        /// <param name="Percent">压缩比例</param>
        /// <param name="w">宽</param>
        /// <param name="h">高</param>
        /// <returns></returns>
        public string fileSaveAs(HttpPostedFile _postedFile, int _isWater)
        {
            string returnpath = string.Empty;
            try
            {
              

                string _fileExt = _postedFile.FileName.Substring(_postedFile.FileName.LastIndexOf(".") + 1);
                //验证合法的文件
                if (!CheckFileExt(this.fileType, _fileExt))
                {
                    return "{\"msg\": \"0\", \"msbox\": \"不允许上传" + _fileExt + "类型的文件！\"}";
                }
                if (this.fileSize > 0 && _postedFile.ContentLength > fileSize * 1024)
                {
                    return "{\"msg\": \"0\", \"msbox\": \"文件超过限制的大小啦！\"}";
                }

                #region 设置存储目录

                //随机数
                Random ro = new Random();
                string weiname = ro.Next(1111, 9999).ToString();
                string fileNameMin = DateTime.Now.ToString("yyyyMMddHHmmssff") + weiname;
                string _fileName = fileNameMin + "." + _fileExt; //随机文件名
                //检查保存的路径 是否有/开头结尾
                if (this.filePath.StartsWith("/") == false) this.filePath = "/" + this.filePath;
                if (this.filePath.EndsWith("/") == false) this.filePath = this.filePath + "/";

                //按日期归类保存
                //string _datePath = DateTime.Now.ToString("yyyyMMdd") + "/";

               
           

                #endregion

                //保存文件
               
                
                #region 是否打图片水印
               
                if (isWatermark >0 && CheckFileExt("BMP|JPEG|JPG|GIF|PNG|TIFF", _fileExt))
                {
                    //if (!Directory.Exists(savePath + "/water/"))
                    //{
                    //    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(savePath + "/water/"));
                    //}

                    Stream _fileal=_postedFile.InputStream;
                    byte[] bytes = new byte[_fileal.Length];
                     _fileal.Read(bytes, 0, bytes.Length);
                      _fileal.Seek(0, SeekOrigin.Begin);

                     Stream _stream;
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes))
                    {
                    System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);

                    ms.Flush();
                    _stream = ImageWaterMark.AddImageSignPic(returnImage, this.imgWaterPath, waterStatus, waterQuality, waterTransparency);
                    }
                    if (_stream == null)
                    {
                        returnpath = SendImgToAliyun(_postedFile.InputStream, _fileExt);
                    }
                    else
                    {
                        returnpath = SendImgToAliyun(_stream, _fileExt);
                    }

                }
                else
                {
                  returnpath=SendImgToAliyun(_postedFile.InputStream, _fileExt);
                }
                #endregion
                return "{\"msg\": \"1\", \"msbox\": \"" + returnpath + "\",\"path\":\"" + returnpath + "\"}";
            }
            catch (Exception ex)
            {
                return "{\"msg\": \"0\", \"msbox\": \"上传过程中发生意外错误！" + ex.Message + "\",\"path\":\"" + returnpath + "\"}";
            }
        }

        /// <summary>
        /// 是否需要压缩
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="_fileNameNew"></param>
        /// <returns></returns>
        public bool ReducedImageAdd(int w, int h, string _fileNameNew)
        {
            string IsWorH = "";//以什么标准来缩
            double Percent = 1;
            int width = ResourceImage.Width;
            int height = ResourceImage.Height;
            if (width > w || height > h)
            {
                //以h为标准来压缩
                if (((double)w / (double)width) > ((double)h / (double)height))
                {
                    IsWorH = "H";//用高为标准来压缩
                }
                else
                {
                    IsWorH = "W";//用宽为标准来压缩
                }

                //宽大于标准，高小于标准
                if (width > w && height < h)
                {
                    Percent = (double)w / (double)width;
                }
                //宽大于标准，高大于标准
                else if (width > w && height > h)
                {
                    if (IsWorH == "H") Percent = (double)h / (double)height;
                    else Percent = (double)w / (double)width;
                }
                //宽小于标准，高大于标准
                else if (width <= w && height > h)
                {
                    Percent = (double)h / (double)height;
                }
                string[] ss = _fileNameNew.Split('.');
                string _ss = "jpg";
                if (ss.Length >= 2)
                {
                    _ss = ss[ss.Length - 1];
                }
                return ReducedImage(Percent, _fileNameNew, _ss);//0.6表示缩小60%
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 检查是否为合法的上传文件
        /// </summary>
        /// <returns></returns>
        private bool CheckFileExt(string _fileType, string _fileExt)
        {
            string[] allowExt = _fileType.Split('|');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i].ToLower() == _fileExt.ToLower()) { return true; }
            }
            return false;
        }

        /// <summary>
        /// New
        /// </summary>
        /// <param name="tempFileName"></param>
        /// <param name="destination"></param>
        public void MoveFiles(string tempFileName, string destination)
        {
            ArrayList alst1 = new ArrayList();
            alst1.Add(_1_1);
            MoveFiles(tempFileName, destination, alst1, alst1, true);
        }

        /// <summary>
        /// 移动文件 从临时上传目录移动到 
        /// </summary>
        /// <param name="tempFileName">临时文件夹要移动的文件名</param>
        /// <param name="destination">目的目录</param>
        /// <param name="W_H">压缩的规格</param>
        /// <param name="wh">改变固定大小的规格</param>
        /// <param name="IsNo">是否要原图，true要，false不要</param>
        public void MoveFiles(string tempFileName, string destination, ArrayList alst1, ArrayList alst2, bool IsNo)
        {
            //检查保存的路径 是否有/开头结尾
            if (this.filePath.StartsWith("/") == false) this.filePath = "/" + this.filePath;
            if (this.filePath.EndsWith("/") == false) this.filePath = this.filePath + "/";
            string tempPath = HttpContext.Current.Server.MapPath(this.filePath + "temp/");

            if (destination.StartsWith("/") == false) destination = "/" + destination;
            if (destination.EndsWith("/") == false) destination = destination + "/";

            string tempFileFullName = tempPath + tempFileName;
            string destinationFullName = HttpContext.Current.Server.MapPath(destination) + tempFileName;

            //如果临时目录存在文件
            if (System.IO.File.Exists(tempFileFullName))
            {
                #region
                if (System.IO.File.Exists(destinationFullName))
                {
                    System.IO.File.Delete(destinationFullName);
                }
                else
                {
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(destination)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(destination));

                        if (!Directory.Exists(HttpContext.Current.Server.MapPath(destination + "/0/")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(destination + "/0/"));
                        }

                    }
                }
                //新增的图片
                //压缩图片
                ResourceImage = Image.FromFile(tempFileFullName);
                bool IsYes = true;
                if (alst1.Count > 0)//是否压缩
                {
                    int p = 0;
                    foreach (int[] W_H in alst1)
                    {
                        #region 获取名字
                        string _NewFileName = destinationFullName; //HttpContext.Current.Server.MapPath(destination);
                        if (p != 0)
                        {
                            _NewFileName = HttpContext.Current.Server.MapPath(destination);
                            if (tempFileName.IndexOf(".") > 0)
                            {
                                string[] img1 = tempFileName.Split('.');
                                _NewFileName += img1[0] + "_" + W_H[0] + "-" + W_H[1] + "." + img1[img1.Length - 1];
                            }
                        }
                        #endregion

                        if (W_H[0] > 1 && W_H[1] > 1)
                        {
                            if (ResourceImage == null)
                            { ResourceImage = Image.FromFile(tempFileFullName); }
                            ReducedImageAdd(W_H[0], W_H[1], _NewFileName);//压缩
                            IsYes = false;
                        }
                        else
                        {
                            IsNo = true; IsYes = true;
                        }
                        p++;
                    }
                }

                if (alst2.Count > 0)//是否生产固定图片
                {
                    int p = 0;
                    foreach (int[] wh in alst2)
                    {
                        if (wh[0] > 1 && wh[1] > 1)
                        {
                            #region 获取名字
                            string _NewFileName = destinationFullName; //HttpContext.Current.Server.MapPath(destination);
                            if (p != 0)
                            {
                                _NewFileName = HttpContext.Current.Server.MapPath(destination);
                                if (tempFileName.IndexOf(".") > 0)
                                {
                                    string[] img1 = tempFileName.Split('.');
                                    _NewFileName += img1[0] + "_" + wh[0] + "-" + wh[1] + "." + img1[img1.Length - 1];
                                }
                            }
                            #endregion

                            ReducedImage(wh[0], wh[1], _NewFileName);
                            IsYes = false;
                        }
                        else
                        {
                            IsNo = true; IsYes = true;
                        }
                    }
                }
                if (IsNo && IsYes && File.Exists(tempFileFullName) && !File.Exists(destinationFullName))
                {
                    ResourceImage.Dispose();
                    System.IO.File.Move(tempFileFullName, destinationFullName);
                }
                //清除临时图片
                if (System.IO.File.Exists(tempFileFullName))
                {
                    ResourceImage.Dispose();
                    System.IO.File.Delete(tempFileFullName);
                }
                #endregion
            }
            else
            {
                if (Directory.Exists(HttpContext.Current.Server.MapPath(destination + "/0/")))
                {
                    DirectoryInfo info = new DirectoryInfo(HttpContext.Current.Server.MapPath(destination + "/0/"));
                    FileInfo[] _FileInfo = info.GetFiles();//获得目录
                    foreach (FileInfo fileinfo in _FileInfo)
                    {
                        System.IO.File.Move(HttpContext.Current.Server.MapPath(destination + "/0/") + fileinfo.Name, HttpContext.Current.Server.MapPath(destination) + fileinfo.Name);
                    }
                }

                //if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(destination + "/0/") + tempFileName))
                //{
                //    System.IO.File.Move(HttpContext.Current.Server.MapPath(destination + "/0/") + tempFileName, destinationFullName);
                //}

            }
        }

        /// <summary>
        /// New批量移动
        /// </summary>
        /// <param name="arrTempFileName">数组文件名列表</param>
        /// <param name="destination">目标目录</param>
        public void MoveFiles(string[] arrTempFileName, string destination)
        {
            ArrayList alst1 = new ArrayList();
            alst1.Add(_1_1);
            MoveFiles(arrTempFileName, destination, alst1, alst1, true);
        }

        /// <summary>
        /// 批量移动
        /// </summary>
        /// <param name="arrTempFileName">数组文件名列表</param>
        /// <param name="destination">目标目录</param>
        public void MoveFiles(string[] arrTempFileName, string destination, ArrayList alst1, ArrayList alst2, bool IsNo)
        {
            //如果文件夹存在 说明己增加过文件。并且 "0" 文件夹临时文件夹存在
            //该方法主要解决 当缩略图文件夹或其它文件夹 己存在文件时 这时更新 缩略图 是重新即时上传模式。 临时文件夹temp有文件。  
            //则会执行 将temp文件移动到该文件夹。该文件夹原有文件。也会存在。下方法在该文件夹新建临时 “0” 存放过时或用过的文件。

            if (Directory.Exists(HttpContext.Current.Server.MapPath(destination)))
            {
                //判断 "0" 文件夹临时文件夹存在 0则存在则更新。。只更新要改改的。
                if (Directory.Exists(HttpContext.Current.Server.MapPath(destination + "/0/")))
                {
                    //判断是否有文件

                    if (Directory.GetFiles(HttpContext.Current.Server.MapPath(destination)).Length > 0)
                    {
                        ////因不更新的文件不会在temp文件夹存在。所以跳过。只将要更新的文件存在当前目录
                        //foreach (string s in Directory.GetFiles(HttpContext.Current.Server.MapPath(destination)))
                        //{
                        //    //Directory.GetFiles(HttpContext.Current.Server.MapPath(destination))
                        //}



                        foreach (string s in Directory.GetFiles(HttpContext.Current.Server.MapPath(destination)))
                        {
                            //如果移动目标文件夹存在移动文件则删除
                            if (File.Exists(HttpContext.Current.Server.MapPath(destination + "/0/" + s.Substring(s.LastIndexOf("\\") + 1, s.Length - s.LastIndexOf("\\") - 1))))
                            {
                                File.Delete(HttpContext.Current.Server.MapPath(destination + "/0/" + s.Substring(s.LastIndexOf("\\") + 1, s.Length - s.LastIndexOf("\\") - 1)));
                            }
                            //移动
                            System.IO.File.Move(s, HttpContext.Current.Server.MapPath(destination + "/0/" + s.Substring(s.LastIndexOf("\\") + 1, s.Length - s.LastIndexOf("\\") - 1)));
                        }
                    }


                }
            }


            foreach (string s in arrTempFileName)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    MoveFiles(s, destination, alst1, alst2, IsNo);

                }
            }
        }


        /// <summary>
        /// 批量移动
        /// </summary>
        /// <param name="arrTempFileName">数组文件名列表</param>
        /// <param name="destination">目标目录</param>
        public void MoveContentFiles(string[] arrTempFileName, string destination)
        {


            //检查保存的路径 是否有/开头结尾
            if (this.filePath.StartsWith("/") == false) this.filePath = "/" + this.filePath;
            if (this.filePath.EndsWith("/") == false) this.filePath = this.filePath + "/";
            string tempPath = HttpContext.Current.Server.MapPath(this.filePath + "temp/");

            if (destination.StartsWith("/") == false) destination = "/" + destination;
            if (destination.EndsWith("/") == false) destination = destination + "/";


            foreach (string s in arrTempFileName)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    string tempFileFullName = tempPath + s;
                    string destinationFullName = HttpContext.Current.Server.MapPath(destination) + s;

                    //如果临时目录存在文件该文件夹
                    if (System.IO.File.Exists(tempFileFullName))
                    {
                        if (System.IO.File.Exists(destinationFullName))
                        {
                            System.IO.File.Delete(destinationFullName);
                        }
                        else
                        {
                            if (!Directory.Exists(HttpContext.Current.Server.MapPath(destination)))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(destination));
                            }
                        }
                        System.IO.File.Move(tempFileFullName, destinationFullName);
                    }

                }
            }
        }

        #region 压缩和生产固定大小图片
        public bool ThumbnailCallback()
        {
            return false;
        }

        /// <summary>
        /// 按照固定大小生产图片
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="targetFilePath"></param>
        /// <returns></returns>
        public bool ReducedImage(int Width, int Height, string targetFilePath)
        {
            try
            {
                Image ReducedImage;
                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                ReducedImage = ResourceImage.GetThumbnailImage(Width, Height, callb, IntPtr.Zero);
                ReducedImage.Save(@targetFilePath);
                ReducedImage.Dispose();
                return true;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 按百分比  缩小60% Percent为0.6 targetFilePath为目标路径
        /// </summary>
        /// <param name="Percent"></param>
        /// <param name="targetFilePath"></param>
        /// <returns></returns>
        public bool ReducedImage(double Percent, string targetFilePath, string filename)
        {
            try
            {
                Image ReducedImage;
                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                ImageWidth = Convert.ToInt32(ResourceImage.Width * Percent);
                ImageHeight = (ResourceImage.Height) * ImageWidth / ResourceImage.Width;//等比例缩放
                //ReducedImage = ResourceImage.GetThumbnailImage(ImageWidth, ImageHeight, callb, IntPtr.Zero);
                //ReducedImage.Save(@targetFilePath);
                //ReducedImage.Dispose();
                if (!string.IsNullOrEmpty(filename))
                {
                    MakeThumbnail(targetFilePath, ImageWidth, ImageHeight, "", filename);
                }
                return true;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return false;
            }
        }
        #endregion


        /**/
        //// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param> 
        public void MakeThumbnail(string thumbnailPath, int width, int height, string mode, string weiName)
        {
            int towidth = width;
            int toheight = height;
            int x = 0;
            int y = 0;
            int ow = ResourceImage.Width;
            int oh = ResourceImage.Height;

            #region 类型
            #endregion

            //新建一个bmp图片
            Image bitmap = new Bitmap(towidth, toheight);
            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);

            //清空画布并以透明背景色填充
            g.Clear(Color.White);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(ResourceImage, new Rectangle(0, 0, towidth, toheight),
            new Rectangle(0, 0, ow, oh),
            GraphicsUnit.Pixel);

            try
            {
                switch (weiName.ToLower())
                {
                    case "jpg":
                    case "jpeg":
                        bitmap.Save(thumbnailPath, ImageFormat.Jpeg);
                        break;
                    case "gif":
                        bitmap.Save(thumbnailPath, ImageFormat.Gif);
                        break;
                    case "bmp":
                        bitmap.Save(thumbnailPath, ImageFormat.Bmp);
                        break;
                    case "png":
                        bitmap.Save(thumbnailPath, ImageFormat.Png);
                        break;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                bitmap.Dispose();
                g.Dispose();
            }
        }
    }
}
