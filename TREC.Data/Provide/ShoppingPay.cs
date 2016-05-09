using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TREC.Data.Provide
{
    /// <summary>
    /// 用户购物操作
    /// </summary>
   public class ShoppingPay
   {
       #region 加入购物车
       /// <summary>
       /// 加入购物车
       /// </summary>
       /// <param name="CustomerUserId"></param>
       /// <param name="productattributeId"></param>
       public static void AddShoppingTrolley(int CustomerUserId, int productattributeId)
       {
     
           string sql = @"DECLARE @c INT
                    SELECT @c=COUNT(1) FROM shoppingTrolley WHERE CustomerUserId=@CustomerUserId AND  productattributeId=@productattributeId and (OrderNumber is null or OrderNumber='') 
                    IF(@c=0)
                    BEGIN
	                INSERT INTO shoppingTrolley(CustomerUserId,productattributeId,ProCount) VALUES(@CustomerUserId,@productattributeId,1)
                    end
                    else
                    begin
                        update shoppingTrolley set ProCount=ProCount+1 where  CustomerUserId=@CustomerUserId and productattributeId=@productattributeId
                     end
                    ";
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerUserId", SqlDbType.Int),
					new SqlParameter("@productattributeId", SqlDbType.Int)
                                        };

            parameters[0].Value = CustomerUserId;
            parameters[1].Value = productattributeId;

            DbHelper.ExecuteNonQuery(CommandType.Text, sql, parameters);
       }
       #endregion


       #region 购物车展示
       /// <summary>
       /// 购物车展示
       /// </summary>
       /// <param name="CustomerUserId"></param>
       /// <returns></returns>
       public static DataTable ShoppingTrolleyList(int CustomerUserId)
       {
           StringBuilder _sql = new StringBuilder("SELECT s.id AS sid,[dbo].[F_PayPrice](tpb.id) as resultPrice,tpb.id AS proinforid, s.ProCount,tp.id AS proid,tp.title,tp.thumb, tpb.productmaterial,");
           _sql.Append("CONVERT(NVARCHAR(20),tpb.productlength)+'*' +CONVERT(NVARCHAR(20),tpb.productwidth)+'*' +CONVERT(NVARCHAR(20),tpb.productheight) AS big, ");
           _sql.Append(" tpb.productcolortitle, ");
           _sql.Append(" tpb.buyprice, tpb.markprice,tpb.saleprice, ");
           _sql.Append(" CAST((tpb.productlength*tpb.productwidth*tpb.productheight)as decimal(38, 10))/1000000000   AS Volume ,");
           _sql.Append(" tpb.saleprice*ProCount as xiaoji ");
           _sql.Append(" FROM  shoppingTrolley s ");
           _sql.Append("LEFT JOIN t_productattribute tpb ON s.productattributeId =tpb.id ");
           _sql.Append(" LEFT JOIN  t_product tp on tp.id=tpb.productid ");
           _sql.Append(" WHERE s.CustomerUserId=@CustomerUserId and (s.OrderNumber is null or s.OrderNumber='') and [dbo].[F_PayPrice](tpb.id)>0 ORDER BY s.id desc ");

           SqlParameter[] parameters = {
					new SqlParameter("@CustomerUserId", SqlDbType.Int)
                                        };

           parameters[0].Value = CustomerUserId;
          return  DbHelper.ExecuteDataset(CommandType.Text, _sql.ToString(), parameters).Tables[0];
       }


       public static DataTable ShoppingTrolleyList(int CustomerUserId,string ordernumber)
       {
           StringBuilder _sql = new StringBuilder("SELECT s.id AS sid,[dbo].[F_PayPrice](tpb.id) as resultPrice,tpb.id AS proinforid, s.ProCount,tp.id AS proid,tp.title,tp.thumb, tpb.productmaterial,");
           _sql.Append("(CASE WHEN tpb.buyprice>0 THEN tpb.buyprice WHEN tpb.saleprice>0 THEN tpb.saleprice WHEN tpb.markprice>0 THEN tpb.markprice ELSE 0 END) as showpay,");
           _sql.Append("CONVERT(NVARCHAR(20),tpb.productlength)+'*' +CONVERT(NVARCHAR(20),tpb.productwidth)+'*' +CONVERT(NVARCHAR(20),tpb.productheight) AS big, ");
           _sql.Append(" tpb.productcolortitle, ");
           _sql.Append(" tpb.buyprice, tpb.markprice,tpb.saleprice, ");
           _sql.Append(" CAST((tpb.productlength*tpb.productwidth*tpb.productheight)as decimal(38, 10))/1000000000   AS Volume ,");
           _sql.Append(" tpb.saleprice*ProCount as xiaoji ");
           _sql.Append(" FROM  shoppingTrolley s ");
           _sql.Append("LEFT JOIN t_productattribute tpb ON s.productattributeId =tpb.id ");
           _sql.Append(" LEFT JOIN  t_product tp on tp.id=tpb.productid ");
           _sql.Append(" WHERE s.CustomerUserId=@CustomerUserId and s.ordernumber='" + ordernumber + "' and [dbo].[F_PayPrice](tpb.id)>0 ORDER BY s.id desc ");

           SqlParameter[] parameters = {
					new SqlParameter("@CustomerUserId", SqlDbType.Int)
                                        };

           parameters[0].Value = CustomerUserId;
           return DbHelper.ExecuteDataset(CommandType.Text, _sql.ToString(), parameters).Tables[0];
       }


       public static DataTable ShoppingTrolleyList(int CustomerUserId, string ordernumber, string createmid)
       {
           StringBuilder _sql = new StringBuilder("SELECT s.id AS sid,ord.PayPrice as resultPrice,tpb.id AS proinforid, s.ProCount,tp.id AS proid,tp.title,tp.thumb, tpb.productmaterial,tpb.productsku,");
           _sql.Append("(CASE WHEN tpb.buyprice>0 THEN tpb.buyprice WHEN tpb.saleprice>0 THEN tpb.saleprice WHEN tpb.markprice>0 THEN tpb.markprice ELSE 0 END) as showpay,");
           _sql.Append("CONVERT(NVARCHAR(20),tpb.productlength)+'*' +CONVERT(NVARCHAR(20),tpb.productwidth)+'*' +CONVERT(NVARCHAR(20),tpb.productheight) AS big, ");
           _sql.Append(" tpb.productcolortitle, ");
           _sql.Append(" tpb.buyprice, tpb.markprice,tpb.saleprice, ");
           _sql.Append(" CAST((tpb.productlength*tpb.productwidth*tpb.productheight)as decimal(38, 10))/1000000000   AS Volume ,");
           _sql.Append(" tpb.saleprice*ProCount as xiaoji ");
           _sql.Append(" FROM  shoppingTrolley s ");
           _sql.Append("LEFT JOIN t_productattribute tpb ON s.productattributeId =tpb.id ");
           _sql.Append(" LEFT JOIN  t_product tp on tp.id=tpb.productid ");
           _sql.Append(" LEFT JOIN OrderInfor ORd ON ord.productattributeId= s.productattributeId ");
           _sql.Append(" WHERE s.CustomerUserId=@CustomerUserId and s.ordernumber='" + ordernumber + "' and tp.createmid=" + createmid + "  ORDER BY s.id desc ");

           SqlParameter[] parameters = {
					new SqlParameter("@CustomerUserId", SqlDbType.Int)
                                        };

           parameters[0].Value = CustomerUserId;
           return DbHelper.ExecuteDataset(CommandType.Text, _sql.ToString(), parameters).Tables[0];
       }

       #endregion

       #region 删除购物车
       /// <summary>
       /// 删除购物车
       /// </summary>
       public static bool DelShoppingTrolley(string ids,int CustomerUserId)
       {
           try
           {
               string sql = "DELETE FROM shoppingTrolley WHERE customerUserId=@CustomerUserId and id IN(" + ids + ")";

               SqlParameter[] parameters = {
					new SqlParameter("@CustomerUserId", SqlDbType.Int)
                                        };
               parameters[0].Value = CustomerUserId;
              

               DbHelper.ExecuteNonQuery(CommandType.Text, sql, parameters);
               return true;
           }
           catch
           {
               return false;
           }
       }
       #endregion

       /// <summary>
       /// 获取地区
       /// </summary>
       /// <param name="parentcode"></param>
       /// <returns></returns>
       public static DataTable GetArea(string parentcode)
       {

           string sql = "SELECT * FROM t_area WHERE parentcode=@parentcode";

           SqlParameter[] parameters = {
					new SqlParameter("@parentcode", SqlDbType.NVarChar,20)
                                        };
           parameters[0].Value = parentcode;

           return DbHelper.ExecuteDataset(CommandType.Text, sql, parameters).Tables[0];
       }

       /// <summary>
       /// 定购流程
       /// </summary>
       /// <param name="Ids"></param>
       /// <param name="CustomerUserId"></param>
       /// <returns></returns>
       public static DataSet ShoppingOrder(string Ids, int CustomerUserId)
       {
         //  string sql = "EXEC sp_order @Ids,@CustomerUserId";

           SqlParameter[] parameters = {
					new SqlParameter("@Ids", SqlDbType.NVarChar,1000),
					new SqlParameter("@CustomerUserId", SqlDbType.Int)
                                        };
           parameters[0].Value = Ids;
           parameters[1].Value = CustomerUserId;

           return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_order", parameters);
       }
       /// <summary>
       /// 获取定单列表数据
       /// </summary>
       /// <param name="pageindex"></param>
       /// <param name="where"></param>
       /// <returns></returns>
       public static DataSet GetOrderList(string pageindex,string where)
       {
           SqlParameter[] parameters = {
					new SqlParameter("@pageIndex ", SqlDbType.Int),
					new SqlParameter("@pagesize", SqlDbType.Int),
                    new SqlParameter("@condiction", SqlDbType.NVarChar,300),
                    new SqlParameter("@table", SqlDbType.NVarChar,100)
                                        };
           parameters[0].Value = pageindex;
           parameters[1].Value = 10;
           parameters[2].Value = where;
           parameters[3].Value = "OrderList";

           return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_TablePage", parameters);
       }
       /// <summary>
       /// 品牌厂商定单查询
       /// </summary>
       /// <param name="PageIndex"></param>
       /// <param name="result"></param>
       /// <param name="Deliverystatus"></param>
       /// <param name="companyid"></param>
       /// <param name="OrderDel"></param>
       /// <returns></returns>
       public static DataSet getCompanyOrderList(int PageIndex, int result, int Deliverystatus, int companyid, int OrderDel)
       {
           SqlParameter[] parameters = {
					new SqlParameter("@pageIndex ", SqlDbType.Int),
					new SqlParameter("@result", SqlDbType.Int),
                    new SqlParameter("@Deliverystatus", SqlDbType.Int),
                    new SqlParameter("@createmid", SqlDbType.Int),
                     new SqlParameter("@OrderDel", SqlDbType.Int)
                                        };

           parameters[0].Value = PageIndex;
           parameters[1].Value = result;
           parameters[2].Value = Deliverystatus;
           parameters[3].Value = companyid;
           parameters[4].Value = OrderDel;
           return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_compary_orderlist", parameters);
       }
       /// <summary>
       /// 未阅读记录数
       /// </summary>
       /// <param name="companyId"></param>
       /// <returns></returns>
       public static DataSet getCompanyNoRead(string companyId)
       {
           StringBuilder _sql = new StringBuilder("SELECT count(ordernumber) AS c FROM( ");
           _sql.Append(" SELECT distinct o.ordernumber   FROM OrderInfor o LEFT JOIN t_productattribute t ON o.productattributeid=t.id  ");
           _sql.Append(" LEFT JOIN t_product p ON t.productid=p.id  WHERE  p.createmid=" + companyId + "  AND o.ordernumber NOT IN (SELECT OrderNumber FROM  OrderListMemberRead WHERE MemberId=" + companyId + ") ");
           _sql.Append(" ) bb ");

           _sql.Append("  SELECT distinct o.ordernumber   FROM OrderInfor o LEFT JOIN t_productattribute t ON o.productattributeid=t.id  ");
           _sql.Append("   LEFT JOIN t_product p ON t.productid=p.id  WHERE  p.createmid=" + companyId + "  AND o.ordernumber NOT IN  ");
           _sql.Append("   (SELECT OrderNumber FROM  OrderListMemberRead WHERE MemberId=" + companyId + ")   ");

           return DbHelper.ExecuteDataset(_sql.ToString());
       }
       
       /// <summary>
       /// 购物车数量
       /// </summary>
       /// <param name="CustomerUserId"></param>
       /// <returns></returns>
       public static string shoppingCount(string CustomerUserId)
       {
           string sql = "SELECT sum(procount) AS c FROM shoppingTrolley WHERE CustomerUserId=" + CustomerUserId + " and  (OrderNumber is null or OrderNumber='') ";
         return  DbHelper.ExecuteDataset(sql).Tables[0].Rows[0][0].ToString();

       }
       /// <summary>
       /// 生成定单
       /// </summary>
       /// <param name="ids"></param>
       /// <param name="ordernumber"></param>
       /// <param name="CustomerUserId"></param>
       /// <param name="AddressId"></param>
       /// <param name="Freight"></param>
       /// <param name="InstallationFee"></param>
       /// <param name="TransportMeth"></param>
       /// <param name="InvoiceClaim"></param>
       /// <param name="InvoiceTop"></param>
       /// <param name="InvoiceAddress"></param>
       /// <param name="InvoiceZipcode"></param>
       /// <param name="Description"></param>
       /// <returns></returns>
       public static DataTable CreateOrderNumber(string ids, string ordernumber, int CustomerUserId, int AddressId, 
           double Freight, double InstallationFee, int TransportMeth, int InvoiceClaim, string InvoiceTop, string InvoiceAddress,
           string InvoiceZipcode, string Description)
       {
           SqlParameter[] parameters = {
					new SqlParameter("@Ids", SqlDbType.NVarChar,1000),
					new SqlParameter("@ordernumber", SqlDbType.NVarChar,100),
                    new SqlParameter("@CustomerUserId", SqlDbType.Int),
                    new SqlParameter("@AddressId", SqlDbType.Int),
                    new SqlParameter("@Freight", SqlDbType.Float),
                    new SqlParameter("@InstallationFee", SqlDbType.Float),
                    new SqlParameter("@TransportMeth", SqlDbType.Int),
                    new SqlParameter("@InvoiceClaim", SqlDbType.Int),
                    new SqlParameter("@InvoiceTop", SqlDbType.NVarChar,100),
                    new SqlParameter("@InvoiceAddress", SqlDbType.NVarChar,200),
                    new SqlParameter("@InvoiceZipcode", SqlDbType.NVarChar,20),
                    new SqlParameter("@Description", SqlDbType.NVarChar,1000)
                                        };
           parameters[0].Value = ids;
           parameters[1].Value = ordernumber;
           parameters[2].Value = CustomerUserId;
           parameters[3].Value = AddressId;
           parameters[4].Value = Freight;
           parameters[5].Value = InstallationFee;
           parameters[6].Value = TransportMeth;
           parameters[7].Value = InvoiceClaim;
           parameters[8].Value = InvoiceTop;

           parameters[9].Value = InvoiceAddress;
           parameters[10].Value = InvoiceZipcode;
           parameters[11].Value = Description;
           return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_CreateOrderNumber", parameters).Tables[0];
       }
      
   }
}
