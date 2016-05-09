using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Config;
using System.Web;
using System.IO;

namespace TREC.Entity
{
    public class EnFilePath
    {
        protected static string resource = WebConfigs.GetConfig().WebUrl + "/";
        protected static string resourceimg = WebConfigs.GetConfig().WebImgUrl;
        protected static string _company = "";
        protected static string _dealer = "";
        protected static string _shop = "";
        protected static string _market = "";
        protected static string _brand = "";
        protected static string _article = "";
        protected static string _articlecategory = "";
        protected static string _promotion = "";
        protected static string _groupon = "";
        protected static string _product = "";
        protected static string _productcategory = "";
        protected static string _productattribute = "";
        protected static string _ad = "";
        protected static string _apppromotionbrand = "";
        protected static string _productgroup = "";

        public static string Thumb = "thumb";
        public static string Surface = "surface";

        public static string Chairman = "chairman";
        public static string MarketClique = "marketclique";
        public static string MarketCliqueThumb = "marketcliquethumb";

        public static string Logo = "logo";
        public static string Banner = "banner";
        public static string DesImage = "desimage";
        public static string HomePageImg = "homepageimg";
        public static string ConImage = "conimage";
        public static string ProductAttributeColorImg = "productcolor";

        public static string License = "license";
        public static string Registration = "registration";
        public static string Organization = "organization";
        public static string Dbook = "dbook";

        public static string fileRootPath = "/upload";//"/upload";
        public static string tmpRootPath = "/upload/temp/";


        public static string Company
        {
            get
            {
                if (_company == "")
                    return fileRootPath + "/company/{1}/{0}/";
                return _company;
            }
            set { _company = value; }
        }

        public static string Dealer
        {
            get
            {
                if (_dealer == "")
                    return fileRootPath + "/dealer/{1}/{0}/";
                return _dealer;
            }
            set { _dealer = value; }
        }

        public static string Shop
        {
            get
            {
                if (_shop == "")
                    return fileRootPath + "/shop/{1}/{0}/";
                return _shop;
            }
            set { _shop = value; }
        }

        public static string Market
        {
            get
            {
                if (_market == "")
                    return fileRootPath + "/market/{1}/{0}/";
                return _market;
            }
            set { _market = value; }
        }

        public static string MarketStorey
        {
            get
            {
                if (_market == "")
                    return fileRootPath + "/marketstorey/{1}/{0}/";
                return _market;
            }
            set { _market = value; }
        }

        public static string Brand
        {
            get
            {
                if (_brand == "")
                    return fileRootPath + "/brand/{1}/{0}/";
                return _brand;
            }
            set { _brand = value; }
        }

        public static string Brands
        {
            get
            {
                if (_brand == "")
                    return fileRootPath + "/brands/{1}/{0}/";
                return _brand;
            }
            set { _brand = value; }
        }

        public static string Article
        {
            get
            {
                if (_article == "")
                    return fileRootPath + "/article/{1}/{0}/";
                return _article;
            }
            set { _article = value; }
        }

        public static string ArticleCategory
        {
            get
            {
                if (_articlecategory == "")
                    return fileRootPath + "/articlecategory/{1}/{0}/";
                return _articlecategory;
            }
            set { _articlecategory = value; }
        }

        public static string Promotion
        {
            get
            {
                if (_promotion == "")
                    return fileRootPath + "/promotion/{1}/{0}/";
                return _promotion;
            }
            set { _promotion = value; }
        }


        public static string PromotionDef
        {
            get
            {
                if (_promotion == "")
                    return fileRootPath + "/promotiondef/{1}/{0}/";
                return _promotion;
            }
            set { _promotion = value; }
        }

        public static string Aggregation
        {
            get
            {
                if (_promotion == "")
                    return fileRootPath + "/aggregation/{1}/{0}/";
                return _promotion;
            }
            set { _promotion = value; }
        }

        public static string Groupon
        {
            get
            {
                if (_groupon == "")
                    return fileRootPath + "/groupon/{1}/{0}/";
                return _groupon;
            }
            set { _groupon = value; }
        }

        public static string Product
        {
            get
            {
                if (_product == "")
                    return fileRootPath + "/product/{1}/{0}/";
                return _product;
            }
            set { _product = value; }
        }

        public static string ProductCategory
        {
            get
            {
                if (_productcategory == "")
                    return fileRootPath + "/productcategory/{1}/{0}/";
                return _productcategory;
            }
            set { _productcategory = value; }
        }

        public static string ProductAttribute
        {
            get
            {
                if (_productattribute == "")
                    return fileRootPath + "/productcategory/{1}/{0}/";
                return _productattribute;
            }
            set { _productattribute = value; }
        }

        public static string Ad
        {
            get
            {
                if (_ad == "")
                    return fileRootPath + "/show/{1}/{0}/";
                return _ad;
            }
            set { _ad = value; }
        }

