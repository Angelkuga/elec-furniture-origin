using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.aspx.company
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion
      
      
    public partial class brand :CompanyPageBase
    {
        public int BrandId = 0;
        public string BrandDescript = "";
        protected CompanyBrand currentBrand = new CompanyBrand();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-" + companyInfo.title + "-厂家品牌";
            CompanyPageBase.setvalue = "-99";

            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);


            if (strqsb == "" && companyInfo.CompanyBrandList.Count > 0)
            {
                BrandId = TypeConverter.StrToInt(companyInfo.CompanyBrandList[0].id);
                BrandDescript = companyInfo.CompanyBrandList[0].descript;
                currentBrand = companyInfo.CompanyBrandList[0];
            }
            else
            {
                //companyInfo.CompanyBrandList.Find(x=>x.id.ToString()==ECommon.QuerySearchBrand).descript
                if (companyInfo.CompanyBrandList.Count == 0)
                {
                    ScriptUtils.ShowAndRedirect("暂无品牌!", ECommon.WebUrl + "/company/" + companyInfo.id + "/index.aspx");
                    return;
                }
                currentBrand = companyInfo.CompanyBrandList.Find(x => x.id.ToString() == strqsb);
                BrandId = TypeConverter.StrToInt(currentBrand.id);
                BrandDescript = currentBrand.descript;
            }
        }
    }
}