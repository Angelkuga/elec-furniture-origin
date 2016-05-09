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
    public class Articles
    {
        

        #region article

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditArticle(EnArticle model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_article(");
                strSql.Append("attribute,title,subtitle,letter,categoryid,subcategoryid,ico,thumb,banner,keyword,descript,context,othercon,source,autho,linkurl,clickcount,sort,createtime,createid,edittime,editid)");
                strSql.Append(" values (");
                strSql.Append("@attribute,@title,@subtitle,@letter,@categoryid,@subcategoryid,@ico,@thumb,@banner,@keyword,@descript,@context,@othercon,@source,@autho,@linkurl,@clickcount,@sort,@createtime,@createid,@edittime,@editid)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@attribute", SqlDbType.VarChar,30),
					new SqlParameter("@title", SqlDbType.NVarChar,60),
					new SqlParameter("@subtitle", SqlDbType.NVarChar,30),
					new SqlParameter("@letter", SqlDbType.VarChar,50),
					new SqlParameter("@categoryid", SqlDbType.Int,4),
					new SqlParameter("@subcategoryid", SqlDbType.VarChar,50),
					new SqlParameter("@ico", SqlDbType.VarChar,30),
					new SqlParameter("@thumb", SqlDbType.VarChar,30),
					new SqlParameter("@banner", SqlDbType.VarChar,300),
					new SqlParameter("@keyword", SqlDbType.NVarChar,100),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@context", SqlDbType.Text),
					new SqlParameter("@othercon", SqlDbType.VarChar,600),
					new SqlParameter("@source", SqlDbType.NVarChar,30),
					new SqlParameter("@autho", SqlDbType.NVarChar,30),
					new SqlParameter("@linkurl", SqlDbType.VarChar,200),
					new SqlParameter("@clickcount", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@createid", SqlDbType.Int,4),
					new SqlParameter("@edittime", SqlDbType.DateTime),
					new SqlParameter("@editid", SqlDbType.Int,4)};
                parameters[0].Value = model.attribute;
                parameters[1].Value = model.title;
                parameters[2].Value = model.subtitle;
                parameters[3].Value = model.letter;
                parameters[4].Value = model.categoryid;
                parameters[5].Value = model.subcategoryid;
                parameters[6].Value = model.ico;
                parameters[7].Value = model.thumb;
                parameters[8].Value = model.banner;
                parameters[9].Value = model.keyword;
                parameters[10].Value = model.descript;
                parameters[11].Value = model.context;
                parameters[12].Value = model.othercon;
                parameters[13].Value = model.source;
                parameters[14].Value = model.autho;
                parameters[15].Value = model.linkurl;
                parameters[16].Value = model.clickcount;
                parameters[17].Value = model.sort;
                parameters[18].Value = model.createtime;
                parameters[19].Value = model.createid;
                parameters[20].Value = model.edittime;
                parameters[21].Value = model.editid;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_article set ");
                strSql.Append("attribute=@attribute,");
                strSql.Append("title=@title,");
                strSql.Append("subtitle=@subtitle,");
                strSql.Append("letter=@letter,");
                strSql.Append("categoryid=@categoryid,");
                strSql.Append("subcategoryid=@subcategoryid,");
                strSql.Append("ico=@ico,");
                strSql.Append("thumb=@thumb,");
                strSql.Append("banner=@banner,");
                strSql.Append("keyword=@keyword,");
                strSql.Append("descript=@descript,");
                strSql.Append("context=@context,");
                strSql.Append("othercon=@othercon,");
                strSql.Append("source=@source,");
                strSql.Append("autho=@autho,");
                strSql.Append("linkurl=@linkurl,");
                strSql.Append("clickcount=@clickcount,");
                strSql.Append("sort=@sort,");
                strSql.Append("createtime=@createtime,");
                strSql.Append("createid=@createid,");
                strSql.Append("edittime=@edittime,");
                strSql.Append("editid=@editid");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@attribute", SqlDbType.VarChar,30),
					new SqlParameter("@title", SqlDbType.NVarChar,60),
					new SqlParameter("@subtitle", SqlDbType.NVarChar,30),
					new SqlParameter("@letter", SqlDbType.VarChar,50),
					new SqlParameter("@categoryid", SqlDbType.Int,4),
					new SqlParameter("@subcategoryid", SqlDbType.VarChar,50),
					new SqlParameter("@ico", SqlDbType.VarChar,30),
					new SqlParameter("@thumb", SqlDbType.VarChar,30),
					new SqlParameter("@banner", SqlDbType.VarChar,300),
					new SqlParameter("@keyword", SqlDbType.NVarChar,100),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@context", SqlDbType.Text),
					new SqlParameter("@othercon", SqlDbType.VarChar,600),
					new SqlParameter("@source", SqlDbType.NVarChar,30),
					new SqlParameter("@autho", SqlDbType.NVarChar,30),
					new SqlParameter("@linkurl", SqlDbType.VarChar,200),
					new SqlParameter("@clickcount", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@createid", SqlDbType.Int,4),
					new SqlParameter("@edittime", SqlDbType.DateTime),
					new SqlParameter("@editid", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.attribute;
                parameters[1].Value = model.title;
                parameters[2].Value = model.subtitle;
                parameters[3].Value = model.letter;
                parameters[4].Value = model.categoryid;
                parameters[5].Value = model.subcategoryid;
                parameters[6].Value = model.ico;
                parameters[7].Value = model.thumb;
                parameters[8].Value = model.banner;
                parameters[9].Value = model.keyword;
                parameters[10].Value = model.descript;
                parameters[11].Value = model.context;
                parameters[12].Value = model.othercon;
                parameters[13].Value = model.source;
                parameters[14].Value = model.autho;
                parameters[15].Value = model.linkurl;
                parameters[16].Value = model.clickcount;
                parameters[17].Value = model.sort;
                parameters[18].Value = model.createtime;
                parameters[19].Value = model.createid;
                parameters[20].Value = model.edittime;
                parameters[21].Value = model.editid;
                parameters[22].Value = model.id;

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
        public static EnArticle GetArticleInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_Article ");
            strSql.Append(strWhere);


            EnArticle model = new EnArticle();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["subtitle"] != null && reader["subtitle"].ToString() != "")
                {
                    model.subtitle = reader["subtitle"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["categoryid"] != null && reader["categoryid"].ToString() != "")
                {
                    model.categoryid = int.Parse(reader["categoryid"].ToString());
                }
                if (reader["subcategoryid"] != null && reader["subcategoryid"].ToString() != "")
                {
                    model.subcategoryid = reader["subcategoryid"].ToString();
                }
                if (reader["ico"] != null && reader["ico"].ToString() != "")
                {
                    model.ico = reader["ico"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["banner"] != null && reader["banner"].ToString() != "")
                {
                    model.banner = reader["banner"].ToString();
                }
                if (reader["keyword"] != null && reader["keyword"].ToString() != "")
                {
                    model.keyword = reader["keyword"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["context"] != null && reader["context"].ToString() != "")
                {
                    model.context = reader["context"].ToString();
                }
                if (reader["othercon"] != null && reader["othercon"].ToString() != "")
                {
                    model.othercon = reader["othercon"].ToString();
                }
                if (reader["source"] != null && reader["source"].ToString() != "")
                {
                    model.source = reader["source"].ToString();
                }
                if (reader["autho"] != null && reader["autho"].ToString() != "")
                {
                    model.autho = reader["autho"].ToString();
                }
                if (reader["linkurl"] != null && reader["linkurl"].ToString() != "")
                {
                    model.linkurl = reader["linkurl"].ToString();
                }
                if (reader["clickcount"] != null && reader["clickcount"].ToString() != "")
                {
                    model.clickcount = int.Parse(reader["clickcount"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["createtime"] != null && reader["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(reader["createtime"].ToString());
                }
                if (reader["createid"] != null && reader["createid"].ToString() != "")
                {
                    model.createid = int.Parse(reader["createid"].ToString());
                }
                if (reader["edittime"] != null && reader["edittime"].ToString() != "")
                {
                    model.edittime = DateTime.Parse(reader["edittime"].ToString());
                }
                if (reader["editid"] != null && reader["editid"].ToString() != "")
                {
                    model.editid = int.Parse(reader["editid"].ToString());
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
        public static List<EnArticle> GetArticleList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnArticle> modelList = new List<EnArticle>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TVArticle, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnArticle model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnArticle();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["subtitle"] != null && dt.Rows[n]["subtitle"].ToString() != "")
                    {
                        model.subtitle = dt.Rows[n]["subtitle"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["categoryid"] != null && dt.Rows[n]["categoryid"].ToString() != "")
                    {
                        model.categoryid = int.Parse(dt.Rows[n]["categoryid"].ToString());
                    }
                    if (dt.Rows[n]["subcategoryid"] != null && dt.Rows[n]["subcategoryid"].ToString() != "")
                    {
                        model.subcategoryid = dt.Rows[n]["subcategoryid"].ToString();
                    }
                    if (dt.Rows[n]["ico"] != null && dt.Rows[n]["ico"].ToString() != "")
                    {
                        model.ico = dt.Rows[n]["ico"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["banner"] != null && dt.Rows[n]["banner"].ToString() != "")
                    {
                        model.banner = dt.Rows[n]["banner"].ToString();
                    }
                    if (dt.Rows[n]["keyword"] != null && dt.Rows[n]["keyword"].ToString() != "")
                    {
                        model.keyword = dt.Rows[n]["keyword"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["context"] != null && dt.Rows[n]["context"].ToString() != "")
                    {
                        model.context = dt.Rows[n]["context"].ToString();
                    }
                    if (dt.Rows[n]["othercon"] != null && dt.Rows[n]["othercon"].ToString() != "")
                    {
                        model.othercon = dt.Rows[n]["othercon"].ToString();
                    }
                    if (dt.Rows[n]["source"] != null && dt.Rows[n]["source"].ToString() != "")
                    {
                        model.source = dt.Rows[n]["source"].ToString();
                    }
                    if (dt.Rows[n]["autho"] != null && dt.Rows[n]["autho"].ToString() != "")
                    {
                        model.autho = dt.Rows[n]["autho"].ToString();
                    }
                    if (dt.Rows[n]["linkurl"] != null && dt.Rows[n]["linkurl"].ToString() != "")
                    {
                        model.linkurl = dt.Rows[n]["linkurl"].ToString();
                    }
                    if (dt.Rows[n]["clickcount"] != null && dt.Rows[n]["clickcount"].ToString() != "")
                    {
                        model.clickcount = int.Parse(dt.Rows[n]["clickcount"].ToString());
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["createtime"] != null && dt.Rows[n]["createtime"].ToString() != "")
                    {
                        model.createtime = DateTime.Parse(dt.Rows[n]["createtime"].ToString());
                    }
                    if (dt.Rows[n]["createid"] != null && dt.Rows[n]["createid"].ToString() != "")
                    {
                        model.createid = int.Parse(dt.Rows[n]["createid"].ToString());
                    }
                    if (dt.Rows[n]["edittime"] != null && dt.Rows[n]["edittime"].ToString() != "")
                    {
                        model.edittime = DateTime.Parse(dt.Rows[n]["edittime"].ToString());
                    }
                    if (dt.Rows[n]["editid"] != null && dt.Rows[n]["editid"].ToString() != "")
                    {
                        model.editid = int.Parse(dt.Rows[n]["editid"].ToString());
                    }
                    if (dt.Rows[n]["cletter"] != null && dt.Rows[n]["cletter"].ToString() != "")
                    {
                        model.cletter = dt.Rows[n]["cletter"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        ///获取数据列表
        public static List<EnArticle> GetArticleList(int pageIndex, int pagesSize, string strWhere, string field, string sortkey, string orderByType, out int pageCount)
        {
            IDataReader reader = DataCommon.GetPageDataReader(TableName.TVArticle, pageIndex, pagesSize, strWhere, sortkey, orderByType, out pageCount);
            List<EnArticle> list = new List<EnArticle>();
            while (reader.Read())
            {
                EnArticle model = new EnArticle();
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["subtitle"] != null && reader["subtitle"].ToString() != "")
                {
                    model.subtitle = reader["subtitle"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["categoryid"] != null && reader["categoryid"].ToString() != "")
                {
                    model.categoryid = int.Parse(reader["categoryid"].ToString());
                }
                if (reader["subcategoryid"] != null && reader["subcategoryid"].ToString() != "")
                {
                    model.subcategoryid = reader["subcategoryid"].ToString();
                }
                if (reader["ico"] != null && reader["ico"].ToString() != "")
                {
                    model.ico = reader["ico"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["banner"] != null && reader["banner"].ToString() != "")
                {
                    model.banner = reader["banner"].ToString();
                }
                if (reader["keyword"] != null && reader["keyword"].ToString() != "")
                {
                    model.keyword = reader["keyword"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["context"] != null && reader["context"].ToString() != "")
                {
                    model.context = reader["context"].ToString();
                }
                if (reader["othercon"] != null && reader["othercon"].ToString() != "")
                {
                    model.othercon = reader["othercon"].ToString();
                }
                if (reader["source"] != null && reader["source"].ToString() != "")
                {
                    model.source = reader["source"].ToString();
                }
                if (reader["autho"] != null && reader["autho"].ToString() != "")
                {
                    model.autho = reader["autho"].ToString();
                }
                if (reader["linkurl"] != null && reader["linkurl"].ToString() != "")
                {
                    model.linkurl = reader["linkurl"].ToString();
                }
                if (reader["clickcount"] != null && reader["clickcount"].ToString() != "")
                {
                    model.clickcount = int.Parse(reader["clickcount"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["createtime"] != null && reader["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(reader["createtime"].ToString());
                }
                if (reader["createid"] != null && reader["createid"].ToString() != "")
                {
                    model.createid = int.Parse(reader["createid"].ToString());
                }
                if (reader["edittime"] != null && reader["edittime"].ToString() != "")
                {
                    model.edittime = DateTime.Parse(reader["edittime"].ToString());
                }
                if (reader["editid"] != null && reader["editid"].ToString() != "")
                {
                    model.editid = int.Parse(reader["editid"].ToString());
                }

                if (reader["cletter"] != null && reader["cletter"].ToString() != "")
                {
                    model.cletter = reader["cletter"].ToString();
                }
                list.Add(model);
            }

            reader.Close();
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return list;
        }

        #endregion

        #region articlecategory
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditArticleCategory(EnArticleCategory model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_articlecategory(");
                strSql.Append("attribute,title,subtitle,letter,ico,thumb,banner,keyword,descript,context,othercon,linktype,linkurl,parentid,lft,rgt,depth,lev,indextemplate,listtemplate,contemplate,sort,createtime,createid,edittime,editid)");
                strSql.Append(" values (");
                strSql.Append("@attribute,@title,@subtitle,@letter,@ico,@thumb,@banner,@keyword,@descript,@context,@othercon,@linktype,@linkurl,@parentid,@lft,@rgt,@depth,@lev,@indextemplate,@listtemplate,@contemplate,@sort,@createtime,@createid,@edittime,@editid)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@attribute", SqlDbType.VarChar,30),
					new SqlParameter("@title", SqlDbType.NVarChar,60),
					new SqlParameter("@subtitle", SqlDbType.NVarChar,30),
					new SqlParameter("@letter", SqlDbType.VarChar,50),
					new SqlParameter("@ico", SqlDbType.VarChar,30),
					new SqlParameter("@thumb", SqlDbType.VarChar,30),
					new SqlParameter("@banner", SqlDbType.VarChar,300),
					new SqlParameter("@keyword", SqlDbType.NVarChar,100),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@context", SqlDbType.NText),
					new SqlParameter("@othercon", SqlDbType.VarChar,600),
					new SqlParameter("@linktype", SqlDbType.Int,4),
					new SqlParameter("@linkurl", SqlDbType.VarChar,200),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@lft", SqlDbType.Int,4),
					new SqlParameter("@rgt", SqlDbType.Int,4),
					new SqlParameter("@depth", SqlDbType.VarChar,500),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@indextemplate", SqlDbType.VarChar,60),
					new SqlParameter("@listtemplate", SqlDbType.VarChar,60),
					new SqlParameter("@contemplate", SqlDbType.VarChar,60),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@createid", SqlDbType.Int,4),
					new SqlParameter("@edittime", SqlDbType.DateTime),
					new SqlParameter("@editid", SqlDbType.Int,4)};
                parameters[0].Value = model.attribute;
                parameters[1].Value = model.title;
                parameters[2].Value = model.subtitle;
                parameters[3].Value = model.letter;
                parameters[4].Value = model.ico;
                parameters[5].Value = model.thumb;
                parameters[6].Value = model.banner;
                parameters[7].Value = model.keyword;
                parameters[8].Value = model.descript;
                parameters[9].Value = model.context;
                parameters[10].Value = model.othercon;
                parameters[11].Value = model.linktype;
                parameters[12].Value = model.linkurl;
                parameters[13].Value = model.parentid;
                parameters[14].Value = model.lft;
                parameters[15].Value = model.rgt;
                parameters[16].Value = model.depth;
                parameters[17].Value = model.lev;
                parameters[18].Value = model.indextemplate;
                parameters[19].Value = model.listtemplate;
                parameters[20].Value = model.contemplate;
                parameters[21].Value = model.sort;
                parameters[22].Value = model.createtime;
                parameters[23].Value = model.createid;
                parameters[24].Value = model.edittime;
                parameters[25].Value = model.editid;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_articlecategory set ");
                strSql.Append("attribute=@attribute,");
                strSql.Append("title=@title,");
                strSql.Append("subtitle=@subtitle,");
                strSql.Append("letter=@letter,");
                strSql.Append("ico=@ico,");
                strSql.Append("thumb=@thumb,");
                strSql.Append("banner=@banner,");
                strSql.Append("keyword=@keyword,");
                strSql.Append("descript=@descript,");
                strSql.Append("context=@context,");
                strSql.Append("othercon=@othercon,");
                strSql.Append("linktype=@linktype,");
                strSql.Append("linkurl=@linkurl,");
                strSql.Append("parentid=@parentid,");
                strSql.Append("lft=@lft,");
                strSql.Append("rgt=@rgt,");
                strSql.Append("depth=@depth,");
                strSql.Append("lev=@lev,");
                strSql.Append("indextemplate=@indextemplate,");
                strSql.Append("listtemplate=@listtemplate,");
                strSql.Append("contemplate=@contemplate,");
                strSql.Append("sort=@sort,");
                strSql.Append("createtime=@createtime,");
                strSql.Append("createid=@createid,");
                strSql.Append("edittime=@edittime,");
                strSql.Append("editid=@editid");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@attribute", SqlDbType.VarChar,30),
					new SqlParameter("@title", SqlDbType.NVarChar,60),
					new SqlParameter("@subtitle", SqlDbType.NVarChar,30),
					new SqlParameter("@letter", SqlDbType.VarChar,50),
					new SqlParameter("@ico", SqlDbType.VarChar,30),
					new SqlParameter("@thumb", SqlDbType.VarChar,30),
					new SqlParameter("@banner", SqlDbType.VarChar,300),
					new SqlParameter("@keyword", SqlDbType.NVarChar,100),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@context", SqlDbType.NText),
					new SqlParameter("@othercon", SqlDbType.VarChar,600),
					new SqlParameter("@linktype", SqlDbType.Int,4),
					new SqlParameter("@linkurl", SqlDbType.VarChar,200),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@lft", SqlDbType.Int,4),
					new SqlParameter("@rgt", SqlDbType.Int,4),
					new SqlParameter("@depth", SqlDbType.VarChar,500),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@indextemplate", SqlDbType.VarChar,60),
					new SqlParameter("@listtemplate", SqlDbType.VarChar,60),
					new SqlParameter("@contemplate", SqlDbType.VarChar,60),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@createid", SqlDbType.Int,4),
					new SqlParameter("@edittime", SqlDbType.DateTime),
					new SqlParameter("@editid", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.attribute;
                parameters[1].Value = model.title;
                parameters[2].Value = model.subtitle;
                parameters[3].Value = model.letter;
                parameters[4].Value = model.ico;
                parameters[5].Value = model.thumb;
                parameters[6].Value = model.banner;
                parameters[7].Value = model.keyword;
                parameters[8].Value = model.descript;
                parameters[9].Value = model.context;
                parameters[10].Value = model.othercon;
                parameters[11].Value = model.linktype;
                parameters[12].Value = model.linkurl;
                parameters[13].Value = model.parentid;
                parameters[14].Value = model.lft;
                parameters[15].Value = model.rgt;
                parameters[16].Value = model.depth;
                parameters[17].Value = model.lev;
                parameters[18].Value = model.indextemplate;
                parameters[19].Value = model.listtemplate;
                parameters[20].Value = model.contemplate;
                parameters[21].Value = model.sort;
                parameters[22].Value = model.createtime;
                parameters[23].Value = model.createid;
                parameters[24].Value = model.edittime;
                parameters[25].Value = model.editid;
                parameters[26].Value = model.id;

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
        public static EnArticleCategory GetArticleCategoryInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from t_ArticleCategory ");
            strSql.Append(strWhere);


            EnArticleCategory model = new EnArticleCategory();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["subtitle"] != null && reader["subtitle"].ToString() != "")
                {
                    model.subtitle = reader["subtitle"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["ico"] != null && reader["ico"].ToString() != "")
                {
                    model.ico = reader["ico"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["banner"] != null && reader["banner"].ToString() != "")
                {
                    model.banner = reader["banner"].ToString();
                }
                if (reader["keyword"] != null && reader["keyword"].ToString() != "")
                {
                    model.keyword = reader["keyword"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["context"] != null && reader["context"].ToString() != "")
                {
                    model.context = reader["context"].ToString();
                }
                if (reader["othercon"] != null && reader["othercon"].ToString() != "")
                {
                    model.othercon = reader["othercon"].ToString();
                }
                if (reader["linktype"] != null && reader["linktype"].ToString() != "")
                {
                    model.linktype = int.Parse(reader["linktype"].ToString());
                }
                if (reader["linkurl"] != null && reader["linkurl"].ToString() != "")
                {
                    model.linkurl = reader["linkurl"].ToString();
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
                if (reader["depth"] != null && reader["depth"].ToString() != "")
                {
                    model.depth = reader["depth"].ToString();
                }
                if (reader["lev"] != null && reader["lev"].ToString() != "")
                {
                    model.lev = int.Parse(reader["lev"].ToString());
                }
                if (reader["indextemplate"] != null && reader["indextemplate"].ToString() != "")
                {
                    model.indextemplate = reader["indextemplate"].ToString();
                }
                if (reader["listtemplate"] != null && reader["listtemplate"].ToString() != "")
                {
                    model.listtemplate = reader["listtemplate"].ToString();
                }
                if (reader["contemplate"] != null && reader["contemplate"].ToString() != "")
                {
                    model.contemplate = reader["contemplate"].ToString();
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["createtime"] != null && reader["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(reader["createtime"].ToString());
                }
                if (reader["createid"] != null && reader["createid"].ToString() != "")
                {
                    model.createid = int.Parse(reader["createid"].ToString());
                }
                if (reader["edittime"] != null && reader["edittime"].ToString() != "")
                {
                    model.edittime = DateTime.Parse(reader["edittime"].ToString());
                }
                if (reader["editid"] != null && reader["editid"].ToString() != "")
                {
                    model.editid = int.Parse(reader["editid"].ToString());
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
        public static List<EnArticleCategory> GetArticleCategoryList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnArticleCategory> modelList = new List<EnArticleCategory>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBArticleCategory, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnArticleCategory model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnArticleCategory();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["subtitle"] != null && dt.Rows[n]["subtitle"].ToString() != "")
                    {
                        model.subtitle = dt.Rows[n]["subtitle"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["ico"] != null && dt.Rows[n]["ico"].ToString() != "")
                    {
                        model.ico = dt.Rows[n]["ico"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["banner"] != null && dt.Rows[n]["banner"].ToString() != "")
                    {
                        model.banner = dt.Rows[n]["banner"].ToString();
                    }
                    if (dt.Rows[n]["keyword"] != null && dt.Rows[n]["keyword"].ToString() != "")
                    {
                        model.keyword = dt.Rows[n]["keyword"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["context"] != null && dt.Rows[n]["context"].ToString() != "")
                    {
                        model.context = dt.Rows[n]["context"].ToString();
                    }
                    if (dt.Rows[n]["othercon"] != null && dt.Rows[n]["othercon"].ToString() != "")
                    {
                        model.othercon = dt.Rows[n]["othercon"].ToString();
                    }
                    if (dt.Rows[n]["linktype"] != null && dt.Rows[n]["linktype"].ToString() != "")
                    {
                        model.linktype = int.Parse(dt.Rows[n]["linktype"].ToString());
                    }
                    if (dt.Rows[n]["linkurl"] != null && dt.Rows[n]["linkurl"].ToString() != "")
                    {
                        model.linkurl = dt.Rows[n]["linkurl"].ToString();
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
                    if (dt.Rows[n]["depth"] != null && dt.Rows[n]["depth"].ToString() != "")
                    {
                        model.depth = dt.Rows[n]["depth"].ToString();
                    }
                    if (dt.Rows[n]["lev"] != null && dt.Rows[n]["lev"].ToString() != "")
                    {
                        model.lev = int.Parse(dt.Rows[n]["lev"].ToString());
                    }
                    if (dt.Rows[n]["indextemplate"] != null && dt.Rows[n]["indextemplate"].ToString() != "")
                    {
                        model.indextemplate = dt.Rows[n]["indextemplate"].ToString();
                    }
                    if (dt.Rows[n]["listtemplate"] != null && dt.Rows[n]["listtemplate"].ToString() != "")
                    {
                        model.listtemplate = dt.Rows[n]["listtemplate"].ToString();
                    }
                    if (dt.Rows[n]["contemplate"] != null && dt.Rows[n]["contemplate"].ToString() != "")
                    {
                        model.contemplate = dt.Rows[n]["contemplate"].ToString();
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["createtime"] != null && dt.Rows[n]["createtime"].ToString() != "")
                    {
                        model.createtime = DateTime.Parse(dt.Rows[n]["createtime"].ToString());
                    }
                    if (dt.Rows[n]["createid"] != null && dt.Rows[n]["createid"].ToString() != "")
                    {
                        model.createid = int.Parse(dt.Rows[n]["createid"].ToString());
                    }
                    if (dt.Rows[n]["edittime"] != null && dt.Rows[n]["edittime"].ToString() != "")
                    {
                        model.edittime = DateTime.Parse(dt.Rows[n]["edittime"].ToString());
                    }
                    if (dt.Rows[n]["editid"] != null && dt.Rows[n]["editid"].ToString() != "")
                    {
                        model.editid = int.Parse(dt.Rows[n]["editid"].ToString());
                    }					

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        ///获取数据列表
        public static List<EnArticleCategory> GetArticleCategoryList(int pageIndex, int pagesSize, string strWhere, string field, string sortkey, string orderByType, out int pageCount)
        {
            IDataReader reader = DataCommon.GetPageDataReader(TableName.TBArticleCategory, pageIndex, pagesSize, strWhere, sortkey, orderByType, out pageCount);
            List<EnArticleCategory> list = new List<EnArticleCategory>();
            while (reader.Read())
            {
                EnArticleCategory model = new EnArticleCategory();
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["subtitle"] != null && reader["subtitle"].ToString() != "")
                {
                    model.subtitle = reader["subtitle"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["ico"] != null && reader["ico"].ToString() != "")
                {
                    model.ico = reader["ico"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["banner"] != null && reader["banner"].ToString() != "")
                {
                    model.banner = reader["banner"].ToString();
                }
                if (reader["keyword"] != null && reader["keyword"].ToString() != "")
                {
                    model.keyword = reader["keyword"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["context"] != null && reader["context"].ToString() != "")
                {
                    model.context = reader["context"].ToString();
                }
                if (reader["othercon"] != null && reader["othercon"].ToString() != "")
                {
                    model.othercon = reader["othercon"].ToString();
                }
                if (reader["linktype"] != null && reader["linktype"].ToString() != "")
                {
                    model.linktype = int.Parse(reader["linktype"].ToString());
                }
                if (reader["linkurl"] != null && reader["linkurl"].ToString() != "")
                {
                    model.linkurl = reader["linkurl"].ToString();
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
                if (reader["depth"] != null && reader["depth"].ToString() != "")
                {
                    model.depth = reader["depth"].ToString();
                }
                if (reader["lev"] != null && reader["lev"].ToString() != "")
                {
                    model.lev = int.Parse(reader["lev"].ToString());
                }
                if (reader["indextemplate"] != null && reader["indextemplate"].ToString() != "")
                {
                    model.indextemplate = reader["indextemplate"].ToString();
                }
                if (reader["listtemplate"] != null && reader["listtemplate"].ToString() != "")
                {
                    model.listtemplate = reader["listtemplate"].ToString();
                }
                if (reader["contemplate"] != null && reader["contemplate"].ToString() != "")
                {
                    model.contemplate = reader["contemplate"].ToString();
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["createtime"] != null && reader["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(reader["createtime"].ToString());
                }
                if (reader["createid"] != null && reader["createid"].ToString() != "")
                {
                    model.createid = int.Parse(reader["createid"].ToString());
                }
                if (reader["edittime"] != null && reader["edittime"].ToString() != "")
                {
                    model.edittime = DateTime.Parse(reader["edittime"].ToString());
                }
                if (reader["editid"] != null && reader["editid"].ToString() != "")
                {
                    model.editid = int.Parse(reader["editid"].ToString());
                }

                list.Add(model);
            }

            reader.Close();
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return list;
        }


        #endregion
    }
}
