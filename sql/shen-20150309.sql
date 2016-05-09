----�Ѹ���-
 ------------------------------------------------
 alter PROC proc_RecommendProduct
 @count int,
 @ProductAttributePromotion INT,
 @did INT,
 @xid INT
AS

	IF(@xid=-1)
		SET @xid = 8;

  SELECT   ','+t_product.attribute+',' as attribute ,t_product.title,dbo.t_product.id,t_product.sku,t_product.thumb,ProductAttributePromotion ,buyprice,markprice,saleprice 
  ,t_brand.title AS brandtitle 
  FROM dbo.t_product 
  INNER JOIN dbo.t_productattribute ON t_productattribute.productid = t_product.id 
  INNER JOIN dbo.t_brand ON t_brand.id = t_product.brandid 
  INNER JOIN dbo.t_productcategory pc ON pc.id = dbo.t_product.categoryid 
  WHERE dbo.t_product.linestatus =1 AND dbo.t_product.auditstatus =1 
  AND LEN(t_product.attribute)>0 
  AND pc.id = @xid
  GO
------------------------------------------------

alter PROC proc_RecommendProducttzh
 @count int,
 @ProductAttributePromotion int,
  @did INT,
 @xid INT
AS
IF(@did	=-1)
	SET @did=7

  SELECT   ','+GroupProduct.attribute+',' as attribute ,GroupProduct.name AS title
  ,GroupProduct.gpid AS id,GroupProduct.no AS sku,GroupProduct.thumb,GroupProductPromotion   ,GroupProduct.Price
  ,t_brand.title AS brandtitle 
  FROM dbo.GroupProduct  
  INNER JOIN dbo.t_brand ON t_brand.id = GroupProduct.brandid 
  WHERE dbo.GroupProduct.Status =1 
  AND LEN(GroupProduct.attribute)>0 
  AND bigCateId = @did	
  GO
 
 
 
------------------------------------------------
  
DECLARE @id INT
set @id =47
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','��ҳ-������ͼƬ','',240,320,1,54,GETDATE(),GETDATE(),'��ҳ-������ͼƬ','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] off

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'��ɽ����һͼƬ' ,'##' ,'' , '/resource/content/img/index/h12.jpg' , '' , N'7' , '310101' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'��ɽ����һͼƬ' ,'##' ,'' , '/resource/content/img/index/h1.jpg' , '' , N'7' , '310101' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'��ɽ���¶�ͼƬ' ,'##' ,'' , '/resource/content/img/index/h2.jpg' , '' , N'7' , '310101' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'��ɽ������ͼƬ' ,'##' ,'' , '/resource/content/img/index/h3.jpg' , '' , N'7' , '310101' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'��ɽ������ͼƬ' ,'##' ,'' , '/resource/content/img/index/h1.jpg' , '' , N'7' , '310101' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 


INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'�������һͼƬ' ,'##' ,'' , '/resource/content/img/index/h12.jpg' , '' , N'7' , '310104' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'�������һͼƬ' ,'##' ,'' , '/resource/content/img/index/h1.jpg' , '' , N'7' , '310104' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'������¶�ͼƬ' ,'##' ,'' , '/resource/content/img/index/h2.jpg' , '' , N'7' , '310104' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'���������ͼƬ' ,'##' ,'' , '/resource/content/img/index/h3.jpg' , '' , N'7' , '310104' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'���������ͼƬ' ,'##' ,'' , '/resource/content/img/index/h1.jpg' , '' , N'7' , '310104' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

------------------------------------------------

DECLARE @id INT
set @id = 48
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','��ҳ-�������ֲ�ͼƬ','',240,320,1,54,GETDATE(),GETDATE(),'��ҳ-�������ֲ�ͼƬ','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'��ɽ���ֲ�ͼƬ1' ,'##' ,'' , '/resource/content/img/index/h4.jpg' , '' , N'7' , '310101' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'��ɽ���ֲ�ͼƬ2' ,'##' ,'' , '/resource/content/img/index/h4.jpg' , '' , N'7' , '310101' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'������ֲ�ͼƬ1' ,'##' ,'' , '/resource/content/img/index/h4.jpg' , '' , N'7' , '310104' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'������ֲ�ͼƬ2' ,'##' ,'' , '/resource/content/img/index/h4.jpg' , '' , N'7' , '310104' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 


------------------------------------------------


 DECLARE @id INT
set @id = 49
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','�Ա����б�ҳ-������������','',240,320,1,54,GETDATE(),GETDATE(),'�Ա����б�ҳ-������������','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/images/ggg1.gif' , '' , N'7' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/images/ggg1.gif' , '' , N'7' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/images/ggg1.gif' , '' , N'7' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/images/ggg1.gif' , '' , N'7' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 


------------------------------------------------
 DECLARE @id INT
set @id = 50
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','�Ա����б�ҳ-�������ֲ�ͼƬ','',240,320,1,54,GETDATE(),GETDATE(),'�Ա����б�ҳ-�������ֲ�ͼƬ','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/images/img1.jpg' , '' , N'7' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/images/img1.jpg' , '' , N'7' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/images/img1.jpg' , '' , N'7' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
 

------------------------------------------------
 
 DECLARE @id INT
set @id = 51
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','�Ա����б�ҳ-����4�����ͼƬ','',240,320,1,54,GETDATE(),GETDATE(),'�Ա����б�ҳ-����4�����ͼƬ','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/images/11.jpg' , '' , N'7' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/images/11.jpg' , '' , N'7' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/images/11.jpg' , '' , N'7' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
 
INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurlfull ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '/resource/content/images/11.jpg' , '' , N'7' , '' , 1 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
 

------------------------------------------------
CREATE PROC proc_t_promotions
 @count int --��������
 as
SELECT  TOP 6 id,mid,membertype,title FROM t_promotions WHERE auditstatus =1 AND linestatus =1 AND IsRecommend =1 
ORDER BY id DESC 
GO

------------------------------------------------
------------------------------------------------