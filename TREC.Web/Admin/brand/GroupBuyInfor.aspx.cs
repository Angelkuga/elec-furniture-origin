using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using Haojibiz;


namespace TREC.Web.Admin.shop
{
    public partial class GroupBuyInfor : AdminPageBase
    {
        public int id
        {
            get
            {
                if (Request["id"] != null)
                {
                    return SubmitMeth.getInt(Request["id"]);
                }
                else
                {
                    return 0;
                }
            }
        }

        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (id > 0)
            {
                GroupBuy grou = new GroupBuy();
                grou = EntityOper.GroupBuy.Where(p => p.Id == id).FirstOrDefault();
                hidelogimg.Value = grou.ImgUrl;
                txttitle.Text = grou.brandName;
                txt_tgtitle.Text = grou.Title;
                txt_showpos.Text = grou.ShowPosition;
                txt_unline.Text = grou.Unline;
                txt_DiscountPerson1.Text = (grou.DiscountPerson1 == null ? "100" : grou.DiscountPerson1.Value.ToString());
                txt_DiscountResult1.Text = (grou.DiscountResult1 == null ? "5" : grou.DiscountResult1.Value.ToString());
                txt_DiscountPerson2.Text = (grou.DiscountPerson2 == null ? "400" : grou.DiscountPerson2.Value.ToString());
                txt_DiscountResult2.Text = (grou.DiscountResult2 == null ? "3.5" : grou.DiscountResult2.Value.ToString());
                txt_orderby.Text = (grou.Orderby == null ? "0" : grou.Orderby.Value.ToString());
                txt_user1.Text = (grou.DiscountUser1 == null ? "0" : grou.DiscountUser1.Value.ToString());
                txt_user2.Text = (grou.DiscountUser2 == null ? "0" : grou.DiscountUser2.Value.ToString());
                txt_zsbegin.Text = (grou.DiscountBegin == null ? "0" : grou.DiscountBegin.Value.ToString()); 
                if (grou.isdefault != null)
                {
                    check_default.Checked = grou.isdefault.Value;
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                GroupBuy grou = new GroupBuy();
                grou = EntityOper.GroupBuy.Where(p => p.Id == id).FirstOrDefault();

              grou.ImgUrl= hidelogimg.Value;
                grou.brandName=txttitle.Text;
                grou.DiscountPerson1 = SubmitMeth.getInt(txt_DiscountPerson1.Text.Trim());
                grou.DiscountResult1 = SubmitMeth.getdouble(txt_DiscountResult1.Text.Trim());
               grou.DiscountPerson2 =SubmitMeth.getInt(txt_DiscountPerson2.Text.Trim());
               grou.DiscountResult2 = SubmitMeth.getdouble(txt_DiscountResult2.Text.Trim());
             grou.Title=txt_tgtitle.Text.Trim();
              grou.Unline=txt_unline.Text.Trim();
              grou.Orderby = SubmitMeth.getInt(txt_orderby.Text.Trim());
              grou.isdefault = check_default.Checked;

             grou.DiscountUser1=SubmitMeth.getInt(txt_user1.Text.Trim());
             grou.DiscountUser2 = SubmitMeth.getInt(txt_user2.Text.Trim());
             grou.DiscountBegin = SubmitMeth.getdouble(txt_zsbegin.Text.Trim());

              grou.ShowPosition=txt_showpos.Text;
               EntityOper.SubmitChanges();
               ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "click", "alert('修改成功！');location.href='GroupBuybrandlist.aspx';", true);
            }


        }
    }
}