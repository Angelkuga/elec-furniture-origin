---------------------------------------------------
DECLARE @id INT
set @id=18
SET IDENTITY_INSERT [dbo].[t_productcategory] ON
INSERT INTO dbo.t_productcategory (id,title, letter, rewritetitle, parentid, lft, rgt, lev, depth, surface, thumb, bannel, descript, pagetitle, keywords, description, template, hits, sort, linestatus, createmid, lastedid, lastedittime, ptype, isshow)
VALUES (69,'户外家具', 'hwjj', '', 0, 125, 134, 1, '', '', '', '', '', NULL, '户外家具', NULL, '', 0, 6, 1, 0, 0, '2015-03-03 16:49:13.55', NULL, 1)
GO

INSERT INTO dbo.t_productcategory (id,title, letter, rewritetitle, parentid, lft, rgt, lev, depth, surface, thumb, bannel, descript, pagetitle, keywords, description, template, hits, sort, linestatus, createmid, lastedid, lastedittime, ptype, isshow)
VALUES (70,'休闲椅', 'xxy', '', 69, 126, 127, 2, '70,', '', '', '', '', NULL, 'xxy', NULL, '', 0, 0, 1, 0, 0, '2015-03-03 16:50:25.907', 1, 1)
GO

INSERT INTO dbo.t_productcategory (id,title, letter, rewritetitle, parentid, lft, rgt, lev, depth, surface, thumb, bannel, descript, pagetitle, keywords, description, template, hits, sort, linestatus, createmid, lastedid, lastedittime, ptype, isshow)
VALUES (71,'吊椅', 'dy', '', 69, 128, 129, 2, '71,', '', '', '', '', NULL, '吊椅', NULL, '', 0, 0, 1, 0, 0, '2015-03-03 16:51:15.713', 1, 1)
GO

INSERT INTO dbo.t_productcategory (id,title, letter, rewritetitle, parentid, lft, rgt, lev, depth, surface, thumb, bannel, descript, pagetitle, keywords, description, template, hits, sort, linestatus, createmid, lastedid, lastedittime, ptype, isshow)
VALUES (72,'桌子', 'zz', '', 69, 130, 131, 2, '72,', '', '', '', '', NULL, '桌子', NULL, '', 0, 0, 1, 0, 0, '2015-03-03 16:51:57.263', 1, 1)
GO

INSERT INTO dbo.t_productcategory (id,title, letter, rewritetitle, parentid, lft, rgt, lev, depth, surface, thumb, bannel, descript, pagetitle, keywords, description, template, hits, sort, linestatus, createmid, lastedid, lastedittime, ptype, isshow)
VALUES (73,'户外套组合', 'tzh', '', 69, 132, 133, 2, '73,', '', '', '', '', NULL, '套组合', NULL, '', 0, 0, 1, 0, 0, '2015-03-03 16:52:33.59', 2, 1)
GO
SET IDENTITY_INSERT [dbo].[t_productcategory] OFF

---------------------------------------------------
 
 

ALTER proc [dbo].[proc_tbbinfo]
@did INT,--大类id
@xid INT--小类id
as
SELECT t_product.categoryid ,t_productcategory.id as xid,t_productcategory.title as xtitle,b.id as did ,b.title as dtitle
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
WHERE t_promotionstype.title='淘宝贝'
 and t_product.auditstatus =1 and t_product.linestatus=1 
group by t_product.categoryid ,t_productcategory.title ,b.title ,b.id  ,t_productcategory.id ,b.sort,t_productcategory.sort
order by b.sort,t_productcategory.sort asc
 

--查询所有淘宝贝数据,给"换一批"使用 
--order by t_product.id desc
DECLARE @str VARCHAR(5000)
SET @str = '

SELECT  t_brand.id as brandid,t_product.title as ptitle, materialname,storage, t_brand.logo , buyprice,markprice,saleprice, t_product.thumb,t_product.id as proid,t_product.id ,
t_productcategory.title as xtitle,b.title as dtitle ,b.id as did,t_productcategory.id as xid  , ROW_NUMBER() over(partition by  b.title  order by NEWID() desc) as rowNum 
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
inner join t_brand on t_brand.id = t_product.brandid
WHERE t_promotionstype.title=''淘宝贝''   ' 

IF(@did<>0)
  SET @str = @str + ' AND b.id = '+CONVERT(VARCHAR,@did) 
IF(@xid <> 0)
 SET @str = @str  +'  and t_productcategory.id = ' +CONVERT(VARCHAR,@xid) 

SET @str = ' SELECT * FROM ( ' + @str + ' ) a WHERE a.rowNum<=12 ORDER BY a.proid DESC  ' 

EXEC (@str)

GO
  

---------------------------------------------------


DECLARE @id INT
DECLARE @id2 INT 
SELECT @id = id FROM dbo.t_advertisingcategory WHERE title = '首页-商家活动导购' 
UPDATE dbo.t_advertising SET isopen =0  WHERE categoryid = @id 
--商场广告开始
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'商场' ,'###' ,'' , '' , '' , N'' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

