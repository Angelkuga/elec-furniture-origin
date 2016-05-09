using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using System.Data;
using System.Text;
namespace TREC.Web.ajax
{
    public partial class GetArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           string parentcode=Request["pcode"];
            string checkcode=Request["checkcode"];
            DataTable dt = new DataTable();

           dt=EcShoppingPay.GetArea(parentcode);
           StringBuilder _value = new StringBuilder(string.Empty);
          
           if (dt != null && dt.Rows.Count > 0)
           {
               foreach(DataRow r  in dt.Rows)
               {
                   string check = string.Empty;
                   if (r["areacode"] as string == checkcode)
                   {
                       check = "selected=\"selected\"";
                   }
                   _value.Append("<option value=\"" + r["areacode"] as string + "\"  " + check + ">" + r["areaname"] as string + "</option>");
               }
           }

           Response.Write(_value.ToString());
        }
    }
}