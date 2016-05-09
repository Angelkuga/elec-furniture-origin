using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz;
using System.Configuration;

public partial class test : System.Web.UI.Page
{
    Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        OrderList _list = new OrderList();
        _list = EntityOper.OrderList.FirstOrDefault();
    }
}