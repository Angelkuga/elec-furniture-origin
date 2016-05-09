
 
  
 ----------------------------------------------
ALTER PROC [dbo].[proc_productsearch]
@brandid int,--品牌
@categoryid int, --小类
@brandsid int ,--系列
@stylevalue varchar(20),--风格
@colorvalue varchar(20),--color
@materialvalue varchar(20),--材质
@dlid VARCHAR(50),--大类id,对应configtype类型
@bid INT ,--大类id
@marketid int ,--卖场id
@pagesize INT,--每页大小
@pageindex int,--页码
@key nvarchar(100) ,--关键词
@keytype INT --关键词类型
as
DECLARE @str VARCHAR(8000)
SET @str=''

SET @str='SELECT ProductAttributePromotion,isnull(t_shop.id,0) as shopid, isnull(t_shop.title,'''' ) as shoptitle ,tp.id AS tpid,tp.title AS tptitle,companyid,companyname,brandtitle,tp.brandid,buyprice,markprice,saleprice,tp.thumb FROM 
dbo.t_product tp INNER JOIN  t_productattribute tpb ON tp.id = tpb.productid 
LEFT JOIN t_productshopprice ON t_productshopprice.productid =  tp.id 
LEFT JOIN dbo.t_shop ON dbo.t_shop.id = t_productshopprice.shopid 

WHERE tp.auditstatus =1 AND tp.linestatus =1 '


IF(@brandid>0)
	SET @str =@str + ' and tp.brandid = ' + CONVERT(varchar,@brandid)
IF(@categoryid>0)
	SET @str =@str + ' and tp.categoryid  =' + CONVERT(varchar,@categoryid)
IF(@brandsid>0)
	SET @str =@str + ' and tp.brandsid  =' + CONVERT(varchar,@brandsid)
IF(@brandsid>0)
	SET @str =@str + ' and tp.brandsid  =' + CONVERT(varchar,@brandsid)
IF(convert(INT, @stylevalue)>0)
	SET @str =@str + ' and tp.stylevalue  = ''' +@stylevalue+ ''''  
IF(convert(INT, @colorvalue)>0)
	SET @str =@str + ' and tp.colorvalue  = ''' +@colorvalue+ ''''  
IF(convert(INT, @materialvalue)>0)
	SET @str =@str + ' and tp.materialvalue  = ''' +@materialvalue+ ''''  
IF(LEN(@dlid)>0) 
	SET @str = @str +  ' and tpb.typevalue = ' + CONVERT(VARCHAR,@dlid)
IF(@bid>0)
	SET @str = @str + '  and tp.categoryid in (SELECT id  FROM dbo.t_productcategory WHERE parentid = '+CONVERT(VARCHAR,@bid)+' AND ptype<>2 ) '
IF(LEN(@key)>0) 
SET @str = @str + '  and (tp.title  like ''%' +@key+ '%'' or tp.companyname   like ''%' +@key+ '%''  or tp.colorname   like ''%' +@key+ '%''   or tp.materialname   like ''%' +@key+ '%''  or tp.brandstitle   like ''%' +@key+ '%''  or tp.brandtitle   like ''%' +@key+ '%''    or tp.categorytitle   like ''%' +@key+ '%''     ) '
IF(@marketid >0 )
BEGIN
SET @str= @str+ ' and tp.brandid in ( SELECT brandid FROM dbo.t_shopbrand WHERE shopid IN (SELECT shopid FROM dbo.t_marketstoreyshop where t_marketstoreyshop.marketid = '  +CONVERT(VARCHAR,@marketid)+  ' ) ) '
END

PRINT(@str)
EXEC (@str)




----------------------------------------------

 
ALTER PROC [dbo].[proc_brandsearch]
 @fg int,--风格
 @cz int,--材质
 @mc int,--卖场
 @key varchar(50),--关键词
 @pageindex int,--当前页
 @pagesize int,--每页数量
 @pagecount int--页数
 AS
 
 DECLARE @str VARCHAR (5000)
 SET @str = ''
 SET @str ='SELECT DISTINCT dbo.t_brand.id , dbo.t_brand.companyid,dbo.t_brand.title, CONVERT(VARCHAR(max),isnull(dbo.t_brand.descript,'''')  )  AS descript,
 dbo.t_brand.thumb,dbo.t_brand.bannel ,
