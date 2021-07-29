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
ALTER TABLE [dbo].[packages] DROP CONSTRAINT [DF_packages_isActive]
GO
ALTER TABLE [dbo].[packages] DROP CONSTRAINT [DF_packages_quantity]
GO
ALTER TABLE [dbo].[countriesCodes] DROP CONSTRAINT [DF_countriesCodes_isDefault]
GO
/****** Object:  Table [dbo].[usersLogs]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usersLogs]') AND type in (N'U'))
DROP TABLE [dbo].[usersLogs]
GO
/****** Object:  Table [dbo].[userSetValues]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[userSetValues]') AND type in (N'U'))
DROP TABLE [dbo].[userSetValues]
GO
/****** Object:  Table [dbo].[users]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type in (N'U'))
DROP TABLE [dbo].[users]
GO
/****** Object:  Table [dbo].[units]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[units]') AND type in (N'U'))
DROP TABLE [dbo].[units]
GO
/****** Object:  Table [dbo].[sysEmails]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sysEmails]') AND type in (N'U'))
DROP TABLE [dbo].[sysEmails]
GO
/****** Object:  Table [dbo].[subscriptionFees]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subscriptionFees]') AND type in (N'U'))
DROP TABLE [dbo].[subscriptionFees]
GO
/****** Object:  Table [dbo].[storageCost]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[storageCost]') AND type in (N'U'))
DROP TABLE [dbo].[storageCost]
GO
/****** Object:  Table [dbo].[shippingCompanies]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[shippingCompanies]') AND type in (N'U'))
DROP TABLE [dbo].[shippingCompanies]
GO
/****** Object:  Table [dbo].[setValues]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setValues]') AND type in (N'U'))
DROP TABLE [dbo].[setValues]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setting]') AND type in (N'U'))
DROP TABLE [dbo].[setting]
GO
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[servicesCosts]') AND type in (N'U'))
DROP TABLE [dbo].[servicesCosts]
GO
/****** Object:  Table [dbo].[serials]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[serials]') AND type in (N'U'))
DROP TABLE [dbo].[serials]
GO
/****** Object:  Table [dbo].[sections]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sections]') AND type in (N'U'))
DROP TABLE [dbo].[sections]
GO
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[propertiesItems]') AND type in (N'U'))
DROP TABLE [dbo].[propertiesItems]
GO
/****** Object:  Table [dbo].[properties]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[properties]') AND type in (N'U'))
DROP TABLE [dbo].[properties]
GO
/****** Object:  Table [dbo].[posUsers]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[posUsers]') AND type in (N'U'))
DROP TABLE [dbo].[posUsers]
GO
/****** Object:  Table [dbo].[pos]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pos]') AND type in (N'U'))
DROP TABLE [dbo].[pos]
GO
/****** Object:  Table [dbo].[Points]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Points]') AND type in (N'U'))
DROP TABLE [dbo].[Points]
GO
/****** Object:  Table [dbo].[packages]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[packages]') AND type in (N'U'))
DROP TABLE [dbo].[packages]
GO
/****** Object:  Table [dbo].[offers]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[offers]') AND type in (N'U'))
DROP TABLE [dbo].[offers]
GO
/****** Object:  Table [dbo].[objects]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[objects]') AND type in (N'U'))
DROP TABLE [dbo].[objects]
GO
/****** Object:  Table [dbo].[memberships]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[memberships]') AND type in (N'U'))
DROP TABLE [dbo].[memberships]
GO
/****** Object:  Table [dbo].[medals]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medals]') AND type in (N'U'))
DROP TABLE [dbo].[medals]
GO
/****** Object:  Table [dbo].[medalAgent]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medalAgent]') AND type in (N'U'))
DROP TABLE [dbo].[medalAgent]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[locations]') AND type in (N'U'))
DROP TABLE [dbo].[locations]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemTransferOffer]') AND type in (N'U'))
DROP TABLE [dbo].[itemTransferOffer]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsUnits]') AND type in (N'U'))
DROP TABLE [dbo].[itemsUnits]
GO
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[itemsTransfer]
GO
/****** Object:  Table [dbo].[itemsProp]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsProp]') AND type in (N'U'))
DROP TABLE [dbo].[itemsProp]
GO
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsOffers]') AND type in (N'U'))
DROP TABLE [dbo].[itemsOffers]
GO
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsMaterials]') AND type in (N'U'))
DROP TABLE [dbo].[itemsMaterials]
GO
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsLocations]') AND type in (N'U'))
DROP TABLE [dbo].[itemsLocations]
GO
/****** Object:  Table [dbo].[items]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[items]') AND type in (N'U'))
DROP TABLE [dbo].[items]
GO
/****** Object:  Table [dbo].[invoiceStatus]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoiceStatus]') AND type in (N'U'))
DROP TABLE [dbo].[invoiceStatus]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoices]') AND type in (N'U'))
DROP TABLE [dbo].[invoices]
GO
/****** Object:  Table [dbo].[inventoryItemLocation]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[inventoryItemLocation]') AND type in (N'U'))
DROP TABLE [dbo].[inventoryItemLocation]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory]') AND type in (N'U'))
DROP TABLE [dbo].[Inventory]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groups]') AND type in (N'U'))
DROP TABLE [dbo].[groups]
GO
/****** Object:  Table [dbo].[groupObject]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupObject]') AND type in (N'U'))
DROP TABLE [dbo].[groupObject]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expenses]') AND type in (N'U'))
DROP TABLE [dbo].[Expenses]
GO
/****** Object:  Table [dbo].[docImages]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[docImages]') AND type in (N'U'))
DROP TABLE [dbo].[docImages]
GO
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[couponsInvoices]') AND type in (N'U'))
DROP TABLE [dbo].[couponsInvoices]
GO
/****** Object:  Table [dbo].[coupons]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[coupons]') AND type in (N'U'))
DROP TABLE [dbo].[coupons]
GO
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[countriesCodes]') AND type in (N'U'))
DROP TABLE [dbo].[countriesCodes]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cities]') AND type in (N'U'))
DROP TABLE [dbo].[cities]
GO
/****** Object:  Table [dbo].[categoryuser]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categoryuser]') AND type in (N'U'))
DROP TABLE [dbo].[categoryuser]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categories]') AND type in (N'U'))
DROP TABLE [dbo].[categories]
GO
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cashTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[cashTransfer]
GO
/****** Object:  Table [dbo].[cards]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cards]') AND type in (N'U'))
DROP TABLE [dbo].[cards]
GO
/****** Object:  Table [dbo].[branchStore]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchStore]') AND type in (N'U'))
DROP TABLE [dbo].[branchStore]
GO
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchesUsers]') AND type in (N'U'))
DROP TABLE [dbo].[branchesUsers]
GO
/****** Object:  Table [dbo].[branches]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branches]') AND type in (N'U'))
DROP TABLE [dbo].[branches]
GO
/****** Object:  Table [dbo].[bondes]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bondes]') AND type in (N'U'))
DROP TABLE [dbo].[bondes]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[banks]') AND type in (N'U'))
DROP TABLE [dbo].[banks]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agents]') AND type in (N'U'))
DROP TABLE [dbo].[agents]
GO
/****** Object:  Table [dbo].[agentMemberships]    Script Date: 28/07/2021 07:37:01 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agentMemberships]') AND type in (N'U'))
DROP TABLE [dbo].[agentMemberships]
GO
/****** Object:  Table [dbo].[agentMemberships]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[agents]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[bondes]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[branches]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[branchStore]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[cards]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoryuser]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[cities]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[coupons]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[docImages]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[Expenses]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[groupObject]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[groups]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[Inventory]    Script Date: 28/07/2021 07:37:01 م ******/
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
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[inventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inventoryItemLocation]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoiceStatus]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[items]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[itemsProp]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 28/07/2021 07:37:01 م ******/
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
	[itemSerial] [nvarchar](200) NULL,
 CONSTRAINT [PK_itemsTransfer] PRIMARY KEY CLUSTERED 
(
	[itemsTransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[medalAgent]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[medals]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[memberships]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[objects]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[offers]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[packages]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[Points]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pos]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posUsers]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[properties]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[sections]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[serials]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[setValues]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[shippingCompanies]    Script Date: 28/07/2021 07:37:01 م ******/
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
 CONSTRAINT [PK_shippingCompanies] PRIMARY KEY CLUSTERED 
(
	[shippingCompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[storageCost]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subscriptionFees]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysEmails]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[units]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 28/07/2021 07:37:01 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userSetValues]    Script Date: 28/07/2021 07:37:01 م ******/
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
/****** Object:  Table [dbo].[usersLogs]    Script Date: 28/07/2021 07:37:01 م ******/
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

INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (1, NULL, N'مهند  أبوشعر ', N'297150930', N'أبوشعر', N'aleppo', N'mail@mail.com', N'+9610210998877', N'+963-111111111', N'', N'v', N'', CAST(171926.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:06:09.7108341' AS DateTime2), CAST(N'2021-07-28T17:33:28.0827801' AS DateTime2), 1, 3, N'no', 1, N'+966021887666', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (2, NULL, N'نور   خضير', N'662615101', N'خضير', N'', N'', N'', N'+963-222222222', N'c37858823db0093766eee74d8ee1f1e5.png', N'v', N'', CAST(1041104.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:06:22.6174744' AS DateTime2), CAST(N'2021-07-28T16:01:54.7342918' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (3, NULL, N'ديانا  لقق', N'621513063', N'لقق', N'', N'', N'', N'+963-333333333', N'71f020248a405d21e94d1de52043bed4.png', N'v', N'', CAST(-1222459520.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:06:41.9485466' AS DateTime2), CAST(N'2021-07-26T12:41:21.8682424' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (4, NULL, N'بيان  سليمان', N'498667622', N'سليمان', N'', N'', N'', N'+963-444444444', N'd2ec5f1ed83abfca0dfec76506b696b3.png', N'v', N'', CAST(4900.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:07:08.7041709' AS DateTime2), CAST(N'2021-07-27T11:55:59.0184534' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (5, NULL, N'أحمد   عقاد', N'637304317', N'عقاد', N'', N'', N'', N'+963-555555555', N'f96f8a89e2143f1e43a2ba7953fb5413.png', N'v', N'', CAST(9950966.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:07:20.4208470' AS DateTime2), CAST(N'2021-07-28T18:04:58.8249281' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (6, NULL, N'بشار   زيدان', N'591702965', N'زيدان', N'', N'', N'', N'+963-666666666', N'56a2e0231c3d394ace201adf37d13f63.png', N'v', N'', CAST(200005632.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:07:34.4228719' AS DateTime2), CAST(N'2021-07-26T13:37:11.3487893' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (7, NULL, N'محمد سودة', N'430477360', N'سودة', N'', N'', N'', N'+963-777777777', N'3204215c19f25609034d24451f7e03d7.png', N'v', N'', CAST(85000.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:07:45.7310231' AS DateTime2), CAST(N'2021-07-26T13:29:17.8742946' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (8, NULL, N'محمد   بهلوان', N'165693251', N'بهلوان', N'', N'', N'', N'+963-888888888', N'6a5d62c1233b5e9b2000dd13aadf81f4.png', N'v', N'', CAST(7000.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:08:01.0595455' AS DateTime2), CAST(N'2021-07-25T11:55:51.2438310' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (9, NULL, N'سمر  كركوتلي', N'377866586', N'كركوتلي', N'', N'', N'', N'+966-999999999', N'6eaba1dc3c031faf262149c058fea728.png', N'c', N'', CAST(15000.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:08:45.2069660' AS DateTime2), CAST(N'2021-07-27T12:28:58.4430316' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (10, NULL, N'عمر  الحراكي', N'213417292', N'الحراكي', N'', N'', N'', N'+966-101010101', N'0f26776e0a524c7d2b6b5f771d500980.png', N'c', N'', CAST(9300.00 AS Decimal(20, 2)), 1, CAST(N'2021-06-30T16:08:58.0342271' AS DateTime2), CAST(N'2021-07-28T01:33:24.1241915' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (11, NULL, N'عمر  طيفور', N'778565517', N'طيفور', N'', N'', N'', N'+966-111111111', N'05da7ccc8020731d607471318fc4f35b.png', N'c', N'', CAST(6050.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:09:16.4003380' AS DateTime2), CAST(N'2021-07-26T12:04:33.7746378' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (12, NULL, N'عمر   معروف', N'35142864', N'معروف', N'', N'', N'', N'+966-121212121', N'0731f29a7d8c55ddab810a076d078aff.png', N'c', N'', CAST(-3700.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:09:40.9186322' AS DateTime2), CAST(N'2021-07-26T12:05:50.3282855' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (13, NULL, N'أمل  زيدان', N'57248015', N'زيدان', N'', N'', N'', N'+966-131313131', N'd24538a57424ec2d36086326b9215b74.png', N'c', N'', CAST(120000.00 AS Decimal(20, 2)), 1, CAST(N'2021-06-30T16:10:01.5456550' AS DateTime2), CAST(N'2021-07-28T11:13:01.1413348' AS DateTime2), 1, 1, N'', 1, N'', CAST(10000.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (14, NULL, N'قمر   كعكة', N'638671253', N'كعكة', N'', N'', N'', N'+966-141414141', N'ad4bfd50185ef68bce2b903aa7e10ec0.png', N'c', N'', CAST(1100.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:10:14.7478300' AS DateTime2), CAST(N'2021-07-26T12:17:06.4775025' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (15, NULL, N'طارق غباش', N'903957178', N'غباش', N'', N'', N'', N'+966-151515151', N'cfba0c3306a45ea0746c531906c58962.png', N'c', N'', CAST(500.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:10:32.6809829' AS DateTime2), CAST(N'2021-07-26T12:11:52.9283383' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (16, NULL, N'طه المحجوب', N'265078604', N'المحجوب', N'', N'', N'', N'+966-161616161', N'4361139d4379eb98f913441815402fe6.png', N'c', N'', CAST(-6000.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:10:42.7726056' AS DateTime2), CAST(N'2021-07-25T13:08:43.4044528' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (17, NULL, N'لونا  آغا', N'10043846', N'آغا', N'', N'', N'', N'+966-171717171', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:10:54.7602515' AS DateTime2), CAST(N'2021-06-30T16:10:54.7602515' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (18, NULL, N'ايمن  البكر', N'83368720', N'البكر', N'', N'', N'', N'+966-181818181', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:11:11.1459706' AS DateTime2), CAST(N'2021-06-30T16:11:11.1459706' AS DateTime2), 1, 1, N'', 1, N'', CAST(20000.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (19, NULL, N'هلا  بكداش', N'494240534', N'بكداش', N'', N'', N'', N'+966-191919191', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:12:11.0473459' AS DateTime2), CAST(N'2021-06-30T16:12:11.0473459' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (20, NULL, N'اية  الأحمد', N'327686608', N'الأحمد', N'', N'', N'', N'+966-202020202', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:12:29.8164362' AS DateTime2), CAST(N'2021-06-30T16:12:29.8164362' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (21, NULL, N'ندى ادلبي', N'947278245', N'ادلبي', N'', N'', N'', N'+966-212121212', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:12:42.4374840' AS DateTime2), CAST(N'2021-06-30T16:12:42.4374840' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (22, NULL, N'جود  كرزة', N'566869883', N'كرزة', N'', N'', N'', N'+966-222222222', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:12:55.0773452' AS DateTime2), CAST(N'2021-06-30T16:12:55.0773452' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (23, NULL, N'غيثاء والي', N'487521162', N'والي', N'', N'', N'', N'+966-232323232', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:13:13.7804093' AS DateTime2), CAST(N'2021-06-30T16:13:13.7804093' AS DateTime2), 1, 1, N'', 1, N'', CAST(500000.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (24, NULL, N'جمانة كرزة', N'949110884', N'كرزة', N'', N'', N'', N'+966-242424242', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:13:36.1745594' AS DateTime2), CAST(N'2021-06-30T16:13:36.1745594' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (25, NULL, N'راما حمامي', N'617817613', N'حمامي', N'', N'', N'', N'+966-252525252', NULL, N'c', N'', CAST(0.00 AS Decimal(20, 2)), 0, CAST(N'2021-06-30T16:13:50.5292915' AS DateTime2), CAST(N'2021-06-30T16:13:50.5292915' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (26, NULL, N'aaa', N'964734422', N'aaa', N'aas', N'aaa@gmail.com', N'+963--213123', N'+963-212213', N'', N'v', N'', CAST(-9000.00 AS Decimal(20, 2)), 0, CAST(N'2021-07-12T12:42:10.8411157' AS DateTime2), CAST(N'2021-07-26T13:46:55.7967503' AS DateTime2), 4, 4, N'', 1, N'+963--21313', CAST(0.00 AS Decimal(20, 2)))
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
SET IDENTITY_INSERT [dbo].[bondes] ON 

INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (1, N'Al-JM-Bpbnd1', CAST(500.00 AS Decimal(20, 2)), CAST(N'2021-07-20T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-07-27T11:24:17.4161421' AS DateTime2), CAST(N'2021-07-24T11:42:35.7880784' AS DateTime2), NULL, 41)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (2, N'Al-JM-Bpbnd2', CAST(500.00 AS Decimal(20, 2)), CAST(N'2021-07-24T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-24T11:46:27.7439953' AS DateTime2), CAST(N'2021-07-24T11:46:27.7439953' AS DateTime2), NULL, 42)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (3, N'Al-JM-Bpbnd3', CAST(500.00 AS Decimal(20, 2)), CAST(N'2021-07-25T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-07-27T11:47:33.1308653' AS DateTime2), CAST(N'2021-07-24T11:48:04.0886750' AS DateTime2), NULL, 43)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (6, N'Al-JM-Bpbnd5', CAST(500.00 AS Decimal(20, 2)), CAST(N'2021-07-25T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-07-27T14:05:07.1935965' AS DateTime2), CAST(N'2021-07-25T10:46:10.0434559' AS DateTime2), NULL, 52)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (10, N'789', CAST(50000.00 AS Decimal(20, 2)), CAST(N'2021-07-02T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-07-25T11:07:41.4347265' AS DateTime2), CAST(N'2021-07-25T11:07:41.4347265' AS DateTime2), NULL, 59)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (24, N'789', CAST(12000.00 AS Decimal(20, 2)), CAST(N'2021-07-27T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-07-25T12:41:52.0098178' AS DateTime2), CAST(N'2021-07-25T12:41:52.0098178' AS DateTime2), NULL, 81)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (25, N'753', CAST(15000.00 AS Decimal(20, 2)), CAST(N'2021-07-20T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-07-25T13:07:51.8567204' AS DateTime2), CAST(N'2021-07-25T13:07:51.8567204' AS DateTime2), NULL, 82)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (33, N'999', CAST(100.00 AS Decimal(20, 2)), CAST(N'2021-07-29T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T11:57:35.8864038' AS DateTime2), CAST(N'2021-07-26T11:57:35.8864038' AS DateTime2), NULL, 84)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (34, N'999', CAST(100.00 AS Decimal(20, 2)), CAST(N'2021-07-28T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T11:58:37.2650573' AS DateTime2), CAST(N'2021-07-26T11:58:37.2650573' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (35, N'pbnd-000001', CAST(100.00 AS Decimal(20, 2)), CAST(N'2021-07-27T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T12:00:49.5385300' AS DateTime2), CAST(N'2021-07-26T12:00:49.5385300' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (36, N'pbnd-000001', CAST(200.00 AS Decimal(20, 2)), CAST(N'2021-07-30T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T12:03:37.1352545' AS DateTime2), CAST(N'2021-07-26T12:03:37.1352545' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (37, N'pbnd-000001', CAST(100.00 AS Decimal(20, 2)), CAST(N'2021-07-30T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T12:04:32.6497336' AS DateTime2), CAST(N'2021-07-26T12:04:32.6497336' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (38, N'pbnd-000001', CAST(100.00 AS Decimal(20, 2)), CAST(N'2021-07-30T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T12:05:49.2367617' AS DateTime2), CAST(N'2021-07-26T12:05:49.2367617' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (39, N'pbnd-000001', CAST(100.00 AS Decimal(20, 2)), CAST(N'2021-07-21T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T12:06:38.2723551' AS DateTime2), CAST(N'2021-07-26T12:06:38.2723551' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (40, N'pbnd-000001', CAST(500.00 AS Decimal(20, 2)), CAST(N'2021-07-20T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T12:08:42.4472347' AS DateTime2), CAST(N'2021-07-26T12:08:42.4472347' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (41, N'pbnd-000001', CAST(1000.00 AS Decimal(20, 2)), CAST(N'2021-07-14T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-07-27T11:24:39.6891857' AS DateTime2), CAST(N'2021-07-26T12:09:18.0029063' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (42, N'pbnd-000001', CAST(1500.00 AS Decimal(20, 2)), CAST(N'2021-07-23T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T12:09:58.0828284' AS DateTime2), CAST(N'2021-07-26T12:09:58.0828284' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (43, N'pbnd-000001', CAST(2000.00 AS Decimal(20, 2)), CAST(N'2021-07-15T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T12:10:30.5410745' AS DateTime2), CAST(N'2021-07-26T12:10:30.5410745' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (44, N'pbnd-000001', CAST(500.00 AS Decimal(20, 2)), CAST(N'2021-07-16T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T12:29:09.2219618' AS DateTime2), CAST(N'2021-07-26T12:29:09.2219618' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (45, N'pbnd-000001', CAST(200.00 AS Decimal(20, 2)), CAST(N'2021-07-15T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T12:29:44.2013337' AS DateTime2), CAST(N'2021-07-26T12:29:44.2013337' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (46, N'pbnd-000001', CAST(7700.00 AS Decimal(20, 2)), CAST(N'2021-07-25T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T12:56:52.7558370' AS DateTime2), CAST(N'2021-07-26T12:56:52.7558370' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (47, N'258', CAST(2500.00 AS Decimal(20, 2)), CAST(N'2021-07-06T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-07-26T13:17:20.2242021' AS DateTime2), CAST(N'2021-07-26T13:17:20.2242021' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (48, N'7890', CAST(2500.00 AS Decimal(20, 2)), CAST(N'2021-07-28T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-07-26T13:18:20.4281276' AS DateTime2), CAST(N'2021-07-26T13:18:20.4281276' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (49, N'888', CAST(5000.00 AS Decimal(20, 2)), CAST(N'2021-07-27T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-07-26T13:24:37.2289439' AS DateTime2), CAST(N'2021-07-26T13:24:37.2289439' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (50, N'777', CAST(5000.00 AS Decimal(20, 2)), CAST(N'2021-07-22T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-07-26T13:29:16.7334453' AS DateTime2), CAST(N'2021-07-26T13:29:16.7334453' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (51, N'555', CAST(4000.00 AS Decimal(20, 2)), CAST(N'2021-07-15T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-07-26T13:36:14.6762838' AS DateTime2), CAST(N'2021-07-26T13:36:14.6762838' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (52, N'444', CAST(4000.00 AS Decimal(20, 2)), CAST(N'2021-07-04T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-07-26T13:37:09.1612511' AS DateTime2), CAST(N'2021-07-26T13:37:09.1612511' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (53, N'666', CAST(6000.00 AS Decimal(20, 2)), CAST(N'2021-07-25T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 3, 3, CAST(N'2021-07-27T11:49:29.2944363' AS DateTime2), CAST(N'2021-07-26T13:45:37.2758620' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (55, N'pbnd-000001', CAST(1500.00 AS Decimal(20, 2)), CAST(N'2021-07-26T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-26T14:50:20.1601590' AS DateTime2), CAST(N'2021-07-26T14:50:20.1601590' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (56, N'pbnd-000001', CAST(800.00 AS Decimal(20, 2)), CAST(N'2021-07-06T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-07-27T11:38:21.7018836' AS DateTime2), CAST(N'2021-07-26T14:51:29.1788492' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (57, N'pbnd-000002', CAST(600.00 AS Decimal(20, 2)), CAST(N'2021-07-20T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-27T12:00:01.1866744' AS DateTime2), CAST(N'2021-07-27T12:00:01.1866744' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (58, N'781', CAST(5000.00 AS Decimal(20, 2)), CAST(N'2021-07-01T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-07-27T12:31:28.6968715' AS DateTime2), CAST(N'2021-07-27T12:31:28.6968715' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (59, N'777', CAST(6237.50 AS Decimal(20, 2)), CAST(N'2021-07-27T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-07-27T12:37:36.1037689' AS DateTime2), CAST(N'2021-07-27T12:37:36.1037689' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (60, N'pbnd-000002', CAST(1200.00 AS Decimal(20, 2)), CAST(N'2021-07-25T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-28T01:30:54.7014071' AS DateTime2), CAST(N'2021-07-28T01:30:54.7014071' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (61, N'pbnd-000002', CAST(1200.00 AS Decimal(20, 2)), CAST(N'2021-07-25T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-07-28T01:31:31.3577599' AS DateTime2), CAST(N'2021-07-28T01:31:31.3577599' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (62, N'8', CAST(1000.00 AS Decimal(20, 2)), CAST(N'2021-07-13T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-07-28T01:36:37.8723454' AS DateTime2), CAST(N'2021-07-28T01:36:37.8723454' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (63, N'852', CAST(20000.00 AS Decimal(20, 2)), CAST(N'2021-07-06T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-07-28T14:25:15.6338402' AS DateTime2), CAST(N'2021-07-28T14:25:15.6338402' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[bondes] OFF
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

INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (25, NULL, N'p', 3, 7, NULL, NULL, N'DM-MA-Bpu1', CAST(N'2021-07-18T14:45:32.0179636' AS DateTime2), CAST(N'2021-07-18T14:45:32.0179636' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (37, NULL, N'd', 2, NULL, 3, NULL, N'Al-JM-Bdv1', CAST(N'2021-07-23T23:13:01.3511179' AS DateTime2), CAST(N'2021-07-23T23:13:01.3511179' AS DateTime2), CAST(1225533555.00 AS Decimal(20, 2)), 1, 1, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (38, NULL, N'p', 2, 5, NULL, NULL, N'Al-JM-Bps1', CAST(N'2021-07-24T11:01:21.2128312' AS DateTime2), CAST(N'2021-07-24T11:01:21.2128312' AS DateTime2), CAST(1000.00 AS Decimal(20, 2)), 3, 3, N'ملاحظات', NULL, NULL, NULL, N's', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (39, NULL, N'p', 2, NULL, NULL, NULL, N'Al-JM-Bpe1', CAST(N'2021-07-24T11:39:31.6451884' AS DateTime2), CAST(N'2021-07-24T11:39:31.6451884' AS DateTime2), CAST(1000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'e', NULL, NULL, NULL, NULL, N'card', 2, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (40, NULL, N'p', 2, NULL, NULL, NULL, N'Al-JM-Bpm1', CAST(N'2021-07-24T11:41:29.4277788' AS DateTime2), CAST(N'2021-07-24T11:41:29.4277788' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'm', NULL, N'159', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (41, NULL, N'p', 2, 5, NULL, NULL, N'Al-JM-Bpu2', CAST(N'2021-07-24T11:42:35.5067772' AS DateTime2), CAST(N'2021-07-24T11:42:36.3348943' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, N'Al-JM-Bpbnd1', NULL, NULL, N'doc', NULL, 1)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (42, NULL, N'p', 2, NULL, NULL, NULL, N'Al-JM-Bpm2', CAST(N'2021-07-24T11:46:24.9936806' AS DateTime2), CAST(N'2021-07-24T11:46:28.3061416' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'm', NULL, N'Al-JM-Bpbnd2', NULL, NULL, N'doc', NULL, 2)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (43, NULL, N'p', 2, NULL, NULL, NULL, N'Al-JM-Bpe2', CAST(N'2021-07-24T11:48:03.8229068' AS DateTime2), CAST(N'2021-07-24T11:48:07.7761199' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'e', NULL, N'Al-JM-Bpbnd3', NULL, NULL, N'doc', NULL, 3)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (45, NULL, N'p', 2, NULL, 5, 31, N'Al-JM-Bpv6', CAST(N'2021-07-24T12:12:05.5902599' AS DateTime2), CAST(N'2021-07-24T12:12:05.5902599' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, N'Al-JM-Bpbnd4', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (47, NULL, N'p', 2, NULL, 2, 30, N'Al-JM-Bpv7', CAST(N'2021-07-24T12:14:33.4828515' AS DateTime2), CAST(N'2021-07-24T12:14:33.4828515' AS DateTime2), CAST(10800000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (48, NULL, N'd', 2, NULL, 9, 29, N'Al-JM-Bpc1', CAST(N'2021-07-24T12:25:37.4129276' AS DateTime2), CAST(N'2021-07-24T12:25:37.4129276' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'card', 1, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (49, NULL, N'p', 2, NULL, 1, 67, N'Al-JM-Bpv8', CAST(N'2021-07-25T10:33:32.0822778' AS DateTime2), CAST(N'2021-07-25T10:33:32.0822778' AS DateTime2), CAST(10000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, N'56', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (51, NULL, N'p', 2, NULL, 4, 35, N'Al-JM-Bpv9', CAST(N'2021-07-25T10:45:03.2302547' AS DateTime2), CAST(N'2021-07-25T10:45:03.2302547' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'card', 2, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (52, NULL, N'p', 2, 6, NULL, NULL, N'Al-JM-Bpu3', CAST(N'2021-07-25T10:46:09.0120663' AS DateTime2), CAST(N'2021-07-25T10:46:11.6840818' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, N'Al-JM-Bpbnd5', NULL, NULL, N'doc', NULL, 6)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (53, NULL, N'p', 2, NULL, 5, 31, N'Al-JM-Bpv10', CAST(N'2021-07-25T10:47:30.9424667' AS DateTime2), CAST(N'2021-07-25T10:47:30.9424667' AS DateTime2), CAST(1000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, N'58', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (57, NULL, N'd', 2, 8, NULL, NULL, N'Al-JM-Bdu1', CAST(N'2021-07-25T11:06:33.3428712' AS DateTime2), CAST(N'2021-07-25T11:06:33.3428712' AS DateTime2), CAST(4000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (58, NULL, N'd', 2, NULL, NULL, NULL, N'Al-JM-Bdm1', CAST(N'2021-07-25T11:06:57.6431693' AS DateTime2), CAST(N'2021-07-25T11:06:57.6431693' AS DateTime2), CAST(5000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'm', NULL, N'852', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (59, NULL, N'd', 2, 5, NULL, NULL, N'Al-JM-Bdu2', CAST(N'2021-07-25T11:07:41.1213238' AS DateTime2), CAST(N'2021-07-25T11:07:50.0251267' AS DateTime2), CAST(50000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, N'789', NULL, NULL, N'doc', NULL, 10)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (61, NULL, N'p', 2, 8, NULL, NULL, N'Al-JM-Bps2', CAST(N'2021-07-25T11:40:57.5251673' AS DateTime2), CAST(N'2021-07-25T11:40:57.5251673' AS DateTime2), CAST(2500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N's', NULL, N'Al-JM-Bpbnd6', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (63, NULL, N'p', 2, NULL, 4, 35, N'Al-JM-Bpv11', CAST(N'2021-07-25T11:43:14.6440908' AS DateTime2), CAST(N'2021-07-25T11:43:14.6440908' AS DateTime2), CAST(2000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (64, NULL, N'p', 2, NULL, 4, 35, N'Al-JM-Bpv12', CAST(N'2021-07-25T11:49:03.2302578' AS DateTime2), CAST(N'2021-07-25T11:49:03.2302578' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, N'78', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (65, NULL, N'p', 2, NULL, 5, 31, N'Al-JM-Bpv13', CAST(N'2021-07-25T11:49:44.3686272' AS DateTime2), CAST(N'2021-07-25T11:49:44.3686272' AS DateTime2), CAST(2500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, N'Al-JM-Bpbnd7', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (70, NULL, N'p', 2, NULL, 5, 31, N'Al-JM-Bpv14', CAST(N'2021-07-25T11:58:03.5591988' AS DateTime2), CAST(N'2021-07-25T11:58:03.5591988' AS DateTime2), CAST(2500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, N'Al-JM-Bpbnd8', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (72, NULL, N'd', 2, NULL, NULL, 83, N'System.Threading.Tasks.Task`1[System.String]', CAST(N'2021-07-25T12:09:01.3129623' AS DateTime2), CAST(N'2021-07-25T12:09:01.3129623' AS DateTime2), CAST(1000.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (73, NULL, N'p', 2, 8, NULL, NULL, N'Al-JM-Bpu4', CAST(N'2021-07-25T12:11:00.3143533' AS DateTime2), CAST(N'2021-07-25T12:11:00.3143533' AS DateTime2), CAST(1200.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, N'Al-JM-Bpbnd9', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (74, NULL, N'p', 2, 7, NULL, NULL, N'Al-JM-Bpu5', CAST(N'2021-07-25T12:20:46.3206156' AS DateTime2), CAST(N'2021-07-25T12:20:46.3206156' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, N'Al-JM-Bpbnd10', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (75, NULL, N'p', 2, NULL, NULL, NULL, N'Al-JM-Bpe3', CAST(N'2021-07-25T12:21:20.4145895' AS DateTime2), CAST(N'2021-07-25T12:21:20.4145895' AS DateTime2), CAST(250.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'e', NULL, N'Al-JM-Bpbnd11', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (77, NULL, N'p', 2, NULL, 6, 51, N'Al-JM-Bpv16', CAST(N'2021-07-25T12:24:36.9960262' AS DateTime2), CAST(N'2021-07-25T12:24:36.9960262' AS DateTime2), CAST(100000000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, N'Al-JM-Bpbnd12', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (78, NULL, N'p', 2, 6, NULL, NULL, N'Al-JM-Bps3', CAST(N'2021-07-25T12:32:16.6745851' AS DateTime2), CAST(N'2021-07-25T12:32:16.6745851' AS DateTime2), CAST(1200.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N's', NULL, N'Al-JM-Bpbnd13', NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (79, NULL, N'p', 2, NULL, 5, 31, N'0000', CAST(N'2021-07-25T12:38:53.0859807' AS DateTime2), CAST(N'2021-07-25T12:38:53.0859807' AS DateTime2), CAST(1000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'doc', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (80, NULL, N'd', 2, 3, NULL, NULL, N'Al-JM-Bdu3', CAST(N'2021-07-25T12:41:21.1812338' AS DateTime2), CAST(N'2021-07-25T12:41:21.1812338' AS DateTime2), CAST(1200.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (81, NULL, N'd', 2, NULL, NULL, NULL, N'Al-JM-Bdm2', CAST(N'2021-07-25T12:41:51.7442496' AS DateTime2), CAST(N'2021-07-25T12:41:52.5253061' AS DateTime2), CAST(12000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'm', NULL, N'789', NULL, NULL, N'doc', NULL, 24)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (82, NULL, N'd', 2, NULL, NULL, NULL, N'Al-JM-Bdm3', CAST(N'2021-07-25T13:07:51.5912430' AS DateTime2), CAST(N'2021-07-25T13:07:52.3101133' AS DateTime2), CAST(15000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'm', NULL, N'753', NULL, NULL, N'doc', NULL, 25)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (83, NULL, N'p', 2, 4, NULL, NULL, N'pv-000001', CAST(N'2021-07-25T13:39:07.5838823' AS DateTime2), CAST(N'2021-07-25T13:39:07.5838823' AS DateTime2), CAST(1250.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N's', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (84, NULL, N'd', 2, NULL, NULL, NULL, N'dv-000001', CAST(N'2021-07-25T13:39:34.1308429' AS DateTime2), CAST(N'2021-07-25T13:39:34.1308429' AS DateTime2), CAST(5000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'm', NULL, NULL, NULL, NULL, N'card', 2, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (85, NULL, N'p', 2, NULL, 4, 35, N'pv-000001', CAST(N'2021-07-26T12:03:37.7755597' AS DateTime2), CAST(N'2021-07-26T12:03:37.7755597' AS DateTime2), CAST(200.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, N'pbnd-000001', NULL, NULL, N'doc', NULL, 36)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (86, NULL, N'p', 2, 2, NULL, NULL, N'pv-000001', CAST(N'2021-07-26T12:08:42.6838038' AS DateTime2), CAST(N'2021-07-26T12:08:42.6838038' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, N'pbnd-000001', NULL, NULL, N'doc', NULL, 40)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (87, NULL, N'p', 2, 7, NULL, NULL, N'pv-000001', CAST(N'2021-07-26T12:09:18.2238666' AS DateTime2), CAST(N'2021-07-26T12:09:18.2238666' AS DateTime2), CAST(1000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N's', NULL, N'pbnd-000001', NULL, NULL, N'doc', NULL, 41)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (88, NULL, N'p', 2, NULL, NULL, NULL, N'pv-000001', CAST(N'2021-07-26T12:09:58.3028325' AS DateTime2), CAST(N'2021-07-26T12:09:58.3028325' AS DateTime2), CAST(1500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'e', NULL, N'pbnd-000001', NULL, NULL, N'doc', NULL, 42)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (89, NULL, N'p', 2, NULL, NULL, NULL, N'pv-000001', CAST(N'2021-07-26T12:10:30.7521798' AS DateTime2), CAST(N'2021-07-26T12:10:30.7521798' AS DateTime2), CAST(2000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'm', NULL, N'pbnd-000001', NULL, NULL, N'doc', NULL, 43)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (90, NULL, N'p', 2, 3, NULL, NULL, N'pv-000001', CAST(N'2021-07-26T12:12:32.7419802' AS DateTime2), CAST(N'2021-07-26T12:12:32.7419802' AS DateTime2), CAST(2500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (91, NULL, N'p', 2, 8, NULL, NULL, N'pv-000001', CAST(N'2021-07-26T12:15:43.8218314' AS DateTime2), CAST(N'2021-07-26T12:15:43.8218314' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N's', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (92, NULL, N'p', 2, NULL, NULL, NULL, N'pv-000001', CAST(N'2021-07-26T12:15:59.1480956' AS DateTime2), CAST(N'2021-07-26T12:15:59.1480956' AS DateTime2), CAST(800.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'e', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (93, NULL, N'p', 2, 8, NULL, NULL, N'pv-000001', CAST(N'2021-07-26T12:17:56.5169704' AS DateTime2), CAST(N'2021-07-26T12:17:56.5169704' AS DateTime2), CAST(800.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, N'987', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (94, NULL, N'p', 2, NULL, NULL, NULL, N'pv-000001', CAST(N'2021-07-26T12:18:38.0063772' AS DateTime2), CAST(N'2021-07-26T12:18:38.0063772' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'm', NULL, NULL, NULL, NULL, N'card', 2, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (95, NULL, N'p', 2, NULL, 5, 31, N'pv-000001', CAST(N'2021-07-26T12:21:41.3937049' AS DateTime2), CAST(N'2021-07-26T12:21:41.3937049' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (97, NULL, N'p', 2, NULL, 3, 82, N'pv-000001', CAST(N'2021-07-26T12:41:20.9777306' AS DateTime2), CAST(N'2021-07-26T12:41:20.9777306' AS DateTime2), CAST(20000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (98, NULL, N'p', 2, NULL, 1, 13, N'pv-000001', CAST(N'2021-07-26T12:51:45.0477579' AS DateTime2), CAST(N'2021-07-26T12:51:45.0477579' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (99, NULL, N'p', 2, NULL, 1, 13, N'pv-000001', CAST(N'2021-07-26T12:56:53.0843211' AS DateTime2), CAST(N'2021-07-26T12:56:53.0843211' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, N'pbnd-000001', NULL, NULL, N'doc', NULL, 46)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (100, NULL, N'd', 2, 4, NULL, NULL, N'dv-000001', CAST(N'2021-07-26T13:14:37.5660874' AS DateTime2), CAST(N'2021-07-26T13:14:37.5660874' AS DateTime2), CAST(1000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (101, NULL, N'd', 2, NULL, NULL, NULL, N'dv-000001', CAST(N'2021-07-26T13:14:59.7068293' AS DateTime2), CAST(N'2021-07-26T13:14:59.7068293' AS DateTime2), CAST(2000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'm', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (102, NULL, N'd', 2, 6, NULL, NULL, N'dv-000001', CAST(N'2021-07-26T13:15:36.9104660' AS DateTime2), CAST(N'2021-07-26T13:15:36.9104660' AS DateTime2), CAST(2500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, N'95', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (103, NULL, N'd', 2, 11, NULL, NULL, N'dv-000001', CAST(N'2021-07-26T13:16:40.6769073' AS DateTime2), CAST(N'2021-07-26T13:16:40.6769073' AS DateTime2), CAST(3000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, NULL, NULL, NULL, N'card', 2, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (104, NULL, N'd', 2, 12, NULL, NULL, N'dv-000001', CAST(N'2021-07-26T13:18:20.7247303' AS DateTime2), CAST(N'2021-07-26T13:18:20.7247303' AS DateTime2), CAST(2500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, N'7890', NULL, NULL, N'doc', NULL, 48)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (105, NULL, N'd', 2, NULL, NULL, NULL, N'dv-000001', CAST(N'2021-07-26T13:36:14.9107666' AS DateTime2), CAST(N'2021-07-26T13:36:14.9107666' AS DateTime2), CAST(4000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'm', NULL, N'555', NULL, NULL, N'doc', NULL, 51)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (106, NULL, N'd', 2, 20, NULL, NULL, N'dv-000001', CAST(N'2021-07-26T13:45:37.5028526' AS DateTime2), CAST(N'2021-07-26T13:45:37.5028526' AS DateTime2), CAST(6000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, N'666', NULL, NULL, N'doc', NULL, 53)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (107, NULL, N'd', 2, NULL, NULL, NULL, N'dv-000002', CAST(N'2021-07-26T14:49:09.2319047' AS DateTime2), CAST(N'2021-07-26T14:49:09.2319047' AS DateTime2), CAST(1500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'm', NULL, N'753', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (108, NULL, N'p', 2, 7, NULL, NULL, N'pv-000002', CAST(N'2021-07-26T14:49:41.6891926' AS DateTime2), CAST(N'2021-07-26T14:49:41.6891926' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, NULL, NULL, NULL, N'card', 1, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (109, NULL, N'p', 2, NULL, NULL, NULL, N'pv-000003', CAST(N'2021-07-26T14:50:22.6792386' AS DateTime2), CAST(N'2021-07-26T14:50:22.6792386' AS DateTime2), CAST(1500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'e', NULL, N'pbnd-000001', NULL, NULL, N'doc', NULL, 55)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (110, NULL, N'p', 2, NULL, NULL, NULL, N'pv-000004', CAST(N'2021-07-26T14:51:29.4103125' AS DateTime2), CAST(N'2021-07-26T14:51:29.4103125' AS DateTime2), CAST(800.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'm', NULL, N'pbnd-000001', NULL, NULL, N'doc', NULL, 56)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (111, NULL, N'p', 2, 7, NULL, NULL, N'pv-000005', CAST(N'2021-07-27T11:08:53.9194043' AS DateTime2), CAST(N'2021-07-27T11:08:53.9194043' AS DateTime2), CAST(100.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (112, NULL, N'p', 2, NULL, NULL, NULL, N'pv-000006', CAST(N'2021-07-27T11:10:14.4906079' AS DateTime2), CAST(N'2021-07-27T11:10:14.4906079' AS DateTime2), CAST(200.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'e', NULL, N'159', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (113, NULL, N'p', 2, 5, NULL, NULL, N'Al-JM-Bpbnd1', CAST(N'2021-07-27T11:24:18.4791712' AS DateTime2), CAST(N'2021-07-27T11:24:18.4791712' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'bnd', NULL, N'Al-JM-Bpbnd1', NULL, NULL, N'cash', NULL, 1)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (114, NULL, N'p', 2, NULL, NULL, NULL, N'Al-JM-Bpbnd2', CAST(N'2021-07-27T11:24:41.3836175' AS DateTime2), CAST(N'2021-07-27T11:24:41.3836175' AS DateTime2), CAST(1000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'bnd', NULL, N'pbnd-000001', NULL, NULL, N'cheque', NULL, 41)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (115, NULL, N'p', 2, NULL, NULL, NULL, N'Al-JM-Bpbnd3', CAST(N'2021-07-27T11:38:28.5946807' AS DateTime2), CAST(N'2021-07-27T11:38:28.5946807' AS DateTime2), CAST(800.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'bnd', NULL, N'pbnd-000001', NULL, NULL, N'cash', NULL, 56)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (116, NULL, N'd', 2, 20, NULL, NULL, N'Al-JM-Bdbnd1', CAST(N'2021-07-27T11:49:30.7799072' AS DateTime2), CAST(N'2021-07-27T11:49:30.7799072' AS DateTime2), CAST(6000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'bnd', NULL, N'666', NULL, NULL, N'cash', NULL, 53)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (117, NULL, N'p', 2, NULL, 5, 31, N'pv-000007', CAST(N'2021-07-27T11:54:26.9452296' AS DateTime2), CAST(N'2021-07-27T11:54:26.9452296' AS DateTime2), CAST(400.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (118, NULL, N'p', 2, NULL, 4, 35, N'pv-000008', CAST(N'2021-07-27T11:55:29.0922172' AS DateTime2), CAST(N'2021-07-27T11:55:29.0922172' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'card', 3, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (119, NULL, N'p', 2, 6, NULL, NULL, N'pv-000009', CAST(N'2021-07-27T12:01:05.8905198' AS DateTime2), CAST(N'2021-07-27T12:01:05.8905198' AS DateTime2), CAST(600.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (120, NULL, N'd', 2, 5, NULL, NULL, N'dv-000003', CAST(N'2021-07-27T12:04:20.5200945' AS DateTime2), CAST(N'2021-07-27T12:04:20.5200945' AS DateTime2), CAST(1000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'u', NULL, N'78', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (122, NULL, N'p', 2, NULL, 1, 13, N'pv-000011', CAST(N'2021-07-27T12:16:45.4486291' AS DateTime2), CAST(N'2021-07-27T12:16:45.4486291' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'card', 3, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (123, NULL, N'p', 2, NULL, 9, 27, N'pv-000012', CAST(N'2021-07-27T12:28:54.5763326' AS DateTime2), CAST(N'2021-07-27T12:28:54.5763326' AS DateTime2), CAST(1000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (124, NULL, N'd', 2, NULL, NULL, NULL, N'dv-000004', CAST(N'2021-07-27T12:31:05.9541410' AS DateTime2), CAST(N'2021-07-27T12:31:05.9541410' AS DateTime2), CAST(8000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'm', NULL, N'78', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (125, NULL, N'd', 2, NULL, 13, 24, N'dv-000005', CAST(N'2021-07-27T12:35:37.3107422' AS DateTime2), CAST(N'2021-07-27T12:35:37.3107422' AS DateTime2), CAST(10000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'card', 1, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (126, NULL, N'd', 2, NULL, 10, 57, N'dv-000006', CAST(N'2021-07-27T12:37:36.4343527' AS DateTime2), CAST(N'2021-07-27T12:37:36.4343527' AS DateTime2), CAST(550.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'c', NULL, N'777', NULL, NULL, N'doc', NULL, 59)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (127, NULL, N'p', 2, 6, NULL, NULL, N'Al-JM-Bpbnd4', CAST(N'2021-07-27T14:05:12.8912679' AS DateTime2), CAST(N'2021-07-27T14:05:12.8912679' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'bnd', NULL, N'Al-JM-Bpbnd5', NULL, NULL, N'card', 1, 6)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (134, NULL, N'd', 2, NULL, 13, 24, N'dv-000010', CAST(N'2021-07-28T11:12:57.6566154' AS DateTime2), CAST(N'2021-07-28T11:12:57.6566154' AS DateTime2), CAST(10000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (136, NULL, N'p', 2, NULL, 2, 13, N'pv-000013', CAST(N'2021-07-28T13:59:36.6588130' AS DateTime2), CAST(N'2021-07-28T13:59:36.6588130' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (137, NULL, N'p', 2, NULL, 2, 30, N'pv-000013', CAST(N'2021-07-28T13:59:36.7867361' AS DateTime2), CAST(N'2021-07-28T13:59:36.7867361' AS DateTime2), CAST(10000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (138, NULL, N'd', 2, NULL, 9, 14, N'dv-000011', CAST(N'2021-07-28T14:05:38.6909288' AS DateTime2), CAST(N'2021-07-28T14:05:38.6909288' AS DateTime2), CAST(1000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'c', NULL, N'450', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (139, NULL, N'd', 2, NULL, 9, 27, N'dv-000011', CAST(N'2021-07-28T14:05:38.8537755' AS DateTime2), CAST(N'2021-07-28T14:05:38.8537755' AS DateTime2), CAST(1000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'c', NULL, N'450', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (140, NULL, N'd', 2, NULL, 9, 29, N'dv-000011', CAST(N'2021-07-28T14:05:38.8783936' AS DateTime2), CAST(N'2021-07-28T14:05:38.8783936' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'c', NULL, N'450', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (141, NULL, N'p', 2, NULL, 14, NULL, N'pv-000014', CAST(N'2021-07-28T14:20:57.6139502' AS DateTime2), CAST(N'2021-07-28T14:20:57.6139502' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'c', NULL, N'520', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (142, NULL, N'p', 2, NULL, 2, 70, N'pv-000015', CAST(N'2021-07-28T14:23:04.0021247' AS DateTime2), CAST(N'2021-07-28T14:23:04.0021247' AS DateTime2), CAST(5000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'card', 2, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (143, NULL, N'p', 2, NULL, 2, NULL, N'pv-000015', CAST(N'2021-07-28T14:23:04.0137434' AS DateTime2), CAST(N'2021-07-28T14:23:04.0137434' AS DateTime2), CAST(5000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'card', 2, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (144, NULL, N'd', 2, NULL, 13, 15, N'dv-000012', CAST(N'2021-07-28T14:25:15.8885959' AS DateTime2), CAST(N'2021-07-28T14:25:15.8885959' AS DateTime2), CAST(20000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'c', NULL, N'852', NULL, NULL, N'doc', NULL, 63)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (145, NULL, N'd', 2, NULL, 7, NULL, N'dv-000013', CAST(N'2021-07-28T14:27:32.4654887' AS DateTime2), CAST(N'2021-07-28T14:27:32.4654887' AS DateTime2), CAST(5000.00 AS Decimal(20, 2)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, N'111', NULL, NULL, N'cheque', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (146, NULL, N'd', 2, NULL, NULL, 92, N'System.Threading.Tasks.Task`1[System.String]', CAST(N'2021-07-28T17:15:37.9664780' AS DateTime2), CAST(N'2021-07-28T17:15:37.9664780' AS DateTime2), CAST(2401500.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (147, NULL, N'd', 2, NULL, NULL, 95, N'System.Threading.Tasks.Task`1[System.String]', CAST(N'2021-07-28T17:24:07.2466397' AS DateTime2), CAST(N'2021-07-28T17:24:07.2466397' AS DateTime2), CAST(3060000.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (148, NULL, N'd', 2, NULL, NULL, 100, N'System.Threading.Tasks.Task`1[System.String]', CAST(N'2021-07-28T17:37:12.8202799' AS DateTime2), CAST(N'2021-07-28T17:37:12.8202799' AS DateTime2), CAST(1200000.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (149, NULL, N'd', 2, NULL, NULL, 101, N'System.Threading.Tasks.Task`1[System.String]', CAST(N'2021-07-28T17:37:20.1018967' AS DateTime2), CAST(N'2021-07-28T17:37:20.1018967' AS DateTime2), CAST(500000.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (150, NULL, N'd', 2, NULL, NULL, 102, N'System.Threading.Tasks.Task`1[System.String]', CAST(N'2021-07-28T17:37:27.6958685' AS DateTime2), CAST(N'2021-07-28T17:37:27.6958685' AS DateTime2), CAST(500.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (151, NULL, N'd', 2, NULL, NULL, 106, N'System.Threading.Tasks.Task`1[System.String]', CAST(N'2021-07-28T17:47:07.1558803' AS DateTime2), CAST(N'2021-07-28T17:47:07.1558803' AS DateTime2), CAST(1500.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (152, NULL, N'd', 2, NULL, NULL, 110, N'System.Threading.Tasks.Task`1[System.String]', CAST(N'2021-07-28T17:52:01.5497746' AS DateTime2), CAST(N'2021-07-28T17:52:01.5497746' AS DateTime2), CAST(23000.00 AS Decimal(20, 2)), 9, 9, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (153, NULL, N'd', 2, NULL, NULL, 111, N'System.Threading.Tasks.Task`1[System.String]', CAST(N'2021-07-28T17:53:03.8632206' AS DateTime2), CAST(N'2021-07-28T17:53:03.8632206' AS DateTime2), CAST(1500.00 AS Decimal(20, 2)), 9, 9, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (154, NULL, N'd', 2, NULL, NULL, 117, N'System.Threading.Tasks.Task`1[System.String]', CAST(N'2021-07-28T17:58:11.4758833' AS DateTime2), CAST(N'2021-07-28T17:58:11.4758833' AS DateTime2), CAST(1500.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId]) VALUES (155, NULL, N'd', 2, NULL, NULL, 118, N'System.Threading.Tasks.Task`1[System.String]', CAST(N'2021-07-28T17:59:09.7893253' AS DateTime2), CAST(N'2021-07-28T17:59:09.7893253' AS DateTime2), CAST(501000.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL)
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
SET IDENTITY_INSERT [dbo].[coupons] OFF
GO
SET IDENTITY_INSERT [dbo].[couponsInvoices] ON 

INSERT [dbo].[couponsInvoices] ([id], [couponId], [InvoiceId], [createDate], [updateDate], [createUserId], [updateUserId], [discountValue], [discountType]) VALUES (1, 1, 15, CAST(N'2021-07-11T12:30:15.1726032' AS DateTime2), CAST(N'2021-07-11T12:30:15.1726032' AS DateTime2), 2, 2, CAST(100.00 AS Decimal(20, 2)), 1)
INSERT [dbo].[couponsInvoices] ([id], [couponId], [InvoiceId], [createDate], [updateDate], [createUserId], [updateUserId], [discountValue], [discountType]) VALUES (2, 2, 22, CAST(N'2021-07-11T16:28:43.0782386' AS DateTime2), CAST(N'2021-07-11T16:28:43.0782386' AS DateTime2), 9, 9, CAST(5.00 AS Decimal(20, 2)), 2)
INSERT [dbo].[couponsInvoices] ([id], [couponId], [InvoiceId], [createDate], [updateDate], [createUserId], [updateUserId], [discountValue], [discountType]) VALUES (4, 3, 24, CAST(N'2021-07-11T17:10:05.7533252' AS DateTime2), CAST(N'2021-07-11T17:10:05.7533252' AS DateTime2), 9, 9, CAST(10.00 AS Decimal(20, 2)), 2)
INSERT [dbo].[couponsInvoices] ([id], [couponId], [InvoiceId], [createDate], [updateDate], [createUserId], [updateUserId], [discountValue], [discountType]) VALUES (5, 2, 24, CAST(N'2021-07-11T17:10:05.7588377' AS DateTime2), CAST(N'2021-07-11T17:10:05.7588377' AS DateTime2), 9, 9, CAST(5.00 AS Decimal(20, 2)), 2)
INSERT [dbo].[couponsInvoices] ([id], [couponId], [InvoiceId], [createDate], [updateDate], [createUserId], [updateUserId], [discountValue], [discountType]) VALUES (6, 1, 27, CAST(N'2021-07-12T11:15:40.5883137' AS DateTime2), CAST(N'2021-07-12T11:15:40.5883137' AS DateTime2), 2, 2, CAST(100.00 AS Decimal(20, 2)), 1)
INSERT [dbo].[couponsInvoices] ([id], [couponId], [InvoiceId], [createDate], [updateDate], [createUserId], [updateUserId], [discountValue], [discountType]) VALUES (7, 2, 29, CAST(N'2021-07-12T13:41:53.9966159' AS DateTime2), CAST(N'2021-07-12T13:41:53.9966159' AS DateTime2), 9, 9, CAST(5.00 AS Decimal(20, 2)), 2)
SET IDENTITY_INSERT [dbo].[couponsInvoices] OFF
GO
SET IDENTITY_INSERT [dbo].[docImages] ON 

INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (3, N'bntg2', N'1', N'ae73b244b30d62daa5f3f1a03d238333.png', N'invoices', N'ccccc', CAST(N'2021-07-24T10:30:40.0497793' AS DateTime2), CAST(N'2021-07-24T10:32:30.3474590' AS DateTime2), 1, 1, 63)
INSERT [dbo].[docImages] ([id], [docName], [docnum], [image], [tableName], [note], [createDate], [updateDate], [createUserId], [updateUserId], [tableId]) VALUES (4, N'ggfg', N'1', N'c6b970ed37eedb623905ea5793f19680.jpg', N'invoices', N'ccccc', CAST(N'2021-07-24T10:31:10.1906418' AS DateTime2), CAST(N'2021-07-24T10:31:10.1906418' AS DateTime2), 1, 1, 63)
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

INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId]) VALUES (1, N'in-000001', CAST(N'2021-07-12T14:46:39.8515114' AS DateTime2), CAST(N'2021-07-12T14:46:39.8515114' AS DateTime2), 2, 2, NULL, NULL, N'n', 2, 2)
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
SET IDENTITY_INSERT [dbo].[inventoryItemLocation] ON 

INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (1, 1, 43, 3, 46, 8, 1, CAST(N'2021-07-12T14:46:40.2046368' AS DateTime2), CAST(N'2021-07-25T10:36:46.5841091' AS DateTime2), NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause]) VALUES (2, 0, 40, 3, 43, 9, 1, CAST(N'2021-07-12T14:46:40.2078261' AS DateTime2), CAST(N'2021-07-12T14:46:40.2078261' AS DateTime2), NULL, 2, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[inventoryItemLocation] OFF
GO
SET IDENTITY_INSERT [dbo].[invoices] ON 

INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (13, N'pb-000004', 2, 2, N'p', N'-1', NULL, CAST(500.00 AS Decimal(20, 2)), CAST(500.00 AS Decimal(20, 2)), CAST(500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-07-22' AS Date), CAST(N'2021-07-11T12:19:52.3820032' AS DateTime2), CAST(N'2021-07-12T13:36:10.0400752' AS DateTime2), 4, NULL, NULL, CAST(N'12:19:52.3820032' AS Time), N'', N'0000000', CAST(N'2021-07-21T00:00:00.0000000' AS DateTime2), 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (14, N'si-000001', 9, 2, N's', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(1000.00 AS Decimal(20, 2)), CAST(1150.00 AS Decimal(20, 2)), CAST(1000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-11T12:29:04.6566200' AS DateTime2), CAST(N'2021-07-11T12:29:04.6566200' AS DateTime2), 2, NULL, NULL, CAST(N'12:29:04.6566200' AS Time), N'', NULL, NULL, NULL, 4, CAST(15.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (15, N'si-000002', 13, 2, N's', NULL, CAST(100.0000 AS Decimal(20, 4)), CAST(4000.00 AS Decimal(20, 2)), CAST(19500.00 AS Decimal(20, 2)), CAST(20000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-11T12:30:12.5400650' AS DateTime2), CAST(N'2021-07-11T12:30:12.5400650' AS DateTime2), 2, NULL, NULL, CAST(N'12:30:12.5400650' AS Time), N'', NULL, NULL, NULL, 2, CAST(15.00 AS Decimal(20, 2)), NULL, NULL, NULL, 0, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (16, N'si-000007', 13, 2, N's', NULL, CAST(100.0000 AS Decimal(20, 4)), CAST(4000.00 AS Decimal(20, 2)), CAST(19500.00 AS Decimal(20, 2)), CAST(30000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-11T12:30:14.3816383' AS DateTime2), CAST(N'2021-07-11T12:30:14.3816383' AS DateTime2), 2, NULL, NULL, CAST(N'12:30:14.3816383' AS Time), N'', NULL, NULL, NULL, 2, CAST(15.00 AS Decimal(20, 2)), NULL, NULL, NULL, 0, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (18, N'si-000003', NULL, 2, N's', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(1250.00 AS Decimal(20, 2)), CAST(1437.50 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-07-11T13:12:57.3778201' AS DateTime2), CAST(N'2021-07-11T13:12:57.3778201' AS DateTime2), 2, NULL, NULL, CAST(N'13:12:57.3778201' AS Time), N'', NULL, NULL, NULL, 2, CAST(15.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (19, N'si-000004', NULL, 2, N's', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(11000.00 AS Decimal(20, 2)), CAST(12650.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-07-11T13:13:29.2529161' AS DateTime2), CAST(N'2021-07-11T13:13:29.2529161' AS DateTime2), 2, NULL, NULL, CAST(N'13:13:29.2529161' AS Time), N'', NULL, NULL, NULL, 2, CAST(15.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (20, N'si-000005', NULL, 2, N's', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(5500.00 AS Decimal(20, 2)), CAST(6325.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-07-11T13:14:47.2689043' AS DateTime2), CAST(N'2021-07-11T13:14:47.2689043' AS DateTime2), 2, NULL, NULL, CAST(N'13:14:47.2689043' AS Time), N'', NULL, NULL, NULL, 2, CAST(15.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (21, N'si-000006', 10, 2, N's', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(500.00 AS Decimal(20, 2)), CAST(575.00 AS Decimal(20, 2)), CAST(575.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-11T13:15:39.7850223' AS DateTime2), CAST(N'2021-07-11T13:15:39.7850223' AS DateTime2), 2, NULL, NULL, CAST(N'13:15:39.7850223' AS Time), N'', NULL, NULL, NULL, 2, CAST(15.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (22, N'si-000008', 12, 9, N's', NULL, CAST(50.0000 AS Decimal(20, 4)), CAST(1000.00 AS Decimal(20, 2)), CAST(1050.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-08' AS Date), CAST(N'2021-07-11T16:28:41.2635479' AS DateTime2), CAST(N'2021-07-11T16:28:41.2635479' AS DateTime2), 9, NULL, NULL, CAST(N'16:28:41.2635479' AS Time), N'', NULL, NULL, NULL, 2, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (24, N'si-000010', 13, 9, N's', NULL, CAST(375.0000 AS Decimal(20, 4)), CAST(2500.00 AS Decimal(20, 2)), CAST(2375.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-11T17:10:04.5920903' AS DateTime2), CAST(N'2021-07-11T17:10:04.5920903' AS DateTime2), 9, NULL, NULL, CAST(N'17:10:04.5920903' AS Time), N'', NULL, NULL, NULL, 2, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (26, N'si-000011', NULL, 2, N's', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(1250.00 AS Decimal(20, 2)), CAST(1437.50 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-07-12T11:12:00.3254787' AS DateTime2), CAST(N'2021-07-12T11:12:00.3254787' AS DateTime2), 2, NULL, NULL, CAST(N'11:12:00.3254787' AS Time), N'', NULL, NULL, NULL, 2, CAST(15.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (27, N'si-000012', 9, 2, N's', NULL, CAST(100.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(16625.00 AS Decimal(20, 2)), CAST(1000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-12T11:15:38.9215983' AS DateTime2), CAST(N'2021-07-12T11:15:38.9215983' AS DateTime2), 2, NULL, NULL, CAST(N'11:15:38.9215983' AS Time), N'', NULL, NULL, NULL, 2, CAST(15.00 AS Decimal(20, 2)), NULL, NULL, NULL, 0, 2, 7, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (28, N'sb-000001', 9, 4, N'sb', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(1000.00 AS Decimal(20, 2)), CAST(1150.00 AS Decimal(20, 2)), CAST(1150.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-12T13:36:22.2121560' AS DateTime2), CAST(N'2021-07-12T13:36:22.2121560' AS DateTime2), 4, 14, NULL, CAST(N'13:36:22.2121560' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (29, N'si-000013', 9, 9, N's', NULL, CAST(75.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1605.00 AS Decimal(20, 2)), CAST(500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-12T13:41:52.6095457' AS DateTime2), CAST(N'2021-07-12T13:41:52.6095457' AS DateTime2), 9, NULL, NULL, CAST(N'13:41:52.6095457' AS Time), N'', NULL, NULL, NULL, 2, CAST(12.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (30, N'pi-000009', 2, 9, N'p', N'2', CAST(10.0000 AS Decimal(20, 4)), CAST(12000000.00 AS Decimal(20, 2)), CAST(10800000.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-07-29' AS Date), CAST(N'2021-07-12T13:55:53.3930998' AS DateTime2), CAST(N'2021-07-15T13:04:39.7417740' AS DateTime2), 9, NULL, NULL, CAST(N'13:55:53.3930998' AS Time), N'', N'12333', CAST(N'2021-07-08T00:00:00.0000000' AS DateTime2), 3, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (31, N'pi-000009', 5, 9, N'pw', N'2', CAST(50.0000 AS Decimal(20, 4)), CAST(200000.00 AS Decimal(20, 2)), CAST(100000.00 AS Decimal(20, 2)), CAST(8400.00 AS Decimal(20, 2)), CAST(91600.00 AS Decimal(20, 2)), CAST(N'2021-07-31' AS Date), CAST(N'2021-07-12T13:57:24.3080336' AS DateTime2), CAST(N'2021-07-12T13:57:24.3080336' AS DateTime2), 9, NULL, NULL, CAST(N'13:57:24.3080336' AS Time), N'', N'213165', CAST(N'2021-07-12T00:00:00.0000000' AS DateTime2), 4, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (32, N'sb-000002', 13, 4, N'sb', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(4000.00 AS Decimal(20, 2)), CAST(19480.00 AS Decimal(20, 2)), CAST(19480.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-12T15:35:52.2318576' AS DateTime2), CAST(N'2021-07-12T15:35:52.2318576' AS DateTime2), 4, 15, NULL, CAST(N'15:35:52.2318576' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, 0, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (33, N'im-000002', NULL, 9, N'im', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-12T18:23:06.1158739' AS DateTime2), CAST(N'2021-07-12T18:23:06.1158739' AS DateTime2), 9, NULL, NULL, CAST(N'18:23:06.1158739' AS Time), NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (34, N'ex-000002', NULL, 9, N'exw', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-12T18:23:06.6539079' AS DateTime2), CAST(N'2021-07-12T18:23:06.6539079' AS DateTime2), 9, 33, NULL, CAST(N'18:23:06.6539079' AS Time), NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (35, N'pi-000009', 4, 9, N'pw', N'-1', NULL, CAST(500000.00 AS Decimal(20, 2)), CAST(500000.00 AS Decimal(20, 2)), CAST(3700.00 AS Decimal(20, 2)), CAST(496300.00 AS Decimal(20, 2)), CAST(N'2021-07-31' AS Date), CAST(N'2021-07-12T18:30:20.3796275' AS DateTime2), CAST(N'2021-07-12T18:30:20.3796275' AS DateTime2), 9, NULL, NULL, CAST(N'18:30:20.3796275' AS Time), N'', N'123355', CAST(N'2021-07-06T00:00:00.0000000' AS DateTime2), 10, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (36, N'im-000002', NULL, 9, N'im', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-12T18:38:00.2686095' AS DateTime2), CAST(N'2021-07-12T18:38:00.2686095' AS DateTime2), 9, NULL, NULL, CAST(N'18:38:00.2686095' AS Time), NULL, NULL, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (37, N'ex-000002', NULL, 9, N'exw', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-12T18:38:00.7119225' AS DateTime2), CAST(N'2021-07-12T18:38:00.7119225' AS DateTime2), 9, 36, NULL, CAST(N'18:38:00.7119225' AS Time), NULL, NULL, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (38, N'si-000014', NULL, 2, N's', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(1000.00 AS Decimal(20, 2)), CAST(1120.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-07-13T13:18:36.1650569' AS DateTime2), CAST(N'2021-07-13T13:18:36.1650569' AS DateTime2), 2, NULL, NULL, CAST(N'13:18:36.1650569' AS Time), N'', NULL, NULL, NULL, 2, CAST(12.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (40, N'pi-000009', 3, 1, N'p', N'-1', NULL, CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-07-24' AS Date), CAST(N'2021-07-13T16:17:22.9723625' AS DateTime2), CAST(N'2021-07-13T16:18:37.1138867' AS DateTime2), 1, NULL, NULL, CAST(N'16:17:22.9723625' AS Time), N'', N'0004575725', NULL, 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (41, N'ex-000003', NULL, 1, N'ex', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-14T15:20:43.2683419' AS DateTime2), CAST(N'2021-07-14T15:20:43.2683419' AS DateTime2), 1, NULL, NULL, CAST(N'15:20:43.2683419' AS Time), NULL, NULL, NULL, 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (42, N'im-000003', NULL, 1, N'im', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-14T15:20:43.7996474' AS DateTime2), CAST(N'2021-07-14T15:20:43.7996474' AS DateTime2), 1, 41, NULL, CAST(N'15:20:43.7996474' AS Time), NULL, NULL, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (43, N'im-000004', NULL, 1, N'im', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-14T15:21:34.4251142' AS DateTime2), CAST(N'2021-07-14T15:21:34.4251142' AS DateTime2), 1, NULL, NULL, CAST(N'15:21:34.4251142' AS Time), NULL, NULL, NULL, 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (44, N'ex-000004', NULL, 1, N'exw', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-14T15:21:34.8781340' AS DateTime2), CAST(N'2021-07-14T15:21:34.8781340' AS DateTime2), 1, 43, NULL, CAST(N'15:21:34.8781340' AS Time), NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (45, N'im-000005', NULL, 1, N'im', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-14T15:22:18.8317099' AS DateTime2), CAST(N'2021-07-14T15:22:18.8317099' AS DateTime2), 1, NULL, NULL, CAST(N'15:22:18.8317099' AS Time), NULL, NULL, NULL, 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (46, N'ex-000005', NULL, 1, N'ex', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-14T15:22:19.3161579' AS DateTime2), CAST(N'2021-07-14T15:26:06.5524512' AS DateTime2), 1, 45, NULL, CAST(N'15:22:19.3161579' AS Time), NULL, NULL, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (47, N'im-000006', NULL, 1, N'im', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-14T15:26:22.2399638' AS DateTime2), CAST(N'2021-07-14T15:26:22.2399638' AS DateTime2), 1, NULL, NULL, CAST(N'15:26:22.2399638' AS Time), NULL, NULL, NULL, 12, 19, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (48, N'ex-000006', NULL, 1, N'exw', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-14T15:26:22.7084760' AS DateTime2), CAST(N'2021-07-14T15:26:22.7084760' AS DateTime2), 1, 47, NULL, CAST(N'15:26:22.7084760' AS Time), NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (49, N'pi-000010', 2, 2, N'pd', N'-1', NULL, CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-29' AS Date), CAST(N'2021-07-15T13:00:20.4893379' AS DateTime2), CAST(N'2021-07-18T15:07:34.2288923' AS DateTime2), 1, NULL, NULL, CAST(N'13:00:20.4893379' AS Time), N'', N'00000000', NULL, 3, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (50, N'pb-000005', 2, 9, N'pb', N'-1', NULL, CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-07-29' AS Date), CAST(N'2021-07-15T13:01:56.0680763' AS DateTime2), CAST(N'2021-07-15T13:03:42.8973160' AS DateTime2), 2, 49, NULL, CAST(N'13:01:56.0680763' AS Time), N'', N'00000000', NULL, 2, 9, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 3, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (51, N'pi-000011', 6, 9, N'p', N'-1', NULL, CAST(100000000.00 AS Decimal(20, 2)), CAST(100000000.00 AS Decimal(20, 2)), CAST(100000000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2024-07-11' AS Date), CAST(N'2021-07-15T15:43:55.3069202' AS DateTime2), CAST(N'2021-07-15T15:50:58.1255859' AS DateTime2), 9, NULL, NULL, CAST(N'15:43:55.3069202' AS Time), N'', N'505', CAST(N'2021-07-15T00:00:00.0000000' AS DateTime2), 5, 9, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 3, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (52, N'si-000015', NULL, 2, N's', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(1000.00 AS Decimal(20, 2)), CAST(1100.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1100.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-15T16:23:45.1994174' AS DateTime2), CAST(N'2021-07-15T16:23:45.1994174' AS DateTime2), 2, NULL, NULL, CAST(N'16:23:45.1994174' AS Time), N'', NULL, NULL, NULL, 2, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (53, N'1', 2, 2, N'p', N'-1', NULL, CAST(20000.00 AS Decimal(20, 2)), CAST(20000.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-31' AS Date), CAST(N'2021-07-15T16:31:09.6414749' AS DateTime2), CAST(N'2021-07-18T16:36:22.6825555' AS DateTime2), 2, NULL, NULL, CAST(N'16:31:09.6414749' AS Time), N'', N'0000000', NULL, 5, 24, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 5, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (54, N'si-000016', NULL, 2, N's', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(2500.00 AS Decimal(20, 2)), CAST(2750.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(2750.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-15T16:32:48.1279631' AS DateTime2), CAST(N'2021-07-15T16:32:48.1279631' AS DateTime2), 2, NULL, NULL, CAST(N'16:32:48.1279631' AS Time), N'', NULL, NULL, NULL, 24, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 5, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (55, N'pi-000013', 5, 9, N'pw', N'-1', NULL, CAST(13000.00 AS Decimal(20, 2)), CAST(13000.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-17T19:19:29.1650305' AS DateTime2), CAST(N'2021-07-17T19:19:29.1650305' AS DateTime2), 9, NULL, NULL, CAST(N'19:19:29.1650305' AS Time), N'', N'5616khbj', CAST(N'2021-07-17T00:00:00.0000000' AS DateTime2), 11, 24, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 5, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (56, N'pi-000014', 3, 1, N'pw', N'-1', NULL, CAST(10000.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-19' AS Date), CAST(N'2021-07-18T12:27:06.8713733' AS DateTime2), CAST(N'2021-07-18T12:27:06.8713733' AS DateTime2), 1, NULL, NULL, CAST(N'12:27:06.8713733' AS Time), N'', N'12', CAST(N'2021-07-26T00:00:00.0000000' AS DateTime2), 12, 24, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 5, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (57, N'si-000017', 2, 2, N's', NULL, CAST(0.0000 AS Decimal(20, 4)), CAST(500.00 AS Decimal(20, 2)), CAST(550.00 AS Decimal(20, 2)), CAST(550.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-18T13:00:35.1019591' AS DateTime2), CAST(N'2021-07-18T13:00:35.1019591' AS DateTime2), 2, NULL, NULL, CAST(N'13:00:35.1019591' AS Time), N'', NULL, NULL, NULL, 24, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 5, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (58, N'pi-000015', 2, 1, N'pw', N'-1', NULL, CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-31' AS Date), CAST(N'2021-07-18T15:42:35.9968542' AS DateTime2), CAST(N'2021-07-18T15:42:35.9968542' AS DateTime2), 1, NULL, NULL, CAST(N'15:42:35.9968542' AS Time), N'', N'', NULL, 3, 24, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 5, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (59, N'2', NULL, 2, N'pd', N'-1', NULL, CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-07-18T15:48:41.5189758' AS DateTime2), CAST(N'2021-07-18T15:48:52.5134550' AS DateTime2), 2, NULL, NULL, CAST(N'15:48:41.5189758' AS Time), N'', N'', NULL, NULL, 24, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 5, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (60, N'1', NULL, 2, N'sd', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-18T15:49:23.4523183' AS DateTime2), CAST(N'2021-07-18T15:49:33.9403715' AS DateTime2), 2, NULL, NULL, CAST(N'15:49:23.4523183' AS Time), N'', NULL, NULL, NULL, 24, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 5, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (61, N'2', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(2500.00 AS Decimal(20, 2)), CAST(2750.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(2750.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-18T15:50:16.6846002' AS DateTime2), CAST(N'2021-07-18T15:50:26.5132270' AS DateTime2), 2, NULL, NULL, CAST(N'15:50:16.6846002' AS Time), N'', NULL, NULL, NULL, 24, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 5, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (62, N'si-000018', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(2500.00 AS Decimal(20, 2)), CAST(2750.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(2750.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-18T15:52:53.5699850' AS DateTime2), CAST(N'2021-07-18T15:52:53.5699850' AS DateTime2), 2, NULL, NULL, CAST(N'15:52:53.5699850' AS Time), N'', NULL, NULL, NULL, 2, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 5, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (63, N'si-000019', NULL, 1, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1200000.00 AS Decimal(20, 2)), CAST(1320000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1320000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-18T16:39:10.8092435' AS DateTime2), CAST(N'2021-07-18T16:39:10.8092435' AS DateTime2), 1, NULL, NULL, CAST(N'16:39:10.8092435' AS Time), N'', NULL, NULL, NULL, 24, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 5, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (64, N'1', NULL, 1, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(12000000.00 AS Decimal(20, 2)), CAST(13200000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(13200000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-18T16:56:37.3909323' AS DateTime2), CAST(N'2021-07-21T00:55:49.5214350' AS DateTime2), 1, NULL, NULL, CAST(N'16:56:37.3909323' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (65, N'3', NULL, 1, N'pd', N'-1', NULL, CAST(28175.00 AS Decimal(20, 2)), CAST(28175.00 AS Decimal(20, 2)), NULL, NULL, NULL, CAST(N'2021-07-18T16:58:41.2985980' AS DateTime2), CAST(N'2021-07-18T16:59:12.3141889' AS DateTime2), 1, NULL, NULL, CAST(N'16:58:41.2985980' AS Time), N'', N'', NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (66, N'pi-000016', 2, 1, N'p', N'-1', NULL, CAST(5000.00 AS Decimal(20, 2)), CAST(5000.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-08-31' AS Date), CAST(N'2021-07-18T18:41:45.2546066' AS DateTime2), CAST(N'2021-07-18T18:42:11.3334559' AS DateTime2), 1, NULL, NULL, CAST(N'18:41:45.2546066' AS Time), N'', N'26655887', CAST(N'2021-07-18T00:00:00.0000000' AS DateTime2), 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (67, N'pi-000017', 2, 2, N'p', N'-1', NULL, CAST(1194700.00 AS Decimal(20, 2)), CAST(1194700.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-07-28' AS Date), CAST(N'2021-07-18T19:20:11.4606617' AS DateTime2), CAST(N'2021-07-18T19:20:35.0232319' AS DateTime2), 2, NULL, NULL, CAST(N'19:20:11.4606617' AS Time), N'', N'0000', NULL, 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (68, N'si-000021', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1200000.00 AS Decimal(20, 2)), CAST(1320000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1320000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-18T19:21:38.5552962' AS DateTime2), CAST(N'2021-07-18T19:21:38.5552962' AS DateTime2), 2, NULL, NULL, CAST(N'19:21:38.5552962' AS Time), N'', NULL, NULL, NULL, 2, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (69, N'si-000022', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(2400000.00 AS Decimal(20, 2)), CAST(2640000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(2640000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-18T19:23:58.8544850' AS DateTime2), CAST(N'2021-07-18T19:23:58.8544850' AS DateTime2), 2, NULL, NULL, CAST(N'19:23:58.8544850' AS Time), N'', NULL, NULL, NULL, 2, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (70, N'pi-000018', 2, 2, N'p', N'-1', NULL, CAST(5000.00 AS Decimal(20, 2)), CAST(5000.00 AS Decimal(20, 2)), CAST(5000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-07-30' AS Date), CAST(N'2021-07-18T19:28:40.8578110' AS DateTime2), CAST(N'2021-07-18T19:29:37.5143635' AS DateTime2), 2, NULL, NULL, CAST(N'19:28:40.8578110' AS Time), N'', N'00000', NULL, 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (71, N'si-000023', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1200000.00 AS Decimal(20, 2)), CAST(1320000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1320000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-18T19:36:21.5391950' AS DateTime2), CAST(N'2021-07-18T19:36:21.5391950' AS DateTime2), 2, NULL, NULL, CAST(N'19:36:21.5391950' AS Time), N'', NULL, NULL, NULL, 2, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (72, N'si-000024', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1200000.00 AS Decimal(20, 2)), CAST(1320000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1320000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-18T19:36:39.6304739' AS DateTime2), CAST(N'2021-07-18T19:36:39.6304739' AS DateTime2), 2, NULL, NULL, CAST(N'19:36:39.6304739' AS Time), N'', NULL, NULL, NULL, 2, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (73, N'pi-000019', 2, 2, N'p', N'-1', NULL, CAST(3471700.00 AS Decimal(20, 2)), CAST(3818870.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-31' AS Date), CAST(N'2021-07-18T19:38:39.7574079' AS DateTime2), CAST(N'2021-07-18T19:39:30.6797474' AS DateTime2), 2, NULL, NULL, CAST(N'19:38:39.7574079' AS Time), N'', N'00000', CAST(N'2021-07-30T00:00:00.0000000' AS DateTime2), 2, 2, CAST(10.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (74, N'si-000025', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1200000.00 AS Decimal(20, 2)), CAST(1320000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1320000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-18T20:00:53.5725419' AS DateTime2), CAST(N'2021-07-18T20:00:53.5725419' AS DateTime2), 2, NULL, NULL, CAST(N'20:00:53.5725419' AS Time), N'', NULL, NULL, NULL, 2, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (75, N'pi-000020', 2, 2, N'p', N'-1', NULL, CAST(25000000.00 AS Decimal(20, 2)), CAST(27500000.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-31' AS Date), CAST(N'2021-07-18T20:04:26.0433532' AS DateTime2), CAST(N'2021-07-18T20:04:50.8717307' AS DateTime2), 2, NULL, NULL, CAST(N'20:04:26.0433532' AS Time), N'', N'00000', NULL, 2, 2, CAST(10.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (76, N'si-000026', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(500000.00 AS Decimal(20, 2)), CAST(550000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(550000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-18T20:04:57.6064092' AS DateTime2), CAST(N'2021-07-18T20:04:57.6064092' AS DateTime2), 2, NULL, NULL, CAST(N'20:04:57.6064092' AS Time), N'', NULL, NULL, NULL, 2, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (77, N'si-000027', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(500000.00 AS Decimal(20, 2)), CAST(550000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(550000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-18T20:09:54.5954119' AS DateTime2), CAST(N'2021-07-18T20:09:54.5954119' AS DateTime2), 2, NULL, NULL, CAST(N'20:09:54.5954119' AS Time), N'', NULL, NULL, NULL, 2, CAST(10.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (78, N'pi-000021', 5, 1, N'pw', N'1', CAST(1000.0000 AS Decimal(20, 4)), CAST(6000000.00 AS Decimal(20, 2)), CAST(5999000.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-10-31' AS Date), CAST(N'2021-07-19T10:33:42.6940902' AS DateTime2), CAST(N'2021-07-19T10:33:42.6940902' AS DateTime2), 1, NULL, NULL, CAST(N'10:33:42.6940902' AS Time), N'', N'2665548', CAST(N'2021-07-19T00:00:00.0000000' AS DateTime2), 7, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (79, N'im-000007', NULL, 1, N'im', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-23T23:06:16.5955974' AS DateTime2), CAST(N'2021-07-23T23:07:18.6119107' AS DateTime2), 1, NULL, NULL, CAST(N'23:06:16.5955974' AS Time), NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (80, N'ex-000007', NULL, 1, N'exw', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-23T23:06:17.0957293' AS DateTime2), CAST(N'2021-07-23T23:07:19.0179713' AS DateTime2), 1, 79, NULL, CAST(N'23:06:17.0957293' AS Time), NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (81, N'pb-000006', 3, 1, N'p', N'-1', NULL, CAST(0.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-07-24' AS Date), CAST(N'2021-07-24T10:34:05.8327761' AS DateTime2), CAST(N'2021-07-24T10:34:05.8327761' AS DateTime2), 1, 40, NULL, CAST(N'10:34:05.8327761' AS Time), N'', N'0004575725', NULL, 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (82, N'pb-000007', 3, 1, N'pb', N'-1', NULL, CAST(0.00 AS Decimal(20, 2)), CAST(20000.00 AS Decimal(20, 2)), CAST(20000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-07-24' AS Date), CAST(N'2021-07-24T10:34:48.3490922' AS DateTime2), CAST(N'2021-07-24T10:34:48.3490922' AS DateTime2), 1, 40, NULL, CAST(N'10:34:48.3490922' AS Time), N'', N'0004575725', NULL, 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (83, N'si-000028', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1000.00 AS Decimal(20, 2)), CAST(1000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-25T12:08:59.8753948' AS DateTime2), CAST(N'2021-07-25T12:08:59.8753948' AS DateTime2), 2, NULL, NULL, CAST(N'12:08:59.8753948' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (84, N'pi-000022', 2, 2, N'pbd', N'-1', NULL, CAST(300.00 AS Decimal(20, 2)), CAST(300.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(300.00 AS Decimal(20, 2)), CAST(N'2021-07-31' AS Date), CAST(N'2021-07-25T12:21:46.4148949' AS DateTime2), CAST(N'2021-07-25T12:34:27.8485226' AS DateTime2), 2, NULL, NULL, CAST(N'12:21:46.4148949' AS Time), N'', N'000000', NULL, 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (85, N'ex-000008', NULL, 2, N'ex', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-27T16:30:10.7685858' AS DateTime2), CAST(N'2021-07-27T16:30:10.7685858' AS DateTime2), 2, NULL, NULL, CAST(N'16:30:10.7685858' AS Time), NULL, NULL, NULL, 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (86, N'im-000008', NULL, 2, N'im', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-27T16:30:11.3308621' AS DateTime2), CAST(N'2021-07-27T16:30:11.3308621' AS DateTime2), 2, 85, NULL, CAST(N'16:30:11.3308621' AS Time), NULL, NULL, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (87, N'im-000009', NULL, 2, N'im', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-27T16:32:32.5018302' AS DateTime2), CAST(N'2021-07-27T16:32:32.5018302' AS DateTime2), 2, NULL, NULL, CAST(N'16:32:32.5018302' AS Time), NULL, NULL, NULL, 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (88, N'ex-000009', NULL, 2, N'exw', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-07-27T16:32:32.9393284' AS DateTime2), CAST(N'2021-07-27T16:32:32.9393284' AS DateTime2), 2, 87, NULL, CAST(N'16:32:32.9393284' AS Time), NULL, NULL, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (89, N'pi-000023', 5, 9, N'pw', N'1', CAST(10000.0000 AS Decimal(20, 4)), CAST(2000000.00 AS Decimal(20, 2)), CAST(1990000.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-10-30' AS Date), CAST(N'2021-07-28T15:59:33.3548902' AS DateTime2), CAST(N'2021-07-28T15:59:33.3548902' AS DateTime2), 9, NULL, NULL, CAST(N'15:59:33.3548902' AS Time), N'', N'aakkad123', NULL, 8, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (90, N'pi-000024', 2, 2, N'pw', N'1', CAST(10000.0000 AS Decimal(20, 4)), CAST(850604.00 AS Decimal(20, 2)), CAST(840604.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-31' AS Date), CAST(N'2021-07-28T16:01:54.2271628' AS DateTime2), CAST(N'2021-07-28T16:01:54.2271628' AS DateTime2), 2, NULL, NULL, CAST(N'16:01:54.2271628' AS Time), N'', N'00000', NULL, 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (91, N'pi-000025', 5, 2, N'pw', N'2', CAST(5.0000 AS Decimal(20, 4)), CAST(1893227.00 AS Decimal(20, 2)), CAST(1798565.65 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-31' AS Date), CAST(N'2021-07-28T16:02:42.0451415' AS DateTime2), CAST(N'2021-07-28T16:02:42.0451415' AS DateTime2), 2, NULL, NULL, CAST(N'16:02:42.0451415' AS Time), N'', N'00000', NULL, 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (92, N'si-000029', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(2401500.00 AS Decimal(20, 2)), CAST(2401500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(2401500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:15:36.5154192' AS DateTime2), CAST(N'2021-07-28T17:15:36.5154192' AS DateTime2), 2, NULL, NULL, CAST(N'17:15:36.5154192' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (93, N'si-000030', NULL, 1, N'sd', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(10000.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:16:32.9283441' AS DateTime2), CAST(N'2021-07-28T17:16:32.9283441' AS DateTime2), 1, NULL, NULL, CAST(N'17:16:32.9283441' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (94, N'si-000031', NULL, 2, N'sd', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1000.00 AS Decimal(20, 2)), CAST(1000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:23:36.9339530' AS DateTime2), CAST(N'2021-07-28T17:23:36.9339530' AS DateTime2), 2, NULL, NULL, CAST(N'17:23:36.9339530' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (95, N'2', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(3060000.00 AS Decimal(20, 2)), CAST(3060000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(3060000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:24:00.5590733' AS DateTime2), CAST(N'2021-07-28T17:24:06.2620973' AS DateTime2), 2, NULL, NULL, CAST(N'17:24:00.5590733' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (96, N'si-000032', NULL, 1, N'sd', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(2508000.00 AS Decimal(20, 2)), CAST(2508000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(2508000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:32:07.9096931' AS DateTime2), CAST(N'2021-07-28T17:32:07.9096931' AS DateTime2), 1, NULL, NULL, CAST(N'17:32:07.9096931' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (97, N'pi-000026', 1, 1, N'pw', N'-1', NULL, CAST(73926.00 AS Decimal(20, 2)), CAST(73926.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-30' AS Date), CAST(N'2021-07-28T17:33:27.5048488' AS DateTime2), CAST(N'2021-07-28T17:33:27.5048488' AS DateTime2), 1, NULL, NULL, CAST(N'17:33:27.5048488' AS Time), N'', N'000', NULL, 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (98, N'pi-000027', 5, 1, N'pw', N'-1', NULL, CAST(150000.00 AS Decimal(20, 2)), CAST(150000.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-31' AS Date), CAST(N'2021-07-28T17:34:35.2090846' AS DateTime2), CAST(N'2021-07-28T17:34:35.2090846' AS DateTime2), 1, NULL, NULL, CAST(N'17:34:35.2090846' AS Time), N'', N'2222', NULL, 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (99, N'si-000033', NULL, 1, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(5000.00 AS Decimal(20, 2)), CAST(5000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(5000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:35:17.5376215' AS DateTime2), CAST(N'2021-07-28T17:35:17.5376215' AS DateTime2), 1, NULL, NULL, CAST(N'17:35:17.5376215' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (100, N'si-000034', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1200000.00 AS Decimal(20, 2)), CAST(1200000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1200000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:37:11.9140556' AS DateTime2), CAST(N'2021-07-28T17:37:11.9140556' AS DateTime2), 2, NULL, NULL, CAST(N'17:37:11.9140556' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (101, N'si-000035', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(500000.00 AS Decimal(20, 2)), CAST(500000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(500000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:37:19.2267345' AS DateTime2), CAST(N'2021-07-28T17:37:19.2267345' AS DateTime2), 2, NULL, NULL, CAST(N'17:37:19.2267345' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (102, N'si-000036', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(500.00 AS Decimal(20, 2)), CAST(500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:37:26.6957207' AS DateTime2), CAST(N'2021-07-28T17:37:26.6957207' AS DateTime2), 2, NULL, NULL, CAST(N'17:37:26.6957207' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (103, N'si-000037', NULL, 1, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:44:29.0601270' AS DateTime2), CAST(N'2021-07-28T17:44:29.0601270' AS DateTime2), 1, NULL, NULL, CAST(N'17:44:29.0601270' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (104, N'si-000038', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:45:49.9985950' AS DateTime2), CAST(N'2021-07-28T17:45:49.9985950' AS DateTime2), 2, NULL, NULL, CAST(N'17:45:49.9985950' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (105, N'si-000039', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:46:41.9993000' AS DateTime2), CAST(N'2021-07-28T17:46:41.9993000' AS DateTime2), 2, NULL, NULL, CAST(N'17:46:41.9993000' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (106, N'si-000040', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:47:06.2495503' AS DateTime2), CAST(N'2021-07-28T17:47:06.2495503' AS DateTime2), 2, NULL, NULL, CAST(N'17:47:06.2495503' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (107, N'si-000041', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:47:46.9061344' AS DateTime2), CAST(N'2021-07-28T17:47:46.9061344' AS DateTime2), 2, NULL, NULL, CAST(N'17:47:46.9061344' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (108, N'si-000042', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:48:59.5791309' AS DateTime2), CAST(N'2021-07-28T17:48:59.5791309' AS DateTime2), 2, NULL, NULL, CAST(N'17:48:59.5791309' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (109, N'si-000043', NULL, 1, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:51:52.1747273' AS DateTime2), CAST(N'2021-07-28T17:51:52.1747273' AS DateTime2), 1, NULL, NULL, CAST(N'17:51:52.1747273' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (110, N'si-000044', NULL, 9, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(23000.00 AS Decimal(20, 2)), CAST(23000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(23000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:52:00.6123302' AS DateTime2), CAST(N'2021-07-28T17:52:00.6123302' AS DateTime2), 9, NULL, NULL, CAST(N'17:52:00.6123302' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (111, N'si-000045', NULL, 9, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:53:02.9722961' AS DateTime2), CAST(N'2021-07-28T17:53:02.9722961' AS DateTime2), 9, NULL, NULL, CAST(N'17:53:02.9722961' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (112, N'si-000046', NULL, 9, N'sd', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:53:43.0352766' AS DateTime2), CAST(N'2021-07-28T17:53:43.0352766' AS DateTime2), 9, NULL, NULL, CAST(N'17:53:43.0352766' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (113, N'si-000047', NULL, 1, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:54:13.0670353' AS DateTime2), CAST(N'2021-07-28T17:54:13.0670353' AS DateTime2), 1, NULL, NULL, CAST(N'17:54:13.0670353' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (114, N'si-000048', NULL, 1, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1200000.00 AS Decimal(20, 2)), CAST(1200000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1200000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:54:43.1609631' AS DateTime2), CAST(N'2021-07-28T17:54:43.1609631' AS DateTime2), 1, NULL, NULL, CAST(N'17:54:43.1609631' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (115, N'si-000049', NULL, 9, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:57:13.4127322' AS DateTime2), CAST(N'2021-07-28T17:57:13.4127322' AS DateTime2), 9, NULL, NULL, CAST(N'17:57:13.4127322' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
GO
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (116, N'si-000050', NULL, 9, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1000.00 AS Decimal(20, 2)), CAST(1000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:57:47.6632847' AS DateTime2), CAST(N'2021-07-28T17:57:47.6632847' AS DateTime2), 9, NULL, NULL, CAST(N'17:57:47.6632847' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (117, N'si-000051', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1500.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:58:10.5229149' AS DateTime2), CAST(N'2021-07-28T17:58:10.5229149' AS DateTime2), 2, NULL, NULL, CAST(N'17:58:10.5229149' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (118, N'si-000052', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(501000.00 AS Decimal(20, 2)), CAST(501000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(501000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T17:59:08.8827030' AS DateTime2), CAST(N'2021-07-28T17:59:08.8827030' AS DateTime2), 2, NULL, NULL, CAST(N'17:59:08.8827030' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (119, N'si-000053', NULL, 9, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(10000.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T18:00:22.2275142' AS DateTime2), CAST(N'2021-07-28T18:00:22.2275142' AS DateTime2), 9, NULL, NULL, CAST(N'18:00:22.2275142' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (120, N'pi-000028', 5, 9, N'pw', N'-1', NULL, CAST(100.00 AS Decimal(20, 2)), CAST(100.00 AS Decimal(20, 2)), NULL, NULL, CAST(N'2021-07-30' AS Date), CAST(N'2021-07-28T18:04:10.5428361' AS DateTime2), CAST(N'2021-07-28T18:04:58.3562293' AS DateTime2), 9, NULL, NULL, CAST(N'18:04:10.5428361' AS Time), N'', N'00000', NULL, 3, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus]) VALUES (121, N'si-000054', NULL, 9, N'sd', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(1000.00 AS Decimal(20, 2)), CAST(1000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(1000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-28T18:15:02.9264472' AS DateTime2), CAST(N'2021-07-28T18:15:02.9264472' AS DateTime2), 9, NULL, NULL, CAST(N'18:15:02.9264472' AS Time), N'', NULL, NULL, NULL, 2, CAST(0.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[invoiceStatus] ON 

INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1, 57, N'pr', CAST(N'2021-07-18T13:00:37.0217947' AS DateTime2), CAST(N'2021-07-18T13:00:37.0217947' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (2, 57, N'ex', CAST(N'2021-07-18T13:00:37.2814095' AS DateTime2), CAST(N'2021-07-18T13:00:37.2814095' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (3, 57, N'rc', CAST(N'2021-07-18T13:00:37.4911851' AS DateTime2), CAST(N'2021-07-18T13:00:37.4911851' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (4, 61, N'pr', CAST(N'2021-07-18T15:50:28.3650250' AS DateTime2), CAST(N'2021-07-18T15:50:28.3650250' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (5, 61, N'ex', CAST(N'2021-07-18T15:50:28.5924930' AS DateTime2), CAST(N'2021-07-18T15:50:28.5924930' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (6, 61, N'rc', CAST(N'2021-07-18T15:50:28.8073209' AS DateTime2), CAST(N'2021-07-18T15:50:28.8073209' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (7, 62, N'pr', CAST(N'2021-07-18T15:52:55.3190273' AS DateTime2), CAST(N'2021-07-18T15:52:55.3190273' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (8, 62, N'ex', CAST(N'2021-07-18T15:52:55.5296249' AS DateTime2), CAST(N'2021-07-18T15:52:55.5296249' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (9, 62, N'rc', CAST(N'2021-07-18T15:52:55.7418551' AS DateTime2), CAST(N'2021-07-18T15:52:55.7418551' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (10, 63, N'pr', CAST(N'2021-07-18T16:39:12.4810088' AS DateTime2), CAST(N'2021-07-18T16:39:12.4810088' AS DateTime2), 1, 1, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (11, 63, N'ex', CAST(N'2021-07-18T16:39:12.6998605' AS DateTime2), CAST(N'2021-07-18T16:39:12.6998605' AS DateTime2), 1, 1, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (12, 63, N'rc', CAST(N'2021-07-18T16:39:12.9188334' AS DateTime2), CAST(N'2021-07-18T16:39:12.9188334' AS DateTime2), 1, 1, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (13, 68, N'pr', CAST(N'2021-07-18T19:21:40.0868456' AS DateTime2), CAST(N'2021-07-18T19:21:40.0868456' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (14, 68, N'ex', CAST(N'2021-07-18T19:21:40.3524037' AS DateTime2), CAST(N'2021-07-18T19:21:40.3524037' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (15, 68, N'rc', CAST(N'2021-07-18T19:21:40.6334192' AS DateTime2), CAST(N'2021-07-18T19:21:40.6334192' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (16, 69, N'pr', CAST(N'2021-07-18T19:24:00.2604264' AS DateTime2), CAST(N'2021-07-18T19:24:00.2604264' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (17, 69, N'ex', CAST(N'2021-07-18T19:24:00.4489751' AS DateTime2), CAST(N'2021-07-18T19:24:00.4489751' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (18, 69, N'rc', CAST(N'2021-07-18T19:24:00.6513471' AS DateTime2), CAST(N'2021-07-18T19:24:00.6513471' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (19, 71, N'pr', CAST(N'2021-07-18T19:36:22.9580625' AS DateTime2), CAST(N'2021-07-18T19:36:22.9580625' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (20, 71, N'ex', CAST(N'2021-07-18T19:36:23.1456385' AS DateTime2), CAST(N'2021-07-18T19:36:23.1456385' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (21, 71, N'rc', CAST(N'2021-07-18T19:36:23.3485685' AS DateTime2), CAST(N'2021-07-18T19:36:23.3485685' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (22, 72, N'pr', CAST(N'2021-07-18T19:36:40.9117073' AS DateTime2), CAST(N'2021-07-18T19:36:40.9117073' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (23, 72, N'ex', CAST(N'2021-07-18T19:36:41.1301671' AS DateTime2), CAST(N'2021-07-18T19:36:41.1301671' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (24, 72, N'rc', CAST(N'2021-07-18T19:36:41.3957782' AS DateTime2), CAST(N'2021-07-18T19:36:41.3957782' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (25, 74, N'pr', CAST(N'2021-07-18T20:00:54.9474876' AS DateTime2), CAST(N'2021-07-18T20:00:54.9474876' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (26, 74, N'ex', CAST(N'2021-07-18T20:00:55.1664077' AS DateTime2), CAST(N'2021-07-18T20:00:55.1664077' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (27, 74, N'rc', CAST(N'2021-07-18T20:00:55.3534892' AS DateTime2), CAST(N'2021-07-18T20:00:55.3534892' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (28, 76, N'pr', CAST(N'2021-07-18T20:04:58.8722302' AS DateTime2), CAST(N'2021-07-18T20:04:58.8722302' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (29, 76, N'ex', CAST(N'2021-07-18T20:04:59.2001112' AS DateTime2), CAST(N'2021-07-18T20:04:59.2001112' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (30, 76, N'rc', CAST(N'2021-07-18T20:04:59.4034424' AS DateTime2), CAST(N'2021-07-18T20:04:59.4034424' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (31, 77, N'pr', CAST(N'2021-07-18T20:09:55.9856818' AS DateTime2), CAST(N'2021-07-18T20:09:55.9856818' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (32, 77, N'ex', CAST(N'2021-07-18T20:09:56.2202062' AS DateTime2), CAST(N'2021-07-18T20:09:56.2202062' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (33, 77, N'rc', CAST(N'2021-07-18T20:09:56.4077840' AS DateTime2), CAST(N'2021-07-18T20:09:56.4077840' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (34, 64, N'pr', CAST(N'2021-07-21T00:55:53.6933355' AS DateTime2), CAST(N'2021-07-21T00:55:53.6933355' AS DateTime2), 1, 1, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (35, 64, N'ex', CAST(N'2021-07-21T00:55:53.8964597' AS DateTime2), CAST(N'2021-07-21T00:55:53.8964597' AS DateTime2), 1, 1, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (36, 64, N'rc', CAST(N'2021-07-21T00:55:54.0840060' AS DateTime2), CAST(N'2021-07-21T00:55:54.0840060' AS DateTime2), 1, 1, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (37, 83, N'pr', CAST(N'2021-07-25T12:09:02.0195937' AS DateTime2), CAST(N'2021-07-25T12:09:02.0195937' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (38, 83, N'ex', CAST(N'2021-07-25T12:09:02.2502668' AS DateTime2), CAST(N'2021-07-25T12:09:02.2502668' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (39, 83, N'rc', CAST(N'2021-07-25T12:09:02.5314410' AS DateTime2), CAST(N'2021-07-25T12:09:02.5314410' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (40, 92, N'pr', CAST(N'2021-07-28T17:15:38.5847647' AS DateTime2), CAST(N'2021-07-28T17:15:38.5847647' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (41, 92, N'ex', CAST(N'2021-07-28T17:15:38.8181706' AS DateTime2), CAST(N'2021-07-28T17:15:38.8181706' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (42, 92, N'rc', CAST(N'2021-07-28T17:15:39.0346672' AS DateTime2), CAST(N'2021-07-28T17:15:39.0346672' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (43, 95, N'pr', CAST(N'2021-07-28T17:24:07.7310657' AS DateTime2), CAST(N'2021-07-28T17:24:07.7310657' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (44, 95, N'ex', CAST(N'2021-07-28T17:24:07.9499691' AS DateTime2), CAST(N'2021-07-28T17:24:07.9499691' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (45, 95, N'rc', CAST(N'2021-07-28T17:24:08.1683813' AS DateTime2), CAST(N'2021-07-28T17:24:08.1683813' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (46, 100, N'pr', CAST(N'2021-07-28T17:37:13.3516371' AS DateTime2), CAST(N'2021-07-28T17:37:13.3516371' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (47, 100, N'ex', CAST(N'2021-07-28T17:37:13.5703834' AS DateTime2), CAST(N'2021-07-28T17:37:13.5703834' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (48, 100, N'rc', CAST(N'2021-07-28T17:37:13.7893091' AS DateTime2), CAST(N'2021-07-28T17:37:13.7893091' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (49, 101, N'pr', CAST(N'2021-07-28T17:37:20.6176772' AS DateTime2), CAST(N'2021-07-28T17:37:20.6176772' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (50, 101, N'ex', CAST(N'2021-07-28T17:37:20.8203508' AS DateTime2), CAST(N'2021-07-28T17:37:20.8203508' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (51, 101, N'rc', CAST(N'2021-07-28T17:37:21.0392851' AS DateTime2), CAST(N'2021-07-28T17:37:21.0392851' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (52, 102, N'pr', CAST(N'2021-07-28T17:37:28.2114898' AS DateTime2), CAST(N'2021-07-28T17:37:28.2114898' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (53, 102, N'ex', CAST(N'2021-07-28T17:37:28.4142451' AS DateTime2), CAST(N'2021-07-28T17:37:28.4142451' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (54, 102, N'rc', CAST(N'2021-07-28T17:37:28.6331812' AS DateTime2), CAST(N'2021-07-28T17:37:28.6331812' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (55, 106, N'pr', CAST(N'2021-07-28T17:47:07.6713177' AS DateTime2), CAST(N'2021-07-28T17:47:07.6713177' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (56, 106, N'ex', CAST(N'2021-07-28T17:47:07.8745147' AS DateTime2), CAST(N'2021-07-28T17:47:07.8745147' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (57, 106, N'rc', CAST(N'2021-07-28T17:47:08.1087872' AS DateTime2), CAST(N'2021-07-28T17:47:08.1087872' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (58, 110, N'pr', CAST(N'2021-07-28T17:52:02.1122683' AS DateTime2), CAST(N'2021-07-28T17:52:02.1122683' AS DateTime2), 9, 9, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (59, 110, N'ex', CAST(N'2021-07-28T17:52:02.3787430' AS DateTime2), CAST(N'2021-07-28T17:52:02.3787430' AS DateTime2), 9, 9, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (60, 110, N'rc', CAST(N'2021-07-28T17:52:02.5966790' AS DateTime2), CAST(N'2021-07-28T17:52:02.5966790' AS DateTime2), 9, 9, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (61, 111, N'pr', CAST(N'2021-07-28T17:53:04.3476504' AS DateTime2), CAST(N'2021-07-28T17:53:04.3476504' AS DateTime2), 9, 9, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (62, 111, N'ex', CAST(N'2021-07-28T17:53:04.5504891' AS DateTime2), CAST(N'2021-07-28T17:53:04.5504891' AS DateTime2), 9, 9, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (63, 111, N'rc', CAST(N'2021-07-28T17:53:04.7694206' AS DateTime2), CAST(N'2021-07-28T17:53:04.7694206' AS DateTime2), 9, 9, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (64, 117, N'pr', CAST(N'2021-07-28T17:58:12.0226464' AS DateTime2), CAST(N'2021-07-28T17:58:12.0226464' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (65, 117, N'ex', CAST(N'2021-07-28T17:58:12.2417669' AS DateTime2), CAST(N'2021-07-28T17:58:12.2417669' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (66, 117, N'rc', CAST(N'2021-07-28T17:58:12.4602001' AS DateTime2), CAST(N'2021-07-28T17:58:12.4602001' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (67, 118, N'pr', CAST(N'2021-07-28T17:59:10.2890584' AS DateTime2), CAST(N'2021-07-28T17:59:10.2890584' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (68, 118, N'ex', CAST(N'2021-07-28T17:59:10.5080622' AS DateTime2), CAST(N'2021-07-28T17:59:10.5080622' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (69, 118, N'rc', CAST(N'2021-07-28T17:59:10.7265137' AS DateTime2), CAST(N'2021-07-28T17:59:10.7265137' AS DateTime2), 2, 2, NULL, 1)
SET IDENTITY_INSERT [dbo].[invoiceStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[items] ON 

INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (1, N'BS', N'barcode scanner', N'barcode scanner', N'n', N'57440ff6b80f068efd50410ea24fd593.png', CAST(5.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:08:07.3467846' AS DateTime2), CAST(N'2021-07-04T13:56:50.3030559' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (2, N'BP', N'barcode printer', N'barcode printer', N'n', N'c37858823db0093766eee74d8ee1f1e5.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:09:25.5952307' AS DateTime2), CAST(N'2021-07-04T13:56:50.3100404' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (3, N'CDR', N'Cash Drawer', N'Cash Drawer', N'n', N'71f020248a405d21e94d1de52043bed4.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:10:03.0032564' AS DateTime2), CAST(N'2021-07-04T13:56:50.3130305' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (4, N'PP2', N'POZONE-POS2', N'POZONE-POS2', N'n', N'd2ec5f1ed83abfca0dfec76506b696b3.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:10:39.3201683' AS DateTime2), CAST(N'2021-07-04T13:56:50.3180187' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (5, N't820', N'POZONE-t820-POS', N'POZONE-t820-POS', N'n', N'f96f8a89e2143f1e43a2ba7953fb5413.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:10:57.6681411' AS DateTime2), CAST(N'2021-07-04T13:56:50.3259931' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (6, N't835', N'POZONE-t835-POS', N'POZONE-t835-POS', N'n', N'56a2e0231c3d394ace201adf37d13f63.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 1, NULL, CAST(N'2021-07-01T14:11:26.2708755' AS DateTime2), CAST(N'2021-07-04T13:56:50.3309804' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (7, N'TR', N'Thermal-rolls', N'Thermal-rolls', N'n', N'3204215c19f25609034d24451f7e03d7.png', CAST(5.00 AS Decimal(20, 2)), 1, 24, 5, 1, NULL, CAST(N'2021-07-01T14:12:09.8270752' AS DateTime2), CAST(N'2021-07-04T13:56:50.3349718' AS DateTime2), 1, 1, 1, 4)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (8, N'LCP', N'laundry casheir', N'laundry-casheir-program', N'sr', N'6a5d62c1233b5e9b2000dd13aadf81f4.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 3, NULL, CAST(N'2021-07-01T14:13:13.5160401' AS DateTime2), CAST(N'2021-07-24T17:01:33.0214937' AS DateTime2), 1, 1, 1, 4)
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
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (19, N'M-BR', N'بروفين ', N'بروفين  400', N'd', N'b06b32577361609a56f8d74e9e127a01.png', CAST(0.00 AS Decimal(20, 2)), 1, 5, 12, 17, NULL, CAST(N'2021-07-01T14:29:08.0748019' AS DateTime2), CAST(N'2021-07-04T13:56:13.4023552' AS DateTime2), 1, 1, 1, 3)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (20, N'M-bS', N'باراسيتامول ', N'باراسيتامول ', N'd', N'cba6ef02fcbd47ba36115f8f64248594.png', CAST(0.00 AS Decimal(20, 2)), 1, 10, 1, 17, NULL, CAST(N'2021-07-01T14:29:59.6125734' AS DateTime2), CAST(N'2021-07-04T13:56:13.4033515' AS DateTime2), 1, 1, 1, 3)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (21, N'IPH-11', N'Iphone 11', N'Iphone 11', N'sn', N'90f607ba318fce94cafe1571617d1b6c.png', CAST(10.00 AS Decimal(20, 2)), 1, 0, 0, 4, NULL, CAST(N'2021-07-01T14:30:50.2396205' AS DateTime2), CAST(N'2021-07-28T17:00:49.5217515' AS DateTime2), 1, 2, 1, 1)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (22, N'IPH-11G', N'Iphone 11 Gold', N'Iphone 11 Gold', N'sn', N'77d0501bbf02ad459f88ab4b7531b14d.jpg', CAST(10.00 AS Decimal(20, 2)), 1, 0, 0, 4, NULL, CAST(N'2021-07-01T14:33:45.9001780' AS DateTime2), CAST(N'2021-07-12T15:47:27.0826403' AS DateTime2), 1, 2, 1, 1)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (23, N'1', N'backage1', N'details1', N'', N'e8a124154d6b4436a9d47827fcd24d4d.png', CAST(20.00 AS Decimal(20, 2)), 0, NULL, NULL, 2, NULL, CAST(N'2021-07-14T14:34:34.8704274' AS DateTime2), CAST(N'2021-07-15T13:20:31.2680816' AS DateTime2), 3, 3, NULL, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (24, N'2', N'package2', N'details2', N'p', N'3f85263e6e6e21f6a4057fab7f956f1b.png', CAST(20.00 AS Decimal(20, 2)), 1, NULL, NULL, 2, NULL, CAST(N'2021-07-14T14:41:51.9347184' AS DateTime2), CAST(N'2021-07-26T10:36:09.9751322' AS DateTime2), 3, 3, NULL, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (26, N'3', N'package3', N'details3', N'', N'37de6228ecdaf854ca17e0abd1062763.jpg', CAST(20.00 AS Decimal(20, 2)), 1, NULL, NULL, 4, NULL, CAST(N'2021-07-15T12:35:10.2370133' AS DateTime2), CAST(N'2021-07-17T10:15:16.0668990' AS DateTime2), 3, 3, NULL, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (27, N'4', N'name1', N'datails1', N'', N'15c139cdb9cb2a3e6788751f02626b1e.png', CAST(12.00 AS Decimal(20, 2)), 1, NULL, NULL, 4, NULL, CAST(N'2021-07-17T10:36:41.1307997' AS DateTime2), CAST(N'2021-07-17T10:37:43.7572240' AS DateTime2), 3, 3, NULL, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (28, N'CDRb', N'Cash Drawer-black', N'Cash Drawer', N'n', N'b754f525b6f76b3c7201c0d029f5b267.png', CAST(5.00 AS Decimal(20, 2)), 1, 10, 1, 1, 3, CAST(N'2021-07-24T16:46:56.0586229' AS DateTime2), CAST(N'2021-07-24T16:54:24.4054444' AS DateTime2), 1, 1, 1, 2)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (29, N'12', N'package1', N'details1', N'p', N'66b335393cbb2b27cf54475a279dc1be.png', CAST(20.00 AS Decimal(20, 2)), 1, NULL, NULL, 6, NULL, CAST(N'2021-07-26T10:36:29.7836479' AS DateTime2), CAST(N'2021-07-26T11:38:09.6915950' AS DateTime2), 3, 3, NULL, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (30, N'14', N'package3', N'details3', N'p', N'f2fed73dd13758a54ab2be16f5bb5171.png', CAST(15.00 AS Decimal(20, 2)), 1, NULL, NULL, 4, NULL, CAST(N'2021-07-26T10:37:42.9909910' AS DateTime2), CAST(N'2021-07-26T10:37:42.9909910' AS DateTime2), 3, 3, NULL, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId]) VALUES (31, N'13', N'name3', N'details3', N'p', N'77b0157cfc76ae37db589ccef70d65f4.png', CAST(2.00 AS Decimal(20, 2)), 1, NULL, NULL, 3, NULL, CAST(N'2021-07-26T10:41:59.4600843' AS DateTime2), CAST(N'2021-07-26T10:41:59.4600843' AS DateTime2), 3, 3, NULL, NULL)
SET IDENTITY_INSERT [dbo].[items] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsLocations] ON 

INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (1, 10, 112, CAST(N'2021-07-04T16:17:28.0526553' AS DateTime2), CAST(N'2021-07-27T16:30:10.2060552' AS DateTime2), 1, 2, NULL, NULL, 9, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (3, 10, 156, CAST(N'2021-07-04T16:17:28.1753201' AS DateTime2), CAST(N'2021-07-27T16:30:10.2374977' AS DateTime2), 1, 2, NULL, NULL, 11, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (4, 10, 50, CAST(N'2021-07-04T17:03:59.7703711' AS DateTime2), CAST(N'2021-07-04T17:03:59.7703711' AS DateTime2), 1, 1, NULL, NULL, 6, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (8, 17, 36, CAST(N'2021-07-11T12:27:39.3339834' AS DateTime2), CAST(N'2021-07-14T15:20:42.7056413' AS DateTime2), 2, 1, CAST(N'2021-07-01' AS Date), CAST(N'2021-07-31' AS Date), 7, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (9, 18, 0, CAST(N'2021-07-11T12:27:54.3356373' AS DateTime2), CAST(N'2021-07-27T16:30:10.2218023' AS DateTime2), 2, 2, CAST(N'2021-07-01' AS Date), CAST(N'2021-07-31' AS Date), 11, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (21, 2, 55, CAST(N'2021-07-15T13:04:39.9758949' AS DateTime2), CAST(N'2021-07-15T13:04:39.9758949' AS DateTime2), 9, 9, NULL, NULL, 6, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (23, 38, 999, CAST(N'2021-07-15T16:28:31.8588873' AS DateTime2), CAST(N'2021-07-18T16:39:11.3873534' AS DateTime2), 2, 2, NULL, NULL, 6, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (25, 38, 46, CAST(N'2021-07-15T16:31:52.4233803' AS DateTime2), CAST(N'2021-07-15T16:31:52.4233803' AS DateTime2), 2, 2, CAST(N'2021-07-01' AS Date), CAST(N'2021-07-31' AS Date), 9, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (26, 38, 50, CAST(N'2021-07-15T16:32:05.6419779' AS DateTime2), CAST(N'2021-07-15T16:32:05.6419779' AS DateTime2), 2, 2, CAST(N'2021-07-01' AS Date), CAST(N'2021-07-01' AS Date), 9, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (27, 1, 25, CAST(N'2021-07-18T19:20:35.2264378' AS DateTime2), CAST(N'2021-07-18T19:20:35.2264378' AS DateTime2), 2, 2, NULL, NULL, 1, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (28, 1, 84, CAST(N'2021-07-18T19:20:35.2421471' AS DateTime2), CAST(N'2021-07-28T17:37:12.3672416' AS DateTime2), 2, 2, NULL, NULL, 6, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (29, 1, 13, CAST(N'2021-07-18T19:20:35.2731098' AS DateTime2), CAST(N'2021-07-27T16:30:10.1903220' AS DateTime2), 2, 2, NULL, NULL, 9, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (30, 1, 13, CAST(N'2021-07-18T19:20:35.2731098' AS DateTime2), CAST(N'2021-07-27T16:30:10.2218023' AS DateTime2), 2, 2, NULL, NULL, 11, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (31, 1, 63, CAST(N'2021-07-18T19:20:35.2887917' AS DateTime2), CAST(N'2021-07-18T19:29:37.7490030' AS DateTime2), 2, 2, NULL, NULL, 17, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (36, 1, 42, CAST(N'2021-07-18T19:39:30.9141015' AS DateTime2), CAST(N'2021-07-28T17:52:01.0811822' AS DateTime2), 2, 2, NULL, NULL, 3, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (37, 1, 45, CAST(N'2021-07-18T19:39:30.9141015' AS DateTime2), CAST(N'2021-07-28T17:59:09.3358106' AS DateTime2), 2, 2, NULL, NULL, 8, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (38, 1, 46, CAST(N'2021-07-18T19:39:30.9141015' AS DateTime2), CAST(N'2021-07-28T17:58:11.0070100' AS DateTime2), 2, 2, NULL, NULL, 12, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (41, 22, 90, CAST(N'2021-07-18T20:09:41.7512952' AS DateTime2), CAST(N'2021-07-28T17:59:09.3358106' AS DateTime2), 2, 2, NULL, NULL, 18, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (42, 23, 50, CAST(N'2021-07-19T12:47:16.6586954' AS DateTime2), CAST(N'2021-07-19T12:47:16.6586954' AS DateTime2), 2, 2, NULL, NULL, 1, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (43, 22, 12, CAST(N'2021-07-19T12:47:26.4557301' AS DateTime2), CAST(N'2021-07-19T12:47:26.4557301' AS DateTime2), 2, 2, NULL, NULL, 17, N'')
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (44, 20, 49, CAST(N'2021-07-24T10:53:31.0513155' AS DateTime2), CAST(N'2021-07-28T17:37:27.1331308' AS DateTime2), 1, 1, CAST(N'2021-07-08' AS Date), CAST(N'2021-07-27' AS Date), 10, N'')
SET IDENTITY_INSERT [dbo].[itemsLocations] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsOffers] ON 

INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (4, 6, 1, NULL, CAST(N'2021-07-11T17:50:11.9894700' AS DateTime2), 2, 2, 10)
INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (5, 1, 2, NULL, CAST(N'2021-07-11T18:49:28.7705399' AS DateTime2), 9, 9, 100)
INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (6, 2, 2, NULL, CAST(N'2021-07-11T18:49:28.7705399' AS DateTime2), 9, 9, 100)
INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (7, 3, 2, NULL, CAST(N'2021-07-11T18:49:28.7705399' AS DateTime2), 9, 9, 100)
INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (8, 6, 2, NULL, CAST(N'2021-07-11T18:49:28.7705399' AS DateTime2), 9, 9, 100)
INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (9, 9, 2, NULL, CAST(N'2021-07-11T18:49:28.7705399' AS DateTime2), 9, 9, 50)
INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (10, 10, 2, NULL, CAST(N'2021-07-11T18:49:28.7705399' AS DateTime2), 9, 9, 50)
INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (11, 11, 2, NULL, CAST(N'2021-07-11T18:49:28.7705399' AS DateTime2), 9, 9, 50)
INSERT [dbo].[itemsOffers] ([ioId], [iuId], [offerId], [createDate], [updateDate], [createUserId], [updateUserId], [quantity]) VALUES (12, 12, 2, NULL, CAST(N'2021-07-11T18:49:28.7705399' AS DateTime2), 9, 9, 10)
SET IDENTITY_INSERT [dbo].[itemsOffers] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsProp] ON 

INSERT [dbo].[itemsProp] ([itemPropId], [propertyItemId], [itemId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (2, 1, 1, CAST(N'2021-07-01T14:37:23.8934926' AS DateTime2), CAST(N'2021-07-01T14:37:23.8934926' AS DateTime2), 1, 1)
INSERT [dbo].[itemsProp] ([itemPropId], [propertyItemId], [itemId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (5, 3, 28, CAST(N'2021-07-24T16:47:20.8237469' AS DateTime2), CAST(N'2021-07-24T16:47:20.8237469' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[itemsProp] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsTransfer] ON 

INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (25, 1, 14, NULL, NULL, CAST(N'2021-07-11T12:29:05.2006175' AS DateTime2), CAST(N'2021-07-11T12:29:05.2006175' AS DateTime2), 2, 2, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (26, 4, 15, NULL, NULL, CAST(N'2021-07-11T12:30:12.9962610' AS DateTime2), CAST(N'2021-07-11T12:30:12.9962610' AS DateTime2), 2, 2, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (27, 4, 16, NULL, NULL, CAST(N'2021-07-11T12:30:14.7841089' AS DateTime2), CAST(N'2021-07-11T12:30:14.7841089' AS DateTime2), 2, 2, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (28, 1, 18, NULL, NULL, CAST(N'2021-07-11T13:12:59.2528124' AS DateTime2), CAST(N'2021-07-11T13:12:59.2528124' AS DateTime2), 2, 2, NULL, CAST(1250.00 AS Decimal(20, 2)), 11, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (29, 11, 19, NULL, NULL, CAST(N'2021-07-11T13:13:30.7996512' AS DateTime2), CAST(N'2021-07-11T13:13:30.7996512' AS DateTime2), 2, 2, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (30, 11, 20, NULL, NULL, CAST(N'2021-07-11T13:14:47.4880802' AS DateTime2), CAST(N'2021-07-11T13:14:47.4880802' AS DateTime2), 2, 2, NULL, CAST(500.00 AS Decimal(20, 2)), 10, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (31, 1, 21, NULL, NULL, CAST(N'2021-07-11T13:15:40.0350075' AS DateTime2), CAST(N'2021-07-11T13:15:40.0350075' AS DateTime2), 2, 2, NULL, CAST(500.00 AS Decimal(20, 2)), 10, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (32, 1, 21, NULL, NULL, CAST(N'2021-07-11T13:15:40.0350075' AS DateTime2), CAST(N'2021-07-11T13:15:40.0350075' AS DateTime2), 2, 2, NULL, CAST(500.00 AS Decimal(20, 2)), 11, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (33, 2, 22, NULL, NULL, CAST(N'2021-07-11T16:28:41.6571550' AS DateTime2), CAST(N'2021-07-11T16:28:41.6571550' AS DateTime2), 9, 9, NULL, CAST(500.00 AS Decimal(20, 2)), 10, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (36, 1, 24, NULL, NULL, CAST(N'2021-07-11T17:10:04.8273805' AS DateTime2), CAST(N'2021-07-11T17:10:04.8273805' AS DateTime2), 9, 9, NULL, CAST(1500.00 AS Decimal(20, 2)), 12, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (37, 10, 24, NULL, NULL, CAST(N'2021-07-11T17:10:04.8284170' AS DateTime2), CAST(N'2021-07-11T17:10:04.8284170' AS DateTime2), 9, 9, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (40, 1, 26, NULL, NULL, CAST(N'2021-07-12T11:12:00.5605914' AS DateTime2), CAST(N'2021-07-12T11:12:00.5605914' AS DateTime2), 2, 2, NULL, CAST(1250.00 AS Decimal(20, 2)), 11, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (41, 1, 27, NULL, NULL, CAST(N'2021-07-12T11:15:39.1625824' AS DateTime2), CAST(N'2021-07-12T11:15:39.1625824' AS DateTime2), 2, 2, NULL, CAST(1500.00 AS Decimal(20, 2)), 12, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (42, 5, 13, NULL, NULL, CAST(N'2021-07-12T13:36:11.1473357' AS DateTime2), CAST(N'2021-07-12T13:36:11.1473357' AS DateTime2), 4, 4, NULL, CAST(100.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (43, 1, 28, NULL, NULL, CAST(N'2021-07-12T13:36:22.4495489' AS DateTime2), CAST(N'2021-07-12T13:36:22.4495489' AS DateTime2), 4, 4, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (44, 1, 29, NULL, NULL, CAST(N'2021-07-12T13:41:52.8480372' AS DateTime2), CAST(N'2021-07-12T13:41:52.8480372' AS DateTime2), 9, 9, NULL, CAST(1500.00 AS Decimal(20, 2)), 12, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (45, 10, 30, NULL, NULL, CAST(N'2021-07-12T13:55:53.8318608' AS DateTime2), CAST(N'2021-07-12T13:55:53.8318608' AS DateTime2), 9, 9, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (46, 200, 31, NULL, NULL, CAST(N'2021-07-12T13:57:24.8101764' AS DateTime2), CAST(N'2021-07-12T13:57:24.8101764' AS DateTime2), 9, 9, NULL, CAST(1000.00 AS Decimal(20, 2)), 9, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (47, 4, 32, NULL, NULL, CAST(N'2021-07-12T15:35:52.5738269' AS DateTime2), CAST(N'2021-07-12T15:35:52.5738269' AS DateTime2), 4, 4, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (48, 5, 33, NULL, NULL, CAST(N'2021-07-12T18:23:06.9626966' AS DateTime2), CAST(N'2021-07-12T18:23:06.9626966' AS DateTime2), 9, 9, NULL, CAST(0.00 AS Decimal(20, 2)), 9, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (49, 5, 34, NULL, NULL, CAST(N'2021-07-12T18:23:07.2045451' AS DateTime2), CAST(N'2021-07-12T18:23:07.2045451' AS DateTime2), 9, 9, NULL, CAST(0.00 AS Decimal(20, 2)), 9, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (50, 500, 35, NULL, NULL, CAST(N'2021-07-12T18:30:20.6872113' AS DateTime2), CAST(N'2021-07-12T18:30:20.6872113' AS DateTime2), 9, 9, NULL, CAST(1000.00 AS Decimal(20, 2)), 3, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (51, 6, 36, NULL, NULL, CAST(N'2021-07-12T18:38:00.9405605' AS DateTime2), CAST(N'2021-07-12T18:38:00.9405605' AS DateTime2), 9, 9, NULL, CAST(0.00 AS Decimal(20, 2)), 1, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (52, 6, 37, NULL, NULL, CAST(N'2021-07-12T18:38:01.1631799' AS DateTime2), CAST(N'2021-07-12T18:38:01.1631799' AS DateTime2), 9, 9, NULL, CAST(0.00 AS Decimal(20, 2)), 1, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (53, 1, 38, NULL, NULL, CAST(N'2021-07-13T13:18:36.5508484' AS DateTime2), CAST(N'2021-07-13T13:18:36.5508484' AS DateTime2), 2, 2, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (57, 10, 41, NULL, NULL, CAST(N'2021-07-14T15:20:44.1119565' AS DateTime2), CAST(N'2021-07-14T15:20:44.1119565' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (58, 10, 42, NULL, NULL, CAST(N'2021-07-14T15:20:44.3464335' AS DateTime2), CAST(N'2021-07-14T15:20:44.3464335' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (59, 3, 43, NULL, NULL, CAST(N'2021-07-14T15:21:35.0972869' AS DateTime2), CAST(N'2021-07-14T15:21:35.0972869' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (60, 3, 44, NULL, NULL, CAST(N'2021-07-14T15:21:35.3314677' AS DateTime2), CAST(N'2021-07-14T15:21:35.3314677' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (63, 3, 46, NULL, NULL, CAST(N'2021-07-14T15:26:06.7867799' AS DateTime2), CAST(N'2021-07-14T15:26:06.7867799' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (64, 3, 45, NULL, NULL, CAST(N'2021-07-14T15:26:07.0209424' AS DateTime2), CAST(N'2021-07-14T15:26:07.0209424' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (65, 5, 47, NULL, NULL, CAST(N'2021-07-14T15:26:22.9274739' AS DateTime2), CAST(N'2021-07-14T15:26:22.9274739' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 1, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (66, 5, 48, NULL, NULL, CAST(N'2021-07-14T15:26:23.1460429' AS DateTime2), CAST(N'2021-07-14T15:26:23.1460429' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 1, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (69, 1, 50, NULL, NULL, CAST(N'2021-07-15T13:03:43.3660850' AS DateTime2), CAST(N'2021-07-15T13:03:43.3660850' AS DateTime2), 2, 2, NULL, CAST(0.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (70, 1000, 51, NULL, NULL, CAST(N'2021-07-15T15:43:55.8225016' AS DateTime2), CAST(N'2021-07-15T15:43:55.8225016' AS DateTime2), 9, 9, NULL, CAST(100000.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (71, 1, 52, NULL, NULL, CAST(N'2021-07-15T16:23:45.6058012' AS DateTime2), CAST(N'2021-07-15T16:23:45.6058012' AS DateTime2), 2, 2, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (73, 5, 54, NULL, NULL, CAST(N'2021-07-15T16:32:48.3453663' AS DateTime2), CAST(N'2021-07-15T16:32:48.3453663' AS DateTime2), 2, 2, NULL, CAST(500.00 AS Decimal(20, 2)), 10, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (74, 1, 55, NULL, NULL, CAST(N'2021-07-17T19:19:29.8655012' AS DateTime2), CAST(N'2021-07-17T19:19:29.8655012' AS DateTime2), 9, 9, NULL, CAST(3000.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (75, 2, 55, NULL, NULL, CAST(N'2021-07-17T19:19:29.8712376' AS DateTime2), CAST(N'2021-07-17T19:19:29.8712376' AS DateTime2), 9, 9, NULL, CAST(5000.00 AS Decimal(20, 2)), 11, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (76, 20, 56, NULL, NULL, CAST(N'2021-07-18T12:27:07.5765355' AS DateTime2), CAST(N'2021-07-18T12:27:07.5765355' AS DateTime2), 1, 1, NULL, CAST(500.00 AS Decimal(20, 2)), 11, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (77, 1, 57, NULL, NULL, CAST(N'2021-07-18T13:00:35.3359943' AS DateTime2), CAST(N'2021-07-18T13:00:35.3359943' AS DateTime2), 2, 2, NULL, CAST(500.00 AS Decimal(20, 2)), 10, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (78, 1, 49, NULL, NULL, CAST(N'2021-07-18T15:07:34.5513407' AS DateTime2), CAST(N'2021-07-18T15:07:34.5513407' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (80, 1, 58, NULL, NULL, CAST(N'2021-07-18T15:42:36.7106820' AS DateTime2), CAST(N'2021-07-18T15:42:36.7106820' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (82, 5550, 59, NULL, NULL, CAST(N'2021-07-18T15:48:52.7771906' AS DateTime2), CAST(N'2021-07-18T15:48:52.7771906' AS DateTime2), 2, 2, NULL, CAST(0.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (84, 0, 60, NULL, NULL, CAST(N'2021-07-18T15:49:34.1599086' AS DateTime2), CAST(N'2021-07-18T15:49:34.1599086' AS DateTime2), 2, 2, NULL, CAST(10000.00 AS Decimal(20, 2)), 3, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (86, 5, 61, NULL, NULL, CAST(N'2021-07-18T15:50:26.7360676' AS DateTime2), CAST(N'2021-07-18T15:50:26.7360676' AS DateTime2), 2, 2, NULL, CAST(500.00 AS Decimal(20, 2)), 10, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (87, 5, 62, NULL, NULL, CAST(N'2021-07-18T15:52:53.9808104' AS DateTime2), CAST(N'2021-07-18T15:52:53.9808104' AS DateTime2), 2, 2, NULL, CAST(500.00 AS Decimal(20, 2)), 10, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (90, 100, 53, NULL, NULL, CAST(N'2021-07-18T16:36:22.9014463' AS DateTime2), CAST(N'2021-07-18T16:36:22.9014463' AS DateTime2), 2, 2, NULL, CAST(200.00 AS Decimal(20, 2)), 9, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (91, 1, 63, NULL, NULL, CAST(N'2021-07-18T16:39:11.0436577' AS DateTime2), CAST(N'2021-07-18T16:39:11.0436577' AS DateTime2), 1, 1, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (97, 2, 65, NULL, NULL, CAST(N'2021-07-18T16:59:13.4550081' AS DateTime2), CAST(N'2021-07-18T16:59:13.4550081' AS DateTime2), 1, 1, NULL, CAST(200.00 AS Decimal(20, 2)), 9, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (98, 5, 65, NULL, NULL, CAST(N'2021-07-18T16:59:13.4550081' AS DateTime2), CAST(N'2021-07-18T16:59:13.4550081' AS DateTime2), 1, 1, NULL, CAST(5555.00 AS Decimal(20, 2)), 1, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (99, 100, 66, NULL, NULL, CAST(N'2021-07-18T18:41:46.2390849' AS DateTime2), CAST(N'2021-07-18T18:41:46.2390849' AS DateTime2), 1, 1, NULL, CAST(50.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (100, 25, 67, NULL, NULL, CAST(N'2021-07-18T19:20:12.1789460' AS DateTime2), CAST(N'2021-07-18T19:20:12.1789460' AS DateTime2), 2, 2, NULL, CAST(782.00 AS Decimal(20, 2)), 1, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (101, 25, 67, NULL, NULL, CAST(N'2021-07-18T19:20:12.1789460' AS DateTime2), CAST(N'2021-07-18T19:20:12.1789460' AS DateTime2), 2, 2, NULL, CAST(278.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (102, 25, 67, NULL, NULL, CAST(N'2021-07-18T19:20:12.1789460' AS DateTime2), CAST(N'2021-07-18T19:20:12.1789460' AS DateTime2), 2, 2, NULL, CAST(387.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (103, 25, 67, NULL, NULL, CAST(N'2021-07-18T19:20:12.1789460' AS DateTime2), CAST(N'2021-07-18T19:20:12.1789460' AS DateTime2), 2, 2, NULL, CAST(397.00 AS Decimal(20, 2)), 9, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (104, 25, 67, NULL, NULL, CAST(N'2021-07-18T19:20:12.1789460' AS DateTime2), CAST(N'2021-07-18T19:20:12.1789460' AS DateTime2), 2, 2, NULL, CAST(257.00 AS Decimal(20, 2)), 11, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (105, 25, 67, NULL, NULL, CAST(N'2021-07-18T19:20:12.1789460' AS DateTime2), CAST(N'2021-07-18T19:20:12.1789460' AS DateTime2), 2, 2, NULL, CAST(45687.00 AS Decimal(20, 2)), 17, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (106, 1, 68, NULL, NULL, CAST(N'2021-07-18T19:21:38.7586549' AS DateTime2), CAST(N'2021-07-18T19:21:38.7586549' AS DateTime2), 2, 2, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (107, 1, 69, NULL, NULL, CAST(N'2021-07-18T19:23:59.0573641' AS DateTime2), CAST(N'2021-07-18T19:23:59.0573641' AS DateTime2), 2, 2, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (108, 1, 69, NULL, NULL, CAST(N'2021-07-18T19:23:59.0573641' AS DateTime2), CAST(N'2021-07-18T19:23:59.0573641' AS DateTime2), 2, 2, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (109, 50, 70, NULL, NULL, CAST(N'2021-07-18T19:28:41.4827439' AS DateTime2), CAST(N'2021-07-18T19:28:41.4827439' AS DateTime2), 2, 2, NULL, CAST(50.00 AS Decimal(20, 2)), 3, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (110, 50, 70, NULL, NULL, CAST(N'2021-07-18T19:28:41.4827439' AS DateTime2), CAST(N'2021-07-18T19:28:41.4827439' AS DateTime2), 2, 2, NULL, CAST(50.00 AS Decimal(20, 2)), 17, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (111, 1, 71, NULL, NULL, CAST(N'2021-07-18T19:36:21.7859511' AS DateTime2), CAST(N'2021-07-18T19:36:21.7859511' AS DateTime2), 2, 2, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (112, 0, 71, NULL, NULL, CAST(N'2021-07-18T19:36:21.7859511' AS DateTime2), CAST(N'2021-07-18T19:36:21.7859511' AS DateTime2), 2, 2, NULL, CAST(1000000.00 AS Decimal(20, 2)), 1, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (113, 1, 72, NULL, NULL, CAST(N'2021-07-18T19:36:39.8175803' AS DateTime2), CAST(N'2021-07-18T19:36:39.8175803' AS DateTime2), 2, 2, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (114, 50, 73, NULL, NULL, CAST(N'2021-07-18T19:38:40.3666997' AS DateTime2), CAST(N'2021-07-18T19:38:40.3666997' AS DateTime2), 2, 2, NULL, CAST(15616.00 AS Decimal(20, 2)), 3, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (115, 50, 73, NULL, NULL, CAST(N'2021-07-18T19:38:40.3666997' AS DateTime2), CAST(N'2021-07-18T19:38:40.3666997' AS DateTime2), 2, 2, NULL, CAST(51651.00 AS Decimal(20, 2)), 8, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (116, 50, 73, NULL, NULL, CAST(N'2021-07-18T19:38:40.3666997' AS DateTime2), CAST(N'2021-07-18T19:38:40.3666997' AS DateTime2), 2, 2, NULL, CAST(516.00 AS Decimal(20, 2)), 12, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (117, 50, 73, NULL, NULL, CAST(N'2021-07-18T19:38:40.3666997' AS DateTime2), CAST(N'2021-07-18T19:38:40.3666997' AS DateTime2), 2, 2, NULL, CAST(1651.00 AS Decimal(20, 2)), 10, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (118, 1, 74, NULL, NULL, CAST(N'2021-07-18T20:00:53.7909458' AS DateTime2), CAST(N'2021-07-18T20:00:53.7909458' AS DateTime2), 2, 2, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (119, 100, 75, NULL, NULL, CAST(N'2021-07-18T20:04:26.6374244' AS DateTime2), CAST(N'2021-07-18T20:04:26.6374244' AS DateTime2), 2, 2, NULL, CAST(250000.00 AS Decimal(20, 2)), 18, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (120, 1, 76, NULL, NULL, CAST(N'2021-07-18T20:04:57.7939190' AS DateTime2), CAST(N'2021-07-18T20:04:57.7939190' AS DateTime2), 2, 2, NULL, CAST(500000.00 AS Decimal(20, 2)), 18, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (121, 1, 77, NULL, NULL, CAST(N'2021-07-18T20:09:54.9233273' AS DateTime2), CAST(N'2021-07-18T20:09:54.9233273' AS DateTime2), 2, 2, NULL, CAST(500000.00 AS Decimal(20, 2)), 18, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (122, 60, 78, NULL, NULL, CAST(N'2021-07-19T10:33:43.5847453' AS DateTime2), CAST(N'2021-07-19T10:33:43.5847453' AS DateTime2), 1, 1, NULL, CAST(100000.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (123, 10, 64, NULL, NULL, CAST(N'2021-07-21T00:55:49.8807189' AS DateTime2), CAST(N'2021-07-21T00:55:49.8807189' AS DateTime2), 1, 1, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (126, 200, 79, NULL, NULL, CAST(N'2021-07-23T23:07:19.2370392' AS DateTime2), CAST(N'2021-07-23T23:07:19.2370392' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (127, 200, 80, NULL, NULL, CAST(N'2021-07-23T23:07:19.4400069' AS DateTime2), CAST(N'2021-07-23T23:07:19.4400069' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (128, 1, 81, NULL, NULL, CAST(N'2021-07-24T10:34:06.2393268' AS DateTime2), CAST(N'2021-07-24T10:34:06.2393268' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (129, 1, 82, NULL, NULL, CAST(N'2021-07-24T10:34:48.6304333' AS DateTime2), CAST(N'2021-07-24T10:34:48.6304333' AS DateTime2), 1, 1, NULL, CAST(0.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (130, 1, 83, NULL, NULL, CAST(N'2021-07-25T12:09:00.2661625' AS DateTime2), CAST(N'2021-07-25T12:09:00.2661625' AS DateTime2), 2, 2, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (134, 2, 84, NULL, NULL, CAST(N'2021-07-25T12:34:28.2232880' AS DateTime2), CAST(N'2021-07-25T12:34:28.2232880' AS DateTime2), 2, 2, NULL, CAST(5.00 AS Decimal(20, 2)), 9, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (135, 56, 84, NULL, NULL, CAST(N'2021-07-25T12:34:28.2232880' AS DateTime2), CAST(N'2021-07-25T12:34:28.2232880' AS DateTime2), 2, 2, NULL, CAST(5.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (136, 2, 84, NULL, NULL, CAST(N'2021-07-25T12:34:28.2232880' AS DateTime2), CAST(N'2021-07-25T12:34:28.2232880' AS DateTime2), 2, 2, NULL, CAST(5.00 AS Decimal(20, 2)), 9, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (137, 12, 85, NULL, NULL, CAST(N'2021-07-27T16:30:11.6279434' AS DateTime2), CAST(N'2021-07-27T16:30:11.6279434' AS DateTime2), 2, 2, NULL, CAST(0.00 AS Decimal(20, 2)), 11, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (138, 12, 85, NULL, NULL, CAST(N'2021-07-27T16:30:11.6279434' AS DateTime2), CAST(N'2021-07-27T16:30:11.6279434' AS DateTime2), 2, 2, NULL, CAST(0.00 AS Decimal(20, 2)), 9, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (139, 12, 86, NULL, NULL, CAST(N'2021-07-27T16:30:11.8778069' AS DateTime2), CAST(N'2021-07-27T16:30:11.8778069' AS DateTime2), 2, 2, NULL, CAST(0.00 AS Decimal(20, 2)), 11, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (140, 12, 86, NULL, NULL, CAST(N'2021-07-27T16:30:11.8778069' AS DateTime2), CAST(N'2021-07-27T16:30:11.8778069' AS DateTime2), 2, 2, NULL, CAST(0.00 AS Decimal(20, 2)), 9, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (141, 1, 87, NULL, NULL, CAST(N'2021-07-27T16:32:33.1579241' AS DateTime2), CAST(N'2021-07-27T16:32:33.1579241' AS DateTime2), 2, 2, NULL, CAST(0.00 AS Decimal(20, 2)), 11, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (142, 1, 88, NULL, NULL, CAST(N'2021-07-27T16:32:33.3768476' AS DateTime2), CAST(N'2021-07-27T16:32:33.3768476' AS DateTime2), 2, 2, NULL, CAST(0.00 AS Decimal(20, 2)), 11, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (143, 60, 89, NULL, NULL, CAST(N'2021-07-28T15:59:34.3432088' AS DateTime2), CAST(N'2021-07-28T15:59:34.3432088' AS DateTime2), 9, 9, NULL, CAST(10000.00 AS Decimal(20, 2)), 1, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (144, 50, 89, NULL, NULL, CAST(N'2021-07-28T15:59:34.3480659' AS DateTime2), CAST(N'2021-07-28T15:59:34.3480659' AS DateTime2), 9, 9, NULL, CAST(10000.00 AS Decimal(20, 2)), 17, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (145, 90, 89, NULL, NULL, CAST(N'2021-07-28T15:59:34.3480659' AS DateTime2), CAST(N'2021-07-28T15:59:34.3480659' AS DateTime2), 9, 9, NULL, CAST(10000.00 AS Decimal(20, 2)), 18, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (146, 15, 90, NULL, NULL, CAST(N'2021-07-28T16:01:54.9753112' AS DateTime2), CAST(N'2021-07-28T16:01:54.9753112' AS DateTime2), 2, 2, NULL, CAST(8864.00 AS Decimal(20, 2)), 1, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (147, 66, 90, NULL, NULL, CAST(N'2021-07-28T16:01:54.9753112' AS DateTime2), CAST(N'2021-07-28T16:01:54.9753112' AS DateTime2), 2, 2, NULL, CAST(5884.00 AS Decimal(20, 2)), 7, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (148, 148, 90, NULL, NULL, CAST(N'2021-07-28T16:01:54.9753112' AS DateTime2), CAST(N'2021-07-28T16:01:54.9753112' AS DateTime2), 2, 2, NULL, CAST(2225.00 AS Decimal(20, 2)), 17, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (149, 142, 91, NULL, NULL, CAST(N'2021-07-28T16:02:42.7286911' AS DateTime2), CAST(N'2021-07-28T16:02:42.7286911' AS DateTime2), 2, 2, NULL, CAST(7277.00 AS Decimal(20, 2)), 18, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (150, 42, 91, NULL, NULL, CAST(N'2021-07-28T16:02:42.7286911' AS DateTime2), CAST(N'2021-07-28T16:02:42.7286911' AS DateTime2), 2, 2, NULL, CAST(5454.00 AS Decimal(20, 2)), 9, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (151, 25, 91, NULL, NULL, CAST(N'2021-07-28T16:02:42.7286911' AS DateTime2), CAST(N'2021-07-28T16:02:42.7286911' AS DateTime2), 2, 2, NULL, CAST(25233.00 AS Decimal(20, 2)), 1, NULL)
GO
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (152, 2, 92, NULL, NULL, CAST(N'2021-07-28T17:15:36.8912182' AS DateTime2), CAST(N'2021-07-28T17:15:36.8912182' AS DateTime2), 2, 2, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (153, 1, 92, NULL, NULL, CAST(N'2021-07-28T17:15:36.8961323' AS DateTime2), CAST(N'2021-07-28T17:15:36.8961323' AS DateTime2), 2, 2, NULL, CAST(1500.00 AS Decimal(20, 2)), 12, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (154, 1, 93, NULL, NULL, CAST(N'2021-07-28T17:16:33.1619060' AS DateTime2), CAST(N'2021-07-28T17:16:33.1619060' AS DateTime2), 1, 1, NULL, CAST(10000.00 AS Decimal(20, 2)), 3, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (155, 1, 94, NULL, NULL, CAST(N'2021-07-28T17:23:37.1681276' AS DateTime2), CAST(N'2021-07-28T17:23:37.1681276' AS DateTime2), 2, 2, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (158, 6, 95, NULL, NULL, CAST(N'2021-07-28T17:24:06.5122944' AS DateTime2), CAST(N'2021-07-28T17:24:06.5122944' AS DateTime2), 2, 2, NULL, CAST(10000.00 AS Decimal(20, 2)), 3, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (159, 6, 95, NULL, NULL, CAST(N'2021-07-28T17:24:06.5122944' AS DateTime2), CAST(N'2021-07-28T17:24:06.5122944' AS DateTime2), 2, 2, NULL, CAST(500000.00 AS Decimal(20, 2)), 18, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (160, 222, 97, NULL, NULL, CAST(N'2021-07-28T17:33:28.3488533' AS DateTime2), CAST(N'2021-07-28T17:33:28.3488533' AS DateTime2), 1, 1, NULL, CAST(333.00 AS Decimal(20, 2)), 1, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (161, 10, 98, NULL, NULL, CAST(N'2021-07-28T17:34:35.8653731' AS DateTime2), CAST(N'2021-07-28T17:34:35.8653731' AS DateTime2), 1, 1, NULL, CAST(15000.00 AS Decimal(20, 2)), 18, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (162, 1, 100, NULL, NULL, CAST(N'2021-07-28T17:37:12.1329818' AS DateTime2), CAST(N'2021-07-28T17:37:12.1329818' AS DateTime2), 2, 2, NULL, CAST(1200000.00 AS Decimal(20, 2)), 6, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (163, 1, 101, NULL, NULL, CAST(N'2021-07-28T17:37:19.4456975' AS DateTime2), CAST(N'2021-07-28T17:37:19.4456975' AS DateTime2), 2, 2, NULL, CAST(500000.00 AS Decimal(20, 2)), 18, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (164, 1, 102, NULL, NULL, CAST(N'2021-07-28T17:37:26.9146705' AS DateTime2), CAST(N'2021-07-28T17:37:26.9146705' AS DateTime2), 2, 2, NULL, CAST(500.00 AS Decimal(20, 2)), 10, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (165, 1, 106, NULL, NULL, CAST(N'2021-07-28T17:47:06.4837200' AS DateTime2), CAST(N'2021-07-28T17:47:06.4837200' AS DateTime2), 2, 2, NULL, CAST(1500.00 AS Decimal(20, 2)), 12, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (166, 3, 110, NULL, NULL, CAST(N'2021-07-28T17:52:00.8465463' AS DateTime2), CAST(N'2021-07-28T17:52:00.8465463' AS DateTime2), 9, 9, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (167, 2, 110, NULL, NULL, CAST(N'2021-07-28T17:52:00.8465463' AS DateTime2), CAST(N'2021-07-28T17:52:00.8465463' AS DateTime2), 9, 9, NULL, CAST(10000.00 AS Decimal(20, 2)), 3, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (168, 1, 111, NULL, NULL, CAST(N'2021-07-28T17:53:03.1909833' AS DateTime2), CAST(N'2021-07-28T17:53:03.1909833' AS DateTime2), 9, 9, NULL, CAST(1500.00 AS Decimal(20, 2)), 12, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (169, 1, 112, NULL, NULL, CAST(N'2021-07-28T17:53:43.2542415' AS DateTime2), CAST(N'2021-07-28T17:53:43.2542415' AS DateTime2), 9, 9, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (170, 1, 112, NULL, NULL, CAST(N'2021-07-28T17:53:43.2542415' AS DateTime2), CAST(N'2021-07-28T17:53:43.2542415' AS DateTime2), 9, 9, NULL, CAST(500.00 AS Decimal(20, 2)), 10, N'')
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (171, 1, 117, NULL, NULL, CAST(N'2021-07-28T17:58:10.7885726' AS DateTime2), CAST(N'2021-07-28T17:58:10.7885726' AS DateTime2), 2, 2, NULL, CAST(1500.00 AS Decimal(20, 2)), 12, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (172, 1, 118, NULL, NULL, CAST(N'2021-07-28T17:59:09.1016507' AS DateTime2), CAST(N'2021-07-28T17:59:09.1016507' AS DateTime2), 2, 2, NULL, CAST(1000.00 AS Decimal(20, 2)), 8, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (173, 1, 118, NULL, NULL, CAST(N'2021-07-28T17:59:09.1173855' AS DateTime2), CAST(N'2021-07-28T17:59:09.1173855' AS DateTime2), 2, 2, NULL, CAST(500000.00 AS Decimal(20, 2)), 18, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial]) VALUES (175, 1, 120, NULL, NULL, CAST(N'2021-07-28T18:04:59.0434638' AS DateTime2), CAST(N'2021-07-28T18:04:59.0434638' AS DateTime2), 9, 9, NULL, CAST(100.00 AS Decimal(20, 2)), 9, NULL)
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
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (19, 29, 11, NULL, NULL, NULL, CAST(15000.00 AS Decimal(20, 2)), N'078683786301', CAST(N'2021-07-26T10:36:30.0982340' AS DateTime2), CAST(N'2021-07-26T11:38:11.1662176' AS DateTime2), 3, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (20, 30, 11, NULL, NULL, NULL, CAST(50000.00 AS Decimal(20, 2)), N'078773818901', CAST(N'2021-07-26T10:37:44.0971823' AS DateTime2), CAST(N'2021-07-26T10:37:44.0971823' AS DateTime2), 3, 3, NULL, NULL, NULL)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId]) VALUES (21, 31, 11, NULL, NULL, NULL, CAST(120000.00 AS Decimal(20, 2)), N'078773843600', CAST(N'2021-07-26T10:42:00.9296014' AS DateTime2), CAST(N'2021-07-26T10:42:00.9296014' AS DateTime2), 3, 3, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[itemsUnits] OFF
GO
SET IDENTITY_INSERT [dbo].[itemTransferOffer] ON 

INSERT [dbo].[itemTransferOffer] ([id], [itemTransId], [offerId], [discountType], [discountValue], [notes], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (1, 36, 2, N'2', CAST(5.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-11T12:30:14.3816383' AS DateTime2), CAST(N'2021-07-11T12:30:14.3816383' AS DateTime2), 9, 9)
INSERT [dbo].[itemTransferOffer] ([id], [itemTransId], [offerId], [discountType], [discountValue], [notes], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (2, 37, 2, N'2', CAST(5.00 AS Decimal(20, 2)), NULL, CAST(N'2021-07-11T12:30:14.3816383' AS DateTime2), CAST(N'2021-07-11T12:30:14.3816383' AS DateTime2), 9, 9)
SET IDENTITY_INSERT [dbo].[itemTransferOffer] OFF
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
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (2, N'Al-JM-B-POS-2', N'POS-2', CAST(1143718386.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:52:00.6122040' AS DateTime2), CAST(N'2021-07-28T17:59:09.5548561' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
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
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (12, N'0', 1, 1, NULL, 11)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (13, N'2000', 1, 1, NULL, 12)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (14, N'ad4bfd50185ef68bce2b903aa7e10ec0.png', 1, 1, N'', 7)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (15, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[setValues] OFF
GO
SET IDENTITY_INSERT [dbo].[shippingCompanies] ON 

INSERT [dbo].[shippingCompanies] ([shippingCompanyId], [name], [RealDeliveryCost], [deliveryCost], [deliveryType], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (0, N'name      ', CAST(12000.00 AS Decimal(20, 2)), CAST(15000.00 AS Decimal(20, 2)), N'local', N'notes', CAST(N'2021-07-05T05:04:36.1578615' AS DateTime2), CAST(N'2021-07-05T05:04:36.1578615' AS DateTime2), 3, 3, 1)
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

INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (1, N'admin', N'1b8baf4f819e5b304e1a176e1c590c84', N'Mohammad', N'Nasani', N'System Admin', N'12', CAST(N'2021-06-28T18:38:45.0434248' AS DateTime2), CAST(N'2021-07-28T17:54:21.2858857' AS DateTime2), 2, 2, N'+963-21-2278910', N'+963-966376308', N'mohamadnasani@gmail.com', N'Halab', 1, N'', 1, N'', N'57440ff6b80f068efd50410ea24fd593.png', 17, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (2, N'yasin', N'e509d17a7834e211ca548cef13b4a933', N'ياسين', N'ادلبي', N'محاسب', N'8', CAST(N'2021-06-30T11:05:51.9137655' AS DateTime2), CAST(N'2021-07-28T17:59:14.9456529' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 0, N'', N'c37858823db0093766eee74d8ee1f1e5.png', 17, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (3, N'yasmine', N'4cdf921bfe31b594a0cc9cc555292f02', N'ياسمين', N'النجار', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:17:13.6368587' AS DateTime2), CAST(N'2021-07-28T14:52:43.3303306' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'71f020248a405d21e94d1de52043bed4.jpg', 17, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (4, N'bonni', N'494e167fd30bf2a244c8fcda0220aa89', N'محمد', N'بني', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:17:38.6309662' AS DateTime2), CAST(N'2021-07-28T16:43:07.5924469' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'd2ec5f1ed83abfca0dfec76506b696b3.png', 17, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (5, N'olwani', N'7ae94a254e28a0e9a575e9669fed5684', N'محمد', N'علواني', N'مدير مشتريات', N'8', CAST(N'2021-06-30T11:23:59.5926231' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'f96f8a89e2143f1e43a2ba7953fb5413.png', 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (6, N'amna', N'78fe84643f9a617ac5800771a1c3c5e9', N'آمنة', N'سعدات', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:24:56.0475272' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'56a2e0231c3d394ace201adf37d13f63.png', 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (7, N'basmah', N'210db3affbee2bdeb82872a7f42a970f', N'باسمة', N'قدري', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:25:40.3004312' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'3204215c19f25609034d24451f7e03d7.png', 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (8, N'bik', N'e2a603fb361ecb7b2fc6791f98382580', N'محمد', N'بيك', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:26:56.9568520' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'6a5d62c1233b5e9b2000dd13aadf81f4.png', 11, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (9, N'naji', N'741e82719da67d8744fd797194aa65b0', N'ناجي', N'مصري', N'مدير', N'8', CAST(N'2021-06-30T11:40:59.4646248' AS DateTime2), CAST(N'2021-07-28T18:14:06.7259796' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'6eaba1dc3c031faf262149c058fea728.png', 17, CAST(0.00 AS Decimal(20, 2)), 0)
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
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (25, N'admin2', N'340b7543dcfa9407abd62b33887a9251', N'Mohammad', N'Nasani', N'System Admin', N'12', CAST(N'2021-07-18T10:33:41.2293103' AS DateTime2), CAST(N'2021-07-18T18:59:54.8799604' AS DateTime2), 2, 2, N'+963-21-2278910', N'+963-966376308', N'mohamadnasani@gmail.com', N'Halab', 1, N'', 1, N'', N'16008f81a32dddded32b87f4a2cd9ca7.png', 14, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (26, N'admin3', N'05c9ef186781449687aed7a0710118a6', N'Mohammad', N'Nasani', N'System Admin', N'12', CAST(N'2021-07-18T10:33:53.3385310' AS DateTime2), CAST(N'2021-07-18T19:00:30.1935296' AS DateTime2), 2, 2, N'+963-21-2278910', N'+963-966376308', N'mohamadnasani@gmail.com', N'Halab', 1, N'', 1, N'', N'16008f81a32dddded32b87f4a2cd9ca7.png', 15, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (27, N'admin4', N'1ac18407b4727f4f6a3cd8ede3b8ed3a', N'Mohammad', N'Nasani', N'System Admin', N'12', CAST(N'2021-07-18T10:35:08.0113579' AS DateTime2), CAST(N'2021-07-19T01:54:20.1886333' AS DateTime2), 2, 2, N'+968--2278910', N'+968-966376308', N'mohamadnasani@gmail.com', N'Halab', 1, N'', 1, N'', N'16008f81a32dddded32b87f4a2cd9ca7.png', 16, CAST(0.00 AS Decimal(20, 2)), 0)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
SET IDENTITY_INSERT [dbo].[userSetValues] ON 

INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (6, 3, 2, NULL, CAST(N'2021-07-10T13:43:33.1472761' AS DateTime2), CAST(N'2021-07-14T12:45:13.2937637' AS DateTime2), 3, 3)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (7, 9, 1, N'thisis', CAST(N'2021-07-10T14:23:23.5064125' AS DateTime2), CAST(N'2021-07-10T14:23:23.5064125' AS DateTime2), 9, 9)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (8, 4, 1, NULL, CAST(N'2021-07-12T10:29:19.2071006' AS DateTime2), CAST(N'2021-07-12T10:29:19.2071006' AS DateTime2), 4, 4)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (9, 2, 2, NULL, CAST(N'2021-07-12T17:06:47.4146813' AS DateTime2), CAST(N'2021-07-12T17:09:45.4157961' AS DateTime2), 2, 2)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (10, 1, 2, NULL, CAST(N'2021-07-24T10:58:03.7729709' AS DateTime2), CAST(N'2021-07-24T10:58:03.7729709' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[userSetValues] OFF
GO
SET IDENTITY_INSERT [dbo].[usersLogs] ON 

INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2584, CAST(N'2021-07-28T16:26:56.9715504' AS DateTime2), CAST(N'2021-07-28T16:34:17.3701945' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2590, CAST(N'2021-07-28T16:49:59.4835176' AS DateTime2), CAST(N'2021-07-28T16:50:36.3146349' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2591, CAST(N'2021-07-28T16:52:41.1418618' AS DateTime2), NULL, 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2592, CAST(N'2021-07-28T16:59:42.5935772' AS DateTime2), NULL, 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2593, CAST(N'2021-07-28T17:01:29.2288743' AS DateTime2), NULL, 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2594, CAST(N'2021-07-28T17:10:52.7025250' AS DateTime2), NULL, 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2595, CAST(N'2021-07-28T17:11:42.3453514' AS DateTime2), NULL, 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2596, CAST(N'2021-07-28T17:11:50.4495483' AS DateTime2), NULL, 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2597, CAST(N'2021-07-28T17:15:14.7847460' AS DateTime2), CAST(N'2021-07-28T17:15:42.7728186' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2598, CAST(N'2021-07-28T17:18:17.2017828' AS DateTime2), CAST(N'2021-07-28T17:18:47.3330804' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2599, CAST(N'2021-07-28T17:22:59.1990424' AS DateTime2), CAST(N'2021-07-28T17:28:41.3122697' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2600, CAST(N'2021-07-28T17:31:19.6905204' AS DateTime2), NULL, 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2601, CAST(N'2021-07-28T17:32:50.3482713' AS DateTime2), NULL, 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2602, CAST(N'2021-07-28T17:37:00.1330458' AS DateTime2), CAST(N'2021-07-28T17:57:00.9438434' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2603, CAST(N'2021-07-28T17:44:15.1224186' AS DateTime2), NULL, 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2604, CAST(N'2021-07-28T17:45:39.0139071' AS DateTime2), NULL, 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2605, CAST(N'2021-07-28T17:46:26.8115362' AS DateTime2), NULL, 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2606, CAST(N'2021-07-28T17:47:29.3121246' AS DateTime2), NULL, 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2607, CAST(N'2021-07-28T17:48:34.5005772' AS DateTime2), NULL, 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2608, CAST(N'2021-07-28T17:50:44.9238764' AS DateTime2), CAST(N'2021-07-28T17:53:51.1759398' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2609, CAST(N'2021-07-28T17:51:27.3929623' AS DateTime2), NULL, 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2610, CAST(N'2021-07-28T17:54:01.5045229' AS DateTime2), NULL, 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2611, CAST(N'2021-07-28T17:54:21.5200531' AS DateTime2), NULL, 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2612, CAST(N'2021-07-28T17:56:57.4908522' AS DateTime2), NULL, 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2613, CAST(N'2021-07-28T17:57:33.6315884' AS DateTime2), NULL, 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2614, CAST(N'2021-07-28T17:58:00.1163709' AS DateTime2), CAST(N'2021-07-28T17:59:14.7266638' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2615, CAST(N'2021-07-28T17:59:57.7428075' AS DateTime2), NULL, 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2616, CAST(N'2021-07-28T18:03:45.3863391' AS DateTime2), NULL, 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2617, CAST(N'2021-07-28T18:07:11.2956383' AS DateTime2), CAST(N'2021-07-28T18:08:53.6095343' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2618, CAST(N'2021-07-28T18:12:23.3308054' AS DateTime2), CAST(N'2021-07-28T18:13:33.8315916' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2619, CAST(N'2021-07-28T18:14:06.9414148' AS DateTime2), NULL, 2, 9)
SET IDENTITY_INSERT [dbo].[usersLogs] OFF
GO
ALTER TABLE [dbo].[countriesCodes] ADD  CONSTRAINT [DF_countriesCodes_isDefault]  DEFAULT ((0)) FOR [isDefault]
GO
ALTER TABLE [dbo].[packages] ADD  CONSTRAINT [DF_packages_quantity]  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[packages] ADD  CONSTRAINT [DF_packages_isActive]  DEFAULT ((1)) FOR [isActive]
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
