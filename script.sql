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
ALTER TABLE [dbo].[subscriptionFees] DROP CONSTRAINT [FK_subscriptionFees_memberships]
GO
ALTER TABLE [dbo].[shippingCompanies] DROP CONSTRAINT [FK_shippingCompanies_users2]
GO
ALTER TABLE [dbo].[shippingCompanies] DROP CONSTRAINT [FK_shippingCompanies_users1]
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
ALTER TABLE [dbo].[Points] DROP CONSTRAINT [FK_Points_users1]
GO
ALTER TABLE [dbo].[Points] DROP CONSTRAINT [FK_Points_users]
GO
ALTER TABLE [dbo].[Points] DROP CONSTRAINT [FK_Points_agents]
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
ALTER TABLE [dbo].[memberships] DROP CONSTRAINT [FK_memberships_users1]
GO
ALTER TABLE [dbo].[memberships] DROP CONSTRAINT [FK_memberships_users]
GO
ALTER TABLE [dbo].[medals] DROP CONSTRAINT [FK_medals_users1]
GO
ALTER TABLE [dbo].[medals] DROP CONSTRAINT [FK_medals_users]
GO
ALTER TABLE [dbo].[medalAgent] DROP CONSTRAINT [FK_medalAgent_users1]
GO
ALTER TABLE [dbo].[medalAgent] DROP CONSTRAINT [FK_medalAgent_users]
GO
ALTER TABLE [dbo].[medalAgent] DROP CONSTRAINT [FK_medalAgent_medals]
GO
ALTER TABLE [dbo].[medalAgent] DROP CONSTRAINT [FK_medalAgent_agents]
GO
ALTER TABLE [dbo].[locations] DROP CONSTRAINT [FK_locations_users1]
GO
ALTER TABLE [dbo].[locations] DROP CONSTRAINT [FK_locations_users]
GO
ALTER TABLE [dbo].[locations] DROP CONSTRAINT [FK_locations_sections]
GO
ALTER TABLE [dbo].[locations] DROP CONSTRAINT [FK_locations_branches1]
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
ALTER TABLE [dbo].[invoiceStatus] DROP CONSTRAINT [FK_invoiceStatus_users2]
GO
ALTER TABLE [dbo].[invoiceStatus] DROP CONSTRAINT [FK_invoiceStatus_users1]
GO
ALTER TABLE [dbo].[invoiceStatus] DROP CONSTRAINT [FK_invoiceStatus_users]
GO
ALTER TABLE [dbo].[invoiceStatus] DROP CONSTRAINT [FK_invoiceStatus_invoices]
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
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_shippingCompanies]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_pos]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_invoices]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_branches1]
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
ALTER TABLE [dbo].[cashTransfer] DROP CONSTRAINT [FK_cashTransfer_agentMemberships]
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
ALTER TABLE [dbo].[agents] DROP CONSTRAINT [FK_agents_Points]
GO
ALTER TABLE [dbo].[agentMemberships] DROP CONSTRAINT [FK_agentMemberships_users2]
GO
ALTER TABLE [dbo].[agentMemberships] DROP CONSTRAINT [FK_agentMemberships_users1]
GO
ALTER TABLE [dbo].[agentMemberships] DROP CONSTRAINT [FK_agentMemberships_subscriptionFees]
GO
ALTER TABLE [dbo].[agentMemberships] DROP CONSTRAINT [FK_agentMemberships_memberships2]
GO
ALTER TABLE [dbo].[agentMemberships] DROP CONSTRAINT [FK_agentMemberships_cashTransfer]
GO
ALTER TABLE [dbo].[agentMemberships] DROP CONSTRAINT [FK_agentMemberships_agents]
GO
/****** Object:  Table [dbo].[usersLogs]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usersLogs]') AND type in (N'U'))
DROP TABLE [dbo].[usersLogs]
GO
/****** Object:  Table [dbo].[userSetValues]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[userSetValues]') AND type in (N'U'))
DROP TABLE [dbo].[userSetValues]
GO
/****** Object:  Table [dbo].[users]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type in (N'U'))
DROP TABLE [dbo].[users]
GO
/****** Object:  Table [dbo].[units]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[units]') AND type in (N'U'))
DROP TABLE [dbo].[units]
GO
/****** Object:  Table [dbo].[subscriptionFees]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subscriptionFees]') AND type in (N'U'))
DROP TABLE [dbo].[subscriptionFees]
GO
/****** Object:  Table [dbo].[shippingCompanies]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[shippingCompanies]') AND type in (N'U'))
DROP TABLE [dbo].[shippingCompanies]
GO
/****** Object:  Table [dbo].[setValues]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setValues]') AND type in (N'U'))
DROP TABLE [dbo].[setValues]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setting]') AND type in (N'U'))
DROP TABLE [dbo].[setting]
GO
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[servicesCosts]') AND type in (N'U'))
DROP TABLE [dbo].[servicesCosts]
GO
/****** Object:  Table [dbo].[serials]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[serials]') AND type in (N'U'))
DROP TABLE [dbo].[serials]
GO
/****** Object:  Table [dbo].[sections]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sections]') AND type in (N'U'))
DROP TABLE [dbo].[sections]
GO
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[propertiesItems]') AND type in (N'U'))
DROP TABLE [dbo].[propertiesItems]
GO
/****** Object:  Table [dbo].[properties]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[properties]') AND type in (N'U'))
DROP TABLE [dbo].[properties]
GO
/****** Object:  Table [dbo].[posUsers]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[posUsers]') AND type in (N'U'))
DROP TABLE [dbo].[posUsers]
GO
/****** Object:  Table [dbo].[pos]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pos]') AND type in (N'U'))
DROP TABLE [dbo].[pos]
GO
/****** Object:  Table [dbo].[Points]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Points]') AND type in (N'U'))
DROP TABLE [dbo].[Points]
GO
/****** Object:  Table [dbo].[orderscontents]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[orderscontents]') AND type in (N'U'))
DROP TABLE [dbo].[orderscontents]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[orders]') AND type in (N'U'))
DROP TABLE [dbo].[orders]
GO
/****** Object:  Table [dbo].[offers]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[offers]') AND type in (N'U'))
DROP TABLE [dbo].[offers]
GO
/****** Object:  Table [dbo].[objects]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[objects]') AND type in (N'U'))
DROP TABLE [dbo].[objects]
GO
/****** Object:  Table [dbo].[memberships]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[memberships]') AND type in (N'U'))
DROP TABLE [dbo].[memberships]
GO
/****** Object:  Table [dbo].[medals]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medals]') AND type in (N'U'))
DROP TABLE [dbo].[medals]
GO
/****** Object:  Table [dbo].[medalAgent]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medalAgent]') AND type in (N'U'))
DROP TABLE [dbo].[medalAgent]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[locations]') AND type in (N'U'))
DROP TABLE [dbo].[locations]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemTransferOffer]') AND type in (N'U'))
DROP TABLE [dbo].[itemTransferOffer]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsUnits]') AND type in (N'U'))
DROP TABLE [dbo].[itemsUnits]
GO
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[itemsTransfer]
GO
/****** Object:  Table [dbo].[itemsProp]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsProp]') AND type in (N'U'))
DROP TABLE [dbo].[itemsProp]
GO
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsOffers]') AND type in (N'U'))
DROP TABLE [dbo].[itemsOffers]
GO
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsMaterials]') AND type in (N'U'))
DROP TABLE [dbo].[itemsMaterials]
GO
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsLocations]') AND type in (N'U'))
DROP TABLE [dbo].[itemsLocations]
GO
/****** Object:  Table [dbo].[items]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[items]') AND type in (N'U'))
DROP TABLE [dbo].[items]
GO
/****** Object:  Table [dbo].[invoiceStatus]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoiceStatus]') AND type in (N'U'))
DROP TABLE [dbo].[invoiceStatus]
GO
/****** Object:  Table [dbo].[invoicesOrders]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoicesOrders]') AND type in (N'U'))
DROP TABLE [dbo].[invoicesOrders]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoices]') AND type in (N'U'))
DROP TABLE [dbo].[invoices]
GO
/****** Object:  Table [dbo].[inventoryItemLocation]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[inventoryItemLocation]') AND type in (N'U'))
DROP TABLE [dbo].[inventoryItemLocation]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory]') AND type in (N'U'))
DROP TABLE [dbo].[Inventory]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groups]') AND type in (N'U'))
DROP TABLE [dbo].[groups]
GO
/****** Object:  Table [dbo].[groupObject]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupObject]') AND type in (N'U'))
DROP TABLE [dbo].[groupObject]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expenses]') AND type in (N'U'))
DROP TABLE [dbo].[Expenses]
GO
/****** Object:  Table [dbo].[docImages]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[docImages]') AND type in (N'U'))
DROP TABLE [dbo].[docImages]
GO
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[couponsInvoices]') AND type in (N'U'))
DROP TABLE [dbo].[couponsInvoices]
GO
/****** Object:  Table [dbo].[coupons]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[coupons]') AND type in (N'U'))
DROP TABLE [dbo].[coupons]
GO
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[countriesCodes]') AND type in (N'U'))
DROP TABLE [dbo].[countriesCodes]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cities]') AND type in (N'U'))
DROP TABLE [dbo].[cities]
GO
/****** Object:  Table [dbo].[categoryuser]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categoryuser]') AND type in (N'U'))
DROP TABLE [dbo].[categoryuser]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categories]') AND type in (N'U'))
DROP TABLE [dbo].[categories]
GO
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cashTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[cashTransfer]
GO
/****** Object:  Table [dbo].[cards]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cards]') AND type in (N'U'))
DROP TABLE [dbo].[cards]
GO
/****** Object:  Table [dbo].[branchStore]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchStore]') AND type in (N'U'))
DROP TABLE [dbo].[branchStore]
GO
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchesUsers]') AND type in (N'U'))
DROP TABLE [dbo].[branchesUsers]
GO
/****** Object:  Table [dbo].[branches]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branches]') AND type in (N'U'))
DROP TABLE [dbo].[branches]
GO
/****** Object:  Table [dbo].[bondes]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bondes]') AND type in (N'U'))
DROP TABLE [dbo].[bondes]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[banks]') AND type in (N'U'))
DROP TABLE [dbo].[banks]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agents]') AND type in (N'U'))
DROP TABLE [dbo].[agents]
GO
/****** Object:  Table [dbo].[agentMemberships]    Script Date: 05/07/2021 05:13:07 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agentMemberships]') AND type in (N'U'))
DROP TABLE [dbo].[agentMemberships]
GO
/****** Object:  Table [dbo].[agentMemberships]    Script Date: 05/07/2021 05:13:07 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 05/07/2021 05:13:07 م ******/
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
	[balance] [decimal](20, 2) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[notes] [ntext] NULL,
	[isActive] [tinyint] NULL,
	[fax] [nvarchar](100) NULL,
	[maxDeserve] [decimal](20, 2) NULL,
 CONSTRAINT [PK_agents] PRIMARY KEY CLUSTERED 
