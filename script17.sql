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
ALTER TABLE [dbo].[notificationUser] DROP CONSTRAINT [FK_notificationUser_users2]
GO
ALTER TABLE [dbo].[notificationUser] DROP CONSTRAINT [FK_notificationUser_users1]
GO
ALTER TABLE [dbo].[notificationUser] DROP CONSTRAINT [FK_notificationUser_users]
GO
ALTER TABLE [dbo].[notificationUser] DROP CONSTRAINT [FK_notificationUser_notification]
GO
ALTER TABLE [dbo].[notification] DROP CONSTRAINT [FK_notification_users1]
GO
ALTER TABLE [dbo].[notification] DROP CONSTRAINT [FK_notification_users]
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
ALTER TABLE [dbo].[itemsTransfer] DROP CONSTRAINT [FK_itemsTransfer_inventoryItemLocation]
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
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [FK_invoices_users5]
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
ALTER TABLE [dbo].[cashTransfer] DROP CONSTRAINT [FK_cashTransfer_shippingCompanies]
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
ALTER TABLE [dbo].[notificationUser] DROP CONSTRAINT [DF_notificationUser_isRead]
GO
ALTER TABLE [dbo].[inventoryItemLocation] DROP CONSTRAINT [DF_inventoryItemLocation_isFalls]
GO
ALTER TABLE [dbo].[countriesCodes] DROP CONSTRAINT [DF_countriesCodes_isDefault]
GO
/****** Object:  Table [dbo].[usersLogs]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usersLogs]') AND type in (N'U'))
DROP TABLE [dbo].[usersLogs]
GO
/****** Object:  Table [dbo].[userSetValues]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[userSetValues]') AND type in (N'U'))
DROP TABLE [dbo].[userSetValues]
GO
/****** Object:  Table [dbo].[users]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type in (N'U'))
DROP TABLE [dbo].[users]
GO
/****** Object:  Table [dbo].[units]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[units]') AND type in (N'U'))
DROP TABLE [dbo].[units]
GO
/****** Object:  Table [dbo].[sysEmails]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sysEmails]') AND type in (N'U'))
DROP TABLE [dbo].[sysEmails]
GO
/****** Object:  Table [dbo].[subscriptionFees]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subscriptionFees]') AND type in (N'U'))
DROP TABLE [dbo].[subscriptionFees]
GO
/****** Object:  Table [dbo].[storageCost]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[storageCost]') AND type in (N'U'))
DROP TABLE [dbo].[storageCost]
GO
/****** Object:  Table [dbo].[shippingCompanies]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[shippingCompanies]') AND type in (N'U'))
DROP TABLE [dbo].[shippingCompanies]
GO
/****** Object:  Table [dbo].[setValues]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setValues]') AND type in (N'U'))
DROP TABLE [dbo].[setValues]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setting]') AND type in (N'U'))
DROP TABLE [dbo].[setting]
GO
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[servicesCosts]') AND type in (N'U'))
DROP TABLE [dbo].[servicesCosts]
GO
/****** Object:  Table [dbo].[serials]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[serials]') AND type in (N'U'))
DROP TABLE [dbo].[serials]
GO
/****** Object:  Table [dbo].[sections]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sections]') AND type in (N'U'))
DROP TABLE [dbo].[sections]
GO
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[propertiesItems]') AND type in (N'U'))
DROP TABLE [dbo].[propertiesItems]
GO
/****** Object:  Table [dbo].[properties]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[properties]') AND type in (N'U'))
DROP TABLE [dbo].[properties]
GO
/****** Object:  Table [dbo].[posUsers]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[posUsers]') AND type in (N'U'))
DROP TABLE [dbo].[posUsers]
GO
/****** Object:  Table [dbo].[pos]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pos]') AND type in (N'U'))
DROP TABLE [dbo].[pos]
GO
/****** Object:  Table [dbo].[Points]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Points]') AND type in (N'U'))
DROP TABLE [dbo].[Points]
GO
/****** Object:  Table [dbo].[packages]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[packages]') AND type in (N'U'))
DROP TABLE [dbo].[packages]
GO
/****** Object:  Table [dbo].[offers]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[offers]') AND type in (N'U'))
DROP TABLE [dbo].[offers]
GO
/****** Object:  Table [dbo].[objects]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[objects]') AND type in (N'U'))
DROP TABLE [dbo].[objects]
GO
/****** Object:  Table [dbo].[notificationUser]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[notificationUser]') AND type in (N'U'))
DROP TABLE [dbo].[notificationUser]
GO
/****** Object:  Table [dbo].[notification]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[notification]') AND type in (N'U'))
DROP TABLE [dbo].[notification]
GO
/****** Object:  Table [dbo].[memberships]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[memberships]') AND type in (N'U'))
DROP TABLE [dbo].[memberships]
GO
/****** Object:  Table [dbo].[medals]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medals]') AND type in (N'U'))
DROP TABLE [dbo].[medals]
GO
/****** Object:  Table [dbo].[medalAgent]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medalAgent]') AND type in (N'U'))
DROP TABLE [dbo].[medalAgent]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[locations]') AND type in (N'U'))
DROP TABLE [dbo].[locations]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemTransferOffer]') AND type in (N'U'))
DROP TABLE [dbo].[itemTransferOffer]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsUnits]') AND type in (N'U'))
DROP TABLE [dbo].[itemsUnits]
GO
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[itemsTransfer]
GO
/****** Object:  Table [dbo].[itemsProp]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsProp]') AND type in (N'U'))
DROP TABLE [dbo].[itemsProp]
GO
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsOffers]') AND type in (N'U'))
DROP TABLE [dbo].[itemsOffers]
GO
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsMaterials]') AND type in (N'U'))
DROP TABLE [dbo].[itemsMaterials]
GO
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsLocations]') AND type in (N'U'))
DROP TABLE [dbo].[itemsLocations]
GO
/****** Object:  Table [dbo].[items]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[items]') AND type in (N'U'))
DROP TABLE [dbo].[items]
GO
/****** Object:  Table [dbo].[invoiceStatus]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoiceStatus]') AND type in (N'U'))
DROP TABLE [dbo].[invoiceStatus]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoices]') AND type in (N'U'))
DROP TABLE [dbo].[invoices]
GO
/****** Object:  Table [dbo].[inventoryItemLocation]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[inventoryItemLocation]') AND type in (N'U'))
DROP TABLE [dbo].[inventoryItemLocation]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory]') AND type in (N'U'))
DROP TABLE [dbo].[Inventory]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groups]') AND type in (N'U'))
DROP TABLE [dbo].[groups]
GO
/****** Object:  Table [dbo].[groupObject]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupObject]') AND type in (N'U'))
DROP TABLE [dbo].[groupObject]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expenses]') AND type in (N'U'))
DROP TABLE [dbo].[Expenses]
GO
/****** Object:  Table [dbo].[docImages]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[docImages]') AND type in (N'U'))
DROP TABLE [dbo].[docImages]
GO
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[couponsInvoices]') AND type in (N'U'))
DROP TABLE [dbo].[couponsInvoices]
GO
/****** Object:  Table [dbo].[coupons]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[coupons]') AND type in (N'U'))
DROP TABLE [dbo].[coupons]
GO
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[countriesCodes]') AND type in (N'U'))
DROP TABLE [dbo].[countriesCodes]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cities]') AND type in (N'U'))
DROP TABLE [dbo].[cities]
GO
/****** Object:  Table [dbo].[categoryuser]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categoryuser]') AND type in (N'U'))
DROP TABLE [dbo].[categoryuser]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categories]') AND type in (N'U'))
DROP TABLE [dbo].[categories]
GO
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cashTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[cashTransfer]
GO
/****** Object:  Table [dbo].[cards]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cards]') AND type in (N'U'))
DROP TABLE [dbo].[cards]
GO
/****** Object:  Table [dbo].[branchStore]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchStore]') AND type in (N'U'))
DROP TABLE [dbo].[branchStore]
GO
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchesUsers]') AND type in (N'U'))
DROP TABLE [dbo].[branchesUsers]
GO
/****** Object:  Table [dbo].[branches]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branches]') AND type in (N'U'))
DROP TABLE [dbo].[branches]
GO
/****** Object:  Table [dbo].[bondes]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bondes]') AND type in (N'U'))
DROP TABLE [dbo].[bondes]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[banks]') AND type in (N'U'))
DROP TABLE [dbo].[banks]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agents]') AND type in (N'U'))
DROP TABLE [dbo].[agents]
GO
/****** Object:  Table [dbo].[agentMemberships]    Script Date: 17/08/2021 07:37:42 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agentMemberships]') AND type in (N'U'))
DROP TABLE [dbo].[agentMemberships]
GO
/****** Object:  Table [dbo].[agentMemberships]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[agents]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[banks]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[bondes]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[branches]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[branchStore]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[cards]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 17/08/2021 07:37:42 م ******/
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
	[shippingCompanyId] [int] NULL,
 CONSTRAINT [PK_cashTransfer] PRIMARY KEY CLUSTERED 
