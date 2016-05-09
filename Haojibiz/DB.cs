using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using Haojibiz.Data;
using Haojibiz.Model;
namespace Haojibiz.DAL
{
    #region 操作数据表中的类。此代码由机器程序生成的。
    /// <summary>
    /// 操作 t_admin 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。管理员
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dadmin : DALHandlerBase8<Madmin, MadminCollection, Eadmin>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dadmin 类的新实例。
        /// </summary>
        public Dadmin() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDadmin 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dadmin(IDALHandler dbHandler) : base("t_admin", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MadminCollection Reader(IDataReader dr)
        {
            MadminCollection rows = new MadminCollection();
            while (dr.Read())
            {
                Madmin m = new Madmin();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.name = Utility.GetDefault<String>(dr[1]);
                m.password = Utility.GetDefault<String>(dr[2]);
                m.displayname = Utility.GetDefault<String>(dr[3]);
                m.question = Utility.GetDefault<String>(dr[4]);
                m.answer = Utility.GetDefault<String>(dr[5]);
                m.email = Utility.GetDefault<String>(dr[6]);
                m.phone = Utility.GetDefault<String>(dr[7]);
                m.areacode = Utility.GetDefault<String>(dr[8]);
                m.address = Utility.GetDefault<String>(dr[9]);
                m.logincount = Utility.GetDefault<Int32?>(dr[10]);
                m.islock = Utility.GetDefault<Int32>(dr[11]);
                m.lastmodule = Utility.GetDefault<String>(dr[12]);
                m.createdate = Utility.GetDefault<DateTime>(dr[13]);
                m.lastactivitydate = Utility.GetDefault<DateTime>(dr[14]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_advertising 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。广告表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dadvertising : DALHandlerBase8<Madvertising, MadvertisingCollection, Eadvertising>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dadvertising 类的新实例。
        /// </summary>
        public Dadvertising() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDadvertising 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dadvertising(IDALHandler dbHandler) : base("t_advertising", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MadvertisingCollection Reader(IDataReader dr)
        {
            MadvertisingCollection rows = new MadvertisingCollection();
            while (dr.Read())
            {
                Madvertising m = new Madvertising();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.categoryid = Utility.GetDefault<Int32>(dr[1]);
                m.title = Utility.GetDefault<String>(dr[2]);
                m.linkurl = Utility.GetDefault<String>(dr[3]);
                m.flashurl = Utility.GetDefault<String>(dr[4]);
                m.imgurl = Utility.GetDefault<String>(dr[5]);
                m.videourl = Utility.GetDefault<String>(dr[6]);
                m.adtext = Utility.GetDefault<String>(dr[7]);
                m.adcode = Utility.GetDefault<String>(dr[8]);
                m.isopen = Utility.GetDefault<Int32?>(dr[9]);
                m.adlinkman = Utility.GetDefault<String>(dr[10]);
                m.adlinkphone = Utility.GetDefault<String>(dr[11]);
                m.adlinkemail = Utility.GetDefault<String>(dr[12]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[13]);
                m.lasteditaid = Utility.GetDefault<Int32>(dr[14]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_advertisingcategory 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。广告分类
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dadvertisingcategory : DALHandlerBase8<Madvertisingcategory, MadvertisingcategoryCollection, Eadvertisingcategory>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dadvertisingcategory 类的新实例。
        /// </summary>
        public Dadvertisingcategory() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDadvertisingcategory 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dadvertisingcategory(IDALHandler dbHandler) : base("t_advertisingcategory", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MadvertisingcategoryCollection Reader(IDataReader dr)
        {
            MadvertisingcategoryCollection rows = new MadvertisingcategoryCollection();
            while (dr.Read())
            {
                Madvertisingcategory m = new Madvertisingcategory();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.parentid = Utility.GetDefault<Int32>(dr[1]);
                m.moduleid = Utility.GetDefault<Int32>(dr[2]);
                m.modulevalue = Utility.GetDefault<String>(dr[3]);
                m.title = Utility.GetDefault<String>(dr[4]);
                m.img = Utility.GetDefault<String>(dr[5]);
                m.height = Utility.GetDefault<Int32>(dr[6]);
                m.width = Utility.GetDefault<Int32>(dr[7]);
                m.isopen = Utility.GetDefault<Int32?>(dr[8]);
                m.adtype = Utility.GetDefault<Int32>(dr[9]);
                m.starttime = Utility.GetDefault<DateTime?>(dr[10]);
                m.endtime = Utility.GetDefault<DateTime?>(dr[11]);
                m.descript = Utility.GetDefault<String>(dr[12]);
                m.template = Utility.GetDefault<String>(dr[13]);
                m.sort = Utility.GetDefault<Int32?>(dr[14]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_aggregation 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。聚合信息
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Daggregation : DALHandlerBase8<Maggregation, MaggregationCollection, Eaggregation>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Daggregation 类的新实例。
        /// </summary>
        public Daggregation() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDaggregation 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Daggregation(IDALHandler dbHandler) : base("t_aggregation", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MaggregationCollection Reader(IDataReader dr)
        {
            MaggregationCollection rows = new MaggregationCollection();
            while (dr.Read())
            {
                Maggregation m = new Maggregation();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.type = Utility.GetDefault<Int32?>(dr[1]);
                m.title = Utility.GetDefault<String>(dr[2]);
                m.title1 = Utility.GetDefault<String>(dr[3]);
                m.title2 = Utility.GetDefault<String>(dr[4]);
                m.title3 = Utility.GetDefault<String>(dr[5]);
                m.thumb = Utility.GetDefault<String>(dr[6]);
                m.thumbw = Utility.GetDefault<Int32?>(dr[7]);
                m.thumbh = Utility.GetDefault<Int32?>(dr[8]);
                m.bannel = Utility.GetDefault<String>(dr[9]);
                m.url = Utility.GetDefault<String>(dr[10]);
                m.url1 = Utility.GetDefault<String>(dr[11]);
                m.url2 = Utility.GetDefault<String>(dr[12]);
                m.descript = Utility.GetDefault<String>(dr[13]);
                m.sort = Utility.GetDefault<Int32?>(dr[14]);
                m.hits = Utility.GetDefault<Int32?>(dr[15]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[16]);
                m.createmid = Utility.GetDefault<Int32?>(dr[17]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_aggregationtype 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。信息所属模块
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Daggregationtype : DALHandlerBase8<Maggregationtype, MaggregationtypeCollection, Eaggregationtype>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Daggregationtype 类的新实例。
        /// </summary>
        public Daggregationtype() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDaggregationtype 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Daggregationtype(IDALHandler dbHandler) : base("t_aggregationtype", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MaggregationtypeCollection Reader(IDataReader dr)
        {
            MaggregationtypeCollection rows = new MaggregationtypeCollection();
            while (dr.Read())
            {
                Maggregationtype m = new Maggregationtype();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.parentid = Utility.GetDefault<Int32?>(dr[1]);
                m.title = Utility.GetDefault<String>(dr[2]);
                m.title1 = Utility.GetDefault<String>(dr[3]);
                m.thumb = Utility.GetDefault<String>(dr[4]);
                m.url = Utility.GetDefault<String>(dr[5]);
                m.sort = Utility.GetDefault<Int32?>(dr[6]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_appbrand 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。经销商、店铺品牌使用申请表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dappbrand : DALHandlerBase8<Mappbrand, MappbrandCollection, Eappbrand>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dappbrand 类的新实例。
        /// </summary>
        public Dappbrand() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDappbrand 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dappbrand(IDALHandler dbHandler) : base("t_appbrand", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MappbrandCollection Reader(IDataReader dr)
        {
            MappbrandCollection rows = new MappbrandCollection();
            while (dr.Read())
            {
                Mappbrand m = new Mappbrand();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.dealerid = Utility.GetDefault<Int32>(dr[1]);
                m.dealetitle = Utility.GetDefault<String>(dr[2]);
                m.brandid = Utility.GetDefault<Int32>(dr[3]);
                m.brandtitle = Utility.GetDefault<String>(dr[4]);
                m.companyid = Utility.GetDefault<Int32>(dr[5]);
                m.companytitle = Utility.GetDefault<String>(dr[6]);
                m.shopid = Utility.GetDefault<Int32?>(dr[7]);
                m.shoptitle = Utility.GetDefault<String>(dr[8]);
                m.appmodule = Utility.GetDefault<Int32>(dr[9]);
                m.apptype = Utility.GetDefault<Int32>(dr[10]);
                m.apptime = Utility.GetDefault<DateTime>(dr[11]);
                m.createmid = Utility.GetDefault<Int32>(dr[12]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[13]);
                m.auditstatus = Utility.GetDefault<Int32>(dr[14]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_appbrandcustomer 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。 
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dappbrandcustomer : DALHandlerBase8<Mappbrandcustomer, MappbrandcustomerCollection, Eappbrandcustomer>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dappbrandcustomer 类的新实例。
        /// </summary>
        public Dappbrandcustomer() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDappbrandcustomer 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dappbrandcustomer(IDALHandler dbHandler) : base("t_appbrandcustomer", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MappbrandcustomerCollection Reader(IDataReader dr)
        {
            MappbrandcustomerCollection rows = new MappbrandcustomerCollection();
            while (dr.Read())
            {
                Mappbrandcustomer m = new Mappbrandcustomer();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.aid = Utility.GetDefault<Int32?>(dr[1]);
                m.name = Utility.GetDefault<String>(dr[2]);
                m.phone = Utility.GetDefault<String>(dr[3]);
                m.mphone = Utility.GetDefault<String>(dr[4]);
                m.email = Utility.GetDefault<String>(dr[5]);
                m.address = Utility.GetDefault<String>(dr[6]);
                m.descript = Utility.GetDefault<String>(dr[7]);
                m.cus = Utility.GetDefault<String>(dr[8]);
                m.CreateTime = Utility.GetDefault<DateTime?>(dr[9]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_area 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。地区表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Darea : DALHandlerBase8<Marea, MareaCollection, Earea>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Darea 类的新实例。
        /// </summary>
        public Darea() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDarea 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Darea(IDALHandler dbHandler) : base("t_area", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MareaCollection Reader(IDataReader dr)
        {
            MareaCollection rows = new MareaCollection();
            while (dr.Read())
            {
                Marea m = new Marea();
                m.areacode = Utility.GetDefault<String>(dr[0]);
                m.parentcode = Utility.GetDefault<String>(dr[1]);
                m.areaname = Utility.GetDefault<String>(dr[2]);
                m.areazipcode = Utility.GetDefault<String>(dr[3]);
                m.grouparea = Utility.GetDefault<String>(dr[4]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_article 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。文章表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Darticle : DALHandlerBase8<Marticle, MarticleCollection, Earticle>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Darticle 类的新实例。
        /// </summary>
        public Darticle() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDarticle 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Darticle(IDALHandler dbHandler) : base("t_article", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MarticleCollection Reader(IDataReader dr)
        {
            MarticleCollection rows = new MarticleCollection();
            while (dr.Read())
            {
                Marticle m = new Marticle();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.nodeid = Utility.GetDefault<Int32>(dr[1]);
                m.title = Utility.GetDefault<String>(dr[2]);
                m.subtitle = Utility.GetDefault<String>(dr[3]);
                m.thumbnail = Utility.GetDefault<String>(dr[4]);
                m.imagelist = Utility.GetDefault<String>(dr[5]);
                m.filelist = Utility.GetDefault<String>(dr[6]);
                m.attribute = Utility.GetDefault<String>(dr[7]);
                m.descript = Utility.GetDefault<String>(dr[8]);
                m.author = Utility.GetDefault<String>(dr[9]);
                m.source = Utility.GetDefault<String>(dr[10]);
                m.tags = Utility.GetDefault<String>(dr[11]);
                m.sort = Utility.GetDefault<Int32?>(dr[12]);
                m.setting = Utility.GetDefault<String>(dr[13]);
                m.addusername = Utility.GetDefault<String>(dr[14]);
                m.adduserid = Utility.GetDefault<Int32>(dr[15]);
                m.adddatetime = Utility.GetDefault<DateTime>(dr[16]);
                m.lasteditusername = Utility.GetDefault<String>(dr[17]);
                m.lastedituserid = Utility.GetDefault<Int32>(dr[18]);
                m.lasteditdatetime = Utility.GetDefault<DateTime>(dr[19]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_article_data 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。 
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Darticle_data : DALHandlerBase8<Marticle_data, Marticle_dataCollection, Earticle_data>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Darticle_data 类的新实例。
        /// </summary>
        public Darticle_data() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDarticle_data 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Darticle_data(IDALHandler dbHandler) : base("t_article_data", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override Marticle_dataCollection Reader(IDataReader dr)
        {
            Marticle_dataCollection rows = new Marticle_dataCollection();
            while (dr.Read())
            {
                Marticle_data m = new Marticle_data();
                m.articleid = Utility.GetDefault<Int32>(dr[0]);
                m.data = Utility.GetDefault<String>(dr[1]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_article_node 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。 
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Darticle_node : DALHandlerBase8<Marticle_node, Marticle_nodeCollection, Earticle_node>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Darticle_node 类的新实例。
        /// </summary>
        public Darticle_node() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDarticle_node 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Darticle_node(IDALHandler dbHandler) : base("t_article_node", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override Marticle_nodeCollection Reader(IDataReader dr)
        {
            Marticle_nodeCollection rows = new Marticle_nodeCollection();
            while (dr.Read())
            {
                Marticle_node m = new Marticle_node();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.parentid = Utility.GetDefault<Int32>(dr[1]);
                m.title = Utility.GetDefault<String>(dr[2]);
                m.subtitle = Utility.GetDefault<String>(dr[3]);
                m.mark = Utility.GetDefault<String>(dr[4]);
                m.formsid = Utility.GetDefault<Int32?>(dr[5]);
                m.lft = Utility.GetDefault<Int32>(dr[6]);
                m.rgt = Utility.GetDefault<Int32>(dr[7]);
                m.lev = Utility.GetDefault<Int32>(dr[8]);
                m.path = Utility.GetDefault<String>(dr[9]);
                m.linktype = Utility.GetDefault<Int32>(dr[10]);
                m.linkurl = Utility.GetDefault<String>(dr[11]);
                m.tempcon = Utility.GetDefault<String>(dr[12]);
                m.templist = Utility.GetDefault<String>(dr[13]);
                m.tempindex = Utility.GetDefault<String>(dr[14]);
                m.filepath = Utility.GetDefault<String>(dr[15]);
                m.keywords = Utility.GetDefault<String>(dr[16]);
                m.descript = Utility.GetDefault<String>(dr[17]);
                m.tags = Utility.GetDefault<String>(dr[18]);
                m.sort = Utility.GetDefault<Int32?>(dr[19]);
                m.setting = Utility.GetDefault<String>(dr[20]);
                m.addusername = Utility.GetDefault<String>(dr[21]);
                m.adduserid = Utility.GetDefault<Int32>(dr[22]);
                m.adddatetime = Utility.GetDefault<DateTime>(dr[23]);
                m.lasteditusername = Utility.GetDefault<String>(dr[24]);
                m.lastedituserid = Utility.GetDefault<Int32>(dr[25]);
                m.lasteditdatetime = Utility.GetDefault<DateTime>(dr[26]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_brand 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。品牌表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dbrand : DALHandlerBase8<Mbrand, MbrandCollection, Ebrand>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dbrand 类的新实例。
        /// </summary>
        public Dbrand() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDbrand 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dbrand(IDALHandler dbHandler) : base("t_brand", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MbrandCollection Reader(IDataReader dr)
        {
            MbrandCollection rows = new MbrandCollection();
            while (dr.Read())
            {
                Mbrand m = new Mbrand();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.companyid = Utility.GetDefault<Int32?>(dr[1]);
                m.title = Utility.GetDefault<String>(dr[2]);
                m.letter = Utility.GetDefault<String>(dr[3]);
                m.groupid = Utility.GetDefault<Int32?>(dr[4]);
                m.attribute = Utility.GetDefault<String>(dr[5]);
                m.productcategory = Utility.GetDefault<String>(dr[6]);
                m.homepage = Utility.GetDefault<String>(dr[7]);
                m.productcount = Utility.GetDefault<Int32?>(dr[8]);
                m.spread = Utility.GetDefault<String>(dr[9]);
                m.material = Utility.GetDefault<String>(dr[10]);
                m.style = Utility.GetDefault<String>(dr[11]);
                m.color = Utility.GetDefault<String>(dr[12]);
                m.surface = Utility.GetDefault<String>(dr[13]);
                m.logo = Utility.GetDefault<String>(dr[14]);
                m.thumb = Utility.GetDefault<String>(dr[15]);
                m.bannel = Utility.GetDefault<String>(dr[16]);
                m.desimage = Utility.GetDefault<String>(dr[17]);
                m.descript = Utility.GetDefault<String>(dr[18]);
                m.keywords = Utility.GetDefault<String>(dr[19]);
                m.template = Utility.GetDefault<String>(dr[20]);
                m.hits = Utility.GetDefault<Int32?>(dr[21]);
                m.sort = Utility.GetDefault<Int32?>(dr[22]);
                m.createmid = Utility.GetDefault<Int32?>(dr[23]);
                m.lasteditid = Utility.GetDefault<Int32?>(dr[24]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[25]);
                m.auditstatus = Utility.GetDefault<Int32>(dr[26]);
                m.linestatus = Utility.GetDefault<Int32>(dr[27]);
                m.Createtime = Utility.GetDefault<DateTime?>(dr[28]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_brands 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。品牌系列表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dbrands : DALHandlerBase8<Mbrands, MbrandsCollection, Ebrands>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dbrands 类的新实例。
        /// </summary>
        public Dbrands() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDbrands 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dbrands(IDALHandler dbHandler) : base("t_brands", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MbrandsCollection Reader(IDataReader dr)
        {
            MbrandsCollection rows = new MbrandsCollection();
            while (dr.Read())
            {
                Mbrands m = new Mbrands();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.brandid = Utility.GetDefault<Int32>(dr[1]);
                m.title = Utility.GetDefault<String>(dr[2]);
                m.letter = Utility.GetDefault<String>(dr[3]);
                m.attribute = Utility.GetDefault<String>(dr[4]);
                m.productcount = Utility.GetDefault<Int32?>(dr[5]);
                m.spread = Utility.GetDefault<String>(dr[6]);
                m.material = Utility.GetDefault<String>(dr[7]);
                m.style = Utility.GetDefault<String>(dr[8]);
                m.surface = Utility.GetDefault<String>(dr[9]);
                m.logo = Utility.GetDefault<String>(dr[10]);
                m.thumb = Utility.GetDefault<String>(dr[11]);
                m.bannel = Utility.GetDefault<String>(dr[12]);
                m.desimage = Utility.GetDefault<String>(dr[13]);
                m.descript = Utility.GetDefault<String>(dr[14]);
                m.keywords = Utility.GetDefault<String>(dr[15]);
                m.template = Utility.GetDefault<String>(dr[16]);
                m.hits = Utility.GetDefault<Int32?>(dr[17]);
                m.sort = Utility.GetDefault<Int32?>(dr[18]);
                m.createmid = Utility.GetDefault<Int32?>(dr[19]);
                m.lasteditid = Utility.GetDefault<Int32?>(dr[20]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[21]);
                m.auditstatus = Utility.GetDefault<Int32>(dr[22]);
                m.linestatus = Utility.GetDefault<Int32>(dr[23]);
                m.color = Utility.GetDefault<String>(dr[24]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_company 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。厂家表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dcompany : DALHandlerBase8<Mcompany, McompanyCollection, Ecompany>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dcompany 类的新实例。
        /// </summary>
        public Dcompany() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDcompany 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dcompany(IDALHandler dbHandler) : base("t_company", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override McompanyCollection Reader(IDataReader dr)
        {
            McompanyCollection rows = new McompanyCollection();
            while (dr.Read())
            {
                Mcompany m = new Mcompany();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.mid = Utility.GetDefault<Int32>(dr[1]);
                m.title = Utility.GetDefault<String>(dr[2]);
                m.letter = Utility.GetDefault<String>(dr[3]);
                m.groupid = Utility.GetDefault<Int32>(dr[4]);
                m.attribute = Utility.GetDefault<String>(dr[5]);
                m.industry = Utility.GetDefault<String>(dr[6]);
                m.productcategory = Utility.GetDefault<String>(dr[7]);
                m.vip = Utility.GetDefault<Int32?>(dr[8]);
                m.areacode = Utility.GetDefault<String>(dr[9]);
                m.address = Utility.GetDefault<String>(dr[10]);
                m.mapapi = Utility.GetDefault<String>(dr[11]);
                m.staffsize = Utility.GetDefault<Int32?>(dr[12]);
                m.regyear = Utility.GetDefault<String>(dr[13]);
                m.regcity = Utility.GetDefault<String>(dr[14]);
                m.buy = Utility.GetDefault<String>(dr[15]);
                m.sell = Utility.GetDefault<String>(dr[16]);
                m.linkman = Utility.GetDefault<String>(dr[17]);
                m.phone = Utility.GetDefault<String>(dr[18]);
                m.mphone = Utility.GetDefault<String>(dr[19]);
                m.fax = Utility.GetDefault<String>(dr[20]);
                m.email = Utility.GetDefault<String>(dr[21]);
                m.postcode = Utility.GetDefault<String>(dr[22]);
                m.homepage = Utility.GetDefault<String>(dr[23]);
                m.domain = Utility.GetDefault<String>(dr[24]);
                m.domainip = Utility.GetDefault<String>(dr[25]);
                m.icp = Utility.GetDefault<String>(dr[26]);
                m.surface = Utility.GetDefault<String>(dr[27]);
                m.logo = Utility.GetDefault<String>(dr[28]);
                m.thumb = Utility.GetDefault<String>(dr[29]);
                m.bannel = Utility.GetDefault<String>(dr[30]);
                m.desimage = Utility.GetDefault<String>(dr[31]);
                m.descript = Utility.GetDefault<String>(dr[32]);
                m.keywords = Utility.GetDefault<String>(dr[33]);
                m.template = Utility.GetDefault<String>(dr[34]);
                m.hits = Utility.GetDefault<Int32?>(dr[35]);
                m.sort = Utility.GetDefault<Int32?>(dr[36]);
                m.createmid = Utility.GetDefault<Int32?>(dr[37]);
                m.lastedid = Utility.GetDefault<Int32?>(dr[38]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[39]);
                m.auditstatus = Utility.GetDefault<Int32>(dr[40]);
                m.linestatus = Utility.GetDefault<Int32>(dr[41]);
                m.license = Utility.GetDefault<String>(dr[42]);
                m.registration = Utility.GetDefault<String>(dr[43]);
                m.organization = Utility.GetDefault<String>(dr[44]);
                m.Createtime = Utility.GetDefault<DateTime?>(dr[45]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_companygroup 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。厂家组表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dcompanygroup : DALHandlerBase8<Mcompanygroup, McompanygroupCollection, Ecompanygroup>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dcompanygroup 类的新实例。
        /// </summary>
        public Dcompanygroup() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDcompanygroup 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dcompanygroup(IDALHandler dbHandler) : base("t_companygroup", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override McompanygroupCollection Reader(IDataReader dr)
        {
            McompanygroupCollection rows = new McompanygroupCollection();
            while (dr.Read())
            {
                Mcompanygroup m = new Mcompanygroup();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.color = Utility.GetDefault<String>(dr[2]);
                m.avatar = Utility.GetDefault<String>(dr[3]);
                m.integral = Utility.GetDefault<Decimal?>(dr[4]);
                m.money = Utility.GetDefault<Decimal?>(dr[5]);
                m.adcount = Utility.GetDefault<Int32?>(dr[6]);
                m.shopcount = Utility.GetDefault<Int32?>(dr[7]);
                m.brandcount = Utility.GetDefault<Int32?>(dr[8]);
                m.promotioncount = Utility.GetDefault<Int32?>(dr[9]);
                m.adrecommend = Utility.GetDefault<Int32?>(dr[10]);
                m.shoprecommend = Utility.GetDefault<Int32?>(dr[11]);
                m.brandrecommend = Utility.GetDefault<Int32?>(dr[12]);
                m.promotionrecommend = Utility.GetDefault<Int32?>(dr[13]);
                m.permissions = Utility.GetDefault<String>(dr[14]);
                m.lev = Utility.GetDefault<Int32?>(dr[15]);
                m.descript = Utility.GetDefault<String>(dr[16]);
                m.sort = Utility.GetDefault<Int32?>(dr[17]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_config 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。配置表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dconfig : DALHandlerBase8<Mconfig, MconfigCollection, Econfig>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dconfig 类的新实例。
        /// </summary>
        public Dconfig() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDconfig 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dconfig(IDALHandler dbHandler) : base("t_config", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MconfigCollection Reader(IDataReader dr)
        {
            MconfigCollection rows = new MconfigCollection();
            while (dr.Read())
            {
                Mconfig m = new Mconfig();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.value = Utility.GetDefault<String>(dr[2]);
                m.type = Utility.GetDefault<Int32>(dr[3]);
                m.module = Utility.GetDefault<Int32>(dr[4]);
                m.sort = Utility.GetDefault<Int32?>(dr[5]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_configtype 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。配置类型表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dconfigtype : DALHandlerBase8<Mconfigtype, MconfigtypeCollection, Econfigtype>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dconfigtype 类的新实例。
        /// </summary>
        public Dconfigtype() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDconfigtype 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dconfigtype(IDALHandler dbHandler) : base("t_configtype", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MconfigtypeCollection Reader(IDataReader dr)
        {
            MconfigtypeCollection rows = new MconfigtypeCollection();
            while (dr.Read())
            {
                Mconfigtype m = new Mconfigtype();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.mark = Utility.GetDefault<String>(dr[2]);
                m.letter = Utility.GetDefault<String>(dr[3]);
                m.type = Utility.GetDefault<String>(dr[4]);
                m.sort = Utility.GetDefault<Int32?>(dr[5]);
                m.count = Utility.GetDefault<Int32?>(dr[6]);
                m.descript = Utility.GetDefault<String>(dr[7]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_dealer 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。经销商
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Ddealer : DALHandlerBase8<Mdealer, MdealerCollection, Edealer>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Ddealer 类的新实例。
        /// </summary>
        public Ddealer() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDdealer 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Ddealer(IDALHandler dbHandler) : base("t_dealer", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MdealerCollection Reader(IDataReader dr)
        {
            MdealerCollection rows = new MdealerCollection();
            while (dr.Read())
            {
                Mdealer m = new Mdealer();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.mid = Utility.GetDefault<Int32>(dr[1]);
                m.title = Utility.GetDefault<String>(dr[2]);
                m.letter = Utility.GetDefault<String>(dr[3]);
                m.groupid = Utility.GetDefault<Int32>(dr[4]);
                m.attribute = Utility.GetDefault<String>(dr[5]);
                m.industry = Utility.GetDefault<String>(dr[6]);
                m.productcategory = Utility.GetDefault<String>(dr[7]);
                m.vip = Utility.GetDefault<Int32?>(dr[8]);
                m.areacode = Utility.GetDefault<String>(dr[9]);
                m.address = Utility.GetDefault<String>(dr[10]);
                m.mapapi = Utility.GetDefault<String>(dr[11]);
                m.staffsize = Utility.GetDefault<Int32?>(dr[12]);
                m.regyear = Utility.GetDefault<String>(dr[13]);
                m.regcity = Utility.GetDefault<String>(dr[14]);
                m.buy = Utility.GetDefault<String>(dr[15]);
                m.sell = Utility.GetDefault<String>(dr[16]);
                m.linkman = Utility.GetDefault<String>(dr[17]);
                m.phone = Utility.GetDefault<String>(dr[18]);
                m.mphone = Utility.GetDefault<String>(dr[19]);
                m.fax = Utility.GetDefault<String>(dr[20]);
                m.email = Utility.GetDefault<String>(dr[21]);
                m.postcode = Utility.GetDefault<String>(dr[22]);
                m.homepage = Utility.GetDefault<String>(dr[23]);
                m.domain = Utility.GetDefault<String>(dr[24]);
                m.domainip = Utility.GetDefault<String>(dr[25]);
                m.icp = Utility.GetDefault<String>(dr[26]);
                m.surface = Utility.GetDefault<String>(dr[27]);
                m.logo = Utility.GetDefault<String>(dr[28]);
                m.thumb = Utility.GetDefault<String>(dr[29]);
                m.bannel = Utility.GetDefault<String>(dr[30]);
                m.desimage = Utility.GetDefault<String>(dr[31]);
                m.descript = Utility.GetDefault<String>(dr[32]);
                m.keywords = Utility.GetDefault<String>(dr[33]);
                m.template = Utility.GetDefault<String>(dr[34]);
                m.hits = Utility.GetDefault<Int32?>(dr[35]);
                m.sort = Utility.GetDefault<Int32?>(dr[36]);
                m.createmid = Utility.GetDefault<Int32?>(dr[37]);
                m.lastedid = Utility.GetDefault<Int32?>(dr[38]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[39]);
                m.auditstatus = Utility.GetDefault<Int32>(dr[40]);
                m.linestatus = Utility.GetDefault<Int32>(dr[41]);
                m.dbook = Utility.GetDefault<String>(dr[42]);
                m.Createtime = Utility.GetDefault<DateTime?>(dr[43]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_dealergroup 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。经销商组表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Ddealergroup : DALHandlerBase8<Mdealergroup, MdealergroupCollection, Edealergroup>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Ddealergroup 类的新实例。
        /// </summary>
        public Ddealergroup() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDdealergroup 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Ddealergroup(IDALHandler dbHandler) : base("t_dealergroup", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MdealergroupCollection Reader(IDataReader dr)
        {
            MdealergroupCollection rows = new MdealergroupCollection();
            while (dr.Read())
            {
                Mdealergroup m = new Mdealergroup();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.color = Utility.GetDefault<String>(dr[2]);
                m.avatar = Utility.GetDefault<String>(dr[3]);
                m.integral = Utility.GetDefault<Decimal?>(dr[4]);
                m.money = Utility.GetDefault<Decimal?>(dr[5]);
                m.adcount = Utility.GetDefault<Int32?>(dr[6]);
                m.shopcount = Utility.GetDefault<Int32?>(dr[7]);
                m.brandcount = Utility.GetDefault<Int32?>(dr[8]);
                m.promotioncount = Utility.GetDefault<Int32?>(dr[9]);
                m.adrecommend = Utility.GetDefault<Int32?>(dr[10]);
                m.shoprecommend = Utility.GetDefault<Int32?>(dr[11]);
                m.brandrecommend = Utility.GetDefault<Int32?>(dr[12]);
                m.promotionrecommend = Utility.GetDefault<Int32?>(dr[13]);
                m.permissions = Utility.GetDefault<String>(dr[14]);
                m.lev = Utility.GetDefault<Int32?>(dr[15]);
                m.descript = Utility.GetDefault<String>(dr[16]);
                m.sort = Utility.GetDefault<Int32?>(dr[17]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_grouporder 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。 
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dgrouporder : DALHandlerBase8<Mgrouporder, MgrouporderCollection, Egrouporder>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dgrouporder 类的新实例。
        /// </summary>
        public Dgrouporder() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDgrouporder 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dgrouporder(IDALHandler dbHandler) : base("t_grouporder", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MgrouporderCollection Reader(IDataReader dr)
        {
            MgrouporderCollection rows = new MgrouporderCollection();
            while (dr.Read())
            {
                Mgrouporder m = new Mgrouporder();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.grouporderno = Utility.GetDefault<String>(dr[1]);
                m.mid = Utility.GetDefault<Int32?>(dr[2]);
                m.fjmid = Utility.GetDefault<Int32?>(dr[3]);
                m.name = Utility.GetDefault<String>(dr[4]);
                m.email = Utility.GetDefault<String>(dr[5]);
                m.phone = Utility.GetDefault<String>(dr[6]);
                m.fax = Utility.GetDefault<String>(dr[7]);
                m.mphone = Utility.GetDefault<String>(dr[8]);
                m.zip = Utility.GetDefault<String>(dr[9]);
                m.areacode = Utility.GetDefault<String>(dr[10]);
                m.address = Utility.GetDefault<String>(dr[11]);
                m.descript = Utility.GetDefault<String>(dr[12]);
                m.totlepromoney = Utility.GetDefault<Decimal?>(dr[13]);
                m.totalmoney = Utility.GetDefault<Decimal?>(dr[14]);
                m.invoicemoney = Utility.GetDefault<Decimal?>(dr[15]);
                m.installationmeney = Utility.GetDefault<Decimal?>(dr[16]);
                m.status = Utility.GetDefault<Int32?>(dr[17]);
                m.createtime = Utility.GetDefault<DateTime?>(dr[18]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_grouporderpay 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。 
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dgrouporderpay : DALHandlerBase8<Mgrouporderpay, MgrouporderpayCollection, Egrouporderpay>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dgrouporderpay 类的新实例。
        /// </summary>
        public Dgrouporderpay() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDgrouporderpay 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dgrouporderpay(IDALHandler dbHandler) : base("t_grouporderpay", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MgrouporderpayCollection Reader(IDataReader dr)
        {
            MgrouporderpayCollection rows = new MgrouporderpayCollection();
            while (dr.Read())
            {
                Mgrouporderpay m = new Mgrouporderpay();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.grouporderid = Utility.GetDefault<Int32?>(dr[1]);
                m.grouporderno = Utility.GetDefault<String>(dr[2]);
                m.paycode = Utility.GetDefault<String>(dr[3]);
                m.paytype = Utility.GetDefault<Int32?>(dr[4]);
                m.paymoney = Utility.GetDefault<Decimal?>(dr[5]);
                m.descript = Utility.GetDefault<String>(dr[6]);
                m.paystatus = Utility.GetDefault<Int32?>(dr[7]);
                m.paydatetime = Utility.GetDefault<DateTime?>(dr[8]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_grouporderproduct 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。 
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dgrouporderproduct : DALHandlerBase8<Mgrouporderproduct, MgrouporderproductCollection, Egrouporderproduct>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dgrouporderproduct 类的新实例。
        /// </summary>
        public Dgrouporderproduct() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDgrouporderproduct 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dgrouporderproduct(IDALHandler dbHandler) : base("t_grouporderproduct", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MgrouporderproductCollection Reader(IDataReader dr)
        {
            MgrouporderproductCollection rows = new MgrouporderproductCollection();
            while (dr.Read())
            {
                Mgrouporderproduct m = new Mgrouporderproduct();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.grouporderid = Utility.GetDefault<Int32?>(dr[1]);
                m.grouporderno = Utility.GetDefault<String>(dr[2]);
                m.promotionid = Utility.GetDefault<Int32?>(dr[3]);
                m.promotiondefid = Utility.GetDefault<Int32?>(dr[4]);
                m.promoteionstageid = Utility.GetDefault<Int32?>(dr[5]);
                m.promoteionstagevalue = Utility.GetDefault<String>(dr[6]);
                m.productid = Utility.GetDefault<Int32?>(dr[7]);
                m.productattributeid = Utility.GetDefault<Int32?>(dr[8]);
                m.productcode = Utility.GetDefault<String>(dr[9]);
                m.productname = Utility.GetDefault<String>(dr[10]);
                m.color = Utility.GetDefault<String>(dr[11]);
                m.material = Utility.GetDefault<String>(dr[12]);
                m.size = Utility.GetDefault<String>(dr[13]);
                m.cbm = Utility.GetDefault<Decimal?>(dr[14]);
                m.num = Utility.GetDefault<Int32?>(dr[15]);
                m.price = Utility.GetDefault<Decimal?>(dr[16]);
                m.totalmoney = Utility.GetDefault<Decimal?>(dr[17]);
                m.proprice = Utility.GetDefault<Decimal?>(dr[18]);
                m.prototalmoney = Utility.GetDefault<Decimal?>(dr[19]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_log 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。日志表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dlog : DALHandlerBase8<Mlog, MlogCollection, Elog>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dlog 类的新实例。
        /// </summary>
        public Dlog() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDlog 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dlog(IDALHandler dbHandler) : base("t_log", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MlogCollection Reader(IDataReader dr)
        {
            MlogCollection rows = new MlogCollection();
            while (dr.Read())
            {
                Mlog m = new Mlog();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.modeule = Utility.GetDefault<Int32?>(dr[1]);
                m.action = Utility.GetDefault<Int32?>(dr[2]);
                m.operateid = Utility.GetDefault<Int32?>(dr[3]);
                m.operatename = Utility.GetDefault<String>(dr[4]);
                m.title = Utility.GetDefault<String>(dr[5]);
                m.lastedittime = Utility.GetDefault<DateTime?>(dr[6]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_market 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。卖场表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dmarket : DALHandlerBase8<Mmarket, MmarketCollection, Emarket>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dmarket 类的新实例。
        /// </summary>
        public Dmarket() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDmarket 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dmarket(IDALHandler dbHandler) : base("t_market", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MmarketCollection Reader(IDataReader dr)
        {
            MmarketCollection rows = new MmarketCollection();
            while (dr.Read())
            {
                Mmarket m = new Mmarket();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.mid = Utility.GetDefault<Int32?>(dr[1]);
                m.title = Utility.GetDefault<String>(dr[2]);
                m.letter = Utility.GetDefault<String>(dr[3]);
                m.groupid = Utility.GetDefault<Int32?>(dr[4]);
                m.attribute = Utility.GetDefault<String>(dr[5]);
                m.industry = Utility.GetDefault<String>(dr[6]);
                m.productcategory = Utility.GetDefault<String>(dr[7]);
                m.vip = Utility.GetDefault<Int32?>(dr[8]);
                m.areacode = Utility.GetDefault<String>(dr[9]);
                m.address = Utility.GetDefault<String>(dr[10]);
                m.mapapi = Utility.GetDefault<String>(dr[11]);
                m.staffsize = Utility.GetDefault<Int32?>(dr[12]);
                m.regyear = Utility.GetDefault<String>(dr[13]);
                m.regcity = Utility.GetDefault<String>(dr[14]);
                m.buy = Utility.GetDefault<String>(dr[15]);
                m.sell = Utility.GetDefault<String>(dr[16]);
                m.cbm = Utility.GetDefault<Decimal?>(dr[17]);
                m.lphone = Utility.GetDefault<String>(dr[18]);
                m.zphone = Utility.GetDefault<String>(dr[19]);
                m.busroute = Utility.GetDefault<String>(dr[20]);
                m.hours = Utility.GetDefault<String>(dr[21]);
                m.linkman = Utility.GetDefault<String>(dr[22]);
                m.phone = Utility.GetDefault<String>(dr[23]);
                m.mphone = Utility.GetDefault<String>(dr[24]);
                m.fax = Utility.GetDefault<String>(dr[25]);
                m.email = Utility.GetDefault<String>(dr[26]);
                m.postcode = Utility.GetDefault<String>(dr[27]);
                m.homepage = Utility.GetDefault<String>(dr[28]);
                m.domain = Utility.GetDefault<String>(dr[29]);
                m.domainip = Utility.GetDefault<String>(dr[30]);
                m.icp = Utility.GetDefault<String>(dr[31]);
                m.surface = Utility.GetDefault<String>(dr[32]);
                m.logo = Utility.GetDefault<String>(dr[33]);
                m.thumb = Utility.GetDefault<String>(dr[34]);
                m.bannel = Utility.GetDefault<String>(dr[35]);
                m.desimage = Utility.GetDefault<String>(dr[36]);
                m.descript = Utility.GetDefault<String>(dr[37]);
                m.keywords = Utility.GetDefault<String>(dr[38]);
                m.template = Utility.GetDefault<String>(dr[39]);
                m.hits = Utility.GetDefault<Int32?>(dr[40]);
                m.sort = Utility.GetDefault<Int32?>(dr[41]);
                m.createmid = Utility.GetDefault<Int32?>(dr[42]);
                m.lastedid = Utility.GetDefault<Int32?>(dr[43]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[44]);
                m.auditstatus = Utility.GetDefault<Int32>(dr[45]);
                m.linestatus = Utility.GetDefault<Int32>(dr[46]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_marketgroup 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。卖场组表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dmarketgroup : DALHandlerBase8<Mmarketgroup, MmarketgroupCollection, Emarketgroup>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dmarketgroup 类的新实例。
        /// </summary>
        public Dmarketgroup() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDmarketgroup 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dmarketgroup(IDALHandler dbHandler) : base("t_marketgroup", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MmarketgroupCollection Reader(IDataReader dr)
        {
            MmarketgroupCollection rows = new MmarketgroupCollection();
            while (dr.Read())
            {
                Mmarketgroup m = new Mmarketgroup();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.color = Utility.GetDefault<String>(dr[2]);
                m.avatar = Utility.GetDefault<String>(dr[3]);
                m.integral = Utility.GetDefault<Decimal?>(dr[4]);
                m.money = Utility.GetDefault<Decimal?>(dr[5]);
                m.adcount = Utility.GetDefault<Int32?>(dr[6]);
                m.shopcount = Utility.GetDefault<Int32?>(dr[7]);
                m.brandcount = Utility.GetDefault<Int32?>(dr[8]);
                m.promotioncount = Utility.GetDefault<Int32?>(dr[9]);
                m.storeycount = Utility.GetDefault<Int32?>(dr[10]);
                m.storeyshopcount = Utility.GetDefault<Int32?>(dr[11]);
                m.adrecommend = Utility.GetDefault<Int32?>(dr[12]);
                m.shoprecommend = Utility.GetDefault<Int32?>(dr[13]);
                m.brandrecommend = Utility.GetDefault<Int32?>(dr[14]);
                m.promotionrecommend = Utility.GetDefault<Int32?>(dr[15]);
                m.lev = Utility.GetDefault<Int32?>(dr[16]);
                m.permissions = Utility.GetDefault<String>(dr[17]);
                m.descript = Utility.GetDefault<String>(dr[18]);
                m.sort = Utility.GetDefault<Int32?>(dr[19]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_marketstorey 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。卖场楼层表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dmarketstorey : DALHandlerBase8<Mmarketstorey, MmarketstoreyCollection, Emarketstorey>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dmarketstorey 类的新实例。
        /// </summary>
        public Dmarketstorey() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDmarketstorey 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dmarketstorey(IDALHandler dbHandler) : base("t_marketstorey", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MmarketstoreyCollection Reader(IDataReader dr)
        {
            MmarketstoreyCollection rows = new MmarketstoreyCollection();
            while (dr.Read())
            {
                Mmarketstorey m = new Mmarketstorey();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.marketid = Utility.GetDefault<Int32>(dr[1]);
                m.markettitle = Utility.GetDefault<String>(dr[2]);
                m.title = Utility.GetDefault<String>(dr[3]);
                m.number = Utility.GetDefault<String>(dr[4]);
                m.surface = Utility.GetDefault<String>(dr[5]);
                m.logo = Utility.GetDefault<String>(dr[6]);
                m.thumb = Utility.GetDefault<String>(dr[7]);
                m.bannel = Utility.GetDefault<String>(dr[8]);
                m.desimage = Utility.GetDefault<String>(dr[9]);
                m.descript = Utility.GetDefault<String>(dr[10]);
                m.keywords = Utility.GetDefault<String>(dr[11]);
                m.template = Utility.GetDefault<String>(dr[12]);
                m.hits = Utility.GetDefault<Int32?>(dr[13]);
                m.sort = Utility.GetDefault<Int32?>(dr[14]);
                m.lastedid = Utility.GetDefault<Int32?>(dr[15]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[16]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_marketstoreyshop 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。卖场楼层店铺
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dmarketstoreyshop : DALHandlerBase8<Mmarketstoreyshop, MmarketstoreyshopCollection, Emarketstoreyshop>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dmarketstoreyshop 类的新实例。
        /// </summary>
        public Dmarketstoreyshop() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDmarketstoreyshop 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dmarketstoreyshop(IDALHandler dbHandler) : base("t_marketstoreyshop", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MmarketstoreyshopCollection Reader(IDataReader dr)
        {
            MmarketstoreyshopCollection rows = new MmarketstoreyshopCollection();
            while (dr.Read())
            {
                Mmarketstoreyshop m = new Mmarketstoreyshop();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.marketid = Utility.GetDefault<Int32>(dr[1]);
                m.markettitle = Utility.GetDefault<String>(dr[2]);
                m.storeyid = Utility.GetDefault<Int32>(dr[3]);
                m.storeytitle = Utility.GetDefault<String>(dr[4]);
                m.shopid = Utility.GetDefault<Int32>(dr[5]);
                m.shoptitle = Utility.GetDefault<String>(dr[6]);
                m.brandidlist = Utility.GetDefault<String>(dr[7]);
                m.brandtitlelist = Utility.GetDefault<String>(dr[8]);
                m.istop = Utility.GetDefault<Int32?>(dr[9]);
                m.isrecommend = Utility.GetDefault<Int32?>(dr[10]);
                m.lev = Utility.GetDefault<Int32?>(dr[11]);
                m.sort = Utility.GetDefault<Int32?>(dr[12]);
                m.lastedid = Utility.GetDefault<Int32?>(dr[13]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[14]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_member 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。会员表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dmember : DALHandlerBase8<Mmember, MmemberCollection, Emember>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dmember 类的新实例。
        /// </summary>
        public Dmember() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDmember 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dmember(IDALHandler dbHandler) : base("t_member", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MmemberCollection Reader(IDataReader dr)
        {
            MmemberCollection rows = new MmemberCollection();
            while (dr.Read())
            {
                Mmember m = new Mmember();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.username = Utility.GetDefault<String>(dr[1]);
                m.password = Utility.GetDefault<String>(dr[2]);
                m.paypassword = Utility.GetDefault<String>(dr[3]);
                m.passport = Utility.GetDefault<String>(dr[4]);
                m.type = Utility.GetDefault<Int32>(dr[5]);
                m.groupid = Utility.GetDefault<Int32>(dr[6]);
                m.sound = Utility.GetDefault<String>(dr[7]);
                m.tname = Utility.GetDefault<String>(dr[8]);
                m.email = Utility.GetDefault<String>(dr[9]);
                m.gender = Utility.GetDefault<Int32?>(dr[10]);
                m.mobile = Utility.GetDefault<String>(dr[11]);
                m.phone = Utility.GetDefault<String>(dr[12]);
                m.msn = Utility.GetDefault<String>(dr[13]);
                m.qq = Utility.GetDefault<String>(dr[14]);
                m.skype = Utility.GetDefault<String>(dr[15]);
                m.ali = Utility.GetDefault<String>(dr[16]);
                m.birthdate = Utility.GetDefault<DateTime?>(dr[17]);
                m.areacode = Utility.GetDefault<String>(dr[18]);
                m.address = Utility.GetDefault<String>(dr[19]);
                m.department = Utility.GetDefault<String>(dr[20]);
                m.career = Utility.GetDefault<String>(dr[21]);
                m.sms = Utility.GetDefault<Decimal?>(dr[22]);
                m.integral = Utility.GetDefault<Decimal?>(dr[23]);
                m.money = Utility.GetDefault<Decimal?>(dr[24]);
                m.bank = Utility.GetDefault<String>(dr[25]);
                m.account = Utility.GetDefault<String>(dr[26]);
                m.alipay = Utility.GetDefault<String>(dr[27]);
                m.regip = Utility.GetDefault<String>(dr[28]);
                m.regtime = Utility.GetDefault<DateTime?>(dr[29]);
                m.loginip = Utility.GetDefault<String>(dr[30]);
                m.logintime = Utility.GetDefault<DateTime?>(dr[31]);
                m.logincount = Utility.GetDefault<Int32?>(dr[32]);
                m.auth = Utility.GetDefault<String>(dr[33]);
                m.authvalue = Utility.GetDefault<String>(dr[34]);
                m.authtime = Utility.GetDefault<DateTime?>(dr[35]);
                m.vemail = Utility.GetDefault<Int32?>(dr[36]);
                m.vmobile = Utility.GetDefault<Int32?>(dr[37]);
                m.vname = Utility.GetDefault<Int32?>(dr[38]);
                m.vbank = Utility.GetDefault<Int32?>(dr[39]);
                m.vcompany = Utility.GetDefault<Int32?>(dr[40]);
                m.valipay = Utility.GetDefault<Int32?>(dr[41]);
                m.support = Utility.GetDefault<String>(dr[42]);
                m.inviter = Utility.GetDefault<String>(dr[43]);
                m.lastedittime = Utility.GetDefault<DateTime?>(dr[44]);
                m.chat = Utility.GetDefault<Int32?>(dr[45]);
                m.message = Utility.GetDefault<Int32?>(dr[46]);
                m.question = Utility.GetDefault<Int32?>(dr[47]);
                m.answer = Utility.GetDefault<String>(dr[48]);
                m.overprice = Utility.GetDefault<Decimal?>(dr[49]);
                m.useprice = Utility.GetDefault<Decimal?>(dr[50]);
                m.Isrecharge = Utility.GetDefault<Boolean?>(dr[51]);
                m.RegStatcTime = Utility.GetDefault<DateTime?>(dr[52]);
                m.RegEndTime = Utility.GetDefault<DateTime?>(dr[53]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_membergroup 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。会员组表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dmembergroup : DALHandlerBase8<Mmembergroup, MmembergroupCollection, Emembergroup>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dmembergroup 类的新实例。
        /// </summary>
        public Dmembergroup() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDmembergroup 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dmembergroup(IDALHandler dbHandler) : base("t_membergroup", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MmembergroupCollection Reader(IDataReader dr)
        {
            MmembergroupCollection rows = new MmembergroupCollection();
            while (dr.Read())
            {
                Mmembergroup m = new Mmembergroup();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.color = Utility.GetDefault<String>(dr[2]);
                m.avatar = Utility.GetDefault<String>(dr[3]);
                m.integral = Utility.GetDefault<Decimal?>(dr[4]);
                m.money = Utility.GetDefault<Decimal?>(dr[5]);
                m.permissions = Utility.GetDefault<String>(dr[6]);
                m.lev = Utility.GetDefault<Int32?>(dr[7]);
                m.descript = Utility.GetDefault<String>(dr[8]);
                m.sort = Utility.GetDefault<Int32?>(dr[9]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_menu 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。菜单表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dmenu : DALHandlerBase8<Mmenu, MmenuCollection, Emenu>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dmenu 类的新实例。
        /// </summary>
        public Dmenu() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDmenu 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dmenu(IDALHandler dbHandler) : base("t_menu", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MmenuCollection Reader(IDataReader dr)
        {
            MmenuCollection rows = new MmenuCollection();
            while (dr.Read())
            {
                Mmenu m = new Mmenu();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.type = Utility.GetDefault<String>(dr[2]);
                m.mark = Utility.GetDefault<String>(dr[3]);
                m.parent = Utility.GetDefault<Int32?>(dr[4]);
                m.lev = Utility.GetDefault<Int32?>(dr[5]);
                m.path = Utility.GetDefault<String>(dr[6]);
                m.url = Utility.GetDefault<String>(dr[7]);
                m.module = Utility.GetDefault<Int32?>(dr[8]);
                m.action = Utility.GetDefault<Int32?>(dr[9]);
                m.descript = Utility.GetDefault<String>(dr[10]);
                m.sort = Utility.GetDefault<Int32?>(dr[11]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_news 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。新闻信息表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dnews : DALHandlerBase8<Mnews, MnewsCollection, Enews>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dnews 类的新实例。
        /// </summary>
        public Dnews() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDnews 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dnews(IDALHandler dbHandler) : base("t_news", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MnewsCollection Reader(IDataReader dr)
        {
            MnewsCollection rows = new MnewsCollection();
            while (dr.Read())
            {
                Mnews m = new Mnews();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.ismember = Utility.GetDefault<Boolean>(dr[1]);
                m.mid = Utility.GetDefault<Int32>(dr[2]);
                m.membertype = Utility.GetDefault<Int32>(dr[3]);
                m.adminid = Utility.GetDefault<Int32>(dr[4]);
                m.title = Utility.GetDefault<String>(dr[5]);
                m.letter = Utility.GetDefault<String>(dr[6]);
                m.intro = Utility.GetDefault<String>(dr[7]);
                m.descript = Utility.GetDefault<String>(dr[8]);
                m.auditstatus = Utility.GetDefault<Int32>(dr[9]);
                m.linestatus = Utility.GetDefault<Int32>(dr[10]);
                m.createtime = Utility.GetDefault<DateTime>(dr[11]);
                m.lastedtime = Utility.GetDefault<DateTime>(dr[12]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_PayMent 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。支付表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DPayMent : DALHandlerBase8<MPayMent, MPayMentCollection, EPayMent>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.DPayMent 类的新实例。
        /// </summary>
        public DPayMent() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDPayMent 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public DPayMent(IDALHandler dbHandler) : base("t_PayMent", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MPayMentCollection Reader(IDataReader dr)
        {
            MPayMentCollection rows = new MPayMentCollection();
            while (dr.Read())
            {
                MPayMent m = new MPayMent();
                m.ID = Utility.GetDefault<Int32>(dr[0]);
                m.OrderCode = Utility.GetDefault<String>(dr[1]);
                m.Price = Utility.GetDefault<Decimal?>(dr[2]);
                m.Mid = Utility.GetDefault<Int32?>(dr[3]);
                m.Types = Utility.GetDefault<Int32?>(dr[4]);
                m.Bank = Utility.GetDefault<String>(dr[5]);
                m.CreateTime = Utility.GetDefault<DateTime?>(dr[6]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_PayMentLog 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。支付日志表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DPayMentLog : DALHandlerBase8<MPayMentLog, MPayMentLogCollection, EPayMentLog>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.DPayMentLog 类的新实例。
        /// </summary>
        public DPayMentLog() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDPayMentLog 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public DPayMentLog(IDALHandler dbHandler) : base("t_PayMentLog", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MPayMentLogCollection Reader(IDataReader dr)
        {
            MPayMentLogCollection rows = new MPayMentLogCollection();
            while (dr.Read())
            {
                MPayMentLog m = new MPayMentLog();
                m.ID = Utility.GetDefault<Int32>(dr[0]);
                m.OrderCode = Utility.GetDefault<String>(dr[1]);
                m.Price = Utility.GetDefault<Decimal?>(dr[2]);
                m.Mid = Utility.GetDefault<Int32?>(dr[3]);
                m.Types = Utility.GetDefault<Int32?>(dr[4]);
                m.Bank = Utility.GetDefault<String>(dr[5]);
                m.CreateTime = Utility.GetDefault<DateTime?>(dr[6]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_pcategoryptypedef 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。产品分类与产品类型关联表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dpcategoryptypedef : DALHandlerBase8<Mpcategoryptypedef, MpcategoryptypedefCollection, Epcategoryptypedef>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dpcategoryptypedef 类的新实例。
        /// </summary>
        public Dpcategoryptypedef() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDpcategoryptypedef 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dpcategoryptypedef(IDALHandler dbHandler) : base("t_pcategoryptypedef", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MpcategoryptypedefCollection Reader(IDataReader dr)
        {
            MpcategoryptypedefCollection rows = new MpcategoryptypedefCollection();
            while (dr.Read())
            {
                Mpcategoryptypedef m = new Mpcategoryptypedef();
                m.productcategoryid = Utility.GetDefault<Int32>(dr[0]);
                m.producttypeid = Utility.GetDefault<Int32?>(dr[1]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_product 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。产品表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dproduct : DALHandlerBase8<Mproduct, MproductCollection, Eproduct>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dproduct 类的新实例。
        /// </summary>
        public Dproduct() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDproduct 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dproduct(IDALHandler dbHandler) : base("t_product", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MproductCollection Reader(IDataReader dr)
        {
            MproductCollection rows = new MproductCollection();
            while (dr.Read())
            {
                Mproduct m = new Mproduct();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.attribute = Utility.GetDefault<String>(dr[1]);
                m.title = Utility.GetDefault<String>(dr[2]);
                m.shottitle = Utility.GetDefault<String>(dr[3]);
                m.tcolor = Utility.GetDefault<String>(dr[4]);
                m.sku = Utility.GetDefault<String>(dr[5]);
                m.no = Utility.GetDefault<String>(dr[6]);
                m.letter = Utility.GetDefault<String>(dr[7]);
                m.categoryid = Utility.GetDefault<Int32>(dr[8]);
                m.categorytitle = Utility.GetDefault<String>(dr[9]);
                m.subcategoryidlist = Utility.GetDefault<String>(dr[10]);
                m.subcategorytitlelist = Utility.GetDefault<String>(dr[11]);
                m.brandid = Utility.GetDefault<Int32>(dr[12]);
                m.brandtitle = Utility.GetDefault<String>(dr[13]);
                m.brandsid = Utility.GetDefault<Int32?>(dr[14]);
                m.brandstitle = Utility.GetDefault<String>(dr[15]);
                m.stylevalue = Utility.GetDefault<String>(dr[16]);
                m.stylename = Utility.GetDefault<String>(dr[17]);
                m.colorname = Utility.GetDefault<String>(dr[18]);
                m.colorvalue = Utility.GetDefault<String>(dr[19]);
                m.materialvalue = Utility.GetDefault<String>(dr[20]);
                m.materialname = Utility.GetDefault<String>(dr[21]);
                m.unit = Utility.GetDefault<String>(dr[22]);
                m.localitycode = Utility.GetDefault<String>(dr[23]);
                m.shipcode = Utility.GetDefault<String>(dr[24]);
                m.customize = Utility.GetDefault<Int32?>(dr[25]);
                m.surface = Utility.GetDefault<String>(dr[26]);
                m.logo = Utility.GetDefault<String>(dr[27]);
                m.thumb = Utility.GetDefault<String>(dr[28]);
                m.bannel = Utility.GetDefault<String>(dr[29]);
                m.desimage = Utility.GetDefault<String>(dr[30]);
                m.descript = Utility.GetDefault<String>(dr[31]);
                m.tob2c = Utility.GetDefault<String>(dr[32]);
                m.companyid = Utility.GetDefault<Int32?>(dr[33]);
                m.companyname = Utility.GetDefault<String>(dr[34]);
                m.createmid = Utility.GetDefault<Int32>(dr[35]);
                m.hits = Utility.GetDefault<Int32?>(dr[36]);
                m.sort = Utility.GetDefault<Int32?>(dr[37]);
                m.lastedid = Utility.GetDefault<Int32?>(dr[38]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[39]);
                m.auditstatus = Utility.GetDefault<Int32>(dr[40]);
                m.linestatus = Utility.GetDefault<Int32>(dr[41]);
                m.assemble = Utility.GetDefault<Boolean?>(dr[42]);
                m.Createtime = Utility.GetDefault<DateTime?>(dr[43]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_productattribute 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。产品属性表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dproductattribute : DALHandlerBase8<Mproductattribute, MproductattributeCollection, Eproductattribute>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dproductattribute 类的新实例。
        /// </summary>
        public Dproductattribute() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDproductattribute 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dproductattribute(IDALHandler dbHandler) : base("t_productattribute", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MproductattributeCollection Reader(IDataReader dr)
        {
            MproductattributeCollection rows = new MproductattributeCollection();
            while (dr.Read())
            {
                Mproductattribute m = new Mproductattribute();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.productid = Utility.GetDefault<Int32?>(dr[1]);
                m.productno = Utility.GetDefault<String>(dr[2]);
                m.productsku = Utility.GetDefault<String>(dr[3]);
                m.typevalue = Utility.GetDefault<String>(dr[4]);
                m.typename = Utility.GetDefault<String>(dr[5]);
                m.productstyle = Utility.GetDefault<String>(dr[6]);
                m.productmaterial = Utility.GetDefault<String>(dr[7]);
                m.productcolorimg = Utility.GetDefault<String>(dr[8]);
                m.productcolortitle = Utility.GetDefault<String>(dr[9]);
                m.productcolorvalue = Utility.GetDefault<String>(dr[10]);
                m.productwidth = Utility.GetDefault<Decimal?>(dr[11]);
                m.productheight = Utility.GetDefault<Decimal?>(dr[12]);
                m.productlength = Utility.GetDefault<Decimal?>(dr[13]);
                m.productcbm = Utility.GetDefault<Decimal?>(dr[14]);
                m.buyprice = Utility.GetDefault<Decimal?>(dr[15]);
                m.markprice = Utility.GetDefault<Decimal?>(dr[16]);
                m.saleprice = Utility.GetDefault<Decimal?>(dr[17]);
                m.otherinfo = Utility.GetDefault<String>(dr[18]);
                m.storage = Utility.GetDefault<Int32?>(dr[19]);
                m.sort = Utility.GetDefault<Int32?>(dr[20]);
                m.isdefault = Utility.GetDefault<Int32>(dr[21]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_productcategory 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。产品分类表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dproductcategory : DALHandlerBase8<Mproductcategory, MproductcategoryCollection, Eproductcategory>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dproductcategory 类的新实例。
        /// </summary>
        public Dproductcategory() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDproductcategory 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dproductcategory(IDALHandler dbHandler) : base("t_productcategory", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MproductcategoryCollection Reader(IDataReader dr)
        {
            MproductcategoryCollection rows = new MproductcategoryCollection();
            while (dr.Read())
            {
                Mproductcategory m = new Mproductcategory();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.letter = Utility.GetDefault<String>(dr[2]);
                m.rewritetitle = Utility.GetDefault<String>(dr[3]);
                m.parentid = Utility.GetDefault<Int32?>(dr[4]);
                m.lft = Utility.GetDefault<Int32?>(dr[5]);
                m.rgt = Utility.GetDefault<Int32?>(dr[6]);
                m.lev = Utility.GetDefault<Int32?>(dr[7]);
                m.depth = Utility.GetDefault<String>(dr[8]);
                m.surface = Utility.GetDefault<String>(dr[9]);
                m.thumb = Utility.GetDefault<String>(dr[10]);
                m.bannel = Utility.GetDefault<String>(dr[11]);
                m.descript = Utility.GetDefault<String>(dr[12]);
                m.keywords = Utility.GetDefault<String>(dr[13]);
                m.template = Utility.GetDefault<String>(dr[14]);
                m.hits = Utility.GetDefault<Int32?>(dr[15]);
                m.sort = Utility.GetDefault<Int32?>(dr[16]);
                m.linestatus = Utility.GetDefault<Int32?>(dr[17]);
                m.createmid = Utility.GetDefault<Int32?>(dr[18]);
                m.lastedid = Utility.GetDefault<Int32?>(dr[19]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[20]);
                m.pagetitle = Utility.GetDefault<String>(dr[21]);
                m.description = Utility.GetDefault<String>(dr[22]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_productcon 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。产品内容表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dproductcon : DALHandlerBase8<Mproductcon, MproductconCollection, Eproductcon>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dproductcon 类的新实例。
        /// </summary>
        public Dproductcon() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDproductcon 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dproductcon(IDALHandler dbHandler) : base("t_productcon", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MproductconCollection Reader(IDataReader dr)
        {
            MproductconCollection rows = new MproductconCollection();
            while (dr.Read())
            {
                Mproductcon m = new Mproductcon();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.productid = Utility.GetDefault<Int32?>(dr[1]);
                m.contype = Utility.GetDefault<Int32?>(dr[2]);
                m.con = Utility.GetDefault<String>(dr[3]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_promotion 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。 
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dpromotion : DALHandlerBase8<Mpromotion, MpromotionCollection, Epromotion>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dpromotion 类的新实例。
        /// </summary>
        public Dpromotion() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDpromotion 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dpromotion(IDALHandler dbHandler) : base("t_promotion", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MpromotionCollection Reader(IDataReader dr)
        {
            MpromotionCollection rows = new MpromotionCollection();
            while (dr.Read())
            {
                Mpromotion m = new Mpromotion();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.htmltitle = Utility.GetDefault<String>(dr[2]);
                m.letter = Utility.GetDefault<String>(dr[3]);
                m.attribute = Utility.GetDefault<String>(dr[4]);
                m.ptype = Utility.GetDefault<Int32?>(dr[5]);
                m.startdatetime = Utility.GetDefault<DateTime?>(dr[6]);
                m.enddatetime = Utility.GetDefault<DateTime?>(dr[7]);
                m.areacode = Utility.GetDefault<String>(dr[8]);
                m.address = Utility.GetDefault<String>(dr[9]);
                m.surface = Utility.GetDefault<String>(dr[10]);
                m.logo = Utility.GetDefault<String>(dr[11]);
                m.thumb = Utility.GetDefault<String>(dr[12]);
                m.bannel = Utility.GetDefault<String>(dr[13]);
                m.desimage = Utility.GetDefault<String>(dr[14]);
                m.descript = Utility.GetDefault<String>(dr[15]);
                m.keywords = Utility.GetDefault<String>(dr[16]);
                m.template = Utility.GetDefault<String>(dr[17]);
                m.hits = Utility.GetDefault<Int32?>(dr[18]);
                m.sort = Utility.GetDefault<Int32?>(dr[19]);
                m.createmid = Utility.GetDefault<Int32?>(dr[20]);
                m.lastedid = Utility.GetDefault<Int32?>(dr[21]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[22]);
                m.auditstatus = Utility.GetDefault<Int32>(dr[23]);
                m.linestatus = Utility.GetDefault<Int32>(dr[24]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_promotionappbrand 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。促销信息品牌关联表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dpromotionappbrand : DALHandlerBase8<Mpromotionappbrand, MpromotionappbrandCollection, Epromotionappbrand>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dpromotionappbrand 类的新实例。
        /// </summary>
        public Dpromotionappbrand() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDpromotionappbrand 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dpromotionappbrand(IDALHandler dbHandler) : base("t_promotionappbrand", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MpromotionappbrandCollection Reader(IDataReader dr)
        {
            MpromotionappbrandCollection rows = new MpromotionappbrandCollection();
            while (dr.Read())
            {
                Mpromotionappbrand m = new Mpromotionappbrand();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.letter = Utility.GetDefault<String>(dr[2]);
                m.bid = Utility.GetDefault<Int32?>(dr[3]);
                m.blogo = Utility.GetDefault<String>(dr[4]);
                m.fordio = Utility.GetDefault<String>(dr[5]);
                m.appcount = Utility.GetDefault<Int32?>(dr[6]);
                m.sort = Utility.GetDefault<Int32?>(dr[7]);
                m.thumb = Utility.GetDefault<String>(dr[8]);
                m.banner = Utility.GetDefault<String>(dr[9]);
                m.htmltitle = Utility.GetDefault<String>(dr[10]);
                m.descript = Utility.GetDefault<String>(dr[11]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_promotionappproduct 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。促销信息产品关联表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dpromotionappproduct : DALHandlerBase8<Mpromotionappproduct, MpromotionappproductCollection, Epromotionappproduct>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dpromotionappproduct 类的新实例。
        /// </summary>
        public Dpromotionappproduct() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDpromotionappproduct 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dpromotionappproduct(IDALHandler dbHandler) : base("t_promotionappproduct", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MpromotionappproductCollection Reader(IDataReader dr)
        {
            MpromotionappproductCollection rows = new MpromotionappproductCollection();
            while (dr.Read())
            {
                Mpromotionappproduct m = new Mpromotionappproduct();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.mid = Utility.GetDefault<Int32?>(dr[1]);
                m.name = Utility.GetDefault<String>(dr[2]);
                m.memail = Utility.GetDefault<String>(dr[3]);
                m.mphone = Utility.GetDefault<String>(dr[4]);
                m.productid = Utility.GetDefault<Int32?>(dr[5]);
                m.productname = Utility.GetDefault<String>(dr[6]);
                m.materialid = Utility.GetDefault<Int32?>(dr[7]);
                m.materialname = Utility.GetDefault<String>(dr[8]);
                m.sizevalue = Utility.GetDefault<String>(dr[9]);
                m.brandid = Utility.GetDefault<Int32?>(dr[10]);
                m.brandname = Utility.GetDefault<String>(dr[11]);
                m.addtime = Utility.GetDefault<DateTime?>(dr[12]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_promotiondef 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。 
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dpromotiondef : DALHandlerBase8<Mpromotiondef, MpromotiondefCollection, Epromotiondef>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dpromotiondef 类的新实例。
        /// </summary>
        public Dpromotiondef() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDpromotiondef 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dpromotiondef(IDALHandler dbHandler) : base("t_promotiondef", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MpromotiondefCollection Reader(IDataReader dr)
        {
            MpromotiondefCollection rows = new MpromotiondefCollection();
            while (dr.Read())
            {
                Mpromotiondef m = new Mpromotiondef();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.pid = Utility.GetDefault<Int32>(dr[2]);
                m.attribute = Utility.GetDefault<String>(dr[3]);
                m.type = Utility.GetDefault<String>(dr[4]);
                m.value = Utility.GetDefault<String>(dr[5]);
                m.valueletter = Utility.GetDefault<String>(dr[6]);
                m.valuetitle = Utility.GetDefault<String>(dr[7]);
                m.thumb = Utility.GetDefault<String>(dr[8]);
                m.banner = Utility.GetDefault<String>(dr[9]);
                m.descript = Utility.GetDefault<String>(dr[10]);
                m.curcountmoney = Utility.GetDefault<String>(dr[11]);
                m.curcountpeople = Utility.GetDefault<String>(dr[12]);
                m.curstage = Utility.GetDefault<String>(dr[13]);
                m.fordio = Utility.GetDefault<String>(dr[14]);
                m.sort = Utility.GetDefault<Int32?>(dr[15]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_promotions 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。促销信息表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dpromotions : DALHandlerBase8<Mpromotions, MpromotionsCollection, Epromotions>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dpromotions 类的新实例。
        /// </summary>
        public Dpromotions() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDpromotions 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dpromotions(IDALHandler dbHandler) : base("t_promotions", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MpromotionsCollection Reader(IDataReader dr)
        {
            MpromotionsCollection rows = new MpromotionsCollection();
            while (dr.Read())
            {
                Mpromotions m = new Mpromotions();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.mid = Utility.GetDefault<Int32>(dr[1]);
                m.membertype = Utility.GetDefault<Int32>(dr[2]);
                m.title = Utility.GetDefault<String>(dr[3]);
                m.htmltitle = Utility.GetDefault<String>(dr[4]);
                m.letter = Utility.GetDefault<String>(dr[5]);
                m.attribute = Utility.GetDefault<String>(dr[6]);
                m.startdatetime = Utility.GetDefault<DateTime>(dr[7]);
                m.enddatetime = Utility.GetDefault<DateTime>(dr[8]);
                m.surface = Utility.GetDefault<String>(dr[9]);
                m.logo = Utility.GetDefault<String>(dr[10]);
                m.thumb = Utility.GetDefault<String>(dr[11]);
                m.bannel = Utility.GetDefault<String>(dr[12]);
                m.desimage = Utility.GetDefault<String>(dr[13]);
                m.descript = Utility.GetDefault<String>(dr[14]);
                m.keywords = Utility.GetDefault<String>(dr[15]);
                m.template = Utility.GetDefault<String>(dr[16]);
                m.hits = Utility.GetDefault<Int32?>(dr[17]);
                m.sort = Utility.GetDefault<Int32?>(dr[18]);
                m.adminid = Utility.GetDefault<Int32>(dr[19]);
                m.lastedadminid = Utility.GetDefault<Int32>(dr[20]);
                m.lastedadmintime = Utility.GetDefault<DateTime>(dr[21]);
                m.lastedmid = Utility.GetDefault<Int32>(dr[22]);
                m.lastedmtime = Utility.GetDefault<DateTime>(dr[23]);
                m.auditstatus = Utility.GetDefault<Int32>(dr[24]);
                m.linestatus = Utility.GetDefault<Int32>(dr[25]);
                m.IsTop = Utility.GetDefault<Boolean>(dr[26]);
                m.IsRecommend = Utility.GetDefault<Boolean>(dr[27]);
                m.IsHot = Utility.GetDefault<Boolean>(dr[28]);
                m.IsEssence = Utility.GetDefault<Boolean>(dr[29]);
                m.IsSlide = Utility.GetDefault<Boolean>(dr[30]);
                m.IsHighlight = Utility.GetDefault<Boolean>(dr[31]);
                m.createtime = Utility.GetDefault<DateTime>(dr[32]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_promotionsrelated 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。促销信息关系表（店铺，卖场根据会员与会员类型决定）
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dpromotionsrelated : DALHandlerBase8<Mpromotionsrelated, MpromotionsrelatedCollection, Epromotionsrelated>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dpromotionsrelated 类的新实例。
        /// </summary>
        public Dpromotionsrelated() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDpromotionsrelated 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dpromotionsrelated(IDALHandler dbHandler) : base("t_promotionsrelated", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MpromotionsrelatedCollection Reader(IDataReader dr)
        {
            MpromotionsrelatedCollection rows = new MpromotionsrelatedCollection();
            while (dr.Read())
            {
                Mpromotionsrelated m = new Mpromotionsrelated();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.mid = Utility.GetDefault<Int32>(dr[1]);
                m.membertype = Utility.GetDefault<Int32>(dr[2]);
                m.promotionsid = Utility.GetDefault<Int32>(dr[3]);
                m.promotionstitle = Utility.GetDefault<String>(dr[4]);
                m.shopid = Utility.GetDefault<Int32>(dr[5]);
                m.shoptitle = Utility.GetDefault<String>(dr[6]);
                m.shopareacode = Utility.GetDefault<String>(dr[7]);
                m.shopaddress = Utility.GetDefault<String>(dr[8]);
                m.marketid = Utility.GetDefault<Int32>(dr[9]);
                m.markettitle = Utility.GetDefault<String>(dr[10]);
                m.marketareacode = Utility.GetDefault<String>(dr[11]);
                m.marketaddress = Utility.GetDefault<String>(dr[12]);
                m.marketstoreyid = Utility.GetDefault<Int32>(dr[13]);
                m.createtime = Utility.GetDefault<DateTime>(dr[14]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_promotionstage 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。 
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dpromotionstage : DALHandlerBase8<Mpromotionstage, MpromotionstageCollection, Epromotionstage>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dpromotionstage 类的新实例。
        /// </summary>
        public Dpromotionstage() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDpromotionstage 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dpromotionstage(IDALHandler dbHandler) : base("t_promotionstage", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MpromotionstageCollection Reader(IDataReader dr)
        {
            MpromotionstageCollection rows = new MpromotionstageCollection();
            while (dr.Read())
            {
                Mpromotionstage m = new Mpromotionstage();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.pid = Utility.GetDefault<Int32>(dr[2]);
                m.did = Utility.GetDefault<Int32>(dr[3]);
                m.stype = Utility.GetDefault<Int32>(dr[4]);
                m.smodle = Utility.GetDefault<Int32>(dr[5]);
                m.svaluemin = Utility.GetDefault<String>(dr[6]);
                m.svaluemax = Utility.GetDefault<String>(dr[7]);
                m.pmodule = Utility.GetDefault<Int32?>(dr[8]);
                m.prolue = Utility.GetDefault<String>(dr[9]);
                m.pvalue = Utility.GetDefault<String>(dr[10]);
                m.sort = Utility.GetDefault<Int32?>(dr[11]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_shop 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。店铺表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dshop : DALHandlerBase8<Mshop, MshopCollection, Eshop>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dshop 类的新实例。
        /// </summary>
        public Dshop() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDshop 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dshop(IDALHandler dbHandler) : base("t_shop", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MshopCollection Reader(IDataReader dr)
        {
            MshopCollection rows = new MshopCollection();
            while (dr.Read())
            {
                Mshop m = new Mshop();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.mid = Utility.GetDefault<Int32>(dr[1]);
                m.title = Utility.GetDefault<String>(dr[2]);
                m.letter = Utility.GetDefault<String>(dr[3]);
                m.groupid = Utility.GetDefault<Int32>(dr[4]);
                m.attribute = Utility.GetDefault<String>(dr[5]);
                m.industry = Utility.GetDefault<String>(dr[6]);
                m.productcategory = Utility.GetDefault<String>(dr[7]);
                m.vip = Utility.GetDefault<Int32?>(dr[8]);
                m.areacode = Utility.GetDefault<String>(dr[9]);
                m.address = Utility.GetDefault<String>(dr[10]);
                m.mapapi = Utility.GetDefault<String>(dr[11]);
                m.staffsize = Utility.GetDefault<Int32?>(dr[12]);
                m.regyear = Utility.GetDefault<String>(dr[13]);
                m.regcity = Utility.GetDefault<String>(dr[14]);
                m.buy = Utility.GetDefault<String>(dr[15]);
                m.sell = Utility.GetDefault<String>(dr[16]);
                m.linkman = Utility.GetDefault<String>(dr[17]);
                m.phone = Utility.GetDefault<String>(dr[18]);
                m.mphone = Utility.GetDefault<String>(dr[19]);
                m.fax = Utility.GetDefault<String>(dr[20]);
                m.email = Utility.GetDefault<String>(dr[21]);
                m.postcode = Utility.GetDefault<String>(dr[22]);
                m.homepage = Utility.GetDefault<String>(dr[23]);
                m.domain = Utility.GetDefault<String>(dr[24]);
                m.domainip = Utility.GetDefault<String>(dr[25]);
                m.icp = Utility.GetDefault<String>(dr[26]);
                m.surface = Utility.GetDefault<String>(dr[27]);
                m.logo = Utility.GetDefault<String>(dr[28]);
                m.thumb = Utility.GetDefault<String>(dr[29]);
                m.bannel = Utility.GetDefault<String>(dr[30]);
                m.desimage = Utility.GetDefault<String>(dr[31]);
                m.descript = Utility.GetDefault<String>(dr[32]);
                m.keywords = Utility.GetDefault<String>(dr[33]);
                m.template = Utility.GetDefault<String>(dr[34]);
                m.hits = Utility.GetDefault<Int32?>(dr[35]);
                m.sort = Utility.GetDefault<Int32?>(dr[36]);
                m.marketid = Utility.GetDefault<Int32?>(dr[37]);
                m.cid = Utility.GetDefault<Int32?>(dr[38]);
                m.ctype = Utility.GetDefault<Int32?>(dr[39]);
                m.createmid = Utility.GetDefault<Int32?>(dr[40]);
                m.lastedid = Utility.GetDefault<Int32?>(dr[41]);
                m.lastedittime = Utility.GetDefault<DateTime>(dr[42]);
                m.auditstatus = Utility.GetDefault<Int32>(dr[43]);
                m.linestatus = Utility.GetDefault<Int32>(dr[44]);
                m.qq = Utility.GetDefault<String>(dr[45]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_shopbrand 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。店铺品牌关联表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dshopbrand : DALHandlerBase8<Mshopbrand, MshopbrandCollection, Eshopbrand>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dshopbrand 类的新实例。
        /// </summary>
        public Dshopbrand() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDshopbrand 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dshopbrand(IDALHandler dbHandler) : base("t_shopbrand", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MshopbrandCollection Reader(IDataReader dr)
        {
            MshopbrandCollection rows = new MshopbrandCollection();
            while (dr.Read())
            {
                Mshopbrand m = new Mshopbrand();
                m.shopid = Utility.GetDefault<Int32>(dr[0]);
                m.brandid = Utility.GetDefault<Int32>(dr[1]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_shopgroup 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。店铺组表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dshopgroup : DALHandlerBase8<Mshopgroup, MshopgroupCollection, Eshopgroup>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dshopgroup 类的新实例。
        /// </summary>
        public Dshopgroup() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDshopgroup 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dshopgroup(IDALHandler dbHandler) : base("t_shopgroup", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MshopgroupCollection Reader(IDataReader dr)
        {
            MshopgroupCollection rows = new MshopgroupCollection();
            while (dr.Read())
            {
                Mshopgroup m = new Mshopgroup();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.color = Utility.GetDefault<String>(dr[2]);
                m.avatar = Utility.GetDefault<String>(dr[3]);
                m.integral = Utility.GetDefault<Decimal?>(dr[4]);
                m.money = Utility.GetDefault<Decimal?>(dr[5]);
                m.adcount = Utility.GetDefault<Int32?>(dr[6]);
                m.marketpcount = Utility.GetDefault<Int32?>(dr[7]);
                m.brandcount = Utility.GetDefault<Int32?>(dr[8]);
                m.promotioncount = Utility.GetDefault<Int32?>(dr[9]);
                m.productcount = Utility.GetDefault<Int32?>(dr[10]);
                m.adrecommend = Utility.GetDefault<Int32?>(dr[11]);
                m.marketrecommend = Utility.GetDefault<Int32?>(dr[12]);
                m.brandrecommend = Utility.GetDefault<Int32?>(dr[13]);
                m.promotionrecommend = Utility.GetDefault<Int32?>(dr[14]);
                m.productrecommend = Utility.GetDefault<Int32?>(dr[15]);
                m.permissions = Utility.GetDefault<String>(dr[16]);
                m.lev = Utility.GetDefault<Int32?>(dr[17]);
                m.descript = Utility.GetDefault<String>(dr[18]);
                m.sort = Utility.GetDefault<Int32?>(dr[19]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_shopproductprice 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。产品产品价格表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dshopproductprice : DALHandlerBase8<Mshopproductprice, MshopproductpriceCollection, Eshopproductprice>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dshopproductprice 类的新实例。
        /// </summary>
        public Dshopproductprice() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDshopproductprice 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dshopproductprice(IDALHandler dbHandler) : base("t_shopproductprice", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override MshopproductpriceCollection Reader(IDataReader dr)
        {
            MshopproductpriceCollection rows = new MshopproductpriceCollection();
            while (dr.Read())
            {
                Mshopproductprice m = new Mshopproductprice();
                m.shopid = Utility.GetDefault<Int32?>(dr[0]);
                m.productid = Utility.GetDefault<Int32?>(dr[1]);
                m.attributeid = Utility.GetDefault<Int32?>(dr[2]);
                m.saleprice = Utility.GetDefault<Decimal>(dr[3]);
                m.buyprice = Utility.GetDefault<Decimal>(dr[4]);
                m.markprice = Utility.GetDefault<Decimal>(dr[5]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_sys_action 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。动作(权限)表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dsys_action : DALHandlerBase8<Msys_action, Msys_actionCollection, Esys_action>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dsys_action 类的新实例。
        /// </summary>
        public Dsys_action() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDsys_action 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dsys_action(IDALHandler dbHandler) : base("t_sys_action", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override Msys_actionCollection Reader(IDataReader dr)
        {
            Msys_actionCollection rows = new Msys_actionCollection();
            while (dr.Read())
            {
                Msys_action m = new Msys_action();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.mark = Utility.GetDefault<String>(dr[2]);
                m.mid = Utility.GetDefault<Int32?>(dr[3]);
                m.actype = Utility.GetDefault<Int32?>(dr[4]);
                m.descript = Utility.GetDefault<String>(dr[5]);
                m.sort = Utility.GetDefault<Int32?>(dr[6]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_sys_module 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。所块表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dsys_module : DALHandlerBase8<Msys_module, Msys_moduleCollection, Esys_module>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dsys_module 类的新实例。
        /// </summary>
        public Dsys_module() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDsys_module 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dsys_module(IDALHandler dbHandler) : base("t_sys_module", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override Msys_moduleCollection Reader(IDataReader dr)
        {
            Msys_moduleCollection rows = new Msys_moduleCollection();
            while (dr.Read())
            {
                Msys_module m = new Msys_module();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.mark = Utility.GetDefault<String>(dr[2]);
                m.descript = Utility.GetDefault<String>(dr[3]);
                m.type = Utility.GetDefault<String>(dr[4]);
                m.sort = Utility.GetDefault<Int32?>(dr[5]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_sys_module_link 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。所块链接表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dsys_module_link : DALHandlerBase8<Msys_module_link, Msys_module_linkCollection, Esys_module_link>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dsys_module_link 类的新实例。
        /// </summary>
        public Dsys_module_link() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDsys_module_link 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dsys_module_link(IDALHandler dbHandler) : base("t_sys_module_link", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override Msys_module_linkCollection Reader(IDataReader dr)
        {
            Msys_module_linkCollection rows = new Msys_module_linkCollection();
            while (dr.Read())
            {
                Msys_module_link m = new Msys_module_link();
                m.mid = Utility.GetDefault<Int32>(dr[0]);
                m.title = Utility.GetDefault<String>(dr[1]);
                m.icourl = Utility.GetDefault<String>(dr[2]);
                m.linkurl = Utility.GetDefault<String>(dr[3]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_sys_role 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。角色表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dsys_role : DALHandlerBase8<Msys_role, Msys_roleCollection, Esys_role>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dsys_role 类的新实例。
        /// </summary>
        public Dsys_role() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDsys_role 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dsys_role(IDALHandler dbHandler) : base("t_sys_role", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override Msys_roleCollection Reader(IDataReader dr)
        {
            Msys_roleCollection rows = new Msys_roleCollection();
            while (dr.Read())
            {
                Msys_role m = new Msys_role();
                m.id = Utility.GetDefault<Int32>(dr[0]);
                m.parentid = Utility.GetDefault<Int32>(dr[1]);
                m.title = Utility.GetDefault<String>(dr[2]);
                m.mark = Utility.GetDefault<String>(dr[3]);
                m.descript = Utility.GetDefault<String>(dr[4]);
                m.sort = Utility.GetDefault<Int32?>(dr[5]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    /// <summary>
    /// 操作 t_sys_roleactiondef 表的类，集成了SELECT、INSERT、DELETE、UPDATE功能。
    /// 此代码由机器程序生成。角色权限关联表
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Dsys_roleactiondef : DALHandlerBase8<Msys_roleactiondef, Msys_roleactiondefCollection, Esys_roleactiondef>
    {
        /// <summary>
        /// 初始化 HaojiBiz.Model.Dsys_roleactiondef 类的新实例。
        /// </summary>
        public Dsys_roleactiondef() : this(null) {  }
        /// <summary>
        /// 初始化 HaojiBiz.ModelDsys_roleactiondef 类的新实例，并绑定此对象的数据库操作句柄。
        /// </summary>
        /// <param name="dbHandler">数据库操作句柄，此对象可以是其它的 Haojibiz.Data.DALHandlerBase8&lt;T1, T2, T3&gt; 派生类（即以“D”字母开头的数据库操作类），或者为 null 时使用它自身实现的 IDALHandler 。</param>
        public Dsys_roleactiondef(IDALHandler dbHandler) : base("t_sys_roleactiondef", dbHandler) { }
        ///<summary>
        /// 把 IDataReader 结果集的值读出，并赋值给同名的表实体类字段
        /// </summary>
        /// <param name="dr">IDataReader 阅读器对象实例</param>
        /// <returns></returns>
        protected override Msys_roleactiondefCollection Reader(IDataReader dr)
        {
            Msys_roleactiondefCollection rows = new Msys_roleactiondefCollection();
            while (dr.Read())
            {
                Msys_roleactiondef m = new Msys_roleactiondef();
                m.actionid = Utility.GetDefault<Int32>(dr[0]);
                m.moduleid = Utility.GetDefault<Int32>(dr[1]);
                m.roleid = Utility.GetDefault<Int32>(dr[2]);
                rows.Add(m);
            }
            if (!dr.IsClosed)
                dr.Close();
            return rows;
        }
    }
    #endregion
}