SELECT @id2 = id FROM dbo.t_advertising WHERE categoryid = @id AND title = '商场'
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位1' ,'###' ,'' , '/resource/content/img/index/h5.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位2' ,'###' ,'' , '/resource/content/img/index/h6.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位3' ,'###' ,'' , '/resource/content/img/index/h7.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位4' ,'###' ,'' , '/resource/content/img/index/h8.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位5' ,'###' ,'' , '/resource/content/img/index/h9.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位6' ,'###' ,'' , '/resource/content/img/index/h10.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位7' ,'###' ,'' , '/resource/content/img/index/h11.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
--商场广告结束

--品牌广告开始
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'品牌' ,'###' ,'' , '' , '' , N'' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

SELECT @id2 = id FROM dbo.t_advertising WHERE categoryid = @id AND title = '品牌'
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位1' ,'###' ,'' , '/resource/content/img/index/h5.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位2' ,'###' ,'' , '/resource/content/img/index/h6.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位3' ,'###' ,'' , '/resource/content/img/index/h7.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位4' ,'###' ,'' , '/resource/content/img/index/h8.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位5' ,'###' ,'' , '/resource/content/img/index/h9.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位6' ,'###' ,'' , '/resource/content/img/index/h10.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位7' ,'###' ,'' , '/resource/content/img/index/h11.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

--品牌广告结束

--厂商广告开始
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'厂商' ,'###' ,'' , '' , '' , N'' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
SELECT @id2 = id FROM dbo.t_advertising WHERE categoryid = @id AND title = '厂商'
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位1' ,'###' ,'' , '/resource/content/img/index/h5.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位2' ,'###' ,'' , '/resource/content/img/index/h6.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位3' ,'###' ,'' , '/resource/content/img/index/h7.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位4' ,'###' ,'' , '/resource/content/img/index/h8.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位5' ,'###' ,'' , '/resource/content/img/index/h9.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位6' ,'###' ,'' , '/resource/content/img/index/h10.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位7' ,'###' ,'' , '/resource/content/img/index/h11.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

--厂商广告结束
--店铺广告开始
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'店铺' ,'###' ,'' , '' , '' , N'' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

SELECT @id2 = id FROM dbo.t_advertising WHERE categoryid = @id AND title = '店铺'
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位1' ,'###' ,'' , '/resource/content/img/index/h5.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位2' ,'###' ,'' , '/resource/content/img/index/h6.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位3' ,'###' ,'' , '/resource/content/img/index/h7.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位4' ,'###' ,'' , '/resource/content/img/index/h8.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位5' ,'###' ,'' , '/resource/content/img/index/h9.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位6' ,'###' ,'' , '/resource/content/img/index/h10.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'广告位7' ,'###' ,'' , '/resource/content/img/index/h11.jpg' , '' , N'' , CONVERT(VARCHAR,@id2) , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

--店铺广告结束

GO


---------------------------------------------------

ALTER PROC [dbo].[proc_advertising]
@str varchar(500) 
AS
DECLARE @strsql VARCHAR(5000)
SET @strsql = ''

