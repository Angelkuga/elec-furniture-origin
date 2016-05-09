--  admin��̨�˵�
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
           ('��������','' ,'marketclique',27,2,'','@web/@admin/market/marketcliquelist.aspx',13,0,'',0)
GO
 

CREATE TABLE [dbo].[t_MarketClique](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[marketid] [int] NOT NULL,
	[title] [nvarchar](200) NULL,
	[chairman] [nvarchar](50) NULL,
	[chairmanOration] [nvarchar](1000) NULL,
	[descript] [ntext] NULL,
	[auditstatus] [smallint] NULL,
	[chairmanimg] [nvarchar](200) NULL,
	[thumbimg] [varchar](200) NULL,
	[infoimg] [varchar](200) NULL,
	[createmid] [int] NULL,
	[lastedittime] [datetime] NULL,
	[createtime] [datetime] NULL,
 CONSTRAINT [PK_t_MarketInfoGroup] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_MarketClique', @level2type=N'COLUMN',@level2name=N'marketid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_MarketClique', @level2type=N'COLUMN',@level2name=N'title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���³�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_MarketClique', @level2type=N'COLUMN',@level2name=N'chairman'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���³��´�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_MarketClique', @level2type=N'COLUMN',@level2name=N'chairmanOration'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_MarketClique', @level2type=N'COLUMN',@level2name=N'descript'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���״̬' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_MarketClique', @level2type=N'COLUMN',@level2name=N'auditstatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ŵ�ͼ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_MarketClique', @level2type=N'COLUMN',@level2name=N'infoimg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_MarketClique', @level2type=N'COLUMN',@level2name=N'createmid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����޸�ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_MarketClique', @level2type=N'COLUMN',@level2name=N'lastedittime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_MarketClique', @level2type=N'COLUMN',@level2name=N'createtime'
GO

 

CREATE TABLE [dbo].[t_MarketCliqueRef](
	[marketid] [int] NOT NULL,
	[marketcliqueid] [int] NOT NULL,
 CONSTRAINT [PK_t_MarketInfoGroupRef] PRIMARY KEY CLUSTERED 
(
	[marketid] ASC,
	[marketcliqueid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_MarketCliqueRef', @level2type=N'COLUMN',@level2name=N'marketid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_MarketCliqueRef', @level2type=N'COLUMN',@level2name=N'marketcliqueid'
GO



go

--112����ҳ�ϵ����ӵ����Ӧƽ̨�ĵ�ַ�𣬶��������ӹ���
-- ���λ��ʹ��[t_aggregation]�� 2015-3-4
--update [t_aggregation] set url= REPLACE(url,'http://jiajuks.com/','/')
--where id between 255 and 268
  
--update [t_aggregation] set url= REPLACE(url,'http://www.jiajuks.com/','/')
--where id between 268 and 280


--update [t_aggregation] set url= '#'
--where id in (270,271)