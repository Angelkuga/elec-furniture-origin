namespace Haojibiz.Model {
    using System;
    
    /// <summary>
    /// 表示 t_admin 表的字段的枚举。管理员
    /// </summary>
    [Flags()]
    public enum Eadmin : ulong {
        /// <summary>
        /// 序号2
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 登陆名
        /// </summary>
        name = 2ul,
        /// <summary>
        /// 登陆密码MD5
        /// </summary>
        password = 4ul,
        /// <summary>
        /// 显示名称
        /// </summary>
        displayname = 8ul,
        /// <summary>
        /// 安全问题
        /// </summary>
        question = 16ul,
        /// <summary>
        /// 答案
        /// </summary>
        answer = 32ul,
        /// <summary>
        /// 邮件
        /// </summary>
        email = 64ul,
        /// <summary>
        /// 电话
        /// </summary>
        phone = 128ul,
        /// <summary>
        /// 地区
        /// </summary>
        areacode = 256ul,
        /// <summary>
        /// 地址
        /// </summary>
        address = 512ul,
        /// <summary>
        /// 登陆次数
        /// </summary>
        logincount = 1024ul,
        /// <summary>
        /// 锁定
        /// </summary>
        islock = 2048ul,
        /// <summary>
        /// 最后活动模块
        /// </summary>
        lastmodule = 4096ul,
        /// <summary>
        /// 创建时间
        /// </summary>
        createdate = 8192ul,
        /// <summary>
        /// 最后活动时间
        /// </summary>
        lastactivitydate = 16384ul,
    }
    /// <summary>
    /// 表示 t_advertising 表的字段的枚举。广告表
    /// </summary>
    [Flags()]
    public enum Eadvertising : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 广告类别ID
        /// </summary>
        categoryid = 2ul,
        /// <summary>
        /// 广告名称
        /// </summary>
        title = 4ul,
        /// <summary>
        /// 广告连接
        /// </summary>
        linkurl = 8ul,
        /// <summary>
        /// Flash地址
        /// </summary>
        flashurl = 16ul,
        /// <summary>
        /// 图片地址
        /// </summary>
        imgurl = 32ul,
        /// <summary>
        /// 视频地址
        /// </summary>
        videourl = 64ul,
        /// <summary>
        /// 文字广告内容
        /// </summary>
        adtext = 128ul,
        /// <summary>
        /// 广告代码(JS广告)
        /// </summary>
        adcode = 256ul,
        /// <summary>
        /// 是否启用
        /// </summary>
        isopen = 512ul,
        /// <summary>
        /// 广告联系人
        /// </summary>
        adlinkman = 1024ul,
        /// <summary>
        /// 广告联系电话
        /// </summary>
        adlinkphone = 2048ul,
        /// <summary>
        /// 联系邮件
        /// </summary>
        adlinkemail = 4096ul,
        /// <summary>
        /// 修改时间
        /// </summary>
        lastedittime = 8192ul,
        /// <summary>
        /// 修改人
        /// </summary>
        lasteditaid = 16384ul,
    }
    /// <summary>
    /// 表示 t_advertisingcategory 表的字段的枚举。广告分类
    /// </summary>
    [Flags()]
    public enum Eadvertisingcategory : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 上级分类
        /// </summary>
        parentid = 2ul,
        /// <summary>
        /// 所属模块
        /// </summary>
        moduleid = 4ul,
        /// <summary>
        /// 所属模块value
        /// </summary>
        modulevalue = 8ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 16ul,
        /// <summary>
        /// 所属位置描述图片
        /// </summary>
        img = 32ul,
        /// <summary>
        /// 高
        /// </summary>
        height = 64ul,
        /// <summary>
        /// 宽
        /// </summary>
        width = 128ul,
        /// <summary>
        /// 是否启用
        /// </summary>
        isopen = 256ul,
        /// <summary>
        /// 广告类型（文字、视频、图片 ……）
        /// </summary>
        adtype = 512ul,
        /// <summary>
        /// 开始时间
        /// </summary>
        starttime = 1024ul,
        /// <summary>
        /// 结束时间
        /// </summary>
        endtime = 2048ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 4096ul,
        /// <summary>
        /// 模版
        /// </summary>
        template = 8192ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 16384ul,
    }
    /// <summary>
    /// 表示 t_aggregation 表的字段的枚举。聚合信息
    /// </summary>
    [Flags()]
    public enum Eaggregation : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 信息所属模块（type表ID）
        /// </summary>
        type = 2ul,
        /// <summary>
        /// 显示文字1
        /// </summary>
        title = 4ul,
        /// <summary>
        /// 显示文字2
        /// </summary>
        title1 = 8ul,
        /// <summary>
        /// 显示文字3
        /// </summary>
        title2 = 16ul,
        /// <summary>
        /// 显示文字4
        /// </summary>
        title3 = 32ul,
        /// <summary>
        /// 显示图片
        /// </summary>
        thumb = 64ul,
        /// <summary>
        /// 图片高
        /// </summary>
        thumbw = 128ul,
        /// <summary>
        /// 图片高
        /// </summary>
        thumbh = 256ul,
        /// <summary>
        /// 幻灯图
        /// </summary>
        bannel = 512ul,
        /// <summary>
        /// 连接1
        /// </summary>
        url = 1024ul,
        /// <summary>
        /// 连接2
        /// </summary>
        url1 = 2048ul,
        /// <summary>
        /// 连接3
        /// </summary>
        url2 = 4096ul,
        /// <summary>
        /// 描述内容
        /// </summary>
        descript = 8192ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 16384ul,
        /// <summary>
        /// 点击率
        /// </summary>
        hits = 32768ul,
        /// <summary>
        /// 最改时间
        /// </summary>
        lastedittime = 65536ul,
        /// <summary>
        /// 添加时间
        /// </summary>
        createmid = 131072ul,
    }
    /// <summary>
    /// 表示 t_aggregationtype 表的字段的枚举。信息所属模块
    /// </summary>
    [Flags()]
    public enum Eaggregationtype : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 上级模块
        /// </summary>
        parentid = 2ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 4ul,
        /// <summary>
        /// 名称1
        /// </summary>
        title1 = 8ul,
        /// <summary>
        /// 缩略图
        /// </summary>
        thumb = 16ul,
        /// <summary>
        /// 连接
        /// </summary>
        url = 32ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 64ul,
    }
    /// <summary>
    /// 表示 t_appbrand 表的字段的枚举。经销商、店铺品牌使用申请表
    /// </summary>
    [Flags()]
    public enum Eappbrand : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 经销商ID
        /// </summary>
        dealerid = 2ul,
        /// <summary>
        /// 经销商名称
        /// </summary>
        dealetitle = 4ul,
        /// <summary>
        /// 品牌ID
        /// </summary>
        brandid = 8ul,
        /// <summary>
        /// 品牌名称
        /// </summary>
        brandtitle = 16ul,
        /// <summary>
        /// 品牌所属厂家ID
        /// </summary>
        companyid = 32ul,
        /// <summary>
        /// 品牌所属厂家名称
        /// </summary>
        companytitle = 64ul,
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        shopid = 128ul,
        /// <summary>
        /// 所属店铺名称
        /// </summary>
        shoptitle = 256ul,
        /// <summary>
        ///  
        /// </summary>
        appmodule = 512ul,
        /// <summary>
        ///  
        /// </summary>
        apptype = 1024ul,
        /// <summary>
        ///  
        /// </summary>
        apptime = 2048ul,
        /// <summary>
        ///  
        /// </summary>
        createmid = 4096ul,
        /// <summary>
        /// 最后修改时间
        /// </summary>
        lastedittime = 8192ul,
        /// <summary>
        /// 状态
        /// </summary>
        auditstatus = 16384ul,
    }
    /// <summary>
    /// 表示 t_appbrandcustomer 表的字段的枚举。 
    /// </summary>
    [Flags()]
    public enum Eappbrandcustomer : ulong {
        /// <summary>
        ///  
        /// </summary>
        id = 1ul,
        /// <summary>
        ///  
        /// </summary>
        aid = 2ul,
        /// <summary>
        ///  
        /// </summary>
        name = 4ul,
        /// <summary>
        ///  
        /// </summary>
        phone = 8ul,
        /// <summary>
        ///  
        /// </summary>
        mphone = 16ul,
        /// <summary>
        ///  
        /// </summary>
        email = 32ul,
        /// <summary>
        ///  
        /// </summary>
        address = 64ul,
        /// <summary>
        ///  
        /// </summary>
        descript = 128ul,
        /// <summary>
        ///  
        /// </summary>
        cus = 256ul,
        /// <summary>
        /// 创建时间
        /// </summary>
        CreateTime = 512ul,
    }
    /// <summary>
    /// 表示 t_area 表的字段的枚举。地区表
    /// </summary>
    [Flags()]
    public enum Earea : ulong {
        /// <summary>
        /// 地区代码
        /// </summary>
        areacode = 1ul,
        /// <summary>
        /// 上级代码
        /// </summary>
        parentcode = 2ul,
        /// <summary>
        /// 地区名称
        /// </summary>
        areaname = 4ul,
        /// <summary>
        /// 邮篇
        /// </summary>
        areazipcode = 8ul,
        /// <summary>
        /// 所属地区组(华东/华南等)
        /// </summary>
        grouparea = 16ul,
    }
    /// <summary>
    /// 表示 t_article 表的字段的枚举。文章表
    /// </summary>
    [Flags()]
    public enum Earticle : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        ///  
        /// </summary>
        nodeid = 2ul,
        /// <summary>
        /// 标题名称
        /// </summary>
        title = 4ul,
        /// <summary>
        /// 副标题
        /// </summary>
        subtitle = 8ul,
        /// <summary>
        ///  
        /// </summary>
        thumbnail = 16ul,
        /// <summary>
        ///  
        /// </summary>
        imagelist = 32ul,
        /// <summary>
        ///  
        /// </summary>
        filelist = 64ul,
        /// <summary>
        /// 属性(推荐,置顶. ……)
        /// </summary>
        attribute = 128ul,
        /// <summary>
        ///  
        /// </summary>
        descript = 256ul,
        /// <summary>
        /// 作者
        /// </summary>
        author = 512ul,
        /// <summary>
        ///  
        /// </summary>
        source = 1024ul,
        /// <summary>
        ///  
        /// </summary>
        tags = 2048ul,
        /// <summary>
        ///  
        /// </summary>
        sort = 4096ul,
        /// <summary>
        ///  
        /// </summary>
        setting = 8192ul,
        /// <summary>
        ///  
        /// </summary>
        addusername = 16384ul,
        /// <summary>
        ///  
        /// </summary>
        adduserid = 32768ul,
        /// <summary>
        ///  
        /// </summary>
        adddatetime = 65536ul,
        /// <summary>
        ///  
        /// </summary>
        lasteditusername = 131072ul,
        /// <summary>
        ///  
        /// </summary>
        lastedituserid = 262144ul,
        /// <summary>
        ///  
        /// </summary>
        lasteditdatetime = 524288ul,
    }
    /// <summary>
    /// 表示 t_article_data 表的字段的枚举。 
    /// </summary>
    [Flags()]
    public enum Earticle_data : ulong {
        /// <summary>
        ///  
        /// </summary>
        articleid = 1ul,
        /// <summary>
        ///  
        /// </summary>
        data = 2ul,
    }
    /// <summary>
    /// 表示 t_article_node 表的字段的枚举。 
    /// </summary>
    [Flags()]
    public enum Earticle_node : ulong {
        /// <summary>
        ///  
        /// </summary>
        id = 1ul,
        /// <summary>
        ///  
        /// </summary>
        parentid = 2ul,
        /// <summary>
        ///  
        /// </summary>
        title = 4ul,
        /// <summary>
        ///  
        /// </summary>
        subtitle = 8ul,
        /// <summary>
        ///  
        /// </summary>
        mark = 16ul,
        /// <summary>
        ///  
        /// </summary>
        formsid = 32ul,
        /// <summary>
        ///  
        /// </summary>
        lft = 64ul,
        /// <summary>
        ///  
        /// </summary>
        rgt = 128ul,
        /// <summary>
        ///  
        /// </summary>
        lev = 256ul,
        /// <summary>
        ///  
        /// </summary>
        path = 512ul,
        /// <summary>
        ///  
        /// </summary>
        linktype = 1024ul,
        /// <summary>
        ///  
        /// </summary>
        linkurl = 2048ul,
        /// <summary>
        ///  
        /// </summary>
        tempcon = 4096ul,
        /// <summary>
        ///  
        /// </summary>
        templist = 8192ul,
        /// <summary>
        ///  
        /// </summary>
        tempindex = 16384ul,
        /// <summary>
        ///  
        /// </summary>
        filepath = 32768ul,
        /// <summary>
        ///  
        /// </summary>
        keywords = 65536ul,
        /// <summary>
        ///  
        /// </summary>
        descript = 131072ul,
        /// <summary>
        ///  
        /// </summary>
        tags = 262144ul,
        /// <summary>
        ///  
        /// </summary>
        sort = 524288ul,
        /// <summary>
        ///  
        /// </summary>
        setting = 1048576ul,
        /// <summary>
        ///  
        /// </summary>
        addusername = 2097152ul,
        /// <summary>
        ///  
        /// </summary>
        adduserid = 4194304ul,
        /// <summary>
        ///  
        /// </summary>
        adddatetime = 8388608ul,
        /// <summary>
        ///  
        /// </summary>
        lasteditusername = 16777216ul,
        /// <summary>
        ///  
        /// </summary>
        lastedituserid = 33554432ul,
        /// <summary>
        ///  
        /// </summary>
        lasteditdatetime = 67108864ul,
    }
    /// <summary>
    /// 表示 t_brand 表的字段的枚举。品牌表
    /// </summary>
    [Flags()]
    public enum Ebrand : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 所属企业ID
        /// </summary>
        companyid = 2ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 4ul,
        /// <summary>
        /// 索引
        /// </summary>
        letter = 8ul,
        /// <summary>
        /// 组ID
        /// </summary>
        groupid = 16ul,
        /// <summary>
        /// 属性(推荐,置顶. ……)
        /// </summary>
        attribute = 32ul,
        /// <summary>
        /// 品牌下产品分类ID（该信息有哪些产品分类）
        /// </summary>
        productcategory = 64ul,
        /// <summary>
        /// 主页地址
        /// </summary>
        homepage = 128ul,
        /// <summary>
        /// 产品数量
        /// </summary>
        productcount = 256ul,
        /// <summary>
        /// 价位（config表值）
        /// </summary>
        spread = 512ul,
        /// <summary>
        /// 材质（config表值）
        /// </summary>
        material = 1024ul,
        /// <summary>
        /// 风格（config表值）
        /// </summary>
        style = 2048ul,
        /// <summary>
        /// 颜色（config表值）
        /// </summary>
        color = 4096ul,
        /// <summary>
        /// 形象图
        /// </summary>
        surface = 8192ul,
        /// <summary>
        /// logo
        /// </summary>
        logo = 16384ul,
        /// <summary>
        /// 缩略图
        /// </summary>
        thumb = 32768ul,
        /// <summary>
        /// 幻灯图
        /// </summary>
        bannel = 65536ul,
        /// <summary>
        /// 描述图
        /// </summary>
        desimage = 131072ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 262144ul,
        /// <summary>
        /// 关键字
        /// </summary>
        keywords = 524288ul,
        /// <summary>
        /// 模版ID
        /// </summary>
        template = 1048576ul,
        /// <summary>
        /// 点击量
        /// </summary>
        hits = 2097152ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 4194304ul,
        /// <summary>
        /// 创建人
        /// </summary>
        createmid = 8388608ul,
        /// <summary>
        /// 修改人
        /// </summary>
        lasteditid = 16777216ul,
        /// <summary>
        /// 最后个改
        /// </summary>
        lastedittime = 33554432ul,
        /// <summary>
        /// 审核状态，-1正在审核，0待审核，1审核通过，-99未通过
        /// </summary>
        auditstatus = 67108864ul,
        /// <summary>
        /// 审核状态，-1正在审核，0待审核，1审核通过，-99未通过
        /// </summary>
        linestatus = 134217728ul,
        /// <summary>
        /// 创建时间
        /// </summary>
        Createtime = 268435456ul,
    }
    /// <summary>
    /// 表示 t_brands 表的字段的枚举。品牌系列表
    /// </summary>
    [Flags()]
    public enum Ebrands : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 所属品牌ID
        /// </summary>
        brandid = 2ul,
        /// <summary>
        /// 系列名称
        /// </summary>
        title = 4ul,
        /// <summary>
        /// 索引
        /// </summary>
        letter = 8ul,
        /// <summary>
        /// 属性
        /// </summary>
        attribute = 16ul,
        /// <summary>
        /// 产品数量
        /// </summary>
        productcount = 32ul,
        /// <summary>
        /// 价位（config表值）
        /// </summary>
        spread = 64ul,
        /// <summary>
        /// 材质（config表值）
        /// </summary>
        material = 128ul,
        /// <summary>
        /// 风格（config表值）
        /// </summary>
        style = 256ul,
        /// <summary>
        /// 形象图
        /// </summary>
        surface = 512ul,
        /// <summary>
        /// logo
        /// </summary>
        logo = 1024ul,
        /// <summary>
        /// 缩略图
        /// </summary>
        thumb = 2048ul,
        /// <summary>
        /// 幻灯图
        /// </summary>
        bannel = 4096ul,
        /// <summary>
        /// 描述图
        /// </summary>
        desimage = 8192ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 16384ul,
        /// <summary>
        /// 关键字
        /// </summary>
        keywords = 32768ul,
        /// <summary>
        /// 模版ID
        /// </summary>
        template = 65536ul,
        /// <summary>
        /// 点击量
        /// </summary>
        hits = 131072ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 262144ul,
        /// <summary>
        /// 创建人
        /// </summary>
        createmid = 524288ul,
        /// <summary>
        /// 最后修改人
        /// </summary>
        lasteditid = 1048576ul,
        /// <summary>
        /// 最后个改
        /// </summary>
        lastedittime = 2097152ul,
        /// <summary>
        /// 审核状态
        /// </summary>
        auditstatus = 4194304ul,
        /// <summary>
        /// 在线状态
        /// </summary>
        linestatus = 8388608ul,
        /// <summary>
        ///  
        /// </summary>
        color = 16777216ul,
    }
    /// <summary>
    /// 表示 t_company 表的字段的枚举。厂家表
    /// </summary>
    [Flags()]
    public enum Ecompany : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 用户表ID
        /// </summary>
        mid = 2ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 4ul,
        /// <summary>
        /// 索引
        /// </summary>
        letter = 8ul,
        /// <summary>
        /// 组ID
        /// </summary>
        groupid = 16ul,
        /// <summary>
        /// 属性
        /// </summary>
        attribute = 32ul,
        /// <summary>
        /// 行业
        /// </summary>
        industry = 64ul,
        /// <summary>
        /// 产品分类
        /// </summary>
        productcategory = 128ul,
        /// <summary>
        /// 是否vip
        /// </summary>
        vip = 256ul,
        /// <summary>
        /// 地区代码
        /// </summary>
        areacode = 512ul,
        /// <summary>
        /// 地址
        /// </summary>
        address = 1024ul,
        /// <summary>
        /// 地图API值
        /// </summary>
        mapapi = 2048ul,
        /// <summary>
        /// 外观图
        /// </summary>
        staffsize = 4096ul,
        /// <summary>
        /// 注册时间
        /// </summary>
        regyear = 8192ul,
        /// <summary>
        /// 注册城市
        /// </summary>
        regcity = 16384ul,
        /// <summary>
        /// 销售信息
        /// </summary>
        buy = 32768ul,
        /// <summary>
        /// 采购信息
        /// </summary>
        sell = 65536ul,
        /// <summary>
        /// 连系人
        /// </summary>
        linkman = 131072ul,
        /// <summary>
        /// 联系电话
        /// </summary>
        phone = 262144ul,
        /// <summary>
        /// 联系手机
        /// </summary>
        mphone = 524288ul,
        /// <summary>
        /// 传真
        /// </summary>
        fax = 1048576ul,
        /// <summary>
        /// 邮件
        /// </summary>
        email = 2097152ul,
        /// <summary>
        /// 邮编
        /// </summary>
        postcode = 4194304ul,
        /// <summary>
        /// 主页
        /// </summary>
        homepage = 8388608ul,
        /// <summary>
        /// 域名
        /// </summary>
        domain = 16777216ul,
        /// <summary>
        /// 域名IP
        /// </summary>
        domainip = 33554432ul,
        /// <summary>
        /// 备案号
        /// </summary>
        icp = 67108864ul,
        /// <summary>
        /// 外观图
        /// </summary>
        surface = 134217728ul,
        /// <summary>
        /// logo
        /// </summary>
        logo = 268435456ul,
        /// <summary>
        /// 缩略图
        /// </summary>
        thumb = 536870912ul,
        /// <summary>
        /// 幻灯图
        /// </summary>
        bannel = 1073741824ul,
        /// <summary>
        /// 描述图
        /// </summary>
        desimage = 2147483648ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 4294967296ul,
        /// <summary>
        /// 关键字
        /// </summary>
        keywords = 8589934592ul,
        /// <summary>
        /// 模版ID
        /// </summary>
        template = 17179869184ul,
        /// <summary>
        /// 点击量
        /// </summary>
        hits = 34359738368ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 68719476736ul,
        /// <summary>
        /// 创建人
        /// </summary>
        createmid = 137438953472ul,
        /// <summary>
        /// 最后修改人
        /// </summary>
        lastedid = 274877906944ul,
        /// <summary>
        /// 最后修改时间
        /// </summary>
        lastedittime = 549755813888ul,
        /// <summary>
        /// 审核状态
        /// </summary>
        auditstatus = 1099511627776ul,
        /// <summary>
        /// 上下线状态
        /// </summary>
        linestatus = 2199023255552ul,
        /// <summary>
        ///  
        /// </summary>
        license = 4398046511104ul,
        /// <summary>
        ///  
        /// </summary>
        registration = 8796093022208ul,
        /// <summary>
        ///  
        /// </summary>
        organization = 17592186044416ul,
        /// <summary>
        ///  
        /// </summary>
        Createtime = 35184372088832ul,
    }
    /// <summary>
    /// 表示 t_companygroup 表的字段的枚举。厂家组表
    /// </summary>
    [Flags()]
    public enum Ecompanygroup : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 组名称
        /// </summary>
        title = 2ul,
        /// <summary>
        /// 组名称颜色
        /// </summary>
        color = 4ul,
        /// <summary>
        /// 组图标
        /// </summary>
        avatar = 8ul,
        /// <summary>
        /// 积分达到
        /// </summary>
        integral = 16ul,
        /// <summary>
        /// 金钱达到
        /// </summary>
        money = 32ul,
        /// <summary>
        /// 广告数量限制
        /// </summary>
        adcount = 64ul,
        /// <summary>
        /// 店铺数量限制
        /// </summary>
        shopcount = 128ul,
        /// <summary>
        /// 品牌数量限制
        /// </summary>
        brandcount = 256ul,
        /// <summary>
        /// 促销信息数量限制
        /// </summary>
        promotioncount = 512ul,
        /// <summary>
        /// 推荐数量限制
        /// </summary>
        adrecommend = 1024ul,
        /// <summary>
        /// 推荐店铺数量限制
        /// </summary>
        shoprecommend = 2048ul,
        /// <summary>
        ///  
        /// </summary>
        brandrecommend = 4096ul,
        /// <summary>
        ///  
        /// </summary>
        promotionrecommend = 8192ul,
        /// <summary>
        ///  
        /// </summary>
        permissions = 16384ul,
        /// <summary>
        /// 级别
        /// </summary>
        lev = 32768ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 65536ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 131072ul,
    }
    /// <summary>
    /// 表示 t_config 表的字段的枚举。配置表
    /// </summary>
    [Flags()]
    public enum Econfig : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 2ul,
        /// <summary>
        /// 值
        /// </summary>
        value = 4ul,
        /// <summary>
        /// 配置类型
        /// </summary>
        type = 8ul,
        /// <summary>
        /// 所属模块
        /// </summary>
        module = 16ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 32ul,
    }
    /// <summary>
    /// 表示 t_configtype 表的字段的枚举。配置类型表
    /// </summary>
    [Flags()]
    public enum Econfigtype : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 类型名称
        /// </summary>
        title = 2ul,
        /// <summary>
        /// 标识
        /// </summary>
        mark = 4ul,
        /// <summary>
        /// 索引
        /// </summary>
        letter = 8ul,
        /// <summary>
        /// 类型
        /// </summary>
        type = 16ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 32ul,
        /// <summary>
        /// 数量
        /// </summary>
        count = 64ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 128ul,
    }
    /// <summary>
    /// 表示 t_dealer 表的字段的枚举。经销商
    /// </summary>
    [Flags()]
    public enum Edealer : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 用户表ID
        /// </summary>
        mid = 2ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 4ul,
        /// <summary>
        /// 索引
        /// </summary>
        letter = 8ul,
        /// <summary>
        /// 组ID
        /// </summary>
        groupid = 16ul,
        /// <summary>
        /// 属性
        /// </summary>
        attribute = 32ul,
        /// <summary>
        /// 行业
        /// </summary>
        industry = 64ul,
        /// <summary>
        /// 产品分类
        /// </summary>
        productcategory = 128ul,
        /// <summary>
        /// 是否vip
        /// </summary>
        vip = 256ul,
        /// <summary>
        /// 地区代码
        /// </summary>
        areacode = 512ul,
        /// <summary>
        /// 地址
        /// </summary>
        address = 1024ul,
        /// <summary>
        /// 地图API值
        /// </summary>
        mapapi = 2048ul,
        /// <summary>
        /// 外观图
        /// </summary>
        staffsize = 4096ul,
        /// <summary>
        /// 注册时间
        /// </summary>
        regyear = 8192ul,
        /// <summary>
        /// 注册城市
        /// </summary>
        regcity = 16384ul,
        /// <summary>
        /// 销售信息
        /// </summary>
        buy = 32768ul,
        /// <summary>
        /// 采购信息
        /// </summary>
        sell = 65536ul,
        /// <summary>
        /// 联系人
        /// </summary>
        linkman = 131072ul,
        /// <summary>
        /// 联系电话
        /// </summary>
        phone = 262144ul,
        /// <summary>
        /// 联系手机
        /// </summary>
        mphone = 524288ul,
        /// <summary>
        /// 传真
        /// </summary>
        fax = 1048576ul,
        /// <summary>
        /// 邮件
        /// </summary>
        email = 2097152ul,
        /// <summary>
        /// 邮编
        /// </summary>
        postcode = 4194304ul,
        /// <summary>
        /// 主页
        /// </summary>
        homepage = 8388608ul,
        /// <summary>
        /// 域名
        /// </summary>
        domain = 16777216ul,
        /// <summary>
        /// 域名IP
        /// </summary>
        domainip = 33554432ul,
        /// <summary>
        /// 备案号
        /// </summary>
        icp = 67108864ul,
        /// <summary>
        /// 外观图
        /// </summary>
        surface = 134217728ul,
        /// <summary>
        /// logo
        /// </summary>
        logo = 268435456ul,
        /// <summary>
        /// 缩略图
        /// </summary>
        thumb = 536870912ul,
        /// <summary>
        /// 幻灯图
        /// </summary>
        bannel = 1073741824ul,
        /// <summary>
        /// 描述图
        /// </summary>
        desimage = 2147483648ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 4294967296ul,
        /// <summary>
        /// 关键字
        /// </summary>
        keywords = 8589934592ul,
        /// <summary>
        /// 模版ID
        /// </summary>
        template = 17179869184ul,
        /// <summary>
        /// 点击量
        /// </summary>
        hits = 34359738368ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 68719476736ul,
        /// <summary>
        /// 创建人
        /// </summary>
        createmid = 137438953472ul,
        /// <summary>
        /// 最后修改人
        /// </summary>
        lastedid = 274877906944ul,
        /// <summary>
        /// 最后修改时间
        /// </summary>
        lastedittime = 549755813888ul,
        /// <summary>
        /// 审核状态
        /// </summary>
        auditstatus = 1099511627776ul,
        /// <summary>
        /// 上下线状态
        /// </summary>
        linestatus = 2199023255552ul,
        /// <summary>
        ///  
        /// </summary>
        dbook = 4398046511104ul,
        /// <summary>
        ///  
        /// </summary>
        Createtime = 8796093022208ul,
    }
    /// <summary>
    /// 表示 t_dealergroup 表的字段的枚举。经销商组表
    /// </summary>
    [Flags()]
    public enum Edealergroup : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 组名称
        /// </summary>
        title = 2ul,
        /// <summary>
        /// 组名称颜色
        /// </summary>
        color = 4ul,
        /// <summary>
        /// 组图标
        /// </summary>
        avatar = 8ul,
        /// <summary>
        /// 积分达到
        /// </summary>
        integral = 16ul,
        /// <summary>
        /// 金钱达到
        /// </summary>
        money = 32ul,
        /// <summary>
        /// 广告数量限制
        /// </summary>
        adcount = 64ul,
        /// <summary>
        /// 店铺数量限制
        /// </summary>
        shopcount = 128ul,
        /// <summary>
        /// 品牌数量限制
        /// </summary>
        brandcount = 256ul,
        /// <summary>
        /// 促销信息数量限制
        /// </summary>
        promotioncount = 512ul,
        /// <summary>
        /// 推荐数量限制
        /// </summary>
        adrecommend = 1024ul,
        /// <summary>
        /// 推荐店铺数量限制
        /// </summary>
        shoprecommend = 2048ul,
        /// <summary>
        ///  
        /// </summary>
        brandrecommend = 4096ul,
        /// <summary>
        ///  
        /// </summary>
        promotionrecommend = 8192ul,
        /// <summary>
        ///  
        /// </summary>
        permissions = 16384ul,
        /// <summary>
        /// 级别
        /// </summary>
        lev = 32768ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 65536ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 131072ul,
    }
    /// <summary>
    /// 表示 t_grouporder 表的字段的枚举。 
    /// </summary>
    [Flags()]
    public enum Egrouporder : ulong {
        /// <summary>
        ///  
        /// </summary>
        id = 1ul,
        /// <summary>
        ///  
        /// </summary>
        grouporderno = 2ul,
        /// <summary>
        ///  
        /// </summary>
        mid = 4ul,
        /// <summary>
        ///  
        /// </summary>
        fjmid = 8ul,
        /// <summary>
        ///  
        /// </summary>
        name = 16ul,
        /// <summary>
        ///  
        /// </summary>
        email = 32ul,
        /// <summary>
        ///  
        /// </summary>
        phone = 64ul,
        /// <summary>
        ///  
        /// </summary>
        fax = 128ul,
        /// <summary>
        ///  
        /// </summary>
        mphone = 256ul,
        /// <summary>
        ///  
        /// </summary>
        zip = 512ul,
        /// <summary>
        ///  
        /// </summary>
        areacode = 1024ul,
        /// <summary>
        ///  
        /// </summary>
        address = 2048ul,
        /// <summary>
        ///  
        /// </summary>
        descript = 4096ul,
        /// <summary>
        ///  
        /// </summary>
        totlepromoney = 8192ul,
        /// <summary>
        ///  
        /// </summary>
        totalmoney = 16384ul,
        /// <summary>
        ///  
        /// </summary>
        invoicemoney = 32768ul,
        /// <summary>
        ///  
        /// </summary>
        installationmeney = 65536ul,
        /// <summary>
        ///  
        /// </summary>
        status = 131072ul,
        /// <summary>
        ///  
        /// </summary>
        createtime = 262144ul,
    }
    /// <summary>
    /// 表示 t_grouporderpay 表的字段的枚举。 
    /// </summary>
    [Flags()]
    public enum Egrouporderpay : ulong {
        /// <summary>
        ///  
        /// </summary>
        id = 1ul,
        /// <summary>
        ///  
        /// </summary>
        grouporderid = 2ul,
        /// <summary>
        ///  
        /// </summary>
        grouporderno = 4ul,
        /// <summary>
        ///  
        /// </summary>
        paycode = 8ul,
        /// <summary>
        ///  
        /// </summary>
        paytype = 16ul,
        /// <summary>
        ///  
        /// </summary>
        paymoney = 32ul,
        /// <summary>
        ///  
        /// </summary>
        descript = 64ul,
        /// <summary>
        ///  
        /// </summary>
        paystatus = 128ul,
        /// <summary>
        ///  
        /// </summary>
        paydatetime = 256ul,
    }
    /// <summary>
    /// 表示 t_grouporderproduct 表的字段的枚举。 
    /// </summary>
    [Flags()]
    public enum Egrouporderproduct : ulong {
        /// <summary>
        ///  
        /// </summary>
        id = 1ul,
        /// <summary>
        ///  
        /// </summary>
        grouporderid = 2ul,
        /// <summary>
        ///  
        /// </summary>
        grouporderno = 4ul,
        /// <summary>
        ///  
        /// </summary>
        promotionid = 8ul,
        /// <summary>
        ///  
        /// </summary>
        promotiondefid = 16ul,
        /// <summary>
        ///  
        /// </summary>
        promoteionstageid = 32ul,
        /// <summary>
        ///  
        /// </summary>
        promoteionstagevalue = 64ul,
        /// <summary>
        ///  
        /// </summary>
        productid = 128ul,
        /// <summary>
        ///  
        /// </summary>
        productattributeid = 256ul,
        /// <summary>
        ///  
        /// </summary>
        productcode = 512ul,
        /// <summary>
        ///  
        /// </summary>
        productname = 1024ul,
        /// <summary>
        ///  
        /// </summary>
        color = 2048ul,
        /// <summary>
        ///  
        /// </summary>
        material = 4096ul,
        /// <summary>
        ///  
        /// </summary>
        size = 8192ul,
        /// <summary>
        ///  
        /// </summary>
        cbm = 16384ul,
        /// <summary>
        ///  
        /// </summary>
        num = 32768ul,
        /// <summary>
        ///  
        /// </summary>
        price = 65536ul,
        /// <summary>
        ///  
        /// </summary>
        totalmoney = 131072ul,
        /// <summary>
        ///  
        /// </summary>
        proprice = 262144ul,
        /// <summary>
        ///  
        /// </summary>
        prototalmoney = 524288ul,
    }
    /// <summary>
    /// 表示 t_log 表的字段的枚举。日志表
    /// </summary>
    [Flags()]
    public enum Elog : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 模块
        /// </summary>
        modeule = 2ul,
        /// <summary>
        /// 动作
        /// </summary>
        action = 4ul,
        /// <summary>
        /// 操作人ID
        /// </summary>
        operateid = 8ul,
        /// <summary>
        /// 操作人名称
        /// </summary>
        operatename = 16ul,
        /// <summary>
        /// 操作信息
        /// </summary>
        title = 32ul,
        /// <summary>
        /// 操作时间
        /// </summary>
        lastedittime = 64ul,
    }
    /// <summary>
    /// 表示 t_market 表的字段的枚举。卖场表
    /// </summary>
    [Flags()]
    public enum Emarket : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 用户表ID
        /// </summary>
        mid = 2ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 4ul,
        /// <summary>
        /// 索引
        /// </summary>
        letter = 8ul,
        /// <summary>
        /// 组ID
        /// </summary>
        groupid = 16ul,
        /// <summary>
        /// 属性
        /// </summary>
        attribute = 32ul,
        /// <summary>
        /// 行业
        /// </summary>
        industry = 64ul,
        /// <summary>
        /// 产品分类
        /// </summary>
        productcategory = 128ul,
        /// <summary>
        /// 是否vip
        /// </summary>
        vip = 256ul,
        /// <summary>
        /// 地区代码
        /// </summary>
        areacode = 512ul,
        /// <summary>
        /// 地址
        /// </summary>
        address = 1024ul,
        /// <summary>
        /// 地图API值
        /// </summary>
        mapapi = 2048ul,
        /// <summary>
        /// 外观图
        /// </summary>
        staffsize = 4096ul,
        /// <summary>
        /// 注册时间
        /// </summary>
        regyear = 8192ul,
        /// <summary>
        /// 注册城市
        /// </summary>
        regcity = 16384ul,
        /// <summary>
        /// 销售信息
        /// </summary>
        buy = 32768ul,
        /// <summary>
        /// 采购信息
        /// </summary>
        sell = 65536ul,
        /// <summary>
        /// 面积
        /// </summary>
        cbm = 131072ul,
        /// <summary>
        /// 投诉电话
        /// </summary>
        lphone = 262144ul,
        /// <summary>
        /// 招商电话
        /// </summary>
        zphone = 524288ul,
        /// <summary>
        /// 公交线路
        /// </summary>
        busroute = 1048576ul,
        /// <summary>
        /// 营业时间
        /// </summary>
        hours = 2097152ul,
        /// <summary>
        /// 联系人
        /// </summary>
        linkman = 4194304ul,
        /// <summary>
        /// 联系电话
        /// </summary>
        phone = 8388608ul,
        /// <summary>
        /// 联系手机
        /// </summary>
        mphone = 16777216ul,
        /// <summary>
        /// 传真
        /// </summary>
        fax = 33554432ul,
        /// <summary>
        /// 邮件
        /// </summary>
        email = 67108864ul,
        /// <summary>
        /// 邮编
        /// </summary>
        postcode = 134217728ul,
        /// <summary>
        /// 主页
        /// </summary>
        homepage = 268435456ul,
        /// <summary>
        /// 域名
        /// </summary>
        domain = 536870912ul,
        /// <summary>
        /// 域名IP
        /// </summary>
        domainip = 1073741824ul,
        /// <summary>
        /// 备案号
        /// </summary>
        icp = 2147483648ul,
        /// <summary>
        /// 外观图
        /// </summary>
        surface = 4294967296ul,
        /// <summary>
        /// logo
        /// </summary>
        logo = 8589934592ul,
        /// <summary>
        /// 缩略图
        /// </summary>
        thumb = 17179869184ul,
        /// <summary>
        /// 幻灯图
        /// </summary>
        bannel = 34359738368ul,
        /// <summary>
        /// 描述图
        /// </summary>
        desimage = 68719476736ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 137438953472ul,
        /// <summary>
        /// 关键字
        /// </summary>
        keywords = 274877906944ul,
        /// <summary>
        /// 模版ID
        /// </summary>
        template = 549755813888ul,
        /// <summary>
        /// 点击量
        /// </summary>
        hits = 1099511627776ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 2199023255552ul,
        /// <summary>
        /// 创建人
        /// </summary>
        createmid = 4398046511104ul,
        /// <summary>
        /// 最后修改人
        /// </summary>
        lastedid = 8796093022208ul,
        /// <summary>
        /// 最后修改时间
        /// </summary>
        lastedittime = 17592186044416ul,
        /// <summary>
        /// 审核状态
        /// </summary>
        auditstatus = 35184372088832ul,
        /// <summary>
        /// 上下线状态
        /// </summary>
        linestatus = 70368744177664ul,
    }
    /// <summary>
    /// 表示 t_marketgroup 表的字段的枚举。卖场组表
    /// </summary>
    [Flags()]
    public enum Emarketgroup : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 组名称
        /// </summary>
        title = 2ul,
        /// <summary>
        /// 组名称颜色
        /// </summary>
        color = 4ul,
        /// <summary>
        /// 组图标
        /// </summary>
        avatar = 8ul,
        /// <summary>
        /// 积分达到
        /// </summary>
        integral = 16ul,
        /// <summary>
        /// 金钱达到
        /// </summary>
        money = 32ul,
        /// <summary>
        /// 广告数量限制
        /// </summary>
        adcount = 64ul,
        /// <summary>
        /// 店铺数量限制
        /// </summary>
        shopcount = 128ul,
        /// <summary>
        /// 品牌数量限制
        /// </summary>
        brandcount = 256ul,
        /// <summary>
        /// 促销信息数量限制
        /// </summary>
        promotioncount = 512ul,
        /// <summary>
        /// 推荐数量限制
        /// </summary>
        storeycount = 1024ul,
        /// <summary>
        /// 推荐店铺数量限制
        /// </summary>
        storeyshopcount = 2048ul,
        /// <summary>
        ///  
        /// </summary>
        adrecommend = 4096ul,
        /// <summary>
        ///  
        /// </summary>
        shoprecommend = 8192ul,
        /// <summary>
        ///  
        /// </summary>
        brandrecommend = 16384ul,
        /// <summary>
        ///  
        /// </summary>
        promotionrecommend = 32768ul,
        /// <summary>
        /// 级别
        /// </summary>
        lev = 65536ul,
        /// <summary>
        ///  
        /// </summary>
        permissions = 131072ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 262144ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 524288ul,
    }
    /// <summary>
    /// 表示 t_marketstorey 表的字段的枚举。卖场楼层表
    /// </summary>
    [Flags()]
    public enum Emarketstorey : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 卖场ID
        /// </summary>
        marketid = 2ul,
        /// <summary>
        /// 卖场名称
        /// </summary>
        markettitle = 4ul,
        /// <summary>
        /// 楼层名称
        /// </summary>
        title = 8ul,
        /// <summary>
        /// 楼层序号ID
        /// </summary>
        number = 16ul,
        /// <summary>
        /// 楼层图
        /// </summary>
        surface = 32ul,
        /// <summary>
        /// LOGO
        /// </summary>
        logo = 64ul,
        /// <summary>
        /// 缩略图
        /// </summary>
        thumb = 128ul,
        /// <summary>
        /// 幻灯图
        /// </summary>
        bannel = 256ul,
        /// <summary>
        /// 描述图
        /// </summary>
        desimage = 512ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 1024ul,
        /// <summary>
        /// 关键字
        /// </summary>
        keywords = 2048ul,
        /// <summary>
        /// 模版ID
        /// </summary>
        template = 4096ul,
        /// <summary>
        /// 点击量
        /// </summary>
        hits = 8192ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 16384ul,
        /// <summary>
        /// 最后修改人
        /// </summary>
        lastedid = 32768ul,
        /// <summary>
        /// 最后修改时间
        /// </summary>
        lastedittime = 65536ul,
    }
    /// <summary>
    /// 表示 t_marketstoreyshop 表的字段的枚举。卖场楼层店铺
    /// </summary>
    [Flags()]
    public enum Emarketstoreyshop : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 卖场ID
        /// </summary>
        marketid = 2ul,
        /// <summary>
        /// 卖场名称
        /// </summary>
        markettitle = 4ul,
        /// <summary>
        /// 楼层ID
        /// </summary>
        storeyid = 8ul,
        /// <summary>
        /// 楼层名称
        /// </summary>
        storeytitle = 16ul,
        /// <summary>
        /// 店铺ID
        /// </summary>
        shopid = 32ul,
        /// <summary>
        /// 店铺名称
        /// </summary>
        shoptitle = 64ul,
        /// <summary>
        /// 店铺品牌Idlist
        /// </summary>
        brandidlist = 128ul,
        /// <summary>
        /// 店铺品牌标题list
        /// </summary>
        brandtitlelist = 256ul,
        /// <summary>
        /// 是否置顶
        /// </summary>
        istop = 512ul,
        /// <summary>
        /// 是否推荐
        /// </summary>
        isrecommend = 1024ul,
        /// <summary>
        /// 级别
        /// </summary>
        lev = 2048ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 4096ul,
        /// <summary>
        /// 最后修改人
        /// </summary>
        lastedid = 8192ul,
        /// <summary>
        /// 最后修改时间
        /// </summary>
        lastedittime = 16384ul,
    }
    /// <summary>
    /// 表示 t_member 表的字段的枚举。会员表
    /// </summary>
    [Flags()]
    public enum Emember : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 登陆账号
        /// </summary>
        username = 2ul,
        /// <summary>
        /// 密码
        /// </summary>
        password = 4ul,
        /// <summary>
        /// 支付密码
        /// </summary>
        paypassword = 8ul,
        /// <summary>
        /// 通行证
        /// </summary>
        passport = 16ul,
        /// <summary>
        /// 账号类型
        /// </summary>
        type = 32ul,
        /// <summary>
        /// 会员组ID
        /// </summary>
        groupid = 64ul,
        /// <summary>
        /// 提示音
        /// </summary>
        sound = 128ul,
        /// <summary>
        /// 真实姓名
        /// </summary>
        tname = 256ul,
        /// <summary>
        /// email
        /// </summary>
        email = 512ul,
        /// <summary>
        /// 性别
        /// </summary>
        gender = 1024ul,
        /// <summary>
        /// 手机
        /// </summary>
        mobile = 2048ul,
        /// <summary>
        /// 电话
        /// </summary>
        phone = 4096ul,
        /// <summary>
        /// Msn
        /// </summary>
        msn = 8192ul,
        /// <summary>
        /// QQ
        /// </summary>
        qq = 16384ul,
        /// <summary>
        /// Skype
        /// </summary>
        skype = 32768ul,
        /// <summary>
        /// Ali
        /// </summary>
        ali = 65536ul,
        /// <summary>
        /// 出生日期
        /// </summary>
        birthdate = 131072ul,
        /// <summary>
        /// 地区Code 
        /// </summary>
        areacode = 262144ul,
        /// <summary>
        /// 详细地址
        /// </summary>
        address = 524288ul,
        /// <summary>
        /// 部门
        /// </summary>
        department = 1048576ul,
        /// <summary>
        /// 职位
        /// </summary>
        career = 2097152ul,
        /// <summary>
        /// 短信余额
        /// </summary>
        sms = 4194304ul,
        /// <summary>
        /// 积分
        /// </summary>
        integral = 8388608ul,
        /// <summary>
        /// 资金金额
        /// </summary>
        money = 16777216ul,
        /// <summary>
        /// 收款银行
        /// </summary>
        bank = 33554432ul,
        /// <summary>
        /// 收款账号
        /// </summary>
        account = 67108864ul,
        /// <summary>
        /// 支付宝账号
        /// </summary>
        alipay = 134217728ul,
        /// <summary>
        /// 注册IP
        /// </summary>
        regip = 268435456ul,
        /// <summary>
        /// 注册时间
        /// </summary>
        regtime = 536870912ul,
        /// <summary>
        /// 最后登陆IP
        /// </summary>
        loginip = 1073741824ul,
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        logintime = 2147483648ul,
        /// <summary>
        /// 登陆次数
        /// </summary>
        logincount = 4294967296ul,
        /// <summary>
        /// 授权认证(密钥)
        /// </summary>
        auth = 8589934592ul,
        /// <summary>
        /// 授权认证内容
        /// </summary>
        authvalue = 17179869184ul,
        /// <summary>
        /// 验证时间
        /// </summary>
        authtime = 34359738368ul,
        /// <summary>
        /// 邮箱认证
        /// </summary>
        vemail = 68719476736ul,
        /// <summary>
        /// 手机认证
        /// </summary>
        vmobile = 137438953472ul,
        /// <summary>
        /// 实名认证
        /// </summary>
        vname = 274877906944ul,
        /// <summary>
        /// 验证银行
        /// </summary>
        vbank = 549755813888ul,
        /// <summary>
        /// 验证公司
        /// </summary>
        vcompany = 1099511627776ul,
        /// <summary>
        /// 验证支付宝
        /// </summary>
        valipay = 2199023255552ul,
        /// <summary>
        /// 客服专员
        /// </summary>
        support = 4398046511104ul,
        /// <summary>
        /// 推荐人(限定为用户名)
        /// </summary>
        inviter = 8796093022208ul,
        /// <summary>
        /// 最后修改时间
        /// </summary>
        lastedittime = 17592186044416ul,
        /// <summary>
        /// 在线聊天
        /// </summary>
        chat = 35184372088832ul,
        /// <summary>
        /// 站内消息
        /// </summary>
        message = 70368744177664ul,
        /// <summary>
        /// 提问
        /// </summary>
        question = 140737488355328ul,
        /// <summary>
        /// 回答
        /// </summary>
        answer = 281474976710656ul,
        /// <summary>
        /// 比价格
        /// </summary>
        overprice = 562949953421312ul,
        /// <summary>
        /// 使用价格
        /// </summary>
        useprice = 1125899906842624ul,
        /// <summary>
        /// 是否补给
        /// </summary>
        Isrecharge = 2251799813685248ul,
        /// <summary>
        /// 开始时间
        /// </summary>
        RegStatcTime = 4503599627370496ul,
        /// <summary>
        /// 结束时间
        /// </summary>
        RegEndTime = 9007199254740992ul,
    }
    /// <summary>
    /// 表示 t_membergroup 表的字段的枚举。会员组表
    /// </summary>
    [Flags()]
    public enum Emembergroup : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 2ul,
        /// <summary>
        /// 颜色
        /// </summary>
        color = 4ul,
        /// <summary>
        /// 标志图片
        /// </summary>
        avatar = 8ul,
        /// <summary>
        /// 积分达至
        /// </summary>
        integral = 16ul,
        /// <summary>
        /// 金额达到
        /// </summary>
        money = 32ul,
        /// <summary>
        /// 权限
        /// </summary>
        permissions = 64ul,
        /// <summary>
        /// 级别
        /// </summary>
        lev = 128ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 256ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 512ul,
    }
    /// <summary>
    /// 表示 t_menu 表的字段的枚举。菜单表
    /// </summary>
    [Flags()]
    public enum Emenu : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 2ul,
        /// <summary>
        /// 类型
        /// </summary>
        type = 4ul,
        /// <summary>
        /// 标识
        /// </summary>
        mark = 8ul,
        /// <summary>
        /// 上级
        /// </summary>
        parent = 16ul,
        /// <summary>
        /// 级别
        /// </summary>
        lev = 32ul,
        /// <summary>
        /// 路径
        /// </summary>
        path = 64ul,
        /// <summary>
        /// 连接
        /// </summary>
        url = 128ul,
        /// <summary>
        /// 模块
        /// </summary>
        module = 256ul,
        /// <summary>
        /// 权限
        /// </summary>
        action = 512ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 1024ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 2048ul,
    }
    /// <summary>
    /// 表示 t_news 表的字段的枚举。新闻信息表
    /// </summary>
    [Flags()]
    public enum Enews : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 是否会员添加
        /// </summary>
        ismember = 2ul,
        /// <summary>
        /// 会员ID
        /// </summary>
        mid = 4ul,
        /// <summary>
        /// 会员类型（冗余）
        /// </summary>
        membertype = 8ul,
        /// <summary>
        /// 管理员ID
        /// </summary>
        adminid = 16ul,
        /// <summary>
        /// 新闻标题
        /// </summary>
        title = 32ul,
        /// <summary>
        /// 索引
        /// </summary>
        letter = 64ul,
        /// <summary>
        /// 新闻导读
        /// </summary>
        intro = 128ul,
        /// <summary>
        /// 新闻内容
        /// </summary>
        descript = 256ul,
        /// <summary>
        /// 审核状态
        /// </summary>
        auditstatus = 512ul,
        /// <summary>
        /// 在线状态
        /// </summary>
        linestatus = 1024ul,
        /// <summary>
        /// 创建时间
        /// </summary>
        createtime = 2048ul,
        /// <summary>
        /// 最后更新时间
        /// </summary>
        lastedtime = 4096ul,
    }
    /// <summary>
    /// 表示 t_PayMent 表的字段的枚举。支付表
    /// </summary>
    [Flags()]
    public enum EPayMent : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        ID = 1ul,
        /// <summary>
        /// 订单号
        /// </summary>
        OrderCode = 2ul,
        /// <summary>
        /// 支付金额
        /// </summary>
        Price = 4ul,
        /// <summary>
        /// 会员ID
        /// </summary>
        Mid = 8ul,
        /// <summary>
        /// 支付类型
        /// </summary>
        Types = 16ul,
        /// <summary>
        /// 银行
        /// </summary>
        Bank = 32ul,
        /// <summary>
        /// 创建时间
        /// </summary>
        CreateTime = 64ul,
    }
    /// <summary>
    /// 表示 t_PayMentLog 表的字段的枚举。支付日志表
    /// </summary>
    [Flags()]
    public enum EPayMentLog : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        ID = 1ul,
        /// <summary>
        /// 订单号
        /// </summary>
        OrderCode = 2ul,
        /// <summary>
        /// 支付金额
        /// </summary>
        Price = 4ul,
        /// <summary>
        /// 会员ID
        /// </summary>
        Mid = 8ul,
        /// <summary>
        /// 支付类型
        /// </summary>
        Types = 16ul,
        /// <summary>
        /// 银行
        /// </summary>
        Bank = 32ul,
        /// <summary>
        /// 创建时间
        /// </summary>
        CreateTime = 64ul,
    }
    /// <summary>
    /// 表示 t_pcategoryptypedef 表的字段的枚举。产品分类与产品类型关联表
    /// </summary>
    [Flags()]
    public enum Epcategoryptypedef : ulong {
        /// <summary>
        /// 分类ID
        /// </summary>
        productcategoryid = 1ul,
        /// <summary>
        /// 类型ID
        /// </summary>
        producttypeid = 2ul,
    }
    /// <summary>
    /// 表示 t_product 表的字段的枚举。产品表
    /// </summary>
    [Flags()]
    public enum Eproduct : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 属性（推荐……）
        /// </summary>
        attribute = 2ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 4ul,
        /// <summary>
        /// 副 名称
        /// </summary>
        shottitle = 8ul,
        /// <summary>
        /// 颜色
        /// </summary>
        tcolor = 16ul,
        /// <summary>
        /// 编号（厂家）
        /// </summary>
        sku = 32ul,
        /// <summary>
        /// 编号(系统)
        /// </summary>
        no = 64ul,
        /// <summary>
        /// 索引
        /// </summary>
        letter = 128ul,
        /// <summary>
        /// 分类ID
        /// </summary>
        categoryid = 256ul,
        /// <summary>
        /// 分类名称
        /// </summary>
        categorytitle = 512ul,
        /// <summary>
        /// 多分类ID列表
        /// </summary>
        subcategoryidlist = 1024ul,
        /// <summary>
        ///  
        /// </summary>
        subcategorytitlelist = 2048ul,
        /// <summary>
        /// 品牌ID
        /// </summary>
        brandid = 4096ul,
        /// <summary>
        /// 品牌名称
        /// </summary>
        brandtitle = 8192ul,
        /// <summary>
        /// 系列ID
        /// </summary>
        brandsid = 16384ul,
        /// <summary>
        /// 系列名称
        /// </summary>
        brandstitle = 32768ul,
        /// <summary>
        /// 风格值
        /// </summary>
        stylevalue = 65536ul,
        /// <summary>
        /// 风格名称
        /// </summary>
        stylename = 131072ul,
        /// <summary>
        /// 颜色名称
        /// </summary>
        colorname = 262144ul,
        /// <summary>
        /// 颜色值
        /// </summary>
        colorvalue = 524288ul,
        /// <summary>
        /// 材质名称
        /// </summary>
        materialvalue = 1048576ul,
        /// <summary>
        /// 材质值
        /// </summary>
        materialname = 2097152ul,
        /// <summary>
        /// 单位
        /// </summary>
        unit = 4194304ul,
        /// <summary>
        /// 产地
        /// </summary>
        localitycode = 8388608ul,
        /// <summary>
        /// 发货地
        /// </summary>
        shipcode = 16777216ul,
        /// <summary>
        ///  
        /// </summary>
        customize = 33554432ul,
        /// <summary>
        /// 外观图
        /// </summary>
        surface = 67108864ul,
        /// <summary>
        /// logo
        /// </summary>
        logo = 134217728ul,
        /// <summary>
        /// 缩略图
        /// </summary>
        thumb = 268435456ul,
        /// <summary>
        /// 幻灯图
        /// </summary>
        bannel = 536870912ul,
        /// <summary>
        /// 描述图
        /// </summary>
        desimage = 1073741824ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 2147483648ul,
        /// <summary>
        /// 福家网ID
        /// </summary>
        tob2c = 4294967296ul,
        /// <summary>
        /// 所属企业ID
        /// </summary>
        companyid = 8589934592ul,
        /// <summary>
        /// 所属企业名称
        /// </summary>
        companyname = 17179869184ul,
        /// <summary>
        /// 创建者ID
        /// </summary>
        createmid = 34359738368ul,
        /// <summary>
        /// 点击量
        /// </summary>
        hits = 68719476736ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 137438953472ul,
        /// <summary>
        /// 修改人ID
        /// </summary>
        lastedid = 274877906944ul,
        /// <summary>
        /// 修改时间
        /// </summary>
        lastedittime = 549755813888ul,
        /// <summary>
        /// 审核状态，-1正在审核，0待审核，1审核通过，-99未通过
        /// </summary>
        auditstatus = 1099511627776ul,
        /// <summary>
        /// 上下线状态,0下线，1上线
        /// </summary>
        linestatus = 2199023255552ul,
        /// <summary>
        ///  
        /// </summary>
        assemble = 4398046511104ul,
        /// <summary>
        /// 创建时间
        /// </summary>
        Createtime = 8796093022208ul,
    }
    /// <summary>
    /// 表示 t_productattribute 表的字段的枚举。产品属性表
    /// </summary>
    [Flags()]
    public enum Eproductattribute : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 产品ID
        /// </summary>
        productid = 2ul,
        /// <summary>
        /// 产品编号(系统编号)
        /// </summary>
        productno = 4ul,
        /// <summary>
        /// 产品SKU（厂家编号）
        /// </summary>
        productsku = 8ul,
        /// <summary>
        /// 产品类型（ ）config表值(其它类型=0)
        /// </summary>
        typevalue = 16ul,
        /// <summary>
        /// 产吕类型名称()
        /// </summary>
        typename = 32ul,
        /// <summary>
        /// 产品风格
        /// </summary>
        productstyle = 64ul,
        /// <summary>
        /// 材质
        /// </summary>
        productmaterial = 128ul,
        /// <summary>
        /// 颜色图片
        /// </summary>
        productcolorimg = 256ul,
        /// <summary>
        /// 颜色名称
        /// </summary>
        productcolortitle = 512ul,
        /// <summary>
        /// 颜色色值
        /// </summary>
        productcolorvalue = 1024ul,
        /// <summary>
        /// 宽
        /// </summary>
        productwidth = 2048ul,
        /// <summary>
        /// 高
        /// </summary>
        productheight = 4096ul,
        /// <summary>
        /// 长
        /// </summary>
        productlength = 8192ul,
        /// <summary>
        /// 体积
        /// </summary>
        productcbm = 16384ul,
        /// <summary>
        /// 采购价
        /// </summary>
        buyprice = 32768ul,
        /// <summary>
        /// 市场价
        /// </summary>
        markprice = 65536ul,
        /// <summary>
        /// 销售价
        /// </summary>
        saleprice = 131072ul,
        /// <summary>
        /// 其它信息
        /// </summary>
        otherinfo = 262144ul,
        /// <summary>
        /// 库存
        /// </summary>
        storage = 524288ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 1048576ul,
        /// <summary>
        /// 是否默认
        /// </summary>
        isdefault = 2097152ul,
    }
    /// <summary>
    /// 表示 t_productcategory 表的字段的枚举。产品分类表
    /// </summary>
    [Flags()]
    public enum Eproductcategory : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 2ul,
        /// <summary>
        /// 索引
        /// </summary>
        letter = 4ul,
        /// <summary>
        /// 路径名称/chuang/
        /// </summary>
        rewritetitle = 8ul,
        /// <summary>
        /// 上级ID
        /// </summary>
        parentid = 16ul,
        /// <summary>
        /// 左值
        /// </summary>
        lft = 32ul,
        /// <summary>
        /// 右值
        /// </summary>
        rgt = 64ul,
        /// <summary>
        /// 层级
        /// </summary>
        lev = 128ul,
        /// <summary>
        /// 深度
        /// </summary>
        depth = 256ul,
        /// <summary>
        /// 外观图
        /// </summary>
        surface = 512ul,
        /// <summary>
        /// 缩略图
        /// </summary>
        thumb = 1024ul,
        /// <summary>
        /// 幻灯图
        /// </summary>
        bannel = 2048ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 4096ul,
        /// <summary>
        /// 关键字
        /// </summary>
        keywords = 8192ul,
        /// <summary>
        /// 模版
        /// </summary>
        template = 16384ul,
        /// <summary>
        /// 点击量
        /// </summary>
        hits = 32768ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 65536ul,
        /// <summary>
        /// 上下级状态
        /// </summary>
        linestatus = 131072ul,
        /// <summary>
        /// 创建人ID
        /// </summary>
        createmid = 262144ul,
        /// <summary>
        /// 修改人ID
        /// </summary>
        lastedid = 524288ul,
        /// <summary>
        /// 修改时间
        /// </summary>
        lastedittime = 1048576ul,
        /// <summary>
        /// 页标题
        /// </summary>
        pagetitle = 2097152ul,
        /// <summary>
        /// 描述
        /// </summary>
        description = 4194304ul,
    }
    /// <summary>
    /// 表示 t_productcon 表的字段的枚举。产品内容表
    /// </summary>
    [Flags()]
    public enum Eproductcon : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 产品ID
        /// </summary>
        productid = 2ul,
        /// <summary>
        ///  
        /// </summary>
        contype = 4ul,
        /// <summary>
        ///  
        /// </summary>
        con = 8ul,
    }
    /// <summary>
    /// 表示 t_promotion 表的字段的枚举。 
    /// </summary>
    [Flags()]
    public enum Epromotion : ulong {
        /// <summary>
        ///  
        /// </summary>
        id = 1ul,
        /// <summary>
        ///  
        /// </summary>
        title = 2ul,
        /// <summary>
        ///  
        /// </summary>
        htmltitle = 4ul,
        /// <summary>
        ///  
        /// </summary>
        letter = 8ul,
        /// <summary>
        ///  
        /// </summary>
        attribute = 16ul,
        /// <summary>
        ///  
        /// </summary>
        ptype = 32ul,
        /// <summary>
        ///  
        /// </summary>
        startdatetime = 64ul,
        /// <summary>
        ///  
        /// </summary>
        enddatetime = 128ul,
        /// <summary>
        ///  
        /// </summary>
        areacode = 256ul,
        /// <summary>
        ///  
        /// </summary>
        address = 512ul,
        /// <summary>
        ///  
        /// </summary>
        surface = 1024ul,
        /// <summary>
        ///  
        /// </summary>
        logo = 2048ul,
        /// <summary>
        ///  
        /// </summary>
        thumb = 4096ul,
        /// <summary>
        ///  
        /// </summary>
        bannel = 8192ul,
        /// <summary>
        ///  
        /// </summary>
        desimage = 16384ul,
        /// <summary>
        ///  
        /// </summary>
        descript = 32768ul,
        /// <summary>
        ///  
        /// </summary>
        keywords = 65536ul,
        /// <summary>
        ///  
        /// </summary>
        template = 131072ul,
        /// <summary>
        ///  
        /// </summary>
        hits = 262144ul,
        /// <summary>
        ///  
        /// </summary>
        sort = 524288ul,
        /// <summary>
        ///  
        /// </summary>
        createmid = 1048576ul,
        /// <summary>
        ///  
        /// </summary>
        lastedid = 2097152ul,
        /// <summary>
        ///  
        /// </summary>
        lastedittime = 4194304ul,
        /// <summary>
        ///  
        /// </summary>
        auditstatus = 8388608ul,
        /// <summary>
        ///  
        /// </summary>
        linestatus = 16777216ul,
    }
    /// <summary>
    /// 表示 t_promotionappbrand 表的字段的枚举。促销信息品牌关联表
    /// </summary>
    [Flags()]
    public enum Epromotionappbrand : ulong {
        /// <summary>
        ///  
        /// </summary>
        id = 1ul,
        /// <summary>
        ///  
        /// </summary>
        title = 2ul,
        /// <summary>
        ///  
        /// </summary>
        letter = 4ul,
        /// <summary>
        ///  
        /// </summary>
        bid = 8ul,
        /// <summary>
        ///  
        /// </summary>
        blogo = 16ul,
        /// <summary>
        ///  
        /// </summary>
        fordio = 32ul,
        /// <summary>
        ///  
        /// </summary>
        appcount = 64ul,
        /// <summary>
        ///  
        /// </summary>
        sort = 128ul,
        /// <summary>
        ///  
        /// </summary>
        thumb = 256ul,
        /// <summary>
        ///  
        /// </summary>
        banner = 512ul,
        /// <summary>
        ///  
        /// </summary>
        htmltitle = 1024ul,
        /// <summary>
        ///  
        /// </summary>
        descript = 2048ul,
    }
    /// <summary>
    /// 表示 t_promotionappproduct 表的字段的枚举。促销信息产品关联表
    /// </summary>
    [Flags()]
    public enum Epromotionappproduct : ulong {
        /// <summary>
        ///  
        /// </summary>
        id = 1ul,
        /// <summary>
        ///  
        /// </summary>
        mid = 2ul,
        /// <summary>
        ///  
        /// </summary>
        name = 4ul,
        /// <summary>
        ///  
        /// </summary>
        memail = 8ul,
        /// <summary>
        ///  
        /// </summary>
        mphone = 16ul,
        /// <summary>
        ///  
        /// </summary>
        productid = 32ul,
        /// <summary>
        ///  
        /// </summary>
        productname = 64ul,
        /// <summary>
        ///  
        /// </summary>
        materialid = 128ul,
        /// <summary>
        ///  
        /// </summary>
        materialname = 256ul,
        /// <summary>
        ///  
        /// </summary>
        sizevalue = 512ul,
        /// <summary>
        ///  
        /// </summary>
        brandid = 1024ul,
        /// <summary>
        ///  
        /// </summary>
        brandname = 2048ul,
        /// <summary>
        ///  
        /// </summary>
        addtime = 4096ul,
    }
    /// <summary>
    /// 表示 t_promotiondef 表的字段的枚举。 
    /// </summary>
    [Flags()]
    public enum Epromotiondef : ulong {
        /// <summary>
        ///  
        /// </summary>
        id = 1ul,
        /// <summary>
        ///  
        /// </summary>
        title = 2ul,
        /// <summary>
        ///  
        /// </summary>
        pid = 4ul,
        /// <summary>
        ///  
        /// </summary>
        attribute = 8ul,
        /// <summary>
        ///  
        /// </summary>
        type = 16ul,
        /// <summary>
        ///  
        /// </summary>
        value = 32ul,
        /// <summary>
        ///  
        /// </summary>
        valueletter = 64ul,
        /// <summary>
        ///  
        /// </summary>
        valuetitle = 128ul,
        /// <summary>
        ///  
        /// </summary>
        thumb = 256ul,
        /// <summary>
        ///  
        /// </summary>
        banner = 512ul,
        /// <summary>
        ///  
        /// </summary>
        descript = 1024ul,
        /// <summary>
        ///  
        /// </summary>
        curcountmoney = 2048ul,
        /// <summary>
        ///  
        /// </summary>
        curcountpeople = 4096ul,
        /// <summary>
        ///  
        /// </summary>
        curstage = 8192ul,
        /// <summary>
        ///  
        /// </summary>
        fordio = 16384ul,
        /// <summary>
        ///  
        /// </summary>
        sort = 32768ul,
    }
    /// <summary>
    /// 表示 t_promotions 表的字段的枚举。促销信息表
    /// </summary>
    [Flags()]
    public enum Epromotions : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 会员ID
        /// </summary>
        mid = 2ul,
        /// <summary>
        /// 会员类型（与t_member.type对应）
        /// </summary>
        membertype = 4ul,
        /// <summary>
        /// 标题
        /// </summary>
        title = 8ul,
        /// <summary>
        /// html标题
        /// </summary>
        htmltitle = 16ul,
        /// <summary>
        /// 索引
        /// </summary>
        letter = 32ul,
        /// <summary>
        /// 属性
        /// </summary>
        attribute = 64ul,
        /// <summary>
        /// 开始时间
        /// </summary>
        startdatetime = 128ul,
        /// <summary>
        /// 结束时间
        /// </summary>
        enddatetime = 256ul,
        /// <summary>
        /// 外观图
        /// </summary>
        surface = 512ul,
        /// <summary>
        /// 商标
        /// </summary>
        logo = 1024ul,
        /// <summary>
        /// 缩略图
        /// </summary>
        thumb = 2048ul,
        /// <summary>
        /// 幻灯片
        /// </summary>
        bannel = 4096ul,
        /// <summary>
        /// 描述图
        /// </summary>
        desimage = 8192ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 16384ul,
        /// <summary>
        /// 关键词
        /// </summary>
        keywords = 32768ul,
        /// <summary>
        /// 模板
        /// </summary>
        template = 65536ul,
        /// <summary>
        /// 点击量
        /// </summary>
        hits = 131072ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 262144ul,
        /// <summary>
        /// 创建人(后台管理员，0则为会员)
        /// </summary>
        adminid = 524288ul,
        /// <summary>
        /// 最后修改人(后台管理员，0则为会员)
        /// </summary>
        lastedadminid = 1048576ul,
        /// <summary>
        /// 最后修改时间（后台管理员，0则为会员）
        /// </summary>
        lastedadmintime = 2097152ul,
        /// <summary>
        /// 最后修改人(会员)
        /// </summary>
        lastedmid = 4194304ul,
        /// <summary>
        /// 最后修改时间（会员）
        /// </summary>
        lastedmtime = 8388608ul,
        /// <summary>
        /// 审核状态
        /// </summary>
        auditstatus = 16777216ul,
        /// <summary>
        /// 在线状态
        /// </summary>
        linestatus = 33554432ul,
        /// <summary>
        /// 是否置顶
        /// </summary>
        IsTop = 67108864ul,
        /// <summary>
        /// 是否推荐
        /// </summary>
        IsRecommend = 134217728ul,
        /// <summary>
        /// 是否热门
        /// </summary>
        IsHot = 268435456ul,
        /// <summary>
        /// 是否精华
        /// </summary>
        IsEssence = 536870912ul,
        /// <summary>
        /// 是否幻灯
        /// </summary>
        IsSlide = 1073741824ul,
        /// <summary>
        /// 是否高亮
        /// </summary>
        IsHighlight = 2147483648ul,
        /// <summary>
        /// 发布日期
        /// </summary>
        createtime = 4294967296ul,
    }
    /// <summary>
    /// 表示 t_promotionsrelated 表的字段的枚举。促销信息关系表（店铺，卖场根据会员与会员类型决定）
    /// </summary>
    [Flags()]
    public enum Epromotionsrelated : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 会员ID
        /// </summary>
        mid = 2ul,
        /// <summary>
        /// 会员类型（冗余字段）
        /// </summary>
        membertype = 4ul,
        /// <summary>
        /// 促销ID
        /// </summary>
        promotionsid = 8ul,
        /// <summary>
        /// 促销标题（冗余字段）
        /// </summary>
        promotionstitle = 16ul,
        /// <summary>
        /// 店铺ID（与卖场ID是不同时存在）
        /// </summary>
        shopid = 32ul,
        /// <summary>
        /// 店铺名称（冗余字段）
        /// </summary>
        shoptitle = 64ul,
        /// <summary>
        /// 店铺地区（冗余字段）
        /// </summary>
        shopareacode = 128ul,
        /// <summary>
        /// 店铺地址（冗余字段）
        /// </summary>
        shopaddress = 256ul,
        /// <summary>
        /// 卖场ID（与店铺ID是不同时存在）
        /// </summary>
        marketid = 512ul,
        /// <summary>
        /// 卖场名称（冗余字段）
        /// </summary>
        markettitle = 1024ul,
        /// <summary>
        /// 卖场地区（冗余字段）
        /// </summary>
        marketareacode = 2048ul,
        /// <summary>
        /// 卖场地址（冗余字段）
        /// </summary>
        marketaddress = 4096ul,
        /// <summary>
        /// 卖场楼层（当为0时表示全部楼层）
        /// </summary>
        marketstoreyid = 8192ul,
        /// <summary>
        /// 创建时间
        /// </summary>
        createtime = 16384ul,
    }
    /// <summary>
    /// 表示 t_promotionstage 表的字段的枚举。 
    /// </summary>
    [Flags()]
    public enum Epromotionstage : ulong {
        /// <summary>
        ///  
        /// </summary>
        id = 1ul,
        /// <summary>
        ///  
        /// </summary>
        title = 2ul,
        /// <summary>
        ///  
        /// </summary>
        pid = 4ul,
        /// <summary>
        ///  
        /// </summary>
        did = 8ul,
        /// <summary>
        ///  
        /// </summary>
        stype = 16ul,
        /// <summary>
        ///  
        /// </summary>
        smodle = 32ul,
        /// <summary>
        ///  
        /// </summary>
        svaluemin = 64ul,
        /// <summary>
        ///  
        /// </summary>
        svaluemax = 128ul,
        /// <summary>
        ///  
        /// </summary>
        pmodule = 256ul,
        /// <summary>
        ///  
        /// </summary>
        prolue = 512ul,
        /// <summary>
        ///  
        /// </summary>
        pvalue = 1024ul,
        /// <summary>
        ///  
        /// </summary>
        sort = 2048ul,
    }
    /// <summary>
    /// 表示 t_shop 表的字段的枚举。店铺表
    /// </summary>
    [Flags()]
    public enum Eshop : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 用户表ID
        /// </summary>
        mid = 2ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 4ul,
        /// <summary>
        /// 索引
        /// </summary>
        letter = 8ul,
        /// <summary>
        /// 组ID
        /// </summary>
        groupid = 16ul,
        /// <summary>
        /// 属性
        /// </summary>
        attribute = 32ul,
        /// <summary>
        /// 行业
        /// </summary>
        industry = 64ul,
        /// <summary>
        /// 产品分类
        /// </summary>
        productcategory = 128ul,
        /// <summary>
        /// 是否vip
        /// </summary>
        vip = 256ul,
        /// <summary>
        /// 地区代码
        /// </summary>
        areacode = 512ul,
        /// <summary>
        /// 地址
        /// </summary>
        address = 1024ul,
        /// <summary>
        /// 地图API值
        /// </summary>
        mapapi = 2048ul,
        /// <summary>
        /// 外观图
        /// </summary>
        staffsize = 4096ul,
        /// <summary>
        /// 注册时间
        /// </summary>
        regyear = 8192ul,
        /// <summary>
        /// 注册城市
        /// </summary>
        regcity = 16384ul,
        /// <summary>
        /// 销售信息
        /// </summary>
        buy = 32768ul,
        /// <summary>
        /// 采购信息
        /// </summary>
        sell = 65536ul,
        /// <summary>
        /// 连系人
        /// </summary>
        linkman = 131072ul,
        /// <summary>
        /// 联系电话
        /// </summary>
        phone = 262144ul,
        /// <summary>
        /// 联系手机
        /// </summary>
        mphone = 524288ul,
        /// <summary>
        /// 传真
        /// </summary>
        fax = 1048576ul,
        /// <summary>
        /// 邮件
        /// </summary>
        email = 2097152ul,
        /// <summary>
        /// 邮编
        /// </summary>
        postcode = 4194304ul,
        /// <summary>
        /// 主页
        /// </summary>
        homepage = 8388608ul,
        /// <summary>
        /// 域名
        /// </summary>
        domain = 16777216ul,
        /// <summary>
        /// 域名IP
        /// </summary>
        domainip = 33554432ul,
        /// <summary>
        /// 备案号
        /// </summary>
        icp = 67108864ul,
        /// <summary>
        /// 外观图
        /// </summary>
        surface = 134217728ul,
        /// <summary>
        /// logo
        /// </summary>
        logo = 268435456ul,
        /// <summary>
        /// 缩略图
        /// </summary>
        thumb = 536870912ul,
        /// <summary>
        /// 幻灯图
        /// </summary>
        bannel = 1073741824ul,
        /// <summary>
        /// 描述图
        /// </summary>
        desimage = 2147483648ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 4294967296ul,
        /// <summary>
        /// 关键字
        /// </summary>
        keywords = 8589934592ul,
        /// <summary>
        /// 模版ID
        /// </summary>
        template = 17179869184ul,
        /// <summary>
        /// 点击量
        /// </summary>
        hits = 34359738368ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 68719476736ul,
        /// <summary>
        /// 卖场ID
        /// </summary>
        marketid = 137438953472ul,
        /// <summary>
        /// 所属企业或经销商ID
        /// </summary>
        cid = 274877906944ul,
        /// <summary>
        /// 所属类型(企业/经销商)
        /// </summary>
        ctype = 549755813888ul,
        /// <summary>
        /// 创建人
        /// </summary>
        createmid = 1099511627776ul,
        /// <summary>
        /// 最后修改人
        /// </summary>
        lastedid = 2199023255552ul,
        /// <summary>
        /// 最后修改时间
        /// </summary>
        lastedittime = 4398046511104ul,
        /// <summary>
        /// 审核状态
        /// </summary>
        auditstatus = 8796093022208ul,
        /// <summary>
        /// 上下线状态
        /// </summary>
        linestatus = 17592186044416ul,
        /// <summary>
        /// QQ
        /// </summary>
        qq = 35184372088832ul,
    }
    /// <summary>
    /// 表示 t_shopbrand 表的字段的枚举。店铺品牌关联表
    /// </summary>
    [Flags()]
    public enum Eshopbrand : ulong {
        /// <summary>
        /// 店铺ID
        /// </summary>
        shopid = 1ul,
        /// <summary>
        /// 品牌ID
        /// </summary>
        brandid = 2ul,
    }
    /// <summary>
    /// 表示 t_shopgroup 表的字段的枚举。店铺组表
    /// </summary>
    [Flags()]
    public enum Eshopgroup : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 2ul,
        /// <summary>
        /// 名称颜色
        /// </summary>
        color = 4ul,
        /// <summary>
        /// 标志图片
        /// </summary>
        avatar = 8ul,
        /// <summary>
        /// 积分达到
        /// </summary>
        integral = 16ul,
        /// <summary>
        /// 金额达至
        /// </summary>
        money = 32ul,
        /// <summary>
        /// 广告数量
        /// </summary>
        adcount = 64ul,
        /// <summary>
        /// 可加入卖场数量
        /// </summary>
        marketpcount = 128ul,
        /// <summary>
        /// 品牌数量
        /// </summary>
        brandcount = 256ul,
        /// <summary>
        /// 促销信息数量
        /// </summary>
        promotioncount = 512ul,
        /// <summary>
        /// 产品数量
        /// </summary>
        productcount = 1024ul,
        /// <summary>
        /// 广告推荐数量
        /// </summary>
        adrecommend = 2048ul,
        /// <summary>
        /// 卖场推荐数量
        /// </summary>
        marketrecommend = 4096ul,
        /// <summary>
        /// 品牌推数量
        /// </summary>
        brandrecommend = 8192ul,
        /// <summary>
        ///  
        /// </summary>
        promotionrecommend = 16384ul,
        /// <summary>
        /// 产品推荐数量
        /// </summary>
        productrecommend = 32768ul,
        /// <summary>
        ///  
        /// </summary>
        permissions = 65536ul,
        /// <summary>
        /// 层级
        /// </summary>
        lev = 131072ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 262144ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 524288ul,
    }
    /// <summary>
    /// 表示 t_shopproductprice 表的字段的枚举。产品产品价格表
    /// </summary>
    [Flags()]
    public enum Eshopproductprice : ulong {
        /// <summary>
        /// 店铺ID
        /// </summary>
        shopid = 1ul,
        /// <summary>
        /// 产品ID
        /// </summary>
        productid = 2ul,
        /// <summary>
        /// 产品属性ID
        /// </summary>
        attributeid = 4ul,
        /// <summary>
        /// 销售价格
        /// </summary>
        saleprice = 8ul,
        /// <summary>
        /// 采购价格
        /// </summary>
        buyprice = 16ul,
        /// <summary>
        /// 市场价格
        /// </summary>
        markprice = 32ul,
    }
    /// <summary>
    /// 表示 t_sys_action 表的字段的枚举。动作(权限)表
    /// </summary>
    [Flags()]
    public enum Esys_action : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 2ul,
        /// <summary>
        /// 标识
        /// </summary>
        mark = 4ul,
        /// <summary>
        /// 模块ID
        /// </summary>
        mid = 8ul,
        /// <summary>
        /// 权限类型
        /// </summary>
        actype = 16ul,
        /// <summary>
        /// 描太空
        /// </summary>
        descript = 32ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 64ul,
    }
    /// <summary>
    /// 表示 t_sys_module 表的字段的枚举。所块表
    /// </summary>
    [Flags()]
    public enum Esys_module : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 2ul,
        /// <summary>
        /// 标识
        /// </summary>
        mark = 4ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 8ul,
        /// <summary>
        /// 类型
        /// </summary>
        type = 16ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 32ul,
    }
    /// <summary>
    /// 表示 t_sys_module_link 表的字段的枚举。所块链接表
    /// </summary>
    [Flags()]
    public enum Esys_module_link : ulong {
        /// <summary>
        ///  
        /// </summary>
        mid = 1ul,
        /// <summary>
        ///  
        /// </summary>
        title = 2ul,
        /// <summary>
        ///  
        /// </summary>
        icourl = 4ul,
        /// <summary>
        ///  
        /// </summary>
        linkurl = 8ul,
    }
    /// <summary>
    /// 表示 t_sys_role 表的字段的枚举。角色表
    /// </summary>
    [Flags()]
    public enum Esys_role : ulong {
        /// <summary>
        /// 序号
        /// </summary>
        id = 1ul,
        /// <summary>
        /// 上级ID
        /// </summary>
        parentid = 2ul,
        /// <summary>
        /// 名称
        /// </summary>
        title = 4ul,
        /// <summary>
        /// 标识
        /// </summary>
        mark = 8ul,
        /// <summary>
        /// 描述
        /// </summary>
        descript = 16ul,
        /// <summary>
        /// 排序
        /// </summary>
        sort = 32ul,
    }
    /// <summary>
    /// 表示 t_sys_roleactiondef 表的字段的枚举。角色权限关联表
    /// </summary>
    [Flags()]
    public enum Esys_roleactiondef : ulong {
        /// <summary>
        /// 权限ID
        /// </summary>
        actionid = 1ul,
        /// <summary>
        /// 模块ID
        /// </summary>
        moduleid = 2ul,
        /// <summary>
        /// 角色ID
        /// </summary>
        roleid = 4ul,
    }
}
