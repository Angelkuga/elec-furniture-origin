using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler
{
    public partial class help : SupplerPageBase
    {
        protected EnArticle model = null;
        protected List<EnArticle> articlelist = new List<EnArticle>();
        protected EnArticleCategory modelMain = null;
        protected List<EnArticleCategory> helpCategoryList = new List<EnArticleCategory>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            lbtitle.Text = "帮助中心";
            modelMain=ECArticle.GetArticleCategoryInfo(" where letter='help-model'");
            if (modelMain != null)
            {
                lbtitle.Text = modelMain.title;

                helpCategoryList = ECArticle.GetReaderArticleCategoryList(1, 30, " and parentid=" + modelMain.id, "", "lft", "asc", out tmpPageCount);
                if (ECommon.QueryCid != "" && ECommon.QueryId == "")
                {
                    lbtitle.Text = helpCategoryList.Single(x => x.id.ToString() == ECommon.QueryCid).title;
                    articlelist = ECArticle.GetReaderArticleList(1, 50, "  and categoryid=" + ECommon.QueryCid, out tmpPageCount);

                }
                if (ECommon.QueryCid == "" && ECommon.QueryId == "")
                {
                }
            }
            else
            {
                Response.Write("请新建一个文档分类，并将索引设为：'help-model',确保索引唯一");
            }






        }
    }
}