USE [incposdb]
GO
ALTER TABLE [dbo].[usersLogs] DROP CONSTRAINT [FK_usersLogs_users]
GO
ALTER TABLE [dbo].[usersLogs] DROP CONSTRAINT [FK_usersLogs_pos]
GO
ALTER TABLE [dbo].[userSetValues] DROP CONSTRAINT [FK_userSetValues_users2]
GO
ALTER TABLE [dbo].[userSetValues] DROP CONSTRAINT [FK_userSetValues_users1]
GO
ALTER TABLE [dbo].[userSetValues] DROP CONSTRAINT [FK_userSetValues_users]
GO
ALTER TABLE [dbo].[userSetValues] DROP CONSTRAINT [FK_userSetValues_setValues]
GO
ALTER TABLE [dbo].[users] DROP CONSTRAINT [FK_users_groups]
GO
ALTER TABLE [dbo].[units] DROP CONSTRAINT [FK_units_users1]
GO
ALTER TABLE [dbo].[units] DROP CONSTRAINT [FK_units_users]
GO
ALTER TABLE [dbo].[setValues] DROP CONSTRAINT [FK_setValues_setting]
GO
ALTER TABLE [dbo].[servicesCosts] DROP CONSTRAINT [FK_servicesCosts_users1]
GO
ALTER TABLE [dbo].[servicesCosts] DROP CONSTRAINT [FK_servicesCosts_users]
GO
ALTER TABLE [dbo].[servicesCosts] DROP CONSTRAINT [FK_servicesCosts_items]
GO
ALTER TABLE [dbo].[serials] DROP CONSTRAINT [FK_serials_users1]
GO
ALTER TABLE [dbo].[serials] DROP CONSTRAINT [FK_serials_users]
GO
ALTER TABLE [dbo].[serials] DROP CONSTRAINT [FK_serials_items]
GO
ALTER TABLE [dbo].[sections] DROP CONSTRAINT [FK_sections_branches]
GO
ALTER TABLE [dbo].[propertiesItems] DROP CONSTRAINT [FK_propertiesItems_users1]
GO
ALTER TABLE [dbo].[propertiesItems] DROP CONSTRAINT [FK_propertiesItems_users]
GO
ALTER TABLE [dbo].[propertiesItems] DROP CONSTRAINT [FK_propertiesItems_properties]
GO
ALTER TABLE [dbo].[properties] DROP CONSTRAINT [FK_properties_users1]
GO
ALTER TABLE [dbo].[properties] DROP CONSTRAINT [FK_properties_users]
GO
ALTER TABLE [dbo].[posUsers] DROP CONSTRAINT [FK_posUsers_users2]
GO
ALTER TABLE [dbo].[posUsers] DROP CONSTRAINT [FK_posUsers_users1]
GO
ALTER TABLE [dbo].[posUsers] DROP CONSTRAINT [FK_posUsers_users]
GO
ALTER TABLE [dbo].[posUsers] DROP CONSTRAINT [FK_posUsers_pos]
GO
ALTER TABLE [dbo].[pos] DROP CONSTRAINT [FK_pos_users1]
GO
ALTER TABLE [dbo].[pos] DROP CONSTRAINT [FK_pos_users]
GO
ALTER TABLE [dbo].[pos] DROP CONSTRAINT [FK_pos_branches]
GO
ALTER TABLE [dbo].[orderscontents] DROP CONSTRAINT [FK_orderscontents_users1]
GO
ALTER TABLE [dbo].[orderscontents] DROP CONSTRAINT [FK_orderscontents_users]
GO
ALTER TABLE [dbo].[orderscontents] DROP CONSTRAINT [FK_orderscontents_orders]
GO
ALTER TABLE [dbo].[orderscontents] DROP CONSTRAINT [FK_orderscontents_items]
GO
ALTER TABLE [dbo].[orderscontents] DROP CONSTRAINT [FK_orderscontents_invoices]
GO
ALTER TABLE [dbo].[orders] DROP CONSTRAINT [FK_orders_users2]
GO
ALTER TABLE [dbo].[orders] DROP CONSTRAINT [FK_orders_users1]
GO
ALTER TABLE [dbo].[orders] DROP CONSTRAINT [FK_orders_users]
GO
ALTER TABLE [dbo].[orders] DROP CONSTRAINT [FK_orders_invoices]
GO
ALTER TABLE [dbo].[objects] DROP CONSTRAINT [FK_objects_users1]
GO
ALTER TABLE [dbo].[objects] DROP CONSTRAINT [FK_objects_users]
GO
ALTER TABLE [dbo].[medals] DROP CONSTRAINT [FK_medals_users1]
GO
ALTER TABLE [dbo].[medals] DROP CONSTRAINT [FK_medals_users]
GO
ALTER TABLE [dbo].[medalAgent] DROP CONSTRAINT [FK_medalAgent_users1]
GO
ALTER TABLE [dbo].[medalAgent] DROP CONSTRAINT [FK_medalAgent_users]
GO
ALTER TABLE [dbo].[medalAgent] DROP CONSTRAINT [FK_medalAgent_offers]
GO
ALTER TABLE [dbo].[medalAgent] DROP CONSTRAINT [FK_medalAgent_medals]
GO
ALTER TABLE [dbo].[medalAgent] DROP CONSTRAINT [FK_medalAgent_coupons]
GO
ALTER TABLE [dbo].[medalAgent] DROP CONSTRAINT [FK_medalAgent_agents]
GO
ALTER TABLE [dbo].[locations] DROP CONSTRAINT [FK_locations_users1]
GO
ALTER TABLE [dbo].[locations] DROP CONSTRAINT [FK_locations_users]
GO
ALTER TABLE [dbo].[locations] DROP CONSTRAINT [FK_locations_sections]
GO
ALTER TABLE [dbo].[itemTransferOffer] DROP CONSTRAINT [FK_itemTransferOffer_users1]
GO
ALTER TABLE [dbo].[itemTransferOffer] DROP CONSTRAINT [FK_itemTransferOffer_users]
GO
ALTER TABLE [dbo].[itemTransferOffer] DROP CONSTRAINT [FK_itemTransferOffer_offers]
GO
ALTER TABLE [dbo].[itemTransferOffer] DROP CONSTRAINT [FK_itemTransferOffer_itemsTransfer]
GO
ALTER TABLE [dbo].[itemsUnits] DROP CONSTRAINT [FK_itemsUnits_users1]
GO
ALTER TABLE [dbo].[itemsUnits] DROP CONSTRAINT [FK_itemsUnits_users]
GO
ALTER TABLE [dbo].[itemsUnits] DROP CONSTRAINT [FK_itemsUnits_units]
GO
ALTER TABLE [dbo].[itemsUnits] DROP CONSTRAINT [FK_itemsUnits_items]
GO
ALTER TABLE [dbo].[itemsTransfer] DROP CONSTRAINT [FK_itemsTransfer_locations1]
GO
ALTER TABLE [dbo].[itemsTransfer] DROP CONSTRAINT [FK_itemsTransfer_locations]
GO
ALTER TABLE [dbo].[itemsTransfer] DROP CONSTRAINT [FK_itemsTransfer_itemsUnits]
GO
ALTER TABLE [dbo].[itemsTransfer] DROP CONSTRAINT [FK_itemsTransfer_invoices]
GO
ALTER TABLE [dbo].[itemsProp] DROP CONSTRAINT [FK_itemsProp_users1]
GO
ALTER TABLE [dbo].[itemsProp] DROP CONSTRAINT [FK_itemsProp_users]
GO
ALTER TABLE [dbo].[itemsProp] DROP CONSTRAINT [FK_itemsProp_propertiesItems]
GO
ALTER TABLE [dbo].[itemsProp] DROP CONSTRAINT [FK_itemsProp_items]
GO
ALTER TABLE [dbo].[itemsOffers] DROP CONSTRAINT [FK_itemsOffers_users1]
GO
ALTER TABLE [dbo].[itemsOffers] DROP CONSTRAINT [FK_itemsOffers_users]
GO
ALTER TABLE [dbo].[itemsOffers] DROP CONSTRAINT [FK_itemsOffers_offers]
GO
ALTER TABLE [dbo].[itemsOffers] DROP CONSTRAINT [FK_itemsOffers_itemsUnits]
GO
ALTER TABLE [dbo].[itemsMaterials] DROP CONSTRAINT [FK_itemsMaterials_units]
GO
ALTER TABLE [dbo].[itemsMaterials] DROP CONSTRAINT [FK_itemsMaterials_items1]
GO
ALTER TABLE [dbo].[itemsMaterials] DROP CONSTRAINT [FK_itemsMaterials_items]
GO
ALTER TABLE [dbo].[itemsLocations] DROP CONSTRAINT [FK_itemsLocations_users3]
GO
ALTER TABLE [dbo].[itemsLocations] DROP CONSTRAINT [FK_itemsLocations_users2]
GO
ALTER TABLE [dbo].[itemsLocations] DROP CONSTRAINT [FK_itemsLocations_users1]
GO
ALTER TABLE [dbo].[itemsLocations] DROP CONSTRAINT [FK_itemsLocations_users]
GO
ALTER TABLE [dbo].[itemsLocations] DROP CONSTRAINT [FK_itemsLocations_locations]
GO
ALTER TABLE [dbo].[itemsLocations] DROP CONSTRAINT [FK_itemsLocations_itemsUnits]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_users3]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_users2]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_users1]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_users]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_units1]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_units]
GO
ALTER TABLE [dbo].[items] DROP CONSTRAINT [FK_items_categories]
GO
ALTER TABLE [dbo].[invoicesOrders] DROP CONSTRAINT [FK_invoicesOrders_users1]
GO
ALTER TABLE [dbo].[invoicesOrders] DROP CONSTRAINT [FK_invoicesOrders_users]
GO
ALTER TABLE [dbo].[invoicesOrders] DROP CONSTRAINT [FK_invoicesOrders_orders]
GO
ALTER TABLE [dbo].[invoicesOrders] DROP CONSTRAINT [FK_invoicesOrders_invoices]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_users3]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_users2]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_users1]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_users]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_pos]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_invoices]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_branches]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_agents]
GO
ALTER TABLE [dbo].[groups] DROP CONSTRAINT [FK_groups_users2]
GO
ALTER TABLE [dbo].[groups] DROP CONSTRAINT [FK_groups_users1]
GO
ALTER TABLE [dbo].[groupObject] DROP CONSTRAINT [FK_groupObject_users1]
GO
ALTER TABLE [dbo].[groupObject] DROP CONSTRAINT [FK_groupObject_users]
GO
ALTER TABLE [dbo].[groupObject] DROP CONSTRAINT [FK_groupObject_objects]
GO
ALTER TABLE [dbo].[groupObject] DROP CONSTRAINT [FK_groupObject_groups]
GO
ALTER TABLE [dbo].[Expenses] DROP CONSTRAINT [FK_Expenses_users]
GO
ALTER TABLE [dbo].[docImages] DROP CONSTRAINT [FK_docImages_users1]
GO
ALTER TABLE [dbo].[docImages] DROP CONSTRAINT [FK_docImages_users]
GO
ALTER TABLE [dbo].[couponsInvoices] DROP CONSTRAINT [FK_couponsInvoices_users1]
GO
ALTER TABLE [dbo].[couponsInvoices] DROP CONSTRAINT [FK_couponsInvoices_users]
GO
ALTER TABLE [dbo].[couponsInvoices] DROP CONSTRAINT [FK_couponsInvoices_invoices]
GO
ALTER TABLE [dbo].[couponsInvoices] DROP CONSTRAINT [FK_couponsInvoices_coupons]
GO
ALTER TABLE [dbo].[coupons] DROP CONSTRAINT [FK_coupons_users1]
GO
ALTER TABLE [dbo].[coupons] DROP CONSTRAINT [FK_coupons_users]
GO
ALTER TABLE [dbo].[cities] DROP CONSTRAINT [FK_cities_countriesCodes]
GO
ALTER TABLE [dbo].[categoryuser] DROP CONSTRAINT [FK_categoryuser_users2]
GO
ALTER TABLE [dbo].[categoryuser] DROP CONSTRAINT [FK_categoryuser_users1]
GO
ALTER TABLE [dbo].[categoryuser] DROP CONSTRAINT [FK_categoryuser_users]
GO
ALTER TABLE [dbo].[categoryuser] DROP CONSTRAINT [FK_categoryuser_categories]
GO
ALTER TABLE [dbo].[categories] DROP CONSTRAINT [FK_categories_users1]
GO
ALTER TABLE [dbo].[categories] DROP CONSTRAINT [FK_categories_users]
GO
ALTER TABLE [dbo].[cashTransfer] DROP CONSTRAINT [FK_cashTransfer_users2]
GO
ALTER TABLE [dbo].[cashTransfer] DROP CONSTRAINT [FK_cashTransfer_users1]
GO
ALTER TABLE [dbo].[cashTransfer] DROP CONSTRAINT [FK_cashTransfer_users]
GO
ALTER TABLE [dbo].[cashTransfer] DROP CONSTRAINT [FK_cashTransfer_pos1]
GO
ALTER TABLE [dbo].[cashTransfer] DROP CONSTRAINT [FK_cashTransfer_pos]
GO
ALTER TABLE [dbo].[cashTransfer] DROP CONSTRAINT [FK_cashTransfer_invoices]
GO
ALTER TABLE [dbo].[cashTransfer] DROP CONSTRAINT [FK_cashTransfer_cashTransfer]
GO
ALTER TABLE [dbo].[cashTransfer] DROP CONSTRAINT [FK_cashTransfer_cards]
GO
ALTER TABLE [dbo].[cashTransfer] DROP CONSTRAINT [FK_cashTransfer_bondes]
GO
ALTER TABLE [dbo].[cashTransfer] DROP CONSTRAINT [FK_cashTransfer_banks]
GO
ALTER TABLE [dbo].[cashTransfer] DROP CONSTRAINT [FK_cashTransfer_agents]
GO
ALTER TABLE [dbo].[cards] DROP CONSTRAINT [FK_cards_users1]
GO
ALTER TABLE [dbo].[cards] DROP CONSTRAINT [FK_cards_users]
GO
ALTER TABLE [dbo].[branchStore] DROP CONSTRAINT [FK_branchStore_users1]
GO
ALTER TABLE [dbo].[branchStore] DROP CONSTRAINT [FK_branchStore_users]
GO
ALTER TABLE [dbo].[branchStore] DROP CONSTRAINT [FK_branchStore_branches2]
GO
ALTER TABLE [dbo].[branchStore] DROP CONSTRAINT [FK_branchStore_branches1]
GO
ALTER TABLE [dbo].[branchStore] DROP CONSTRAINT [FK_branchStore_branches]
GO
ALTER TABLE [dbo].[branchesUsers] DROP CONSTRAINT [FK_branchesUsers_users]
GO
ALTER TABLE [dbo].[branchesUsers] DROP CONSTRAINT [FK_branchesUsers_branches]
GO
ALTER TABLE [dbo].[branches] DROP CONSTRAINT [FK_branches_users1]
GO
ALTER TABLE [dbo].[branches] DROP CONSTRAINT [FK_branches_users]
GO
ALTER TABLE [dbo].[bondes] DROP CONSTRAINT [FK_bondes_users1]
GO
ALTER TABLE [dbo].[bondes] DROP CONSTRAINT [FK_bondes_users]
GO
ALTER TABLE [dbo].[bondes] DROP CONSTRAINT [FK_bondes_cashTransfer]
GO
ALTER TABLE [dbo].[agents] DROP CONSTRAINT [FK_agents_users1]
GO
ALTER TABLE [dbo].[agents] DROP CONSTRAINT [FK_agents_users]
GO
/****** Object:  Table [dbo].[usersLogs]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usersLogs]') AND type in (N'U'))
DROP TABLE [dbo].[usersLogs]
GO
/****** Object:  Table [dbo].[userSetValues]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[userSetValues]') AND type in (N'U'))
DROP TABLE [dbo].[userSetValues]
GO
/****** Object:  Table [dbo].[users]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type in (N'U'))
DROP TABLE [dbo].[users]
GO
/****** Object:  Table [dbo].[units]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[units]') AND type in (N'U'))
DROP TABLE [dbo].[units]
GO
/****** Object:  Table [dbo].[setValues]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setValues]') AND type in (N'U'))
DROP TABLE [dbo].[setValues]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setting]') AND type in (N'U'))
DROP TABLE [dbo].[setting]
GO
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[servicesCosts]') AND type in (N'U'))
DROP TABLE [dbo].[servicesCosts]
GO
/****** Object:  Table [dbo].[serials]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[serials]') AND type in (N'U'))
DROP TABLE [dbo].[serials]
GO
/****** Object:  Table [dbo].[sections]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sections]') AND type in (N'U'))
DROP TABLE [dbo].[sections]
GO
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[propertiesItems]') AND type in (N'U'))
DROP TABLE [dbo].[propertiesItems]
GO
/****** Object:  Table [dbo].[properties]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[properties]') AND type in (N'U'))
DROP TABLE [dbo].[properties]
GO
/****** Object:  Table [dbo].[posUsers]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[posUsers]') AND type in (N'U'))
DROP TABLE [dbo].[posUsers]
GO
/****** Object:  Table [dbo].[pos]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pos]') AND type in (N'U'))
DROP TABLE [dbo].[pos]
GO
/****** Object:  Table [dbo].[orderscontents]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[orderscontents]') AND type in (N'U'))
DROP TABLE [dbo].[orderscontents]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[orders]') AND type in (N'U'))
DROP TABLE [dbo].[orders]
GO
/****** Object:  Table [dbo].[offers]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[offers]') AND type in (N'U'))
DROP TABLE [dbo].[offers]
GO
/****** Object:  Table [dbo].[objects]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[objects]') AND type in (N'U'))
DROP TABLE [dbo].[objects]
GO
/****** Object:  Table [dbo].[medals]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medals]') AND type in (N'U'))
DROP TABLE [dbo].[medals]
GO
/****** Object:  Table [dbo].[medalAgent]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medalAgent]') AND type in (N'U'))
DROP TABLE [dbo].[medalAgent]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[locations]') AND type in (N'U'))
DROP TABLE [dbo].[locations]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemTransferOffer]') AND type in (N'U'))
DROP TABLE [dbo].[itemTransferOffer]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsUnits]') AND type in (N'U'))
DROP TABLE [dbo].[itemsUnits]
GO
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[itemsTransfer]
GO
/****** Object:  Table [dbo].[itemsProp]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsProp]') AND type in (N'U'))
DROP TABLE [dbo].[itemsProp]
GO
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsOffers]') AND type in (N'U'))
DROP TABLE [dbo].[itemsOffers]
GO
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsMaterials]') AND type in (N'U'))
DROP TABLE [dbo].[itemsMaterials]
GO
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsLocations]') AND type in (N'U'))
DROP TABLE [dbo].[itemsLocations]
GO
/****** Object:  Table [dbo].[items]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[items]') AND type in (N'U'))
DROP TABLE [dbo].[items]
GO
/****** Object:  Table [dbo].[invoicesOrders]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoicesOrders]') AND type in (N'U'))
DROP TABLE [dbo].[invoicesOrders]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoices]') AND type in (N'U'))
DROP TABLE [dbo].[invoices]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groups]') AND type in (N'U'))
DROP TABLE [dbo].[groups]
GO
/****** Object:  Table [dbo].[groupObject]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupObject]') AND type in (N'U'))
DROP TABLE [dbo].[groupObject]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expenses]') AND type in (N'U'))
DROP TABLE [dbo].[Expenses]
GO
/****** Object:  Table [dbo].[docImages]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[docImages]') AND type in (N'U'))
DROP TABLE [dbo].[docImages]
GO
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[couponsInvoices]') AND type in (N'U'))
DROP TABLE [dbo].[couponsInvoices]
GO
/****** Object:  Table [dbo].[coupons]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[coupons]') AND type in (N'U'))
DROP TABLE [dbo].[coupons]
GO
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[countriesCodes]') AND type in (N'U'))
DROP TABLE [dbo].[countriesCodes]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cities]') AND type in (N'U'))
DROP TABLE [dbo].[cities]
GO
/****** Object:  Table [dbo].[categoryuser]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categoryuser]') AND type in (N'U'))
DROP TABLE [dbo].[categoryuser]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categories]') AND type in (N'U'))
DROP TABLE [dbo].[categories]
GO
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cashTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[cashTransfer]
GO
/****** Object:  Table [dbo].[cards]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cards]') AND type in (N'U'))
DROP TABLE [dbo].[cards]
GO
/****** Object:  Table [dbo].[branchStore]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchStore]') AND type in (N'U'))
DROP TABLE [dbo].[branchStore]
GO
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchesUsers]') AND type in (N'U'))
DROP TABLE [dbo].[branchesUsers]
GO
/****** Object:  Table [dbo].[branches]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branches]') AND type in (N'U'))
DROP TABLE [dbo].[branches]
GO
/****** Object:  Table [dbo].[bondes]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bondes]') AND type in (N'U'))
DROP TABLE [dbo].[bondes]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[banks]') AND type in (N'U'))
DROP TABLE [dbo].[banks]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 17/06/2021 08:05:13 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agents]') AND type in (N'U'))
DROP TABLE [dbo].[agents]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 17/06/2021 08:05:13 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[agents](
	[agentId] [int] IDENTITY(1,1) NOT NULL,
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
	[balance] [decimal](20, 4) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[notes] [ntext] NULL,
	[isActive] [tinyint] NULL,
	[fax] [nvarchar](100) NULL,
	[maxDeserve] [decimal](20, 4) NULL,
 CONSTRAINT [PK_agents] PRIMARY KEY CLUSTERED 
(
	[agentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 17/06/2021 08:05:13 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bondes]    Script Date: 17/06/2021 08:05:13 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bondes](
	[bondId] [int] IDENTITY(1,1) NOT NULL,
	[number] [nvarchar](200) NULL,
	[amount] [decimal](20, 4) NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[branches]    Script Date: 17/06/2021 08:05:13 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 17/06/2021 08:05:13 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[branchStore]    Script Date: 17/06/2021 08:05:13 م ******/
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
 CONSTRAINT [PK_branchStore] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cards]    Script Date: 17/06/2021 08:05:13 م ******/
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
 CONSTRAINT [PK_cards] PRIMARY KEY CLUSTERED 
