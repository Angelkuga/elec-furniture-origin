using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TREC.Entity;
using TRECommon;
using System.Data.Common;



namespace TREC.Data
{
    /// <summary>
    /// 产品数据访问类
    /// </summary>
    public class ProductDb
    {

        /// <summary>
        /// 调整产品价格
        /// </summary>
        /// <param name="brandId">品牌id</param>
        /// <param name="seriesId">系列id</param>
        /// <param name="shopId">店铺id</param>
        /// <param name="pricetype">调整类型（1表示根据市场价调整销售价；0表示根据销售价调整市场价）</param>
        /// <param name="pp">百分比</param>
        /// <param name="userName">会员名</param>
        /// <returns></returns>
        public static bool SetProductPrice(int brandId, int seriesId, int shopId, int pricetype, int pp, string Userid)
        {
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@brandId",SqlDbType.Int,4),
                new SqlParameter("@seriesId",SqlDbType.Int,4),
                new SqlParameter("@shopId",SqlDbType.Int,4),
                new SqlParameter("@pricetype",SqlDbType.Int,4),
                new SqlParameter("@pp",SqlDbType.Int,4),
                new SqlParameter("@userId",SqlDbType.VarChar,50)
            };
            Parameter[0].Value = brandId;
            Parameter[1].Value = seriesId;
            Parameter[2].Value = shopId;
            Parameter[3].Value = pricetype;
            Parameter[4].Value = pp;
            Parameter[5].Value = Userid;
            return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_SetProductPrice", Parameter) > 0;

        }
        #region 获取套组合产品列表
        /// <summary>
        /// 获取套组合产品列表
        /// </summary>
        /// <param name="Where">where id= and ''</param>
        /// <returns></returns>
        public static List<GroupProductModel> QueryGroupProductListByWhere(string strWhere)
        {
            if (!string.IsNullOrEmpty(strWhere))
                strWhere = " where " + strWhere;
            List<GroupProductModel> list = new List<GroupProductModel>();
            DataSet ds = new DataSet();
            ds = DbHelper.ExecuteDataset("select * from GroupProduct" + strWhere);
            if (ds.Tables.Count > 0)
            {
                GroupProductModel model;
                #region 实体赋值
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model = new GroupProductModel();
                    if (ds.Tables[0].Rows[i]["gpId"].ToString() != "")
                    {
                        model.gpId = int.Parse(ds.Tables[0].Rows[i]["gpId"].ToString());
                    }
                    model.No = ds.Tables[0].Rows[i]["No"].ToString();
                    model.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    if (ds.Tables[0].Rows[i]["brandId"].ToString() != "")
                    {
                        model.brandId = int.Parse(ds.Tables[0].Rows[i]["brandId"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["bigCateId"].ToString() != "")
                    {
                        model.bigCateId = int.Parse(ds.Tables[0].Rows[i]["bigCateId"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["styleId"].ToString() != "")
                    {
                        model.styleId = int.Parse(ds.Tables[0].Rows[i]["styleId"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["MaterialId"].ToString() != "")
                    {
                        model.MaterialId = int.Parse(ds.Tables[0].Rows[i]["MaterialId"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["SeriesId"].ToString() != "")
                    {
                        model.SeriesId = int.Parse(ds.Tables[0].Rows[i]["SeriesId"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["ColorId"].ToString() != "")
                    {
                        model.ColorId = int.Parse(ds.Tables[0].Rows[i]["ColorId"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["IsGroup"].ToString() != "")
                    {
                        model.IsGroup = int.Parse(ds.Tables[0].Rows[i]["IsGroup"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Price"].ToString() != "")
                    {
                        model.Price = float.Parse(ds.Tables[0].Rows[i]["Price"].ToString());
                    }
                    model.thumb = ds.Tables[0].Rows[i]["thumb"].ToString();
                    model.bannel = ds.Tables[0].Rows[i]["bannel"].ToString();
                    model.Descript = ds.Tables[0].Rows[i]["Descript"].ToString();
                    model.userName = ds.Tables[0].Rows[i]["userName"].ToString();
                    if (ds.Tables[0].Rows[i]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[i]["CreateDate"].ToString());
                    }
                    model.ModifyUser = ds.Tables[0].Rows[i]["ModifyUser"].ToString();
                    if (ds.Tables[0].Rows[i]["ModifyTime"].ToString() != "")
                    {
                        model.ModifyTime = DateTime.Parse(ds.Tables[0].Rows[i]["ModifyTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(ds.Tables[0].Rows[i]["Status"].ToString());
                    }
                    model.PropertyName = ds.Tables[0].Rows[i]["PropertyName"].ToString();
                    if (ds.Tables[0].Rows[i]["ShopId"].ToString() != "")
                    {
                        model.ShopId = int.Parse(ds.Tables[0].Rows[i]["ShopId"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Sale"].ToString() != "")
                    {
                        model.Sale = int.Parse(ds.Tables[0].Rows[i]["Sale"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Stock"].ToString() != "")
                    {
                        model.Stock = int.Parse(ds.Tables[0].Rows[i]["Stock"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["groupProductPromotion"] != DBNull.Value && ds.Tables[0].Rows[i]["groupProductPromotion"].ToString() != "")
                    {
                        model.groupProductPromotion = int.Parse(ds.Tables[0].Rows[i]["groupProductPromotion"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["smallCateId"] != DBNull.Value && ds.Tables[0].Rows[i]["smallCateId"].ToString() != "")
                    {
                        model.smallCateId = int.Parse(ds.Tables[0].Rows[i]["smallCateId"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Attribute"] != DBNull.Value && ds.Tables[0].Rows[i]["Attribute"].ToString() != "")
                    {
                        model.Attribute = ds.Tables[0].Rows[i]["Attribute"].ToString();
                    }
                    if (ds.Tables[0].Rows[i]["Sort"].ToString() != "")
                    {
                        model.Sort = int.Parse(ds.Tables[0].Rows[i]["Sort"].ToString());
                    }
                    list.Add(model);
                }
                #endregion
            }
            return list;
        }
        #endregion

        #region 得到实体对象
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static GroupProductModel GetModel(int gpId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 gpId,No,Name,brandId,bigCateId,styleId,MaterialId,SeriesId,ColorId,IsGroup,Price,thumb,bannel,Descript,userName,CreateDate,ModifyUser,ModifyTime,Status,PropertyName,ShopId,Sale,Stock,createmid,companyid,GroupProductPromotion,smallCateId,attribute,sort from GroupProduct ");
            strSql.Append(" where gpId=@gpId");
            SqlParameter[] parameters = {
					new SqlParameter("@gpId", SqlDbType.Int,4)
			};
            parameters[0].Value = gpId;

            GroupProductModel model = new GroupProductModel();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static GroupProductModel DataRowToModel(DataRow row)
        {
            GroupProductModel model = new GroupProductModel();
            if (row != null)
            {
                #region 赋值

                if (row["gpId"] != null && row["gpId"].ToString() != "")
                {
                    model.gpId = int.Parse(row["gpId"].ToString());
                }
                if (row["No"] != null)
                {
                    model.No = row["No"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["brandId"] != null && row["brandId"].ToString() != "")
                {
                    model.brandId = int.Parse(row["brandId"].ToString());
                }
                if (row["bigCateId"] != null && row["bigCateId"].ToString() != "")
                {
                    model.bigCateId = int.Parse(row["bigCateId"].ToString());
                }
                if (row["styleId"] != null && row["styleId"].ToString() != "")
                {
                    model.styleId = int.Parse(row["styleId"].ToString());
                }
                if (row["MaterialId"] != null && row["MaterialId"].ToString() != "")
                {
                    model.MaterialId = int.Parse(row["MaterialId"].ToString());
                }
                if (row["SeriesId"] != null && row["SeriesId"].ToString() != "")
                {
                    model.SeriesId = int.Parse(row["SeriesId"].ToString());
                }
                if (row["ColorId"] != null && row["ColorId"].ToString() != "")
                {
                    model.ColorId = int.Parse(row["ColorId"].ToString());
                }
                if (row["IsGroup"] != null && row["IsGroup"].ToString() != "")
                {
                    model.IsGroup = int.Parse(row["IsGroup"].ToString());
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = float.Parse(row["Price"].ToString());
                }

                if (row["thumb"] != null)
                {
                    model.thumb = row["thumb"].ToString();
                }
                if (row["bannel"] != null)
                {
                    model.bannel = row["bannel"].ToString();
                }
                if (row["Descript"] != null)
                {
                    model.Descript = row["Descript"].ToString();
                }
                if (row["userName"] != null)
                {
                    model.userName = row["userName"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["ModifyUser"] != null)
                {
                    model.ModifyUser = row["ModifyUser"].ToString();
                }
                if (row["ModifyTime"] != null && row["ModifyTime"].ToString() != "")
                {
                    model.ModifyTime = DateTime.Parse(row["ModifyTime"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["PropertyName"] != null)
                {
                    model.PropertyName = row["PropertyName"].ToString();
                }
                if (row["ShopId"] != null && row["ShopId"].ToString() != "")
                {
                    model.ShopId = int.Parse(row["ShopId"].ToString());
                }
                if (row["Sale"] != null && row["Sale"].ToString() != "")
                {
                    model.Sale = int.Parse(row["Sale"].ToString());
                }
                if (row["Stock"] != null && row["Stock"].ToString() != "")
                {
                    model.Stock = int.Parse(row["Stock"].ToString());
                }
                if (row["createmid"] != null && row["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(row["createmid"].ToString());
                }
                if (row["companyid"] != null && row["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(row["companyid"].ToString());
                }
                if (row["GroupProductPromotion"] != null && row["GroupProductPromotion"].ToString() != "")
                {
                    model.groupProductPromotion = int.Parse(row["GroupProductPromotion"].ToString());
                }
                if (row["smallCateId"] != null && row["smallCateId"].ToString() != "")
                {
                    model.smallCateId = int.Parse(row["smallCateId"].ToString());
                }
                #endregion
            }
            return model;
        }

        #endregion
        #region 根据套组合编号获取套组合列表（复制套组合时用）

        /// <summary>
        ///根据套组合编号获取套组合列表（复制套组合时用）
        /// </summary>
        /// <param name="uName">用户名</param>
        /// <param name="gpno">套组合编号</param>
        /// <returns></returns>
        public static DataTable GetgroupProductCountList(string uName, string gpno)
        {
            string sql = string.Format("select gpid,name,no,t_shop.title as shopname from GroupProduct left join t_shop on t_shop.id=GroupProduct.ShopId where  GroupProduct.userName='{0}' and GroupProduct.no like '%{1}%'", uName, gpno);
            return DbHelper.ExecuteDataset(sql).Tables[0];
        }
        #endregion

        #region 保存发布套组合产品

        ///<summary>
        /// 保存发布套组合产品
        /// </summary>
        /// <param name="model">套组合产品数据</param>
        /// <param name="singleproductId">单品id</param>
        /// <param name="ShopIdStr">店铺id</param>
        /// <returns></returns>
        public static int SaveIssueGroupProductDb(GroupProductModel model, string singleproductId, string ShopIdStr)
        {
            string Sql_SaveIssueGroupProductDb = @"
                INSERT INTO GroupProduct 
                (No,Name,brandId,bigCateId,styleId,MaterialId,SeriesId,ColorId,IsGroup,Price,thumb,bannel,Descript,userName,PropertyName,GroupProductPromotion,smallCateId,companyid,Attribute,sort,status) VALUES 
                (@No,@Name,@brandId,@bigCateId,@styleId,@MaterialId,@SeriesId,@ColorId,@IsGroup,@Price,@thumb,@bannel,@Descript,@userName,@PropertyName,@GroupProductPromotion,@smallCateId,@companyid,@Attribute,@sort,0);
                select @@IDENTITY";

            SqlParameter[] Parameter = 
            {
                new SqlParameter("@No",SqlDbType.VarChar,100),
                new SqlParameter("@Name",SqlDbType.NVarChar,100),
                new SqlParameter("@brandId",SqlDbType.Int,4),
                new SqlParameter("@bigCateId",SqlDbType.Int,4),
                new SqlParameter("@styleId",SqlDbType.Int,4),
                new SqlParameter("@MaterialId",SqlDbType.Int,4),
                new SqlParameter("@SeriesId",SqlDbType.Int,4),
                new SqlParameter("@ColorId",SqlDbType.Int,4),
                new SqlParameter("@IsGroup",SqlDbType.Int,4),
                new SqlParameter("@Price",SqlDbType.Decimal,8),
                new SqlParameter("@thumb",SqlDbType.VarChar,100),
                new SqlParameter("@bannel",SqlDbType.VarChar,100),
                new SqlParameter("@Descript",SqlDbType.Text,0),
                new SqlParameter("@userName",SqlDbType.VarChar,50),
                new SqlParameter("@PropertyName",SqlDbType.NVarChar,200),                
                new SqlParameter("@GroupProductPromotion",SqlDbType.Int,4),
                new SqlParameter("@smallCateId",SqlDbType.Int,4),
                new SqlParameter("@companyid",SqlDbType.Int,4),
                new SqlParameter("@Attribute",SqlDbType.VarChar,100),
            new SqlParameter("@sort",SqlDbType.Int,4)
            };
            Parameter[0].Value = model.No;
            Parameter[1].Value = model.Name;
            Parameter[2].Value = model.brandId;
            Parameter[3].Value = model.bigCateId;
            Parameter[4].Value = model.styleId;
            Parameter[5].Value = model.MaterialId;
            Parameter[6].Value = model.SeriesId;
            Parameter[7].Value = model.ColorId;
            Parameter[8].Value = model.IsGroup;
            Parameter[9].Value = model.Price;
            Parameter[10].Value = model.thumb;
            Parameter[11].Value = model.bannel;
            Parameter[12].Value = model.Descript;
            Parameter[13].Value = model.userName;
            Parameter[14].Value = model.PropertyName;
            Parameter[15].Value = model.groupProductPromotion;
            Parameter[16].Value = model.smallCateId;
            Parameter[17].Value = model.companyid;
            Parameter[18].Value = model.Attribute;
            Parameter[19].Value = model.Sort;
            object obj = DbHelper.ExecuteScalar(CommandType.Text, Sql_SaveIssueGroupProductDb.ToString(), Parameter);
            int gpidOut = 0;
            if (obj != null)
            {
                gpidOut = TypeConverter.ObjectToInt(obj);
                SqlParameter[] parameters = {
                 new SqlParameter("@gpId", SqlDbType.Int),
                 new SqlParameter("@ShopIdStr", SqlDbType.VarChar,100),        
                 new SqlParameter("@userName", SqlDbType.VarChar,100),
                 new SqlParameter("@singleproductId", SqlDbType.VarChar,500),
                };
                parameters[0].Value = gpidOut;
                parameters[1].Value = ShopIdStr;
                parameters[2].Value = model.userName;
                parameters[3].Value = singleproductId;
                object obj2 = DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_SaveGroupProductProperty", parameters);
                return gpidOut;

            }
            else
            {
                gpidOut = 0;
                return 0;// SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, Sql_SaveIssueGroupProductDb, Parameter) > 0;
            }
            // new SqlParameter("@singleproductId",SqlDbType.VarChar,500),
            //    new SqlParameter("@ShopIdStr",SqlDbType.VarChar,100),
            //            string Sql_SaveIssueGroupProductDb = @"
            //                INSERT INTO GroupProduct (No,Name,brandId,bigCateId,styleId,MaterialId,SeriesId,ColorId,IsGroup,Price,thumb,bannel,Descript,userName,PropertyName) VALUES 
            //                (@No,@Name,@brandId,@bigCateId,@styleId,@MaterialId,@SeriesId,@ColorId,@IsGroup,@Price,@thumb,@bannel,@Descript,@userName,@PropertyName);
            //                IF @@Error=0
            //                   Begin
            //                      Exec proc_SaveGroupProductProperty @@identity,@userName,@singleproductId,@ShopIdStr,@gpidOut
            //                   End
            //            ";


        }
        #endregion

        #region 保存编辑套组合产品

        /// <summary>
        /// 保存编辑套组合产品
        /// </summary>
        /// <param name="model">套组合产品数据</param>
        /// <param name="singleproductId">单品id</param>
        /// <param name="ShopIdStr">店铺id</param>
        /// <returns></returns>
        public static int SaveEditorGroupProductDb(GroupProductModel model, string singleproductId, string ShopIdStr)
        {
            string Sql_SaveEditorGroupProductDb = @"
                UPDATE GroupProduct SET No=@No,Name=@Name,brandId=@brandId,bigCateId=@bigCateId,styleId=@styleId,MaterialId=@MaterialId,
                SeriesId=@SeriesId,ColorId=@ColorId,IsGroup=@IsGroup,Price=@Price,thumb=@thumb,bannel=@bannel,
                Descript=@Descript,ModifyUser=@userName,ModifyTime=GETDATE(),Status=@Status,PropertyName=@PropertyName,GroupProductPromotion=@GroupProductPromotion,
                smallCateId=@smallCateId,companyid=@companyid,Attribute=@Attribute,sort=@sort,ShopId=@ShopIdStr WHERE gpId=@gpId;";
            //    IF @@Error=0
            //       Begin
            //         - Exec proc_SaveGroupProductProperty @gpId,'',@singleproductId,@ShopIdStr
            //       End
            //";
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@No",SqlDbType.VarChar,100),
                new SqlParameter("@Name",SqlDbType.NVarChar,100),
                new SqlParameter("@brandId",SqlDbType.Int,4),
                new SqlParameter("@bigCateId",SqlDbType.Int,4),
                new SqlParameter("@styleId",SqlDbType.Int,4),
                new SqlParameter("@MaterialId",SqlDbType.Int,4),
                new SqlParameter("@SeriesId",SqlDbType.Int,4),
                new SqlParameter("@ColorId",SqlDbType.Int,4),
                new SqlParameter("@IsGroup",SqlDbType.Int,4),
                new SqlParameter("@Price",SqlDbType.Decimal,8),
                new SqlParameter("@thumb",SqlDbType.VarChar,100),
                new SqlParameter("@bannel",SqlDbType.VarChar,100),
                new SqlParameter("@Descript",SqlDbType.Text,0),
                new SqlParameter("@userName",SqlDbType.VarChar,50),
                new SqlParameter("@PropertyName",SqlDbType.NVarChar,200),
                new SqlParameter("@singleproductId",SqlDbType.VarChar,500),
                new SqlParameter("@ShopIdStr",SqlDbType.VarChar,100),
                new SqlParameter("@gpId",SqlDbType.Int,4),
                new SqlParameter("@GroupProductPromotion",SqlDbType.Int,4),
                new SqlParameter("@smallCateId",SqlDbType.Int,4),
                new SqlParameter("@companyid",SqlDbType.Int,4),
                new SqlParameter("@Status",SqlDbType.Int,4),
                new SqlParameter("@Attribute", SqlDbType.VarChar,100),
                new SqlParameter("@sort", SqlDbType.Int,4)
            };
            Parameter[0].Value = model.No;
            Parameter[1].Value = model.Name;
            Parameter[2].Value = model.brandId;
            Parameter[3].Value = model.bigCateId;
            Parameter[4].Value = model.styleId;
            Parameter[5].Value = model.MaterialId;
            Parameter[6].Value = model.SeriesId;
            Parameter[7].Value = model.ColorId;
            Parameter[8].Value = model.IsGroup;
            Parameter[9].Value = model.Price;
            Parameter[10].Value = model.thumb;
            Parameter[11].Value = model.bannel;
            Parameter[12].Value = model.Descript;
            Parameter[13].Value = model.userName;
            Parameter[14].Value = model.PropertyName;
            Parameter[15].Value = singleproductId;
            Parameter[16].Value = ShopIdStr;
            Parameter[17].Value = model.gpId;
            Parameter[18].Value = model.groupProductPromotion;
            Parameter[19].Value = model.smallCateId;
            Parameter[20].Value = model.companyid;
            Parameter[21].Value = model.Status;
            Parameter[22].Value = model.Attribute;
            Parameter[23].Value = model.Sort;
            if (DbHelper.ExecuteNonQuery(CommandType.Text, Sql_SaveEditorGroupProductDb.ToString(), Parameter) > 0)
            {
                return model.gpId;
            }
            else
            {
                return 0;
            }
            // return true;// SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, Sql_SaveEditorGroupProductDb, Parameter) > 0;
        }
        #endregion

        #region 查询套组合产品

        /// <summary>
        /// 查询套组合产品
        /// </summary>
        /// <param name="Where">查询条件</param>
        /// <param name="productNo">产品编号</param>
        /// <param name="userName">会员名</param>
        /// <param name="Sale">销量排序(1表示降序；0表示升序)</param>
        /// <param name="Stock">库存排序(1表示降序；0表示升序)</param>
        /// <param name="Sorder">状态排序(1表示降序；0表示升序)</param>
        /// <param name="PageSize">每页显示产品数量</param>
        /// <param name="CurrentPage">当前索引页</param>
        /// <param name="Counts">总产品数</param>
        /// <returns></returns>
        public static List<GroupProductModel> QueryGroupProductListDb(string Where, string productNo, string userName, int Sale, int Stock, int Sorder, int PageSize, int CurrentPage, out int Counts)
        {
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@Where",SqlDbType.VarChar,1000),
                new SqlParameter("@userName",SqlDbType.VarChar,50),
                new SqlParameter("@Sale",SqlDbType.Int,4),
                new SqlParameter("@Stock",SqlDbType.Int,4),
                new SqlParameter("@Sorder",SqlDbType.Int,4),
                new SqlParameter("@PageSize",SqlDbType.Int,4),
                new SqlParameter("@CurrentPage",SqlDbType.Int,4),
                new SqlParameter("@productNo",SqlDbType.NVarChar,100)
            };
            Parameter[0].Value = Where;
            Parameter[1].Value = userName;
            Parameter[2].Value = Sale;
            Parameter[3].Value = Stock;
            Parameter[4].Value = Sorder;
            Parameter[5].Value = PageSize;
            Parameter[6].Value = CurrentPage;
            Parameter[7].Value = productNo;
            List<GroupProductModel> groupProductList = new List<GroupProductModel>();
            GroupProductModel model = null;
            Counts = 0;
            // DbHelper.ExecuteReader();  DbDataReader
            //using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proc_QueryGroupProductListDb", Parameter))
            using (DbDataReader sdr = DbHelper.ExecuteReader(CommandType.StoredProcedure, "proc_QueryGroupProductListDb", Parameter))
            {
                while (sdr.Read())
                {
                    model = new GroupProductModel();
                    //店铺名称
                    if (!(sdr[0] is DBNull))
                        model.ShopName = sdr[0].ToString();
                    //大类名称
                    if (!(sdr[1] is DBNull))
                        model.CategoryName = sdr[1].ToString();
                    //图片地址
                    model.thumb = sdr[2].ToString();
                    //套组合名称（品牌+系列+名称）
                    model.Name = sdr[3].ToString();
                    //产品id
                    model.gpId = sdr.GetInt32(4);
                    //销量
                    model.Sale = sdr.GetInt32(5);
                    //库存
                    model.Stock = sdr.GetInt32(6);
                    //状态
                    model.Status = sdr.GetInt32(7);
                    //总记录数
                    if (Counts == 0)
                        Counts = sdr.GetInt32(8);
                    groupProductList.Add(model);
                    model.No = sdr[9].ToString();
                    model = null;
                }
            }
            return groupProductList;
        }
        #endregion

        /// <summary>
        /// 查询回收站中套组合产品
        /// </summary>
        /// <param name="Where">查询条件</param>
        /// <param name="productNo">产品编号</param>
        /// <param name="userName">会员名</param>
        /// <param name="Sale">销量排序(1表示降序；0表示升序)</param>
        /// <param name="Stock">库存排序(1表示降序；0表示升序)</param>
        /// <param name="Sorder">状态排序(1表示降序；0表示升序)</param>
        /// <param name="PageSize">每页显示产品数量</param>
        /// <param name="CurrentPage">当前索引页</param>
        /// <param name="Counts">总产品数</param>
        /// <returns></returns>
        public static List<GroupProductModel> QueryRecycleGroupProductListDb(string Where, string productNo, string userName, int Sale, int Stock, int Sorder, int PageSize, int CurrentPage, out int Counts)
        {
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@Where",SqlDbType.VarChar,1000),
                new SqlParameter("@userName",SqlDbType.VarChar,50),
                new SqlParameter("@Sale",SqlDbType.Int,4),
                new SqlParameter("@Stock",SqlDbType.Int,4),
                new SqlParameter("@Sorder",SqlDbType.Int,4),
                new SqlParameter("@PageSize",SqlDbType.Int,4),
                new SqlParameter("@CurrentPage",SqlDbType.Int,4),
                new SqlParameter("@productNo",SqlDbType.NVarChar,100)
            };
            Parameter[0].Value = Where;
            Parameter[1].Value = userName;
            Parameter[2].Value = Sale;
            Parameter[3].Value = Stock;
            Parameter[4].Value = Sorder;
            Parameter[5].Value = PageSize;
            Parameter[6].Value = CurrentPage;
            Parameter[7].Value = productNo;
            List<GroupProductModel> groupProductList = new List<GroupProductModel>();
            GroupProductModel model = null;
            Counts = 0;
            //using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proc_QueryRecycleGroupProductListDb", Parameter))
            using (DbDataReader sdr = DbHelper.ExecuteReader(CommandType.StoredProcedure, "proc_QueryRecycleGroupProductListDb", Parameter))
            {
                while (sdr.Read())
                {
                    model = new GroupProductModel();
                    //店铺名称
                    if (!(sdr[0] is DBNull))
                        model.ShopName = sdr[0].ToString();
                    //大类名称
                    if (!(sdr[1] is DBNull))
                        model.CategoryName = sdr[1].ToString();
                    //图片地址
                    model.thumb = sdr[2].ToString();
                    //套组合名称（品牌+系列+名称）
                    model.Name = sdr[3].ToString();
                    //产品id
                    model.gpId = sdr.GetInt32(4);
                    //销量
                    model.Sale = sdr.GetInt32(5);
                    //库存
                    model.Stock = sdr.GetInt32(6);
                    //状态
                    model.Status = sdr.GetInt32(7);
                    //总记录数
                    if (Counts == 0)
                        Counts = sdr.GetInt32(8);
                    groupProductList.Add(model);
                    model = null;
                }
            }
            return groupProductList;
        }

        /// <summary>
        /// 上线（下线、删除）套组合产品
        /// </summary>
        /// <param name="gpId">套组产品id</param>
        /// <param name="Type">类型（up表示上线；down表示下线；delete表示删除）</param>
        /// <returns></returns>
        public static bool DoGroupProduct(string gpId, string Type)
        {
            string Sql_DoGroupProduct = string.Empty;
            switch (Type)
            {
                case "up":
                    Sql_DoGroupProduct = "UPDATE GroupProduct SET Status=1 WHERE gpId IN ({0}) ";
                    break;
                case "down":
                    Sql_DoGroupProduct = "UPDATE GroupProduct SET Status=0 WHERE gpId IN ({0}) ";
                    break;
                default:
                    Sql_DoGroupProduct = @"
                        INSERT INTO GroupProductRecycle (gpId,[No],[Name],brandId,bigCateId,styleId,MaterialId,SeriesId,ColorId,
                    IsGroup,Price,thumb,bannel,Descript,userName,CreateDate,ModifyUser,ModifyTime,Status,PropertyName,ShopId,Sale,Stock) 
                    SELECT gpId,[No],[Name],brandId,bigCateId,styleId,MaterialId,SeriesId,ColorId,
                    IsGroup,Price,thumb,bannel,Descript,userName,CreateDate,ModifyUser,ModifyTime,Status,PropertyName,ShopId,Sale,Stock FROM GroupProduct WHERE gpId IN ({0});
                       IF @@ERROR=0
                          BEGIN
                            DELETE FROM GroupProduct WHERE gpId IN ({0})
                          END
                    ";
                    break;
            }
            Sql_DoGroupProduct = string.Format(Sql_DoGroupProduct, gpId);
            //return true;// SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, Sql_DoGroupProduct) > 0;
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql_DoGroupProduct) > 0;
        }

        /// <summary>
        /// 保存复制套组合产品到店铺数据
        /// </summary>
        /// <param name="productId">套组合产品id</param>
        /// <param name="shopId">店铺id</param>
        /// <param name="quantity">成功复制店铺数量</param>
        /// <returns></returns>
        public static bool SaveCopyGroupProductToShopDb(string productId, string shopId, out int quantity)
        {
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@productId",SqlDbType.VarChar,500),
                new SqlParameter("@shopId",SqlDbType.VarChar,500),
                new SqlParameter("@ReturnParm",SqlDbType.Int,4,ParameterDirection.Output,true,0,0,string.Empty,DataRowVersion.Default,null)
            };
            Parameter[0].Value = productId;
            Parameter[1].Value = shopId;
            int i = DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_SaveCopyGroupProductToShopDb", Parameter);
            quantity = 0;
            if (i > 0)
                quantity = (int)Parameter[2].Value;
            return i > 0;
        }

        /// <summary>
        /// 保存复制单品到店铺数据
        /// </summary>
        /// <param name="productId">单品id</param>
        /// <param name="shopId">店铺id</param>
        /// <param name="quantity">成功复制店铺数量</param>
        /// <returns></returns>
        public static bool SaveCopyProductToShopDb(string productId, string shopId, out int quantity)
        {
            SqlParameter[] Parameter = 
            {
                new SqlParameter("@productId",SqlDbType.VarChar,500),
                new SqlParameter("@shopId",SqlDbType.VarChar,500),
                new SqlParameter("@ReturnParm",SqlDbType.Int,4,ParameterDirection.Output,true,0,0,string.Empty,DataRowVersion.Default,null)
            };
            Parameter[0].Value = productId;
            Parameter[1].Value = shopId;
            int i = DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_SaveProductCopyToShopDb", Parameter);
            quantity = 0;
            if (i > 0)
                quantity = (int)Parameter[2].Value;
            return i > 0;
        }

        /// <summary>
        /// 还原（删除）回收站中套组合产品
        /// </summary>
        /// <param name="gpId">套组合产品id</param>
        /// <param name="Type">操作类型（revert表示还原；delete表示删除）</param>
        /// <returns></returns>
        public static bool DoRecycleGroupProduct(string gpId, string Type)
        {
            string Sql_DoRecycleProductProperty = string.Empty;
            if (Type == "revert")
            {
                Sql_DoRecycleProductProperty = @"
                   SET IDENTITY_INSERT [dbo].[GroupProduct] ON;
                   INSERT INTO GroupProduct (gpId,[No],[Name],brandId,bigCateId,styleId,MaterialId,SeriesId,ColorId,
                    IsGroup,Price,thumb,bannel,Descript,userName,CreateDate,ModifyUser,ModifyTime,Status,PropertyName,ShopId,Sale,Stock) 
                    SELECT gpId,[No],[Name],brandId,bigCateId,styleId,MaterialId,SeriesId,ColorId,
                    IsGroup,Price,thumb,bannel,Descript,userName,CreateDate,ModifyUser,ModifyTime,Status,PropertyName,ShopId,Sale,Stock FROM GroupProductRecycle WHERE gpId IN ({0});
                   SET IDENTITY_INSERT [dbo].[GroupProduct] OFF;
                       IF @@ERROR=0
                          BEGIN
                            DELETE FROM GroupProductRecycle WHERE gpId IN ({0})
                          END                   
                ";
            }
            else
            {
                Sql_DoRecycleProductProperty = @"
                  DELETE FROM GroupProductRecycle WHERE gpId IN ({0});
                  IF @@ERROR=0
                     BEGIN
                       DELETE FROM GroupProductProperty WHERE gpId IN ({0});
                     END
                ";
            }
            Sql_DoRecycleProductProperty = string.Format(Sql_DoRecycleProductProperty, gpId);
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql_DoRecycleProductProperty) > 0;

        }

        /// <summary>
        /// 查询编辑套组合产品时XML数据
        /// </summary>
        /// <param name="gpId">套组合产品id</param>
        /// <returns></returns>
        public static string QueryEditorGroupProductDbXml(int gpId)
        {
            string Sql_QueryEditorGroupProductDbXml = @"IF Exists(SELECT 1 FROM GroupProduct WHERE gpId=@gpId) 
               Begin
                  SELECT [No],[Name],brandId,bigCateId,styleId,MaterialId,SeriesId,ColorId,
                    IsGroup,CAST(Price AS VARCHAR(10)) AS Price,thumb,bannel,Descript,PropertyName,ShopId,(dbo.fn_GetGroupSingleProductId(@gpId)) AS spId FROM GroupProduct WHERE gpId = @gpId for xml path('gpxml');
               End
            Else
               Begin
                  SELECT NULL;
               End
            ";
            SqlParameter para = new SqlParameter("@gpId", SqlDbType.Int, 4);
            para.Value = gpId;

            object gpObject = DbHelper.ExecuteScalar(CommandType.Text, Sql_QueryEditorGroupProductDbXml, para);
            if (gpObject is DBNull)
                return null;
            else
                return (string)gpObject;
        }

        /// <summary>
        /// 查询复制同类套组合产品数据
        /// </summary>
        /// <param name="productNo">套组合产品编号</param>
        /// <param name="gpId">套组合产品属性id</param>
        /// <returns></returns>
        public static string QueryCopyGroupProdcutDbByNo(string productNo)
        {

            return "";
        }

        #region 获取套组合单品ids

        /// <summary>
        /// 获取套组合单品ids
        /// </summary>
        /// <param name="strWere">where条件，（id=1 and uid= ）</param>
        /// <returns></returns>
        public static List<GroupProductProperty> GetGroupProductPropertyByWhere(string strWere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from GroupProductProperty where 1=1");
            if (strWere != "")
            {
                strSql.Append(" and" + strWere);
            }

            List<GroupProductProperty> modellist = new List<GroupProductProperty>();

            using (IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (reader.Read())
                {
                    GroupProductProperty model = new GroupProductProperty();
                    if (reader["ppId"] != null && reader["ppId"].ToString() != "")
                    {
                        model.ppId = int.Parse(reader["ppId"].ToString());
                    }
                    modellist.Add(model);
                }
            }
            return modellist;
        }
        #endregion
    }
}