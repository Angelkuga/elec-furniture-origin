using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace TREC.ECommerce
{
    public class XWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            return request;
        }
    } 

   public class SubmitMeth
    {

        /// <summary>
        /// 字符串切割
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static String bSubstring(string s, int length)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(s);
            int n = 0;  //  表示当前的字节数
            int i = 0;  //  要截取的字节数
            for (; i < bytes.GetLength(0) && n < length; i++)
            {

                //  偶数位置，如0、2、4等，为UCS2编码中两个字节的第一个字节
                if (i % 2 == 0)
                {
                    n++;      //  在UCS2第一个字节时n加1
                }
                else
                {

                    //  当UCS2编码的第二个字节大于0时，该UCS2字符为汉字，一个汉字算两个字节
                    if (bytes[i] > 0)
                    {
                        n++;
                    }
                }

            }

            //  如果i为奇数时，处理成偶数
            if (i % 2 == 1)
            {

                //  该UCS2字符是汉字时，去掉这个截一半的汉字
                if (bytes[i] > 0)

                    i = i - 1;

                 //  该UCS2字符是字母或数字，则保留该字符
                else
                    i = i + 1;
            }
            return System.Text.Encoding.Unicode.GetString(bytes, 0, i);
        }

        public static string gettest(string url)
        {

            XWebClient wc = new XWebClient();
            wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.63 Safari/537.36");
            Stream st = wc.OpenRead(url);
            StreamReader sr = new StreamReader(st, Encoding.GetEncoding("GBK"));
            string res = sr.ReadToEnd();
            sr.Close();
            st.Close();

            return res.Replace("\r\n", "").Replace("\\r\\n", "").Replace("\r", "").Replace("\n", "").Replace("\\r", "").Replace("\\n", "");
        }


        public static string Post(string url, string paramData, Encoding dataEncode)
        {
            try
            {
                string postString = paramData;
                byte[] postData = Encoding.UTF8.GetBytes(postString);

                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                webClient.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.63 Safari/537.36");
                byte[] responseData = webClient.UploadData(url, "POST", postData);
                string srcString = Encoding.UTF8.GetString(responseData);

                return srcString;
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string GetWebContent(string sUrl)
        {
            string strResult = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sUrl);
                request.Headers["Accept-Encoding"] = "gzip,deflate";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                //声明一个HttpWebRequest请求
                request.Timeout = 3000000;
                //设置连接超时时间
                //request.Headers.Set("Content-Encoding", "gzip");
                //request.Headers.Set("Content-Language", "zh-CN");
                //request.Headers.Set("Content-Type", "application/javascript;charset=GBK");
                //request.Headers.Set("User-Agent", "Mozilla/5.0 (Windows NT 6.1; rv:24.0) Gecko/20100101 Firefox/24.0");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.ToString() != "")
                {
                    Stream streamReceive = response.GetResponseStream();
                    Encoding encoding = Encoding.GetEncoding("GBK");//乱码处理 GBK  
                    StreamReader streamReader = new StreamReader(streamReceive, encoding);
                    strResult = streamReader.ReadToEnd();
                }
            }
            catch (Exception exp)
            {

            }
            return strResult;
        }

        public static string Get(string url)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.63 Safari/537.36");
                Stream st = wc.OpenRead(url);
                StreamReader sr = new StreamReader(st);
                string res = sr.ReadToEnd();
                sr.Close();
                st.Close();
                return res;
            }
            catch
            {
                return string.Empty;
            }
           


        }


        public static int getInt(string v)
        {
            int o = 0;
            Int32.TryParse(v, out o);
            return o;
        }
        public static double getdouble(string v)
        {
            double o = 0;
            double.TryParse(v, out o);
            return o;
        }
        public static string DisposeHtml(string html)
        {
            html = html.Replace("&nbsp;", "").Trim();
            html = html.Replace(" ", "");
            string Htmlstring = Regex.Replace(html, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            return Htmlstring;

        }

    }
}
