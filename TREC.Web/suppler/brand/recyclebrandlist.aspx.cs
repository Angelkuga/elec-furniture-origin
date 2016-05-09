using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Suppler.brand
{
    public partial class recyclebrandlist : SupplerPageBase
    {
        protected int pagequantity = 50;//每页信息数
        protected string pageStr = string.Empty;//分页
        protected int currentPage = 1;//当前索引页

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string memberId = CookiesHelper.GetCookie("mid");
                if (string.IsNullOrEmpty(memberId))
                {
                    Response.Write("<script>top.document.location.href='" + ECommon.WebUrl + "index.aspx" + "';</script>");
                    Response.End();
                }

                //选中左边菜单栏目
                Master.menuName = "brandlist";

                ShowData(memberId);
            }
        }

        protected void ShowData(string memberId)
        {
            if (string.IsNullOrEmpty(memberId))
                return;
            string strWhere = "";            
            strWhere += " createmid=" + memberId;

            List<EnBrand> brandList = ECBrand.GetRecycleBrandList(ECommon.QueryPageIndex, pagequantity, strWhere, out tmpPageCount);
            if (0 < tmpPageCount)
            {
                RptBrand.DataSource = brandList;
                RptBrand.DataBind();
                int totalPage = 0;
                //计算总页数
                if (tmpPageCount % pagequantity != 0)
                    totalPage = (tmpPageCount - tmpPageCount % pagequantity) / pagequantity + 1;
                else
                    totalPage = tmpPageCount / pagequantity;

                pageStr = commonMemberPageSub(tmpPageCount, totalPage, pagequantity, currentPage, "recyclebrandlist.aspx?", 5, "个", "品牌");
            }
        }      
    }
}