isnull( fg.title,'''' ) AS fgtitle,isnull(cz.title,'''') AS cztitle,dbo.t_brand.logo
 FROM t_Brand 
 LEFT JOIN t_config fg ON  fg.value =  dbo.t_brand.style AND fg.type=3 AND fg.module =103
 LEFT JOIN t_config cz ON  cz.value =  dbo.t_brand.material AND cz.type=4 AND cz.module =103
 LEFT JOIN t_shopbrand ON t_shopbrand.brandid = dbo.t_brand.id 
 LEFT JOIN t_marketstoreyshop ON t_marketstoreyshop.shopid = t_shopbrand.shopid 
 where 1=1 '
 
IF(@fg>0)
	SET @str = @str + ' and t_brand.style ='  + CONVERT(VARCHAR, @fg )
IF(@cz>0)
	SET @str = @str + ' and t_brand.material ='+ CONVERT(VARCHAR, @cz )
IF(@mc>0)
	SET @str = @str +  ' AND t_marketstoreyshop.marketid =' + CONVERT(VARCHAR,@mc)
--BEGIN
--	SET @str = @str +' AND t_Brand.id IN (
--SELECT     brandid   FROM t_shopbrand 
--inner JOIN t_marketstoreyshop ON t_marketstoreyshop.shopid = t_shopbrand.shopid 
--AND marketid=' +CONVERT(VARCHAR,@mc) + '  ) '
--END

IF(LEN(@key) >0) 
	SET @str = @str + '  and (t_marketstoreyshop.markettitle like ''%' +@key+ '%'' or t_brand.title like ''%' +@key+ '%''      ) '


PRINT (@str)
 EXEC (@str	)

----------------------------------------------


ALTER TABLE t_productcategory ADD isshow INT DEFAULT(0) 
ALTER TABLE dbo.t_config ADD isshow INT DEFAULT(0)

----------------------------------------------
alter PROC proc_configtype_product
AS
SELECT * FROM (
SELECT t_config.isshow AS configshow,tp.isshow AS tpshow,t_config.id AS configid,tp2.id AS tp2id,tp2.title AS tp2title,tp.id AS tpid,tp.title AS tptitle,dbo.t_config.title AS configtitle,dbo.t_config.value  ,
dbo.t_configtype.title AS  configtypetitle,dbo.t_configtype.type AS configtype,dbo.t_configtype.id AS configtypeid,tp.sort
 
FROM dbo.t_productcategory tp 
INNER JOIN t_productcategory tp2 ON tp.parentid = tp2.id
INNER JOIN t_pcategoryptypedef tpt ON tp.id = tpt.productcategoryid 
INNER JOIN t_config ON t_config.value = CONVERT(VARCHAR, tpt.producttypeid ) 
INNER JOIN dbo.t_configtype ON t_configtype.id = t_config.type
 
UNION ALL

SELECT -1,-1,-1,tp2.id AS tp2id,tp2.title AS tp2title, tp.id AS tpid,tp.title AS tptitle ,'','','',-1,-1,-1
FROM dbo.t_productcategory tp 
INNER JOIN t_productcategory tp2 ON tp.parentid = tp2.id 
WHERE tp.ptype=2 and tp.title LIKE '%套组合%' 
) a 
ORDER BY sort,tpid ,configtype
GO


-------20150227-----------------------------------------------------------
  
