

/*
���¹������
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
VALUES(@id,0,0,'','��ҳ-Ʒ���Ƽ���߹��λ','',230,180,1,50,GETDATE(),GETDATE(),'��ҳ-Ʒ���Ƽ���߹��λ','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF

INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'##' ,'' , '' , '' , N'' , '' , 0 ,N'' , N'' ,N'' ,GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
go
--------------------------------------
DECLARE @id INT
set @id=18
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','��ҳ-��ʱ�����ұ߹��λ','',240,320,1,51,GETDATE(),GETDATE(),'��ҳ-��ʱ�����ұ߹��λ','',0 )
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
VALUES(0,0,'','��ҳ-�����ؼ��ұ߹��λ','',240,320,1,52,GETDATE(),GETDATE(),'��ҳ-�����ؼ��ұ߹��λ','',0 )
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
VALUES(@id,0,0,'','��ҳ-�̼һ����','',240,320,1,53,GETDATE(),GETDATE(),'��ҳ-�̼һ����','',0 )
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
VALUES(@id,0,0,'','�̼һҳ��-�ұ߹��ͼ','',240,320,1,54,GETDATE(),GETDATE(),'�̼һҳ��-�ұ߹��ͼ','',0 )
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
VALUES(@id,0,0,'','�̼һҳ��-�������ͼ','',240,320,1,55,GETDATE(),GETDATE(),'�̼һҳ��-�������ͼ','',0 )
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

 
 
--//////////���ͱ�
create table t_promotionstype
(
	id int identity(1,1) primary key,
	title varchar(50) ,--��������
	createtime datetime,--����ʱ��
	userid int,--������id
	pstate int,--״̬
	pindex int-- ����
)
insert into t_promotionstype(title,createtime,userid,pstate,pindex) 
select '��ʱ����',GETDATE(),0,1,0 union all
select '�����ؼ�',GETDATE(),0,1,0 union all
select '�Ա���',GETDATE(),0,1,0 
--//////////���ͱ�
 
--------------------------------------


alter proc proc_tbbinfo
as
SELECT t_product.categoryid ,t_productcategory.title,b.title,b.id,t_productcategory.parentid
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
WHERE t_promotionstype.title='�Ա���'
group by t_product.categoryid ,t_productcategory.title,b.title,b.id,t_productcategory.parentid 


--��ѯ�����Ա�������,��"��һ��"ʹ��?
SELECT storage, t_brand.logo , buyprice,markprice,saleprice, t_product.thumb,t_product.id as proid,t_product.id ,t_productcategory.title,b.title,b.id,t_productcategory.parentid
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
inner join t_brand on t_brand.id = t_product.brandid
WHERE t_promotionstype.title='�Ա���'
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
WHERE t_promotionstype.title='�Ա���'
group by t_product.categoryid ,t_productcategory.title ,b.title ,b.id  ,t_productcategory.id ,b.sort,t_productcategory.sort
order by b.sort,t_productcategory.sort asc
 


--��ѯ�����Ա�������,��"��һ��"ʹ��?
SELECT  t_brand.id as brandid,t_product.title as ptitle, materialname,storage, t_brand.logo , buyprice,markprice,saleprice, t_product.thumb,t_product.id as proid,t_product.id ,
t_productcategory.title as xtitle,b.title as dtitle ,b.id as did,t_productcategory.id as xid 
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
inner join t_brand on t_brand.id = t_product.brandid
WHERE t_promotionstype.title='�Ա���'
 and t_product.auditstatus =1 and t_product.linestatus=1 
order by t_productcategory.sort asc 

-------------------------------------




UPDATE t_productcategory SET sort =1 WHERE parentid =0 AND title ='���ҼҾ�'
UPDATE t_productcategory SET sort =2 WHERE parentid =0 AND title ='�����Ҿ�'
UPDATE t_productcategory SET sort =3 WHERE parentid =0 AND title ='�����Ҿ�'
UPDATE t_productcategory SET sort =4 WHERE parentid =0 AND title ='�鷿�Ҿ�'
UPDATE t_productcategory SET sort =5 WHERE parentid =0 AND title ='��ͯ�Ҿ�'
 
UPDATE t_productcategory SET sort =1 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='��ͯ�Ҿ�')) AND title ='��ͯ��'
UPDATE t_productcategory SET sort =2 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='��ͯ�Ҿ�')) AND title ='��ͯ��'
UPDATE t_productcategory SET sort =3 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='��ͯ�Ҿ�')) AND title ='��ͯ��'
UPDATE t_productcategory SET sort =4 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='��ͯ�Ҿ�')) AND title ='��ͯ�¹�'
UPDATE t_productcategory SET sort =6 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='��ͯ�Ҿ�')) AND title ='��ͯ��ͷ��'
UPDATE t_productcategory SET sort =7 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='��ͯ�Ҿ�')) AND title ='��ͯ���'
UPDATE t_productcategory SET sort =8 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='��ͯ�Ҿ�')) AND title ='��ͯ����'
UPDATE t_productcategory SET sort =9 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='��ͯ�Ҿ�')) AND title ='��ͯ����'

-----------------------------------------------


 
UPDATE t_productcategory SET sort =1 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�鷿�Ҿ�')) AND title ='����'
UPDATE t_productcategory SET sort =2 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�鷿�Ҿ�')) AND title ='����'
UPDATE t_productcategory SET sort =3 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�鷿�Ҿ�')) AND title ='���'
UPDATE t_productcategory SET sort =4 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�鷿�Ҿ�')) AND title ='���'
UPDATE t_productcategory SET sort =6 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�鷿�Ҿ�')) AND title ='�鱨��'
UPDATE t_productcategory SET sort =7 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�鷿�Ҿ�')) AND title ='������'
UPDATE t_productcategory SET sort =8 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�鷿�Ҿ�')) AND title ='�鷿����'
UPDATE t_productcategory SET sort =9 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�鷿�Ҿ�')) AND title ='�칫��'

---------------------------------------


UPDATE t_productcategory SET sort =1 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='����'
UPDATE t_productcategory SET sort =2 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='����'
UPDATE t_productcategory SET sort =3 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='�ͱ߹�/��'
UPDATE t_productcategory SET sort =4 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='����'
UPDATE t_productcategory SET sort =5 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='��̨'
UPDATE t_productcategory SET sort =6 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='����'
UPDATE t_productcategory SET sort =7 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='�ͳ�'
UPDATE t_productcategory SET sort =8 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='��������'
---------------------------------------

UPDATE t_productcategory SET sort =1 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='���ҼҾ�')) AND title ='��'
UPDATE t_productcategory SET sort =2 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='���ҼҾ�')) AND title ='��ͷ��'
UPDATE t_productcategory SET sort =3 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='���ҼҾ�')) AND title ='�¹�'
UPDATE t_productcategory SET sort =4 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='���ҼҾ�')) AND title ='����'
UPDATE t_productcategory SET sort =5 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='���ҼҾ�')) AND title ='��ױ̨/��'
UPDATE t_productcategory SET sort =6 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='���ҼҾ�')) AND title ='��ױ��'
UPDATE t_productcategory SET sort =7 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='���ҼҾ�')) AND title ='��β��'
UPDATE t_productcategory SET sort =8 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='���ҼҾ�')) AND title ='�¼�'
UPDATE t_productcategory SET sort =9 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='���ҼҾ�')) AND title ='���¾�'
UPDATE t_productcategory SET sort =10 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='���ҼҾ�')) AND title ='����'
UPDATE t_productcategory SET sort =11 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='���ҼҾ�')) AND title ='����'
UPDATE t_productcategory SET sort =12 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='���ҼҾ�')) AND title ='��ͷ��'
UPDATE t_productcategory SET sort =13 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='���ҼҾ�')) AND title ='�������� '
---------------------------------------
UPDATE t_productcategory SET sort =1 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='ɳ��'
UPDATE t_productcategory SET sort =2 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='�輸'
UPDATE t_productcategory SET sort =3 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='�Ǽ�'
UPDATE t_productcategory SET sort =4 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='���ӹ�' 
UPDATE t_productcategory SET sort =5 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='չʾ��'
UPDATE t_productcategory SET sort =6 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='�ƹ�'
UPDATE t_productcategory SET sort =7 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='������'
UPDATE t_productcategory SET sort =8 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='��̤'
UPDATE t_productcategory SET sort =9 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='������'
UPDATE t_productcategory SET sort =10 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='����/��'
UPDATE t_productcategory SET sort =11 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='Ь��'
UPDATE t_productcategory SET sort =12 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='����'
UPDATE t_productcategory SET sort =13 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='����'
UPDATE t_productcategory SET sort =14 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�'))  AND title ='����'
UPDATE t_productcategory SET sort =15 WHERE (parentid = (SELECT id FROM t_productcategory WHERE parentid =0 AND title ='�����Ҿ�')) AND title ='��������'

---------------------------------------


ALTER PROC [dbo].[proc_HDSelect]
@pageindex int,--��ǰҳ��
@pagecount int,--��ҳ��
@pagesize int,--ÿҳ��ʾ����
@marketid int,--�̳�id
@brandid int,--Ʒ��id
@areaid varchar(10),--����id
@keyword nvarchar(100),--�����ؼ���
@type int,--����� (����,����,����)
@sorttype varchar(10) ,--����ʽ(asc desc)
@sort varchar(50) --��������
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
	--������ҵ=101,������=102,����=103,���̹���Ա=104,
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
	/*��ע������δ���*/
