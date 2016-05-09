using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.Entity;
using TREC.ECommerce;

namespace TREC.Web.Suppler.member
{
    public partial class SettlePurview : SupplerPageBase
    {
        protected int pagequantity = 10;//每页信息数
        protected string pageStr = string.Empty;//分页
        protected int currentPage = 1;//当前索引页
        protected string shopStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                 //选中左边菜单栏目
            Master.menuName = "purviewPM";
            if (!IsPostBack)
            {
               
                string userName = HttpContext.Current.User.Identity.Name.Trim();

                string myurl = "SettlePurview.aspx?";
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
                string strWhere = string.Empty;
                if (memberInfo!=null)
                {
                    strWhere += " parentid="+memberInfo.id;
                }
                
                //总记录数
                int Counts = 0;
                //总页数
                int PageCount = 0;

                if (!string.IsNullOrEmpty(Request["Page"]))
                {
                    int.TryParse(Request["Page"].Trim(), out currentPage);
                    if (currentPage <= 0)
                        currentPage = 1;
                }
                List<EnMember> EnMemberList = ECMember.GetMemberList(currentPage, pagequantity, strWhere, out Counts);
                //List<EnProduct> productList = ECProduct.GetProductList(currentPage, pagequantity, strWhere, out Counts);
                if (EnMemberList != null)
                {
                    if (0 < EnMemberList.Count)
                    {
                        RptAccont.DataSource = EnMemberList;
                        RptAccont.DataBind();
                        int totalPage = 0;
                        //计算总页数
                        if (Counts % pagequantity != 0)
                            totalPage = (Counts - Counts % pagequantity) / pagequantity + 1;
                        else
                            totalPage = Counts / pagequantity;
                        pageStr = commonMemberPageSub(Counts, totalPage, pagequantity, currentPage, "SettlePurview.aspx?", 5, "个", "账号");
                    }
                }
                //List<Model_Account> AccountList = MemberLoginBll.QueryAccountListDb(userName, pagequantity, currentPage, out Counts, out PageCount);
                //if (AccountList != null)
                //{
                //    if (0 < AccountList.Count)
                //    {
                //        RptAccont.DataSource = AccountList;
                //        RptAccont.DataBind();

                //        pageStr = PageUtil.commonMemberPageSub(Counts, PageCount, pagequantity, currentPage, myurl, 5, "个", "账号");
                //    }
                //    AccountList.Clear();
                //    AccountList = null;
                //}
            }
        }

        #region 获取店铺名称
        public string GetShopName(object obj)
        {
            // ECShop.GetShopList(" createmid = " + memberId.ToString(), out shopRecord);
            int myId = 0;
            int.TryParse(obj.ToString(), out myId);
            EnShop shopModel = ECShop.GetShopInfo(" where id=" + myId);
            if (shopModel != null)
            {
                return shopModel.title;
            }
            else
            {
                return "";
            }

        }
        #endregion

        /// <summary>
        /// 获得编号
        /// </summary>
        /// <param name="infoId">id</param>
        /// <returns></returns>
        public string getCode(string infoId)
        {
            if (int.Parse(infoId) < 10)
                return "00" + infoId;
            else if (int.Parse(infoId) < 100)
                return "0" + infoId;
            else
                return infoId;
        }

      
    }
}