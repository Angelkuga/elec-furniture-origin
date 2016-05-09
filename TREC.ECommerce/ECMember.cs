using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TREC.Entity;
using TREC.Data;
using TRECommon;
using System.Web;


namespace TREC.ECommerce
{
    public class ECMember
    {
        //获取最新注册用户
        public static List<EnMember> GetTop20MemberList()
        {
            return GetMemberList("", " where [type]!=" + (int)EnumMemberType.个人成员 + " and  id not in (select mid from " + TableName.TBCompany + ") and  id not in (select mid from " + TableName.TBDealer + ") and id not in (select mid from " + TableName.TBShop + ") and id not in (select mid from " + TableName.TBMarket + ") ", " order by id desc");
        }

        public static List<EnMember> GetTop20MemberList(string name)
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(name))
            {
                strWhere += " and username like '%" + name + "%' ";
            }
            return GetMemberList(" top 20 * ", " where  [type]!=" + (int)EnumMemberType.个人成员 + " and  id not in (select mid from " + TableName.TBCompany + ") and  id not in (select mid from " + TableName.TBDealer + ") and id not in (select mid from " + TableName.TBShop + ") and id not in (select mid from " + TableName.TBMarket + ") " + strWhere, " order by id desc");
        }

        /// <summary>
        /// 检查会员是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int ChkecUserName(string name)
        {
            return DataCommon.Exists(TableName.TBMember, " where username='" + name + "'");
        }

        /// <summary>
        /// 登陆
        /// 2015-01-30 shen  
        /// 修改密码验证MyMD5.GetMD5(pwd) 为 MyMD5.MD532(pwd) 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static int Login(string name, string pwd)
        {
            // 旧登陆
            //DataRow dr = DataCommon.GetDataRow(TableName.TBMember, "id,type,logincount,username,groupid", " where (username='" + name + "' or email='" + name + "' or mobile='" + name + "') and password='" + MyMD5.GetMD5(pwd) + "'", "");

            //新登录参数化数据
            DataRow dr = Members.MemberLogin(name, MyMD5.GetMD5(pwd)); 

            if (dr != null && dr["id"] != Convert.DBNull)
            {

                DataCommon.UpdateValue(TableName.TBMember, "logincount,logintime,loginip", (TypeConverter.StrToInt(dr["logincount"].ToString()) + 1).ToString() + "," + DateTime.Now.ToString() + "," + WebRequest.GetIP(), " where id=" + dr["id"].ToString());

                //CookiesHelper.WriteCookie("mid", dr["id"].ToString(), 60);
                //CookiesHelper.WriteCookie("mname", dr["username"].ToString(), 60);
                //CookiesHelper.WriteCookie("mpwd", MyMD5.GetMD5(pwd), 60);


                #region 登录
                string userTicketData = dr["id"].ToString() + "|" + dr["username"].ToString() + "|" + MyMD5.GetMD5(pwd);
                //加密存储cookie
                System.Web.Security.FormsAuthenticationTicket Ticket = new System.Web.Security.FormsAuthenticationTicket(1, "UserTicket", DateTime.Now, DateTime.Now.AddDays(1), false, userTicketData);
                userTicketData = System.Web.Security.FormsAuthentication.Encrypt(Ticket);
                HttpCookie userCookie = new HttpCookie("UserInfo", userTicketData);
                userCookie.Expires = Ticket.Expiration;
                HttpContext.Current.Response.AppendCookie(userCookie);
                #endregion

                if (dr["groupid"] != Convert.DBNull && dr["groupid"].ToString() == "10")
                {
                    return 10;//消费会员
                }
                if (dr["type"] != Convert.DBNull && dr["type"].ToString() != "0" && dr["type"].ToString() != "")
                {
                    return TypeConverter.StrToInt(dr["type"].ToString());
                }
                return TypeConverter.StrToInt(dr["type"].ToString());
            }
            return 0;

        }


        /// <summary>
        /// 保存申请注入资料
        /// </summary>
        /// <param name="regUser">用户名</param>
        /// <param name="passWord">登录密码</param>
        /// <param name="MobileOrEmail">手机/邮箱</param>
        /// <param name="meType">1表示手机；0表示邮箱</param>
        /// <returns></returns>
        public static bool SaveRegisterDb(string regUser, string passWord, string MobileOrEmail, string meType, string userGroup)
        {
            EnMember memberModel = new EnMember();
            memberModel.id = 0;
            memberModel.username = regUser;
            memberModel.password = MyMD5.GetMD5(passWord);
            memberModel.paypassword = memberModel.password;
            memberModel.birthdate = TypeConverter.StrToDateTime("1900-01-01");


            memberModel.type = (int)EnumMemberType.个人成员;
            memberModel.groupid = 0;
            if (!string.IsNullOrEmpty(userGroup))
            {
                memberModel.groupid = int.Parse(userGroup);
            }
            memberModel.sound = "";
            memberModel.tname = "";
            if (meType == "0")
                memberModel.email = MobileOrEmail;
            else
                memberModel.email = "";
            memberModel.gender = 0;
            if (meType == "1")
                memberModel.mobile = MobileOrEmail;
            else
                memberModel.mobile = "";
            memberModel.phone = "";
            memberModel.msn = "";
            memberModel.qq = "";
            memberModel.skype = "";
            memberModel.ali = "";
            memberModel.areacode = "";
            memberModel.address = "";
            memberModel.department = "";
            memberModel.career = "";
            memberModel.bank = "";
            memberModel.account = "";
            memberModel.alipay = "";

            memberModel.authtime = TypeConverter.StrToDateTime("1900-01-01");
            memberModel.auth = "";
            memberModel.authvalue = "";
            memberModel.vemail = 0;
            memberModel.vmobile = 0;
            memberModel.vname = 0;
            memberModel.vbank = 0;
            memberModel.vcompany = 0;
            memberModel.valipay = 0;
            memberModel.support = "";
            memberModel.inviter = "";

            memberModel.regtime = DateTime.Now;
            memberModel.logintime = DateTime.Now;
            memberModel.chat = 0;
            memberModel.message = 0;
            memberModel.logincount = 1;
            memberModel.regip = WebRequest.GetIP();
            memberModel.regtime = DateTime.Now;
            memberModel.loginip = WebRequest.GetIP();

            int mid = ECMember.EditMember(memberModel);
            if (mid > 0)
            {
                #region 登录写入cookie
                string userTicketData = mid.ToString() + "|" + memberModel.username + "|" + memberModel.password;
                //加密存储cookie
                System.Web.Security.FormsAuthenticationTicket Ticket = new System.Web.Security.FormsAuthenticationTicket(1, "UserTicket", DateTime.Now, DateTime.Now.AddDays(1), false, userTicketData);
                userTicketData = System.Web.Security.FormsAuthentication.Encrypt(Ticket);
                HttpCookie userCookie = new HttpCookie("UserInfo", userTicketData);
                userCookie.Expires = Ticket.Expiration;
                HttpContext.Current.Response.AppendCookie(userCookie);
                #endregion
                //CookiesHelper.WriteCookie("mid", mid.ToString());
                //CookiesHelper.WriteCookie("mname", memberModel.username);
                //CookiesHelper.WriteCookie("mpwd", memberModel.password);
            }
            memberModel = null;
            return mid > 0;
        }


        #region  Method-Member
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMember(EnMember model)
        {
            return Members.EditMember(model);
        }

        /// <summary>
        /// 更新对像充值字段
        /// </summary>
        public static int ModifyMenber(EnMember model)
        {
            return Members.ModifyMenber(model);
        }

        public static int ModifyMenber2(EnMember model)
        {
            return Members.ModifyMenber2(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnMember GetMemberInfo(string strWhere)
        {
            return Members.GetMemberInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMember> GetMemberList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Members.GetMemberList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnMember> GetMemberList(string strWhere, out int pageCount)
        {
            return GetMemberList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnMember> GetMemberList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetMemberList(-1, 0, strWhere, out tmpPageCount);
        }

        ///获取数据列表
        public static List<EnMember> GetMemberList(string field, string strWhere, string sort)
        {
            return Members.GetMemberList(field, strWhere, sort);
        }

        //获取数据列表ToDataTable
        public static DataTable GetMemberListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBMember, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnMember(int id)
        {
            return DeletEnMember(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnMemberByIdList(string idList)
        {
            return DeletEnMember(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnMember(string strWhere)
        {
            return DataCommon.Delete(TableName.TBMember, strWhere);
        }
        #endregion

        #region  Method-MemberGroup
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMemberGroup(EnMemberGroup model)
        {
            return Members.EditMemberGroup(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnMemberGroup GetMemberGroupInfo(string strWhere)
        {
            return Members.GetMemberGroupInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMemberGroup> GetMemberGroupList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Members.GetMemberGroupList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnMemberGroup> GetMemberGroupList(string strWhere, out int pageCount)
        {
            return GetMemberGroupList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnMemberGroup> GetMemberGroupList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetMemberGroupList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetMemberGroupListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBMemberGroup, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnMemberGroup(int id)
        {
            return DeletEnMemberGroup(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnMemberGroupByIdList(string idList)
        {
            return DeletEnMemberGroup(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnMemberGroup(string strWhere)
        {
            return DataCommon.Delete(TableName.TBMemberGroup, strWhere);
        }
        #endregion

        #region 将子账号删除至回收站

        /// <summary>
        /// 将子账号删除至回收站
        /// </summary>
        /// <param name="userName">会员名</param>
        /// <param name="AccountId">账号id</param>
        /// <returns></returns>
        public static bool DelAccountToRecycle(string userName, string AccountId)
        {
            return Members.DelAccountToRecycle(userName, AccountId);
        }
        #endregion


        #region 获得回收站数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMember> GetMemberRecycleList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Members.GetMemberRecycleList(PageIndex, PageSize, strWhere, out pageCount);
        }
        #endregion


        #region 还原回收站子账号
        /// <summary>
        /// 还原账号回收站中账号
        /// </summary>
        /// <param name="userName">会员名</param>
        /// <param name="AccountId">账号id</param>
        /// <returns></returns>
        public static bool RevertAccountRecycle(string userName, string AccountId)
        {
            return Members.RevertAccountRecycle(userName, AccountId);
        }
        #endregion

        #region 删除账号回收站中账号数据
        /// <summary>
        /// 删除账号回收站中账号数据
        /// </summary>
        /// <param name="userName">会员名</param>
        /// <param name="AccountId">账号id</param>
        /// <returns></returns>
        public static bool DelAccountRecycle(string userName, string AccountId)
        {
            return Members.DelAccountRecycle(userName, AccountId);
        }
        #endregion
    }
}