        public static string AppPromotionBrand
        {
            get
            {
                if (_apppromotionbrand == "")
                    return fileRootPath + "/apppromotionbrand/{1}/{0}/";
                return _apppromotionbrand;
            }
            set { _apppromotionbrand = value; }
        }

        /// <summary>
        /// 套组合产品图片路径
        /// </summary>
        public static string ProductGroup
        {
            get
            {
                if (_productgroup == "")
                    return fileRootPath + "/productgroup/{1}/{0}/";
                return _productgroup;
            }
            set { _productgroup = value; }
        }


        public static string GetAppPromotionBrandThumbPath(string id, string file)
        {
            return !string.IsNullOrEmpty(file) ? resource + string.Format(AppPromotionBrand, id, Banner)  + GetFile(file) : resource + "resource/web/images/noshop.jpg";
        }


        public static string GetFile(string file)
        {
            return file.Replace(",", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetFileNew(string file, string w, string h)
        {
            string[] imgstr = file.Replace(",", "").Split('.');
            if (imgstr.Length == 2)
            {
                string imgurl = imgstr[0] + "_" + w + "-" + h + "." + imgstr[1];
                return imgurl;
            }
            else
                return file.Replace(",", "");
        }

        public static string GetCompanyThumbPath(string id, string file)
        {
            return !string.IsNullOrEmpty(file) ? resource + string.Format(Company, id, Thumb).Replace("/upload", "")  + file : resource + "resource/web/images/noshop.jpg";
        }

        /// <summary>
        /// 新的工厂解析图片
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetCompanyThumbPathNew(string id, string file, string w, string h)
        {
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Company, id, Thumb).Replace("/upload", "")  + GetFileNew(file, w, h) : resource + "resource/web/images/noshop.jpg";
        }

        public static string GetCompanyBannerPath(string id, string file)
        {
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Company, id, Banner).Replace("/upload", "")  + GetFile(file) : resource + "resource/web/images/noshop.jpg";
        }

        public static string GetShopThumbPath(string id, string file)
        {
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Shop, id, Thumb).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noshop.jpg";
        }

