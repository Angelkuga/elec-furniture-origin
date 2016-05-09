using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;
using System.Data.Linq;

namespace TREC.Web.aspx.company
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion


    public partial class news : CompanyPageBase
    {
        protected Dnews dnews = new Dnews();
        protected List<NewsInfo> list = new List<NewsInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(ECommon.WebUrl + "company/" + ECommon.QueryCid + "/index.aspx");//新闻跳转首页
            CompanyPageBase.setvalue = "-99";
            pageTitle = "-" + companyInfo.title + "-厂家新闻";
            if (!IsPostBack)
            {
                loadData();
            }
        }
        void loadData()
        {
            var query = from a in dnews.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1 && c.mid == companyInfo.mid)
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
            pager.UrlRewritePattern = string.Format(EnUrls.CompanyInfoNewsList, ECommon.QueryCid, "{0}");
        }
        protected string NextUrl
        {
            get
            {
                if (pager.CurrentPageIndex >= pager.PageCount)
                {
                    return "#";
                }
                return string.Format(EnUrls.CompanyInfoNewsList, ECommon.QueryCid, ECommon.QueryPageIndex + 1);
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
                return string.Format(EnUrls.CompanyInfoNewsList, ECommon.QueryCid, ECommon.QueryPageIndex - 1);
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