using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TRECommon;
using TREC.Entity;

namespace TREC.Web.Suppler
{
    public partial class supplermemberinfo : SupplerPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtlinkman.Text = memberInfo.tname;
                txtphone.Text = memberInfo.phone;
                txtmphone.Text = memberInfo.mobile;
                txtemail.Text = memberInfo.email;
                txtzhiwei.Text = memberInfo.career;
                txtqq.Text = memberInfo.qq;

                switch (TypeConverter.StrToInt(Request.QueryString["sid"].ToString()))
                {
                    case (int)EnumMemberType.工厂企业:

                        if (companyInfo != null)
                        {
                            txtctitle.Text = companyInfo.title;
                        }
                        break;
                    case (int)EnumMemberType.经销商:
                        if (companyInfo != null)
                        {
                            txtctitle.Text = dealerInfo.title;
                        }
                        break;
                    case (int)EnumMemberType.卖场:
                        if (companyInfo != null)
                        {
                            txtctitle.Text = marketInfo.title;
                        }
                        break;
                }
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {


            memberInfo.tname = txtlinkman.Text;
            memberInfo.phone = txtphone.Text;
            memberInfo.mobile = txtmphone.Text;
            memberInfo.email = txtemail.Text;
            memberInfo.career = txtzhiwei.Text;
            memberInfo.lastedittime = DateTime.Now;
            memberInfo.qq = txtqq.Text;
            ECMember.EditMember(memberInfo);

            if (Request.QueryString["sid"] != null)
            {
                switch (TypeConverter.StrToInt(Request.QueryString["sid"].ToString()))
                {
                    case (int)EnumMemberType.工厂企业:
                        #region 工厂企业                        
                        EnCompany _companyInfo = null;
                        if (companyInfo != null)
                        {
                            _companyInfo = companyInfo;
                        }
                        else
                        {
                            _companyInfo = new EnCompany();
                            _companyInfo.id = 0;
                            _companyInfo.mid = memberInfo.id;
                            _companyInfo.title = txtctitle.Text;
                            _companyInfo.letter = "";
                            _companyInfo.groupid = 0;
                            _companyInfo.attribute = "";
                            _companyInfo.industry = "";
                            _companyInfo.productcategory = "";
                            _companyInfo.vip = 0;
                            _companyInfo.areacode = "";
                            _companyInfo.address = "";
                            _companyInfo.staffsize = 0;
                            _companyInfo.regyear = "2000";
                            _companyInfo.regcity = "";
                            _companyInfo.buy = "";
                            _companyInfo.sell = "";
                            _companyInfo.linkman = txtlinkman.Text;
                            _companyInfo.phone = txtphone.Text;
                            _companyInfo.mphone = txtmphone.Text;
                            _companyInfo.fax = "";
                            _companyInfo.email = txtemail.Text;
                            _companyInfo.postcode = "";
                            _companyInfo.homepage = "";
                            _companyInfo.domain = "";
                            _companyInfo.domainip = "";
                            _companyInfo.icp = "";
                            _companyInfo.surface = "";
                            _companyInfo.logo = "";
                            _companyInfo.thumb = "";
                            _companyInfo.bannel = "";
                            _companyInfo.desimage = "";
                            _companyInfo.descript = "";
                            _companyInfo.keywords = "";
                            _companyInfo.template = "";
                            _companyInfo.hits = 0;
                            _companyInfo.sort = 0;
                            _companyInfo.lastedid = memberInfo.id;
                            _companyInfo.lastedittime = DateTime.Now;
                            _companyInfo.auditstatus = 0;
                            _companyInfo.linestatus = 0;
                        }
                        if (ECCompany.EditCompany(_companyInfo) > 0)
                        {
                            //Modify :rafer
                            //date   :2012-4-25
                            //Remarks:注册邮件
                            EmailHelper.SendEmailReg(txtctitle.Text, null, "工厂企业", memberInfo.phone, memberInfo.tname, memberInfo.qq);

                          //  ScriptUtils.RedirectFrame(this.Page, "f_company/setup1.aspx");
                            ScriptUtils.RedirectFrame(this.Page, "index.aspx");
                        }
                        #endregion
                        break;
                    case (int)EnumMemberType.经销商:
                        #region 经销商
                        EnDealer _dealerInfo = null;
                        if (dealerInfo != null)
                        {
                            _dealerInfo = dealerInfo;
                        }
                        else
                        {
                            _dealerInfo = new EnDealer();
                            _dealerInfo.id = 0;
                            _dealerInfo.mid = memberInfo.id;
                            _dealerInfo.title = txtctitle.Text;
                            _dealerInfo.letter = "";
                            _dealerInfo.groupid = 0;
                            _dealerInfo.attribute = "";
                            _dealerInfo.industry = "";
                            _dealerInfo.productcategory = "";
                            _dealerInfo.vip = 0;
                            _dealerInfo.areacode = "";
                            _dealerInfo.address = "";
                            _dealerInfo.staffsize = 0;
                            _dealerInfo.regyear = "2000";
                            _dealerInfo.regcity = "";
                            _dealerInfo.buy = "";
                            _dealerInfo.sell = "";
                            _dealerInfo.linkman = "";
                            _dealerInfo.phone = "";
                            _dealerInfo.mphone = "";
                            _dealerInfo.fax = "";
                            _dealerInfo.email = "";
                            _dealerInfo.postcode = "";
                            _dealerInfo.homepage = "";
                            _dealerInfo.domain = "";
                            _dealerInfo.domainip = "";
                            _dealerInfo.icp = "";
                            _dealerInfo.surface = "";
                            _dealerInfo.logo = "";
                            _dealerInfo.thumb = "";
                            _dealerInfo.bannel = "";
                            _dealerInfo.desimage = "";
                            _dealerInfo.descript = "";
                            _dealerInfo.keywords = "";
                            _dealerInfo.template = "";
                            _dealerInfo.hits = 0;
                            _dealerInfo.sort = 0;
                            _dealerInfo.lastedid = memberInfo.id;
                            _dealerInfo.lastedittime = DateTime.Now;
                            _dealerInfo.auditstatus = 0;
                            _dealerInfo.linestatus = 0;
                        }
                        if (ECDealer.EditDealer(_dealerInfo) > 0)
                        {
                            //ScriptUtils.RedirectFrame(this.Page, "f_dealer/setup1.aspx");
                            ScriptUtils.RedirectFrame(this.Page, "index.aspx");
                        }
                        #endregion
                        break;
                    case (int)EnumMemberType.卖场:
                        #region 卖场
                        
                        EnMarket _marketInfo = null;
                        if (marketInfo != null)
                        {
                            _marketInfo = marketInfo;
                        }
                        else
                        {
                            _marketInfo = new EnMarket();
                            _marketInfo.id = 0;
                            _marketInfo.mid = memberInfo.id;
                            _marketInfo.title = txtctitle.Text;
                            _marketInfo.letter = "";
                            _marketInfo.groupid = 0;
                            _marketInfo.attribute = "";
                            _marketInfo.industry = "";
                            _marketInfo.productcategory = "";
                            _marketInfo.vip = 0;
                            _marketInfo.areacode = "";
                            _marketInfo.address = "";
                            _marketInfo.staffsize = 0;
                            _marketInfo.regyear = "2000";
                            _marketInfo.regcity = "";
                            _marketInfo.buy = "";
                            _marketInfo.sell = "";
                            _marketInfo.linkman = "";
                            _marketInfo.phone = "";
                            _marketInfo.mphone = "";
                            _marketInfo.fax = "";
                            _marketInfo.email = "";
                            _marketInfo.postcode = "";
                            _marketInfo.homepage = "";
                            _marketInfo.domain = "";
                            _marketInfo.domainip = "";
                            _marketInfo.icp = "";
                            _marketInfo.surface = "";
                            _marketInfo.logo = "";
                            _marketInfo.thumb = "";
                            _marketInfo.bannel = "";
                            _marketInfo.desimage = "";
                            _marketInfo.descript = "";
                            _marketInfo.keywords = "";
                            _marketInfo.template = "";
                            _marketInfo.busroute = "";
                            _marketInfo.cbm = 0;
                            _marketInfo.hours = "";
                            _marketInfo.zphone = "";
                            _marketInfo.hits = 0;
                            _marketInfo.sort = 0;
                            _marketInfo.lastedid = memberInfo.id;
                            _marketInfo.lastedittime = DateTime.Now;
                            _marketInfo.auditstatus = 0;
                            _marketInfo.linestatus = 0;
                        }
                        if (ECMarket.EditMarket(_marketInfo) > 0)
                        {
                            //Modify :rafer
                            //date   :2012-4-25
                            //Remarks:注册邮件
                            EmailHelper.SendEmailReg(txtctitle.Text, null, "卖场", memberInfo.phone, memberInfo.tname, memberInfo.qq);
                            //ScriptUtils.RedirectFrame(this.Page, "f_market/setup1.aspx");
                            ScriptUtils.RedirectFrame(this.Page, "index.aspx");
                        }
                        #endregion
                        break;
                }
            }


        }
    }
}