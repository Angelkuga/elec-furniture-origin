//======================================================================
// 组织名: Troopsen
// 命名空间名称: Common
// 文件名: SysInfo
// 创建人: Troopsen
// 创建时间: 2011/3/30 21:58:29
//======================================================================
using System;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TRECommon
{
    public class SysInfo
    {
        #region CpuUsage类
        /// <summary>
        /// Defines an abstract base class for implementations of CPU usage counters.
        /// </summary>
        public abstract class CpuUsage
        {
            /// <summary>
            /// Creates and returns a CpuUsage instance that can be used to query the CPU time on this operating system.
            /// </summary>
            /// <returns>An instance of the CpuUsage class.</returns>
            /// <exception cref="NotSupportedException">This platform is not supported -or- initialization of the CPUUsage object failed.</exception>
            public static CpuUsage Create()
            {
                if (m_CpuUsage == null)
                {
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                        m_CpuUsage = new CpuUsageNt();
                    else if (Environment.OSVersion.Platform == PlatformID.Win32Windows)
                        m_CpuUsage = new CpuUsage9x();
                    else
                        throw new NotSupportedException();
                }
                return m_CpuUsage;
            }
            /// <summary>
            /// Determines the current average CPU load.
            /// </summary>
            /// <returns>An integer that holds the CPU load percentage.</returns>
            /// <exception cref="NotSupportedException">One of the system calls fails. The CPU time can not be obtained.</exception>
            public abstract int Query();
            /// <summary>
            /// Holds an instance of the CPUUsage class.
            /// </summary>
            private static CpuUsage m_CpuUsage = null;
        }

        //------------------------------------------- win 9x ---------------------------------------

        /// <summary>
        /// Inherits the CPUUsage class and implements the Query method for Windows 9x systems.
        /// </summary>
        /// <remarks>
        /// <p>This class works on Windows 98 and Windows Millenium Edition.</p>
        /// <p>You should not use this class directly in your code. Use the CPUUsage.Create() method to instantiate a CPUUsage object.</p>
        /// </remarks>
        internal sealed class CpuUsage9x : CpuUsage
        {
            /// <summary>
            /// Initializes a new CPUUsage9x instance.
            /// </summary>
            /// <exception cref="NotSupportedException">One of the system calls fails.</exception>
            public CpuUsage9x()
            {
                try
                {
                    // start the counter by reading the value of the 'StartStat' key
                    RegistryKey startKey = Registry.DynData.OpenSubKey(@"PerfStats\StartStat", false);
                    if (startKey == null)
                        throw new NotSupportedException();
                    startKey.GetValue(@"KERNEL\CPUUsage");
                    startKey.Close();
                    // open the counter's value key
                    m_StatData = Registry.DynData.OpenSubKey(@"PerfStats\StatData", false);
                    if (m_StatData == null)
                        throw new NotSupportedException();
                }
                catch (NotSupportedException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new NotSupportedException("Error while querying the system information.", e);
                }
            }
            /// <summary>
            /// Determines the current average CPU load.
            /// </summary>
            /// <returns>An integer that holds the CPU load percentage.</returns>
            /// <exception cref="NotSupportedException">One of the system calls fails. The CPU time can not be obtained.</exception>
            public override int Query()
            {
                try
                {
                    return (int)m_StatData.GetValue(@"KERNEL\CPUUsage");
                }
                catch (Exception e)
                {
                    throw new NotSupportedException("Error while querying the system information.", e);
                }
            }
            /// <summary>
            /// Closes the allocated resources.
            /// </summary>
            ~CpuUsage9x()
            {
                try
                {
                    m_StatData.Close();
                }
                catch { }
                // stopping the counter
                try
                {
                    RegistryKey stopKey = Registry.DynData.OpenSubKey(@"PerfStats\StopStat", false);
                    stopKey.GetValue(@"KERNEL\CPUUsage", false);
                    stopKey.Close();
                }
                catch { }
            }
            /// <summary>Holds the registry key that's used to read the CPU load.</summary>
            private RegistryKey m_StatData;
        }

        //------------------------------------------- win nt ---------------------------------------

        /// <summary>
        /// Inherits the CPUUsage class and implements the Query method for Windows NT systems.
        /// </summary>
        /// <remarks>
        /// <p>This class works on Windows NT4, Windows 2000, Windows XP, Windows .NET Server and higher.</p>
        /// <p>You should not use this class directly in your code. Use the CPUUsage.Create() method to instantiate a CPUUsage object.</p>
        /// </remarks>
        internal sealed class CpuUsageNt : CpuUsage
        {
            /// <summary>
            /// Initializes a new CpuUsageNt instance.
            /// </summary>
            /// <exception cref="NotSupportedException">One of the system calls fails.</exception>
            public CpuUsageNt()
            {
                byte[] timeInfo = new byte[32];		// SYSTEM_TIME_INFORMATION structure
                byte[] perfInfo = new byte[312];	// SYSTEM_PERFORMANCE_INFORMATION structure
                byte[] baseInfo = new byte[44];		// SYSTEM_BASIC_INFORMATION structure
                int ret;
                // get new system time
                ret = NtQuerySystemInformation(SYSTEM_TIMEINFORMATION, timeInfo, timeInfo.Length, IntPtr.Zero);
                if (ret != NO_ERROR)
                    throw new NotSupportedException();
                // get new CPU's idle time
                ret = NtQuerySystemInformation(SYSTEM_PERFORMANCEINFORMATION, perfInfo, perfInfo.Length, IntPtr.Zero);
                if (ret != NO_ERROR)
                    throw new NotSupportedException();
                // get number of processors in the system
                ret = NtQuerySystemInformation(SYSTEM_BASICINFORMATION, baseInfo, baseInfo.Length, IntPtr.Zero);
                if (ret != NO_ERROR)
                    throw new NotSupportedException();
                // store new CPU's idle and system time and number of processors
                oldIdleTime = BitConverter.ToInt64(perfInfo, 0); // SYSTEM_PERFORMANCE_INFORMATION.liIdleTime
                oldSystemTime = BitConverter.ToInt64(timeInfo, 8); // SYSTEM_TIME_INFORMATION.liKeSystemTime
                processorCount = baseInfo[40];
            }
            /// <summary>
            /// Determines the current average CPU load.
            /// </summary>
            /// <returns>An integer that holds the CPU load percentage.</returns>
            /// <exception cref="NotSupportedException">One of the system calls fails. The CPU time can not be obtained.</exception>
            public override int Query()
            {
                byte[] timeInfo = new byte[32];		// SYSTEM_TIME_INFORMATION structure
                byte[] perfInfo = new byte[312];	// SYSTEM_PERFORMANCE_INFORMATION structure
                double dbIdleTime, dbSystemTime;
                int ret;
                // get new system time
                ret = NtQuerySystemInformation(SYSTEM_TIMEINFORMATION, timeInfo, timeInfo.Length, IntPtr.Zero);
                if (ret != NO_ERROR)
                    throw new NotSupportedException();
                // get new CPU's idle time
                ret = NtQuerySystemInformation(SYSTEM_PERFORMANCEINFORMATION, perfInfo, perfInfo.Length, IntPtr.Zero);
                if (ret != NO_ERROR)
                    throw new NotSupportedException();
                // CurrentValue = NewValue - OldValue
                dbIdleTime = BitConverter.ToInt64(perfInfo, 0) - oldIdleTime;
                dbSystemTime = BitConverter.ToInt64(timeInfo, 8) - oldSystemTime;
                // CurrentCpuIdle = IdleTime / SystemTime
                if (dbSystemTime != 0)
                    dbIdleTime = dbIdleTime / dbSystemTime;
                // CurrentCpuUsage% = 100 - (CurrentCpuIdle * 100) / NumberOfProcessors
                dbIdleTime = 100.0 - dbIdleTime * 100.0 / processorCount + 0.5;
                // store new CPU's idle and system time
                oldIdleTime = BitConverter.ToInt64(perfInfo, 0); // SYSTEM_PERFORMANCE_INFORMATION.liIdleTime
                oldSystemTime = BitConverter.ToInt64(timeInfo, 8); // SYSTEM_TIME_INFORMATION.liKeSystemTime
                return (int)dbIdleTime;
            }
            /// <summary>
            /// NtQuerySystemInformation is an internal Windows function that retrieves various kinds of system information.
            /// </summary>
            /// <param name="dwInfoType">One of the values enumerated in SYSTEM_INFORMATION_CLASS, indicating the kind of system information to be retrieved.</param>
            /// <param name="lpStructure">Points to a buffer where the requested information is to be returned. The size and structure of this information varies depending on the value of the SystemInformationClass parameter.</param>
            /// <param name="dwSize">Length of the buffer pointed to by the SystemInformation parameter.</param>
            /// <param name="returnLength">Optional pointer to a location where the function writes the actual size of the information requested.</param>
            /// <returns>Returns a success NTSTATUS if successful, and an NTSTATUS error code otherwise.</returns>
            [DllImport("ntdll", EntryPoint = "NtQuerySystemInformation")]
            private static extern int NtQuerySystemInformation(int dwInfoType, byte[] lpStructure, int dwSize, IntPtr returnLength);
            /// <summary>Returns the number of processors in the system in a SYSTEM_BASIC_INFORMATION structure.</summary>
            private const int SYSTEM_BASICINFORMATION = 0;
            /// <summary>Returns an opaque SYSTEM_PERFORMANCE_INFORMATION structure.</summary>
            private const int SYSTEM_PERFORMANCEINFORMATION = 2;
            /// <summary>Returns an opaque SYSTEM_TIMEOFDAY_INFORMATION structure.</summary>
            private const int SYSTEM_TIMEINFORMATION = 3;
            /// <summary>The value returned by NtQuerySystemInformation is no error occurred.</summary>
            private const int NO_ERROR = 0;
            /// <summary>Holds the old idle time.</summary>
            private long oldIdleTime;
            /// <summary>Holds the old system time.</summary>
            private long oldSystemTime;
            /// <summary>Holds the number of processors in the system.</summary>
            private double processorCount;
        }
        #endregion

        /// <summary>
        /// 获得Cpu使用率
        /// </summary>
        /// <returns>返回使用率</returns>
        public static int GetCpuUsage()
        {
            return CpuUsage.Create().Query();
        }


        /// <summary>
        /// 系统信息
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string[] LoadSystemInf(System.Web.UI.Page page)
        {
            #region 检测系统信息

            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.CacheControl = "no-cache";

            //取得页面执行开始时间
            DateTime stime = DateTime.Now;

            //取得服务器相关信息
            string[] arrStr = new string[24];
            arrStr[0] = page.Server.MachineName; //服务器名称
            arrStr[1] = HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"]; //服务器IP地址
            arrStr[2] = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];  //服务器域名

            int build, major, minor, revision;
            build = Environment.Version.Build;
            major = Environment.Version.Major;
            minor = Environment.Version.Minor;
            revision = Environment.Version.Revision;

            arrStr[3] = ".NET CLR  " + major + "." + minor + "." + build + "." + revision; //.NET解释引擎版本
            arrStr[5] = Environment.OSVersion.ToString(); //服务器操作系统

            arrStr[6] = HttpContext.Current.Request.ServerVariables["SERVER_SOFTWARE"]; //服务器IIS版本
            arrStr[7] = HttpContext.Current.Request.ServerVariables["SERVER_PORT"]; //HTTP访问端口:
            arrStr[8] = page.Server.ScriptTimeout.ToString();//服务端脚本执行超时:
            //语言应该是浏览者信息, 1.0 final 修改
            arrStr[9] = HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];  //语言:
            arrStr[10] = DateTime.Now.ToString();  //服务器当前时间:
            arrStr[11] = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];   //虚拟目录绝对路径:
            arrStr[12] = HttpContext.Current.Request.ServerVariables["PATH_TRANSLATED"];  //执行文件绝对路径:
            arrStr[13] = HttpContext.Current.Request.ServerVariables["HTTPS"]; //  HTTPS:

            //取得用户浏览器信息
            HttpBrowserCapabilities bc = HttpContext.Current.Request.Browser;
            arrStr[14] = bc.Browser.ToString(); //浏览器:

            arrStr[15] = bc.Cookies.ToString(); // Cookies:
            arrStr[16] = bc.Frames.ToString(); // Frames(分栏)
            arrStr[17] = bc.JavaApplets.ToString(); // JavaApplets:
            arrStr[18] = bc.EcmaScriptVersion.ToString(); // JavaScript:
            arrStr[19] = bc.Platform.ToString(); // 浏览者操作系统:
            arrStr[20] = bc.VBScript.ToString(); // VBScript:
            arrStr[21] = bc.Version.ToString(); // 浏览器版本:

            //取得浏览者ip地址,1.0 final 加入
            arrStr[22] = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            //取得页面执行结束时间
            DateTime etime = DateTime.Now;

            //计算页面执行时间
            arrStr[23] = ((etime - stime).TotalMilliseconds).ToString();

            return arrStr;

            #endregion
        }


        private static string[] browerNames = { "MSIE", "Firefox", "Opera", "Netscape", "Safari", "Lynx", "Konqueror", "Mozilla" };
        //private const string[] osNames = { "Win", "Mac", "Linux", "FreeBSD", "SunOS", "OS/2", "AIX", "Bot", "Crawl", "Spider" };


        /// <summary>
        /// 获得浏览器信息
        /// </summary>
        /// <returns></returns>
        public static string GetClientBrower()
        {
            string agent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            if (!string.IsNullOrEmpty(agent))
            {
                foreach (string name in browerNames)
                {
                    if (agent.Contains(name))
                        return name;
                }
            }
            return "Other";
        }


        /// <summary>
        /// 获得操作系统信息
        /// </summary>
        /// <returns></returns>
        public static string GetClientOS()
        {
            string os = string.Empty;
            string agent = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            if (agent == null)
                return "Other";

            if (agent.IndexOf("Win") > -1)
                os = "Windows";
            else if (agent.IndexOf("Mac") > -1)
                os = "Mac";
            else if (agent.IndexOf("Linux") > -1)
                os = "Linux";
            else if (agent.IndexOf("FreeBSD") > -1)
                os = "FreeBSD";
            else if (agent.IndexOf("SunOS") > -1)
                os = "SunOS";
            else if (agent.IndexOf("OS/2") > -1)
                os = "OS/2";
            else if (agent.IndexOf("AIX") > -1)
                os = "AIX";
            else if (System.Text.RegularExpressions.Regex.IsMatch(agent, @"(Bot|Crawl|Spider)"))
                os = "Spiders";
            else
                os = "Other";
            return os;
        }


        public static string GetClientOS(HttpContext Context)
        {
            string strSysVersion = "其他";
            string strAgentInfo = Context.Request.ServerVariables["HTTP_USER_AGENT"];

            if (strAgentInfo.Contains("NT 5.2"))
            {
                strSysVersion = "Windows 2003";
            }
            else if (strAgentInfo.Contains("NT 5.1"))
            {
                strSysVersion = "Windows XP";
            }
            else if (strAgentInfo.Contains("NT 5"))
            {
                strSysVersion = "Windows 2000";
            }
            else if (strAgentInfo.Contains("NT 4.9"))
            {
                strSysVersion = "Windows ME";
            }
            else if (strAgentInfo.Contains("NT 4"))
            {
                strSysVersion = "Windows NT4";
            }
            else if (strAgentInfo.Contains("NT 98"))
            {
                strSysVersion = "Windows 98";
            }
            else if (strAgentInfo.Contains("NT 95"))
            {
                strSysVersion = "Windows 95";
            }
            else if (strSysVersion.ToLower().Contains("Mac"))
            {
                strSysVersion = "Mac";
            }
            else if (strSysVersion.ToLower().Contains("unix"))
            {
                strSysVersion = "UNIX";
            }
            else if (strSysVersion.ToLower().Contains("linux"))
            {
                strSysVersion = "Linux";
            }
            else if (strSysVersion.Contains("SunOS"))
            {
                strSysVersion = "SunOS";
            }

            return strSysVersion;
        }


    }
}
