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
    public class ProductAttributes
    {
        #region 删除多余的产品属性信息
        /// <summary>
        /// 删除多余的产品属性信息
        /// </summary>
        /// <param name="strwhere">where 条件  id='</param>
        /// <returns></returns>
        public static int DelProductAttribute(string strwhere)
        {
            if (strwhere != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete  t_productattribute where  ");
                strSql.Append(strwhere);
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString());
                return TypeConverter.ObjectToInt(obj);
            }
            else
            {
                return 0;
            }
        }
        #endregion

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditProductAttribute(EnProductAttribute model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                // strSql.Append("delete  t_productattribute where productid=@productid ");
                strSql.Append("insert into t_productattribute(");
                strSql.Append("productid,productno,productsku,typevalue,typename,productstyle,productmaterial,productcolorimg,productcolortitle,productcolorvalue,productwidth,productheight,productlength,productcbm,buyprice,markprice,saleprice,otherinfo,storage,sort,isdefault,ProductAttributePromotion)");
                strSql.Append(" values (");
                strSql.Append("@productid,@productno,@productsku,@typevalue,@typename,@productstyle,@productmaterial,@productcolorimg,@productcolortitle,@productcolorvalue,@productwidth,@productheight,@productlength,@productcbm,@buyprice,@markprice,@saleprice,@otherinfo,@storage,@sort,@isdefault,@ProductAttributePromotion)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@productid", SqlDbType.Int,4),
					new SqlParameter("@productno", SqlDbType.VarChar,50),
					new SqlParameter("@productsku", SqlDbType.VarChar,50),
					new SqlParameter("@typevalue", SqlDbType.NVarChar,50),
					new SqlParameter("@typename", SqlDbType.NVarChar,50),
					new SqlParameter("@productstyle", SqlDbType.NVarChar,50),
					new SqlParameter("@productmaterial", SqlDbType.NVarChar,50),
					new SqlParameter("@productcolorimg", SqlDbType.VarChar,60),
					new SqlParameter("@productcolortitle", SqlDbType.NVarChar,50),
					new SqlParameter("@productcolorvalue", SqlDbType.NVarChar,50),
					new SqlParameter("@productwidth", SqlDbType.Decimal,9),
					new SqlParameter("@productheight", SqlDbType.Decimal,9),
					new SqlParameter("@productlength", SqlDbType.Decimal,9),
					new SqlParameter("@productcbm", SqlDbType.Decimal,9),
					new SqlParameter("@buyprice", SqlDbType.Decimal,9),
					new SqlParameter("@markprice", SqlDbType.Decimal,9),
					new SqlParameter("@saleprice", SqlDbType.Decimal,9),
					new SqlParameter("@otherinfo", SqlDbType.NText),
					new SqlParameter("@storage", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
                    new SqlParameter("@isdefault", SqlDbType.Int,4),
                    new SqlParameter("@ProductAttributePromotion", SqlDbType.Int,4)};
                parameters[0].Value = model.productid;
                parameters[1].Value = model.productno;
                parameters[2].Value = model.productsku;
                parameters[3].Value = model.typevalue;
                parameters[4].Value = model.typename;
                parameters[5].Value = model.productstyle;
                parameters[6].Value = model.productmaterial;
                parameters[7].Value = model.productcolorimg;
                parameters[8].Value = model.productcolortitle;
                parameters[9].Value = model.productcolorvalue;
                parameters[10].Value = model.productwidth;
                parameters[11].Value = model.productheight;
                parameters[12].Value = model.productlength;
                parameters[13].Value = model.productcbm;
                parameters[14].Value = model.buyprice;
                parameters[15].Value = model.markprice;
                parameters[16].Value = model.saleprice;
                parameters[17].Value = model.otherinfo;
                parameters[18].Value = model.storage;
                parameters[19].Value = model.sort;
                parameters[20].Value = model.isdefault;
                parameters[21].Value = model.productAttributePromotion;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_productattribute set ");
                strSql.Append("productid=@productid,");
                strSql.Append("productno=@productno,");
                strSql.Append("productsku=@productsku,");
                strSql.Append("typevalue=@typevalue,");
                strSql.Append("typename=@typename,");
                strSql.Append("productstyle=@productstyle,");
                strSql.Append("productmaterial=@productmaterial,");
                strSql.Append("productcolorimg=@productcolorimg,");
                strSql.Append("productcolortitle=@productcolortitle,");
                strSql.Append("productcolorvalue=@productcolorvalue,");
                strSql.Append("productwidth=@productwidth,");
                strSql.Append("productheight=@productheight,");
                strSql.Append("productlength=@productlength,");
                strSql.Append("productcbm=@productcbm,");
                strSql.Append("buyprice=@buyprice,");
                strSql.Append("markprice=@markprice,");
                strSql.Append("saleprice=@saleprice,");
                strSql.Append("otherinfo=@otherinfo,");
                strSql.Append("storage=@storage,");
                strSql.Append("sort=@sort,");
                strSql.Append("isdefault=@isdefault,");
                strSql.Append("ProductAttributePromotion=@ProductAttributePromotion");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@productid", SqlDbType.Int,4),
					new SqlParameter("@productno", SqlDbType.VarChar,50),
					new SqlParameter("@productsku", SqlDbType.VarChar,50),
					new SqlParameter("@typevalue", SqlDbType.NVarChar,50),
					new SqlParameter("@typename", SqlDbType.NVarChar,50),
					new SqlParameter("@productstyle", SqlDbType.NVarChar,50),
					new SqlParameter("@productmaterial", SqlDbType.NVarChar,50),
					new SqlParameter("@productcolorimg", SqlDbType.VarChar,60),
					new SqlParameter("@productcolortitle", SqlDbType.NVarChar,50),
					new SqlParameter("@productcolorvalue", SqlDbType.NVarChar,50),
					new SqlParameter("@productwidth", SqlDbType.Decimal,9),
					new SqlParameter("@productheight", SqlDbType.Decimal,9),
					new SqlParameter("@productlength", SqlDbType.Decimal,9),
					new SqlParameter("@productcbm", SqlDbType.Decimal,9),
					new SqlParameter("@buyprice", SqlDbType.Decimal,9),
					new SqlParameter("@markprice", SqlDbType.Decimal,9),
					new SqlParameter("@saleprice", SqlDbType.Decimal,9),
					new SqlParameter("@otherinfo", SqlDbType.NText),
					new SqlParameter("@storage", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@isdefault", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@ProductAttributePromotion", SqlDbType.Int,4)};
                parameters[0].Value = model.productid;
                parameters[1].Value = model.productno;
                parameters[2].Value = model.productsku;
                parameters[3].Value = model.typevalue;
                parameters[4].Value = model.typename;
                parameters[5].Value = model.productstyle;
                parameters[6].Value = model.productmaterial;
                parameters[7].Value = model.productcolorimg;
                parameters[8].Value = model.productcolortitle;
                parameters[9].Value = model.productcolorvalue;
                parameters[10].Value = model.productwidth;
                parameters[11].Value = model.productheight;
                parameters[12].Value = model.productlength;
                parameters[13].Value = model.productcbm;
                parameters[14].Value = model.buyprice;
                parameters[15].Value = model.markprice;
                parameters[16].Value = model.saleprice;
                parameters[17].Value = model.otherinfo;
                parameters[18].Value = model.storage;
                parameters[19].Value = model.sort;
                parameters[20].Value = model.isdefault;
                parameters[21].Value = model.id;
                parameters[22].Value = model.productAttributePromotion;

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
        /// <param name="strWhere">where 条件（where id=11）</param>
        /// <returns></returns>
        public static EnProductAttribute GetProductAttributeInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_ProductAttribute ");
            strSql.Append(strWhere);


            EnProductAttribute model = new EnProductAttribute();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["productid"] != null && reader["productid"].ToString() != "")
                {
                    model.productid = int.Parse(reader["productid"].ToString());
                }
                if (reader["productno"] != null && reader["productno"].ToString() != "")
                {
                    model.productno = reader["productno"].ToString();
                }
                if (reader["productsku"] != null && reader["productsku"].ToString() != "")
                {
                    model.productsku = reader["productsku"].ToString();
                }
                if (reader["typevalue"] != null && reader["typevalue"].ToString() != "")
                {
                    model.typevalue = reader["typevalue"].ToString();
                }
                if (reader["typename"] != null && reader["typename"].ToString() != "")
                {
                    model.typename = reader["typename"].ToString();
                }
                if (reader["productstyle"] != null && reader["productstyle"].ToString() != "")
                {
                    model.productstyle = reader["productstyle"].ToString();
                }
                if (reader["productmaterial"] != null && reader["productmaterial"].ToString() != "")
                {
                    model.productmaterial = reader["productmaterial"].ToString();
                }
                if (reader["productcolorimg"] != null && reader["productcolorimg"].ToString() != "")
                {
                    model.productcolorimg = reader["productcolorimg"].ToString();
                }
                if (reader["productcolortitle"] != null && reader["productcolortitle"].ToString() != "")
                {
                    model.productcolortitle = reader["productcolortitle"].ToString();
                }
                if (reader["productcolorvalue"] != null && reader["productcolorvalue"].ToString() != "")
                {
                    model.productcolorvalue = reader["productcolorvalue"].ToString();
                }
                if (reader["productwidth"] != null && reader["productwidth"].ToString() != "")
                {
                    model.productwidth = decimal.Parse(reader["productwidth"].ToString());
                }
                if (reader["productheight"] != null && reader["productheight"].ToString() != "")
                {
                    model.productheight = decimal.Parse(reader["productheight"].ToString());
                }
                if (reader["productlength"] != null && reader["productlength"].ToString() != "")
                {
                    model.productlength = decimal.Parse(reader["productlength"].ToString());
                }
                if (reader["productcbm"] != null && reader["productcbm"].ToString() != "")
                {
                    model.productcbm = decimal.Parse(reader["productcbm"].ToString());
                }
                if (reader["buyprice"] != null && reader["buyprice"].ToString() != "")
                {
                    model.buyprice = decimal.Parse(reader["buyprice"].ToString());
                }
                if (reader["markprice"] != null && reader["markprice"].ToString() != "")
                {
                    model.markprice = decimal.Parse(reader["markprice"].ToString());
                }
                if (reader["saleprice"] != null && reader["saleprice"].ToString() != "")
                {
                    model.saleprice = decimal.Parse(reader["saleprice"].ToString());
                }
                if (reader["otherinfo"] != null && reader["otherinfo"].ToString() != "")
                {
                    model.otherinfo = reader["otherinfo"].ToString();
                }
                if (reader["storage"] != null && reader["storage"].ToString() != "")
                {
                    model.storage = int.Parse(reader["storage"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["isdefault"] != null && reader["isdefault"].ToString() != "")
                {
                    model.isdefault = int.Parse(reader["isdefault"].ToString());
                }
                if (reader["ProductAttributePromotion"] != null && reader["ProductAttributePromotion"].ToString() != "")
                {
                    model.productAttributePromotion = int.Parse(reader["ProductAttributePromotion"].ToString());
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
        public static List<EnProductAttribute> GetProductAttributeList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnProductAttribute> modelList = new List<EnProductAttribute>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBProductAttribute, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnProductAttribute model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnProductAttribute();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["productid"] != null && dt.Rows[n]["productid"].ToString() != "")
                    {
                        model.productid = int.Parse(dt.Rows[n]["productid"].ToString());
                    }
                    if (dt.Rows[n]["productno"] != null && dt.Rows[n]["productno"].ToString() != "")
                    {
                        model.productno = dt.Rows[n]["productno"].ToString();
                    }
                    if (dt.Rows[n]["productsku"] != null && dt.Rows[n]["productsku"].ToString() != "")
                    {
                        model.productsku = dt.Rows[n]["productsku"].ToString();
                    }
                    if (dt.Rows[n]["typevalue"] != null && dt.Rows[n]["typevalue"].ToString() != "")
                    {
                        model.typevalue = dt.Rows[n]["typevalue"].ToString();
                    }
                    if (dt.Rows[n]["typename"] != null && dt.Rows[n]["typename"].ToString() != "")
                    {
                        model.typename = dt.Rows[n]["typename"].ToString();
                    }
                    if (dt.Rows[n]["productstyle"] != null && dt.Rows[n]["productstyle"].ToString() != "")
                    {
                        model.productstyle = dt.Rows[n]["productstyle"].ToString();
                    }
                    if (dt.Rows[n]["productmaterial"] != null && dt.Rows[n]["productmaterial"].ToString() != "")
                    {
                        model.productmaterial = dt.Rows[n]["productmaterial"].ToString();
                    }
                    if (dt.Rows[n]["productcolorimg"] != null && dt.Rows[n]["productcolorimg"].ToString() != "")
                    {
                        model.productcolorimg = dt.Rows[n]["productcolorimg"].ToString();
                    }
                    if (dt.Rows[n]["productcolortitle"] != null && dt.Rows[n]["productcolortitle"].ToString() != "")
                    {
                        model.productcolortitle = dt.Rows[n]["productcolortitle"].ToString();
                    }
                    if (dt.Rows[n]["productcolorvalue"] != null && dt.Rows[n]["productcolorvalue"].ToString() != "")
                    {
                        model.productcolorvalue = dt.Rows[n]["productcolorvalue"].ToString();
                    }
                    if (dt.Rows[n]["productwidth"] != null && dt.Rows[n]["productwidth"].ToString() != "")
                    {
                        model.productwidth = decimal.Parse(dt.Rows[n]["productwidth"].ToString());
                    }
                    if (dt.Rows[n]["productheight"] != null && dt.Rows[n]["productheight"].ToString() != "")
                    {
                        model.productheight = decimal.Parse(dt.Rows[n]["productheight"].ToString());
                    }
                    if (dt.Rows[n]["productlength"] != null && dt.Rows[n]["productlength"].ToString() != "")
                    {
                        model.productlength = decimal.Parse(dt.Rows[n]["productlength"].ToString());
                    }
                    if (dt.Rows[n]["productcbm"] != null && dt.Rows[n]["productcbm"].ToString() != "")
                    {
                        model.productcbm = decimal.Parse(dt.Rows[n]["productcbm"].ToString());
                    }
                    if (dt.Rows[n]["buyprice"] != null && dt.Rows[n]["buyprice"].ToString() != "")
                    {
                        model.buyprice = decimal.Parse(dt.Rows[n]["buyprice"].ToString());
                    }
                    if (dt.Rows[n]["markprice"] != null && dt.Rows[n]["markprice"].ToString() != "")
                    {
                        model.markprice = decimal.Parse(dt.Rows[n]["markprice"].ToString());
                    }
                    if (dt.Rows[n]["saleprice"] != null && dt.Rows[n]["saleprice"].ToString() != "")
                    {
                        model.saleprice = decimal.Parse(dt.Rows[n]["saleprice"].ToString());
                    }
                    if (dt.Rows[n]["otherinfo"] != null && dt.Rows[n]["otherinfo"].ToString() != "")
                    {
                        model.otherinfo = dt.Rows[n]["otherinfo"].ToString();
                    }
                    if (dt.Rows[n]["storage"] != null && dt.Rows[n]["storage"].ToString() != "")
                    {
                        model.storage = int.Parse(dt.Rows[n]["storage"].ToString());
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["isdefault"] != null && dt.Rows[n]["isdefault"].ToString() != "")
                    {
                        model.isdefault = int.Parse(dt.Rows[n]["isdefault"].ToString());
                    }
                    if (dt.Rows[n]["productAttributePromotion"] != null && dt.Rows[n]["productAttributePromotion"].ToString() != "")
                    {
                        model.productAttributePromotion = int.Parse(dt.Rows[n]["productAttributePromotion"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 按照shopid获得数据列表
        /// </summary>
        public static List<EnProductAttribute> GetProductAttributeListByShopId(string shopId)
        {
            List<EnProductAttribute> modelList = new List<EnProductAttribute>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t_pa.id,t_pa.productid,t_pa.productno,t_pa.productsku,t_pa.typevalue,t_pa.typename,t_pa.productstyle,t_pa.productmaterial,t_pa.productcolorimg,t_pa.productcolortitle,t_pa.productcolorvalue,t_pa.productwidth,t_pa.productheight,t_pa.productlength,t_pa.productcbm,t_pa.buyprice,t_pa.markprice,t_pa.saleprice,t_pa.otherinfo,t_pa.storage,t_pa.sort,t_pa.isdefault,t_pa.productAttributePromotion from t_productattribute as t_pa join t_product as t_p on t_pa.productid=t_p.id join t_shopbrand as t_s on t_s.brandid=t_p.brandid where t_s.shopid=");
            strSql.Append(shopId);


            using (IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (reader.Read())
                {
                    EnProductAttribute model = new EnProductAttribute();
                    if (reader["id"] != null && reader["id"].ToString() != "")
                    {
                        model.id = int.Parse(reader["id"].ToString());
                    }
                    if (reader["productid"] != null && reader["productid"].ToString() != "")
                    {
                        model.productid = int.Parse(reader["productid"].ToString());
                    }
                    if (reader["productno"] != null && reader["productno"].ToString() != "")
                    {
                        model.productno = reader["productno"].ToString();
                    }
                    if (reader["productsku"] != null && reader["productsku"].ToString() != "")
                    {
                        model.productsku = reader["productsku"].ToString();
                    }
                    if (reader["typevalue"] != null && reader["typevalue"].ToString() != "")
                    {
                        model.typevalue = reader["typevalue"].ToString();
                    }
                    if (reader["typename"] != null && reader["typename"].ToString() != "")
                    {
                        model.typename = reader["typename"].ToString();
                    }
                    if (reader["productstyle"] != null && reader["productstyle"].ToString() != "")
                    {
                        model.productstyle = reader["productstyle"].ToString();
                    }
                    if (reader["productmaterial"] != null && reader["productmaterial"].ToString() != "")
                    {
                        model.productmaterial = reader["productmaterial"].ToString();
                    }
                    if (reader["productcolorimg"] != null && reader["productcolorimg"].ToString() != "")
                    {
                        model.productcolorimg = reader["productcolorimg"].ToString();
                    }
                    if (reader["productcolortitle"] != null && reader["productcolortitle"].ToString() != "")
                    {
                        model.productcolortitle = reader["productcolortitle"].ToString();
                    }
                    if (reader["productcolorvalue"] != null && reader["productcolorvalue"].ToString() != "")
                    {
                        model.productcolorvalue = reader["productcolorvalue"].ToString();
                    }
                    if (reader["productwidth"] != null && reader["productwidth"].ToString() != "")
                    {
                        model.productwidth = decimal.Parse(reader["productwidth"].ToString());
                    }
                    if (reader["productheight"] != null && reader["productheight"].ToString() != "")
                    {
                        model.productheight = decimal.Parse(reader["productheight"].ToString());
                    }
                    if (reader["productlength"] != null && reader["productlength"].ToString() != "")
                    {
                        model.productlength = decimal.Parse(reader["productlength"].ToString());
                    }
                    if (reader["productcbm"] != null && reader["productcbm"].ToString() != "")
                    {
                        model.productcbm = decimal.Parse(reader["productcbm"].ToString());
                    }
                    if (reader["buyprice"] != null && reader["buyprice"].ToString() != "")
                    {
                        model.buyprice = decimal.Parse(reader["buyprice"].ToString());
                    }
                    if (reader["markprice"] != null && reader["markprice"].ToString() != "")
                    {
                        model.markprice = decimal.Parse(reader["markprice"].ToString());
                    }
                    if (reader["saleprice"] != null && reader["saleprice"].ToString() != "")
                    {
                        model.saleprice = decimal.Parse(reader["saleprice"].ToString());
                    }
                    if (reader["otherinfo"] != null && reader["otherinfo"].ToString() != "")
                    {
                        model.otherinfo = reader["otherinfo"].ToString();
                    }
                    if (reader["storage"] != null && reader["storage"].ToString() != "")
                    {
                        model.storage = int.Parse(reader["storage"].ToString());
                    }
                    if (reader["sort"] != null && reader["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(reader["sort"].ToString());
                    }
                    if (reader["isdefault"] != null && reader["isdefault"].ToString() != "")
                    {
                        model.isdefault = int.Parse(reader["isdefault"].ToString());
                    }
                    if (reader["productAttributePromotion"] != null && reader["productAttributePromotion"].ToString() != "")
                    {
                        model.productAttributePromotion = int.Parse(reader["productAttributePromotion"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

    }
}
