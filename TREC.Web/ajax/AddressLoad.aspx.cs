using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz;
using System.Text;

namespace TREC.Web.ajax
{
    public partial class AddressLoad : System.Web.UI.Page
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
       // ShoppingAddress _shopEntity = new ShoppingAddress();

        protected void Page_Load(object sender, EventArgs e)
        {
            int CustomerUserId = Int32.Parse(TRECommon.CookiesHelper.GetCookieCustomer("cid"));
            List<ShoppingAddress> _list = new List<ShoppingAddress>();

           _list=EntityOper.ShoppingAddress.Where(p => p.CustomerUserId == CustomerUserId).OrderByDescending(p=>p.IsDefault).ToList();

           //'{"Id":"11","Consignee":"基纳","ProvinceCode":"450000","CityCode":"451300","AreaCode":"451301","Address":"地址","Zipcode":"Zipcode","Mobile":"Mobile","Phone":"Phone","Email":"Email","Fax":"Fax"}'

          
           StringBuilder _value = new StringBuilder(string.Empty);
           string checkadd = "<input type=\"hidden\" id=\"checkAddressId\" name=\"checkAddressId\" value=\"0\" />";

           foreach (ShoppingAddress ad in _list)
           {
               StringBuilder _json = new StringBuilder(string.Empty);
               _json.Append("{");
               _json.Append("\"Id\":\""+ad.Id+"\",");
               _json.Append("\"Consignee\":\""+ad.Consignee+"\",");
               _json.Append("\"ProvinceCode\":\"" + ad.ProvinceCode + "\",");
               _json.Append("\"CityCode\":\""+ad.CityCode+"\",");
               _json.Append("\"AreaCode\":\"" + ad.AreaCode + "\",");
               _json.Append("\"Address\":\""+ad.Address+"\",");
               _json.Append("\"Zipcode\":\""+ad.Zipcode+"\",");
               _json.Append("\"Mobile\":\""+ad.Mobile+"\",");
               _json.Append("\"Phone\":\""+ad.Phone+"\",");
               _json.Append("\"Email\":\""+ad.Email+"\",");
               _json.Append("\"Fax\":\""+ad.Fax+"\"");
               _json.Append("}");

               string isdefault = string.Empty;
               if (ad.IsDefault.Value || _list.Count==1)
               {
                   isdefault = " dizhixz";
                   checkadd = "<input type=\"hidden\" id=\"checkAddressId\" name=\"checkAddressId\" value=\"" + ad.Id + "\" />";
               }
               _value.Append("<div class=\"dizhi" + isdefault + "\" id='dizhi" + ad.Id + "' onclick=\"funcheckAddress('"+ad.Id+"')\">");
               _value.Append("<div><span>" + ad.Mobile + "</span>");
               _value.Append("<strong>" + ad.Consignee + "</strong>收</div>");
               _value.Append(ad.ProvinceName+ad.CityName+ad.AreaName+ "<br>");
               _value.Append(ad.Address+ "<div>");
               _value.Append("<input type=\"hidden\" id=\"updateId" + ad.Id + "\" value='" + _json.ToString() + "'/>");
               _value.Append("<a href=\"javascript:DelOrDefault('" + ad.Id + "','default')\">设为默认地址</a><a href=\"javascript:addressUpdate('" + ad.Id + "')\">编辑</a><a href=\"javascript:DelOrDefault('" + ad.Id + "','del')\">删除</a>");
               _value.Append("</div></div>");
           }

           Response.Write(_value.ToString() + checkadd);
        }
    }
}