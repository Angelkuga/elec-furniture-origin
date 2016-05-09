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
    public class ECConfig
    {
        //判断配置类型标识是否存在。/标识全局唯一
        public static int ExitConfigTypeMark(string mark)
        {
            return DataCommon.Exists(TableName.TBConfigType, " where mark='" + mark + "'");
        }
        
        public static int UpConfigSort(string sort,int id)
        {
            return DataCommon.UpdateValue(TableName.TBConfig, "sort", sort, " where id=" + id);
        }

        //根据配置模块及模块配置类型读取名称
        public static string GetTypeName(string module, string type)
        {
            if (module == "" || type == "")
            {
                return "";
            }
            DataRow dr = DataCommon.GetDataRow(TableName.TBConfigType, "title", " where type='" + module + "' and id=" + type, "");
            if (dr != Convert.DBNull && dr != null && dr.Table.Rows.Count > 0)
                return dr["title"].ToString();
            return "";
        }


        #region  Method-Config
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditConfig(EnConfig model)
        {
            return Configs.EditConfig(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnConfig GetConfigInfo(string strWhere)
        {
            return Configs.GetConfigInfo(strWhere);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static string GetConfigInfoNew(string strWhere)
        {
            int tmpPageCount = 0;
            return Configs.GetConfigListNew(-1, 0, strWhere, out tmpPageCount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnConfig> GetConfigList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Configs.GetConfigList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnConfig> GetConfigList(string strWhere, out int pageCount)
        {
            return GetConfigList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnConfig> GetConfigList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetConfigList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetConfigListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBConfig, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteConfig(int id)
        {
            return DeleteConfig(" where id=" + id);
        }
        ///删除对象
        public static int DeleteConfigByIdList(string idList)
        {
            return DeleteConfig(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteConfig(string strWhere)
        {
            return DataCommon.Delete(TableName.TBConfig, strWhere);
        }
        #endregion


        #region  Method-ConfigType
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditConfigType(EnConfigType model)
        {
            return Configs.EditConfigType(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnConfigType GetConfigTypeInfo(string strWhere)
        {
            return Configs.GetConfigTypeInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnConfigType> GetConfigTypeList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Configs.GetConfigTypeList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnConfigType> GetConfigTypeList(string strWhere, out int pageCount)
        {
            return GetConfigTypeList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnConfigType> GetConfigTypeList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetConfigTypeList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetConfigTypeListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBConfigType, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteConfigType(int id)
        {
            return DeleteConfigType(" where id=" + id);
        }
        ///删除对象
        public static int DeleteConfigTypeByIdList(string idList)
        {
            return DeleteConfigType(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteConfigType(string strWhere)
        {
            return DataCommon.Delete(TableName.TBConfigType, strWhere);
        }
        #endregion
    }
}
