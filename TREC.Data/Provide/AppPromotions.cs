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
    public class AppPromotions
    {
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditPromotionAppBrand(EnPromotionAppBrand model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_promotionappbrand(");
                strSql.Append("title,letter,bid,blogo,fordio,thumb,banner,htmltitle,descript,appcount,sort,IsRecommend,discount,period,style,stylevalue,percount,BrandABC,Template,RulesInfo,Starttime,Endtime)");
                strSql.Append(" values (");
                strSql.Append("@title,@letter,@bid,@blogo,@fordio,@thumb,@banner,@htmltitle,@descript,@appcount,@sort,@IsRecommend,@discount,@period,@style,@stylevalue,@percount,@BrandABC,@Template,@RulesInfo,@Starttime,@Endtime)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@letter", SqlDbType.VarChar,50),
					new SqlParameter("@bid", SqlDbType.Int,4),
					new SqlParameter("@blogo", SqlDbType.VarChar,50),
					new SqlParameter("@fordio", SqlDbType.VarChar,10),
					new SqlParameter("@thumb", SqlDbType.VarChar,50),
					new SqlParameter("@banner", SqlDbType.VarChar,240),
					new SqlParameter("@htmltitle", SqlDbType.NVarChar,80),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@appcount", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
                    new SqlParameter("@IsRecommend", SqlDbType.Bit),
                    new SqlParameter("@discount", SqlDbType.Int,4),
                    new SqlParameter("@period", SqlDbType.Int,4),
                    new SqlParameter("@style", SqlDbType.Int,4),
                    new SqlParameter("@stylevalue", SqlDbType.VarChar,50),
                    new SqlParameter("@percount", SqlDbType.Int,4),
                    new SqlParameter("@BrandABC", SqlDbType.VarChar,50),
                    new SqlParameter("@Template", SqlDbType.NText),
                    new SqlParameter("@RulesInfo", SqlDbType.NText),
                    new SqlParameter("@Starttime", SqlDbType.DateTime),
                    new SqlParameter("@Endtime", SqlDbType.DateTime)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.letter;
                parameters[2].Value = model.bid;
                parameters[3].Value = model.blogo;
                parameters[4].Value = model.fordio;
                parameters[5].Value = model.thumb;
                parameters[6].Value = model.banner;
                parameters[7].Value = model.htmltitle;
                parameters[8].Value = model.descript;
                parameters[9].Value = model.appcount;
                parameters[10].Value = model.sort;

                parameters[11].Value = model.IsRecommend;
                parameters[12].Value = model.Discount;
                parameters[13].Value = model.Period;
                parameters[14].Value = model.Style;
                parameters[15].Value = model.Stylevalue;
                parameters[16].Value = model.Percount;
                parameters[17].Value = model.BrandABC;
                parameters[18].Value = model.Template;
                parameters[19].Value = model.RulesInfo;
                parameters[20].Value = model.Starttime;
                parameters[21].Value = model.Endtime;
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_promotionappbrand set ");
                strSql.Append("title=@title,");
                strSql.Append("letter=@letter,");
                strSql.Append("bid=@bid,");
                strSql.Append("blogo=@blogo,");
                strSql.Append("fordio=@fordio,");
                strSql.Append("thumb=@thumb,");
                strSql.Append("banner=@banner,");
                strSql.Append("htmltitle=@htmltitle,");
                strSql.Append("descript=@descript,");
                strSql.Append("appcount=@appcount,");
                strSql.Append("sort=@sort,IsRecommend=@IsRecommend, discount=@discount, period=@period, style=@style, stylevalue=@stylevalue,percount=@percount,BrandABC=@BrandABC,Template=@Template,RulesInfo=@RulesInfo,");
                strSql.Append("Starttime=@Starttime,Endtime=@Endtime");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@letter", SqlDbType.VarChar,50),
					new SqlParameter("@bid", SqlDbType.Int,4),
					new SqlParameter("@blogo", SqlDbType.VarChar,50),
					new SqlParameter("@fordio", SqlDbType.VarChar,10),
					new SqlParameter("@thumb", SqlDbType.VarChar,50),
					new SqlParameter("@banner", SqlDbType.VarChar,240),
					new SqlParameter("@htmltitle", SqlDbType.NVarChar,80),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@appcount", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@IsRecommend", SqlDbType.Bit),
                    new SqlParameter("@discount", SqlDbType.Int,4),
                    new SqlParameter("@period", SqlDbType.Int,4),
                    new SqlParameter("@style", SqlDbType.Int,4),
                    new SqlParameter("@stylevalue", SqlDbType.VarChar,50),
                    new SqlParameter("@percount", SqlDbType.Int,4),
                    new SqlParameter("@BrandABC", SqlDbType.VarChar,50),
                    new SqlParameter("@Template", SqlDbType.NText),
                    new SqlParameter("@RulesInfo", SqlDbType.NText),
                    new SqlParameter("@Starttime", SqlDbType.DateTime),
                    new SqlParameter("@Endtime", SqlDbType.DateTime)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.letter;
                parameters[2].Value = model.bid;
                parameters[3].Value = model.blogo;
                parameters[4].Value = model.fordio;
                parameters[5].Value = model.thumb;
                parameters[6].Value = model.banner;
                parameters[7].Value = model.htmltitle;
                parameters[8].Value = model.descript;
                parameters[9].Value = model.appcount;
                parameters[10].Value = model.sort;
                parameters[11].Value = model.id;
                parameters[12].Value = model.IsRecommend;
                parameters[13].Value = model.Discount;
                parameters[14].Value = model.Period;
                parameters[15].Value = model.Style;
                parameters[16].Value = model.Stylevalue;
                parameters[17].Value = model.Percount;
                parameters[18].Value = model.BrandABC;
                parameters[19].Value = model.Template;
                parameters[20].Value = model.RulesInfo;
                parameters[21].Value = model.Starttime;
                parameters[22].Value = model.Endtime;
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
        public static EnPromotionAppBrand GetPromotionAppBrandInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_PromotionAppBrand ");
            strSql.Append(strWhere);


            EnPromotionAppBrand model = new EnPromotionAppBrand();
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
                if (reader["bid"] != null && reader["bid"].ToString() != "")
                {
                    model.bid = int.Parse(reader["bid"].ToString());
                }
                if (reader["blogo"] != null && reader["blogo"].ToString() != "")
                {
                    model.blogo = reader["blogo"].ToString();
                }
                if (reader["fordio"] != null && reader["fordio"].ToString() != "")
                {
                    model.fordio = reader["fordio"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["banner"] != null && reader["banner"].ToString() != "")
                {
                    model.banner = reader["banner"].ToString();
                }
                if (reader["htmltitle"] != null && reader["htmltitle"].ToString() != "")
                {
                    model.htmltitle = reader["htmltitle"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["appcount"] != null && reader["appcount"].ToString() != "")
                {
                    model.appcount = int.Parse(reader["appcount"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["discount"] != null && reader["discount"].ToString() != "")
                {
                    model.Discount = int.Parse(reader["discount"].ToString());
                }
                if (reader["IsRecommend"] != null && reader["IsRecommend"].ToString() != "")
                {
                    model.IsRecommend = bool.Parse(reader["IsRecommend"].ToString());
                }
                if (reader["period"] != null && reader["period"].ToString() != "")
                {
                    model.Period = int.Parse(reader["period"].ToString());
                }
                if (reader["style"] != null && reader["Style"].ToString() != "")
                {
                    model.Style = int.Parse(reader["Style"].ToString());
                }
                if (reader["stylevalue"] != null && reader["Stylevalue"].ToString() != "")
                {
                    model.Stylevalue = reader["Stylevalue"].ToString();
                }
                if (reader["percount"] != null && reader["percount"].ToString() != "")
                {
                    model.Percount = int.Parse(reader["percount"].ToString());
                }
                if (reader["brandABC"] != null && reader["brandABC"].ToString() != "")
                {
                    model.BrandABC = reader["brandABC"].ToString();
                }
                if (reader["Template"] != null && reader["Template"].ToString() != "")
                {
                    model.Template = reader["Template"].ToString();
                }
                if (reader["RulesInfo"] != null && reader["RulesInfo"].ToString() != "")
                {
                    model.RulesInfo = reader["RulesInfo"].ToString();
                }
                if (reader["Starttime"] != null && reader["Starttime"].ToString() != "")
                {
                    model.Starttime = DateTime.Parse(reader["Starttime"].ToString());
                }
                if (reader["Endtime"] != null && reader["Endtime"].ToString() != "")
                {
                    model.Endtime = DateTime.Parse(reader["Endtime"].ToString());
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
        public static List<EnPromotionAppBrand> GetPromotionAppBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return GetPromotionAppBrandList(PageIndex, PageSize, strWhere, "", out  pageCount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnPromotionAppBrand> GetPromotionAppBrandList(int PageIndex, int PageSize, string strWhere, string orderby, out int pageCount)
        {
            List<EnPromotionAppBrand> modelList = new List<EnPromotionAppBrand>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBPromotionAppBrand, PageIndex, PageSize, strWhere, orderby, 0, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnPromotionAppBrand model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnPromotionAppBrand();
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
                    if (dt.Rows[n]["bid"] != null && dt.Rows[n]["bid"].ToString() != "")
                    {
                        model.bid = int.Parse(dt.Rows[n]["bid"].ToString());
                    }
                    if (dt.Rows[n]["blogo"] != null && dt.Rows[n]["blogo"].ToString() != "")
                    {
                        model.blogo = dt.Rows[n]["blogo"].ToString();
                    }
                    if (dt.Rows[n]["fordio"] != null && dt.Rows[n]["fordio"].ToString() != "")
                    {
                        model.fordio = dt.Rows[n]["fordio"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["banner"] != null && dt.Rows[n]["banner"].ToString() != "")
                    {
                        model.banner = dt.Rows[n]["banner"].ToString();
                    }
                    if (dt.Rows[n]["htmltitle"] != null && dt.Rows[n]["htmltitle"].ToString() != "")
                    {
                        model.htmltitle = dt.Rows[n]["htmltitle"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["appcount"] != null && dt.Rows[n]["appcount"].ToString() != "")
                    {
                        model.appcount = int.Parse(dt.Rows[n]["appcount"].ToString());
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["discount"] != null && dt.Rows[n]["discount"].ToString() != "")
                    {
                        model.Discount = int.Parse(dt.Rows[n]["discount"].ToString());
                    }
                    if (dt.Rows[n]["IsRecommend"] != null && dt.Rows[n]["IsRecommend"].ToString() != "")
                    {
                        model.IsRecommend = bool.Parse(dt.Rows[n]["IsRecommend"].ToString());
                    }
                    if (dt.Rows[n]["period"] != null && dt.Rows[n]["period"].ToString() != "")
                    {
                        model.Period = int.Parse(dt.Rows[n]["period"].ToString());
                    }
                    if (dt.Rows[n]["style"] != null && dt.Rows[n]["Style"].ToString() != "")
                    {
                        model.Style = int.Parse(dt.Rows[n]["Style"].ToString());
                    }
                    if (dt.Rows[n]["stylevalue"] != null && dt.Rows[n]["Stylevalue"].ToString() != "")
                    {
                        model.Stylevalue = dt.Rows[n]["Stylevalue"].ToString();
                    }
                    if (dt.Rows[n]["percount"] != null && dt.Rows[n]["percount"].ToString() != "")
                    {
                        model.Percount = int.Parse(dt.Rows[n]["percount"].ToString());
                    }
                    if (dt.Rows[n]["brandABC"] != null && dt.Rows[n]["brandABC"].ToString() != "")
                    {
                        model.BrandABC = dt.Rows[n]["brandABC"].ToString();
                    }
                    if (dt.Rows[n]["Template"] != null && dt.Rows[n]["Template"].ToString() != "")
                    {
                        model.Template = dt.Rows[n]["Template"].ToString();
                    }
                    if (dt.Rows[n]["RulesInfo"] != null && dt.Rows[n]["RulesInfo"].ToString() != "")
                    {
                        model.RulesInfo = dt.Rows[n]["RulesInfo"].ToString();
                    }
                    if (dt.Rows[n]["Starttime"] != null && dt.Rows[n]["Starttime"].ToString() != "")
                    {
                        model.Starttime = DateTime.Parse(dt.Rows[n]["Starttime"].ToString());
                    }
                    if (dt.Rows[n]["Endtime"] != null && dt.Rows[n]["Endtime"].ToString() != "")
                    {
                        model.Endtime = DateTime.Parse(dt.Rows[n]["Endtime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAppBrandCustomer(EnAppBrandCustomer model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_appbrandcustomer(");
                strSql.Append("aid,name,phone,mphone,email,address,descript,cus,sex,citycode,productJson)");
                strSql.Append(" values (");
                strSql.Append("@aid,@name,@phone,@mphone,@email,@address,@descript,@cus,@sex,@citycode,@productJson)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@aid", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@phone", SqlDbType.VarChar,20),
					new SqlParameter("@mphone", SqlDbType.VarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,50),
					new SqlParameter("@descript", SqlDbType.NVarChar,600),
					new SqlParameter("@cus", SqlDbType.NText),
					new SqlParameter("@sex", SqlDbType.Int,4),
					new SqlParameter("@citycode", SqlDbType.NVarChar,20),
					new SqlParameter("@productJson", SqlDbType.NText)};
                parameters[0].Value = model.aid;
                parameters[1].Value = model.name;
                parameters[2].Value = model.phone;
                parameters[3].Value = model.mphone;
                parameters[4].Value = model.email;
                parameters[5].Value = model.address;
                parameters[6].Value = model.descript;
                parameters[7].Value = model.cus;
                parameters[8].Value = model.Sex;
                parameters[9].Value = model.Citycode;
                parameters[10].Value = model.ProductJson;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_appbrandcustomer set ");
                strSql.Append("aid=@aid,");
                strSql.Append("name=@name,");
                strSql.Append("phone=@phone,");
                strSql.Append("mphone=@mphone,");
                strSql.Append("email=@email,");
                strSql.Append("address=@address,");
                strSql.Append("descript=@descript,");
                strSql.Append("cus=@cus,");
                strSql.Append("sex=@sex,citycode=@citycode,productJson=@productJson");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@aid", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@phone", SqlDbType.VarChar,20),
					new SqlParameter("@mphone", SqlDbType.VarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,50),
					new SqlParameter("@descript", SqlDbType.NVarChar,600),
					new SqlParameter("@cus", SqlDbType.NText),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@sex", SqlDbType.Int,4),
					new SqlParameter("@citycode", SqlDbType.NVarChar,20),
					new SqlParameter("@productJson", SqlDbType.NText)};
                parameters[0].Value = model.aid;
                parameters[1].Value = model.name;
                parameters[2].Value = model.phone;
                parameters[3].Value = model.mphone;
                parameters[4].Value = model.email;
                parameters[5].Value = model.address;
                parameters[6].Value = model.descript;
                parameters[7].Value = model.cus;
                parameters[8].Value = model.id;
                parameters[9].Value = model.Sex;
                parameters[10].Value = model.Citycode;
                parameters[11].Value = model.ProductJson;

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
        public static EnAppBrandCustomer GetAppBrandCustomerInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_AppBrandCustomer ");
            strSql.Append(strWhere);


            EnAppBrandCustomer model = new EnAppBrandCustomer();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["aid"] != null && reader["aid"].ToString() != "")
                {
                    model.aid = int.Parse(reader["aid"].ToString());
                }
                if (reader["name"] != null && reader["name"].ToString() != "")
                {
                    model.name = reader["name"].ToString();
                }
                if (reader["phone"] != null && reader["phone"].ToString() != "")
                {
                    model.phone = reader["phone"].ToString();
                }
                if (reader["mphone"] != null && reader["mphone"].ToString() != "")
                {
                    model.mphone = reader["mphone"].ToString();
                }
                if (reader["email"] != null && reader["email"].ToString() != "")
                {
                    model.email = reader["email"].ToString();
                }
                if (reader["address"] != null && reader["address"].ToString() != "")
                {
                    model.address = reader["address"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["cus"] != null && reader["cus"].ToString() != "")
                {
                    model.cus = reader["cus"].ToString();
                }
                if (reader["sex"] != null && reader["sex"].ToString() != "")
                {
                    model.Sex =int.Parse(reader["sex"].ToString());
                }
                if (reader["citycode"] != null && reader["citycode"].ToString() != "")
                {
                    model.Citycode = reader["citycode"].ToString();
                }
                if (reader["productJson"] != null && reader["productJson"].ToString() != "")
                {
                    model.ProductJson = reader["productJson"].ToString();
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
        public static List<EnAppBrandCustomer> GetAppBrandCustomerList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnAppBrandCustomer> modelList = new List<EnAppBrandCustomer>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBAppBrandCustomer, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnAppBrandCustomer model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnAppBrandCustomer();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["aid"] != null && dt.Rows[n]["aid"].ToString() != "")
                    {
                        model.aid = int.Parse(dt.Rows[n]["aid"].ToString());
                    }
                    if (dt.Rows[n]["name"] != null && dt.Rows[n]["name"].ToString() != "")
                    {
                        model.name = dt.Rows[n]["name"].ToString();
                    }
                    if (dt.Rows[n]["phone"] != null && dt.Rows[n]["phone"].ToString() != "")
                    {
                        model.phone = dt.Rows[n]["phone"].ToString();
                    }
                    if (dt.Rows[n]["mphone"] != null && dt.Rows[n]["mphone"].ToString() != "")
                    {
                        model.mphone = dt.Rows[n]["mphone"].ToString();
                    }
                    if (dt.Rows[n]["email"] != null && dt.Rows[n]["email"].ToString() != "")
                    {
                        model.email = dt.Rows[n]["email"].ToString();
                    }
                    if (dt.Rows[n]["address"] != null && dt.Rows[n]["address"].ToString() != "")
                    {
                        model.address = dt.Rows[n]["address"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["cus"] != null && dt.Rows[n]["cus"].ToString() != "")
                    {
                        model.cus = dt.Rows[n]["cus"].ToString();
                    }
                    if (dt.Rows[n]["CreateTime"] != null && dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["sex"] != null && dt.Rows[n]["sex"].ToString() != "")
                    {
                        model.Sex = int.Parse(dt.Rows[n]["sex"].ToString());
                    }
                    if (dt.Rows[n]["citycode"] != null && dt.Rows[n]["citycode"].ToString() != "")
                    {
                        model.Citycode = dt.Rows[n]["citycode"].ToString();
                    }
                    if (dt.Rows[n]["productJson"] != null && dt.Rows[n]["productJson"].ToString() != "")
                    {
                        model.ProductJson = dt.Rows[n]["productJson"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        public static List<EnAppProduct> GetAppBrandProductList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnAppProduct> modelList = new List<EnAppProduct>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBAppBrandProduct, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnAppProduct model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnAppProduct();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["mid"] != null && dt.Rows[n]["mid"].ToString() != "")
                    {
                        model.mid = int.Parse(dt.Rows[n]["mid"].ToString());
                    }
                    if (dt.Rows[n]["name"] != null && dt.Rows[n]["name"].ToString() != "")
                    {
                        model.name = dt.Rows[n]["name"].ToString();
                    }
                    if (dt.Rows[n]["memail"] != null && dt.Rows[n]["memail"].ToString() != "")
                    {
                        model.memail = dt.Rows[n]["memail"].ToString();
                    }
                    if (dt.Rows[n]["mphone"] != null && dt.Rows[n]["mphone"].ToString() != "")
                    {
                        model.mphone = dt.Rows[n]["mphone"].ToString();
                    }
                    if (dt.Rows[n]["productid"] != null && dt.Rows[n]["productid"].ToString() != "")
                    {
                        model.productid = int.Parse(dt.Rows[n]["productid"].ToString());
                    }
                    if (dt.Rows[n]["productname"] != null && dt.Rows[n]["productname"].ToString() != "")
                    {
                        model.productname = dt.Rows[n]["productname"].ToString();
                    }
                    if (dt.Rows[n]["materialid"] != null && dt.Rows[n]["materialid"].ToString() != "")
                    {
                        model.materialid = int.Parse(dt.Rows[n]["materialid"].ToString());
                    }
                    if (dt.Rows[n]["materialname"] != null && dt.Rows[n]["materialname"].ToString() != "")
                    {
                        model.materialname = dt.Rows[n]["materialname"].ToString();
                    }
                    if (dt.Rows[n]["sizevalue"] != null && dt.Rows[n]["sizevalue"].ToString() != "")
                    {
                        model.sizevalue = dt.Rows[n]["sizevalue"].ToString();
                    }
                    if (dt.Rows[n]["brandid"] != null && dt.Rows[n]["brandid"].ToString() != "")
                    {
                        model.brandid = int.Parse(dt.Rows[n]["brandid"].ToString());
                    }
                    if (dt.Rows[n]["brandname"] != null && dt.Rows[n]["brandname"].ToString() != "")
                    {
                        model.brandname = dt.Rows[n]["brandname"].ToString();
                    }
                    if (dt.Rows[n]["addtime"] != null && dt.Rows[n]["addtime"].ToString() != "")
                    {
                        model.addtime = DateTime.Parse(dt.Rows[n]["addtime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

    }
}
