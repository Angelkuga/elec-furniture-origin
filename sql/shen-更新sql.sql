

/*
更新广告分类表
2015-01-29 shen
*/
ALTER TABLE t_advertisingcategory ALTER column img varchar(200) null 

ALTER TABLE t_advertisingcategory ALTER column descript nvarchar(200) null 


--UPDATE t_advertising SET imgurlfull = imgurl WHERE categoryid=20
--UPDATE t_advertising SET imgurlfull = imgurl WHERE categoryid=23
--UPDATE t_advertising SET imgurlfull = imgurl WHERE categoryid=24


DECLARE @id INT
set @id=17
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','首页-品牌推荐左边广告位','',230,180,1,50,GETDATE(),GETDATE(),'首页-品牌推荐左边广告位','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
go
--------------------------------------
DECLARE @id INT
set @id=18
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','首页-限时抢购右边广告位','',240,320,1,51,GETDATE(),GETDATE(),'首页-限时抢购右边广告位','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h25.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/img/index/h16.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

GO

--------------------------------------

 
DECLARE @id INT
set @id = 19
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
INSERT INTO t_advertisingcategory(parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(0,0,'','首页-本周特价右边广告位','',240,320,1,52,GETDATE(),GETDATE(),'首页-本周特价右边广告位','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] Off

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

GO

--------------------------------------

DECLARE @id INT
set @id =20
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','首页-商家活动导购','',240,320,1,53,GETDATE(),GETDATE(),'首页-商家活动导购','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] Off


INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/h5.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/h6.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/h7.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/h8.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/h9.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/h10.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/h11.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 


--------------------------------------
DECLARE @id INT
set @id = 21
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','商家活动页面-右边广告图','',240,320,1,54,GETDATE(),GETDATE(),'商家活动页面-右边广告图','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] off

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/hd_1.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/hd_2.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/hd_3.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/hd_4.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/hd_5.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/hd_6.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

 --------------------------------------
DECLARE @id INT
set @id = 22
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','商家活动页面-顶部广告图','',240,320,1,55,GETDATE(),GETDATE(),'商家活动页面-顶部广告图','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] Off

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/h11.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/h11.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '../../../resource/content/img/index/h11.jpg' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 


 --------------------------------------
ALTER TABLE t_advertising ADD width INT
ALTER TABLE t_advertising ADD height INT
ALTER TABLE t_advertising ADD sort INT
ALTER TABLE t_advertising ADD advstate INT
ALTER TABLE t_advertising ADD starttime DATETIME
ALTER TABLE t_advertising ADD endtime DATETIME
go
--------------------------------------

ALTER TABLE dbo.t_area ADD sort INT
UPDATE dbo.t_area SET sort =0 
go
--------------------------------------
  
--UPDATE t_advertising SET imgurl ='../../../resource/content/img/index/h17.jpg',starttime='2015-01-01',endtime='2015-03-31',advstate=1 WHERE id= 17
--UPDATE t_advertising SET imgurl ='../../../resource/content/img/index/h16.jpg',starttime='2015-01-01',endtime='2015-03-31',advstate=1 WHERE id= 18
--UPDATE t_advertising SET imgurl ='../../../resource/content/img/index/h17.jpg',starttime='2015-01-01',endtime='2015-03-31',advstate=1 WHERE id= 19
 
 

--------------------------------------
alter proc proc_BrandMarket
AS 
SELECT LEFT(letter,1) as letter2, * FROM dbo.t_brand WHERE auditstatus =1 ;
select LEFT(letter,1) as letter2,*  from t_market where auditstatus=1;
SELECT  * FROM t_shop WHERE auditstatus=1 ;
SELECT * FROM t_company WHERE auditstatus=1 ;
SELECT  *FROM t_dealer WHERE auditstatus=1 ;
GO
--------------------------------------

 
 
--//////////类型表
create table t_promotionstype
(
	id int identity(1,1) primary key,
	title varchar(50) ,--类型名称
	createtime datetime,--创建时间
	userid int,--创建人id
	pstate int,--状态
	pindex int-- 排序
)
insert into t_promotionstype(title,createtime,userid,pstate,pindex) 
select '限时抢购',GETDATE(),0,1,0 union all
select '本周特价',GETDATE(),0,1,0 union all
select '淘宝贝',GETDATE(),0,1,0 
--//////////类型表
 
--------------------------------------


alter proc proc_tbbinfo
as
SELECT t_product.categoryid ,t_productcategory.title,b.title,b.id,t_productcategory.parentid
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
WHERE t_promotionstype.title='淘宝贝'
group by t_product.categoryid ,t_productcategory.title,b.title,b.id,t_productcategory.parentid 


