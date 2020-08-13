/****** Object:  Table [dbo].[Product]    Script Date: 8/13/2020 1:41:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[pId] [int] IDENTITY(1,1) NOT NULL,
	[productCode] [nvarchar](30) NOT NULL,
	[productName] [nvarchar](100) NOT NULL,
	[manufacturer] [nvarchar](100) NOT NULL,
	[quantity] [int] NOT NULL,
	[rate] [money] NOT NULL,
	[totalAmount]  AS ([quantity]*[rate]),
	[createdOn] [datetime] NOT NULL,
	[lastModifiedOn] [datetime] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Product_Id] PRIMARY KEY CLUSTERED 
(
	[pId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT (getdate()) FOR [createdOn]
GO
