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
    public class Promotions
    {


        //活动信息
        public static List<EnWebPromotion> GetWebPromotionList(int PageIndex, int PageSize, string strWhere, string sortkey, string orderby, out int pageCount)
        {
            List<EnWebPromotion> list = new List<EnWebPromotion>();
            IDataReader reader = DataCommon.GetPageDataReader(TableName.TVPromotion, PageIndex, PageSize, strWhere, sortkey, orderby, out pageCount);
            while (reader.Read())
            {
                EnWebPromotion model = new EnWebPromotion();
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["htmltitle"] != null && reader["htmltitle"].ToString() != "")
                {
                    model.htmltitle = reader["htmltitle"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["ptype"] != null && reader["ptype"].ToString() != "")
                {
                    model.ptype = int.Parse(reader["ptype"].ToString());
                }
                if (reader["startdatetime"] != null && reader["startdatetime"].ToString() != "")
                {
                    model.startdatetime = DateTime.Parse(reader["startdatetime"].ToString());
                }
                if (reader["enddatetime"] != null && reader["enddatetime"].ToString() != "")
                {
                    model.enddatetime = DateTime.Parse(reader["enddatetime"].ToString());
                }
                if (reader["areacode"] != null && reader["areacode"].ToString() != "")
                {
                    model.areacode = reader["areacode"].ToString();
                }
                if (reader["address"] != null && reader["address"].ToString() != "")
                {
                    model.address = reader["address"].ToString();
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
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
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
                //if (reader["pid"] != null && reader["pid"].ToString() != "")
                //{
                //    model.pid = int.Parse(reader["pid"].ToString());
                //}
                //if (reader["companyidlist"] != null && reader["companyidlist"].ToString() != "")
                //{
                //    model.companyidlist = reader["companyidlist"].ToString();
                //}
                //if (reader["dealeridlist"] != null && reader["dealeridlist"].ToString() != "")
                //{
                //    model.dealeridlist = reader["dealeridlist"].ToString();
                //}
                //if (reader["shopidlist"] != null && reader["shopidlist"].ToString() != "")
                //{
                //    model.shopidlist = reader["shopidlist"].ToString();
                //}
                //if (reader["brandidlist"] != null && reader["brandidlist"].ToString() != "")
                //{
                //    model.brandidlist = reader["brandidlist"].ToString();
                //}
                //if (reader["marketidlist"] != null && reader["marketidlist"].ToString() != "")
                //{
                //    model.marketidlist = reader["marketidlist"].ToString();
                //}
                //if (reader["productidlist"] != null && reader["productidlist"].ToString() != "")
                //{
                //    model.productidlist = reader["productidlist"].ToString();
                //}


                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return list;
        }

        /// <summary>
        /// 活动信息
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="strWhere"></param>
        /// <param name="sortkey"></param>
        /// <param name="orderby"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public static List<EnWebPromotion> GetPromotionList(int PageIndex, int PageSize, string strWhere, string sortkey, string orderby, out int pageCount)
        {
            List<EnWebPromotion> list = new List<EnWebPromotion>();
            IDataReader reader = DataCommon.GetPageDataReader(" t_promotions ", PageIndex, PageSize, strWhere, sortkey, orderby, out pageCount);
            while (reader.Read())
            {
                EnWebPromotion model = new EnWebPromotion();
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["htmltitle"] != null && reader["htmltitle"].ToString() != "")
                {
                    model.htmltitle = reader["htmltitle"].ToString();
                }
                if (reader["membertype"] != null && reader["membertype"].ToString() != "")
                {
                    model.ptype = int.Parse(reader["membertype"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["startdatetime"] != null && reader["startdatetime"].ToString() != "")
                {
                    model.startdatetime = DateTime.Parse(reader["startdatetime"].ToString());
                }
                if (reader["enddatetime"] != null && reader["enddatetime"].ToString() != "")
                {
                    model.enddatetime = DateTime.Parse(reader["enddatetime"].ToString());
                }
                if (reader["createtime"] != null && reader["createtime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["createtime"].ToString());
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.auditstatus = int.Parse(reader["auditstatus"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.linestatus = int.Parse(reader["linestatus"].ToString());
                }
                if (reader["hits"] != null && reader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(reader["hits"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }

                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return list;
        }

        //活动信息
        public static List<EnWebPromotionInfoList> GetWebPromotionInfoList(int PageIndex, int PageSize, string strWhere, string sortkey, string orderby, out int pageCount)
        {
            List<EnWebPromotionInfoList> list = new List<EnWebPromotionInfoList>();
            IDataReader reader = DataCommon.GetPageDataReader(TableName.TVPromotionInfoList, PageIndex, PageSize, strWhere, sortkey, orderby, out pageCount);
            while (reader.Read())
            {
                EnWebPromotionInfoList model = new EnWebPromotionInfoList();
                if (reader["brandlogo"] != null && reader["brandlogo"].ToString() != "")
                {
                    model.brandlogo = reader["brandlogo"].ToString();
                }
                if (reader["ptitle"] != null && reader["ptitle"].ToString() != "")
                {
                    model.ptitle = reader["ptitle"].ToString();
                }
                if (reader["htmltitle"] != null && reader["htmltitle"].ToString() != "")
                {
                    model.htmltitle = reader["htmltitle"].ToString();
                }
                if (reader["startdatetime"] != null && reader["startdatetime"].ToString() != "")
                {
                    model.startdatetime = DateTime.Parse(reader["startdatetime"].ToString());
                }
                if (reader["enddatetime"] != null && reader["enddatetime"].ToString() != "")
                {
                    model.enddatetime = DateTime.Parse(reader["enddatetime"].ToString());
                }
                if (reader["areacode"] != null && reader["areacode"].ToString() != "")
                {
                    model.areacode = reader["areacode"].ToString();
                }
                if (reader["address"] != null && reader["address"].ToString() != "")
                {
                    model.address = reader["address"].ToString();
                }
                if (reader["ptype"] != null && reader["ptype"].ToString() != "")
                {
                    model.ptype = int.Parse(reader["ptype"].ToString());
                }
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["pid"] != null && reader["pid"].ToString() != "")
                {
                    model.pid = int.Parse(reader["pid"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["type"] != null && reader["type"].ToString() != "")
                {
                    model.type = reader["type"].ToString();
                }
                if (reader["value"] != null && reader["value"].ToString() != "")
                {
                    model.value = reader["value"].ToString();
                }
                if (reader["valueletter"] != null && reader["valueletter"].ToString() != "")
                {
                    model.valueletter = reader["valueletter"].ToString();
                }
                if (reader["valuetitle"] != null && reader["valuetitle"].ToString() != "")
                {
                    model.valuetitle = reader["valuetitle"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["banner"] != null && reader["banner"].ToString() != "")
                {
                    model.banner = reader["banner"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["curcountmoney"] != null && reader["curcountmoney"].ToString() != "")
                {
                    model.curcountmoney = reader["curcountmoney"].ToString();
                }
                if (reader["curcountpeople"] != null && reader["curcountpeople"].ToString() != "")
                {
                    model.curcountpeople = reader["curcountpeople"].ToString();
                }
                if (reader["curstage"] != null && reader["curstage"].ToString() != "")
                {
                    model.curstage = reader["curstage"].ToString();
                }
                if (reader["fordio"] != null && reader["fordio"].ToString() != "")
                {
                    model.fordio = reader["fordio"].ToString();
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["stagelist"] != null && reader["stagelist"].ToString() != "")
                {
                    model.stagelist = reader["stagelist"].ToString();
                }
                if (reader["stagecount"] != null && reader["stagecount"].ToString() != "")
                {
                    model.stagecount = int.Parse(reader["stagecount"].ToString());
                }

                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return list;
        }

        //活动信息
        public static EnWebPromotionInfoList GetWebPromotionInfoListInfo(string strWhere)
        {
            EnWebPromotionInfoList model = new EnWebPromotionInfoList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from "+TableName.TVPromotionInfoList+" ");
            strSql.Append(strWhere);
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            while (reader.Read())
            {
                if (reader["brandlogo"] != null && reader["brandlogo"].ToString() != "")
                {
                    model.brandlogo = reader["brandlogo"].ToString();
                }
                if (reader["ptitle"] != null && reader["ptitle"].ToString() != "")
                {
                    model.ptitle = reader["ptitle"].ToString();
                }
                if (reader["htmltitle"] != null && reader["htmltitle"].ToString() != "")
                {
                    model.htmltitle = reader["htmltitle"].ToString();
                }
                if (reader["startdatetime"] != null && reader["startdatetime"].ToString() != "")
                {
                    model.startdatetime = DateTime.Parse(reader["startdatetime"].ToString());
                }
                if (reader["enddatetime"] != null && reader["enddatetime"].ToString() != "")
                {
                    model.enddatetime = DateTime.Parse(reader["enddatetime"].ToString());
                }
                if (reader["areacode"] != null && reader["areacode"].ToString() != "")
                {
                    model.areacode = reader["areacode"].ToString();
                }
                if (reader["address"] != null && reader["address"].ToString() != "")
                {
                    model.address = reader["address"].ToString();
                }
                if (reader["ptype"] != null && reader["ptype"].ToString() != "")
                {
                    model.ptype = int.Parse(reader["ptype"].ToString());
                }
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["pid"] != null && reader["pid"].ToString() != "")
                {
                    model.pid = int.Parse(reader["pid"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["type"] != null && reader["type"].ToString() != "")
                {
                    model.type = reader["type"].ToString();
                }
                if (reader["value"] != null && reader["value"].ToString() != "")
                {
                    model.value = reader["value"].ToString();
                }
                if (reader["valueletter"] != null && reader["valueletter"].ToString() != "")
                {
                    model.valueletter = reader["valueletter"].ToString();
                }
                if (reader["valuetitle"] != null && reader["valuetitle"].ToString() != "")
                {
                    model.valuetitle = reader["valuetitle"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["banner"] != null && reader["banner"].ToString() != "")
                {
                    model.banner = reader["banner"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["curcountmoney"] != null && reader["curcountmoney"].ToString() != "")
                {
                    model.curcountmoney = reader["curcountmoney"].ToString();
                }
                if (reader["curcountpeople"] != null && reader["curcountpeople"].ToString() != "")
                {
                    model.curcountpeople = reader["curcountpeople"].ToString();
                }
                if (reader["curstage"] != null && reader["curstage"].ToString() != "")
                {
                    model.curstage = reader["curstage"].ToString();
                }
                if (reader["fordio"] != null && reader["fordio"].ToString() != "")
                {
                    model.fordio = reader["fordio"].ToString();
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["stagelist"] != null && reader["stagelist"].ToString() != "")
                {
                    model.stagelist = reader["stagelist"].ToString();
                }
                if (reader["stagecount"] != null && reader["stagecount"].ToString() != "")
                {
                    model.stagecount = int.Parse(reader["stagecount"].ToString());
                }

            }
            if (!reader.IsClosed)
                reader.Close();
            return model;
        }


        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditPromotion(EnPromotion model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_promotion(");
                strSql.Append("title,htmltitle,letter,attribute,ptype,startdatetime,enddatetime,areacode,address,surface,logo,thumb,bannel,desimage,descript,keywords,template,hits,sort,createmid,lastedid,lastedittime,auditstatus,linestatus)");
                strSql.Append(" values (");
                strSql.Append("@title,@htmltitle,@letter,@attribute,@ptype,@startdatetime,@enddatetime,@areacode,@address,@surface,@logo,@thumb,@bannel,@desimage,@descript,@keywords,@template,@hits,@sort,@createmid,@lastedid,@lastedittime,@auditstatus,@linestatus)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@htmltitle", SqlDbType.NVarChar,500),
					new SqlParameter("@letter", SqlDbType.VarChar,20),
					new SqlParameter("@attribute", SqlDbType.VarChar,100),
					new SqlParameter("@ptype", SqlDbType.Int,4),
					new SqlParameter("@startdatetime", SqlDbType.DateTime),
					new SqlParameter("@enddatetime", SqlDbType.DateTime),
					new SqlParameter("@areacode", SqlDbType.VarChar,10),
					new SqlParameter("@address", SqlDbType.NVarChar,50),
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
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.htmltitle;
                parameters[2].Value = model.letter;
                parameters[3].Value = model.attribute;
                parameters[4].Value = model.ptype;
                parameters[5].Value = model.startdatetime;
                parameters[6].Value = model.enddatetime;
                parameters[7].Value = model.areacode;
                parameters[8].Value = model.address;
                parameters[9].Value = model.surface;
                parameters[10].Value = model.logo;
                parameters[11].Value = model.thumb;
                parameters[12].Value = model.bannel;
                parameters[13].Value = model.desimage;
                parameters[14].Value = model.descript;
                parameters[15].Value = model.keywords;
                parameters[16].Value = model.template;
                parameters[17].Value = model.hits;
                parameters[18].Value = model.sort;
                parameters[19].Value = model.createmid;
                parameters[20].Value = model.lastedid;
                parameters[21].Value = model.lastedittime;
                parameters[22].Value = model.auditstatus;
                parameters[23].Value = model.linestatus;



                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_promotion set ");
                strSql.Append("title=@title,");
                strSql.Append("htmltitle=@htmltitle,");
                strSql.Append("letter=@letter,");
                strSql.Append("attribute=@attribute,");
                strSql.Append("ptype=@ptype,");
                strSql.Append("startdatetime=@startdatetime,");
                strSql.Append("enddatetime=@enddatetime,");
                strSql.Append("areacode=@areacode,");
                strSql.Append("address=@address,");
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
                strSql.Append("lastedid=@lastedid,");
                strSql.Append("lastedittime=@lastedittime,");
                strSql.Append("auditstatus=@auditstatus,");
                strSql.Append("linestatus=@linestatus");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@htmltitle", SqlDbType.NVarChar,500),
					new SqlParameter("@letter", SqlDbType.VarChar,20),
					new SqlParameter("@attribute", SqlDbType.VarChar,100),
					new SqlParameter("@ptype", SqlDbType.Int,4),
					new SqlParameter("@startdatetime", SqlDbType.DateTime),
					new SqlParameter("@enddatetime", SqlDbType.DateTime),
					new SqlParameter("@areacode", SqlDbType.VarChar,10),
					new SqlParameter("@address", SqlDbType.NVarChar,50),
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
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.htmltitle;
                parameters[2].Value = model.letter;
                parameters[3].Value = model.attribute;
                parameters[4].Value = model.ptype;
                parameters[5].Value = model.startdatetime;
                parameters[6].Value = model.enddatetime;
                parameters[7].Value = model.areacode;
                parameters[8].Value = model.address;
                parameters[9].Value = model.surface;
                parameters[10].Value = model.logo;
                parameters[11].Value = model.thumb;
                parameters[12].Value = model.bannel;
                parameters[13].Value = model.desimage;
                parameters[14].Value = model.descript;
                parameters[15].Value = model.keywords;
                parameters[16].Value = model.template;
                parameters[17].Value = model.hits;
                parameters[18].Value = model.sort;
                parameters[19].Value = model.createmid;
                parameters[20].Value = model.lastedid;
                parameters[21].Value = model.lastedittime;
                parameters[22].Value = model.auditstatus;
                parameters[23].Value = model.linestatus;
                parameters[24].Value = model.id;

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
        public static EnPromotion GetPromotionInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_Promotion ");
            strSql.Append(strWhere);


            EnPromotion model = new EnPromotion();
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
                if (reader["htmltitle"] != null && reader["htmltitle"].ToString() != "")
                {
                    model.htmltitle = reader["htmltitle"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["ptype"] != null && reader["ptype"].ToString() != "")
                {
                    model.ptype = int.Parse(reader["ptype"].ToString());
                }
                if (reader["startdatetime"] != null && reader["startdatetime"].ToString() != "")
                {
                    model.startdatetime = DateTime.Parse(reader["startdatetime"].ToString());
                }
                if (reader["enddatetime"] != null && reader["enddatetime"].ToString() != "")
                {
                    model.enddatetime = DateTime.Parse(reader["enddatetime"].ToString());
                }
                if (reader["areacode"] != null && reader["areacode"].ToString() != "")
                {
                    model.areacode = reader["areacode"].ToString();
                }
                if (reader["address"] != null && reader["address"].ToString() != "")
                {
                    model.address = reader["address"].ToString();
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
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnPromotion> GetPromotionList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnPromotion> modelList = new List<EnPromotion>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBPromotion, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnPromotion model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnPromotion();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["htmltitle"] != null && dt.Rows[n]["htmltitle"].ToString() != "")
                    {
                        model.htmltitle = dt.Rows[n]["htmltitle"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["ptype"] != null && dt.Rows[n]["ptype"].ToString() != "")
                    {
                        model.ptype = int.Parse(dt.Rows[n]["ptype"].ToString());
                    }
                    if (dt.Rows[n]["startdatetime"] != null && dt.Rows[n]["startdatetime"].ToString() != "")
                    {
                        model.startdatetime = DateTime.Parse(dt.Rows[n]["startdatetime"].ToString());
                    }
                    if (dt.Rows[n]["enddatetime"] != null && dt.Rows[n]["enddatetime"].ToString() != "")
                    {
                        model.enddatetime = DateTime.Parse(dt.Rows[n]["enddatetime"].ToString());
                    }
                    if (dt.Rows[n]["areacode"] != null && dt.Rows[n]["areacode"].ToString() != "")
                    {
                        model.areacode = dt.Rows[n]["areacode"].ToString();
                    }
                    if (dt.Rows[n]["address"] != null && dt.Rows[n]["address"].ToString() != "")
                    {
                        model.address = dt.Rows[n]["address"].ToString();
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
                    if (dt.Rows[n]["lastedid"] != null && dt.Rows[n]["lastedid"].ToString() != "")
                    {
                        model.lastedid = int.Parse(dt.Rows[n]["lastedid"].ToString());
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
        /// 更新对像
        /// </summary>
        public static int EditPromotionDef(EnPromotionDef model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_promotiondef(");
                strSql.Append("title,pid,attribute,type,value,valueletter,valuetitle,thumb,banner,descript,curcountmoney,curcountpeople,curstage,fordio,sort)");
                strSql.Append(" values (");
                strSql.Append("@title,@pid,@attribute,@type,@value,@valueletter,@valuetitle,@thumb,@banner,@descript,@curcountmoney,@curcountpeople,@curstage,@fordio,@sort)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,300),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@attribute", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.VarChar,20),
					new SqlParameter("@value", SqlDbType.VarChar,20),
					new SqlParameter("@valueletter", SqlDbType.VarChar,20),
					new SqlParameter("@valuetitle", SqlDbType.NVarChar,50),
					new SqlParameter("@thumb", SqlDbType.VarChar,100),
					new SqlParameter("@banner", SqlDbType.VarChar,400),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@curcountmoney", SqlDbType.VarChar,20),
					new SqlParameter("@curcountpeople", SqlDbType.VarChar,20),
					new SqlParameter("@curstage", SqlDbType.VarChar,20),
					new SqlParameter("@fordio", SqlDbType.VarChar,20),
					new SqlParameter("@sort", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.pid;
                parameters[2].Value = model.attribute;
                parameters[3].Value = model.type;
                parameters[4].Value = model.value;
                parameters[5].Value = model.valueletter;
                parameters[6].Value = model.valuetitle;
                parameters[7].Value = model.thumb;
                parameters[8].Value = model.banner;
                parameters[9].Value = model.descript;
                parameters[10].Value = model.curcountmoney;
                parameters[11].Value = model.curcountpeople;
                parameters[12].Value = model.curstage;
                parameters[13].Value = model.fordio;
                parameters[14].Value = model.sort;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_promotiondef set ");
                strSql.Append("title=@title,");
                strSql.Append("pid=@pid,");
                strSql.Append("attribute=@attribute,");
                strSql.Append("type=@type,");
                strSql.Append("value=@value,");
                strSql.Append("valueletter=@valueletter,");
                strSql.Append("valuetitle=@valuetitle,");
                strSql.Append("thumb=@thumb,");
                strSql.Append("banner=@banner,");
                strSql.Append("descript=@descript,");
                strSql.Append("curcountmoney=@curcountmoney,");
                strSql.Append("curcountpeople=@curcountpeople,");
                strSql.Append("curstage=@curstage,");
                strSql.Append("fordio=@fordio,");
                strSql.Append("sort=@sort");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,300),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@attribute", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.VarChar,20),
					new SqlParameter("@value", SqlDbType.VarChar,20),
					new SqlParameter("@valueletter", SqlDbType.VarChar,20),
					new SqlParameter("@valuetitle", SqlDbType.NVarChar,50),
					new SqlParameter("@thumb", SqlDbType.VarChar,100),
					new SqlParameter("@banner", SqlDbType.VarChar,400),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@curcountmoney", SqlDbType.VarChar,20),
					new SqlParameter("@curcountpeople", SqlDbType.VarChar,20),
					new SqlParameter("@curstage", SqlDbType.VarChar,20),
					new SqlParameter("@fordio", SqlDbType.VarChar,20),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.pid;
                parameters[2].Value = model.attribute;
                parameters[3].Value = model.type;
                parameters[4].Value = model.value;
                parameters[5].Value = model.valueletter;
                parameters[6].Value = model.valuetitle;
                parameters[7].Value = model.thumb;
                parameters[8].Value = model.banner;
                parameters[9].Value = model.descript;
                parameters[10].Value = model.curcountmoney;
                parameters[11].Value = model.curcountpeople;
                parameters[12].Value = model.curstage;
                parameters[13].Value = model.fordio;
                parameters[14].Value = model.sort;
                parameters[15].Value = model.id;

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
        public static EnPromotionDef GetPromotionDefInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_Promotiondef ");
            strSql.Append(strWhere);


            EnPromotionDef model = new EnPromotionDef();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["pid"] != null && reader["pid"].ToString() != "")
                {
                    model.pid = int.Parse(reader["pid"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["type"] != null && reader["type"].ToString() != "")
                {
                    model.type = reader["type"].ToString();
                }
                if (reader["value"] != null && reader["value"].ToString() != "")
                {
                    model.value = reader["value"].ToString();
                }
                if (reader["valueletter"] != null && reader["valueletter"].ToString() != "")
                {
                    model.valueletter = reader["valueletter"].ToString();
                }
                if (reader["valuetitle"] != null && reader["valuetitle"].ToString() != "")
                {
                    model.valuetitle = reader["valuetitle"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["banner"] != null && reader["banner"].ToString() != "")
                {
                    model.banner = reader["banner"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["curcountmoney"] != null && reader["curcountmoney"].ToString() != "")
                {
                    model.curcountmoney = reader["curcountmoney"].ToString();
                }
                if (reader["curcountpeople"] != null && reader["curcountpeople"].ToString() != "")
                {
                    model.curcountpeople = reader["curcountpeople"].ToString();
                }
                if (reader["curstage"] != null && reader["curstage"].ToString() != "")
                {
                    model.curstage = reader["curstage"].ToString();
                }
                if (reader["fordio"] != null && reader["fordio"].ToString() != "")
                {
                    model.fordio = reader["fordio"].ToString();
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
        public static List<EnPromotionDef> GetPromotionDefList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnPromotionDef> modelList = new List<EnPromotionDef>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBPromotionDef, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnPromotionDef model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnPromotionDef();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["pid"] != null && dt.Rows[n]["pid"].ToString() != "")
                    {
                        model.pid = int.Parse(dt.Rows[n]["pid"].ToString());
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = dt.Rows[n]["type"].ToString();
                    }
                    if (dt.Rows[n]["value"] != null && dt.Rows[n]["value"].ToString() != "")
                    {
                        model.value = dt.Rows[n]["value"].ToString();
                    }
                    if (dt.Rows[n]["valueletter"] != null && dt.Rows[n]["valueletter"].ToString() != "")
                    {
                        model.valueletter = dt.Rows[n]["valueletter"].ToString();
                    }
                    if (dt.Rows[n]["valuetitle"] != null && dt.Rows[n]["valuetitle"].ToString() != "")
                    {
                        model.valuetitle = dt.Rows[n]["valuetitle"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["banner"] != null && dt.Rows[n]["banner"].ToString() != "")
                    {
                        model.banner = dt.Rows[n]["banner"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["curcountmoney"] != null && dt.Rows[n]["curcountmoney"].ToString() != "")
                    {
                        model.curcountmoney = dt.Rows[n]["curcountmoney"].ToString();
                    }
                    if (dt.Rows[n]["curcountpeople"] != null && dt.Rows[n]["curcountpeople"].ToString() != "")
                    {
                        model.curcountpeople = dt.Rows[n]["curcountpeople"].ToString();
                    }
                    if (dt.Rows[n]["curstage"] != null && dt.Rows[n]["curstage"].ToString() != "")
                    {
                        model.curstage = dt.Rows[n]["curstage"].ToString();
                    }
                    if (dt.Rows[n]["fordio"] != null && dt.Rows[n]["fordio"].ToString() != "")
                    {
                        model.fordio = dt.Rows[n]["fordio"].ToString();
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditPromotionStage(EnPromotionStage model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_promotionstage(");
                strSql.Append("title,pid,did,stype,smodle,svaluemin,svaluemax,pmodule,prolue,pvalue,sort)");
                strSql.Append(" values (");
                strSql.Append("@title,@pid,@did,@stype,@smodle,@svaluemin,@svaluemax,@pmodule,@prolue,@pvalue,@sort)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@did", SqlDbType.Int,4),
					new SqlParameter("@stype", SqlDbType.Int,4),
					new SqlParameter("@smodle", SqlDbType.Int,4),
					new SqlParameter("@svaluemin", SqlDbType.NVarChar,50),
					new SqlParameter("@svaluemax", SqlDbType.NVarChar,50),
					new SqlParameter("@pmodule", SqlDbType.Int,4),
					new SqlParameter("@prolue", SqlDbType.NVarChar,50),
					new SqlParameter("@pvalue", SqlDbType.VarChar,50),
					new SqlParameter("@sort", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.pid;
                parameters[2].Value = model.did;
                parameters[3].Value = model.stype;
                parameters[4].Value = model.smodle;
                parameters[5].Value = model.svaluemin;
                parameters[6].Value = model.svaluemax;
                parameters[7].Value = model.pmodule;
                parameters[8].Value = model.prolue;
                parameters[9].Value = model.pvalue;
                parameters[10].Value = model.sort;



                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_promotionstage set ");
                strSql.Append("title=@title,");
                strSql.Append("pid=@pid,");
                strSql.Append("did=@did,");
                strSql.Append("stype=@stype,");
                strSql.Append("smodle=@smodle,");
                strSql.Append("svaluemin=@svaluemin,");
                strSql.Append("svaluemax=@svaluemax,");
                strSql.Append("pmodule=@pmodule,");
                strSql.Append("prolue=@prolue,");
                strSql.Append("pvalue=@pvalue,");
                strSql.Append("sort=@sort");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@did", SqlDbType.Int,4),
					new SqlParameter("@stype", SqlDbType.Int,4),
					new SqlParameter("@smodle", SqlDbType.Int,4),
					new SqlParameter("@svaluemin", SqlDbType.NVarChar,50),
					new SqlParameter("@svaluemax", SqlDbType.NVarChar,50),
					new SqlParameter("@pmodule", SqlDbType.Int,4),
					new SqlParameter("@prolue", SqlDbType.NVarChar,50),
					new SqlParameter("@pvalue", SqlDbType.VarChar,50),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.pid;
                parameters[2].Value = model.did;
                parameters[3].Value = model.stype;
                parameters[4].Value = model.smodle;
                parameters[5].Value = model.svaluemin;
                parameters[6].Value = model.svaluemax;
                parameters[7].Value = model.pmodule;
                parameters[8].Value = model.prolue;
                parameters[9].Value = model.pvalue;
                parameters[10].Value = model.sort;
                parameters[11].Value = model.id;

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
        public static EnPromotionStage GetPromotionStageInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_PromotionStage ");
            strSql.Append(strWhere);


            EnPromotionStage model = new EnPromotionStage();
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
                if (reader["pid"] != null && reader["pid"].ToString() != "")
                {
                    model.pid = int.Parse(reader["pid"].ToString());
                }
                if (reader["did"] != null && reader["did"].ToString() != "")
                {
                    model.did = int.Parse(reader["did"].ToString());
                }
                if (reader["stype"] != null && reader["stype"].ToString() != "")
                {
                    model.stype = int.Parse(reader["stype"].ToString());
                }
                if (reader["smodle"] != null && reader["smodle"].ToString() != "")
                {
                    model.smodle = int.Parse(reader["smodle"].ToString());
                }
                if (reader["svaluemin"] != null && reader["svaluemin"].ToString() != "")
                {
                    model.svaluemin = reader["svaluemin"].ToString();
                }
                if (reader["svaluemax"] != null && reader["svaluemax"].ToString() != "")
                {
                    model.svaluemax = reader["svaluemax"].ToString();
                }
                if (reader["pmodule"] != null && reader["pmodule"].ToString() != "")
                {
                    model.pmodule = int.Parse(reader["pmodule"].ToString());
                }
                if (reader["prolue"] != null && reader["prolue"].ToString() != "")
                {
                    model.prolue = reader["prolue"].ToString();
                }
                if (reader["pvalue"] != null && reader["pvalue"].ToString() != "")
                {
                    model.pvalue = reader["pvalue"].ToString();
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
        public static List<EnPromotionStage> GetPromotionStageList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnPromotionStage> modelList = new List<EnPromotionStage>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBPromotionStage, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnPromotionStage model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnPromotionStage();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["pid"] != null && dt.Rows[n]["pid"].ToString() != "")
                    {
                        model.pid = int.Parse(dt.Rows[n]["pid"].ToString());
                    }
                    if (dt.Rows[n]["did"] != null && dt.Rows[n]["did"].ToString() != "")
                    {
                        model.did = int.Parse(dt.Rows[n]["did"].ToString());
                    }
                    if (dt.Rows[n]["stype"] != null && dt.Rows[n]["stype"].ToString() != "")
                    {
                        model.stype = int.Parse(dt.Rows[n]["stype"].ToString());
                    }
                    if (dt.Rows[n]["smodle"] != null && dt.Rows[n]["smodle"].ToString() != "")
                    {
                        model.smodle = int.Parse(dt.Rows[n]["smodle"].ToString());
                    }
                    if (dt.Rows[n]["svaluemin"] != null && dt.Rows[n]["svaluemin"].ToString() != "")
                    {
                        model.svaluemin = dt.Rows[n]["svaluemin"].ToString();
                    }
                    if (dt.Rows[n]["svaluemax"] != null && dt.Rows[n]["svaluemax"].ToString() != "")
                    {
                        model.svaluemax = dt.Rows[n]["svaluemax"].ToString();
                    }
                    if (dt.Rows[n]["pmodule"] != null && dt.Rows[n]["pmodule"].ToString() != "")
                    {
                        model.pmodule = int.Parse(dt.Rows[n]["pmodule"].ToString());
                    }
                    if (dt.Rows[n]["prolue"] != null && dt.Rows[n]["prolue"].ToString() != "")
                    {
                        model.prolue = dt.Rows[n]["prolue"].ToString();
                    }
                    if (dt.Rows[n]["pvalue"] != null && dt.Rows[n]["pvalue"].ToString() != "")
                    {
                        model.pvalue = dt.Rows[n]["pvalue"].ToString();
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


    }
}
