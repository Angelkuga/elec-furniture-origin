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
    public class ECMenu
    {
        #region  Method-Menu
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMenu(EnMenu model)
        {
            return Menus.EditMenu(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnMenu GetMenuInfo(string strWhere)
        {
            return Menus.GetMenuInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMenu> GetMenuList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Menus.GetMenuList(PageIndex, PageSize, strWhere, out pageCount);
        }

        public static List<EnMenu> GetMenuList(string filed, string strWhere, string sort)
        {
            if (sort == "")
            {
                sort = "order by sort desc";
            }

            List<EnMenu> list = Menus.GetMenuList(filed, strWhere, sort);
            List<EnMenu> t = new List<EnMenu>();
            var p = list.GroupBy(x => new { x.module });
            foreach (var i in p)
            {
                foreach (EnMenu m in list.Where(j => j.module == i.Key.module && j.parent==0))
                {
                    t.Add(m);
                    foreach (EnMenu s in list.Where(n => n.parent == m.id))
                    {
                        t.Add(s);
                    }
                }
            }
            return t;
        }


        ///获取数据列表
        public static List<EnMenu> GetMenuList(string strWhere, out int pageCount)
        {
            return GetMenuList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnMenu> GetMenuList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetMenuList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetMenuListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBMenu, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteMenu(int id)
        {
            return DeleteMenu(" where id=" + id);
        }
        ///删除对象
        public static int DeleteMenuByIdList(string idList)
        {
            return DeleteMenu(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteMenu(string strWhere)
        {
            return DataCommon.Delete(TableName.TBMenu, strWhere);
        }
        #endregion
    }
}
