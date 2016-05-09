using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TREC.Entity;
using TRECommon;

namespace TREC.Data.Provide
{
    /// <summary>
    /// 活动类型DAL
    /// </summary>
    public class t_promotionstypeDAL
    {
        /// <summary>
        /// 获取活动类型数据
        /// </summary>
        /// <returns></returns>
        public static List<t_promotionstype> GetPromotionTypeList()
        {
            List<t_promotionstype> list = new List<t_promotionstype>();
            if (TRECommon.DataCache.GetCache("t_promotionstypeList") != null)
            {
                list = (List<t_promotionstype>)TRECommon.DataCache.GetCache("t_promotionstypeList");
            }
            else
            {
                IDataReader reader = DataCommon.GetDataIReader("t_promotionstype", "", "", " order by id asc");
                while (reader.Read())
                {
                    t_promotionstype model = new t_promotionstype();
                    if (reader["id"] != DBNull.Value && reader["id"].ToString() != "")
                    {
                        model.id = int.Parse(reader["id"].ToString());
                    }
                    if (reader["title"] != DBNull.Value && reader["title"].ToString() != "")
                    {
                        model.title = reader["title"].ToString();
                    }
                    if (reader["pindex"] != DBNull.Value && reader["pindex"].ToString() != "")
                    {
                        model.pindex = int.Parse(reader["pindex"].ToString());
                    }
                    if (reader["pstate"] != DBNull.Value && reader["pstate"].ToString() != "")
                    {
                        model.pstate = int.Parse(reader["pstate"].ToString());
                    }
                    if (reader["userid"] != DBNull.Value && reader["userid"].ToString() != "")
                    {
                        model.userid = int.Parse(reader["userid"].ToString());
                    }
                    if (reader["createtime"] != DBNull.Value && reader["createtime"].ToString() != "")
                    {
                        model.createtime = Convert.ToDateTime(reader["createtime"].ToString());
                    }
                    list.Add(model);
                }
                if (!reader.IsClosed)
                    reader.Close();
                TRECommon.DataCache.SetCache("t_promotionstypeList", list, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            return list;
        } 

        /// <summary>
        /// 根据id获取活动类型数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static t_promotionstype GetPromotionTypeById(int ids)
        {
            List<t_promotionstype> list = t_promotionstypeDAL.GetPromotionTypeList().Where(x => x.id == ids).ToList();
            if (list.Count > 0)
                return list.FirstOrDefault();
            else
                return null;
        }
    }
}
