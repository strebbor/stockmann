USE [stockmann]
GO
/****** Object:  Table [dbo].[stockItems]    Script Date: 07/02/2013 19:26:05 ******/
ALTER TABLE [dbo].[stockItems] DROP CONSTRAINT [DF_stockItems_overrideActive]
GO
ALTER TABLE [dbo].[stockItems] DROP CONSTRAINT [DF_stockItems_overrideExport]
GO
ALTER TABLE [dbo].[stockItems] DROP CONSTRAINT [DF_stockItems_agencyMargin]
GO
ALTER TABLE [dbo].[stockItems] DROP CONSTRAINT [DF_stockItems_grossMargin]
GO
ALTER TABLE [dbo].[stockItems] DROP CONSTRAINT [DF_stockItems_discount]
GO
ALTER TABLE [dbo].[stockItems] DROP CONSTRAINT [DF_stockItems_active]
GO
DROP TABLE [dbo].[stockItems]
GO
/****** Object:  Table [dbo].[supplier_templates]    Script Date: 07/02/2013 19:26:05 ******/
DROP TABLE [dbo].[supplier_templates]
GO
/****** Object:  Table [dbo].[suppliers]    Script Date: 07/02/2013 19:26:05 ******/
ALTER TABLE [dbo].[suppliers] DROP CONSTRAINT [DF_suppliers_default_markupPercentage]
GO
ALTER TABLE [dbo].[suppliers] DROP CONSTRAINT [DF_suppliers_discount]
GO
ALTER TABLE [dbo].[suppliers] DROP CONSTRAINT [DF_suppliers_grossMargin]
GO
ALTER TABLE [dbo].[suppliers] DROP CONSTRAINT [DF_suppliers_active]
GO
DROP TABLE [dbo].[suppliers]
GO
/****** Object:  Table [dbo].[templateColumn_formatting]    Script Date: 07/02/2013 19:26:05 ******/
DROP TABLE [dbo].[templateColumn_formatting]
GO
/****** Object:  Table [dbo].[templateColumns]    Script Date: 07/02/2013 19:26:05 ******/
ALTER TABLE [dbo].[templateColumns] DROP CONSTRAINT [DF_templateColumns_applyRounding]
GO
DROP TABLE [dbo].[templateColumns]
GO
/****** Object:  Table [dbo].[templates]    Script Date: 07/02/2013 19:26:05 ******/
ALTER TABLE [dbo].[templates] DROP CONSTRAINT [DF_templates_active]
GO
ALTER TABLE [dbo].[templates] DROP CONSTRAINT [DF_templates_direction]
GO
DROP TABLE [dbo].[templates]
GO
/****** Object:  Table [dbo].[templates]    Script Date: 07/02/2013 19:26:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[templates](
	[templateID] [int] IDENTITY(1,1) NOT NULL,
	[templateName] [varchar](50) NULL,
	[active] [varchar](50) NULL CONSTRAINT [DF_templates_active]  DEFAULT ('True'),
	[direction] [varchar](50) NULL CONSTRAINT [DF_templates_direction]  DEFAULT ('IMPORT'),
 CONSTRAINT [PK_templates] PRIMARY KEY CLUSTERED 
(
	[templateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[templateColumns]    Script Date: 07/02/2013 19:26:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[templateColumns](
	[templateColumnID] [int] IDENTITY(1,1) NOT NULL,
	[templateID] [int] NULL,
	[csvHeader] [varchar](50) NULL,
	[databaseColumn] [varchar](50) NULL,
	[columnType] [varchar](50) NULL,
	[calculation] [varchar](250) NULL,
	[conditionalFormatting] [varchar](50) NULL,
	[applyRounding] [varchar](50) NULL CONSTRAINT [DF_templateColumns_applyRounding]  DEFAULT ('False'),
 CONSTRAINT [PK_templateColumns] PRIMARY KEY CLUSTERED 
(
	[templateColumnID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[templateColumn_formatting]    Script Date: 07/02/2013 19:26:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[templateColumn_formatting](
	[formattingID] [int] IDENTITY(1,1) NOT NULL,
	[templateColumnID] [int] NULL,
	[op] [varchar](50) NULL,
	[color] [varchar](50) NULL,
	[number] [decimal](18, 2) NULL,
 CONSTRAINT [PK_templateColumn_formatting] PRIMARY KEY CLUSTERED 
(
	[formattingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[suppliers]    Script Date: 07/02/2013 19:26:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[suppliers](
	[supplierID] [int] IDENTITY(1,1) NOT NULL,
	[supplierName] [varchar](50) NULL,
	[supplierCode] [varchar](50) NULL,
	[uniqueKey] [varchar](50) NULL,
	[agencyMargin] [decimal](18, 2) NULL CONSTRAINT [DF_suppliers_default_markupPercentage]  DEFAULT ((0)),
	[discount] [decimal](18, 2) NULL CONSTRAINT [DF_suppliers_discount]  DEFAULT ((0)),
	[grossMargin] [decimal](18, 2) NULL CONSTRAINT [DF_suppliers_grossMargin]  DEFAULT ((0)),
	[active] [varchar](50) NULL CONSTRAINT [DF_suppliers_active]  DEFAULT ('TRUE'),
 CONSTRAINT [PK_suppliers] PRIMARY KEY CLUSTERED 
(
	[supplierID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[supplier_templates]    Script Date: 07/02/2013 19:26:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[supplier_templates](
	[supplierTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[templateID] [int] NULL,
	[supplierID] [int] NULL,
 CONSTRAINT [PK_supplier_templates] PRIMARY KEY CLUSTERED 
(
	[supplierTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stockItems]    Script Date: 07/02/2013 19:26:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stockItems](
	[stockID] [int] IDENTITY(1,1) NOT NULL,
	[supplierID] [int] NULL,
	[productCode] [varchar](50) NULL,
	[productName] [varchar](50) NULL,
	[description] [varchar](250) NULL,
	[uniqueKey] [varchar](50) NULL,
	[productBasePrice] [decimal](18, 2) NULL,
	[overrideMargins] [varchar](50) NULL CONSTRAINT [DF_stockItems_overrideActive]  DEFAULT ('False'),
	[mustExport] [varchar](50) NULL CONSTRAINT [DF_stockItems_overrideExport]  DEFAULT ('True'),
	[agencyMargin] [decimal](18, 2) NULL CONSTRAINT [DF_stockItems_agencyMargin]  DEFAULT ((0)),
	[grossMargin] [decimal](18, 2) NULL CONSTRAINT [DF_stockItems_grossMargin]  DEFAULT ((0)),
	[discount] [decimal](18, 2) NULL CONSTRAINT [DF_stockItems_discount]  DEFAULT ((0)),
	[lastUpdate] [datetime] NULL,
	[active] [int] NULL CONSTRAINT [DF_stockItems_active]  DEFAULT ((1)),
	[SpecialDiscount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_stockItems] PRIMARY KEY CLUSTERED 
(
	[stockID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
