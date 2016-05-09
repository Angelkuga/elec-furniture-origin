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
    public class Advertisements
    {
        #region 共公广告

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAdvertisement(EnAdvertisement model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_advertising(");
                strSql.Append("categoryid,title,linkurl,flashurl,imgurl,videourl,adtext,adcode,isopen,adlinkman,adlinkphone,adlinkemail,lastedittime,lasteditaid,price,starttime,endtime,sort,orgprice,imgurlfull)");
                strSql.Append(" values (");
                strSql.Append("@categoryid,@title,@linkurl,@flashurl,@imgurl,@videourl,@adtext,@adcode,@isopen,@adlinkman,@adlinkphone,@adlinkemail,@lastedittime,@lasteditaid,@price,@starttime,@endtime,@sort,@orgprice,@imgurlfull)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@categoryid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@linkurl", SqlDbType.VarChar,100),
					new SqlParameter("@flashurl", SqlDbType.VarChar,100),
					new SqlParameter("@imgurl", SqlDbType.VarChar,100),
					new SqlParameter("@videourl", SqlDbType.VarChar,100),
					new SqlParameter("@adtext", SqlDbType.NVarChar,2000),
					new SqlParameter("@adcode", SqlDbType.VarChar,2000),
					new SqlParameter("@isopen", SqlDbType.Int,4),
					new SqlParameter("@adlinkman", SqlDbType.NVarChar,20),
					new SqlParameter("@adlinkphone", SqlDbType.NVarChar,20),
					new SqlParameter("@adlinkemail", SqlDbType.NVarChar,20),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@lasteditaid", SqlDbType.Int,4),
                new SqlParameter("@price", SqlDbType.VarChar,20),
                new SqlParameter("@starttime", SqlDbType.DateTime),
                new SqlParameter("@endtime", SqlDbType.DateTime),
                new SqlParameter("@sort", SqlDbType.Int),
                 new SqlParameter("@OrgPrice", SqlDbType.VarChar,20),
                 new SqlParameter("@ImgUrlFull", SqlDbType.VarChar,300)
                                            };
                parameters[0].Value = model.categoryid;
                parameters[1].Value = model.title;
                parameters[2].Value = model.linkurl;
                parameters[3].Value = model.flashurl;
                parameters[4].Value = model.imgurl;
                parameters[5].Value = model.videourl;
                parameters[6].Value = model.adtext;
                parameters[7].Value = model.adcode;
                parameters[8].Value = model.isopen;
                parameters[9].Value = model.adlinkman;
                parameters[10].Value = model.adlinkphone;
                parameters[11].Value = model.adlinkemail;
                parameters[12].Value = model.lastedittime;
                parameters[13].Value = model.lasteditaid;
                parameters[14].Value = model.Price;
                parameters[15].Value = model.StarTtime;
                parameters[16].Value = model.EndTime;
                parameters[17].Value = model.Sort;
                parameters[18].Value = model.OrgPrice;
                parameters[19].Value = model.ImgUrlFull;
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_advertising set ");
                strSql.Append("categoryid=@categoryid,");
                strSql.Append("title=@title,");
                strSql.Append("linkurl=@linkurl,");
                strSql.Append("flashurl=@flashurl,");
                strSql.Append("imgurl=@imgurl,");
                strSql.Append("videourl=@videourl,");
                strSql.Append("adtext=@adtext,");
                strSql.Append("adcode=@adcode,");
                strSql.Append("isopen=@isopen,");
                strSql.Append("adlinkman=@adlinkman,");
                strSql.Append("adlinkphone=@adlinkphone,");
                strSql.Append("adlinkemail=@adlinkemail,");
                strSql.Append("lastedittime=@lastedittime,");
                strSql.Append("lasteditaid=@lasteditaid,");
                strSql.Append("price=@price,");
                strSql.Append("starttime=@starttime,");
                strSql.Append("endtime=@endtime,");
                strSql.Append("orgprice=@orgprice,");
                strSql.Append("imgurlfull=@imgurlfull,");
                strSql.Append("sort=@sort");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@categoryid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@linkurl", SqlDbType.VarChar,100),
					new SqlParameter("@flashurl", SqlDbType.VarChar,100),
					new SqlParameter("@imgurl", SqlDbType.VarChar,100),
					new SqlParameter("@videourl", SqlDbType.VarChar,100),
					new SqlParameter("@adtext", SqlDbType.NVarChar,2000),
					new SqlParameter("@adcode", SqlDbType.VarChar,2000),
					new SqlParameter("@isopen", SqlDbType.Int,4),
					new SqlParameter("@adlinkman", SqlDbType.NVarChar,20),
					new SqlParameter("@adlinkphone", SqlDbType.NVarChar,20),
					new SqlParameter("@adlinkemail", SqlDbType.NVarChar,20),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@lasteditaid", SqlDbType.Int,4),
                    new SqlParameter("@price", SqlDbType.VarChar,20),
                    new SqlParameter("@starttime", SqlDbType.DateTime),
                    new SqlParameter("@endtime", SqlDbType.DateTime),
                    new SqlParameter("@sort", SqlDbType.Int),
                    new SqlParameter("@orgprice", SqlDbType.VarChar,20),
                    new SqlParameter("@imgurlfull", SqlDbType.VarChar,300),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.categoryid;
                parameters[1].Value = model.title;
                parameters[2].Value = model.linkurl;
                parameters[3].Value = model.flashurl;
                parameters[4].Value = model.imgurl;
                parameters[5].Value = model.videourl;
                parameters[6].Value = model.adtext;
                parameters[7].Value = model.adcode;
                parameters[8].Value = model.isopen;
                parameters[9].Value = model.adlinkman;
                parameters[10].Value = model.adlinkphone;
                parameters[11].Value = model.adlinkemail;
                parameters[12].Value = model.lastedittime;
                parameters[13].Value = model.lasteditaid;
                parameters[14].Value = model.Price;
                parameters[15].Value = model.StarTtime;
                parameters[16].Value = model.EndTime;
                parameters[17].Value = model.Sort;
                parameters[18].Value = model.OrgPrice;
                parameters[19].Value = model.ImgUrlFull;
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
        public static EnAdvertisement GetAdvertisementInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_advertising ");
            strSql.Append(strWhere);


            EnAdvertisement model = new EnAdvertisement();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["categoryid"] != null && reader["categoryid"].ToString() != "")
                {
                    model.categoryid = int.Parse(reader["categoryid"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["linkurl"] != null && reader["linkurl"].ToString() != "")
                {
                    model.linkurl = reader["linkurl"].ToString();
                }
                if (reader["flashurl"] != null && reader["flashurl"].ToString() != "")
                {
                    model.flashurl = reader["flashurl"].ToString();
                }
                if (reader["imgurl"] != null && reader["imgurl"].ToString() != "")
                {
                    model.imgurl = reader["imgurl"].ToString();
                }
                if (reader["videourl"] != null && reader["videourl"].ToString() != "")
                {
                    model.videourl = reader["videourl"].ToString();
                }
                if (reader["adtext"] != null && reader["adtext"].ToString() != "")
                {
                    model.adtext = reader["adtext"].ToString();
                }
                if (reader["adcode"] != null && reader["adcode"].ToString() != "")
                {
                    model.adcode = reader["adcode"].ToString();
                }
                if (reader["isopen"] != null && reader["isopen"].ToString() != "")
                {
                    model.isopen = int.Parse(reader["isopen"].ToString());
                }
                if (reader["adlinkman"] != null && reader["adlinkman"].ToString() != "")
                {
                    model.adlinkman = reader["adlinkman"].ToString();
                }
                if (reader["adlinkphone"] != null && reader["adlinkphone"].ToString() != "")
                {
                    model.adlinkphone = reader["adlinkphone"].ToString();
                }
                if (reader["adlinkemail"] != null && reader["adlinkemail"].ToString() != "")
                {
                    model.adlinkemail = reader["adlinkemail"].ToString();
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["lasteditaid"] != null && reader["lasteditaid"].ToString() != "")
                {
                    model.lasteditaid = int.Parse(reader["lasteditaid"].ToString());
                }
                if (reader["Price"] != null && reader["Price"].ToString() != "")
                {
                    model.Price = reader["Price"].ToString();
                }
                if (reader["StarTtime"] != null && reader["StarTtime"].ToString() != "")
                {
                    model.StarTtime = DateTime.Parse(reader["StarTtime"].ToString());
                }
                if (reader["EndTime"] != null && reader["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(reader["EndTime"].ToString());
                }
                if (reader["Sort"] != null && reader["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(reader["Sort"].ToString());
                }
                if (reader["OrgPrice"] != null && reader["OrgPrice"].ToString() != "")
                {
                    model.OrgPrice = reader["OrgPrice"].ToString();
                }
                if (reader["ImgUrlFull"] != null && reader["ImgUrlFull"].ToString() != "")
                {
                    model.ImgUrlFull = reader["ImgUrlFull"].ToString();
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
        public static List<EnAdvertisement> GetAdvertisementList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnAdvertisement> modelList = new List<EnAdvertisement>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBAdvertisement, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnAdvertisement model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnAdvertisement();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["categoryid"] != null && dt.Rows[n]["categoryid"].ToString() != "")
                    {
                        model.categoryid = int.Parse(dt.Rows[n]["categoryid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["linkurl"] != null && dt.Rows[n]["linkurl"].ToString() != "")
                    {
                        model.linkurl = dt.Rows[n]["linkurl"].ToString();
                    }
                    if (dt.Rows[n]["flashurl"] != null && dt.Rows[n]["flashurl"].ToString() != "")
                    {
                        model.flashurl = dt.Rows[n]["flashurl"].ToString();
                    }
                    if (dt.Rows[n]["imgurl"] != null && dt.Rows[n]["imgurl"].ToString() != "")
                    {
                        model.imgurl = dt.Rows[n]["imgurl"].ToString();
                    }
                    if (dt.Rows[n]["videourl"] != null && dt.Rows[n]["videourl"].ToString() != "")
                    {
                        model.videourl = dt.Rows[n]["videourl"].ToString();
                    }
                    if (dt.Rows[n]["adtext"] != null && dt.Rows[n]["adtext"].ToString() != "")
                    {
                        model.adtext = dt.Rows[n]["adtext"].ToString();
                    }
                    if (dt.Rows[n]["adcode"] != null && dt.Rows[n]["adcode"].ToString() != "")
                    {
                        model.adcode = dt.Rows[n]["adcode"].ToString();
                    }
                    if (dt.Rows[n]["isopen"] != null && dt.Rows[n]["isopen"].ToString() != "")
                    {
                        model.isopen = int.Parse(dt.Rows[n]["isopen"].ToString());
                    }
                    if (dt.Rows[n]["adlinkman"] != null && dt.Rows[n]["adlinkman"].ToString() != "")
                    {
                        model.adlinkman = dt.Rows[n]["adlinkman"].ToString();
                    }
                    if (dt.Rows[n]["adlinkphone"] != null && dt.Rows[n]["adlinkphone"].ToString() != "")
                    {
                        model.adlinkphone = dt.Rows[n]["adlinkphone"].ToString();
                    }
                    if (dt.Rows[n]["adlinkemail"] != null && dt.Rows[n]["adlinkemail"].ToString() != "")
                    {
                        model.adlinkemail = dt.Rows[n]["adlinkemail"].ToString();
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["lasteditaid"] != null && dt.Rows[n]["lasteditaid"].ToString() != "")
                    {
                        model.lasteditaid = int.Parse(dt.Rows[n]["lasteditaid"].ToString());
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = dt.Rows[n]["Price"].ToString();
                    }
                    if (dt.Rows[n]["StarTtime"] != null && dt.Rows[n]["StarTtime"].ToString() != "")
                    {
                        model.StarTtime = DateTime.Parse(dt.Rows[n]["StarTtime"].ToString());
                    }
                    if (dt.Rows[n]["EndTime"] != null && dt.Rows[n]["EndTime"].ToString() != "")
                    {
                        model.EndTime = DateTime.Parse(dt.Rows[n]["EndTime"].ToString());
                    }
                    if (dt.Rows[n]["ImgUrlFull"] != null && dt.Rows[n]["ImgUrlFull"].ToString() != "")
                    {
                        model.ImgUrlFull = dt.Rows[n]["ImgUrlFull"].ToString();
                    }
                    if (dt.Rows[n]["OrgPrice"] != null && dt.Rows[n]["OrgPrice"].ToString() != "")
                    {
                        model.OrgPrice = dt.Rows[n]["OrgPrice"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

        #region 共公广告分类

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAdvertisementCategory(EnAdvertisementCategory model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_advertisingcategory(");
                strSql.Append("parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort)");
                strSql.Append(" values (");
                strSql.Append("@parentid,@moduleid,@modulevalue,@title,@img,@height,@width,@isopen,@adtype,@starttime,@endtime,@descript,@template,@sort)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@moduleid", SqlDbType.Int,4),
					new SqlParameter("@modulevalue", SqlDbType.NVarChar,50),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@img", SqlDbType.VarChar,50),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@isopen", SqlDbType.Int,4),
					new SqlParameter("@adtype", SqlDbType.Int,4),
					new SqlParameter("@starttime", SqlDbType.DateTime),
					new SqlParameter("@endtime", SqlDbType.DateTime),
					new SqlParameter("@descript", SqlDbType.NChar,10),
					new SqlParameter("@template", SqlDbType.NVarChar,2000),
					new SqlParameter("@sort", SqlDbType.Int,4)};
                parameters[0].Value = model.parentid;
                parameters[1].Value = model.moduleid;
                parameters[2].Value = model.modulevalue;
                parameters[3].Value = model.title;
                parameters[4].Value = model.img;
                parameters[5].Value = model.height;
                parameters[6].Value = model.width;
                parameters[7].Value = model.isopen;
                parameters[8].Value = model.adtype;
                parameters[9].Value = model.starttime;
                parameters[10].Value = model.endtime;
                parameters[11].Value = model.descript;
                parameters[12].Value = model.template;
                parameters[13].Value = model.sort;

                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_advertisingcategory set ");
                strSql.Append("parentid=@parentid,");
                strSql.Append("moduleid=@moduleid,");
                strSql.Append("modulevalue=@modulevalue,");
                strSql.Append("title=@title,");
                strSql.Append("img=@img,");
                strSql.Append("height=@height,");
                strSql.Append("width=@width,");
                strSql.Append("isopen=@isopen,");
                strSql.Append("adtype=@adtype,");
                strSql.Append("starttime=@starttime,");
                strSql.Append("endtime=@endtime,");
                strSql.Append("descript=@descript,");
                strSql.Append("template=@template,");
                strSql.Append("sort=@sort");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@moduleid", SqlDbType.Int,4),
					new SqlParameter("@modulevalue", SqlDbType.NVarChar,50),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@img", SqlDbType.VarChar,50),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@isopen", SqlDbType.Int,4),
					new SqlParameter("@adtype", SqlDbType.Int,4),
					new SqlParameter("@starttime", SqlDbType.DateTime),
					new SqlParameter("@endtime", SqlDbType.DateTime),
					new SqlParameter("@descript", SqlDbType.NChar,10),
					new SqlParameter("@template", SqlDbType.NVarChar,2000),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.parentid;
                parameters[1].Value = model.moduleid;
                parameters[2].Value = model.modulevalue;
                parameters[3].Value = model.title;
                parameters[4].Value = model.img;
                parameters[5].Value = model.height;
                parameters[6].Value = model.width;
                parameters[7].Value = model.isopen;
                parameters[8].Value = model.adtype;
                parameters[9].Value = model.starttime;
                parameters[10].Value = model.endtime;
                parameters[11].Value = model.descript;
                parameters[12].Value = model.template;
                parameters[13].Value = model.sort;
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
        public static EnAdvertisementCategory GetAdvertisementCategoryInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_advertisingcategory ");
            strSql.Append(strWhere);


            EnAdvertisementCategory model = new EnAdvertisementCategory();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["parentid"] != null && reader["parentid"].ToString() != "")
                {
                    model.parentid = int.Parse(reader["parentid"].ToString());
                }
                if (reader["moduleid"] != null && reader["moduleid"].ToString() != "")
                {
                    model.moduleid = int.Parse(reader["moduleid"].ToString());
                }
                if (reader["modulevalue"] != null && reader["modulevalue"].ToString() != "")
                {
                    model.modulevalue = reader["modulevalue"].ToString();
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["img"] != null && reader["img"].ToString() != "")
                {
                    model.img = reader["img"].ToString();
                }
                if (reader["height"] != null && reader["height"].ToString() != "")
                {
                    model.height = int.Parse(reader["height"].ToString());
                }
                if (reader["width"] != null && reader["width"].ToString() != "")
                {
                    model.width = int.Parse(reader["width"].ToString());
                }
                if (reader["isopen"] != null && reader["isopen"].ToString() != "")
                {
                    model.isopen = int.Parse(reader["isopen"].ToString());
                }
                if (reader["adtype"] != null && reader["adtype"].ToString() != "")
                {
                    model.adtype = int.Parse(reader["adtype"].ToString());
                }
                if (reader["starttime"] != null && reader["starttime"].ToString() != "")
                {
                    model.starttime = DateTime.Parse(reader["starttime"].ToString());
                }
                if (reader["endtime"] != null && reader["endtime"].ToString() != "")
                {
                    model.endtime = DateTime.Parse(reader["endtime"].ToString());
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["template"] != null && reader["template"].ToString() != "")
                {
                    model.template = reader["template"].ToString();
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
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
        public static List<EnAdvertisementCategory> GetAdvertisementCategoryList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnAdvertisementCategory> modelList = new List<EnAdvertisementCategory>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBAdvertisementCategory, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            DataView dv = dt.DefaultView;
            dv.Sort = "sort,id  desc";
            dt = dv.ToTable();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Select(" parentid=0"))
                {
                    EnAdvertisementCategory model = new EnAdvertisementCategory();
                    if (dr["id"] != null && dr["id"].ToString() != "")
                    {
                        model.id = int.Parse(dr["id"].ToString());
                    }
                    if (dr["parentid"] != null && dr["parentid"].ToString() != "")
                    {
                        model.parentid = int.Parse(dr["parentid"].ToString());
                    }
                    if (dr["moduleid"] != null && dr["moduleid"].ToString() != "")
                    {
                        model.moduleid = int.Parse(dr["moduleid"].ToString());
                    }
                    if (dr["modulevalue"] != null && dr["modulevalue"].ToString() != "")
                    {
                        model.modulevalue = dr["modulevalue"].ToString();
                    }
                    if (dr["title"] != null && dr["title"].ToString() != "")
                    {
                        model.title = dr["title"].ToString();
                    }
                    if (dr["img"] != null && dr["img"].ToString() != "")
                    {
                        model.img = dr["img"].ToString();
                    }
                    if (dr["height"] != null && dr["height"].ToString() != "")
                    {
                        model.height = int.Parse(dr["height"].ToString());
                    }
                    if (dr["width"] != null && dr["width"].ToString() != "")
                    {
                        model.width = int.Parse(dr["width"].ToString());
                    }
                    if (dr["isopen"] != null && dr["isopen"].ToString() != "")
                    {
                        model.isopen = int.Parse(dr["isopen"].ToString());
                    }
                    if (dr["adtype"] != null && dr["adtype"].ToString() != "")
                    {
                        model.adtype = int.Parse(dr["adtype"].ToString());
                    }
                    if (dr["starttime"] != null && dr["starttime"].ToString() != "")
                    {
                        model.starttime = DateTime.Parse(dr["starttime"].ToString());
                    }
                    if (dr["endtime"] != null && dr["endtime"].ToString() != "")
                    {
                        model.endtime = DateTime.Parse(dr["endtime"].ToString());
                    }
                    if (dr["descript"] != null && dr["descript"].ToString() != "")
                    {
                        model.descript = dr["descript"].ToString();
                    }
                    if (dr["template"] != null && dr["template"].ToString() != "")
                    {
                        model.template = dr["template"].ToString();
                    }
                    if (dr["sort"] != null && dr["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dr["sort"].ToString());
                    }
                    modelList.Add(model);

                    foreach (DataRow drSub in dt.Select(" parentid=" + model.id))
                    {
                        EnAdvertisementCategory modelSub = new EnAdvertisementCategory();
                        if (drSub["id"] != null && drSub["id"].ToString() != "")
                        {
                            modelSub.id = int.Parse(drSub["id"].ToString());
                        }
                        if (drSub["parentid"] != null && drSub["parentid"].ToString() != "")
                        {
                            modelSub.parentid = int.Parse(drSub["parentid"].ToString());
                        }
                        if (drSub["moduleid"] != null && drSub["moduleid"].ToString() != "")
                        {
                            modelSub.moduleid = int.Parse(drSub["moduleid"].ToString());
                        }
                        if (drSub["modulevalue"] != null && drSub["modulevalue"].ToString() != "")
                        {
                            modelSub.modulevalue = drSub["modulevalue"].ToString();
                        }
                        if (drSub["title"] != null && drSub["title"].ToString() != "")
                        {
                            modelSub.title = drSub["title"].ToString();
                        }
                        if (drSub["img"] != null && drSub["img"].ToString() != "")
                        {
                            modelSub.img = drSub["img"].ToString();
                        }
                        if (drSub["height"] != null && drSub["height"].ToString() != "")
                        {
                            modelSub.height = int.Parse(drSub["height"].ToString());
                        }
                        if (drSub["width"] != null && drSub["width"].ToString() != "")
                        {
                            modelSub.width = int.Parse(drSub["width"].ToString());
                        }
                        if (drSub["isopen"] != null && drSub["isopen"].ToString() != "")
                        {
                            modelSub.isopen = int.Parse(drSub["isopen"].ToString());
                        }
                        if (drSub["adtype"] != null && drSub["adtype"].ToString() != "")
                        {
                            modelSub.adtype = int.Parse(drSub["adtype"].ToString());
                        }
                        if (drSub["starttime"] != null && drSub["starttime"].ToString() != "")
                        {
                            modelSub.starttime = DateTime.Parse(drSub["starttime"].ToString());
                        }
                        if (drSub["endtime"] != null && drSub["endtime"].ToString() != "")
                        {
                            modelSub.endtime = DateTime.Parse(drSub["endtime"].ToString());
                        }
                        if (drSub["descript"] != null && drSub["descript"].ToString() != "")
                        {
                            modelSub.descript = drSub["descript"].ToString();
                        }
                        if (drSub["template"] != null && drSub["template"].ToString() != "")
                        {
                            modelSub.template = drSub["template"].ToString();
                        }
                        if (drSub["sort"] != null && drSub["sort"].ToString() != "")
                        {
                            modelSub.sort = int.Parse(drSub["sort"].ToString());
                        }
                        modelList.Add(modelSub);
                    }


                }
            }
            return modelList;
        }


        #endregion

        /// <summary>
        /// 获取广告列表
        /// 2015-01-29 shen
        /// </summary>
        /// <returns></returns>
        public static List<t_advertising> AdvertisingList(string strWhere)
        {
            string sql = @"exec proc_advertising @str='" + strWhere + "' ";


            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sql).Tables[0];

            List<t_advertising> list = new List<t_advertising>();

            t_advertising info;

            foreach (DataRow row in dt.Rows)
            {
                info = new t_advertising();
                t_advertising.FillData(row, out info);
                list.Add(info);
            }
            return list;
        }
        /// <summary>
        /// 导航条推荐品牌
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static List<t_navigationbrand> t_navigationbrandList()
        {
            string sql = @"exec proc_navbrand ";


            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sql).Tables[0];

            List<t_navigationbrand> list = new List<t_navigationbrand>();

            t_navigationbrand info;

            foreach (DataRow row in dt.Rows)
            {
                info = new t_navigationbrand();
                t_navigationbrand.FillData(row, out info);
                list.Add(info);
            }
            return list;
        }


        /// <summary>
        /// 获取商家活动信息
        /// shen 2015-02-04
        /// </summary>
        /// <param name="pageindex">当前页数</param>
        /// <param name="pagecount">总页数</param>
        /// <param name="pagesize">每页显示数量</param>
        /// <param name="marketid">商场id</param>
        /// <param name="brandid">品牌id</param>
        /// <param name="areaid">区域id</param>
        /// <param name="keyword">搜索关键词</param>
        /// <param name="type">活动发起方 (卖场,工厂,店铺)</param>
        /// <param name="sorttype">排序方式(asc desc)</param>
        /// <param name="sort">排序类型</param>
        public static DataTable HDSearch(int pageindex, int pagecount, int pagesize, int marketid, int brandid, string areaid,
            string keyword, int type, string sorttype, string sort)
        {

            string strsql = "";

            if (string.IsNullOrEmpty(sorttype))
            {
                sorttype = "desc";
            }
            strsql = @"exec proc_HDSelect " +
                      " @pageindex = " + pageindex.ToString() +
                      ",@pagecount = " + pagecount.ToString() +
                      ",@pagesize =" + pagesize.ToString() +
                      ",@marketid =" + marketid.ToString() +
                      ",@brandid =" + brandid.ToString() +
                      ",@areaid ='" + areaid + "' " +
                      ",@keyword = '" + keyword + "' " +
                      ",@type= " + type.ToString() +
                      ",@sorttype='" + sorttype + "'" +
                      ",@sort='" + sort + "'";

            DataTable dt = new DataTable();
            try
            {
                dt = DbHelper.ExecuteDataset(CommandType.Text, strsql).Tables[0];
            }
            catch (Exception err)
            {

            }

            return dt;

        }

        public static DataSet HDSearch(int pageindex, int pagesize, string condiction, string order)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@pageIndex", SqlDbType.Int),
					new SqlParameter("@pagesize", SqlDbType.Int),
					new SqlParameter("@condiction", SqlDbType.VarChar,1000),
                    new SqlParameter("@table", SqlDbType.VarChar,100),
                    new SqlParameter("@orderby", SqlDbType.VarChar,100)
                                         };

            parameters[0].Value = pageindex;
            parameters[1].Value = pagesize;
            parameters[2].Value = condiction;
            parameters[3].Value = "v_promotions";
            parameters[4].Value = order;
            //string sql = "EXEC sp_TablePage_orderby "",10,'','v_promotions',' etime desc'";

            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_TablePage_orderby", parameters);
        }

        /// <summary>
        /// 首页淘宝贝
        /// shen 2015-02-06
        /// </summary>
        /// <returns></returns>
        public static DataSet TBBSearch(int did,int xid)
        {
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, "exec proc_tbbinfo @did = "+did+" ,@xid = " +xid);
            return ds;

        }
    }
}
