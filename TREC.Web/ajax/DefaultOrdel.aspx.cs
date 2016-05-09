using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz;

namespace TREC.Web.ajax
{
    public partial class DefaultOrdel : System.Web.UI.Page
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id=Int32.Parse(Request.Form["Id"].Trim());
            string type=Request.Form["t"];

            int CustomerUserId = Int32.Parse(TRECommon.CookiesHelper.GetCookieCustomer("cid"));
            ShoppingAddress _shopEntity = new ShoppingAddress();
            List<ShoppingAddress> _list = new List<ShoppingAddress>();

            _shopEntity = EntityOper.ShoppingAddress.Where(p => p.CustomerUserId == CustomerUserId &&p.Id==id).FirstOrDefault();

            if (type == "del")
            {
                EntityOper.ShoppingAddress.DeleteOnSubmit(_shopEntity);
                EntityOper.SubmitChanges();
            }
            else if (type == "default")
            {
                foreach (ShoppingAddress s in EntityOper.ShoppingAddress.Where(p => p.CustomerUserId == CustomerUserId))
                {
                    ShoppingAddress _se = new ShoppingAddress();
                    s.IsDefault = false;
                    _se = s;
                    _list.Add(_se);
                }
                _shopEntity.IsDefault = true;
                EntityOper.SubmitChanges();
            }

        }
    }
}