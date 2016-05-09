namespace Haojibiz.DAL {
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Collections.Generic;
    using System.Reflection;
    using System.ComponentModel;
    using Haojibiz.Model;
    
    
    /// <summary>
    /// 使用 Linq 操作 SQL Server 数据库的上下文对象，数据库查询、插入、删除、更新及事务控制等均在此类完成。
    /// </summary>
    [Database(Name="TREC")]
    public partial class LinqDataContext : DataContext {
        
        #region 静态私有字段
        private static MappingSource mappingSource = new AttributeMappingSource();
        #endregion
        
        /// <summary>
        /// 当类初始化新实例时（即构造函数）调用此方法，请在自定义的类中实现此分部方法，或留空不作任何处理。
        /// </summary>
        partial void OnCreated();
        
        /// <summary>
        /// 初始化 Linq 数据库操作类的新实例。
        /// </summary>
        public LinqDataContext() : 
                base(Haojibiz.Data.SqlHelper.NewConnection, mappingSource) {
            this.OnCreated();
        }
        
        /// <summary>
        /// 初始化 Linq 数据库操作类的新实例。
        /// </summary>
        public LinqDataContext(System.Data.IDbConnection connection) : 
                base(connection, mappingSource) {
            this.OnCreated();
        }
        
        /// <summary>
        /// 初始化 Linq 数据库操作类的新实例。
        /// </summary>
        public LinqDataContext(System.Data.Common.DbTransaction transaction) : 
                base(transaction.Connection, mappingSource) {
            this.Transaction = transaction;
            this.OnCreated();
        }
        
        /// <summary>
        /// 管理员
        /// </summary>
        public Table<Madmin> admin {
            get {
                return this.GetTable<Madmin>();
            }
        }
        
        /// <summary>
        /// 广告表
        /// </summary>
        public Table<Madvertising> advertising {
            get {
                return this.GetTable<Madvertising>();
            }
        }
        
        /// <summary>
        /// 广告分类
        /// </summary>
        public Table<Madvertisingcategory> advertisingcategory {
            get {
                return this.GetTable<Madvertisingcategory>();
            }
        }
        
        /// <summary>
        /// 聚合信息
        /// </summary>
        public Table<Maggregation> aggregation {
            get {
                return this.GetTable<Maggregation>();
            }
        }
        
        /// <summary>
        /// 信息所属模块
        /// </summary>
        public Table<Maggregationtype> aggregationtype {
            get {
                return this.GetTable<Maggregationtype>();
            }
        }
        
        /// <summary>
        /// 经销商、店铺品牌使用申请表
        /// </summary>
        public Table<Mappbrand> appbrand {
            get {
                return this.GetTable<Mappbrand>();
            }
        }
        
        /// <summary>
        ///  
        /// </summary>
        public Table<Mappbrandcustomer> appbrandcustomer {
            get {
                return this.GetTable<Mappbrandcustomer>();
            }
        }
        
        /// <summary>
        /// 地区表
        /// </summary>
        public Table<Marea> area {
            get {
                return this.GetTable<Marea>();
            }
        }
        
        /// <summary>
        /// 文章表
        /// </summary>
        public Table<Marticle> article {
            get {
                return this.GetTable<Marticle>();
            }
        }
        
        /// <summary>
        ///  
        /// </summary>
        public Table<Marticle_data> article_data {
            get {
                return this.GetTable<Marticle_data>();
            }
        }
        
        /// <summary>
        ///  
        /// </summary>
        public Table<Marticle_node> article_node {
            get {
                return this.GetTable<Marticle_node>();
            }
        }
        
        /// <summary>
        /// 品牌表
        /// </summary>
        public Table<Mbrand> brand {
            get {
                return this.GetTable<Mbrand>();
            }
        }
        
        /// <summary>
        /// 品牌系列表
        /// </summary>
        public Table<Mbrands> brands {
            get {
                return this.GetTable<Mbrands>();
            }
        }
        
        /// <summary>
        /// 厂家表
        /// </summary>
        public Table<Mcompany> company {
            get {
                return this.GetTable<Mcompany>();
            }
        }
        
        /// <summary>
        /// 厂家组表
        /// </summary>
        public Table<Mcompanygroup> companygroup {
            get {
                return this.GetTable<Mcompanygroup>();
            }
        }
        
        /// <summary>
        /// 配置表
        /// </summary>
        public Table<Mconfig> config {
            get {
                return this.GetTable<Mconfig>();
            }
        }
        
        /// <summary>
        /// 配置类型表
        /// </summary>
        public Table<Mconfigtype> configtype {
            get {
                return this.GetTable<Mconfigtype>();
            }
        }
        
        /// <summary>
        /// 经销商
        /// </summary>
        public Table<Mdealer> dealer {
            get {
                return this.GetTable<Mdealer>();
            }
        }
        
        /// <summary>
        /// 经销商组表
        /// </summary>
        public Table<Mdealergroup> dealergroup {
            get {
                return this.GetTable<Mdealergroup>();
            }
        }
        
        /// <summary>
        ///  
        /// </summary>
        public Table<Mgrouporder> grouporder {
            get {
                return this.GetTable<Mgrouporder>();
            }
        }
        
        /// <summary>
        ///  
        /// </summary>
        public Table<Mgrouporderpay> grouporderpay {
            get {
                return this.GetTable<Mgrouporderpay>();
            }
        }
        
        /// <summary>
        ///  
        /// </summary>
        public Table<Mgrouporderproduct> grouporderproduct {
            get {
                return this.GetTable<Mgrouporderproduct>();
            }
        }
        
        /// <summary>
        /// 日志表
        /// </summary>
        public Table<Mlog> log {
            get {
                return this.GetTable<Mlog>();
            }
        }
        
        /// <summary>
        /// 卖场表
        /// </summary>
        public Table<Mmarket> market {
            get {
                return this.GetTable<Mmarket>();
            }
        }
        
        /// <summary>
        /// 卖场组表
        /// </summary>
        public Table<Mmarketgroup> marketgroup {
            get {
                return this.GetTable<Mmarketgroup>();
            }
        }
        
        /// <summary>
        /// 卖场楼层表
        /// </summary>
        public Table<Mmarketstorey> marketstorey {
            get {
                return this.GetTable<Mmarketstorey>();
            }
        }
        
        /// <summary>
        /// 卖场楼层店铺
        /// </summary>
        public Table<Mmarketstoreyshop> marketstoreyshop {
            get {
                return this.GetTable<Mmarketstoreyshop>();
            }
        }
        
        /// <summary>
        /// 会员表
        /// </summary>
        public Table<Mmember> member {
            get {
                return this.GetTable<Mmember>();
            }
        }
        
        /// <summary>
        /// 会员组表
        /// </summary>
        public Table<Mmembergroup> membergroup {
            get {
                return this.GetTable<Mmembergroup>();
            }
        }
        
        /// <summary>
        /// 菜单表
        /// </summary>
        public Table<Mmenu> menu {
            get {
                return this.GetTable<Mmenu>();
            }
        }
        
        /// <summary>
        /// 新闻信息表
        /// </summary>
        public Table<Mnews> news {
            get {
                return this.GetTable<Mnews>();
            }
        }
        
        /// <summary>
        /// 支付表
        /// </summary>
        public Table<MPayMent> PayMent {
            get {
                return this.GetTable<MPayMent>();
            }
        }
        
        /// <summary>
        /// 支付日志表
        /// </summary>
        public Table<MPayMentLog> PayMentLog {
            get {
                return this.GetTable<MPayMentLog>();
            }
        }
        
        /// <summary>
        /// 产品分类与产品类型关联表
        /// </summary>
        public Table<Mpcategoryptypedef> pcategoryptypedef {
            get {
                return this.GetTable<Mpcategoryptypedef>();
            }
        }
        
        /// <summary>
        /// 产品表
        /// </summary>
        public Table<Mproduct> product {
            get {
                return this.GetTable<Mproduct>();
            }
        }
        
        /// <summary>
        /// 产品属性表
        /// </summary>
        public Table<Mproductattribute> productattribute {
            get {
                return this.GetTable<Mproductattribute>();
            }
        }
        
        /// <summary>
        /// 产品分类表
        /// </summary>
        public Table<Mproductcategory> productcategory {
            get {
                return this.GetTable<Mproductcategory>();
            }
        }
        
        /// <summary>
        /// 产品内容表
        /// </summary>
        public Table<Mproductcon> productcon {
            get {
                return this.GetTable<Mproductcon>();
            }
        }
        
        /// <summary>
        ///  
        /// </summary>
        public Table<Mpromotion> promotion {
            get {
                return this.GetTable<Mpromotion>();
            }
        }
        
        /// <summary>
        /// 促销信息品牌关联表
        /// </summary>
        public Table<Mpromotionappbrand> promotionappbrand {
            get {
                return this.GetTable<Mpromotionappbrand>();
            }
        }
        
        /// <summary>
        /// 促销信息产品关联表
        /// </summary>
        public Table<Mpromotionappproduct> promotionappproduct {
            get {
                return this.GetTable<Mpromotionappproduct>();
            }
        }
        
        /// <summary>
        ///  
        /// </summary>
        public Table<Mpromotiondef> promotiondef {
            get {
                return this.GetTable<Mpromotiondef>();
            }
        }
        
        /// <summary>
        /// 促销信息表
        /// </summary>
        public Table<Mpromotions> promotions {
            get {
                return this.GetTable<Mpromotions>();
            }
        }
        
        /// <summary>
        /// 促销信息关系表（店铺，卖场根据会员与会员类型决定）
        /// </summary>
        public Table<Mpromotionsrelated> promotionsrelated {
            get {
                return this.GetTable<Mpromotionsrelated>();
            }
        }
        
        /// <summary>
        ///  
        /// </summary>
        public Table<Mpromotionstage> promotionstage {
            get {
                return this.GetTable<Mpromotionstage>();
            }
        }
        
        /// <summary>
        /// 店铺表
        /// </summary>
        public Table<Mshop> shop {
            get {
                return this.GetTable<Mshop>();
            }
        }
        
        /// <summary>
        /// 店铺品牌关联表
        /// </summary>
        public Table<Mshopbrand> shopbrand {
            get {
                return this.GetTable<Mshopbrand>();
            }
        }
        
        /// <summary>
        /// 店铺组表
        /// </summary>
        public Table<Mshopgroup> shopgroup {
            get {
                return this.GetTable<Mshopgroup>();
            }
        }
        
        /// <summary>
        /// 产品产品价格表
        /// </summary>
        public Table<Mshopproductprice> shopproductprice {
            get {
                return this.GetTable<Mshopproductprice>();
            }
        }
        
        /// <summary>
        /// 动作(权限)表
        /// </summary>
        public Table<Msys_action> sys_action {
            get {
                return this.GetTable<Msys_action>();
            }
        }
        
        /// <summary>
        /// 所块表
        /// </summary>
        public Table<Msys_module> sys_module {
            get {
                return this.GetTable<Msys_module>();
            }
        }
        
        /// <summary>
        /// 所块链接表
        /// </summary>
        public Table<Msys_module_link> sys_module_link {
            get {
                return this.GetTable<Msys_module_link>();
            }
        }
        
        /// <summary>
        /// 角色表
        /// </summary>
        public Table<Msys_role> sys_role {
            get {
                return this.GetTable<Msys_role>();
            }
        }
        
        /// <summary>
        /// 角色权限关联表
        /// </summary>
        public Table<Msys_roleactiondef> sys_roleactiondef {
            get {
                return this.GetTable<Msys_roleactiondef>();
            }
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 NewID()，以生成一个 Guid 随机数。
        /// </summary>
        [Function(Name="NEWID", IsComposable=true)]
        public virtual Guid FunctionNewID() {
            return ((Guid)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 GetTime()，以获取当前系统日期和时间。
        /// </summary>
        [Function(Name="GETTIME", IsComposable=true)]
        public virtual DateTime FunctionGetTime() {
            return ((DateTime)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Sum()，以统计字段数值总和。
        /// </summary>
        [Function(Name="SUM", IsComposable=true)]
        public virtual Byte? FunctionSum(byte arg) {
            return ((Byte?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Min()，以计算字段中的最小值。
        /// </summary>
        [Function(Name="MIN", IsComposable=true)]
        public virtual Byte? FunctionMin(byte arg) {
            return ((Byte?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Max()，以计算字段中的最大值。
        /// </summary>
        [Function(Name="MAX", IsComposable=true)]
        public virtual Byte? FunctionMax(byte arg) {
            return ((Byte?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Sum()，以统计字段数值总和。
        /// </summary>
        [Function(Name="SUM", IsComposable=true)]
        public virtual Int16? FunctionSum(short arg) {
            return ((Int16?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Min()，以计算字段中的最小值。
        /// </summary>
        [Function(Name="MIN", IsComposable=true)]
        public virtual Int16? FunctionMin(short arg) {
            return ((Int16?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Max()，以计算字段中的最大值。
        /// </summary>
        [Function(Name="MAX", IsComposable=true)]
        public virtual Int16? FunctionMax(short arg) {
            return ((Int16?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Sum()，以统计字段数值总和。
        /// </summary>
        [Function(Name="SUM", IsComposable=true)]
        public virtual Int32? FunctionSum(int arg) {
            return ((Int32?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Min()，以计算字段中的最小值。
        /// </summary>
        [Function(Name="MIN", IsComposable=true)]
        public virtual Int32? FunctionMin(int arg) {
            return ((Int32?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Max()，以计算字段中的最大值。
        /// </summary>
        [Function(Name="MAX", IsComposable=true)]
        public virtual Int32? FunctionMax(int arg) {
            return ((Int32?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Sum()，以统计字段数值总和。
        /// </summary>
        [Function(Name="SUM", IsComposable=true)]
        public virtual Int64? FunctionSum(long arg) {
            return ((Int64?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Min()，以计算字段中的最小值。
        /// </summary>
        [Function(Name="MIN", IsComposable=true)]
        public virtual Int64? FunctionMin(long arg) {
            return ((Int64?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Max()，以计算字段中的最大值。
        /// </summary>
        [Function(Name="MAX", IsComposable=true)]
        public virtual Int64? FunctionMax(long arg) {
            return ((Int64?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Sum()，以统计字段数值总和。
        /// </summary>
        [Function(Name="SUM", IsComposable=true)]
        public virtual SByte? FunctionSum(sbyte arg) {
            return ((SByte?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Min()，以计算字段中的最小值。
        /// </summary>
        [Function(Name="MIN", IsComposable=true)]
        public virtual SByte? FunctionMin(sbyte arg) {
            return ((SByte?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Max()，以计算字段中的最大值。
        /// </summary>
        [Function(Name="MAX", IsComposable=true)]
        public virtual SByte? FunctionMax(sbyte arg) {
            return ((SByte?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Sum()，以统计字段数值总和。
        /// </summary>
        [Function(Name="SUM", IsComposable=true)]
        public virtual UInt16? FunctionSum(ushort arg) {
            return ((UInt16?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Min()，以计算字段中的最小值。
        /// </summary>
        [Function(Name="MIN", IsComposable=true)]
        public virtual UInt16? FunctionMin(ushort arg) {
            return ((UInt16?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Max()，以计算字段中的最大值。
        /// </summary>
        [Function(Name="MAX", IsComposable=true)]
        public virtual UInt16? FunctionMax(ushort arg) {
            return ((UInt16?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Sum()，以统计字段数值总和。
        /// </summary>
        [Function(Name="SUM", IsComposable=true)]
        public virtual UInt32? FunctionSum(uint arg) {
            return ((UInt32?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Min()，以计算字段中的最小值。
        /// </summary>
        [Function(Name="MIN", IsComposable=true)]
        public virtual UInt32? FunctionMin(uint arg) {
            return ((UInt32?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Max()，以计算字段中的最大值。
        /// </summary>
        [Function(Name="MAX", IsComposable=true)]
        public virtual UInt32? FunctionMax(uint arg) {
            return ((UInt32?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Sum()，以统计字段数值总和。
        /// </summary>
        [Function(Name="SUM", IsComposable=true)]
        public virtual UInt64? FunctionSum(ulong arg) {
            return ((UInt64?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Min()，以计算字段中的最小值。
        /// </summary>
        [Function(Name="MIN", IsComposable=true)]
        public virtual UInt64? FunctionMin(ulong arg) {
            return ((UInt64?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Max()，以计算字段中的最大值。
        /// </summary>
        [Function(Name="MAX", IsComposable=true)]
        public virtual UInt64? FunctionMax(ulong arg) {
            return ((UInt64?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Sum()，以统计字段数值总和。
        /// </summary>
        [Function(Name="SUM", IsComposable=true)]
        public virtual Single? FunctionSum(float arg) {
            return ((Single?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Min()，以计算字段中的最小值。
        /// </summary>
        [Function(Name="MIN", IsComposable=true)]
        public virtual Single? FunctionMin(float arg) {
            return ((Single?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Max()，以计算字段中的最大值。
        /// </summary>
        [Function(Name="MAX", IsComposable=true)]
        public virtual Single? FunctionMax(float arg) {
            return ((Single?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Sum()，以统计字段数值总和。
        /// </summary>
        [Function(Name="SUM", IsComposable=true)]
        public virtual Double? FunctionSum(double arg) {
            return ((Double?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Min()，以计算字段中的最小值。
        /// </summary>
        [Function(Name="MIN", IsComposable=true)]
        public virtual Double? FunctionMin(double arg) {
            return ((Double?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Max()，以计算字段中的最大值。
        /// </summary>
        [Function(Name="MAX", IsComposable=true)]
        public virtual Double? FunctionMax(double arg) {
            return ((Double?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Sum()，以统计字段数值总和。
        /// </summary>
        [Function(Name="SUM", IsComposable=true)]
        public virtual Decimal? FunctionSum(decimal arg) {
            return ((Decimal?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Min()，以计算字段中的最小值。
        /// </summary>
        [Function(Name="MIN", IsComposable=true)]
        public virtual Decimal? FunctionMin(decimal arg) {
            return ((Decimal?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Max()，以计算字段中的最大值。
        /// </summary>
        [Function(Name="MAX", IsComposable=true)]
        public virtual Decimal? FunctionMax(decimal arg) {
            return ((Decimal?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Count()，以计算表中的行数。
        /// </summary>
        [Function(Name="COUNT", IsComposable=true)]
        public virtual int FunctionCount(int arg) {
            return ((int)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
        
        /// <summary>
        /// 获取一个映射 SQL Server 中系统函数 Count_Big()，以计算表中的行数。
        /// </summary>
        [Function(Name="COUNT_BIG", IsComposable=true)]
        public virtual long FunctionCount(long arg) {
            return ((long)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arg).ReturnValue));
        }
    }
}