(
	[cardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 17/06/2021 08:05:13 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cashTransfer](
	[cashTransId] [int] IDENTITY(1,1) NOT NULL,
	[transType] [nvarchar](50) NULL,
	[posId] [int] NULL,
	[userId] [int] NULL,
	[agentId] [int] NULL,
	[invId] [int] NULL,
	[transNum] [nvarchar](50) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[cash] [decimal](20, 4) NULL,
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
 CONSTRAINT [PK_cashTransfer] PRIMARY KEY CLUSTERED 
(
	[cashTransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 17/06/2021 08:05:13 م ******/
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
	[taxes] [decimal](20, 4) NULL,
	[parentId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[notes] [ntext] NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoryuser]    Script Date: 17/06/2021 08:05:13 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 17/06/2021 08:05:13 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 17/06/2021 08:05:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[countriesCodes](
	[countryId] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_countriesCodes] PRIMARY KEY CLUSTERED 
(
	[countryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[coupons]    Script Date: 17/06/2021 08:05:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[coupons](
	[cId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[code] [nvarchar](100) NULL,
	[isActive] [tinyint] NULL,
	[discountType] [nvarchar](100) NULL,
	[discountValue] [decimal](20, 4) NULL,
	[startDate] [datetime2](7) NULL,
	[endDate] [datetime2](7) NULL,
	[notes] [ntext] NULL,
	[quantity] [int] NULL,
	[remainQ] [int] NULL,
	[invMin] [decimal](20, 4) NULL,
	[invMax] [decimal](20, 4) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[barcode] [nvarchar](200) NULL,
 CONSTRAINT [PK_coupons] PRIMARY KEY CLUSTERED 
(
	[cId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 17/06/2021 08:05:14 م ******/
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
	[discountValue] [decimal](20, 4) NULL,
	[discountType] [tinyint] NULL,
 CONSTRAINT [PK_couponsInvoices] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[docImages]    Script Date: 17/06/2021 08:05:14 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 17/06/2021 08:05:14 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[groupObject]    Script Date: 17/06/2021 08:05:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[groupObject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[groupId] [int] NULL,
	[objectId] [int] NULL,
	[notes] [ntext] NULL,
	[addOb] [tinyint] NULL,
	[updateOb] [tinyint] NULL,
	[deleteOb] [tinyint] NULL,
	[showOb] [tinyint] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_groupObject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 17/06/2021 08:05:14 م ******/
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
 CONSTRAINT [PK_groups] PRIMARY KEY CLUSTERED 
(
	[groupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 17/06/2021 08:05:14 م ******/
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
	[discountValue] [decimal](20, 4) NULL,
	[total] [decimal](20, 4) NULL,
	[totalNet] [decimal](20, 4) NULL,
	[paid] [decimal](20, 4) NULL,
	[deserved] [decimal](20, 4) NULL,
	[deservedDate] [date] NULL,
	[invDate] [date] NULL,
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
	[tax] [decimal](20, 4) NULL,
	[taxtype] [int] NULL,
	[name] [nvarchar](200) NULL,
	[isApproved] [tinyint] NULL,
 CONSTRAINT [PK_invoices] PRIMARY KEY CLUSTERED 
(
	[invoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoicesOrders]    Script Date: 17/06/2021 08:05:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoicesOrders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[invoiceId] [int] NULL,
	[orderId] [int] NULL,
	[ordercase] [nvarchar](50) NULL,
	[notes] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_invoicesOrders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[items]    Script Date: 17/06/2021 08:05:14 م ******/
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
	[taxes] [decimal](20, 4) NULL,
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
 CONSTRAINT [PK_items] PRIMARY KEY CLUSTERED 
(
	[itemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 17/06/2021 08:05:14 م ******/
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
	[storeCost] [decimal](20, 4) NULL,
 CONSTRAINT [PK_itemsLocations] PRIMARY KEY CLUSTERED 
(
	[itemsLocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 17/06/2021 08:05:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemsMaterials](
	[itemMatId] [int] IDENTITY(1,1) NOT NULL,
	[itemId] [int] NULL,
	[materialId] [int] NULL,
	[quantity] [decimal](18, 4) NULL,
	[unitId] [int] NULL,
	[price] [decimal](18, 18) NULL,
 CONSTRAINT [PK_itemsMaterials] PRIMARY KEY CLUSTERED 
(
	[itemMatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 17/06/2021 08:05:14 م ******/
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
 CONSTRAINT [PK_itemsOffers] PRIMARY KEY CLUSTERED 
(
	[ioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsProp]    Script Date: 17/06/2021 08:05:14 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 17/06/2021 08:05:14 م ******/
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
	[price] [decimal](20, 4) NULL,
	[itemUnitId] [int] NULL,
 CONSTRAINT [PK_itemsTransfer] PRIMARY KEY CLUSTERED 
(
	[itemsTransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 17/06/2021 08:05:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemsUnits](
	[itemUnitId] [int] IDENTITY(1,1) NOT NULL,
	[itemId] [int] NULL,
	[unitId] [int] NULL,
	[unitValue] [decimal](20, 4) NULL,
	[defaultSale] [smallint] NULL,
	[defaultPurchase] [smallint] NULL,
	[price] [decimal](20, 4) NULL,
	[barcode] [nvarchar](200) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[subUnitId] [int] NULL,
	[purchasePrice] [decimal](20, 4) NULL,
 CONSTRAINT [PK_itemsUnits] PRIMARY KEY CLUSTERED 
(
	[itemUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 17/06/2021 08:05:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemTransferOffer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[itemTransId] [int] NULL,
	[offerId] [int] NULL,
	[discountType] [nvarchar](100) NULL,
	[discountValue] [decimal](20, 4) NULL,
	[notes] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_itemTransferOffer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 17/06/2021 08:05:14 م ******/
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
 CONSTRAINT [PK_locations] PRIMARY KEY CLUSTERED 
(
	[locationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medalAgent]    Script Date: 17/06/2021 08:05:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medalAgent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[medalId] [int] NULL,
	[agentId] [int] NULL,
	[offerId] [int] NULL,
	[couponId] [int] NULL,
	[notes] [ntext] NULL,
	[isActive] [tinyint] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_medalAgent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medals]    Script Date: 17/06/2021 08:05:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medals](
	[medalId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[isActive] [tinyint] NULL,
	[notes] [ntext] NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_medals] PRIMARY KEY CLUSTERED 
(
	[medalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[objects]    Script Date: 17/06/2021 08:05:14 م ******/
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
 CONSTRAINT [PK_objects] PRIMARY KEY CLUSTERED 
(
	[objectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[offers]    Script Date: 17/06/2021 08:05:14 م ******/
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
	[discountValue] [decimal](20, 4) NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 17/06/2021 08:05:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[orderId] [int] IDENTITY(1,1) NOT NULL,
	[invoiceId] [int] NULL,
	[ordercase] [nvarchar](50) NULL,
	[userId] [int] NULL,
	[prior] [int] NULL,
	[type] [smallint] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orderscontents]    Script Date: 17/06/2021 08:05:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderscontents](
	[contentId] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NULL,
	[itemId] [int] NULL,
	[quantity] [decimal](20, 4) NULL,
	[invoiceId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_orderscontents] PRIMARY KEY CLUSTERED 
(
	[contentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pos]    Script Date: 17/06/2021 08:05:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pos](
	[posId] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](100) NULL,
	[name] [nvarchar](100) NULL,
	[balance] [decimal](20, 4) NULL,
	[branchId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
	[note] [ntext] NULL,
	[balanceAll] [decimal](20, 4) NULL,
 CONSTRAINT [PK_pos] PRIMARY KEY CLUSTERED 
(
	[posId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posUsers]    Script Date: 17/06/2021 08:05:14 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[properties]    Script Date: 17/06/2021 08:05:14 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 17/06/2021 08:05:14 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sections]    Script Date: 17/06/2021 08:05:14 م ******/
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
 CONSTRAINT [PK_sections] PRIMARY KEY CLUSTERED 
(
	[sectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[serials]    Script Date: 17/06/2021 08:05:14 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 17/06/2021 08:05:14 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servicesCosts](
	[costId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[costVal] [decimal](20, 4) NULL,
	[itemId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
 CONSTRAINT [PK_servicesCosts] PRIMARY KEY CLUSTERED 
(
	[costId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 17/06/2021 08:05:14 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[setValues]    Script Date: 17/06/2021 08:05:14 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[units]    Script Date: 17/06/2021 08:05:14 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 17/06/2021 08:05:14 م ******/
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
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userSetValues]    Script Date: 17/06/2021 08:05:14 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usersLogs]    Script Date: 17/06/2021 08:05:14 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[agents] ON 

INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (13, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), NULL, 2, NULL, NULL, 0, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-02T15:23:48.4083806' AS DateTime2), CAST(N'2021-05-05T13:23:34.6419512' AS DateTime2), 2, 2, NULL, 0, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (18, N'cus10', N'664600129', N'company10', N'add10', N'cus10@gmail.com', N'', N'+212-898765544', N'9c8336c58218f7dbea9b172c0da81139.jpg', N'c', N'', CAST(-2000.0000 AS Decimal(20, 4)), CAST(N'2021-05-02T16:20:55.7658847' AS DateTime2), CAST(N'2021-06-13T14:33:07.9189093' AS DateTime2), 2, NULL, N'note10', 0, N'', CAST(100000.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (20, N'Mohammad', N'531702975', N'increase', N'', N'', N'+965--7655', N'+971-77655', N'cba6ef02fcbd47ba36115f8f64248594.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-03T10:49:37.2417048' AS DateTime2), CAST(N'2021-05-27T10:52:08.1459740' AS DateTime2), 2, 2, N'', 1, N'+965--76544', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (21, N'العميل1', N'394261291', N'الشركة1', N'', N'', N'', N'+968-099887', N'90f607ba318fce94cafe1571617d1b6c.jpg', N'c', N'', CAST(95000.0000 AS Decimal(20, 4)), CAST(N'2021-05-03T13:28:28.7665158' AS DateTime2), CAST(N'2021-06-13T14:25:09.3896042' AS DateTime2), 2, NULL, N'', 0, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (22, N'عدم حذف هذا العميل 123', N'526864667', N'com1', N'address', N'ven1@mail.com', N'+966-2-8766', N'+971-0366988', N'77d0501bbf02ad459f88ab4b7531b14d.jpg', N'v', N'', CAST(-2000.0000 AS Decimal(20, 4)), CAST(N'2021-05-03T14:09:11.9300938' AS DateTime2), CAST(N'2021-06-13T14:23:34.2055977' AS DateTime2), 2, NULL, N'no1', 0, N'+965--665544', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (24, N'ven34', N'239162293', N'com3', N'', N'', N'+95004112344', N'+9660998777', N'', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-03T14:31:29.6651040' AS DateTime2), CAST(N'2021-05-03T15:40:41.5724517' AS DateTime2), 2, 2, N'', 0, N'+95004176554', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (25, N'العميل2', N'874505178', N'الشركة2', N'e@mail.com', N'e@mail.com', N'+974--87665', N'+966-87766', N'16008f81a32dddded32b87f4a2cd9ca7.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-03T14:55:59.2346784' AS DateTime2), CAST(N'2021-06-16T11:28:48.6243445' AS DateTime2), 2, 2, N'ملاحظات2', 0, N'+971-6-765544', CAST(200000.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (26, N'الزبون11', N'310584380', N'الشركة1', N'العنوان1', N'e@gmail.net', N'+965--766', N'+968-0998', N'37de6228ecdaf854ca17e0abd1062763.jpg', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-03T14:58:01.8645344' AS DateTime2), CAST(N'2021-06-03T13:19:11.6682494' AS DateTime2), 2, 2, N'ملاحظات1', 1, N'+965--55444', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (27, N'yas', N'296263574', N'increase', N'', N'', N'+968--099999', N'+966-098877', N'15c139cdb9cb2a3e6788751f02626b1e.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-03T15:07:56.6061482' AS DateTime2), CAST(N'2021-05-26T14:20:44.0594928' AS DateTime2), 2, 2, N'', 1, N'+964-1-76555', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (30, N'مورد اختبار', N'323267143', N'ssشركة', N'', N'', N'+96601109887', N'+966-098877', N'', N'v', N'', CAST(124000.0000 AS Decimal(20, 4)), CAST(N'2021-05-03T15:17:15.1575800' AS DateTime2), CAST(N'2021-06-17T14:20:21.4478543' AS DateTime2), 2, 2, N'', 1, N'+96601176555', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (33, N'العميل3', N'721274452', N'تجربة', N'3@mail.net', N'3@mail.net', N'+966-3-87665', N'+971-09887', N'ff301ee31a7bad76b8f563c843096adc.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-05T13:36:57.0841300' AS DateTime2), CAST(N'2021-06-17T09:32:55.8614205' AS DateTime2), 2, 2, N'ملاحظات3', 0, N'+965--76555', CAST(10.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (36, N'تجربة التاريخ', N'195777221', N'الشركة', N'address', N'e@mail.com', N'+965--0988777', N'+974-236588', N'9e57f20d79c131f76efff5103509ca8d.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-06T11:51:43.0578293' AS DateTime2), CAST(N'2021-05-26T14:19:00.2152333' AS DateTime2), 2, 2, N'ملاحظات', 1, N'+965--65544', CAST(200000.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (37, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL, NULL, NULL, 1, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (38, N'الاسم', N'310069437', N'company', N'e@mail.net', N'e@mail.net', N'+973--766555', N'+966-09877', N'f8232374a80b629d9ffa799df77bc908.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), NULL, CAST(N'2021-05-29T10:08:46.3968179' AS DateTime2), 2, 2, N'notes', 1, N'+971--34343', CAST(1200.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (39, N'name', N'721274452', N'com', N'n@mail.com', N'n@mail.com', N'', N'+965-665566544', N'f369cb172051ae89aaea306a576018d5.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), NULL, CAST(N'2021-05-26T14:50:49.8196390' AS DateTime2), 2, 2, N'no', 1, N'', CAST(15.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (40, N'cus1', N'979706308', N'com1', N'add', N'cus13@hotmail.com', N'+965--6655444', N'+974-987766687', N'd440dc23574eac00ee07d2070bc326a6.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), NULL, CAST(N'2021-05-29T10:41:44.2868162' AS DateTime2), 2, 2, N'no', 1, N'+965--77666666656656666', CAST(14.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (41, N'الزبون2', N'383558749', N'الشركة2', N'halab', N'', N'+974--65444', N'+974-76555', N'2ab64b9b24a0b1e7c1be08de64bf20b7.jpg', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), NULL, CAST(N'2021-06-13T13:44:23.3118628' AS DateTime2), 2, 2, N'', 1, N'+971-7-756544', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (44, N'ven5', N'354340947', N'com5', N'', N'', N'+966-3-98877', N'+966-9888777', N'30fc6575bf902fbb7443c32827f764b7.jfif', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), NULL, CAST(N'2021-06-03T13:21:12.1379930' AS DateTime2), 2, 2, N'', 1, N'+965--443333', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (46, N'ven12', N'350593260', N'', N'', N'', N'', N'+963099887766', N'', NULL, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL, 2, N'', 0, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (47, N'ven5', N'409747752', N'com5', N'', N'', N'', N'+963099887766', N'', NULL, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL, 2, N'', 0, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (48, N'ven5', N'250136962', N'company5', N'', N'', N'', N'+963099887766', N'', NULL, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL, 2, N'', 0, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (49, N'الاسم', N'874505178', N'الشركة', N'', N'', N'+963-11-87665', N'+966-098877', N'32311b5fce9eda034bcb7e7185da6225.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-10T10:45:17.4129806' AS DateTime2), CAST(N'2021-05-26T14:34:47.8102501' AS DateTime2), 2, 2, N'', 1, N'+967-3-888675', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (50, N'تجربة', N'109734150', N'الشركة', N'', N'', N'+968--77655', N'+968-987665', N'1610a829bfbc79ad551271913ec4e155.jpg', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-10T10:52:15.1545706' AS DateTime2), CAST(N'2021-05-25T14:44:17.1964373' AS DateTime2), 2, 2, N'', 1, N'+968--66544', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (51, N'new', N'648910058', N'new com', N'address', N'e@email.com', N'+965--987767', N'+968-098877', N'9e95263dffc253da89baaaf21e4a16ae.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-10T11:07:12.8292681' AS DateTime2), CAST(N'2021-05-29T10:11:38.2855267' AS DateTime2), 2, 2, N'notes', 1, N'+965--344566', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (52, N'new1', N'648910058', N'new com', N'address', N'e@mail.org', N'+965--7655', N'+968-098776', N'332ce0fc448f5f4cc5770ffd1972a5b8.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-10T11:11:32.7455194' AS DateTime2), CAST(N'2021-05-29T10:11:56.9073710' AS DateTime2), 2, 2, N'notes', 1, N'+965--444444', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (55, N'hddd', N'173980060', N'lknl', N'', N'', N'+966-6-234234532', N'+965-453425325', N'f511fb76d630487164e36642f221e881.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-17T17:19:27.4125566' AS DateTime2), CAST(N'2021-05-26T14:36:57.4239163' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (56, N'ahmd', N'664600129', N'hh', N'', N'', N'+966-6-23523525', N'+965-34534534', N'07db2136fa28ae8857d5dcf41365af0d.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-18T03:46:42.2447545' AS DateTime2), CAST(N'2021-05-26T14:26:29.0701516' AS DateTime2), 2, 2, N'', 1, N'+963-21-23523', CAST(33.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (57, N'ahmad', N'802914444', N'dqwdqwd', N'aad@egfew.com', N'aad@egfew.com', N'+973--234234', N'+965-777764', N'a3319b3adf7e69d0d26ef3b05c51bf34.png', N'v', N'', CAST(50100.0000 AS Decimal(20, 4)), CAST(N'2021-05-18T04:19:49.5609334' AS DateTime2), CAST(N'2021-06-16T12:30:20.7262968' AS DateTime2), 2, 2, N'', 1, N'+218-61-2342342', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (58, N'n', N'173980060', N'n', N'', N'', N'+965--776655', N'+965-09888787', N'1af86a79362aee3d07adaa181d3b4530.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-20T11:14:07.1127208' AS DateTime2), CAST(N'2021-05-26T14:37:46.5487533' AS DateTime2), 2, 2, N'', 1, N'+965--66555', CAST(10.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (59, N'm', N'164924258', N'm', N'', N'', N'+965--776655', N'+965-098887', N'2d59818c743d4812c37c0319776e6eaf.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-20T12:10:38.1659499' AS DateTime2), CAST(N'2021-05-22T15:47:28.4007423' AS DateTime2), 2, 2, N'', 1, N'+965--5444343', CAST(12.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (60, N'mnbv', N'998301123', N'', N'', N'', N'', N'+965-554444444', N'59.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T09:50:24.8095254' AS DateTime2), CAST(N'2021-05-22T09:50:24.8095254' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (61, N'ffffff', N'173980060', N'', N'', N'', N'', N'+965-424242424', N'676bc5b0437c5cf998e3126cc5c15067.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T09:51:13.2705995' AS DateTime2), CAST(N'2021-05-26T14:39:18.8606062' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (62, N'drfffff', N'173980060', N'', N'', N'', N'', N'+965-444242424', N'4a735ab7e4fc144e629adcc88c50d928.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T09:51:44.1698805' AS DateTime2), CAST(N'2021-05-26T14:39:02.9497889' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (63, N'ffdfdfd', N'153227988', N'', N'', N'', N'', N'+965-646363636', N'3abf9f93f2d741816737ce8a69275049.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T09:54:03.8234234' AS DateTime2), CAST(N'2021-05-24T17:02:39.9831199' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (67, N'test', N'874202921', N'test', N'', N'', N'+965--8766', N'+968-87766', N'67.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T12:49:29.8254787' AS DateTime2), CAST(N'2021-05-22T12:49:29.8254787' AS DateTime2), 2, 2, N'', 1, N'+965--64332', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (68, N'test2', N'211210787', N'test2', N'', N'', N'+965--876665', N'+965-036987', N'33.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T13:07:20.0150995' AS DateTime2), CAST(N'2021-05-22T13:07:20.0150995' AS DateTime2), 2, 2, N'', 1, N'+965--234566', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (69, N'test3', N'173980060', N'test3', N'', N'', N'+965--76565655', N'+966-0998887', N'a8bd239f1b510e6202ce53e4acb87ec0.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T13:13:02.8570569' AS DateTime2), CAST(N'2021-05-26T14:38:52.5514858' AS DateTime2), 2, 2, N'', 1, N'+965--665555', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (70, N'test4', N'17211273', N'test4', N'', N'', N'+965--7766', N'+971-0998877', NULL, N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T13:17:38.2984760' AS DateTime2), CAST(N'2021-05-22T13:17:38.2984760' AS DateTime2), 2, 2, N'', 1, N'+965--55444', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (71, N'test5', N'397276743', N'test5', N'', N'', N'+965--54333', N'+965-099888', N'1933956d6e4530c87b406a5f1e04cdd3.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T13:25:52.0412104' AS DateTime2), CAST(N'2021-05-27T15:57:59.9101897' AS DateTime2), 2, 2, N'', 1, N'+965--76555', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (72, N'test6', N'752750181', N'test6', N'', N'', N'+965--55444', N'+966-09888', N'8f9c7dcf3974bcd3007661a7bc07f748.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T13:28:06.3121417' AS DateTime2), CAST(N'2021-05-22T15:57:34.9739318' AS DateTime2), 2, 2, N'', 1, N'+965--44333', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (74, N'test8', N'606425761', N'test8', N'', N'', N'+965--6555', N'+966-0988776', N'3d8a89a8d4a2669103672e20b295f70e.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T13:33:57.6664362' AS DateTime2), CAST(N'2021-05-26T10:42:37.6562910' AS DateTime2), 2, 2, N'', 1, N'+965--65544', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (76, N'Ali', N'821258008', N'com', N'aleppo', N'ali@outlook.com', N'+965--76666', N'+965-900025559', N'acad2cb19b348c62bb4a8e6d19b57e94.jpg', N'v', N'', CAST(-2000.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T13:51:11.1080633' AS DateTime2), CAST(N'2021-06-13T14:19:44.9466272' AS DateTime2), 2, NULL, N'notes', 0, N'+971-2-345667', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (79, N'Mohamad', N'727284076', N'', N'', N'', N'', N'+966-233344444', N'6ba5856ab6276042e4e8933b76d8cd2d.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T16:29:53.5773524' AS DateTime2), CAST(N'2021-05-23T17:32:48.2641768' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (82, N'test', N'185566250', N'test com', N't@mail.org', N't@mail.org', N'', N'+965-09888', N'94f1470a482faee14779e695dc385390.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-24T17:01:54.5633887' AS DateTime2), CAST(N'2021-05-24T17:02:20.9149242' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (83, N'test', N'333959899', N'test', N'w@mail.com', N'w@mail.com', N'', N'+968-988878', N'2dc70af4aa7464eae5105feeb47fa35e.png', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-24T17:17:41.0663512' AS DateTime2), CAST(N'2021-05-27T11:00:56.4030840' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (85, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-24T17:25:58.4516564' AS DateTime2), CAST(N'2021-05-24T17:25:58.4516564' AS DateTime2), NULL, NULL, NULL, 1, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (86, N'مورد جديد', N'354340947', N'شركة جديدة', N'', N'', N'+965--8766', N'+965-987766', N'a0a5bf7453680d921382ece447fb8439.jpg', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-25T14:44:57.0373756' AS DateTime2), CAST(N'2021-06-03T13:20:31.6366877' AS DateTime2), 2, 2, N'', 1, N'+965--776655', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (87, N'name', N'179920289', N'com', N'', N'', N'+966-2-76554', N'+968-098776', N'694568a38ec02b9345ab1f652aa86427.jpg', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T10:28:02.0416510' AS DateTime2), CAST(N'2021-05-26T10:36:00.2572169' AS DateTime2), 2, 2, N'', 1, N'+966-2-76655', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (93, N'name1', N'333959899', N'com1', N'dsa', N'posadmpas@gmail.com', N'+965--76655', N'+974-09888', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T10:32:30.5358721' AS DateTime2), CAST(N'2021-05-27T11:01:39.5038125' AS DateTime2), 2, 2, N'asd', 1, N'+965--433454', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (94, N'vendor1', N'333959899', N'company1', N'address', N'vendor1@gmail.com', N'+965--7665', N'+968-099988', N'f8a33e27581ea8951e50227d8f88cc42.png', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:06:10.2861026' AS DateTime2), CAST(N'2021-05-27T11:00:34.6814900' AS DateTime2), 2, 2, N'notes', 1, N'+965--54433', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (95, N'vendor2', N'542692035', N'com2', N'address2', N'vendor2@gmail.com', N'+965--87766', N'+968-098877', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:10:08.2181305' AS DateTime2), CAST(N'2021-05-26T14:33:40.1884111' AS DateTime2), 2, 2, N'notes2', 1, N'+966-3-766555', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (96, N'customer1', N'333457741', N'company1', N'address1', N'customer1@mail.com', N'+965--765444', N'+965-098877', N'03c78974a814080b4dea8d6b3be9200b.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:14:46.8059906' AS DateTime2), CAST(N'2021-05-26T11:14:46.8059906' AS DateTime2), 2, 2, N'notes', 1, N'+966-3-65544', CAST(10.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (97, N'customer2', N'114850684', N'com2', N'address2', N'customer2@mail.net', N'+965--9876655', N'+965-098887', N'54b481299e43159c8b86a7b48abfac9a.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:16:39.3005828' AS DateTime2), CAST(N'2021-05-27T15:55:55.5621563' AS DateTime2), 2, 2, N'notes', 1, N'+965--655444', CAST(12.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (98, N'vendor3', N'773226304', N'com3', N'address', N'ven3@gmail.com', N'+966-4-887665', N'+966-987766', N'60f5fcf614d791d17ed1836e07f572d5.png', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:20:12.2911369' AS DateTime2), CAST(N'2021-05-26T11:20:12.2911369' AS DateTime2), 2, 2, N'notes', 1, N'+965--876655', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (99, N'vendor4', N'16558617', N'com4', N'address4', N'ven4@hotmail.com', N'+966-2-76555', N'+966-098876665', N'e45a0ca43a89e1e5cb9e17130398cbfe.png', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:21:41.3448791' AS DateTime2), CAST(N'2021-05-26T11:21:41.3448791' AS DateTime2), 2, 2, N'notes4', 1, N'+966-3-76554', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (101, N'vendor6', N'336022791', N'com6', N'', N'', N'+966-2-97665', N'+968-099872222', N'65cbc53ce24c975bac068b74ce9851ad.png', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:30:02.9743132' AS DateTime2), CAST(N'2021-05-26T14:16:13.6316195' AS DateTime2), 2, 2, N'', 1, N'+965--665555', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (102, N'customer3', N'699531950', N'com3', N'add3', N'cus3@mail.com', N'+966-3-98777', N'+966-0998888', N'3b58509ddc436f5be16ae07eb41e5485.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:39:50.9533465' AS DateTime2), CAST(N'2021-05-26T11:39:50.9533465' AS DateTime2), 2, 2, N'notes', 1, N'+968--877665', CAST(12.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (103, N'customer4', N'554097599', N'com4', N'add4', N'cus4@gmail.com', N'+965--76554', N'+966-09888', N'3b58509ddc436f5be16ae07eb41e5485.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:40:40.6908299' AS DateTime2), CAST(N'2021-05-26T11:40:40.6908299' AS DateTime2), 2, 2, N'notes', 1, N'+965--654444', CAST(15.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (104, N'الزبون1', N'308854941', N'الشركة1', N'العنوان1', N'e@gmail.net', N'+965--98766', N'+971-098776', N'2c942114130107a42564129d88364caa.jpg', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-27T10:49:52.5562924' AS DateTime2), CAST(N'2021-05-27T10:49:52.5562924' AS DateTime2), 2, 2, N'ملاحظات1', 1, N'+965--7766555', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (105, N'ven', N'494037165', N'ven', N'ven', N'ven@mail.com', N'+965--7665', N'+966-09888', N'', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-27T13:47:37.8875118' AS DateTime2), CAST(N'2021-05-27T13:47:37.8875118' AS DateTime2), 2, 2, N'no', 1, N'+965--66555', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (106, N'ven1', N'701789470', N'ven1', N'ven1', N'ven1@mail.com', N'+965--7665', N'+966-09888', N'0392aca4cfc104fe1e0e1fc01a156e48.jpg', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-27T13:48:17.8335325' AS DateTime2), CAST(N'2021-05-27T13:48:45.2653372' AS DateTime2), 2, 2, N'no1', 1, N'+965--66555', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (107, N'cus1', N'564289888', N'cus1', N'cus1', N'cus1@mail.net', N'+965--55443', N'+966-09987', N'75d707c18b8826bfc65d86302331e1b8.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-27T13:49:27.4118080' AS DateTime2), CAST(N'2021-05-27T13:49:50.4120674' AS DateTime2), 2, 2, N'cus1', 1, N'+965--77655', CAST(10.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (108, N'cus2', N'788607256', N'cus2', N'', N'', N'+965--76665', N'+968-98877', N'75d707c18b8826bfc65d86302331e1b8.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-27T13:50:19.5810285' AS DateTime2), CAST(N'2021-05-27T13:50:19.5810285' AS DateTime2), 2, 2, N'vo', 1, N'+965--87655', CAST(15.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (109, N'مورد جديد', N'767588288', N'شركة', N'', N'', N'+966-7-8775', N'+965-98877', N'612baa4e93fed6bc3283d71e6fbf6ae4.jpg', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T10:24:29.4770275' AS DateTime2), CAST(N'2021-05-29T10:24:29.4770275' AS DateTime2), 2, 2, N'', 1, N'+966-6-876655', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (110, N'new vendor', N'387216466', N'new company', N'', N'', N'', N'+965-98765', N'85c2efa2d5814dd19fb1e2b4c70adec5.png', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T10:27:57.8895593' AS DateTime2), CAST(N'2021-05-29T12:38:36.7359406' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (111, N'عميل جديد', N'191311660', N'شركة جديدة', N'', N'', N'+965--765', N'+965-98776', N'b6839313a590506d5fe90d755a18a78f.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T10:31:33.0763562' AS DateTime2), CAST(N'2021-05-29T10:31:33.0763562' AS DateTime2), 2, 2, N'', 1, N'+965--7665', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (112, N'مورد اختبار', N'892340670', N'ssشركة', N'', N'', N'+966-2-09887', N'+966-098877', N'', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-31T20:11:34.2622225' AS DateTime2), CAST(N'2021-05-31T20:11:34.2622225' AS DateTime2), 2, 2, N'', 1, N'+966-2-76555', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (113, N'name1', N'238384423', N'com1', N'dsa', N'posadmpas@gmail.com', N'+965--76655', N'+974-09888', N'', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-31T20:11:54.9768320' AS DateTime2), CAST(N'2021-05-31T20:11:54.9768320' AS DateTime2), 2, 2, N'asd', 1, N'+965--433454', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (114, N'ahmad', N'466330956', N'dqwdqwd', N'aad@egfew.com', N'aad@egfew.com', N'+973--234234', N'+965-777764', N'', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-31T20:12:00.7055136' AS DateTime2), CAST(N'2021-05-31T20:12:00.7055136' AS DateTime2), 2, 2, N'', 1, N'+218-61-2342342', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (115, N'ddssds', N'307545950', N'', N'', N'', N'', N'+965-444444444', NULL, N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-01T11:03:36.3406567' AS DateTime2), CAST(N'2021-06-01T11:03:36.3406567' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (116, N'الزبون3-6', N'470172864', N'الشركة3-6', N'العنوان1', N'e3-6@gmail.net', N'+965--766', N'+968-0998', N'510e64744fc6d6c7cea034b4bd4825cb.jpg', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-03T12:53:41.2804694' AS DateTime2), CAST(N'2021-06-03T12:53:41.2804694' AS DateTime2), 2, 2, N'ملاحظات1', 1, N'+965--55444', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (117, N'العميل12', N'763739324', N'الشركة12', N'e12@mail.com', N'e12@mail.com', N'+974--87665', N'+966-87766', N'72adeed7e7804cd0f75fd3f2e0922d80.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-03T12:55:16.4696608' AS DateTime2), CAST(N'2021-06-03T12:55:16.4696608' AS DateTime2), 2, 2, N'ملاحظات12', 1, N'+971-6-765544', CAST(200000.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (118, N'تجربة 3-6', N'205684746', N'الشركة', N'', N'', N'+968--77655', N'+968-987665', N'fc3befd3360d499b82738e558d8f0fea.jpg', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-03T13:05:43.6648697' AS DateTime2), CAST(N'2021-06-03T13:05:43.6648697' AS DateTime2), 2, 2, N'', 1, N'+968--66544', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (119, N'name11', N'315285152', N'com11', N'dsa', N'posadmpas@gmail.com', N'+965--76655', N'+974-09888', N'6ece0bf6643794263ad50a5ad7c54470.jpg', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-03T13:06:21.4317574' AS DateTime2), CAST(N'2021-06-03T13:06:21.4317574' AS DateTime2), 2, 2, N'asd', 1, N'+965--433454', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (120, N'new test', N'342041156', N'new comp', N'', N'', N'+965--887777', N'+971-09988', N'93708755b649e4a43d3385c2d3ea6dd1.jpg', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-03T13:08:19.1671887' AS DateTime2), CAST(N'2021-06-03T13:08:19.1671887' AS DateTime2), 2, 2, N'', 1, N'+965--8877', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (122, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(-1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-13T13:18:32.7266767' AS DateTime2), CAST(N'2021-06-13T13:18:32.7266767' AS DateTime2), NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (123, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(-1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-13T13:21:25.2297331' AS DateTime2), CAST(N'2021-06-13T13:21:25.2297331' AS DateTime2), NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (124, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(-1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-13T13:28:33.2684556' AS DateTime2), CAST(N'2021-06-13T13:28:33.2684556' AS DateTime2), NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (125, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(-1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-13T13:31:45.2863983' AS DateTime2), CAST(N'2021-06-13T13:31:45.2863983' AS DateTime2), NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (126, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(100.0000 AS Decimal(20, 4)), CAST(N'2021-06-13T13:35:47.7654389' AS DateTime2), CAST(N'2021-06-13T13:35:47.7654389' AS DateTime2), NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (127, NULL, NULL, NULL, N'syr', NULL, NULL, NULL, NULL, NULL, NULL, CAST(100.0000 AS Decimal(20, 4)), CAST(N'2021-06-13T13:38:31.9138229' AS DateTime2), CAST(N'2021-06-13T13:38:31.9138229' AS DateTime2), NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (128, NULL, NULL, NULL, N'syr', NULL, NULL, NULL, NULL, NULL, NULL, CAST(-1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-13T13:51:40.3829557' AS DateTime2), CAST(N'2021-06-13T13:51:40.3829557' AS DateTime2), NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (129, NULL, NULL, NULL, N'syr', NULL, NULL, NULL, NULL, NULL, NULL, CAST(-1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-13T13:53:54.8835608' AS DateTime2), CAST(N'2021-06-13T13:53:54.8835608' AS DateTime2), NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (130, NULL, NULL, NULL, N'syr', NULL, NULL, NULL, NULL, NULL, NULL, CAST(-2000.0000 AS Decimal(20, 4)), CAST(N'2021-06-13T13:55:39.8171978' AS DateTime2), CAST(N'2021-06-13T13:55:39.8171978' AS DateTime2), NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (131, NULL, NULL, NULL, N'syr', NULL, NULL, NULL, NULL, NULL, NULL, CAST(-2000.0000 AS Decimal(20, 4)), CAST(N'2021-06-13T13:57:04.8838599' AS DateTime2), CAST(N'2021-06-13T13:57:04.8838599' AS DateTime2), NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (132, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(-2000.0000 AS Decimal(20, 4)), CAST(N'2021-06-13T14:11:34.6994969' AS DateTime2), CAST(N'2021-06-13T14:11:34.6994969' AS DateTime2), NULL, NULL, NULL, 0, NULL, CAST(0.0000 AS Decimal(20, 4)))
SET IDENTITY_INSERT [dbo].[agents] OFF
GO
SET IDENTITY_INSERT [dbo].[banks] ON 

INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, N'bank3', N'+216-73-0988877', N'+249-099888', N'add', N'8776', N'no', CAST(N'2021-04-28T13:28:14.0079999' AS DateTime2), CAST(N'2021-05-25T10:26:45.1173873' AS DateTime2), 1, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (4, N'bank4', N'+971-6-8766', N'+967-099887', N'add', N'888776', N'no', CAST(N'2021-04-28T13:28:14.0079999' AS DateTime2), CAST(N'2021-06-03T13:32:40.0943404' AS DateTime2), 1, 2, 0)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (5, N'bank13', N'+966-3-0987766', N'+974-098887', N'address', N'18776', N'notes', CAST(N'2021-05-09T15:05:12.2215628' AS DateTime2), CAST(N'2021-05-26T15:07:05.8436694' AS DateTime2), 1, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (6, N'bank17', N'+966-3-8766555', N'+974-0987766', N'العنوان', N'09877', N'ملاحظات', CAST(N'2021-05-10T11:16:36.0665072' AS DateTime2), CAST(N'2021-05-25T10:09:19.7223109' AS DateTime2), 1, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (7, N'bank16', N'+965--887766', N'+965-09877', N'address', N'087767', N'notes', CAST(N'2021-05-10T11:16:38.4583116' AS DateTime2), CAST(N'2021-06-03T12:54:20.6853114' AS DateTime2), 1, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (9, N'bank10', N'+966-3-099888', N'+971-099887', N'العنوان', N'545466', N'', CAST(N'2021-05-16T14:32:27.3384234' AS DateTime2), CAST(N'2021-05-24T17:45:32.9247115' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (10, N'bank1', N'+966-1-87665', N'+968-0988', N'حلب', N'98776', N'', CAST(N'2021-05-16T14:40:42.1864615' AS DateTime2), CAST(N'2021-05-24T17:47:13.8362193' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (11, N'bank12', N'+963011655444', N'+9630998776', N'add', N'55566', N'', CAST(N'2021-05-16T14:48:45.8985163' AS DateTime2), CAST(N'2021-05-16T15:44:55.0331778' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (12, N'bank11', N'+96301143225667', N'+9630981344', N'', N'122', N'', CAST(N'2021-05-16T15:08:42.4233985' AS DateTime2), CAST(N'2021-05-16T15:45:15.4615853' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (13, N'bank13', N'+971-2-866554', N'+968-098777', N'add', N'218776', N'no', CAST(N'2021-05-16T15:27:06.5125659' AS DateTime2), CAST(N'2021-05-26T15:07:45.3361442' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (14, N'bank14', N'+965--65544', N'+966-876555', N'', N'123', N'', CAST(N'2021-05-16T15:32:13.7690779' AS DateTime2), CAST(N'2021-05-26T15:10:22.4475608' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (15, N'bank15', N'+965--66555', N'+971-765433', N'add', N'87665', N'no', CAST(N'2021-05-16T15:43:55.6199607' AS DateTime2), CAST(N'2021-05-26T15:10:40.1962319' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (17, N'البركة', N'+965--87766', N'+965-09887', N'العنوان', N'1235', N'ملاحظات', CAST(N'2021-05-26T12:03:13.9953010' AS DateTime2), CAST(N'2021-05-26T12:03:13.9953010' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (18, N'bank3', N'+965--877665', N'+968-09877', N'', N'8776', N'', CAST(N'2021-05-26T13:47:52.0867062' AS DateTime2), CAST(N'2021-05-26T13:47:52.0867062' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (19, N'banak4', N'+965--8776', N'+965-09887', N'', N'888776', N'', CAST(N'2021-05-26T13:49:27.8523016' AS DateTime2), CAST(N'2021-05-26T13:49:27.8523016' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (20, N'bank18', N'+965--87766', N'-098777', N'', N'098767', N'', CAST(N'2021-05-26T14:09:17.4874911' AS DateTime2), CAST(N'2021-05-26T14:09:17.4874911' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (21, N'bank14', N'+965--7666', N'+965-77665', N'address', N'888776', N'notes', CAST(N'2021-05-26T15:10:05.0939127' AS DateTime2), CAST(N'2021-05-26T15:10:05.0939127' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (22, N'fsdfsaf', N'+965--32123', N'+965-1323132', N'dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd', N'1321313', N'dddddddddddddddddddddddddddddddddddddddddd', CAST(N'2021-06-03T11:38:34.2288942' AS DateTime2), CAST(N'2021-06-03T11:38:34.2288942' AS DateTime2), 2, 2, 1)
SET IDENTITY_INSERT [dbo].[banks] OFF
GO
SET IDENTITY_INSERT [dbo].[bondes] ON 

INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (1, N'435034433pbo1', CAST(5000.0000 AS Decimal(20, 4)), CAST(N'2021-06-03T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 2, 2, CAST(N'2021-06-17T13:03:50.4688298' AS DateTime2), CAST(N'2021-06-17T13:03:50.4688298' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (2, N'435034433pbo1', CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-06-30T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 2, 2, CAST(N'2021-06-17T13:14:35.5182576' AS DateTime2), CAST(N'2021-06-17T13:14:35.5182576' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (3, N'435034433pbo1', CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-06-10T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 2, 2, CAST(N'2021-06-17T13:19:19.2353401' AS DateTime2), CAST(N'2021-06-17T13:19:19.2353401' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[bondes] OFF
GO
SET IDENTITY_INSERT [dbo].[branches] ON 

INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (1, N'm', N'رئيسي لايحذف', N'branch1main notdelete', N'e.mail.com', N'8766', N'+9630987665', CAST(N'2021-04-28T13:56:36.6368454' AS DateTime2), CAST(N'2021-05-12T13:08:37.1866734' AS DateTime2), 2, 2, N'no', 0, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (5, N'm', N'main', N'branch1', N'e.mail.com', N'8766', N'+9630987665', CAST(N'2021-04-28T13:56:36.6368454' AS DateTime2), CAST(N'2021-05-10T11:57:26.2689264' AS DateTime2), 2, 2, N'no', 0, 0, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (6, N'bb', N'الفرع1', N'العنوان', N'e@mail.com', N'+966-1-987766', N'+966-099989', CAST(N'2021-04-28T13:58:46.6741732' AS DateTime2), CAST(N'2021-05-26T14:54:38.6425033' AS DateTime2), 2, 2, N'no', 0, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (7, N'b', N'b', N'b', N'e@mail.com', N'+971-2-8877767', N'+968-098776', CAST(N'2021-04-28T14:28:45.0514781' AS DateTime2), CAST(N'2021-05-25T11:29:02.1717322' AS DateTime2), 2, 2, N'b', 17, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (9, N'storecode1', N'store1', N'add', N'r@mail.com', N'+971-4-76554', N'+968-9876765', CAST(N'2021-04-28T14:34:13.0321229' AS DateTime2), CAST(N'2021-05-25T10:53:59.7006202' AS DateTime2), 2, 2, N'notes', 18, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (10, N'storecode2', N'store2', N'add2', N'a@gmail.com', N'+965--98766', N'+971-9877656', CAST(N'2021-04-28T14:34:44.1086508' AS DateTime2), CAST(N'2021-05-25T11:02:04.2111354' AS DateTime2), 2, 2, N'notes', 7, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (11, N'code', N'store', N's', N'', N'+966-1-765554', N'+968-988777', CAST(N'2021-04-28T14:38:45.1942312' AS DateTime2), CAST(N'2021-05-25T11:17:30.3241488' AS DateTime2), 2, 2, N'', 43, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (17, N'372698422', N'branch2', N'address2', N'branch2@mail.com', N'+950419887766', N'+9610987766', CAST(N'2021-05-04T12:10:29.3035552' AS DateTime2), CAST(N'2021-05-11T12:12:44.4625666' AS DateTime2), 2, 2, N'notes2', 36, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (18, N'435034433', N'branch3', N'address3', N'b3@gmail.net', N'+966-1-87666', N'+971-09877', CAST(N'2021-05-04T12:19:42.5883467' AS DateTime2), CAST(N'2021-06-02T11:17:56.4710913' AS DateTime2), 2, 2, N'لا تحذف هذا الفرع من فضلك', 18, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (21, N'161621441', N'store 8', N'add', N'', N'+966-1-765443', N'+968-987766', CAST(N'2021-05-05T10:53:23.3028023' AS DateTime2), CAST(N'2021-06-05T12:28:39.0970182' AS DateTime2), 2, 2, N'', 41, 0, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (24, N'499482074', N'name', N'address', N'name@mail.org', N'+96301166554', N'+963098876', CAST(N'2021-05-09T11:16:44.8946924' AS DateTime2), CAST(N'2021-05-24T15:35:57.2909428' AS DateTime2), 2, 2, N'notes', 17, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (25, N'852874438', N'الفرع1', N'address', N'name@mail.org', N'+96301166554', N'+963098876', CAST(N'2021-05-09T11:21:57.3755900' AS DateTime2), CAST(N'2021-05-09T11:21:57.3755900' AS DateTime2), 2, 2, N'ملاحظات', 21, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (26, N'313858917', N'الفرع2', N'address', N'name@mail.org', N'+96301166554', N'+963098876', CAST(N'2021-05-09T11:29:12.0381335' AS DateTime2), CAST(N'2021-05-09T11:29:12.0381335' AS DateTime2), 2, 2, N'notes', 24, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (35, N'140201381', N'store3', N'add', N'e@mail.org', N'+96301198777655', N'+9630998754', CAST(N'2021-05-09T13:27:03.1667976' AS DateTime2), CAST(N'2021-05-09T13:31:36.8005914' AS DateTime2), 2, 2, N'notes', 18, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (36, N'957369264', N'1تجربة', N'العنوان', N'x@outlook.net', N'+965--876655', N'+965-088777', CAST(N'2021-05-10T11:18:08.6905919' AS DateTime2), CAST(N'2021-05-27T12:21:29.6763980' AS DateTime2), 2, 2, N'ملاحظات', 17, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (37, N'90755923', N'تجربة المخازن', N'', N'', N'', N'+968-098766', CAST(N'2021-05-10T11:18:29.2384937' AS DateTime2), CAST(N'2021-05-25T11:15:53.7564429' AS DateTime2), 2, 2, N'', 47, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (38, N'364610534', N'name', N'add', N'', N'', N'+968-09887', CAST(N'2021-05-10T12:14:18.6239200' AS DateTime2), CAST(N'2021-05-26T14:56:08.1811321' AS DateTime2), 2, 2, N'', 24, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (39, N'code', N'name', N'', N'name@mail.com', N'+968--86665', N'+968-0988777', CAST(N'2021-05-10T12:50:29.5901982' AS DateTime2), CAST(N'2021-05-24T18:04:29.9978312' AS DateTime2), 2, 2, N'', 6, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (41, N'0987', N'nameeeeee', N'address', N'name@mail.com', N'+966-2-087766', N'+971-09877', CAST(N'2021-05-10T14:23:09.0016428' AS DateTime2), CAST(N'2021-05-24T18:05:36.8450774' AS DateTime2), 2, 2, N'notes', 6, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (42, N'765', N'n', N'', N'', N'', N'+968-099887', CAST(N'2021-05-10T14:29:03.9890822' AS DateTime2), CAST(N'2021-05-26T15:41:10.0198581' AS DateTime2), 2, 2, N'', 6, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (43, N'7265', N'm', N'', N'', N'+966-1-988777', N'+971-099877', CAST(N'2021-05-11T10:40:06.9978618' AS DateTime2), CAST(N'2021-05-26T14:59:43.3137578' AS DateTime2), 2, 2, N'', 6, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (44, N'123', N'x', N'', N'', N'', N'+963098877', CAST(N'2021-05-11T10:47:01.3533689' AS DateTime2), CAST(N'2021-05-11T10:47:01.3533689' AS DateTime2), 2, 2, N'', 17, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (45, N'a', N'a', N'', N'a@mail.org', N'+966-2-766554', N'+968-098877', CAST(N'2021-05-11T11:34:50.3573739' AS DateTime2), CAST(N'2021-05-25T11:29:54.1164664' AS DateTime2), 2, 2, N'notes', 17, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (46, N'test', N'test', N'', N'test@mail.net', N'', N'+96309876', CAST(N'2021-05-11T11:44:03.4902263' AS DateTime2), CAST(N'2021-05-11T11:44:03.4902263' AS DateTime2), 2, 2, N'', 17, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (47, N'x', N'x', N'', N'x@gmail.com', N'', N'+963988766', CAST(N'2021-05-11T11:51:17.1567935' AS DateTime2), CAST(N'2021-05-26T15:41:41.4339883' AS DateTime2), 2, 2, N'', 26, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (48, N'xx', N'xxx', N'', N'xx@mail.net', N'', N'+963098765', CAST(N'2021-05-11T11:54:14.6668564' AS DateTime2), CAST(N'2021-05-11T11:54:14.6668564' AS DateTime2), 2, 2, N'', 24, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (49, N'xxx', N'xxx', N'', N'xxx@hotmail.com', N'', N'+9630912345', CAST(N'2021-05-11T12:02:08.0625661' AS DateTime2), CAST(N'2021-05-11T12:02:08.0625661' AS DateTime2), 2, 2, N'', 36, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (50, N'xxxx', N'xxxx', N'', N'', N'', N'+96309124566', CAST(N'2021-05-11T12:10:55.8637520' AS DateTime2), CAST(N'2021-06-03T16:36:02.2566894' AS DateTime2), 2, 2, N'', 25, 0, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (51, N'aaa', N'aaa', N'عنوان', N'', N'', N'+9610432578-444444444', CAST(N'2021-05-11T12:26:45.4588686' AS DateTime2), CAST(N'2021-05-24T15:33:41.2916043' AS DateTime2), 2, 2, N'ملاحظات', 26, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (53, N'aa', N'aa', N'', N'', N'', N'+96309165326', CAST(N'2021-05-11T13:15:03.3891353' AS DateTime2), CAST(N'2021-05-11T13:15:03.3891353' AS DateTime2), 2, 2, N'', 6, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (54, N'aaa', N'aaa', N'', N'', N'', N'+963098765', CAST(N'2021-05-11T13:28:03.7843571' AS DateTime2), CAST(N'2021-05-11T13:28:03.7843571' AS DateTime2), 2, 2, N'', 26, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (55, N'xxxa', N'x', N'add', N'', N'', N'+963098765', CAST(N'2021-05-11T13:28:57.5157592' AS DateTime2), CAST(N'2021-05-11T13:29:53.5699580' AS DateTime2), 2, 2, N'ملاحظات', 25, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (56, N'A32', N'فرع السالمية', N'', N'', N'', N'+963876444232', CAST(N'2021-05-12T12:58:54.7980898' AS DateTime2), CAST(N'2021-05-24T15:34:48.9686362' AS DateTime2), 2, 2, N'', 25, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (57, N'9876', N'name', N'', N'', N'', N'+968-098877', CAST(N'2021-05-16T16:21:22.4534991' AS DateTime2), CAST(N'2021-05-25T11:16:05.7848725' AS DateTime2), 2, 2, N'notes', 24, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (58, N'aa', N'mm', N'aalep', N'ew@EFEF.KUM', N'+90-216-2343245324', N'+967-553333', CAST(N'2021-05-18T04:58:04.9488485' AS DateTime2), CAST(N'2021-05-24T15:35:40.7771007' AS DateTime2), 2, 2, N'', 6, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (59, N'ب4', N'لبلبلبلبلب', N'', N'', N'', N'-456555555', CAST(N'2021-05-24T15:32:16.4265307' AS DateTime2), CAST(N'2021-05-24T17:57:48.4387666' AS DateTime2), 2, 2, N'', 6, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (60, N'codeee', N'name', N'address', N'', N'', N'+965-0988', CAST(N'2021-05-24T17:56:59.8985625' AS DateTime2), CAST(N'2021-05-24T18:00:04.9345996' AS DateTime2), 2, 2, N'notes', 7, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (61, N'coden', N'nnn', N'note', N'y@gmail.com', N'+971-3-76555', N'+968-98777', CAST(N'2021-05-25T11:18:21.6979692' AS DateTime2), CAST(N'2021-05-25T11:18:21.6979692' AS DateTime2), 2, 2, N'note', 17, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (62, N'1code', N'x', N'add', N'x@m.com', N'+965--87666', N'+965-09898', CAST(N'2021-05-26T10:50:45.9803001' AS DateTime2), CAST(N'2021-05-26T10:50:45.9803001' AS DateTime2), 2, 2, N'note', 6, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (63, N'new code1', N'new branch1', N'address1', N'b1@hotmail.com', N'+965--876555', N'+966-0988766', CAST(N'2021-05-26T11:52:57.1344849' AS DateTime2), CAST(N'2021-05-26T11:52:57.1344849' AS DateTime2), 2, 2, N'notes', 24, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (64, N'new code1', N'new store1', N'address', N's1@outlook.com', N'+966-2-665444', N'+966-09887', CAST(N'2021-05-26T11:55:16.5083298' AS DateTime2), CAST(N'2021-05-26T11:55:16.5083298' AS DateTime2), 2, 2, N'notes', 18, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (65, N'شيفرة1', N'الفرع1', N'العنوان', N'e@mail.com', N'+965--9877666', N'+966-098877', CAST(N'2021-05-26T14:54:10.4072027' AS DateTime2), CAST(N'2021-05-26T14:54:10.4072027' AS DateTime2), 2, 2, N'no', 7, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (66, N'bb', N'b', N'b', N'', N'+965--77766', N'+965-0988', CAST(N'2021-05-27T12:22:01.8617095' AS DateTime2), CAST(N'2021-06-05T13:15:41.7928748' AS DateTime2), 2, 2, N'b', 24, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (67, N'c', N'c', N'c', N'', N'+965--5554', N'-8776', CAST(N'2021-05-27T12:22:28.3549357' AS DateTime2), CAST(N'2021-05-27T12:22:28.3549357' AS DateTime2), 2, 2, N'', 25, 1, N's')
SET IDENTITY_INSERT [dbo].[branches] OFF
GO
SET IDENTITY_INSERT [dbo].[cards] ON 

INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1, N'visa', N'local card', CAST(N'2021-06-10T11:11:01.6275135' AS DateTime2), CAST(N'2021-06-12T14:01:34.2780865' AS DateTime2), 2, 2, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'master', N'local card', CAST(N'2021-06-10T11:11:02.0124857' AS DateTime2), CAST(N'2021-06-10T11:11:02.0124857' AS DateTime2), 2, 2, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, N'visa2', N'local card', CAST(N'2021-06-10T11:11:02.0703335' AS DateTime2), CAST(N'2021-06-12T13:55:34.3405362' AS DateTime2), 2, 2, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (4, N'master2', N'local card', CAST(N'2021-06-10T11:11:02.0902800' AS DateTime2), CAST(N'2021-06-10T11:11:02.0902800' AS DateTime2), 2, 2, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (5, N'visa', N'local card', CAST(N'2021-06-10T11:11:11.6108384' AS DateTime2), CAST(N'2021-06-10T11:11:11.6108384' AS DateTime2), 2, 2, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (6, N'master', N'local card', CAST(N'2021-06-10T11:11:11.8103054' AS DateTime2), CAST(N'2021-06-10T11:11:11.8103054' AS DateTime2), 2, 2, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (7, N'visa1', N'local card', CAST(N'2021-06-10T11:11:11.8242699' AS DateTime2), CAST(N'2021-06-10T11:11:11.8242699' AS DateTime2), 2, 2, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (8, N'master2', N'local card', CAST(N'2021-06-10T11:11:11.8641610' AS DateTime2), CAST(N'2021-06-12T13:40:39.0582482' AS DateTime2), 2, 2, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (12, N'visa', N'local card', CAST(N'2021-06-12T13:57:47.6645244' AS DateTime2), CAST(N'2021-06-12T13:57:47.6645244' AS DateTime2), 2, 2, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (13, N'visa', N'local     ', CAST(N'2021-06-12T13:57:51.9936821' AS DateTime2), CAST(N'2021-06-12T14:01:58.5069090' AS DateTime2), 2, 2, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (14, N'visa', N'local card', CAST(N'2021-06-12T13:58:29.1175640' AS DateTime2), CAST(N'2021-06-12T13:58:29.1175640' AS DateTime2), 2, 2, 1)
SET IDENTITY_INSERT [dbo].[cards] OFF
GO
SET IDENTITY_INSERT [dbo].[cashTransfer] ON 

INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (1, N'd', 53, 22, NULL, NULL, N'435034433pb0', CAST(N'2021-06-02T12:58:06.4082669' AS DateTime2), CAST(N'2021-06-02T12:58:06.4082669' AS DateTime2), CAST(12.0000 AS Decimal(20, 4)), 2, 2, N'note', NULL, NULL, NULL, N'bn', NULL, NULL, NULL, 4, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (2, N'p', 53, 23, NULL, NULL, N'435034433rb0', CAST(N'2021-06-02T13:00:19.2596608' AS DateTime2), CAST(N'2021-06-02T13:00:19.2596608' AS DateTime2), CAST(10.0000 AS Decimal(20, 4)), 2, 2, N'note2', NULL, NULL, NULL, N'bn', NULL, NULL, NULL, 6, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (3, N'd', 53, 26, NULL, NULL, N'435034433pb1', CAST(N'2021-06-02T13:02:04.7713968' AS DateTime2), CAST(N'2021-06-02T13:02:04.7713968' AS DateTime2), CAST(10.0000 AS Decimal(20, 4)), 2, 2, N'note', NULL, NULL, NULL, N'bn', NULL, NULL, NULL, 7, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (4, N'p', 53, 28, NULL, NULL, N'435034433rb1', CAST(N'2021-06-02T13:03:48.3171932' AS DateTime2), CAST(N'2021-06-02T13:03:48.3171932' AS DateTime2), CAST(500.0000 AS Decimal(20, 4)), 2, 2, N'note4', NULL, NULL, NULL, N'bn', NULL, NULL, NULL, 5, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (5, N'p', 53, 25, NULL, NULL, N'435034433rb2', CAST(N'2021-06-02T13:26:10.7460811' AS DateTime2), CAST(N'2021-06-02T13:26:10.7460811' AS DateTime2), CAST(1500.0000 AS Decimal(20, 4)), 2, 2, N'notes5', 53, NULL, NULL, N'bn', NULL, N'123', NULL, 7, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (6, N'd', 53, 22, NULL, NULL, N'435034433pb2', CAST(N'2021-06-02T17:41:24.1289838' AS DateTime2), CAST(N'2021-06-02T17:41:24.1289838' AS DateTime2), CAST(3333.0000 AS Decimal(20, 4)), 2, 2, N'fdfdfdfdfdf', 53, NULL, NULL, N'bn', NULL, N'534424', NULL, 5, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (7, N'd', 53, 22, NULL, NULL, N'435034433pb0', CAST(N'2021-06-03T10:08:18.7562273' AS DateTime2), CAST(N'2021-06-03T10:08:18.7562273' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'no', 53, NULL, NULL, N'bn', NULL, N'1', NULL, 5, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (10, N'p', 59, NULL, NULL, NULL, N'435034433pp1', CAST(N'2021-06-05T11:56:14.5684708' AS DateTime2), CAST(N'2021-06-06T11:41:39.6853040' AS DateTime2), CAST(1500.0000 AS Decimal(20, 4)), 2, 2, N'notes3', 53, 1, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (11, N'd', 54, NULL, NULL, NULL, N'435034433dp0', CAST(N'2021-06-05T11:56:14.6153362' AS DateTime2), CAST(N'2021-06-06T11:14:02.0012321' AS DateTime2), CAST(1500.0000 AS Decimal(20, 4)), 2, 2, N'notes3', 53, 0, 10, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (12, N'p', 59, NULL, NULL, NULL, N'435034433pp3', CAST(N'2021-06-05T14:11:34.7067146' AS DateTime2), CAST(N'2021-06-06T11:14:31.7757263' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'notes5', 53, 0, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (13, N'd', 54, NULL, NULL, NULL, N'435034433dp2', CAST(N'2021-06-05T14:11:34.7575468' AS DateTime2), CAST(N'2021-06-06T11:14:31.7637298' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'notes5', 53, 0, 12, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (14, N'p', 54, NULL, NULL, NULL, N'435034433pp3', CAST(N'2021-06-06T11:01:54.9717177' AS DateTime2), CAST(N'2021-06-06T11:15:47.1088559' AS DateTime2), CAST(10000.0000 AS Decimal(20, 4)), 2, 2, N'notes5', 53, 0, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (15, N'd', 53, NULL, NULL, NULL, N'435034433dp3', CAST(N'2021-06-06T11:01:55.3965855' AS DateTime2), CAST(N'2021-06-06T11:15:47.1258127' AS DateTime2), CAST(10000.0000 AS Decimal(20, 4)), 2, 2, N'notes5', 53, 0, 14, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (16, N'p', 53, NULL, NULL, NULL, N'435034433pp4', CAST(N'2021-06-06T12:26:56.3456272' AS DateTime2), CAST(N'2021-06-06T12:26:56.3456272' AS DateTime2), CAST(300.0000 AS Decimal(20, 4)), 2, 2, N'notes6', 53, 0, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (17, N'd', 54, NULL, NULL, NULL, N'435034433dp4', CAST(N'2021-06-06T12:26:56.7946118' AS DateTime2), CAST(N'2021-06-06T12:26:56.7946118' AS DateTime2), CAST(300.0000 AS Decimal(20, 4)), 2, 2, NULL, 53, 0, 16, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (18, N'p', 53, NULL, NULL, NULL, N'435034433pp5', CAST(N'2021-06-07T12:12:55.9301842' AS DateTime2), CAST(N'2021-06-07T12:12:55.9301842' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'notes', 53, 1, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (19, N'd', 54, NULL, NULL, NULL, N'435034433dp5', CAST(N'2021-06-07T12:12:56.4981838' AS DateTime2), CAST(N'2021-06-07T14:01:55.5090363' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, NULL, 53, 1, 18, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (20, N'p', 54, NULL, NULL, NULL, N'435034433pp6', CAST(N'2021-06-07T12:19:26.3303548' AS DateTime2), CAST(N'2021-06-07T13:50:03.9438874' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'notes2', 53, 1, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (21, N'd', 59, NULL, NULL, NULL, N'435034433dp6', CAST(N'2021-06-07T12:19:26.3782280' AS DateTime2), CAST(N'2021-06-07T12:19:26.3782280' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, NULL, 53, 0, 20, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (26, N'p', 60, NULL, NULL, NULL, N'435034433pp7', CAST(N'2021-06-07T13:05:47.8388200' AS DateTime2), CAST(N'2021-06-07T13:05:47.8388200' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'notes44', 53, 0, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (27, N'd', 53, NULL, NULL, NULL, N'435034433dp7', CAST(N'2021-06-07T13:05:47.8745362' AS DateTime2), CAST(N'2021-06-07T13:05:47.8745362' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, NULL, 53, 1, 26, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (28, N'p', 53, NULL, NULL, NULL, N'435034433pp8', CAST(N'2021-06-07T14:05:17.1641323' AS DateTime2), CAST(N'2021-06-07T14:05:17.1641323' AS DateTime2), CAST(20000.0000 AS Decimal(20, 4)), 2, 2, N'no', 53, 1, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (29, N'd', 54, NULL, NULL, NULL, N'435034433dp8', CAST(N'2021-06-07T14:05:17.2266497' AS DateTime2), CAST(N'2021-06-07T14:05:54.4975744' AS DateTime2), CAST(20000.0000 AS Decimal(20, 4)), 2, 2, NULL, 53, 1, 28, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (30, N'p', 53, NULL, NULL, NULL, N'435034433pp9', CAST(N'2021-06-07T14:11:27.3262229' AS DateTime2), CAST(N'2021-06-07T14:11:27.3262229' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'no', 53, 1, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (31, N'd', 54, NULL, NULL, NULL, N'435034433dp9', CAST(N'2021-06-07T14:11:27.4199512' AS DateTime2), CAST(N'2021-06-07T14:12:07.0675262' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, NULL, 53, 1, 30, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (32, N'p', 53, NULL, NULL, NULL, N'435034433pp10', CAST(N'2021-06-07T14:13:13.6511532' AS DateTime2), CAST(N'2021-06-07T14:13:13.6511532' AS DateTime2), CAST(500000.0000 AS Decimal(20, 4)), 2, 2, N'no', 53, 1, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (33, N'd', 54, NULL, NULL, NULL, N'435034433dp10', CAST(N'2021-06-07T14:13:13.6823958' AS DateTime2), CAST(N'2021-06-07T14:13:13.6823958' AS DateTime2), CAST(500000.0000 AS Decimal(20, 4)), 2, 2, NULL, 53, 0, 32, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (34, N'p', 53, NULL, NULL, NULL, N'435034433pp11', CAST(N'2021-06-08T12:58:16.8245285' AS DateTime2), CAST(N'2021-06-08T13:11:18.9135490' AS DateTime2), CAST(211.0000 AS Decimal(20, 4)), 2, 2, N'', 53, 1, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (35, N'd', 62, NULL, NULL, NULL, N'435034433pp1', CAST(N'2021-06-08T12:58:17.3561107' AS DateTime2), CAST(N'2021-06-08T13:11:18.9464579' AS DateTime2), CAST(211.0000 AS Decimal(20, 4)), 2, 2, N'', 53, 1, 34, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (36, N'p', 54, NULL, NULL, NULL, N'435034433pp12', CAST(N'2021-06-08T13:04:02.7825282' AS DateTime2), CAST(N'2021-06-08T13:27:08.8901201' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', 53, 1, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (37, N'd', 61, NULL, NULL, NULL, N'435034433pp1', CAST(N'2021-06-08T13:04:03.3091184' AS DateTime2), CAST(N'2021-06-08T14:04:00.5505665' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, NULL, 53, 1, 36, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (38, N'p', 60, NULL, NULL, NULL, N'435034433pp13', CAST(N'2021-06-08T13:09:49.2301884' AS DateTime2), CAST(N'2021-06-08T13:11:48.4386547' AS DateTime2), CAST(250.0000 AS Decimal(20, 4)), 2, 2, N'', 53, 0, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (39, N'd', 54, NULL, NULL, NULL, N'435034433pp1', CAST(N'2021-06-08T13:09:49.3319172' AS DateTime2), CAST(N'2021-06-08T13:57:26.6660593' AS DateTime2), CAST(250.0000 AS Decimal(20, 4)), 2, 2, N'', 53, 1, 38, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (42, N'd', 53, NULL, 30, NULL, N'435034433dv1', CAST(N'2021-06-10T11:13:17.2790403' AS DateTime2), CAST(N'2021-06-10T11:13:17.2790403' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'notes', NULL, NULL, NULL, N'v', NULL, N'10', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (43, N'd', 53, 23, NULL, NULL, N'435034433du1', CAST(N'2021-06-10T11:22:24.3282762' AS DateTime2), CAST(N'2021-06-10T11:22:24.3282762' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'notes', NULL, NULL, NULL, N'u', NULL, N'', NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (44, N'd', 53, NULL, 50, NULL, N'435034433dv2', CAST(N'2021-06-10T11:30:04.9035741' AS DateTime2), CAST(N'2021-06-10T11:30:04.9035741' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'notes', NULL, NULL, NULL, N'v', NULL, N'100', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (45, N'd', 53, NULL, 57, NULL, N'435034433dv3', CAST(N'2021-06-10T11:30:56.2653326' AS DateTime2), CAST(N'2021-06-10T11:30:56.2653326' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 1, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (46, N'd', 53, NULL, 50, NULL, N'435034433pv1', CAST(N'2021-06-10T12:04:52.0653823' AS DateTime2), CAST(N'2021-06-10T12:04:52.0653823' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 4, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (47, N'p', 53, NULL, 76, NULL, N'435034433pv1', CAST(N'2021-06-10T12:14:51.5796932' AS DateTime2), CAST(N'2021-06-10T12:14:51.5796932' AS DateTime2), CAST(120.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 5, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (48, N'p', 53, NULL, 41, NULL, N'435034433pv2', CAST(N'2021-06-10T12:20:48.7714137' AS DateTime2), CAST(N'2021-06-10T12:20:48.7714137' AS DateTime2), CAST(150.0000 AS Decimal(20, 4)), 2, 2, N'notesss', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 5, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (49, N'p', 53, NULL, 25, NULL, N'435034433pc1', CAST(N'2021-06-10T12:27:42.2432044' AS DateTime2), CAST(N'2021-06-10T12:27:42.2432044' AS DateTime2), CAST(1200.0000 AS Decimal(20, 4)), 2, 2, N'noote', NULL, NULL, NULL, N'c', NULL, N'12', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (50, N'p', 53, 27, NULL, NULL, N'435034433pu1', CAST(N'2021-06-10T12:28:38.5774575' AS DateTime2), CAST(N'2021-06-10T12:28:38.5774575' AS DateTime2), CAST(15000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, N'15', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (51, N'p', 53, 23, NULL, NULL, N'435034433ps1', CAST(N'2021-06-10T12:29:25.3300006' AS DateTime2), CAST(N'2021-06-10T12:29:25.3300006' AS DateTime2), CAST(50000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N's', NULL, N'', NULL, NULL, N'card', 4, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (52, N'p', 53, NULL, NULL, NULL, N'435034433pe1', CAST(N'2021-06-10T12:30:04.4744011' AS DateTime2), CAST(N'2021-06-10T12:30:04.4744011' AS DateTime2), CAST(100.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'e', NULL, N'', NULL, NULL, N'card', 8, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (53, N'p', 53, NULL, NULL, NULL, N'435034433pm1', CAST(N'2021-06-10T12:30:41.1224749' AS DateTime2), CAST(N'2021-06-10T12:30:41.1224749' AS DateTime2), CAST(200.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'm', NULL, N'', NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (54, N'p', 53, 22, NULL, NULL, N'435034433pbn4', CAST(N'2021-06-12T10:27:53.5230834' AS DateTime2), CAST(N'2021-06-12T10:27:53.5230834' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'nooote', NULL, NULL, NULL, N'bn', NULL, N'12', NULL, 10, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (55, N'd', 53, 23, NULL, NULL, N'435034433dbn5', CAST(N'2021-06-12T10:29:43.4346844' AS DateTime2), CAST(N'2021-06-12T10:29:43.4346844' AS DateTime2), CAST(1500.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'5', NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (56, N'd', 53, 24, NULL, NULL, N'435034433dbn6', CAST(N'2021-06-12T10:32:58.2446305' AS DateTime2), CAST(N'2021-06-12T10:32:58.2446305' AS DateTime2), CAST(2500.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'123', NULL, 11, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (57, N'p', 53, 25, NULL, NULL, N'435034433pbn5', CAST(N'2021-06-12T10:34:25.9588951' AS DateTime2), CAST(N'2021-06-12T10:34:25.9588951' AS DateTime2), CAST(1500.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'147', NULL, 10, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (58, N'p', 53, 26, NULL, NULL, N'435034433pbn6', CAST(N'2021-06-12T10:36:00.3658523' AS DateTime2), CAST(N'2021-06-12T10:36:00.3658523' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'bn', NULL, N'159', NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (59, N'p', 53, 24, NULL, NULL, N'435034433pbn7', CAST(N'2021-06-12T10:38:04.3130940' AS DateTime2), CAST(N'2021-06-12T10:38:04.3130940' AS DateTime2), CAST(3000.0000 AS Decimal(20, 4)), 2, 2, N'nottte', NULL, NULL, NULL, N'bn', NULL, N'753', NULL, 11, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (60, N'd', 53, 25, NULL, NULL, N'435034433dbn7', CAST(N'2021-06-12T10:41:37.3711887' AS DateTime2), CAST(N'2021-06-12T10:41:37.3711887' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'852', NULL, 10, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (61, N'p', 53, 27, NULL, NULL, N'435034433pbn8', CAST(N'2021-06-12T10:45:58.3873624' AS DateTime2), CAST(N'2021-06-12T10:45:58.3873624' AS DateTime2), CAST(1500.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'963', NULL, 10, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (62, N'p', 53, 27, NULL, NULL, N'435034433pbn9', CAST(N'2021-06-12T10:47:59.8231854' AS DateTime2), CAST(N'2021-06-12T10:47:59.8231854' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'987', NULL, 10, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (63, N'p', 53, 25, NULL, NULL, N'435034433pbn10', CAST(N'2021-06-12T10:48:47.9829376' AS DateTime2), CAST(N'2021-06-12T10:48:47.9829376' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'753', NULL, 12, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (64, N'd', 53, 25, NULL, NULL, N'435034433dbn8', CAST(N'2021-06-12T10:49:14.4030581' AS DateTime2), CAST(N'2021-06-12T10:49:14.4030581' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'258', NULL, 10, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (65, N'd', 53, 25, NULL, NULL, N'435034433dbn9', CAST(N'2021-06-12T10:51:00.6514303' AS DateTime2), CAST(N'2021-06-12T10:51:00.6514303' AS DateTime2), CAST(2500.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'753', NULL, 12, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (66, N'p', 53, 27, NULL, NULL, N'435034433pbn11', CAST(N'2021-06-12T10:52:28.4132951' AS DateTime2), CAST(N'2021-06-12T10:52:28.4132951' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'852', NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (67, N'd', 53, 25, NULL, NULL, N'435034433dbn10', CAST(N'2021-06-12T10:53:45.4189672' AS DateTime2), CAST(N'2021-06-12T10:53:45.4189672' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'654', NULL, 10, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (68, N'p', 53, 22, NULL, NULL, N'435034433pbn12', CAST(N'2021-06-12T10:55:37.6937126' AS DateTime2), CAST(N'2021-06-12T10:55:37.6937126' AS DateTime2), CAST(4000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'654', NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (69, N'p', 53, 27, NULL, NULL, N'435034433pbn13', CAST(N'2021-06-12T10:57:52.9001517' AS DateTime2), CAST(N'2021-06-12T10:57:52.9001517' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'852', NULL, 7, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (70, N'd', 53, 26, NULL, NULL, N'435034433dbn11', CAST(N'2021-06-12T11:01:00.0693759' AS DateTime2), CAST(N'2021-06-12T11:01:00.0693759' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'248', NULL, 10, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (71, N'd', 53, 25, NULL, NULL, N'435034433dbn12', CAST(N'2021-06-12T11:06:01.9229501' AS DateTime2), CAST(N'2021-06-12T11:06:01.9229501' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'987', NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (72, N'd', 53, NULL, 44, NULL, N'435034433pv3', CAST(N'2021-06-12T13:38:43.9350229' AS DateTime2), CAST(N'2021-06-12T13:38:43.9350229' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'notes', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (73, N'd', 53, NULL, 25, NULL, N'435034433pc2', CAST(N'2021-06-12T13:52:13.0433662' AS DateTime2), CAST(N'2021-06-12T13:52:13.0433662' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'125', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (74, N'd', 53, 24, NULL, NULL, N'435034433pu2', CAST(N'2021-06-12T13:53:50.9506280' AS DateTime2), CAST(N'2021-06-12T13:53:50.9506280' AS DateTime2), CAST(500.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, N'10', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (75, N'd', 53, NULL, 33, NULL, N'435034433dc2', CAST(N'2021-06-12T13:55:29.9256845' AS DateTime2), CAST(N'2021-06-12T13:55:29.9256845' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'notes', NULL, NULL, NULL, N'c', NULL, N'150', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (76, N'd', 53, NULL, NULL, NULL, N'435034433dm1', CAST(N'2021-06-12T13:57:37.4141873' AS DateTime2), CAST(N'2021-06-12T13:57:37.4141873' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'm', NULL, N'', NULL, NULL, N'card', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (77, N'p', 53, 22, NULL, NULL, N'435034433pbn14', CAST(N'2021-06-12T19:57:50.3162476' AS DateTime2), CAST(N'2021-06-12T19:57:50.3162476' AS DateTime2), CAST(22330.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'222', NULL, 5, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (78, N'd', 53, NULL, 26, NULL, N'435034433du3', CAST(N'2021-06-13T12:05:09.7487011' AS DateTime2), CAST(N'2021-06-13T12:05:09.7487011' AS DateTime2), CAST(1200.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'u', NULL, N'', NULL, NULL, N'card', 5, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (79, N'd', 53, 24, NULL, NULL, N'435034433du4', CAST(N'2021-06-13T12:08:49.6608008' AS DateTime2), CAST(N'2021-06-13T12:08:49.6608008' AS DateTime2), CAST(200.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'u', NULL, N'', NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (80, N'd', 53, NULL, 44, NULL, N'435034433dv6', CAST(N'2021-06-13T12:33:04.9323591' AS DateTime2), CAST(N'2021-06-13T12:33:04.9323591' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 6, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (81, N'd', 53, NULL, 76, NULL, N'435034433dv7', CAST(N'2021-06-13T12:55:11.9678684' AS DateTime2), CAST(N'2021-06-13T12:55:11.9678684' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (82, N'd', 53, NULL, 76, NULL, N'435034433dv8', CAST(N'2021-06-13T13:04:42.3320041' AS DateTime2), CAST(N'2021-06-13T13:04:42.3320041' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'note', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 5, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (83, N'd', 53, NULL, 76, NULL, N'435034433dv9', CAST(N'2021-06-13T13:09:25.6465259' AS DateTime2), CAST(N'2021-06-13T13:09:25.6465259' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'100', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (84, N'd', 53, NULL, 76, NULL, N'435034433dv10', CAST(N'2021-06-13T13:12:12.4877105' AS DateTime2), CAST(N'2021-06-13T13:12:12.4877105' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'100', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (85, N'd', 53, NULL, 76, NULL, N'435034433dv11', CAST(N'2021-06-13T13:18:28.6505687' AS DateTime2), CAST(N'2021-06-13T13:18:28.6505687' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'102', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (86, N'd', 53, NULL, 76, NULL, N'435034433dv12', CAST(N'2021-06-13T13:21:20.0904684' AS DateTime2), CAST(N'2021-06-13T13:21:20.0904684' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'100', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (87, N'd', 53, NULL, 76, NULL, N'435034433dv13', CAST(N'2021-06-13T13:28:29.3629243' AS DateTime2), CAST(N'2021-06-13T13:28:29.3629243' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 5, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (88, N'd', 53, NULL, 76, NULL, N'435034433dv14', CAST(N'2021-06-13T13:31:41.5054693' AS DateTime2), CAST(N'2021-06-13T13:31:41.5054693' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'12', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (89, N'd', 53, NULL, 76, NULL, N'435034433dv15', CAST(N'2021-06-13T13:35:40.3352993' AS DateTime2), CAST(N'2021-06-13T13:35:40.3352993' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'10', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (90, N'd', 53, NULL, 76, NULL, N'435034433dv16', CAST(N'2021-06-13T13:38:28.2605845' AS DateTime2), CAST(N'2021-06-13T13:38:28.2605845' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'12', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (91, N'd', 53, NULL, 76, NULL, N'435034433dv17', CAST(N'2021-06-13T13:51:40.0697924' AS DateTime2), CAST(N'2021-06-13T13:51:40.0697924' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'12', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (92, N'd', 53, NULL, 76, NULL, N'435034433dv18', CAST(N'2021-06-13T13:53:49.8011415' AS DateTime2), CAST(N'2021-06-13T13:53:49.8011415' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 5, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (93, N'd', 53, NULL, 76, NULL, N'435034433dv19', CAST(N'2021-06-13T13:55:36.8072383' AS DateTime2), CAST(N'2021-06-13T13:55:36.8072383' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'12', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (94, N'd', 53, NULL, 76, NULL, N'435034433dv20', CAST(N'2021-06-13T13:57:02.9649871' AS DateTime2), CAST(N'2021-06-13T13:57:02.9649871' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 5, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (95, N'd', 53, NULL, 22, NULL, N'435034433dv21', CAST(N'2021-06-13T14:11:29.6809044' AS DateTime2), CAST(N'2021-06-13T14:11:29.6809044' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'75', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (96, N'd', 53, NULL, 76, NULL, N'435034433dv22', CAST(N'2021-06-13T14:19:42.2717953' AS DateTime2), CAST(N'2021-06-13T14:19:42.2717953' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'105', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (97, N'd', 53, NULL, 22, NULL, N'435034433dv23', CAST(N'2021-06-13T14:23:31.7992000' AS DateTime2), CAST(N'2021-06-13T14:23:31.7992000' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 6, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (98, N'd', 53, NULL, 21, NULL, N'435034433dc3', CAST(N'2021-06-13T14:25:07.0219298' AS DateTime2), CAST(N'2021-06-13T14:25:07.0219298' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'258', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (99, N'd', 53, NULL, 18, NULL, N'435034433dc4', CAST(N'2021-06-13T14:33:05.4876754' AS DateTime2), CAST(N'2021-06-13T14:33:05.4876754' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'', NULL, NULL, N'card', 2, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (100, N'p', 53, NULL, 57, NULL, N'435034433pv3', CAST(N'2021-06-16T12:30:20.2455820' AS DateTime2), CAST(N'2021-06-16T12:30:20.2455820' AS DateTime2), CAST(50100.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'123351651', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (101, N'p', 53, 23, NULL, NULL, N'435034433pu2', CAST(N'2021-06-16T12:31:42.8479624' AS DateTime2), CAST(N'2021-06-16T12:31:42.8479624' AS DateTime2), CAST(10500.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (102, N'p', 53, NULL, 30, NULL, N'435034433pv4', CAST(N'2021-06-17T12:13:15.5930644' AS DateTime2), CAST(N'2021-06-17T12:13:15.5930644' AS DateTime2), CAST(100000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (103, N'p', 53, NULL, 30, NULL, N'435034433pv5', CAST(N'2021-06-17T12:14:52.1089019' AS DateTime2), CAST(N'2021-06-17T12:14:52.1089019' AS DateTime2), CAST(100000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (104, N'p', 53, NULL, 30, NULL, N'435034433pv6', CAST(N'2021-06-17T12:19:39.9480679' AS DateTime2), CAST(N'2021-06-17T12:19:39.9480679' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (105, N'p', 53, NULL, 30, NULL, N'435034433pv7', CAST(N'2021-06-17T12:21:47.5180597' AS DateTime2), CAST(N'2021-06-17T12:21:47.5180597' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (106, N'p', 53, NULL, 30, NULL, N'435034433pv8', CAST(N'2021-06-17T12:23:32.0259249' AS DateTime2), CAST(N'2021-06-17T12:23:32.0259249' AS DateTime2), CAST(3000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (107, N'p', 53, NULL, 30, NULL, N'435034433pv9', CAST(N'2021-06-17T12:24:46.1439056' AS DateTime2), CAST(N'2021-06-17T12:24:46.1439056' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
GO
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (108, N'p', 53, NULL, 30, NULL, N'435034433pv10', CAST(N'2021-06-17T13:01:29.2113474' AS DateTime2), CAST(N'2021-06-17T13:01:29.2113474' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (109, N'p', 53, NULL, 30, NULL, N'435034433pv11', CAST(N'2021-06-17T13:03:50.4219961' AS DateTime2), CAST(N'2021-06-17T13:03:50.4219961' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'435034433pbo1', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (110, N'p', 53, NULL, 30, NULL, N'435034433pv12', CAST(N'2021-06-17T13:14:35.4870153' AS DateTime2), CAST(N'2021-06-17T13:14:35.4870153' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'435034433pbo1', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (111, N'p', 53, NULL, 30, NULL, N'435034433pv13', CAST(N'2021-06-17T13:19:19.2014313' AS DateTime2), CAST(N'2021-06-17T13:19:19.2014313' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'435034433pbo1', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (112, N'p', 53, NULL, 30, NULL, N'435034433pv14', CAST(N'2021-06-17T14:13:17.6090036' AS DateTime2), CAST(N'2021-06-17T14:13:17.6090036' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'147', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (113, N'p', 53, NULL, 30, NULL, N'435034433pv15', CAST(N'2021-06-17T14:20:20.6821117' AS DateTime2), CAST(N'2021-06-17T14:20:20.6821117' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'435034433pbo1', NULL, NULL, N'doc', NULL, NULL)
SET IDENTITY_INSERT [dbo].[cashTransfer] OFF
GO
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (20, N'CD3055', N'غذائية', N'details', N'cba6ef02fcbd47ba36115f8f64248594.jpg', 1, CAST(2.0000 AS Decimal(20, 4)), 0, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-06-09T10:24:54.6679428' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (21, N'BR655', N'معلبات', N'details', N'90f607ba318fce94cafe1571617d1b6c.jpg', 1, CAST(2.0000 AS Decimal(20, 4)), 20, CAST(N'2021-05-02T11:54:18.4411860' AS DateTime2), CAST(N'2021-05-26T15:26:46.8253839' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (22, N'BP487', N'البان', N'details', N'77d0501bbf02ad459f88ab4b7531b14d.jpg', 1, CAST(20.0000 AS Decimal(20, 4)), 53, CAST(N'2021-05-02T11:54:48.2868209' AS DateTime2), CAST(N'2021-05-25T14:07:56.8592506' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (23, N'PoS35', N'POS', N'POS', N'e8a124154d6b4436a9d47827fcd24d4d.jpg', 1, CAST(20.0000 AS Decimal(20, 4)), 138, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-06-12T17:10:18.5857786' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (24, N'P1R418', N'خضار', N'تفاصيل الخضار', N'3f85263e6e6e21f6a4057fab7f956f1b.jpg', 1, CAST(20.0000 AS Decimal(20, 4)), 20, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-26T15:48:47.6884990' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (25, N'CD1235', N'مرتديلا هنا', N'details', N'16008f81a32dddded32b87f4a2cd9ca7.jpg', 1, CAST(2.0000 AS Decimal(20, 4)), 21, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-06-09T10:25:05.0495562' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (26, N'BR486', N'شهية', N'details', N'37de6228ecdaf854ca17e0abd1062763.jpg', 1, CAST(2.0000 AS Decimal(20, 4)), 21, CAST(N'2021-05-02T11:54:18.4411860' AS DateTime2), CAST(N'2021-05-27T11:11:54.2199040' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (27, N'BP731', N'باركود', N'details', N'15c139cdb9cb2a3e6788751f02626b1e.jpg', 1, CAST(20.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-02T11:54:48.2868209' AS DateTime2), CAST(N'2021-05-26T15:32:30.8008166' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (53, N'CD305', N'لبنة', N'details', N'cdf738f67f30988eabbed1143f759633.png', 1, CAST(2.0000 AS Decimal(20, 4)), 22, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-25T13:55:21.2302576' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (55, N'BP487', N'لبن', N'details', N'/pic/barcode-printer/barcode-printer.png', 1, CAST(20.0000 AS Decimal(20, 4)), 22, CAST(N'2021-05-02T11:54:48.2868209' AS DateTime2), CAST(N'2021-05-02T11:54:48.2868209' AS DateTime2), 2, 2, N'notes')
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (57, N'PR418', N'غنم', N'Programs', N'/pic/Programs/laundry-casheir-program.png', 1, CAST(20.0000 AS Decimal(20, 4)), 55, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-25T13:58:10.8105815' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (58, N'CD235', N'بقر', N'details', N'1af86a79362aee3d07adaa181d3b4530.png', 1, CAST(2.0000 AS Decimal(20, 4)), 55, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-25T13:58:25.3849661' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (110, N'1224', N'لبنة نوع 1', N'', N'85c2efa2d5814dd19fb1e2b4c70adec5.png', 1, CAST(12.0000 AS Decimal(20, 4)), 53, CAST(N'2021-05-24T13:08:24.8976041' AS DateTime2), CAST(N'2021-05-25T13:58:53.6966608' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (118, N'code', N'لبنة نوع 2', N'', N'fc3befd3360d499b82738e558d8f0fea.jpg', 1, CAST(20.0000 AS Decimal(20, 4)), 53, CAST(N'2021-05-24T15:22:06.6661376' AS DateTime2), CAST(N'2021-05-25T13:51:00.2412758' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (133, N'clothes code', N'clothes', N'details', N'1e2cd78289952bab4bbace2c9726e8a3.jpg', 1, CAST(10.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-26T12:43:49.3933266' AS DateTime2), CAST(N'2021-05-27T11:27:01.2793296' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (134, N'girl clothes code', N'girl clothes', N'girl details', N'3bc1cd3e00f33e503422147e91ad9be9.jpg', 1, CAST(12.0000 AS Decimal(20, 4)), 133, CAST(N'2021-05-26T12:46:32.4397581' AS DateTime2), CAST(N'2021-05-26T12:46:32.4397581' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (136, N'boy code', N'boy clothes', N'boy details', N'2f22def6b3b770f8de6e23c65b720bca.jpg', 1, CAST(0.0000 AS Decimal(20, 4)), 133, CAST(N'2021-05-26T13:00:09.5475839' AS DateTime2), CAST(N'2021-05-26T13:00:09.5475839' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (137, N'cooode', N'delta', N'تفاصيل', N'1d314df616dec441168be8e479000a35.jpg', 1, CAST(0.0000 AS Decimal(20, 4)), 21, CAST(N'2021-05-26T15:50:52.5279501' AS DateTime2), CAST(N'2021-05-27T11:28:01.3518788' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (138, N'eleccode', N'electronics', N'details', N'd0c7a95d715f9ae73262cb19628fc4aa.jpg', 1, CAST(12.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-27T11:30:55.3770834' AS DateTime2), CAST(N'2021-05-27T11:34:41.6252150' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (139, N'Stationerycode', N'قرطاسية', N'تفاصيل', N'0899ba7263de0bf8d9941034cb77c75f.jpg', 1, CAST(12.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-27T11:38:34.6600710' AS DateTime2), CAST(N'2021-05-29T10:16:20.6984776' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (140, N'penCode', N'pen', N'pen details', N'ead1d735e39e62e79a5ffe8a29b9602a.png', 1, CAST(0.0000 AS Decimal(20, 4)), 139, CAST(N'2021-05-29T10:18:05.3161236' AS DateTime2), CAST(N'2021-05-29T10:18:05.3161236' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (141, N'bookCode', N'book', N'book details', N'88d3f4f4f2dcf8f5d39b4443746fed38.jpg', 1, CAST(2.0000 AS Decimal(20, 4)), 139, CAST(N'2021-05-29T10:20:47.4188562' AS DateTime2), CAST(N'2021-05-29T10:20:47.4188562' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (142, N'eraserCode', N'eraser', N'eraser datails', N'f94459182d73b07b6e0709cf361c3b41.jpg', 1, CAST(1.0000 AS Decimal(20, 4)), 139, CAST(N'2021-05-29T10:34:28.7728203' AS DateTime2), CAST(N'2021-05-29T10:34:28.7728203' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (143, N'fff', N'hello', N'', N'8264e3f9419763fc14c88a4ce05f9d3d.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-29T10:49:16.5205627' AS DateTime2), CAST(N'2021-05-31T14:18:51.2039972' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (145, N'fffs', N'efg', N'', N'8264e3f9419763fc14c88a4ce05f9d3d.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T13:54:54.7474183' AS DateTime2), CAST(N'2021-05-31T13:54:54.7474183' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (146, N'fffss', N'ewr', N'', N'ea1da6ce2355c295fe5fedfc2567bbee.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T13:55:01.4784201' AS DateTime2), CAST(N'2021-05-31T14:10:30.8599099' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (147, N'fffsss', N'fsd', N'', N'8264e3f9419763fc14c88a4ce05f9d3d.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T13:55:05.1815492' AS DateTime2), CAST(N'2021-05-31T13:55:05.1815492' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (148, N'fffssss', N'vch', N'', N'603e11b6233ab9ef7cd6c6cabe9fd28a.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T13:55:09.8111385' AS DateTime2), CAST(N'2021-05-31T14:10:05.7560365' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (149, N'fffsssss', N'gre', N'', N'2abca48ae62be008a974627fdb64f82b.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T13:55:12.4521080' AS DateTime2), CAST(N'2021-05-31T14:10:10.5731555' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (150, N'sfffsssss', N'jrt', N'', N'546b5b50332217713c09ac101dcc276e.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T13:55:16.0933395' AS DateTime2), CAST(N'2021-05-31T14:10:21.8829132' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (151, N'ssfffsssss', N'kyt', N'', N'8264e3f9419763fc14c88a4ce05f9d3d.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T13:55:19.7754937' AS DateTime2), CAST(N'2021-05-31T13:55:19.7754937' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (152, N'ssfffssssss', N'mty', N'', N'9216d2fde1469338340b25caa7e631b4.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T13:55:29.0966003' AS DateTime2), CAST(N'2021-05-31T14:09:56.3182732' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (153, N'ssfffsssssss', N'zxe', N'', N'7900ec813b398fc899eb97069a97bc3a.jpg', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T13:55:34.8761149' AS DateTime2), CAST(N'2021-05-31T14:15:16.0702606' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (154, N'ssfffssssssss', N'ewr', N'', N'8264e3f9419763fc14c88a4ce05f9d3d.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T13:55:37.8930479' AS DateTime2), CAST(N'2021-05-31T13:55:37.8930479' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (155, N'sssfffssssssss', N'daw', N'', N'3c20e4c671fab8787871c8741e08473f.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T13:55:41.3677575' AS DateTime2), CAST(N'2021-05-31T14:12:05.8279672' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (156, N'sssfffsssssssss', N'jyt', N'', N'8264e3f9419763fc14c88a4ce05f9d3d.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T13:55:45.0170296' AS DateTime2), CAST(N'2021-05-31T13:55:45.0170296' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (157, N'sssfffssssssssx', N'ynn', N'', N'3c20e4c671fab8787871c8741e08473f.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T14:11:54.9480580' AS DateTime2), CAST(N'2021-05-31T14:11:54.9480580' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (158, N'PoS35x', N'POS', N'POS', N'e8a124154d6b4436a9d47827fcd24d4d.png', 1, CAST(20.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T14:12:39.7223318' AS DateTime2), CAST(N'2021-05-31T14:12:39.7223318' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (159, N'PoS35y', N'POS', N'POS', N'e8a124154d6b4436a9d47827fcd24d4d.png', 1, CAST(20.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T14:12:59.3887763' AS DateTime2), CAST(N'2021-05-31T14:12:59.3887763' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (160, N'ssfffssssssssssss', N'fff', N'', N'9db62000fb0ec17666f83e452333dda5.jpg', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T14:14:58.9789642' AS DateTime2), CAST(N'2021-05-31T14:18:04.5906530' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (161, N'assfffssssssssssss', N'fff', N'', NULL, 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-31T14:23:51.0119123' AS DateTime2), CAST(N'2021-05-31T14:23:51.0119123' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (162, N'test', N'test', N'', N'cace2752209d1b8797dc8823e276df6c.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-06-03T12:59:20.3578820' AS DateTime2), CAST(N'2021-06-03T12:59:20.3578820' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (163, N'test2', N'test2', N'', N'5296841c2476dd68590f01ba35636cba.jpg', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-06-03T13:00:36.2184951' AS DateTime2), CAST(N'2021-06-03T13:00:36.2184951' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (164, N'test3', N'test3', N'', N'4565ef9b30dd10c880ef10f747a76bef.png', 1, CAST(0.0000 AS Decimal(20, 4)), 0, CAST(N'2021-06-03T13:01:30.3252294' AS DateTime2), CAST(N'2021-06-03T13:01:30.3252294' AS DateTime2), 2, 2, NULL)
SET IDENTITY_INSERT [dbo].[categories] OFF
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

INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (1, N'+965')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (2, N'+966')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (3, N'+968')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (4, N'+971')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (5, N'+974')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (6, N'+973')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (7, N'+964')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (8, N'+961')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (9, N'+963')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (10, N'+967')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (11, N'+962')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (12, N'+213')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (13, N'+20')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (14, N'+216')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (15, N'+249')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (16, N'+212')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (17, N'+218')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (18, N'+252')
INSERT [dbo].[countriesCodes] ([countryId], [code]) VALUES (19, N'+90')
SET IDENTITY_INSERT [dbo].[countriesCodes] OFF
GO
SET IDENTITY_INSERT [dbo].[coupons] ON 

INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (1, N'name', N'code', 1, N'نسبة مئوية', CAST(10.0000 AS Decimal(20, 4)), CAST(N'2021-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-30T00:00:00.0000000' AS DateTime2), N'notes', 5, NULL, CAST(10.0000 AS Decimal(20, 4)), CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-05-27T13:55:54.0446584' AS DateTime2), CAST(N'2021-05-30T13:18:29.9878204' AS DateTime2), 2, 2, N'barcode')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (2, N'name', N'code', 1, N'1', CAST(10.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-30T00:00:00.0000000' AS DateTime2), N'', 10, NULL, CAST(10.0000 AS Decimal(20, 4)), CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T11:21:06.3396934' AS DateTime2), CAST(N'2021-05-29T11:21:06.3396934' AS DateTime2), 2, 2, N'barcode')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (4, N'name3', N'code3', 1, N'1', CAST(10.0000 AS Decimal(20, 4)), CAST(N'2021-05-15T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-27T00:00:00.0000000' AS DateTime2), N'note3', 10, NULL, CAST(100.0000 AS Decimal(20, 4)), CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T11:45:32.7356234' AS DateTime2), CAST(N'2021-05-30T15:20:58.1692990' AS DateTime2), 2, 2, N'barcode3')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (5, N'name3', N'code3', 1, N'value', CAST(10.0000 AS Decimal(20, 4)), NULL, NULL, N'note3', 10, NULL, CAST(100.0000 AS Decimal(20, 4)), CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T11:47:13.9738061' AS DateTime2), CAST(N'2021-05-29T11:47:13.9738061' AS DateTime2), 2, 2, N'barcode3')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (6, N'name4', N'code4', 1, N'value', CAST(20.0000 AS Decimal(20, 4)), NULL, NULL, N'note4', 20, NULL, CAST(200.0000 AS Decimal(20, 4)), CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T11:54:42.2103640' AS DateTime2), CAST(N'2021-05-29T11:54:42.2103640' AS DateTime2), 2, 2, N'barcode4')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (7, N'name5', N'code5', 1, N'1', CAST(20.0000 AS Decimal(20, 4)), CAST(N'2021-06-03T00:00:00.0000000' AS DateTime2), CAST(N'2021-06-17T00:00:00.0000000' AS DateTime2), N'notes5', 20, 2, CAST(200.0000 AS Decimal(20, 4)), CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T11:58:41.3460644' AS DateTime2), CAST(N'2021-06-01T13:09:36.6089982' AS DateTime2), 2, 2, N'barcode5')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (8, N'name6', N'code6', 1, N'1', CAST(50.0000 AS Decimal(20, 4)), CAST(N'2021-01-05T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-05T00:00:00.0000000' AS DateTime2), N'notes6', 20, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(100.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T12:00:33.8318850' AS DateTime2), CAST(N'2021-06-17T14:02:15.7511280' AS DateTime2), 2, 2, N'b100')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (9, N'name7', N'code7', 1, N'2', CAST(10.0000 AS Decimal(20, 4)), CAST(N'2021-05-21T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-24T00:00:00.0000000' AS DateTime2), N'notes7', 20, 2, CAST(70.0000 AS Decimal(20, 4)), CAST(700.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T12:02:34.6844079' AS DateTime2), CAST(N'2021-05-30T15:23:14.0506876' AS DateTime2), 2, 2, N'barcode7')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (10, N'name8', N'code8', 1, N'Value', NULL, NULL, NULL, N'', 20, 2, NULL, NULL, CAST(N'2021-05-29T12:45:41.1408623' AS DateTime2), CAST(N'2021-05-29T12:45:41.1408623' AS DateTime2), 2, 2, N'barcode8')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (11, N'name9', N'code9', 1, N'نسبة مئوية', CAST(20.0000 AS Decimal(20, 4)), CAST(N'2021-05-08T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-21T00:00:00.0000000' AS DateTime2), N'notes9', 20, 2, CAST(1000.0000 AS Decimal(20, 4)), CAST(10000.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T12:55:53.7601107' AS DateTime2), CAST(N'2021-05-30T15:17:26.5094905' AS DateTime2), 2, 2, N'barcode9')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (12, N'name10', N'code10', 1, N'Value', CAST(25.0000 AS Decimal(20, 4)), NULL, NULL, N'code10', 50, 2, CAST(500.0000 AS Decimal(20, 4)), CAST(5000.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T13:07:33.1176025' AS DateTime2), CAST(N'2021-05-29T13:07:33.1176025' AS DateTime2), 2, 2, N'barcode10')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (13, N'name11', N'code11', 1, N'1', CAST(20.0000 AS Decimal(20, 4)), CAST(N'2021-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-01T00:00:00.0000000' AS DateTime2), N'code11', 70, 2, CAST(700.0000 AS Decimal(20, 4)), CAST(7000.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T13:08:52.4632889' AS DateTime2), CAST(N'2021-06-01T13:10:51.5855448' AS DateTime2), 2, 2, N'barcode11')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (14, N'name12', N'code12', 1, N'Value', CAST(500.0000 AS Decimal(20, 4)), NULL, NULL, N'notes12', 5, 1, CAST(500.0000 AS Decimal(20, 4)), CAST(5000.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T13:11:53.4072827' AS DateTime2), CAST(N'2021-05-29T13:11:53.4072827' AS DateTime2), 2, 2, N'barcode12')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (15, N'name13', N'code13', 1, N'Value', CAST(500.0000 AS Decimal(20, 4)), CAST(N'2021-05-22T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-31T00:00:00.0000000' AS DateTime2), N'notes13', 10, 1, CAST(100.0000 AS Decimal(20, 4)), CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T13:16:04.7960447' AS DateTime2), CAST(N'2021-05-29T13:16:04.7960447' AS DateTime2), 2, 2, N'barcode13')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (16, N'name14', N'code14', 0, N'Rate', CAST(20.0000 AS Decimal(20, 4)), CAST(N'2021-05-08T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-30T00:00:00.0000000' AS DateTime2), N'notes14', 30, 3, CAST(300.0000 AS Decimal(20, 4)), CAST(3000.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T13:20:11.2355317' AS DateTime2), CAST(N'2021-05-29T13:20:11.2355317' AS DateTime2), 2, 2, N'barcode14')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (17, N'name15', N'code15', 1, N'Value', CAST(200.0000 AS Decimal(20, 4)), CAST(N'2021-05-15T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-31T00:00:00.0000000' AS DateTime2), N'', 10, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-05-29T13:31:53.7434522' AS DateTime2), CAST(N'2021-05-29T13:31:53.7434522' AS DateTime2), 2, 2, N'barcode15')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (22, N'y', N'y', 1, N'نسبة مئوية', CAST(10.0000 AS Decimal(20, 4)), CAST(N'2021-05-06T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-26T00:00:00.0000000' AS DateTime2), N'y', 15, NULL, CAST(10.0000 AS Decimal(20, 4)), CAST(100.0000 AS Decimal(20, 4)), CAST(N'2021-05-30T11:59:18.6454155' AS DateTime2), CAST(N'2021-05-30T11:59:18.6454155' AS DateTime2), 2, 2, N'y')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (23, N'name20', N'code20', 1, N'نسبة مئوية', CAST(10.0000 AS Decimal(20, 4)), CAST(N'2021-05-20T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-24T00:00:00.0000000' AS DateTime2), N'note3', 10, NULL, CAST(10.0000 AS Decimal(20, 4)), CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-05-30T12:06:08.1017245' AS DateTime2), CAST(N'2021-05-30T12:06:08.1017245' AS DateTime2), 2, 2, N'barcode20')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (24, N'name21', N'code21', 0, N'2', CAST(21.0000 AS Decimal(20, 4)), CAST(N'2021-05-21T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-31T00:00:00.0000000' AS DateTime2), N'notes21', 21, NULL, CAST(21.0000 AS Decimal(20, 4)), CAST(210.0000 AS Decimal(20, 4)), CAST(N'2021-05-30T15:28:32.2517760' AS DateTime2), CAST(N'2021-05-30T15:28:32.2517760' AS DateTime2), 2, 2, N'barcode21')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (25, N'c', N'Dis100', 0, N'1', CAST(50.0000 AS Decimal(20, 4)), CAST(N'2021-06-17T00:00:00.0000000' AS DateTime2), CAST(N'2021-06-22T00:00:00.0000000' AS DateTime2), N'', 50, NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(10000.0000 AS Decimal(20, 4)), CAST(N'2021-06-16T16:35:50.9664407' AS DateTime2), CAST(N'2021-06-16T16:35:50.9664407' AS DateTime2), 2, 2, N'100')
SET IDENTITY_INSERT [dbo].[coupons] OFF
GO
SET IDENTITY_INSERT [dbo].[docImages] ON 

INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (1, NULL, N'12', N'627d6a1f66c1fac85a86621cb06481c8.jpg', N'invoices', NULL, CAST(N'2021-06-10T13:44:56.2226726' AS DateTime2), CAST(N'2021-06-10T13:44:56.2226726' AS DateTime2), 2, 2, 49)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (2, NULL, N'12', N'a53acbf0f7a7a10ffc5d332c5fae812f.jpg', N'cashTransfer', NULL, CAST(N'2021-06-10T13:47:55.1243598' AS DateTime2), CAST(N'2021-06-10T13:47:55.1243598' AS DateTime2), 2, 2, 49)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (3, NULL, N'12', N'136927f52363fd588e0f400a420d4c9a.png', N'cashTransfer', NULL, CAST(N'2021-06-10T13:48:06.8854000' AS DateTime2), CAST(N'2021-06-10T13:48:06.8854000' AS DateTime2), 2, 2, 49)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (4, NULL, NULL, N'fea6552b3a61ac3561cb7631b9ec6f37.jpg', N'cashTransfer', NULL, CAST(N'2021-06-10T13:50:35.7258192' AS DateTime2), CAST(N'2021-06-10T13:50:35.7258192' AS DateTime2), 2, 2, 1)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (5, NULL, NULL, N'ddeac1f37b408bb9855ae105eabe904d.jfif', N'cashTransfer', NULL, CAST(N'2021-06-10T13:50:55.8370808' AS DateTime2), CAST(N'2021-06-10T13:50:55.8370808' AS DateTime2), 2, 2, 1)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (6, NULL, NULL, N'a6ebb12cb112dbdb7bae50bf809b8282.png', N'cashTransfer', NULL, CAST(N'2021-06-12T14:13:24.9278545' AS DateTime2), CAST(N'2021-06-12T14:13:24.9278545' AS DateTime2), 2, 2, 0)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (7, NULL, NULL, N'460b804e1670c3031ab412beb9245b0f.jfif', N'cashTransfer', NULL, CAST(N'2021-06-12T14:13:36.7951564' AS DateTime2), CAST(N'2021-06-12T14:13:36.7951564' AS DateTime2), 2, 2, 0)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (8, NULL, N'storecode1_PI_10', N'31fee3b62bd6e4f879bc55e8d966c149.png', N'invoices', NULL, CAST(N'2021-06-12T23:18:13.4881103' AS DateTime2), CAST(N'2021-06-12T23:18:13.4881103' AS DateTime2), 2, 2, 16)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (9, NULL, N'storecode1_PI_10', N'c85e0c120b140694c41a3753dd1ef8c8.jpg', N'invoices', NULL, CAST(N'2021-06-12T23:18:37.5057860' AS DateTime2), CAST(N'2021-06-12T23:18:37.5057860' AS DateTime2), 2, 2, 16)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (10, NULL, N'storecode1_PI_10', N'e15ab95700f9c87e46e3b0d2ef95d47d.jpg', N'invoices', NULL, CAST(N'2021-06-12T23:18:58.8908839' AS DateTime2), CAST(N'2021-06-12T23:18:58.8908839' AS DateTime2), 2, 2, 16)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (11, NULL, N'storecode1_PI_10', N'a56b576c1cd3b4401ed1ee7292aa9759.png', N'invoices', NULL, CAST(N'2021-06-13T10:18:26.0565627' AS DateTime2), CAST(N'2021-06-13T10:18:26.0565627' AS DateTime2), 2, 2, 16)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (12, NULL, N'123', N'87f259537e0812f86a9306937b3f8581.jpg', N'cashTransfer', NULL, CAST(N'2021-06-13T11:06:03.7347887' AS DateTime2), CAST(N'2021-06-13T11:06:03.7347887' AS DateTime2), 2, 2, 5)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (14, NULL, NULL, NULL, N'cashTransfer', NULL, CAST(N'2021-06-13T12:49:18.8490064' AS DateTime2), CAST(N'2021-06-13T12:49:18.8490064' AS DateTime2), 2, 2, 0)
SET IDENTITY_INSERT [dbo].[docImages] OFF
GO
SET IDENTITY_INSERT [dbo].[invoices] ON 

INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (1, N'0987_PI_1', 41, 2, N'p', N'1', NULL, CAST(120.0000 AS Decimal(20, 4)), CAST(120.0000 AS Decimal(20, 4)), NULL, NULL, NULL, CAST(N'2021-06-06' AS Date), CAST(N'2021-06-06T16:49:26.0092081' AS DateTime2), 2, NULL, NULL, CAST(N'16:49:26.0092081' AS Time), N'', N'', NULL, 41, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (2, N'0987_PI_1', 41, 2, N'pbd', N'1', NULL, CAST(120.0000 AS Decimal(20, 4)), CAST(120.0000 AS Decimal(20, 4)), NULL, NULL, NULL, CAST(N'2021-06-06' AS Date), CAST(N'2021-06-06T17:04:01.7897248' AS DateTime2), 2, 1, NULL, CAST(N'17:04:01.7897248' AS Time), N'', N'', NULL, 41, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (3, N'0987_PI_1', 41, 2, N'pbd', N'1', NULL, CAST(120.0000 AS Decimal(20, 4)), CAST(120.0000 AS Decimal(20, 4)), NULL, NULL, NULL, CAST(N'2021-06-06' AS Date), CAST(N'2021-06-06T17:04:12.3020588' AS DateTime2), 2, 1, NULL, CAST(N'17:04:12.3020588' AS Time), N'', N'', NULL, 41, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (4, N'0987_PI_1', 41, 2, N'pbd', N'-1', NULL, CAST(120.0000 AS Decimal(20, 4)), CAST(120.0000 AS Decimal(20, 4)), NULL, NULL, NULL, CAST(N'2021-06-06' AS Date), CAST(N'2021-06-12T16:50:47.2771750' AS DateTime2), 2, 1, NULL, CAST(N'17:04:56.1018556' AS Time), N'', N'', NULL, 41, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (5, N'313858917_PI_2', 26, 2, N'p', N'1', NULL, CAST(1200.0000 AS Decimal(20, 4)), CAST(1200.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-06' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-07T12:15:33.4167232' AS DateTime2), 2, NULL, NULL, CAST(N'12:15:33.4167232' AS Time), N'', N'1651651561', CAST(N'2021-06-03T00:00:00.0000000' AS DateTime2), 26, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (6, N'313858917_PI_3', 26, 2, N'p', N'1', NULL, CAST(1000.0000 AS Decimal(20, 4)), CAST(1000.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-09' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-07T12:26:17.0362379' AS DateTime2), 2, NULL, NULL, CAST(N'12:26:17.0362379' AS Time), N'', N'3434343', CAST(N'2021-06-02T00:00:00.0000000' AS DateTime2), 26, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (7, N'313858917_PI_4', 26, 2, N'p', N'1', CAST(10.0000 AS Decimal(20, 4)), CAST(4200.0000 AS Decimal(20, 4)), CAST(4190.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-08' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-07T12:27:49.0658992' AS DateTime2), 2, NULL, NULL, CAST(N'12:27:49.0658992' AS Time), N'', N'5955919', CAST(N'2021-06-07T00:00:00.0000000' AS DateTime2), 26, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (8, N'313858917_PI_5', 26, 2, N'p', N'1', CAST(10.0000 AS Decimal(20, 4)), CAST(1320.0000 AS Decimal(20, 4)), CAST(1310.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-08' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-07T12:28:27.1770641' AS DateTime2), 2, NULL, NULL, CAST(N'12:28:27.1770641' AS Time), N'', N'35434', CAST(N'2021-06-07T00:00:00.0000000' AS DateTime2), 26, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (9, N'313858917_PI_6', 26, 2, N'p', N'1', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-08' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-07T12:31:23.0894773' AS DateTime2), 2, NULL, NULL, CAST(N'12:31:23.0894773' AS Time), N'', N'6156161', CAST(N'2021-06-07T00:00:00.0000000' AS DateTime2), 26, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (10, N'313858917_PI_7', 26, 2, N'p', N'1', NULL, CAST(242.0000 AS Decimal(20, 4)), CAST(242.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-09' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-07T12:32:50.0932119' AS DateTime2), 2, NULL, NULL, CAST(N'12:32:50.0932119' AS Time), N'', N'4543', CAST(N'2021-06-18T00:00:00.0000000' AS DateTime2), 26, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (11, N'123_PI_8', 44, 2, N'pd', N'2', CAST(15.0000 AS Decimal(20, 4)), CAST(2740.0000 AS Decimal(20, 4)), CAST(2329.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-30' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-12T16:49:29.6556958' AS DateTime2), 2, NULL, NULL, CAST(N'12:35:09.8427910' AS Time), N'', N'9846515', CAST(N'2021-06-07T00:00:00.0000000' AS DateTime2), 44, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (12, N'0987_PI_1', 41, 2, N'pb', N'1', NULL, CAST(160.0000 AS Decimal(20, 4)), CAST(160.0000 AS Decimal(20, 4)), NULL, NULL, NULL, CAST(N'2021-06-10' AS Date), CAST(N'2021-06-10T13:37:43.8399063' AS DateTime2), 2, 1, NULL, CAST(N'13:37:43.8399063' AS Time), N'', N'', NULL, 41, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (13, N'313858917_PI_7', 26, 2, N'pbd', N'-1', NULL, CAST(242.0000 AS Decimal(20, 4)), CAST(242.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-09' AS Date), CAST(N'2021-06-12' AS Date), CAST(N'2021-06-12T15:51:11.9177991' AS DateTime2), 2, 10, NULL, CAST(N'15:51:11.9177991' AS Time), N'', N'4543', CAST(N'2021-06-18T00:00:00.0000000' AS DateTime2), 26, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (14, N'm_PI_9', 30, 2, N'p', N'-1', NULL, CAST(20000.0000 AS Decimal(20, 4)), CAST(19600.0000 AS Decimal(20, 4)), CAST(0.0000 AS Decimal(20, 4)), CAST(19600.0000 AS Decimal(20, 4)), CAST(N'2021-06-09' AS Date), CAST(N'2021-06-12' AS Date), CAST(N'2021-06-12T17:18:26.5011595' AS DateTime2), 2, NULL, NULL, CAST(N'17:18:26.5011595' AS Time), N'', N'54343434', NULL, 5, NULL, CAST(2.0000 AS Decimal(20, 4)), NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (15, N'storecode1_PI_10', 30, 2, N'p', N'2', CAST(2.0000 AS Decimal(20, 4)), CAST(124.0000 AS Decimal(20, 4)), CAST(119.0900 AS Decimal(20, 4)), CAST(0.0000 AS Decimal(20, 4)), CAST(119.0900 AS Decimal(20, 4)), CAST(N'2021-06-30' AS Date), CAST(N'2021-06-12' AS Date), CAST(N'2021-06-12T19:49:59.8854766' AS DateTime2), 2, NULL, NULL, CAST(N'19:49:59.8854766' AS Time), N'hjhjhj', N'22115555', CAST(N'2021-06-11T00:00:00.0000000' AS DateTime2), 9, NULL, CAST(2.0000 AS Decimal(20, 4)), NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (16, N'storecode1_PI_10', 30, 2, N'p', N'-1', NULL, CAST(135.0000 AS Decimal(20, 4)), CAST(132.3000 AS Decimal(20, 4)), CAST(0.0000 AS Decimal(20, 4)), CAST(132.3000 AS Decimal(20, 4)), CAST(N'2021-06-30' AS Date), CAST(N'2021-06-12' AS Date), CAST(N'2021-06-12T20:32:26.5066624' AS DateTime2), 2, NULL, NULL, CAST(N'20:32:26.5066624' AS Time), N'hjhjhgj', N'222333', CAST(N'2021-06-12T00:00:00.0000000' AS DateTime2), 9, NULL, CAST(2.0000 AS Decimal(20, 4)), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[items] ON 

INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (90, N'p11', N'Pos Touch Screen', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-06-09T10:46:26.6394130' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (91, N'test2', N'test22', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-06-12T17:05:50.1809615' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (93, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(0.0000 AS Decimal(20, 4)), 1, 1, 2, NULL, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-06-12T17:06:48.6756616' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (94, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (95, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (96, N'w', N'2', N'2', N'n', N'', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-06-12T10:18:59.6606157' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (97, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (98, N'test1', N'test1', N'test1', N'n', N'60f5fcf614d791d17ed1836e07f572d5.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-06-12T17:06:21.7147001' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (99, N'test2', N'test2', N'test2', N'n', N'e45a0ca43a89e1e5cb9e17130398cbfe.png', CAST(0.0000 AS Decimal(20, 4)), 1, 3, 4, NULL, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-06-12T17:07:04.6629390' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (101, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (102, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (103, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (104, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (105, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (106, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (107, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (108, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (109, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (110, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (111, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (112, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (113, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (114, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (115, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (116, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (117, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (118, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (119, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (120, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (121, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (122, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (123, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (124, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (125, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (126, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (127, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (128, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (129, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (130, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (131, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (132, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (133, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (134, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (135, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (136, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (137, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (138, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (139, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (140, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (141, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (142, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (143, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (144, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (145, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (146, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (147, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (148, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (149, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (150, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (151, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (152, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (153, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (154, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (155, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (156, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (157, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (158, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (159, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (160, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (161, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (162, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (163, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (164, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (165, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (166, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (167, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (168, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (169, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (170, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (171, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (172, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (173, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (174, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (175, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (176, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (177, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (178, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (179, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (180, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (181, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (182, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (183, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (184, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (185, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (186, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (187, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (188, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (189, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (190, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
GO
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (191, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (192, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (193, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (194, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (195, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (196, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (197, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (198, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (199, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (200, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (201, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (202, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (203, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (204, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (205, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (206, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (207, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (208, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (209, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (210, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (211, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (212, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (213, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (214, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (215, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (216, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (217, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (218, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (219, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (220, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (221, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (222, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (223, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (224, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (225, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (226, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (227, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (228, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (229, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (230, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (231, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (232, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (233, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (234, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (235, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (236, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (237, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (238, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (239, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (240, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (241, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (242, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (243, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (244, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (245, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (246, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (247, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (248, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (249, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (250, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (251, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (252, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (253, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (254, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (255, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (256, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (257, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (258, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (259, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (260, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (261, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (262, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (263, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (264, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (265, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (266, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (267, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (268, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (269, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (270, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (271, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (272, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (273, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (274, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (275, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (276, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (277, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (278, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (279, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (280, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (281, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (282, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (283, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (284, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (285, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (286, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (287, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (288, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (289, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (290, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
GO
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (291, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (292, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (293, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (294, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (295, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (296, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (297, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (298, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (299, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (300, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (301, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (302, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (303, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (304, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (305, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (306, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (307, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (308, N'test1', N'test1', N'test1', N'n', N'abefdb7c4c1a9c7c2e9b6bada63d622d.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, NULL, CAST(N'2021-05-29T14:07:11.9020426' AS DateTime2), CAST(N'2021-05-30T12:18:20.4159554' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (309, N'test2', N'test2', N'test2', N'n', N'85143bf64b0abc6f54340d8b84bb6b32.png', CAST(2.0000 AS Decimal(20, 4)), 1, 3, 4, 20, NULL, CAST(N'2021-05-29T14:07:31.0109457' AS DateTime2), CAST(N'2021-05-30T12:46:10.4846166' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (310, N'test4', N'test3', N'test3', N'n', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, NULL, CAST(N'2021-05-30T11:09:20.0450783' AS DateTime2), CAST(N'2021-05-30T12:46:21.5234512' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (311, N'222', N'222', N'222', N'n', N'f8a33e27581ea8951e50227d8f88cc42.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 21, NULL, CAST(N'2021-05-30T11:10:40.3685708' AS DateTime2), CAST(N'2021-05-30T12:48:27.0852469' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (312, N'233', N'222', N'222', N'n', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', CAST(2.0000 AS Decimal(20, 4)), 1, 2, 2, 20, NULL, CAST(N'2021-05-30T11:11:12.2300567' AS DateTime2), CAST(N'2021-05-30T12:46:33.9140512' AS DateTime2), 2, 2, 22, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (313, N'w', N'2', N'2', N'n', N'03c78974a814080b4dea8d6b3be9200b.png', CAST(2.0000 AS Decimal(20, 4)), 1, 20, 40, 20, 90, CAST(N'2021-05-30T11:12:16.0692333' AS DateTime2), CAST(N'2021-05-30T12:46:45.1795900' AS DateTime2), 2, 2, 5, 6)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (314, N'A23', N'Part', N'dddd', N'n', N'54b481299e43159c8b86a7b48abfac9a.png', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 93, CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), CAST(N'2021-05-30T12:55:31.5908317' AS DateTime2), 2, 2, 23, 22)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (315, N'148a', N'pen', N'', N'n', N'bea5a0d5b1fed8b6e177ab441d70c7d4.jpg', CAST(2.0000 AS Decimal(20, 4)), 1, 1, 2, 20, 107, CAST(N'2021-06-12T10:11:51.6069115' AS DateTime2), CAST(N'2021-06-12T10:14:21.0329317' AS DateTime2), 2, 2, 23, 22)
SET IDENTITY_INSERT [dbo].[items] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsProp] ON 

INSERT [dbo].[itemsProp] ([itemPropId], [propertyItemId], [itemId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (2, 9, 90, CAST(N'2021-06-10T13:56:07.8872860' AS DateTime2), CAST(N'2021-06-10T13:56:07.8872860' AS DateTime2), 2, 2)
SET IDENTITY_INSERT [dbo].[itemsProp] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsTransfer] ON 

INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (1, 4, 1, NULL, NULL, CAST(N'2021-06-06T16:49:26.5981371' AS DateTime2), CAST(N'2021-06-06T16:49:26.5981371' AS DateTime2), 2, 2, NULL, CAST(10.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (2, 4, 1, NULL, NULL, CAST(N'2021-06-06T16:49:26.6021259' AS DateTime2), CAST(N'2021-06-06T16:49:26.6021259' AS DateTime2), 2, 2, NULL, CAST(20.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (3, 4, 2, NULL, NULL, CAST(N'2021-06-06T17:04:01.8784892' AS DateTime2), CAST(N'2021-06-06T17:04:01.8784892' AS DateTime2), 2, 2, NULL, CAST(10.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (4, 4, 2, NULL, NULL, CAST(N'2021-06-06T17:04:01.8794867' AS DateTime2), CAST(N'2021-06-06T17:04:01.8794867' AS DateTime2), 2, 2, NULL, CAST(20.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (5, 4, 3, NULL, NULL, CAST(N'2021-06-06T17:04:12.3878275' AS DateTime2), CAST(N'2021-06-06T17:04:12.3878275' AS DateTime2), 2, 2, NULL, CAST(10.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (6, 4, 3, NULL, NULL, CAST(N'2021-06-06T17:04:12.3878275' AS DateTime2), CAST(N'2021-06-06T17:04:12.3878275' AS DateTime2), 2, 2, NULL, CAST(20.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (9, 4, 5, NULL, NULL, CAST(N'2021-06-07T12:15:33.7679079' AS DateTime2), CAST(N'2021-06-07T12:15:33.7679079' AS DateTime2), 2, 2, NULL, CAST(100.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (10, 4, 5, NULL, NULL, CAST(N'2021-06-07T12:15:33.7763676' AS DateTime2), CAST(N'2021-06-07T12:15:33.7763676' AS DateTime2), 2, 2, NULL, CAST(200.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (11, 2, 6, NULL, NULL, CAST(N'2021-06-07T12:26:17.1509321' AS DateTime2), CAST(N'2021-06-07T12:26:17.1509321' AS DateTime2), 2, 2, NULL, CAST(200.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (12, 2, 6, NULL, NULL, CAST(N'2021-06-07T12:26:17.1519304' AS DateTime2), CAST(N'2021-06-07T12:26:17.1519304' AS DateTime2), 2, 2, NULL, CAST(300.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (13, 2, 7, NULL, NULL, CAST(N'2021-06-07T12:27:49.1137716' AS DateTime2), CAST(N'2021-06-07T12:27:49.1137716' AS DateTime2), 2, 2, NULL, CAST(100.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (14, 2, 7, NULL, NULL, CAST(N'2021-06-07T12:27:49.1147688' AS DateTime2), CAST(N'2021-06-07T12:27:49.1147688' AS DateTime2), 2, 2, NULL, CAST(2000.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (15, 1, 8, NULL, NULL, CAST(N'2021-06-07T12:28:27.2618365' AS DateTime2), CAST(N'2021-06-07T12:28:27.2618365' AS DateTime2), 2, 2, NULL, CAST(100.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (16, 1, 8, NULL, NULL, CAST(N'2021-06-07T12:28:27.2618365' AS DateTime2), CAST(N'2021-06-07T12:28:27.2618365' AS DateTime2), 2, 2, NULL, CAST(1220.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (17, 2, 9, NULL, NULL, CAST(N'2021-06-07T12:31:23.1463252' AS DateTime2), CAST(N'2021-06-07T12:31:23.1463252' AS DateTime2), 2, 2, NULL, CAST(0.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (18, 1, 9, NULL, NULL, CAST(N'2021-06-07T12:31:23.1463252' AS DateTime2), CAST(N'2021-06-07T12:31:23.1463252' AS DateTime2), 2, 2, NULL, CAST(0.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (19, 2, 10, NULL, NULL, CAST(N'2021-06-07T12:32:50.1769871' AS DateTime2), CAST(N'2021-06-07T12:32:50.1769871' AS DateTime2), 2, 2, NULL, CAST(103.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (20, 1, 10, NULL, NULL, CAST(N'2021-06-07T12:32:50.1769871' AS DateTime2), CAST(N'2021-06-07T12:32:50.1769871' AS DateTime2), 2, 2, NULL, CAST(36.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (27, 4, 12, NULL, NULL, CAST(N'2021-06-10T13:37:44.0323933' AS DateTime2), CAST(N'2021-06-10T13:37:44.0323933' AS DateTime2), 2, 2, NULL, CAST(10.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (28, 6, 12, NULL, NULL, CAST(N'2021-06-10T13:37:44.0353845' AS DateTime2), CAST(N'2021-06-10T13:37:44.0353845' AS DateTime2), 2, 2, NULL, CAST(20.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (29, 2, 13, NULL, NULL, CAST(N'2021-06-12T15:51:12.5471165' AS DateTime2), CAST(N'2021-06-12T15:51:12.5471165' AS DateTime2), 2, 2, NULL, CAST(103.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (30, 1, 13, NULL, NULL, CAST(N'2021-06-12T15:51:12.5531016' AS DateTime2), CAST(N'2021-06-12T15:51:12.5531016' AS DateTime2), 2, 2, NULL, CAST(36.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (33, 5, 11, NULL, NULL, CAST(N'2021-06-12T16:49:29.7493965' AS DateTime2), CAST(N'2021-06-12T16:49:29.7493965' AS DateTime2), 2, 2, NULL, CAST(500.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (34, 2, 11, NULL, NULL, CAST(N'2021-06-12T16:49:29.7493965' AS DateTime2), CAST(N'2021-06-12T16:49:29.7493965' AS DateTime2), 2, 2, NULL, CAST(120.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (35, 4, 4, NULL, NULL, CAST(N'2021-06-12T16:50:47.3864914' AS DateTime2), CAST(N'2021-06-12T16:50:47.3864914' AS DateTime2), 2, 2, NULL, CAST(10.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (36, 4, 4, NULL, NULL, CAST(N'2021-06-12T16:50:47.3864914' AS DateTime2), CAST(N'2021-06-12T16:50:47.3864914' AS DateTime2), 2, 2, NULL, CAST(20.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (37, 10, 14, NULL, NULL, CAST(N'2021-06-12T17:18:26.5959058' AS DateTime2), CAST(N'2021-06-12T17:18:26.5959058' AS DateTime2), 2, 2, NULL, CAST(2000.0000 AS Decimal(20, 4)), 12)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (38, 1, 14, NULL, NULL, CAST(N'2021-06-12T17:18:26.5959058' AS DateTime2), CAST(N'2021-06-12T17:18:26.5959058' AS DateTime2), 2, 2, NULL, CAST(0.0000 AS Decimal(20, 4)), 15)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (39, 4, 15, NULL, NULL, CAST(N'2021-06-12T19:49:59.9732417' AS DateTime2), CAST(N'2021-06-12T19:49:59.9732417' AS DateTime2), 2, 2, NULL, CAST(10.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (40, 7, 15, NULL, NULL, CAST(N'2021-06-12T19:49:59.9742401' AS DateTime2), CAST(N'2021-06-12T19:49:59.9742401' AS DateTime2), 2, 2, NULL, CAST(12.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (41, 6, 16, NULL, NULL, CAST(N'2021-06-12T20:32:26.6024576' AS DateTime2), CAST(N'2021-06-12T20:32:26.6024576' AS DateTime2), 2, 2, NULL, CAST(10.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (42, 3, 16, NULL, NULL, CAST(N'2021-06-12T20:32:26.6034068' AS DateTime2), CAST(N'2021-06-12T20:32:26.6034068' AS DateTime2), 2, 2, NULL, CAST(25.0000 AS Decimal(20, 4)), 10)
SET IDENTITY_INSERT [dbo].[itemsTransfer] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsUnits] ON 

INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (1, 97, 19, CAST(1.0000 AS Decimal(20, 4)), 0, 0, CAST(650.0000 AS Decimal(20, 4)), N'0782257122602200', CAST(N'2021-06-01T15:52:29.1049959' AS DateTime2), CAST(N'2021-06-02T12:18:57.4354338' AS DateTime2), 2, 2, 22, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (2, 97, 18, CAST(1.0000 AS Decimal(20, 4)), 0, 0, CAST(2333.0000 AS Decimal(20, 4)), N'20782344295001', CAST(N'2021-06-02T12:18:32.8647140' AS DateTime2), CAST(N'2021-06-02T12:19:01.2791549' AS DateTime2), 2, 2, 24, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (3, 97, 23, CAST(432423.0000 AS Decimal(20, 4)), 0, 0, CAST(432432.0000 AS Decimal(20, 4)), N'0782344339005', CAST(N'2021-06-02T12:19:43.4038242' AS DateTime2), CAST(N'2021-06-02T12:19:43.4038242' AS DateTime2), 2, 2, 23, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (5, 97, 5, CAST(34.0000 AS Decimal(20, 4)), 0, 0, CAST(3333333333333.0000 AS Decimal(20, 4)), N'0782354219003', CAST(N'2021-06-02T15:03:51.6915308' AS DateTime2), CAST(N'2021-06-02T15:03:51.6915308' AS DateTime2), 2, 2, 24, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (6, 97, 21, CAST(1.0000 AS Decimal(20, 4)), 1, 0, CAST(22222222222.0000 AS Decimal(20, 4)), N'0782354339002', CAST(N'2021-06-02T15:05:55.1053196' AS DateTime2), CAST(N'2021-06-02T15:05:55.1053196' AS DateTime2), 2, 2, 22, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (7, 94, 5, CAST(600.0000 AS Decimal(20, 4)), 0, 0, CAST(6000.0000 AS Decimal(20, 4)), N'0782354417001', CAST(N'2021-06-02T15:07:15.5935040' AS DateTime2), CAST(N'2021-06-02T15:07:15.5935040' AS DateTime2), 2, 2, 21, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (8, 94, 6, CAST(5165.0000 AS Decimal(20, 4)), 1, 1, CAST(8484.0000 AS Decimal(20, 4)), N'0782440418001', CAST(N'2021-06-03T11:13:55.7520277' AS DateTime2), CAST(N'2021-06-03T11:13:55.7520277' AS DateTime2), 2, 2, 22, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (9, 94, 18, CAST(3232.0000 AS Decimal(20, 4)), 0, 0, CAST(3444.0000 AS Decimal(20, 4)), N'0782440431002', CAST(N'2021-06-03T11:14:10.1215561' AS DateTime2), CAST(N'2021-06-03T11:14:10.1215561' AS DateTime2), 2, 2, 19, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (10, 90, 6, CAST(50.0000 AS Decimal(20, 4)), 1, 1, CAST(56165165.0000 AS Decimal(20, 4)), N'6211002432513', CAST(N'2021-06-05T16:49:21.5936793' AS DateTime2), CAST(N'2021-06-17T16:26:06.9802088' AS DateTime2), 2, 2, 22, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (11, 91, 5, CAST(651651.0000 AS Decimal(20, 4)), 1, 1, CAST(1661.0000 AS Decimal(20, 4)), N'6211002422514', CAST(N'2021-06-05T16:50:04.9068593' AS DateTime2), CAST(N'2021-06-05T16:50:04.9068593' AS DateTime2), 2, 2, 22, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (12, 93, 5, CAST(123.0000 AS Decimal(20, 4)), 1, 1, CAST(500.0000 AS Decimal(20, 4)), N'0783361937000', CAST(N'2021-06-12T17:12:59.1921738' AS DateTime2), CAST(N'2021-06-12T17:12:59.1921738' AS DateTime2), 2, 2, 6, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (13, 99, 30, CAST(100.0000 AS Decimal(20, 4)), 0, 0, CAST(10000.0000 AS Decimal(20, 4)), N'0783361979501', CAST(N'2021-06-12T17:13:37.5316972' AS DateTime2), CAST(N'2021-06-12T17:15:12.1658269' AS DateTime2), 2, 2, 32, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (14, 99, 31, CAST(100.0000 AS Decimal(20, 4)), 0, 0, CAST(1000.0000 AS Decimal(20, 4)), N'0783362017002', CAST(N'2021-06-12T17:14:18.8702363' AS DateTime2), CAST(N'2021-06-12T17:14:18.8702363' AS DateTime2), 2, 2, 30, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (15, 99, 32, CAST(1.0000 AS Decimal(20, 4)), 1, 1, CAST(100.0000 AS Decimal(20, 4)), N'0783362058003', CAST(N'2021-06-12T17:14:41.8588080' AS DateTime2), CAST(N'2021-06-12T17:14:41.8588080' AS DateTime2), 2, 2, 32, NULL)
SET IDENTITY_INSERT [dbo].[itemsUnits] OFF
GO
SET IDENTITY_INSERT [dbo].[locations] ON 

INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (1, N'A', N'B', N'315', CAST(N'2021-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-06-01T13:02:09.1794190' AS DateTime2), 2, 2, 1, 1, N'55156')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (12, N'A', N'B', N'945', CAST(N'2021-05-26T17:49:48.3021200' AS DateTime2), CAST(N'2021-05-26T17:50:09.4636208' AS DateTime2), 2, 2, 1, NULL, N'rrre')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (13, N'A', N'V', N'115', CAST(N'2021-05-26T17:49:54.9645131' AS DateTime2), CAST(N'2021-05-27T10:58:06.1744761' AS DateTime2), 2, 2, 1, NULL, N'rrre')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (14, N'A', N's', N'115', CAST(N'2021-05-27T10:59:11.6424682' AS DateTime2), CAST(N'2021-06-01T13:02:20.3425687' AS DateTime2), 2, 2, 1, NULL, N'bo5')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (15, N'A', N'B', N'945', CAST(N'2021-05-30T15:29:15.8909085' AS DateTime2), CAST(N'2021-05-30T15:29:15.8909085' AS DateTime2), 2, 2, 1, NULL, N'rrre')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (80, N'A', N'M', N'1', CAST(N'2021-06-12T19:30:50.9126648' AS DateTime2), CAST(N'2021-06-12T19:30:50.9126648' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (81, N'A', N'M', N'2', CAST(N'2021-06-12T19:30:50.9326102' AS DateTime2), CAST(N'2021-06-12T19:30:50.9326102' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (82, N'A', N'M', N'3', CAST(N'2021-06-12T19:30:50.9375969' AS DateTime2), CAST(N'2021-06-12T19:30:50.9375969' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (83, N'A', N'M', N'4', CAST(N'2021-06-12T19:30:50.9425847' AS DateTime2), CAST(N'2021-06-12T19:30:50.9425847' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (84, N'A', N'N', N'1', CAST(N'2021-06-12T19:30:50.9455771' AS DateTime2), CAST(N'2021-06-12T19:30:50.9455771' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (85, N'A', N'N', N'2', CAST(N'2021-06-12T19:30:50.9515610' AS DateTime2), CAST(N'2021-06-12T19:30:50.9515610' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (86, N'A', N'N', N'3', CAST(N'2021-06-12T19:30:50.9565470' AS DateTime2), CAST(N'2021-06-12T19:30:50.9565470' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (87, N'A', N'N', N'4', CAST(N'2021-06-12T19:30:50.9615333' AS DateTime2), CAST(N'2021-06-12T19:30:50.9615333' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (88, N'B', N'M', N'1', CAST(N'2021-06-12T19:30:50.9665200' AS DateTime2), CAST(N'2021-06-12T19:30:50.9665200' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (89, N'B', N'M', N'2', CAST(N'2021-06-12T19:30:50.9715071' AS DateTime2), CAST(N'2021-06-12T19:30:50.9715071' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (90, N'B', N'M', N'3', CAST(N'2021-06-12T19:30:50.9764935' AS DateTime2), CAST(N'2021-06-12T19:30:50.9764935' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (91, N'B', N'M', N'4', CAST(N'2021-06-12T19:30:50.9814821' AS DateTime2), CAST(N'2021-06-12T19:30:50.9814821' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (92, N'B', N'N', N'1', CAST(N'2021-06-12T19:30:50.9871824' AS DateTime2), CAST(N'2021-06-12T19:30:50.9871824' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (93, N'B', N'N', N'2', CAST(N'2021-06-12T19:30:50.9921695' AS DateTime2), CAST(N'2021-06-12T19:30:50.9921695' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (94, N'B', N'N', N'3', CAST(N'2021-06-12T19:30:50.9971570' AS DateTime2), CAST(N'2021-06-12T19:30:50.9971570' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (95, N'B', N'N', N'4', CAST(N'2021-06-12T19:30:51.0061321' AS DateTime2), CAST(N'2021-06-12T19:30:51.0061321' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (96, N'C', N'M', N'1', CAST(N'2021-06-12T19:30:51.0101209' AS DateTime2), CAST(N'2021-06-12T19:30:51.0101209' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (97, N'C', N'M', N'2', CAST(N'2021-06-12T19:30:51.0161067' AS DateTime2), CAST(N'2021-06-12T19:30:51.0161067' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (98, N'C', N'M', N'3', CAST(N'2021-06-12T19:30:51.0240843' AS DateTime2), CAST(N'2021-06-12T19:30:51.0240843' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (99, N'C', N'M', N'4', CAST(N'2021-06-12T19:30:51.0290714' AS DateTime2), CAST(N'2021-06-12T19:30:51.0290714' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (100, N'C', N'N', N'1', CAST(N'2021-06-12T19:30:51.0360513' AS DateTime2), CAST(N'2021-06-12T19:30:51.0360513' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (101, N'C', N'N', N'2', CAST(N'2021-06-12T19:30:51.0420356' AS DateTime2), CAST(N'2021-06-12T19:30:51.0420356' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (102, N'C', N'N', N'3', CAST(N'2021-06-12T19:30:51.0460244' AS DateTime2), CAST(N'2021-06-12T19:30:51.0460244' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (103, N'C', N'N', N'4', CAST(N'2021-06-12T19:30:51.0520091' AS DateTime2), CAST(N'2021-06-12T19:30:51.0520091' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (104, N'D', N'M', N'1', CAST(N'2021-06-12T19:30:51.0579926' AS DateTime2), CAST(N'2021-06-12T19:30:51.0579926' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (105, N'D', N'M', N'2', CAST(N'2021-06-12T19:30:51.0659732' AS DateTime2), CAST(N'2021-06-12T19:30:51.0659732' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (106, N'D', N'M', N'3', CAST(N'2021-06-12T19:30:51.0709588' AS DateTime2), CAST(N'2021-06-12T19:30:51.0709588' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (107, N'D', N'M', N'4', CAST(N'2021-06-12T19:30:51.0749494' AS DateTime2), CAST(N'2021-06-12T19:30:51.0749494' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (108, N'D', N'N', N'1', CAST(N'2021-06-12T19:30:51.0789382' AS DateTime2), CAST(N'2021-06-12T19:30:51.0789382' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (109, N'D', N'N', N'2', CAST(N'2021-06-12T19:30:51.0859186' AS DateTime2), CAST(N'2021-06-12T19:30:51.0859186' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (110, N'D', N'N', N'3', CAST(N'2021-06-12T19:30:51.0899081' AS DateTime2), CAST(N'2021-06-12T19:30:51.0899081' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (111, N'D', N'N', N'4', CAST(N'2021-06-12T19:30:51.0968892' AS DateTime2), CAST(N'2021-06-12T19:30:51.0968892' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (112, N'E', N'M', N'1', CAST(N'2021-06-12T19:30:51.1028746' AS DateTime2), CAST(N'2021-06-12T19:30:51.1028746' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (113, N'E', N'M', N'2', CAST(N'2021-06-12T19:30:51.1078602' AS DateTime2), CAST(N'2021-06-12T19:30:51.1078602' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (114, N'E', N'M', N'3', CAST(N'2021-06-12T19:30:51.1128454' AS DateTime2), CAST(N'2021-06-12T19:30:51.1128454' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (115, N'E', N'M', N'4', CAST(N'2021-06-12T19:30:51.1198280' AS DateTime2), CAST(N'2021-06-12T19:30:51.1198280' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (116, N'E', N'N', N'1', CAST(N'2021-06-12T19:30:51.1238172' AS DateTime2), CAST(N'2021-06-12T19:30:51.1238172' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (117, N'E', N'N', N'2', CAST(N'2021-06-12T19:30:51.1288032' AS DateTime2), CAST(N'2021-06-12T19:30:51.1288032' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (118, N'E', N'N', N'3', CAST(N'2021-06-12T19:30:51.1327961' AS DateTime2), CAST(N'2021-06-12T19:30:51.1327961' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (119, N'E', N'N', N'4', CAST(N'2021-06-12T19:30:51.1387774' AS DateTime2), CAST(N'2021-06-12T19:30:51.1387774' AS DateTime2), 2, 2, 1, NULL, N'')
SET IDENTITY_INSERT [dbo].[locations] OFF
GO
SET IDENTITY_INSERT [dbo].[offers] ON 

INSERT [dbo].[offers] ([offerId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (2, N'offer1', N'12', 1, N'1', CAST(1.0000 AS Decimal(20, 4)), CAST(N'2021-06-09T13:00:00.0000000' AS DateTime2), CAST(N'2021-06-25T15:00:00.0000000' AS DateTime2), CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), 2, 2, N'notes1')
INSERT [dbo].[offers] ([offerId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (3, N'offer2', N'1', 0, N'1', CAST(10.0000 AS Decimal(20, 4)), CAST(N'2021-05-07T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-17T00:00:00.0000000' AS DateTime2), NULL, NULL, 2, NULL, N'')
INSERT [dbo].[offers] ([offerId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (4, N'offer2', N'2', 0, N'1', CAST(10.0000 AS Decimal(20, 4)), CAST(N'2021-05-14T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-20T00:00:00.0000000' AS DateTime2), NULL, NULL, 2, NULL, N'')
INSERT [dbo].[offers] ([offerId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (5, N'offer33', N'3', 1, N'2', CAST(5.0000 AS Decimal(20, 4)), CAST(N'2021-06-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-06-15T00:00:00.0000000' AS DateTime2), NULL, NULL, 2, NULL, N'notes3')
INSERT [dbo].[offers] ([offerId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (7, N'offer4', N'4', 1, N'2', CAST(15.0000 AS Decimal(20, 4)), CAST(N'2021-06-09T04:01:00.0000000' AS DateTime2), CAST(N'2021-06-19T05:00:00.0000000' AS DateTime2), NULL, NULL, 2, NULL, N'notes2')
INSERT [dbo].[offers] ([offerId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (8, N'offer5', N'5', 1, N'1', CAST(500.0000 AS Decimal(20, 4)), CAST(N'2021-06-22T13:59:00.0000000' AS DateTime2), CAST(N'2021-06-30T14:00:00.0000000' AS DateTime2), NULL, NULL, 2, NULL, N'notes5')
INSERT [dbo].[offers] ([offerId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (9, N'offer6', N'6', 0, N'1', CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-01T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-30T19:00:00.0000000' AS DateTime2), NULL, NULL, 2, NULL, N'notes6')
INSERT [dbo].[offers] ([offerId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (10, N'offer7', N'7', 1, N'1', CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-01T06:00:00.0000000' AS DateTime2), CAST(N'2021-06-01T07:00:00.0000000' AS DateTime2), NULL, NULL, 2, NULL, N'notes7')
SET IDENTITY_INSERT [dbo].[offers] OFF
GO
SET IDENTITY_INSERT [dbo].[pos] ON 

INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (53, N'cod1', N'poos1', CAST(83000.0000 AS Decimal(20, 4)), 5, CAST(N'2021-05-26T11:56:56.7623988' AS DateTime2), CAST(N'2021-06-17T14:20:21.1636165' AS DateTime2), 2, 2, 1, N'لا تحذف هذه النقطة من فضلك', CAST(43070.0000 AS Decimal(20, 4)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (54, N'code1', N'pos2', CAST(103000.0000 AS Decimal(20, 4)), 36, CAST(N'2021-05-26T11:59:42.4697380' AS DateTime2), CAST(N'2021-06-17T09:34:01.0919126' AS DateTime2), 2, 2, 1, N'notes', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (59, N'pos3', N'pos3', CAST(100000.0000 AS Decimal(20, 4)), 5, CAST(N'2021-05-27T13:57:51.7422942' AS DateTime2), CAST(N'2021-05-27T13:57:51.7422942' AS DateTime2), 2, 2, 1, N'notes', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (60, N'code4', N'pos4', CAST(100000.0000 AS Decimal(20, 4)), 5, CAST(N'2021-06-07T12:26:13.6095591' AS DateTime2), CAST(N'2021-06-07T12:26:13.6095591' AS DateTime2), 2, 2, 1, N'notes4', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (61, N'code5', N'pos5', CAST(102000.0000 AS Decimal(20, 4)), 7, CAST(N'2021-06-07T12:26:34.5265006' AS DateTime2), CAST(N'2021-06-08T14:04:00.4717761' AS DateTime2), 2, 2, 1, N'notes5', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (62, N'code6', N'pos6', CAST(100000.0000 AS Decimal(20, 4)), 24, CAST(N'2021-06-07T12:27:00.2722793' AS DateTime2), CAST(N'2021-06-07T12:27:00.2722793' AS DateTime2), 2, 2, 1, N'notes6', NULL)
SET IDENTITY_INSERT [dbo].[pos] OFF
GO
SET IDENTITY_INSERT [dbo].[properties] ON 

INSERT [dbo].[properties] ([propertyId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'ggggg', CAST(N'2021-04-29T15:54:25.5516908' AS DateTime2), CAST(N'2021-06-09T15:35:58.8001710' AS DateTime2), 2, 2, 1)
INSERT [dbo].[properties] ([propertyId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (13, N'color', CAST(N'2021-05-11T15:17:04.3229313' AS DateTime2), CAST(N'2021-05-11T15:17:04.3229313' AS DateTime2), 2, 2, 1)
INSERT [dbo].[properties] ([propertyId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (14, N'size', CAST(N'2021-05-11T15:19:48.1954941' AS DateTime2), CAST(N'2021-05-11T15:19:48.1954941' AS DateTime2), 2, 2, 1)
INSERT [dbo].[properties] ([propertyId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (15, N'', CAST(N'2021-06-08T10:37:52.4324457' AS DateTime2), CAST(N'2021-06-08T10:37:52.4324457' AS DateTime2), 2, 2, 1)
SET IDENTITY_INSERT [dbo].[properties] OFF
GO
SET IDENTITY_INSERT [dbo].[propertiesItems] ON 

INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1, N'val1', NULL, 1, CAST(N'2021-05-11T10:44:43.2278927' AS DateTime2), CAST(N'2021-05-11T10:44:43.2278927' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'', NULL, 1, CAST(N'2021-05-11T12:21:57.2111139' AS DateTime2), CAST(N'2021-05-11T12:21:57.2111139' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, N'cvvv', NULL, 1, CAST(N'2021-05-11T12:22:00.4441406' AS DateTime2), CAST(N'2021-05-11T12:22:00.4441406' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (4, N'rrr', NULL, 1, CAST(N'2021-05-11T12:22:04.3068115' AS DateTime2), CAST(N'2021-05-11T12:22:04.3068115' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (5, N'a', 2, NULL, CAST(N'2021-05-11T15:14:17.8697442' AS DateTime2), CAST(N'2021-05-11T15:14:17.8697442' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (6, N's', 2, NULL, CAST(N'2021-05-11T15:14:19.9986857' AS DateTime2), CAST(N'2021-05-11T15:14:19.9986857' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (7, N'd', 2, NULL, CAST(N'2021-05-11T15:14:21.2918710' AS DateTime2), CAST(N'2021-05-11T15:14:21.2918710' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (8, N'f', 2, NULL, CAST(N'2021-05-11T15:14:22.9314576' AS DateTime2), CAST(N'2021-05-11T15:14:22.9314576' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (9, N'red', 13, NULL, CAST(N'2021-05-11T15:17:14.0609323' AS DateTime2), CAST(N'2021-05-11T15:17:14.0609323' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (10, N'blue', 13, NULL, CAST(N'2021-05-11T15:17:18.9358780' AS DateTime2), CAST(N'2021-05-11T15:17:18.9358780' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (11, N'yellow', 13, NULL, CAST(N'2021-05-11T15:17:25.2749369' AS DateTime2), CAST(N'2021-05-11T15:17:25.2749369' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (12, N'green', 13, NULL, CAST(N'2021-05-11T15:17:29.2064300' AS DateTime2), CAST(N'2021-05-11T15:17:29.2064300' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (14, N'xl', 14, NULL, CAST(N'2021-05-11T15:20:02.7715401' AS DateTime2), CAST(N'2021-05-11T15:20:02.7715401' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (15, N'lg', 14, NULL, CAST(N'2021-05-11T15:20:13.6175552' AS DateTime2), CAST(N'2021-05-11T15:20:13.6175552' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (16, N'md', 14, NULL, CAST(N'2021-05-11T15:20:17.1142106' AS DateTime2), CAST(N'2021-05-11T15:20:17.1142106' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (17, N'sm', 14, NULL, CAST(N'2021-05-11T15:20:19.8110027' AS DateTime2), CAST(N'2021-05-11T15:20:19.8110027' AS DateTime2), 2, 2, 1)
SET IDENTITY_INSERT [dbo].[propertiesItems] OFF
GO
SET IDENTITY_INSERT [dbo].[sections] ON 

INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note]) VALUES (1, N'secc1', CAST(N'2021-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-27T12:45:17.3525969' AS DateTime2), 2, 2, 1, 1, N'sssd')
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note]) VALUES (7, N'test1', CAST(N'2021-05-27T12:45:41.1098440' AS DateTime2), CAST(N'2021-05-27T12:45:41.1098440' AS DateTime2), 2, 2, 6, 1, N'1')
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note]) VALUES (8, N'test2', CAST(N'2021-05-27T12:46:09.2126182' AS DateTime2), CAST(N'2021-05-27T12:46:09.2126182' AS DateTime2), 2, 2, 17, 1, N'2')
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note]) VALUES (9, N'test3', CAST(N'2021-05-27T12:46:11.8213487' AS DateTime2), CAST(N'2021-05-27T12:46:20.7880200' AS DateTime2), 2, 2, 18, 1, N'3')
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note]) VALUES (11, N'test3', CAST(N'2021-05-27T12:48:10.5719337' AS DateTime2), CAST(N'2021-05-27T12:48:10.5719337' AS DateTime2), 2, 2, 18, 1, N'3')
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note]) VALUES (12, N'Foods', CAST(N'2021-06-12T19:14:49.9704227' AS DateTime2), CAST(N'2021-06-12T19:14:49.9704227' AS DateTime2), 2, 2, 6, 1, N'sssdddd')
SET IDENTITY_INSERT [dbo].[sections] OFF
GO
SET IDENTITY_INSERT [dbo].[units] ON 

INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (5, N'unit11', 0, 0, CAST(N'2021-04-29T12:31:49.5705277' AS DateTime2), 2, 2, CAST(N'2021-04-29T12:31:49.5705277' AS DateTime2), 0, 1, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (6, N'unit2', 0, 0, CAST(N'2021-04-29T12:31:56.7277483' AS DateTime2), 2, 2, CAST(N'2021-04-29T12:31:56.7277483' AS DateTime2), 0, NULL, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (18, N'unit3', 1, 1, CAST(N'2021-05-11T12:11:13.8472003' AS DateTime2), 2, 2, CAST(N'2021-05-11T12:11:13.8472003' AS DateTime2), 0, 1, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (19, N'unit4', 1, 1, CAST(N'2021-05-11T12:11:29.9002977' AS DateTime2), 2, 2, CAST(N'2021-05-11T12:11:29.9002977' AS DateTime2), 0, 1, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (20, N'rrrruuu', 0, 0, CAST(N'2021-05-11T12:21:33.4047656' AS DateTime2), 2, 2, CAST(N'2021-05-11T13:11:36.0594416' AS DateTime2), 0, NULL, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (21, N'test', 1, 1, CAST(N'2021-05-11T13:09:36.8104631' AS DateTime2), 2, 2, CAST(N'2021-06-09T15:36:44.3761316' AS DateTime2), 0, 1, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (22, N'TEST2', 1, 1, CAST(N'2021-05-11T13:46:04.9020633' AS DateTime2), 2, 2, CAST(N'2021-05-11T13:46:04.9020633' AS DateTime2), 0, 1, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (23, N'8', 0, 0, CAST(N'2021-05-11T13:59:27.0549321' AS DateTime2), 2, 2, CAST(N'2021-05-11T15:13:38.1746353' AS DateTime2), 0, NULL, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (24, N'5', 0, 0, CAST(N'2021-05-11T15:13:32.2317362' AS DateTime2), 2, 2, CAST(N'2021-05-11T15:13:46.3762503' AS DateTime2), 0, NULL, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (25, N'Kg', 1, 1, CAST(N'2021-05-16T11:05:10.2817797' AS DateTime2), 2, 2, CAST(N'2021-05-16T11:46:29.8209350' AS DateTime2), 0, 1, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (26, N'gram', NULL, NULL, CAST(N'2021-05-16T11:31:29.3896835' AS DateTime2), 2, 2, CAST(N'2021-05-16T11:31:29.3896835' AS DateTime2), NULL, 1, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (27, N'liter', NULL, NULL, CAST(N'2021-05-16T12:32:25.3814107' AS DateTime2), 2, 2, CAST(N'2021-05-16T12:32:25.3814107' AS DateTime2), NULL, 1, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (28, N'Box', NULL, NULL, CAST(N'2021-05-23T17:04:04.4959712' AS DateTime2), 2, 2, CAST(N'2021-05-23T17:04:04.4959712' AS DateTime2), NULL, 1, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (29, N'Bottle', NULL, NULL, CAST(N'2021-05-23T17:04:14.6614805' AS DateTime2), 2, 2, CAST(N'2021-05-23T17:04:14.6614805' AS DateTime2), NULL, 1, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (30, N'كرتونة', NULL, NULL, CAST(N'2021-05-25T13:59:21.8088862' AS DateTime2), 2, 2, CAST(N'2021-05-25T13:59:21.8088862' AS DateTime2), NULL, 1, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (31, N'صندوق', NULL, NULL, CAST(N'2021-05-25T13:59:28.7460816' AS DateTime2), 2, 2, CAST(N'2021-05-25T13:59:28.7460816' AS DateTime2), NULL, 1, NULL)
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (32, N'قطعة', NULL, NULL, CAST(N'2021-05-25T13:59:32.8620081' AS DateTime2), 2, 2, CAST(N'2021-05-25T13:59:32.8620081' AS DateTime2), NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[units] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (2, N'ممنوع الحذف نهائياً', N'45345', N'محمد', N'ناجي', N'job', N'12', CAST(N'2021-04-28T13:31:09.2150383' AS DateTime2), CAST(N'2021-06-14T17:16:32.7358828' AS DateTime2), 2, 2, N'', N'-', N'e@mail.com', N'add1', 1, N'', 1, N'', N'c37858823db0093766eee74d8ee1f1e5.jpg', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (22, N'user1', N'5946e8666343f3cc2dd63d6efc893eaa', N'user1', N'user1', N'job1', N'12', CAST(N'2021-05-25T13:24:05.7312846' AS DateTime2), CAST(N'2021-05-26T14:48:01.8178281' AS DateTime2), 2, 2, N'+971-3-8877666', N'+971-098777', N'e@mail.com', N'address1', 1, N'notes', 1, N'', N'77d0501bbf02ad459f88ab4b7531b14d.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (23, N'user3', N'a99899ea5502d6bd97671ed56ffa86d2', N'user3', N'user3', N'job3', N'12', CAST(N'2021-05-25T13:26:43.8437082' AS DateTime2), CAST(N'2021-05-26T14:50:22.6754600' AS DateTime2), 2, 2, N'+971-4-87665', N'+974-0998887', N'user3@mail.com', N'address3', 1, N'notes', 1, N'', N'e8a124154d6b4436a9d47827fcd24d4d.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (24, N'user4', N'560b3d64638fd493da93829d4460ab80', N'user4', N'user4', N'job2', N'8', CAST(N'2021-05-25T13:29:01.1462507' AS DateTime2), CAST(N'2021-05-26T14:45:46.3072634' AS DateTime2), 2, 2, N'+966-2-988776', N'+971-08987', N'', N'address4', 1, N'notes', 1, N'', N'3f85263e6e6e21f6a4057fab7f956f1b.jpg', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (25, N'user5', N'9249872ce129cc07496ef668bd00c246', N'user5', N'user5', N'job1', N'5', CAST(N'2021-05-25T13:31:24.1717816' AS DateTime2), CAST(N'2021-05-29T10:15:08.5134369' AS DateTime2), 2, 2, N'+974--8877767', N'+971-998877', N'user5@outlook.com', N'user5', 1, N'', 1, N'', N'16008f81a32dddded32b87f4a2cd9ca7.jpg', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (26, N'user6', N'bbdfb058c7bcf00dff01f136507cf398', N'user6', N'user6', N'job1', N'8', CAST(N'2021-05-25T13:38:11.0397128' AS DateTime2), CAST(N'2021-05-26T14:50:11.6838831' AS DateTime2), 2, 2, N'+968--765544', N'+968-0988777', N'user6@gmail.com', N'user6', 1, N'', 1, N'', N'37de6228ecdaf854ca17e0abd1062763.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (27, N'user7', N'3931e9e2fada0c78bff1b42b62ab054c', N'user7', N'user7', N'job1', N'10', CAST(N'2021-05-26T11:49:57.9322155' AS DateTime2), CAST(N'2021-05-27T11:43:17.8964579' AS DateTime2), 2, 2, N'+965--7766555', N'+965-098887', N'user7@mail.com', N'add7', 1, N'notes', 1, N'', N'15c139cdb9cb2a3e6788751f02626b1e.jpg', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (28, N'user8', N'0d73ce6a99e8b1c095c316b400f87eca', N'user8', N'user8', N'job1', N'5', CAST(N'2021-05-27T11:47:02.1691843' AS DateTime2), CAST(N'2021-05-27T11:47:02.1691843' AS DateTime2), 2, 2, N'+966-2-98776', N'+966-098777', N'', N'address8', 1, N'notes', 1, N'', N'b754f525b6f76b3c7201c0d029f5b267.jpg', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (29, N'user9', N'98ff26e245571d90652dcbd17c04c064', N'user9', N'user9', N'job4', N'2', CAST(N'2021-05-27T11:48:20.7582741' AS DateTime2), CAST(N'2021-05-27T11:49:12.7952971' AS DateTime2), 2, 2, N'', N'+965-', N'', N'', 1, N'', 1, N'', N'b754f525b6f76b3c7201c0d029f5b267.jpg', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (30, N'user10', N'd9f10a951a430979d850e6199fa42492', N'user10', N'user10', N'job1', N'12', CAST(N'2021-05-27T13:53:48.5886519' AS DateTime2), CAST(N'2021-05-29T10:13:13.8431127' AS DateTime2), 2, 2, N'+965--998777', N'+966-09887', N'', N'user10', 1, N'', 1, N'', N'f2fed73dd13758a54ab2be16f5bb5171.jpg', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (31, N'newuser', N'932fce2e7bd668f2f689375ff8120b36', N'new user', N'new user', N'job2', N'10', CAST(N'2021-05-29T10:35:52.2592357' AS DateTime2), CAST(N'2021-05-29T10:35:52.2592357' AS DateTime2), 2, 2, N'', N'-', N'', N'', 1, N'', 1, N'', N'77b0157cfc76ae37db589ccef70d65f4.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (32, N'newuser1', N'9f94c6adac0267abfd702723f4f8fc10', N'new user1', N'new user1', N'job5', N'2', CAST(N'2021-05-29T10:41:16.4163496' AS DateTime2), CAST(N'2021-05-29T10:41:16.4163496' AS DateTime2), 2, 2, N'', N'+965-', N'', N'', 1, N'', 1, N'', N'5c19eb82b3b5f0aaa3393ddd7a89027c.jpg', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (33, N'user13', N'11b02624148d40c53ddd4daea1f90d14', N'user13', N'user13', N'job3', N'12', CAST(N'2021-06-03T12:56:44.9500463' AS DateTime2), CAST(N'2021-06-03T12:56:44.9500463' AS DateTime2), 2, 2, N'+971-4-87665', N'+974-0998887', N'user3@mail.com', N'address13', 1, N'13notes', 1, N'', N'ff301ee31a7bad76b8f563c843096adc.jfif', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (34, N'user15', N'8d545b6281a83fc145c500eedafbcbd3', N'user15', N'user15', N'job15', N'5', CAST(N'2021-06-03T12:58:08.2961327' AS DateTime2), CAST(N'2021-06-03T12:58:08.2961327' AS DateTime2), 2, 2, N'+974--8877767', N'+971-998877', N'user15@outlook.com', N'user15', 1, N'', 1, N'', N'9a8205e9af7a1e0e14f8d0d47f4e39ac.jpg', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (35, N'yasin', N'9b43a5e653134fc8350ca9944eadaf2f', N'yasin', N'user2', N'job3', N'12', CAST(N'2021-06-14T17:06:17.9626157' AS DateTime2), CAST(N'2021-06-14T17:06:17.9626157' AS DateTime2), 2, 2, N'', N'-', N'e@mail.com', N'add1', 1, N'', 1, N'', N'c37858823db0093766eee74d8ee1f1e5.jpg', NULL)
SET IDENTITY_INSERT [dbo].[users] OFF
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
ALTER TABLE [dbo].[branchStore]  WITH CHECK ADD  CONSTRAINT [FK_branchStore_branches1] FOREIGN KEY([storeId])
REFERENCES [dbo].[branches] ([branchId])
GO
ALTER TABLE [dbo].[branchStore] CHECK CONSTRAINT [FK_branchStore_branches1]
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
ALTER TABLE [dbo].[invoicesOrders]  WITH CHECK ADD  CONSTRAINT [FK_invoicesOrders_invoices] FOREIGN KEY([invoiceId])
REFERENCES [dbo].[invoices] ([invoiceId])
GO
ALTER TABLE [dbo].[invoicesOrders] CHECK CONSTRAINT [FK_invoicesOrders_invoices]
GO
ALTER TABLE [dbo].[invoicesOrders]  WITH CHECK ADD  CONSTRAINT [FK_invoicesOrders_orders] FOREIGN KEY([orderId])
REFERENCES [dbo].[orders] ([orderId])
GO
ALTER TABLE [dbo].[invoicesOrders] CHECK CONSTRAINT [FK_invoicesOrders_orders]
GO
ALTER TABLE [dbo].[invoicesOrders]  WITH CHECK ADD  CONSTRAINT [FK_invoicesOrders_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[invoicesOrders] CHECK CONSTRAINT [FK_invoicesOrders_users]
GO
ALTER TABLE [dbo].[invoicesOrders]  WITH CHECK ADD  CONSTRAINT [FK_invoicesOrders_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[invoicesOrders] CHECK CONSTRAINT [FK_invoicesOrders_users1]
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
ALTER TABLE [dbo].[itemsUnits]  WITH CHECK ADD  CONSTRAINT [FK_itemsUnits_items] FOREIGN KEY([itemId])
REFERENCES [dbo].[items] ([itemId])
GO
ALTER TABLE [dbo].[itemsUnits] CHECK CONSTRAINT [FK_itemsUnits_items]
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
ALTER TABLE [dbo].[medalAgent]  WITH CHECK ADD  CONSTRAINT [FK_medalAgent_coupons] FOREIGN KEY([couponId])
REFERENCES [dbo].[coupons] ([cId])
GO
ALTER TABLE [dbo].[medalAgent] CHECK CONSTRAINT [FK_medalAgent_coupons]
GO
ALTER TABLE [dbo].[medalAgent]  WITH CHECK ADD  CONSTRAINT [FK_medalAgent_medals] FOREIGN KEY([medalId])
REFERENCES [dbo].[medals] ([medalId])
GO
ALTER TABLE [dbo].[medalAgent] CHECK CONSTRAINT [FK_medalAgent_medals]
GO
ALTER TABLE [dbo].[medalAgent]  WITH CHECK ADD  CONSTRAINT [FK_medalAgent_offers] FOREIGN KEY([offerId])
REFERENCES [dbo].[offers] ([offerId])
GO
ALTER TABLE [dbo].[medalAgent] CHECK CONSTRAINT [FK_medalAgent_offers]
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
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_invoices] FOREIGN KEY([invoiceId])
REFERENCES [dbo].[invoices] ([invoiceId])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_invoices]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_users]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_users1] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_users1]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_users2] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_users2]
GO
ALTER TABLE [dbo].[orderscontents]  WITH CHECK ADD  CONSTRAINT [FK_orderscontents_invoices] FOREIGN KEY([invoiceId])
REFERENCES [dbo].[invoices] ([invoiceId])
GO
ALTER TABLE [dbo].[orderscontents] CHECK CONSTRAINT [FK_orderscontents_invoices]
GO
ALTER TABLE [dbo].[orderscontents]  WITH CHECK ADD  CONSTRAINT [FK_orderscontents_items] FOREIGN KEY([itemId])
REFERENCES [dbo].[items] ([itemId])
GO
ALTER TABLE [dbo].[orderscontents] CHECK CONSTRAINT [FK_orderscontents_items]
GO
ALTER TABLE [dbo].[orderscontents]  WITH CHECK ADD  CONSTRAINT [FK_orderscontents_orders] FOREIGN KEY([orderId])
REFERENCES [dbo].[orders] ([orderId])
GO
ALTER TABLE [dbo].[orderscontents] CHECK CONSTRAINT [FK_orderscontents_orders]
GO
ALTER TABLE [dbo].[orderscontents]  WITH CHECK ADD  CONSTRAINT [FK_orderscontents_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[orderscontents] CHECK CONSTRAINT [FK_orderscontents_users]
GO
ALTER TABLE [dbo].[orderscontents]  WITH CHECK ADD  CONSTRAINT [FK_orderscontents_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[orderscontents] CHECK CONSTRAINT [FK_orderscontents_users1]
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
ALTER TABLE [dbo].[units]  WITH CHECK ADD  CONSTRAINT [FK_units_users] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[units] CHECK CONSTRAINT [FK_units_users]
GO
ALTER TABLE [dbo].[units]  WITH CHECK ADD  CONSTRAINT [FK_units_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[units] CHECK CONSTRAINT [FK_units_users1]
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
