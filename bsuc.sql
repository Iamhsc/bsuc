USE [master]
GO
/****** Object:  Database [bsuc]    Script Date: 11/15/2018 00:50:56 ******/
CREATE DATABASE [bsuc] ON  PRIMARY 
( NAME = N'bsuc', FILENAME = N'C:\Users\imhsc\Desktop\bsuc\bsuc\App_Data\bsuc.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bsuc_log', FILENAME = N'C:\Users\imhsc\Desktop\bsuc\bsuc\App_Data\bsuc_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bsuc] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bsuc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bsuc] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [bsuc] SET ANSI_NULLS OFF
GO
ALTER DATABASE [bsuc] SET ANSI_PADDING OFF
GO
ALTER DATABASE [bsuc] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [bsuc] SET ARITHABORT OFF
GO
ALTER DATABASE [bsuc] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [bsuc] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [bsuc] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [bsuc] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [bsuc] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [bsuc] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [bsuc] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [bsuc] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [bsuc] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [bsuc] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [bsuc] SET  DISABLE_BROKER
GO
ALTER DATABASE [bsuc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [bsuc] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [bsuc] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [bsuc] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [bsuc] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [bsuc] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [bsuc] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [bsuc] SET  READ_WRITE
GO
ALTER DATABASE [bsuc] SET RECOVERY FULL
GO
ALTER DATABASE [bsuc] SET  MULTI_USER
GO
ALTER DATABASE [bsuc] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [bsuc] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'bsuc', N'ON'
GO
USE [bsuc]
GO
/****** Object:  Table [dbo].[b_user]    Script Date: 11/15/2018 00:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[b_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_type] [tinyint] NOT NULL,
	[username] [varchar](20) NULL,
	[salt] [varchar](12) NULL,
	[password] [varchar](64) NULL,
	[sex] [tinyint] NOT NULL,
	[birthday] [date] NULL,
	[ctime] [int] NOT NULL,
	[status] [tinyint] NOT NULL,
	[nickname] [varchar](20) NULL,
	[email] [varchar](20) NULL,
	[mobile] [varchar](20) NULL,
	[avatar] [varchar](50) NULL,
	[more] [varchar](50) NULL,
	[last_login_time] [int] NULL,
	[last_login_ip] [varchar](20) NULL,
 CONSTRAINT [PK_b_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户类型；1:超级管理员；2:管理员；3:用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'user_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'username'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'随机字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'salt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加密后密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别；0保密；1男；2女' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'ctime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态；0拉黑；1正常' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'nickname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更多' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'more'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'last_login_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次登录ip' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'b_user', @level2type=N'COLUMN',@level2name=N'last_login_ip'
GO
/****** Object:  Table [dbo].[b_menu]    Script Date: 11/15/2018 00:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[b_menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](20) NOT NULL,
	[url] [varchar](200) NULL,
	[parent_id] [int] NOT NULL,
	[sort] [int] NOT NULL,
	[system] [tinyint] NOT NULL,
	[nav] [tinyint] NOT NULL,
	[status] [tinyint] NOT NULL,
	[ctime] [int] NOT NULL,
 CONSTRAINT [PK_AdminMenu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_b_user_user_type]    Script Date: 11/15/2018 00:50:59 ******/
ALTER TABLE [dbo].[b_user] ADD  CONSTRAINT [DF_b_user_user_type]  DEFAULT ((3)) FOR [user_type]
GO
/****** Object:  Default [DF_b_user_sex]    Script Date: 11/15/2018 00:50:59 ******/
ALTER TABLE [dbo].[b_user] ADD  CONSTRAINT [DF_b_user_sex]  DEFAULT ((0)) FOR [sex]
GO
/****** Object:  Default [DF_b_user_ctime]    Script Date: 11/15/2018 00:50:59 ******/
ALTER TABLE [dbo].[b_user] ADD  CONSTRAINT [DF_b_user_ctime]  DEFAULT ((0)) FOR [ctime]
GO
/****** Object:  Default [DF_b_user_status]    Script Date: 11/15/2018 00:50:59 ******/
ALTER TABLE [dbo].[b_user] ADD  CONSTRAINT [DF_b_user_status]  DEFAULT ((1)) FOR [status]
GO
/****** Object:  Default [DF_b_user_last_login_time]    Script Date: 11/15/2018 00:50:59 ******/
ALTER TABLE [dbo].[b_user] ADD  CONSTRAINT [DF_b_user_last_login_time]  DEFAULT ((0)) FOR [last_login_time]
GO
/****** Object:  Default [DF_b_menu_parent_id]    Script Date: 11/15/2018 00:50:59 ******/
ALTER TABLE [dbo].[b_menu] ADD  CONSTRAINT [DF_b_menu_parent_id]  DEFAULT ((0)) FOR [parent_id]
GO
/****** Object:  Default [DF_b_menu_sort]    Script Date: 11/15/2018 00:50:59 ******/
ALTER TABLE [dbo].[b_menu] ADD  CONSTRAINT [DF_b_menu_sort]  DEFAULT ((0)) FOR [sort]
GO
/****** Object:  Default [DF_AdminMenu_system]    Script Date: 11/15/2018 00:50:59 ******/
ALTER TABLE [dbo].[b_menu] ADD  CONSTRAINT [DF_AdminMenu_system]  DEFAULT ((0)) FOR [system]
GO
/****** Object:  Default [DF_AdminMenu_nav]    Script Date: 11/15/2018 00:50:59 ******/
ALTER TABLE [dbo].[b_menu] ADD  CONSTRAINT [DF_AdminMenu_nav]  DEFAULT ((1)) FOR [nav]
GO
/****** Object:  Default [DF_AdminMenu_status]    Script Date: 11/15/2018 00:50:59 ******/
ALTER TABLE [dbo].[b_menu] ADD  CONSTRAINT [DF_AdminMenu_status]  DEFAULT ((1)) FOR [status]
GO
/****** Object:  Default [DF_AdminMenu_ctime]    Script Date: 11/15/2018 00:50:59 ******/
ALTER TABLE [dbo].[b_menu] ADD  CONSTRAINT [DF_AdminMenu_ctime]  DEFAULT ((0)) FOR [ctime]
GO
