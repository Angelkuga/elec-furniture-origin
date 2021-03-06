 -- 后台菜单替换//为/
  update [dbo].[t_menu]
  set url=REPLACE(url,'//','/') where url like '%//%'  and url not like '%://%'
  
  
 --抢购报名t_MsgCollection添加字段
alter table  dbo.t_MsgCollection add useraddress Nvarchar(500)
alter table  dbo.t_MsgCollection add ProdID int
alter table  dbo.t_MsgCollection add MID int
alter table  dbo.t_MsgCollection add prodcon int
   
--推荐产品
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] ON
INSERT INTO [dbo].[t_advertisingcategory]
           (id,[parentid],[moduleid],[modulevalue],[title],[img],[height],[width]
           ,[isopen],[adtype],[starttime],[endtime],[descript],[template],[sort])
     VALUES
           (31,0,15,'','淘宝贝列表页推荐产品','淘宝贝列表页推荐产品',0,0,1,102,GETDATE(),GETDATE(),'','',0)
INSERT INTO [dbo].[t_advertisingcategory]
           (id,[parentid],[moduleid],[modulevalue],[title],[img],[height],[width]
           ,[isopen],[adtype],[starttime],[endtime],[descript],[template],[sort])
     VALUES
           (32,0,15,'','主站首页-品牌推荐','主站首页-品牌推荐',0,0,1,102,GETDATE(),GETDATE(),'','',0)
INSERT INTO [dbo].[t_advertisingcategory]
           (id,[parentid],[moduleid],[modulevalue],[title],[img],[height],[width]
           ,[isopen],[adtype],[starttime],[endtime],[descript],[template],[sort])
     VALUES
           (33,0,15,'','主站首页-限时抢购','主站首页-限时抢购',0,0,1,102,GETDATE(),GETDATE(),'','',0)
INSERT INTO [dbo].[t_advertisingcategory]
           (id,[parentid],[moduleid],[modulevalue],[title],[img],[height],[width]
           ,[isopen],[adtype],[starttime],[endtime],[descript],[template],[sort])
     VALUES
           (34,0,15,'','主站首页-本周特价','主站首页-本周特价',0,0,1,102,GETDATE(),GETDATE(),'','',0)
INSERT INTO [dbo].[t_advertisingcategory]
           (id,[parentid],[moduleid],[modulevalue],[title],[img],[height],[width]
           ,[isopen],[adtype],[starttime],[endtime],[descript],[template],[sort])
     VALUES
           (40,0,15,'','全部分类-推荐品牌','全部分类-推荐品牌',0,0,1,102,GETDATE(),GETDATE(),'','',0)
SET IDENTITY_INSERT [dbo].[t_advertisingcategory] OFF
GO
--  admin后台菜单
INSERT INTO [dbo].[t_menu]
           ([title]
           ,[type]
           ,[mark]
           ,[parent]
           ,[lev]
           ,[path]
           ,[url]
           ,[module]
           ,[action]
           ,[descript]
           ,[sort])
     VALUES
           ('管理套组合','' ,'mmgroupproduct',65,2,'','@web/@admin/product/Groupproductlist.aspx',4,0,'',0)
GO 

 --广告位原始价和完整图片连接地址
 alter table  dbo.t_advertising add imgurlfull varchar(300)
 alter table  dbo.t_advertising add orgprice varchar(20)
 
 update t_advertising
 set imgurlfull=REPLACE(imgurl,'../..','')
 where categoryid in (17,18,19)
 
 
 --关闭新版不用广告分类
 update dbo.t_advertisingcategory
 set isopen=0
 where id in (15,14,3,16,1,12,11,10,9,8,7,6)
