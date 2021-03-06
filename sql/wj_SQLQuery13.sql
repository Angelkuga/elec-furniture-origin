  -- 添加抢购限时
  alter table [dbo].[t_aggregation]  add starttime  datetime null
  alter table  [dbo].[t_aggregation]  add endtime  datetime null
  
  -- 广告位不使用[t_aggregation]了 2015-3-4
 -- SET IDENTITY_INSERT [dbo].[t_aggregationtype]   ON
 -- INSERT INTO [dbo].[t_aggregationtype]
 --          (id,[parentid],[title],[title1],[thumb],[url],[sort])
 --    VALUES
 --          (50,0,'品牌推荐','','','',0) 
 --   INSERT INTO [dbo].[t_aggregationtype]
 --          (id,[parentid],[title],[title1],[thumb],[url],[sort])
 --    VALUES
 --          (51,0,'限时抢购','','','',0) 
 --  INSERT INTO [dbo].[t_aggregationtype]
 --          (id,[parentid],[title],[title1],[thumb],[url],[sort])
 --    VALUES
 --          (52,0,'限时抢购B','','','',0) 
 --   INSERT INTO [dbo].[t_aggregationtype]
 --          (id,[parentid],[title],[title1],[thumb],[url],[sort])
 --    VALUES
 --          (53,0,'淘宝贝','','','',0)       
 --      INSERT INTO [dbo].[t_aggregationtype]
 --          (id,[parentid],[title],[title1],[thumb],[url],[sort])
 --    VALUES
 --          (54,0,'商家活动导购','','','',0)     
 --      INSERT INTO [dbo].[t_aggregationtype]
 --          (id,[parentid],[title],[title1],[thumb],[url],[sort])
 --    VALUES
 --          (55,0,'逛卖场','','','',0)
 --SET IDENTITY_INSERT [dbo].[t_aggregationtype]   OFF
 
 go
 
ALTER VIEW [dbo].[v_aggregation]
AS
SELECT a.id, t.thumb AS typethumb, t.url AS typeurl, t.title AS typetitle, t.parentid AS parent, a.type, a.title, a.title1, a.title2, a.title3, a.thumb, a.thumbw, a.thumbh, a.bannel, a.url, 
 a.descript, a.sort, a.hits, a.lastedittime, a.createmid, a.starttime, a.endtime
FROM dbo.t_aggregation AS a LEFT OUTER JOIN
 dbo.t_aggregationtype AS t ON a.type = t.id

