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
    public class GroupOrders
    {
        #region GroupOrder


        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditGroupOrder(EnGroupOrder model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_grouporder(");
                strSql.Append("grouporderno,mid,fjmid,name,email,phone,fax,mphone,zip,areacode,address,descript,totlepromoney,totalmoney,invoicemoney,installationmeney,status,createtime)");
                strSql.Append(" values (");
                strSql.Append("@grouporderno,@mid,@fjmid,@name,@email,@phone,@fax,@mphone,@zip,@areacode,@address,@descript,@totlepromoney,@totalmoney,@invoicemoney,@installationmeney,@status,@createtime)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@grouporderno", SqlDbType.VarChar,20),
					new SqlParameter("@mid", SqlDbType.Int,4),
					new SqlParameter("@fjmid", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,20),
					new SqlParameter("@email", SqlDbType.NVarChar,20),
					new SqlParameter("@phone", SqlDbType.VarChar,20),
					new SqlParameter("@fax", SqlDbType.VarChar,20),
					new SqlParameter("@mphone", SqlDbType.VarChar,20),
					new SqlParameter("@zip", SqlDbType.VarChar,20),
					new SqlParameter("@areacode", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar,20),
					new SqlParameter("@descript", SqlDbType.NVarChar,600),
					new SqlParameter("@totlepromoney", SqlDbType.Decimal,9),
					new SqlParameter("@totalmoney", SqlDbType.Decimal,9),
					new SqlParameter("@invoicemoney", SqlDbType.Decimal,9),
					new SqlParameter("@installationmeney", SqlDbType.Decimal,9),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime)};
                parameters[0].Value = model.grouporderno;
                parameters[1].Value = model.mid;
                parameters[2].Value = model.fjmid;
                parameters[3].Value = model.name;
                parameters[4].Value = model.email;
                parameters[5].Value = model.phone;
                parameters[6].Value = model.fax;
                parameters[7].Value = model.mphone;
                parameters[8].Value = model.zip;
                parameters[9].Value = model.areacode;
                parameters[10].Value = model.address;
                parameters[11].Value = model.descript;
                parameters[12].Value = model.totlepromoney;
                parameters[13].Value = model.totalmoney;
                parameters[14].Value = model.invoicemoney;
                parameters[15].Value = model.installationmeney;
                parameters[16].Value = model.status;
                parameters[17].Value = model.createtime;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_grouporder set ");
                strSql.Append("grouporderno=@grouporderno,");
                strSql.Append("mid=@mid,");
                strSql.Append("fjmid=@fjmid,");
                strSql.Append("name=@name,");
                strSql.Append("email=@email,");
                strSql.Append("phone=@phone,");
                strSql.Append("fax=@fax,");
                strSql.Append("mphone=@mphone,");
                strSql.Append("zip=@zip,");
                strSql.Append("areacode=@areacode,");
                strSql.Append("address=@address,");
                strSql.Append("descript=@descript,");
                strSql.Append("totlepromoney=@totlepromoney,");
                strSql.Append("totalmoney=@totalmoney,");
                strSql.Append("invoicemoney=@invoicemoney,");
                strSql.Append("installationmeney=@installationmeney,");
                strSql.Append("status=@status,");
                strSql.Append("createtime=@createtime");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@grouporderno", SqlDbType.VarChar,20),
					new SqlParameter("@mid", SqlDbType.Int,4),
					new SqlParameter("@fjmid", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,20),
					new SqlParameter("@email", SqlDbType.NVarChar,20),
					new SqlParameter("@phone", SqlDbType.VarChar,20),
					new SqlParameter("@fax", SqlDbType.VarChar,20),
					new SqlParameter("@mphone", SqlDbType.VarChar,20),
					new SqlParameter("@zip", SqlDbType.VarChar,20),
					new SqlParameter("@areacode", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar,20),
					new SqlParameter("@descript", SqlDbType.NVarChar,600),
					new SqlParameter("@totlepromoney", SqlDbType.Decimal,9),
					new SqlParameter("@totalmoney", SqlDbType.Decimal,9),
					new SqlParameter("@invoicemoney", SqlDbType.Decimal,9),
					new SqlParameter("@installationmeney", SqlDbType.Decimal,9),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.grouporderno;
                parameters[1].Value = model.mid;
                parameters[2].Value = model.fjmid;
                parameters[3].Value = model.name;
                parameters[4].Value = model.email;
                parameters[5].Value = model.phone;
                parameters[6].Value = model.fax;
                parameters[7].Value = model.mphone;
                parameters[8].Value = model.zip;
                parameters[9].Value = model.areacode;
                parameters[10].Value = model.address;
                parameters[11].Value = model.descript;
                parameters[12].Value = model.totlepromoney;
                parameters[13].Value = model.totalmoney;
                parameters[14].Value = model.invoicemoney;
                parameters[15].Value = model.installationmeney;
                parameters[16].Value = model.status;
                parameters[17].Value = model.createtime;
                parameters[18].Value = model.id;

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
        public static EnGroupOrder GetGroupOrderInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_grouporder ");
            strSql.Append(strWhere);


            EnGroupOrder model = new EnGroupOrder();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["grouporderno"] != null && reader["grouporderno"].ToString() != "")
                {
                    model.grouporderno = reader["grouporderno"].ToString();
                }
                if (reader["name"] != null && reader["name"].ToString() != "")
                {
                    model.name = reader["name"].ToString();
                }
                if (reader["mid"] != null && reader["mid"].ToString() != "")
                {
                    model.mid = int.Parse(reader["mid"].ToString());
                }
                if (reader["fjmid"] != null && reader["fjmid"].ToString() != "")
                {
                    model.fjmid = int.Parse(reader["fjmid"].ToString());
                }
                if (reader["email"] != null && reader["email"].ToString() != "")
                {
                    model.email = reader["email"].ToString();
                }
                if (reader["phone"] != null && reader["phone"].ToString() != "")
                {
                    model.phone = reader["phone"].ToString();
                }
                if (reader["fax"] != null && reader["fax"].ToString() != "")
                {
                    model.fax = reader["fax"].ToString();
                }
                if (reader["mphone"] != null && reader["mphone"].ToString() != "")
                {
                    model.mphone = reader["mphone"].ToString();
                }
                if (reader["zip"] != null && reader["zip"].ToString() != "")
                {
                    model.zip = reader["zip"].ToString();
                }
                if (reader["areacode"] != null && reader["areacode"].ToString() != "")
                {
                    model.areacode = reader["areacode"].ToString();
                }
                if (reader["address"] != null && reader["address"].ToString() != "")
                {
                    model.address = reader["address"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["totlepromoney"] != null && reader["totlepromoney"].ToString() != "")
                {
                    model.totlepromoney = decimal.Parse(reader["totlepromoney"].ToString());
                }
                if (reader["totalmoney"] != null && reader["totalmoney"].ToString() != "")
                {
                    model.totalmoney = decimal.Parse(reader["totalmoney"].ToString());
                }
                if (reader["invoicemoney"] != null && reader["invoicemoney"].ToString() != "")
                {
                    model.invoicemoney = decimal.Parse(reader["invoicemoney"].ToString());
                }
                if (reader["installationmeney"] != null && reader["installationmeney"].ToString() != "")
                {
                    model.installationmeney = decimal.Parse(reader["installationmeney"].ToString());
                }
                if (reader["status"] != null && reader["status"].ToString() != "")
                {
                    model.status = int.Parse(reader["status"].ToString());
                }
                if (reader["createtime"] != null && reader["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(reader["createtime"].ToString());
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
        public static List<EnGroupOrder> GetGroupOrderList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnGroupOrder> modelList = new List<EnGroupOrder>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBGroupOrder, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnGroupOrder model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnGroupOrder();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["grouporderno"] != null && dt.Rows[n]["grouporderno"].ToString() != "")
                    {
                        model.grouporderno = dt.Rows[n]["grouporderno"].ToString();
                    }
                    if (dt.Rows[n]["mid"] != null && dt.Rows[n]["mid"].ToString() != "")
                    {
                        model.mid = int.Parse(dt.Rows[n]["mid"].ToString());
                    }
                    if (dt.Rows[n]["fjmid"] != null && dt.Rows[n]["fjmid"].ToString() != "")
                    {
                        model.fjmid = int.Parse(dt.Rows[n]["fjmid"].ToString());
                    }
                    if (dt.Rows[n]["name"] != null && dt.Rows[n]["name"].ToString() != "")
                    {
                        model.name = dt.Rows[n]["name"].ToString();
                    }
                    if (dt.Rows[n]["email"] != null && dt.Rows[n]["email"].ToString() != "")
                    {
                        model.email = dt.Rows[n]["email"].ToString();
                    }
                    if (dt.Rows[n]["phone"] != null && dt.Rows[n]["phone"].ToString() != "")
                    {
                        model.phone = dt.Rows[n]["phone"].ToString();
                    }
                    if (dt.Rows[n]["fax"] != null && dt.Rows[n]["fax"].ToString() != "")
                    {
                        model.fax = dt.Rows[n]["fax"].ToString();
                    }
                    if (dt.Rows[n]["mphone"] != null && dt.Rows[n]["mphone"].ToString() != "")
                    {
                        model.mphone = dt.Rows[n]["mphone"].ToString();
                    }
                    if (dt.Rows[n]["zip"] != null && dt.Rows[n]["zip"].ToString() != "")
                    {
                        model.zip = dt.Rows[n]["zip"].ToString();
                    }
                    if (dt.Rows[n]["areacode"] != null && dt.Rows[n]["areacode"].ToString() != "")
                    {
                        model.areacode = dt.Rows[n]["areacode"].ToString();
                    }
                    if (dt.Rows[n]["address"] != null && dt.Rows[n]["address"].ToString() != "")
                    {
                        model.address = dt.Rows[n]["address"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["totlepromoney"] != null && dt.Rows[n]["totlepromoney"].ToString() != "")
                    {
                        model.totlepromoney = decimal.Parse(dt.Rows[n]["totlepromoney"].ToString());
                    }
                    if (dt.Rows[n]["totalmoney"] != null && dt.Rows[n]["totalmoney"].ToString() != "")
                    {
                        model.totalmoney = decimal.Parse(dt.Rows[n]["totalmoney"].ToString());
                    }
                    if (dt.Rows[n]["invoicemoney"] != null && dt.Rows[n]["invoicemoney"].ToString() != "")
                    {
                        model.invoicemoney = decimal.Parse(dt.Rows[n]["invoicemoney"].ToString());
                    }
                    if (dt.Rows[n]["installationmeney"] != null && dt.Rows[n]["installationmeney"].ToString() != "")
                    {
                        model.installationmeney = decimal.Parse(dt.Rows[n]["installationmeney"].ToString());
                    }
                    if (dt.Rows[n]["status"] != null && dt.Rows[n]["status"].ToString() != "")
                    {
                        model.status = int.Parse(dt.Rows[n]["status"].ToString());
                    }
                    if (dt.Rows[n]["createtime"] != null && dt.Rows[n]["createtime"].ToString() != "")
                    {
                        model.createtime = DateTime.Parse(dt.Rows[n]["createtime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

        #region  grouporderpay
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditGroupOrderPay(EnGroupOrderPay model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_grouporderpay(");
                strSql.Append("grouporderid,grouporderno,paycode,paytype,paymoney,descript,paystatus,paydatetime)");
                strSql.Append(" values (");
                strSql.Append("@grouporderid,@grouporderno,@paycode,@paytype,@paymoney,@descript,@paystatus,@paydatetime)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@grouporderid", SqlDbType.Int,4),
					new SqlParameter("@grouporderno", SqlDbType.VarChar,20),
					new SqlParameter("@paycode", SqlDbType.VarChar,20),
					new SqlParameter("@paytype", SqlDbType.Int,4),
					new SqlParameter("@paymoney", SqlDbType.Decimal,9),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@paystatus", SqlDbType.Int,4),
					new SqlParameter("@paydatetime", SqlDbType.DateTime)};
                parameters[0].Value = model.grouporderid;
                parameters[1].Value = model.grouporderno;
                parameters[2].Value = model.paycode;
                parameters[3].Value = model.paytype;
                parameters[4].Value = model.paymoney;
                parameters[5].Value = model.descript;
                parameters[6].Value = model.paystatus;
                parameters[7].Value = model.paydatetime;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_grouporderpay set ");
                strSql.Append("grouporderid=@grouporderid,");
                strSql.Append("grouporderno=@grouporderno,");
                strSql.Append("paycode=@paycode,");
                strSql.Append("paytype=@paytype,");
                strSql.Append("paymoney=@paymoney,");
                strSql.Append("descript=@descript,");
                strSql.Append("paystatus=@paystatus,");
                strSql.Append("paydatetime=@paydatetime");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@grouporderid", SqlDbType.Int,4),
					new SqlParameter("@grouporderno", SqlDbType.VarChar,20),
					new SqlParameter("@paycode", SqlDbType.VarChar,20),
					new SqlParameter("@paytype", SqlDbType.Int,4),
					new SqlParameter("@paymoney", SqlDbType.Decimal,9),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@paystatus", SqlDbType.Int,4),
					new SqlParameter("@paydatetime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.grouporderid;
                parameters[1].Value = model.grouporderno;
                parameters[2].Value = model.paycode;
                parameters[3].Value = model.paytype;
                parameters[4].Value = model.paymoney;
                parameters[5].Value = model.descript;
                parameters[6].Value = model.paystatus;
                parameters[7].Value = model.paydatetime;
                parameters[8].Value = model.id;

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
        public static EnGroupOrderPay GetGroupOrderPayInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_grouporderpay ");
            strSql.Append(strWhere);


            EnGroupOrderPay model = new EnGroupOrderPay();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["grouporderid"] != null && reader["grouporderid"].ToString() != "")
                {
                    model.grouporderid = int.Parse(reader["grouporderid"].ToString());
                }
                if (reader["grouporderno"] != null && reader["grouporderno"].ToString() != "")
                {
                    model.grouporderno = reader["grouporderno"].ToString();
                }
                if (reader["paycode"] != null && reader["paycode"].ToString() != "")
                {
                    model.paycode = reader["paycode"].ToString();
                }
                if (reader["paytype"] != null && reader["paytype"].ToString() != "")
                {
                    model.paytype = int.Parse(reader["paytype"].ToString());
                }
                if (reader["paymoney"] != null && reader["paymoney"].ToString() != "")
                {
                    model.paymoney = decimal.Parse(reader["paymoney"].ToString());
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["paystatus"] != null && reader["paystatus"].ToString() != "")
                {
                    model.paystatus = int.Parse(reader["paystatus"].ToString());
                }
                if (reader["paydatetime"] != null && reader["paydatetime"].ToString() != "")
                {
                    model.paydatetime = DateTime.Parse(reader["paydatetime"].ToString());
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
        public static List<EnGroupOrderPay> GetGroupOrderPayList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnGroupOrderPay> modelList = new List<EnGroupOrderPay>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBGroupOrderPay, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnGroupOrderPay model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnGroupOrderPay();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["grouporderid"] != null && dt.Rows[n]["grouporderid"].ToString() != "")
                    {
                        model.grouporderid = int.Parse(dt.Rows[n]["grouporderid"].ToString());
                    }
                    if (dt.Rows[n]["grouporderno"] != null && dt.Rows[n]["grouporderno"].ToString() != "")
                    {
                        model.grouporderno = dt.Rows[n]["grouporderno"].ToString();
                    }
                    if (dt.Rows[n]["paycode"] != null && dt.Rows[n]["paycode"].ToString() != "")
                    {
                        model.paycode = dt.Rows[n]["paycode"].ToString();
                    }
                    if (dt.Rows[n]["paytype"] != null && dt.Rows[n]["paytype"].ToString() != "")
                    {
                        model.paytype = int.Parse(dt.Rows[n]["paytype"].ToString());
                    }
                    if (dt.Rows[n]["paymoney"] != null && dt.Rows[n]["paymoney"].ToString() != "")
                    {
                        model.paymoney = decimal.Parse(dt.Rows[n]["paymoney"].ToString());
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["paystatus"] != null && dt.Rows[n]["paystatus"].ToString() != "")
                    {
                        model.paystatus = int.Parse(dt.Rows[n]["paystatus"].ToString());
                    }
                    if (dt.Rows[n]["paydatetime"] != null && dt.Rows[n]["paydatetime"].ToString() != "")
                    {
                        model.paydatetime = DateTime.Parse(dt.Rows[n]["paydatetime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

        #region grouporderproduct
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditGroupOrderProduct(EnGroupOrderProduct model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_grouporderproduct(");
                strSql.Append("grouporderid,grouporderno,promotionid,promotiondefid,promoteionstageid,promoteionstagevalue,productid,productattributeid,productcode,productname,color,material,size,cbm,num,price,totalmoney,proprice,prototalmoney)");
                strSql.Append(" values (");
                strSql.Append("@grouporderid,@grouporderno,@promotionid,@promotiondefid,@promoteionstageid,@promoteionstagevalue,@productid,@productattributeid,@productcode,@productname,@color,@material,@size,@cbm,@num,@price,@totalmoney,@proprice,@prototalmoney)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@grouporderid", SqlDbType.Int,4),
					new SqlParameter("@grouporderno", SqlDbType.VarChar,20),
					new SqlParameter("@promotionid", SqlDbType.Int,4),
					new SqlParameter("@promotiondefid", SqlDbType.Int,4),
					new SqlParameter("@promoteionstageid", SqlDbType.Int,4),
					new SqlParameter("@promoteionstagevalue", SqlDbType.VarChar,20),
					new SqlParameter("@productid", SqlDbType.Int,4),
					new SqlParameter("@productattributeid", SqlDbType.Int,4),
					new SqlParameter("@productcode", SqlDbType.VarChar,20),
					new SqlParameter("@productname", SqlDbType.NVarChar,50),
					new SqlParameter("@color", SqlDbType.NVarChar,50),
					new SqlParameter("@material", SqlDbType.NVarChar,50),
					new SqlParameter("@size", SqlDbType.NVarChar,50),
					new SqlParameter("@cbm", SqlDbType.Decimal,9),
					new SqlParameter("@num", SqlDbType.Decimal,9),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@totalmoney", SqlDbType.Decimal,9),
					new SqlParameter("@proprice", SqlDbType.Decimal,9),
					new SqlParameter("@prototalmoney", SqlDbType.Decimal,9)};
                parameters[0].Value = model.grouporderid;
                parameters[1].Value = model.grouporderno;
                parameters[2].Value = model.promotionid;
                parameters[3].Value = model.promotiondefid;
                parameters[4].Value = model.promoteionstageid;
                parameters[5].Value = model.promoteionstagevalue;
                parameters[6].Value = model.productid;
                parameters[7].Value = model.productattributeid;
                parameters[8].Value = model.productcode;
                parameters[9].Value = model.productname;
                parameters[10].Value = model.color;
                parameters[11].Value = model.material;
                parameters[12].Value = model.size;
                parameters[13].Value = model.cbm;
                parameters[14].Value = model.num;
                parameters[15].Value = model.price;
                parameters[16].Value = model.totalmoney;
                parameters[17].Value = model.proprice;
                parameters[18].Value = model.prototalmoney;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_grouporderproduct set ");
                strSql.Append("grouporderid=@grouporderid,");
                strSql.Append("grouporderno=@grouporderno,");
                strSql.Append("promotionid=@promotionid,");
                strSql.Append("promotiondefid=@promotiondefid,");
                strSql.Append("promoteionstageid=@promoteionstageid,");
                strSql.Append("promoteionstagevalue=@promoteionstagevalue,");
                strSql.Append("productid=@productid,");
                strSql.Append("productattributeid=@productattributeid,");
                strSql.Append("productcode=@productcode,");
                strSql.Append("productname=@productname,");
                strSql.Append("color=@color,");
                strSql.Append("material=@material,");
                strSql.Append("size=@size,");
                strSql.Append("cbm=@cbm,");
                strSql.Append("num=@num,");
                strSql.Append("price=@price,");
                strSql.Append("totalmoney=@totalmoney,");
                strSql.Append("proprice=@proprice,");
                strSql.Append("prototalmoney=@prototalmoney");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@grouporderid", SqlDbType.Int,4),
					new SqlParameter("@grouporderno", SqlDbType.VarChar,20),
					new SqlParameter("@promotionid", SqlDbType.Int,4),
					new SqlParameter("@promotiondefid", SqlDbType.Int,4),
					new SqlParameter("@promoteionstageid", SqlDbType.Int,4),
					new SqlParameter("@promoteionstagevalue", SqlDbType.VarChar,20),
					new SqlParameter("@productid", SqlDbType.Int,4),
					new SqlParameter("@productattributeid", SqlDbType.Int,4),
					new SqlParameter("@productcode", SqlDbType.VarChar,20),
					new SqlParameter("@productname", SqlDbType.NVarChar,50),
					new SqlParameter("@color", SqlDbType.NVarChar,50),
					new SqlParameter("@material", SqlDbType.NVarChar,50),
					new SqlParameter("@size", SqlDbType.NVarChar,50),
					new SqlParameter("@cbm", SqlDbType.Decimal,9),
					new SqlParameter("@num", SqlDbType.Decimal,9),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@totalmoney", SqlDbType.Decimal,9),
					new SqlParameter("@proprice", SqlDbType.Decimal,9),
					new SqlParameter("@prototalmoney", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.grouporderid;
                parameters[1].Value = model.grouporderno;
                parameters[2].Value = model.promotionid;
                parameters[3].Value = model.promotiondefid;
                parameters[4].Value = model.promoteionstageid;
                parameters[5].Value = model.promoteionstagevalue;
                parameters[6].Value = model.productid;
                parameters[7].Value = model.productattributeid;
                parameters[8].Value = model.productcode;
                parameters[9].Value = model.productname;
                parameters[10].Value = model.color;
                parameters[11].Value = model.material;
                parameters[12].Value = model.size;
                parameters[13].Value = model.cbm;
                parameters[14].Value = model.num;
                parameters[15].Value = model.price;
                parameters[16].Value = model.totalmoney;
                parameters[17].Value = model.proprice;
                parameters[18].Value = model.prototalmoney;
                parameters[19].Value = model.id;

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
        public static EnGroupOrderProduct GetGroupOrderProductInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_GroupOrderProduct ");
            strSql.Append(strWhere);


            EnGroupOrderProduct model = new EnGroupOrderProduct();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["grouporderid"] != null && reader["grouporderid"].ToString() != "")
                {
                    model.grouporderid = int.Parse(reader["grouporderid"].ToString());
                }
                if (reader["grouporderno"] != null && reader["grouporderno"].ToString() != "")
                {
                    model.grouporderno = reader["grouporderno"].ToString();
                }
                if (reader["promotionid"] != null && reader["promotionid"].ToString() != "")
                {
                    model.promotionid = int.Parse(reader["promotionid"].ToString());
                }
                if (reader["promotiondefid"] != null && reader["promotiondefid"].ToString() != "")
                {
                    model.promotiondefid = int.Parse(reader["promotiondefid"].ToString());
                }
                if (reader["promoteionstageid"] != null && reader["promoteionstageid"].ToString() != "")
                {
                    model.promoteionstageid = int.Parse(reader["promoteionstageid"].ToString());
                }
                if (reader["promoteionstagevalue"] != null && reader["promoteionstagevalue"].ToString() != "")
                {
                    model.promoteionstagevalue = reader["promoteionstagevalue"].ToString();
                }
                if (reader["productid"] != null && reader["productid"].ToString() != "")
                {
                    model.productid = int.Parse(reader["productid"].ToString());
                }
                if (reader["productattributeid"] != null && reader["productattributeid"].ToString() != "")
                {
                    model.productattributeid = int.Parse(reader["productattributeid"].ToString());
                }
                if (reader["productcode"] != null && reader["productcode"].ToString() != "")
                {
                    model.productcode = reader["productcode"].ToString();
                }
                if (reader["productname"] != null && reader["productname"].ToString() != "")
                {
                    model.productname = reader["productname"].ToString();
                }
                if (reader["color"] != null && reader["color"].ToString() != "")
                {
                    model.color = reader["color"].ToString();
                }
                if (reader["material"] != null && reader["material"].ToString() != "")
                {
                    model.material = reader["material"].ToString();
                }
                if (reader["size"] != null && reader["size"].ToString() != "")
                {
                    model.size = reader["size"].ToString();
                }
                if (reader["cbm"] != null && reader["cbm"].ToString() != "")
                {
                    model.cbm = decimal.Parse(reader["cbm"].ToString());
                }
                if (reader["num"] != null && reader["num"].ToString() != "")
                {
                    model.num = int.Parse(reader["num"].ToString());
                }
                if (reader["price"] != null && reader["price"].ToString() != "")
                {
                    model.price = decimal.Parse(reader["price"].ToString());
                }
                if (reader["totalmoney"] != null && reader["totalmoney"].ToString() != "")
                {
                    model.totalmoney = decimal.Parse(reader["totalmoney"].ToString());
                }
                if (reader["proprice"] != null && reader["proprice"].ToString() != "")
                {
                    model.proprice = decimal.Parse(reader["proprice"].ToString());
                }
                if (reader["prototalmoney"] != null && reader["prototalmoney"].ToString() != "")
                {
                    model.prototalmoney = decimal.Parse(reader["prototalmoney"].ToString());
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
        public static List<EnGroupOrderProduct> GetGroupOrderProductList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnGroupOrderProduct> modelList = new List<EnGroupOrderProduct>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBGroupOrderProduct, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnGroupOrderProduct model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnGroupOrderProduct();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["grouporderid"] != null && dt.Rows[n]["grouporderid"].ToString() != "")
                    {
                        model.grouporderid = int.Parse(dt.Rows[n]["grouporderid"].ToString());
                    }
                    if (dt.Rows[n]["grouporderno"] != null && dt.Rows[n]["grouporderno"].ToString() != "")
                    {
                        model.grouporderno = dt.Rows[n]["grouporderno"].ToString();
                    }
                    if (dt.Rows[n]["promotionid"] != null && dt.Rows[n]["promotionid"].ToString() != "")
                    {
                        model.promotionid = int.Parse(dt.Rows[n]["promotionid"].ToString());
                    }
                    if (dt.Rows[n]["promotiondefid"] != null && dt.Rows[n]["promotiondefid"].ToString() != "")
                    {
                        model.promotiondefid = int.Parse(dt.Rows[n]["promotiondefid"].ToString());
                    }
                    if (dt.Rows[n]["promoteionstageid"] != null && dt.Rows[n]["promoteionstageid"].ToString() != "")
                    {
                        model.promoteionstageid = int.Parse(dt.Rows[n]["promoteionstageid"].ToString());
                    }
                    if (dt.Rows[n]["promoteionstagevalue"] != null && dt.Rows[n]["promoteionstagevalue"].ToString() != "")
                    {
                        model.promoteionstagevalue = dt.Rows[n]["promoteionstagevalue"].ToString();
                    }
                    if (dt.Rows[n]["productid"] != null && dt.Rows[n]["productid"].ToString() != "")
                    {
                        model.productid = int.Parse(dt.Rows[n]["productid"].ToString());
                    }
                    if (dt.Rows[n]["productattributeid"] != null && dt.Rows[n]["productattributeid"].ToString() != "")
                    {
                        model.productattributeid = int.Parse(dt.Rows[n]["productattributeid"].ToString());
                    }
                    if (dt.Rows[n]["productcode"] != null && dt.Rows[n]["productcode"].ToString() != "")
                    {
                        model.productcode = dt.Rows[n]["productcode"].ToString();
                    }
                    if (dt.Rows[n]["productname"] != null && dt.Rows[n]["productname"].ToString() != "")
                    {
                        model.productname = dt.Rows[n]["productname"].ToString();
                    }
                    if (dt.Rows[n]["color"] != null && dt.Rows[n]["color"].ToString() != "")
                    {
                        model.color = dt.Rows[n]["color"].ToString();
                    }
                    if (dt.Rows[n]["material"] != null && dt.Rows[n]["material"].ToString() != "")
                    {
                        model.material = dt.Rows[n]["material"].ToString();
                    }
                    if (dt.Rows[n]["size"] != null && dt.Rows[n]["size"].ToString() != "")
                    {
                        model.size = dt.Rows[n]["size"].ToString();
                    }
                    if (dt.Rows[n]["cbm"] != null && dt.Rows[n]["cbm"].ToString() != "")
                    {
                        model.cbm = decimal.Parse(dt.Rows[n]["cbm"].ToString());
                    }
                    if (dt.Rows[n]["num"] != null && dt.Rows[n]["num"].ToString() != "")
                    {
                        model.num = int.Parse(dt.Rows[n]["num"].ToString());
                    }
                    if (dt.Rows[n]["price"] != null && dt.Rows[n]["price"].ToString() != "")
                    {
                        model.price = decimal.Parse(dt.Rows[n]["price"].ToString());
                    }
                    if (dt.Rows[n]["totalmoney"] != null && dt.Rows[n]["totalmoney"].ToString() != "")
                    {
                        model.totalmoney = decimal.Parse(dt.Rows[n]["totalmoney"].ToString());
                    }
                    if (dt.Rows[n]["proprice"] != null && dt.Rows[n]["proprice"].ToString() != "")
                    {
                        model.proprice = decimal.Parse(dt.Rows[n]["proprice"].ToString());
                    }
                    if (dt.Rows[n]["prototalmoney"] != null && dt.Rows[n]["prototalmoney"].ToString() != "")
                    {
                        model.prototalmoney = decimal.Parse(dt.Rows[n]["prototalmoney"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion
    }
}
