using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TREC.ECommerce;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;
using System.Data.Linq;
namespace TREC.Web.aspx.company
{
    public class newsinfo : CompanyPageBase
    {
        protected Dnews dnews = new Dnews();
        protected NewsInfo mnews = null;
        protected int PKID = TRECommon.WebRequest.GetQueryInt("id");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (PKID > 0)
                {
                    loadData();
                }
            }
            pageTitle = "-公司新闻";
        }
        void loadData()
        {
            var query = from a in dnews.Linq.Where(c => c.id == PKID)
                        join b in dnews.LinqData<Mcompany>().Where(c => c.mid > 0) on a.mid equals b.mid into f
                        from k in f.DefaultIfEmpty()
                        select new NewsInfo
                        {
                            id = a.id,
                            ismember = a.ismember,
                            mid = a.mid,
                            membertype = a.membertype,
                            title = a.title,
                            intro = a.intro,
                            descript = a.descript,
                            createtime = a.createtime,
                            companyid = (k != null ? k.id : 0),
                            companytitle = (k != null ? k.title : "")
                        };
            mnews = query.FirstOrDefault();
            if (mnews == null)
            {
                Response.Write(Request.UrlReferrer.ToString());
            }
        }
        protected class NewsInfo : Haojibiz.Model.Mnews
        {
            /// <summary>
            /// 工厂 ID
            /// </summary>
            public int companyid { get; set; }
            /// <summary>
            /// 工厂名称
            /// </summary>
            public string companytitle { get; set; }
        }
    }
}