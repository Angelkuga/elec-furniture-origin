using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace TRECommon
{
    public class WebUtils
    {
        #region URL

        /// <summary>
        /// 从URL获取域名
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetDomainFromUrl(string url)
        {
            if (url == null || url == "") return "";

            if (url.ToLower().StartsWith("http://"))
                url = url.Remove(0, 7);
            string[] parts = url.Split('/');
            string domain = "";
            List<string> dotcoms = new List<string>() { ".com", ".org", ".net", ".gov" };
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] != "" && parts[i].IndexOf(".") > 0)
                {
                    domain = parts[0];
                    break;
                }
            }
            if (domain.Length > 0)
            {
                string[] ds = domain.Split('.');
                if (ds.Length == 3 && !dotcoms.Contains(ds[1]))
                    domain = ds[1] + "." + ds[2];
                else if (ds.Length == 4 && dotcoms.Contains(ds[2]))
                    domain = ds[1] + "." + ds[2] + "." + ds[3];
                else if (ds.Length > 4)
                {
                    domain = ds[ds.Length - 3] + "." + ds[ds.Length - 2] + "." + ds[ds.Length - 1];
                }
            }
            return domain;
        }

        // <summary>
        /// 返回url中去掉文件名部分。如/news/2.html 中的/news/
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetChannelUrlFromUrl(string url)
        {
            if (url.IndexOf("?") > 0)
                url = url.Remove(url.IndexOf("?"));

            if (url.IndexOf('.') > 0)
                return url.Substring(0, url.LastIndexOf('/') + 1);
            else
            {
                if (!url.EndsWith("/")) url = url + "/";
                return url;
            }
        }



        /// <summary>
        /// 获得当前页面的名称
        /// </summary>
        /// <returns>当前页面的名称</returns>
        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }

        /// <summary>
        /// 返回路径
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        public static string ResolveUrl(string relativeUrl)
        {
            if (relativeUrl == null) throw new ArgumentNullException("relativeUrl");

            if (relativeUrl.Length == 0 || relativeUrl[0] == '/' ||
                relativeUrl[0] == '\\') return relativeUrl;

            int idxOfScheme =
              relativeUrl.IndexOf(@"://", StringComparison.Ordinal);
            if (idxOfScheme != -1)
            {
                int idxOfQM = relativeUrl.IndexOf('?');
                if (idxOfQM == -1 || idxOfQM > idxOfScheme) return relativeUrl;
            }

            StringBuilder sbUrl = new StringBuilder();
            sbUrl.Append(HttpRuntime.AppDomainAppVirtualPath);
            if (sbUrl.Length == 0 || sbUrl[sbUrl.Length - 1] != '/') sbUrl.Append('/');

            // found question mark already? query string, do not touch!
            bool foundQM = false;
            bool foundSlash; // the latest char was a slash?
            if (relativeUrl.Length > 1
                && relativeUrl[0] == '~'
                && (relativeUrl[1] == '/' || relativeUrl[1] == '\\'))
            {
                relativeUrl = relativeUrl.Substring(2);
                foundSlash = true;
            }
            else foundSlash = false;
            foreach (char c in relativeUrl)
            {
                if (!foundQM)
                {
                    if (c == '?') foundQM = true;
                    else
                    {
                        if (c == '/' || c == '\\')
                        {
                            if (foundSlash) continue;
                            else
                            {
                                sbUrl.Append('/');
                                foundSlash = true;
                                continue;
                            }
                        }
                        else if (foundSlash) foundSlash = false;
                    }
                }
                sbUrl.Append(c);
            }

            return sbUrl.ToString();
        }



        #endregion

        #region 验证码
        
        /// <summary>
        /// 生成数字
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetNumVerify(int length)
        {
            Random rand = new Random();
            string min = "";
            string max = "";
            for (int i = 0; i < length; i++)
            {
                min += "1";
                max += "9";
            }

            return (rand.Next(TypeConverter.StrToInt(min), TypeConverter.StrToInt(max)).ToString());


        }

        /// <summary>
        /// 生成随数数字
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomNumVerify(int length)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9";
            string[] allCharArray = allChar.Split(',');

            string newCode = "";
            Random rand = new Random();

            int temp = -1;  //临时变量rand实列标志 内容为上次的值 如果值为上次生成的数次则实列新的random

            for (int i = 0; i < length; i++)
            {
                //首次无需执行实列新Random
                if (temp != -1)
                {
                    rand = new Random(int.MaxValue - rand.Next(800) - 1);
                }

                int t = rand.Next(9);  //临时变量 位置

                //如果本次位置==上次位置则重新实列Randon
                if (t == temp)
                {
                    return GetRandomNumVerify(length);
                }

                temp = t;

                newCode += allCharArray[t];

            }

            return newCode;

        }

        /// <summary>
        /// 生成随数 数字+字母
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomNumAndLetterVerify(int length)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(int.MaxValue - rand.Next(800) - 1);
                }
                int t = rand.Next(61);
                if (temp == t)
                {
                    return GetRandomNumAndLetterVerify(length);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }

        /// <summary>
        /// 生成汉字字节
        /// </summary>
        /// <param name="strlength"></param>
        /// <returns></returns>
        public static object[] GetRandomRegionVerify(int strlength)
        {
            //定义一个字符串数组储存汉字编码的组成元素 
            string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Random rnd = new Random();
            //定义一个object数组用来 
            object[] bytes = new object[strlength];

            /**/
            /*每循环一次产生一个含两个元素的十六进制字节数组，并将其放入bject数组中 
         每个汉字有四个区位码组成 
         区位码第1位和区位码第2位作为字节数组第一个元素 
         区位码第3位和区位码第4位作为字节数组第二个元素 
        */
            for (int i = 0; i < strlength; i++)
            {
                //区位码第1位 
                int r1 = rnd.Next(11, 14);
                string str_r1 = rBase[r1].Trim();

                //区位码第2位 
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i);//更换随机数发生器的种子避免产生重复值 
                int r2;
                if (r1 == 13)
                {
                    r2 = rnd.Next(0, 7);
                }
                else
                {
                    r2 = rnd.Next(0, 16);
                }
                string str_r2 = rBase[r2].Trim();

                //区位码第3位 
                rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);
                int r3 = rnd.Next(10, 16);
                string str_r3 = rBase[r3].Trim();

                //区位码第4位 
                rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string str_r4 = rBase[r4].Trim();

                //定义两个字节变量存储产生的随机汉字区位码 
                byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);
                //将两个字节变量存储在字节数组中 
                byte[] str_r = new byte[] { byte1, byte2 };

                //将产生的一个汉字的字节数组放入object数组中 
                bytes.SetValue(str_r, i);
            }
            return bytes;
        }

        /// <summary>
        /// 生成汉字
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string GetRandomRegionVerifyByLength(int num)
        {
            Encoding gb = Encoding.GetEncoding("gb2312");

            //调用函数产生10个随机中文汉字编码 
            object[] bytes = GetRandomRegionVerify(num);
            string strtxt = "";

            //根据汉字编码的字节数组解码出中文汉字 
            for (int i = 0; i < num; i++)
            {
                strtxt += gb.GetString((byte[])Convert.ChangeType(bytes[i], typeof(byte[])));
            }
            return strtxt;
        }



        #endregion

    }
}
