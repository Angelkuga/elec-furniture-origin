/****** Object:  Table [dbo].[t_customer]    Script Date: 03/05/2015 10:19:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
-- 消费者用户
CREATE TABLE [dbo].[t_customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uname] [varchar](100) NULL,
	[upassword] [varchar](100) NULL,
	[unametype] [int] NULL,
	[ustatus] [int] NULL,
	[regtime] [datetime] NULL,
	[regip] [varchar](20) NULL,
 CONSTRAINT [PK_t_membercustomer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
 
 

/****** Object:  Table [dbo].[t_customeractive]    Script Date: 03/05/2015 10:24:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
-- 用户账号激活
CREATE TABLE [dbo].[t_customeractive](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[atext] [varchar](50) NULL,
	[acode] [varchar](50) NULL,
	[atype] [int] NULL,
	[createtime] [datetime] NULL,
	[astatus] [int] NULL,
 CONSTRAINT [PK_t_customeractive] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
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
           ('管理消费用户','' ,'mmcustomer',10,2,'','@web/@admin/member/customerlist.aspx',12,0,'',0)
GO
--  admin后台菜单
update t_menu set title='添加卖场' where id=40
