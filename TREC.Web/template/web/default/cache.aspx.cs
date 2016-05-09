using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Web.UI.HtmlControls;

namespace TREC.Web.template.web
{
    public partial class cache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string key = Request.QueryString["k"];


            if (!string.IsNullOrEmpty(key))
            {
                try
                {
                    TRECommon.DataCache.Remove(key);

                    Response.Redirect( TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') +  "/cache.aspx");

                }
                catch { }
            }
            if(!IsPostBack)
                getallcache(); 
        }

        private void getallcache()
        {
            System.Collections.IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();

            System.Text.StringBuilder strb = new System.Text.StringBuilder();

            while (CacheEnum.MoveNext())
            {

                strb.Append("<a alt='点击清空缓存' title='点击清空缓存' href='?k=" + CacheEnum.Key.ToString() + "'>" + CacheEnum.Key.ToString() + "</a><br /><br />");
                
            }
            div1.InnerHtml = strb.ToString();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             System.Collections.IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
            
             while (CacheEnum.MoveNext())
             {
                 TRECommon.DataCache.Remove(CacheEnum.Key.ToString());
             }

             Response.Redirect(TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/cache.aspx");

        }
    }
}