end
else
begin 
	/*Ĭ�Ͽ�ʼʱ������*/
		set @strsql =  @strsql +  ' order by t_promotions.startdatetime  asc  '
end

print @strsql

exec(@strsql)

---------------------------------------

/*2015-02-10��ʼ*/ 

INSERT INTO dbo.t_productcategory
( title ,letter ,rewritetitle ,parentid ,lft ,rgt ,lev ,depth ,surface ,thumb ,bannel ,descript ,pagetitle ,keywords ,description ,template ,
hits ,sort ,linestatus ,createmid ,lastedid ,lastedittime)
VALUES  ( N'���������' , '' , '' ,  (SELECT id FROM dbo.t_productcategory WHERE title='���ҼҾ�') , 0 ,  
0 ,  0 , '' ,  '' ,  '' ,  '' ,  NULL , N'' , N'' ,  N'' ,  '' ,  0 ,  -1 ,  1 , 1 ,  0 , GETDATE()          ) 

INSERT INTO dbo.t_productcategory
( title ,letter ,rewritetitle ,parentid ,lft ,rgt ,lev ,depth ,surface ,thumb ,bannel ,descript ,pagetitle ,keywords ,description ,template ,
hits ,sort ,linestatus ,createmid ,lastedid ,lastedittime)
VALUES  ( N'���������' , '' , '' ,  (SELECT id FROM dbo.t_productcategory WHERE title='�����Ҿ�') , 0 ,  
0 ,  0 , '' ,  '' ,  '' ,  '' ,  NULL , N'' , N'' ,  N'' ,  '' ,  0 ,  -1 ,  1 , 1 ,  0 , GETDATE()          ) 

