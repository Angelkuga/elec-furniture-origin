﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using System.Collections;

namespace TREC.Web.Suppler.shop
{
    public partial class shoplist : SupplerPageBase
    {
        protected int pagequantity = 20;//每页信息数
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
                Master.menuName = "shoplist";
                ShowData(memberId);
            }
        }

        protected void ShowData(string memberId)
        {
            string strWhere = "";
            if (memberInfo.type == (int)EnumMemberType.工厂企业)
                strWhere += " id in (select shopid from t_shopbrand where brandid in (select id from t_brand where companyid=" + companyInfo.id + "))";
            else
                strWhere += " createmid=" + memberId;
            List<EnShop> shopList = ECShop.GetShopList(ECommon.QueryPageIndex, pagequantity, strWhere, out tmpPageCount);
            if (shopList != null)
            {
                if (0 < shopList.Count())
                {
                    rptList.DataSource = shopList;
                    rptList.DataBind();

                    int totalPage = 0;
                    //计算总页数
                    if (tmpPageCount % pagequantity != 0)
                        totalPage = (tmpPageCount - tmpPageCount % pagequantity) / pagequantity + 1;
                    else
                        totalPage = tmpPageCount / pagequantity;

                    pageStr = commonMemberPageSub(tmpPageCount, totalPage, pagequantity, currentPage, "shoplist.aspx?", 5, "个", "店铺");
                }
                shopList.Clear();
                shopList = null;
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

        public string GetBrandOfShopId(object id)
        {
            string _ref = string.Empty;
            if (id == null)
            {
                return _ref;
            }
            int shopid = Convert.ToInt32(id);
            int i = 0;
            foreach (Hashtable m in ECShop.GetReaderShopBrandList(shopid))
            {
                if (m["BrandName"] != null)
                {
                    if (i == 0)
                    {
                        _ref = m["BrandName"].ToString();
                    }
                    else
                    {
                        _ref += "，" + m["BrandName"];
                    }
                }
                else
                {
                    _ref = "暂无";
                }

                i++;
            }

            return _ref;
        }
    }
}