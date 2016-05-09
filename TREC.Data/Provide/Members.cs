using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TREC.Entity;
using TRECommon;

namespace TREC.Data
{
    public class Members
    {
        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMember(EnMember model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_member(");
                strSql.Append("username,password,paypassword,passport,type,groupid,sound,tname,email,gender,mobile,phone,msn,qq,skype,ali,birthdate,areacode,address,department,career,sms,integral,money,bank,account,alipay,regip,regtime,loginip,logintime,logincount,auth,authvalue,authtime,vemail,vmobile,vname,vbank,vcompany,valipay,support,inviter,lastedittime,chat,message,question,answer,parentid,shopid)");
                strSql.Append(" values (");
                strSql.Append("@username,@password,@paypassword,@passport,@type,@groupid,@sound,@tname,@email,@gender,@mobile,@phone,@msn,@qq,@skype,@ali,@birthdate,@areacode,@address,@department,@career,@sms,@integral,@money,@bank,@account,@alipay,@regip,@regtime,@loginip,@logintime,@logincount,@auth,@authvalue,@authtime,@vemail,@vmobile,@vname,@vbank,@vcompany,@valipay,@support,@inviter,@lastedittime,@chat,@message,@question,@answer,@parentid,@shopid)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,20),
					new SqlParameter("@password", SqlDbType.VarChar,50),
					new SqlParameter("@paypassword", SqlDbType.VarChar,40),
					new SqlParameter("@passport", SqlDbType.VarChar,16),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@groupid", SqlDbType.Int,4),
					new SqlParameter("@sound", SqlDbType.VarChar,120),
					new SqlParameter("@tname", SqlDbType.NVarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@gender", SqlDbType.Int,4),
					new SqlParameter("@mobile", SqlDbType.VarChar,20),
					new SqlParameter("@phone", SqlDbType.VarChar,20),
					new SqlParameter("@msn", SqlDbType.NVarChar,50),
					new SqlParameter("@qq", SqlDbType.NVarChar,50),
					new SqlParameter("@skype", SqlDbType.NVarChar,50),
					new SqlParameter("@ali", SqlDbType.NVarChar,50),
					new SqlParameter("@birthdate", SqlDbType.DateTime),
					new SqlParameter("@areacode", SqlDbType.VarChar,10),
					new SqlParameter("@address", SqlDbType.NVarChar,120),
					new SqlParameter("@department", SqlDbType.NVarChar,20),
					new SqlParameter("@career", SqlDbType.NVarChar,20),
					new SqlParameter("@sms", SqlDbType.Decimal,9),
					new SqlParameter("@integral", SqlDbType.Decimal,9),
					new SqlParameter("@money", SqlDbType.Decimal,9),
					new SqlParameter("@bank", SqlDbType.NVarChar,50),
					new SqlParameter("@account", SqlDbType.NVarChar,50),
					new SqlParameter("@alipay", SqlDbType.NVarChar,50),
					new SqlParameter("@regip", SqlDbType.VarChar,50),
					new SqlParameter("@regtime", SqlDbType.DateTime),
					new SqlParameter("@loginip", SqlDbType.VarChar,50),
					new SqlParameter("@logintime", SqlDbType.DateTime),
					new SqlParameter("@logincount", SqlDbType.Int,4),
					new SqlParameter("@auth", SqlDbType.VarChar,32),
					new SqlParameter("@authvalue", SqlDbType.NVarChar,100),
					new SqlParameter("@authtime", SqlDbType.DateTime),
					new SqlParameter("@vemail", SqlDbType.Int,4),
					new SqlParameter("@vmobile", SqlDbType.Int,4),
					new SqlParameter("@vname", SqlDbType.Int,4),
					new SqlParameter("@vbank", SqlDbType.Int,4),
					new SqlParameter("@vcompany", SqlDbType.Int,4),
					new SqlParameter("@valipay", SqlDbType.Int,4),
					new SqlParameter("@support", SqlDbType.NVarChar,500),
					new SqlParameter("@inviter", SqlDbType.NVarChar,20),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@chat", SqlDbType.Int,4),
					new SqlParameter("@message", SqlDbType.Int,4),
					new SqlParameter("@question", SqlDbType.Int,4),
					new SqlParameter("@answer", SqlDbType.NVarChar,100),
                    new SqlParameter("@parentid", SqlDbType.Int,4),
                    new SqlParameter("@shopid", SqlDbType.Int,4),
                    
                                            };
                parameters[0].Value = model.username;
                parameters[1].Value = model.password;
                parameters[2].Value = model.paypassword;
                parameters[3].Value = model.passport;
                parameters[4].Value = model.type;
                parameters[5].Value = model.groupid;
                parameters[6].Value = model.sound;
                parameters[7].Value = model.tname;
                parameters[8].Value = model.email;
                parameters[9].Value = model.gender;
                parameters[10].Value = model.mobile;
                parameters[11].Value = model.phone;
                parameters[12].Value = model.msn;
                parameters[13].Value = model.qq;
                parameters[14].Value = model.skype;
                parameters[15].Value = model.ali;
                parameters[16].Value = model.birthdate;
                parameters[17].Value = model.areacode;
                parameters[18].Value = model.address;
                parameters[19].Value = model.department;
                parameters[20].Value = model.career;
                parameters[21].Value = model.sms;
                parameters[22].Value = model.integral;
                parameters[23].Value = model.money;
                parameters[24].Value = model.bank;
                parameters[25].Value = model.account;
                parameters[26].Value = model.alipay;
                parameters[27].Value = model.regip;
                parameters[28].Value = model.regtime;
                parameters[29].Value = model.loginip;
                parameters[30].Value = model.logintime;
                parameters[31].Value = model.logincount;
                parameters[32].Value = model.auth;
                parameters[33].Value = model.authvalue;
                parameters[34].Value = model.authtime;
                parameters[35].Value = model.vemail;
                parameters[36].Value = model.vmobile;
                parameters[37].Value = model.vname;
                parameters[38].Value = model.vbank;
                parameters[39].Value = model.vcompany;
                parameters[40].Value = model.valipay;
                parameters[41].Value = model.support;
                parameters[42].Value = model.inviter;
                parameters[43].Value = model.lastedittime;
                parameters[44].Value = model.chat;
                parameters[45].Value = model.message;
                parameters[46].Value = model.question;
                parameters[47].Value = model.answer;
                parameters[48].Value = model.parentid;
                parameters[49].Value = model.shopid;
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_member set ");
                strSql.Append("username=@username,");
                strSql.Append("password=@password,");
                strSql.Append("paypassword=@paypassword,");
                strSql.Append("passport=@passport,");
                strSql.Append("type=@type,");
                strSql.Append("groupid=@groupid,");
                strSql.Append("sound=@sound,");
                strSql.Append("tname=@tname,");
                strSql.Append("email=@email,");
                strSql.Append("gender=@gender,");
                strSql.Append("mobile=@mobile,");
                strSql.Append("phone=@phone,");
                strSql.Append("msn=@msn,");
                strSql.Append("qq=@qq,");
                strSql.Append("skype=@skype,");
                strSql.Append("ali=@ali,");
                strSql.Append("birthdate=@birthdate,");
                strSql.Append("areacode=@areacode,");
                strSql.Append("address=@address,");
                strSql.Append("department=@department,");
                strSql.Append("career=@career,");
                strSql.Append("sms=@sms,");
                strSql.Append("integral=@integral,");
                strSql.Append("money=@money,");
                strSql.Append("bank=@bank,");
                strSql.Append("account=@account,");
                strSql.Append("alipay=@alipay,");
                strSql.Append("regip=@regip,");
                strSql.Append("regtime=@regtime,");
                strSql.Append("loginip=@loginip,");
                strSql.Append("logintime=@logintime,");
                strSql.Append("logincount=@logincount,");
                strSql.Append("auth=@auth,");
                strSql.Append("authvalue=@authvalue,");
                strSql.Append("authtime=@authtime,");
                strSql.Append("vemail=@vemail,");
                strSql.Append("vmobile=@vmobile,");
                strSql.Append("vname=@vname,");
                strSql.Append("vbank=@vbank,");
                strSql.Append("vcompany=@vcompany,");
                strSql.Append("valipay=@valipay,");
                strSql.Append("support=@support,");
                strSql.Append("inviter=@inviter,");
                strSql.Append("lastedittime=@lastedittime,");
                strSql.Append("chat=@chat,");
                strSql.Append("message=@message,");
                strSql.Append("question=@question,");
                strSql.Append("answer=@answer,");
                strSql.Append("parentid=@parentid,");
                strSql.Append("shopid=@shopid");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,20),
					new SqlParameter("@password", SqlDbType.VarChar,50),
					new SqlParameter("@paypassword", SqlDbType.VarChar,40),
					new SqlParameter("@passport", SqlDbType.VarChar,16),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@groupid", SqlDbType.Int,4),
					new SqlParameter("@sound", SqlDbType.VarChar,120),
					new SqlParameter("@tname", SqlDbType.NVarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@gender", SqlDbType.Int,4),
					new SqlParameter("@mobile", SqlDbType.VarChar,20),
					new SqlParameter("@phone", SqlDbType.VarChar,20),
					new SqlParameter("@msn", SqlDbType.NVarChar,50),
					new SqlParameter("@qq", SqlDbType.NVarChar,50),
					new SqlParameter("@skype", SqlDbType.NVarChar,50),
					new SqlParameter("@ali", SqlDbType.NVarChar,50),
					new SqlParameter("@birthdate", SqlDbType.DateTime),
					new SqlParameter("@areacode", SqlDbType.VarChar,10),
					new SqlParameter("@address", SqlDbType.NVarChar,120),
					new SqlParameter("@department", SqlDbType.NVarChar,20),
					new SqlParameter("@career", SqlDbType.NVarChar,20),
					new SqlParameter("@sms", SqlDbType.Decimal,9),
					new SqlParameter("@integral", SqlDbType.Decimal,9),
					new SqlParameter("@money", SqlDbType.Decimal,9),
					new SqlParameter("@bank", SqlDbType.NVarChar,50),
					new SqlParameter("@account", SqlDbType.NVarChar,50),
					new SqlParameter("@alipay", SqlDbType.NVarChar,50),
					new SqlParameter("@regip", SqlDbType.VarChar,50),
					new SqlParameter("@regtime", SqlDbType.DateTime),
					new SqlParameter("@loginip", SqlDbType.VarChar,50),
					new SqlParameter("@logintime", SqlDbType.DateTime),
					new SqlParameter("@logincount", SqlDbType.Int,4),
					new SqlParameter("@auth", SqlDbType.VarChar,32),
					new SqlParameter("@authvalue", SqlDbType.NVarChar,100),
					new SqlParameter("@authtime", SqlDbType.DateTime),
					new SqlParameter("@vemail", SqlDbType.Int,4),
					new SqlParameter("@vmobile", SqlDbType.Int,4),
					new SqlParameter("@vname", SqlDbType.Int,4),
					new SqlParameter("@vbank", SqlDbType.Int,4),
					new SqlParameter("@vcompany", SqlDbType.Int,4),
					new SqlParameter("@valipay", SqlDbType.Int,4),
					new SqlParameter("@support", SqlDbType.NVarChar,500),
					new SqlParameter("@inviter", SqlDbType.NVarChar,20),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@chat", SqlDbType.Int,4),
					new SqlParameter("@message", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@question", SqlDbType.Int,4),
					new SqlParameter("@answer", SqlDbType.NVarChar,100),
                    new SqlParameter("@parentid", SqlDbType.Int,4),
                    new SqlParameter("@shopid", SqlDbType.Int,4),
                                            };
                parameters[0].Value = model.username;
                parameters[1].Value = model.password;
                parameters[2].Value = model.paypassword;
                parameters[3].Value = model.passport;
                parameters[4].Value = model.type;
                parameters[5].Value = model.groupid;
                parameters[6].Value = model.sound;
                parameters[7].Value = model.tname;
                parameters[8].Value = model.email;
                parameters[9].Value = model.gender;
                parameters[10].Value = model.mobile;
                parameters[11].Value = model.phone;
                parameters[12].Value = model.msn;
                parameters[13].Value = model.qq;
                parameters[14].Value = model.skype;
                parameters[15].Value = model.ali;
                parameters[16].Value = model.birthdate;
                parameters[17].Value = model.areacode;
                parameters[18].Value = model.address;
                parameters[19].Value = model.department;
                parameters[20].Value = model.career;
                parameters[21].Value = model.sms;
                parameters[22].Value = model.integral;
                parameters[23].Value = model.money;
                parameters[24].Value = model.bank;
                parameters[25].Value = model.account;
                parameters[26].Value = model.alipay;
                parameters[27].Value = model.regip;
                parameters[28].Value = model.regtime;
                parameters[29].Value = model.loginip;
                parameters[30].Value = model.logintime;
                parameters[31].Value = model.logincount;
                parameters[32].Value = model.auth;
                parameters[33].Value = model.authvalue;
                parameters[34].Value = model.authtime;
                parameters[35].Value = model.vemail;
                parameters[36].Value = model.vmobile;
                parameters[37].Value = model.vname;
                parameters[38].Value = model.vbank;
                parameters[39].Value = model.vcompany;
                parameters[40].Value = model.valipay;
                parameters[41].Value = model.support;
                parameters[42].Value = model.inviter;
                parameters[43].Value = model.lastedittime;
                parameters[44].Value = model.chat;
                parameters[45].Value = model.message;
                parameters[46].Value = model.id;
                parameters[47].Value = model.question;
                parameters[48].Value = model.answer;
                parameters[49].Value = model.parentid;
                parameters[50].Value = model.shopid;
                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return model.id;
                }
            }

            return 0;

        }