--查询所有淘宝贝数据,给"换一批"使用?
SELECT storage, t_brand.logo , buyprice,markprice,saleprice, t_product.thumb,t_product.id as proid,t_product.id ,t_productcategory.title,b.title,b.id,t_productcategory.parentid
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
inner join t_brand on t_brand.id = t_product.brandid
WHERE t_promotionstype.title='淘宝贝'
 and t_product.auditstatus =1 and t_product.linestatus=1 
go

 
--------------------------------------


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
SELECT  t_brand.id as brandid,t_product.title as ptitle, materialname,storage, t_brand.logo , buyprice,markprice,saleprice, t_product.thumb,t_product.id as proid,t_product.id ,
t_productcategory.title as xtitle,b.title as dtitle ,b.id as did,t_productcategory.id as xid 
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
inner join t_brand on t_brand.id = t_product.brandid
WHERE t_promotionstype.title='淘宝贝'
 and t_product.auditstatus =1 and t_product.linestatus=1 
order by t_productcategory.sort asc 

-------------------------------------




UPDATE t_productcategory SET sort =1 WHERE parentid =0 AND title ='卧室家具'
UPDATE t_productcategory SET sort =2 WHERE parentid =0 AND title ='客厅家具'
UPDATE t_productcategory SET sort =3 WHERE parentid =0 AND title ='餐厅家具'
UPDATE t_productcategory SET sort =4 WHERE parentid =0 AND title ='书房家具'
UPDATE t_productcategory SET sort =5 WHERE parentid =0 AND title ='儿童家具'
 
UPDATE t_productcategory SET sort =1 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='儿童家具')) AND title ='儿童床'
UPDATE t_productcategory SET sort =2 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='儿童家具')) AND title ='儿童桌'
UPDATE t_productcategory SET sort =3 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='儿童家具')) AND title ='儿童椅'
UPDATE t_productcategory SET sort =4 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='儿童家具')) AND title ='儿童衣柜'
UPDATE t_productcategory SET sort =6 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='儿童家具')) AND title ='儿童床头柜'
UPDATE t_productcategory SET sort =7 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='儿童家具')) AND title ='儿童书柜'
UPDATE t_productcategory SET sort =8 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='儿童家具')) AND title ='儿童斗柜'
UPDATE t_productcategory SET sort =9 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='儿童家具')) AND title ='儿童其他'

-----------------------------------------------


 
UPDATE t_productcategory SET sort =1 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='书房家具')) AND title ='书桌'
UPDATE t_productcategory SET sort =2 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='书房家具')) AND title ='书椅'
UPDATE t_productcategory SET sort =3 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='书房家具')) AND title ='书柜'
UPDATE t_productcategory SET sort =4 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='书房家具')) AND title ='书架'
UPDATE t_productcategory SET sort =6 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='书房家具')) AND title ='书报架'
UPDATE t_productcategory SET sort =7 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='书房家具')) AND title ='电脑桌'
UPDATE t_productcategory SET sort =8 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='书房家具')) AND title ='书房其他'
UPDATE t_productcategory SET sort =9 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='书房家具')) AND title ='办公椅'

---------------------------------------


UPDATE t_productcategory SET sort =1 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='餐厅家具')) AND title ='餐桌'
UPDATE t_productcategory SET sort =2 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='餐厅家具')) AND title ='餐椅'
UPDATE t_productcategory SET sort =3 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='餐厅家具')) AND title ='餐边柜/镜'
UPDATE t_productcategory SET sort =4 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='餐厅家具')) AND title ='橱柜'
UPDATE t_productcategory SET sort =5 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='餐厅家具')) AND title ='吧台'
UPDATE t_productcategory SET sort =6 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='餐厅家具')) AND title ='吧椅'
UPDATE t_productcategory SET sort =7 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='餐厅家具')) AND title ='餐车'
UPDATE t_productcategory SET sort =8 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='餐厅家具')) AND title ='餐厅其他'
---------------------------------------

