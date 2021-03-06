/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2014
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [CallIT]
GO
/****** Object:  Table [dbo].[news]    Script Date: 9/2/2017 9:51:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[news](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[newsType] [nvarchar](10) NOT NULL,
	[newsText] [nvarchar](500) NULL,
	[newsImage] [nvarchar](100) NULL,
	[newImageBase] [ntext] NULL,
	[createBy] [nvarchar](50) NULL,
	[createDate] [datetime] NULL,
	[updateBy] [nvarchar](50) NULL,
	[updateDate] [datetime] NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_news] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
