namespace Haojibiz.Model {
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data;
    using System.Data.Linq.Mapping;
    using System.Collections.Generic;
    using System.Reflection;
    using System.ComponentModel;
    using Haojibiz.Data;
    
    /// <summary>
    /// 管理员
    /// </summary>
    [Table(Name="t_admin")]
    [Serializable()]
    [DisplayName("管理员")]
    [Description("管理员")]
    public partial class Madmin : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 登陆名
        /// </summary>
        String _name;
        /// <summary>
        /// 登陆密码MD5
        /// </summary>
        String _password;
        /// <summary>
        /// 显示名称
        /// </summary>
        String _displayname;
        /// <summary>
        /// 安全问题
        /// </summary>
        String _question;
        /// <summary>
        /// 答案
        /// </summary>
        String _answer;
        /// <summary>
        /// 邮件
        /// </summary>
        String _email;
        /// <summary>
        /// 电话
        /// </summary>
        String _phone;
        /// <summary>
        /// 地区
        /// </summary>
        String _areacode;
        /// <summary>
        /// 地址
        /// </summary>
        String _address;
        /// <summary>
        /// 登陆次数
        /// </summary>
        Int32? _logincount;
        /// <summary>
        /// 锁定
        /// </summary>
        Int32 _islock;
        /// <summary>
        /// 最后活动模块
        /// </summary>
        String _lastmodule;
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime _createdate;
        /// <summary>
        /// 最后活动时间
        /// </summary>
        DateTime _lastactivitydate;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 name 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnnameChanging(String value);
        /// <summary>
        /// 当 name 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnnameChanged();
        /// <summary>
        /// 当 password 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpasswordChanging(String value);
        /// <summary>
        /// 当 password 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpasswordChanged();
        /// <summary>
        /// 当 displayname 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndisplaynameChanging(String value);
        /// <summary>
        /// 当 displayname 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndisplaynameChanged();
        /// <summary>
        /// 当 question 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnquestionChanging(String value);
        /// <summary>
        /// 当 question 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnquestionChanged();
        /// <summary>
        /// 当 answer 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnanswerChanging(String value);
        /// <summary>
        /// 当 answer 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnanswerChanged();
        /// <summary>
        /// 当 email 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnemailChanging(String value);
        /// <summary>
        /// 当 email 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnemailChanged();
        /// <summary>
        /// 当 phone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnphoneChanging(String value);
        /// <summary>
        /// 当 phone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnphoneChanged();
        /// <summary>
        /// 当 areacode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnareacodeChanging(String value);
        /// <summary>
        /// 当 areacode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnareacodeChanged();
        /// <summary>
        /// 当 address 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaddressChanging(String value);
        /// <summary>
        /// 当 address 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaddressChanged();
        /// <summary>
        /// 当 logincount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlogincountChanging(Int32? value);
        /// <summary>
        /// 当 logincount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlogincountChanged();
        /// <summary>
        /// 当 islock 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnislockChanging(Int32 value);
        /// <summary>
        /// 当 islock 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnislockChanged();
        /// <summary>
        /// 当 lastmodule 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastmoduleChanging(String value);
        /// <summary>
        /// 当 lastmodule 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastmoduleChanged();
        /// <summary>
        /// 当 createdate 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatedateChanging(DateTime value);
        /// <summary>
        /// 当 createdate 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatedateChanged();
        /// <summary>
        /// 当 lastactivitydate 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastactivitydateChanging(DateTime value);
        /// <summary>
        /// 当 lastactivitydate 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastactivitydateChanged();
        
        /// <summary>
        /// 初始化 Madmin 实体类的新实例。
        /// </summary>
        public Madmin() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 登陆名
        /// </summary>
        [Column(Storage="_name", DbType="nvarchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName("登陆名")]
        [Description("登陆名")]
        public String name {
            get {
                return this._name;
            }
            set {
                this.OnnameChanging(value);
                this.SendPropertyChanging("name", value);
                this._name = value;
                this.SendPropertyChanged("name", value);
                this.OnnameChanged();
            }
        }
        /// <summary>
        /// 登陆密码MD5
        /// </summary>
        [Column(Storage="_password", DbType="char(32) NOT NULL", CanBeNull=false)]
        [DisplayName("登陆密码MD5")]
        [Description("登陆密码MD5")]
        public String password {
            get {
                return this._password;
            }
            set {
                this.OnpasswordChanging(value);
                this.SendPropertyChanging("password", value);
                this._password = value;
                this.SendPropertyChanged("password", value);
                this.OnpasswordChanged();
            }
        }
        /// <summary>
        /// 显示名称
        /// </summary>
        [Column(Storage="_displayname", DbType="nvarchar(25)")]
        [DisplayName("显示名称")]
        [Description("显示名称")]
        public String displayname {
            get {
                return this._displayname;
            }
            set {
                if ((this._displayname != value)) {
                    this.OndisplaynameChanging(value);
                    this.SendPropertyChanging("displayname", value);
                    this._displayname = value;
                    this.SendPropertyChanged("displayname", value);
                    this.OndisplaynameChanged();
                }
            }
        }
        /// <summary>
        /// 安全问题
        /// </summary>
        [Column(Storage="_question", DbType="nvarchar(30)")]
        [DisplayName("安全问题")]
        [Description("安全问题")]
        public String question {
            get {
                return this._question;
            }
            set {
                if ((this._question != value)) {
                    this.OnquestionChanging(value);
                    this.SendPropertyChanging("question", value);
                    this._question = value;
                    this.SendPropertyChanged("question", value);
                    this.OnquestionChanged();
                }
            }
        }
        /// <summary>
        /// 答案
        /// </summary>
        [Column(Storage="_answer", DbType="nvarchar(30)")]
        [DisplayName("答案")]
        [Description("答案")]
        public String answer {
            get {
                return this._answer;
            }
            set {
                if ((this._answer != value)) {
                    this.OnanswerChanging(value);
                    this.SendPropertyChanging("answer", value);
                    this._answer = value;
                    this.SendPropertyChanged("answer", value);
                    this.OnanswerChanged();
                }
            }
        }
        /// <summary>
        /// 邮件
        /// </summary>
        [Column(Storage="_email", DbType="varchar(30) NOT NULL", CanBeNull=false)]
        [DisplayName("邮件")]
        [Description("邮件")]
        public String email {
            get {
                return this._email;
            }
            set {
                this.OnemailChanging(value);
                this.SendPropertyChanging("email", value);
                this._email = value;
                this.SendPropertyChanged("email", value);
                this.OnemailChanged();
            }
        }
        /// <summary>
        /// 电话
        /// </summary>
        [Column(Storage="_phone", DbType="varchar(30)")]
        [DisplayName("电话")]
        [Description("电话")]
        public String phone {
            get {
                return this._phone;
            }
            set {
                if ((this._phone != value)) {
                    this.OnphoneChanging(value);
                    this.SendPropertyChanging("phone", value);
                    this._phone = value;
                    this.SendPropertyChanged("phone", value);
                    this.OnphoneChanged();
                }
            }
        }
        /// <summary>
        /// 地区
        /// </summary>
        [Column(Storage="_areacode", DbType="varchar(10)")]
        [DisplayName("地区")]
        [Description("地区")]
        public String areacode {
            get {
                return this._areacode;
            }
            set {
                if ((this._areacode != value)) {
                    this.OnareacodeChanging(value);
                    this.SendPropertyChanging("areacode", value);
                    this._areacode = value;
                    this.SendPropertyChanged("areacode", value);
                    this.OnareacodeChanged();
                }
            }
        }
        /// <summary>
        /// 地址
        /// </summary>
        [Column(Storage="_address", DbType="nvarchar(50)")]
        [DisplayName("地址")]
        [Description("地址")]
        public String address {
            get {
                return this._address;
            }
            set {
                if ((this._address != value)) {
                    this.OnaddressChanging(value);
                    this.SendPropertyChanging("address", value);
                    this._address = value;
                    this.SendPropertyChanged("address", value);
                    this.OnaddressChanged();
                }
            }
        }
        /// <summary>
        /// 登陆次数
        /// </summary>
        [Column(Storage="_logincount", DbType="int")]
        [DisplayName("登陆次数")]
        [Description("登陆次数")]
        public Int32? logincount {
            get {
                return this._logincount;
            }
            set {
                if ((this._logincount != value)) {
                    this.OnlogincountChanging(value);
                    this.SendPropertyChanging("logincount", value);
                    this._logincount = value;
                    this.SendPropertyChanged("logincount", value);
                    this.OnlogincountChanged();
                }
            }
        }
        /// <summary>
        /// 锁定
        /// </summary>
        [Column(Storage="_islock", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("锁定")]
        [Description("锁定")]
        public Int32 islock {
            get {
                return this._islock;
            }
            set {
                this.OnislockChanging(value);
                this.SendPropertyChanging("islock", value);
                this._islock = value;
                this.SendPropertyChanged("islock", value);
                this.OnislockChanged();
            }
        }
        /// <summary>
        /// 最后活动模块
        /// </summary>
        [Column(Storage="_lastmodule", DbType="nvarchar(50)")]
        [DisplayName("最后活动模块")]
        [Description("最后活动模块")]
        public String lastmodule {
            get {
                return this._lastmodule;
            }
            set {
                if ((this._lastmodule != value)) {
                    this.OnlastmoduleChanging(value);
                    this.SendPropertyChanging("lastmodule", value);
                    this._lastmodule = value;
                    this.SendPropertyChanged("lastmodule", value);
                    this.OnlastmoduleChanged();
                }
            }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Storage="_createdate", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        public DateTime createdate {
            get {
                return this._createdate;
            }
            set {
                this.OncreatedateChanging(value);
                this.SendPropertyChanging("createdate", value);
                this._createdate = value;
                this.SendPropertyChanged("createdate", value);
                this.OncreatedateChanged();
            }
        }
        /// <summary>
        /// 最后活动时间
        /// </summary>
        [Column(Storage="_lastactivitydate", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最后活动时间")]
        [Description("最后活动时间")]
        public DateTime lastactivitydate {
            get {
                return this._lastactivitydate;
            }
            set {
                this.OnlastactivitydateChanging(value);
                this.SendPropertyChanging("lastactivitydate", value);
                this._lastactivitydate = value;
                this.SendPropertyChanged("lastactivitydate", value);
                this.OnlastactivitydateChanged();
            }
        }
    }
    /// <summary>
    /// 广告表
    /// </summary>
    [Table(Name="t_advertising")]
    [Serializable()]
    [DisplayName("广告表")]
    [Description("广告表")]
    public partial class Madvertising : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 广告类别ID
        /// </summary>
        Int32 _categoryid;
        /// <summary>
        /// 广告名称
        /// </summary>
        String _title;
        /// <summary>
        /// 广告连接
        /// </summary>
        String _linkurl;
        /// <summary>
        /// Flash地址
        /// </summary>
        String _flashurl;
        /// <summary>
        /// 图片地址
        /// </summary>
        String _imgurl;
        /// <summary>
        /// 视频地址
        /// </summary>
        String _videourl;
        /// <summary>
        /// 文字广告内容
        /// </summary>
        String _adtext;
        /// <summary>
        /// 广告代码(JS广告)
        /// </summary>
        String _adcode;
        /// <summary>
        /// 是否启用
        /// </summary>
        Int32? _isopen;
        /// <summary>
        /// 广告联系人
        /// </summary>
        String _adlinkman;
        /// <summary>
        /// 广告联系电话
        /// </summary>
        String _adlinkphone;
        /// <summary>
        /// 联系邮件
        /// </summary>
        String _adlinkemail;
        /// <summary>
        /// 修改时间
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        /// 修改人
        /// </summary>
        Int32 _lasteditaid;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 categoryid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncategoryidChanging(Int32 value);
        /// <summary>
        /// 当 categoryid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncategoryidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 linkurl 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinkurlChanging(String value);
        /// <summary>
        /// 当 linkurl 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinkurlChanged();
        /// <summary>
        /// 当 flashurl 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnflashurlChanging(String value);
        /// <summary>
        /// 当 flashurl 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnflashurlChanged();
        /// <summary>
        /// 当 imgurl 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnimgurlChanging(String value);
        /// <summary>
        /// 当 imgurl 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnimgurlChanged();
        /// <summary>
        /// 当 videourl 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvideourlChanging(String value);
        /// <summary>
        /// 当 videourl 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvideourlChanged();
        /// <summary>
        /// 当 adtext 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadtextChanging(String value);
        /// <summary>
        /// 当 adtext 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadtextChanged();
        /// <summary>
        /// 当 adcode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadcodeChanging(String value);
        /// <summary>
        /// 当 adcode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadcodeChanged();
        /// <summary>
        /// 当 isopen 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnisopenChanging(Int32? value);
        /// <summary>
        /// 当 isopen 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnisopenChanged();
        /// <summary>
        /// 当 adlinkman 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadlinkmanChanging(String value);
        /// <summary>
        /// 当 adlinkman 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadlinkmanChanged();
        /// <summary>
        /// 当 adlinkphone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadlinkphoneChanging(String value);
        /// <summary>
        /// 当 adlinkphone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadlinkphoneChanged();
        /// <summary>
        /// 当 adlinkemail 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadlinkemailChanging(String value);
        /// <summary>
        /// 当 adlinkemail 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadlinkemailChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        /// <summary>
        /// 当 lasteditaid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlasteditaidChanging(Int32 value);
        /// <summary>
        /// 当 lasteditaid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlasteditaidChanged();
        
        /// <summary>
        /// 初始化 Madvertising 实体类的新实例。
        /// </summary>
        public Madvertising() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 广告类别ID
        /// </summary>
        [Column(Storage="_categoryid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("广告类别ID")]
        [Description("广告类别ID")]
        public Int32 categoryid {
            get {
                return this._categoryid;
            }
            set {
                this.OncategoryidChanging(value);
                this.SendPropertyChanging("categoryid", value);
                this._categoryid = value;
                this.SendPropertyChanged("categoryid", value);
                this.OncategoryidChanged();
            }
        }
        /// <summary>
        /// 广告名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("广告名称")]
        [Description("广告名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 广告连接
        /// </summary>
        [Column(Storage="_linkurl", DbType="varchar(100)")]
        [DisplayName("广告连接")]
        [Description("广告连接")]
        public String linkurl {
            get {
                return this._linkurl;
            }
            set {
                if ((this._linkurl != value)) {
                    this.OnlinkurlChanging(value);
                    this.SendPropertyChanging("linkurl", value);
                    this._linkurl = value;
                    this.SendPropertyChanged("linkurl", value);
                    this.OnlinkurlChanged();
                }
            }
        }
        /// <summary>
        /// Flash地址
        /// </summary>
        [Column(Storage="_flashurl", DbType="varchar(100)")]
        [DisplayName("Flash地址")]
        [Description("Flash地址")]
        public String flashurl {
            get {
                return this._flashurl;
            }
            set {
                if ((this._flashurl != value)) {
                    this.OnflashurlChanging(value);
                    this.SendPropertyChanging("flashurl", value);
                    this._flashurl = value;
                    this.SendPropertyChanged("flashurl", value);
                    this.OnflashurlChanged();
                }
            }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        [Column(Storage="_imgurl", DbType="varchar(100)")]
        [DisplayName("图片地址")]
        [Description("图片地址")]
        public String imgurl {
            get {
                return this._imgurl;
            }
            set {
                if ((this._imgurl != value)) {
                    this.OnimgurlChanging(value);
                    this.SendPropertyChanging("imgurl", value);
                    this._imgurl = value;
                    this.SendPropertyChanged("imgurl", value);
                    this.OnimgurlChanged();
                }
            }
        }
        /// <summary>
        /// 视频地址
        /// </summary>
        [Column(Storage="_videourl", DbType="varchar(100)")]
        [DisplayName("视频地址")]
        [Description("视频地址")]
        public String videourl {
            get {
                return this._videourl;
            }
            set {
                if ((this._videourl != value)) {
                    this.OnvideourlChanging(value);
                    this.SendPropertyChanging("videourl", value);
                    this._videourl = value;
                    this.SendPropertyChanged("videourl", value);
                    this.OnvideourlChanged();
                }
            }
        }
        /// <summary>
        /// 文字广告内容
        /// </summary>
        [Column(Storage="_adtext", DbType="nvarchar(2000)")]
        [DisplayName("文字广告内容")]
        [Description("文字广告内容")]
        public String adtext {
            get {
                return this._adtext;
            }
            set {
                if ((this._adtext != value)) {
                    this.OnadtextChanging(value);
                    this.SendPropertyChanging("adtext", value);
                    this._adtext = value;
                    this.SendPropertyChanged("adtext", value);
                    this.OnadtextChanged();
                }
            }
        }
        /// <summary>
        /// 广告代码(JS广告)
        /// </summary>
        [Column(Storage="_adcode", DbType="varchar(2000)")]
        [DisplayName("广告代码(JS广告)")]
        [Description("广告代码(JS广告)")]
        public String adcode {
            get {
                return this._adcode;
            }
            set {
                if ((this._adcode != value)) {
                    this.OnadcodeChanging(value);
                    this.SendPropertyChanging("adcode", value);
                    this._adcode = value;
                    this.SendPropertyChanged("adcode", value);
                    this.OnadcodeChanged();
                }
            }
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Column(Storage="_isopen", DbType="int")]
        [DisplayName("是否启用")]
        [Description("是否启用")]
        public Int32? isopen {
            get {
                return this._isopen;
            }
            set {
                if ((this._isopen != value)) {
                    this.OnisopenChanging(value);
                    this.SendPropertyChanging("isopen", value);
                    this._isopen = value;
                    this.SendPropertyChanged("isopen", value);
                    this.OnisopenChanged();
                }
            }
        }
        /// <summary>
        /// 广告联系人
        /// </summary>
        [Column(Storage="_adlinkman", DbType="nvarchar(20)")]
        [DisplayName("广告联系人")]
        [Description("广告联系人")]
        public String adlinkman {
            get {
                return this._adlinkman;
            }
            set {
                if ((this._adlinkman != value)) {
                    this.OnadlinkmanChanging(value);
                    this.SendPropertyChanging("adlinkman", value);
                    this._adlinkman = value;
                    this.SendPropertyChanged("adlinkman", value);
                    this.OnadlinkmanChanged();
                }
            }
        }
        /// <summary>
        /// 广告联系电话
        /// </summary>
        [Column(Storage="_adlinkphone", DbType="nvarchar(20)")]
        [DisplayName("广告联系电话")]
        [Description("广告联系电话")]
        public String adlinkphone {
            get {
                return this._adlinkphone;
            }
            set {
                if ((this._adlinkphone != value)) {
                    this.OnadlinkphoneChanging(value);
                    this.SendPropertyChanging("adlinkphone", value);
                    this._adlinkphone = value;
                    this.SendPropertyChanged("adlinkphone", value);
                    this.OnadlinkphoneChanged();
                }
            }
        }
        /// <summary>
        /// 联系邮件
        /// </summary>
        [Column(Storage="_adlinkemail", DbType="nvarchar(20)")]
        [DisplayName("联系邮件")]
        [Description("联系邮件")]
        public String adlinkemail {
            get {
                return this._adlinkemail;
            }
            set {
                if ((this._adlinkemail != value)) {
                    this.OnadlinkemailChanging(value);
                    this.SendPropertyChanging("adlinkemail", value);
                    this._adlinkemail = value;
                    this.SendPropertyChanged("adlinkemail", value);
                    this.OnadlinkemailChanged();
                }
            }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("修改时间")]
        [Description("修改时间")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        [Column(Storage="_lasteditaid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("修改人")]
        [Description("修改人")]
        public Int32 lasteditaid {
            get {
                return this._lasteditaid;
            }
            set {
                this.OnlasteditaidChanging(value);
                this.SendPropertyChanging("lasteditaid", value);
                this._lasteditaid = value;
                this.SendPropertyChanged("lasteditaid", value);
                this.OnlasteditaidChanged();
            }
        }
    }
    /// <summary>
    /// 广告分类
    /// </summary>
    [Table(Name="t_advertisingcategory")]
    [Serializable()]
    [DisplayName("广告分类")]
    [Description("广告分类")]
    public partial class Madvertisingcategory : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 上级分类
        /// </summary>
        Int32 _parentid;
        /// <summary>
        /// 所属模块
        /// </summary>
        Int32 _moduleid;
        /// <summary>
        /// 所属模块value
        /// </summary>
        String _modulevalue;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 所属位置描述图片
        /// </summary>
        String _img;
        /// <summary>
        /// 高
        /// </summary>
        Int32 _height;
        /// <summary>
        /// 宽
        /// </summary>
        Int32 _width;
        /// <summary>
        /// 是否启用
        /// </summary>
        Int32? _isopen;
        /// <summary>
        /// 广告类型（文字、视频、图片 ……）
        /// </summary>
        Int32 _adtype;
        /// <summary>
        /// 开始时间
        /// </summary>
        DateTime? _starttime;
        /// <summary>
        /// 结束时间
        /// </summary>
        DateTime? _endtime;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 模版
        /// </summary>
        String _template;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 parentid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnparentidChanging(Int32 value);
        /// <summary>
        /// 当 parentid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnparentidChanged();
        /// <summary>
        /// 当 moduleid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmoduleidChanging(Int32 value);
        /// <summary>
        /// 当 moduleid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmoduleidChanged();
        /// <summary>
        /// 当 modulevalue 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmodulevalueChanging(String value);
        /// <summary>
        /// 当 modulevalue 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmodulevalueChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 img 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnimgChanging(String value);
        /// <summary>
        /// 当 img 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnimgChanged();
        /// <summary>
        /// 当 height 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnheightChanging(Int32 value);
        /// <summary>
        /// 当 height 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnheightChanged();
        /// <summary>
        /// 当 width 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnwidthChanging(Int32 value);
        /// <summary>
        /// 当 width 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnwidthChanged();
        /// <summary>
        /// 当 isopen 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnisopenChanging(Int32? value);
        /// <summary>
        /// 当 isopen 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnisopenChanged();
        /// <summary>
        /// 当 adtype 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadtypeChanging(Int32 value);
        /// <summary>
        /// 当 adtype 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadtypeChanged();
        /// <summary>
        /// 当 starttime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstarttimeChanging(DateTime? value);
        /// <summary>
        /// 当 starttime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstarttimeChanged();
        /// <summary>
        /// 当 endtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnendtimeChanging(DateTime? value);
        /// <summary>
        /// 当 endtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnendtimeChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 template 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntemplateChanging(String value);
        /// <summary>
        /// 当 template 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntemplateChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Madvertisingcategory 实体类的新实例。
        /// </summary>
        public Madvertisingcategory() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 上级分类
        /// </summary>
        [Column(Storage="_parentid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("上级分类")]
        [Description("上级分类")]
        public Int32 parentid {
            get {
                return this._parentid;
            }
            set {
                this.OnparentidChanging(value);
                this.SendPropertyChanging("parentid", value);
                this._parentid = value;
                this.SendPropertyChanged("parentid", value);
                this.OnparentidChanged();
            }
        }
        /// <summary>
        /// 所属模块
        /// </summary>
        [Column(Storage="_moduleid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("所属模块")]
        [Description("所属模块")]
        public Int32 moduleid {
            get {
                return this._moduleid;
            }
            set {
                this.OnmoduleidChanging(value);
                this.SendPropertyChanging("moduleid", value);
                this._moduleid = value;
                this.SendPropertyChanged("moduleid", value);
                this.OnmoduleidChanged();
            }
        }
        /// <summary>
        /// 所属模块value
        /// </summary>
        [Column(Storage="_modulevalue", DbType="nvarchar(50)")]
        [DisplayName("所属模块value")]
        [Description("所属模块value")]
        public String modulevalue {
            get {
                return this._modulevalue;
            }
            set {
                if ((this._modulevalue != value)) {
                    this.OnmodulevalueChanging(value);
                    this.SendPropertyChanging("modulevalue", value);
                    this._modulevalue = value;
                    this.SendPropertyChanged("modulevalue", value);
                    this.OnmodulevalueChanged();
                }
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 所属位置描述图片
        /// </summary>
        [Column(Storage="_img", DbType="varchar(50)")]
        [DisplayName("所属位置描述图片")]
        [Description("所属位置描述图片")]
        public String img {
            get {
                return this._img;
            }
            set {
                if ((this._img != value)) {
                    this.OnimgChanging(value);
                    this.SendPropertyChanging("img", value);
                    this._img = value;
                    this.SendPropertyChanged("img", value);
                    this.OnimgChanged();
                }
            }
        }
        /// <summary>
        /// 高
        /// </summary>
        [Column(Storage="_height", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("高")]
        [Description("高")]
        public Int32 height {
            get {
                return this._height;
            }
            set {
                this.OnheightChanging(value);
                this.SendPropertyChanging("height", value);
                this._height = value;
                this.SendPropertyChanged("height", value);
                this.OnheightChanged();
            }
        }
        /// <summary>
        /// 宽
        /// </summary>
        [Column(Storage="_width", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("宽")]
        [Description("宽")]
        public Int32 width {
            get {
                return this._width;
            }
            set {
                this.OnwidthChanging(value);
                this.SendPropertyChanging("width", value);
                this._width = value;
                this.SendPropertyChanged("width", value);
                this.OnwidthChanged();
            }
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Column(Storage="_isopen", DbType="int")]
        [DisplayName("是否启用")]
        [Description("是否启用")]
        public Int32? isopen {
            get {
                return this._isopen;
            }
            set {
                if ((this._isopen != value)) {
                    this.OnisopenChanging(value);
                    this.SendPropertyChanging("isopen", value);
                    this._isopen = value;
                    this.SendPropertyChanged("isopen", value);
                    this.OnisopenChanged();
                }
            }
        }
        /// <summary>
        /// 广告类型（文字、视频、图片 ……）
        /// </summary>
        [Column(Storage="_adtype", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("广告类型（文字、视频、图片 ……）")]
        [Description("广告类型（文字、视频、图片 ……）")]
        public Int32 adtype {
            get {
                return this._adtype;
            }
            set {
                this.OnadtypeChanging(value);
                this.SendPropertyChanging("adtype", value);
                this._adtype = value;
                this.SendPropertyChanged("adtype", value);
                this.OnadtypeChanged();
            }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Column(Storage="_starttime", DbType="datetime")]
        [DisplayName("开始时间")]
        [Description("开始时间")]
        public DateTime? starttime {
            get {
                return this._starttime;
            }
            set {
                if ((this._starttime != value)) {
                    this.OnstarttimeChanging(value);
                    this.SendPropertyChanging("starttime", value);
                    this._starttime = value;
                    this.SendPropertyChanged("starttime", value);
                    this.OnstarttimeChanged();
                }
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Column(Storage="_endtime", DbType="datetime")]
        [DisplayName("结束时间")]
        [Description("结束时间")]
        public DateTime? endtime {
            get {
                return this._endtime;
            }
            set {
                if ((this._endtime != value)) {
                    this.OnendtimeChanging(value);
                    this.SendPropertyChanging("endtime", value);
                    this._endtime = value;
                    this.SendPropertyChanged("endtime", value);
                    this.OnendtimeChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="nchar(10)")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 模版
        /// </summary>
        [Column(Storage="_template", DbType="nvarchar(2000)")]
        [DisplayName("模版")]
        [Description("模版")]
        public String template {
            get {
                return this._template;
            }
            set {
                if ((this._template != value)) {
                    this.OntemplateChanging(value);
                    this.SendPropertyChanging("template", value);
                    this._template = value;
                    this.SendPropertyChanged("template", value);
                    this.OntemplateChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    /// 聚合信息
    /// </summary>
    [Table(Name="t_aggregation")]
    [Serializable()]
    [DisplayName("聚合信息")]
    [Description("聚合信息")]
    public partial class Maggregation : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 信息所属模块（type表ID）
        /// </summary>
        Int32? _type;
        /// <summary>
        /// 显示文字1
        /// </summary>
        String _title;
        /// <summary>
        /// 显示文字2
        /// </summary>
        String _title1;
        /// <summary>
        /// 显示文字3
        /// </summary>
        String _title2;
        /// <summary>
        /// 显示文字4
        /// </summary>
        String _title3;
        /// <summary>
        /// 显示图片
        /// </summary>
        String _thumb;
        /// <summary>
        /// 图片高
        /// </summary>
        Int32? _thumbw;
        /// <summary>
        /// 图片高
        /// </summary>
        Int32? _thumbh;
        /// <summary>
        /// 幻灯图
        /// </summary>
        String _bannel;
        /// <summary>
        /// 连接1
        /// </summary>
        String _url;
        /// <summary>
        /// 连接2
        /// </summary>
        String _url1;
        /// <summary>
        /// 连接3
        /// </summary>
        String _url2;
        /// <summary>
        /// 描述内容
        /// </summary>
        String _descript;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 点击率
        /// </summary>
        Int32? _hits;
        /// <summary>
        /// 最改时间
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        /// 添加时间
        /// </summary>
        Int32? _createmid;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 type 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntypeChanging(Int32? value);
        /// <summary>
        /// 当 type 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntypeChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 title1 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void Ontitle1Changing(String value);
        /// <summary>
        /// 当 title1 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void Ontitle1Changed();
        /// <summary>
        /// 当 title2 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void Ontitle2Changing(String value);
        /// <summary>
        /// 当 title2 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void Ontitle2Changed();
        /// <summary>
        /// 当 title3 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void Ontitle3Changing(String value);
        /// <summary>
        /// 当 title3 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void Ontitle3Changed();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 thumbw 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbwChanging(Int32? value);
        /// <summary>
        /// 当 thumbw 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbwChanged();
        /// <summary>
        /// 当 thumbh 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbhChanging(Int32? value);
        /// <summary>
        /// 当 thumbh 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbhChanged();
        /// <summary>
        /// 当 bannel 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannelChanging(String value);
        /// <summary>
        /// 当 bannel 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannelChanged();
        /// <summary>
        /// 当 url 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnurlChanging(String value);
        /// <summary>
        /// 当 url 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnurlChanged();
        /// <summary>
        /// 当 url1 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void Onurl1Changing(String value);
        /// <summary>
        /// 当 url1 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void Onurl1Changed();
        /// <summary>
        /// 当 url2 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void Onurl2Changing(String value);
        /// <summary>
        /// 当 url2 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void Onurl2Changed();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 hits 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhitsChanging(Int32? value);
        /// <summary>
        /// 当 hits 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhitsChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        /// <summary>
        /// 当 createmid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatemidChanging(Int32? value);
        /// <summary>
        /// 当 createmid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatemidChanged();
        
        /// <summary>
        /// 初始化 Maggregation 实体类的新实例。
        /// </summary>
        public Maggregation() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 信息所属模块（type表ID）
        /// </summary>
        [Column(Storage="_type", DbType="int")]
        [DisplayName("信息所属模块（type表ID）")]
        [Description("信息所属模块（type表ID）")]
        public Int32? type {
            get {
                return this._type;
            }
            set {
                if ((this._type != value)) {
                    this.OntypeChanging(value);
                    this.SendPropertyChanging("type", value);
                    this._type = value;
                    this.SendPropertyChanged("type", value);
                    this.OntypeChanged();
                }
            }
        }
        /// <summary>
        /// 显示文字1
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(120)")]
        [DisplayName("显示文字1")]
        [Description("显示文字1")]
        public String title {
            get {
                return this._title;
            }
            set {
                if ((this._title != value)) {
                    this.OntitleChanging(value);
                    this.SendPropertyChanging("title", value);
                    this._title = value;
                    this.SendPropertyChanged("title", value);
                    this.OntitleChanged();
                }
            }
        }
        /// <summary>
        /// 显示文字2
        /// </summary>
        [Column(Storage="_title1", DbType="nvarchar(50)")]
        [DisplayName("显示文字2")]
        [Description("显示文字2")]
        public String title1 {
            get {
                return this._title1;
            }
            set {
                if ((this._title1 != value)) {
                    this.Ontitle1Changing(value);
                    this.SendPropertyChanging("title1", value);
                    this._title1 = value;
                    this.SendPropertyChanged("title1", value);
                    this.Ontitle1Changed();
                }
            }
        }
        /// <summary>
        /// 显示文字3
        /// </summary>
        [Column(Storage="_title2", DbType="nvarchar(50)")]
        [DisplayName("显示文字3")]
        [Description("显示文字3")]
        public String title2 {
            get {
                return this._title2;
            }
            set {
                if ((this._title2 != value)) {
                    this.Ontitle2Changing(value);
                    this.SendPropertyChanging("title2", value);
                    this._title2 = value;
                    this.SendPropertyChanged("title2", value);
                    this.Ontitle2Changed();
                }
            }
        }
        /// <summary>
        /// 显示文字4
        /// </summary>
        [Column(Storage="_title3", DbType="nvarchar(50)")]
        [DisplayName("显示文字4")]
        [Description("显示文字4")]
        public String title3 {
            get {
                return this._title3;
            }
            set {
                if ((this._title3 != value)) {
                    this.Ontitle3Changing(value);
                    this.SendPropertyChanging("title3", value);
                    this._title3 = value;
                    this.SendPropertyChanged("title3", value);
                    this.Ontitle3Changed();
                }
            }
        }
        /// <summary>
        /// 显示图片
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(50)")]
        [DisplayName("显示图片")]
        [Description("显示图片")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        /// 图片高
        /// </summary>
        [Column(Storage="_thumbw", DbType="int")]
        [DisplayName("图片高")]
        [Description("图片高")]
        public Int32? thumbw {
            get {
                return this._thumbw;
            }
            set {
                if ((this._thumbw != value)) {
                    this.OnthumbwChanging(value);
                    this.SendPropertyChanging("thumbw", value);
                    this._thumbw = value;
                    this.SendPropertyChanged("thumbw", value);
                    this.OnthumbwChanged();
                }
            }
        }
        /// <summary>
        /// 图片高
        /// </summary>
        [Column(Storage="_thumbh", DbType="int")]
        [DisplayName("图片高")]
        [Description("图片高")]
        public Int32? thumbh {
            get {
                return this._thumbh;
            }
            set {
                if ((this._thumbh != value)) {
                    this.OnthumbhChanging(value);
                    this.SendPropertyChanging("thumbh", value);
                    this._thumbh = value;
                    this.SendPropertyChanged("thumbh", value);
                    this.OnthumbhChanged();
                }
            }
        }
        /// <summary>
        /// 幻灯图
        /// </summary>
        [Column(Storage="_bannel", DbType="varchar(400)")]
        [DisplayName("幻灯图")]
        [Description("幻灯图")]
        public String bannel {
            get {
                return this._bannel;
            }
            set {
                if ((this._bannel != value)) {
                    this.OnbannelChanging(value);
                    this.SendPropertyChanging("bannel", value);
                    this._bannel = value;
                    this.SendPropertyChanged("bannel", value);
                    this.OnbannelChanged();
                }
            }
        }
        /// <summary>
        /// 连接1
        /// </summary>
        [Column(Storage="_url", DbType="varchar(50)")]
        [DisplayName("连接1")]
        [Description("连接1")]
        public String url {
            get {
                return this._url;
            }
            set {
                if ((this._url != value)) {
                    this.OnurlChanging(value);
                    this.SendPropertyChanging("url", value);
                    this._url = value;
                    this.SendPropertyChanged("url", value);
                    this.OnurlChanged();
                }
            }
        }
        /// <summary>
        /// 连接2
        /// </summary>
        [Column(Storage="_url1", DbType="varchar(50)")]
        [DisplayName("连接2")]
        [Description("连接2")]
        public String url1 {
            get {
                return this._url1;
            }
            set {
                if ((this._url1 != value)) {
                    this.Onurl1Changing(value);
                    this.SendPropertyChanging("url1", value);
                    this._url1 = value;
                    this.SendPropertyChanged("url1", value);
                    this.Onurl1Changed();
                }
            }
        }
        /// <summary>
        /// 连接3
        /// </summary>
        [Column(Storage="_url2", DbType="varchar(50)")]
        [DisplayName("连接3")]
        [Description("连接3")]
        public String url2 {
            get {
                return this._url2;
            }
            set {
                if ((this._url2 != value)) {
                    this.Onurl2Changing(value);
                    this.SendPropertyChanging("url2", value);
                    this._url2 = value;
                    this.SendPropertyChanged("url2", value);
                    this.Onurl2Changed();
                }
            }
        }
        /// <summary>
        /// 描述内容
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(250)")]
        [DisplayName("描述内容")]
        [Description("描述内容")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 点击率
        /// </summary>
        [Column(Storage="_hits", DbType="int")]
        [DisplayName("点击率")]
        [Description("点击率")]
        public Int32? hits {
            get {
                return this._hits;
            }
            set {
                if ((this._hits != value)) {
                    this.OnhitsChanging(value);
                    this.SendPropertyChanging("hits", value);
                    this._hits = value;
                    this.SendPropertyChanged("hits", value);
                    this.OnhitsChanged();
                }
            }
        }
        /// <summary>
        /// 最改时间
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最改时间")]
        [Description("最改时间")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Column(Storage="_createmid", DbType="int")]
        [DisplayName("添加时间")]
        [Description("添加时间")]
        public Int32? createmid {
            get {
                return this._createmid;
            }
            set {
                if ((this._createmid != value)) {
                    this.OncreatemidChanging(value);
                    this.SendPropertyChanging("createmid", value);
                    this._createmid = value;
                    this.SendPropertyChanged("createmid", value);
                    this.OncreatemidChanged();
                }
            }
        }
    }
    /// <summary>
    /// 信息所属模块
    /// </summary>
    [Table(Name="t_aggregationtype")]
    [Serializable()]
    [DisplayName("信息所属模块")]
    [Description("信息所属模块")]
    public partial class Maggregationtype : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 上级模块
        /// </summary>
        Int32? _parentid;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 名称1
        /// </summary>
        String _title1;
        /// <summary>
        /// 缩略图
        /// </summary>
        String _thumb;
        /// <summary>
        /// 连接
        /// </summary>
        String _url;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 parentid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnparentidChanging(Int32? value);
        /// <summary>
        /// 当 parentid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnparentidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 title1 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void Ontitle1Changing(String value);
        /// <summary>
        /// 当 title1 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void Ontitle1Changed();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 url 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnurlChanging(String value);
        /// <summary>
        /// 当 url 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnurlChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Maggregationtype 实体类的新实例。
        /// </summary>
        public Maggregationtype() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 上级模块
        /// </summary>
        [Column(Storage="_parentid", DbType="int")]
        [DisplayName("上级模块")]
        [Description("上级模块")]
        public Int32? parentid {
            get {
                return this._parentid;
            }
            set {
                if ((this._parentid != value)) {
                    this.OnparentidChanging(value);
                    this.SendPropertyChanging("parentid", value);
                    this._parentid = value;
                    this.SendPropertyChanged("parentid", value);
                    this.OnparentidChanged();
                }
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(120) NOT NULL", CanBeNull=false)]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 名称1
        /// </summary>
        [Column(Storage="_title1", DbType="nvarchar(50)")]
        [DisplayName("名称1")]
        [Description("名称1")]
        public String title1 {
            get {
                return this._title1;
            }
            set {
                if ((this._title1 != value)) {
                    this.Ontitle1Changing(value);
                    this.SendPropertyChanging("title1", value);
                    this._title1 = value;
                    this.SendPropertyChanged("title1", value);
                    this.Ontitle1Changed();
                }
            }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(400)")]
        [DisplayName("缩略图")]
        [Description("缩略图")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        /// 连接
        /// </summary>
        [Column(Storage="_url", DbType="varchar(100)")]
        [DisplayName("连接")]
        [Description("连接")]
        public String url {
            get {
                return this._url;
            }
            set {
                if ((this._url != value)) {
                    this.OnurlChanging(value);
                    this.SendPropertyChanging("url", value);
                    this._url = value;
                    this.SendPropertyChanged("url", value);
                    this.OnurlChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    /// 经销商、店铺品牌使用申请表
    /// </summary>
    [Table(Name="t_appbrand")]
    [Serializable()]
    [DisplayName("经销商、店铺品牌使用申请表")]
    [Description("经销商、店铺品牌使用申请表")]
    public partial class Mappbrand : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 经销商ID
        /// </summary>
        Int32 _dealerid;
        /// <summary>
        /// 经销商名称
        /// </summary>
        String _dealetitle;
        /// <summary>
        /// 品牌ID
        /// </summary>
        Int32 _brandid;
        /// <summary>
        /// 品牌名称
        /// </summary>
        String _brandtitle;
        /// <summary>
        /// 品牌所属厂家ID
        /// </summary>
        Int32 _companyid;
        /// <summary>
        /// 品牌所属厂家名称
        /// </summary>
        String _companytitle;
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        Int32? _shopid;
        /// <summary>
        /// 所属店铺名称
        /// </summary>
        String _shoptitle;
        /// <summary>
        ///  
        /// </summary>
        Int32 _appmodule;
        /// <summary>
        ///  
        /// </summary>
        Int32 _apptype;
        /// <summary>
        ///  
        /// </summary>
        DateTime _apptime;
        /// <summary>
        ///  
        /// </summary>
        Int32 _createmid;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        /// 状态
        /// </summary>
        Int32 _auditstatus;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 dealerid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndealeridChanging(Int32 value);
        /// <summary>
        /// 当 dealerid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndealeridChanged();
        /// <summary>
        /// 当 dealetitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndealetitleChanging(String value);
        /// <summary>
        /// 当 dealetitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndealetitleChanged();
        /// <summary>
        /// 当 brandid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandidChanging(Int32 value);
        /// <summary>
        /// 当 brandid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandidChanged();
        /// <summary>
        /// 当 brandtitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandtitleChanging(String value);
        /// <summary>
        /// 当 brandtitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandtitleChanged();
        /// <summary>
        /// 当 companyid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncompanyidChanging(Int32 value);
        /// <summary>
        /// 当 companyid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncompanyidChanged();
        /// <summary>
        /// 当 companytitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncompanytitleChanging(String value);
        /// <summary>
        /// 当 companytitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncompanytitleChanged();
        /// <summary>
        /// 当 shopid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshopidChanging(Int32? value);
        /// <summary>
        /// 当 shopid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshopidChanged();
        /// <summary>
        /// 当 shoptitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshoptitleChanging(String value);
        /// <summary>
        /// 当 shoptitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshoptitleChanged();
        /// <summary>
        /// 当 appmodule 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnappmoduleChanging(Int32 value);
        /// <summary>
        /// 当 appmodule 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnappmoduleChanged();
        /// <summary>
        /// 当 apptype 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnapptypeChanging(Int32 value);
        /// <summary>
        /// 当 apptype 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnapptypeChanged();
        /// <summary>
        /// 当 apptime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnapptimeChanging(DateTime value);
        /// <summary>
        /// 当 apptime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnapptimeChanged();
        /// <summary>
        /// 当 createmid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatemidChanging(Int32 value);
        /// <summary>
        /// 当 createmid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatemidChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        /// <summary>
        /// 当 auditstatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauditstatusChanging(Int32 value);
        /// <summary>
        /// 当 auditstatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauditstatusChanged();
        
        /// <summary>
        /// 初始化 Mappbrand 实体类的新实例。
        /// </summary>
        public Mappbrand() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 经销商ID
        /// </summary>
        [Column(Storage="_dealerid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("经销商ID")]
        [Description("经销商ID")]
        public Int32 dealerid {
            get {
                return this._dealerid;
            }
            set {
                this.OndealeridChanging(value);
                this.SendPropertyChanging("dealerid", value);
                this._dealerid = value;
                this.SendPropertyChanged("dealerid", value);
                this.OndealeridChanged();
            }
        }
        /// <summary>
        /// 经销商名称
        /// </summary>
        [Column(Storage="_dealetitle", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("经销商名称")]
        [Description("经销商名称")]
        public String dealetitle {
            get {
                return this._dealetitle;
            }
            set {
                this.OndealetitleChanging(value);
                this.SendPropertyChanging("dealetitle", value);
                this._dealetitle = value;
                this.SendPropertyChanged("dealetitle", value);
                this.OndealetitleChanged();
            }
        }
        /// <summary>
        /// 品牌ID
        /// </summary>
        [Column(Storage="_brandid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("品牌ID")]
        [Description("品牌ID")]
        public Int32 brandid {
            get {
                return this._brandid;
            }
            set {
                this.OnbrandidChanging(value);
                this.SendPropertyChanging("brandid", value);
                this._brandid = value;
                this.SendPropertyChanged("brandid", value);
                this.OnbrandidChanged();
            }
        }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [Column(Storage="_brandtitle", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("品牌名称")]
        [Description("品牌名称")]
        public String brandtitle {
            get {
                return this._brandtitle;
            }
            set {
                this.OnbrandtitleChanging(value);
                this.SendPropertyChanging("brandtitle", value);
                this._brandtitle = value;
                this.SendPropertyChanged("brandtitle", value);
                this.OnbrandtitleChanged();
            }
        }
        /// <summary>
        /// 品牌所属厂家ID
        /// </summary>
        [Column(Storage="_companyid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("品牌所属厂家ID")]
        [Description("品牌所属厂家ID")]
        public Int32 companyid {
            get {
                return this._companyid;
            }
            set {
                this.OncompanyidChanging(value);
                this.SendPropertyChanging("companyid", value);
                this._companyid = value;
                this.SendPropertyChanged("companyid", value);
                this.OncompanyidChanged();
            }
        }
        /// <summary>
        /// 品牌所属厂家名称
        /// </summary>
        [Column(Storage="_companytitle", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("品牌所属厂家名称")]
        [Description("品牌所属厂家名称")]
        public String companytitle {
            get {
                return this._companytitle;
            }
            set {
                this.OncompanytitleChanging(value);
                this.SendPropertyChanging("companytitle", value);
                this._companytitle = value;
                this.SendPropertyChanged("companytitle", value);
                this.OncompanytitleChanged();
            }
        }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        [Column(Storage="_shopid", DbType="int")]
        [DisplayName("所属店铺ID")]
        [Description("所属店铺ID")]
        public Int32? shopid {
            get {
                return this._shopid;
            }
            set {
                if ((this._shopid != value)) {
                    this.OnshopidChanging(value);
                    this.SendPropertyChanging("shopid", value);
                    this._shopid = value;
                    this.SendPropertyChanged("shopid", value);
                    this.OnshopidChanged();
                }
            }
        }
        /// <summary>
        /// 所属店铺名称
        /// </summary>
        [Column(Storage="_shoptitle", DbType="nvarchar(50)")]
        [DisplayName("所属店铺名称")]
        [Description("所属店铺名称")]
        public String shoptitle {
            get {
                return this._shoptitle;
            }
            set {
                if ((this._shoptitle != value)) {
                    this.OnshoptitleChanging(value);
                    this.SendPropertyChanging("shoptitle", value);
                    this._shoptitle = value;
                    this.SendPropertyChanged("shoptitle", value);
                    this.OnshoptitleChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_appmodule", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 appmodule {
            get {
                return this._appmodule;
            }
            set {
                this.OnappmoduleChanging(value);
                this.SendPropertyChanging("appmodule", value);
                this._appmodule = value;
                this.SendPropertyChanged("appmodule", value);
                this.OnappmoduleChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_apptype", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 apptype {
            get {
                return this._apptype;
            }
            set {
                this.OnapptypeChanging(value);
                this.SendPropertyChanging("apptype", value);
                this._apptype = value;
                this.SendPropertyChanged("apptype", value);
                this.OnapptypeChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_apptime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public DateTime apptime {
            get {
                return this._apptime;
            }
            set {
                this.OnapptimeChanging(value);
                this.SendPropertyChanging("apptime", value);
                this._apptime = value;
                this.SendPropertyChanged("apptime", value);
                this.OnapptimeChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_createmid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 createmid {
            get {
                return this._createmid;
            }
            set {
                this.OncreatemidChanging(value);
                this.SendPropertyChanging("createmid", value);
                this._createmid = value;
                this.SendPropertyChanged("createmid", value);
                this.OncreatemidChanged();
            }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最后修改时间")]
        [Description("最后修改时间")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
        /// <summary>
        /// 状态
        /// </summary>
        [Column(Storage="_auditstatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("状态")]
        [Description("状态")]
        public Int32 auditstatus {
            get {
                return this._auditstatus;
            }
            set {
                this.OnauditstatusChanging(value);
                this.SendPropertyChanging("auditstatus", value);
                this._auditstatus = value;
                this.SendPropertyChanged("auditstatus", value);
                this.OnauditstatusChanged();
            }
        }
    }
    /// <summary>
    ///  
    /// </summary>
    [Table(Name="t_appbrandcustomer")]
    [Serializable()]
    [DisplayName(" ")]
    [Description(" ")]
    public partial class Mappbrandcustomer : DALModelBase {
        /// <summary>
        ///  
        /// </summary>
        Int32 _id;
        /// <summary>
        ///  
        /// </summary>
        Int32? _aid;
        /// <summary>
        ///  
        /// </summary>
        String _name;
        /// <summary>
        ///  
        /// </summary>
        String _phone;
        /// <summary>
        ///  
        /// </summary>
        String _mphone;
        /// <summary>
        ///  
        /// </summary>
        String _email;
        /// <summary>
        ///  
        /// </summary>
        String _address;
        /// <summary>
        ///  
        /// </summary>
        String _descript;
        /// <summary>
        ///  
        /// </summary>
        String _cus;
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? _CreateTime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 aid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaidChanging(Int32? value);
        /// <summary>
        /// 当 aid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaidChanged();
        /// <summary>
        /// 当 name 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnnameChanging(String value);
        /// <summary>
        /// 当 name 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnnameChanged();
        /// <summary>
        /// 当 phone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnphoneChanging(String value);
        /// <summary>
        /// 当 phone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnphoneChanged();
        /// <summary>
        /// 当 mphone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmphoneChanging(String value);
        /// <summary>
        /// 当 mphone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmphoneChanged();
        /// <summary>
        /// 当 email 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnemailChanging(String value);
        /// <summary>
        /// 当 email 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnemailChanged();
        /// <summary>
        /// 当 address 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaddressChanging(String value);
        /// <summary>
        /// 当 address 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaddressChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 cus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncusChanging(String value);
        /// <summary>
        /// 当 cus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncusChanged();
        /// <summary>
        /// 当 CreateTime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnCreateTimeChanging(DateTime? value);
        /// <summary>
        /// 当 CreateTime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnCreateTimeChanged();
        
        /// <summary>
        /// 初始化 Mappbrandcustomer 实体类的新实例。
        /// </summary>
        public Mappbrandcustomer() {
            this.OnCreated();
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_aid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? aid {
            get {
                return this._aid;
            }
            set {
                if ((this._aid != value)) {
                    this.OnaidChanging(value);
                    this.SendPropertyChanging("aid", value);
                    this._aid = value;
                    this.SendPropertyChanged("aid", value);
                    this.OnaidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_name", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String name {
            get {
                return this._name;
            }
            set {
                if ((this._name != value)) {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging("name", value);
                    this._name = value;
                    this.SendPropertyChanged("name", value);
                    this.OnnameChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_phone", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String phone {
            get {
                return this._phone;
            }
            set {
                if ((this._phone != value)) {
                    this.OnphoneChanging(value);
                    this.SendPropertyChanging("phone", value);
                    this._phone = value;
                    this.SendPropertyChanged("phone", value);
                    this.OnphoneChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_mphone", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String mphone {
            get {
                return this._mphone;
            }
            set {
                if ((this._mphone != value)) {
                    this.OnmphoneChanging(value);
                    this.SendPropertyChanging("mphone", value);
                    this._mphone = value;
                    this.SendPropertyChanged("mphone", value);
                    this.OnmphoneChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_email", DbType="varchar(30)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String email {
            get {
                return this._email;
            }
            set {
                if ((this._email != value)) {
                    this.OnemailChanging(value);
                    this.SendPropertyChanging("email", value);
                    this._email = value;
                    this.SendPropertyChanged("email", value);
                    this.OnemailChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_address", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String address {
            get {
                return this._address;
            }
            set {
                if ((this._address != value)) {
                    this.OnaddressChanging(value);
                    this.SendPropertyChanging("address", value);
                    this._address = value;
                    this.SendPropertyChanged("address", value);
                    this.OnaddressChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(600)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_cus", DbType="ntext")]
        [DisplayName(" ")]
        [Description(" ")]
        public String cus {
            get {
                return this._cus;
            }
            set {
                if ((this._cus != value)) {
                    this.OncusChanging(value);
                    this.SendPropertyChanging("cus", value);
                    this._cus = value;
                    this.SendPropertyChanged("cus", value);
                    this.OncusChanged();
                }
            }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Storage="_CreateTime", DbType="datetime")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        public DateTime? CreateTime {
            get {
                return this._CreateTime;
            }
            set {
                if ((this._CreateTime != value)) {
                    this.OnCreateTimeChanging(value);
                    this.SendPropertyChanging("CreateTime", value);
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime", value);
                    this.OnCreateTimeChanged();
                }
            }
        }
    }
    /// <summary>
    /// 地区表
    /// </summary>
    [Table(Name="t_area")]
    [Serializable()]
    [DisplayName("地区表")]
    [Description("地区表")]
    public partial class Marea : DALModelBase {
        /// <summary>
        /// 地区代码
        /// </summary>
        String _areacode;
        /// <summary>
        /// 上级代码
        /// </summary>
        String _parentcode;
        /// <summary>
        /// 地区名称
        /// </summary>
        String _areaname;
        /// <summary>
        /// 邮篇
        /// </summary>
        String _areazipcode;
        /// <summary>
        /// 所属地区组(华东/华南等)
        /// </summary>
        String _grouparea;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 areacode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnareacodeChanging(String value);
        /// <summary>
        /// 当 areacode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnareacodeChanged();
        /// <summary>
        /// 当 parentcode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnparentcodeChanging(String value);
        /// <summary>
        /// 当 parentcode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnparentcodeChanged();
        /// <summary>
        /// 当 areaname 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnareanameChanging(String value);
        /// <summary>
        /// 当 areaname 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnareanameChanged();
        /// <summary>
        /// 当 areazipcode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnareazipcodeChanging(String value);
        /// <summary>
        /// 当 areazipcode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnareazipcodeChanged();
        /// <summary>
        /// 当 grouparea 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OngroupareaChanging(String value);
        /// <summary>
        /// 当 grouparea 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OngroupareaChanged();
        
        /// <summary>
        /// 初始化 Marea 实体类的新实例。
        /// </summary>
        public Marea() {
            this.OnCreated();
        }
        /// <summary>
        /// 地区代码
        /// </summary>
        [Column(Storage="_areacode", DbType="varchar(10)")]
        [DisplayName("地区代码")]
        [Description("地区代码")]
        public String areacode {
            get {
                return this._areacode;
            }
            set {
                if ((this._areacode != value)) {
                    this.OnareacodeChanging(value);
                    this.SendPropertyChanging("areacode", value);
                    this._areacode = value;
                    this.SendPropertyChanged("areacode", value);
                    this.OnareacodeChanged();
                }
            }
        }
        /// <summary>
        /// 上级代码
        /// </summary>
        [Column(Storage="_parentcode", DbType="varchar(10)")]
        [DisplayName("上级代码")]
        [Description("上级代码")]
        public String parentcode {
            get {
                return this._parentcode;
            }
            set {
                if ((this._parentcode != value)) {
                    this.OnparentcodeChanging(value);
                    this.SendPropertyChanging("parentcode", value);
                    this._parentcode = value;
                    this.SendPropertyChanged("parentcode", value);
                    this.OnparentcodeChanged();
                }
            }
        }
        /// <summary>
        /// 地区名称
        /// </summary>
        [Column(Storage="_areaname", DbType="nvarchar(25)")]
        [DisplayName("地区名称")]
        [Description("地区名称")]
        public String areaname {
            get {
                return this._areaname;
            }
            set {
                if ((this._areaname != value)) {
                    this.OnareanameChanging(value);
                    this.SendPropertyChanging("areaname", value);
                    this._areaname = value;
                    this.SendPropertyChanged("areaname", value);
                    this.OnareanameChanged();
                }
            }
        }
        /// <summary>
        /// 邮篇
        /// </summary>
        [Column(Storage="_areazipcode", DbType="varchar(10)")]
        [DisplayName("邮篇")]
        [Description("邮篇")]
        public String areazipcode {
            get {
                return this._areazipcode;
            }
            set {
                if ((this._areazipcode != value)) {
                    this.OnareazipcodeChanging(value);
                    this.SendPropertyChanging("areazipcode", value);
                    this._areazipcode = value;
                    this.SendPropertyChanged("areazipcode", value);
                    this.OnareazipcodeChanged();
                }
            }
        }
        /// <summary>
        /// 所属地区组(华东/华南等)
        /// </summary>
        [Column(Storage="_grouparea", DbType="nvarchar(25)")]
        [DisplayName("所属地区组(华东/华南等)")]
        [Description("所属地区组(华东/华南等)")]
        public String grouparea {
            get {
                return this._grouparea;
            }
            set {
                if ((this._grouparea != value)) {
                    this.OngroupareaChanging(value);
                    this.SendPropertyChanging("grouparea", value);
                    this._grouparea = value;
                    this.SendPropertyChanged("grouparea", value);
                    this.OngroupareaChanged();
                }
            }
        }
    }
    /// <summary>
    /// 文章表
    /// </summary>
    [Table(Name="t_article")]
    [Serializable()]
    [DisplayName("文章表")]
    [Description("文章表")]
    public partial class Marticle : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        ///  
        /// </summary>
        Int32 _nodeid;
        /// <summary>
        /// 标题名称
        /// </summary>
        String _title;
        /// <summary>
        /// 副标题
        /// </summary>
        String _subtitle;
        /// <summary>
        ///  
        /// </summary>
        String _thumbnail;
        /// <summary>
        ///  
        /// </summary>
        String _imagelist;
        /// <summary>
        ///  
        /// </summary>
        String _filelist;
        /// <summary>
        /// 属性(推荐,置顶. ……)
        /// </summary>
        String _attribute;
        /// <summary>
        ///  
        /// </summary>
        String _descript;
        /// <summary>
        /// 作者
        /// </summary>
        String _author;
        /// <summary>
        ///  
        /// </summary>
        String _source;
        /// <summary>
        ///  
        /// </summary>
        String _tags;
        /// <summary>
        ///  
        /// </summary>
        Int32? _sort;
        /// <summary>
        ///  
        /// </summary>
        String _setting;
        /// <summary>
        ///  
        /// </summary>
        String _addusername;
        /// <summary>
        ///  
        /// </summary>
        Int32 _adduserid;
        /// <summary>
        ///  
        /// </summary>
        DateTime _adddatetime;
        /// <summary>
        ///  
        /// </summary>
        String _lasteditusername;
        /// <summary>
        ///  
        /// </summary>
        Int32 _lastedituserid;
        /// <summary>
        ///  
        /// </summary>
        DateTime _lasteditdatetime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 nodeid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnnodeidChanging(Int32 value);
        /// <summary>
        /// 当 nodeid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnnodeidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 subtitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsubtitleChanging(String value);
        /// <summary>
        /// 当 subtitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsubtitleChanged();
        /// <summary>
        /// 当 thumbnail 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbnailChanging(String value);
        /// <summary>
        /// 当 thumbnail 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbnailChanged();
        /// <summary>
        /// 当 imagelist 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnimagelistChanging(String value);
        /// <summary>
        /// 当 imagelist 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnimagelistChanged();
        /// <summary>
        /// 当 filelist 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnfilelistChanging(String value);
        /// <summary>
        /// 当 filelist 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnfilelistChanged();
        /// <summary>
        /// 当 attribute 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnattributeChanging(String value);
        /// <summary>
        /// 当 attribute 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnattributeChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 author 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauthorChanging(String value);
        /// <summary>
        /// 当 author 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauthorChanged();
        /// <summary>
        /// 当 source 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsourceChanging(String value);
        /// <summary>
        /// 当 source 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsourceChanged();
        /// <summary>
        /// 当 tags 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntagsChanging(String value);
        /// <summary>
        /// 当 tags 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntagsChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 setting 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsettingChanging(String value);
        /// <summary>
        /// 当 setting 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsettingChanged();
        /// <summary>
        /// 当 addusername 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaddusernameChanging(String value);
        /// <summary>
        /// 当 addusername 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaddusernameChanged();
        /// <summary>
        /// 当 adduserid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadduseridChanging(Int32 value);
        /// <summary>
        /// 当 adduserid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadduseridChanged();
        /// <summary>
        /// 当 adddatetime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadddatetimeChanging(DateTime value);
        /// <summary>
        /// 当 adddatetime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadddatetimeChanged();
        /// <summary>
        /// 当 lasteditusername 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlasteditusernameChanging(String value);
        /// <summary>
        /// 当 lasteditusername 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlasteditusernameChanged();
        /// <summary>
        /// 当 lastedituserid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedituseridChanging(Int32 value);
        /// <summary>
        /// 当 lastedituserid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedituseridChanged();
        /// <summary>
        /// 当 lasteditdatetime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlasteditdatetimeChanging(DateTime value);
        /// <summary>
        /// 当 lasteditdatetime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlasteditdatetimeChanged();
        
        /// <summary>
        /// 初始化 Marticle 实体类的新实例。
        /// </summary>
        public Marticle() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_nodeid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 nodeid {
            get {
                return this._nodeid;
            }
            set {
                this.OnnodeidChanging(value);
                this.SendPropertyChanging("nodeid", value);
                this._nodeid = value;
                this.SendPropertyChanged("nodeid", value);
                this.OnnodeidChanged();
            }
        }
        /// <summary>
        /// 标题名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(60) NOT NULL", CanBeNull=false)]
        [DisplayName("标题名称")]
        [Description("标题名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 副标题
        /// </summary>
        [Column(Storage="_subtitle", DbType="nvarchar(30)")]
        [DisplayName("副标题")]
        [Description("副标题")]
        public String subtitle {
            get {
                return this._subtitle;
            }
            set {
                if ((this._subtitle != value)) {
                    this.OnsubtitleChanging(value);
                    this.SendPropertyChanging("subtitle", value);
                    this._subtitle = value;
                    this.SendPropertyChanged("subtitle", value);
                    this.OnsubtitleChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_thumbnail", DbType="varchar(30)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String thumbnail {
            get {
                return this._thumbnail;
            }
            set {
                if ((this._thumbnail != value)) {
                    this.OnthumbnailChanging(value);
                    this.SendPropertyChanging("thumbnail", value);
                    this._thumbnail = value;
                    this.SendPropertyChanged("thumbnail", value);
                    this.OnthumbnailChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_imagelist", DbType="varchar(200)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String imagelist {
            get {
                return this._imagelist;
            }
            set {
                if ((this._imagelist != value)) {
                    this.OnimagelistChanging(value);
                    this.SendPropertyChanging("imagelist", value);
                    this._imagelist = value;
                    this.SendPropertyChanged("imagelist", value);
                    this.OnimagelistChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_filelist", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String filelist {
            get {
                return this._filelist;
            }
            set {
                if ((this._filelist != value)) {
                    this.OnfilelistChanging(value);
                    this.SendPropertyChanging("filelist", value);
                    this._filelist = value;
                    this.SendPropertyChanged("filelist", value);
                    this.OnfilelistChanged();
                }
            }
        }
        /// <summary>
        /// 属性(推荐,置顶. ……)
        /// </summary>
        [Column(Storage="_attribute", DbType="varchar(50)")]
        [DisplayName("属性(推荐,置顶. ……)")]
        [Description("属性(推荐,置顶. ……)")]
        public String attribute {
            get {
                return this._attribute;
            }
            set {
                if ((this._attribute != value)) {
                    this.OnattributeChanging(value);
                    this.SendPropertyChanging("attribute", value);
                    this._attribute = value;
                    this.SendPropertyChanged("attribute", value);
                    this.OnattributeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(450)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 作者
        /// </summary>
        [Column(Storage="_author", DbType="nvarchar(20)")]
        [DisplayName("作者")]
        [Description("作者")]
        public String author {
            get {
                return this._author;
            }
            set {
                if ((this._author != value)) {
                    this.OnauthorChanging(value);
                    this.SendPropertyChanging("author", value);
                    this._author = value;
                    this.SendPropertyChanged("author", value);
                    this.OnauthorChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_source", DbType="nvarchar(30)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String source {
            get {
                return this._source;
            }
            set {
                if ((this._source != value)) {
                    this.OnsourceChanging(value);
                    this.SendPropertyChanging("source", value);
                    this._source = value;
                    this.SendPropertyChanged("source", value);
                    this.OnsourceChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_tags", DbType="varchar(300)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String tags {
            get {
                return this._tags;
            }
            set {
                if ((this._tags != value)) {
                    this.OntagsChanging(value);
                    this.SendPropertyChanging("tags", value);
                    this._tags = value;
                    this.SendPropertyChanged("tags", value);
                    this.OntagsChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_setting", DbType="nvarchar(500)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String setting {
            get {
                return this._setting;
            }
            set {
                if ((this._setting != value)) {
                    this.OnsettingChanging(value);
                    this.SendPropertyChanging("setting", value);
                    this._setting = value;
                    this.SendPropertyChanged("setting", value);
                    this.OnsettingChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_addusername", DbType="nvarchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String addusername {
            get {
                return this._addusername;
            }
            set {
                this.OnaddusernameChanging(value);
                this.SendPropertyChanging("addusername", value);
                this._addusername = value;
                this.SendPropertyChanged("addusername", value);
                this.OnaddusernameChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_adduserid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 adduserid {
            get {
                return this._adduserid;
            }
            set {
                this.OnadduseridChanging(value);
                this.SendPropertyChanging("adduserid", value);
                this._adduserid = value;
                this.SendPropertyChanged("adduserid", value);
                this.OnadduseridChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_adddatetime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public DateTime adddatetime {
            get {
                return this._adddatetime;
            }
            set {
                this.OnadddatetimeChanging(value);
                this.SendPropertyChanging("adddatetime", value);
                this._adddatetime = value;
                this.SendPropertyChanged("adddatetime", value);
                this.OnadddatetimeChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_lasteditusername", DbType="nvarchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String lasteditusername {
            get {
                return this._lasteditusername;
            }
            set {
                this.OnlasteditusernameChanging(value);
                this.SendPropertyChanging("lasteditusername", value);
                this._lasteditusername = value;
                this.SendPropertyChanged("lasteditusername", value);
                this.OnlasteditusernameChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_lastedituserid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 lastedituserid {
            get {
                return this._lastedituserid;
            }
            set {
                this.OnlastedituseridChanging(value);
                this.SendPropertyChanging("lastedituserid", value);
                this._lastedituserid = value;
                this.SendPropertyChanged("lastedituserid", value);
                this.OnlastedituseridChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_lasteditdatetime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public DateTime lasteditdatetime {
            get {
                return this._lasteditdatetime;
            }
            set {
                this.OnlasteditdatetimeChanging(value);
                this.SendPropertyChanging("lasteditdatetime", value);
                this._lasteditdatetime = value;
                this.SendPropertyChanged("lasteditdatetime", value);
                this.OnlasteditdatetimeChanged();
            }
        }
    }
    /// <summary>
    ///  
    /// </summary>
    [Table(Name="t_article_data")]
    [Serializable()]
    [DisplayName(" ")]
    [Description(" ")]
    public partial class Marticle_data : DALModelBase {
        /// <summary>
        ///  
        /// </summary>
        Int32 _articleid;
        /// <summary>
        ///  
        /// </summary>
        String _data;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 articleid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnarticleidChanging(Int32 value);
        /// <summary>
        /// 当 articleid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnarticleidChanged();
        /// <summary>
        /// 当 data 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndataChanging(String value);
        /// <summary>
        /// 当 data 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndataChanged();
        
        /// <summary>
        /// 初始化 Marticle_data 实体类的新实例。
        /// </summary>
        public Marticle_data() {
            this.OnCreated();
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_articleid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 articleid {
            get {
                return this._articleid;
            }
            set {
                this.OnarticleidChanging(value);
                this.SendPropertyChanging("articleid", value);
                this._articleid = value;
                this.SendPropertyChanged("articleid", value);
                this.OnarticleidChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_data", DbType="ntext NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String data {
            get {
                return this._data;
            }
            set {
                this.OndataChanging(value);
                this.SendPropertyChanging("data", value);
                this._data = value;
                this.SendPropertyChanged("data", value);
                this.OndataChanged();
            }
        }
    }
    /// <summary>
    ///  
    /// </summary>
    [Table(Name="t_article_node")]
    [Serializable()]
    [DisplayName(" ")]
    [Description(" ")]
    public partial class Marticle_node : DALModelBase {
        /// <summary>
        ///  
        /// </summary>
        Int32 _id;
        /// <summary>
        ///  
        /// </summary>
        Int32 _parentid;
        /// <summary>
        ///  
        /// </summary>
        String _title;
        /// <summary>
        ///  
        /// </summary>
        String _subtitle;
        /// <summary>
        ///  
        /// </summary>
        String _mark;
        /// <summary>
        ///  
        /// </summary>
        Int32? _formsid;
        /// <summary>
        ///  
        /// </summary>
        Int32 _lft;
        /// <summary>
        ///  
        /// </summary>
        Int32 _rgt;
        /// <summary>
        ///  
        /// </summary>
        Int32 _lev;
        /// <summary>
        ///  
        /// </summary>
        String _path;
        /// <summary>
        ///  
        /// </summary>
        Int32 _linktype;
        /// <summary>
        ///  
        /// </summary>
        String _linkurl;
        /// <summary>
        ///  
        /// </summary>
        String _tempcon;
        /// <summary>
        ///  
        /// </summary>
        String _templist;
        /// <summary>
        ///  
        /// </summary>
        String _tempindex;
        /// <summary>
        ///  
        /// </summary>
        String _filepath;
        /// <summary>
        ///  
        /// </summary>
        String _keywords;
        /// <summary>
        ///  
        /// </summary>
        String _descript;
        /// <summary>
        ///  
        /// </summary>
        String _tags;
        /// <summary>
        ///  
        /// </summary>
        Int32? _sort;
        /// <summary>
        ///  
        /// </summary>
        String _setting;
        /// <summary>
        ///  
        /// </summary>
        String _addusername;
        /// <summary>
        ///  
        /// </summary>
        Int32 _adduserid;
        /// <summary>
        ///  
        /// </summary>
        DateTime _adddatetime;
        /// <summary>
        ///  
        /// </summary>
        String _lasteditusername;
        /// <summary>
        ///  
        /// </summary>
        Int32 _lastedituserid;
        /// <summary>
        ///  
        /// </summary>
        DateTime _lasteditdatetime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 parentid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnparentidChanging(Int32 value);
        /// <summary>
        /// 当 parentid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnparentidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 subtitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsubtitleChanging(String value);
        /// <summary>
        /// 当 subtitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsubtitleChanged();
        /// <summary>
        /// 当 mark 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarkChanging(String value);
        /// <summary>
        /// 当 mark 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarkChanged();
        /// <summary>
        /// 当 formsid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnformsidChanging(Int32? value);
        /// <summary>
        /// 当 formsid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnformsidChanged();
        /// <summary>
        /// 当 lft 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlftChanging(Int32 value);
        /// <summary>
        /// 当 lft 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlftChanged();
        /// <summary>
        /// 当 rgt 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnrgtChanging(Int32 value);
        /// <summary>
        /// 当 rgt 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnrgtChanged();
        /// <summary>
        /// 当 lev 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlevChanging(Int32 value);
        /// <summary>
        /// 当 lev 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlevChanged();
        /// <summary>
        /// 当 path 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpathChanging(String value);
        /// <summary>
        /// 当 path 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpathChanged();
        /// <summary>
        /// 当 linktype 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinktypeChanging(Int32 value);
        /// <summary>
        /// 当 linktype 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinktypeChanged();
        /// <summary>
        /// 当 linkurl 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinkurlChanging(String value);
        /// <summary>
        /// 当 linkurl 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinkurlChanged();
        /// <summary>
        /// 当 tempcon 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntempconChanging(String value);
        /// <summary>
        /// 当 tempcon 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntempconChanged();
        /// <summary>
        /// 当 templist 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntemplistChanging(String value);
        /// <summary>
        /// 当 templist 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntemplistChanged();
        /// <summary>
        /// 当 tempindex 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntempindexChanging(String value);
        /// <summary>
        /// 当 tempindex 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntempindexChanged();
        /// <summary>
        /// 当 filepath 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnfilepathChanging(String value);
        /// <summary>
        /// 当 filepath 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnfilepathChanged();
        /// <summary>
        /// 当 keywords 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnkeywordsChanging(String value);
        /// <summary>
        /// 当 keywords 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnkeywordsChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 tags 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntagsChanging(String value);
        /// <summary>
        /// 当 tags 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntagsChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 setting 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsettingChanging(String value);
        /// <summary>
        /// 当 setting 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsettingChanged();
        /// <summary>
        /// 当 addusername 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaddusernameChanging(String value);
        /// <summary>
        /// 当 addusername 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaddusernameChanged();
        /// <summary>
        /// 当 adduserid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadduseridChanging(Int32 value);
        /// <summary>
        /// 当 adduserid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadduseridChanged();
        /// <summary>
        /// 当 adddatetime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadddatetimeChanging(DateTime value);
        /// <summary>
        /// 当 adddatetime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadddatetimeChanged();
        /// <summary>
        /// 当 lasteditusername 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlasteditusernameChanging(String value);
        /// <summary>
        /// 当 lasteditusername 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlasteditusernameChanged();
        /// <summary>
        /// 当 lastedituserid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedituseridChanging(Int32 value);
        /// <summary>
        /// 当 lastedituserid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedituseridChanged();
        /// <summary>
        /// 当 lasteditdatetime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlasteditdatetimeChanging(DateTime value);
        /// <summary>
        /// 当 lasteditdatetime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlasteditdatetimeChanged();
        
        /// <summary>
        /// 初始化 Marticle_node 实体类的新实例。
        /// </summary>
        public Marticle_node() {
            this.OnCreated();
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_parentid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 parentid {
            get {
                return this._parentid;
            }
            set {
                this.OnparentidChanging(value);
                this.SendPropertyChanging("parentid", value);
                this._parentid = value;
                this.SendPropertyChanged("parentid", value);
                this.OnparentidChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(60) NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_subtitle", DbType="nvarchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String subtitle {
            get {
                return this._subtitle;
            }
            set {
                if ((this._subtitle != value)) {
                    this.OnsubtitleChanging(value);
                    this.SendPropertyChanging("subtitle", value);
                    this._subtitle = value;
                    this.SendPropertyChanged("subtitle", value);
                    this.OnsubtitleChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_mark", DbType="varchar(10)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String mark {
            get {
                return this._mark;
            }
            set {
                if ((this._mark != value)) {
                    this.OnmarkChanging(value);
                    this.SendPropertyChanging("mark", value);
                    this._mark = value;
                    this.SendPropertyChanged("mark", value);
                    this.OnmarkChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_formsid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? formsid {
            get {
                return this._formsid;
            }
            set {
                if ((this._formsid != value)) {
                    this.OnformsidChanging(value);
                    this.SendPropertyChanging("formsid", value);
                    this._formsid = value;
                    this.SendPropertyChanged("formsid", value);
                    this.OnformsidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_lft", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 lft {
            get {
                return this._lft;
            }
            set {
                this.OnlftChanging(value);
                this.SendPropertyChanging("lft", value);
                this._lft = value;
                this.SendPropertyChanged("lft", value);
                this.OnlftChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_rgt", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 rgt {
            get {
                return this._rgt;
            }
            set {
                this.OnrgtChanging(value);
                this.SendPropertyChanging("rgt", value);
                this._rgt = value;
                this.SendPropertyChanged("rgt", value);
                this.OnrgtChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_lev", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 lev {
            get {
                return this._lev;
            }
            set {
                this.OnlevChanging(value);
                this.SendPropertyChanging("lev", value);
                this._lev = value;
                this.SendPropertyChanged("lev", value);
                this.OnlevChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_path", DbType="varchar(120) NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String path {
            get {
                return this._path;
            }
            set {
                this.OnpathChanging(value);
                this.SendPropertyChanging("path", value);
                this._path = value;
                this.SendPropertyChanged("path", value);
                this.OnpathChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_linktype", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 linktype {
            get {
                return this._linktype;
            }
            set {
                this.OnlinktypeChanging(value);
                this.SendPropertyChanging("linktype", value);
                this._linktype = value;
                this.SendPropertyChanged("linktype", value);
                this.OnlinktypeChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_linkurl", DbType="varchar(120)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String linkurl {
            get {
                return this._linkurl;
            }
            set {
                if ((this._linkurl != value)) {
                    this.OnlinkurlChanging(value);
                    this.SendPropertyChanging("linkurl", value);
                    this._linkurl = value;
                    this.SendPropertyChanged("linkurl", value);
                    this.OnlinkurlChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_tempcon", DbType="varchar(120)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String tempcon {
            get {
                return this._tempcon;
            }
            set {
                if ((this._tempcon != value)) {
                    this.OntempconChanging(value);
                    this.SendPropertyChanging("tempcon", value);
                    this._tempcon = value;
                    this.SendPropertyChanged("tempcon", value);
                    this.OntempconChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_templist", DbType="varchar(120)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String templist {
            get {
                return this._templist;
            }
            set {
                if ((this._templist != value)) {
                    this.OntemplistChanging(value);
                    this.SendPropertyChanging("templist", value);
                    this._templist = value;
                    this.SendPropertyChanged("templist", value);
                    this.OntemplistChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_tempindex", DbType="varchar(120)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String tempindex {
            get {
                return this._tempindex;
            }
            set {
                if ((this._tempindex != value)) {
                    this.OntempindexChanging(value);
                    this.SendPropertyChanging("tempindex", value);
                    this._tempindex = value;
                    this.SendPropertyChanged("tempindex", value);
                    this.OntempindexChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_filepath", DbType="varchar(120)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String filepath {
            get {
                return this._filepath;
            }
            set {
                if ((this._filepath != value)) {
                    this.OnfilepathChanging(value);
                    this.SendPropertyChanging("filepath", value);
                    this._filepath = value;
                    this.SendPropertyChanged("filepath", value);
                    this.OnfilepathChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_keywords", DbType="nvarchar(100)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String keywords {
            get {
                return this._keywords;
            }
            set {
                if ((this._keywords != value)) {
                    this.OnkeywordsChanging(value);
                    this.SendPropertyChanging("keywords", value);
                    this._keywords = value;
                    this.SendPropertyChanged("keywords", value);
                    this.OnkeywordsChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(450)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_tags", DbType="varchar(300)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String tags {
            get {
                return this._tags;
            }
            set {
                if ((this._tags != value)) {
                    this.OntagsChanging(value);
                    this.SendPropertyChanging("tags", value);
                    this._tags = value;
                    this.SendPropertyChanged("tags", value);
                    this.OntagsChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_setting", DbType="nvarchar(500)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String setting {
            get {
                return this._setting;
            }
            set {
                if ((this._setting != value)) {
                    this.OnsettingChanging(value);
                    this.SendPropertyChanging("setting", value);
                    this._setting = value;
                    this.SendPropertyChanged("setting", value);
                    this.OnsettingChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_addusername", DbType="nvarchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String addusername {
            get {
                return this._addusername;
            }
            set {
                this.OnaddusernameChanging(value);
                this.SendPropertyChanging("addusername", value);
                this._addusername = value;
                this.SendPropertyChanged("addusername", value);
                this.OnaddusernameChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_adduserid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 adduserid {
            get {
                return this._adduserid;
            }
            set {
                this.OnadduseridChanging(value);
                this.SendPropertyChanging("adduserid", value);
                this._adduserid = value;
                this.SendPropertyChanged("adduserid", value);
                this.OnadduseridChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_adddatetime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public DateTime adddatetime {
            get {
                return this._adddatetime;
            }
            set {
                this.OnadddatetimeChanging(value);
                this.SendPropertyChanging("adddatetime", value);
                this._adddatetime = value;
                this.SendPropertyChanged("adddatetime", value);
                this.OnadddatetimeChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_lasteditusername", DbType="nvarchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String lasteditusername {
            get {
                return this._lasteditusername;
            }
            set {
                this.OnlasteditusernameChanging(value);
                this.SendPropertyChanging("lasteditusername", value);
                this._lasteditusername = value;
                this.SendPropertyChanged("lasteditusername", value);
                this.OnlasteditusernameChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_lastedituserid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 lastedituserid {
            get {
                return this._lastedituserid;
            }
            set {
                this.OnlastedituseridChanging(value);
                this.SendPropertyChanging("lastedituserid", value);
                this._lastedituserid = value;
                this.SendPropertyChanged("lastedituserid", value);
                this.OnlastedituseridChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_lasteditdatetime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public DateTime lasteditdatetime {
            get {
                return this._lasteditdatetime;
            }
            set {
                this.OnlasteditdatetimeChanging(value);
                this.SendPropertyChanging("lasteditdatetime", value);
                this._lasteditdatetime = value;
                this.SendPropertyChanged("lasteditdatetime", value);
                this.OnlasteditdatetimeChanged();
            }
        }
    }
    /// <summary>
    /// 品牌表
    /// </summary>
    [Table(Name="t_brand")]
    [Serializable()]
    [DisplayName("品牌表")]
    [Description("品牌表")]
    public partial class Mbrand : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 所属企业ID
        /// </summary>
        Int32? _companyid;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 索引
        /// </summary>
        String _letter;
        /// <summary>
        /// 组ID
        /// </summary>
        Int32? _groupid;
        /// <summary>
        /// 属性(推荐,置顶. ……)
        /// </summary>
        String _attribute;
        /// <summary>
        /// 品牌下产品分类ID（该信息有哪些产品分类）
        /// </summary>
        String _productcategory;
        /// <summary>
        /// 主页地址
        /// </summary>
        String _homepage;
        /// <summary>
        /// 产品数量
        /// </summary>
        Int32? _productcount;
        /// <summary>
        /// 价位（config表值）
        /// </summary>
        String _spread;
        /// <summary>
        /// 材质（config表值）
        /// </summary>
        String _material;
        /// <summary>
        /// 风格（config表值）
        /// </summary>
        String _style;
        /// <summary>
        /// 颜色（config表值）
        /// </summary>
        String _color;
        /// <summary>
        /// 形象图
        /// </summary>
        String _surface;
        /// <summary>
        /// logo
        /// </summary>
        String _logo;
        /// <summary>
        /// 缩略图
        /// </summary>
        String _thumb;
        /// <summary>
        /// 幻灯图
        /// </summary>
        String _bannel;
        /// <summary>
        /// 描述图
        /// </summary>
        String _desimage;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 关键字
        /// </summary>
        String _keywords;
        /// <summary>
        /// 模版ID
        /// </summary>
        String _template;
        /// <summary>
        /// 点击量
        /// </summary>
        Int32? _hits;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 创建人
        /// </summary>
        Int32? _createmid;
        /// <summary>
        /// 修改人
        /// </summary>
        Int32? _lasteditid;
        /// <summary>
        /// 最后个改
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        /// 审核状态，-1正在审核，0待审核，1审核通过，-99未通过
        /// </summary>
        Int32 _auditstatus;
        /// <summary>
        /// 审核状态，-1正在审核，0待审核，1审核通过，-99未通过
        /// </summary>
        Int32 _linestatus;
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? _Createtime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 companyid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncompanyidChanging(Int32? value);
        /// <summary>
        /// 当 companyid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncompanyidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 letter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnletterChanging(String value);
        /// <summary>
        /// 当 letter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnletterChanged();
        /// <summary>
        /// 当 groupid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OngroupidChanging(Int32? value);
        /// <summary>
        /// 当 groupid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OngroupidChanged();
        /// <summary>
        /// 当 attribute 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnattributeChanging(String value);
        /// <summary>
        /// 当 attribute 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnattributeChanged();
        /// <summary>
        /// 当 productcategory 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcategoryChanging(String value);
        /// <summary>
        /// 当 productcategory 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcategoryChanged();
        /// <summary>
        /// 当 homepage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhomepageChanging(String value);
        /// <summary>
        /// 当 homepage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhomepageChanged();
        /// <summary>
        /// 当 productcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcountChanging(Int32? value);
        /// <summary>
        /// 当 productcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcountChanged();
        /// <summary>
        /// 当 spread 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnspreadChanging(String value);
        /// <summary>
        /// 当 spread 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnspreadChanged();
        /// <summary>
        /// 当 material 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmaterialChanging(String value);
        /// <summary>
        /// 当 material 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmaterialChanged();
        /// <summary>
        /// 当 style 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstyleChanging(String value);
        /// <summary>
        /// 当 style 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstyleChanged();
        /// <summary>
        /// 当 color 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncolorChanging(String value);
        /// <summary>
        /// 当 color 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncolorChanged();
        /// <summary>
        /// 当 surface 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsurfaceChanging(String value);
        /// <summary>
        /// 当 surface 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsurfaceChanged();
        /// <summary>
        /// 当 logo 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlogoChanging(String value);
        /// <summary>
        /// 当 logo 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlogoChanged();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 bannel 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannelChanging(String value);
        /// <summary>
        /// 当 bannel 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannelChanged();
        /// <summary>
        /// 当 desimage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndesimageChanging(String value);
        /// <summary>
        /// 当 desimage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndesimageChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 keywords 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnkeywordsChanging(String value);
        /// <summary>
        /// 当 keywords 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnkeywordsChanged();
        /// <summary>
        /// 当 template 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntemplateChanging(String value);
        /// <summary>
        /// 当 template 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntemplateChanged();
        /// <summary>
        /// 当 hits 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhitsChanging(Int32? value);
        /// <summary>
        /// 当 hits 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhitsChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 createmid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatemidChanging(Int32? value);
        /// <summary>
        /// 当 createmid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatemidChanged();
        /// <summary>
        /// 当 lasteditid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlasteditidChanging(Int32? value);
        /// <summary>
        /// 当 lasteditid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlasteditidChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        /// <summary>
        /// 当 auditstatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauditstatusChanging(Int32 value);
        /// <summary>
        /// 当 auditstatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauditstatusChanged();
        /// <summary>
        /// 当 linestatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinestatusChanging(Int32 value);
        /// <summary>
        /// 当 linestatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinestatusChanged();
        /// <summary>
        /// 当 Createtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnCreatetimeChanging(DateTime? value);
        /// <summary>
        /// 当 Createtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnCreatetimeChanged();
        
        /// <summary>
        /// 初始化 Mbrand 实体类的新实例。
        /// </summary>
        public Mbrand() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 所属企业ID
        /// </summary>
        [Column(Storage="_companyid", DbType="int")]
        [DisplayName("所属企业ID")]
        [Description("所属企业ID")]
        public Int32? companyid {
            get {
                return this._companyid;
            }
            set {
                if ((this._companyid != value)) {
                    this.OncompanyidChanging(value);
                    this.SendPropertyChanging("companyid", value);
                    this._companyid = value;
                    this.SendPropertyChanged("companyid", value);
                    this.OncompanyidChanged();
                }
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(80) NOT NULL", CanBeNull=false)]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 索引
        /// </summary>
        [Column(Storage="_letter", DbType="varchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName("索引")]
        [Description("索引")]
        public String letter {
            get {
                return this._letter;
            }
            set {
                this.OnletterChanging(value);
                this.SendPropertyChanging("letter", value);
                this._letter = value;
                this.SendPropertyChanged("letter", value);
                this.OnletterChanged();
            }
        }
        /// <summary>
        /// 组ID
        /// </summary>
        [Column(Storage="_groupid", DbType="int")]
        [DisplayName("组ID")]
        [Description("组ID")]
        public Int32? groupid {
            get {
                return this._groupid;
            }
            set {
                if ((this._groupid != value)) {
                    this.OngroupidChanging(value);
                    this.SendPropertyChanging("groupid", value);
                    this._groupid = value;
                    this.SendPropertyChanged("groupid", value);
                    this.OngroupidChanged();
                }
            }
        }
        /// <summary>
        /// 属性(推荐,置顶. ……)
        /// </summary>
        [Column(Storage="_attribute", DbType="varchar(100)")]
        [DisplayName("属性")]
        [Description("属性(推荐,置顶. ……)")]
        public String attribute {
            get {
                return this._attribute;
            }
            set {
                if ((this._attribute != value)) {
                    this.OnattributeChanging(value);
                    this.SendPropertyChanging("attribute", value);
                    this._attribute = value;
                    this.SendPropertyChanged("attribute", value);
                    this.OnattributeChanged();
                }
            }
        }
        /// <summary>
        /// 品牌下产品分类ID（该信息有哪些产品分类）
        /// </summary>
        [Column(Storage="_productcategory", DbType="varchar(50)")]
        [DisplayName("品牌下产品分类ID")]
        [Description("品牌下产品分类ID（该信息有哪些产品分类）")]
        public String productcategory {
            get {
                return this._productcategory;
            }
            set {
                if ((this._productcategory != value)) {
                    this.OnproductcategoryChanging(value);
                    this.SendPropertyChanging("productcategory", value);
                    this._productcategory = value;
                    this.SendPropertyChanged("productcategory", value);
                    this.OnproductcategoryChanged();
                }
            }
        }
        /// <summary>
        /// 主页地址
        /// </summary>
        [Column(Storage="_homepage", DbType="varchar(50)")]
        [DisplayName("主页地址")]
        [Description("主页地址")]
        public String homepage {
            get {
                return this._homepage;
            }
            set {
                if ((this._homepage != value)) {
                    this.OnhomepageChanging(value);
                    this.SendPropertyChanging("homepage", value);
                    this._homepage = value;
                    this.SendPropertyChanged("homepage", value);
                    this.OnhomepageChanged();
                }
            }
        }
        /// <summary>
        /// 产品数量
        /// </summary>
        [Column(Storage="_productcount", DbType="int")]
        [DisplayName("产品数量")]
        [Description("产品数量")]
        public Int32? productcount {
            get {
                return this._productcount;
            }
            set {
                if ((this._productcount != value)) {
                    this.OnproductcountChanging(value);
                    this.SendPropertyChanging("productcount", value);
                    this._productcount = value;
                    this.SendPropertyChanged("productcount", value);
                    this.OnproductcountChanged();
                }
            }
        }
        /// <summary>
        /// 价位（config表值）
        /// </summary>
        [Column(Storage="_spread", DbType="nvarchar(30)")]
        [DisplayName("价位")]
        [Description("价位（config表值）")]
        public String spread {
            get {
                return this._spread;
            }
            set {
                if ((this._spread != value)) {
                    this.OnspreadChanging(value);
                    this.SendPropertyChanging("spread", value);
                    this._spread = value;
                    this.SendPropertyChanged("spread", value);
                    this.OnspreadChanged();
                }
            }
        }
        /// <summary>
        /// 材质（config表值）
        /// </summary>
        [Column(Storage="_material", DbType="nvarchar(50)")]
        [DisplayName("材质")]
        [Description("材质（config表值）")]
        public String material {
            get {
                return this._material;
            }
            set {
                if ((this._material != value)) {
                    this.OnmaterialChanging(value);
                    this.SendPropertyChanging("material", value);
                    this._material = value;
                    this.SendPropertyChanged("material", value);
                    this.OnmaterialChanged();
                }
            }
        }
        /// <summary>
        /// 风格（config表值）
        /// </summary>
        [Column(Storage="_style", DbType="nvarchar(50)")]
        [DisplayName("风格")]
        [Description("风格（config表值）")]
        public String style {
            get {
                return this._style;
            }
            set {
                if ((this._style != value)) {
                    this.OnstyleChanging(value);
                    this.SendPropertyChanging("style", value);
                    this._style = value;
                    this.SendPropertyChanged("style", value);
                    this.OnstyleChanged();
                }
            }
        }
        /// <summary>
        /// 颜色（config表值）
        /// </summary>
        [Column(Storage="_color", DbType="nvarchar(50)")]
        [DisplayName("颜色")]
        [Description("颜色（config表值）")]
        public String color {
            get {
                return this._color;
            }
            set {
                if ((this._color != value)) {
                    this.OncolorChanging(value);
                    this.SendPropertyChanging("color", value);
                    this._color = value;
                    this.SendPropertyChanged("color", value);
                    this.OncolorChanged();
                }
            }
        }
        /// <summary>
        /// 形象图
        /// </summary>
        [Column(Storage="_surface", DbType="varchar(200)")]
        [DisplayName("形象图")]
        [Description("形象图")]
        public String surface {
            get {
                return this._surface;
            }
            set {
                if ((this._surface != value)) {
                    this.OnsurfaceChanging(value);
                    this.SendPropertyChanging("surface", value);
                    this._surface = value;
                    this.SendPropertyChanged("surface", value);
                    this.OnsurfaceChanged();
                }
            }
        }
        /// <summary>
        /// logo
        /// </summary>
        [Column(Storage="_logo", DbType="varchar(40)")]
        [DisplayName("logo")]
        [Description("logo")]
        public String logo {
            get {
                return this._logo;
            }
            set {
                if ((this._logo != value)) {
                    this.OnlogoChanging(value);
                    this.SendPropertyChanging("logo", value);
                    this._logo = value;
                    this.SendPropertyChanged("logo", value);
                    this.OnlogoChanged();
                }
            }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(40)")]
        [DisplayName("缩略图")]
        [Description("缩略图")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        /// 幻灯图
        /// </summary>
        [Column(Storage="_bannel", DbType="varchar(300)")]
        [DisplayName("幻灯图")]
        [Description("幻灯图")]
        public String bannel {
            get {
                return this._bannel;
            }
            set {
                if ((this._bannel != value)) {
                    this.OnbannelChanging(value);
                    this.SendPropertyChanging("bannel", value);
                    this._bannel = value;
                    this.SendPropertyChanged("bannel", value);
                    this.OnbannelChanged();
                }
            }
        }
        /// <summary>
        /// 描述图
        /// </summary>
        [Column(Storage="_desimage", DbType="varchar(400)")]
        [DisplayName("描述图")]
        [Description("描述图")]
        public String desimage {
            get {
                return this._desimage;
            }
            set {
                if ((this._desimage != value)) {
                    this.OndesimageChanging(value);
                    this.SendPropertyChanging("desimage", value);
                    this._desimage = value;
                    this.SendPropertyChanged("desimage", value);
                    this.OndesimageChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="ntext")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        [Column(Storage="_keywords", DbType="nvarchar(200)")]
        [DisplayName("关键字")]
        [Description("关键字")]
        public String keywords {
            get {
                return this._keywords;
            }
            set {
                if ((this._keywords != value)) {
                    this.OnkeywordsChanging(value);
                    this.SendPropertyChanging("keywords", value);
                    this._keywords = value;
                    this.SendPropertyChanged("keywords", value);
                    this.OnkeywordsChanged();
                }
            }
        }
        /// <summary>
        /// 模版ID
        /// </summary>
        [Column(Storage="_template", DbType="varchar(50)")]
        [DisplayName("模版ID")]
        [Description("模版ID")]
        public String template {
            get {
                return this._template;
            }
            set {
                if ((this._template != value)) {
                    this.OntemplateChanging(value);
                    this.SendPropertyChanging("template", value);
                    this._template = value;
                    this.SendPropertyChanged("template", value);
                    this.OntemplateChanged();
                }
            }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        [Column(Storage="_hits", DbType="int")]
        [DisplayName("点击量")]
        [Description("点击量")]
        public Int32? hits {
            get {
                return this._hits;
            }
            set {
                if ((this._hits != value)) {
                    this.OnhitsChanging(value);
                    this.SendPropertyChanging("hits", value);
                    this._hits = value;
                    this.SendPropertyChanged("hits", value);
                    this.OnhitsChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column(Storage="_createmid", DbType="int")]
        [DisplayName("创建人")]
        [Description("创建人")]
        public Int32? createmid {
            get {
                return this._createmid;
            }
            set {
                if ((this._createmid != value)) {
                    this.OncreatemidChanging(value);
                    this.SendPropertyChanging("createmid", value);
                    this._createmid = value;
                    this.SendPropertyChanged("createmid", value);
                    this.OncreatemidChanged();
                }
            }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        [Column(Storage="_lasteditid", DbType="int")]
        [DisplayName("修改人")]
        [Description("修改人")]
        public Int32? lasteditid {
            get {
                return this._lasteditid;
            }
            set {
                if ((this._lasteditid != value)) {
                    this.OnlasteditidChanging(value);
                    this.SendPropertyChanging("lasteditid", value);
                    this._lasteditid = value;
                    this.SendPropertyChanged("lasteditid", value);
                    this.OnlasteditidChanged();
                }
            }
        }
        /// <summary>
        /// 最后个改
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最后个改")]
        [Description("最后个改")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
        /// <summary>
        /// 审核状态，-1正在审核，0待审核，1审核通过，-99未通过
        /// </summary>
        [Column(Storage="_auditstatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("审核状态")]
        [Description("审核状态，-1正在审核，0待审核，1审核通过，-99未通过")]
        public Int32 auditstatus {
            get {
                return this._auditstatus;
            }
            set {
                this.OnauditstatusChanging(value);
                this.SendPropertyChanging("auditstatus", value);
                this._auditstatus = value;
                this.SendPropertyChanged("auditstatus", value);
                this.OnauditstatusChanged();
            }
        }
        /// <summary>
        /// 审核状态，-1正在审核，0待审核，1审核通过，-99未通过
        /// </summary>
        [Column(Storage="_linestatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("审核状态")]
        [Description("审核状态，-1正在审核，0待审核，1审核通过，-99未通过")]
        public Int32 linestatus {
            get {
                return this._linestatus;
            }
            set {
                this.OnlinestatusChanging(value);
                this.SendPropertyChanging("linestatus", value);
                this._linestatus = value;
                this.SendPropertyChanged("linestatus", value);
                this.OnlinestatusChanged();
            }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Storage="_Createtime", DbType="datetime")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        public DateTime? Createtime {
            get {
                return this._Createtime;
            }
            set {
                if ((this._Createtime != value)) {
                    this.OnCreatetimeChanging(value);
                    this.SendPropertyChanging("Createtime", value);
                    this._Createtime = value;
                    this.SendPropertyChanged("Createtime", value);
                    this.OnCreatetimeChanged();
                }
            }
        }
    }
    /// <summary>
    /// 品牌系列表
    /// </summary>
    [Table(Name="t_brands")]
    [Serializable()]
    [DisplayName("品牌系列表")]
    [Description("品牌系列表")]
    public partial class Mbrands : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 所属品牌ID
        /// </summary>
        Int32 _brandid;
        /// <summary>
        /// 系列名称
        /// </summary>
        String _title;
        /// <summary>
        /// 索引
        /// </summary>
        String _letter;
        /// <summary>
        /// 属性
        /// </summary>
        String _attribute;
        /// <summary>
        /// 产品数量
        /// </summary>
        Int32? _productcount;
        /// <summary>
        /// 价位（config表值）
        /// </summary>
        String _spread;
        /// <summary>
        /// 材质（config表值）
        /// </summary>
        String _material;
        /// <summary>
        /// 风格（config表值）
        /// </summary>
        String _style;
        /// <summary>
        /// 形象图
        /// </summary>
        String _surface;
        /// <summary>
        /// logo
        /// </summary>
        String _logo;
        /// <summary>
        /// 缩略图
        /// </summary>
        String _thumb;
        /// <summary>
        /// 幻灯图
        /// </summary>
        String _bannel;
        /// <summary>
        /// 描述图
        /// </summary>
        String _desimage;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 关键字
        /// </summary>
        String _keywords;
        /// <summary>
        /// 模版ID
        /// </summary>
        String _template;
        /// <summary>
        /// 点击量
        /// </summary>
        Int32? _hits;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 创建人
        /// </summary>
        Int32? _createmid;
        /// <summary>
        /// 最后修改人
        /// </summary>
        Int32? _lasteditid;
        /// <summary>
        /// 最后个改
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        /// 审核状态
        /// </summary>
        Int32 _auditstatus;
        /// <summary>
        /// 在线状态
        /// </summary>
        Int32 _linestatus;
        /// <summary>
        ///  
        /// </summary>
        String _color;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 brandid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandidChanging(Int32 value);
        /// <summary>
        /// 当 brandid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 letter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnletterChanging(String value);
        /// <summary>
        /// 当 letter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnletterChanged();
        /// <summary>
        /// 当 attribute 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnattributeChanging(String value);
        /// <summary>
        /// 当 attribute 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnattributeChanged();
        /// <summary>
        /// 当 productcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcountChanging(Int32? value);
        /// <summary>
        /// 当 productcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcountChanged();
        /// <summary>
        /// 当 spread 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnspreadChanging(String value);
        /// <summary>
        /// 当 spread 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnspreadChanged();
        /// <summary>
        /// 当 material 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmaterialChanging(String value);
        /// <summary>
        /// 当 material 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmaterialChanged();
        /// <summary>
        /// 当 style 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstyleChanging(String value);
        /// <summary>
        /// 当 style 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstyleChanged();
        /// <summary>
        /// 当 surface 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsurfaceChanging(String value);
        /// <summary>
        /// 当 surface 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsurfaceChanged();
        /// <summary>
        /// 当 logo 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlogoChanging(String value);
        /// <summary>
        /// 当 logo 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlogoChanged();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 bannel 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannelChanging(String value);
        /// <summary>
        /// 当 bannel 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannelChanged();
        /// <summary>
        /// 当 desimage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndesimageChanging(String value);
        /// <summary>
        /// 当 desimage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndesimageChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 keywords 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnkeywordsChanging(String value);
        /// <summary>
        /// 当 keywords 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnkeywordsChanged();
        /// <summary>
        /// 当 template 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntemplateChanging(String value);
        /// <summary>
        /// 当 template 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntemplateChanged();
        /// <summary>
        /// 当 hits 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhitsChanging(Int32? value);
        /// <summary>
        /// 当 hits 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhitsChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 createmid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatemidChanging(Int32? value);
        /// <summary>
        /// 当 createmid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatemidChanged();
        /// <summary>
        /// 当 lasteditid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlasteditidChanging(Int32? value);
        /// <summary>
        /// 当 lasteditid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlasteditidChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        /// <summary>
        /// 当 auditstatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauditstatusChanging(Int32 value);
        /// <summary>
        /// 当 auditstatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauditstatusChanged();
        /// <summary>
        /// 当 linestatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinestatusChanging(Int32 value);
        /// <summary>
        /// 当 linestatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinestatusChanged();
        /// <summary>
        /// 当 color 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncolorChanging(String value);
        /// <summary>
        /// 当 color 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncolorChanged();
        
        /// <summary>
        /// 初始化 Mbrands 实体类的新实例。
        /// </summary>
        public Mbrands() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 所属品牌ID
        /// </summary>
        [Column(Storage="_brandid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("所属品牌ID")]
        [Description("所属品牌ID")]
        public Int32 brandid {
            get {
                return this._brandid;
            }
            set {
                this.OnbrandidChanging(value);
                this.SendPropertyChanging("brandid", value);
                this._brandid = value;
                this.SendPropertyChanged("brandid", value);
                this.OnbrandidChanged();
            }
        }
        /// <summary>
        /// 系列名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(80) NOT NULL", CanBeNull=false)]
        [DisplayName("系列名称")]
        [Description("系列名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 索引
        /// </summary>
        [Column(Storage="_letter", DbType="varchar(20)")]
        [DisplayName("索引")]
        [Description("索引")]
        public String letter {
            get {
                return this._letter;
            }
            set {
                if ((this._letter != value)) {
                    this.OnletterChanging(value);
                    this.SendPropertyChanging("letter", value);
                    this._letter = value;
                    this.SendPropertyChanged("letter", value);
                    this.OnletterChanged();
                }
            }
        }
        /// <summary>
        /// 属性
        /// </summary>
        [Column(Storage="_attribute", DbType="varchar(100)")]
        [DisplayName("属性")]
        [Description("属性")]
        public String attribute {
            get {
                return this._attribute;
            }
            set {
                if ((this._attribute != value)) {
                    this.OnattributeChanging(value);
                    this.SendPropertyChanging("attribute", value);
                    this._attribute = value;
                    this.SendPropertyChanged("attribute", value);
                    this.OnattributeChanged();
                }
            }
        }
        /// <summary>
        /// 产品数量
        /// </summary>
        [Column(Storage="_productcount", DbType="int")]
        [DisplayName("产品数量")]
        [Description("产品数量")]
        public Int32? productcount {
            get {
                return this._productcount;
            }
            set {
                if ((this._productcount != value)) {
                    this.OnproductcountChanging(value);
                    this.SendPropertyChanging("productcount", value);
                    this._productcount = value;
                    this.SendPropertyChanged("productcount", value);
                    this.OnproductcountChanged();
                }
            }
        }
        /// <summary>
        /// 价位（config表值）
        /// </summary>
        [Column(Storage="_spread", DbType="nvarchar(30)")]
        [DisplayName("价位")]
        [Description("价位（config表值）")]
        public String spread {
            get {
                return this._spread;
            }
            set {
                if ((this._spread != value)) {
                    this.OnspreadChanging(value);
                    this.SendPropertyChanging("spread", value);
                    this._spread = value;
                    this.SendPropertyChanged("spread", value);
                    this.OnspreadChanged();
                }
            }
        }
        /// <summary>
        /// 材质（config表值）
        /// </summary>
        [Column(Storage="_material", DbType="nvarchar(50)")]
        [DisplayName("材质")]
        [Description("材质（config表值）")]
        public String material {
            get {
                return this._material;
            }
            set {
                if ((this._material != value)) {
                    this.OnmaterialChanging(value);
                    this.SendPropertyChanging("material", value);
                    this._material = value;
                    this.SendPropertyChanged("material", value);
                    this.OnmaterialChanged();
                }
            }
        }
        /// <summary>
        /// 风格（config表值）
        /// </summary>
        [Column(Storage="_style", DbType="nvarchar(50)")]
        [DisplayName("风格")]
        [Description("风格（config表值）")]
        public String style {
            get {
                return this._style;
            }
            set {
                if ((this._style != value)) {
                    this.OnstyleChanging(value);
                    this.SendPropertyChanging("style", value);
                    this._style = value;
                    this.SendPropertyChanged("style", value);
                    this.OnstyleChanged();
                }
            }
        }
        /// <summary>
        /// 形象图
        /// </summary>
        [Column(Storage="_surface", DbType="varchar(200)")]
        [DisplayName("形象图")]
        [Description("形象图")]
        public String surface {
            get {
                return this._surface;
            }
            set {
                if ((this._surface != value)) {
                    this.OnsurfaceChanging(value);
                    this.SendPropertyChanging("surface", value);
                    this._surface = value;
                    this.SendPropertyChanged("surface", value);
                    this.OnsurfaceChanged();
                }
            }
        }
        /// <summary>
        /// logo
        /// </summary>
        [Column(Storage="_logo", DbType="varchar(40)")]
        [DisplayName("logo")]
        [Description("logo")]
        public String logo {
            get {
                return this._logo;
            }
            set {
                if ((this._logo != value)) {
                    this.OnlogoChanging(value);
                    this.SendPropertyChanging("logo", value);
                    this._logo = value;
                    this.SendPropertyChanged("logo", value);
                    this.OnlogoChanged();
                }
            }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(40)")]
        [DisplayName("缩略图")]
        [Description("缩略图")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        /// 幻灯图
        /// </summary>
        [Column(Storage="_bannel", DbType="varchar(300)")]
        [DisplayName("幻灯图")]
        [Description("幻灯图")]
        public String bannel {
            get {
                return this._bannel;
            }
            set {
                if ((this._bannel != value)) {
                    this.OnbannelChanging(value);
                    this.SendPropertyChanging("bannel", value);
                    this._bannel = value;
                    this.SendPropertyChanged("bannel", value);
                    this.OnbannelChanged();
                }
            }
        }
        /// <summary>
        /// 描述图
        /// </summary>
        [Column(Storage="_desimage", DbType="varchar(400)")]
        [DisplayName("描述图")]
        [Description("描述图")]
        public String desimage {
            get {
                return this._desimage;
            }
            set {
                if ((this._desimage != value)) {
                    this.OndesimageChanging(value);
                    this.SendPropertyChanging("desimage", value);
                    this._desimage = value;
                    this.SendPropertyChanged("desimage", value);
                    this.OndesimageChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="ntext")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        [Column(Storage="_keywords", DbType="nvarchar(200)")]
        [DisplayName("关键字")]
        [Description("关键字")]
        public String keywords {
            get {
                return this._keywords;
            }
            set {
                if ((this._keywords != value)) {
                    this.OnkeywordsChanging(value);
                    this.SendPropertyChanging("keywords", value);
                    this._keywords = value;
                    this.SendPropertyChanged("keywords", value);
                    this.OnkeywordsChanged();
                }
            }
        }
        /// <summary>
        /// 模版ID
        /// </summary>
        [Column(Storage="_template", DbType="varchar(50)")]
        [DisplayName("模版ID")]
        [Description("模版ID")]
        public String template {
            get {
                return this._template;
            }
            set {
                if ((this._template != value)) {
                    this.OntemplateChanging(value);
                    this.SendPropertyChanging("template", value);
                    this._template = value;
                    this.SendPropertyChanged("template", value);
                    this.OntemplateChanged();
                }
            }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        [Column(Storage="_hits", DbType="int")]
        [DisplayName("点击量")]
        [Description("点击量")]
        public Int32? hits {
            get {
                return this._hits;
            }
            set {
                if ((this._hits != value)) {
                    this.OnhitsChanging(value);
                    this.SendPropertyChanging("hits", value);
                    this._hits = value;
                    this.SendPropertyChanged("hits", value);
                    this.OnhitsChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column(Storage="_createmid", DbType="int")]
        [DisplayName("创建人")]
        [Description("创建人")]
        public Int32? createmid {
            get {
                return this._createmid;
            }
            set {
                if ((this._createmid != value)) {
                    this.OncreatemidChanging(value);
                    this.SendPropertyChanging("createmid", value);
                    this._createmid = value;
                    this.SendPropertyChanged("createmid", value);
                    this.OncreatemidChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改人
        /// </summary>
        [Column(Storage="_lasteditid", DbType="int")]
        [DisplayName("最后修改人")]
        [Description("最后修改人")]
        public Int32? lasteditid {
            get {
                return this._lasteditid;
            }
            set {
                if ((this._lasteditid != value)) {
                    this.OnlasteditidChanging(value);
                    this.SendPropertyChanging("lasteditid", value);
                    this._lasteditid = value;
                    this.SendPropertyChanged("lasteditid", value);
                    this.OnlasteditidChanged();
                }
            }
        }
        /// <summary>
        /// 最后个改
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最后个改")]
        [Description("最后个改")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        [Column(Storage="_auditstatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("审核状态")]
        [Description("审核状态")]
        public Int32 auditstatus {
            get {
                return this._auditstatus;
            }
            set {
                this.OnauditstatusChanging(value);
                this.SendPropertyChanging("auditstatus", value);
                this._auditstatus = value;
                this.SendPropertyChanged("auditstatus", value);
                this.OnauditstatusChanged();
            }
        }
        /// <summary>
        /// 在线状态
        /// </summary>
        [Column(Storage="_linestatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("在线状态")]
        [Description("在线状态")]
        public Int32 linestatus {
            get {
                return this._linestatus;
            }
            set {
                this.OnlinestatusChanging(value);
                this.SendPropertyChanging("linestatus", value);
                this._linestatus = value;
                this.SendPropertyChanged("linestatus", value);
                this.OnlinestatusChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_color", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String color {
            get {
                return this._color;
            }
            set {
                if ((this._color != value)) {
                    this.OncolorChanging(value);
                    this.SendPropertyChanging("color", value);
                    this._color = value;
                    this.SendPropertyChanged("color", value);
                    this.OncolorChanged();
                }
            }
        }
    }
    /// <summary>
    /// 厂家表
    /// </summary>
    [Table(Name="t_company")]
    [Serializable()]
    [DisplayName("厂家表")]
    [Description("厂家表")]
    public partial class Mcompany : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 用户表ID
        /// </summary>
        Int32 _mid;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 索引
        /// </summary>
        String _letter;
        /// <summary>
        /// 组ID
        /// </summary>
        Int32 _groupid;
        /// <summary>
        /// 属性
        /// </summary>
        String _attribute;
        /// <summary>
        /// 行业
        /// </summary>
        String _industry;
        /// <summary>
        /// 产品分类
        /// </summary>
        String _productcategory;
        /// <summary>
        /// 是否vip
        /// </summary>
        Int32? _vip;
        /// <summary>
        /// 地区代码
        /// </summary>
        String _areacode;
        /// <summary>
        /// 地址
        /// </summary>
        String _address;
        /// <summary>
        /// 地图API值
        /// </summary>
        String _mapapi;
        /// <summary>
        /// 外观图
        /// </summary>
        Int32? _staffsize;
        /// <summary>
        /// 注册时间
        /// </summary>
        String _regyear;
        /// <summary>
        /// 注册城市
        /// </summary>
        String _regcity;
        /// <summary>
        /// 销售信息
        /// </summary>
        String _buy;
        /// <summary>
        /// 采购信息
        /// </summary>
        String _sell;
        /// <summary>
        /// 连系人
        /// </summary>
        String _linkman;
        /// <summary>
        /// 联系电话
        /// </summary>
        String _phone;
        /// <summary>
        /// 联系手机
        /// </summary>
        String _mphone;
        /// <summary>
        /// 传真
        /// </summary>
        String _fax;
        /// <summary>
        /// 邮件
        /// </summary>
        String _email;
        /// <summary>
        /// 邮编
        /// </summary>
        String _postcode;
        /// <summary>
        /// 主页
        /// </summary>
        String _homepage;
        /// <summary>
        /// 域名
        /// </summary>
        String _domain;
        /// <summary>
        /// 域名IP
        /// </summary>
        String _domainip;
        /// <summary>
        /// 备案号
        /// </summary>
        String _icp;
        /// <summary>
        /// 外观图
        /// </summary>
        String _surface;
        /// <summary>
        /// logo
        /// </summary>
        String _logo;
        /// <summary>
        /// 缩略图
        /// </summary>
        String _thumb;
        /// <summary>
        /// 幻灯图
        /// </summary>
        String _bannel;
        /// <summary>
        /// 描述图
        /// </summary>
        String _desimage;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 关键字
        /// </summary>
        String _keywords;
        /// <summary>
        /// 模版ID
        /// </summary>
        String _template;
        /// <summary>
        /// 点击量
        /// </summary>
        Int32? _hits;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 创建人
        /// </summary>
        Int32? _createmid;
        /// <summary>
        /// 最后修改人
        /// </summary>
        Int32? _lastedid;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        /// 审核状态
        /// </summary>
        Int32 _auditstatus;
        /// <summary>
        /// 上下线状态
        /// </summary>
        Int32 _linestatus;
        /// <summary>
        ///  
        /// </summary>
        String _license;
        /// <summary>
        ///  
        /// </summary>
        String _registration;
        /// <summary>
        ///  
        /// </summary>
        String _organization;
        /// <summary>
        ///  
        /// </summary>
        DateTime? _Createtime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 mid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmidChanging(Int32 value);
        /// <summary>
        /// 当 mid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 letter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnletterChanging(String value);
        /// <summary>
        /// 当 letter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnletterChanged();
        /// <summary>
        /// 当 groupid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OngroupidChanging(Int32 value);
        /// <summary>
        /// 当 groupid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OngroupidChanged();
        /// <summary>
        /// 当 attribute 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnattributeChanging(String value);
        /// <summary>
        /// 当 attribute 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnattributeChanged();
        /// <summary>
        /// 当 industry 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnindustryChanging(String value);
        /// <summary>
        /// 当 industry 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnindustryChanged();
        /// <summary>
        /// 当 productcategory 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcategoryChanging(String value);
        /// <summary>
        /// 当 productcategory 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcategoryChanged();
        /// <summary>
        /// 当 vip 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvipChanging(Int32? value);
        /// <summary>
        /// 当 vip 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvipChanged();
        /// <summary>
        /// 当 areacode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnareacodeChanging(String value);
        /// <summary>
        /// 当 areacode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnareacodeChanged();
        /// <summary>
        /// 当 address 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaddressChanging(String value);
        /// <summary>
        /// 当 address 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaddressChanged();
        /// <summary>
        /// 当 mapapi 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmapapiChanging(String value);
        /// <summary>
        /// 当 mapapi 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmapapiChanged();
        /// <summary>
        /// 当 staffsize 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstaffsizeChanging(Int32? value);
        /// <summary>
        /// 当 staffsize 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstaffsizeChanged();
        /// <summary>
        /// 当 regyear 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnregyearChanging(String value);
        /// <summary>
        /// 当 regyear 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnregyearChanged();
        /// <summary>
        /// 当 regcity 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnregcityChanging(String value);
        /// <summary>
        /// 当 regcity 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnregcityChanged();
        /// <summary>
        /// 当 buy 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbuyChanging(String value);
        /// <summary>
        /// 当 buy 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbuyChanged();
        /// <summary>
        /// 当 sell 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsellChanging(String value);
        /// <summary>
        /// 当 sell 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsellChanged();
        /// <summary>
        /// 当 linkman 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinkmanChanging(String value);
        /// <summary>
        /// 当 linkman 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinkmanChanged();
        /// <summary>
        /// 当 phone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnphoneChanging(String value);
        /// <summary>
        /// 当 phone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnphoneChanged();
        /// <summary>
        /// 当 mphone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmphoneChanging(String value);
        /// <summary>
        /// 当 mphone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmphoneChanged();
        /// <summary>
        /// 当 fax 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnfaxChanging(String value);
        /// <summary>
        /// 当 fax 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnfaxChanged();
        /// <summary>
        /// 当 email 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnemailChanging(String value);
        /// <summary>
        /// 当 email 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnemailChanged();
        /// <summary>
        /// 当 postcode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpostcodeChanging(String value);
        /// <summary>
        /// 当 postcode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpostcodeChanged();
        /// <summary>
        /// 当 homepage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhomepageChanging(String value);
        /// <summary>
        /// 当 homepage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhomepageChanged();
        /// <summary>
        /// 当 domain 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndomainChanging(String value);
        /// <summary>
        /// 当 domain 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndomainChanged();
        /// <summary>
        /// 当 domainip 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndomainipChanging(String value);
        /// <summary>
        /// 当 domainip 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndomainipChanged();
        /// <summary>
        /// 当 icp 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnicpChanging(String value);
        /// <summary>
        /// 当 icp 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnicpChanged();
        /// <summary>
        /// 当 surface 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsurfaceChanging(String value);
        /// <summary>
        /// 当 surface 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsurfaceChanged();
        /// <summary>
        /// 当 logo 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlogoChanging(String value);
        /// <summary>
        /// 当 logo 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlogoChanged();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 bannel 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannelChanging(String value);
        /// <summary>
        /// 当 bannel 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannelChanged();
        /// <summary>
        /// 当 desimage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndesimageChanging(String value);
        /// <summary>
        /// 当 desimage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndesimageChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 keywords 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnkeywordsChanging(String value);
        /// <summary>
        /// 当 keywords 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnkeywordsChanged();
        /// <summary>
        /// 当 template 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntemplateChanging(String value);
        /// <summary>
        /// 当 template 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntemplateChanged();
        /// <summary>
        /// 当 hits 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhitsChanging(Int32? value);
        /// <summary>
        /// 当 hits 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhitsChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 createmid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatemidChanging(Int32? value);
        /// <summary>
        /// 当 createmid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatemidChanged();
        /// <summary>
        /// 当 lastedid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedidChanging(Int32? value);
        /// <summary>
        /// 当 lastedid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedidChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        /// <summary>
        /// 当 auditstatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauditstatusChanging(Int32 value);
        /// <summary>
        /// 当 auditstatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauditstatusChanged();
        /// <summary>
        /// 当 linestatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinestatusChanging(Int32 value);
        /// <summary>
        /// 当 linestatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinestatusChanged();
        /// <summary>
        /// 当 license 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlicenseChanging(String value);
        /// <summary>
        /// 当 license 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlicenseChanged();
        /// <summary>
        /// 当 registration 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnregistrationChanging(String value);
        /// <summary>
        /// 当 registration 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnregistrationChanged();
        /// <summary>
        /// 当 organization 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnorganizationChanging(String value);
        /// <summary>
        /// 当 organization 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnorganizationChanged();
        /// <summary>
        /// 当 Createtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnCreatetimeChanging(DateTime? value);
        /// <summary>
        /// 当 Createtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnCreatetimeChanged();
        
        /// <summary>
        /// 初始化 Mcompany 实体类的新实例。
        /// </summary>
        public Mcompany() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 用户表ID
        /// </summary>
        [Column(Storage="_mid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("用户表ID")]
        [Description("用户表ID")]
        public Int32 mid {
            get {
                return this._mid;
            }
            set {
                this.OnmidChanging(value);
                this.SendPropertyChanging("mid", value);
                this._mid = value;
                this.SendPropertyChanged("mid", value);
                this.OnmidChanged();
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(80)")]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                if ((this._title != value)) {
                    this.OntitleChanging(value);
                    this.SendPropertyChanging("title", value);
                    this._title = value;
                    this.SendPropertyChanged("title", value);
                    this.OntitleChanged();
                }
            }
        }
        /// <summary>
        /// 索引
        /// </summary>
        [Column(Storage="_letter", DbType="varchar(20)")]
        [DisplayName("索引")]
        [Description("索引")]
        public String letter {
            get {
                return this._letter;
            }
            set {
                if ((this._letter != value)) {
                    this.OnletterChanging(value);
                    this.SendPropertyChanging("letter", value);
                    this._letter = value;
                    this.SendPropertyChanged("letter", value);
                    this.OnletterChanged();
                }
            }
        }
        /// <summary>
        /// 组ID
        /// </summary>
        [Column(Storage="_groupid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("组ID")]
        [Description("组ID")]
        public Int32 groupid {
            get {
                return this._groupid;
            }
            set {
                this.OngroupidChanging(value);
                this.SendPropertyChanging("groupid", value);
                this._groupid = value;
                this.SendPropertyChanged("groupid", value);
                this.OngroupidChanged();
            }
        }
        /// <summary>
        /// 属性
        /// </summary>
        [Column(Storage="_attribute", DbType="varchar(100)")]
        [DisplayName("属性")]
        [Description("属性")]
        public String attribute {
            get {
                return this._attribute;
            }
            set {
                if ((this._attribute != value)) {
                    this.OnattributeChanging(value);
                    this.SendPropertyChanging("attribute", value);
                    this._attribute = value;
                    this.SendPropertyChanged("attribute", value);
                    this.OnattributeChanged();
                }
            }
        }
        /// <summary>
        /// 行业
        /// </summary>
        [Column(Storage="_industry", DbType="varchar(50)")]
        [DisplayName("行业")]
        [Description("行业")]
        public String industry {
            get {
                return this._industry;
            }
            set {
                if ((this._industry != value)) {
                    this.OnindustryChanging(value);
                    this.SendPropertyChanging("industry", value);
                    this._industry = value;
                    this.SendPropertyChanged("industry", value);
                    this.OnindustryChanged();
                }
            }
        }
        /// <summary>
        /// 产品分类
        /// </summary>
        [Column(Storage="_productcategory", DbType="varchar(50)")]
        [DisplayName("产品分类")]
        [Description("产品分类")]
        public String productcategory {
            get {
                return this._productcategory;
            }
            set {
                if ((this._productcategory != value)) {
                    this.OnproductcategoryChanging(value);
                    this.SendPropertyChanging("productcategory", value);
                    this._productcategory = value;
                    this.SendPropertyChanged("productcategory", value);
                    this.OnproductcategoryChanged();
                }
            }
        }
        /// <summary>
        /// 是否vip
        /// </summary>
        [Column(Storage="_vip", DbType="int")]
        [DisplayName("是否vip")]
        [Description("是否vip")]
        public Int32? vip {
            get {
                return this._vip;
            }
            set {
                if ((this._vip != value)) {
                    this.OnvipChanging(value);
                    this.SendPropertyChanging("vip", value);
                    this._vip = value;
                    this.SendPropertyChanged("vip", value);
                    this.OnvipChanged();
                }
            }
        }
        /// <summary>
        /// 地区代码
        /// </summary>
        [Column(Storage="_areacode", DbType="varchar(10)")]
        [DisplayName("地区代码")]
        [Description("地区代码")]
        public String areacode {
            get {
                return this._areacode;
            }
            set {
                if ((this._areacode != value)) {
                    this.OnareacodeChanging(value);
                    this.SendPropertyChanging("areacode", value);
                    this._areacode = value;
                    this.SendPropertyChanged("areacode", value);
                    this.OnareacodeChanged();
                }
            }
        }
        /// <summary>
        /// 地址
        /// </summary>
        [Column(Storage="_address", DbType="nvarchar(60)")]
        [DisplayName("地址")]
        [Description("地址")]
        public String address {
            get {
                return this._address;
            }
            set {
                if ((this._address != value)) {
                    this.OnaddressChanging(value);
                    this.SendPropertyChanging("address", value);
                    this._address = value;
                    this.SendPropertyChanged("address", value);
                    this.OnaddressChanged();
                }
            }
        }
        /// <summary>
        /// 地图API值
        /// </summary>
        [Column(Storage="_mapapi", DbType="nvarchar(80)")]
        [DisplayName("地图API值")]
        [Description("地图API值")]
        public String mapapi {
            get {
                return this._mapapi;
            }
            set {
                if ((this._mapapi != value)) {
                    this.OnmapapiChanging(value);
                    this.SendPropertyChanging("mapapi", value);
                    this._mapapi = value;
                    this.SendPropertyChanged("mapapi", value);
                    this.OnmapapiChanged();
                }
            }
        }
        /// <summary>
        /// 外观图
        /// </summary>
        [Column(Storage="_staffsize", DbType="int")]
        [DisplayName("外观图")]
        [Description("外观图")]
        public Int32? staffsize {
            get {
                return this._staffsize;
            }
            set {
                if ((this._staffsize != value)) {
                    this.OnstaffsizeChanging(value);
                    this.SendPropertyChanging("staffsize", value);
                    this._staffsize = value;
                    this.SendPropertyChanged("staffsize", value);
                    this.OnstaffsizeChanged();
                }
            }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        [Column(Storage="_regyear", DbType="varchar(7)")]
        [DisplayName("注册时间")]
        [Description("注册时间")]
        public String regyear {
            get {
                return this._regyear;
            }
            set {
                if ((this._regyear != value)) {
                    this.OnregyearChanging(value);
                    this.SendPropertyChanging("regyear", value);
                    this._regyear = value;
                    this.SendPropertyChanged("regyear", value);
                    this.OnregyearChanged();
                }
            }
        }
        /// <summary>
        /// 注册城市
        /// </summary>
        [Column(Storage="_regcity", DbType="varchar(10)")]
        [DisplayName("注册城市")]
        [Description("注册城市")]
        public String regcity {
            get {
                return this._regcity;
            }
            set {
                if ((this._regcity != value)) {
                    this.OnregcityChanging(value);
                    this.SendPropertyChanging("regcity", value);
                    this._regcity = value;
                    this.SendPropertyChanged("regcity", value);
                    this.OnregcityChanged();
                }
            }
        }
        /// <summary>
        /// 销售信息
        /// </summary>
        [Column(Storage="_buy", DbType="nvarchar(300)")]
        [DisplayName("销售信息")]
        [Description("销售信息")]
        public String buy {
            get {
                return this._buy;
            }
            set {
                if ((this._buy != value)) {
                    this.OnbuyChanging(value);
                    this.SendPropertyChanging("buy", value);
                    this._buy = value;
                    this.SendPropertyChanged("buy", value);
                    this.OnbuyChanged();
                }
            }
        }
        /// <summary>
        /// 采购信息
        /// </summary>
        [Column(Storage="_sell", DbType="nvarchar(300)")]
        [DisplayName("采购信息")]
        [Description("采购信息")]
        public String sell {
            get {
                return this._sell;
            }
            set {
                if ((this._sell != value)) {
                    this.OnsellChanging(value);
                    this.SendPropertyChanging("sell", value);
                    this._sell = value;
                    this.SendPropertyChanged("sell", value);
                    this.OnsellChanged();
                }
            }
        }
        /// <summary>
        /// 连系人
        /// </summary>
        [Column(Storage="_linkman", DbType="nvarchar(20)")]
        [DisplayName("连系人")]
        [Description("连系人")]
        public String linkman {
            get {
                return this._linkman;
            }
            set {
                if ((this._linkman != value)) {
                    this.OnlinkmanChanging(value);
                    this.SendPropertyChanging("linkman", value);
                    this._linkman = value;
                    this.SendPropertyChanged("linkman", value);
                    this.OnlinkmanChanged();
                }
            }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Column(Storage="_phone", DbType="varchar(20)")]
        [DisplayName("联系电话")]
        [Description("联系电话")]
        public String phone {
            get {
                return this._phone;
            }
            set {
                if ((this._phone != value)) {
                    this.OnphoneChanging(value);
                    this.SendPropertyChanging("phone", value);
                    this._phone = value;
                    this.SendPropertyChanged("phone", value);
                    this.OnphoneChanged();
                }
            }
        }
        /// <summary>
        /// 联系手机
        /// </summary>
        [Column(Storage="_mphone", DbType="varchar(20)")]
        [DisplayName("联系手机")]
        [Description("联系手机")]
        public String mphone {
            get {
                return this._mphone;
            }
            set {
                if ((this._mphone != value)) {
                    this.OnmphoneChanging(value);
                    this.SendPropertyChanging("mphone", value);
                    this._mphone = value;
                    this.SendPropertyChanged("mphone", value);
                    this.OnmphoneChanged();
                }
            }
        }
        /// <summary>
        /// 传真
        /// </summary>
        [Column(Storage="_fax", DbType="varchar(20)")]
        [DisplayName("传真")]
        [Description("传真")]
        public String fax {
            get {
                return this._fax;
            }
            set {
                if ((this._fax != value)) {
                    this.OnfaxChanging(value);
                    this.SendPropertyChanging("fax", value);
                    this._fax = value;
                    this.SendPropertyChanged("fax", value);
                    this.OnfaxChanged();
                }
            }
        }
        /// <summary>
        /// 邮件
        /// </summary>
        [Column(Storage="_email", DbType="varchar(50)")]
        [DisplayName("邮件")]
        [Description("邮件")]
        public String email {
            get {
                return this._email;
            }
            set {
                if ((this._email != value)) {
                    this.OnemailChanging(value);
                    this.SendPropertyChanging("email", value);
                    this._email = value;
                    this.SendPropertyChanged("email", value);
                    this.OnemailChanged();
                }
            }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        [Column(Storage="_postcode", DbType="varchar(15)")]
        [DisplayName("邮编")]
        [Description("邮编")]
        public String postcode {
            get {
                return this._postcode;
            }
            set {
                if ((this._postcode != value)) {
                    this.OnpostcodeChanging(value);
                    this.SendPropertyChanging("postcode", value);
                    this._postcode = value;
                    this.SendPropertyChanged("postcode", value);
                    this.OnpostcodeChanged();
                }
            }
        }
        /// <summary>
        /// 主页
        /// </summary>
        [Column(Storage="_homepage", DbType="varchar(50)")]
        [DisplayName("主页")]
        [Description("主页")]
        public String homepage {
            get {
                return this._homepage;
            }
            set {
                if ((this._homepage != value)) {
                    this.OnhomepageChanging(value);
                    this.SendPropertyChanging("homepage", value);
                    this._homepage = value;
                    this.SendPropertyChanged("homepage", value);
                    this.OnhomepageChanged();
                }
            }
        }
        /// <summary>
        /// 域名
        /// </summary>
        [Column(Storage="_domain", DbType="varchar(50)")]
        [DisplayName("域名")]
        [Description("域名")]
        public String domain {
            get {
                return this._domain;
            }
            set {
                if ((this._domain != value)) {
                    this.OndomainChanging(value);
                    this.SendPropertyChanging("domain", value);
                    this._domain = value;
                    this.SendPropertyChanged("domain", value);
                    this.OndomainChanged();
                }
            }
        }
        /// <summary>
        /// 域名IP
        /// </summary>
        [Column(Storage="_domainip", DbType="varchar(50)")]
        [DisplayName("域名IP")]
        [Description("域名IP")]
        public String domainip {
            get {
                return this._domainip;
            }
            set {
                if ((this._domainip != value)) {
                    this.OndomainipChanging(value);
                    this.SendPropertyChanging("domainip", value);
                    this._domainip = value;
                    this.SendPropertyChanged("domainip", value);
                    this.OndomainipChanged();
                }
            }
        }
        /// <summary>
        /// 备案号
        /// </summary>
        [Column(Storage="_icp", DbType="nvarchar(50)")]
        [DisplayName("备案号")]
        [Description("备案号")]
        public String icp {
            get {
                return this._icp;
            }
            set {
                if ((this._icp != value)) {
                    this.OnicpChanging(value);
                    this.SendPropertyChanging("icp", value);
                    this._icp = value;
                    this.SendPropertyChanged("icp", value);
                    this.OnicpChanged();
                }
            }
        }
        /// <summary>
        /// 外观图
        /// </summary>
        [Column(Storage="_surface", DbType="varchar(200)")]
        [DisplayName("外观图")]
        [Description("外观图")]
        public String surface {
            get {
                return this._surface;
            }
            set {
                if ((this._surface != value)) {
                    this.OnsurfaceChanging(value);
                    this.SendPropertyChanging("surface", value);
                    this._surface = value;
                    this.SendPropertyChanged("surface", value);
                    this.OnsurfaceChanged();
                }
            }
        }
        /// <summary>
        /// logo
        /// </summary>
        [Column(Storage="_logo", DbType="varchar(40)")]
        [DisplayName("logo")]
        [Description("logo")]
        public String logo {
            get {
                return this._logo;
            }
            set {
                if ((this._logo != value)) {
                    this.OnlogoChanging(value);
                    this.SendPropertyChanging("logo", value);
                    this._logo = value;
                    this.SendPropertyChanged("logo", value);
                    this.OnlogoChanged();
                }
            }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(40)")]
        [DisplayName("缩略图")]
        [Description("缩略图")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        /// 幻灯图
        /// </summary>
        [Column(Storage="_bannel", DbType="varchar(300)")]
        [DisplayName("幻灯图")]
        [Description("幻灯图")]
        public String bannel {
            get {
                return this._bannel;
            }
            set {
                if ((this._bannel != value)) {
                    this.OnbannelChanging(value);
                    this.SendPropertyChanging("bannel", value);
                    this._bannel = value;
                    this.SendPropertyChanged("bannel", value);
                    this.OnbannelChanged();
                }
            }
        }
        /// <summary>
        /// 描述图
        /// </summary>
        [Column(Storage="_desimage", DbType="varchar(400)")]
        [DisplayName("描述图")]
        [Description("描述图")]
        public String desimage {
            get {
                return this._desimage;
            }
            set {
                if ((this._desimage != value)) {
                    this.OndesimageChanging(value);
                    this.SendPropertyChanging("desimage", value);
                    this._desimage = value;
                    this.SendPropertyChanged("desimage", value);
                    this.OndesimageChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="ntext")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        [Column(Storage="_keywords", DbType="nvarchar(200)")]
        [DisplayName("关键字")]
        [Description("关键字")]
        public String keywords {
            get {
                return this._keywords;
            }
            set {
                if ((this._keywords != value)) {
                    this.OnkeywordsChanging(value);
                    this.SendPropertyChanging("keywords", value);
                    this._keywords = value;
                    this.SendPropertyChanged("keywords", value);
                    this.OnkeywordsChanged();
                }
            }
        }
        /// <summary>
        /// 模版ID
        /// </summary>
        [Column(Storage="_template", DbType="varchar(50)")]
        [DisplayName("模版ID")]
        [Description("模版ID")]
        public String template {
            get {
                return this._template;
            }
            set {
                if ((this._template != value)) {
                    this.OntemplateChanging(value);
                    this.SendPropertyChanging("template", value);
                    this._template = value;
                    this.SendPropertyChanged("template", value);
                    this.OntemplateChanged();
                }
            }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        [Column(Storage="_hits", DbType="int")]
        [DisplayName("点击量")]
        [Description("点击量")]
        public Int32? hits {
            get {
                return this._hits;
            }
            set {
                if ((this._hits != value)) {
                    this.OnhitsChanging(value);
                    this.SendPropertyChanging("hits", value);
                    this._hits = value;
                    this.SendPropertyChanged("hits", value);
                    this.OnhitsChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column(Storage="_createmid", DbType="int")]
        [DisplayName("创建人")]
        [Description("创建人")]
        public Int32? createmid {
            get {
                return this._createmid;
            }
            set {
                if ((this._createmid != value)) {
                    this.OncreatemidChanging(value);
                    this.SendPropertyChanging("createmid", value);
                    this._createmid = value;
                    this.SendPropertyChanged("createmid", value);
                    this.OncreatemidChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改人
        /// </summary>
        [Column(Storage="_lastedid", DbType="int")]
        [DisplayName("最后修改人")]
        [Description("最后修改人")]
        public Int32? lastedid {
            get {
                return this._lastedid;
            }
            set {
                if ((this._lastedid != value)) {
                    this.OnlastedidChanging(value);
                    this.SendPropertyChanging("lastedid", value);
                    this._lastedid = value;
                    this.SendPropertyChanged("lastedid", value);
                    this.OnlastedidChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最后修改时间")]
        [Description("最后修改时间")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        [Column(Storage="_auditstatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("审核状态")]
        [Description("审核状态")]
        public Int32 auditstatus {
            get {
                return this._auditstatus;
            }
            set {
                this.OnauditstatusChanging(value);
                this.SendPropertyChanging("auditstatus", value);
                this._auditstatus = value;
                this.SendPropertyChanged("auditstatus", value);
                this.OnauditstatusChanged();
            }
        }
        /// <summary>
        /// 上下线状态
        /// </summary>
        [Column(Storage="_linestatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("上下线状态")]
        [Description("上下线状态")]
        public Int32 linestatus {
            get {
                return this._linestatus;
            }
            set {
                this.OnlinestatusChanging(value);
                this.SendPropertyChanging("linestatus", value);
                this._linestatus = value;
                this.SendPropertyChanged("linestatus", value);
                this.OnlinestatusChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_license", DbType="nvarchar(100)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String license {
            get {
                return this._license;
            }
            set {
                if ((this._license != value)) {
                    this.OnlicenseChanging(value);
                    this.SendPropertyChanging("license", value);
                    this._license = value;
                    this.SendPropertyChanged("license", value);
                    this.OnlicenseChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_registration", DbType="nvarchar(100)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String registration {
            get {
                return this._registration;
            }
            set {
                if ((this._registration != value)) {
                    this.OnregistrationChanging(value);
                    this.SendPropertyChanging("registration", value);
                    this._registration = value;
                    this.SendPropertyChanged("registration", value);
                    this.OnregistrationChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_organization", DbType="nvarchar(100)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String organization {
            get {
                return this._organization;
            }
            set {
                if ((this._organization != value)) {
                    this.OnorganizationChanging(value);
                    this.SendPropertyChanging("organization", value);
                    this._organization = value;
                    this.SendPropertyChanged("organization", value);
                    this.OnorganizationChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_Createtime", DbType="datetime")]
        [DisplayName(" ")]
        [Description(" ")]
        public DateTime? Createtime {
            get {
                return this._Createtime;
            }
            set {
                if ((this._Createtime != value)) {
                    this.OnCreatetimeChanging(value);
                    this.SendPropertyChanging("Createtime", value);
                    this._Createtime = value;
                    this.SendPropertyChanged("Createtime", value);
                    this.OnCreatetimeChanged();
                }
            }
        }
    }
    /// <summary>
    /// 厂家组表
    /// </summary>
    [Table(Name="t_companygroup")]
    [Serializable()]
    [DisplayName("厂家组表")]
    [Description("厂家组表")]
    public partial class Mcompanygroup : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 组名称
        /// </summary>
        String _title;
        /// <summary>
        /// 组名称颜色
        /// </summary>
        String _color;
        /// <summary>
        /// 组图标
        /// </summary>
        String _avatar;
        /// <summary>
        /// 积分达到
        /// </summary>
        Decimal? _integral;
        /// <summary>
        /// 金钱达到
        /// </summary>
        Decimal? _money;
        /// <summary>
        /// 广告数量限制
        /// </summary>
        Int32? _adcount;
        /// <summary>
        /// 店铺数量限制
        /// </summary>
        Int32? _shopcount;
        /// <summary>
        /// 品牌数量限制
        /// </summary>
        Int32? _brandcount;
        /// <summary>
        /// 促销信息数量限制
        /// </summary>
        Int32? _promotioncount;
        /// <summary>
        /// 推荐数量限制
        /// </summary>
        Int32? _adrecommend;
        /// <summary>
        /// 推荐店铺数量限制
        /// </summary>
        Int32? _shoprecommend;
        /// <summary>
        ///  
        /// </summary>
        Int32? _brandrecommend;
        /// <summary>
        ///  
        /// </summary>
        Int32? _promotionrecommend;
        /// <summary>
        ///  
        /// </summary>
        String _permissions;
        /// <summary>
        /// 级别
        /// </summary>
        Int32? _lev;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 color 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncolorChanging(String value);
        /// <summary>
        /// 当 color 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncolorChanged();
        /// <summary>
        /// 当 avatar 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnavatarChanging(String value);
        /// <summary>
        /// 当 avatar 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnavatarChanged();
        /// <summary>
        /// 当 integral 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnintegralChanging(Decimal? value);
        /// <summary>
        /// 当 integral 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnintegralChanged();
        /// <summary>
        /// 当 money 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmoneyChanging(Decimal? value);
        /// <summary>
        /// 当 money 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmoneyChanged();
        /// <summary>
        /// 当 adcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadcountChanging(Int32? value);
        /// <summary>
        /// 当 adcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadcountChanged();
        /// <summary>
        /// 当 shopcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshopcountChanging(Int32? value);
        /// <summary>
        /// 当 shopcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshopcountChanged();
        /// <summary>
        /// 当 brandcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandcountChanging(Int32? value);
        /// <summary>
        /// 当 brandcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandcountChanged();
        /// <summary>
        /// 当 promotioncount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromotioncountChanging(Int32? value);
        /// <summary>
        /// 当 promotioncount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromotioncountChanged();
        /// <summary>
        /// 当 adrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadrecommendChanging(Int32? value);
        /// <summary>
        /// 当 adrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadrecommendChanged();
        /// <summary>
        /// 当 shoprecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshoprecommendChanging(Int32? value);
        /// <summary>
        /// 当 shoprecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshoprecommendChanged();
        /// <summary>
        /// 当 brandrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandrecommendChanging(Int32? value);
        /// <summary>
        /// 当 brandrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandrecommendChanged();
        /// <summary>
        /// 当 promotionrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromotionrecommendChanging(Int32? value);
        /// <summary>
        /// 当 promotionrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromotionrecommendChanged();
        /// <summary>
        /// 当 permissions 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpermissionsChanging(String value);
        /// <summary>
        /// 当 permissions 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpermissionsChanged();
        /// <summary>
        /// 当 lev 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlevChanging(Int32? value);
        /// <summary>
        /// 当 lev 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlevChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Mcompanygroup 实体类的新实例。
        /// </summary>
        public Mcompanygroup() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 组名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(30) NOT NULL", CanBeNull=false)]
        [DisplayName("组名称")]
        [Description("组名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 组名称颜色
        /// </summary>
        [Column(Storage="_color", DbType="char(7)")]
        [DisplayName("组名称颜色")]
        [Description("组名称颜色")]
        public String color {
            get {
                return this._color;
            }
            set {
                if ((this._color != value)) {
                    this.OncolorChanging(value);
                    this.SendPropertyChanging("color", value);
                    this._color = value;
                    this.SendPropertyChanged("color", value);
                    this.OncolorChanged();
                }
            }
        }
        /// <summary>
        /// 组图标
        /// </summary>
        [Column(Storage="_avatar", DbType="varchar(40)")]
        [DisplayName("组图标")]
        [Description("组图标")]
        public String avatar {
            get {
                return this._avatar;
            }
            set {
                if ((this._avatar != value)) {
                    this.OnavatarChanging(value);
                    this.SendPropertyChanging("avatar", value);
                    this._avatar = value;
                    this.SendPropertyChanged("avatar", value);
                    this.OnavatarChanged();
                }
            }
        }
        /// <summary>
        /// 积分达到
        /// </summary>
        [Column(Storage="_integral", DbType="decimal")]
        [DisplayName("积分达到")]
        [Description("积分达到")]
        public Decimal? integral {
            get {
                return this._integral;
            }
            set {
                if ((this._integral != value)) {
                    this.OnintegralChanging(value);
                    this.SendPropertyChanging("integral", value);
                    this._integral = value;
                    this.SendPropertyChanged("integral", value);
                    this.OnintegralChanged();
                }
            }
        }
        /// <summary>
        /// 金钱达到
        /// </summary>
        [Column(Storage="_money", DbType="decimal")]
        [DisplayName("金钱达到")]
        [Description("金钱达到")]
        public Decimal? money {
            get {
                return this._money;
            }
            set {
                if ((this._money != value)) {
                    this.OnmoneyChanging(value);
                    this.SendPropertyChanging("money", value);
                    this._money = value;
                    this.SendPropertyChanged("money", value);
                    this.OnmoneyChanged();
                }
            }
        }
        /// <summary>
        /// 广告数量限制
        /// </summary>
        [Column(Storage="_adcount", DbType="int")]
        [DisplayName("广告数量限制")]
        [Description("广告数量限制")]
        public Int32? adcount {
            get {
                return this._adcount;
            }
            set {
                if ((this._adcount != value)) {
                    this.OnadcountChanging(value);
                    this.SendPropertyChanging("adcount", value);
                    this._adcount = value;
                    this.SendPropertyChanged("adcount", value);
                    this.OnadcountChanged();
                }
            }
        }
        /// <summary>
        /// 店铺数量限制
        /// </summary>
        [Column(Storage="_shopcount", DbType="int")]
        [DisplayName("店铺数量限制")]
        [Description("店铺数量限制")]
        public Int32? shopcount {
            get {
                return this._shopcount;
            }
            set {
                if ((this._shopcount != value)) {
                    this.OnshopcountChanging(value);
                    this.SendPropertyChanging("shopcount", value);
                    this._shopcount = value;
                    this.SendPropertyChanged("shopcount", value);
                    this.OnshopcountChanged();
                }
            }
        }
        /// <summary>
        /// 品牌数量限制
        /// </summary>
        [Column(Storage="_brandcount", DbType="int")]
        [DisplayName("品牌数量限制")]
        [Description("品牌数量限制")]
        public Int32? brandcount {
            get {
                return this._brandcount;
            }
            set {
                if ((this._brandcount != value)) {
                    this.OnbrandcountChanging(value);
                    this.SendPropertyChanging("brandcount", value);
                    this._brandcount = value;
                    this.SendPropertyChanged("brandcount", value);
                    this.OnbrandcountChanged();
                }
            }
        }
        /// <summary>
        /// 促销信息数量限制
        /// </summary>
        [Column(Storage="_promotioncount", DbType="int")]
        [DisplayName("促销信息数量限制")]
        [Description("促销信息数量限制")]
        public Int32? promotioncount {
            get {
                return this._promotioncount;
            }
            set {
                if ((this._promotioncount != value)) {
                    this.OnpromotioncountChanging(value);
                    this.SendPropertyChanging("promotioncount", value);
                    this._promotioncount = value;
                    this.SendPropertyChanged("promotioncount", value);
                    this.OnpromotioncountChanged();
                }
            }
        }
        /// <summary>
        /// 推荐数量限制
        /// </summary>
        [Column(Storage="_adrecommend", DbType="int")]
        [DisplayName("推荐数量限制")]
        [Description("推荐数量限制")]
        public Int32? adrecommend {
            get {
                return this._adrecommend;
            }
            set {
                if ((this._adrecommend != value)) {
                    this.OnadrecommendChanging(value);
                    this.SendPropertyChanging("adrecommend", value);
                    this._adrecommend = value;
                    this.SendPropertyChanged("adrecommend", value);
                    this.OnadrecommendChanged();
                }
            }
        }
        /// <summary>
        /// 推荐店铺数量限制
        /// </summary>
        [Column(Storage="_shoprecommend", DbType="int")]
        [DisplayName("推荐店铺数量限制")]
        [Description("推荐店铺数量限制")]
        public Int32? shoprecommend {
            get {
                return this._shoprecommend;
            }
            set {
                if ((this._shoprecommend != value)) {
                    this.OnshoprecommendChanging(value);
                    this.SendPropertyChanging("shoprecommend", value);
                    this._shoprecommend = value;
                    this.SendPropertyChanged("shoprecommend", value);
                    this.OnshoprecommendChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_brandrecommend", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? brandrecommend {
            get {
                return this._brandrecommend;
            }
            set {
                if ((this._brandrecommend != value)) {
                    this.OnbrandrecommendChanging(value);
                    this.SendPropertyChanging("brandrecommend", value);
                    this._brandrecommend = value;
                    this.SendPropertyChanged("brandrecommend", value);
                    this.OnbrandrecommendChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_promotionrecommend", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? promotionrecommend {
            get {
                return this._promotionrecommend;
            }
            set {
                if ((this._promotionrecommend != value)) {
                    this.OnpromotionrecommendChanging(value);
                    this.SendPropertyChanging("promotionrecommend", value);
                    this._promotionrecommend = value;
                    this.SendPropertyChanged("promotionrecommend", value);
                    this.OnpromotionrecommendChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_permissions", DbType="ntext")]
        [DisplayName(" ")]
        [Description(" ")]
        public String permissions {
            get {
                return this._permissions;
            }
            set {
                if ((this._permissions != value)) {
                    this.OnpermissionsChanging(value);
                    this.SendPropertyChanging("permissions", value);
                    this._permissions = value;
                    this.SendPropertyChanged("permissions", value);
                    this.OnpermissionsChanged();
                }
            }
        }
        /// <summary>
        /// 级别
        /// </summary>
        [Column(Storage="_lev", DbType="int")]
        [DisplayName("级别")]
        [Description("级别")]
        public Int32? lev {
            get {
                return this._lev;
            }
            set {
                if ((this._lev != value)) {
                    this.OnlevChanging(value);
                    this.SendPropertyChanging("lev", value);
                    this._lev = value;
                    this.SendPropertyChanged("lev", value);
                    this.OnlevChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(300)")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    /// 配置表
    /// </summary>
    [Table(Name="t_config")]
    [Serializable()]
    [DisplayName("配置表")]
    [Description("配置表")]
    public partial class Mconfig : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 值
        /// </summary>
        String _value;
        /// <summary>
        /// 配置类型
        /// </summary>
        Int32 _type;
        /// <summary>
        /// 所属模块
        /// </summary>
        Int32 _module;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 value 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvalueChanging(String value);
        /// <summary>
        /// 当 value 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvalueChanged();
        /// <summary>
        /// 当 type 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntypeChanging(Int32 value);
        /// <summary>
        /// 当 type 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntypeChanged();
        /// <summary>
        /// 当 module 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmoduleChanging(Int32 value);
        /// <summary>
        /// 当 module 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmoduleChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Mconfig 实体类的新实例。
        /// </summary>
        public Mconfig() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(400) NOT NULL", CanBeNull=false)]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 值
        /// </summary>
        [Column(Storage="_value", DbType="nvarchar(400) NOT NULL", CanBeNull=false)]
        [DisplayName("值")]
        [Description("值")]
        public String value {
            get {
                return this._value;
            }
            set {
                this.OnvalueChanging(value);
                this.SendPropertyChanging("value", value);
                this._value = value;
                this.SendPropertyChanged("value", value);
                this.OnvalueChanged();
            }
        }
        /// <summary>
        /// 配置类型
        /// </summary>
        [Column(Storage="_type", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("配置类型")]
        [Description("配置类型")]
        public Int32 type {
            get {
                return this._type;
            }
            set {
                this.OntypeChanging(value);
                this.SendPropertyChanging("type", value);
                this._type = value;
                this.SendPropertyChanged("type", value);
                this.OntypeChanged();
            }
        }
        /// <summary>
        /// 所属模块
        /// </summary>
        [Column(Storage="_module", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("所属模块")]
        [Description("所属模块")]
        public Int32 module {
            get {
                return this._module;
            }
            set {
                this.OnmoduleChanging(value);
                this.SendPropertyChanging("module", value);
                this._module = value;
                this.SendPropertyChanged("module", value);
                this.OnmoduleChanged();
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    /// 配置类型表
    /// </summary>
    [Table(Name="t_configtype")]
    [Serializable()]
    [DisplayName("配置类型表")]
    [Description("配置类型表")]
    public partial class Mconfigtype : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 类型名称
        /// </summary>
        String _title;
        /// <summary>
        /// 标识
        /// </summary>
        String _mark;
        /// <summary>
        /// 索引
        /// </summary>
        String _letter;
        /// <summary>
        /// 类型
        /// </summary>
        String _type;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 数量
        /// </summary>
        Int32? _count;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 mark 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarkChanging(String value);
        /// <summary>
        /// 当 mark 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarkChanged();
        /// <summary>
        /// 当 letter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnletterChanging(String value);
        /// <summary>
        /// 当 letter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnletterChanged();
        /// <summary>
        /// 当 type 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntypeChanging(String value);
        /// <summary>
        /// 当 type 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntypeChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 count 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncountChanging(Int32? value);
        /// <summary>
        /// 当 count 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncountChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        
        /// <summary>
        /// 初始化 Mconfigtype 实体类的新实例。
        /// </summary>
        public Mconfigtype() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 类型名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(80)")]
        [DisplayName("类型名称")]
        [Description("类型名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                if ((this._title != value)) {
                    this.OntitleChanging(value);
                    this.SendPropertyChanging("title", value);
                    this._title = value;
                    this.SendPropertyChanged("title", value);
                    this.OntitleChanged();
                }
            }
        }
        /// <summary>
        /// 标识
        /// </summary>
        [Column(Storage="_mark", DbType="varchar(20)")]
        [DisplayName("标识")]
        [Description("标识")]
        public String mark {
            get {
                return this._mark;
            }
            set {
                if ((this._mark != value)) {
                    this.OnmarkChanging(value);
                    this.SendPropertyChanging("mark", value);
                    this._mark = value;
                    this.SendPropertyChanged("mark", value);
                    this.OnmarkChanged();
                }
            }
        }
        /// <summary>
        /// 索引
        /// </summary>
        [Column(Storage="_letter", DbType="varchar(20)")]
        [DisplayName("索引")]
        [Description("索引")]
        public String letter {
            get {
                return this._letter;
            }
            set {
                if ((this._letter != value)) {
                    this.OnletterChanging(value);
                    this.SendPropertyChanging("letter", value);
                    this._letter = value;
                    this.SendPropertyChanged("letter", value);
                    this.OnletterChanged();
                }
            }
        }
        /// <summary>
        /// 类型
        /// </summary>
        [Column(Storage="_type", DbType="varchar(100)")]
        [DisplayName("类型")]
        [Description("类型")]
        public String type {
            get {
                return this._type;
            }
            set {
                if ((this._type != value)) {
                    this.OntypeChanging(value);
                    this.SendPropertyChanging("type", value);
                    this._type = value;
                    this.SendPropertyChanged("type", value);
                    this.OntypeChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 数量
        /// </summary>
        [Column(Storage="_count", DbType="int")]
        [DisplayName("数量")]
        [Description("数量")]
        public Int32? count {
            get {
                return this._count;
            }
            set {
                if ((this._count != value)) {
                    this.OncountChanging(value);
                    this.SendPropertyChanging("count", value);
                    this._count = value;
                    this.SendPropertyChanged("count", value);
                    this.OncountChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(400)")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
    }
    /// <summary>
    /// 经销商
    /// </summary>
    [Table(Name="t_dealer")]
    [Serializable()]
    [DisplayName("经销商")]
    [Description("经销商")]
    public partial class Mdealer : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 用户表ID
        /// </summary>
        Int32 _mid;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 索引
        /// </summary>
        String _letter;
        /// <summary>
        /// 组ID
        /// </summary>
        Int32 _groupid;
        /// <summary>
        /// 属性
        /// </summary>
        String _attribute;
        /// <summary>
        /// 行业
        /// </summary>
        String _industry;
        /// <summary>
        /// 产品分类
        /// </summary>
        String _productcategory;
        /// <summary>
        /// 是否vip
        /// </summary>
        Int32? _vip;
        /// <summary>
        /// 地区代码
        /// </summary>
        String _areacode;
        /// <summary>
        /// 地址
        /// </summary>
        String _address;
        /// <summary>
        /// 地图API值
        /// </summary>
        String _mapapi;
        /// <summary>
        /// 外观图
        /// </summary>
        Int32? _staffsize;
        /// <summary>
        /// 注册时间
        /// </summary>
        String _regyear;
        /// <summary>
        /// 注册城市
        /// </summary>
        String _regcity;
        /// <summary>
        /// 销售信息
        /// </summary>
        String _buy;
        /// <summary>
        /// 采购信息
        /// </summary>
        String _sell;
        /// <summary>
        /// 联系人
        /// </summary>
        String _linkman;
        /// <summary>
        /// 联系电话
        /// </summary>
        String _phone;
        /// <summary>
        /// 联系手机
        /// </summary>
        String _mphone;
        /// <summary>
        /// 传真
        /// </summary>
        String _fax;
        /// <summary>
        /// 邮件
        /// </summary>
        String _email;
        /// <summary>
        /// 邮编
        /// </summary>
        String _postcode;
        /// <summary>
        /// 主页
        /// </summary>
        String _homepage;
        /// <summary>
        /// 域名
        /// </summary>
        String _domain;
        /// <summary>
        /// 域名IP
        /// </summary>
        String _domainip;
        /// <summary>
        /// 备案号
        /// </summary>
        String _icp;
        /// <summary>
        /// 外观图
        /// </summary>
        String _surface;
        /// <summary>
        /// logo
        /// </summary>
        String _logo;
        /// <summary>
        /// 缩略图
        /// </summary>
        String _thumb;
        /// <summary>
        /// 幻灯图
        /// </summary>
        String _bannel;
        /// <summary>
        /// 描述图
        /// </summary>
        String _desimage;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 关键字
        /// </summary>
        String _keywords;
        /// <summary>
        /// 模版ID
        /// </summary>
        String _template;
        /// <summary>
        /// 点击量
        /// </summary>
        Int32? _hits;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 创建人
        /// </summary>
        Int32? _createmid;
        /// <summary>
        /// 最后修改人
        /// </summary>
        Int32? _lastedid;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        /// 审核状态
        /// </summary>
        Int32 _auditstatus;
        /// <summary>
        /// 上下线状态
        /// </summary>
        Int32 _linestatus;
        /// <summary>
        ///  
        /// </summary>
        String _dbook;
        /// <summary>
        ///  
        /// </summary>
        DateTime? _Createtime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 mid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmidChanging(Int32 value);
        /// <summary>
        /// 当 mid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 letter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnletterChanging(String value);
        /// <summary>
        /// 当 letter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnletterChanged();
        /// <summary>
        /// 当 groupid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OngroupidChanging(Int32 value);
        /// <summary>
        /// 当 groupid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OngroupidChanged();
        /// <summary>
        /// 当 attribute 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnattributeChanging(String value);
        /// <summary>
        /// 当 attribute 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnattributeChanged();
        /// <summary>
        /// 当 industry 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnindustryChanging(String value);
        /// <summary>
        /// 当 industry 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnindustryChanged();
        /// <summary>
        /// 当 productcategory 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcategoryChanging(String value);
        /// <summary>
        /// 当 productcategory 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcategoryChanged();
        /// <summary>
        /// 当 vip 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvipChanging(Int32? value);
        /// <summary>
        /// 当 vip 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvipChanged();
        /// <summary>
        /// 当 areacode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnareacodeChanging(String value);
        /// <summary>
        /// 当 areacode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnareacodeChanged();
        /// <summary>
        /// 当 address 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaddressChanging(String value);
        /// <summary>
        /// 当 address 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaddressChanged();
        /// <summary>
        /// 当 mapapi 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmapapiChanging(String value);
        /// <summary>
        /// 当 mapapi 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmapapiChanged();
        /// <summary>
        /// 当 staffsize 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstaffsizeChanging(Int32? value);
        /// <summary>
        /// 当 staffsize 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstaffsizeChanged();
        /// <summary>
        /// 当 regyear 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnregyearChanging(String value);
        /// <summary>
        /// 当 regyear 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnregyearChanged();
        /// <summary>
        /// 当 regcity 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnregcityChanging(String value);
        /// <summary>
        /// 当 regcity 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnregcityChanged();
        /// <summary>
        /// 当 buy 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbuyChanging(String value);
        /// <summary>
        /// 当 buy 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbuyChanged();
        /// <summary>
        /// 当 sell 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsellChanging(String value);
        /// <summary>
        /// 当 sell 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsellChanged();
        /// <summary>
        /// 当 linkman 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinkmanChanging(String value);
        /// <summary>
        /// 当 linkman 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinkmanChanged();
        /// <summary>
        /// 当 phone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnphoneChanging(String value);
        /// <summary>
        /// 当 phone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnphoneChanged();
        /// <summary>
        /// 当 mphone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmphoneChanging(String value);
        /// <summary>
        /// 当 mphone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmphoneChanged();
        /// <summary>
        /// 当 fax 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnfaxChanging(String value);
        /// <summary>
        /// 当 fax 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnfaxChanged();
        /// <summary>
        /// 当 email 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnemailChanging(String value);
        /// <summary>
        /// 当 email 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnemailChanged();
        /// <summary>
        /// 当 postcode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpostcodeChanging(String value);
        /// <summary>
        /// 当 postcode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpostcodeChanged();
        /// <summary>
        /// 当 homepage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhomepageChanging(String value);
        /// <summary>
        /// 当 homepage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhomepageChanged();
        /// <summary>
        /// 当 domain 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndomainChanging(String value);
        /// <summary>
        /// 当 domain 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndomainChanged();
        /// <summary>
        /// 当 domainip 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndomainipChanging(String value);
        /// <summary>
        /// 当 domainip 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndomainipChanged();
        /// <summary>
        /// 当 icp 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnicpChanging(String value);
        /// <summary>
        /// 当 icp 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnicpChanged();
        /// <summary>
        /// 当 surface 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsurfaceChanging(String value);
        /// <summary>
        /// 当 surface 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsurfaceChanged();
        /// <summary>
        /// 当 logo 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlogoChanging(String value);
        /// <summary>
        /// 当 logo 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlogoChanged();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 bannel 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannelChanging(String value);
        /// <summary>
        /// 当 bannel 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannelChanged();
        /// <summary>
        /// 当 desimage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndesimageChanging(String value);
        /// <summary>
        /// 当 desimage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndesimageChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 keywords 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnkeywordsChanging(String value);
        /// <summary>
        /// 当 keywords 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnkeywordsChanged();
        /// <summary>
        /// 当 template 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntemplateChanging(String value);
        /// <summary>
        /// 当 template 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntemplateChanged();
        /// <summary>
        /// 当 hits 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhitsChanging(Int32? value);
        /// <summary>
        /// 当 hits 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhitsChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 createmid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatemidChanging(Int32? value);
        /// <summary>
        /// 当 createmid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatemidChanged();
        /// <summary>
        /// 当 lastedid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedidChanging(Int32? value);
        /// <summary>
        /// 当 lastedid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedidChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        /// <summary>
        /// 当 auditstatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauditstatusChanging(Int32 value);
        /// <summary>
        /// 当 auditstatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauditstatusChanged();
        /// <summary>
        /// 当 linestatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinestatusChanging(Int32 value);
        /// <summary>
        /// 当 linestatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinestatusChanged();
        /// <summary>
        /// 当 dbook 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndbookChanging(String value);
        /// <summary>
        /// 当 dbook 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndbookChanged();
        /// <summary>
        /// 当 Createtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnCreatetimeChanging(DateTime? value);
        /// <summary>
        /// 当 Createtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnCreatetimeChanged();
        
        /// <summary>
        /// 初始化 Mdealer 实体类的新实例。
        /// </summary>
        public Mdealer() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 用户表ID
        /// </summary>
        [Column(Storage="_mid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("用户表ID")]
        [Description("用户表ID")]
        public Int32 mid {
            get {
                return this._mid;
            }
            set {
                this.OnmidChanging(value);
                this.SendPropertyChanging("mid", value);
                this._mid = value;
                this.SendPropertyChanged("mid", value);
                this.OnmidChanged();
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(80) NOT NULL", CanBeNull=false)]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 索引
        /// </summary>
        [Column(Storage="_letter", DbType="varchar(20)")]
        [DisplayName("索引")]
        [Description("索引")]
        public String letter {
            get {
                return this._letter;
            }
            set {
                if ((this._letter != value)) {
                    this.OnletterChanging(value);
                    this.SendPropertyChanging("letter", value);
                    this._letter = value;
                    this.SendPropertyChanged("letter", value);
                    this.OnletterChanged();
                }
            }
        }
        /// <summary>
        /// 组ID
        /// </summary>
        [Column(Storage="_groupid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("组ID")]
        [Description("组ID")]
        public Int32 groupid {
            get {
                return this._groupid;
            }
            set {
                this.OngroupidChanging(value);
                this.SendPropertyChanging("groupid", value);
                this._groupid = value;
                this.SendPropertyChanged("groupid", value);
                this.OngroupidChanged();
            }
        }
        /// <summary>
        /// 属性
        /// </summary>
        [Column(Storage="_attribute", DbType="varchar(100)")]
        [DisplayName("属性")]
        [Description("属性")]
        public String attribute {
            get {
                return this._attribute;
            }
            set {
                if ((this._attribute != value)) {
                    this.OnattributeChanging(value);
                    this.SendPropertyChanging("attribute", value);
                    this._attribute = value;
                    this.SendPropertyChanged("attribute", value);
                    this.OnattributeChanged();
                }
            }
        }
        /// <summary>
        /// 行业
        /// </summary>
        [Column(Storage="_industry", DbType="varchar(50)")]
        [DisplayName("行业")]
        [Description("行业")]
        public String industry {
            get {
                return this._industry;
            }
            set {
                if ((this._industry != value)) {
                    this.OnindustryChanging(value);
                    this.SendPropertyChanging("industry", value);
                    this._industry = value;
                    this.SendPropertyChanged("industry", value);
                    this.OnindustryChanged();
                }
            }
        }
        /// <summary>
        /// 产品分类
        /// </summary>
        [Column(Storage="_productcategory", DbType="varchar(50)")]
        [DisplayName("产品分类")]
        [Description("产品分类")]
        public String productcategory {
            get {
                return this._productcategory;
            }
            set {
                if ((this._productcategory != value)) {
                    this.OnproductcategoryChanging(value);
                    this.SendPropertyChanging("productcategory", value);
                    this._productcategory = value;
                    this.SendPropertyChanged("productcategory", value);
                    this.OnproductcategoryChanged();
                }
            }
        }
        /// <summary>
        /// 是否vip
        /// </summary>
        [Column(Storage="_vip", DbType="int")]
        [DisplayName("是否vip")]
        [Description("是否vip")]
        public Int32? vip {
            get {
                return this._vip;
            }
            set {
                if ((this._vip != value)) {
                    this.OnvipChanging(value);
                    this.SendPropertyChanging("vip", value);
                    this._vip = value;
                    this.SendPropertyChanged("vip", value);
                    this.OnvipChanged();
                }
            }
        }
        /// <summary>
        /// 地区代码
        /// </summary>
        [Column(Storage="_areacode", DbType="varchar(10)")]
        [DisplayName("地区代码")]
        [Description("地区代码")]
        public String areacode {
            get {
                return this._areacode;
            }
            set {
                if ((this._areacode != value)) {
                    this.OnareacodeChanging(value);
                    this.SendPropertyChanging("areacode", value);
                    this._areacode = value;
                    this.SendPropertyChanged("areacode", value);
                    this.OnareacodeChanged();
                }
            }
        }
        /// <summary>
        /// 地址
        /// </summary>
        [Column(Storage="_address", DbType="nvarchar(60)")]
        [DisplayName("地址")]
        [Description("地址")]
        public String address {
            get {
                return this._address;
            }
            set {
                if ((this._address != value)) {
                    this.OnaddressChanging(value);
                    this.SendPropertyChanging("address", value);
                    this._address = value;
                    this.SendPropertyChanged("address", value);
                    this.OnaddressChanged();
                }
            }
        }
        /// <summary>
        /// 地图API值
        /// </summary>
        [Column(Storage="_mapapi", DbType="nvarchar(50)")]
        [DisplayName("地图API值")]
        [Description("地图API值")]
        public String mapapi {
            get {
                return this._mapapi;
            }
            set {
                if ((this._mapapi != value)) {
                    this.OnmapapiChanging(value);
                    this.SendPropertyChanging("mapapi", value);
                    this._mapapi = value;
                    this.SendPropertyChanged("mapapi", value);
                    this.OnmapapiChanged();
                }
            }
        }
        /// <summary>
        /// 外观图
        /// </summary>
        [Column(Storage="_staffsize", DbType="int")]
        [DisplayName("外观图")]
        [Description("外观图")]
        public Int32? staffsize {
            get {
                return this._staffsize;
            }
            set {
                if ((this._staffsize != value)) {
                    this.OnstaffsizeChanging(value);
                    this.SendPropertyChanging("staffsize", value);
                    this._staffsize = value;
                    this.SendPropertyChanged("staffsize", value);
                    this.OnstaffsizeChanged();
                }
            }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        [Column(Storage="_regyear", DbType="varchar(7)")]
        [DisplayName("注册时间")]
        [Description("注册时间")]
        public String regyear {
            get {
                return this._regyear;
            }
            set {
                if ((this._regyear != value)) {
                    this.OnregyearChanging(value);
                    this.SendPropertyChanging("regyear", value);
                    this._regyear = value;
                    this.SendPropertyChanged("regyear", value);
                    this.OnregyearChanged();
                }
            }
        }
        /// <summary>
        /// 注册城市
        /// </summary>
        [Column(Storage="_regcity", DbType="varchar(10)")]
        [DisplayName("注册城市")]
        [Description("注册城市")]
        public String regcity {
            get {
                return this._regcity;
            }
            set {
                if ((this._regcity != value)) {
                    this.OnregcityChanging(value);
                    this.SendPropertyChanging("regcity", value);
                    this._regcity = value;
                    this.SendPropertyChanged("regcity", value);
                    this.OnregcityChanged();
                }
            }
        }
        /// <summary>
        /// 销售信息
        /// </summary>
        [Column(Storage="_buy", DbType="nvarchar(300)")]
        [DisplayName("销售信息")]
        [Description("销售信息")]
        public String buy {
            get {
                return this._buy;
            }
            set {
                if ((this._buy != value)) {
                    this.OnbuyChanging(value);
                    this.SendPropertyChanging("buy", value);
                    this._buy = value;
                    this.SendPropertyChanged("buy", value);
                    this.OnbuyChanged();
                }
            }
        }
        /// <summary>
        /// 采购信息
        /// </summary>
        [Column(Storage="_sell", DbType="nvarchar(300)")]
        [DisplayName("采购信息")]
        [Description("采购信息")]
        public String sell {
            get {
                return this._sell;
            }
            set {
                if ((this._sell != value)) {
                    this.OnsellChanging(value);
                    this.SendPropertyChanging("sell", value);
                    this._sell = value;
                    this.SendPropertyChanged("sell", value);
                    this.OnsellChanged();
                }
            }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        [Column(Storage="_linkman", DbType="nvarchar(20)")]
        [DisplayName("联系人")]
        [Description("联系人")]
        public String linkman {
            get {
                return this._linkman;
            }
            set {
                if ((this._linkman != value)) {
                    this.OnlinkmanChanging(value);
                    this.SendPropertyChanging("linkman", value);
                    this._linkman = value;
                    this.SendPropertyChanged("linkman", value);
                    this.OnlinkmanChanged();
                }
            }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Column(Storage="_phone", DbType="varchar(20)")]
        [DisplayName("联系电话")]
        [Description("联系电话")]
        public String phone {
            get {
                return this._phone;
            }
            set {
                if ((this._phone != value)) {
                    this.OnphoneChanging(value);
                    this.SendPropertyChanging("phone", value);
                    this._phone = value;
                    this.SendPropertyChanged("phone", value);
                    this.OnphoneChanged();
                }
            }
        }
        /// <summary>
        /// 联系手机
        /// </summary>
        [Column(Storage="_mphone", DbType="varchar(20)")]
        [DisplayName("联系手机")]
        [Description("联系手机")]
        public String mphone {
            get {
                return this._mphone;
            }
            set {
                if ((this._mphone != value)) {
                    this.OnmphoneChanging(value);
                    this.SendPropertyChanging("mphone", value);
                    this._mphone = value;
                    this.SendPropertyChanged("mphone", value);
                    this.OnmphoneChanged();
                }
            }
        }
        /// <summary>
        /// 传真
        /// </summary>
        [Column(Storage="_fax", DbType="varchar(20)")]
        [DisplayName("传真")]
        [Description("传真")]
        public String fax {
            get {
                return this._fax;
            }
            set {
                if ((this._fax != value)) {
                    this.OnfaxChanging(value);
                    this.SendPropertyChanging("fax", value);
                    this._fax = value;
                    this.SendPropertyChanged("fax", value);
                    this.OnfaxChanged();
                }
            }
        }
        /// <summary>
        /// 邮件
        /// </summary>
        [Column(Storage="_email", DbType="varchar(50)")]
        [DisplayName("邮件")]
        [Description("邮件")]
        public String email {
            get {
                return this._email;
            }
            set {
                if ((this._email != value)) {
                    this.OnemailChanging(value);
                    this.SendPropertyChanging("email", value);
                    this._email = value;
                    this.SendPropertyChanged("email", value);
                    this.OnemailChanged();
                }
            }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        [Column(Storage="_postcode", DbType="varchar(15)")]
        [DisplayName("邮编")]
        [Description("邮编")]
        public String postcode {
            get {
                return this._postcode;
            }
            set {
                if ((this._postcode != value)) {
                    this.OnpostcodeChanging(value);
                    this.SendPropertyChanging("postcode", value);
                    this._postcode = value;
                    this.SendPropertyChanged("postcode", value);
                    this.OnpostcodeChanged();
                }
            }
        }
        /// <summary>
        /// 主页
        /// </summary>
        [Column(Storage="_homepage", DbType="varchar(50)")]
        [DisplayName("主页")]
        [Description("主页")]
        public String homepage {
            get {
                return this._homepage;
            }
            set {
                if ((this._homepage != value)) {
                    this.OnhomepageChanging(value);
                    this.SendPropertyChanging("homepage", value);
                    this._homepage = value;
                    this.SendPropertyChanged("homepage", value);
                    this.OnhomepageChanged();
                }
            }
        }
        /// <summary>
        /// 域名
        /// </summary>
        [Column(Storage="_domain", DbType="varchar(50)")]
        [DisplayName("域名")]
        [Description("域名")]
        public String domain {
            get {
                return this._domain;
            }
            set {
                if ((this._domain != value)) {
                    this.OndomainChanging(value);
                    this.SendPropertyChanging("domain", value);
                    this._domain = value;
                    this.SendPropertyChanged("domain", value);
                    this.OndomainChanged();
                }
            }
        }
        /// <summary>
        /// 域名IP
        /// </summary>
        [Column(Storage="_domainip", DbType="varchar(50)")]
        [DisplayName("域名IP")]
        [Description("域名IP")]
        public String domainip {
            get {
                return this._domainip;
            }
            set {
                if ((this._domainip != value)) {
                    this.OndomainipChanging(value);
                    this.SendPropertyChanging("domainip", value);
                    this._domainip = value;
                    this.SendPropertyChanged("domainip", value);
                    this.OndomainipChanged();
                }
            }
        }
        /// <summary>
        /// 备案号
        /// </summary>
        [Column(Storage="_icp", DbType="nvarchar(50)")]
        [DisplayName("备案号")]
        [Description("备案号")]
        public String icp {
            get {
                return this._icp;
            }
            set {
                if ((this._icp != value)) {
                    this.OnicpChanging(value);
                    this.SendPropertyChanging("icp", value);
                    this._icp = value;
                    this.SendPropertyChanged("icp", value);
                    this.OnicpChanged();
                }
            }
        }
        /// <summary>
        /// 外观图
        /// </summary>
        [Column(Storage="_surface", DbType="varchar(200)")]
        [DisplayName("外观图")]
        [Description("外观图")]
        public String surface {
            get {
                return this._surface;
            }
            set {
                if ((this._surface != value)) {
                    this.OnsurfaceChanging(value);
                    this.SendPropertyChanging("surface", value);
                    this._surface = value;
                    this.SendPropertyChanged("surface", value);
                    this.OnsurfaceChanged();
                }
            }
        }
        /// <summary>
        /// logo
        /// </summary>
        [Column(Storage="_logo", DbType="varchar(40)")]
        [DisplayName("logo")]
        [Description("logo")]
        public String logo {
            get {
                return this._logo;
            }
            set {
                if ((this._logo != value)) {
                    this.OnlogoChanging(value);
                    this.SendPropertyChanging("logo", value);
                    this._logo = value;
                    this.SendPropertyChanged("logo", value);
                    this.OnlogoChanged();
                }
            }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(40)")]
        [DisplayName("缩略图")]
        [Description("缩略图")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        /// 幻灯图
        /// </summary>
        [Column(Storage="_bannel", DbType="varchar(300)")]
        [DisplayName("幻灯图")]
        [Description("幻灯图")]
        public String bannel {
            get {
                return this._bannel;
            }
            set {
                if ((this._bannel != value)) {
                    this.OnbannelChanging(value);
                    this.SendPropertyChanging("bannel", value);
                    this._bannel = value;
                    this.SendPropertyChanged("bannel", value);
                    this.OnbannelChanged();
                }
            }
        }
        /// <summary>
        /// 描述图
        /// </summary>
        [Column(Storage="_desimage", DbType="varchar(400)")]
        [DisplayName("描述图")]
        [Description("描述图")]
        public String desimage {
            get {
                return this._desimage;
            }
            set {
                if ((this._desimage != value)) {
                    this.OndesimageChanging(value);
                    this.SendPropertyChanging("desimage", value);
                    this._desimage = value;
                    this.SendPropertyChanged("desimage", value);
                    this.OndesimageChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="ntext")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        [Column(Storage="_keywords", DbType="nvarchar(200)")]
        [DisplayName("关键字")]
        [Description("关键字")]
        public String keywords {
            get {
                return this._keywords;
            }
            set {
                if ((this._keywords != value)) {
                    this.OnkeywordsChanging(value);
                    this.SendPropertyChanging("keywords", value);
                    this._keywords = value;
                    this.SendPropertyChanged("keywords", value);
                    this.OnkeywordsChanged();
                }
            }
        }
        /// <summary>
        /// 模版ID
        /// </summary>
        [Column(Storage="_template", DbType="varchar(50)")]
        [DisplayName("模版ID")]
        [Description("模版ID")]
        public String template {
            get {
                return this._template;
            }
            set {
                if ((this._template != value)) {
                    this.OntemplateChanging(value);
                    this.SendPropertyChanging("template", value);
                    this._template = value;
                    this.SendPropertyChanged("template", value);
                    this.OntemplateChanged();
                }
            }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        [Column(Storage="_hits", DbType="int")]
        [DisplayName("点击量")]
        [Description("点击量")]
        public Int32? hits {
            get {
                return this._hits;
            }
            set {
                if ((this._hits != value)) {
                    this.OnhitsChanging(value);
                    this.SendPropertyChanging("hits", value);
                    this._hits = value;
                    this.SendPropertyChanged("hits", value);
                    this.OnhitsChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column(Storage="_createmid", DbType="int")]
        [DisplayName("创建人")]
        [Description("创建人")]
        public Int32? createmid {
            get {
                return this._createmid;
            }
            set {
                if ((this._createmid != value)) {
                    this.OncreatemidChanging(value);
                    this.SendPropertyChanging("createmid", value);
                    this._createmid = value;
                    this.SendPropertyChanged("createmid", value);
                    this.OncreatemidChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改人
        /// </summary>
        [Column(Storage="_lastedid", DbType="int")]
        [DisplayName("最后修改人")]
        [Description("最后修改人")]
        public Int32? lastedid {
            get {
                return this._lastedid;
            }
            set {
                if ((this._lastedid != value)) {
                    this.OnlastedidChanging(value);
                    this.SendPropertyChanging("lastedid", value);
                    this._lastedid = value;
                    this.SendPropertyChanged("lastedid", value);
                    this.OnlastedidChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最后修改时间")]
        [Description("最后修改时间")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        [Column(Storage="_auditstatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("审核状态")]
        [Description("审核状态")]
        public Int32 auditstatus {
            get {
                return this._auditstatus;
            }
            set {
                this.OnauditstatusChanging(value);
                this.SendPropertyChanging("auditstatus", value);
                this._auditstatus = value;
                this.SendPropertyChanged("auditstatus", value);
                this.OnauditstatusChanged();
            }
        }
        /// <summary>
        /// 上下线状态
        /// </summary>
        [Column(Storage="_linestatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("上下线状态")]
        [Description("上下线状态")]
        public Int32 linestatus {
            get {
                return this._linestatus;
            }
            set {
                this.OnlinestatusChanging(value);
                this.SendPropertyChanging("linestatus", value);
                this._linestatus = value;
                this.SendPropertyChanged("linestatus", value);
                this.OnlinestatusChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_dbook", DbType="nvarchar(100)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String dbook {
            get {
                return this._dbook;
            }
            set {
                if ((this._dbook != value)) {
                    this.OndbookChanging(value);
                    this.SendPropertyChanging("dbook", value);
                    this._dbook = value;
                    this.SendPropertyChanged("dbook", value);
                    this.OndbookChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_Createtime", DbType="datetime")]
        [DisplayName(" ")]
        [Description(" ")]
        public DateTime? Createtime {
            get {
                return this._Createtime;
            }
            set {
                if ((this._Createtime != value)) {
                    this.OnCreatetimeChanging(value);
                    this.SendPropertyChanging("Createtime", value);
                    this._Createtime = value;
                    this.SendPropertyChanged("Createtime", value);
                    this.OnCreatetimeChanged();
                }
            }
        }
    }
    /// <summary>
    /// 经销商组表
    /// </summary>
    [Table(Name="t_dealergroup")]
    [Serializable()]
    [DisplayName("经销商组表")]
    [Description("经销商组表")]
    public partial class Mdealergroup : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 组名称
        /// </summary>
        String _title;
        /// <summary>
        /// 组名称颜色
        /// </summary>
        String _color;
        /// <summary>
        /// 组图标
        /// </summary>
        String _avatar;
        /// <summary>
        /// 积分达到
        /// </summary>
        Decimal? _integral;
        /// <summary>
        /// 金钱达到
        /// </summary>
        Decimal? _money;
        /// <summary>
        /// 广告数量限制
        /// </summary>
        Int32? _adcount;
        /// <summary>
        /// 店铺数量限制
        /// </summary>
        Int32? _shopcount;
        /// <summary>
        /// 品牌数量限制
        /// </summary>
        Int32? _brandcount;
        /// <summary>
        /// 促销信息数量限制
        /// </summary>
        Int32? _promotioncount;
        /// <summary>
        /// 推荐数量限制
        /// </summary>
        Int32? _adrecommend;
        /// <summary>
        /// 推荐店铺数量限制
        /// </summary>
        Int32? _shoprecommend;
        /// <summary>
        ///  
        /// </summary>
        Int32? _brandrecommend;
        /// <summary>
        ///  
        /// </summary>
        Int32? _promotionrecommend;
        /// <summary>
        ///  
        /// </summary>
        String _permissions;
        /// <summary>
        /// 级别
        /// </summary>
        Int32? _lev;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 color 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncolorChanging(String value);
        /// <summary>
        /// 当 color 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncolorChanged();
        /// <summary>
        /// 当 avatar 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnavatarChanging(String value);
        /// <summary>
        /// 当 avatar 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnavatarChanged();
        /// <summary>
        /// 当 integral 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnintegralChanging(Decimal? value);
        /// <summary>
        /// 当 integral 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnintegralChanged();
        /// <summary>
        /// 当 money 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmoneyChanging(Decimal? value);
        /// <summary>
        /// 当 money 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmoneyChanged();
        /// <summary>
        /// 当 adcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadcountChanging(Int32? value);
        /// <summary>
        /// 当 adcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadcountChanged();
        /// <summary>
        /// 当 shopcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshopcountChanging(Int32? value);
        /// <summary>
        /// 当 shopcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshopcountChanged();
        /// <summary>
        /// 当 brandcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandcountChanging(Int32? value);
        /// <summary>
        /// 当 brandcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandcountChanged();
        /// <summary>
        /// 当 promotioncount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromotioncountChanging(Int32? value);
        /// <summary>
        /// 当 promotioncount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromotioncountChanged();
        /// <summary>
        /// 当 adrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadrecommendChanging(Int32? value);
        /// <summary>
        /// 当 adrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadrecommendChanged();
        /// <summary>
        /// 当 shoprecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshoprecommendChanging(Int32? value);
        /// <summary>
        /// 当 shoprecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshoprecommendChanged();
        /// <summary>
        /// 当 brandrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandrecommendChanging(Int32? value);
        /// <summary>
        /// 当 brandrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandrecommendChanged();
        /// <summary>
        /// 当 promotionrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromotionrecommendChanging(Int32? value);
        /// <summary>
        /// 当 promotionrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromotionrecommendChanged();
        /// <summary>
        /// 当 permissions 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpermissionsChanging(String value);
        /// <summary>
        /// 当 permissions 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpermissionsChanged();
        /// <summary>
        /// 当 lev 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlevChanging(Int32? value);
        /// <summary>
        /// 当 lev 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlevChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Mdealergroup 实体类的新实例。
        /// </summary>
        public Mdealergroup() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 组名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(30) NOT NULL", CanBeNull=false)]
        [DisplayName("组名称")]
        [Description("组名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 组名称颜色
        /// </summary>
        [Column(Storage="_color", DbType="char(7)")]
        [DisplayName("组名称颜色")]
        [Description("组名称颜色")]
        public String color {
            get {
                return this._color;
            }
            set {
                if ((this._color != value)) {
                    this.OncolorChanging(value);
                    this.SendPropertyChanging("color", value);
                    this._color = value;
                    this.SendPropertyChanged("color", value);
                    this.OncolorChanged();
                }
            }
        }
        /// <summary>
        /// 组图标
        /// </summary>
        [Column(Storage="_avatar", DbType="varchar(40)")]
        [DisplayName("组图标")]
        [Description("组图标")]
        public String avatar {
            get {
                return this._avatar;
            }
            set {
                if ((this._avatar != value)) {
                    this.OnavatarChanging(value);
                    this.SendPropertyChanging("avatar", value);
                    this._avatar = value;
                    this.SendPropertyChanged("avatar", value);
                    this.OnavatarChanged();
                }
            }
        }
        /// <summary>
        /// 积分达到
        /// </summary>
        [Column(Storage="_integral", DbType="decimal")]
        [DisplayName("积分达到")]
        [Description("积分达到")]
        public Decimal? integral {
            get {
                return this._integral;
            }
            set {
                if ((this._integral != value)) {
                    this.OnintegralChanging(value);
                    this.SendPropertyChanging("integral", value);
                    this._integral = value;
                    this.SendPropertyChanged("integral", value);
                    this.OnintegralChanged();
                }
            }
        }
        /// <summary>
        /// 金钱达到
        /// </summary>
        [Column(Storage="_money", DbType="decimal")]
        [DisplayName("金钱达到")]
        [Description("金钱达到")]
        public Decimal? money {
            get {
                return this._money;
            }
            set {
                if ((this._money != value)) {
                    this.OnmoneyChanging(value);
                    this.SendPropertyChanging("money", value);
                    this._money = value;
                    this.SendPropertyChanged("money", value);
                    this.OnmoneyChanged();
                }
            }
        }
        /// <summary>
        /// 广告数量限制
        /// </summary>
        [Column(Storage="_adcount", DbType="int")]
        [DisplayName("广告数量限制")]
        [Description("广告数量限制")]
        public Int32? adcount {
            get {
                return this._adcount;
            }
            set {
                if ((this._adcount != value)) {
                    this.OnadcountChanging(value);
                    this.SendPropertyChanging("adcount", value);
                    this._adcount = value;
                    this.SendPropertyChanged("adcount", value);
                    this.OnadcountChanged();
                }
            }
        }
        /// <summary>
        /// 店铺数量限制
        /// </summary>
        [Column(Storage="_shopcount", DbType="int")]
        [DisplayName("店铺数量限制")]
        [Description("店铺数量限制")]
        public Int32? shopcount {
            get {
                return this._shopcount;
            }
            set {
                if ((this._shopcount != value)) {
                    this.OnshopcountChanging(value);
                    this.SendPropertyChanging("shopcount", value);
                    this._shopcount = value;
                    this.SendPropertyChanged("shopcount", value);
                    this.OnshopcountChanged();
                }
            }
        }
        /// <summary>
        /// 品牌数量限制
        /// </summary>
        [Column(Storage="_brandcount", DbType="int")]
        [DisplayName("品牌数量限制")]
        [Description("品牌数量限制")]
        public Int32? brandcount {
            get {
                return this._brandcount;
            }
            set {
                if ((this._brandcount != value)) {
                    this.OnbrandcountChanging(value);
                    this.SendPropertyChanging("brandcount", value);
                    this._brandcount = value;
                    this.SendPropertyChanged("brandcount", value);
                    this.OnbrandcountChanged();
                }
            }
        }
        /// <summary>
        /// 促销信息数量限制
        /// </summary>
        [Column(Storage="_promotioncount", DbType="int")]
        [DisplayName("促销信息数量限制")]
        [Description("促销信息数量限制")]
        public Int32? promotioncount {
            get {
                return this._promotioncount;
            }
            set {
                if ((this._promotioncount != value)) {
                    this.OnpromotioncountChanging(value);
                    this.SendPropertyChanging("promotioncount", value);
                    this._promotioncount = value;
                    this.SendPropertyChanged("promotioncount", value);
                    this.OnpromotioncountChanged();
                }
            }
        }
        /// <summary>
        /// 推荐数量限制
        /// </summary>
        [Column(Storage="_adrecommend", DbType="int")]
        [DisplayName("推荐数量限制")]
        [Description("推荐数量限制")]
        public Int32? adrecommend {
            get {
                return this._adrecommend;
            }
            set {
                if ((this._adrecommend != value)) {
                    this.OnadrecommendChanging(value);
                    this.SendPropertyChanging("adrecommend", value);
                    this._adrecommend = value;
                    this.SendPropertyChanged("adrecommend", value);
                    this.OnadrecommendChanged();
                }
            }
        }
        /// <summary>
        /// 推荐店铺数量限制
        /// </summary>
        [Column(Storage="_shoprecommend", DbType="int")]
        [DisplayName("推荐店铺数量限制")]
        [Description("推荐店铺数量限制")]
        public Int32? shoprecommend {
            get {
                return this._shoprecommend;
            }
            set {
                if ((this._shoprecommend != value)) {
                    this.OnshoprecommendChanging(value);
                    this.SendPropertyChanging("shoprecommend", value);
                    this._shoprecommend = value;
                    this.SendPropertyChanged("shoprecommend", value);
                    this.OnshoprecommendChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_brandrecommend", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? brandrecommend {
            get {
                return this._brandrecommend;
            }
            set {
                if ((this._brandrecommend != value)) {
                    this.OnbrandrecommendChanging(value);
                    this.SendPropertyChanging("brandrecommend", value);
                    this._brandrecommend = value;
                    this.SendPropertyChanged("brandrecommend", value);
                    this.OnbrandrecommendChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_promotionrecommend", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? promotionrecommend {
            get {
                return this._promotionrecommend;
            }
            set {
                if ((this._promotionrecommend != value)) {
                    this.OnpromotionrecommendChanging(value);
                    this.SendPropertyChanging("promotionrecommend", value);
                    this._promotionrecommend = value;
                    this.SendPropertyChanged("promotionrecommend", value);
                    this.OnpromotionrecommendChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_permissions", DbType="ntext")]
        [DisplayName(" ")]
        [Description(" ")]
        public String permissions {
            get {
                return this._permissions;
            }
            set {
                if ((this._permissions != value)) {
                    this.OnpermissionsChanging(value);
                    this.SendPropertyChanging("permissions", value);
                    this._permissions = value;
                    this.SendPropertyChanged("permissions", value);
                    this.OnpermissionsChanged();
                }
            }
        }
        /// <summary>
        /// 级别
        /// </summary>
        [Column(Storage="_lev", DbType="int")]
        [DisplayName("级别")]
        [Description("级别")]
        public Int32? lev {
            get {
                return this._lev;
            }
            set {
                if ((this._lev != value)) {
                    this.OnlevChanging(value);
                    this.SendPropertyChanging("lev", value);
                    this._lev = value;
                    this.SendPropertyChanged("lev", value);
                    this.OnlevChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(300)")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    ///  
    /// </summary>
    [Table(Name="t_grouporder")]
    [Serializable()]
    [DisplayName(" ")]
    [Description(" ")]
    public partial class Mgrouporder : DALModelBase {
        /// <summary>
        ///  
        /// </summary>
        Int32 _id;
        /// <summary>
        ///  
        /// </summary>
        String _grouporderno;
        /// <summary>
        ///  
        /// </summary>
        Int32? _mid;
        /// <summary>
        ///  
        /// </summary>
        Int32? _fjmid;
        /// <summary>
        ///  
        /// </summary>
        String _name;
        /// <summary>
        ///  
        /// </summary>
        String _email;
        /// <summary>
        ///  
        /// </summary>
        String _phone;
        /// <summary>
        ///  
        /// </summary>
        String _fax;
        /// <summary>
        ///  
        /// </summary>
        String _mphone;
        /// <summary>
        ///  
        /// </summary>
        String _zip;
        /// <summary>
        ///  
        /// </summary>
        String _areacode;
        /// <summary>
        ///  
        /// </summary>
        String _address;
        /// <summary>
        ///  
        /// </summary>
        String _descript;
        /// <summary>
        ///  
        /// </summary>
        Decimal? _totlepromoney;
        /// <summary>
        ///  
        /// </summary>
        Decimal? _totalmoney;
        /// <summary>
        ///  
        /// </summary>
        Decimal? _invoicemoney;
        /// <summary>
        ///  
        /// </summary>
        Decimal? _installationmeney;
        /// <summary>
        ///  
        /// </summary>
        Int32? _status;
        /// <summary>
        ///  
        /// </summary>
        DateTime? _createtime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 grouporderno 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OngroupordernoChanging(String value);
        /// <summary>
        /// 当 grouporderno 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OngroupordernoChanged();
        /// <summary>
        /// 当 mid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmidChanging(Int32? value);
        /// <summary>
        /// 当 mid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmidChanged();
        /// <summary>
        /// 当 fjmid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnfjmidChanging(Int32? value);
        /// <summary>
        /// 当 fjmid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnfjmidChanged();
        /// <summary>
        /// 当 name 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnnameChanging(String value);
        /// <summary>
        /// 当 name 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnnameChanged();
        /// <summary>
        /// 当 email 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnemailChanging(String value);
        /// <summary>
        /// 当 email 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnemailChanged();
        /// <summary>
        /// 当 phone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnphoneChanging(String value);
        /// <summary>
        /// 当 phone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnphoneChanged();
        /// <summary>
        /// 当 fax 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnfaxChanging(String value);
        /// <summary>
        /// 当 fax 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnfaxChanged();
        /// <summary>
        /// 当 mphone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmphoneChanging(String value);
        /// <summary>
        /// 当 mphone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmphoneChanged();
        /// <summary>
        /// 当 zip 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnzipChanging(String value);
        /// <summary>
        /// 当 zip 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnzipChanged();
        /// <summary>
        /// 当 areacode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnareacodeChanging(String value);
        /// <summary>
        /// 当 areacode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnareacodeChanged();
        /// <summary>
        /// 当 address 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaddressChanging(String value);
        /// <summary>
        /// 当 address 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaddressChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 totlepromoney 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntotlepromoneyChanging(Decimal? value);
        /// <summary>
        /// 当 totlepromoney 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntotlepromoneyChanged();
        /// <summary>
        /// 当 totalmoney 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntotalmoneyChanging(Decimal? value);
        /// <summary>
        /// 当 totalmoney 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntotalmoneyChanged();
        /// <summary>
        /// 当 invoicemoney 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OninvoicemoneyChanging(Decimal? value);
        /// <summary>
        /// 当 invoicemoney 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OninvoicemoneyChanged();
        /// <summary>
        /// 当 installationmeney 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OninstallationmeneyChanging(Decimal? value);
        /// <summary>
        /// 当 installationmeney 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OninstallationmeneyChanged();
        /// <summary>
        /// 当 status 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstatusChanging(Int32? value);
        /// <summary>
        /// 当 status 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstatusChanged();
        /// <summary>
        /// 当 createtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatetimeChanging(DateTime? value);
        /// <summary>
        /// 当 createtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatetimeChanged();
        
        /// <summary>
        /// 初始化 Mgrouporder 实体类的新实例。
        /// </summary>
        public Mgrouporder() {
            this.OnCreated();
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_grouporderno", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String grouporderno {
            get {
                return this._grouporderno;
            }
            set {
                if ((this._grouporderno != value)) {
                    this.OngroupordernoChanging(value);
                    this.SendPropertyChanging("grouporderno", value);
                    this._grouporderno = value;
                    this.SendPropertyChanged("grouporderno", value);
                    this.OngroupordernoChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_mid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? mid {
            get {
                return this._mid;
            }
            set {
                if ((this._mid != value)) {
                    this.OnmidChanging(value);
                    this.SendPropertyChanging("mid", value);
                    this._mid = value;
                    this.SendPropertyChanged("mid", value);
                    this.OnmidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_fjmid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? fjmid {
            get {
                return this._fjmid;
            }
            set {
                if ((this._fjmid != value)) {
                    this.OnfjmidChanging(value);
                    this.SendPropertyChanging("fjmid", value);
                    this._fjmid = value;
                    this.SendPropertyChanged("fjmid", value);
                    this.OnfjmidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_name", DbType="nvarchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String name {
            get {
                return this._name;
            }
            set {
                if ((this._name != value)) {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging("name", value);
                    this._name = value;
                    this.SendPropertyChanged("name", value);
                    this.OnnameChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_email", DbType="nvarchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String email {
            get {
                return this._email;
            }
            set {
                if ((this._email != value)) {
                    this.OnemailChanging(value);
                    this.SendPropertyChanging("email", value);
                    this._email = value;
                    this.SendPropertyChanged("email", value);
                    this.OnemailChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_phone", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String phone {
            get {
                return this._phone;
            }
            set {
                if ((this._phone != value)) {
                    this.OnphoneChanging(value);
                    this.SendPropertyChanging("phone", value);
                    this._phone = value;
                    this.SendPropertyChanged("phone", value);
                    this.OnphoneChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_fax", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String fax {
            get {
                return this._fax;
            }
            set {
                if ((this._fax != value)) {
                    this.OnfaxChanging(value);
                    this.SendPropertyChanging("fax", value);
                    this._fax = value;
                    this.SendPropertyChanged("fax", value);
                    this.OnfaxChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_mphone", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String mphone {
            get {
                return this._mphone;
            }
            set {
                if ((this._mphone != value)) {
                    this.OnmphoneChanging(value);
                    this.SendPropertyChanging("mphone", value);
                    this._mphone = value;
                    this.SendPropertyChanged("mphone", value);
                    this.OnmphoneChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_zip", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String zip {
            get {
                return this._zip;
            }
            set {
                if ((this._zip != value)) {
                    this.OnzipChanging(value);
                    this.SendPropertyChanging("zip", value);
                    this._zip = value;
                    this.SendPropertyChanged("zip", value);
                    this.OnzipChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_areacode", DbType="varchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String areacode {
            get {
                return this._areacode;
            }
            set {
                if ((this._areacode != value)) {
                    this.OnareacodeChanging(value);
                    this.SendPropertyChanging("areacode", value);
                    this._areacode = value;
                    this.SendPropertyChanged("areacode", value);
                    this.OnareacodeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_address", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String address {
            get {
                return this._address;
            }
            set {
                if ((this._address != value)) {
                    this.OnaddressChanging(value);
                    this.SendPropertyChanging("address", value);
                    this._address = value;
                    this.SendPropertyChanged("address", value);
                    this.OnaddressChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(600)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_totlepromoney", DbType="decimal")]
        [DisplayName(" ")]
        [Description(" ")]
        public Decimal? totlepromoney {
            get {
                return this._totlepromoney;
            }
            set {
                if ((this._totlepromoney != value)) {
                    this.OntotlepromoneyChanging(value);
                    this.SendPropertyChanging("totlepromoney", value);
                    this._totlepromoney = value;
                    this.SendPropertyChanged("totlepromoney", value);
                    this.OntotlepromoneyChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_totalmoney", DbType="decimal")]
        [DisplayName(" ")]
        [Description(" ")]
        public Decimal? totalmoney {
            get {
                return this._totalmoney;
            }
            set {
                if ((this._totalmoney != value)) {
                    this.OntotalmoneyChanging(value);
                    this.SendPropertyChanging("totalmoney", value);
                    this._totalmoney = value;
                    this.SendPropertyChanged("totalmoney", value);
                    this.OntotalmoneyChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_invoicemoney", DbType="decimal")]
        [DisplayName(" ")]
        [Description(" ")]
        public Decimal? invoicemoney {
            get {
                return this._invoicemoney;
            }
            set {
                if ((this._invoicemoney != value)) {
                    this.OninvoicemoneyChanging(value);
                    this.SendPropertyChanging("invoicemoney", value);
                    this._invoicemoney = value;
                    this.SendPropertyChanged("invoicemoney", value);
                    this.OninvoicemoneyChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_installationmeney", DbType="decimal")]
        [DisplayName(" ")]
        [Description(" ")]
        public Decimal? installationmeney {
            get {
                return this._installationmeney;
            }
            set {
                if ((this._installationmeney != value)) {
                    this.OninstallationmeneyChanging(value);
                    this.SendPropertyChanging("installationmeney", value);
                    this._installationmeney = value;
                    this.SendPropertyChanged("installationmeney", value);
                    this.OninstallationmeneyChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_status", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? status {
            get {
                return this._status;
            }
            set {
                if ((this._status != value)) {
                    this.OnstatusChanging(value);
                    this.SendPropertyChanging("status", value);
                    this._status = value;
                    this.SendPropertyChanged("status", value);
                    this.OnstatusChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_createtime", DbType="datetime")]
        [DisplayName(" ")]
        [Description(" ")]
        public DateTime? createtime {
            get {
                return this._createtime;
            }
            set {
                if ((this._createtime != value)) {
                    this.OncreatetimeChanging(value);
                    this.SendPropertyChanging("createtime", value);
                    this._createtime = value;
                    this.SendPropertyChanged("createtime", value);
                    this.OncreatetimeChanged();
                }
            }
        }
    }
    /// <summary>
    ///  
    /// </summary>
    [Table(Name="t_grouporderpay")]
    [Serializable()]
    [DisplayName(" ")]
    [Description(" ")]
    public partial class Mgrouporderpay : DALModelBase {
        /// <summary>
        ///  
        /// </summary>
        Int32 _id;
        /// <summary>
        ///  
        /// </summary>
        Int32? _grouporderid;
        /// <summary>
        ///  
        /// </summary>
        String _grouporderno;
        /// <summary>
        ///  
        /// </summary>
        String _paycode;
        /// <summary>
        ///  
        /// </summary>
        Int32? _paytype;
        /// <summary>
        ///  
        /// </summary>
        Decimal? _paymoney;
        /// <summary>
        ///  
        /// </summary>
        String _descript;
        /// <summary>
        ///  
        /// </summary>
        Int32? _paystatus;
        /// <summary>
        ///  
        /// </summary>
        DateTime? _paydatetime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 grouporderid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OngrouporderidChanging(Int32? value);
        /// <summary>
        /// 当 grouporderid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OngrouporderidChanged();
        /// <summary>
        /// 当 grouporderno 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OngroupordernoChanging(String value);
        /// <summary>
        /// 当 grouporderno 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OngroupordernoChanged();
        /// <summary>
        /// 当 paycode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpaycodeChanging(String value);
        /// <summary>
        /// 当 paycode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpaycodeChanged();
        /// <summary>
        /// 当 paytype 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpaytypeChanging(Int32? value);
        /// <summary>
        /// 当 paytype 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpaytypeChanged();
        /// <summary>
        /// 当 paymoney 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpaymoneyChanging(Decimal? value);
        /// <summary>
        /// 当 paymoney 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpaymoneyChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 paystatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpaystatusChanging(Int32? value);
        /// <summary>
        /// 当 paystatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpaystatusChanged();
        /// <summary>
        /// 当 paydatetime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpaydatetimeChanging(DateTime? value);
        /// <summary>
        /// 当 paydatetime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpaydatetimeChanged();
        
        /// <summary>
        /// 初始化 Mgrouporderpay 实体类的新实例。
        /// </summary>
        public Mgrouporderpay() {
            this.OnCreated();
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_grouporderid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? grouporderid {
            get {
                return this._grouporderid;
            }
            set {
                if ((this._grouporderid != value)) {
                    this.OngrouporderidChanging(value);
                    this.SendPropertyChanging("grouporderid", value);
                    this._grouporderid = value;
                    this.SendPropertyChanged("grouporderid", value);
                    this.OngrouporderidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_grouporderno", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String grouporderno {
            get {
                return this._grouporderno;
            }
            set {
                if ((this._grouporderno != value)) {
                    this.OngroupordernoChanging(value);
                    this.SendPropertyChanging("grouporderno", value);
                    this._grouporderno = value;
                    this.SendPropertyChanged("grouporderno", value);
                    this.OngroupordernoChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_paycode", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String paycode {
            get {
                return this._paycode;
            }
            set {
                if ((this._paycode != value)) {
                    this.OnpaycodeChanging(value);
                    this.SendPropertyChanging("paycode", value);
                    this._paycode = value;
                    this.SendPropertyChanged("paycode", value);
                    this.OnpaycodeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_paytype", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? paytype {
            get {
                return this._paytype;
            }
            set {
                if ((this._paytype != value)) {
                    this.OnpaytypeChanging(value);
                    this.SendPropertyChanging("paytype", value);
                    this._paytype = value;
                    this.SendPropertyChanged("paytype", value);
                    this.OnpaytypeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_paymoney", DbType="decimal")]
        [DisplayName(" ")]
        [Description(" ")]
        public Decimal? paymoney {
            get {
                return this._paymoney;
            }
            set {
                if ((this._paymoney != value)) {
                    this.OnpaymoneyChanging(value);
                    this.SendPropertyChanging("paymoney", value);
                    this._paymoney = value;
                    this.SendPropertyChanged("paymoney", value);
                    this.OnpaymoneyChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_descript", DbType="ntext")]
        [DisplayName(" ")]
        [Description(" ")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_paystatus", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? paystatus {
            get {
                return this._paystatus;
            }
            set {
                if ((this._paystatus != value)) {
                    this.OnpaystatusChanging(value);
                    this.SendPropertyChanging("paystatus", value);
                    this._paystatus = value;
                    this.SendPropertyChanged("paystatus", value);
                    this.OnpaystatusChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_paydatetime", DbType="datetime")]
        [DisplayName(" ")]
        [Description(" ")]
        public DateTime? paydatetime {
            get {
                return this._paydatetime;
            }
            set {
                if ((this._paydatetime != value)) {
                    this.OnpaydatetimeChanging(value);
                    this.SendPropertyChanging("paydatetime", value);
                    this._paydatetime = value;
                    this.SendPropertyChanged("paydatetime", value);
                    this.OnpaydatetimeChanged();
                }
            }
        }
    }
    /// <summary>
    ///  
    /// </summary>
    [Table(Name="t_grouporderproduct")]
    [Serializable()]
    [DisplayName(" ")]
    [Description(" ")]
    public partial class Mgrouporderproduct : DALModelBase {
        /// <summary>
        ///  
        /// </summary>
        Int32 _id;
        /// <summary>
        ///  
        /// </summary>
        Int32? _grouporderid;
        /// <summary>
        ///  
        /// </summary>
        String _grouporderno;
        /// <summary>
        ///  
        /// </summary>
        Int32? _promotionid;
        /// <summary>
        ///  
        /// </summary>
        Int32? _promotiondefid;
        /// <summary>
        ///  
        /// </summary>
        Int32? _promoteionstageid;
        /// <summary>
        ///  
        /// </summary>
        String _promoteionstagevalue;
        /// <summary>
        ///  
        /// </summary>
        Int32? _productid;
        /// <summary>
        ///  
        /// </summary>
        Int32? _productattributeid;
        /// <summary>
        ///  
        /// </summary>
        String _productcode;
        /// <summary>
        ///  
        /// </summary>
        String _productname;
        /// <summary>
        ///  
        /// </summary>
        String _color;
        /// <summary>
        ///  
        /// </summary>
        String _material;
        /// <summary>
        ///  
        /// </summary>
        String _size;
        /// <summary>
        ///  
        /// </summary>
        Decimal? _cbm;
        /// <summary>
        ///  
        /// </summary>
        Int32? _num;
        /// <summary>
        ///  
        /// </summary>
        Decimal? _price;
        /// <summary>
        ///  
        /// </summary>
        Decimal? _totalmoney;
        /// <summary>
        ///  
        /// </summary>
        Decimal? _proprice;
        /// <summary>
        ///  
        /// </summary>
        Decimal? _prototalmoney;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 grouporderid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OngrouporderidChanging(Int32? value);
        /// <summary>
        /// 当 grouporderid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OngrouporderidChanged();
        /// <summary>
        /// 当 grouporderno 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OngroupordernoChanging(String value);
        /// <summary>
        /// 当 grouporderno 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OngroupordernoChanged();
        /// <summary>
        /// 当 promotionid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromotionidChanging(Int32? value);
        /// <summary>
        /// 当 promotionid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromotionidChanged();
        /// <summary>
        /// 当 promotiondefid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromotiondefidChanging(Int32? value);
        /// <summary>
        /// 当 promotiondefid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromotiondefidChanged();
        /// <summary>
        /// 当 promoteionstageid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromoteionstageidChanging(Int32? value);
        /// <summary>
        /// 当 promoteionstageid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromoteionstageidChanged();
        /// <summary>
        /// 当 promoteionstagevalue 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromoteionstagevalueChanging(String value);
        /// <summary>
        /// 当 promoteionstagevalue 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromoteionstagevalueChanged();
        /// <summary>
        /// 当 productid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductidChanging(Int32? value);
        /// <summary>
        /// 当 productid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductidChanged();
        /// <summary>
        /// 当 productattributeid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductattributeidChanging(Int32? value);
        /// <summary>
        /// 当 productattributeid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductattributeidChanged();
        /// <summary>
        /// 当 productcode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcodeChanging(String value);
        /// <summary>
        /// 当 productcode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcodeChanged();
        /// <summary>
        /// 当 productname 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductnameChanging(String value);
        /// <summary>
        /// 当 productname 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductnameChanged();
        /// <summary>
        /// 当 color 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncolorChanging(String value);
        /// <summary>
        /// 当 color 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncolorChanged();
        /// <summary>
        /// 当 material 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmaterialChanging(String value);
        /// <summary>
        /// 当 material 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmaterialChanged();
        /// <summary>
        /// 当 size 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsizeChanging(String value);
        /// <summary>
        /// 当 size 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsizeChanged();
        /// <summary>
        /// 当 cbm 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncbmChanging(Decimal? value);
        /// <summary>
        /// 当 cbm 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncbmChanged();
        /// <summary>
        /// 当 num 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnnumChanging(Int32? value);
        /// <summary>
        /// 当 num 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnnumChanged();
        /// <summary>
        /// 当 price 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpriceChanging(Decimal? value);
        /// <summary>
        /// 当 price 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpriceChanged();
        /// <summary>
        /// 当 totalmoney 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntotalmoneyChanging(Decimal? value);
        /// <summary>
        /// 当 totalmoney 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntotalmoneyChanged();
        /// <summary>
        /// 当 proprice 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpropriceChanging(Decimal? value);
        /// <summary>
        /// 当 proprice 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpropriceChanged();
        /// <summary>
        /// 当 prototalmoney 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnprototalmoneyChanging(Decimal? value);
        /// <summary>
        /// 当 prototalmoney 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnprototalmoneyChanged();
        
        /// <summary>
        /// 初始化 Mgrouporderproduct 实体类的新实例。
        /// </summary>
        public Mgrouporderproduct() {
            this.OnCreated();
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_grouporderid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? grouporderid {
            get {
                return this._grouporderid;
            }
            set {
                if ((this._grouporderid != value)) {
                    this.OngrouporderidChanging(value);
                    this.SendPropertyChanging("grouporderid", value);
                    this._grouporderid = value;
                    this.SendPropertyChanged("grouporderid", value);
                    this.OngrouporderidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_grouporderno", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String grouporderno {
            get {
                return this._grouporderno;
            }
            set {
                if ((this._grouporderno != value)) {
                    this.OngroupordernoChanging(value);
                    this.SendPropertyChanging("grouporderno", value);
                    this._grouporderno = value;
                    this.SendPropertyChanged("grouporderno", value);
                    this.OngroupordernoChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_promotionid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? promotionid {
            get {
                return this._promotionid;
            }
            set {
                if ((this._promotionid != value)) {
                    this.OnpromotionidChanging(value);
                    this.SendPropertyChanging("promotionid", value);
                    this._promotionid = value;
                    this.SendPropertyChanged("promotionid", value);
                    this.OnpromotionidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_promotiondefid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? promotiondefid {
            get {
                return this._promotiondefid;
            }
            set {
                if ((this._promotiondefid != value)) {
                    this.OnpromotiondefidChanging(value);
                    this.SendPropertyChanging("promotiondefid", value);
                    this._promotiondefid = value;
                    this.SendPropertyChanged("promotiondefid", value);
                    this.OnpromotiondefidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_promoteionstageid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? promoteionstageid {
            get {
                return this._promoteionstageid;
            }
            set {
                if ((this._promoteionstageid != value)) {
                    this.OnpromoteionstageidChanging(value);
                    this.SendPropertyChanging("promoteionstageid", value);
                    this._promoteionstageid = value;
                    this.SendPropertyChanged("promoteionstageid", value);
                    this.OnpromoteionstageidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_promoteionstagevalue", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String promoteionstagevalue {
            get {
                return this._promoteionstagevalue;
            }
            set {
                if ((this._promoteionstagevalue != value)) {
                    this.OnpromoteionstagevalueChanging(value);
                    this.SendPropertyChanging("promoteionstagevalue", value);
                    this._promoteionstagevalue = value;
                    this.SendPropertyChanged("promoteionstagevalue", value);
                    this.OnpromoteionstagevalueChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_productid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? productid {
            get {
                return this._productid;
            }
            set {
                if ((this._productid != value)) {
                    this.OnproductidChanging(value);
                    this.SendPropertyChanging("productid", value);
                    this._productid = value;
                    this.SendPropertyChanged("productid", value);
                    this.OnproductidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_productattributeid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? productattributeid {
            get {
                return this._productattributeid;
            }
            set {
                if ((this._productattributeid != value)) {
                    this.OnproductattributeidChanging(value);
                    this.SendPropertyChanging("productattributeid", value);
                    this._productattributeid = value;
                    this.SendPropertyChanged("productattributeid", value);
                    this.OnproductattributeidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_productcode", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String productcode {
            get {
                return this._productcode;
            }
            set {
                if ((this._productcode != value)) {
                    this.OnproductcodeChanging(value);
                    this.SendPropertyChanging("productcode", value);
                    this._productcode = value;
                    this.SendPropertyChanged("productcode", value);
                    this.OnproductcodeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_productname", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String productname {
            get {
                return this._productname;
            }
            set {
                if ((this._productname != value)) {
                    this.OnproductnameChanging(value);
                    this.SendPropertyChanging("productname", value);
                    this._productname = value;
                    this.SendPropertyChanged("productname", value);
                    this.OnproductnameChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_color", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String color {
            get {
                return this._color;
            }
            set {
                if ((this._color != value)) {
                    this.OncolorChanging(value);
                    this.SendPropertyChanging("color", value);
                    this._color = value;
                    this.SendPropertyChanged("color", value);
                    this.OncolorChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_material", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String material {
            get {
                return this._material;
            }
            set {
                if ((this._material != value)) {
                    this.OnmaterialChanging(value);
                    this.SendPropertyChanging("material", value);
                    this._material = value;
                    this.SendPropertyChanged("material", value);
                    this.OnmaterialChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_size", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String size {
            get {
                return this._size;
            }
            set {
                if ((this._size != value)) {
                    this.OnsizeChanging(value);
                    this.SendPropertyChanging("size", value);
                    this._size = value;
                    this.SendPropertyChanged("size", value);
                    this.OnsizeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_cbm", DbType="decimal")]
        [DisplayName(" ")]
        [Description(" ")]
        public Decimal? cbm {
            get {
                return this._cbm;
            }
            set {
                if ((this._cbm != value)) {
                    this.OncbmChanging(value);
                    this.SendPropertyChanging("cbm", value);
                    this._cbm = value;
                    this.SendPropertyChanged("cbm", value);
                    this.OncbmChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_num", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? num {
            get {
                return this._num;
            }
            set {
                if ((this._num != value)) {
                    this.OnnumChanging(value);
                    this.SendPropertyChanging("num", value);
                    this._num = value;
                    this.SendPropertyChanged("num", value);
                    this.OnnumChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_price", DbType="decimal")]
        [DisplayName(" ")]
        [Description(" ")]
        public Decimal? price {
            get {
                return this._price;
            }
            set {
                if ((this._price != value)) {
                    this.OnpriceChanging(value);
                    this.SendPropertyChanging("price", value);
                    this._price = value;
                    this.SendPropertyChanged("price", value);
                    this.OnpriceChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_totalmoney", DbType="decimal")]
        [DisplayName(" ")]
        [Description(" ")]
        public Decimal? totalmoney {
            get {
                return this._totalmoney;
            }
            set {
                if ((this._totalmoney != value)) {
                    this.OntotalmoneyChanging(value);
                    this.SendPropertyChanging("totalmoney", value);
                    this._totalmoney = value;
                    this.SendPropertyChanged("totalmoney", value);
                    this.OntotalmoneyChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_proprice", DbType="decimal")]
        [DisplayName(" ")]
        [Description(" ")]
        public Decimal? proprice {
            get {
                return this._proprice;
            }
            set {
                if ((this._proprice != value)) {
                    this.OnpropriceChanging(value);
                    this.SendPropertyChanging("proprice", value);
                    this._proprice = value;
                    this.SendPropertyChanged("proprice", value);
                    this.OnpropriceChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_prototalmoney", DbType="decimal")]
        [DisplayName(" ")]
        [Description(" ")]
        public Decimal? prototalmoney {
            get {
                return this._prototalmoney;
            }
            set {
                if ((this._prototalmoney != value)) {
                    this.OnprototalmoneyChanging(value);
                    this.SendPropertyChanging("prototalmoney", value);
                    this._prototalmoney = value;
                    this.SendPropertyChanged("prototalmoney", value);
                    this.OnprototalmoneyChanged();
                }
            }
        }
    }
    /// <summary>
    /// 日志表
    /// </summary>
    [Table(Name="t_log")]
    [Serializable()]
    [DisplayName("日志表")]
    [Description("日志表")]
    public partial class Mlog : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 模块
        /// </summary>
        Int32? _modeule;
        /// <summary>
        /// 动作
        /// </summary>
        Int32? _action;
        /// <summary>
        /// 操作人ID
        /// </summary>
        Int32? _operateid;
        /// <summary>
        /// 操作人名称
        /// </summary>
        String _operatename;
        /// <summary>
        /// 操作信息
        /// </summary>
        String _title;
        /// <summary>
        /// 操作时间
        /// </summary>
        DateTime? _lastedittime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 modeule 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmodeuleChanging(Int32? value);
        /// <summary>
        /// 当 modeule 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmodeuleChanged();
        /// <summary>
        /// 当 action 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnactionChanging(Int32? value);
        /// <summary>
        /// 当 action 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnactionChanged();
        /// <summary>
        /// 当 operateid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnoperateidChanging(Int32? value);
        /// <summary>
        /// 当 operateid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnoperateidChanged();
        /// <summary>
        /// 当 operatename 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnoperatenameChanging(String value);
        /// <summary>
        /// 当 operatename 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnoperatenameChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime? value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        
        /// <summary>
        /// 初始化 Mlog 实体类的新实例。
        /// </summary>
        public Mlog() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 模块
        /// </summary>
        [Column(Storage="_modeule", DbType="int")]
        [DisplayName("模块")]
        [Description("模块")]
        public Int32? modeule {
            get {
                return this._modeule;
            }
            set {
                if ((this._modeule != value)) {
                    this.OnmodeuleChanging(value);
                    this.SendPropertyChanging("modeule", value);
                    this._modeule = value;
                    this.SendPropertyChanged("modeule", value);
                    this.OnmodeuleChanged();
                }
            }
        }
        /// <summary>
        /// 动作
        /// </summary>
        [Column(Storage="_action", DbType="int")]
        [DisplayName("动作")]
        [Description("动作")]
        public Int32? action {
            get {
                return this._action;
            }
            set {
                if ((this._action != value)) {
                    this.OnactionChanging(value);
                    this.SendPropertyChanging("action", value);
                    this._action = value;
                    this.SendPropertyChanged("action", value);
                    this.OnactionChanged();
                }
            }
        }
        /// <summary>
        /// 操作人ID
        /// </summary>
        [Column(Storage="_operateid", DbType="int")]
        [DisplayName("操作人ID")]
        [Description("操作人ID")]
        public Int32? operateid {
            get {
                return this._operateid;
            }
            set {
                if ((this._operateid != value)) {
                    this.OnoperateidChanging(value);
                    this.SendPropertyChanging("operateid", value);
                    this._operateid = value;
                    this.SendPropertyChanged("operateid", value);
                    this.OnoperateidChanged();
                }
            }
        }
        /// <summary>
        /// 操作人名称
        /// </summary>
        [Column(Storage="_operatename", DbType="nvarchar(60)")]
        [DisplayName("操作人名称")]
        [Description("操作人名称")]
        public String operatename {
            get {
                return this._operatename;
            }
            set {
                if ((this._operatename != value)) {
                    this.OnoperatenameChanging(value);
                    this.SendPropertyChanging("operatename", value);
                    this._operatename = value;
                    this.SendPropertyChanged("operatename", value);
                    this.OnoperatenameChanged();
                }
            }
        }
        /// <summary>
        /// 操作信息
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(380)")]
        [DisplayName("操作信息")]
        [Description("操作信息")]
        public String title {
            get {
                return this._title;
            }
            set {
                if ((this._title != value)) {
                    this.OntitleChanging(value);
                    this.SendPropertyChanging("title", value);
                    this._title = value;
                    this.SendPropertyChanged("title", value);
                    this.OntitleChanged();
                }
            }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime")]
        [DisplayName("操作时间")]
        [Description("操作时间")]
        public DateTime? lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                if ((this._lastedittime != value)) {
                    this.OnlastedittimeChanging(value);
                    this.SendPropertyChanging("lastedittime", value);
                    this._lastedittime = value;
                    this.SendPropertyChanged("lastedittime", value);
                    this.OnlastedittimeChanged();
                }
            }
        }
    }
    /// <summary>
    /// 卖场表
    /// </summary>
    [Table(Name="t_market")]
    [Serializable()]
    [DisplayName("卖场表")]
    [Description("卖场表")]
    public partial class Mmarket : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 用户表ID
        /// </summary>
        Int32? _mid;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 索引
        /// </summary>
        String _letter;
        /// <summary>
        /// 组ID
        /// </summary>
        Int32? _groupid;
        /// <summary>
        /// 属性
        /// </summary>
        String _attribute;
        /// <summary>
        /// 行业
        /// </summary>
        String _industry;
        /// <summary>
        /// 产品分类
        /// </summary>
        String _productcategory;
        /// <summary>
        /// 是否vip
        /// </summary>
        Int32? _vip;
        /// <summary>
        /// 地区代码
        /// </summary>
        String _areacode;
        /// <summary>
        /// 地址
        /// </summary>
        String _address;
        /// <summary>
        /// 地图API值
        /// </summary>
        String _mapapi;
        /// <summary>
        /// 外观图
        /// </summary>
        Int32? _staffsize;
        /// <summary>
        /// 注册时间
        /// </summary>
        String _regyear;
        /// <summary>
        /// 注册城市
        /// </summary>
        String _regcity;
        /// <summary>
        /// 销售信息
        /// </summary>
        String _buy;
        /// <summary>
        /// 采购信息
        /// </summary>
        String _sell;
        /// <summary>
        /// 面积
        /// </summary>
        Decimal? _cbm;
        /// <summary>
        /// 投诉电话
        /// </summary>
        String _lphone;
        /// <summary>
        /// 招商电话
        /// </summary>
        String _zphone;
        /// <summary>
        /// 公交线路
        /// </summary>
        String _busroute;
        /// <summary>
        /// 营业时间
        /// </summary>
        String _hours;
        /// <summary>
        /// 联系人
        /// </summary>
        String _linkman;
        /// <summary>
        /// 联系电话
        /// </summary>
        String _phone;
        /// <summary>
        /// 联系手机
        /// </summary>
        String _mphone;
        /// <summary>
        /// 传真
        /// </summary>
        String _fax;
        /// <summary>
        /// 邮件
        /// </summary>
        String _email;
        /// <summary>
        /// 邮编
        /// </summary>
        String _postcode;
        /// <summary>
        /// 主页
        /// </summary>
        String _homepage;
        /// <summary>
        /// 域名
        /// </summary>
        String _domain;
        /// <summary>
        /// 域名IP
        /// </summary>
        String _domainip;
        /// <summary>
        /// 备案号
        /// </summary>
        String _icp;
        /// <summary>
        /// 外观图
        /// </summary>
        String _surface;
        /// <summary>
        /// logo
        /// </summary>
        String _logo;
        /// <summary>
        /// 缩略图
        /// </summary>
        String _thumb;
        /// <summary>
        /// 幻灯图
        /// </summary>
        String _bannel;
        /// <summary>
        /// 描述图
        /// </summary>
        String _desimage;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 关键字
        /// </summary>
        String _keywords;
        /// <summary>
        /// 模版ID
        /// </summary>
        String _template;
        /// <summary>
        /// 点击量
        /// </summary>
        Int32? _hits;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 创建人
        /// </summary>
        Int32? _createmid;
        /// <summary>
        /// 最后修改人
        /// </summary>
        Int32? _lastedid;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        /// 审核状态
        /// </summary>
        Int32 _auditstatus;
        /// <summary>
        /// 上下线状态
        /// </summary>
        Int32 _linestatus;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 mid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmidChanging(Int32? value);
        /// <summary>
        /// 当 mid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 letter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnletterChanging(String value);
        /// <summary>
        /// 当 letter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnletterChanged();
        /// <summary>
        /// 当 groupid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OngroupidChanging(Int32? value);
        /// <summary>
        /// 当 groupid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OngroupidChanged();
        /// <summary>
        /// 当 attribute 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnattributeChanging(String value);
        /// <summary>
        /// 当 attribute 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnattributeChanged();
        /// <summary>
        /// 当 industry 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnindustryChanging(String value);
        /// <summary>
        /// 当 industry 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnindustryChanged();
        /// <summary>
        /// 当 productcategory 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcategoryChanging(String value);
        /// <summary>
        /// 当 productcategory 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcategoryChanged();
        /// <summary>
        /// 当 vip 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvipChanging(Int32? value);
        /// <summary>
        /// 当 vip 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvipChanged();
        /// <summary>
        /// 当 areacode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnareacodeChanging(String value);
        /// <summary>
        /// 当 areacode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnareacodeChanged();
        /// <summary>
        /// 当 address 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaddressChanging(String value);
        /// <summary>
        /// 当 address 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaddressChanged();
        /// <summary>
        /// 当 mapapi 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmapapiChanging(String value);
        /// <summary>
        /// 当 mapapi 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmapapiChanged();
        /// <summary>
        /// 当 staffsize 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstaffsizeChanging(Int32? value);
        /// <summary>
        /// 当 staffsize 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstaffsizeChanged();
        /// <summary>
        /// 当 regyear 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnregyearChanging(String value);
        /// <summary>
        /// 当 regyear 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnregyearChanged();
        /// <summary>
        /// 当 regcity 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnregcityChanging(String value);
        /// <summary>
        /// 当 regcity 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnregcityChanged();
        /// <summary>
        /// 当 buy 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbuyChanging(String value);
        /// <summary>
        /// 当 buy 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbuyChanged();
        /// <summary>
        /// 当 sell 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsellChanging(String value);
        /// <summary>
        /// 当 sell 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsellChanged();
        /// <summary>
        /// 当 cbm 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncbmChanging(Decimal? value);
        /// <summary>
        /// 当 cbm 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncbmChanged();
        /// <summary>
        /// 当 lphone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlphoneChanging(String value);
        /// <summary>
        /// 当 lphone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlphoneChanged();
        /// <summary>
        /// 当 zphone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnzphoneChanging(String value);
        /// <summary>
        /// 当 zphone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnzphoneChanged();
        /// <summary>
        /// 当 busroute 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbusrouteChanging(String value);
        /// <summary>
        /// 当 busroute 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbusrouteChanged();
        /// <summary>
        /// 当 hours 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhoursChanging(String value);
        /// <summary>
        /// 当 hours 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhoursChanged();
        /// <summary>
        /// 当 linkman 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinkmanChanging(String value);
        /// <summary>
        /// 当 linkman 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinkmanChanged();
        /// <summary>
        /// 当 phone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnphoneChanging(String value);
        /// <summary>
        /// 当 phone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnphoneChanged();
        /// <summary>
        /// 当 mphone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmphoneChanging(String value);
        /// <summary>
        /// 当 mphone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmphoneChanged();
        /// <summary>
        /// 当 fax 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnfaxChanging(String value);
        /// <summary>
        /// 当 fax 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnfaxChanged();
        /// <summary>
        /// 当 email 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnemailChanging(String value);
        /// <summary>
        /// 当 email 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnemailChanged();
        /// <summary>
        /// 当 postcode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpostcodeChanging(String value);
        /// <summary>
        /// 当 postcode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpostcodeChanged();
        /// <summary>
        /// 当 homepage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhomepageChanging(String value);
        /// <summary>
        /// 当 homepage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhomepageChanged();
        /// <summary>
        /// 当 domain 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndomainChanging(String value);
        /// <summary>
        /// 当 domain 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndomainChanged();
        /// <summary>
        /// 当 domainip 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndomainipChanging(String value);
        /// <summary>
        /// 当 domainip 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndomainipChanged();
        /// <summary>
        /// 当 icp 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnicpChanging(String value);
        /// <summary>
        /// 当 icp 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnicpChanged();
        /// <summary>
        /// 当 surface 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsurfaceChanging(String value);
        /// <summary>
        /// 当 surface 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsurfaceChanged();
        /// <summary>
        /// 当 logo 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlogoChanging(String value);
        /// <summary>
        /// 当 logo 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlogoChanged();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 bannel 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannelChanging(String value);
        /// <summary>
        /// 当 bannel 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannelChanged();
        /// <summary>
        /// 当 desimage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndesimageChanging(String value);
        /// <summary>
        /// 当 desimage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndesimageChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 keywords 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnkeywordsChanging(String value);
        /// <summary>
        /// 当 keywords 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnkeywordsChanged();
        /// <summary>
        /// 当 template 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntemplateChanging(String value);
        /// <summary>
        /// 当 template 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntemplateChanged();
        /// <summary>
        /// 当 hits 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhitsChanging(Int32? value);
        /// <summary>
        /// 当 hits 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhitsChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 createmid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatemidChanging(Int32? value);
        /// <summary>
        /// 当 createmid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatemidChanged();
        /// <summary>
        /// 当 lastedid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedidChanging(Int32? value);
        /// <summary>
        /// 当 lastedid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedidChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        /// <summary>
        /// 当 auditstatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauditstatusChanging(Int32 value);
        /// <summary>
        /// 当 auditstatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauditstatusChanged();
        /// <summary>
        /// 当 linestatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinestatusChanging(Int32 value);
        /// <summary>
        /// 当 linestatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinestatusChanged();
        
        /// <summary>
        /// 初始化 Mmarket 实体类的新实例。
        /// </summary>
        public Mmarket() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 用户表ID
        /// </summary>
        [Column(Storage="_mid", DbType="int")]
        [DisplayName("用户表ID")]
        [Description("用户表ID")]
        public Int32? mid {
            get {
                return this._mid;
            }
            set {
                if ((this._mid != value)) {
                    this.OnmidChanging(value);
                    this.SendPropertyChanging("mid", value);
                    this._mid = value;
                    this.SendPropertyChanged("mid", value);
                    this.OnmidChanged();
                }
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(80) NOT NULL", CanBeNull=false)]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 索引
        /// </summary>
        [Column(Storage="_letter", DbType="varchar(20)")]
        [DisplayName("索引")]
        [Description("索引")]
        public String letter {
            get {
                return this._letter;
            }
            set {
                if ((this._letter != value)) {
                    this.OnletterChanging(value);
                    this.SendPropertyChanging("letter", value);
                    this._letter = value;
                    this.SendPropertyChanged("letter", value);
                    this.OnletterChanged();
                }
            }
        }
        /// <summary>
        /// 组ID
        /// </summary>
        [Column(Storage="_groupid", DbType="int")]
        [DisplayName("组ID")]
        [Description("组ID")]
        public Int32? groupid {
            get {
                return this._groupid;
            }
            set {
                if ((this._groupid != value)) {
                    this.OngroupidChanging(value);
                    this.SendPropertyChanging("groupid", value);
                    this._groupid = value;
                    this.SendPropertyChanged("groupid", value);
                    this.OngroupidChanged();
                }
            }
        }
        /// <summary>
        /// 属性
        /// </summary>
        [Column(Storage="_attribute", DbType="varchar(100)")]
        [DisplayName("属性")]
        [Description("属性")]
        public String attribute {
            get {
                return this._attribute;
            }
            set {
                if ((this._attribute != value)) {
                    this.OnattributeChanging(value);
                    this.SendPropertyChanging("attribute", value);
                    this._attribute = value;
                    this.SendPropertyChanged("attribute", value);
                    this.OnattributeChanged();
                }
            }
        }
        /// <summary>
        /// 行业
        /// </summary>
        [Column(Storage="_industry", DbType="varchar(50)")]
        [DisplayName("行业")]
        [Description("行业")]
        public String industry {
            get {
                return this._industry;
            }
            set {
                if ((this._industry != value)) {
                    this.OnindustryChanging(value);
                    this.SendPropertyChanging("industry", value);
                    this._industry = value;
                    this.SendPropertyChanged("industry", value);
                    this.OnindustryChanged();
                }
            }
        }
        /// <summary>
        /// 产品分类
        /// </summary>
        [Column(Storage="_productcategory", DbType="varchar(50)")]
        [DisplayName("产品分类")]
        [Description("产品分类")]
        public String productcategory {
            get {
                return this._productcategory;
            }
            set {
                if ((this._productcategory != value)) {
                    this.OnproductcategoryChanging(value);
                    this.SendPropertyChanging("productcategory", value);
                    this._productcategory = value;
                    this.SendPropertyChanged("productcategory", value);
                    this.OnproductcategoryChanged();
                }
            }
        }
        /// <summary>
        /// 是否vip
        /// </summary>
        [Column(Storage="_vip", DbType="int")]
        [DisplayName("是否vip")]
        [Description("是否vip")]
        public Int32? vip {
            get {
                return this._vip;
            }
            set {
                if ((this._vip != value)) {
                    this.OnvipChanging(value);
                    this.SendPropertyChanging("vip", value);
                    this._vip = value;
                    this.SendPropertyChanged("vip", value);
                    this.OnvipChanged();
                }
            }
        }
        /// <summary>
        /// 地区代码
        /// </summary>
        [Column(Storage="_areacode", DbType="varchar(10)")]
        [DisplayName("地区代码")]
        [Description("地区代码")]
        public String areacode {
            get {
                return this._areacode;
            }
            set {
                if ((this._areacode != value)) {
                    this.OnareacodeChanging(value);
                    this.SendPropertyChanging("areacode", value);
                    this._areacode = value;
                    this.SendPropertyChanged("areacode", value);
                    this.OnareacodeChanged();
                }
            }
        }
        /// <summary>
        /// 地址
        /// </summary>
        [Column(Storage="_address", DbType="nvarchar(60)")]
        [DisplayName("地址")]
        [Description("地址")]
        public String address {
            get {
                return this._address;
            }
            set {
                if ((this._address != value)) {
                    this.OnaddressChanging(value);
                    this.SendPropertyChanging("address", value);
                    this._address = value;
                    this.SendPropertyChanged("address", value);
                    this.OnaddressChanged();
                }
            }
        }
        /// <summary>
        /// 地图API值
        /// </summary>
        [Column(Storage="_mapapi", DbType="nvarchar(80)")]
        [DisplayName("地图API值")]
        [Description("地图API值")]
        public String mapapi {
            get {
                return this._mapapi;
            }
            set {
                if ((this._mapapi != value)) {
                    this.OnmapapiChanging(value);
                    this.SendPropertyChanging("mapapi", value);
                    this._mapapi = value;
                    this.SendPropertyChanged("mapapi", value);
                    this.OnmapapiChanged();
                }
            }
        }
        /// <summary>
        /// 外观图
        /// </summary>
        [Column(Storage="_staffsize", DbType="int")]
        [DisplayName("外观图")]
        [Description("外观图")]
        public Int32? staffsize {
            get {
                return this._staffsize;
            }
            set {
                if ((this._staffsize != value)) {
                    this.OnstaffsizeChanging(value);
                    this.SendPropertyChanging("staffsize", value);
                    this._staffsize = value;
                    this.SendPropertyChanged("staffsize", value);
                    this.OnstaffsizeChanged();
                }
            }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        [Column(Storage="_regyear", DbType="varchar(7)")]
        [DisplayName("注册时间")]
        [Description("注册时间")]
        public String regyear {
            get {
                return this._regyear;
            }
            set {
                if ((this._regyear != value)) {
                    this.OnregyearChanging(value);
                    this.SendPropertyChanging("regyear", value);
                    this._regyear = value;
                    this.SendPropertyChanged("regyear", value);
                    this.OnregyearChanged();
                }
            }
        }
        /// <summary>
        /// 注册城市
        /// </summary>
        [Column(Storage="_regcity", DbType="varchar(10)")]
        [DisplayName("注册城市")]
        [Description("注册城市")]
        public String regcity {
            get {
                return this._regcity;
            }
            set {
                if ((this._regcity != value)) {
                    this.OnregcityChanging(value);
                    this.SendPropertyChanging("regcity", value);
                    this._regcity = value;
                    this.SendPropertyChanged("regcity", value);
                    this.OnregcityChanged();
                }
            }
        }
        /// <summary>
        /// 销售信息
        /// </summary>
        [Column(Storage="_buy", DbType="nvarchar(300)")]
        [DisplayName("销售信息")]
        [Description("销售信息")]
        public String buy {
            get {
                return this._buy;
            }
            set {
                if ((this._buy != value)) {
                    this.OnbuyChanging(value);
                    this.SendPropertyChanging("buy", value);
                    this._buy = value;
                    this.SendPropertyChanged("buy", value);
                    this.OnbuyChanged();
                }
            }
        }
        /// <summary>
        /// 采购信息
        /// </summary>
        [Column(Storage="_sell", DbType="nvarchar(300)")]
        [DisplayName("采购信息")]
        [Description("采购信息")]
        public String sell {
            get {
                return this._sell;
            }
            set {
                if ((this._sell != value)) {
                    this.OnsellChanging(value);
                    this.SendPropertyChanging("sell", value);
                    this._sell = value;
                    this.SendPropertyChanged("sell", value);
                    this.OnsellChanged();
                }
            }
        }
        /// <summary>
        /// 面积
        /// </summary>
        [Column(Storage="_cbm", DbType="decimal")]
        [DisplayName("面积")]
        [Description("面积")]
        public Decimal? cbm {
            get {
                return this._cbm;
            }
            set {
                if ((this._cbm != value)) {
                    this.OncbmChanging(value);
                    this.SendPropertyChanging("cbm", value);
                    this._cbm = value;
                    this.SendPropertyChanged("cbm", value);
                    this.OncbmChanged();
                }
            }
        }
        /// <summary>
        /// 投诉电话
        /// </summary>
        [Column(Storage="_lphone", DbType="varchar(50)")]
        [DisplayName("投诉电话")]
        [Description("投诉电话")]
        public String lphone {
            get {
                return this._lphone;
            }
            set {
                if ((this._lphone != value)) {
                    this.OnlphoneChanging(value);
                    this.SendPropertyChanging("lphone", value);
                    this._lphone = value;
                    this.SendPropertyChanged("lphone", value);
                    this.OnlphoneChanged();
                }
            }
        }
        /// <summary>
        /// 招商电话
        /// </summary>
        [Column(Storage="_zphone", DbType="varchar(50)")]
        [DisplayName("招商电话")]
        [Description("招商电话")]
        public String zphone {
            get {
                return this._zphone;
            }
            set {
                if ((this._zphone != value)) {
                    this.OnzphoneChanging(value);
                    this.SendPropertyChanging("zphone", value);
                    this._zphone = value;
                    this.SendPropertyChanged("zphone", value);
                    this.OnzphoneChanged();
                }
            }
        }
        /// <summary>
        /// 公交线路
        /// </summary>
        [Column(Storage="_busroute", DbType="nvarchar(160)")]
        [DisplayName("公交线路")]
        [Description("公交线路")]
        public String busroute {
            get {
                return this._busroute;
            }
            set {
                if ((this._busroute != value)) {
                    this.OnbusrouteChanging(value);
                    this.SendPropertyChanging("busroute", value);
                    this._busroute = value;
                    this.SendPropertyChanged("busroute", value);
                    this.OnbusrouteChanged();
                }
            }
        }
        /// <summary>
        /// 营业时间
        /// </summary>
        [Column(Storage="_hours", DbType="nvarchar(160)")]
        [DisplayName("营业时间")]
        [Description("营业时间")]
        public String hours {
            get {
                return this._hours;
            }
            set {
                if ((this._hours != value)) {
                    this.OnhoursChanging(value);
                    this.SendPropertyChanging("hours", value);
                    this._hours = value;
                    this.SendPropertyChanged("hours", value);
                    this.OnhoursChanged();
                }
            }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        [Column(Storage="_linkman", DbType="nvarchar(20)")]
        [DisplayName("联系人")]
        [Description("联系人")]
        public String linkman {
            get {
                return this._linkman;
            }
            set {
                if ((this._linkman != value)) {
                    this.OnlinkmanChanging(value);
                    this.SendPropertyChanging("linkman", value);
                    this._linkman = value;
                    this.SendPropertyChanged("linkman", value);
                    this.OnlinkmanChanged();
                }
            }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Column(Storage="_phone", DbType="varchar(20)")]
        [DisplayName("联系电话")]
        [Description("联系电话")]
        public String phone {
            get {
                return this._phone;
            }
            set {
                if ((this._phone != value)) {
                    this.OnphoneChanging(value);
                    this.SendPropertyChanging("phone", value);
                    this._phone = value;
                    this.SendPropertyChanged("phone", value);
                    this.OnphoneChanged();
                }
            }
        }
        /// <summary>
        /// 联系手机
        /// </summary>
        [Column(Storage="_mphone", DbType="varchar(20)")]
        [DisplayName("联系手机")]
        [Description("联系手机")]
        public String mphone {
            get {
                return this._mphone;
            }
            set {
                if ((this._mphone != value)) {
                    this.OnmphoneChanging(value);
                    this.SendPropertyChanging("mphone", value);
                    this._mphone = value;
                    this.SendPropertyChanged("mphone", value);
                    this.OnmphoneChanged();
                }
            }
        }
        /// <summary>
        /// 传真
        /// </summary>
        [Column(Storage="_fax", DbType="varchar(20)")]
        [DisplayName("传真")]
        [Description("传真")]
        public String fax {
            get {
                return this._fax;
            }
            set {
                if ((this._fax != value)) {
                    this.OnfaxChanging(value);
                    this.SendPropertyChanging("fax", value);
                    this._fax = value;
                    this.SendPropertyChanged("fax", value);
                    this.OnfaxChanged();
                }
            }
        }
        /// <summary>
        /// 邮件
        /// </summary>
        [Column(Storage="_email", DbType="varchar(50)")]
        [DisplayName("邮件")]
        [Description("邮件")]
        public String email {
            get {
                return this._email;
            }
            set {
                if ((this._email != value)) {
                    this.OnemailChanging(value);
                    this.SendPropertyChanging("email", value);
                    this._email = value;
                    this.SendPropertyChanged("email", value);
                    this.OnemailChanged();
                }
            }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        [Column(Storage="_postcode", DbType="varchar(15)")]
        [DisplayName("邮编")]
        [Description("邮编")]
        public String postcode {
            get {
                return this._postcode;
            }
            set {
                if ((this._postcode != value)) {
                    this.OnpostcodeChanging(value);
                    this.SendPropertyChanging("postcode", value);
                    this._postcode = value;
                    this.SendPropertyChanged("postcode", value);
                    this.OnpostcodeChanged();
                }
            }
        }
        /// <summary>
        /// 主页
        /// </summary>
        [Column(Storage="_homepage", DbType="varchar(50)")]
        [DisplayName("主页")]
        [Description("主页")]
        public String homepage {
            get {
                return this._homepage;
            }
            set {
                if ((this._homepage != value)) {
                    this.OnhomepageChanging(value);
                    this.SendPropertyChanging("homepage", value);
                    this._homepage = value;
                    this.SendPropertyChanged("homepage", value);
                    this.OnhomepageChanged();
                }
            }
        }
        /// <summary>
        /// 域名
        /// </summary>
        [Column(Storage="_domain", DbType="varchar(50)")]
        [DisplayName("域名")]
        [Description("域名")]
        public String domain {
            get {
                return this._domain;
            }
            set {
                if ((this._domain != value)) {
                    this.OndomainChanging(value);
                    this.SendPropertyChanging("domain", value);
                    this._domain = value;
                    this.SendPropertyChanged("domain", value);
                    this.OndomainChanged();
                }
            }
        }
        /// <summary>
        /// 域名IP
        /// </summary>
        [Column(Storage="_domainip", DbType="varchar(50)")]
        [DisplayName("域名IP")]
        [Description("域名IP")]
        public String domainip {
            get {
                return this._domainip;
            }
            set {
                if ((this._domainip != value)) {
                    this.OndomainipChanging(value);
                    this.SendPropertyChanging("domainip", value);
                    this._domainip = value;
                    this.SendPropertyChanged("domainip", value);
                    this.OndomainipChanged();
                }
            }
        }
        /// <summary>
        /// 备案号
        /// </summary>
        [Column(Storage="_icp", DbType="nvarchar(50)")]
        [DisplayName("备案号")]
        [Description("备案号")]
        public String icp {
            get {
                return this._icp;
            }
            set {
                if ((this._icp != value)) {
                    this.OnicpChanging(value);
                    this.SendPropertyChanging("icp", value);
                    this._icp = value;
                    this.SendPropertyChanged("icp", value);
                    this.OnicpChanged();
                }
            }
        }
        /// <summary>
        /// 外观图
        /// </summary>
        [Column(Storage="_surface", DbType="varchar(200)")]
        [DisplayName("外观图")]
        [Description("外观图")]
        public String surface {
            get {
                return this._surface;
            }
            set {
                if ((this._surface != value)) {
                    this.OnsurfaceChanging(value);
                    this.SendPropertyChanging("surface", value);
                    this._surface = value;
                    this.SendPropertyChanged("surface", value);
                    this.OnsurfaceChanged();
                }
            }
        }
        /// <summary>
        /// logo
        /// </summary>
        [Column(Storage="_logo", DbType="varchar(40)")]
        [DisplayName("logo")]
        [Description("logo")]
        public String logo {
            get {
                return this._logo;
            }
            set {
                if ((this._logo != value)) {
                    this.OnlogoChanging(value);
                    this.SendPropertyChanging("logo", value);
                    this._logo = value;
                    this.SendPropertyChanged("logo", value);
                    this.OnlogoChanged();
                }
            }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(40)")]
        [DisplayName("缩略图")]
        [Description("缩略图")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        /// 幻灯图
        /// </summary>
        [Column(Storage="_bannel", DbType="varchar(300)")]
        [DisplayName("幻灯图")]
        [Description("幻灯图")]
        public String bannel {
            get {
                return this._bannel;
            }
            set {
                if ((this._bannel != value)) {
                    this.OnbannelChanging(value);
                    this.SendPropertyChanging("bannel", value);
                    this._bannel = value;
                    this.SendPropertyChanged("bannel", value);
                    this.OnbannelChanged();
                }
            }
        }
        /// <summary>
        /// 描述图
        /// </summary>
        [Column(Storage="_desimage", DbType="varchar(400)")]
        [DisplayName("描述图")]
        [Description("描述图")]
        public String desimage {
            get {
                return this._desimage;
            }
            set {
                if ((this._desimage != value)) {
                    this.OndesimageChanging(value);
                    this.SendPropertyChanging("desimage", value);
                    this._desimage = value;
                    this.SendPropertyChanged("desimage", value);
                    this.OndesimageChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="ntext")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        [Column(Storage="_keywords", DbType="nvarchar(200)")]
        [DisplayName("关键字")]
        [Description("关键字")]
        public String keywords {
            get {
                return this._keywords;
            }
            set {
                if ((this._keywords != value)) {
                    this.OnkeywordsChanging(value);
                    this.SendPropertyChanging("keywords", value);
                    this._keywords = value;
                    this.SendPropertyChanged("keywords", value);
                    this.OnkeywordsChanged();
                }
            }
        }
        /// <summary>
        /// 模版ID
        /// </summary>
        [Column(Storage="_template", DbType="varchar(50)")]
        [DisplayName("模版ID")]
        [Description("模版ID")]
        public String template {
            get {
                return this._template;
            }
            set {
                if ((this._template != value)) {
                    this.OntemplateChanging(value);
                    this.SendPropertyChanging("template", value);
                    this._template = value;
                    this.SendPropertyChanged("template", value);
                    this.OntemplateChanged();
                }
            }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        [Column(Storage="_hits", DbType="int")]
        [DisplayName("点击量")]
        [Description("点击量")]
        public Int32? hits {
            get {
                return this._hits;
            }
            set {
                if ((this._hits != value)) {
                    this.OnhitsChanging(value);
                    this.SendPropertyChanging("hits", value);
                    this._hits = value;
                    this.SendPropertyChanged("hits", value);
                    this.OnhitsChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column(Storage="_createmid", DbType="int")]
        [DisplayName("创建人")]
        [Description("创建人")]
        public Int32? createmid {
            get {
                return this._createmid;
            }
            set {
                if ((this._createmid != value)) {
                    this.OncreatemidChanging(value);
                    this.SendPropertyChanging("createmid", value);
                    this._createmid = value;
                    this.SendPropertyChanged("createmid", value);
                    this.OncreatemidChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改人
        /// </summary>
        [Column(Storage="_lastedid", DbType="int")]
        [DisplayName("最后修改人")]
        [Description("最后修改人")]
        public Int32? lastedid {
            get {
                return this._lastedid;
            }
            set {
                if ((this._lastedid != value)) {
                    this.OnlastedidChanging(value);
                    this.SendPropertyChanging("lastedid", value);
                    this._lastedid = value;
                    this.SendPropertyChanged("lastedid", value);
                    this.OnlastedidChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最后修改时间")]
        [Description("最后修改时间")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        [Column(Storage="_auditstatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("审核状态")]
        [Description("审核状态")]
        public Int32 auditstatus {
            get {
                return this._auditstatus;
            }
            set {
                this.OnauditstatusChanging(value);
                this.SendPropertyChanging("auditstatus", value);
                this._auditstatus = value;
                this.SendPropertyChanged("auditstatus", value);
                this.OnauditstatusChanged();
            }
        }
        /// <summary>
        /// 上下线状态
        /// </summary>
        [Column(Storage="_linestatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("上下线状态")]
        [Description("上下线状态")]
        public Int32 linestatus {
            get {
                return this._linestatus;
            }
            set {
                this.OnlinestatusChanging(value);
                this.SendPropertyChanging("linestatus", value);
                this._linestatus = value;
                this.SendPropertyChanged("linestatus", value);
                this.OnlinestatusChanged();
            }
        }
    }
    /// <summary>
    /// 卖场组表
    /// </summary>
    [Table(Name="t_marketgroup")]
    [Serializable()]
    [DisplayName("卖场组表")]
    [Description("卖场组表")]
    public partial class Mmarketgroup : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 组名称
        /// </summary>
        String _title;
        /// <summary>
        /// 组名称颜色
        /// </summary>
        String _color;
        /// <summary>
        /// 组图标
        /// </summary>
        String _avatar;
        /// <summary>
        /// 积分达到
        /// </summary>
        Decimal? _integral;
        /// <summary>
        /// 金钱达到
        /// </summary>
        Decimal? _money;
        /// <summary>
        /// 广告数量限制
        /// </summary>
        Int32? _adcount;
        /// <summary>
        /// 店铺数量限制
        /// </summary>
        Int32? _shopcount;
        /// <summary>
        /// 品牌数量限制
        /// </summary>
        Int32? _brandcount;
        /// <summary>
        /// 促销信息数量限制
        /// </summary>
        Int32? _promotioncount;
        /// <summary>
        /// 推荐数量限制
        /// </summary>
        Int32? _storeycount;
        /// <summary>
        /// 推荐店铺数量限制
        /// </summary>
        Int32? _storeyshopcount;
        /// <summary>
        ///  
        /// </summary>
        Int32? _adrecommend;
        /// <summary>
        ///  
        /// </summary>
        Int32? _shoprecommend;
        /// <summary>
        ///  
        /// </summary>
        Int32? _brandrecommend;
        /// <summary>
        ///  
        /// </summary>
        Int32? _promotionrecommend;
        /// <summary>
        /// 级别
        /// </summary>
        Int32? _lev;
        /// <summary>
        ///  
        /// </summary>
        String _permissions;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 color 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncolorChanging(String value);
        /// <summary>
        /// 当 color 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncolorChanged();
        /// <summary>
        /// 当 avatar 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnavatarChanging(String value);
        /// <summary>
        /// 当 avatar 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnavatarChanged();
        /// <summary>
        /// 当 integral 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnintegralChanging(Decimal? value);
        /// <summary>
        /// 当 integral 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnintegralChanged();
        /// <summary>
        /// 当 money 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmoneyChanging(Decimal? value);
        /// <summary>
        /// 当 money 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmoneyChanged();
        /// <summary>
        /// 当 adcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadcountChanging(Int32? value);
        /// <summary>
        /// 当 adcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadcountChanged();
        /// <summary>
        /// 当 shopcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshopcountChanging(Int32? value);
        /// <summary>
        /// 当 shopcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshopcountChanged();
        /// <summary>
        /// 当 brandcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandcountChanging(Int32? value);
        /// <summary>
        /// 当 brandcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandcountChanged();
        /// <summary>
        /// 当 promotioncount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromotioncountChanging(Int32? value);
        /// <summary>
        /// 当 promotioncount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromotioncountChanged();
        /// <summary>
        /// 当 storeycount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstoreycountChanging(Int32? value);
        /// <summary>
        /// 当 storeycount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstoreycountChanged();
        /// <summary>
        /// 当 storeyshopcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstoreyshopcountChanging(Int32? value);
        /// <summary>
        /// 当 storeyshopcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstoreyshopcountChanged();
        /// <summary>
        /// 当 adrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadrecommendChanging(Int32? value);
        /// <summary>
        /// 当 adrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadrecommendChanged();
        /// <summary>
        /// 当 shoprecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshoprecommendChanging(Int32? value);
        /// <summary>
        /// 当 shoprecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshoprecommendChanged();
        /// <summary>
        /// 当 brandrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandrecommendChanging(Int32? value);
        /// <summary>
        /// 当 brandrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandrecommendChanged();
        /// <summary>
        /// 当 promotionrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromotionrecommendChanging(Int32? value);
        /// <summary>
        /// 当 promotionrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromotionrecommendChanged();
        /// <summary>
        /// 当 lev 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlevChanging(Int32? value);
        /// <summary>
        /// 当 lev 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlevChanged();
        /// <summary>
        /// 当 permissions 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpermissionsChanging(String value);
        /// <summary>
        /// 当 permissions 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpermissionsChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Mmarketgroup 实体类的新实例。
        /// </summary>
        public Mmarketgroup() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 组名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(30) NOT NULL", CanBeNull=false)]
        [DisplayName("组名称")]
        [Description("组名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 组名称颜色
        /// </summary>
        [Column(Storage="_color", DbType="char(7)")]
        [DisplayName("组名称颜色")]
        [Description("组名称颜色")]
        public String color {
            get {
                return this._color;
            }
            set {
                if ((this._color != value)) {
                    this.OncolorChanging(value);
                    this.SendPropertyChanging("color", value);
                    this._color = value;
                    this.SendPropertyChanged("color", value);
                    this.OncolorChanged();
                }
            }
        }
        /// <summary>
        /// 组图标
        /// </summary>
        [Column(Storage="_avatar", DbType="varchar(40)")]
        [DisplayName("组图标")]
        [Description("组图标")]
        public String avatar {
            get {
                return this._avatar;
            }
            set {
                if ((this._avatar != value)) {
                    this.OnavatarChanging(value);
                    this.SendPropertyChanging("avatar", value);
                    this._avatar = value;
                    this.SendPropertyChanged("avatar", value);
                    this.OnavatarChanged();
                }
            }
        }
        /// <summary>
        /// 积分达到
        /// </summary>
        [Column(Storage="_integral", DbType="decimal")]
        [DisplayName("积分达到")]
        [Description("积分达到")]
        public Decimal? integral {
            get {
                return this._integral;
            }
            set {
                if ((this._integral != value)) {
                    this.OnintegralChanging(value);
                    this.SendPropertyChanging("integral", value);
                    this._integral = value;
                    this.SendPropertyChanged("integral", value);
                    this.OnintegralChanged();
                }
            }
        }
        /// <summary>
        /// 金钱达到
        /// </summary>
        [Column(Storage="_money", DbType="decimal")]
        [DisplayName("金钱达到")]
        [Description("金钱达到")]
        public Decimal? money {
            get {
                return this._money;
            }
            set {
                if ((this._money != value)) {
                    this.OnmoneyChanging(value);
                    this.SendPropertyChanging("money", value);
                    this._money = value;
                    this.SendPropertyChanged("money", value);
                    this.OnmoneyChanged();
                }
            }
        }
        /// <summary>
        /// 广告数量限制
        /// </summary>
        [Column(Storage="_adcount", DbType="int")]
        [DisplayName("广告数量限制")]
        [Description("广告数量限制")]
        public Int32? adcount {
            get {
                return this._adcount;
            }
            set {
                if ((this._adcount != value)) {
                    this.OnadcountChanging(value);
                    this.SendPropertyChanging("adcount", value);
                    this._adcount = value;
                    this.SendPropertyChanged("adcount", value);
                    this.OnadcountChanged();
                }
            }
        }
        /// <summary>
        /// 店铺数量限制
        /// </summary>
        [Column(Storage="_shopcount", DbType="int")]
        [DisplayName("店铺数量限制")]
        [Description("店铺数量限制")]
        public Int32? shopcount {
            get {
                return this._shopcount;
            }
            set {
                if ((this._shopcount != value)) {
                    this.OnshopcountChanging(value);
                    this.SendPropertyChanging("shopcount", value);
                    this._shopcount = value;
                    this.SendPropertyChanged("shopcount", value);
                    this.OnshopcountChanged();
                }
            }
        }
        /// <summary>
        /// 品牌数量限制
        /// </summary>
        [Column(Storage="_brandcount", DbType="int")]
        [DisplayName("品牌数量限制")]
        [Description("品牌数量限制")]
        public Int32? brandcount {
            get {
                return this._brandcount;
            }
            set {
                if ((this._brandcount != value)) {
                    this.OnbrandcountChanging(value);
                    this.SendPropertyChanging("brandcount", value);
                    this._brandcount = value;
                    this.SendPropertyChanged("brandcount", value);
                    this.OnbrandcountChanged();
                }
            }
        }
        /// <summary>
        /// 促销信息数量限制
        /// </summary>
        [Column(Storage="_promotioncount", DbType="int")]
        [DisplayName("促销信息数量限制")]
        [Description("促销信息数量限制")]
        public Int32? promotioncount {
            get {
                return this._promotioncount;
            }
            set {
                if ((this._promotioncount != value)) {
                    this.OnpromotioncountChanging(value);
                    this.SendPropertyChanging("promotioncount", value);
                    this._promotioncount = value;
                    this.SendPropertyChanged("promotioncount", value);
                    this.OnpromotioncountChanged();
                }
            }
        }
        /// <summary>
        /// 推荐数量限制
        /// </summary>
        [Column(Storage="_storeycount", DbType="int")]
        [DisplayName("推荐数量限制")]
        [Description("推荐数量限制")]
        public Int32? storeycount {
            get {
                return this._storeycount;
            }
            set {
                if ((this._storeycount != value)) {
                    this.OnstoreycountChanging(value);
                    this.SendPropertyChanging("storeycount", value);
                    this._storeycount = value;
                    this.SendPropertyChanged("storeycount", value);
                    this.OnstoreycountChanged();
                }
            }
        }
        /// <summary>
        /// 推荐店铺数量限制
        /// </summary>
        [Column(Storage="_storeyshopcount", DbType="int")]
        [DisplayName("推荐店铺数量限制")]
        [Description("推荐店铺数量限制")]
        public Int32? storeyshopcount {
            get {
                return this._storeyshopcount;
            }
            set {
                if ((this._storeyshopcount != value)) {
                    this.OnstoreyshopcountChanging(value);
                    this.SendPropertyChanging("storeyshopcount", value);
                    this._storeyshopcount = value;
                    this.SendPropertyChanged("storeyshopcount", value);
                    this.OnstoreyshopcountChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_adrecommend", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? adrecommend {
            get {
                return this._adrecommend;
            }
            set {
                if ((this._adrecommend != value)) {
                    this.OnadrecommendChanging(value);
                    this.SendPropertyChanging("adrecommend", value);
                    this._adrecommend = value;
                    this.SendPropertyChanged("adrecommend", value);
                    this.OnadrecommendChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_shoprecommend", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? shoprecommend {
            get {
                return this._shoprecommend;
            }
            set {
                if ((this._shoprecommend != value)) {
                    this.OnshoprecommendChanging(value);
                    this.SendPropertyChanging("shoprecommend", value);
                    this._shoprecommend = value;
                    this.SendPropertyChanged("shoprecommend", value);
                    this.OnshoprecommendChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_brandrecommend", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? brandrecommend {
            get {
                return this._brandrecommend;
            }
            set {
                if ((this._brandrecommend != value)) {
                    this.OnbrandrecommendChanging(value);
                    this.SendPropertyChanging("brandrecommend", value);
                    this._brandrecommend = value;
                    this.SendPropertyChanged("brandrecommend", value);
                    this.OnbrandrecommendChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_promotionrecommend", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? promotionrecommend {
            get {
                return this._promotionrecommend;
            }
            set {
                if ((this._promotionrecommend != value)) {
                    this.OnpromotionrecommendChanging(value);
                    this.SendPropertyChanging("promotionrecommend", value);
                    this._promotionrecommend = value;
                    this.SendPropertyChanged("promotionrecommend", value);
                    this.OnpromotionrecommendChanged();
                }
            }
        }
        /// <summary>
        /// 级别
        /// </summary>
        [Column(Storage="_lev", DbType="int")]
        [DisplayName("级别")]
        [Description("级别")]
        public Int32? lev {
            get {
                return this._lev;
            }
            set {
                if ((this._lev != value)) {
                    this.OnlevChanging(value);
                    this.SendPropertyChanging("lev", value);
                    this._lev = value;
                    this.SendPropertyChanged("lev", value);
                    this.OnlevChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_permissions", DbType="ntext")]
        [DisplayName(" ")]
        [Description(" ")]
        public String permissions {
            get {
                return this._permissions;
            }
            set {
                if ((this._permissions != value)) {
                    this.OnpermissionsChanging(value);
                    this.SendPropertyChanging("permissions", value);
                    this._permissions = value;
                    this.SendPropertyChanged("permissions", value);
                    this.OnpermissionsChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(300)")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    /// 卖场楼层表
    /// </summary>
    [Table(Name="t_marketstorey")]
    [Serializable()]
    [DisplayName("卖场楼层表")]
    [Description("卖场楼层表")]
    public partial class Mmarketstorey : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 卖场ID
        /// </summary>
        Int32 _marketid;
        /// <summary>
        /// 卖场名称
        /// </summary>
        String _markettitle;
        /// <summary>
        /// 楼层名称
        /// </summary>
        String _title;
        /// <summary>
        /// 楼层序号ID
        /// </summary>
        String _number;
        /// <summary>
        /// 楼层图
        /// </summary>
        String _surface;
        /// <summary>
        /// LOGO
        /// </summary>
        String _logo;
        /// <summary>
        /// 缩略图
        /// </summary>
        String _thumb;
        /// <summary>
        /// 幻灯图
        /// </summary>
        String _bannel;
        /// <summary>
        /// 描述图
        /// </summary>
        String _desimage;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 关键字
        /// </summary>
        String _keywords;
        /// <summary>
        /// 模版ID
        /// </summary>
        String _template;
        /// <summary>
        /// 点击量
        /// </summary>
        Int32? _hits;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 最后修改人
        /// </summary>
        Int32? _lastedid;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 marketid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarketidChanging(Int32 value);
        /// <summary>
        /// 当 marketid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarketidChanged();
        /// <summary>
        /// 当 markettitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarkettitleChanging(String value);
        /// <summary>
        /// 当 markettitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarkettitleChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 number 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnnumberChanging(String value);
        /// <summary>
        /// 当 number 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnnumberChanged();
        /// <summary>
        /// 当 surface 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsurfaceChanging(String value);
        /// <summary>
        /// 当 surface 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsurfaceChanged();
        /// <summary>
        /// 当 logo 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlogoChanging(String value);
        /// <summary>
        /// 当 logo 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlogoChanged();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 bannel 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannelChanging(String value);
        /// <summary>
        /// 当 bannel 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannelChanged();
        /// <summary>
        /// 当 desimage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndesimageChanging(String value);
        /// <summary>
        /// 当 desimage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndesimageChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 keywords 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnkeywordsChanging(String value);
        /// <summary>
        /// 当 keywords 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnkeywordsChanged();
        /// <summary>
        /// 当 template 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntemplateChanging(String value);
        /// <summary>
        /// 当 template 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntemplateChanged();
        /// <summary>
        /// 当 hits 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhitsChanging(Int32? value);
        /// <summary>
        /// 当 hits 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhitsChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 lastedid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedidChanging(Int32? value);
        /// <summary>
        /// 当 lastedid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedidChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        
        /// <summary>
        /// 初始化 Mmarketstorey 实体类的新实例。
        /// </summary>
        public Mmarketstorey() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 卖场ID
        /// </summary>
        [Column(Storage="_marketid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("卖场ID")]
        [Description("卖场ID")]
        public Int32 marketid {
            get {
                return this._marketid;
            }
            set {
                this.OnmarketidChanging(value);
                this.SendPropertyChanging("marketid", value);
                this._marketid = value;
                this.SendPropertyChanged("marketid", value);
                this.OnmarketidChanged();
            }
        }
        /// <summary>
        /// 卖场名称
        /// </summary>
        [Column(Storage="_markettitle", DbType="nvarchar(50)")]
        [DisplayName("卖场名称")]
        [Description("卖场名称")]
        public String markettitle {
            get {
                return this._markettitle;
            }
            set {
                if ((this._markettitle != value)) {
                    this.OnmarkettitleChanging(value);
                    this.SendPropertyChanging("markettitle", value);
                    this._markettitle = value;
                    this.SendPropertyChanged("markettitle", value);
                    this.OnmarkettitleChanged();
                }
            }
        }
        /// <summary>
        /// 楼层名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("楼层名称")]
        [Description("楼层名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 楼层序号ID
        /// </summary>
        [Column(Storage="_number", DbType="nvarchar(20)")]
        [DisplayName("楼层序号ID")]
        [Description("楼层序号ID")]
        public String number {
            get {
                return this._number;
            }
            set {
                if ((this._number != value)) {
                    this.OnnumberChanging(value);
                    this.SendPropertyChanging("number", value);
                    this._number = value;
                    this.SendPropertyChanged("number", value);
                    this.OnnumberChanged();
                }
            }
        }
        /// <summary>
        /// 楼层图
        /// </summary>
        [Column(Storage="_surface", DbType="varchar(200)")]
        [DisplayName("楼层图")]
        [Description("楼层图")]
        public String surface {
            get {
                return this._surface;
            }
            set {
                if ((this._surface != value)) {
                    this.OnsurfaceChanging(value);
                    this.SendPropertyChanging("surface", value);
                    this._surface = value;
                    this.SendPropertyChanged("surface", value);
                    this.OnsurfaceChanged();
                }
            }
        }
        /// <summary>
        /// LOGO
        /// </summary>
        [Column(Storage="_logo", DbType="varchar(40)")]
        [DisplayName("LOGO")]
        [Description("LOGO")]
        public String logo {
            get {
                return this._logo;
            }
            set {
                if ((this._logo != value)) {
                    this.OnlogoChanging(value);
                    this.SendPropertyChanging("logo", value);
                    this._logo = value;
                    this.SendPropertyChanged("logo", value);
                    this.OnlogoChanged();
                }
            }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(40)")]
        [DisplayName("缩略图")]
        [Description("缩略图")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        /// 幻灯图
        /// </summary>
        [Column(Storage="_bannel", DbType="varchar(300)")]
        [DisplayName("幻灯图")]
        [Description("幻灯图")]
        public String bannel {
            get {
                return this._bannel;
            }
            set {
                if ((this._bannel != value)) {
                    this.OnbannelChanging(value);
                    this.SendPropertyChanging("bannel", value);
                    this._bannel = value;
                    this.SendPropertyChanged("bannel", value);
                    this.OnbannelChanged();
                }
            }
        }
        /// <summary>
        /// 描述图
        /// </summary>
        [Column(Storage="_desimage", DbType="varchar(400)")]
        [DisplayName("描述图")]
        [Description("描述图")]
        public String desimage {
            get {
                return this._desimage;
            }
            set {
                if ((this._desimage != value)) {
                    this.OndesimageChanging(value);
                    this.SendPropertyChanging("desimage", value);
                    this._desimage = value;
                    this.SendPropertyChanged("desimage", value);
                    this.OndesimageChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="ntext")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        [Column(Storage="_keywords", DbType="nvarchar(200)")]
        [DisplayName("关键字")]
        [Description("关键字")]
        public String keywords {
            get {
                return this._keywords;
            }
            set {
                if ((this._keywords != value)) {
                    this.OnkeywordsChanging(value);
                    this.SendPropertyChanging("keywords", value);
                    this._keywords = value;
                    this.SendPropertyChanged("keywords", value);
                    this.OnkeywordsChanged();
                }
            }
        }
        /// <summary>
        /// 模版ID
        /// </summary>
        [Column(Storage="_template", DbType="varchar(50)")]
        [DisplayName("模版ID")]
        [Description("模版ID")]
        public String template {
            get {
                return this._template;
            }
            set {
                if ((this._template != value)) {
                    this.OntemplateChanging(value);
                    this.SendPropertyChanging("template", value);
                    this._template = value;
                    this.SendPropertyChanged("template", value);
                    this.OntemplateChanged();
                }
            }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        [Column(Storage="_hits", DbType="int")]
        [DisplayName("点击量")]
        [Description("点击量")]
        public Int32? hits {
            get {
                return this._hits;
            }
            set {
                if ((this._hits != value)) {
                    this.OnhitsChanging(value);
                    this.SendPropertyChanging("hits", value);
                    this._hits = value;
                    this.SendPropertyChanged("hits", value);
                    this.OnhitsChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改人
        /// </summary>
        [Column(Storage="_lastedid", DbType="int")]
        [DisplayName("最后修改人")]
        [Description("最后修改人")]
        public Int32? lastedid {
            get {
                return this._lastedid;
            }
            set {
                if ((this._lastedid != value)) {
                    this.OnlastedidChanging(value);
                    this.SendPropertyChanging("lastedid", value);
                    this._lastedid = value;
                    this.SendPropertyChanged("lastedid", value);
                    this.OnlastedidChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最后修改时间")]
        [Description("最后修改时间")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
    }
    /// <summary>
    /// 卖场楼层店铺
    /// </summary>
    [Table(Name="t_marketstoreyshop")]
    [Serializable()]
    [DisplayName("卖场楼层店铺")]
    [Description("卖场楼层店铺")]
    public partial class Mmarketstoreyshop : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 卖场ID
        /// </summary>
        Int32 _marketid;
        /// <summary>
        /// 卖场名称
        /// </summary>
        String _markettitle;
        /// <summary>
        /// 楼层ID
        /// </summary>
        Int32 _storeyid;
        /// <summary>
        /// 楼层名称
        /// </summary>
        String _storeytitle;
        /// <summary>
        /// 店铺ID
        /// </summary>
        Int32 _shopid;
        /// <summary>
        /// 店铺名称
        /// </summary>
        String _shoptitle;
        /// <summary>
        /// 店铺品牌Idlist
        /// </summary>
        String _brandidlist;
        /// <summary>
        /// 店铺品牌标题list
        /// </summary>
        String _brandtitlelist;
        /// <summary>
        /// 是否置顶
        /// </summary>
        Int32? _istop;
        /// <summary>
        /// 是否推荐
        /// </summary>
        Int32? _isrecommend;
        /// <summary>
        /// 级别
        /// </summary>
        Int32? _lev;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 最后修改人
        /// </summary>
        Int32? _lastedid;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 marketid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarketidChanging(Int32 value);
        /// <summary>
        /// 当 marketid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarketidChanged();
        /// <summary>
        /// 当 markettitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarkettitleChanging(String value);
        /// <summary>
        /// 当 markettitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarkettitleChanged();
        /// <summary>
        /// 当 storeyid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstoreyidChanging(Int32 value);
        /// <summary>
        /// 当 storeyid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstoreyidChanged();
        /// <summary>
        /// 当 storeytitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstoreytitleChanging(String value);
        /// <summary>
        /// 当 storeytitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstoreytitleChanged();
        /// <summary>
        /// 当 shopid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshopidChanging(Int32 value);
        /// <summary>
        /// 当 shopid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshopidChanged();
        /// <summary>
        /// 当 shoptitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshoptitleChanging(String value);
        /// <summary>
        /// 当 shoptitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshoptitleChanged();
        /// <summary>
        /// 当 brandidlist 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandidlistChanging(String value);
        /// <summary>
        /// 当 brandidlist 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandidlistChanged();
        /// <summary>
        /// 当 brandtitlelist 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandtitlelistChanging(String value);
        /// <summary>
        /// 当 brandtitlelist 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandtitlelistChanged();
        /// <summary>
        /// 当 istop 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnistopChanging(Int32? value);
        /// <summary>
        /// 当 istop 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnistopChanged();
        /// <summary>
        /// 当 isrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnisrecommendChanging(Int32? value);
        /// <summary>
        /// 当 isrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnisrecommendChanged();
        /// <summary>
        /// 当 lev 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlevChanging(Int32? value);
        /// <summary>
        /// 当 lev 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlevChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 lastedid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedidChanging(Int32? value);
        /// <summary>
        /// 当 lastedid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedidChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        
        /// <summary>
        /// 初始化 Mmarketstoreyshop 实体类的新实例。
        /// </summary>
        public Mmarketstoreyshop() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 卖场ID
        /// </summary>
        [Column(Storage="_marketid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("卖场ID")]
        [Description("卖场ID")]
        public Int32 marketid {
            get {
                return this._marketid;
            }
            set {
                this.OnmarketidChanging(value);
                this.SendPropertyChanging("marketid", value);
                this._marketid = value;
                this.SendPropertyChanged("marketid", value);
                this.OnmarketidChanged();
            }
        }
        /// <summary>
        /// 卖场名称
        /// </summary>
        [Column(Storage="_markettitle", DbType="nvarchar(50)")]
        [DisplayName("卖场名称")]
        [Description("卖场名称")]
        public String markettitle {
            get {
                return this._markettitle;
            }
            set {
                if ((this._markettitle != value)) {
                    this.OnmarkettitleChanging(value);
                    this.SendPropertyChanging("markettitle", value);
                    this._markettitle = value;
                    this.SendPropertyChanged("markettitle", value);
                    this.OnmarkettitleChanged();
                }
            }
        }
        /// <summary>
        /// 楼层ID
        /// </summary>
        [Column(Storage="_storeyid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("楼层ID")]
        [Description("楼层ID")]
        public Int32 storeyid {
            get {
                return this._storeyid;
            }
            set {
                this.OnstoreyidChanging(value);
                this.SendPropertyChanging("storeyid", value);
                this._storeyid = value;
                this.SendPropertyChanged("storeyid", value);
                this.OnstoreyidChanged();
            }
        }
        /// <summary>
        /// 楼层名称
        /// </summary>
        [Column(Storage="_storeytitle", DbType="nvarchar(50)")]
        [DisplayName("楼层名称")]
        [Description("楼层名称")]
        public String storeytitle {
            get {
                return this._storeytitle;
            }
            set {
                if ((this._storeytitle != value)) {
                    this.OnstoreytitleChanging(value);
                    this.SendPropertyChanging("storeytitle", value);
                    this._storeytitle = value;
                    this.SendPropertyChanged("storeytitle", value);
                    this.OnstoreytitleChanged();
                }
            }
        }
        /// <summary>
        /// 店铺ID
        /// </summary>
        [Column(Storage="_shopid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("店铺ID")]
        [Description("店铺ID")]
        public Int32 shopid {
            get {
                return this._shopid;
            }
            set {
                this.OnshopidChanging(value);
                this.SendPropertyChanging("shopid", value);
                this._shopid = value;
                this.SendPropertyChanged("shopid", value);
                this.OnshopidChanged();
            }
        }
        /// <summary>
        /// 店铺名称
        /// </summary>
        [Column(Storage="_shoptitle", DbType="nvarchar(50)")]
        [DisplayName("店铺名称")]
        [Description("店铺名称")]
        public String shoptitle {
            get {
                return this._shoptitle;
            }
            set {
                if ((this._shoptitle != value)) {
                    this.OnshoptitleChanging(value);
                    this.SendPropertyChanging("shoptitle", value);
                    this._shoptitle = value;
                    this.SendPropertyChanged("shoptitle", value);
                    this.OnshoptitleChanged();
                }
            }
        }
        /// <summary>
        /// 店铺品牌Idlist
        /// </summary>
        [Column(Storage="_brandidlist", DbType="varchar(50)")]
        [DisplayName("店铺品牌Idlist")]
        [Description("店铺品牌Idlist")]
        public String brandidlist {
            get {
                return this._brandidlist;
            }
            set {
                if ((this._brandidlist != value)) {
                    this.OnbrandidlistChanging(value);
                    this.SendPropertyChanging("brandidlist", value);
                    this._brandidlist = value;
                    this.SendPropertyChanged("brandidlist", value);
                    this.OnbrandidlistChanged();
                }
            }
        }
        /// <summary>
        /// 店铺品牌标题list
        /// </summary>
        [Column(Storage="_brandtitlelist", DbType="nvarchar(200)")]
        [DisplayName("店铺品牌标题list")]
        [Description("店铺品牌标题list")]
        public String brandtitlelist {
            get {
                return this._brandtitlelist;
            }
            set {
                if ((this._brandtitlelist != value)) {
                    this.OnbrandtitlelistChanging(value);
                    this.SendPropertyChanging("brandtitlelist", value);
                    this._brandtitlelist = value;
                    this.SendPropertyChanged("brandtitlelist", value);
                    this.OnbrandtitlelistChanged();
                }
            }
        }
        /// <summary>
        /// 是否置顶
        /// </summary>
        [Column(Storage="_istop", DbType="int")]
        [DisplayName("是否置顶")]
        [Description("是否置顶")]
        public Int32? istop {
            get {
                return this._istop;
            }
            set {
                if ((this._istop != value)) {
                    this.OnistopChanging(value);
                    this.SendPropertyChanging("istop", value);
                    this._istop = value;
                    this.SendPropertyChanged("istop", value);
                    this.OnistopChanged();
                }
            }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        [Column(Storage="_isrecommend", DbType="int")]
        [DisplayName("是否推荐")]
        [Description("是否推荐")]
        public Int32? isrecommend {
            get {
                return this._isrecommend;
            }
            set {
                if ((this._isrecommend != value)) {
                    this.OnisrecommendChanging(value);
                    this.SendPropertyChanging("isrecommend", value);
                    this._isrecommend = value;
                    this.SendPropertyChanged("isrecommend", value);
                    this.OnisrecommendChanged();
                }
            }
        }
        /// <summary>
        /// 级别
        /// </summary>
        [Column(Storage="_lev", DbType="int")]
        [DisplayName("级别")]
        [Description("级别")]
        public Int32? lev {
            get {
                return this._lev;
            }
            set {
                if ((this._lev != value)) {
                    this.OnlevChanging(value);
                    this.SendPropertyChanging("lev", value);
                    this._lev = value;
                    this.SendPropertyChanged("lev", value);
                    this.OnlevChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改人
        /// </summary>
        [Column(Storage="_lastedid", DbType="int")]
        [DisplayName("最后修改人")]
        [Description("最后修改人")]
        public Int32? lastedid {
            get {
                return this._lastedid;
            }
            set {
                if ((this._lastedid != value)) {
                    this.OnlastedidChanging(value);
                    this.SendPropertyChanging("lastedid", value);
                    this._lastedid = value;
                    this.SendPropertyChanged("lastedid", value);
                    this.OnlastedidChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最后修改时间")]
        [Description("最后修改时间")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
    }
    /// <summary>
    /// 会员表
    /// </summary>
    [Table(Name="t_member")]
    [Serializable()]
    [DisplayName("会员表")]
    [Description("会员表")]
    public partial class Mmember : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 登陆账号
        /// </summary>
        String _username;
        /// <summary>
        /// 密码
        /// </summary>
        String _password;
        /// <summary>
        /// 支付密码
        /// </summary>
        String _paypassword;
        /// <summary>
        /// 通行证
        /// </summary>
        String _passport;
        /// <summary>
        /// 账号类型
        /// </summary>
        Int32 _type;
        /// <summary>
        /// 会员组ID
        /// </summary>
        Int32 _groupid;
        /// <summary>
        /// 提示音
        /// </summary>
        String _sound;
        /// <summary>
        /// 真实姓名
        /// </summary>
        String _tname;
        /// <summary>
        /// email
        /// </summary>
        String _email;
        /// <summary>
        /// 性别
        /// </summary>
        Int32? _gender;
        /// <summary>
        /// 手机
        /// </summary>
        String _mobile;
        /// <summary>
        /// 电话
        /// </summary>
        String _phone;
        /// <summary>
        /// Msn
        /// </summary>
        String _msn;
        /// <summary>
        /// QQ
        /// </summary>
        String _qq;
        /// <summary>
        /// Skype
        /// </summary>
        String _skype;
        /// <summary>
        /// Ali
        /// </summary>
        String _ali;
        /// <summary>
        /// 出生日期
        /// </summary>
        DateTime? _birthdate;
        /// <summary>
        /// 地区Code 
        /// </summary>
        String _areacode;
        /// <summary>
        /// 详细地址
        /// </summary>
        String _address;
        /// <summary>
        /// 部门
        /// </summary>
        String _department;
        /// <summary>
        /// 职位
        /// </summary>
        String _career;
        /// <summary>
        /// 短信余额
        /// </summary>
        Decimal? _sms;
        /// <summary>
        /// 积分
        /// </summary>
        Decimal? _integral;
        /// <summary>
        /// 资金金额
        /// </summary>
        Decimal? _money;
        /// <summary>
        /// 收款银行
        /// </summary>
        String _bank;
        /// <summary>
        /// 收款账号
        /// </summary>
        String _account;
        /// <summary>
        /// 支付宝账号
        /// </summary>
        String _alipay;
        /// <summary>
        /// 注册IP
        /// </summary>
        String _regip;
        /// <summary>
        /// 注册时间
        /// </summary>
        DateTime? _regtime;
        /// <summary>
        /// 最后登陆IP
        /// </summary>
        String _loginip;
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        DateTime? _logintime;
        /// <summary>
        /// 登陆次数
        /// </summary>
        Int32? _logincount;
        /// <summary>
        /// 授权认证(密钥)
        /// </summary>
        String _auth;
        /// <summary>
        /// 授权认证内容
        /// </summary>
        String _authvalue;
        /// <summary>
        /// 验证时间
        /// </summary>
        DateTime? _authtime;
        /// <summary>
        /// 邮箱认证
        /// </summary>
        Int32? _vemail;
        /// <summary>
        /// 手机认证
        /// </summary>
        Int32? _vmobile;
        /// <summary>
        /// 实名认证
        /// </summary>
        Int32? _vname;
        /// <summary>
        /// 验证银行
        /// </summary>
        Int32? _vbank;
        /// <summary>
        /// 验证公司
        /// </summary>
        Int32? _vcompany;
        /// <summary>
        /// 验证支付宝
        /// </summary>
        Int32? _valipay;
        /// <summary>
        /// 客服专员
        /// </summary>
        String _support;
        /// <summary>
        /// 推荐人(限定为用户名)
        /// </summary>
        String _inviter;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime? _lastedittime;
        /// <summary>
        /// 在线聊天
        /// </summary>
        Int32? _chat;
        /// <summary>
        /// 站内消息
        /// </summary>
        Int32? _message;
        /// <summary>
        /// 提问
        /// </summary>
        Int32? _question;
        /// <summary>
        /// 回答
        /// </summary>
        String _answer;
        /// <summary>
        /// 比价格
        /// </summary>
        Decimal? _overprice;
        /// <summary>
        /// 使用价格
        /// </summary>
        Decimal? _useprice;
        /// <summary>
        /// 是否补给
        /// </summary>
        Boolean? _Isrecharge;
        /// <summary>
        /// 开始时间
        /// </summary>
        DateTime? _RegStatcTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        DateTime? _RegEndTime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 username 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnusernameChanging(String value);
        /// <summary>
        /// 当 username 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnusernameChanged();
        /// <summary>
        /// 当 password 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpasswordChanging(String value);
        /// <summary>
        /// 当 password 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpasswordChanged();
        /// <summary>
        /// 当 paypassword 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpaypasswordChanging(String value);
        /// <summary>
        /// 当 paypassword 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpaypasswordChanged();
        /// <summary>
        /// 当 passport 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpassportChanging(String value);
        /// <summary>
        /// 当 passport 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpassportChanged();
        /// <summary>
        /// 当 type 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntypeChanging(Int32 value);
        /// <summary>
        /// 当 type 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntypeChanged();
        /// <summary>
        /// 当 groupid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OngroupidChanging(Int32 value);
        /// <summary>
        /// 当 groupid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OngroupidChanged();
        /// <summary>
        /// 当 sound 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsoundChanging(String value);
        /// <summary>
        /// 当 sound 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsoundChanged();
        /// <summary>
        /// 当 tname 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntnameChanging(String value);
        /// <summary>
        /// 当 tname 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntnameChanged();
        /// <summary>
        /// 当 email 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnemailChanging(String value);
        /// <summary>
        /// 当 email 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnemailChanged();
        /// <summary>
        /// 当 gender 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OngenderChanging(Int32? value);
        /// <summary>
        /// 当 gender 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OngenderChanged();
        /// <summary>
        /// 当 mobile 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmobileChanging(String value);
        /// <summary>
        /// 当 mobile 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmobileChanged();
        /// <summary>
        /// 当 phone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnphoneChanging(String value);
        /// <summary>
        /// 当 phone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnphoneChanged();
        /// <summary>
        /// 当 msn 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmsnChanging(String value);
        /// <summary>
        /// 当 msn 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmsnChanged();
        /// <summary>
        /// 当 qq 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnqqChanging(String value);
        /// <summary>
        /// 当 qq 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnqqChanged();
        /// <summary>
        /// 当 skype 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnskypeChanging(String value);
        /// <summary>
        /// 当 skype 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnskypeChanged();
        /// <summary>
        /// 当 ali 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaliChanging(String value);
        /// <summary>
        /// 当 ali 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaliChanged();
        /// <summary>
        /// 当 birthdate 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbirthdateChanging(DateTime? value);
        /// <summary>
        /// 当 birthdate 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbirthdateChanged();
        /// <summary>
        /// 当 areacode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnareacodeChanging(String value);
        /// <summary>
        /// 当 areacode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnareacodeChanged();
        /// <summary>
        /// 当 address 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaddressChanging(String value);
        /// <summary>
        /// 当 address 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaddressChanged();
        /// <summary>
        /// 当 department 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndepartmentChanging(String value);
        /// <summary>
        /// 当 department 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndepartmentChanged();
        /// <summary>
        /// 当 career 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncareerChanging(String value);
        /// <summary>
        /// 当 career 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncareerChanged();
        /// <summary>
        /// 当 sms 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsmsChanging(Decimal? value);
        /// <summary>
        /// 当 sms 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsmsChanged();
        /// <summary>
        /// 当 integral 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnintegralChanging(Decimal? value);
        /// <summary>
        /// 当 integral 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnintegralChanged();
        /// <summary>
        /// 当 money 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmoneyChanging(Decimal? value);
        /// <summary>
        /// 当 money 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmoneyChanged();
        /// <summary>
        /// 当 bank 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbankChanging(String value);
        /// <summary>
        /// 当 bank 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbankChanged();
        /// <summary>
        /// 当 account 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaccountChanging(String value);
        /// <summary>
        /// 当 account 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaccountChanged();
        /// <summary>
        /// 当 alipay 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnalipayChanging(String value);
        /// <summary>
        /// 当 alipay 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnalipayChanged();
        /// <summary>
        /// 当 regip 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnregipChanging(String value);
        /// <summary>
        /// 当 regip 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnregipChanged();
        /// <summary>
        /// 当 regtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnregtimeChanging(DateTime? value);
        /// <summary>
        /// 当 regtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnregtimeChanged();
        /// <summary>
        /// 当 loginip 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnloginipChanging(String value);
        /// <summary>
        /// 当 loginip 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnloginipChanged();
        /// <summary>
        /// 当 logintime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlogintimeChanging(DateTime? value);
        /// <summary>
        /// 当 logintime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlogintimeChanged();
        /// <summary>
        /// 当 logincount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlogincountChanging(Int32? value);
        /// <summary>
        /// 当 logincount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlogincountChanged();
        /// <summary>
        /// 当 auth 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauthChanging(String value);
        /// <summary>
        /// 当 auth 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauthChanged();
        /// <summary>
        /// 当 authvalue 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauthvalueChanging(String value);
        /// <summary>
        /// 当 authvalue 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauthvalueChanged();
        /// <summary>
        /// 当 authtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauthtimeChanging(DateTime? value);
        /// <summary>
        /// 当 authtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauthtimeChanged();
        /// <summary>
        /// 当 vemail 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvemailChanging(Int32? value);
        /// <summary>
        /// 当 vemail 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvemailChanged();
        /// <summary>
        /// 当 vmobile 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvmobileChanging(Int32? value);
        /// <summary>
        /// 当 vmobile 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvmobileChanged();
        /// <summary>
        /// 当 vname 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvnameChanging(Int32? value);
        /// <summary>
        /// 当 vname 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvnameChanged();
        /// <summary>
        /// 当 vbank 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvbankChanging(Int32? value);
        /// <summary>
        /// 当 vbank 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvbankChanged();
        /// <summary>
        /// 当 vcompany 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvcompanyChanging(Int32? value);
        /// <summary>
        /// 当 vcompany 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvcompanyChanged();
        /// <summary>
        /// 当 valipay 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvalipayChanging(Int32? value);
        /// <summary>
        /// 当 valipay 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvalipayChanged();
        /// <summary>
        /// 当 support 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsupportChanging(String value);
        /// <summary>
        /// 当 support 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsupportChanged();
        /// <summary>
        /// 当 inviter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OninviterChanging(String value);
        /// <summary>
        /// 当 inviter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OninviterChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime? value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        /// <summary>
        /// 当 chat 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnchatChanging(Int32? value);
        /// <summary>
        /// 当 chat 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnchatChanged();
        /// <summary>
        /// 当 message 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmessageChanging(Int32? value);
        /// <summary>
        /// 当 message 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmessageChanged();
        /// <summary>
        /// 当 question 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnquestionChanging(Int32? value);
        /// <summary>
        /// 当 question 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnquestionChanged();
        /// <summary>
        /// 当 answer 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnanswerChanging(String value);
        /// <summary>
        /// 当 answer 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnanswerChanged();
        /// <summary>
        /// 当 overprice 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnoverpriceChanging(Decimal? value);
        /// <summary>
        /// 当 overprice 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnoverpriceChanged();
        /// <summary>
        /// 当 useprice 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnusepriceChanging(Decimal? value);
        /// <summary>
        /// 当 useprice 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnusepriceChanged();
        /// <summary>
        /// 当 Isrecharge 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnIsrechargeChanging(Boolean? value);
        /// <summary>
        /// 当 Isrecharge 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnIsrechargeChanged();
        /// <summary>
        /// 当 RegStatcTime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnRegStatcTimeChanging(DateTime? value);
        /// <summary>
        /// 当 RegStatcTime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnRegStatcTimeChanged();
        /// <summary>
        /// 当 RegEndTime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnRegEndTimeChanging(DateTime? value);
        /// <summary>
        /// 当 RegEndTime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnRegEndTimeChanged();
        
        /// <summary>
        /// 初始化 Mmember 实体类的新实例。
        /// </summary>
        public Mmember() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 登陆账号
        /// </summary>
        [Column(Storage="_username", DbType="nvarchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName("登陆账号")]
        [Description("登陆账号")]
        public String username {
            get {
                return this._username;
            }
            set {
                this.OnusernameChanging(value);
                this.SendPropertyChanging("username", value);
                this._username = value;
                this.SendPropertyChanged("username", value);
                this.OnusernameChanged();
            }
        }
        /// <summary>
        /// 密码
        /// </summary>
        [Column(Storage="_password", DbType="varchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("密码")]
        [Description("密码")]
        public String password {
            get {
                return this._password;
            }
            set {
                this.OnpasswordChanging(value);
                this.SendPropertyChanging("password", value);
                this._password = value;
                this.SendPropertyChanged("password", value);
                this.OnpasswordChanged();
            }
        }
        /// <summary>
        /// 支付密码
        /// </summary>
        [Column(Storage="_paypassword", DbType="varchar(40)")]
        [DisplayName("支付密码")]
        [Description("支付密码")]
        public String paypassword {
            get {
                return this._paypassword;
            }
            set {
                if ((this._paypassword != value)) {
                    this.OnpaypasswordChanging(value);
                    this.SendPropertyChanging("paypassword", value);
                    this._paypassword = value;
                    this.SendPropertyChanged("paypassword", value);
                    this.OnpaypasswordChanged();
                }
            }
        }
        /// <summary>
        /// 通行证
        /// </summary>
        [Column(Storage="_passport", DbType="varchar(16)")]
        [DisplayName("通行证")]
        [Description("通行证")]
        public String passport {
            get {
                return this._passport;
            }
            set {
                if ((this._passport != value)) {
                    this.OnpassportChanging(value);
                    this.SendPropertyChanging("passport", value);
                    this._passport = value;
                    this.SendPropertyChanged("passport", value);
                    this.OnpassportChanged();
                }
            }
        }
        /// <summary>
        /// 账号类型
        /// </summary>
        [Column(Storage="_type", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("账号类型")]
        [Description("账号类型")]
        public Int32 type {
            get {
                return this._type;
            }
            set {
                this.OntypeChanging(value);
                this.SendPropertyChanging("type", value);
                this._type = value;
                this.SendPropertyChanged("type", value);
                this.OntypeChanged();
            }
        }
        /// <summary>
        /// 会员组ID
        /// </summary>
        [Column(Storage="_groupid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("会员组ID")]
        [Description("会员组ID")]
        public Int32 groupid {
            get {
                return this._groupid;
            }
            set {
                this.OngroupidChanging(value);
                this.SendPropertyChanging("groupid", value);
                this._groupid = value;
                this.SendPropertyChanged("groupid", value);
                this.OngroupidChanged();
            }
        }
        /// <summary>
        /// 提示音
        /// </summary>
        [Column(Storage="_sound", DbType="varchar(120)")]
        [DisplayName("提示音")]
        [Description("提示音")]
        public String sound {
            get {
                return this._sound;
            }
            set {
                if ((this._sound != value)) {
                    this.OnsoundChanging(value);
                    this.SendPropertyChanging("sound", value);
                    this._sound = value;
                    this.SendPropertyChanged("sound", value);
                    this.OnsoundChanged();
                }
            }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [Column(Storage="_tname", DbType="nvarchar(20)")]
        [DisplayName("真实姓名")]
        [Description("真实姓名")]
        public String tname {
            get {
                return this._tname;
            }
            set {
                if ((this._tname != value)) {
                    this.OntnameChanging(value);
                    this.SendPropertyChanging("tname", value);
                    this._tname = value;
                    this.SendPropertyChanged("tname", value);
                    this.OntnameChanged();
                }
            }
        }
        /// <summary>
        /// email
        /// </summary>
        [Column(Storage="_email", DbType="varchar(50)")]
        [DisplayName("email")]
        [Description("email")]
        public String email {
            get {
                return this._email;
            }
            set {
                if ((this._email != value)) {
                    this.OnemailChanging(value);
                    this.SendPropertyChanging("email", value);
                    this._email = value;
                    this.SendPropertyChanged("email", value);
                    this.OnemailChanged();
                }
            }
        }
        /// <summary>
        /// 性别
        /// </summary>
        [Column(Storage="_gender", DbType="int")]
        [DisplayName("性别")]
        [Description("性别")]
        public Int32? gender {
            get {
                return this._gender;
            }
            set {
                if ((this._gender != value)) {
                    this.OngenderChanging(value);
                    this.SendPropertyChanging("gender", value);
                    this._gender = value;
                    this.SendPropertyChanged("gender", value);
                    this.OngenderChanged();
                }
            }
        }
        /// <summary>
        /// 手机
        /// </summary>
        [Column(Storage="_mobile", DbType="varchar(20)")]
        [DisplayName("手机")]
        [Description("手机")]
        public String mobile {
            get {
                return this._mobile;
            }
            set {
                if ((this._mobile != value)) {
                    this.OnmobileChanging(value);
                    this.SendPropertyChanging("mobile", value);
                    this._mobile = value;
                    this.SendPropertyChanged("mobile", value);
                    this.OnmobileChanged();
                }
            }
        }
        /// <summary>
        /// 电话
        /// </summary>
        [Column(Storage="_phone", DbType="varchar(20)")]
        [DisplayName("电话")]
        [Description("电话")]
        public String phone {
            get {
                return this._phone;
            }
            set {
                if ((this._phone != value)) {
                    this.OnphoneChanging(value);
                    this.SendPropertyChanging("phone", value);
                    this._phone = value;
                    this.SendPropertyChanged("phone", value);
                    this.OnphoneChanged();
                }
            }
        }
        /// <summary>
        /// Msn
        /// </summary>
        [Column(Storage="_msn", DbType="nvarchar(50)")]
        [DisplayName("Msn")]
        [Description("Msn")]
        public String msn {
            get {
                return this._msn;
            }
            set {
                if ((this._msn != value)) {
                    this.OnmsnChanging(value);
                    this.SendPropertyChanging("msn", value);
                    this._msn = value;
                    this.SendPropertyChanged("msn", value);
                    this.OnmsnChanged();
                }
            }
        }
        /// <summary>
        /// QQ
        /// </summary>
        [Column(Storage="_qq", DbType="nvarchar(50)")]
        [DisplayName("QQ")]
        [Description("QQ")]
        public String qq {
            get {
                return this._qq;
            }
            set {
                if ((this._qq != value)) {
                    this.OnqqChanging(value);
                    this.SendPropertyChanging("qq", value);
                    this._qq = value;
                    this.SendPropertyChanged("qq", value);
                    this.OnqqChanged();
                }
            }
        }
        /// <summary>
        /// Skype
        /// </summary>
        [Column(Storage="_skype", DbType="nvarchar(50)")]
        [DisplayName("Skype")]
        [Description("Skype")]
        public String skype {
            get {
                return this._skype;
            }
            set {
                if ((this._skype != value)) {
                    this.OnskypeChanging(value);
                    this.SendPropertyChanging("skype", value);
                    this._skype = value;
                    this.SendPropertyChanged("skype", value);
                    this.OnskypeChanged();
                }
            }
        }
        /// <summary>
        /// Ali
        /// </summary>
        [Column(Storage="_ali", DbType="nvarchar(50)")]
        [DisplayName("Ali")]
        [Description("Ali")]
        public String ali {
            get {
                return this._ali;
            }
            set {
                if ((this._ali != value)) {
                    this.OnaliChanging(value);
                    this.SendPropertyChanging("ali", value);
                    this._ali = value;
                    this.SendPropertyChanged("ali", value);
                    this.OnaliChanged();
                }
            }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        [Column(Storage="_birthdate", DbType="datetime")]
        [DisplayName("出生日期")]
        [Description("出生日期")]
        public DateTime? birthdate {
            get {
                return this._birthdate;
            }
            set {
                if ((this._birthdate != value)) {
                    this.OnbirthdateChanging(value);
                    this.SendPropertyChanging("birthdate", value);
                    this._birthdate = value;
                    this.SendPropertyChanged("birthdate", value);
                    this.OnbirthdateChanged();
                }
            }
        }
        /// <summary>
        /// 地区Code 
        /// </summary>
        [Column(Storage="_areacode", DbType="varchar(10)")]
        [DisplayName("地区Code")]
        [Description("地区Code ")]
        public String areacode {
            get {
                return this._areacode;
            }
            set {
                if ((this._areacode != value)) {
                    this.OnareacodeChanging(value);
                    this.SendPropertyChanging("areacode", value);
                    this._areacode = value;
                    this.SendPropertyChanged("areacode", value);
                    this.OnareacodeChanged();
                }
            }
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        [Column(Storage="_address", DbType="nvarchar(120)")]
        [DisplayName("详细地址")]
        [Description("详细地址")]
        public String address {
            get {
                return this._address;
            }
            set {
                if ((this._address != value)) {
                    this.OnaddressChanging(value);
                    this.SendPropertyChanging("address", value);
                    this._address = value;
                    this.SendPropertyChanged("address", value);
                    this.OnaddressChanged();
                }
            }
        }
        /// <summary>
        /// 部门
        /// </summary>
        [Column(Storage="_department", DbType="nvarchar(20)")]
        [DisplayName("部门")]
        [Description("部门")]
        public String department {
            get {
                return this._department;
            }
            set {
                if ((this._department != value)) {
                    this.OndepartmentChanging(value);
                    this.SendPropertyChanging("department", value);
                    this._department = value;
                    this.SendPropertyChanged("department", value);
                    this.OndepartmentChanged();
                }
            }
        }
        /// <summary>
        /// 职位
        /// </summary>
        [Column(Storage="_career", DbType="nvarchar(20)")]
        [DisplayName("职位")]
        [Description("职位")]
        public String career {
            get {
                return this._career;
            }
            set {
                if ((this._career != value)) {
                    this.OncareerChanging(value);
                    this.SendPropertyChanging("career", value);
                    this._career = value;
                    this.SendPropertyChanged("career", value);
                    this.OncareerChanged();
                }
            }
        }
        /// <summary>
        /// 短信余额
        /// </summary>
        [Column(Storage="_sms", DbType="decimal")]
        [DisplayName("短信余额")]
        [Description("短信余额")]
        public Decimal? sms {
            get {
                return this._sms;
            }
            set {
                if ((this._sms != value)) {
                    this.OnsmsChanging(value);
                    this.SendPropertyChanging("sms", value);
                    this._sms = value;
                    this.SendPropertyChanged("sms", value);
                    this.OnsmsChanged();
                }
            }
        }
        /// <summary>
        /// 积分
        /// </summary>
        [Column(Storage="_integral", DbType="decimal")]
        [DisplayName("积分")]
        [Description("积分")]
        public Decimal? integral {
            get {
                return this._integral;
            }
            set {
                if ((this._integral != value)) {
                    this.OnintegralChanging(value);
                    this.SendPropertyChanging("integral", value);
                    this._integral = value;
                    this.SendPropertyChanged("integral", value);
                    this.OnintegralChanged();
                }
            }
        }
        /// <summary>
        /// 资金金额
        /// </summary>
        [Column(Storage="_money", DbType="decimal")]
        [DisplayName("资金金额")]
        [Description("资金金额")]
        public Decimal? money {
            get {
                return this._money;
            }
            set {
                if ((this._money != value)) {
                    this.OnmoneyChanging(value);
                    this.SendPropertyChanging("money", value);
                    this._money = value;
                    this.SendPropertyChanged("money", value);
                    this.OnmoneyChanged();
                }
            }
        }
        /// <summary>
        /// 收款银行
        /// </summary>
        [Column(Storage="_bank", DbType="nvarchar(50)")]
        [DisplayName("收款银行")]
        [Description("收款银行")]
        public String bank {
            get {
                return this._bank;
            }
            set {
                if ((this._bank != value)) {
                    this.OnbankChanging(value);
                    this.SendPropertyChanging("bank", value);
                    this._bank = value;
                    this.SendPropertyChanged("bank", value);
                    this.OnbankChanged();
                }
            }
        }
        /// <summary>
        /// 收款账号
        /// </summary>
        [Column(Storage="_account", DbType="nvarchar(50)")]
        [DisplayName("收款账号")]
        [Description("收款账号")]
        public String account {
            get {
                return this._account;
            }
            set {
                if ((this._account != value)) {
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging("account", value);
                    this._account = value;
                    this.SendPropertyChanged("account", value);
                    this.OnaccountChanged();
                }
            }
        }
        /// <summary>
        /// 支付宝账号
        /// </summary>
        [Column(Storage="_alipay", DbType="nvarchar(50)")]
        [DisplayName("支付宝账号")]
        [Description("支付宝账号")]
        public String alipay {
            get {
                return this._alipay;
            }
            set {
                if ((this._alipay != value)) {
                    this.OnalipayChanging(value);
                    this.SendPropertyChanging("alipay", value);
                    this._alipay = value;
                    this.SendPropertyChanged("alipay", value);
                    this.OnalipayChanged();
                }
            }
        }
        /// <summary>
        /// 注册IP
        /// </summary>
        [Column(Storage="_regip", DbType="varchar(50)")]
        [DisplayName("注册IP")]
        [Description("注册IP")]
        public String regip {
            get {
                return this._regip;
            }
            set {
                if ((this._regip != value)) {
                    this.OnregipChanging(value);
                    this.SendPropertyChanging("regip", value);
                    this._regip = value;
                    this.SendPropertyChanged("regip", value);
                    this.OnregipChanged();
                }
            }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        [Column(Storage="_regtime", DbType="datetime")]
        [DisplayName("注册时间")]
        [Description("注册时间")]
        public DateTime? regtime {
            get {
                return this._regtime;
            }
            set {
                if ((this._regtime != value)) {
                    this.OnregtimeChanging(value);
                    this.SendPropertyChanging("regtime", value);
                    this._regtime = value;
                    this.SendPropertyChanged("regtime", value);
                    this.OnregtimeChanged();
                }
            }
        }
        /// <summary>
        /// 最后登陆IP
        /// </summary>
        [Column(Storage="_loginip", DbType="varchar(50)")]
        [DisplayName("最后登陆IP")]
        [Description("最后登陆IP")]
        public String loginip {
            get {
                return this._loginip;
            }
            set {
                if ((this._loginip != value)) {
                    this.OnloginipChanging(value);
                    this.SendPropertyChanging("loginip", value);
                    this._loginip = value;
                    this.SendPropertyChanged("loginip", value);
                    this.OnloginipChanged();
                }
            }
        }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        [Column(Storage="_logintime", DbType="datetime")]
        [DisplayName("最后登陆时间")]
        [Description("最后登陆时间")]
        public DateTime? logintime {
            get {
                return this._logintime;
            }
            set {
                if ((this._logintime != value)) {
                    this.OnlogintimeChanging(value);
                    this.SendPropertyChanging("logintime", value);
                    this._logintime = value;
                    this.SendPropertyChanged("logintime", value);
                    this.OnlogintimeChanged();
                }
            }
        }
        /// <summary>
        /// 登陆次数
        /// </summary>
        [Column(Storage="_logincount", DbType="int")]
        [DisplayName("登陆次数")]
        [Description("登陆次数")]
        public Int32? logincount {
            get {
                return this._logincount;
            }
            set {
                if ((this._logincount != value)) {
                    this.OnlogincountChanging(value);
                    this.SendPropertyChanging("logincount", value);
                    this._logincount = value;
                    this.SendPropertyChanged("logincount", value);
                    this.OnlogincountChanged();
                }
            }
        }
        /// <summary>
        /// 授权认证(密钥)
        /// </summary>
        [Column(Storage="_auth", DbType="varchar(32)")]
        [DisplayName("授权认证(密钥)")]
        [Description("授权认证(密钥)")]
        public String auth {
            get {
                return this._auth;
            }
            set {
                if ((this._auth != value)) {
                    this.OnauthChanging(value);
                    this.SendPropertyChanging("auth", value);
                    this._auth = value;
                    this.SendPropertyChanged("auth", value);
                    this.OnauthChanged();
                }
            }
        }
        /// <summary>
        /// 授权认证内容
        /// </summary>
        [Column(Storage="_authvalue", DbType="nvarchar(100)")]
        [DisplayName("授权认证内容")]
        [Description("授权认证内容")]
        public String authvalue {
            get {
                return this._authvalue;
            }
            set {
                if ((this._authvalue != value)) {
                    this.OnauthvalueChanging(value);
                    this.SendPropertyChanging("authvalue", value);
                    this._authvalue = value;
                    this.SendPropertyChanged("authvalue", value);
                    this.OnauthvalueChanged();
                }
            }
        }
        /// <summary>
        /// 验证时间
        /// </summary>
        [Column(Storage="_authtime", DbType="datetime")]
        [DisplayName("验证时间")]
        [Description("验证时间")]
        public DateTime? authtime {
            get {
                return this._authtime;
            }
            set {
                if ((this._authtime != value)) {
                    this.OnauthtimeChanging(value);
                    this.SendPropertyChanging("authtime", value);
                    this._authtime = value;
                    this.SendPropertyChanged("authtime", value);
                    this.OnauthtimeChanged();
                }
            }
        }
        /// <summary>
        /// 邮箱认证
        /// </summary>
        [Column(Storage="_vemail", DbType="int")]
        [DisplayName("邮箱认证")]
        [Description("邮箱认证")]
        public Int32? vemail {
            get {
                return this._vemail;
            }
            set {
                if ((this._vemail != value)) {
                    this.OnvemailChanging(value);
                    this.SendPropertyChanging("vemail", value);
                    this._vemail = value;
                    this.SendPropertyChanged("vemail", value);
                    this.OnvemailChanged();
                }
            }
        }
        /// <summary>
        /// 手机认证
        /// </summary>
        [Column(Storage="_vmobile", DbType="int")]
        [DisplayName("手机认证")]
        [Description("手机认证")]
        public Int32? vmobile {
            get {
                return this._vmobile;
            }
            set {
                if ((this._vmobile != value)) {
                    this.OnvmobileChanging(value);
                    this.SendPropertyChanging("vmobile", value);
                    this._vmobile = value;
                    this.SendPropertyChanged("vmobile", value);
                    this.OnvmobileChanged();
                }
            }
        }
        /// <summary>
        /// 实名认证
        /// </summary>
        [Column(Storage="_vname", DbType="int")]
        [DisplayName("实名认证")]
        [Description("实名认证")]
        public Int32? vname {
            get {
                return this._vname;
            }
            set {
                if ((this._vname != value)) {
                    this.OnvnameChanging(value);
                    this.SendPropertyChanging("vname", value);
                    this._vname = value;
                    this.SendPropertyChanged("vname", value);
                    this.OnvnameChanged();
                }
            }
        }
        /// <summary>
        /// 验证银行
        /// </summary>
        [Column(Storage="_vbank", DbType="int")]
        [DisplayName("验证银行")]
        [Description("验证银行")]
        public Int32? vbank {
            get {
                return this._vbank;
            }
            set {
                if ((this._vbank != value)) {
                    this.OnvbankChanging(value);
                    this.SendPropertyChanging("vbank", value);
                    this._vbank = value;
                    this.SendPropertyChanged("vbank", value);
                    this.OnvbankChanged();
                }
            }
        }
        /// <summary>
        /// 验证公司
        /// </summary>
        [Column(Storage="_vcompany", DbType="int")]
        [DisplayName("验证公司")]
        [Description("验证公司")]
        public Int32? vcompany {
            get {
                return this._vcompany;
            }
            set {
                if ((this._vcompany != value)) {
                    this.OnvcompanyChanging(value);
                    this.SendPropertyChanging("vcompany", value);
                    this._vcompany = value;
                    this.SendPropertyChanged("vcompany", value);
                    this.OnvcompanyChanged();
                }
            }
        }
        /// <summary>
        /// 验证支付宝
        /// </summary>
        [Column(Storage="_valipay", DbType="int")]
        [DisplayName("验证支付宝")]
        [Description("验证支付宝")]
        public Int32? valipay {
            get {
                return this._valipay;
            }
            set {
                if ((this._valipay != value)) {
                    this.OnvalipayChanging(value);
                    this.SendPropertyChanging("valipay", value);
                    this._valipay = value;
                    this.SendPropertyChanged("valipay", value);
                    this.OnvalipayChanged();
                }
            }
        }
        /// <summary>
        /// 客服专员
        /// </summary>
        [Column(Storage="_support", DbType="nvarchar(500)")]
        [DisplayName("客服专员")]
        [Description("客服专员")]
        public String support {
            get {
                return this._support;
            }
            set {
                if ((this._support != value)) {
                    this.OnsupportChanging(value);
                    this.SendPropertyChanging("support", value);
                    this._support = value;
                    this.SendPropertyChanged("support", value);
                    this.OnsupportChanged();
                }
            }
        }
        /// <summary>
        /// 推荐人(限定为用户名)
        /// </summary>
        [Column(Storage="_inviter", DbType="nvarchar(20)")]
        [DisplayName("推荐人(限定为用户名)")]
        [Description("推荐人(限定为用户名)")]
        public String inviter {
            get {
                return this._inviter;
            }
            set {
                if ((this._inviter != value)) {
                    this.OninviterChanging(value);
                    this.SendPropertyChanging("inviter", value);
                    this._inviter = value;
                    this.SendPropertyChanged("inviter", value);
                    this.OninviterChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime")]
        [DisplayName("最后修改时间")]
        [Description("最后修改时间")]
        public DateTime? lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                if ((this._lastedittime != value)) {
                    this.OnlastedittimeChanging(value);
                    this.SendPropertyChanging("lastedittime", value);
                    this._lastedittime = value;
                    this.SendPropertyChanged("lastedittime", value);
                    this.OnlastedittimeChanged();
                }
            }
        }
        /// <summary>
        /// 在线聊天
        /// </summary>
        [Column(Storage="_chat", DbType="int")]
        [DisplayName("在线聊天")]
        [Description("在线聊天")]
        public Int32? chat {
            get {
                return this._chat;
            }
            set {
                if ((this._chat != value)) {
                    this.OnchatChanging(value);
                    this.SendPropertyChanging("chat", value);
                    this._chat = value;
                    this.SendPropertyChanged("chat", value);
                    this.OnchatChanged();
                }
            }
        }
        /// <summary>
        /// 站内消息
        /// </summary>
        [Column(Storage="_message", DbType="int")]
        [DisplayName("站内消息")]
        [Description("站内消息")]
        public Int32? message {
            get {
                return this._message;
            }
            set {
                if ((this._message != value)) {
                    this.OnmessageChanging(value);
                    this.SendPropertyChanging("message", value);
                    this._message = value;
                    this.SendPropertyChanged("message", value);
                    this.OnmessageChanged();
                }
            }
        }
        /// <summary>
        /// 提问
        /// </summary>
        [Column(Storage="_question", DbType="int")]
        [DisplayName("提问")]
        [Description("提问")]
        public Int32? question {
            get {
                return this._question;
            }
            set {
                if ((this._question != value)) {
                    this.OnquestionChanging(value);
                    this.SendPropertyChanging("question", value);
                    this._question = value;
                    this.SendPropertyChanged("question", value);
                    this.OnquestionChanged();
                }
            }
        }
        /// <summary>
        /// 回答
        /// </summary>
        [Column(Storage="_answer", DbType="varchar(100)")]
        [DisplayName("回答")]
        [Description("回答")]
        public String answer {
            get {
                return this._answer;
            }
            set {
                if ((this._answer != value)) {
                    this.OnanswerChanging(value);
                    this.SendPropertyChanging("answer", value);
                    this._answer = value;
                    this.SendPropertyChanged("answer", value);
                    this.OnanswerChanged();
                }
            }
        }
        /// <summary>
        /// 比价格
        /// </summary>
        [Column(Storage="_overprice", DbType="decimal")]
        [DisplayName("比价格")]
        [Description("比价格")]
        public Decimal? overprice {
            get {
                return this._overprice;
            }
            set {
                if ((this._overprice != value)) {
                    this.OnoverpriceChanging(value);
                    this.SendPropertyChanging("overprice", value);
                    this._overprice = value;
                    this.SendPropertyChanged("overprice", value);
                    this.OnoverpriceChanged();
                }
            }
        }
        /// <summary>
        /// 使用价格
        /// </summary>
        [Column(Storage="_useprice", DbType="decimal")]
        [DisplayName("使用价格")]
        [Description("使用价格")]
        public Decimal? useprice {
            get {
                return this._useprice;
            }
            set {
                if ((this._useprice != value)) {
                    this.OnusepriceChanging(value);
                    this.SendPropertyChanging("useprice", value);
                    this._useprice = value;
                    this.SendPropertyChanged("useprice", value);
                    this.OnusepriceChanged();
                }
            }
        }
        /// <summary>
        /// 是否补给
        /// </summary>
        [Column(Storage="_Isrecharge", DbType="bit")]
        [DisplayName("是否补给")]
        [Description("是否补给")]
        public Boolean? Isrecharge {
            get {
                return this._Isrecharge;
            }
            set {
                if ((this._Isrecharge != value)) {
                    this.OnIsrechargeChanging(value);
                    this.SendPropertyChanging("Isrecharge", value);
                    this._Isrecharge = value;
                    this.SendPropertyChanged("Isrecharge", value);
                    this.OnIsrechargeChanged();
                }
            }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Column(Storage="_RegStatcTime", DbType="datetime")]
        [DisplayName("开始时间")]
        [Description("开始时间")]
        public DateTime? RegStatcTime {
            get {
                return this._RegStatcTime;
            }
            set {
                if ((this._RegStatcTime != value)) {
                    this.OnRegStatcTimeChanging(value);
                    this.SendPropertyChanging("RegStatcTime", value);
                    this._RegStatcTime = value;
                    this.SendPropertyChanged("RegStatcTime", value);
                    this.OnRegStatcTimeChanged();
                }
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Column(Storage="_RegEndTime", DbType="datetime")]
        [DisplayName("结束时间")]
        [Description("结束时间")]
        public DateTime? RegEndTime {
            get {
                return this._RegEndTime;
            }
            set {
                if ((this._RegEndTime != value)) {
                    this.OnRegEndTimeChanging(value);
                    this.SendPropertyChanging("RegEndTime", value);
                    this._RegEndTime = value;
                    this.SendPropertyChanged("RegEndTime", value);
                    this.OnRegEndTimeChanged();
                }
            }
        }
    }
    /// <summary>
    /// 会员组表
    /// </summary>
    [Table(Name="t_membergroup")]
    [Serializable()]
    [DisplayName("会员组表")]
    [Description("会员组表")]
    public partial class Mmembergroup : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 颜色
        /// </summary>
        String _color;
        /// <summary>
        /// 标志图片
        /// </summary>
        String _avatar;
        /// <summary>
        /// 积分达至
        /// </summary>
        Decimal? _integral;
        /// <summary>
        /// 金额达到
        /// </summary>
        Decimal? _money;
        /// <summary>
        /// 权限
        /// </summary>
        String _permissions;
        /// <summary>
        /// 级别
        /// </summary>
        Int32? _lev;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 color 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncolorChanging(String value);
        /// <summary>
        /// 当 color 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncolorChanged();
        /// <summary>
        /// 当 avatar 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnavatarChanging(String value);
        /// <summary>
        /// 当 avatar 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnavatarChanged();
        /// <summary>
        /// 当 integral 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnintegralChanging(Decimal? value);
        /// <summary>
        /// 当 integral 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnintegralChanged();
        /// <summary>
        /// 当 money 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmoneyChanging(Decimal? value);
        /// <summary>
        /// 当 money 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmoneyChanged();
        /// <summary>
        /// 当 permissions 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpermissionsChanging(String value);
        /// <summary>
        /// 当 permissions 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpermissionsChanged();
        /// <summary>
        /// 当 lev 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlevChanging(Int32? value);
        /// <summary>
        /// 当 lev 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlevChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Mmembergroup 实体类的新实例。
        /// </summary>
        public Mmembergroup() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(30) NOT NULL", CanBeNull=false)]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 颜色
        /// </summary>
        [Column(Storage="_color", DbType="char(7)")]
        [DisplayName("颜色")]
        [Description("颜色")]
        public String color {
            get {
                return this._color;
            }
            set {
                if ((this._color != value)) {
                    this.OncolorChanging(value);
                    this.SendPropertyChanging("color", value);
                    this._color = value;
                    this.SendPropertyChanged("color", value);
                    this.OncolorChanged();
                }
            }
        }
        /// <summary>
        /// 标志图片
        /// </summary>
        [Column(Storage="_avatar", DbType="varchar(40)")]
        [DisplayName("标志图片")]
        [Description("标志图片")]
        public String avatar {
            get {
                return this._avatar;
            }
            set {
                if ((this._avatar != value)) {
                    this.OnavatarChanging(value);
                    this.SendPropertyChanging("avatar", value);
                    this._avatar = value;
                    this.SendPropertyChanged("avatar", value);
                    this.OnavatarChanged();
                }
            }
        }
        /// <summary>
        /// 积分达至
        /// </summary>
        [Column(Storage="_integral", DbType="decimal")]
        [DisplayName("积分达至")]
        [Description("积分达至")]
        public Decimal? integral {
            get {
                return this._integral;
            }
            set {
                if ((this._integral != value)) {
                    this.OnintegralChanging(value);
                    this.SendPropertyChanging("integral", value);
                    this._integral = value;
                    this.SendPropertyChanged("integral", value);
                    this.OnintegralChanged();
                }
            }
        }
        /// <summary>
        /// 金额达到
        /// </summary>
        [Column(Storage="_money", DbType="decimal")]
        [DisplayName("金额达到")]
        [Description("金额达到")]
        public Decimal? money {
            get {
                return this._money;
            }
            set {
                if ((this._money != value)) {
                    this.OnmoneyChanging(value);
                    this.SendPropertyChanging("money", value);
                    this._money = value;
                    this.SendPropertyChanged("money", value);
                    this.OnmoneyChanged();
                }
            }
        }
        /// <summary>
        /// 权限
        /// </summary>
        [Column(Storage="_permissions", DbType="ntext")]
        [DisplayName("权限")]
        [Description("权限")]
        public String permissions {
            get {
                return this._permissions;
            }
            set {
                if ((this._permissions != value)) {
                    this.OnpermissionsChanging(value);
                    this.SendPropertyChanging("permissions", value);
                    this._permissions = value;
                    this.SendPropertyChanged("permissions", value);
                    this.OnpermissionsChanged();
                }
            }
        }
        /// <summary>
        /// 级别
        /// </summary>
        [Column(Storage="_lev", DbType="int")]
        [DisplayName("级别")]
        [Description("级别")]
        public Int32? lev {
            get {
                return this._lev;
            }
            set {
                if ((this._lev != value)) {
                    this.OnlevChanging(value);
                    this.SendPropertyChanging("lev", value);
                    this._lev = value;
                    this.SendPropertyChanged("lev", value);
                    this.OnlevChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(300)")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    /// 菜单表
    /// </summary>
    [Table(Name="t_menu")]
    [Serializable()]
    [DisplayName("菜单表")]
    [Description("菜单表")]
    public partial class Mmenu : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 类型
        /// </summary>
        String _type;
        /// <summary>
        /// 标识
        /// </summary>
        String _mark;
        /// <summary>
        /// 上级
        /// </summary>
        Int32? _parent;
        /// <summary>
        /// 级别
        /// </summary>
        Int32? _lev;
        /// <summary>
        /// 路径
        /// </summary>
        String _path;
        /// <summary>
        /// 连接
        /// </summary>
        String _url;
        /// <summary>
        /// 模块
        /// </summary>
        Int32? _module;
        /// <summary>
        /// 权限
        /// </summary>
        Int32? _action;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 type 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntypeChanging(String value);
        /// <summary>
        /// 当 type 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntypeChanged();
        /// <summary>
        /// 当 mark 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarkChanging(String value);
        /// <summary>
        /// 当 mark 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarkChanged();
        /// <summary>
        /// 当 parent 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnparentChanging(Int32? value);
        /// <summary>
        /// 当 parent 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnparentChanged();
        /// <summary>
        /// 当 lev 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlevChanging(Int32? value);
        /// <summary>
        /// 当 lev 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlevChanged();
        /// <summary>
        /// 当 path 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpathChanging(String value);
        /// <summary>
        /// 当 path 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpathChanged();
        /// <summary>
        /// 当 url 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnurlChanging(String value);
        /// <summary>
        /// 当 url 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnurlChanged();
        /// <summary>
        /// 当 module 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmoduleChanging(Int32? value);
        /// <summary>
        /// 当 module 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmoduleChanged();
        /// <summary>
        /// 当 action 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnactionChanging(Int32? value);
        /// <summary>
        /// 当 action 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnactionChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Mmenu 实体类的新实例。
        /// </summary>
        public Mmenu() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 类型
        /// </summary>
        [Column(Storage="_type", DbType="varchar(50)")]
        [DisplayName("类型")]
        [Description("类型")]
        public String type {
            get {
                return this._type;
            }
            set {
                if ((this._type != value)) {
                    this.OntypeChanging(value);
                    this.SendPropertyChanging("type", value);
                    this._type = value;
                    this.SendPropertyChanged("type", value);
                    this.OntypeChanged();
                }
            }
        }
        /// <summary>
        /// 标识
        /// </summary>
        [Column(Storage="_mark", DbType="varchar(50)")]
        [DisplayName("标识")]
        [Description("标识")]
        public String mark {
            get {
                return this._mark;
            }
            set {
                if ((this._mark != value)) {
                    this.OnmarkChanging(value);
                    this.SendPropertyChanging("mark", value);
                    this._mark = value;
                    this.SendPropertyChanged("mark", value);
                    this.OnmarkChanged();
                }
            }
        }
        /// <summary>
        /// 上级
        /// </summary>
        [Column(Storage="_parent", DbType="int")]
        [DisplayName("上级")]
        [Description("上级")]
        public Int32? parent {
            get {
                return this._parent;
            }
            set {
                if ((this._parent != value)) {
                    this.OnparentChanging(value);
                    this.SendPropertyChanging("parent", value);
                    this._parent = value;
                    this.SendPropertyChanged("parent", value);
                    this.OnparentChanged();
                }
            }
        }
        /// <summary>
        /// 级别
        /// </summary>
        [Column(Storage="_lev", DbType="int")]
        [DisplayName("级别")]
        [Description("级别")]
        public Int32? lev {
            get {
                return this._lev;
            }
            set {
                if ((this._lev != value)) {
                    this.OnlevChanging(value);
                    this.SendPropertyChanging("lev", value);
                    this._lev = value;
                    this.SendPropertyChanged("lev", value);
                    this.OnlevChanged();
                }
            }
        }
        /// <summary>
        /// 路径
        /// </summary>
        [Column(Storage="_path", DbType="varchar(50)")]
        [DisplayName("路径")]
        [Description("路径")]
        public String path {
            get {
                return this._path;
            }
            set {
                if ((this._path != value)) {
                    this.OnpathChanging(value);
                    this.SendPropertyChanging("path", value);
                    this._path = value;
                    this.SendPropertyChanged("path", value);
                    this.OnpathChanged();
                }
            }
        }
        /// <summary>
        /// 连接
        /// </summary>
        [Column(Storage="_url", DbType="varchar(400) NOT NULL", CanBeNull=false)]
        [DisplayName("连接")]
        [Description("连接")]
        public String url {
            get {
                return this._url;
            }
            set {
                this.OnurlChanging(value);
                this.SendPropertyChanging("url", value);
                this._url = value;
                this.SendPropertyChanged("url", value);
                this.OnurlChanged();
            }
        }
        /// <summary>
        /// 模块
        /// </summary>
        [Column(Storage="_module", DbType="int")]
        [DisplayName("模块")]
        [Description("模块")]
        public Int32? module {
            get {
                return this._module;
            }
            set {
                if ((this._module != value)) {
                    this.OnmoduleChanging(value);
                    this.SendPropertyChanging("module", value);
                    this._module = value;
                    this.SendPropertyChanged("module", value);
                    this.OnmoduleChanged();
                }
            }
        }
        /// <summary>
        /// 权限
        /// </summary>
        [Column(Storage="_action", DbType="int")]
        [DisplayName("权限")]
        [Description("权限")]
        public Int32? action {
            get {
                return this._action;
            }
            set {
                if ((this._action != value)) {
                    this.OnactionChanging(value);
                    this.SendPropertyChanging("action", value);
                    this._action = value;
                    this.SendPropertyChanged("action", value);
                    this.OnactionChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(800)")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    /// 新闻信息表
    /// </summary>
    [Table(Name="t_news")]
    [Serializable()]
    [DisplayName("新闻信息表")]
    [Description("新闻信息表")]
    public partial class Mnews : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 是否会员添加
        /// </summary>
        Boolean _ismember;
        /// <summary>
        /// 会员ID
        /// </summary>
        Int32 _mid;
        /// <summary>
        /// 会员类型（冗余）
        /// </summary>
        Int32 _membertype;
        /// <summary>
        /// 管理员ID
        /// </summary>
        Int32 _adminid;
        /// <summary>
        /// 新闻标题
        /// </summary>
        String _title;
        /// <summary>
        /// 索引
        /// </summary>
        String _letter;
        /// <summary>
        /// 新闻导读
        /// </summary>
        String _intro;
        /// <summary>
        /// 新闻内容
        /// </summary>
        String _descript;
        /// <summary>
        /// 审核状态
        /// </summary>
        Int32 _auditstatus;
        /// <summary>
        /// 在线状态
        /// </summary>
        Int32 _linestatus;
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime _createtime;
        /// <summary>
        /// 最后更新时间
        /// </summary>
        DateTime _lastedtime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 ismember 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnismemberChanging(Boolean value);
        /// <summary>
        /// 当 ismember 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnismemberChanged();
        /// <summary>
        /// 当 mid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmidChanging(Int32 value);
        /// <summary>
        /// 当 mid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmidChanged();
        /// <summary>
        /// 当 membertype 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmembertypeChanging(Int32 value);
        /// <summary>
        /// 当 membertype 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmembertypeChanged();
        /// <summary>
        /// 当 adminid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadminidChanging(Int32 value);
        /// <summary>
        /// 当 adminid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadminidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 letter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnletterChanging(String value);
        /// <summary>
        /// 当 letter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnletterChanged();
        /// <summary>
        /// 当 intro 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnintroChanging(String value);
        /// <summary>
        /// 当 intro 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnintroChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 auditstatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauditstatusChanging(Int32 value);
        /// <summary>
        /// 当 auditstatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauditstatusChanged();
        /// <summary>
        /// 当 linestatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinestatusChanging(Int32 value);
        /// <summary>
        /// 当 linestatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinestatusChanged();
        /// <summary>
        /// 当 createtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatetimeChanging(DateTime value);
        /// <summary>
        /// 当 createtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatetimeChanged();
        /// <summary>
        /// 当 lastedtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedtimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedtimeChanged();
        
        /// <summary>
        /// 初始化 Mnews 实体类的新实例。
        /// </summary>
        public Mnews() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 是否会员添加
        /// </summary>
        [Column(Storage="_ismember", DbType="bit NOT NULL", CanBeNull=false)]
        [DisplayName("是否会员添加")]
        [Description("是否会员添加")]
        public Boolean ismember {
            get {
                return this._ismember;
            }
            set {
                this.OnismemberChanging(value);
                this.SendPropertyChanging("ismember", value);
                this._ismember = value;
                this.SendPropertyChanged("ismember", value);
                this.OnismemberChanged();
            }
        }
        /// <summary>
        /// 会员ID
        /// </summary>
        [Column(Storage="_mid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("会员ID")]
        [Description("会员ID")]
        public Int32 mid {
            get {
                return this._mid;
            }
            set {
                this.OnmidChanging(value);
                this.SendPropertyChanging("mid", value);
                this._mid = value;
                this.SendPropertyChanged("mid", value);
                this.OnmidChanged();
            }
        }
        /// <summary>
        /// 会员类型（冗余）
        /// </summary>
        [Column(Storage="_membertype", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("会员类型（冗余）")]
        [Description("会员类型（冗余）")]
        public Int32 membertype {
            get {
                return this._membertype;
            }
            set {
                this.OnmembertypeChanging(value);
                this.SendPropertyChanging("membertype", value);
                this._membertype = value;
                this.SendPropertyChanged("membertype", value);
                this.OnmembertypeChanged();
            }
        }
        /// <summary>
        /// 管理员ID
        /// </summary>
        [Column(Storage="_adminid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("管理员ID")]
        [Description("管理员ID")]
        public Int32 adminid {
            get {
                return this._adminid;
            }
            set {
                this.OnadminidChanging(value);
                this.SendPropertyChanging("adminid", value);
                this._adminid = value;
                this.SendPropertyChanged("adminid", value);
                this.OnadminidChanged();
            }
        }
        /// <summary>
        /// 新闻标题
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(80) NOT NULL", CanBeNull=false)]
        [DisplayName("新闻标题")]
        [Description("新闻标题")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 索引
        /// </summary>
        [Column(Storage="_letter", DbType="nvarchar(80) NOT NULL", CanBeNull=false)]
        [DisplayName("索引")]
        [Description("索引")]
        public String letter {
            get {
                return this._letter;
            }
            set {
                this.OnletterChanging(value);
                this.SendPropertyChanging("letter", value);
                this._letter = value;
                this.SendPropertyChanged("letter", value);
                this.OnletterChanged();
            }
        }
        /// <summary>
        /// 新闻导读
        /// </summary>
        [Column(Storage="_intro", DbType="nvarchar(500) NOT NULL", CanBeNull=false)]
        [DisplayName("新闻导读")]
        [Description("新闻导读")]
        public String intro {
            get {
                return this._intro;
            }
            set {
                this.OnintroChanging(value);
                this.SendPropertyChanging("intro", value);
                this._intro = value;
                this.SendPropertyChanged("intro", value);
                this.OnintroChanged();
            }
        }
        /// <summary>
        /// 新闻内容
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(4000) NOT NULL", CanBeNull=false)]
        [DisplayName("新闻内容")]
        [Description("新闻内容")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                this.OndescriptChanging(value);
                this.SendPropertyChanging("descript", value);
                this._descript = value;
                this.SendPropertyChanged("descript", value);
                this.OndescriptChanged();
            }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        [Column(Storage="_auditstatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("审核状态")]
        [Description("审核状态")]
        public Int32 auditstatus {
            get {
                return this._auditstatus;
            }
            set {
                this.OnauditstatusChanging(value);
                this.SendPropertyChanging("auditstatus", value);
                this._auditstatus = value;
                this.SendPropertyChanged("auditstatus", value);
                this.OnauditstatusChanged();
            }
        }
        /// <summary>
        /// 在线状态
        /// </summary>
        [Column(Storage="_linestatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("在线状态")]
        [Description("在线状态")]
        public Int32 linestatus {
            get {
                return this._linestatus;
            }
            set {
                this.OnlinestatusChanging(value);
                this.SendPropertyChanging("linestatus", value);
                this._linestatus = value;
                this.SendPropertyChanged("linestatus", value);
                this.OnlinestatusChanged();
            }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Storage="_createtime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        public DateTime createtime {
            get {
                return this._createtime;
            }
            set {
                this.OncreatetimeChanging(value);
                this.SendPropertyChanging("createtime", value);
                this._createtime = value;
                this.SendPropertyChanged("createtime", value);
                this.OncreatetimeChanged();
            }
        }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Column(Storage="_lastedtime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最后更新时间")]
        [Description("最后更新时间")]
        public DateTime lastedtime {
            get {
                return this._lastedtime;
            }
            set {
                this.OnlastedtimeChanging(value);
                this.SendPropertyChanging("lastedtime", value);
                this._lastedtime = value;
                this.SendPropertyChanged("lastedtime", value);
                this.OnlastedtimeChanged();
            }
        }
    }
    /// <summary>
    /// 支付表
    /// </summary>
    [Table(Name="t_PayMent")]
    [Serializable()]
    [DisplayName("支付表")]
    [Description("支付表")]
    public partial class MPayMent : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _ID;
        /// <summary>
        /// 订单号
        /// </summary>
        String _OrderCode;
        /// <summary>
        /// 支付金额
        /// </summary>
        Decimal? _Price;
        /// <summary>
        /// 会员ID
        /// </summary>
        Int32? _Mid;
        /// <summary>
        /// 支付类型
        /// </summary>
        Int32? _Types;
        /// <summary>
        /// 银行
        /// </summary>
        String _Bank;
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? _CreateTime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 ID 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnIDChanging(Int32 value);
        /// <summary>
        /// 当 ID 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnIDChanged();
        /// <summary>
        /// 当 OrderCode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnOrderCodeChanging(String value);
        /// <summary>
        /// 当 OrderCode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnOrderCodeChanged();
        /// <summary>
        /// 当 Price 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnPriceChanging(Decimal? value);
        /// <summary>
        /// 当 Price 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnPriceChanged();
        /// <summary>
        /// 当 Mid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnMidChanging(Int32? value);
        /// <summary>
        /// 当 Mid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnMidChanged();
        /// <summary>
        /// 当 Types 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnTypesChanging(Int32? value);
        /// <summary>
        /// 当 Types 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnTypesChanged();
        /// <summary>
        /// 当 Bank 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnBankChanging(String value);
        /// <summary>
        /// 当 Bank 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnBankChanged();
        /// <summary>
        /// 当 CreateTime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnCreateTimeChanging(DateTime? value);
        /// <summary>
        /// 当 CreateTime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnCreateTimeChanged();
        
        /// <summary>
        /// 初始化 MPayMent 实体类的新实例。
        /// </summary>
        public MPayMent() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_ID", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 ID {
            get {
                return this._ID;
            }
            set {
                this._ID = value;
            }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        [Column(Storage="_OrderCode", DbType="varchar(50)")]
        [DisplayName("订单号")]
        [Description("订单号")]
        public String OrderCode {
            get {
                return this._OrderCode;
            }
            set {
                if ((this._OrderCode != value)) {
                    this.OnOrderCodeChanging(value);
                    this.SendPropertyChanging("OrderCode", value);
                    this._OrderCode = value;
                    this.SendPropertyChanged("OrderCode", value);
                    this.OnOrderCodeChanged();
                }
            }
        }
        /// <summary>
        /// 支付金额
        /// </summary>
        [Column(Storage="_Price", DbType="decimal")]
        [DisplayName("支付金额")]
        [Description("支付金额")]
        public Decimal? Price {
            get {
                return this._Price;
            }
            set {
                if ((this._Price != value)) {
                    this.OnPriceChanging(value);
                    this.SendPropertyChanging("Price", value);
                    this._Price = value;
                    this.SendPropertyChanged("Price", value);
                    this.OnPriceChanged();
                }
            }
        }
        /// <summary>
        /// 会员ID
        /// </summary>
        [Column(Storage="_Mid", DbType="int")]
        [DisplayName("会员ID")]
        [Description("会员ID")]
        public Int32? Mid {
            get {
                return this._Mid;
            }
            set {
                if ((this._Mid != value)) {
                    this.OnMidChanging(value);
                    this.SendPropertyChanging("Mid", value);
                    this._Mid = value;
                    this.SendPropertyChanged("Mid", value);
                    this.OnMidChanged();
                }
            }
        }
        /// <summary>
        /// 支付类型
        /// </summary>
        [Column(Storage="_Types", DbType="int")]
        [DisplayName("支付类型")]
        [Description("支付类型")]
        public Int32? Types {
            get {
                return this._Types;
            }
            set {
                if ((this._Types != value)) {
                    this.OnTypesChanging(value);
                    this.SendPropertyChanging("Types", value);
                    this._Types = value;
                    this.SendPropertyChanged("Types", value);
                    this.OnTypesChanged();
                }
            }
        }
        /// <summary>
        /// 银行
        /// </summary>
        [Column(Storage="_Bank", DbType="varchar(20)")]
        [DisplayName("银行")]
        [Description("银行")]
        public String Bank {
            get {
                return this._Bank;
            }
            set {
                if ((this._Bank != value)) {
                    this.OnBankChanging(value);
                    this.SendPropertyChanging("Bank", value);
                    this._Bank = value;
                    this.SendPropertyChanged("Bank", value);
                    this.OnBankChanged();
                }
            }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Storage="_CreateTime", DbType="datetime")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        public DateTime? CreateTime {
            get {
                return this._CreateTime;
            }
            set {
                if ((this._CreateTime != value)) {
                    this.OnCreateTimeChanging(value);
                    this.SendPropertyChanging("CreateTime", value);
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime", value);
                    this.OnCreateTimeChanged();
                }
            }
        }
    }
    /// <summary>
    /// 支付日志表
    /// </summary>
    [Table(Name="t_PayMentLog")]
    [Serializable()]
    [DisplayName("支付日志表")]
    [Description("支付日志表")]
    public partial class MPayMentLog : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _ID;
        /// <summary>
        /// 订单号
        /// </summary>
        String _OrderCode;
        /// <summary>
        /// 支付金额
        /// </summary>
        Decimal? _Price;
        /// <summary>
        /// 会员ID
        /// </summary>
        Int32? _Mid;
        /// <summary>
        /// 支付类型
        /// </summary>
        Int32? _Types;
        /// <summary>
        /// 银行
        /// </summary>
        String _Bank;
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? _CreateTime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 ID 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnIDChanging(Int32 value);
        /// <summary>
        /// 当 ID 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnIDChanged();
        /// <summary>
        /// 当 OrderCode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnOrderCodeChanging(String value);
        /// <summary>
        /// 当 OrderCode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnOrderCodeChanged();
        /// <summary>
        /// 当 Price 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnPriceChanging(Decimal? value);
        /// <summary>
        /// 当 Price 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnPriceChanged();
        /// <summary>
        /// 当 Mid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnMidChanging(Int32? value);
        /// <summary>
        /// 当 Mid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnMidChanged();
        /// <summary>
        /// 当 Types 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnTypesChanging(Int32? value);
        /// <summary>
        /// 当 Types 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnTypesChanged();
        /// <summary>
        /// 当 Bank 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnBankChanging(String value);
        /// <summary>
        /// 当 Bank 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnBankChanged();
        /// <summary>
        /// 当 CreateTime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnCreateTimeChanging(DateTime? value);
        /// <summary>
        /// 当 CreateTime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnCreateTimeChanged();
        
        /// <summary>
        /// 初始化 MPayMentLog 实体类的新实例。
        /// </summary>
        public MPayMentLog() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_ID", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 ID {
            get {
                return this._ID;
            }
            set {
                this._ID = value;
            }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        [Column(Storage="_OrderCode", DbType="varchar(50)")]
        [DisplayName("订单号")]
        [Description("订单号")]
        public String OrderCode {
            get {
                return this._OrderCode;
            }
            set {
                if ((this._OrderCode != value)) {
                    this.OnOrderCodeChanging(value);
                    this.SendPropertyChanging("OrderCode", value);
                    this._OrderCode = value;
                    this.SendPropertyChanged("OrderCode", value);
                    this.OnOrderCodeChanged();
                }
            }
        }
        /// <summary>
        /// 支付金额
        /// </summary>
        [Column(Storage="_Price", DbType="decimal")]
        [DisplayName("支付金额")]
        [Description("支付金额")]
        public Decimal? Price {
            get {
                return this._Price;
            }
            set {
                if ((this._Price != value)) {
                    this.OnPriceChanging(value);
                    this.SendPropertyChanging("Price", value);
                    this._Price = value;
                    this.SendPropertyChanged("Price", value);
                    this.OnPriceChanged();
                }
            }
        }
        /// <summary>
        /// 会员ID
        /// </summary>
        [Column(Storage="_Mid", DbType="int")]
        [DisplayName("会员ID")]
        [Description("会员ID")]
        public Int32? Mid {
            get {
                return this._Mid;
            }
            set {
                if ((this._Mid != value)) {
                    this.OnMidChanging(value);
                    this.SendPropertyChanging("Mid", value);
                    this._Mid = value;
                    this.SendPropertyChanged("Mid", value);
                    this.OnMidChanged();
                }
            }
        }
        /// <summary>
        /// 支付类型
        /// </summary>
        [Column(Storage="_Types", DbType="int")]
        [DisplayName("支付类型")]
        [Description("支付类型")]
        public Int32? Types {
            get {
                return this._Types;
            }
            set {
                if ((this._Types != value)) {
                    this.OnTypesChanging(value);
                    this.SendPropertyChanging("Types", value);
                    this._Types = value;
                    this.SendPropertyChanged("Types", value);
                    this.OnTypesChanged();
                }
            }
        }
        /// <summary>
        /// 银行
        /// </summary>
        [Column(Storage="_Bank", DbType="varchar(20)")]
        [DisplayName("银行")]
        [Description("银行")]
        public String Bank {
            get {
                return this._Bank;
            }
            set {
                if ((this._Bank != value)) {
                    this.OnBankChanging(value);
                    this.SendPropertyChanging("Bank", value);
                    this._Bank = value;
                    this.SendPropertyChanged("Bank", value);
                    this.OnBankChanged();
                }
            }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Storage="_CreateTime", DbType="datetime")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        public DateTime? CreateTime {
            get {
                return this._CreateTime;
            }
            set {
                if ((this._CreateTime != value)) {
                    this.OnCreateTimeChanging(value);
                    this.SendPropertyChanging("CreateTime", value);
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime", value);
                    this.OnCreateTimeChanged();
                }
            }
        }
    }
    /// <summary>
    /// 产品分类与产品类型关联表
    /// </summary>
    [Table(Name="t_pcategoryptypedef")]
    [Serializable()]
    [DisplayName("产品分类与产品类型关联表")]
    [Description("产品分类与产品类型关联表")]
    public partial class Mpcategoryptypedef : DALModelBase {
        /// <summary>
        /// 分类ID
        /// </summary>
        Int32 _productcategoryid;
        /// <summary>
        /// 类型ID
        /// </summary>
        Int32? _producttypeid;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 productcategoryid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcategoryidChanging(Int32 value);
        /// <summary>
        /// 当 productcategoryid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcategoryidChanged();
        /// <summary>
        /// 当 producttypeid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproducttypeidChanging(Int32? value);
        /// <summary>
        /// 当 producttypeid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproducttypeidChanged();
        
        /// <summary>
        /// 初始化 Mpcategoryptypedef 实体类的新实例。
        /// </summary>
        public Mpcategoryptypedef() {
            this.OnCreated();
        }
        /// <summary>
        /// 分类ID
        /// </summary>
        [Column(Storage="_productcategoryid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("分类ID")]
        [Description("分类ID")]
        public Int32 productcategoryid {
            get {
                return this._productcategoryid;
            }
            set {
                this.OnproductcategoryidChanging(value);
                this.SendPropertyChanging("productcategoryid", value);
                this._productcategoryid = value;
                this.SendPropertyChanged("productcategoryid", value);
                this.OnproductcategoryidChanged();
            }
        }
        /// <summary>
        /// 类型ID
        /// </summary>
        [Column(Storage="_producttypeid", DbType="int")]
        [DisplayName("类型ID")]
        [Description("类型ID")]
        public Int32? producttypeid {
            get {
                return this._producttypeid;
            }
            set {
                if ((this._producttypeid != value)) {
                    this.OnproducttypeidChanging(value);
                    this.SendPropertyChanging("producttypeid", value);
                    this._producttypeid = value;
                    this.SendPropertyChanged("producttypeid", value);
                    this.OnproducttypeidChanged();
                }
            }
        }
    }
    /// <summary>
    /// 产品表
    /// </summary>
    [Table(Name="t_product")]
    [Serializable()]
    [DisplayName("产品表")]
    [Description("产品表")]
    public partial class Mproduct : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 属性（推荐……）
        /// </summary>
        String _attribute;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 副 名称
        /// </summary>
        String _shottitle;
        /// <summary>
        /// 颜色
        /// </summary>
        String _tcolor;
        /// <summary>
        /// 编号（厂家）
        /// </summary>
        String _sku;
        /// <summary>
        /// 编号(系统)
        /// </summary>
        String _no;
        /// <summary>
        /// 索引
        /// </summary>
        String _letter;
        /// <summary>
        /// 分类ID
        /// </summary>
        Int32 _categoryid;
        /// <summary>
        /// 分类名称
        /// </summary>
        String _categorytitle;
        /// <summary>
        /// 多分类ID列表
        /// </summary>
        String _subcategoryidlist;
        /// <summary>
        ///  
        /// </summary>
        String _subcategorytitlelist;
        /// <summary>
        /// 品牌ID
        /// </summary>
        Int32 _brandid;
        /// <summary>
        /// 品牌名称
        /// </summary>
        String _brandtitle;
        /// <summary>
        /// 系列ID
        /// </summary>
        Int32? _brandsid;
        /// <summary>
        /// 系列名称
        /// </summary>
        String _brandstitle;
        /// <summary>
        /// 风格值
        /// </summary>
        String _stylevalue;
        /// <summary>
        /// 风格名称
        /// </summary>
        String _stylename;
        /// <summary>
        /// 颜色名称
        /// </summary>
        String _colorname;
        /// <summary>
        /// 颜色值
        /// </summary>
        String _colorvalue;
        /// <summary>
        /// 材质名称
        /// </summary>
        String _materialvalue;
        /// <summary>
        /// 材质值
        /// </summary>
        String _materialname;
        /// <summary>
        /// 单位
        /// </summary>
        String _unit;
        /// <summary>
        /// 产地
        /// </summary>
        String _localitycode;
        /// <summary>
        /// 发货地
        /// </summary>
        String _shipcode;
        /// <summary>
        ///  
        /// </summary>
        Int32? _customize;
        /// <summary>
        /// 外观图
        /// </summary>
        String _surface;
        /// <summary>
        /// logo
        /// </summary>
        String _logo;
        /// <summary>
        /// 缩略图
        /// </summary>
        String _thumb;
        /// <summary>
        /// 幻灯图
        /// </summary>
        String _bannel;
        /// <summary>
        /// 描述图
        /// </summary>
        String _desimage;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 福家网ID
        /// </summary>
        String _tob2c;
        /// <summary>
        /// 所属企业ID
        /// </summary>
        Int32? _companyid;
        /// <summary>
        /// 所属企业名称
        /// </summary>
        String _companyname;
        /// <summary>
        /// 创建者ID
        /// </summary>
        Int32 _createmid;
        /// <summary>
        /// 点击量
        /// </summary>
        Int32? _hits;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 修改人ID
        /// </summary>
        Int32? _lastedid;
        /// <summary>
        /// 修改时间
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        /// 审核状态，-1正在审核，0待审核，1审核通过，-99未通过
        /// </summary>
        Int32 _auditstatus;
        /// <summary>
        /// 上下线状态,0下线，1上线
        /// </summary>
        Int32 _linestatus;
        /// <summary>
        ///  
        /// </summary>
        Boolean? _assemble;
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? _Createtime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 attribute 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnattributeChanging(String value);
        /// <summary>
        /// 当 attribute 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnattributeChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 shottitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshottitleChanging(String value);
        /// <summary>
        /// 当 shottitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshottitleChanged();
        /// <summary>
        /// 当 tcolor 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntcolorChanging(String value);
        /// <summary>
        /// 当 tcolor 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntcolorChanged();
        /// <summary>
        /// 当 sku 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnskuChanging(String value);
        /// <summary>
        /// 当 sku 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnskuChanged();
        /// <summary>
        /// 当 no 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnnoChanging(String value);
        /// <summary>
        /// 当 no 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnnoChanged();
        /// <summary>
        /// 当 letter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnletterChanging(String value);
        /// <summary>
        /// 当 letter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnletterChanged();
        /// <summary>
        /// 当 categoryid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncategoryidChanging(Int32 value);
        /// <summary>
        /// 当 categoryid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncategoryidChanged();
        /// <summary>
        /// 当 categorytitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncategorytitleChanging(String value);
        /// <summary>
        /// 当 categorytitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncategorytitleChanged();
        /// <summary>
        /// 当 subcategoryidlist 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsubcategoryidlistChanging(String value);
        /// <summary>
        /// 当 subcategoryidlist 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsubcategoryidlistChanged();
        /// <summary>
        /// 当 subcategorytitlelist 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsubcategorytitlelistChanging(String value);
        /// <summary>
        /// 当 subcategorytitlelist 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsubcategorytitlelistChanged();
        /// <summary>
        /// 当 brandid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandidChanging(Int32 value);
        /// <summary>
        /// 当 brandid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandidChanged();
        /// <summary>
        /// 当 brandtitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandtitleChanging(String value);
        /// <summary>
        /// 当 brandtitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandtitleChanged();
        /// <summary>
        /// 当 brandsid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandsidChanging(Int32? value);
        /// <summary>
        /// 当 brandsid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandsidChanged();
        /// <summary>
        /// 当 brandstitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandstitleChanging(String value);
        /// <summary>
        /// 当 brandstitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandstitleChanged();
        /// <summary>
        /// 当 stylevalue 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstylevalueChanging(String value);
        /// <summary>
        /// 当 stylevalue 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstylevalueChanged();
        /// <summary>
        /// 当 stylename 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstylenameChanging(String value);
        /// <summary>
        /// 当 stylename 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstylenameChanged();
        /// <summary>
        /// 当 colorname 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncolornameChanging(String value);
        /// <summary>
        /// 当 colorname 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncolornameChanged();
        /// <summary>
        /// 当 colorvalue 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncolorvalueChanging(String value);
        /// <summary>
        /// 当 colorvalue 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncolorvalueChanged();
        /// <summary>
        /// 当 materialvalue 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmaterialvalueChanging(String value);
        /// <summary>
        /// 当 materialvalue 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmaterialvalueChanged();
        /// <summary>
        /// 当 materialname 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmaterialnameChanging(String value);
        /// <summary>
        /// 当 materialname 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmaterialnameChanged();
        /// <summary>
        /// 当 unit 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnunitChanging(String value);
        /// <summary>
        /// 当 unit 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnunitChanged();
        /// <summary>
        /// 当 localitycode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlocalitycodeChanging(String value);
        /// <summary>
        /// 当 localitycode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlocalitycodeChanged();
        /// <summary>
        /// 当 shipcode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshipcodeChanging(String value);
        /// <summary>
        /// 当 shipcode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshipcodeChanged();
        /// <summary>
        /// 当 customize 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncustomizeChanging(Int32? value);
        /// <summary>
        /// 当 customize 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncustomizeChanged();
        /// <summary>
        /// 当 surface 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsurfaceChanging(String value);
        /// <summary>
        /// 当 surface 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsurfaceChanged();
        /// <summary>
        /// 当 logo 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlogoChanging(String value);
        /// <summary>
        /// 当 logo 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlogoChanged();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 bannel 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannelChanging(String value);
        /// <summary>
        /// 当 bannel 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannelChanged();
        /// <summary>
        /// 当 desimage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndesimageChanging(String value);
        /// <summary>
        /// 当 desimage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndesimageChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 tob2c 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void Ontob2cChanging(String value);
        /// <summary>
        /// 当 tob2c 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void Ontob2cChanged();
        /// <summary>
        /// 当 companyid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncompanyidChanging(Int32? value);
        /// <summary>
        /// 当 companyid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncompanyidChanged();
        /// <summary>
        /// 当 companyname 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncompanynameChanging(String value);
        /// <summary>
        /// 当 companyname 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncompanynameChanged();
        /// <summary>
        /// 当 createmid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatemidChanging(Int32 value);
        /// <summary>
        /// 当 createmid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatemidChanged();
        /// <summary>
        /// 当 hits 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhitsChanging(Int32? value);
        /// <summary>
        /// 当 hits 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhitsChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 lastedid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedidChanging(Int32? value);
        /// <summary>
        /// 当 lastedid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedidChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        /// <summary>
        /// 当 auditstatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauditstatusChanging(Int32 value);
        /// <summary>
        /// 当 auditstatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauditstatusChanged();
        /// <summary>
        /// 当 linestatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinestatusChanging(Int32 value);
        /// <summary>
        /// 当 linestatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinestatusChanged();
        /// <summary>
        /// 当 assemble 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnassembleChanging(Boolean? value);
        /// <summary>
        /// 当 assemble 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnassembleChanged();
        /// <summary>
        /// 当 Createtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnCreatetimeChanging(DateTime? value);
        /// <summary>
        /// 当 Createtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnCreatetimeChanged();
        
        /// <summary>
        /// 初始化 Mproduct 实体类的新实例。
        /// </summary>
        public Mproduct() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 属性（推荐……）
        /// </summary>
        [Column(Storage="_attribute", DbType="varchar(100)")]
        [DisplayName("属性（推荐……）")]
        [Description("属性（推荐……）")]
        public String attribute {
            get {
                return this._attribute;
            }
            set {
                if ((this._attribute != value)) {
                    this.OnattributeChanging(value);
                    this.SendPropertyChanging("attribute", value);
                    this._attribute = value;
                    this.SendPropertyChanged("attribute", value);
                    this.OnattributeChanged();
                }
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(80)")]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                if ((this._title != value)) {
                    this.OntitleChanging(value);
                    this.SendPropertyChanging("title", value);
                    this._title = value;
                    this.SendPropertyChanged("title", value);
                    this.OntitleChanged();
                }
            }
        }
        /// <summary>
        /// 副 名称
        /// </summary>
        [Column(Storage="_shottitle", DbType="nvarchar(20)")]
        [DisplayName("副 名称")]
        [Description("副 名称")]
        public String shottitle {
            get {
                return this._shottitle;
            }
            set {
                if ((this._shottitle != value)) {
                    this.OnshottitleChanging(value);
                    this.SendPropertyChanging("shottitle", value);
                    this._shottitle = value;
                    this.SendPropertyChanged("shottitle", value);
                    this.OnshottitleChanged();
                }
            }
        }
        /// <summary>
        /// 颜色
        /// </summary>
        [Column(Storage="_tcolor", DbType="char(7)")]
        [DisplayName("颜色")]
        [Description("颜色")]
        public String tcolor {
            get {
                return this._tcolor;
            }
            set {
                if ((this._tcolor != value)) {
                    this.OntcolorChanging(value);
                    this.SendPropertyChanging("tcolor", value);
                    this._tcolor = value;
                    this.SendPropertyChanged("tcolor", value);
                    this.OntcolorChanged();
                }
            }
        }
        /// <summary>
        /// 编号（厂家）
        /// </summary>
        [Column(Storage="_sku", DbType="varchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("编号（厂家）")]
        [Description("编号（厂家）")]
        public String sku {
            get {
                return this._sku;
            }
            set {
                this.OnskuChanging(value);
                this.SendPropertyChanging("sku", value);
                this._sku = value;
                this.SendPropertyChanged("sku", value);
                this.OnskuChanged();
            }
        }
        /// <summary>
        /// 编号(系统)
        /// </summary>
        [Column(Storage="_no", DbType="varchar(50)")]
        [DisplayName("编号(系统)")]
        [Description("编号(系统)")]
        public String no {
            get {
                return this._no;
            }
            set {
                if ((this._no != value)) {
                    this.OnnoChanging(value);
                    this.SendPropertyChanging("no", value);
                    this._no = value;
                    this.SendPropertyChanged("no", value);
                    this.OnnoChanged();
                }
            }
        }
        /// <summary>
        /// 索引
        /// </summary>
        [Column(Storage="_letter", DbType="varchar(30)")]
        [DisplayName("索引")]
        [Description("索引")]
        public String letter {
            get {
                return this._letter;
            }
            set {
                if ((this._letter != value)) {
                    this.OnletterChanging(value);
                    this.SendPropertyChanging("letter", value);
                    this._letter = value;
                    this.SendPropertyChanged("letter", value);
                    this.OnletterChanged();
                }
            }
        }
        /// <summary>
        /// 分类ID
        /// </summary>
        [Column(Storage="_categoryid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("分类ID")]
        [Description("分类ID")]
        public Int32 categoryid {
            get {
                return this._categoryid;
            }
            set {
                this.OncategoryidChanging(value);
                this.SendPropertyChanging("categoryid", value);
                this._categoryid = value;
                this.SendPropertyChanged("categoryid", value);
                this.OncategoryidChanged();
            }
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        [Column(Storage="_categorytitle", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("分类名称")]
        [Description("分类名称")]
        public String categorytitle {
            get {
                return this._categorytitle;
            }
            set {
                this.OncategorytitleChanging(value);
                this.SendPropertyChanging("categorytitle", value);
                this._categorytitle = value;
                this.SendPropertyChanged("categorytitle", value);
                this.OncategorytitleChanged();
            }
        }
        /// <summary>
        /// 多分类ID列表
        /// </summary>
        [Column(Storage="_subcategoryidlist", DbType="varchar(50)")]
        [DisplayName("多分类ID列表")]
        [Description("多分类ID列表")]
        public String subcategoryidlist {
            get {
                return this._subcategoryidlist;
            }
            set {
                if ((this._subcategoryidlist != value)) {
                    this.OnsubcategoryidlistChanging(value);
                    this.SendPropertyChanging("subcategoryidlist", value);
                    this._subcategoryidlist = value;
                    this.SendPropertyChanged("subcategoryidlist", value);
                    this.OnsubcategoryidlistChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_subcategorytitlelist", DbType="nvarchar(200)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String subcategorytitlelist {
            get {
                return this._subcategorytitlelist;
            }
            set {
                if ((this._subcategorytitlelist != value)) {
                    this.OnsubcategorytitlelistChanging(value);
                    this.SendPropertyChanging("subcategorytitlelist", value);
                    this._subcategorytitlelist = value;
                    this.SendPropertyChanged("subcategorytitlelist", value);
                    this.OnsubcategorytitlelistChanged();
                }
            }
        }
        /// <summary>
        /// 品牌ID
        /// </summary>
        [Column(Storage="_brandid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("品牌ID")]
        [Description("品牌ID")]
        public Int32 brandid {
            get {
                return this._brandid;
            }
            set {
                this.OnbrandidChanging(value);
                this.SendPropertyChanging("brandid", value);
                this._brandid = value;
                this.SendPropertyChanged("brandid", value);
                this.OnbrandidChanged();
            }
        }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [Column(Storage="_brandtitle", DbType="nvarchar(50)")]
        [DisplayName("品牌名称")]
        [Description("品牌名称")]
        public String brandtitle {
            get {
                return this._brandtitle;
            }
            set {
                if ((this._brandtitle != value)) {
                    this.OnbrandtitleChanging(value);
                    this.SendPropertyChanging("brandtitle", value);
                    this._brandtitle = value;
                    this.SendPropertyChanged("brandtitle", value);
                    this.OnbrandtitleChanged();
                }
            }
        }
        /// <summary>
        /// 系列ID
        /// </summary>
        [Column(Storage="_brandsid", DbType="int")]
        [DisplayName("系列ID")]
        [Description("系列ID")]
        public Int32? brandsid {
            get {
                return this._brandsid;
            }
            set {
                if ((this._brandsid != value)) {
                    this.OnbrandsidChanging(value);
                    this.SendPropertyChanging("brandsid", value);
                    this._brandsid = value;
                    this.SendPropertyChanged("brandsid", value);
                    this.OnbrandsidChanged();
                }
            }
        }
        /// <summary>
        /// 系列名称
        /// </summary>
        [Column(Storage="_brandstitle", DbType="nvarchar(50)")]
        [DisplayName("系列名称")]
        [Description("系列名称")]
        public String brandstitle {
            get {
                return this._brandstitle;
            }
            set {
                if ((this._brandstitle != value)) {
                    this.OnbrandstitleChanging(value);
                    this.SendPropertyChanging("brandstitle", value);
                    this._brandstitle = value;
                    this.SendPropertyChanged("brandstitle", value);
                    this.OnbrandstitleChanged();
                }
            }
        }
        /// <summary>
        /// 风格值
        /// </summary>
        [Column(Storage="_stylevalue", DbType="nvarchar(50)")]
        [DisplayName("风格值")]
        [Description("风格值")]
        public String stylevalue {
            get {
                return this._stylevalue;
            }
            set {
                if ((this._stylevalue != value)) {
                    this.OnstylevalueChanging(value);
                    this.SendPropertyChanging("stylevalue", value);
                    this._stylevalue = value;
                    this.SendPropertyChanged("stylevalue", value);
                    this.OnstylevalueChanged();
                }
            }
        }
        /// <summary>
        /// 风格名称
        /// </summary>
        [Column(Storage="_stylename", DbType="nvarchar(50)")]
        [DisplayName("风格名称")]
        [Description("风格名称")]
        public String stylename {
            get {
                return this._stylename;
            }
            set {
                if ((this._stylename != value)) {
                    this.OnstylenameChanging(value);
                    this.SendPropertyChanging("stylename", value);
                    this._stylename = value;
                    this.SendPropertyChanged("stylename", value);
                    this.OnstylenameChanged();
                }
            }
        }
        /// <summary>
        /// 颜色名称
        /// </summary>
        [Column(Storage="_colorname", DbType="nvarchar(50)")]
        [DisplayName("颜色名称")]
        [Description("颜色名称")]
        public String colorname {
            get {
                return this._colorname;
            }
            set {
                if ((this._colorname != value)) {
                    this.OncolornameChanging(value);
                    this.SendPropertyChanging("colorname", value);
                    this._colorname = value;
                    this.SendPropertyChanged("colorname", value);
                    this.OncolornameChanged();
                }
            }
        }
        /// <summary>
        /// 颜色值
        /// </summary>
        [Column(Storage="_colorvalue", DbType="nvarchar(50)")]
        [DisplayName("颜色值")]
        [Description("颜色值")]
        public String colorvalue {
            get {
                return this._colorvalue;
            }
            set {
                if ((this._colorvalue != value)) {
                    this.OncolorvalueChanging(value);
                    this.SendPropertyChanging("colorvalue", value);
                    this._colorvalue = value;
                    this.SendPropertyChanged("colorvalue", value);
                    this.OncolorvalueChanged();
                }
            }
        }
        /// <summary>
        /// 材质名称
        /// </summary>
        [Column(Storage="_materialvalue", DbType="nvarchar(50)")]
        [DisplayName("材质名称")]
        [Description("材质名称")]
        public String materialvalue {
            get {
                return this._materialvalue;
            }
            set {
                if ((this._materialvalue != value)) {
                    this.OnmaterialvalueChanging(value);
                    this.SendPropertyChanging("materialvalue", value);
                    this._materialvalue = value;
                    this.SendPropertyChanged("materialvalue", value);
                    this.OnmaterialvalueChanged();
                }
            }
        }
        /// <summary>
        /// 材质值
        /// </summary>
        [Column(Storage="_materialname", DbType="nvarchar(50)")]
        [DisplayName("材质值")]
        [Description("材质值")]
        public String materialname {
            get {
                return this._materialname;
            }
            set {
                if ((this._materialname != value)) {
                    this.OnmaterialnameChanging(value);
                    this.SendPropertyChanging("materialname", value);
                    this._materialname = value;
                    this.SendPropertyChanged("materialname", value);
                    this.OnmaterialnameChanged();
                }
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        [Column(Storage="_unit", DbType="nvarchar(4)")]
        [DisplayName("单位")]
        [Description("单位")]
        public String unit {
            get {
                return this._unit;
            }
            set {
                if ((this._unit != value)) {
                    this.OnunitChanging(value);
                    this.SendPropertyChanging("unit", value);
                    this._unit = value;
                    this.SendPropertyChanged("unit", value);
                    this.OnunitChanged();
                }
            }
        }
        /// <summary>
        /// 产地
        /// </summary>
        [Column(Storage="_localitycode", DbType="varchar(12)")]
        [DisplayName("产地")]
        [Description("产地")]
        public String localitycode {
            get {
                return this._localitycode;
            }
            set {
                if ((this._localitycode != value)) {
                    this.OnlocalitycodeChanging(value);
                    this.SendPropertyChanging("localitycode", value);
                    this._localitycode = value;
                    this.SendPropertyChanged("localitycode", value);
                    this.OnlocalitycodeChanged();
                }
            }
        }
        /// <summary>
        /// 发货地
        /// </summary>
        [Column(Storage="_shipcode", DbType="varchar(12)")]
        [DisplayName("发货地")]
        [Description("发货地")]
        public String shipcode {
            get {
                return this._shipcode;
            }
            set {
                if ((this._shipcode != value)) {
                    this.OnshipcodeChanging(value);
                    this.SendPropertyChanging("shipcode", value);
                    this._shipcode = value;
                    this.SendPropertyChanged("shipcode", value);
                    this.OnshipcodeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_customize", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? customize {
            get {
                return this._customize;
            }
            set {
                if ((this._customize != value)) {
                    this.OncustomizeChanging(value);
                    this.SendPropertyChanging("customize", value);
                    this._customize = value;
                    this.SendPropertyChanged("customize", value);
                    this.OncustomizeChanged();
                }
            }
        }
        /// <summary>
        /// 外观图
        /// </summary>
        [Column(Storage="_surface", DbType="varchar(200)")]
        [DisplayName("外观图")]
        [Description("外观图")]
        public String surface {
            get {
                return this._surface;
            }
            set {
                if ((this._surface != value)) {
                    this.OnsurfaceChanging(value);
                    this.SendPropertyChanging("surface", value);
                    this._surface = value;
                    this.SendPropertyChanged("surface", value);
                    this.OnsurfaceChanged();
                }
            }
        }
        /// <summary>
        /// logo
        /// </summary>
        [Column(Storage="_logo", DbType="varchar(40)")]
        [DisplayName("logo")]
        [Description("logo")]
        public String logo {
            get {
                return this._logo;
            }
            set {
                if ((this._logo != value)) {
                    this.OnlogoChanging(value);
                    this.SendPropertyChanging("logo", value);
                    this._logo = value;
                    this.SendPropertyChanged("logo", value);
                    this.OnlogoChanged();
                }
            }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(40)")]
        [DisplayName("缩略图")]
        [Description("缩略图")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        /// 幻灯图
        /// </summary>
        [Column(Storage="_bannel", DbType="varchar(300)")]
        [DisplayName("幻灯图")]
        [Description("幻灯图")]
        public String bannel {
            get {
                return this._bannel;
            }
            set {
                if ((this._bannel != value)) {
                    this.OnbannelChanging(value);
                    this.SendPropertyChanging("bannel", value);
                    this._bannel = value;
                    this.SendPropertyChanged("bannel", value);
                    this.OnbannelChanged();
                }
            }
        }
        /// <summary>
        /// 描述图
        /// </summary>
        [Column(Storage="_desimage", DbType="varchar(400)")]
        [DisplayName("描述图")]
        [Description("描述图")]
        public String desimage {
            get {
                return this._desimage;
            }
            set {
                if ((this._desimage != value)) {
                    this.OndesimageChanging(value);
                    this.SendPropertyChanging("desimage", value);
                    this._desimage = value;
                    this.SendPropertyChanged("desimage", value);
                    this.OndesimageChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(500)")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 福家网ID
        /// </summary>
        [Column(Storage="_tob2c", DbType="varchar(50)")]
        [DisplayName("福家网ID")]
        [Description("福家网ID")]
        public String tob2c {
            get {
                return this._tob2c;
            }
            set {
                if ((this._tob2c != value)) {
                    this.Ontob2cChanging(value);
                    this.SendPropertyChanging("tob2c", value);
                    this._tob2c = value;
                    this.SendPropertyChanged("tob2c", value);
                    this.Ontob2cChanged();
                }
            }
        }
        /// <summary>
        /// 所属企业ID
        /// </summary>
        [Column(Storage="_companyid", DbType="int")]
        [DisplayName("所属企业ID")]
        [Description("所属企业ID")]
        public Int32? companyid {
            get {
                return this._companyid;
            }
            set {
                if ((this._companyid != value)) {
                    this.OncompanyidChanging(value);
                    this.SendPropertyChanging("companyid", value);
                    this._companyid = value;
                    this.SendPropertyChanged("companyid", value);
                    this.OncompanyidChanged();
                }
            }
        }
        /// <summary>
        /// 所属企业名称
        /// </summary>
        [Column(Storage="_companyname", DbType="nvarchar(50)")]
        [DisplayName("所属企业名称")]
        [Description("所属企业名称")]
        public String companyname {
            get {
                return this._companyname;
            }
            set {
                if ((this._companyname != value)) {
                    this.OncompanynameChanging(value);
                    this.SendPropertyChanging("companyname", value);
                    this._companyname = value;
                    this.SendPropertyChanged("companyname", value);
                    this.OncompanynameChanged();
                }
            }
        }
        /// <summary>
        /// 创建者ID
        /// </summary>
        [Column(Storage="_createmid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("创建者ID")]
        [Description("创建者ID")]
        public Int32 createmid {
            get {
                return this._createmid;
            }
            set {
                this.OncreatemidChanging(value);
                this.SendPropertyChanging("createmid", value);
                this._createmid = value;
                this.SendPropertyChanged("createmid", value);
                this.OncreatemidChanged();
            }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        [Column(Storage="_hits", DbType="int")]
        [DisplayName("点击量")]
        [Description("点击量")]
        public Int32? hits {
            get {
                return this._hits;
            }
            set {
                if ((this._hits != value)) {
                    this.OnhitsChanging(value);
                    this.SendPropertyChanging("hits", value);
                    this._hits = value;
                    this.SendPropertyChanged("hits", value);
                    this.OnhitsChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 修改人ID
        /// </summary>
        [Column(Storage="_lastedid", DbType="int")]
        [DisplayName("修改人ID")]
        [Description("修改人ID")]
        public Int32? lastedid {
            get {
                return this._lastedid;
            }
            set {
                if ((this._lastedid != value)) {
                    this.OnlastedidChanging(value);
                    this.SendPropertyChanging("lastedid", value);
                    this._lastedid = value;
                    this.SendPropertyChanged("lastedid", value);
                    this.OnlastedidChanged();
                }
            }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("修改时间")]
        [Description("修改时间")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
        /// <summary>
        /// 审核状态，-1正在审核，0待审核，1审核通过，-99未通过
        /// </summary>
        [Column(Storage="_auditstatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("审核状态")]
        [Description("审核状态，-1正在审核，0待审核，1审核通过，-99未通过")]
        public Int32 auditstatus {
            get {
                return this._auditstatus;
            }
            set {
                this.OnauditstatusChanging(value);
                this.SendPropertyChanging("auditstatus", value);
                this._auditstatus = value;
                this.SendPropertyChanged("auditstatus", value);
                this.OnauditstatusChanged();
            }
        }
        /// <summary>
        /// 上下线状态,0下线，1上线
        /// </summary>
        [Column(Storage="_linestatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("上下线状态")]
        [Description("上下线状态,0下线，1上线")]
        public Int32 linestatus {
            get {
                return this._linestatus;
            }
            set {
                this.OnlinestatusChanging(value);
                this.SendPropertyChanging("linestatus", value);
                this._linestatus = value;
                this.SendPropertyChanged("linestatus", value);
                this.OnlinestatusChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_assemble", DbType="bit")]
        [DisplayName(" ")]
        [Description(" ")]
        public Boolean? assemble {
            get {
                return this._assemble;
            }
            set {
                if ((this._assemble != value)) {
                    this.OnassembleChanging(value);
                    this.SendPropertyChanging("assemble", value);
                    this._assemble = value;
                    this.SendPropertyChanged("assemble", value);
                    this.OnassembleChanged();
                }
            }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Storage="_Createtime", DbType="datetime")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        public DateTime? Createtime {
            get {
                return this._Createtime;
            }
            set {
                if ((this._Createtime != value)) {
                    this.OnCreatetimeChanging(value);
                    this.SendPropertyChanging("Createtime", value);
                    this._Createtime = value;
                    this.SendPropertyChanged("Createtime", value);
                    this.OnCreatetimeChanged();
                }
            }
        }
    }
    /// <summary>
    /// 产品属性表
    /// </summary>
    [Table(Name="t_productattribute")]
    [Serializable()]
    [DisplayName("产品属性表")]
    [Description("产品属性表")]
    public partial class Mproductattribute : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 产品ID
        /// </summary>
        Int32? _productid;
        /// <summary>
        /// 产品编号(系统编号)
        /// </summary>
        String _productno;
        /// <summary>
        /// 产品SKU（厂家编号）
        /// </summary>
        String _productsku;
        /// <summary>
        /// 产品类型（ ）config表值(其它类型=0)
        /// </summary>
        String _typevalue;
        /// <summary>
        /// 产吕类型名称()
        /// </summary>
        String _typename;
        /// <summary>
        /// 产品风格
        /// </summary>
        String _productstyle;
        /// <summary>
        /// 材质
        /// </summary>
        String _productmaterial;
        /// <summary>
        /// 颜色图片
        /// </summary>
        String _productcolorimg;
        /// <summary>
        /// 颜色名称
        /// </summary>
        String _productcolortitle;
        /// <summary>
        /// 颜色色值
        /// </summary>
        String _productcolorvalue;
        /// <summary>
        /// 宽
        /// </summary>
        Decimal? _productwidth;
        /// <summary>
        /// 高
        /// </summary>
        Decimal? _productheight;
        /// <summary>
        /// 长
        /// </summary>
        Decimal? _productlength;
        /// <summary>
        /// 体积
        /// </summary>
        Decimal? _productcbm;
        /// <summary>
        /// 采购价
        /// </summary>
        Decimal? _buyprice;
        /// <summary>
        /// 市场价
        /// </summary>
        Decimal? _markprice;
        /// <summary>
        /// 销售价
        /// </summary>
        Decimal? _saleprice;
        /// <summary>
        /// 其它信息
        /// </summary>
        String _otherinfo;
        /// <summary>
        /// 库存
        /// </summary>
        Int32? _storage;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 是否默认
        /// </summary>
        Int32 _isdefault;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 productid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductidChanging(Int32? value);
        /// <summary>
        /// 当 productid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductidChanged();
        /// <summary>
        /// 当 productno 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductnoChanging(String value);
        /// <summary>
        /// 当 productno 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductnoChanged();
        /// <summary>
        /// 当 productsku 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductskuChanging(String value);
        /// <summary>
        /// 当 productsku 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductskuChanged();
        /// <summary>
        /// 当 typevalue 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntypevalueChanging(String value);
        /// <summary>
        /// 当 typevalue 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntypevalueChanged();
        /// <summary>
        /// 当 typename 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntypenameChanging(String value);
        /// <summary>
        /// 当 typename 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntypenameChanged();
        /// <summary>
        /// 当 productstyle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductstyleChanging(String value);
        /// <summary>
        /// 当 productstyle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductstyleChanged();
        /// <summary>
        /// 当 productmaterial 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductmaterialChanging(String value);
        /// <summary>
        /// 当 productmaterial 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductmaterialChanged();
        /// <summary>
        /// 当 productcolorimg 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcolorimgChanging(String value);
        /// <summary>
        /// 当 productcolorimg 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcolorimgChanged();
        /// <summary>
        /// 当 productcolortitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcolortitleChanging(String value);
        /// <summary>
        /// 当 productcolortitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcolortitleChanged();
        /// <summary>
        /// 当 productcolorvalue 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcolorvalueChanging(String value);
        /// <summary>
        /// 当 productcolorvalue 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcolorvalueChanged();
        /// <summary>
        /// 当 productwidth 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductwidthChanging(Decimal? value);
        /// <summary>
        /// 当 productwidth 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductwidthChanged();
        /// <summary>
        /// 当 productheight 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductheightChanging(Decimal? value);
        /// <summary>
        /// 当 productheight 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductheightChanged();
        /// <summary>
        /// 当 productlength 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductlengthChanging(Decimal? value);
        /// <summary>
        /// 当 productlength 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductlengthChanged();
        /// <summary>
        /// 当 productcbm 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcbmChanging(Decimal? value);
        /// <summary>
        /// 当 productcbm 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcbmChanged();
        /// <summary>
        /// 当 buyprice 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbuypriceChanging(Decimal? value);
        /// <summary>
        /// 当 buyprice 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbuypriceChanged();
        /// <summary>
        /// 当 markprice 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarkpriceChanging(Decimal? value);
        /// <summary>
        /// 当 markprice 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarkpriceChanged();
        /// <summary>
        /// 当 saleprice 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsalepriceChanging(Decimal? value);
        /// <summary>
        /// 当 saleprice 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsalepriceChanged();
        /// <summary>
        /// 当 otherinfo 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnotherinfoChanging(String value);
        /// <summary>
        /// 当 otherinfo 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnotherinfoChanged();
        /// <summary>
        /// 当 storage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstorageChanging(Int32? value);
        /// <summary>
        /// 当 storage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstorageChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 isdefault 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnisdefaultChanging(Int32 value);
        /// <summary>
        /// 当 isdefault 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnisdefaultChanged();
        
        /// <summary>
        /// 初始化 Mproductattribute 实体类的新实例。
        /// </summary>
        public Mproductattribute() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 产品ID
        /// </summary>
        [Column(Storage="_productid", DbType="int")]
        [DisplayName("产品ID")]
        [Description("产品ID")]
        public Int32? productid {
            get {
                return this._productid;
            }
            set {
                if ((this._productid != value)) {
                    this.OnproductidChanging(value);
                    this.SendPropertyChanging("productid", value);
                    this._productid = value;
                    this.SendPropertyChanged("productid", value);
                    this.OnproductidChanged();
                }
            }
        }
        /// <summary>
        /// 产品编号(系统编号)
        /// </summary>
        [Column(Storage="_productno", DbType="varchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("产品编号(系统编号)")]
        [Description("产品编号(系统编号)")]
        public String productno {
            get {
                return this._productno;
            }
            set {
                this.OnproductnoChanging(value);
                this.SendPropertyChanging("productno", value);
                this._productno = value;
                this.SendPropertyChanged("productno", value);
                this.OnproductnoChanged();
            }
        }
        /// <summary>
        /// 产品SKU（厂家编号）
        /// </summary>
        [Column(Storage="_productsku", DbType="varchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("产品SKU（厂家编号）")]
        [Description("产品SKU（厂家编号）")]
        public String productsku {
            get {
                return this._productsku;
            }
            set {
                this.OnproductskuChanging(value);
                this.SendPropertyChanging("productsku", value);
                this._productsku = value;
                this.SendPropertyChanged("productsku", value);
                this.OnproductskuChanged();
            }
        }
        /// <summary>
        /// 产品类型（ ）config表值(其它类型=0)
        /// </summary>
        [Column(Storage="_typevalue", DbType="nvarchar(50)")]
        [DisplayName("产品类型（ ）config表值(其它类型=0)")]
        [Description("产品类型（ ）config表值(其它类型=0)")]
        public String typevalue {
            get {
                return this._typevalue;
            }
            set {
                if ((this._typevalue != value)) {
                    this.OntypevalueChanging(value);
                    this.SendPropertyChanging("typevalue", value);
                    this._typevalue = value;
                    this.SendPropertyChanged("typevalue", value);
                    this.OntypevalueChanged();
                }
            }
        }
        /// <summary>
        /// 产吕类型名称()
        /// </summary>
        [Column(Storage="_typename", DbType="nvarchar(50)")]
        [DisplayName("产吕类型名称()")]
        [Description("产吕类型名称()")]
        public String typename {
            get {
                return this._typename;
            }
            set {
                if ((this._typename != value)) {
                    this.OntypenameChanging(value);
                    this.SendPropertyChanging("typename", value);
                    this._typename = value;
                    this.SendPropertyChanged("typename", value);
                    this.OntypenameChanged();
                }
            }
        }
        /// <summary>
        /// 产品风格
        /// </summary>
        [Column(Storage="_productstyle", DbType="nvarchar(50)")]
        [DisplayName("产品风格")]
        [Description("产品风格")]
        public String productstyle {
            get {
                return this._productstyle;
            }
            set {
                if ((this._productstyle != value)) {
                    this.OnproductstyleChanging(value);
                    this.SendPropertyChanging("productstyle", value);
                    this._productstyle = value;
                    this.SendPropertyChanged("productstyle", value);
                    this.OnproductstyleChanged();
                }
            }
        }
        /// <summary>
        /// 材质
        /// </summary>
        [Column(Storage="_productmaterial", DbType="nvarchar(50)")]
        [DisplayName("材质")]
        [Description("材质")]
        public String productmaterial {
            get {
                return this._productmaterial;
            }
            set {
                if ((this._productmaterial != value)) {
                    this.OnproductmaterialChanging(value);
                    this.SendPropertyChanging("productmaterial", value);
                    this._productmaterial = value;
                    this.SendPropertyChanged("productmaterial", value);
                    this.OnproductmaterialChanged();
                }
            }
        }
        /// <summary>
        /// 颜色图片
        /// </summary>
        [Column(Storage="_productcolorimg", DbType="varchar(60)")]
        [DisplayName("颜色图片")]
        [Description("颜色图片")]
        public String productcolorimg {
            get {
                return this._productcolorimg;
            }
            set {
                if ((this._productcolorimg != value)) {
                    this.OnproductcolorimgChanging(value);
                    this.SendPropertyChanging("productcolorimg", value);
                    this._productcolorimg = value;
                    this.SendPropertyChanged("productcolorimg", value);
                    this.OnproductcolorimgChanged();
                }
            }
        }
        /// <summary>
        /// 颜色名称
        /// </summary>
        [Column(Storage="_productcolortitle", DbType="nvarchar(50)")]
        [DisplayName("颜色名称")]
        [Description("颜色名称")]
        public String productcolortitle {
            get {
                return this._productcolortitle;
            }
            set {
                if ((this._productcolortitle != value)) {
                    this.OnproductcolortitleChanging(value);
                    this.SendPropertyChanging("productcolortitle", value);
                    this._productcolortitle = value;
                    this.SendPropertyChanged("productcolortitle", value);
                    this.OnproductcolortitleChanged();
                }
            }
        }
        /// <summary>
        /// 颜色色值
        /// </summary>
        [Column(Storage="_productcolorvalue", DbType="nvarchar(50)")]
        [DisplayName("颜色色值")]
        [Description("颜色色值")]
        public String productcolorvalue {
            get {
                return this._productcolorvalue;
            }
            set {
                if ((this._productcolorvalue != value)) {
                    this.OnproductcolorvalueChanging(value);
                    this.SendPropertyChanging("productcolorvalue", value);
                    this._productcolorvalue = value;
                    this.SendPropertyChanged("productcolorvalue", value);
                    this.OnproductcolorvalueChanged();
                }
            }
        }
        /// <summary>
        /// 宽
        /// </summary>
        [Column(Storage="_productwidth", DbType="decimal")]
        [DisplayName("宽")]
        [Description("宽")]
        public Decimal? productwidth {
            get {
                return this._productwidth;
            }
            set {
                if ((this._productwidth != value)) {
                    this.OnproductwidthChanging(value);
                    this.SendPropertyChanging("productwidth", value);
                    this._productwidth = value;
                    this.SendPropertyChanged("productwidth", value);
                    this.OnproductwidthChanged();
                }
            }
        }
        /// <summary>
        /// 高
        /// </summary>
        [Column(Storage="_productheight", DbType="decimal")]
        [DisplayName("高")]
        [Description("高")]
        public Decimal? productheight {
            get {
                return this._productheight;
            }
            set {
                if ((this._productheight != value)) {
                    this.OnproductheightChanging(value);
                    this.SendPropertyChanging("productheight", value);
                    this._productheight = value;
                    this.SendPropertyChanged("productheight", value);
                    this.OnproductheightChanged();
                }
            }
        }
        /// <summary>
        /// 长
        /// </summary>
        [Column(Storage="_productlength", DbType="decimal")]
        [DisplayName("长")]
        [Description("长")]
        public Decimal? productlength {
            get {
                return this._productlength;
            }
            set {
                if ((this._productlength != value)) {
                    this.OnproductlengthChanging(value);
                    this.SendPropertyChanging("productlength", value);
                    this._productlength = value;
                    this.SendPropertyChanged("productlength", value);
                    this.OnproductlengthChanged();
                }
            }
        }
        /// <summary>
        /// 体积
        /// </summary>
        [Column(Storage="_productcbm", DbType="decimal")]
        [DisplayName("体积")]
        [Description("体积")]
        public Decimal? productcbm {
            get {
                return this._productcbm;
            }
            set {
                if ((this._productcbm != value)) {
                    this.OnproductcbmChanging(value);
                    this.SendPropertyChanging("productcbm", value);
                    this._productcbm = value;
                    this.SendPropertyChanged("productcbm", value);
                    this.OnproductcbmChanged();
                }
            }
        }
        /// <summary>
        /// 采购价
        /// </summary>
        [Column(Storage="_buyprice", DbType="decimal")]
        [DisplayName("采购价")]
        [Description("采购价")]
        public Decimal? buyprice {
            get {
                return this._buyprice;
            }
            set {
                if ((this._buyprice != value)) {
                    this.OnbuypriceChanging(value);
                    this.SendPropertyChanging("buyprice", value);
                    this._buyprice = value;
                    this.SendPropertyChanged("buyprice", value);
                    this.OnbuypriceChanged();
                }
            }
        }
        /// <summary>
        /// 市场价
        /// </summary>
        [Column(Storage="_markprice", DbType="decimal")]
        [DisplayName("市场价")]
        [Description("市场价")]
        public Decimal? markprice {
            get {
                return this._markprice;
            }
            set {
                if ((this._markprice != value)) {
                    this.OnmarkpriceChanging(value);
                    this.SendPropertyChanging("markprice", value);
                    this._markprice = value;
                    this.SendPropertyChanged("markprice", value);
                    this.OnmarkpriceChanged();
                }
            }
        }
        /// <summary>
        /// 销售价
        /// </summary>
        [Column(Storage="_saleprice", DbType="decimal")]
        [DisplayName("销售价")]
        [Description("销售价")]
        public Decimal? saleprice {
            get {
                return this._saleprice;
            }
            set {
                if ((this._saleprice != value)) {
                    this.OnsalepriceChanging(value);
                    this.SendPropertyChanging("saleprice", value);
                    this._saleprice = value;
                    this.SendPropertyChanged("saleprice", value);
                    this.OnsalepriceChanged();
                }
            }
        }
        /// <summary>
        /// 其它信息
        /// </summary>
        [Column(Storage="_otherinfo", DbType="ntext")]
        [DisplayName("其它信息")]
        [Description("其它信息")]
        public String otherinfo {
            get {
                return this._otherinfo;
            }
            set {
                if ((this._otherinfo != value)) {
                    this.OnotherinfoChanging(value);
                    this.SendPropertyChanging("otherinfo", value);
                    this._otherinfo = value;
                    this.SendPropertyChanged("otherinfo", value);
                    this.OnotherinfoChanged();
                }
            }
        }
        /// <summary>
        /// 库存
        /// </summary>
        [Column(Storage="_storage", DbType="int")]
        [DisplayName("库存")]
        [Description("库存")]
        public Int32? storage {
            get {
                return this._storage;
            }
            set {
                if ((this._storage != value)) {
                    this.OnstorageChanging(value);
                    this.SendPropertyChanging("storage", value);
                    this._storage = value;
                    this.SendPropertyChanged("storage", value);
                    this.OnstorageChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 是否默认
        /// </summary>
        [Column(Storage="_isdefault", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("是否默认")]
        [Description("是否默认")]
        public Int32 isdefault {
            get {
                return this._isdefault;
            }
            set {
                this.OnisdefaultChanging(value);
                this.SendPropertyChanging("isdefault", value);
                this._isdefault = value;
                this.SendPropertyChanged("isdefault", value);
                this.OnisdefaultChanged();
            }
        }
    }
    /// <summary>
    /// 产品分类表
    /// </summary>
    [Table(Name="t_productcategory")]
    [Serializable()]
    [DisplayName("产品分类表")]
    [Description("产品分类表")]
    public partial class Mproductcategory : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 索引
        /// </summary>
        String _letter;
        /// <summary>
        /// 路径名称/chuang/
        /// </summary>
        String _rewritetitle;
        /// <summary>
        /// 上级ID
        /// </summary>
        Int32? _parentid;
        /// <summary>
        /// 左值
        /// </summary>
        Int32? _lft;
        /// <summary>
        /// 右值
        /// </summary>
        Int32? _rgt;
        /// <summary>
        /// 层级
        /// </summary>
        Int32? _lev;
        /// <summary>
        /// 深度
        /// </summary>
        String _depth;
        /// <summary>
        /// 外观图
        /// </summary>
        String _surface;
        /// <summary>
        /// 缩略图
        /// </summary>
        String _thumb;
        /// <summary>
        /// 幻灯图
        /// </summary>
        String _bannel;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 关键字
        /// </summary>
        String _keywords;
        /// <summary>
        /// 模版
        /// </summary>
        String _template;
        /// <summary>
        /// 点击量
        /// </summary>
        Int32? _hits;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 上下级状态
        /// </summary>
        Int32? _linestatus;
        /// <summary>
        /// 创建人ID
        /// </summary>
        Int32? _createmid;
        /// <summary>
        /// 修改人ID
        /// </summary>
        Int32? _lastedid;
        /// <summary>
        /// 修改时间
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        /// 页标题
        /// </summary>
        String _pagetitle;
        /// <summary>
        /// 描述
        /// </summary>
        String _description;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 letter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnletterChanging(String value);
        /// <summary>
        /// 当 letter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnletterChanged();
        /// <summary>
        /// 当 rewritetitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnrewritetitleChanging(String value);
        /// <summary>
        /// 当 rewritetitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnrewritetitleChanged();
        /// <summary>
        /// 当 parentid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnparentidChanging(Int32? value);
        /// <summary>
        /// 当 parentid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnparentidChanged();
        /// <summary>
        /// 当 lft 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlftChanging(Int32? value);
        /// <summary>
        /// 当 lft 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlftChanged();
        /// <summary>
        /// 当 rgt 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnrgtChanging(Int32? value);
        /// <summary>
        /// 当 rgt 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnrgtChanged();
        /// <summary>
        /// 当 lev 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlevChanging(Int32? value);
        /// <summary>
        /// 当 lev 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlevChanged();
        /// <summary>
        /// 当 depth 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndepthChanging(String value);
        /// <summary>
        /// 当 depth 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndepthChanged();
        /// <summary>
        /// 当 surface 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsurfaceChanging(String value);
        /// <summary>
        /// 当 surface 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsurfaceChanged();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 bannel 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannelChanging(String value);
        /// <summary>
        /// 当 bannel 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannelChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 keywords 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnkeywordsChanging(String value);
        /// <summary>
        /// 当 keywords 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnkeywordsChanged();
        /// <summary>
        /// 当 template 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntemplateChanging(String value);
        /// <summary>
        /// 当 template 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntemplateChanged();
        /// <summary>
        /// 当 hits 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhitsChanging(Int32? value);
        /// <summary>
        /// 当 hits 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhitsChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 linestatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinestatusChanging(Int32? value);
        /// <summary>
        /// 当 linestatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinestatusChanged();
        /// <summary>
        /// 当 createmid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatemidChanging(Int32? value);
        /// <summary>
        /// 当 createmid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatemidChanged();
        /// <summary>
        /// 当 lastedid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedidChanging(Int32? value);
        /// <summary>
        /// 当 lastedid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedidChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        /// <summary>
        /// 当 pagetitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpagetitleChanging(String value);
        /// <summary>
        /// 当 pagetitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpagetitleChanged();
        /// <summary>
        /// 当 description 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptionChanging(String value);
        /// <summary>
        /// 当 description 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptionChanged();
        
        /// <summary>
        /// 初始化 Mproductcategory 实体类的新实例。
        /// </summary>
        public Mproductcategory() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(80) NOT NULL", CanBeNull=false)]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 索引
        /// </summary>
        [Column(Storage="_letter", DbType="varchar(20)")]
        [DisplayName("索引")]
        [Description("索引")]
        public String letter {
            get {
                return this._letter;
            }
            set {
                if ((this._letter != value)) {
                    this.OnletterChanging(value);
                    this.SendPropertyChanging("letter", value);
                    this._letter = value;
                    this.SendPropertyChanged("letter", value);
                    this.OnletterChanged();
                }
            }
        }
        /// <summary>
        /// 路径名称/chuang/
        /// </summary>
        [Column(Storage="_rewritetitle", DbType="varchar(20)")]
        [DisplayName("路径名称/chuang/")]
        [Description("路径名称/chuang/")]
        public String rewritetitle {
            get {
                return this._rewritetitle;
            }
            set {
                if ((this._rewritetitle != value)) {
                    this.OnrewritetitleChanging(value);
                    this.SendPropertyChanging("rewritetitle", value);
                    this._rewritetitle = value;
                    this.SendPropertyChanged("rewritetitle", value);
                    this.OnrewritetitleChanged();
                }
            }
        }
        /// <summary>
        /// 上级ID
        /// </summary>
        [Column(Storage="_parentid", DbType="int")]
        [DisplayName("上级ID")]
        [Description("上级ID")]
        public Int32? parentid {
            get {
                return this._parentid;
            }
            set {
                if ((this._parentid != value)) {
                    this.OnparentidChanging(value);
                    this.SendPropertyChanging("parentid", value);
                    this._parentid = value;
                    this.SendPropertyChanged("parentid", value);
                    this.OnparentidChanged();
                }
            }
        }
        /// <summary>
        /// 左值
        /// </summary>
        [Column(Storage="_lft", DbType="int")]
        [DisplayName("左值")]
        [Description("左值")]
        public Int32? lft {
            get {
                return this._lft;
            }
            set {
                if ((this._lft != value)) {
                    this.OnlftChanging(value);
                    this.SendPropertyChanging("lft", value);
                    this._lft = value;
                    this.SendPropertyChanged("lft", value);
                    this.OnlftChanged();
                }
            }
        }
        /// <summary>
        /// 右值
        /// </summary>
        [Column(Storage="_rgt", DbType="int")]
        [DisplayName("右值")]
        [Description("右值")]
        public Int32? rgt {
            get {
                return this._rgt;
            }
            set {
                if ((this._rgt != value)) {
                    this.OnrgtChanging(value);
                    this.SendPropertyChanging("rgt", value);
                    this._rgt = value;
                    this.SendPropertyChanged("rgt", value);
                    this.OnrgtChanged();
                }
            }
        }
        /// <summary>
        /// 层级
        /// </summary>
        [Column(Storage="_lev", DbType="int")]
        [DisplayName("层级")]
        [Description("层级")]
        public Int32? lev {
            get {
                return this._lev;
            }
            set {
                if ((this._lev != value)) {
                    this.OnlevChanging(value);
                    this.SendPropertyChanging("lev", value);
                    this._lev = value;
                    this.SendPropertyChanged("lev", value);
                    this.OnlevChanged();
                }
            }
        }
        /// <summary>
        /// 深度
        /// </summary>
        [Column(Storage="_depth", DbType="varchar(200)")]
        [DisplayName("深度")]
        [Description("深度")]
        public String depth {
            get {
                return this._depth;
            }
            set {
                if ((this._depth != value)) {
                    this.OndepthChanging(value);
                    this.SendPropertyChanging("depth", value);
                    this._depth = value;
                    this.SendPropertyChanged("depth", value);
                    this.OndepthChanged();
                }
            }
        }
        /// <summary>
        /// 外观图
        /// </summary>
        [Column(Storage="_surface", DbType="varchar(200)")]
        [DisplayName("外观图")]
        [Description("外观图")]
        public String surface {
            get {
                return this._surface;
            }
            set {
                if ((this._surface != value)) {
                    this.OnsurfaceChanging(value);
                    this.SendPropertyChanging("surface", value);
                    this._surface = value;
                    this.SendPropertyChanged("surface", value);
                    this.OnsurfaceChanged();
                }
            }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(40)")]
        [DisplayName("缩略图")]
        [Description("缩略图")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        /// 幻灯图
        /// </summary>
        [Column(Storage="_bannel", DbType="varchar(300)")]
        [DisplayName("幻灯图")]
        [Description("幻灯图")]
        public String bannel {
            get {
                return this._bannel;
            }
            set {
                if ((this._bannel != value)) {
                    this.OnbannelChanging(value);
                    this.SendPropertyChanging("bannel", value);
                    this._bannel = value;
                    this.SendPropertyChanged("bannel", value);
                    this.OnbannelChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="ntext")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        [Column(Storage="_keywords", DbType="nvarchar(200)")]
        [DisplayName("关键字")]
        [Description("关键字")]
        public String keywords {
            get {
                return this._keywords;
            }
            set {
                if ((this._keywords != value)) {
                    this.OnkeywordsChanging(value);
                    this.SendPropertyChanging("keywords", value);
                    this._keywords = value;
                    this.SendPropertyChanged("keywords", value);
                    this.OnkeywordsChanged();
                }
            }
        }
        /// <summary>
        /// 模版
        /// </summary>
        [Column(Storage="_template", DbType="varchar(50)")]
        [DisplayName("模版")]
        [Description("模版")]
        public String template {
            get {
                return this._template;
            }
            set {
                if ((this._template != value)) {
                    this.OntemplateChanging(value);
                    this.SendPropertyChanging("template", value);
                    this._template = value;
                    this.SendPropertyChanged("template", value);
                    this.OntemplateChanged();
                }
            }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        [Column(Storage="_hits", DbType="int")]
        [DisplayName("点击量")]
        [Description("点击量")]
        public Int32? hits {
            get {
                return this._hits;
            }
            set {
                if ((this._hits != value)) {
                    this.OnhitsChanging(value);
                    this.SendPropertyChanging("hits", value);
                    this._hits = value;
                    this.SendPropertyChanged("hits", value);
                    this.OnhitsChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 上下级状态
        /// </summary>
        [Column(Storage="_linestatus", DbType="int")]
        [DisplayName("上下级状态")]
        [Description("上下级状态")]
        public Int32? linestatus {
            get {
                return this._linestatus;
            }
            set {
                if ((this._linestatus != value)) {
                    this.OnlinestatusChanging(value);
                    this.SendPropertyChanging("linestatus", value);
                    this._linestatus = value;
                    this.SendPropertyChanged("linestatus", value);
                    this.OnlinestatusChanged();
                }
            }
        }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column(Storage="_createmid", DbType="int")]
        [DisplayName("创建人ID")]
        [Description("创建人ID")]
        public Int32? createmid {
            get {
                return this._createmid;
            }
            set {
                if ((this._createmid != value)) {
                    this.OncreatemidChanging(value);
                    this.SendPropertyChanging("createmid", value);
                    this._createmid = value;
                    this.SendPropertyChanged("createmid", value);
                    this.OncreatemidChanged();
                }
            }
        }
        /// <summary>
        /// 修改人ID
        /// </summary>
        [Column(Storage="_lastedid", DbType="int")]
        [DisplayName("修改人ID")]
        [Description("修改人ID")]
        public Int32? lastedid {
            get {
                return this._lastedid;
            }
            set {
                if ((this._lastedid != value)) {
                    this.OnlastedidChanging(value);
                    this.SendPropertyChanging("lastedid", value);
                    this._lastedid = value;
                    this.SendPropertyChanged("lastedid", value);
                    this.OnlastedidChanged();
                }
            }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("修改时间")]
        [Description("修改时间")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
        /// <summary>
        /// 页标题
        /// </summary>
        [Column(Storage="_pagetitle", DbType="varchar(200)")]
        [DisplayName("页标题")]
        [Description("页标题")]
        public String pagetitle {
            get {
                return this._pagetitle;
            }
            set {
                if ((this._pagetitle != value)) {
                    this.OnpagetitleChanging(value);
                    this.SendPropertyChanging("pagetitle", value);
                    this._pagetitle = value;
                    this.SendPropertyChanged("pagetitle", value);
                    this.OnpagetitleChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_description", DbType="varchar(200)")]
        [DisplayName("描述")]
        [Description("描述")]
        public String description {
            get {
                return this._description;
            }
            set {
                if ((this._description != value)) {
                    this.OndescriptionChanging(value);
                    this.SendPropertyChanging("description", value);
                    this._description = value;
                    this.SendPropertyChanged("description", value);
                    this.OndescriptionChanged();
                }
            }
        }
    }
    /// <summary>
    /// 产品内容表
    /// </summary>
    [Table(Name="t_productcon")]
    [Serializable()]
    [DisplayName("产品内容表")]
    [Description("产品内容表")]
    public partial class Mproductcon : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 产品ID
        /// </summary>
        Int32? _productid;
        /// <summary>
        ///  
        /// </summary>
        Int32? _contype;
        /// <summary>
        ///  
        /// </summary>
        String _con;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 productid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductidChanging(Int32? value);
        /// <summary>
        /// 当 productid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductidChanged();
        /// <summary>
        /// 当 contype 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncontypeChanging(Int32? value);
        /// <summary>
        /// 当 contype 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncontypeChanged();
        /// <summary>
        /// 当 con 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnconChanging(String value);
        /// <summary>
        /// 当 con 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnconChanged();
        
        /// <summary>
        /// 初始化 Mproductcon 实体类的新实例。
        /// </summary>
        public Mproductcon() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 产品ID
        /// </summary>
        [Column(Storage="_productid", DbType="int")]
        [DisplayName("产品ID")]
        [Description("产品ID")]
        public Int32? productid {
            get {
                return this._productid;
            }
            set {
                if ((this._productid != value)) {
                    this.OnproductidChanging(value);
                    this.SendPropertyChanging("productid", value);
                    this._productid = value;
                    this.SendPropertyChanged("productid", value);
                    this.OnproductidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_contype", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? contype {
            get {
                return this._contype;
            }
            set {
                if ((this._contype != value)) {
                    this.OncontypeChanging(value);
                    this.SendPropertyChanging("contype", value);
                    this._contype = value;
                    this.SendPropertyChanged("contype", value);
                    this.OncontypeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_con", DbType="ntext")]
        [DisplayName(" ")]
        [Description(" ")]
        public String con {
            get {
                return this._con;
            }
            set {
                if ((this._con != value)) {
                    this.OnconChanging(value);
                    this.SendPropertyChanging("con", value);
                    this._con = value;
                    this.SendPropertyChanged("con", value);
                    this.OnconChanged();
                }
            }
        }
    }
    /// <summary>
    ///  
    /// </summary>
    [Table(Name="t_promotion")]
    [Serializable()]
    [DisplayName(" ")]
    [Description(" ")]
    public partial class Mpromotion : DALModelBase {
        /// <summary>
        ///  
        /// </summary>
        Int32 _id;
        /// <summary>
        ///  
        /// </summary>
        String _title;
        /// <summary>
        ///  
        /// </summary>
        String _htmltitle;
        /// <summary>
        ///  
        /// </summary>
        String _letter;
        /// <summary>
        ///  
        /// </summary>
        String _attribute;
        /// <summary>
        ///  
        /// </summary>
        Int32? _ptype;
        /// <summary>
        ///  
        /// </summary>
        DateTime? _startdatetime;
        /// <summary>
        ///  
        /// </summary>
        DateTime? _enddatetime;
        /// <summary>
        ///  
        /// </summary>
        String _areacode;
        /// <summary>
        ///  
        /// </summary>
        String _address;
        /// <summary>
        ///  
        /// </summary>
        String _surface;
        /// <summary>
        ///  
        /// </summary>
        String _logo;
        /// <summary>
        ///  
        /// </summary>
        String _thumb;
        /// <summary>
        ///  
        /// </summary>
        String _bannel;
        /// <summary>
        ///  
        /// </summary>
        String _desimage;
        /// <summary>
        ///  
        /// </summary>
        String _descript;
        /// <summary>
        ///  
        /// </summary>
        String _keywords;
        /// <summary>
        ///  
        /// </summary>
        String _template;
        /// <summary>
        ///  
        /// </summary>
        Int32? _hits;
        /// <summary>
        ///  
        /// </summary>
        Int32? _sort;
        /// <summary>
        ///  
        /// </summary>
        Int32? _createmid;
        /// <summary>
        ///  
        /// </summary>
        Int32? _lastedid;
        /// <summary>
        ///  
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        ///  
        /// </summary>
        Int32 _auditstatus;
        /// <summary>
        ///  
        /// </summary>
        Int32 _linestatus;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 htmltitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhtmltitleChanging(String value);
        /// <summary>
        /// 当 htmltitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhtmltitleChanged();
        /// <summary>
        /// 当 letter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnletterChanging(String value);
        /// <summary>
        /// 当 letter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnletterChanged();
        /// <summary>
        /// 当 attribute 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnattributeChanging(String value);
        /// <summary>
        /// 当 attribute 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnattributeChanged();
        /// <summary>
        /// 当 ptype 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnptypeChanging(Int32? value);
        /// <summary>
        /// 当 ptype 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnptypeChanged();
        /// <summary>
        /// 当 startdatetime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstartdatetimeChanging(DateTime? value);
        /// <summary>
        /// 当 startdatetime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstartdatetimeChanged();
        /// <summary>
        /// 当 enddatetime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnenddatetimeChanging(DateTime? value);
        /// <summary>
        /// 当 enddatetime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnenddatetimeChanged();
        /// <summary>
        /// 当 areacode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnareacodeChanging(String value);
        /// <summary>
        /// 当 areacode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnareacodeChanged();
        /// <summary>
        /// 当 address 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaddressChanging(String value);
        /// <summary>
        /// 当 address 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaddressChanged();
        /// <summary>
        /// 当 surface 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsurfaceChanging(String value);
        /// <summary>
        /// 当 surface 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsurfaceChanged();
        /// <summary>
        /// 当 logo 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlogoChanging(String value);
        /// <summary>
        /// 当 logo 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlogoChanged();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 bannel 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannelChanging(String value);
        /// <summary>
        /// 当 bannel 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannelChanged();
        /// <summary>
        /// 当 desimage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndesimageChanging(String value);
        /// <summary>
        /// 当 desimage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndesimageChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 keywords 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnkeywordsChanging(String value);
        /// <summary>
        /// 当 keywords 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnkeywordsChanged();
        /// <summary>
        /// 当 template 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntemplateChanging(String value);
        /// <summary>
        /// 当 template 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntemplateChanged();
        /// <summary>
        /// 当 hits 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhitsChanging(Int32? value);
        /// <summary>
        /// 当 hits 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhitsChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 createmid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatemidChanging(Int32? value);
        /// <summary>
        /// 当 createmid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatemidChanged();
        /// <summary>
        /// 当 lastedid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedidChanging(Int32? value);
        /// <summary>
        /// 当 lastedid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedidChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        /// <summary>
        /// 当 auditstatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauditstatusChanging(Int32 value);
        /// <summary>
        /// 当 auditstatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauditstatusChanged();
        /// <summary>
        /// 当 linestatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinestatusChanging(Int32 value);
        /// <summary>
        /// 当 linestatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinestatusChanged();
        
        /// <summary>
        /// 初始化 Mpromotion 实体类的新实例。
        /// </summary>
        public Mpromotion() {
            this.OnCreated();
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(80) NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_htmltitle", DbType="nvarchar(500)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String htmltitle {
            get {
                return this._htmltitle;
            }
            set {
                if ((this._htmltitle != value)) {
                    this.OnhtmltitleChanging(value);
                    this.SendPropertyChanging("htmltitle", value);
                    this._htmltitle = value;
                    this.SendPropertyChanged("htmltitle", value);
                    this.OnhtmltitleChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_letter", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String letter {
            get {
                return this._letter;
            }
            set {
                if ((this._letter != value)) {
                    this.OnletterChanging(value);
                    this.SendPropertyChanging("letter", value);
                    this._letter = value;
                    this.SendPropertyChanged("letter", value);
                    this.OnletterChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_attribute", DbType="varchar(100)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String attribute {
            get {
                return this._attribute;
            }
            set {
                if ((this._attribute != value)) {
                    this.OnattributeChanging(value);
                    this.SendPropertyChanging("attribute", value);
                    this._attribute = value;
                    this.SendPropertyChanged("attribute", value);
                    this.OnattributeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_ptype", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? ptype {
            get {
                return this._ptype;
            }
            set {
                if ((this._ptype != value)) {
                    this.OnptypeChanging(value);
                    this.SendPropertyChanging("ptype", value);
                    this._ptype = value;
                    this.SendPropertyChanged("ptype", value);
                    this.OnptypeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_startdatetime", DbType="datetime")]
        [DisplayName(" ")]
        [Description(" ")]
        public DateTime? startdatetime {
            get {
                return this._startdatetime;
            }
            set {
                if ((this._startdatetime != value)) {
                    this.OnstartdatetimeChanging(value);
                    this.SendPropertyChanging("startdatetime", value);
                    this._startdatetime = value;
                    this.SendPropertyChanged("startdatetime", value);
                    this.OnstartdatetimeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_enddatetime", DbType="datetime")]
        [DisplayName(" ")]
        [Description(" ")]
        public DateTime? enddatetime {
            get {
                return this._enddatetime;
            }
            set {
                if ((this._enddatetime != value)) {
                    this.OnenddatetimeChanging(value);
                    this.SendPropertyChanging("enddatetime", value);
                    this._enddatetime = value;
                    this.SendPropertyChanged("enddatetime", value);
                    this.OnenddatetimeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_areacode", DbType="varchar(10)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String areacode {
            get {
                return this._areacode;
            }
            set {
                if ((this._areacode != value)) {
                    this.OnareacodeChanging(value);
                    this.SendPropertyChanging("areacode", value);
                    this._areacode = value;
                    this.SendPropertyChanged("areacode", value);
                    this.OnareacodeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_address", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String address {
            get {
                return this._address;
            }
            set {
                if ((this._address != value)) {
                    this.OnaddressChanging(value);
                    this.SendPropertyChanging("address", value);
                    this._address = value;
                    this.SendPropertyChanged("address", value);
                    this.OnaddressChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_surface", DbType="varchar(200)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String surface {
            get {
                return this._surface;
            }
            set {
                if ((this._surface != value)) {
                    this.OnsurfaceChanging(value);
                    this.SendPropertyChanging("surface", value);
                    this._surface = value;
                    this.SendPropertyChanged("surface", value);
                    this.OnsurfaceChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_logo", DbType="varchar(40)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String logo {
            get {
                return this._logo;
            }
            set {
                if ((this._logo != value)) {
                    this.OnlogoChanging(value);
                    this.SendPropertyChanging("logo", value);
                    this._logo = value;
                    this.SendPropertyChanged("logo", value);
                    this.OnlogoChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(40)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_bannel", DbType="varchar(300)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String bannel {
            get {
                return this._bannel;
            }
            set {
                if ((this._bannel != value)) {
                    this.OnbannelChanging(value);
                    this.SendPropertyChanging("bannel", value);
                    this._bannel = value;
                    this.SendPropertyChanged("bannel", value);
                    this.OnbannelChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_desimage", DbType="varchar(400)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String desimage {
            get {
                return this._desimage;
            }
            set {
                if ((this._desimage != value)) {
                    this.OndesimageChanging(value);
                    this.SendPropertyChanging("desimage", value);
                    this._desimage = value;
                    this.SendPropertyChanged("desimage", value);
                    this.OndesimageChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_descript", DbType="ntext")]
        [DisplayName(" ")]
        [Description(" ")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_keywords", DbType="nvarchar(200)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String keywords {
            get {
                return this._keywords;
            }
            set {
                if ((this._keywords != value)) {
                    this.OnkeywordsChanging(value);
                    this.SendPropertyChanging("keywords", value);
                    this._keywords = value;
                    this.SendPropertyChanged("keywords", value);
                    this.OnkeywordsChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_template", DbType="varchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String template {
            get {
                return this._template;
            }
            set {
                if ((this._template != value)) {
                    this.OntemplateChanging(value);
                    this.SendPropertyChanging("template", value);
                    this._template = value;
                    this.SendPropertyChanged("template", value);
                    this.OntemplateChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_hits", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? hits {
            get {
                return this._hits;
            }
            set {
                if ((this._hits != value)) {
                    this.OnhitsChanging(value);
                    this.SendPropertyChanging("hits", value);
                    this._hits = value;
                    this.SendPropertyChanged("hits", value);
                    this.OnhitsChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_createmid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? createmid {
            get {
                return this._createmid;
            }
            set {
                if ((this._createmid != value)) {
                    this.OncreatemidChanging(value);
                    this.SendPropertyChanging("createmid", value);
                    this._createmid = value;
                    this.SendPropertyChanged("createmid", value);
                    this.OncreatemidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_lastedid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? lastedid {
            get {
                return this._lastedid;
            }
            set {
                if ((this._lastedid != value)) {
                    this.OnlastedidChanging(value);
                    this.SendPropertyChanging("lastedid", value);
                    this._lastedid = value;
                    this.SendPropertyChanged("lastedid", value);
                    this.OnlastedidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_auditstatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 auditstatus {
            get {
                return this._auditstatus;
            }
            set {
                this.OnauditstatusChanging(value);
                this.SendPropertyChanging("auditstatus", value);
                this._auditstatus = value;
                this.SendPropertyChanged("auditstatus", value);
                this.OnauditstatusChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_linestatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 linestatus {
            get {
                return this._linestatus;
            }
            set {
                this.OnlinestatusChanging(value);
                this.SendPropertyChanging("linestatus", value);
                this._linestatus = value;
                this.SendPropertyChanged("linestatus", value);
                this.OnlinestatusChanged();
            }
        }
    }
    /// <summary>
    /// 促销信息品牌关联表
    /// </summary>
    [Table(Name="t_promotionappbrand")]
    [Serializable()]
    [DisplayName("促销信息品牌关联表")]
    [Description("促销信息品牌关联表")]
    public partial class Mpromotionappbrand : DALModelBase {
        /// <summary>
        ///  
        /// </summary>
        Int32 _id;
        /// <summary>
        ///  
        /// </summary>
        String _title;
        /// <summary>
        ///  
        /// </summary>
        String _letter;
        /// <summary>
        ///  
        /// </summary>
        Int32? _bid;
        /// <summary>
        ///  
        /// </summary>
        String _blogo;
        /// <summary>
        ///  
        /// </summary>
        String _fordio;
        /// <summary>
        ///  
        /// </summary>
        Int32? _appcount;
        /// <summary>
        ///  
        /// </summary>
        Int32? _sort;
        /// <summary>
        ///  
        /// </summary>
        String _thumb;
        /// <summary>
        ///  
        /// </summary>
        String _banner;
        /// <summary>
        ///  
        /// </summary>
        String _htmltitle;
        /// <summary>
        ///  
        /// </summary>
        String _descript;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 letter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnletterChanging(String value);
        /// <summary>
        /// 当 letter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnletterChanged();
        /// <summary>
        /// 当 bid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbidChanging(Int32? value);
        /// <summary>
        /// 当 bid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbidChanged();
        /// <summary>
        /// 当 blogo 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnblogoChanging(String value);
        /// <summary>
        /// 当 blogo 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnblogoChanged();
        /// <summary>
        /// 当 fordio 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnfordioChanging(String value);
        /// <summary>
        /// 当 fordio 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnfordioChanged();
        /// <summary>
        /// 当 appcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnappcountChanging(Int32? value);
        /// <summary>
        /// 当 appcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnappcountChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 banner 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannerChanging(String value);
        /// <summary>
        /// 当 banner 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannerChanged();
        /// <summary>
        /// 当 htmltitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhtmltitleChanging(String value);
        /// <summary>
        /// 当 htmltitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhtmltitleChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        
        /// <summary>
        /// 初始化 Mpromotionappbrand 实体类的新实例。
        /// </summary>
        public Mpromotionappbrand() {
            this.OnCreated();
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String title {
            get {
                return this._title;
            }
            set {
                if ((this._title != value)) {
                    this.OntitleChanging(value);
                    this.SendPropertyChanging("title", value);
                    this._title = value;
                    this.SendPropertyChanged("title", value);
                    this.OntitleChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_letter", DbType="varchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String letter {
            get {
                return this._letter;
            }
            set {
                if ((this._letter != value)) {
                    this.OnletterChanging(value);
                    this.SendPropertyChanging("letter", value);
                    this._letter = value;
                    this.SendPropertyChanged("letter", value);
                    this.OnletterChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_bid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? bid {
            get {
                return this._bid;
            }
            set {
                if ((this._bid != value)) {
                    this.OnbidChanging(value);
                    this.SendPropertyChanging("bid", value);
                    this._bid = value;
                    this.SendPropertyChanged("bid", value);
                    this.OnbidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_blogo", DbType="varchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String blogo {
            get {
                return this._blogo;
            }
            set {
                if ((this._blogo != value)) {
                    this.OnblogoChanging(value);
                    this.SendPropertyChanging("blogo", value);
                    this._blogo = value;
                    this.SendPropertyChanged("blogo", value);
                    this.OnblogoChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_fordio", DbType="varchar(10)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String fordio {
            get {
                return this._fordio;
            }
            set {
                if ((this._fordio != value)) {
                    this.OnfordioChanging(value);
                    this.SendPropertyChanging("fordio", value);
                    this._fordio = value;
                    this.SendPropertyChanged("fordio", value);
                    this.OnfordioChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_appcount", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? appcount {
            get {
                return this._appcount;
            }
            set {
                if ((this._appcount != value)) {
                    this.OnappcountChanging(value);
                    this.SendPropertyChanging("appcount", value);
                    this._appcount = value;
                    this.SendPropertyChanged("appcount", value);
                    this.OnappcountChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_banner", DbType="varchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String banner {
            get {
                return this._banner;
            }
            set {
                if ((this._banner != value)) {
                    this.OnbannerChanging(value);
                    this.SendPropertyChanging("banner", value);
                    this._banner = value;
                    this.SendPropertyChanged("banner", value);
                    this.OnbannerChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_htmltitle", DbType="nvarchar(80)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String htmltitle {
            get {
                return this._htmltitle;
            }
            set {
                if ((this._htmltitle != value)) {
                    this.OnhtmltitleChanging(value);
                    this.SendPropertyChanging("htmltitle", value);
                    this._htmltitle = value;
                    this.SendPropertyChanged("htmltitle", value);
                    this.OnhtmltitleChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_descript", DbType="ntext")]
        [DisplayName(" ")]
        [Description(" ")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
    }
    /// <summary>
    /// 促销信息产品关联表
    /// </summary>
    [Table(Name="t_promotionappproduct")]
    [Serializable()]
    [DisplayName("促销信息产品关联表")]
    [Description("促销信息产品关联表")]
    public partial class Mpromotionappproduct : DALModelBase {
        /// <summary>
        ///  
        /// </summary>
        Int32 _id;
        /// <summary>
        ///  
        /// </summary>
        Int32? _mid;
        /// <summary>
        ///  
        /// </summary>
        String _name;
        /// <summary>
        ///  
        /// </summary>
        String _memail;
        /// <summary>
        ///  
        /// </summary>
        String _mphone;
        /// <summary>
        ///  
        /// </summary>
        Int32? _productid;
        /// <summary>
        ///  
        /// </summary>
        String _productname;
        /// <summary>
        ///  
        /// </summary>
        Int32? _materialid;
        /// <summary>
        ///  
        /// </summary>
        String _materialname;
        /// <summary>
        ///  
        /// </summary>
        String _sizevalue;
        /// <summary>
        ///  
        /// </summary>
        Int32? _brandid;
        /// <summary>
        ///  
        /// </summary>
        String _brandname;
        /// <summary>
        ///  
        /// </summary>
        DateTime? _addtime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 mid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmidChanging(Int32? value);
        /// <summary>
        /// 当 mid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmidChanged();
        /// <summary>
        /// 当 name 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnnameChanging(String value);
        /// <summary>
        /// 当 name 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnnameChanged();
        /// <summary>
        /// 当 memail 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmemailChanging(String value);
        /// <summary>
        /// 当 memail 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmemailChanged();
        /// <summary>
        /// 当 mphone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmphoneChanging(String value);
        /// <summary>
        /// 当 mphone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmphoneChanged();
        /// <summary>
        /// 当 productid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductidChanging(Int32? value);
        /// <summary>
        /// 当 productid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductidChanged();
        /// <summary>
        /// 当 productname 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductnameChanging(String value);
        /// <summary>
        /// 当 productname 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductnameChanged();
        /// <summary>
        /// 当 materialid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmaterialidChanging(Int32? value);
        /// <summary>
        /// 当 materialid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmaterialidChanged();
        /// <summary>
        /// 当 materialname 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmaterialnameChanging(String value);
        /// <summary>
        /// 当 materialname 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmaterialnameChanged();
        /// <summary>
        /// 当 sizevalue 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsizevalueChanging(String value);
        /// <summary>
        /// 当 sizevalue 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsizevalueChanged();
        /// <summary>
        /// 当 brandid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandidChanging(Int32? value);
        /// <summary>
        /// 当 brandid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandidChanged();
        /// <summary>
        /// 当 brandname 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandnameChanging(String value);
        /// <summary>
        /// 当 brandname 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandnameChanged();
        /// <summary>
        /// 当 addtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaddtimeChanging(DateTime? value);
        /// <summary>
        /// 当 addtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaddtimeChanged();
        
        /// <summary>
        /// 初始化 Mpromotionappproduct 实体类的新实例。
        /// </summary>
        public Mpromotionappproduct() {
            this.OnCreated();
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_mid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? mid {
            get {
                return this._mid;
            }
            set {
                if ((this._mid != value)) {
                    this.OnmidChanging(value);
                    this.SendPropertyChanging("mid", value);
                    this._mid = value;
                    this.SendPropertyChanged("mid", value);
                    this.OnmidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_name", DbType="nvarchar(30)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String name {
            get {
                return this._name;
            }
            set {
                if ((this._name != value)) {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging("name", value);
                    this._name = value;
                    this.SendPropertyChanged("name", value);
                    this.OnnameChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_memail", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String memail {
            get {
                return this._memail;
            }
            set {
                if ((this._memail != value)) {
                    this.OnmemailChanging(value);
                    this.SendPropertyChanging("memail", value);
                    this._memail = value;
                    this.SendPropertyChanged("memail", value);
                    this.OnmemailChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_mphone", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String mphone {
            get {
                return this._mphone;
            }
            set {
                if ((this._mphone != value)) {
                    this.OnmphoneChanging(value);
                    this.SendPropertyChanging("mphone", value);
                    this._mphone = value;
                    this.SendPropertyChanged("mphone", value);
                    this.OnmphoneChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_productid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? productid {
            get {
                return this._productid;
            }
            set {
                if ((this._productid != value)) {
                    this.OnproductidChanging(value);
                    this.SendPropertyChanging("productid", value);
                    this._productid = value;
                    this.SendPropertyChanged("productid", value);
                    this.OnproductidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_productname", DbType="nvarchar(200)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String productname {
            get {
                return this._productname;
            }
            set {
                if ((this._productname != value)) {
                    this.OnproductnameChanging(value);
                    this.SendPropertyChanging("productname", value);
                    this._productname = value;
                    this.SendPropertyChanged("productname", value);
                    this.OnproductnameChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_materialid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? materialid {
            get {
                return this._materialid;
            }
            set {
                if ((this._materialid != value)) {
                    this.OnmaterialidChanging(value);
                    this.SendPropertyChanging("materialid", value);
                    this._materialid = value;
                    this.SendPropertyChanged("materialid", value);
                    this.OnmaterialidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_materialname", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String materialname {
            get {
                return this._materialname;
            }
            set {
                if ((this._materialname != value)) {
                    this.OnmaterialnameChanging(value);
                    this.SendPropertyChanging("materialname", value);
                    this._materialname = value;
                    this.SendPropertyChanged("materialname", value);
                    this.OnmaterialnameChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_sizevalue", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String sizevalue {
            get {
                return this._sizevalue;
            }
            set {
                if ((this._sizevalue != value)) {
                    this.OnsizevalueChanging(value);
                    this.SendPropertyChanging("sizevalue", value);
                    this._sizevalue = value;
                    this.SendPropertyChanged("sizevalue", value);
                    this.OnsizevalueChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_brandid", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? brandid {
            get {
                return this._brandid;
            }
            set {
                if ((this._brandid != value)) {
                    this.OnbrandidChanging(value);
                    this.SendPropertyChanging("brandid", value);
                    this._brandid = value;
                    this.SendPropertyChanged("brandid", value);
                    this.OnbrandidChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_brandname", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String brandname {
            get {
                return this._brandname;
            }
            set {
                if ((this._brandname != value)) {
                    this.OnbrandnameChanging(value);
                    this.SendPropertyChanging("brandname", value);
                    this._brandname = value;
                    this.SendPropertyChanged("brandname", value);
                    this.OnbrandnameChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_addtime", DbType="datetime")]
        [DisplayName(" ")]
        [Description(" ")]
        public DateTime? addtime {
            get {
                return this._addtime;
            }
            set {
                if ((this._addtime != value)) {
                    this.OnaddtimeChanging(value);
                    this.SendPropertyChanging("addtime", value);
                    this._addtime = value;
                    this.SendPropertyChanged("addtime", value);
                    this.OnaddtimeChanged();
                }
            }
        }
    }
    /// <summary>
    ///  
    /// </summary>
    [Table(Name="t_promotiondef")]
    [Serializable()]
    [DisplayName(" ")]
    [Description(" ")]
    public partial class Mpromotiondef : DALModelBase {
        /// <summary>
        ///  
        /// </summary>
        Int32 _id;
        /// <summary>
        ///  
        /// </summary>
        String _title;
        /// <summary>
        ///  
        /// </summary>
        Int32 _pid;
        /// <summary>
        ///  
        /// </summary>
        String _attribute;
        /// <summary>
        ///  
        /// </summary>
        String _type;
        /// <summary>
        ///  
        /// </summary>
        String _value;
        /// <summary>
        ///  
        /// </summary>
        String _valueletter;
        /// <summary>
        ///  
        /// </summary>
        String _valuetitle;
        /// <summary>
        ///  
        /// </summary>
        String _thumb;
        /// <summary>
        ///  
        /// </summary>
        String _banner;
        /// <summary>
        ///  
        /// </summary>
        String _descript;
        /// <summary>
        ///  
        /// </summary>
        String _curcountmoney;
        /// <summary>
        ///  
        /// </summary>
        String _curcountpeople;
        /// <summary>
        ///  
        /// </summary>
        String _curstage;
        /// <summary>
        ///  
        /// </summary>
        String _fordio;
        /// <summary>
        ///  
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 pid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpidChanging(Int32 value);
        /// <summary>
        /// 当 pid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpidChanged();
        /// <summary>
        /// 当 attribute 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnattributeChanging(String value);
        /// <summary>
        /// 当 attribute 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnattributeChanged();
        /// <summary>
        /// 当 type 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntypeChanging(String value);
        /// <summary>
        /// 当 type 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntypeChanged();
        /// <summary>
        /// 当 value 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvalueChanging(String value);
        /// <summary>
        /// 当 value 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvalueChanged();
        /// <summary>
        /// 当 valueletter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvalueletterChanging(String value);
        /// <summary>
        /// 当 valueletter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvalueletterChanged();
        /// <summary>
        /// 当 valuetitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvaluetitleChanging(String value);
        /// <summary>
        /// 当 valuetitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvaluetitleChanged();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 banner 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannerChanging(String value);
        /// <summary>
        /// 当 banner 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannerChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 curcountmoney 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncurcountmoneyChanging(String value);
        /// <summary>
        /// 当 curcountmoney 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncurcountmoneyChanged();
        /// <summary>
        /// 当 curcountpeople 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncurcountpeopleChanging(String value);
        /// <summary>
        /// 当 curcountpeople 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncurcountpeopleChanged();
        /// <summary>
        /// 当 curstage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncurstageChanging(String value);
        /// <summary>
        /// 当 curstage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncurstageChanged();
        /// <summary>
        /// 当 fordio 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnfordioChanging(String value);
        /// <summary>
        /// 当 fordio 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnfordioChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Mpromotiondef 实体类的新实例。
        /// </summary>
        public Mpromotiondef() {
            this.OnCreated();
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(300)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String title {
            get {
                return this._title;
            }
            set {
                if ((this._title != value)) {
                    this.OntitleChanging(value);
                    this.SendPropertyChanging("title", value);
                    this._title = value;
                    this.SendPropertyChanged("title", value);
                    this.OntitleChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_pid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 pid {
            get {
                return this._pid;
            }
            set {
                this.OnpidChanging(value);
                this.SendPropertyChanging("pid", value);
                this._pid = value;
                this.SendPropertyChanged("pid", value);
                this.OnpidChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_attribute", DbType="varchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String attribute {
            get {
                return this._attribute;
            }
            set {
                if ((this._attribute != value)) {
                    this.OnattributeChanging(value);
                    this.SendPropertyChanging("attribute", value);
                    this._attribute = value;
                    this.SendPropertyChanged("attribute", value);
                    this.OnattributeChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_type", DbType="varchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String type {
            get {
                return this._type;
            }
            set {
                this.OntypeChanging(value);
                this.SendPropertyChanging("type", value);
                this._type = value;
                this.SendPropertyChanged("type", value);
                this.OntypeChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_value", DbType="varchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String value {
            get {
                return this._value;
            }
            set {
                this.OnvalueChanging(value);
                this.SendPropertyChanging("value", value);
                this._value = value;
                this.SendPropertyChanged("value", value);
                this.OnvalueChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_valueletter", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String valueletter {
            get {
                return this._valueletter;
            }
            set {
                if ((this._valueletter != value)) {
                    this.OnvalueletterChanging(value);
                    this.SendPropertyChanging("valueletter", value);
                    this._valueletter = value;
                    this.SendPropertyChanged("valueletter", value);
                    this.OnvalueletterChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_valuetitle", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String valuetitle {
            get {
                return this._valuetitle;
            }
            set {
                if ((this._valuetitle != value)) {
                    this.OnvaluetitleChanging(value);
                    this.SendPropertyChanging("valuetitle", value);
                    this._valuetitle = value;
                    this.SendPropertyChanged("valuetitle", value);
                    this.OnvaluetitleChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(100)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_banner", DbType="varchar(400)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String banner {
            get {
                return this._banner;
            }
            set {
                if ((this._banner != value)) {
                    this.OnbannerChanging(value);
                    this.SendPropertyChanging("banner", value);
                    this._banner = value;
                    this.SendPropertyChanged("banner", value);
                    this.OnbannerChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(300)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_curcountmoney", DbType="varchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String curcountmoney {
            get {
                return this._curcountmoney;
            }
            set {
                this.OncurcountmoneyChanging(value);
                this.SendPropertyChanging("curcountmoney", value);
                this._curcountmoney = value;
                this.SendPropertyChanged("curcountmoney", value);
                this.OncurcountmoneyChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_curcountpeople", DbType="varchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String curcountpeople {
            get {
                return this._curcountpeople;
            }
            set {
                this.OncurcountpeopleChanging(value);
                this.SendPropertyChanging("curcountpeople", value);
                this._curcountpeople = value;
                this.SendPropertyChanged("curcountpeople", value);
                this.OncurcountpeopleChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_curstage", DbType="varchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String curstage {
            get {
                return this._curstage;
            }
            set {
                this.OncurstageChanging(value);
                this.SendPropertyChanging("curstage", value);
                this._curstage = value;
                this.SendPropertyChanged("curstage", value);
                this.OncurstageChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_fordio", DbType="varchar(20)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String fordio {
            get {
                return this._fordio;
            }
            set {
                if ((this._fordio != value)) {
                    this.OnfordioChanging(value);
                    this.SendPropertyChanging("fordio", value);
                    this._fordio = value;
                    this.SendPropertyChanged("fordio", value);
                    this.OnfordioChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    /// 促销信息表
    /// </summary>
    [Table(Name="t_promotions")]
    [Serializable()]
    [DisplayName("促销信息表")]
    [Description("促销信息表")]
    public partial class Mpromotions : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 会员ID
        /// </summary>
        Int32 _mid;
        /// <summary>
        /// 会员类型（与t_member.type对应）
        /// </summary>
        Int32 _membertype;
        /// <summary>
        /// 标题
        /// </summary>
        String _title;
        /// <summary>
        /// html标题
        /// </summary>
        String _htmltitle;
        /// <summary>
        /// 索引
        /// </summary>
        String _letter;
        /// <summary>
        /// 属性
        /// </summary>
        String _attribute;
        /// <summary>
        /// 开始时间
        /// </summary>
        DateTime _startdatetime;
        /// <summary>
        /// 结束时间
        /// </summary>
        DateTime _enddatetime;
        /// <summary>
        /// 外观图
        /// </summary>
        String _surface;
        /// <summary>
        /// 商标
        /// </summary>
        String _logo;
        /// <summary>
        /// 缩略图
        /// </summary>
        String _thumb;
        /// <summary>
        /// 幻灯片
        /// </summary>
        String _bannel;
        /// <summary>
        /// 描述图
        /// </summary>
        String _desimage;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 关键词
        /// </summary>
        String _keywords;
        /// <summary>
        /// 模板
        /// </summary>
        String _template;
        /// <summary>
        /// 点击量
        /// </summary>
        Int32? _hits;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 创建人(后台管理员，0则为会员)
        /// </summary>
        Int32 _adminid;
        /// <summary>
        /// 最后修改人(后台管理员，0则为会员)
        /// </summary>
        Int32 _lastedadminid;
        /// <summary>
        /// 最后修改时间（后台管理员，0则为会员）
        /// </summary>
        DateTime _lastedadmintime;
        /// <summary>
        /// 最后修改人(会员)
        /// </summary>
        Int32 _lastedmid;
        /// <summary>
        /// 最后修改时间（会员）
        /// </summary>
        DateTime _lastedmtime;
        /// <summary>
        /// 审核状态
        /// </summary>
        Int32 _auditstatus;
        /// <summary>
        /// 在线状态
        /// </summary>
        Int32 _linestatus;
        /// <summary>
        /// 是否置顶
        /// </summary>
        Boolean _IsTop;
        /// <summary>
        /// 是否推荐
        /// </summary>
        Boolean _IsRecommend;
        /// <summary>
        /// 是否热门
        /// </summary>
        Boolean _IsHot;
        /// <summary>
        /// 是否精华
        /// </summary>
        Boolean _IsEssence;
        /// <summary>
        /// 是否幻灯
        /// </summary>
        Boolean _IsSlide;
        /// <summary>
        /// 是否高亮
        /// </summary>
        Boolean _IsHighlight;
        /// <summary>
        /// 发布日期
        /// </summary>
        DateTime _createtime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 mid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmidChanging(Int32 value);
        /// <summary>
        /// 当 mid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmidChanged();
        /// <summary>
        /// 当 membertype 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmembertypeChanging(Int32 value);
        /// <summary>
        /// 当 membertype 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmembertypeChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 htmltitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhtmltitleChanging(String value);
        /// <summary>
        /// 当 htmltitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhtmltitleChanged();
        /// <summary>
        /// 当 letter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnletterChanging(String value);
        /// <summary>
        /// 当 letter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnletterChanged();
        /// <summary>
        /// 当 attribute 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnattributeChanging(String value);
        /// <summary>
        /// 当 attribute 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnattributeChanged();
        /// <summary>
        /// 当 startdatetime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstartdatetimeChanging(DateTime value);
        /// <summary>
        /// 当 startdatetime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstartdatetimeChanged();
        /// <summary>
        /// 当 enddatetime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnenddatetimeChanging(DateTime value);
        /// <summary>
        /// 当 enddatetime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnenddatetimeChanged();
        /// <summary>
        /// 当 surface 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsurfaceChanging(String value);
        /// <summary>
        /// 当 surface 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsurfaceChanged();
        /// <summary>
        /// 当 logo 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlogoChanging(String value);
        /// <summary>
        /// 当 logo 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlogoChanged();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 bannel 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannelChanging(String value);
        /// <summary>
        /// 当 bannel 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannelChanged();
        /// <summary>
        /// 当 desimage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndesimageChanging(String value);
        /// <summary>
        /// 当 desimage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndesimageChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 keywords 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnkeywordsChanging(String value);
        /// <summary>
        /// 当 keywords 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnkeywordsChanged();
        /// <summary>
        /// 当 template 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntemplateChanging(String value);
        /// <summary>
        /// 当 template 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntemplateChanged();
        /// <summary>
        /// 当 hits 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhitsChanging(Int32? value);
        /// <summary>
        /// 当 hits 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhitsChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 adminid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadminidChanging(Int32 value);
        /// <summary>
        /// 当 adminid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadminidChanged();
        /// <summary>
        /// 当 lastedadminid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedadminidChanging(Int32 value);
        /// <summary>
        /// 当 lastedadminid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedadminidChanged();
        /// <summary>
        /// 当 lastedadmintime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedadmintimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedadmintime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedadmintimeChanged();
        /// <summary>
        /// 当 lastedmid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedmidChanging(Int32 value);
        /// <summary>
        /// 当 lastedmid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedmidChanged();
        /// <summary>
        /// 当 lastedmtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedmtimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedmtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedmtimeChanged();
        /// <summary>
        /// 当 auditstatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauditstatusChanging(Int32 value);
        /// <summary>
        /// 当 auditstatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauditstatusChanged();
        /// <summary>
        /// 当 linestatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinestatusChanging(Int32 value);
        /// <summary>
        /// 当 linestatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinestatusChanged();
        /// <summary>
        /// 当 IsTop 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnIsTopChanging(Boolean value);
        /// <summary>
        /// 当 IsTop 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnIsTopChanged();
        /// <summary>
        /// 当 IsRecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnIsRecommendChanging(Boolean value);
        /// <summary>
        /// 当 IsRecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnIsRecommendChanged();
        /// <summary>
        /// 当 IsHot 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnIsHotChanging(Boolean value);
        /// <summary>
        /// 当 IsHot 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnIsHotChanged();
        /// <summary>
        /// 当 IsEssence 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnIsEssenceChanging(Boolean value);
        /// <summary>
        /// 当 IsEssence 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnIsEssenceChanged();
        /// <summary>
        /// 当 IsSlide 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnIsSlideChanging(Boolean value);
        /// <summary>
        /// 当 IsSlide 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnIsSlideChanged();
        /// <summary>
        /// 当 IsHighlight 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnIsHighlightChanging(Boolean value);
        /// <summary>
        /// 当 IsHighlight 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnIsHighlightChanged();
        /// <summary>
        /// 当 createtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatetimeChanging(DateTime value);
        /// <summary>
        /// 当 createtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatetimeChanged();
        
        /// <summary>
        /// 初始化 Mpromotions 实体类的新实例。
        /// </summary>
        public Mpromotions() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 会员ID
        /// </summary>
        [Column(Storage="_mid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("会员ID")]
        [Description("会员ID")]
        public Int32 mid {
            get {
                return this._mid;
            }
            set {
                this.OnmidChanging(value);
                this.SendPropertyChanging("mid", value);
                this._mid = value;
                this.SendPropertyChanged("mid", value);
                this.OnmidChanged();
            }
        }
        /// <summary>
        /// 会员类型（与t_member.type对应）
        /// </summary>
        [Column(Storage="_membertype", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("会员类型")]
        [Description("会员类型（与t_member.type对应）")]
        public Int32 membertype {
            get {
                return this._membertype;
            }
            set {
                this.OnmembertypeChanging(value);
                this.SendPropertyChanging("membertype", value);
                this._membertype = value;
                this.SendPropertyChanged("membertype", value);
                this.OnmembertypeChanged();
            }
        }
        /// <summary>
        /// 标题
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(80) NOT NULL", CanBeNull=false)]
        [DisplayName("标题")]
        [Description("标题")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// html标题
        /// </summary>
        [Column(Storage="_htmltitle", DbType="nvarchar(500)")]
        [DisplayName("html标题")]
        [Description("html标题")]
        public String htmltitle {
            get {
                return this._htmltitle;
            }
            set {
                if ((this._htmltitle != value)) {
                    this.OnhtmltitleChanging(value);
                    this.SendPropertyChanging("htmltitle", value);
                    this._htmltitle = value;
                    this.SendPropertyChanged("htmltitle", value);
                    this.OnhtmltitleChanged();
                }
            }
        }
        /// <summary>
        /// 索引
        /// </summary>
        [Column(Storage="_letter", DbType="varchar(80)")]
        [DisplayName("索引")]
        [Description("索引")]
        public String letter {
            get {
                return this._letter;
            }
            set {
                if ((this._letter != value)) {
                    this.OnletterChanging(value);
                    this.SendPropertyChanging("letter", value);
                    this._letter = value;
                    this.SendPropertyChanged("letter", value);
                    this.OnletterChanged();
                }
            }
        }
        /// <summary>
        /// 属性
        /// </summary>
        [Column(Storage="_attribute", DbType="varchar(100)")]
        [DisplayName("属性")]
        [Description("属性")]
        public String attribute {
            get {
                return this._attribute;
            }
            set {
                if ((this._attribute != value)) {
                    this.OnattributeChanging(value);
                    this.SendPropertyChanging("attribute", value);
                    this._attribute = value;
                    this.SendPropertyChanged("attribute", value);
                    this.OnattributeChanged();
                }
            }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Column(Storage="_startdatetime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("开始时间")]
        [Description("开始时间")]
        public DateTime startdatetime {
            get {
                return this._startdatetime;
            }
            set {
                this.OnstartdatetimeChanging(value);
                this.SendPropertyChanging("startdatetime", value);
                this._startdatetime = value;
                this.SendPropertyChanged("startdatetime", value);
                this.OnstartdatetimeChanged();
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Column(Storage="_enddatetime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("结束时间")]
        [Description("结束时间")]
        public DateTime enddatetime {
            get {
                return this._enddatetime;
            }
            set {
                this.OnenddatetimeChanging(value);
                this.SendPropertyChanging("enddatetime", value);
                this._enddatetime = value;
                this.SendPropertyChanged("enddatetime", value);
                this.OnenddatetimeChanged();
            }
        }
        /// <summary>
        /// 外观图
        /// </summary>
        [Column(Storage="_surface", DbType="varchar(200)")]
        [DisplayName("外观图")]
        [Description("外观图")]
        public String surface {
            get {
                return this._surface;
            }
            set {
                if ((this._surface != value)) {
                    this.OnsurfaceChanging(value);
                    this.SendPropertyChanging("surface", value);
                    this._surface = value;
                    this.SendPropertyChanged("surface", value);
                    this.OnsurfaceChanged();
                }
            }
        }
        /// <summary>
        /// 商标
        /// </summary>
        [Column(Storage="_logo", DbType="varchar(40)")]
        [DisplayName("商标")]
        [Description("商标")]
        public String logo {
            get {
                return this._logo;
            }
            set {
                if ((this._logo != value)) {
                    this.OnlogoChanging(value);
                    this.SendPropertyChanging("logo", value);
                    this._logo = value;
                    this.SendPropertyChanged("logo", value);
                    this.OnlogoChanged();
                }
            }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(40)")]
        [DisplayName("缩略图")]
        [Description("缩略图")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        /// 幻灯片
        /// </summary>
        [Column(Storage="_bannel", DbType="varchar(300)")]
        [DisplayName("幻灯片")]
        [Description("幻灯片")]
        public String bannel {
            get {
                return this._bannel;
            }
            set {
                if ((this._bannel != value)) {
                    this.OnbannelChanging(value);
                    this.SendPropertyChanging("bannel", value);
                    this._bannel = value;
                    this.SendPropertyChanged("bannel", value);
                    this.OnbannelChanged();
                }
            }
        }
        /// <summary>
        /// 描述图
        /// </summary>
        [Column(Storage="_desimage", DbType="varchar(400)")]
        [DisplayName("描述图")]
        [Description("描述图")]
        public String desimage {
            get {
                return this._desimage;
            }
            set {
                if ((this._desimage != value)) {
                    this.OndesimageChanging(value);
                    this.SendPropertyChanging("desimage", value);
                    this._desimage = value;
                    this.SendPropertyChanged("desimage", value);
                    this.OndesimageChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="ntext")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 关键词
        /// </summary>
        [Column(Storage="_keywords", DbType="nvarchar(200)")]
        [DisplayName("关键词")]
        [Description("关键词")]
        public String keywords {
            get {
                return this._keywords;
            }
            set {
                if ((this._keywords != value)) {
                    this.OnkeywordsChanging(value);
                    this.SendPropertyChanging("keywords", value);
                    this._keywords = value;
                    this.SendPropertyChanged("keywords", value);
                    this.OnkeywordsChanged();
                }
            }
        }
        /// <summary>
        /// 模板
        /// </summary>
        [Column(Storage="_template", DbType="varchar(50)")]
        [DisplayName("模板")]
        [Description("模板")]
        public String template {
            get {
                return this._template;
            }
            set {
                if ((this._template != value)) {
                    this.OntemplateChanging(value);
                    this.SendPropertyChanging("template", value);
                    this._template = value;
                    this.SendPropertyChanged("template", value);
                    this.OntemplateChanged();
                }
            }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        [Column(Storage="_hits", DbType="int")]
        [DisplayName("点击量")]
        [Description("点击量")]
        public Int32? hits {
            get {
                return this._hits;
            }
            set {
                if ((this._hits != value)) {
                    this.OnhitsChanging(value);
                    this.SendPropertyChanging("hits", value);
                    this._hits = value;
                    this.SendPropertyChanged("hits", value);
                    this.OnhitsChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 创建人(后台管理员，0则为会员)
        /// </summary>
        [Column(Storage="_adminid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("创建人")]
        [Description("创建人(后台管理员，0则为会员)")]
        public Int32 adminid {
            get {
                return this._adminid;
            }
            set {
                this.OnadminidChanging(value);
                this.SendPropertyChanging("adminid", value);
                this._adminid = value;
                this.SendPropertyChanged("adminid", value);
                this.OnadminidChanged();
            }
        }
        /// <summary>
        /// 最后修改人(后台管理员，0则为会员)
        /// </summary>
        [Column(Storage="_lastedadminid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("最后修改人")]
        [Description("最后修改人(后台管理员，0则为会员)")]
        public Int32 lastedadminid {
            get {
                return this._lastedadminid;
            }
            set {
                this.OnlastedadminidChanging(value);
                this.SendPropertyChanging("lastedadminid", value);
                this._lastedadminid = value;
                this.SendPropertyChanged("lastedadminid", value);
                this.OnlastedadminidChanged();
            }
        }
        /// <summary>
        /// 最后修改时间（后台管理员，0则为会员）
        /// </summary>
        [Column(Storage="_lastedadmintime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最后修改时间")]
        [Description("最后修改时间（后台管理员，0则为会员）")]
        public DateTime lastedadmintime {
            get {
                return this._lastedadmintime;
            }
            set {
                this.OnlastedadmintimeChanging(value);
                this.SendPropertyChanging("lastedadmintime", value);
                this._lastedadmintime = value;
                this.SendPropertyChanged("lastedadmintime", value);
                this.OnlastedadmintimeChanged();
            }
        }
        /// <summary>
        /// 最后修改人(会员)
        /// </summary>
        [Column(Storage="_lastedmid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("最后修改人")]
        [Description("最后修改人(会员)")]
        public Int32 lastedmid {
            get {
                return this._lastedmid;
            }
            set {
                this.OnlastedmidChanging(value);
                this.SendPropertyChanging("lastedmid", value);
                this._lastedmid = value;
                this.SendPropertyChanged("lastedmid", value);
                this.OnlastedmidChanged();
            }
        }
        /// <summary>
        /// 最后修改时间（会员）
        /// </summary>
        [Column(Storage="_lastedmtime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最后修改时间")]
        [Description("最后修改时间（会员）")]
        public DateTime lastedmtime {
            get {
                return this._lastedmtime;
            }
            set {
                this.OnlastedmtimeChanging(value);
                this.SendPropertyChanging("lastedmtime", value);
                this._lastedmtime = value;
                this.SendPropertyChanged("lastedmtime", value);
                this.OnlastedmtimeChanged();
            }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        [Column(Storage="_auditstatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("审核状态")]
        [Description("审核状态")]
        public Int32 auditstatus {
            get {
                return this._auditstatus;
            }
            set {
                this.OnauditstatusChanging(value);
                this.SendPropertyChanging("auditstatus", value);
                this._auditstatus = value;
                this.SendPropertyChanged("auditstatus", value);
                this.OnauditstatusChanged();
            }
        }
        /// <summary>
        /// 在线状态
        /// </summary>
        [Column(Storage="_linestatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("在线状态")]
        [Description("在线状态")]
        public Int32 linestatus {
            get {
                return this._linestatus;
            }
            set {
                this.OnlinestatusChanging(value);
                this.SendPropertyChanging("linestatus", value);
                this._linestatus = value;
                this.SendPropertyChanged("linestatus", value);
                this.OnlinestatusChanged();
            }
        }
        /// <summary>
        /// 是否置顶
        /// </summary>
        [Column(Storage="_IsTop", DbType="bit NOT NULL", CanBeNull=false)]
        [DisplayName("是否置顶")]
        [Description("是否置顶")]
        public Boolean IsTop {
            get {
                return this._IsTop;
            }
            set {
                this.OnIsTopChanging(value);
                this.SendPropertyChanging("IsTop", value);
                this._IsTop = value;
                this.SendPropertyChanged("IsTop", value);
                this.OnIsTopChanged();
            }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        [Column(Storage="_IsRecommend", DbType="bit NOT NULL", CanBeNull=false)]
        [DisplayName("是否推荐")]
        [Description("是否推荐")]
        public Boolean IsRecommend {
            get {
                return this._IsRecommend;
            }
            set {
                this.OnIsRecommendChanging(value);
                this.SendPropertyChanging("IsRecommend", value);
                this._IsRecommend = value;
                this.SendPropertyChanged("IsRecommend", value);
                this.OnIsRecommendChanged();
            }
        }
        /// <summary>
        /// 是否热门
        /// </summary>
        [Column(Storage="_IsHot", DbType="bit NOT NULL", CanBeNull=false)]
        [DisplayName("是否热门")]
        [Description("是否热门")]
        public Boolean IsHot {
            get {
                return this._IsHot;
            }
            set {
                this.OnIsHotChanging(value);
                this.SendPropertyChanging("IsHot", value);
                this._IsHot = value;
                this.SendPropertyChanged("IsHot", value);
                this.OnIsHotChanged();
            }
        }
        /// <summary>
        /// 是否精华
        /// </summary>
        [Column(Storage="_IsEssence", DbType="bit NOT NULL", CanBeNull=false)]
        [DisplayName("是否精华")]
        [Description("是否精华")]
        public Boolean IsEssence {
            get {
                return this._IsEssence;
            }
            set {
                this.OnIsEssenceChanging(value);
                this.SendPropertyChanging("IsEssence", value);
                this._IsEssence = value;
                this.SendPropertyChanged("IsEssence", value);
                this.OnIsEssenceChanged();
            }
        }
        /// <summary>
        /// 是否幻灯
        /// </summary>
        [Column(Storage="_IsSlide", DbType="bit NOT NULL", CanBeNull=false)]
        [DisplayName("是否幻灯")]
        [Description("是否幻灯")]
        public Boolean IsSlide {
            get {
                return this._IsSlide;
            }
            set {
                this.OnIsSlideChanging(value);
                this.SendPropertyChanging("IsSlide", value);
                this._IsSlide = value;
                this.SendPropertyChanged("IsSlide", value);
                this.OnIsSlideChanged();
            }
        }
        /// <summary>
        /// 是否高亮
        /// </summary>
        [Column(Storage="_IsHighlight", DbType="bit NOT NULL", CanBeNull=false)]
        [DisplayName("是否高亮")]
        [Description("是否高亮")]
        public Boolean IsHighlight {
            get {
                return this._IsHighlight;
            }
            set {
                this.OnIsHighlightChanging(value);
                this.SendPropertyChanging("IsHighlight", value);
                this._IsHighlight = value;
                this.SendPropertyChanged("IsHighlight", value);
                this.OnIsHighlightChanged();
            }
        }
        /// <summary>
        /// 发布日期
        /// </summary>
        [Column(Storage="_createtime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("发布日期")]
        [Description("发布日期")]
        public DateTime createtime {
            get {
                return this._createtime;
            }
            set {
                this.OncreatetimeChanging(value);
                this.SendPropertyChanging("createtime", value);
                this._createtime = value;
                this.SendPropertyChanged("createtime", value);
                this.OncreatetimeChanged();
            }
        }
    }
    /// <summary>
    /// 促销信息关系表（店铺，卖场根据会员与会员类型决定）
    /// </summary>
    [Table(Name="t_promotionsrelated")]
    [Serializable()]
    [DisplayName("促销信息关系表")]
    [Description("促销信息关系表（店铺，卖场根据会员与会员类型决定）")]
    public partial class Mpromotionsrelated : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 会员ID
        /// </summary>
        Int32 _mid;
        /// <summary>
        /// 会员类型（冗余字段）
        /// </summary>
        Int32 _membertype;
        /// <summary>
        /// 促销ID
        /// </summary>
        Int32 _promotionsid;
        /// <summary>
        /// 促销标题（冗余字段）
        /// </summary>
        String _promotionstitle;
        /// <summary>
        /// 店铺ID（与卖场ID是不同时存在）
        /// </summary>
        Int32 _shopid;
        /// <summary>
        /// 店铺名称（冗余字段）
        /// </summary>
        String _shoptitle;
        /// <summary>
        /// 店铺地区（冗余字段）
        /// </summary>
        String _shopareacode;
        /// <summary>
        /// 店铺地址（冗余字段）
        /// </summary>
        String _shopaddress;
        /// <summary>
        /// 卖场ID（与店铺ID是不同时存在）
        /// </summary>
        Int32 _marketid;
        /// <summary>
        /// 卖场名称（冗余字段）
        /// </summary>
        String _markettitle;
        /// <summary>
        /// 卖场地区（冗余字段）
        /// </summary>
        String _marketareacode;
        /// <summary>
        /// 卖场地址（冗余字段）
        /// </summary>
        String _marketaddress;
        /// <summary>
        /// 卖场楼层（当为0时表示全部楼层）
        /// </summary>
        Int32 _marketstoreyid;
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime _createtime;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 mid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmidChanging(Int32 value);
        /// <summary>
        /// 当 mid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmidChanged();
        /// <summary>
        /// 当 membertype 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmembertypeChanging(Int32 value);
        /// <summary>
        /// 当 membertype 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmembertypeChanged();
        /// <summary>
        /// 当 promotionsid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromotionsidChanging(Int32 value);
        /// <summary>
        /// 当 promotionsid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromotionsidChanged();
        /// <summary>
        /// 当 promotionstitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromotionstitleChanging(String value);
        /// <summary>
        /// 当 promotionstitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromotionstitleChanged();
        /// <summary>
        /// 当 shopid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshopidChanging(Int32 value);
        /// <summary>
        /// 当 shopid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshopidChanged();
        /// <summary>
        /// 当 shoptitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshoptitleChanging(String value);
        /// <summary>
        /// 当 shoptitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshoptitleChanged();
        /// <summary>
        /// 当 shopareacode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshopareacodeChanging(String value);
        /// <summary>
        /// 当 shopareacode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshopareacodeChanged();
        /// <summary>
        /// 当 shopaddress 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshopaddressChanging(String value);
        /// <summary>
        /// 当 shopaddress 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshopaddressChanged();
        /// <summary>
        /// 当 marketid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarketidChanging(Int32 value);
        /// <summary>
        /// 当 marketid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarketidChanged();
        /// <summary>
        /// 当 markettitle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarkettitleChanging(String value);
        /// <summary>
        /// 当 markettitle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarkettitleChanged();
        /// <summary>
        /// 当 marketareacode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarketareacodeChanging(String value);
        /// <summary>
        /// 当 marketareacode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarketareacodeChanged();
        /// <summary>
        /// 当 marketaddress 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarketaddressChanging(String value);
        /// <summary>
        /// 当 marketaddress 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarketaddressChanged();
        /// <summary>
        /// 当 marketstoreyid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarketstoreyidChanging(Int32 value);
        /// <summary>
        /// 当 marketstoreyid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarketstoreyidChanged();
        /// <summary>
        /// 当 createtime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatetimeChanging(DateTime value);
        /// <summary>
        /// 当 createtime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatetimeChanged();
        
        /// <summary>
        /// 初始化 Mpromotionsrelated 实体类的新实例。
        /// </summary>
        public Mpromotionsrelated() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 会员ID
        /// </summary>
        [Column(Storage="_mid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("会员ID")]
        [Description("会员ID")]
        public Int32 mid {
            get {
                return this._mid;
            }
            set {
                this.OnmidChanging(value);
                this.SendPropertyChanging("mid", value);
                this._mid = value;
                this.SendPropertyChanged("mid", value);
                this.OnmidChanged();
            }
        }
        /// <summary>
        /// 会员类型（冗余字段）
        /// </summary>
        [Column(Storage="_membertype", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("会员类型（冗余字段）")]
        [Description("会员类型（冗余字段）")]
        public Int32 membertype {
            get {
                return this._membertype;
            }
            set {
                this.OnmembertypeChanging(value);
                this.SendPropertyChanging("membertype", value);
                this._membertype = value;
                this.SendPropertyChanged("membertype", value);
                this.OnmembertypeChanged();
            }
        }
        /// <summary>
        /// 促销ID
        /// </summary>
        [Column(Storage="_promotionsid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("促销ID")]
        [Description("促销ID")]
        public Int32 promotionsid {
            get {
                return this._promotionsid;
            }
            set {
                this.OnpromotionsidChanging(value);
                this.SendPropertyChanging("promotionsid", value);
                this._promotionsid = value;
                this.SendPropertyChanged("promotionsid", value);
                this.OnpromotionsidChanged();
            }
        }
        /// <summary>
        /// 促销标题（冗余字段）
        /// </summary>
        [Column(Storage="_promotionstitle", DbType="nvarchar(80) NOT NULL", CanBeNull=false)]
        [DisplayName("促销标题（冗余字段）")]
        [Description("促销标题（冗余字段）")]
        public String promotionstitle {
            get {
                return this._promotionstitle;
            }
            set {
                this.OnpromotionstitleChanging(value);
                this.SendPropertyChanging("promotionstitle", value);
                this._promotionstitle = value;
                this.SendPropertyChanged("promotionstitle", value);
                this.OnpromotionstitleChanged();
            }
        }
        /// <summary>
        /// 店铺ID（与卖场ID是不同时存在）
        /// </summary>
        [Column(Storage="_shopid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("店铺ID")]
        [Description("店铺ID（与卖场ID是不同时存在）")]
        public Int32 shopid {
            get {
                return this._shopid;
            }
            set {
                this.OnshopidChanging(value);
                this.SendPropertyChanging("shopid", value);
                this._shopid = value;
                this.SendPropertyChanged("shopid", value);
                this.OnshopidChanged();
            }
        }
        /// <summary>
        /// 店铺名称（冗余字段）
        /// </summary>
        [Column(Storage="_shoptitle", DbType="nvarchar(80) NOT NULL", CanBeNull=false)]
        [DisplayName("店铺名称（冗余字段）")]
        [Description("店铺名称（冗余字段）")]
        public String shoptitle {
            get {
                return this._shoptitle;
            }
            set {
                this.OnshoptitleChanging(value);
                this.SendPropertyChanging("shoptitle", value);
                this._shoptitle = value;
                this.SendPropertyChanged("shoptitle", value);
                this.OnshoptitleChanged();
            }
        }
        /// <summary>
        /// 店铺地区（冗余字段）
        /// </summary>
        [Column(Storage="_shopareacode", DbType="varchar(10) NOT NULL", CanBeNull=false)]
        [DisplayName("店铺地区（冗余字段）")]
        [Description("店铺地区（冗余字段）")]
        public String shopareacode {
            get {
                return this._shopareacode;
            }
            set {
                this.OnshopareacodeChanging(value);
                this.SendPropertyChanging("shopareacode", value);
                this._shopareacode = value;
                this.SendPropertyChanged("shopareacode", value);
                this.OnshopareacodeChanged();
            }
        }
        /// <summary>
        /// 店铺地址（冗余字段）
        /// </summary>
        [Column(Storage="_shopaddress", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("店铺地址（冗余字段）")]
        [Description("店铺地址（冗余字段）")]
        public String shopaddress {
            get {
                return this._shopaddress;
            }
            set {
                this.OnshopaddressChanging(value);
                this.SendPropertyChanging("shopaddress", value);
                this._shopaddress = value;
                this.SendPropertyChanged("shopaddress", value);
                this.OnshopaddressChanged();
            }
        }
        /// <summary>
        /// 卖场ID（与店铺ID是不同时存在）
        /// </summary>
        [Column(Storage="_marketid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("卖场ID")]
        [Description("卖场ID（与店铺ID是不同时存在）")]
        public Int32 marketid {
            get {
                return this._marketid;
            }
            set {
                this.OnmarketidChanging(value);
                this.SendPropertyChanging("marketid", value);
                this._marketid = value;
                this.SendPropertyChanged("marketid", value);
                this.OnmarketidChanged();
            }
        }
        /// <summary>
        /// 卖场名称（冗余字段）
        /// </summary>
        [Column(Storage="_markettitle", DbType="nvarchar(80) NOT NULL", CanBeNull=false)]
        [DisplayName("卖场名称（冗余字段）")]
        [Description("卖场名称（冗余字段）")]
        public String markettitle {
            get {
                return this._markettitle;
            }
            set {
                this.OnmarkettitleChanging(value);
                this.SendPropertyChanging("markettitle", value);
                this._markettitle = value;
                this.SendPropertyChanged("markettitle", value);
                this.OnmarkettitleChanged();
            }
        }
        /// <summary>
        /// 卖场地区（冗余字段）
        /// </summary>
        [Column(Storage="_marketareacode", DbType="varchar(10) NOT NULL", CanBeNull=false)]
        [DisplayName("卖场地区（冗余字段）")]
        [Description("卖场地区（冗余字段）")]
        public String marketareacode {
            get {
                return this._marketareacode;
            }
            set {
                this.OnmarketareacodeChanging(value);
                this.SendPropertyChanging("marketareacode", value);
                this._marketareacode = value;
                this.SendPropertyChanged("marketareacode", value);
                this.OnmarketareacodeChanged();
            }
        }
        /// <summary>
        /// 卖场地址（冗余字段）
        /// </summary>
        [Column(Storage="_marketaddress", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        [DisplayName("卖场地址（冗余字段）")]
        [Description("卖场地址（冗余字段）")]
        public String marketaddress {
            get {
                return this._marketaddress;
            }
            set {
                this.OnmarketaddressChanging(value);
                this.SendPropertyChanging("marketaddress", value);
                this._marketaddress = value;
                this.SendPropertyChanged("marketaddress", value);
                this.OnmarketaddressChanged();
            }
        }
        /// <summary>
        /// 卖场楼层（当为0时表示全部楼层）
        /// </summary>
        [Column(Storage="_marketstoreyid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("卖场楼层")]
        [Description("卖场楼层（当为0时表示全部楼层）")]
        public Int32 marketstoreyid {
            get {
                return this._marketstoreyid;
            }
            set {
                this.OnmarketstoreyidChanging(value);
                this.SendPropertyChanging("marketstoreyid", value);
                this._marketstoreyid = value;
                this.SendPropertyChanged("marketstoreyid", value);
                this.OnmarketstoreyidChanged();
            }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Storage="_createtime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        public DateTime createtime {
            get {
                return this._createtime;
            }
            set {
                this.OncreatetimeChanging(value);
                this.SendPropertyChanging("createtime", value);
                this._createtime = value;
                this.SendPropertyChanged("createtime", value);
                this.OncreatetimeChanged();
            }
        }
    }
    /// <summary>
    ///  
    /// </summary>
    [Table(Name="t_promotionstage")]
    [Serializable()]
    [DisplayName(" ")]
    [Description(" ")]
    public partial class Mpromotionstage : DALModelBase {
        /// <summary>
        ///  
        /// </summary>
        Int32 _id;
        /// <summary>
        ///  
        /// </summary>
        String _title;
        /// <summary>
        ///  
        /// </summary>
        Int32 _pid;
        /// <summary>
        ///  
        /// </summary>
        Int32 _did;
        /// <summary>
        ///  
        /// </summary>
        Int32 _stype;
        /// <summary>
        ///  
        /// </summary>
        Int32 _smodle;
        /// <summary>
        ///  
        /// </summary>
        String _svaluemin;
        /// <summary>
        ///  
        /// </summary>
        String _svaluemax;
        /// <summary>
        ///  
        /// </summary>
        Int32? _pmodule;
        /// <summary>
        ///  
        /// </summary>
        String _prolue;
        /// <summary>
        ///  
        /// </summary>
        String _pvalue;
        /// <summary>
        ///  
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 pid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpidChanging(Int32 value);
        /// <summary>
        /// 当 pid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpidChanged();
        /// <summary>
        /// 当 did 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndidChanging(Int32 value);
        /// <summary>
        /// 当 did 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndidChanged();
        /// <summary>
        /// 当 stype 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstypeChanging(Int32 value);
        /// <summary>
        /// 当 stype 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstypeChanged();
        /// <summary>
        /// 当 smodle 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsmodleChanging(Int32 value);
        /// <summary>
        /// 当 smodle 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsmodleChanged();
        /// <summary>
        /// 当 svaluemin 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsvalueminChanging(String value);
        /// <summary>
        /// 当 svaluemin 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsvalueminChanged();
        /// <summary>
        /// 当 svaluemax 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsvaluemaxChanging(String value);
        /// <summary>
        /// 当 svaluemax 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsvaluemaxChanged();
        /// <summary>
        /// 当 pmodule 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpmoduleChanging(Int32? value);
        /// <summary>
        /// 当 pmodule 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpmoduleChanged();
        /// <summary>
        /// 当 prolue 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnprolueChanging(String value);
        /// <summary>
        /// 当 prolue 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnprolueChanged();
        /// <summary>
        /// 当 pvalue 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpvalueChanging(String value);
        /// <summary>
        /// 当 pvalue 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpvalueChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Mpromotionstage 实体类的新实例。
        /// </summary>
        public Mpromotionstage() {
            this.OnCreated();
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String title {
            get {
                return this._title;
            }
            set {
                if ((this._title != value)) {
                    this.OntitleChanging(value);
                    this.SendPropertyChanging("title", value);
                    this._title = value;
                    this.SendPropertyChanged("title", value);
                    this.OntitleChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_pid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 pid {
            get {
                return this._pid;
            }
            set {
                this.OnpidChanging(value);
                this.SendPropertyChanging("pid", value);
                this._pid = value;
                this.SendPropertyChanged("pid", value);
                this.OnpidChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_did", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 did {
            get {
                return this._did;
            }
            set {
                this.OndidChanging(value);
                this.SendPropertyChanging("did", value);
                this._did = value;
                this.SendPropertyChanged("did", value);
                this.OndidChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_stype", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 stype {
            get {
                return this._stype;
            }
            set {
                this.OnstypeChanging(value);
                this.SendPropertyChanging("stype", value);
                this._stype = value;
                this.SendPropertyChanged("stype", value);
                this.OnstypeChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_smodle", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 smodle {
            get {
                return this._smodle;
            }
            set {
                this.OnsmodleChanging(value);
                this.SendPropertyChanging("smodle", value);
                this._smodle = value;
                this.SendPropertyChanged("smodle", value);
                this.OnsmodleChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_svaluemin", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String svaluemin {
            get {
                return this._svaluemin;
            }
            set {
                if ((this._svaluemin != value)) {
                    this.OnsvalueminChanging(value);
                    this.SendPropertyChanging("svaluemin", value);
                    this._svaluemin = value;
                    this.SendPropertyChanged("svaluemin", value);
                    this.OnsvalueminChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_svaluemax", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String svaluemax {
            get {
                return this._svaluemax;
            }
            set {
                if ((this._svaluemax != value)) {
                    this.OnsvaluemaxChanging(value);
                    this.SendPropertyChanging("svaluemax", value);
                    this._svaluemax = value;
                    this.SendPropertyChanged("svaluemax", value);
                    this.OnsvaluemaxChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_pmodule", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? pmodule {
            get {
                return this._pmodule;
            }
            set {
                if ((this._pmodule != value)) {
                    this.OnpmoduleChanging(value);
                    this.SendPropertyChanging("pmodule", value);
                    this._pmodule = value;
                    this.SendPropertyChanged("pmodule", value);
                    this.OnpmoduleChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_prolue", DbType="nvarchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String prolue {
            get {
                return this._prolue;
            }
            set {
                if ((this._prolue != value)) {
                    this.OnprolueChanging(value);
                    this.SendPropertyChanging("prolue", value);
                    this._prolue = value;
                    this.SendPropertyChanged("prolue", value);
                    this.OnprolueChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_pvalue", DbType="varchar(50)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String pvalue {
            get {
                return this._pvalue;
            }
            set {
                if ((this._pvalue != value)) {
                    this.OnpvalueChanging(value);
                    this.SendPropertyChanging("pvalue", value);
                    this._pvalue = value;
                    this.SendPropertyChanged("pvalue", value);
                    this.OnpvalueChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    /// 店铺表
    /// </summary>
    [Table(Name="t_shop")]
    [Serializable()]
    [DisplayName("店铺表")]
    [Description("店铺表")]
    public partial class Mshop : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 用户表ID
        /// </summary>
        Int32 _mid;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 索引
        /// </summary>
        String _letter;
        /// <summary>
        /// 组ID
        /// </summary>
        Int32 _groupid;
        /// <summary>
        /// 属性
        /// </summary>
        String _attribute;
        /// <summary>
        /// 行业
        /// </summary>
        String _industry;
        /// <summary>
        /// 产品分类
        /// </summary>
        String _productcategory;
        /// <summary>
        /// 是否vip
        /// </summary>
        Int32? _vip;
        /// <summary>
        /// 地区代码
        /// </summary>
        String _areacode;
        /// <summary>
        /// 地址
        /// </summary>
        String _address;
        /// <summary>
        /// 地图API值
        /// </summary>
        String _mapapi;
        /// <summary>
        /// 外观图
        /// </summary>
        Int32? _staffsize;
        /// <summary>
        /// 注册时间
        /// </summary>
        String _regyear;
        /// <summary>
        /// 注册城市
        /// </summary>
        String _regcity;
        /// <summary>
        /// 销售信息
        /// </summary>
        String _buy;
        /// <summary>
        /// 采购信息
        /// </summary>
        String _sell;
        /// <summary>
        /// 连系人
        /// </summary>
        String _linkman;
        /// <summary>
        /// 联系电话
        /// </summary>
        String _phone;
        /// <summary>
        /// 联系手机
        /// </summary>
        String _mphone;
        /// <summary>
        /// 传真
        /// </summary>
        String _fax;
        /// <summary>
        /// 邮件
        /// </summary>
        String _email;
        /// <summary>
        /// 邮编
        /// </summary>
        String _postcode;
        /// <summary>
        /// 主页
        /// </summary>
        String _homepage;
        /// <summary>
        /// 域名
        /// </summary>
        String _domain;
        /// <summary>
        /// 域名IP
        /// </summary>
        String _domainip;
        /// <summary>
        /// 备案号
        /// </summary>
        String _icp;
        /// <summary>
        /// 外观图
        /// </summary>
        String _surface;
        /// <summary>
        /// logo
        /// </summary>
        String _logo;
        /// <summary>
        /// 缩略图
        /// </summary>
        String _thumb;
        /// <summary>
        /// 幻灯图
        /// </summary>
        String _bannel;
        /// <summary>
        /// 描述图
        /// </summary>
        String _desimage;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 关键字
        /// </summary>
        String _keywords;
        /// <summary>
        /// 模版ID
        /// </summary>
        String _template;
        /// <summary>
        /// 点击量
        /// </summary>
        Int32? _hits;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 卖场ID
        /// </summary>
        Int32? _marketid;
        /// <summary>
        /// 所属企业或经销商ID
        /// </summary>
        Int32? _cid;
        /// <summary>
        /// 所属类型(企业/经销商)
        /// </summary>
        Int32? _ctype;
        /// <summary>
        /// 创建人
        /// </summary>
        Int32? _createmid;
        /// <summary>
        /// 最后修改人
        /// </summary>
        Int32? _lastedid;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime _lastedittime;
        /// <summary>
        /// 审核状态
        /// </summary>
        Int32 _auditstatus;
        /// <summary>
        /// 上下线状态
        /// </summary>
        Int32 _linestatus;
        /// <summary>
        /// QQ
        /// </summary>
        String _qq;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 mid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmidChanging(Int32 value);
        /// <summary>
        /// 当 mid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 letter 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnletterChanging(String value);
        /// <summary>
        /// 当 letter 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnletterChanged();
        /// <summary>
        /// 当 groupid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OngroupidChanging(Int32 value);
        /// <summary>
        /// 当 groupid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OngroupidChanged();
        /// <summary>
        /// 当 attribute 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnattributeChanging(String value);
        /// <summary>
        /// 当 attribute 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnattributeChanged();
        /// <summary>
        /// 当 industry 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnindustryChanging(String value);
        /// <summary>
        /// 当 industry 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnindustryChanged();
        /// <summary>
        /// 当 productcategory 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcategoryChanging(String value);
        /// <summary>
        /// 当 productcategory 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcategoryChanged();
        /// <summary>
        /// 当 vip 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnvipChanging(Int32? value);
        /// <summary>
        /// 当 vip 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnvipChanged();
        /// <summary>
        /// 当 areacode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnareacodeChanging(String value);
        /// <summary>
        /// 当 areacode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnareacodeChanged();
        /// <summary>
        /// 当 address 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnaddressChanging(String value);
        /// <summary>
        /// 当 address 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnaddressChanged();
        /// <summary>
        /// 当 mapapi 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmapapiChanging(String value);
        /// <summary>
        /// 当 mapapi 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmapapiChanged();
        /// <summary>
        /// 当 staffsize 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnstaffsizeChanging(Int32? value);
        /// <summary>
        /// 当 staffsize 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnstaffsizeChanged();
        /// <summary>
        /// 当 regyear 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnregyearChanging(String value);
        /// <summary>
        /// 当 regyear 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnregyearChanged();
        /// <summary>
        /// 当 regcity 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnregcityChanging(String value);
        /// <summary>
        /// 当 regcity 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnregcityChanged();
        /// <summary>
        /// 当 buy 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbuyChanging(String value);
        /// <summary>
        /// 当 buy 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbuyChanged();
        /// <summary>
        /// 当 sell 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsellChanging(String value);
        /// <summary>
        /// 当 sell 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsellChanged();
        /// <summary>
        /// 当 linkman 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinkmanChanging(String value);
        /// <summary>
        /// 当 linkman 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinkmanChanged();
        /// <summary>
        /// 当 phone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnphoneChanging(String value);
        /// <summary>
        /// 当 phone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnphoneChanged();
        /// <summary>
        /// 当 mphone 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmphoneChanging(String value);
        /// <summary>
        /// 当 mphone 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmphoneChanged();
        /// <summary>
        /// 当 fax 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnfaxChanging(String value);
        /// <summary>
        /// 当 fax 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnfaxChanged();
        /// <summary>
        /// 当 email 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnemailChanging(String value);
        /// <summary>
        /// 当 email 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnemailChanged();
        /// <summary>
        /// 当 postcode 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpostcodeChanging(String value);
        /// <summary>
        /// 当 postcode 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpostcodeChanged();
        /// <summary>
        /// 当 homepage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhomepageChanging(String value);
        /// <summary>
        /// 当 homepage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhomepageChanged();
        /// <summary>
        /// 当 domain 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndomainChanging(String value);
        /// <summary>
        /// 当 domain 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndomainChanged();
        /// <summary>
        /// 当 domainip 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndomainipChanging(String value);
        /// <summary>
        /// 当 domainip 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndomainipChanged();
        /// <summary>
        /// 当 icp 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnicpChanging(String value);
        /// <summary>
        /// 当 icp 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnicpChanged();
        /// <summary>
        /// 当 surface 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsurfaceChanging(String value);
        /// <summary>
        /// 当 surface 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsurfaceChanged();
        /// <summary>
        /// 当 logo 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlogoChanging(String value);
        /// <summary>
        /// 当 logo 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlogoChanged();
        /// <summary>
        /// 当 thumb 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnthumbChanging(String value);
        /// <summary>
        /// 当 thumb 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnthumbChanged();
        /// <summary>
        /// 当 bannel 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbannelChanging(String value);
        /// <summary>
        /// 当 bannel 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbannelChanged();
        /// <summary>
        /// 当 desimage 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndesimageChanging(String value);
        /// <summary>
        /// 当 desimage 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndesimageChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 keywords 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnkeywordsChanging(String value);
        /// <summary>
        /// 当 keywords 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnkeywordsChanged();
        /// <summary>
        /// 当 template 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntemplateChanging(String value);
        /// <summary>
        /// 当 template 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntemplateChanged();
        /// <summary>
        /// 当 hits 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnhitsChanging(Int32? value);
        /// <summary>
        /// 当 hits 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnhitsChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        /// <summary>
        /// 当 marketid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarketidChanging(Int32? value);
        /// <summary>
        /// 当 marketid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarketidChanged();
        /// <summary>
        /// 当 cid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncidChanging(Int32? value);
        /// <summary>
        /// 当 cid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncidChanged();
        /// <summary>
        /// 当 ctype 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnctypeChanging(Int32? value);
        /// <summary>
        /// 当 ctype 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnctypeChanged();
        /// <summary>
        /// 当 createmid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncreatemidChanging(Int32? value);
        /// <summary>
        /// 当 createmid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncreatemidChanged();
        /// <summary>
        /// 当 lastedid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedidChanging(Int32? value);
        /// <summary>
        /// 当 lastedid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedidChanged();
        /// <summary>
        /// 当 lastedittime 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanging(DateTime value);
        /// <summary>
        /// 当 lastedittime 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlastedittimeChanged();
        /// <summary>
        /// 当 auditstatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnauditstatusChanging(Int32 value);
        /// <summary>
        /// 当 auditstatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnauditstatusChanged();
        /// <summary>
        /// 当 linestatus 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinestatusChanging(Int32 value);
        /// <summary>
        /// 当 linestatus 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinestatusChanged();
        /// <summary>
        /// 当 qq 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnqqChanging(String value);
        /// <summary>
        /// 当 qq 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnqqChanged();
        
        /// <summary>
        /// 初始化 Mshop 实体类的新实例。
        /// </summary>
        public Mshop() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 用户表ID
        /// </summary>
        [Column(Storage="_mid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("用户表ID")]
        [Description("用户表ID")]
        public Int32 mid {
            get {
                return this._mid;
            }
            set {
                this.OnmidChanging(value);
                this.SendPropertyChanging("mid", value);
                this._mid = value;
                this.SendPropertyChanged("mid", value);
                this.OnmidChanged();
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(80) NOT NULL", CanBeNull=false)]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 索引
        /// </summary>
        [Column(Storage="_letter", DbType="varchar(20)")]
        [DisplayName("索引")]
        [Description("索引")]
        public String letter {
            get {
                return this._letter;
            }
            set {
                if ((this._letter != value)) {
                    this.OnletterChanging(value);
                    this.SendPropertyChanging("letter", value);
                    this._letter = value;
                    this.SendPropertyChanged("letter", value);
                    this.OnletterChanged();
                }
            }
        }
        /// <summary>
        /// 组ID
        /// </summary>
        [Column(Storage="_groupid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("组ID")]
        [Description("组ID")]
        public Int32 groupid {
            get {
                return this._groupid;
            }
            set {
                this.OngroupidChanging(value);
                this.SendPropertyChanging("groupid", value);
                this._groupid = value;
                this.SendPropertyChanged("groupid", value);
                this.OngroupidChanged();
            }
        }
        /// <summary>
        /// 属性
        /// </summary>
        [Column(Storage="_attribute", DbType="varchar(100)")]
        [DisplayName("属性")]
        [Description("属性")]
        public String attribute {
            get {
                return this._attribute;
            }
            set {
                if ((this._attribute != value)) {
                    this.OnattributeChanging(value);
                    this.SendPropertyChanging("attribute", value);
                    this._attribute = value;
                    this.SendPropertyChanged("attribute", value);
                    this.OnattributeChanged();
                }
            }
        }
        /// <summary>
        /// 行业
        /// </summary>
        [Column(Storage="_industry", DbType="varchar(50)")]
        [DisplayName("行业")]
        [Description("行业")]
        public String industry {
            get {
                return this._industry;
            }
            set {
                if ((this._industry != value)) {
                    this.OnindustryChanging(value);
                    this.SendPropertyChanging("industry", value);
                    this._industry = value;
                    this.SendPropertyChanged("industry", value);
                    this.OnindustryChanged();
                }
            }
        }
        /// <summary>
        /// 产品分类
        /// </summary>
        [Column(Storage="_productcategory", DbType="varchar(50)")]
        [DisplayName("产品分类")]
        [Description("产品分类")]
        public String productcategory {
            get {
                return this._productcategory;
            }
            set {
                if ((this._productcategory != value)) {
                    this.OnproductcategoryChanging(value);
                    this.SendPropertyChanging("productcategory", value);
                    this._productcategory = value;
                    this.SendPropertyChanged("productcategory", value);
                    this.OnproductcategoryChanged();
                }
            }
        }
        /// <summary>
        /// 是否vip
        /// </summary>
        [Column(Storage="_vip", DbType="int")]
        [DisplayName("是否vip")]
        [Description("是否vip")]
        public Int32? vip {
            get {
                return this._vip;
            }
            set {
                if ((this._vip != value)) {
                    this.OnvipChanging(value);
                    this.SendPropertyChanging("vip", value);
                    this._vip = value;
                    this.SendPropertyChanged("vip", value);
                    this.OnvipChanged();
                }
            }
        }
        /// <summary>
        /// 地区代码
        /// </summary>
        [Column(Storage="_areacode", DbType="varchar(10)")]
        [DisplayName("地区代码")]
        [Description("地区代码")]
        public String areacode {
            get {
                return this._areacode;
            }
            set {
                if ((this._areacode != value)) {
                    this.OnareacodeChanging(value);
                    this.SendPropertyChanging("areacode", value);
                    this._areacode = value;
                    this.SendPropertyChanged("areacode", value);
                    this.OnareacodeChanged();
                }
            }
        }
        /// <summary>
        /// 地址
        /// </summary>
        [Column(Storage="_address", DbType="nvarchar(60)")]
        [DisplayName("地址")]
        [Description("地址")]
        public String address {
            get {
                return this._address;
            }
            set {
                if ((this._address != value)) {
                    this.OnaddressChanging(value);
                    this.SendPropertyChanging("address", value);
                    this._address = value;
                    this.SendPropertyChanged("address", value);
                    this.OnaddressChanged();
                }
            }
        }
        /// <summary>
        /// 地图API值
        /// </summary>
        [Column(Storage="_mapapi", DbType="nvarchar(80)")]
        [DisplayName("地图API值")]
        [Description("地图API值")]
        public String mapapi {
            get {
                return this._mapapi;
            }
            set {
                if ((this._mapapi != value)) {
                    this.OnmapapiChanging(value);
                    this.SendPropertyChanging("mapapi", value);
                    this._mapapi = value;
                    this.SendPropertyChanged("mapapi", value);
                    this.OnmapapiChanged();
                }
            }
        }
        /// <summary>
        /// 外观图
        /// </summary>
        [Column(Storage="_staffsize", DbType="int")]
        [DisplayName("外观图")]
        [Description("外观图")]
        public Int32? staffsize {
            get {
                return this._staffsize;
            }
            set {
                if ((this._staffsize != value)) {
                    this.OnstaffsizeChanging(value);
                    this.SendPropertyChanging("staffsize", value);
                    this._staffsize = value;
                    this.SendPropertyChanged("staffsize", value);
                    this.OnstaffsizeChanged();
                }
            }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        [Column(Storage="_regyear", DbType="varchar(7)")]
        [DisplayName("注册时间")]
        [Description("注册时间")]
        public String regyear {
            get {
                return this._regyear;
            }
            set {
                if ((this._regyear != value)) {
                    this.OnregyearChanging(value);
                    this.SendPropertyChanging("regyear", value);
                    this._regyear = value;
                    this.SendPropertyChanged("regyear", value);
                    this.OnregyearChanged();
                }
            }
        }
        /// <summary>
        /// 注册城市
        /// </summary>
        [Column(Storage="_regcity", DbType="varchar(10)")]
        [DisplayName("注册城市")]
        [Description("注册城市")]
        public String regcity {
            get {
                return this._regcity;
            }
            set {
                if ((this._regcity != value)) {
                    this.OnregcityChanging(value);
                    this.SendPropertyChanging("regcity", value);
                    this._regcity = value;
                    this.SendPropertyChanged("regcity", value);
                    this.OnregcityChanged();
                }
            }
        }
        /// <summary>
        /// 销售信息
        /// </summary>
        [Column(Storage="_buy", DbType="nvarchar(300)")]
        [DisplayName("销售信息")]
        [Description("销售信息")]
        public String buy {
            get {
                return this._buy;
            }
            set {
                if ((this._buy != value)) {
                    this.OnbuyChanging(value);
                    this.SendPropertyChanging("buy", value);
                    this._buy = value;
                    this.SendPropertyChanged("buy", value);
                    this.OnbuyChanged();
                }
            }
        }
        /// <summary>
        /// 采购信息
        /// </summary>
        [Column(Storage="_sell", DbType="nvarchar(300)")]
        [DisplayName("采购信息")]
        [Description("采购信息")]
        public String sell {
            get {
                return this._sell;
            }
            set {
                if ((this._sell != value)) {
                    this.OnsellChanging(value);
                    this.SendPropertyChanging("sell", value);
                    this._sell = value;
                    this.SendPropertyChanged("sell", value);
                    this.OnsellChanged();
                }
            }
        }
        /// <summary>
        /// 连系人
        /// </summary>
        [Column(Storage="_linkman", DbType="nvarchar(20)")]
        [DisplayName("连系人")]
        [Description("连系人")]
        public String linkman {
            get {
                return this._linkman;
            }
            set {
                if ((this._linkman != value)) {
                    this.OnlinkmanChanging(value);
                    this.SendPropertyChanging("linkman", value);
                    this._linkman = value;
                    this.SendPropertyChanged("linkman", value);
                    this.OnlinkmanChanged();
                }
            }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Column(Storage="_phone", DbType="varchar(20)")]
        [DisplayName("联系电话")]
        [Description("联系电话")]
        public String phone {
            get {
                return this._phone;
            }
            set {
                if ((this._phone != value)) {
                    this.OnphoneChanging(value);
                    this.SendPropertyChanging("phone", value);
                    this._phone = value;
                    this.SendPropertyChanged("phone", value);
                    this.OnphoneChanged();
                }
            }
        }
        /// <summary>
        /// 联系手机
        /// </summary>
        [Column(Storage="_mphone", DbType="varchar(20)")]
        [DisplayName("联系手机")]
        [Description("联系手机")]
        public String mphone {
            get {
                return this._mphone;
            }
            set {
                if ((this._mphone != value)) {
                    this.OnmphoneChanging(value);
                    this.SendPropertyChanging("mphone", value);
                    this._mphone = value;
                    this.SendPropertyChanged("mphone", value);
                    this.OnmphoneChanged();
                }
            }
        }
        /// <summary>
        /// 传真
        /// </summary>
        [Column(Storage="_fax", DbType="varchar(20)")]
        [DisplayName("传真")]
        [Description("传真")]
        public String fax {
            get {
                return this._fax;
            }
            set {
                if ((this._fax != value)) {
                    this.OnfaxChanging(value);
                    this.SendPropertyChanging("fax", value);
                    this._fax = value;
                    this.SendPropertyChanged("fax", value);
                    this.OnfaxChanged();
                }
            }
        }
        /// <summary>
        /// 邮件
        /// </summary>
        [Column(Storage="_email", DbType="varchar(50)")]
        [DisplayName("邮件")]
        [Description("邮件")]
        public String email {
            get {
                return this._email;
            }
            set {
                if ((this._email != value)) {
                    this.OnemailChanging(value);
                    this.SendPropertyChanging("email", value);
                    this._email = value;
                    this.SendPropertyChanged("email", value);
                    this.OnemailChanged();
                }
            }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        [Column(Storage="_postcode", DbType="varchar(15)")]
        [DisplayName("邮编")]
        [Description("邮编")]
        public String postcode {
            get {
                return this._postcode;
            }
            set {
                if ((this._postcode != value)) {
                    this.OnpostcodeChanging(value);
                    this.SendPropertyChanging("postcode", value);
                    this._postcode = value;
                    this.SendPropertyChanged("postcode", value);
                    this.OnpostcodeChanged();
                }
            }
        }
        /// <summary>
        /// 主页
        /// </summary>
        [Column(Storage="_homepage", DbType="varchar(50)")]
        [DisplayName("主页")]
        [Description("主页")]
        public String homepage {
            get {
                return this._homepage;
            }
            set {
                if ((this._homepage != value)) {
                    this.OnhomepageChanging(value);
                    this.SendPropertyChanging("homepage", value);
                    this._homepage = value;
                    this.SendPropertyChanged("homepage", value);
                    this.OnhomepageChanged();
                }
            }
        }
        /// <summary>
        /// 域名
        /// </summary>
        [Column(Storage="_domain", DbType="varchar(50)")]
        [DisplayName("域名")]
        [Description("域名")]
        public String domain {
            get {
                return this._domain;
            }
            set {
                if ((this._domain != value)) {
                    this.OndomainChanging(value);
                    this.SendPropertyChanging("domain", value);
                    this._domain = value;
                    this.SendPropertyChanged("domain", value);
                    this.OndomainChanged();
                }
            }
        }
        /// <summary>
        /// 域名IP
        /// </summary>
        [Column(Storage="_domainip", DbType="varchar(50)")]
        [DisplayName("域名IP")]
        [Description("域名IP")]
        public String domainip {
            get {
                return this._domainip;
            }
            set {
                if ((this._domainip != value)) {
                    this.OndomainipChanging(value);
                    this.SendPropertyChanging("domainip", value);
                    this._domainip = value;
                    this.SendPropertyChanged("domainip", value);
                    this.OndomainipChanged();
                }
            }
        }
        /// <summary>
        /// 备案号
        /// </summary>
        [Column(Storage="_icp", DbType="nvarchar(50)")]
        [DisplayName("备案号")]
        [Description("备案号")]
        public String icp {
            get {
                return this._icp;
            }
            set {
                if ((this._icp != value)) {
                    this.OnicpChanging(value);
                    this.SendPropertyChanging("icp", value);
                    this._icp = value;
                    this.SendPropertyChanged("icp", value);
                    this.OnicpChanged();
                }
            }
        }
        /// <summary>
        /// 外观图
        /// </summary>
        [Column(Storage="_surface", DbType="varchar(200)")]
        [DisplayName("外观图")]
        [Description("外观图")]
        public String surface {
            get {
                return this._surface;
            }
            set {
                if ((this._surface != value)) {
                    this.OnsurfaceChanging(value);
                    this.SendPropertyChanging("surface", value);
                    this._surface = value;
                    this.SendPropertyChanged("surface", value);
                    this.OnsurfaceChanged();
                }
            }
        }
        /// <summary>
        /// logo
        /// </summary>
        [Column(Storage="_logo", DbType="varchar(40)")]
        [DisplayName("logo")]
        [Description("logo")]
        public String logo {
            get {
                return this._logo;
            }
            set {
                if ((this._logo != value)) {
                    this.OnlogoChanging(value);
                    this.SendPropertyChanging("logo", value);
                    this._logo = value;
                    this.SendPropertyChanged("logo", value);
                    this.OnlogoChanged();
                }
            }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        [Column(Storage="_thumb", DbType="varchar(40)")]
        [DisplayName("缩略图")]
        [Description("缩略图")]
        public String thumb {
            get {
                return this._thumb;
            }
            set {
                if ((this._thumb != value)) {
                    this.OnthumbChanging(value);
                    this.SendPropertyChanging("thumb", value);
                    this._thumb = value;
                    this.SendPropertyChanged("thumb", value);
                    this.OnthumbChanged();
                }
            }
        }
        /// <summary>
        /// 幻灯图
        /// </summary>
        [Column(Storage="_bannel", DbType="varchar(300)")]
        [DisplayName("幻灯图")]
        [Description("幻灯图")]
        public String bannel {
            get {
                return this._bannel;
            }
            set {
                if ((this._bannel != value)) {
                    this.OnbannelChanging(value);
                    this.SendPropertyChanging("bannel", value);
                    this._bannel = value;
                    this.SendPropertyChanged("bannel", value);
                    this.OnbannelChanged();
                }
            }
        }
        /// <summary>
        /// 描述图
        /// </summary>
        [Column(Storage="_desimage", DbType="varchar(400)")]
        [DisplayName("描述图")]
        [Description("描述图")]
        public String desimage {
            get {
                return this._desimage;
            }
            set {
                if ((this._desimage != value)) {
                    this.OndesimageChanging(value);
                    this.SendPropertyChanging("desimage", value);
                    this._desimage = value;
                    this.SendPropertyChanged("desimage", value);
                    this.OndesimageChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="ntext")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        [Column(Storage="_keywords", DbType="nvarchar(200)")]
        [DisplayName("关键字")]
        [Description("关键字")]
        public String keywords {
            get {
                return this._keywords;
            }
            set {
                if ((this._keywords != value)) {
                    this.OnkeywordsChanging(value);
                    this.SendPropertyChanging("keywords", value);
                    this._keywords = value;
                    this.SendPropertyChanged("keywords", value);
                    this.OnkeywordsChanged();
                }
            }
        }
        /// <summary>
        /// 模版ID
        /// </summary>
        [Column(Storage="_template", DbType="varchar(50)")]
        [DisplayName("模版ID")]
        [Description("模版ID")]
        public String template {
            get {
                return this._template;
            }
            set {
                if ((this._template != value)) {
                    this.OntemplateChanging(value);
                    this.SendPropertyChanging("template", value);
                    this._template = value;
                    this.SendPropertyChanged("template", value);
                    this.OntemplateChanged();
                }
            }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        [Column(Storage="_hits", DbType="int")]
        [DisplayName("点击量")]
        [Description("点击量")]
        public Int32? hits {
            get {
                return this._hits;
            }
            set {
                if ((this._hits != value)) {
                    this.OnhitsChanging(value);
                    this.SendPropertyChanging("hits", value);
                    this._hits = value;
                    this.SendPropertyChanged("hits", value);
                    this.OnhitsChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
        /// <summary>
        /// 卖场ID
        /// </summary>
        [Column(Storage="_marketid", DbType="int")]
        [DisplayName("卖场ID")]
        [Description("卖场ID")]
        public Int32? marketid {
            get {
                return this._marketid;
            }
            set {
                if ((this._marketid != value)) {
                    this.OnmarketidChanging(value);
                    this.SendPropertyChanging("marketid", value);
                    this._marketid = value;
                    this.SendPropertyChanged("marketid", value);
                    this.OnmarketidChanged();
                }
            }
        }
        /// <summary>
        /// 所属企业或经销商ID
        /// </summary>
        [Column(Storage="_cid", DbType="int")]
        [DisplayName("所属企业或经销商ID")]
        [Description("所属企业或经销商ID")]
        public Int32? cid {
            get {
                return this._cid;
            }
            set {
                if ((this._cid != value)) {
                    this.OncidChanging(value);
                    this.SendPropertyChanging("cid", value);
                    this._cid = value;
                    this.SendPropertyChanged("cid", value);
                    this.OncidChanged();
                }
            }
        }
        /// <summary>
        /// 所属类型(企业/经销商)
        /// </summary>
        [Column(Storage="_ctype", DbType="int")]
        [DisplayName("所属类型(企业/经销商)")]
        [Description("所属类型(企业/经销商)")]
        public Int32? ctype {
            get {
                return this._ctype;
            }
            set {
                if ((this._ctype != value)) {
                    this.OnctypeChanging(value);
                    this.SendPropertyChanging("ctype", value);
                    this._ctype = value;
                    this.SendPropertyChanged("ctype", value);
                    this.OnctypeChanged();
                }
            }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column(Storage="_createmid", DbType="int")]
        [DisplayName("创建人")]
        [Description("创建人")]
        public Int32? createmid {
            get {
                return this._createmid;
            }
            set {
                if ((this._createmid != value)) {
                    this.OncreatemidChanging(value);
                    this.SendPropertyChanging("createmid", value);
                    this._createmid = value;
                    this.SendPropertyChanged("createmid", value);
                    this.OncreatemidChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改人
        /// </summary>
        [Column(Storage="_lastedid", DbType="int")]
        [DisplayName("最后修改人")]
        [Description("最后修改人")]
        public Int32? lastedid {
            get {
                return this._lastedid;
            }
            set {
                if ((this._lastedid != value)) {
                    this.OnlastedidChanging(value);
                    this.SendPropertyChanging("lastedid", value);
                    this._lastedid = value;
                    this.SendPropertyChanged("lastedid", value);
                    this.OnlastedidChanged();
                }
            }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Column(Storage="_lastedittime", DbType="datetime NOT NULL", CanBeNull=false)]
        [DisplayName("最后修改时间")]
        [Description("最后修改时间")]
        public DateTime lastedittime {
            get {
                return this._lastedittime;
            }
            set {
                this.OnlastedittimeChanging(value);
                this.SendPropertyChanging("lastedittime", value);
                this._lastedittime = value;
                this.SendPropertyChanged("lastedittime", value);
                this.OnlastedittimeChanged();
            }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        [Column(Storage="_auditstatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("审核状态")]
        [Description("审核状态")]
        public Int32 auditstatus {
            get {
                return this._auditstatus;
            }
            set {
                this.OnauditstatusChanging(value);
                this.SendPropertyChanging("auditstatus", value);
                this._auditstatus = value;
                this.SendPropertyChanged("auditstatus", value);
                this.OnauditstatusChanged();
            }
        }
        /// <summary>
        /// 上下线状态
        /// </summary>
        [Column(Storage="_linestatus", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("上下线状态")]
        [Description("上下线状态")]
        public Int32 linestatus {
            get {
                return this._linestatus;
            }
            set {
                this.OnlinestatusChanging(value);
                this.SendPropertyChanging("linestatus", value);
                this._linestatus = value;
                this.SendPropertyChanged("linestatus", value);
                this.OnlinestatusChanged();
            }
        }
        /// <summary>
        /// QQ
        /// </summary>
        [Column(Storage="_qq", DbType="varchar(20)")]
        [DisplayName("QQ")]
        [Description("QQ")]
        public String qq {
            get {
                return this._qq;
            }
            set {
                if ((this._qq != value)) {
                    this.OnqqChanging(value);
                    this.SendPropertyChanging("qq", value);
                    this._qq = value;
                    this.SendPropertyChanged("qq", value);
                    this.OnqqChanged();
                }
            }
        }
    }
    /// <summary>
    /// 店铺品牌关联表
    /// </summary>
    [Table(Name="t_shopbrand")]
    [Serializable()]
    [DisplayName("店铺品牌关联表")]
    [Description("店铺品牌关联表")]
    public partial class Mshopbrand : DALModelBase {
        /// <summary>
        /// 店铺ID
        /// </summary>
        Int32 _shopid;
        /// <summary>
        /// 品牌ID
        /// </summary>
        Int32 _brandid;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 shopid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshopidChanging(Int32 value);
        /// <summary>
        /// 当 shopid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshopidChanged();
        /// <summary>
        /// 当 brandid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandidChanging(Int32 value);
        /// <summary>
        /// 当 brandid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandidChanged();
        
        /// <summary>
        /// 初始化 Mshopbrand 实体类的新实例。
        /// </summary>
        public Mshopbrand() {
            this.OnCreated();
        }
        /// <summary>
        /// 店铺ID
        /// </summary>
        [Column(Storage="_shopid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("店铺ID")]
        [Description("店铺ID")]
        public Int32 shopid {
            get {
                return this._shopid;
            }
            set {
                this.OnshopidChanging(value);
                this.SendPropertyChanging("shopid", value);
                this._shopid = value;
                this.SendPropertyChanged("shopid", value);
                this.OnshopidChanged();
            }
        }
        /// <summary>
        /// 品牌ID
        /// </summary>
        [Column(Storage="_brandid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("品牌ID")]
        [Description("品牌ID")]
        public Int32 brandid {
            get {
                return this._brandid;
            }
            set {
                this.OnbrandidChanging(value);
                this.SendPropertyChanging("brandid", value);
                this._brandid = value;
                this.SendPropertyChanged("brandid", value);
                this.OnbrandidChanged();
            }
        }
    }
    /// <summary>
    /// 店铺组表
    /// </summary>
    [Table(Name="t_shopgroup")]
    [Serializable()]
    [DisplayName("店铺组表")]
    [Description("店铺组表")]
    public partial class Mshopgroup : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 名称颜色
        /// </summary>
        String _color;
        /// <summary>
        /// 标志图片
        /// </summary>
        String _avatar;
        /// <summary>
        /// 积分达到
        /// </summary>
        Decimal? _integral;
        /// <summary>
        /// 金额达至
        /// </summary>
        Decimal? _money;
        /// <summary>
        /// 广告数量
        /// </summary>
        Int32? _adcount;
        /// <summary>
        /// 可加入卖场数量
        /// </summary>
        Int32? _marketpcount;
        /// <summary>
        /// 品牌数量
        /// </summary>
        Int32? _brandcount;
        /// <summary>
        /// 促销信息数量
        /// </summary>
        Int32? _promotioncount;
        /// <summary>
        /// 产品数量
        /// </summary>
        Int32? _productcount;
        /// <summary>
        /// 广告推荐数量
        /// </summary>
        Int32? _adrecommend;
        /// <summary>
        /// 卖场推荐数量
        /// </summary>
        Int32? _marketrecommend;
        /// <summary>
        /// 品牌推数量
        /// </summary>
        Int32? _brandrecommend;
        /// <summary>
        ///  
        /// </summary>
        Int32? _promotionrecommend;
        /// <summary>
        /// 产品推荐数量
        /// </summary>
        Int32? _productrecommend;
        /// <summary>
        ///  
        /// </summary>
        String _permissions;
        /// <summary>
        /// 层级
        /// </summary>
        Int32? _lev;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 color 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OncolorChanging(String value);
        /// <summary>
        /// 当 color 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OncolorChanged();
        /// <summary>
        /// 当 avatar 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnavatarChanging(String value);
        /// <summary>
        /// 当 avatar 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnavatarChanged();
        /// <summary>
        /// 当 integral 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnintegralChanging(Decimal? value);
        /// <summary>
        /// 当 integral 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnintegralChanged();
        /// <summary>
        /// 当 money 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmoneyChanging(Decimal? value);
        /// <summary>
        /// 当 money 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmoneyChanged();
        /// <summary>
        /// 当 adcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadcountChanging(Int32? value);
        /// <summary>
        /// 当 adcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadcountChanged();
        /// <summary>
        /// 当 marketpcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarketpcountChanging(Int32? value);
        /// <summary>
        /// 当 marketpcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarketpcountChanged();
        /// <summary>
        /// 当 brandcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandcountChanging(Int32? value);
        /// <summary>
        /// 当 brandcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandcountChanged();
        /// <summary>
        /// 当 promotioncount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromotioncountChanging(Int32? value);
        /// <summary>
        /// 当 promotioncount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromotioncountChanged();
        /// <summary>
        /// 当 productcount 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductcountChanging(Int32? value);
        /// <summary>
        /// 当 productcount 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductcountChanged();
        /// <summary>
        /// 当 adrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnadrecommendChanging(Int32? value);
        /// <summary>
        /// 当 adrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnadrecommendChanged();
        /// <summary>
        /// 当 marketrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarketrecommendChanging(Int32? value);
        /// <summary>
        /// 当 marketrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarketrecommendChanged();
        /// <summary>
        /// 当 brandrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbrandrecommendChanging(Int32? value);
        /// <summary>
        /// 当 brandrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbrandrecommendChanged();
        /// <summary>
        /// 当 promotionrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpromotionrecommendChanging(Int32? value);
        /// <summary>
        /// 当 promotionrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpromotionrecommendChanged();
        /// <summary>
        /// 当 productrecommend 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductrecommendChanging(Int32? value);
        /// <summary>
        /// 当 productrecommend 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductrecommendChanged();
        /// <summary>
        /// 当 permissions 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnpermissionsChanging(String value);
        /// <summary>
        /// 当 permissions 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnpermissionsChanged();
        /// <summary>
        /// 当 lev 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlevChanging(Int32? value);
        /// <summary>
        /// 当 lev 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlevChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Mshopgroup 实体类的新实例。
        /// </summary>
        public Mshopgroup() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(30) NOT NULL", CanBeNull=false)]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 名称颜色
        /// </summary>
        [Column(Storage="_color", DbType="char(7)")]
        [DisplayName("名称颜色")]
        [Description("名称颜色")]
        public String color {
            get {
                return this._color;
            }
            set {
                if ((this._color != value)) {
                    this.OncolorChanging(value);
                    this.SendPropertyChanging("color", value);
                    this._color = value;
                    this.SendPropertyChanged("color", value);
                    this.OncolorChanged();
                }
            }
        }
        /// <summary>
        /// 标志图片
        /// </summary>
        [Column(Storage="_avatar", DbType="varchar(40)")]
        [DisplayName("标志图片")]
        [Description("标志图片")]
        public String avatar {
            get {
                return this._avatar;
            }
            set {
                if ((this._avatar != value)) {
                    this.OnavatarChanging(value);
                    this.SendPropertyChanging("avatar", value);
                    this._avatar = value;
                    this.SendPropertyChanged("avatar", value);
                    this.OnavatarChanged();
                }
            }
        }
        /// <summary>
        /// 积分达到
        /// </summary>
        [Column(Storage="_integral", DbType="decimal")]
        [DisplayName("积分达到")]
        [Description("积分达到")]
        public Decimal? integral {
            get {
                return this._integral;
            }
            set {
                if ((this._integral != value)) {
                    this.OnintegralChanging(value);
                    this.SendPropertyChanging("integral", value);
                    this._integral = value;
                    this.SendPropertyChanged("integral", value);
                    this.OnintegralChanged();
                }
            }
        }
        /// <summary>
        /// 金额达至
        /// </summary>
        [Column(Storage="_money", DbType="decimal")]
        [DisplayName("金额达至")]
        [Description("金额达至")]
        public Decimal? money {
            get {
                return this._money;
            }
            set {
                if ((this._money != value)) {
                    this.OnmoneyChanging(value);
                    this.SendPropertyChanging("money", value);
                    this._money = value;
                    this.SendPropertyChanged("money", value);
                    this.OnmoneyChanged();
                }
            }
        }
        /// <summary>
        /// 广告数量
        /// </summary>
        [Column(Storage="_adcount", DbType="int")]
        [DisplayName("广告数量")]
        [Description("广告数量")]
        public Int32? adcount {
            get {
                return this._adcount;
            }
            set {
                if ((this._adcount != value)) {
                    this.OnadcountChanging(value);
                    this.SendPropertyChanging("adcount", value);
                    this._adcount = value;
                    this.SendPropertyChanged("adcount", value);
                    this.OnadcountChanged();
                }
            }
        }
        /// <summary>
        /// 可加入卖场数量
        /// </summary>
        [Column(Storage="_marketpcount", DbType="int")]
        [DisplayName("可加入卖场数量")]
        [Description("可加入卖场数量")]
        public Int32? marketpcount {
            get {
                return this._marketpcount;
            }
            set {
                if ((this._marketpcount != value)) {
                    this.OnmarketpcountChanging(value);
                    this.SendPropertyChanging("marketpcount", value);
                    this._marketpcount = value;
                    this.SendPropertyChanged("marketpcount", value);
                    this.OnmarketpcountChanged();
                }
            }
        }
        /// <summary>
        /// 品牌数量
        /// </summary>
        [Column(Storage="_brandcount", DbType="int")]
        [DisplayName("品牌数量")]
        [Description("品牌数量")]
        public Int32? brandcount {
            get {
                return this._brandcount;
            }
            set {
                if ((this._brandcount != value)) {
                    this.OnbrandcountChanging(value);
                    this.SendPropertyChanging("brandcount", value);
                    this._brandcount = value;
                    this.SendPropertyChanged("brandcount", value);
                    this.OnbrandcountChanged();
                }
            }
        }
        /// <summary>
        /// 促销信息数量
        /// </summary>
        [Column(Storage="_promotioncount", DbType="int")]
        [DisplayName("促销信息数量")]
        [Description("促销信息数量")]
        public Int32? promotioncount {
            get {
                return this._promotioncount;
            }
            set {
                if ((this._promotioncount != value)) {
                    this.OnpromotioncountChanging(value);
                    this.SendPropertyChanging("promotioncount", value);
                    this._promotioncount = value;
                    this.SendPropertyChanged("promotioncount", value);
                    this.OnpromotioncountChanged();
                }
            }
        }
        /// <summary>
        /// 产品数量
        /// </summary>
        [Column(Storage="_productcount", DbType="int")]
        [DisplayName("产品数量")]
        [Description("产品数量")]
        public Int32? productcount {
            get {
                return this._productcount;
            }
            set {
                if ((this._productcount != value)) {
                    this.OnproductcountChanging(value);
                    this.SendPropertyChanging("productcount", value);
                    this._productcount = value;
                    this.SendPropertyChanged("productcount", value);
                    this.OnproductcountChanged();
                }
            }
        }
        /// <summary>
        /// 广告推荐数量
        /// </summary>
        [Column(Storage="_adrecommend", DbType="int")]
        [DisplayName("广告推荐数量")]
        [Description("广告推荐数量")]
        public Int32? adrecommend {
            get {
                return this._adrecommend;
            }
            set {
                if ((this._adrecommend != value)) {
                    this.OnadrecommendChanging(value);
                    this.SendPropertyChanging("adrecommend", value);
                    this._adrecommend = value;
                    this.SendPropertyChanged("adrecommend", value);
                    this.OnadrecommendChanged();
                }
            }
        }
        /// <summary>
        /// 卖场推荐数量
        /// </summary>
        [Column(Storage="_marketrecommend", DbType="int")]
        [DisplayName("卖场推荐数量")]
        [Description("卖场推荐数量")]
        public Int32? marketrecommend {
            get {
                return this._marketrecommend;
            }
            set {
                if ((this._marketrecommend != value)) {
                    this.OnmarketrecommendChanging(value);
                    this.SendPropertyChanging("marketrecommend", value);
                    this._marketrecommend = value;
                    this.SendPropertyChanged("marketrecommend", value);
                    this.OnmarketrecommendChanged();
                }
            }
        }
        /// <summary>
        /// 品牌推数量
        /// </summary>
        [Column(Storage="_brandrecommend", DbType="int")]
        [DisplayName("品牌推数量")]
        [Description("品牌推数量")]
        public Int32? brandrecommend {
            get {
                return this._brandrecommend;
            }
            set {
                if ((this._brandrecommend != value)) {
                    this.OnbrandrecommendChanging(value);
                    this.SendPropertyChanging("brandrecommend", value);
                    this._brandrecommend = value;
                    this.SendPropertyChanged("brandrecommend", value);
                    this.OnbrandrecommendChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_promotionrecommend", DbType="int")]
        [Description(" ")]
        public Int32? promotionrecommend {
            get {
                return this._promotionrecommend;
            }
            set {
                if ((this._promotionrecommend != value)) {
                    this.OnpromotionrecommendChanging(value);
                    this.SendPropertyChanging("promotionrecommend", value);
                    this._promotionrecommend = value;
                    this.SendPropertyChanged("promotionrecommend", value);
                    this.OnpromotionrecommendChanged();
                }
            }
        }
        /// <summary>
        /// 产品推荐数量
        /// </summary>
        [Column(Storage="_productrecommend", DbType="int")]
        [DisplayName("产品推荐数量")]
        [Description("产品推荐数量")]
        public Int32? productrecommend {
            get {
                return this._productrecommend;
            }
            set {
                if ((this._productrecommend != value)) {
                    this.OnproductrecommendChanging(value);
                    this.SendPropertyChanging("productrecommend", value);
                    this._productrecommend = value;
                    this.SendPropertyChanged("productrecommend", value);
                    this.OnproductrecommendChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_permissions", DbType="ntext")]
        [DisplayName(" ")]
        [Description(" ")]
        public String permissions {
            get {
                return this._permissions;
            }
            set {
                if ((this._permissions != value)) {
                    this.OnpermissionsChanging(value);
                    this.SendPropertyChanging("permissions", value);
                    this._permissions = value;
                    this.SendPropertyChanged("permissions", value);
                    this.OnpermissionsChanged();
                }
            }
        }
        /// <summary>
        /// 层级
        /// </summary>
        [Column(Storage="_lev", DbType="int")]
        [DisplayName("层级")]
        [Description("层级")]
        public Int32? lev {
            get {
                return this._lev;
            }
            set {
                if ((this._lev != value)) {
                    this.OnlevChanging(value);
                    this.SendPropertyChanging("lev", value);
                    this._lev = value;
                    this.SendPropertyChanged("lev", value);
                    this.OnlevChanged();
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(300)")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    /// 产品产品价格表
    /// </summary>
    [Table(Name="t_shopproductprice")]
    [Serializable()]
    [DisplayName("产品产品价格表")]
    [Description("产品产品价格表")]
    public partial class Mshopproductprice : DALModelBase {
        /// <summary>
        /// 店铺ID
        /// </summary>
        Int32? _shopid;
        /// <summary>
        /// 产品ID
        /// </summary>
        Int32? _productid;
        /// <summary>
        /// 产品属性ID
        /// </summary>
        Int32? _attributeid;
        /// <summary>
        /// 销售价格
        /// </summary>
        Decimal _saleprice;
        /// <summary>
        /// 采购价格
        /// </summary>
        Decimal _buyprice;
        /// <summary>
        /// 市场价格
        /// </summary>
        Decimal _markprice;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 shopid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnshopidChanging(Int32? value);
        /// <summary>
        /// 当 shopid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnshopidChanged();
        /// <summary>
        /// 当 productid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnproductidChanging(Int32? value);
        /// <summary>
        /// 当 productid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnproductidChanged();
        /// <summary>
        /// 当 attributeid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnattributeidChanging(Int32? value);
        /// <summary>
        /// 当 attributeid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnattributeidChanged();
        /// <summary>
        /// 当 saleprice 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsalepriceChanging(Decimal value);
        /// <summary>
        /// 当 saleprice 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsalepriceChanged();
        /// <summary>
        /// 当 buyprice 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnbuypriceChanging(Decimal value);
        /// <summary>
        /// 当 buyprice 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnbuypriceChanged();
        /// <summary>
        /// 当 markprice 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarkpriceChanging(Decimal value);
        /// <summary>
        /// 当 markprice 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarkpriceChanged();
        
        /// <summary>
        /// 初始化 Mshopproductprice 实体类的新实例。
        /// </summary>
        public Mshopproductprice() {
            this.OnCreated();
        }
        /// <summary>
        /// 店铺ID
        /// </summary>
        [Column(Storage="_shopid", DbType="int")]
        [DisplayName("店铺ID")]
        [Description("店铺ID")]
        public Int32? shopid {
            get {
                return this._shopid;
            }
            set {
                if ((this._shopid != value)) {
                    this.OnshopidChanging(value);
                    this.SendPropertyChanging("shopid", value);
                    this._shopid = value;
                    this.SendPropertyChanged("shopid", value);
                    this.OnshopidChanged();
                }
            }
        }
        /// <summary>
        /// 产品ID
        /// </summary>
        [Column(Storage="_productid", DbType="int")]
        [DisplayName("产品ID")]
        [Description("产品ID")]
        public Int32? productid {
            get {
                return this._productid;
            }
            set {
                if ((this._productid != value)) {
                    this.OnproductidChanging(value);
                    this.SendPropertyChanging("productid", value);
                    this._productid = value;
                    this.SendPropertyChanged("productid", value);
                    this.OnproductidChanged();
                }
            }
        }
        /// <summary>
        /// 产品属性ID
        /// </summary>
        [Column(Storage="_attributeid", DbType="int")]
        [DisplayName("产品属性ID")]
        [Description("产品属性ID")]
        public Int32? attributeid {
            get {
                return this._attributeid;
            }
            set {
                if ((this._attributeid != value)) {
                    this.OnattributeidChanging(value);
                    this.SendPropertyChanging("attributeid", value);
                    this._attributeid = value;
                    this.SendPropertyChanged("attributeid", value);
                    this.OnattributeidChanged();
                }
            }
        }
        /// <summary>
        /// 销售价格
        /// </summary>
        [Column(Storage="_saleprice", DbType="decimal NOT NULL", CanBeNull=false)]
        [DisplayName("销售价格")]
        [Description("销售价格")]
        public Decimal saleprice {
            get {
                return this._saleprice;
            }
            set {
                this.OnsalepriceChanging(value);
                this.SendPropertyChanging("saleprice", value);
                this._saleprice = value;
                this.SendPropertyChanged("saleprice", value);
                this.OnsalepriceChanged();
            }
        }
        /// <summary>
        /// 采购价格
        /// </summary>
        [Column(Storage="_buyprice", DbType="decimal NOT NULL", CanBeNull=false)]
        [DisplayName("采购价格")]
        [Description("采购价格")]
        public Decimal buyprice {
            get {
                return this._buyprice;
            }
            set {
                this.OnbuypriceChanging(value);
                this.SendPropertyChanging("buyprice", value);
                this._buyprice = value;
                this.SendPropertyChanged("buyprice", value);
                this.OnbuypriceChanged();
            }
        }
        /// <summary>
        /// 市场价格
        /// </summary>
        [Column(Storage="_markprice", DbType="decimal NOT NULL", CanBeNull=false)]
        [DisplayName("市场价格")]
        [Description("市场价格")]
        public Decimal markprice {
            get {
                return this._markprice;
            }
            set {
                this.OnmarkpriceChanging(value);
                this.SendPropertyChanging("markprice", value);
                this._markprice = value;
                this.SendPropertyChanged("markprice", value);
                this.OnmarkpriceChanged();
            }
        }
    }
    /// <summary>
    /// 动作(权限)表
    /// </summary>
    [Table(Name="t_sys_action")]
    [Serializable()]
    [DisplayName("动作(权限)表")]
    [Description("动作(权限)表")]
    public partial class Msys_action : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 标识
        /// </summary>
        String _mark;
        /// <summary>
        /// 模块ID
        /// </summary>
        Int32? _mid;
        /// <summary>
        /// 权限类型
        /// </summary>
        Int32? _actype;
        /// <summary>
        /// 描太空
        /// </summary>
        String _descript;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 mark 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarkChanging(String value);
        /// <summary>
        /// 当 mark 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarkChanged();
        /// <summary>
        /// 当 mid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmidChanging(Int32? value);
        /// <summary>
        /// 当 mid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmidChanged();
        /// <summary>
        /// 当 actype 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnactypeChanging(Int32? value);
        /// <summary>
        /// 当 actype 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnactypeChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Msys_action 实体类的新实例。
        /// </summary>
        public Msys_action() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(30)")]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                if ((this._title != value)) {
                    this.OntitleChanging(value);
                    this.SendPropertyChanging("title", value);
                    this._title = value;
                    this.SendPropertyChanged("title", value);
                    this.OntitleChanged();
                }
            }
        }
        /// <summary>
        /// 标识
        /// </summary>
        [Column(Storage="_mark", DbType="varchar(30)")]
        [DisplayName("标识")]
        [Description("标识")]
        public String mark {
            get {
                return this._mark;
            }
            set {
                if ((this._mark != value)) {
                    this.OnmarkChanging(value);
                    this.SendPropertyChanging("mark", value);
                    this._mark = value;
                    this.SendPropertyChanged("mark", value);
                    this.OnmarkChanged();
                }
            }
        }
        /// <summary>
        /// 模块ID
        /// </summary>
        [Column(Storage="_mid", DbType="int")]
        [DisplayName("模块ID")]
        [Description("模块ID")]
        public Int32? mid {
            get {
                return this._mid;
            }
            set {
                if ((this._mid != value)) {
                    this.OnmidChanging(value);
                    this.SendPropertyChanging("mid", value);
                    this._mid = value;
                    this.SendPropertyChanged("mid", value);
                    this.OnmidChanged();
                }
            }
        }
        /// <summary>
        /// 权限类型
        /// </summary>
        [Column(Storage="_actype", DbType="int")]
        [DisplayName("权限类型")]
        [Description("权限类型")]
        public Int32? actype {
            get {
                return this._actype;
            }
            set {
                if ((this._actype != value)) {
                    this.OnactypeChanging(value);
                    this.SendPropertyChanging("actype", value);
                    this._actype = value;
                    this.SendPropertyChanged("actype", value);
                    this.OnactypeChanged();
                }
            }
        }
        /// <summary>
        /// 描太空
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(300)")]
        [DisplayName("描太空")]
        [Description("描太空")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    /// 所块表
    /// </summary>
    [Table(Name="t_sys_module")]
    [Serializable()]
    [DisplayName("所块表")]
    [Description("所块表")]
    public partial class Msys_module : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 标识
        /// </summary>
        String _mark;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 类型
        /// </summary>
        String _type;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 mark 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarkChanging(String value);
        /// <summary>
        /// 当 mark 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarkChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 type 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntypeChanging(String value);
        /// <summary>
        /// 当 type 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntypeChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Msys_module 实体类的新实例。
        /// </summary>
        public Msys_module() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(30) NOT NULL", CanBeNull=false)]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 标识
        /// </summary>
        [Column(Storage="_mark", DbType="varchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName("标识")]
        [Description("标识")]
        public String mark {
            get {
                return this._mark;
            }
            set {
                this.OnmarkChanging(value);
                this.SendPropertyChanging("mark", value);
                this._mark = value;
                this.SendPropertyChanged("mark", value);
                this.OnmarkChanged();
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(300)")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 类型
        /// </summary>
        [Column(Storage="_type", DbType="varchar(50)")]
        [DisplayName("类型")]
        [Description("类型")]
        public String type {
            get {
                return this._type;
            }
            set {
                if ((this._type != value)) {
                    this.OntypeChanging(value);
                    this.SendPropertyChanging("type", value);
                    this._type = value;
                    this.SendPropertyChanged("type", value);
                    this.OntypeChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    /// 所块链接表
    /// </summary>
    [Table(Name="t_sys_module_link")]
    [Serializable()]
    [DisplayName("所块链接表")]
    [Description("所块链接表")]
    public partial class Msys_module_link : DALModelBase {
        /// <summary>
        ///  
        /// </summary>
        Int32 _mid;
        /// <summary>
        ///  
        /// </summary>
        String _title;
        /// <summary>
        ///  
        /// </summary>
        String _icourl;
        /// <summary>
        ///  
        /// </summary>
        String _linkurl;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 mid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmidChanging(Int32 value);
        /// <summary>
        /// 当 mid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 icourl 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnicourlChanging(String value);
        /// <summary>
        /// 当 icourl 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnicourlChanged();
        /// <summary>
        /// 当 linkurl 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnlinkurlChanging(String value);
        /// <summary>
        /// 当 linkurl 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnlinkurlChanged();
        
        /// <summary>
        /// 初始化 Msys_module_link 实体类的新实例。
        /// </summary>
        public Msys_module_link() {
            this.OnCreated();
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_mid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public Int32 mid {
            get {
                return this._mid;
            }
            set {
                this.OnmidChanging(value);
                this.SendPropertyChanging("mid", value);
                this._mid = value;
                this.SendPropertyChanged("mid", value);
                this.OnmidChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(30) NOT NULL", CanBeNull=false)]
        [DisplayName(" ")]
        [Description(" ")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_icourl", DbType="varchar(40)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String icourl {
            get {
                return this._icourl;
            }
            set {
                if ((this._icourl != value)) {
                    this.OnicourlChanging(value);
                    this.SendPropertyChanging("icourl", value);
                    this._icourl = value;
                    this.SendPropertyChanged("icourl", value);
                    this.OnicourlChanged();
                }
            }
        }
        /// <summary>
        ///  
        /// </summary>
        [Column(Storage="_linkurl", DbType="varchar(40)")]
        [DisplayName(" ")]
        [Description(" ")]
        public String linkurl {
            get {
                return this._linkurl;
            }
            set {
                if ((this._linkurl != value)) {
                    this.OnlinkurlChanging(value);
                    this.SendPropertyChanging("linkurl", value);
                    this._linkurl = value;
                    this.SendPropertyChanged("linkurl", value);
                    this.OnlinkurlChanged();
                }
            }
        }
    }
    /// <summary>
    /// 角色表
    /// </summary>
    [Table(Name="t_sys_role")]
    [Serializable()]
    [DisplayName("角色表")]
    [Description("角色表")]
    public partial class Msys_role : DALModelBase {
        /// <summary>
        /// 序号
        /// </summary>
        Int32 _id;
        /// <summary>
        /// 上级ID
        /// </summary>
        Int32 _parentid;
        /// <summary>
        /// 名称
        /// </summary>
        String _title;
        /// <summary>
        /// 标识
        /// </summary>
        String _mark;
        /// <summary>
        /// 描述
        /// </summary>
        String _descript;
        /// <summary>
        /// 排序
        /// </summary>
        Int32? _sort;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 id 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnidChanging(Int32 value);
        /// <summary>
        /// 当 id 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnidChanged();
        /// <summary>
        /// 当 parentid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnparentidChanging(Int32 value);
        /// <summary>
        /// 当 parentid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnparentidChanged();
        /// <summary>
        /// 当 title 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OntitleChanging(String value);
        /// <summary>
        /// 当 title 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OntitleChanged();
        /// <summary>
        /// 当 mark 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmarkChanging(String value);
        /// <summary>
        /// 当 mark 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmarkChanged();
        /// <summary>
        /// 当 descript 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OndescriptChanging(String value);
        /// <summary>
        /// 当 descript 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OndescriptChanged();
        /// <summary>
        /// 当 sort 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnsortChanging(Int32? value);
        /// <summary>
        /// 当 sort 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnsortChanged();
        
        /// <summary>
        /// 初始化 Msys_role 实体类的新实例。
        /// </summary>
        public Msys_role() {
            this.OnCreated();
        }
        /// <summary>
        /// 序号
        /// </summary>
        [Column(Storage="_id", DbType="int NOT NULL", CanBeNull=false, IsDbGenerated=true, IsPrimaryKey=true)]
        [DisplayName("序号")]
        [Description("序号")]
        public Int32 id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        /// <summary>
        /// 上级ID
        /// </summary>
        [Column(Storage="_parentid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("上级ID")]
        [Description("上级ID")]
        public Int32 parentid {
            get {
                return this._parentid;
            }
            set {
                this.OnparentidChanging(value);
                this.SendPropertyChanging("parentid", value);
                this._parentid = value;
                this.SendPropertyChanged("parentid", value);
                this.OnparentidChanged();
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Column(Storage="_title", DbType="nvarchar(30) NOT NULL", CanBeNull=false)]
        [DisplayName("名称")]
        [Description("名称")]
        public String title {
            get {
                return this._title;
            }
            set {
                this.OntitleChanging(value);
                this.SendPropertyChanging("title", value);
                this._title = value;
                this.SendPropertyChanged("title", value);
                this.OntitleChanged();
            }
        }
        /// <summary>
        /// 标识
        /// </summary>
        [Column(Storage="_mark", DbType="varchar(20) NOT NULL", CanBeNull=false)]
        [DisplayName("标识")]
        [Description("标识")]
        public String mark {
            get {
                return this._mark;
            }
            set {
                this.OnmarkChanging(value);
                this.SendPropertyChanging("mark", value);
                this._mark = value;
                this.SendPropertyChanged("mark", value);
                this.OnmarkChanged();
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(Storage="_descript", DbType="nvarchar(200)")]
        [DisplayName("描述")]
        [Description("描述")]
        public String descript {
            get {
                return this._descript;
            }
            set {
                if ((this._descript != value)) {
                    this.OndescriptChanging(value);
                    this.SendPropertyChanging("descript", value);
                    this._descript = value;
                    this.SendPropertyChanged("descript", value);
                    this.OndescriptChanged();
                }
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Column(Storage="_sort", DbType="int")]
        [DisplayName("排序")]
        [Description("排序")]
        public Int32? sort {
            get {
                return this._sort;
            }
            set {
                if ((this._sort != value)) {
                    this.OnsortChanging(value);
                    this.SendPropertyChanging("sort", value);
                    this._sort = value;
                    this.SendPropertyChanged("sort", value);
                    this.OnsortChanged();
                }
            }
        }
    }
    /// <summary>
    /// 角色权限关联表
    /// </summary>
    [Table(Name="t_sys_roleactiondef")]
    [Serializable()]
    [DisplayName("角色权限关联表")]
    [Description("角色权限关联表")]
    public partial class Msys_roleactiondef : DALModelBase {
        /// <summary>
        /// 权限ID
        /// </summary>
        Int32 _actionid;
        /// <summary>
        /// 模块ID
        /// </summary>
        Int32 _moduleid;
        /// <summary>
        /// 角色ID
        /// </summary>
        Int32 _roleid;
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        /// <summary>
        /// 当 actionid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnactionidChanging(Int32 value);
        /// <summary>
        /// 当 actionid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnactionidChanged();
        /// <summary>
        /// 当 moduleid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnmoduleidChanging(Int32 value);
        /// <summary>
        /// 当 moduleid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnmoduleidChanged();
        /// <summary>
        /// 当 roleid 属性的值发生更改时，调用此方法。
        /// </summary>
        partial void OnroleidChanging(Int32 value);
        /// <summary>
        /// 当 roleid 属性的值发生更改后，调用此方法。
        /// </summary>
        partial void OnroleidChanged();
        
        /// <summary>
        /// 初始化 Msys_roleactiondef 实体类的新实例。
        /// </summary>
        public Msys_roleactiondef() {
            this.OnCreated();
        }
        /// <summary>
        /// 权限ID
        /// </summary>
        [Column(Storage="_actionid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("权限ID")]
        [Description("权限ID")]
        public Int32 actionid {
            get {
                return this._actionid;
            }
            set {
                this.OnactionidChanging(value);
                this.SendPropertyChanging("actionid", value);
                this._actionid = value;
                this.SendPropertyChanged("actionid", value);
                this.OnactionidChanged();
            }
        }
        /// <summary>
        /// 模块ID
        /// </summary>
        [Column(Storage="_moduleid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("模块ID")]
        [Description("模块ID")]
        public Int32 moduleid {
            get {
                return this._moduleid;
            }
            set {
                this.OnmoduleidChanging(value);
                this.SendPropertyChanging("moduleid", value);
                this._moduleid = value;
                this.SendPropertyChanged("moduleid", value);
                this.OnmoduleidChanged();
            }
        }
        /// <summary>
        /// 角色ID
        /// </summary>
        [Column(Storage="_roleid", DbType="int NOT NULL", CanBeNull=false)]
        [DisplayName("角色ID")]
        [Description("角色ID")]
        public Int32 roleid {
            get {
                return this._roleid;
            }
            set {
                this.OnroleidChanging(value);
                this.SendPropertyChanging("roleid", value);
                this._roleid = value;
                this.SendPropertyChanged("roleid", value);
                this.OnroleidChanged();
            }
        }
    }
}
