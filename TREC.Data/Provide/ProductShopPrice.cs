using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TREC.Entity;
using System.Data;
using TRECommon;

namespace TREC.Data
{
    public class ProductShopPrice
    {
        
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditProductShopPrice(EnProductShopPrice model)
        {
            if (model.Id <= 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_productshopprice(");
                strSql.Append("[productid],[shopid],[price],[dollprice],[lastedittime],[brandid],[attributeid],[brandsid])");
                strSql.Append(" values (");
                strSql.Append("@productid,@shopid,@price,@dollprice,@lastedittime,@brandid,@attributeid,@brandsid)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@productid", SqlDbType.Int,4),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Decimal),
					new SqlParameter("@dollprice", SqlDbType.Decimal),
                    new SqlParameter("@lastedittime", SqlDbType.DateTime),
                    new SqlParameter("@brandid", SqlDbType.Int),
                    new SqlParameter("@attributeid", SqlDbType.Int),
                    new SqlParameter("@brandsid", SqlDbType.Int)};
                parameters[0].Value = model.Productid;
                parameters[1].Value = model.Shopid;
                parameters[2].Value = model.Price;
                parameters[3].Value = model.Dollprice;
                parameters[4].Value = model.Lastedittime;
                parameters[5].Value = model.Brandid;
                parameters[6].Value = model.Attributeid;
                parameters[7].Value = model.Brandsid;
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_productshopprice set ");
                strSql.Append("price=@price,");
                strSql.Append("dollprice=@dollprice,");
                strSql.Append("lastedittime=@lastedittime,");
                strSql.Append("brandid=@brandid,");
                strSql.Append("attributeid=@attributeid,");
                strSql.Append("brandsid=@brandsid");
                strSql.Append(" where productid=@productid and shopid=@shopid");
                //strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@productid", SqlDbType.Int,4),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Decimal),
					new SqlParameter("@dollprice", SqlDbType.Decimal),
                    new SqlParameter("@lastedittime", SqlDbType.DateTime),
                    new SqlParameter("@brandid", SqlDbType.Int),
                    new SqlParameter("@attributeid", SqlDbType.Int),
                    new SqlParameter("@brandsid", SqlDbType.Int)};
                parameters[0].Value = model.Productid;
                parameters[1].Value = model.Shopid;
                parameters[2].Value = model.Price;
                parameters[3].Value = model.Dollprice;
                parameters[4].Value = model.Lastedittime;
                parameters[5].Value = model.Brandid;
                parameters[6].Value = model.Attributeid;
                parameters[7].Value = model.Brandsid;
                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return model.Id;
                }
            }

            return 0;

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnProductShopPrice GetProductShopPriceInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_productshopprice ");
            strSql.Append(strWhere);


            EnProductShopPrice model = new EnProductShopPrice();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.Id = int.Parse(reader["id"].ToString());
                }
                if (reader["productid"] != null && reader["productid"].ToString() != "")
                {
                    model.Productid = int.Parse(reader["productid"].ToString());
                }
                if (reader["shopid"] != null && reader["shopid"].ToString() != "")
                {
                    model.Shopid = int.Parse(reader["shopid"].ToString());
                }
                if (reader["price"] != null && reader["price"].ToString() != "")
                {
                    model.Price = decimal.Parse(reader["price"].ToString());
                }
                if (reader["dollprice"] != null && reader["dollprice"].ToString() != "")
                {
                    model.Dollprice = decimal.Parse(reader["dollprice"].ToString());
                }
                if (reader["CreateTime"] != null && reader["CreateTime"].ToString() != "")
                {
                    model.Createtime = DateTime.Parse(reader["CreateTime"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.Lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["brandid"] != null && reader["brandid"].ToString() != "")
                {
                    model.Brandid = int.Parse(reader["brandid"].ToString());
                }
                if (reader["attributeid"] != null && reader["attributeid"].ToString() != "")
                {
                    model.Attributeid = int.Parse(reader["attributeid"].ToString());
                }
                if (reader["brandsid"] != null && reader["brandsid"].ToString() != "")
                {
                    model.Brandsid = int.Parse(reader["brandsid"].ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public static List<EnProductShopPrice> GetProductShopPriceListByShopId(string shopId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from t_productshopprice where shopid=");
            strSql.Append(shopId);

            List<EnProductShopPrice> modellist = new List<EnProductShopPrice>();
            
            using (IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (reader.Read())
                {
                    EnProductShopPrice model = new EnProductShopPrice();
                    if (reader["id"] != null && reader["id"].ToString() != "")
                    {
                        model.Id = int.Parse(reader["id"].ToString());
                    }
                    if (reader["productid"] != null && reader["productid"].ToString() != "")
                    {
                        model.Productid = int.Parse(reader["productid"].ToString());
                    }
                    if (reader["shopid"] != null && reader["shopid"].ToString() != "")
                    {
                        model.Shopid = int.Parse(reader["shopid"].ToString());
                    }
                    if (reader["price"] != null && reader["price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(reader["price"].ToString());
                    }
                    if (reader["dollprice"] != null && reader["dollprice"].ToString() != "")
                    {
                        model.Dollprice = decimal.Parse(reader["dollprice"].ToString());
                    }
                    if (reader["CreateTime"] != null && reader["CreateTime"].ToString() != "")
                    {
                        model.Createtime = DateTime.Parse(reader["CreateTime"].ToString());
                    }
                    if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                    {
                        model.Lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                    }
                    if (reader["brandid"] != null && reader["brandid"].ToString() != "")
                    {
                        model.Brandid = int.Parse(reader["brandid"].ToString());
                    }
                    if (reader["attributeid"] != null && reader["attributeid"].ToString() != "")
                    {
                        model.Attributeid = int.Parse(reader["attributeid"].ToString());
                    }
                    if (reader["brandsid"] != null && reader["brandsid"].ToString() != "")
                    {
                        model.Brandsid = int.Parse(reader["brandsid"].ToString());
                    }
                    modellist.Add(model);
                }
            }
            return modellist;
        }

        #region 获取店铺ids

        /// <summary>
        /// 获取店铺ids
        /// </summary>
        /// <param name="strWere">where条件，（id=1 and uid= ）</param>
        /// <returns></returns>
        public static List<EnProductShopPrice> GetProductShopPriceListByWhere(string strWere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from t_productshopprice where 1=1");
            if (strWere!="")
            {
                strSql.Append(" and" +strWere);
            }            

            List<EnProductShopPrice> modellist = new List<EnProductShopPrice>();

            using (IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (reader.Read())
                {
                    EnProductShopPrice model = new EnProductShopPrice();
                    if (reader["id"] != null && reader["id"].ToString() != "")
                    {
                        model.Id = int.Parse(reader["id"].ToString());
                    }
                    if (reader["productid"] != null && reader["productid"].ToString() != "")
                    {
                        model.Productid = int.Parse(reader["productid"].ToString());
                    }
                    if (reader["shopid"] != null && reader["shopid"].ToString() != "")
                    {
                        model.Shopid = int.Parse(reader["shopid"].ToString());
                    }
                    if (reader["price"] != null && reader["price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(reader["price"].ToString());
                    }
                    if (reader["dollprice"] != null && reader["dollprice"].ToString() != "")
                    {
                        model.Dollprice = decimal.Parse(reader["dollprice"].ToString());
                    }
                    if (reader["CreateTime"] != null && reader["CreateTime"].ToString() != "")
                    {
                        model.Createtime = DateTime.Parse(reader["CreateTime"].ToString());
                    }
                    if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                    {
                        model.Lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                    }
                    if (reader["brandid"] != null && reader["brandid"].ToString() != "")
                    {
                        model.Brandid = int.Parse(reader["brandid"].ToString());
                    }
                    if (reader["attributeid"] != null && reader["attributeid"].ToString() != "")
                    {
                        model.Attributeid = int.Parse(reader["attributeid"].ToString());
                    }
                    if (reader["brandsid"] != null && reader["brandsid"].ToString() != "")
                    {
                        model.Brandsid = int.Parse(reader["brandsid"].ToString());
                    }
                    modellist.Add(model);
                }
            }
            return modellist;
        }
        #endregion

    }
}
