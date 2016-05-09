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
     
    public partial class brandlist : SupplerPageBase
    {
       

        protected int pagequantity = 20;//每页信息数
        protected string pageStr = string.Empty;//分页
        protected int currentPage = 1;//当前索引页
        public string brandUrl = string.Empty;
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
                //if (memberInfo.type==102)
                //{
                //    brandUrl = "createbrand.aspx";
                //}
                //else
                //{
                brandUrl = "brandinfo.aspx";
                // }

            }
        }

        protected void ShowData(string memberId)
        {
            if (string.IsNullOrEmpty(memberId))
                return;
            string strWhere = "";
            if (memberInfo.type == (int)EnumMemberType.工厂企业)
                strWhere += " companyid=" + companyInfo.id;
            else
                strWhere += " createmid=" + memberId;

            List<EnBrand> brandList = ECBrand.GetBrandList(ECommon.QueryPageIndex, pagequantity, strWhere, out tmpPageCount);
            if (0 < tmpPageCount)
            {
                rptList.DataSource = brandList;
                rptList.DataBind();
                int totalPage = 0;
                //计算总页数
                if (tmpPageCount % pagequantity != 0)
                    totalPage = (tmpPageCount - tmpPageCount % pagequantity) / pagequantity + 1;
                else
                    totalPage = tmpPageCount / pagequantity;

                pageStr = commonMemberPageSub(tmpPageCount, totalPage, pagequantity, currentPage, "brandlist.aspx?", 5, "个", "品牌");
            }
        }

        public string GetStatusStr(object obj)
        {
            string str = string.Empty;
            if (obj == null)
            {
                return str;
            }
            switch (obj.ToString())
            {
                case "-1":
                    str = "<a class=\"oncheck\">审核中</a>";
                    break;
                case "0":
                    str = "<a class=\"oncheck\">待审核</a>";
                    break;
                case "1":
                    str = "<a class=\"online\">已上线</a>";
                    break;
                case "-99":
                    str = "<a class=\"offline\">已下线</a>";
                    break;
            }
            return str;
        }

        
    }
}