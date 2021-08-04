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
ALTER TABLE [dbo].[sysEmails] DROP CONSTRAINT [FK_sysEmails_users1]
GO
ALTER TABLE [dbo].[sysEmails] DROP CONSTRAINT [FK_sysEmails_users]
GO
ALTER TABLE [dbo].[sysEmails] DROP CONSTRAINT [FK_sysEmails_branches]
GO
ALTER TABLE [dbo].[subscriptionFees] DROP CONSTRAINT [FK_subscriptionFees_memberships]
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
ALTER TABLE [dbo].[packages] DROP CONSTRAINT [FK_packages_users2]
GO
ALTER TABLE [dbo].[packages] DROP CONSTRAINT [FK_packages_users1]
GO
ALTER TABLE [dbo].[packages] DROP CONSTRAINT [FK_packages_itemsUnits1]
GO
ALTER TABLE [dbo].[packages] DROP CONSTRAINT [FK_packages_itemsUnits]
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
ALTER TABLE [dbo].[itemsUnits] DROP CONSTRAINT [FK_itemsUnits_storageCost]
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
ALTER TABLE [dbo].[invoiceStatus] DROP CONSTRAINT [FK_invoiceStatus_users1]
GO
ALTER TABLE [dbo].[invoiceStatus] DROP CONSTRAINT [FK_invoiceStatus_users]
GO
ALTER TABLE [dbo].[invoiceStatus] DROP CONSTRAINT [FK_invoiceStatus_invoices]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_users4]
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
ALTER TABLE [dbo].[Inventory] DROP CONSTRAINT [FK_Inventory_pos]
GO
ALTER TABLE [dbo].[Inventory] DROP CONSTRAINT [FK_Inventory_branches]
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
ALTER TABLE [dbo].[storageCost] DROP CONSTRAINT [DF_storageCost_cost]
GO
ALTER TABLE [dbo].[shippingCompanies] DROP CONSTRAINT [DF_shippingCompanies_balance]
GO
ALTER TABLE [dbo].[packages] DROP CONSTRAINT [DF_packages_isActive]
GO
ALTER TABLE [dbo].[packages] DROP CONSTRAINT [DF_packages_quantity]
GO
ALTER TABLE [dbo].[countriesCodes] DROP CONSTRAINT [DF_countriesCodes_isDefault]
GO
/****** Object:  Table [dbo].[usersLogs]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usersLogs]') AND type in (N'U'))
DROP TABLE [dbo].[usersLogs]
GO
/****** Object:  Table [dbo].[userSetValues]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[userSetValues]') AND type in (N'U'))
DROP TABLE [dbo].[userSetValues]
GO
/****** Object:  Table [dbo].[users]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type in (N'U'))
DROP TABLE [dbo].[users]
GO
/****** Object:  Table [dbo].[units]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[units]') AND type in (N'U'))
DROP TABLE [dbo].[units]
GO
/****** Object:  Table [dbo].[sysEmails]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sysEmails]') AND type in (N'U'))
DROP TABLE [dbo].[sysEmails]
GO
/****** Object:  Table [dbo].[subscriptionFees]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subscriptionFees]') AND type in (N'U'))
DROP TABLE [dbo].[subscriptionFees]
GO
/****** Object:  Table [dbo].[storageCost]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[storageCost]') AND type in (N'U'))
DROP TABLE [dbo].[storageCost]
GO
/****** Object:  Table [dbo].[shippingCompanies]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[shippingCompanies]') AND type in (N'U'))
DROP TABLE [dbo].[shippingCompanies]
GO
/****** Object:  Table [dbo].[setValues]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setValues]') AND type in (N'U'))
DROP TABLE [dbo].[setValues]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setting]') AND type in (N'U'))
DROP TABLE [dbo].[setting]
GO
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[servicesCosts]') AND type in (N'U'))
DROP TABLE [dbo].[servicesCosts]
GO
/****** Object:  Table [dbo].[serials]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[serials]') AND type in (N'U'))
DROP TABLE [dbo].[serials]
GO
/****** Object:  Table [dbo].[sections]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sections]') AND type in (N'U'))
DROP TABLE [dbo].[sections]
GO
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[propertiesItems]') AND type in (N'U'))
DROP TABLE [dbo].[propertiesItems]
GO
/****** Object:  Table [dbo].[properties]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[properties]') AND type in (N'U'))
DROP TABLE [dbo].[properties]
GO
/****** Object:  Table [dbo].[posUsers]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[posUsers]') AND type in (N'U'))
DROP TABLE [dbo].[posUsers]
GO
/****** Object:  Table [dbo].[pos]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pos]') AND type in (N'U'))
DROP TABLE [dbo].[pos]
GO
/****** Object:  Table [dbo].[Points]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Points]') AND type in (N'U'))
DROP TABLE [dbo].[Points]
GO
/****** Object:  Table [dbo].[packages]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[packages]') AND type in (N'U'))
DROP TABLE [dbo].[packages]
GO
/****** Object:  Table [dbo].[offers]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[offers]') AND type in (N'U'))
DROP TABLE [dbo].[offers]
GO
/****** Object:  Table [dbo].[objects]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[objects]') AND type in (N'U'))
DROP TABLE [dbo].[objects]
GO
/****** Object:  Table [dbo].[memberships]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[memberships]') AND type in (N'U'))
DROP TABLE [dbo].[memberships]
GO
/****** Object:  Table [dbo].[medals]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medals]') AND type in (N'U'))
DROP TABLE [dbo].[medals]
GO
/****** Object:  Table [dbo].[medalAgent]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medalAgent]') AND type in (N'U'))
DROP TABLE [dbo].[medalAgent]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[locations]') AND type in (N'U'))
DROP TABLE [dbo].[locations]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemTransferOffer]') AND type in (N'U'))
DROP TABLE [dbo].[itemTransferOffer]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsUnits]') AND type in (N'U'))
DROP TABLE [dbo].[itemsUnits]
GO
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[itemsTransfer]
GO
/****** Object:  Table [dbo].[itemsProp]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsProp]') AND type in (N'U'))
DROP TABLE [dbo].[itemsProp]
GO
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsOffers]') AND type in (N'U'))
DROP TABLE [dbo].[itemsOffers]
GO
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsMaterials]') AND type in (N'U'))
DROP TABLE [dbo].[itemsMaterials]
GO
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsLocations]') AND type in (N'U'))
DROP TABLE [dbo].[itemsLocations]
GO
/****** Object:  Table [dbo].[items]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[items]') AND type in (N'U'))
DROP TABLE [dbo].[items]
GO
/****** Object:  Table [dbo].[invoiceStatus]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoiceStatus]') AND type in (N'U'))
DROP TABLE [dbo].[invoiceStatus]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoices]') AND type in (N'U'))
DROP TABLE [dbo].[invoices]
GO
/****** Object:  Table [dbo].[inventoryItemLocation]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[inventoryItemLocation]') AND type in (N'U'))
DROP TABLE [dbo].[inventoryItemLocation]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory]') AND type in (N'U'))
DROP TABLE [dbo].[Inventory]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groups]') AND type in (N'U'))
DROP TABLE [dbo].[groups]
GO
/****** Object:  Table [dbo].[groupObject]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupObject]') AND type in (N'U'))
DROP TABLE [dbo].[groupObject]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expenses]') AND type in (N'U'))
DROP TABLE [dbo].[Expenses]
GO
/****** Object:  Table [dbo].[docImages]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[docImages]') AND type in (N'U'))
DROP TABLE [dbo].[docImages]
GO
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[couponsInvoices]') AND type in (N'U'))
DROP TABLE [dbo].[couponsInvoices]
GO
/****** Object:  Table [dbo].[coupons]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[coupons]') AND type in (N'U'))
DROP TABLE [dbo].[coupons]
GO
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[countriesCodes]') AND type in (N'U'))
DROP TABLE [dbo].[countriesCodes]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cities]') AND type in (N'U'))
DROP TABLE [dbo].[cities]
GO
/****** Object:  Table [dbo].[categoryuser]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categoryuser]') AND type in (N'U'))
DROP TABLE [dbo].[categoryuser]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categories]') AND type in (N'U'))
DROP TABLE [dbo].[categories]
GO
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cashTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[cashTransfer]
GO
/****** Object:  Table [dbo].[cards]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cards]') AND type in (N'U'))
DROP TABLE [dbo].[cards]
GO
/****** Object:  Table [dbo].[branchStore]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchStore]') AND type in (N'U'))
DROP TABLE [dbo].[branchStore]
GO
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchesUsers]') AND type in (N'U'))
DROP TABLE [dbo].[branchesUsers]
GO
/****** Object:  Table [dbo].[branches]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branches]') AND type in (N'U'))
DROP TABLE [dbo].[branches]
GO
/****** Object:  Table [dbo].[bondes]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bondes]') AND type in (N'U'))
DROP TABLE [dbo].[bondes]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[banks]') AND type in (N'U'))
DROP TABLE [dbo].[banks]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agents]') AND type in (N'U'))
DROP TABLE [dbo].[agents]
GO
/****** Object:  Table [dbo].[agentMemberships]    Script Date: 04/08/2021 11:18:02 ص ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agentMemberships]') AND type in (N'U'))
DROP TABLE [dbo].[agentMemberships]
GO
/****** Object:  Table [dbo].[agentMemberships]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[agents]    Script Date: 04/08/2021 11:18:02 ص ******/
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
	[maxDeserve] [decimal](20, 2) NULL,
 CONSTRAINT [PK_agents] PRIMARY KEY CLUSTERED 
