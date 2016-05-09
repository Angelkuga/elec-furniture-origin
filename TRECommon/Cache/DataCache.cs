using System;
using System.Web;

namespace TRECommon
{
    public class DataCache
    {
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey">键值</param>
        /// <returns>Object</returns>
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey">键字</param>
        /// <param name="objObject">Object</param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="slidingExpiration"></param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="CacheKey"></param>
        public static void Remove(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Remove(CacheKey);
        }








        #region
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache对象值
        /// </summary>
        /// <param name="CacheKey">索引键值</param>
        /// <returns>返回缓存对象</returns>
        public static object GetCache_file(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }
        /// <summary>
        /// 设置以缓存依赖的方式缓存数据
        /// </summary>
        /// <param name="CacheKey">索引键值</param>
        /// <param name="objObject">缓存对象</param>
        /// <param name="cacheDepen">依赖对象</param>
        public static void SetCache_file(string CacheKey, object objObject, System.Web.Caching.CacheDependency dep)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(
                CacheKey,
                objObject,
                dep,
                System.Web.Caching.Cache.NoAbsoluteExpiration, //从不过期
                System.Web.Caching.Cache.NoSlidingExpiration, //禁用可调过期
                System.Web.Caching.CacheItemPriority.Default,
                null);
        }
        /*
            string CacheKey = "cachetest";
            object objModel = GetCache(CacheKey);//从缓存中获取
            if (objModel == null) //缓存里没有
            {
            //读取数据库
            if (objModel != null)
            {
            //依赖 C:\\test.txt 文件的变化来更新缓存
            System.Web.Caching.CacheDependency dep = new System.Web.Caching.CacheDependency("C:\\test.txt");
            SetCache(CacheKey, objModel, dep);//写入缓存
            }
            } 
        */

        #endregion




    }
}