(
	[agentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[bondes]    Script Date: 05/07/2021 05:13:07 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bondes](
	[bondId] [int] IDENTITY(1,1) NOT NULL,
	[number] [nvarchar](200) NULL,
	[amount] [decimal](20, 2) NULL,
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
/****** Object:  Table [dbo].[branches]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[branchStore]    Script Date: 05/07/2021 05:13:07 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cards]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 05/07/2021 05:13:07 م ******/
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
	[cash] [decimal](20, 2) NULL,
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
/****** Object:  Table [dbo].[categories]    Script Date: 05/07/2021 05:13:07 م ******/
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
	[taxes] [decimal](20, 2) NULL,
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
/****** Object:  Table [dbo].[categoryuser]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[cities]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[coupons]    Script Date: 05/07/2021 05:13:07 م ******/
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
	[discountValue] [decimal](20, 2) NULL,
	[startDate] [datetime2](7) NULL,
	[endDate] [datetime2](7) NULL,
	[notes] [ntext] NULL,
	[quantity] [int] NULL,
	[remainQ] [int] NULL,
	[invMin] [decimal](20, 2) NULL,
	[invMax] [decimal](20, 2) NULL,
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
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 05/07/2021 05:13:07 م ******/
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
	[discountValue] [decimal](20, 2) NULL,
	[discountType] [tinyint] NULL,
 CONSTRAINT [PK_couponsInvoices] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[docImages]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[Expenses]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[groupObject]    Script Date: 05/07/2021 05:13:07 م ******/
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
	[reportOb] [bit] NULL,
	[levelOb] [tinyint] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [int] NULL,
 CONSTRAINT [PK_groupObject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 05/07/2021 05:13:07 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 05/07/2021 05:13:07 م ******/
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
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[inventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inventoryItemLocation]    Script Date: 05/07/2021 05:13:07 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 05/07/2021 05:13:07 م ******/
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
	[total] [decimal](20, 2) NULL,
	[totalNet] [decimal](20, 2) NULL,
	[paid] [decimal](20, 2) NULL,
	[deserved] [decimal](20, 2) NULL,
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
	[tax] [decimal](20, 2) NULL,
	[taxtype] [int] NULL,
	[name] [nvarchar](200) NULL,
	[isApproved] [tinyint] NULL,
	[shippingCompanyId] [int] NULL,
	[branchCreatorId] [int] NULL,
 CONSTRAINT [PK_invoices] PRIMARY KEY CLUSTERED 
(
	[invoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoicesOrders]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[invoiceStatus]    Script Date: 05/07/2021 05:13:07 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoiceStatus](
	[invStatusId] [int] IDENTITY(1,1) NOT NULL,
	[invoiceId] [int] NULL,
	[date] [datetime2](7) NULL,
	[userId] [int] NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[items]    Script Date: 05/07/2021 05:13:07 م ******/
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
	[taxes] [decimal](20, 2) NULL,
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
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 05/07/2021 05:13:07 م ******/
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
	[storeCost] [decimal](20, 2) NULL,
 CONSTRAINT [PK_itemsLocations] PRIMARY KEY CLUSTERED 
(
	[itemsLocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 05/07/2021 05:13:07 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemsMaterials](
	[itemMatId] [int] IDENTITY(1,1) NOT NULL,
	[itemId] [int] NULL,
	[materialId] [int] NULL,
	[quantity] [decimal](20, 2) NULL,
	[unitId] [int] NULL,
	[price] [decimal](20, 2) NULL,
 CONSTRAINT [PK_itemsMaterials] PRIMARY KEY CLUSTERED 
(
	[itemMatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[itemsProp]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 05/07/2021 05:13:07 م ******/
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
	[price] [decimal](20, 2) NULL,
	[itemUnitId] [int] NULL,
 CONSTRAINT [PK_itemsTransfer] PRIMARY KEY CLUSTERED 
(
	[itemsTransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 05/07/2021 05:13:07 م ******/
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
	[price] [decimal](20, 2) NULL,
	[barcode] [nvarchar](200) NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[subUnitId] [int] NULL,
	[purchasePrice] [decimal](20, 2) NULL,
 CONSTRAINT [PK_itemsUnits] PRIMARY KEY CLUSTERED 
(
	[itemUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 05/07/2021 05:13:07 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemTransferOffer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[itemTransId] [int] NULL,
	[offerId] [int] NULL,
	[discountType] [nvarchar](100) NULL,
	[discountValue] [decimal](20, 2) NULL,
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
/****** Object:  Table [dbo].[locations]    Script Date: 05/07/2021 05:13:07 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medalAgent]    Script Date: 05/07/2021 05:13:07 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medals]    Script Date: 05/07/2021 05:13:07 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[memberships]    Script Date: 05/07/2021 05:13:07 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[memberships](
	[membershipId] [int] NOT NULL,
	[name] [nvarchar](100) NULL,
	[deliveryDiscount] [decimal](20, 2) NULL,
	[deliveryDiscountType] [nvarchar](100) NULL,
	[invoiceDiscount] [decimal](20, 2) NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[objects]    Script Date: 05/07/2021 05:13:07 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[offers]    Script Date: 05/07/2021 05:13:07 م ******/
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
	[discountValue] [decimal](20, 2) NULL,
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
/****** Object:  Table [dbo].[orders]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[orderscontents]    Script Date: 05/07/2021 05:13:07 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderscontents](
	[contentId] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NULL,
	[itemId] [int] NULL,
	[quantity] [decimal](20, 2) NULL,
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
/****** Object:  Table [dbo].[Points]    Script Date: 05/07/2021 05:13:07 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Points](
	[pointId] [int] NOT NULL,
	[Cash] [decimal](20, 2) NULL,
	[CashPoints] [int] NULL,
	[invoiceCount] [int] NULL,
	[invoiceCountPoints] [int] NULL,
	[CashArchive] [decimal](20, 2) NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pos]    Script Date: 05/07/2021 05:13:07 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pos](
	[posId] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](100) NULL,
	[name] [nvarchar](100) NULL,
	[balance] [decimal](20, 2) NULL,
	[branchId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
	[note] [ntext] NULL,
	[balanceAll] [decimal](20, 2) NULL,
 CONSTRAINT [PK_pos] PRIMARY KEY CLUSTERED 
(
	[posId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posUsers]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[properties]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[sections]    Script Date: 05/07/2021 05:13:07 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[serials]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 05/07/2021 05:13:07 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servicesCosts](
	[costId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[costVal] [decimal](20, 2) NULL,
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
/****** Object:  Table [dbo].[setting]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[setValues]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[shippingCompanies]    Script Date: 05/07/2021 05:13:07 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shippingCompanies](
	[shippingCompanyId] [int] NOT NULL,
	[name] [nchar](10) NULL,
	[RealDeliveryCost] [decimal](20, 2) NULL,
	[deliveryCost] [decimal](20, 2) NULL,
	[deliveryType] [nvarchar](100) NULL,
	[notes] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
 CONSTRAINT [PK_shippingCompanies] PRIMARY KEY CLUSTERED 
(
	[shippingCompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subscriptionFees]    Script Date: 05/07/2021 05:13:07 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subscriptionFees](
	[subscriptionFeesId] [int] NOT NULL,
	[membershipId] [int] NULL,
	[monthsCount] [int] NULL,
	[Amount] [decimal](20, 2) NULL,
	[notes] [ntext] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[isActive] [tinyint] NULL,
 CONSTRAINT [PK_subscriptionFees] PRIMARY KEY CLUSTERED 
(
	[subscriptionFeesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[units]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[userSetValues]    Script Date: 05/07/2021 05:13:07 م ******/
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
/****** Object:  Table [dbo].[usersLogs]    Script Date: 05/07/2021 05:13:07 م ******/
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

INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (1, NULL, N'مهند  أبوشعر ', N'297150930', N'أبوشعر', N'', N'', N'', N'+963-111111111', N'57440ff6b80f068efd50410ea24fd593.png', N'v', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:06:09.7108341' AS DateTime2), CAST(N'2021-07-03T11:42:35.3483184' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (2, NULL, N'نور   خضير', N'662615101', N'خضير', N'', N'', N'', N'+963-222222222', N'c37858823db0093766eee74d8ee1f1e5.png', N'v', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:06:22.6174744' AS DateTime2), CAST(N'2021-07-03T11:42:47.5037666' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (3, NULL, N'ديانا  لقق', N'621513063', N'لقق', N'', N'', N'', N'+963-333333333', N'71f020248a405d21e94d1de52043bed4.png', N'v', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:06:41.9485466' AS DateTime2), CAST(N'2021-07-03T11:43:07.1933891' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (4, NULL, N'بيان  سليمان', N'498667622', N'سليمان', N'', N'', N'', N'+963-444444444', N'd2ec5f1ed83abfca0dfec76506b696b3.png', N'v', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:07:08.7041709' AS DateTime2), CAST(N'2021-07-03T11:43:00.3346596' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (5, NULL, N'أحمد   عقاد', N'637304317', N'عقاد', N'', N'', N'', N'+963-555555555', N'f96f8a89e2143f1e43a2ba7953fb5413.png', N'v', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:07:20.4208470' AS DateTime2), CAST(N'2021-07-03T11:43:17.7428115' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (6, NULL, N'بشار   زيدان', N'591702965', N'زيدان', N'', N'', N'', N'+963-666666666', N'56a2e0231c3d394ace201adf37d13f63.png', N'v', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:07:34.4228719' AS DateTime2), CAST(N'2021-07-03T11:43:27.9612971' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (7, NULL, N'محمد سودة', N'430477360', N'سودة', N'', N'', N'', N'+963-777777777', N'3204215c19f25609034d24451f7e03d7.png', N'v', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:07:45.7310231' AS DateTime2), CAST(N'2021-07-03T11:43:32.5624029' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (8, NULL, N'محمد   بهلوان', N'165693251', N'بهلوان', N'', N'', N'', N'+963-888888888', N'6a5d62c1233b5e9b2000dd13aadf81f4.png', N'v', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:08:01.0595455' AS DateTime2), CAST(N'2021-07-03T11:44:13.8732729' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (9, NULL, N'سمر  كركوتلي', N'377866586', N'كركوتلي', N'', N'', N'', N'+966-999999999', N'6eaba1dc3c031faf262149c058fea728.png', N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:08:45.2069660' AS DateTime2), CAST(N'2021-07-03T11:44:22.4405104' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (10, NULL, N'عمر  الحراكي', N'213417292', N'الحراكي', N'', N'', N'', N'+966-101010101', N'0f26776e0a524c7d2b6b5f771d500980.png', N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:08:58.0342271' AS DateTime2), CAST(N'2021-07-03T11:44:26.7807622' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (11, NULL, N'عمر  طيفور', N'778565517', N'طيفور', N'', N'', N'', N'+966-111111111', N'05da7ccc8020731d607471318fc4f35b.png', N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:09:16.4003380' AS DateTime2), CAST(N'2021-07-03T11:44:32.2641278' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (12, NULL, N'عمر   معروف', N'35142864', N'معروف', N'', N'', N'', N'+966-121212121', N'0731f29a7d8c55ddab810a076d078aff.png', N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:09:40.9186322' AS DateTime2), CAST(N'2021-07-03T11:44:36.8612191' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (13, NULL, N'أمل  زيدان', N'57248015', N'زيدان', N'', N'', N'', N'+966-131313131', N'd24538a57424ec2d36086326b9215b74.png', N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:10:01.5456550' AS DateTime2), CAST(N'2021-07-03T11:44:42.7060734' AS DateTime2), 1, 1, N'', 1, N'', CAST(10000.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (14, NULL, N'قمر   كعكة', N'638671253', N'كعكة', N'', N'', N'', N'+966-141414141', N'ad4bfd50185ef68bce2b903aa7e10ec0.png', N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:10:14.7478300' AS DateTime2), CAST(N'2021-07-03T11:44:54.5489169' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (15, NULL, N'طارق غباش', N'903957178', N'غباش', N'', N'', N'', N'+966-151515151', N'cfba0c3306a45ea0746c531906c58962.png', N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:10:32.6809829' AS DateTime2), CAST(N'2021-06-30T16:21:32.9260344' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (16, NULL, N'طه المحجوب', N'265078604', N'المحجوب', N'', N'', N'', N'+966-161616161', N'4361139d4379eb98f913441815402fe6.png', N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:10:42.7726056' AS DateTime2), CAST(N'2021-06-30T16:21:38.2045489' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (17, NULL, N'لونا  آغا', N'10043846', N'آغا', N'', N'', N'', N'+966-171717171', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:10:54.7602515' AS DateTime2), CAST(N'2021-06-30T16:10:54.7602515' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (18, NULL, N'ايمن  البكر', N'83368720', N'البكر', N'', N'', N'', N'+966-181818181', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:11:11.1459706' AS DateTime2), CAST(N'2021-06-30T16:11:11.1459706' AS DateTime2), 1, 1, N'', 1, N'', CAST(20000.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (19, NULL, N'هلا  بكداش', N'494240534', N'بكداش', N'', N'', N'', N'+966-191919191', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:12:11.0473459' AS DateTime2), CAST(N'2021-06-30T16:12:11.0473459' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (20, NULL, N'اية  الأحمد', N'327686608', N'الأحمد', N'', N'', N'', N'+966-202020202', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:12:29.8164362' AS DateTime2), CAST(N'2021-06-30T16:12:29.8164362' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (21, NULL, N'ندى ادلبي', N'947278245', N'ادلبي', N'', N'', N'', N'+966-212121212', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:12:42.4374840' AS DateTime2), CAST(N'2021-06-30T16:12:42.4374840' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (22, NULL, N'جود  كرزة', N'566869883', N'كرزة', N'', N'', N'', N'+966-222222222', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:12:55.0773452' AS DateTime2), CAST(N'2021-06-30T16:12:55.0773452' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (23, NULL, N'غيثاء والي', N'487521162', N'والي', N'', N'', N'', N'+966-232323232', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:13:13.7804093' AS DateTime2), CAST(N'2021-06-30T16:13:13.7804093' AS DateTime2), 1, 1, N'', 1, N'', CAST(500000.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (24, NULL, N'جمانة كرزة', N'949110884', N'كرزة', N'', N'', N'', N'+966-242424242', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:13:36.1745594' AS DateTime2), CAST(N'2021-06-30T16:13:36.1745594' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (25, NULL, N'راما حمامي', N'617817613', N'حمامي', N'', N'', N'', N'+966-252525252', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-06-30T16:13:50.5292915' AS DateTime2), CAST(N'2021-06-30T16:13:50.5292915' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
SET IDENTITY_INSERT [dbo].[agents] OFF
GO
SET IDENTITY_INSERT [dbo].[banks] ON 

INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1, N'بنك الكويت', N'+963--1111111111', N'+963-111111111', N'', N'5844899481', N'', CAST(N'2021-06-30T17:49:41.7711150' AS DateTime2), CAST(N'2021-06-30T17:49:41.7711150' AS DateTime2), 1, 1, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'البنك الإسلامي', N'+963--2222222222', N'+963-222222222', N'', N'5241975628', N'', CAST(N'2021-06-30T17:49:52.9911178' AS DateTime2), CAST(N'2021-06-30T17:49:52.9911178' AS DateTime2), 1, 1, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, N'بنك الشارقة', N'+963--3333333333', N'+963-333333333', N'', N'1486286545', N'', CAST(N'2021-06-30T17:50:05.6640985' AS DateTime2), CAST(N'2021-06-30T17:50:05.6640985' AS DateTime2), 1, 1, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (4, N'بنك الأهلي', N'+963--4444444444', N'+963-444444444', N'', N'3157865752', N'', CAST(N'2021-06-30T17:50:16.2337727' AS DateTime2), CAST(N'2021-06-30T17:50:16.2337727' AS DateTime2), 1, 1, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (5, N'بنك الراجحي', N'+963--5555555555', N'+963-555555555', N'', N'3648515547', N'', CAST(N'2021-06-30T17:50:27.3930780' AS DateTime2), CAST(N'2021-06-30T17:50:27.3930780' AS DateTime2), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[banks] OFF
GO
SET IDENTITY_INSERT [dbo].[branches] ON 

INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (1, N'00', N'-', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, 1, N'bs')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (2, N'Al-JM-B', N'فرع الجميلية - مركزي حلب', N'', N'', N'', N'+971-999999999', CAST(N'2021-06-29T15:23:22.3414329' AS DateTime2), CAST(N'2021-06-29T15:53:24.6803577' AS DateTime2), 1, 1, N'', 1, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (3, N'Al-FK-B', N'فرع الفرقان', N'', N'', N'', N'+966-999999999', CAST(N'2021-06-29T15:30:46.9319676' AS DateTime2), CAST(N'2021-06-29T15:53:31.7036722' AS DateTime2), 1, 1, N'', 2, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (4, N'Al-AD-B', N'فرع الأعظمية', N'', N'', N'', N'+963-999999999', CAST(N'2021-06-29T15:31:03.4836194' AS DateTime2), CAST(N'2021-06-29T15:31:03.4836194' AS DateTime2), 1, 1, N'', 2, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (5, N'DM-MA-B', N'فرع مدينة دمشق', N'', N'', N'', N'+963-999999999', CAST(N'2021-06-29T15:31:18.4853928' AS DateTime2), CAST(N'2021-06-29T15:31:18.4853928' AS DateTime2), 1, 1, N'', 1, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (6, N'DM-RF-B', N'فرع ريف دمشق', N'', N'', N'', N'+963-999999999', CAST(N'2021-06-29T15:31:39.2256506' AS DateTime2), CAST(N'2021-06-29T15:31:39.2256506' AS DateTime2), 1, 1, N'', 5, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (7, N'HA-KL-B', N'فرع حماه', N'', N'', N'', N'+963-999999999', CAST(N'2021-06-29T15:32:03.5225954' AS DateTime2), CAST(N'2021-06-29T15:32:03.5225954' AS DateTime2), 1, 1, N'', 1, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (8, N'TR-SF-B', N'فرع طرطوس', N'', N'', N'', N'+963-999999999', CAST(N'2021-06-29T15:32:28.4443968' AS DateTime2), CAST(N'2021-06-29T15:32:28.4443968' AS DateTime2), 1, 1, N'', 1, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (10, N'Al-JM1-S', N'مخزن الجميلية الأول', N'', N'', N'', N'+963-101010101', CAST(N'2021-06-29T16:27:18.7329942' AS DateTime2), CAST(N'2021-06-29T16:27:18.7329942' AS DateTime2), 1, 1, N'', 2, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (11, N'Al-JM2-S', N'مخزن الجميلية الثاني', N'', N'', N'', N'+963-111111111', CAST(N'2021-06-29T16:27:42.3148952' AS DateTime2), CAST(N'2021-06-29T16:27:42.3148952' AS DateTime2), 1, 1, N'', 2, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (12, N'Al-JF-S', N'مخزن الجميلية - الفرقان', N'', N'', N'', N'+963-121212121', CAST(N'2021-06-29T16:28:45.9873115' AS DateTime2), CAST(N'2021-06-29T16:28:45.9873115' AS DateTime2), 1, 1, N'', 2, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (13, N'Al-FA-S', N'مخزن الفرقان - الأعظمية', N'', N'', N'', N'+963-131313131', CAST(N'2021-06-29T16:29:26.5089359' AS DateTime2), CAST(N'2021-06-29T16:29:26.5089359' AS DateTime2), 1, 1, N'', 3, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (14, N'DM-MA-S', N'مخزن الشام', N'', N'', N'', N'+963-141414141', CAST(N'2021-06-29T16:29:57.7204904' AS DateTime2), CAST(N'2021-06-29T16:29:57.7204904' AS DateTime2), 1, 1, N'', 5, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (15, N'HA-KL-S', N'مخزن حماه', N'', N'', N'', N'+963-151515151', CAST(N'2021-06-29T16:30:33.5084078' AS DateTime2), CAST(N'2021-06-29T16:30:33.5084078' AS DateTime2), 1, 1, N'', 7, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (16, N'TR-SF-S', N'مخزن طرطوس', N'', N'', N'', N'+963-161616161', CAST(N'2021-06-29T16:30:53.7068016' AS DateTime2), CAST(N'2021-06-29T16:30:53.7068016' AS DateTime2), 1, 1, N'', 8, 1, N's')
SET IDENTITY_INSERT [dbo].[branches] OFF
GO
SET IDENTITY_INSERT [dbo].[cards] ON 

INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1, N'Visa Card', N'', CAST(N'2021-06-30T17:57:16.0207327' AS DateTime2), CAST(N'2021-06-30T17:57:16.0207327' AS DateTime2), 1, 1, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'Master Card', N'', CAST(N'2021-06-30T17:57:25.2721667' AS DateTime2), CAST(N'2021-06-30T17:57:25.2721667' AS DateTime2), 1, 1, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, N'K-net', N'', CAST(N'2021-06-30T17:57:35.1366818' AS DateTime2), CAST(N'2021-06-30T17:57:35.1366818' AS DateTime2), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[cards] OFF
GO
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (1, N'EL', N'الكترونيات', N'', N'57440ff6b80f068efd50410ea24fd593.jpg', 1, CAST(5.00 AS Decimal(20, 2)), 0, CAST(N'2021-07-01T11:29:48.5534758' AS DateTime2), CAST(N'2021-07-04T13:56:50.2113017' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (2, N'EL-PR', N'طابعات', N'', N'c37858823db0093766eee74d8ee1f1e5.png', 1, CAST(0.00 AS Decimal(20, 2)), 1, CAST(N'2021-07-01T11:43:04.0050266' AS DateTime2), CAST(N'2021-07-04T13:56:50.2432155' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (3, N'EL-PG', N'برامج', N'', N'71f020248a405d21e94d1de52043bed4.png', 1, CAST(0.00 AS Decimal(20, 2)), 1, CAST(N'2021-07-01T11:43:52.0819247' AS DateTime2), CAST(N'2021-07-04T13:56:50.2771253' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (4, N'EL-MB', N'جوالات', N'', N'd2ec5f1ed83abfca0dfec76506b696b3.png', 1, CAST(10.00 AS Decimal(20, 2)), 1, CAST(N'2021-07-01T11:44:42.7723305' AS DateTime2), CAST(N'2021-07-04T13:56:50.2821134' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (5, N'FD', N'غذائية', N'', N'f96f8a89e2143f1e43a2ba7953fb5413.png', 1, CAST(0.00 AS Decimal(20, 2)), 0, CAST(N'2021-07-01T11:45:28.0183676' AS DateTime2), CAST(N'2021-07-03T11:35:18.0991206' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (6, N'FD-CD', N'معلبات', N'', N'56a2e0231c3d394ace201adf37d13f63.jpg', 1, CAST(0.00 AS Decimal(20, 2)), 5, CAST(N'2021-07-01T11:45:48.3124572' AS DateTime2), CAST(N'2021-07-03T11:34:24.9697976' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (7, N'FD-FV', N'خضار وفواكه', N'', N'3204215c19f25609034d24451f7e03d7.jpg', 1, CAST(0.00 AS Decimal(20, 2)), 5, CAST(N'2021-07-01T11:46:33.4496662' AS DateTime2), CAST(N'2021-07-03T11:34:34.7354272' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (8, N'FD-CT', N'حلويات', N'', N'6a5d62c1233b5e9b2000dd13aadf81f4.jpg', 1, CAST(0.00 AS Decimal(20, 2)), 5, CAST(N'2021-07-01T11:46:58.1869891' AS DateTime2), CAST(N'2021-07-03T11:34:42.7952173' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (9, N'FD-SD', N'مشروبات غازية', N'', N'6eaba1dc3c031faf262149c058fea728.jpeg', 1, CAST(0.00 AS Decimal(20, 2)), 5, CAST(N'2021-07-01T11:45:28.0183676' AS DateTime2), CAST(N'2021-07-03T11:34:52.1089403' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (10, N'CL', N'ملابس', N'', N'0f26776e0a524c7d2b6b5f771d500980.jpg', 1, CAST(0.00 AS Decimal(20, 2)), 0, CAST(N'2021-07-01T12:02:37.8302811' AS DateTime2), CAST(N'2021-07-03T11:35:28.5515921' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (11, N'CL-MN', N'رجالي', N'', N'05da7ccc8020731d607471318fc4f35b.jpeg', 1, CAST(0.00 AS Decimal(20, 2)), 10, CAST(N'2021-07-01T12:05:57.5394155' AS DateTime2), CAST(N'2021-07-03T11:35:34.1315020' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (12, N'CL-WM', N'نسائي', N'', N'0731f29a7d8c55ddab810a076d078aff.jpg', 1, CAST(0.00 AS Decimal(20, 2)), 10, CAST(N'2021-07-01T12:06:27.4849848' AS DateTime2), CAST(N'2021-07-03T11:35:47.2658332' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (13, N'CL-CH', N'أطفال', N'', N'd24538a57424ec2d36086326b9215b74.jpg', 1, CAST(0.00 AS Decimal(20, 2)), 10, CAST(N'2021-07-01T12:06:49.5928571' AS DateTime2), CAST(N'2021-07-03T11:35:51.3899444' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (14, N'CL-BB', N'ديارة', N'', N'ad4bfd50185ef68bce2b903aa7e10ec0.jpeg', 1, CAST(0.00 AS Decimal(20, 2)), 10, CAST(N'2021-07-01T12:07:09.4877287' AS DateTime2), CAST(N'2021-07-03T11:36:10.4750981' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (17, N'MD', N'أدوية', N'', N'5dee7ade7f7ceefa02cc62d1d5961622.png', 1, CAST(0.00 AS Decimal(20, 2)), 0, CAST(N'2021-07-01T13:59:23.5273860' AS DateTime2), CAST(N'2021-07-04T13:56:13.3873950' AS DateTime2), 1, 1, NULL)
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
SET IDENTITY_INSERT [dbo].[invoices] ON 

INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId]) VALUES (2, N'pi-Al-JM-B-Al-JM-B-POS-1-2', 1, 1, N'p', N'1', CAST(2000.0000 AS Decimal(20, 4)), CAST(25000.00 AS Decimal(20, 2)), CAST(23000.00 AS Decimal(20, 2)), CAST(23000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-07-25' AS Date), CAST(N'2021-07-04T13:10:51.6103491' AS DateTime2), CAST(N'2021-07-04T16:17:27.9848290' AS DateTime2), 1, NULL, NULL, CAST(N'13:10:51.6103491' AS Time), N'', N'000000', CAST(N'2021-07-04T00:00:00.0000000' AS DateTime2), 12, NULL, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId]) VALUES (3, N'pi-Al-JM-B-Al-JM-B-POS-1-3', NULL, 1, N'pd', N'-1', NULL, CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-04T15:49:43.0812005' AS DateTime2), CAST(N'2021-07-05T15:55:46.4250248' AS DateTime2), 9, NULL, NULL, CAST(N'15:49:43.0812005' AS Time), N'', N'', NULL, NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId]) VALUES (4, N'pi-Al-JM-B-Al-JM-B-POS-1-4', 1, 1, N'p', N'1', CAST(5000.0000 AS Decimal(20, 4)), CAST(80000.00 AS Decimal(20, 2)), CAST(75000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(75000.00 AS Decimal(20, 2)), CAST(N'2021-12-02' AS Date), CAST(N'2021-07-04T15:53:04.7093562' AS DateTime2), CAST(N'2021-07-04T17:03:48.5020864' AS DateTime2), 1, NULL, NULL, CAST(N'15:53:04.7093562' AS Time), N'', N'0000000', CAST(N'2021-07-01T00:00:00.0000000' AS DateTime2), 12, NULL, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId]) VALUES (5, N'pi-Al-JM-B-Al-JM-B-POS-1-5', 1, 1, N'p', N'2', CAST(10.0000 AS Decimal(20, 4)), CAST(120000.00 AS Decimal(20, 2)), CAST(108000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(108000.00 AS Decimal(20, 2)), CAST(N'2021-08-01' AS Date), CAST(N'2021-07-04T15:54:20.8477629' AS DateTime2), CAST(N'2021-07-04T17:03:51.7105248' AS DateTime2), 1, NULL, NULL, CAST(N'15:54:20.8477629' AS Time), N'', N'000000', NULL, 12, NULL, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId]) VALUES (6, N'pi-Al-JM-B-Al-JM-B-POS-1-6', 3, 1, N'p', N'-1', NULL, CAST(1000000.00 AS Decimal(20, 2)), CAST(1000000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1000000.00 AS Decimal(20, 2)), CAST(N'2021-08-31' AS Date), CAST(N'2021-07-04T15:59:29.4673071' AS DateTime2), CAST(N'2021-07-04T17:03:59.7544142' AS DateTime2), 1, NULL, NULL, CAST(N'15:59:29.4673071' AS Time), N'', N'00', NULL, 12, NULL, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId]) VALUES (9, N'pb-Al-JF-S-Al-JM-B-POS-1-3', 1, 1, N'pbd', N'1', CAST(2000.0000 AS Decimal(20, 4)), CAST(25000.00 AS Decimal(20, 2)), CAST(25000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(25000.00 AS Decimal(20, 2)), CAST(N'2021-07-25' AS Date), CAST(N'2021-07-05T10:11:28.5833177' AS DateTime2), CAST(N'2021-07-05T10:11:28.5833177' AS DateTime2), 1, 2, NULL, CAST(N'10:11:28.5833177' AS Time), N'', N'000000', CAST(N'2021-07-04T00:00:00.0000000' AS DateTime2), 12, NULL, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId]) VALUES (10, N'pi-Al-FK-B-Al-FK-B-POS-1-7', 6, 9, N'pw', N'1', CAST(10.0000 AS Decimal(20, 4)), CAST(1600.00 AS Decimal(20, 2)), CAST(1590.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1590.00 AS Decimal(20, 2)), CAST(N'2021-07-23' AS Date), CAST(N'2021-07-05T15:50:08.3042827' AS DateTime2), CAST(N'2021-07-05T15:50:08.3042827' AS DateTime2), 9, NULL, NULL, CAST(N'15:50:08.3042827' AS Time), N'', N'5151', CAST(N'2021-07-07T00:00:00.0000000' AS DateTime2), 3, NULL, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId]) VALUES (11, N'pi-Al-FK-B-Al-FK-B-POS-1-8', 2, 9, N'pd', N'-1', NULL, CAST(5.00 AS Decimal(20, 2)), CAST(5.10 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(5.10 AS Decimal(20, 2)), CAST(N'2021-07-07' AS Date), CAST(N'2021-07-05T15:55:24.3959382' AS DateTime2), CAST(N'2021-07-05T15:55:24.3959382' AS DateTime2), 9, NULL, NULL, CAST(N'15:55:24.3959382' AS Time), N'', N'', NULL, 4, NULL, CAST(2.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId]) VALUES (12, N'pi-Al-FK-B-Al-FK-B-POS-1-9', 8, 9, N'pw', N'2', CAST(2.0000 AS Decimal(20, 4)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-07-29' AS Date), CAST(N'2021-07-05T15:57:01.5476136' AS DateTime2), CAST(N'2021-07-05T15:57:01.5476136' AS DateTime2), 9, NULL, NULL, CAST(N'15:57:01.5476136' AS Time), N'', N'443', CAST(N'2021-07-09T00:00:00.0000000' AS DateTime2), 3, NULL, CAST(2.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[items] ON 

INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (1, N'BS', N'barcode scanner', N'barcode scanner', N'n', N'57440ff6b80f068efd50410ea24fd593.png', CAST(5.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:08:07.3467846' AS DateTime2), CAST(N'2021-07-04T13:56:50.3030559' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (2, N'BP', N'barcode printer', N'barcode printer', N'n', N'c37858823db0093766eee74d8ee1f1e5.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:09:25.5952307' AS DateTime2), CAST(N'2021-07-04T13:56:50.3100404' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (3, N'CDR', N'Cash Drawer', N'Cash Drawer', N'n', N'71f020248a405d21e94d1de52043bed4.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:10:03.0032564' AS DateTime2), CAST(N'2021-07-04T13:56:50.3130305' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (4, N'PP2', N'POZONE-POS2', N'POZONE-POS2', N'n', N'd2ec5f1ed83abfca0dfec76506b696b3.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:10:39.3201683' AS DateTime2), CAST(N'2021-07-04T13:56:50.3180187' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (5, N't820', N'POZONE-t820-POS', N'POZONE-t820-POS', N'n', N'f96f8a89e2143f1e43a2ba7953fb5413.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:10:57.6681411' AS DateTime2), CAST(N'2021-07-04T13:56:50.3259931' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (6, N't835', N'POZONE-t835-POS', N'POZONE-t835-POS', N'n', N'56a2e0231c3d394ace201adf37d13f63.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:11:26.2708755' AS DateTime2), CAST(N'2021-07-04T13:56:50.3309804' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (7, N'TR', N'Thermal-rolls', N'Thermal-rolls', N'n', N'3204215c19f25609034d24451f7e03d7.png', CAST(5.00 AS Decimal(20, 2)), 1, 24, 5, 1, NULL, CAST(N'2021-07-01T14:12:09.8270752' AS DateTime2), CAST(N'2021-07-04T13:56:50.3349718' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (8, N'LCP', N'laundry-casheir-program', N'laundry-casheir-program', N'sr', N'6a5d62c1233b5e9b2000dd13aadf81f4.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 3, NULL, CAST(N'2021-07-01T14:13:13.5160401' AS DateTime2), CAST(N'2021-07-04T13:56:50.3419517' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (9, N'ET-1', N'thermal-printer', N'EPSON thermal printer', N'n', N'6eaba1dc3c031faf262149c058fea728.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:14:16.7573809' AS DateTime2), CAST(N'2021-07-04T13:56:50.3459418' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (10, N'ET-2', N'EPSON-thermal-printer2', N'EPSON-thermal-printer2', N'n', N'0f26776e0a524c7d2b6b5f771d500980.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:14:40.8903848' AS DateTime2), CAST(N'2021-07-04T13:56:50.3499308' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (11, N'ET-3', N'EPSON-thermal-printer3', N'EPSON-thermal-printer3', N'n', N'05da7ccc8020731d607471318fc4f35b.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:15:40.8420029' AS DateTime2), CAST(N'2021-07-04T13:56:50.3599032' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (12, N'ET-4', N'EPSON-thermal-printer4', N'EPSON-thermal-printer4', N'n', N'0731f29a7d8c55ddab810a076d078aff.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:16:04.4280304' AS DateTime2), CAST(N'2021-07-04T13:56:50.3638930' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (13, N'PP610', N'POZONE-PP610-USB', N'POZONE-PP610-USB', N'n', N'd24538a57424ec2d36086326b9215b74.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:16:32.6852530' AS DateTime2), CAST(N'2021-07-04T13:56:50.3668848' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (14, N'POZONE', N'POZONE-thermal-printer', N'POZONE-thermal-printer', N'n', N'ad4bfd50185ef68bce2b903aa7e10ec0.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:16:53.2349861' AS DateTime2), CAST(N'2021-07-04T13:56:50.3728688' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (15, N'RIO', N'rio-thermal-printer', N'rio-thermal-printer', N'n', N'cfba0c3306a45ea0746c531906c58962.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:23:16.1801577' AS DateTime2), CAST(N'2021-07-04T13:56:50.3798507' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (16, N'STP', N'Sewoo-thermal-printer', N'Sewoo-thermal-printer', N'n', N'4361139d4379eb98f913441815402fe6.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:23:55.7825952' AS DateTime2), CAST(N'2021-07-04T13:56:50.3918179' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (17, N'ZD200D', N'Zebra-ZD200D', N'Zebra-ZD200D', N'n', N'5dee7ade7f7ceefa02cc62d1d5961622.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:24:25.4197898' AS DateTime2), CAST(N'2021-07-04T13:56:50.3968039' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (18, N'M-AS', N'الأسبرين ', N'الأسبرين ', N'd', N'9c8336c58218f7dbea9b172c0da81139.jpg', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 17, NULL, CAST(N'2021-07-01T14:26:42.2934756' AS DateTime2), CAST(N'2021-07-04T13:56:13.4003614' AS DateTime2), 1, 1, 1, 3)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (19, N'M-BR', N'بروفين ', N'بروفين  400', N'd', N'b06b32577361609a56f8d74e9e127a01.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 17, NULL, CAST(N'2021-07-01T14:29:08.0748019' AS DateTime2), CAST(N'2021-07-04T13:56:13.4023552' AS DateTime2), 1, 1, 1, 3)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (20, N'M-bS', N'باراسيتامول ', N'باراسيتامول ', N'd', N'cba6ef02fcbd47ba36115f8f64248594.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 17, NULL, CAST(N'2021-07-01T14:29:59.6125734' AS DateTime2), CAST(N'2021-07-04T13:56:13.4033515' AS DateTime2), 1, 1, 1, 3)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (21, N'IPH-11', N'Iphone 11', N'Iphone 11', N'n', N'90f607ba318fce94cafe1571617d1b6c.png', CAST(10.00 AS Decimal(20, 2)), 1, 0, 0, 4, NULL, CAST(N'2021-07-01T14:30:50.2396205' AS DateTime2), CAST(N'2021-07-04T13:56:50.4017912' AS DateTime2), 1, 1, 1, 1)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (22, N'IPH-11G', N'Iphone 11 Gold', N'Iphone 11 Gold', N'n', N'77d0501bbf02ad459f88ab4b7531b14d.jpg', CAST(10.00 AS Decimal(20, 2)), 1, 0, 0, 4, NULL, CAST(N'2021-07-01T14:33:45.9001780' AS DateTime2), CAST(N'2021-07-04T13:56:50.4107670' AS DateTime2), 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[items] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsLocations] ON 

INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note], [storeCost]) VALUES (1, 10, 100, CAST(N'2021-07-04T16:17:28.0526553' AS DateTime2), CAST(N'2021-07-04T16:17:28.0526553' AS DateTime2), 1, 1, NULL, NULL, 9, NULL, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note], [storeCost]) VALUES (2, 10, 101, CAST(N'2021-07-04T16:17:28.1683433' AS DateTime2), CAST(N'2021-07-04T17:03:48.8032931' AS DateTime2), 1, 1, NULL, NULL, 7, NULL, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note], [storeCost]) VALUES (3, 10, 101, CAST(N'2021-07-04T16:17:28.1753201' AS DateTime2), CAST(N'2021-07-04T17:03:51.7244870' AS DateTime2), 1, 1, NULL, NULL, 11, NULL, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note], [storeCost]) VALUES (4, 10, 1, CAST(N'2021-07-04T17:03:59.7703711' AS DateTime2), CAST(N'2021-07-04T17:03:59.7703711' AS DateTime2), 1, 1, NULL, NULL, 6, NULL, NULL)
SET IDENTITY_INSERT [dbo].[itemsLocations] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsProp] ON 

INSERT [dbo].[itemsProp] ([itemPropId], [propertyItemId], [itemId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (2, 1, 1, CAST(N'2021-07-01T14:37:23.8934926' AS DateTime2), CAST(N'2021-07-01T14:37:23.8934926' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[itemsProp] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsTransfer] ON 

INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (5, 100, 2, NULL, NULL, CAST(N'2021-07-04T15:42:36.2520817' AS DateTime2), CAST(N'2021-07-04T15:42:36.2520817' AS DateTime2), 1, 1, NULL, CAST(250.00 AS Decimal(20, 2)), 9)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (6, 1, 2, NULL, NULL, CAST(N'2021-07-04T15:42:36.2530788' AS DateTime2), CAST(N'2021-07-04T15:42:36.2530788' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 7)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (7, 1, 2, NULL, NULL, CAST(N'2021-07-04T15:42:36.2540759' AS DateTime2), CAST(N'2021-07-04T15:42:36.2540759' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (9, 100, 4, NULL, NULL, CAST(N'2021-07-04T15:53:04.8220541' AS DateTime2), CAST(N'2021-07-04T15:53:04.8220541' AS DateTime2), 1, 1, NULL, CAST(800.00 AS Decimal(20, 2)), 7)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (10, 100, 5, NULL, NULL, CAST(N'2021-07-04T15:54:20.9849062' AS DateTime2), CAST(N'2021-07-04T15:54:20.9849062' AS DateTime2), 1, 1, NULL, CAST(1200.00 AS Decimal(20, 2)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (11, 1, 6, NULL, NULL, CAST(N'2021-07-04T15:59:29.6219024' AS DateTime2), CAST(N'2021-07-04T15:59:29.6219024' AS DateTime2), 1, 1, NULL, CAST(1000000.00 AS Decimal(20, 2)), 6)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (14, 100, 9, NULL, NULL, CAST(N'2021-07-05T10:11:28.6800574' AS DateTime2), CAST(N'2021-07-05T10:11:28.6800574' AS DateTime2), 1, 1, NULL, CAST(250.00 AS Decimal(20, 2)), 9)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (15, 1, 9, NULL, NULL, CAST(N'2021-07-05T10:11:28.6810545' AS DateTime2), CAST(N'2021-07-05T10:11:28.6810545' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 7)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (16, 1, 9, NULL, NULL, CAST(N'2021-07-05T10:11:28.6810545' AS DateTime2), CAST(N'2021-07-05T10:11:28.6810545' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (17, 1, 10, NULL, NULL, CAST(N'2021-07-05T15:50:08.5645897' AS DateTime2), CAST(N'2021-07-05T15:50:08.5645897' AS DateTime2), 9, 9, NULL, CAST(100.00 AS Decimal(20, 2)), 9)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (18, 1, 10, NULL, NULL, CAST(N'2021-07-05T15:50:08.5675816' AS DateTime2), CAST(N'2021-07-05T15:50:08.5675816' AS DateTime2), 9, 9, NULL, CAST(1500.00 AS Decimal(20, 2)), 11)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (19, 1, 11, NULL, NULL, CAST(N'2021-07-05T15:55:24.4507939' AS DateTime2), CAST(N'2021-07-05T15:55:24.4507939' AS DateTime2), 9, 9, NULL, CAST(5.00 AS Decimal(20, 2)), 6)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (20, 1, 3, NULL, NULL, CAST(N'2021-07-05T15:55:46.5606632' AS DateTime2), CAST(N'2021-07-05T15:55:46.5606632' AS DateTime2), 9, 9, NULL, CAST(0.00 AS Decimal(20, 2)), 9)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId]) VALUES (21, 1, 12, NULL, NULL, CAST(N'2021-07-05T15:57:01.6293950' AS DateTime2), CAST(N'2021-07-05T15:57:01.6293950' AS DateTime2), 9, 9, NULL, CAST(0.00 AS Decimal(20, 2)), 7)
SET IDENTITY_INSERT [dbo].[itemsTransfer] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsUnits] ON 

INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (1, 1, 4, 10, 0, 1, CAST(1000000.00 AS Decimal(20, 2)), N'4078525279900', CAST(N'2021-07-01T14:44:41.7298217' AS DateTime2), CAST(N'2021-07-01T14:44:41.7298217' AS DateTime2), 1, 1, 3, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (2, 1, 3, 10, 0, 0, CAST(100000.00 AS Decimal(20, 2)), N'8078525308101', CAST(N'2021-07-01T14:44:59.9506480' AS DateTime2), CAST(N'2021-07-01T14:44:59.9506480' AS DateTime2), 1, 1, 1, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (3, 1, 1, 1, 1, 0, CAST(10000.00 AS Decimal(20, 2)), N'1078525310002', CAST(N'2021-07-01T14:45:13.7321603' AS DateTime2), CAST(N'2021-07-01T14:45:13.7321603' AS DateTime2), 1, 1, 1, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (6, 21, 1, 1, 1, 1, CAST(1200000.00 AS Decimal(20, 2)), N'9078525346911', CAST(N'2021-07-01T14:51:39.5162385' AS DateTime2), CAST(N'2021-07-01T14:51:39.5162385' AS DateTime2), 1, 1, 1, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (7, 19, 2, 12, 0, 1, CAST(10000.00 AS Decimal(20, 2)), N'9078525349912', CAST(N'2021-07-01T14:52:35.2357118' AS DateTime2), CAST(N'2021-07-03T10:55:23.0696576' AS DateTime2), 1, 1, 1, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (8, 19, 1, 1, 1, 0, CAST(1000.00 AS Decimal(20, 2)), N'3078525355513', CAST(N'2021-07-01T14:52:46.5385199' AS DateTime2), CAST(N'2021-07-01T14:52:46.5385199' AS DateTime2), 1, 1, 1, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (9, 18, 2, 12, 0, 1, CAST(5000.00 AS Decimal(20, 2)), N'8078543943001', CAST(N'2021-07-03T10:57:25.6220112' AS DateTime2), CAST(N'2021-07-03T10:57:25.6220112' AS DateTime2), 1, 1, 1, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (10, 18, 1, 1, 1, 0, CAST(500.00 AS Decimal(20, 2)), N'4078543945504', CAST(N'2021-07-03T10:57:48.3277860' AS DateTime2), CAST(N'2021-07-03T10:57:48.3277860' AS DateTime2), 1, 1, 1, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (11, 20, 2, 12, 0, 1, CAST(1250.00 AS Decimal(20, 2)), N'9078543955607', CAST(N'2021-07-03T10:59:35.7246859' AS DateTime2), CAST(N'2021-07-03T10:59:35.7246859' AS DateTime2), 1, 1, 1, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice]) VALUES (12, 20, 1, 1, 1, 0, CAST(1500.00 AS Decimal(20, 2)), N'3078543957508', CAST(N'2021-07-03T10:59:59.8630022' AS DateTime2), CAST(N'2021-07-04T13:11:23.1386605' AS DateTime2), 1, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[itemsUnits] OFF
GO
SET IDENTITY_INSERT [dbo].[locations] ON 

INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (1, N'0', N'0', N'0', CAST(N'2021-06-29T15:23:22.5919044' AS DateTime2), CAST(N'2021-06-29T15:23:22.5919044' AS DateTime2), 1, 1, 1, 1, N'', 2, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (2, N'0', N'0', N'0', CAST(N'2021-06-29T15:30:46.9982964' AS DateTime2), CAST(N'2021-06-29T15:30:46.9982964' AS DateTime2), 1, 1, 1, 2, N'', 3, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (3, N'0', N'0', N'0', CAST(N'2021-06-29T15:31:03.5280255' AS DateTime2), CAST(N'2021-06-29T15:31:03.5280255' AS DateTime2), 1, 1, 1, 3, N'', 4, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (4, N'0', N'0', N'0', CAST(N'2021-06-29T15:31:18.5330876' AS DateTime2), CAST(N'2021-06-29T15:31:18.5330876' AS DateTime2), 1, 1, 1, 4, N'', 5, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (5, N'0', N'0', N'0', CAST(N'2021-06-29T15:31:39.2715997' AS DateTime2), CAST(N'2021-06-29T15:31:39.2715997' AS DateTime2), 1, 1, 1, 5, N'', 6, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (6, N'0', N'0', N'0', CAST(N'2021-06-29T15:32:03.5880190' AS DateTime2), CAST(N'2021-06-29T15:32:03.5880190' AS DateTime2), 1, 1, 1, 6, N'', 7, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (7, N'0', N'0', N'0', CAST(N'2021-06-29T15:32:28.4940356' AS DateTime2), CAST(N'2021-06-29T15:32:28.4940356' AS DateTime2), 1, 1, 1, 7, N'', 8, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (8, N'0', N'0', N'0', CAST(N'2021-06-29T16:27:18.9204267' AS DateTime2), CAST(N'2021-06-29T16:27:18.9204267' AS DateTime2), 1, 1, 1, 8, N'', 10, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (9, N'0', N'0', N'0', CAST(N'2021-06-29T16:27:42.3459488' AS DateTime2), CAST(N'2021-06-29T16:27:42.3459488' AS DateTime2), 1, 1, 1, 9, N'', 11, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (10, N'0', N'0', N'0', CAST(N'2021-06-29T16:28:46.0967301' AS DateTime2), CAST(N'2021-06-29T16:28:46.0967301' AS DateTime2), 1, 1, 1, 10, N'', 12, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (11, N'0', N'0', N'0', CAST(N'2021-06-29T16:29:26.5559706' AS DateTime2), CAST(N'2021-06-29T16:29:26.5559706' AS DateTime2), 1, 1, 1, 11, N'', 13, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (12, N'0', N'0', N'0', CAST(N'2021-06-29T16:29:57.7828227' AS DateTime2), CAST(N'2021-06-29T16:29:57.7828227' AS DateTime2), 1, 1, 1, 12, N'', 14, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (13, N'0', N'0', N'0', CAST(N'2021-06-29T16:30:33.5551124' AS DateTime2), CAST(N'2021-06-29T16:30:33.5551124' AS DateTime2), 1, 1, 1, 13, N'', 15, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (14, N'0', N'0', N'0', CAST(N'2021-06-29T16:30:53.7691034' AS DateTime2), CAST(N'2021-06-29T16:30:53.7691034' AS DateTime2), 1, 1, 1, 14, N'', 16, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (17, N'A', N'A', N'1', CAST(N'2021-07-03T17:42:28.3338023' AS DateTime2), CAST(N'2021-07-03T17:42:28.3338023' AS DateTime2), 1, 1, 1, NULL, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (18, N'A', N'A', N'2', CAST(N'2021-07-03T17:42:28.3709619' AS DateTime2), CAST(N'2021-07-03T17:42:28.3709619' AS DateTime2), 1, 1, 1, NULL, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (19, N'A', N'A', N'3', CAST(N'2021-07-03T17:42:28.3829295' AS DateTime2), CAST(N'2021-07-03T17:42:28.3829295' AS DateTime2), 1, 1, 1, NULL, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (20, N'A', N'A', N'4', CAST(N'2021-07-03T17:42:28.3919065' AS DateTime2), CAST(N'2021-07-03T17:42:28.3919065' AS DateTime2), 1, 1, 1, NULL, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (21, N'A', N'A', N'5', CAST(N'2021-07-03T17:42:28.4008819' AS DateTime2), CAST(N'2021-07-03T17:42:28.4008819' AS DateTime2), 1, 1, 1, NULL, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (22, N'A', N'B', N'1', CAST(N'2021-07-03T17:42:28.4078630' AS DateTime2), CAST(N'2021-07-03T17:42:28.4078630' AS DateTime2), 1, 1, 1, NULL, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (23, N'A', N'B', N'2', CAST(N'2021-07-03T17:42:28.4178372' AS DateTime2), CAST(N'2021-07-03T17:42:28.4178372' AS DateTime2), 1, 1, 1, NULL, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (24, N'A', N'B', N'3', CAST(N'2021-07-03T17:42:28.4327961' AS DateTime2), CAST(N'2021-07-03T17:42:28.4327961' AS DateTime2), 1, 1, 1, NULL, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (25, N'A', N'B', N'4', CAST(N'2021-07-03T17:42:28.4417736' AS DateTime2), CAST(N'2021-07-03T17:42:28.4417736' AS DateTime2), 1, 1, 1, NULL, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (26, N'A', N'B', N'5', CAST(N'2021-07-03T17:42:28.4547383' AS DateTime2), CAST(N'2021-07-03T17:42:28.4547383' AS DateTime2), 1, 1, 1, NULL, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (27, N'A', N'A', N'1', CAST(N'2021-07-04T17:05:19.6628269' AS DateTime2), CAST(N'2021-07-04T17:05:19.6628269' AS DateTime2), 1, 1, 1, NULL, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (28, N'A', N'A', N'2', CAST(N'2021-07-04T17:05:19.7126918' AS DateTime2), CAST(N'2021-07-04T17:05:19.7126918' AS DateTime2), 1, 1, 1, NULL, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (29, N'A', N'A', N'3', CAST(N'2021-07-04T17:05:19.7196729' AS DateTime2), CAST(N'2021-07-04T17:05:19.7196729' AS DateTime2), 1, 1, 1, NULL, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (30, N'A', N'A', N'4', CAST(N'2021-07-04T17:05:19.7296467' AS DateTime2), CAST(N'2021-07-04T17:05:19.7296467' AS DateTime2), 1, 1, 1, NULL, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (31, N'A', N'A', N'5', CAST(N'2021-07-04T17:05:19.7356311' AS DateTime2), CAST(N'2021-07-04T17:05:19.7356311' AS DateTime2), 1, 1, 1, NULL, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (32, N'A', N'B', N'1', CAST(N'2021-07-04T17:05:19.7436089' AS DateTime2), CAST(N'2021-07-04T17:05:19.7436089' AS DateTime2), 1, 1, 1, NULL, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (33, N'A', N'B', N'2', CAST(N'2021-07-04T17:05:19.7515880' AS DateTime2), CAST(N'2021-07-04T17:05:19.7515880' AS DateTime2), 1, 1, 1, NULL, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (34, N'A', N'B', N'3', CAST(N'2021-07-04T17:05:19.7605638' AS DateTime2), CAST(N'2021-07-04T17:39:47.0849684' AS DateTime2), 1, 1, 1, 17, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (35, N'A', N'B', N'4', CAST(N'2021-07-04T17:05:19.7675496' AS DateTime2), CAST(N'2021-07-04T17:39:47.1178699' AS DateTime2), 1, 1, 1, 17, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (36, N'A', N'B', N'5', CAST(N'2021-07-04T17:05:19.7745286' AS DateTime2), CAST(N'2021-07-04T17:39:47.1428030' AS DateTime2), 1, 1, 1, 17, N'', 12, NULL)
SET IDENTITY_INSERT [dbo].[locations] OFF
GO
SET IDENTITY_INSERT [dbo].[pos] ON 

INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (1, N'Al-JM-B-POS-1', N'POS-1', NULL, 2, CAST(N'2021-06-29T16:51:49.0366461' AS DateTime2), CAST(N'2021-06-29T16:51:49.0366461' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (2, N'Al-JM-B-POS-2', N'POS-2', NULL, 2, CAST(N'2021-06-29T16:52:00.6122040' AS DateTime2), CAST(N'2021-06-29T16:52:00.6122040' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (3, N'Al-JM-B-POS-3', N'POS-3', NULL, 2, CAST(N'2021-06-29T16:52:12.7045399' AS DateTime2), CAST(N'2021-06-29T16:52:12.7045399' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (4, N'Al-JM-B-POS-4', N'POS-4', NULL, 2, CAST(N'2021-06-29T16:52:24.9776657' AS DateTime2), CAST(N'2021-06-29T16:52:24.9776657' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (5, N'Al-JM-B-POS-5', N'POS-5', NULL, 2, CAST(N'2021-06-29T16:52:34.7838816' AS DateTime2), CAST(N'2021-06-29T16:52:34.7838816' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (6, N'Al-JM-B-POS-6', N'POS-6', NULL, 2, CAST(N'2021-06-29T16:52:47.6503734' AS DateTime2), CAST(N'2021-06-29T16:52:47.6503734' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (7, N'Al-JM-B-POS-7', N'POS-7', NULL, 2, CAST(N'2021-06-29T16:52:56.7213024' AS DateTime2), CAST(N'2021-06-29T16:52:56.7213024' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (8, N'Al-JM-B-POS-8', N'POS-8', NULL, 2, CAST(N'2021-06-29T16:53:15.5931410' AS DateTime2), CAST(N'2021-06-29T16:53:15.5931410' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (9, N'Al-FK-B-POS-1', N'POS-1', NULL, 3, CAST(N'2021-06-29T16:53:31.2314166' AS DateTime2), CAST(N'2021-06-29T16:53:31.2314166' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (10, N'Al-FK-B-POS-2', N'POS-2', NULL, 3, CAST(N'2021-06-29T16:53:43.3120745' AS DateTime2), CAST(N'2021-06-29T16:53:43.3120745' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (11, N'Al-FK-B-POS-3', N'POS-3', NULL, 3, CAST(N'2021-06-29T16:54:04.8285713' AS DateTime2), CAST(N'2021-06-29T16:54:04.8285713' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (12, N'Al-FK-B-POS-4', N'POS-4', NULL, 3, CAST(N'2021-06-29T16:54:24.1639502' AS DateTime2), CAST(N'2021-06-29T16:54:24.1639502' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (13, N'Al-FK-B-POS-5', N'POS-5', NULL, 3, CAST(N'2021-06-29T16:54:33.1411948' AS DateTime2), CAST(N'2021-06-29T16:54:33.1411948' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (14, N'Al-AD-B-POS-1', N'POS-1', NULL, 4, CAST(N'2021-06-29T16:54:45.9819243' AS DateTime2), CAST(N'2021-06-29T16:54:45.9819243' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (15, N'Al-AD-B-POS-2', N'POS-2', NULL, 4, CAST(N'2021-06-29T16:55:04.0642268' AS DateTime2), CAST(N'2021-06-29T16:55:04.0642268' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (16, N'Al-AD-B-POS-3', N'POS-3', NULL, 4, CAST(N'2021-06-29T16:55:18.8647255' AS DateTime2), CAST(N'2021-06-29T16:55:18.8647255' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (17, N'Al-AD-B-POS-4', N'POS-4', NULL, 4, CAST(N'2021-06-29T16:55:45.0261811' AS DateTime2), CAST(N'2021-06-29T16:55:45.0261811' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (18, N'Al-AD-B-POS-5', N'POS-5', NULL, 4, CAST(N'2021-06-29T16:56:02.5499135' AS DateTime2), CAST(N'2021-06-29T16:56:02.5499135' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (19, N'Al-JF-S-POS-1', N'POS-1', NULL, 12, CAST(N'2021-06-29T17:07:11.8491483' AS DateTime2), CAST(N'2021-06-29T17:07:11.8491483' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (20, N'Al-JF-S-POS-2', N'POS-2', NULL, 12, CAST(N'2021-06-29T17:09:33.0600271' AS DateTime2), CAST(N'2021-06-29T17:09:33.0600271' AS DateTime2), 1, 1, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (22, N'Al-FA-S-POS-1', N'POS-1', NULL, 13, CAST(N'2021-06-29T17:10:13.8441442' AS DateTime2), CAST(N'2021-06-29T17:10:48.5201089' AS DateTime2), 1, 1, 1, N'', NULL)
SET IDENTITY_INSERT [dbo].[pos] OFF
GO
SET IDENTITY_INSERT [dbo].[properties] ON 

INSERT [dbo].[properties] ([propertyId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'لون', CAST(N'2021-07-01T10:32:54.5840533' AS DateTime2), CAST(N'2021-07-01T10:32:54.5840533' AS DateTime2), 2, 2, 1)
INSERT [dbo].[properties] ([propertyId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, N'قياس', CAST(N'2021-07-01T10:36:21.4507448' AS DateTime2), CAST(N'2021-07-01T10:49:51.7138921' AS DateTime2), 2, 1, 1)
SET IDENTITY_INSERT [dbo].[properties] OFF
GO
SET IDENTITY_INSERT [dbo].[propertiesItems] ON 

INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1, N'احمر', 2, NULL, CAST(N'2021-07-01T10:36:47.2218947' AS DateTime2), CAST(N'2021-07-01T10:37:22.4156656' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'ازرق', 2, NULL, CAST(N'2021-07-01T10:36:58.3862401' AS DateTime2), CAST(N'2021-07-01T10:36:58.3862401' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, N'اصفر', 2, NULL, CAST(N'2021-07-01T10:37:10.5669858' AS DateTime2), CAST(N'2021-07-01T10:37:10.5669858' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (4, N'بنفسجي', 2, NULL, CAST(N'2021-07-01T10:37:16.5996680' AS DateTime2), CAST(N'2021-07-01T10:37:16.5996680' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (5, N'S', 3, NULL, CAST(N'2021-07-01T10:38:23.3341932' AS DateTime2), CAST(N'2021-07-01T10:38:23.3341932' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (6, N'M', 3, NULL, CAST(N'2021-07-01T10:38:29.3304036' AS DateTime2), CAST(N'2021-07-01T10:38:29.3304036' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (7, N'L', 3, NULL, CAST(N'2021-07-01T10:38:32.0452514' AS DateTime2), CAST(N'2021-07-01T10:38:32.0452514' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (8, N'XL', 3, NULL, CAST(N'2021-07-01T10:38:41.7729244' AS DateTime2), CAST(N'2021-07-01T10:38:41.7729244' AS DateTime2), 1, 1, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (9, N'XXL', 3, NULL, CAST(N'2021-07-01T10:38:46.2005383' AS DateTime2), CAST(N'2021-07-01T10:38:46.2005383' AS DateTime2), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[propertiesItems] OFF
GO
SET IDENTITY_INSERT [dbo].[sections] ON 

INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (1, N'FreeZone', CAST(N'2021-06-29T15:23:22.5233511' AS DateTime2), CAST(N'2021-06-29T15:23:22.5233511' AS DateTime2), 1, 1, 2, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (2, N'FreeZone', CAST(N'2021-06-29T15:30:46.9726673' AS DateTime2), CAST(N'2021-06-29T15:30:46.9726673' AS DateTime2), 1, 1, 3, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (3, N'FreeZone', CAST(N'2021-06-29T15:31:03.5105202' AS DateTime2), CAST(N'2021-06-29T15:31:03.5105202' AS DateTime2), 1, 1, 4, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (4, N'FreeZone', CAST(N'2021-06-29T15:31:18.5067533' AS DateTime2), CAST(N'2021-06-29T15:31:18.5067533' AS DateTime2), 1, 1, 5, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (5, N'FreeZone', CAST(N'2021-06-29T15:31:39.2448499' AS DateTime2), CAST(N'2021-06-29T15:31:39.2448499' AS DateTime2), 1, 1, 6, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (6, N'FreeZone', CAST(N'2021-06-29T15:32:03.5478533' AS DateTime2), CAST(N'2021-06-29T15:32:03.5478533' AS DateTime2), 1, 1, 7, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (7, N'FreeZone', CAST(N'2021-06-29T15:32:28.4742881' AS DateTime2), CAST(N'2021-06-29T15:32:28.4742881' AS DateTime2), 1, 1, 8, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (8, N'FreeZone', CAST(N'2021-06-29T16:27:18.8579174' AS DateTime2), CAST(N'2021-06-29T16:27:18.8579174' AS DateTime2), 1, 1, 10, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (9, N'FreeZone', CAST(N'2021-06-29T16:27:42.3305115' AS DateTime2), CAST(N'2021-06-29T16:27:42.3305115' AS DateTime2), 1, 1, 11, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (10, N'FreeZone', CAST(N'2021-06-29T16:28:46.0186390' AS DateTime2), CAST(N'2021-06-29T16:28:46.0186390' AS DateTime2), 1, 1, 12, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (11, N'FreeZone', CAST(N'2021-06-29T16:29:26.5247092' AS DateTime2), CAST(N'2021-06-29T16:29:26.5247092' AS DateTime2), 1, 1, 13, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (12, N'FreeZone', CAST(N'2021-06-29T16:29:57.7517606' AS DateTime2), CAST(N'2021-06-29T16:29:57.7517606' AS DateTime2), 1, 1, 14, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (13, N'FreeZone', CAST(N'2021-06-29T16:30:33.5396792' AS DateTime2), CAST(N'2021-06-29T16:30:33.5396792' AS DateTime2), 1, 1, 15, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (14, N'FreeZone', CAST(N'2021-06-29T16:30:53.7224148' AS DateTime2), CAST(N'2021-06-29T16:30:53.7224148' AS DateTime2), 1, 1, 16, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (17, N'طبية', CAST(N'2021-07-04T17:35:30.9195379' AS DateTime2), CAST(N'2021-07-04T17:35:30.9195379' AS DateTime2), 1, 1, 12, 1, N'', NULL)
SET IDENTITY_INSERT [dbo].[sections] OFF
GO
SET IDENTITY_INSERT [dbo].[servicesCosts] ON 

INSERT [dbo].[servicesCosts] ([costId], [name], [costVal], [itemId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (1, N'برنامج كامل', CAST(1000000.00 AS Decimal(20, 2)), 8, CAST(N'2021-07-01T14:41:32.2618746' AS DateTime2), CAST(N'2021-07-01T14:41:42.3937853' AS DateTime2), 1, 1)
INSERT [dbo].[servicesCosts] ([costId], [name], [costVal], [itemId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (2, N'صيانة', CAST(10000.00 AS Decimal(20, 2)), 8, CAST(N'2021-07-01T14:41:55.7959418' AS DateTime2), CAST(N'2021-07-01T14:41:55.7959418' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[servicesCosts] OFF
GO
SET IDENTITY_INSERT [dbo].[units] ON 

INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (1, N'عنصر', NULL, NULL, CAST(N'2021-07-01T10:07:02.8984458' AS DateTime2), 1, 1, CAST(N'2021-07-01T10:07:02.8984458' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (2, N'علبة', NULL, NULL, CAST(N'2021-07-01T10:07:08.1912545' AS DateTime2), 1, 1, CAST(N'2021-07-01T10:07:08.1912545' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (3, N'كرتونة', NULL, NULL, CAST(N'2021-07-01T10:07:14.2150778' AS DateTime2), 1, 1, CAST(N'2021-07-01T10:07:14.2150778' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (4, N'صندوق', NULL, NULL, CAST(N'2021-07-01T10:07:19.6227361' AS DateTime2), 1, 1, CAST(N'2021-07-01T10:07:19.6227361' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (5, N'غرام', NULL, NULL, CAST(N'2021-07-01T10:07:24.5387959' AS DateTime2), 1, 1, CAST(N'2021-07-01T10:07:24.5387959' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (6, N'كيلو', NULL, NULL, CAST(N'2021-07-01T10:07:29.6950121' AS DateTime2), 1, 1, CAST(N'2021-07-01T10:07:29.6950121' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (7, N'طن', NULL, NULL, CAST(N'2021-07-01T10:07:34.6946380' AS DateTime2), 1, 1, CAST(N'2021-07-01T10:07:34.6946380' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (8, N'مل', NULL, NULL, CAST(N'2021-07-01T10:07:39.2255917' AS DateTime2), 1, 1, CAST(N'2021-07-01T10:07:39.2255917' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (9, N'ليتر', NULL, NULL, CAST(N'2021-07-01T10:07:45.9004101' AS DateTime2), 1, 1, CAST(N'2021-07-01T10:07:45.9014175' AS DateTime2), NULL, 1, N'')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (10, N'برميل', NULL, NULL, CAST(N'2021-07-01T10:07:50.3338814' AS DateTime2), 1, 1, CAST(N'2021-07-01T10:07:50.3338814' AS DateTime2), NULL, 1, N'')
SET IDENTITY_INSERT [dbo].[units] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (1, N'admin', N'1b8baf4f819e5b304e1a176e1c590c84', N'Mohammad', N'Nasani', N'System Admin', N'12', CAST(N'2021-06-28T18:38:45.0434248' AS DateTime2), CAST(N'2021-07-05T16:39:36.9679748' AS DateTime2), 2, 1, N'+963-21-2278910', N'+963-966376308', N'mohamadnasani@gmail.com', N'Halab', 1, N'', 1, N'', N'57440ff6b80f068efd50410ea24fd593.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (2, N'yasin', N'e509d17a7834e211ca548cef13b4a933', N'ياسين', N'ادلبي', N'محاسب', N'8', CAST(N'2021-06-30T11:05:51.9137655' AS DateTime2), CAST(N'2021-07-05T04:32:01.0067756' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', N'c37858823db0093766eee74d8ee1f1e5.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (3, N'yasmine', N'4cdf921bfe31b594a0cc9cc555292f02', N'ياسمين', N'النجار', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:17:13.6368587' AS DateTime2), CAST(N'2021-07-05T04:43:24.8595396' AS DateTime2), 1, 3, N'', N'+963-09876544', N'', N'', 1, N'', 1, N'', N'71f020248a405d21e94d1de52043bed4.jpg', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (4, N'bonni', N'494e167fd30bf2a244c8fcda0220aa89', N'محمد', N'بني', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:17:38.6309662' AS DateTime2), CAST(N'2021-07-05T04:18:23.3320125' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', N'd2ec5f1ed83abfca0dfec76506b696b3.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (5, N'olwani', N'7ae94a254e28a0e9a575e9669fed5684', N'محمد', N'علواني', N'مدير مشتريات', N'8', CAST(N'2021-06-30T11:23:59.5926231' AS DateTime2), CAST(N'2021-07-03T11:45:30.9681396' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', N'f96f8a89e2143f1e43a2ba7953fb5413.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (6, N'amna', N'78fe84643f9a617ac5800771a1c3c5e9', N'آمنة', N'سعدات', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:24:56.0475272' AS DateTime2), CAST(N'2021-07-03T11:45:37.8693339' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', N'56a2e0231c3d394ace201adf37d13f63.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (7, N'basmah', N'210db3affbee2bdeb82872a7f42a970f', N'باسمة', N'قدري', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:25:40.3004312' AS DateTime2), CAST(N'2021-07-03T11:45:43.1954307' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', N'3204215c19f25609034d24451f7e03d7.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (8, N'bik', N'e2a603fb361ecb7b2fc6791f98382580', N'محمد', N'بيك', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:26:56.9568520' AS DateTime2), CAST(N'2021-07-03T11:45:49.4855706' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', N'6a5d62c1233b5e9b2000dd13aadf81f4.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (9, N'naji', N'741e82719da67d8744fd797194aa65b0', N'ناجي', N'مصري', N'مدير', N'8', CAST(N'2021-06-30T11:40:59.4646248' AS DateTime2), CAST(N'2021-07-05T15:48:10.2500032' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', N'6eaba1dc3c031faf262149c058fea728.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (10, N'gammal', N'93f8a85e591d4c7d7bb32a1c2ded5f49', N'جمال', N'عثمان', N'محاسب', N'8', CAST(N'2021-06-30T11:41:40.3141978' AS DateTime2), CAST(N'2021-07-03T11:46:01.1927060' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', N'0f26776e0a524c7d2b6b5f771d500980.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (11, N'samer', N'88bc4525060f0e96bf15392785fc0bc9', N'سامر', N'المصري', N'امين مستودع', N'8', CAST(N'2021-06-30T11:42:42.2388711' AS DateTime2), CAST(N'2021-07-03T11:46:05.7130644' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', N'05da7ccc8020731d607471318fc4f35b.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (12, N'esmaeil', N'b52c7f50ba2f865399e5838e87e4db6c', N'اسماعيل', N'امجد', N'مدير مشتريات', N'8', CAST(N'2021-06-30T11:43:05.8054749' AS DateTime2), CAST(N'2021-07-03T11:46:10.9926345' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', N'0731f29a7d8c55ddab810a076d078aff.png', NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (13, N'fatema', N'd8fe177d106f727da83452e72ed6cc52', N'فاطمة', N'خالد', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:43:27.8574569' AS DateTime2), CAST(N'2021-06-30T11:43:27.8574569' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', NULL, NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (14, N'aya', N'b697f68966fb214868346e83867897ab', N'آية', N'سليمان', N'مدير', N'8', CAST(N'2021-06-30T11:43:48.7387915' AS DateTime2), CAST(N'2021-06-30T11:43:48.7387915' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', NULL, NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (15, N'somaya', N'bd1872d1a3f8b6ac8ea1801d78500716', N'سمية', N'محمد', N'محاسب', N'8', CAST(N'2021-06-30T11:44:27.3588024' AS DateTime2), CAST(N'2021-06-30T11:44:27.3588024' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', NULL, NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (16, N'samerah', N'1fb05f350e1272d0fcf5023cd08b0c78', N'سميرة', N'المحجوب', N'امين مستودع', N'8', CAST(N'2021-06-30T11:45:13.9722914' AS DateTime2), CAST(N'2021-06-30T11:45:13.9722914' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', NULL, NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (17, N'sawsan', N'4e08511679204a2c1056e96feafd9a98', N'سوسن', N'الأحمد', N'مدير مشتريات', N'8', CAST(N'2021-06-30T11:45:52.9176913' AS DateTime2), CAST(N'2021-06-30T11:45:52.9176913' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', NULL, NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (18, N'sara', N'7202807332047589fa409179963a9c04', N'سارة', N'علي', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:47:13.0378597' AS DateTime2), CAST(N'2021-06-30T11:47:13.0378597' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', NULL, NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (19, N'dina', N'513866157bae565e9e3bc02a1ca05e9d', N'دينا', N'نعمة', N'امين مستودع', N'8', CAST(N'2021-06-30T11:48:15.5604312' AS DateTime2), CAST(N'2021-06-30T11:48:15.5604312' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', NULL, NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (20, N'sabbagh', N'1a45d82222dab4a597537f85b7dacfe1', N'أحمد', N'صباغ', N'مساعد امين مستودع', N'8', CAST(N'2021-06-30T11:48:46.0905677' AS DateTime2), CAST(N'2021-06-30T11:48:46.0905677' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', NULL, NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (21, N'saeed', N'1e920a928a6be4ea6fa634e7fa3f048b', N'سعيد', N'قطان', N'امين مستودع', N'8', CAST(N'2021-06-30T11:49:06.2421502' AS DateTime2), CAST(N'2021-06-30T11:49:06.2421502' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 1, N'', NULL, NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (22, N'admin2', N'9579a84c56ad91c528d78e6c0103b249', N'world', N'hellosss', N'محاسب', N'5', CAST(N'2021-06-30T12:00:26.8220743' AS DateTime2), CAST(N'2021-06-30T12:01:26.2613614' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 0, N'', NULL, NULL)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId]) VALUES (23, N'admin2', N'5a30984e268f3112ae87891732ddce2d', N'world', N'hellosss', N'محاسب', N'5', CAST(N'2021-06-30T14:36:07.0830901' AS DateTime2), CAST(N'2021-06-30T14:36:07.0830901' AS DateTime2), 1, 1, N'', N'+963-', N'', N'', 1, N'', 0, N'', NULL, NULL)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
SET IDENTITY_INSERT [dbo].[usersLogs] ON 

INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (38, CAST(N'2021-07-03T16:46:22.7258309' AS DateTime2), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[usersLogs] OFF
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
ALTER TABLE [dbo].[invoiceStatus]  WITH CHECK ADD  CONSTRAINT [FK_invoiceStatus_users2] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[invoiceStatus] CHECK CONSTRAINT [FK_invoiceStatus_users2]
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
ALTER TABLE [dbo].[shippingCompanies]  WITH CHECK ADD  CONSTRAINT [FK_shippingCompanies_users1] FOREIGN KEY([updateUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[shippingCompanies] CHECK CONSTRAINT [FK_shippingCompanies_users1]
GO
ALTER TABLE [dbo].[shippingCompanies]  WITH CHECK ADD  CONSTRAINT [FK_shippingCompanies_users2] FOREIGN KEY([createUserId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[shippingCompanies] CHECK CONSTRAINT [FK_shippingCompanies_users2]
GO
ALTER TABLE [dbo].[subscriptionFees]  WITH CHECK ADD  CONSTRAINT [FK_subscriptionFees_memberships] FOREIGN KEY([membershipId])
REFERENCES [dbo].[memberships] ([membershipId])
GO
ALTER TABLE [dbo].[subscriptionFees] CHECK CONSTRAINT [FK_subscriptionFees_memberships]
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
