USE [basedb]
GO
/****** Object:  User [IIS APPPOOL\POSAPI]    Script Date: 03/20/2022 5:35:35 PM ******/
CREATE USER [IIS APPPOOL\POSAPI] FOR LOGIN [IIS APPPOOL\POSAPI] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\POSAPI]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [IIS APPPOOL\POSAPI]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [IIS APPPOOL\POSAPI]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [IIS APPPOOL\POSAPI]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [IIS APPPOOL\POSAPI]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\POSAPI]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\POSAPI]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [IIS APPPOOL\POSAPI]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [IIS APPPOOL\POSAPI]
GO
/****** Object:  Table [dbo].[agentMemberships]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[agentMemberships](
	[agentMembershipsId] [int] IDENTITY(1,1) NOT NULL,
	[subscriptionFeesId] [int] NULL,
	[cashTransId] [int] NULL,
	[membershipId] [int] NULL,
	[agentId] [int] NULL,
	[startDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
	[notes] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
 CONSTRAINT [PK_agentMemberships] PRIMARY KEY CLUSTERED 
(
	[agentMembershipsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[agents](
	[agentId] [int] IDENTITY(1,1) NOT NULL,
	[pointId] [int] NULL,
	[name] [nvarchar](100) NULL,
	[code] [nvarchar](100) NULL,
	[company] [nvarchar](100) NULL,
	[address] [ntext] NULL,
	[email] [nvarchar](200) NULL,
	[phone] [nvarchar](100) NULL,
	[mobile] [nvarchar](100) NULL,
	[image] [ntext] NULL,
	[type] [nvarchar](50) NULL,
	[accType] [nvarchar](50) NULL,
	[balance] [decimal](20, 3) NULL,
	[balanceType] [tinyint] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[notes] [ntext] NULL,
	[isActive] [tinyint] NULL,
	[fax] [nvarchar](100) NULL,
	[maxDeserve] [decimal](20, 3) NULL,
	[isLimited] [bit] NOT NULL,
	[payType] [nvarchar](20) NULL,
 CONSTRAINT [PK_agents] PRIMARY KEY CLUSTERED 
(
	[agentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[banks](
	[bankId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[phone] [nvarchar](100) NULL,
	[mobile] [nvarchar](100) NULL,
	[address] [nvarchar](100) NULL,
	[accNumber] [nvarchar](100) NULL,
	[notes] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
 CONSTRAINT [PK_banks] PRIMARY KEY CLUSTERED 
(
	[bankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bondes]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bondes](
	[bondId] [int] IDENTITY(1,1) NOT NULL,
	[number] [nvarchar](200) NULL,
	[amount] [decimal](20, 3) NULL,
	[deserveDate] [datetime2](7) NULL,
	[type] [nvarchar](50) NULL,
	[isRecieved] [tinyint] NULL,
	[notes] [ntext] NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[updateDate] [datetime2](7) NULL,
	[createDate] [datetime2](7) NULL,
	[isActive] [tinyint] NULL,
	[cashTransId] [int] NULL,
 CONSTRAINT [PK_bondes] PRIMARY KEY CLUSTERED 
(
	[bondId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[branches]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[branches](
	[branchId] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](100) NULL,
	[name] [nvarchar](100) NULL,
	[address] [ntext] NULL,
	[email] [nvarchar](200) NULL,
	[phone] [nvarchar](100) NULL,
	[mobile] [nvarchar](100) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[notes] [ntext] NULL,
	[parentId] [int] NULL,
	[isActive] [tinyint] NULL,
	[type] [nvarchar](50) NULL,
 CONSTRAINT [PK_branches] PRIMARY KEY CLUSTERED 
(
	[branchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[branchesUsers](
	[branchsUsersId] [int] IDENTITY(1,1) NOT NULL,
	[branchId] [int] NULL,
	[userId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_branchesUsers] PRIMARY KEY CLUSTERED 
(
	[branchsUsersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[branchStore]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[branchStore](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[branchId] [int] NULL,
	[storeId] [int] NULL,
	[note] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [int] NULL,
 CONSTRAINT [PK_branchStore] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cards]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cards](
	[cardId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[notes] [nvarchar](50) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
	[image] [ntext] NULL,
	[hasProcessNum] [bit] NULL,
 CONSTRAINT [PK_cards] PRIMARY KEY CLUSTERED 
(
	[cardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cashTransfer](
	[cashTransId] [int] IDENTITY(1,1) NOT NULL,
	[agentMembershipsId] [int] NULL,
	[transType] [nvarchar](50) NULL,
	[posId] [int] NULL,
	[userId] [int] NULL,
	[agentId] [int] NULL,
	[invId] [int] NULL,
	[transNum] [nvarchar](50) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[cash] [decimal](20, 3) NULL,
	[updateUserId] [int] NULL,
	[createUserId] [int] NULL,
	[notes] [ntext] NULL,
	[posIdCreator] [int] NULL,
	[isConfirm] [tinyint] NULL,
	[cashTransIdSource] [int] NULL,
	[side] [nvarchar](50) NULL,
	[docName] [nvarchar](100) NULL,
	[docNum] [nvarchar](100) NULL,
	[docImage] [ntext] NULL,
	[bankId] [int] NULL,
	[processType] [nvarchar](50) NULL,
	[cardId] [int] NULL,
	[bondId] [int] NULL,
	[shippingCompanyId] [int] NULL,
 CONSTRAINT [PK_cashTransfer] PRIMARY KEY CLUSTERED 
(
	[cashTransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[categoryId] [int] IDENTITY(1,1) NOT NULL,
	[categoryCode] [nvarchar](100) NULL,
	[name] [nvarchar](100) NULL,
	[details] [ntext] NULL,
	[image] [ntext] NULL,
	[isActive] [smallint] NULL,
	[taxes] [decimal](20, 3) NULL,
	[parentId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[notes] [ntext] NULL,
	[fixedTax] [tinyint] NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoryuser]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoryuser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[categoryId] [int] NULL,
	[userId] [int] NULL,
	[sequence] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_categoryuser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cities](
	[cityId] [int] IDENTITY(1,1) NOT NULL,
	[cityCode] [nvarchar](50) NULL,
	[countryId] [int] NULL,
 CONSTRAINT [PK_cities] PRIMARY KEY CLUSTERED 
(
	[cityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[countriesCodes](
	[countryId] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](50) NOT NULL,
	[currency] [nvarchar](50) NULL,
	[name] [nvarchar](100) NULL,
	[isDefault] [tinyint] NOT NULL,
	[currencyId] [int] NOT NULL,
 CONSTRAINT [PK_countriesCodes] PRIMARY KEY CLUSTERED 
(
	[countryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[coupons]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[coupons](
	[cId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[code] [nvarchar](100) NULL,
	[isActive] [tinyint] NULL,
	[discountType] [tinyint] NULL,
	[discountValue] [decimal](20, 3) NULL,
	[startDate] [datetime2](7) NULL,
	[endDate] [datetime2](7) NULL,
	[notes] [ntext] NULL,
	[quantity] [int] NULL,
	[remainQ] [int] NULL,
	[invMin] [decimal](20, 3) NULL,
	[invMax] [decimal](20, 3) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[barcode] [nvarchar](200) NULL,
 CONSTRAINT [PK_coupons] PRIMARY KEY CLUSTERED 
(
	[cId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[couponsInvoices](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[couponId] [int] NULL,
	[InvoiceId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[discountValue] [decimal](20, 3) NULL,
	[discountType] [tinyint] NULL,
 CONSTRAINT [PK_couponsInvoices] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[docImages]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[docImages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[docName] [nvarchar](200) NULL,
	[docnum] [nvarchar](200) NULL,
	[image] [ntext] NULL,
	[tableName] [nvarchar](100) NULL,
	[note] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[tableId] [int] NULL,
 CONSTRAINT [PK_docImages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[error]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[error](
	[errorId] [int] IDENTITY(1,1) NOT NULL,
	[num] [nvarchar](200) NULL,
	[msg] [ntext] NULL,
	[stackTrace] [ntext] NULL,
	[targetSite] [ntext] NULL,
	[posId] [int] NULL,
	[branchId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
 CONSTRAINT [PK_error] PRIMARY KEY CLUSTERED 
(
	[errorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[exId] [int] IDENTITY(1,1) NOT NULL,
	[expense] [ntext] NULL,
	[note] [ntext] NULL,
	[isActive] [tinyint] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_Expenses] PRIMARY KEY CLUSTERED 
(
	[exId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[groupObject]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[groupObject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[groupId] [int] NULL,
	[objectId] [int] NULL,
	[notes] [ntext] NULL,
	[addOb] [tinyint] NOT NULL,
	[updateOb] [tinyint] NOT NULL,
	[deleteOb] [tinyint] NOT NULL,
	[showOb] [tinyint] NOT NULL,
	[reportOb] [tinyint] NOT NULL,
	[levelOb] [tinyint] NOT NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [int] NULL,
 CONSTRAINT [PK_groupObject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[groups](
	[groupId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[notes] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [int] NULL,
 CONSTRAINT [PK_groups] PRIMARY KEY CLUSTERED 
(
	[groupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[inventoryId] [int] IDENTITY(1,1) NOT NULL,
	[num] [nvarchar](200) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
	[notes] [ntext] NULL,
	[inventoryType] [nvarchar](10) NULL,
	[branchId] [int] NULL,
	[posId] [int] NULL,
	[mainInventoryId] [int] NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[inventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inventoryItemLocation]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inventoryItemLocation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[isDestroyed] [bit] NULL,
	[amount] [int] NULL,
	[amountDestroyed] [int] NULL,
	[realAmount] [int] NULL,
	[itemLocationId] [int] NULL,
	[inventoryId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
	[notes] [ntext] NULL,
	[cause] [ntext] NULL,
	[isFalls] [bit] NOT NULL,
	[fallCause] [ntext] NULL,
 CONSTRAINT [PK_inventoryItemLocation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoiceOrder]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoiceOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[invoiceId] [int] NULL,
	[orderId] [int] NULL,
	[quantity] [int] NULL,
	[itemsTransferId] [int] NULL,
 CONSTRAINT [PK_invoiceOrder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoices](
	[invoiceId] [int] IDENTITY(1,1) NOT NULL,
	[invNumber] [nvarchar](100) NULL,
	[agentId] [int] NULL,
	[createUserId] [int] NULL,
	[invType] [nvarchar](50) NULL,
	[discountType] [nvarchar](10) NULL,
	[discountValue] [decimal](20, 3) NULL,
	[total] [decimal](20, 3) NULL,
	[totalNet] [decimal](20, 3) NULL,
	[paid] [decimal](20, 3) NULL,
	[deserved] [decimal](20, 3) NULL,
	[deservedDate] [date] NULL,
	[invDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[updateUserId] [int] NULL,
	[invoiceMainId] [int] NULL,
	[invCase] [nvarchar](50) NULL,
	[invTime] [time](7) NULL,
	[notes] [ntext] NULL,
	[vendorInvNum] [nvarchar](100) NULL,
	[vendorInvDate] [datetime2](7) NULL,
	[branchId] [int] NULL,
	[posId] [int] NULL,
	[tax] [decimal](20, 3) NULL,
	[taxtype] [int] NULL,
	[name] [nvarchar](200) NULL,
	[isApproved] [tinyint] NULL,
	[shippingCompanyId] [int] NULL,
	[branchCreatorId] [int] NULL,
	[shipUserId] [int] NULL,
	[prevStatus] [nvarchar](10) NULL,
	[userId] [int] NULL,
	[manualDiscountValue] [decimal](20, 3) NOT NULL,
	[manualDiscountType] [nvarchar](10) NULL,
	[isActive] [bit] NOT NULL,
	[invoiceProfit] [decimal](20, 3) NULL,
	[cashReturn] [decimal](20, 3) NOT NULL,
	[printedcount] [int] NOT NULL,
	[isOrginal] [bit] NOT NULL,
	[shippingCost] [decimal](20, 3) NOT NULL,
	[realShippingCost] [decimal](20, 3) NOT NULL,
 CONSTRAINT [PK_invoices] PRIMARY KEY CLUSTERED 
(
	[invoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoiceStatus]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoiceStatus](
	[invStatusId] [int] IDENTITY(1,1) NOT NULL,
	[invoiceId] [int] NULL,
	[status] [nvarchar](50) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[notes] [ntext] NULL,
	[isActive] [tinyint] NULL,
 CONSTRAINT [PK_invoiceStatus] PRIMARY KEY CLUSTERED 
(
	[invStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[items]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[items](
	[itemId] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](50) NULL,
	[name] [nvarchar](200) NULL,
	[details] [ntext] NULL,
	[type] [nvarchar](50) NOT NULL,
	[image] [ntext] NULL,
	[taxes] [decimal](20, 3) NULL,
	[isActive] [tinyint] NULL,
	[min] [int] NULL,
	[max] [int] NULL,
	[categoryId] [int] NULL,
	[parentId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[minUnitId] [int] NULL,
	[maxUnitId] [int] NULL,
	[avgPurchasePrice] [decimal](20, 3) NULL,
 CONSTRAINT [PK_items] PRIMARY KEY CLUSTERED 
(
	[itemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemsLocations](
	[itemsLocId] [int] IDENTITY(1,1) NOT NULL,
	[locationId] [int] NULL,
	[quantity] [bigint] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[startDate] [date] NULL,
	[endDate] [date] NULL,
	[itemUnitId] [int] NULL,
	[note] [ntext] NULL,
	[invoiceId] [int] NULL,
 CONSTRAINT [PK_itemsLocations] PRIMARY KEY CLUSTERED 
(
	[itemsLocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemsMaterials](
	[itemMatId] [int] IDENTITY(1,1) NOT NULL,
	[itemId] [int] NULL,
	[materialId] [int] NULL,
	[quantity] [decimal](20, 3) NULL,
	[unitId] [int] NULL,
	[price] [decimal](20, 2) NULL,
 CONSTRAINT [PK_itemsMaterials] PRIMARY KEY CLUSTERED 
(
	[itemMatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemsOffers](
	[ioId] [int] IDENTITY(1,1) NOT NULL,
	[iuId] [int] NULL,
	[offerId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[quantity] [int] NULL,
	[used] [int] NULL,
 CONSTRAINT [PK_itemsOffers] PRIMARY KEY CLUSTERED 
(
	[ioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsProp]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemsProp](
	[itemPropId] [int] IDENTITY(1,1) NOT NULL,
	[propertyItemId] [int] NULL,
	[itemId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_itemsProp] PRIMARY KEY CLUSTERED 
(
	[itemPropId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemsTransfer](
	[itemsTransId] [int] IDENTITY(1,1) NOT NULL,
	[quantity] [bigint] NULL,
	[invoiceId] [int] NULL,
	[locationIdNew] [int] NULL,
	[locationIdOld] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[notes] [ntext] NULL,
	[price] [decimal](20, 3) NULL,
	[itemUnitId] [int] NULL,
	[itemSerial] [nvarchar](200) NOT NULL,
	[inventoryItemLocId] [int] NULL,
	[offerId] [int] NULL,
	[profit] [decimal](20, 3) NULL,
	[purchasePrice] [decimal](20, 3) NULL,
	[cause] [nvarchar](500) NULL,
	[itemTax] [decimal](20, 3) NULL,
	[itemUnitPrice] [decimal](20, 3) NULL,
	[offerValue] [decimal](20, 3) NULL,
	[offerType] [decimal](20, 3) NULL,
 CONSTRAINT [PK_itemsTransfer] PRIMARY KEY CLUSTERED 
(
	[itemsTransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemsUnits](
	[itemUnitId] [int] IDENTITY(1,1) NOT NULL,
	[itemId] [int] NULL,
	[unitId] [int] NULL,
	[unitValue] [int] NULL,
	[defaultSale] [smallint] NULL,
	[defaultPurchase] [smallint] NULL,
	[price] [decimal](20, 3) NULL,
	[barcode] [nvarchar](200) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[subUnitId] [int] NULL,
	[purchasePrice] [decimal](20, 3) NULL,
	[storageCostId] [int] NULL,
	[isActive] [tinyint] NULL,
	[cost] [decimal](20, 3) NULL,
 CONSTRAINT [PK_itemsUnits] PRIMARY KEY CLUSTERED 
(
	[itemUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemTransferOffer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[itemTransId] [int] NULL,
	[offerId] [int] NULL,
	[discountType] [nvarchar](100) NULL,
	[discountValue] [decimal](20, 3) NULL,
	[notes] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_itemTransferOffer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemUnitUser]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemUnitUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[itemUnitId] [int] NULL,
	[userId] [int] NULL,
	[notes] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
 CONSTRAINT [PK_itemUnitUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[locations](
	[locationId] [int] IDENTITY(1,1) NOT NULL,
	[x] [nvarchar](100) NULL,
	[y] [nvarchar](100) NULL,
	[z] [nvarchar](100) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
	[sectionId] [int] NULL,
	[note] [ntext] NULL,
	[branchId] [int] NULL,
	[isFreeZone] [tinyint] NULL,
 CONSTRAINT [PK_locations] PRIMARY KEY CLUSTERED 
(
	[locationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medalAgent]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medalAgent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[medalId] [int] NULL,
	[agentId] [int] NULL,
	[notes] [ntext] NULL,
	[isActive] [tinyint] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_medalAgent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medals]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medals](
	[medalId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[symbol] [ntext] NULL,
	[CashPointsRequired] [int] NULL,
	[invoiceCountPointsRequired] [int] NULL,
	[isActive] [tinyint] NULL,
	[notes] [ntext] NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_medals] PRIMARY KEY CLUSTERED 
(
	[medalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[memberships]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[memberships](
	[membershipId] [int] NOT NULL,
	[name] [nvarchar](100) NULL,
	[deliveryDiscount] [decimal](20, 3) NULL,
	[deliveryDiscountType] [nvarchar](100) NULL,
	[invoiceDiscount] [decimal](20, 3) NULL,
	[invoiceDiscountType] [nvarchar](100) NULL,
	[notes] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
 CONSTRAINT [PK_memberships] PRIMARY KEY CLUSTERED 
(
	[membershipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[notification]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notification](
	[notId] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](500) NULL,
	[ncontent] [nvarchar](1000) NULL,
	[side] [nvarchar](10) NULL,
	[msgType] [nvarchar](10) NULL,
	[path] [nvarchar](500) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
 CONSTRAINT [PK_notification] PRIMARY KEY CLUSTERED 
(
	[notId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[notificationUser]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notificationUser](
	[notUserId] [int] IDENTITY(1,1) NOT NULL,
	[notId] [int] NULL,
	[userId] [int] NULL,
	[isRead] [bit] NOT NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[posId] [int] NULL,
 CONSTRAINT [PK_notificationUser] PRIMARY KEY CLUSTERED 
(
	[notUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[objects]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[objects](
	[objectId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[note] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [int] NULL,
	[parentObjectId] [int] NULL,
	[objectType] [nvarchar](10) NULL,
 CONSTRAINT [PK_objects] PRIMARY KEY CLUSTERED 
(
	[objectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[offers]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[offers](
	[offerId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[code] [nvarchar](100) NULL,
	[isActive] [tinyint] NULL,
	[discountType] [nvarchar](100) NULL,
	[discountValue] [decimal](20, 3) NULL,
	[startDate] [datetime2](7) NULL,
	[endDate] [datetime2](7) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[notes] [ntext] NULL,
 CONSTRAINT [PK_offers] PRIMARY KEY CLUSTERED 
(
	[offerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[packages]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[packages](
	[packageId] [int] IDENTITY(1,1) NOT NULL,
	[parentIUId] [int] NULL,
	[childIUId] [int] NULL,
	[quantity] [int] NOT NULL,
	[isActive] [tinyint] NOT NULL,
	[notes] [ntext] NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_packages] PRIMARY KEY CLUSTERED 
(
	[packageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[paperSize]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paperSize](
	[sizeId] [int] IDENTITY(1,1) NOT NULL,
	[paperSize] [nvarchar](200) NULL,
	[printfor] [nvarchar](200) NULL,
	[sizeValue] [nvarchar](200) NULL,
 CONSTRAINT [PK_paperSize] PRIMARY KEY CLUSTERED 
(
	[sizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Points]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Points](
	[pointId] [int] NOT NULL,
	[Cash] [decimal](20, 3) NULL,
	[CashPoints] [int] NULL,
	[invoiceCount] [int] NULL,
	[invoiceCountPoints] [int] NULL,
	[CashArchive] [decimal](20, 3) NULL,
	[CashPointsArchive] [int] NULL,
	[invoiceCountArchive] [int] NULL,
	[invoiceCountPoinstArchive] [int] NULL,
	[notes] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
	[agentId] [int] NULL,
 CONSTRAINT [PK_Points] PRIMARY KEY CLUSTERED 
(
	[pointId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pos]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pos](
	[posId] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](100) NULL,
	[name] [nvarchar](100) NULL,
	[balance] [decimal](20, 3) NULL,
	[branchId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
	[note] [ntext] NULL,
	[balanceAll] [decimal](20, 3) NULL,
	[boxState] [nvarchar](20) NULL,
	[isAdminClose] [tinyint] NOT NULL,
 CONSTRAINT [PK_pos] PRIMARY KEY CLUSTERED 
(
	[posId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posSerials]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posSerials](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[posSerial] [nvarchar](300) NULL,
	[notes] [nvarchar](300) NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_posSerials] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posSetting]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posSetting](
	[posSettingId] [int] IDENTITY(1,1) NOT NULL,
	[posId] [int] NULL,
	[saleInvPrinterId] [int] NULL,
	[reportPrinterId] [int] NULL,
	[saleInvPapersizeId] [int] NULL,
	[posSerial] [nvarchar](1000) NULL,
	[docPapersizeId] [int] NULL,
	[posDeviceCode] [nvarchar](500) NULL,
	[posSerialId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_posSetting] PRIMARY KEY CLUSTERED 
(
	[posSettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posUsers]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posUsers](
	[posUserId] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[posId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_posUsers] PRIMARY KEY CLUSTERED 
(
	[posUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[printers]    Script Date: 03/20/2022 5:35:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[printers](
	[printerId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](500) NULL,
	[printFor] [nvarchar](50) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_printers] PRIMARY KEY CLUSTERED 
(
	[printerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramDetails]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramDetails](
	[id] [int] NOT NULL,
	[programName] [nvarchar](500) NULL,
	[branchCount] [int] NOT NULL,
	[posCount] [int] NOT NULL,
	[userCount] [int] NOT NULL,
	[vendorCount] [int] NOT NULL,
	[customerCount] [int] NOT NULL,
	[itemCount] [int] NOT NULL,
	[saleinvCount] [int] NOT NULL,
	[programIncId] [int] NULL,
	[versionIncId] [int] NULL,
	[versionName] [nvarchar](500) NULL,
	[storeCount] [int] NOT NULL,
	[packageSaleCode] [nvarchar](500) NULL,
	[customerServerCode] [nvarchar](500) NULL,
	[expireDate] [datetime2](7) NULL,
	[isOnlineServer] [bit] NULL,
	[packageNumber] [nvarchar](500) NULL,
	[updateDate] [datetime2](7) NULL,
	[isLimitDate] [bit] NULL,
	[isLimitCount] [bit] NULL,
	[isActive] [bit] NOT NULL,
	[packageName] [nvarchar](500) NULL,
	[bookDate] [datetime2](7) NULL,
	[pId] [int] NULL,
	[pcdId] [int] NULL,
	[customerName] [nvarchar](500) NULL,
	[customerLastName] [nvarchar](500) NULL,
	[agentName] [nvarchar](500) NULL,
	[agentLastName] [nvarchar](500) NULL,
	[agentAccountName] [nvarchar](500) NULL,
	[isServerActivated] [bit] NOT NULL,
	[activatedate] [datetime2](7) NULL,
	[pocrDate] [datetime2](7) NULL,
	[poId] [int] NULL,
	[upnum] [nvarchar](500) NULL,
	[notes] [nvarchar](500) NULL,
 CONSTRAINT [PK_ProgramDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[properties]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[properties](
	[propertyId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
 CONSTRAINT [PK_properties] PRIMARY KEY CLUSTERED 
(
	[propertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[propertiesItems](
	[propertyItemId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[propertyId] [int] NULL,
	[isDefault] [smallint] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
 CONSTRAINT [PK_propertiesItems] PRIMARY KEY CLUSTERED 
(
	[propertyItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sections]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sections](
	[sectionId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[branchId] [int] NULL,
	[isActive] [tinyint] NULL,
	[note] [ntext] NULL,
	[isFreeZone] [tinyint] NULL,
 CONSTRAINT [PK_sections] PRIMARY KEY CLUSTERED 
(
	[sectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[serials]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[serials](
	[serialId] [int] IDENTITY(1,1) NOT NULL,
	[itemId] [int] NULL,
	[serialNum] [nvarchar](200) NULL,
	[isActive] [tinyint] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_serials] PRIMARY KEY CLUSTERED 
(
	[serialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servicesCosts](
	[costId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[costVal] [decimal](20, 3) NULL,
	[itemId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_servicesCosts] PRIMARY KEY CLUSTERED 
(
	[costId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[setting](
	[settingId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[notes] [ntext] NULL,
 CONSTRAINT [PK_setting] PRIMARY KEY CLUSTERED 
(
	[settingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[setValues]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[setValues](
	[valId] [int] IDENTITY(1,1) NOT NULL,
	[value] [ntext] NULL,
	[isDefault] [int] NULL,
	[isSystem] [int] NULL,
	[notes] [ntext] NULL,
	[settingId] [int] NULL,
 CONSTRAINT [PK_setValues] PRIMARY KEY CLUSTERED 
(
	[valId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shippingCompanies]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shippingCompanies](
	[shippingCompanyId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NULL,
	[RealDeliveryCost] [decimal](20, 3) NULL,
	[deliveryCost] [decimal](20, 3) NULL,
	[deliveryType] [nvarchar](100) NULL,
	[notes] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
	[balance] [decimal](20, 3) NOT NULL,
	[balanceType] [tinyint] NULL,
	[email] [nvarchar](200) NULL,
	[phone] [nvarchar](100) NULL,
	[mobile] [nvarchar](100) NULL,
	[fax] [nvarchar](100) NULL,
	[address] [ntext] NULL,
 CONSTRAINT [PK_shippingCompanies] PRIMARY KEY CLUSTERED 
(
	[shippingCompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[storageCost]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[storageCost](
	[storageCostId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[cost] [decimal](20, 3) NOT NULL,
	[note] [ntext] NULL,
	[isActive] [tinyint] NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_storageCost] PRIMARY KEY CLUSTERED 
(
	[storageCostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subscriptionFees]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subscriptionFees](
	[subscriptionFeesId] [int] NOT NULL,
	[membershipId] [int] NULL,
	[monthsCount] [int] NULL,
	[Amount] [decimal](20, 3) NULL,
	[notes] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
 CONSTRAINT [PK_subscriptionFees] PRIMARY KEY CLUSTERED 
(
	[subscriptionFeesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysEmails]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysEmails](
	[emailId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[port] [int] NULL,
	[isSSL] [bit] NULL,
	[smtpClient] [nvarchar](100) NULL,
	[side] [nvarchar](100) NULL,
	[notes] [nvarchar](100) NULL,
	[branchId] [int] NULL,
	[isActive] [tinyint] NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[isMajor] [bit] NULL,
 CONSTRAINT [PK_sysEmails] PRIMARY KEY CLUSTERED 
(
	[emailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[units]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[units](
	[unitId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[isSmallest] [smallint] NULL,
	[smallestId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[updateDate] [datetime2](7) NULL,
	[parentid] [int] NULL,
	[isActive] [tinyint] NULL,
	[notes] [nvarchar](100) NULL,
 CONSTRAINT [PK_units] PRIMARY KEY CLUSTERED 
(
	[unitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[name] [nvarchar](100) NULL,
	[lastname] [nvarchar](100) NULL,
	[job] [nvarchar](100) NULL,
	[workHours] [nvarchar](100) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[phone] [nvarchar](50) NULL,
	[mobile] [nvarchar](50) NULL,
	[email] [nvarchar](100) NULL,
	[address] [ntext] NULL,
	[isActive] [smallint] NULL,
	[notes] [ntext] NULL,
	[isOnline] [tinyint] NULL,
	[role] [nvarchar](50) NULL,
	[image] [ntext] NULL,
	[groupId] [int] NULL,
	[balance] [decimal](20, 3) NULL,
	[balanceType] [tinyint] NULL,
	[isAdmin] [bit] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userSetValues]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userSetValues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[valId] [int] NULL,
	[note] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_userSetValues] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usersLogs]    Script Date: 03/20/2022 5:35:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usersLogs](
	[logId] [int] IDENTITY(1,1) NOT NULL,
	[sInDate] [datetime2](7) NULL,
	[sOutDate] [datetime2](7) NULL,
	[posId] [int] NULL,
	[userId] [int] NULL,
 CONSTRAINT [PK_usersLogs] PRIMARY KEY CLUSTERED 
(
	[logId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[branches] ON 

INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (1, N'00', N'-', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, 1, N'bs')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (2, N'Main-00', N'Main', N'', N'', N'', N'+965-99999999', CAST(N'2021-06-29T15:23:22.3414329' AS DateTime2), CAST(N'2021-11-06T14:48:23.0368623' AS DateTime2), 1, 1, N'', 1, 1, N'b')
SET IDENTITY_INSERT [dbo].[branches] OFF
GO
SET IDENTITY_INSERT [dbo].[cards] ON 

INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [image], [hasProcessNum]) VALUES (1, N'Visa Card', N'', CAST(N'2021-10-27T17:16:10.0411383' AS DateTime2), CAST(N'2021-10-27T17:24:41.7960806' AS DateTime2), 1, 1, 1, N'57440ff6b80f068efd50410ea24fd593.png', 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [image], [hasProcessNum]) VALUES (2, N'Master Card', N'', CAST(N'2021-10-27T17:16:13.3548331' AS DateTime2), CAST(N'2021-11-04T16:19:20.6480239' AS DateTime2), 1, 1, 1, N'c37858823db0093766eee74d8ee1f1e5.png', 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [image], [hasProcessNum]) VALUES (3, N'K-net', N'', CAST(N'2021-10-27T17:17:01.4593550' AS DateTime2), CAST(N'2021-12-14T12:37:08.4934792' AS DateTime2), 1, 1, 1, N'71f020248a405d21e94d1de52043bed4.png', 1)
SET IDENTITY_INSERT [dbo].[cards] OFF
GO
SET IDENTITY_INSERT [dbo].[cities] ON 

INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (1, N'1', 2)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (2, N'2', 2)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (3, N'3', 2)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (4, N'4', 2)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (5, N'6', 2)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (6, N'7', 2)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (7, N'2', 4)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (8, N'3', 4)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (9, N'4', 4)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (10, N'6', 4)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (11, N'7', 4)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (12, N'9', 4)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (13, N'1', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (14, N'21', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (15, N'23', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (16, N'24', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (17, N'25', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (18, N'30', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (19, N'32', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (20, N'33', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (21, N'36', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (22, N'37', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (23, N'40', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (24, N'42', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (25, N'50', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (26, N'53', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (27, N'60', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (28, N'62', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (29, N'66', 7)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (30, N'1', 8)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (31, N'4', 8)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (32, N'5', 8)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (33, N'6', 8)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (34, N'7', 8)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (35, N'8', 8)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (36, N'9', 8)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (37, N'11', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (38, N'21', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (39, N'22', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (40, N'23', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (41, N'31', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (42, N'33', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (43, N'34', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (44, N'41', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (45, N'43', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (46, N'51', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (47, N'52', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (48, N'14', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (49, N'15', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (50, N'16', 9)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (51, N'1', 10)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (52, N'2', 10)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (53, N'3', 10)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (54, N'4', 10)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (55, N'5', 10)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (56, N'6', 10)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (57, N'2', 11)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (58, N'5', 11)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (59, N'6', 11)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (60, N'8', 11)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (61, N'21', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (62, N'24', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (63, N'25', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (64, N'26', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (65, N'27', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (66, N'29', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (67, N'31', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (68, N'32', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (69, N'33', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (70, N'34', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (71, N'35', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (72, N'36', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (73, N'37', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (74, N'38', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (75, N'41', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (76, N'43', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (77, N'45', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (78, N'46', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (79, N'48', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (80, N'49', 12)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (81, N'2', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (82, N'3', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (83, N'40', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (84, N'45', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (85, N'48', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (86, N'50', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (87, N'55', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (88, N'62', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (89, N'64', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (90, N'66', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (91, N'68', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (92, N'82', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (93, N'84', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (94, N'86', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (95, N'88', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (96, N'93', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (97, N'95', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (98, N'96', 13)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (99, N'97', 13)
GO
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (100, N'71', 14)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (101, N'72', 14)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (103, N'73', 14)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (104, N'74', 14)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (105, N'75', 14)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (106, N'77', 14)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (107, N'21', 17)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (108, N'51', 17)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (109, N'57', 17)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (110, N'61', 17)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (111, N'87', 17)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (112, N'521', 17)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (113, N'652', 17)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (114, N'727', 17)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (115, N'212', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (116, N'216', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (117, N'222', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (118, N'224', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (119, N'232', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (120, N'236', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (121, N'242', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (122, N'246', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (123, N'256', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (124, N'258', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (125, N'266', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (126, N'272', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (127, N'274', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (128, N'276', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (129, N'284', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (130, N'312', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (131, N'322', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (132, N'332', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (134, N'338', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (135, N'342', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (136, N'346', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (137, N'352', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (138, N'358', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (139, N'362', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (140, N'364', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (141, N'366', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (142, N'382', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (143, N'412', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (144, N'414', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (145, N'416', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (146, N'422', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (147, N'424', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (148, N'432', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (149, N'442', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (150, N'452', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (151, N'462', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (152, N'472', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (153, N'482', 19)
INSERT [dbo].[cities] ([cityId], [cityCode], [countryId]) VALUES (154, N'488', 19)
SET IDENTITY_INSERT [dbo].[cities] OFF
GO
SET IDENTITY_INSERT [dbo].[countriesCodes] ON 

INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (1, N'+965', N'KWD', N'Kuwait', 1, 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (2, N'+966', N'SAR', N'Saudi Arabia', 0, 1)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (3, N'+968', N'OMR', N'Oman', 0, 2)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (4, N'+971', N'AED', N'United Arab Emirates', 0, 3)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (5, N'+974', N'QAR', N'Qatar', 0, 4)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (6, N'+973', N'BHD', N'Bahrain', 0, 5)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (7, N'+964', N'IQD', N'Iraq', 0, 6)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (8, N'+961', N'LBP', N'Lebanon', 0, 7)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (9, N'+963', N'SYP', N'Syria', 0, 8)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (10, N'+967', N'YER', N'Yemen', 0, 9)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (11, N'+962', N'JOD', N'Jordan', 0, 10)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (12, N'+213', N'DZD', N'Algeria', 0, 11)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (13, N'+20', N'EGP', N'Egypt', 0, 12)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (14, N'+216', N'TND', N'Tunisia', 0, 13)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (15, N'+249', N'SDG', N'Sudan', 0, 14)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (16, N'+212', N'MAD', N'Morocco', 0, 15)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (17, N'+218', N'LYD', N'Libya', 0, 16)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (18, N'+252', N'SOS', N'Somalia', 0, 17)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault], [currencyId]) VALUES (19, N'+90', N'TRY', N'Turkey', 0, 18)
SET IDENTITY_INSERT [dbo].[countriesCodes] OFF
GO
SET IDENTITY_INSERT [dbo].[groupObject] ON 

INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1597, 10, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.4700739' AS DateTime2), CAST(N'2021-11-18T18:54:15.4700739' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1598, 10, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.4738506' AS DateTime2), CAST(N'2021-11-18T18:54:15.4738506' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1599, 10, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.4759626' AS DateTime2), CAST(N'2021-11-18T18:54:15.4759626' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1600, 10, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.4791293' AS DateTime2), CAST(N'2021-11-18T18:54:15.4791293' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1601, 10, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.4807603' AS DateTime2), CAST(N'2021-11-18T18:54:15.4807603' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1602, 10, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.4828277' AS DateTime2), CAST(N'2021-11-18T18:54:15.4828277' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1603, 10, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.4856107' AS DateTime2), CAST(N'2021-11-18T18:54:15.4856107' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1604, 10, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.4877517' AS DateTime2), CAST(N'2021-11-18T18:54:15.4877517' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1605, 10, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.4898537' AS DateTime2), CAST(N'2021-11-18T18:54:15.4898537' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1606, 10, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.4916033' AS DateTime2), CAST(N'2021-11-18T18:54:15.4916033' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1607, 10, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.4937089' AS DateTime2), CAST(N'2021-11-18T18:54:15.4937089' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1608, 10, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.4963746' AS DateTime2), CAST(N'2021-11-18T18:54:15.4963746' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1609, 10, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.4986261' AS DateTime2), CAST(N'2021-11-18T18:54:15.4986261' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1610, 10, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.5002600' AS DateTime2), CAST(N'2021-11-18T18:54:15.5002600' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1611, 10, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:15.5023306' AS DateTime2), CAST(N'2021-11-18T18:54:15.5023306' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1612, 10, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3069272' AS DateTime2), CAST(N'2021-11-18T18:54:16.3069272' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1613, 10, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3102202' AS DateTime2), CAST(N'2021-11-18T18:54:16.3102202' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1614, 10, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3118152' AS DateTime2), CAST(N'2021-11-18T18:54:16.3118152' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1615, 10, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3139338' AS DateTime2), CAST(N'2021-11-18T18:54:16.3139338' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1616, 10, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3167085' AS DateTime2), CAST(N'2021-11-18T18:54:16.3167085' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1617, 10, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3188084' AS DateTime2), CAST(N'2021-11-18T18:54:16.3188084' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1618, 10, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3204904' AS DateTime2), CAST(N'2021-11-18T18:54:16.3204904' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1619, 10, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3225742' AS DateTime2), CAST(N'2021-11-18T18:54:16.3225742' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1620, 10, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3246423' AS DateTime2), CAST(N'2021-11-18T18:54:16.3246423' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1621, 10, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3274615' AS DateTime2), CAST(N'2021-11-18T18:54:16.3274615' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1622, 10, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3335116' AS DateTime2), CAST(N'2021-11-18T18:54:16.3335116' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1623, 10, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3351532' AS DateTime2), CAST(N'2021-11-18T18:54:16.3351532' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1624, 10, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3399643' AS DateTime2), CAST(N'2021-11-18T18:54:16.3399643' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1625, 10, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3421385' AS DateTime2), CAST(N'2021-11-18T18:54:16.3421385' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1626, 10, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:16.3453088' AS DateTime2), CAST(N'2021-11-18T18:54:16.3453088' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1627, 10, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1028972' AS DateTime2), CAST(N'2021-11-18T18:54:17.1028972' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1628, 10, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1066449' AS DateTime2), CAST(N'2021-11-18T18:54:17.1066449' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1629, 10, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1088534' AS DateTime2), CAST(N'2021-11-18T18:54:17.1088534' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1630, 10, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1117317' AS DateTime2), CAST(N'2021-11-18T18:54:17.1117317' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1631, 10, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1143938' AS DateTime2), CAST(N'2021-11-18T18:54:17.1143938' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1632, 10, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1165622' AS DateTime2), CAST(N'2021-11-18T18:54:17.1165622' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1633, 10, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1204233' AS DateTime2), CAST(N'2021-11-18T18:54:17.1204233' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1634, 10, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1225573' AS DateTime2), CAST(N'2021-11-18T18:54:17.1225573' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1635, 10, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1251994' AS DateTime2), CAST(N'2021-11-18T18:54:17.1251994' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1636, 10, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1283446' AS DateTime2), CAST(N'2021-11-18T18:54:17.1283446' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1637, 10, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1311979' AS DateTime2), CAST(N'2021-11-18T18:54:17.1311979' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1638, 10, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1329274' AS DateTime2), CAST(N'2021-11-18T18:54:17.1329274' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1639, 10, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1360666' AS DateTime2), CAST(N'2021-11-18T18:54:17.1360666' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1640, 10, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1388136' AS DateTime2), CAST(N'2021-11-18T18:54:17.1388136' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1641, 10, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.1409027' AS DateTime2), CAST(N'2021-11-18T18:54:17.1409027' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1642, 10, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.7942129' AS DateTime2), CAST(N'2021-11-18T18:54:17.7942129' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1643, 10, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.8010883' AS DateTime2), CAST(N'2021-11-18T18:54:17.8010883' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1644, 10, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.8050966' AS DateTime2), CAST(N'2021-11-18T18:54:17.8050966' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1645, 10, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:17.8079860' AS DateTime2), CAST(N'2021-11-18T18:54:17.8079860' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1646, 10, 50, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:17.8106929' AS DateTime2), CAST(N'2021-11-18T18:56:31.8288350' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1647, 10, 51, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:17.8139389' AS DateTime2), CAST(N'2021-11-18T18:56:36.2174491' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1648, 10, 52, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:17.8166758' AS DateTime2), CAST(N'2021-11-18T18:56:42.6398382' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1649, 10, 53, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:17.8189174' AS DateTime2), CAST(N'2021-11-18T18:56:43.1498531' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1650, 10, 54, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:17.8223419' AS DateTime2), CAST(N'2021-11-18T18:56:51.8692353' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1651, 10, 55, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:17.8286385' AS DateTime2), CAST(N'2021-11-18T18:56:52.3484701' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1652, 10, 56, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:17.8324212' AS DateTime2), CAST(N'2021-11-18T18:56:58.7818240' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1653, 10, 57, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:17.8363630' AS DateTime2), CAST(N'2021-11-18T18:56:59.2874391' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1654, 10, 58, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:17.8401996' AS DateTime2), CAST(N'2021-11-18T18:57:03.8059036' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1655, 10, 59, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:17.8429007' AS DateTime2), CAST(N'2021-11-18T18:57:07.6757517' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1656, 10, 60, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:17.8471985' AS DateTime2), CAST(N'2021-11-18T18:57:10.9650535' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1657, 10, 61, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:18.4613155' AS DateTime2), CAST(N'2021-11-18T18:57:15.4340943' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1658, 10, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:18.4640330' AS DateTime2), CAST(N'2021-11-18T18:54:18.4640330' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1659, 10, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:18.4672765' AS DateTime2), CAST(N'2021-11-18T18:54:18.4672765' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1660, 10, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:18.4699352' AS DateTime2), CAST(N'2021-11-18T18:54:18.4699352' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1661, 10, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:18.4720785' AS DateTime2), CAST(N'2021-11-18T18:54:18.4720785' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1662, 10, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:18.4748694' AS DateTime2), CAST(N'2021-11-18T18:54:18.4748694' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1663, 10, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:18.4775496' AS DateTime2), CAST(N'2021-11-18T18:54:18.4775496' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1664, 10, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:18.4797099' AS DateTime2), CAST(N'2021-11-18T18:54:18.4797099' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1665, 10, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:18.4818426' AS DateTime2), CAST(N'2021-11-18T18:54:18.4818426' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1666, 10, 74, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:18.4834441' AS DateTime2), CAST(N'2021-11-18T19:01:15.5084128' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1667, 10, 75, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:18.4866521' AS DateTime2), CAST(N'2021-11-18T19:01:25.1897106' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1668, 10, 76, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:18.4893545' AS DateTime2), CAST(N'2021-11-18T19:01:44.7639034' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1669, 10, 77, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:18.4915028' AS DateTime2), CAST(N'2021-11-18T19:01:49.5641876' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1670, 10, 78, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:18.4943227' AS DateTime2), CAST(N'2021-11-18T18:56:19.5416277' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1671, 10, 79, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:18.4975711' AS DateTime2), CAST(N'2021-11-18T18:56:20.0329344' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1672, 10, 80, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.1644484' AS DateTime2), CAST(N'2021-11-18T18:56:16.2869133' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1673, 10, 81, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:19.1681704' AS DateTime2), CAST(N'2021-11-18T18:55:48.3418796' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1674, 10, 82, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:19.1712700' AS DateTime2), CAST(N'2021-11-18T18:58:52.3844193' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1675, 10, 83, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.1729322' AS DateTime2), CAST(N'2021-11-18T18:58:52.8706993' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1676, 10, 84, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:19.1798522' AS DateTime2), CAST(N'2021-11-18T18:59:08.4370873' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1677, 10, 85, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.1838930' AS DateTime2), CAST(N'2021-11-18T18:59:08.9468702' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1678, 10, 86, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.1887683' AS DateTime2), CAST(N'2021-11-18T18:59:15.5151851' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1679, 10, 87, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.1914686' AS DateTime2), CAST(N'2021-11-18T18:59:16.0191777' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1680, 10, 88, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.1948151' AS DateTime2), CAST(N'2021-11-18T18:59:16.5022044' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1681, 10, 89, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.1964066' AS DateTime2), CAST(N'2021-11-18T18:59:22.7518379' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1682, 10, 90, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.1985075' AS DateTime2), CAST(N'2021-11-18T18:59:23.2569215' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1683, 10, 91, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.2011374' AS DateTime2), CAST(N'2021-11-18T18:58:59.7374672' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1684, 10, 92, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.2032748' AS DateTime2), CAST(N'2021-11-18T18:59:00.3409893' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1685, 10, 93, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.2054075' AS DateTime2), CAST(N'2021-11-18T18:59:01.0273861' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1686, 10, 94, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.2080785' AS DateTime2), CAST(N'2021-11-18T18:59:11.5114240' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1687, 10, 95, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8361959' AS DateTime2), CAST(N'2021-11-18T18:59:12.3141871' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1688, 10, 96, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8399773' AS DateTime2), CAST(N'2021-11-18T19:02:03.5783567' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1689, 10, 97, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8431300' AS DateTime2), CAST(N'2021-11-18T19:02:04.1045360' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1690, 10, 98, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8447386' AS DateTime2), CAST(N'2021-11-18T19:02:04.6124315' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1691, 10, 99, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8468428' AS DateTime2), CAST(N'2021-11-18T18:58:41.8695042' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1692, 10, 100, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8489891' AS DateTime2), CAST(N'2021-11-18T18:58:42.3674751' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1693, 10, 101, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8517713' AS DateTime2), CAST(N'2021-11-18T18:58:42.8565470' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1694, 10, 102, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8545693' AS DateTime2), CAST(N'2021-11-18T18:57:57.5804237' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1695, 10, 103, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8566951' AS DateTime2), CAST(N'2021-11-18T18:57:58.0648310' AS DateTime2), 2, 2, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1696, 10, 104, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8604996' AS DateTime2), CAST(N'2021-11-18T18:57:58.5777035' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1697, 10, 105, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8642649' AS DateTime2), CAST(N'2021-11-18T18:57:59.0776145' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1698, 10, 106, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8663929' AS DateTime2), CAST(N'2021-11-18T18:57:59.5754810' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1699, 10, 107, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:19.8702934' AS DateTime2), CAST(N'2021-11-18T18:58:06.5018744' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1700, 10, 108, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:19.8741368' AS DateTime2), CAST(N'2021-11-18T18:58:12.6941780' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1701, 10, 109, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8761767' AS DateTime2), CAST(N'2021-11-18T18:58:13.1928995' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1702, 10, 110, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:20.5557799' AS DateTime2), CAST(N'2021-11-18T19:01:39.9654959' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1703, 10, 111, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5595499' AS DateTime2), CAST(N'2021-11-18T19:01:40.5521989' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1704, 10, 112, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5629709' AS DateTime2), CAST(N'2021-11-18T18:58:15.9937472' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1705, 10, 113, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5646503' AS DateTime2), CAST(N'2021-11-18T18:58:16.6479027' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1706, 10, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:20.5667093' AS DateTime2), CAST(N'2021-11-18T18:54:20.5667093' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1707, 10, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:20.5695206' AS DateTime2), CAST(N'2021-11-18T18:54:20.5695206' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1708, 10, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:20.5718430' AS DateTime2), CAST(N'2021-11-18T18:54:20.5718430' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1709, 10, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:20.5734575' AS DateTime2), CAST(N'2021-11-18T18:54:20.5734575' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1710, 10, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:20.5772288' AS DateTime2), CAST(N'2021-11-18T18:54:20.5772288' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1711, 10, 119, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5793322' AS DateTime2), CAST(N'2021-11-18T18:58:20.1583553' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1712, 10, 120, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5820475' AS DateTime2), CAST(N'2021-11-18T18:58:20.6460604' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1713, 10, 121, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5841841' AS DateTime2), CAST(N'2021-11-18T18:58:21.1684770' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1714, 10, 122, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5868553' AS DateTime2), CAST(N'2021-11-18T18:57:34.7107357' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1715, 10, 123, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5889848' AS DateTime2), CAST(N'2021-11-18T18:57:35.2164072' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1716, 10, 124, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5928847' AS DateTime2), CAST(N'2021-11-18T18:57:37.2105472' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1717, 10, 125, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2513540' AS DateTime2), CAST(N'2021-11-18T18:57:37.6980605' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1718, 10, 126, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2552285' AS DateTime2), CAST(N'2021-11-18T18:57:40.1156937' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1719, 10, 127, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2588823' AS DateTime2), CAST(N'2021-11-18T18:57:40.6400491' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1720, 10, 128, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2637736' AS DateTime2), CAST(N'2021-11-18T18:57:43.7541801' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1721, 10, 129, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2671413' AS DateTime2), CAST(N'2021-11-18T18:57:44.2423939' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1722, 10, 130, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:21.2698329' AS DateTime2), CAST(N'2021-11-18T18:54:21.2698329' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1723, 10, 131, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:21.2715076' AS DateTime2), CAST(N'2021-11-18T18:54:21.2715076' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1724, 10, 132, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2736076' AS DateTime2), CAST(N'2021-11-18T18:57:46.6982312' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1725, 10, 133, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2767037' AS DateTime2), CAST(N'2021-11-18T18:57:47.2041066' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1726, 10, 134, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:21.2783078' AS DateTime2), CAST(N'2021-11-18T18:57:31.4593809' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1727, 10, 135, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2804435' AS DateTime2), CAST(N'2021-11-18T18:57:31.9618229' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1728, 10, 137, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:21.2833055' AS DateTime2), CAST(N'2021-11-18T19:01:25.7053558' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1729, 10, 138, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2853798' AS DateTime2), CAST(N'2021-11-18T18:55:49.2305392' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1730, 10, 145, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:21.2880734' AS DateTime2), CAST(N'2021-11-18T19:01:55.9761995' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1731, 10, 147, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:21.2915662' AS DateTime2), CAST(N'2021-11-18T18:54:21.2915662' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1732, 10, 148, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:22.0362152' AS DateTime2), CAST(N'2021-11-18T18:54:22.0362152' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1733, 10, 151, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:22.0399454' AS DateTime2), CAST(N'2021-11-18T18:55:56.6443297' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1734, 10, 152, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:22.0431286' AS DateTime2), CAST(N'2021-11-18T18:54:22.0431286' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1735, 10, 153, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0458154' AS DateTime2), CAST(N'2021-11-18T18:58:29.9918029' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1736, 10, 154, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0479479' AS DateTime2), CAST(N'2021-11-18T18:58:30.5070390' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1737, 10, 155, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0507073' AS DateTime2), CAST(N'2021-11-18T18:59:01.6214694' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1738, 10, 156, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0529350' AS DateTime2), CAST(N'2021-11-18T18:59:02.1554642' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1739, 10, 157, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:22.0556504' AS DateTime2), CAST(N'2021-11-18T18:54:22.0556504' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1740, 10, 158, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0577888' AS DateTime2), CAST(N'2021-11-18T18:56:26.3314666' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1741, 10, 159, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:22.0604692' AS DateTime2), CAST(N'2021-11-18T18:54:22.0604692' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1742, 10, 160, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0626387' AS DateTime2), CAST(N'2021-11-18T18:59:19.6603933' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1743, 10, 161, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0652918' AS DateTime2), CAST(N'2021-11-18T18:59:20.1670641' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1744, 10, 162, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0685914' AS DateTime2), CAST(N'2021-11-18T18:58:00.0617468' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1745, 10, 163, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0702123' AS DateTime2), CAST(N'2021-11-18T18:58:21.7726620' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1746, 10, 164, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0723716' AS DateTime2), CAST(N'2021-11-18T18:58:43.3545315' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1747, 10, 165, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7580500' AS DateTime2), CAST(N'2021-11-18T18:58:31.0135976' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1748, 10, 166, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7607721' AS DateTime2), CAST(N'2021-11-18T18:57:47.6925855' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1749, 10, 180, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:22.7635594' AS DateTime2), CAST(N'2021-11-18T18:54:22.7635594' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1750, 10, 181, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:22.7656791' AS DateTime2), CAST(N'2021-11-18T18:54:22.7656791' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1751, 10, 182, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:22.7684574' AS DateTime2), CAST(N'2021-11-18T18:54:22.7684574' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1752, 10, 183, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:22.7717995' AS DateTime2), CAST(N'2021-11-18T18:54:22.7717995' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1753, 10, 184, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7745103' AS DateTime2), CAST(N'2021-11-18T18:55:15.5035881' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1754, 10, 185, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7765950' AS DateTime2), CAST(N'2021-11-18T18:55:15.9858511' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1755, 10, 186, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7782713' AS DateTime2), CAST(N'2021-11-18T18:55:16.4753459' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1756, 10, 187, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7814172' AS DateTime2), CAST(N'2021-11-18T18:55:16.9634983' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1757, 10, 188, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7841832' AS DateTime2), CAST(N'2021-11-18T18:55:04.3481758' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1758, 10, 192, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7862850' AS DateTime2), CAST(N'2021-11-18T18:56:16.8132862' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1759, 10, 193, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:22.7899918' AS DateTime2), CAST(N'2021-11-18T18:54:22.7899918' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1760, 10, 194, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7931910' AS DateTime2), CAST(N'2021-11-29T16:13:29.6397529' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1761, 10, 195, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7960266' AS DateTime2), CAST(N'2021-11-29T16:13:30.0732937' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1762, 10, 196, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5763481' AS DateTime2), CAST(N'2021-11-18T18:58:43.8681287' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1763, 10, 197, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5801364' AS DateTime2), CAST(N'2021-11-18T18:58:44.3289950' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1764, 10, 198, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5829166' AS DateTime2), CAST(N'2021-11-18T18:58:31.5097937' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1765, 10, 199, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5860788' AS DateTime2), CAST(N'2021-11-18T18:59:02.7320835' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1766, 10, 200, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5887862' AS DateTime2), CAST(N'2021-11-18T18:58:24.3485864' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1767, 10, 201, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5920396' AS DateTime2), CAST(N'2021-11-18T18:57:20.1312201' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1768, 10, 202, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5946477' AS DateTime2), CAST(N'2021-11-18T18:57:21.7062520' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1769, 10, 203, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5967980' AS DateTime2), CAST(N'2021-11-18T18:57:23.4015668' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1770, 10, 204, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5994234' AS DateTime2), CAST(N'2021-11-18T18:57:18.5278798' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1771, 10, 205, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:23.6014995' AS DateTime2), CAST(N'2021-11-18T18:54:23.6014995' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1772, 10, 206, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:23.6036232' AS DateTime2), CAST(N'2021-11-18T18:54:23.6036232' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1773, 10, 207, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:23.6063280' AS DateTime2), CAST(N'2021-11-18T19:01:32.9793313' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1774, 10, 209, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.6096317' AS DateTime2), CAST(N'2021-11-18T18:58:00.5728719' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1775, 10, 210, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.6135371' AS DateTime2), CAST(N'2021-11-18T18:58:44.8438794' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1776, 10, 212, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.6151772' AS DateTime2), CAST(N'2021-11-18T18:59:17.0543357' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1777, 11, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3535665' AS DateTime2), CAST(N'2021-11-20T13:44:09.3535665' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1778, 11, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3729621' AS DateTime2), CAST(N'2021-11-20T13:44:09.3729621' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1779, 11, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3750491' AS DateTime2), CAST(N'2021-11-20T13:44:09.3750491' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1780, 11, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3771861' AS DateTime2), CAST(N'2021-11-20T13:44:09.3771861' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1781, 11, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3798785' AS DateTime2), CAST(N'2021-11-20T13:44:09.3798785' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1782, 11, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3849166' AS DateTime2), CAST(N'2021-11-20T13:44:09.3849166' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1783, 11, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3888711' AS DateTime2), CAST(N'2021-11-20T13:44:09.3888711' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1784, 11, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3915717' AS DateTime2), CAST(N'2021-11-20T13:44:09.3915717' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1785, 11, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3947644' AS DateTime2), CAST(N'2021-11-20T13:44:09.3947644' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1786, 11, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3963834' AS DateTime2), CAST(N'2021-11-20T13:44:09.3963834' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1787, 11, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3984786' AS DateTime2), CAST(N'2021-11-20T13:44:09.3984786' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1788, 11, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.4005922' AS DateTime2), CAST(N'2021-11-20T13:44:09.4005922' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1789, 11, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.4032687' AS DateTime2), CAST(N'2021-11-20T13:44:09.4032687' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1790, 11, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.4053782' AS DateTime2), CAST(N'2021-11-20T13:44:09.4053782' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1791, 11, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.4074527' AS DateTime2), CAST(N'2021-11-20T13:44:09.4074527' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1792, 11, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0294358' AS DateTime2), CAST(N'2021-11-20T13:44:10.0294358' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1793, 11, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0369885' AS DateTime2), CAST(N'2021-11-20T13:44:10.0369885' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1794, 11, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0390837' AS DateTime2), CAST(N'2021-11-20T13:44:10.0390837' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1795, 11, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0469835' AS DateTime2), CAST(N'2021-11-20T13:44:10.0469835' AS DateTime2), 1, 1, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1796, 11, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0492341' AS DateTime2), CAST(N'2021-11-20T13:44:10.0492341' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1797, 11, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0520492' AS DateTime2), CAST(N'2021-11-20T13:44:10.0520492' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1798, 11, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0569681' AS DateTime2), CAST(N'2021-11-20T13:44:10.0569681' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1799, 11, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0586085' AS DateTime2), CAST(N'2021-11-20T13:44:10.0586085' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1800, 11, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0613715' AS DateTime2), CAST(N'2021-11-20T13:44:10.0613715' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1801, 11, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0645267' AS DateTime2), CAST(N'2021-11-20T13:44:10.0645267' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1802, 11, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0668088' AS DateTime2), CAST(N'2021-11-20T13:44:10.0668088' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1803, 11, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0700885' AS DateTime2), CAST(N'2021-11-20T13:44:10.0700885' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1804, 11, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0732547' AS DateTime2), CAST(N'2021-11-20T13:44:10.0732547' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1805, 11, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0791668' AS DateTime2), CAST(N'2021-11-20T13:44:10.0791668' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1806, 11, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0841450' AS DateTime2), CAST(N'2021-11-20T13:44:10.0841450' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1807, 11, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6755331' AS DateTime2), CAST(N'2021-11-20T13:44:10.6755331' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1808, 11, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6797131' AS DateTime2), CAST(N'2021-11-20T13:44:10.6797131' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1809, 11, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6824082' AS DateTime2), CAST(N'2021-11-20T13:44:10.6824082' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1810, 11, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6845061' AS DateTime2), CAST(N'2021-11-20T13:44:10.6845061' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1811, 11, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6866803' AS DateTime2), CAST(N'2021-11-20T13:44:10.6866803' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1812, 11, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6894217' AS DateTime2), CAST(N'2021-11-20T13:44:10.6894217' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1813, 11, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6915746' AS DateTime2), CAST(N'2021-11-20T13:44:10.6915746' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1814, 11, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6931701' AS DateTime2), CAST(N'2021-11-20T13:44:10.6931701' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1815, 11, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6963804' AS DateTime2), CAST(N'2021-11-20T13:44:10.6963804' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1816, 11, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6980819' AS DateTime2), CAST(N'2021-11-20T13:44:10.6980819' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1817, 11, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.7002142' AS DateTime2), CAST(N'2021-11-20T13:44:10.7002142' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1818, 11, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.7030034' AS DateTime2), CAST(N'2021-11-20T13:44:10.7030034' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1819, 11, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.7051055' AS DateTime2), CAST(N'2021-11-20T13:44:10.7051055' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1820, 11, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.7071709' AS DateTime2), CAST(N'2021-11-20T13:44:10.7071709' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1821, 11, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.7099176' AS DateTime2), CAST(N'2021-11-20T13:44:10.7099176' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1822, 11, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3273971' AS DateTime2), CAST(N'2021-11-20T13:44:11.3273971' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1823, 11, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3300333' AS DateTime2), CAST(N'2021-11-20T13:44:11.3300333' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1824, 11, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3327548' AS DateTime2), CAST(N'2021-11-20T13:44:11.3327548' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1825, 11, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3348454' AS DateTime2), CAST(N'2021-11-20T13:44:11.3348454' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1826, 11, 50, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3369823' AS DateTime2), CAST(N'2021-11-20T13:44:11.3369823' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1827, 11, 51, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3396618' AS DateTime2), CAST(N'2021-11-20T13:44:11.3396618' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1828, 11, 52, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3417622' AS DateTime2), CAST(N'2021-11-20T13:44:11.3417622' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1829, 11, 53, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:11.3428275' AS DateTime2), CAST(N'2021-11-20T13:44:11.3428275' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1830, 11, 54, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3455693' AS DateTime2), CAST(N'2021-11-20T13:44:11.3455693' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1831, 11, 55, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:11.3477416' AS DateTime2), CAST(N'2021-11-20T13:44:11.3477416' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1832, 11, 56, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3493892' AS DateTime2), CAST(N'2021-11-20T13:44:11.3493892' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1833, 11, 57, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:11.3515434' AS DateTime2), CAST(N'2021-11-20T13:44:11.3515434' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1834, 11, 58, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3542678' AS DateTime2), CAST(N'2021-11-20T13:44:11.3542678' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1835, 11, 59, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3563975' AS DateTime2), CAST(N'2021-11-20T13:44:11.3563975' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1836, 11, 60, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3591456' AS DateTime2), CAST(N'2021-11-20T13:44:11.3591456' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1837, 11, 61, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9685783' AS DateTime2), CAST(N'2021-11-20T13:44:11.9685783' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1838, 11, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9717577' AS DateTime2), CAST(N'2021-11-20T13:44:11.9717577' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1839, 11, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9734193' AS DateTime2), CAST(N'2021-11-20T13:44:11.9734193' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1840, 11, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9755359' AS DateTime2), CAST(N'2021-11-20T13:44:11.9755359' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1841, 11, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9783849' AS DateTime2), CAST(N'2021-11-20T13:44:11.9783849' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1842, 11, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9804849' AS DateTime2), CAST(N'2021-11-20T13:44:11.9804849' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1843, 11, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9833332' AS DateTime2), CAST(N'2021-11-20T13:44:11.9833332' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1844, 11, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9861436' AS DateTime2), CAST(N'2021-11-20T13:44:11.9861436' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1845, 11, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9882761' AS DateTime2), CAST(N'2021-11-20T13:44:11.9882761' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1846, 11, 74, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:11.9909278' AS DateTime2), CAST(N'2021-11-20T14:16:21.7317163' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1847, 11, 75, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:11.9941196' AS DateTime2), CAST(N'2021-11-20T14:16:31.8259391' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1848, 11, 76, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:11.9962245' AS DateTime2), CAST(N'2021-11-20T14:16:49.1432321' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1849, 11, 77, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:11.9979269' AS DateTime2), CAST(N'2021-11-20T14:16:54.9162423' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1850, 11, 78, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.0000093' AS DateTime2), CAST(N'2021-11-20T13:44:12.0000093' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1851, 11, 79, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.0027075' AS DateTime2), CAST(N'2021-11-20T13:44:12.0027075' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1852, 11, 80, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6032019' AS DateTime2), CAST(N'2021-11-20T13:44:12.6032019' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1853, 11, 81, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:12.6064213' AS DateTime2), CAST(N'2021-11-20T13:44:12.6064213' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1854, 11, 82, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:12.6091516' AS DateTime2), CAST(N'2021-11-20T13:44:12.6091516' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1855, 11, 83, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6112616' AS DateTime2), CAST(N'2021-11-20T13:44:12.6112616' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1856, 11, 84, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:12.6139887' AS DateTime2), CAST(N'2021-11-20T13:44:12.6139887' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1857, 11, 85, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6160791' AS DateTime2), CAST(N'2021-11-20T13:44:12.6160791' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1858, 11, 86, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6181826' AS DateTime2), CAST(N'2021-11-20T13:44:12.6181826' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1859, 11, 87, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6198340' AS DateTime2), CAST(N'2021-11-20T13:44:12.6198340' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1860, 11, 88, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6219670' AS DateTime2), CAST(N'2021-11-20T13:44:12.6219670' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1861, 11, 89, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6246485' AS DateTime2), CAST(N'2021-11-20T13:44:12.6246485' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1862, 11, 90, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6267429' AS DateTime2), CAST(N'2021-11-20T13:44:12.6267429' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1863, 11, 91, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6289076' AS DateTime2), CAST(N'2021-11-20T13:44:12.6289076' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1864, 11, 92, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6315278' AS DateTime2), CAST(N'2021-11-20T13:44:12.6315278' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1865, 11, 93, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6336785' AS DateTime2), CAST(N'2021-11-20T13:44:12.6336785' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1866, 11, 94, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6357903' AS DateTime2), CAST(N'2021-11-20T13:44:12.6357903' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1867, 11, 95, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.2576395' AS DateTime2), CAST(N'2021-11-20T13:44:13.2576395' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1868, 11, 96, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.2613149' AS DateTime2), CAST(N'2021-11-20T13:44:13.2613149' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1869, 11, 97, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.2634481' AS DateTime2), CAST(N'2021-11-20T13:44:13.2634481' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1870, 11, 98, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.2656050' AS DateTime2), CAST(N'2021-11-20T13:44:13.2656050' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1871, 11, 99, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2672617' AS DateTime2), CAST(N'2021-11-20T14:13:58.1653931' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1872, 11, 100, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2704389' AS DateTime2), CAST(N'2021-11-20T14:13:58.6361310' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1873, 11, 101, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2714930' AS DateTime2), CAST(N'2021-11-20T14:13:59.1236156' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1874, 11, 102, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2741760' AS DateTime2), CAST(N'2021-11-20T14:13:16.6373204' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1875, 11, 103, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2763123' AS DateTime2), CAST(N'2021-11-20T14:13:17.1386696' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1876, 11, 104, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2789876' AS DateTime2), CAST(N'2021-11-20T14:13:17.6246558' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1877, 11, 105, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2811066' AS DateTime2), CAST(N'2021-11-20T14:13:18.0964273' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1878, 11, 106, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2837741' AS DateTime2), CAST(N'2021-11-20T14:13:18.6003784' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1879, 11, 107, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:13.2859747' AS DateTime2), CAST(N'2021-11-20T14:13:26.1944201' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1880, 11, 108, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:13.2880939' AS DateTime2), CAST(N'2021-11-20T14:13:33.6114269' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1881, 11, 109, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2909172' AS DateTime2), CAST(N'2021-11-20T14:13:34.0946341' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1882, 11, 110, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:13.9491687' AS DateTime2), CAST(N'2021-11-20T14:16:44.3603679' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1883, 11, 111, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.9528841' AS DateTime2), CAST(N'2021-11-20T14:16:44.8691743' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1884, 11, 112, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.9560330' AS DateTime2), CAST(N'2021-11-20T14:13:38.6090195' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1885, 11, 113, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.9576955' AS DateTime2), CAST(N'2021-11-20T14:13:39.1012707' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1886, 11, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:13.9609451' AS DateTime2), CAST(N'2021-11-20T13:44:13.9609451' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1887, 11, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.9625532' AS DateTime2), CAST(N'2021-11-20T13:44:13.9625532' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1888, 11, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:13.9646433' AS DateTime2), CAST(N'2021-11-20T13:44:13.9646433' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1889, 11, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.9667099' AS DateTime2), CAST(N'2021-11-20T13:44:13.9667099' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1890, 11, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.9695368' AS DateTime2), CAST(N'2021-11-20T13:44:13.9695368' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1891, 11, 119, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.9716223' AS DateTime2), CAST(N'2021-11-20T14:13:46.5891468' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1892, 11, 120, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.9743440' AS DateTime2), CAST(N'2021-11-20T14:13:47.0452411' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1893, 11, 121, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.9775151' AS DateTime2), CAST(N'2021-11-20T14:13:47.5460814' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1894, 11, 122, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.9801874' AS DateTime2), CAST(N'2021-11-20T13:44:13.9801874' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1895, 11, 123, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.9822926' AS DateTime2), CAST(N'2021-11-20T13:44:13.9822926' AS DateTime2), 1, 1, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1896, 11, 124, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.9849443' AS DateTime2), CAST(N'2021-11-20T13:44:13.9849443' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1897, 11, 125, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6012643' AS DateTime2), CAST(N'2021-11-20T13:44:14.6012643' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1898, 11, 126, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6063354' AS DateTime2), CAST(N'2021-11-20T13:44:14.6063354' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1899, 11, 127, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6092467' AS DateTime2), CAST(N'2021-11-20T13:44:14.6092467' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1900, 11, 128, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6113849' AS DateTime2), CAST(N'2021-11-20T13:44:14.6113849' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1901, 11, 129, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6130337' AS DateTime2), CAST(N'2021-11-20T13:44:14.6130337' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1902, 11, 130, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6151357' AS DateTime2), CAST(N'2021-11-20T13:44:14.6151357' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1903, 11, 131, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6168087' AS DateTime2), CAST(N'2021-11-20T13:44:14.6168087' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1904, 11, 132, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6189171' AS DateTime2), CAST(N'2021-11-20T13:44:14.6189171' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1905, 11, 133, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6221021' AS DateTime2), CAST(N'2021-11-20T13:44:14.6221021' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1906, 11, 134, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:14.6237993' AS DateTime2), CAST(N'2021-11-20T13:44:14.6237993' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1907, 11, 135, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6259292' AS DateTime2), CAST(N'2021-11-20T13:44:14.6259292' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1908, 11, 137, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:14.6296600' AS DateTime2), CAST(N'2021-11-20T14:16:32.2953175' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1909, 11, 138, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6323706' AS DateTime2), CAST(N'2021-11-20T13:44:14.6323706' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1910, 11, 145, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:14.6356051' AS DateTime2), CAST(N'2021-11-20T14:17:03.3338994' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1911, 11, 147, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:14.6382912' AS DateTime2), CAST(N'2021-11-20T13:44:14.6382912' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1912, 11, 148, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:15.2517259' AS DateTime2), CAST(N'2021-11-20T13:44:15.2517259' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1913, 11, 151, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:15.2544806' AS DateTime2), CAST(N'2021-11-20T13:44:15.2544806' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1914, 11, 152, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:15.2565710' AS DateTime2), CAST(N'2021-11-20T13:44:15.2565710' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1915, 11, 153, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:15.2586833' AS DateTime2), CAST(N'2021-11-20T14:14:05.0078173' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1916, 11, 154, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:15.2615081' AS DateTime2), CAST(N'2021-11-20T14:14:05.5399919' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1917, 11, 155, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.2625589' AS DateTime2), CAST(N'2021-11-20T13:44:15.2625589' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1918, 11, 156, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.2653238' AS DateTime2), CAST(N'2021-11-20T13:44:15.2653238' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1919, 11, 157, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:15.2685208' AS DateTime2), CAST(N'2021-11-20T13:44:15.2685208' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1920, 11, 158, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.2701253' AS DateTime2), CAST(N'2021-11-20T13:44:15.2701253' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1921, 11, 159, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:15.2722522' AS DateTime2), CAST(N'2021-11-20T13:44:15.2722522' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1922, 11, 160, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.2750881' AS DateTime2), CAST(N'2021-11-20T13:44:15.2750881' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1923, 11, 161, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.2771710' AS DateTime2), CAST(N'2021-11-20T13:44:15.2771710' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1924, 11, 162, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:15.2799784' AS DateTime2), CAST(N'2021-11-20T14:13:19.1130752' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1925, 11, 163, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:15.2832127' AS DateTime2), CAST(N'2021-11-20T14:13:48.0930385' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1926, 11, 164, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:15.2858993' AS DateTime2), CAST(N'2021-11-20T14:13:59.5951368' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1927, 11, 165, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:15.9332108' AS DateTime2), CAST(N'2021-11-20T14:14:06.0526120' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1928, 11, 166, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9363862' AS DateTime2), CAST(N'2021-11-20T13:44:15.9363862' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1929, 11, 180, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9391871' AS DateTime2), CAST(N'2021-11-20T13:44:15.9391871' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1930, 11, 181, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9419562' AS DateTime2), CAST(N'2021-11-20T13:44:15.9419562' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1931, 11, 182, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9451527' AS DateTime2), CAST(N'2021-11-20T13:44:15.9451527' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1932, 11, 183, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9479154' AS DateTime2), CAST(N'2021-11-20T13:44:15.9479154' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1933, 11, 184, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9501792' AS DateTime2), CAST(N'2021-11-20T13:44:15.9501792' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1934, 11, 185, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9518052' AS DateTime2), CAST(N'2021-11-20T13:44:15.9518052' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1935, 11, 186, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9539072' AS DateTime2), CAST(N'2021-11-20T13:44:15.9539072' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1936, 11, 187, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9566548' AS DateTime2), CAST(N'2021-11-20T13:44:15.9566548' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1937, 11, 188, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9587832' AS DateTime2), CAST(N'2021-11-20T13:44:15.9587832' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1938, 11, 192, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9604119' AS DateTime2), CAST(N'2021-11-20T13:44:15.9604119' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1939, 11, 193, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:15.9625656' AS DateTime2), CAST(N'2021-11-20T13:44:15.9625656' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1940, 11, 194, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9647050' AS DateTime2), CAST(N'2021-11-20T13:44:15.9647050' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1941, 11, 195, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9673590' AS DateTime2), CAST(N'2021-11-20T13:44:15.9673590' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1942, 11, 196, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:16.6127931' AS DateTime2), CAST(N'2021-11-20T14:14:00.0891859' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1943, 11, 197, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:16.6170209' AS DateTime2), CAST(N'2021-11-20T14:14:00.5758056' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1944, 11, 198, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:16.6186562' AS DateTime2), CAST(N'2021-11-20T14:14:06.5360393' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1945, 11, 199, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:16.6207724' AS DateTime2), CAST(N'2021-11-20T13:44:16.6207724' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1946, 11, 200, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:16.6228523' AS DateTime2), CAST(N'2021-11-20T14:13:50.9549251' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1947, 11, 201, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:16.6255583' AS DateTime2), CAST(N'2021-11-20T13:44:16.6255583' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1948, 11, 202, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:16.6276878' AS DateTime2), CAST(N'2022-01-24T18:01:33.0875424' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1949, 11, 203, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:16.6303587' AS DateTime2), CAST(N'2021-11-20T13:44:16.6303587' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1950, 11, 204, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:16.6325048' AS DateTime2), CAST(N'2021-11-20T13:44:16.6325048' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1951, 11, 205, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:16.6352418' AS DateTime2), CAST(N'2021-11-20T13:44:16.6352418' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1952, 11, 206, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:16.6373169' AS DateTime2), CAST(N'2021-11-20T13:44:16.6373169' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1953, 11, 207, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:16.6411242' AS DateTime2), CAST(N'2021-11-20T14:16:37.6202607' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1954, 11, 209, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:16.6432253' AS DateTime2), CAST(N'2021-11-20T14:13:19.6384490' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1955, 11, 210, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:16.6463538' AS DateTime2), CAST(N'2021-11-20T14:14:01.0844886' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1956, 11, 212, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:16.6490419' AS DateTime2), CAST(N'2021-11-20T13:44:16.6490419' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1957, 12, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8471843' AS DateTime2), CAST(N'2021-11-20T13:55:42.8471843' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1958, 12, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8516219' AS DateTime2), CAST(N'2021-11-20T13:55:42.8516219' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1959, 12, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8543503' AS DateTime2), CAST(N'2021-11-20T13:55:42.8543503' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1960, 12, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8581520' AS DateTime2), CAST(N'2021-11-20T13:55:42.8581520' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1961, 12, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8609042' AS DateTime2), CAST(N'2021-11-20T13:55:42.8609042' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1962, 12, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8641215' AS DateTime2), CAST(N'2021-11-20T13:55:42.8641215' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1963, 12, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8679112' AS DateTime2), CAST(N'2021-11-20T13:55:42.8679112' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1964, 12, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8716623' AS DateTime2), CAST(N'2021-11-20T13:55:42.8716623' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1965, 12, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8737881' AS DateTime2), CAST(N'2021-11-20T13:55:42.8737881' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1966, 12, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8774816' AS DateTime2), CAST(N'2021-11-20T13:55:42.8774816' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1967, 12, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8796058' AS DateTime2), CAST(N'2021-11-20T13:55:42.8796058' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1968, 12, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8834782' AS DateTime2), CAST(N'2021-11-20T13:55:42.8834782' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1969, 12, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8866297' AS DateTime2), CAST(N'2021-11-20T13:55:42.8866297' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1970, 12, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8894039' AS DateTime2), CAST(N'2021-11-20T13:55:42.8894039' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1971, 12, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8931946' AS DateTime2), CAST(N'2021-11-20T13:55:42.8931946' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1972, 12, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9272778' AS DateTime2), CAST(N'2021-11-20T13:55:44.9272778' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1973, 12, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9313259' AS DateTime2), CAST(N'2021-11-20T13:55:44.9313259' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1974, 12, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9340199' AS DateTime2), CAST(N'2021-11-20T13:55:44.9340199' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1975, 12, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9362632' AS DateTime2), CAST(N'2021-11-20T13:55:44.9362632' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1976, 12, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9378850' AS DateTime2), CAST(N'2021-11-20T13:55:44.9378850' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1977, 12, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9410617' AS DateTime2), CAST(N'2021-11-20T13:55:44.9410617' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1978, 12, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9437424' AS DateTime2), CAST(N'2021-11-20T13:55:44.9437424' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1979, 12, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9458892' AS DateTime2), CAST(N'2021-11-20T13:55:44.9458892' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1980, 12, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9485883' AS DateTime2), CAST(N'2021-11-20T13:55:44.9485883' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1981, 12, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9507367' AS DateTime2), CAST(N'2021-11-20T13:55:44.9507367' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1982, 12, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9545059' AS DateTime2), CAST(N'2021-11-20T13:55:44.9545059' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1983, 12, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9566905' AS DateTime2), CAST(N'2021-11-20T13:55:44.9566905' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1984, 12, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9594012' AS DateTime2), CAST(N'2021-11-20T13:55:44.9594012' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1985, 12, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9615590' AS DateTime2), CAST(N'2021-11-20T13:55:44.9615590' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1986, 12, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9644058' AS DateTime2), CAST(N'2021-11-20T13:55:44.9644058' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1987, 12, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3560709' AS DateTime2), CAST(N'2021-11-20T13:55:46.3560709' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1988, 12, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3609849' AS DateTime2), CAST(N'2021-11-20T13:55:46.3609849' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1989, 12, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3648281' AS DateTime2), CAST(N'2021-11-20T13:55:46.3648281' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1990, 12, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3687075' AS DateTime2), CAST(N'2021-11-20T13:55:46.3687075' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1991, 12, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3716430' AS DateTime2), CAST(N'2021-11-20T13:55:46.3716430' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1992, 12, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3754868' AS DateTime2), CAST(N'2021-11-20T13:55:46.3754868' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1993, 12, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3795839' AS DateTime2), CAST(N'2021-11-20T13:55:46.3795839' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1994, 12, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3823458' AS DateTime2), CAST(N'2021-11-20T13:55:46.3823458' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1995, 12, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3861806' AS DateTime2), CAST(N'2021-11-20T13:55:46.3861806' AS DateTime2), 1, 1, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1996, 12, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3899980' AS DateTime2), CAST(N'2021-11-20T13:55:46.3899980' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1997, 12, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3921938' AS DateTime2), CAST(N'2021-11-20T13:55:46.3921938' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1998, 12, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3948797' AS DateTime2), CAST(N'2021-11-20T13:55:46.3948797' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1999, 12, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3971998' AS DateTime2), CAST(N'2021-11-20T13:55:46.3971998' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2000, 12, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3988735' AS DateTime2), CAST(N'2021-11-20T13:55:46.3988735' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2001, 12, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.4020219' AS DateTime2), CAST(N'2021-11-20T13:55:46.4020219' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2002, 12, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.3949267' AS DateTime2), CAST(N'2021-11-20T13:55:48.3949267' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2003, 12, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.3986715' AS DateTime2), CAST(N'2021-11-20T13:55:48.3986715' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2004, 12, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4008285' AS DateTime2), CAST(N'2021-11-20T13:55:48.4008285' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2005, 12, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4018872' AS DateTime2), CAST(N'2021-11-20T13:55:48.4018872' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2006, 12, 50, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4045501' AS DateTime2), CAST(N'2021-11-20T13:55:48.4045501' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2007, 12, 51, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4066671' AS DateTime2), CAST(N'2021-11-20T13:55:48.4066671' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2008, 12, 52, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4093128' AS DateTime2), CAST(N'2021-11-20T13:55:48.4093128' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2009, 12, 53, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:48.4125574' AS DateTime2), CAST(N'2021-11-20T13:55:48.4125574' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2010, 12, 54, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4152339' AS DateTime2), CAST(N'2021-11-20T13:55:48.4152339' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2011, 12, 55, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:48.4183735' AS DateTime2), CAST(N'2021-11-20T13:55:48.4183735' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2012, 12, 56, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4204353' AS DateTime2), CAST(N'2021-11-20T13:55:48.4204353' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2013, 12, 57, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:48.4220861' AS DateTime2), CAST(N'2021-11-20T13:55:48.4220861' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2014, 12, 58, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4241898' AS DateTime2), CAST(N'2021-11-20T13:55:48.4241898' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2015, 12, 59, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4263070' AS DateTime2), CAST(N'2021-11-20T13:55:48.4263070' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2016, 12, 60, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4290421' AS DateTime2), CAST(N'2021-11-20T13:55:48.4290421' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2017, 12, 61, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5228365' AS DateTime2), CAST(N'2021-11-20T13:55:50.5228365' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2018, 12, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5255132' AS DateTime2), CAST(N'2021-11-20T13:55:50.5255132' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2019, 12, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5287123' AS DateTime2), CAST(N'2021-11-20T13:55:50.5287123' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2020, 12, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5313493' AS DateTime2), CAST(N'2021-11-20T13:55:50.5313493' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2021, 12, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5334268' AS DateTime2), CAST(N'2021-11-20T13:55:50.5334268' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2022, 12, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5366580' AS DateTime2), CAST(N'2021-11-20T13:55:50.5366580' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2023, 12, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5392698' AS DateTime2), CAST(N'2021-11-20T13:55:50.5392698' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2024, 12, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5431110' AS DateTime2), CAST(N'2021-11-20T13:55:50.5431110' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2025, 12, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5462805' AS DateTime2), CAST(N'2021-11-20T13:55:50.5462805' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2026, 12, 74, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5490450' AS DateTime2), CAST(N'2021-11-20T13:55:50.5490450' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2027, 12, 75, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5511618' AS DateTime2), CAST(N'2021-11-20T13:55:50.5511618' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2028, 12, 76, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5538429' AS DateTime2), CAST(N'2021-11-20T13:55:50.5538429' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2029, 12, 77, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5578760' AS DateTime2), CAST(N'2021-11-20T13:55:50.5578760' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2030, 12, 78, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:50.5607329' AS DateTime2), CAST(N'2021-11-20T13:55:50.5607329' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2031, 12, 79, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:50.5641621' AS DateTime2), CAST(N'2021-11-20T13:55:50.5641621' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2032, 12, 80, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:52.2971108' AS DateTime2), CAST(N'2021-11-20T13:55:52.2971108' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2033, 12, 81, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:52.3008701' AS DateTime2), CAST(N'2021-11-20T13:55:52.3008701' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2034, 12, 82, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:55:52.3030447' AS DateTime2), CAST(N'2021-11-20T14:14:22.2900742' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2035, 12, 83, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3047527' AS DateTime2), CAST(N'2021-11-20T14:14:22.9172526' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2036, 12, 84, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:55:52.3078751' AS DateTime2), CAST(N'2021-11-20T14:14:28.4783888' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2037, 12, 85, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3105430' AS DateTime2), CAST(N'2021-11-20T14:14:28.9665878' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2038, 12, 86, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3137269' AS DateTime2), CAST(N'2021-11-20T14:14:33.1636826' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2039, 12, 87, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3164620' AS DateTime2), CAST(N'2021-11-20T14:14:33.6521942' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2040, 12, 88, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3196019' AS DateTime2), CAST(N'2021-11-20T14:14:34.1265299' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2041, 12, 89, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3222872' AS DateTime2), CAST(N'2021-11-20T14:14:37.2604353' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2042, 12, 90, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3244536' AS DateTime2), CAST(N'2021-11-20T14:14:37.7581660' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2043, 12, 91, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3271680' AS DateTime2), CAST(N'2021-11-20T14:14:44.2306715' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2044, 12, 92, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3293458' AS DateTime2), CAST(N'2021-11-20T14:14:44.7167524' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2045, 12, 93, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3320711' AS DateTime2), CAST(N'2021-11-20T14:14:45.2157182' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2046, 12, 94, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3352756' AS DateTime2), CAST(N'2021-11-20T14:14:50.2450186' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2047, 12, 95, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:54.5499771' AS DateTime2), CAST(N'2021-11-20T14:14:50.7127108' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2048, 12, 96, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:54.5558512' AS DateTime2), CAST(N'2021-11-20T14:14:59.0940904' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2049, 12, 97, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:54.5634996' AS DateTime2), CAST(N'2021-11-20T14:14:59.5930465' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2050, 12, 98, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:54.5656253' AS DateTime2), CAST(N'2021-11-20T14:15:00.1428849' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2051, 12, 99, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5672482' AS DateTime2), CAST(N'2021-11-20T13:55:54.5672482' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2052, 12, 100, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5693536' AS DateTime2), CAST(N'2021-11-20T13:55:54.5693536' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2053, 12, 101, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5714653' AS DateTime2), CAST(N'2021-11-20T13:55:54.5714653' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2054, 12, 102, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5742001' AS DateTime2), CAST(N'2021-11-20T13:55:54.5742001' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2055, 12, 103, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5770506' AS DateTime2), CAST(N'2021-11-20T13:55:54.5770506' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2056, 12, 104, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5791561' AS DateTime2), CAST(N'2021-11-20T13:55:54.5791561' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2057, 12, 105, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5812611' AS DateTime2), CAST(N'2021-11-20T13:55:54.5812611' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2058, 12, 106, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5828832' AS DateTime2), CAST(N'2021-11-20T13:55:54.5828832' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2059, 12, 107, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:54.5861421' AS DateTime2), CAST(N'2021-11-20T13:55:54.5861421' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2060, 12, 108, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:54.5877934' AS DateTime2), CAST(N'2021-11-20T13:55:54.5877934' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2061, 12, 109, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5917497' AS DateTime2), CAST(N'2021-11-20T13:55:54.5917497' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2062, 12, 110, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:56.7312058' AS DateTime2), CAST(N'2021-11-20T13:55:56.7312058' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2063, 12, 111, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7362855' AS DateTime2), CAST(N'2021-11-20T13:55:56.7362855' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2064, 12, 112, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7390216' AS DateTime2), CAST(N'2021-11-20T13:55:56.7390216' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2065, 12, 113, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7422519' AS DateTime2), CAST(N'2021-11-20T13:55:56.7422519' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2066, 12, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:56.7449882' AS DateTime2), CAST(N'2021-11-20T13:55:56.7449882' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2067, 12, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7481879' AS DateTime2), CAST(N'2021-11-20T13:55:56.7481879' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2068, 12, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:56.7498557' AS DateTime2), CAST(N'2021-11-20T13:55:56.7498557' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2069, 12, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7530124' AS DateTime2), CAST(N'2021-11-20T13:55:56.7530124' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2070, 12, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7557482' AS DateTime2), CAST(N'2021-11-20T13:55:56.7557482' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2071, 12, 119, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7578151' AS DateTime2), CAST(N'2021-11-20T13:55:56.7578151' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2072, 12, 120, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7606486' AS DateTime2), CAST(N'2021-11-20T13:55:56.7606486' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2073, 12, 121, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7638002' AS DateTime2), CAST(N'2021-11-20T13:55:56.7638002' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2074, 12, 122, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7665908' AS DateTime2), CAST(N'2021-11-20T13:55:56.7665908' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2075, 12, 123, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7695224' AS DateTime2), CAST(N'2021-11-20T13:55:56.7695224' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2076, 12, 124, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7723702' AS DateTime2), CAST(N'2021-11-20T13:55:56.7723702' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2077, 12, 125, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6182154' AS DateTime2), CAST(N'2021-11-20T13:55:58.6182154' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2078, 12, 126, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6220509' AS DateTime2), CAST(N'2021-11-20T13:55:58.6220509' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2079, 12, 127, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6266878' AS DateTime2), CAST(N'2021-11-20T13:55:58.6266878' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2080, 12, 128, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6298292' AS DateTime2), CAST(N'2021-11-20T13:55:58.6298292' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2081, 12, 129, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6327000' AS DateTime2), CAST(N'2021-11-20T13:55:58.6327000' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2082, 12, 130, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6364382' AS DateTime2), CAST(N'2021-11-20T13:55:58.6364382' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2083, 12, 131, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6403561' AS DateTime2), CAST(N'2021-11-20T13:55:58.6403561' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2084, 12, 132, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6436731' AS DateTime2), CAST(N'2021-11-20T13:55:58.6436731' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2085, 12, 133, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6481451' AS DateTime2), CAST(N'2021-11-20T13:55:58.6481451' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2086, 12, 134, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:58.6519746' AS DateTime2), CAST(N'2021-11-20T13:55:58.6519746' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2087, 12, 135, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6551150' AS DateTime2), CAST(N'2021-11-20T13:55:58.6551150' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2088, 12, 137, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:58.6591886' AS DateTime2), CAST(N'2021-11-20T13:55:58.6591886' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2089, 12, 138, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6629804' AS DateTime2), CAST(N'2021-11-20T13:55:58.6629804' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2090, 12, 145, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:58.6687455' AS DateTime2), CAST(N'2021-11-20T13:55:58.6687455' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2091, 12, 147, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:58.6737349' AS DateTime2), CAST(N'2021-11-20T13:55:58.6737349' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2092, 12, 148, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:59.7954361' AS DateTime2), CAST(N'2021-11-20T13:55:59.7954361' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2093, 12, 151, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:59.7985748' AS DateTime2), CAST(N'2021-11-20T13:55:59.7985748' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2094, 12, 152, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:59.8012689' AS DateTime2), CAST(N'2021-11-20T13:55:59.8012689' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2095, 12, 153, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:59.8054917' AS DateTime2), CAST(N'2021-11-20T13:55:59.8054917' AS DateTime2), 1, 1, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2096, 12, 154, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:59.8082139' AS DateTime2), CAST(N'2021-11-20T13:55:59.8082139' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2097, 12, 155, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:59.8093179' AS DateTime2), CAST(N'2021-11-20T14:14:45.7430698' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2098, 12, 156, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:59.8120592' AS DateTime2), CAST(N'2021-11-20T14:14:46.2307816' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2099, 12, 157, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:59.8141692' AS DateTime2), CAST(N'2021-11-20T13:55:59.8141692' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2100, 12, 158, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:59.8163039' AS DateTime2), CAST(N'2021-11-20T13:55:59.8163039' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2101, 12, 159, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:59.8180233' AS DateTime2), CAST(N'2021-11-20T13:55:59.8180233' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2102, 12, 160, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:59.8201734' AS DateTime2), CAST(N'2021-11-20T14:14:54.5131245' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2103, 12, 161, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:59.8230150' AS DateTime2), CAST(N'2021-11-20T14:14:55.2436829' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2104, 12, 162, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:59.8257061' AS DateTime2), CAST(N'2021-11-20T13:55:59.8257061' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2105, 12, 163, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:59.8290244' AS DateTime2), CAST(N'2021-11-20T13:55:59.8290244' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2106, 12, 164, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:59.8317499' AS DateTime2), CAST(N'2021-11-20T13:55:59.8317499' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2107, 12, 165, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2328783' AS DateTime2), CAST(N'2021-11-20T13:56:01.2328783' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2108, 12, 166, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2360877' AS DateTime2), CAST(N'2021-11-20T13:56:01.2360877' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2109, 12, 180, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2387764' AS DateTime2), CAST(N'2021-11-20T13:56:01.2387764' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2110, 12, 181, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2408957' AS DateTime2), CAST(N'2021-11-20T13:56:01.2408957' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2111, 12, 182, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2436235' AS DateTime2), CAST(N'2021-11-20T13:56:01.2436235' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2112, 12, 183, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2469631' AS DateTime2), CAST(N'2021-11-20T13:56:01.2469631' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2113, 12, 184, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2486662' AS DateTime2), CAST(N'2021-11-20T13:56:01.2486662' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2114, 12, 185, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2520488' AS DateTime2), CAST(N'2021-11-20T13:56:01.2520488' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2115, 12, 186, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2554088' AS DateTime2), CAST(N'2021-11-20T13:56:01.2554088' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2116, 12, 187, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2575865' AS DateTime2), CAST(N'2021-11-20T13:56:01.2575865' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2117, 12, 188, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2597220' AS DateTime2), CAST(N'2021-11-20T13:56:01.2597220' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2118, 12, 192, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2613517' AS DateTime2), CAST(N'2021-11-20T13:56:01.2613517' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2119, 12, 193, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:56:01.2645216' AS DateTime2), CAST(N'2021-11-20T13:56:01.2645216' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2120, 12, 194, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2661736' AS DateTime2), CAST(N'2021-11-20T13:56:01.2661736' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2121, 12, 195, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2693772' AS DateTime2), CAST(N'2021-11-20T13:56:01.2693772' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2122, 12, 196, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7437961' AS DateTime2), CAST(N'2021-11-20T13:56:02.7437961' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2123, 12, 197, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7465452' AS DateTime2), CAST(N'2021-11-20T13:56:02.7465452' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2124, 12, 198, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7486797' AS DateTime2), CAST(N'2021-11-20T13:56:02.7486797' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2125, 12, 199, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:56:02.7507708' AS DateTime2), CAST(N'2021-11-20T14:14:46.7332986' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2126, 12, 200, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7534666' AS DateTime2), CAST(N'2021-11-20T13:56:02.7534666' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2127, 12, 201, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7545542' AS DateTime2), CAST(N'2021-11-20T13:56:02.7545542' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2128, 12, 202, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7573200' AS DateTime2), CAST(N'2021-11-20T13:56:02.7573200' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2129, 12, 203, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:56:02.7594635' AS DateTime2), CAST(N'2022-01-24T18:01:00.4792228' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2130, 12, 204, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7622471' AS DateTime2), CAST(N'2021-11-20T13:56:02.7622471' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2131, 12, 205, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7644031' AS DateTime2), CAST(N'2021-11-20T13:56:02.7644031' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2132, 12, 206, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:56:02.7671095' AS DateTime2), CAST(N'2021-11-20T13:56:02.7671095' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2133, 12, 207, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:56:02.7692007' AS DateTime2), CAST(N'2021-11-20T13:56:02.7692007' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2134, 12, 209, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7708530' AS DateTime2), CAST(N'2021-11-20T13:56:02.7708530' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2135, 12, 210, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7729671' AS DateTime2), CAST(N'2021-11-20T13:56:02.7729671' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2136, 12, 212, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:56:02.7750678' AS DateTime2), CAST(N'2021-11-20T14:14:34.6208663' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2137, 13, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3332905' AS DateTime2), CAST(N'2021-11-20T13:57:06.3332905' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2138, 13, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3359454' AS DateTime2), CAST(N'2021-11-20T13:57:06.3359454' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2139, 13, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3380607' AS DateTime2), CAST(N'2021-11-20T13:57:06.3380607' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2140, 13, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3407562' AS DateTime2), CAST(N'2021-11-20T13:57:06.3407562' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2141, 13, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3429271' AS DateTime2), CAST(N'2021-11-20T13:57:06.3429271' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2142, 13, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3456369' AS DateTime2), CAST(N'2021-11-20T13:57:06.3456369' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2143, 13, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3488611' AS DateTime2), CAST(N'2021-11-20T13:57:06.3488611' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2144, 13, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3516969' AS DateTime2), CAST(N'2021-11-20T13:57:06.3516969' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2145, 13, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3543808' AS DateTime2), CAST(N'2021-11-20T13:57:06.3543808' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2146, 13, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3568117' AS DateTime2), CAST(N'2021-11-20T13:57:06.3568117' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2147, 13, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3584751' AS DateTime2), CAST(N'2021-11-20T13:57:06.3584751' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2148, 13, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3616225' AS DateTime2), CAST(N'2021-11-20T13:57:06.3616225' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2149, 13, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3632416' AS DateTime2), CAST(N'2021-11-20T13:57:06.3632416' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2150, 13, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3654046' AS DateTime2), CAST(N'2021-11-20T13:57:06.3654046' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2151, 13, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3681664' AS DateTime2), CAST(N'2021-11-20T13:57:06.3681664' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2152, 13, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1345923' AS DateTime2), CAST(N'2021-11-20T13:57:09.1345923' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2153, 13, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1367749' AS DateTime2), CAST(N'2021-11-20T13:57:09.1367749' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2154, 13, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1388526' AS DateTime2), CAST(N'2021-11-20T13:57:09.1388526' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2155, 13, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1415160' AS DateTime2), CAST(N'2021-11-20T13:57:09.1415160' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2156, 13, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1425674' AS DateTime2), CAST(N'2021-11-20T13:57:09.1425674' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2157, 13, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1453443' AS DateTime2), CAST(N'2021-11-20T13:57:09.1453443' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2158, 13, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1474495' AS DateTime2), CAST(N'2021-11-20T13:57:09.1474495' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2159, 13, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1485368' AS DateTime2), CAST(N'2021-11-20T13:57:09.1485368' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2160, 13, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1512528' AS DateTime2), CAST(N'2021-11-20T13:57:09.1512528' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2161, 13, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1534126' AS DateTime2), CAST(N'2021-11-20T13:57:09.1534126' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2162, 13, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1560720' AS DateTime2), CAST(N'2021-11-20T13:57:09.1560720' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2163, 13, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1581918' AS DateTime2), CAST(N'2021-11-20T13:57:09.1581918' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2164, 13, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1602606' AS DateTime2), CAST(N'2021-11-20T13:57:09.1602606' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2165, 13, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1629457' AS DateTime2), CAST(N'2021-11-20T13:57:09.1629457' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2166, 13, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1651687' AS DateTime2), CAST(N'2021-11-20T13:57:09.1651687' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2167, 13, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8259835' AS DateTime2), CAST(N'2021-11-20T13:57:12.8259835' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2168, 13, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8298126' AS DateTime2), CAST(N'2021-11-20T13:57:12.8298126' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2169, 13, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8319345' AS DateTime2), CAST(N'2021-11-20T13:57:12.8319345' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2170, 13, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8357038' AS DateTime2), CAST(N'2021-11-20T13:57:12.8357038' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2171, 13, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8378211' AS DateTime2), CAST(N'2021-11-20T13:57:12.8378211' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2172, 13, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8394225' AS DateTime2), CAST(N'2021-11-20T13:57:12.8394225' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2173, 13, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8427079' AS DateTime2), CAST(N'2021-11-20T13:57:12.8427079' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2174, 13, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8444558' AS DateTime2), CAST(N'2021-11-20T13:57:12.8444558' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2175, 13, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8465642' AS DateTime2), CAST(N'2021-11-20T13:57:12.8465642' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2176, 13, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8494680' AS DateTime2), CAST(N'2021-11-20T13:57:12.8494680' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2177, 13, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8532621' AS DateTime2), CAST(N'2021-11-20T13:57:12.8532621' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2178, 13, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8575299' AS DateTime2), CAST(N'2021-11-20T13:57:12.8575299' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2179, 13, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8602546' AS DateTime2), CAST(N'2021-11-20T13:57:12.8602546' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2180, 13, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8640783' AS DateTime2), CAST(N'2021-11-20T13:57:12.8640783' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2181, 13, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8690399' AS DateTime2), CAST(N'2021-11-20T13:57:12.8690399' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2182, 13, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4001529' AS DateTime2), CAST(N'2021-11-20T13:57:15.4001529' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2183, 13, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4039971' AS DateTime2), CAST(N'2021-11-20T13:57:15.4039971' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2184, 13, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4061002' AS DateTime2), CAST(N'2021-11-20T13:57:15.4061002' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2185, 13, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4077229' AS DateTime2), CAST(N'2021-11-20T13:57:15.4077229' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2186, 13, 50, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4109137' AS DateTime2), CAST(N'2021-11-20T13:57:15.4109137' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2187, 13, 51, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4119514' AS DateTime2), CAST(N'2021-11-20T13:57:15.4119514' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2188, 13, 52, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4145733' AS DateTime2), CAST(N'2021-11-20T13:57:15.4145733' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2189, 13, 53, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:15.4167230' AS DateTime2), CAST(N'2021-11-20T13:57:15.4167230' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2190, 13, 54, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4189217' AS DateTime2), CAST(N'2021-11-20T13:57:15.4189217' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2191, 13, 55, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:15.4205296' AS DateTime2), CAST(N'2021-11-20T13:57:15.4205296' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2192, 13, 56, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4226385' AS DateTime2), CAST(N'2021-11-20T13:57:15.4226385' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2193, 13, 57, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:15.4253939' AS DateTime2), CAST(N'2021-11-20T13:57:15.4253939' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2194, 13, 58, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4274792' AS DateTime2), CAST(N'2021-11-20T13:57:15.4274792' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2195, 13, 59, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4295870' AS DateTime2), CAST(N'2021-11-20T13:57:15.4295870' AS DateTime2), 1, 1, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2196, 13, 60, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4312039' AS DateTime2), CAST(N'2021-11-20T13:57:15.4312039' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2197, 13, 61, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9242573' AS DateTime2), CAST(N'2021-11-20T13:57:17.9242573' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2198, 13, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9284991' AS DateTime2), CAST(N'2021-11-20T13:57:17.9284991' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2199, 13, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9323653' AS DateTime2), CAST(N'2021-11-20T13:57:17.9323653' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2200, 13, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9351246' AS DateTime2), CAST(N'2021-11-20T13:57:17.9351246' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2201, 13, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9383047' AS DateTime2), CAST(N'2021-11-20T13:57:17.9383047' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2202, 13, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9399368' AS DateTime2), CAST(N'2021-11-20T13:57:17.9399368' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2203, 13, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9420639' AS DateTime2), CAST(N'2021-11-20T13:57:17.9420639' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2204, 13, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9448042' AS DateTime2), CAST(N'2021-11-20T13:57:17.9448042' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2205, 13, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9469240' AS DateTime2), CAST(N'2021-11-20T13:57:17.9469240' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2206, 13, 74, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9496921' AS DateTime2), CAST(N'2021-11-20T13:57:17.9496921' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2207, 13, 75, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9517024' AS DateTime2), CAST(N'2021-11-20T13:57:17.9517024' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2208, 13, 76, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9544612' AS DateTime2), CAST(N'2021-11-20T13:57:17.9544612' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2209, 13, 77, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9567818' AS DateTime2), CAST(N'2021-11-20T13:57:17.9567818' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2210, 13, 78, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:17.9594605' AS DateTime2), CAST(N'2021-11-20T13:57:17.9594605' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2211, 13, 79, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:17.9616210' AS DateTime2), CAST(N'2021-11-20T13:57:17.9616210' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2212, 13, 80, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6390931' AS DateTime2), CAST(N'2021-11-20T13:57:20.6390931' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2213, 13, 81, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:20.6430473' AS DateTime2), CAST(N'2021-11-20T13:57:20.6430473' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2214, 13, 82, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:20.6451969' AS DateTime2), CAST(N'2021-11-20T13:57:20.6451969' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2215, 13, 83, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6468387' AS DateTime2), CAST(N'2021-11-20T13:57:20.6468387' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2216, 13, 84, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:20.6502227' AS DateTime2), CAST(N'2021-11-20T13:57:20.6502227' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2217, 13, 85, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6518347' AS DateTime2), CAST(N'2021-11-20T13:57:20.6518347' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2218, 13, 86, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6545737' AS DateTime2), CAST(N'2021-11-20T13:57:20.6545737' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2219, 13, 87, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6577937' AS DateTime2), CAST(N'2021-11-20T13:57:20.6577937' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2220, 13, 88, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6594134' AS DateTime2), CAST(N'2021-11-20T13:57:20.6594134' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2221, 13, 89, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6625977' AS DateTime2), CAST(N'2021-11-20T13:57:20.6625977' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2222, 13, 90, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6647187' AS DateTime2), CAST(N'2021-11-20T13:57:20.6647187' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2223, 13, 91, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6674963' AS DateTime2), CAST(N'2021-11-20T13:57:20.6674963' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2224, 13, 92, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6695550' AS DateTime2), CAST(N'2021-11-20T13:57:20.6695550' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2225, 13, 93, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6723518' AS DateTime2), CAST(N'2021-11-20T13:57:20.6723518' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2226, 13, 94, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6751494' AS DateTime2), CAST(N'2021-11-20T13:57:20.6751494' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2227, 13, 95, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6051298' AS DateTime2), CAST(N'2021-11-20T13:57:23.6051298' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2228, 13, 96, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6095541' AS DateTime2), CAST(N'2021-11-20T13:57:23.6095541' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2229, 13, 97, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6128420' AS DateTime2), CAST(N'2021-11-20T13:57:23.6128420' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2230, 13, 98, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6156623' AS DateTime2), CAST(N'2021-11-20T13:57:23.6156623' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2231, 13, 99, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6196479' AS DateTime2), CAST(N'2021-11-20T13:57:23.6196479' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2232, 13, 100, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6235176' AS DateTime2), CAST(N'2021-11-20T13:57:23.6235176' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2233, 13, 101, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6262819' AS DateTime2), CAST(N'2021-11-20T13:57:23.6262819' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2234, 13, 102, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6301074' AS DateTime2), CAST(N'2021-11-20T13:57:23.6301074' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2235, 13, 103, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6340714' AS DateTime2), CAST(N'2021-11-20T13:57:23.6340714' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2236, 13, 104, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6374116' AS DateTime2), CAST(N'2021-11-20T13:57:23.6374116' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2237, 13, 105, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6407888' AS DateTime2), CAST(N'2021-11-20T13:57:23.6407888' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2238, 13, 106, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6441080' AS DateTime2), CAST(N'2021-11-20T13:57:23.6441080' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2239, 13, 107, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:23.6468793' AS DateTime2), CAST(N'2021-11-20T13:57:23.6468793' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2240, 13, 108, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:23.6496247' AS DateTime2), CAST(N'2021-11-20T13:57:23.6496247' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2241, 13, 109, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6517574' AS DateTime2), CAST(N'2021-11-20T13:57:23.6517574' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2242, 13, 110, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:30.5342132' AS DateTime2), CAST(N'2021-11-20T13:57:30.5342132' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2243, 13, 111, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5392431' AS DateTime2), CAST(N'2021-11-20T13:57:30.5392431' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2244, 13, 112, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5419365' AS DateTime2), CAST(N'2021-11-20T13:57:30.5419365' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2245, 13, 113, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5447909' AS DateTime2), CAST(N'2021-11-20T13:57:30.5447909' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2246, 13, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:30.5479514' AS DateTime2), CAST(N'2021-11-20T13:57:30.5479514' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2247, 13, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5507813' AS DateTime2), CAST(N'2021-11-20T13:57:30.5507813' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2248, 13, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:30.5535040' AS DateTime2), CAST(N'2021-11-20T13:57:30.5535040' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2249, 13, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5556578' AS DateTime2), CAST(N'2021-11-20T13:57:30.5556578' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2250, 13, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5599470' AS DateTime2), CAST(N'2021-11-20T13:57:30.5599470' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2251, 13, 119, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5648905' AS DateTime2), CAST(N'2021-11-20T13:57:30.5648905' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2252, 13, 120, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5681482' AS DateTime2), CAST(N'2021-11-20T13:57:30.5681482' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2253, 13, 121, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5714060' AS DateTime2), CAST(N'2021-11-20T13:57:30.5714060' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2254, 13, 122, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:30.5742298' AS DateTime2), CAST(N'2021-11-20T14:15:13.9440450' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2255, 13, 123, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:30.5769456' AS DateTime2), CAST(N'2021-11-20T14:15:14.4632723' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2256, 13, 124, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:30.5802259' AS DateTime2), CAST(N'2021-11-20T14:15:17.7024911' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2257, 13, 125, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7131042' AS DateTime2), CAST(N'2021-11-20T14:15:18.2513365' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2258, 13, 126, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7170516' AS DateTime2), CAST(N'2021-11-20T14:15:21.7617388' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2259, 13, 127, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7197095' AS DateTime2), CAST(N'2021-11-20T14:15:22.2971691' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2260, 13, 128, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7225090' AS DateTime2), CAST(N'2021-11-20T14:15:25.6262284' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2261, 13, 129, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7252886' AS DateTime2), CAST(N'2021-11-20T14:15:26.2098267' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2262, 13, 130, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:31.7285573' AS DateTime2), CAST(N'2021-11-20T13:57:31.7285573' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2263, 13, 131, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:31.7323598' AS DateTime2), CAST(N'2021-11-20T13:57:31.7323598' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2264, 13, 132, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7361506' AS DateTime2), CAST(N'2021-11-20T14:15:30.7213602' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2265, 13, 133, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7406326' AS DateTime2), CAST(N'2021-11-20T14:15:31.2036413' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2266, 13, 134, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:57:31.7460527' AS DateTime2), CAST(N'2021-11-20T14:15:10.9843106' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2267, 13, 135, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7509781' AS DateTime2), CAST(N'2021-11-20T14:15:11.5351160' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2268, 13, 137, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:31.7557187' AS DateTime2), CAST(N'2021-11-20T13:57:31.7557187' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2269, 13, 138, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:31.7605106' AS DateTime2), CAST(N'2021-11-20T13:57:31.7605106' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2270, 13, 145, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:31.7647349' AS DateTime2), CAST(N'2021-11-20T13:57:31.7647349' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2271, 13, 147, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:31.7696479' AS DateTime2), CAST(N'2021-11-20T13:57:31.7696479' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2272, 13, 148, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:32.8887059' AS DateTime2), CAST(N'2021-11-20T13:57:32.8887059' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2273, 13, 151, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:32.8924501' AS DateTime2), CAST(N'2021-11-20T13:57:32.8924501' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2274, 13, 152, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:32.8951653' AS DateTime2), CAST(N'2021-11-20T13:57:32.8951653' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2275, 13, 153, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.8983215' AS DateTime2), CAST(N'2021-11-20T13:57:32.8983215' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2276, 13, 154, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9010516' AS DateTime2), CAST(N'2021-11-20T13:57:32.9010516' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2277, 13, 155, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9042553' AS DateTime2), CAST(N'2021-11-20T13:57:32.9042553' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2278, 13, 156, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9070205' AS DateTime2), CAST(N'2021-11-20T13:57:32.9070205' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2279, 13, 157, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:32.9091734' AS DateTime2), CAST(N'2021-11-20T13:57:32.9091734' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2280, 13, 158, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9118980' AS DateTime2), CAST(N'2021-11-20T13:57:32.9118980' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2281, 13, 159, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:32.9139877' AS DateTime2), CAST(N'2021-11-20T13:57:32.9139877' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2282, 13, 160, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9167376' AS DateTime2), CAST(N'2021-11-20T13:57:32.9167376' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2283, 13, 161, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9188999' AS DateTime2), CAST(N'2021-11-20T13:57:32.9188999' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2284, 13, 162, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9216624' AS DateTime2), CAST(N'2021-11-20T13:57:32.9216624' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2285, 13, 163, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9237732' AS DateTime2), CAST(N'2021-11-20T13:57:32.9237732' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2286, 13, 164, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9265122' AS DateTime2), CAST(N'2021-11-20T13:57:32.9265122' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2287, 13, 165, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0329134' AS DateTime2), CAST(N'2021-11-20T13:57:34.0329134' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2288, 13, 166, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:34.0366996' AS DateTime2), CAST(N'2021-11-20T14:15:31.6697738' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2289, 13, 180, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0399190' AS DateTime2), CAST(N'2021-11-20T13:57:34.0399190' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2290, 13, 181, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0426158' AS DateTime2), CAST(N'2021-11-20T13:57:34.0426158' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2291, 13, 182, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0458790' AS DateTime2), CAST(N'2021-11-20T13:57:34.0458790' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2292, 13, 183, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0496458' AS DateTime2), CAST(N'2021-11-20T13:57:34.0496458' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2293, 13, 184, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0524143' AS DateTime2), CAST(N'2021-11-20T13:57:34.0524143' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2294, 13, 185, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0556823' AS DateTime2), CAST(N'2021-11-20T13:57:34.0556823' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2295, 13, 186, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0584001' AS DateTime2), CAST(N'2021-11-20T13:57:34.0584001' AS DateTime2), 1, 1, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2296, 13, 187, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0632713' AS DateTime2), CAST(N'2021-11-20T13:57:34.0632713' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2297, 13, 188, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0654001' AS DateTime2), CAST(N'2021-11-20T13:57:34.0654001' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2298, 13, 192, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0681962' AS DateTime2), CAST(N'2021-11-20T13:57:34.0681962' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2299, 13, 193, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:34.0720528' AS DateTime2), CAST(N'2021-11-20T13:57:34.0720528' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2300, 13, 194, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0743217' AS DateTime2), CAST(N'2021-11-20T13:57:34.0743217' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2301, 13, 195, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0759862' AS DateTime2), CAST(N'2021-11-20T13:57:34.0759862' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2302, 13, 196, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2154238' AS DateTime2), CAST(N'2021-11-20T13:57:35.2154238' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2303, 13, 197, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2204733' AS DateTime2), CAST(N'2021-11-20T13:57:35.2204733' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2304, 13, 198, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2253246' AS DateTime2), CAST(N'2021-11-20T13:57:35.2253246' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2305, 13, 199, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2302164' AS DateTime2), CAST(N'2021-11-20T13:57:35.2302164' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2306, 13, 200, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2340013' AS DateTime2), CAST(N'2021-11-20T13:57:35.2340013' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2307, 13, 201, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2388839' AS DateTime2), CAST(N'2021-11-20T13:57:35.2388839' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2308, 13, 202, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2431788' AS DateTime2), CAST(N'2021-11-20T13:57:35.2431788' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2309, 13, 203, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2476505' AS DateTime2), CAST(N'2021-11-20T13:57:35.2476505' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2310, 13, 204, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:35.2524962' AS DateTime2), CAST(N'2022-01-24T18:01:16.4714839' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2311, 13, 205, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2567729' AS DateTime2), CAST(N'2021-11-20T13:57:35.2567729' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2312, 13, 206, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:35.2605464' AS DateTime2), CAST(N'2021-11-20T13:57:35.2605464' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2313, 13, 207, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:35.2663637' AS DateTime2), CAST(N'2021-11-20T13:57:35.2663637' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2314, 13, 209, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2700991' AS DateTime2), CAST(N'2021-11-20T13:57:35.2700991' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2315, 13, 210, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2733034' AS DateTime2), CAST(N'2021-11-20T13:57:35.2733034' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2316, 13, 212, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2782000' AS DateTime2), CAST(N'2021-11-20T13:57:35.2782000' AS DateTime2), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[groupObject] OFF
GO
SET IDENTITY_INSERT [dbo].[groups] ON 

INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (10, N'Management', N'', CAST(N'2021-11-18T18:54:14.8061474' AS DateTime2), CAST(N'2021-11-18T18:54:14.8061474' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (11, N'Purchase/sale', N'', CAST(N'2021-11-20T13:44:07.4592974' AS DateTime2), CAST(N'2021-11-20T13:44:07.4592974' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (12, N'storage', N'', CAST(N'2021-11-20T13:54:57.8851425' AS DateTime2), CAST(N'2021-11-20T14:12:54.9483755' AS DateTime2), 1, 1, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (13, N'accounts', N'', CAST(N'2021-11-20T13:56:35.3006277' AS DateTime2), CAST(N'2021-11-20T14:13:05.0728651' AS DateTime2), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[groups] OFF
GO
SET IDENTITY_INSERT [dbo].[locations] ON 

INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (1, N'0', N'0', N'0', CAST(N'2021-10-27T14:24:10.1324341' AS DateTime2), CAST(N'2021-10-27T14:24:10.1324341' AS DateTime2), 1, 1, 1, 1, N'', 2, 1)
SET IDENTITY_INSERT [dbo].[locations] OFF
GO
SET IDENTITY_INSERT [dbo].[objects] ON 

INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (1, N'catalog', N'', NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (2, N'storage', N'', NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (3, N'purchase', N'', NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (4, N'sales', N'', NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (5, N'accounts', N'', NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (6, N'sectionData', N'', NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (7, N'settings', N'', NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (8, N'home', N'', NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (9, N'categories', N'', NULL, NULL, NULL, NULL, 1, 1, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (10, N'item', N'', NULL, NULL, NULL, NULL, 1, 1, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (11, N'properties', N'', NULL, NULL, NULL, NULL, 1, 1, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (12, N'units', N'', NULL, NULL, NULL, NULL, 1, 1, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (13, N'locations', N'', NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (14, N'section', N'', NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (15, N'reciptOfInvoice', N'', NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (16, N'itemsStorage', N'', NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (17, N'importExport', N'', NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (18, N'itemsDestroy', N'', NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (19, N'inventory', N'', NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (20, N'storageStatistic', N'', NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (21, N'payInvoice', N'', NULL, NULL, NULL, NULL, 1, 3, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (22, N'purchaseStatistic', N'', NULL, NULL, NULL, NULL, 1, 3, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (23, N'reciptInvoice', N'', NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (24, N'coupon', N'', NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (25, N'offer', N'', NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (26, N'package', N'', NULL, NULL, NULL, NULL, 1, 1, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (27, N'quotation', N'', NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (28, N'medals', N'', NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (29, N'membership', N'', NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (30, N'salesStatistic', N'', NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (31, N'posAccounting', N'', NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (32, N'payments', N'', NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (33, N'received', N'', NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (34, N'bonds', N'', NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (35, N'banksAccounting', N'', NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (36, N'accountsStatistic', N'', NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (37, N'suppliers', N'', NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (38, N'customers', N'', NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (39, N'users', N'', NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (40, N'branches', N'', NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (41, N'stores', N'', NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (42, N'pos', N'', NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (43, N'banks', N'', NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (44, N'cards', N'', NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (45, N'shippingCompany', N'', NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (46, N'general', N'', NULL, NULL, NULL, NULL, 1, 7, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (47, N'reportsSettings', N'', NULL, NULL, NULL, NULL, 1, 7, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (48, N'permissions', N'', NULL, NULL, NULL, NULL, 1, 7, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (49, N'subscriptions', N'', NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (50, N'suppliers_basics', N'', NULL, NULL, NULL, NULL, 1, 37, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (51, N'customers_basics', N'', NULL, NULL, NULL, NULL, 1, 38, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (52, N'users_basics', N'', NULL, NULL, NULL, NULL, 1, 39, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (53, N'users_stores', N'', NULL, NULL, NULL, NULL, 1, 39, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (54, N'branches_basics', N'', NULL, NULL, NULL, NULL, 1, 40, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (55, N'branches_branches', N'', NULL, NULL, NULL, NULL, 1, 40, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (56, N'stores_basics', N'', NULL, NULL, NULL, NULL, 1, 41, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (57, N'stores_branches', N'', NULL, NULL, NULL, NULL, 1, 41, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (58, N'pos_basics', N'', NULL, NULL, NULL, NULL, 1, 42, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (59, N'banks_basics', N'', NULL, NULL, NULL, NULL, 1, 43, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (60, N'cards_basics', N'', NULL, NULL, NULL, NULL, 1, 44, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (61, N'shippingCompany_basics', N'', NULL, NULL, NULL, NULL, 1, 45, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (63, N'reports', N'', NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (65, N'ordersAccounting', N'', NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (67, N'salesOrders', N'', NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (68, N'salesReports', N'', NULL, NULL, NULL, NULL, 1, 63, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (69, N'purchaseReports', N'', NULL, NULL, NULL, NULL, 1, 63, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (70, N'storageReports', N'', NULL, NULL, NULL, NULL, 1, 63, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (71, N'accountsReports', N'', NULL, NULL, NULL, NULL, 1, 63, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (72, N'usersReports', N'', NULL, NULL, NULL, NULL, 1, 63, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (74, N'categories_basics', N'', NULL, NULL, NULL, NULL, 1, 9, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (75, N'item_basics', N'', NULL, NULL, NULL, NULL, 1, 10, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (76, N'properties_basics', N'', NULL, NULL, NULL, NULL, 1, 11, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (77, N'units_basics', N'', NULL, NULL, NULL, NULL, 1, 12, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (78, N'general_usersSettings', N'', NULL, NULL, NULL, NULL, 1, 46, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (79, N'general_companySettings', N'', NULL, NULL, NULL, NULL, 1, 46, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (80, N'reports_usersSettings', N'', NULL, NULL, NULL, NULL, 1, 47, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (81, N'permissions_basics', N'', NULL, NULL, NULL, NULL, 1, 48, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (82, N'locations_basics', N'', NULL, NULL, NULL, NULL, 1, 13, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (83, N'locations_addRange', N'', NULL, NULL, NULL, NULL, 1, 13, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (84, N'section_basics', N'', NULL, NULL, NULL, NULL, 1, 14, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (85, N'section_selectLocation', N'', NULL, NULL, NULL, NULL, 1, 14, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (86, N'reciptOfInvoice_recipt', N'', NULL, NULL, NULL, NULL, 1, 15, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (87, N'reciptOfInvoice_return', N'', NULL, NULL, NULL, NULL, 1, 15, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (88, N'reciptOfInvoice_reports', N'', NULL, NULL, NULL, NULL, 1, 15, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (89, N'itemsStorage_transfer', N'', NULL, NULL, NULL, NULL, 1, 16, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (90, N'itemsStorage_reports', N'', NULL, NULL, NULL, NULL, 1, 16, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (91, N'importExport_import', N'', NULL, NULL, NULL, NULL, 1, 17, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (92, N'importExport_export', N'', NULL, NULL, NULL, NULL, 1, 17, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (93, N'importExport_reports', N'', NULL, NULL, NULL, NULL, 1, 17, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (94, N'itemsDestroy_destroy', N'', NULL, NULL, NULL, NULL, 1, 18, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (95, N'itemsDestroy_reports', N'', NULL, NULL, NULL, NULL, 1, 18, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (96, N'inventory_create', N'', NULL, NULL, NULL, NULL, 1, 19, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (97, N'inventory_archiving', N'', NULL, NULL, NULL, NULL, 1, 19, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (98, N'inventory_reports', N'', NULL, NULL, NULL, NULL, 1, 19, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (99, N'payInvoice_invoice', N'', NULL, NULL, NULL, NULL, 1, 21, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (100, N'payInvoice_return', N'', NULL, NULL, NULL, NULL, 1, 21, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (101, N'payInvoice_payments', N'', NULL, NULL, NULL, NULL, 1, 21, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (102, N'reciptInvoice_invoice', N'', NULL, NULL, NULL, NULL, 1, 23, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (103, N'reciptInvoice_return', N'', NULL, NULL, NULL, NULL, 1, 23, N'one')
GO
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (104, N'reciptInvoice_payments', N'', NULL, NULL, NULL, NULL, 1, 23, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (105, N'reciptInvoice_executeOrder', N'', NULL, NULL, NULL, NULL, 1, 23, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (106, N'reciptInvoice_quotation', N'', NULL, NULL, NULL, NULL, 1, 23, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (107, N'coupon_basics', N'', NULL, NULL, NULL, NULL, 1, 24, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (108, N'offer_basics', N'', NULL, NULL, NULL, NULL, 1, 25, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (109, N'offer_items', N'', NULL, NULL, NULL, NULL, 1, 25, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (110, N'package_basics', N'', NULL, NULL, NULL, NULL, 1, 26, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (111, N'package_items', N'', NULL, NULL, NULL, NULL, 1, 26, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (112, N'quotation_create', N'', NULL, NULL, NULL, NULL, 1, 27, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (113, N'quotation_reports', N'', NULL, NULL, NULL, NULL, 1, 27, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (114, N'medals_basics', N'', NULL, NULL, NULL, NULL, 1, 28, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (115, N'medals_customers', N'', NULL, NULL, NULL, NULL, 1, 28, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (116, N'membership_basics', N'', NULL, NULL, NULL, NULL, 1, 29, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (117, N'membership_customers', N'', NULL, NULL, NULL, NULL, 1, 29, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (118, N'membership_subscriptionFees', N'', NULL, NULL, NULL, NULL, 1, 29, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (119, N'salesOrders_create', N'', NULL, NULL, NULL, NULL, 1, 67, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (120, N'salesOrders_delivery', N'', NULL, NULL, NULL, NULL, 1, 67, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (121, N'salesOrders_reports', N'', NULL, NULL, NULL, NULL, 1, 67, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (122, N'payments_create', N'', NULL, NULL, NULL, NULL, 1, 32, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (123, N'payments_reports', N'', NULL, NULL, NULL, NULL, 1, 32, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (124, N'received_create', N'', NULL, NULL, NULL, NULL, 1, 33, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (125, N'received_reports', N'', NULL, NULL, NULL, NULL, 1, 33, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (126, N'bonds_create', N'', NULL, NULL, NULL, NULL, 1, 34, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (127, N'bonds_reports', N'', NULL, NULL, NULL, NULL, 1, 34, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (128, N'banksAccounting_create', N'', NULL, NULL, NULL, NULL, 1, 35, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (129, N'banksAccounting_reports', N'', NULL, NULL, NULL, NULL, 1, 35, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (130, N'subscriptions_create', N'', NULL, NULL, NULL, NULL, 1, 49, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (131, N'subscriptions_reports', N'', NULL, NULL, NULL, NULL, 1, 49, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (132, N'ordersAccounting_create', N'', NULL, NULL, NULL, NULL, 1, 65, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (133, N'ordersAccounting_reports', N'', NULL, NULL, NULL, NULL, 1, 65, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (134, N'posAccounting_basics', N'', NULL, NULL, NULL, NULL, 1, 31, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (135, N'posAccounting_transAdmin', N'', NULL, NULL, NULL, NULL, 1, 31, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (137, N'unit_basics', N'', NULL, NULL, NULL, NULL, 1, 10, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (138, N'Permissions_users', N'', NULL, NULL, NULL, NULL, 1, 48, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (145, N'storageCost_basics', N'', NULL, NULL, NULL, NULL, 1, 147, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (147, N'storageCost', N'', NULL, NULL, NULL, NULL, 1, 1, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (148, N'emailsSetting', N'', NULL, NULL, NULL, NULL, 1, 7, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (151, N'emailsSetting_basics', N'', NULL, NULL, NULL, NULL, 1, 148, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (152, N'purchaseOrder', N'', NULL, NULL, NULL, NULL, 1, 3, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (153, N'purchaseOrder_create', N'', NULL, NULL, NULL, NULL, 1, 152, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (154, N'purchaseOrder_reports', N'', NULL, NULL, NULL, NULL, 1, 152, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (155, N'importExport_package', N'', NULL, NULL, NULL, NULL, 1, 17, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (156, N'importExport_unitConversion', N'', NULL, NULL, NULL, NULL, 1, 17, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (157, N'emailTemplates', N'', NULL, NULL, NULL, NULL, 1, 7, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (158, N'emailTemplates_save', N'', NULL, NULL, NULL, NULL, 1, 157, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (159, N'shortage', N'', NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (160, N'shortage_save', N'', NULL, NULL, NULL, NULL, 1, 159, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (161, N'shortage_reports', N'', NULL, NULL, NULL, NULL, 1, 159, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (162, N'reciptInvoice_sendEmail', N'', NULL, NULL, NULL, NULL, 1, 23, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (163, N'salesOrders_sendEmail', N'', NULL, NULL, NULL, NULL, 1, 67, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (164, N'payInvoice_sendEmail', N'', NULL, NULL, NULL, NULL, 1, 21, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (165, N'purchaseOrder_sendEmail', N'', NULL, NULL, NULL, NULL, 1, 152, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (166, N'ordersAccounting_allBranches', N'', NULL, NULL, NULL, NULL, 1, 65, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (180, N'alerts', N'', NULL, NULL, NULL, NULL, 1, NULL, N'alert')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (181, N'storageAlerts', N'', NULL, NULL, NULL, NULL, 1, 180, N'alert')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (182, N'saleAlerts', N'', NULL, NULL, NULL, NULL, 1, 180, N'alert')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (183, N'accountsAlerts', N'', NULL, NULL, NULL, NULL, 1, 180, N'alert')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (184, N'storageAlerts_minMaxItem', N'', NULL, NULL, NULL, NULL, 1, 181, N'alert')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (185, N'storageAlerts_ImpExp', N'', NULL, NULL, NULL, NULL, 1, 181, N'alert')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (186, N'storageAlerts_ctreatePurchaseInvoice', N'', NULL, NULL, NULL, NULL, 1, 181, N'alert')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (187, N'storageAlerts_ctreatePurchaseReturnInvoice', N'', NULL, NULL, NULL, NULL, 1, 181, N'alert')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (188, N'saleAlerts_executeOrder', N'', NULL, NULL, NULL, NULL, 1, 182, N'alert')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (192, N'reports_companySettings', N'', NULL, NULL, NULL, NULL, 1, 47, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (193, N'dashboard', N'', NULL, NULL, NULL, NULL, 1, 8, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (194, N'dashboard_view', N'', NULL, NULL, NULL, NULL, 1, 193, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (195, N'dashboard_branches', N'', NULL, NULL, NULL, NULL, 1, 193, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (196, N'payInvoice_openOrder', N'', NULL, NULL, NULL, NULL, 1, 21, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (197, N'payInvoice_initializeShortage', N'', NULL, NULL, NULL, NULL, 1, 21, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (198, N'purchaseOrder_initializeShortage', N'', NULL, NULL, NULL, NULL, 1, 152, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (199, N'importExport_initializeShortage', N'', NULL, NULL, NULL, NULL, 1, 17, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (200, N'salesStatistic_statistic', N'', NULL, NULL, NULL, NULL, 1, 30, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (201, N'salesReports_view', N'', NULL, NULL, NULL, NULL, 1, 68, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (202, N'purchaseReports_view', N'', NULL, NULL, NULL, NULL, 1, 69, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (203, N'storageReports_view', N'', NULL, NULL, NULL, NULL, 1, 70, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (204, N'accountsReports_view', N'', NULL, NULL, NULL, NULL, 1, 71, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (205, N'usersReports_view', N'', NULL, NULL, NULL, NULL, 1, 72, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (206, N'service', N'', NULL, NULL, NULL, NULL, 1, 1, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (207, N'service_basics', N'', NULL, NULL, NULL, NULL, 1, 206, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (209, N'reciptInvoice_printCount', N'', NULL, NULL, NULL, NULL, 1, 23, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (210, N'payInvoice_printCount', N'', NULL, NULL, NULL, NULL, 1, 21, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (212, N'reciptOfInvoice_inputs', N'', NULL, NULL, NULL, NULL, 1, 15, N'one')
SET IDENTITY_INSERT [dbo].[objects] OFF
GO
SET IDENTITY_INSERT [dbo].[paperSize] ON 

INSERT [dbo].[paperSize] ([sizeId], [paperSize], [printfor], [sizeValue]) VALUES (1, N'A4', N'sal-doc', N'A4')
INSERT [dbo].[paperSize] ([sizeId], [paperSize], [printfor], [sizeValue]) VALUES (2, N'Width:10 cm', N'sal', N'10cm')
INSERT [dbo].[paperSize] ([sizeId], [paperSize], [printfor], [sizeValue]) VALUES (3, N'Width:8 cm', N'sal', N'8cm')
INSERT [dbo].[paperSize] ([sizeId], [paperSize], [printfor], [sizeValue]) VALUES (4, N'Width:5.7 cm', N'sal', N'5.7cm')
INSERT [dbo].[paperSize] ([sizeId], [paperSize], [printfor], [sizeValue]) VALUES (6, N'A5', N'doc', N'A5')
SET IDENTITY_INSERT [dbo].[paperSize] OFF
GO
SET IDENTITY_INSERT [dbo].[pos] ON 

INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll], [boxState], [isAdminClose]) VALUES (1, N'Main-POS-1', N'POS-1', CAST(0.000 AS Decimal(20, 3)), 2, CAST(N'2021-06-29T16:51:49.0366461' AS DateTime2), CAST(N'2022-03-02T12:46:44.5605448' AS DateTime2), 1, 1, 1, N'', CAST(0.000 AS Decimal(20, 3)), N'c', 0)
SET IDENTITY_INSERT [dbo].[pos] OFF
GO
INSERT [dbo].[ProgramDetails] ([id], [programName], [branchCount], [posCount], [userCount], [vendorCount], [customerCount], [itemCount], [saleinvCount], [programIncId], [versionIncId], [versionName], [storeCount], [packageSaleCode], [customerServerCode], [expireDate], [isOnlineServer], [packageNumber], [updateDate], [isLimitDate], [isLimitCount], [isActive], [packageName], [bookDate], [pId], [pcdId], [customerName], [customerLastName], [agentName], [agentLastName], [agentAccountName], [isServerActivated], [activatedate], [pocrDate], [poId], [upnum], [notes]) VALUES (1, N'0', 0, 0, 0, 0, 0, 0, 0, NULL, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, CAST(N'2022-01-29T15:03:11.0941616' AS DateTime2), NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, N'', N'')
GO
SET IDENTITY_INSERT [dbo].[properties] ON 

INSERT [dbo].[properties] ([propertyId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1, N'Colors', CAST(N'2021-10-27T17:34:44.9898673' AS DateTime2), CAST(N'2021-11-20T14:55:12.3224772' AS DateTime2), 1, 1, 1)
INSERT [dbo].[properties] ([propertyId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'Size', CAST(N'2021-10-27T17:34:57.8915060' AS DateTime2), CAST(N'2021-11-28T12:41:00.4253024' AS DateTime2), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[properties] OFF
GO
SET IDENTITY_INSERT [dbo].[propertiesItems] ON 

INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'red', 1, NULL, CAST(N'2021-10-27T17:35:27.7476986' AS DateTime2), CAST(N'2021-11-20T14:25:53.7708669' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, N'Blue', 1, NULL, CAST(N'2021-10-27T17:35:39.7802301' AS DateTime2), CAST(N'2021-11-20T14:54:51.3723312' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (4, N'Yellow ', 1, NULL, CAST(N'2021-10-27T17:35:47.7848219' AS DateTime2), CAST(N'2021-11-20T14:27:50.2750744' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (5, N'Purple', 1, NULL, CAST(N'2021-10-27T17:35:53.7380560' AS DateTime2), CAST(N'2021-11-20T14:36:50.1192021' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (6, N'Green', 1, NULL, CAST(N'2021-10-27T17:36:09.3678435' AS DateTime2), CAST(N'2021-11-20T14:44:23.0490106' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (7, N'Maroon', 1, NULL, CAST(N'2021-10-27T17:36:12.3667652' AS DateTime2), CAST(N'2021-11-20T14:45:26.2790105' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (8, N'Aqua', 1, NULL, CAST(N'2021-10-27T17:36:20.9386710' AS DateTime2), CAST(N'2021-11-20T14:47:23.3683413' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (9, N'White', 1, NULL, CAST(N'2021-10-27T17:36:27.1893593' AS DateTime2), CAST(N'2021-11-20T14:53:28.7535679' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (10, N'Black', 1, NULL, CAST(N'2021-10-27T17:36:33.0240117' AS DateTime2), CAST(N'2021-11-20T14:53:47.1298025' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (13, N'S', 2, NULL, CAST(N'2021-10-27T17:36:09.3678435' AS DateTime2), CAST(N'2021-10-27T17:36:09.3678435' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (14, N'M', 2, NULL, CAST(N'2021-10-27T17:36:12.3667652' AS DateTime2), CAST(N'2021-10-27T17:36:12.3667652' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (15, N'L', 2, NULL, CAST(N'2021-10-27T17:36:20.9386710' AS DateTime2), CAST(N'2021-10-27T17:36:20.9386710' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (16, N'XL', 2, NULL, CAST(N'2021-10-27T17:36:27.1893593' AS DateTime2), CAST(N'2021-10-27T17:36:27.1893593' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (17, N'XLL', 2, NULL, CAST(N'2021-10-27T17:36:33.0240117' AS DateTime2), CAST(N'2021-10-27T17:36:33.0240117' AS DateTime2), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[propertiesItems] OFF
GO
SET IDENTITY_INSERT [dbo].[sections] ON 

INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (1, N'FreeZone', CAST(N'2021-10-27T14:24:09.6148636' AS DateTime2), CAST(N'2021-10-27T14:24:09.6148636' AS DateTime2), 1, 1, 2, 1, N'', 1)
SET IDENTITY_INSERT [dbo].[sections] OFF
GO
SET IDENTITY_INSERT [dbo].[setting] ON 

INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (1, N'com_name', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (2, N'com_address', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (3, N'com_email', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (4, N'com_mobile', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (5, N'com_phone', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (6, N'com_fax', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (7, N'com_logo', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (8, N'region', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (9, N'language', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (10, N'currency', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (11, N'tax', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (12, N'storage_cost', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (13, N'pur_order_email_temp', N'emailtemp')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (14, N'dateForm', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (15, N'sale_email_temp', N'emailtemp')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (16, N'sale_order_email_temp', N'emailtemp')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (17, N'quotation_email_temp', N'emailtemp')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (18, N'required_email_temp', N'emailtemp')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (19, N'sale_copy_count', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (20, N'pur_copy_count', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (21, N'print_on_save_sale', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (22, N'print_on_save_pur', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (23, N'email_on_save_sale', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (24, N'email_on_save_pur', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (25, N'menuIsOpen', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (26, N'report_lang', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (27, N'rep_copy_count', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (28, N'user_path', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (29, N'accuracy', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (30, N'pur_email_temp', N'emailtemp')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (31, N'Pur_inv_avg_count', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (32, N'Allow_print_inv_count', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (33, N'item_cost', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (34, N'invoiceTax_bool', N'tax')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (35, N'invoiceTax_decimal', N'tax')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (36, N'itemsTax_bool', N'tax')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (37, N'itemsTax_decimal', N'tax')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (38, N'active_site', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (39, N'show_header', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (40, N'itemtax_note', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (41, N'sales_invoice_note', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (42, N'print_on_save_directentry', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (43, N'directentry_copy_count', NULL)
SET IDENTITY_INSERT [dbo].[setting] OFF
GO
SET IDENTITY_INSERT [dbo].[setValues] ON 

INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (1, N'en', NULL, NULL, NULL, 9)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (2, N'ar', NULL, NULL, NULL, 9)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (12, N'0', 0, 1, NULL, 11)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (13, N'0', 1, 1, NULL, 12)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (14, N'no-image-icon-125x125.png', 1, 1, N'', 7)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (15, N'', NULL, 1, N'title', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (16, N'', NULL, 1, N'text1', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (17, N'', NULL, 1, N'text2', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (18, N'', NULL, 1, N'link1text', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (19, N'', NULL, 1, N'link2text', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (20, N'', NULL, NULL, N'link3text', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (22, N'', NULL, 1, N'link1url', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (23, N'', NULL, 1, N'link2url', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (24, N'', NULL, 1, N'link3url', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (25, N'ShortDatePattern', 1, 1, NULL, 14)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (26, N'', NULL, 1, N'title', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (27, N'', NULL, 1, N'text1', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (28, N'', NULL, 1, N'text2', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (29, N'', NULL, 1, N'link1text', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (30, N'', NULL, 1, N'link2text', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (31, N'', NULL, NULL, N'link3text', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (32, N'', NULL, 1, N'link1url', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (33, N'', NULL, 1, N'link2url', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (34, N'', NULL, 1, N'link3url', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (39, N'', NULL, 1, N'title', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (40, N'', NULL, NULL, N'text1', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (41, N'', NULL, 1, N'text2', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (42, N'', NULL, 1, N'link1text', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (43, N'', NULL, 1, N'link2text', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (44, N'', NULL, 1, N'link3text', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (45, N'', NULL, 1, N'link1url', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (46, N'', NULL, 1, N'link2url', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (47, N'', NULL, 1, N'link3url', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (48, N'', NULL, 1, N'title', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (49, N'', NULL, NULL, N'text1', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (50, N'', NULL, 1, N'text2', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (51, N'', NULL, 1, N'link1text', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (52, N'', NULL, 1, N'link2text', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (53, N'', NULL, NULL, N'link3text', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (54, N'', NULL, 1, N'link1url', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (55, N'', NULL, 1, N'link2url', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (56, N'', NULL, 1, N'link3url', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (58, N'', 1, 1, NULL, 1)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (59, N'', 1, 1, NULL, 2)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (60, N'', 1, 1, NULL, 3)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (61, N'', 1, 1, NULL, 4)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (62, N'', 1, 1, NULL, 5)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (63, N'', 1, 1, NULL, 6)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (64, N'', NULL, 1, N'title', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (65, N'', NULL, NULL, N'text1', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (66, N'', NULL, 1, N'text2', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (67, N'', NULL, 1, N'link1text', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (68, N'', NULL, 1, N'link2text', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (69, N'', NULL, NULL, N'link3text', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (70, N'', NULL, 1, N'link1url', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (71, N'', NULL, 1, N'link2url', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (72, N'', NULL, 1, N'link3url', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (73, N'1', NULL, 1, N'print', 19)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (74, N'1', NULL, 1, N'print', 20)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (75, N'0', NULL, 1, N'print', 21)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (76, N'0', NULL, 1, N'print', 22)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (77, N'0', NULL, 1, N'print', 23)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (78, N'0', NULL, 1, N'print', 24)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (79, N'open', NULL, NULL, NULL, 25)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (80, N'close', NULL, NULL, NULL, 25)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (81, N'en', 1, 1, NULL, 26)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (82, N'ar', 0, 1, NULL, 26)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (83, N'1', 1, 1, N'print', 27)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (84, N'first', NULL, NULL, NULL, 28)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (85, N'second', NULL, NULL, NULL, 28)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (87, N'1', 1, 1, NULL, 29)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (88, N'', NULL, 1, N'title', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (89, N'', NULL, NULL, N'text1', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (90, N'', NULL, 1, N'text2', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (91, N'', NULL, 1, N'link1text', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (92, N'', NULL, 1, N'link2text', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (93, N'', NULL, 1, N'link3text', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (94, N'', NULL, 1, N'link1url', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (95, N'', NULL, 1, N'link2url', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (96, N'', NULL, 1, N'link3url', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (109, N'5', 1, 1, NULL, 31)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (110, N'5', 1, 1, N'print', 32)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (111, N'0', 1, 1, NULL, 33)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (112, N'False', 0, 1, N'tax', 34)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (113, N'0', 0, 1, N'tax', 35)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (114, N'False', 0, 1, N'tax', 36)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (115, N'0', 1, 1, N'tax', 37)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (144, N'https://localhost:443', NULL, NULL, NULL, 38)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (145, N'1', 1, 1, N'print', 39)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (146, N'', 1, 1, N'print', 40)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (147, N'', 1, 1, N'print', 41)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (148, N'0', 1, 1, N'print', 42)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (149, N'1', 1, 1, N'print', 43)
SET IDENTITY_INSERT [dbo].[setValues] OFF
GO
SET IDENTITY_INSERT [dbo].[shippingCompanies] ON 

INSERT [dbo].[shippingCompanies] ([shippingCompanyId], [name], [RealDeliveryCost], [deliveryCost], [deliveryType], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [balance], [balanceType], [email], [phone], [mobile], [fax], [address]) VALUES (1, N'Local     ', CAST(0.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), N'local', N'', CAST(N'2021-10-27T17:29:10.5505682' AS DateTime2), CAST(N'2021-12-07T12:10:50.8599647' AS DateTime2), 1, 1, 1, CAST(0.000 AS Decimal(20, 3)), 0, N'', N'', N'+965-999999999', N'', N'')
SET IDENTITY_INSERT [dbo].[shippingCompanies] OFF
GO
SET IDENTITY_INSERT [dbo].[storageCost] ON 

INSERT [dbo].[storageCost] ([storageCostId], [name], [cost], [note], [isActive], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (1, N'Small box', CAST(0.000 AS Decimal(20, 3)), N'', 1, 2, 2, CAST(N'2021-10-27T17:38:38.9658043' AS DateTime2), CAST(N'2022-01-01T11:17:30.4292394' AS DateTime2))
INSERT [dbo].[storageCost] ([storageCostId], [name], [cost], [note], [isActive], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (2, N'Medium box', CAST(0.000 AS Decimal(20, 3)), N'', 1, 2, 2, CAST(N'2021-10-27T17:38:48.6324643' AS DateTime2), CAST(N'2021-11-20T15:05:59.9557687' AS DateTime2))
INSERT [dbo].[storageCost] ([storageCostId], [name], [cost], [note], [isActive], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (3, N'Big box', CAST(0.000 AS Decimal(20, 3)), N'', 1, 2, 2, CAST(N'2021-10-27T17:39:30.6741180' AS DateTime2), CAST(N'2021-11-20T15:05:53.2792939' AS DateTime2))
SET IDENTITY_INSERT [dbo].[storageCost] OFF
GO
SET IDENTITY_INSERT [dbo].[units] ON 

INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (1, N'package', NULL, NULL, CAST(N'2021-07-15T11:59:52.5435356' AS DateTime2), 1, 1, CAST(N'2021-07-15T11:59:52.5435356' AS DateTime2), NULL, 1, N'package')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (2, N'Item', NULL, NULL, CAST(N'2021-10-27T17:30:03.4713222' AS DateTime2), 2, 2, CAST(N'2021-11-20T15:20:04.2985557' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (3, N'Box', NULL, NULL, CAST(N'2021-10-27T17:30:15.3960182' AS DateTime2), 2, 2, CAST(N'2021-11-20T15:20:27.3981350' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (5, N'g', NULL, NULL, CAST(N'2021-10-27T17:30:36.6851711' AS DateTime2), 2, 2, CAST(N'2021-11-20T15:22:43.5061107' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (6, N'Kg', NULL, NULL, CAST(N'2021-10-27T17:30:41.0430394' AS DateTime2), 2, 2, CAST(N'2021-11-20T15:21:02.1666577' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (7, N'M', NULL, NULL, CAST(N'2021-10-27T17:30:44.6121672' AS DateTime2), 2, 2, CAST(N'2021-11-20T15:21:16.3964743' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (8, N'mm', NULL, NULL, CAST(N'2021-10-27T17:30:48.0629747' AS DateTime2), 2, 2, CAST(N'2021-11-20T15:22:02.2061906' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (9, N'liter', NULL, NULL, CAST(N'2021-10-27T17:30:51.2115388' AS DateTime2), 2, 2, CAST(N'2021-11-20T15:22:33.3190745' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (10, N'barrel', NULL, NULL, CAST(N'2021-10-27T17:30:54.8458383' AS DateTime2), 2, 2, CAST(N'2021-11-20T15:23:17.4146319' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (12, N'service', NULL, NULL, NULL, 1, 1, CAST(N'2021-07-15T11:59:52.5435356' AS DateTime2), NULL, 1, N'service')
SET IDENTITY_INSERT [dbo].[units] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (1, N'Support@Increase', N'6379ebbefcde75fb0e5da33f4168c236', N'Support', N'Increase', N'System Admin', N'12', CAST(N'2021-06-28T18:38:45.0434248' AS DateTime2), CAST(N'2022-03-02T17:10:24.9243504' AS DateTime2), 1, 1, N'+963-21-2278910', N'+963-99999999', N'', N'', 1, N'', 0, N'', NULL, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (2, N'admin', N'1b8baf4f819e5b304e1a176e1c590c84', N'admin', N'admin', N'Manager', N'8', CAST(N'2021-06-30T11:05:51.9137655' AS DateTime2), CAST(N'2022-03-02T17:03:07.7369392' AS DateTime2), 1, 1, N'', N'+963-99999999', N'', N'', 1, N'', 0, N'', NULL, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
ALTER TABLE [dbo].[agents] ADD  CONSTRAINT [DF_agents_isLimited_1]  DEFAULT ((0)) FOR [isLimited]
GO
ALTER TABLE [dbo].[countriesCodes] ADD  CONSTRAINT [DF_countriesCodes_isDefault]  DEFAULT ((0)) FOR [isDefault]
GO
ALTER TABLE [dbo].[countriesCodes] ADD  CONSTRAINT [DF_countriesCodes_currencyId]  DEFAULT ((0)) FOR [currencyId]
GO
ALTER TABLE [dbo].[inventoryItemLocation] ADD  CONSTRAINT [DF_inventoryItemLocation_isFalls]  DEFAULT ((0)) FOR [isFalls]
GO
ALTER TABLE [dbo].[invoices] ADD  CONSTRAINT [DF_invoices_manualDiscountValue]  DEFAULT ((0)) FOR [manualDiscountValue]
GO
ALTER TABLE [dbo].[invoices] ADD  CONSTRAINT [DF_invoices_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[invoices] ADD  CONSTRAINT [DF_invoices_cashReturn]  DEFAULT ((0)) FOR [cashReturn]
GO
ALTER TABLE [dbo].[invoices] ADD  CONSTRAINT [DF_invoices_printedcount]  DEFAULT ((0)) FOR [printedcount]
GO
ALTER TABLE [dbo].[invoices] ADD  CONSTRAINT [DF_invoices_isOrginal]  DEFAULT ((1)) FOR [isOrginal]
GO
ALTER TABLE [dbo].[invoices] ADD  CONSTRAINT [DF_invoices_shippingCost]  DEFAULT ((0)) FOR [shippingCost]
GO
ALTER TABLE [dbo].[invoices] ADD  CONSTRAINT [DF_invoices_realShippingCost]  DEFAULT ((0)) FOR [realShippingCost]
GO
ALTER TABLE [dbo].[notificationUser] ADD  CONSTRAINT [DF_notificationUser_isRead]  DEFAULT ((0)) FOR [isRead]
GO
ALTER TABLE [dbo].[packages] ADD  CONSTRAINT [DF_packages_quantity]  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[packages] ADD  CONSTRAINT [DF_packages_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[posSerials] ADD  CONSTRAINT [DF_posSerials_isActive]  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[ProgramDetails] ADD  CONSTRAINT [DF_ProgramDetails_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[ProgramDetails] ADD  CONSTRAINT [DF_ProgramDetails_isServerActivated]  DEFAULT ((0)) FOR [isServerActivated]
GO
ALTER TABLE [dbo].[shippingCompanies] ADD  CONSTRAINT [DF_shippingCompanies_balance]  DEFAULT ((0)) FOR [balance]
GO
ALTER TABLE [dbo].[storageCost] ADD  CONSTRAINT [DF_storageCost_cost]  DEFAULT ((0)) FOR [cost]
GO
ALTER TABLE [dbo].[agentMemberships]  WITH CHECK ADD  CONSTRAINT [FK_agentMemberships_agents] FOREIGN KEY([agentId])
REFERENCES [dbo].[agents] ([agentId])
GO
ALTER TABLE [dbo].[agentMemberships] CHECK CONSTRAINT [FK_agentMemberships_agents]
GO
ALTER TABLE [dbo].[agentMemberships]  WITH CHECK ADD  CONSTRAINT [FK_agentMemberships_cashTransfer] FOREIGN KEY([cashTransId])
REFERENCES [dbo].[cashTransfer] ([cashTransId])
GO
ALTER TABLE [dbo].[agentMemberships] CHECK CONSTRAINT [FK_agentMemberships_cashTransfer]
GO
ALTER TABLE [dbo].[agentMemberships]  WITH CHECK ADD  CONSTRAINT [FK_agentMemberships_memberships2] FOREIGN KEY([membershipId])
REFERENCES [dbo].[memberships] ([membershipId])
GO
ALTER TABLE [dbo].[agentMemberships] CHECK CONSTRAINT [FK_agentMemberships_memberships2]
GO
ALTER TABLE [dbo].[agentMemberships]  WITH CHECK ADD  CONSTRAINT [FK_agentMemberships_subscriptionFees] FOREIGN KEY([subscriptionFeesId])
REFERENCES [dbo].[subscriptionFees] ([subscriptionFeesId])
GO
ALTER TABLE [dbo].[agentMemberships] CHECK CONSTRAINT [FK_agentMemberships_subscriptionFees]
GO
ALTER TABLE [dbo].[agentMemberships]  WITH CHECK ADD  CONSTRAINT [FK_agentMemberships_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[agentMemberships] CHECK CONSTRAINT [FK_agentMemberships_users1]
GO
ALTER TABLE [dbo].[agentMemberships]  WITH CHECK ADD  CONSTRAINT [FK_agentMemberships_users2] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[agentMemberships] CHECK CONSTRAINT [FK_agentMemberships_users2]
GO
ALTER TABLE [dbo].[agents]  WITH CHECK ADD  CONSTRAINT [FK_agents_Points] FOREIGN KEY([pointId])
REFERENCES [dbo].[Points] ([pointId])
GO
ALTER TABLE [dbo].[agents] CHECK CONSTRAINT [FK_agents_Points]
GO
ALTER TABLE [dbo].[agents]  WITH CHECK ADD  CONSTRAINT [FK_agents_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[agents] CHECK CONSTRAINT [FK_agents_users]
GO
ALTER TABLE [dbo].[agents]  WITH CHECK ADD  CONSTRAINT [FK_agents_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[agents] CHECK CONSTRAINT [FK_agents_users1]
GO
ALTER TABLE [dbo].[bondes]  WITH CHECK ADD  CONSTRAINT [FK_bondes_cashTransfer] FOREIGN KEY([cashTransId])
REFERENCES [dbo].[cashTransfer] ([cashTransId])
GO
ALTER TABLE [dbo].[bondes] CHECK CONSTRAINT [FK_bondes_cashTransfer]
GO
ALTER TABLE [dbo].[bondes]  WITH CHECK ADD  CONSTRAINT [FK_bondes_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[bondes] CHECK CONSTRAINT [FK_bondes_users]
GO
ALTER TABLE [dbo].[bondes]  WITH CHECK ADD  CONSTRAINT [FK_bondes_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[bondes] CHECK CONSTRAINT [FK_bondes_users1]
GO
ALTER TABLE [dbo].[branches]  WITH CHECK ADD  CONSTRAINT [FK_branches_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[branches] CHECK CONSTRAINT [FK_branches_users]
GO
ALTER TABLE [dbo].[branches]  WITH CHECK ADD  CONSTRAINT [FK_branches_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[branches] CHECK CONSTRAINT [FK_branches_users1]
GO
ALTER TABLE [dbo].[branchesUsers]  WITH CHECK ADD  CONSTRAINT [FK_branchesUsers_branches] FOREIGN KEY([branchId])
REFERENCES [dbo].[branches] ([branchId])
GO
ALTER TABLE [dbo].[branchesUsers] CHECK CONSTRAINT [FK_branchesUsers_branches]
GO
ALTER TABLE [dbo].[branchesUsers]  WITH CHECK ADD  CONSTRAINT [FK_branchesUsers_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[branchesUsers] CHECK CONSTRAINT [FK_branchesUsers_users]
GO
ALTER TABLE [dbo].[branchStore]  WITH CHECK ADD  CONSTRAINT [FK_branchStore_branches] FOREIGN KEY([branchId])
REFERENCES [dbo].[branches] ([branchId])
GO
ALTER TABLE [dbo].[branchStore] CHECK CONSTRAINT [FK_branchStore_branches]
GO
ALTER TABLE [dbo].[branchStore]  WITH CHECK ADD  CONSTRAINT [FK_branchStore_branches2] FOREIGN KEY([branchId])
REFERENCES [dbo].[branches] ([branchId])
GO
ALTER TABLE [dbo].[branchStore] CHECK CONSTRAINT [FK_branchStore_branches2]
GO
ALTER TABLE [dbo].[branchStore]  WITH CHECK ADD  CONSTRAINT [FK_branchStore_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[branchStore] CHECK CONSTRAINT [FK_branchStore_users]
GO
ALTER TABLE [dbo].[branchStore]  WITH CHECK ADD  CONSTRAINT [FK_branchStore_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[branchStore] CHECK CONSTRAINT [FK_branchStore_users1]
GO
ALTER TABLE [dbo].[cards]  WITH CHECK ADD  CONSTRAINT [FK_cards_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[cards] CHECK CONSTRAINT [FK_cards_users]
GO
ALTER TABLE [dbo].[cards]  WITH CHECK ADD  CONSTRAINT [FK_cards_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[cards] CHECK CONSTRAINT [FK_cards_users1]
GO
ALTER TABLE [dbo].[cashTransfer]  WITH CHECK ADD  CONSTRAINT [FK_cashTransfer_agentMemberships] FOREIGN KEY([agentMembershipsId])
REFERENCES [dbo].[agentMemberships] ([agentMembershipsId])
GO
ALTER TABLE [dbo].[cashTransfer] CHECK CONSTRAINT [FK_cashTransfer_agentMemberships]
GO
ALTER TABLE [dbo].[cashTransfer]  WITH CHECK ADD  CONSTRAINT [FK_cashTransfer_agents] FOREIGN KEY([agentId])
REFERENCES [dbo].[agents] ([agentId])
GO
ALTER TABLE [dbo].[cashTransfer] CHECK CONSTRAINT [FK_cashTransfer_agents]
GO
ALTER TABLE [dbo].[cashTransfer]  WITH CHECK ADD  CONSTRAINT [FK_cashTransfer_banks] FOREIGN KEY([bankId])
REFERENCES [dbo].[banks] ([bankId])
GO
ALTER TABLE [dbo].[cashTransfer] CHECK CONSTRAINT [FK_cashTransfer_banks]
GO
ALTER TABLE [dbo].[cashTransfer]  WITH CHECK ADD  CONSTRAINT [FK_cashTransfer_bondes] FOREIGN KEY([bondId])
REFERENCES [dbo].[bondes] ([bondId])
GO
ALTER TABLE [dbo].[cashTransfer] CHECK CONSTRAINT [FK_cashTransfer_bondes]
GO
ALTER TABLE [dbo].[cashTransfer]  WITH CHECK ADD  CONSTRAINT [FK_cashTransfer_cards] FOREIGN KEY([cardId])
REFERENCES [dbo].[cards] ([cardId])
GO
ALTER TABLE [dbo].[cashTransfer] CHECK CONSTRAINT [FK_cashTransfer_cards]
GO
ALTER TABLE [dbo].[cashTransfer]  WITH CHECK ADD  CONSTRAINT [FK_cashTransfer_cashTransfer] FOREIGN KEY([cashTransIdSource])
REFERENCES [dbo].[cashTransfer] ([cashTransId])
GO
ALTER TABLE [dbo].[cashTransfer] CHECK CONSTRAINT [FK_cashTransfer_cashTransfer]
GO
ALTER TABLE [dbo].[cashTransfer]  WITH CHECK ADD  CONSTRAINT [FK_cashTransfer_invoices] FOREIGN KEY([invId])
REFERENCES [dbo].[invoices] ([invoiceId])
GO
ALTER TABLE [dbo].[cashTransfer] CHECK CONSTRAINT [FK_cashTransfer_invoices]
GO
ALTER TABLE [dbo].[cashTransfer]  WITH CHECK ADD  CONSTRAINT [FK_cashTransfer_pos] FOREIGN KEY([posId])
REFERENCES [dbo].[pos] ([posId])
GO
ALTER TABLE [dbo].[cashTransfer] CHECK CONSTRAINT [FK_cashTransfer_pos]
GO
ALTER TABLE [dbo].[cashTransfer]  WITH CHECK ADD  CONSTRAINT [FK_cashTransfer_pos1] FOREIGN KEY([posIdCreator])
REFERENCES [dbo].[pos] ([posId])
GO
ALTER TABLE [dbo].[cashTransfer] CHECK CONSTRAINT [FK_cashTransfer_pos1]
GO
ALTER TABLE [dbo].[cashTransfer]  WITH CHECK ADD  CONSTRAINT [FK_cashTransfer_shippingCompanies] FOREIGN KEY([shippingCompanyId])
REFERENCES [dbo].[shippingCompanies] ([shippingCompanyId])
GO
ALTER TABLE [dbo].[cashTransfer] CHECK CONSTRAINT [FK_cashTransfer_shippingCompanies]
GO
ALTER TABLE [dbo].[cashTransfer]  WITH CHECK ADD  CONSTRAINT [FK_cashTransfer_users] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[cashTransfer] CHECK CONSTRAINT [FK_cashTransfer_users]
GO
ALTER TABLE [dbo].[cashTransfer]  WITH CHECK ADD  CONSTRAINT [FK_cashTransfer_users1] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[cashTransfer] CHECK CONSTRAINT [FK_cashTransfer_users1]
GO
ALTER TABLE [dbo].[cashTransfer]  WITH CHECK ADD  CONSTRAINT [FK_cashTransfer_users2] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[cashTransfer] CHECK CONSTRAINT [FK_cashTransfer_users2]
GO
ALTER TABLE [dbo].[categories]  WITH CHECK ADD  CONSTRAINT [FK_categories_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[categories] CHECK CONSTRAINT [FK_categories_users]
GO
ALTER TABLE [dbo].[categories]  WITH CHECK ADD  CONSTRAINT [FK_categories_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[categories] CHECK CONSTRAINT [FK_categories_users1]
GO
ALTER TABLE [dbo].[categoryuser]  WITH CHECK ADD  CONSTRAINT [FK_categoryuser_categories] FOREIGN KEY([categoryId])
REFERENCES [dbo].[categories] ([categoryId])
GO
ALTER TABLE [dbo].[categoryuser] CHECK CONSTRAINT [FK_categoryuser_categories]
GO
ALTER TABLE [dbo].[categoryuser]  WITH CHECK ADD  CONSTRAINT [FK_categoryuser_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[categoryuser] CHECK CONSTRAINT [FK_categoryuser_users]
GO
ALTER TABLE [dbo].[categoryuser]  WITH CHECK ADD  CONSTRAINT [FK_categoryuser_users1] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[categoryuser] CHECK CONSTRAINT [FK_categoryuser_users1]
GO
ALTER TABLE [dbo].[categoryuser]  WITH CHECK ADD  CONSTRAINT [FK_categoryuser_users2] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[categoryuser] CHECK CONSTRAINT [FK_categoryuser_users2]
GO
ALTER TABLE [dbo].[cities]  WITH CHECK ADD  CONSTRAINT [FK_cities_countriesCodes] FOREIGN KEY([countryId])
REFERENCES [dbo].[countriesCodes] ([countryId])
GO
ALTER TABLE [dbo].[cities] CHECK CONSTRAINT [FK_cities_countriesCodes]
GO
ALTER TABLE [dbo].[coupons]  WITH CHECK ADD  CONSTRAINT [FK_coupons_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[coupons] CHECK CONSTRAINT [FK_coupons_users]
GO
ALTER TABLE [dbo].[coupons]  WITH NOCHECK ADD  CONSTRAINT [FK_coupons_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[coupons] NOCHECK CONSTRAINT [FK_coupons_users1]
GO
ALTER TABLE [dbo].[couponsInvoices]  WITH CHECK ADD  CONSTRAINT [FK_couponsInvoices_coupons] FOREIGN KEY([couponId])
REFERENCES [dbo].[coupons] ([cId])
GO
ALTER TABLE [dbo].[couponsInvoices] CHECK CONSTRAINT [FK_couponsInvoices_coupons]
GO
ALTER TABLE [dbo].[couponsInvoices]  WITH CHECK ADD  CONSTRAINT [FK_couponsInvoices_invoices] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[invoices] ([invoiceId])
GO
ALTER TABLE [dbo].[couponsInvoices] CHECK CONSTRAINT [FK_couponsInvoices_invoices]
GO
ALTER TABLE [dbo].[couponsInvoices]  WITH CHECK ADD  CONSTRAINT [FK_couponsInvoices_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[couponsInvoices] CHECK CONSTRAINT [FK_couponsInvoices_users]
GO
ALTER TABLE [dbo].[couponsInvoices]  WITH CHECK ADD  CONSTRAINT [FK_couponsInvoices_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[couponsInvoices] CHECK CONSTRAINT [FK_couponsInvoices_users1]
GO
ALTER TABLE [dbo].[docImages]  WITH CHECK ADD  CONSTRAINT [FK_docImages_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[docImages] CHECK CONSTRAINT [FK_docImages_users]
GO
ALTER TABLE [dbo].[docImages]  WITH CHECK ADD  CONSTRAINT [FK_docImages_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[docImages] CHECK CONSTRAINT [FK_docImages_users1]
GO
ALTER TABLE [dbo].[error]  WITH CHECK ADD  CONSTRAINT [FK_error_branches] FOREIGN KEY([branchId])
REFERENCES [dbo].[branches] ([branchId])
GO
ALTER TABLE [dbo].[error] CHECK CONSTRAINT [FK_error_branches]
GO
ALTER TABLE [dbo].[error]  WITH CHECK ADD  CONSTRAINT [FK_error_pos] FOREIGN KEY([posId])
REFERENCES [dbo].[pos] ([posId])
GO
ALTER TABLE [dbo].[error] CHECK CONSTRAINT [FK_error_pos]
GO
ALTER TABLE [dbo].[error]  WITH CHECK ADD  CONSTRAINT [FK_error_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[error] CHECK CONSTRAINT [FK_error_users]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_users]
GO
ALTER TABLE [dbo].[groupObject]  WITH CHECK ADD  CONSTRAINT [FK_groupObject_groups] FOREIGN KEY([groupId])
REFERENCES [dbo].[groups] ([groupId])
GO
ALTER TABLE [dbo].[groupObject] CHECK CONSTRAINT [FK_groupObject_groups]
GO
ALTER TABLE [dbo].[groupObject]  WITH CHECK ADD  CONSTRAINT [FK_groupObject_objects] FOREIGN KEY([objectId])
REFERENCES [dbo].[objects] ([objectId])
GO
ALTER TABLE [dbo].[groupObject] CHECK CONSTRAINT [FK_groupObject_objects]
GO
ALTER TABLE [dbo].[groupObject]  WITH CHECK ADD  CONSTRAINT [FK_groupObject_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[groupObject] CHECK CONSTRAINT [FK_groupObject_users]
GO
ALTER TABLE [dbo].[groupObject]  WITH CHECK ADD  CONSTRAINT [FK_groupObject_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[groupObject] CHECK CONSTRAINT [FK_groupObject_users1]
GO
ALTER TABLE [dbo].[groups]  WITH CHECK ADD  CONSTRAINT [FK_groups_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[groups] CHECK CONSTRAINT [FK_groups_users1]
GO
ALTER TABLE [dbo].[groups]  WITH CHECK ADD  CONSTRAINT [FK_groups_users2] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[groups] CHECK CONSTRAINT [FK_groups_users2]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_branches] FOREIGN KEY([branchId])
REFERENCES [dbo].[branches] ([branchId])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_branches]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_pos] FOREIGN KEY([posId])
REFERENCES [dbo].[pos] ([posId])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_pos]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_users]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_users1]
GO
ALTER TABLE [dbo].[inventoryItemLocation]  WITH CHECK ADD  CONSTRAINT [FK_inventoryItemLocation_Inventory] FOREIGN KEY([inventoryId])
REFERENCES [dbo].[Inventory] ([inventoryId])
GO
ALTER TABLE [dbo].[inventoryItemLocation] CHECK CONSTRAINT [FK_inventoryItemLocation_Inventory]
GO
ALTER TABLE [dbo].[inventoryItemLocation]  WITH CHECK ADD  CONSTRAINT [FK_inventoryItemLocation_itemsLocations] FOREIGN KEY([itemLocationId])
REFERENCES [dbo].[itemsLocations] ([itemsLocId])
GO
ALTER TABLE [dbo].[inventoryItemLocation] CHECK CONSTRAINT [FK_inventoryItemLocation_itemsLocations]
GO
ALTER TABLE [dbo].[inventoryItemLocation]  WITH CHECK ADD  CONSTRAINT [FK_inventoryItemLocation_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[inventoryItemLocation] CHECK CONSTRAINT [FK_inventoryItemLocation_users]
GO
ALTER TABLE [dbo].[inventoryItemLocation]  WITH CHECK ADD  CONSTRAINT [FK_inventoryItemLocation_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[inventoryItemLocation] CHECK CONSTRAINT [FK_inventoryItemLocation_users1]
GO
ALTER TABLE [dbo].[invoiceOrder]  WITH CHECK ADD  CONSTRAINT [FK_invoiceOrder_invoices] FOREIGN KEY([invoiceId])
REFERENCES [dbo].[invoices] ([invoiceId])
GO
ALTER TABLE [dbo].[invoiceOrder] CHECK CONSTRAINT [FK_invoiceOrder_invoices]
GO
ALTER TABLE [dbo].[invoiceOrder]  WITH CHECK ADD  CONSTRAINT [FK_invoiceOrder_invoices1] FOREIGN KEY([orderId])
REFERENCES [dbo].[invoices] ([invoiceId])
GO
ALTER TABLE [dbo].[invoiceOrder] CHECK CONSTRAINT [FK_invoiceOrder_invoices1]
GO
ALTER TABLE [dbo].[invoiceOrder]  WITH CHECK ADD  CONSTRAINT [FK_invoiceOrder_itemsTransfer] FOREIGN KEY([itemsTransferId])
REFERENCES [dbo].[itemsTransfer] ([itemsTransId])
GO
ALTER TABLE [dbo].[invoiceOrder] CHECK CONSTRAINT [FK_invoiceOrder_itemsTransfer]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_agents] FOREIGN KEY([agentId])
REFERENCES [dbo].[agents] ([agentId])
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_agents]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_branches] FOREIGN KEY([branchId])
REFERENCES [dbo].[branches] ([branchId])
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_branches]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_branches1] FOREIGN KEY([branchCreatorId])
REFERENCES [dbo].[branches] ([branchId])
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_branches1]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_invoices] FOREIGN KEY([invoiceMainId])
REFERENCES [dbo].[invoices] ([invoiceId])
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_invoices]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_pos] FOREIGN KEY([posId])
REFERENCES [dbo].[pos] ([posId])
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_pos]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_shippingCompanies] FOREIGN KEY([shippingCompanyId])
REFERENCES [dbo].[shippingCompanies] ([shippingCompanyId])
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_shippingCompanies]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_users] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_users]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_users1] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_users1]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_users2] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_users2]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_users3] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_users3]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_users4] FOREIGN KEY([shipUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_users4]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_users5] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_users5]
GO
ALTER TABLE [dbo].[invoiceStatus]  WITH CHECK ADD  CONSTRAINT [FK_invoiceStatus_invoices] FOREIGN KEY([invoiceId])
REFERENCES [dbo].[invoices] ([invoiceId])
GO
ALTER TABLE [dbo].[invoiceStatus] CHECK CONSTRAINT [FK_invoiceStatus_invoices]
GO
ALTER TABLE [dbo].[invoiceStatus]  WITH CHECK ADD  CONSTRAINT [FK_invoiceStatus_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[invoiceStatus] CHECK CONSTRAINT [FK_invoiceStatus_users]
GO
ALTER TABLE [dbo].[invoiceStatus]  WITH CHECK ADD  CONSTRAINT [FK_invoiceStatus_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[invoiceStatus] CHECK CONSTRAINT [FK_invoiceStatus_users1]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_categories] FOREIGN KEY([categoryId])
REFERENCES [dbo].[categories] ([categoryId])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_categories]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_units] FOREIGN KEY([minUnitId])
REFERENCES [dbo].[units] ([unitId])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_units]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_units1] FOREIGN KEY([maxUnitId])
REFERENCES [dbo].[units] ([unitId])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_units1]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_users]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_users1]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_users2] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_users2]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_users3] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_users3]
GO
ALTER TABLE [dbo].[itemsLocations]  WITH CHECK ADD  CONSTRAINT [FK_itemsLocations_invoices] FOREIGN KEY([invoiceId])
REFERENCES [dbo].[invoices] ([invoiceId])
GO
ALTER TABLE [dbo].[itemsLocations] CHECK CONSTRAINT [FK_itemsLocations_invoices]
GO
ALTER TABLE [dbo].[itemsLocations]  WITH CHECK ADD  CONSTRAINT [FK_itemsLocations_itemsUnits] FOREIGN KEY([itemUnitId])
REFERENCES [dbo].[itemsUnits] ([itemUnitId])
GO
ALTER TABLE [dbo].[itemsLocations] CHECK CONSTRAINT [FK_itemsLocations_itemsUnits]
GO
ALTER TABLE [dbo].[itemsLocations]  WITH CHECK ADD  CONSTRAINT [FK_itemsLocations_locations] FOREIGN KEY([locationId])
REFERENCES [dbo].[locations] ([locationId])
GO
ALTER TABLE [dbo].[itemsLocations] CHECK CONSTRAINT [FK_itemsLocations_locations]
GO
ALTER TABLE [dbo].[itemsLocations]  WITH CHECK ADD  CONSTRAINT [FK_itemsLocations_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemsLocations] CHECK CONSTRAINT [FK_itemsLocations_users]
GO
ALTER TABLE [dbo].[itemsLocations]  WITH CHECK ADD  CONSTRAINT [FK_itemsLocations_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemsLocations] CHECK CONSTRAINT [FK_itemsLocations_users1]
GO
ALTER TABLE [dbo].[itemsLocations]  WITH CHECK ADD  CONSTRAINT [FK_itemsLocations_users2] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemsLocations] CHECK CONSTRAINT [FK_itemsLocations_users2]
GO
ALTER TABLE [dbo].[itemsLocations]  WITH CHECK ADD  CONSTRAINT [FK_itemsLocations_users3] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemsLocations] CHECK CONSTRAINT [FK_itemsLocations_users3]
GO
ALTER TABLE [dbo].[itemsMaterials]  WITH CHECK ADD  CONSTRAINT [FK_itemsMaterials_items] FOREIGN KEY([itemId])
REFERENCES [dbo].[items] ([itemId])
GO
ALTER TABLE [dbo].[itemsMaterials] CHECK CONSTRAINT [FK_itemsMaterials_items]
GO
ALTER TABLE [dbo].[itemsMaterials]  WITH CHECK ADD  CONSTRAINT [FK_itemsMaterials_items1] FOREIGN KEY([materialId])
REFERENCES [dbo].[items] ([itemId])
GO
ALTER TABLE [dbo].[itemsMaterials] CHECK CONSTRAINT [FK_itemsMaterials_items1]
GO
ALTER TABLE [dbo].[itemsMaterials]  WITH CHECK ADD  CONSTRAINT [FK_itemsMaterials_units] FOREIGN KEY([unitId])
REFERENCES [dbo].[units] ([unitId])
GO
ALTER TABLE [dbo].[itemsMaterials] CHECK CONSTRAINT [FK_itemsMaterials_units]
GO
ALTER TABLE [dbo].[itemsOffers]  WITH CHECK ADD  CONSTRAINT [FK_itemsOffers_itemsUnits] FOREIGN KEY([iuId])
REFERENCES [dbo].[itemsUnits] ([itemUnitId])
GO
ALTER TABLE [dbo].[itemsOffers] CHECK CONSTRAINT [FK_itemsOffers_itemsUnits]
GO
ALTER TABLE [dbo].[itemsOffers]  WITH CHECK ADD  CONSTRAINT [FK_itemsOffers_offers] FOREIGN KEY([offerId])
REFERENCES [dbo].[offers] ([offerId])
GO
ALTER TABLE [dbo].[itemsOffers] CHECK CONSTRAINT [FK_itemsOffers_offers]
GO
ALTER TABLE [dbo].[itemsOffers]  WITH CHECK ADD  CONSTRAINT [FK_itemsOffers_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemsOffers] CHECK CONSTRAINT [FK_itemsOffers_users]
GO
ALTER TABLE [dbo].[itemsOffers]  WITH CHECK ADD  CONSTRAINT [FK_itemsOffers_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemsOffers] CHECK CONSTRAINT [FK_itemsOffers_users1]
GO
ALTER TABLE [dbo].[itemsProp]  WITH CHECK ADD  CONSTRAINT [FK_itemsProp_items] FOREIGN KEY([itemId])
REFERENCES [dbo].[items] ([itemId])
GO
ALTER TABLE [dbo].[itemsProp] CHECK CONSTRAINT [FK_itemsProp_items]
GO
ALTER TABLE [dbo].[itemsProp]  WITH CHECK ADD  CONSTRAINT [FK_itemsProp_propertiesItems] FOREIGN KEY([propertyItemId])
REFERENCES [dbo].[propertiesItems] ([propertyItemId])
GO
ALTER TABLE [dbo].[itemsProp] CHECK CONSTRAINT [FK_itemsProp_propertiesItems]
GO
ALTER TABLE [dbo].[itemsProp]  WITH CHECK ADD  CONSTRAINT [FK_itemsProp_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemsProp] CHECK CONSTRAINT [FK_itemsProp_users]
GO
ALTER TABLE [dbo].[itemsProp]  WITH CHECK ADD  CONSTRAINT [FK_itemsProp_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemsProp] CHECK CONSTRAINT [FK_itemsProp_users1]
GO
ALTER TABLE [dbo].[itemsTransfer]  WITH CHECK ADD  CONSTRAINT [FK_itemsTransfer_inventoryItemLocation] FOREIGN KEY([inventoryItemLocId])
REFERENCES [dbo].[inventoryItemLocation] ([id])
GO
ALTER TABLE [dbo].[itemsTransfer] CHECK CONSTRAINT [FK_itemsTransfer_inventoryItemLocation]
GO
ALTER TABLE [dbo].[itemsTransfer]  WITH CHECK ADD  CONSTRAINT [FK_itemsTransfer_invoices] FOREIGN KEY([invoiceId])
REFERENCES [dbo].[invoices] ([invoiceId])
GO
ALTER TABLE [dbo].[itemsTransfer] CHECK CONSTRAINT [FK_itemsTransfer_invoices]
GO
ALTER TABLE [dbo].[itemsTransfer]  WITH CHECK ADD  CONSTRAINT [FK_itemsTransfer_itemsUnits] FOREIGN KEY([itemUnitId])
REFERENCES [dbo].[itemsUnits] ([itemUnitId])
GO
ALTER TABLE [dbo].[itemsTransfer] CHECK CONSTRAINT [FK_itemsTransfer_itemsUnits]
GO
ALTER TABLE [dbo].[itemsTransfer]  WITH CHECK ADD  CONSTRAINT [FK_itemsTransfer_locations] FOREIGN KEY([locationIdNew])
REFERENCES [dbo].[locations] ([locationId])
GO
ALTER TABLE [dbo].[itemsTransfer] CHECK CONSTRAINT [FK_itemsTransfer_locations]
GO
ALTER TABLE [dbo].[itemsTransfer]  WITH CHECK ADD  CONSTRAINT [FK_itemsTransfer_locations1] FOREIGN KEY([locationIdOld])
REFERENCES [dbo].[locations] ([locationId])
GO
ALTER TABLE [dbo].[itemsTransfer] CHECK CONSTRAINT [FK_itemsTransfer_locations1]
GO
ALTER TABLE [dbo].[itemsTransfer]  WITH CHECK ADD  CONSTRAINT [FK_itemsTransfer_offers] FOREIGN KEY([offerId])
REFERENCES [dbo].[offers] ([offerId])
GO
ALTER TABLE [dbo].[itemsTransfer] CHECK CONSTRAINT [FK_itemsTransfer_offers]
GO
ALTER TABLE [dbo].[itemsUnits]  WITH CHECK ADD  CONSTRAINT [FK_itemsUnits_items] FOREIGN KEY([itemId])
REFERENCES [dbo].[items] ([itemId])
GO
ALTER TABLE [dbo].[itemsUnits] CHECK CONSTRAINT [FK_itemsUnits_items]
GO
ALTER TABLE [dbo].[itemsUnits]  WITH CHECK ADD  CONSTRAINT [FK_itemsUnits_storageCost] FOREIGN KEY([storageCostId])
REFERENCES [dbo].[storageCost] ([storageCostId])
GO
ALTER TABLE [dbo].[itemsUnits] CHECK CONSTRAINT [FK_itemsUnits_storageCost]
GO
ALTER TABLE [dbo].[itemsUnits]  WITH CHECK ADD  CONSTRAINT [FK_itemsUnits_units] FOREIGN KEY([unitId])
REFERENCES [dbo].[units] ([unitId])
GO
ALTER TABLE [dbo].[itemsUnits] CHECK CONSTRAINT [FK_itemsUnits_units]
GO
ALTER TABLE [dbo].[itemsUnits]  WITH CHECK ADD  CONSTRAINT [FK_itemsUnits_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemsUnits] CHECK CONSTRAINT [FK_itemsUnits_users]
GO
ALTER TABLE [dbo].[itemsUnits]  WITH CHECK ADD  CONSTRAINT [FK_itemsUnits_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemsUnits] CHECK CONSTRAINT [FK_itemsUnits_users1]
GO
ALTER TABLE [dbo].[itemTransferOffer]  WITH CHECK ADD  CONSTRAINT [FK_itemTransferOffer_itemsTransfer] FOREIGN KEY([itemTransId])
REFERENCES [dbo].[itemsTransfer] ([itemsTransId])
GO
ALTER TABLE [dbo].[itemTransferOffer] CHECK CONSTRAINT [FK_itemTransferOffer_itemsTransfer]
GO
ALTER TABLE [dbo].[itemTransferOffer]  WITH CHECK ADD  CONSTRAINT [FK_itemTransferOffer_offers] FOREIGN KEY([offerId])
REFERENCES [dbo].[offers] ([offerId])
GO
ALTER TABLE [dbo].[itemTransferOffer] CHECK CONSTRAINT [FK_itemTransferOffer_offers]
GO
ALTER TABLE [dbo].[itemTransferOffer]  WITH CHECK ADD  CONSTRAINT [FK_itemTransferOffer_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemTransferOffer] CHECK CONSTRAINT [FK_itemTransferOffer_users]
GO
ALTER TABLE [dbo].[itemTransferOffer]  WITH CHECK ADD  CONSTRAINT [FK_itemTransferOffer_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemTransferOffer] CHECK CONSTRAINT [FK_itemTransferOffer_users1]
GO
ALTER TABLE [dbo].[itemUnitUser]  WITH CHECK ADD  CONSTRAINT [FK_itemUnitUser_itemsUnits] FOREIGN KEY([itemUnitId])
REFERENCES [dbo].[itemsUnits] ([itemUnitId])
GO
ALTER TABLE [dbo].[itemUnitUser] CHECK CONSTRAINT [FK_itemUnitUser_itemsUnits]
GO
ALTER TABLE [dbo].[itemUnitUser]  WITH CHECK ADD  CONSTRAINT [FK_itemUnitUser_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemUnitUser] CHECK CONSTRAINT [FK_itemUnitUser_users]
GO
ALTER TABLE [dbo].[itemUnitUser]  WITH CHECK ADD  CONSTRAINT [FK_itemUnitUser_users1] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemUnitUser] CHECK CONSTRAINT [FK_itemUnitUser_users1]
GO
ALTER TABLE [dbo].[itemUnitUser]  WITH CHECK ADD  CONSTRAINT [FK_itemUnitUser_users2] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[itemUnitUser] CHECK CONSTRAINT [FK_itemUnitUser_users2]
GO
ALTER TABLE [dbo].[locations]  WITH CHECK ADD  CONSTRAINT [FK_locations_branches1] FOREIGN KEY([branchId])
REFERENCES [dbo].[branches] ([branchId])
GO
ALTER TABLE [dbo].[locations] CHECK CONSTRAINT [FK_locations_branches1]
GO
ALTER TABLE [dbo].[locations]  WITH CHECK ADD  CONSTRAINT [FK_locations_sections] FOREIGN KEY([sectionId])
REFERENCES [dbo].[sections] ([sectionId])
GO
ALTER TABLE [dbo].[locations] CHECK CONSTRAINT [FK_locations_sections]
GO
ALTER TABLE [dbo].[locations]  WITH CHECK ADD  CONSTRAINT [FK_locations_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[locations] CHECK CONSTRAINT [FK_locations_users]
GO
ALTER TABLE [dbo].[locations]  WITH CHECK ADD  CONSTRAINT [FK_locations_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[locations] CHECK CONSTRAINT [FK_locations_users1]
GO
ALTER TABLE [dbo].[medalAgent]  WITH CHECK ADD  CONSTRAINT [FK_medalAgent_agents] FOREIGN KEY([agentId])
REFERENCES [dbo].[agents] ([agentId])
GO
ALTER TABLE [dbo].[medalAgent] CHECK CONSTRAINT [FK_medalAgent_agents]
GO
ALTER TABLE [dbo].[medalAgent]  WITH CHECK ADD  CONSTRAINT [FK_medalAgent_medals] FOREIGN KEY([medalId])
REFERENCES [dbo].[medals] ([medalId])
GO
ALTER TABLE [dbo].[medalAgent] CHECK CONSTRAINT [FK_medalAgent_medals]
GO
ALTER TABLE [dbo].[medalAgent]  WITH CHECK ADD  CONSTRAINT [FK_medalAgent_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[medalAgent] CHECK CONSTRAINT [FK_medalAgent_users]
GO
ALTER TABLE [dbo].[medalAgent]  WITH CHECK ADD  CONSTRAINT [FK_medalAgent_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[medalAgent] CHECK CONSTRAINT [FK_medalAgent_users1]
GO
ALTER TABLE [dbo].[medals]  WITH CHECK ADD  CONSTRAINT [FK_medals_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[medals] CHECK CONSTRAINT [FK_medals_users]
GO
ALTER TABLE [dbo].[medals]  WITH CHECK ADD  CONSTRAINT [FK_medals_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[medals] CHECK CONSTRAINT [FK_medals_users1]
GO
ALTER TABLE [dbo].[memberships]  WITH CHECK ADD  CONSTRAINT [FK_memberships_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[memberships] CHECK CONSTRAINT [FK_memberships_users]
GO
ALTER TABLE [dbo].[memberships]  WITH CHECK ADD  CONSTRAINT [FK_memberships_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[memberships] CHECK CONSTRAINT [FK_memberships_users1]
GO
ALTER TABLE [dbo].[notification]  WITH CHECK ADD  CONSTRAINT [FK_notification_users] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[notification] CHECK CONSTRAINT [FK_notification_users]
GO
ALTER TABLE [dbo].[notification]  WITH CHECK ADD  CONSTRAINT [FK_notification_users1] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[notification] CHECK CONSTRAINT [FK_notification_users1]
GO
ALTER TABLE [dbo].[notificationUser]  WITH CHECK ADD  CONSTRAINT [FK_notificationUser_notification] FOREIGN KEY([notId])
REFERENCES [dbo].[notification] ([notId])
GO
ALTER TABLE [dbo].[notificationUser] CHECK CONSTRAINT [FK_notificationUser_notification]
GO
ALTER TABLE [dbo].[notificationUser]  WITH CHECK ADD  CONSTRAINT [FK_notificationUser_pos] FOREIGN KEY([posId])
REFERENCES [dbo].[pos] ([posId])
GO
ALTER TABLE [dbo].[notificationUser] CHECK CONSTRAINT [FK_notificationUser_pos]
GO
ALTER TABLE [dbo].[notificationUser]  WITH CHECK ADD  CONSTRAINT [FK_notificationUser_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[notificationUser] CHECK CONSTRAINT [FK_notificationUser_users]
GO
ALTER TABLE [dbo].[notificationUser]  WITH CHECK ADD  CONSTRAINT [FK_notificationUser_users1] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[notificationUser] CHECK CONSTRAINT [FK_notificationUser_users1]
GO
ALTER TABLE [dbo].[notificationUser]  WITH CHECK ADD  CONSTRAINT [FK_notificationUser_users2] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[notificationUser] CHECK CONSTRAINT [FK_notificationUser_users2]
GO
ALTER TABLE [dbo].[objects]  WITH CHECK ADD  CONSTRAINT [FK_objects_objects] FOREIGN KEY([parentObjectId])
REFERENCES [dbo].[objects] ([objectId])
GO
ALTER TABLE [dbo].[objects] CHECK CONSTRAINT [FK_objects_objects]
GO
ALTER TABLE [dbo].[objects]  WITH CHECK ADD  CONSTRAINT [FK_objects_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[objects] CHECK CONSTRAINT [FK_objects_users]
GO
ALTER TABLE [dbo].[objects]  WITH CHECK ADD  CONSTRAINT [FK_objects_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[objects] CHECK CONSTRAINT [FK_objects_users1]
GO
ALTER TABLE [dbo].[packages]  WITH CHECK ADD  CONSTRAINT [FK_packages_itemsUnits] FOREIGN KEY([parentIUId])
REFERENCES [dbo].[itemsUnits] ([itemUnitId])
GO
ALTER TABLE [dbo].[packages] CHECK CONSTRAINT [FK_packages_itemsUnits]
GO
ALTER TABLE [dbo].[packages]  WITH CHECK ADD  CONSTRAINT [FK_packages_itemsUnits1] FOREIGN KEY([childIUId])
REFERENCES [dbo].[itemsUnits] ([itemUnitId])
GO
ALTER TABLE [dbo].[packages] CHECK CONSTRAINT [FK_packages_itemsUnits1]
GO
ALTER TABLE [dbo].[packages]  WITH CHECK ADD  CONSTRAINT [FK_packages_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[packages] CHECK CONSTRAINT [FK_packages_users1]
GO
ALTER TABLE [dbo].[packages]  WITH CHECK ADD  CONSTRAINT [FK_packages_users2] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[packages] CHECK CONSTRAINT [FK_packages_users2]
GO
ALTER TABLE [dbo].[Points]  WITH CHECK ADD  CONSTRAINT [FK_Points_agents] FOREIGN KEY([agentId])
REFERENCES [dbo].[agents] ([agentId])
GO
ALTER TABLE [dbo].[Points] CHECK CONSTRAINT [FK_Points_agents]
GO
ALTER TABLE [dbo].[Points]  WITH CHECK ADD  CONSTRAINT [FK_Points_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[Points] CHECK CONSTRAINT [FK_Points_users]
GO
ALTER TABLE [dbo].[Points]  WITH CHECK ADD  CONSTRAINT [FK_Points_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[Points] CHECK CONSTRAINT [FK_Points_users1]
GO
ALTER TABLE [dbo].[pos]  WITH CHECK ADD  CONSTRAINT [FK_pos_branches] FOREIGN KEY([branchId])
REFERENCES [dbo].[branches] ([branchId])
GO
ALTER TABLE [dbo].[pos] CHECK CONSTRAINT [FK_pos_branches]
GO
ALTER TABLE [dbo].[pos]  WITH CHECK ADD  CONSTRAINT [FK_pos_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[pos] CHECK CONSTRAINT [FK_pos_users]
GO
ALTER TABLE [dbo].[pos]  WITH CHECK ADD  CONSTRAINT [FK_pos_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[pos] CHECK CONSTRAINT [FK_pos_users1]
GO
ALTER TABLE [dbo].[posSetting]  WITH CHECK ADD  CONSTRAINT [FK_posSetting_paperSize] FOREIGN KEY([saleInvPapersizeId])
REFERENCES [dbo].[paperSize] ([sizeId])
GO
ALTER TABLE [dbo].[posSetting] CHECK CONSTRAINT [FK_posSetting_paperSize]
GO
ALTER TABLE [dbo].[posSetting]  WITH CHECK ADD  CONSTRAINT [FK_posSetting_pos] FOREIGN KEY([posId])
REFERENCES [dbo].[pos] ([posId])
GO
ALTER TABLE [dbo].[posSetting] CHECK CONSTRAINT [FK_posSetting_pos]
GO
ALTER TABLE [dbo].[posSetting]  WITH CHECK ADD  CONSTRAINT [FK_posSetting_posSerials] FOREIGN KEY([posSerialId])
REFERENCES [dbo].[posSerials] ([id])
GO
ALTER TABLE [dbo].[posSetting] CHECK CONSTRAINT [FK_posSetting_posSerials]
GO
ALTER TABLE [dbo].[posSetting]  WITH CHECK ADD  CONSTRAINT [FK_posSetting_printers] FOREIGN KEY([saleInvPrinterId])
REFERENCES [dbo].[printers] ([printerId])
GO
ALTER TABLE [dbo].[posSetting] CHECK CONSTRAINT [FK_posSetting_printers]
GO
ALTER TABLE [dbo].[posSetting]  WITH CHECK ADD  CONSTRAINT [FK_posSetting_printers1] FOREIGN KEY([reportPrinterId])
REFERENCES [dbo].[printers] ([printerId])
GO
ALTER TABLE [dbo].[posSetting] CHECK CONSTRAINT [FK_posSetting_printers1]
GO
ALTER TABLE [dbo].[posSetting]  WITH CHECK ADD  CONSTRAINT [FK_posSetting_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[posSetting] CHECK CONSTRAINT [FK_posSetting_users]
GO
ALTER TABLE [dbo].[posSetting]  WITH CHECK ADD  CONSTRAINT [FK_posSetting_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[posSetting] CHECK CONSTRAINT [FK_posSetting_users1]
GO
ALTER TABLE [dbo].[posUsers]  WITH CHECK ADD  CONSTRAINT [FK_posUsers_pos] FOREIGN KEY([posId])
REFERENCES [dbo].[pos] ([posId])
GO
ALTER TABLE [dbo].[posUsers] CHECK CONSTRAINT [FK_posUsers_pos]
GO
ALTER TABLE [dbo].[posUsers]  WITH CHECK ADD  CONSTRAINT [FK_posUsers_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[posUsers] CHECK CONSTRAINT [FK_posUsers_users]
GO
ALTER TABLE [dbo].[posUsers]  WITH CHECK ADD  CONSTRAINT [FK_posUsers_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[posUsers] CHECK CONSTRAINT [FK_posUsers_users1]
GO
ALTER TABLE [dbo].[posUsers]  WITH CHECK ADD  CONSTRAINT [FK_posUsers_users2] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[posUsers] CHECK CONSTRAINT [FK_posUsers_users2]
GO
ALTER TABLE [dbo].[printers]  WITH CHECK ADD  CONSTRAINT [FK_printers_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[printers] CHECK CONSTRAINT [FK_printers_users]
GO
ALTER TABLE [dbo].[printers]  WITH CHECK ADD  CONSTRAINT [FK_printers_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[printers] CHECK CONSTRAINT [FK_printers_users1]
GO
ALTER TABLE [dbo].[properties]  WITH CHECK ADD  CONSTRAINT [FK_properties_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[properties] CHECK CONSTRAINT [FK_properties_users]
GO
ALTER TABLE [dbo].[properties]  WITH CHECK ADD  CONSTRAINT [FK_properties_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[properties] CHECK CONSTRAINT [FK_properties_users1]
GO
ALTER TABLE [dbo].[propertiesItems]  WITH CHECK ADD  CONSTRAINT [FK_propertiesItems_properties] FOREIGN KEY([propertyId])
REFERENCES [dbo].[properties] ([propertyId])
GO
ALTER TABLE [dbo].[propertiesItems] CHECK CONSTRAINT [FK_propertiesItems_properties]
GO
ALTER TABLE [dbo].[propertiesItems]  WITH CHECK ADD  CONSTRAINT [FK_propertiesItems_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[propertiesItems] CHECK CONSTRAINT [FK_propertiesItems_users]
GO
ALTER TABLE [dbo].[propertiesItems]  WITH CHECK ADD  CONSTRAINT [FK_propertiesItems_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[propertiesItems] CHECK CONSTRAINT [FK_propertiesItems_users1]
GO
ALTER TABLE [dbo].[sections]  WITH CHECK ADD  CONSTRAINT [FK_sections_branches] FOREIGN KEY([branchId])
REFERENCES [dbo].[branches] ([branchId])
GO
ALTER TABLE [dbo].[sections] CHECK CONSTRAINT [FK_sections_branches]
GO
ALTER TABLE [dbo].[serials]  WITH CHECK ADD  CONSTRAINT [FK_serials_items] FOREIGN KEY([itemId])
REFERENCES [dbo].[items] ([itemId])
GO
ALTER TABLE [dbo].[serials] CHECK CONSTRAINT [FK_serials_items]
GO
ALTER TABLE [dbo].[serials]  WITH CHECK ADD  CONSTRAINT [FK_serials_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[serials] CHECK CONSTRAINT [FK_serials_users]
GO
ALTER TABLE [dbo].[serials]  WITH CHECK ADD  CONSTRAINT [FK_serials_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[serials] CHECK CONSTRAINT [FK_serials_users1]
GO
ALTER TABLE [dbo].[servicesCosts]  WITH CHECK ADD  CONSTRAINT [FK_servicesCosts_items] FOREIGN KEY([itemId])
REFERENCES [dbo].[items] ([itemId])
GO
ALTER TABLE [dbo].[servicesCosts] CHECK CONSTRAINT [FK_servicesCosts_items]
GO
ALTER TABLE [dbo].[servicesCosts]  WITH CHECK ADD  CONSTRAINT [FK_servicesCosts_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[servicesCosts] CHECK CONSTRAINT [FK_servicesCosts_users]
GO
ALTER TABLE [dbo].[servicesCosts]  WITH CHECK ADD  CONSTRAINT [FK_servicesCosts_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[servicesCosts] CHECK CONSTRAINT [FK_servicesCosts_users1]
GO
ALTER TABLE [dbo].[setValues]  WITH CHECK ADD  CONSTRAINT [FK_setValues_setting] FOREIGN KEY([settingId])
REFERENCES [dbo].[setting] ([settingId])
GO
ALTER TABLE [dbo].[setValues] CHECK CONSTRAINT [FK_setValues_setting]
GO
ALTER TABLE [dbo].[subscriptionFees]  WITH CHECK ADD  CONSTRAINT [FK_subscriptionFees_memberships] FOREIGN KEY([membershipId])
REFERENCES [dbo].[memberships] ([membershipId])
GO
ALTER TABLE [dbo].[subscriptionFees] CHECK CONSTRAINT [FK_subscriptionFees_memberships]
GO
ALTER TABLE [dbo].[sysEmails]  WITH CHECK ADD  CONSTRAINT [FK_sysEmails_branches] FOREIGN KEY([branchId])
REFERENCES [dbo].[branches] ([branchId])
GO
ALTER TABLE [dbo].[sysEmails] CHECK CONSTRAINT [FK_sysEmails_branches]
GO
ALTER TABLE [dbo].[sysEmails]  WITH CHECK ADD  CONSTRAINT [FK_sysEmails_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[sysEmails] CHECK CONSTRAINT [FK_sysEmails_users]
GO
ALTER TABLE [dbo].[sysEmails]  WITH CHECK ADD  CONSTRAINT [FK_sysEmails_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[sysEmails] CHECK CONSTRAINT [FK_sysEmails_users1]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_groups] FOREIGN KEY([groupId])
REFERENCES [dbo].[groups] ([groupId])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_groups]
GO
ALTER TABLE [dbo].[userSetValues]  WITH CHECK ADD  CONSTRAINT [FK_userSetValues_setValues] FOREIGN KEY([valId])
REFERENCES [dbo].[setValues] ([valId])
GO
ALTER TABLE [dbo].[userSetValues] CHECK CONSTRAINT [FK_userSetValues_setValues]
GO
ALTER TABLE [dbo].[userSetValues]  WITH CHECK ADD  CONSTRAINT [FK_userSetValues_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[userSetValues] CHECK CONSTRAINT [FK_userSetValues_users]
GO
ALTER TABLE [dbo].[userSetValues]  WITH CHECK ADD  CONSTRAINT [FK_userSetValues_users1] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[userSetValues] CHECK CONSTRAINT [FK_userSetValues_users1]
GO
ALTER TABLE [dbo].[userSetValues]  WITH CHECK ADD  CONSTRAINT [FK_userSetValues_users2] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[userSetValues] CHECK CONSTRAINT [FK_userSetValues_users2]
GO
ALTER TABLE [dbo].[usersLogs]  WITH CHECK ADD  CONSTRAINT [FK_usersLogs_pos] FOREIGN KEY([posId])
REFERENCES [dbo].[pos] ([posId])
GO
ALTER TABLE [dbo].[usersLogs] CHECK CONSTRAINT [FK_usersLogs_pos]
GO
ALTER TABLE [dbo].[usersLogs]  WITH CHECK ADD  CONSTRAINT [FK_usersLogs_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[usersLogs] CHECK CONSTRAINT [FK_usersLogs_users]
GO
