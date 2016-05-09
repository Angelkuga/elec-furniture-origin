using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.Entity;
using TREC.ECommerce;

namespace TREC.Web.Suppler.member
{
    public partial class UpdateAccount : SupplerPageBase
    {
        protected EnMember model = null;//会员基本资料
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    //选中左边菜单栏目
               Master.menuName = "purview";
            //    string userName = HttpContext.Current.User.Identity.Name.Trim();
            //    if (!string.IsNullOrEmpty(userName))
               model = memberinfo.memberInfo;
            //}
        }
    }
}