        /// <summary>
        /// 更新对像充值字段
        /// </summary>
        public static int ModifyMenber(EnMember model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_member set ");
            strSql.Append("overprice=overprice+@overprice,");
            strSql.Append("useprice=useprice+@useprice,");
            strSql.Append("Isrecharge=@Isrecharge,");
            strSql.Append("RegStatcTime=@RegStatcTime,");
            strSql.Append("RegEndTime=@RegEndTime,");
            strSql.Append("vipLevel=@vipLevel");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@overprice", SqlDbType.Decimal),
					new SqlParameter("@useprice", SqlDbType.Decimal),
					new SqlParameter("@Isrecharge", SqlDbType.Bit),
					new SqlParameter("@RegStatcTime", SqlDbType.DateTime),
                    new SqlParameter("@RegEndTime", SqlDbType.DateTime),
                    new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@vipLevel", SqlDbType.Int,4)};
            parameters[0].Value = model.overprice;
            parameters[1].Value = model.useprice;
            parameters[2].Value = model.Isrecharge;
            parameters[3].Value = model.RegStatcTime;
            parameters[4].Value = model.RegEndTime;
            parameters[5].Value = model.id;
            parameters[6].Value = model.VipLevel;
            if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                return model.id;
            }
            return 0;
        }

        public static int ModifyMenber2(EnMember model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_member set ");
            strSql.Append("type=@type");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@type", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.id;
            parameters[1].Value = model.type;
            if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                return model.id;
            }
            return 0;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnMember GetMemberInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_member ");
            strSql.Append(strWhere);


