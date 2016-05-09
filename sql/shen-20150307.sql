
---------已经更新到服务器---------------------
--------------------------------------------------
--首页淘宝贝左边广告---
DECLARE @id INT
set @id = 46
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','页面-淘宝贝左边广告图','',240,320,1,54,GETDATE(),GETDATE(),'页面-淘宝贝左边广告图','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] off

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h14.jpg' , '' , N'7' , '7' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h15.jpg' , '' , N'7' , '7' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h14.jpg' , '' , N'9' , '9' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h15.jpg' , '' , N'9' , '9' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h14.jpg' , '' , N'10' , '10' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h15.jpg' , '' , N'10' , '10' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h14.jpg' , '' , N'11' , '11' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h15.jpg' , '' , N'11' , '11' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h14.jpg' , '' , N'12' , '12' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h15.jpg' , '' , N'12' , '12' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h14.jpg' , '' , N'69' , '69' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h15.jpg' , '' , N'69' , '69' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

--------------------------------------------------
USE [JiaJuKSN]
GO
/****** Object:  StoredProcedure [dbo].[proc_tbbinfo]    Script Date: 03/07/2015 20:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 

ALTER proc [dbo].[proc_tbbinfo]
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



--------------------------------------------------