ALTER proc [dbo].[proc_BrandMarket]
AS 
SELECT LEFT(letter,1) as letter2, * FROM dbo.t_brand WHERE auditstatus =1 AND linestatus=1 ;
select LEFT(letter,1) as letter2,*  from t_market where auditstatus=1 AND linestatus=1;
SELECT  * FROM t_shop WHERE auditstatus=1 AND linestatus=1;
SELECT * FROM t_company WHERE auditstatus=1 AND linestatus=1 ;
SELECT  *FROM t_dealer WHERE auditstatus=1 AND linestatus=1;

----------------------------------------------
 
ALTER PROC [dbo].[proc_productsearch]
@brandid int,--品牌
@categoryid int, --小类
@brandsid int ,--系列
@stylevalue varchar(20),--风格
@colorvalue varchar(20),--color
@materialvalue varchar(20),--材质
@dlid VARCHAR(50),--大类id,对应configtype类型
@bid INT ,--大类id
@marketid int ,--卖场id
@pagesize INT,--每页大小
@pageindex int,--页码
@key nvarchar(100) ,--关键词
@keytype INT --关键词类型
as
DECLARE @str VARCHAR(8000)
SET @str=''

SET @str='SELECT ProductAttributePromotion,isnull(t_shop.id,0) as shopid, isnull(t_shop.title,'''' ) as shoptitle ,tp.id AS tpid,tp.title AS tptitle,tp.companyid,companyname,brandtitle,tp.brandid,buyprice,markprice,saleprice,tp.thumb FROM 
dbo.t_product tp INNER JOIN  t_productattribute tpb ON tp.id = tpb.productid 
inner join t_brand on t_brand.id = tp.brandid  AND t_brand.auditstatus=1 AND t_brand.linestatus=1 
LEFT JOIN t_productshopprice ON t_productshopprice.productid =  tp.id 
LEFT JOIN dbo.t_shop ON dbo.t_shop.id = t_productshopprice.shopid 

WHERE tp.auditstatus =1 AND tp.linestatus =1 '


IF(@brandid>0)
	SET @str =@str + ' and tp.brandid = ' + CONVERT(varchar,@brandid)
IF(@categoryid>0)
	SET @str =@str + ' and tp.categoryid  =' + CONVERT(varchar,@categoryid)
IF(@brandsid>0)
	SET @str =@str + ' and tp.brandsid  =' + CONVERT(varchar,@brandsid)
IF(@brandsid>0)
	SET @str =@str + ' and tp.brandsid  =' + CONVERT(varchar,@brandsid)
IF(convert(INT, @stylevalue)>0)
	SET @str =@str + ' and tp.stylevalue  = ''' +@stylevalue+ ''''  
IF(convert(INT, @colorvalue)>0)
	SET @str =@str + ' and tp.colorvalue  = ''' +@colorvalue+ ''''  
IF(convert(INT, @materialvalue)>0)
	SET @str =@str + ' and tp.materialvalue  = ''' +@materialvalue+ ''''  
IF(LEN(@dlid)>0) 
	SET @str = @str +  ' and tpb.typevalue = ' + CONVERT(VARCHAR,@dlid)
IF(@bid>0)
	SET @str = @str + '  and tp.categoryid in (SELECT id  FROM dbo.t_productcategory WHERE parentid = '+CONVERT(VARCHAR,@bid)+' AND ptype<>2 ) '
IF(LEN(@key)>0) 
SET @str = @str + '  and (tp.title  like ''%' +@key+ '%'' or tp.companyname   like ''%' +@key+ '%''  or tp.colorname   like ''%' +@key+ '%''   or tp.materialname   like ''%' +@key+ '%''  or tp.brandstitle   like ''%' +@key+ '%''  or tp.brandtitle   like ''%' +@key+ '%''    or tp.categorytitle   like ''%' +@key+ '%''     ) '
IF(@marketid >0 )
BEGIN
SET @str= @str+ ' and tp.brandid in ( SELECT brandid FROM dbo.t_shopbrand WHERE shopid IN (SELECT shopid FROM dbo.t_marketstoreyshop where t_marketstoreyshop.marketid = '  +CONVERT(VARCHAR,@marketid)+  ' ) ) '
END

PRINT(@str)
EXEC (@str)

----------------------------------------------
--是否推荐品牌
ALTER TABLE t_brand ADD Recommend INT DEFAULT(0)
--推荐品牌次序
ALTER TABLE t_brand ADD RecommendSort INT DEFAULT(0)
--是否显示在首页导航条上
ALTER TABLE dbo.t_brand ADD ShowNav INT DEFAULT(0)

--是否推荐卖场
ALTER TABLE t_market ADD Recommend INT DEFAULT(0)
--推荐卖场次序
ALTER TABLE t_market ADD RecommendSort INT DEFAULT(0)
--是否显示在首页导航条上
ALTER TABLE t_market ADD ShowNav INT DEFAULT(0)

----------------------------------------------

 
 ALTER PROC [dbo].[proc_brandsearch]
 @fg int,--风格
 @cz int,--材质
 @mc int,--卖场
 @key varchar(50),--关键词
 @pageindex int,--当前页
 @pagesize int,--每页数量
 @pagecount int--页数
 AS
 
 DECLARE @str VARCHAR (5000)
 SET @str = ''
 SET @str ='SELECT DISTINCT dbo.t_brand.id , dbo.t_brand.companyid,dbo.t_brand.title, CONVERT(VARCHAR(max),isnull(dbo.t_brand.descript,'''')  )  AS descript,
 dbo.t_brand.thumb,dbo.t_brand.bannel ,
