using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;

using TRECommon;



namespace TREC.Config
{
    /// <summary>
    /// 网站信息管理
    /// </summary>
    class WebFileManager:DefaultConfigFileManager
    {
        /// <summary>
        /// 对象
        /// </summary>
        private static WebInfo m_configinfo;

        /// <summary>
        /// 文件修改时间
        /// </summary>
        private static DateTime m_fileoldchange;

        /// <summary>
        /// 锁对象
        /// </summary>
        private static object m_lockHelper = new object();

        /// <summary>
        /// 初始化文件修改时间和对象实例
        /// </summary>
        static WebFileManager()
        {
            m_fileoldchange = System.IO.File.GetLastWriteTime(ConfigFilePath);
            m_configinfo = (WebInfo)DefaultConfigFileManager.DeserializeInfo(ConfigFilePath, typeof(WebInfo));
        }

        /// <summary>
        /// 当前的配置实例
        /// </summary>
        public new static IConfigInfo ConfigInfo
        {
            get { return m_configinfo; }
            set { m_configinfo = (WebInfo)value; }
        }


        /// <summary>
        /// 配置文件所在路径
        /// </summary>
        public static string filename = null;

        /// <summary>
        /// 获取配置文件所在路径
        /// </summary>
        public new static string ConfigFilePath
        {
            get
            {
                if (filename == null)
                {
                    HttpContext context = HttpContext.Current;
                    if (context != null)
                    {
                        filename = context.Server.MapPath("~/config/webinfo.config");
                        if (!File.Exists(filename))
                        {
                            filename = context.Server.MapPath("/config/webinfo.config");
                        }
                    }
                    else
                    {
                        filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config/webinfo.config");
                    }
                    if (!File.Exists(filename))
                    {
                        throw new Exception("发生错误: 虚拟目录或网站../config/下没有正确的webinfo.config文件");
                    }
                }
                return filename;
            }
        }

        /// <summary>
        /// 返回配置类实例
        /// </summary>
        /// <returns></returns>
        public static WebInfo LoadConfig()
        {
            ConfigInfo = DefaultConfigFileManager.LoadConfig(ref m_fileoldchange, ConfigFilePath, ConfigInfo);
            return ConfigInfo as WebInfo;
        }

        /// <summary>
        /// 保存配置类实例
        /// </summary>
        /// <returns></returns>
        public override bool SaveConfig()
        {
            return base.SaveConfig(ConfigFilePath, ConfigInfo);
        }

    }
}
