using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TREC.Entity;
using TRECommon;

namespace TREC.Data
{
    public class ProductCategorys
    {

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditProductCategory(EnProductCategory model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_productcategory(");
                strSql.Append("title,letter,rewritetitle,parentid,lft,rgt,lev,depth,surface,thumb,bannel,descript,keywords,template,hits,sort,createmid,lastedid,lastedittime,linestatus)");
                strSql.Append(" values (");
                strSql.Append("@title,@letter,@rewritetitle,@parentid,@lft,@rgt,@lev,@depth,@surface,@thumb,@bannel,@descript,@keywords,@template,@hits,@sort,@createmid,@lastedid,@lastedittime,@linestatus)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@letter", SqlDbType.VarChar,20),
					new SqlParameter("@rewritetitle", SqlDbType.VarChar,20),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@lft", SqlDbType.Int,4),
					new SqlParameter("@rgt", SqlDbType.Int,4),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@depth", SqlDbType.VarChar,200),
					new SqlParameter("@surface", SqlDbType.VarChar,200),
					new SqlParameter("@thumb", SqlDbType.VarChar,40),
					new SqlParameter("@bannel", SqlDbType.VarChar,300),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@keywords", SqlDbType.NVarChar,200),
					new SqlParameter("@template", SqlDbType.VarChar,50),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@linestatus", SqlDbType.Int)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.letter;
                parameters[2].Value = model.rewritetitle;
                parameters[3].Value = model.parentid;
                parameters[4].Value = model.lft;
                parameters[5].Value = model.rgt;
                parameters[6].Value = model.lev;
                parameters[7].Value = model.depth;
                parameters[8].Value = model.surface;
                parameters[9].Value = model.thumb;
                parameters[10].Value = model.bannel;
                parameters[11].Value = model.descript;
                parameters[12].Value = model.keywords;
                parameters[13].Value = model.template;
                parameters[14].Value = model.hits;
                parameters[15].Value = model.sort;
                parameters[16].Value = model.createmid;
                parameters[17].Value = model.lastedid;
                parameters[18].Value = model.lastedittime;
                parameters[19].Value = model.linestatus;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_productcategory set ");
                strSql.Append("title=@title,");
                strSql.Append("letter=@letter,");
                strSql.Append("rewritetitle=@rewritetitle,");
                strSql.Append("parentid=@parentid,");
                strSql.Append("lft=@lft,");
                strSql.Append("rgt=@rgt,");
                strSql.Append("lev=@lev,");
                strSql.Append("depth=@depth,");
                strSql.Append("surface=@surface,");
                strSql.Append("thumb=@thumb,");
                strSql.Append("bannel=@bannel,");
                strSql.Append("descript=@descript,");
                strSql.Append("keywords=@keywords,");
                strSql.Append("template=@template,");
                strSql.Append("hits=@hits,");
                strSql.Append("sort=@sort,");
                strSql.Append("createmid=@createmid,");
                strSql.Append("lastedid=@lastedid,");
                strSql.Append("lastedittime=@lastedittime,");
                strSql.Append("linestatus=@linestatus");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@letter", SqlDbType.VarChar,20),
					new SqlParameter("@rewritetitle", SqlDbType.VarChar,20),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@lft", SqlDbType.Int,4),
					new SqlParameter("@rgt", SqlDbType.Int,4),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@depth", SqlDbType.VarChar,200),
					new SqlParameter("@surface", SqlDbType.VarChar,200),
					new SqlParameter("@thumb", SqlDbType.VarChar,40),
					new SqlParameter("@bannel", SqlDbType.VarChar,300),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@keywords", SqlDbType.NVarChar,200),
					new SqlParameter("@template", SqlDbType.VarChar,50),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.letter;
                parameters[2].Value = model.rewritetitle;
                parameters[3].Value = model.parentid;
                parameters[4].Value = model.lft;
                parameters[5].Value = model.rgt;
                parameters[6].Value = model.lev;
                parameters[7].Value = model.depth;
                parameters[8].Value = model.surface;
                parameters[9].Value = model.thumb;
                parameters[10].Value = model.bannel;
                parameters[11].Value = model.descript;
                parameters[12].Value = model.keywords;
                parameters[13].Value = model.template;
                parameters[14].Value = model.hits;
                parameters[15].Value = model.sort;
                parameters[16].Value = model.createmid;
                parameters[17].Value = model.lastedid;
                parameters[18].Value = model.lastedittime;
                parameters[19].Value = model.linestatus;
                parameters[20].Value = model.id;

                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return model.id;
                }
            }