isnull( fg.title,'''' ) AS fgtitle,isnull(cz.title,'''') AS cztitle,dbo.t_brand.logo
 FROM t_Brand 
 LEFT JOIN t_config fg ON  fg.value =  dbo.t_brand.style AND fg.type=3 AND fg.module =103
 LEFT JOIN t_config cz ON  cz.value =  dbo.t_brand.material AND cz.type=4 AND cz.module =103
 LEFT JOIN t_shopbrand ON t_shopbrand.brandid = dbo.t_brand.id 
 LEFT JOIN t_marketstoreyshop ON t_marketstoreyshop.shopid = t_shopbrand.shopid 
 where dbo.t_brand.linestatus =1 AND dbo.t_brand.auditstatus=1  '
   
IF(@fg>0)
	SET @str = @str + ' and t_brand.style ='  + CONVERT(VARCHAR, @fg )
IF(@cz>0)
	SET @str = @str + ' and t_brand.material ='+ CONVERT(VARCHAR, @cz )
IF(@mc>0)
	SET @str = @str +  ' AND t_marketstoreyshop.marketid =' + CONVERT(VARCHAR,@mc)
--BEGIN
--	SET @str = @str +' AND t_Brand.id IN (
--SELECT     brandid   FROM t_shopbrand 
--inner JOIN t_marketstoreyshop ON t_marketstoreyshop.shopid = t_shopbrand.shopid 
--AND marketid=' +CONVERT(VARCHAR,@mc) + '  ) '
--END

IF(LEN(@key) >0) 
	SET @str = @str + '  and (t_marketstoreyshop.markettitle like ''%' +@key+ '%'' or t_brand.title like ''%' +@key+ '%''      ) '


PRINT (@str)
 EXEC (@str	)



 ----------------------------------------------


alter PROC proc_shoppromotions
@shopid int,
@count int
AS

 SELECT TOP 3 t_promotions.title,t_promotions.id,t_promotions.htmltitle,
 t_promotions.startdatetime,t_promotions.enddatetime,t_promotions.descript,  REPLACE(surface,',','') AS surface  FROM t_promotionsrelated INNER JOIN dbo.t_promotions ON t_promotions.id = promotionsid 
 WHERE auditstatus=1 AND linestatus	=1 AND attribute='活动' and t_promotionsrelated.shopid = @shopid
 GO
 
