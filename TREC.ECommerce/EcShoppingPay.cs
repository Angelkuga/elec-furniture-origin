using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Data.Provide;
using System.Data;
namespace TREC.ECommerce
{
    public class EcShoppingPay
    {
       
       
        /// <summary>
        /// 生成定单号
        /// </summary>
        public string OrderNumber
        {
            get
            {
                Random ran = new Random();
                int RandKey = ran.Next(100, 999);
                return DateTime.Now.ToString("yyyyMMddHHmmssfff") + RandKey;
            }
        }

        public static int getInt(string s)
        {
            int r = 0;
             Int32.TryParse(s, out r);
             return r;
        }

        public static double getDouble(string s)
        {
            double r = 0;
            double.TryParse(s, out r);
            return r;
        }
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="CustomerUserId"></param>
        /// <param name="productattributeId"></param>
        public static void AddShoppingTrolley(int CustomerUserId, int productattributeId)
        {
            ShoppingPay.AddShoppingTrolley(CustomerUserId, productattributeId);
        }
        /// <summary>
        /// 购物车展示
        /// </summary>
        /// <param name="CustomerUserId"></param>
        /// <returns></returns>
        public static DataTable ShoppingTrolleyList(int CustomerUserId)
        {
            return ShoppingPay.ShoppingTrolleyList(CustomerUserId);
        }

        /// <summary>
        /// 删除购物车
        /// </summary>
        public static bool DelShoppingTrolley(string ids, int CustomerUserId)
        {
            return ShoppingPay.DelShoppingTrolley(ids, CustomerUserId);
        }

        /// <summary>
        /// 获取地区
        /// </summary>
        /// <param name="parentcode"></param>
        /// <returns></returns>
        public static DataTable GetArea(string parentcode)
        {
            return ShoppingPay.GetArea(parentcode);
        }

         /// <summary>
       /// 获取定单列表数据
       /// </summary>
       /// <param name="pageindex"></param>
       /// <param name="where"></param>
       /// <returns></returns>
        public static DataSet GetOrderList(string pageindex, string where)
        {
            return ShoppingPay.GetOrderList(pageindex, where);
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
            return ShoppingPay.getCompanyOrderList(PageIndex, result, Deliverystatus, companyid, OrderDel);
        }

         /// <summary>
       /// 未阅读记录数
       /// </summary>
       /// <param name="companyId"></param>
       /// <returns></returns>
        public static DataSet getCompanyNoRead(string companyId)
        {
            return ShoppingPay.getCompanyNoRead(companyId);
        }
        /// <summary>
        /// 定购流程
        /// </summary>
        /// <param name="Ids"></param>
        /// <param name="CustomerUserId"></param>
        /// <returns></returns>
        public static DataSet ShoppingOrder(string Ids, int CustomerUserId)
        {
            return ShoppingPay.ShoppingOrder(Ids, CustomerUserId);
        }
        public static DataTable ShoppingTrolleyList(int CustomerUserId, string ordernumber)
        {
            return ShoppingPay.ShoppingTrolleyList(CustomerUserId,ordernumber);
        }
        public static DataTable ShoppingTrolleyList(int CustomerUserId, string ordernumber, string createmid)
        {
            return ShoppingPay.ShoppingTrolleyList(CustomerUserId, ordernumber, createmid);
        }
          /// <summary>
       /// 购物车数量
       /// </summary>
       /// <param name="CustomerUserId"></param>
       /// <returns></returns>
        public static string shoppingCount(string CustomerUserId)
        {
            return ShoppingPay.shoppingCount(CustomerUserId);
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
            return ShoppingPay.CreateOrderNumber(ids, ordernumber, CustomerUserId, AddressId, Freight, InstallationFee, TransportMeth, InvoiceClaim,
                                                InvoiceTop, InvoiceAddress, InvoiceZipcode, Description);
        }

    }
}
