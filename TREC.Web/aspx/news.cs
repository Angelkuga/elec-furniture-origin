using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TREC.ECommerce;
using TRECommon;
using TREC.Entity;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;
using System.Data.Linq;

namespace TREC.Web.aspx
{
    public class news : WebPageBase
    {
        protected Dnews dnews = new Dnews();
        protected List<NewsInfo> list = new List<NewsInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
            pageTitle = "-新闻资讯";
        }
        void loadData()
        {
            var query = from a in dnews.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1)
                        join b in dnews.LinqData<Mcompany>().Where(c => c.mid > 0) on a.mid equals b.mid into f
                        from k in f.DefaultIfEmpty()
                        orderby a.createtime descending
                        select new NewsInfo
                        {
                            id = a.id,
                            title = a.title,
                            auditstatus = a.auditstatus,
                            linestatus = a.linestatus,
                            mid = a.mid,
                            membertype = a.membertype,
                            createtime = a.createtime,
                            intro = a.intro,
                            ismember = a.ismember,
                            companyid = (k != null ? k.id : 0),
                            companytitle = (k != null ? k.title : "")
                        };
            switch (ECommon.QuerySearchDisplay)
            {
                case "admin":
                    query = query.Where(c => !c.ismember);
                    break;
                case "company":
                    query = query.Where(c => c.ismember);
                    break;
            }
            list = pager.GetPagedDataSource(query);
            pager.EnableUrlRewriting = true;
            pager.UrlRewritePattern = string.Format(EnUrls.NewsListSearch, ECommon.QuerySearchDisplay, "{0}");
        }
        private List<NewsInfo> newList = null;

        public string getListTitle
        {
            get
            {
                string url = Request.Url.ToString();
                if (url.ToLower().Contains("admin"))
                {
                    return "最新行业资讯";
                }
                else if (url.ToLower().Contains("company"))
                {
                    return "品牌新闻资讯";
                }
                else
                {
                    return "全部新闻资讯";
                }
            }
        }
        protected List<NewsInfo> NewList
        {
            get
            {
                if (newList == null)
                {
                    var query = (from a in dnews.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1)
                                 join b in dnews.LinqData<Mcompany>().Where(c => c.mid > 0) on a.mid equals b.mid into f
                                 from k in f.DefaultIfEmpty()
                                 orderby a.createtime descending
                                 select new NewsInfo
                                 {
                                     id = a.id,
                                     mid = a.mid,
                                     membertype = a.membertype,
                                     createtime = a.createtime,
                                     intro = a.intro,
                                     ismember = a.ismember,
                                     title = a.title,
                                     auditstatus = a.auditstatus,
                                     linestatus = a.linestatus,
                                     companyid = (k != null ? k.id : 0),
                                     companytitle = (k != null ? k.title : "")
                                 }).Take(5);
                    newList = query.ToList();
                }
                return newList;
            }
        }
        protected string NextUrl
        {
            get
            {
                if (pager.CurrentPageIndex >= pager.PageCount)
                {
                    return "#";
                }
                return string.Format(EnUrls.NewsListSearch, ECommon.QuerySearchDisplay, pager.CurrentPageIndex + 1);
            }
        }
        protected string PrvUrl
        {
            get
            {
                if (pager.CurrentPageIndex <= 1)
                {
                    return "#";
                }
                return string.Format(EnUrls.NewsListSearch, ECommon.QuerySearchDisplay, pager.CurrentPageIndex - 1);
            }
        }
        protected global::Wuqi.Webdiyer.AspNetPager pager;
        /// <summary>
        /// 新闻信息类
        /// </summary>
        protected class NewsInfo : Haojibiz.Model.Mnews
        {
            public int companyid { get; set; }
            public string companytitle { get; set; }
        }
    }
}