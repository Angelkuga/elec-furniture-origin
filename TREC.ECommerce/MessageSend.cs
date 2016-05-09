using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Config;
using System.Net;
using System.IO;

namespace TREC.ECommerce
{
    public class MessageSend
    {
        protected static string SendUrl = "http://18dx.cn/API/Services.aspx";//发送地址
        protected static string usertitle = WebConfigs.GetConfig().UserTile;//用户
        protected static string hashcode = WebConfigs.GetConfig().Hashcode;//用户密码(明文或MD5加密)
        public static string action = "msgsend";//操作类型         
        protected static string mobile = "";//目的手机号码（多个手机号请用半角逗号或封号隔开） 
        protected static string content = "";//短信内容，最多支持250个字，67个字按一条短信计费 
        protected static string time = "";//短信定时发送时间,可以传空值,为空则视为立即发送,格式:yyyy-MM-dd HH:mm:ss 
        protected static string msgid = "";//短信批次的唯一ID,长整型,可以传空值,若不传空值请做好唯一判断,发送成功后返回字符串中,将返回系统自动给出的批次ID,该ID可以与手机号码一起用于配置短信报告与上行短信记录 
        protected static string encode = "";//编码,为空或不加该参数,默认为UTF-8, 可以传: GB2312 ,gbk 等 

        //action=msgsend&user=本站用户名&mobile=手机号码&content=短信内容&time=发送时间&msgid=批次ID&hashcode=校验码 
        public static string MessageSendInfo(string _action,string _mobile,string _content,string _msgid,string _encode)
        {
            if (string.IsNullOrEmpty(_action))
            {
                _action = action;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(SendUrl);
            sb.Append("?");
            sb.Append("action=" + _action);
            sb.Append("&user=" + usertitle);
            sb.Append("&mobile=" + _mobile);
            sb.Append("&content=" + _content);
            sb.Append("&time=");
            sb.Append("&msgid=" + _msgid);
            sb.Append("&hashcode=" + hashcode);
            sb.Append("&encode=UTF-8");
            return GetHtmlFromUrl(sb.ToString());
        }

        //调用时只需要把拼成的URL传给该函数即可。判断返回值即可
        protected static string GetHtmlFromUrl(string url)
        {
            string strRet = null;
            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.UTF8);
                strRet = ser.ReadToEnd();
            }
            catch (Exception ex)
            {
                strRet = null;
            }
            return strRet;
        }


    }
}
