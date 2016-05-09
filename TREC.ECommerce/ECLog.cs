using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TREC.Entity;
using TREC.Data;
using TRECommon;


namespace TREC.ECommerce
{
    public class ECLog
    {

        /// <summary>
        /// 增加日志
        /// </summary>
        /// <param name="module">模块ID</param>
        /// <param name="action">动作ID</param>
        /// <param name="aid">操作人ID</param>
        /// <param name="aname">操作人名称</param>
        /// <param name="title">操作内容</param>
        /// <returns></returns>
        public static int AddLog(int module, int action, int aid, string aname, string title)
        {
            EnLog model = new EnLog();
            model.id = 0;
            model.modeule = module;
            model.action = action;
            model.operateid = aid;
            model.operatename = aname;
            model.title = title;
            model.lastedittime = DateTime.Now;
            return EditLog(model);
        }


        #region  Method-Log
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditLog(EnLog model)
        {
            return Logs.EditLog(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnLog GetLogInfo(string strWhere)
        {
            return Logs.GetLogInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnLog> GetLogList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Logs.GetLogList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnLog> GetLogList(string strWhere, out int pageCount)
        {
            return GetLogList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnLog> GetLogList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetLogList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetLogListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBLog, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteLog(int id)
        {
            return DeleteLog(" where id=" + id);
        }
        ///删除对象
        public static int DeleteLogByIdList(string idList)
        {
            return DeleteLog(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteLog(string strWhere)
        {
            return DataCommon.Delete(TableName.TBLog, strWhere);
        }
        #endregion
    }
}
