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
    public class Brands
    {
        public static int ExitBrandTitleLetter(string title)
        {
            SqlParameter[] parames = { 
            new SqlParameter("@letter", SqlDbType.VarChar, 30)};
            parames[0].Value = title;
            return DataCommon.Exists(TableName.TBBrand, " where letter=@letter", parames);
        }

        public static int ExitBrandTitle(string title)
        {
            SqlParameter[] parames = { 
            new SqlParameter("@title", SqlDbType.NVarChar, 30)};
            parames[0].Value = title;
            return DataCommon.Exists(TableName.TBBrand, " where title=@title", parames);
        }

        public static int ExitBrandsTitle(string title)
        {
            SqlParameter[] parames = { 
            new SqlParameter("@title", SqlDbType.NVarChar, 30)};
            parames[0].Value = title;
            return DataCommon.Exists(TableName.TBBrands, " where title=@title", parames);
        }

        #region 福家网+家具快搜品牌


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnAllBrand> GetAllBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnAllBrand> modelList = new List<EnAllBrand>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TVAllBrand, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnAllBrand model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnAllBrand();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = long.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["brandid"] != null && dt.Rows[n]["brandid"].ToString() != "")
                    {
                        model.brandid = int.Parse(dt.Rows[n]["brandid"].ToString());
                    }
                    if (dt.Rows[n]["brandcode"] != null && dt.Rows[n]["brandcode"].ToString() != "")
                    {
                        model.brandcode = dt.Rows[n]["brandcode"].ToString();
                    }
                    if (dt.Rows[n]["companycode"] != null && dt.Rows[n]["companycode"].ToString() != "")
                    {
                        model.companycode = dt.Rows[n]["companycode"].ToString();
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString() + "/" + dt.Rows[n]["quanpin"].ToString() + "_" + dt.Rows[n]["fordio"].ToString();
                    }
                    if (dt.Rows[n]["quanpin"] != null && dt.Rows[n]["quanpin"].ToString() != "")
                    {
                        model.quanpin = dt.Rows[n]["quanpin"].ToString();
                    }
                    if (dt.Rows[n]["ename"] != null && dt.Rows[n]["ename"].ToString() != "")
                    {
                        model.ename = dt.Rows[n]["ename"].ToString();
                    }
                    if (dt.Rows[n]["logo"] != null && dt.Rows[n]["logo"].ToString() != "")
                    {
                        model.logo = dt.Rows[n]["logo"].ToString();
                    }
                    if (dt.Rows[n]["compayid"] != null && dt.Rows[n]["compayid"].ToString() != "")
                    {
                        model.compayid = int.Parse(dt.Rows[n]["compayid"].ToString());
                    }
                    if (dt.Rows[n]["fordio"] != null && dt.Rows[n]["fordio"].ToString() != "")
                    {
                        model.fordio = dt.Rows[n]["fordio"].ToString();
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public static List<EnBrand> GetBrandByLetter(string strWhere)
        {
            if (!string.IsNullOrEmpty(strWhere))
                strWhere = " WHERE auditstatus = 1 and companyid <> 0 and linestatus =1 AND letter IS NOT NULL AND letter <> '' AND " + strWhere;
            else
                strWhere = " WHERE auditstatus = 1 and companyid <> 0 and linestatus =1 AND letter IS NOT NULL AND letter <> '' ";
            IDataReader reader = DataCommon.GetDataIReader(TableName.TBBrand, " id,title,substring(letter,1,1) as myletter,companyid ", strWhere, " ");
            List<EnBrand> BrandList = new List<EnBrand>();
            EnBrand model = null;
            while (reader.Read())
            {
                model = new EnBrand();
                model.id = int.Parse(reader["companyid"].ToString());
                model.title = reader["title"].ToString();
                model.letter = reader["myletter"].ToString();
                BrandList.Add(model);
                model = null;
            } 
            reader.Close();
            if (!reader.IsClosed)
            {
                reader.Close();
            }
            return BrandList;
        }

        #endregion

        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditBrand(EnBrand model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_brand(");
                strSql.Append("companyid,title,letter,groupid,attribute,productcategory,homepage,productcount,spread,material,style,color,surface,logo,thumb,bannel,desimage,descript,keywords,template,hits,sort,createmid,lasteditid,lastedittime,auditstatus,linestatus)");
                strSql.Append(" values (");
                strSql.Append("@companyid,@title,@letter,@groupid,@attribute,@productcategory,@homepage,@productcount,@spread,@material,@style,@color,@surface,@logo,@thumb,@bannel,@desimage,@descript,@keywords,@template,@hits,@sort,@createmid,@lasteditid,@lastedittime,@auditstatus,@linestatus)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@companyid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@letter", SqlDbType.VarChar,20),
					new SqlParameter("@groupid", SqlDbType.Int,4),
					new SqlParameter("@attribute", SqlDbType.VarChar,100),
					new SqlParameter("@productcategory", SqlDbType.VarChar,50),
					new SqlParameter("@homepage", SqlDbType.VarChar,50),
					new SqlParameter("@productcount", SqlDbType.Int,4),
					new SqlParameter("@spread", SqlDbType.NVarChar,30),
					new SqlParameter("@material", SqlDbType.NVarChar,50),
					new SqlParameter("@style", SqlDbType.NVarChar,50),
					new SqlParameter("@color", SqlDbType.NVarChar,50),
					new SqlParameter("@surface", SqlDbType.VarChar,200),
					new SqlParameter("@logo", SqlDbType.VarChar,40),
					new SqlParameter("@thumb", SqlDbType.VarChar,40),
					new SqlParameter("@bannel", SqlDbType.VarChar,300),
					new SqlParameter("@desimage", SqlDbType.VarChar,400),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@keywords", SqlDbType.NVarChar,200),
					new SqlParameter("@template", SqlDbType.VarChar,50),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@lasteditid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4)};
                parameters[0].Value = model.companyid;
                parameters[1].Value = model.title;
                parameters[2].Value = model.letter;
                parameters[3].Value = model.groupid;
                parameters[4].Value = model.attribute;
                parameters[5].Value = model.productcategory;
                parameters[6].Value = model.homepage;
                parameters[7].Value = model.productcount;
                parameters[8].Value = model.spread;
                parameters[9].Value = model.material;
                parameters[10].Value = model.style;
                parameters[11].Value = model.color;
                parameters[12].Value = model.surface;
                parameters[13].Value = model.logo;
                parameters[14].Value = model.thumb;
                parameters[15].Value = model.bannel;
                parameters[16].Value = model.desimage;
                parameters[17].Value = model.descript;
                parameters[18].Value = model.keywords;
                parameters[19].Value = model.template;
                parameters[20].Value = model.hits;
                parameters[21].Value = model.sort;
                parameters[22].Value = model.createmid;
                parameters[23].Value = model.lasteditid;
                parameters[24].Value = model.lastedittime;
                parameters[25].Value = model.auditstatus;
                parameters[26].Value = model.linestatus;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_brand set ");
                strSql.Append("companyid=@companyid,");
                strSql.Append("title=@title,");
                strSql.Append("letter=@letter,");
                strSql.Append("groupid=@groupid,");
                strSql.Append("attribute=@attribute,");
                strSql.Append("productcategory=@productcategory,");
                strSql.Append("homepage=@homepage,");
                strSql.Append("productcount=@productcount,");
                strSql.Append("spread=@spread,");
                strSql.Append("material=@material,");
                strSql.Append("style=@style,");
                strSql.Append("color=@color,");
                strSql.Append("surface=@surface,");
                strSql.Append("logo=@logo,");
                strSql.Append("thumb=@thumb,");
                strSql.Append("bannel=@bannel,");
                strSql.Append("desimage=@desimage,");
                strSql.Append("descript=@descript,");
                strSql.Append("keywords=@keywords,");
                strSql.Append("template=@template,");
                strSql.Append("hits=@hits,");
                strSql.Append("sort=@sort,");
                strSql.Append("createmid=@createmid,");
                strSql.Append("lasteditid=@lasteditid,");
                strSql.Append("lastedittime=@lastedittime,");
                strSql.Append("auditstatus=@auditstatus,");
                strSql.Append("linestatus=@linestatus");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@companyid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@letter", SqlDbType.VarChar,20),
					new SqlParameter("@groupid", SqlDbType.Int,4),
					new SqlParameter("@attribute", SqlDbType.VarChar,100),
					new SqlParameter("@productcategory", SqlDbType.VarChar,50),
					new SqlParameter("@homepage", SqlDbType.VarChar,50),
					new SqlParameter("@productcount", SqlDbType.Int,4),
					new SqlParameter("@spread", SqlDbType.NVarChar,30),
					new SqlParameter("@material", SqlDbType.NVarChar,50),
					new SqlParameter("@style", SqlDbType.NVarChar,50),
					new SqlParameter("@color", SqlDbType.NVarChar,50),
					new SqlParameter("@surface", SqlDbType.VarChar,200),
					new SqlParameter("@logo", SqlDbType.VarChar,40),
					new SqlParameter("@thumb", SqlDbType.VarChar,40),
					new SqlParameter("@bannel", SqlDbType.VarChar,300),
					new SqlParameter("@desimage", SqlDbType.VarChar,400),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@keywords", SqlDbType.NVarChar,200),
					new SqlParameter("@template", SqlDbType.VarChar,50),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@lasteditid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.companyid;
                parameters[1].Value = model.title;
                parameters[2].Value = model.letter;
                parameters[3].Value = model.groupid;
                parameters[4].Value = model.attribute;
                parameters[5].Value = model.productcategory;
                parameters[6].Value = model.homepage;
                parameters[7].Value = model.productcount;
                parameters[8].Value = model.spread;
                parameters[9].Value = model.material;
                parameters[10].Value = model.style;
                parameters[11].Value = model.color;
                parameters[12].Value = model.surface;
                parameters[13].Value = model.logo;
                parameters[14].Value = model.thumb;
                parameters[15].Value = model.bannel;
                parameters[16].Value = model.desimage;
                parameters[17].Value = model.descript;
                parameters[18].Value = model.keywords;
                parameters[19].Value = model.template;
                parameters[20].Value = model.hits;
                parameters[21].Value = model.sort;
                parameters[22].Value = model.createmid;
                parameters[23].Value = model.lasteditid;
                parameters[24].Value = model.lastedittime;
                parameters[25].Value = model.auditstatus;
                parameters[26].Value = model.linestatus;
                parameters[27].Value = model.id;

                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return model.id;
                }
            }

            return 0;

        }

        /// <summary>
        /// 得到实体
        /// </summary>
        /// <param name="strWhere">where id=1 and ....</param>
        /// <returns></returns>
        public static EnBrand GetBrandInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_Brand ");
            strSql.Append(strWhere);


            EnBrand model = new EnBrand();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["companyid"] != null && reader["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(reader["companyid"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["groupid"] != null && reader["groupid"].ToString() != "")
                {
                    model.groupid = int.Parse(reader["groupid"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["productcategory"] != null && reader["productcategory"].ToString() != "")
                {
                    model.productcategory = reader["productcategory"].ToString();
                }
                if (reader["homepage"] != null && reader["homepage"].ToString() != "")
                {
                    model.homepage = reader["homepage"].ToString();
                }
                if (reader["productcount"] != null && reader["productcount"].ToString() != "")
                {
                    model.productcount = int.Parse(reader["productcount"].ToString());
                }
                if (reader["spread"] != null && reader["spread"].ToString() != "")
                {
                    model.spread = reader["spread"].ToString();
                }
                if (reader["material"] != null && reader["material"].ToString() != "")
                {
                    model.material = reader["material"].ToString();
                }
                if (reader["style"] != null && reader["style"].ToString() != "")
                {
                    model.style = reader["style"].ToString();
                }
                if (reader["color"] != null && reader["color"].ToString() != "")
                {
                    model.color = reader["color"].ToString();
                }
                if (reader["surface"] != null && reader["surface"].ToString() != "")
                {
                    model.surface = reader["surface"].ToString();
                }
                if (reader["logo"] != null && reader["logo"].ToString() != "")
                {
                    model.logo = reader["logo"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["bannel"] != null && reader["bannel"].ToString() != "")
                {
                    model.bannel = reader["bannel"].ToString();
                }
                if (reader["desimage"] != null && reader["desimage"].ToString() != "")
                {
                    model.desimage = reader["desimage"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["keywords"] != null && reader["keywords"].ToString() != "")
                {
                    model.keywords = reader["keywords"].ToString();
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
                if (reader["lasteditid"] != null && reader["lasteditid"].ToString() != "")
                {
                    model.lasteditid = int.Parse(reader["lasteditid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.auditstatus = int.Parse(reader["auditstatus"].ToString());
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

        #region 获取色板回收站列表
        /// <summary>
        /// 获取色板回收站列表
        /// </summary>
        public static List<t_colorswatch> GetColorSwtchRecycleList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<t_colorswatch> modelList = new List<t_colorswatch>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TVSeriesSwatchRecycle, PageIndex, PageSize, strWhere, "csid", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                t_colorswatch model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new t_colorswatch();
                    if (dt.Rows[n]["csid"].ToString() != "")
                    {
                        model.csid = int.Parse(dt.Rows[n]["csid"].ToString());
                    }
                    model.SwatchName = dt.Rows[n]["SwatchName"].ToString();
                    if (dt.Rows[n]["CategroyId"].ToString() != "")
                    {
                        model.CategroyId = int.Parse(dt.Rows[n]["CategroyId"].ToString());
                    }
                    model.Picture = dt.Rows[n]["Picture"].ToString();
                    if (dt.Rows[n]["CreateId"].ToString() != "")
                    {
                        model.CreateId = int.Parse(dt.Rows[n]["CreateId"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["bSeriesId"].ToString() != "")
                    {
                        model.bSeriesId = int.Parse(dt.Rows[n]["bSeriesId"].ToString());
                    }

                    if (dt.Rows[n]["title"].ToString() != "")
                    {
                        model.bName = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["brandsName"].ToString() != "")
                    {
                        model.brandsName = dt.Rows[n]["brandsName"].ToString();
                    }
                    if (dt.Rows[n]["Name"].ToString() != "")
                    {
                        model.cName = dt.Rows[n]["Name"].ToString();
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion

        #region 获取色板列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<t_colorswatch> GetColorSwatchList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<t_colorswatch> modelList = new List<t_colorswatch>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TVSeriesSwatch, PageIndex, PageSize, strWhere, "csid", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                t_colorswatch model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new t_colorswatch();
                    if (dt.Rows[n]["csid"].ToString() != "")
                    {
                        model.csid = int.Parse(dt.Rows[n]["csid"].ToString());
                    }
                    model.SwatchName = dt.Rows[n]["SwatchName"].ToString();
                    if (dt.Rows[n]["CategroyId"].ToString() != "")
                    {
                        model.CategroyId = int.Parse(dt.Rows[n]["CategroyId"].ToString());
                    }
                    model.Picture = dt.Rows[n]["Picture"].ToString();
                    if (dt.Rows[n]["CreateId"].ToString() != "")
                    {
                        model.CreateId = int.Parse(dt.Rows[n]["CreateId"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["bSeriesId"].ToString() != "")
                    {
                        model.bSeriesId = int.Parse(dt.Rows[n]["bSeriesId"].ToString());
                    }

                    if (dt.Rows[n]["title"].ToString() != "")
                    {
                        model.bName = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["brandsName"].ToString() != "")
                    {
                        model.brandsName = dt.Rows[n]["brandsName"].ToString();
                    }
                    if (dt.Rows[n]["Name"].ToString() != "")
                    {
                        model.cName = dt.Rows[n]["Name"].ToString();
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnBrand> GetBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnBrand> modelList = new List<EnBrand>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBBrand, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnBrand model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnBrand();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["companyid"] != null && dt.Rows[n]["companyid"].ToString() != "")
                    {
                        model.companyid = int.Parse(dt.Rows[n]["companyid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["groupid"] != null && dt.Rows[n]["groupid"].ToString() != "")
                    {
                        model.groupid = int.Parse(dt.Rows[n]["groupid"].ToString());
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["productcategory"] != null && dt.Rows[n]["productcategory"].ToString() != "")
                    {
                        model.productcategory = dt.Rows[n]["productcategory"].ToString();
                    }
                    if (dt.Rows[n]["homepage"] != null && dt.Rows[n]["homepage"].ToString() != "")
                    {
                        model.homepage = dt.Rows[n]["homepage"].ToString();
                    }
                    if (dt.Rows[n]["productcount"] != null && dt.Rows[n]["productcount"].ToString() != "")
                    {
                        model.productcount = int.Parse(dt.Rows[n]["productcount"].ToString());
                    }
                    if (dt.Rows[n]["spread"] != null && dt.Rows[n]["spread"].ToString() != "")
                    {
                        model.spread = dt.Rows[n]["spread"].ToString();
                    }
                    if (dt.Rows[n]["material"] != null && dt.Rows[n]["material"].ToString() != "")
                    {
                        model.material = dt.Rows[n]["material"].ToString();
                    }
                    if (dt.Rows[n]["style"] != null && dt.Rows[n]["style"].ToString() != "")
                    {
                        model.style = dt.Rows[n]["style"].ToString();
                    }
                    if (dt.Rows[n]["color"] != null && dt.Rows[n]["color"].ToString() != "")
                    {
                        model.color = dt.Rows[n]["color"].ToString();
                    }
                    if (dt.Rows[n]["surface"] != null && dt.Rows[n]["surface"].ToString() != "")
                    {
                        model.surface = dt.Rows[n]["surface"].ToString();
                    }
                    if (dt.Rows[n]["logo"] != null && dt.Rows[n]["logo"].ToString() != "")
                    {
                        model.logo = dt.Rows[n]["logo"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["bannel"] != null && dt.Rows[n]["bannel"].ToString() != "")
                    {
                        model.bannel = dt.Rows[n]["bannel"].ToString();
                    }
                    if (dt.Rows[n]["desimage"] != null && dt.Rows[n]["desimage"].ToString() != "")
                    {
                        model.desimage = dt.Rows[n]["desimage"].ToString();
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
                    if (dt.Rows[n]["lasteditid"] != null && dt.Rows[n]["lasteditid"].ToString() != "")
                    {
                        model.lasteditid = int.Parse(dt.Rows[n]["lasteditid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
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
        public static List<EnBrand> GetRecycleBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnBrand> modelList = new List<EnBrand>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBRecycleBrand, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnBrand model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnBrand();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["companyid"] != null && dt.Rows[n]["companyid"].ToString() != "")
                    {
                        model.companyid = int.Parse(dt.Rows[n]["companyid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["groupid"] != null && dt.Rows[n]["groupid"].ToString() != "")
                    {
                        model.groupid = int.Parse(dt.Rows[n]["groupid"].ToString());
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["productcategory"] != null && dt.Rows[n]["productcategory"].ToString() != "")
                    {
                        model.productcategory = dt.Rows[n]["productcategory"].ToString();
                    }
                    if (dt.Rows[n]["homepage"] != null && dt.Rows[n]["homepage"].ToString() != "")
                    {
                        model.homepage = dt.Rows[n]["homepage"].ToString();
                    }
                    if (dt.Rows[n]["productcount"] != null && dt.Rows[n]["productcount"].ToString() != "")
                    {
                        model.productcount = int.Parse(dt.Rows[n]["productcount"].ToString());
                    }
                    if (dt.Rows[n]["spread"] != null && dt.Rows[n]["spread"].ToString() != "")
                    {
                        model.spread = dt.Rows[n]["spread"].ToString();
                    }
                    if (dt.Rows[n]["material"] != null && dt.Rows[n]["material"].ToString() != "")
                    {
                        model.material = dt.Rows[n]["material"].ToString();
                    }
                    if (dt.Rows[n]["style"] != null && dt.Rows[n]["style"].ToString() != "")
                    {
                        model.style = dt.Rows[n]["style"].ToString();
                    }
                    if (dt.Rows[n]["color"] != null && dt.Rows[n]["color"].ToString() != "")
                    {
                        model.color = dt.Rows[n]["color"].ToString();
                    }
                    if (dt.Rows[n]["surface"] != null && dt.Rows[n]["surface"].ToString() != "")
                    {
                        model.surface = dt.Rows[n]["surface"].ToString();
                    }
                    if (dt.Rows[n]["logo"] != null && dt.Rows[n]["logo"].ToString() != "")
                    {
                        model.logo = dt.Rows[n]["logo"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["bannel"] != null && dt.Rows[n]["bannel"].ToString() != "")
                    {
                        model.bannel = dt.Rows[n]["bannel"].ToString();
                    }
                    if (dt.Rows[n]["desimage"] != null && dt.Rows[n]["desimage"].ToString() != "")
                    {
                        model.desimage = dt.Rows[n]["desimage"].ToString();
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
                    if (dt.Rows[n]["lasteditid"] != null && dt.Rows[n]["lasteditid"].ToString() != "")
                    {
                        model.lasteditid = int.Parse(dt.Rows[n]["lasteditid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
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
        public static List<EnWebBrand> GetWebBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnWebBrand> modelList = new List<EnWebBrand>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TVBrand, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnWebBrand model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnWebBrand();

                    model.companyname = dt.Rows[n]["companyname"].ToString();
                    model.attribute = dt.Rows[n]["attribute"].ToString();
                    model.productcategory = dt.Rows[n]["productcategory"].ToString();
                    model.homepage = dt.Rows[n]["homepage"].ToString();
                    if (dt.Rows[n]["productcount"].ToString() != "")
                    {
                        model.productcount = int.Parse(dt.Rows[n]["productcount"].ToString());
                    }
                    model.spread = dt.Rows[n]["spread"].ToString();
                    model.material = dt.Rows[n]["material"].ToString();
                    model.style = dt.Rows[n]["style"].ToString();
                    model.surface = dt.Rows[n]["surface"].ToString();
                    model.logo = dt.Rows[n]["logo"].ToString();
                    model.thumb = dt.Rows[n]["thumb"].ToString();
                    model.spreadname = dt.Rows[n]["spreadname"].ToString();
                    model.bannel = dt.Rows[n]["bannel"].ToString();
                    model.desimage = dt.Rows[n]["desimage"].ToString();
                    model.descript = dt.Rows[n]["descript"].ToString();
                    model.keywords = dt.Rows[n]["keywords"].ToString();
                    model.template = dt.Rows[n]["template"].ToString();
                    if (dt.Rows[n]["hits"].ToString() != "")
                    {
                        model.hits = int.Parse(dt.Rows[n]["hits"].ToString());
                    }
                    if (dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["createmid"].ToString() != "")
                    {
                        model.createmid = int.Parse(dt.Rows[n]["createmid"].ToString());
                    }
                    if (dt.Rows[n]["lasteditid"].ToString() != "")
                    {
                        model.lasteditid = int.Parse(dt.Rows[n]["lasteditid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    model.stylename = dt.Rows[n]["stylename"].ToString();
                    if (dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
                    }
                    if (dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    model.materialname = dt.Rows[n]["materialname"].ToString();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["companyid"].ToString() != "")
                    {
                        model.companyid = int.Parse(dt.Rows[n]["companyid"].ToString());
                    }
                    model.title = dt.Rows[n]["title"].ToString();
                    model.letter = dt.Rows[n]["letter"].ToString();
                    if (dt.Rows[n]["groupid"].ToString() != "")
                    {
                        model.groupid = int.Parse(dt.Rows[n]["groupid"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }




        #endregion


        /// <summary>
        /// 获得Brand数据列表
        /// </summary>
        public static List<EnBrand> GetAdminBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnBrand> modelList = new List<EnBrand>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TVAdminBrandList, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnBrand model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnBrand();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["companyid"] != null && dt.Rows[n]["companyid"].ToString() != "")
                    {
                        model.companyid = int.Parse(dt.Rows[n]["companyid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["groupid"] != null && dt.Rows[n]["groupid"].ToString() != "")
                    {
                        model.groupid = int.Parse(dt.Rows[n]["groupid"].ToString());
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["productcategory"] != null && dt.Rows[n]["productcategory"].ToString() != "")
                    {
                        model.productcategory = dt.Rows[n]["productcategory"].ToString();
                    }
                    if (dt.Rows[n]["homepage"] != null && dt.Rows[n]["homepage"].ToString() != "")
                    {
                        model.homepage = dt.Rows[n]["homepage"].ToString();
                    }
                    if (dt.Rows[n]["productcount"] != null && dt.Rows[n]["productcount"].ToString() != "")
                    {
                        model.productcount = int.Parse(dt.Rows[n]["productcount"].ToString());
                    }
                    if (dt.Rows[n]["spread"] != null && dt.Rows[n]["spread"].ToString() != "")
                    {
                        model.spread = dt.Rows[n]["spread"].ToString();
                    }
                    if (dt.Rows[n]["material"] != null && dt.Rows[n]["material"].ToString() != "")
                    {
                        model.material = dt.Rows[n]["material"].ToString();
                    }
                    if (dt.Rows[n]["style"] != null && dt.Rows[n]["style"].ToString() != "")
                    {
                        model.style = dt.Rows[n]["style"].ToString();
                    }
                    if (dt.Rows[n]["color"] != null && dt.Rows[n]["color"].ToString() != "")
                    {
                        model.color = dt.Rows[n]["color"].ToString();
                    }
                    if (dt.Rows[n]["surface"] != null && dt.Rows[n]["surface"].ToString() != "")
                    {
                        model.surface = dt.Rows[n]["surface"].ToString();
                    }
                    if (dt.Rows[n]["logo"] != null && dt.Rows[n]["logo"].ToString() != "")
                    {
                        model.logo = dt.Rows[n]["logo"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["bannel"] != null && dt.Rows[n]["bannel"].ToString() != "")
                    {
                        model.bannel = dt.Rows[n]["bannel"].ToString();
                    }
                    if (dt.Rows[n]["desimage"] != null && dt.Rows[n]["desimage"].ToString() != "")
                    {
                        model.desimage = dt.Rows[n]["desimage"].ToString();
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
                    if (dt.Rows[n]["lasteditid"] != null && dt.Rows[n]["lasteditid"].ToString() != "")
                    {
                        model.lasteditid = int.Parse(dt.Rows[n]["lasteditid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    if (dt.Rows[n]["CompanyTitle"] != null && dt.Rows[n]["CompanyTitle"].ToString() != "")
                    {
                        model.CompanyTitle = dt.Rows[n]["CompanyTitle"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #region brands


        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditBrands(EnBrands model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_brands(");
                strSql.Append("brandid,title,letter,attribute,productcount,spread,material,style,color,surface,logo,thumb,bannel,desimage,descript,keywords,template,hits,sort,createmid,lasteditid,lastedittime,auditstatus,linestatus)");
                strSql.Append(" values (");
                strSql.Append("@brandid,@title,@letter,@attribute,@productcount,@spread,@material,@style,@color,@surface,@logo,@thumb,@bannel,@desimage,@descript,@keywords,@template,@hits,@sort,@createmid,@lasteditid,@lastedittime,@auditstatus,@linestatus)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@brandid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@letter", SqlDbType.VarChar,20),
					new SqlParameter("@attribute", SqlDbType.VarChar,100),
					new SqlParameter("@productcount", SqlDbType.Int,4),
					new SqlParameter("@spread", SqlDbType.NVarChar,30),
					new SqlParameter("@material", SqlDbType.NVarChar,50),
					new SqlParameter("@style", SqlDbType.NVarChar,50),
					new SqlParameter("@surface", SqlDbType.VarChar,200),
					new SqlParameter("@logo", SqlDbType.VarChar,40),
					new SqlParameter("@thumb", SqlDbType.VarChar,40),
					new SqlParameter("@bannel", SqlDbType.VarChar,300),
					new SqlParameter("@desimage", SqlDbType.VarChar,400),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@keywords", SqlDbType.NVarChar,200),
					new SqlParameter("@template", SqlDbType.VarChar,50),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@lasteditid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
                     new SqlParameter("@color", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.brandid;
                parameters[1].Value = model.title;
                parameters[2].Value = model.letter;
                parameters[3].Value = model.attribute;
                parameters[4].Value = model.productcount;
                parameters[5].Value = model.spread;
                parameters[6].Value = model.material;
                parameters[7].Value = model.style;
                parameters[8].Value = model.surface;
                parameters[9].Value = model.logo;
                parameters[10].Value = model.thumb;
                parameters[11].Value = model.bannel;
                parameters[12].Value = model.desimage;
                parameters[13].Value = model.descript;
                parameters[14].Value = model.keywords;
                parameters[15].Value = model.template;
                parameters[16].Value = model.hits;
                parameters[17].Value = model.sort;
                parameters[18].Value = model.createmid;
                parameters[19].Value = model.lasteditid;
                parameters[20].Value = model.lastedittime;
                parameters[21].Value = model.auditstatus;
                parameters[22].Value = model.linestatus;
                parameters[23].Value = model.color;

                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_brands set ");
                strSql.Append("brandid=@brandid,");
                strSql.Append("title=@title,");
                strSql.Append("letter=@letter,");
                strSql.Append("attribute=@attribute,");
                strSql.Append("productcount=@productcount,");
                strSql.Append("spread=@spread,");
                strSql.Append("material=@material,");
                strSql.Append("style=@style,");
                strSql.Append("color=@color,");
                strSql.Append("surface=@surface,");
                strSql.Append("logo=@logo,");
                strSql.Append("thumb=@thumb,");
                strSql.Append("bannel=@bannel,");
                strSql.Append("desimage=@desimage,");
                strSql.Append("descript=@descript,");
                strSql.Append("keywords=@keywords,");
                strSql.Append("template=@template,");
                strSql.Append("hits=@hits,");
                strSql.Append("sort=@sort,");
                strSql.Append("createmid=@createmid,");
                strSql.Append("lasteditid=@lasteditid,");
                strSql.Append("lastedittime=@lastedittime,");
                strSql.Append("auditstatus=@auditstatus,");
                strSql.Append("linestatus=@linestatus");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@brandid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@letter", SqlDbType.VarChar,20),
					new SqlParameter("@attribute", SqlDbType.VarChar,100),
					new SqlParameter("@productcount", SqlDbType.Int,4),
					new SqlParameter("@spread", SqlDbType.NVarChar,30),
					new SqlParameter("@material", SqlDbType.NVarChar,50),
					new SqlParameter("@style", SqlDbType.NVarChar,50),
					new SqlParameter("@surface", SqlDbType.VarChar,200),
					new SqlParameter("@logo", SqlDbType.VarChar,40),
					new SqlParameter("@thumb", SqlDbType.VarChar,40),
					new SqlParameter("@bannel", SqlDbType.VarChar,300),
					new SqlParameter("@desimage", SqlDbType.VarChar,400),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@keywords", SqlDbType.NVarChar,200),
					new SqlParameter("@template", SqlDbType.VarChar,50),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@lasteditid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@color", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.brandid;
                parameters[1].Value = model.title;
                parameters[2].Value = model.letter;
                parameters[3].Value = model.attribute;
                parameters[4].Value = model.productcount;
                parameters[5].Value = model.spread;
                parameters[6].Value = model.material;
                parameters[7].Value = model.style;
                parameters[8].Value = model.surface;
                parameters[9].Value = model.logo;
                parameters[10].Value = model.thumb;
                parameters[11].Value = model.bannel;
                parameters[12].Value = model.desimage;
                parameters[13].Value = model.descript;
                parameters[14].Value = model.keywords;
                parameters[15].Value = model.template;
                parameters[16].Value = model.hits;
                parameters[17].Value = model.sort;
                parameters[18].Value = model.createmid;
                parameters[19].Value = model.lasteditid;
                parameters[20].Value = model.lastedittime;
                parameters[21].Value = model.auditstatus;
                parameters[22].Value = model.linestatus;
                parameters[23].Value = model.id;
                parameters[24].Value = model.color;
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
        public static EnBrands GetBrandsInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_Brands ");
            strSql.Append(strWhere);


            EnBrands model = new EnBrands();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["brandid"] != null && reader["brandid"].ToString() != "")
                {
                    model.brandid = int.Parse(reader["brandid"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["productcount"] != null && reader["productcount"].ToString() != "")
                {
                    model.productcount = int.Parse(reader["productcount"].ToString());
                }
                if (reader["spread"] != null && reader["spread"].ToString() != "")
                {
                    model.spread = reader["spread"].ToString();
                }
                if (reader["material"] != null && reader["material"].ToString() != "")
                {
                    model.material = reader["material"].ToString();
                }
                if (reader["style"] != null && reader["style"].ToString() != "")
                {
                    model.style = reader["style"].ToString();
                }
                if (reader["color"] != null && reader["color"].ToString() != "")
                {
                    model.color = reader["color"].ToString();
                }
                if (reader["surface"] != null && reader["surface"].ToString() != "")
                {
                    model.surface = reader["surface"].ToString();
                }
                if (reader["logo"] != null && reader["logo"].ToString() != "")
                {
                    model.logo = reader["logo"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["bannel"] != null && reader["bannel"].ToString() != "")
                {
                    model.bannel = reader["bannel"].ToString();
                }
                if (reader["desimage"] != null && reader["desimage"].ToString() != "")
                {
                    model.desimage = reader["desimage"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["keywords"] != null && reader["keywords"].ToString() != "")
                {
                    model.keywords = reader["keywords"].ToString();
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
                if (reader["lasteditid"] != null && reader["lasteditid"].ToString() != "")
                {
                    model.lasteditid = int.Parse(reader["lasteditid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.auditstatus = int.Parse(reader["auditstatus"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.linestatus = int.Parse(reader["linestatus"].ToString());
                }

                reader.Close();
                reader.Dispose();
                if (!reader.IsClosed)
                {
                    reader.Close();
                    reader.Dispose();
                }
                return model;
            }
            else
            {
                reader.Close();
                reader.Dispose();
                if (!reader.IsClosed)
                {
                    reader.Close();
                    reader.Dispose();
                }

                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnBrands> GetBrandsList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnBrands> modelList = new List<EnBrands>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBBrands, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnBrands model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnBrands();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["brandid"] != null && dt.Rows[n]["brandid"].ToString() != "")
                    {
                        model.brandid = int.Parse(dt.Rows[n]["brandid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["productcount"] != null && dt.Rows[n]["productcount"].ToString() != "")
                    {
                        model.productcount = int.Parse(dt.Rows[n]["productcount"].ToString());
                    }
                    if (dt.Rows[n]["spread"] != null && dt.Rows[n]["spread"].ToString() != "")
                    {
                        model.spread = dt.Rows[n]["spread"].ToString();
                    }
                    if (dt.Rows[n]["material"] != null && dt.Rows[n]["material"].ToString() != "")
                    {
                        model.material = dt.Rows[n]["material"].ToString();
                    }
                    if (dt.Rows[n]["style"] != null && dt.Rows[n]["style"].ToString() != "")
                    {
                        model.style = dt.Rows[n]["style"].ToString();
                    }
                    if (dt.Rows[n]["surface"] != null && dt.Rows[n]["surface"].ToString() != "")
                    {
                        model.surface = dt.Rows[n]["surface"].ToString();
                    }
                    if (dt.Rows[n]["logo"] != null && dt.Rows[n]["logo"].ToString() != "")
                    {
                        model.logo = dt.Rows[n]["logo"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["bannel"] != null && dt.Rows[n]["bannel"].ToString() != "")
                    {
                        model.bannel = dt.Rows[n]["bannel"].ToString();
                    }
                    if (dt.Rows[n]["desimage"] != null && dt.Rows[n]["desimage"].ToString() != "")
                    {
                        model.desimage = dt.Rows[n]["desimage"].ToString();
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
                    if (dt.Rows[n]["lasteditid"] != null && dt.Rows[n]["lasteditid"].ToString() != "")
                    {
                        model.lasteditid = int.Parse(dt.Rows[n]["lasteditid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
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
        /// 获取品牌数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static DataTable getBrandList(string where)
        {
            string sql = "SELECT (SELECT TOP 1 stylename FROM t_productrecyclerecycle WHERE stylevalue=t_brand.style) AS stylename ,(SELECT TOP 1 materialname  FROM t_productrecyclerecycle WHERE   materialvalue=t_brand.material) AS  materialname, * FROM t_brand where 1=1 " + where;
            return DbHelper.ExecuteDataset(sql).Tables[0];
        }
        #endregion

        #region AppBrand

        public static int AddAppendBrand(List<EnAppBrand> list)
        {
            List<CommandInfo> cmdList = new List<CommandInfo>();

            foreach (EnAppBrand ap in list)
            {

                if (ap.brandid != 0)
                {
                    CommandInfo model = new CommandInfo();

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into t_appbrand(");
                    strSql.Append("dealerid,dealetitle,brandid,brandtitle,companyid,companytitle,shopid,shoptitle,appmodule,apptype,apptime,createmid,lastedittime,auditstatus)");
                    strSql.Append(" values (");
                    strSql.Append("@dealerid,@dealetitle,@brandid,@brandtitle,@companyid,@companytitle,@shopid,@shoptitle,@appmodule,@apptype,@apptime,@createmid,@lastedittime,@auditstatus)");
                    strSql.Append(";select @@IDENTITY");
                    SqlParameter[] parameters = {
					new SqlParameter("@dealerid", SqlDbType.Int,4),
					new SqlParameter("@dealetitle", SqlDbType.NVarChar,50),
					new SqlParameter("@brandid", SqlDbType.Int,4),
					new SqlParameter("@brandtitle", SqlDbType.NVarChar,50),
					new SqlParameter("@companyid", SqlDbType.Int,4),
					new SqlParameter("@companytitle", SqlDbType.NVarChar,50),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@shoptitle", SqlDbType.NVarChar,50),
					new SqlParameter("@appmodule", SqlDbType.Int,4),
					new SqlParameter("@apptype", SqlDbType.Int,4),
					new SqlParameter("@apptime", SqlDbType.DateTime),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4)};
                    parameters[0].Value = ap.dealerid;
                    parameters[1].Value = ap.dealetitle;
                    parameters[2].Value = ap.brandid;
                    parameters[3].Value = ap.brandtitle;
                    parameters[4].Value = ap.companyid;
                    parameters[5].Value = ap.companytitle;
                    parameters[6].Value = ap.shopid;
                    parameters[7].Value = ap.shoptitle;
                    parameters[8].Value = ap.appmodule;
                    parameters[9].Value = ap.apptype;
                    parameters[10].Value = ap.apptime;
                    parameters[11].Value = ap.createmid;
                    parameters[12].Value = ap.lastedittime;
                    parameters[13].Value = ap.auditstatus;

                    model.CommandText = strSql.ToString();
                    model.Parameters = parameters;
                    model.EffentNextType = EffentNextType.ExcuteEffectRows;
                    cmdList.Add(model);
                }

            }

            return DbHelper.ExecuteSqlTran(cmdList);
        }

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAppBrand(EnAppBrand model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_appbrand(");
                strSql.Append("dealerid,dealetitle,brandid,brandtitle,companyid,companytitle,shopid,shoptitle,appmodule,apptype,apptime,createmid,lastedittime,auditstatus)");
                strSql.Append(" values (");
                strSql.Append("@dealerid,@dealetitle,@brandid,@brandtitle,@companyid,@companytitle,@shopid,@shoptitle,@appmodule,@apptype,@apptime,@createmid,@lastedittime,@auditstatus)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@dealerid", SqlDbType.Int,4),
					new SqlParameter("@dealetitle", SqlDbType.NVarChar,50),
					new SqlParameter("@brandid", SqlDbType.Int,4),
					new SqlParameter("@brandtitle", SqlDbType.NVarChar,50),
					new SqlParameter("@companyid", SqlDbType.Int,4),
					new SqlParameter("@companytitle", SqlDbType.NVarChar,50),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@shoptitle", SqlDbType.NVarChar,50),
					new SqlParameter("@appmodule", SqlDbType.Int,4),
					new SqlParameter("@apptype", SqlDbType.Int,4),
					new SqlParameter("@apptime", SqlDbType.DateTime),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4)};
                parameters[0].Value = model.dealerid;
                parameters[1].Value = model.dealetitle;
                parameters[2].Value = model.brandid;
                parameters[3].Value = model.brandtitle;
                parameters[4].Value = model.companyid;
                parameters[5].Value = model.companytitle;
                parameters[6].Value = model.shopid;
                parameters[7].Value = model.shoptitle;
                parameters[8].Value = model.appmodule;
                parameters[9].Value = model.apptype;
                parameters[10].Value = model.apptime;
                parameters[11].Value = model.createmid;
                parameters[12].Value = model.lastedittime;
                parameters[13].Value = model.auditstatus;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_appbrand set ");
                strSql.Append("dealerid=@dealerid,");
                strSql.Append("dealetitle=@dealetitle,");
                strSql.Append("brandid=@brandid,");
                strSql.Append("brandtitle=@brandtitle,");
                strSql.Append("companyid=@companyid,");
                strSql.Append("companytitle=@companytitle,");
                strSql.Append("shopid=@shopid,");
                strSql.Append("shoptitle=@shoptitle,");
                strSql.Append("appmodule=@appmodule,");
                strSql.Append("apptype=@apptype,");
                strSql.Append("apptime=@apptime,");
                strSql.Append("createmid=@createmid,");
                strSql.Append("lastedittime=@lastedittime,");
                strSql.Append("auditstatus=@auditstatus");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@dealerid", SqlDbType.Int,4),
					new SqlParameter("@dealetitle", SqlDbType.NVarChar,50),
					new SqlParameter("@brandid", SqlDbType.Int,4),
					new SqlParameter("@brandtitle", SqlDbType.NVarChar,50),
					new SqlParameter("@companyid", SqlDbType.Int,4),
					new SqlParameter("@companytitle", SqlDbType.NVarChar,50),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@shoptitle", SqlDbType.NVarChar,50),
					new SqlParameter("@appmodule", SqlDbType.Int,4),
					new SqlParameter("@apptype", SqlDbType.Int,4),
					new SqlParameter("@apptime", SqlDbType.DateTime),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.dealerid;
                parameters[1].Value = model.dealetitle;
                parameters[2].Value = model.brandid;
                parameters[3].Value = model.brandtitle;
                parameters[4].Value = model.companyid;
                parameters[5].Value = model.companytitle;
                parameters[6].Value = model.shopid;
                parameters[7].Value = model.shoptitle;
                parameters[8].Value = model.appmodule;
                parameters[9].Value = model.apptype;
                parameters[10].Value = model.apptime;
                parameters[11].Value = model.createmid;
                parameters[12].Value = model.lastedittime;
                parameters[13].Value = model.auditstatus;
                parameters[14].Value = model.id;

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
        public static EnAppBrand GetAppBrandInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_AppBrand ");
            strSql.Append(strWhere);


            EnAppBrand model = new EnAppBrand();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["dealerid"] != null && reader["dealerid"].ToString() != "")
                {
                    model.dealerid = int.Parse(reader["dealerid"].ToString());
                }
                if (reader["dealetitle"] != null && reader["dealetitle"].ToString() != "")
                {
                    model.dealetitle = reader["dealetitle"].ToString();
                }
                if (reader["brandid"] != null && reader["brandid"].ToString() != "")
                {
                    model.brandid = int.Parse(reader["brandid"].ToString());
                }
                if (reader["brandtitle"] != null && reader["brandtitle"].ToString() != "")
                {
                    model.brandtitle = reader["brandtitle"].ToString();
                }
                if (reader["companyid"] != null && reader["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(reader["companyid"].ToString());
                }
                if (reader["companytitle"] != null && reader["companytitle"].ToString() != "")
                {
                    model.companytitle = reader["companytitle"].ToString();
                }
                if (reader["shopid"] != null && reader["shopid"].ToString() != "")
                {
                    model.shopid = int.Parse(reader["shopid"].ToString());
                }
                if (reader["shoptitle"] != null && reader["shoptitle"].ToString() != "")
                {
                    model.shoptitle = reader["shoptitle"].ToString();
                }
                if (reader["appmodule"] != null && reader["appmodule"].ToString() != "")
                {
                    model.appmodule = int.Parse(reader["appmodule"].ToString());
                }
                if (reader["apptype"] != null && reader["apptype"].ToString() != "")
                {
                    model.apptype = int.Parse(reader["apptype"].ToString());
                }
                if (reader["apptim"] != null && reader["apptim"].ToString() != "")
                {
                    model.apptime = DateTime.Parse(reader["apptime"].ToString());
                }
                if (reader["createmid"] != null && reader["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(reader["createmid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.auditstatus = int.Parse(reader["auditstatus"].ToString());
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
        public static List<EnAppBrand> GetAppBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnAppBrand> modelList = new List<EnAppBrand>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBAppBrand, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnAppBrand model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnAppBrand();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["dealerid"] != null && dt.Rows[n]["dealerid"].ToString() != "")
                    {
                        model.dealerid = int.Parse(dt.Rows[n]["dealerid"].ToString());
                    }
                    if (dt.Rows[n]["dealetitle"] != null && dt.Rows[n]["dealetitle"].ToString() != "")
                    {
                        model.dealetitle = dt.Rows[n]["dealetitle"].ToString();
                    }
                    if (dt.Rows[n]["brandid"] != null && dt.Rows[n]["brandid"].ToString() != "")
                    {
                        model.brandid = int.Parse(dt.Rows[n]["brandid"].ToString());
                    }
                    if (dt.Rows[n]["brandtitle"] != null && dt.Rows[n]["brandtitle"].ToString() != "")
                    {
                        model.brandtitle = dt.Rows[n]["brandtitle"].ToString();
                    }
                    if (dt.Rows[n]["companyid"] != null && dt.Rows[n]["companyid"].ToString() != "")
                    {
                        model.companyid = int.Parse(dt.Rows[n]["companyid"].ToString());
                    }
                    if (dt.Rows[n]["companytitle"] != null && dt.Rows[n]["companytitle"].ToString() != "")
                    {
                        model.companytitle = dt.Rows[n]["companytitle"].ToString();
                    }
                    if (dt.Rows[n]["shopid"] != null && dt.Rows[n]["shopid"].ToString() != "")
                    {
                        model.shopid = int.Parse(dt.Rows[n]["shopid"].ToString());
                    }
                    if (dt.Rows[n]["shoptitle"] != null && dt.Rows[n]["shoptitle"].ToString() != "")
                    {
                        model.shoptitle = dt.Rows[n]["shoptitle"].ToString();
                    }
                    if (dt.Rows[n]["appmodule"] != null && dt.Rows[n]["appmodule"].ToString() != "")
                    {
                        model.appmodule = int.Parse(dt.Rows[n]["appmodule"].ToString());
                    }
                    if (dt.Rows[n]["apptype"] != null && dt.Rows[n]["apptype"].ToString() != "")
                    {
                        model.apptype = int.Parse(dt.Rows[n]["apptype"].ToString());
                    }
                    if (dt.Rows[n]["apptime"] != null && dt.Rows[n]["apptime"].ToString() != "")
                    {
                        model.apptime = DateTime.Parse(dt.Rows[n]["apptime"].ToString());
                    }
                    if (dt.Rows[n]["createmid"] != null && dt.Rows[n]["createmid"].ToString() != "")
                    {
                        model.createmid = int.Parse(dt.Rows[n]["createmid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public static List<EnAppBrand> GetAppBrandOfBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        //{
        //    List<EnAppBrand> modelList = new List<EnAppBrand>();
        //    string sql = "select * from t_appbrand a left join t_Brand b on a.brandid=b.id ";
        //    if (string.IsNullOrEmpty(strWhere))
        //    {
        //        sql += " where 1=1 and " + strWhere;
        //    }
        //    DataSet dr = DbHelper.ExecuteDataset(sql);
        //    DataTable dt = new DataTable();
        //    if (dr != null && dr.Tables[0] != null)
        //    {
        //        dt = dr.Tables[0];
        //    }
        //    if (dt.Rows.Count > 0)
        //    {
        //        EnAppBrand model;
        //        for (int n = 0; n < dt.Rows.Count; n++)
        //        {
        //            model = new EnAppBrand();
        //            if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
        //            {
        //                model.id = int.Parse(dt.Rows[n]["id"].ToString());
        //            }
        //            if (dt.Rows[n]["dealerid"] != null && dt.Rows[n]["dealerid"].ToString() != "")
        //            {
        //                model.dealerid = int.Parse(dt.Rows[n]["dealerid"].ToString());
        //            }
        //            if (dt.Rows[n]["dealetitle"] != null && dt.Rows[n]["dealetitle"].ToString() != "")
        //            {
        //                model.dealetitle = dt.Rows[n]["dealetitle"].ToString();
        //            }
        //            if (dt.Rows[n]["brandid"] != null && dt.Rows[n]["brandid"].ToString() != "")
        //            {
        //                model.brandid = int.Parse(dt.Rows[n]["brandid"].ToString());
        //            }
        //            if (dt.Rows[n]["brandtitle"] != null && dt.Rows[n]["brandtitle"].ToString() != "")
        //            {
        //                model.brandtitle = dt.Rows[n]["brandtitle"].ToString();
        //            }
        //            if (dt.Rows[n]["companyid"] != null && dt.Rows[n]["companyid"].ToString() != "")
        //            {
        //                model.companyid = int.Parse(dt.Rows[n]["companyid"].ToString());
        //            }
        //            if (dt.Rows[n]["companytitle"] != null && dt.Rows[n]["companytitle"].ToString() != "")
        //            {
        //                model.companytitle = dt.Rows[n]["companytitle"].ToString();
        //            }
        //            if (dt.Rows[n]["shopid"] != null && dt.Rows[n]["shopid"].ToString() != "")
        //            {
        //                model.shopid = int.Parse(dt.Rows[n]["shopid"].ToString());
        //            }
        //            if (dt.Rows[n]["shoptitle"] != null && dt.Rows[n]["shoptitle"].ToString() != "")
        //            {
        //                model.shoptitle = dt.Rows[n]["shoptitle"].ToString();
        //            }
        //            if (dt.Rows[n]["appmodule"] != null && dt.Rows[n]["appmodule"].ToString() != "")
        //            {
        //                model.appmodule = int.Parse(dt.Rows[n]["appmodule"].ToString());
        //            }
        //            if (dt.Rows[n]["apptype"] != null && dt.Rows[n]["apptype"].ToString() != "")
        //            {
        //                model.apptype = int.Parse(dt.Rows[n]["apptype"].ToString());
        //            }
        //            if (dt.Rows[n]["apptime"] != null && dt.Rows[n]["apptime"].ToString() != "")
        //            {
        //                model.apptime = DateTime.Parse(dt.Rows[n]["apptime"].ToString());
        //            }
        //            if (dt.Rows[n]["createmid"] != null && dt.Rows[n]["createmid"].ToString() != "")
        //            {
        //                model.createmid = int.Parse(dt.Rows[n]["createmid"].ToString());
        //            }
        //            if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
        //            {
        //                model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
        //            }
        //            if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
        //            {
        //                model.auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
        //            }
        //            modelList.Add(model);
        //        }
        //    }
        //    return modelList;
        //}

        #endregion

        #region 后台列表查询专用
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnBrands> GetAdminBrandsList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnBrands> modelList = new List<EnBrands>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TVAdminBrandsList, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnBrands model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnBrands();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["brandid"] != null && dt.Rows[n]["brandid"].ToString() != "")
                    {
                        model.brandid = int.Parse(dt.Rows[n]["brandid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["productcount"] != null && dt.Rows[n]["productcount"].ToString() != "")
                    {
                        model.productcount = int.Parse(dt.Rows[n]["productcount"].ToString());
                    }
                    if (dt.Rows[n]["spread"] != null && dt.Rows[n]["spread"].ToString() != "")
                    {
                        model.spread = dt.Rows[n]["spread"].ToString();
                    }
                    if (dt.Rows[n]["material"] != null && dt.Rows[n]["material"].ToString() != "")
                    {
                        model.material = dt.Rows[n]["material"].ToString();
                    }
                    if (dt.Rows[n]["style"] != null && dt.Rows[n]["style"].ToString() != "")
                    {
                        model.style = dt.Rows[n]["style"].ToString();
                    }
                    if (dt.Rows[n]["surface"] != null && dt.Rows[n]["surface"].ToString() != "")
                    {
                        model.surface = dt.Rows[n]["surface"].ToString();
                    }
                    if (dt.Rows[n]["logo"] != null && dt.Rows[n]["logo"].ToString() != "")
                    {
                        model.logo = dt.Rows[n]["logo"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["bannel"] != null && dt.Rows[n]["bannel"].ToString() != "")
                    {
                        model.bannel = dt.Rows[n]["bannel"].ToString();
                    }
                    if (dt.Rows[n]["desimage"] != null && dt.Rows[n]["desimage"].ToString() != "")
                    {
                        model.desimage = dt.Rows[n]["desimage"].ToString();
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
                    if (dt.Rows[n]["lasteditid"] != null && dt.Rows[n]["lasteditid"].ToString() != "")
                    {
                        model.lasteditid = int.Parse(dt.Rows[n]["lasteditid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    if (dt.Rows[n]["BrandTitle"] != null && dt.Rows[n]["BrandTitle"].ToString() != "")
                    {
                        model.brandTitle = dt.Rows[n]["BrandTitle"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion


        /// <summary>
        /// 首页商家品牌展示
        /// </summary>
        /// <returns></returns>
        public static DataSet Brandindex()
        {
            StringBuilder _value = new StringBuilder("SELECT DISTINCT SUBSTRING(letter,1,1) AS letter  FROM dbo.t_brand WHERE auditstatus=1 AND linestatus=1 AND LEN(letter)>0");
            _value.Append(" SELECT * FROM ( SELECT  title, SUBSTRING(letter,1,1) AS letter  FROM dbo.t_brand WHERE auditstatus=1 AND linestatus=1 AND LEN(letter)>0 ) bb GROUP BY title,letter");
            _value.Append("   SELECT [dbo].[f_BrandIndex](t1.id) AS indexdata,SUBSTRING(letter,1,1) AS lefirst, (SELECT  TOP 1 stylename FROM t_productrecyclerecycle WHERE stylevalue=style) AS stylename,(SELECT TOP 1 materialname FROM t_productrecyclerecycle WHERE materialvalue=material) AS materialname, t1.* FROM dbo.t_brand  t1   WHERE id IN (SELECT TOP 1 t2.id FROM t_brand t2 WHERE t2.title=t1.title ORDER BY t2.sort desc ) AND t1.auditstatus=1 AND t1.linestatus=1");
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, _value.ToString());

            return ds;
        }
        /// <summary>
        /// 高端品牌
        /// </summary>
        /// <returns></returns>
        public static DataTable BrandAdver()
        {
            string sql = "SELECT  TOP 20 * FROM t_advertising  WHERE categoryid=52 ORDER BY  id desc";
            return DbHelper.ExecuteDataset(CommandType.Text, sql).Tables[0];
        }
        /// <summary>
        /// 卖场广告
        /// </summary>
        /// <returns></returns>
        public static DataTable brandAdverMarket()
        {
            string sql = "SELECT  TOP 12 * FROM t_advertising  WHERE categoryid=54 and id!=235 ORDER BY sort desc,  id desc";
            return DbHelper.ExecuteDataset(CommandType.Text, sql).Tables[0];
        }
        /// <summary>
        /// 通过父节点获取广告位
        /// </summary>
        /// <param name="top"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static DataTable getBrandByPid(string top, string pid)
        {
            string sql = "SELECT  TOP " + top + " * FROM t_advertising  WHERE categoryid=" + pid + "  ORDER BY sort desc,  id desc";
            return DbHelper.ExecuteDataset(CommandType.Text, sql).Tables[0];
        }
        /// <summary>
        /// 首页品牌推荐
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public static DataTable BrandIndextop(int top,string where,string orderby )
        {
            if (string.IsNullOrEmpty(orderby))
            {
                orderby = "t1.id desc";
            }
            string sql = "  SELECT TOP " + top + " t1.* FROM dbo.t_brand  t1   WHERE id IN (SELECT TOP 1 t2.id FROM t_brand t2 WHERE t2.title=t1.title ORDER BY t2.sort desc ) AND t1.auditstatus=1 AND t1.linestatus=1 " + where + " ORDER BY " + orderby;

            return DbHelper.ExecuteDataset(CommandType.Text, sql).Tables[0];
        }

        #region
        /// <summary>
        /// shen 2015-02-03
        /// </summary>
        public static void GetBrand()
        {
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, " exec proc_BrandMarket ; ");

            DataTable dt = ds.Tables[0];
            List<t_brand> t_brandlist = new List<t_brand>();
            t_brand t = new t_brand();
            foreach (DataRow item in dt.Rows)
            {
                t = new t_brand();
                t_brand.FillData(item, out t);
                t_brandlist.Add(t);
            }

            dt = ds.Tables[1];
            List<t_market> t_marketlist = new List<t_market>();
            t_market tm = new t_market();
            foreach (DataRow item in dt.Rows)
            {
                tm = new t_market();
                t_market.FillData(item, out tm);
                t_marketlist.Add(tm);

            }

            dt = ds.Tables[2];
            List<t_shop> t_shoplist = new List<t_shop>();
            t_shop ts = new t_shop();
            foreach (DataRow item in dt.Rows)
            {
                ts = new t_shop();
                t_shop.FillData(item, out ts);
                t_shoplist.Add(ts);

            }
            dt = ds.Tables[3];
            List<t_company> t_companylist = new List<t_company>();
            t_company tc = new t_company();
            foreach (DataRow item in dt.Rows)
            {
                tc = new t_company();
                t_company.FillData(item, out tc);
                t_companylist.Add(tc);

            }
            dt = ds.Tables[4];
            List<t_dealer> t_dealerlist = new List<t_dealer>();
            t_dealer td = new t_dealer();
            foreach (DataRow item in dt.Rows)
            {
                td = new t_dealer();
                t_dealer.FillData(item, out td);
                t_dealerlist.Add(td);

            }
            BrandAndMarket bm = new BrandAndMarket();
            bm.brandlist = t_brandlist;
            bm.companylist = t_companylist;
            bm.dealerlist = t_dealerlist;
            bm.marketlist = t_marketlist;
            bm.shoplist = t_shoplist;
            TRECommon.DataCache.SetCache("brandandmarket", bm, DateTime.Now.AddMinutes(10), TimeSpan.Zero);


        }
        #endregion



    }
}
