using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler.colorswatch
{
    public partial class DelSwatchList : SupplerPageBase
    {
        protected int pagequantity = 10;//每页信息数
        protected string pageStr = string.Empty;//分页
        protected int currentPage = 1;//当前索引页
        protected string SwatchName = string.Empty;//搜索色板名称
        protected int brandId = 0;//品牌id
        protected int seriesId = 0;//系列id
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (memberInfo != null)
                {

                    //选中左边菜单栏目
                    Master.menuName = "colorswatchlist";


                    string userName = HttpContext.Current.User.Identity.Name.Trim();
                    string strWhere = "";
                    strWhere += " CreateId=" + memberInfo.id;
                    string myurl = "SwatchList.aspx?";
                    //色板名称
                    if (!string.IsNullOrEmpty(Request["SwatchName"]))
                    {
                        SwatchName = Server.UrlDecode(Request["SwatchName"].Trim());
                        if (!string.IsNullOrEmpty(SwatchName))
                            myurl += "SwatchName=" + SwatchName + "&";
                    }

                    //品牌id
                    if (!string.IsNullOrEmpty(Request["brandId"]))
                    {
                        int.TryParse(Request["brandId"].Trim(), out brandId);
                        if (0 < brandId)
                            myurl += "brandId=" + brandId + "&";
                        else
                            brandId = 0;
                    }

                    //系列id
                    if (!string.IsNullOrEmpty(Request["seriesId"]))
                    {
                        int.TryParse(Request["seriesId"].Trim(), out seriesId);
                        if (0 < seriesId)
                            myurl += "seriesId=" + seriesId + "&";
                        else
                            seriesId = 0;
                    }

                    //每页信息数
                    if (!string.IsNullOrEmpty(Request["pq"]))
                        int.TryParse(Request["pq"].Trim(), out pagequantity);
                    if (pagequantity != 20 && pagequantity != 30 && pagequantity != 50)
                        pagequantity = 10;
                    else if (pagequantity != 10)
                        myurl += "pq=" + pagequantity + "&";

                    //当前索引页
                    if (!string.IsNullOrEmpty(Request["Page"]))
                        int.TryParse(Request["Page"].Trim(), out currentPage);
                    if (currentPage < 0)
                        currentPage = 1;

                    //总记录数
                    int Counts = 0;
                    //总页数
                    int PageCount = 0;
                    List<t_colorswatch> brandList = ECBrand.GetColorSwtchRecycleList(ECommon.QueryPageIndex, pagequantity, strWhere, out tmpPageCount);
                    if (0 < tmpPageCount)
                    {
                        RptSwatch.DataSource = brandList;
                        RptSwatch.DataBind();
                        int totalPage = 0;
                        //计算总页数
                        if (tmpPageCount % pagequantity != 0)
                            totalPage = (tmpPageCount - tmpPageCount % pagequantity) / pagequantity + 1;
                        else
                            totalPage = tmpPageCount / pagequantity;

                        pageStr = commonMemberPageSub(tmpPageCount, totalPage, pagequantity, currentPage, "brandlist.aspx?", 5, "个", "品牌");
                    }
                    //List<ColorSwatchModel> SwatchList = TREC.ECommerce.ColorSwatchBll.QueryColorSwatchListDb(userName, brandId, seriesId, SwatchName, pagequantity, currentPage, out Counts, out PageCount);
                    //if (SwatchList != null)
                    //{
                    //    if (0 < SwatchList.Count)
                    //    {
                    //        RptSwatch.DataSource = SwatchList;
                    //        RptSwatch.DataBind();

                    //        pageStr = commonMemberPageSub(Counts, PageCount, pagequantity, currentPage, myurl, 5, "个", "色板");
                    //    }
                    //    SwatchList.Clear();
                    //    SwatchList = null;
                    //}
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(),
                   System.Guid.NewGuid().ToString(),
                   "<script>window.top.location.href='" + ECommon.WebUrl + "/login.aspx" + "'</script>"
                   );
                return;
            }
        }
    }
}