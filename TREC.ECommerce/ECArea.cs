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
    public class ECArea
    {
        #region  Method-Area
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditArea(EnArea model)
        {
            return Areas.EditArea(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnArea GetAreaInfo(string strWhere)
        {
            return Areas.GetAreaInfo(strWhere);
        }

        ///获取数据列表
        public static List<EnArea> GetAreaList(string strWhere)
        {
            return Areas.GetAreaList(" where " + strWhere);
        }

        ///删除对象
        public static int DeleteAreaByAreacode(string areacode)
        {
            return DeleteArea(" where areacode='" + areacode + "'");
        }
        ///删除对象
        public static int DeleteAreaByIdList(string idList)
        {
            return DeleteArea(" where id areacode (" + idList + ")");
        }
        ///删除对象
        public static int DeleteArea(string strWhere)
        {
            return DataCommon.Delete(TableName.TBArea, strWhere);
        }

        /// <summary>
        /// 2015-01-30 shen 获取所有地址
        /// </summary>
        /// <returns></returns>
        public static List<EnArea> EnAreaList()
        {
            return Areas.GetAreaList();

        }
        #endregion
    }
}
