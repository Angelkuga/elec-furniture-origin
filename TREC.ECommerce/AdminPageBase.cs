using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections;
using TREC.Entity;

namespace TREC.ECommerce
{
    public class AdminPageBase : System.Web.UI.Page
    {
        public int tmpPageCount = 0;
        public int adminId = 0;
        public string adminName = "后台开发用户";

        public int thisPageModule = 0;
        public int thisOperateActionId = 0;



        public AdminPageBase()
        {
            if (TRECommon.CookiesHelper.GetCookie("aadmin") != TRECommon.MyMD5.GetMD5("admin"))
            {
                HttpContext.Current.Response.Redirect("login.aspx");
            }
        }

        /// <summary>
        /// 上下线数据
        /// </summary>
        /// <param name="alst">数据的条件ID</param>
        /// <param name="types">修改的类型（表）</param>
        /// <param name="_values">修改的值</param>
        /// <returns></returns>
        public static bool ModifyTable_auditstatus_linestatus(string alst, EnumModifyType types, bool _values, string wherefiles)
        {
            string values = "0,0";
            if (_values)
            {
                values = "1,1";
            }
            bool IsReturn = false;
            if (string.IsNullOrEmpty(wherefiles))
            {
                wherefiles = "id";
            }
            switch (types)
            {
                case EnumModifyType.company:
                    IsReturn = ECCompany.ModifyTable(TableName.TBCompany, values, "auditstatus,linestatus", " where " + wherefiles + " in(" + alst + ")") > 0;
                    break;
                case EnumModifyType.market:
                    IsReturn = ECCompany.ModifyTable(TableName.TBMarket, values, "auditstatus,linestatus", " where " + wherefiles + " in(" + alst + ")") > 0;
                    break;
                case EnumModifyType.product:
                    IsReturn = ECCompany.ModifyTable(TableName.TBProduct, values, "auditstatus,linestatus", " where " + wherefiles + " in(" + alst + ")") > 0;
                    break;
                case EnumModifyType.shop:
                    IsReturn = ECCompany.ModifyTable(TableName.TBShop, values, "auditstatus,linestatus", " where " + wherefiles + " in(" + alst + ")") > 0;
                    break;
                case EnumModifyType.brand:
                    IsReturn = ECCompany.ModifyTable(TableName.TBBrand, values, "auditstatus,linestatus", " where " + wherefiles + " in(" + alst + ")") > 0;
                    break;
                default:
                    break;
            }
            return IsReturn;

        }

        /// <summary>
        /// 上下线数据
        /// </summary>
        /// <param name="alst">数据的条件ID</param>
        /// <param name="types">修改的类型（表）</param>
        /// <param name="_values">修改的值</param>
        /// <returns></returns>
        public static bool ModifyTable_auditstatus_linestatus(ArrayList alst, EnumModifyType types, bool _values, string wherefiles)
        {
            string idlist = "";
            for (int i = 0; i < alst.Count; i++)
            {
                string id = alst[i].ToString();
                idlist += id + ",";
            }
            idlist = idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist;

            return ModifyTable_auditstatus_linestatus(idlist, types, _values, wherefiles);
        }

    }


    public enum EnumModifyType
    {
        company = 0,
        market = 1,
        product = 2,
        shop = 3,
        brand = 4,
    }
}