UPDATE t_productcategory SET sort =1 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='卧室家具')) AND title ='床'
UPDATE t_productcategory SET sort =2 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='卧室家具')) AND title ='床头柜'
UPDATE t_productcategory SET sort =3 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='卧室家具')) AND title ='衣柜'
UPDATE t_productcategory SET sort =4 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='卧室家具')) AND title ='斗柜'
UPDATE t_productcategory SET sort =5 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='卧室家具')) AND title ='梳妆台/镜'
UPDATE t_productcategory SET sort =6 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='卧室家具')) AND title ='梳妆凳'
UPDATE t_productcategory SET sort =7 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='卧室家具')) AND title ='床尾凳'
UPDATE t_productcategory SET sort =8 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='卧室家具')) AND title ='衣架'
UPDATE t_productcategory SET sort =9 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='卧室家具')) AND title ='穿衣镜'
UPDATE t_productcategory SET sort =10 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='卧室家具')) AND title ='床垫'
UPDATE t_productcategory SET sort =11 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='卧室家具')) AND title ='床屏'
UPDATE t_productcategory SET sort =12 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='卧室家具')) AND title ='床头板'
UPDATE t_productcategory SET sort =13 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='卧室家具')) AND title ='卧室其他 '
---------------------------------------
UPDATE t_productcategory SET sort =1 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='沙发'
UPDATE t_productcategory SET sort =2 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='茶几'
UPDATE t_productcategory SET sort =3 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='角几'
UPDATE t_productcategory SET sort =4 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='电视柜' 
UPDATE t_productcategory SET sort =5 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='展示柜'
UPDATE t_productcategory SET sort =6 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='酒柜'
UPDATE t_productcategory SET sort =7 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='休闲椅'
UPDATE t_productcategory SET sort =8 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='脚踏'
UPDATE t_productcategory SET sort =9 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='贵妃椅'
UPDATE t_productcategory SET sort =10 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='玄关/镜'
UPDATE t_productcategory SET sort =11 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='鞋柜'
UPDATE t_productcategory SET sort =12 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='话几'
UPDATE t_productcategory SET sort =13 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='花架'
UPDATE t_productcategory SET sort =14 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具'))  AND title ='屏风'
UPDATE t_productcategory SET sort =15 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='客厅家具')) AND title ='客厅其他'

---------------------------------------


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
t_promotions.title,t_promotions.startdatetime,t_promotions.enddatetime ,t_promotionsrelated.shopid 
from t_promotions 
inner join t_promotionsrelated on t_promotionsrelated.promotionsid = t_promotions.id
inner join t_shop on t_shop.id=  t_promotionsrelated.shopid 
inner join t_market on t_market.id  = t_shop.marketid 
inner join t_shopbrand on t_shop.id = t_shopbrand.shopid
inner join t_brand on t_brand.id = t_shopbrand.brandid
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

---------------------------------------

/*2015-02-10开始*/ 

INSERT INTO dbo.t_productcategory
( title ,letter ,rewritetitle ,parentid ,lft ,rgt ,lev ,depth ,surface ,thumb ,bannel ,descript ,pagetitle ,keywords ,description ,template ,
hits ,sort ,linestatus ,createmid ,lastedid ,lastedittime)
VALUES  ( N'卧室套组合' , '' , '' ,  (SELECT id FROM dbo.t_productcategory WHERE title='卧室家具') , 0 ,  
0 ,  0 , '' ,  '' ,  '' ,  '' ,  NULL , N'' , N'' ,  N'' ,  '' ,  0 ,  -1 ,  1 , 1 ,  0 , GETDATE()          ) 

INSERT INTO dbo.t_productcategory
( title ,letter ,rewritetitle ,parentid ,lft ,rgt ,lev ,depth ,surface ,thumb ,bannel ,descript ,pagetitle ,keywords ,description ,template ,
hits ,sort ,linestatus ,createmid ,lastedid ,lastedittime)
VALUES  ( N'客厅套组合' , '' , '' ,  (SELECT id FROM dbo.t_productcategory WHERE title='客厅家具') , 0 ,  
0 ,  0 , '' ,  '' ,  '' ,  '' ,  NULL , N'' , N'' ,  N'' ,  '' ,  0 ,  -1 ,  1 , 1 ,  0 , GETDATE()          ) 

INSERT INTO dbo.t_productcategory
( title ,letter ,rewritetitle ,parentid ,lft ,rgt ,lev ,depth ,surface ,thumb ,bannel ,descript ,pagetitle ,keywords ,description ,template ,
hits ,sort ,linestatus ,createmid ,lastedid ,lastedittime)
VALUES  ( N'餐厅套组合' , '' , '' ,  (SELECT id FROM dbo.t_productcategory WHERE title='餐厅家具') , 0 ,  
0 ,  0 , '' ,  '' ,  '' ,  '' ,  NULL , N'' , N'' ,  N'' ,  '' ,  0 ,  -1 ,  1 , 1 ,  0 , GETDATE()          ) 

