using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;
namespace TREC.Web.aspx
{
    public class promotionsinfo : WebPageBase
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

        private List<Mpromotions> newList = null;
        protected List<Mpromotions> NewList
        {
            get
            {
                if (newList == null)
                {
                    newList = dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(dpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k }).OrderByDescending(c => c.f.createtime).Take(5).ToList().Select(c => new Mpromotions
                    {
                        id = c.f.id,
                        title = c.f.title,
                        startdatetime = c.f.startdatetime,
                        enddatetime = c.f.enddatetime,
                        createtime = c.f.createtime,
                        membertype = c.f.membertype,
                        promotionsrelated = c.k.ToList()
                    }).ToList();
                }
                return newList;
            }
        }
    }
}