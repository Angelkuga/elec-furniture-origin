using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using System.Collections;
using TREC.Web.Code;
using Haojibiz;
namespace TREC.Web.template.web.ascx
{
	public partial class HeadDealer : System.Web.UI.UserControl
	{
        //public static EnMember memberInfo = null;
        //public EnWebCompany companyInfo = new EnWebCompany();
        public Hashtable _htb = new Hashtable();//数据统计

        public string getdid
        {
            get
            {
                if (Request["did"] != null)
                {
                    return Request["did"];
                }
                else
                {
                    return "0";
                }
                
            }
        }

        public string title = string.Empty;
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();

        public string companyUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            //_htb = ECProduct.GetIndexCount().FirstOrDefault();
            //if (ECommon.QueryCId == "" || ECommon.QueryCId == "0")
            //{
            //    Response.Redirect(ECommon.WebUrl);
            //}

            //companyInfo = ECCompany.GetWebCompanyInfo(" where id=" + ECommon.QueryCId);

            //if (companyInfo != null)
            //{
            //    memberInfo = ECMember.GetMemberInfo(" where id= " + CompanyPageBase.companyInfo.mid);
            //}

            DealerPageBase _pagebase = new DealerPageBase();

            if (_pagebase.DealerInfor != null)
            {
                title = _pagebase.DealerInfor.title;
                try
                {
                    t_brand _ct_brand = new t_brand();
                    string _brandtitle = EntityOper.t_brand.Where(p => p.createmid == _pagebase.DealerInfor.mid).FirstOrDefault().title;
                    _ct_brand = EntityOper.t_brand.Where(p => p.title == _brandtitle && p.companyid > 0).FirstOrDefault();
                    if (_ct_brand != null)
                    {
                        companyUrl = "/company/" + _ct_brand.companyid + "/index.aspx";
                    }
                    else
                    {
                        companyUrl = "/company/0/index.aspx";
                    }
                }
                catch
                { 
                }
                Repeater_brand.DataSource = EntityOper.t_brand.Where(p => p.createmid == _pagebase.DealerInfor.mid).ToList();
                Repeater_brand.DataBind();
            }
        }
	}
}