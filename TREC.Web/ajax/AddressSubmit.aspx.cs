using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz;

namespace TREC.Web.ajax
{
    public partial class AddressSubmit : System.Web.UI.Page
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            int id=Int32.Parse(Request.Form["Id"]);
              int CustomerUserId=Int32.Parse(TRECommon.CookiesHelper.GetCookieCustomer("cid"));

            string Consignee = Request.Form["Consignee"];
            string ProvinceName = Request.Form["ProvinceName"];
            string ProvinceCode = Request.Form["ProvinceCode"];
            string CityName = Request.Form["CityName"];
            string CityCode = Request.Form["CityCode"];
            string AreaName = Request.Form["AreaName"];
            string AreaCode = Request.Form["AreaCode"];
            string Address = Request.Form["Address"];
            string Mobile = Request.Form["Mobile"];
            string Phone = Request.Form["Phone"];
            string Email = Request.Form["Email"];
            string Fax = Request.Form["Fax"];
            string Zipcode = Request.Form["Zipcode"];
          

            ShoppingAddress _shopEntity = new ShoppingAddress();
            if (id > 0)
            {
                _shopEntity = EntityOper.ShoppingAddress.Where(p => p.Id == id).FirstOrDefault();
            }
            _shopEntity.Address = Address;
            _shopEntity.AreaCode = AreaCode;
            _shopEntity.AreaName = AreaName;
            _shopEntity.CityCode = CityCode;
            _shopEntity.CityName = CityName;
            _shopEntity.Consignee = Consignee;
            _shopEntity.CreateTime = DateTime.Now;
            _shopEntity.CustomerUserId = CustomerUserId;
            _shopEntity.Email = Email;
            _shopEntity.Fax = Fax;
            _shopEntity.Zipcode = Zipcode;

            if (id == 0)
            {
                _shopEntity.IsDefault = EntityOper.ShoppingAddress.Where(p => p.CustomerUserId == CustomerUserId).ToList().Count > 0 ? false : true;
            }
            _shopEntity.Mobile = Mobile;
            _shopEntity.Phone = Phone;
            _shopEntity.ProvinceCode = ProvinceCode;
            _shopEntity.ProvinceName = ProvinceName;

            if (id == 0)
            {
                EntityOper.ShoppingAddress.InsertOnSubmit(_shopEntity);
            }

            EntityOper.SubmitChanges();
           
        }
    }
}