INSERT INTO dbo.t_productcategory
( title ,letter ,rewritetitle ,parentid ,lft ,rgt ,lev ,depth ,surface ,thumb ,bannel ,descript ,pagetitle ,keywords ,description ,template ,
hits ,sort ,linestatus ,createmid ,lastedid ,lastedittime)
VALUES  ( N'���������' , '' , '' ,  (SELECT id FROM dbo.t_productcategory WHERE title='�����Ҿ�') , 0 ,  
0 ,  0 , '' ,  '' ,  '' ,  '' ,  NULL , N'' , N'' ,  N'' ,  '' ,  0 ,  -1 ,  1 , 1 ,  0 , GETDATE()          ) 

INSERT INTO dbo.t_productcategory
( title ,letter ,rewritetitle ,parentid ,lft ,rgt ,lev ,depth ,surface ,thumb ,bannel ,descript ,pagetitle ,keywords ,description ,template ,
hits ,sort ,linestatus ,createmid ,lastedid ,lastedittime)
VALUES  ( N'�鷿�����' , '' , '' ,  (SELECT id FROM dbo.t_productcategory WHERE title='�鷿�Ҿ�') , 0 ,  
0 ,  0 , '' ,  '' ,  '' ,  '' ,  NULL , N'' , N'' ,  N'' ,  '' ,  0 ,  -1 ,  1 , 1 ,  0 , GETDATE()          ) 

