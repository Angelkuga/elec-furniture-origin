using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TREC.ECommerce;
using Haojibiz;

namespace TREC.Web.Code
{
    public class DealerPageBase : System.Web.UI.Page
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();

        public int did
        {
            get
            {
                if (System.Web.HttpContext.Current.Request["did"] != null)
                {
                    return SubmitMeth.getInt(System.Web.HttpContext.Current.Request["did"]);
                }
                else
                {
                    return 0;
                }
            }
        }

        public t_dealer DealerInfor { get; set; }
        public string title;
        public string seoword = "-家具快搜";
        public List<t_company> companylist = new List<t_company>();
        List<int> companyIdlist = new List<int>();

   

        public DealerPageBase()
        {
            DealerInfor = EntityOper.t_dealer.Where(p => p.id == did&&p.auditstatus==1&&p.linestatus==1).FirstOrDefault();

            if (DealerInfor == null)
            {

                if (!System.Web.HttpContext.Current.Request.Url.ToString().ToLower().Contains("Index2.aspx".ToLower()))
                {
                    System.Web.HttpContext.Current.Response.Redirect("/dealer/Index2.aspx?did=" + did);
                }
            }
            else
            {
                title = DealerInfor.title;
                List<t_brand> _brand = new List<t_brand>();
                _brand = EntityOper.t_brand.Where(p => p.createmid == DealerInfor.mid).ToList();

                if (_brand.Count > 0)
                {
                    foreach (t_brand b in _brand)
                    {
                        if (b.companyid > 0)
                        {
                            companyIdlist.Add(b.companyid.Value);
                        }
                    }

                    if (companyIdlist.Count > 0)
                    {
                        companylist = EntityOper.t_company.Where(p => companyIdlist.Contains(p.id)).ToList();
                    }
                }
            }
        }
    }
}