(
	[agentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[bondes]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[branches]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[branchStore]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[cards]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[categories]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[categoryuser]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[cities]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 04/08/2021 11:18:02 ص ******/
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
 CONSTRAINT [PK_countriesCodes] PRIMARY KEY CLUSTERED 
(
	[countryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[coupons]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[docImages]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[Expenses]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[groupObject]    Script Date: 04/08/2021 11:18:02 ص ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[Inventory]    Script Date: 04/08/2021 11:18:02 ص ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inventoryItemLocation]    Script Date: 04/08/2021 11:18:02 ص ******/
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
 CONSTRAINT [PK_inventoryItemLocation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 04/08/2021 11:18:02 ص ******/
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
	[shipUserId] [int] NULL,
	[prevStatus] [nvarchar](10) NULL,
 CONSTRAINT [PK_invoices] PRIMARY KEY CLUSTERED 
(
	[invoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoiceStatus]    Script Date: 04/08/2021 11:18:02 ص ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[items]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 04/08/2021 11:18:02 ص ******/
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
 CONSTRAINT [PK_itemsLocations] PRIMARY KEY CLUSTERED 
(
	[itemsLocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[itemsProp]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 04/08/2021 11:18:02 ص ******/
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
	[itemSerial] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_itemsTransfer] PRIMARY KEY CLUSTERED 
(
	[itemsTransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 04/08/2021 11:18:02 ص ******/
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
	[storageCostId] [int] NULL,
 CONSTRAINT [PK_itemsUnits] PRIMARY KEY CLUSTERED 
(
	[itemUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[locations]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[medalAgent]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[medals]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[memberships]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[objects]    Script Date: 04/08/2021 11:18:02 ص ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[offers]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[packages]    Script Date: 04/08/2021 11:18:02 ص ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Points]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[pos]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[posUsers]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[properties]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[sections]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[serials]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[setting]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[setValues]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[shippingCompanies]    Script Date: 04/08/2021 11:18:02 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shippingCompanies](
	[shippingCompanyId] [int] IDENTITY(1,1) NOT NULL,
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
	[balance] [decimal](20, 3) NOT NULL,
	[balanceType] [tinyint] NULL,
 CONSTRAINT [PK_shippingCompanies] PRIMARY KEY CLUSTERED 
(
	[shippingCompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[storageCost]    Script Date: 04/08/2021 11:18:02 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[storageCost](
	[storageCostId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[cost] [decimal](20, 2) NOT NULL,
	[note] [ntext] NULL,
	[isActive] [tinyint] NULL,
	[createUserId] [int] NULL,
	[updateUserId] [int] NULL,
	[createDate] [datetime2](7) NULL,
	[updateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_storageCost] PRIMARY KEY CLUSTERED 
(
	[storageCostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subscriptionFees]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[sysEmails]    Script Date: 04/08/2021 11:18:02 ص ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[units]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 04/08/2021 11:18:02 ص ******/
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
	[balance] [decimal](20, 2) NULL,
	[balanceType] [tinyint] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userSetValues]    Script Date: 04/08/2021 11:18:02 ص ******/
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
/****** Object:  Table [dbo].[usersLogs]    Script Date: 04/08/2021 11:18:02 ص ******/
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

INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (1, NULL, N'مهند  أبوشعر ', N'550811941', N'أبوشعر', N'aleppo', N'mail@mail.com', N'+961-021-0998877', N'+963-093355887', N'57440ff6b80f068efd50410ea24fd593.jfif', N'v', N'', CAST(151252.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:06:09.7108341' AS DateTime2), CAST(N'2021-08-03T13:14:19.3158948' AS DateTime2), 1, 3, N'notes', 1, N'+966-021-887666', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (2, NULL, N'نور   خضير', N'197159583', N'خضير', N'homs', N'nour@gmail.com', N'+966-021-57892455', N'+963-098765321', N'c37858823db0093766eee74d8ee1f1e5.jfif', N'v', N'', CAST(27744.150 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:06:22.6174744' AS DateTime2), CAST(N'2021-07-30T15:07:33.6417349' AS DateTime2), 1, 3, N'ملاحظات', 1, N'+950-041-8529663', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (3, NULL, N'ديانا  لقق', N'621513063', N'لقق', N'', N'', N'', N'+963-333333333', N'71f020248a405d21e94d1de52043bed4.png', N'v', N'', CAST(-1211459000.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:06:41.9485466' AS DateTime2), CAST(N'2021-07-29T22:56:22.5252580' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (4, NULL, N'بيان  سليمان', N'498667622', N'سليمان', N'', N'', N'', N'+963-444444444', N'd2ec5f1ed83abfca0dfec76506b696b3.png', N'v', N'', CAST(105005.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:07:08.7041709' AS DateTime2), CAST(N'2021-07-31T21:05:00.4004167' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (5, NULL, N'أحمد   عقاد', N'637304317', N'عقاد', N'', N'', N'', N'+963-555555555', N'f96f8a89e2143f1e43a2ba7953fb5413.png', N'v', N'', CAST(10005016.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:07:20.4208470' AS DateTime2), CAST(N'2021-07-30T15:05:53.1409790' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (6, NULL, N'بشار   زيدان', N'591702965', N'زيدان', N'', N'', N'', N'+963-666666666', N'56a2e0231c3d394ace201adf37d13f63.png', N'v', N'', CAST(200066736.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:07:34.4228719' AS DateTime2), CAST(N'2021-07-29T17:17:50.2271591' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (7, NULL, N'محمد سودة', N'430477360', N'سودة', N'', N'', N'', N'+963-777777777', N'3204215c19f25609034d24451f7e03d7.jpg', N'v', N'', CAST(110000.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:07:45.7310231' AS DateTime2), CAST(N'2021-07-29T16:55:24.0185464' AS DateTime2), 1, 2, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (8, NULL, N'محمد   بهلوان', N'165693251', N'بهلوان', N'', N'', N'', N'+963-888888888', N'6a5d62c1233b5e9b2000dd13aadf81f4.png', N'v', N'', CAST(26288000.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:08:01.0595455' AS DateTime2), CAST(N'2021-07-29T16:43:42.1168260' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (9, NULL, N'سمر  كركوتلي', N'377866586', N'كركوتلي', N'', N'', N'', N'+966-999999999', N'6eaba1dc3c031faf262149c058fea728.png', N'c', N'', CAST(3329.250 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:08:45.2069660' AS DateTime2), CAST(N'2021-08-02T00:32:13.4240976' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (10, NULL, N'عمر  الحراكي', N'213417292', N'الحراكي', N'', N'', N'', N'+966-101010101', N'0f26776e0a524c7d2b6b5f771d500980.png', N'c', N'', CAST(12300.000 AS Decimal(20, 3)), 1, CAST(N'2021-06-30T16:08:58.0342271' AS DateTime2), CAST(N'2021-07-28T01:33:24.1241915' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (11, NULL, N'عمر  طيفور', N'778565517', N'طيفور', N'', N'', N'', N'+966-111111111', N'05da7ccc8020731d607471318fc4f35b.png', N'c', N'', CAST(6050.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:09:16.4003380' AS DateTime2), CAST(N'2021-07-26T12:04:33.7746378' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (12, NULL, N'عمر   معروف', N'35142864', N'معروف', N'', N'', N'', N'+966-121212121', N'0731f29a7d8c55ddab810a076d078aff.png', N'c', N'', CAST(-3700.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:09:40.9186322' AS DateTime2), CAST(N'2021-07-26T12:05:50.3282855' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (13, NULL, N'أمل  زيدان', N'57248015', N'زيدان', N'', N'', N'', N'+966-131313131', N'd24538a57424ec2d36086326b9215b74.png', N'c', N'', CAST(120000.000 AS Decimal(20, 3)), 1, CAST(N'2021-06-30T16:10:01.5456550' AS DateTime2), CAST(N'2021-07-28T11:13:01.1413348' AS DateTime2), 1, 1, N'', 1, N'', CAST(10000.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (14, NULL, N'قمر   كعكة', N'638671253', N'كعكة', N'', N'', N'', N'+966-141414141', N'ad4bfd50185ef68bce2b903aa7e10ec0.png', N'c', N'', CAST(1100.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:10:14.7478300' AS DateTime2), CAST(N'2021-07-26T12:17:06.4775025' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (15, NULL, N'طارق غباش', N'903957178', N'غباش', N'', N'', N'', N'+966-151515151', N'cfba0c3306a45ea0746c531906c58962.png', N'c', N'', CAST(500.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:10:32.6809829' AS DateTime2), CAST(N'2021-07-26T12:11:52.9283383' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (16, NULL, N'طه المحجوب', N'265078604', N'المحجوب', N'', N'', N'', N'+966-161616161', N'4361139d4379eb98f913441815402fe6.png', N'c', N'', CAST(-6000.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:10:42.7726056' AS DateTime2), CAST(N'2021-07-25T13:08:43.4044528' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (17, NULL, N'لونا  آغا', N'10043846', N'آغا', N'', N'', N'', N'+966-171717171', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:10:54.7602515' AS DateTime2), CAST(N'2021-06-30T16:10:54.7602515' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (18, NULL, N'ايمن  البكر', N'83368720', N'البكر', N'', N'', N'', N'+966-181818181', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:11:11.1459706' AS DateTime2), CAST(N'2021-06-30T16:11:11.1459706' AS DateTime2), 1, 1, N'', 1, N'', CAST(20000.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (19, NULL, N'هلا  بكداش', N'494240534', N'بكداش', N'', N'', N'', N'+966-191919191', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:12:11.0473459' AS DateTime2), CAST(N'2021-06-30T16:12:11.0473459' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (20, NULL, N'اية  الأحمد', N'327686608', N'الأحمد', N'', N'', N'', N'+966-202020202', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:12:29.8164362' AS DateTime2), CAST(N'2021-06-30T16:12:29.8164362' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (21, NULL, N'ندى ادلبي', N'947278245', N'ادلبي', N'', N'', N'', N'+966-212121212', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:12:42.4374840' AS DateTime2), CAST(N'2021-06-30T16:12:42.4374840' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (22, NULL, N'جود  كرزة', N'566869883', N'كرزة', N'', N'', N'', N'+966-222222222', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:12:55.0773452' AS DateTime2), CAST(N'2021-06-30T16:12:55.0773452' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (23, NULL, N'غيثاء والي', N'487521162', N'والي', N'', N'', N'', N'+966-232323232', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:13:13.7804093' AS DateTime2), CAST(N'2021-06-30T16:13:13.7804093' AS DateTime2), 1, 1, N'', 1, N'', CAST(500000.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (24, NULL, N'جمانة كرزة', N'949110884', N'كرزة', N'', N'', N'', N'+966-242424242', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:13:36.1745594' AS DateTime2), CAST(N'2021-06-30T16:13:36.1745594' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (25, NULL, N'راما حمامي', N'617817613', N'حمامي', N'', N'', N'', N'+966-252525252', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:13:50.5292915' AS DateTime2), CAST(N'2021-06-30T16:13:50.5292915' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (32, NULL, N'v1', N'v-000001', N'v1', N'', N'', N'+966--4558222', N'+966-096852552', N'', N'v', N'', CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-08-03T10:55:10.0737835' AS DateTime2), CAST(N'2021-08-03T10:55:10.0737835' AS DateTime2), 3, 3, N'', 1, N'+966--984111', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (33, NULL, N'c1', N'c-000001', N'c1', N'', N'', N'+966-3-3665821', N'+965-036694', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-08-03T10:55:56.7056308' AS DateTime2), CAST(N'2021-08-03T10:55:56.7056308' AS DateTime2), 3, 3, N'', 1, N'+966-2-656562632', CAST(100000.00 AS Decimal(20, 2)))
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
SET IDENTITY_INSERT [dbo].[branchesUsers] ON 

INSERT [dbo].[branchesUsers] ([branchsUsersId], [branchId], [userId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (8, 3, 21, CAST(N'2021-07-06T10:35:17.8206950' AS DateTime2), CAST(N'2021-07-06T10:35:17.8206950' AS DateTime2), 3, 3)
INSERT [dbo].[branchesUsers] ([branchsUsersId], [branchId], [userId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (9, 4, 21, CAST(N'2021-07-06T10:35:17.8206950' AS DateTime2), CAST(N'2021-07-06T10:35:17.8206950' AS DateTime2), 3, 3)
INSERT [dbo].[branchesUsers] ([branchsUsersId], [branchId], [userId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (10, 5, 21, CAST(N'2021-07-06T10:35:17.8206950' AS DateTime2), CAST(N'2021-07-06T10:35:17.8206950' AS DateTime2), 3, 3)
SET IDENTITY_INSERT [dbo].[branchesUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[branchStore] ON 

INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1, 3, 2, NULL, CAST(N'2021-07-05T05:13:16.1940536' AS DateTime2), CAST(N'2021-07-05T05:13:16.1940536' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, 3, 5, NULL, CAST(N'2021-07-05T05:13:16.2092900' AS DateTime2), CAST(N'2021-07-05T05:13:16.2092900' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, 3, 7, NULL, CAST(N'2021-07-05T05:13:16.2092900' AS DateTime2), CAST(N'2021-07-05T05:13:16.2092900' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (4, 3, 8, NULL, CAST(N'2021-07-05T05:13:16.2092900' AS DateTime2), CAST(N'2021-07-05T05:13:16.2092900' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (5, 12, 3, NULL, CAST(N'2021-07-05T05:13:46.8348339' AS DateTime2), CAST(N'2021-07-05T05:13:46.8348339' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (6, 12, 5, NULL, CAST(N'2021-07-05T05:13:46.8348339' AS DateTime2), CAST(N'2021-07-05T05:13:46.8348339' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (7, 12, 4, NULL, CAST(N'2021-07-05T05:13:46.8348339' AS DateTime2), CAST(N'2021-07-05T05:13:46.8348339' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (8, 12, 8, NULL, CAST(N'2021-07-05T05:13:46.8348339' AS DateTime2), CAST(N'2021-07-05T05:13:46.8348339' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (9, 12, 7, NULL, CAST(N'2021-07-05T05:13:46.8348339' AS DateTime2), CAST(N'2021-07-05T05:13:46.8348339' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (13, 2, 3, NULL, CAST(N'2021-07-06T10:31:46.8968127' AS DateTime2), CAST(N'2021-07-06T10:31:46.8968127' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (14, 2, 4, NULL, CAST(N'2021-07-06T10:31:46.8968127' AS DateTime2), CAST(N'2021-07-06T10:31:46.8968127' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (15, 2, 5, NULL, CAST(N'2021-07-06T10:31:46.8968127' AS DateTime2), CAST(N'2021-07-06T10:31:46.8968127' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (16, 2, 16, NULL, CAST(N'2021-07-06T10:31:46.8968127' AS DateTime2), CAST(N'2021-07-06T10:31:46.8968127' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (17, 2, 15, NULL, CAST(N'2021-07-06T10:31:46.8968127' AS DateTime2), CAST(N'2021-07-06T10:31:46.8968127' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (18, 2, 14, NULL, CAST(N'2021-07-06T10:31:46.8968127' AS DateTime2), CAST(N'2021-07-06T10:31:46.8968127' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (19, 11, 14, NULL, CAST(N'2021-07-06T10:46:26.4844285' AS DateTime2), CAST(N'2021-07-06T10:46:26.4844285' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (20, 11, 15, NULL, CAST(N'2021-07-06T10:46:26.4844285' AS DateTime2), CAST(N'2021-07-06T10:46:26.4844285' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (21, 11, 16, NULL, CAST(N'2021-07-06T10:46:26.4844285' AS DateTime2), CAST(N'2021-07-06T10:46:26.4844285' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (22, 16, 2, NULL, CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (23, 16, 3, NULL, CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (24, 16, 4, NULL, CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (25, 16, 5, NULL, CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (26, 16, 6, NULL, CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (27, 16, 7, NULL, CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (28, 16, 8, NULL, CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), CAST(N'2021-07-06T10:48:21.8759852' AS DateTime2), 3, 3, 1)
SET IDENTITY_INSERT [dbo].[branchStore] OFF
GO
SET IDENTITY_INSERT [dbo].[cards] ON 

INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1, N'Visa Card', N'', CAST(N'2021-06-30T17:57:16.0207327' AS DateTime2), CAST(N'2021-06-30T17:57:16.0207327' AS DateTime2), 1, 1, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'Master Card', N'', CAST(N'2021-06-30T17:57:25.2721667' AS DateTime2), CAST(N'2021-06-30T17:57:25.2721667' AS DateTime2), 1, 1, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, N'K-net', N'', CAST(N'2021-06-30T17:57:35.1366818' AS DateTime2), CAST(N'2021-06-30T17:57:35.1366818' AS DateTime2), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[cards] OFF
GO
SET IDENTITY_INSERT [dbo].[cashTransfer] ON 

INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (169, NULL, N'd', 2, NULL, NULL, 171, N'dc-000001', CAST(N'2021-08-01T12:14:12.5183169' AS DateTime2), CAST(N'2021-08-01T12:14:12.5183169' AS DateTime2), CAST(1050.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (170, NULL, N'd', 2, NULL, NULL, 172, N'dc-000002', CAST(N'2021-08-01T12:15:22.0449776' AS DateTime2), CAST(N'2021-08-01T12:15:22.0449776' AS DateTime2), CAST(1050.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (171, NULL, N'd', 2, NULL, 9, 178, N'dc-000003', CAST(N'2021-08-02T00:32:12.9015975' AS DateTime2), CAST(N'2021-08-02T00:32:12.9015975' AS DateTime2), CAST(11670.75 AS Decimal(20, 2)), 1, 1, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'balance', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (174, NULL, N'd', 2, 3, 10, 151, N'', CAST(N'2021-08-03T11:30:06.8252641' AS DateTime2), CAST(N'2021-08-03T11:30:06.8252641' AS DateTime2), CAST(1200.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (176, NULL, N'd', 2, 3, 10, 151, N'dc-000004', CAST(N'2021-08-03T14:36:26.1471992' AS DateTime2), CAST(N'2021-08-03T14:36:26.1471992' AS DateTime2), CAST(1200.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
SET IDENTITY_INSERT [dbo].[cashTransfer] OFF
GO
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (1, N'EL', N'الكترونيات', N'', N'57440ff6b80f068efd50410ea24fd593.jpg', 1, CAST(5.00 AS Decimal(20, 2)), 0, CAST(N'2021-07-01T11:29:48.5534758' AS DateTime2), CAST(N'2021-07-04T13:56:50.2113017' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (2, N'EL-PR', N'طابعات', N'', N'c37858823db0093766eee74d8ee1f1e5.png', 1, CAST(0.00 AS Decimal(20, 2)), 1, CAST(N'2021-07-01T11:43:04.0050266' AS DateTime2), CAST(N'2021-07-04T13:56:50.2432155' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (3, N'EL-PG', N'برامج', N'', N'71f020248a405d21e94d1de52043bed4.png', 1, CAST(0.00 AS Decimal(20, 2)), 1, CAST(N'2021-07-01T11:43:52.0819247' AS DateTime2), CAST(N'2021-07-04T13:56:50.2771253' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (4, N'EL-MB', N'جوالات', N'', N'd2ec5f1ed83abfca0dfec76506b696b3.png', 1, CAST(10.00 AS Decimal(20, 2)), 1, CAST(N'2021-07-01T11:44:42.7723305' AS DateTime2), CAST(N'2021-07-04T13:56:50.2821134' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (5, N'FD', N'غذائية', N'', N'f96f8a89e2143f1e43a2ba7953fb5413.png', 1, CAST(0.00 AS Decimal(20, 2)), 0, CAST(N'2021-07-01T11:45:28.0183676' AS DateTime2), CAST(N'2021-07-03T11:35:18.0991206' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (6, N'FD-CD', N'معلبات', N'', N'56a2e0231c3d394ace201adf37d13f63.jpg', 1, CAST(0.00 AS Decimal(20, 2)), 5, CAST(N'2021-07-01T11:45:48.3124572' AS DateTime2), CAST(N'2021-07-03T11:34:24.9697976' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (7, N'FD-FV', N'خضار وفواكه', N'', N'3204215c19f25609034d24451f7e03d7.jpg', 1, CAST(0.00 AS Decimal(20, 2)), 5, CAST(N'2021-07-01T11:46:33.4496662' AS DateTime2), CAST(N'2021-07-03T11:34:34.7354272' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (8, N'FD-CT', N'حلويات', N'', N'6a5d62c1233b5e9b2000dd13aadf81f4.jpg', 1, CAST(0.00 AS Decimal(20, 2)), 5, CAST(N'2021-07-01T11:46:58.1869891' AS DateTime2), CAST(N'2021-07-29T15:04:32.1061187' AS DateTime2), 1, 2, NULL)
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

INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (1, N'+965', N'KWD', N'Kuwait', 1)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (2, N'+966', N'SAR', N'Saudi Arabia', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (3, N'+968', N'OMR', N'Oman', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (4, N'+971', N'AED', N'United Arab Emirates', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (5, N'+974', N'QAR', N'Qatar', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (6, N'+973', N'BHD', N'Bahrain', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (7, N'+964', N'IQD', N'Iraq', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (8, N'+961', N'LBP', N'Lebanon', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (9, N'+963', N'SYP', N'Syria', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (10, N'+967', N'YER', N'Yemen', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (11, N'+962', N'JOD', N'Jordan', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (12, N'+213', N'DZD', N'Algeria', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (13, N'+20', N'EGP', N'Egypt', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (14, N'+216', N'TND', N'Tunisia', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (15, N'+249', N'SDG', N'Sudan', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (16, N'+212', N'MAD', N'Morocco', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (17, N'+218', N'LYD', N'Libya', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (18, N'+252', N'SOS', N'Somalia', 0)
INSERT [dbo].[countriesCodes] ([countryId], [code], [currency], [name], [isDefault]) VALUES (19, N'+90', N'TRY', N'Turkey', 0)
SET IDENTITY_INSERT [dbo].[countriesCodes] OFF
GO
SET IDENTITY_INSERT [dbo].[coupons] ON 

INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (1, N'Dis100', N'100', 1, 1, CAST(100.00 AS Decimal(20, 2)), CAST(N'2021-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-07-31T00:00:00.0000000' AS DateTime2), N'', 9, 7, CAST(0.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), CAST(N'2021-07-10T15:35:08.1261778' AS DateTime2), CAST(N'2021-07-10T15:36:37.1493609' AS DateTime2), 2, 2, N'cop-100')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (2, N'cop2021', N'212225', 1, 2, CAST(5.00 AS Decimal(20, 2)), CAST(N'2021-07-11T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-26T00:00:00.0000000' AS DateTime2), N'for vip customer', 100, 96, CAST(1.00 AS Decimal(20, 2)), CAST(100000.00 AS Decimal(20, 2)), CAST(N'2021-07-11T16:14:25.7570450' AS DateTime2), CAST(N'2021-07-11T16:14:25.7570450' AS DateTime2), 9, 9, N'cop-212225')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (3, N'كوبون حسم 10', N'10100', 1, 2, CAST(10.00 AS Decimal(20, 2)), CAST(N'2021-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-24T00:00:00.0000000' AS DateTime2), N'', 100, 99, CAST(1.00 AS Decimal(20, 2)), CAST(100000.00 AS Decimal(20, 2)), CAST(N'2021-07-11T17:07:35.4783488' AS DateTime2), CAST(N'2021-07-11T17:07:35.4783488' AS DateTime2), 9, 9, N'cop-10100')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (4, N'd2', N'd2', 1, 2, CAST(2.00 AS Decimal(20, 2)), CAST(N'2021-07-31T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-31T00:00:00.0000000' AS DateTime2), N'', 100, 100, CAST(1.00 AS Decimal(20, 2)), CAST(100.00 AS Decimal(20, 2)), CAST(N'2021-07-31T21:45:56.0549620' AS DateTime2), CAST(N'2021-07-31T21:45:56.0549620' AS DateTime2), 1, 1, N'cop-d2')
SET IDENTITY_INSERT [dbo].[coupons] OFF
GO
SET IDENTITY_INSERT [dbo].[docImages] ON 

INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (3, N'bntg2', N'1', N'ae73b244b30d62daa5f3f1a03d238333.png', N'invoices', N'ccccc', CAST(N'2021-07-24T10:30:40.0497793' AS DateTime2), CAST(N'2021-07-24T10:32:30.3474590' AS DateTime2), 1, 1, 63)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (4, N'ggfg', N'1', N'c6b970ed37eedb623905ea5793f19680.jpg', N'invoices', N'ccccc', CAST(N'2021-07-24T10:31:10.1906418' AS DateTime2), CAST(N'2021-07-24T10:31:10.1906418' AS DateTime2), 1, 1, 63)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (5, N'ييييي', N'pi-000031', N'2ac47fb532b6715c079c500eaa1c2c20.jpg', N'invoices', N'', CAST(N'2021-07-29T13:10:40.7271198' AS DateTime2), CAST(N'2021-07-29T13:10:40.7271198' AS DateTime2), 3, 3, 137)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (6, N'ئئئ', N'pi-000031', N'3a36c74946d8170a0fb993b3a1a89562.jpg', N'invoices', N'', CAST(N'2021-07-29T13:10:53.6522755' AS DateTime2), CAST(N'2021-07-29T13:10:53.6522755' AS DateTime2), 3, 3, 137)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (7, N'ئئئ', N'pi-000031', N'81afc1c85110af12dbc1d86490be864c.png', N'invoices', N'', CAST(N'2021-07-29T13:25:46.6166073' AS DateTime2), CAST(N'2021-07-29T13:26:17.2767749' AS DateTime2), 3, 3, 137)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (8, N'new', N'pi-000031', NULL, N'invoices', N'', CAST(N'2021-07-29T13:39:56.1958526' AS DateTime2), CAST(N'2021-07-29T13:39:56.1958526' AS DateTime2), 3, 3, 137)
SET IDENTITY_INSERT [dbo].[docImages] OFF
GO
SET IDENTITY_INSERT [dbo].[groupObject] ON 

INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (890, 11, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.2685418' AS DateTime2), CAST(N'2021-07-17T17:33:17.2685418' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (891, 11, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.2871218' AS DateTime2), CAST(N'2021-07-17T17:33:17.2871218' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (892, 11, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.2903348' AS DateTime2), CAST(N'2021-07-17T17:33:17.2903348' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (893, 11, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.2919647' AS DateTime2), CAST(N'2021-07-17T17:33:17.2919647' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (894, 11, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.2940755' AS DateTime2), CAST(N'2021-07-17T17:33:17.2940755' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (895, 11, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.2968604' AS DateTime2), CAST(N'2021-07-17T17:33:17.2968604' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (896, 11, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.2989880' AS DateTime2), CAST(N'2021-07-17T17:33:17.2989880' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (897, 11, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.3010780' AS DateTime2), CAST(N'2021-07-17T17:33:17.3010780' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (898, 11, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.3026631' AS DateTime2), CAST(N'2021-07-17T17:33:17.3026631' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (899, 11, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.3047604' AS DateTime2), CAST(N'2021-07-17T17:33:17.3047604' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (900, 11, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.3068782' AS DateTime2), CAST(N'2021-07-17T17:33:17.3068782' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (901, 11, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.3094829' AS DateTime2), CAST(N'2021-07-17T17:33:17.3094829' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (902, 11, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.3115451' AS DateTime2), CAST(N'2021-07-17T17:33:17.3115451' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (903, 11, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.3146499' AS DateTime2), CAST(N'2021-07-17T17:33:17.3146499' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (904, 11, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.3173584' AS DateTime2), CAST(N'2021-07-17T17:33:17.3173584' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (905, 11, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6054195' AS DateTime2), CAST(N'2021-07-17T17:33:17.6054195' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (906, 11, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6086372' AS DateTime2), CAST(N'2021-07-17T17:33:17.6086372' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (907, 11, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6112763' AS DateTime2), CAST(N'2021-07-17T17:33:17.6112763' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (908, 11, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6133613' AS DateTime2), CAST(N'2021-07-17T17:33:17.6133613' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (909, 11, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6154500' AS DateTime2), CAST(N'2021-07-17T17:33:17.6154500' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (910, 11, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6181398' AS DateTime2), CAST(N'2021-07-17T17:33:17.6181398' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (911, 11, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6202800' AS DateTime2), CAST(N'2021-07-17T17:33:17.6202800' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (912, 11, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6230975' AS DateTime2), CAST(N'2021-07-17T17:33:17.6230975' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (913, 11, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6252652' AS DateTime2), CAST(N'2021-07-17T17:33:17.6252652' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (914, 11, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6268526' AS DateTime2), CAST(N'2021-07-17T17:33:17.6268526' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (915, 11, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6289316' AS DateTime2), CAST(N'2021-07-17T17:33:17.6289316' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (916, 11, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6310227' AS DateTime2), CAST(N'2021-07-17T17:33:17.6310227' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (917, 11, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6336622' AS DateTime2), CAST(N'2021-07-17T17:33:17.6336622' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (918, 11, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6357323' AS DateTime2), CAST(N'2021-07-17T17:33:17.6357323' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (919, 11, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.6388850' AS DateTime2), CAST(N'2021-07-17T17:33:17.6388850' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (920, 11, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9249293' AS DateTime2), CAST(N'2021-07-17T17:33:17.9249293' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (921, 11, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9287331' AS DateTime2), CAST(N'2021-07-17T17:33:17.9287331' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (922, 11, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9308708' AS DateTime2), CAST(N'2021-07-17T17:33:17.9308708' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (923, 11, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9325383' AS DateTime2), CAST(N'2021-07-17T17:33:17.9325383' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (924, 11, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9357176' AS DateTime2), CAST(N'2021-07-17T17:33:17.9357176' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (925, 11, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9378222' AS DateTime2), CAST(N'2021-07-17T17:33:17.9378222' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (926, 11, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9395117' AS DateTime2), CAST(N'2021-07-17T17:33:17.9395117' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (927, 11, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9416302' AS DateTime2), CAST(N'2021-07-17T17:33:17.9416302' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (928, 11, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9432611' AS DateTime2), CAST(N'2021-07-17T17:33:17.9432611' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (929, 11, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9453551' AS DateTime2), CAST(N'2021-07-17T17:33:17.9453551' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (930, 11, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9485603' AS DateTime2), CAST(N'2021-07-17T17:33:17.9485603' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (931, 11, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9512693' AS DateTime2), CAST(N'2021-07-17T17:33:17.9512693' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (932, 11, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9534129' AS DateTime2), CAST(N'2021-07-17T17:33:17.9534129' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (933, 11, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9561581' AS DateTime2), CAST(N'2021-07-17T17:33:17.9561581' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (934, 11, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:17.9593332' AS DateTime2), CAST(N'2021-07-17T17:33:17.9593332' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (935, 11, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:18.2793311' AS DateTime2), CAST(N'2021-07-17T17:33:18.2793311' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (936, 11, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:18.2830292' AS DateTime2), CAST(N'2021-07-17T17:33:18.2830292' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (937, 11, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:18.2851841' AS DateTime2), CAST(N'2021-07-17T17:33:18.2851841' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (938, 11, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:18.2873111' AS DateTime2), CAST(N'2021-07-17T17:33:18.2873111' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (939, 11, 50, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:18.2889224' AS DateTime2), CAST(N'2021-07-17T17:39:27.5222619' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (940, 11, 51, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:18.2910273' AS DateTime2), CAST(N'2021-07-17T17:39:32.1860330' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (941, 11, 52, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:18.2931232' AS DateTime2), CAST(N'2021-07-18T10:27:30.4735689' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (942, 11, 53, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:18.2958534' AS DateTime2), CAST(N'2021-07-18T10:27:30.6925971' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (943, 11, 54, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:18.2979936' AS DateTime2), CAST(N'2021-07-17T17:39:44.8532976' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (944, 11, 55, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:18.3006380' AS DateTime2), CAST(N'2021-07-17T17:39:45.0750305' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (945, 11, 56, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:18.3038746' AS DateTime2), CAST(N'2021-07-17T17:40:30.1004683' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (946, 11, 57, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:18.3064784' AS DateTime2), CAST(N'2021-07-17T17:40:30.3211763' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (947, 11, 58, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:18.3086523' AS DateTime2), CAST(N'2021-07-17T17:40:36.3089992' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (948, 11, 59, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:18.3107189' AS DateTime2), CAST(N'2021-07-17T17:40:41.7289551' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (949, 11, 60, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:18.3134785' AS DateTime2), CAST(N'2021-07-17T17:40:47.4632569' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (950, 11, 61, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:18.5935953' AS DateTime2), CAST(N'2021-07-17T17:40:53.2394693' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (951, 11, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:18.6295563' AS DateTime2), CAST(N'2021-07-17T17:33:18.6295563' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (952, 11, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:18.6327641' AS DateTime2), CAST(N'2021-07-17T17:33:18.6327641' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (953, 11, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:18.6348425' AS DateTime2), CAST(N'2021-07-17T17:33:18.6348425' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (954, 11, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:18.6405535' AS DateTime2), CAST(N'2021-07-17T17:33:18.6405535' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (955, 11, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:18.6444242' AS DateTime2), CAST(N'2021-07-17T17:33:18.6444242' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (956, 11, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:18.6476100' AS DateTime2), CAST(N'2021-07-17T17:33:18.6476100' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (957, 11, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:18.6497347' AS DateTime2), CAST(N'2021-07-17T17:33:18.6497347' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (958, 11, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-17T17:33:18.6513805' AS DateTime2), CAST(N'2021-07-17T17:33:18.6513805' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (959, 11, 74, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:18.6545044' AS DateTime2), CAST(N'2021-07-17T17:47:28.2330247' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (960, 11, 75, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:18.6561467' AS DateTime2), CAST(N'2021-07-18T10:08:49.8832938' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (961, 11, 76, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:18.6582650' AS DateTime2), CAST(N'2021-07-17T17:47:43.6512822' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (962, 11, 77, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:18.6614697' AS DateTime2), CAST(N'2021-07-17T17:47:48.4069120' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (963, 11, 78, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:18.6631049' AS DateTime2), CAST(N'2021-07-17T17:39:20.3646425' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (964, 11, 79, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:18.6662607' AS DateTime2), CAST(N'2021-07-17T17:39:20.5920130' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (965, 11, 80, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.0066625' AS DateTime2), CAST(N'2021-07-17T17:39:17.0913890' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (966, 11, 81, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:19.0097989' AS DateTime2), CAST(N'2021-07-17T17:38:33.9609810' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (967, 11, 82, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:19.0129588' AS DateTime2), CAST(N'2021-07-17T17:46:41.2304274' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (968, 11, 83, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.0145407' AS DateTime2), CAST(N'2021-07-17T17:46:43.1884606' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (969, 11, 84, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:19.0744838' AS DateTime2), CAST(N'2021-07-17T17:46:54.8003181' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (970, 11, 85, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.0772038' AS DateTime2), CAST(N'2021-07-17T17:46:57.2270993' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (971, 11, 86, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.0803408' AS DateTime2), CAST(N'2021-07-18T10:08:32.1801352' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (972, 11, 87, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.0830149' AS DateTime2), CAST(N'2021-07-18T10:08:32.3986440' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (973, 11, 88, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.0851222' AS DateTime2), CAST(N'2021-07-18T10:08:32.6177121' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (974, 11, 89, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.0867105' AS DateTime2), CAST(N'2021-07-17T17:47:08.3113389' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (975, 11, 90, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.0898628' AS DateTime2), CAST(N'2021-07-17T17:47:07.5623824' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (976, 11, 91, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.0919871' AS DateTime2), CAST(N'2021-07-18T10:08:40.4456472' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (977, 11, 92, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.0946361' AS DateTime2), CAST(N'2021-07-18T10:08:40.6488475' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (978, 11, 93, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.0979033' AS DateTime2), CAST(N'2021-07-18T10:08:40.8834983' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (979, 11, 94, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.1005638' AS DateTime2), CAST(N'2021-07-17T17:47:15.6350586' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (980, 11, 95, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.4004613' AS DateTime2), CAST(N'2021-07-17T17:47:16.4751529' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (981, 11, 96, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.4030949' AS DateTime2), CAST(N'2021-07-18T10:08:36.5865335' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (982, 11, 97, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.4062151' AS DateTime2), CAST(N'2021-07-18T10:08:36.8050490' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (983, 11, 98, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.4083460' AS DateTime2), CAST(N'2021-07-18T10:08:37.0240130' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (984, 11, 99, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.4099823' AS DateTime2), CAST(N'2021-07-17T17:46:26.6393119' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (985, 11, 100, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.4120956' AS DateTime2), CAST(N'2021-07-17T17:46:29.1941649' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (986, 11, 101, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.4142477' AS DateTime2), CAST(N'2021-07-17T17:46:31.3539520' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (987, 11, 102, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.4169475' AS DateTime2), CAST(N'2021-07-18T10:08:10.8830008' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (988, 11, 103, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.4201528' AS DateTime2), CAST(N'2021-07-18T10:08:11.0864418' AS DateTime2), 2, 2, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (989, 11, 104, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.4218104' AS DateTime2), CAST(N'2021-07-18T10:08:11.3051199' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (990, 11, 105, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.4239344' AS DateTime2), CAST(N'2021-07-18T10:08:11.5238419' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (991, 11, 106, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.4267978' AS DateTime2), CAST(N'2021-07-18T10:08:11.7424370' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (992, 11, 107, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:19.4289812' AS DateTime2), CAST(N'2021-07-17T17:45:36.4776038' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (993, 11, 108, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:19.4306147' AS DateTime2), CAST(N'2021-07-17T17:45:42.0547159' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (994, 11, 109, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.4327457' AS DateTime2), CAST(N'2021-07-17T17:45:41.0497365' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (995, 11, 110, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:19.7197032' AS DateTime2), CAST(N'2021-07-18T09:57:21.8924916' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (996, 11, 111, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.7234856' AS DateTime2), CAST(N'2021-07-18T09:57:22.1424385' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (997, 11, 112, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.7255935' AS DateTime2), CAST(N'2021-07-17T17:45:53.1702237' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (998, 11, 113, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.7282810' AS DateTime2), CAST(N'2021-07-17T17:45:54.3195676' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (999, 11, 114, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:19.7304110' AS DateTime2), CAST(N'2021-07-17T17:46:17.5967595' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1000, 11, 115, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.7324702' AS DateTime2), CAST(N'2021-07-17T17:46:20.0478147' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1001, 11, 116, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:19.7351641' AS DateTime2), CAST(N'2021-07-18T10:08:17.9925754' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1002, 11, 117, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.7372872' AS DateTime2), CAST(N'2021-07-18T10:08:18.2267752' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1003, 11, 118, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.7401814' AS DateTime2), CAST(N'2021-07-18T10:08:18.4457658' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1004, 11, 119, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.7422846' AS DateTime2), CAST(N'2021-07-18T10:08:22.1330331' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1005, 11, 120, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.7450456' AS DateTime2), CAST(N'2021-07-18T10:08:22.3519703' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1006, 11, 121, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.7471705' AS DateTime2), CAST(N'2021-07-18T10:08:22.5705076' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1007, 11, 122, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.7499722' AS DateTime2), CAST(N'2021-07-17T17:41:18.0652106' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1008, 11, 123, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.7522539' AS DateTime2), CAST(N'2021-07-17T17:41:18.2967069' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1009, 11, 124, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:19.7539369' AS DateTime2), CAST(N'2021-07-17T17:41:21.7029803' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1010, 11, 125, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:20.0429495' AS DateTime2), CAST(N'2021-07-17T17:41:21.9324994' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1011, 11, 126, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:20.0467188' AS DateTime2), CAST(N'2021-07-17T17:41:24.4978908' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1012, 11, 127, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:20.0488494' AS DateTime2), CAST(N'2021-07-17T17:41:24.7118753' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1013, 11, 128, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:20.0509593' AS DateTime2), CAST(N'2021-07-17T17:41:28.3036730' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1014, 11, 129, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:20.0525814' AS DateTime2), CAST(N'2021-07-17T17:41:28.5162527' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1015, 11, 130, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:20.0546728' AS DateTime2), CAST(N'2021-07-18T10:08:00.3048885' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1016, 11, 131, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:20.0567664' AS DateTime2), CAST(N'2021-07-18T10:08:00.5238557' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1017, 11, 132, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:20.0584001' AS DateTime2), CAST(N'2021-07-18T10:08:03.5234580' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1018, 11, 133, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:20.0615999' AS DateTime2), CAST(N'2021-07-18T10:08:03.7423920' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1019, 11, 134, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:20.0643836' AS DateTime2), CAST(N'2021-07-17T17:41:12.9833759' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1020, 11, 135, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:20.0654182' AS DateTime2), CAST(N'2021-07-17T17:41:13.1975870' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1021, 11, 137, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-17T17:33:20.0685803' AS DateTime2), CAST(N'2021-07-18T10:08:50.1033760' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1022, 11, 138, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-17T17:33:20.0701736' AS DateTime2), CAST(N'2021-07-17T17:38:34.1805069' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1289, 14, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8529519' AS DateTime2), CAST(N'2021-07-18T10:10:16.8529519' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1290, 14, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8686761' AS DateTime2), CAST(N'2021-07-18T10:10:16.8686761' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1291, 14, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8686761' AS DateTime2), CAST(N'2021-07-18T10:10:16.8686761' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1292, 14, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8686761' AS DateTime2), CAST(N'2021-07-18T10:10:16.8686761' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1293, 14, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8686761' AS DateTime2), CAST(N'2021-07-18T10:10:16.8686761' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1294, 14, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1295, 14, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1296, 14, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1297, 14, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1298, 14, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1299, 14, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1300, 14, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1301, 14, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), CAST(N'2021-07-18T10:10:16.8838918' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1302, 14, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8995922' AS DateTime2), CAST(N'2021-07-18T10:10:16.8995922' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1303, 14, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:16.8995922' AS DateTime2), CAST(N'2021-07-18T10:10:16.8995922' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1304, 14, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.2902687' AS DateTime2), CAST(N'2021-07-18T10:10:17.2902687' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1305, 14, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1306, 14, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1307, 14, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1308, 14, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1309, 14, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1310, 14, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1311, 14, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), CAST(N'2021-07-18T10:10:17.3060032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1312, 14, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1313, 14, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1314, 14, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1315, 14, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1316, 14, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1317, 14, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1318, 14, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), CAST(N'2021-07-18T10:10:17.3217461' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1319, 14, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1320, 14, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1321, 14, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1322, 14, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1323, 14, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1324, 14, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1325, 14, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), CAST(N'2021-07-18T10:10:17.6652460' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1326, 14, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1327, 14, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1328, 14, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1329, 14, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1330, 14, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1331, 14, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1332, 14, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), CAST(N'2021-07-18T10:10:17.6810255' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1333, 14, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:17.6967508' AS DateTime2), CAST(N'2021-07-18T10:10:17.6967508' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1334, 14, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.0094143' AS DateTime2), CAST(N'2021-07-18T10:10:18.0094143' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1335, 14, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.0094143' AS DateTime2), CAST(N'2021-07-18T10:10:18.0094143' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1336, 14, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.0094143' AS DateTime2), CAST(N'2021-07-18T10:10:18.0094143' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1337, 14, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.0094143' AS DateTime2), CAST(N'2021-07-18T10:10:18.0094143' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1338, 14, 50, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1339, 14, 51, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1340, 14, 52, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1341, 14, 53, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1342, 14, 54, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1343, 14, 55, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1344, 14, 56, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1345, 14, 57, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), CAST(N'2021-07-18T10:10:18.0246259' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1346, 14, 58, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.0403566' AS DateTime2), CAST(N'2021-07-18T10:10:18.0403566' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1347, 14, 59, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.0403566' AS DateTime2), CAST(N'2021-07-18T10:10:18.0403566' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1348, 14, 60, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.0403566' AS DateTime2), CAST(N'2021-07-18T10:10:18.0403566' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1349, 14, 61, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.4624490' AS DateTime2), CAST(N'2021-07-18T10:10:18.4624490' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1350, 14, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1351, 14, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1352, 14, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1353, 14, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1354, 14, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), 2, 2, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1355, 14, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1356, 14, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), CAST(N'2021-07-18T10:10:18.4776876' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1357, 14, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1358, 14, 74, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1359, 14, 75, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1360, 14, 76, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1361, 14, 77, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1362, 14, 78, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1363, 14, 79, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), CAST(N'2021-07-18T10:10:18.4934373' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1364, 14, 80, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:21.8683377' AS DateTime2), CAST(N'2021-07-18T10:10:21.8683377' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1365, 14, 81, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:21.8683377' AS DateTime2), CAST(N'2021-07-18T10:10:21.8683377' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1366, 14, 82, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-18T10:10:21.8683377' AS DateTime2), CAST(N'2021-07-18T10:22:23.7835144' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1367, 14, 83, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:21.8683377' AS DateTime2), CAST(N'2021-07-18T10:22:24.0337284' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1368, 14, 84, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-18T10:10:21.8683377' AS DateTime2), CAST(N'2021-07-18T10:22:30.0961555' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1369, 14, 85, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:21.8840674' AS DateTime2), CAST(N'2021-07-18T10:22:30.3146391' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1370, 14, 86, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:21.8840674' AS DateTime2), CAST(N'2021-07-18T10:22:35.6741128' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1371, 14, 87, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:21.8840674' AS DateTime2), CAST(N'2021-07-18T10:22:35.8772422' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1372, 14, 88, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:21.8840674' AS DateTime2), CAST(N'2021-07-18T10:22:36.0960884' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1373, 14, 89, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:21.8840674' AS DateTime2), CAST(N'2021-07-18T10:22:39.7369242' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1374, 14, 90, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:21.8840674' AS DateTime2), CAST(N'2021-07-18T10:22:39.9555013' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1375, 14, 91, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:21.8840674' AS DateTime2), CAST(N'2021-07-18T10:22:44.6589388' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1376, 14, 92, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:21.8997791' AS DateTime2), CAST(N'2021-07-18T10:22:44.8801824' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1377, 14, 93, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:21.8997791' AS DateTime2), CAST(N'2021-07-18T10:22:45.0963487' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1378, 14, 94, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:21.8997791' AS DateTime2), CAST(N'2021-07-18T10:22:48.6275051' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1379, 14, 95, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:22.2124435' AS DateTime2), CAST(N'2021-07-18T10:22:48.8626372' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1380, 14, 96, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:22.2124435' AS DateTime2), CAST(N'2021-07-18T10:22:52.2058098' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1381, 14, 97, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), CAST(N'2021-07-18T10:22:52.4242135' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1382, 14, 98, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), CAST(N'2021-07-18T10:22:52.6431254' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1383, 14, 99, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1384, 14, 100, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1385, 14, 101, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1386, 14, 102, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1387, 14, 103, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1388, 14, 104, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), CAST(N'2021-07-18T10:10:22.2281357' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1389, 14, 105, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:22.2433845' AS DateTime2), CAST(N'2021-07-18T10:10:22.2433845' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1390, 14, 106, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:22.2433845' AS DateTime2), CAST(N'2021-07-18T10:10:22.2433845' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1391, 14, 107, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:22.2433845' AS DateTime2), CAST(N'2021-07-18T10:10:22.2433845' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1392, 14, 108, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:22.2433845' AS DateTime2), CAST(N'2021-07-18T10:10:22.2433845' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1393, 14, 109, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:22.2433845' AS DateTime2), CAST(N'2021-07-18T10:10:22.2433845' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1394, 14, 110, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:25.6497682' AS DateTime2), CAST(N'2021-07-18T10:10:25.6497682' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1395, 14, 111, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:25.6497682' AS DateTime2), CAST(N'2021-07-18T10:10:25.6497682' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1396, 14, 112, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:25.6497682' AS DateTime2), CAST(N'2021-07-18T10:10:25.6497682' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1397, 14, 113, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:25.6497682' AS DateTime2), CAST(N'2021-07-18T10:10:25.6497682' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1398, 14, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1399, 14, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1400, 14, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1401, 14, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1402, 14, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1403, 14, 119, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1404, 14, 120, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), CAST(N'2021-07-18T10:10:25.6654662' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1405, 14, 121, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:25.6812048' AS DateTime2), CAST(N'2021-07-18T10:10:25.6812048' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1406, 14, 122, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:25.6812048' AS DateTime2), CAST(N'2021-07-18T10:10:25.6812048' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1407, 14, 123, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:25.6812048' AS DateTime2), CAST(N'2021-07-18T10:10:25.6812048' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1408, 14, 124, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:25.6812048' AS DateTime2), CAST(N'2021-07-18T10:10:25.6812048' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1409, 14, 125, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:29.1031478' AS DateTime2), CAST(N'2021-07-18T10:10:29.1031478' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1410, 14, 126, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:29.1031478' AS DateTime2), CAST(N'2021-07-18T10:10:29.1031478' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1411, 14, 127, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:29.1031478' AS DateTime2), CAST(N'2021-07-18T10:10:29.1031478' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1412, 14, 128, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:29.1031478' AS DateTime2), CAST(N'2021-07-18T10:10:29.1031478' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1413, 14, 129, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:29.1031478' AS DateTime2), CAST(N'2021-07-18T10:10:29.1031478' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1414, 14, 130, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:29.1031478' AS DateTime2), CAST(N'2021-07-18T10:10:29.1031478' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1415, 14, 131, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1416, 14, 132, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1417, 14, 133, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1418, 14, 134, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1419, 14, 135, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1420, 14, 137, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1421, 14, 138, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), CAST(N'2021-07-18T10:10:29.1183520' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1422, 15, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.3614409' AS DateTime2), CAST(N'2021-07-18T10:21:34.3614409' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1423, 15, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.3766729' AS DateTime2), CAST(N'2021-07-18T10:21:34.3766729' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1424, 15, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.3766729' AS DateTime2), CAST(N'2021-07-18T10:21:34.3766729' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1425, 15, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.3766729' AS DateTime2), CAST(N'2021-07-18T10:21:34.3766729' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1426, 15, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.3766729' AS DateTime2), CAST(N'2021-07-18T10:21:34.3766729' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1427, 15, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.3766729' AS DateTime2), CAST(N'2021-07-18T10:21:34.3766729' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1428, 15, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.3766729' AS DateTime2), CAST(N'2021-07-18T10:21:34.3766729' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1429, 15, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.4295133' AS DateTime2), CAST(N'2021-07-18T10:21:34.4295133' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1430, 15, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.4295133' AS DateTime2), CAST(N'2021-07-18T10:21:34.4295133' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1431, 15, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.4295133' AS DateTime2), CAST(N'2021-07-18T10:21:34.4295133' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1432, 15, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.4295133' AS DateTime2), CAST(N'2021-07-18T10:21:34.4295133' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1433, 15, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.4295133' AS DateTime2), CAST(N'2021-07-18T10:21:34.4295133' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1434, 15, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.4413170' AS DateTime2), CAST(N'2021-07-18T10:21:34.4413170' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1435, 15, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.4413170' AS DateTime2), CAST(N'2021-07-18T10:21:34.4413170' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1436, 15, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.4413170' AS DateTime2), CAST(N'2021-07-18T10:21:34.4413170' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1437, 15, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7207229' AS DateTime2), CAST(N'2021-07-18T10:21:34.7207229' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1438, 15, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7207229' AS DateTime2), CAST(N'2021-07-18T10:21:34.7207229' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1439, 15, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1440, 15, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1441, 15, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1442, 15, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1443, 15, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1444, 15, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1445, 15, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1446, 15, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), CAST(N'2021-07-18T10:21:34.7364316' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1447, 15, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7516679' AS DateTime2), CAST(N'2021-07-18T10:21:34.7516679' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1448, 15, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7516679' AS DateTime2), CAST(N'2021-07-18T10:21:34.7516679' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1449, 15, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7516679' AS DateTime2), CAST(N'2021-07-18T10:21:34.7516679' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1450, 15, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7516679' AS DateTime2), CAST(N'2021-07-18T10:21:34.7516679' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1451, 15, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:34.7516679' AS DateTime2), CAST(N'2021-07-18T10:21:34.7516679' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1452, 15, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0485719' AS DateTime2), CAST(N'2021-07-18T10:21:35.0485719' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1453, 15, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0485719' AS DateTime2), CAST(N'2021-07-18T10:21:35.0485719' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1454, 15, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0485719' AS DateTime2), CAST(N'2021-07-18T10:21:35.0485719' AS DateTime2), 2, 2, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1455, 15, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1456, 15, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1457, 15, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1458, 15, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1459, 15, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1460, 15, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1461, 15, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1462, 15, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), CAST(N'2021-07-18T10:21:35.0643402' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1463, 15, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0800087' AS DateTime2), CAST(N'2021-07-18T10:21:35.0800087' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1464, 15, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0800087' AS DateTime2), CAST(N'2021-07-18T10:21:35.0800087' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1465, 15, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0800087' AS DateTime2), CAST(N'2021-07-18T10:21:35.0800087' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1466, 15, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.0800087' AS DateTime2), CAST(N'2021-07-18T10:21:35.0800087' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1467, 15, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.3771209' AS DateTime2), CAST(N'2021-07-18T10:21:35.3771209' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1468, 15, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.3771209' AS DateTime2), CAST(N'2021-07-18T10:21:35.3771209' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1469, 15, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.3771209' AS DateTime2), CAST(N'2021-07-18T10:21:35.3771209' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1470, 15, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.3771209' AS DateTime2), CAST(N'2021-07-18T10:21:35.3771209' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1471, 15, 50, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.3771209' AS DateTime2), CAST(N'2021-07-18T10:21:35.3771209' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1472, 15, 51, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.3771209' AS DateTime2), CAST(N'2021-07-18T10:21:35.3771209' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1473, 15, 52, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1474, 15, 53, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1475, 15, 54, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1476, 15, 55, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1477, 15, 56, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1478, 15, 57, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1479, 15, 58, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1480, 15, 59, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), CAST(N'2021-07-18T10:21:35.3923369' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1481, 15, 60, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.4080621' AS DateTime2), CAST(N'2021-07-18T10:21:35.4080621' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1482, 15, 61, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.6737571' AS DateTime2), CAST(N'2021-07-18T10:21:35.6737571' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1483, 15, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1484, 15, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1485, 15, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1486, 15, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1487, 15, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1488, 15, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1489, 15, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), CAST(N'2021-07-18T10:21:35.6894592' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1490, 15, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1491, 15, 74, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1492, 15, 75, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1493, 15, 76, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1494, 15, 77, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1495, 15, 78, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1496, 15, 79, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), CAST(N'2021-07-18T10:21:35.7052096' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1497, 15, 80, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1498, 15, 81, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1499, 15, 82, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1500, 15, 83, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1501, 15, 84, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1502, 15, 85, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1503, 15, 86, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), CAST(N'2021-07-18T10:21:36.0016840' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1504, 15, 87, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1505, 15, 88, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1506, 15, 89, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1507, 15, 90, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1508, 15, 91, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1509, 15, 92, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1510, 15, 93, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1511, 15, 94, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), CAST(N'2021-07-18T10:21:36.0173597' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1512, 15, 95, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1513, 15, 96, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1514, 15, 97, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1515, 15, 98, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1516, 15, 99, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1517, 15, 100, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1518, 15, 101, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1519, 15, 102, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), CAST(N'2021-07-18T10:21:36.3142418' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1520, 15, 103, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1521, 15, 104, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1522, 15, 105, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1523, 15, 106, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1524, 15, 107, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1525, 15, 108, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1526, 15, 109, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), CAST(N'2021-07-18T10:21:36.3299530' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1527, 15, 110, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1528, 15, 111, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1529, 15, 112, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1530, 15, 113, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1531, 15, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1532, 15, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1533, 15, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), CAST(N'2021-07-18T10:21:36.6270704' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1534, 15, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.6427688' AS DateTime2), CAST(N'2021-07-18T10:21:36.6427688' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1535, 15, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.6427688' AS DateTime2), CAST(N'2021-07-18T10:21:36.6427688' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1536, 15, 119, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.6427688' AS DateTime2), CAST(N'2021-07-18T10:21:36.6427688' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1537, 15, 120, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.6427688' AS DateTime2), CAST(N'2021-07-18T10:21:36.6427688' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1538, 15, 121, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.6427688' AS DateTime2), CAST(N'2021-07-18T10:21:36.6427688' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1539, 15, 122, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:36.6427688' AS DateTime2), CAST(N'2021-07-18T10:23:13.3310316' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1540, 15, 123, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:36.6427688' AS DateTime2), CAST(N'2021-07-18T10:23:13.5496426' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1541, 15, 124, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:36.6427688' AS DateTime2), CAST(N'2021-07-18T10:23:18.8307774' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1542, 15, 125, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:36.9393533' AS DateTime2), CAST(N'2021-07-18T10:23:19.0496128' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1543, 15, 126, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:36.9550470' AS DateTime2), CAST(N'2021-07-18T10:23:22.2217789' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1544, 15, 127, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:36.9550470' AS DateTime2), CAST(N'2021-07-18T10:23:22.4403843' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1545, 15, 128, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:36.9550470' AS DateTime2), CAST(N'2021-07-18T10:23:25.3620393' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1546, 15, 129, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:36.9550470' AS DateTime2), CAST(N'2021-07-18T10:23:25.5809962' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1547, 15, 130, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:36.9550470' AS DateTime2), CAST(N'2021-07-18T10:23:35.2062504' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1548, 15, 131, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:36.9550470' AS DateTime2), CAST(N'2021-07-18T10:23:35.4248679' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1549, 15, 132, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:36.9707409' AS DateTime2), CAST(N'2021-07-18T10:23:29.2372240' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1550, 15, 133, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:36.9707409' AS DateTime2), CAST(N'2021-07-18T10:23:29.4718540' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1551, 15, 134, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-18T10:21:36.9707409' AS DateTime2), CAST(N'2021-07-18T10:23:15.7997426' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1552, 15, 135, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:36.9707409' AS DateTime2), CAST(N'2021-07-18T10:23:16.0183958' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1553, 15, 137, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:36.9707409' AS DateTime2), CAST(N'2021-07-18T10:21:36.9707409' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1554, 15, 138, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:36.9707409' AS DateTime2), CAST(N'2021-07-18T10:21:36.9707409' AS DateTime2), 2, 2, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1555, 16, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4238660' AS DateTime2), CAST(N'2021-07-18T10:21:56.4238660' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1556, 16, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4395625' AS DateTime2), CAST(N'2021-07-18T10:21:56.4395625' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1557, 16, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4395625' AS DateTime2), CAST(N'2021-07-18T10:21:56.4395625' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1558, 16, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4395625' AS DateTime2), CAST(N'2021-07-18T10:21:56.4395625' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1559, 16, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4395625' AS DateTime2), CAST(N'2021-07-18T10:21:56.4395625' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1560, 16, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4395625' AS DateTime2), CAST(N'2021-07-18T10:21:56.4395625' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1561, 16, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4395625' AS DateTime2), CAST(N'2021-07-18T10:21:56.4395625' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1562, 16, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1563, 16, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1564, 16, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1565, 16, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1566, 16, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1567, 16, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1568, 16, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1569, 16, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), CAST(N'2021-07-18T10:21:56.4552544' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1570, 16, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7518163' AS DateTime2), CAST(N'2021-07-18T10:21:56.7518163' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1571, 16, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7518163' AS DateTime2), CAST(N'2021-07-18T10:21:56.7518163' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1572, 16, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7518163' AS DateTime2), CAST(N'2021-07-18T10:21:56.7518163' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1573, 16, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7518163' AS DateTime2), CAST(N'2021-07-18T10:21:56.7518163' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1574, 16, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1575, 16, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1576, 16, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1577, 16, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1578, 16, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1579, 16, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1580, 16, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1581, 16, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1582, 16, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), CAST(N'2021-07-18T10:21:56.7675894' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1583, 16, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7832611' AS DateTime2), CAST(N'2021-07-18T10:21:56.7832611' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1584, 16, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:56.7832611' AS DateTime2), CAST(N'2021-07-18T10:21:56.7832611' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1585, 16, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.0803222' AS DateTime2), CAST(N'2021-07-18T10:21:57.0803222' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1586, 16, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.0803222' AS DateTime2), CAST(N'2021-07-18T10:21:57.0803222' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1587, 16, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.0803222' AS DateTime2), CAST(N'2021-07-18T10:21:57.0803222' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1588, 16, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.0803222' AS DateTime2), CAST(N'2021-07-18T10:21:57.0803222' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1589, 16, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.0803222' AS DateTime2), CAST(N'2021-07-18T10:21:57.0803222' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1590, 16, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.0959955' AS DateTime2), CAST(N'2021-07-18T10:21:57.0959955' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1591, 16, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.0959955' AS DateTime2), CAST(N'2021-07-18T10:21:57.0959955' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1592, 16, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.0959955' AS DateTime2), CAST(N'2021-07-18T10:21:57.0959955' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1593, 16, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.0959955' AS DateTime2), CAST(N'2021-07-18T10:21:57.0959955' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1594, 16, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.0959955' AS DateTime2), CAST(N'2021-07-18T10:21:57.0959955' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1595, 16, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.1116912' AS DateTime2), CAST(N'2021-07-18T10:21:57.1116912' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1596, 16, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.1116912' AS DateTime2), CAST(N'2021-07-18T10:21:57.1116912' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1597, 16, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.1116912' AS DateTime2), CAST(N'2021-07-18T10:21:57.1116912' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1598, 16, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.1116912' AS DateTime2), CAST(N'2021-07-18T10:21:57.1116912' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1599, 16, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.1269005' AS DateTime2), CAST(N'2021-07-18T10:21:57.1269005' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1600, 16, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.4551231' AS DateTime2), CAST(N'2021-07-18T10:21:57.4551231' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1601, 16, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.4551231' AS DateTime2), CAST(N'2021-07-18T10:21:57.4551231' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1602, 16, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.4551231' AS DateTime2), CAST(N'2021-07-18T10:21:57.4551231' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1603, 16, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.4551231' AS DateTime2), CAST(N'2021-07-18T10:21:57.4551231' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1604, 16, 50, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.4551231' AS DateTime2), CAST(N'2021-07-18T10:21:57.4551231' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1605, 16, 51, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.4551231' AS DateTime2), CAST(N'2021-07-18T10:21:57.4551231' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1606, 16, 52, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1607, 16, 53, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1608, 16, 54, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1609, 16, 55, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1610, 16, 56, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1611, 16, 57, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1612, 16, 58, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), CAST(N'2021-07-18T10:21:57.4708387' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1613, 16, 59, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.4865326' AS DateTime2), CAST(N'2021-07-18T10:21:57.4865326' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1614, 16, 60, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.4865326' AS DateTime2), CAST(N'2021-07-18T10:21:57.4865326' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1615, 16, 61, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.7677353' AS DateTime2), CAST(N'2021-07-18T10:21:57.7677353' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1616, 16, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.7677353' AS DateTime2), CAST(N'2021-07-18T10:21:57.7677353' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1617, 16, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.7677353' AS DateTime2), CAST(N'2021-07-18T10:21:57.7677353' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1618, 16, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1619, 16, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1620, 16, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1621, 16, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1622, 16, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1623, 16, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1624, 16, 74, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1625, 16, 75, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1626, 16, 76, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), CAST(N'2021-07-18T10:21:57.7834032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1627, 16, 77, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:57.7990965' AS DateTime2), CAST(N'2021-07-18T10:21:57.7990965' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1628, 16, 78, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:57.7990965' AS DateTime2), CAST(N'2021-07-18T10:21:57.7990965' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1629, 16, 79, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:57.7990965' AS DateTime2), CAST(N'2021-07-18T10:21:57.7990965' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1630, 16, 80, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.0803461' AS DateTime2), CAST(N'2021-07-18T10:21:58.0803461' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1631, 16, 81, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1632, 16, 82, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1633, 16, 83, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1634, 16, 84, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1635, 16, 85, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1636, 16, 86, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1637, 16, 87, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1638, 16, 88, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), CAST(N'2021-07-18T10:21:58.0960240' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1639, 16, 89, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.1112541' AS DateTime2), CAST(N'2021-07-18T10:21:58.1112541' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1640, 16, 90, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.1112541' AS DateTime2), CAST(N'2021-07-18T10:21:58.1112541' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1641, 16, 91, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.1112541' AS DateTime2), CAST(N'2021-07-18T10:21:58.1112541' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1642, 16, 92, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.1112541' AS DateTime2), CAST(N'2021-07-18T10:21:58.1112541' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1643, 16, 93, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.1112541' AS DateTime2), CAST(N'2021-07-18T10:21:58.1112541' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1644, 16, 94, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.1112541' AS DateTime2), CAST(N'2021-07-18T10:21:58.1112541' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1645, 16, 95, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.4082324' AS DateTime2), CAST(N'2021-07-18T10:21:58.4082324' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1646, 16, 96, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.4082324' AS DateTime2), CAST(N'2021-07-18T10:21:58.4082324' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1647, 16, 97, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.4082324' AS DateTime2), CAST(N'2021-07-18T10:21:58.4082324' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1648, 16, 98, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.4082324' AS DateTime2), CAST(N'2021-07-18T10:21:58.4082324' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1649, 16, 99, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:58.4239069' AS DateTime2), CAST(N'2021-07-18T10:24:27.5033900' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1650, 16, 100, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:58.4239069' AS DateTime2), CAST(N'2021-07-18T10:24:27.7219997' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1651, 16, 101, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:58.4239069' AS DateTime2), CAST(N'2021-07-18T10:24:27.9410350' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1652, 16, 102, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:58.4239069' AS DateTime2), CAST(N'2021-07-18T10:23:57.7376423' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1653, 16, 103, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:58.4239069' AS DateTime2), CAST(N'2021-07-18T10:23:58.0813518' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1654, 16, 104, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:58.4239069' AS DateTime2), CAST(N'2021-07-18T10:23:58.2998274' AS DateTime2), 2, 2, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1655, 16, 105, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:58.4239069' AS DateTime2), CAST(N'2021-07-18T10:23:58.5187951' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1656, 16, 106, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:58.4239069' AS DateTime2), CAST(N'2021-07-18T10:23:58.7377578' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1657, 16, 107, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:58.4396438' AS DateTime2), CAST(N'2021-07-18T10:21:58.4396438' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1658, 16, 108, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:58.4396438' AS DateTime2), CAST(N'2021-07-18T10:21:58.4396438' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1659, 16, 109, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.4396438' AS DateTime2), CAST(N'2021-07-18T10:21:58.4396438' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1660, 16, 110, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:58.7210164' AS DateTime2), CAST(N'2021-07-18T10:21:58.7210164' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1661, 16, 111, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.7210164' AS DateTime2), CAST(N'2021-07-18T10:21:58.7210164' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1662, 16, 112, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1663, 16, 113, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1664, 16, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1665, 16, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1666, 16, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1667, 16, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1668, 16, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1669, 16, 119, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:58.7367288' AS DateTime2), CAST(N'2021-07-18T10:24:16.7688708' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1670, 16, 120, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:58.7519583' AS DateTime2), CAST(N'2021-07-18T10:24:16.9878330' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1671, 16, 121, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-18T10:21:58.7519583' AS DateTime2), CAST(N'2021-07-18T10:24:17.2063057' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1672, 16, 122, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.7519583' AS DateTime2), CAST(N'2021-07-18T10:21:58.7519583' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1673, 16, 123, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.7519583' AS DateTime2), CAST(N'2021-07-18T10:21:58.7519583' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1674, 16, 124, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:58.7519583' AS DateTime2), CAST(N'2021-07-18T10:21:58.7519583' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1675, 16, 125, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1676, 16, 126, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1677, 16, 127, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1678, 16, 128, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1679, 16, 129, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1680, 16, 130, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1681, 16, 131, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), CAST(N'2021-07-18T10:21:59.0332271' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1682, 16, 132, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:59.0489719' AS DateTime2), CAST(N'2021-07-18T10:21:59.0489719' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1683, 16, 133, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:59.0489719' AS DateTime2), CAST(N'2021-07-18T10:21:59.0489719' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1684, 16, 134, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:59.0489719' AS DateTime2), CAST(N'2021-07-18T10:21:59.0489719' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1685, 16, 135, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:59.0489719' AS DateTime2), CAST(N'2021-07-18T10:21:59.0489719' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1686, 16, 137, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-07-18T10:21:59.0489719' AS DateTime2), CAST(N'2021-07-18T10:21:59.0489719' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1687, 16, 138, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-07-18T10:21:59.0489719' AS DateTime2), CAST(N'2021-07-18T10:21:59.0489719' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1688, 17, 1, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.8538751' AS DateTime2), CAST(N'2021-07-27T15:04:22.8538751' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1689, 17, 2, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.8696128' AS DateTime2), CAST(N'2021-07-27T15:04:22.8696128' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1690, 17, 3, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.8696128' AS DateTime2), CAST(N'2021-07-27T15:04:22.8696128' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1691, 17, 4, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.8696128' AS DateTime2), CAST(N'2021-07-27T15:04:22.8696128' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1692, 17, 5, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.8696128' AS DateTime2), CAST(N'2021-07-27T15:04:22.8696128' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1693, 17, 6, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1694, 17, 7, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1695, 17, 8, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1696, 17, 9, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1697, 17, 10, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1698, 17, 11, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1699, 17, 12, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1700, 17, 13, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), CAST(N'2021-07-27T15:04:22.8852735' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1701, 17, 14, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.9005015' AS DateTime2), CAST(N'2021-07-27T15:04:22.9005015' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1702, 17, 15, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:22.9005015' AS DateTime2), CAST(N'2021-07-27T15:04:22.9005015' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1703, 17, 16, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1704, 17, 17, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1705, 17, 18, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1706, 17, 19, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1707, 17, 20, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1708, 17, 21, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1709, 17, 22, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1710, 17, 23, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), CAST(N'2021-07-27T15:04:23.2601558' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1711, 17, 24, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1712, 17, 25, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1713, 17, 26, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1714, 17, 27, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1715, 17, 28, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1716, 17, 29, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1717, 17, 30, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), CAST(N'2021-07-27T15:04:23.2758717' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1718, 17, 31, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.7756254' AS DateTime2), CAST(N'2021-07-27T15:04:23.7756254' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1719, 17, 32, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.7756254' AS DateTime2), CAST(N'2021-07-27T15:04:23.7756254' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1720, 17, 33, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1721, 17, 34, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1722, 17, 35, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1723, 17, 36, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1724, 17, 37, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1725, 17, 38, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1726, 17, 39, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), CAST(N'2021-07-27T15:04:23.7913350' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1727, 17, 40, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.8070462' AS DateTime2), CAST(N'2021-07-27T15:04:23.8070462' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1728, 17, 41, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.8070462' AS DateTime2), CAST(N'2021-07-27T15:04:23.8070462' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1729, 17, 42, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.8070462' AS DateTime2), CAST(N'2021-07-27T15:04:23.8070462' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1730, 17, 43, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.8070462' AS DateTime2), CAST(N'2021-07-27T15:04:23.8070462' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1731, 17, 44, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.8070462' AS DateTime2), CAST(N'2021-07-27T15:04:23.8070462' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1732, 17, 45, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:23.8070462' AS DateTime2), CAST(N'2021-07-27T15:04:23.8070462' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1733, 17, 46, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.1035966' AS DateTime2), CAST(N'2021-07-27T15:04:24.1035966' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1734, 17, 47, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.1035966' AS DateTime2), CAST(N'2021-07-27T15:04:24.1035966' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1735, 17, 48, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.1035966' AS DateTime2), CAST(N'2021-07-27T15:04:24.1035966' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1736, 17, 49, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.1035966' AS DateTime2), CAST(N'2021-07-27T15:04:24.1035966' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1737, 17, 50, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.1035966' AS DateTime2), CAST(N'2021-07-27T15:04:24.1035966' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1738, 17, 51, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1739, 17, 52, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1740, 17, 53, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1741, 17, 54, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1742, 17, 55, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1743, 17, 56, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1744, 17, 57, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1745, 17, 58, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), CAST(N'2021-07-27T15:04:24.1193009' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1746, 17, 59, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.1349948' AS DateTime2), CAST(N'2021-07-27T15:04:24.1349948' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1747, 17, 60, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.1349948' AS DateTime2), CAST(N'2021-07-27T15:04:24.1349948' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1748, 17, 61, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.4162582' AS DateTime2), CAST(N'2021-07-27T15:04:24.4162582' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1749, 17, 63, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.4162582' AS DateTime2), CAST(N'2021-07-27T15:04:24.4162582' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1750, 17, 65, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.4162582' AS DateTime2), CAST(N'2021-07-27T15:04:24.4162582' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1751, 17, 67, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1752, 17, 68, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1753, 17, 69, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1754, 17, 70, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), 2, 2, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1755, 17, 71, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1756, 17, 72, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1757, 17, 74, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1758, 17, 75, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), CAST(N'2021-07-27T15:04:24.4319836' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1759, 17, 76, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.4477284' AS DateTime2), CAST(N'2021-07-27T15:04:24.4477284' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1760, 17, 77, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.4477284' AS DateTime2), CAST(N'2021-07-27T15:04:24.4477284' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1761, 17, 78, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.4477284' AS DateTime2), CAST(N'2021-07-27T15:04:24.4477284' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1762, 17, 79, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.4477284' AS DateTime2), CAST(N'2021-07-27T15:04:24.4477284' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1763, 17, 80, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.7287278' AS DateTime2), CAST(N'2021-07-27T15:04:24.7287278' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1764, 17, 81, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.7287278' AS DateTime2), CAST(N'2021-07-27T15:04:24.7287278' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1765, 17, 82, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.7287278' AS DateTime2), CAST(N'2021-07-27T15:04:24.7287278' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1766, 17, 83, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1767, 17, 84, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1768, 17, 85, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1769, 17, 86, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1770, 17, 87, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1771, 17, 88, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1772, 17, 89, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1773, 17, 90, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), CAST(N'2021-07-27T15:04:24.7445456' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1774, 17, 91, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.7602070' AS DateTime2), CAST(N'2021-07-27T15:04:24.7602070' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1775, 17, 92, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.7602070' AS DateTime2), CAST(N'2021-07-27T15:04:24.7602070' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1776, 17, 93, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.7602070' AS DateTime2), CAST(N'2021-07-27T15:04:24.7602070' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1777, 17, 94, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:24.7602070' AS DateTime2), CAST(N'2021-07-27T15:04:24.7602070' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1778, 17, 95, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.0567859' AS DateTime2), CAST(N'2021-07-27T15:04:25.0567859' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1779, 17, 96, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.0567859' AS DateTime2), CAST(N'2021-07-27T15:04:25.0567859' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1780, 17, 97, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.0567859' AS DateTime2), CAST(N'2021-07-27T15:04:25.0567859' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1781, 17, 98, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.0567859' AS DateTime2), CAST(N'2021-07-27T15:04:25.0567859' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1782, 17, 99, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1783, 17, 100, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1784, 17, 101, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1785, 17, 102, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1786, 17, 103, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1787, 17, 104, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1788, 17, 105, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1789, 17, 106, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), CAST(N'2021-07-27T15:04:25.0724691' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1790, 17, 107, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:25.0881858' AS DateTime2), CAST(N'2021-07-27T15:04:25.0881858' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1791, 17, 108, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:25.0881858' AS DateTime2), CAST(N'2021-07-27T15:04:25.0881858' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1792, 17, 109, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.0881858' AS DateTime2), CAST(N'2021-07-27T15:04:25.0881858' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1793, 17, 110, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:25.4632064' AS DateTime2), CAST(N'2021-07-27T15:04:25.4632064' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1794, 17, 111, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.4632064' AS DateTime2), CAST(N'2021-07-27T15:04:25.4632064' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1795, 17, 112, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1796, 17, 113, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1797, 17, 114, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1798, 17, 115, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1799, 17, 116, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1800, 17, 117, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1801, 17, 118, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1802, 17, 119, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), CAST(N'2021-07-27T15:04:25.4789120' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1803, 17, 120, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.4945986' AS DateTime2), CAST(N'2021-07-27T15:04:25.4945986' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1804, 17, 121, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.4945986' AS DateTime2), CAST(N'2021-07-27T15:04:25.4945986' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1805, 17, 122, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.4945986' AS DateTime2), CAST(N'2021-07-27T15:04:25.4945986' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1806, 17, 123, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.4945986' AS DateTime2), CAST(N'2021-07-27T15:04:25.4945986' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1807, 17, 124, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.4945986' AS DateTime2), CAST(N'2021-07-27T15:04:25.4945986' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1808, 17, 125, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1809, 17, 126, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1810, 17, 127, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1811, 17, 128, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1812, 17, 129, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1813, 17, 130, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1814, 17, 131, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1815, 17, 132, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), CAST(N'2021-07-27T15:04:25.7912134' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1816, 17, 133, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1817, 17, 134, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1818, 17, 135, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1819, 17, 137, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1820, 17, 138, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1821, 17, 145, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1822, 17, 147, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), CAST(N'2021-07-27T15:04:25.8068796' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1823, 17, 148, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:26.0568280' AS DateTime2), CAST(N'2021-07-27T15:04:26.0568280' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1824, 17, 151, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:26.0725759' AS DateTime2), CAST(N'2021-07-27T15:04:26.0725759' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1825, 17, 152, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-07-27T15:04:26.0725759' AS DateTime2), CAST(N'2021-07-27T15:04:26.0725759' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1826, 17, 153, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:26.0725759' AS DateTime2), CAST(N'2021-07-27T15:04:26.0725759' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1827, 17, 154, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:26.0725759' AS DateTime2), CAST(N'2021-07-27T15:04:26.0725759' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1828, 17, 155, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:26.0725759' AS DateTime2), CAST(N'2021-07-27T15:04:26.0725759' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1829, 17, 156, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-07-27T15:04:26.0725759' AS DateTime2), CAST(N'2021-07-27T15:04:26.0725759' AS DateTime2), 2, 2, 1)
SET IDENTITY_INSERT [dbo].[groupObject] OFF
GO
SET IDENTITY_INSERT [dbo].[groups] ON 

INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (11, N'Admin', N'', CAST(N'2021-07-17T17:33:16.4708159' AS DateTime2), CAST(N'2021-07-27T15:04:50.1821379' AS DateTime2), 2, 2, 0)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (14, N'امين مستودع', N'', CAST(N'2021-07-18T10:10:16.5402142' AS DateTime2), CAST(N'2021-07-18T10:10:16.5402142' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (15, N'محاسب', N'', CAST(N'2021-07-18T10:21:33.6270353' AS DateTime2), CAST(N'2021-07-18T10:21:33.6270353' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (16, N'كاشيير', N'', CAST(N'2021-07-18T10:21:56.1427115' AS DateTime2), CAST(N'2021-07-18T10:21:56.1427115' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (17, N'Admin', N'', CAST(N'2021-07-27T15:04:22.0881072' AS DateTime2), CAST(N'2021-07-27T15:04:22.0881072' AS DateTime2), 2, 2, 1)
SET IDENTITY_INSERT [dbo].[groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventory] ON 

INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (1, N'in-000001', CAST(N'2021-07-12T14:46:39.8515114' AS DateTime2), CAST(N'2021-07-12T14:46:39.8515114' AS DateTime2), 2, 2, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (2, N'in-000001', CAST(N'2021-07-29T21:58:05.2557403' AS DateTime2), CAST(N'2021-07-29T21:58:05.2557403' AS DateTime2), 1, 1, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (3, N'in-000001', CAST(N'2021-07-31T15:24:09.9700461' AS DateTime2), CAST(N'2021-07-31T15:24:09.9700461' AS DateTime2), 1, 1, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (4, N'in-000001', CAST(N'2021-07-31T15:24:40.9395848' AS DateTime2), CAST(N'2021-07-31T15:24:40.9395848' AS DateTime2), 1, 1, NULL, NULL, N'a', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (5, N'in-000001', CAST(N'2021-07-31T15:25:43.4091005' AS DateTime2), CAST(N'2021-07-31T15:25:43.4091005' AS DateTime2), 1, 1, NULL, NULL, N'd', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (6, N'in-000001', CAST(N'2021-07-31T21:20:54.7715164' AS DateTime2), CAST(N'2021-07-31T21:20:54.7715164' AS DateTime2), 1, 1, NULL, NULL, N'd', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (7, N'in-000002', CAST(N'2021-08-01T11:45:34.3423449' AS DateTime2), CAST(N'2021-08-01T16:02:38.1518766' AS DateTime2), 2, 2, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (8, N'in-000001', CAST(N'2021-08-01T12:09:51.9463371' AS DateTime2), CAST(N'2021-08-01T12:09:51.9463371' AS DateTime2), 9, 9, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (9, N'in-000001', CAST(N'2021-08-01T12:09:52.0740936' AS DateTime2), CAST(N'2021-08-01T12:09:52.0740936' AS DateTime2), 9, 9, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (10, N'in-000001', CAST(N'2021-08-01T12:10:27.9774995' AS DateTime2), CAST(N'2021-08-01T12:10:27.9774995' AS DateTime2), 9, 9, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (11, N'in-000001', CAST(N'2021-08-01T12:21:26.4992361' AS DateTime2), CAST(N'2021-08-01T12:21:26.4992361' AS DateTime2), 9, 9, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (12, N'in-000004', CAST(N'2021-08-01T15:49:32.2700098' AS DateTime2), CAST(N'2021-08-01T15:49:32.2700098' AS DateTime2), 2, 2, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (13, N'in-000005', CAST(N'2021-08-01T15:58:29.6839363' AS DateTime2), CAST(N'2021-08-01T15:58:29.6839363' AS DateTime2), 2, 2, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (14, N'in-000006', CAST(N'2021-08-01T15:59:15.8487223' AS DateTime2), CAST(N'2021-08-01T15:59:15.8487223' AS DateTime2), 2, 2, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (15, N'in-000007', CAST(N'2021-08-01T16:35:10.8162993' AS DateTime2), CAST(N'2021-08-01T16:35:10.8162993' AS DateTime2), 2, 2, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (16, N'in-000008', CAST(N'2021-08-01T16:37:22.8427708' AS DateTime2), CAST(N'2021-08-01T16:37:22.8427708' AS DateTime2), 2, 2, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (17, N'in-000009', CAST(N'2021-08-02T12:35:37.0624064' AS DateTime2), CAST(N'2021-08-02T12:35:37.0624064' AS DateTime2), 2, 2, NULL, NULL, N'n', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (18, N'in-000010', CAST(N'2021-08-02T12:35:52.0787811' AS DateTime2), CAST(N'2021-08-02T12:35:52.0787811' AS DateTime2), 2, 2, NULL, NULL, N'n', 2, 2, NULL)
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
SET IDENTITY_INSERT [dbo].[inventoryItemLocation] ON 

INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (1, 1, 43, 3, 46, 8, 1, CAST(N'2021-07-12T14:46:40.2046368' AS DateTime2), CAST(N'2021-07-25T10:36:46.5841091' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (2, 0, 40, 3, 43, 9, 1, CAST(N'2021-07-12T14:46:40.2078261' AS DateTime2), CAST(N'2021-07-12T14:46:40.2078261' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (3, 0, 8, 0, 8, 8, 2, CAST(N'2021-07-29T21:58:05.6013739' AS DateTime2), CAST(N'2021-07-29T21:58:05.6013739' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (4, 0, 90, 0, 90, 41, 2, CAST(N'2021-07-29T21:58:05.6051476' AS DateTime2), CAST(N'2021-07-29T21:58:05.6051476' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (5, 0, 50, 1, 50, 42, 2, CAST(N'2021-07-29T21:58:05.6051476' AS DateTime2), CAST(N'2021-07-29T21:58:05.6051476' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (6, 0, 12, 0, 12, 43, 2, CAST(N'2021-07-29T21:58:05.6051476' AS DateTime2), CAST(N'2021-07-29T21:58:05.6051476' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (7, 0, 48, 0, 48, 44, 2, CAST(N'2021-07-29T21:58:05.6062317' AS DateTime2), CAST(N'2021-07-29T21:58:05.6062317' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (8, 0, 7, 0, 7, 8, 3, CAST(N'2021-07-31T15:24:10.3606938' AS DateTime2), CAST(N'2021-07-31T15:24:10.3606938' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (9, 1, 90, 2, 90, 41, 3, CAST(N'2021-07-31T15:24:10.3606938' AS DateTime2), CAST(N'2021-08-02T12:21:57.7342159' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (10, 0, 50, 0, 50, 42, 3, CAST(N'2021-07-31T15:24:10.3606938' AS DateTime2), CAST(N'2021-07-31T15:24:10.3606938' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (11, 0, 12, 0, 12, 43, 3, CAST(N'2021-07-31T15:24:10.3606938' AS DateTime2), CAST(N'2021-07-31T15:24:10.3606938' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (12, 1, 47, 5, 47, 44, 3, CAST(N'2021-07-31T15:24:10.3606938' AS DateTime2), CAST(N'2021-08-02T12:20:43.0546895' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (13, 0, 18, 0, 18, 49, 3, CAST(N'2021-07-31T15:24:10.3606938' AS DateTime2), CAST(N'2021-07-31T15:24:10.3606938' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (14, 0, 10, 0, 10, 50, 3, CAST(N'2021-07-31T15:24:10.3606938' AS DateTime2), CAST(N'2021-07-31T15:24:10.3606938' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (15, 0, 7, 0, 7, 8, 4, CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (16, 0, 90, 0, 90, 41, 4, CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (17, 0, 50, 0, 50, 42, 4, CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (18, 0, 12, 0, 12, 43, 4, CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (19, 0, 47, 0, 47, 44, 4, CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (20, 0, 16, 0, 18, 49, 4, CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (21, 0, 8, 0, 10, 50, 4, CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), CAST(N'2021-07-31T15:24:41.2520494' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (22, 0, 5, 0, 7, 8, 5, CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (23, 0, 48, 0, 90, 41, 5, CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (24, 0, 3, 0, 50, 42, 5, CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (25, 0, 10, 0, 12, 43, 5, CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (26, 0, 46, 0, 47, 44, 5, CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (27, 0, 15, 0, 18, 49, 5, CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (28, 0, 4, 0, 10, 50, 5, CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), CAST(N'2021-07-31T15:25:43.6900479' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (29, 0, 7, 0, 7, 8, 6, CAST(N'2021-07-31T21:20:55.1619367' AS DateTime2), CAST(N'2021-07-31T21:20:55.1619367' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (30, 0, 89, 0, 90, 41, 6, CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (31, 0, 50, 1, 50, 42, 6, CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (32, 0, 12, 0, 12, 43, 6, CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (33, 0, 0, 0, 47, 44, 6, CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (34, 0, 0, 0, 18, 49, 6, CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (35, 0, 0, 0, 10, 50, 6, CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (36, 0, 0, 0, 50, 51, 6, CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), CAST(N'2021-07-31T21:20:55.1776522' AS DateTime2), NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (37, 0, 6, 0, 7, 8, 7, CAST(N'2021-08-01T11:45:34.7428168' AS DateTime2), CAST(N'2021-08-01T16:02:38.4866460' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (38, 1, 88, 1, 90, 41, 7, CAST(N'2021-08-01T11:45:34.7476399' AS DateTime2), CAST(N'2021-08-02T12:19:07.6622631' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (39, 1, 25, 10, 50, 42, 7, CAST(N'2021-08-01T11:45:34.7486969' AS DateTime2), CAST(N'2021-08-02T12:25:16.1752781' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (40, 0, 14, 0, 12, 43, 7, CAST(N'2021-08-01T11:45:34.7486969' AS DateTime2), CAST(N'2021-08-01T16:02:38.4877137' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (41, 0, 47, 0, 47, 44, 7, CAST(N'2021-08-01T11:45:34.7486969' AS DateTime2), CAST(N'2021-08-01T16:02:38.4877137' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (42, 0, 18, 0, 18, 49, 7, CAST(N'2021-08-01T11:45:34.7486969' AS DateTime2), CAST(N'2021-08-01T16:02:38.4877137' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (43, 0, 9, 0, 10, 50, 7, CAST(N'2021-08-01T11:45:34.7486969' AS DateTime2), CAST(N'2021-08-01T16:02:38.4887612' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (44, 1, 49, 1, 50, 51, 7, CAST(N'2021-08-01T11:45:34.7497674' AS DateTime2), CAST(N'2021-08-02T12:16:00.1180218' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (45, 0, 7, 0, 7, 8, 8, CAST(N'2021-08-01T12:09:52.3416040' AS DateTime2), CAST(N'2021-08-01T12:09:52.3416040' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (46, 0, 60, 0, 90, 41, 8, CAST(N'2021-08-01T12:09:52.3466716' AS DateTime2), CAST(N'2021-08-01T12:09:52.3466716' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (47, 0, 25, 0, 50, 42, 8, CAST(N'2021-08-01T12:09:52.3466716' AS DateTime2), CAST(N'2021-08-01T12:09:52.3466716' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (48, 0, 6, 0, 12, 43, 8, CAST(N'2021-08-01T12:09:52.3466716' AS DateTime2), CAST(N'2021-08-01T12:09:52.3466716' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (49, 0, 47, 0, 47, 44, 8, CAST(N'2021-08-01T12:09:52.3466716' AS DateTime2), CAST(N'2021-08-01T12:09:52.3466716' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (50, 0, 15, 0, 18, 49, 8, CAST(N'2021-08-01T12:09:52.3466716' AS DateTime2), CAST(N'2021-08-01T12:09:52.3466716' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (51, 0, 10, 0, 10, 50, 8, CAST(N'2021-08-01T12:09:52.3477971' AS DateTime2), CAST(N'2021-08-01T12:09:52.3477971' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (52, 0, 40, 0, 50, 51, 8, CAST(N'2021-08-01T12:09:52.3477971' AS DateTime2), CAST(N'2021-08-01T12:09:52.3477971' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (53, 0, 7, 0, 7, 8, 9, CAST(N'2021-08-01T12:09:52.3749376' AS DateTime2), CAST(N'2021-08-01T12:09:52.3749376' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (54, 0, 60, 0, 90, 41, 9, CAST(N'2021-08-01T12:09:52.3749376' AS DateTime2), CAST(N'2021-08-01T12:09:52.3749376' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (55, 0, 25, 0, 50, 42, 9, CAST(N'2021-08-01T12:09:52.3749376' AS DateTime2), CAST(N'2021-08-01T12:09:52.3749376' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (56, 0, 6, 0, 12, 43, 9, CAST(N'2021-08-01T12:09:52.3760066' AS DateTime2), CAST(N'2021-08-01T12:09:52.3760066' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (57, 0, 47, 0, 47, 44, 9, CAST(N'2021-08-01T12:09:52.3760066' AS DateTime2), CAST(N'2021-08-01T12:09:52.3760066' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (58, 0, 15, 0, 18, 49, 9, CAST(N'2021-08-01T12:09:52.3760066' AS DateTime2), CAST(N'2021-08-01T12:09:52.3760066' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (59, 0, 10, 0, 10, 50, 9, CAST(N'2021-08-01T12:09:52.3765841' AS DateTime2), CAST(N'2021-08-01T12:09:52.3765841' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (60, 0, 40, 0, 50, 51, 9, CAST(N'2021-08-01T12:09:52.3765841' AS DateTime2), CAST(N'2021-08-01T12:09:52.3765841' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (61, 0, 7, 0, 7, 8, 10, CAST(N'2021-08-01T12:10:28.3407046' AS DateTime2), CAST(N'2021-08-01T12:10:28.3407046' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (62, 0, 0, 0, 90, 41, 10, CAST(N'2021-08-01T12:10:28.3417916' AS DateTime2), CAST(N'2021-08-01T12:10:28.3417916' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (63, 0, 0, 0, 50, 42, 10, CAST(N'2021-08-01T12:10:28.3417916' AS DateTime2), CAST(N'2021-08-01T12:10:28.3417916' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (64, 0, 0, 0, 12, 43, 10, CAST(N'2021-08-01T12:10:28.3417916' AS DateTime2), CAST(N'2021-08-01T12:10:28.3417916' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (65, 0, 0, 0, 47, 44, 10, CAST(N'2021-08-01T12:10:28.3417916' AS DateTime2), CAST(N'2021-08-01T12:10:28.3417916' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (66, 0, 0, 0, 18, 49, 10, CAST(N'2021-08-01T12:10:28.3417916' AS DateTime2), CAST(N'2021-08-01T12:10:28.3417916' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (67, 0, 0, 0, 10, 50, 10, CAST(N'2021-08-01T12:10:28.3428351' AS DateTime2), CAST(N'2021-08-01T12:10:28.3428351' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (68, 0, 0, 0, 50, 51, 10, CAST(N'2021-08-01T12:10:28.3428351' AS DateTime2), CAST(N'2021-08-01T12:10:28.3428351' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (69, 0, 0, 0, 7, 8, 10, CAST(N'2021-08-01T12:10:28.3428351' AS DateTime2), CAST(N'2021-08-01T12:10:28.3428351' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (70, 0, 0, 0, 90, 41, 10, CAST(N'2021-08-01T12:10:28.3428351' AS DateTime2), CAST(N'2021-08-01T12:10:28.3428351' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (71, 0, 0, 0, 50, 42, 10, CAST(N'2021-08-01T12:10:28.3438785' AS DateTime2), CAST(N'2021-08-01T12:10:28.3438785' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (72, 0, 0, 0, 12, 43, 10, CAST(N'2021-08-01T12:10:28.3438785' AS DateTime2), CAST(N'2021-08-01T12:10:28.3438785' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (73, 0, 0, 0, 47, 44, 10, CAST(N'2021-08-01T12:10:28.3444255' AS DateTime2), CAST(N'2021-08-01T12:10:28.3444255' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (74, 0, 0, 0, 18, 49, 10, CAST(N'2021-08-01T12:10:28.3444255' AS DateTime2), CAST(N'2021-08-01T12:10:28.3444255' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (75, 0, 0, 0, 10, 50, 10, CAST(N'2021-08-01T12:10:28.3444255' AS DateTime2), CAST(N'2021-08-01T12:10:28.3444255' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (76, 0, 0, 0, 50, 51, 10, CAST(N'2021-08-01T12:10:28.3454631' AS DateTime2), CAST(N'2021-08-01T12:10:28.3454631' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (77, 0, 7, 0, 7, 8, 11, CAST(N'2021-08-01T12:21:26.8157694' AS DateTime2), CAST(N'2021-08-01T12:21:26.8157694' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (78, 0, 90, 0, 90, 41, 11, CAST(N'2021-08-01T12:21:26.8168200' AS DateTime2), CAST(N'2021-08-01T12:21:26.8168200' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (79, 0, 25, 0, 50, 42, 11, CAST(N'2021-08-01T12:21:26.8168200' AS DateTime2), CAST(N'2021-08-01T12:21:26.8168200' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (80, 0, 12, 0, 12, 43, 11, CAST(N'2021-08-01T12:21:26.8168200' AS DateTime2), CAST(N'2021-08-01T12:21:26.8168200' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (81, 0, 47, 0, 47, 44, 11, CAST(N'2021-08-01T12:21:26.8168200' AS DateTime2), CAST(N'2021-08-01T12:21:26.8168200' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (82, 0, 18, 0, 18, 49, 11, CAST(N'2021-08-01T12:21:26.8168200' AS DateTime2), CAST(N'2021-08-01T12:21:26.8168200' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (83, 0, 10, 0, 10, 50, 11, CAST(N'2021-08-01T12:21:26.8168200' AS DateTime2), CAST(N'2021-08-01T12:21:26.8168200' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (84, 0, 40, 0, 50, 51, 11, CAST(N'2021-08-01T12:21:26.8179065' AS DateTime2), CAST(N'2021-08-01T12:21:26.8179065' AS DateTime2), NULL, 9, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (85, 0, 45, 0, 90, 41, 12, CAST(N'2021-08-01T15:49:32.5583483' AS DateTime2), CAST(N'2021-08-01T15:49:32.5583483' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (86, 0, 25, 0, 50, 42, 12, CAST(N'2021-08-01T15:49:32.5589314' AS DateTime2), CAST(N'2021-08-01T15:49:32.5589314' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (87, 0, 6, 0, 12, 43, 12, CAST(N'2021-08-01T15:49:32.5589314' AS DateTime2), CAST(N'2021-08-01T15:49:32.5589314' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (88, 0, 23, 0, 47, 44, 12, CAST(N'2021-08-01T15:49:32.5589314' AS DateTime2), CAST(N'2021-08-01T15:49:32.5589314' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (89, 0, 9, 0, 18, 49, 12, CAST(N'2021-08-01T15:49:32.5599638' AS DateTime2), CAST(N'2021-08-01T15:49:32.5599638' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (90, 0, 5, 0, 10, 50, 12, CAST(N'2021-08-01T15:49:32.5599638' AS DateTime2), CAST(N'2021-08-01T15:49:32.5599638' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (91, 0, 25, 0, 50, 51, 12, CAST(N'2021-08-01T15:49:32.5599638' AS DateTime2), CAST(N'2021-08-01T15:49:32.5599638' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (92, 0, 44, 0, 87, 52, 12, CAST(N'2021-08-01T15:49:32.5599638' AS DateTime2), CAST(N'2021-08-01T15:49:32.5599638' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (93, 0, 4, 0, 8, 8, 13, CAST(N'2021-08-01T15:58:30.1061692' AS DateTime2), CAST(N'2021-08-01T15:58:30.1061692' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (94, 0, 45, 0, 90, 41, 13, CAST(N'2021-08-01T15:58:30.1098839' AS DateTime2), CAST(N'2021-08-01T15:58:30.1098839' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (95, 0, 25, 0, 50, 42, 13, CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (96, 0, 6, 0, 12, 43, 13, CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (97, 0, 24, 0, 48, 44, 13, CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (98, 0, 9, 0, 18, 49, 13, CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (99, 0, 5, 0, 10, 50, 13, CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), NULL, 2, NULL, NULL, NULL)
GO
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (100, 0, 25, 0, 50, 51, 13, CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (101, 0, 44, 0, 88, 52, 13, CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), CAST(N'2021-08-01T15:58:30.1109243' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (102, 0, 3, 0, 8, 8, 14, CAST(N'2021-08-01T15:59:16.1320611' AS DateTime2), CAST(N'2021-08-01T15:59:16.1320611' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (103, 0, 45, 0, 90, 41, 14, CAST(N'2021-08-01T15:59:16.1320611' AS DateTime2), CAST(N'2021-08-01T15:59:16.1320611' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (104, 0, 25, 0, 50, 42, 14, CAST(N'2021-08-01T15:59:16.1320611' AS DateTime2), CAST(N'2021-08-01T15:59:16.1320611' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (105, 0, 12, 0, 12, 43, 14, CAST(N'2021-08-01T15:59:16.1331404' AS DateTime2), CAST(N'2021-08-01T15:59:16.1331404' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (106, 0, 24, 0, 48, 44, 14, CAST(N'2021-08-01T15:59:16.1331404' AS DateTime2), CAST(N'2021-08-01T15:59:16.1331404' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (107, 0, 9, 0, 18, 49, 14, CAST(N'2021-08-01T15:59:16.1331404' AS DateTime2), CAST(N'2021-08-01T15:59:16.1331404' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (108, 0, 5, 0, 10, 50, 14, CAST(N'2021-08-01T15:59:16.1342215' AS DateTime2), CAST(N'2021-08-01T15:59:16.1342215' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (109, 0, 25, 0, 50, 51, 14, CAST(N'2021-08-01T15:59:16.1342215' AS DateTime2), CAST(N'2021-08-01T15:59:16.1342215' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (110, 0, 45, 0, 88, 52, 14, CAST(N'2021-08-01T15:59:16.1348058' AS DateTime2), CAST(N'2021-08-01T15:59:16.1348058' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (111, 0, 5, 0, 8, 8, 15, CAST(N'2021-08-01T16:35:11.2109827' AS DateTime2), CAST(N'2021-08-01T16:35:11.2109827' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (112, 0, 45, 0, 90, 41, 15, CAST(N'2021-08-01T16:35:11.2169364' AS DateTime2), CAST(N'2021-08-01T16:35:11.2169364' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (113, 0, 25, 0, 50, 42, 15, CAST(N'2021-08-01T16:35:11.2169364' AS DateTime2), CAST(N'2021-08-01T16:35:11.2169364' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (114, 0, 6, 0, 12, 43, 15, CAST(N'2021-08-01T16:35:11.2175098' AS DateTime2), CAST(N'2021-08-01T16:35:11.2175098' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (115, 0, 24, 0, 48, 44, 15, CAST(N'2021-08-01T16:35:11.2175098' AS DateTime2), CAST(N'2021-08-01T16:35:11.2175098' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (116, 0, 9, 0, 18, 49, 15, CAST(N'2021-08-01T16:35:11.2175098' AS DateTime2), CAST(N'2021-08-01T16:35:11.2175098' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (117, 0, 5, 0, 10, 50, 15, CAST(N'2021-08-01T16:35:11.2175098' AS DateTime2), CAST(N'2021-08-01T16:35:11.2175098' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (118, 0, 25, 0, 50, 51, 15, CAST(N'2021-08-01T16:35:11.2185594' AS DateTime2), CAST(N'2021-08-01T16:35:11.2185594' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (119, 0, 45, 0, 88, 52, 15, CAST(N'2021-08-01T16:35:11.2185594' AS DateTime2), CAST(N'2021-08-01T16:35:11.2185594' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (120, 0, 3, 0, 8, 8, 16, CAST(N'2021-08-01T16:37:23.1172969' AS DateTime2), CAST(N'2021-08-01T16:37:23.1172969' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (121, 0, 45, 0, 90, 41, 16, CAST(N'2021-08-01T16:37:23.1172969' AS DateTime2), CAST(N'2021-08-01T16:37:23.1172969' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (122, 0, 25, 0, 50, 42, 16, CAST(N'2021-08-01T16:37:23.1172969' AS DateTime2), CAST(N'2021-08-01T16:37:23.1172969' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (123, 0, 6, 0, 12, 43, 16, CAST(N'2021-08-01T16:37:23.1183583' AS DateTime2), CAST(N'2021-08-01T16:37:23.1183583' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (124, 0, 24, 0, 48, 44, 16, CAST(N'2021-08-01T16:37:23.1183583' AS DateTime2), CAST(N'2021-08-01T16:37:23.1183583' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (125, 0, 9, 0, 18, 49, 16, CAST(N'2021-08-01T16:37:23.1183583' AS DateTime2), CAST(N'2021-08-01T16:37:23.1183583' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (126, 0, 5, 0, 10, 50, 16, CAST(N'2021-08-01T16:37:23.1189482' AS DateTime2), CAST(N'2021-08-01T16:37:23.1189482' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (127, 0, 25, 0, 50, 51, 16, CAST(N'2021-08-01T16:37:23.1189482' AS DateTime2), CAST(N'2021-08-01T16:37:23.1189482' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (128, 0, 45, 0, 88, 52, 16, CAST(N'2021-08-01T16:37:23.1189482' AS DateTime2), CAST(N'2021-08-01T16:37:23.1189482' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (129, 0, 0, 0, 7, 8, 17, CAST(N'2021-08-02T12:35:37.4917696' AS DateTime2), CAST(N'2021-08-02T12:35:37.4917696' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (130, 0, 0, 0, 87, 41, 17, CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (131, 0, 0, 0, 40, 42, 17, CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (132, 0, 0, 0, 12, 43, 17, CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (133, 0, 0, 0, 43, 44, 17, CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (134, 0, 0, 0, 18, 49, 17, CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (135, 0, 0, 0, 10, 50, 17, CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (136, 0, 0, 0, 49, 51, 17, CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (137, 0, 0, 0, 88, 52, 17, CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), CAST(N'2021-08-02T12:35:37.4928611' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (138, 1, 5, 2, 7, 8, 18, CAST(N'2021-08-02T12:35:52.4315737' AS DateTime2), CAST(N'2021-08-02T12:36:40.1877558' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (139, 0, 0, 0, 87, 41, 18, CAST(N'2021-08-02T12:35:52.4315737' AS DateTime2), CAST(N'2021-08-02T12:35:52.4315737' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (140, 0, 0, 0, 40, 42, 18, CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (141, 0, 0, 0, 12, 43, 18, CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (142, 0, 0, 0, 43, 44, 18, CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (143, 0, 0, 0, 18, 49, 18, CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (144, 0, 0, 0, 10, 50, 18, CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (145, 0, 0, 0, 49, 51, 18, CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (146, 0, 0, 0, 88, 52, 18, CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), CAST(N'2021-08-02T12:35:52.4326328' AS DateTime2), NULL, 2, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[inventoryItemLocation] OFF
GO
SET IDENTITY_INSERT [dbo].[invoices] ON 

INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (147, NULL, NULL, 1, N'pd', N'-1', NULL, CAST(8000.00 AS Decimal(20, 2)), CAST(8000.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-07-29T17:12:11.1914708' AS DateTime2), CAST(N'2021-07-29T17:12:11.1914708' AS DateTime2), 1, NULL, NULL, CAST(N'17:12:11.1914708' AS Time), N'', N'', NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (148, N'pi-000006', 6, 1, N'pw', N'-1', NULL, CAST(2000.00 AS Decimal(20, 2)), CAST(2000.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-31' AS Date), CAST(N'2021-07-29T17:17:44.3273190' AS DateTime2), CAST(N'2021-07-29T17:17:44.3273190' AS DateTime2), 1, NULL, NULL, CAST(N'17:17:44.3273190' AS Time), N'', N'1', NULL, 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (149, NULL, NULL, 1, N'pd', N'-1', NULL, CAST(1000.00 AS Decimal(20, 2)), CAST(1000.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-07-29T17:24:01.6533737' AS DateTime2), CAST(N'2021-07-29T17:24:01.6533737' AS DateTime2), 1, NULL, NULL, CAST(N'17:24:01.6533737' AS Time), N'', N'', NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (150, N'pi-000012', 5, 1, N'p', N'1', CAST(1000.0000 AS Decimal(20, 4)), CAST(55050.00 AS Decimal(20, 2)), CAST(54050.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-10-25' AS Date), CAST(N'2021-07-29T18:14:37.4102402' AS DateTime2), CAST(N'2021-07-31T15:19:22.6072348' AS DateTime2), 1, NULL, NULL, CAST(N'18:14:37.4102402' AS Time), N'', N'', CAST(N'2021-07-30T00:00:00.0000000' AS DateTime2), 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (151, N'si-000001', 10, 9, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-29T18:22:39.0400369' AS DateTime2), CAST(N'2021-07-29T18:22:39.0400369' AS DateTime2), 9, NULL, NULL, CAST(N'18:22:39.0400369' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, 3, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (152, N'1', NULL, 1, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1615.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1615.00 AS Decimal(20, 2)), CAST(N'2021-08-31' AS Date), CAST(N'2021-07-29T20:28:05.9440694' AS DateTime2), CAST(N'2021-07-29T20:31:11.9522670' AS DateTime2), 1, NULL, NULL, CAST(N'20:28:05.9440694' AS Time), N'nnnnbb', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, 1, 2, 3, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (153, N'pi-000007', 1, 1, N'p', N'1', CAST(20.0000 AS Decimal(20, 4)), CAST(500.00 AS Decimal(20, 2)), CAST(480.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-08-31' AS Date), CAST(N'2021-07-29T20:28:33.6105120' AS DateTime2), CAST(N'2021-07-29T20:33:25.6005944' AS DateTime2), 1, NULL, NULL, CAST(N'20:28:33.6105120' AS Time), N'sddddd', N'266558', CAST(N'2021-07-20T00:00:00.0000000' AS DateTime2), 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (154, N'pb-000001', 1, 1, N'pb', N'1', CAST(20.0000 AS Decimal(20, 4)), CAST(500.00 AS Decimal(20, 2)), CAST(500.00 AS Decimal(20, 2)), CAST(500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-08-31' AS Date), CAST(N'2021-07-29T20:34:00.1527069' AS DateTime2), CAST(N'2021-07-29T20:34:34.9244285' AS DateTime2), 1, 153, NULL, CAST(N'20:34:00.1527069' AS Time), N'sddddd', N'266558', CAST(N'2021-07-20T00:00:00.0000000' AS DateTime2), 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (156, N'im-000001', NULL, 1, N'im', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-29T21:49:59.7465719' AS DateTime2), CAST(N'2021-07-29T21:49:59.7465719' AS DateTime2), 1, NULL, NULL, CAST(N'21:49:59.7465719' AS Time), NULL, NULL, NULL, 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (157, N'ex-000001', NULL, 1, N'exw', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-29T21:50:00.2321034' AS DateTime2), CAST(N'2021-07-29T21:50:00.2321034' AS DateTime2), 1, 156, NULL, CAST(N'21:50:00.2321034' AS Time), NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (158, N'ex-000002', NULL, 1, N'ex', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-29T21:54:16.3429385' AS DateTime2), CAST(N'2021-07-29T21:54:16.3429385' AS DateTime2), 1, NULL, NULL, CAST(N'21:54:16.3429385' AS Time), NULL, NULL, NULL, 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (159, N'im-000002', NULL, 1, N'im', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-29T21:54:16.7400699' AS DateTime2), CAST(N'2021-07-29T21:54:16.7400699' AS DateTime2), 1, 158, NULL, CAST(N'21:54:16.7400699' AS Time), NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (160, N'pi-000008', 2, 1, N'pw', N'1', CAST(100.0000 AS Decimal(20, 4)), CAST(10500.00 AS Decimal(20, 2)), CAST(10920.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-08-31' AS Date), CAST(N'2021-07-29T22:10:33.0635127' AS DateTime2), CAST(N'2021-07-29T22:10:33.0635127' AS DateTime2), 1, NULL, NULL, CAST(N'22:10:33.0635127' AS Time), N'', N'5554566', CAST(N'2021-07-29T00:00:00.0000000' AS DateTime2), 3, 2, CAST(5.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (161, N'pb-000002', 1, 1, N'pb', N'1', CAST(20.0000 AS Decimal(20, 4)), CAST(500.00 AS Decimal(20, 2)), CAST(500.00 AS Decimal(20, 2)), CAST(500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-08-31' AS Date), CAST(N'2021-07-29T22:16:50.7271671' AS DateTime2), CAST(N'2021-07-29T22:17:17.2326223' AS DateTime2), 1, 153, NULL, CAST(N'22:16:50.7271671' AS Time), N'sddddd', N'266558', CAST(N'2021-07-20T00:00:00.0000000' AS DateTime2), 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (163, N'ds-000001', NULL, 1, N'd', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-29T22:20:29.0273575' AS DateTime2), CAST(N'2021-07-29T22:20:29.0273575' AS DateTime2), 1, NULL, NULL, CAST(N'22:20:29.0273575' AS Time), N'', NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (164, N'pi-000009', 3, 1, N'pw', N'1', NULL, CAST(40.00 AS Decimal(20, 2)), CAST(40.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-11-01' AS Date), CAST(N'2021-07-29T22:56:18.3056791' AS DateTime2), CAST(N'2021-07-29T22:56:18.3056791' AS DateTime2), 1, NULL, NULL, CAST(N'22:56:18.3056791' AS Time), N'', N'2554555', CAST(N'2021-07-29T00:00:00.0000000' AS DateTime2), 4, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (165, N'pi-000010', 2, 2, N'p', N'-1', NULL, CAST(14973.00 AS Decimal(20, 2)), CAST(15721.65 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-31' AS Date), CAST(N'2021-07-30T00:33:01.6326937' AS DateTime2), CAST(N'2021-07-30T00:33:38.9275095' AS DateTime2), 2, NULL, NULL, CAST(N'00:33:01.6326937' AS Time), N'', N'000', NULL, 2, 2, CAST(5.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (166, N'si-000002', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(6000500.00 AS Decimal(20, 2)), CAST(6300525.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(6300525.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-30T00:35:53.6488372' AS DateTime2), CAST(N'2021-07-30T00:35:53.6488372' AS DateTime2), 2, NULL, NULL, CAST(N'00:35:53.6488372' AS Time), N'', NULL, NULL, NULL, 2, CAST(5.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (167, N'pi-000011', 4, 1, N'p', N'-1', NULL, CAST(100000.00 AS Decimal(20, 2)), CAST(100000.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-31' AS Date), CAST(N'2021-07-30T14:26:16.3485662' AS DateTime2), CAST(N'2021-07-31T15:19:46.7642540' AS DateTime2), 1, NULL, NULL, CAST(N'14:26:16.3485662' AS Time), N'', N'14', NULL, 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (168, N'pi-000013', 2, 1, N'p', N'-1', NULL, CAST(1050.00 AS Decimal(20, 2)), CAST(1102.50 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-11-30' AS Date), CAST(N'2021-07-30T15:07:33.2541987' AS DateTime2), CAST(N'2021-07-30T15:08:15.2091390' AS DateTime2), 1, NULL, NULL, CAST(N'15:07:33.2541987' AS Time), N'', N'6655444', CAST(N'2021-07-30T00:00:00.0000000' AS DateTime2), 2, 2, CAST(5.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (169, N'pi-000014', 1, 1, N'p', N'-1', NULL, CAST(550.00 AS Decimal(20, 2)), CAST(550.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-10-31' AS Date), CAST(N'2021-07-31T15:18:55.0917222' AS DateTime2), CAST(N'2021-07-31T15:19:30.4515298' AS DateTime2), 1, NULL, NULL, CAST(N'15:18:55.0917222' AS Time), N'5555', N'522332', CAST(N'2021-07-31T00:00:00.0000000' AS DateTime2), 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (170, N'pi-000015', 4, 1, N'p', N'-1', NULL, CAST(100.00 AS Decimal(20, 2)), CAST(105.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-09-30' AS Date), CAST(N'2021-07-31T21:04:59.5569329' AS DateTime2), CAST(N'2021-07-31T21:05:44.7292591' AS DateTime2), 1, NULL, NULL, CAST(N'21:04:59.5569329' AS Time), N'', N'66558', CAST(N'2021-07-31T00:00:00.0000000' AS DateTime2), 2, 2, CAST(5.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (171, N'si-000003', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1000.00 AS Decimal(20, 2)), CAST(1050.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1050.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-01T12:14:10.7351001' AS DateTime2), CAST(N'2021-08-01T12:14:10.7351001' AS DateTime2), 2, NULL, NULL, CAST(N'12:14:10.7351001' AS Time), N'', NULL, NULL, NULL, 2, CAST(5.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (172, N'si-000004', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1000.00 AS Decimal(20, 2)), CAST(1050.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1050.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-01T12:15:20.8035964' AS DateTime2), CAST(N'2021-08-01T12:15:20.8035964' AS DateTime2), 2, NULL, NULL, CAST(N'12:15:20.8035964' AS Time), N'', NULL, NULL, NULL, 2, CAST(5.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (173, N'or-000001', 12, 2, N'or', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(2500.00 AS Decimal(20, 2)), CAST(2625.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-08-01T13:13:16.3979439' AS DateTime2), CAST(N'2021-08-01T13:13:16.3979439' AS DateTime2), 2, NULL, NULL, CAST(N'13:13:16.3979439' AS Time), N'', NULL, NULL, NULL, 2, CAST(5.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (174, N'or-000002', 11, 2, N'or', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(21500.00 AS Decimal(20, 2)), CAST(37575.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-08-01T13:14:02.4170225' AS DateTime2), CAST(N'2021-08-01T13:14:02.4170225' AS DateTime2), 2, NULL, NULL, CAST(N'13:14:02.4170225' AS Time), N'', NULL, NULL, NULL, 2, CAST(5.00 AS Decimal(20, 2)), NULL, NULL, NULL, 4, 2, 6, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (175, N'or-000003', 11, 2, N'or', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(1200000.00 AS Decimal(20, 2)), CAST(1260115.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-08-01T13:15:16.1346167' AS DateTime2), CAST(N'2021-08-01T13:15:16.1346167' AS DateTime2), 2, NULL, NULL, CAST(N'13:15:16.1346167' AS Time), N'', NULL, NULL, 2, 2, CAST(5.00 AS Decimal(20, 2)), NULL, NULL, NULL, 1, 2, 11, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (176, N'or-000004', 11, 2, N'or', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(625.00 AS Decimal(20, 2)), CAST(15656.25 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-08-17' AS Date), CAST(N'2021-08-01T13:17:32.3669449' AS DateTime2), CAST(N'2021-08-01T13:17:32.3669449' AS DateTime2), 2, NULL, NULL, CAST(N'13:17:32.3669449' AS Time), N'', NULL, NULL, 2, 2, CAST(5.00 AS Decimal(20, 2)), NULL, NULL, NULL, 4, 2, 13, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (177, N'or-000005', 12, 3, N'or', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(12000000.00 AS Decimal(20, 2)), CAST(12600115.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-08-01T13:39:33.1231413' AS DateTime2), CAST(N'2021-08-01T13:39:33.1231413' AS DateTime2), 3, NULL, NULL, CAST(N'13:39:33.1231413' AS Time), N'', NULL, NULL, 2, 2, CAST(5.00 AS Decimal(20, 2)), NULL, NULL, NULL, 2, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (178, N'si-000005', 9, 1, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(11000.00 AS Decimal(20, 2)), CAST(11670.75 AS Decimal(20, 2)), CAST(11670.75 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-08-31' AS Date), CAST(N'2021-08-02T00:32:09.7788724' AS DateTime2), CAST(N'2021-08-02T00:32:12.5248116' AS DateTime2), 1, NULL, NULL, CAST(N'00:32:09.7788724' AS Time), N'', NULL, NULL, NULL, 2, CAST(5.00 AS Decimal(20, 2)), NULL, NULL, NULL, 1, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (179, N'po-000001', 4, 3, N'po', NULL, NULL, CAST(4.00 AS Decimal(20, 2)), CAST(4.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-08-02T10:28:27.5047763' AS DateTime2), CAST(N'2021-08-02T10:28:27.5047763' AS DateTime2), 3, NULL, NULL, CAST(N'10:28:27.5047763' AS Time), N'', NULL, NULL, NULL, 2, NULL, 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (180, N'po-000002', 3, 3, N'po', NULL, NULL, CAST(6.00 AS Decimal(20, 2)), CAST(6.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-08-02T10:32:12.7721143' AS DateTime2), CAST(N'2021-08-02T10:32:12.7721143' AS DateTime2), 3, NULL, NULL, CAST(N'10:32:12.7721143' AS Time), N'', NULL, NULL, NULL, 2, NULL, 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (181, N'or-000006', 1, 3, N'or', NULL, NULL, CAST(10000.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), NULL, CAST(10000.00 AS Decimal(20, 2)), CAST(N'2021-08-31' AS Date), CAST(N'2021-08-02T10:32:12.7721143' AS DateTime2), CAST(N'2021-08-02T10:32:12.7721143' AS DateTime2), 3, NULL, NULL, CAST(N'10:32:12.7721143' AS Time), NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, 2, 10, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (182, N'ds-000002', NULL, 2, N'd', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-02T12:15:59.4522507' AS DateTime2), CAST(N'2021-08-02T12:15:59.4522507' AS DateTime2), 2, NULL, NULL, CAST(N'12:15:59.4522507' AS Time), N'', NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (183, N'ds-000003', NULL, 2, N'd', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-02T12:18:21.7213699' AS DateTime2), CAST(N'2021-08-02T12:18:21.7213699' AS DateTime2), 2, NULL, NULL, CAST(N'12:18:21.7213699' AS Time), N'ddd', NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (184, N'ds-000004', NULL, 2, N'd', NULL, NULL, CAST(25.00 AS Decimal(20, 2)), CAST(25.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(25.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-02T12:19:07.1424905' AS DateTime2), CAST(N'2021-08-02T12:19:07.1424905' AS DateTime2), 2, NULL, NULL, CAST(N'12:19:07.1424905' AS Time), N'nnnnn', NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (185, N'ds-000005', NULL, 2, N'd', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-02T12:20:39.5081672' AS DateTime2), CAST(N'2021-08-02T12:20:39.5081672' AS DateTime2), 2, NULL, NULL, CAST(N'12:20:39.5081672' AS Time), N'nnnnnnnnnnnnrn', NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (186, N'ds-000006', NULL, 2, N'd', NULL, NULL, CAST(50.00 AS Decimal(20, 2)), CAST(50.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(50.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-02T12:21:57.2655395' AS DateTime2), CAST(N'2021-08-02T12:21:57.2655395' AS DateTime2), 2, NULL, NULL, CAST(N'12:21:57.2655395' AS Time), N'nnnnnnn', NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (187, N'ds-000007', NULL, 2, N'd', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-02T12:25:15.6446927' AS DateTime2), CAST(N'2021-08-02T12:25:15.6446927' AS DateTime2), 2, NULL, NULL, CAST(N'12:25:15.6446927' AS Time), N'', NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (188, N'ds-000008', NULL, 2, N'd', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-02T12:36:39.6885891' AS DateTime2), CAST(N'2021-08-02T12:36:39.6885891' AS DateTime2), 2, NULL, NULL, CAST(N'12:36:39.6885891' AS Time), N'nnnnnnnnnnnn', NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (189, N'pi-000016', 1, 3, N'pw', N'-1', NULL, CAST(1222.00 AS Decimal(20, 2)), CAST(1222.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-08-24' AS Date), CAST(N'2021-08-03T13:14:18.1373149' AS DateTime2), CAST(N'2021-08-03T13:14:18.1373149' AS DateTime2), 3, NULL, NULL, CAST(N'13:14:18.1373149' AS Time), N'', N'ثصث3', CAST(N'2021-08-03T00:00:00.0000000' AS DateTime2), 3, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (190, N'po-000003', 7, 9, N'po', NULL, NULL, CAST(1.00 AS Decimal(20, 2)), CAST(1.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-08-03T19:12:54.5232288' AS DateTime2), CAST(N'2021-08-03T19:12:54.5242922' AS DateTime2), 9, NULL, NULL, CAST(N'19:12:54.5242922' AS Time), N'', NULL, NULL, NULL, 2, NULL, 2, NULL, NULL, NULL, 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[invoiceStatus] ON 

INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (89, 151, N'pr', CAST(N'2021-07-29T18:22:40.9225464' AS DateTime2), CAST(N'2021-07-29T18:22:40.9225464' AS DateTime2), 9, 9, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (90, 151, N'ex', CAST(N'2021-07-29T18:22:41.1648915' AS DateTime2), CAST(N'2021-07-29T18:22:41.1648915' AS DateTime2), 9, 9, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (91, 151, N'tr', CAST(N'2021-07-29T18:22:41.4159734' AS DateTime2), CAST(N'2021-07-29T18:22:41.4159734' AS DateTime2), 9, 9, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (92, 152, N'pr', CAST(N'2021-07-29T20:31:13.5869467' AS DateTime2), CAST(N'2021-07-29T20:31:13.5869467' AS DateTime2), 1, 1, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (93, 152, N'ex', CAST(N'2021-07-29T20:31:13.7998852' AS DateTime2), CAST(N'2021-07-29T20:31:13.7998852' AS DateTime2), 1, 1, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (94, 166, N'pr', CAST(N'2021-07-30T00:35:58.6718766' AS DateTime2), CAST(N'2021-07-30T00:35:58.6718766' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (95, 166, N'ex', CAST(N'2021-07-30T00:36:00.8770676' AS DateTime2), CAST(N'2021-07-30T00:36:00.8770676' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (96, 166, N'rc', CAST(N'2021-07-30T00:36:01.9021893' AS DateTime2), CAST(N'2021-07-30T00:36:01.9021893' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (97, 171, N'pr', CAST(N'2021-08-01T12:14:13.4352298' AS DateTime2), CAST(N'2021-08-01T12:14:13.4352298' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (98, 171, N'ex', CAST(N'2021-08-01T12:14:13.6756902' AS DateTime2), CAST(N'2021-08-01T12:14:13.6756902' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (99, 171, N'rc', CAST(N'2021-08-01T12:14:13.8973325' AS DateTime2), CAST(N'2021-08-01T12:14:13.8973325' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (100, 172, N'pr', CAST(N'2021-08-01T12:15:22.7234038' AS DateTime2), CAST(N'2021-08-01T12:15:22.7234038' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (101, 172, N'ex', CAST(N'2021-08-01T12:15:23.0185211' AS DateTime2), CAST(N'2021-08-01T12:15:23.0185211' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (102, 172, N'rc', CAST(N'2021-08-01T12:15:23.3006264' AS DateTime2), CAST(N'2021-08-01T12:15:23.3006264' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (103, 173, N'pr', CAST(N'2021-08-01T13:13:17.3948334' AS DateTime2), CAST(N'2021-08-01T13:13:17.3948334' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (104, 174, N'pr', CAST(N'2021-08-01T13:14:03.4189640' AS DateTime2), CAST(N'2021-08-01T13:14:03.4189640' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (105, 175, N'pr', CAST(N'2021-08-01T13:15:17.1639596' AS DateTime2), CAST(N'2021-08-01T13:15:17.1639596' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (106, 175, N'ex', CAST(N'2021-08-01T13:16:50.3087592' AS DateTime2), CAST(N'2021-08-01T13:16:50.3087592' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (107, 176, N'pr', CAST(N'2021-08-01T13:17:33.2828513' AS DateTime2), CAST(N'2021-08-01T13:17:33.2828513' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (108, 176, N'ex', CAST(N'2021-08-01T13:17:43.9989269' AS DateTime2), CAST(N'2021-08-01T13:17:43.9989269' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (109, 177, N'pr', CAST(N'2021-08-01T13:39:34.0595200' AS DateTime2), CAST(N'2021-08-01T13:39:34.0595200' AS DateTime2), 3, 3, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (110, 177, N'ex', CAST(N'2021-08-01T13:40:14.6463189' AS DateTime2), CAST(N'2021-08-01T13:40:14.6463189' AS DateTime2), 3, 3, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (111, 177, N'ex', CAST(N'2021-08-01T13:40:52.6271015' AS DateTime2), CAST(N'2021-08-01T13:40:52.6271015' AS DateTime2), 3, 3, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (112, 176, N'ex', CAST(N'2021-08-01T13:41:02.0822513' AS DateTime2), CAST(N'2021-08-01T13:41:02.0822513' AS DateTime2), 3, 3, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (113, 175, N'ex', CAST(N'2021-08-01T13:41:10.9063850' AS DateTime2), CAST(N'2021-08-01T13:41:10.9063850' AS DateTime2), 3, 3, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (114, 177, N'ex', CAST(N'2021-08-01T15:06:11.1434445' AS DateTime2), CAST(N'2021-08-01T15:06:11.1434445' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (115, 177, N'ex', CAST(N'2021-08-01T15:06:58.1764335' AS DateTime2), CAST(N'2021-08-01T15:06:58.1764335' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (116, 178, N'pr', CAST(N'2021-08-02T00:32:14.2638695' AS DateTime2), CAST(N'2021-08-02T00:32:14.2638695' AS DateTime2), 1, 1, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (117, 178, N'ex', CAST(N'2021-08-02T00:32:14.9210286' AS DateTime2), CAST(N'2021-08-02T00:32:14.9210286' AS DateTime2), 1, 1, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (118, 181, N'rc', CAST(N'2021-08-02T00:32:14.9210286' AS DateTime2), CAST(N'2021-08-02T00:32:14.9210286' AS DateTime2), 3, 3, NULL, 1)
SET IDENTITY_INSERT [dbo].[invoiceStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[items] ON 

INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (1, N'BS', N'barcode scanner', N'barcode scanner', N'n', N'57440ff6b80f068efd50410ea24fd593.png', CAST(5.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:08:07.3467846' AS DateTime2), CAST(N'2021-07-04T13:56:50.3030559' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (2, N'BP', N'barcode printer', N'barcode printer', N'n', N'c37858823db0093766eee74d8ee1f1e5.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-04T13:56:50.3100404' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (3, N'CDR', N'Cash Drawer', N'Cash Drawer', N'n', N'71f020248a405d21e94d1de52043bed4.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:10:03.0032564' AS DateTime2), CAST(N'2021-07-04T13:56:50.3130305' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (4, N'PP2', N'POZONE-POS2', N'POZONE-POS2', N'n', N'd2ec5f1ed83abfca0dfec76506b696b3.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-04T13:56:50.3180187' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (5, N't820', N'POZONE-t820-POS', N'POZONE-t820-POS', N'n', N'f96f8a89e2143f1e43a2ba7953fb5413.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:10:57.6681411' AS DateTime2), CAST(N'2021-07-04T13:56:50.3259931' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (6, N't835', N'POZONE-t835-POS', N'  POZONE-t835-POS POZONE-t835-POS POZONE-t835-POS POZONE-t835-POS', N'n', N'56a2e0231c3d394ace201adf37d13f63.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-08-03T14:23:03.0523210' AS DateTime2), 1, 2, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (7, N'TR', N'Thermal-rolls', N'Thermal-rolls', N'n', N'3204215c19f25609034d24451f7e03d7.png', CAST(5.00 AS Decimal(20, 2)), 1, 24, 5, 1, NULL, CAST(N'2021-07-01T14:12:09.8270752' AS DateTime2), CAST(N'2021-07-04T13:56:50.3349718' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (8, N'LCP', N'laundry casheir', N'laundry-casheir-program', N'sr', N'6a5d62c1233b5e9b2000dd13aadf81f4.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 3, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-24T17:01:33.0214937' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (9, N'ET-1', N'thermal-printer', N'EPSON thermal printer', N'n', N'6eaba1dc3c031faf262149c058fea728.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:14:16.7573809' AS DateTime2), CAST(N'2021-07-04T13:56:50.3459418' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (10, N'ET-2', N'EPSON thermal printer2', N'EPSON-thermal-printer2', N'n', N'0f26776e0a524c7d2b6b5f771d500980.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-29T16:00:27.3275937' AS DateTime2), 1, 2, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (11, N'ET-3', N'EPSON-K500', N'EPSON-thermal-printer3', N'n', N'05da7ccc8020731d607471318fc4f35b.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:15:40.8420029' AS DateTime2), CAST(N'2021-07-29T15:47:49.2749868' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (12, N'ET-4', N'EPSON-thermal-printer4', N'EPSON-thermal-printer4', N'n', N'0731f29a7d8c55ddab810a076d078aff.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-04T13:56:50.3638930' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (13, N'PP610', N'POZONE-PP610-USB', N'POZONE-PP610-USB', N'n', N'd24538a57424ec2d36086326b9215b74.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:16:32.6852530' AS DateTime2), CAST(N'2021-07-04T13:56:50.3668848' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (14, N'POZONE', N'POZONE-thermal-printer', N'POZONE-thermal-printer', N'n', N'ad4bfd50185ef68bce2b903aa7e10ec0.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-04T13:56:50.3728688' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (15, N'RIO', N'rio-thermal-printer', N'rio-thermal-printer', N'n', N'cfba0c3306a45ea0746c531906c58962.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:23:16.1801577' AS DateTime2), CAST(N'2021-07-04T13:56:50.3798507' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (16, N'STP', N'Sewoo-thermal-printer', N'Sewoo-thermal-printer', N'n', N'4361139d4379eb98f913441815402fe6.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-04T13:56:50.3918179' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (17, N'ZD200D', N'Zebra-ZD200D', N'Zebra-ZD200D', N'n', N'5dee7ade7f7ceefa02cc62d1d5961622.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 2, NULL, CAST(N'2021-07-01T14:24:25.4197898' AS DateTime2), CAST(N'2021-07-04T13:56:50.3968039' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (18, N'M-AS', N'الأسبرين ', N'الأسبرين ', N'd', N'9c8336c58218f7dbea9b172c0da81139.jpg', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 17, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-04T13:56:13.4003614' AS DateTime2), 1, 1, 1, 3)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (19, N'M-BR', N'بروفين ', N'بروفين  400', N'd', N'b06b32577361609a56f8d74e9e127a01.png', CAST(0.00 AS Decimal(20, 2)), 1, 5, 12, 17, NULL, CAST(N'2021-07-01T14:29:08.0748019' AS DateTime2), CAST(N'2021-07-04T13:56:13.4023552' AS DateTime2), 1, 1, 1, 3)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (20, N'M-bS', N'باراسيتامول ', N'باراسيتامول ', N'd', N'cba6ef02fcbd47ba36115f8f64248594.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 17, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-04T13:56:13.4033515' AS DateTime2), 1, 1, 1, 3)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (21, N'IPH-11', N'Iphone 11', N'Iphone 11', N'sn', N'90f607ba318fce94cafe1571617d1b6c.png', CAST(10.00 AS Decimal(20, 2)), 1, 0, 0, 4, NULL, CAST(N'2021-07-01T14:30:50.2396205' AS DateTime2), CAST(N'2021-07-28T17:00:49.5217515' AS DateTime2), 1, 2, 1, 1)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (22, N'IPH-11G', N'Iphone 11 Gold', N'Iphone 11 Gold', N'sn', N'77d0501bbf02ad459f88ab4b7531b14d.jpg', CAST(10.00 AS Decimal(20, 2)), 1, 0, 0, 4, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-12T15:47:27.0826403' AS DateTime2), 1, 2, 1, 1)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (23, N'1', N'backage1', N'details1', N'', N'e8a124154d6b4436a9d47827fcd24d4d.png', CAST(20.00 AS Decimal(20, 2)), 0, NULL, NULL, 2, NULL, CAST(N'2021-07-14T14:34:34.8704274' AS DateTime2), CAST(N'2021-07-15T13:20:31.2680816' AS DateTime2), 3, 3, NULL, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (24, N'2', N'package2', N'details2', N'p', N'3f85263e6e6e21f6a4057fab7f956f1b.png', CAST(20.00 AS Decimal(20, 2)), 1, NULL, NULL, 2, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-26T10:36:09.9751322' AS DateTime2), 3, 3, NULL, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (26, N'3', N'package3', N'details3', N'', N'37de6228ecdaf854ca17e0abd1062763.jpg', CAST(20.00 AS Decimal(20, 2)), 1, NULL, NULL, 4, NULL, CAST(N'2021-07-15T12:35:10.2370133' AS DateTime2), CAST(N'2021-07-17T10:15:16.0668990' AS DateTime2), 3, 3, NULL, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (27, N'4', N'name1', N'datails1', N'', N'15c139cdb9cb2a3e6788751f02626b1e.png', CAST(12.00 AS Decimal(20, 2)), 1, NULL, NULL, 4, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-17T10:37:43.7572240' AS DateTime2), 3, 3, NULL, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (28, N'CDRb', N'Cash Drawer-black', N'Cash Drawer', N'n', N'b754f525b6f76b3c7201c0d029f5b267.png', CAST(5.00 AS Decimal(20, 2)), 1, 10, 1, 1, 3, CAST(N'2021-07-24T16:46:56.0586229' AS DateTime2), CAST(N'2021-07-24T16:54:24.4054444' AS DateTime2), 1, 1, 1, 2)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (29, N'12', N'package1', N'details1', N'p', N'66b335393cbb2b27cf54475a279dc1be.png', CAST(20.00 AS Decimal(20, 2)), 1, NULL, NULL, 6, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-26T11:38:09.6915950' AS DateTime2), 3, 3, NULL, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (30, N'14', N'package3', N'details3', N'p', N'f2fed73dd13758a54ab2be16f5bb5171.png', CAST(15.00 AS Decimal(20, 2)), 1, NULL, NULL, 4, NULL, CAST(N'2021-07-26T10:37:42.9909910' AS DateTime2), CAST(N'2021-07-26T10:37:42.9909910' AS DateTime2), 3, 3, NULL, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (31, N'13', N'name3', N'details3', N'p', N'77b0157cfc76ae37db589ccef70d65f4.png', CAST(2.00 AS Decimal(20, 2)), 1, NULL, NULL, 3, NULL, CAST(N'2021-08-02T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-26T10:41:59.4600843' AS DateTime2), 3, 3, NULL, NULL)
SET IDENTITY_INSERT [dbo].[items] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsLocations] ON 

INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (1, 10, 112, CAST(N'2021-07-04T16:17:28.0526553' AS DateTime2), CAST(N'2021-07-27T16:30:10.2060552' AS DateTime2), 1, 2, NULL, NULL, 9, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (3, 10, 156, CAST(N'2021-07-04T16:17:28.1753201' AS DateTime2), CAST(N'2021-07-27T16:30:10.2374977' AS DateTime2), 1, 2, NULL, NULL, 11, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (4, 10, 50, CAST(N'2021-07-04T17:03:59.7703711' AS DateTime2), CAST(N'2021-07-04T17:03:59.7703711' AS DateTime2), 1, 1, NULL, NULL, 6, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (8, 17, 5, CAST(N'2021-07-11T12:27:39.3339834' AS DateTime2), CAST(N'2021-08-02T12:36:40.4190618' AS DateTime2), 2, 2, CAST(N'2021-07-01' AS Date), CAST(N'2021-07-31' AS Date), 7, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (9, 18, 0, CAST(N'2021-07-11T12:27:54.3356373' AS DateTime2), CAST(N'2021-07-27T16:30:10.2218023' AS DateTime2), 2, 2, CAST(N'2021-07-01' AS Date), CAST(N'2021-07-31' AS Date), 11, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (21, 2, 56, CAST(N'2021-07-15T13:04:39.9758949' AS DateTime2), CAST(N'2021-07-15T13:04:39.9758949' AS DateTime2), 9, 9, NULL, NULL, 6, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (23, 38, 1000, CAST(N'2021-07-15T16:28:31.8588873' AS DateTime2), CAST(N'2021-07-18T16:39:11.3873534' AS DateTime2), 2, 2, NULL, NULL, 6, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (25, 38, 46, CAST(N'2021-07-15T16:31:52.4233803' AS DateTime2), CAST(N'2021-07-15T16:31:52.4233803' AS DateTime2), 2, 2, CAST(N'2021-07-01' AS Date), CAST(N'2021-07-31' AS Date), 9, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (26, 38, 50, CAST(N'2021-07-15T16:32:05.6419779' AS DateTime2), CAST(N'2021-07-15T16:32:05.6419779' AS DateTime2), 2, 2, CAST(N'2021-07-01' AS Date), CAST(N'2021-07-01' AS Date), 9, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (27, 1, 120, CAST(N'2021-07-18T19:20:35.2264378' AS DateTime2), CAST(N'2021-07-31T15:19:47.0139457' AS DateTime2), 2, 1, NULL, NULL, 1, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (28, 1, 80, CAST(N'2021-07-18T19:20:35.2421471' AS DateTime2), CAST(N'2021-07-30T00:35:54.8804099' AS DateTime2), 2, 1, NULL, NULL, 6, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (29, 1, 0, CAST(N'2021-07-18T19:20:35.2731098' AS DateTime2), CAST(N'2021-08-04T10:24:58.1467603' AS DateTime2), 2, 1, NULL, NULL, 9, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (30, 1, 6, CAST(N'2021-07-18T19:20:35.2731098' AS DateTime2), CAST(N'2021-07-30T00:33:39.3200386' AS DateTime2), 2, 2, NULL, NULL, 11, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (31, 1, 221, CAST(N'2021-07-18T19:20:35.2887917' AS DateTime2), CAST(N'2021-08-02T12:18:25.4934917' AS DateTime2), 2, 2, NULL, NULL, 17, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (36, 1, 26, CAST(N'2021-07-18T19:39:30.9141015' AS DateTime2), CAST(N'2021-07-30T15:08:15.8730124' AS DateTime2), 2, 1, NULL, NULL, 3, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (38, 1, 44, CAST(N'2021-07-18T19:39:30.9141015' AS DateTime2), CAST(N'2021-07-29T20:31:12.5195118' AS DateTime2), 2, 2, NULL, NULL, 12, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (41, 22, 87, CAST(N'2021-07-18T20:09:41.7512952' AS DateTime2), CAST(N'2021-08-02T12:21:57.9608678' AS DateTime2), 2, 2, NULL, NULL, 18, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (42, 23, 40, CAST(N'2021-07-19T12:47:16.6586954' AS DateTime2), CAST(N'2021-08-02T12:25:16.3960318' AS DateTime2), 2, 2, NULL, NULL, 1, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (43, 22, 12, CAST(N'2021-07-19T12:47:26.4557301' AS DateTime2), CAST(N'2021-07-19T12:47:26.4557301' AS DateTime2), 2, 2, NULL, NULL, 17, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (44, 20, 43, CAST(N'2021-07-24T10:53:31.0513155' AS DateTime2), CAST(N'2021-08-02T12:20:43.2743039' AS DateTime2), 1, 2, CAST(N'2021-07-08' AS Date), CAST(N'2021-07-27' AS Date), 10, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (45, 1, 142, CAST(N'2021-07-29T11:33:22.9229602' AS DateTime2), CAST(N'2021-07-31T15:21:09.4587972' AS DateTime2), 9, 1, NULL, NULL, 18, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (46, 1, 18, CAST(N'2021-07-29T11:39:03.1771008' AS DateTime2), CAST(N'2021-07-31T21:08:08.2775629' AS DateTime2), 9, 1, NULL, NULL, 7, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (47, 2, 20, CAST(N'2021-07-29T21:54:15.6034894' AS DateTime2), CAST(N'2021-07-29T21:54:15.6034894' AS DateTime2), 1, 1, NULL, NULL, 7, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (49, 24, 18, CAST(N'2021-07-29T22:00:38.1737566' AS DateTime2), CAST(N'2021-07-29T22:20:30.1316731' AS DateTime2), 1, 1, NULL, NULL, 3, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (50, 25, 0, CAST(N'2021-07-31T15:21:09.4587972' AS DateTime2), CAST(N'2021-08-03T17:18:04.1073143' AS DateTime2), 1, 2, NULL, NULL, 18, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (51, 18, 49, CAST(N'2021-07-31T21:08:08.2775629' AS DateTime2), CAST(N'2021-08-02T12:16:00.3377854' AS DateTime2), 1, 2, CAST(N'2021-07-01' AS Date), CAST(N'2021-10-31' AS Date), 7, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (52, 18, 88, CAST(N'2021-08-01T13:22:07.2697052' AS DateTime2), CAST(N'2021-08-01T13:24:49.5026435' AS DateTime2), 1, 1, CAST(N'2021-07-01' AS Date), CAST(N'2021-07-31' AS Date), 7, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (53, 23, 10, CAST(N'2021-08-03T17:18:04.1216564' AS DateTime2), CAST(N'2021-08-03T17:18:04.1216564' AS DateTime2), 2, 2, NULL, NULL, 18, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (54, 1, 96, CAST(N'2021-08-04T10:24:58.1781974' AS DateTime2), CAST(N'2021-08-04T10:24:58.1781974' AS DateTime2), 1, 1, NULL, NULL, 10, NULL)
SET IDENTITY_INSERT [dbo].[itemsLocations] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsProp] ON 

INSERT [dbo].[itemsProp] ([itemPropId], [propertyItemId], [itemId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (2, 1, 1, CAST(N'2021-07-01T14:37:23.8934926' AS DateTime2), CAST(N'2021-07-01T14:37:23.8934926' AS DateTime2), 1, 1)
INSERT [dbo].[itemsProp] ([itemPropId], [propertyItemId], [itemId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (5, 3, 28, CAST(N'2021-07-24T16:47:20.8237469' AS DateTime2), CAST(N'2021-07-24T16:47:20.8237469' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[itemsProp] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsTransfer] ON 

INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (203, 1, 151, NULL, NULL, CAST(N'2021-07-29T18:22:39.2889937' AS DateTime2), CAST(N'2021-07-29T18:22:39.2889937' AS DateTime2), 9, 9, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (204, 1, 151, NULL, NULL, CAST(N'2021-07-29T18:22:39.2889937' AS DateTime2), CAST(N'2021-07-29T18:22:39.2889937' AS DateTime2), 9, 9, NULL, CAST(500.00 AS Decimal(20, 2)), 10, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (207, 1, 153, NULL, NULL, CAST(N'2021-07-29T20:29:51.8242602' AS DateTime2), CAST(N'2021-07-29T20:29:51.8242602' AS DateTime2), 1, 1, NULL, CAST(500.00 AS Decimal(20, 2)), 7, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (208, 1, 152, NULL, NULL, CAST(N'2021-07-29T20:31:12.1622645' AS DateTime2), CAST(N'2021-07-29T20:31:12.1622645' AS DateTime2), 1, 1, NULL, CAST(1500.00 AS Decimal(20, 2)), 12, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (211, 1, 154, NULL, NULL, CAST(N'2021-07-29T20:34:35.2133351' AS DateTime2), CAST(N'2021-07-29T20:34:35.2133351' AS DateTime2), 1, 1, NULL, CAST(500.00 AS Decimal(20, 2)), 7, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (212, 1, 156, NULL, NULL, CAST(N'2021-07-29T21:50:00.5359323' AS DateTime2), CAST(N'2021-07-29T21:50:00.5359323' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 9, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (213, 1, 157, NULL, NULL, CAST(N'2021-07-29T21:50:00.7642781' AS DateTime2), CAST(N'2021-07-29T21:50:00.7642781' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 9, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (214, 20, 158, NULL, NULL, CAST(N'2021-07-29T21:54:17.0768392' AS DateTime2), CAST(N'2021-07-29T21:54:17.0768392' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 7, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (215, 20, 159, NULL, NULL, CAST(N'2021-07-29T21:54:17.2770535' AS DateTime2), CAST(N'2021-07-29T21:54:17.2770535' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 7, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (216, 20, 160, NULL, NULL, CAST(N'2021-07-29T22:10:33.8651043' AS DateTime2), CAST(N'2021-07-29T22:10:33.8651043' AS DateTime2), 1, 1, NULL, CAST(500.00 AS Decimal(20, 2)), 6, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (217, 10, 160, NULL, NULL, CAST(N'2021-07-29T22:10:33.8651043' AS DateTime2), CAST(N'2021-07-29T22:10:33.8651043' AS DateTime2), 1, 1, NULL, CAST(50.00 AS Decimal(20, 2)), 1, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (220, 1, 161, NULL, NULL, CAST(N'2021-07-29T22:17:17.5013049' AS DateTime2), CAST(N'2021-07-29T22:17:17.5013049' AS DateTime2), 1, 1, NULL, CAST(500.00 AS Decimal(20, 2)), 7, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (221, 2, 163, NULL, NULL, CAST(N'2021-07-29T22:20:29.5937516' AS DateTime2), CAST(N'2021-07-29T22:20:29.5937516' AS DateTime2), NULL, NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 3, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (222, 5, 164, NULL, NULL, CAST(N'2021-07-29T22:56:23.3728126' AS DateTime2), CAST(N'2021-07-29T22:56:23.3728126' AS DateTime2), 1, 1, NULL, CAST(2.00 AS Decimal(20, 2)), 11, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (223, 10, 164, NULL, NULL, CAST(N'2021-07-29T22:56:23.3803955' AS DateTime2), CAST(N'2021-07-29T22:56:23.3803955' AS DateTime2), 1, 1, NULL, CAST(3.00 AS Decimal(20, 2)), 9, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (224, 2, 165, NULL, NULL, CAST(N'2021-07-30T00:33:02.6502691' AS DateTime2), CAST(N'2021-07-30T00:33:02.6502691' AS DateTime2), 2, 2, NULL, CAST(5849.00 AS Decimal(20, 2)), 1, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (225, 5, 165, NULL, NULL, CAST(N'2021-07-30T00:33:02.6551395' AS DateTime2), CAST(N'2021-07-30T00:33:02.6551395' AS DateTime2), 2, 2, NULL, CAST(655.00 AS Decimal(20, 2)), 11, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (226, 5, 166, NULL, NULL, CAST(N'2021-07-30T00:35:54.2046878' AS DateTime2), CAST(N'2021-07-30T00:35:54.2046878' AS DateTime2), 2, 2, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (227, 1, 166, NULL, NULL, CAST(N'2021-07-30T00:35:54.2052672' AS DateTime2), CAST(N'2021-07-30T00:35:54.2052672' AS DateTime2), 2, 2, NULL, CAST(500.00 AS Decimal(20, 2)), 10, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (228, 2, 167, NULL, NULL, CAST(N'2021-07-30T14:26:30.6415534' AS DateTime2), CAST(N'2021-07-30T14:26:30.6415534' AS DateTime2), 1, 1, NULL, CAST(50000.00 AS Decimal(20, 2)), 1, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (229, 50, 150, NULL, NULL, CAST(N'2021-07-30T15:05:53.4829461' AS DateTime2), CAST(N'2021-07-30T15:05:53.4829461' AS DateTime2), 1, 1, NULL, CAST(1100.00 AS Decimal(20, 2)), 1, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (230, 10, 150, NULL, NULL, CAST(N'2021-07-30T15:05:53.4856074' AS DateTime2), CAST(N'2021-07-30T15:05:53.4856074' AS DateTime2), 1, 1, NULL, CAST(5.00 AS Decimal(20, 2)), 9, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (231, 5, 168, NULL, NULL, CAST(N'2021-07-30T15:07:33.8449601' AS DateTime2), CAST(N'2021-07-30T15:07:33.8449601' AS DateTime2), 1, 1, NULL, CAST(110.00 AS Decimal(20, 2)), 3, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (232, 10, 168, NULL, NULL, CAST(N'2021-07-30T15:07:33.8460362' AS DateTime2), CAST(N'2021-07-30T15:07:33.8460362' AS DateTime2), 1, 1, NULL, CAST(50.00 AS Decimal(20, 2)), 18, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (233, 11, 169, NULL, NULL, CAST(N'2021-07-31T15:18:56.1229446' AS DateTime2), CAST(N'2021-07-31T15:18:56.1229446' AS DateTime2), 1, 1, NULL, CAST(50.00 AS Decimal(20, 2)), 17, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (234, 20, 170, NULL, NULL, CAST(N'2021-07-31T21:05:00.7127925' AS DateTime2), CAST(N'2021-07-31T21:05:00.7127925' AS DateTime2), 1, 1, NULL, CAST(5.00 AS Decimal(20, 2)), 9, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (235, 1, 171, NULL, NULL, CAST(N'2021-08-01T12:14:11.0964880' AS DateTime2), CAST(N'2021-08-01T12:14:11.0964880' AS DateTime2), 2, 2, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (236, 1, 172, NULL, NULL, CAST(N'2021-08-01T12:15:21.0811239' AS DateTime2), CAST(N'2021-08-01T12:15:21.0811239' AS DateTime2), 2, 2, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (237, 5, 173, NULL, NULL, CAST(N'2021-08-01T13:13:17.0972551' AS DateTime2), CAST(N'2021-08-01T13:13:17.0972551' AS DateTime2), 2, 2, NULL, CAST(500.00 AS Decimal(20, 2)), 10, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (238, 43, 174, NULL, NULL, CAST(N'2021-08-01T13:14:03.1677629' AS DateTime2), CAST(N'2021-08-01T13:14:03.1677629' AS DateTime2), 2, 2, NULL, CAST(500.00 AS Decimal(20, 2)), 10, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (239, 1, 175, NULL, NULL, CAST(N'2021-08-01T13:15:16.7746473' AS DateTime2), CAST(N'2021-08-01T13:15:16.7746473' AS DateTime2), 2, 2, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (240, 5, 176, NULL, NULL, CAST(N'2021-08-01T13:17:33.0027739' AS DateTime2), CAST(N'2021-08-01T13:17:33.0027739' AS DateTime2), 2, 2, NULL, CAST(125.00 AS Decimal(20, 2)), 17, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (241, 10, 177, NULL, NULL, CAST(N'2021-08-01T13:39:33.7776148' AS DateTime2), CAST(N'2021-08-01T13:39:33.7776148' AS DateTime2), 3, 3, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (242, 1, 178, NULL, NULL, CAST(N'2021-08-02T00:32:10.4155125' AS DateTime2), CAST(N'2021-08-02T00:32:10.4155125' AS DateTime2), 1, 1, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (243, 1, 178, NULL, NULL, CAST(N'2021-08-02T00:32:10.4203324' AS DateTime2), CAST(N'2021-08-02T00:32:10.4203324' AS DateTime2), 1, 1, NULL, CAST(10000.00 AS Decimal(20, 2)), 3, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (244, 5, 179, NULL, NULL, CAST(N'2021-08-02T10:28:27.9029142' AS DateTime2), CAST(N'2021-08-02T10:28:27.9029142' AS DateTime2), 3, 3, NULL, CAST(0.00 AS Decimal(20, 2)), 11, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (245, 5, 180, NULL, NULL, CAST(N'2021-08-02T10:32:13.1538646' AS DateTime2), CAST(N'2021-08-02T10:32:13.1538646' AS DateTime2), 3, 3, NULL, CAST(0.00 AS Decimal(20, 2)), 9, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (246, 5, 180, NULL, NULL, CAST(N'2021-08-02T10:32:13.1549116' AS DateTime2), CAST(N'2021-08-02T10:32:13.1549116' AS DateTime2), 3, 3, NULL, CAST(0.00 AS Decimal(20, 2)), 9, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (247, 1, 182, NULL, NULL, CAST(N'2021-08-02T12:15:59.7929280' AS DateTime2), CAST(N'2021-08-02T12:15:59.7929280' AS DateTime2), NULL, NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 7, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (248, 1, 183, NULL, NULL, CAST(N'2021-08-02T12:18:22.1252625' AS DateTime2), CAST(N'2021-08-02T12:18:22.1252625' AS DateTime2), NULL, NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 17, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (249, 1, 184, NULL, NULL, CAST(N'2021-08-02T12:19:07.3634997' AS DateTime2), CAST(N'2021-08-02T12:19:07.3634997' AS DateTime2), NULL, NULL, NULL, CAST(25.00 AS Decimal(20, 2)), 18, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (250, 5, 185, NULL, NULL, CAST(N'2021-08-02T12:20:39.8107842' AS DateTime2), CAST(N'2021-08-02T12:20:39.8107842' AS DateTime2), NULL, NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 10, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (251, 2, 186, NULL, NULL, CAST(N'2021-08-02T12:21:57.5047612' AS DateTime2), CAST(N'2021-08-02T12:21:57.5047612' AS DateTime2), NULL, NULL, NULL, CAST(25.00 AS Decimal(20, 2)), 18, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (252, 10, 187, NULL, NULL, CAST(N'2021-08-02T12:25:15.9124298' AS DateTime2), CAST(N'2021-08-02T12:25:15.9124298' AS DateTime2), NULL, NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 1, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (253, 2, 188, NULL, NULL, CAST(N'2021-08-02T12:36:39.9357669' AS DateTime2), CAST(N'2021-08-02T12:36:39.9357669' AS DateTime2), NULL, NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 7, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (254, 1, 189, NULL, NULL, CAST(N'2021-08-03T13:14:19.7601367' AS DateTime2), CAST(N'2021-08-03T13:14:19.7601367' AS DateTime2), 3, 3, NULL, CAST(1222.00 AS Decimal(20, 2)), 7, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (255, 1, 190, NULL, NULL, CAST(N'2021-08-03T19:12:54.9227091' AS DateTime2), CAST(N'2021-08-03T19:12:54.9227091' AS DateTime2), 9, 9, NULL, CAST(0.00 AS Decimal(20, 2)), 7, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (256, 2, 190, NULL, NULL, CAST(N'2021-08-03T19:12:54.9307376' AS DateTime2), CAST(N'2021-08-03T19:12:54.9307376' AS DateTime2), 9, 9, NULL, CAST(0.00 AS Decimal(20, 2)), 10, N'')
SET IDENTITY_INSERT [dbo].[itemsTransfer] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsUnits] ON 

INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (1, 1, 4, 10, 0, 1, CAST(1000000.00 AS Decimal(20, 2)), N'4078525279900', CAST(N'2021-07-01T14:44:41.7298217' AS DateTime2), CAST(N'2021-07-01T14:44:41.7298217' AS DateTime2), 1, 1, 3, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (2, 1, 3, 10, 0, 0, CAST(100000.00 AS Decimal(20, 2)), N'8078525308101', CAST(N'2021-07-01T14:44:59.9506480' AS DateTime2), CAST(N'2021-07-01T14:44:59.9506480' AS DateTime2), 1, 1, 1, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (3, 1, 1, 1, 1, 0, CAST(10000.00 AS Decimal(20, 2)), N'1078525310002', CAST(N'2021-07-01T14:45:13.7321603' AS DateTime2), CAST(N'2021-07-01T14:45:13.7321603' AS DateTime2), 1, 1, 1, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (6, 21, 1, 1, 1, 1, CAST(1200000.00 AS Decimal(20, 2)), N'9078525346911', CAST(N'2021-07-01T14:51:39.5162385' AS DateTime2), CAST(N'2021-07-01T14:51:39.5162385' AS DateTime2), 1, 1, 1, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (7, 19, 2, 12, 0, 1, CAST(10000.00 AS Decimal(20, 2)), N'9078525349912', CAST(N'2021-07-01T14:52:35.2357118' AS DateTime2), CAST(N'2021-07-03T10:55:23.0696576' AS DateTime2), 1, 1, 1, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (8, 19, 1, 1, 1, 0, CAST(1000.00 AS Decimal(20, 2)), N'3078525355513', CAST(N'2021-07-01T14:52:46.5385199' AS DateTime2), CAST(N'2021-07-01T14:52:46.5385199' AS DateTime2), 1, 1, 1, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (9, 18, 2, 12, 0, 1, CAST(5000.00 AS Decimal(20, 2)), N'8078543943001', CAST(N'2021-07-03T10:57:25.6220112' AS DateTime2), CAST(N'2021-07-25T11:35:38.0737335' AS DateTime2), 1, 1, 1, NULL, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (10, 18, 1, 1, 1, 0, CAST(500.00 AS Decimal(20, 2)), N'4078543945504', CAST(N'2021-07-03T10:57:48.3277860' AS DateTime2), CAST(N'2021-07-03T10:57:48.3277860' AS DateTime2), 1, 1, 1, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (11, 20, 2, 12, 0, 1, CAST(1250.00 AS Decimal(20, 2)), N'9078543955607', CAST(N'2021-07-03T10:59:35.7246859' AS DateTime2), CAST(N'2021-07-25T11:43:23.9080779' AS DateTime2), 1, 1, 1, NULL, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (12, 20, 1, 1, 1, 0, CAST(1500.00 AS Decimal(20, 2)), N'3078543957508', CAST(N'2021-07-03T10:59:59.8630022' AS DateTime2), CAST(N'2021-07-04T13:11:23.1386605' AS DateTime2), 1, 1, 1, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (13, 26, 11, NULL, NULL, NULL, CAST(8888888.00 AS Decimal(20, 2)), N'078664667700', CAST(N'2021-07-15T12:35:15.5340024' AS DateTime2), CAST(N'2021-07-17T10:15:25.7699628' AS DateTime2), 3, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (14, 23, 11, NULL, NULL, NULL, CAST(1111111.00 AS Decimal(20, 2)), N'078664729101', CAST(N'2021-07-15T13:08:36.4469190' AS DateTime2), CAST(N'2021-07-15T13:08:36.4469190' AS DateTime2), 3, 3, NULL, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (15, 24, 11, NULL, NULL, NULL, CAST(15000.00 AS Decimal(20, 2)), N'078683786301', CAST(N'2021-07-17T10:31:40.0468171' AS DateTime2), CAST(N'2021-07-26T10:36:11.3071575' AS DateTime2), 3, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (16, 27, 11, NULL, NULL, NULL, CAST(111111.00 AS Decimal(20, 2)), N'078683813600', CAST(N'2021-07-17T10:36:41.6623136' AS DateTime2), CAST(N'2021-07-17T10:37:45.1324540' AS DateTime2), 3, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (17, 2, 12, 12, 0, 1, CAST(125.00 AS Decimal(20, 2)), N'8078696805102', CAST(N'2021-07-18T18:56:04.1895801' AS DateTime2), CAST(N'2021-07-18T18:56:04.1895801' AS DateTime2), 1, 1, 1, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (18, 17, 1, 1, 1, 1, CAST(500000.00 AS Decimal(20, 2)), N'8078697220300', CAST(N'2021-07-18T20:04:00.3555774' AS DateTime2), CAST(N'2021-07-18T20:04:00.3555774' AS DateTime2), 2, 2, 1, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (19, 29, 11, NULL, 1, NULL, CAST(15000.00 AS Decimal(20, 2)), N'078683786301', CAST(N'2021-07-26T10:36:30.0982340' AS DateTime2), CAST(N'2021-07-26T11:38:11.1662176' AS DateTime2), 3, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (20, 30, 11, NULL, 1, NULL, CAST(50000.00 AS Decimal(20, 2)), N'078773818901', CAST(N'2021-07-26T10:37:44.0971823' AS DateTime2), CAST(N'2021-07-26T10:37:44.0971823' AS DateTime2), 3, 3, NULL, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (21, 31, 11, NULL, 1, NULL, CAST(120000.00 AS Decimal(20, 2)), N'078773843600', CAST(N'2021-07-26T10:42:00.9296014' AS DateTime2), CAST(N'2021-07-26T10:42:00.9296014' AS DateTime2), 3, 3, NULL, NULL, NULL)
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
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (17, N'A', N'A', N'1', CAST(N'2021-07-03T17:42:28.3338023' AS DateTime2), CAST(N'2021-07-11T12:25:52.8921130' AS DateTime2), 1, 1, 1, 19, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (18, N'A', N'A', N'2', CAST(N'2021-07-03T17:42:28.3709619' AS DateTime2), CAST(N'2021-07-27T15:17:23.0504749' AS DateTime2), 1, 2, 1, 19, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (19, N'A', N'A', N'3', CAST(N'2021-07-03T17:42:28.3829295' AS DateTime2), CAST(N'2021-07-11T12:25:52.9215453' AS DateTime2), 1, 1, 1, 19, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (20, N'A', N'A', N'4', CAST(N'2021-07-03T17:42:28.3919065' AS DateTime2), CAST(N'2021-07-11T12:25:52.9236317' AS DateTime2), 1, 1, 1, 19, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (21, N'A', N'A', N'5', CAST(N'2021-07-03T17:42:28.4008819' AS DateTime2), CAST(N'2021-07-11T12:25:52.9263308' AS DateTime2), 1, 1, 1, 19, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (22, N'A', N'B', N'1', CAST(N'2021-07-03T17:42:28.4078630' AS DateTime2), CAST(N'2021-07-11T13:10:12.0641879' AS DateTime2), 1, 1, 1, 20, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (23, N'A', N'B', N'2', CAST(N'2021-07-03T17:42:28.4178372' AS DateTime2), CAST(N'2021-07-11T13:10:12.0799054' AS DateTime2), 1, 1, 1, 20, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (24, N'A', N'B', N'3', CAST(N'2021-07-03T17:42:28.4327961' AS DateTime2), CAST(N'2021-07-11T13:10:12.0641879' AS DateTime2), 1, 1, 1, 20, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (25, N'A', N'B', N'4', CAST(N'2021-07-03T17:42:28.4417736' AS DateTime2), CAST(N'2021-07-11T13:10:12.0641879' AS DateTime2), 1, 1, 1, 20, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (26, N'A', N'B', N'5', CAST(N'2021-07-03T17:42:28.4547383' AS DateTime2), CAST(N'2021-07-11T13:10:12.0641879' AS DateTime2), 1, 1, 1, 20, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (27, N'A', N'A', N'1', CAST(N'2021-07-04T17:05:19.6628269' AS DateTime2), CAST(N'2021-07-10T15:56:39.5692917' AS DateTime2), 1, 1, 1, 17, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (28, N'A', N'A', N'2', CAST(N'2021-07-04T17:05:19.7126918' AS DateTime2), CAST(N'2021-07-10T15:56:39.5671842' AS DateTime2), 1, 1, 1, 17, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (29, N'A', N'A', N'3', CAST(N'2021-07-04T17:05:19.7196729' AS DateTime2), CAST(N'2021-07-10T15:56:39.5645516' AS DateTime2), 1, 1, 1, 17, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (30, N'A', N'A', N'4', CAST(N'2021-07-04T17:05:19.7296467' AS DateTime2), CAST(N'2021-07-10T15:56:39.5613936' AS DateTime2), 1, 1, 1, 17, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (31, N'A', N'A', N'5', CAST(N'2021-07-04T17:05:19.7356311' AS DateTime2), CAST(N'2021-07-10T15:56:39.5476755' AS DateTime2), 1, 1, 1, 17, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (32, N'A', N'B', N'1', CAST(N'2021-07-04T17:05:19.7436089' AS DateTime2), CAST(N'2021-07-06T12:45:19.9439705' AS DateTime2), 1, 2, 1, 17, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (33, N'A', N'B', N'2', CAST(N'2021-07-04T17:05:19.7515880' AS DateTime2), CAST(N'2021-07-06T12:45:19.9439705' AS DateTime2), 1, 2, 1, 17, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (34, N'A', N'B', N'3', CAST(N'2021-07-04T17:05:19.7605638' AS DateTime2), CAST(N'2021-07-06T12:45:19.9439705' AS DateTime2), 1, 2, 1, 17, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (35, N'A', N'B', N'4', CAST(N'2021-07-04T17:05:19.7675496' AS DateTime2), CAST(N'2021-07-06T12:45:19.9439705' AS DateTime2), 1, 2, 1, 17, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (36, N'A', N'B', N'5', CAST(N'2021-07-04T17:05:19.7745286' AS DateTime2), CAST(N'2021-07-06T12:45:19.9596804' AS DateTime2), 1, 2, 1, 17, N'', 12, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (37, N'0', N'0', N'0', CAST(N'2021-07-12T18:39:17.2024475' AS DateTime2), CAST(N'2021-07-12T18:40:10.4263872' AS DateTime2), 9, 9, 1, 21, N'', 10, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (38, N'1', N'1', N'1', CAST(N'2021-07-15T16:27:22.3893288' AS DateTime2), CAST(N'2021-07-15T16:28:20.7183174' AS DateTime2), 2, 2, 1, 22, N'', 5, NULL)
SET IDENTITY_INSERT [dbo].[locations] OFF
GO
SET IDENTITY_INSERT [dbo].[objects] ON 

INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (1, N'catalog', NULL, NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (2, N'storage', NULL, NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (3, N'purchase', NULL, NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (4, N'sales', NULL, NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (5, N'accounts', NULL, NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (6, N'sectionData', NULL, NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (7, N'settings', NULL, NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (8, N'home', NULL, NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (9, N'categories', NULL, NULL, NULL, NULL, NULL, 1, 1, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (10, N'item', NULL, NULL, NULL, NULL, NULL, 1, 1, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (11, N'properties', NULL, NULL, NULL, NULL, NULL, 1, 1, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (12, N'units', NULL, NULL, NULL, NULL, NULL, 1, 1, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (13, N'locations', NULL, NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (14, N'section', NULL, NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (15, N'reciptOfInvoice', NULL, NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (16, N'itemsStorage', NULL, NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (17, N'importExport', NULL, NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (18, N'itemsDestroy', NULL, NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (19, N'inventory', NULL, NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (20, N'storageStatistic', NULL, NULL, NULL, NULL, NULL, 1, 2, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (21, N'payInvoice', NULL, NULL, NULL, NULL, NULL, 1, 3, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (22, N'purchaseStatistic', NULL, NULL, NULL, NULL, NULL, 1, 3, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (23, N'reciptInvoice', NULL, NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (24, N'coupon', NULL, NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (25, N'offer', NULL, NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (26, N'package', NULL, NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (27, N'quotation', NULL, NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (28, N'medals', NULL, NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (29, N'membership', NULL, NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (30, N'salesStatistic', NULL, NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (31, N'posAccounting', NULL, NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (32, N'payments', NULL, NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (33, N'received', NULL, NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (34, N'bonds', NULL, NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (35, N'banksAccounting', NULL, NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (36, N'accountsStatistic', NULL, NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (37, N'suppliers', NULL, NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (38, N'customers', NULL, NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (39, N'users', NULL, NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (40, N'branches', NULL, NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (41, N'stores', NULL, NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (42, N'pos', NULL, NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (43, N'banks', NULL, NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (44, N'cards', NULL, NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (45, N'shippingCompany', NULL, NULL, NULL, NULL, NULL, 1, 6, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (46, N'general', NULL, NULL, NULL, NULL, NULL, 1, 7, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (47, N'reportsSettings', NULL, NULL, NULL, NULL, NULL, 1, 7, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (48, N'permissions', NULL, NULL, NULL, NULL, NULL, 1, 7, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (49, N'subscriptions', NULL, NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (50, N'suppliers_basics', NULL, NULL, NULL, NULL, NULL, 1, 37, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (51, N'customers_basics', NULL, NULL, NULL, NULL, NULL, 1, 38, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (52, N'users_basics', NULL, NULL, NULL, NULL, NULL, 1, 39, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (53, N'users_stores', NULL, NULL, NULL, NULL, NULL, 1, 39, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (54, N'branches_basics', NULL, NULL, NULL, NULL, NULL, 1, 40, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (55, N'branches_branches', NULL, NULL, NULL, NULL, NULL, 1, 40, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (56, N'stores_basics', NULL, NULL, NULL, NULL, NULL, 1, 41, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (57, N'stores_branches', NULL, NULL, NULL, NULL, NULL, 1, 41, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (58, N'pos_basics', NULL, NULL, NULL, NULL, NULL, 1, 42, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (59, N'banks_basics', NULL, NULL, NULL, NULL, NULL, 1, 43, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (60, N'cards_basics', NULL, NULL, NULL, NULL, NULL, 1, 44, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (61, N'shippingCompany_basics', NULL, NULL, NULL, NULL, NULL, 1, 45, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (63, N'reports', NULL, NULL, NULL, NULL, NULL, 1, NULL, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (65, N'ordersAccounting', NULL, NULL, NULL, NULL, NULL, 1, 5, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (67, N'salesOrders', NULL, NULL, NULL, NULL, NULL, 1, 4, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (68, N'salesReports', NULL, NULL, NULL, NULL, NULL, 1, 63, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (69, N'purchaseReports', NULL, NULL, NULL, NULL, NULL, 1, 63, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (70, N'storageReports', NULL, NULL, NULL, NULL, NULL, 1, 63, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (71, N'accountsReports', NULL, NULL, NULL, NULL, NULL, 1, 63, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (72, N'usersReports', NULL, NULL, NULL, NULL, NULL, 1, 63, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (74, N'categories_basics', N'', NULL, NULL, NULL, NULL, 1, 9, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (75, N'item_basics', N'', NULL, NULL, NULL, NULL, 1, 10, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (76, N'properties_basics', N'', NULL, NULL, NULL, NULL, 1, 11, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (77, N'units_basics', N'', NULL, NULL, NULL, NULL, 1, 12, N'all')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (78, N'general_usersSettings', N'', NULL, NULL, NULL, NULL, 1, 46, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (79, N'general_companySettings', N'', NULL, NULL, NULL, NULL, 1, 46, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (80, N'reports_settings', N'', NULL, NULL, NULL, NULL, 1, 47, N'one')
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
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (96, N'inventory_createInventory', N'', NULL, NULL, NULL, NULL, 1, 19, N'one')
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
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (152, N'purchaseOrder', NULL, NULL, NULL, NULL, NULL, 1, 3, N'basic')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (153, N'purchaseOrder_create', N'', NULL, NULL, NULL, NULL, 1, 152, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (154, N'purchaseOrder_reports', N'', NULL, NULL, NULL, NULL, 1, 152, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (155, N'importExport_package', N'', NULL, NULL, NULL, NULL, 1, 17, N'one')
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (156, N'importExport_unitConversion', N'', NULL, NULL, NULL, NULL, 1, 17, N'one')
SET IDENTITY_INSERT [dbo].[objects] OFF
GO
SET IDENTITY_INSERT [dbo].[offers] ON 

INSERT [dbo].[offers] ([offerId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (1, N'عرض ايفون بمليون', N'offerM', 1, N'1', CAST(200000.00 AS Decimal(20, 2)), CAST(N'2021-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-07-31T23:59:00.0000000' AS DateTime2), NULL, NULL, 2, NULL, N'')
INSERT [dbo].[offers] ([offerId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (2, N'عرض 5', N'5100', 1, N'2', CAST(5.00 AS Decimal(20, 2)), CAST(N'2021-07-01T01:00:00.0000000' AS DateTime2), CAST(N'2022-07-30T01:00:00.0000000' AS DateTime2), NULL, NULL, 9, NULL, N'')
SET IDENTITY_INSERT [dbo].[offers] OFF
GO
SET IDENTITY_INSERT [dbo].[packages] ON 

INSERT [dbo].[packages] ([packageId], [parentIUId], [childIUId], [quantity], [isActive], [notes], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (18, 15, 12, 12, 1, N'باراسيتامول -عنصر', 3, 3, NULL, CAST(N'2021-07-17T13:11:39.6911850' AS DateTime2))
INSERT [dbo].[packages] ([packageId], [parentIUId], [childIUId], [quantity], [isActive], [notes], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (19, 15, 7, 3, 1, N'بروفين -علبة', 3, 3, NULL, CAST(N'2021-07-17T13:11:39.6911850' AS DateTime2))
INSERT [dbo].[packages] ([packageId], [parentIUId], [childIUId], [quantity], [isActive], [notes], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (20, 15, 11, 2, 1, N'باراسيتامول -علبة', 3, 3, NULL, CAST(N'2021-07-17T13:11:39.6911850' AS DateTime2))
INSERT [dbo].[packages] ([packageId], [parentIUId], [childIUId], [quantity], [isActive], [notes], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (21, 15, 1, 12, 1, N'barcode scanner-صندوق', 3, 3, NULL, CAST(N'2021-07-17T13:11:39.6911850' AS DateTime2))
INSERT [dbo].[packages] ([packageId], [parentIUId], [childIUId], [quantity], [isActive], [notes], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (22, 15, 2, 5, 1, N'barcode scanner-كرتونة', 3, 3, NULL, CAST(N'2021-07-17T13:11:39.6911850' AS DateTime2))
INSERT [dbo].[packages] ([packageId], [parentIUId], [childIUId], [quantity], [isActive], [notes], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (23, 15, 6, 2, 1, N'Iphone 11-عنصر', 3, 3, NULL, CAST(N'2021-07-17T13:11:39.6911850' AS DateTime2))
INSERT [dbo].[packages] ([packageId], [parentIUId], [childIUId], [quantity], [isActive], [notes], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (24, 15, 10, 12, 1, N'الأسبرين -عنصر', 3, 3, NULL, CAST(N'2021-07-17T13:11:39.6911850' AS DateTime2))
SET IDENTITY_INSERT [dbo].[packages] OFF
GO
SET IDENTITY_INSERT [dbo].[pos] ON 

INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (1, N'Al-JM-B-POS-1', N'POS-1', CAST(0.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:51:49.0366461' AS DateTime2), CAST(N'2021-06-29T16:51:49.0366461' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (2, N'Al-JM-B-POS-2', N'POS-2', CAST(1150252526.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:52:00.6122040' AS DateTime2), CAST(N'2021-08-03T14:36:44.8886678' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (3, N'Al-JM-B-POS-3', N'POS-3', CAST(44410.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:52:12.7045399' AS DateTime2), CAST(N'2021-07-18T14:45:32.4827301' AS DateTime2), 1, 1, 1, N'', CAST(100000.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (4, N'Al-JM-B-POS-4', N'POS-4', CAST(0.00 AS Decimal(20, 2)), 3, CAST(N'2021-06-29T16:52:24.9776657' AS DateTime2), CAST(N'2021-06-29T16:52:24.9776657' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (5, N'Al-JM-B-POS-5', N'POS-5', CAST(0.00 AS Decimal(20, 2)), 3, CAST(N'2021-06-29T16:52:34.7838816' AS DateTime2), CAST(N'2021-06-29T16:52:34.7838816' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (6, N'Al-JM-B-POS-6', N'POS-6', CAST(0.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:52:47.6503734' AS DateTime2), CAST(N'2021-06-29T16:52:47.6503734' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (7, N'Al-JM-B-POS-7', N'POS-7', CAST(0.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:52:56.7213024' AS DateTime2), CAST(N'2021-06-29T16:52:56.7213024' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (8, N'Al-JM-B-POS-8', N'POS-8', CAST(0.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:53:15.5931410' AS DateTime2), CAST(N'2021-06-29T16:53:15.5931410' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (9, N'Al-FK-B-POS-1', N'POS-1', CAST(0.00 AS Decimal(20, 2)), 3, CAST(N'2021-06-29T16:53:31.2314166' AS DateTime2), CAST(N'2021-06-29T16:53:31.2314166' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (10, N'Al-FK-B-POS-2', N'POS-2', CAST(0.00 AS Decimal(20, 2)), 3, CAST(N'2021-06-29T16:53:43.3120745' AS DateTime2), CAST(N'2021-06-29T16:53:43.3120745' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (11, N'Al-FK-B-POS-3', N'POS-3', CAST(0.00 AS Decimal(20, 2)), 3, CAST(N'2021-06-29T16:54:04.8285713' AS DateTime2), CAST(N'2021-06-29T16:54:04.8285713' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (12, N'Al-FK-B-POS-4', N'POS-4', CAST(0.00 AS Decimal(20, 2)), 3, CAST(N'2021-06-29T16:54:24.1639502' AS DateTime2), CAST(N'2021-06-29T16:54:24.1639502' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (13, N'Al-FK-B-POS-5', N'POS-5', CAST(0.00 AS Decimal(20, 2)), 3, CAST(N'2021-06-29T16:54:33.1411948' AS DateTime2), CAST(N'2021-06-29T16:54:33.1411948' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (14, N'Al-AD-B-POS-1', N'POS-1', CAST(0.00 AS Decimal(20, 2)), 4, CAST(N'2021-06-29T16:54:45.9819243' AS DateTime2), CAST(N'2021-06-29T16:54:45.9819243' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (15, N'Al-AD-B-POS-2', N'POS-2', CAST(0.00 AS Decimal(20, 2)), 4, CAST(N'2021-06-29T16:55:04.0642268' AS DateTime2), CAST(N'2021-06-29T16:55:04.0642268' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (16, N'Al-AD-B-POS-3', N'POS-3', CAST(0.00 AS Decimal(20, 2)), 4, CAST(N'2021-06-29T16:55:18.8647255' AS DateTime2), CAST(N'2021-06-29T16:55:18.8647255' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (17, N'Al-AD-B-POS-4', N'POS-4', CAST(0.00 AS Decimal(20, 2)), 4, CAST(N'2021-06-29T16:55:45.0261811' AS DateTime2), CAST(N'2021-06-29T16:55:45.0261811' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (18, N'Al-AD-B-POS-5', N'POS-5', CAST(0.00 AS Decimal(20, 2)), 4, CAST(N'2021-06-29T16:56:02.5499135' AS DateTime2), CAST(N'2021-06-29T16:56:02.5499135' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (19, N'Al-JF-S-POS-1', N'POS-1', CAST(0.00 AS Decimal(20, 2)), 12, CAST(N'2021-06-29T17:07:11.8491483' AS DateTime2), CAST(N'2021-06-29T17:07:11.8491483' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (20, N'Al-JF-S-POS-2', N'POS-2', CAST(0.00 AS Decimal(20, 2)), 12, CAST(N'2021-06-29T17:09:33.0600271' AS DateTime2), CAST(N'2021-06-29T17:09:33.0600271' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (22, N'Al-FA-S-POS-1', N'POS-1', CAST(0.00 AS Decimal(20, 2)), 13, CAST(N'2021-06-29T17:10:13.8441442' AS DateTime2), CAST(N'2021-06-29T17:10:48.5201089' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (23, N'Al-JM-S-POS-1', N'POS-1', CAST(0.00 AS Decimal(20, 2)), 10, CAST(N'2021-06-29T17:10:13.8441442' AS DateTime2), CAST(N'2021-06-29T17:10:48.5201089' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (24, N'DM-CE-B-POS-1', N'POS-1', CAST(1323300.00 AS Decimal(20, 2)), 5, CAST(N'2021-07-15T15:46:28.7313439' AS DateTime2), CAST(N'2021-07-18T16:39:11.6686139' AS DateTime2), 9, 9, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (26, N'POS-8', N'test', CAST(0.00 AS Decimal(20, 2)), 4, CAST(N'2021-07-18T11:25:49.7338167' AS DateTime2), CAST(N'2021-07-18T11:25:49.7338167' AS DateTime2), 3, 3, 1, N'', CAST(0.00 AS Decimal(20, 2)))
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
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (18, N'الكترونيات', CAST(N'2021-07-10T16:04:21.2507398' AS DateTime2), CAST(N'2021-07-10T16:04:21.2507398' AS DateTime2), 1, 1, 12, 1, N'', NULL)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (19, N'طبية', CAST(N'2021-07-11T12:25:38.8254364' AS DateTime2), CAST(N'2021-07-11T12:25:38.8254364' AS DateTime2), 2, 2, 2, 1, N'', NULL)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (20, N'تقني', CAST(N'2021-07-11T13:09:40.4234229' AS DateTime2), CAST(N'2021-07-11T13:09:40.4234229' AS DateTime2), 2, 2, 2, 1, N'', NULL)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (21, N'Electronic', CAST(N'2021-07-12T18:39:50.8494624' AS DateTime2), CAST(N'2021-07-12T18:39:50.8494624' AS DateTime2), 9, 9, 10, 1, N'', NULL)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (22, N'جوال', CAST(N'2021-07-15T16:28:15.2494103' AS DateTime2), CAST(N'2021-07-15T16:28:15.2494103' AS DateTime2), 2, 2, 5, 1, N'', NULL)
SET IDENTITY_INSERT [dbo].[sections] OFF
GO
SET IDENTITY_INSERT [dbo].[serials] ON 

INSERT [dbo].[serials] ([serialId], [itemId], [serialNum], [isActive], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (1, 22, N'A123', 1, CAST(N'2021-07-12T15:47:54.2615800' AS DateTime2), CAST(N'2021-07-12T15:47:54.2615800' AS DateTime2), NULL, NULL)
INSERT [dbo].[serials] ([serialId], [itemId], [serialNum], [isActive], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (2, 22, N'A258', 1, CAST(N'2021-07-12T15:48:10.7511645' AS DateTime2), CAST(N'2021-07-12T15:48:10.7511645' AS DateTime2), NULL, NULL)
INSERT [dbo].[serials] ([serialId], [itemId], [serialNum], [isActive], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (3, 22, N'A300', 1, CAST(N'2021-07-12T15:49:48.3873095' AS DateTime2), CAST(N'2021-07-12T15:49:48.3873095' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[serials] OFF
GO
SET IDENTITY_INSERT [dbo].[servicesCosts] ON 

INSERT [dbo].[servicesCosts] ([costId], [name], [costVal], [itemId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (1, N'برنامج كامل', CAST(1000000.00 AS Decimal(20, 2)), 8, CAST(N'2021-07-01T14:41:32.2618746' AS DateTime2), CAST(N'2021-07-01T14:41:42.3937853' AS DateTime2), 1, 1)
INSERT [dbo].[servicesCosts] ([costId], [name], [costVal], [itemId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (2, N'صيانة', CAST(10000.00 AS Decimal(20, 2)), 8, CAST(N'2021-07-01T14:41:55.7959418' AS DateTime2), CAST(N'2021-07-01T14:41:55.7959418' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[servicesCosts] OFF
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
SET IDENTITY_INSERT [dbo].[setting] OFF
GO
SET IDENTITY_INSERT [dbo].[setValues] ON 

INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (1, N'en', NULL, NULL, NULL, 9)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (2, N'ar', NULL, NULL, NULL, 9)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (3, N'Increase', 1, 1, NULL, 1)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (4, N'Kuwait', 1, 1, NULL, 2)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (5, N'info@Increase.com', 1, 1, NULL, 3)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (6, N'+965-098765489', 1, 1, NULL, 4)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (7, N'+965--52333333242342', 1, 1, NULL, 5)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (8, N'+965-31-54433222423423', 1, 1, NULL, 6)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (12, N'5', 1, 1, NULL, 11)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (13, N'2000', 1, 1, NULL, 12)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (14, N'ad4bfd50185ef68bce2b903aa7e10ec0.png', 1, 1, N'', 7)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (15, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[setValues] OFF
GO
SET IDENTITY_INSERT [dbo].[shippingCompanies] ON 

INSERT [dbo].[shippingCompanies] ([shippingCompanyId], [name], [RealDeliveryCost], [deliveryCost], [deliveryType], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [balance], [balanceType]) VALUES (1, N'name      ', CAST(112.00 AS Decimal(20, 2)), CAST(115.00 AS Decimal(20, 2)), N'local', N'notes', CAST(N'2021-07-29T15:12:02.4328432' AS DateTime2), CAST(N'2021-07-29T15:12:02.4328432' AS DateTime2), 2, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL)
INSERT [dbo].[shippingCompanies] ([shippingCompanyId], [name], [RealDeliveryCost], [deliveryCost], [deliveryType], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [balance], [balanceType]) VALUES (2, N'smsa      ', CAST(112.00 AS Decimal(20, 2)), CAST(115.00 AS Decimal(20, 2)), N'com', N'notes', CAST(N'2021-07-29T15:12:33.0786920' AS DateTime2), CAST(N'2021-07-29T15:12:33.0786920' AS DateTime2), 2, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL)
INSERT [dbo].[shippingCompanies] ([shippingCompanyId], [name], [RealDeliveryCost], [deliveryCost], [deliveryType], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [balance], [balanceType]) VALUES (4, N'name      ', CAST(12000.00 AS Decimal(20, 2)), CAST(15000.00 AS Decimal(20, 2)), N'local', N'notes', CAST(N'2021-07-29T15:22:09.2733507' AS DateTime2), CAST(N'2021-07-29T15:22:09.2733507' AS DateTime2), 2, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL)
SET IDENTITY_INSERT [dbo].[shippingCompanies] OFF
GO
SET IDENTITY_INSERT [dbo].[storageCost] ON 

INSERT [dbo].[storageCost] ([storageCostId], [name], [cost], [note], [isActive], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (1, N'كرتونة صغيرة جداً', CAST(0.01 AS Decimal(20, 2)), N'', 1, 2, 2, CAST(N'2021-07-25T11:01:57.4320405' AS DateTime2), CAST(N'2021-07-25T11:02:53.4060243' AS DateTime2))
INSERT [dbo].[storageCost] ([storageCostId], [name], [cost], [note], [isActive], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (2, N'كرتونة وسط', CAST(0.05 AS Decimal(20, 2)), N'', 1, 2, 2, CAST(N'2021-07-25T11:03:28.3456869' AS DateTime2), CAST(N'2021-07-25T11:03:28.3456869' AS DateTime2))
INSERT [dbo].[storageCost] ([storageCostId], [name], [cost], [note], [isActive], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (3, N'كرتونة كبيرة', CAST(0.10 AS Decimal(20, 2)), N'', 1, 2, 2, CAST(N'2021-07-25T11:03:57.5559213' AS DateTime2), CAST(N'2021-07-25T11:03:57.5559213' AS DateTime2))
INSERT [dbo].[storageCost] ([storageCostId], [name], [cost], [note], [isActive], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (4, N'كرتونة كبيرة جداً', CAST(1.00 AS Decimal(20, 2)), N'', 1, 2, 2, CAST(N'2021-07-25T11:04:37.0354778' AS DateTime2), CAST(N'2021-07-25T11:04:37.0354778' AS DateTime2))
SET IDENTITY_INSERT [dbo].[storageCost] OFF
GO
SET IDENTITY_INSERT [dbo].[sysEmails] ON 

INSERT [dbo].[sysEmails] ([emailId], [name], [email], [password], [port], [isSSL], [smtpClient], [side], [notes], [branchId], [isActive], [createUserId], [updateUserId], [createDate], [updateDate], [isMajor]) VALUES (4, N'info', N'wseetw@gmail.com', N'MjE0YTE5NjBh', 587, 1, N'smtp.gmail.com', N'if', N'', 2, 1, 9, 2, CAST(N'2021-07-26T18:45:00.9858489' AS DateTime2), CAST(N'2021-07-27T15:20:04.9590026' AS DateTime2), 1)
INSERT [dbo].[sysEmails] ([emailId], [name], [email], [password], [port], [isSSL], [smtpClient], [side], [notes], [branchId], [isActive], [createUserId], [updateUserId], [createDate], [updateDate], [isMajor]) VALUES (5, N'manager', N'wseetw@gmail.com', N'MjE0YTE5NjBh', 587, 1, N'smtp.gmail.com', N'mg', N'', 2, 1, 9, 9, CAST(N'2021-08-04T11:13:08.9508371' AS DateTime2), CAST(N'2021-08-04T11:13:08.9508371' AS DateTime2), 1)
INSERT [dbo].[sysEmails] ([emailId], [name], [email], [password], [port], [isSSL], [smtpClient], [side], [notes], [branchId], [isActive], [createUserId], [updateUserId], [createDate], [updateDate], [isMajor]) VALUES (6, N'manager', N'wseetw@gmail.com', N'MjE0YTE5NjBh', 587, 1, N'smtp.gmail.com', N'md', N'', 2, 1, 9, 9, CAST(N'2021-08-04T11:13:34.9727936' AS DateTime2), CAST(N'2021-08-04T11:13:34.9727936' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[sysEmails] OFF
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
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (11, N'package', NULL, NULL, CAST(N'2021-07-15T11:59:52.5435356' AS DateTime2), 3, 3, CAST(N'2021-07-15T11:59:52.5435356' AS DateTime2), NULL, 1, N'package notes')
INSERT [dbo].[units] ([unitId], [name], [isSmallest], [smallestId], [createDate], [createUserId], [updateUserId], [updateDate], [parentid], [isActive], [notes]) VALUES (12, N'درزن', NULL, NULL, CAST(N'2021-07-18T18:54:09.5320892' AS DateTime2), 1, 1, CAST(N'2021-07-18T18:54:09.5320892' AS DateTime2), NULL, 1, N'بب')
SET IDENTITY_INSERT [dbo].[units] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (1, N'admin', N'1b8baf4f819e5b304e1a176e1c590c84', N'Mohammad', N'Nasani', N'System Admin', N'12', CAST(N'2021-06-28T18:38:45.0434248' AS DateTime2), CAST(N'2021-08-04T10:22:43.8337805' AS DateTime2), 2, 2, N'+963-21-2278910', N'+963-966376308', N'mohamadnasani@gmail.com', N'Halab', 1, N'', 1, N'', N'57440ff6b80f068efd50410ea24fd593.jpg', 17, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (2, N'yasin', N'6714523532b49462e549ebb6b334b034', N'ياسين', N'ادلبي', N'محاسب', N'8', CAST(N'2021-06-30T11:05:51.9137655' AS DateTime2), CAST(N'2021-08-03T18:32:35.1915360' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'c37858823db0093766eee74d8ee1f1e5.png', 17, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (3, N'yasmine', N'4cdf921bfe31b594a0cc9cc555292f02', N'ياسمين', N'النجار', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:17:13.6368587' AS DateTime2), CAST(N'2021-08-03T14:31:16.8377248' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'71f020248a405d21e94d1de52043bed4.jpg', 17, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (4, N'bonni', N'494e167fd30bf2a244c8fcda0220aa89', N'محمد', N'بني', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:17:38.6309662' AS DateTime2), CAST(N'2021-08-03T16:42:39.7139201' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'd2ec5f1ed83abfca0dfec76506b696b3.png', 17, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (5, N'olwani', N'7ae94a254e28a0e9a575e9669fed5684', N'محمد', N'علواني', N'مدير مشتريات', N'8', CAST(N'2021-06-30T11:23:59.5926231' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'f96f8a89e2143f1e43a2ba7953fb5413.png', 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (6, N'amna', N'78fe84643f9a617ac5800771a1c3c5e9', N'آمنة', N'سعدات', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:24:56.0475272' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'56a2e0231c3d394ace201adf37d13f63.png', 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (7, N'basmah', N'210db3affbee2bdeb82872a7f42a970f', N'باسمة', N'قدري', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:25:40.3004312' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'3204215c19f25609034d24451f7e03d7.png', 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (8, N'bik', N'e2a603fb361ecb7b2fc6791f98382580', N'محمد', N'بيك', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:26:56.9568520' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'6a5d62c1233b5e9b2000dd13aadf81f4.png', 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (9, N'naji', N'741e82719da67d8744fd797194aa65b0', N'ناجي', N'مصري', N'مدير', N'8', CAST(N'2021-06-30T11:40:59.4646248' AS DateTime2), CAST(N'2021-08-04T11:08:29.7899849' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'6eaba1dc3c031faf262149c058fea728.png', 17, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (10, N'gammal', N'93f8a85e591d4c7d7bb32a1c2ded5f49', N'جمال', N'عثمان', N'محاسب', N'8', CAST(N'2021-06-30T11:41:40.3141978' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'0f26776e0a524c7d2b6b5f771d500980.png', 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (11, N'samer', N'88bc4525060f0e96bf15392785fc0bc9', N'سامر', N'المصري', N'امين مستودع', N'8', CAST(N'2021-06-30T11:42:42.2388711' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'05da7ccc8020731d607471318fc4f35b.png', 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (12, N'esmaeil', N'b52c7f50ba2f865399e5838e87e4db6c', N'اسماعيل', N'امجد', N'مدير مشتريات', N'8', CAST(N'2021-06-30T11:43:05.8054749' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'0731f29a7d8c55ddab810a076d078aff.png', 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (13, N'fatema', N'd8fe177d106f727da83452e72ed6cc52', N'فاطمة', N'خالد', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:43:27.8574569' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (14, N'aya', N'9b43a5e653134fc8350ca9944eadaf2f', N'آية', N'سليمان', N'مدير', N'8', CAST(N'2021-06-30T11:43:48.7387915' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (15, N'somaya', N'bd1872d1a3f8b6ac8ea1801d78500716', N'سمية', N'محمد', N'محاسب', N'8', CAST(N'2021-06-30T11:44:27.3588024' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (16, N'samerah', N'1fb05f350e1272d0fcf5023cd08b0c78', N'سميرة', N'المحجوب', N'امين مستودع', N'8', CAST(N'2021-06-30T11:45:13.9722914' AS DateTime2), CAST(N'2021-06-30T11:45:13.9722914' AS DateTime2), 1, 1, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (17, N'sawsan', N'4e08511679204a2c1056e96feafd9a98', N'سوسن', N'الأحمد', N'مدير مشتريات', N'8', CAST(N'2021-06-30T11:45:52.9176913' AS DateTime2), CAST(N'2021-06-30T11:45:52.9176913' AS DateTime2), 1, 1, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (18, N'sara', N'7202807332047589fa409179963a9c04', N'سارة', N'علي', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:47:13.0378597' AS DateTime2), CAST(N'2021-06-30T11:47:13.0378597' AS DateTime2), 1, 1, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (19, N'dina', N'513866157bae565e9e3bc02a1ca05e9d', N'دينا', N'نعمة', N'امين مستودع', N'8', CAST(N'2021-06-30T11:48:15.5604312' AS DateTime2), CAST(N'2021-07-27T15:05:09.6356859' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, 17, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (20, N'sabbagh', N'1a45d82222dab4a597537f85b7dacfe1', N'أحمد', N'صباغ', N'مساعد امين مستودع', N'8', CAST(N'2021-06-30T11:48:46.0905677' AS DateTime2), CAST(N'2021-06-30T11:48:46.0905677' AS DateTime2), 1, 1, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (21, N'saeed', N'1e920a928a6be4ea6fa634e7fa3f048b', N'سعيد', N'قطان', N'امين مستودع', N'8', CAST(N'2021-06-30T11:49:06.2421502' AS DateTime2), CAST(N'2021-06-30T11:49:06.2421502' AS DateTime2), 1, 1, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (25, N'admin2', N'340b7543dcfa9407abd62b33887a9251', N'Mohammad', N'Nasani', N'System Admin', N'12', CAST(N'2021-07-18T10:33:41.2293103' AS DateTime2), CAST(N'2021-07-31T20:45:29.3549369' AS DateTime2), 2, 2, N'+963-21-2278910', N'+963-966376308', N'mohamadnasani@gmail.com', N'Halab', 1, N'', 1, N'', N'16008f81a32dddded32b87f4a2cd9ca7.png', 14, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (26, N'admin3', N'05c9ef186781449687aed7a0710118a6', N'Mohammad', N'Nasani', N'System Admin', N'12', CAST(N'2021-07-18T10:33:53.3385310' AS DateTime2), CAST(N'2021-07-31T20:46:01.2926515' AS DateTime2), 2, 2, N'+963-21-2278910', N'+963-966376308', N'mohamadnasani@gmail.com', N'Halab', 1, N'', 1, N'', N'16008f81a32dddded32b87f4a2cd9ca7.png', 15, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (27, N'admin4', N'1ac18407b4727f4f6a3cd8ede3b8ed3a', N'Mohammad', N'Nasani', N'System Admin', N'12', CAST(N'2021-07-18T10:35:08.0113579' AS DateTime2), CAST(N'2021-07-19T01:54:20.1886333' AS DateTime2), 2, 2, N'+968--2278910', N'+968-966376308', N'mohamadnasani@gmail.com', N'Halab', 1, N'', 1, N'', N'16008f81a32dddded32b87f4a2cd9ca7.png', 16, CAST(0.00 AS Decimal(20, 2)), 0)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
SET IDENTITY_INSERT [dbo].[userSetValues] ON 

INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (6, 3, 2, NULL, CAST(N'2021-07-10T13:43:33.1472761' AS DateTime2), CAST(N'2021-07-14T12:45:13.2937637' AS DateTime2), 3, 3)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (7, 9, 1, N'thisis', CAST(N'2021-07-10T14:23:23.5064125' AS DateTime2), CAST(N'2021-07-10T14:23:23.5064125' AS DateTime2), 9, 9)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (8, 4, 1, NULL, CAST(N'2021-07-12T10:29:19.2071006' AS DateTime2), CAST(N'2021-07-12T10:29:19.2071006' AS DateTime2), 4, 4)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (9, 2, 2, NULL, CAST(N'2021-07-12T17:06:47.4146813' AS DateTime2), CAST(N'2021-07-12T17:09:45.4157961' AS DateTime2), 2, 2)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (10, 1, 1, NULL, CAST(N'2021-07-24T10:58:03.7729709' AS DateTime2), CAST(N'2021-07-31T21:00:20.9283513' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[userSetValues] OFF
GO
SET IDENTITY_INSERT [dbo].[usersLogs] ON 

INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2584, CAST(N'2021-07-28T16:26:56.9715504' AS DateTime2), CAST(N'2021-07-28T16:34:17.3701945' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2590, CAST(N'2021-07-28T16:49:59.4835176' AS DateTime2), CAST(N'2021-07-28T16:50:36.3146349' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2591, CAST(N'2021-07-28T16:52:41.1418618' AS DateTime2), CAST(N'2021-07-29T15:02:06.8140842' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2592, CAST(N'2021-07-28T16:59:42.5935772' AS DateTime2), CAST(N'2021-07-29T15:02:06.8162234' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2593, CAST(N'2021-07-28T17:01:29.2288743' AS DateTime2), CAST(N'2021-07-29T15:02:06.8188506' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2594, CAST(N'2021-07-28T17:10:52.7025250' AS DateTime2), CAST(N'2021-07-29T15:02:06.8199337' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2595, CAST(N'2021-07-28T17:11:42.3453514' AS DateTime2), CAST(N'2021-07-29T15:30:00.5179708' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2596, CAST(N'2021-07-28T17:11:50.4495483' AS DateTime2), CAST(N'2021-07-29T15:02:06.8220486' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2597, CAST(N'2021-07-28T17:15:14.7847460' AS DateTime2), CAST(N'2021-07-28T17:15:42.7728186' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2598, CAST(N'2021-07-28T17:18:17.2017828' AS DateTime2), CAST(N'2021-07-28T17:18:47.3330804' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2599, CAST(N'2021-07-28T17:22:59.1990424' AS DateTime2), CAST(N'2021-07-28T17:28:41.3122697' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2600, CAST(N'2021-07-28T17:31:19.6905204' AS DateTime2), CAST(N'2021-07-29T15:30:00.5208966' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2601, CAST(N'2021-07-28T17:32:50.3482713' AS DateTime2), CAST(N'2021-07-29T15:30:00.5230374' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2602, CAST(N'2021-07-28T17:37:00.1330458' AS DateTime2), CAST(N'2021-07-28T17:57:00.9438434' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2603, CAST(N'2021-07-28T17:44:15.1224186' AS DateTime2), CAST(N'2021-07-29T15:30:00.5246579' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2604, CAST(N'2021-07-28T17:45:39.0139071' AS DateTime2), CAST(N'2021-07-29T15:02:06.8236546' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2605, CAST(N'2021-07-28T17:46:26.8115362' AS DateTime2), CAST(N'2021-07-29T15:02:06.8247097' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2606, CAST(N'2021-07-28T17:47:29.3121246' AS DateTime2), CAST(N'2021-07-29T15:02:06.8268172' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2607, CAST(N'2021-07-28T17:48:34.5005772' AS DateTime2), CAST(N'2021-07-29T15:02:06.8278619' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2608, CAST(N'2021-07-28T17:50:44.9238764' AS DateTime2), CAST(N'2021-07-28T17:53:51.1759398' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2609, CAST(N'2021-07-28T17:51:27.3929623' AS DateTime2), CAST(N'2021-07-29T15:30:00.5267900' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2610, CAST(N'2021-07-28T17:54:01.5045229' AS DateTime2), CAST(N'2021-07-29T15:30:00.5284129' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2611, CAST(N'2021-07-28T17:54:21.5200531' AS DateTime2), CAST(N'2021-07-29T15:30:00.5306459' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2612, CAST(N'2021-07-28T17:56:57.4908522' AS DateTime2), CAST(N'2021-07-29T14:41:23.6391072' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2613, CAST(N'2021-07-28T17:57:33.6315884' AS DateTime2), CAST(N'2021-07-29T14:41:23.6412557' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2614, CAST(N'2021-07-28T17:58:00.1163709' AS DateTime2), CAST(N'2021-07-28T17:59:14.7266638' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2615, CAST(N'2021-07-28T17:59:57.7428075' AS DateTime2), CAST(N'2021-07-29T14:41:23.6429002' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2616, CAST(N'2021-07-28T18:03:45.3863391' AS DateTime2), CAST(N'2021-07-29T14:41:23.6449806' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2617, CAST(N'2021-07-28T18:07:11.2956383' AS DateTime2), CAST(N'2021-07-28T18:08:53.6095343' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2618, CAST(N'2021-07-28T18:12:23.3308054' AS DateTime2), CAST(N'2021-07-28T18:13:33.8315916' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2619, CAST(N'2021-07-28T18:14:06.9414148' AS DateTime2), CAST(N'2021-07-29T14:41:23.6460471' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2620, CAST(N'2021-07-29T00:22:08.1996028' AS DateTime2), CAST(N'2021-07-29T00:27:06.1561071' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2621, CAST(N'2021-07-29T09:39:24.6596771' AS DateTime2), CAST(N'2021-07-29T09:44:25.8192316' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2622, CAST(N'2021-07-29T09:49:34.2445341' AS DateTime2), CAST(N'2021-07-29T15:30:00.5316941' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2623, CAST(N'2021-07-29T09:51:18.0112630' AS DateTime2), CAST(N'2021-07-29T09:54:40.2482414' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2624, CAST(N'2021-07-29T10:13:00.5572384' AS DateTime2), CAST(N'2021-07-29T10:14:30.7611591' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2625, CAST(N'2021-07-29T10:16:03.5435039' AS DateTime2), CAST(N'2021-07-31T15:28:54.3643138' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2626, CAST(N'2021-07-29T10:18:07.1073359' AS DateTime2), CAST(N'2021-07-29T10:20:36.9995911' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2627, CAST(N'2021-07-29T10:24:03.2360943' AS DateTime2), CAST(N'2021-07-29T10:25:19.9717081' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2628, CAST(N'2021-07-29T10:25:11.0805041' AS DateTime2), CAST(N'2021-07-29T15:02:06.8299779' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2629, CAST(N'2021-07-29T10:27:07.4257471' AS DateTime2), CAST(N'2021-07-29T10:32:55.4298291' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2630, CAST(N'2021-07-29T10:30:45.6313391' AS DateTime2), CAST(N'2021-07-29T10:31:40.3508726' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2631, CAST(N'2021-07-29T10:34:00.8682584' AS DateTime2), CAST(N'2021-07-29T10:34:34.0088990' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2632, CAST(N'2021-07-29T10:35:44.2754361' AS DateTime2), CAST(N'2021-07-29T10:36:19.6036181' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2633, CAST(N'2021-07-29T10:36:49.9168258' AS DateTime2), CAST(N'2021-07-29T10:37:43.3389163' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2634, CAST(N'2021-07-29T10:37:57.1519677' AS DateTime2), CAST(N'2021-07-29T10:38:32.5115511' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2635, CAST(N'2021-07-29T10:39:15.2152396' AS DateTime2), CAST(N'2021-07-29T15:02:06.8315997' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2636, CAST(N'2021-07-29T10:42:43.4520243' AS DateTime2), CAST(N'2021-07-29T15:02:06.8337104' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2637, CAST(N'2021-07-29T10:45:03.7345800' AS DateTime2), CAST(N'2021-07-29T15:02:06.8347354' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2638, CAST(N'2021-07-29T10:46:29.2042595' AS DateTime2), CAST(N'2021-07-29T10:47:18.8613965' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2639, CAST(N'2021-07-29T10:46:51.2671935' AS DateTime2), CAST(N'2021-07-29T10:47:27.3925508' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2640, CAST(N'2021-07-29T10:49:14.7375354' AS DateTime2), CAST(N'2021-07-29T10:50:14.4412897' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2641, CAST(N'2021-07-29T10:51:14.8325141' AS DateTime2), CAST(N'2021-07-29T11:00:47.6048699' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2642, CAST(N'2021-07-29T11:01:53.2457932' AS DateTime2), CAST(N'2021-07-29T11:03:51.1043164' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2643, CAST(N'2021-07-29T11:14:13.8095960' AS DateTime2), CAST(N'2021-08-01T11:13:39.6314905' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2644, CAST(N'2021-07-29T11:14:44.9103887' AS DateTime2), CAST(N'2021-07-29T11:16:14.6769835' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2645, CAST(N'2021-07-29T11:20:28.9924670' AS DateTime2), CAST(N'2021-07-29T11:21:38.4304899' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2646, CAST(N'2021-07-29T11:22:21.9624659' AS DateTime2), CAST(N'2021-07-31T15:28:54.3643138' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2647, CAST(N'2021-07-29T11:22:52.4938982' AS DateTime2), CAST(N'2021-08-01T11:13:39.6314905' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2648, CAST(N'2021-07-29T11:24:10.7605944' AS DateTime2), CAST(N'2021-08-01T11:13:39.6314905' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2649, CAST(N'2021-07-29T11:24:36.9953208' AS DateTime2), CAST(N'2021-07-29T11:25:06.4019850' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2650, CAST(N'2021-07-29T11:25:57.9022471' AS DateTime2), CAST(N'2021-07-29T11:28:04.5602273' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2651, CAST(N'2021-07-29T11:26:20.7151544' AS DateTime2), CAST(N'2021-08-01T11:13:39.6314905' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2652, CAST(N'2021-07-29T11:27:43.5755182' AS DateTime2), CAST(N'2021-07-29T15:30:00.5343836' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2653, CAST(N'2021-07-29T11:28:49.1700023' AS DateTime2), CAST(N'2021-07-29T11:42:51.4300261' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2654, CAST(N'2021-07-29T11:29:21.8264417' AS DateTime2), CAST(N'2021-07-29T11:30:44.1557838' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2655, CAST(N'2021-07-29T11:30:21.6240507' AS DateTime2), CAST(N'2021-07-29T11:33:29.7043445' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2656, CAST(N'2021-07-29T11:30:36.7179445' AS DateTime2), CAST(N'2021-07-29T11:32:29.1256433' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2657, CAST(N'2021-07-29T11:35:00.3616684' AS DateTime2), CAST(N'2021-07-29T15:30:00.5354230' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2658, CAST(N'2021-07-29T11:35:59.4717928' AS DateTime2), CAST(N'2021-07-29T11:37:05.5973651' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2659, CAST(N'2021-07-29T11:36:01.9719517' AS DateTime2), CAST(N'2021-07-29T11:40:53.5532966' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2660, CAST(N'2021-07-29T11:37:48.5979946' AS DateTime2), CAST(N'2021-07-29T11:52:50.6085977' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2661, CAST(N'2021-07-29T11:40:44.8971163' AS DateTime2), CAST(N'2021-07-29T11:53:14.3590476' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2662, CAST(N'2021-07-29T11:43:43.6961105' AS DateTime2), CAST(N'2021-07-29T11:45:37.1347507' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2663, CAST(N'2021-07-29T11:47:14.9171961' AS DateTime2), CAST(N'2021-07-29T11:50:58.9043648' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2664, CAST(N'2021-07-29T11:51:00.2013322' AS DateTime2), CAST(N'2021-07-29T11:52:35.1552851' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2665, CAST(N'2021-07-29T11:51:07.0606075' AS DateTime2), CAST(N'2021-07-29T11:59:02.0223498' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2666, CAST(N'2021-07-29T11:53:12.8745877' AS DateTime2), CAST(N'2021-07-29T15:30:00.5375658' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2667, CAST(N'2021-07-29T11:54:40.3288416' AS DateTime2), CAST(N'2021-07-29T15:30:00.5392004' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2668, CAST(N'2021-07-29T11:55:47.9074628' AS DateTime2), CAST(N'2021-07-29T15:30:00.5413187' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2669, CAST(N'2021-07-29T11:57:04.3773209' AS DateTime2), CAST(N'2021-07-29T15:30:00.5434446' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2670, CAST(N'2021-07-29T12:07:58.1341253' AS DateTime2), CAST(N'2021-07-29T12:11:30.8162474' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2671, CAST(N'2021-07-29T12:11:28.0388840' AS DateTime2), CAST(N'2021-08-01T11:13:39.6314905' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2672, CAST(N'2021-07-29T12:14:49.8261656' AS DateTime2), CAST(N'2021-07-29T15:30:00.5450872' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2673, CAST(N'2021-07-29T12:17:10.5668068' AS DateTime2), CAST(N'2021-08-01T11:13:39.6314905' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2674, CAST(N'2021-07-29T12:19:45.3976956' AS DateTime2), CAST(N'2021-07-29T15:30:00.5472354' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2675, CAST(N'2021-07-29T12:19:56.1507769' AS DateTime2), CAST(N'2021-07-29T12:20:14.8592054' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2676, CAST(N'2021-07-29T12:23:46.8167606' AS DateTime2), CAST(N'2021-07-29T12:33:16.8228026' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2677, CAST(N'2021-07-29T12:26:48.1536425' AS DateTime2), CAST(N'2021-07-29T12:29:54.2453728' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2678, CAST(N'2021-07-29T12:26:51.4532944' AS DateTime2), CAST(N'2021-07-29T12:28:48.0527937' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2679, CAST(N'2021-07-29T12:33:24.6409240' AS DateTime2), CAST(N'2021-07-29T12:34:28.3971605' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2681, CAST(N'2021-07-29T12:39:04.0572864' AS DateTime2), CAST(N'2021-07-29T13:14:04.8393413' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2682, CAST(N'2021-07-29T12:41:37.1000299' AS DateTime2), CAST(N'2021-07-29T12:42:07.9971194' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2683, CAST(N'2021-07-29T12:44:04.1274444' AS DateTime2), CAST(N'2021-07-29T12:44:47.4429066' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2684, CAST(N'2021-07-29T12:48:43.3757048' AS DateTime2), CAST(N'2021-07-29T12:50:20.3899610' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2685, CAST(N'2021-07-29T12:48:56.9050386' AS DateTime2), CAST(N'2021-07-29T12:49:35.8238977' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2686, CAST(N'2021-07-29T12:49:38.7136945' AS DateTime2), CAST(N'2021-07-29T12:51:55.2729779' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2687, CAST(N'2021-07-29T12:51:58.3559987' AS DateTime2), CAST(N'2021-07-29T12:52:31.2173091' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2688, CAST(N'2021-07-29T12:55:02.9313263' AS DateTime2), CAST(N'2021-07-29T12:56:32.7254555' AS DateTime2), 2, 4)
GO
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2689, CAST(N'2021-07-29T12:56:46.5595783' AS DateTime2), CAST(N'2021-08-01T11:13:39.6314905' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2690, CAST(N'2021-07-29T12:58:34.0608885' AS DateTime2), CAST(N'2021-07-29T12:59:30.4523220' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2691, CAST(N'2021-07-29T12:59:38.8844459' AS DateTime2), CAST(N'2021-07-29T13:01:36.4223709' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2692, CAST(N'2021-07-29T13:00:31.7881048' AS DateTime2), CAST(N'2021-07-29T13:03:05.4701842' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2693, CAST(N'2021-07-29T13:03:15.4804044' AS DateTime2), CAST(N'2021-07-29T13:04:28.8065466' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2694, CAST(N'2021-07-29T13:03:34.2498670' AS DateTime2), CAST(N'2021-07-29T13:06:05.7595027' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2695, CAST(N'2021-07-29T13:05:20.2386075' AS DateTime2), CAST(N'2021-07-29T13:07:33.0199800' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2696, CAST(N'2021-07-29T13:06:28.2663996' AS DateTime2), CAST(N'2021-07-29T13:36:28.9832921' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2697, CAST(N'2021-07-29T13:08:23.0738749' AS DateTime2), CAST(N'2021-07-29T13:09:52.1485911' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2698, CAST(N'2021-07-29T13:08:56.9744340' AS DateTime2), CAST(N'2021-07-29T13:11:20.5619062' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2699, CAST(N'2021-07-29T13:10:03.2398298' AS DateTime2), CAST(N'2021-07-29T13:11:04.9339049' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2700, CAST(N'2021-07-29T13:17:02.9764398' AS DateTime2), CAST(N'2021-07-29T13:17:51.9290667' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2701, CAST(N'2021-07-29T13:18:03.5761446' AS DateTime2), CAST(N'2021-07-29T13:19:01.9156173' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2702, CAST(N'2021-07-29T13:19:12.3603169' AS DateTime2), CAST(N'2021-07-29T13:20:05.9486650' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2703, CAST(N'2021-07-29T13:21:03.4101541' AS DateTime2), CAST(N'2021-07-29T13:21:55.9250115' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2704, CAST(N'2021-07-29T13:23:50.0197231' AS DateTime2), CAST(N'2021-07-29T13:24:36.1610778' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2705, CAST(N'2021-07-29T13:25:03.6701212' AS DateTime2), CAST(N'2021-07-29T13:26:32.6586347' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2706, CAST(N'2021-07-29T13:28:52.2511041' AS DateTime2), CAST(N'2021-07-29T13:29:41.9876920' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2707, CAST(N'2021-07-29T13:32:32.5094235' AS DateTime2), CAST(N'2021-07-29T13:33:05.2213951' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2708, CAST(N'2021-07-29T13:32:44.0318653' AS DateTime2), CAST(N'2021-07-29T14:22:44.8562291' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2709, CAST(N'2021-07-29T13:34:30.7258232' AS DateTime2), CAST(N'2021-08-01T11:13:39.6314905' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2710, CAST(N'2021-07-29T13:34:55.9860549' AS DateTime2), CAST(N'2021-07-29T13:35:41.3467603' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2711, CAST(N'2021-07-29T13:35:31.7370929' AS DateTime2), CAST(N'2021-08-01T11:13:39.6471784' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2712, CAST(N'2021-07-29T13:36:29.0916588' AS DateTime2), CAST(N'2021-07-29T13:36:54.0929093' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2713, CAST(N'2021-07-29T13:37:52.1896131' AS DateTime2), CAST(N'2021-07-31T15:28:54.3643138' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2714, CAST(N'2021-07-29T13:39:18.1579475' AS DateTime2), CAST(N'2021-08-01T11:13:39.7100593' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2715, CAST(N'2021-07-29T13:39:58.6311116' AS DateTime2), CAST(N'2021-07-29T13:40:28.3992058' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2716, CAST(N'2021-07-29T13:41:11.9821645' AS DateTime2), CAST(N'2021-07-29T15:02:06.8363645' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2717, CAST(N'2021-07-29T13:41:32.0708657' AS DateTime2), CAST(N'2021-08-01T11:13:39.7100593' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2718, CAST(N'2021-07-29T13:41:53.2018932' AS DateTime2), CAST(N'2021-07-29T13:56:53.8978587' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2719, CAST(N'2021-07-29T13:42:00.6903375' AS DateTime2), CAST(N'2021-07-29T13:42:54.5266925' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2720, CAST(N'2021-07-29T13:47:07.7909759' AS DateTime2), CAST(N'2021-07-29T13:48:27.6032464' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2721, CAST(N'2021-07-29T13:54:06.6705510' AS DateTime2), CAST(N'2021-07-31T15:28:54.3799938' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2722, CAST(N'2021-07-29T13:57:17.4052613' AS DateTime2), CAST(N'2021-07-29T13:57:26.9354845' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2723, CAST(N'2021-07-29T13:57:39.6289202' AS DateTime2), CAST(N'2021-07-31T15:28:54.3799938' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2724, CAST(N'2021-07-29T13:59:59.8952411' AS DateTime2), CAST(N'2021-07-29T14:01:49.4676721' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2725, CAST(N'2021-07-29T14:01:59.3022741' AS DateTime2), CAST(N'2021-07-29T14:03:26.2870813' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2726, CAST(N'2021-07-29T14:05:21.9225991' AS DateTime2), CAST(N'2021-07-31T15:28:54.3799938' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2727, CAST(N'2021-07-29T14:06:11.9864399' AS DateTime2), CAST(N'2021-07-31T15:28:54.3799938' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2728, CAST(N'2021-07-29T14:07:40.9358690' AS DateTime2), CAST(N'2021-07-31T15:28:54.3799938' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2729, CAST(N'2021-07-29T14:09:42.7927127' AS DateTime2), CAST(N'2021-07-29T14:10:12.4505584' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2730, CAST(N'2021-07-29T14:11:37.3004311' AS DateTime2), CAST(N'2021-07-29T14:12:21.0138425' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2731, CAST(N'2021-07-29T14:14:16.6046067' AS DateTime2), CAST(N'2021-07-29T14:14:58.3785473' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2732, CAST(N'2021-07-29T14:16:09.0618428' AS DateTime2), CAST(N'2021-07-29T14:17:47.9087373' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2733, CAST(N'2021-07-29T14:17:11.7085907' AS DateTime2), CAST(N'2021-07-29T14:17:28.8973582' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2734, CAST(N'2021-07-29T14:24:58.3659111' AS DateTime2), CAST(N'2021-07-29T14:32:00.0273643' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2735, CAST(N'2021-07-29T14:27:18.3640966' AS DateTime2), CAST(N'2021-07-29T14:27:37.8291694' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2736, CAST(N'2021-07-29T14:33:31.7176355' AS DateTime2), CAST(N'2021-07-29T14:34:10.9156878' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2737, CAST(N'2021-07-29T14:33:50.4997281' AS DateTime2), CAST(N'2021-07-29T14:34:23.3448464' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2738, CAST(N'2021-07-29T14:38:47.3960143' AS DateTime2), CAST(N'2021-07-29T14:39:21.4403251' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2739, CAST(N'2021-07-29T14:39:11.1186864' AS DateTime2), CAST(N'2021-07-31T15:28:54.3799938' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2740, CAST(N'2021-07-29T14:39:43.8973081' AS DateTime2), CAST(N'2021-07-31T15:28:54.3799938' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2741, CAST(N'2021-07-29T14:40:51.7306455' AS DateTime2), CAST(N'2021-07-29T14:41:26.1802210' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2742, CAST(N'2021-07-29T14:41:26.3284245' AS DateTime2), CAST(N'2021-07-29T14:42:16.6490804' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2743, CAST(N'2021-07-29T14:42:25.3711844' AS DateTime2), CAST(N'2021-07-29T14:43:18.2141033' AS DateTime2), 9, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2744, CAST(N'2021-07-29T14:42:44.7403135' AS DateTime2), CAST(N'2021-07-29T14:44:26.6012252' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2745, CAST(N'2021-07-29T14:43:13.5194386' AS DateTime2), CAST(N'2021-07-29T14:44:14.4330883' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2746, CAST(N'2021-07-29T14:44:36.0304351' AS DateTime2), CAST(N'2021-07-29T14:45:12.6456896' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2747, CAST(N'2021-07-29T14:45:10.7778095' AS DateTime2), CAST(N'2021-07-29T14:47:17.7427372' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2748, CAST(N'2021-07-29T14:45:30.1302124' AS DateTime2), CAST(N'2021-07-29T14:46:00.1363945' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2749, CAST(N'2021-07-29T14:46:29.0160485' AS DateTime2), CAST(N'2021-07-29T14:46:53.9431870' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2750, CAST(N'2021-07-29T14:47:30.7058222' AS DateTime2), CAST(N'2021-07-29T14:49:49.0697710' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2751, CAST(N'2021-07-29T14:48:32.3747348' AS DateTime2), CAST(N'2021-07-29T15:30:00.5494003' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2752, CAST(N'2021-07-29T14:49:10.1385975' AS DateTime2), CAST(N'2021-07-31T15:28:54.3799938' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2753, CAST(N'2021-07-29T14:49:12.4703349' AS DateTime2), CAST(N'2021-07-29T14:50:23.5692921' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2754, CAST(N'2021-07-29T14:50:16.1848471' AS DateTime2), CAST(N'2021-07-29T14:51:01.4050758' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2755, CAST(N'2021-07-29T14:51:45.4430041' AS DateTime2), CAST(N'2021-07-29T14:52:22.2938710' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2756, CAST(N'2021-07-29T14:52:53.0303640' AS DateTime2), CAST(N'2021-07-29T14:55:07.2697921' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2757, CAST(N'2021-07-29T14:54:58.8431992' AS DateTime2), CAST(N'2021-07-29T14:55:39.9935097' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2758, CAST(N'2021-07-29T14:55:37.2380246' AS DateTime2), CAST(N'2021-07-29T14:55:58.4740040' AS DateTime2), 9, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2759, CAST(N'2021-07-29T14:55:56.4986737' AS DateTime2), CAST(N'2021-07-29T14:56:24.8680480' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2760, CAST(N'2021-07-29T14:58:20.6659295' AS DateTime2), CAST(N'2021-07-29T14:58:51.6357963' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2761, CAST(N'2021-07-29T15:01:35.3187364' AS DateTime2), CAST(N'2021-07-29T15:04:36.8933003' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2762, CAST(N'2021-07-29T15:02:07.5257410' AS DateTime2), CAST(N'2021-07-29T15:02:25.4968355' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2763, CAST(N'2021-07-29T15:02:53.5031773' AS DateTime2), CAST(N'2021-07-29T15:04:37.8079097' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2764, CAST(N'2021-07-29T15:08:49.9602571' AS DateTime2), CAST(N'2021-07-29T15:09:19.3312292' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2765, CAST(N'2021-07-29T15:10:23.9274944' AS DateTime2), CAST(N'2021-07-29T15:12:43.7814108' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2766, CAST(N'2021-07-29T15:10:27.8274951' AS DateTime2), CAST(N'2021-07-29T15:12:25.5587222' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2767, CAST(N'2021-07-29T15:14:46.2828271' AS DateTime2), CAST(N'2021-07-29T15:20:33.5216401' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2768, CAST(N'2021-07-29T15:17:31.4833071' AS DateTime2), CAST(N'2021-07-29T15:28:58.1628756' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2769, CAST(N'2021-07-29T15:28:56.5024964' AS DateTime2), CAST(N'2021-07-29T15:29:26.3809729' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2770, CAST(N'2021-07-29T15:30:01.2500777' AS DateTime2), CAST(N'2021-07-29T15:30:37.5382375' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2771, CAST(N'2021-07-29T15:33:44.8011342' AS DateTime2), CAST(N'2021-07-29T15:38:51.7019667' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2772, CAST(N'2021-07-29T15:39:03.3441059' AS DateTime2), CAST(N'2021-07-29T15:39:57.8985859' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2773, CAST(N'2021-07-29T15:40:05.8904193' AS DateTime2), CAST(N'2021-07-29T15:40:12.2054701' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2774, CAST(N'2021-07-29T15:40:08.5064115' AS DateTime2), CAST(N'2021-07-29T15:40:30.0671419' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2775, CAST(N'2021-07-29T15:40:25.6082798' AS DateTime2), CAST(N'2021-07-29T15:40:41.7345445' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2776, CAST(N'2021-07-29T15:40:41.5714442' AS DateTime2), CAST(N'2021-07-29T15:41:02.7831542' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2777, CAST(N'2021-07-29T15:40:57.9464651' AS DateTime2), CAST(N'2021-07-29T15:41:37.7235956' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2778, CAST(N'2021-07-29T15:40:58.3322156' AS DateTime2), CAST(N'2021-07-29T15:41:29.9075904' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2779, CAST(N'2021-07-29T15:41:25.8377398' AS DateTime2), CAST(N'2021-07-29T15:41:51.9620365' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2780, CAST(N'2021-07-29T15:41:47.5555114' AS DateTime2), CAST(N'2021-07-29T15:51:29.3373266' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2781, CAST(N'2021-07-29T15:42:22.9627029' AS DateTime2), CAST(N'2021-07-29T15:42:58.1103868' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2782, CAST(N'2021-07-29T15:43:53.2400394' AS DateTime2), CAST(N'2021-07-29T15:45:07.3467546' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2783, CAST(N'2021-07-29T15:45:58.2221463' AS DateTime2), CAST(N'2021-07-29T15:46:49.2419061' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2784, CAST(N'2021-07-29T15:49:12.9971283' AS DateTime2), CAST(N'2021-07-29T16:09:15.0613464' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2785, CAST(N'2021-07-29T15:51:27.2065350' AS DateTime2), CAST(N'2021-07-29T15:51:34.2600123' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2786, CAST(N'2021-07-29T15:51:55.6925499' AS DateTime2), CAST(N'2021-07-29T15:53:00.8111116' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2787, CAST(N'2021-07-29T15:56:40.4801254' AS DateTime2), CAST(N'2021-07-29T15:57:21.7370229' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2788, CAST(N'2021-07-29T15:59:19.2725734' AS DateTime2), CAST(N'2021-07-29T16:00:52.1859128' AS DateTime2), 2, 2)
GO
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2789, CAST(N'2021-07-29T16:04:58.7855776' AS DateTime2), CAST(N'2021-07-29T16:07:22.8004222' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2790, CAST(N'2021-07-29T16:07:23.4892081' AS DateTime2), CAST(N'2021-07-29T16:07:50.1417533' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2791, CAST(N'2021-07-29T16:07:50.8888178' AS DateTime2), CAST(N'2021-07-29T16:09:30.9773539' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2792, CAST(N'2021-07-29T16:09:31.7129455' AS DateTime2), CAST(N'2021-07-29T16:10:21.5941519' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2793, CAST(N'2021-07-29T16:10:22.3041770' AS DateTime2), CAST(N'2021-07-29T16:25:23.3135410' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2794, CAST(N'2021-07-29T16:40:45.3499472' AS DateTime2), CAST(N'2021-07-29T16:48:00.6189833' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2795, CAST(N'2021-07-29T16:52:53.1465915' AS DateTime2), CAST(N'2021-07-29T16:58:31.4486345' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2796, CAST(N'2021-07-29T16:58:32.1660611' AS DateTime2), CAST(N'2021-07-30T00:29:21.5343244' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2797, CAST(N'2021-07-29T17:11:12.7323741' AS DateTime2), CAST(N'2021-07-29T18:13:45.3679089' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2798, CAST(N'2021-07-29T18:13:50.2545813' AS DateTime2), CAST(N'2021-07-29T18:15:47.2162138' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2799, CAST(N'2021-07-29T18:21:52.1339162' AS DateTime2), CAST(N'2021-07-29T18:31:17.1488307' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2800, CAST(N'2021-07-29T20:25:49.3636062' AS DateTime2), CAST(N'2021-07-29T21:42:49.9154989' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2801, CAST(N'2021-07-29T21:42:58.3946908' AS DateTime2), CAST(N'2021-07-29T21:52:25.6260157' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2802, CAST(N'2021-07-29T21:52:27.0302648' AS DateTime2), CAST(N'2021-07-29T22:08:30.4790099' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2803, CAST(N'2021-07-29T22:08:31.1106130' AS DateTime2), CAST(N'2021-07-29T22:15:20.6160434' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2804, CAST(N'2021-07-29T22:15:28.7726972' AS DateTime2), CAST(N'2021-07-29T22:21:33.6140139' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2805, CAST(N'2021-07-29T22:51:57.1073913' AS DateTime2), CAST(N'2021-07-29T23:03:23.9365968' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2806, CAST(N'2021-07-29T23:03:45.7870541' AS DateTime2), CAST(N'2021-07-30T14:23:28.2190656' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2807, CAST(N'2021-07-29T23:07:54.9105073' AS DateTime2), CAST(N'2021-07-29T23:08:24.6852353' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2808, CAST(N'2021-07-29T23:46:29.1192115' AS DateTime2), CAST(N'2021-07-31T15:28:54.3799938' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2809, CAST(N'2021-07-30T00:29:25.7175495' AS DateTime2), CAST(N'2021-07-30T00:36:55.0431795' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2810, CAST(N'2021-07-30T00:42:16.6540367' AS DateTime2), CAST(N'2021-07-30T00:43:36.1674671' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2811, CAST(N'2021-07-30T14:24:05.2698446' AS DateTime2), CAST(N'2021-07-30T14:51:32.7392388' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2812, CAST(N'2021-07-30T14:51:34.1199944' AS DateTime2), CAST(N'2021-07-30T14:52:04.8703681' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2813, CAST(N'2021-07-30T15:02:37.9475236' AS DateTime2), CAST(N'2021-07-30T15:02:59.8663180' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2814, CAST(N'2021-07-30T15:02:59.2560866' AS DateTime2), CAST(N'2021-07-30T15:04:15.2164075' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2815, CAST(N'2021-07-30T15:04:12.7690753' AS DateTime2), CAST(N'2021-07-30T15:04:23.9631223' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2816, CAST(N'2021-07-30T15:04:23.3264280' AS DateTime2), CAST(N'2021-07-30T15:04:34.1850362' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2817, CAST(N'2021-07-30T15:04:31.2868247' AS DateTime2), CAST(N'2021-07-30T15:04:47.5332748' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2818, CAST(N'2021-07-30T15:04:44.6406106' AS DateTime2), CAST(N'2021-07-30T21:13:23.0512764' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2819, CAST(N'2021-07-31T09:25:11.5242890' AS DateTime2), CAST(N'2021-07-31T09:30:12.3022042' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2820, CAST(N'2021-07-31T09:30:34.8565924' AS DateTime2), CAST(N'2021-07-31T09:40:35.5133988' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2821, CAST(N'2021-07-31T09:47:05.0544110' AS DateTime2), CAST(N'2021-07-31T09:47:51.1238596' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2822, CAST(N'2021-07-31T09:48:32.5701216' AS DateTime2), CAST(N'2021-07-31T09:49:52.6379398' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2823, CAST(N'2021-07-31T09:49:53.3408936' AS DateTime2), CAST(N'2021-07-31T14:17:23.9040125' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2824, CAST(N'2021-07-31T14:17:25.2134345' AS DateTime2), CAST(N'2021-07-31T15:14:53.2170529' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2825, CAST(N'2021-07-31T15:14:54.3418170' AS DateTime2), CAST(N'2021-07-31T15:29:18.1458493' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2826, CAST(N'2021-07-31T15:28:55.1456631' AS DateTime2), CAST(N'2021-07-31T15:29:26.3650922' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2827, CAST(N'2021-07-31T15:29:35.2715310' AS DateTime2), CAST(N'2021-07-31T15:36:07.3700398' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2828, CAST(N'2021-07-31T15:36:08.4167135' AS DateTime2), CAST(N'2021-07-31T15:36:34.6669032' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2829, CAST(N'2021-07-31T15:46:46.8465763' AS DateTime2), CAST(N'2021-07-31T15:47:23.0187817' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2830, CAST(N'2021-07-31T15:47:40.1595946' AS DateTime2), CAST(N'2021-08-01T09:59:41.3965135' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2831, CAST(N'2021-07-31T17:01:05.5270713' AS DateTime2), CAST(N'2021-08-01T11:44:03.9510549' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2832, CAST(N'2021-07-31T20:27:23.6235225' AS DateTime2), CAST(N'2021-07-31T20:38:40.6974963' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2833, CAST(N'2021-07-31T20:38:41.3971775' AS DateTime2), CAST(N'2021-07-31T20:46:39.2934811' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2834, CAST(N'2021-07-31T20:45:29.7455467' AS DateTime2), NULL, 2, 25)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2835, CAST(N'2021-07-31T20:46:01.7782454' AS DateTime2), NULL, 2, 26)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2836, CAST(N'2021-07-31T20:46:40.0276350' AS DateTime2), CAST(N'2021-07-31T21:36:00.4384495' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2837, CAST(N'2021-07-31T21:36:01.1101228' AS DateTime2), CAST(N'2021-07-31T21:43:58.3345298' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2838, CAST(N'2021-07-31T21:43:58.9910289' AS DateTime2), CAST(N'2021-07-31T21:46:10.5238223' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2839, CAST(N'2021-07-31T21:46:11.1955316' AS DateTime2), CAST(N'2021-07-31T22:28:28.7566213' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2840, CAST(N'2021-07-31T22:28:29.4599993' AS DateTime2), CAST(N'2021-07-31T22:32:35.8534918' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2841, CAST(N'2021-07-31T22:32:36.5879701' AS DateTime2), CAST(N'2021-08-01T10:02:31.4137408' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2842, CAST(N'2021-08-01T09:59:43.2869903' AS DateTime2), CAST(N'2021-08-01T10:05:28.9156399' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2843, CAST(N'2021-08-01T10:02:32.1011402' AS DateTime2), CAST(N'2021-08-01T10:10:59.1849690' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2844, CAST(N'2021-08-01T10:05:30.0408617' AS DateTime2), CAST(N'2021-08-01T10:11:38.2010858' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2845, CAST(N'2021-08-01T10:10:59.9192796' AS DateTime2), CAST(N'2021-08-01T11:11:33.9111556' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2846, CAST(N'2021-08-01T10:11:38.9981244' AS DateTime2), CAST(N'2021-08-01T10:13:30.9990333' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2847, CAST(N'2021-08-01T10:13:32.3743682' AS DateTime2), CAST(N'2021-08-01T10:15:48.1099222' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2848, CAST(N'2021-08-01T10:15:48.9693277' AS DateTime2), CAST(N'2021-08-01T10:18:41.9712270' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2849, CAST(N'2021-08-01T10:18:42.7211106' AS DateTime2), CAST(N'2021-08-01T10:22:30.3174300' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2850, CAST(N'2021-08-01T10:22:31.0829253' AS DateTime2), CAST(N'2021-08-01T10:23:53.4587329' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2851, CAST(N'2021-08-01T10:23:54.2713324' AS DateTime2), CAST(N'2021-08-01T10:29:57.5568158' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2852, CAST(N'2021-08-01T10:29:58.3068702' AS DateTime2), CAST(N'2021-08-01T10:31:18.9012151' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2853, CAST(N'2021-08-01T10:31:19.8545927' AS DateTime2), CAST(N'2021-08-01T10:32:05.9017737' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2854, CAST(N'2021-08-01T10:32:07.0735406' AS DateTime2), CAST(N'2021-08-01T10:33:53.7779512' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2855, CAST(N'2021-08-01T10:33:54.7311330' AS DateTime2), CAST(N'2021-08-01T10:35:49.8881764' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2856, CAST(N'2021-08-01T10:35:50.7636588' AS DateTime2), CAST(N'2021-08-01T10:37:56.0930402' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2857, CAST(N'2021-08-01T10:37:56.9365426' AS DateTime2), CAST(N'2021-08-01T10:39:34.6254103' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2858, CAST(N'2021-08-01T10:39:36.2972167' AS DateTime2), CAST(N'2021-08-01T11:26:43.4996914' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2859, CAST(N'2021-08-01T11:13:41.1939258' AS DateTime2), CAST(N'2021-08-01T11:16:23.3367084' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2860, CAST(N'2021-08-01T11:15:10.1793002' AS DateTime2), CAST(N'2021-08-01T12:18:08.2676627' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2861, CAST(N'2021-08-01T11:16:24.4301324' AS DateTime2), CAST(N'2021-08-01T11:19:42.1359416' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2862, CAST(N'2021-08-01T11:19:43.2607697' AS DateTime2), CAST(N'2021-08-01T11:24:25.5920550' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2863, CAST(N'2021-08-01T11:24:26.7793697' AS DateTime2), CAST(N'2021-08-01T11:27:53.0745264' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2864, CAST(N'2021-08-01T11:27:49.6403540' AS DateTime2), CAST(N'2021-08-01T11:47:39.7853005' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2865, CAST(N'2021-08-01T11:27:54.4310318' AS DateTime2), CAST(N'2021-08-01T11:29:32.9266490' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2866, CAST(N'2021-08-01T11:29:33.9442824' AS DateTime2), CAST(N'2021-08-01T11:39:33.4615630' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2867, CAST(N'2021-08-01T11:39:35.5891382' AS DateTime2), CAST(N'2021-08-01T12:04:22.8813644' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2868, CAST(N'2021-08-01T11:44:05.7328263' AS DateTime2), CAST(N'2021-08-01T11:49:06.4467563' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2869, CAST(N'2021-08-01T11:47:40.9238092' AS DateTime2), CAST(N'2021-08-01T12:30:00.2839603' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2870, CAST(N'2021-08-01T11:49:07.2171228' AS DateTime2), CAST(N'2021-08-01T12:10:12.5388694' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2871, CAST(N'2021-08-01T12:04:25.1813522' AS DateTime2), CAST(N'2021-08-01T12:06:49.5281029' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2872, CAST(N'2021-08-01T12:06:32.9311121' AS DateTime2), CAST(N'2021-08-01T12:24:03.1727607' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2873, CAST(N'2021-08-01T12:06:50.4107590' AS DateTime2), CAST(N'2021-08-01T12:08:22.5727659' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2874, CAST(N'2021-08-01T12:08:23.3541109' AS DateTime2), CAST(N'2021-08-01T12:10:55.3021478' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2875, CAST(N'2021-08-01T12:10:13.3814896' AS DateTime2), CAST(N'2021-08-01T12:12:02.4130744' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2876, CAST(N'2021-08-01T12:10:56.1537040' AS DateTime2), CAST(N'2021-08-01T12:17:28.3900168' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2877, CAST(N'2021-08-01T12:12:03.3651490' AS DateTime2), CAST(N'2021-08-01T13:11:37.2283503' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2878, CAST(N'2021-08-01T12:17:29.3410638' AS DateTime2), CAST(N'2021-08-01T12:19:17.8958837' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2879, CAST(N'2021-08-01T12:18:09.1443097' AS DateTime2), CAST(N'2021-08-01T12:42:14.4219933' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2880, CAST(N'2021-08-01T12:19:18.9063843' AS DateTime2), CAST(N'2021-08-01T12:23:02.0870977' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2881, CAST(N'2021-08-01T12:23:02.9609026' AS DateTime2), CAST(N'2021-08-01T12:25:51.0471246' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2882, CAST(N'2021-08-01T12:24:04.2146681' AS DateTime2), CAST(N'2021-08-01T15:18:32.9146687' AS DateTime2), 9, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2883, CAST(N'2021-08-01T12:25:51.8867774' AS DateTime2), CAST(N'2021-08-01T12:27:03.3203319' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2884, CAST(N'2021-08-01T12:27:04.2793873' AS DateTime2), CAST(N'2021-08-01T12:30:07.2238400' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2885, CAST(N'2021-08-01T12:30:01.3969997' AS DateTime2), CAST(N'2021-08-01T12:31:26.2305259' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2886, CAST(N'2021-08-01T12:30:08.0939814' AS DateTime2), CAST(N'2021-08-01T12:32:31.3726191' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2887, CAST(N'2021-08-01T12:31:28.2088644' AS DateTime2), CAST(N'2021-08-01T12:34:31.6895406' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2888, CAST(N'2021-08-01T12:32:32.1017445' AS DateTime2), CAST(N'2021-08-01T12:33:27.6392360' AS DateTime2), 2, 3)
GO
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2889, CAST(N'2021-08-01T12:33:28.8491028' AS DateTime2), CAST(N'2021-08-01T12:51:22.6632803' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2890, CAST(N'2021-08-01T12:34:33.0681227' AS DateTime2), CAST(N'2021-08-01T12:36:43.1502423' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2891, CAST(N'2021-08-01T12:36:44.1608394' AS DateTime2), CAST(N'2021-08-01T12:38:45.1331574' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2892, CAST(N'2021-08-01T12:38:46.1155829' AS DateTime2), CAST(N'2021-08-01T12:40:47.5942010' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2893, CAST(N'2021-08-01T12:40:48.4166639' AS DateTime2), CAST(N'2021-08-01T12:41:50.6800592' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2894, CAST(N'2021-08-01T12:41:51.5559814' AS DateTime2), CAST(N'2021-08-01T12:42:21.7182183' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2895, CAST(N'2021-08-01T12:42:15.1444565' AS DateTime2), CAST(N'2021-08-01T13:19:29.9836759' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2896, CAST(N'2021-08-01T12:42:22.6137842' AS DateTime2), CAST(N'2021-08-01T12:44:27.3925151' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2897, CAST(N'2021-08-01T12:44:28.2372171' AS DateTime2), CAST(N'2021-08-01T12:46:00.0711364' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2898, CAST(N'2021-08-01T12:46:01.2264244' AS DateTime2), CAST(N'2021-08-01T12:47:12.5801867' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2899, CAST(N'2021-08-01T12:47:13.6170050' AS DateTime2), CAST(N'2021-08-01T12:49:47.1722271' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2900, CAST(N'2021-08-01T12:49:48.1741391' AS DateTime2), CAST(N'2021-08-01T12:50:19.9908238' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2901, CAST(N'2021-08-01T12:50:21.1404516' AS DateTime2), CAST(N'2021-08-01T12:52:31.0955884' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2902, CAST(N'2021-08-01T12:51:23.6636532' AS DateTime2), CAST(N'2021-08-01T13:03:43.3609065' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2903, CAST(N'2021-08-01T12:52:32.2485867' AS DateTime2), CAST(N'2021-08-01T12:53:06.1630586' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2904, CAST(N'2021-08-01T12:53:07.1131797' AS DateTime2), CAST(N'2021-08-01T12:54:50.0078434' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2905, CAST(N'2021-08-01T12:54:50.9123539' AS DateTime2), CAST(N'2021-08-01T12:57:05.6854928' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2906, CAST(N'2021-08-01T12:57:07.1142154' AS DateTime2), CAST(N'2021-08-01T12:59:48.8244587' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2907, CAST(N'2021-08-01T12:59:49.8391073' AS DateTime2), CAST(N'2021-08-01T13:13:54.6090640' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2908, CAST(N'2021-08-01T13:03:44.7238905' AS DateTime2), CAST(N'2021-08-01T13:36:51.7768465' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2909, CAST(N'2021-08-01T13:11:37.9795564' AS DateTime2), CAST(N'2021-08-01T13:47:38.3370075' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2910, CAST(N'2021-08-01T13:13:55.5960019' AS DateTime2), CAST(N'2021-08-01T13:34:25.5678482' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2911, CAST(N'2021-08-01T13:19:30.7346920' AS DateTime2), CAST(N'2021-08-01T14:38:42.1554150' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2912, CAST(N'2021-08-01T13:34:26.9673630' AS DateTime2), CAST(N'2021-08-01T13:47:38.3370075' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2913, CAST(N'2021-08-01T13:36:52.5922543' AS DateTime2), CAST(N'2021-08-01T13:38:27.3207395' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2914, CAST(N'2021-08-01T13:38:28.2277903' AS DateTime2), CAST(N'2021-08-01T13:44:39.5662159' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2915, CAST(N'2021-08-01T13:44:41.8582588' AS DateTime2), CAST(N'2021-08-01T14:06:48.7375197' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2916, CAST(N'2021-08-01T13:47:41.2666231' AS DateTime2), CAST(N'2021-08-01T13:48:43.2427399' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2917, CAST(N'2021-08-01T13:47:43.3398316' AS DateTime2), CAST(N'2021-08-01T14:00:44.8452465' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2918, CAST(N'2021-08-01T13:48:44.4116598' AS DateTime2), CAST(N'2021-08-01T13:50:07.7035043' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2919, CAST(N'2021-08-01T13:50:09.2959589' AS DateTime2), CAST(N'2021-08-01T13:51:27.3708853' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2920, CAST(N'2021-08-01T13:51:28.3504272' AS DateTime2), CAST(N'2021-08-01T13:53:15.6151795' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2921, CAST(N'2021-08-01T13:53:16.5389487' AS DateTime2), CAST(N'2021-08-01T13:54:18.1930105' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2922, CAST(N'2021-08-01T13:54:19.3582108' AS DateTime2), CAST(N'2021-08-01T13:55:29.2411968' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2923, CAST(N'2021-08-01T13:55:30.2940265' AS DateTime2), CAST(N'2021-08-01T13:57:01.5419891' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2924, CAST(N'2021-08-01T13:57:02.6240458' AS DateTime2), CAST(N'2021-08-01T13:59:11.4369764' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2925, CAST(N'2021-08-01T13:59:12.5676749' AS DateTime2), CAST(N'2021-08-01T14:00:30.5149168' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2926, CAST(N'2021-08-01T14:00:31.8077900' AS DateTime2), CAST(N'2021-08-01T14:14:05.6790625' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2927, CAST(N'2021-08-01T14:00:45.6891859' AS DateTime2), CAST(N'2021-08-01T14:02:43.9212065' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2928, CAST(N'2021-08-01T14:02:44.7639418' AS DateTime2), CAST(N'2021-08-01T14:35:26.7730561' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2929, CAST(N'2021-08-01T14:06:49.6581362' AS DateTime2), CAST(N'2021-08-01T14:09:36.9472475' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2930, CAST(N'2021-08-01T14:09:38.0682541' AS DateTime2), CAST(N'2021-08-01T19:49:41.0269185' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2931, CAST(N'2021-08-01T14:14:07.0269548' AS DateTime2), CAST(N'2021-08-01T14:14:45.0247926' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2932, CAST(N'2021-08-01T14:14:46.1877981' AS DateTime2), CAST(N'2021-08-01T14:17:19.9249459' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2933, CAST(N'2021-08-01T14:17:20.6790000' AS DateTime2), CAST(N'2021-08-01T14:17:55.5051928' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2934, CAST(N'2021-08-01T14:17:56.3781620' AS DateTime2), CAST(N'2021-08-01T14:20:41.2406540' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2935, CAST(N'2021-08-01T14:20:45.3750304' AS DateTime2), CAST(N'2021-08-01T14:22:55.9525118' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2936, CAST(N'2021-08-01T14:22:56.7880906' AS DateTime2), CAST(N'2021-08-01T14:29:25.6953256' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2937, CAST(N'2021-08-01T14:29:26.4162457' AS DateTime2), CAST(N'2021-08-01T15:05:49.8330196' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2938, CAST(N'2021-08-01T14:35:27.4720909' AS DateTime2), CAST(N'2021-08-01T14:52:47.9828227' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2939, CAST(N'2021-08-01T14:38:42.8509193' AS DateTime2), CAST(N'2021-08-01T15:15:12.6378787' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2940, CAST(N'2021-08-01T14:52:49.8549900' AS DateTime2), CAST(N'2021-08-01T15:05:49.8330196' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2941, CAST(N'2021-08-01T15:05:51.6875890' AS DateTime2), CAST(N'2021-08-01T15:19:17.2216725' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2942, CAST(N'2021-08-01T15:05:51.6854297' AS DateTime2), CAST(N'2021-08-01T15:13:49.8855105' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2943, CAST(N'2021-08-01T15:13:50.8237991' AS DateTime2), CAST(N'2021-08-01T15:15:08.1106017' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2944, CAST(N'2021-08-01T15:15:09.2819049' AS DateTime2), CAST(N'2021-08-01T15:16:39.1110256' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2945, CAST(N'2021-08-01T15:15:13.3302307' AS DateTime2), CAST(N'2021-08-01T15:17:55.8862864' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2946, CAST(N'2021-08-01T15:16:39.8913070' AS DateTime2), CAST(N'2021-08-01T15:18:07.6831740' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2947, CAST(N'2021-08-01T15:17:56.6000575' AS DateTime2), CAST(N'2021-08-01T15:29:47.4514471' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2948, CAST(N'2021-08-01T15:18:08.4920510' AS DateTime2), CAST(N'2021-08-01T15:18:50.5034544' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2949, CAST(N'2021-08-01T15:18:34.1831914' AS DateTime2), CAST(N'2021-08-01T15:18:43.8797327' AS DateTime2), 9, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2950, CAST(N'2021-08-01T15:18:51.2397860' AS DateTime2), CAST(N'2021-08-01T15:20:45.5636806' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2951, CAST(N'2021-08-01T15:19:18.2881614' AS DateTime2), CAST(N'2021-08-01T15:37:47.4591399' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2952, CAST(N'2021-08-01T15:20:46.7757702' AS DateTime2), CAST(N'2021-08-01T15:24:03.2279716' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2953, CAST(N'2021-08-01T15:24:03.9827980' AS DateTime2), CAST(N'2021-08-01T15:26:30.7584950' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2954, CAST(N'2021-08-01T15:26:32.0298308' AS DateTime2), CAST(N'2021-08-01T15:43:54.4262158' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2955, CAST(N'2021-08-01T15:29:48.2247922' AS DateTime2), CAST(N'2021-08-01T15:30:29.3845348' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2956, CAST(N'2021-08-01T15:30:30.0788780' AS DateTime2), CAST(N'2021-08-01T15:34:20.5337623' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2957, CAST(N'2021-08-01T15:34:21.2241142' AS DateTime2), CAST(N'2021-08-01T15:35:33.3618730' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2958, CAST(N'2021-08-01T15:35:34.0397310' AS DateTime2), CAST(N'2021-08-01T17:39:18.9836739' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2959, CAST(N'2021-08-01T15:37:48.1731664' AS DateTime2), CAST(N'2021-08-01T15:41:33.1953260' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2960, CAST(N'2021-08-01T15:41:34.3526519' AS DateTime2), CAST(N'2021-08-01T15:48:35.0094064' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2961, CAST(N'2021-08-01T15:43:55.2473272' AS DateTime2), CAST(N'2021-08-01T15:52:01.1117554' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2962, CAST(N'2021-08-01T15:48:35.9018397' AS DateTime2), CAST(N'2021-08-01T15:57:13.1685318' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2963, CAST(N'2021-08-01T15:52:18.3903184' AS DateTime2), CAST(N'2021-08-01T15:58:53.8790879' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2964, CAST(N'2021-08-01T15:57:14.2534597' AS DateTime2), CAST(N'2021-08-01T16:10:40.9850907' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2965, CAST(N'2021-08-01T15:58:54.7923046' AS DateTime2), CAST(N'2021-08-01T15:59:32.1350258' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2966, CAST(N'2021-08-01T15:59:32.8731440' AS DateTime2), CAST(N'2021-08-01T16:10:04.1092386' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2967, CAST(N'2021-08-01T16:10:05.9489210' AS DateTime2), CAST(N'2021-08-01T16:10:55.8505594' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2968, CAST(N'2021-08-01T16:10:41.6657265' AS DateTime2), CAST(N'2021-08-01T16:11:40.5511408' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2969, CAST(N'2021-08-01T16:10:56.7068049' AS DateTime2), CAST(N'2021-08-01T16:12:34.8417353' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2970, CAST(N'2021-08-01T16:11:46.8186232' AS DateTime2), CAST(N'2021-08-01T16:17:06.1964414' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2971, CAST(N'2021-08-01T16:12:35.8368132' AS DateTime2), CAST(N'2021-08-01T16:14:20.9134836' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2972, CAST(N'2021-08-01T16:14:21.8764756' AS DateTime2), CAST(N'2021-08-01T16:15:59.3548063' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2973, CAST(N'2021-08-01T16:16:00.4622536' AS DateTime2), CAST(N'2021-08-01T16:17:25.1650016' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2974, CAST(N'2021-08-01T16:17:07.0538505' AS DateTime2), CAST(N'2021-08-01T16:17:56.8996903' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2975, CAST(N'2021-08-01T16:17:26.1981731' AS DateTime2), CAST(N'2021-08-01T16:18:34.5824650' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2976, CAST(N'2021-08-01T16:17:57.5997664' AS DateTime2), CAST(N'2021-08-01T16:27:22.1905425' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2977, CAST(N'2021-08-01T16:18:36.8666157' AS DateTime2), CAST(N'2021-08-01T16:20:49.5489876' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2978, CAST(N'2021-08-01T16:20:50.3361811' AS DateTime2), CAST(N'2021-08-01T16:23:17.7787715' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2979, CAST(N'2021-08-01T16:23:18.7004788' AS DateTime2), CAST(N'2021-08-01T16:26:20.4839987' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2980, CAST(N'2021-08-01T16:26:21.2485815' AS DateTime2), CAST(N'2021-08-01T16:34:36.1558546' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2981, CAST(N'2021-08-01T16:27:22.8821866' AS DateTime2), CAST(N'2021-08-01T16:41:24.3937764' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2982, CAST(N'2021-08-01T16:34:36.9929183' AS DateTime2), CAST(N'2021-08-01T16:35:27.3808044' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2983, CAST(N'2021-08-01T16:35:28.1297272' AS DateTime2), CAST(N'2021-08-01T16:37:43.9830451' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2984, CAST(N'2021-08-01T16:37:44.7498897' AS DateTime2), CAST(N'2021-08-01T16:43:02.4158502' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2985, CAST(N'2021-08-01T16:41:25.1886170' AS DateTime2), CAST(N'2021-08-01T16:44:41.0180641' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2986, CAST(N'2021-08-01T16:43:03.1491693' AS DateTime2), CAST(N'2021-08-01T16:47:32.0396394' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2987, CAST(N'2021-08-01T16:44:41.8313181' AS DateTime2), CAST(N'2021-08-01T17:01:59.6886564' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2988, CAST(N'2021-08-01T16:47:32.7985322' AS DateTime2), CAST(N'2021-08-01T16:49:13.4185030' AS DateTime2), 2, 4)
GO
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2989, CAST(N'2021-08-01T16:49:14.2106868' AS DateTime2), CAST(N'2021-08-01T16:50:28.3143597' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2990, CAST(N'2021-08-01T16:50:29.0788011' AS DateTime2), CAST(N'2021-08-01T16:52:15.6025823' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2991, CAST(N'2021-08-01T16:52:16.6817714' AS DateTime2), CAST(N'2021-08-01T16:55:44.5721618' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2992, CAST(N'2021-08-01T16:55:45.3757922' AS DateTime2), CAST(N'2021-08-02T09:21:57.9729995' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2993, CAST(N'2021-08-01T17:02:00.5125035' AS DateTime2), CAST(N'2021-08-01T17:08:47.9924866' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2994, CAST(N'2021-08-01T17:08:48.8138062' AS DateTime2), CAST(N'2021-08-01T17:18:17.2024201' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2995, CAST(N'2021-08-01T17:18:17.9606683' AS DateTime2), CAST(N'2021-08-01T17:25:06.0977696' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2996, CAST(N'2021-08-01T17:25:06.8039876' AS DateTime2), CAST(N'2021-08-01T17:34:25.9551301' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2997, CAST(N'2021-08-01T17:34:26.8048267' AS DateTime2), CAST(N'2021-08-01T18:02:42.9171814' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2998, CAST(N'2021-08-01T17:39:19.7377678' AS DateTime2), CAST(N'2021-08-02T00:26:40.0175639' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2999, CAST(N'2021-08-01T18:02:43.7569646' AS DateTime2), CAST(N'2021-08-01T18:07:54.9554641' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3000, CAST(N'2021-08-01T18:07:55.8713586' AS DateTime2), CAST(N'2021-08-01T18:12:56.6169461' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3001, CAST(N'2021-08-01T18:12:57.4685237' AS DateTime2), CAST(N'2021-08-01T18:14:52.4538360' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3002, CAST(N'2021-08-01T18:14:53.2929990' AS DateTime2), CAST(N'2021-08-01T18:20:07.4498084' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3003, CAST(N'2021-08-01T18:20:08.3911763' AS DateTime2), CAST(N'2021-08-02T12:15:10.1531291' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3004, CAST(N'2021-08-01T18:48:01.6993028' AS DateTime2), CAST(N'2021-08-01T18:50:25.9720276' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3005, CAST(N'2021-08-01T18:50:26.6692501' AS DateTime2), CAST(N'2021-08-02T13:27:54.1688082' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3006, CAST(N'2021-08-01T19:49:43.1020602' AS DateTime2), CAST(N'2021-08-01T19:52:04.3866506' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3007, CAST(N'2021-08-01T19:52:05.1381645' AS DateTime2), CAST(N'2021-08-01T20:01:06.9840310' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3008, CAST(N'2021-08-01T20:01:07.8218818' AS DateTime2), CAST(N'2021-08-02T10:26:27.2785998' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3009, CAST(N'2021-08-02T00:26:42.0923434' AS DateTime2), CAST(N'2021-08-02T14:49:15.4699235' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3010, CAST(N'2021-08-02T09:21:59.1284539' AS DateTime2), CAST(N'2021-08-02T09:23:37.8320920' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3011, CAST(N'2021-08-02T09:23:41.6315822' AS DateTime2), CAST(N'2021-08-02T09:25:17.0736247' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3012, CAST(N'2021-08-02T09:25:17.8490991' AS DateTime2), CAST(N'2021-08-02T09:28:29.7207495' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3013, CAST(N'2021-08-02T09:28:30.6338144' AS DateTime2), CAST(N'2021-08-02T09:30:21.0194114' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3014, CAST(N'2021-08-02T09:30:21.7558154' AS DateTime2), CAST(N'2021-08-02T09:35:16.7440838' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3015, CAST(N'2021-08-02T09:35:18.8044007' AS DateTime2), CAST(N'2021-08-02T09:37:05.0037803' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3016, CAST(N'2021-08-02T09:37:06.4176498' AS DateTime2), CAST(N'2021-08-02T09:39:00.2652750' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3017, CAST(N'2021-08-02T09:39:00.9905488' AS DateTime2), CAST(N'2021-08-02T09:42:22.2711427' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3018, CAST(N'2021-08-02T09:42:22.9975071' AS DateTime2), CAST(N'2021-08-02T09:45:35.1444561' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3019, CAST(N'2021-08-02T09:45:35.9386674' AS DateTime2), CAST(N'2021-08-02T09:47:03.2590251' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3020, CAST(N'2021-08-02T09:47:04.0089663' AS DateTime2), CAST(N'2021-08-02T09:48:13.1226162' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3021, CAST(N'2021-08-02T09:48:14.1068846' AS DateTime2), CAST(N'2021-08-02T09:49:23.6745590' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3022, CAST(N'2021-08-02T09:49:24.4126365' AS DateTime2), CAST(N'2021-08-02T09:54:21.0745739' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3023, CAST(N'2021-08-02T09:54:21.8743038' AS DateTime2), CAST(N'2021-08-02T10:46:00.5792081' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3024, CAST(N'2021-08-02T10:26:28.1330586' AS DateTime2), CAST(N'2021-08-02T10:28:51.1177298' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3025, CAST(N'2021-08-02T10:28:51.9601969' AS DateTime2), CAST(N'2021-08-02T10:41:21.0965695' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3026, CAST(N'2021-08-02T10:41:21.8944058' AS DateTime2), CAST(N'2021-08-02T10:43:55.3310601' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3027, CAST(N'2021-08-02T10:43:56.2892965' AS DateTime2), CAST(N'2021-08-02T10:45:41.7102471' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3028, CAST(N'2021-08-02T10:45:42.5431942' AS DateTime2), CAST(N'2021-08-02T10:49:58.3929102' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3029, CAST(N'2021-08-02T10:46:01.5238921' AS DateTime2), CAST(N'2021-08-02T10:47:47.2785939' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3030, CAST(N'2021-08-02T10:47:48.3088480' AS DateTime2), CAST(N'2021-08-02T10:57:12.7234369' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3031, CAST(N'2021-08-02T10:50:00.1475735' AS DateTime2), CAST(N'2021-08-02T10:56:41.4240537' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3032, CAST(N'2021-08-02T10:56:42.3332764' AS DateTime2), CAST(N'2021-08-02T11:00:18.7360480' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3033, CAST(N'2021-08-02T10:57:13.4684690' AS DateTime2), CAST(N'2021-08-02T10:59:04.3523060' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3034, CAST(N'2021-08-02T10:59:05.3296065' AS DateTime2), CAST(N'2021-08-02T11:04:00.5497859' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3035, CAST(N'2021-08-02T11:00:19.6760569' AS DateTime2), CAST(N'2021-08-02T11:02:21.6257580' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3036, CAST(N'2021-08-02T11:02:22.3501383' AS DateTime2), CAST(N'2021-08-02T11:04:09.8130704' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3037, CAST(N'2021-08-02T11:04:01.5421919' AS DateTime2), CAST(N'2021-08-02T11:06:37.9713990' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3038, CAST(N'2021-08-02T11:04:10.5435521' AS DateTime2), CAST(N'2021-08-02T11:09:11.1381079' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3039, CAST(N'2021-08-02T11:06:38.7878355' AS DateTime2), CAST(N'2021-08-02T11:09:30.9584620' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3040, CAST(N'2021-08-02T11:09:12.4913554' AS DateTime2), CAST(N'2021-08-02T11:11:31.1901653' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3041, CAST(N'2021-08-02T11:09:31.7406658' AS DateTime2), CAST(N'2021-08-02T11:11:30.3426569' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3042, CAST(N'2021-08-02T11:11:31.1063159' AS DateTime2), CAST(N'2021-08-02T11:14:10.3310251' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3043, CAST(N'2021-08-02T11:11:31.9148831' AS DateTime2), CAST(N'2021-08-02T11:14:09.0802164' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3044, CAST(N'2021-08-02T11:14:10.0010148' AS DateTime2), CAST(N'2021-08-02T11:24:17.2260002' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3045, CAST(N'2021-08-02T11:14:11.1037767' AS DateTime2), CAST(N'2021-08-02T11:31:46.9773790' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3046, CAST(N'2021-08-02T11:24:18.3751299' AS DateTime2), CAST(N'2021-08-02T11:26:37.8544560' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3047, CAST(N'2021-08-02T11:26:38.8346374' AS DateTime2), CAST(N'2021-08-02T11:28:09.3511883' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3048, CAST(N'2021-08-02T11:28:10.1571665' AS DateTime2), CAST(N'2021-08-02T11:31:42.5435063' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3049, CAST(N'2021-08-02T11:31:43.2814757' AS DateTime2), CAST(N'2021-08-02T11:55:32.3861551' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3050, CAST(N'2021-08-02T11:31:47.7805374' AS DateTime2), CAST(N'2021-08-02T11:43:41.8859715' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3051, CAST(N'2021-08-02T11:43:43.7636141' AS DateTime2), CAST(N'2021-08-02T11:45:42.5484341' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3052, CAST(N'2021-08-02T11:45:43.4174063' AS DateTime2), CAST(N'2021-08-02T11:56:42.1743490' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3053, CAST(N'2021-08-02T11:55:33.1234725' AS DateTime2), CAST(N'2021-08-02T12:14:04.8885376' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3054, CAST(N'2021-08-02T11:56:42.9895005' AS DateTime2), CAST(N'2021-08-02T11:58:53.9753368' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3055, CAST(N'2021-08-02T11:58:54.6854955' AS DateTime2), CAST(N'2021-08-02T12:01:30.7266842' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3056, CAST(N'2021-08-02T12:01:31.4755031' AS DateTime2), CAST(N'2021-08-02T12:04:13.6415855' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3057, CAST(N'2021-08-02T12:04:14.3816914' AS DateTime2), CAST(N'2021-08-02T12:06:21.4952931' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3058, CAST(N'2021-08-02T12:06:22.2608993' AS DateTime2), CAST(N'2021-08-02T12:07:29.1679252' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3059, CAST(N'2021-08-02T12:07:29.9435194' AS DateTime2), CAST(N'2021-08-02T12:09:03.8070154' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3060, CAST(N'2021-08-02T12:09:06.4173445' AS DateTime2), CAST(N'2021-08-02T12:17:46.6644870' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3061, CAST(N'2021-08-02T12:14:05.8024881' AS DateTime2), CAST(N'2021-08-02T12:35:38.2417719' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3062, CAST(N'2021-08-02T12:15:10.8834502' AS DateTime2), CAST(N'2021-08-02T12:17:07.3666354' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3063, CAST(N'2021-08-02T12:17:09.3438408' AS DateTime2), CAST(N'2021-08-02T12:20:11.8386089' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3064, CAST(N'2021-08-02T12:17:50.4709232' AS DateTime2), CAST(N'2021-08-02T12:19:09.2120757' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3065, CAST(N'2021-08-02T12:19:10.0206109' AS DateTime2), CAST(N'2021-08-02T12:20:57.3663468' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3066, CAST(N'2021-08-02T12:20:12.6050642' AS DateTime2), CAST(N'2021-08-02T12:21:35.4338326' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3067, CAST(N'2021-08-02T12:20:58.1777718' AS DateTime2), CAST(N'2021-08-02T12:24:07.8972810' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3068, CAST(N'2021-08-02T12:21:36.1798551' AS DateTime2), CAST(N'2021-08-02T12:24:20.5072106' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3069, CAST(N'2021-08-02T12:24:08.6432519' AS DateTime2), CAST(N'2021-08-02T12:41:45.8891841' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3070, CAST(N'2021-08-02T12:24:21.2756073' AS DateTime2), CAST(N'2021-08-02T12:35:02.7533181' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3071, CAST(N'2021-08-02T12:35:03.6889418' AS DateTime2), CAST(N'2021-08-02T12:36:19.6867957' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3072, CAST(N'2021-08-02T12:35:39.1696799' AS DateTime2), CAST(N'2021-08-02T12:37:46.7925741' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3073, CAST(N'2021-08-02T12:36:20.4143609' AS DateTime2), CAST(N'2021-08-02T12:37:06.0762734' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3074, CAST(N'2021-08-02T12:37:06.8417450' AS DateTime2), CAST(N'2021-08-02T12:49:52.3677312' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3075, CAST(N'2021-08-02T12:37:47.5209470' AS DateTime2), CAST(N'2021-08-02T12:38:29.2735699' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3076, CAST(N'2021-08-02T12:38:29.9820207' AS DateTime2), CAST(N'2021-08-02T12:39:20.8363313' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3077, CAST(N'2021-08-02T12:39:21.5318390' AS DateTime2), CAST(N'2021-08-02T12:44:20.4340054' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3078, CAST(N'2021-08-02T12:41:46.6598181' AS DateTime2), CAST(N'2021-08-02T12:45:31.8332802' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3079, CAST(N'2021-08-02T12:44:21.1975351' AS DateTime2), CAST(N'2021-08-02T12:45:53.1026563' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3080, CAST(N'2021-08-02T12:45:32.5718697' AS DateTime2), CAST(N'2021-08-02T12:49:16.5010454' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3081, CAST(N'2021-08-02T12:45:53.7999450' AS DateTime2), CAST(N'2021-08-02T12:49:30.2233221' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3082, CAST(N'2021-08-02T12:49:20.5216062' AS DateTime2), CAST(N'2021-08-02T12:53:58.2921425' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3083, CAST(N'2021-08-02T12:49:31.2418206' AS DateTime2), CAST(N'2021-08-02T12:53:35.3537156' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3084, CAST(N'2021-08-02T12:49:53.5418421' AS DateTime2), CAST(N'2021-08-02T12:54:28.0228406' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3085, CAST(N'2021-08-02T12:53:37.1045000' AS DateTime2), CAST(N'2021-08-02T12:56:40.8507417' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3086, CAST(N'2021-08-02T12:53:59.1004164' AS DateTime2), CAST(N'2021-08-02T12:56:33.3568464' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3087, CAST(N'2021-08-02T12:54:28.8178012' AS DateTime2), CAST(N'2021-08-02T13:12:45.4815261' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3088, CAST(N'2021-08-02T12:56:34.0926184' AS DateTime2), CAST(N'2021-08-02T12:57:12.3579019' AS DateTime2), 2, 4)
GO
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3089, CAST(N'2021-08-02T12:56:41.5167895' AS DateTime2), CAST(N'2021-08-02T12:58:45.2279206' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3090, CAST(N'2021-08-02T12:57:13.1244877' AS DateTime2), CAST(N'2021-08-02T12:59:20.6627073' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3091, CAST(N'2021-08-02T12:58:46.0130159' AS DateTime2), CAST(N'2021-08-02T12:59:48.3957562' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3092, CAST(N'2021-08-02T12:59:21.4508318' AS DateTime2), CAST(N'2021-08-02T13:00:46.9561420' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3093, CAST(N'2021-08-02T12:59:53.4004316' AS DateTime2), CAST(N'2021-08-02T13:00:22.9170579' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3094, CAST(N'2021-08-02T13:00:23.6318226' AS DateTime2), CAST(N'2021-08-02T13:02:00.2061684' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3095, CAST(N'2021-08-02T13:00:47.6698369' AS DateTime2), CAST(N'2021-08-02T13:02:02.9696016' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3096, CAST(N'2021-08-02T13:02:00.9753694' AS DateTime2), CAST(N'2021-08-02T13:04:26.0917357' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3097, CAST(N'2021-08-02T13:02:03.7144723' AS DateTime2), CAST(N'2021-08-02T13:03:57.6538072' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3098, CAST(N'2021-08-02T13:03:58.4038712' AS DateTime2), CAST(N'2021-08-02T13:07:14.8054831' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3099, CAST(N'2021-08-02T13:04:26.7987141' AS DateTime2), CAST(N'2021-08-02T13:07:33.6189559' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3100, CAST(N'2021-08-02T13:07:15.7431063' AS DateTime2), CAST(N'2021-08-02T13:08:33.3357115' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3101, CAST(N'2021-08-02T13:07:34.3241815' AS DateTime2), CAST(N'2021-08-02T13:11:24.7601446' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3102, CAST(N'2021-08-02T13:08:34.0603358' AS DateTime2), CAST(N'2021-08-02T13:11:02.3122714' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3103, CAST(N'2021-08-02T13:11:03.0923970' AS DateTime2), CAST(N'2021-08-02T13:14:28.5503529' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3104, CAST(N'2021-08-02T13:11:25.4856005' AS DateTime2), CAST(N'2021-08-02T13:13:55.6253509' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3105, CAST(N'2021-08-02T13:12:46.2821006' AS DateTime2), CAST(N'2021-08-02T13:17:55.7999395' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3106, CAST(N'2021-08-02T13:13:56.3712541' AS DateTime2), CAST(N'2021-08-02T13:19:56.4081366' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3107, CAST(N'2021-08-02T13:14:29.4769042' AS DateTime2), CAST(N'2021-08-02T13:16:23.8898347' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3108, CAST(N'2021-08-02T13:16:25.0179411' AS DateTime2), CAST(N'2021-08-02T13:36:16.9830551' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3109, CAST(N'2021-08-02T13:17:56.6624929' AS DateTime2), CAST(N'2021-08-02T14:34:08.6730065' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3110, CAST(N'2021-08-02T13:19:58.1648750' AS DateTime2), CAST(N'2021-08-02T13:20:48.5490576' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3111, CAST(N'2021-08-02T13:20:49.2190719' AS DateTime2), CAST(N'2021-08-02T13:39:08.4583373' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3112, CAST(N'2021-08-02T13:27:54.9783931' AS DateTime2), CAST(N'2021-08-02T13:41:02.9915469' AS DateTime2), 9, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3113, CAST(N'2021-08-02T13:36:17.9779221' AS DateTime2), CAST(N'2021-08-02T13:39:23.5082823' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3114, CAST(N'2021-08-02T13:39:09.1398912' AS DateTime2), CAST(N'2021-08-02T14:13:42.5332051' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3115, CAST(N'2021-08-02T13:39:24.5394130' AS DateTime2), CAST(N'2021-08-02T13:51:16.3817958' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3116, CAST(N'2021-08-02T13:51:17.1028319' AS DateTime2), CAST(N'2021-08-02T13:58:04.0235984' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3117, CAST(N'2021-08-02T13:58:05.6035785' AS DateTime2), CAST(N'2021-08-02T14:00:19.3346984' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3118, CAST(N'2021-08-02T14:00:20.1357659' AS DateTime2), CAST(N'2021-08-02T14:43:23.1526856' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3119, CAST(N'2021-08-02T14:13:43.2332790' AS DateTime2), CAST(N'2021-08-02T14:18:54.3018824' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3120, CAST(N'2021-08-02T14:18:56.0164790' AS DateTime2), CAST(N'2021-08-02T14:27:26.0710711' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3121, CAST(N'2021-08-02T14:27:26.7977428' AS DateTime2), CAST(N'2021-08-02T14:43:50.7929695' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3122, CAST(N'2021-08-02T14:34:09.4582020' AS DateTime2), CAST(N'2021-08-02T14:37:18.6130825' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3123, CAST(N'2021-08-02T14:37:19.3903900' AS DateTime2), CAST(N'2021-08-02T15:01:45.8590976' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3124, CAST(N'2021-08-02T14:43:14.0047507' AS DateTime2), CAST(N'2021-08-02T14:46:43.9772429' AS DateTime2), 9, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3125, CAST(N'2021-08-02T14:43:24.1310405' AS DateTime2), CAST(N'2021-08-02T14:47:42.3225731' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3126, CAST(N'2021-08-02T14:43:51.5048236' AS DateTime2), CAST(N'2021-08-02T14:49:21.3895253' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3127, CAST(N'2021-08-02T14:46:46.2834284' AS DateTime2), CAST(N'2021-08-02T14:56:47.3691625' AS DateTime2), 9, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3128, CAST(N'2021-08-02T14:47:43.1946274' AS DateTime2), CAST(N'2021-08-02T14:56:47.5595539' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3129, CAST(N'2021-08-02T14:49:16.1606119' AS DateTime2), CAST(N'2021-08-02T15:40:45.4692561' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3130, CAST(N'2021-08-02T14:49:24.9776188' AS DateTime2), CAST(N'2021-08-02T14:52:27.9853007' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3131, CAST(N'2021-08-02T14:52:28.9676704' AS DateTime2), CAST(N'2021-08-03T10:52:02.2141159' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3132, CAST(N'2021-08-02T14:56:48.5867878' AS DateTime2), CAST(N'2021-08-02T14:58:26.1832447' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3133, CAST(N'2021-08-02T14:57:29.8443564' AS DateTime2), CAST(N'2021-08-02T14:57:36.3107101' AS DateTime2), 9, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3134, CAST(N'2021-08-02T14:58:18.0634661' AS DateTime2), CAST(N'2021-08-02T15:02:32.4581736' AS DateTime2), 9, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3135, CAST(N'2021-08-02T14:58:27.2439988' AS DateTime2), CAST(N'2021-08-02T15:00:56.8109186' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3136, CAST(N'2021-08-02T15:00:57.5589079' AS DateTime2), CAST(N'2021-08-02T15:01:46.7998825' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3137, CAST(N'2021-08-02T15:01:46.6601078' AS DateTime2), CAST(N'2021-08-02T16:24:11.2060188' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3138, CAST(N'2021-08-02T15:01:47.5562965' AS DateTime2), CAST(N'2021-08-02T15:37:38.3577007' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3139, CAST(N'2021-08-02T15:37:39.2015443' AS DateTime2), CAST(N'2021-08-02T15:56:41.7997553' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3140, CAST(N'2021-08-02T15:40:43.6723468' AS DateTime2), CAST(N'2021-08-02T15:41:26.8602388' AS DateTime2), 9, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3141, CAST(N'2021-08-02T15:40:46.1721721' AS DateTime2), CAST(N'2021-08-02T15:50:54.8508050' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3142, CAST(N'2021-08-02T15:50:55.5541372' AS DateTime2), CAST(N'2021-08-02T16:49:57.9660293' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3143, CAST(N'2021-08-02T15:56:43.6437185' AS DateTime2), CAST(N'2021-08-02T15:57:47.8468723' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3144, CAST(N'2021-08-02T15:57:48.6438148' AS DateTime2), CAST(N'2021-08-02T16:00:23.6747965' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3145, CAST(N'2021-08-02T16:00:24.4403496' AS DateTime2), CAST(N'2021-08-02T16:01:52.7771821' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3146, CAST(N'2021-08-02T16:01:53.5584781' AS DateTime2), CAST(N'2021-08-02T16:05:22.2170935' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3147, CAST(N'2021-08-02T16:05:22.9513441' AS DateTime2), CAST(N'2021-08-02T16:07:18.4825976' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3148, CAST(N'2021-08-02T16:07:19.2643531' AS DateTime2), CAST(N'2021-08-02T16:09:09.8891897' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3149, CAST(N'2021-08-02T16:09:10.6080323' AS DateTime2), CAST(N'2021-08-02T16:10:33.9063908' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3150, CAST(N'2021-08-02T16:10:34.6252332' AS DateTime2), CAST(N'2021-08-02T16:11:09.0943692' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3151, CAST(N'2021-08-02T16:11:09.8284578' AS DateTime2), CAST(N'2021-08-02T16:12:44.1292427' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3152, CAST(N'2021-08-02T16:11:12.3769861' AS DateTime2), CAST(N'2021-08-02T16:31:36.8549004' AS DateTime2), 9, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3153, CAST(N'2021-08-02T16:12:44.8636934' AS DateTime2), CAST(N'2021-08-02T16:14:13.4003907' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3154, CAST(N'2021-08-02T16:14:14.1454029' AS DateTime2), CAST(N'2021-08-02T16:29:39.0218791' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3155, CAST(N'2021-08-02T16:24:12.3934980' AS DateTime2), CAST(N'2021-08-02T16:42:14.8456841' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3156, CAST(N'2021-08-02T16:29:39.8345051' AS DateTime2), CAST(N'2021-08-02T16:31:09.9013221' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3157, CAST(N'2021-08-02T16:31:10.9015342' AS DateTime2), CAST(N'2021-08-02T16:32:38.4077374' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3158, CAST(N'2021-08-02T16:32:39.2672262' AS DateTime2), CAST(N'2021-08-02T16:33:53.4292823' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3159, CAST(N'2021-08-02T16:33:54.2246833' AS DateTime2), CAST(N'2021-08-02T16:35:39.5072597' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3160, CAST(N'2021-08-02T16:35:40.1788784' AS DateTime2), CAST(N'2021-08-02T16:40:44.7889068' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3161, CAST(N'2021-08-02T16:40:45.5388102' AS DateTime2), CAST(N'2021-08-02T16:43:11.8165642' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3162, CAST(N'2021-08-02T16:42:15.6423242' AS DateTime2), CAST(N'2021-08-02T16:50:51.8493108' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3163, CAST(N'2021-08-02T16:43:12.7402029' AS DateTime2), CAST(N'2021-08-02T16:49:46.4042993' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3164, CAST(N'2021-08-02T16:47:01.3485806' AS DateTime2), CAST(N'2021-08-02T16:49:30.6074843' AS DateTime2), 9, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3165, CAST(N'2021-08-02T16:49:47.2743546' AS DateTime2), CAST(N'2021-08-02T16:57:13.8605822' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3166, CAST(N'2021-08-02T16:49:58.6849610' AS DateTime2), CAST(N'2021-08-03T10:08:23.3759331' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3167, CAST(N'2021-08-02T16:50:52.7723247' AS DateTime2), CAST(N'2021-08-02T17:01:56.1435710' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3168, CAST(N'2021-08-02T16:57:14.6709117' AS DateTime2), CAST(N'2021-08-02T16:58:42.9408546' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3169, CAST(N'2021-08-02T16:58:43.6685920' AS DateTime2), CAST(N'2021-08-03T15:34:17.8308360' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3170, CAST(N'2021-08-02T17:01:56.8935113' AS DateTime2), CAST(N'2021-08-02T17:22:56.5158393' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3171, CAST(N'2021-08-02T17:22:57.3330451' AS DateTime2), CAST(N'2021-08-02T17:28:14.2359889' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3172, CAST(N'2021-08-02T17:28:20.0031460' AS DateTime2), CAST(N'2021-08-02T17:37:04.7064829' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3173, CAST(N'2021-08-02T17:37:05.5791639' AS DateTime2), CAST(N'2021-08-02T17:38:50.5521146' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3174, CAST(N'2021-08-02T17:38:51.3519640' AS DateTime2), CAST(N'2021-08-02T17:43:29.7621913' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3175, CAST(N'2021-08-02T17:43:31.5513081' AS DateTime2), CAST(N'2021-08-02T17:50:43.0614835' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3176, CAST(N'2021-08-02T17:50:43.9490118' AS DateTime2), CAST(N'2021-08-02T17:51:43.1052031' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3177, CAST(N'2021-08-02T17:51:43.8853151' AS DateTime2), CAST(N'2021-08-02T17:57:02.8921904' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3178, CAST(N'2021-08-02T17:57:03.7864871' AS DateTime2), CAST(N'2021-08-02T18:07:09.5137275' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3179, CAST(N'2021-08-02T18:06:19.2638410' AS DateTime2), CAST(N'2021-08-02T18:07:42.9522110' AS DateTime2), 9, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3180, CAST(N'2021-08-02T18:07:10.3916643' AS DateTime2), CAST(N'2021-08-02T18:11:57.1711741' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3181, CAST(N'2021-08-02T18:11:58.4071585' AS DateTime2), CAST(N'2021-08-02T18:17:26.2160603' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3182, CAST(N'2021-08-02T18:17:27.0209124' AS DateTime2), CAST(N'2021-08-02T18:20:15.7468102' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3183, CAST(N'2021-08-02T18:20:16.5293339' AS DateTime2), CAST(N'2021-08-02T18:22:13.8900948' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3184, CAST(N'2021-08-02T18:22:14.8306157' AS DateTime2), CAST(N'2021-08-03T11:50:20.0812321' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3185, CAST(N'2021-08-02T23:43:42.0865908' AS DateTime2), CAST(N'2021-08-03T14:15:45.7883202' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3186, CAST(N'2021-08-03T10:08:25.0466205' AS DateTime2), CAST(N'2021-08-03T11:05:42.6172124' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3187, CAST(N'2021-08-03T10:52:04.4315048' AS DateTime2), CAST(N'2021-08-03T10:53:28.3374063' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3188, CAST(N'2021-08-03T10:53:29.1839667' AS DateTime2), CAST(N'2021-08-03T11:05:13.8785243' AS DateTime2), 2, 3)
GO
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3189, CAST(N'2021-08-03T11:05:14.7751967' AS DateTime2), CAST(N'2021-08-03T11:08:53.2089235' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3190, CAST(N'2021-08-03T11:05:43.4255599' AS DateTime2), CAST(N'2021-08-03T12:54:29.5375440' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3191, CAST(N'2021-08-03T11:08:55.2762924' AS DateTime2), CAST(N'2021-08-03T11:10:21.6434597' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3192, CAST(N'2021-08-03T11:10:22.4220228' AS DateTime2), CAST(N'2021-08-03T11:13:53.3921288' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3193, CAST(N'2021-08-03T11:13:54.1429750' AS DateTime2), CAST(N'2021-08-03T11:14:40.0194515' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3194, CAST(N'2021-08-03T11:14:40.9108681' AS DateTime2), CAST(N'2021-08-03T11:17:59.1740955' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3195, CAST(N'2021-08-03T11:17:59.9671233' AS DateTime2), CAST(N'2021-08-03T11:23:30.1334309' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3196, CAST(N'2021-08-03T11:23:30.8883402' AS DateTime2), CAST(N'2021-08-03T11:28:23.9630149' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3197, CAST(N'2021-08-03T11:28:24.9835025' AS DateTime2), CAST(N'2021-08-03T11:39:58.6339629' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3198, CAST(N'2021-08-03T11:39:59.8416481' AS DateTime2), CAST(N'2021-08-03T11:41:20.3170139' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3199, CAST(N'2021-08-03T11:41:21.0941738' AS DateTime2), CAST(N'2021-08-03T12:45:06.7929305' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3200, CAST(N'2021-08-03T11:50:21.3753989' AS DateTime2), CAST(N'2021-08-03T12:03:43.4569233' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3201, CAST(N'2021-08-03T12:03:44.3526576' AS DateTime2), CAST(N'2021-08-03T12:37:51.3244825' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3202, CAST(N'2021-08-03T12:37:53.2960367' AS DateTime2), CAST(N'2021-08-03T12:51:31.1874033' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3203, CAST(N'2021-08-03T12:45:08.8269162' AS DateTime2), CAST(N'2021-08-03T12:58:32.3543937' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3204, CAST(N'2021-08-03T12:51:32.2825907' AS DateTime2), CAST(N'2021-08-03T13:30:07.9471688' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3205, CAST(N'2021-08-03T12:54:30.3843204' AS DateTime2), CAST(N'2021-08-03T12:56:12.8889819' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3206, CAST(N'2021-08-03T12:56:13.7764444' AS DateTime2), CAST(N'2021-08-03T12:58:05.7880955' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3207, CAST(N'2021-08-03T12:58:06.7268406' AS DateTime2), CAST(N'2021-08-03T15:17:23.6871361' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3208, CAST(N'2021-08-03T12:58:33.2469714' AS DateTime2), CAST(N'2021-08-03T13:10:25.5838579' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3209, CAST(N'2021-08-03T13:10:26.4255938' AS DateTime2), CAST(N'2021-08-03T13:22:21.4079208' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3210, CAST(N'2021-08-03T13:22:22.3492730' AS DateTime2), CAST(N'2021-08-03T13:27:31.4075981' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3211, CAST(N'2021-08-03T13:27:32.4532590' AS DateTime2), CAST(N'2021-08-03T13:34:37.9667366' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3212, CAST(N'2021-08-03T13:30:09.6336741' AS DateTime2), CAST(N'2021-08-03T13:58:16.7588289' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3213, CAST(N'2021-08-03T13:34:39.2877620' AS DateTime2), CAST(N'2021-08-03T13:35:25.8076335' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3214, CAST(N'2021-08-03T13:35:27.1805142' AS DateTime2), CAST(N'2021-08-03T13:36:33.3059585' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3215, CAST(N'2021-08-03T13:36:34.6172123' AS DateTime2), CAST(N'2021-08-03T13:39:28.2346083' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3216, CAST(N'2021-08-03T13:39:29.0659027' AS DateTime2), CAST(N'2021-08-03T13:42:24.8369529' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3217, CAST(N'2021-08-03T13:42:26.0842271' AS DateTime2), CAST(N'2021-08-03T13:43:08.3159201' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3218, CAST(N'2021-08-03T13:43:09.3783710' AS DateTime2), CAST(N'2021-08-03T13:46:25.0234983' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3219, CAST(N'2021-08-03T13:46:29.0429877' AS DateTime2), CAST(N'2021-08-03T13:49:09.3764119' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3220, CAST(N'2021-08-03T13:49:10.2633076' AS DateTime2), CAST(N'2021-08-03T14:01:13.5459289' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3221, CAST(N'2021-08-03T13:58:19.9908039' AS DateTime2), CAST(N'2021-08-03T14:00:34.3673457' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3222, CAST(N'2021-08-03T14:00:35.4659222' AS DateTime2), CAST(N'2021-08-03T14:09:52.2824554' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3223, CAST(N'2021-08-03T14:01:16.4383897' AS DateTime2), CAST(N'2021-08-03T14:24:52.1917134' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3224, CAST(N'2021-08-03T14:09:54.0032613' AS DateTime2), CAST(N'2021-08-03T14:11:23.5235463' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3225, CAST(N'2021-08-03T14:11:24.5313592' AS DateTime2), CAST(N'2021-08-03T14:13:18.5387939' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3226, CAST(N'2021-08-03T14:13:19.4605331' AS DateTime2), CAST(N'2021-08-03T14:16:26.7020573' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3227, CAST(N'2021-08-03T14:15:48.1769417' AS DateTime2), CAST(N'2021-08-03T14:27:42.1524580' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3228, CAST(N'2021-08-03T14:16:27.7741223' AS DateTime2), CAST(N'2021-08-03T14:19:23.1587148' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3229, CAST(N'2021-08-03T14:19:24.0073824' AS DateTime2), CAST(N'2021-08-03T14:21:57.0751115' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3230, CAST(N'2021-08-03T14:21:58.8142440' AS DateTime2), CAST(N'2021-08-03T14:24:25.1871634' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3231, CAST(N'2021-08-03T14:24:26.2889759' AS DateTime2), CAST(N'2021-08-03T14:26:07.1886632' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3232, CAST(N'2021-08-03T14:24:52.9818821' AS DateTime2), CAST(N'2021-08-03T14:26:45.4619433' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3233, CAST(N'2021-08-03T14:26:08.1037018' AS DateTime2), CAST(N'2021-08-03T14:27:55.8048767' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3234, CAST(N'2021-08-03T14:26:46.7492133' AS DateTime2), CAST(N'2021-08-03T14:31:16.5192537' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3235, CAST(N'2021-08-03T14:27:42.9275191' AS DateTime2), CAST(N'2021-08-03T14:29:25.7109389' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3236, CAST(N'2021-08-03T14:27:56.8584694' AS DateTime2), CAST(N'2021-08-03T14:29:11.0915306' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3237, CAST(N'2021-08-03T14:29:11.9159345' AS DateTime2), CAST(N'2021-08-03T14:30:49.0540978' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3238, CAST(N'2021-08-03T14:29:26.4113667' AS DateTime2), CAST(N'2021-08-03T14:35:01.1377028' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3239, CAST(N'2021-08-03T14:30:49.9399865' AS DateTime2), CAST(N'2021-08-03T14:32:35.1271101' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3240, CAST(N'2021-08-03T14:31:17.4215928' AS DateTime2), NULL, 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3241, CAST(N'2021-08-03T14:32:35.9288846' AS DateTime2), CAST(N'2021-08-03T14:37:49.7606000' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3242, CAST(N'2021-08-03T14:35:01.8887555' AS DateTime2), CAST(N'2021-08-03T14:51:44.2289824' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3243, CAST(N'2021-08-03T14:37:51.0662267' AS DateTime2), CAST(N'2021-08-03T14:48:34.2846438' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3244, CAST(N'2021-08-03T14:48:35.3225046' AS DateTime2), CAST(N'2021-08-03T15:00:51.0596388' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3245, CAST(N'2021-08-03T14:51:45.1491005' AS DateTime2), CAST(N'2021-08-03T14:52:33.1085697' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3246, CAST(N'2021-08-03T14:52:33.9747667' AS DateTime2), CAST(N'2021-08-03T14:57:19.0941462' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3247, CAST(N'2021-08-03T14:57:20.3128663' AS DateTime2), CAST(N'2021-08-03T19:11:15.0966529' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3248, CAST(N'2021-08-03T15:00:52.5410974' AS DateTime2), CAST(N'2021-08-03T15:03:46.1875060' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3249, CAST(N'2021-08-03T15:03:46.9491931' AS DateTime2), CAST(N'2021-08-03T15:06:04.4533685' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3250, CAST(N'2021-08-03T15:06:05.2091190' AS DateTime2), CAST(N'2021-08-03T15:10:24.9405923' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3251, CAST(N'2021-08-03T15:10:25.7725690' AS DateTime2), CAST(N'2021-08-03T15:18:13.2829962' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3252, CAST(N'2021-08-03T15:17:24.3759876' AS DateTime2), CAST(N'2021-08-03T16:49:45.3314418' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3253, CAST(N'2021-08-03T15:18:14.2237129' AS DateTime2), CAST(N'2021-08-03T15:34:46.3196363' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3254, CAST(N'2021-08-03T15:34:25.2015875' AS DateTime2), CAST(N'2021-08-03T15:37:25.2993162' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3255, CAST(N'2021-08-03T15:34:48.4464975' AS DateTime2), CAST(N'2021-08-03T15:42:48.2587519' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3256, CAST(N'2021-08-03T15:37:26.6867923' AS DateTime2), CAST(N'2021-08-03T15:37:59.9654093' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3257, CAST(N'2021-08-03T15:38:00.7237888' AS DateTime2), CAST(N'2021-08-03T15:38:41.4569793' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3258, CAST(N'2021-08-03T15:38:42.1915806' AS DateTime2), CAST(N'2021-08-03T15:42:22.7152612' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3259, CAST(N'2021-08-03T15:42:23.5482360' AS DateTime2), CAST(N'2021-08-03T15:45:54.8033557' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3260, CAST(N'2021-08-03T15:42:49.1080655' AS DateTime2), CAST(N'2021-08-03T15:46:36.8624525' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3261, CAST(N'2021-08-03T15:45:57.4633144' AS DateTime2), CAST(N'2021-08-03T15:54:13.2856196' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3262, CAST(N'2021-08-03T15:46:38.0345508' AS DateTime2), CAST(N'2021-08-03T15:49:03.7905528' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3263, CAST(N'2021-08-03T15:49:04.4771966' AS DateTime2), CAST(N'2021-08-03T15:50:19.7973225' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3264, CAST(N'2021-08-03T15:50:20.7739251' AS DateTime2), CAST(N'2021-08-03T15:56:15.3082100' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3265, CAST(N'2021-08-03T15:54:14.6496649' AS DateTime2), CAST(N'2021-08-03T15:55:23.8233295' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3266, CAST(N'2021-08-03T15:55:28.6964134' AS DateTime2), CAST(N'2021-08-03T15:57:28.1788793' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3267, CAST(N'2021-08-03T15:56:19.1566381' AS DateTime2), CAST(N'2021-08-03T15:58:23.1486980' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3268, CAST(N'2021-08-03T15:57:29.8301425' AS DateTime2), CAST(N'2021-08-03T15:59:30.9522002' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3269, CAST(N'2021-08-03T15:58:24.7696583' AS DateTime2), CAST(N'2021-08-03T16:47:33.4690031' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3270, CAST(N'2021-08-03T15:59:32.1193511' AS DateTime2), CAST(N'2021-08-03T16:00:47.1767030' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3271, CAST(N'2021-08-03T16:00:48.0335990' AS DateTime2), CAST(N'2021-08-03T16:07:16.6002055' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3272, CAST(N'2021-08-03T16:07:17.5339206' AS DateTime2), CAST(N'2021-08-03T16:10:05.9407121' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3273, CAST(N'2021-08-03T16:10:08.0059346' AS DateTime2), CAST(N'2021-08-03T16:16:06.4374917' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3274, CAST(N'2021-08-03T16:16:07.4909648' AS DateTime2), CAST(N'2021-08-03T16:22:28.5667604' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3275, CAST(N'2021-08-03T16:22:30.3953307' AS DateTime2), CAST(N'2021-08-03T16:24:45.2267936' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3276, CAST(N'2021-08-03T16:24:46.0083445' AS DateTime2), CAST(N'2021-08-03T16:26:23.8997465' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3277, CAST(N'2021-08-03T16:26:24.9310994' AS DateTime2), CAST(N'2021-08-03T16:28:41.5211754' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3278, CAST(N'2021-08-03T16:28:42.2557275' AS DateTime2), CAST(N'2021-08-03T16:30:59.4280093' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3279, CAST(N'2021-08-03T16:31:03.2108436' AS DateTime2), CAST(N'2021-08-03T16:42:38.7645847' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3280, CAST(N'2021-08-03T16:42:40.4198096' AS DateTime2), NULL, 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3281, CAST(N'2021-08-03T16:47:35.4197640' AS DateTime2), CAST(N'2021-08-03T17:00:53.0538188' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3282, CAST(N'2021-08-03T16:49:46.0530271' AS DateTime2), CAST(N'2021-08-03T17:01:30.5843252' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3283, CAST(N'2021-08-03T17:00:54.9394433' AS DateTime2), CAST(N'2021-08-03T17:17:31.7636587' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3284, CAST(N'2021-08-03T17:01:31.2649578' AS DateTime2), CAST(N'2021-08-04T10:22:42.9120757' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3285, CAST(N'2021-08-03T17:17:32.5429957' AS DateTime2), CAST(N'2021-08-03T17:32:09.0343350' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3286, CAST(N'2021-08-03T17:32:10.2061527' AS DateTime2), CAST(N'2021-08-03T17:50:48.8859458' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3287, CAST(N'2021-08-03T17:50:49.7921355' AS DateTime2), CAST(N'2021-08-03T17:54:28.6020516' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3288, CAST(N'2021-08-03T17:54:29.3678751' AS DateTime2), CAST(N'2021-08-03T18:02:01.3980701' AS DateTime2), 2, 2)
GO
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3289, CAST(N'2021-08-03T18:02:02.2578326' AS DateTime2), CAST(N'2021-08-03T18:12:22.9169245' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3290, CAST(N'2021-08-03T18:12:23.6871179' AS DateTime2), CAST(N'2021-08-03T18:25:05.1473851' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3291, CAST(N'2021-08-03T18:25:06.8504961' AS DateTime2), CAST(N'2021-08-03T18:32:34.8164210' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3292, CAST(N'2021-08-03T18:32:36.0817264' AS DateTime2), NULL, 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3293, CAST(N'2021-08-03T19:11:17.1257412' AS DateTime2), CAST(N'2021-08-03T19:11:43.8394003' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3294, CAST(N'2021-08-03T19:11:47.5939779' AS DateTime2), CAST(N'2021-08-04T11:08:28.8759479' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3295, CAST(N'2021-08-04T10:22:44.6151805' AS DateTime2), NULL, 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3296, CAST(N'2021-08-04T11:08:30.6491402' AS DateTime2), NULL, 2, 9)
SET IDENTITY_INSERT [dbo].[usersLogs] OFF
GO
ALTER TABLE [dbo].[countriesCodes] ADD  CONSTRAINT [DF_countriesCodes_isDefault]  DEFAULT ((0)) FOR [isDefault]
GO
ALTER TABLE [dbo].[packages] ADD  CONSTRAINT [DF_packages_quantity]  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[packages] ADD  CONSTRAINT [DF_packages_isActive]  DEFAULT ((1)) FOR [isActive]
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