--GO 
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g1.jpg',0,0,GETDATE())
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g2.jpg',0,0,GETDATE())
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g3.jpg',0,0,GETDATE())
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g4.jpg',0,0,GETDATE())
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g5.jpg',0,0,GETDATE())
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g6.jpg',0,0,GETDATE())
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g7.jpg',0,0,GETDATE())
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g8.jpg',0,0,GETDATE())
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g9.jpg',0,0,GETDATE())
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g10.jpg',0,0,GETDATE())
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g11.jpg',0,0,GETDATE())
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g12.jpg',0,0,GETDATE())
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g13.jpg',0,0,GETDATE())
--insert into dbo.t_aggregation ([type],title,url,thumb,sort,hits,lastedittime) values(50,'','','g14.jpg',0,0,GETDATE())
--go
--insert into dbo.t_aggregation ([type],title,title1,title2,url,thumb,sort,hits,lastedittime,starttime,endtime) values(51,'','3000','1500','','h18.jpg',0,0,GETDATE(),'2015-1-24 12:30:30','2015-2-1 12:30:30')
--insert into dbo.t_aggregation ([type],title,title1,title2,url,thumb,sort,hits,lastedittime,starttime,endtime) values(51,'','3000','1500','','h20.jpg',0,0,GETDATE(),'2015-1-24 12:30:30','2015-2-1 12:30:30')
--insert into dbo.t_aggregation ([type],title,title1,title2,url,thumb,sort,hits,lastedittime,starttime,endtime) values(51,'','3000','1500','','h21.jpg',0,0,GETDATE(),'2015-1-24 12:30:30','2015-2-1 12:30:30')
--insert into dbo.t_aggregation ([type],title,title1,title2,url,thumb,sort,hits,lastedittime,starttime,endtime) values(51,'','3000','1500','','h22.jpg',0,0,GETDATE(),'2015-1-24 12:30:30','2015-2-1 12:30:30')
--insert into dbo.t_aggregation ([type],title,title1,title2,url,thumb,sort,hits,lastedittime,starttime,endtime) values(51,'','3000','1500','','h23.jpg',0,0,GETDATE(),'2015-1-24 12:30:30','2015-2-1 12:30:30')
--insert into dbo.t_aggregation ([type],title,title1,title2,url,thumb,sort,hits,lastedittime,starttime,endtime) values(51,'','3000','1500','','h24.jpg',0,0,GETDATE(),'2015-1-24 12:30:30','2015-2-1 12:30:30')
--go
--insert into dbo.t_aggregation ([type],title,title1,title2,url,thumb,sort,hits,lastedittime,starttime,endtime) values(52,'','3000','1500','','h18.jpg',0,0,GETDATE(),'2015-1-24 12:30:30','2015-2-1 12:30:30')
--insert into dbo.t_aggregation ([type],title,title1,title2,url,thumb,sort,hits,lastedittime,starttime,endtime) values(52,'','3000','1500','','h20.jpg',0,0,GETDATE(),'2015-1-24 12:30:30','2015-2-1 12:30:30')
--insert into dbo.t_aggregation ([type],title,title1,title2,url,thumb,sort,hits,lastedittime,starttime,endtime) values(52,'','3000','1500','','h21.jpg',0,0,GETDATE(),'2015-1-24 12:30:30','2015-2-1 12:30:30')
--insert into dbo.t_aggregation ([type],title,title1,title2,url,thumb,sort,hits,lastedittime,starttime,endtime) values(52,'','3000','1500','','h22.jpg',0,0,GETDATE(),'2015-1-24 12:30:30','2015-2-1 12:30:30')
--insert into dbo.t_aggregation ([type],title,title1,title2,url,thumb,sort,hits,lastedittime,starttime,endtime) values(52,'','3000','1500','','h23.jpg',0,0,GETDATE(),'2015-1-24 12:30:30','2015-2-1 12:30:30')
--insert into dbo.t_aggregation ([type],title,title1,title2,url,thumb,sort,hits,lastedittime,starttime,endtime) values(52,'','3000','1500','','h24.jpg',0,0,GETDATE(),'2015-1-24 12:30:30','2015-2-1 12:30:30')



  --update [t_aggregation] set thumb='h23_new.jpg' where ID=276
  --  update [t_aggregation] set thumb='h24_new.jpg' where ID=275
    
    
    
  --   update [t_aggregation] set title='朗尼 皮艺沙发LS-5001' where id=275
  --update [t_aggregation] set title='北欧E家卧房4件套A-8011' where id=276
  -- update [t_aggregation] set title='星耀 实木框架餐桌TF-01' where id=277
  --  update [t_aggregation] set title='欧莱思特 沙发0804-2' where id=278
  --   update [t_aggregation] set title='卡丁乐园 现代 儿童床（1ETWCC）全实木' where id=279
  --    update [t_aggregation] set title='爱凡香柏木 田园 床（QM-1）全实木' where id=280
      
      
  --     update [t_aggregation] set title='欧莱思特 实木餐椅1802-2A' where id=269
  --update [t_aggregation] set title='田园之家 实木FWA01床 ' where id=270
  -- update [t_aggregation] set title='欧莱思特 实木斗柜0801-9' where id=271
  --  update [t_aggregation] set title='欧莱思特 实木电视柜0804-6' where id=272
  --   update [t_aggregation] set title='简欧之尊 RF12卧室3件套' where id=273
  --    update [t_aggregation] set title='北欧E家 实木简欧 A-210双人床' where id=274
      
      
--产品属性添加活动字段 数据对应 t_promotionstype
alter table  dbo.t_productattribute add ProductAttributePromotion int 

--厂商注册用品牌信息
alter table  dbo.t_company add brandInfo Nvarchar(200)


--套组合产品添加活动字段 数据对应 t_promotionstype
alter table  dbo.GroupProduct add GroupProductPromotion int 
--套组合产品添加小类字段 数据对应 dbo.t_config
alter table  dbo.GroupProduct add smallCateId int 