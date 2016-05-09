
--已经更新到测试平台数据库--


ALTER PROC [dbo].[proc_producttype]
AS
--大类
SELECT id,title,ISNULL(isshow,0) AS isshow FROM dbo.t_productcategory WHERE linestatus=1 AND parentid =0 ORDER BY sort
--小类
SELECT t1.id,t1.title,t1.parentid,ISNULL(t1.isshow,0) AS isshow,t1.ptype FROM dbo.t_productcategory t1 
INNER JOIN t_productcategory t2 ON  t1.parentid = t2.id  WHERE t1.linestatus=1  ORDER BY t1.sort
--各种属性
 
select ct.id,ct.title AS cttitle,ct.type AS cttype,c.value AS cid,c.title AS ctitle,ISNULL(c.isshow,0) AS isshow FROM t_configtype ct
INNER JOIN t_config c ON c.type=ct.id AND c.module = ct.type
ORDER BY c.sort
/**
根据产品和属性关系确定属性值,不适用
 SELECT * FROM (
SELECT tp2.id AS tp2id,tp2.title AS tp2title,tp.id AS tpid,tp.title AS tptitle,dbo.t_config.title AS configtitle,dbo.t_config.value  ,
dbo.t_configtype.title AS  configtypetitle,dbo.t_configtype.type AS configtype,dbo.t_configtype.id AS configtypeid,tp.sort
 
FROM dbo.t_productcategory tp 
INNER JOIN t_productcategory tp2 ON tp.parentid = tp2.id
INNER JOIN t_pcategoryptypedef tpt ON tp.id = tpt.productcategoryid 
INNER JOIN t_config ON t_config.value = CONVERT(VARCHAR, tpt.producttypeid ) 
INNER JOIN dbo.t_configtype ON t_configtype.id = t_config.type
 
UNION ALL

SELECT tp2.id AS tp2id,tp2.title AS tp2title, tp.id AS tpid,tp.title AS tptitle ,'','','',-1,-1,-1
FROM dbo.t_productcategory tp 
INNER JOIN t_productcategory tp2 ON tp.parentid = tp2.id 
WHERE tp.ptype=2 and tp.title LIKE '%套组合%'

) a
ORDER BY sort,tpid ,configtype
*/

-------------------------

alter PROC proc_configtype_product
AS
SELECT * FROM (
SELECT tp.ptype,tp.parentid, tp2.id AS tp2id,tp2.title AS tp2title,tp.id AS tpid,tp.title AS tptitle,dbo.t_config.title AS configtitle,dbo.t_config.value  ,
dbo.t_configtype.title AS  configtypetitle,dbo.t_configtype.type AS configtype,dbo.t_configtype.id AS configtypeid,tp.sort
 ,tp.isshow
FROM dbo.t_productcategory tp 
INNER JOIN t_productcategory tp2 ON tp.parentid = tp2.id
INNER JOIN t_pcategoryptypedef tpt ON tp.id = tpt.productcategoryid 
INNER JOIN t_config ON t_config.value = CONVERT(VARCHAR, tpt.producttypeid ) 
INNER JOIN dbo.t_configtype ON t_configtype.id = t_config.type
UNION ALL
SELECT tp.ptype,0,tp2.id AS tp2id,tp2.title AS tp2title, tp.id AS tpid,tp.title AS tptitle ,'','','',-1,-1,-1,1
FROM dbo.t_productcategory tp 
INNER JOIN t_productcategory tp2 ON tp.parentid = tp2.id 
WHERE tp.ptype=2 and tp.title LIKE '%套组合%'

) a
ORDER BY sort,tpid ,configtype
GO



-----------------------------

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
 
