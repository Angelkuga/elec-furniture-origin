using System;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using Haojibiz.Data;
using System.Collections.Generic;
using System.Web;

namespace Haojibiz.DAL
{
    /// <summary>
    /// 对所有 Haojibiz.Data.DALHandlerBase8 的派生类添加扩展方法。
    /// </summary>
    public static class DBExtendMethod
    {
        #region [对所有实现 Haojibiz.Data.IDALHandler 接口类的添加一个使用 Linq 操作数据库的扩展方法，以便在当前类中立即获取访问数据库的方法。]
        /// <summary>
        /// 获取访问数据库 LINQ 访问对象 System.Data.Linq.Table&lt;TEntity&gt; 的实例。
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="the"></param>
        /// <returns></returns>
        public static Table<TEntity> LinqData<TEntity>(this IDALHandler the) where TEntity : class
        {
            return the.LinqContext.GetTable<TEntity>();
        }

        /// <summary>
        /// 获取访问数据库 LINQ 访问对象 System.Data.Linq.Table&lt;TEntity&gt; 的实例。
        /// </summary>
        /// <typeparam name="TEntity">要查询的数据库实体类。</typeparam>
        /// <param name="where">指定此 Linq 筛选条件。</param>
        /// <param name="the"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> LinqData<TEntity>(this IDALHandler the, Expression<Func<TEntity, bool>> where)
            where TEntity : class
        {
            return the.LinqContext.GetTable<TEntity>().Where<TEntity>(where);
        }
        #endregion

        #region [对 AspNetPager 分类控件添加扩展方法]
        /// <summary>
        /// 获取可用于 GridView、DataList、Repeater 或用于循环枚举项的并已设置到分页控件的数据源。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pager"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<T> GetPagedDataSource<T>(this Wuqi.Webdiyer.AspNetPager pager, IQueryable<T> query)
            where T : class
        {
            pager.RecordCount = query.Count();
            var idx = 1;
            int.TryParse(pager.Page.Request.QueryString[pager.UrlPageIndexName], out idx);
            if (idx <= 0)
            {
                idx = 1;
            }
            if (idx > pager.PageCount)
            {
                idx = pager.PageCount;
            }
            return query.Skip((idx - 1) * pager.PageSize).Take(pager.PageSize).ToList();
        }
        #endregion
    }
}
