using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Entity;
using TREC.Data;
using TRECommon;


namespace TREC.ECommerce
{


    /// <summary>
    /// 色板数据调用
    /// </summary>
    public class ColorSwatchBll
    {

        /// <summary>
        /// 查询色板类别
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <returns></returns>
        public static Dictionary<int, string> QuerycolorSwatchDb(string typeName)
        {
            return ColorSwatchDb.QuerycolorSwatchDb(typeName);
}


        /// <summary>
        /// 查询色板列表数据
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="brandId">品牌id</param>
        /// <param name="seriesId">系列id</param>
        /// <param name="SwatchName">色板名称</param>
        /// <param name="PageSize">每页显示数据量</param>
        /// <param name="CurentPage">当前索引页</param>
        /// <param name="Counts">返回总记录数</param>
        /// <param name="PageCount">返回总页数</param>
        /// <returns></returns>
        public static List<ColorSwatchModel> QueryColorSwatchListDb(string userName, int brandId, int seriesId, string SwatchName, int PageSize, int CurentPage, out int Counts, out int PageCount)
        {
            return ColorSwatchDb.QueryColorSwatchListDb(userName,brandId,seriesId,SwatchName, PageSize, CurentPage, out Counts, out PageCount);
        }

        /// <summary>
        /// 查询编辑色板数据
        /// </summary>
        /// <param name="userName">会员名</param>
        /// <param name="SwatchId">色板id</param>
        /// <param name="IsEditor">是否有权限编辑该色板（bool表示没有权限编辑）</param>
        /// <returns></returns>
        public static t_colorswatch QueryEditorColorSwatchDb(int uid , int SwatchId, out bool IsEditor)
        {
            return ColorSwatchDb.QueryEditorColorSwatchDb(uid,SwatchId,out IsEditor);
        }

        /// <summary>
        /// 保存添加色板数据
        /// </summary>
        /// <param name="model">色板数据</param>
        /// <returns></returns>
        public static bool SaveInsertColorSwatch(t_colorswatch model)
        {
            return ColorSwatchDb.SaveInsertColorSwatch(model);
        }

        /// <summary>
        /// 保存编辑色板数据
        /// </summary>
        /// <param name="model">色板数据</param>
        /// <returns></returns>
        public static bool SaveEditorColorSwatch(t_colorswatch model)
        {
            return ColorSwatchDb.SaveEditorColorSwatch(model);
        }

        /// <summary>
        /// 删除色板数据
        /// </summary>
        /// <param name="swId">色板id</param>
        
        /// <returns></returns>
        public static int DelColorSwatchDbBySwId(string swId )
        {
            return ColorSwatchDb.DelColorSwatchDbBySwId(swId);
        }

        /// <summary>
        /// 查询回收站中色板列表数据
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="PageSize">每页显示数据量</param>
        /// <param name="CurentPage">当前索引页</param>
        /// <param name="Counts">返回总记录数</param>
        /// <param name="PageCount">返回总页数</param>
        /// <returns></returns>
        public static List<ColorSwatchModel> QueryColorSwatchRecycleListDb(string userName, int PageSize, int CurentPage, out int Counts, out int PageCount)
        {
            return ColorSwatchDb.QueryColorSwatchRecycleListDb(userName, PageSize, CurentPage, out Counts, out PageCount);
        }

        /// <summary>
        /// 删除回收站中色板数据
        /// </summary>
        /// <param name="swId">色板id</param>
        /// <param name="userName">会员名</param>
        /// <returns></returns>
        public static int DelColorSwatchRecycle(string swId)
        {
            return ColorSwatchDb.DelColorSwatchRecycle(swId);
        }

        /// <summary>
        /// 还原回收站中色板数据
        /// </summary>
        /// <param name="swId">色板id</param>
        /// <param name="userName">会员名</param>
        /// <returns></returns>
        public static int RevertColorSwatchRecycle(string swId)
        {
            return ColorSwatchDb.RevertColorSwatchRecycle(swId);
        }
    }
}