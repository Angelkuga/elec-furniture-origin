using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.Entity;
using TREC.ECommerce;

namespace TREC.Web.Suppler.shop
{
    public partial class createsmarket :SupplerPageBase
    {
        public string areaCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EnMarket model = new EnMarket();

            string title = txtmarkettitle.Text;
            string letter = "";
            int groupid = 0;
            string attribute = "";
            string industry = "";
            string productcategory = "";
            int vip = 0;
            string areacode = Request.Form["ddlareacode_value"] == null ? Request.Params["ddlareacode_value"] == null ? "" : Request.Params["ddlareacode_value"].ToString() : Request.Form["ddlareacode_value"];
            string address = txtaddress.Text;
            int staffsize = 0;
            string regyear = "2012";
            string regcity = "";
            string buy = "";
            string sell = "";
            string linkman = this.txtlinkman.Text;
            string phone = this.txtphone.Text;
            string mphone = "";
            string fax = "";
            string email = "";
            string postcode = "";
            string homepage = "";
            string domain = "";
            string domainip = "";
            string icp = "";
            string surface = "";
            string logo = "";
            string thumb = "";
            string bannel = "";
            string desimage = "";
            string descript = this.txtdescript.Text;
            string keywords = "";
            string template = "";
            int hits = 0;
            int sort = 0;
            DateTime lastedittime = DateTime.Now;
            int auditstatus = 0;
            int linestatus = 0;

            model.mid = 0;
            model.title = title;
            model.letter = letter;
            model.groupid = groupid;
            model.attribute = attribute;
            model.industry = industry;
            model.productcategory = productcategory;
            model.vip = vip;
            model.areacode = areacode;
            model.address = address;
            model.staffsize = staffsize;
            model.regyear = regyear;
            model.regcity = regcity;
            model.buy = buy;
            model.sell = sell;
            model.linkman = linkman;
            model.phone = phone;
            model.mphone = mphone;
            model.fax = fax;
            model.email = email;
            model.postcode = postcode;
            model.homepage = homepage;
            model.domain = domain;
            model.domainip = domainip;
            model.icp = icp;
            model.surface = surface;
            model.logo = logo;
            model.thumb = thumb;
            model.bannel = bannel;
            model.desimage = desimage;
            model.descript = descript;
            model.keywords = keywords;
            model.template = template;
            model.hits = hits;
            model.sort = sort;
            model.lastedittime = lastedittime;
            model.auditstatus = auditstatus;
            model.linestatus = linestatus;
            model.cbm = 0;
            model.lphone = "";
            model.zphone = "";
            model.busroute = "";
            model.hours = "";
            model.lastedid = memberInfo.id;
            model.mapapi = "";
            model.createmid = memberInfo.id;

            ECMarket.EditMarket(model);
            //{
            //    UiCommon.JscriptPrint(this.Page, "卖场添加成功，请查找并选择!", "shopinfo.aspx", "Success");
            //}
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(),
                   System.Guid.NewGuid().ToString(),
                   "<script>art.dialog.close()</script>"
                   );
        }
    }
}