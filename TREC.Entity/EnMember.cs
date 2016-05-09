using System;
namespace TREC.Entity
{
    /// <summary>
    /// admin:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class EnMember
    {
        public EnMember()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _password;
        private string _paypassword;
        private string _passport;
        private int _type;
        private int _groupid = 0;
        private string _sound;
        private string _tname;
        private string _email;
        private int? _gender;
        private string _mobile;
        private string _phone;
        private string _msn;
        private string _qq;
        private string _skype;
        private string _ali;
        private DateTime _birthdate;
        private string _areacode;
        private string _address;
        private string _department;
        private string _career;
        private decimal? _sms = 0M;
        private decimal? _integral = 0M;
        private decimal? _money = 0M;
        private string _bank;
        private string _account;
        private string _alipay;
        private string _regip;
        private DateTime? _regtime = DateTime.Now;
        private string _loginip;
        private DateTime? _logintime = DateTime.Now;
        private int? _logincount;
        private string _auth;
        private string _authvalue;
        private DateTime _authtime;
        private int? _vemail;
        private int? _vmobile;
        private int? _vname;
        private int? _vbank;
        private int? _vcompany;
        private int? _valipay;
        private string _support;
        private string _inviter;
        private DateTime? _lastedittime = DateTime.Now;
        private int? _chat;
        private int? _message;
        private int _question;
        private string _answer;
        private decimal _overprice;
        private decimal _useprice;
        private bool _isrecharge;
        private DateTime _regStatcTime;
        private DateTime _regEndTime;
        private int? _parentid;
        private int? _shopid;
        


        private int _vipLevel;

        /// <summary>
        /// 所属店铺id，子账号用
        /// </summary>
        public int? shopid
        {
            get { return _shopid; }
            set { _shopid = value; }
        }
        /// <summary>
        /// 父账号id
        /// </summary>
        public int? parentid
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// 会员等级
        /// </summary>
        public int VipLevel
        {
            get { return _vipLevel; }
            set { _vipLevel = value; }
        }

        /// <summary>
        /// 充值到期时间
        /// </summary>
        public DateTime RegEndTime
        {
            set { _regEndTime = value; }
            get { return _regEndTime; }
        }
        
        /// <summary>
        /// 最后充值时间
        /// </summary>
        public DateTime RegStatcTime
        {
            set { _regStatcTime = value; }
            get { return _regStatcTime; }
        }
        /// <summary>
        /// 是否充值
        /// </summary>
        public bool Isrecharge
        {
            set { _isrecharge = value; }
            get { return _isrecharge; }
        }
        /// <summary>
        /// 使用过的余额
        /// </summary>
        public decimal useprice
        {
            set { _useprice = value; }
            get { return _useprice; }
        }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal overprice
        {
            set { _overprice = value; }
            get { return _overprice; }
        }

        /// <summary>
        /// 回答
        /// </summary>
        public string answer
        {
            set { _answer = value; }
            get { return _answer; }
        }
        /// <summary>
        /// 提问
        /// </summary>
        public int question
        {
            set { _question = value; }
            get { return _question; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 登陆账号
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 支付密码
        /// </summary>
        public string paypassword
        {
            set { _paypassword = value; }
            get { return _paypassword; }
        }
        /// <summary>
        /// 通行证
        /// </summary>
        public string passport
        {
            set { _passport = value; }
            get { return _passport; }
        }
        /// <summary>
        /// 账号类型
        /// </summary>
        public int type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 会员组ID
        /// </summary>
        public int groupid
        {
            set { _groupid = value; }
            get { return _groupid; }
        }
        /// <summary>
        /// 提示音
        /// </summary>
        public string sound
        {
            set { _sound = value; }
            get { return _sound; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string tname
        {
            set { _tname = value; }
            get { return _tname; }
        }
        /// <summary>
        /// email
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public int? gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string msn
        {
            set { _msn = value; }
            get { return _msn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qq
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string skype
        {
            set { _skype = value; }
            get { return _skype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ali
        {
            set { _ali = value; }
            get { return _ali; }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime birthdate
        {
            set { _birthdate = value; }
            get { return _birthdate; }
        }
        /// <summary>
        /// 地区Code 
        /// </summary>
        public string areacode
        {
            set { _areacode = value; }
            get { return _areacode; }
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 职位
        /// </summary>
        public string career
        {
            set { _career = value; }
            get { return _career; }
        }
        /// <summary>
        /// 短信余额
        /// </summary>
        public decimal? sms
        {
            set { _sms = value; }
            get { return _sms; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public decimal? integral
        {
            set { _integral = value; }
            get { return _integral; }
        }
        /// <summary>
        /// 资金金额
        /// </summary>
        public decimal? money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 收款银行
        /// </summary>
        public string bank
        {
            set { _bank = value; }
            get { return _bank; }
        }
        /// <summary>
        /// 收款账号
        /// </summary>
        public string account
        {
            set { _account = value; }
            get { return _account; }
        }
        /// <summary>
        /// 支付宝账号
        /// </summary>
        public string alipay
        {
            set { _alipay = value; }
            get { return _alipay; }
        }
        /// <summary>
        /// 注册IP
        /// </summary>
        public string regip
        {
            set { _regip = value; }
            get { return _regip; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? regtime
        {
            set { _regtime = value; }
            get { return _regtime; }
        }
        /// <summary>
        /// 最后登陆IP
        /// </summary>
        public string loginip
        {
            set { _loginip = value; }
            get { return _loginip; }
        }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime? logintime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }
        /// <summary>
        /// 登陆次数
        /// </summary>
        public int? logincount
        {
            set { _logincount = value; }
            get { return _logincount; }
        }
        /// <summary>
        /// 授权认证(密钥)
        /// </summary>
        public string auth
        {
            set { _auth = value; }
            get { return _auth; }
        }
        /// <summary>
        /// 授权认证内容
        /// </summary>
        public string authvalue
        {
            set { _authvalue = value; }
            get { return _authvalue; }
        }
        /// <summary>
        /// 验证时间
        /// </summary>
        public DateTime authtime
        {
            set { _authtime = value; }
            get { return _authtime; }
        }
        /// <summary>
        /// 邮箱认证
        /// </summary>
        public int? vemail
        {
            set { _vemail = value; }
            get { return _vemail; }
        }
        /// <summary>
        /// 手机认证
        /// </summary>
        public int? vmobile
        {
            set { _vmobile = value; }
            get { return _vmobile; }
        }
        /// <summary>
        /// 实名认证
        /// </summary>
        public int? vname
        {
            set { _vname = value; }
            get { return _vname; }
        }
        /// <summary>
        /// 验证银行
        /// </summary>
        public int? vbank
        {
            set { _vbank = value; }
            get { return _vbank; }
        }
        /// <summary>
        /// 验证公司
        /// </summary>
        public int? vcompany
        {
            set { _vcompany = value; }
            get { return _vcompany; }
        }
        /// <summary>
        /// 验证支付宝
        /// </summary>
        public int? valipay
        {
            set { _valipay = value; }
            get { return _valipay; }
        }
        /// <summary>
        /// 客服专员
        /// </summary>
        public string support
        {
            set { _support = value; }
            get { return _support; }
        }
        /// <summary>
        /// 推荐人(限定为用户名)
        /// </summary>
        public string inviter
        {
            set { _inviter = value; }
            get { return _inviter; }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? lastedittime
        {
            set { _lastedittime = value; }
            get { return _lastedittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? chat
        {
            set { _chat = value; }
            get { return _chat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? message
        {
            set { _message = value; }
            get { return _message; }
        }
        #endregion Model

    }
}