INSERT INTO dbo.t_productcategory
( title ,letter ,rewritetitle ,parentid ,lft ,rgt ,lev ,depth ,surface ,thumb ,bannel ,descript ,pagetitle ,keywords ,description ,template ,
hits ,sort ,linestatus ,createmid ,lastedid ,lastedittime)
VALUES  ( N'��ͯ�����' , '' , '' ,  (SELECT id FROM dbo.t_productcategory WHERE title='��ͯ�Ҿ�') , 0 ,  
0 ,  0 , '' ,  '' ,  '' ,  '' ,  NULL , N'' , N'' ,  N'' ,  '' ,  0 ,  -1 ,  1 , 1 ,  0 , GETDATE()          ) 

---------------------------------------




ALTER TABLE GroupProductProperty ADD   pcount INT DEFAULT(1) 


---------------------------------------

ALTER TABLE dbo.t_productcategory ADD ptype INT 
UPDATE t_productcategory SET ptype=1 
UPDATE t_productcategory SET ptype=2 WHERE  title LIKE '%�����%'


--��������ͣ���̨�������ϲ�Ʒʱ�����ݴ���/С��ȷ��
ALTER TABLE GroupProduct ADD gtype int DEFAULT(0) 

---------------------------------------
/*2015-02-10����*/ 



/*2015-02-13 ��ʼ*/

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
--����
SELECT id,title FROM dbo.t_productcategory WHERE linestatus=1 AND parentid =0 ORDER BY sort
--С��
SELECT t1.id,t1.title,t1.parentid FROM dbo.t_productcategory t1 
INNER JOIN t_productcategory t2 ON  t1.parentid = t2.id  WHERE t1.linestatus=1  ORDER BY t1.sort
--��������
 
select ct.id,ct.title AS cttitle,ct.type AS cttype,c.value AS cid,c.title AS ctitle FROM t_configtype ct
INNER JOIN t_config c ON c.type=ct.id AND c.module = ct.type

/**
���ݲ�Ʒ�����Թ�ϵȷ������ֵ,������
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
WHERE tp.ptype=2 and tp.title LIKE '%�����%'

) a
ORDER BY sort,tpid ,configtype
*/
GO


---------------------------------------
 
DECLARE @id INT
set @id =23
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','��Ʒ�б�ҳ-�����Ƽ�','',159,106,1,56,GETDATE(),GETDATE(),'��Ʒ�б�ҳ-�����Ƽ�','',0 )
 SET IDENTITY_INSERT [dbo].[t_advertisingcategory] Off
 
