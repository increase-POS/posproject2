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
ALTER TABLE [dbo].[objects] DROP CONSTRAINT [FK_objects_objects]
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
ALTER TABLE [dbo].[inventoryItemLocation] DROP CONSTRAINT [FK_inventoryItemLocation_users1]
GO
ALTER TABLE [dbo].[inventoryItemLocation] DROP CONSTRAINT [FK_inventoryItemLocation_users]
GO
ALTER TABLE [dbo].[inventoryItemLocation] DROP CONSTRAINT [FK_inventoryItemLocation_itemsLocations]
GO
ALTER TABLE [dbo].[inventoryItemLocation] DROP CONSTRAINT [FK_inventoryItemLocation_Inventory]
GO
ALTER TABLE [dbo].[Inventory] DROP CONSTRAINT [FK_Inventory_users1]
GO
ALTER TABLE [dbo].[Inventory] DROP CONSTRAINT [FK_Inventory_users]
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
/****** Object:  Table [dbo].[usersLogs]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usersLogs]') AND type in (N'U'))
DROP TABLE [dbo].[usersLogs]
GO
/****** Object:  Table [dbo].[userSetValues]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[userSetValues]') AND type in (N'U'))
DROP TABLE [dbo].[userSetValues]
GO
/****** Object:  Table [dbo].[users]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type in (N'U'))
DROP TABLE [dbo].[users]
GO
/****** Object:  Table [dbo].[units]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[units]') AND type in (N'U'))
DROP TABLE [dbo].[units]
GO
/****** Object:  Table [dbo].[setValues]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setValues]') AND type in (N'U'))
DROP TABLE [dbo].[setValues]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setting]') AND type in (N'U'))
DROP TABLE [dbo].[setting]
GO
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[servicesCosts]') AND type in (N'U'))
DROP TABLE [dbo].[servicesCosts]
GO
/****** Object:  Table [dbo].[serials]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[serials]') AND type in (N'U'))
DROP TABLE [dbo].[serials]
GO
/****** Object:  Table [dbo].[sections]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sections]') AND type in (N'U'))
DROP TABLE [dbo].[sections]
GO
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[propertiesItems]') AND type in (N'U'))
DROP TABLE [dbo].[propertiesItems]
GO
/****** Object:  Table [dbo].[properties]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[properties]') AND type in (N'U'))
DROP TABLE [dbo].[properties]
GO
/****** Object:  Table [dbo].[posUsers]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[posUsers]') AND type in (N'U'))
DROP TABLE [dbo].[posUsers]
GO
/****** Object:  Table [dbo].[pos]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pos]') AND type in (N'U'))
DROP TABLE [dbo].[pos]
GO
/****** Object:  Table [dbo].[orderscontents]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[orderscontents]') AND type in (N'U'))
DROP TABLE [dbo].[orderscontents]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[orders]') AND type in (N'U'))
DROP TABLE [dbo].[orders]
GO
/****** Object:  Table [dbo].[offers]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[offers]') AND type in (N'U'))
DROP TABLE [dbo].[offers]
GO
/****** Object:  Table [dbo].[objects]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[objects]') AND type in (N'U'))
DROP TABLE [dbo].[objects]
GO
/****** Object:  Table [dbo].[medals]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medals]') AND type in (N'U'))
DROP TABLE [dbo].[medals]
GO
/****** Object:  Table [dbo].[medalAgent]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medalAgent]') AND type in (N'U'))
DROP TABLE [dbo].[medalAgent]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[locations]') AND type in (N'U'))
DROP TABLE [dbo].[locations]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemTransferOffer]') AND type in (N'U'))
DROP TABLE [dbo].[itemTransferOffer]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsUnits]') AND type in (N'U'))
DROP TABLE [dbo].[itemsUnits]
GO
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[itemsTransfer]
GO
/****** Object:  Table [dbo].[itemsProp]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsProp]') AND type in (N'U'))
DROP TABLE [dbo].[itemsProp]
GO
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsOffers]') AND type in (N'U'))
DROP TABLE [dbo].[itemsOffers]
GO
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsMaterials]') AND type in (N'U'))
DROP TABLE [dbo].[itemsMaterials]
GO
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsLocations]') AND type in (N'U'))
DROP TABLE [dbo].[itemsLocations]
GO
/****** Object:  Table [dbo].[items]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[items]') AND type in (N'U'))
DROP TABLE [dbo].[items]
GO
/****** Object:  Table [dbo].[invoicesOrders]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoicesOrders]') AND type in (N'U'))
DROP TABLE [dbo].[invoicesOrders]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoices]') AND type in (N'U'))
DROP TABLE [dbo].[invoices]
GO
/****** Object:  Table [dbo].[inventoryItemLocation]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[inventoryItemLocation]') AND type in (N'U'))
DROP TABLE [dbo].[inventoryItemLocation]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory]') AND type in (N'U'))
DROP TABLE [dbo].[Inventory]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groups]') AND type in (N'U'))
DROP TABLE [dbo].[groups]
GO
/****** Object:  Table [dbo].[groupObject]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupObject]') AND type in (N'U'))
DROP TABLE [dbo].[groupObject]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expenses]') AND type in (N'U'))
DROP TABLE [dbo].[Expenses]
GO
/****** Object:  Table [dbo].[docImages]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[docImages]') AND type in (N'U'))
DROP TABLE [dbo].[docImages]
GO
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[couponsInvoices]') AND type in (N'U'))
DROP TABLE [dbo].[couponsInvoices]
GO
/****** Object:  Table [dbo].[coupons]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[coupons]') AND type in (N'U'))
DROP TABLE [dbo].[coupons]
GO
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[countriesCodes]') AND type in (N'U'))
DROP TABLE [dbo].[countriesCodes]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cities]') AND type in (N'U'))
DROP TABLE [dbo].[cities]
GO
/****** Object:  Table [dbo].[categoryuser]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categoryuser]') AND type in (N'U'))
DROP TABLE [dbo].[categoryuser]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categories]') AND type in (N'U'))
DROP TABLE [dbo].[categories]
GO
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cashTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[cashTransfer]
GO
/****** Object:  Table [dbo].[cards]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cards]') AND type in (N'U'))
DROP TABLE [dbo].[cards]
GO
/****** Object:  Table [dbo].[branchStore]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchStore]') AND type in (N'U'))
DROP TABLE [dbo].[branchStore]
GO
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchesUsers]') AND type in (N'U'))
DROP TABLE [dbo].[branchesUsers]
GO
/****** Object:  Table [dbo].[branches]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branches]') AND type in (N'U'))
DROP TABLE [dbo].[branches]
GO
/****** Object:  Table [dbo].[bondes]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bondes]') AND type in (N'U'))
DROP TABLE [dbo].[bondes]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[banks]') AND type in (N'U'))
DROP TABLE [dbo].[banks]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 6/24/2021 3:37:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agents]') AND type in (N'U'))
DROP TABLE [dbo].[agents]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[bondes]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[branches]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[branchStore]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[cards]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoryuser]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[cities]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[coupons]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[docImages]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[Expenses]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[groupObject]    Script Date: 6/24/2021 3:37:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[groupObject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[groupId] [int] NULL,
	[objectId] [int] NULL,
	[notes] [ntext] NULL,
	[addOb] [bit] NOT NULL,
	[updateOb] [bit] NOT NULL,
	[deleteOb] [bit] NOT NULL,
	[showOb] [bit] NOT NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [int] NULL,
	[reportOb] [bit] NULL,
 CONSTRAINT [PK_groupObject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[Inventory]    Script Date: 6/24/2021 3:37:14 PM ******/
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
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[inventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inventoryItemLocation]    Script Date: 6/24/2021 3:37:14 PM ******/
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
 CONSTRAINT [PK_inventoryItemLocation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoicesOrders]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[items]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsProp]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medalAgent]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medals]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[objects]    Script Date: 6/24/2021 3:37:14 PM ******/
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
 CONSTRAINT [PK_objects] PRIMARY KEY CLUSTERED 
