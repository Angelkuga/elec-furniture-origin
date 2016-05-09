
--已更新---

-----------调整品牌查询方式,对多个同名品牌查询------------------------------
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
inner join t_shop on t_shop.id=  t_promotionsrelated.shopid and t_shop.linestatus =1 and t_shop.auditstatus =1 
inner join t_market on t_market.id  = t_shop.marketid and t_market.linestatus =1 and t_market.auditstatus =1 
inner join t_shopbrand on t_shop.id = t_shopbrand.shopid
inner join t_brand on t_brand.id = t_shopbrand.brandid and t_brand.linestatus =1 and t_brand.auditstatus =1 
inner join t_area on t_area.areacode = t_shop.areacode
where 1=1 
'

if(@marketid>0)
	set @strsql =  @strsql +  '  and t_market.id = ' + CONVERT(varchar,@marketid)  ;
if(@brandid>0)
	set @strsql =  @strsql +  '  and t_brand.id in ( select id from t_brand where title in (select title from t_brand where id =' + CONVERT(varchar,@brandid)+ ' ) ) '   ;
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

-------------------------------------------
 
---ProductAttributePromotion新增字段--


ALTER VIEW [dbo].[v_product]
AS
select [shopxml]
      ,[attributexml]
      ,[shopprice]
      ,[spreadname]
      ,[brandlogo]
      ,[id]
      ,[attribute]
      ,[title]
      ,[shottitle]
      ,[tcolor]
      ,[sku]
      ,[no]
      ,[letter]
      ,[categoryid]
      ,[categorytitle]
      ,[subcategoryidlist]
      ,[subcategorytitlelist]
      ,[brandid]
      ,[brandtitle]
      ,[brandsid]
      ,[brandstitle]
      ,[stylevalue]
      ,[stylename]
      ,[colorname]
      ,[colorvalue]
      ,[materialvalue]
      ,[materialname]
      ,[unit]
      ,[localitycode]
      ,[shipcode]
      ,[customize]
      ,[surface]
      ,[logo]
      ,[thumb]
      ,[bannel]
      ,[desimage]
      ,[descript]
      ,[tob2c]
      ,[companyid]
      ,[companyname]
      ,[createmid]
      ,[hits]
      ,[sort]
      ,[lastedid]
      ,[lastedittime]
      ,[auditstatus]
      ,[linestatus]
      ,[assemble]
      ,[Createtime]
      ,[sortstr]
      ,[IsPay]
      ,[FID]
      ,(CASE WHEN dollpriceMax<>0.00 THEN dollpriceMax ELSE [priceMax] END) AS maxPrice
      ,(CASE WHEN dollpriceMin<>0.00 THEN dollpriceMin ELSE [priceMin] END) AS minPrice
       FROM 
       (SELECT     (SELECT     ISNULL(id, 0) AS id, ISNULL(title, '') AS title, ISNULL(thumb, '') AS thumb, ISNULL(mapapi, '') AS map, ISNULL(linkman, '') AS linkman, ISNULL(phone, '') 
                                              AS phone, ISNULL(areacode, '') AS areacode, ISNULL(address, '') AS address, ISNULL(qq, '') AS qq, ISNULL(IsPay, '0') AS ispay, ISNULL
                                                  ((SELECT     TOP 1 price
                                                      FROM         t_productshopprice
                                                      WHERE     productid = p.id AND shopid = t_shop.id), '0') AS price, ISNULL
                                                  ((SELECT     TOP 1 dollprice
                                                      FROM         t_productshopprice
                                                      WHERE     productid = p.id AND shopid = t_shop.id), '0') AS dollprice
                       FROM          t_shop
                       WHERE      id IN
                                                  (SELECT     shopid
                                                    FROM          t_shopbrand
                                                    WHERE      brandid = p.brandid) AND linestatus = 1
                       ORDER BY lastedittime DESC, hits FOR XML PATH('type')) AS shopxml,
                          (SELECT     ISNULL(id, 0) AS id, ISNULL(typevalue, 0) typevalue, ISNULL(typename, '') AS typename, ISNULL(productstyle, '') AS productstyle, 
                                                   ISNULL(productmaterial, '') AS productmaterial, ISNULL(productwidth, 0) AS productwidth, ISNULL(productlength, 0) AS productlength, 
                                                   ISNULL(productheight, 0) AS productheight, ISNULL(productcbm, 0) AS productcbm, ISNULL(productcolorimg, '') AS productcolorimg, 
                                                   ISNULL(productcolortitle, '') AS productcolortitle, ISNULL(productcolorvalue, '') AS productcolorvalue, ISNULL(buyprice, 0) AS buyprice, 
                                                   ISNULL(markprice, 0) AS markprice, ISNULL(saleprice, 0) AS saleprice, ISNULL(isdefault, 0) AS isdefault, ISNULL(sort, 0) AS sort,ISNULL(ProductAttributePromotion,0) AS ProductAttributePromotion
                            FROM          t_productattribute
                            WHERE      productid = p.id
                            ORDER BY sort FOR XML PATH('type')) AS attributexml, ISNULL
                          ((SELECT     ISNULL(shopid, 0) AS shopid, ISNULL(productid, 0) AS productid, ISNULL(attributeid, 0) AS attributeid, ISNULL(markprice, 0) AS markprice, 
                                                    ISNULL(saleprice, 0) AS saleprice, ISNULL(buyprice, 0) AS buyprice
                              FROM         t_shopproductprice
                              WHERE     productid = p.id
                              ORDER BY p.sort FOR XML PATH('type')), '') AS shopprice,
                          (SELECT     title
                            FROM          t_config
                            WHERE      module = 103 AND type = 5 AND value =
                                                       (SELECT     spread
                                                         FROM          t_brand
                                                         WHERE      id = p.brandid)) AS spreadname, b2.logo AS brandlogo, p.*,
                          (SELECT     TOP 1 tpmax.price
                            FROM          t_productshopprice AS tpmax
                            WHERE      tpmax.productid = p.id
                            ORDER BY tpmax.price DESC) AS priceMax,
                          (SELECT     TOP 1 tpmin.price
                            FROM          t_productshopprice AS tpmin
                            WHERE      tpmin.productid = p.id
                            ORDER BY tpmin.price ASC) AS priceMin,
                          (SELECT     TOP 1 tdpmax.dollprice
                            FROM          t_productshopprice AS tdpmax
                            WHERE      tdpmax.productid = p.id
                            ORDER BY tdpmax.dollprice DESC) AS dollpriceMax,
                          (SELECT     TOP 1 tdpmin.dollprice
                            FROM          t_productshopprice AS tdpmin
                            WHERE      tdpmin.productid = p.id
                            ORDER BY tdpmin.dollprice ASC) AS dollpriceMin
FROM         t_product p LEFT JOIN
                      t_brand b2 ON p.brandid = b2.id
WHERE     p.linestatus = 1 
) AS t