INSERT INTO dbo.t_advertising
( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id ,N'��Ʒ�б�ҳ-�����Ƽ�' , '##' , '' , '../../../resource/content/images/cp2.jpg' ,'' , N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() ,0 , 1,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

INSERT INTO dbo.t_advertising
( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id ,N'��Ʒ�б�ҳ-�����Ƽ�' , '##' , '' , '../../../resource/content/images/cp2.jpg' ,'' , N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() ,0 , 1,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
INSERT INTO dbo.t_advertising
( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id ,N'��Ʒ�б�ҳ-�����Ƽ�' , '##' , '' , '../../../resource/content/images/cp2.jpg' ,'' , N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() ,0 , 1,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 
---------------------------------------

--�����۸�
ALTER TABLE t_advertising ADD price varchar(20)  
/*2015-02-13 ����*/

---------------------------------------

 
  
 
ALTER PROC [dbo].[proc_productsearch]
@brandid int,--Ʒ��
@categoryid int, --С��
@brandsid int ,--ϵ��
@stylevalue varchar(20),--���
@colorvalue varchar(20),--color
@materialvalue varchar(20),--����
@dlid VARCHAR(50),--����id,��Ӧconfigtype����
@bid INT ,--����id
@marketid int ,--����id
@pagesize INT,--ÿҳ��С
@pageindex int,--ҳ��
@key nvarchar(100) ,--�ؼ���
@keytype INT --�ؼ�������
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
 @fg int,--���
 @cz int,--����
 @mc int,--����
 @key varchar(50),--�ؼ���
 @pageindex int,--��ǰҳ
 @pagesize int,--ÿҳ����
 @pagecount int--ҳ��
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
WHERE tp.ptype=2 and tp.title LIKE '%�����%'

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
@brandid int,--Ʒ��
@categoryid int, --С��
@brandsid int ,--ϵ��
@stylevalue varchar(20),--���
@colorvalue varchar(20),--color
@materialvalue varchar(20),--����
@dlid VARCHAR(50),--����id,��Ӧconfigtype����
@bid INT ,--����id
@marketid int ,--����id
@pagesize INT,--ÿҳ��С
@pageindex int,--ҳ��
@key nvarchar(100) ,--�ؼ���
@keytype INT --�ؼ�������
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

--�Ƿ��Ƽ�Ʒ��
ALTER TABLE t_brand ADD Recommend INT DEFAULT(0)
--�Ƽ�Ʒ�ƴ���
ALTER TABLE t_brand ADD RecommendSort INT DEFAULT(0)
--�Ƿ���ʾ����ҳ��������
ALTER TABLE dbo.t_brand ADD ShowNav INT DEFAULT(0)

--�Ƿ��Ƽ�����
ALTER TABLE t_market ADD Recommend INT DEFAULT(0)
--�Ƽ���������
ALTER TABLE t_market ADD RecommendSort INT DEFAULT(0)
--�Ƿ���ʾ����ҳ��������
ALTER TABLE t_market ADD ShowNav INT DEFAULT(0)

---------------------------------------

 
 ALTER PROC [dbo].[proc_brandsearch]
 @fg int,--���
 @cz int,--����
 @mc int,--����
 @key varchar(50),--�ؼ���
 @pageindex int,--��ǰҳ
 @pagesize int,--ÿҳ����
 @pagecount int--ҳ��
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
VALUES(@id,0,0,'','Ʒ������ҳ-�ұ��Ƽ�Ʒ��','',0,0,1,59,GETDATE(),GETDATE(),'Ʒ������ҳ-�ұ��Ƽ�Ʒ��','',0 )
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
VALUES(@id,0,0,'','Ʒ������ҳ-�ұߵײ����','',0,0,1,57,GETDATE(),GETDATE(),'Ʒ������ҳ-�ұߵײ����','',0 )
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF


INSERT INTO dbo.t_advertising( categoryid ,title ,linkurl ,flashurl ,imgurl ,videourl ,adtext ,adcode ,isopen ,adlinkman ,adlinkphone ,adlinkemail ,lastedittime ,lasteditaid,sort,starttime,endtime,advstate)
VALUES  ( @id , N'' ,'/company/136/index.aspx','' , 'http://www.jiajuks.com/upload/brand/logo/340/20130607172438841210.jpg' , '' ,N'' ,'' , 0 , N'' , N'' , N'' , GETDATE() , 0 , 0 ,GETDATE(),DATEADD(MONTH,1,GETDATE()),1); 

---------------------------------------

DECLARE @id INT
set @id = 26
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
 INSERT INTO t_advertisingcategory(id,parentid,moduleid,modulevalue,title,img,height,width,isopen,adtype,starttime,endtime,descript,template,sort) 
VALUES(@id,0,0,'','Ʒ������ҳ-�����̼�','',0,0,1,58,GETDATE(),GETDATE(),'Ʒ������ҳ-�����̼�','',0 )

 
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
 WHERE auditstatus=1 AND linestatus	=1 AND attribute='�' and t_promotionsrelated.shopid = @shopid
 GO
 
---------------------------------------

