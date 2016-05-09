--删除原计划文章信息相关表
drop table t_article,t_article_data,t_article_node
--新建文章信息表及信息分类表
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_article]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_article](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[attribute] [varchar](30) NULL,
	[title] [nvarchar](60) NOT NULL,
	[subtitle] [nvarchar](30) NULL,
	[letter] [varchar](50) NULL,
	[categoryid] [int] NOT NULL,
	[subcategoryid] [varchar](50) NULL,
	[ico] [varchar](30) NULL,
	[thumb] [varchar](30) NULL,
	[banner] [varchar](300) NULL,
	[keyword] [nvarchar](100) NULL,
	[descript] [nvarchar](300) NULL,
	[context] [text] NULL,
	[othercon] [varchar](600) NULL,
	[source] [nvarchar](30) NULL,
	[autho] [nvarchar](30) NULL,
	[linkurl] [varchar](200) NULL,
	[clickcount] [int] NULL CONSTRAINT [DF_t_article_clickcount]  DEFAULT ((0)),
	[sort] [int] NULL CONSTRAINT [DF_t_article_sort]  DEFAULT ((0)),
	[createtime] [datetime] NULL,
	[createid] [int] NULL CONSTRAINT [DF_t_article_createid]  DEFAULT ((0)),
	[edittime] [datetime] NULL CONSTRAINT [DF_t_article_edittime]  DEFAULT (getdate()),
	[editid] [int] NULL CONSTRAINT [DF_t_article_editid]  DEFAULT ((0)),
 CONSTRAINT [PK_t_article] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_articlecategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[t_articlecategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[attribute] [varchar](30) NULL,
	[title] [nvarchar](60) NOT NULL,
	[subtitle] [nvarchar](30) NULL,
	[letter] [varchar](50) NULL,
	[ico] [varchar](30) NULL,
	[thumb] [varchar](30) NULL,
	[banner] [varchar](300) NULL,
	[keyword] [nvarchar](100) NULL,
	[descript] [nvarchar](300) NULL,
	[context] [ntext] NULL,
	[othercon] [varchar](600) NULL,
	[linktype] [int] NULL,
	[linkurl] [varchar](200) NULL,
	[parentid] [int] NOT NULL,
	[lft] [int] NULL,
	[rgt] [int] NULL,
	[depth] [varchar](500) NULL,
	[lev] [int] NULL,
	[indextemplate] [varchar](60) NULL,
	[listtemplate] [varchar](60) NULL,
	[contemplate] [varchar](60) NULL,
	[sort] [int] NULL CONSTRAINT [DF_t_articlecategory_sort]  DEFAULT ((0)),
	[createtime] [datetime] NULL,
	[createid] [int] NULL CONSTRAINT [DF_t_articlecategory_createid]  DEFAULT ((0)),
	[edittime] [datetime] NULL CONSTRAINT [DF_t_articlecategory_edittime]  DEFAULT (getdate()),
	[editid] [int] NULL CONSTRAINT [DF_t_articlecategory_editid]  DEFAULT ((0)),
 CONSTRAINT [PK_t_articlecategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tr_t_articlecategory]'))
EXEC dbo.sp_executesql @statement = N'
create trigger [dbo].[tr_t_articlecategory] on [dbo].[t_articlecategory]
for insert
as 
begin 
--update t_member set type=101 from t_member as m, inserted as i where m.id=i.mid
declare @parentid int,@lft int,@rgt int,@lev int,@plev int,@depth varchar(200),@pdepth varchar(200),@id int, @MaxRgt int
select @parentid=parentid,@lft=lft,@rgt=rgt,@lev=lev,@depth=depth,@id=id from inserted

--判断存在数据
if (exists (select top 1 id from t_articlecategory)) 
    begin
	   --判断是否顶级
	   if(@parentid=0)
		begin
			select @MaxRgt=max(rgt) from t_articlecategory
			update t_articlecategory set parentid=@parentid,lev=1,depth='''',lft=@MaxRgt+1,rgt=@MaxRgt+2 where id=@id
		end
	   else
		begin
			--添加子级
		   SET XACT_ABORT ON	
		   BEGIN TRANSACTION
			select @rgt=rgt,@plev=lev,@pdepth=depth from t_articlecategory where id=@parentid
			update t_articlecategory set rgt=rgt+2 where rgt>=@rgt
			update t_articlecategory set lft=lft+2 where lft>=@rgt

			update t_articlecategory set parentid=@parentid,lev=@plev+1,depth=@pdepth+CAST(@id as varchar(200))+'','',lft=@rgt,rgt=@rgt+1 where id=@id

			COMMIT TRANSACTION
		   SET XACT_ABORT OFF
		end
    end
else
	begin
		--添加第一条数据   
	update t_articlecategory set parentid=@parentid,lev=1,depth='''',lft=1,rgt=2 where id=@id
	end
end

' 
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tr_t_articlecategory_deleted]'))
EXEC dbo.sp_executesql @statement = N'
create trigger [dbo].[tr_t_articlecategory_deleted] on [dbo].[t_articlecategory]
for delete
as 
begin 
declare @lft int,@cid int,@rgt int,@rows int
set @rows=0
select @cid=id,@lft=lft,@rgt=rgt from deleted
if (@cid>0)
     begin
        SET XACT_ABORT ON
        BEGIN TRANSACTION
         delete from t_articlecategory where lft>=@lft and rgt<=@rgt
	     set @rows=@@rowcount
         update t_articlecategory set lft=lft-(@rgt-@lft+1) where lft>@lft
		 set @rows=@rows+@@rowcount
         update t_articlecategory set rgt=rgt-(@rgt-@lft+1) where rgt>@rgt
		set @rows=@rows+@@rowcount
         COMMIT TRANSACTION
        SET XACT_ABORT OFF    
End
select @rows


end

' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MoveArticleNodeUp]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[MoveArticleNodeUp] 
    @id int
AS
declare @lft int
declare @rgt int
declare @layer int
if exists (select 1 from t_articlecategory where id=@id)
    begin
       SET XACT_ABORT ON
       BEGIN TRANSACTION
        select @lft=lft,@rgt=rgt,@layer=lev from t_articlecategory where id=@id
        if exists (select * from t_articlecategory where rgt=@lft-1 and lev=@layer)
           begin
               declare @brother_lft int
               declare @brother_rgt int
               select @brother_lft=lft,@brother_rgt=rgt from t_articlecategory where rgt=@lft-1 and lev=@layer
               update t_articlecategory set lft=lft-(@brother_rgt-@brother_lft+1) where lft>=@lft and rgt<=@rgt
               update t_articlecategory set lft=lft+(@rgt-@lft+1) where lft>=@brother_lft and rgt<=@brother_rgt
               update t_articlecategory set rgt=rgt-(@brother_rgt-@brother_lft+1) where rgt>@brother_rgt and rgt<=@rgt
               update t_articlecategory set rgt=rgt+(@rgt-@lft+1) where lft>=@brother_lft+(@rgt-@lft+1) and rgt<=@brother_rgt
           end
        COMMIT TRANSACTION
       SET XACT_ABORT OFF    
    end' 
END

GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[v_article]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[v_article]
AS
SELECT     a.id, a.attribute, a.title, a.subtitle, a.letter, a.categoryid, a.subcategoryid, a.ico, a.thumb, a.banner, a.keyword, a.descript, a.context, a.othercon, 
                      a.source, a.autho, a.linkurl, a.clickcount, a.sort, a.createtime, a.createid, a.edittime, a.editid, c.letter AS cletter
FROM         dbo.t_article AS a LEFT OUTER JOIN
                      dbo.t_articlecategory AS c ON a.categoryid = c.id
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'v_article', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 186
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 224
               Bottom = 114
               Right = 372
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 52
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_article'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'v_article', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_article'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'v_article', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_article'
---