using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.member
{
    public partial class membergroupinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
           

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnMemberGroup model = ECMember.GetMemberGroupInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txttitle.Text = model.title;
                    this.txtcolor.Text = model.color;
                    this.txtavatar.Text = model.avatar;
                    this.txtintegral.Text = model.integral.ToString();
                    this.txtmoney.Text = model.money.ToString();
                    this.txtpermissions.Text = model.permissions;
                    this.txtlev.Text = model.lev.ToString();
                    this.txtdescript.Text = model.descript;
                    this.txtsort.Text = model.sort.ToString();
                   
                }
            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            TREC.Entity.EnMemberGroup model = null;

            string strErr = "";
            if (this.txttitle.Text.Trim().Length == 0)
            {
                strErr += "title不能为空！\\n";
            }

            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }
            if(model==null)
            {   
                model = new EnMemberGroup();
            }

            string title = this.txttitle.Text;
            string color = this.txtcolor.Text;
            string avatar = this.txtavatar.Text;
            decimal integral = TypeConverter.StrToDeimal(this.txtintegral.Text);
            decimal money = TypeConverter.StrToDeimal(this.txtmoney.Text);
            string permissions = this.txtpermissions.Text;
            int lev = TypeConverter.StrToInt(this.txtlev.Text);
            string descript = this.txtdescript.Text;
            int sort = TypeConverter.StrToInt(this.txtsort.Text);
            
            model.title = title;
            model.color = color;
            model.avatar = avatar;
            model.integral = integral;
            model.money = money;
            model.permissions = permissions;
            model.lev = lev;
            model.descript = descript;
            model.sort = sort;
            

            int aid = ECMember.EditMemberGroup(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}