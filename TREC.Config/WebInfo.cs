using System;
using System.Collections.Generic;
using System.Text;

namespace TREC.Config
{
    [Serializable]

    public class WebInfo : IConfigInfo
    {
        private string _webname = "";
        private string _weburl = "";
        private string _websupplerurl = "";
        private string _webadminurl = "";

        private string _webimgurl = "";

        private string _webtel = "";
        private string _webfax = "";
        private string _webemail = "";
        private string _webcrod = "";
        private string _webkeywords = "";
        private string _webdescription = "";
        private string _webcopyright = "";
        private string _jtip = "";
        private string _jhost = "";
        private string _cookieurl = "";


        private string _usertile = "";
        private string _hashcode = "";

        private string _servicemail = "";


        private string _templateskin = "default";

        /// <summary>
        ///  网站名称
        /// </summary>
        public string WebName
        {
            set { _webname = value; }
            get { return _webname; }
        }

        /// <summary>
        ///  网站地址
        /// </summary>
        public string WebUrl
        {
            set { _weburl = value; }
            get { return _weburl; }
        }

        /// <summary>
        ///  通道网站地址
        /// </summary>
        public string WebSupplerUrl
        {
            set { _websupplerurl = value; }
            get { return _websupplerurl; }
        }

        /// <summary>
        ///  后台网站地址
        /// </summary>
        public string WebAdminUrl
        {
            set { _webadminurl = value; }
            get { return _webadminurl; }
        }

        /// <summary>
        /// 网站图片地址
        /// </summary>
        public string WebImgUrl
        {
            set { _webimgurl = value; }
            get { return _webimgurl; }
        }

        /// <summary>
        ///  联系电话
        /// </summary>
        public string WebTel
        {
            set { _webtel = value; }
            get { return _webtel; }
        }

        /// <summary>
        ///  传真地址
        /// </summary>
        public string WebFax
        {
            set { _webfax = value; }
            get { return _webfax; }
        }

        /// <summary>
        ///  联系邮箱
        /// </summary>
        public string WebEmail
        {
            set { _webemail = value; }
            get { return _webemail; }
        }

        /// <summary>
        ///  ICP备案
        /// </summary>
        public string WebCrod
        {
            set { _webcrod = value; }
            get { return _webcrod; }
        }

        /// <summary>
        /// 网站关健字
        /// </summary>
        public string WebKeywords
        {
            set { _webkeywords = value; }
            get { return _webkeywords; }
        }

        /// <summary>
        ///  网站描述
        /// </summary>
        public string WebDescription
        {
            set { _webdescription = value; }
            get { return _webdescription; }
        }

        /// <summary>
        ///  公司版权
        /// </summary>
        public string WebCopyright
        {
            set { _webcopyright = value; }
            get { return _webcopyright; }
        }

        /// <summary>
        /// 交通银行报文IP地址
        /// </summary>
        public string Jtip
        {
            set { _jtip = value; }
            get { return _jtip; }
        }

        /// <summary>
        /// 交通银行报文端口地址
        /// </summary>
        public string JHost
        {
            set { _jhost = value; }
            get { return _jhost; }
        }
        /// <summary>
        /// 跨域写入Cookie的域名
        /// </summary>
        public string CookieUrl
        {
            set { _cookieurl = value; }
            get { return _cookieurl; }
        }
        /// <summary>
        /// 短信密码
        /// </summary>
        public string Hashcode
        {
            get { return _hashcode; }
            set { _hashcode = value; }
        }
        /// <summary>
        /// 短信用户
        /// </summary>
        public string UserTile
        {
            get { return _usertile; }
            set { _usertile = value; }
        }

        /// <summary>
        /// 通知客服邮箱
        /// </summary>
        public string ServiceMail
        {
            get { return _servicemail; }
            set { _servicemail = value; }
        }
    }
}
