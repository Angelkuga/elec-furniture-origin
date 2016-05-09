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
    public class ECRole
    {
        #region  Method-Role
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditRole(EnRole model)
        {
            return Permissions.EditRole(model);
            
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnRole GetRoleInfo(string strWhere)
        {
            return Permissions.GetRoleInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnRole> GetRoleList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Permissions.GetRoleList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnRole> GetRoleList(string strWhere, out int pageCount)
        {
            return GetRoleList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnRole> GetRoleList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetRoleList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetRoleListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBSystemRole, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnRole(int id)
        {
            return DeletEnRole(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnRoleByIdList(string idList)
        {
            return DeletEnRole(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnRole(string strWhere)
        {
            return DataCommon.Delete(TableName.TBSystemRole, strWhere);
        }
        #endregion

        #region 角色与权限关联
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditRoleActionDef(EnRoleActionDef model)
        {
            return Permissions.EditRoleActionDef(model);

        }

        public static int  DelRoleActionDef(int roleid)
        {
            return DataCommon.Delete(TableName.TBRoleActionDef, " WHERE roleid=" + roleid);
        }

        public static List<EnRoleActionDef> GetRoleActionDefList(string strWhere)
        {
            return Permissions.GetRoleActionDefList(strWhere);

        }

        #endregion 
    }
}
