USE [base]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 2022-01-01 4:33:22 PM ******/

SET IDENTITY_INSERT [dbo].[setting] ON 


INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (34, N'invoiceTax_bool', N'tax')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (35, N'invoiceTax_decimal', N'tax')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (36, N'itemsTax_bool', N'tax')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (37, N'itemsTax_decimal', N'tax')
SET IDENTITY_INSERT [dbo].[setting] OFF
GO
SET IDENTITY_INSERT [dbo].[setValues] ON 

INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (112, N'0', 1, 1, N'tax', 34)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (113, N'0', 1, 1, N'tax', 35)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (114, N'0', 1, 1, N'tax', 36)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (115, N'0', 1, 1, N'tax', 37)
SET IDENTITY_INSERT [dbo].[setValues] OFF
GO

