using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using System.Collections;
using System.Text;
using TREC.Entity;

namespace TREC.Web.aspx.ascx
{
    public class headerShop : System.Web.UI.UserControl
    {
        public Hashtable _htb = new Hashtable();//数据统计
         
        public string woshi = "";
        public string keting = "";
        public string canting = "";
        public string shufang = "";
        public string ertong = "";
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        public string getdid
        {
            get
            {
                if (Request["did"] != null)
                {
                    return Request["did"];
                }
                else
                {
                    if (Request["sid"] != null)
                    {
                        shopInfo = ECShop.GetWebShopInfo(" where id=" + Request["sid"]);
                        int mid = 0;
                        if (shopInfo != null)
                        {
                            mid = shopInfo.mid;
                          Haojibiz.t_dealer _dealer=new Haojibiz.t_dealer();

                          _dealer = EntityOper.t_dealer.Where(p => p.mid == mid).FirstOrDefault();

                          if (_dealer != null)
                          {
                            return  _dealer.id.ToString();
                          }
                           
                        }
                    }
                    return "0";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _htb = ECProduct.GetIndexCount().FirstOrDefault();

            ShopPageBase();
        }

        public string companyurl = "";
        public  EnWebShop shopInfo = new EnWebShop();
        public  bool IsCount = true;
        public  string StyleString = string.Empty;//品牌下系列的id
        public void ShopPageBase()
        {
            if (ECommon.QuerySId == "" || ECommon.QuerySId == "0")
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(),
                    System.Guid.NewGuid().ToString(),
                    "<script>window.top.location.href='" + ECommon.WebUrl + "'</script>"
                    );
            }
            else
            {
                shopInfo = ECShop.GetWebShopInfo(" where id=" + ECommon.QuerySId);
                List<EnBrands> list = new List<EnBrands>();
                if (shopInfo != null && shopInfo.ShopBrandInfo != null && !string.IsNullOrEmpty(shopInfo.ShopBrandInfo.id))
                {
                    IsCount = true;
                   list= ECBrand.GetBrandsList(" brandid=" + shopInfo.ShopBrandInfo.id);
                }
                else
                {
                    list = new List<EnBrands>();
                    IsCount = false;
                }
                if (list.Count > 0)
                {
                    int i = 0;
                    foreach (EnBrands item in list)
                    {
                       
                        if (string.IsNullOrEmpty(item.style))
                        {
                            continue;
                        }
                        if (i == 0)
                        {
                            StyleString = item.style;
                        }
                        else
                        {
                            StyleString += "," + item.style;
                        }
                        i++;
                    }
                }
                if (string.IsNullOrEmpty(StyleString))
                {
                    StyleString = "0";
                }
            }
             
        }

    }
}