        public static string GetAggregationThumbPath(string id, string file)
        {
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Aggregation, id, Thumb).Replace("/upload", "")  + GetFile(file) : resource + "resource/web/images/noshop.jpg";
        }

        public static string GetShopBannerPath(string id, string file)
        {
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Shop, id, Banner).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noshop.jpg";
        }

        public static string GetBrandThumbPath(string id, string file)
        {
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Brand, id, Thumb).Replace("/upload", "")  + GetFile(file) : resource + "resource/web/images/noshop.jpg";
        }

        /// <summary>
        /// 新的brand解析新图
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetBrandThumbPathNew(string id, string file, string w, string h)
        {
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Brand, id, Thumb).Replace("/upload", "")  + GetFileNew(file, w, h) : resource + "resource/web/images/noshop.jpg";
        }

        public static string GetFordioBrandLogoPath(string file)
        {

            return !string.IsNullOrEmpty(file) ? "http://www.fujiawang.com/images/brand/105_38/" + file + "_1" : resource + "resource/web/images/noshop.jpg";
        }

        public static string GetProductThumbPath(string id, string file)
        {
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Product, id, Thumb).Replace("/upload", "")  + GetFile(file) : resource + "resource/web/images/noshop.jpg";
        }

        /// <summary>
        /// 新的商品解析图片
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetProductThumbPathNew(string id, string file, string w, string h)
        {
            string rev = !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Product, id, Thumb).Replace("/upload", "") + GetFileNew(file, w, h) : resource + "resource/web/images/noshop.jpg";
            try
            {
               
                string getfile = "/upload" + string.Format(Product, id, Thumb) + GetFileNew(file, w, h);
                if (File.Exists(HttpContext.Current.Server.MapPath(getfile)))
                {


                    return rev;
                }
                else
                {
                    return GetProductThumbPath(id, file);
                }
            }
            catch
            {
                return rev;
            }
        }

        public static string GetProductBannerPath(string id, string file)
        {
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Product, id, Banner).Replace("/upload", "")  + GetFile(file) : resource + "resource/web/images/noshop.jpg";
        }
        /// <summary>
        /// 产品在首页的图
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetProductHomePageImgPath(string id, string file)
        {
            if (!string.IsNullOrEmpty(file) && file.ToLower().Contains("http://"))
            {
                return file.Replace(",", "");
            }
            else
            {
                return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Product, id, HomePageImg).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noshop.jpg";
            }
            }
        public static string GetBrandLogoPath(string id, string file)
        {
            if (!string.IsNullOrEmpty(file) && file.ToLower().Contains("http://"))
            {
                return file.Replace(",", "");
            }
            else
            {
                return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Brand, id, Logo).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noproductlistshop.gif";
            }
            }
         
        public static string GetMarketSurfacePath(string id, string file)
        {
            if (!string.IsNullOrEmpty(file)&&file.ToLower().Contains("http://"))
            {
                return file.Replace(",", "");
            }
            else
            {
                return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Market, id, Surface).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noshop.jpg";
            }
        }
        /// <summary>
        /// 集团董事长照片路径
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetMarketChairmanPath(string id, string file)
        {
            if (!string.IsNullOrEmpty(file) && file.ToLower().Contains("http:"))
            {
                return file.Replace(",", "");
            }
            else
            {
                return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Market, id, Chairman).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noshop.jpg";
            }
        }
        /// <summary>
        /// 集团形象大图路径
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetMarketCliquePath(string id, string file)
        {
            if (!string.IsNullOrEmpty(file) && file.ToLower().Contains("http:"))
            {
                return file.Replace(",", "");
            }
            else
            {
                return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Market, id, MarketClique).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noshop.jpg";
            }
        }
        /// <summary>
        /// 集团形象缩略图路径
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetMarketCliqueThumbPath(string id, string file)
        {
            if (!string.IsNullOrEmpty(file) && file.ToLower().Contains("http:"))
            {
                return file.Replace(",", "");
            }
            else
            {
                return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Market, id, MarketCliqueThumb).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noshop.jpg";
            }
        }
        /// <summary>
        /// 活动图路径
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetPromotionSurfacePath(string id, string file)
        {
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Promotion, id, Surface).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noshop.jpg";
        }
        /// <summary>
        /// 套组合缩略图
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetProductGroupThumbPath(string id, string file)
        {
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(ProductGroup, id, Thumb).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noshop.jpg";
        }
        /// <summary>
        /// 套组合banner图
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetProductGroupBannerPath(string id, string file)
        {
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(ProductGroup, id, Banner).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noshop.jpg";
        } 
        public static string GetMarketLogoPath(string id, string file)
        {
            if (!string.IsNullOrEmpty(file) && file.ToLower().Contains("http:"))
            {
                return file.Replace(",", "");
            }
            else
            {
                return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Market, id, Logo).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noshop.jpg";
            }
        }

        public static string GetMarketBannerPath(string id, string file)
        {
            if (!string.IsNullOrEmpty(file) && file.ToLower().Contains("http:"))
            {
                return file.Replace(",","");
            }
            else
            {
                return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Market, id, Banner).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noshop.jpg";
            }
        }

        public static string GetMarketStoreyThumbPath(string id, string file)
        {
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(MarketStorey, id, Thumb).Replace("/upload", "")  + GetFile(file) : resource + "/resource/web/images/nomarkets.gif";
        }

        public static string GetMarketThumbPath(string id, string file)
        {
            if (!string.IsNullOrEmpty(file) && file.ToLower().Contains("http:"))
            {
                return file.Replace(",", "");
            }
            else
            {
                return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Market, id, Thumb).Replace("/upload", "") + GetFile(file) : resource + "resource/web/images/noshop.jpg";
            }
        }

        public static string GetMarketDescriptPath(string id, string file)
        {

            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Market, id, DesImage).Replace("/upload", "")  + GetFile(file) : resource + "resource/web/images/noshop.jpg";
        }





        /// <summary>
        /// 获取卖场楼层图片
        /// </summary>
        /// <param name="id">楼层id</param>
        /// <param name="file">文件名称</param>
        /// <param name="upload">是否有upload文件，如果upload不为空，则保留upload文件夹</param>
        /// <returns></returns>
        public static string GetMarketStoreyThumbPath(string id, string file, string upload)
        {
            //if (upload != "")
            //{
            //    return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(MarketStorey, id, Thumb) + "/" + GetFile(file) : resource + "/resource/web/images/nomarkets.gif";
            //}
            //else
            //{
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(MarketStorey, id, Thumb).Replace("/upload", "")  + GetFile(file) : resource + "/resource/web/images/nomarkets.gif";
            //  }

        }

        /// <summary>
        /// 获取图片路径
        /// </summary>
        /// <param name="id">产品id</param>
        /// <param name="file">thumb图片名称（20141205100832464484.jpg）</param>
        /// <param name="Isupload">是否替换掉upload文件目录，如果upload不为空，则返回路径带有upload目录的路径，如果为空，则替换掉upload路径</param>
        /// <returns></returns>
        public static string GetProductThumbPath(string id, string file, string Isupload)
        {
            //if (Isupload != "")
            //{
            //    return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Product, id, Thumb) + "/" + GetFile(file) : resource + "resource/web/images/noshop.jpg";
            //}
            //else
            //{
            return !string.IsNullOrEmpty(file) ? resourceimg + string.Format(Product, id, Thumb).Replace("/upload", "")  + GetFile(file) : resource + "resource/web/images/noshop.jpg";

            //  }

        }


    }
}
