using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TREC.Entity;
using TRECommon;
using System.Data.Common;

namespace TREC.Data
{
    /// <summary>
    /// 色板数据访问类
    /// </summary>
    public class ColorSwatchDb
    {
        /// <summary>
        /// 查询色板类别
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <returns></returns>
        public static Dictionary<int, string> QuerycolorSwatchDb(string typeName)
        {
            string Sql_QueryBrandGradeDb = "SELECT ID,[Name] FROM CategoryAttribute WHERE AttributeName=@typeName AND Name <> '' AND Name IS NOT NULL ORDER BY Sort,ID ";
            SqlParameter para = new SqlParameter("@typeName", SqlDbType.NVarChar, 50);
            para.Value = typeName;
            Dictionary<int, string> bgDict = new Dictionary<int, string>();
            //using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, Sql_QueryBrandGradeDb, para))
            //{
            using (IDataReader sdr = DbHelper.ExecuteReader(CommandType.Text, Sql_QueryBrandGradeDb,para))
            {
                while (sdr.Read())
                {
                    bgDict.Add(int.Parse(sdr["ID"].ToString()), sdr["Name"].ToString());
                }
            }
            return bgDict;
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
        public static List<ColorSwatchModel> QueryColorSwatchListDb(string userid,int brandId,int seriesId,string SwatchName, int PageSize, int CurentPage, out int Counts, out int PageCount)
        {
            string Where = " AND CreateId = '" + userid + "' ";
            //品牌id
            if (0 < brandId)
                Where += string.Format(" AND bSeriesId IN (SELECT id FROM t_brands WHERE brandid = {0} ) ", brandId);
            //系列id
            if (0 < seriesId)
                Where += " AND bSeriesId = " + seriesId;
            //色板名称
            if (!string.IsNullOrEmpty(SwatchName))
                Where += " AND SwatchName LIKE '%" + SwatchName + "%' ";
            string OrderBy = " csid ";
            string fileName = " csid,SwatchName,Picture,SeriesName,[Name],BrandName ";
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@tblName",SqlDbType.NVarChar,200),
                new SqlParameter("@fldName",SqlDbType.NVarChar,500),
                new SqlParameter("@pageSize",SqlDbType.Int,4),
                new SqlParameter("@page",SqlDbType.Int,4),
                new SqlParameter("@pageCount",SqlDbType.Int,4),
                new SqlParameter("@Counts",SqlDbType.Int,4),
                new SqlParameter("@fldSort",SqlDbType.NVarChar,200),
                new SqlParameter("@Sort",SqlDbType.Bit,1),
                new SqlParameter("@strCondition ",SqlDbType.NVarChar,1000),
                new SqlParameter("@ID",SqlDbType.NVarChar,150)
            };
            Parameter[0].Value = "V_SeriesSwatch";
            Parameter[1].Value = fileName;
            Parameter[2].Value = PageSize;
            Parameter[3].Value = CurentPage;
            Parameter[4].Direction = ParameterDirection.Output;//总页数
            Parameter[5].Direction = ParameterDirection.Output;//总记录数
            Parameter[6].Value = OrderBy;
            Parameter[7].Value = 1;
            Parameter[8].Value = Where;
            Parameter[9].Value = "csid";

            DbHelper.ExecuteNonQuery( CommandType.StoredProcedure, "proc_ListPageInt", Parameter);
            Counts = (int)Parameter[5].Value;
            PageCount = (int)Parameter[4].Value;
            List<ColorSwatchModel> SwatchList = new List<ColorSwatchModel>();
            ColorSwatchModel model = null;
            using (DbDataReader sdr = DbHelper.ExecuteReader(CommandType.StoredProcedure, "proc_ListPageInt", Parameter))
            {
                while (sdr.Read())
                {
                    model = new ColorSwatchModel();
                    //色板id
                    model.csid = sdr.GetInt32(0);
                    //色板名称
                    model.SwatchName = sdr[1].ToString();
                    //色板图片
                    if (!(sdr[2] is DBNull))
                        model.Picture = sdr[2].ToString();
                    else
                        model.Picture = "";
                    //系列名称
                    if (!(sdr[3] is DBNull))
                        model.SeriesName = sdr[3].ToString();
                    //类别名称
                    if (!(sdr[4] is DBNull))
                        model.CategroyName = sdr[4].ToString();
                    //品牌名称
                    if (!(sdr[5] is DBNull))
                        model.BrandName = sdr[5].ToString();
                    SwatchList.Add(model);
                    model = null;
                }
            }
            return SwatchList;
        }

