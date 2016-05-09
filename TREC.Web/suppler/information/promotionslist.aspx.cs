using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;
using System.Data.Linq;

namespace TREC.Web.Suppler.information
{
    public partial class promotionslist : SupplerPageBase
    {
        protected int day = 0;//最近天数
        protected DateTime? issueDate = null;//发布时间
        protected int sDay = 0;//剩余时间
        protected string keyWord = string.Empty;//关键字
        protected int pagequantity = 20;//每页信息数
        protected int orderBy = 0;//0表示默认（1表示剩余天数降序；2表示关注数降序；3表示状态升序；4表示剩余天数升序；5表示关注数升序；6表示状态降序）
        protected string pageStr = string.Empty;//分页
        protected int Type = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!SupplerPageBase.IsPayMember())
                //{
                //    Response.Redirect("/suppler/Payment/RegPayment.aspx");
                //}
                string memberId = CookiesHelper.GetCookie("mid");
                if (string.IsNullOrEmpty(memberId))
                {
                    Response.Write("<script>top.document.location.href='" + ECommon.WebUrl + "index.aspx" + "';</script>");
                    Response.End();
                }
                //选中左边菜单栏目
                Master.menuName = "information";
                loadData(memberId);
            }
        }

        public void loadData(string memberId)
        {
            string strWhere = " and mid = " + memberId;
            //分页链接
            string myurl = "promotionslist.aspx?";
            //查看信息类型            
            if (!string.IsNullOrEmpty(Request["Type"]))
                int.TryParse(Request["Type"].Trim(), out Type);

            //保存商务类型
            switch (Type)
            {
                case 1:
                    strWhere += " and attribute ='促销'";
                    myurl += "Type=" + Type + "&";
                    break;
                case 2:
                    strWhere += " and attribute ='活动'";
                    myurl += "Type=" + Type + "&";
                    break;
                case 3:
                    strWhere += " and attribute ='新闻'";
                    myurl += "Type=" + Type + "&";
                    break;
                case 4:
                    strWhere += " and attribute ='招商'";
                    myurl += "Type=" + Type + "&";
                    break;
              
            }

            //if (Type < 0 || 5 < Type)
            //    Type = 0;
            //else if (0 < Type)
            //{
            //    strWhere += " and membertype = " + Type;
            //    myurl += "Type=" + Type + "&";
            //}

            //最近天数
            if (!string.IsNullOrEmpty(Request["day"]))
                int.TryParse(Request["day"].Trim(), out day);
            if (day < 0)
                day = 0;
            else if (0 < day)
            {
                strWhere += " and datediff(day,getdate(),createtime) <= " + day.ToString();
                myurl += "day=" + day + "&";
            }

            //发布时间
            DateTime myDateTime;
            if (!string.IsNullOrEmpty(Request["issueDate"]))
            {
                if (DateTime.TryParse(Request["issueDate"].Trim(), out myDateTime))
                {
                    issueDate = myDateTime;
                    myurl += "issueDate=" + issueDate.ToString() + "&";
                    strWhere += " and 0 = datediff(day,getdate(),createtime) ";
                }
            }

            //剩余时间
            if (!string.IsNullOrEmpty(Request["sDay"]))
                int.TryParse(Request["sDay"].Trim(), out sDay);
            if (sDay < 0)
                sDay = 0;
            else if (0 < sDay)
            {
                strWhere += " and datediff(day,getdate(),enddatetime) <= " + sDay.ToString();
                myurl += "sDay=" + sDay + "&";
            }

            //关键字
            if (!string.IsNullOrEmpty(Request["keyWord"]))
            {
                keyWord = Request["keyWord"].Trim();
                myurl += "keyWord=" + keyWord + "&";
                strWhere += " and [title] like '%" + keyWord + "%' ";
            }

            //每页信息数
            if (!string.IsNullOrEmpty(Request["pq"]))
                int.TryParse(Request["pq"].Trim(), out pagequantity);
            if (pagequantity != 10 && pagequantity != 30 && pagequantity != 50)
                pagequantity = 20;
            else if (pagequantity != 20)
                myurl += "pq=" + pagequantity + "&";

            //排序方式
            if (!string.IsNullOrEmpty(Request["orderBy"]))
                int.TryParse(Request["orderBy"].Trim(), out orderBy);
            if (orderBy < 0 || 6 < orderBy)
                orderBy = 0;
            else if (orderBy != 0)
                myurl += "orderBy=" + orderBy + "&";
            
            List<EnWebPromotion> infoList = ECPromotion.GetPromotionList(ECommon.QueryPageIndex, pagequantity, strWhere, " id ", " desc ", out tmpPageCount);
            if (infoList != null)
            {
                if (0 < infoList.Count)
                {
                    rptList.DataSource = infoList;
                    rptList.DataBind();

                    int totalPage = 0;
                    //计算总页数
                    if (tmpPageCount % pagequantity != 0)
                        totalPage = (tmpPageCount - tmpPageCount % pagequantity) / pagequantity + 1;
                    else
                        totalPage = tmpPageCount / pagequantity;

                    pageStr = commonMemberPageSub(tmpPageCount, totalPage, pagequantity, ECommon.QueryPageIndex, myurl, 5, "个", "信息");
                }
                infoList.Clear();
                infoList = null;
            }
        }

        /// <summary>
        /// 获得剩余天数
        /// </summary>
        /// <param name="endDate">截至日期</param>
        /// <returns></returns>
        public string GetSurplusDay(string endDate)
        {
            DateTime dt = DateTime.Now;
            if (DateTime.TryParse(endDate.Trim(), out dt))
            {
                 TimeSpan span = dt.Subtract(DateTime.Now);
                 int day = span.Days + 1;
                 if (0 < day)
                     return day.ToString();
                 else
                     return "已过期";
            }
            else
                return null;
        }

        /// <summary>
        /// 获得商务信息类型
        /// </summary>
        /// <param name="infoType">商务信息类型id</param>
        /// <returns></returns>
        public string getInfoTypeName(int infoType)
        {
            string typeName = string.Empty;
            switch (infoType)
            {
                case 1:
                    typeName = "促销";
                    break;
                case 2:
                    typeName = "活动";
                    break;
                case 3:
                    typeName = "新闻";
                    break;
                case 4:
                    typeName = "招商";
                    break;
                default:
                    typeName = "其他";
                    break;
            }
            return typeName;
        }

        /// <summary>
        /// 获得商务信息状态描述
        /// </summary>
        /// <param name="IsOnline">商务信息状态</param>
        /// <returns></returns>
        public string GetInfoStatus(string IsOnline)
        {
            if (IsOnline == "-1")
                return "<a class=\"offline\">已下线</a>";
            else if (IsOnline == "0")
                return "<a class=\"oncheck\">申请中</a>";
            else
                return "<a class=\"online\">已上线</a>";
        }
    }
}