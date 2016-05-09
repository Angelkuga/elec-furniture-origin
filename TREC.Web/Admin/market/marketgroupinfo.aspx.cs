using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.market
{
    public partial class marketgroupinfo : AdminPageBase
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
                EnMarketGroup model = ECMarket.GetMarketGroupInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txttitle.Text = model.title;
                    this.txtcolor.Text = model.color;
                    this.txtavatar.Text = model.avatar;
                    this.txtintegral.Text = model.integral.ToString();
                    this.txtmoney.Text = model.money.ToString();
                    this.txtadcount.Text = model.adcount.ToString();
                    this.txtshopcount.Text = model.shopcount.ToString();
                    this.txtbrandcount.Text = model.brandcount.ToString();
                    this.txtpromotioncount.Text = model.promotioncount.ToString();
                    this.txtadrecommend.Text = model.adrecommend.ToString();
                    this.txtshoprecommend.Text = model.shoprecommend.ToString();
                    this.txtbrandrecommend.Text = model.brandrecommend.ToString();
                    this.txtpromotionrecommend.Text = model.promotionrecommend.ToString();
                    this.txtshopcount.Text = model.storeycount.ToString();
                    this.txtshoprecommend.Text = model.storeyshopcount.ToString();
                    this.txtpermissions.Text = model.permissions;
                    this.txtlev.Text = model.lev.ToString();
                    this.txtdescript.Text = model.descript;
                    this.txtsort.Text = model.sort.ToString();

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnMarketGroup model = null;

            string strErr = "";
            

            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            string title = this.txttitle.Text;
            string color = this.txtcolor.Text;
            string avatar = this.txtavatar.Text;
            decimal integral = TypeConverter.StrToDeimal(this.txtintegral.Text);
            decimal money = TypeConverter.StrToDeimal(this.txtmoney.Text);
            int adcount = TypeConverter.StrToInt(this.txtadcount.Text);
            int shopcount = TypeConverter.StrToInt(this.txtshopcount.Text);
            int brandcount = TypeConverter.StrToInt(this.txtbrandcount.Text);
            int promotioncount = TypeConverter.StrToInt(this.txtpromotioncount.Text);
            int adrecommend = TypeConverter.StrToInt(this.txtadrecommend.Text);
            int shoprecommend = TypeConverter.StrToInt(this.txtshoprecommend.Text);
            int brandrecommend = TypeConverter.StrToInt(this.txtbrandrecommend.Text);
            int promotionrecommend = TypeConverter.StrToInt(this.txtpromotionrecommend.Text);

            int storeycount = TypeConverter.StrToInt(this.txtstoreycount.Text);
            int storeyshopcount = TypeConverter.StrToInt(this.txtstoreyshopcount.Text);

            string permissions = this.txtpermissions.Text;
            int lev = TypeConverter.StrToInt(this.txtlev.Text);
            string descript = this.txtdescript.Text;
            int sort = TypeConverter.StrToInt(this.txtsort.Text);

            


            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECMarket.GetMarketGroupInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
               

            }
            if (model == null)
            {
                model = new EnMarketGroup();
            }



            model.title = title;
            model.color = color;
            model.avatar = avatar;
            model.integral = integral;
            model.money = money;
            model.adcount = adcount;
            model.shopcount = shopcount;
            model.brandcount = brandcount;
            model.promotioncount = promotioncount;
            model.adrecommend = adrecommend;
            model.shoprecommend = shoprecommend;
            model.brandrecommend = brandrecommend;
            model.promotionrecommend = promotionrecommend;
            model.permissions = permissions;
            model.storeycount = storeycount;
            model.storeyshopcount = storeyshopcount;
            model.lev = lev;
            model.descript = descript;
            model.sort = sort;
            


            int aid = ECMarket.EditMarketGroup(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}