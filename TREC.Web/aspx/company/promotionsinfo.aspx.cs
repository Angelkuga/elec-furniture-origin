using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRECommon;
using TREC.ECommerce;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;

namespace TREC.Web.aspx.company
{
    public class promotionsinfo : CompanyPageBase
    {
        protected Dpromotions dpromotions = new Dpromotions();
        protected Mpromotions mpromotions = new Mpromotions();
        protected int PKID = TRECommon.WebRequest.GetQueryInt("id");
        protected List<Mshop> shoplist = new List<Mshop>();
        protected List<Mmarket> marketlist = new List<Mmarket>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PKID > 0)
            {
                var firstItem = dpromotions.Linq.Where(c => c.id == PKID).GroupJoin(dpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k })
                     .Where(c => c.f.id == PKID).FirstOrDefault();
                if (firstItem != null)
                {
                    mpromotions = firstItem.f;
                    mpromotions.promotionsrelated = firstItem.k.ToList();

                    var shopids = mpromotions.promotionsrelated.Select(c => c.shopid).ToList();
                    if (shopids.Count > 0)
                    {
                        shoplist = dpromotions.LinqData<Mshop>().Where(c => shopids.Contains(c.id)).ToList();
                    }
                    var marketids = mpromotions.promotionsrelated.Select(c => c.marketid).ToList();
                    if (marketids.Count > 0)
                    {
                        marketlist = dpromotions.LinqData<Mmarket>().Where(c => marketids.Contains(c.id)).ToList();
                    }
                }
            }
        }
    }
}