SET @str='SELECT distinct  ProductAttributePromotion,isnull(t_shop.id,0) as shopid, isnull(t_shop.title,'''' ) as shoptitle ,tp.id AS tpid,tp.title AS tptitle,tp.companyid,companyname,brandtitle,tp.brandid,buyprice,markprice,saleprice,tp.thumb FROM 
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

-----------------------------
DECLARE @id INT
set @id = 30
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','卖场搜索页-右边底部广告','',0,0,1,57,GETDATE(),GETDATE(),'卖场搜索页-右边底部广告','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] off

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/company/136/index.aspx','' , 'http://www.jiajuks.com/upload/brand/logo/340/20130607172438841210.jpg' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

-----------------------------
DECLARE @id INT
set @id = 31
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','卖场搜索页-优质商家','',0,0,1,58,GETDATE(),GETDATE(),'卖场搜索页-优质商家','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] off
 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/company/136/index.aspx','' , 'http://www.jiajuks.com/upload/brand/logo/340/20130607172438841210.jpg' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 


-----------------------------

DECLARE @id INT
set @id =32
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','产品搜索页-推荐产品','',0,0,1,58,GETDATE(),GETDATE(),'产品搜索页-推荐产品','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF

 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/productinfo.aspx?id=22101','' , '/resource/content/images/tuijian.png' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

-----------------------------

--更新系列显示在导航
UPDATE t_productcategory SET isshow = 1  WHERE parentid =0
--更新套组合显示
UPDATE dbo.t_productcategory SET isshow=1 WHERE ptype=2

--卧室系列
UPDATE t_productcategory SET isshow = 1 WHERE title IN ('梳妆台/镜','床垫','斗柜','衣柜','床');
--卧室系列属性
UPDATE t_config SET isshow =1 WHERE module =103 AND type=11 and value IN (
SELECT CONVERT(VARCHAR,producttypeid) FROM dbo.t_pcategoryptypedef WHERE productcategoryid IN (
SELECT id FROM dbo.t_productcategory WHERE title IN ( '梳妆台/镜','床垫','斗柜','衣柜','床')));
--客厅家具
UPDATE t_productcategory SET isshow = 1 WHERE title IN ('玄关/镜','酒柜','角几','茶几','沙发');
--客厅系列属性
UPDATE t_config SET isshow =1 WHERE module =103 AND type=11 and value IN (
SELECT CONVERT(VARCHAR,producttypeid) FROM dbo.t_pcategoryptypedef WHERE productcategoryid IN (
SELECT id FROM dbo.t_productcategory WHERE title IN ('玄关/镜','酒柜','角几','茶几','沙发')));
--餐厅家具
UPDATE t_productcategory SET isshow = 1 WHERE title IN ('餐边柜/镜','餐椅','餐桌');
--餐厅系列属性
UPDATE t_config SET isshow =1 WHERE module =103 AND type=11 and value IN (
SELECT CONVERT(VARCHAR,producttypeid) FROM dbo.t_pcategoryptypedef WHERE productcategoryid IN (
SELECT id FROM dbo.t_productcategory WHERE title IN ('餐边柜/镜','餐椅','餐桌')));
--书房家具
UPDATE t_productcategory SET isshow = 1 WHERE title IN ('书柜');
--书房系列属性
UPDATE t_config SET isshow =1 WHERE module =103 AND type=11 and value IN (
SELECT CONVERT(VARCHAR,producttypeid) FROM dbo.t_pcategoryptypedef WHERE productcategoryid IN (
SELECT id FROM dbo.t_productcategory WHERE title IN ('书柜')));
--儿童家具
UPDATE t_productcategory SET isshow = 1 WHERE title IN ('儿童床','儿童衣柜');
--儿童系列属性
UPDATE t_config SET isshow =1 WHERE module =103 AND type=11 and value IN (
SELECT CONVERT(VARCHAR,producttypeid) FROM dbo.t_pcategoryptypedef WHERE productcategoryid IN (
SELECT id FROM dbo.t_productcategory WHERE title IN ('儿童床','儿童衣柜')));
--户外家具
UPDATE t_productcategory SET sort = 6,isshow =1 WHERE   title='户外家具' 
UPDATE t_productcategory SET isshow = 1,ptype=1 WHERE title IN ('休闲椅','吊椅','桌子');
UPDATE t_productcategory SET isshow = 1,ptype=2 WHERE title IN ('套组合');
--户外家具
UPDATE t_config SET isshow =1 WHERE module =103 AND type=11 and value IN (
SELECT CONVERT(VARCHAR,producttypeid) FROM dbo.t_pcategoryptypedef WHERE productcategoryid IN (
SELECT id FROM dbo.t_productcategory WHERE title IN ('休闲椅','吊椅','桌子','套组合')));

-----------------------------

IF EXISTS(SELECT * FROM sys.objects WHERE name='t_navigationbrand')
	DROP TABLE t_navigationbrand
go
CREATE TABLE t_navigationbrand
(
  id INT IDENTITY(1,1) PRIMARY KEY ,
  ntype INT ,--1卖场id,2品牌id,3产品分类大类id
  ntypeid INT,--1卖场id,2品牌id,3产品分类大类id
  nid INT,--1卖场id,2品牌id,3产品分类大类id
  nstate INT
)
--卧室家具
INSERT INTO t_navigationbrand (ntype,ntypeid,nid,nstate) 
SELECT 3,7,414,1 UNION ALL
SELECT 3,7,340,1 UNION ALL
SELECT 3,7,61,1 UNION ALL
SELECT 3,7,322,1 UNION ALL
SELECT 3,7,365,1 UNION ALL
SELECT 3,7,470,1 UNION ALL
SELECT 3,7,26,1 UNION ALL
SELECT 3,7,400,1 ;
--客厅家具
INSERT INTO t_navigationbrand (ntype,ntypeid,nid,nstate) 
SELECT 3,9,414,1 UNION ALL
SELECT 3,9,340,1 UNION ALL
SELECT 3,9,61,1 UNION ALL
SELECT 3,9,322,1 UNION ALL
SELECT 3,9,365,1 UNION ALL
SELECT 3,9,470,1 UNION ALL
SELECT 3,9,26,1 UNION ALL
SELECT 3,9,400,1 ;
--儿童家具
INSERT INTO t_navigationbrand (ntype,ntypeid,nid,nstate) 
SELECT 3,12,414,1 UNION ALL
SELECT 3,12,340,1 UNION ALL
SELECT 3,12,61,1 UNION ALL
SELECT 3,12,322,1 UNION ALL
SELECT 3,12,365,1 UNION ALL
SELECT 3,12,470,1 UNION ALL
SELECT 3,12,26,1 UNION ALL
SELECT 3,12,400,1 ;
--书房家具
INSERT INTO t_navigationbrand (ntype,ntypeid,nid,nstate) 
SELECT 3,11,414,1 UNION ALL
SELECT 3,11,340,1 UNION ALL
SELECT 3,11,61,1 UNION ALL
SELECT 3,11,322,1 UNION ALL
SELECT 3,11,365,1 UNION ALL
SELECT 3,11,470,1 UNION ALL
SELECT 3,11,26,1 UNION ALL
SELECT 3,11,400,1 ;
--餐厅家具
INSERT INTO t_navigationbrand (ntype,ntypeid,nid,nstate) 
SELECT 3,10,414,1 UNION ALL
SELECT 3,10,340,1 UNION ALL
SELECT 3,10,61,1 UNION ALL
SELECT 3,10,322,1 UNION ALL
SELECT 3,10,365,1 UNION ALL
SELECT 3,10,470,1 UNION ALL
SELECT 3,10,26,1 UNION ALL
SELECT 3,10,400,1 ;


SELECT t1.ntype,ntypeid,t_brand.id AS brandid,companyid,REPLACE(logo,',','') AS logo
FROM dbo.t_brand 
INNER JOIN t_navigationbrand t1 ON t1.nid = t_brand.id and t1.ntype = 3
WHERE t1.nstate =1 
-----------------------------
/*
导航条上卖场,品牌,系列中推荐的品牌
*/
CREATE PROC proc_navbrand
AS
SELECT t1.ntype,ntypeid,t_brand.id AS brandid,companyid,REPLACE(logo,',','') AS logo
FROM dbo.t_brand 
INNER JOIN t_navigationbrand t1 ON t1.nid = t_brand.id and t1.ntype = 3
WHERE t1.nstate =1 
GO
----------------------------
/*
查询广告内容
*/
CREATE PROC proc_advertising
@str varchar(500) 
AS
DECLARE @strsql VARCHAR(5000)
SET @strsql = ''

SET @strsql = 'SELECT t.adcode, t.id , t.width,t.height,t.categoryid,t.title ,t.linkurl ,t.imgurl ,t.starttime ,t.endtime ,t.sort,t.price,tg.title AS tgtitle 
FROM    t_advertisingcategory tg
        INNER JOIN t_advertising t ON t.categoryid = tg.id
WHERE   t.isopen = 1
        AND ( t.starttime <= GETDATE()  AND t.endtime >= GETDATE()  ) ' + @str +' ORDER BY categoryid, t.sort desc ';

EXEC (@strsql)
GO

----------------------------
--更新广告状态
UPDATE t_advertising SET isopen =1 WHERE advstate =1

----------------------------
--更新属性查询
 
ALTER PROC [dbo].[proc_configtype_product]
AS
SELECT * FROM (
SELECT t_config.id AS configid,tp.ptype,tp.parentid, tp2.id AS tp2id,tp2.title AS tp2title,tp.id AS tpid,tp.title AS tptitle,dbo.t_config.title AS configtitle,dbo.t_config.value  ,
dbo.t_configtype.title AS  configtypetitle,dbo.t_configtype.type AS configtype,dbo.t_configtype.id AS configtypeid,tp.sort
 ,tp.isshow AS tpshow ,dbo.t_config.isshow AS configshow
FROM dbo.t_productcategory tp 
INNER JOIN t_productcategory tp2 ON tp.parentid = tp2.id
INNER JOIN t_pcategoryptypedef tpt ON tp.id = tpt.productcategoryid 
INNER JOIN t_config ON t_config.value = CONVERT(VARCHAR, tpt.producttypeid ) 
INNER JOIN dbo.t_configtype ON t_configtype.id = t_config.type
UNION ALL
SELECT 0,tp.ptype,0,tp2.id AS tp2id,tp2.title AS tp2title, tp.id AS tpid,tp.title AS tptitle ,'','','',-1,-1,-1,1,0
FROM dbo.t_productcategory tp 
INNER JOIN t_productcategory tp2 ON tp.parentid = tp2.id 
WHERE tp.ptype=2 and tp.title LIKE '%套组合%'

) a
ORDER BY sort,tpid ,configtype


----------------------------

DECLARE @id INT
set @id = 33
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','卖场首页-右边推荐店铺','',0,0,1,58,GETDATE(),GETDATE(),'卖场首页-右边推荐店铺','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

----------------------------
DECLARE @id INT
set @id =34
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','卖场首页-右边优质商家','',0,0,1,58,GETDATE(),GETDATE(),'卖场首页-右边优质商家','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 


----------------------------

DECLARE @id INT
set @id = 35
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','卖场首页-右边底部广告','',0,0,1,58,GETDATE(),GETDATE(),'卖场首页-右边底部广告','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
----------------------------

DECLARE @id INT
set @id = 36
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','产品列表页-推荐产品','',0,0,1,58,GETDATE(),GETDATE(),'产品列表页-推荐产品','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '../../../resource/content/images/tuijian.png' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
----------------------------




ALTER PROC [dbo].[proc_advertising]
@str varchar(500) 
AS
DECLARE @strsql VARCHAR(5000)
SET @strsql = ''

SET @strsql = 'SELECT t.orgprice,t.adcode, t.id , t.width,t.height,t.categoryid,t.title ,t.linkurl ,t.imgurlfull as imgurl ,t.starttime ,t.endtime ,t.sort,t.price,tg.title AS tgtitle 
FROM    t_advertisingcategory tg
        INNER JOIN t_advertising t ON t.categoryid = tg.id
WHERE   t.isopen = 1
	--and (t.starttime <= GETDATE()  AND t.endtime >= GETDATE()  )
           ' + @str +' ORDER BY categoryid, t.sort desc ';

EXEC (@strsql)

----------------------------

UPDATE t_advertisingcategory SET title='首页-品牌推荐左边广告位' WHERE title ='首页-品牌推荐' AND id=17
UPDATE t_advertisingcategory SET title='首页-限时抢购右边广告位' WHERE title ='首页-限时抢购' AND id=18
UPDATE t_advertisingcategory SET title='首页-本周特价右边广告位' WHERE title ='首页-本周特价' AND id=19
UPDATE t_advertising SET imgurlfull = imgurl WHERE categoryid=20
UPDATE t_advertising SET imgurlfull = imgurl WHERE categoryid=23
UPDATE t_advertising SET imgurlfull = imgurl WHERE categoryid=24
------------------------------



ALTER PROC [dbo].[proc_HDSelect]
@pageindex int,--当前页数
@pagecount int,--总页数
@pagesize int,--每页显示数量
@marketid int,--商场id
@brandid int,--品牌id
@areaid varchar(10),--区域id
@keyword nvarchar(100),--搜索关键词
@type int,--活动发起方 (卖场,工厂,店铺)
@sorttype varchar(10) ,--排序方式(asc desc)
@sort varchar(50) --排序类型
AS

declare @strsql varchar(8000)
set @strsql=''

set @strsql = '
select distinct t_promotions.membertype,t_brand.companyid,t_promotions.id as pid,t_brand.title as BrandTitle,t_brand.id as BrandID, t_market.title as MarketName,t_market.areacode, t_shop.title as ShopName,t_shop.areacode, 
t_promotions.title,t_promotions.startdatetime,t_promotions.enddatetime ,t_promotionsrelated.shopid ,( t_area.areaname + t_shop.address ) as address
from t_promotions 
inner join t_promotionsrelated on t_promotionsrelated.promotionsid = t_promotions.id
inner join t_shop on t_shop.id=  t_promotionsrelated.shopid 
inner join t_market on t_market.id  = t_shop.marketid 
inner join t_shopbrand on t_shop.id = t_shopbrand.shopid
inner join t_brand on t_brand.id = t_shopbrand.brandid 
inner join t_area on t_area.areacode = t_shop.areacode
where 1=1 
'

if(@marketid>0)
	set @strsql =  @strsql +  '  and t_market.id = ' + CONVERT(varchar,@marketid)  ;
if(@brandid>0)
	set @strsql =  @strsql +  '  and t_brand.id = ' + CONVERT(varchar,@brandid) ;
if(LEN(@areaid) >0 )
	set @strsql =  @strsql +  '  and t_market.areacode =  '''+@areaid+ '''  '  ;
if(@type>0)
begin
	--工厂企业=101,经销商=102,卖场=103,店铺管理员=104,
	set @strsql =  @strsql +  '  and t_promotions.membertype =  '+CONVERT(varchar,@type)  ;
end

--if(@type>0)	

	
if(LEN(@keyword) > 0)
	 set @strsql =  @strsql +  ' and ( t_brand.title  like ''%'+@keyword+'%''  or   t_market.title like ''%'+@keyword+'%''  or t_shop.title like ''%'+@keyword+'%''    ) ';

if(LEN(@sort) >0 )
begin
	if(@sort = 'begintime' )
		set @strsql =  @strsql +  ' order by t_promotions.startdatetime   '+@sorttype+'    '
	if(@sort = 'endtime')
		set @strsql =  @strsql +  ' order by t_promotions.enddatetime   '+@sorttype+'    '
	/*关注度排序未完成*/
end
else
begin 
	/*默认开始时间排序*/
		set @strsql =  @strsql +  ' order by t_promotions.startdatetime  asc  '
end

print @strsql

exec(@strsql)

------------------------------


 
 
 
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
 
SET @str='SELECT distinct  ProductAttributePromotion,isnull(t_shop.id,0) as shopid, isnull(t_shop.title,'''' ) as shoptitle ,tp.id AS tpid,tp.title AS tptitle,
tp.companyid,companyname,brandtitle,tp.brandid,buyprice,markprice,saleprice,tp.thumb,tp.lastedittime  FROM 
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
SET @str = @str +' order by tp.lastedittime DESC  '
PRINT(@str)
EXEC (@str)


