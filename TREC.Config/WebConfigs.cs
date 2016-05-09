using System;
using System.Collections.Generic;
using System.Text;

namespace TREC.Config
{
    /// <summary>
    /// 网站信息配置类
    /// </summary>
    public class WebConfigs
    {
        private static System.Timers.Timer baseConfigTimer = new System.Timers.Timer(60000);

        private static WebInfo m_configinfo;

		/// <summary>
        /// 静态构造函数初始化相应实例和定时器
		/// </summary>
        static WebConfigs()
        {
            m_configinfo = WebFileManager.LoadConfig();
            baseConfigTimer.AutoReset = true;
            baseConfigTimer.Enabled = true;
            baseConfigTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed); 
            baseConfigTimer.Start();
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ResetConfig();
        }


        /// <summary>
        /// 重设配置类实例
        /// </summary>
        public static void ResetConfig()
        {
            m_configinfo = WebFileManager.LoadConfig();
        }


        /// <summary>
        /// 获取配置类实例
        /// </summary>
        /// <returns></returns>
        public static WebInfo GetConfig()
        {

            return WebFileManager.LoadConfig();
        }

        /// <summary>
        /// 保存配置类实例
        /// </summary>
        /// <param name="WebConfigInfo"></param>
        /// <returns></returns>
        public static bool SaveConfig(WebInfo webconfiginfo)
        {
            WebFileManager ecfm = new WebFileManager();
            WebFileManager.ConfigInfo = webconfiginfo;
            return ecfm.SaveConfig();
        }

        


    }
}