INSERT INTO dbo.t_productcategory
( title ,letter ,rewritetitle ,parentid ,lft ,rgt ,lev ,depth ,surface ,thumb ,bannel ,descript ,pagetitle ,keywords ,description ,template ,
hits ,sort ,linestatus ,createmid ,lastedid ,lastedittime)
VALUES  ( N'书房套组合' , '' , '' ,  (SELECT id FROM dbo.t_productcategory WHERE title='书房家具') , 0 ,  
0 ,  0 , '' ,  '' ,  '' ,  '' ,  NULL , N'' , N'' ,  N'' ,  '' ,  0 ,  -1 ,  1 , 1 ,  0 , GETDATE()          ) 

INSERT INTO dbo.t_productcategory
( title ,letter ,rewritetitle ,parentid ,lft ,rgt ,lev ,depth ,surface ,thumb ,bannel ,descript ,pagetitle ,keywords ,description ,template ,
hits ,sort ,linestatus ,createmid ,lastedid ,lastedittime)
VALUES  ( N'儿童套组合' , '' , '' ,  (SELECT id FROM dbo.t_productcategory WHERE title='儿童家具') , 0 ,  
0 ,  0 , '' ,  '' ,  '' ,  '' ,  NULL , N'' , N'' ,  N'' ,  '' ,  0 ,  -1 ,  1 , 1 ,  0 , GETDATE()          ) 

---------------------------------------




ALTER TABLE GroupProductProperty ADD   pcount INT DEFAULT(1) 


---------------------------------------

ALTER TABLE dbo.t_productcategory ADD ptype INT 
UPDATE t_productcategory SET ptype=1 
UPDATE t_productcategory SET ptype=2 WHERE  title LIKE '%套组合%'


--套组合类型，后台添加套组合产品时，根据大类/小类确定
ALTER TABLE GroupProduct ADD gtype int DEFAULT(0) 

---------------------------------------
/*2015-02-10结束*/ 



/*2015-02-13 开始*/

---------------------------------------
alter PROC proc_producttype
AS
SELECT tp.id AS tpid,tp.title AS tptitle,dbo.t_config.title AS configtitle,dbo.t_config.value  ,
dbo.t_configtype.title AS  configtypetitle,dbo.t_configtype.type AS configtype,dbo.t_configtype.id AS configtypeid
FROM dbo.t_productcategory tp
INNER JOIN t_pcategoryptypedef tpt ON tp.id = tpt.productcategoryid 
INNER JOIN t_config ON t_config.value = CONVERT(VARCHAR, tpt.producttypeid ) 
INNER JOIN dbo.t_configtype ON t_configtype.id = t_config.type
ORDER BY tp.id ,dbo.t_configtype.type
GO

---------------------------------------

alter PROC proc_producttype
AS
--大类
SELECT id,title FROM dbo.t_productcategory WHERE linestatus=1 AND parentid =0 ORDER BY sort
--小类
SELECT t1.id,t1.title,t1.parentid FROM dbo.t_productcategory t1 
INNER JOIN t_productcategory t2 ON  t1.parentid = t2.id  WHERE t1.linestatus=1  ORDER BY t1.sort
--各种属性
 
select ct.id,ct.title AS cttitle,ct.type AS cttype,c.value AS cid,c.title AS ctitle FROM t_configtype ct
INNER JOIN t_config c ON c.type=ct.id AND c.module = ct.type

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
GO


---------------------------------------
 
DECLARE @id INT
set @id =23
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','产品列表页-热卖推荐','',159,106,1,56,GETDATE(),GETDATE(),'产品列表页-热卖推荐','',0 )
 SET IDENTITY_INSERT [dbo].[t_advertisingcategory] Off
 
