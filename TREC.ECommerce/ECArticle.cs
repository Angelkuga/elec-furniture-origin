using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using TREC.Entity;
using TREC.Data;
using TRECommon;


namespace TREC.ECommerce
{
    public class ECArticle
    {
        public static void BindArticleCategory(DropDownList ddl)
        {
            int pageCount = 0;
            List<EnArticleCategory> list = GetReaderArticleCategoryList(1, 10000, "", "", " lft", "asc", out pageCount);
            foreach (EnArticleCategory c in list)
            {
                c.title = c.lev > 1 ? "├ " + c.title : c.title;
                c.title = StringOperation.StringOfChar(c.lev - 1, "　") + c.title;
            }
            ddl.DataSource = list;
            ddl.DataTextField = "title";
            ddl.DataValueField = "id";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("请选择分类", "0"));
        }

        public static int UpConFilePath(string con, int id)
        {
            return DataCommon.UpdateValue(TableName.TBArticle, "context", con, " where id=" + id);
        }
        public static int UpCategoryConFilePath(string con, int id)
        {
            return DataCommon.UpdateValue(TableName.TBArticleCategory, "context", con, " where id=" + id);
        }

        //分类上移
         public static int CategoryArticleNodeUp(int id)
         {
             return DataCommon.CategoryNodeUp(TableName.TPArticleCategoryUp, id);
             //TPArticleCategoryUp
         }

        #region  Method-Article

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditArticle(EnArticle model)
        {
            return Articles.EditArticle(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnArticle GetArticleInfo(string strWhere)
        {
            return Articles.GetArticleInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnArticle> GetArticleList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Articles.GetArticleList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnArticle> GetArticleList(string strWhere, out int pageCount)
        {
            return GetArticleList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnArticle> GetArticleList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetArticleList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetArticleListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TVArticle, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        public static List<EnArticle> GetReaderArticleList(int PageIndex, int PageSize, string strWhere,string field,string orderkey,string ordertype, out int pageCount)
        {
            return Articles.GetArticleList(PageIndex, PageSize, strWhere, field, orderkey, ordertype, out pageCount);
        }


        public static List<EnArticle> GetReaderArticleList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Articles.GetArticleList(PageIndex, PageSize, strWhere, "", "", "", out pageCount);
        }

        ///删除对象
        public static int DeleteArticle(int id)
        {
            return DeleteArticle(" where id=" + id);
        }
        ///删除对象
        public static int DeleteArticleByIdList(string idList)
        {
            return DeleteArticle(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteArticle(string strWhere)
        {
            return DataCommon.Delete(TableName.TBArticle, strWhere);
        }
        #endregion

        #region  Method-ArticleCategory

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditArticleCategory(EnArticleCategory model)
        {
            return Articles.EditArticleCategory(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnArticleCategory GetArticleCategoryInfo(string strWhere)
        {
            return Articles.GetArticleCategoryInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnArticleCategory> GetArticleCategoryList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Articles.GetArticleCategoryList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnArticleCategory> GetArticleCategoryList(string strWhere, out int pageCount)
        {
            return GetArticleCategoryList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnArticleCategory> GetArticleCategoryList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetArticleCategoryList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetArticleCategoryListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBArticleCategory, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        public static List<EnArticleCategory> GetReaderArticleCategoryList(int PageIndex, int PageSize, string strWhere, string field, string orderkey, string ordertype, out int pageCount)
        {
            return Articles.GetArticleCategoryList(PageIndex, PageSize, strWhere, field, orderkey, ordertype, out pageCount);
        }

        public static List<EnArticleCategory> GetReaderArticleCategoryList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Articles.GetArticleCategoryList(PageIndex, PageSize, strWhere, "", "", "", out pageCount);
        }

        ///删除对象
        public static int DeleteArticleCategory(int id)
        {
            return DeleteArticleCategory(" where id=" + id);
        }
        ///删除对象
        public static int DeleteArticleCategoryByIdList(string idList)
        {
            return DeleteArticleCategory(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteArticleCategory(string strWhere)
        {
            return DataCommon.Delete(TableName.TBArticleCategory, strWhere);
        }
        #endregion
    }
}
