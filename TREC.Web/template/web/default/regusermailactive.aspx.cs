using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web
{
    public partial class regusermailactive : System.Web.UI.Page
    {
        public string geturl
        {
            get
            {
                if (Request["url"] != null && Request["url"].Length>5)
                {
                    return Request["url"];
                }
                else
                {
                    return TREC.ECommerce.ECommon.WebUrl;
                }
            }
        }
        //邮件连接激活消费用户
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = Request["code"].ToString();
            EnCustomerActive models = ECCustomerActive.GetCustomerActive(string.Format(" where atype=2 and astatus=1 and acode='{0}'", code));
            if (models != null)
            {
                EnCustomer cmodel = ECCustomer.GetCustomer(string.Format(" where unametype=2 and uname='{0}'", models.AText));
                if (cmodel != null)
                {
                    cmodel.UStatus = 1;
                    ECCustomer.EditCustomer(cmodel);
                    models.AStatus = 0;
                    ECCustomerActive.EditCustomer(models);
                    Response.Write("<script>alert('账号激活成功!');window.location.href='" + geturl + "';</script>");
                }
                else
                {
                    Response.Write("<script>alert('账号激活失败，激活码已被使用过，请联系客服!');window.location.href='" + geturl + "';</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('账号激活失败，请联系客服!');window.location.href='" + TREC.ECommerce.ECommon.WebUrl + "';</script>");
            }
        }
    }
}