INSERT INTO dbo.t_advertising
( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id ,N'产品列表页-热卖推荐' , '##' , '' , '../../../resource/content/images/cp2.jpg' ,'' , N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() ,0 , 1,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising
( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id ,N'产品列表页-热卖推荐' , '##' , '' , '../../../resource/content/images/cp2.jpg' ,'' , N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() ,0 , 1,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising
( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id ,N'产品列表页-热卖推荐' , '##' , '' , '../../../resource/content/images/cp2.jpg' ,'' , N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() ,0 , 1,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
---------------------------------------

--促销价格
ALTER TABLE t_advertising ADD price varchar(20)  
/*2015-02-13 结束*/

---------------------------------------

 
  
 
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


---------------------------------------



 
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

go
---------------------------------------

ALTER TABLE t_productcategory ADD isshow INT DEFAULT(0) 
ALTER TABLE dbo.t_config ADD isshow INT DEFAULT(0)

---------------------------------------

alter PROC proc_configtype_product
AS
SELECT * FROM (
SELECT tp.parentid, tp2.id AS tp2id,tp2.title AS tp2title,tp.id AS tpid,tp.title AS tptitle,dbo.t_config.title AS configtitle,dbo.t_config.value  ,
dbo.t_configtype.title AS  configtypetitle,dbo.t_configtype.type AS configtype,dbo.t_configtype.id AS configtypeid,tp.sort
 ,tp.isshow
FROM dbo.t_productcategory tp 
INNER JOIN t_productcategory tp2 ON tp.parentid = tp2.id
INNER JOIN t_pcategoryptypedef tpt ON tp.id = tpt.productcategoryid 
INNER JOIN t_config ON t_config.value = CONVERT(VARCHAR, tpt.producttypeid ) 
INNER JOIN dbo.t_configtype ON t_configtype.id = t_config.type
UNION ALL
SELECT 0,tp2.id AS tp2id,tp2.title AS tp2title, tp.id AS tpid,tp.title AS tptitle ,'','','',-1,-1,-1,1
FROM dbo.t_productcategory tp 
INNER JOIN t_productcategory tp2 ON tp.parentid = tp2.id 
WHERE tp.ptype=2 and tp.title LIKE '%套组合%'

) a
ORDER BY sort,tpid ,configtype
GO
---------------------------------------

-------20150227------------------------
  
ALTER proc [dbo].[proc_BrandMarket]
AS 
SELECT LEFT(letter,1) as letter2, * FROM dbo.t_brand WHERE auditstatus =1 AND linestatus=1 ;
select LEFT(letter,1) as letter2,*  from t_market where auditstatus=1 AND linestatus=1;
SELECT  * FROM t_shop WHERE auditstatus=1 AND linestatus=1;
SELECT * FROM t_company WHERE auditstatus=1 AND linestatus=1 ;
SELECT  *FROM t_dealer WHERE auditstatus=1 AND linestatus=1;

---------------------------------------
 
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

---------------------------------------

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

---------------------------------------

 
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

go
---------------------------------------

-------20150227-------------
 

DECLARE @id INT
set @id =24
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON

 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','品牌搜索页-右边推荐品牌','',0,0,1,59,GETDATE(),GETDATE(),'品牌搜索页-右边推荐品牌','',0 )
 SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF
  
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/company/136/index.aspx','' , 'http://www.jiajuks.com/upload/brand/logo/340/20130607172438841210.jpg' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/company/84/index.aspx','' , 'http://www.jiajuks.com/upload/brand/logo/26/20130607163039796565.jpg' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/company/84/index.aspx','' , 'http://www.jiajuks.com/upload/brand/logo/28/20130607163837507808.jpg' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1);  

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/company/84/index.aspx','' , 'http://www.jiajuks.com/upload/brand/logo/479/20130607170959064141.jpg' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1);  

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/company/84/index.aspx','' , 'http://www.jiajuks.com/upload/brand/logo/27/20130607163926744345.jpg' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1);  

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/company/84/index.aspx','' , 'http://www.jiajuks.com/upload/brand/logo/454/20130607162434373504.jpg' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1);  

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/company/84/index.aspx','' , 'http://www.jiajuks.com/upload/brand/logo/401/20130607170000134017.jpg' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/company/84/index.aspx','' , 'http://www.jiajuks.com/upload/brand/logo/318/20130607164839988311.jpg' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

---------------------------------------

DECLARE @id INT
set @id = 25
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','品牌搜索页-右边底部广告','',0,0,1,57,GETDATE(),GETDATE(),'品牌搜索页-右边底部广告','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF


INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/company/136/index.aspx','' , 'http://www.jiajuks.com/upload/brand/logo/340/20130607172438841210.jpg' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

---------------------------------------

DECLARE @id INT
set @id = 26
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','品牌搜索页-优质商家','',0,0,1,58,GETDATE(),GETDATE(),'品牌搜索页-优质商家','',0 )

 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/company/136/index.aspx','' , 'http://www.jiajuks.com/upload/brand/logo/340/20130607172438841210.jpg' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 


---------------------------------------

-------20150227-------------



alter PROC proc_shoppromotions
@shopid int,
@count int
AS

 SELECT TOP 3 t_promotions.title,t_promotions.id,t_promotions.htmltitle,
 t_promotions.startdatetime,t_promotions.enddatetime,t_promotions.descript,  REPLACE(surface,',','') AS surface  FROM t_promotionsrelated INNER JOIN dbo.t_promotions ON t_promotions.id = promotionsid 
 WHERE auditstatus=1 AND linestatus	=1 AND attribute='活动' and t_promotionsrelated.shopid = @shopid
 GO
 
---------------------------------------