(
	[cashTransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[categoryuser]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[cities]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[coupons]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[docImages]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[Expenses]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[groupObject]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[groups]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[Inventory]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[inventoryItemLocation]    Script Date: 17/08/2021 07:37:42 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 17/08/2021 07:37:42 م ******/
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
	[userId] [int] NULL,
 CONSTRAINT [PK_invoices] PRIMARY KEY CLUSTERED 
(
	[invoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoiceStatus]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[items]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[itemsProp]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 17/08/2021 07:37:42 م ******/
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
	[inventoryItemLocId] [int] NULL,
 CONSTRAINT [PK_itemsTransfer] PRIMARY KEY CLUSTERED 
(
	[itemsTransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 17/08/2021 07:37:42 م ******/
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
	[isActive] [tinyint] NULL,
 CONSTRAINT [PK_itemsUnits] PRIMARY KEY CLUSTERED 
(
	[itemUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[locations]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[medalAgent]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[medals]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[memberships]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[notification]    Script Date: 17/08/2021 07:37:42 م ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[notificationUser]    Script Date: 17/08/2021 07:37:42 م ******/
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
 CONSTRAINT [PK_notificationUser] PRIMARY KEY CLUSTERED 
(
	[notUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[objects]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[offers]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[packages]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[Points]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[pos]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[posUsers]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[properties]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[sections]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[serials]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[setting]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[setValues]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[shippingCompanies]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[storageCost]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[subscriptionFees]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[sysEmails]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[units]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[userSetValues]    Script Date: 17/08/2021 07:37:42 م ******/
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
/****** Object:  Table [dbo].[usersLogs]    Script Date: 17/08/2021 07:37:42 م ******/
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

INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (1, NULL, N'مهند  أبوشعر ', N'v-000001', N'أبوشعر', N'aleppo', N'YASINIDLBI@GMAIL.COM', N'+961-021-0998877', N'+963-093355887', N'57440ff6b80f068efd50410ea24fd593.jfif', N'v', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:06:09.7108341' AS DateTime2), CAST(N'2021-08-15T13:43:03.5407077' AS DateTime2), 1, 9, N'notes', 1, N'+966-021-887666', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (2, NULL, N'نور   خضير', N'v-000002', N'خضير', N'homs', N'nour@gmail.com', N'+966-021-57892455', N'+963-098765321', N'c37858823db0093766eee74d8ee1f1e5.jfif', N'v', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:06:22.6174744' AS DateTime2), CAST(N'2021-08-07T12:52:33.1961256' AS DateTime2), 1, 3, N'ملاحظات', 1, N'+950-041-8529663', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (3, NULL, N'ديانا  لقق', N'v-000003', N'لقق', N'', N'', N'', N'+963-333333333', N'71f020248a405d21e94d1de52043bed4.png', N'v', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:06:41.9485466' AS DateTime2), CAST(N'2021-07-29T22:56:22.5252580' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (4, NULL, N'بيان  سليمان', N'v-000004', N'سليمان', N'', N'', N'', N'+963-444444444', N'd2ec5f1ed83abfca0dfec76506b696b3.png', N'v', N'', CAST(26250.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:07:08.7041709' AS DateTime2), CAST(N'2021-08-16T13:00:42.3635804' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (5, NULL, N'أحمد   عقاد', N'v-000005', N'عقاد', N'', N'atiaf.art@gmail.com', N'', N'+963-555555555', N'f96f8a89e2143f1e43a2ba7953fb5413.png', N'v', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:07:20.4208470' AS DateTime2), CAST(N'2021-08-08T14:39:41.7408538' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (6, NULL, N'بشار   زيدان', N'v-000006', N'زيدان', N'', N'', N'', N'+963-666666666', N'56a2e0231c3d394ace201adf37d13f63.png', N'v', N'', CAST(500.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:07:34.4228719' AS DateTime2), CAST(N'2021-08-17T16:59:48.7738464' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (7, NULL, N'محمد سودة', N'v-000007', N'سودة', N'', N'najyms@gmail.com', N'', N'+963-777777777', N'3204215c19f25609034d24451f7e03d7.jpg', N'v', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:07:45.7310231' AS DateTime2), CAST(N'2021-08-07T17:46:05.9070940' AS DateTime2), 1, 9, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (8, NULL, N'محمد   بهلوان', N'v-000008', N'بهلوان', N'', N'najyms@gmail.com', N'', N'+963-888888888', N'6a5d62c1233b5e9b2000dd13aadf81f4.png', N'v', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:08:01.0595455' AS DateTime2), CAST(N'2021-08-07T17:03:17.5933503' AS DateTime2), 1, 9, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (9, NULL, N'سمر كركوتلي', N'c-000001', N'كركوك', N'سسسس', N'', N'+963-011-555555555555555', N'+966-999999999', N'6eaba1dc3c031faf262149c058fea728.jfif', N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:08:45.2069660' AS DateTime2), CAST(N'2021-08-09T12:05:43.3489372' AS DateTime2), 1, 2, N'سسسس', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (10, NULL, N'عمر  الحراكي', N'c-000002', N'الحراكي', N'', N'najyms@gmail.com', N'', N'+966-101010101', N'0f26776e0a524c7d2b6b5f771d500980.png', N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:08:58.0342271' AS DateTime2), CAST(N'2021-08-16T19:15:22.0453107' AS DateTime2), 1, 9, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (11, NULL, N'عمر  طيفور', N'c-000003', N'طيفور', N'', N'', N'', N'+966-111111111', N'05da7ccc8020731d607471318fc4f35b.png', N'c', N'', CAST(3500.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:09:16.4003380' AS DateTime2), CAST(N'2021-07-26T12:04:33.7746378' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (12, NULL, N'عمر   معروف', N'c-000004', N'معروف', N'', N'', N'', N'+966-121212121', N'0731f29a7d8c55ddab810a076d078aff.png', N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:09:40.9186322' AS DateTime2), CAST(N'2021-07-26T12:05:50.3282855' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (13, NULL, N'أمل  زيدان', N'c-000005', N'زيدان', N'', N'', N'', N'+966-131313131', N'd24538a57424ec2d36086326b9215b74.png', N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:10:01.5456550' AS DateTime2), CAST(N'2021-07-28T11:13:01.1413348' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (14, NULL, N'قمر   كعكة', N'c-000006', N'كعكة', N'', N'', N'', N'+966-141414141', N'ad4bfd50185ef68bce2b903aa7e10ec0.png', N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:10:14.7478300' AS DateTime2), CAST(N'2021-08-09T11:55:26.6461904' AS DateTime2), 1, 3, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (15, NULL, N'طارق غباش', N'c-000007', N'غباش', N'', N'', N'', N'+966-151515151', N'cfba0c3306a45ea0746c531906c58962.png', N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:10:32.6809829' AS DateTime2), CAST(N'2021-07-26T12:11:52.9283383' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (16, NULL, N'طه المحجوب', N'c-000008', N'المحجوب', N'', N'', N'', N'+966-161616161', N'4361139d4379eb98f913441815402fe6.png', N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:10:42.7726056' AS DateTime2), CAST(N'2021-07-25T13:08:43.4044528' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (17, NULL, N'لونا  آغا', N'c-000009', N'آغا', N'', N'', N'', N'+966-171717171', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:10:54.7602515' AS DateTime2), CAST(N'2021-06-30T16:10:54.7602515' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (18, NULL, N'ايمن  البكر', N'c-000010', N'البكر', N'', N'', N'', N'+966-181818181', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:11:11.1459706' AS DateTime2), CAST(N'2021-06-30T16:11:11.1459706' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (19, NULL, N'هلا  بكداش', N'c-000011', N'بكداش', N'', N'', N'', N'+966-191919191', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:12:11.0473459' AS DateTime2), CAST(N'2021-06-30T16:12:11.0473459' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (20, NULL, N'اية  الأحمد', N'c-000012', N'الأحمد', N'', N'', N'', N'+966-202020202', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:12:29.8164362' AS DateTime2), CAST(N'2021-06-30T16:12:29.8164362' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (21, NULL, N'ندى ادلبي', N'c-000013', N'ادلبي', N'', N'', N'', N'+966-212121212', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:12:42.4374840' AS DateTime2), CAST(N'2021-08-07T12:17:23.9125888' AS DateTime2), 1, 2, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (22, NULL, N'جود  كرزة', N'c-000014', N'كرزة', N'', N'', N'', N'+966-222222222', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:12:55.0773452' AS DateTime2), CAST(N'2021-06-30T16:12:55.0773452' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (23, NULL, N'غيثاء والي', N'c-000015', N'والي', N'', N'', N'', N'+966-232323232', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:13:13.7804093' AS DateTime2), CAST(N'2021-06-30T16:13:13.7804093' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (24, NULL, N'جمانة كرزة', N'c-000016', N'كرزة', N'', N'', N'', N'+966-242424242', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:13:36.1745594' AS DateTime2), CAST(N'2021-06-30T16:13:36.1745594' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve]) VALUES (25, NULL, N'راما حمامي', N'c-000017', N'حمامي', N'', N'', N'', N'+966-252525252', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-06-30T16:13:50.5292915' AS DateTime2), CAST(N'2021-06-30T16:13:50.5292915' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.00 AS Decimal(20, 2)))
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

INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (65, N'pbnd-000001', CAST(1500.00 AS Decimal(20, 2)), CAST(N'2021-08-11T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-08-04T14:54:46.7895609' AS DateTime2), CAST(N'2021-08-04T14:54:46.7895609' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (66, N'pbnd-000001', CAST(1000.00 AS Decimal(20, 2)), CAST(N'2021-08-14T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-08-05T12:00:24.5315659' AS DateTime2), CAST(N'2021-08-05T12:00:24.5315659' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (67, N'pbnd-000002', CAST(6000.00 AS Decimal(20, 2)), CAST(N'2021-08-06T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 9, 9, CAST(N'2021-08-07T12:11:26.6462032' AS DateTime2), CAST(N'2021-08-07T12:11:26.6462032' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (68, N'pbnd-000003', CAST(100000.00 AS Decimal(20, 2)), CAST(N'2021-08-14T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 9, 9, CAST(N'2021-08-07T13:15:06.1914659' AS DateTime2), CAST(N'2021-08-07T13:15:06.1914659' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (69, N'524', CAST(3000.00 AS Decimal(20, 2)), CAST(N'2021-08-09T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-08-09T14:46:25.4708314' AS DateTime2), CAST(N'2021-08-09T14:46:25.4708314' AS DateTime2), NULL, NULL)
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
SET IDENTITY_INSERT [dbo].[cards] ON 

INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1, N'Visa Card', N'', CAST(N'2021-06-30T17:57:16.0207327' AS DateTime2), CAST(N'2021-06-30T17:57:16.0207327' AS DateTime2), 1, 1, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'Master Card', N'', CAST(N'2021-06-30T17:57:25.2721667' AS DateTime2), CAST(N'2021-06-30T17:57:25.2721667' AS DateTime2), 1, 1, 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, N'K-net', N'', CAST(N'2021-06-30T17:57:35.1366818' AS DateTime2), CAST(N'2021-06-30T17:57:35.1366818' AS DateTime2), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[cards] OFF
GO
SET IDENTITY_INSERT [dbo].[cashTransfer] ON 

INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1, NULL, N'd', 2, NULL, NULL, 1, N'dv-000001', CAST(N'2021-08-15T13:43:03.3950971' AS DateTime2), CAST(N'2021-08-15T13:43:03.3950971' AS DateTime2), CAST(10000.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'balance', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (2, NULL, N'd', 2, NULL, NULL, 2, N'dc-000001', CAST(N'2021-08-15T13:43:32.9640868' AS DateTime2), CAST(N'2021-08-15T13:43:32.9640868' AS DateTime2), CAST(105000.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (3, NULL, N'p', 2, NULL, 1, 1, N'pv-000001', CAST(N'2021-08-15T13:43:53.6687593' AS DateTime2), CAST(N'2021-08-15T13:43:53.6687593' AS DateTime2), CAST(10000.00 AS Decimal(20, 2)), 2, 2, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (4, NULL, N'd', 2, NULL, NULL, 3, N'dv-000002', CAST(N'2021-08-16T13:00:42.1531106' AS DateTime2), CAST(N'2021-08-16T13:00:42.1531106' AS DateTime2), CAST(26250.00 AS Decimal(20, 2)), 2, 2, NULL, NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'balance', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (5, NULL, N'd', 2, NULL, 10, 5, N'dc-000002', CAST(N'2021-08-16T19:10:37.7300262' AS DateTime2), CAST(N'2021-08-16T19:10:37.7300262' AS DateTime2), CAST(21000.00 AS Decimal(20, 2)), 9, 9, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (6, NULL, N'd', 2, NULL, 11, 6, N'dc-000003', CAST(N'2021-08-17T16:30:16.8511744' AS DateTime2), CAST(N'2021-08-17T16:30:16.8511744' AS DateTime2), CAST(3500.00 AS Decimal(20, 2)), 1, 1, N'', NULL, NULL, NULL, N'c', NULL, N'1245645645', NULL, NULL, N'cheque', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (7, NULL, N'd', 2, NULL, NULL, 8, N'dv-000003', CAST(N'2021-08-17T16:59:48.7229786' AS DateTime2), CAST(N'2021-08-17T16:59:48.7229786' AS DateTime2), CAST(2500.00 AS Decimal(20, 2)), 1, 1, NULL, NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'balance', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (8, NULL, N'p', 2, NULL, 6, 8, N'pv-000002', CAST(N'2021-08-17T17:02:40.2475329' AS DateTime2), CAST(N'2021-08-17T17:02:40.2475329' AS DateTime2), CAST(2000.00 AS Decimal(20, 2)), 1, 1, N'', NULL, NULL, NULL, N'v', NULL, N'u678nl', NULL, NULL, N'cheque', NULL, NULL, NULL)
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

INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (1, N'coupon', N'877', 1, 1, CAST(10.00 AS Decimal(20, 2)), CAST(N'2021-08-10T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-23T00:00:00.0000000' AS DateTime2), N'', 5, 5, CAST(10.00 AS Decimal(20, 2)), CAST(100.00 AS Decimal(20, 2)), CAST(N'2021-08-16T12:15:23.6154508' AS DateTime2), CAST(N'2021-08-16T12:15:23.6154508' AS DateTime2), 3, 3, N'cop-877')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (2, N'coupon2', N'852', 0, 1, CAST(10.00 AS Decimal(20, 2)), CAST(N'2021-08-10T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-23T00:00:00.0000000' AS DateTime2), N'', 5, 5, CAST(10.00 AS Decimal(20, 2)), CAST(100.00 AS Decimal(20, 2)), CAST(N'2021-08-16T12:23:54.5499913' AS DateTime2), CAST(N'2021-08-16T12:23:54.5499913' AS DateTime2), 3, 3, N'cop-852')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (3, N'coupon3', N'456', 1, 2, CAST(15.00 AS Decimal(20, 2)), CAST(N'2021-08-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-15T00:00:00.0000000' AS DateTime2), N'', 3, 3, CAST(10.00 AS Decimal(20, 2)), CAST(100.00 AS Decimal(20, 2)), CAST(N'2021-08-16T12:24:51.9964889' AS DateTime2), CAST(N'2021-08-16T12:24:51.9964889' AS DateTime2), 3, 3, N'cop-456')
SET IDENTITY_INSERT [dbo].[coupons] OFF
GO
SET IDENTITY_INSERT [dbo].[groupObject] ON 

INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1984, 19, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.2884352' AS DateTime2), CAST(N'2021-08-11T14:23:48.2884352' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1985, 19, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.2954469' AS DateTime2), CAST(N'2021-08-11T14:23:48.2954469' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1986, 19, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.2982133' AS DateTime2), CAST(N'2021-08-11T14:23:48.2982133' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1987, 19, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.3003266' AS DateTime2), CAST(N'2021-08-11T14:23:48.3003266' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1988, 19, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.3030142' AS DateTime2), CAST(N'2021-08-11T14:23:48.3030142' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1989, 19, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.3052000' AS DateTime2), CAST(N'2021-08-11T14:23:48.3052000' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1990, 19, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.3068001' AS DateTime2), CAST(N'2021-08-11T14:23:48.3068001' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1991, 19, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.3088765' AS DateTime2), CAST(N'2021-08-11T14:23:48.3088765' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1992, 19, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.3120726' AS DateTime2), CAST(N'2021-08-11T14:23:48.3120726' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1993, 19, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.3136642' AS DateTime2), CAST(N'2021-08-11T14:23:48.3136642' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1994, 19, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.3157684' AS DateTime2), CAST(N'2021-08-11T14:23:48.3157684' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1995, 19, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.3189437' AS DateTime2), CAST(N'2021-08-11T14:23:48.3189437' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1996, 19, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.3217497' AS DateTime2), CAST(N'2021-08-11T14:23:48.3217497' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1997, 19, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.3244521' AS DateTime2), CAST(N'2021-08-11T14:23:48.3244521' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1998, 19, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.3276121' AS DateTime2), CAST(N'2021-08-11T14:23:48.3276121' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1999, 19, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6174149' AS DateTime2), CAST(N'2021-08-11T14:23:48.6174149' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2000, 19, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6207860' AS DateTime2), CAST(N'2021-08-11T14:23:48.6207860' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2001, 19, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6234938' AS DateTime2), CAST(N'2021-08-11T14:23:48.6234938' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2002, 19, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6256593' AS DateTime2), CAST(N'2021-08-11T14:23:48.6256593' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2003, 19, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6272337' AS DateTime2), CAST(N'2021-08-11T14:23:48.6272337' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2004, 19, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6293415' AS DateTime2), CAST(N'2021-08-11T14:23:48.6293415' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2005, 19, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6319931' AS DateTime2), CAST(N'2021-08-11T14:23:48.6319931' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2006, 19, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6351341' AS DateTime2), CAST(N'2021-08-11T14:23:48.6351341' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2007, 19, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6378501' AS DateTime2), CAST(N'2021-08-11T14:23:48.6378501' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2008, 19, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6400408' AS DateTime2), CAST(N'2021-08-11T14:23:48.6400408' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2009, 19, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6427281' AS DateTime2), CAST(N'2021-08-11T14:23:48.6427281' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2010, 19, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6448724' AS DateTime2), CAST(N'2021-08-11T14:23:48.6448724' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2011, 19, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6486752' AS DateTime2), CAST(N'2021-08-11T14:23:48.6486752' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2012, 19, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6507885' AS DateTime2), CAST(N'2021-08-11T14:23:48.6507885' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2013, 19, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.6534469' AS DateTime2), CAST(N'2021-08-11T14:23:48.6534469' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2014, 19, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9349523' AS DateTime2), CAST(N'2021-08-11T14:23:48.9349523' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2015, 19, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9387115' AS DateTime2), CAST(N'2021-08-11T14:23:48.9387115' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2016, 19, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9407955' AS DateTime2), CAST(N'2021-08-11T14:23:48.9407955' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2017, 19, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9429871' AS DateTime2), CAST(N'2021-08-11T14:23:48.9429871' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2018, 19, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9445838' AS DateTime2), CAST(N'2021-08-11T14:23:48.9445838' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2019, 19, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9466680' AS DateTime2), CAST(N'2021-08-11T14:23:48.9466680' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2020, 19, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9493396' AS DateTime2), CAST(N'2021-08-11T14:23:48.9493396' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2021, 19, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9514271' AS DateTime2), CAST(N'2021-08-11T14:23:48.9514271' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2022, 19, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9535389' AS DateTime2), CAST(N'2021-08-11T14:23:48.9535389' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2023, 19, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9562673' AS DateTime2), CAST(N'2021-08-11T14:23:48.9562673' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2024, 19, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9583928' AS DateTime2), CAST(N'2021-08-11T14:23:48.9583928' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2025, 19, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9605786' AS DateTime2), CAST(N'2021-08-11T14:23:48.9605786' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2026, 19, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9632824' AS DateTime2), CAST(N'2021-08-11T14:23:48.9632824' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2027, 19, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9654023' AS DateTime2), CAST(N'2021-08-11T14:23:48.9654023' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2028, 19, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:48.9680818' AS DateTime2), CAST(N'2021-08-11T14:23:48.9680818' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2029, 19, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:49.9278481' AS DateTime2), CAST(N'2021-08-11T14:23:49.9278481' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2030, 19, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:49.9320091' AS DateTime2), CAST(N'2021-08-11T14:23:49.9320091' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2031, 19, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:49.9346321' AS DateTime2), CAST(N'2021-08-11T14:23:49.9346321' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2032, 19, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:49.9378441' AS DateTime2), CAST(N'2021-08-11T14:23:49.9378441' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2033, 19, 50, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:49.9398749' AS DateTime2), CAST(N'2021-08-11T14:31:42.1031970' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2034, 19, 51, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:49.9425588' AS DateTime2), CAST(N'2021-08-11T14:31:48.5748208' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2035, 19, 52, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:49.9447093' AS DateTime2), CAST(N'2021-08-11T14:31:54.6934143' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2036, 19, 53, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:49.9485159' AS DateTime2), CAST(N'2021-08-11T14:31:54.9085001' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2037, 19, 54, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:49.9506218' AS DateTime2), CAST(N'2021-08-11T14:31:59.5635849' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2038, 19, 55, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:49.9532784' AS DateTime2), CAST(N'2021-08-11T14:31:59.7928327' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2039, 19, 56, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:49.9553807' AS DateTime2), CAST(N'2021-08-11T14:32:06.0269593' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2040, 19, 57, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:49.9580962' AS DateTime2), CAST(N'2021-08-11T14:32:06.3012717' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2041, 19, 58, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:49.9601723' AS DateTime2), CAST(N'2021-08-11T14:32:16.6249330' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2042, 19, 59, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:49.9632823' AS DateTime2), CAST(N'2021-08-11T14:32:21.8797999' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2043, 19, 60, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:49.9653475' AS DateTime2), CAST(N'2021-08-11T14:32:28.3019383' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2044, 19, 61, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:50.2523260' AS DateTime2), CAST(N'2021-08-11T14:33:29.7678152' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2045, 19, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:50.2549841' AS DateTime2), CAST(N'2021-08-11T14:23:50.2549841' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2046, 19, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:50.2581517' AS DateTime2), CAST(N'2021-08-11T14:23:50.2581517' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2047, 19, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:50.2602424' AS DateTime2), CAST(N'2021-08-11T14:23:50.2602424' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2048, 19, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:50.2618731' AS DateTime2), CAST(N'2021-08-11T14:23:50.2618731' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2049, 19, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:50.2650923' AS DateTime2), CAST(N'2021-08-11T14:23:50.2650923' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2050, 19, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:50.2677745' AS DateTime2), CAST(N'2021-08-11T14:23:50.2677745' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2051, 19, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:50.2698510' AS DateTime2), CAST(N'2021-08-11T14:23:50.2698510' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2052, 19, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:50.2725202' AS DateTime2), CAST(N'2021-08-11T14:23:50.2725202' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2053, 19, 74, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:50.2746144' AS DateTime2), CAST(N'2021-08-11T14:28:33.7150932' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2054, 19, 75, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:50.2767294' AS DateTime2), CAST(N'2021-08-11T14:28:41.0885149' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2055, 19, 76, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:50.2794205' AS DateTime2), CAST(N'2021-08-11T14:28:49.3021624' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2056, 19, 77, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:50.2826185' AS DateTime2), CAST(N'2021-08-11T14:28:54.5116856' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2057, 19, 78, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.2852613' AS DateTime2), CAST(N'2021-08-11T14:33:34.6307648' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2058, 19, 79, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.2874349' AS DateTime2), CAST(N'2021-08-11T14:33:34.8562300' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2059, 19, 80, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.5704882' AS DateTime2), CAST(N'2021-08-11T14:33:36.9568955' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2060, 19, 81, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:50.5736367' AS DateTime2), CAST(N'2021-08-11T14:33:42.7502453' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2061, 19, 82, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:50.5752644' AS DateTime2), CAST(N'2021-08-11T14:29:08.3844115' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2062, 19, 83, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.5773974' AS DateTime2), CAST(N'2021-08-11T14:29:08.6018162' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2063, 19, 84, N'', 1, 0, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:50.5802814' AS DateTime2), CAST(N'2021-08-11T14:29:14.7316258' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2064, 19, 85, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.5823950' AS DateTime2), CAST(N'2021-08-11T14:29:14.9521857' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2065, 19, 86, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.5840473' AS DateTime2), CAST(N'2021-08-11T14:29:18.0496820' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2066, 19, 87, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.5861226' AS DateTime2), CAST(N'2021-08-11T14:29:18.2987091' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2067, 19, 88, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.5882250' AS DateTime2), CAST(N'2021-08-11T14:29:18.5291887' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2068, 19, 89, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.5909477' AS DateTime2), CAST(N'2021-08-11T14:29:23.8063032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2069, 19, 90, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.5931014' AS DateTime2), CAST(N'2021-08-11T14:29:24.0252096' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2070, 19, 91, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.5952122' AS DateTime2), CAST(N'2021-08-11T14:29:28.0552034' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2071, 19, 92, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.5968262' AS DateTime2), CAST(N'2021-08-11T14:29:28.2670291' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2072, 19, 93, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.5989569' AS DateTime2), CAST(N'2021-08-11T14:29:28.4889718' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2073, 19, 94, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.6016660' AS DateTime2), CAST(N'2021-08-11T14:29:31.0002094' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2074, 19, 95, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.8898535' AS DateTime2), CAST(N'2021-08-11T14:29:31.2658909' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2075, 19, 96, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.8946723' AS DateTime2), CAST(N'2021-08-11T14:29:36.9298072' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2076, 19, 97, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.8967624' AS DateTime2), CAST(N'2021-08-11T14:29:37.1543121' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2077, 19, 98, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.8988601' AS DateTime2), CAST(N'2021-08-11T14:29:37.3731420' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2078, 19, 99, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.9004738' AS DateTime2), CAST(N'2021-08-11T14:29:43.9107606' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2079, 19, 100, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.9025548' AS DateTime2), CAST(N'2021-08-11T14:29:44.1198588' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2080, 19, 101, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.9053211' AS DateTime2), CAST(N'2021-08-11T14:29:44.3365063' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2081, 19, 102, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.9086294' AS DateTime2), CAST(N'2021-08-16T19:09:38.1562129' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2082, 19, 103, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.9113513' AS DateTime2), CAST(N'2021-08-16T19:09:38.1731701' AS DateTime2), 2, 2, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2083, 19, 104, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.9134585' AS DateTime2), CAST(N'2021-08-16T19:09:38.1881284' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2084, 19, 105, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.9161519' AS DateTime2), CAST(N'2021-08-16T19:09:38.2010938' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2085, 19, 106, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.9182928' AS DateTime2), CAST(N'2021-08-16T19:09:38.2130624' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2086, 19, 107, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:50.9210345' AS DateTime2), CAST(N'2021-08-11T14:30:00.9217826' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2087, 19, 108, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:50.9248186' AS DateTime2), CAST(N'2021-08-11T14:30:15.2709850' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2088, 19, 109, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:50.9280526' AS DateTime2), CAST(N'2021-08-11T14:30:15.4863238' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2089, 19, 110, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:51.2384597' AS DateTime2), CAST(N'2021-08-11T14:30:20.0965379' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2090, 19, 111, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.2422325' AS DateTime2), CAST(N'2021-08-11T14:30:20.3105666' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2091, 19, 112, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:23:51.2453795' AS DateTime2), CAST(N'2021-08-11T14:23:51.2453795' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2092, 19, 113, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:23:51.2480387' AS DateTime2), CAST(N'2021-08-11T14:23:51.2480387' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2093, 19, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:51.2501113' AS DateTime2), CAST(N'2021-08-11T14:23:51.2501113' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2094, 19, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:23:51.2521885' AS DateTime2), CAST(N'2021-08-11T14:23:51.2521885' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2095, 19, 116, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:51.2542689' AS DateTime2), CAST(N'2021-08-11T14:30:56.1488008' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2096, 19, 117, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.2558903' AS DateTime2), CAST(N'2021-08-11T14:30:56.3965910' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2097, 19, 118, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.2580355' AS DateTime2), CAST(N'2021-08-11T14:30:59.7481598' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2098, 19, 119, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.2607112' AS DateTime2), CAST(N'2021-08-11T14:30:05.2759888' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2099, 19, 120, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.2617461' AS DateTime2), CAST(N'2021-08-11T14:30:05.4950778' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2100, 19, 121, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.2638495' AS DateTime2), CAST(N'2021-08-11T14:30:05.7068994' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2101, 19, 122, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.2670311' AS DateTime2), CAST(N'2021-08-11T14:31:11.6080424' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2102, 19, 123, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.2686424' AS DateTime2), CAST(N'2021-08-11T14:31:11.8324199' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2103, 19, 124, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.2718877' AS DateTime2), CAST(N'2021-08-11T14:31:15.5489397' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2104, 19, 125, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.5644741' AS DateTime2), CAST(N'2021-08-11T14:31:15.7665804' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2105, 19, 126, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.5677089' AS DateTime2), CAST(N'2021-08-11T14:31:19.5549214' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2106, 19, 127, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.5693332' AS DateTime2), CAST(N'2021-08-11T14:31:19.7802123' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2107, 19, 128, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.5715090' AS DateTime2), CAST(N'2021-08-11T14:31:07.7045278' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2108, 19, 129, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.5736133' AS DateTime2), CAST(N'2021-08-11T14:31:07.9251545' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2109, 19, 130, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.5762772' AS DateTime2), CAST(N'2021-08-11T14:31:22.8573889' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2110, 19, 131, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.5783498' AS DateTime2), CAST(N'2021-08-11T14:31:23.1403934' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2111, 19, 132, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.5810077' AS DateTime2), CAST(N'2021-08-11T14:31:25.6178409' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2112, 19, 133, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.5830900' AS DateTime2), CAST(N'2021-08-11T14:31:25.9274182' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2113, 19, 134, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:51.5851980' AS DateTime2), CAST(N'2021-08-11T14:31:03.7536410' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2114, 19, 135, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.5873136' AS DateTime2), CAST(N'2021-08-11T14:31:04.0126438' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2115, 19, 137, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:51.5889400' AS DateTime2), CAST(N'2021-08-11T14:28:41.3094514' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2116, 19, 138, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.5910830' AS DateTime2), CAST(N'2021-08-11T14:33:42.9624179' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2117, 19, 145, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:51.5938545' AS DateTime2), CAST(N'2021-08-11T14:29:00.3709789' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2118, 19, 147, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:51.5959420' AS DateTime2), CAST(N'2021-08-11T14:23:51.5959420' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2119, 19, 148, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:51.8798912' AS DateTime2), CAST(N'2021-08-11T14:23:51.8798912' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2120, 19, 151, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:23:51.8831105' AS DateTime2), CAST(N'2021-08-11T14:33:47.7785276' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2121, 19, 152, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:51.8858687' AS DateTime2), CAST(N'2021-08-11T14:23:51.8858687' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2122, 19, 153, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.8880079' AS DateTime2), CAST(N'2021-08-11T14:29:47.2477478' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2123, 19, 154, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.8907340' AS DateTime2), CAST(N'2021-08-11T14:29:47.4664791' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2124, 19, 155, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.8928418' AS DateTime2), CAST(N'2021-08-11T14:29:28.7054595' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2125, 19, 156, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.8957355' AS DateTime2), CAST(N'2021-08-11T14:29:28.9222817' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2126, 19, 157, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:51.8978470' AS DateTime2), CAST(N'2021-08-11T14:23:51.8978470' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2127, 19, 158, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.9006016' AS DateTime2), CAST(N'2021-08-11T14:33:51.8982781' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2128, 19, 159, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:23:51.9027124' AS DateTime2), CAST(N'2021-08-11T14:23:51.9027124' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2129, 19, 160, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.9054640' AS DateTime2), CAST(N'2021-08-11T14:29:33.6409164' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2130, 19, 161, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.9081648' AS DateTime2), CAST(N'2021-08-11T14:29:33.8570004' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2131, 19, 162, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.9103294' AS DateTime2), CAST(N'2021-08-16T19:09:38.2280222' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2132, 19, 163, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.9135261' AS DateTime2), CAST(N'2021-08-11T14:30:05.9321512' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2133, 19, 164, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.9161632' AS DateTime2), CAST(N'2021-08-11T14:29:44.5631536' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2134, 19, 165, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:52.1299016' AS DateTime2), CAST(N'2021-08-11T14:29:47.6781236' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2135, 20, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3400575' AS DateTime2), CAST(N'2021-08-11T14:24:42.3400575' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2136, 20, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3442585' AS DateTime2), CAST(N'2021-08-11T14:24:42.3442585' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2137, 20, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3468781' AS DateTime2), CAST(N'2021-08-11T14:24:42.3468781' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2138, 20, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3489926' AS DateTime2), CAST(N'2021-08-11T14:24:42.3489926' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2139, 20, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3516878' AS DateTime2), CAST(N'2021-08-11T14:24:42.3516878' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2140, 20, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3548439' AS DateTime2), CAST(N'2021-08-11T14:24:42.3548439' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2141, 20, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3575025' AS DateTime2), CAST(N'2021-08-11T14:24:42.3575025' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2142, 20, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3606598' AS DateTime2), CAST(N'2021-08-11T14:24:42.3606598' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2143, 20, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3627923' AS DateTime2), CAST(N'2021-08-11T14:24:42.3627923' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2144, 20, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3655265' AS DateTime2), CAST(N'2021-08-11T14:24:42.3655265' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2145, 20, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3676615' AS DateTime2), CAST(N'2021-08-11T14:24:42.3676615' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2146, 20, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3704392' AS DateTime2), CAST(N'2021-08-11T14:24:42.3704392' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2147, 20, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3725604' AS DateTime2), CAST(N'2021-08-11T14:24:42.3725604' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2148, 20, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3764928' AS DateTime2), CAST(N'2021-08-11T14:24:42.3764928' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2149, 20, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.3792274' AS DateTime2), CAST(N'2021-08-11T14:24:42.3792274' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2150, 20, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.6965780' AS DateTime2), CAST(N'2021-08-11T14:24:42.6965780' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2151, 20, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.6996964' AS DateTime2), CAST(N'2021-08-11T14:24:42.6996964' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2152, 20, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.7023858' AS DateTime2), CAST(N'2021-08-11T14:24:42.7023858' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2153, 20, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.7045132' AS DateTime2), CAST(N'2021-08-11T14:24:42.7045132' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2154, 20, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.7061512' AS DateTime2), CAST(N'2021-08-11T14:24:42.7061512' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2155, 20, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.7082231' AS DateTime2), CAST(N'2021-08-11T14:24:42.7082231' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2156, 20, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.7103208' AS DateTime2), CAST(N'2021-08-11T14:24:42.7103208' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2157, 20, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.7129656' AS DateTime2), CAST(N'2021-08-11T14:24:42.7129656' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2158, 20, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.7150868' AS DateTime2), CAST(N'2021-08-11T14:24:42.7150868' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2159, 20, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.7172070' AS DateTime2), CAST(N'2021-08-11T14:24:42.7172070' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2160, 20, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.7199486' AS DateTime2), CAST(N'2021-08-11T14:24:42.7199486' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2161, 20, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.7220503' AS DateTime2), CAST(N'2021-08-11T14:24:42.7220503' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2162, 20, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.7242762' AS DateTime2), CAST(N'2021-08-11T14:24:42.7242762' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2163, 20, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.7270244' AS DateTime2), CAST(N'2021-08-11T14:24:42.7270244' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2164, 20, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:42.7297327' AS DateTime2), CAST(N'2021-08-11T14:24:42.7297327' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2165, 20, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2142750' AS DateTime2), CAST(N'2021-08-11T14:24:43.2142750' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2166, 20, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2180506' AS DateTime2), CAST(N'2021-08-11T14:24:43.2180506' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2167, 20, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2211989' AS DateTime2), CAST(N'2021-08-11T14:24:43.2211989' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2168, 20, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2228163' AS DateTime2), CAST(N'2021-08-11T14:24:43.2228163' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2169, 20, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2260708' AS DateTime2), CAST(N'2021-08-11T14:24:43.2260708' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2170, 20, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2276976' AS DateTime2), CAST(N'2021-08-11T14:24:43.2276976' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2171, 20, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2298257' AS DateTime2), CAST(N'2021-08-11T14:24:43.2298257' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2172, 20, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2325005' AS DateTime2), CAST(N'2021-08-11T14:24:43.2325005' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2173, 20, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2346301' AS DateTime2), CAST(N'2021-08-11T14:24:43.2346301' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2174, 20, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2367697' AS DateTime2), CAST(N'2021-08-11T14:24:43.2367697' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2175, 20, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2384326' AS DateTime2), CAST(N'2021-08-11T14:24:43.2384326' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2176, 20, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2405502' AS DateTime2), CAST(N'2021-08-11T14:24:43.2405502' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2177, 20, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2436576' AS DateTime2), CAST(N'2021-08-11T14:24:43.2436576' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2178, 20, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2452981' AS DateTime2), CAST(N'2021-08-11T14:24:43.2452981' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2179, 20, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.2473804' AS DateTime2), CAST(N'2021-08-11T14:24:43.2473804' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2180, 20, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.7804164' AS DateTime2), CAST(N'2021-08-11T14:24:43.7804164' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2181, 20, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.7852347' AS DateTime2), CAST(N'2021-08-11T14:24:43.7852347' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2182, 20, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.7874145' AS DateTime2), CAST(N'2021-08-11T14:24:43.7874145' AS DateTime2), 2, 2, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2183, 20, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.7900874' AS DateTime2), CAST(N'2021-08-11T14:24:43.7900874' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2184, 20, 50, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.7933660' AS DateTime2), CAST(N'2021-08-11T14:24:43.7933660' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2185, 20, 51, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.7949523' AS DateTime2), CAST(N'2021-08-11T14:24:43.7949523' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2186, 20, 52, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.7970820' AS DateTime2), CAST(N'2021-08-11T14:24:43.7970820' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2187, 20, 53, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:43.7991963' AS DateTime2), CAST(N'2021-08-11T14:24:43.7991963' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2188, 20, 54, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.8018524' AS DateTime2), CAST(N'2021-08-11T14:24:43.8018524' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2189, 20, 55, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:43.8039188' AS DateTime2), CAST(N'2021-08-11T14:24:43.8039188' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2190, 20, 56, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.8067991' AS DateTime2), CAST(N'2021-08-11T14:24:43.8067991' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2191, 20, 57, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:43.8089682' AS DateTime2), CAST(N'2021-08-11T14:24:43.8089682' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2192, 20, 58, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.8128246' AS DateTime2), CAST(N'2021-08-11T14:24:43.8128246' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2193, 20, 59, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.8155792' AS DateTime2), CAST(N'2021-08-11T14:24:43.8155792' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2194, 20, 60, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:43.8176626' AS DateTime2), CAST(N'2021-08-11T14:24:43.8176626' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2195, 20, 61, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.1037358' AS DateTime2), CAST(N'2021-08-11T14:24:44.1037358' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2196, 20, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.1096839' AS DateTime2), CAST(N'2021-08-11T14:24:44.1096839' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2197, 20, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.1125032' AS DateTime2), CAST(N'2021-08-11T14:24:44.1125032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2198, 20, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.1156892' AS DateTime2), CAST(N'2021-08-11T14:24:44.1156892' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2199, 20, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.1184171' AS DateTime2), CAST(N'2021-08-11T14:24:44.1184171' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2200, 20, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.1205668' AS DateTime2), CAST(N'2021-08-11T14:24:44.1205668' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2201, 20, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.1221874' AS DateTime2), CAST(N'2021-08-11T14:24:44.1221874' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2202, 20, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.1243025' AS DateTime2), CAST(N'2021-08-11T14:24:44.1243025' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2203, 20, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.1270216' AS DateTime2), CAST(N'2021-08-11T14:24:44.1270216' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2204, 20, 74, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.1291467' AS DateTime2), CAST(N'2021-08-11T14:24:44.1291467' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2205, 20, 75, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.1312805' AS DateTime2), CAST(N'2021-08-11T14:24:44.1312805' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2206, 20, 76, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.1340736' AS DateTime2), CAST(N'2021-08-11T14:24:44.1340736' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2207, 20, 77, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.1368955' AS DateTime2), CAST(N'2021-08-11T14:24:44.1368955' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2208, 20, 78, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.1406243' AS DateTime2), CAST(N'2021-08-11T14:24:44.1406243' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2209, 20, 79, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.1427772' AS DateTime2), CAST(N'2021-08-11T14:24:44.1427772' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2210, 20, 80, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.4300577' AS DateTime2), CAST(N'2021-08-11T14:24:44.4300577' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2211, 20, 81, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.4339255' AS DateTime2), CAST(N'2021-08-11T14:24:44.4339255' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2212, 20, 82, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.4365983' AS DateTime2), CAST(N'2021-08-11T14:24:44.4365983' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2213, 20, 83, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.4387199' AS DateTime2), CAST(N'2021-08-11T14:24:44.4387199' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2214, 20, 84, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:44.4408102' AS DateTime2), CAST(N'2021-08-11T14:24:44.4408102' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2215, 20, 85, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.4423778' AS DateTime2), CAST(N'2021-08-11T14:24:44.4423778' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2216, 20, 86, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.4444596' AS DateTime2), CAST(N'2021-08-11T14:24:44.4444596' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2217, 20, 87, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.4465382' AS DateTime2), CAST(N'2021-08-11T14:24:44.4465382' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2218, 20, 88, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.4492363' AS DateTime2), CAST(N'2021-08-11T14:24:44.4492363' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2219, 20, 89, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.4513200' AS DateTime2), CAST(N'2021-08-11T14:24:44.4513200' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2220, 20, 90, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.4533852' AS DateTime2), CAST(N'2021-08-11T14:24:44.4533852' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2221, 20, 91, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.4556026' AS DateTime2), CAST(N'2021-08-11T14:24:44.4556026' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2222, 20, 92, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.4582492' AS DateTime2), CAST(N'2021-08-11T14:24:44.4582492' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2223, 20, 93, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.4609238' AS DateTime2), CAST(N'2021-08-11T14:24:44.4609238' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2224, 20, 94, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.4640412' AS DateTime2), CAST(N'2021-08-11T14:24:44.4640412' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2225, 20, 95, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.7511864' AS DateTime2), CAST(N'2021-08-11T14:24:44.7511864' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2226, 20, 96, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.7550366' AS DateTime2), CAST(N'2021-08-11T14:24:44.7550366' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2227, 20, 97, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.7571604' AS DateTime2), CAST(N'2021-08-11T14:24:44.7571604' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2228, 20, 98, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:44.7587527' AS DateTime2), CAST(N'2021-08-11T14:24:44.7587527' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2229, 20, 99, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:44.7608241' AS DateTime2), CAST(N'2021-08-11T14:42:12.1310028' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2230, 20, 100, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:44.7629326' AS DateTime2), CAST(N'2021-08-11T14:42:12.3449089' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2231, 20, 101, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:44.7657948' AS DateTime2), CAST(N'2021-08-11T14:42:12.5675007' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2232, 20, 102, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:44.7678985' AS DateTime2), CAST(N'2021-08-11T14:42:25.8715186' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2233, 20, 103, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:44.7695058' AS DateTime2), CAST(N'2021-08-11T14:42:26.0919912' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2234, 20, 104, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:44.7716160' AS DateTime2), CAST(N'2021-08-11T14:42:26.3107397' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2235, 20, 105, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:44.7737852' AS DateTime2), CAST(N'2021-08-11T14:42:26.5276470' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2236, 20, 106, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:44.7754892' AS DateTime2), CAST(N'2021-08-11T14:42:26.7455488' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2237, 20, 107, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:24:44.7786519' AS DateTime2), CAST(N'2021-08-11T14:42:31.9284133' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2238, 20, 108, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:24:44.7802903' AS DateTime2), CAST(N'2021-08-11T14:42:39.3481040' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2239, 20, 109, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:44.7823826' AS DateTime2), CAST(N'2021-08-11T14:42:39.6078649' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2240, 20, 110, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:24:45.0695128' AS DateTime2), CAST(N'2021-08-11T14:42:46.0872963' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2241, 20, 111, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.0733084' AS DateTime2), CAST(N'2021-08-11T14:42:46.3126452' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2242, 20, 112, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.0754777' AS DateTime2), CAST(N'2021-08-11T14:42:52.0050058' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2243, 20, 113, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.0771029' AS DateTime2), CAST(N'2021-08-11T14:42:52.2177469' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2244, 20, 114, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:24:45.0792507' AS DateTime2), CAST(N'2021-08-11T14:43:03.9472688' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2245, 20, 115, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.0813505' AS DateTime2), CAST(N'2021-08-11T14:43:04.1593207' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2246, 20, 116, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:24:45.0829649' AS DateTime2), CAST(N'2021-08-11T14:43:12.0681435' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2247, 20, 117, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.0850944' AS DateTime2), CAST(N'2021-08-11T14:43:12.3327918' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2248, 20, 118, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.0882733' AS DateTime2), CAST(N'2021-08-11T14:43:12.5474168' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2249, 20, 119, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.0899260' AS DateTime2), CAST(N'2021-08-11T14:42:57.0503146' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2250, 20, 120, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.0920319' AS DateTime2), CAST(N'2021-08-11T14:42:57.2611696' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2251, 20, 121, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.0947189' AS DateTime2), CAST(N'2021-08-11T14:42:57.4731448' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2252, 20, 122, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.0957847' AS DateTime2), CAST(N'2021-08-11T14:24:45.0957847' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2253, 20, 123, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.0980126' AS DateTime2), CAST(N'2021-08-11T14:24:45.0980126' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2254, 20, 124, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.1007041' AS DateTime2), CAST(N'2021-08-11T14:24:45.1007041' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2255, 20, 125, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.3831466' AS DateTime2), CAST(N'2021-08-11T14:24:45.3831466' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2256, 20, 126, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.3871495' AS DateTime2), CAST(N'2021-08-11T14:24:45.3871495' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2257, 20, 127, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.3898682' AS DateTime2), CAST(N'2021-08-11T14:24:45.3898682' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2258, 20, 128, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.3927346' AS DateTime2), CAST(N'2021-08-11T14:24:45.3927346' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2259, 20, 129, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.3948498' AS DateTime2), CAST(N'2021-08-11T14:24:45.3948498' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2260, 20, 130, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.3976920' AS DateTime2), CAST(N'2021-08-11T14:24:45.3976920' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2261, 20, 131, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.4003449' AS DateTime2), CAST(N'2021-08-11T14:24:45.4003449' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2262, 20, 132, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.4025147' AS DateTime2), CAST(N'2021-08-11T14:41:59.1277100' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2263, 20, 133, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.4052700' AS DateTime2), CAST(N'2021-08-11T14:41:59.3453572' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2264, 20, 134, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:45.4084726' AS DateTime2), CAST(N'2021-08-11T14:24:45.4084726' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2265, 20, 135, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.4111934' AS DateTime2), CAST(N'2021-08-11T14:24:45.4111934' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2266, 20, 137, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:45.4143553' AS DateTime2), CAST(N'2021-08-11T14:24:45.4143553' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2267, 20, 138, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.4170820' AS DateTime2), CAST(N'2021-08-11T14:24:45.4170820' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2268, 20, 145, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:45.4192524' AS DateTime2), CAST(N'2021-08-11T14:24:45.4192524' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2269, 20, 147, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:45.4229078' AS DateTime2), CAST(N'2021-08-11T14:24:45.4229078' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2270, 20, 148, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:45.7775996' AS DateTime2), CAST(N'2021-08-11T14:24:45.7775996' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2271, 20, 151, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:45.7802808' AS DateTime2), CAST(N'2021-08-11T14:24:45.7802808' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2272, 20, 152, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:45.7823826' AS DateTime2), CAST(N'2021-08-11T14:24:45.7823826' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2273, 20, 153, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.7851523' AS DateTime2), CAST(N'2021-08-11T14:42:15.6805053' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2274, 20, 154, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.7874018' AS DateTime2), CAST(N'2021-08-11T14:42:15.8964417' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2275, 20, 155, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.7890099' AS DateTime2), CAST(N'2021-08-11T14:24:45.7890099' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2276, 20, 156, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.7911732' AS DateTime2), CAST(N'2021-08-11T14:24:45.7911732' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2277, 20, 157, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:45.7938543' AS DateTime2), CAST(N'2021-08-11T14:24:45.7938543' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2278, 20, 158, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.7969854' AS DateTime2), CAST(N'2021-08-11T14:24:45.7969854' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2279, 20, 159, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:24:45.7992701' AS DateTime2), CAST(N'2021-08-11T14:24:45.7992701' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2280, 20, 160, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.8009308' AS DateTime2), CAST(N'2021-08-11T14:24:45.8009308' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2281, 20, 161, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:24:45.8036156' AS DateTime2), CAST(N'2021-08-11T14:24:45.8036156' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2282, 20, 162, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.8056905' AS DateTime2), CAST(N'2021-08-11T14:42:26.9592396' AS DateTime2), 2, 2, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2283, 20, 163, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.8077766' AS DateTime2), CAST(N'2021-08-11T14:42:57.6909517' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2284, 20, 164, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:45.8104231' AS DateTime2), CAST(N'2021-08-11T14:42:12.7851057' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2285, 20, 165, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:24:46.2334286' AS DateTime2), CAST(N'2021-08-11T14:42:16.1159393' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2286, 21, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9564959' AS DateTime2), CAST(N'2021-08-11T14:26:10.9564959' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2287, 21, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9603647' AS DateTime2), CAST(N'2021-08-11T14:26:10.9603647' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2288, 21, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9619887' AS DateTime2), CAST(N'2021-08-11T14:26:10.9619887' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2289, 21, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9652202' AS DateTime2), CAST(N'2021-08-11T14:26:10.9652202' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2290, 21, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9678848' AS DateTime2), CAST(N'2021-08-11T14:26:10.9678848' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2291, 21, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9710948' AS DateTime2), CAST(N'2021-08-11T14:26:10.9710948' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2292, 21, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9734280' AS DateTime2), CAST(N'2021-08-11T14:26:10.9734280' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2293, 21, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9768854' AS DateTime2), CAST(N'2021-08-11T14:26:10.9768854' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2294, 21, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9786036' AS DateTime2), CAST(N'2021-08-11T14:26:10.9796977' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2295, 21, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9818193' AS DateTime2), CAST(N'2021-08-11T14:26:10.9818193' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2296, 21, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9845573' AS DateTime2), CAST(N'2021-08-11T14:26:10.9845573' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2297, 21, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9867019' AS DateTime2), CAST(N'2021-08-11T14:26:10.9867019' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2298, 21, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9893814' AS DateTime2), CAST(N'2021-08-11T14:26:10.9893814' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2299, 21, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9914967' AS DateTime2), CAST(N'2021-08-11T14:26:10.9914967' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2300, 21, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:10.9947022' AS DateTime2), CAST(N'2021-08-11T14:26:10.9947022' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2301, 21, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.2992406' AS DateTime2), CAST(N'2021-08-11T14:26:11.2992406' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2302, 21, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3020044' AS DateTime2), CAST(N'2021-08-11T14:26:11.3020044' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2303, 21, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3041080' AS DateTime2), CAST(N'2021-08-11T14:26:11.3041080' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2304, 21, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3068794' AS DateTime2), CAST(N'2021-08-11T14:26:11.3068794' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2305, 21, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3090226' AS DateTime2), CAST(N'2021-08-11T14:26:11.3090226' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2306, 21, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3106696' AS DateTime2), CAST(N'2021-08-11T14:26:11.3106696' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2307, 21, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3127870' AS DateTime2), CAST(N'2021-08-11T14:26:11.3127870' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2308, 21, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3148896' AS DateTime2), CAST(N'2021-08-11T14:26:11.3148896' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2309, 21, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3175613' AS DateTime2), CAST(N'2021-08-11T14:26:11.3175613' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2310, 21, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3196488' AS DateTime2), CAST(N'2021-08-11T14:26:11.3196488' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2311, 21, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3217982' AS DateTime2), CAST(N'2021-08-11T14:26:11.3217982' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2312, 21, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3244721' AS DateTime2), CAST(N'2021-08-11T14:26:11.3244721' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2313, 21, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3265513' AS DateTime2), CAST(N'2021-08-11T14:26:11.3265513' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2314, 21, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3292478' AS DateTime2), CAST(N'2021-08-11T14:26:11.3292478' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2315, 21, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.3323771' AS DateTime2), CAST(N'2021-08-11T14:26:11.3323771' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2316, 21, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6506643' AS DateTime2), CAST(N'2021-08-11T14:26:11.6506643' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2317, 21, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6538243' AS DateTime2), CAST(N'2021-08-11T14:26:11.6538243' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2318, 21, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6565457' AS DateTime2), CAST(N'2021-08-11T14:26:11.6565457' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2319, 21, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6587282' AS DateTime2), CAST(N'2021-08-11T14:26:11.6587282' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2320, 21, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6603454' AS DateTime2), CAST(N'2021-08-11T14:26:11.6603454' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2321, 21, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6624967' AS DateTime2), CAST(N'2021-08-11T14:26:11.6624967' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2322, 21, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6662092' AS DateTime2), CAST(N'2021-08-11T14:26:11.6662092' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2323, 21, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6683578' AS DateTime2), CAST(N'2021-08-11T14:26:11.6683578' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2324, 21, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6711858' AS DateTime2), CAST(N'2021-08-11T14:26:11.6711858' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2325, 21, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6732730' AS DateTime2), CAST(N'2021-08-11T14:26:11.6732730' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2326, 21, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6750123' AS DateTime2), CAST(N'2021-08-11T14:26:11.6750123' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2327, 21, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6778274' AS DateTime2), CAST(N'2021-08-11T14:26:11.6778274' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2328, 21, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6799112' AS DateTime2), CAST(N'2021-08-11T14:26:11.6799112' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2329, 21, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6820076' AS DateTime2), CAST(N'2021-08-11T14:26:11.6820076' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2330, 21, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:11.6847233' AS DateTime2), CAST(N'2021-08-11T14:26:11.6847233' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2331, 21, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.0512340' AS DateTime2), CAST(N'2021-08-11T14:26:12.0512340' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2332, 21, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.0539119' AS DateTime2), CAST(N'2021-08-11T14:26:12.0539119' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2333, 21, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.0559962' AS DateTime2), CAST(N'2021-08-11T14:26:12.0559962' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2334, 21, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.0586177' AS DateTime2), CAST(N'2021-08-11T14:26:12.0586177' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2335, 21, 50, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.0607136' AS DateTime2), CAST(N'2021-08-11T14:26:12.0607136' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2336, 21, 51, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.0628392' AS DateTime2), CAST(N'2021-08-11T14:26:12.0628392' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2337, 21, 52, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.0644676' AS DateTime2), CAST(N'2021-08-11T14:26:12.0644676' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2338, 21, 53, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:12.0665773' AS DateTime2), CAST(N'2021-08-11T14:26:12.0665773' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2339, 21, 54, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.0687177' AS DateTime2), CAST(N'2021-08-11T14:26:12.0687177' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2340, 21, 55, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:12.0714813' AS DateTime2), CAST(N'2021-08-11T14:26:12.0714813' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2341, 21, 56, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.0736321' AS DateTime2), CAST(N'2021-08-11T14:26:12.0736321' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2342, 21, 57, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:12.0752724' AS DateTime2), CAST(N'2021-08-11T14:26:12.0752724' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2343, 21, 58, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.0784752' AS DateTime2), CAST(N'2021-08-11T14:26:12.0784752' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2344, 21, 59, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.0801648' AS DateTime2), CAST(N'2021-08-11T14:26:12.0801648' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2345, 21, 60, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.0833429' AS DateTime2), CAST(N'2021-08-11T14:26:12.0833429' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2346, 21, 61, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.3695093' AS DateTime2), CAST(N'2021-08-11T14:26:12.3695093' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2347, 21, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.3732831' AS DateTime2), CAST(N'2021-08-11T14:26:12.3732831' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2348, 21, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.3754617' AS DateTime2), CAST(N'2021-08-11T14:26:12.3754617' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2349, 21, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.3770687' AS DateTime2), CAST(N'2021-08-11T14:26:12.3770687' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2350, 21, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.3791686' AS DateTime2), CAST(N'2021-08-11T14:26:12.3791686' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2351, 21, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.3812748' AS DateTime2), CAST(N'2021-08-11T14:26:12.3812748' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2352, 21, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.3828954' AS DateTime2), CAST(N'2021-08-11T14:26:12.3828954' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2353, 21, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.3850296' AS DateTime2), CAST(N'2021-08-11T14:26:12.3850296' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2354, 21, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.3876866' AS DateTime2), CAST(N'2021-08-11T14:26:12.3876866' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2355, 21, 74, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.3908455' AS DateTime2), CAST(N'2021-08-11T14:26:12.3908455' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2356, 21, 75, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.3919295' AS DateTime2), CAST(N'2021-08-11T14:26:12.3919295' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2357, 21, 76, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.3947244' AS DateTime2), CAST(N'2021-08-11T14:26:12.3947244' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2358, 21, 77, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.3968355' AS DateTime2), CAST(N'2021-08-11T14:26:12.3968355' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2359, 21, 78, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:12.3995201' AS DateTime2), CAST(N'2021-08-11T14:26:12.3995201' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2360, 21, 79, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:12.4016979' AS DateTime2), CAST(N'2021-08-11T14:26:12.4016979' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2361, 21, 80, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:12.6943312' AS DateTime2), CAST(N'2021-08-11T14:26:12.6943312' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2362, 21, 81, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:12.6975049' AS DateTime2), CAST(N'2021-08-11T14:26:12.6975049' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2363, 21, 82, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:26:12.6995870' AS DateTime2), CAST(N'2021-08-11T14:43:37.4808241' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2364, 21, 83, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:12.7022175' AS DateTime2), CAST(N'2021-08-11T14:43:37.6920122' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2365, 21, 84, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:26:12.7032510' AS DateTime2), CAST(N'2021-08-11T14:43:42.9942842' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2366, 21, 85, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:12.7101744' AS DateTime2), CAST(N'2021-08-11T14:43:43.2251330' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2367, 21, 86, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:12.7122841' AS DateTime2), CAST(N'2021-08-11T14:43:46.0714653' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2368, 21, 87, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:12.7149948' AS DateTime2), CAST(N'2021-08-11T14:43:46.2855147' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2369, 21, 88, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:12.7171136' AS DateTime2), CAST(N'2021-08-11T14:43:46.4974227' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2370, 21, 89, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:12.7197708' AS DateTime2), CAST(N'2021-08-11T14:43:49.1503076' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2371, 21, 90, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:12.7218792' AS DateTime2), CAST(N'2021-08-11T14:43:49.3721720' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2372, 21, 91, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:12.7239630' AS DateTime2), CAST(N'2021-08-11T14:43:54.1006590' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2373, 21, 92, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:12.7267057' AS DateTime2), CAST(N'2021-08-11T14:43:54.3183785' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2374, 21, 93, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:12.7288213' AS DateTime2), CAST(N'2021-08-11T14:43:54.5360753' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2375, 21, 94, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:12.7315117' AS DateTime2), CAST(N'2021-08-11T14:43:59.0702032' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2376, 21, 95, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:13.0286582' AS DateTime2), CAST(N'2021-08-11T14:43:59.2896230' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2377, 21, 96, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:13.0313624' AS DateTime2), CAST(N'2021-08-11T14:44:07.1546274' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2378, 21, 97, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:13.0335016' AS DateTime2), CAST(N'2021-08-11T14:44:07.3752952' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2379, 21, 98, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:13.0351609' AS DateTime2), CAST(N'2021-08-11T14:44:07.6576096' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2380, 21, 99, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.0372211' AS DateTime2), CAST(N'2021-08-11T14:26:13.0372211' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2381, 21, 100, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.0393390' AS DateTime2), CAST(N'2021-08-11T14:26:13.0393390' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2382, 21, 101, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.0414032' AS DateTime2), CAST(N'2021-08-11T14:26:13.0414032' AS DateTime2), 2, 2, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2383, 21, 102, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.0430280' AS DateTime2), CAST(N'2021-08-11T14:26:13.0430280' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2384, 21, 103, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.0452039' AS DateTime2), CAST(N'2021-08-11T14:26:13.0452039' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2385, 21, 104, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.0468296' AS DateTime2), CAST(N'2021-08-11T14:26:13.0468296' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2386, 21, 105, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.0489284' AS DateTime2), CAST(N'2021-08-11T14:26:13.0489284' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2387, 21, 106, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.0510669' AS DateTime2), CAST(N'2021-08-11T14:26:13.0510669' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2388, 21, 107, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:13.0538175' AS DateTime2), CAST(N'2021-08-11T14:26:13.0538175' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2389, 21, 108, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:13.0559519' AS DateTime2), CAST(N'2021-08-11T14:26:13.0559519' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2390, 21, 109, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.0576096' AS DateTime2), CAST(N'2021-08-11T14:26:13.0576096' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2391, 21, 110, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:13.3498609' AS DateTime2), CAST(N'2021-08-11T14:26:13.3498609' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2392, 21, 111, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.3604491' AS DateTime2), CAST(N'2021-08-11T14:26:13.3604491' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2393, 21, 112, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.3627085' AS DateTime2), CAST(N'2021-08-11T14:26:13.3627085' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2394, 21, 113, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.3643636' AS DateTime2), CAST(N'2021-08-11T14:26:13.3643636' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2395, 21, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:13.3675647' AS DateTime2), CAST(N'2021-08-11T14:26:13.3675647' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2396, 21, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.3702779' AS DateTime2), CAST(N'2021-08-11T14:26:13.3702779' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2397, 21, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:13.3723963' AS DateTime2), CAST(N'2021-08-11T14:26:13.3723963' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2398, 21, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.3750966' AS DateTime2), CAST(N'2021-08-11T14:26:13.3750966' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2399, 21, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.3772091' AS DateTime2), CAST(N'2021-08-11T14:26:13.3772091' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2400, 21, 119, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.3792959' AS DateTime2), CAST(N'2021-08-11T14:26:13.3792959' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2401, 21, 120, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.3809146' AS DateTime2), CAST(N'2021-08-11T14:26:13.3809146' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2402, 21, 121, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.3830055' AS DateTime2), CAST(N'2021-08-11T14:26:13.3830055' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2403, 21, 122, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.3868458' AS DateTime2), CAST(N'2021-08-11T14:26:13.3868458' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2404, 21, 123, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.3889803' AS DateTime2), CAST(N'2021-08-11T14:26:13.3889803' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2405, 21, 124, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.3905609' AS DateTime2), CAST(N'2021-08-11T14:26:13.3905609' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2406, 21, 125, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.7140579' AS DateTime2), CAST(N'2021-08-11T14:26:13.7140579' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2407, 21, 126, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.7178354' AS DateTime2), CAST(N'2021-08-11T14:26:13.7178354' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2408, 21, 127, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.7210058' AS DateTime2), CAST(N'2021-08-11T14:26:13.7210058' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2409, 21, 128, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.7236711' AS DateTime2), CAST(N'2021-08-11T14:26:13.7236711' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2410, 21, 129, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.7258217' AS DateTime2), CAST(N'2021-08-11T14:26:13.7258217' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2411, 21, 130, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.7276192' AS DateTime2), CAST(N'2021-08-11T14:26:13.7276192' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2412, 21, 131, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.7296956' AS DateTime2), CAST(N'2021-08-11T14:26:13.7296956' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2413, 21, 132, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.7318013' AS DateTime2), CAST(N'2021-08-11T14:42:02.2885052' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2414, 21, 133, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.7334413' AS DateTime2), CAST(N'2021-08-11T14:42:02.5033586' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2415, 21, 134, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:13.7355653' AS DateTime2), CAST(N'2021-08-11T14:26:13.7355653' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2416, 21, 135, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.7382983' AS DateTime2), CAST(N'2021-08-11T14:26:13.7382983' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2417, 21, 137, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:13.7403752' AS DateTime2), CAST(N'2021-08-11T14:26:13.7403752' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2418, 21, 138, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:13.7425148' AS DateTime2), CAST(N'2021-08-11T14:26:13.7425148' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2419, 21, 145, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:13.7463386' AS DateTime2), CAST(N'2021-08-11T14:26:13.7463386' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2420, 21, 147, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:13.7491113' AS DateTime2), CAST(N'2021-08-11T14:26:13.7491113' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2421, 21, 148, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:14.0412441' AS DateTime2), CAST(N'2021-08-11T14:26:14.0412441' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2422, 21, 151, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:14.0450575' AS DateTime2), CAST(N'2021-08-11T14:26:14.0450575' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2423, 21, 152, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:14.0471444' AS DateTime2), CAST(N'2021-08-11T14:26:14.0471444' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2424, 21, 153, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:14.0487927' AS DateTime2), CAST(N'2021-08-11T14:26:14.0487927' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2425, 21, 154, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:14.0509671' AS DateTime2), CAST(N'2021-08-11T14:26:14.0509671' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2426, 21, 155, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:14.0536030' AS DateTime2), CAST(N'2021-08-11T14:43:54.7507079' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2427, 21, 156, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:14.0558473' AS DateTime2), CAST(N'2021-08-11T14:26:14.0558473' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2428, 21, 157, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:14.0579455' AS DateTime2), CAST(N'2021-08-11T14:26:14.0579455' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2429, 21, 158, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:14.0595774' AS DateTime2), CAST(N'2021-08-11T14:26:14.0595774' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2430, 21, 159, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:26:14.0616800' AS DateTime2), CAST(N'2021-08-11T14:26:14.0616800' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2431, 21, 160, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:14.0643806' AS DateTime2), CAST(N'2021-08-11T14:44:01.9635700' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2432, 21, 161, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:26:14.0664791' AS DateTime2), CAST(N'2021-08-11T14:44:02.1840107' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2433, 21, 162, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:14.0685895' AS DateTime2), CAST(N'2021-08-11T14:26:14.0685895' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2434, 21, 163, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:14.0702326' AS DateTime2), CAST(N'2021-08-11T14:26:14.0702326' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2435, 21, 164, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:14.0723230' AS DateTime2), CAST(N'2021-08-11T14:26:14.0723230' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2436, 21, 165, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:26:14.2802234' AS DateTime2), CAST(N'2021-08-11T14:26:14.2802234' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2437, 22, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2219119' AS DateTime2), CAST(N'2021-08-11T14:27:01.2219119' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2438, 22, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2308683' AS DateTime2), CAST(N'2021-08-11T14:27:01.2308683' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2439, 22, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2335893' AS DateTime2), CAST(N'2021-08-11T14:27:01.2335893' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2440, 22, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2356826' AS DateTime2), CAST(N'2021-08-11T14:27:01.2356826' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2441, 22, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2394315' AS DateTime2), CAST(N'2021-08-11T14:27:01.2394315' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2442, 22, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2415229' AS DateTime2), CAST(N'2021-08-11T14:27:01.2415229' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2443, 22, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2431115' AS DateTime2), CAST(N'2021-08-11T14:27:01.2431115' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2444, 22, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2453873' AS DateTime2), CAST(N'2021-08-11T14:27:01.2453873' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2445, 22, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2481199' AS DateTime2), CAST(N'2021-08-11T14:27:01.2481199' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2446, 22, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2514440' AS DateTime2), CAST(N'2021-08-11T14:27:01.2514440' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2447, 22, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2541026' AS DateTime2), CAST(N'2021-08-11T14:27:01.2541026' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2448, 22, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2569719' AS DateTime2), CAST(N'2021-08-11T14:27:01.2569719' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2449, 22, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2590545' AS DateTime2), CAST(N'2021-08-11T14:27:01.2590545' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2450, 22, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2617538' AS DateTime2), CAST(N'2021-08-11T14:27:01.2617538' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2451, 22, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.2649135' AS DateTime2), CAST(N'2021-08-11T14:27:01.2649135' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2452, 22, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.5586557' AS DateTime2), CAST(N'2021-08-11T14:27:01.5586557' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2453, 22, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.5637417' AS DateTime2), CAST(N'2021-08-11T14:27:01.5637417' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2454, 22, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.5712737' AS DateTime2), CAST(N'2021-08-11T14:27:01.5712737' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2455, 22, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.5772949' AS DateTime2), CAST(N'2021-08-11T14:27:01.5772949' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2456, 22, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.5810842' AS DateTime2), CAST(N'2021-08-11T14:27:01.5810842' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2457, 22, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.5833144' AS DateTime2), CAST(N'2021-08-11T14:27:01.5833144' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2458, 22, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.5871887' AS DateTime2), CAST(N'2021-08-11T14:27:01.5871887' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2459, 22, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.5909936' AS DateTime2), CAST(N'2021-08-11T14:27:01.5909936' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2460, 22, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.5943166' AS DateTime2), CAST(N'2021-08-11T14:27:01.5943166' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2461, 22, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.5971161' AS DateTime2), CAST(N'2021-08-11T14:27:01.5971161' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2462, 22, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.5998517' AS DateTime2), CAST(N'2021-08-11T14:27:01.5998517' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2463, 22, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.6020050' AS DateTime2), CAST(N'2021-08-11T14:27:01.6020050' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2464, 22, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.6056046' AS DateTime2), CAST(N'2021-08-11T14:27:01.6056046' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2465, 22, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.6087669' AS DateTime2), CAST(N'2021-08-11T14:27:01.6087669' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2466, 22, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.6115222' AS DateTime2), CAST(N'2021-08-11T14:27:01.6115222' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2467, 22, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9318511' AS DateTime2), CAST(N'2021-08-11T14:27:01.9318511' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2468, 22, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9355587' AS DateTime2), CAST(N'2021-08-11T14:27:01.9355587' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2469, 22, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9376956' AS DateTime2), CAST(N'2021-08-11T14:27:01.9376956' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2470, 22, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9387579' AS DateTime2), CAST(N'2021-08-11T14:27:01.9387579' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2471, 22, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9414621' AS DateTime2), CAST(N'2021-08-11T14:27:01.9414621' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2472, 22, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9425338' AS DateTime2), CAST(N'2021-08-11T14:27:01.9425338' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2473, 22, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9446675' AS DateTime2), CAST(N'2021-08-11T14:27:01.9446675' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2474, 22, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9473614' AS DateTime2), CAST(N'2021-08-11T14:27:01.9473614' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2475, 22, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9494724' AS DateTime2), CAST(N'2021-08-11T14:27:01.9494724' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2476, 22, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9515597' AS DateTime2), CAST(N'2021-08-11T14:27:01.9515597' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2477, 22, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9531944' AS DateTime2), CAST(N'2021-08-11T14:27:01.9531944' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2478, 22, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9553155' AS DateTime2), CAST(N'2021-08-11T14:27:01.9553155' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2479, 22, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9574322' AS DateTime2), CAST(N'2021-08-11T14:27:01.9574322' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2480, 22, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9590747' AS DateTime2), CAST(N'2021-08-11T14:27:01.9590747' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2481, 22, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:01.9611826' AS DateTime2), CAST(N'2021-08-11T14:27:01.9611826' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2482, 22, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.3185566' AS DateTime2), CAST(N'2021-08-11T14:27:02.3185566' AS DateTime2), 2, 2, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2483, 22, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.3222675' AS DateTime2), CAST(N'2021-08-11T14:27:02.3222675' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2484, 22, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.3255624' AS DateTime2), CAST(N'2021-08-11T14:27:02.3255624' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2485, 22, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.3282858' AS DateTime2), CAST(N'2021-08-11T14:27:02.3282858' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2486, 22, 50, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.3303424' AS DateTime2), CAST(N'2021-08-11T14:27:02.3303424' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2487, 22, 51, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.3319645' AS DateTime2), CAST(N'2021-08-11T14:27:02.3319645' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2488, 22, 52, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.3340856' AS DateTime2), CAST(N'2021-08-11T14:27:02.3340856' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2489, 22, 53, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.3373376' AS DateTime2), CAST(N'2021-08-11T14:27:02.3373376' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2490, 22, 54, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.3400016' AS DateTime2), CAST(N'2021-08-11T14:27:02.3400016' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2491, 22, 55, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.3421153' AS DateTime2), CAST(N'2021-08-11T14:27:02.3421153' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2492, 22, 56, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.3437373' AS DateTime2), CAST(N'2021-08-11T14:27:02.3437373' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2493, 22, 57, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.3458912' AS DateTime2), CAST(N'2021-08-11T14:27:02.3458912' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2494, 22, 58, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.3496098' AS DateTime2), CAST(N'2021-08-11T14:27:02.3496098' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2495, 22, 59, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.3528047' AS DateTime2), CAST(N'2021-08-11T14:27:02.3528047' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2496, 22, 60, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.3555141' AS DateTime2), CAST(N'2021-08-11T14:27:02.3555141' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2497, 22, 61, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.6339816' AS DateTime2), CAST(N'2021-08-11T14:27:02.6339816' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2498, 22, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.6377041' AS DateTime2), CAST(N'2021-08-11T14:27:02.6377041' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2499, 22, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.6397801' AS DateTime2), CAST(N'2021-08-11T14:27:02.6397801' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2500, 22, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.6429630' AS DateTime2), CAST(N'2021-08-11T14:27:02.6429630' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2501, 22, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.6457302' AS DateTime2), CAST(N'2021-08-11T14:27:02.6457302' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2502, 22, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.6484120' AS DateTime2), CAST(N'2021-08-11T14:27:02.6484120' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2503, 22, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.6505385' AS DateTime2), CAST(N'2021-08-11T14:27:02.6505385' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2504, 22, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.6526315' AS DateTime2), CAST(N'2021-08-11T14:27:02.6526315' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2505, 22, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.6553280' AS DateTime2), CAST(N'2021-08-11T14:27:02.6553280' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2506, 22, 74, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.6575379' AS DateTime2), CAST(N'2021-08-11T14:27:02.6575379' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2507, 22, 75, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.6601827' AS DateTime2), CAST(N'2021-08-11T14:27:02.6601827' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2508, 22, 76, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.6622935' AS DateTime2), CAST(N'2021-08-11T14:27:02.6622935' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2509, 22, 77, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.6643641' AS DateTime2), CAST(N'2021-08-11T14:27:02.6643641' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2510, 22, 78, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.6670264' AS DateTime2), CAST(N'2021-08-11T14:27:02.6670264' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2511, 22, 79, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.6691642' AS DateTime2), CAST(N'2021-08-11T14:27:02.6691642' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2512, 22, 80, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.9484628' AS DateTime2), CAST(N'2021-08-11T14:27:02.9484628' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2513, 22, 81, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.9511291' AS DateTime2), CAST(N'2021-08-11T14:27:02.9511291' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2514, 22, 82, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.9532491' AS DateTime2), CAST(N'2021-08-11T14:27:02.9532491' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2515, 22, 83, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.9554010' AS DateTime2), CAST(N'2021-08-11T14:27:02.9554010' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2516, 22, 84, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:02.9570367' AS DateTime2), CAST(N'2021-08-11T14:27:02.9570367' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2517, 22, 85, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.9602631' AS DateTime2), CAST(N'2021-08-11T14:27:02.9602631' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2518, 22, 86, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.9618742' AS DateTime2), CAST(N'2021-08-11T14:27:02.9618742' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2519, 22, 87, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.9640355' AS DateTime2), CAST(N'2021-08-11T14:27:02.9640355' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2520, 22, 88, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.9668297' AS DateTime2), CAST(N'2021-08-11T14:27:02.9668297' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2521, 22, 89, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.9689392' AS DateTime2), CAST(N'2021-08-11T14:27:02.9689392' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2522, 22, 90, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.9716857' AS DateTime2), CAST(N'2021-08-11T14:27:02.9716857' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2523, 22, 91, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.9738205' AS DateTime2), CAST(N'2021-08-11T14:27:02.9738205' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2524, 22, 92, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.9765264' AS DateTime2), CAST(N'2021-08-11T14:27:02.9765264' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2525, 22, 93, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.9786646' AS DateTime2), CAST(N'2021-08-11T14:27:02.9786646' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2526, 22, 94, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:02.9807510' AS DateTime2), CAST(N'2021-08-11T14:27:02.9807510' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2527, 22, 95, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.2655585' AS DateTime2), CAST(N'2021-08-11T14:27:03.2655585' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2528, 22, 96, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.2687445' AS DateTime2), CAST(N'2021-08-11T14:27:03.2687445' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2529, 22, 97, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.2714061' AS DateTime2), CAST(N'2021-08-11T14:27:03.2714061' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2530, 22, 98, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.2735798' AS DateTime2), CAST(N'2021-08-11T14:27:03.2735798' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2531, 22, 99, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.2763543' AS DateTime2), CAST(N'2021-08-11T14:27:03.2763543' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2532, 22, 100, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.2785440' AS DateTime2), CAST(N'2021-08-11T14:27:03.2785440' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2533, 22, 101, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.2811926' AS DateTime2), CAST(N'2021-08-11T14:27:03.2811926' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2534, 22, 102, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.2833485' AS DateTime2), CAST(N'2021-08-11T14:27:03.2833485' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2535, 22, 103, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.2854303' AS DateTime2), CAST(N'2021-08-11T14:27:03.2854303' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2536, 22, 104, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.2882445' AS DateTime2), CAST(N'2021-08-11T14:27:03.2882445' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2537, 22, 105, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.2909164' AS DateTime2), CAST(N'2021-08-11T14:27:03.2909164' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2538, 22, 106, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.2930287' AS DateTime2), CAST(N'2021-08-11T14:27:03.2930287' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2539, 22, 107, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:03.2951101' AS DateTime2), CAST(N'2021-08-11T14:27:03.2951101' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2540, 22, 108, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:03.2971897' AS DateTime2), CAST(N'2021-08-11T14:27:03.2971897' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2541, 22, 109, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.2987991' AS DateTime2), CAST(N'2021-08-11T14:27:03.2987991' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2542, 22, 110, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:03.5888464' AS DateTime2), CAST(N'2021-08-11T14:27:03.5888464' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2543, 22, 111, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.5930042' AS DateTime2), CAST(N'2021-08-11T14:27:03.5930042' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2544, 22, 112, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.5957919' AS DateTime2), CAST(N'2021-08-11T14:27:03.5957919' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2545, 22, 113, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.5978932' AS DateTime2), CAST(N'2021-08-11T14:27:03.5978932' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2546, 22, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:03.5996709' AS DateTime2), CAST(N'2021-08-11T14:27:03.5996709' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2547, 22, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.6007374' AS DateTime2), CAST(N'2021-08-11T14:27:03.6007374' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2548, 22, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:03.6033925' AS DateTime2), CAST(N'2021-08-11T14:27:03.6033925' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2549, 22, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.6054694' AS DateTime2), CAST(N'2021-08-11T14:27:03.6054694' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2550, 22, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.6076039' AS DateTime2), CAST(N'2021-08-11T14:27:03.6076039' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2551, 22, 119, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.6097085' AS DateTime2), CAST(N'2021-08-11T14:27:03.6097085' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2552, 22, 120, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.6113535' AS DateTime2), CAST(N'2021-08-11T14:27:03.6113535' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2553, 22, 121, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.6135185' AS DateTime2), CAST(N'2021-08-11T14:27:03.6135185' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2554, 22, 122, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:27:03.6165264' AS DateTime2), CAST(N'2021-08-11T14:44:51.1821047' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2555, 22, 123, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:27:03.6203723' AS DateTime2), CAST(N'2021-08-11T14:44:51.3971379' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2556, 22, 124, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:27:03.6219938' AS DateTime2), CAST(N'2021-08-11T14:44:54.5940895' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2557, 22, 125, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:27:03.9081016' AS DateTime2), CAST(N'2021-08-11T14:44:54.8091933' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2558, 22, 126, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:27:03.9112924' AS DateTime2), CAST(N'2021-08-11T14:44:57.9502855' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2559, 22, 127, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:27:03.9139711' AS DateTime2), CAST(N'2021-08-11T14:44:58.1691737' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2560, 22, 128, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:27:03.9160884' AS DateTime2), CAST(N'2021-08-11T14:45:01.5479013' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2561, 22, 129, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:27:03.9192607' AS DateTime2), CAST(N'2021-08-11T14:45:01.8252675' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2562, 22, 130, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:27:03.9208489' AS DateTime2), CAST(N'2021-08-11T14:45:09.7732989' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2563, 22, 131, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:27:03.9240465' AS DateTime2), CAST(N'2021-08-11T14:45:09.9890021' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2564, 22, 132, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:27:03.9256463' AS DateTime2), CAST(N'2021-08-11T14:45:05.3184679' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2565, 22, 133, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:27:03.9287809' AS DateTime2), CAST(N'2021-08-11T14:45:05.5312628' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2566, 22, 134, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-08-11T14:27:03.9319064' AS DateTime2), CAST(N'2021-08-11T14:44:48.5376313' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2567, 22, 135, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:27:03.9335642' AS DateTime2), CAST(N'2021-08-11T14:44:48.7605017' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2568, 22, 137, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:03.9367344' AS DateTime2), CAST(N'2021-08-11T14:27:03.9367344' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2569, 22, 138, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:03.9384104' AS DateTime2), CAST(N'2021-08-11T14:27:03.9384104' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2570, 22, 145, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:03.9416295' AS DateTime2), CAST(N'2021-08-11T14:27:03.9416295' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2571, 22, 147, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:03.9442745' AS DateTime2), CAST(N'2021-08-11T14:27:03.9442745' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2572, 22, 148, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:04.2393892' AS DateTime2), CAST(N'2021-08-11T14:27:04.2393892' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2573, 22, 151, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:04.2432039' AS DateTime2), CAST(N'2021-08-11T14:27:04.2432039' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2574, 22, 152, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:04.2453389' AS DateTime2), CAST(N'2021-08-11T14:27:04.2453389' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2575, 22, 153, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:04.2480885' AS DateTime2), CAST(N'2021-08-11T14:27:04.2480885' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2576, 22, 154, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:04.2491527' AS DateTime2), CAST(N'2021-08-11T14:27:04.2491527' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2577, 22, 155, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:04.2518525' AS DateTime2), CAST(N'2021-08-11T14:27:04.2518525' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2578, 22, 156, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:04.2541486' AS DateTime2), CAST(N'2021-08-11T14:27:04.2541486' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2579, 22, 157, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:04.2557551' AS DateTime2), CAST(N'2021-08-11T14:27:04.2557551' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2580, 22, 158, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:04.2578250' AS DateTime2), CAST(N'2021-08-11T14:27:04.2578250' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2581, 22, 159, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-08-11T14:27:04.2599437' AS DateTime2), CAST(N'2021-08-11T14:27:04.2599437' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2582, 22, 160, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:04.2626901' AS DateTime2), CAST(N'2021-08-11T14:27:04.2626901' AS DateTime2), 2, 2, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2583, 22, 161, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:04.2648328' AS DateTime2), CAST(N'2021-08-11T14:27:04.2648328' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2584, 22, 162, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:04.2664698' AS DateTime2), CAST(N'2021-08-11T14:27:04.2664698' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2585, 22, 163, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:04.2685942' AS DateTime2), CAST(N'2021-08-11T14:27:04.2685942' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2586, 22, 164, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:04.2718112' AS DateTime2), CAST(N'2021-08-11T14:27:04.2718112' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2587, 22, 165, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:27:04.4826510' AS DateTime2), CAST(N'2021-08-11T14:27:04.4826510' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2588, 19, 166, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.5830900' AS DateTime2), CAST(N'2021-08-11T14:31:25.9274182' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2589, 20, 166, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:23:51.5830900' AS DateTime2), CAST(N'2021-08-11T14:41:59.5583614' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2590, 21, 166, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-08-11T14:23:51.5830900' AS DateTime2), CAST(N'2021-08-11T14:42:02.7094520' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2591, 22, 166, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-08-11T14:23:51.5830900' AS DateTime2), CAST(N'2021-08-11T14:45:05.7459717' AS DateTime2), 2, 2, 1)
SET IDENTITY_INSERT [dbo].[groupObject] OFF
GO
SET IDENTITY_INSERT [dbo].[groups] ON 

INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (19, N'إداري', N'', CAST(N'2021-08-11T14:23:42.8562724' AS DateTime2), CAST(N'2021-08-11T14:23:42.8562724' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (20, N'مبيعات/مشتريات', N'', CAST(N'2021-08-11T14:24:41.1322381' AS DateTime2), CAST(N'2021-08-11T14:43:27.4932460' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (21, N'تخزين', N'', CAST(N'2021-08-11T14:26:10.6478717' AS DateTime2), CAST(N'2021-08-11T14:26:10.6478717' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (22, N'محاسبة', N'', CAST(N'2021-08-11T14:27:00.9336134' AS DateTime2), CAST(N'2021-08-11T14:27:00.9336134' AS DateTime2), 2, 2, 1)
SET IDENTITY_INSERT [dbo].[groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventory] ON 

INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (1, N'in-000001', CAST(N'2021-08-16T13:00:56.2676421' AS DateTime2), CAST(N'2021-08-16T13:01:21.8493189' AS DateTime2), 2, 2, NULL, NULL, N'a', 2, 2, NULL)
INSERT [dbo].[Inventory] ([inventoryId], [num], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [inventoryType], [branchId], [posId], [mainInventoryId]) VALUES (2, N'in-000002', CAST(N'2021-08-16T13:01:36.7604407' AS DateTime2), CAST(N'2021-08-16T13:01:46.1134487' AS DateTime2), 2, 2, NULL, NULL, N'n', 2, 2, NULL)
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
SET IDENTITY_INSERT [dbo].[inventoryItemLocation] ON 

INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause], [isFalls], [fallCause]) VALUES (1, 0, 97, 0, 99, 1, 1, CAST(N'2021-08-16T13:00:56.4012845' AS DateTime2), CAST(N'2021-08-16T13:01:21.8792071' AS DateTime2), NULL, 2, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause], [isFalls], [fallCause]) VALUES (2, 0, 49, 1, 50, 3, 1, CAST(N'2021-08-16T13:00:56.4062713' AS DateTime2), CAST(N'2021-08-16T13:01:21.8792071' AS DateTime2), NULL, 2, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause], [isFalls], [fallCause]) VALUES (3, 0, 97, 0, 99, 1, 2, CAST(N'2021-08-16T13:01:36.7793900' AS DateTime2), CAST(N'2021-08-16T13:01:46.1732901' AS DateTime2), NULL, 2, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[inventoryItemLocation] ([id], [isDestroyed], [amount], [amountDestroyed], [realAmount], [itemLocationId], [inventoryId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [notes], [cause], [isFalls], [fallCause]) VALUES (4, 1, 49, 1, 50, 3, 2, CAST(N'2021-08-16T13:01:36.7793900' AS DateTime2), CAST(N'2021-08-16T13:02:09.4411153' AS DateTime2), NULL, 2, NULL, N'', N'انتهاء الصلاحية', 0, NULL)
SET IDENTITY_INSERT [dbo].[inventoryItemLocation] OFF
GO
SET IDENTITY_INSERT [dbo].[invoices] ON 

INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId]) VALUES (1, N'pi-000001', 1, 2, N'p', N'-1', NULL, CAST(10000.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), CAST(10000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(N'2021-08-31' AS Date), CAST(N'2021-08-15T13:43:03.1607215' AS DateTime2), CAST(N'2021-08-15T13:43:14.2321683' AS DateTime2), 2, NULL, NULL, CAST(N'13:43:03.1607215' AS Time), N'', N'01000', NULL, 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId]) VALUES (2, N'si-000001', NULL, 2, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(100000.00 AS Decimal(20, 2)), CAST(105000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(105000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-15T13:43:32.6060407' AS DateTime2), CAST(N'2021-08-15T13:43:32.6060407' AS DateTime2), 2, NULL, NULL, CAST(N'13:43:32.6060407' AS Time), N'', NULL, NULL, NULL, 2, CAST(5.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId]) VALUES (3, N'pi-000002', 4, 2, N'p', N'-1', NULL, CAST(25000.00 AS Decimal(20, 2)), CAST(26250.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(26250.00 AS Decimal(20, 2)), CAST(N'2021-08-31' AS Date), CAST(N'2021-08-16T13:00:41.9207294' AS DateTime2), CAST(N'2021-08-16T13:00:52.0000443' AS DateTime2), 2, NULL, NULL, CAST(N'13:00:41.9207294' AS Time), N'', N'00000', NULL, 2, 2, CAST(5.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId]) VALUES (4, N'ds-000001', NULL, 2, N'd', NULL, NULL, CAST(500.00 AS Decimal(20, 2)), CAST(500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-16T13:02:09.3503574' AS DateTime2), CAST(N'2021-08-16T13:02:09.3503574' AS DateTime2), 2, NULL, NULL, CAST(N'13:02:09.3503574' AS Time), N'', NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId]) VALUES (5, N'si-000002', 10, 9, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(20000.00 AS Decimal(20, 2)), CAST(21000.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(21000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-16T19:10:37.0997105' AS DateTime2), CAST(N'2021-08-16T19:10:37.0997105' AS DateTime2), 9, NULL, NULL, CAST(N'19:10:37.0997105' AS Time), N'', NULL, NULL, NULL, 2, CAST(5.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId]) VALUES (6, N'si-000003', 11, 1, N's', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(10000.00 AS Decimal(20, 2)), CAST(10500.00 AS Decimal(20, 2)), CAST(3500.00 AS Decimal(20, 2)), CAST(7000.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-17T16:29:05.8478596' AS DateTime2), CAST(N'2021-08-17T16:29:05.8478596' AS DateTime2), 1, NULL, NULL, CAST(N'16:29:05.8478596' AS Time), N'', NULL, NULL, NULL, 2, CAST(5.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId]) VALUES (7, N'si-000004', NULL, 2, N'sd', N'1', CAST(0.0000 AS Decimal(20, 4)), CAST(10000.00 AS Decimal(20, 2)), CAST(10500.00 AS Decimal(20, 2)), CAST(0.00 AS Decimal(20, 2)), CAST(10500.00 AS Decimal(20, 2)), NULL, CAST(N'2021-08-17T16:54:21.3812811' AS DateTime2), CAST(N'2021-08-17T16:54:21.3812811' AS DateTime2), 2, NULL, NULL, CAST(N'16:54:21.3812811' AS Time), N'', NULL, NULL, NULL, 2, CAST(5.00 AS Decimal(20, 2)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId]) VALUES (8, N'pi-000003', 6, 1, N'pw', N'-1', NULL, CAST(500.00 AS Decimal(20, 2)), CAST(2500.00 AS Decimal(20, 2)), CAST(2000.00 AS Decimal(20, 2)), CAST(500.00 AS Decimal(20, 2)), CAST(N'2021-08-31' AS Date), CAST(N'2021-08-17T16:59:48.5524370' AS DateTime2), CAST(N'2021-08-17T16:59:48.5524370' AS DateTime2), 1, NULL, NULL, CAST(N'16:59:48.5524370' AS Time), N'', N'iyo9u98', CAST(N'2021-08-17T00:00:00.0000000' AS DateTime2), 2, 2, CAST(0.00 AS Decimal(20, 2)), 2, NULL, NULL, NULL, 2, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[invoiceStatus] ON 

INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1, 2, N'pr', CAST(N'2021-08-15T13:43:33.0897509' AS DateTime2), CAST(N'2021-08-15T13:43:33.0897509' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (2, 2, N'ex', CAST(N'2021-08-15T13:43:33.1555732' AS DateTime2), CAST(N'2021-08-15T13:43:33.1555732' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (3, 2, N'rc', CAST(N'2021-08-15T13:43:33.2104287' AS DateTime2), CAST(N'2021-08-15T13:43:33.2104287' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (4, 5, N'pr', CAST(N'2021-08-16T19:10:37.8696537' AS DateTime2), CAST(N'2021-08-16T19:10:37.8696537' AS DateTime2), 9, 9, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (5, 5, N'ex', CAST(N'2021-08-16T19:10:37.9873704' AS DateTime2), CAST(N'2021-08-16T19:10:37.9873704' AS DateTime2), 9, 9, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (6, 5, N'rc', CAST(N'2021-08-16T19:10:38.0272355' AS DateTime2), CAST(N'2021-08-16T19:10:38.0272355' AS DateTime2), 9, 9, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (7, 6, N'pr', CAST(N'2021-08-17T16:29:06.3600289' AS DateTime2), CAST(N'2021-08-17T16:29:06.3600289' AS DateTime2), 1, 1, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (8, 6, N'ex', CAST(N'2021-08-17T16:29:06.4538119' AS DateTime2), CAST(N'2021-08-17T16:29:06.4538119' AS DateTime2), 1, 1, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (9, 6, N'rc', CAST(N'2021-08-17T16:29:06.5019657' AS DateTime2), CAST(N'2021-08-17T16:29:06.5019657' AS DateTime2), 1, 1, NULL, 1)
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
SET IDENTITY_INSERT [dbo].[items] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsLocations] ON 

INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (1, 1, 98, CAST(N'2021-08-15T13:43:14.2869924' AS DateTime2), CAST(N'2021-08-15T13:43:14.2869924' AS DateTime2), 2, 2, NULL, NULL, 1, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (2, 1, 7, CAST(N'2021-08-15T13:43:32.8075028' AS DateTime2), CAST(N'2021-08-17T16:29:06.1835004' AS DateTime2), 2, 2, NULL, NULL, 3, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (3, 1, 49, CAST(N'2021-08-16T13:00:52.0499443' AS DateTime2), CAST(N'2021-08-16T13:02:09.4810087' AS DateTime2), 2, 2, NULL, NULL, 7, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note]) VALUES (4, 1, 9, CAST(N'2021-08-16T19:10:37.5315564' AS DateTime2), CAST(N'2021-08-16T19:10:37.5315564' AS DateTime2), 9, 9, NULL, NULL, 3, NULL)
SET IDENTITY_INSERT [dbo].[itemsLocations] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsProp] ON 

INSERT [dbo].[itemsProp] ([itemPropId], [propertyItemId], [itemId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (2, 1, 1, CAST(N'2021-07-01T14:37:23.8934926' AS DateTime2), CAST(N'2021-07-01T14:37:23.8934926' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[itemsProp] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsTransfer] ON 

INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId]) VALUES (1, 100, 1, NULL, NULL, CAST(N'2021-08-15T13:43:03.6394744' AS DateTime2), CAST(N'2021-08-15T13:43:03.6394744' AS DateTime2), 2, 2, NULL, CAST(100.00 AS Decimal(20, 2)), 1, N'', NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId]) VALUES (2, 10, 2, NULL, NULL, CAST(N'2021-08-15T13:43:32.6280171' AS DateTime2), CAST(N'2021-08-15T13:43:32.6280171' AS DateTime2), 2, 2, NULL, CAST(10000.00 AS Decimal(20, 2)), 3, N'', NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId]) VALUES (3, 50, 3, NULL, NULL, CAST(N'2021-08-16T13:00:42.4582922' AS DateTime2), CAST(N'2021-08-16T13:00:42.4582922' AS DateTime2), 2, 2, NULL, CAST(500.00 AS Decimal(20, 2)), 7, N'', NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId]) VALUES (4, 1, 4, NULL, NULL, CAST(N'2021-08-16T13:02:09.4042138' AS DateTime2), CAST(N'2021-08-16T13:02:09.4042138' AS DateTime2), 2, 2, NULL, CAST(500.00 AS Decimal(20, 2)), 7, N'', 4)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId]) VALUES (5, 2, 5, NULL, NULL, CAST(N'2021-08-16T19:10:37.2792321' AS DateTime2), CAST(N'2021-08-16T19:10:37.2792321' AS DateTime2), 9, 9, NULL, CAST(10000.00 AS Decimal(20, 2)), 3, N'', NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId]) VALUES (6, 1, 6, NULL, NULL, CAST(N'2021-08-17T16:29:05.9870242' AS DateTime2), CAST(N'2021-08-17T16:29:05.9870242' AS DateTime2), 1, 1, NULL, CAST(10000.00 AS Decimal(20, 2)), 3, N'', NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId]) VALUES (7, 1, 7, NULL, NULL, CAST(N'2021-08-17T16:54:21.4191488' AS DateTime2), CAST(N'2021-08-17T16:54:21.4191488' AS DateTime2), 2, 2, NULL, CAST(10000.00 AS Decimal(20, 2)), 3, N'', NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId]) VALUES (8, 1, 8, NULL, NULL, CAST(N'2021-08-17T16:59:48.8057623' AS DateTime2), CAST(N'2021-08-17T16:59:48.8057623' AS DateTime2), 1, 1, NULL, CAST(500.00 AS Decimal(20, 2)), 7, N'', NULL)
SET IDENTITY_INSERT [dbo].[itemsTransfer] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsUnits] ON 

INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (1, 1, 4, 10, 0, 1, CAST(1000000.00 AS Decimal(20, 2)), N'4078525279900', CAST(N'2021-07-01T14:44:41.7298217' AS DateTime2), CAST(N'2021-07-01T14:44:41.7298217' AS DateTime2), 1, 1, 3, NULL, NULL, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (2, 1, 3, 10, 0, 0, CAST(100000.00 AS Decimal(20, 2)), N'8078525308101', CAST(N'2021-07-01T14:44:59.9506480' AS DateTime2), CAST(N'2021-07-01T14:44:59.9506480' AS DateTime2), 1, 1, 1, NULL, NULL, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (3, 1, 1, 1, 1, 0, CAST(10000.00 AS Decimal(20, 2)), N'1078525310002', CAST(N'2021-07-01T14:45:13.7321603' AS DateTime2), CAST(N'2021-07-01T14:45:13.7321603' AS DateTime2), 1, 1, 1, NULL, NULL, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (6, 21, 1, 1, 1, 1, CAST(1200000.00 AS Decimal(20, 2)), N'9078525346911', CAST(N'2021-07-01T14:51:39.5162385' AS DateTime2), CAST(N'2021-07-01T14:51:39.5162385' AS DateTime2), 1, 1, 1, NULL, NULL, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (7, 19, 2, 12, 0, 0, CAST(10000.00 AS Decimal(20, 2)), N'9078525349912', CAST(N'2021-07-01T14:52:35.2357118' AS DateTime2), CAST(N'2021-08-05T12:14:41.6775992' AS DateTime2), 1, 1, 1, NULL, 2, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (8, 19, 1, 1, 0, 0, CAST(1000.00 AS Decimal(20, 2)), N'3078525355513', CAST(N'2021-07-01T14:52:46.5385199' AS DateTime2), CAST(N'2021-08-05T12:14:55.2145219' AS DateTime2), 1, 1, 1, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (9, 18, 2, 12, 0, 1, CAST(5000.00 AS Decimal(20, 2)), N'8078543943001', CAST(N'2021-07-03T10:57:25.6220112' AS DateTime2), CAST(N'2021-07-25T11:35:38.0737335' AS DateTime2), 1, 1, 1, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (10, 18, 1, 1, 1, 0, CAST(500.00 AS Decimal(20, 2)), N'4078543945504', CAST(N'2021-07-03T10:57:48.3277860' AS DateTime2), CAST(N'2021-07-03T10:57:48.3277860' AS DateTime2), 1, 1, 1, NULL, NULL, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (11, 20, 2, 12, 1, 0, CAST(1500.00 AS Decimal(20, 2)), N'9078543955607', CAST(N'2021-07-03T10:59:35.7246859' AS DateTime2), CAST(N'2021-08-05T12:08:15.2377220' AS DateTime2), 1, 1, 1, NULL, 2, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (12, 20, 1, 1, 0, 0, CAST(1250.00 AS Decimal(20, 2)), N'3078543957508', CAST(N'2021-07-03T10:59:59.8630022' AS DateTime2), CAST(N'2021-08-05T12:08:09.8847972' AS DateTime2), 1, 1, 1, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (17, 2, 12, 12, 0, 1, CAST(125.00 AS Decimal(20, 2)), N'8078696805102', CAST(N'2021-07-18T18:56:04.1895801' AS DateTime2), CAST(N'2021-07-18T18:56:04.1895801' AS DateTime2), 1, 1, 1, NULL, NULL, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (18, 17, 1, 1, 1, 1, CAST(500000.00 AS Decimal(20, 2)), N'8078697220300', CAST(N'2021-07-18T20:04:00.3555774' AS DateTime2), CAST(N'2021-07-18T20:04:00.3555774' AS DateTime2), 2, 2, 1, NULL, NULL, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (22, 20, 1, 1, 0, 1, CAST(1250.00 AS Decimal(20, 2)), N'3078543957508', CAST(N'2021-08-05T12:08:40.7870968' AS DateTime2), CAST(N'2021-08-05T12:08:40.7870968' AS DateTime2), 2, 2, 1, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (23, 7, 3, 12, 1, 0, CAST(20000.00 AS Decimal(20, 2)), N'6078874484800', CAST(N'2021-08-05T12:28:01.4602198' AS DateTime2), CAST(N'2021-08-05T12:28:01.4602198' AS DateTime2), 2, 2, 1, NULL, 2, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (24, 7, 1, 1, 0, 1, CAST(2500.00 AS Decimal(20, 2)), N'6078874484800', CAST(N'2021-08-05T12:28:23.9463893' AS DateTime2), CAST(N'2021-08-05T12:28:23.9463893' AS DateTime2), 2, 2, 1, NULL, 1, 1)
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
INSERT [dbo].[objects] ([objectId], [name], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [parentObjectId], [objectType]) VALUES (26, N'package', N'', NULL, NULL, NULL, NULL, 1, 4, N'basic')
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
SET IDENTITY_INSERT [dbo].[objects] OFF
GO
SET IDENTITY_INSERT [dbo].[pos] ON 

INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (1, N'Al-JM-B-POS-1', N'POS-1', CAST(0.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:51:49.0366461' AS DateTime2), CAST(N'2021-08-09T14:43:34.0477026' AS DateTime2), 1, 2, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (2, N'Al-JM-B-POS-2', N'POS-2', CAST(21000.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:52:00.6122040' AS DateTime2), CAST(N'2021-08-16T19:10:37.6452557' AS DateTime2), 1, 2, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (3, N'Al-JM-B-POS-3', N'POS-3', CAST(0.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:52:12.7045399' AS DateTime2), CAST(N'2021-08-10T15:16:19.1861926' AS DateTime2), 1, 3, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (4, N'Al-JM-B-POS-4', N'POS-4', CAST(0.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:52:24.9776657' AS DateTime2), CAST(N'2021-08-07T15:21:51.3562564' AS DateTime2), 1, 2, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (5, N'Al-JM-B-POS-5', N'POS-5', CAST(0.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:52:34.7838816' AS DateTime2), CAST(N'2021-08-07T15:22:13.4693155' AS DateTime2), 1, 2, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (6, N'Al-JM-B-POS-6', N'POS-6', CAST(0.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:52:47.6503734' AS DateTime2), CAST(N'2021-06-29T16:52:47.6503734' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (7, N'Al-JM-B-POS-7', N'POS-7', CAST(0.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:52:56.7213024' AS DateTime2), CAST(N'2021-06-29T16:52:56.7213024' AS DateTime2), 1, 1, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (8, N'Al-JM-B-POS-8', N'POS-8', CAST(0.00 AS Decimal(20, 2)), 2, CAST(N'2021-06-29T16:53:15.5931410' AS DateTime2), CAST(N'2021-08-10T15:16:19.1872671' AS DateTime2), 1, 3, 1, N'', CAST(0.00 AS Decimal(20, 2)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (9, N'Al-FK-B-POS-1', N'POS-1', CAST(0.00 AS Decimal(20, 2)), 3, CAST(N'2021-06-29T16:53:31.2314166' AS DateTime2), CAST(N'2021-08-10T13:16:18.5824465' AS DateTime2), 1, 3, 1, N'', CAST(0.00 AS Decimal(20, 2)))
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
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (24, N'DM-CE-B-POS-1', N'POS-1', CAST(0.00 AS Decimal(20, 2)), 5, CAST(N'2021-07-15T15:46:28.7313439' AS DateTime2), CAST(N'2021-08-10T13:10:39.5329904' AS DateTime2), 9, 3, 1, N'', CAST(0.00 AS Decimal(20, 2)))
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
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (13, N'pur_order_email_temp', N'emailtemp')
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (14, N'dateForm', NULL)
INSERT [dbo].[setting] ([settingId], [name], [notes]) VALUES (15, N'sale_email_temp', N'emailtemp')
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
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (14, N'ad4bfd50185ef68bce2b903aa7e10ec0.jpg', 1, 1, N'', 7)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (15, N'Title', NULL, 1, N'title', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (16, N'Please provide to us,with a price list,along with your terms and conditions of sale, applicable discounts, shipping dates and additional sales and corporate policies. Should the information you provide be acceptable and competitive.', NULL, 1, N'text1', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (17, N'Thank you for your cooperation. We have also enclosed our procurement specifications and conditions for your review', NULL, 1, N'text2', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (18, N'Support', NULL, 1, N'link1text', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (19, N'Returnpolicy ', NULL, 1, N'link2text', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (20, N'About Us', NULL, NULL, N'link3text', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (22, N'http://www.google.com', NULL, 1, N'link1url', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (23, N'http://www.google.com', NULL, 1, N'link2url', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (24, N'http://www.google.com', NULL, 1, N'link3url', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (25, N'dddd, MMMM d, yyyy', 1, 1, NULL, 14)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (26, N'Sales', NULL, 1, N'title', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (27, N'Please provide to us,with a price list,along with your terms and conditions of sale, applicable discounts, shipping dates and additional sales and corporate policies. Should the information you provide be acceptable and competitive.', NULL, 1, N'text1', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (28, N'Thank you for your cooperation. We have also enclosed our procurement specifications and conditions for your review', NULL, 1, N'text2', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (29, N'Support', NULL, 1, N'link1text', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (30, N'Returnpolicy ', NULL, 1, N'link2text', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (31, N'About Us', NULL, NULL, N'link3text', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (32, N'http://www.google.com', NULL, 1, N'link1url', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (33, N'http://www.google.com', NULL, 1, N'link2url', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (34, N'http://www.google.com', NULL, 1, N'link3url', 15)
SET IDENTITY_INSERT [dbo].[setValues] OFF
GO
SET IDENTITY_INSERT [dbo].[shippingCompanies] ON 

INSERT [dbo].[shippingCompanies] ([shippingCompanyId], [name], [RealDeliveryCost], [deliveryCost], [deliveryType], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [balance], [balanceType]) VALUES (1, N'FedEx     ', CAST(12.00 AS Decimal(20, 2)), CAST(15.00 AS Decimal(20, 2)), N'local', N'notes', CAST(N'2021-07-29T15:12:02.4328432' AS DateTime2), CAST(N'2021-08-07T16:19:28.7623016' AS DateTime2), 2, 2, 1, CAST(0.000 AS Decimal(20, 3)), 0)
INSERT [dbo].[shippingCompanies] ([shippingCompanyId], [name], [RealDeliveryCost], [deliveryCost], [deliveryType], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [balance], [balanceType]) VALUES (2, N'AL Haram  ', CAST(12.00 AS Decimal(20, 2)), CAST(15.00 AS Decimal(20, 2)), N'com', N'notes', CAST(N'2021-07-29T15:12:33.0786920' AS DateTime2), CAST(N'2021-08-07T16:19:47.4658294' AS DateTime2), 2, 2, 1, CAST(0.000 AS Decimal(20, 3)), 0)
INSERT [dbo].[shippingCompanies] ([shippingCompanyId], [name], [RealDeliveryCost], [deliveryCost], [deliveryType], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [balance], [balanceType]) VALUES (4, N'AL Kadmous', CAST(10.00 AS Decimal(20, 2)), CAST(15.00 AS Decimal(20, 2)), N'local', N'notes', CAST(N'2021-07-29T15:22:09.2733507' AS DateTime2), CAST(N'2021-08-09T13:17:36.0087323' AS DateTime2), 2, 2, 1, CAST(0.000 AS Decimal(20, 3)), 0)
INSERT [dbo].[shippingCompanies] ([shippingCompanyId], [name], [RealDeliveryCost], [deliveryCost], [deliveryType], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [balance], [balanceType]) VALUES (5, N'aramex    ', CAST(13.00 AS Decimal(20, 2)), CAST(15.00 AS Decimal(20, 2)), N'com', N'', CAST(N'2021-08-08T14:02:44.9224153' AS DateTime2), CAST(N'2021-08-08T14:02:44.9224153' AS DateTime2), 2, 2, 1, CAST(0.000 AS Decimal(20, 3)), 0)
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
INSERT [dbo].[sysEmails] ([emailId], [name], [email], [password], [port], [isSSL], [smtpClient], [side], [notes], [branchId], [isActive], [createUserId], [updateUserId], [createDate], [updateDate], [isMajor]) VALUES (6, N'manager', N'wseetw@gmail.com', N'MjE0YTE5NjBh', 587, 1, N'smtp.gmail.com', N'md', N'', 2, 1, 9, 9, CAST(N'2021-08-04T11:13:34.9727936' AS DateTime2), CAST(N'2021-08-04T11:37:42.9603264' AS DateTime2), 1)
INSERT [dbo].[sysEmails] ([emailId], [name], [email], [password], [port], [isSSL], [smtpClient], [side], [notes], [branchId], [isActive], [createUserId], [updateUserId], [createDate], [updateDate], [isMajor]) VALUES (7, N'HR', N'wseetw@gmail.com', N'MjE0YTE5NjBh', 587, 1, N'smtp.gmail.com', N'hr', N'', 2, 1, 9, 9, CAST(N'2021-08-04T11:34:51.7231965' AS DateTime2), CAST(N'2021-08-04T11:34:51.7231965' AS DateTime2), 1)
INSERT [dbo].[sysEmails] ([emailId], [name], [email], [password], [port], [isSSL], [smtpClient], [side], [notes], [branchId], [isActive], [createUserId], [updateUserId], [createDate], [updateDate], [isMajor]) VALUES (8, N'Market', N'wseetw@gmail.com', N'MjE0YTE5NjBh', 587, 1, N'smtp.gmail.com', N'mk', N'', 2, 1, 9, 9, CAST(N'2021-08-04T11:35:18.1678888' AS DateTime2), CAST(N'2021-08-04T11:35:18.1678888' AS DateTime2), 1)
INSERT [dbo].[sysEmails] ([emailId], [name], [email], [password], [port], [isSSL], [smtpClient], [side], [notes], [branchId], [isActive], [createUserId], [updateUserId], [createDate], [updateDate], [isMajor]) VALUES (9, N'Support', N'wseetw@gmail.com', N'MjE0YTE5NjBh', 587, 1, N'smtp.gmail.com', N'sp', N'', 2, 1, 9, 9, CAST(N'2021-08-04T11:35:45.2890175' AS DateTime2), CAST(N'2021-08-04T11:35:45.2890175' AS DateTime2), 1)
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

INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (1, N'admin', N'1b8baf4f819e5b304e1a176e1c590c84', N'Mohammad', N'Nasani', N'System Admin', N'12', CAST(N'2021-06-28T18:38:45.0434248' AS DateTime2), CAST(N'2021-08-17T16:57:01.8733959' AS DateTime2), 2, 2, N'+963-21-2278910', N'+963-966376308', N'mohamadnasani@gmail.com', N'Halab', 1, N'', 1, N'', N'57440ff6b80f068efd50410ea24fd593.jpg', 19, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (2, N'yasin', N'1b8baf4f819e5b304e1a176e1c590c84', N'ياسين', N'ادلبي', N'محاسب', N'8', CAST(N'2021-06-30T11:05:51.9137655' AS DateTime2), CAST(N'2021-08-17T18:44:43.3049233' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'c37858823db0093766eee74d8ee1f1e5.png', 19, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (3, N'yasmine', N'4cdf921bfe31b594a0cc9cc555292f02', N'ياسمين', N'النجار', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:17:13.6368587' AS DateTime2), CAST(N'2021-08-17T14:36:59.8106886' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'71f020248a405d21e94d1de52043bed4.jpg', 19, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (4, N'bonni', N'494e167fd30bf2a244c8fcda0220aa89', N'محمد', N'بني', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:17:38.6309662' AS DateTime2), CAST(N'2021-08-17T16:57:37.2283465' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'd2ec5f1ed83abfca0dfec76506b696b3.png', 19, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (5, N'olwani', N'7ae94a254e28a0e9a575e9669fed5684', N'محمد', N'علواني', N'مدير مشتريات', N'8', CAST(N'2021-06-30T11:23:59.5926231' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'f96f8a89e2143f1e43a2ba7953fb5413.png', NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (6, N'amna', N'78fe84643f9a617ac5800771a1c3c5e9', N'آمنة', N'سعدات', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:24:56.0475272' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'56a2e0231c3d394ace201adf37d13f63.png', NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (7, N'basmah', N'210db3affbee2bdeb82872a7f42a970f', N'باسمة', N'قدري', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:25:40.3004312' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'3204215c19f25609034d24451f7e03d7.png', NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (8, N'bik', N'e2a603fb361ecb7b2fc6791f98382580', N'محمد', N'بيك', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:26:56.9568520' AS DateTime2), CAST(N'2021-08-09T11:26:10.4174871' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'6a5d62c1233b5e9b2000dd13aadf81f4.png', NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (9, N'naji', N'741e82719da67d8744fd797194aa65b0', N'ناجي', N'مصري', N'مدير', N'8', CAST(N'2021-06-30T11:40:59.4646248' AS DateTime2), CAST(N'2021-08-16T19:09:00.6913237' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'6eaba1dc3c031faf262149c058fea728.png', 19, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (10, N'gammal', N'93f8a85e591d4c7d7bb32a1c2ded5f49', N'جمال', N'عثمان', N'محاسب', N'8', CAST(N'2021-06-30T11:41:40.3141978' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'0f26776e0a524c7d2b6b5f771d500980.png', NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (11, N'samer', N'88bc4525060f0e96bf15392785fc0bc9', N'سامر', N'المصري', N'امين مستودع', N'8', CAST(N'2021-06-30T11:42:42.2388711' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'05da7ccc8020731d607471318fc4f35b.png', NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (12, N'esmaeil', N'b52c7f50ba2f865399e5838e87e4db6c', N'اسماعيل', N'امجد', N'مدير مشتريات', N'8', CAST(N'2021-06-30T11:43:05.8054749' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'0731f29a7d8c55ddab810a076d078aff.png', NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (13, N'fatema', N'd8fe177d106f727da83452e72ed6cc52', N'فاطمة', N'خالد', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:43:27.8574569' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (14, N'aya', N'9b43a5e653134fc8350ca9944eadaf2f', N'آية', N'سليمان', N'مدير', N'8', CAST(N'2021-06-30T11:43:48.7387915' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (15, N'somaya', N'bd1872d1a3f8b6ac8ea1801d78500716', N'سمية', N'محمد', N'محاسب', N'8', CAST(N'2021-06-30T11:44:27.3588024' AS DateTime2), CAST(N'2021-07-15T12:36:06.4721474' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (16, N'samerah', N'1fb05f350e1272d0fcf5023cd08b0c78', N'سميرة', N'المحجوب', N'امين مستودع', N'8', CAST(N'2021-06-30T11:45:13.9722914' AS DateTime2), CAST(N'2021-06-30T11:45:13.9722914' AS DateTime2), 1, 1, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (17, N'sawsan', N'4e08511679204a2c1056e96feafd9a98', N'سوسن', N'الأحمد', N'مدير مشتريات', N'8', CAST(N'2021-06-30T11:45:52.9176913' AS DateTime2), CAST(N'2021-06-30T11:45:52.9176913' AS DateTime2), 1, 1, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (18, N'sara', N'7202807332047589fa409179963a9c04', N'سارة', N'علي', N'نقطة مبيعات', N'8', CAST(N'2021-06-30T11:47:13.0378597' AS DateTime2), CAST(N'2021-06-30T11:47:13.0378597' AS DateTime2), 1, 1, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (19, N'dina', N'513866157bae565e9e3bc02a1ca05e9d', N'دينا', N'نعمة', N'امين مستودع', N'8', CAST(N'2021-06-30T11:48:15.5604312' AS DateTime2), CAST(N'2021-08-11T14:45:36.7448271' AS DateTime2), 1, 2, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, 19, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (20, N'sabbagh', N'1a45d82222dab4a597537f85b7dacfe1', N'أحمد', N'صباغ', N'مساعد امين مستودع', N'8', CAST(N'2021-06-30T11:48:46.0905677' AS DateTime2), CAST(N'2021-06-30T11:48:46.0905677' AS DateTime2), 1, 1, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType]) VALUES (21, N'saeed', N'1e920a928a6be4ea6fa634e7fa3f048b', N'سعيد', N'قطان', N'امين مستودع', N'8', CAST(N'2021-06-30T11:49:06.2421502' AS DateTime2), CAST(N'2021-06-30T11:49:06.2421502' AS DateTime2), 1, 1, N'', N'+963-966376308', N'', N'', 1, N'', 1, N'', NULL, NULL, CAST(0.00 AS Decimal(20, 2)), 0)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
SET IDENTITY_INSERT [dbo].[userSetValues] ON 

INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (6, 3, 2, NULL, CAST(N'2021-07-10T13:43:33.1472761' AS DateTime2), CAST(N'2021-07-14T12:45:13.2937637' AS DateTime2), 3, 3)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (7, 9, 1, N'thisis', CAST(N'2021-07-10T14:23:23.5064125' AS DateTime2), CAST(N'2021-08-08T10:32:50.4993971' AS DateTime2), 9, 9)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (8, 4, 1, NULL, CAST(N'2021-07-12T10:29:19.2071006' AS DateTime2), CAST(N'2021-08-08T12:47:21.8151312' AS DateTime2), 4, 4)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (9, 2, 2, NULL, CAST(N'2021-07-12T17:06:47.4146813' AS DateTime2), CAST(N'2021-07-12T17:09:45.4157961' AS DateTime2), 2, 2)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (10, 1, 2, NULL, CAST(N'2021-07-24T10:58:03.7729709' AS DateTime2), CAST(N'2021-08-09T15:27:52.7050058' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[userSetValues] OFF
GO
SET IDENTITY_INSERT [dbo].[usersLogs] ON 

INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (1, CAST(N'2021-08-15T11:30:11.8860255' AS DateTime2), CAST(N'2021-08-15T12:52:35.2990173' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2, CAST(N'2021-08-15T11:51:42.7188002' AS DateTime2), CAST(N'2021-08-15T11:52:00.2968307' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (3, CAST(N'2021-08-15T11:53:09.2485848' AS DateTime2), CAST(N'2021-08-17T10:31:58.1067210' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (4, CAST(N'2021-08-15T11:54:53.8891489' AS DateTime2), CAST(N'2021-08-15T11:56:33.8095916' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (5, CAST(N'2021-08-15T11:56:55.7220380' AS DateTime2), CAST(N'2021-08-15T13:19:07.4534131' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (6, CAST(N'2021-08-15T12:52:36.1287996' AS DateTime2), CAST(N'2021-08-15T12:57:46.5828640' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (7, CAST(N'2021-08-15T12:57:46.7055354' AS DateTime2), CAST(N'2021-08-15T13:02:03.6155928' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (8, CAST(N'2021-08-15T13:02:03.7392610' AS DateTime2), CAST(N'2021-08-15T14:54:43.7960115' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (9, CAST(N'2021-08-15T13:03:33.2670912' AS DateTime2), CAST(N'2021-08-15T13:22:04.2948457' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (10, CAST(N'2021-08-15T13:19:08.7379519' AS DateTime2), CAST(N'2021-08-17T10:01:00.2988905' AS DateTime2), 1, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (11, CAST(N'2021-08-15T13:22:04.7695789' AS DateTime2), CAST(N'2021-08-15T13:42:19.3966644' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (12, CAST(N'2021-08-15T13:42:19.5542429' AS DateTime2), CAST(N'2021-08-15T13:44:12.8644671' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (13, CAST(N'2021-08-15T13:44:13.0020983' AS DateTime2), CAST(N'2021-08-15T13:45:25.8145697' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (14, CAST(N'2021-08-15T13:45:25.9791005' AS DateTime2), CAST(N'2021-08-15T13:48:09.3645496' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (15, CAST(N'2021-08-15T13:48:09.5958981' AS DateTime2), CAST(N'2021-08-15T13:59:13.2866031' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (16, CAST(N'2021-08-15T13:59:13.5110313' AS DateTime2), CAST(N'2021-08-15T14:00:54.1310119' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (17, CAST(N'2021-08-15T14:00:54.2904428' AS DateTime2), CAST(N'2021-08-15T14:02:16.7680841' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (18, CAST(N'2021-08-15T14:02:16.9655284' AS DateTime2), CAST(N'2021-08-15T14:04:45.3071409' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (19, CAST(N'2021-08-15T14:04:45.4966383' AS DateTime2), CAST(N'2021-08-15T14:06:15.6846442' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (20, CAST(N'2021-08-15T14:06:15.9479440' AS DateTime2), CAST(N'2021-08-15T14:41:35.1652612' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (21, CAST(N'2021-08-15T14:41:35.8055523' AS DateTime2), CAST(N'2021-08-15T15:37:30.4717028' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (22, CAST(N'2021-08-15T14:54:44.0822498' AS DateTime2), CAST(N'2021-08-16T11:21:37.6801838' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (23, CAST(N'2021-08-15T15:37:31.1439074' AS DateTime2), CAST(N'2021-08-15T16:07:53.5922008' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (24, CAST(N'2021-08-15T16:07:54.2634090' AS DateTime2), CAST(N'2021-08-16T12:59:48.5827586' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (25, CAST(N'2021-08-16T11:21:38.2456744' AS DateTime2), CAST(N'2021-08-16T12:09:13.1620408' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (26, CAST(N'2021-08-16T12:09:14.1494009' AS DateTime2), CAST(N'2021-08-16T12:11:09.2349243' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (27, CAST(N'2021-08-16T12:11:09.8413376' AS DateTime2), CAST(N'2021-08-16T12:14:26.7843091' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (28, CAST(N'2021-08-16T12:14:27.5712062' AS DateTime2), CAST(N'2021-08-16T12:20:21.4705542' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (29, CAST(N'2021-08-16T12:20:22.4778623' AS DateTime2), CAST(N'2021-08-16T12:23:02.5380080' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (30, CAST(N'2021-08-16T12:23:03.1563197' AS DateTime2), CAST(N'2021-08-16T12:27:17.9155452' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (31, CAST(N'2021-08-16T12:27:18.5318980' AS DateTime2), CAST(N'2021-08-16T13:39:05.5635443' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (32, CAST(N'2021-08-16T12:59:49.2749079' AS DateTime2), CAST(N'2021-08-17T14:15:35.5817830' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (33, CAST(N'2021-08-16T13:39:06.6117456' AS DateTime2), CAST(N'2021-08-16T14:47:29.4074565' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (34, CAST(N'2021-08-16T14:47:30.0956193' AS DateTime2), CAST(N'2021-08-16T15:12:19.2572658' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (35, CAST(N'2021-08-16T15:12:20.7792005' AS DateTime2), CAST(N'2021-08-17T11:13:38.4895848' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (36, CAST(N'2021-08-16T19:09:01.2428525' AS DateTime2), CAST(N'2021-08-16T19:22:27.4506195' AS DateTime2), 2, 9)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (37, CAST(N'2021-08-17T10:01:01.3161728' AS DateTime2), CAST(N'2021-08-17T11:08:00.2430590' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (38, CAST(N'2021-08-17T10:31:58.3401020' AS DateTime2), CAST(N'2021-08-17T10:35:13.9095180' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (39, CAST(N'2021-08-17T10:52:06.3051538' AS DateTime2), CAST(N'2021-08-17T10:54:31.4836148' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (40, CAST(N'2021-08-17T10:56:41.2351415' AS DateTime2), CAST(N'2021-08-17T11:01:22.5246889' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (41, CAST(N'2021-08-17T11:01:22.8936716' AS DateTime2), CAST(N'2021-08-17T11:01:52.1570689' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (42, CAST(N'2021-08-17T11:05:54.4794240' AS DateTime2), CAST(N'2021-08-17T11:06:25.1155213' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (43, CAST(N'2021-08-17T11:08:00.3587497' AS DateTime2), CAST(N'2021-08-17T11:31:30.2430088' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (44, CAST(N'2021-08-17T11:09:53.0959456' AS DateTime2), CAST(N'2021-08-17T11:10:24.2167793' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (45, CAST(N'2021-08-17T11:13:39.9430117' AS DateTime2), CAST(N'2021-08-17T11:33:34.2118122' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (46, CAST(N'2021-08-17T11:17:36.0102398' AS DateTime2), CAST(N'2021-08-17T11:21:09.1431123' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (47, CAST(N'2021-08-17T11:30:10.0914829' AS DateTime2), CAST(N'2021-08-17T11:31:11.4701280' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (48, CAST(N'2021-08-17T11:31:30.3364957' AS DateTime2), CAST(N'2021-08-17T11:40:51.9495745' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (49, CAST(N'2021-08-17T11:33:34.3424646' AS DateTime2), CAST(N'2021-08-17T11:36:45.4260630' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (50, CAST(N'2021-08-17T11:36:45.5553463' AS DateTime2), CAST(N'2021-08-17T11:39:31.8589009' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (51, CAST(N'2021-08-17T11:39:31.9857767' AS DateTime2), CAST(N'2021-08-17T11:41:42.3750423' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (52, CAST(N'2021-08-17T11:40:52.0662650' AS DateTime2), CAST(N'2021-08-17T12:29:55.9513982' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (53, CAST(N'2021-08-17T11:41:42.4877063' AS DateTime2), CAST(N'2021-08-17T11:46:35.3146541' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (54, CAST(N'2021-08-17T11:44:52.4047538' AS DateTime2), CAST(N'2021-08-17T12:40:03.5392655' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (55, CAST(N'2021-08-17T11:46:35.4712362' AS DateTime2), CAST(N'2021-08-17T13:00:30.2533719' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (56, CAST(N'2021-08-17T12:29:56.0910261' AS DateTime2), CAST(N'2021-08-17T16:28:09.4594711' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (57, CAST(N'2021-08-17T12:40:04.7929162' AS DateTime2), CAST(N'2021-08-17T12:54:02.4446329' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (58, CAST(N'2021-08-17T12:54:02.5902443' AS DateTime2), CAST(N'2021-08-17T13:45:50.4993211' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (59, CAST(N'2021-08-17T13:00:30.4847528' AS DateTime2), CAST(N'2021-08-17T13:03:48.8227750' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (60, CAST(N'2021-08-17T13:03:48.9274958' AS DateTime2), CAST(N'2021-08-17T13:07:44.9330421' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (61, CAST(N'2021-08-17T13:07:48.4396424' AS DateTime2), CAST(N'2021-08-17T13:15:51.2570665' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (62, CAST(N'2021-08-17T13:15:53.2387731' AS DateTime2), CAST(N'2021-08-17T13:17:41.8984560' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (63, CAST(N'2021-08-17T13:17:42.0929053' AS DateTime2), CAST(N'2021-08-17T13:23:39.7443037' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (64, CAST(N'2021-08-17T13:23:39.8809392' AS DateTime2), CAST(N'2021-08-17T14:27:52.4856288' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (65, CAST(N'2021-08-17T13:45:51.4826916' AS DateTime2), CAST(N'2021-08-17T13:55:35.0365293' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (66, CAST(N'2021-08-17T13:55:35.1990964' AS DateTime2), CAST(N'2021-08-17T14:02:21.5946590' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (67, CAST(N'2021-08-17T14:02:21.7811617' AS DateTime2), CAST(N'2021-08-17T14:05:22.4266264' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (68, CAST(N'2021-08-17T14:05:22.8016587' AS DateTime2), CAST(N'2021-08-17T14:06:33.1941187' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (69, CAST(N'2021-08-17T14:15:36.3896279' AS DateTime2), CAST(N'2021-08-17T14:19:22.0566571' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (70, CAST(N'2021-08-17T14:19:23.5381044' AS DateTime2), CAST(N'2021-08-17T14:22:41.8920333' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (71, CAST(N'2021-08-17T14:22:42.1114189' AS DateTime2), CAST(N'2021-08-17T14:25:01.6680722' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (72, CAST(N'2021-08-17T14:25:01.8266486' AS DateTime2), CAST(N'2021-08-17T15:02:01.3377025' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (73, CAST(N'2021-08-17T14:27:53.2017172' AS DateTime2), CAST(N'2021-08-17T14:36:01.3030303' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (74, CAST(N'2021-08-17T14:36:01.7249254' AS DateTime2), CAST(N'2021-08-17T14:36:59.6042427' AS DateTime2), 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (75, CAST(N'2021-08-17T14:37:00.2166033' AS DateTime2), NULL, 2, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (76, CAST(N'2021-08-17T14:57:04.5569593' AS DateTime2), CAST(N'2021-08-17T15:00:27.3239498' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (77, CAST(N'2021-08-17T15:00:27.6281052' AS DateTime2), CAST(N'2021-08-17T15:00:53.8021628' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (78, CAST(N'2021-08-17T15:02:01.6638301' AS DateTime2), CAST(N'2021-08-17T16:35:30.8387882' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (79, CAST(N'2021-08-17T15:02:12.4689582' AS DateTime2), CAST(N'2021-08-17T15:02:25.9569483' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (80, CAST(N'2021-08-17T15:03:01.8799269' AS DateTime2), CAST(N'2021-08-17T15:04:19.1215313' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (81, CAST(N'2021-08-17T15:04:19.4007836' AS DateTime2), CAST(N'2021-08-17T15:04:28.8644966' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (82, CAST(N'2021-08-17T15:06:01.6963266' AS DateTime2), CAST(N'2021-08-17T15:07:29.2204868' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (83, CAST(N'2021-08-17T15:07:29.4319201' AS DateTime2), CAST(N'2021-08-17T15:07:38.8517525' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (84, CAST(N'2021-08-17T15:08:23.3069307' AS DateTime2), CAST(N'2021-08-17T15:09:24.9093571' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (85, CAST(N'2021-08-17T15:09:25.0549334' AS DateTime2), CAST(N'2021-08-17T15:44:31.4463815' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (86, CAST(N'2021-08-17T15:44:32.1844183' AS DateTime2), CAST(N'2021-08-17T15:52:06.6982334' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (87, CAST(N'2021-08-17T15:53:10.9147777' AS DateTime2), CAST(N'2021-08-17T15:56:27.7288727' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (88, CAST(N'2021-08-17T15:56:28.2743817' AS DateTime2), CAST(N'2021-08-17T16:14:37.6832038' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (89, CAST(N'2021-08-17T16:22:11.3893323' AS DateTime2), CAST(N'2021-08-17T16:27:34.6744216' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (90, CAST(N'2021-08-17T16:27:34.9546401' AS DateTime2), CAST(N'2021-08-17T16:28:10.5405843' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (91, CAST(N'2021-08-17T16:28:09.6090411' AS DateTime2), CAST(N'2021-08-17T16:57:01.8065726' AS DateTime2), 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (92, CAST(N'2021-08-17T16:29:01.8587838' AS DateTime2), CAST(N'2021-08-17T16:30:39.8837140' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (93, CAST(N'2021-08-17T16:30:40.0303222' AS DateTime2), CAST(N'2021-08-17T16:32:29.0499572' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (94, CAST(N'2021-08-17T16:32:29.2281547' AS DateTime2), CAST(N'2021-08-17T16:40:37.7855179' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (95, CAST(N'2021-08-17T16:35:31.1000914' AS DateTime2), CAST(N'2021-08-17T16:38:24.9341952' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (96, CAST(N'2021-08-17T16:38:25.1819319' AS DateTime2), CAST(N'2021-08-17T16:42:01.1262310' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (97, CAST(N'2021-08-17T16:40:38.1639458' AS DateTime2), CAST(N'2021-08-17T16:43:40.9468499' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (98, CAST(N'2021-08-17T16:42:01.3596434' AS DateTime2), CAST(N'2021-08-17T16:52:52.1926975' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (99, CAST(N'2021-08-17T16:47:03.4542786' AS DateTime2), CAST(N'2021-08-17T16:53:35.3602245' AS DateTime2), 2, 4)
GO
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (100, CAST(N'2021-08-17T16:52:52.3552948' AS DateTime2), CAST(N'2021-08-17T17:34:41.1760666' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (101, CAST(N'2021-08-17T16:55:00.2735785' AS DateTime2), CAST(N'2021-08-17T16:57:36.8972594' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (102, CAST(N'2021-08-17T16:57:01.9601600' AS DateTime2), NULL, 2, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (103, CAST(N'2021-08-17T16:57:37.3570022' AS DateTime2), CAST(N'2021-08-17T16:58:33.3913051' AS DateTime2), 2, 4)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (104, CAST(N'2021-08-17T17:34:41.9829124' AS DateTime2), CAST(N'2021-08-17T18:33:50.2954617' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (105, CAST(N'2021-08-17T18:33:51.4802955' AS DateTime2), CAST(N'2021-08-17T18:35:48.2072518' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (106, CAST(N'2021-08-17T18:35:48.3568176' AS DateTime2), CAST(N'2021-08-17T18:44:43.2331152' AS DateTime2), 2, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (107, CAST(N'2021-08-17T18:44:43.3677552' AS DateTime2), NULL, 2, 2)
SET IDENTITY_INSERT [dbo].[usersLogs] OFF
GO
ALTER TABLE [dbo].[countriesCodes] ADD  CONSTRAINT [DF_countriesCodes_isDefault]  DEFAULT ((0)) FOR [isDefault]
GO
ALTER TABLE [dbo].[inventoryItemLocation] ADD  CONSTRAINT [DF_inventoryItemLocation_isFalls]  DEFAULT ((0)) FOR [isFalls]
GO
ALTER TABLE [dbo].[notificationUser] ADD  CONSTRAINT [DF_notificationUser_isRead]  DEFAULT ((0)) FOR [isRead]
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
