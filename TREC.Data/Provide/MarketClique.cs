using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Entity;
using TRECommon;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace TREC.Data
{
    /// <summary>
    /// 卖场集团DAL类
    /// </summary>
    public class MarketClique
    {
        /// <summary>
        /// 更新卖场集团对像
        /// </summary>
        public static int EditMarketClique(EnMarketClique model)
        {
            if (model.Id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into [t_MarketClique](");
                strSql.Append("marketid,title,chairman,chairmanOration,descript,auditstatus,chairmanimg,thumbimg,infoimg,createmid,lastedittime,createtime,LogImg,phone,Address)");
                strSql.Append(" values (");
                strSql.Append("@marketid,@title,@chairman,@chairmanOration,@descript,@auditstatus,@chairmanimg,@thumbimg,@infoimg,@createmid,@lastedittime,@createtime,@LogImg,@phone,@Address)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@marketid",model.MarketId),
                    new SqlParameter("@title",model.Title),
                    new SqlParameter("@chairman",model.Chairman),
                    new SqlParameter("@chairmanOration",model.ChairmanOration),
                    new SqlParameter("@descript",model.Descript),
                    new SqlParameter("@auditstatus",model.Auditstatus),
                    new SqlParameter("@chairmanimg",model.ChairmanImg),
                    new SqlParameter("@thumbimg",model.ThumbImg),
                    new SqlParameter("@infoimg",model.InfoImg),
                    new SqlParameter("@createmid",model.CreateMid),
                    new SqlParameter("@lastedittime",model.LastediTime),
                     new SqlParameter("@logimg",model.LogImg),
                    new SqlParameter("@createtime",model.CreateTime),
                    new SqlParameter("@phone",model.Phone),
                    new SqlParameter("@Address",model.Address)
                                            };
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update [t_MarketClique] set ");
                strSql.Append("marketid=@marketid,title=@title,chairman=@chairman,chairmanOration=@chairmanOration,descript=@descript,");
                strSql.Append("auditstatus=@auditstatus,chairmanimg=@chairmanimg,thumbimg=@thumbimg,infoimg=@infoimg,");
                strSql.Append("lastedittime=@lastedittime,LogImg=@LogImg,createmid=@createmid,phone=@phone,Address=@Address where  id=@id");
                SqlParameter[] parameters = {
                    new SqlParameter("@id",model.Id),
                    new SqlParameter("@marketid",model.MarketId),
                    new SqlParameter("@title",model.Title),
                    new SqlParameter("@chairman",model.Chairman),
                    new SqlParameter("@chairmanOration",model.ChairmanOration),
                    new SqlParameter("@descript",model.Descript),
                    new SqlParameter("@auditstatus",model.Auditstatus),
                    new SqlParameter("@chairmanimg",model.ChairmanImg),
                    new SqlParameter("@thumbimg",model.ThumbImg),
                    new SqlParameter("@infoimg",model.InfoImg),
                    new SqlParameter("@createmid",model.CreateMid),
                    new SqlParameter("@lastedittime",model.LastediTime),
                      new SqlParameter("@logimg",model.LogImg),
                    new SqlParameter("@createtime",model.CreateTime),
                     new SqlParameter("@phone",model.Phone),
                      new SqlParameter("@Address",model.Address)
                                            };
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            return 0;
        }

        /// <summary>
        /// 按idlist条件删除卖场集团
        /// </summary>
        /// <param name="idlist">id列表</param>
        /// <returns></returns>
        public static int DeleteMarketClique(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("Delete from [t_MarketCliqueRef] where marketcliqueid in ({0});",idlist);
            strSql.AppendFormat("Delete from [t_MarketClique] where id in ({0});", idlist);
            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 更具sql条件获取卖场集团对象
        /// </summary>
        /// <param name="strWhere">where条件(要写where关键字)</param>
        /// <returns></returns>
        public static EnMarketClique GetMarketClique(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [t_MarketClique] ");
            strSql.Append(strWhere);


            EnMarketClique model = new EnMarketClique();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != DBNull.Value && reader["id"].ToString() != "")
                {
                    model.Id = int.Parse(reader["id"].ToString());
                }
                if (reader["marketid"] != DBNull.Value && reader["marketid"].ToString() != "")
                {
                    model.MarketId = int.Parse(reader["marketid"].ToString());
                }
                if (reader["LogImg"] != DBNull.Value && reader["LogImg"].ToString() != "")
                {
                    model.LogImg = reader["LogImg"].ToString();
                }
                
                if (reader["title"] != DBNull.Value && reader["title"].ToString() != "")
                {
                    model.Title = reader["title"].ToString();
                }
                if (reader["chairman"] != DBNull.Value && reader["chairman"].ToString() != "")
                {
                    model.Chairman = reader["chairman"].ToString();
                }
                if (reader["chairmanOration"] != DBNull.Value && reader["chairmanOration"].ToString() != "")
                {
                    model.ChairmanOration = reader["chairmanOration"].ToString();
                }
                if (reader["descript"] != DBNull.Value && reader["descript"].ToString() != "")
                {
                    model.Descript = reader["descript"].ToString();
                }
                if (reader["descript"] != DBNull.Value && reader["descript"].ToString() != "")
                {
                    model.Descript = reader["descript"].ToString();
                }
                if (reader["auditstatus"] != DBNull.Value && reader["auditstatus"].ToString() != "")
                {
                    model.Auditstatus = int.Parse(reader["auditstatus"].ToString());
                }
                if (reader["chairmanimg"] != DBNull.Value && reader["chairmanimg"].ToString() != "")
                {
                    model.ChairmanImg = reader["chairmanimg"].ToString();
                }
                if (reader["thumbimg"] != DBNull.Value && reader["thumbimg"].ToString() != "")
                {
                    model.ThumbImg = reader["thumbimg"].ToString();
                }
                if (reader["infoimg"] != DBNull.Value && reader["infoimg"].ToString() != "")
                {
                    model.InfoImg = reader["infoimg"].ToString();
                }
                if (reader["createmid"] != DBNull.Value && reader["createmid"].ToString() != "")
                {
                    model.CreateMid = int.Parse(reader["createmid"].ToString());
                }
                if (reader["lastedittime"] != DBNull.Value && reader["lastedittime"].ToString() != "")
                {
                    model.LastediTime = Convert.ToDateTime(reader["lastedittime"].ToString());
                }
                if (reader["createtime"] != DBNull.Value && reader["createtime"].ToString() != "")
                {
                    model.CreateTime = Convert.ToDateTime(reader["createtime"].ToString());
                }


                if (reader["phone"] != DBNull.Value && reader["phone"].ToString() != "")
                {
                    model.Phone = reader["phone"].ToString();
                }
                if (reader["Address"] != DBNull.Value && reader["Address"].ToString() != "")
                {
                    model.Address = reader["Address"].ToString();
                }
                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                return model;
            }
            else
            {
                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                return null;
            }
        }

        /// <summary>
        /// 卖场集团分页数据
        /// </summary>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="strWhere">条件</param>
        /// <param name="pagecount">总页数</param>
        /// <returns></returns>
        public static List<EnMarketClique> GetMarketCliqueList(int pageindex, int pagesize, string strWhere, out int pagecount)
        {
            List<EnMarketClique> modelList = new List<EnMarketClique>();
            DataTable dt = DataCommon.GetPageDataTable("t_MarketClique", pageindex, pagesize, strWhere, "", 1, out pagecount);
            if (dt.Rows.Count > 0)
            {
                EnMarketClique model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMarketClique();
                    if (dt.Rows[n]["id"] != DBNull.Value && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["marketid"] != DBNull.Value && dt.Rows[n]["marketid"].ToString() != "")
                    {
                        model.MarketId = int.Parse(dt.Rows[n]["marketid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != DBNull.Value && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["chairman"] != DBNull.Value && dt.Rows[n]["chairman"].ToString() != "")
                    {
                        model.Chairman = dt.Rows[n]["chairman"].ToString();
                    }
                    if (dt.Rows[n]["chairmanOration"] != DBNull.Value && dt.Rows[n]["chairmanOration"].ToString() != "")
                    {
                        model.ChairmanOration = dt.Rows[n]["chairmanOration"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != DBNull.Value && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.Descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != DBNull.Value && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.Descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["auditstatus"] != DBNull.Value && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.Auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
                    }
                    if (dt.Rows[n]["chairmanimg"] != DBNull.Value && dt.Rows[n]["chairmanimg"].ToString() != "")
                    {
                        model.ChairmanImg = dt.Rows[n]["chairmanimg"].ToString();
                    }
                    if (dt.Rows[n]["thumbimg"] != DBNull.Value && dt.Rows[n]["thumbimg"].ToString() != "")
                    {
                        model.ThumbImg = dt.Rows[n]["thumbimg"].ToString();
                    }
                    if (dt.Rows[n]["infoimg"] != DBNull.Value && dt.Rows[n]["infoimg"].ToString() != "")
                    {
                        model.InfoImg = dt.Rows[n]["infoimg"].ToString();
                    }
                    if (dt.Rows[n]["createmid"] != DBNull.Value && dt.Rows[n]["createmid"].ToString() != "")
                    {
                        model.CreateMid = int.Parse(dt.Rows[n]["createmid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != DBNull.Value && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.LastediTime = Convert.ToDateTime(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["createtime"] != DBNull.Value && dt.Rows[n]["createtime"].ToString() != "")
                    {
                        model.CreateTime = Convert.ToDateTime(dt.Rows[n]["createtime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 更具集团id获取卖场集团对象
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static EnMarketClique GetMarketCliqueById(int marketCliqueId)
        {
            return GetMarketClique(string.Format(" where id = {0} ", marketCliqueId));
        }

        /// <summary>
        /// 更具主卖场id获取卖场集团对象
        /// </summary>
        /// <param name="marketId">主卖场id</param>
        /// <returns></returns>
        public static EnMarketClique GetMarketCliqueByMainMarketId(int marketId)
        {
            return GetMarketClique(string.Format(" where marketid = {0} ", marketId));
        }

        public static EnMarketClique GetMarketCliqueByMid(int Mid)
        {
            return GetMarketClique(string.Format(" where createmid = {0} ", Mid));
        }
        public static EnMarketClique GetMarketCliqueByWhere(string Where)
        {
            return GetMarketClique(Where);
        }

        /// <summary>
        /// 更具子卖场id获取卖场集团对象
        /// </summary>
        /// <param name="submarketId">子卖场id</param>
        /// <returns></returns>
        public static EnMarketClique GetMarketCliqueBySubMarketId(int submarketId)
        {
            return GetMarketClique(string.Format(" where ID in (select top 1 marketcliqueid from  t_MarketCliqueRef where marketid={0}) ", submarketId));
        }

        /// <summary>
        /// 更具集团对象返回审核通过的集团对象
        /// </summary>
        /// <param name="paramodel">集团对象</param>
        /// <returns></returns>
        public static EnMarketClique GetMarketCliqueByModel(EnMarketClique paramodel)
        {
            if (paramodel.Auditstatus == (int)EnumAuditStatus.通过)
            {
                return paramodel;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 按子卖场id列表和集团id设置卖场和集团关系表
        /// </summary>
        /// <param name="marketCliqueId">集团id</param>
        /// <param name="idList">子卖场id列表字符串(123,456,789)</param>
        public static void SetSubMarket(int marketCliqueId, string idList)
        {
            string[] submarketids = idList.Split(',');
            StringBuilder sqlstr = new StringBuilder(string.Format("delete from t_MarketCliqueRef where marketcliqueid={0};", marketCliqueId));
            foreach (string items in submarketids)
            {
                sqlstr.AppendFormat("insert into t_MarketCliqueRef(marketid,marketcliqueid)values({0},{1});", items, marketCliqueId);
            }
            DbHelper.ExecuteNonQuery(CommandType.Text, sqlstr.ToString());
        }

        /// <summary>
        /// 更具集团id删除所有子卖场
        /// </summary>
        /// <param name="marketCliqueId"></param>
        public static void DeleteSubMarket(int marketCliqueId)
        {
            StringBuilder sqlstr = new StringBuilder(string.Format("delete from t_MarketCliqueRef where marketcliqueid={0};", marketCliqueId));
            DbHelper.ExecuteNonQuery(CommandType.Text, sqlstr.ToString());
        }

        /// <summary>
        /// 更具集团id获取卖场
        /// </summary>
        /// <param name="marketCliqueId">集团id</param>
        /// <returns></returns>
        public static string[] GetSubMarketByMarketCliqueId(int marketCliqueId)
        {
            StringBuilder strSql = new StringBuilder(string.Format("select * from t_MarketCliqueRef where marketcliqueid={0};", marketCliqueId));
            List<string> submarketId = new List<string>();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            while (reader.Read())
            {
                if (reader["marketid"] != DBNull.Value && reader["marketid"].ToString() != "")
                {
                    submarketId.Add(reader["marketid"].ToString());
                }
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }
            return submarketId.ToArray();
        }

        /// <summary>
        /// 更具 集团id列表设置审核状态
        /// </summary>
        /// <param name="marketCliquelistId">集团id列表</param>
        /// <param name="auditstatus">审核状态</param>
        public static void SetMarketCliqueAuditstatus(string marketCliquelistId, int auditstatus)
        {
            if (marketCliquelistId != string.Empty)
            {
                StringBuilder strSql = new StringBuilder(string.Format("update t_MarketClique set auditstatus={1} where id=({0});", marketCliquelistId, auditstatus));
                DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }
        }
    }
}