            EnMember model = new EnMember();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["username"] != null && reader["username"].ToString() != "")
                {
                    model.username = reader["username"].ToString();
                }
                if (reader["password"] != null && reader["password"].ToString() != "")
                {
                    model.password = reader["password"].ToString();
                }
                if (reader["paypassword"] != null && reader["paypassword"].ToString() != "")
                {
                    model.paypassword = reader["paypassword"].ToString();
                }
                if (reader["passport"] != null && reader["passport"].ToString() != "")
                {
                    model.passport = reader["passport"].ToString();
                }
                if (reader["type"] != null && reader["type"].ToString() != "")
                {
                    model.type = int.Parse(reader["type"].ToString());
                }
                if (reader["groupid"] != null && reader["groupid"].ToString() != "")
                {
                    model.groupid = int.Parse(reader["groupid"].ToString());
                }
                if (reader["sound"] != null && reader["sound"].ToString() != "")
                {
                    model.sound = reader["sound"].ToString();
                }
                if (reader["tname"] != null && reader["tname"].ToString() != "")
                {
                    model.tname = reader["tname"].ToString();
                }
                if (reader["email"] != null && reader["email"].ToString() != "")
                {
                    model.email = reader["email"].ToString();
                }
                if (reader["gender"] != null && reader["gender"].ToString() != "")
                {
                    model.gender = int.Parse(reader["gender"].ToString());
                }
                if (reader["mobile"] != null && reader["mobile"].ToString() != "")
                {
                    model.mobile = reader["mobile"].ToString();
                }
                if (reader["phone"] != null && reader["phone"].ToString() != "")
                {
                    model.phone = reader["phone"].ToString();
                }
                if (reader["msn"] != null && reader["msn"].ToString() != "")
                {
                    model.msn = reader["msn"].ToString();
                }
                if (reader["qq"] != null && reader["qq"].ToString() != "")
                {
                    model.qq = reader["qq"].ToString();
                }
                if (reader["skype"] != null && reader["skype"].ToString() != "")
                {
                    model.skype = reader["skype"].ToString();
                }
                if (reader["ali"] != null && reader["ali"].ToString() != "")
                {
                    model.ali = reader["ali"].ToString();
                }
                if (reader["birthdate"] != null && reader["birthdate"].ToString() != "")
                {
                    model.birthdate = DateTime.Parse(reader["birthdate"].ToString());
                }
                if (reader["areacode"] != null && reader["areacode"].ToString() != "")
                {
                    model.areacode = reader["areacode"].ToString();
                }
                if (reader["address"] != null && reader["address"].ToString() != "")
                {
                    model.address = reader["address"].ToString();
                }
                if (reader["department"] != null && reader["department"].ToString() != "")
                {
                    model.department = reader["department"].ToString();
                }
                if (reader["career"] != null && reader["career"].ToString() != "")
                {
                    model.career = reader["career"].ToString();
                }
                if (reader["sms"] != null && reader["sms"].ToString() != "")
                {
                    model.sms = decimal.Parse(reader["sms"].ToString());
                }
                if (reader["integral"] != null && reader["integral"].ToString() != "")
                {
                    model.integral = decimal.Parse(reader["integral"].ToString());
                }
                if (reader["money"] != null && reader["money"].ToString() != "")
                {
                    model.money = decimal.Parse(reader["money"].ToString());
                }
                if (reader["bank"] != null && reader["bank"].ToString() != "")
                {
                    model.bank = reader["bank"].ToString();
                }
                if (reader["account"] != null && reader["account"].ToString() != "")
                {
                    model.account = reader["account"].ToString();
                }
                if (reader["alipay"] != null && reader["alipay"].ToString() != "")
                {
                    model.alipay = reader["alipay"].ToString();
                }
                if (reader["regip"] != null && reader["regip"].ToString() != "")
                {
                    model.regip = reader["regip"].ToString();
                }
                if (reader["regtime"] != null && reader["regtime"].ToString() != "")
                {
                    model.regtime = DateTime.Parse(reader["regtime"].ToString());
                }
                if (reader["loginip"] != null && reader["loginip"].ToString() != "")
                {
                    model.loginip = reader["loginip"].ToString();
                }
                if (reader["logintime"] != null && reader["logintime"].ToString() != "")
                {
                    model.logintime = DateTime.Parse(reader["logintime"].ToString());
                }
                if (reader["logincount"] != null && reader["logincount"].ToString() != "")
                {
                    model.logincount = int.Parse(reader["logincount"].ToString());
                }
                if (reader["auth"] != null && reader["auth"].ToString() != "")
                {
                    model.auth = reader["auth"].ToString();
                }
                if (reader["authvalue"] != null && reader["authvalue"].ToString() != "")
                {
                    model.authvalue = reader["authvalue"].ToString();
                }
                if (reader["authtime"] != null && reader["authtime"].ToString() != "")
                {
                    model.authtime = DateTime.Parse(reader["authtime"].ToString());
                }
                if (reader["vemail"] != null && reader["vemail"].ToString() != "")
                {
                    model.vemail = int.Parse(reader["vemail"].ToString());
                }
                if (reader["vmobile"] != null && reader["vmobile"].ToString() != "")
                {
                    model.vmobile = int.Parse(reader["vmobile"].ToString());
                }
                if (reader["vname"] != null && reader["vname"].ToString() != "")
                {
                    model.vname = int.Parse(reader["vname"].ToString());
                }
                if (reader["vbank"] != null && reader["vbank"].ToString() != "")
                {
                    model.vbank = int.Parse(reader["vbank"].ToString());
                }
                if (reader["vcompany"] != null && reader["vcompany"].ToString() != "")
                {
                    model.vcompany = int.Parse(reader["vcompany"].ToString());
                }
                if (reader["valipay"] != null && reader["valipay"].ToString() != "")
                {
                    model.valipay = int.Parse(reader["valipay"].ToString());
                }
                if (reader["support"] != null && reader["support"].ToString() != "")
                {
                    model.support = reader["support"].ToString();
                }
                if (reader["inviter"] != null && reader["inviter"].ToString() != "")
                {
                    model.inviter = reader["inviter"].ToString();
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["chat"] != null && reader["chat"].ToString() != "")
                {
                    model.chat = int.Parse(reader["chat"].ToString());
                }
                if (reader["message"] != null && reader["message"].ToString() != "")
                {
                    model.message = int.Parse(reader["message"].ToString());
                }
                if (reader["question"] != null && reader["question"].ToString() != "")
                {
                    model.question = int.Parse(reader["question"].ToString());
                }
                if (reader["answer"] != null && reader["answer"].ToString() != "")
                {
                    model.answer = reader["answer"].ToString();
                }
                if (reader["overprice"] != null && reader["overprice"].ToString() != "")
                {
                    model.overprice = TypeConverter.ObjToDeimal(reader["overprice"].ToString());
                }
                if (reader["useprice"] != null && reader["useprice"].ToString() != "")
                {
                    model.useprice = TypeConverter.ObjToDeimal(reader["useprice"].ToString());
                }
                if (reader["Isrecharge"] != null && reader["Isrecharge"].ToString() != "")
                {
                    model.Isrecharge = TypeConverter.StrToBool(reader["Isrecharge"].ToString(), false);
                }
                if (reader["RegStatcTime"] != null && reader["RegStatcTime"].ToString() != "")
                {
                    string ii = reader["RegStatcTime"].ToString();
                    model.RegStatcTime = TypeConverter.StrToDateTime(reader["RegStatcTime"].ToString());
                }
                if (reader["RegEndTime"] != null && reader["RegEndTime"].ToString() != "")
                {
                    model.RegEndTime = TypeConverter.StrToDateTime(reader["RegEndTime"].ToString());
                }
                if (reader["vipLevel"] != null && reader["vipLevel"].ToString() != "")
                {
                    model.VipLevel = TypeConverter.StrToInt(reader["vipLevel"].ToString());
                }
                if (reader["shopid"] != null && reader["shopid"].ToString() != "")
                {
                    model.shopid = TypeConverter.StrToInt(reader["shopid"].ToString());
                }
                if (reader["parentid"] != null && reader["parentid"].ToString() != "")
                {
                    model.parentid = TypeConverter.StrToInt(reader["parentid"].ToString());
                }


                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                return model;
            }
            else
            {
                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMember> GetMemberList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnMember> modelList = new List<EnMember>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBMember, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnMember model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMember();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["username"] != null && dt.Rows[n]["username"].ToString() != "")
                    {
                        model.username = dt.Rows[n]["username"].ToString();
                    }
                    if (dt.Rows[n]["password"] != null && dt.Rows[n]["password"].ToString() != "")
                    {
                        model.password = dt.Rows[n]["password"].ToString();
                    }
                    if (dt.Rows[n]["paypassword"] != null && dt.Rows[n]["paypassword"].ToString() != "")
                    {
                        model.paypassword = dt.Rows[n]["paypassword"].ToString();
                    }
                    if (dt.Rows[n]["passport"] != null && dt.Rows[n]["passport"].ToString() != "")
                    {
                        model.passport = dt.Rows[n]["passport"].ToString();
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = int.Parse(dt.Rows[n]["type"].ToString());
                    }
                    if (dt.Rows[n]["groupid"] != null && dt.Rows[n]["groupid"].ToString() != "")
                    {
                        model.groupid = int.Parse(dt.Rows[n]["groupid"].ToString());
                    }
                    if (dt.Rows[n]["sound"] != null && dt.Rows[n]["sound"].ToString() != "")
                    {
                        model.sound = dt.Rows[n]["sound"].ToString();
                    }
                    if (dt.Rows[n]["tname"] != null && dt.Rows[n]["tname"].ToString() != "")
                    {
                        model.tname = dt.Rows[n]["tname"].ToString();
                    }
                    if (dt.Rows[n]["email"] != null && dt.Rows[n]["email"].ToString() != "")
                    {
                        model.email = dt.Rows[n]["email"].ToString();
                    }
                    if (dt.Rows[n]["gender"] != null && dt.Rows[n]["gender"].ToString() != "")
                    {
                        model.gender = int.Parse(dt.Rows[n]["gender"].ToString());
                    }
                    if (dt.Rows[n]["mobile"] != null && dt.Rows[n]["mobile"].ToString() != "")
                    {
                        model.mobile = dt.Rows[n]["mobile"].ToString();
                    }
                    if (dt.Rows[n]["phone"] != null && dt.Rows[n]["phone"].ToString() != "")
                    {
                        model.phone = dt.Rows[n]["phone"].ToString();
                    }
                    if (dt.Rows[n]["msn"] != null && dt.Rows[n]["msn"].ToString() != "")
                    {
                        model.msn = dt.Rows[n]["msn"].ToString();
                    }
                    if (dt.Rows[n]["qq"] != null && dt.Rows[n]["qq"].ToString() != "")
                    {
                        model.qq = dt.Rows[n]["qq"].ToString();
                    }
                    if (dt.Rows[n]["skype"] != null && dt.Rows[n]["skype"].ToString() != "")
                    {
                        model.skype = dt.Rows[n]["skype"].ToString();
                    }
                    if (dt.Rows[n]["ali"] != null && dt.Rows[n]["ali"].ToString() != "")
                    {
                        model.ali = dt.Rows[n]["ali"].ToString();
                    }
                    if (dt.Rows[n]["birthdate"] != null && dt.Rows[n]["birthdate"].ToString() != "")
                    {
                        model.birthdate = DateTime.Parse(dt.Rows[n]["birthdate"].ToString());
                    }
                    if (dt.Rows[n]["areacode"] != null && dt.Rows[n]["areacode"].ToString() != "")
                    {
                        model.areacode = dt.Rows[n]["areacode"].ToString();
                    }
                    if (dt.Rows[n]["address"] != null && dt.Rows[n]["address"].ToString() != "")
                    {
                        model.address = dt.Rows[n]["address"].ToString();
                    }
                    if (dt.Rows[n]["department"] != null && dt.Rows[n]["department"].ToString() != "")
                    {
                        model.department = dt.Rows[n]["department"].ToString();
                    }
                    if (dt.Rows[n]["career"] != null && dt.Rows[n]["career"].ToString() != "")
                    {
                        model.career = dt.Rows[n]["career"].ToString();
                    }
                    if (dt.Rows[n]["sms"] != null && dt.Rows[n]["sms"].ToString() != "")
                    {
                        model.sms = decimal.Parse(dt.Rows[n]["sms"].ToString());
                    }
                    if (dt.Rows[n]["integral"] != null && dt.Rows[n]["integral"].ToString() != "")
                    {
                        model.integral = decimal.Parse(dt.Rows[n]["integral"].ToString());
                    }
                    if (dt.Rows[n]["money"] != null && dt.Rows[n]["money"].ToString() != "")
                    {
                        model.money = decimal.Parse(dt.Rows[n]["money"].ToString());
                    }
                    if (dt.Rows[n]["bank"] != null && dt.Rows[n]["bank"].ToString() != "")
                    {
                        model.bank = dt.Rows[n]["bank"].ToString();
                    }
                    if (dt.Rows[n]["account"] != null && dt.Rows[n]["account"].ToString() != "")
                    {
                        model.account = dt.Rows[n]["account"].ToString();
                    }
                    if (dt.Rows[n]["alipay"] != null && dt.Rows[n]["alipay"].ToString() != "")
                    {
                        model.alipay = dt.Rows[n]["alipay"].ToString();
                    }
                    if (dt.Rows[n]["regip"] != null && dt.Rows[n]["regip"].ToString() != "")
                    {
                        model.regip = dt.Rows[n]["regip"].ToString();
                    }
                    if (dt.Rows[n]["regtime"] != null && dt.Rows[n]["regtime"].ToString() != "")
                    {
                        model.regtime = DateTime.Parse(dt.Rows[n]["regtime"].ToString());
                    }
                    if (dt.Rows[n]["loginip"] != null && dt.Rows[n]["loginip"].ToString() != "")
                    {
                        model.loginip = dt.Rows[n]["loginip"].ToString();
                    }
                    if (dt.Rows[n]["logintime"] != null && dt.Rows[n]["logintime"].ToString() != "")
                    {
                        model.logintime = DateTime.Parse(dt.Rows[n]["logintime"].ToString());
                    }
                    if (dt.Rows[n]["logincount"] != null && dt.Rows[n]["logincount"].ToString() != "")
                    {
                        model.logincount = int.Parse(dt.Rows[n]["logincount"].ToString());
                    }
                    if (dt.Rows[n]["auth"] != null && dt.Rows[n]["auth"].ToString() != "")
                    {
                        model.auth = dt.Rows[n]["auth"].ToString();
                    }
                    if (dt.Rows[n]["authvalue"] != null && dt.Rows[n]["authvalue"].ToString() != "")
                    {
                        model.authvalue = dt.Rows[n]["authvalue"].ToString();
                    }
                    if (dt.Rows[n]["authtime"] != null && dt.Rows[n]["authtime"].ToString() != "")
                    {
                        model.authtime = DateTime.Parse(dt.Rows[n]["authtime"].ToString());
                    }
                    if (dt.Rows[n]["vemail"] != null && dt.Rows[n]["vemail"].ToString() != "")
                    {
                        model.vemail = int.Parse(dt.Rows[n]["vemail"].ToString());
                    }
                    if (dt.Rows[n]["vmobile"] != null && dt.Rows[n]["vmobile"].ToString() != "")
                    {
                        model.vmobile = int.Parse(dt.Rows[n]["vmobile"].ToString());
                    }
                    if (dt.Rows[n]["vname"] != null && dt.Rows[n]["vname"].ToString() != "")
                    {
                        model.vname = int.Parse(dt.Rows[n]["vname"].ToString());
                    }
                    if (dt.Rows[n]["vbank"] != null && dt.Rows[n]["vbank"].ToString() != "")
                    {
                        model.vbank = int.Parse(dt.Rows[n]["vbank"].ToString());
                    }
                    if (dt.Rows[n]["vcompany"] != null && dt.Rows[n]["vcompany"].ToString() != "")
                    {
                        model.vcompany = int.Parse(dt.Rows[n]["vcompany"].ToString());
                    }
                    if (dt.Rows[n]["valipay"] != null && dt.Rows[n]["valipay"].ToString() != "")
                    {
                        model.valipay = int.Parse(dt.Rows[n]["valipay"].ToString());
                    }
                    if (dt.Rows[n]["support"] != null && dt.Rows[n]["support"].ToString() != "")
                    {
                        model.support = dt.Rows[n]["support"].ToString();
                    }
                    if (dt.Rows[n]["inviter"] != null && dt.Rows[n]["inviter"].ToString() != "")
                    {
                        model.inviter = dt.Rows[n]["inviter"].ToString();
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["chat"] != null && dt.Rows[n]["chat"].ToString() != "")
                    {
                        model.chat = int.Parse(dt.Rows[n]["chat"].ToString());
                    }
                    if (dt.Rows[n]["message"] != null && dt.Rows[n]["message"].ToString() != "")
                    {
                        model.message = int.Parse(dt.Rows[n]["message"].ToString());
                    }
                    if (dt.Rows[n]["question"] != null && dt.Rows[n]["question"].ToString() != "")
                    {
                        model.question = int.Parse(dt.Rows[n]["question"].ToString());
                    }
                    if (dt.Rows[n]["answer"] != null && dt.Rows[n]["answer"].ToString() != "")
                    {
                        model.answer = dt.Rows[n]["answer"].ToString();
                    }
                    if (dt.Rows[n]["overprice"] != null && dt.Rows[n]["overprice"].ToString() != "")
                    {
                        model.overprice = TypeConverter.ObjToDeimal(dt.Rows[n]["overprice"].ToString());
                    }
                    if (dt.Rows[n]["useprice"] != null && dt.Rows[n]["useprice"].ToString() != "")
                    {
                        model.useprice = TypeConverter.ObjToDeimal(dt.Rows[n]["useprice"].ToString());
                    }
                    if (dt.Rows[n]["Isrecharge"] != null && dt.Rows[n]["Isrecharge"].ToString() != "")
                    {
                        model.Isrecharge = TypeConverter.StrToBool(dt.Rows[n]["Isrecharge"].ToString(), false);
                    }
                    if (dt.Rows[n]["RegStatcTime"] != null && dt.Rows[n]["RegStatcTime"].ToString() != "")
                    {
                        model.RegStatcTime = !string.IsNullOrEmpty(dt.Rows[n]["RegStatcTime"].ToString()) ? DateTime.Parse(dt.Rows[n]["RegStatcTime"].ToString()) : DateTime.Parse("0001/1/1 0:00:00");
                    }
                    if (dt.Rows[n]["RegEndTime"] != null && dt.Rows[n]["RegEndTime"].ToString() != "")
                    {
                        model.RegEndTime = DateTime.Parse(dt.Rows[n]["RegEndTime"].ToString());
                    }
                    if (dt.Rows[n]["vipLevel"] != null && dt.Rows[n]["vipLevel"].ToString() != "")
                    {
                        model.VipLevel = TypeConverter.StrToInt(dt.Rows[n]["vipLevel"].ToString());
                    }

                    if (dt.Rows[n]["shopid"] != null && dt.Rows[n]["shopid"].ToString() != "")
                    {
                        model.shopid = TypeConverter.StrToInt(dt.Rows[n]["shopid"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #region 获得回收站数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMember> GetMemberRecycleList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnMember> modelList = new List<EnMember>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBMemberRecycle, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnMember model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMember();
                    #region 赋值

                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["username"] != null && dt.Rows[n]["username"].ToString() != "")
                    {
                        model.username = dt.Rows[n]["username"].ToString();
                    }
                    if (dt.Rows[n]["password"] != null && dt.Rows[n]["password"].ToString() != "")
                    {
                        model.password = dt.Rows[n]["password"].ToString();
                    }
                    if (dt.Rows[n]["paypassword"] != null && dt.Rows[n]["paypassword"].ToString() != "")
                    {
                        model.paypassword = dt.Rows[n]["paypassword"].ToString();
                    }
                    if (dt.Rows[n]["passport"] != null && dt.Rows[n]["passport"].ToString() != "")
                    {
                        model.passport = dt.Rows[n]["passport"].ToString();
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = int.Parse(dt.Rows[n]["type"].ToString());
                    }
                    if (dt.Rows[n]["groupid"] != null && dt.Rows[n]["groupid"].ToString() != "")
                    {
                        model.groupid = int.Parse(dt.Rows[n]["groupid"].ToString());
                    }
                    if (dt.Rows[n]["sound"] != null && dt.Rows[n]["sound"].ToString() != "")
                    {
                        model.sound = dt.Rows[n]["sound"].ToString();
                    }
                    if (dt.Rows[n]["tname"] != null && dt.Rows[n]["tname"].ToString() != "")
                    {
                        model.tname = dt.Rows[n]["tname"].ToString();
                    }
                    if (dt.Rows[n]["email"] != null && dt.Rows[n]["email"].ToString() != "")
                    {
                        model.email = dt.Rows[n]["email"].ToString();
                    }
                    if (dt.Rows[n]["gender"] != null && dt.Rows[n]["gender"].ToString() != "")
                    {
                        model.gender = int.Parse(dt.Rows[n]["gender"].ToString());
                    }
                    if (dt.Rows[n]["mobile"] != null && dt.Rows[n]["mobile"].ToString() != "")
                    {
                        model.mobile = dt.Rows[n]["mobile"].ToString();
                    }
                    if (dt.Rows[n]["phone"] != null && dt.Rows[n]["phone"].ToString() != "")
                    {
                        model.phone = dt.Rows[n]["phone"].ToString();
                    }
                    if (dt.Rows[n]["msn"] != null && dt.Rows[n]["msn"].ToString() != "")
                    {
                        model.msn = dt.Rows[n]["msn"].ToString();
                    }
                    if (dt.Rows[n]["qq"] != null && dt.Rows[n]["qq"].ToString() != "")
                    {
                        model.qq = dt.Rows[n]["qq"].ToString();
                    }
                    if (dt.Rows[n]["skype"] != null && dt.Rows[n]["skype"].ToString() != "")
                    {
                        model.skype = dt.Rows[n]["skype"].ToString();
                    }
                    if (dt.Rows[n]["ali"] != null && dt.Rows[n]["ali"].ToString() != "")
                    {
                        model.ali = dt.Rows[n]["ali"].ToString();
                    }
                    if (dt.Rows[n]["birthdate"] != null && dt.Rows[n]["birthdate"].ToString() != "")
                    {
                        model.birthdate = DateTime.Parse(dt.Rows[n]["birthdate"].ToString());
                    }
                    if (dt.Rows[n]["areacode"] != null && dt.Rows[n]["areacode"].ToString() != "")
                    {
                        model.areacode = dt.Rows[n]["areacode"].ToString();
                    }
                    if (dt.Rows[n]["address"] != null && dt.Rows[n]["address"].ToString() != "")
                    {
                        model.address = dt.Rows[n]["address"].ToString();
                    }
                    if (dt.Rows[n]["department"] != null && dt.Rows[n]["department"].ToString() != "")
                    {
                        model.department = dt.Rows[n]["department"].ToString();
                    }
                    if (dt.Rows[n]["career"] != null && dt.Rows[n]["career"].ToString() != "")
                    {
                        model.career = dt.Rows[n]["career"].ToString();
                    }
                    if (dt.Rows[n]["sms"] != null && dt.Rows[n]["sms"].ToString() != "")
                    {
                        model.sms = decimal.Parse(dt.Rows[n]["sms"].ToString());
                    }
                    if (dt.Rows[n]["integral"] != null && dt.Rows[n]["integral"].ToString() != "")
                    {
                        model.integral = decimal.Parse(dt.Rows[n]["integral"].ToString());
                    }
                    if (dt.Rows[n]["money"] != null && dt.Rows[n]["money"].ToString() != "")
                    {
                        model.money = decimal.Parse(dt.Rows[n]["money"].ToString());
                    }
                    if (dt.Rows[n]["bank"] != null && dt.Rows[n]["bank"].ToString() != "")
                    {
                        model.bank = dt.Rows[n]["bank"].ToString();
                    }
                    if (dt.Rows[n]["account"] != null && dt.Rows[n]["account"].ToString() != "")
                    {
                        model.account = dt.Rows[n]["account"].ToString();
                    }
                    if (dt.Rows[n]["alipay"] != null && dt.Rows[n]["alipay"].ToString() != "")
                    {
                        model.alipay = dt.Rows[n]["alipay"].ToString();
                    }
                    if (dt.Rows[n]["regip"] != null && dt.Rows[n]["regip"].ToString() != "")
                    {
                        model.regip = dt.Rows[n]["regip"].ToString();
                    }
                    if (dt.Rows[n]["regtime"] != null && dt.Rows[n]["regtime"].ToString() != "")
                    {
                        model.regtime = DateTime.Parse(dt.Rows[n]["regtime"].ToString());
                    }
                    if (dt.Rows[n]["loginip"] != null && dt.Rows[n]["loginip"].ToString() != "")
                    {
                        model.loginip = dt.Rows[n]["loginip"].ToString();
                    }
                    if (dt.Rows[n]["logintime"] != null && dt.Rows[n]["logintime"].ToString() != "")
                    {
                        model.logintime = DateTime.Parse(dt.Rows[n]["logintime"].ToString());
                    }
                    if (dt.Rows[n]["logincount"] != null && dt.Rows[n]["logincount"].ToString() != "")
                    {
                        model.logincount = int.Parse(dt.Rows[n]["logincount"].ToString());
                    }
                    if (dt.Rows[n]["auth"] != null && dt.Rows[n]["auth"].ToString() != "")
                    {
                        model.auth = dt.Rows[n]["auth"].ToString();
                    }
                    if (dt.Rows[n]["authvalue"] != null && dt.Rows[n]["authvalue"].ToString() != "")
                    {
                        model.authvalue = dt.Rows[n]["authvalue"].ToString();
                    }
                    if (dt.Rows[n]["authtime"] != null && dt.Rows[n]["authtime"].ToString() != "")
                    {
                        model.authtime = DateTime.Parse(dt.Rows[n]["authtime"].ToString());
                    }
                    if (dt.Rows[n]["vemail"] != null && dt.Rows[n]["vemail"].ToString() != "")
                    {
                        model.vemail = int.Parse(dt.Rows[n]["vemail"].ToString());
                    }
                    if (dt.Rows[n]["vmobile"] != null && dt.Rows[n]["vmobile"].ToString() != "")
                    {
                        model.vmobile = int.Parse(dt.Rows[n]["vmobile"].ToString());
                    }
                    if (dt.Rows[n]["vname"] != null && dt.Rows[n]["vname"].ToString() != "")
                    {
                        model.vname = int.Parse(dt.Rows[n]["vname"].ToString());
                    }
                    if (dt.Rows[n]["vbank"] != null && dt.Rows[n]["vbank"].ToString() != "")
                    {
                        model.vbank = int.Parse(dt.Rows[n]["vbank"].ToString());
                    }
                    if (dt.Rows[n]["vcompany"] != null && dt.Rows[n]["vcompany"].ToString() != "")
                    {
                        model.vcompany = int.Parse(dt.Rows[n]["vcompany"].ToString());
                    }
                    if (dt.Rows[n]["valipay"] != null && dt.Rows[n]["valipay"].ToString() != "")
                    {
                        model.valipay = int.Parse(dt.Rows[n]["valipay"].ToString());
                    }
                    if (dt.Rows[n]["support"] != null && dt.Rows[n]["support"].ToString() != "")
                    {
                        model.support = dt.Rows[n]["support"].ToString();
                    }
                    if (dt.Rows[n]["inviter"] != null && dt.Rows[n]["inviter"].ToString() != "")
                    {
                        model.inviter = dt.Rows[n]["inviter"].ToString();
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["chat"] != null && dt.Rows[n]["chat"].ToString() != "")
                    {
                        model.chat = int.Parse(dt.Rows[n]["chat"].ToString());
                    }
                    if (dt.Rows[n]["message"] != null && dt.Rows[n]["message"].ToString() != "")
                    {
                        model.message = int.Parse(dt.Rows[n]["message"].ToString());
                    }
                    if (dt.Rows[n]["question"] != null && dt.Rows[n]["question"].ToString() != "")
                    {
                        model.question = int.Parse(dt.Rows[n]["question"].ToString());
                    }
                    if (dt.Rows[n]["answer"] != null && dt.Rows[n]["answer"].ToString() != "")
                    {
                        model.answer = dt.Rows[n]["answer"].ToString();
                    }
                    if (dt.Rows[n]["overprice"] != null && dt.Rows[n]["overprice"].ToString() != "")
                    {
                        model.overprice = TypeConverter.ObjToDeimal(dt.Rows[n]["overprice"].ToString());
                    }
                    if (dt.Rows[n]["useprice"] != null && dt.Rows[n]["useprice"].ToString() != "")
                    {
                        model.useprice = TypeConverter.ObjToDeimal(dt.Rows[n]["useprice"].ToString());
                    }
                    if (dt.Rows[n]["Isrecharge"] != null && dt.Rows[n]["Isrecharge"].ToString() != "")
                    {
                        model.Isrecharge = TypeConverter.StrToBool(dt.Rows[n]["Isrecharge"].ToString(), false);
                    }
                    if (dt.Rows[n]["RegStatcTime"] != null && dt.Rows[n]["RegStatcTime"].ToString() != "")
                    {
                        model.RegStatcTime = !string.IsNullOrEmpty(dt.Rows[n]["RegStatcTime"].ToString()) ? DateTime.Parse(dt.Rows[n]["RegStatcTime"].ToString()) : DateTime.Parse("0001/1/1 0:00:00");
                    }
                    if (dt.Rows[n]["RegEndTime"] != null && dt.Rows[n]["RegEndTime"].ToString() != "")
                    {
                        model.RegEndTime = DateTime.Parse(dt.Rows[n]["RegEndTime"].ToString());
                    }
                    if (dt.Rows[n]["vipLevel"] != null && dt.Rows[n]["vipLevel"].ToString() != "")
                    {
                        model.VipLevel = TypeConverter.StrToInt(dt.Rows[n]["vipLevel"].ToString());
                    }

                    if (dt.Rows[n]["shopid"] != null && dt.Rows[n]["shopid"].ToString() != "")
                    {
                        model.shopid = TypeConverter.StrToInt(dt.Rows[n]["shopid"].ToString());
                    }
                    modelList.Add(model);
                    #endregion

                }
            }
            return modelList;
        }
        #endregion

        public static List<EnMember> GetMemberList(string filed, string strWhere, string sort)
        {
            List<EnMember> modelList = new List<EnMember>();
            DataTable dt = DataCommon.GetDataTable(TableName.TBMember, filed, strWhere, sort);
            if (dt.Rows.Count > 0)
            {
                EnMember model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMember();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["username"] != null && dt.Rows[n]["username"].ToString() != "")
                    {
                        model.username = dt.Rows[n]["username"].ToString();
                    }
                    if (dt.Rows[n]["password"] != null && dt.Rows[n]["password"].ToString() != "")
                    {
                        model.password = dt.Rows[n]["password"].ToString();
                    }
                    if (dt.Rows[n]["paypassword"] != null && dt.Rows[n]["paypassword"].ToString() != "")
                    {
                        model.paypassword = dt.Rows[n]["paypassword"].ToString();
                    }
                    if (dt.Rows[n]["passport"] != null && dt.Rows[n]["passport"].ToString() != "")
                    {
                        model.passport = dt.Rows[n]["passport"].ToString();
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = int.Parse(dt.Rows[n]["type"].ToString());
                    }
                    if (dt.Rows[n]["groupid"] != null && dt.Rows[n]["groupid"].ToString() != "")
                    {
                        model.groupid = int.Parse(dt.Rows[n]["groupid"].ToString());
                    }
                    if (dt.Rows[n]["sound"] != null && dt.Rows[n]["sound"].ToString() != "")
                    {
                        model.sound = dt.Rows[n]["sound"].ToString();
                    }
                    if (dt.Rows[n]["tname"] != null && dt.Rows[n]["tname"].ToString() != "")
                    {
                        model.tname = dt.Rows[n]["tname"].ToString();
                    }
                    if (dt.Rows[n]["email"] != null && dt.Rows[n]["email"].ToString() != "")
                    {
                        model.email = dt.Rows[n]["email"].ToString();
                    }
                    if (dt.Rows[n]["gender"] != null && dt.Rows[n]["gender"].ToString() != "")
                    {
                        model.gender = int.Parse(dt.Rows[n]["gender"].ToString());
                    }
                    if (dt.Rows[n]["mobile"] != null && dt.Rows[n]["mobile"].ToString() != "")
                    {
                        model.mobile = dt.Rows[n]["mobile"].ToString();
                    }
                    if (dt.Rows[n]["phone"] != null && dt.Rows[n]["phone"].ToString() != "")
                    {
                        model.phone = dt.Rows[n]["phone"].ToString();
                    }
                    if (dt.Rows[n]["msn"] != null && dt.Rows[n]["msn"].ToString() != "")
                    {
                        model.msn = dt.Rows[n]["msn"].ToString();
                    }
                    if (dt.Rows[n]["qq"] != null && dt.Rows[n]["qq"].ToString() != "")
                    {
                        model.qq = dt.Rows[n]["qq"].ToString();
                    }
                    if (dt.Rows[n]["skype"] != null && dt.Rows[n]["skype"].ToString() != "")
                    {
                        model.skype = dt.Rows[n]["skype"].ToString();
                    }
                    if (dt.Rows[n]["ali"] != null && dt.Rows[n]["ali"].ToString() != "")
                    {
                        model.ali = dt.Rows[n]["ali"].ToString();
                    }
                    if (dt.Rows[n]["birthdate"] != null && dt.Rows[n]["birthdate"].ToString() != "")
                    {
                        model.birthdate = DateTime.Parse(dt.Rows[n]["birthdate"].ToString());
                    }
                    if (dt.Rows[n]["areacode"] != null && dt.Rows[n]["areacode"].ToString() != "")
                    {
                        model.areacode = dt.Rows[n]["areacode"].ToString();
                    }
                    if (dt.Rows[n]["address"] != null && dt.Rows[n]["address"].ToString() != "")
                    {
                        model.address = dt.Rows[n]["address"].ToString();
                    }
                    if (dt.Rows[n]["department"] != null && dt.Rows[n]["department"].ToString() != "")
                    {
                        model.department = dt.Rows[n]["department"].ToString();
                    }
                    if (dt.Rows[n]["career"] != null && dt.Rows[n]["career"].ToString() != "")
                    {
                        model.career = dt.Rows[n]["career"].ToString();
                    }
                    if (dt.Rows[n]["sms"] != null && dt.Rows[n]["sms"].ToString() != "")
                    {
                        model.sms = decimal.Parse(dt.Rows[n]["sms"].ToString());
                    }
                    if (dt.Rows[n]["integral"] != null && dt.Rows[n]["integral"].ToString() != "")
                    {
                        model.integral = decimal.Parse(dt.Rows[n]["integral"].ToString());
                    }
                    if (dt.Rows[n]["money"] != null && dt.Rows[n]["money"].ToString() != "")
                    {
                        model.money = decimal.Parse(dt.Rows[n]["money"].ToString());
                    }
                    if (dt.Rows[n]["bank"] != null && dt.Rows[n]["bank"].ToString() != "")
                    {
                        model.bank = dt.Rows[n]["bank"].ToString();
                    }
                    if (dt.Rows[n]["account"] != null && dt.Rows[n]["account"].ToString() != "")
                    {
                        model.account = dt.Rows[n]["account"].ToString();
                    }
                    if (dt.Rows[n]["alipay"] != null && dt.Rows[n]["alipay"].ToString() != "")
                    {
                        model.alipay = dt.Rows[n]["alipay"].ToString();
                    }
                    if (dt.Rows[n]["regip"] != null && dt.Rows[n]["regip"].ToString() != "")
                    {
                        model.regip = dt.Rows[n]["regip"].ToString();
                    }
                    if (dt.Rows[n]["regtime"] != null && dt.Rows[n]["regtime"].ToString() != "")
                    {
                        model.regtime = DateTime.Parse(dt.Rows[n]["regtime"].ToString());
                    }
                    if (dt.Rows[n]["loginip"] != null && dt.Rows[n]["loginip"].ToString() != "")
                    {
                        model.loginip = dt.Rows[n]["loginip"].ToString();
                    }
                    if (dt.Rows[n]["logintime"] != null && dt.Rows[n]["logintime"].ToString() != "")
                    {
                        model.logintime = DateTime.Parse(dt.Rows[n]["logintime"].ToString());
                    }
                    if (dt.Rows[n]["logincount"] != null && dt.Rows[n]["logincount"].ToString() != "")
                    {
                        model.logincount = int.Parse(dt.Rows[n]["logincount"].ToString());
                    }
                    if (dt.Rows[n]["auth"] != null && dt.Rows[n]["auth"].ToString() != "")
                    {
                        model.auth = dt.Rows[n]["auth"].ToString();
                    }
                    if (dt.Rows[n]["authvalue"] != null && dt.Rows[n]["authvalue"].ToString() != "")
                    {
                        model.authvalue = dt.Rows[n]["authvalue"].ToString();
                    }
                    if (dt.Rows[n]["authtime"] != null && dt.Rows[n]["authtime"].ToString() != "")
                    {
                        model.authtime = DateTime.Parse(dt.Rows[n]["authtime"].ToString());
                    }
                    if (dt.Rows[n]["vemail"] != null && dt.Rows[n]["vemail"].ToString() != "")
                    {
                        model.vemail = int.Parse(dt.Rows[n]["vemail"].ToString());
                    }
                    if (dt.Rows[n]["vmobile"] != null && dt.Rows[n]["vmobile"].ToString() != "")
                    {
                        model.vmobile = int.Parse(dt.Rows[n]["vmobile"].ToString());
                    }
                    if (dt.Rows[n]["vname"] != null && dt.Rows[n]["vname"].ToString() != "")
                    {
                        model.vname = int.Parse(dt.Rows[n]["vname"].ToString());
                    }
                    if (dt.Rows[n]["vbank"] != null && dt.Rows[n]["vbank"].ToString() != "")
                    {
                        model.vbank = int.Parse(dt.Rows[n]["vbank"].ToString());
                    }
                    if (dt.Rows[n]["vcompany"] != null && dt.Rows[n]["vcompany"].ToString() != "")
                    {
                        model.vcompany = int.Parse(dt.Rows[n]["vcompany"].ToString());
                    }
                    if (dt.Rows[n]["valipay"] != null && dt.Rows[n]["valipay"].ToString() != "")
                    {
                        model.valipay = int.Parse(dt.Rows[n]["valipay"].ToString());
                    }
                    if (dt.Rows[n]["support"] != null && dt.Rows[n]["support"].ToString() != "")
                    {
                        model.support = dt.Rows[n]["support"].ToString();
                    }
                    if (dt.Rows[n]["inviter"] != null && dt.Rows[n]["inviter"].ToString() != "")
                    {
                        model.inviter = dt.Rows[n]["inviter"].ToString();
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["chat"] != null && dt.Rows[n]["chat"].ToString() != "")
                    {
                        model.chat = int.Parse(dt.Rows[n]["chat"].ToString());
                    }
                    if (dt.Rows[n]["message"] != null && dt.Rows[n]["message"].ToString() != "")
                    {
                        model.message = int.Parse(dt.Rows[n]["message"].ToString());
                    }
                    if (dt.Rows[n]["question"] != null && dt.Rows[n]["question"].ToString() != "")
                    {
                        model.question = int.Parse(dt.Rows[n]["question"].ToString());
                    }
                    if (dt.Rows[n]["answer"] != null && dt.Rows[n]["answer"].ToString() != "")
                    {
                        model.answer = dt.Rows[n]["answer"].ToString();
                    }
                    if (dt.Rows[n]["overprice"] != null && dt.Rows[n]["overprice"].ToString() != "")
                    {
                        model.overprice = TypeConverter.ObjToDeimal(dt.Rows[n]["overprice"].ToString());
                    }
                    if (dt.Rows[n]["useprice"] != null && dt.Rows[n]["useprice"].ToString() != "")
                    {
                        model.useprice = TypeConverter.ObjToDeimal(dt.Rows[n]["useprice"].ToString());
                    }
                    if (dt.Rows[n]["Isrecharge"] != null && dt.Rows[n]["Isrecharge"].ToString() != "")
                    {
                        model.Isrecharge = TypeConverter.StrToBool(dt.Rows[n]["Isrecharge"].ToString(), false);
                    }
                    if (dt.Rows[n]["RegStatcTime"] != null && dt.Rows[n]["RegStatcTime"].ToString() != "")
                    {
                        model.RegStatcTime = TypeConverter.StrToDateTime(dt.Rows[n]["RegStatcTime"].ToString(), DateTime.Parse("0001/1/1 0:00:00"));
                    }
                    if (dt.Rows[n]["RegEndTime"] != null && dt.Rows[n]["RegEndTime"].ToString() != "")
                    {
                        model.RegEndTime = TypeConverter.StrToDateTime(dt.Rows[n]["RegEndTime"].ToString(), DateTime.Parse("0001/1/1 0:00:00"));
                    }
                    if (dt.Rows[n]["vipLevel"] != null && dt.Rows[n]["vipLevel"].ToString() != "")
                    {
                        model.VipLevel = TypeConverter.StrToInt(dt.Rows[n]["vipLevel"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #region 将子账号删除至回收站

        /// <summary>
        /// 将子账号删除至回收站
        /// </summary>
        /// <param name="userName">会员名</param>
        /// <param name="AccountId">账号id</param>
        /// <returns></returns>
        public static bool DelAccountToRecycle(string userName, string AccountId)
        {
            string Sql_DelAccountToRecycle = @"
               INSERT INTO t_memberrecycle (id,username,password,paypassword,passport,type,groupid,sound,tname,email,gender,mobile,phone,msn,qq,skype,ali,birthdate,areacode,address,department,career,sms,integral,money,bank,account,alipay,regip,regtime,loginip,logintime,logincount,auth,authvalue,authtime,vemail,vmobile,vname,vbank,vcompany,valipay,support,inviter,lastedittime,chat,message,question,answer,parentid,shopid) 
     SELECT id,username,password,paypassword,passport,type,groupid,sound,tname,email,gender,mobile,phone,msn,qq,skype,ali,birthdate,areacode,address,department,career,sms,integral,money,bank,account,alipay,regip,regtime,loginip,logintime,logincount,auth,authvalue,authtime,vemail,vmobile,vname,vbank,vcompany,valipay,support,inviter,lastedittime,chat,message,question,answer,parentid,shopid FROM t_member WHERE 
                username <> @username AND id IN (@AccountId) AND parentid IN (SELECT A.id FROM t_member A WHERE A.username=@userName);
                IF @@ERROR = 0
                   Begin
                       DELETE FROM t_member WHERE username <> @username AND id IN (@AccountId) AND parentid IN (SELECT A.id FROM t_member A WHERE A.username=@userName);
                   End
            ";
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@userName",SqlDbType.VarChar,50),
                new SqlParameter("@AccountId",SqlDbType.VarChar,500)
            };
            Parameter[0].Value = userName;
            Parameter[1].Value = AccountId;
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql_DelAccountToRecycle, Parameter) > 0;
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
            string Sql_RevertAccountRecycle = @"
               BEGIN TRANSACTION;
                SET IDENTITY_INSERT [dbo].[t_member] ON;
                INSERT INTO t_member (id,username,password,paypassword,passport,type,groupid,sound,tname,email,gender,mobile,phone,msn,qq,skype,ali,birthdate,areacode,address,department,career,sms,integral,money,bank,account,alipay,regip,regtime,loginip,logintime,logincount,auth,authvalue,authtime,vemail,vmobile,vname,vbank,vcompany,valipay,support,inviter,lastedittime,chat,message,question,answer,parentid,shopid) 
                SELECT id,username,password,paypassword,passport,type,groupid,sound,tname,email,gender,mobile,phone,msn,qq,skype,ali,birthdate,areacode,address,department,career,sms,integral,money,bank,account,alipay,regip,regtime,loginip,logintime,logincount,auth,authvalue,authtime,vemail,vmobile,vname,vbank,vcompany,valipay,support,inviter,lastedittime,chat,message,question,answer,parentid,shopid FROM t_memberrecycle WHERE 
                username <> @userName AND id IN (@AccountId) AND parentid IN (SELECT A.id FROM t_member A WHERE A.username=@userName);
                IF @@ERROR = 0
                   Begin
                       DELETE FROM t_memberrecycle WHERE username <> @userName AND id IN (@AccountId) AND parentid IN (SELECT A.id FROM t_member A WHERE A.username=@userName);
                   End
                SET IDENTITY_INSERT [dbo].[t_member] OFF;
               COMMIT TRANSACTION   
            ";
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@AccountId",SqlDbType.VarChar,500),
                new SqlParameter("@userName",SqlDbType.VarChar,50)
            };
            Parameter[0].Value = AccountId;
            Parameter[1].Value = userName;
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql_RevertAccountRecycle, Parameter) > 0;
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
            string Sql_DelAccountRecycle = @"
                DELETE FROM t_memberrecycle WHERE id IN (@AccountId) AND parentid IN (SELECT id FROM t_member WHERE username = @userName)
            ";
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@AccountId",SqlDbType.VarChar,500),
                new SqlParameter("@userName",SqlDbType.VarChar,50)
            };
            Parameter[0].Value = AccountId;
            Parameter[1].Value = userName;
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql_DelAccountRecycle, Parameter) > 0;
        }
        #endregion

        #endregion

        #region 共公模块-组

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMemberGroup(EnMemberGroup model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_membergroup(");
                strSql.Append("title,color,avatar,integral,money,permissions,lev,descript,sort)");
                strSql.Append(" values (");
                strSql.Append("@title,@color,@avatar,@integral,@money,@permissions,@lev,@descript,@sort)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@color", SqlDbType.Char,7),
					new SqlParameter("@avatar", SqlDbType.VarChar,40),
					new SqlParameter("@integral", SqlDbType.Decimal,9),
					new SqlParameter("@money", SqlDbType.Decimal,9),
					new SqlParameter("@permissions", SqlDbType.NText),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@sort", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.color;
                parameters[2].Value = model.avatar;
                parameters[3].Value = model.integral;
                parameters[4].Value = model.money;
                parameters[5].Value = model.permissions;
                parameters[6].Value = model.lev;
                parameters[7].Value = model.descript;
                parameters[8].Value = model.sort;



                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_membergroup set ");
                strSql.Append("title=@title,");
                strSql.Append("color=@color,");
                strSql.Append("avatar=@avatar,");
                strSql.Append("integral=@integral,");
                strSql.Append("money=@money,");
                strSql.Append("permissions=@permissions,");
                strSql.Append("lev=@lev,");
                strSql.Append("descript=@descript,");
                strSql.Append("sort=@sort");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@color", SqlDbType.Char,7),
					new SqlParameter("@avatar", SqlDbType.VarChar,40),
					new SqlParameter("@integral", SqlDbType.Decimal,9),
					new SqlParameter("@money", SqlDbType.Decimal,9),
					new SqlParameter("@permissions", SqlDbType.NText),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.color;
                parameters[2].Value = model.avatar;
                parameters[3].Value = model.integral;
                parameters[4].Value = model.money;
                parameters[5].Value = model.permissions;
                parameters[6].Value = model.lev;
                parameters[7].Value = model.descript;
                parameters[8].Value = model.sort;
                parameters[9].Value = model.id;

                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return model.id;
                }
            }

            return 0;

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnMemberGroup GetMemberGroupInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_MemberGroup ");
            strSql.Append(strWhere);


            EnMemberGroup model = new EnMemberGroup();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["color"] != null && reader["color"].ToString() != "")
                {
                    model.color = reader["color"].ToString();
                }
                if (reader["avatar"] != null && reader["avatar"].ToString() != "")
                {
                    model.avatar = reader["avatar"].ToString();
                }
                if (reader["integral"] != null && reader["integral"].ToString() != "")
                {
                    model.integral = decimal.Parse(reader["integral"].ToString());
                }
                if (reader["money"] != null && reader["money"].ToString() != "")
                {
                    model.money = decimal.Parse(reader["money"].ToString());
                }
                if (reader["permissions"] != null && reader["permissions"].ToString() != "")
                {
                    model.permissions = reader["permissions"].ToString();
                }
                if (reader["lev"] != null && reader["lev"].ToString() != "")
                {
                    model.lev = int.Parse(reader["lev"].ToString());
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }

                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                return model;
            }
            else
            {
                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMemberGroup> GetMemberGroupList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnMemberGroup> modelList = new List<EnMemberGroup>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBMemberGroup, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnMemberGroup model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMemberGroup();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["color"] != null && dt.Rows[n]["color"].ToString() != "")
                    {
                        model.color = dt.Rows[n]["color"].ToString();
                    }
                    if (dt.Rows[n]["avatar"] != null && dt.Rows[n]["avatar"].ToString() != "")
                    {
                        model.avatar = dt.Rows[n]["avatar"].ToString();
                    }
                    if (dt.Rows[n]["integral"] != null && dt.Rows[n]["integral"].ToString() != "")
                    {
                        model.integral = decimal.Parse(dt.Rows[n]["integral"].ToString());
                    }
                    if (dt.Rows[n]["money"] != null && dt.Rows[n]["money"].ToString() != "")
                    {
                        model.money = decimal.Parse(dt.Rows[n]["money"].ToString());
                    }
                    if (dt.Rows[n]["permissions"] != null && dt.Rows[n]["permissions"].ToString() != "")
                    {
                        model.permissions = dt.Rows[n]["permissions"].ToString();
                    }
                    if (dt.Rows[n]["lev"] != null && dt.Rows[n]["lev"].ToString() != "")
                    {
                        model.lev = int.Parse(dt.Rows[n]["lev"].ToString());
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion


        #region wengjie 用户登录
        //DataRow dr = DataCommon.GetDataRow(TableName.TBMember, "id,type,logincount,username,groupid", " where (username='" + name + "' or email='" + name + "' or mobile='" + name + "') and password='" + MyMD5.GetMD5(pwd) + "'", "");
        /// <summary>
        /// 供应商用户登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码md5加密后</param>
        /// <returns></returns>
        public static DataRow MemberLogin(string name, string pwd)
        {
            DataRow dr = null;
            string sqlstr = "select id,type,logincount,username,groupid from t_member where (username=@name or email=@name or mobile=@name) and password=@password";
            using (DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, sqlstr,
                new SqlParameter[] { new SqlParameter("@name", name), new SqlParameter("@password", pwd) }))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];
                }
            }
            return dr;
        }

        #endregion
    }
}
