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
    public partial class editpwd :SupplerPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (memberInfo.password.ToUpper() != MyMD5.GetMD5(txtOldPwd.Text))
            {                
                Response.Write("<script>alert('旧密码不正确！');window.parent.location.href='editpwd.aspx';</script>");
                return;
            }
            if (txtNewPwd.Text != "")
            {
                memberInfo.password = MyMD5.GetMD5(txtNewPwd.Text);
            }

            if (ECMember.EditMember(memberInfo) > 0)
            {             
                Response.Write("<script>alert('密码修改成功,请重新登录！');window.parent.location.href='" + ECommon.WebUrl + "/loginout.aspx';</script>");
                Response.End();
            }
        }
    }
}