(
	[objectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[offers]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orderscontents]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pos]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posUsers]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[properties]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[sections]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[serials]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[setValues]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[units]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 6/24/2021 3:37:14 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userSetValues]    Script Date: 6/24/2021 3:37:14 PM ******/
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
/****** Object:  Table [dbo].[usersLogs]    Script Date: 6/24/2021 3:37:14 PM ******/
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
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (27, N'yas', N'296263574', N'increase', N'', N'', N'+968--099999', N'+966-098877', N'15c139cdb9cb2a3e6788751f02626b1e.jpg', N'c', N'', CAST(21900.0000 AS Decimal(20, 4)), CAST(N'2021-05-03T15:07:56.6061482' AS DateTime2), CAST(N'2021-06-24T11:45:54.7761014' AS DateTime2), 2, 2, N'', 1, N'+964-1-76555', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (30, N'مورد اختبار', N'323267143', N'ssشركة', N'', N'', N'+96601109887', N'+966-098877', N'', N'v', N'', CAST(126100.0000 AS Decimal(20, 4)), CAST(N'2021-05-03T15:17:15.1575800' AS DateTime2), CAST(N'2021-06-24T10:31:55.1887680' AS DateTime2), 2, 2, N'', 1, N'+96601176555', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (33, N'العميل3', N'721274452', N'تجربة', N'3@mail.net', N'3@mail.net', N'+966-3-87665', N'+971-09887', N'ff301ee31a7bad76b8f563c843096adc.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-05T13:36:57.0841300' AS DateTime2), CAST(N'2021-06-17T09:32:55.8614205' AS DateTime2), 2, 2, N'ملاحظات3', 0, N'+965--76555', CAST(10.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (36, N'تجربة التاريخ', N'195777221', N'الشركة', N'address', N'e@mail.com', N'+965--0988777', N'+974-236588', N'9e57f20d79c131f76efff5103509ca8d.png', N'c', N'', CAST(-7000.0000 AS Decimal(20, 4)), CAST(N'2021-05-06T11:51:43.0578293' AS DateTime2), CAST(N'2021-06-24T10:39:35.3229995' AS DateTime2), 2, 2, N'ملاحظات', 1, N'+965--65544', CAST(200000.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (37, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL, NULL, NULL, 1, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (38, N'الاسم', N'310069437', N'company', N'e@mail.net', N'e@mail.net', N'+973--766555', N'+966-09877', N'f8232374a80b629d9ffa799df77bc908.jpg', N'c', N'', CAST(-3000.0000 AS Decimal(20, 4)), NULL, CAST(N'2021-06-23T10:51:10.9149760' AS DateTime2), 2, 2, N'notes', 1, N'+971--34343', CAST(1200.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (39, N'name', N'721274452', N'com', N'n@mail.com', N'n@mail.com', N'', N'+965-665566544', N'f369cb172051ae89aaea306a576018d5.jpg', N'c', N'', CAST(-199000.0000 AS Decimal(20, 4)), NULL, CAST(N'2021-06-24T11:48:10.2722736' AS DateTime2), 2, 2, N'no', 1, N'', CAST(15.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (40, N'cus1', N'979706308', N'com1', N'add', N'cus13@hotmail.com', N'+965--6655444', N'+974-987766687', N'd440dc23574eac00ee07d2070bc326a6.png', N'c', N'', CAST(-3000.0000 AS Decimal(20, 4)), NULL, CAST(N'2021-06-22T11:26:21.5850510' AS DateTime2), 2, 2, N'no', 1, N'+965--77666666656656666', CAST(14.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (41, N'الزبون2', N'383558749', N'الشركة2', N'halab', N'', N'+974--65444', N'+974-76555', N'2ab64b9b24a0b1e7c1be08de64bf20b7.jpg', N'v', N'', CAST(3600.0000 AS Decimal(20, 4)), NULL, CAST(N'2021-06-19T12:02:50.6468516' AS DateTime2), 2, 2, N'', 1, N'+971-7-756544', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (44, N'ven5', N'354340947', N'com5', N'', N'', N'+966-3-98877', N'+966-9888777', N'30fc6575bf902fbb7443c32827f764b7.jfif', N'v', N'', CAST(-3000.0000 AS Decimal(20, 4)), NULL, CAST(N'2021-06-22T10:53:22.8697340' AS DateTime2), 2, 2, N'', 1, N'+965--443333', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (46, N'ven12', N'350593260', N'', N'', N'', N'', N'+963099887766', N'', NULL, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL, 2, N'', 0, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (47, N'ven5', N'409747752', N'com5', N'', N'', N'', N'+963099887766', N'', NULL, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL, 2, N'', 0, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (48, N'ven5', N'250136962', N'company5', N'', N'', N'', N'+963099887766', N'', NULL, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL, 2, N'', 0, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (49, N'الاسم', N'874505178', N'الشركة', N'', N'', N'+963-11-87665', N'+966-098877', N'32311b5fce9eda034bcb7e7185da6225.png', N'c', N'', CAST(-900.0000 AS Decimal(20, 4)), CAST(N'2021-05-10T10:45:17.4129806' AS DateTime2), CAST(N'2021-06-19T15:00:46.7406025' AS DateTime2), 2, 2, N'', 1, N'+967-3-888675', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (50, N'تجربة', N'109734150', N'الشركة', N'', N'', N'+968--77655', N'+968-987665', N'1610a829bfbc79ad551271913ec4e155.jpg', N'v', N'', CAST(-2000.0000 AS Decimal(20, 4)), CAST(N'2021-05-10T10:52:15.1545706' AS DateTime2), CAST(N'2021-06-22T11:16:15.0972478' AS DateTime2), 2, 2, N'', 1, N'+968--66544', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (51, N'new', N'648910058', N'new com', N'address', N'e@email.com', N'+965--987767', N'+968-098877', N'9e95263dffc253da89baaaf21e4a16ae.png', N'c', N'', CAST(-3500.0000 AS Decimal(20, 4)), CAST(N'2021-05-10T11:07:12.8292681' AS DateTime2), CAST(N'2021-06-22T10:38:59.3811863' AS DateTime2), 2, 2, N'notes', 1, N'+965--344566', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (52, N'new1', N'648910058', N'new com', N'address', N'e@mail.org', N'+965--7655', N'+968-098776', N'332ce0fc448f5f4cc5770ffd1972a5b8.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-10T11:11:32.7455194' AS DateTime2), CAST(N'2021-05-29T10:11:56.9073710' AS DateTime2), 2, 2, N'notes', 1, N'+965--444444', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (55, N'hddd', N'173980060', N'lknl', N'', N'', N'+966-6-234234532', N'+965-453425325', N'f511fb76d630487164e36642f221e881.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-17T17:19:27.4125566' AS DateTime2), CAST(N'2021-05-26T14:36:57.4239163' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (56, N'ahmd', N'664600129', N'hh', N'', N'', N'+966-6-23523525', N'+965-34534534', N'07db2136fa28ae8857d5dcf41365af0d.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-18T03:46:42.2447545' AS DateTime2), CAST(N'2021-05-26T14:26:29.0701516' AS DateTime2), 2, 2, N'', 1, N'+963-21-23523', CAST(33.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (57, N'ahmad', N'802914444', N'dqwdqwd', N'aad@egfew.com', N'aad@egfew.com', N'+973--234234', N'+965-777764', N'a3319b3adf7e69d0d26ef3b05c51bf34.png', N'v', N'', CAST(97103.0000 AS Decimal(20, 4)), CAST(N'2021-05-18T04:19:49.5609334' AS DateTime2), CAST(N'2021-06-22T11:35:33.4813432' AS DateTime2), 2, 2, N'', 1, N'+218-61-2342342', CAST(0.0000 AS Decimal(20, 4)))
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
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (83, N'test', N'333959899', N'test', N'w@mail.com', N'w@mail.com', N'', N'+968-988878', N'2dc70af4aa7464eae5105feeb47fa35e.png', N'v', N'', CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-05-24T17:17:41.0663512' AS DateTime2), CAST(N'2021-06-20T14:10:17.8438614' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (85, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-24T17:25:58.4516564' AS DateTime2), CAST(N'2021-05-24T17:25:58.4516564' AS DateTime2), NULL, NULL, NULL, 1, NULL, CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (86, N'مورد جديد', N'354340947', N'شركة جديدة', N'', N'', N'+965--8766', N'+965-987766', N'a0a5bf7453680d921382ece447fb8439.jpg', N'v', N'', CAST(-1000.0000 AS Decimal(20, 4)), CAST(N'2021-05-25T14:44:57.0373756' AS DateTime2), CAST(N'2021-06-20T12:46:31.1974611' AS DateTime2), 2, 2, N'', 1, N'+965--776655', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (87, N'name', N'179920289', N'com', N'', N'', N'+966-2-76554', N'+968-098776', N'694568a38ec02b9345ab1f652aa86427.jpg', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T10:28:02.0416510' AS DateTime2), CAST(N'2021-05-26T10:36:00.2572169' AS DateTime2), 2, 2, N'', 1, N'+966-2-76655', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (93, N'name1', N'333959899', N'com1', N'dsa', N'posadmpas@gmail.com', N'+965--76655', N'+974-09888', N'b7e8f1ea5c2e3c49c4af7338e16e0874.png', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T10:32:30.5358721' AS DateTime2), CAST(N'2021-05-27T11:01:39.5038125' AS DateTime2), 2, 2, N'asd', 1, N'+965--433454', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (94, N'vendor1', N'333959899', N'company1', N'address', N'vendor1@gmail.com', N'+965--7665', N'+968-099988', N'f8a33e27581ea8951e50227d8f88cc42.png', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:06:10.2861026' AS DateTime2), CAST(N'2021-05-27T11:00:34.6814900' AS DateTime2), 2, 2, N'notes', 1, N'+965--54433', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (95, N'vendor2', N'542692035', N'com2', N'address2', N'vendor2@gmail.com', N'+965--87766', N'+968-098877', N'f008e84007c08b9f9c1ceecc8cf5bc61.png', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:10:08.2181305' AS DateTime2), CAST(N'2021-05-26T14:33:40.1884111' AS DateTime2), 2, 2, N'notes2', 1, N'+966-3-766555', CAST(0.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (96, N'customer1', N'333457741', N'company1', N'address1', N'customer1@mail.com', N'+965--765444', N'+965-098877', N'03c78974a814080b4dea8d6b3be9200b.png', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:14:46.8059906' AS DateTime2), CAST(N'2021-05-26T11:14:46.8059906' AS DateTime2), 2, 2, N'notes', 1, N'+966-3-65544', CAST(10.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (97, N'customer2', N'114850684', N'com2', N'address2', N'customer2@mail.net', N'+965--9876655', N'+965-098887', N'54b481299e43159c8b86a7b48abfac9a.jpg', N'c', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:16:39.3005828' AS DateTime2), CAST(N'2021-05-27T15:55:55.5621563' AS DateTime2), 2, 2, N'notes', 1, N'+965--655444', CAST(12.0000 AS Decimal(20, 4)))
INSERT [dbo].[agents] ([agentId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (98, N'vendor3', N'773226304', N'com3', N'address', N'ven3@gmail.com', N'+966-4-887665', N'+966-987766', N'60f5fcf614d791d17ed1836e07f572d5.png', N'v', N'', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-05-26T11:20:12.2911369' AS DateTime2), CAST(N'2021-05-26T11:20:12.2911369' AS DateTime2), 2, 2, N'notes', 1, N'+965--876655', CAST(0.0000 AS Decimal(20, 4)))
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

INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (39, N'435034433pbnd1', CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-25T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 2, 2, CAST(N'2021-06-21T13:08:48.3102375' AS DateTime2), CAST(N'2021-06-21T13:08:48.3102375' AS DateTime2), NULL, 187)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (40, N'435034433pbnd2', CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-06-26T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 2, 2, CAST(N'2021-06-21T13:09:59.4730817' AS DateTime2), CAST(N'2021-06-21T13:09:59.4730817' AS DateTime2), NULL, 188)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (41, N'435034433pbnd3', CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-06-28T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 2, 2, CAST(N'2021-06-21T14:12:31.1347164' AS DateTime2), CAST(N'2021-06-21T14:12:31.1347164' AS DateTime2), NULL, 189)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (42, N'435034433pbnd4', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-22T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 2, 2, CAST(N'2021-06-21T14:14:13.0836828' AS DateTime2), CAST(N'2021-06-21T14:14:13.0836828' AS DateTime2), NULL, 190)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (43, N'435034433pbnd5', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-29T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 2, 2, CAST(N'2021-06-22T10:35:55.1353956' AS DateTime2), CAST(N'2021-06-21T14:18:26.9215107' AS DateTime2), NULL, 191)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (44, N'435034433pbnd6', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-24T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 2, 2, CAST(N'2021-06-22T10:31:34.5125315' AS DateTime2), CAST(N'2021-06-22T10:30:50.0190631' AS DateTime2), NULL, 192)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (45, N'435034433pbnd7', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-25T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 2, 2, CAST(N'2021-06-22T10:39:42.9100892' AS DateTime2), CAST(N'2021-06-22T10:38:59.1527965' AS DateTime2), NULL, 195)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (46, N'435034433pbnd8', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-25T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 2, 2, CAST(N'2021-06-22T10:42:36.2189507' AS DateTime2), CAST(N'2021-06-22T10:41:48.8278088' AS DateTime2), NULL, 197)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (47, N'435034433pbnd9', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-26T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 2, 2, CAST(N'2021-06-22T10:58:58.6182630' AS DateTime2), CAST(N'2021-06-22T10:53:22.6772519' AS DateTime2), NULL, 199)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (48, N'435034433pbnd10', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-01T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 2, 2, CAST(N'2021-06-22T11:02:01.5516886' AS DateTime2), CAST(N'2021-06-22T11:01:44.7046843' AS DateTime2), NULL, 202)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (49, N'8527', CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-30T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 2, 2, CAST(N'2021-06-22T11:11:05.6268987' AS DateTime2), CAST(N'2021-06-22T11:11:05.6268987' AS DateTime2), NULL, 205)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (50, N'7890', CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-30T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 2, 2, CAST(N'2021-06-22T11:13:31.3286390' AS DateTime2), CAST(N'2021-06-22T11:13:31.3286390' AS DateTime2), NULL, 207)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (51, N'7530', CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-06-30T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 2, 2, CAST(N'2021-06-22T11:16:14.8469175' AS DateTime2), CAST(N'2021-06-22T11:16:14.8469175' AS DateTime2), NULL, 208)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (52, N'8520', CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-06-28T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 2, 2, CAST(N'2021-06-22T11:18:53.5181816' AS DateTime2), CAST(N'2021-06-22T11:18:53.5181816' AS DateTime2), NULL, 210)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (53, N'9520', CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-21T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 2, 2, CAST(N'2021-06-22T11:20:59.9159874' AS DateTime2), CAST(N'2021-06-22T11:20:59.9159874' AS DateTime2), NULL, 211)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (54, N'8520', CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-06-29T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 2, 2, CAST(N'2021-06-22T11:23:32.1825458' AS DateTime2), CAST(N'2021-06-22T11:23:32.1825458' AS DateTime2), NULL, 213)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (55, N'1230', CAST(2500.0000 AS Decimal(20, 4)), CAST(N'2021-06-25T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 2, 2, CAST(N'2021-06-22T11:26:21.2455510' AS DateTime2), CAST(N'2021-06-22T11:26:21.2455510' AS DateTime2), NULL, 215)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (56, N'7530', CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-06-26T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 2, 2, CAST(N'2021-06-22T11:31:15.4481515' AS DateTime2), CAST(N'2021-06-22T11:31:15.4481515' AS DateTime2), NULL, 216)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (57, N'450', CAST(2500.0000 AS Decimal(20, 4)), CAST(N'2021-06-27T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 2, 2, CAST(N'2021-06-22T11:32:57.3646380' AS DateTime2), CAST(N'2021-06-22T11:32:57.3646380' AS DateTime2), NULL, 218)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (58, N'20', CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-26T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 2, 2, CAST(N'2021-06-22T11:35:33.2244366' AS DateTime2), CAST(N'2021-06-22T11:35:33.2244366' AS DateTime2), NULL, 220)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (59, N'220', CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-06-26T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 2, 2, CAST(N'2021-06-23T10:52:34.7226197' AS DateTime2), CAST(N'2021-06-22T11:38:11.6915037' AS DateTime2), NULL, 221)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (60, N'10', CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-06-20T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 2, 2, CAST(N'2021-06-22T11:45:53.0890173' AS DateTime2), CAST(N'2021-06-22T11:39:59.5473234' AS DateTime2), NULL, 222)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (61, N'540', CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-08T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 2, 2, CAST(N'2021-06-22T11:44:23.6560231' AS DateTime2), CAST(N'2021-06-22T11:41:27.2270362' AS DateTime2), NULL, 223)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (62, N'435034433pbnd11', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-20T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 2, 2, CAST(N'2021-06-22T12:05:24.5906950' AS DateTime2), CAST(N'2021-06-22T12:00:27.8705269' AS DateTime2), NULL, 226)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (63, N'435034433pbnd12', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-26T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 2, 2, CAST(N'2021-06-23T10:21:37.2499598' AS DateTime2), CAST(N'2021-06-23T10:19:27.5744660' AS DateTime2), NULL, 229)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (64, N'123', CAST(100.0000 AS Decimal(20, 4)), CAST(N'2021-06-28T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 2, 2, CAST(N'2021-06-23T10:25:39.3737435' AS DateTime2), CAST(N'2021-06-23T10:24:32.6487341' AS DateTime2), NULL, 232)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (65, N'435034433pbnd13', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-26T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 2, 2, CAST(N'2021-06-23T10:54:25.8940867' AS DateTime2), CAST(N'2021-06-23T10:53:24.0915412' AS DateTime2), NULL, 236)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (66, N'435034433pbnd14', CAST(0.0000 AS Decimal(20, 4)), CAST(N'2021-06-30T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 2, 2, CAST(N'2021-06-24T10:33:06.5762594' AS DateTime2), CAST(N'2021-06-24T10:31:54.7858460' AS DateTime2), NULL, 238)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (67, N'149', CAST(12000.0000 AS Decimal(20, 4)), CAST(N'2021-06-23T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 2, 2, CAST(N'2021-06-24T10:35:28.8676019' AS DateTime2), CAST(N'2021-06-24T10:35:28.8676019' AS DateTime2), NULL, 242)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (68, N'000', CAST(15000.0000 AS Decimal(20, 4)), CAST(N'2021-06-26T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 2, 2, CAST(N'2021-06-24T10:39:58.1810533' AS DateTime2), CAST(N'2021-06-24T10:39:35.0553087' AS DateTime2), NULL, 243)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (69, N'435034433pbnd15', CAST(22000.0000 AS Decimal(20, 4)), CAST(N'2021-06-23T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 2, 2, CAST(N'2021-06-24T11:45:54.6195197' AS DateTime2), CAST(N'2021-06-24T11:45:54.6195197' AS DateTime2), NULL, 249)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (70, N'55564888', CAST(200000.0000 AS Decimal(20, 4)), CAST(N'2021-09-13T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 2, 2, CAST(N'2021-06-24T11:48:10.1612876' AS DateTime2), CAST(N'2021-06-24T11:48:10.1612876' AS DateTime2), NULL, 250)
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
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (36, N'957369264', N'1تجربة', N'sy', N'x@outlook.net', N'+965--876655', N'+965-088777', CAST(N'2021-05-10T11:18:08.6905919' AS DateTime2), CAST(N'2021-06-23T16:52:41.9702668' AS DateTime2), 2, 2, N'ملاحظات', 17, 1, N'b')
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
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (68, N'3434', N'syria', N'b  gr eg tr', N'hdhd@hbjh.com', N'+963--22422222', N'+963-093565665', CAST(N'2021-06-23T16:54:23.3340684' AS DateTime2), CAST(N'2021-06-23T16:54:23.3340684' AS DateTime2), 2, 2, N'', 6, 1, N'b')
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
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (74, N'd', 53, 24, NULL, NULL, N'435034433pu2', CAST(N'2021-06-12T13:53:50.9506280' AS DateTime2), CAST(N'2021-06-12T13:53:50.9506280' AS DateTime2), CAST(500.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, N'10', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (75, N'd', 53, NULL, 33, NULL, N'435034433dc2', CAST(N'2021-06-12T13:55:29.9256845' AS DateTime2), CAST(N'2021-06-12T13:55:29.9256845' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'notes', NULL, NULL, NULL, N'c', NULL, N'150', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (76, N'd', 53, NULL, NULL, NULL, N'435034433dm1', CAST(N'2021-06-12T13:57:37.4141873' AS DateTime2), CAST(N'2021-06-12T13:57:37.4141873' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'm', NULL, N'', NULL, NULL, N'card', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (77, N'p', 53, 22, NULL, NULL, N'435034433pbn14', CAST(N'2021-06-12T19:57:50.3162476' AS DateTime2), CAST(N'2021-06-12T19:57:50.3162476' AS DateTime2), CAST(22330.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'222', NULL, 5, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (78, N'd', 53, NULL, 26, NULL, N'435034433du3', CAST(N'2021-06-13T12:05:09.7487011' AS DateTime2), CAST(N'2021-06-13T12:05:09.7487011' AS DateTime2), CAST(1200.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'u', NULL, N'', NULL, NULL, N'card', 5, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (79, N'd', 53, 24, NULL, NULL, N'435034433du4', CAST(N'2021-06-13T12:08:49.6608008' AS DateTime2), CAST(N'2021-06-13T12:08:49.6608008' AS DateTime2), CAST(200.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'u', NULL, N'', NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (80, N'd', 53, NULL, 44, NULL, N'435034433dv6', CAST(N'2021-06-13T12:33:04.9323591' AS DateTime2), CAST(N'2021-06-13T12:33:04.9323591' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 6, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (81, N'd', 53, NULL, 76, NULL, N'435034433dv7', CAST(N'2021-06-13T12:55:11.9678684' AS DateTime2), CAST(N'2021-06-13T12:55:11.9678684' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (82, N'd', 53, NULL, 76, NULL, N'435034433dv8', CAST(N'2021-06-13T13:04:42.3320041' AS DateTime2), CAST(N'2021-06-13T13:04:42.3320041' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'note', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 5, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (86, N'd', 53, NULL, 76, NULL, N'435034433dv12', CAST(N'2021-06-13T13:21:20.0904684' AS DateTime2), CAST(N'2021-06-13T13:21:20.0904684' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'100', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (87, N'd', 53, NULL, 76, NULL, N'435034433dv13', CAST(N'2021-06-13T13:28:29.3629243' AS DateTime2), CAST(N'2021-06-13T13:28:29.3629243' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 5, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (88, N'd', 53, NULL, 76, NULL, N'435034433dv14', CAST(N'2021-06-13T13:31:41.5054693' AS DateTime2), CAST(N'2021-06-13T13:31:41.5054693' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'12', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (90, N'd', 53, NULL, 76, NULL, N'435034433dv16', CAST(N'2021-06-13T13:38:28.2605845' AS DateTime2), CAST(N'2021-06-13T13:38:28.2605845' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'12', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (92, N'd', 53, NULL, 76, NULL, N'435034433dv18', CAST(N'2021-06-13T13:53:49.8011415' AS DateTime2), CAST(N'2021-06-13T13:53:49.8011415' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 5, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (93, N'd', 53, NULL, 76, NULL, N'435034433dv19', CAST(N'2021-06-13T13:55:36.8072383' AS DateTime2), CAST(N'2021-06-13T13:55:36.8072383' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'12', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (94, N'd', 53, NULL, 76, NULL, N'435034433dv20', CAST(N'2021-06-13T13:57:02.9649871' AS DateTime2), CAST(N'2021-06-13T13:57:02.9649871' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 5, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (95, N'd', 53, NULL, 22, NULL, N'435034433dv21', CAST(N'2021-06-13T14:11:29.6809044' AS DateTime2), CAST(N'2021-06-13T14:11:29.6809044' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'75', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (97, N'd', 53, NULL, 22, NULL, N'435034433dv23', CAST(N'2021-06-13T14:23:31.7992000' AS DateTime2), CAST(N'2021-06-13T14:23:31.7992000' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'', NULL, NULL, N'card', 6, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (99, N'd', 53, NULL, 18, NULL, N'435034433dc4', CAST(N'2021-06-13T14:33:05.4876754' AS DateTime2), CAST(N'2021-06-13T14:33:05.4876754' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'', NULL, NULL, N'card', 2, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (100, N'p', 53, NULL, 57, NULL, N'435034433pv3', CAST(N'2021-06-16T12:30:20.2455820' AS DateTime2), CAST(N'2021-06-16T12:30:20.2455820' AS DateTime2), CAST(50100.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'123351651', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (101, N'p', 53, 23, NULL, NULL, N'435034433pu2', CAST(N'2021-06-16T12:31:42.8479624' AS DateTime2), CAST(N'2021-06-16T12:31:42.8479624' AS DateTime2), CAST(10500.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (102, N'p', 53, NULL, 30, NULL, N'435034433pv4', CAST(N'2021-06-17T12:13:15.5930644' AS DateTime2), CAST(N'2021-06-17T12:13:15.5930644' AS DateTime2), CAST(100000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (103, N'p', 53, NULL, 30, NULL, N'435034433pv5', CAST(N'2021-06-17T12:14:52.1089019' AS DateTime2), CAST(N'2021-06-17T12:14:52.1089019' AS DateTime2), CAST(100000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (104, N'p', 53, NULL, 30, NULL, N'435034433pv6', CAST(N'2021-06-17T12:19:39.9480679' AS DateTime2), CAST(N'2021-06-17T12:19:39.9480679' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (105, N'p', 53, NULL, 30, NULL, N'435034433pv7', CAST(N'2021-06-17T12:21:47.5180597' AS DateTime2), CAST(N'2021-06-17T12:21:47.5180597' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (106, N'p', 53, NULL, 30, NULL, N'435034433pv8', CAST(N'2021-06-17T12:23:32.0259249' AS DateTime2), CAST(N'2021-06-17T12:23:32.0259249' AS DateTime2), CAST(3000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (107, N'p', 53, NULL, 30, NULL, N'435034433pv9', CAST(N'2021-06-17T12:24:46.1439056' AS DateTime2), CAST(N'2021-06-17T12:24:46.1439056' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (108, N'p', 53, NULL, 30, NULL, N'435034433pv10', CAST(N'2021-06-17T13:01:29.2113474' AS DateTime2), CAST(N'2021-06-17T13:01:29.2113474' AS DateTime2), CAST(5000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (112, N'p', 53, NULL, 30, NULL, N'435034433pv14', CAST(N'2021-06-17T14:13:17.6090036' AS DateTime2), CAST(N'2021-06-17T14:13:17.6090036' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'147', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (119, N'p', 53, 25, NULL, NULL, N'435034433pu4', CAST(N'2021-06-19T10:55:02.8449041' AS DateTime2), CAST(N'2021-06-19T10:55:02.8449041' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (120, N'p', 53, NULL, 30, NULL, N'435034433pv19', CAST(N'2021-06-19T11:07:31.8492233' AS DateTime2), CAST(N'2021-06-19T11:07:31.8492233' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (121, N'p', 53, 22, NULL, NULL, N'435034433pu5', CAST(N'2021-06-19T11:08:17.2556402' AS DateTime2), CAST(N'2021-06-19T11:08:17.2556402' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, N'159', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (122, N'p', 53, NULL, 36, NULL, N'435034433pc3', CAST(N'2021-06-19T11:10:12.1255267' AS DateTime2), CAST(N'2021-06-19T11:10:12.1255267' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'951', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (123, N'p', 53, NULL, 40, NULL, N'435034433pc4', CAST(N'2021-06-19T11:14:41.3983858' AS DateTime2), CAST(N'2021-06-19T11:14:41.3983858' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'852', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (124, N'p', 53, NULL, 57, NULL, N'435034433pv20', CAST(N'2021-06-19T11:15:57.8703279' AS DateTime2), CAST(N'2021-06-19T11:15:57.8703279' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'card', 3, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (134, N'd', 53, NULL, NULL, 17, N'System.Threading.Tasks.Task`1[System.String]', CAST(N'2021-06-19T12:34:02.9095367' AS DateTime2), CAST(N'2021-06-19T12:34:02.9095367' AS DateTime2), CAST(510.0000 AS Decimal(20, 4)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
GO
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (136, N'd', 53, NULL, 30, NULL, N'435034433dv24', CAST(N'2021-06-19T14:34:11.6552248' AS DateTime2), CAST(N'2021-06-19T14:34:11.6552248' AS DateTime2), CAST(10000.0000 AS Decimal(20, 4)), 2, 2, N'notes', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (137, N'd', 53, NULL, 30, NULL, N'435034433dv25', CAST(N'2021-06-19T14:35:06.7077555' AS DateTime2), CAST(N'2021-06-19T14:35:06.7077555' AS DateTime2), CAST(10000.0000 AS Decimal(20, 4)), 2, 2, N'no', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (138, N'd', 53, NULL, 30, NULL, N'435034433dv26', CAST(N'2021-06-19T14:36:35.9982835' AS DateTime2), CAST(N'2021-06-19T14:36:35.9982835' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (139, N'd', 53, NULL, 30, NULL, N'435034433dv27', CAST(N'2021-06-19T14:36:58.9720246' AS DateTime2), CAST(N'2021-06-19T14:36:58.9720246' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'852', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (140, N'd', 53, NULL, 30, NULL, N'435034433dv28', CAST(N'2021-06-19T14:38:07.4664211' AS DateTime2), CAST(N'2021-06-19T14:38:07.4664211' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'147', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (141, N'd', 53, NULL, 36, NULL, N'435034433dc6', CAST(N'2021-06-19T14:44:18.6452752' AS DateTime2), CAST(N'2021-06-19T14:44:18.6452752' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'258', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (142, N'd', 53, NULL, 36, NULL, N'435034433dc7', CAST(N'2021-06-19T14:45:59.2544743' AS DateTime2), CAST(N'2021-06-19T14:45:59.2544743' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'753', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (143, N'd', 53, NULL, 30, NULL, N'435034433dv29', CAST(N'2021-06-19T14:58:12.5741667' AS DateTime2), CAST(N'2021-06-19T14:58:12.5741667' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'card', 8, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (144, N'd', 53, NULL, 38, NULL, N'435034433dc8', CAST(N'2021-06-19T15:00:04.7117669' AS DateTime2), CAST(N'2021-06-19T15:00:04.7117669' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'259', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (145, N'd', 53, NULL, 49, NULL, N'435034433dc9', CAST(N'2021-06-19T15:00:43.1242663' AS DateTime2), CAST(N'2021-06-19T15:00:43.1242663' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'card', 2, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (185, N'd', 53, 36, NULL, NULL, N'435034433dbn13', CAST(N'2021-06-21T11:13:19.5101010' AS DateTime2), CAST(N'2021-06-21T11:28:51.3515956' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'159', NULL, 6, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (186, N'd', 53, 36, NULL, NULL, N'435034433dbn14', CAST(N'2021-06-21T11:21:54.0840566' AS DateTime2), CAST(N'2021-06-21T11:26:34.2627547' AS DateTime2), CAST(2500.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bn', NULL, N'15987', NULL, 12, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (187, N'p', 53, NULL, 36, NULL, N'435034433pc4', CAST(N'2021-06-21T13:08:47.9197024' AS DateTime2), CAST(N'2021-06-21T13:08:47.9197024' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'435034433pbnd1', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (188, N'p', 53, 26, NULL, NULL, N'435034433pu5', CAST(N'2021-06-21T13:09:59.4382053' AS DateTime2), CAST(N'2021-06-21T13:09:59.4382053' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, N'435034433pbnd2', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (189, N'p', 53, NULL, 36, NULL, N'435034433pc5', CAST(N'2021-06-21T14:12:30.7058624' AS DateTime2), CAST(N'2021-06-21T14:12:30.7058624' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'435034433pbnd3', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (190, N'p', 53, NULL, 51, NULL, N'435034433pc6', CAST(N'2021-06-21T14:14:13.0617721' AS DateTime2), CAST(N'2021-06-21T14:14:13.0617721' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'435034433pbnd4', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (191, N'p', 53, 25, NULL, NULL, N'435034433pu6', CAST(N'2021-06-21T14:18:26.8902703' AS DateTime2), CAST(N'2021-06-21T14:18:26.8902703' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, N'435034433pbnd5', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (192, N'p', 53, NULL, 38, NULL, N'435034433pc7', CAST(N'2021-06-22T10:30:49.5971577' AS DateTime2), CAST(N'2021-06-22T10:41:48.9414742' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'435034433pbnd6', NULL, NULL, N'doc', NULL, 46)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (193, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-06-22T10:30:55.0725260' AS DateTime2), CAST(N'2021-06-22T10:30:55.0725260' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 44)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (194, N'p', 53, 25, NULL, NULL, N'435034433pbnd1', CAST(N'2021-06-22T10:35:55.2091970' AS DateTime2), CAST(N'2021-06-22T10:35:55.2091970' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'435034433pbnd5', NULL, NULL, N'cheque', NULL, 43)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (195, N'p', 53, NULL, 51, NULL, N'435034433pc8', CAST(N'2021-06-22T10:38:59.1109068' AS DateTime2), CAST(N'2021-06-22T10:38:59.1109068' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'435034433pbnd7', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (196, N'p', 53, NULL, 51, NULL, N'435034433pbnd2', CAST(N'2021-06-22T10:39:42.9888769' AS DateTime2), CAST(N'2021-06-22T10:39:42.9888769' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'435034433pbnd7', NULL, NULL, N'card', 2, 45)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (197, N'p', 53, NULL, 30, NULL, N'435034433pv14', CAST(N'2021-06-22T10:41:48.8018467' AS DateTime2), CAST(N'2021-06-22T10:41:48.8018467' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'435034433pbnd8', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (198, N'p', 53, NULL, 30, NULL, N'435034433pbnd3', CAST(N'2021-06-22T10:42:36.2658282' AS DateTime2), CAST(N'2021-06-22T10:42:36.2658282' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'435034433pbnd8', NULL, NULL, N'cash', NULL, 46)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (199, N'p', 53, NULL, 44, NULL, N'435034433pv15', CAST(N'2021-06-22T10:53:14.5914038' AS DateTime2), CAST(N'2021-06-22T10:53:14.5914038' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'435034433pbnd9', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (200, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-06-22T10:53:27.7264312' AS DateTime2), CAST(N'2021-06-22T10:53:27.7264312' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 47)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (201, N'p', 53, NULL, 44, NULL, N'435034433pbnd4', CAST(N'2021-06-22T10:58:58.6850856' AS DateTime2), CAST(N'2021-06-22T10:58:58.6850856' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'435034433pbnd9', NULL, NULL, N'card', 5, 47)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (202, N'p', 53, 25, NULL, NULL, N'435034433pu7', CAST(N'2021-06-22T11:01:44.6600708' AS DateTime2), CAST(N'2021-06-22T11:01:44.6600708' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, N'435034433pbnd10', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (203, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-06-22T11:01:44.8698197' AS DateTime2), CAST(N'2021-06-22T11:01:44.8698197' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 48)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (204, N'p', 53, 25, NULL, NULL, N'435034433pbnd5', CAST(N'2021-06-22T11:02:01.6073989' AS DateTime2), CAST(N'2021-06-22T11:02:01.6073989' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'435034433pbnd10', NULL, NULL, N'cheque', NULL, 48)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (205, N'd', 53, 22, NULL, NULL, N'435034433du5', CAST(N'2021-06-22T11:10:57.8326615' AS DateTime2), CAST(N'2021-06-22T11:13:33.2807242' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, N'8527', NULL, NULL, N'doc', NULL, 50)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (206, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-06-22T11:11:10.6985713' AS DateTime2), CAST(N'2021-06-22T11:11:10.6985713' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 49)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (207, N'd', 53, 23, NULL, NULL, N'435034433du6', CAST(N'2021-06-22T11:13:24.1698466' AS DateTime2), CAST(N'2021-06-22T11:13:24.1698466' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, N'7890', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (208, N'd', 53, NULL, 50, NULL, N'435034433dv23', CAST(N'2021-06-22T11:16:05.0849873' AS DateTime2), CAST(N'2021-06-22T11:18:58.5608846' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'7530', NULL, NULL, N'doc', NULL, 52)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (209, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-06-22T11:16:16.3699675' AS DateTime2), CAST(N'2021-06-22T11:16:16.3699675' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 51)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (210, N'd', 53, NULL, 40, NULL, N'435034433dc8', CAST(N'2021-06-22T11:18:48.3425955' AS DateTime2), CAST(N'2021-06-22T11:18:48.3425955' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'8520', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (211, N'd', 53, NULL, 57, NULL, N'435034433dv24', CAST(N'2021-06-22T11:20:55.3299616' AS DateTime2), CAST(N'2021-06-22T11:20:55.3299616' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'9520', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (212, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-06-22T11:21:04.9558313' AS DateTime2), CAST(N'2021-06-22T11:21:04.9558313' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 53)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (213, N'd', 53, NULL, 40, NULL, N'435034433dc9', CAST(N'2021-06-22T11:23:25.2841976' AS DateTime2), CAST(N'2021-06-22T11:23:25.2841976' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'8520', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (214, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-06-22T11:23:37.2392907' AS DateTime2), CAST(N'2021-06-22T11:23:37.2392907' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 54)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (215, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-06-22T11:26:29.1263239' AS DateTime2), NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 55)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (216, N'd', 53, NULL, 57, NULL, N'435034433dv25', CAST(N'2021-06-22T11:31:07.9582396' AS DateTime2), CAST(N'2021-06-22T11:31:07.9582396' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'7530', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (217, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-06-22T11:31:20.5154717' AS DateTime2), CAST(N'2021-06-22T11:31:20.5154717' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 56)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (218, N'd', 53, 24, NULL, NULL, N'435034433du7', CAST(N'2021-06-22T11:32:55.4310837' AS DateTime2), CAST(N'2021-06-22T11:32:55.4310837' AS DateTime2), CAST(2500.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, N'450', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (219, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-06-22T11:32:59.7759189' AS DateTime2), CAST(N'2021-06-22T11:32:59.7759189' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 57)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (220, N'd', 53, NULL, 57, NULL, N'435034433dv26', CAST(N'2021-06-22T11:35:21.3654377' AS DateTime2), CAST(N'2021-06-22T11:35:38.3268707' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'20', NULL, NULL, N'doc', NULL, 58)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (221, N'd', 53, NULL, 38, NULL, N'435034433dc10', CAST(N'2021-06-22T11:38:07.3769033' AS DateTime2), CAST(N'2021-06-22T11:38:16.1074636' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'220', NULL, NULL, N'doc', NULL, 59)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (222, N'd', 53, 23, NULL, NULL, N'435034433du8', CAST(N'2021-06-22T11:39:52.5926932' AS DateTime2), CAST(N'2021-06-22T11:40:04.6451835' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, N'10', NULL, NULL, N'doc', NULL, 60)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (223, N'd', 53, NULL, 30, NULL, N'435034433dv27', CAST(N'2021-06-22T11:41:20.8113806' AS DateTime2), CAST(N'2021-06-22T11:41:32.3337129' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'540', NULL, NULL, N'doc', NULL, 61)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (224, N'd', 53, NULL, 30, NULL, N'435034433dbnd1', CAST(N'2021-06-22T11:44:23.7547596' AS DateTime2), CAST(N'2021-06-22T11:44:23.7547596' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'540', NULL, NULL, N'cheque', NULL, 61)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (225, N'd', 53, 23, NULL, NULL, N'435034433dbnd2', CAST(N'2021-06-22T11:45:53.1578338' AS DateTime2), CAST(N'2021-06-22T11:45:53.1578338' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'10', NULL, NULL, N'cheque', NULL, 60)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (226, N'p', 53, NULL, 38, NULL, N'435034433pc9', CAST(N'2021-06-22T12:00:27.8376139' AS DateTime2), CAST(N'2021-06-22T12:00:27.8376139' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'435034433pbnd11', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (227, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-06-22T12:00:27.9702633' AS DateTime2), CAST(N'2021-06-22T12:00:27.9702633' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 62)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (228, N'p', 53, NULL, 38, NULL, N'435034433pbnd6', CAST(N'2021-06-22T12:05:24.6594814' AS DateTime2), CAST(N'2021-06-22T12:05:24.6594814' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'435034433pbnd11', NULL, NULL, N'cheque', NULL, 62)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (229, N'p', 53, NULL, 30, NULL, N'435034433pv16', CAST(N'2021-06-23T10:19:27.5006812' AS DateTime2), CAST(N'2021-06-23T10:19:27.5006812' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'435034433pbnd12', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (230, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-06-23T10:19:27.6871655' AS DateTime2), CAST(N'2021-06-23T10:19:27.6871655' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 63)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (231, N'p', 53, NULL, 30, NULL, N'435034433pbnd7', CAST(N'2021-06-23T10:21:37.3217671' AS DateTime2), CAST(N'2021-06-23T10:21:37.3217671' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'435034433pbnd12', NULL, NULL, N'cheque', NULL, 63)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (232, N'd', 53, NULL, 27, NULL, N'435034433dc11', CAST(N'2021-06-23T10:24:19.1966498' AS DateTime2), CAST(N'2021-06-23T10:24:37.7560564' AS DateTime2), CAST(100.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'123', NULL, NULL, N'doc', NULL, 64)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (233, N'd', 53, NULL, 27, NULL, N'435034433dbnd3', CAST(N'2021-06-23T10:25:39.4345773' AS DateTime2), CAST(N'2021-06-23T10:25:39.4345773' AS DateTime2), CAST(100.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'123', NULL, NULL, N'card', 2, 64)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (234, N'p', 53, NULL, 38, NULL, N'435034433pc10', CAST(N'2021-06-23T10:51:10.6446989' AS DateTime2), CAST(N'2021-06-23T10:51:10.6446989' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'456', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (235, N'd', 53, NULL, 38, NULL, N'435034433dbnd4', CAST(N'2021-06-23T10:52:34.7675338' AS DateTime2), CAST(N'2021-06-23T10:52:34.7675338' AS DateTime2), CAST(2000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'220', NULL, NULL, N'card', 2, 59)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (236, N'p', 53, 23, NULL, NULL, N'435034433pu8', CAST(N'2021-06-23T10:53:24.0602986' AS DateTime2), CAST(N'2021-06-23T10:53:24.2789988' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, N'435034433pbnd13', NULL, NULL, N'doc', NULL, 65)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (237, N'p', 53, 23, NULL, NULL, N'435034433pbnd8', CAST(N'2021-06-23T10:54:25.9721921' AS DateTime2), CAST(N'2021-06-23T10:54:25.9721921' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'435034433pbnd13', NULL, NULL, N'cheque', NULL, 65)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (238, N'p', 53, NULL, 30, NULL, N'435034433pv17', CAST(N'2021-06-24T10:31:54.6661647' AS DateTime2), CAST(N'2021-06-24T10:31:55.0561235' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, N'435034433pbnd14', NULL, NULL, N'doc', NULL, 66)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (239, N'p', 53, NULL, 30, NULL, N'435034433pbnd9', CAST(N'2021-06-24T10:33:06.6590344' AS DateTime2), CAST(N'2021-06-24T10:33:06.6590344' AS DateTime2), CAST(0.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'435034433pbnd14', NULL, NULL, N'card', 5, 66)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (240, N'p', 54, NULL, NULL, NULL, N'435034433pp14', CAST(N'2021-06-24T10:34:06.4101574' AS DateTime2), CAST(N'2021-06-24T10:34:06.4101574' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, N'dddddd', 53, 0, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (241, N'd', 59, NULL, NULL, NULL, N'435034433pp1', CAST(N'2021-06-24T10:34:06.5487881' AS DateTime2), CAST(N'2021-06-24T10:34:06.5487881' AS DateTime2), CAST(1000.0000 AS Decimal(20, 4)), 2, 2, NULL, 53, 0, 240, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (242, N'd', 53, 26, NULL, NULL, N'435034433du9', CAST(N'2021-06-24T10:35:26.3114564' AS DateTime2), CAST(N'2021-06-24T10:35:29.0800320' AS DateTime2), CAST(12000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'u', NULL, N'149', NULL, NULL, N'doc', NULL, 67)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (243, N'd', 53, NULL, 36, NULL, N'435034433dc12', CAST(N'2021-06-24T10:39:35.0283445' AS DateTime2), CAST(N'2021-06-24T10:39:35.2970679' AS DateTime2), CAST(15000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'000', NULL, NULL, N'doc', NULL, 68)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (244, N'd', 53, NULL, 36, NULL, N'435034433dbnd5', CAST(N'2021-06-24T10:39:58.3250882' AS DateTime2), CAST(N'2021-06-24T10:39:58.3250882' AS DateTime2), CAST(15000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'bnd', NULL, N'000', NULL, NULL, N'card', 3, 68)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (245, N'p', 53, NULL, NULL, NULL, N'435034433pp15', CAST(N'2021-06-24T11:32:08.9367968' AS DateTime2), CAST(N'2021-06-24T11:32:08.9367968' AS DateTime2), CAST(10000.0000 AS Decimal(20, 4)), 2, 2, N'', 53, 1, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (246, N'd', 54, NULL, NULL, NULL, N'435034433pp1', CAST(N'2021-06-24T11:32:09.0345346' AS DateTime2), CAST(N'2021-06-24T11:32:09.0345346' AS DateTime2), CAST(10000.0000 AS Decimal(20, 4)), 2, 2, NULL, 53, 0, 245, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (247, N'p', 64, NULL, NULL, NULL, N'435034433pp16', CAST(N'2021-06-24T11:32:46.7054486' AS DateTime2), CAST(N'2021-06-24T11:32:46.7054486' AS DateTime2), CAST(960000.0000 AS Decimal(20, 4)), 2, 2, N'', 53, 0, NULL, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (248, N'd', 65, NULL, NULL, NULL, N'435034433pp1', CAST(N'2021-06-24T11:32:46.7952066' AS DateTime2), CAST(N'2021-06-24T11:32:46.7952066' AS DateTime2), CAST(960000.0000 AS Decimal(20, 4)), 2, 2, NULL, 53, 0, 247, N'p', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (249, N'p', 53, NULL, 27, NULL, N'435034433pc11', CAST(N'2021-06-24T11:45:54.5965805' AS DateTime2), CAST(N'2021-06-24T11:45:54.7342136' AS DateTime2), CAST(22000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'435034433pbnd15', NULL, NULL, N'doc', NULL, 69)
INSERT [dbo].[cashTransfer] ([cashTransId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (250, N'd', 53, NULL, 39, NULL, N'435034433dc13', CAST(N'2021-06-24T11:48:08.9182382' AS DateTime2), CAST(N'2021-06-24T11:48:10.2234059' AS DateTime2), CAST(200000.0000 AS Decimal(20, 4)), 2, 2, N'', NULL, NULL, NULL, N'c', NULL, N'55564888', NULL, NULL, N'doc', NULL, 70)
SET IDENTITY_INSERT [dbo].[cashTransfer] OFF
GO
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (20, N'CD3055', N'غذائية', N'details', N'cba6ef02fcbd47ba36115f8f64248594.jpg', 1, CAST(2.0000 AS Decimal(20, 4)), 0, CAST(N'2021-05-02T11:54:18.4411860' AS DateTime2), CAST(N'2021-06-09T10:24:54.6679428' AS DateTime2), 2, 2, NULL)
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
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (23, N'name20', N'code20', 1, N'نسبة مئوية', CAST(10.0000 AS Decimal(20, 4)), CAST(N'2021-05-20T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-24T00:00:00.0000000' AS DateTime2), N'note3', 10, NULL, CAST(10.0000 AS Decimal(20, 4)), CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-05-30T12:06:08.1017245' AS DateTime2), CAST(N'2021-05-30T12:06:08.1017245' AS DateTime2), 2, 2, N'barcode20')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (24, N'name21', N'code21', 0, N'2', CAST(21.0000 AS Decimal(20, 4)), CAST(N'2021-05-21T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-31T00:00:00.0000000' AS DateTime2), N'notes21', 21, NULL, CAST(21.0000 AS Decimal(20, 4)), CAST(210.0000 AS Decimal(20, 4)), CAST(N'2021-05-30T15:28:32.2517760' AS DateTime2), CAST(N'2021-05-30T15:28:32.2517760' AS DateTime2), 2, 2, N'barcode21')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (25, N'c', N'Dis100', 0, N'1', CAST(50.0000 AS Decimal(20, 4)), CAST(N'2021-06-17T00:00:00.0000000' AS DateTime2), CAST(N'2021-06-22T00:00:00.0000000' AS DateTime2), N'', 50, NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(10000.0000 AS Decimal(20, 4)), CAST(N'2021-06-16T16:35:50.9664407' AS DateTime2), CAST(N'2021-06-16T16:35:50.9664407' AS DateTime2), 2, 2, N'100')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (26, N'name24-6', N'code24-6', 1, N'1', CAST(2000.0000 AS Decimal(20, 4)), CAST(N'2021-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-07-29T00:00:00.0000000' AS DateTime2), N'notes24-6', 500, NULL, CAST(5000.0000 AS Decimal(20, 4)), CAST(10000.0000 AS Decimal(20, 4)), CAST(N'2021-06-24T10:51:20.0066528' AS DateTime2), CAST(N'2021-06-24T10:53:14.9369791' AS DateTime2), 2, 2, N'bacode24-6')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (27, N'name224-6', N'code224-6', 0, N'2', CAST(20.0000 AS Decimal(20, 4)), CAST(N'2021-06-26T00:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T00:00:00.0000000' AS DateTime2), N'notes224-6', 5000, NULL, CAST(500.0000 AS Decimal(20, 4)), CAST(1000.0000 AS Decimal(20, 4)), CAST(N'2021-06-24T11:03:36.4116077' AS DateTime2), CAST(N'2021-06-24T11:03:36.4116077' AS DateTime2), 2, 2, N'cop-20')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (28, N'name1', N'code1', 0, N'1', CAST(10000.0000 AS Decimal(20, 4)), CAST(N'2021-05-08T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-26T00:00:00.0000000' AS DateTime2), N'no', 10, 10, CAST(2000.0000 AS Decimal(20, 4)), CAST(20000.0000 AS Decimal(20, 4)), CAST(N'2021-06-24T11:11:15.6276385' AS DateTime2), CAST(N'2021-06-24T11:11:15.6276385' AS DateTime2), 2, 2, N'cop-16')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (29, N'coupon17', N'coupon17', 1, N'2', CAST(20.0000 AS Decimal(20, 4)), CAST(N'2021-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-31T00:00:00.0000000' AS DateTime2), N'note17', 15, 15, CAST(5000.0000 AS Decimal(20, 4)), CAST(20000.0000 AS Decimal(20, 4)), CAST(N'2021-06-24T11:16:08.5112500' AS DateTime2), CAST(N'2021-06-24T11:16:37.8169161' AS DateTime2), 2, 2, N'cop-17')
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
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (15, N'x', N'1459', N'9a8cf00ad91fde85b1b1e6c812822c02.jpg', N'bondes', N'', CAST(N'2021-06-20T11:08:38.8231016' AS DateTime2), CAST(N'2021-06-20T11:08:38.8231016' AS DateTime2), 2, 2, 19)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (16, N'y', N'1459', N'ac5b7beec65c5bcb2c9e3684921390d1.jpg', N'bondes', N'', CAST(N'2021-06-20T11:09:08.1385591' AS DateTime2), CAST(N'2021-06-20T11:09:08.1385591' AS DateTime2), 2, 2, 19)
SET IDENTITY_INSERT [dbo].[docImages] OFF
GO
SET IDENTITY_INSERT [dbo].[groupObject] ON 

INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (27, 21, 1, N'', 1, 1, 1, 1, CAST(N'2021-06-23T14:34:32.1232124' AS DateTime2), CAST(N'2021-06-23T14:36:14.6332944' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (28, 21, 5, N'', 1, 0, 0, 1, CAST(N'2021-06-23T14:34:32.2219477' AS DateTime2), CAST(N'2021-06-23T14:36:14.6472592' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (31, 22, 1, N'', 0, 0, 0, 1, CAST(N'2021-06-23T14:35:36.3316405' AS DateTime2), CAST(N'2021-06-23T14:37:19.2780470' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (32, 22, 5, N'', 1, 1, 0, 1, CAST(N'2021-06-23T14:35:36.3974655' AS DateTime2), CAST(N'2021-06-23T14:37:19.2960436' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (39, 23, 1, N'', 1, 1, 0, 1, CAST(N'2021-06-23T14:38:02.6042746' AS DateTime2), CAST(N'2021-06-23T14:55:42.8282572' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (40, 23, 5, N'', 1, 1, 1, 0, CAST(N'2021-06-23T14:38:02.6381844' AS DateTime2), CAST(N'2021-06-23T14:55:42.8392301' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (45, 24, 1, N'', 0, 0, 0, 0, CAST(N'2021-06-23T15:18:21.8658523' AS DateTime2), CAST(N'2021-06-23T15:18:47.5310060' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (46, 24, 5, N'', 0, 0, 1, 1, CAST(N'2021-06-23T15:18:21.9283689' AS DateTime2), CAST(N'2021-06-23T15:18:47.5778741' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (47, 25, 1, N'', 0, 0, 0, 0, CAST(N'2021-06-23T15:18:32.1344647' AS DateTime2), CAST(N'2021-06-23T15:18:44.6085295' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (48, 25, 5, N'', 0, 0, 0, 0, CAST(N'2021-06-23T15:18:32.1969484' AS DateTime2), CAST(N'2021-06-23T15:18:44.6710125' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (53, 26, 1, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:47:50.9385393' AS DateTime2), CAST(N'2021-06-24T13:20:23.0098233' AS DateTime2), 2, 2, 1, 0)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (54, 26, 5, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:47:51.0063556' AS DateTime2), CAST(N'2021-06-24T13:20:23.0237863' AS DateTime2), 2, 2, 1, 0)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (55, 26, 6, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:47:51.0292945' AS DateTime2), CAST(N'2021-06-24T13:20:23.0487195' AS DateTime2), 2, 2, 1, 0)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (56, 26, 7, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:47:51.0761694' AS DateTime2), CAST(N'2021-06-24T13:20:23.1005812' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (57, 26, 8, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:47:51.0891336' AS DateTime2), CAST(N'2021-06-24T13:20:23.1135477' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (58, 26, 9, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:47:51.1011128' AS DateTime2), CAST(N'2021-06-24T13:20:23.1394770' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (59, 26, 10, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:47:51.1200515' AS DateTime2), CAST(N'2021-06-24T13:20:23.1614190' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (60, 26, 11, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:47:51.1669272' AS DateTime2), CAST(N'2021-06-24T13:20:23.1723881' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (61, 27, 1, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:51:24.9542765' AS DateTime2), CAST(N'2021-06-24T12:51:24.9542765' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (62, 27, 5, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:51:25.0191024' AS DateTime2), CAST(N'2021-06-24T12:51:25.0191024' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (63, 27, 6, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:51:25.0919077' AS DateTime2), CAST(N'2021-06-24T12:51:25.0919077' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (64, 27, 7, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:51:25.1428023' AS DateTime2), CAST(N'2021-06-24T12:51:25.1428023' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (65, 27, 8, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:51:25.1786768' AS DateTime2), CAST(N'2021-06-24T12:51:25.1786768' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (66, 27, 9, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:51:25.2754196' AS DateTime2), CAST(N'2021-06-24T12:51:25.2754196' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (67, 27, 10, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:51:25.2893807' AS DateTime2), CAST(N'2021-06-24T12:51:25.2893807' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (68, 27, 11, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:51:25.2993523' AS DateTime2), CAST(N'2021-06-24T12:51:25.2993523' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (69, 28, 1, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:54:25.6647895' AS DateTime2), CAST(N'2021-06-24T12:54:25.6647895' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (70, 28, 5, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:54:25.7136588' AS DateTime2), CAST(N'2021-06-24T12:54:25.7136588' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (71, 28, 6, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:54:25.8193775' AS DateTime2), CAST(N'2021-06-24T12:54:25.8193775' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (72, 28, 7, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:54:25.8762243' AS DateTime2), CAST(N'2021-06-24T12:54:25.8762243' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (73, 28, 8, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:54:25.8941772' AS DateTime2), CAST(N'2021-06-24T12:54:25.8941772' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (74, 28, 9, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:54:25.9131258' AS DateTime2), CAST(N'2021-06-24T12:54:25.9131258' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (75, 28, 10, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:54:25.9380590' AS DateTime2), CAST(N'2021-06-24T12:54:25.9380590' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (76, 28, 11, N'', 0, 0, 0, 0, CAST(N'2021-06-24T12:54:25.9590046' AS DateTime2), CAST(N'2021-06-24T12:54:25.9590046' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (77, 29, 1, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:00:10.3910718' AS DateTime2), CAST(N'2021-06-24T13:00:10.3910718' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (78, 29, 5, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:00:10.4848023' AS DateTime2), CAST(N'2021-06-24T13:00:10.4848023' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (79, 29, 6, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:01:18.4746148' AS DateTime2), CAST(N'2021-06-24T13:01:18.4746148' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (80, 29, 7, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:02:27.0661370' AS DateTime2), CAST(N'2021-06-24T13:02:27.0661370' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (81, 29, 8, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:02:28.7871147' AS DateTime2), CAST(N'2021-06-24T13:02:28.7871147' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (82, 29, 9, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:03:06.7627365' AS DateTime2), CAST(N'2021-06-24T13:03:06.7627365' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (83, 29, 10, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:03:06.8096015' AS DateTime2), CAST(N'2021-06-24T13:03:06.8096015' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (84, 29, 11, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:03:06.8408442' AS DateTime2), CAST(N'2021-06-24T13:03:06.8408442' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (85, 30, 1, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:06:55.9833681' AS DateTime2), CAST(N'2021-06-24T13:06:55.9833681' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (86, 30, 5, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:06:56.0614780' AS DateTime2), CAST(N'2021-06-24T13:06:56.0614780' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (87, 30, 6, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:07:17.5951691' AS DateTime2), CAST(N'2021-06-24T13:07:17.5951691' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (88, 30, 7, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:07:17.7670073' AS DateTime2), CAST(N'2021-06-24T13:07:17.7670073' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (89, 30, 8, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:07:17.8138720' AS DateTime2), CAST(N'2021-06-24T13:07:17.8138720' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (90, 30, 9, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:07:17.8763591' AS DateTime2), CAST(N'2021-06-24T13:07:17.8763591' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (91, 30, 10, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:07:18.0325707' AS DateTime2), CAST(N'2021-06-24T13:07:18.0325707' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (92, 30, 11, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:07:18.1887835' AS DateTime2), CAST(N'2021-06-24T13:07:18.1887835' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (93, 31, 1, N'', 0, 0, 0, 1, CAST(N'2021-06-24T13:07:34.7557731' AS DateTime2), CAST(N'2021-06-24T13:08:03.8583885' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (94, 31, 5, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:07:34.8338801' AS DateTime2), CAST(N'2021-06-24T13:08:03.9052524' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (95, 31, 6, N'', 0, 0, 0, 1, CAST(N'2021-06-24T13:07:34.9431998' AS DateTime2), CAST(N'2021-06-24T13:08:03.9364970' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (96, 31, 7, N'', 0, 0, 1, 0, CAST(N'2021-06-24T13:07:34.9900981' AS DateTime2), CAST(N'2021-06-24T13:08:03.9521485' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (97, 31, 8, N'', 0, 0, 1, 0, CAST(N'2021-06-24T13:07:35.0369590' AS DateTime2), CAST(N'2021-06-24T13:08:03.9677713' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (98, 31, 9, N'', 0, 0, 0, 0, CAST(N'2021-06-24T13:07:36.5678208' AS DateTime2), CAST(N'2021-06-24T13:08:03.9833877' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (99, 31, 10, N'', 0, 1, 0, 0, CAST(N'2021-06-24T13:07:39.0540061' AS DateTime2), CAST(N'2021-06-24T13:08:03.9989818' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [reportOb]) VALUES (100, 31, 11, N'', 1, 0, 1, 1, CAST(N'2021-06-24T13:07:40.0062416' AS DateTime2), CAST(N'2021-06-24T13:08:04.0302233' AS DateTime2), 2, 2, 1, NULL)
SET IDENTITY_INSERT [dbo].[groupObject] OFF
GO
SET IDENTITY_INSERT [dbo].[groups] ON 

INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (21, N'Accountants', N'dffffff', CAST(N'2021-06-23T14:34:31.9855816' AS DateTime2), CAST(N'2021-06-23T15:18:17.9894907' AS DateTime2), 2, 2, 0)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (22, N'Sales Men', N'ddffgg', CAST(N'2021-06-23T14:35:36.3206718' AS DateTime2), CAST(N'2021-06-23T15:18:11.8434624' AS DateTime2), 2, 2, 0)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (23, N'cashier', N'jjjj', CAST(N'2021-06-23T14:38:02.5883176' AS DateTime2), CAST(N'2021-06-23T15:18:08.7517248' AS DateTime2), 2, 2, 0)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (24, N'Accountants', N'', CAST(N'2021-06-23T15:18:21.5511269' AS DateTime2), CAST(N'2021-06-24T12:47:34.7208732' AS DateTime2), 2, 2, 0)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (25, N'Accountants2', N'', CAST(N'2021-06-23T15:18:32.0094923' AS DateTime2), CAST(N'2021-06-24T12:47:37.7587571' AS DateTime2), 2, 2, 0)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (26, N'تجربة 1', N'', CAST(N'2021-06-24T12:47:50.7969171' AS DateTime2), CAST(N'2021-06-24T12:47:50.7969171' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (27, N'تجربة 2', N'', CAST(N'2021-06-24T12:51:24.9363248' AS DateTime2), CAST(N'2021-06-24T12:51:24.9363248' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (28, N'تجربة 3', N'', CAST(N'2021-06-24T12:54:25.4742995' AS DateTime2), CAST(N'2021-06-24T12:54:25.4742995' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (29, N'تجربة 4', N'', CAST(N'2021-06-24T13:00:01.1679938' AS DateTime2), CAST(N'2021-06-24T13:00:01.1679938' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (30, N'تجربة 5', N'', CAST(N'2021-06-24T13:06:55.7021807' AS DateTime2), CAST(N'2021-06-24T13:06:55.7021807' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (31, N'تجربة 6', N'', CAST(N'2021-06-24T13:07:34.7245309' AS DateTime2), CAST(N'2021-06-24T13:07:34.7245309' AS DateTime2), 2, 2, 1)
SET IDENTITY_INSERT [dbo].[groups] OFF
GO
SET IDENTITY_INSERT [dbo].[invoices] ON 

INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (1, N'0987_PI_1', 41, 2, N'p', N'1', NULL, CAST(120.0000 AS Decimal(20, 4)), CAST(120.0000 AS Decimal(20, 4)), NULL, NULL, NULL, CAST(N'2021-06-06' AS Date), CAST(N'2021-06-06T16:49:26.0092081' AS DateTime2), 2, NULL, NULL, CAST(N'16:49:26.0092081' AS Time), N'', N'', NULL, 41, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (2, N'0987_PI_1', 41, 2, N'pbd', N'1', NULL, CAST(120.0000 AS Decimal(20, 4)), CAST(120.0000 AS Decimal(20, 4)), NULL, NULL, NULL, CAST(N'2021-06-06' AS Date), CAST(N'2021-06-06T17:04:01.7897248' AS DateTime2), 2, 1, NULL, CAST(N'17:04:01.7897248' AS Time), N'', N'', NULL, 41, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (3, N'0987_PI_1', 41, 2, N'pbd', N'1', NULL, CAST(120.0000 AS Decimal(20, 4)), CAST(120.0000 AS Decimal(20, 4)), NULL, NULL, NULL, CAST(N'2021-06-06' AS Date), CAST(N'2021-06-06T17:04:12.3020588' AS DateTime2), 2, 1, NULL, CAST(N'17:04:12.3020588' AS Time), N'', N'', NULL, 41, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (4, N'0987_PI_1', 41, 2, N'pb', N'-1', NULL, CAST(120.0000 AS Decimal(20, 4)), CAST(120.0000 AS Decimal(20, 4)), NULL, NULL, NULL, CAST(N'2021-06-06' AS Date), CAST(N'2021-06-23T14:26:49.1443366' AS DateTime2), 2, 1, NULL, CAST(N'17:04:56.1018556' AS Time), N'', N'', NULL, 41, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (5, N'313858917_PI_2', 26, 2, N'p', N'1', NULL, CAST(1200.0000 AS Decimal(20, 4)), CAST(1200.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-06' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-07T12:15:33.4167232' AS DateTime2), 2, NULL, NULL, CAST(N'12:15:33.4167232' AS Time), N'', N'1651651561', CAST(N'2021-06-03T00:00:00.0000000' AS DateTime2), 26, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (6, N'313858917_PI_3', 26, 2, N'p', N'1', NULL, CAST(1000.0000 AS Decimal(20, 4)), CAST(1000.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-09' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-07T12:26:17.0362379' AS DateTime2), 2, NULL, NULL, CAST(N'12:26:17.0362379' AS Time), N'', N'3434343', CAST(N'2021-06-02T00:00:00.0000000' AS DateTime2), 26, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (7, N'313858917_PI_4', 26, 2, N'p', N'1', CAST(10.0000 AS Decimal(20, 4)), CAST(4200.0000 AS Decimal(20, 4)), CAST(4190.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-08' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-07T12:27:49.0658992' AS DateTime2), 2, NULL, NULL, CAST(N'12:27:49.0658992' AS Time), N'', N'5955919', CAST(N'2021-06-07T00:00:00.0000000' AS DateTime2), 26, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (8, N'313858917_PI_5', 26, 2, N'p', N'1', CAST(10.0000 AS Decimal(20, 4)), CAST(1320.0000 AS Decimal(20, 4)), CAST(1310.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-08' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-07T12:28:27.1770641' AS DateTime2), 2, NULL, NULL, CAST(N'12:28:27.1770641' AS Time), N'', N'35434', CAST(N'2021-06-07T00:00:00.0000000' AS DateTime2), 26, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (9, N'313858917_PI_6', 26, 2, N'p', N'1', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-08' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-07T12:31:23.0894773' AS DateTime2), 2, NULL, NULL, CAST(N'12:31:23.0894773' AS Time), N'', N'6156161', CAST(N'2021-06-07T00:00:00.0000000' AS DateTime2), 26, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (10, N'313858917_PI_7', 26, 2, N'p', N'1', NULL, CAST(242.0000 AS Decimal(20, 4)), CAST(242.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-09' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-07T12:32:50.0932119' AS DateTime2), 2, NULL, NULL, CAST(N'12:32:50.0932119' AS Time), N'', N'4543', CAST(N'2021-06-18T00:00:00.0000000' AS DateTime2), 26, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (11, N'123_PI_8', 44, 2, N'pd', N'2', CAST(15.0000 AS Decimal(20, 4)), CAST(2740.0000 AS Decimal(20, 4)), CAST(2329.0000 AS Decimal(20, 4)), NULL, NULL, CAST(N'2021-06-30' AS Date), CAST(N'2021-06-07' AS Date), CAST(N'2021-06-22T16:12:21.3967981' AS DateTime2), 2, NULL, NULL, CAST(N'12:35:09.8427910' AS Time), N'', N'9846515', CAST(N'2021-06-07T00:00:00.0000000' AS DateTime2), 44, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (12, N'0987_PI_1', 41, 2, N'pb', N'1', NULL, CAST(160.0000 AS Decimal(20, 4)), CAST(160.0000 AS Decimal(20, 4)), NULL, NULL, NULL, CAST(N'2021-06-10' AS Date), CAST(N'2021-06-10T13:37:43.8399063' AS DateTime2), 2, 1, NULL, CAST(N'13:37:43.8399063' AS Time), N'', N'', NULL, 41, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (13, N'313858917_PI_7', 26, 2, N'pbd', N'-1', NULL, CAST(242.0000 AS Decimal(20, 4)), CAST(242.0000 AS Decimal(20, 4)), NULL, NULL, NULL, CAST(N'2021-06-12' AS Date), CAST(N'2021-06-20T09:22:23.7356148' AS DateTime2), 2, 10, NULL, CAST(N'15:51:11.9177991' AS Time), N'', N'4543', CAST(N'2021-06-18T00:00:00.0000000' AS DateTime2), 26, NULL, CAST(0.0000 AS Decimal(20, 4)), NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (14, N'm_PI_9', 30, 2, N'p', N'-1', NULL, CAST(20000.0000 AS Decimal(20, 4)), CAST(19600.0000 AS Decimal(20, 4)), CAST(0.0000 AS Decimal(20, 4)), CAST(19600.0000 AS Decimal(20, 4)), CAST(N'2021-06-09' AS Date), CAST(N'2021-06-12' AS Date), CAST(N'2021-06-12T17:18:26.5011595' AS DateTime2), 2, NULL, NULL, CAST(N'17:18:26.5011595' AS Time), N'', N'54343434', NULL, 5, NULL, CAST(2.0000 AS Decimal(20, 4)), NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (15, N'storecode1_PI_10', 30, 2, N'p', N'2', CAST(2.0000 AS Decimal(20, 4)), CAST(124.0000 AS Decimal(20, 4)), CAST(119.0900 AS Decimal(20, 4)), CAST(0.0000 AS Decimal(20, 4)), CAST(119.0900 AS Decimal(20, 4)), CAST(N'2021-06-30' AS Date), CAST(N'2021-06-12' AS Date), CAST(N'2021-06-12T19:49:59.8854766' AS DateTime2), 2, NULL, NULL, CAST(N'19:49:59.8854766' AS Time), N'hjhjhj', N'22115555', CAST(N'2021-06-11T00:00:00.0000000' AS DateTime2), 9, NULL, CAST(2.0000 AS Decimal(20, 4)), NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (16, N'storecode1_PI_10', 30, 2, N'p', N'-1', NULL, CAST(135.0000 AS Decimal(20, 4)), CAST(132.3000 AS Decimal(20, 4)), CAST(0.0000 AS Decimal(20, 4)), CAST(132.3000 AS Decimal(20, 4)), CAST(N'2021-06-30' AS Date), CAST(N'2021-06-12' AS Date), CAST(N'2021-06-12T20:32:26.5066624' AS DateTime2), 2, NULL, NULL, CAST(N'20:32:26.5066624' AS Time), N'hjhjhgj', N'222333', CAST(N'2021-06-12T00:00:00.0000000' AS DateTime2), 9, NULL, CAST(2.0000 AS Decimal(20, 4)), NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved]) VALUES (17, N'm_SI_1', NULL, 2, N's', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(500.0000 AS Decimal(20, 4)), CAST(510.0000 AS Decimal(20, 4)), CAST(510.0000 AS Decimal(20, 4)), CAST(0.0000 AS Decimal(20, 4)), NULL, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T12:34:02.6861344' AS DateTime2), 2, NULL, NULL, CAST(N'12:34:02.6861344' AS Time), N'', NULL, NULL, NULL, 53, CAST(2.0000 AS Decimal(20, 4)), NULL, NULL, NULL)
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
SET IDENTITY_INSERT [dbo].[itemsOffers] ON 

INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (37, 10, 2, NULL, CAST(N'2021-06-24T10:28:47.8027866' AS DateTime2), 2, 2, 2)
INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (38, 9, 2, NULL, CAST(N'2021-06-24T10:28:47.8027866' AS DateTime2), 2, 2, 10)
INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (39, 2, 2, NULL, CAST(N'2021-06-24T10:28:47.8027866' AS DateTime2), 2, 2, 12)
INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (42, 1, 8, NULL, CAST(N'2021-06-24T10:29:48.5951668' AS DateTime2), 2, 2, 10)
INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (43, 7, 8, NULL, CAST(N'2021-06-24T10:29:48.5951668' AS DateTime2), 2, 2, 8)
SET IDENTITY_INSERT [dbo].[itemsOffers] OFF
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
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (37, 10, 14, NULL, NULL, CAST(N'2021-06-12T17:18:26.5959058' AS DateTime2), CAST(N'2021-06-12T17:18:26.5959058' AS DateTime2), 2, 2, NULL, CAST(2000.0000 AS Decimal(20, 4)), 12)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (38, 1, 14, NULL, NULL, CAST(N'2021-06-12T17:18:26.5959058' AS DateTime2), CAST(N'2021-06-12T17:18:26.5959058' AS DateTime2), 2, 2, NULL, CAST(0.0000 AS Decimal(20, 4)), 15)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (39, 4, 15, NULL, NULL, CAST(N'2021-06-12T19:49:59.9732417' AS DateTime2), CAST(N'2021-06-12T19:49:59.9732417' AS DateTime2), 2, 2, NULL, CAST(10.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (40, 7, 15, NULL, NULL, CAST(N'2021-06-12T19:49:59.9742401' AS DateTime2), CAST(N'2021-06-12T19:49:59.9742401' AS DateTime2), 2, 2, NULL, CAST(12.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (41, 6, 16, NULL, NULL, CAST(N'2021-06-12T20:32:26.6024576' AS DateTime2), CAST(N'2021-06-12T20:32:26.6024576' AS DateTime2), 2, 2, NULL, CAST(10.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (42, 3, 16, NULL, NULL, CAST(N'2021-06-12T20:32:26.6034068' AS DateTime2), CAST(N'2021-06-12T20:32:26.6034068' AS DateTime2), 2, 2, NULL, CAST(25.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (43, 1, 17, NULL, NULL, CAST(N'2021-06-19T12:34:03.3304120' AS DateTime2), CAST(N'2021-06-19T12:34:03.3304120' AS DateTime2), 2, 2, NULL, CAST(500.0000 AS Decimal(20, 4)), 12)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (44, 2, 13, NULL, NULL, CAST(N'2021-06-20T09:22:24.2083490' AS DateTime2), CAST(N'2021-06-20T09:22:24.2083490' AS DateTime2), 2, 2, NULL, CAST(103.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (45, 1, 13, NULL, NULL, CAST(N'2021-06-20T09:22:24.2272987' AS DateTime2), CAST(N'2021-06-20T09:22:24.2272987' AS DateTime2), 2, 2, NULL, CAST(36.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (52, 5, 11, NULL, NULL, CAST(N'2021-06-22T16:12:21.5217981' AS DateTime2), CAST(N'2021-06-22T16:12:21.5217981' AS DateTime2), 2, 2, NULL, CAST(500.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (53, 2, 11, NULL, NULL, CAST(N'2021-06-22T16:12:21.5217981' AS DateTime2), CAST(N'2021-06-22T16:12:21.5217981' AS DateTime2), 2, 2, NULL, CAST(120.0000 AS Decimal(20, 4)), 10)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (54, 4, 4, NULL, NULL, CAST(N'2021-06-23T14:26:49.3717261' AS DateTime2), CAST(N'2021-06-23T14:26:49.3717261' AS DateTime2), 2, 2, NULL, CAST(10.0000 AS Decimal(20, 4)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (55, 4, 4, NULL, NULL, CAST(N'2021-06-23T14:26:49.3976577' AS DateTime2), CAST(N'2021-06-23T14:26:49.3976577' AS DateTime2), 2, 2, NULL, CAST(20.0000 AS Decimal(20, 4)), 10)
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
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (16, 314, 30, CAST(100.0000 AS Decimal(20, 4)), 0, 0, CAST(10000.0000 AS Decimal(20, 4)), N'780201379555', CAST(N'2021-06-23T09:47:09.2564450' AS DateTime2), CAST(N'2021-06-23T09:47:09.2564450' AS DateTime2), 2, 2, 31, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (17, 314, 31, CAST(100.0000 AS Decimal(20, 4)), 0, 0, CAST(1000.0000 AS Decimal(20, 4)), N'780201379623', CAST(N'2021-06-23T09:47:43.4332900' AS DateTime2), CAST(N'2021-06-23T09:47:43.4332900' AS DateTime2), 2, 2, 32, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (18, 314, 32, CAST(1.0000 AS Decimal(20, 4)), 1, 1, CAST(100.0000 AS Decimal(20, 4)), N'780201378527', CAST(N'2021-06-23T09:48:24.3658433' AS DateTime2), CAST(N'2021-06-23T09:48:24.3658433' AS DateTime2), 2, 2, 32, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (19, 314, 29, CAST(10.0000 AS Decimal(20, 4)), 0, 0, CAST(200000.0000 AS Decimal(20, 4)), N'780201373676', CAST(N'2021-06-23T09:49:36.3003521' AS DateTime2), CAST(N'2021-06-23T09:49:36.3003521' AS DateTime2), 2, 2, 30, NULL)
SET IDENTITY_INSERT [dbo].[itemsUnits] OFF
GO
SET IDENTITY_INSERT [dbo].[locations] ON 

INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (1, N'A', N'B', N'315', CAST(N'2021-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-06-01T13:02:09.1794190' AS DateTime2), 2, 2, 1, 1, N'55156')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (12, N'A', N'B', N'945', CAST(N'2021-05-26T17:49:48.3021200' AS DateTime2), CAST(N'2021-05-26T17:50:09.4636208' AS DateTime2), 2, 2, 1, NULL, N'rrre')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (13, N'A', N'V', N'115', CAST(N'2021-05-26T17:49:54.9645131' AS DateTime2), CAST(N'2021-05-27T10:58:06.1744761' AS DateTime2), 2, 2, 1, NULL, N'rrre')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (14, N'A', N's', N'115', CAST(N'2021-05-27T10:59:11.6424682' AS DateTime2), CAST(N'2021-06-01T13:02:20.3425687' AS DateTime2), 2, 2, 1, NULL, N'bo5')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (15, N'A', N'B', N'945', CAST(N'2021-05-30T15:29:15.8909085' AS DateTime2), CAST(N'2021-05-30T15:29:15.8909085' AS DateTime2), 2, 2, 1, NULL, N'rrre')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (80, N'A', N'M', N'1', CAST(N'2021-06-12T19:30:50.9126648' AS DateTime2), CAST(N'2021-06-12T19:30:50.9126648' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (81, N'A', N'M', N'2', CAST(N'2021-06-12T19:30:50.9326102' AS DateTime2), CAST(N'2021-06-24T11:20:25.5464018' AS DateTime2), 2, 2, 1, NULL, N'no notes AM2')
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
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (124, N'1', N'2', N'3', CAST(N'2021-06-24T11:31:47.3192584' AS DateTime2), CAST(N'2021-06-24T11:31:47.3192584' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (125, N'1', N'2', N'4', CAST(N'2021-06-24T11:31:47.3348495' AS DateTime2), CAST(N'2021-06-24T11:31:47.3348495' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (126, N'1', N'2', N'5', CAST(N'2021-06-24T11:31:47.3505021' AS DateTime2), CAST(N'2021-06-24T11:31:47.3505021' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (127, N'1', N'2', N'6', CAST(N'2021-06-24T11:31:47.3505021' AS DateTime2), CAST(N'2021-06-24T11:31:47.3505021' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (128, N'1', N'2', N'7', CAST(N'2021-06-24T11:31:47.3660932' AS DateTime2), CAST(N'2021-06-24T11:31:47.3660932' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (129, N'1', N'3', N'3', CAST(N'2021-06-24T11:31:47.3817165' AS DateTime2), CAST(N'2021-06-24T11:31:47.3817165' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (130, N'1', N'3', N'4', CAST(N'2021-06-24T11:31:47.3973366' AS DateTime2), CAST(N'2021-06-24T11:31:47.3973366' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (131, N'1', N'3', N'5', CAST(N'2021-06-24T11:31:47.4129870' AS DateTime2), CAST(N'2021-06-24T11:31:47.4129870' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (132, N'1', N'3', N'6', CAST(N'2021-06-24T11:31:47.4286102' AS DateTime2), CAST(N'2021-06-24T11:31:47.4286102' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (133, N'1', N'3', N'7', CAST(N'2021-06-24T11:31:47.4286102' AS DateTime2), CAST(N'2021-06-24T11:31:47.4286102' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (134, N'1', N'4', N'3', CAST(N'2021-06-24T11:31:47.4442308' AS DateTime2), CAST(N'2021-06-24T11:31:47.4442308' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (135, N'1', N'4', N'4', CAST(N'2021-06-24T11:31:47.4598204' AS DateTime2), CAST(N'2021-06-24T11:31:47.4598204' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (136, N'1', N'4', N'5', CAST(N'2021-06-24T11:31:47.4598204' AS DateTime2), CAST(N'2021-06-24T11:31:47.4598204' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (137, N'1', N'4', N'6', CAST(N'2021-06-24T11:31:47.4754734' AS DateTime2), CAST(N'2021-06-24T11:31:47.4754734' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (138, N'1', N'4', N'7', CAST(N'2021-06-24T11:31:47.4910977' AS DateTime2), CAST(N'2021-06-24T11:31:47.4910977' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (139, N'1', N'5', N'3', CAST(N'2021-06-24T11:31:47.5067141' AS DateTime2), CAST(N'2021-06-24T11:31:47.5067141' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (140, N'1', N'5', N'4', CAST(N'2021-06-24T11:31:47.5067141' AS DateTime2), CAST(N'2021-06-24T11:31:47.5067141' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (141, N'1', N'5', N'5', CAST(N'2021-06-24T11:31:47.5223411' AS DateTime2), CAST(N'2021-06-24T11:31:47.5223411' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (142, N'1', N'5', N'6', CAST(N'2021-06-24T11:31:47.5379587' AS DateTime2), CAST(N'2021-06-24T11:31:47.5379587' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (143, N'1', N'5', N'7', CAST(N'2021-06-24T11:31:47.5379587' AS DateTime2), CAST(N'2021-06-24T11:31:47.5379587' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (144, N'1', N'6', N'3', CAST(N'2021-06-24T11:31:47.5535800' AS DateTime2), CAST(N'2021-06-24T11:31:47.5535800' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (145, N'1', N'6', N'4', CAST(N'2021-06-24T11:31:47.5535800' AS DateTime2), CAST(N'2021-06-24T11:31:47.5535800' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (146, N'1', N'6', N'5', CAST(N'2021-06-24T11:31:47.5691726' AS DateTime2), CAST(N'2021-06-24T11:31:47.5691726' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (147, N'1', N'6', N'6', CAST(N'2021-06-24T11:31:47.5847939' AS DateTime2), CAST(N'2021-06-24T11:31:47.5847939' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (148, N'1', N'6', N'7', CAST(N'2021-06-24T11:31:47.6004439' AS DateTime2), CAST(N'2021-06-24T11:31:47.6004439' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (149, N'2', N'2', N'3', CAST(N'2021-06-24T11:31:47.6004439' AS DateTime2), CAST(N'2021-06-24T11:31:47.6004439' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (150, N'2', N'2', N'4', CAST(N'2021-06-24T11:31:47.6160679' AS DateTime2), CAST(N'2021-06-24T11:31:47.6160679' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (151, N'2', N'2', N'5', CAST(N'2021-06-24T11:31:47.6316903' AS DateTime2), CAST(N'2021-06-24T11:31:47.6316903' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (152, N'2', N'2', N'6', CAST(N'2021-06-24T11:31:47.6473116' AS DateTime2), CAST(N'2021-06-24T11:31:47.6473116' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (153, N'2', N'2', N'7', CAST(N'2021-06-24T11:31:47.6473116' AS DateTime2), CAST(N'2021-06-24T11:31:47.6473116' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (154, N'2', N'3', N'3', CAST(N'2021-06-24T11:31:47.6629295' AS DateTime2), CAST(N'2021-06-24T11:31:47.6629295' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (155, N'2', N'3', N'4', CAST(N'2021-06-24T11:31:47.6629295' AS DateTime2), CAST(N'2021-06-24T11:31:47.6629295' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (156, N'2', N'3', N'5', CAST(N'2021-06-24T11:31:47.6785191' AS DateTime2), CAST(N'2021-06-24T11:31:47.6785191' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (157, N'2', N'3', N'6', CAST(N'2021-06-24T11:31:47.6941718' AS DateTime2), CAST(N'2021-06-24T11:31:47.6941718' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (158, N'2', N'3', N'7', CAST(N'2021-06-24T11:31:47.6941718' AS DateTime2), CAST(N'2021-06-24T11:31:47.6941718' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (159, N'2', N'4', N'3', CAST(N'2021-06-24T11:31:47.7097625' AS DateTime2), CAST(N'2021-06-24T11:31:47.7097625' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (160, N'2', N'4', N'4', CAST(N'2021-06-24T11:31:47.7253834' AS DateTime2), CAST(N'2021-06-24T11:31:47.7253834' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (161, N'2', N'4', N'5', CAST(N'2021-06-24T11:31:47.7410380' AS DateTime2), CAST(N'2021-06-24T11:31:47.7410380' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (162, N'2', N'4', N'6', CAST(N'2021-06-24T11:31:47.7566544' AS DateTime2), CAST(N'2021-06-24T11:31:47.7566544' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (163, N'2', N'4', N'7', CAST(N'2021-06-24T11:31:47.7722485' AS DateTime2), CAST(N'2021-06-24T11:31:47.7722485' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (164, N'2', N'5', N'3', CAST(N'2021-06-24T11:31:47.7878691' AS DateTime2), CAST(N'2021-06-24T11:31:47.7878691' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (165, N'2', N'5', N'4', CAST(N'2021-06-24T11:31:47.7878691' AS DateTime2), CAST(N'2021-06-24T11:31:47.7878691' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (166, N'2', N'5', N'5', CAST(N'2021-06-24T11:31:47.8035217' AS DateTime2), CAST(N'2021-06-24T11:31:47.8035217' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (167, N'2', N'5', N'6', CAST(N'2021-06-24T11:31:47.8035217' AS DateTime2), CAST(N'2021-06-24T11:31:47.8035217' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (168, N'2', N'5', N'7', CAST(N'2021-06-24T11:31:47.8191434' AS DateTime2), CAST(N'2021-06-24T11:31:47.8191434' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (169, N'2', N'6', N'3', CAST(N'2021-06-24T11:31:47.8347655' AS DateTime2), CAST(N'2021-06-24T11:31:47.8347655' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (170, N'2', N'6', N'4', CAST(N'2021-06-24T11:31:47.8347655' AS DateTime2), CAST(N'2021-06-24T11:31:47.8347655' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (171, N'2', N'6', N'5', CAST(N'2021-06-24T11:31:47.8503857' AS DateTime2), CAST(N'2021-06-24T11:31:47.8503857' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (172, N'2', N'6', N'6', CAST(N'2021-06-24T11:31:47.8816253' AS DateTime2), CAST(N'2021-06-24T11:31:47.8816253' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (173, N'2', N'6', N'7', CAST(N'2021-06-24T11:31:47.8972217' AS DateTime2), CAST(N'2021-06-24T11:31:47.8972217' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (174, N'3', N'2', N'3', CAST(N'2021-06-24T11:31:47.8972217' AS DateTime2), CAST(N'2021-06-24T11:31:47.8972217' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (175, N'3', N'2', N'4', CAST(N'2021-06-24T11:31:47.9128411' AS DateTime2), CAST(N'2021-06-24T11:31:47.9128411' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (176, N'3', N'2', N'5', CAST(N'2021-06-24T11:31:47.9128411' AS DateTime2), CAST(N'2021-06-24T11:31:47.9128411' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (177, N'3', N'2', N'6', CAST(N'2021-06-24T11:31:47.9284628' AS DateTime2), CAST(N'2021-06-24T11:31:47.9284628' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (178, N'3', N'2', N'7', CAST(N'2021-06-24T11:31:47.9440837' AS DateTime2), CAST(N'2021-06-24T11:31:47.9440837' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (179, N'3', N'3', N'3', CAST(N'2021-06-24T11:31:47.9440837' AS DateTime2), CAST(N'2021-06-24T11:31:47.9440837' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (180, N'3', N'3', N'4', CAST(N'2021-06-24T11:31:47.9597058' AS DateTime2), CAST(N'2021-06-24T11:31:47.9597058' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (181, N'3', N'3', N'5', CAST(N'2021-06-24T11:31:47.9753565' AS DateTime2), CAST(N'2021-06-24T11:31:47.9753565' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (182, N'3', N'3', N'6', CAST(N'2021-06-24T11:31:47.9753565' AS DateTime2), CAST(N'2021-06-24T11:31:47.9753565' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (183, N'3', N'3', N'7', CAST(N'2021-06-24T11:31:47.9909801' AS DateTime2), CAST(N'2021-06-24T11:31:47.9909801' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (184, N'3', N'4', N'3', CAST(N'2021-06-24T11:31:48.0065690' AS DateTime2), CAST(N'2021-06-24T11:31:48.0065690' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (185, N'3', N'4', N'4', CAST(N'2021-06-24T11:31:48.0221903' AS DateTime2), CAST(N'2021-06-24T11:31:48.0221903' AS DateTime2), 2, 2, 1, NULL, N'')
GO
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (186, N'3', N'4', N'5', CAST(N'2021-06-24T11:31:48.0221903' AS DateTime2), CAST(N'2021-06-24T11:31:48.0221903' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (187, N'3', N'4', N'6', CAST(N'2021-06-24T11:31:48.0378425' AS DateTime2), CAST(N'2021-06-24T11:31:48.0378425' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (188, N'3', N'4', N'7', CAST(N'2021-06-24T11:31:48.0378425' AS DateTime2), CAST(N'2021-06-24T11:31:48.0378425' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (189, N'3', N'5', N'3', CAST(N'2021-06-24T11:31:48.0534337' AS DateTime2), CAST(N'2021-06-24T11:31:48.0534337' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (190, N'3', N'5', N'4', CAST(N'2021-06-24T11:31:48.0690546' AS DateTime2), CAST(N'2021-06-24T11:31:48.0690546' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (191, N'3', N'5', N'5', CAST(N'2021-06-24T11:31:48.0690546' AS DateTime2), CAST(N'2021-06-24T11:31:48.0690546' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (192, N'3', N'5', N'6', CAST(N'2021-06-24T11:31:48.0846744' AS DateTime2), CAST(N'2021-06-24T11:31:48.0846744' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (193, N'3', N'5', N'7', CAST(N'2021-06-24T11:31:48.1002980' AS DateTime2), CAST(N'2021-06-24T11:31:48.1002980' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (194, N'3', N'6', N'3', CAST(N'2021-06-24T11:31:48.1002980' AS DateTime2), CAST(N'2021-06-24T11:31:48.1002980' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (195, N'3', N'6', N'4', CAST(N'2021-06-24T11:31:48.1223178' AS DateTime2), CAST(N'2021-06-24T11:31:48.1223178' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (196, N'3', N'6', N'5', CAST(N'2021-06-24T11:31:48.1322920' AS DateTime2), CAST(N'2021-06-24T11:31:48.1322920' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (197, N'3', N'6', N'6', CAST(N'2021-06-24T11:31:48.1452566' AS DateTime2), CAST(N'2021-06-24T11:31:48.1452566' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (198, N'3', N'6', N'7', CAST(N'2021-06-24T11:31:48.1542325' AS DateTime2), CAST(N'2021-06-24T11:31:48.1542325' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (199, N'4', N'2', N'3', CAST(N'2021-06-24T11:31:48.1652318' AS DateTime2), CAST(N'2021-06-24T11:31:48.1652318' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (200, N'4', N'2', N'4', CAST(N'2021-06-24T11:31:48.1761745' AS DateTime2), CAST(N'2021-06-24T11:31:48.1761745' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (201, N'4', N'2', N'5', CAST(N'2021-06-24T11:31:48.1861472' AS DateTime2), CAST(N'2021-06-24T11:31:48.1861472' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (202, N'4', N'2', N'6', CAST(N'2021-06-24T11:31:48.1971239' AS DateTime2), CAST(N'2021-06-24T11:31:48.1971239' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (203, N'4', N'2', N'7', CAST(N'2021-06-24T11:31:48.2090891' AS DateTime2), CAST(N'2021-06-24T11:31:48.2090891' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (204, N'4', N'3', N'3', CAST(N'2021-06-24T11:31:48.2190606' AS DateTime2), CAST(N'2021-06-24T11:31:48.2190606' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (205, N'4', N'3', N'4', CAST(N'2021-06-24T11:31:48.2290613' AS DateTime2), CAST(N'2021-06-24T11:31:48.2290613' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (206, N'4', N'3', N'5', CAST(N'2021-06-24T11:31:48.2439958' AS DateTime2), CAST(N'2021-06-24T11:31:48.2439958' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (207, N'4', N'3', N'6', CAST(N'2021-06-24T11:31:48.2549641' AS DateTime2), CAST(N'2021-06-24T11:31:48.2549641' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (208, N'4', N'3', N'7', CAST(N'2021-06-24T11:31:48.2699239' AS DateTime2), CAST(N'2021-06-24T11:31:48.2699239' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (209, N'4', N'4', N'3', CAST(N'2021-06-24T11:31:48.2749892' AS DateTime2), CAST(N'2021-06-24T11:31:48.2749892' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (210, N'4', N'4', N'4', CAST(N'2021-06-24T11:31:48.2906422' AS DateTime2), CAST(N'2021-06-24T11:31:48.2906422' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (211, N'4', N'4', N'5', CAST(N'2021-06-24T11:31:48.2906422' AS DateTime2), CAST(N'2021-06-24T11:31:48.2906422' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (212, N'4', N'4', N'6', CAST(N'2021-06-24T11:31:48.3062348' AS DateTime2), CAST(N'2021-06-24T11:31:48.3062348' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (213, N'4', N'4', N'7', CAST(N'2021-06-24T11:31:48.3218539' AS DateTime2), CAST(N'2021-06-24T11:31:48.3218539' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (214, N'4', N'5', N'3', CAST(N'2021-06-24T11:31:48.3375073' AS DateTime2), CAST(N'2021-06-24T11:31:48.3375073' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (215, N'4', N'5', N'4', CAST(N'2021-06-24T11:31:48.3531297' AS DateTime2), CAST(N'2021-06-24T11:31:48.3531297' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (216, N'4', N'5', N'5', CAST(N'2021-06-24T11:31:48.3531297' AS DateTime2), CAST(N'2021-06-24T11:31:48.3531297' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (217, N'4', N'5', N'6', CAST(N'2021-06-24T11:31:48.3687178' AS DateTime2), CAST(N'2021-06-24T11:31:48.3687178' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (218, N'4', N'5', N'7', CAST(N'2021-06-24T11:31:48.3687178' AS DateTime2), CAST(N'2021-06-24T11:31:48.3687178' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (219, N'4', N'6', N'3', CAST(N'2021-06-24T11:31:48.3843406' AS DateTime2), CAST(N'2021-06-24T11:31:48.3843406' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (220, N'4', N'6', N'4', CAST(N'2021-06-24T11:31:48.3999952' AS DateTime2), CAST(N'2021-06-24T11:31:48.3999952' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (221, N'4', N'6', N'5', CAST(N'2021-06-24T11:31:48.3999952' AS DateTime2), CAST(N'2021-06-24T11:31:48.3999952' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (222, N'4', N'6', N'6', CAST(N'2021-06-24T11:31:48.4155825' AS DateTime2), CAST(N'2021-06-24T11:31:48.4155825' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (223, N'4', N'6', N'7', CAST(N'2021-06-24T11:31:48.4312352' AS DateTime2), CAST(N'2021-06-24T11:31:48.4312352' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (224, N'5', N'2', N'3', CAST(N'2021-06-24T11:31:48.4468251' AS DateTime2), CAST(N'2021-06-24T11:31:48.4468251' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (225, N'5', N'2', N'4', CAST(N'2021-06-24T11:31:48.4468251' AS DateTime2), CAST(N'2021-06-24T11:31:48.4468251' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (226, N'5', N'2', N'5', CAST(N'2021-06-24T11:31:48.4624785' AS DateTime2), CAST(N'2021-06-24T11:31:48.4624785' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (227, N'5', N'2', N'6', CAST(N'2021-06-24T11:31:48.4624785' AS DateTime2), CAST(N'2021-06-24T11:31:48.4624785' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (228, N'5', N'2', N'7', CAST(N'2021-06-24T11:31:48.4780678' AS DateTime2), CAST(N'2021-06-24T11:31:48.4780678' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (229, N'5', N'3', N'3', CAST(N'2021-06-24T11:31:48.4936898' AS DateTime2), CAST(N'2021-06-24T11:31:48.4936898' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (230, N'5', N'3', N'4', CAST(N'2021-06-24T11:31:48.4936898' AS DateTime2), CAST(N'2021-06-24T11:31:48.4936898' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (231, N'5', N'3', N'5', CAST(N'2021-06-24T11:31:48.5093127' AS DateTime2), CAST(N'2021-06-24T11:31:48.5093127' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (232, N'5', N'3', N'6', CAST(N'2021-06-24T11:31:48.5249336' AS DateTime2), CAST(N'2021-06-24T11:31:48.5249336' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (233, N'5', N'3', N'7', CAST(N'2021-06-24T11:31:48.5249336' AS DateTime2), CAST(N'2021-06-24T11:31:48.5249336' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (234, N'5', N'4', N'3', CAST(N'2021-06-24T11:31:48.5561766' AS DateTime2), CAST(N'2021-06-24T11:31:48.5561766' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (235, N'5', N'4', N'4', CAST(N'2021-06-24T11:31:48.5718266' AS DateTime2), CAST(N'2021-06-24T11:31:48.5718266' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (236, N'5', N'4', N'5', CAST(N'2021-06-24T11:31:48.5874513' AS DateTime2), CAST(N'2021-06-24T11:31:48.5874513' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (237, N'5', N'4', N'6', CAST(N'2021-06-24T11:31:48.6030696' AS DateTime2), CAST(N'2021-06-24T11:31:48.6030696' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (238, N'5', N'4', N'7', CAST(N'2021-06-24T11:31:48.6186936' AS DateTime2), CAST(N'2021-06-24T11:31:48.6186936' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (239, N'5', N'5', N'3', CAST(N'2021-06-24T11:31:48.6186936' AS DateTime2), CAST(N'2021-06-24T11:31:48.6186936' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (240, N'5', N'5', N'4', CAST(N'2021-06-24T11:31:48.6342820' AS DateTime2), CAST(N'2021-06-24T11:31:48.6342820' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (241, N'5', N'5', N'5', CAST(N'2021-06-24T11:31:48.6499377' AS DateTime2), CAST(N'2021-06-24T11:31:48.6499377' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (242, N'5', N'5', N'6', CAST(N'2021-06-24T11:31:48.6655549' AS DateTime2), CAST(N'2021-06-24T11:31:48.6655549' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (243, N'5', N'5', N'7', CAST(N'2021-06-24T11:31:48.6811762' AS DateTime2), CAST(N'2021-06-24T11:31:48.6811762' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (244, N'5', N'6', N'3', CAST(N'2021-06-24T11:31:48.6811762' AS DateTime2), CAST(N'2021-06-24T11:31:48.6811762' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (245, N'5', N'6', N'4', CAST(N'2021-06-24T11:31:48.6967684' AS DateTime2), CAST(N'2021-06-24T11:31:48.6967684' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (246, N'5', N'6', N'5', CAST(N'2021-06-24T11:31:48.7123897' AS DateTime2), CAST(N'2021-06-24T11:31:48.7123897' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (247, N'5', N'6', N'6', CAST(N'2021-06-24T11:31:48.7280409' AS DateTime2), CAST(N'2021-06-24T11:31:48.7280409' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (248, N'5', N'6', N'7', CAST(N'2021-06-24T11:31:48.7280409' AS DateTime2), CAST(N'2021-06-24T11:31:48.7280409' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (249, N'A', N'B', N'C', CAST(N'2021-06-24T11:37:26.5066099' AS DateTime2), CAST(N'2021-06-24T11:37:26.5066099' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (250, N'A', N'B', N'D', CAST(N'2021-06-24T11:37:26.5222320' AS DateTime2), CAST(N'2021-06-24T11:37:26.5222320' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (251, N'A', N'B', N'E', CAST(N'2021-06-24T11:37:26.5378541' AS DateTime2), CAST(N'2021-06-24T11:37:26.5378541' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (252, N'A', N'C', N'C', CAST(N'2021-06-24T11:37:26.5534437' AS DateTime2), CAST(N'2021-06-24T11:37:26.5534437' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (253, N'A', N'C', N'D', CAST(N'2021-06-24T11:37:26.5534437' AS DateTime2), CAST(N'2021-06-24T11:37:26.5534437' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (254, N'A', N'C', N'E', CAST(N'2021-06-24T11:37:26.5690993' AS DateTime2), CAST(N'2021-06-24T11:37:26.5690993' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (255, N'A', N'D', N'C', CAST(N'2021-06-24T11:37:26.5846867' AS DateTime2), CAST(N'2021-06-24T11:37:26.5846867' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (256, N'A', N'D', N'D', CAST(N'2021-06-24T11:37:26.6003393' AS DateTime2), CAST(N'2021-06-24T11:37:26.6003393' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (257, N'A', N'D', N'E', CAST(N'2021-06-24T11:37:26.6003393' AS DateTime2), CAST(N'2021-06-24T11:37:26.6003393' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (258, N'B', N'B', N'C', CAST(N'2021-06-24T11:37:26.6159289' AS DateTime2), CAST(N'2021-06-24T11:37:26.6159289' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (259, N'B', N'B', N'D', CAST(N'2021-06-24T11:37:26.6315502' AS DateTime2), CAST(N'2021-06-24T11:37:26.6315502' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (260, N'B', N'B', N'E', CAST(N'2021-06-24T11:37:26.6472032' AS DateTime2), CAST(N'2021-06-24T11:37:26.6472032' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (261, N'B', N'C', N'C', CAST(N'2021-06-24T11:37:26.6628261' AS DateTime2), CAST(N'2021-06-24T11:37:26.6628261' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (262, N'B', N'C', N'D', CAST(N'2021-06-24T11:37:26.6784478' AS DateTime2), CAST(N'2021-06-24T11:37:26.6784478' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (263, N'B', N'C', N'E', CAST(N'2021-06-24T11:37:26.6940642' AS DateTime2), CAST(N'2021-06-24T11:37:26.6940642' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (264, N'B', N'D', N'C', CAST(N'2021-06-24T11:37:26.7253121' AS DateTime2), CAST(N'2021-06-24T11:37:26.7253121' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (265, N'B', N'D', N'D', CAST(N'2021-06-24T11:37:26.7409009' AS DateTime2), CAST(N'2021-06-24T11:37:26.7409009' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (266, N'B', N'D', N'E', CAST(N'2021-06-24T11:37:26.7409009' AS DateTime2), CAST(N'2021-06-24T11:37:26.7409009' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (267, N'C', N'B', N'C', CAST(N'2021-06-24T11:37:26.7565219' AS DateTime2), CAST(N'2021-06-24T11:37:26.7565219' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (268, N'C', N'B', N'D', CAST(N'2021-06-24T11:37:26.7721454' AS DateTime2), CAST(N'2021-06-24T11:37:26.7721454' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (269, N'C', N'B', N'E', CAST(N'2021-06-24T11:37:26.7877951' AS DateTime2), CAST(N'2021-06-24T11:37:26.7877951' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (270, N'C', N'C', N'C', CAST(N'2021-06-24T11:37:26.8033854' AS DateTime2), CAST(N'2021-06-24T11:37:26.8033854' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (271, N'C', N'C', N'D', CAST(N'2021-06-24T11:37:26.8502799' AS DateTime2), CAST(N'2021-06-24T11:37:26.8502799' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (272, N'C', N'C', N'E', CAST(N'2021-06-24T11:37:26.8659028' AS DateTime2), CAST(N'2021-06-24T11:37:26.8659028' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (273, N'C', N'D', N'C', CAST(N'2021-06-24T11:37:26.8815241' AS DateTime2), CAST(N'2021-06-24T11:37:26.8815241' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (274, N'C', N'D', N'D', CAST(N'2021-06-24T11:37:26.8971446' AS DateTime2), CAST(N'2021-06-24T11:37:26.8971446' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (275, N'C', N'D', N'E', CAST(N'2021-06-24T11:37:26.9127663' AS DateTime2), CAST(N'2021-06-24T11:37:26.9127663' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (276, N'D', N'B', N'C', CAST(N'2021-06-24T11:37:26.9127663' AS DateTime2), CAST(N'2021-06-24T11:37:26.9127663' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (277, N'D', N'B', N'D', CAST(N'2021-06-24T11:37:26.9439787' AS DateTime2), CAST(N'2021-06-24T11:37:26.9439787' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (278, N'D', N'B', N'E', CAST(N'2021-06-24T11:37:26.9439787' AS DateTime2), CAST(N'2021-06-24T11:37:26.9439787' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (279, N'D', N'C', N'C', CAST(N'2021-06-24T11:37:26.9596019' AS DateTime2), CAST(N'2021-06-24T11:37:26.9596019' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (280, N'D', N'C', N'D', CAST(N'2021-06-24T11:37:26.9752516' AS DateTime2), CAST(N'2021-06-24T11:37:26.9752516' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (281, N'D', N'C', N'E', CAST(N'2021-06-24T11:37:26.9908755' AS DateTime2), CAST(N'2021-06-24T11:37:26.9908755' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (282, N'D', N'D', N'C', CAST(N'2021-06-24T11:37:27.0064640' AS DateTime2), CAST(N'2021-06-24T11:37:27.0064640' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (283, N'D', N'D', N'D', CAST(N'2021-06-24T11:37:27.0064640' AS DateTime2), CAST(N'2021-06-24T11:37:27.0064640' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (284, N'D', N'D', N'E', CAST(N'2021-06-24T11:37:27.0220857' AS DateTime2), CAST(N'2021-06-24T11:37:27.0220857' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (285, N'E', N'B', N'C', CAST(N'2021-06-24T11:37:27.0377380' AS DateTime2), CAST(N'2021-06-24T11:37:27.0377380' AS DateTime2), 2, 2, 1, NULL, N'')
GO
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (286, N'E', N'B', N'D', CAST(N'2021-06-24T11:37:27.0533608' AS DateTime2), CAST(N'2021-06-24T11:37:27.0533608' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (287, N'E', N'B', N'E', CAST(N'2021-06-24T11:37:27.0689504' AS DateTime2), CAST(N'2021-06-24T11:37:27.0689504' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (288, N'E', N'C', N'C', CAST(N'2021-06-24T11:37:27.0689504' AS DateTime2), CAST(N'2021-06-24T11:37:27.0689504' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (289, N'E', N'C', N'D', CAST(N'2021-06-24T11:37:27.3188910' AS DateTime2), CAST(N'2021-06-24T11:37:27.3188910' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (290, N'E', N'C', N'E', CAST(N'2021-06-24T11:37:27.3501642' AS DateTime2), CAST(N'2021-06-24T11:37:27.3501642' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (291, N'E', N'D', N'C', CAST(N'2021-06-24T11:37:27.3657576' AS DateTime2), CAST(N'2021-06-24T11:37:27.3657576' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (292, N'E', N'D', N'D', CAST(N'2021-06-24T11:37:27.3813766' AS DateTime2), CAST(N'2021-06-24T11:37:27.3813766' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (293, N'E', N'D', N'E', CAST(N'2021-06-24T11:37:27.3969979' AS DateTime2), CAST(N'2021-06-24T11:37:27.3969979' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (294, N'A', N'B', N'F', CAST(N'2021-06-24T11:46:08.7132982' AS DateTime2), CAST(N'2021-06-24T11:46:08.7132982' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (295, N'A', N'B', N'G', CAST(N'2021-06-24T11:46:08.7289187' AS DateTime2), CAST(N'2021-06-24T11:46:08.7289187' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (296, N'A', N'B', N'H', CAST(N'2021-06-24T11:46:08.7445076' AS DateTime2), CAST(N'2021-06-24T11:46:08.7445076' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (297, N'A', N'B', N'I', CAST(N'2021-06-24T11:46:08.7445076' AS DateTime2), CAST(N'2021-06-24T11:46:08.7445076' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (298, N'A', N'B', N'J', CAST(N'2021-06-24T11:46:08.7601323' AS DateTime2), CAST(N'2021-06-24T11:46:08.7601323' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (299, N'A', N'B', N'K', CAST(N'2021-06-24T11:46:08.7757823' AS DateTime2), CAST(N'2021-06-24T11:46:08.7757823' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (300, N'A', N'B', N'L', CAST(N'2021-06-24T11:46:08.7757823' AS DateTime2), CAST(N'2021-06-24T11:46:08.7757823' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (301, N'A', N'B', N'M', CAST(N'2021-06-24T11:46:08.7913719' AS DateTime2), CAST(N'2021-06-24T11:46:08.7913719' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (302, N'A', N'B', N'N', CAST(N'2021-06-24T11:46:08.8069936' AS DateTime2), CAST(N'2021-06-24T11:46:08.8069936' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (303, N'A', N'C', N'F', CAST(N'2021-06-24T11:46:08.8069936' AS DateTime2), CAST(N'2021-06-24T11:46:08.8069936' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (304, N'A', N'C', N'G', CAST(N'2021-06-24T11:46:08.8226157' AS DateTime2), CAST(N'2021-06-24T11:46:08.8226157' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (305, N'A', N'C', N'H', CAST(N'2021-06-24T11:46:08.8382358' AS DateTime2), CAST(N'2021-06-24T11:46:08.8382358' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (306, N'A', N'C', N'I', CAST(N'2021-06-24T11:46:08.8382358' AS DateTime2), CAST(N'2021-06-24T11:46:08.8382358' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (307, N'A', N'C', N'J', CAST(N'2021-06-24T11:46:08.8538579' AS DateTime2), CAST(N'2021-06-24T11:46:08.8538579' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (308, N'A', N'C', N'K', CAST(N'2021-06-24T11:46:08.8695102' AS DateTime2), CAST(N'2021-06-24T11:46:08.8695102' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (309, N'A', N'C', N'L', CAST(N'2021-06-24T11:46:08.8695102' AS DateTime2), CAST(N'2021-06-24T11:46:08.8695102' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (310, N'A', N'C', N'M', CAST(N'2021-06-24T11:46:08.8851311' AS DateTime2), CAST(N'2021-06-24T11:46:08.8851311' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (311, N'A', N'C', N'N', CAST(N'2021-06-24T11:46:08.9007222' AS DateTime2), CAST(N'2021-06-24T11:46:08.9007222' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (312, N'A', N'D', N'F', CAST(N'2021-06-24T11:46:08.9007222' AS DateTime2), CAST(N'2021-06-24T11:46:08.9007222' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (313, N'A', N'D', N'G', CAST(N'2021-06-24T11:46:08.9163428' AS DateTime2), CAST(N'2021-06-24T11:46:08.9163428' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (314, N'A', N'D', N'H', CAST(N'2021-06-24T11:46:08.9319947' AS DateTime2), CAST(N'2021-06-24T11:46:08.9319947' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (315, N'A', N'D', N'I', CAST(N'2021-06-24T11:46:08.9319947' AS DateTime2), CAST(N'2021-06-24T11:46:08.9319947' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (316, N'A', N'D', N'J', CAST(N'2021-06-24T11:46:08.9475880' AS DateTime2), CAST(N'2021-06-24T11:46:08.9475880' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (317, N'A', N'D', N'K', CAST(N'2021-06-24T11:46:08.9632369' AS DateTime2), CAST(N'2021-06-24T11:46:08.9632369' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (318, N'A', N'D', N'L', CAST(N'2021-06-24T11:46:08.9632369' AS DateTime2), CAST(N'2021-06-24T11:46:08.9632369' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (319, N'A', N'D', N'M', CAST(N'2021-06-24T11:46:08.9788601' AS DateTime2), CAST(N'2021-06-24T11:46:08.9788601' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (320, N'A', N'D', N'N', CAST(N'2021-06-24T11:46:08.9944811' AS DateTime2), CAST(N'2021-06-24T11:46:08.9944811' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (321, N'A', N'E', N'C', CAST(N'2021-06-24T11:46:08.9944811' AS DateTime2), CAST(N'2021-06-24T11:46:08.9944811' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (322, N'A', N'E', N'D', CAST(N'2021-06-24T11:46:09.0100722' AS DateTime2), CAST(N'2021-06-24T11:46:09.0100722' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (323, N'A', N'E', N'E', CAST(N'2021-06-24T11:46:09.0100722' AS DateTime2), CAST(N'2021-06-24T11:46:09.0100722' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (324, N'A', N'E', N'F', CAST(N'2021-06-24T11:46:09.0256961' AS DateTime2), CAST(N'2021-06-24T11:46:09.0256961' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (325, N'A', N'E', N'G', CAST(N'2021-06-24T11:46:09.0413450' AS DateTime2), CAST(N'2021-06-24T11:46:09.0413450' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (326, N'A', N'E', N'H', CAST(N'2021-06-24T11:46:09.0413450' AS DateTime2), CAST(N'2021-06-24T11:46:09.0413450' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (327, N'A', N'E', N'I', CAST(N'2021-06-24T11:46:09.0569667' AS DateTime2), CAST(N'2021-06-24T11:46:09.0569667' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (328, N'A', N'E', N'J', CAST(N'2021-06-24T11:46:09.0725880' AS DateTime2), CAST(N'2021-06-24T11:46:09.0725880' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (329, N'A', N'E', N'K', CAST(N'2021-06-24T11:46:09.0882116' AS DateTime2), CAST(N'2021-06-24T11:46:09.0882116' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (330, N'A', N'E', N'L', CAST(N'2021-06-24T11:46:09.1038318' AS DateTime2), CAST(N'2021-06-24T11:46:09.1038318' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (331, N'A', N'E', N'M', CAST(N'2021-06-24T11:46:09.1194202' AS DateTime2), CAST(N'2021-06-24T11:46:09.1194202' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (332, N'A', N'E', N'N', CAST(N'2021-06-24T11:46:09.1194202' AS DateTime2), CAST(N'2021-06-24T11:46:09.1194202' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (333, N'A', N'F', N'C', CAST(N'2021-06-24T11:46:09.1350430' AS DateTime2), CAST(N'2021-06-24T11:46:09.1350430' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (334, N'A', N'F', N'D', CAST(N'2021-06-24T11:46:09.1506659' AS DateTime2), CAST(N'2021-06-24T11:46:09.1506659' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (335, N'A', N'F', N'E', CAST(N'2021-06-24T11:46:09.1819364' AS DateTime2), CAST(N'2021-06-24T11:46:09.1819364' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (336, N'A', N'F', N'F', CAST(N'2021-06-24T11:46:09.1975283' AS DateTime2), CAST(N'2021-06-24T11:46:09.1975283' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (337, N'A', N'F', N'G', CAST(N'2021-06-24T11:46:09.1975283' AS DateTime2), CAST(N'2021-06-24T11:46:09.1975283' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (338, N'A', N'F', N'H', CAST(N'2021-06-24T11:46:09.2131488' AS DateTime2), CAST(N'2021-06-24T11:46:09.2131488' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (339, N'A', N'F', N'I', CAST(N'2021-06-24T11:46:09.2288019' AS DateTime2), CAST(N'2021-06-24T11:46:09.2288019' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (340, N'A', N'F', N'J', CAST(N'2021-06-24T11:46:09.2444236' AS DateTime2), CAST(N'2021-06-24T11:46:09.2444236' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (341, N'A', N'F', N'K', CAST(N'2021-06-24T11:46:09.2600437' AS DateTime2), CAST(N'2021-06-24T11:46:09.2600437' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (342, N'A', N'F', N'L', CAST(N'2021-06-24T11:46:09.2756662' AS DateTime2), CAST(N'2021-06-24T11:46:09.2756662' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (343, N'A', N'F', N'M', CAST(N'2021-06-24T11:46:09.3069115' AS DateTime2), CAST(N'2021-06-24T11:46:09.3069115' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (344, N'A', N'F', N'N', CAST(N'2021-06-24T11:46:09.3069115' AS DateTime2), CAST(N'2021-06-24T11:46:09.3069115' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (345, N'A', N'G', N'C', CAST(N'2021-06-24T11:46:09.3225294' AS DateTime2), CAST(N'2021-06-24T11:46:09.3225294' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (346, N'A', N'G', N'D', CAST(N'2021-06-24T11:46:09.3381227' AS DateTime2), CAST(N'2021-06-24T11:46:09.3381227' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (347, N'A', N'G', N'E', CAST(N'2021-06-24T11:46:09.3381227' AS DateTime2), CAST(N'2021-06-24T11:46:09.3381227' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (348, N'A', N'G', N'F', CAST(N'2021-06-24T11:46:09.3537731' AS DateTime2), CAST(N'2021-06-24T11:46:09.3537731' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (349, N'A', N'G', N'G', CAST(N'2021-06-24T11:46:09.3693695' AS DateTime2), CAST(N'2021-06-24T11:46:09.3693695' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (350, N'A', N'G', N'H', CAST(N'2021-06-24T11:46:09.3693695' AS DateTime2), CAST(N'2021-06-24T11:46:09.3693695' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (351, N'A', N'G', N'I', CAST(N'2021-06-24T11:46:09.3849859' AS DateTime2), CAST(N'2021-06-24T11:46:09.3849859' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (352, N'A', N'G', N'J', CAST(N'2021-06-24T11:46:10.4018344' AS DateTime2), CAST(N'2021-06-24T11:46:10.4018344' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (353, N'A', N'G', N'K', CAST(N'2021-06-24T11:46:10.4018344' AS DateTime2), CAST(N'2021-06-24T11:46:10.4018344' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (354, N'A', N'G', N'L', CAST(N'2021-06-24T11:46:10.4174912' AS DateTime2), CAST(N'2021-06-24T11:46:10.4174912' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (355, N'A', N'G', N'M', CAST(N'2021-06-24T11:46:10.4331099' AS DateTime2), CAST(N'2021-06-24T11:46:10.4331099' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (356, N'A', N'G', N'N', CAST(N'2021-06-24T11:46:10.4331099' AS DateTime2), CAST(N'2021-06-24T11:46:10.4331099' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (357, N'A', N'H', N'C', CAST(N'2021-06-24T11:46:10.4486972' AS DateTime2), CAST(N'2021-06-24T11:46:10.4486972' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (358, N'A', N'H', N'D', CAST(N'2021-06-24T11:46:10.4643502' AS DateTime2), CAST(N'2021-06-24T11:46:10.4643502' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (359, N'A', N'H', N'E', CAST(N'2021-06-24T11:46:10.4643502' AS DateTime2), CAST(N'2021-06-24T11:46:10.4643502' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (360, N'A', N'H', N'F', CAST(N'2021-06-24T11:46:10.4955925' AS DateTime2), CAST(N'2021-06-24T11:46:10.4955925' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (361, N'A', N'H', N'G', CAST(N'2021-06-24T11:46:10.5112138' AS DateTime2), CAST(N'2021-06-24T11:46:10.5112138' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (362, N'A', N'H', N'H', CAST(N'2021-06-24T11:46:10.5268045' AS DateTime2), CAST(N'2021-06-24T11:46:10.5268045' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (363, N'A', N'H', N'I', CAST(N'2021-06-24T11:46:10.5424568' AS DateTime2), CAST(N'2021-06-24T11:46:10.5424568' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (364, N'A', N'H', N'J', CAST(N'2021-06-24T11:46:10.5580811' AS DateTime2), CAST(N'2021-06-24T11:46:10.5580811' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (365, N'A', N'H', N'K', CAST(N'2021-06-24T11:46:10.5737009' AS DateTime2), CAST(N'2021-06-24T11:46:10.5737009' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (366, N'A', N'H', N'L', CAST(N'2021-06-24T11:46:10.6049428' AS DateTime2), CAST(N'2021-06-24T11:46:10.6049428' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (367, N'A', N'H', N'M', CAST(N'2021-06-24T11:46:10.6205645' AS DateTime2), CAST(N'2021-06-24T11:46:10.6205645' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (368, N'A', N'H', N'N', CAST(N'2021-06-24T11:46:10.6361548' AS DateTime2), CAST(N'2021-06-24T11:46:10.6361548' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (369, N'A', N'I', N'C', CAST(N'2021-06-24T11:46:10.6361548' AS DateTime2), CAST(N'2021-06-24T11:46:10.6361548' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (370, N'A', N'I', N'D', CAST(N'2021-06-24T11:46:10.6518071' AS DateTime2), CAST(N'2021-06-24T11:46:10.6518071' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (371, N'A', N'I', N'E', CAST(N'2021-06-24T11:46:10.6674284' AS DateTime2), CAST(N'2021-06-24T11:46:10.6674284' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (372, N'A', N'I', N'F', CAST(N'2021-06-24T11:46:10.6830520' AS DateTime2), CAST(N'2021-06-24T11:46:10.6830520' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (373, N'A', N'I', N'G', CAST(N'2021-06-24T11:46:10.6986710' AS DateTime2), CAST(N'2021-06-24T11:46:10.6986710' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (374, N'A', N'I', N'H', CAST(N'2021-06-24T11:46:10.7142621' AS DateTime2), CAST(N'2021-06-24T11:46:10.7142621' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (375, N'A', N'I', N'I', CAST(N'2021-06-24T11:46:10.7299137' AS DateTime2), CAST(N'2021-06-24T11:46:10.7299137' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (376, N'A', N'I', N'J', CAST(N'2021-06-24T11:46:10.7299137' AS DateTime2), CAST(N'2021-06-24T11:46:10.7299137' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (377, N'A', N'I', N'K', CAST(N'2021-06-24T11:46:10.7455342' AS DateTime2), CAST(N'2021-06-24T11:46:10.7455342' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (378, N'A', N'I', N'L', CAST(N'2021-06-24T11:46:10.7611559' AS DateTime2), CAST(N'2021-06-24T11:46:10.7611559' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (379, N'A', N'I', N'M', CAST(N'2021-06-24T11:46:10.7767772' AS DateTime2), CAST(N'2021-06-24T11:46:10.7767772' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (380, N'A', N'I', N'N', CAST(N'2021-06-24T11:46:10.7767772' AS DateTime2), CAST(N'2021-06-24T11:46:10.7767772' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (381, N'A', N'J', N'C', CAST(N'2021-06-24T11:46:10.8080221' AS DateTime2), CAST(N'2021-06-24T11:46:10.8080221' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (382, N'A', N'J', N'D', CAST(N'2021-06-24T11:46:10.8236472' AS DateTime2), CAST(N'2021-06-24T11:46:10.8236472' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (383, N'A', N'J', N'E', CAST(N'2021-06-24T11:46:10.8236472' AS DateTime2), CAST(N'2021-06-24T11:46:10.8236472' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (384, N'A', N'J', N'F', CAST(N'2021-06-24T11:46:10.8392311' AS DateTime2), CAST(N'2021-06-24T11:46:10.8392311' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (385, N'A', N'J', N'G', CAST(N'2021-06-24T11:46:10.8548830' AS DateTime2), CAST(N'2021-06-24T11:46:10.8548830' AS DateTime2), 2, 2, 1, NULL, N'')
GO
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (386, N'A', N'J', N'H', CAST(N'2021-06-24T11:46:10.8705055' AS DateTime2), CAST(N'2021-06-24T11:46:10.8705055' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (387, N'A', N'J', N'I', CAST(N'2021-06-24T11:46:10.8860966' AS DateTime2), CAST(N'2021-06-24T11:46:10.8860966' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (388, N'A', N'J', N'J', CAST(N'2021-06-24T11:46:10.8860966' AS DateTime2), CAST(N'2021-06-24T11:46:10.8860966' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (389, N'A', N'J', N'K', CAST(N'2021-06-24T11:46:10.9017485' AS DateTime2), CAST(N'2021-06-24T11:46:10.9017485' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (390, N'A', N'J', N'L', CAST(N'2021-06-24T11:46:10.9173690' AS DateTime2), CAST(N'2021-06-24T11:46:10.9173690' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (391, N'A', N'J', N'M', CAST(N'2021-06-24T11:46:10.9329613' AS DateTime2), CAST(N'2021-06-24T11:46:10.9329613' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (392, N'A', N'J', N'N', CAST(N'2021-06-24T11:46:10.9485837' AS DateTime2), CAST(N'2021-06-24T11:46:10.9485837' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (393, N'A', N'K', N'C', CAST(N'2021-06-24T11:46:10.9642337' AS DateTime2), CAST(N'2021-06-24T11:46:10.9642337' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (394, N'A', N'K', N'D', CAST(N'2021-06-24T11:46:10.9798547' AS DateTime2), CAST(N'2021-06-24T11:46:10.9798547' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (395, N'A', N'K', N'E', CAST(N'2021-06-24T11:46:10.9798547' AS DateTime2), CAST(N'2021-06-24T11:46:10.9798547' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (396, N'A', N'K', N'F', CAST(N'2021-06-24T11:46:10.9954446' AS DateTime2), CAST(N'2021-06-24T11:46:10.9954446' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (397, N'A', N'K', N'G', CAST(N'2021-06-24T11:46:11.0110694' AS DateTime2), CAST(N'2021-06-24T11:46:11.0110694' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (398, N'A', N'K', N'H', CAST(N'2021-06-24T11:46:11.0267201' AS DateTime2), CAST(N'2021-06-24T11:46:11.0267201' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (399, N'A', N'K', N'I', CAST(N'2021-06-24T11:46:11.0423407' AS DateTime2), CAST(N'2021-06-24T11:46:11.0423407' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (400, N'A', N'K', N'J', CAST(N'2021-06-24T11:46:11.0579612' AS DateTime2), CAST(N'2021-06-24T11:46:11.0579612' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (401, N'A', N'K', N'K', CAST(N'2021-06-24T11:46:11.0735837' AS DateTime2), CAST(N'2021-06-24T11:46:11.0735837' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (402, N'A', N'K', N'L', CAST(N'2021-06-24T11:46:11.0735837' AS DateTime2), CAST(N'2021-06-24T11:46:11.0735837' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (403, N'A', N'K', N'M', CAST(N'2021-06-24T11:46:11.0891755' AS DateTime2), CAST(N'2021-06-24T11:46:11.0891755' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (404, N'A', N'K', N'N', CAST(N'2021-06-24T11:46:11.1048259' AS DateTime2), CAST(N'2021-06-24T11:46:11.1048259' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (405, N'A', N'L', N'C', CAST(N'2021-06-24T11:46:11.1048259' AS DateTime2), CAST(N'2021-06-24T11:46:11.1048259' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (406, N'A', N'L', N'D', CAST(N'2021-06-24T11:46:11.1204476' AS DateTime2), CAST(N'2021-06-24T11:46:11.1204476' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (407, N'A', N'L', N'E', CAST(N'2021-06-24T11:46:11.1360387' AS DateTime2), CAST(N'2021-06-24T11:46:11.1360387' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (408, N'A', N'L', N'F', CAST(N'2021-06-24T11:46:11.1360387' AS DateTime2), CAST(N'2021-06-24T11:46:11.1360387' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (409, N'A', N'L', N'G', CAST(N'2021-06-24T11:46:11.1516581' AS DateTime2), CAST(N'2021-06-24T11:46:11.1516581' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (410, N'A', N'L', N'H', CAST(N'2021-06-24T11:46:11.1673119' AS DateTime2), CAST(N'2021-06-24T11:46:11.1673119' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (411, N'A', N'L', N'I', CAST(N'2021-06-24T11:46:11.1673119' AS DateTime2), CAST(N'2021-06-24T11:46:11.1673119' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (412, N'A', N'L', N'J', CAST(N'2021-06-24T11:46:11.1829363' AS DateTime2), CAST(N'2021-06-24T11:46:11.1829363' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (413, N'A', N'L', N'K', CAST(N'2021-06-24T11:46:11.1985546' AS DateTime2), CAST(N'2021-06-24T11:46:11.1985546' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (414, N'A', N'L', N'L', CAST(N'2021-06-24T11:46:11.1985546' AS DateTime2), CAST(N'2021-06-24T11:46:11.1985546' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (415, N'A', N'L', N'M', CAST(N'2021-06-24T11:46:11.2141759' AS DateTime2), CAST(N'2021-06-24T11:46:11.2141759' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (416, N'A', N'L', N'N', CAST(N'2021-06-24T11:46:11.2297662' AS DateTime2), CAST(N'2021-06-24T11:46:11.2297662' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (417, N'A', N'M', N'C', CAST(N'2021-06-24T11:46:11.2454185' AS DateTime2), CAST(N'2021-06-24T11:46:11.2454185' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (418, N'A', N'M', N'D', CAST(N'2021-06-24T11:46:11.2454185' AS DateTime2), CAST(N'2021-06-24T11:46:11.2454185' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (419, N'A', N'M', N'E', CAST(N'2021-06-24T11:46:11.2610134' AS DateTime2), CAST(N'2021-06-24T11:46:11.2610134' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (420, N'A', N'M', N'F', CAST(N'2021-06-24T11:46:11.2766611' AS DateTime2), CAST(N'2021-06-24T11:46:11.2766611' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (421, N'A', N'M', N'G', CAST(N'2021-06-24T11:46:11.2766611' AS DateTime2), CAST(N'2021-06-24T11:46:11.2766611' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (422, N'A', N'M', N'H', CAST(N'2021-06-24T11:46:11.2922526' AS DateTime2), CAST(N'2021-06-24T11:46:11.2922526' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (423, N'A', N'M', N'I', CAST(N'2021-06-24T11:46:11.3235266' AS DateTime2), CAST(N'2021-06-24T11:46:11.3235266' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (424, N'A', N'M', N'J', CAST(N'2021-06-24T11:46:11.3391471' AS DateTime2), CAST(N'2021-06-24T11:46:11.3391471' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (425, N'A', N'M', N'K', CAST(N'2021-06-24T11:46:11.3391471' AS DateTime2), CAST(N'2021-06-24T11:46:11.3391471' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (426, N'A', N'M', N'L', CAST(N'2021-06-24T11:46:11.3547363' AS DateTime2), CAST(N'2021-06-24T11:46:11.3547363' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (427, N'A', N'M', N'M', CAST(N'2021-06-24T11:46:11.3703898' AS DateTime2), CAST(N'2021-06-24T11:46:11.3703898' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (428, N'A', N'M', N'N', CAST(N'2021-06-24T11:46:11.3860114' AS DateTime2), CAST(N'2021-06-24T11:46:11.3860114' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (429, N'A', N'N', N'C', CAST(N'2021-06-24T11:46:11.4016328' AS DateTime2), CAST(N'2021-06-24T11:46:11.4016328' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (430, N'A', N'N', N'D', CAST(N'2021-06-24T11:46:11.4172507' AS DateTime2), CAST(N'2021-06-24T11:46:11.4172507' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (431, N'A', N'N', N'E', CAST(N'2021-06-24T11:46:11.4328769' AS DateTime2), CAST(N'2021-06-24T11:46:11.4328769' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (432, N'A', N'N', N'F', CAST(N'2021-06-24T11:46:11.4484971' AS DateTime2), CAST(N'2021-06-24T11:46:11.4484971' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (433, N'A', N'N', N'G', CAST(N'2021-06-24T11:46:11.4640863' AS DateTime2), CAST(N'2021-06-24T11:46:11.4640863' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (434, N'A', N'N', N'H', CAST(N'2021-06-24T11:46:11.4640863' AS DateTime2), CAST(N'2021-06-24T11:46:11.4640863' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (435, N'A', N'N', N'I', CAST(N'2021-06-24T11:46:11.4797386' AS DateTime2), CAST(N'2021-06-24T11:46:11.4797386' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (436, N'A', N'N', N'J', CAST(N'2021-06-24T11:46:11.4953595' AS DateTime2), CAST(N'2021-06-24T11:46:11.4953595' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (437, N'A', N'N', N'K', CAST(N'2021-06-24T11:46:11.4953595' AS DateTime2), CAST(N'2021-06-24T11:46:11.4953595' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (438, N'A', N'N', N'L', CAST(N'2021-06-24T11:46:11.5266014' AS DateTime2), CAST(N'2021-06-24T11:46:11.5266014' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (439, N'A', N'N', N'M', CAST(N'2021-06-24T11:46:11.5421936' AS DateTime2), CAST(N'2021-06-24T11:46:11.5421936' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (440, N'A', N'N', N'N', CAST(N'2021-06-24T11:46:11.5578149' AS DateTime2), CAST(N'2021-06-24T11:46:11.5578149' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (441, N'A', N'O', N'C', CAST(N'2021-06-24T11:46:11.5734683' AS DateTime2), CAST(N'2021-06-24T11:46:11.5734683' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (442, N'A', N'O', N'D', CAST(N'2021-06-24T11:46:11.5890881' AS DateTime2), CAST(N'2021-06-24T11:46:11.5890881' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (443, N'A', N'O', N'E', CAST(N'2021-06-24T11:46:11.6047094' AS DateTime2), CAST(N'2021-06-24T11:46:11.6047094' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (444, N'A', N'O', N'F', CAST(N'2021-06-24T11:46:11.6359524' AS DateTime2), CAST(N'2021-06-24T11:46:11.6359524' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (445, N'A', N'O', N'G', CAST(N'2021-06-24T11:46:11.6359524' AS DateTime2), CAST(N'2021-06-24T11:46:11.6359524' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (446, N'A', N'O', N'H', CAST(N'2021-06-24T11:46:11.6515428' AS DateTime2), CAST(N'2021-06-24T11:46:11.6515428' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (447, N'A', N'O', N'I', CAST(N'2021-06-24T11:46:11.6671656' AS DateTime2), CAST(N'2021-06-24T11:46:11.6671656' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (448, N'A', N'O', N'J', CAST(N'2021-06-24T11:46:11.6827847' AS DateTime2), CAST(N'2021-06-24T11:46:11.6827847' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (449, N'A', N'O', N'K', CAST(N'2021-06-24T11:46:11.6984381' AS DateTime2), CAST(N'2021-06-24T11:46:11.6984381' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (450, N'A', N'O', N'L', CAST(N'2021-06-24T11:46:11.7296486' AS DateTime2), CAST(N'2021-06-24T11:46:11.7296486' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (451, N'A', N'O', N'M', CAST(N'2021-06-24T11:46:11.7296486' AS DateTime2), CAST(N'2021-06-24T11:46:11.7296486' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (452, N'A', N'O', N'N', CAST(N'2021-06-24T11:46:11.7452737' AS DateTime2), CAST(N'2021-06-24T11:46:11.7452737' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (453, N'B', N'B', N'F', CAST(N'2021-06-24T11:46:11.7608935' AS DateTime2), CAST(N'2021-06-24T11:46:11.7608935' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (454, N'B', N'B', N'G', CAST(N'2021-06-24T11:46:11.7608935' AS DateTime2), CAST(N'2021-06-24T11:46:11.7608935' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (455, N'B', N'B', N'H', CAST(N'2021-06-24T11:46:11.7765159' AS DateTime2), CAST(N'2021-06-24T11:46:11.7765159' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (456, N'B', N'B', N'I', CAST(N'2021-06-24T11:46:11.7921660' AS DateTime2), CAST(N'2021-06-24T11:46:11.7921660' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (457, N'B', N'B', N'J', CAST(N'2021-06-24T11:46:11.8077888' AS DateTime2), CAST(N'2021-06-24T11:46:11.8077888' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (458, N'B', N'B', N'K', CAST(N'2021-06-24T11:46:11.8234093' AS DateTime2), CAST(N'2021-06-24T11:46:11.8234093' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (459, N'B', N'B', N'L', CAST(N'2021-06-24T11:46:11.8390299' AS DateTime2), CAST(N'2021-06-24T11:46:11.8390299' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (460, N'B', N'B', N'M', CAST(N'2021-06-24T11:46:11.8390299' AS DateTime2), CAST(N'2021-06-24T11:46:11.8390299' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (461, N'B', N'B', N'N', CAST(N'2021-06-24T11:46:11.8546202' AS DateTime2), CAST(N'2021-06-24T11:46:11.8546202' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (462, N'B', N'C', N'F', CAST(N'2021-06-24T11:46:11.8702423' AS DateTime2), CAST(N'2021-06-24T11:46:11.8702423' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (463, N'B', N'C', N'G', CAST(N'2021-06-24T11:46:11.8858632' AS DateTime2), CAST(N'2021-06-24T11:46:11.8858632' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (464, N'B', N'C', N'H', CAST(N'2021-06-24T11:46:11.8858632' AS DateTime2), CAST(N'2021-06-24T11:46:11.8858632' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (465, N'B', N'C', N'I', CAST(N'2021-06-24T11:46:11.9014830' AS DateTime2), CAST(N'2021-06-24T11:46:11.9014830' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (466, N'B', N'C', N'J', CAST(N'2021-06-24T11:46:11.9014830' AS DateTime2), CAST(N'2021-06-24T11:46:11.9014830' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (467, N'B', N'C', N'K', CAST(N'2021-06-24T11:46:11.9171059' AS DateTime2), CAST(N'2021-06-24T11:46:11.9171059' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (468, N'B', N'C', N'L', CAST(N'2021-06-24T11:46:11.9483802' AS DateTime2), CAST(N'2021-06-24T11:46:11.9483802' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (469, N'B', N'C', N'M', CAST(N'2021-06-24T11:46:11.9640011' AS DateTime2), CAST(N'2021-06-24T11:46:11.9640011' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (470, N'B', N'C', N'N', CAST(N'2021-06-24T11:46:11.9795919' AS DateTime2), CAST(N'2021-06-24T11:46:11.9795919' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (471, N'B', N'D', N'F', CAST(N'2021-06-24T11:46:11.9952151' AS DateTime2), CAST(N'2021-06-24T11:46:11.9952151' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (472, N'B', N'D', N'G', CAST(N'2021-06-24T11:46:12.0108658' AS DateTime2), CAST(N'2021-06-24T11:46:12.0108658' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (473, N'B', N'D', N'H', CAST(N'2021-06-24T11:46:12.0264573' AS DateTime2), CAST(N'2021-06-24T11:46:12.0264573' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (474, N'B', N'D', N'I', CAST(N'2021-06-24T11:46:12.0420775' AS DateTime2), CAST(N'2021-06-24T11:46:12.0420775' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (475, N'B', N'D', N'J', CAST(N'2021-06-24T11:46:12.0576973' AS DateTime2), CAST(N'2021-06-24T11:46:12.0576973' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (476, N'B', N'D', N'K', CAST(N'2021-06-24T11:46:12.0733197' AS DateTime2), CAST(N'2021-06-24T11:46:12.0733197' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (477, N'B', N'D', N'L', CAST(N'2021-06-24T11:46:12.0889747' AS DateTime2), CAST(N'2021-06-24T11:46:12.0889747' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (478, N'B', N'D', N'M', CAST(N'2021-06-24T11:46:12.0889747' AS DateTime2), CAST(N'2021-06-24T11:46:12.0889747' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (479, N'B', N'D', N'N', CAST(N'2021-06-24T11:46:12.1045624' AS DateTime2), CAST(N'2021-06-24T11:46:12.1045624' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (480, N'B', N'E', N'C', CAST(N'2021-06-24T11:46:12.1045624' AS DateTime2), CAST(N'2021-06-24T11:46:12.1045624' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (481, N'B', N'E', N'D', CAST(N'2021-06-24T11:46:12.1201826' AS DateTime2), CAST(N'2021-06-24T11:46:12.1201826' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (482, N'B', N'E', N'E', CAST(N'2021-06-24T11:46:12.1358042' AS DateTime2), CAST(N'2021-06-24T11:46:12.1358042' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (483, N'B', N'E', N'F', CAST(N'2021-06-24T11:46:12.1514259' AS DateTime2), CAST(N'2021-06-24T11:46:12.1514259' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (484, N'B', N'E', N'G', CAST(N'2021-06-24T11:46:12.1514259' AS DateTime2), CAST(N'2021-06-24T11:46:12.1514259' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (485, N'B', N'E', N'H', CAST(N'2021-06-24T11:46:12.1670790' AS DateTime2), CAST(N'2021-06-24T11:46:12.1670790' AS DateTime2), 2, 2, 1, NULL, N'')
GO
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (486, N'B', N'E', N'I', CAST(N'2021-06-24T11:46:12.1670790' AS DateTime2), CAST(N'2021-06-24T11:46:12.1670790' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (487, N'B', N'E', N'J', CAST(N'2021-06-24T11:46:12.1826727' AS DateTime2), CAST(N'2021-06-24T11:46:12.1826727' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (488, N'B', N'E', N'K', CAST(N'2021-06-24T11:46:12.1982925' AS DateTime2), CAST(N'2021-06-24T11:46:12.1982925' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (489, N'B', N'E', N'L', CAST(N'2021-06-24T11:46:12.1982925' AS DateTime2), CAST(N'2021-06-24T11:46:12.1982925' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (490, N'B', N'E', N'M', CAST(N'2021-06-24T11:46:12.2139429' AS DateTime2), CAST(N'2021-06-24T11:46:12.2139429' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (491, N'B', N'E', N'N', CAST(N'2021-06-24T11:46:12.2295427' AS DateTime2), CAST(N'2021-06-24T11:46:12.2295427' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (492, N'B', N'F', N'C', CAST(N'2021-06-24T11:46:12.2451648' AS DateTime2), CAST(N'2021-06-24T11:46:12.2451648' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (493, N'B', N'F', N'D', CAST(N'2021-06-24T11:46:12.2608061' AS DateTime2), CAST(N'2021-06-24T11:46:12.2608061' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (494, N'B', N'F', N'E', CAST(N'2021-06-24T11:46:12.2608061' AS DateTime2), CAST(N'2021-06-24T11:46:12.2608061' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (495, N'B', N'F', N'F', CAST(N'2021-06-24T11:46:12.2763991' AS DateTime2), CAST(N'2021-06-24T11:46:12.2763991' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (496, N'B', N'F', N'G', CAST(N'2021-06-24T11:46:12.2920491' AS DateTime2), CAST(N'2021-06-24T11:46:12.2920491' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (497, N'B', N'F', N'H', CAST(N'2021-06-24T11:46:12.3076727' AS DateTime2), CAST(N'2021-06-24T11:46:12.3076727' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (498, N'B', N'F', N'I', CAST(N'2021-06-24T11:46:12.3076727' AS DateTime2), CAST(N'2021-06-24T11:46:12.3076727' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (499, N'B', N'F', N'J', CAST(N'2021-06-24T11:46:12.3232611' AS DateTime2), CAST(N'2021-06-24T11:46:12.3232611' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (500, N'B', N'F', N'K', CAST(N'2021-06-24T11:46:12.3389142' AS DateTime2), CAST(N'2021-06-24T11:46:12.3389142' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (501, N'B', N'F', N'L', CAST(N'2021-06-24T11:46:12.3545034' AS DateTime2), CAST(N'2021-06-24T11:46:12.3545034' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (502, N'B', N'F', N'M', CAST(N'2021-06-24T11:46:12.3545034' AS DateTime2), CAST(N'2021-06-24T11:46:12.3545034' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (503, N'B', N'F', N'N', CAST(N'2021-06-24T11:46:12.3701557' AS DateTime2), CAST(N'2021-06-24T11:46:12.3701557' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (504, N'B', N'G', N'C', CAST(N'2021-06-24T11:46:12.3857456' AS DateTime2), CAST(N'2021-06-24T11:46:12.3857456' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (505, N'B', N'G', N'D', CAST(N'2021-06-24T11:46:12.3857456' AS DateTime2), CAST(N'2021-06-24T11:46:12.3857456' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (506, N'B', N'G', N'E', CAST(N'2021-06-24T11:46:12.4013688' AS DateTime2), CAST(N'2021-06-24T11:46:12.4013688' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (507, N'B', N'G', N'F', CAST(N'2021-06-24T11:46:12.4169898' AS DateTime2), CAST(N'2021-06-24T11:46:12.4169898' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (508, N'B', N'G', N'G', CAST(N'2021-06-24T11:46:12.4169898' AS DateTime2), CAST(N'2021-06-24T11:46:12.4169898' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (509, N'B', N'G', N'H', CAST(N'2021-06-24T11:46:12.4326432' AS DateTime2), CAST(N'2021-06-24T11:46:12.4326432' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (510, N'B', N'G', N'I', CAST(N'2021-06-24T11:46:12.4326432' AS DateTime2), CAST(N'2021-06-24T11:46:12.4326432' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (511, N'B', N'G', N'J', CAST(N'2021-06-24T11:46:12.4482343' AS DateTime2), CAST(N'2021-06-24T11:46:12.4482343' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (512, N'B', N'G', N'K', CAST(N'2021-06-24T11:46:12.4638843' AS DateTime2), CAST(N'2021-06-24T11:46:12.4638843' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (513, N'B', N'G', N'L', CAST(N'2021-06-24T11:46:12.4638843' AS DateTime2), CAST(N'2021-06-24T11:46:12.4638843' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (514, N'B', N'G', N'M', CAST(N'2021-06-24T11:46:12.4794780' AS DateTime2), CAST(N'2021-06-24T11:46:12.4794780' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (515, N'B', N'G', N'N', CAST(N'2021-06-24T11:46:12.4950967' AS DateTime2), CAST(N'2021-06-24T11:46:12.4950967' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (516, N'B', N'H', N'C', CAST(N'2021-06-24T11:46:12.5107478' AS DateTime2), CAST(N'2021-06-24T11:46:12.5107478' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (517, N'B', N'H', N'D', CAST(N'2021-06-24T11:46:12.5263397' AS DateTime2), CAST(N'2021-06-24T11:46:12.5263397' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (518, N'B', N'H', N'E', CAST(N'2021-06-24T11:46:12.5263397' AS DateTime2), CAST(N'2021-06-24T11:46:12.5263397' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (519, N'B', N'H', N'F', CAST(N'2021-06-24T11:46:12.5419591' AS DateTime2), CAST(N'2021-06-24T11:46:12.5419591' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (520, N'B', N'H', N'G', CAST(N'2021-06-24T11:46:12.5575827' AS DateTime2), CAST(N'2021-06-24T11:46:12.5575827' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (521, N'B', N'H', N'H', CAST(N'2021-06-24T11:46:12.5575827' AS DateTime2), CAST(N'2021-06-24T11:46:12.5575827' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (522, N'B', N'H', N'I', CAST(N'2021-06-24T11:46:12.5732346' AS DateTime2), CAST(N'2021-06-24T11:46:12.5732346' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (523, N'B', N'H', N'J', CAST(N'2021-06-24T11:46:12.5888555' AS DateTime2), CAST(N'2021-06-24T11:46:12.5888555' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (524, N'B', N'H', N'K', CAST(N'2021-06-24T11:46:12.6044761' AS DateTime2), CAST(N'2021-06-24T11:46:12.6044761' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (525, N'B', N'H', N'L', CAST(N'2021-06-24T11:46:12.6200672' AS DateTime2), CAST(N'2021-06-24T11:46:12.6200672' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (526, N'B', N'H', N'M', CAST(N'2021-06-24T11:46:12.6357187' AS DateTime2), CAST(N'2021-06-24T11:46:12.6357187' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (527, N'B', N'H', N'N', CAST(N'2021-06-24T11:46:12.6513397' AS DateTime2), CAST(N'2021-06-24T11:46:12.6513397' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (528, N'B', N'I', N'C', CAST(N'2021-06-24T11:46:12.6669330' AS DateTime2), CAST(N'2021-06-24T11:46:12.6669330' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (529, N'B', N'I', N'D', CAST(N'2021-06-24T11:46:12.6669330' AS DateTime2), CAST(N'2021-06-24T11:46:12.6669330' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (530, N'B', N'I', N'E', CAST(N'2021-06-24T11:46:12.6825861' AS DateTime2), CAST(N'2021-06-24T11:46:12.6825861' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (531, N'B', N'I', N'F', CAST(N'2021-06-24T11:46:12.6982051' AS DateTime2), CAST(N'2021-06-24T11:46:12.6982051' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (532, N'B', N'I', N'G', CAST(N'2021-06-24T11:46:12.7138298' AS DateTime2), CAST(N'2021-06-24T11:46:12.7138298' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (533, N'B', N'I', N'H', CAST(N'2021-06-24T11:46:12.7294156' AS DateTime2), CAST(N'2021-06-24T11:46:12.7294156' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (534, N'B', N'I', N'I', CAST(N'2021-06-24T11:46:12.7450683' AS DateTime2), CAST(N'2021-06-24T11:46:12.7450683' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (535, N'B', N'I', N'J', CAST(N'2021-06-24T11:46:12.7450683' AS DateTime2), CAST(N'2021-06-24T11:46:12.7450683' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (536, N'B', N'I', N'K', CAST(N'2021-06-24T11:46:12.7606900' AS DateTime2), CAST(N'2021-06-24T11:46:12.7606900' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (537, N'B', N'I', N'L', CAST(N'2021-06-24T11:46:12.7762796' AS DateTime2), CAST(N'2021-06-24T11:46:12.7762796' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (538, N'B', N'I', N'M', CAST(N'2021-06-24T11:46:12.7919330' AS DateTime2), CAST(N'2021-06-24T11:46:12.7919330' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (539, N'B', N'I', N'N', CAST(N'2021-06-24T11:46:12.7919330' AS DateTime2), CAST(N'2021-06-24T11:46:12.7919330' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (540, N'B', N'J', N'C', CAST(N'2021-06-24T11:46:12.8075233' AS DateTime2), CAST(N'2021-06-24T11:46:12.8075233' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (541, N'B', N'J', N'D', CAST(N'2021-06-24T11:46:12.8231813' AS DateTime2), CAST(N'2021-06-24T11:46:12.8231813' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (542, N'B', N'J', N'E', CAST(N'2021-06-24T11:46:12.8387648' AS DateTime2), CAST(N'2021-06-24T11:46:12.8387648' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (543, N'B', N'J', N'F', CAST(N'2021-06-24T11:46:12.8387648' AS DateTime2), CAST(N'2021-06-24T11:46:12.8387648' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (544, N'B', N'J', N'G', CAST(N'2021-06-24T11:46:12.8543903' AS DateTime2), CAST(N'2021-06-24T11:46:12.8543903' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (545, N'B', N'J', N'H', CAST(N'2021-06-24T11:46:12.8700407' AS DateTime2), CAST(N'2021-06-24T11:46:12.8700407' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (546, N'B', N'J', N'I', CAST(N'2021-06-24T11:46:12.8856605' AS DateTime2), CAST(N'2021-06-24T11:46:12.8856605' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (547, N'B', N'J', N'J', CAST(N'2021-06-24T11:46:12.9012825' AS DateTime2), CAST(N'2021-06-24T11:46:12.9012825' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (548, N'B', N'J', N'K', CAST(N'2021-06-24T11:46:12.9169039' AS DateTime2), CAST(N'2021-06-24T11:46:12.9169039' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (549, N'B', N'J', N'L', CAST(N'2021-06-24T11:46:12.9325267' AS DateTime2), CAST(N'2021-06-24T11:46:12.9325267' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (550, N'B', N'J', N'M', CAST(N'2021-06-24T11:46:12.9325267' AS DateTime2), CAST(N'2021-06-24T11:46:12.9325267' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (551, N'B', N'J', N'N', CAST(N'2021-06-24T11:46:12.9481167' AS DateTime2), CAST(N'2021-06-24T11:46:12.9637391' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (552, N'B', N'K', N'C', CAST(N'2021-06-24T11:46:12.9637391' AS DateTime2), CAST(N'2021-06-24T11:46:12.9637391' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (553, N'B', N'K', N'D', CAST(N'2021-06-24T11:46:12.9793891' AS DateTime2), CAST(N'2021-06-24T11:46:12.9793891' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (554, N'B', N'K', N'E', CAST(N'2021-06-24T11:46:12.9950100' AS DateTime2), CAST(N'2021-06-24T11:46:12.9950100' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (555, N'B', N'K', N'F', CAST(N'2021-06-24T11:46:12.9950100' AS DateTime2), CAST(N'2021-06-24T11:46:12.9950100' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (556, N'B', N'K', N'G', CAST(N'2021-06-24T11:46:13.0106008' AS DateTime2), CAST(N'2021-06-24T11:46:13.0106008' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (557, N'B', N'K', N'H', CAST(N'2021-06-24T11:46:13.0262417' AS DateTime2), CAST(N'2021-06-24T11:46:13.0262417' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (558, N'B', N'K', N'I', CAST(N'2021-06-24T11:46:13.0262417' AS DateTime2), CAST(N'2021-06-24T11:46:13.0262417' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (559, N'B', N'K', N'J', CAST(N'2021-06-24T11:46:13.0574647' AS DateTime2), CAST(N'2021-06-24T11:46:13.0574647' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (560, N'B', N'K', N'K', CAST(N'2021-06-24T11:46:13.0574647' AS DateTime2), CAST(N'2021-06-24T11:46:13.0574647' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (561, N'B', N'K', N'L', CAST(N'2021-06-24T11:46:13.0731185' AS DateTime2), CAST(N'2021-06-24T11:46:13.0731185' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (562, N'B', N'K', N'M', CAST(N'2021-06-24T11:46:13.0887085' AS DateTime2), CAST(N'2021-06-24T11:46:13.0887085' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (563, N'B', N'K', N'N', CAST(N'2021-06-24T11:46:13.0887085' AS DateTime2), CAST(N'2021-06-24T11:46:13.0887085' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (564, N'B', N'L', N'C', CAST(N'2021-06-24T11:46:13.1043283' AS DateTime2), CAST(N'2021-06-24T11:46:13.1043283' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (565, N'B', N'L', N'D', CAST(N'2021-06-24T11:46:13.1199813' AS DateTime2), CAST(N'2021-06-24T11:46:13.1199813' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (566, N'B', N'L', N'E', CAST(N'2021-06-24T11:46:13.1355709' AS DateTime2), CAST(N'2021-06-24T11:46:13.1355709' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (567, N'B', N'L', N'F', CAST(N'2021-06-24T11:46:13.1512236' AS DateTime2), CAST(N'2021-06-24T11:46:13.1512236' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (568, N'B', N'L', N'G', CAST(N'2021-06-24T11:46:13.1668456' AS DateTime2), CAST(N'2021-06-24T11:46:13.1668456' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (569, N'B', N'L', N'H', CAST(N'2021-06-24T11:46:13.1824673' AS DateTime2), CAST(N'2021-06-24T11:46:13.1824673' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (570, N'B', N'L', N'I', CAST(N'2021-06-24T11:46:13.1824673' AS DateTime2), CAST(N'2021-06-24T11:46:13.1824673' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (571, N'B', N'L', N'J', CAST(N'2021-06-24T11:46:13.1980565' AS DateTime2), CAST(N'2021-06-24T11:46:13.1980565' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (572, N'B', N'L', N'K', CAST(N'2021-06-24T11:46:13.2137096' AS DateTime2), CAST(N'2021-06-24T11:46:13.2137096' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (573, N'B', N'L', N'L', CAST(N'2021-06-24T11:46:13.2137096' AS DateTime2), CAST(N'2021-06-24T11:46:13.2137096' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (574, N'B', N'L', N'M', CAST(N'2021-06-24T11:46:13.2293007' AS DateTime2), CAST(N'2021-06-24T11:46:13.2293007' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (575, N'B', N'L', N'N', CAST(N'2021-06-24T11:46:13.2449522' AS DateTime2), CAST(N'2021-06-24T11:46:13.2449522' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (576, N'B', N'M', N'C', CAST(N'2021-06-24T11:46:13.2605750' AS DateTime2), CAST(N'2021-06-24T11:46:13.2605750' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (577, N'B', N'M', N'D', CAST(N'2021-06-24T11:46:13.2605750' AS DateTime2), CAST(N'2021-06-24T11:46:13.2605750' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (578, N'B', N'M', N'E', CAST(N'2021-06-24T11:46:13.2761638' AS DateTime2), CAST(N'2021-06-24T11:46:13.2761638' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (579, N'B', N'M', N'F', CAST(N'2021-06-24T11:46:13.2918161' AS DateTime2), CAST(N'2021-06-24T11:46:13.2918161' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (580, N'B', N'M', N'G', CAST(N'2021-06-24T11:46:13.3074401' AS DateTime2), CAST(N'2021-06-24T11:46:13.3074401' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (581, N'B', N'M', N'H', CAST(N'2021-06-24T11:46:13.3074401' AS DateTime2), CAST(N'2021-06-24T11:46:13.3074401' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (582, N'B', N'M', N'I', CAST(N'2021-06-24T11:46:13.3230274' AS DateTime2), CAST(N'2021-06-24T11:46:13.3230274' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (583, N'B', N'M', N'J', CAST(N'2021-06-24T11:46:13.3386819' AS DateTime2), CAST(N'2021-06-24T11:46:13.3386819' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (584, N'B', N'M', N'K', CAST(N'2021-06-24T11:46:13.3543033' AS DateTime2), CAST(N'2021-06-24T11:46:13.3543033' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (585, N'B', N'M', N'L', CAST(N'2021-06-24T11:46:13.3699242' AS DateTime2), CAST(N'2021-06-24T11:46:13.3699242' AS DateTime2), 2, 2, 1, NULL, N'')
GO
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (586, N'B', N'M', N'M', CAST(N'2021-06-24T11:46:13.3855142' AS DateTime2), CAST(N'2021-06-24T11:46:13.3855142' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (587, N'B', N'M', N'N', CAST(N'2021-06-24T11:46:13.3855142' AS DateTime2), CAST(N'2021-06-24T11:46:13.3855142' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (588, N'B', N'N', N'C', CAST(N'2021-06-24T11:46:13.4011676' AS DateTime2), CAST(N'2021-06-24T11:46:13.4011676' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (589, N'B', N'N', N'D', CAST(N'2021-06-24T11:46:13.4167564' AS DateTime2), CAST(N'2021-06-24T11:46:13.4167564' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (590, N'B', N'N', N'E', CAST(N'2021-06-24T11:46:13.4167564' AS DateTime2), CAST(N'2021-06-24T11:46:13.4167564' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (591, N'B', N'N', N'F', CAST(N'2021-06-24T11:46:13.4324113' AS DateTime2), CAST(N'2021-06-24T11:46:13.4324113' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (592, N'B', N'N', N'G', CAST(N'2021-06-24T11:46:13.4324113' AS DateTime2), CAST(N'2021-06-24T11:46:13.4324113' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (593, N'B', N'N', N'H', CAST(N'2021-06-24T11:46:13.4479987' AS DateTime2), CAST(N'2021-06-24T11:46:13.4479987' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (594, N'B', N'N', N'I', CAST(N'2021-06-24T11:46:13.4636513' AS DateTime2), CAST(N'2021-06-24T11:46:13.4636513' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (595, N'B', N'N', N'J', CAST(N'2021-06-24T11:46:13.4792417' AS DateTime2), CAST(N'2021-06-24T11:46:13.4792417' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (596, N'B', N'N', N'K', CAST(N'2021-06-24T11:46:13.4792417' AS DateTime2), CAST(N'2021-06-24T11:46:13.4792417' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (597, N'B', N'N', N'L', CAST(N'2021-06-24T11:46:13.4948626' AS DateTime2), CAST(N'2021-06-24T11:46:13.4948626' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (598, N'B', N'N', N'M', CAST(N'2021-06-24T11:46:13.5105156' AS DateTime2), CAST(N'2021-06-24T11:46:13.5105156' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (599, N'B', N'N', N'N', CAST(N'2021-06-24T11:46:13.5261362' AS DateTime2), CAST(N'2021-06-24T11:46:13.5261362' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (600, N'B', N'O', N'C', CAST(N'2021-06-24T11:46:13.5261362' AS DateTime2), CAST(N'2021-06-24T11:46:13.5261362' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (601, N'B', N'O', N'D', CAST(N'2021-06-24T11:46:13.5417299' AS DateTime2), CAST(N'2021-06-24T11:46:13.5417299' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (602, N'B', N'O', N'E', CAST(N'2021-06-24T11:46:13.5573818' AS DateTime2), CAST(N'2021-06-24T11:46:13.5573818' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (603, N'B', N'O', N'F', CAST(N'2021-06-24T11:46:13.5730016' AS DateTime2), CAST(N'2021-06-24T11:46:13.5730016' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (604, N'B', N'O', N'G', CAST(N'2021-06-24T11:46:13.5885916' AS DateTime2), CAST(N'2021-06-24T11:46:13.5885916' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (605, N'B', N'O', N'H', CAST(N'2021-06-24T11:46:13.5885916' AS DateTime2), CAST(N'2021-06-24T11:46:13.5885916' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (606, N'B', N'O', N'I', CAST(N'2021-06-24T11:46:13.6042125' AS DateTime2), CAST(N'2021-06-24T11:46:13.6042125' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (607, N'B', N'O', N'J', CAST(N'2021-06-24T11:46:13.6198648' AS DateTime2), CAST(N'2021-06-24T11:46:13.6198648' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (608, N'B', N'O', N'K', CAST(N'2021-06-24T11:46:13.6354861' AS DateTime2), CAST(N'2021-06-24T11:46:13.6354861' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (609, N'B', N'O', N'L', CAST(N'2021-06-24T11:46:13.6354861' AS DateTime2), CAST(N'2021-06-24T11:46:13.6354861' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (610, N'B', N'O', N'M', CAST(N'2021-06-24T11:46:13.6511078' AS DateTime2), CAST(N'2021-06-24T11:46:13.6511078' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (611, N'B', N'O', N'N', CAST(N'2021-06-24T11:46:13.6666989' AS DateTime2), CAST(N'2021-06-24T11:46:13.6666989' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (612, N'C', N'B', N'F', CAST(N'2021-06-24T11:46:13.6666989' AS DateTime2), CAST(N'2021-06-24T11:46:13.6666989' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (613, N'C', N'B', N'G', CAST(N'2021-06-24T11:46:13.6823535' AS DateTime2), CAST(N'2021-06-24T11:46:13.6823535' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (614, N'C', N'B', N'H', CAST(N'2021-06-24T11:46:13.6979721' AS DateTime2), CAST(N'2021-06-24T11:46:13.6979721' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (615, N'C', N'B', N'I', CAST(N'2021-06-24T11:46:13.7135614' AS DateTime2), CAST(N'2021-06-24T11:46:13.7135614' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (616, N'C', N'B', N'J', CAST(N'2021-06-24T11:46:13.7292151' AS DateTime2), CAST(N'2021-06-24T11:46:13.7292151' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (617, N'C', N'B', N'K', CAST(N'2021-06-24T11:46:13.7292151' AS DateTime2), CAST(N'2021-06-24T11:46:13.7292151' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (618, N'C', N'B', N'L', CAST(N'2021-06-24T11:46:13.7604249' AS DateTime2), CAST(N'2021-06-24T11:46:13.7604249' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (619, N'C', N'B', N'M', CAST(N'2021-06-24T11:46:13.7760466' AS DateTime2), CAST(N'2021-06-24T11:46:13.7760466' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (620, N'C', N'B', N'N', CAST(N'2021-06-24T11:46:13.7916996' AS DateTime2), CAST(N'2021-06-24T11:46:13.7916996' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (621, N'C', N'C', N'F', CAST(N'2021-06-24T11:46:13.8073240' AS DateTime2), CAST(N'2021-06-24T11:46:13.8073240' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (622, N'C', N'C', N'G', CAST(N'2021-06-24T11:46:13.8073240' AS DateTime2), CAST(N'2021-06-24T11:46:13.8073240' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (623, N'C', N'C', N'H', CAST(N'2021-06-24T11:46:13.8229121' AS DateTime2), CAST(N'2021-06-24T11:46:13.8229121' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (624, N'C', N'C', N'I', CAST(N'2021-06-24T11:46:13.8385640' AS DateTime2), CAST(N'2021-06-24T11:46:13.8385640' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (625, N'C', N'C', N'J', CAST(N'2021-06-24T11:46:13.8541856' AS DateTime2), CAST(N'2021-06-24T11:46:13.8541856' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (626, N'C', N'C', N'K', CAST(N'2021-06-24T11:46:13.8541856' AS DateTime2), CAST(N'2021-06-24T11:46:13.8541856' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (627, N'C', N'C', N'L', CAST(N'2021-06-24T11:46:13.8698062' AS DateTime2), CAST(N'2021-06-24T11:46:13.8698062' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (628, N'C', N'C', N'M', CAST(N'2021-06-24T11:46:13.8854275' AS DateTime2), CAST(N'2021-06-24T11:46:13.8854275' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (629, N'C', N'C', N'N', CAST(N'2021-06-24T11:46:13.9010503' AS DateTime2), CAST(N'2021-06-24T11:46:13.9010503' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (630, N'C', N'D', N'F', CAST(N'2021-06-24T11:46:13.9166396' AS DateTime2), CAST(N'2021-06-24T11:46:13.9166396' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (631, N'C', N'D', N'G', CAST(N'2021-06-24T11:46:13.9166396' AS DateTime2), CAST(N'2021-06-24T11:46:13.9166396' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (632, N'C', N'D', N'H', CAST(N'2021-06-24T11:46:13.9322628' AS DateTime2), CAST(N'2021-06-24T11:46:13.9322628' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (633, N'C', N'D', N'I', CAST(N'2021-06-24T11:46:13.9479143' AS DateTime2), CAST(N'2021-06-24T11:46:13.9479143' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (634, N'C', N'D', N'J', CAST(N'2021-06-24T11:46:13.9635352' AS DateTime2), CAST(N'2021-06-24T11:46:13.9635352' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (635, N'C', N'D', N'K', CAST(N'2021-06-24T11:46:13.9791558' AS DateTime2), CAST(N'2021-06-24T11:46:13.9791558' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (636, N'C', N'D', N'L', CAST(N'2021-06-24T11:46:13.9947775' AS DateTime2), CAST(N'2021-06-24T11:46:13.9947775' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (637, N'C', N'D', N'M', CAST(N'2021-06-24T11:46:13.9947775' AS DateTime2), CAST(N'2021-06-24T11:46:13.9947775' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (638, N'C', N'D', N'N', CAST(N'2021-06-24T11:46:14.0103678' AS DateTime2), CAST(N'2021-06-24T11:46:14.0103678' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (639, N'C', N'E', N'C', CAST(N'2021-06-24T11:46:14.0259918' AS DateTime2), CAST(N'2021-06-24T11:46:14.0259918' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (640, N'C', N'E', N'D', CAST(N'2021-06-24T11:46:14.0416414' AS DateTime2), CAST(N'2021-06-24T11:46:14.0416414' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (641, N'C', N'E', N'E', CAST(N'2021-06-24T11:46:14.0416414' AS DateTime2), CAST(N'2021-06-24T11:46:14.0416414' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (642, N'C', N'E', N'F', CAST(N'2021-06-24T11:46:14.0572325' AS DateTime2), CAST(N'2021-06-24T11:46:14.0572325' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (643, N'C', N'E', N'G', CAST(N'2021-06-24T11:46:14.0728527' AS DateTime2), CAST(N'2021-06-24T11:46:14.0728527' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (644, N'C', N'E', N'H', CAST(N'2021-06-24T11:46:14.0885065' AS DateTime2), CAST(N'2021-06-24T11:46:14.0885065' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (645, N'C', N'E', N'I', CAST(N'2021-06-24T11:46:14.1041266' AS DateTime2), CAST(N'2021-06-24T11:46:14.1041266' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (646, N'C', N'E', N'J', CAST(N'2021-06-24T11:46:14.1197193' AS DateTime2), CAST(N'2021-06-24T11:46:14.1197193' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (647, N'C', N'E', N'K', CAST(N'2021-06-24T11:46:14.1353402' AS DateTime2), CAST(N'2021-06-24T11:46:14.1353402' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (648, N'C', N'E', N'L', CAST(N'2021-06-24T11:46:14.1353402' AS DateTime2), CAST(N'2021-06-24T11:46:14.1353402' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (649, N'C', N'E', N'M', CAST(N'2021-06-24T11:46:14.1680123' AS DateTime2), CAST(N'2021-06-24T11:46:14.1680123' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (650, N'C', N'E', N'N', CAST(N'2021-06-24T11:46:14.1819757' AS DateTime2), CAST(N'2021-06-24T11:46:14.1819757' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (651, N'C', N'F', N'C', CAST(N'2021-06-24T11:46:14.1939424' AS DateTime2), CAST(N'2021-06-24T11:46:14.1939424' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (652, N'C', N'F', N'D', CAST(N'2021-06-24T11:46:14.2079050' AS DateTime2), CAST(N'2021-06-24T11:46:14.2079050' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (653, N'C', N'F', N'E', CAST(N'2021-06-24T11:46:14.2188756' AS DateTime2), CAST(N'2021-06-24T11:46:14.2188756' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (654, N'C', N'F', N'F', CAST(N'2021-06-24T11:46:14.2308446' AS DateTime2), CAST(N'2021-06-24T11:46:14.2308446' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (655, N'C', N'F', N'G', CAST(N'2021-06-24T11:46:14.2448053' AS DateTime2), CAST(N'2021-06-24T11:46:14.2448053' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (656, N'C', N'F', N'H', CAST(N'2021-06-24T11:46:14.2557786' AS DateTime2), CAST(N'2021-06-24T11:46:14.2557786' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (657, N'C', N'F', N'I', CAST(N'2021-06-24T11:46:14.2667481' AS DateTime2), CAST(N'2021-06-24T11:46:14.2667481' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (658, N'C', N'F', N'J', CAST(N'2021-06-24T11:46:14.2827047' AS DateTime2), CAST(N'2021-06-24T11:46:14.2827047' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (659, N'C', N'F', N'K', CAST(N'2021-06-24T11:46:14.2976656' AS DateTime2), CAST(N'2021-06-24T11:46:14.2976656' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (660, N'C', N'F', N'L', CAST(N'2021-06-24T11:46:14.3225992' AS DateTime2), CAST(N'2021-06-24T11:46:14.3225992' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (661, N'C', N'F', N'M', CAST(N'2021-06-24T11:46:14.3405502' AS DateTime2), CAST(N'2021-06-24T11:46:14.3405502' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (662, N'C', N'F', N'N', CAST(N'2021-06-24T11:46:14.3575052' AS DateTime2), CAST(N'2021-06-24T11:46:14.3575052' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (663, N'C', N'G', N'C', CAST(N'2021-06-24T11:46:14.3714681' AS DateTime2), CAST(N'2021-06-24T11:46:14.3714681' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (664, N'C', N'G', N'D', CAST(N'2021-06-24T11:46:14.3874247' AS DateTime2), CAST(N'2021-06-24T11:46:14.3874247' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (665, N'C', N'G', N'E', CAST(N'2021-06-24T11:46:14.4043804' AS DateTime2), CAST(N'2021-06-24T11:46:14.4043804' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (666, N'C', N'G', N'F', CAST(N'2021-06-24T11:46:14.4362948' AS DateTime2), CAST(N'2021-06-24T11:46:14.4362948' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (667, N'C', N'G', N'G', CAST(N'2021-06-24T11:46:14.4472711' AS DateTime2), CAST(N'2021-06-24T11:46:14.4472711' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (668, N'C', N'G', N'H', CAST(N'2021-06-24T11:46:14.4642192' AS DateTime2), CAST(N'2021-06-24T11:46:14.4642192' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (669, N'C', N'G', N'I', CAST(N'2021-06-24T11:46:14.4781822' AS DateTime2), CAST(N'2021-06-24T11:46:14.4781822' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (670, N'C', N'G', N'J', CAST(N'2021-06-24T11:46:14.4931427' AS DateTime2), CAST(N'2021-06-24T11:46:14.4931427' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (671, N'C', N'G', N'K', CAST(N'2021-06-24T11:46:14.5051124' AS DateTime2), CAST(N'2021-06-24T11:46:14.5051124' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (672, N'C', N'G', N'L', CAST(N'2021-06-24T11:46:14.5150832' AS DateTime2), CAST(N'2021-06-24T11:46:14.5150832' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (673, N'C', N'G', N'M', CAST(N'2021-06-24T11:46:14.5280502' AS DateTime2), CAST(N'2021-06-24T11:46:14.5280502' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (674, N'C', N'G', N'N', CAST(N'2021-06-24T11:46:14.5440064' AS DateTime2), CAST(N'2021-06-24T11:46:14.5440064' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (675, N'C', N'H', N'C', CAST(N'2021-06-24T11:46:14.5569729' AS DateTime2), CAST(N'2021-06-24T11:46:14.5569729' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (676, N'C', N'H', N'D', CAST(N'2021-06-24T11:46:14.5729299' AS DateTime2), CAST(N'2021-06-24T11:46:14.5729299' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (677, N'C', N'H', N'E', CAST(N'2021-06-24T11:46:14.5868921' AS DateTime2), CAST(N'2021-06-24T11:46:14.5868921' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (678, N'C', N'H', N'F', CAST(N'2021-06-24T11:46:14.6008540' AS DateTime2), CAST(N'2021-06-24T11:46:14.6008540' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (679, N'C', N'H', N'G', CAST(N'2021-06-24T11:46:14.6188068' AS DateTime2), CAST(N'2021-06-24T11:46:14.6188068' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (680, N'C', N'H', N'H', CAST(N'2021-06-24T11:46:14.6407474' AS DateTime2), CAST(N'2021-06-24T11:46:14.6407474' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (681, N'C', N'H', N'I', CAST(N'2021-06-24T11:46:14.6520642' AS DateTime2), CAST(N'2021-06-24T11:46:14.6520642' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (682, N'C', N'H', N'J', CAST(N'2021-06-24T11:46:14.6520642' AS DateTime2), CAST(N'2021-06-24T11:46:14.6520642' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (683, N'C', N'H', N'K', CAST(N'2021-06-24T11:46:14.6676871' AS DateTime2), CAST(N'2021-06-24T11:46:14.6676871' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (684, N'C', N'H', N'L', CAST(N'2021-06-24T11:46:14.6676871' AS DateTime2), CAST(N'2021-06-24T11:46:14.6676871' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (685, N'C', N'H', N'M', CAST(N'2021-06-24T11:46:14.6833390' AS DateTime2), CAST(N'2021-06-24T11:46:14.6833390' AS DateTime2), 2, 2, 1, NULL, N'')
GO
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (686, N'C', N'H', N'N', CAST(N'2021-06-24T11:46:14.6989599' AS DateTime2), CAST(N'2021-06-24T11:46:14.6989599' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (687, N'C', N'I', N'C', CAST(N'2021-06-24T11:46:14.6989599' AS DateTime2), CAST(N'2021-06-24T11:46:14.6989599' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (688, N'C', N'I', N'D', CAST(N'2021-06-24T11:46:14.7145502' AS DateTime2), CAST(N'2021-06-24T11:46:14.7145502' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (689, N'C', N'I', N'E', CAST(N'2021-06-24T11:46:14.7302055' AS DateTime2), CAST(N'2021-06-24T11:46:14.7302055' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (690, N'C', N'I', N'F', CAST(N'2021-06-24T11:46:14.7457929' AS DateTime2), CAST(N'2021-06-24T11:46:14.7457929' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (691, N'C', N'I', N'G', CAST(N'2021-06-24T11:46:14.7457929' AS DateTime2), CAST(N'2021-06-24T11:46:14.7457929' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (692, N'C', N'I', N'H', CAST(N'2021-06-24T11:46:14.7614142' AS DateTime2), CAST(N'2021-06-24T11:46:14.7614142' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (693, N'C', N'I', N'I', CAST(N'2021-06-24T11:46:14.7770355' AS DateTime2), CAST(N'2021-06-24T11:46:14.7770355' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (694, N'C', N'I', N'J', CAST(N'2021-06-24T11:46:14.7770355' AS DateTime2), CAST(N'2021-06-24T11:46:14.7770355' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (695, N'C', N'I', N'K', CAST(N'2021-06-24T11:46:14.7926579' AS DateTime2), CAST(N'2021-06-24T11:46:14.7926579' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (696, N'C', N'I', N'L', CAST(N'2021-06-24T11:46:14.8082785' AS DateTime2), CAST(N'2021-06-24T11:46:14.8082785' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (697, N'C', N'I', N'M', CAST(N'2021-06-24T11:46:14.8238998' AS DateTime2), CAST(N'2021-06-24T11:46:14.8238998' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (698, N'C', N'I', N'N', CAST(N'2021-06-24T11:46:14.8395211' AS DateTime2), CAST(N'2021-06-24T11:46:14.8395211' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (699, N'C', N'J', N'C', CAST(N'2021-06-24T11:46:14.8395211' AS DateTime2), CAST(N'2021-06-24T11:46:14.8395211' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (700, N'C', N'J', N'D', CAST(N'2021-06-24T11:46:14.8551428' AS DateTime2), CAST(N'2021-06-24T11:46:14.8551428' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (701, N'C', N'J', N'E', CAST(N'2021-06-24T11:46:14.8707645' AS DateTime2), CAST(N'2021-06-24T11:46:14.8707645' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (702, N'C', N'J', N'F', CAST(N'2021-06-24T11:46:14.9022507' AS DateTime2), CAST(N'2021-06-24T11:46:14.9022507' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (703, N'C', N'J', N'G', CAST(N'2021-06-24T11:46:14.9361609' AS DateTime2), CAST(N'2021-06-24T11:46:14.9361609' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (704, N'C', N'J', N'H', CAST(N'2021-06-24T11:46:14.9451372' AS DateTime2), CAST(N'2021-06-24T11:46:14.9451372' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (705, N'C', N'J', N'I', CAST(N'2021-06-24T11:46:14.9581014' AS DateTime2), CAST(N'2021-06-24T11:46:14.9581014' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (706, N'C', N'J', N'J', CAST(N'2021-06-24T11:46:14.9730635' AS DateTime2), CAST(N'2021-06-24T11:46:14.9730635' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (707, N'C', N'J', N'K', CAST(N'2021-06-24T11:46:14.9860281' AS DateTime2), CAST(N'2021-06-24T11:46:14.9860281' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (708, N'C', N'J', N'L', CAST(N'2021-06-24T11:46:15.0239268' AS DateTime2), CAST(N'2021-06-24T11:46:15.0239268' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (709, N'C', N'J', N'M', CAST(N'2021-06-24T11:46:15.0378999' AS DateTime2), CAST(N'2021-06-24T11:46:15.0378999' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (710, N'C', N'J', N'N', CAST(N'2021-06-24T11:46:15.0518523' AS DateTime2), CAST(N'2021-06-24T11:46:15.0518523' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (711, N'C', N'K', N'C', CAST(N'2021-06-24T11:46:15.0648174' AS DateTime2), CAST(N'2021-06-24T11:46:15.0648174' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (712, N'C', N'K', N'D', CAST(N'2021-06-24T11:46:15.0797772' AS DateTime2), CAST(N'2021-06-24T11:46:15.0797772' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (713, N'C', N'K', N'E', CAST(N'2021-06-24T11:46:15.0987272' AS DateTime2), CAST(N'2021-06-24T11:46:15.0987272' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (714, N'C', N'K', N'F', CAST(N'2021-06-24T11:46:15.1655494' AS DateTime2), CAST(N'2021-06-24T11:46:15.1655494' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (715, N'C', N'K', N'G', CAST(N'2021-06-24T11:46:15.1874895' AS DateTime2), CAST(N'2021-06-24T11:46:15.1874895' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (716, N'C', N'K', N'H', CAST(N'2021-06-24T11:46:15.2014529' AS DateTime2), CAST(N'2021-06-24T11:46:15.2014529' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (717, N'C', N'K', N'I', CAST(N'2021-06-24T11:46:15.2243910' AS DateTime2), CAST(N'2021-06-24T11:46:15.2243910' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (718, N'C', N'K', N'J', CAST(N'2021-06-24T11:46:15.2403487' AS DateTime2), CAST(N'2021-06-24T11:46:15.2403487' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (719, N'C', N'K', N'K', CAST(N'2021-06-24T11:46:15.2563057' AS DateTime2), CAST(N'2021-06-24T11:46:15.2563057' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (720, N'C', N'K', N'L', CAST(N'2021-06-24T11:46:15.2732614' AS DateTime2), CAST(N'2021-06-24T11:46:15.2732614' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (721, N'C', N'K', N'M', CAST(N'2021-06-24T11:46:15.2882204' AS DateTime2), CAST(N'2021-06-24T11:46:15.2882204' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (722, N'C', N'K', N'N', CAST(N'2021-06-24T11:46:15.3061718' AS DateTime2), CAST(N'2021-06-24T11:46:15.3061718' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (723, N'C', N'L', N'C', CAST(N'2021-06-24T11:46:15.3181411' AS DateTime2), CAST(N'2021-06-24T11:46:15.3181411' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (724, N'C', N'L', N'D', CAST(N'2021-06-24T11:46:15.3281131' AS DateTime2), CAST(N'2021-06-24T11:46:15.3281131' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (725, N'C', N'L', N'E', CAST(N'2021-06-24T11:46:15.3470631' AS DateTime2), CAST(N'2021-06-24T11:46:15.3470631' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (726, N'C', N'L', N'F', CAST(N'2021-06-24T11:46:15.3590310' AS DateTime2), CAST(N'2021-06-24T11:46:15.3590310' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (727, N'C', N'L', N'G', CAST(N'2021-06-24T11:46:15.3709995' AS DateTime2), CAST(N'2021-06-24T11:46:15.3709995' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (728, N'C', N'L', N'H', CAST(N'2021-06-24T11:46:15.3859639' AS DateTime2), CAST(N'2021-06-24T11:46:15.3859639' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (729, N'C', N'L', N'I', CAST(N'2021-06-24T11:46:15.3969292' AS DateTime2), CAST(N'2021-06-24T11:46:15.3969292' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (730, N'C', N'L', N'J', CAST(N'2021-06-24T11:46:15.4188713' AS DateTime2), CAST(N'2021-06-24T11:46:15.4188713' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (731, N'C', N'L', N'K', CAST(N'2021-06-24T11:46:15.4223171' AS DateTime2), CAST(N'2021-06-24T11:46:15.4223171' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (732, N'C', N'L', N'L', CAST(N'2021-06-24T11:46:15.4379384' AS DateTime2), CAST(N'2021-06-24T11:46:15.4379384' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (733, N'C', N'L', N'M', CAST(N'2021-06-24T11:46:15.4535861' AS DateTime2), CAST(N'2021-06-24T11:46:15.4535861' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (734, N'C', N'L', N'N', CAST(N'2021-06-24T11:46:15.4535861' AS DateTime2), CAST(N'2021-06-24T11:46:15.4535861' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (735, N'C', N'M', N'C', CAST(N'2021-06-24T11:46:15.4691810' AS DateTime2), CAST(N'2021-06-24T11:46:15.4691810' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (736, N'C', N'M', N'D', CAST(N'2021-06-24T11:46:15.4848034' AS DateTime2), CAST(N'2021-06-24T11:46:15.4848034' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (737, N'C', N'M', N'E', CAST(N'2021-06-24T11:46:15.5004244' AS DateTime2), CAST(N'2021-06-24T11:46:15.5004244' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (738, N'C', N'M', N'F', CAST(N'2021-06-24T11:46:15.5160449' AS DateTime2), CAST(N'2021-06-24T11:46:15.5160449' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (739, N'C', N'M', N'G', CAST(N'2021-06-24T11:46:15.5160449' AS DateTime2), CAST(N'2021-06-24T11:46:15.5160449' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (740, N'C', N'M', N'H', CAST(N'2021-06-24T11:46:15.5316670' AS DateTime2), CAST(N'2021-06-24T11:46:15.5316670' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (741, N'C', N'M', N'I', CAST(N'2021-06-24T11:46:15.5472895' AS DateTime2), CAST(N'2021-06-24T11:46:15.5472895' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (742, N'C', N'M', N'J', CAST(N'2021-06-24T11:46:15.5629100' AS DateTime2), CAST(N'2021-06-24T11:46:15.5629100' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (743, N'C', N'M', N'K', CAST(N'2021-06-24T11:46:15.5785321' AS DateTime2), CAST(N'2021-06-24T11:46:15.5785321' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (744, N'C', N'M', N'L', CAST(N'2021-06-24T11:46:15.5941519' AS DateTime2), CAST(N'2021-06-24T11:46:15.5941519' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (745, N'C', N'M', N'M', CAST(N'2021-06-24T11:46:15.6097728' AS DateTime2), CAST(N'2021-06-24T11:46:15.6097728' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (746, N'C', N'M', N'N', CAST(N'2021-06-24T11:46:15.6253956' AS DateTime2), CAST(N'2021-06-24T11:46:15.6253956' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (747, N'C', N'N', N'C', CAST(N'2021-06-24T11:46:15.6410170' AS DateTime2), CAST(N'2021-06-24T11:46:15.6410170' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (748, N'C', N'N', N'D', CAST(N'2021-06-24T11:46:15.6566375' AS DateTime2), CAST(N'2021-06-24T11:46:15.6566375' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (749, N'C', N'N', N'E', CAST(N'2021-06-24T11:46:15.6722596' AS DateTime2), CAST(N'2021-06-24T11:46:15.6722596' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (750, N'C', N'N', N'F', CAST(N'2021-06-24T11:46:15.6878801' AS DateTime2), CAST(N'2021-06-24T11:46:15.6878801' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (751, N'C', N'N', N'G', CAST(N'2021-06-24T11:46:15.7035014' AS DateTime2), CAST(N'2021-06-24T11:46:15.7035014' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (752, N'C', N'N', N'H', CAST(N'2021-06-24T11:46:15.7191541' AS DateTime2), CAST(N'2021-06-24T11:46:15.7191541' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (753, N'C', N'N', N'I', CAST(N'2021-06-24T11:46:16.0471711' AS DateTime2), CAST(N'2021-06-24T11:46:16.0471711' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (754, N'C', N'N', N'J', CAST(N'2021-06-24T11:46:16.0627939' AS DateTime2), CAST(N'2021-06-24T11:46:16.0627939' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (755, N'C', N'N', N'K', CAST(N'2021-06-24T11:46:16.0784148' AS DateTime2), CAST(N'2021-06-24T11:46:16.0784148' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (756, N'C', N'N', N'L', CAST(N'2021-06-24T11:46:16.0940365' AS DateTime2), CAST(N'2021-06-24T11:46:16.0940365' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (757, N'C', N'N', N'M', CAST(N'2021-06-24T11:46:16.1252792' AS DateTime2), CAST(N'2021-06-24T11:46:16.1252792' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (758, N'C', N'N', N'N', CAST(N'2021-06-24T11:46:16.1408997' AS DateTime2), CAST(N'2021-06-24T11:46:16.1408997' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (759, N'C', N'O', N'C', CAST(N'2021-06-24T11:46:16.1721435' AS DateTime2), CAST(N'2021-06-24T11:46:16.1721435' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (760, N'C', N'O', N'D', CAST(N'2021-06-24T11:46:16.1877648' AS DateTime2), CAST(N'2021-06-24T11:46:16.1877648' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (761, N'C', N'O', N'E', CAST(N'2021-06-24T11:46:16.2033853' AS DateTime2), CAST(N'2021-06-24T11:46:16.2033853' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (762, N'C', N'O', N'F', CAST(N'2021-06-24T11:46:16.2190063' AS DateTime2), CAST(N'2021-06-24T11:46:16.2190063' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (763, N'C', N'O', N'G', CAST(N'2021-06-24T11:46:16.2346276' AS DateTime2), CAST(N'2021-06-24T11:46:16.2346276' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (764, N'C', N'O', N'H', CAST(N'2021-06-24T11:46:16.2502489' AS DateTime2), CAST(N'2021-06-24T11:46:16.2502489' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (765, N'C', N'O', N'I', CAST(N'2021-06-24T11:46:16.2658989' AS DateTime2), CAST(N'2021-06-24T11:46:16.2658989' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (766, N'C', N'O', N'J', CAST(N'2021-06-24T11:46:16.2815251' AS DateTime2), CAST(N'2021-06-24T11:46:16.2815251' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (767, N'C', N'O', N'K', CAST(N'2021-06-24T11:46:16.2815251' AS DateTime2), CAST(N'2021-06-24T11:46:16.2815251' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (768, N'C', N'O', N'L', CAST(N'2021-06-24T11:46:16.2971132' AS DateTime2), CAST(N'2021-06-24T11:46:16.2971132' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (769, N'C', N'O', N'M', CAST(N'2021-06-24T11:46:16.3127342' AS DateTime2), CAST(N'2021-06-24T11:46:16.3127342' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (770, N'C', N'O', N'N', CAST(N'2021-06-24T11:46:16.3283570' AS DateTime2), CAST(N'2021-06-24T11:46:16.3283570' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (771, N'D', N'B', N'F', CAST(N'2021-06-24T11:46:16.3439787' AS DateTime2), CAST(N'2021-06-24T11:46:16.3439787' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (772, N'D', N'B', N'G', CAST(N'2021-06-24T11:46:16.3439787' AS DateTime2), CAST(N'2021-06-24T11:46:16.3439787' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (773, N'D', N'B', N'H', CAST(N'2021-06-24T11:46:16.3595996' AS DateTime2), CAST(N'2021-06-24T11:46:16.3595996' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (774, N'D', N'B', N'I', CAST(N'2021-06-24T11:46:16.3752213' AS DateTime2), CAST(N'2021-06-24T11:46:16.3752213' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (775, N'D', N'B', N'J', CAST(N'2021-06-24T11:46:16.3908411' AS DateTime2), CAST(N'2021-06-24T11:46:16.3908411' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (776, N'D', N'B', N'K', CAST(N'2021-06-24T11:46:16.3908411' AS DateTime2), CAST(N'2021-06-24T11:46:16.3908411' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (777, N'D', N'B', N'L', CAST(N'2021-06-24T11:46:16.4064628' AS DateTime2), CAST(N'2021-06-24T11:46:16.4064628' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (778, N'D', N'B', N'M', CAST(N'2021-06-24T11:46:16.4220841' AS DateTime2), CAST(N'2021-06-24T11:46:16.4220841' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (779, N'D', N'B', N'N', CAST(N'2021-06-24T11:46:16.4220841' AS DateTime2), CAST(N'2021-06-24T11:46:16.4220841' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (780, N'D', N'C', N'F', CAST(N'2021-06-24T11:46:16.4377065' AS DateTime2), CAST(N'2021-06-24T11:46:16.4377065' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (781, N'D', N'C', N'G', CAST(N'2021-06-24T11:46:16.4533271' AS DateTime2), CAST(N'2021-06-24T11:46:16.4533271' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (782, N'D', N'C', N'H', CAST(N'2021-06-24T11:46:16.4689492' AS DateTime2), CAST(N'2021-06-24T11:46:16.4689492' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (783, N'D', N'C', N'I', CAST(N'2021-06-24T11:46:16.4689492' AS DateTime2), CAST(N'2021-06-24T11:46:16.4689492' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (784, N'D', N'C', N'J', CAST(N'2021-06-24T11:46:16.4845720' AS DateTime2), CAST(N'2021-06-24T11:46:16.4845720' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (785, N'D', N'C', N'K', CAST(N'2021-06-24T11:46:16.5001922' AS DateTime2), CAST(N'2021-06-24T11:46:16.5001922' AS DateTime2), 2, 2, 1, NULL, N'')
GO
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (786, N'D', N'C', N'L', CAST(N'2021-06-24T11:46:16.5158433' AS DateTime2), CAST(N'2021-06-24T11:46:16.5158433' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (787, N'D', N'C', N'M', CAST(N'2021-06-24T11:46:16.5314673' AS DateTime2), CAST(N'2021-06-24T11:46:16.5314673' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (788, N'D', N'C', N'N', CAST(N'2021-06-24T11:46:16.5470565' AS DateTime2), CAST(N'2021-06-24T11:46:16.5470565' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (789, N'D', N'D', N'F', CAST(N'2021-06-24T11:46:16.5626763' AS DateTime2), CAST(N'2021-06-24T11:46:16.5626763' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (790, N'D', N'D', N'G', CAST(N'2021-06-24T11:46:16.5782972' AS DateTime2), CAST(N'2021-06-24T11:46:16.5782972' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (791, N'D', N'D', N'H', CAST(N'2021-06-24T11:46:16.5782972' AS DateTime2), CAST(N'2021-06-24T11:46:16.5782972' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (792, N'D', N'D', N'I', CAST(N'2021-06-24T11:46:16.6095402' AS DateTime2), CAST(N'2021-06-24T11:46:16.6095402' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (793, N'D', N'D', N'J', CAST(N'2021-06-24T11:46:16.6251627' AS DateTime2), CAST(N'2021-06-24T11:46:16.6251627' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (794, N'D', N'D', N'K', CAST(N'2021-06-24T11:46:16.6407832' AS DateTime2), CAST(N'2021-06-24T11:46:16.6407832' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (795, N'D', N'D', N'L', CAST(N'2021-06-24T11:46:16.6407832' AS DateTime2), CAST(N'2021-06-24T11:46:16.6407832' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (796, N'D', N'D', N'M', CAST(N'2021-06-24T11:46:16.6564049' AS DateTime2), CAST(N'2021-06-24T11:46:16.6564049' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (797, N'D', N'D', N'N', CAST(N'2021-06-24T11:46:16.6720255' AS DateTime2), CAST(N'2021-06-24T11:46:16.6720255' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (798, N'D', N'E', N'C', CAST(N'2021-06-24T11:46:16.6876468' AS DateTime2), CAST(N'2021-06-24T11:46:16.6876468' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (799, N'D', N'E', N'D', CAST(N'2021-06-24T11:46:16.7032681' AS DateTime2), CAST(N'2021-06-24T11:46:16.7032681' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (800, N'D', N'E', N'E', CAST(N'2021-06-24T11:46:16.7345122' AS DateTime2), CAST(N'2021-06-24T11:46:16.7345122' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (801, N'D', N'E', N'F', CAST(N'2021-06-24T11:46:16.7501332' AS DateTime2), CAST(N'2021-06-24T11:46:16.7501332' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (802, N'D', N'E', N'G', CAST(N'2021-06-24T11:46:16.7501332' AS DateTime2), CAST(N'2021-06-24T11:46:16.7501332' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (803, N'D', N'E', N'H', CAST(N'2021-06-24T11:46:16.7657579' AS DateTime2), CAST(N'2021-06-24T11:46:16.7657579' AS DateTime2), 2, 2, 1, NULL, N'')
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note]) VALUES (804, N'A', N'B', N'F', CAST(N'2021-06-24T11:46:16.7814045' AS DateTime2), CAST(N'2021-06-24T11:46:16.7814045' AS DateTime2), 2, 2, 1, NULL, N'')
SET IDENTITY_INSERT [dbo].[locations] OFF
GO
SET IDENTITY_INSERT [dbo].[objects] ON 

INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId]) VALUES (1, N'catalog', N'واجهة الكاتالوج', CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId]) VALUES (5, N'unit', N'واجهة الوحدات', CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), 2, 2, 1, 1)
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId]) VALUES (6, N'editUni', N'تعديل الوحدات', CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), 2, 2, 1, 5)
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId]) VALUES (7, N'item', N'واجهة العناصر', CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), 2, 2, 1, 1)
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId]) VALUES (8, N'editItem', N'تعديل العناصر', CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), 2, 2, 1, 7)
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId]) VALUES (9, N'account', N'واجهة المحاسبة', CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), 2, 2, 1, NULL)
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId]) VALUES (10, N'payment', N'واجهة المدفوعات', CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), 2, 2, 1, 9)
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId]) VALUES (11, N'editPayment', N'تعديل المدفوعات', CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), CAST(N'2021-05-02T14:55:27.6081340' AS DateTime2), 2, 2, 1, 10)
SET IDENTITY_INSERT [dbo].[objects] OFF
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

INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (53, N'cod1', N'poos1', CAST(228007.0000 AS Decimal(20, 4)), 5, CAST(N'2021-05-26T11:56:56.7623988' AS DateTime2), CAST(N'2021-06-24T11:48:10.2204143' AS DateTime2), 2, 2, 1, N'لا تحذف هذه النقطة من فضلك', CAST(43070.0000 AS Decimal(20, 4)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (54, N'code1', N'pos2', CAST(103000.0000 AS Decimal(20, 4)), 36, CAST(N'2021-05-26T11:59:42.4697380' AS DateTime2), CAST(N'2021-06-17T09:34:01.0919126' AS DateTime2), 2, 2, 1, N'notes', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (59, N'pos3', N'pos3', CAST(100000.0000 AS Decimal(20, 4)), 5, CAST(N'2021-05-27T13:57:51.7422942' AS DateTime2), CAST(N'2021-05-27T13:57:51.7422942' AS DateTime2), 2, 2, 1, N'notes', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (60, N'code4', N'pos4', CAST(100000.0000 AS Decimal(20, 4)), 5, CAST(N'2021-06-07T12:26:13.6095591' AS DateTime2), CAST(N'2021-06-07T12:26:13.6095591' AS DateTime2), 2, 2, 1, N'notes4', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (61, N'code5', N'pos5', CAST(102000.0000 AS Decimal(20, 4)), 7, CAST(N'2021-06-07T12:26:34.5265006' AS DateTime2), CAST(N'2021-06-08T14:04:00.4717761' AS DateTime2), 2, 2, 1, N'notes5', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (62, N'code6', N'pos6', CAST(100000.0000 AS Decimal(20, 4)), 24, CAST(N'2021-06-07T12:27:00.2722793' AS DateTime2), CAST(N'2021-06-07T12:27:00.2722793' AS DateTime2), 2, 2, 1, N'notes6', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (63, N'23', N'salmiah', CAST(75000.0000 AS Decimal(20, 4)), 56, CAST(N'2021-06-23T14:59:24.8140280' AS DateTime2), CAST(N'2021-06-23T14:59:24.8140280' AS DateTime2), 2, 2, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (64, N'32', N'نقطة حلب', CAST(320000.0000 AS Decimal(20, 4)), 62, CAST(N'2021-06-23T16:50:27.2690465' AS DateTime2), CAST(N'2021-06-23T16:50:27.2690465' AS DateTime2), 2, 2, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (65, N'3242', N'Damas', CAST(150000.0000 AS Decimal(20, 4)), 68, CAST(N'2021-06-23T16:54:44.1820755' AS DateTime2), CAST(N'2021-06-23T16:54:44.1820755' AS DateTime2), 2, 2, 1, N'', NULL)
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
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note]) VALUES (8, N'test2', CAST(N'2021-05-27T12:46:09.2126182' AS DateTime2), CAST(N'2021-05-27T12:46:09.2126182' AS DateTime2), 2, 2, 17, 1, N'2')
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note]) VALUES (9, N'test3', CAST(N'2021-05-27T12:46:11.8213487' AS DateTime2), CAST(N'2021-05-27T12:46:20.7880200' AS DateTime2), 2, 2, 18, 1, N'3')
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note]) VALUES (11, N'test3', CAST(N'2021-05-27T12:48:10.5719337' AS DateTime2), CAST(N'2021-05-27T12:48:10.5719337' AS DateTime2), 2, 2, 18, 1, N'3')
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note]) VALUES (13, N'Test Section2', CAST(N'2021-06-19T16:03:22.3485095' AS DateTime2), CAST(N'2021-06-19T16:03:37.1964441' AS DateTime2), 2, 2, 56, 1, N'ssss2s')
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note]) VALUES (14, N'sectionnn1', CAST(N'2021-06-24T11:48:42.7466745' AS DateTime2), CAST(N'2021-06-24T11:49:01.5364332' AS DateTime2), 2, 2, 7, 1, N'noootes')
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
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (36, N'user21-6-2021', N'044d8d316706d4ffb11047f010aa3c1e', N'user21-6-2021', N'user21-6-2021', N'job1', N'12', CAST(N'2021-06-21T11:11:48.4966542' AS DateTime2), CAST(N'2021-06-21T11:11:48.4966542' AS DateTime2), 2, 2, N'+963-14-76655', N'+963-098876', N'', N'user21-6-2021', 1, N'', 1, N'', NULL, NULL)
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