        /// <summary>
        /// 查询编辑色板数据
        /// </summary>
        /// <param name="userName">会员名</param>
        /// <param name="SwatchId">色板id</param>
        /// <param name="IsEditor">是否有权限编辑该色板（bool表示没有权限编辑）</param>
        /// <returns></returns>
        public static t_colorswatch QueryEditorColorSwatchDb(int uid, int SwatchId, out bool IsEditor)
        {
            IsEditor = false;
            string Sql_QueryEditorColorSwatchDb = @"
               IF Exists(SELECT 1 FROM t_colorswatch WHERE csid=@SwatchId)
                  Begin
                     IF Exists(SELECT 1 FROM t_colorswatch WHERE csid=@SwatchId AND CreateId=@uid)
                        Begin
                          SELECT SwatchName,CategroyId,Picture,t_colorswatch.brandId,t_colorswatch.bSeriesId FROM t_colorswatch LEFT JOIN
                               t_brands ON bSeriesId =t_brands.id  WHERE csid=@SwatchId AND t_colorswatch.CreateId=@uid;
                        End
                     ELSE
                        Begin
                          SELECT NULL
                        End
                  End
            ";
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@uid",SqlDbType.Int,4),
                new SqlParameter("@SwatchId",SqlDbType.Int,4)
            };
            Parameter[0].Value = uid;
            Parameter[1].Value = SwatchId;
            t_colorswatch model = null;
            using (DbDataReader sdr = DbHelper.ExecuteReader( CommandType.Text, Sql_QueryEditorColorSwatchDb, Parameter))
            {
                if (sdr.Read())
                {
                    model = new t_colorswatch();
                    if (!(sdr[0] is DBNull))
                    {
                        IsEditor = true;
                        //色板名称
                        model.SwatchName = sdr[0].ToString();
                        //类别id
                        model.CategroyId = sdr.GetInt32(1);
                        //色板图片
                        model.Picture = sdr[2].ToString();
                        //品牌id
                        if (!(sdr[3] is DBNull))
                        {
                            model.brandid = sdr.GetInt32(3);
                            //系列id
                            model.bSeriesId = sdr.GetInt32(4);
                        }
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 保存添加色板数据
        /// </summary>
        /// <param name="model">色板数据</param>
        /// <returns></returns>
        public static bool SaveInsertColorSwatch(t_colorswatch model)
        {
            string Sql_SaveInsertColorSwatch = @"INSERT INTO ColorSwatch (SwatchName,CategroyId,Picture,CreateUser,bSeriesId) 
                   VALUES (@SwatchName,@CategroyId,@Picture,@userName,@SeriesId)
            ";
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@SwatchName",SqlDbType.NVarChar,100),
                new SqlParameter("@CategroyId",SqlDbType.Int,4),
                new SqlParameter("@Picture",SqlDbType.VarChar,100),
                new SqlParameter("@CreateId",SqlDbType.VarChar,50),
                new SqlParameter("@SeriesId",SqlDbType.Int,4)
            };
            Parameter[0].Value = model.SwatchName;
            Parameter[1].Value = model.CategroyId;
            Parameter[2].Value = model.Picture;
            Parameter[3].Value = model.CreateId;
            Parameter[4].Value = model.bSeriesId;
            return DbHelper.ExecuteNonQuery( CommandType.Text, Sql_SaveInsertColorSwatch, Parameter) > 0;
        }

        /// <summary>
        /// 保存编辑色板数据
        /// </summary>
        /// <param name="model">色板数据</param>
        /// <returns></returns>
        public static bool SaveEditorColorSwatch(t_colorswatch model)
        {
            string Sql_SaveInsertColorSwatch = @"UPDATE ColorSwatch SET SwatchName=@SwatchName,CategroyId=@CategroyId,Picture=@Picture,bSeriesId=@SeriesId  
                  WHERE csid=@csid
            ";
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@SwatchName",SqlDbType.NVarChar,100),
                new SqlParameter("@CategroyId",SqlDbType.Int,4),
                new SqlParameter("@Picture",SqlDbType.VarChar,100),
                new SqlParameter("@csid",SqlDbType.Int,4),
                new SqlParameter("@SeriesId",SqlDbType.Int,4)
            };
            Parameter[0].Value = model.SwatchName;
            Parameter[1].Value = model.CategroyId;
            Parameter[2].Value = model.Picture;
            Parameter[3].Value = model.csid;
            Parameter[4].Value = model.bSeriesId;
            return DbHelper.ExecuteNonQuery( CommandType.Text, Sql_SaveInsertColorSwatch, Parameter) > 0;
        }

        /// <summary>
        /// 删除色板数据
        /// </summary>
        /// <param name="swId">色板id</param>        
        /// <returns></returns>
        public static int DelColorSwatchDbBySwId(string swId)
        {
            string Sql_DelColorSwatchDbBySwId = string.Format(@"
               INSERT INTO ColorSwatchRecycle (csid,SwatchName,CategroyId,Picture,CreateId,bSeriesId,brandId) 
               SELECT csid,SwatchName,CategroyId,Picture,CreateId,bSeriesId,brandId FROM t_colorswatch WHERE csid IN ({0}) ;
               IF @@ERROR = 0
                  Begin
                      DELETE FROM  t_colorswatch WHERE csid IN ({0});
                  End
            ", swId);            
            return DbHelper.ExecuteNonQuery( CommandType.Text, Sql_DelColorSwatchDbBySwId);
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
            string Where = " AND CreateUser = '" + userName + "' ";
            string OrderBy = " csid ";
            string fileName = " csid,SwatchName,Picture,SeriesName,[Name],BrandName ";
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@tblName",SqlDbType.NVarChar,200),
                new SqlParameter("@fldName",SqlDbType.NVarChar,500),
                new SqlParameter("@pageSize",SqlDbType.Int,4),
                new SqlParameter("@page",SqlDbType.Int,4),
                new SqlParameter("@pageCount",SqlDbType.Int,4),
                new SqlParameter("@Counts",SqlDbType.Int,4),
                new SqlParameter("@fldSort",SqlDbType.NVarChar,200),
                new SqlParameter("@Sort",SqlDbType.Bit,1),
                new SqlParameter("@strCondition ",SqlDbType.NVarChar,1000),
                new SqlParameter("@ID",SqlDbType.NVarChar,150)
            };
            Parameter[0].Value = "V_SeriesSwatchRecycle";
            Parameter[1].Value = fileName;
            Parameter[2].Value = PageSize;
            Parameter[3].Value = CurentPage;
            Parameter[4].Direction = ParameterDirection.Output;//总页数
            Parameter[5].Direction = ParameterDirection.Output;//总记录数
            Parameter[6].Value = OrderBy;
            Parameter[7].Value = 1;
            Parameter[8].Value = Where;
            Parameter[9].Value = "csid";

            DbHelper.ExecuteNonQuery( CommandType.StoredProcedure, "proc_ListPageInt", Parameter);
            Counts = (int)Parameter[5].Value;
            PageCount = (int)Parameter[4].Value;
            List<ColorSwatchModel> SwatchList = new List<ColorSwatchModel>();
            ColorSwatchModel model = null;
            using (DbDataReader sdr = DbHelper.ExecuteReader( CommandType.StoredProcedure, "proc_ListPageInt", Parameter))
            {
                while (sdr.Read())
                {
                    model = new ColorSwatchModel();
                    //色板id
                    model.csid = sdr.GetInt32(0);
                    //色板名称
                    model.SwatchName = sdr[1].ToString();
                    //色板图片
                    if (!(sdr[2] is DBNull))
                        model.Picture = sdr[2].ToString();
                    else
                        model.Picture = "";
                    //系列名称
                    if (!(sdr[3] is DBNull))
                        model.SeriesName = sdr[3].ToString();
                    //类别名称
                    if (!(sdr[4] is DBNull))
                        model.CategroyName = sdr[4].ToString();
                    //品牌名称
                    if (!(sdr[5] is DBNull))
                        model.BrandName = sdr[5].ToString();
                    SwatchList.Add(model);
                    model = null;
                }
            }
            return SwatchList;
        }

        /// <summary>
        /// 删除回收站中色板数据
        /// </summary>
        /// <param name="swId">色板id</param>
        /// <param name="userName">会员名</param>
        /// <returns></returns>
        public static int DelColorSwatchRecycle(string swId)
        {
            string Sql_DelColorSwatchRecycle = string.Format(@"DELETE FROM  ColorSwatchRecycle WHERE csid IN ({0})", swId);            
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql_DelColorSwatchRecycle);
        }

        /// <summary>
        /// 还原回收站中色板数据
        /// </summary>
        /// <param name="swId">色板id</param>        
        /// <returns></returns>
        public static int RevertColorSwatchRecycle(string swId )
        {
            string Sql_RevertColorSwatchRecycle = string.Format(@"
               SET IDENTITY_INSERT [dbo].[t_colorswatch] ON;
               INSERT INTO t_colorswatch (csid,SwatchName,CategroyId,Picture,CreateId,CreateTime,bSeriesId,brandId) 
               SELECT csid,SwatchName,CategroyId,Picture,CreateId,CreateTime,bSeriesId,brandId FROM ColorSwatchRecycle WHERE csid IN ({0}) ;
               SET IDENTITY_INSERT [dbo].[t_colorswatch] OFF;
               IF @@ERROR = 0
                  Begin
                      DELETE FROM  ColorSwatchRecycle WHERE csid IN ({0});
                  End
            ", swId);
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql_RevertColorSwatchRecycle);
        }
    }
}