GO

 
-------------------------------------------
 

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
 --histt查询浏览记录, 通过keytype判断--
 IF(@key = 'histt')
	SET @str='SELECT distinct top 5 ProductAttributePromotion,isnull(t_shop.id,0) as shopid, isnull(t_shop.title,'''' ) as shoptitle ,tp.id AS tpid,tp.title AS tptitle,
tp.companyid,companyname,brandtitle,tp.brandid,buyprice,markprice,saleprice,tp.thumb,tp.lastedittime  FROM 
dbo.t_product tp INNER JOIN  t_productattribute tpb ON tp.id = tpb.productid 
inner join t_brand on t_brand.id = tp.brandid  AND t_brand.auditstatus=1 AND t_brand.linestatus=1 
LEFT JOIN t_productshopprice ON t_productshopprice.productid =  tp.id 
LEFT JOIN dbo.t_shop ON dbo.t_shop.id = t_productshopprice.shopid 

WHERE tp.auditstatus =1 AND tp.linestatus =1 '
ELSE 
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
 
-------------------------------------------

DECLARE @id INT
set @id = 39
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','卖场促销资讯页-右边推荐店铺','',0,0,1,58,GETDATE(),GETDATE(),'卖场促销资讯页-右边推荐店铺','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] off
 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 



-------------------------------------------
DECLARE @id INT
set @id = 38
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','卖场促销资讯页-右边底部广告','',0,0,1,58,GETDATE(),GETDATE(),'卖场促销资讯页-右边底部广告','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] off
 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
 
-------------------------------------------
DECLARE @id INT
set @id = 37
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','卖场促销资讯页-右边优质商家','',0,0,1,58,GETDATE(),GETDATE(),'卖场促销资讯页-右边优质商家','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] off
 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'','' , '' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
 
-------------------------------------------

-------------------------------------------
-------------------------------------------
-------------------------------------------
-------------------------------------------
-------------------------------------------
-------------------------------------------