------------------------------

 

ALTER proc [dbo].[proc_tbbinfo]
as
SELECT t_product.categoryid ,t_productcategory.id as xid,t_productcategory.title as xtitle,b.id as did ,b.title as dtitle
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
WHERE t_promotionstype.title='淘宝贝'
group by t_product.categoryid ,t_productcategory.title ,b.title ,b.id  ,t_productcategory.id ,b.sort,t_productcategory.sort
order by b.sort,t_productcategory.sort asc
 


--查询所有淘宝贝数据,给"换一批"使用?
/*
SELECT  t_brand.id as brandid,t_product.title as ptitle, materialname,storage, t_brand.logo , buyprice,markprice,saleprice, t_product.thumb,t_product.id as proid,t_product.id ,
t_productcategory.title as xtitle,b.title as dtitle ,b.id as did,t_productcategory.id as xid ,,ROW_NUMBER() over(partition by  b.title  order by t_product.id desc) as rowNum 
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
inner join t_brand on t_brand.id = t_product.brandid
WHERE t_promotionstype.title='淘宝贝'
 and t_product.auditstatus =1 and t_product.linestatus=1 
order by t_productcategory.sort asc 
*/

SELECT * FROM (
SELECT  t_brand.id as brandid,t_product.title as ptitle, materialname,storage, t_brand.logo , buyprice,markprice,saleprice, t_product.thumb,t_product.id as proid,t_product.id ,
t_productcategory.title as xtitle,b.title as dtitle ,b.id as did,t_productcategory.id as xid  , ROW_NUMBER() over(partition by  b.title  order by t_product.id desc) as rowNum 
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
inner join t_brand on t_brand.id = t_product.brandid
WHERE t_promotionstype.title='淘宝贝'
 and t_product.auditstatus =1 and t_product.linestatus=1 
 
) a WHERE a.rowNum<=36
ORDER BY a.proid DESC 

GO

------------------------------

