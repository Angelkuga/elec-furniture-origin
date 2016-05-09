using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.shop
{
    public partial class shopgroupinfo : AdminPageBase
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
                EnShopGroup model = ECShop.GetShopGroupInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txttitle.Text = model.title;
                    this.txtcolor.Text = model.color;
                    this.txtavatar.Text = model.avatar;
                    this.txtintegral.Text = model.integral.ToString();
                    this.txtmoney.Text = model.money.ToString();
                    this.txtadcount.Text = model.adcount.ToString();
                    this.txtmarketcount.Text = model.marketpcount.ToString();
                    this.txtbrandcount.Text = model.brandcount.ToString();
                    this.txtpromotioncount.Text = model.promotioncount.ToString();
                    this.txtadrecommend.Text = model.adrecommend.ToString();
                    this.txtmarketrecommend.Text = model.marketrecommend.ToString();
                    this.txtbrandrecommend.Text = model.brandrecommend.ToString();
                    this.txtpromotionrecommend.Text = model.promotionrecommend.ToString();
                    this.txtpermissions.Text = model.permissions;
                    this.txtlev.Text = model.lev.ToString();
                    this.txtdescript.Text = model.descript;
                    this.txtsort.Text = model.sort.ToString();

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnShopGroup model = null;

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
            int marketcount = TypeConverter.StrToInt(this.txtmarketcount.Text);
            int brandcount = TypeConverter.StrToInt(this.txtbrandcount.Text);
            int promotioncount = TypeConverter.StrToInt(this.txtpromotioncount.Text);
            int adrecommend = TypeConverter.StrToInt(this.txtadrecommend.Text);
            int marketrecommend = TypeConverter.StrToInt(this.txtmarketrecommend.Text);
            int brandrecommend = TypeConverter.StrToInt(this.txtbrandrecommend.Text);
            int promotionrecommend = TypeConverter.StrToInt(this.txtpromotionrecommend.Text);


            string permissions = this.txtpermissions.Text;
            int lev = TypeConverter.StrToInt(this.txtlev.Text);
            string descript = this.txtdescript.Text;
            int sort = TypeConverter.StrToInt(this.txtsort.Text);

            


            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECShop.GetShopGroupInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
         

            }

            if (model == null)
            {
                model = new EnShopGroup();
            }


            model.title = title;
            model.color = color;
            model.avatar = avatar;
            model.integral = integral;
            model.money = money;
            model.adcount = adcount;
            model.marketpcount = marketcount;
            model.brandcount = brandcount;
            model.promotioncount = promotioncount;
            model.adrecommend = adrecommend;
            model.marketrecommend = marketrecommend;
            model.brandrecommend = brandrecommend;
            model.promotionrecommend = promotionrecommend;
            model.permissions = permissions;
            model.lev = lev;
            model.descript = descript;
            model.sort = sort;
            


            int aid = ECShop.EditShopGroup(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}