            return 0;

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnProductCategory GetProductCategoryInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_ProductCategory ");
            strSql.Append(strWhere);


            EnProductCategory model = new EnProductCategory();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["rewritetitle"] != null && reader["rewritetitle"].ToString() != "")
                {
                    model.rewritetitle = reader["rewritetitle"].ToString();
                }
                if (reader["parentid"] != null && reader["parentid"].ToString() != "")
                {
                    model.parentid = int.Parse(reader["parentid"].ToString());
                }
                if (reader["lft"] != null && reader["lft"].ToString() != "")
                {
                    model.lft = int.Parse(reader["lft"].ToString());
                }
                if (reader["rgt"] != null && reader["rgt"].ToString() != "")
                {
                    model.rgt = int.Parse(reader["rgt"].ToString());
                }
                if (reader["lev"] != null && reader["lev"].ToString() != "")
                {
                    model.lev = int.Parse(reader["lev"].ToString());
                }
                if (reader["depth"] != null && reader["depth"].ToString() != "")
                {
                    model.depth = reader["depth"].ToString();
                }
                if (reader["surface"] != null && reader["surface"].ToString() != "")
                {
                    model.surface = reader["surface"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["bannel"] != null && reader["bannel"].ToString() != "")
                {
                    model.bannel = reader["bannel"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["pagetitle"] != null && reader["pagetitle"].ToString() != "")
                {
                    model.pagetitle = reader["pagetitle"].ToString();
                }
                if (reader["keywords"] != null && reader["keywords"].ToString() != "")
                {
                    model.keywords = reader["keywords"].ToString();
                }
                if (reader["description"] != null && reader["description"].ToString() != "")
                {
                    model.description = reader["description"].ToString();
                }
                if (reader["template"] != null && reader["template"].ToString() != "")
                {
                    model.template = reader["template"].ToString();
                }
                if (reader["hits"] != null && reader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(reader["hits"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["createmid"] != null && reader["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(reader["createmid"].ToString());
                }
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.linestatus = int.Parse(reader["linestatus"].ToString());
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
        /// 获得数据列表
        /// </summary>
        public static List<EnProductCategory> GetProductCategoryList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnProductCategory> modelList = new List<EnProductCategory>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBProductCategory, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnProductCategory model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnProductCategory();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["rewritetitle"] != null && dt.Rows[n]["rewritetitle"].ToString() != "")
                    {
                        model.rewritetitle = dt.Rows[n]["rewritetitle"].ToString();
                    }
                    if (dt.Rows[n]["parentid"] != null && dt.Rows[n]["parentid"].ToString() != "")
                    {
                        model.parentid = int.Parse(dt.Rows[n]["parentid"].ToString());
                    }
                    if (dt.Rows[n]["lft"] != null && dt.Rows[n]["lft"].ToString() != "")
                    {
                        model.lft = int.Parse(dt.Rows[n]["lft"].ToString());
                    }
                    if (dt.Rows[n]["rgt"] != null && dt.Rows[n]["rgt"].ToString() != "")
                    {
                        model.rgt = int.Parse(dt.Rows[n]["rgt"].ToString());
                    }
                    if (dt.Rows[n]["lev"] != null && dt.Rows[n]["lev"].ToString() != "")
                    {
                        model.lev = int.Parse(dt.Rows[n]["lev"].ToString());
                    }
                    if (dt.Rows[n]["depth"] != null && dt.Rows[n]["depth"].ToString() != "")
                    {
                        model.depth = dt.Rows[n]["depth"].ToString();
                    }
                    if (dt.Rows[n]["surface"] != null && dt.Rows[n]["surface"].ToString() != "")
                    {
                        model.surface = dt.Rows[n]["surface"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["bannel"] != null && dt.Rows[n]["bannel"].ToString() != "")
                    {
                        model.bannel = dt.Rows[n]["bannel"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["keywords"] != null && dt.Rows[n]["keywords"].ToString() != "")
                    {
                        model.keywords = dt.Rows[n]["keywords"].ToString();
                    }
                    if (dt.Rows[n]["template"] != null && dt.Rows[n]["template"].ToString() != "")
                    {
                        model.template = dt.Rows[n]["template"].ToString();
                    }
                    if (dt.Rows[n]["hits"] != null && dt.Rows[n]["hits"].ToString() != "")
                    {
                        model.hits = int.Parse(dt.Rows[n]["hits"].ToString());
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["createmid"] != null && dt.Rows[n]["createmid"].ToString() != "")
                    {
                        model.createmid = int.Parse(dt.Rows[n]["createmid"].ToString());
                    }
                    if (dt.Rows[n]["lastedid"] != null && dt.Rows[n]["lastedid"].ToString() != "")
                    {
                        model.lastedid = int.Parse(dt.Rows[n]["lastedid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnProductCategory> GetProductCategoryList(string fields,string strWhere)
        {
            List<EnProductCategory> modelList = new List<EnProductCategory>();
            DataTable dt = DataCommon.GetDataTable(TableName.TBProductCategory, fields, strWhere, " order by lft");
            if (dt.Rows.Count > 0)
            {
                EnProductCategory model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnProductCategory();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["rewritetitle"] != null && dt.Rows[n]["rewritetitle"].ToString() != "")
                    {
                        model.rewritetitle = dt.Rows[n]["rewritetitle"].ToString();
                    }
                    if (dt.Rows[n]["parentid"] != null && dt.Rows[n]["parentid"].ToString() != "")
                    {
                        model.parentid = int.Parse(dt.Rows[n]["parentid"].ToString());
                    }
                    if (dt.Rows[n]["lft"] != null && dt.Rows[n]["lft"].ToString() != "")
                    {
                        model.lft = int.Parse(dt.Rows[n]["lft"].ToString());
                    }
                    if (dt.Rows[n]["rgt"] != null && dt.Rows[n]["rgt"].ToString() != "")
                    {
                        model.rgt = int.Parse(dt.Rows[n]["rgt"].ToString());
                    }
                    if (dt.Rows[n]["lev"] != null && dt.Rows[n]["lev"].ToString() != "")
                    {
                        model.lev = int.Parse(dt.Rows[n]["lev"].ToString());
                    }
                    if (dt.Rows[n]["depth"] != null && dt.Rows[n]["depth"].ToString() != "")
                    {
                        model.depth = dt.Rows[n]["depth"].ToString();
                    }
                    if (dt.Rows[n]["surface"] != null && dt.Rows[n]["surface"].ToString() != "")
                    {
                        model.surface = dt.Rows[n]["surface"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["bannel"] != null && dt.Rows[n]["bannel"].ToString() != "")
                    {
                        model.bannel = dt.Rows[n]["bannel"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["keywords"] != null && dt.Rows[n]["keywords"].ToString() != "")
                    {
                        model.keywords = dt.Rows[n]["keywords"].ToString();
                    }
                    if (dt.Rows[n]["template"] != null && dt.Rows[n]["template"].ToString() != "")
                    {
                        model.template = dt.Rows[n]["template"].ToString();
                    }
                    if (dt.Rows[n]["hits"] != null && dt.Rows[n]["hits"].ToString() != "")
                    {
                        model.hits = int.Parse(dt.Rows[n]["hits"].ToString());
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["createmid"] != null && dt.Rows[n]["createmid"].ToString() != "")
                    {
                        model.createmid = int.Parse(dt.Rows[n]["createmid"].ToString());
                    }
                    if (dt.Rows[n]["lastedid"] != null && dt.Rows[n]["lastedid"].ToString() != "")
                    {
                        model.lastedid = int.Parse(dt.Rows[n]["lastedid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获取所有产品类别
        /// <para>shen 2015-02-04</para>
        /// </summary>
        public static void ProductCategoryList()
        {
            string strsql = " select * from t_productcategory ";

            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text,strsql).Tables[0];

            List<t_productcategory> list = new List<t_productcategory>();
            t_productcategory info;

            foreach (DataRow dr in dt.Rows)
            {
                info = new t_productcategory();
                t_productcategory.FillData(dr, out info);
                list.Add(info);
            }

            List<t_productcategory> temp = list.FindAll(x => x.parentid == 0).ToList();

            foreach (t_productcategory item in temp)
            {
                item.ProCategoryList = temp.FindAll(x=>x.parentid == item.id).ToList();
            }

            TRECommon.DataCache.SetCache("ProductCategoryList", temp,DateTime.Now.AddMinutes(30),TimeSpan.Zero);

        }
    }
}