SET @strsql = 'SELECT t.orgprice,isnull(t.adcode,'''') as adcode, t.id , t.width,t.height,t.categoryid,t.title ,t.linkurl ,t.imgurlfull as imgurl ,t.starttime ,t.endtime ,t.sort,t.price,tg.title AS tgtitle 
FROM    t_advertisingcategory tg
        INNER JOIN t_advertising t ON t.categoryid = tg.id
WHERE   t.isopen = 1
	--and (t.starttime <= GETDATE()  AND t.endtime >= GETDATE()  )
           ' + @str +' ORDER BY categoryid, t.sort desc ';

EXEC (@strsql)

---------------------------------------------------

 

ALTER proc [dbo].[proc_tbbinfo]
@did INT,--大类id
@xid INT--小类id
as
SELECT t_product.categoryid ,t_productcategory.id as xid,t_productcategory.title as xtitle,b.id as did ,b.title as dtitle
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
WHERE t_promotionstype.title='淘宝贝'
 and t_product.auditstatus =1 and t_product.linestatus=1 
group by t_product.categoryid ,t_productcategory.title ,b.title ,b.id  ,t_productcategory.id ,b.sort,t_productcategory.sort
order by b.sort,t_productcategory.sort asc
 

--查询所有淘宝贝数据,给"换一批"使用 
--order by t_product.id desc
DECLARE @str VARCHAR(5000)
SET @str = '

SELECT  t_brand.id as brandid,t_product.title as ptitle, materialname,storage, t_brand.logo , buyprice,markprice,saleprice, t_product.thumb,t_product.id as proid,t_product.id ,
t_productcategory.title as xtitle,b.title as dtitle ,b.id as did,t_productcategory.id as xid  , ROW_NUMBER() over(partition by  b.title  order by NEWID() desc) as rowNum 
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
inner join t_brand on t_brand.id = t_product.brandid
WHERE t_product.linestatus=1 and t_product.auditstatus=1 and  t_promotionstype.title=''淘宝贝''   ' 

IF(@did<>0)
  SET @str = @str + ' AND b.id = '+CONVERT(VARCHAR,@did) 
IF(@xid <> 0)
 SET @str = @str  +'  and t_productcategory.id = ' +CONVERT(VARCHAR,@xid) 

SET @str = ' SELECT * FROM ( ' + @str + ' ) a WHERE a.rowNum<=12 ORDER BY a.proid DESC  ' 

EXEC (@str)

---------------------------------------------------
 
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
tp.companyid,companyname,brandtitle,    tp.sku, tp.stylename, tp.materialname,tp.categorytitle  ,  tp.brandid,buyprice,markprice,saleprice,tp.thumb,tp.lastedittime  FROM 
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


---------------------------------------------------

 

ALTER proc [dbo].[proc_tbbinfo]
@did INT,--大类id
@xid INT--小类id
as
SELECT t_product.categoryid ,t_productcategory.id as xid,t_productcategory.title as xtitle,b.id as did ,b.title as dtitle
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
WHERE t_promotionstype.title='淘宝贝'
 and t_product.auditstatus =1 and t_product.linestatus=1 
group by t_product.categoryid ,t_productcategory.title ,b.title ,b.id  ,t_productcategory.id ,b.sort,t_productcategory.sort
order by b.sort,t_productcategory.sort asc
 

--查询所有淘宝贝数据,给"换一批"使用 
--order by t_product.id desc
DECLARE @str VARCHAR(5000)
SET @str = '

SELECT  ISNULL(t_brand.title,'') AS brandtitle,t_productcategory.title AS catetitle,ISNULL(t_product.sku,'') AS sku,t_brand.id as brandid,t_product.title as ptitle, materialname,storage, t_brand.logo , buyprice,markprice,saleprice, t_product.thumb,t_product.id as proid,t_product.id ,
t_productcategory.title as xtitle,b.title as dtitle ,b.id as did,t_productcategory.id as xid  , ROW_NUMBER() over(partition by  b.title  order by NEWID() desc) as rowNum 
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
inner join t_brand on t_brand.id = t_product.brandid
WHERE t_product.linestatus=1 and t_product.auditstatus=1 and  t_promotionstype.title=''淘宝贝''   ' 

IF(@did<>0)
  SET @str = @str + ' AND b.id = '+CONVERT(VARCHAR,@did) 
IF(@xid <> 0)
 SET @str = @str  +'  and t_productcategory.id = ' +CONVERT(VARCHAR,@xid) 

SET @str = ' SELECT * FROM ( ' + @str + ' ) a WHERE a.rowNum<=12 ORDER BY a.proid DESC  ' 

EXEC (@str)


 ---------------------------------------------------


ALTER proc [dbo].[proc_tbbinfo]
@did INT,--大类id
@xid INT--小类id
as
SELECT t_product.categoryid ,t_productcategory.id as xid,t_productcategory.title as xtitle,b.id as did ,b.title as dtitle
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
WHERE t_promotionstype.title='淘宝贝'
 and t_product.auditstatus =1 and t_product.linestatus=1 
group by t_product.categoryid ,t_productcategory.title ,b.title ,b.id  ,t_productcategory.id ,b.sort,t_productcategory.sort
order by b.sort,t_productcategory.sort asc
 

--查询所有淘宝贝数据,给"换一批"使用 
--order by t_product.id desc
DECLARE @str VARCHAR(5000)
SET @str = '

SELECT  materialname, (ISNULL(t_brand.title,'''') +'' '' + t_productcategory.title +'' ''  +ISNULL(t_product.sku,'''') +'' '' +materialname) AS ptitle,t_brand.id as brandid,t_product.title as ptitle2,storage, t_brand.logo , buyprice,markprice,saleprice, t_product.thumb,t_product.id as proid,t_product.id ,
t_productcategory.title as xtitle,b.title as dtitle ,b.id as did,t_productcategory.id as xid  , ROW_NUMBER() over(partition by  b.title  order by NEWID() desc) as rowNum 
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
inner join t_brand on t_brand.id = t_product.brandid
WHERE t_product.linestatus=1 and t_product.auditstatus=1 and  t_promotionstype.title=''淘宝贝''   ' 

IF(@did<>0)
  SET @str = @str + ' AND b.id = '+CONVERT(VARCHAR,@did) 
IF(@xid <> 0)
 SET @str = @str  +'  and t_productcategory.id = ' +CONVERT(VARCHAR,@xid) 

SET @str = ' SELECT * FROM ( ' + @str + ' ) a WHERE a.rowNum<=12 ORDER BY a.proid DESC  ' 

EXEC (@str)

 
 ---------------------------------------------------