USE [incposdbtest]
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
ALTER TABLE [dbo].[printers] DROP CONSTRAINT [FK_printers_users1]
GO
ALTER TABLE [dbo].[printers] DROP CONSTRAINT [FK_printers_users]
GO
ALTER TABLE [dbo].[posUsers] DROP CONSTRAINT [FK_posUsers_users2]
GO
ALTER TABLE [dbo].[posUsers] DROP CONSTRAINT [FK_posUsers_users1]
GO
ALTER TABLE [dbo].[posUsers] DROP CONSTRAINT [FK_posUsers_users]
GO
ALTER TABLE [dbo].[posUsers] DROP CONSTRAINT [FK_posUsers_pos]
GO
ALTER TABLE [dbo].[posSetting] DROP CONSTRAINT [FK_posSetting_users1]
GO
ALTER TABLE [dbo].[posSetting] DROP CONSTRAINT [FK_posSetting_users]
GO
ALTER TABLE [dbo].[posSetting] DROP CONSTRAINT [FK_posSetting_printers1]
GO
ALTER TABLE [dbo].[posSetting] DROP CONSTRAINT [FK_posSetting_printers]
GO
ALTER TABLE [dbo].[posSetting] DROP CONSTRAINT [FK_posSetting_posSerials]
GO
ALTER TABLE [dbo].[posSetting] DROP CONSTRAINT [FK_posSetting_pos]
GO
ALTER TABLE [dbo].[posSetting] DROP CONSTRAINT [FK_posSetting_paperSize]
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
ALTER TABLE [dbo].[notificationUser] DROP CONSTRAINT [FK_notificationUser_pos]
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
ALTER TABLE [dbo].[itemUnitUser] DROP CONSTRAINT [FK_itemUnitUser_users2]
GO
ALTER TABLE [dbo].[itemUnitUser] DROP CONSTRAINT [FK_itemUnitUser_users1]
GO
ALTER TABLE [dbo].[itemUnitUser] DROP CONSTRAINT [FK_itemUnitUser_users]
GO
ALTER TABLE [dbo].[itemUnitUser] DROP CONSTRAINT [FK_itemUnitUser_itemsUnits]
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
ALTER TABLE [dbo].[itemsTransfer] DROP CONSTRAINT [FK_itemsTransfer_offers]
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
ALTER TABLE [dbo].[itemsLocations] DROP CONSTRAINT [FK_itemsLocations_invoices]
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
ALTER TABLE [dbo].[invoiceOrder] DROP CONSTRAINT [FK_invoiceOrder_itemsTransfer]
GO
ALTER TABLE [dbo].[invoiceOrder] DROP CONSTRAINT [FK_invoiceOrder_invoices1]
GO
ALTER TABLE [dbo].[invoiceOrder] DROP CONSTRAINT [FK_invoiceOrder_invoices]
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
ALTER TABLE [dbo].[error] DROP CONSTRAINT [FK_error_users]
GO
ALTER TABLE [dbo].[error] DROP CONSTRAINT [FK_error_pos]
GO
ALTER TABLE [dbo].[error] DROP CONSTRAINT [FK_error_branches]
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
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [DF_invoices_isOrginal]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [DF_invoices_printedcount]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [DF_invoices_cashReturn]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [DF_invoices_isActive]
GO
ALTER TABLE [dbo].[invoices] DROP CONSTRAINT [DF_invoices_manualDiscountValue]
GO
ALTER TABLE [dbo].[inventoryItemLocation] DROP CONSTRAINT [DF_inventoryItemLocation_isFalls]
GO
ALTER TABLE [dbo].[countriesCodes] DROP CONSTRAINT [DF_countriesCodes_currencyId]
GO
ALTER TABLE [dbo].[countriesCodes] DROP CONSTRAINT [DF_countriesCodes_isDefault]
GO
ALTER TABLE [dbo].[agents] DROP CONSTRAINT [DF_agents_isLimited_1]
GO
/****** Object:  Table [dbo].[usersLogs]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usersLogs]') AND type in (N'U'))
DROP TABLE [dbo].[usersLogs]
GO
/****** Object:  Table [dbo].[userSetValues]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[userSetValues]') AND type in (N'U'))
DROP TABLE [dbo].[userSetValues]
GO
/****** Object:  Table [dbo].[users]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type in (N'U'))
DROP TABLE [dbo].[users]
GO
/****** Object:  Table [dbo].[units]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[units]') AND type in (N'U'))
DROP TABLE [dbo].[units]
GO
/****** Object:  Table [dbo].[sysEmails]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sysEmails]') AND type in (N'U'))
DROP TABLE [dbo].[sysEmails]
GO
/****** Object:  Table [dbo].[subscriptionFees]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subscriptionFees]') AND type in (N'U'))
DROP TABLE [dbo].[subscriptionFees]
GO
/****** Object:  Table [dbo].[storageCost]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[storageCost]') AND type in (N'U'))
DROP TABLE [dbo].[storageCost]
GO
/****** Object:  Table [dbo].[shippingCompanies]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[shippingCompanies]') AND type in (N'U'))
DROP TABLE [dbo].[shippingCompanies]
GO
/****** Object:  Table [dbo].[setValues]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setValues]') AND type in (N'U'))
DROP TABLE [dbo].[setValues]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setting]') AND type in (N'U'))
DROP TABLE [dbo].[setting]
GO
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[servicesCosts]') AND type in (N'U'))
DROP TABLE [dbo].[servicesCosts]
GO
/****** Object:  Table [dbo].[serials]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[serials]') AND type in (N'U'))
DROP TABLE [dbo].[serials]
GO
/****** Object:  Table [dbo].[sections]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sections]') AND type in (N'U'))
DROP TABLE [dbo].[sections]
GO
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[propertiesItems]') AND type in (N'U'))
DROP TABLE [dbo].[propertiesItems]
GO
/****** Object:  Table [dbo].[properties]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[properties]') AND type in (N'U'))
DROP TABLE [dbo].[properties]
GO
/****** Object:  Table [dbo].[ProgramDetails]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProgramDetails]') AND type in (N'U'))
DROP TABLE [dbo].[ProgramDetails]
GO
/****** Object:  Table [dbo].[printers]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[printers]') AND type in (N'U'))
DROP TABLE [dbo].[printers]
GO
/****** Object:  Table [dbo].[posUsers]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[posUsers]') AND type in (N'U'))
DROP TABLE [dbo].[posUsers]
GO
/****** Object:  Table [dbo].[posSetting]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[posSetting]') AND type in (N'U'))
DROP TABLE [dbo].[posSetting]
GO
/****** Object:  Table [dbo].[posSerials]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[posSerials]') AND type in (N'U'))
DROP TABLE [dbo].[posSerials]
GO
/****** Object:  Table [dbo].[pos]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pos]') AND type in (N'U'))
DROP TABLE [dbo].[pos]
GO
/****** Object:  Table [dbo].[Points]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Points]') AND type in (N'U'))
DROP TABLE [dbo].[Points]
GO
/****** Object:  Table [dbo].[paperSize]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[paperSize]') AND type in (N'U'))
DROP TABLE [dbo].[paperSize]
GO
/****** Object:  Table [dbo].[packages]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[packages]') AND type in (N'U'))
DROP TABLE [dbo].[packages]
GO
/****** Object:  Table [dbo].[offers]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[offers]') AND type in (N'U'))
DROP TABLE [dbo].[offers]
GO
/****** Object:  Table [dbo].[objects]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[objects]') AND type in (N'U'))
DROP TABLE [dbo].[objects]
GO
/****** Object:  Table [dbo].[notificationUser]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[notificationUser]') AND type in (N'U'))
DROP TABLE [dbo].[notificationUser]
GO
/****** Object:  Table [dbo].[notification]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[notification]') AND type in (N'U'))
DROP TABLE [dbo].[notification]
GO
/****** Object:  Table [dbo].[memberships]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[memberships]') AND type in (N'U'))
DROP TABLE [dbo].[memberships]
GO
/****** Object:  Table [dbo].[medals]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medals]') AND type in (N'U'))
DROP TABLE [dbo].[medals]
GO
/****** Object:  Table [dbo].[medalAgent]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medalAgent]') AND type in (N'U'))
DROP TABLE [dbo].[medalAgent]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[locations]') AND type in (N'U'))
DROP TABLE [dbo].[locations]
GO
/****** Object:  Table [dbo].[itemUnitUser]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemUnitUser]') AND type in (N'U'))
DROP TABLE [dbo].[itemUnitUser]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemTransferOffer]') AND type in (N'U'))
DROP TABLE [dbo].[itemTransferOffer]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsUnits]') AND type in (N'U'))
DROP TABLE [dbo].[itemsUnits]
GO
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[itemsTransfer]
GO
/****** Object:  Table [dbo].[itemsProp]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsProp]') AND type in (N'U'))
DROP TABLE [dbo].[itemsProp]
GO
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsOffers]') AND type in (N'U'))
DROP TABLE [dbo].[itemsOffers]
GO
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsMaterials]') AND type in (N'U'))
DROP TABLE [dbo].[itemsMaterials]
GO
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemsLocations]') AND type in (N'U'))
DROP TABLE [dbo].[itemsLocations]
GO
/****** Object:  Table [dbo].[items]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[items]') AND type in (N'U'))
DROP TABLE [dbo].[items]
GO
/****** Object:  Table [dbo].[invoiceStatus]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoiceStatus]') AND type in (N'U'))
DROP TABLE [dbo].[invoiceStatus]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoices]') AND type in (N'U'))
DROP TABLE [dbo].[invoices]
GO
/****** Object:  Table [dbo].[invoiceOrder]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoiceOrder]') AND type in (N'U'))
DROP TABLE [dbo].[invoiceOrder]
GO
/****** Object:  Table [dbo].[inventoryItemLocation]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[inventoryItemLocation]') AND type in (N'U'))
DROP TABLE [dbo].[inventoryItemLocation]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory]') AND type in (N'U'))
DROP TABLE [dbo].[Inventory]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groups]') AND type in (N'U'))
DROP TABLE [dbo].[groups]
GO
/****** Object:  Table [dbo].[groupObject]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupObject]') AND type in (N'U'))
DROP TABLE [dbo].[groupObject]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expenses]') AND type in (N'U'))
DROP TABLE [dbo].[Expenses]
GO
/****** Object:  Table [dbo].[error]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[error]') AND type in (N'U'))
DROP TABLE [dbo].[error]
GO
/****** Object:  Table [dbo].[docImages]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[docImages]') AND type in (N'U'))
DROP TABLE [dbo].[docImages]
GO
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[couponsInvoices]') AND type in (N'U'))
DROP TABLE [dbo].[couponsInvoices]
GO
/****** Object:  Table [dbo].[coupons]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[coupons]') AND type in (N'U'))
DROP TABLE [dbo].[coupons]
GO
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[countriesCodes]') AND type in (N'U'))
DROP TABLE [dbo].[countriesCodes]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cities]') AND type in (N'U'))
DROP TABLE [dbo].[cities]
GO
/****** Object:  Table [dbo].[categoryuser]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categoryuser]') AND type in (N'U'))
DROP TABLE [dbo].[categoryuser]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categories]') AND type in (N'U'))
DROP TABLE [dbo].[categories]
GO
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cashTransfer]') AND type in (N'U'))
DROP TABLE [dbo].[cashTransfer]
GO
/****** Object:  Table [dbo].[cards]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cards]') AND type in (N'U'))
DROP TABLE [dbo].[cards]
GO
/****** Object:  Table [dbo].[branchStore]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchStore]') AND type in (N'U'))
DROP TABLE [dbo].[branchStore]
GO
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branchesUsers]') AND type in (N'U'))
DROP TABLE [dbo].[branchesUsers]
GO
/****** Object:  Table [dbo].[branches]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[branches]') AND type in (N'U'))
DROP TABLE [dbo].[branches]
GO
/****** Object:  Table [dbo].[bondes]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bondes]') AND type in (N'U'))
DROP TABLE [dbo].[bondes]
GO
/****** Object:  Table [dbo].[banks]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[banks]') AND type in (N'U'))
DROP TABLE [dbo].[banks]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agents]') AND type in (N'U'))
DROP TABLE [dbo].[agents]
GO
/****** Object:  Table [dbo].[agentMemberships]    Script Date: 06/12/2021 03:10:50 م ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agentMemberships]') AND type in (N'U'))
DROP TABLE [dbo].[agentMemberships]
GO
/****** Object:  Table [dbo].[agentMemberships]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[agents]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[banks]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[bondes]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[branches]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[branchesUsers]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[branchStore]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[cards]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[cashTransfer]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[categories]    Script Date: 06/12/2021 03:10:50 م ******/
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
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoryuser]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[cities]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[countriesCodes]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[coupons]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[couponsInvoices]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[docImages]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[error]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[Expenses]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[groupObject]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[groups]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[Inventory]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[inventoryItemLocation]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[invoiceOrder]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[invoices]    Script Date: 06/12/2021 03:10:50 م ******/
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
 CONSTRAINT [PK_invoices] PRIMARY KEY CLUSTERED 
(
	[invoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoiceStatus]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[items]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[itemsLocations]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[itemsMaterials]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[itemsOffers]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[itemsProp]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[itemsTransfer]    Script Date: 06/12/2021 03:10:50 م ******/
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
 CONSTRAINT [PK_itemsTransfer] PRIMARY KEY CLUSTERED 
(
	[itemsTransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsUnits]    Script Date: 06/12/2021 03:10:50 م ******/
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
 CONSTRAINT [PK_itemsUnits] PRIMARY KEY CLUSTERED 
(
	[itemUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemTransferOffer]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[itemUnitUser]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[locations]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[medalAgent]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[medals]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[memberships]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[notification]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[notificationUser]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[objects]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[offers]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[packages]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[paperSize]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[Points]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[pos]    Script Date: 06/12/2021 03:10:50 م ******/
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
 CONSTRAINT [PK_pos] PRIMARY KEY CLUSTERED 
(
	[posId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posSerials]    Script Date: 06/12/2021 03:10:50 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posSerials](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[posSerial] [nvarchar](300) NULL,
	[notes] [nvarchar](300) NULL,
 CONSTRAINT [PK_posSerials] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posSetting]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[posUsers]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[printers]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[ProgramDetails]    Script Date: 06/12/2021 03:10:50 م ******/
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
 CONSTRAINT [PK_ProgramDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[properties]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[propertiesItems]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[sections]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[serials]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[servicesCosts]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[setting]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[setValues]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[shippingCompanies]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[storageCost]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[subscriptionFees]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[sysEmails]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[units]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[userSetValues]    Script Date: 06/12/2021 03:10:50 م ******/
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
/****** Object:  Table [dbo].[usersLogs]    Script Date: 06/12/2021 03:10:50 م ******/
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

INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (1, NULL, N'مهند  أبوشعر ', N'v-000001', N'-', N'', N'', N'', N'+965-999999999', N'57440ff6b80f068efd50410ea24fd593.png', N'v', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:11:49.5676408' AS DateTime2), CAST(N'2021-11-20T15:13:19.4666706' AS DateTime2), 2, 3, N'', 0, N'', CAST(0.000 AS Decimal(20, 3)), 0, N'cash')
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (2, NULL, N'نور   خضير', N'v-000002', N'-', N'', N'mnasani79@gmail.com', N'', N'+965-999999999', N'c37858823db0093766eee74d8ee1f1e5.png', N'v', N'', CAST(217000.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:12:19.6967080' AS DateTime2), CAST(N'2021-12-01T18:28:33.5745080' AS DateTime2), 2, 8, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, N'card')
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (3, NULL, N'ديانا  لقق', N'v-000003', N'-', N'', N'', N'', N'+965-999999999', N'', N'v', N'', CAST(1200.000 AS Decimal(20, 3)), 1, CAST(N'2021-10-27T15:12:33.0447671' AS DateTime2), CAST(N'2021-11-11T14:48:29.7525695' AS DateTime2), 2, 2, N'', 0, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (4, NULL, N'بيان  سليمان', N'v-000004', N'-', N'', N'najyms@gmail.com', N'', N'+965-999999999', N'', N'v', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:12:44.6663568' AS DateTime2), CAST(N'2021-11-23T16:20:46.0821846' AS DateTime2), 2, 8, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, N'')
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (5, NULL, N'أحمد   عقاد', N'v-000005', N'-', N'', N'', N'', N'+965-999999999', N'', N'v', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:12:53.2796985' AS DateTime2), CAST(N'2021-11-02T18:12:56.7503098' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (6, NULL, N'بشار   زيدان', N'v-000006', N'-', N'', N'', N'', N'+965-999999999', N'', N'v', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:13:27.6091463' AS DateTime2), CAST(N'2021-11-23T14:15:32.4413110' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (7, NULL, N'محمد سودة', N'v-000007', N'-', N'', N'', N'', N'+965-999999999', N'', N'v', N'', CAST(8000.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:13:50.1574876' AS DateTime2), CAST(N'2021-11-30T19:04:56.6809004' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (8, NULL, N'محمد   بهلوان', N'v-000008', N'-', N'', N'', N'', N'+965-999999999', N'', N'v', N'', CAST(12000.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:14:17.4118824' AS DateTime2), CAST(N'2021-11-30T19:05:49.5250539' AS DateTime2), 2, 9, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (10, NULL, N'سمر  كركوتلي', N'c-000001', N'-', N'', N'', N'', N'+965-999999999', N'0f26776e0a524c7d2b6b5f771d500980.png', N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:17:40.1806115' AS DateTime2), CAST(N'2021-11-20T17:12:01.9171295' AS DateTime2), 2, 9, N'', 0, N'', CAST(0.000 AS Decimal(20, 3)), 0, N'')
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (11, NULL, N'عمر  الحراكي', N'c-000002', N'-', N'', N'mnasani79@gmail.com', N'', N'+965-999999999', N'05da7ccc8020731d607471318fc4f35b.png', N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:18:03.7480896' AS DateTime2), CAST(N'2021-11-23T16:20:09.8069245' AS DateTime2), 2, 8, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, N'')
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (12, NULL, N'عمر  طيفور', N'c-000003', N'-', N'', N'najyms@gmail.com', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:18:11.1610752' AS DateTime2), CAST(N'2021-11-23T16:20:27.7209656' AS DateTime2), 2, 8, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, N'')
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (13, NULL, N'عمر   معروف', N'c-000004', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:18:30.1346722' AS DateTime2), CAST(N'2021-10-27T15:18:30.1346722' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (14, NULL, N'أمل  زيدان', N'c-000005', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:18:37.5448873' AS DateTime2), CAST(N'2021-11-16T18:40:27.5721448' AS DateTime2), 2, 2, N'', 0, N'', CAST(0.000 AS Decimal(20, 3)), 0, N'balance')
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (15, NULL, N'قمر   كعكة', N'c-000006', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:18:44.0218635' AS DateTime2), CAST(N'2021-10-30T17:59:13.5502960' AS DateTime2), 2, 9, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (16, NULL, N'طارق غباش', N'c-000007', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:18:50.2411871' AS DateTime2), CAST(N'2021-11-02T17:06:01.1718709' AS DateTime2), 2, 9, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (17, NULL, N'طه المحجوب', N'c-000008', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:18:58.8492665' AS DateTime2), CAST(N'2021-10-27T15:18:58.8492665' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (18, NULL, N'لونا  آغا', N'c-000009', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:19:06.3860700' AS DateTime2), CAST(N'2021-10-27T15:19:06.3860700' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (19, NULL, N'ايمن  البكر', N'c-000010', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:19:13.0971061' AS DateTime2), CAST(N'2021-10-27T15:19:13.0971061' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (20, NULL, N'هلا  بكداش', N'c-000011', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:19:23.3113045' AS DateTime2), CAST(N'2021-10-27T15:19:23.3113045' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (21, NULL, N'اية  الأحمد', N'c-000012', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:19:29.5005060' AS DateTime2), CAST(N'2021-10-27T15:19:29.5005060' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (22, NULL, N'ندى ادلبي', N'c-000013', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:19:45.0112595' AS DateTime2), CAST(N'2021-10-27T15:19:45.0112595' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (23, NULL, N'جود  كرزة', N'c-000014', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:20:00.8917664' AS DateTime2), CAST(N'2021-10-27T15:20:00.8917664' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (24, NULL, N'غيثاء والي', N'c-000015', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:20:09.9584705' AS DateTime2), CAST(N'2021-11-06T14:28:11.2077345' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (25, NULL, N'جمانة كرزة', N'c-000016', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:20:24.3446658' AS DateTime2), CAST(N'2021-10-27T15:20:24.3446658' AS DateTime2), 2, 2, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, NULL)
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (26, NULL, N'راما حمامي', N'c-000017', N'-', N'', N'', N'', N'+965-999999999', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T15:20:35.6449724' AS DateTime2), CAST(N'2021-11-16T14:04:38.7177439' AS DateTime2), 2, 9, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, N'balance')
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (42, NULL, N'name', N'c-000019', N'company', N'address', N'', N'+965--557855', N'+965-89845', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-11-16T13:14:44.8320540' AS DateTime2), CAST(N'2021-11-16T14:04:30.9193999' AS DateTime2), 3, 9, N'notes', 1, N'+965--5554', CAST(0.000 AS Decimal(20, 3)), 0, N'multiple')
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (43, NULL, N'wwww', N'c-000020', N'wwww', N'', N'', N'', N'+965-785322366', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-11-16T14:05:28.3185105' AS DateTime2), CAST(N'2021-11-16T14:05:28.3185105' AS DateTime2), 9, 9, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, N'cash')
INSERT [dbo].[agents] ([agentId], [pointId], [name], [code], [company], [address], [email], [phone], [mobile], [image], [type], [accType], [balance], [balanceType], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive], [fax], [maxDeserve], [isLimited], [payType]) VALUES (45, NULL, N'Mohamad Naser', N'c-000021', N'msnns', N'', N'd@d.com', N'', N'+965-966554445', NULL, N'c', N'', CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-11-29T15:01:54.6580262' AS DateTime2), CAST(N'2021-11-29T15:01:54.6580262' AS DateTime2), 1, 1, N'', 1, N'', CAST(0.000 AS Decimal(20, 3)), 0, N'cash')
SET IDENTITY_INSERT [dbo].[agents] OFF
GO
SET IDENTITY_INSERT [dbo].[banks] ON 

INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1, N'بنك الكويت', N'+965--111111111', N'+965-111111111', N'', N'5844899481', N'', CAST(N'2021-10-27T17:12:41.3132419' AS DateTime2), CAST(N'2021-10-27T17:12:41.3132419' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'البنك الإسلامي', N'+965--111111111', N'+965-111111111', N'', N'5241975628', N'', CAST(N'2021-10-27T17:12:51.9876187' AS DateTime2), CAST(N'2021-10-27T17:12:51.9876187' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, N'بنك الشارقة', N'+965--111111111', N'+965-111111111', N'', N'1486286545', N'', CAST(N'2021-10-27T17:13:03.4134109' AS DateTime2), CAST(N'2021-10-27T17:13:03.4134109' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (4, N'بنك الأهلي', N'+965--111111111', N'+965-111111111', N'', N'3157865752', N'', CAST(N'2021-10-27T17:13:14.5330873' AS DateTime2), CAST(N'2021-10-27T17:13:14.5330873' AS DateTime2), 2, 2, 1)
INSERT [dbo].[banks] ([bankId], [name], [phone], [mobile], [address], [accNumber], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (5, N'بنك الراجحي', N'+965--111111111', N'+965-111111111', N'', N'3648515547', N'', CAST(N'2021-10-27T17:13:25.2382173' AS DateTime2), CAST(N'2021-11-04T16:18:15.0524093' AS DateTime2), 2, 9, 1)
SET IDENTITY_INSERT [dbo].[banks] OFF
GO
SET IDENTITY_INSERT [dbo].[bondes] ON 

INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (1, N'pbnd-000001', CAST(15000.000 AS Decimal(20, 3)), CAST(N'2021-10-01T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 9, 9, CAST(N'2021-10-30T18:18:48.2346026' AS DateTime2), CAST(N'2021-10-30T18:18:48.2346026' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (2, N'pbnd-000001', CAST(3500.000 AS Decimal(20, 3)), CAST(N'2021-11-10T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-11-10T13:05:54.6914517' AS DateTime2), CAST(N'2021-11-10T13:05:54.6914517' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (3, N'pbnd-000002', CAST(1000.000 AS Decimal(20, 3)), CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-11-10T13:25:45.9301505' AS DateTime2), CAST(N'2021-11-10T13:25:45.9301505' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (4, N'8', CAST(1200.000 AS Decimal(20, 3)), CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 3, 3, CAST(N'2021-11-10T13:28:30.5213527' AS DateTime2), CAST(N'2021-11-10T13:27:49.8370308' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (5, N'56165165', CAST(100000.000 AS Decimal(20, 3)), CAST(N'2021-11-17T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 9, 9, CAST(N'2021-11-11T14:40:17.6357893' AS DateTime2), CAST(N'2021-11-11T14:40:17.6357893' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (6, N'pbnd-000003', CAST(120.000 AS Decimal(20, 3)), CAST(N'2021-11-16T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-11-11T16:23:54.0893151' AS DateTime2), CAST(N'2021-11-11T16:23:54.0893151' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (7, N'55555', CAST(318700.000 AS Decimal(20, 3)), CAST(N'2021-11-11T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 9, 9, CAST(N'2021-11-11T16:34:39.4786089' AS DateTime2), CAST(N'2021-11-11T16:32:38.9500262' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (8, N'pbnd-000004', CAST(250.000 AS Decimal(20, 3)), CAST(N'2021-11-16T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-11-14T11:06:31.3257412' AS DateTime2), CAST(N'2021-11-14T10:50:22.8280593' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (9, N'pbnd-000005', CAST(350.000 AS Decimal(20, 3)), CAST(N'2021-11-18T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-11-14T11:04:34.9821372' AS DateTime2), CAST(N'2021-11-14T10:58:43.3635272' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (10, N'pbnd-000006', CAST(450.000 AS Decimal(20, 3)), CAST(N'2021-11-24T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-11-14T11:11:32.8200893' AS DateTime2), CAST(N'2021-11-14T11:10:08.7006873' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (11, N'987', CAST(1000.000 AS Decimal(20, 3)), CAST(N'2021-11-24T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 3, 3, CAST(N'2021-11-14T11:25:23.6351159' AS DateTime2), CAST(N'2021-11-14T11:23:32.1606654' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (12, N'258', CAST(2500.000 AS Decimal(20, 3)), CAST(N'2021-11-18T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 3, 3, CAST(N'2021-11-14T11:25:44.2761338' AS DateTime2), CAST(N'2021-11-14T11:24:01.2604140' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (13, N'324', CAST(2000.000 AS Decimal(20, 3)), CAST(N'2021-11-20T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 3, 3, CAST(N'2021-11-14T11:26:25.3826539' AS DateTime2), CAST(N'2021-11-14T11:24:31.4696237' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (14, N'986', CAST(5000.000 AS Decimal(20, 3)), CAST(N'2021-11-26T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 3, 3, CAST(N'2021-11-14T11:36:51.4939610' AS DateTime2), CAST(N'2021-11-14T11:35:32.9673281' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (15, N'pbnd-000007', CAST(500.000 AS Decimal(20, 3)), CAST(N'2021-11-29T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-11-14T11:38:30.7142666' AS DateTime2), CAST(N'2021-11-14T11:35:58.4634691' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (16, N'pbnd-000008', CAST(200.000 AS Decimal(20, 3)), CAST(N'2021-11-21T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-11-14T11:58:35.2316929' AS DateTime2), CAST(N'2021-11-14T11:52:28.3014971' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (17, N'pbnd-000009', CAST(250.000 AS Decimal(20, 3)), CAST(N'2021-11-22T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-11-14T11:59:54.4827499' AS DateTime2), CAST(N'2021-11-14T11:53:06.0396017' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (18, N'pbnd-000010', CAST(300.000 AS Decimal(20, 3)), CAST(N'2021-11-23T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-11-14T12:13:29.7971562' AS DateTime2), CAST(N'2021-11-14T11:53:33.9862906' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (19, N'pbnd-000011', CAST(350.000 AS Decimal(20, 3)), CAST(N'2021-11-24T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-11-14T12:17:47.7971664' AS DateTime2), CAST(N'2021-11-14T11:54:10.7875777' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (20, N'777', CAST(400.000 AS Decimal(20, 3)), CAST(N'2021-11-25T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-11-14T11:54:57.1615546' AS DateTime2), CAST(N'2021-11-14T11:54:57.1615546' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (21, N'963', CAST(450.000 AS Decimal(20, 3)), CAST(N'2021-11-26T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-11-14T11:55:52.9875925' AS DateTime2), CAST(N'2021-11-14T11:55:52.9875925' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (22, N'pbnd-000012', CAST(1000.000 AS Decimal(20, 3)), CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-11-16T14:07:23.8449615' AS DateTime2), CAST(N'2021-11-16T14:05:38.3115273' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (23, N'pbnd-000013', CAST(1500.000 AS Decimal(20, 3)), CAST(N'2021-11-19T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-11-16T14:13:39.2906421' AS DateTime2), CAST(N'2021-11-16T14:13:15.3085793' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (24, N'987', CAST(2500.000 AS Decimal(20, 3)), CAST(N'2021-11-17T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 3, 3, CAST(N'2021-11-16T14:27:59.7857230' AS DateTime2), CAST(N'2021-11-16T14:27:27.5601652' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (25, N'545', CAST(3300.000 AS Decimal(20, 3)), CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 2, 2, CAST(N'2021-11-16T18:03:16.8717673' AS DateTime2), CAST(N'2021-11-16T17:46:53.8764018' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (26, N'84651651', CAST(8000.000 AS Decimal(20, 3)), CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 2, 2, CAST(N'2021-11-16T17:48:19.7702486' AS DateTime2), CAST(N'2021-11-16T17:48:19.7702486' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (27, N'pbnd-000001', CAST(1000.000 AS Decimal(20, 3)), CAST(N'2021-11-24T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-11-17T16:09:05.2403643' AS DateTime2), CAST(N'2021-11-17T16:07:04.7959217' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (28, N'pbnd-000002', CAST(1500.000 AS Decimal(20, 3)), CAST(N'2021-11-25T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-11-18T15:54:53.0875044' AS DateTime2), CAST(N'2021-11-18T15:47:15.4498786' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (29, N'pbnd-000003', CAST(500.000 AS Decimal(20, 3)), CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-11-20T15:50:41.6277184' AS DateTime2), CAST(N'2021-11-20T15:50:41.6277184' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (30, N'85', CAST(5000.000 AS Decimal(20, 3)), CAST(N'2021-11-25T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-11-20T15:59:18.4100423' AS DateTime2), CAST(N'2021-11-20T15:59:18.4100423' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (31, N'34567876', CAST(10000.000 AS Decimal(20, 3)), CAST(N'2021-11-25T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 9, 9, CAST(N'2021-11-20T17:23:13.7747871' AS DateTime2), CAST(N'2021-11-20T17:17:49.5028818' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (32, N'23456789', CAST(10000.000 AS Decimal(20, 3)), CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), N'd', 1, NULL, 9, 9, CAST(N'2021-11-20T18:21:38.9487127' AS DateTime2), CAST(N'2021-11-20T17:18:36.7845348' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (33, N'8', CAST(2500.000 AS Decimal(20, 3)), CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 3, 3, CAST(N'2021-11-21T11:51:45.5124528' AS DateTime2), CAST(N'2021-11-21T11:51:45.5124528' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (34, N'pbnd-000001', CAST(500.000 AS Decimal(20, 3)), CAST(N'2021-11-25T00:00:00.0000000' AS DateTime2), N'p', 0, NULL, 3, 3, CAST(N'2021-11-21T11:55:41.5074847' AS DateTime2), CAST(N'2021-11-21T11:55:41.5074847' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (35, N'pbnd-000002', CAST(450.000 AS Decimal(20, 3)), CAST(N'2021-11-26T00:00:00.0000000' AS DateTime2), N'p', 1, NULL, 3, 3, CAST(N'2021-11-21T11:56:42.7738181' AS DateTime2), CAST(N'2021-11-21T11:56:12.5664664' AS DateTime2), NULL, NULL)
INSERT [dbo].[bondes] ([bondId], [number], [amount], [deserveDate], [type], [isRecieved], [notes], [createUserId], [updateUserId], [updateDate], [createDate], [isActive], [cashTransId]) VALUES (36, N'591516516', CAST(2000.000 AS Decimal(20, 3)), CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), N'd', 0, NULL, 9, 9, CAST(N'2021-11-22T15:22:21.0962717' AS DateTime2), CAST(N'2021-11-22T15:22:21.0962717' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[bondes] OFF
GO
SET IDENTITY_INSERT [dbo].[branches] ON 

INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (1, N'00', N'-', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, 1, N'bs')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (2, N'Al-JM-B', N'الجميلية', N'', N'', N'', N'+965-2563897', CAST(N'2021-06-29T15:23:22.3414329' AS DateTime2), CAST(N'2021-11-06T14:48:23.0368623' AS DateTime2), 1, 9, N'', 1, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (3, N'Al-FK-B', N'فرع الفرقان', N'', N'', N'', N'+971-999999999', CAST(N'2021-10-27T14:24:08.2820370' AS DateTime2), CAST(N'2021-10-30T15:11:55.4191973' AS DateTime2), 2, 9, N'', 1, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (4, N'Al-AD-B', N'فرع الأعظمية', N'', N'', N'', N'+971-999999999', CAST(N'2021-10-27T14:24:24.9653144' AS DateTime2), CAST(N'2021-10-27T14:24:24.9653144' AS DateTime2), 2, 2, N'', 1, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (5, N'DM-MA-B', N'فرع مدينة دمشق', N'', N'', N'', N'+971-999999999', CAST(N'2021-10-27T14:24:46.3263099' AS DateTime2), CAST(N'2021-10-27T14:24:46.3263099' AS DateTime2), 2, 2, N'', 1, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (6, N'DM-RF-B', N'فرع ريف دمشق', N'', N'', N'', N'+971-999999999', CAST(N'2021-10-27T14:25:03.0969984' AS DateTime2), CAST(N'2021-10-27T14:25:03.0969984' AS DateTime2), 2, 2, N'', 1, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (7, N'HA-KL-B', N'فرع حماه', N'', N'', N'', N'+971-999999999', CAST(N'2021-10-27T14:25:21.5430652' AS DateTime2), CAST(N'2021-10-27T14:25:21.5430652' AS DateTime2), 2, 2, N'', 1, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (8, N'TR-SF-B', N'فرع طرطوس', N'', N'', N'', N'+971-999999999', CAST(N'2021-10-27T14:25:38.0469279' AS DateTime2), CAST(N'2021-11-04T16:17:36.2704737' AS DateTime2), 2, 9, N'', 1, 1, N'b')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (9, N'Al-JM1-S', N'مخزن الجميلية الأول', N'', N'', N'', N'+965-999999999', CAST(N'2021-10-27T14:26:27.8660593' AS DateTime2), CAST(N'2021-10-27T14:26:27.8660593' AS DateTime2), 2, 2, N'', 2, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (10, N'Al-JM2-S', N'مخزن الجميلية الثاني', N'', N'', N'', N'+965-999999999', CAST(N'2021-10-27T14:26:45.2897657' AS DateTime2), CAST(N'2021-10-30T15:12:23.8648309' AS DateTime2), 2, 9, N'', 2, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (11, N'Al-JF-S', N'مخزن الجميلية - الفرقان', N'', N'', N'', N'+965-999999999', CAST(N'2021-10-27T14:27:13.9685436' AS DateTime2), CAST(N'2021-10-30T15:12:07.4871150' AS DateTime2), 2, 9, N'', 3, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (12, N'Al-FA-S', N'مخزن الفرقان - الأعظمية', N'', N'', N'', N'+965-999999999', CAST(N'2021-10-27T14:27:43.5399303' AS DateTime2), CAST(N'2021-10-27T14:27:43.5399303' AS DateTime2), 2, 2, N'', 3, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (13, N'DM-MA-S', N'مخزن الشام', N'', N'', N'', N'+965-999999999', CAST(N'2021-10-27T14:28:08.0064517' AS DateTime2), CAST(N'2021-10-27T14:28:08.0064517' AS DateTime2), 2, 2, N'', 5, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (14, N'HA-KL-S', N'مخزن حماه', N'', N'', N'', N'+965-999999999', CAST(N'2021-10-27T14:28:26.6662160' AS DateTime2), CAST(N'2021-10-27T14:28:26.6662160' AS DateTime2), 2, 2, N'', 7, 1, N's')
INSERT [dbo].[branches] ([branchId], [code], [name], [address], [email], [phone], [mobile], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [parentId], [isActive], [type]) VALUES (15, N'TR-SF-S', N'مخزن طرطوس', N'', N'', N'', N'+965-999999999', CAST(N'2021-10-27T14:28:41.9238311' AS DateTime2), CAST(N'2021-11-04T16:17:54.2710182' AS DateTime2), 2, 9, N'', 8, 1, N's')
SET IDENTITY_INSERT [dbo].[branches] OFF
GO
SET IDENTITY_INSERT [dbo].[branchesUsers] ON 

INSERT [dbo].[branchesUsers] ([branchsUsersId], [branchId], [userId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (1, 2, 9, CAST(N'2021-10-28T17:17:21.7328661' AS DateTime2), CAST(N'2021-10-28T17:17:21.7328661' AS DateTime2), 9, 9)
INSERT [dbo].[branchesUsers] ([branchsUsersId], [branchId], [userId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (2, 3, 9, CAST(N'2021-10-28T17:17:21.7466440' AS DateTime2), CAST(N'2021-10-28T17:17:21.7466440' AS DateTime2), 9, 9)
SET IDENTITY_INSERT [dbo].[branchesUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[branchStore] ON 

INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (4, 2, 4, NULL, CAST(N'2021-11-03T15:19:37.6075528' AS DateTime2), CAST(N'2021-11-03T15:19:37.6075528' AS DateTime2), 3, 3, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (5, 2, 3, NULL, CAST(N'2021-11-03T15:19:37.6069312' AS DateTime2), CAST(N'2021-11-03T15:19:37.6069312' AS DateTime2), 9, 9, 1)
INSERT [dbo].[branchStore] ([id], [branchId], [storeId], [note], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (6, 2, 2, NULL, CAST(N'2021-11-03T15:19:37.6075528' AS DateTime2), CAST(N'2021-11-03T15:19:37.6075528' AS DateTime2), 9, 9, 1)
SET IDENTITY_INSERT [dbo].[branchStore] OFF
GO
SET IDENTITY_INSERT [dbo].[cards] ON 

INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [image], [hasProcessNum]) VALUES (1, N'Visa Card', N'', CAST(N'2021-10-27T17:16:10.0411383' AS DateTime2), CAST(N'2021-10-27T17:24:41.7960806' AS DateTime2), 2, 2, 1, N'57440ff6b80f068efd50410ea24fd593.png', 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [image], [hasProcessNum]) VALUES (2, N'Master Card', N'', CAST(N'2021-10-27T17:16:13.3548331' AS DateTime2), CAST(N'2021-11-04T16:19:20.6480239' AS DateTime2), 9, 9, 1, N'c37858823db0093766eee74d8ee1f1e5.png', 1)
INSERT [dbo].[cards] ([cardId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [image], [hasProcessNum]) VALUES (3, N'K-net', N'', CAST(N'2021-10-27T17:17:01.4593550' AS DateTime2), CAST(N'2021-11-20T14:24:01.3276499' AS DateTime2), 9, 9, 1, N'71f020248a405d21e94d1de52043bed4.png', 1)
SET IDENTITY_INSERT [dbo].[cards] OFF
GO
SET IDENTITY_INSERT [dbo].[cashTransfer] ON 

INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1318, NULL, N'd', 1, NULL, 2, 1179, N'dv-000001', CAST(N'2021-11-30T19:03:43.2901463' AS DateTime2), CAST(N'2021-11-30T19:03:43.2901463' AS DateTime2), CAST(5000.000 AS Decimal(20, 3)), 2, 2, NULL, NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1319, NULL, N'd', 1, NULL, 7, 1180, N'dv-000002', CAST(N'2021-11-30T19:04:54.7121612' AS DateTime2), CAST(N'2021-11-30T19:04:54.7121612' AS DateTime2), CAST(8000.000 AS Decimal(20, 3)), 2, 2, NULL, NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1320, NULL, N'd', 1, NULL, 8, 1181, N'dv-000003', CAST(N'2021-11-30T19:05:47.4310464' AS DateTime2), CAST(N'2021-11-30T19:05:47.4310464' AS DateTime2), CAST(12000.000 AS Decimal(20, 3)), 2, 2, NULL, NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1321, NULL, N'p', 1, NULL, NULL, 1182, N'pc-000001', CAST(N'2021-11-30T19:09:33.4310753' AS DateTime2), CAST(N'2021-11-30T19:09:33.4310753' AS DateTime2), CAST(1200.000 AS Decimal(20, 3)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1322, NULL, N'd', 1, NULL, NULL, 1182, N'dc-000001', CAST(N'2021-11-30T19:09:37.7128102' AS DateTime2), CAST(N'2021-11-30T19:09:37.7128102' AS DateTime2), CAST(1200.000 AS Decimal(20, 3)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1323, NULL, N'p', 1, NULL, NULL, 1183, N'pc-000002', CAST(N'2021-11-30T19:18:58.9260016' AS DateTime2), CAST(N'2021-11-30T19:18:58.9260016' AS DateTime2), CAST(1000.000 AS Decimal(20, 3)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1324, NULL, N'd', 1, NULL, NULL, 1183, N'dc-000002', CAST(N'2021-11-30T19:19:02.3946762' AS DateTime2), CAST(N'2021-11-30T19:19:02.3946762' AS DateTime2), CAST(1000.000 AS Decimal(20, 3)), 2, 2, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1325, NULL, N'p', 1, NULL, NULL, 1184, N'pc-000003', CAST(N'2021-12-01T14:02:28.9377985' AS DateTime2), CAST(N'2021-12-01T14:02:28.9377985' AS DateTime2), CAST(1200.000 AS Decimal(20, 3)), 3, 3, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1326, NULL, N'd', 1, NULL, NULL, 1184, N'dc-000003', CAST(N'2021-12-01T14:02:33.8957018' AS DateTime2), CAST(N'2021-12-01T14:02:33.8957018' AS DateTime2), CAST(1200.000 AS Decimal(20, 3)), 3, 3, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1327, NULL, N'p', 1, NULL, NULL, 1185, N'pc-000004', CAST(N'2021-12-01T14:07:47.0024031' AS DateTime2), CAST(N'2021-12-01T14:07:47.0024031' AS DateTime2), CAST(3600.000 AS Decimal(20, 3)), 3, 3, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1328, NULL, N'd', 1, NULL, NULL, 1185, N'dc-000004', CAST(N'2021-12-01T14:07:51.2112074' AS DateTime2), CAST(N'2021-12-01T14:07:51.2112074' AS DateTime2), CAST(3600.000 AS Decimal(20, 3)), 3, 3, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1329, NULL, N'p', 1, NULL, NULL, 1186, N'pc-000005', CAST(N'2021-12-01T14:34:05.4635770' AS DateTime2), CAST(N'2021-12-01T14:34:05.4635770' AS DateTime2), CAST(2390.000 AS Decimal(20, 3)), 8, 8, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1330, NULL, N'd', 1, NULL, NULL, 1186, N'dc-000005', CAST(N'2021-12-01T14:34:09.5961823' AS DateTime2), CAST(N'2021-12-01T14:34:09.5961823' AS DateTime2), CAST(2390.000 AS Decimal(20, 3)), 8, 8, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1331, NULL, N'p', 1, NULL, NULL, 1187, N'pc-000006', CAST(N'2021-12-01T14:34:47.0007351' AS DateTime2), CAST(N'2021-12-01T14:34:47.0007351' AS DateTime2), CAST(2300.000 AS Decimal(20, 3)), 8, 8, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1332, NULL, N'd', 1, NULL, NULL, 1187, N'dc-000006', CAST(N'2021-12-01T14:34:50.4613632' AS DateTime2), CAST(N'2021-12-01T14:34:50.4613632' AS DateTime2), CAST(2300.000 AS Decimal(20, 3)), 8, 8, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1333, NULL, N'p', 1, NULL, NULL, 1188, N'pc-000007', CAST(N'2021-12-01T15:19:43.0723673' AS DateTime2), CAST(N'2021-12-01T15:19:43.0723673' AS DateTime2), CAST(2290.000 AS Decimal(20, 3)), 8, 8, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1334, NULL, N'd', 1, NULL, NULL, 1188, N'dc-000007', CAST(N'2021-12-01T15:19:46.6274790' AS DateTime2), CAST(N'2021-12-01T15:19:46.6274790' AS DateTime2), CAST(2290.000 AS Decimal(20, 3)), 8, 8, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1335, NULL, N'd', 1, NULL, 2, 1194, N'dv-000004', CAST(N'2021-12-01T18:28:31.4605599' AS DateTime2), CAST(N'2021-12-01T18:28:31.4605599' AS DateTime2), CAST(212000.000 AS Decimal(20, 3)), 8, 8, NULL, NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1336, NULL, N'p', 1, NULL, 11, 1195, N'pc-000008', CAST(N'2021-12-01T18:31:05.3817598' AS DateTime2), CAST(N'2021-12-01T18:31:05.3817598' AS DateTime2), CAST(302000.000 AS Decimal(20, 3)), 8, 8, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1337, NULL, N'd', 1, NULL, 11, 1195, N'dc-000008', CAST(N'2021-12-01T18:31:08.7657503' AS DateTime2), CAST(N'2021-12-01T18:31:08.7657503' AS DateTime2), CAST(302000.000 AS Decimal(20, 3)), 8, 8, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1338, NULL, N'p', 1, NULL, NULL, 1196, N'pc-000009', CAST(N'2021-12-01T18:35:02.7252354' AS DateTime2), CAST(N'2021-12-01T18:35:02.7252354' AS DateTime2), CAST(1100.000 AS Decimal(20, 3)), 8, 8, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1339, NULL, N'd', 1, NULL, NULL, 1196, N'dc-000009', CAST(N'2021-12-01T18:35:06.2559119' AS DateTime2), CAST(N'2021-12-01T18:35:06.2559119' AS DateTime2), CAST(1100.000 AS Decimal(20, 3)), 8, 8, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1340, NULL, N'd', 1, NULL, NULL, 1198, N'dv-000005', CAST(N'2021-12-06T13:22:45.5856537' AS DateTime2), CAST(N'2021-12-06T13:22:45.5856537' AS DateTime2), CAST(1250.000 AS Decimal(20, 3)), 3, 3, NULL, NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'inv', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1341, NULL, N'p', 1, NULL, NULL, 1198, N'pv-000001', CAST(N'2021-12-06T13:22:48.2421975' AS DateTime2), CAST(N'2021-12-06T13:22:48.2421975' AS DateTime2), CAST(1250.000 AS Decimal(20, 3)), 3, 3, NULL, NULL, NULL, NULL, N'c', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1342, NULL, N'd', 1, NULL, NULL, NULL, N'dsh-000001', CAST(N'2021-12-06T13:40:10.8002029' AS DateTime2), CAST(N'2021-12-06T13:40:10.8002029' AS DateTime2), CAST(1000.000 AS Decimal(20, 3)), 3, 3, N'', NULL, NULL, NULL, N'sh', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, 2)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1343, NULL, N'p', 1, NULL, 3, NULL, N'pv-000002', CAST(N'2021-12-06T14:41:39.0589506' AS DateTime2), CAST(N'2021-12-06T14:41:39.0589506' AS DateTime2), CAST(1200.000 AS Decimal(20, 3)), 3, 3, N'', NULL, NULL, NULL, N'v', NULL, NULL, NULL, NULL, N'cash', NULL, NULL, NULL)
INSERT [dbo].[cashTransfer] ([cashTransId], [agentMembershipsId], [transType], [posId], [userId], [agentId], [invId], [transNum], [createDate], [updateDate], [cash], [updateUserId], [createUserId], [notes], [posIdCreator], [isConfirm], [cashTransIdSource], [side], [docName], [docNum], [docImage], [bankId], [processType], [cardId], [bondId], [shippingCompanyId]) VALUES (1344, NULL, N'p', 1, NULL, NULL, NULL, N'psh-000001', CAST(N'2021-12-06T14:42:33.2624869' AS DateTime2), CAST(N'2021-12-06T14:42:33.2624869' AS DateTime2), CAST(2000.000 AS Decimal(20, 3)), 3, 3, N'', NULL, NULL, NULL, N'sh', NULL, N'58', NULL, NULL, N'cheque', NULL, NULL, 3)
SET IDENTITY_INSERT [dbo].[cashTransfer] OFF
GO
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (1, N'EL', N'الكترونيات', N'', N'57440ff6b80f068efd50410ea24fd593.jfif', 1, CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T17:40:52.2309017' AS DateTime2), CAST(N'2021-10-30T16:41:34.8562818' AS DateTime2), 2, 9, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (2, N'EL-PR', N'طابعات', N'', N'c37858823db0093766eee74d8ee1f1e5.png', 1, CAST(0.000 AS Decimal(20, 3)), 1, CAST(N'2021-10-27T17:41:09.9011683' AS DateTime2), CAST(N'2021-10-30T16:41:34.8562818' AS DateTime2), 2, 9, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (3, N'EL-PG', N'برامج', N'', N'71f020248a405d21e94d1de52043bed4.png', 1, CAST(0.000 AS Decimal(20, 3)), 1, CAST(N'2021-10-27T17:41:27.2134436' AS DateTime2), CAST(N'2021-10-30T16:41:34.8562818' AS DateTime2), 2, 9, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (4, N'EL-MB', N'جوالات', N'', N'd2ec5f1ed83abfca0dfec76506b696b3.jpg', 1, CAST(0.000 AS Decimal(20, 3)), 1, CAST(N'2021-10-27T17:41:42.4217607' AS DateTime2), CAST(N'2021-10-30T16:41:34.8719743' AS DateTime2), 2, 9, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (5, N'FD', N'غذائية', N'', N'f96f8a89e2143f1e43a2ba7953fb5413.jpg', 1, CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T17:42:05.5571653' AS DateTime2), CAST(N'2021-10-27T17:52:57.7699761' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (6, N'FD-CD', N'معلبات', N'', N'56a2e0231c3d394ace201adf37d13f63.jpg', 1, CAST(0.000 AS Decimal(20, 3)), 5, CAST(N'2021-10-27T17:42:22.1008295' AS DateTime2), CAST(N'2021-10-27T17:52:57.7775320' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (7, N'FD-FV', N'خضار وفواكه', N'', N'3204215c19f25609034d24451f7e03d7.jpg', 1, CAST(0.000 AS Decimal(20, 3)), 5, CAST(N'2021-10-27T17:43:24.9086347' AS DateTime2), CAST(N'2021-10-27T17:52:57.7806468' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (8, N'FD-CT', N'حلويات', N'', N'6a5d62c1233b5e9b2000dd13aadf81f4.jpg', 1, CAST(0.000 AS Decimal(20, 3)), 5, CAST(N'2021-10-27T17:43:38.3444078' AS DateTime2), CAST(N'2021-10-27T17:52:57.7832792' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (9, N'FD-SD', N'مشروبات غازية', N'', N'6eaba1dc3c031faf262149c058fea728.jpeg', 1, CAST(0.000 AS Decimal(20, 3)), 5, CAST(N'2021-10-27T17:43:51.6797013' AS DateTime2), CAST(N'2021-10-27T17:52:57.7864809' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (10, N'CL', N'ملابس', N'', N'0f26776e0a524c7d2b6b5f771d500980.jfif', 1, CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T17:44:08.3525929' AS DateTime2), CAST(N'2021-10-30T16:41:10.3403996' AS DateTime2), 2, 9, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (11, N'MD', N'أدوية', N'', N'05da7ccc8020731d607471318fc4f35b.png', 1, CAST(0.000 AS Decimal(20, 3)), 0, CAST(N'2021-10-27T17:44:21.9632757' AS DateTime2), CAST(N'2021-10-27T17:53:16.0444182' AS DateTime2), 2, 2, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (12, N'CL-MN', N'رجالي', N'', N'0731f29a7d8c55ddab810a076d078aff.jfif', 1, CAST(0.000 AS Decimal(20, 3)), 10, CAST(N'2021-10-27T17:44:34.4124589' AS DateTime2), CAST(N'2021-10-30T16:41:22.3251012' AS DateTime2), 2, 9, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (13, N'CL-WM', N'نسائي', N'', N'd24538a57424ec2d36086326b9215b74.jpg', 1, CAST(0.000 AS Decimal(20, 3)), 10, CAST(N'2021-10-27T17:44:50.3460735' AS DateTime2), CAST(N'2021-10-30T16:41:10.3875107' AS DateTime2), 2, 9, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (14, N'CL-CH', N'أطفال', N'', N'ad4bfd50185ef68bce2b903aa7e10ec0.jpg', 1, CAST(0.000 AS Decimal(20, 3)), 10, CAST(N'2021-10-27T17:45:02.0898263' AS DateTime2), CAST(N'2021-10-30T16:41:10.3875107' AS DateTime2), 2, 9, NULL)
INSERT [dbo].[categories] ([categoryId], [categoryCode], [name], [details], [image], [isActive], [taxes], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (15, N'CL-BB', N'ديارة', N'', N'cfba0c3306a45ea0746c531906c58962.jpeg', 1, CAST(0.000 AS Decimal(20, 3)), 10, CAST(N'2021-10-27T17:45:13.4844779' AS DateTime2), CAST(N'2021-10-30T16:41:10.4032116' AS DateTime2), 2, 9, NULL)
SET IDENTITY_INSERT [dbo].[categories] OFF
GO
SET IDENTITY_INSERT [dbo].[categoryuser] ON 

INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (1, 1, 1, 1, CAST(N'2021-10-27T17:40:52.3629042' AS DateTime2), CAST(N'2021-10-27T17:40:52.3629042' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (2, 1, 2, 1, CAST(N'2021-10-27T17:40:52.3687457' AS DateTime2), CAST(N'2021-10-27T17:40:52.3687457' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (3, 1, 3, 1, CAST(N'2021-10-27T17:40:52.3698450' AS DateTime2), CAST(N'2021-10-27T17:40:52.3698450' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (4, 1, 4, 1, CAST(N'2021-10-27T17:40:52.3719701' AS DateTime2), CAST(N'2021-10-27T17:40:52.3719701' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (5, 1, 5, 1, CAST(N'2021-10-27T17:40:52.3735855' AS DateTime2), CAST(N'2021-10-27T17:40:52.3735855' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (6, 1, 6, 1, CAST(N'2021-10-27T17:40:52.3746134' AS DateTime2), CAST(N'2021-10-27T17:40:52.3746134' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (7, 1, 7, 1, CAST(N'2021-10-27T17:40:52.3767555' AS DateTime2), CAST(N'2021-10-27T17:40:52.3767555' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (8, 1, 8, 1, CAST(N'2021-10-27T17:40:52.3783984' AS DateTime2), CAST(N'2021-10-27T17:40:52.3783984' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (9, 1, 9, 1, CAST(N'2021-10-27T17:40:52.3794735' AS DateTime2), CAST(N'2021-10-27T17:40:52.3794735' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (10, 1, 10, 1, CAST(N'2021-10-27T17:40:52.3816622' AS DateTime2), CAST(N'2021-10-27T17:40:52.3816622' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (11, 1, 11, 1, CAST(N'2021-10-27T17:40:52.3833532' AS DateTime2), CAST(N'2021-10-27T17:40:52.3833532' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (12, 2, 1, 2, CAST(N'2021-10-27T17:41:09.9097410' AS DateTime2), CAST(N'2021-10-27T17:41:09.9097410' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (13, 2, 2, 2, CAST(N'2021-10-27T17:41:09.9107768' AS DateTime2), CAST(N'2021-10-27T17:41:09.9107768' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (14, 2, 3, 2, CAST(N'2021-10-27T17:41:09.9128782' AS DateTime2), CAST(N'2021-10-27T17:41:09.9128782' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (15, 2, 4, 2, CAST(N'2021-10-27T17:41:09.9144727' AS DateTime2), CAST(N'2021-10-27T17:41:09.9144727' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (16, 2, 5, 2, CAST(N'2021-10-27T17:41:09.9165917' AS DateTime2), CAST(N'2021-10-27T17:41:09.9165917' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (17, 2, 6, 2, CAST(N'2021-10-27T17:41:09.9186782' AS DateTime2), CAST(N'2021-10-27T17:41:09.9186782' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (18, 2, 7, 2, CAST(N'2021-10-27T17:41:09.9207910' AS DateTime2), CAST(N'2021-10-27T17:41:09.9207910' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (19, 2, 8, 2, CAST(N'2021-10-27T17:41:09.9224333' AS DateTime2), CAST(N'2021-10-27T17:41:09.9224333' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (20, 2, 9, 2, CAST(N'2021-10-27T17:41:09.9245541' AS DateTime2), CAST(N'2021-10-27T17:41:09.9245541' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (21, 2, 10, 2, CAST(N'2021-10-27T17:41:09.9266398' AS DateTime2), CAST(N'2021-10-27T17:41:09.9266398' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (22, 2, 11, 2, CAST(N'2021-10-27T17:41:09.9283060' AS DateTime2), CAST(N'2021-10-27T17:41:09.9283060' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (23, 3, 1, 3, CAST(N'2021-10-27T17:41:27.2166031' AS DateTime2), CAST(N'2021-10-27T17:41:27.2166031' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (24, 3, 2, 3, CAST(N'2021-10-27T17:41:27.2182973' AS DateTime2), CAST(N'2021-10-27T17:41:27.2182973' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (25, 3, 3, 3, CAST(N'2021-10-27T17:41:27.2193395' AS DateTime2), CAST(N'2021-10-27T17:41:27.2193395' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (26, 3, 4, 3, CAST(N'2021-10-27T17:41:27.2214171' AS DateTime2), CAST(N'2021-10-27T17:41:27.2214171' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (27, 3, 5, 3, CAST(N'2021-10-27T17:41:27.2234873' AS DateTime2), CAST(N'2021-10-27T17:41:27.2234873' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (28, 3, 6, 3, CAST(N'2021-10-27T17:41:27.2250855' AS DateTime2), CAST(N'2021-10-27T17:41:27.2250855' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (29, 3, 7, 3, CAST(N'2021-10-27T17:41:27.2261451' AS DateTime2), CAST(N'2021-10-27T17:41:27.2261451' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (30, 3, 8, 3, CAST(N'2021-10-27T17:41:27.2282280' AS DateTime2), CAST(N'2021-10-27T17:41:27.2282280' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (31, 3, 9, 3, CAST(N'2021-10-27T17:41:27.2299116' AS DateTime2), CAST(N'2021-10-27T17:41:27.2299116' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (32, 3, 10, 3, CAST(N'2021-10-27T17:41:27.2320079' AS DateTime2), CAST(N'2021-10-27T17:41:27.2320079' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (33, 3, 11, 3, CAST(N'2021-10-27T17:41:27.2341172' AS DateTime2), CAST(N'2021-10-27T17:41:27.2341172' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (34, 4, 1, 4, CAST(N'2021-10-27T17:41:42.4244379' AS DateTime2), CAST(N'2021-10-27T17:41:42.4244379' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (35, 4, 2, 4, CAST(N'2021-10-27T17:41:42.4255136' AS DateTime2), CAST(N'2021-10-27T17:41:42.4255136' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (36, 4, 3, 4, CAST(N'2021-10-27T17:41:42.4265639' AS DateTime2), CAST(N'2021-10-27T17:41:42.4265639' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (37, 4, 4, 4, CAST(N'2021-10-27T17:41:42.4287188' AS DateTime2), CAST(N'2021-10-27T17:41:42.4287188' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (38, 4, 5, 4, CAST(N'2021-10-27T17:41:42.4303508' AS DateTime2), CAST(N'2021-10-27T17:41:42.4303508' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (39, 4, 6, 4, CAST(N'2021-10-27T17:41:42.4314301' AS DateTime2), CAST(N'2021-10-27T17:41:42.4314301' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (40, 4, 7, 4, CAST(N'2021-10-27T17:41:42.4336173' AS DateTime2), CAST(N'2021-10-27T17:41:42.4336173' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (41, 4, 8, 4, CAST(N'2021-10-27T17:41:42.4352120' AS DateTime2), CAST(N'2021-10-27T17:41:42.4352120' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (42, 4, 9, 4, CAST(N'2021-10-27T17:41:42.4373262' AS DateTime2), CAST(N'2021-10-27T17:41:42.4373262' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (43, 4, 10, 4, CAST(N'2021-10-27T17:41:42.4394525' AS DateTime2), CAST(N'2021-10-27T17:41:42.4394525' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (44, 4, 11, 4, CAST(N'2021-10-27T17:41:42.4410544' AS DateTime2), CAST(N'2021-10-27T17:41:42.4410544' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (45, 5, 1, 5, CAST(N'2021-10-27T17:42:05.5609480' AS DateTime2), CAST(N'2021-10-27T17:42:05.5609480' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (46, 5, 2, 5, CAST(N'2021-10-27T17:42:05.5630130' AS DateTime2), CAST(N'2021-10-27T17:42:05.5630130' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (47, 5, 3, 5, CAST(N'2021-10-27T17:42:05.5646457' AS DateTime2), CAST(N'2021-10-27T17:42:05.5646457' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (48, 5, 4, 5, CAST(N'2021-10-27T17:42:05.5667543' AS DateTime2), CAST(N'2021-10-27T17:42:05.5667543' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (49, 5, 5, 5, CAST(N'2021-10-27T17:42:05.5688672' AS DateTime2), CAST(N'2021-10-27T17:42:05.5688672' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (50, 5, 6, 5, CAST(N'2021-10-27T17:42:05.5705006' AS DateTime2), CAST(N'2021-10-27T17:42:05.5705006' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (51, 5, 7, 5, CAST(N'2021-10-27T17:42:05.5715464' AS DateTime2), CAST(N'2021-10-27T17:42:05.5715464' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (52, 5, 8, 5, CAST(N'2021-10-27T17:42:05.5736364' AS DateTime2), CAST(N'2021-10-27T17:42:05.5736364' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (53, 5, 9, 5, CAST(N'2021-10-27T17:42:05.5757406' AS DateTime2), CAST(N'2021-10-27T17:42:05.5757406' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (54, 5, 10, 5, CAST(N'2021-10-27T17:42:05.5773147' AS DateTime2), CAST(N'2021-10-27T17:42:05.5773147' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (55, 5, 11, 5, CAST(N'2021-10-27T17:42:05.5794811' AS DateTime2), CAST(N'2021-10-27T17:42:05.5794811' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (56, 6, 1, 6, CAST(N'2021-10-27T17:42:22.1040401' AS DateTime2), CAST(N'2021-10-27T17:42:22.1040401' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (57, 6, 2, 6, CAST(N'2021-10-27T17:42:22.1057675' AS DateTime2), CAST(N'2021-10-27T17:42:22.1057675' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (58, 6, 3, 6, CAST(N'2021-10-27T17:42:22.1078582' AS DateTime2), CAST(N'2021-10-27T17:42:22.1078582' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (59, 6, 4, 6, CAST(N'2021-10-27T17:42:22.1089637' AS DateTime2), CAST(N'2021-10-27T17:42:22.1089637' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (60, 6, 5, 6, CAST(N'2021-10-27T17:42:22.1105730' AS DateTime2), CAST(N'2021-10-27T17:42:22.1105730' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (61, 6, 6, 6, CAST(N'2021-10-27T17:42:22.1126834' AS DateTime2), CAST(N'2021-10-27T17:42:22.1126834' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (62, 6, 7, 6, CAST(N'2021-10-27T17:42:22.1137652' AS DateTime2), CAST(N'2021-10-27T17:42:22.1137652' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (63, 6, 8, 6, CAST(N'2021-10-27T17:42:22.1154570' AS DateTime2), CAST(N'2021-10-27T17:42:22.1154570' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (64, 6, 9, 6, CAST(N'2021-10-27T17:42:22.1175907' AS DateTime2), CAST(N'2021-10-27T17:42:22.1175907' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (65, 6, 10, 6, CAST(N'2021-10-27T17:42:22.1186267' AS DateTime2), CAST(N'2021-10-27T17:42:22.1186267' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (66, 6, 11, 6, CAST(N'2021-10-27T17:42:22.1207695' AS DateTime2), CAST(N'2021-10-27T17:42:22.1207695' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (67, 7, 1, 7, CAST(N'2021-10-27T17:43:24.9128758' AS DateTime2), CAST(N'2021-10-27T17:43:24.9128758' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (68, 7, 2, 7, CAST(N'2021-10-27T17:43:24.9145128' AS DateTime2), CAST(N'2021-10-27T17:43:24.9145128' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (69, 7, 3, 7, CAST(N'2021-10-27T17:43:24.9165710' AS DateTime2), CAST(N'2021-10-27T17:43:24.9165710' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (70, 7, 4, 7, CAST(N'2021-10-27T17:43:24.9176475' AS DateTime2), CAST(N'2021-10-27T17:43:24.9176475' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (71, 7, 5, 7, CAST(N'2021-10-27T17:43:24.9203444' AS DateTime2), CAST(N'2021-10-27T17:43:24.9203444' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (72, 7, 6, 7, CAST(N'2021-10-27T17:43:24.9214028' AS DateTime2), CAST(N'2021-10-27T17:43:24.9214028' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (73, 7, 7, 7, CAST(N'2021-10-27T17:43:24.9234669' AS DateTime2), CAST(N'2021-10-27T17:43:24.9234669' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (74, 7, 8, 7, CAST(N'2021-10-27T17:43:24.9255428' AS DateTime2), CAST(N'2021-10-27T17:43:24.9255428' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (75, 7, 9, 7, CAST(N'2021-10-27T17:43:24.9265802' AS DateTime2), CAST(N'2021-10-27T17:43:24.9265802' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (76, 7, 10, 7, CAST(N'2021-10-27T17:43:24.9293016' AS DateTime2), CAST(N'2021-10-27T17:43:24.9293016' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (77, 7, 11, 7, CAST(N'2021-10-27T17:43:24.9314430' AS DateTime2), CAST(N'2021-10-27T17:43:24.9314430' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (78, 8, 1, 8, CAST(N'2021-10-27T17:43:38.3485888' AS DateTime2), CAST(N'2021-10-27T17:43:38.3485888' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (79, 8, 2, 8, CAST(N'2021-10-27T17:43:38.3496288' AS DateTime2), CAST(N'2021-10-27T17:43:38.3496288' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (80, 8, 3, 8, CAST(N'2021-10-27T17:43:38.3512248' AS DateTime2), CAST(N'2021-10-27T17:43:38.3512248' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (81, 8, 4, 8, CAST(N'2021-10-27T17:43:38.3533323' AS DateTime2), CAST(N'2021-10-27T17:43:38.3533323' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (82, 8, 5, 8, CAST(N'2021-10-27T17:43:38.3554523' AS DateTime2), CAST(N'2021-10-27T17:43:38.3554523' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (83, 8, 6, 8, CAST(N'2021-10-27T17:43:38.3570483' AS DateTime2), CAST(N'2021-10-27T17:43:38.3570483' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (84, 8, 7, 8, CAST(N'2021-10-27T17:43:38.3591480' AS DateTime2), CAST(N'2021-10-27T17:43:38.3591480' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (85, 8, 8, 8, CAST(N'2021-10-27T17:43:38.3612955' AS DateTime2), CAST(N'2021-10-27T17:43:38.3612955' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (86, 8, 9, 8, CAST(N'2021-10-27T17:43:38.3623452' AS DateTime2), CAST(N'2021-10-27T17:43:38.3623452' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (87, 8, 10, 8, CAST(N'2021-10-27T17:43:38.3639331' AS DateTime2), CAST(N'2021-10-27T17:43:38.3639331' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (88, 8, 11, 8, CAST(N'2021-10-27T17:43:38.3660298' AS DateTime2), CAST(N'2021-10-27T17:43:38.3660298' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (89, 9, 1, 9, CAST(N'2021-10-27T17:43:51.6834518' AS DateTime2), CAST(N'2021-10-27T17:43:51.6834518' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (90, 9, 2, 9, CAST(N'2021-10-27T17:43:51.6845116' AS DateTime2), CAST(N'2021-10-27T17:43:51.6845116' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (91, 9, 3, 9, CAST(N'2021-10-27T17:43:51.6865889' AS DateTime2), CAST(N'2021-10-27T17:43:51.6865889' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (92, 9, 4, 9, CAST(N'2021-10-27T17:43:51.6886644' AS DateTime2), CAST(N'2021-10-27T17:43:51.6886644' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (93, 9, 5, 9, CAST(N'2021-10-27T17:43:51.6902903' AS DateTime2), CAST(N'2021-10-27T17:43:51.6902903' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (94, 9, 6, 9, CAST(N'2021-10-27T17:43:51.6913221' AS DateTime2), CAST(N'2021-10-27T17:43:51.6913221' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (95, 9, 7, 9, CAST(N'2021-10-27T17:43:51.6934062' AS DateTime2), CAST(N'2021-10-27T17:43:51.6934062' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (96, 9, 8, 9, CAST(N'2021-10-27T17:43:51.6955126' AS DateTime2), CAST(N'2021-10-27T17:43:51.6955126' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (97, 9, 9, 9, CAST(N'2021-10-27T17:43:51.6971468' AS DateTime2), CAST(N'2021-10-27T17:43:51.6971468' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (98, 9, 10, 9, CAST(N'2021-10-27T17:43:51.6992285' AS DateTime2), CAST(N'2021-10-27T17:43:51.6992285' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (99, 9, 11, 9, CAST(N'2021-10-27T17:43:51.7002995' AS DateTime2), CAST(N'2021-10-27T17:43:51.7002995' AS DateTime2), 2, 2)
GO
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (100, 10, 1, 10, CAST(N'2021-10-27T17:44:08.3565716' AS DateTime2), CAST(N'2021-10-27T17:44:08.3565716' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (101, 10, 2, 10, CAST(N'2021-10-27T17:44:08.3576519' AS DateTime2), CAST(N'2021-10-27T17:44:08.3576519' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (102, 10, 3, 10, CAST(N'2021-10-27T17:44:08.3603640' AS DateTime2), CAST(N'2021-10-27T17:44:08.3603640' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (103, 10, 4, 10, CAST(N'2021-10-27T17:44:08.3624888' AS DateTime2), CAST(N'2021-10-27T17:44:08.3624888' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (104, 10, 5, 10, CAST(N'2021-10-27T17:44:08.3635091' AS DateTime2), CAST(N'2021-10-27T17:44:08.3635091' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (105, 10, 6, 10, CAST(N'2021-10-27T17:44:08.3651308' AS DateTime2), CAST(N'2021-10-27T17:44:08.3651308' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (106, 10, 7, 10, CAST(N'2021-10-27T17:44:08.3672263' AS DateTime2), CAST(N'2021-10-27T17:44:08.3672263' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (107, 10, 8, 10, CAST(N'2021-10-27T17:44:08.3682778' AS DateTime2), CAST(N'2021-10-27T17:44:08.3682778' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (108, 10, 9, 10, CAST(N'2021-10-27T17:44:08.3703762' AS DateTime2), CAST(N'2021-10-27T17:44:08.3703762' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (109, 10, 10, 10, CAST(N'2021-10-27T17:44:08.3719958' AS DateTime2), CAST(N'2021-10-27T17:44:08.3719958' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (110, 10, 11, 10, CAST(N'2021-10-27T17:44:08.3730524' AS DateTime2), CAST(N'2021-10-27T17:44:08.3730524' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (111, 11, 1, 11, CAST(N'2021-10-27T17:44:21.9670943' AS DateTime2), CAST(N'2021-10-27T17:44:21.9670943' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (112, 11, 2, 11, CAST(N'2021-10-27T17:44:21.9687516' AS DateTime2), CAST(N'2021-10-27T17:44:21.9687516' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (113, 11, 3, 11, CAST(N'2021-10-27T17:44:21.9709172' AS DateTime2), CAST(N'2021-10-27T17:44:21.9709172' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (114, 11, 4, 11, CAST(N'2021-10-27T17:44:21.9719754' AS DateTime2), CAST(N'2021-10-27T17:44:21.9719754' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (115, 11, 5, 11, CAST(N'2021-10-27T17:44:21.9730514' AS DateTime2), CAST(N'2021-10-27T17:44:21.9730514' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (116, 11, 6, 11, CAST(N'2021-10-27T17:44:21.9747584' AS DateTime2), CAST(N'2021-10-27T17:44:21.9747584' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (117, 11, 7, 11, CAST(N'2021-10-27T17:44:21.9766079' AS DateTime2), CAST(N'2021-10-27T17:44:21.9766079' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (118, 11, 8, 11, CAST(N'2021-10-27T17:44:21.9788350' AS DateTime2), CAST(N'2021-10-27T17:44:21.9788350' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (119, 11, 9, 11, CAST(N'2021-10-27T17:44:21.9815972' AS DateTime2), CAST(N'2021-10-27T17:44:21.9815972' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (120, 11, 10, 11, CAST(N'2021-10-27T17:44:21.9839437' AS DateTime2), CAST(N'2021-10-27T17:44:21.9839437' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (121, 11, 11, 11, CAST(N'2021-10-27T17:44:21.9867049' AS DateTime2), CAST(N'2021-10-27T17:44:21.9867049' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (122, 12, 1, 12, CAST(N'2021-10-27T17:44:34.4156592' AS DateTime2), CAST(N'2021-10-27T17:44:34.4156592' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (123, 12, 2, 12, CAST(N'2021-10-27T17:44:34.4184061' AS DateTime2), CAST(N'2021-10-27T17:44:34.4184061' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (124, 12, 3, 12, CAST(N'2021-10-27T17:44:34.4194305' AS DateTime2), CAST(N'2021-10-27T17:44:34.4194305' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (125, 12, 4, 12, CAST(N'2021-10-27T17:44:34.4215726' AS DateTime2), CAST(N'2021-10-27T17:44:34.4215726' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (126, 12, 5, 12, CAST(N'2021-10-27T17:44:34.4232159' AS DateTime2), CAST(N'2021-10-27T17:44:34.4232159' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (127, 12, 6, 12, CAST(N'2021-10-27T17:44:34.4242731' AS DateTime2), CAST(N'2021-10-27T17:44:34.4242731' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (128, 12, 7, 12, CAST(N'2021-10-27T17:44:34.4264131' AS DateTime2), CAST(N'2021-10-27T17:44:34.4264131' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (129, 12, 8, 12, CAST(N'2021-10-27T17:44:34.4280072' AS DateTime2), CAST(N'2021-10-27T17:44:34.4280072' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (130, 12, 9, 12, CAST(N'2021-10-27T17:44:34.4301077' AS DateTime2), CAST(N'2021-10-27T17:44:34.4301077' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (131, 12, 10, 12, CAST(N'2021-10-27T17:44:34.4311436' AS DateTime2), CAST(N'2021-10-27T17:44:34.4311436' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (132, 12, 11, 12, CAST(N'2021-10-27T17:44:34.4332162' AS DateTime2), CAST(N'2021-10-27T17:44:34.4332162' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (133, 13, 1, 13, CAST(N'2021-10-27T17:44:50.3492531' AS DateTime2), CAST(N'2021-10-27T17:44:50.3492531' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (134, 13, 2, 13, CAST(N'2021-10-27T17:44:50.3509110' AS DateTime2), CAST(N'2021-10-27T17:44:50.3509110' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (135, 13, 3, 13, CAST(N'2021-10-27T17:44:50.3529976' AS DateTime2), CAST(N'2021-10-27T17:44:50.3529976' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (136, 13, 4, 13, CAST(N'2021-10-27T17:44:50.3540971' AS DateTime2), CAST(N'2021-10-27T17:44:50.3540971' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (137, 13, 5, 13, CAST(N'2021-10-27T17:44:50.3561868' AS DateTime2), CAST(N'2021-10-27T17:44:50.3561868' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (138, 13, 6, 13, CAST(N'2021-10-27T17:44:50.3577668' AS DateTime2), CAST(N'2021-10-27T17:44:50.3577668' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (139, 13, 7, 13, CAST(N'2021-10-27T17:44:50.3598491' AS DateTime2), CAST(N'2021-10-27T17:44:50.3598491' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (140, 13, 8, 13, CAST(N'2021-10-27T17:44:50.3619784' AS DateTime2), CAST(N'2021-10-27T17:44:50.3619784' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (141, 13, 9, 13, CAST(N'2021-10-27T17:44:50.3635828' AS DateTime2), CAST(N'2021-10-27T17:44:50.3635828' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (142, 13, 10, 13, CAST(N'2021-10-27T17:44:50.3646617' AS DateTime2), CAST(N'2021-10-27T17:44:50.3646617' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (143, 13, 11, 13, CAST(N'2021-10-27T17:44:50.3668057' AS DateTime2), CAST(N'2021-10-27T17:44:50.3668057' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (144, 14, 1, 14, CAST(N'2021-10-27T17:45:02.0935416' AS DateTime2), CAST(N'2021-10-27T17:45:02.0935416' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (145, 14, 2, 14, CAST(N'2021-10-27T17:45:02.0956609' AS DateTime2), CAST(N'2021-10-27T17:45:02.0956609' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (146, 14, 3, 14, CAST(N'2021-10-27T17:45:02.0972581' AS DateTime2), CAST(N'2021-10-27T17:45:02.0972581' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (147, 14, 4, 14, CAST(N'2021-10-27T17:45:02.0993708' AS DateTime2), CAST(N'2021-10-27T17:45:02.0993708' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (148, 14, 5, 14, CAST(N'2021-10-27T17:45:02.1014982' AS DateTime2), CAST(N'2021-10-27T17:45:02.1014982' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (149, 14, 6, 14, CAST(N'2021-10-27T17:45:02.1031004' AS DateTime2), CAST(N'2021-10-27T17:45:02.1031004' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (150, 14, 7, 14, CAST(N'2021-10-27T17:45:02.1052089' AS DateTime2), CAST(N'2021-10-27T17:45:02.1052089' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (151, 14, 8, 14, CAST(N'2021-10-27T17:45:02.1073229' AS DateTime2), CAST(N'2021-10-27T17:45:02.1073229' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (152, 14, 9, 14, CAST(N'2021-10-27T17:45:02.1083643' AS DateTime2), CAST(N'2021-10-27T17:45:02.1083643' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (153, 14, 10, 14, CAST(N'2021-10-27T17:45:02.1110843' AS DateTime2), CAST(N'2021-10-27T17:45:02.1110843' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (154, 14, 11, 14, CAST(N'2021-10-27T17:45:02.1131610' AS DateTime2), CAST(N'2021-10-27T17:45:02.1131610' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (155, 15, 1, 15, CAST(N'2021-10-27T17:45:13.4882237' AS DateTime2), CAST(N'2021-10-27T17:45:13.4882237' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (156, 15, 2, 15, CAST(N'2021-10-27T17:45:13.4892856' AS DateTime2), CAST(N'2021-10-27T17:45:13.4892856' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (157, 15, 3, 15, CAST(N'2021-10-27T17:45:13.4913941' AS DateTime2), CAST(N'2021-10-27T17:45:13.4913941' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (158, 15, 4, 15, CAST(N'2021-10-27T17:45:13.4924494' AS DateTime2), CAST(N'2021-10-27T17:45:13.4924494' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (159, 15, 5, 15, CAST(N'2021-10-27T17:45:13.4950946' AS DateTime2), CAST(N'2021-10-27T17:45:13.4950946' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (160, 15, 6, 15, CAST(N'2021-10-27T17:45:13.4961364' AS DateTime2), CAST(N'2021-10-27T17:45:13.4961364' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (161, 15, 7, 15, CAST(N'2021-10-27T17:45:13.4982477' AS DateTime2), CAST(N'2021-10-27T17:45:13.4982477' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (162, 15, 8, 15, CAST(N'2021-10-27T17:45:13.4992991' AS DateTime2), CAST(N'2021-10-27T17:45:13.4992991' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (163, 15, 9, 15, CAST(N'2021-10-27T17:45:13.5009022' AS DateTime2), CAST(N'2021-10-27T17:45:13.5009022' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (164, 15, 10, 15, CAST(N'2021-10-27T17:45:13.5029745' AS DateTime2), CAST(N'2021-10-27T17:45:13.5029745' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (165, 15, 11, 15, CAST(N'2021-10-27T17:45:13.5050459' AS DateTime2), CAST(N'2021-10-27T17:45:13.5050459' AS DateTime2), 2, 2)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (166, 1, 12, 1, CAST(N'2021-11-29T15:05:38.4919931' AS DateTime2), CAST(N'2021-11-29T15:05:38.4919931' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (167, 2, 12, 2, CAST(N'2021-11-29T15:05:38.5056090' AS DateTime2), CAST(N'2021-11-29T15:05:38.5056090' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (168, 3, 12, 3, CAST(N'2021-11-29T15:05:38.5066784' AS DateTime2), CAST(N'2021-11-29T15:05:38.5066784' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (169, 4, 12, 4, CAST(N'2021-11-29T15:05:38.5066784' AS DateTime2), CAST(N'2021-11-29T15:05:38.5066784' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (170, 5, 12, 5, CAST(N'2021-11-29T15:05:38.5077252' AS DateTime2), CAST(N'2021-11-29T15:05:38.5077252' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (171, 6, 12, 6, CAST(N'2021-11-29T15:05:38.5083213' AS DateTime2), CAST(N'2021-11-29T15:05:38.5083213' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (172, 7, 12, 7, CAST(N'2021-11-29T15:05:38.5083213' AS DateTime2), CAST(N'2021-11-29T15:05:38.5083213' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (173, 8, 12, 8, CAST(N'2021-11-29T15:05:38.5083213' AS DateTime2), CAST(N'2021-11-29T15:05:38.5083213' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (174, 9, 12, 9, CAST(N'2021-11-29T15:05:38.5094594' AS DateTime2), CAST(N'2021-11-29T15:05:38.5094594' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (175, 10, 12, 10, CAST(N'2021-11-29T15:05:38.5094594' AS DateTime2), CAST(N'2021-11-29T15:05:38.5094594' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (176, 11, 12, 11, CAST(N'2021-11-29T15:05:38.5105323' AS DateTime2), CAST(N'2021-11-29T15:05:38.5105323' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (177, 12, 12, 12, CAST(N'2021-11-29T15:05:38.5115795' AS DateTime2), CAST(N'2021-11-29T15:05:38.5115795' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (178, 13, 12, 13, CAST(N'2021-11-29T15:05:38.5115795' AS DateTime2), CAST(N'2021-11-29T15:05:38.5115795' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (179, 14, 12, 14, CAST(N'2021-11-29T15:05:38.5126565' AS DateTime2), CAST(N'2021-11-29T15:05:38.5126565' AS DateTime2), 8, 8)
INSERT [dbo].[categoryuser] ([id], [categoryId], [userId], [sequence], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (180, 15, 12, 15, CAST(N'2021-11-29T15:05:38.5132790' AS DateTime2), CAST(N'2021-11-29T15:05:38.5132790' AS DateTime2), 8, 8)
SET IDENTITY_INSERT [dbo].[categoryuser] OFF
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
SET IDENTITY_INSERT [dbo].[coupons] ON 

INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (1, N'test1', N'T1', 1, 1, CAST(1000.000 AS Decimal(20, 3)), CAST(N'2021-11-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), N'', 25, 25, CAST(0.000 AS Decimal(20, 3)), CAST(99999999.000 AS Decimal(20, 3)), CAST(N'2021-11-03T16:27:42.8544680' AS DateTime2), CAST(N'2021-11-03T16:27:42.8544680' AS DateTime2), 9, 9, N'cop-T1')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (2, N'coupon1', N'co1', 1, 1, CAST(15.000 AS Decimal(20, 3)), CAST(N'2021-11-07T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), N'', 5, 5, CAST(10000.000 AS Decimal(20, 3)), CAST(25000.000 AS Decimal(20, 3)), CAST(N'2021-11-07T12:08:54.5653500' AS DateTime2), CAST(N'2021-11-07T13:59:53.4457212' AS DateTime2), 3, 3, N'cop-co1')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (3, N'coupon2', N'co2', 1, 2, CAST(25.000 AS Decimal(20, 3)), CAST(N'2021-11-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-11-30T00:00:00.0000000' AS DateTime2), N'', 10, 10, CAST(10.000 AS Decimal(20, 3)), CAST(10000.000 AS Decimal(20, 3)), CAST(N'2021-11-09T13:29:29.2951947' AS DateTime2), CAST(N'2021-12-01T15:23:26.0053763' AS DateTime2), 3, 3, N'cop-co2')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (4, N'coupon3', N'co3', 1, 1, CAST(10.000 AS Decimal(20, 3)), CAST(N'2021-11-07T00:00:00.0000000' AS DateTime2), CAST(N'2022-11-30T00:00:00.0000000' AS DateTime2), N'', 1000, 1000, CAST(1000.000 AS Decimal(20, 3)), CAST(25000.000 AS Decimal(20, 3)), CAST(N'2021-11-09T13:32:50.9740182' AS DateTime2), CAST(N'2021-12-01T15:22:12.9571653' AS DateTime2), 3, 3, N'cop-co3')
INSERT [dbo].[coupons] ([cId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [notes], [quantity], [remainQ], [invMin], [invMax], [createDate], [updateDate], [createUserId], [updateUserId], [barcode]) VALUES (5, N'coupon 10', N'co10', 1, 1, CAST(10.000 AS Decimal(20, 3)), CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-11-30T00:00:00.0000000' AS DateTime2), N'', 1000, 1000, CAST(1.000 AS Decimal(20, 3)), CAST(1000.000 AS Decimal(20, 3)), CAST(N'2021-12-01T15:25:25.6411794' AS DateTime2), CAST(N'2021-12-01T15:25:25.6411794' AS DateTime2), 8, 8, N'cop-co10')
SET IDENTITY_INSERT [dbo].[coupons] OFF
GO
SET IDENTITY_INSERT [dbo].[couponsInvoices] ON 

INSERT [dbo].[couponsInvoices] ([id], [couponId], [InvoiceId], [createDate], [updateDate], [createUserId], [updateUserId], [discountValue], [discountType]) VALUES (4, 4, 1186, CAST(N'2021-12-01T14:34:06.1648689' AS DateTime2), CAST(N'2021-12-01T14:34:06.1648689' AS DateTime2), 8, 8, CAST(10.000 AS Decimal(20, 3)), 1)
INSERT [dbo].[couponsInvoices] ([id], [couponId], [InvoiceId], [createDate], [updateDate], [createUserId], [updateUserId], [discountValue], [discountType]) VALUES (5, 4, 1188, CAST(N'2021-12-01T15:19:43.6091612' AS DateTime2), CAST(N'2021-12-01T15:19:43.6091612' AS DateTime2), 8, 8, CAST(10.000 AS Decimal(20, 3)), 1)
SET IDENTITY_INSERT [dbo].[couponsInvoices] OFF
GO
SET IDENTITY_INSERT [dbo].[error] ON 

INSERT [dbo].[error] ([errorId], [num], [msg], [stackTrace], [targetSite], [posId], [branchId], [createDate], [createUserId]) VALUES (1553, N'-2146233033', N'Input string was not in a correct format.', N'   at System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)rn   at System.Number.ParseDecimal(String value, NumberStyles options, NumberFormatInfo numfmt)rn   at System.Decimal.Parse(String s)rn   at POS.View.uc_coupon.<Btn_add_Click>d__25.MoveNext() in E:POS 1-12-2021POSViewsalesuc_coupon.xaml.cs:line 460', N'Void StringToNumber(System.String, System.Globalization.NumberStyles, NumberBuffer ByRef, System.Globalization.NumberFormatInfo, Boolean)', 1, 2, CAST(N'2021-12-01T15:26:21.7332720' AS DateTime2), 3)
INSERT [dbo].[error] ([errorId], [num], [msg], [stackTrace], [targetSite], [posId], [branchId], [createDate], [createUserId]) VALUES (1554, N'-2147467261', N'Value cannot be null.rnParameter name: source', N'   at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)rn   at Restaurant.View.sales.uc_diningHall.Btn_prevPage_Click(Object sender, RoutedEventArgs e) in E:GitHubRESprojectRestaurantRestaurantViewsalesuc_diningHall.xaml.cs:line 196', N'System.Collections.Generic.List`1[TSource] ToList[TSource](System.Collections.Generic.IEnumerable`1[TSource])', NULL, NULL, CAST(N'2021-12-04T17:36:43.3742650' AS DateTime2), 1)
INSERT [dbo].[error] ([errorId], [num], [msg], [stackTrace], [targetSite], [posId], [branchId], [createDate], [createUserId]) VALUES (1555, N'-2147467261', N'Value cannot be null.rnParameter name: source', N'   at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)rn   at Restaurant.View.sales.uc_diningHall.Btn_activePage_Click(Object sender, RoutedEventArgs e) in E:GitHubRESprojectRestaurantRestaurantViewsalesuc_diningHall.xaml.cs:line 220', N'System.Collections.Generic.List`1[TSource] ToList[TSource](System.Collections.Generic.IEnumerable`1[TSource])', NULL, NULL, CAST(N'2021-12-04T17:36:44.0929088' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[error] OFF
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
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1696, 10, 104, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8604996' AS DateTime2), CAST(N'2021-11-18T18:57:58.5777035' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1697, 10, 105, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8642649' AS DateTime2), CAST(N'2021-11-18T18:57:59.0776145' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1698, 10, 106, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8663929' AS DateTime2), CAST(N'2021-11-18T18:57:59.5754810' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1699, 10, 107, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:19.8702934' AS DateTime2), CAST(N'2021-11-18T18:58:06.5018744' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1700, 10, 108, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:19.8741368' AS DateTime2), CAST(N'2021-11-18T18:58:12.6941780' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1701, 10, 109, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:19.8761767' AS DateTime2), CAST(N'2021-11-18T18:58:13.1928995' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1702, 10, 110, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:20.5557799' AS DateTime2), CAST(N'2021-11-18T19:01:39.9654959' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1703, 10, 111, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5595499' AS DateTime2), CAST(N'2021-11-18T19:01:40.5521989' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1704, 10, 112, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5629709' AS DateTime2), CAST(N'2021-11-18T18:58:15.9937472' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1705, 10, 113, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5646503' AS DateTime2), CAST(N'2021-11-18T18:58:16.6479027' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1706, 10, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:20.5667093' AS DateTime2), CAST(N'2021-11-18T18:54:20.5667093' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1707, 10, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:20.5695206' AS DateTime2), CAST(N'2021-11-18T18:54:20.5695206' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1708, 10, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:20.5718430' AS DateTime2), CAST(N'2021-11-18T18:54:20.5718430' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1709, 10, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:20.5734575' AS DateTime2), CAST(N'2021-11-18T18:54:20.5734575' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1710, 10, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:20.5772288' AS DateTime2), CAST(N'2021-11-18T18:54:20.5772288' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1711, 10, 119, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5793322' AS DateTime2), CAST(N'2021-11-18T18:58:20.1583553' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1712, 10, 120, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5820475' AS DateTime2), CAST(N'2021-11-18T18:58:20.6460604' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1713, 10, 121, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5841841' AS DateTime2), CAST(N'2021-11-18T18:58:21.1684770' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1714, 10, 122, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5868553' AS DateTime2), CAST(N'2021-11-18T18:57:34.7107357' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1715, 10, 123, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5889848' AS DateTime2), CAST(N'2021-11-18T18:57:35.2164072' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1716, 10, 124, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:20.5928847' AS DateTime2), CAST(N'2021-11-18T18:57:37.2105472' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1717, 10, 125, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2513540' AS DateTime2), CAST(N'2021-11-18T18:57:37.6980605' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1718, 10, 126, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2552285' AS DateTime2), CAST(N'2021-11-18T18:57:40.1156937' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1719, 10, 127, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2588823' AS DateTime2), CAST(N'2021-11-18T18:57:40.6400491' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1720, 10, 128, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2637736' AS DateTime2), CAST(N'2021-11-18T18:57:43.7541801' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1721, 10, 129, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2671413' AS DateTime2), CAST(N'2021-11-18T18:57:44.2423939' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1722, 10, 130, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:21.2698329' AS DateTime2), CAST(N'2021-11-18T18:54:21.2698329' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1723, 10, 131, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:21.2715076' AS DateTime2), CAST(N'2021-11-18T18:54:21.2715076' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1724, 10, 132, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2736076' AS DateTime2), CAST(N'2021-11-18T18:57:46.6982312' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1725, 10, 133, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2767037' AS DateTime2), CAST(N'2021-11-18T18:57:47.2041066' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1726, 10, 134, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:21.2783078' AS DateTime2), CAST(N'2021-11-18T18:57:31.4593809' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1727, 10, 135, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2804435' AS DateTime2), CAST(N'2021-11-18T18:57:31.9618229' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1728, 10, 137, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:21.2833055' AS DateTime2), CAST(N'2021-11-18T19:01:25.7053558' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1729, 10, 138, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:21.2853798' AS DateTime2), CAST(N'2021-11-18T18:55:49.2305392' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1730, 10, 145, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:21.2880734' AS DateTime2), CAST(N'2021-11-18T19:01:55.9761995' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1731, 10, 147, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:21.2915662' AS DateTime2), CAST(N'2021-11-18T18:54:21.2915662' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1732, 10, 148, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:22.0362152' AS DateTime2), CAST(N'2021-11-18T18:54:22.0362152' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1733, 10, 151, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:22.0399454' AS DateTime2), CAST(N'2021-11-18T18:55:56.6443297' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1734, 10, 152, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:22.0431286' AS DateTime2), CAST(N'2021-11-18T18:54:22.0431286' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1735, 10, 153, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0458154' AS DateTime2), CAST(N'2021-11-18T18:58:29.9918029' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1736, 10, 154, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0479479' AS DateTime2), CAST(N'2021-11-18T18:58:30.5070390' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1737, 10, 155, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0507073' AS DateTime2), CAST(N'2021-11-18T18:59:01.6214694' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1738, 10, 156, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0529350' AS DateTime2), CAST(N'2021-11-18T18:59:02.1554642' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1739, 10, 157, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:22.0556504' AS DateTime2), CAST(N'2021-11-18T18:54:22.0556504' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1740, 10, 158, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0577888' AS DateTime2), CAST(N'2021-11-18T18:56:26.3314666' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1741, 10, 159, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:22.0604692' AS DateTime2), CAST(N'2021-11-18T18:54:22.0604692' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1742, 10, 160, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0626387' AS DateTime2), CAST(N'2021-11-18T18:59:19.6603933' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1743, 10, 161, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0652918' AS DateTime2), CAST(N'2021-11-18T18:59:20.1670641' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1744, 10, 162, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0685914' AS DateTime2), CAST(N'2021-11-18T18:58:00.0617468' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1745, 10, 163, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0702123' AS DateTime2), CAST(N'2021-11-18T18:58:21.7726620' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1746, 10, 164, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.0723716' AS DateTime2), CAST(N'2021-11-18T18:58:43.3545315' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1747, 10, 165, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7580500' AS DateTime2), CAST(N'2021-11-18T18:58:31.0135976' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1748, 10, 166, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7607721' AS DateTime2), CAST(N'2021-11-18T18:57:47.6925855' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1749, 10, 180, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:22.7635594' AS DateTime2), CAST(N'2021-11-18T18:54:22.7635594' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1750, 10, 181, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:22.7656791' AS DateTime2), CAST(N'2021-11-18T18:54:22.7656791' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1751, 10, 182, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:22.7684574' AS DateTime2), CAST(N'2021-11-18T18:54:22.7684574' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1752, 10, 183, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:22.7717995' AS DateTime2), CAST(N'2021-11-18T18:54:22.7717995' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1753, 10, 184, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7745103' AS DateTime2), CAST(N'2021-11-18T18:55:15.5035881' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1754, 10, 185, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7765950' AS DateTime2), CAST(N'2021-11-18T18:55:15.9858511' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1755, 10, 186, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7782713' AS DateTime2), CAST(N'2021-11-18T18:55:16.4753459' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1756, 10, 187, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7814172' AS DateTime2), CAST(N'2021-11-18T18:55:16.9634983' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1757, 10, 188, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7841832' AS DateTime2), CAST(N'2021-11-18T18:55:04.3481758' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1758, 10, 192, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7862850' AS DateTime2), CAST(N'2021-11-18T18:56:16.8132862' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1759, 10, 193, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:22.7899918' AS DateTime2), CAST(N'2021-11-18T18:54:22.7899918' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1760, 10, 194, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7931910' AS DateTime2), CAST(N'2021-11-29T16:13:29.6397529' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1761, 10, 195, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:22.7960266' AS DateTime2), CAST(N'2021-11-29T16:13:30.0732937' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1762, 10, 196, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5763481' AS DateTime2), CAST(N'2021-11-18T18:58:43.8681287' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1763, 10, 197, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5801364' AS DateTime2), CAST(N'2021-11-18T18:58:44.3289950' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1764, 10, 198, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5829166' AS DateTime2), CAST(N'2021-11-18T18:58:31.5097937' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1765, 10, 199, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5860788' AS DateTime2), CAST(N'2021-11-18T18:59:02.7320835' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1766, 10, 200, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5887862' AS DateTime2), CAST(N'2021-11-18T18:58:24.3485864' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1767, 10, 201, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5920396' AS DateTime2), CAST(N'2021-11-18T18:57:20.1312201' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1768, 10, 202, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5946477' AS DateTime2), CAST(N'2021-11-18T18:57:21.7062520' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1769, 10, 203, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5967980' AS DateTime2), CAST(N'2021-11-18T18:57:23.4015668' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1770, 10, 204, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.5994234' AS DateTime2), CAST(N'2021-11-18T18:57:18.5278798' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1771, 10, 205, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-18T18:54:23.6014995' AS DateTime2), CAST(N'2021-11-18T18:54:23.6014995' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1772, 10, 206, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-18T18:54:23.6036232' AS DateTime2), CAST(N'2021-11-18T18:54:23.6036232' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1773, 10, 207, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-18T18:54:23.6063280' AS DateTime2), CAST(N'2021-11-18T19:01:32.9793313' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1774, 10, 209, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.6096317' AS DateTime2), CAST(N'2021-11-18T18:58:00.5728719' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1775, 10, 210, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.6135371' AS DateTime2), CAST(N'2021-11-18T18:58:44.8438794' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1776, 10, 212, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-18T18:54:23.6151772' AS DateTime2), CAST(N'2021-11-18T18:59:17.0543357' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1777, 11, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3535665' AS DateTime2), CAST(N'2021-11-20T13:44:09.3535665' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1778, 11, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3729621' AS DateTime2), CAST(N'2021-11-20T13:44:09.3729621' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1779, 11, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3750491' AS DateTime2), CAST(N'2021-11-20T13:44:09.3750491' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1780, 11, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3771861' AS DateTime2), CAST(N'2021-11-20T13:44:09.3771861' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1781, 11, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3798785' AS DateTime2), CAST(N'2021-11-20T13:44:09.3798785' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1782, 11, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3849166' AS DateTime2), CAST(N'2021-11-20T13:44:09.3849166' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1783, 11, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3888711' AS DateTime2), CAST(N'2021-11-20T13:44:09.3888711' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1784, 11, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3915717' AS DateTime2), CAST(N'2021-11-20T13:44:09.3915717' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1785, 11, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3947644' AS DateTime2), CAST(N'2021-11-20T13:44:09.3947644' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1786, 11, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3963834' AS DateTime2), CAST(N'2021-11-20T13:44:09.3963834' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1787, 11, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.3984786' AS DateTime2), CAST(N'2021-11-20T13:44:09.3984786' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1788, 11, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.4005922' AS DateTime2), CAST(N'2021-11-20T13:44:09.4005922' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1789, 11, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.4032687' AS DateTime2), CAST(N'2021-11-20T13:44:09.4032687' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1790, 11, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.4053782' AS DateTime2), CAST(N'2021-11-20T13:44:09.4053782' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1791, 11, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:09.4074527' AS DateTime2), CAST(N'2021-11-20T13:44:09.4074527' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1792, 11, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0294358' AS DateTime2), CAST(N'2021-11-20T13:44:10.0294358' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1793, 11, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0369885' AS DateTime2), CAST(N'2021-11-20T13:44:10.0369885' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1794, 11, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0390837' AS DateTime2), CAST(N'2021-11-20T13:44:10.0390837' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1795, 11, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0469835' AS DateTime2), CAST(N'2021-11-20T13:44:10.0469835' AS DateTime2), 9, 9, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1796, 11, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0492341' AS DateTime2), CAST(N'2021-11-20T13:44:10.0492341' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1797, 11, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0520492' AS DateTime2), CAST(N'2021-11-20T13:44:10.0520492' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1798, 11, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0569681' AS DateTime2), CAST(N'2021-11-20T13:44:10.0569681' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1799, 11, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0586085' AS DateTime2), CAST(N'2021-11-20T13:44:10.0586085' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1800, 11, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0613715' AS DateTime2), CAST(N'2021-11-20T13:44:10.0613715' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1801, 11, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0645267' AS DateTime2), CAST(N'2021-11-20T13:44:10.0645267' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1802, 11, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0668088' AS DateTime2), CAST(N'2021-11-20T13:44:10.0668088' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1803, 11, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0700885' AS DateTime2), CAST(N'2021-11-20T13:44:10.0700885' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1804, 11, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0732547' AS DateTime2), CAST(N'2021-11-20T13:44:10.0732547' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1805, 11, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0791668' AS DateTime2), CAST(N'2021-11-20T13:44:10.0791668' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1806, 11, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.0841450' AS DateTime2), CAST(N'2021-11-20T13:44:10.0841450' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1807, 11, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6755331' AS DateTime2), CAST(N'2021-11-20T13:44:10.6755331' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1808, 11, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6797131' AS DateTime2), CAST(N'2021-11-20T13:44:10.6797131' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1809, 11, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6824082' AS DateTime2), CAST(N'2021-11-20T13:44:10.6824082' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1810, 11, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6845061' AS DateTime2), CAST(N'2021-11-20T13:44:10.6845061' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1811, 11, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6866803' AS DateTime2), CAST(N'2021-11-20T13:44:10.6866803' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1812, 11, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6894217' AS DateTime2), CAST(N'2021-11-20T13:44:10.6894217' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1813, 11, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6915746' AS DateTime2), CAST(N'2021-11-20T13:44:10.6915746' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1814, 11, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6931701' AS DateTime2), CAST(N'2021-11-20T13:44:10.6931701' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1815, 11, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6963804' AS DateTime2), CAST(N'2021-11-20T13:44:10.6963804' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1816, 11, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.6980819' AS DateTime2), CAST(N'2021-11-20T13:44:10.6980819' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1817, 11, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.7002142' AS DateTime2), CAST(N'2021-11-20T13:44:10.7002142' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1818, 11, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.7030034' AS DateTime2), CAST(N'2021-11-20T13:44:10.7030034' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1819, 11, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.7051055' AS DateTime2), CAST(N'2021-11-20T13:44:10.7051055' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1820, 11, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.7071709' AS DateTime2), CAST(N'2021-11-20T13:44:10.7071709' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1821, 11, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:10.7099176' AS DateTime2), CAST(N'2021-11-20T13:44:10.7099176' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1822, 11, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3273971' AS DateTime2), CAST(N'2021-11-20T13:44:11.3273971' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1823, 11, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3300333' AS DateTime2), CAST(N'2021-11-20T13:44:11.3300333' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1824, 11, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3327548' AS DateTime2), CAST(N'2021-11-20T13:44:11.3327548' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1825, 11, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3348454' AS DateTime2), CAST(N'2021-11-20T13:44:11.3348454' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1826, 11, 50, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3369823' AS DateTime2), CAST(N'2021-11-20T13:44:11.3369823' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1827, 11, 51, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3396618' AS DateTime2), CAST(N'2021-11-20T13:44:11.3396618' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1828, 11, 52, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3417622' AS DateTime2), CAST(N'2021-11-20T13:44:11.3417622' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1829, 11, 53, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:11.3428275' AS DateTime2), CAST(N'2021-11-20T13:44:11.3428275' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1830, 11, 54, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3455693' AS DateTime2), CAST(N'2021-11-20T13:44:11.3455693' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1831, 11, 55, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:11.3477416' AS DateTime2), CAST(N'2021-11-20T13:44:11.3477416' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1832, 11, 56, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3493892' AS DateTime2), CAST(N'2021-11-20T13:44:11.3493892' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1833, 11, 57, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:11.3515434' AS DateTime2), CAST(N'2021-11-20T13:44:11.3515434' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1834, 11, 58, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3542678' AS DateTime2), CAST(N'2021-11-20T13:44:11.3542678' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1835, 11, 59, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3563975' AS DateTime2), CAST(N'2021-11-20T13:44:11.3563975' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1836, 11, 60, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.3591456' AS DateTime2), CAST(N'2021-11-20T13:44:11.3591456' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1837, 11, 61, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9685783' AS DateTime2), CAST(N'2021-11-20T13:44:11.9685783' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1838, 11, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9717577' AS DateTime2), CAST(N'2021-11-20T13:44:11.9717577' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1839, 11, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9734193' AS DateTime2), CAST(N'2021-11-20T13:44:11.9734193' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1840, 11, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9755359' AS DateTime2), CAST(N'2021-11-20T13:44:11.9755359' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1841, 11, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9783849' AS DateTime2), CAST(N'2021-11-20T13:44:11.9783849' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1842, 11, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9804849' AS DateTime2), CAST(N'2021-11-20T13:44:11.9804849' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1843, 11, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9833332' AS DateTime2), CAST(N'2021-11-20T13:44:11.9833332' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1844, 11, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9861436' AS DateTime2), CAST(N'2021-11-20T13:44:11.9861436' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1845, 11, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:11.9882761' AS DateTime2), CAST(N'2021-11-20T13:44:11.9882761' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1846, 11, 74, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:11.9909278' AS DateTime2), CAST(N'2021-11-20T14:16:21.7317163' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1847, 11, 75, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:11.9941196' AS DateTime2), CAST(N'2021-11-20T14:16:31.8259391' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1848, 11, 76, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:11.9962245' AS DateTime2), CAST(N'2021-11-20T14:16:49.1432321' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1849, 11, 77, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:11.9979269' AS DateTime2), CAST(N'2021-11-20T14:16:54.9162423' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1850, 11, 78, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.0000093' AS DateTime2), CAST(N'2021-11-20T13:44:12.0000093' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1851, 11, 79, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.0027075' AS DateTime2), CAST(N'2021-11-20T13:44:12.0027075' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1852, 11, 80, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6032019' AS DateTime2), CAST(N'2021-11-20T13:44:12.6032019' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1853, 11, 81, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:12.6064213' AS DateTime2), CAST(N'2021-11-20T13:44:12.6064213' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1854, 11, 82, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:12.6091516' AS DateTime2), CAST(N'2021-11-20T13:44:12.6091516' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1855, 11, 83, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6112616' AS DateTime2), CAST(N'2021-11-20T13:44:12.6112616' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1856, 11, 84, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:12.6139887' AS DateTime2), CAST(N'2021-11-20T13:44:12.6139887' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1857, 11, 85, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6160791' AS DateTime2), CAST(N'2021-11-20T13:44:12.6160791' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1858, 11, 86, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6181826' AS DateTime2), CAST(N'2021-11-20T13:44:12.6181826' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1859, 11, 87, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6198340' AS DateTime2), CAST(N'2021-11-20T13:44:12.6198340' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1860, 11, 88, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6219670' AS DateTime2), CAST(N'2021-11-20T13:44:12.6219670' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1861, 11, 89, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6246485' AS DateTime2), CAST(N'2021-11-20T13:44:12.6246485' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1862, 11, 90, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6267429' AS DateTime2), CAST(N'2021-11-20T13:44:12.6267429' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1863, 11, 91, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6289076' AS DateTime2), CAST(N'2021-11-20T13:44:12.6289076' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1864, 11, 92, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6315278' AS DateTime2), CAST(N'2021-11-20T13:44:12.6315278' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1865, 11, 93, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6336785' AS DateTime2), CAST(N'2021-11-20T13:44:12.6336785' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1866, 11, 94, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:12.6357903' AS DateTime2), CAST(N'2021-11-20T13:44:12.6357903' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1867, 11, 95, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.2576395' AS DateTime2), CAST(N'2021-11-20T13:44:13.2576395' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1868, 11, 96, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.2613149' AS DateTime2), CAST(N'2021-11-20T13:44:13.2613149' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1869, 11, 97, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.2634481' AS DateTime2), CAST(N'2021-11-20T13:44:13.2634481' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1870, 11, 98, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.2656050' AS DateTime2), CAST(N'2021-11-20T13:44:13.2656050' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1871, 11, 99, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2672617' AS DateTime2), CAST(N'2021-11-20T14:13:58.1653931' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1872, 11, 100, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2704389' AS DateTime2), CAST(N'2021-11-20T14:13:58.6361310' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1873, 11, 101, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2714930' AS DateTime2), CAST(N'2021-11-20T14:13:59.1236156' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1874, 11, 102, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2741760' AS DateTime2), CAST(N'2021-11-20T14:13:16.6373204' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1875, 11, 103, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2763123' AS DateTime2), CAST(N'2021-11-20T14:13:17.1386696' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1876, 11, 104, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2789876' AS DateTime2), CAST(N'2021-11-20T14:13:17.6246558' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1877, 11, 105, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2811066' AS DateTime2), CAST(N'2021-11-20T14:13:18.0964273' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1878, 11, 106, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2837741' AS DateTime2), CAST(N'2021-11-20T14:13:18.6003784' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1879, 11, 107, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:13.2859747' AS DateTime2), CAST(N'2021-11-20T14:13:26.1944201' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1880, 11, 108, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:13.2880939' AS DateTime2), CAST(N'2021-11-20T14:13:33.6114269' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1881, 11, 109, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.2909172' AS DateTime2), CAST(N'2021-11-20T14:13:34.0946341' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1882, 11, 110, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:13.9491687' AS DateTime2), CAST(N'2021-11-20T14:16:44.3603679' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1883, 11, 111, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.9528841' AS DateTime2), CAST(N'2021-11-20T14:16:44.8691743' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1884, 11, 112, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.9560330' AS DateTime2), CAST(N'2021-11-20T14:13:38.6090195' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1885, 11, 113, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.9576955' AS DateTime2), CAST(N'2021-11-20T14:13:39.1012707' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1886, 11, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:13.9609451' AS DateTime2), CAST(N'2021-11-20T13:44:13.9609451' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1887, 11, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.9625532' AS DateTime2), CAST(N'2021-11-20T13:44:13.9625532' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1888, 11, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:13.9646433' AS DateTime2), CAST(N'2021-11-20T13:44:13.9646433' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1889, 11, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.9667099' AS DateTime2), CAST(N'2021-11-20T13:44:13.9667099' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1890, 11, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.9695368' AS DateTime2), CAST(N'2021-11-20T13:44:13.9695368' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1891, 11, 119, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.9716223' AS DateTime2), CAST(N'2021-11-20T14:13:46.5891468' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1892, 11, 120, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.9743440' AS DateTime2), CAST(N'2021-11-20T14:13:47.0452411' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1893, 11, 121, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:13.9775151' AS DateTime2), CAST(N'2021-11-20T14:13:47.5460814' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1894, 11, 122, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.9801874' AS DateTime2), CAST(N'2021-11-20T13:44:13.9801874' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1895, 11, 123, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.9822926' AS DateTime2), CAST(N'2021-11-20T13:44:13.9822926' AS DateTime2), 9, 9, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1896, 11, 124, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:13.9849443' AS DateTime2), CAST(N'2021-11-20T13:44:13.9849443' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1897, 11, 125, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6012643' AS DateTime2), CAST(N'2021-11-20T13:44:14.6012643' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1898, 11, 126, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6063354' AS DateTime2), CAST(N'2021-11-20T13:44:14.6063354' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1899, 11, 127, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6092467' AS DateTime2), CAST(N'2021-11-20T13:44:14.6092467' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1900, 11, 128, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6113849' AS DateTime2), CAST(N'2021-11-20T13:44:14.6113849' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1901, 11, 129, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6130337' AS DateTime2), CAST(N'2021-11-20T13:44:14.6130337' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1902, 11, 130, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6151357' AS DateTime2), CAST(N'2021-11-20T13:44:14.6151357' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1903, 11, 131, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6168087' AS DateTime2), CAST(N'2021-11-20T13:44:14.6168087' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1904, 11, 132, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6189171' AS DateTime2), CAST(N'2021-11-20T13:44:14.6189171' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1905, 11, 133, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6221021' AS DateTime2), CAST(N'2021-11-20T13:44:14.6221021' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1906, 11, 134, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:14.6237993' AS DateTime2), CAST(N'2021-11-20T13:44:14.6237993' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1907, 11, 135, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6259292' AS DateTime2), CAST(N'2021-11-20T13:44:14.6259292' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1908, 11, 137, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:14.6296600' AS DateTime2), CAST(N'2021-11-20T14:16:32.2953175' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1909, 11, 138, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:14.6323706' AS DateTime2), CAST(N'2021-11-20T13:44:14.6323706' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1910, 11, 145, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:14.6356051' AS DateTime2), CAST(N'2021-11-20T14:17:03.3338994' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1911, 11, 147, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:14.6382912' AS DateTime2), CAST(N'2021-11-20T13:44:14.6382912' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1912, 11, 148, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:15.2517259' AS DateTime2), CAST(N'2021-11-20T13:44:15.2517259' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1913, 11, 151, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:15.2544806' AS DateTime2), CAST(N'2021-11-20T13:44:15.2544806' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1914, 11, 152, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:15.2565710' AS DateTime2), CAST(N'2021-11-20T13:44:15.2565710' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1915, 11, 153, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:15.2586833' AS DateTime2), CAST(N'2021-11-20T14:14:05.0078173' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1916, 11, 154, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:15.2615081' AS DateTime2), CAST(N'2021-11-20T14:14:05.5399919' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1917, 11, 155, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.2625589' AS DateTime2), CAST(N'2021-11-20T13:44:15.2625589' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1918, 11, 156, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.2653238' AS DateTime2), CAST(N'2021-11-20T13:44:15.2653238' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1919, 11, 157, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:15.2685208' AS DateTime2), CAST(N'2021-11-20T13:44:15.2685208' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1920, 11, 158, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.2701253' AS DateTime2), CAST(N'2021-11-20T13:44:15.2701253' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1921, 11, 159, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:15.2722522' AS DateTime2), CAST(N'2021-11-20T13:44:15.2722522' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1922, 11, 160, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.2750881' AS DateTime2), CAST(N'2021-11-20T13:44:15.2750881' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1923, 11, 161, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.2771710' AS DateTime2), CAST(N'2021-11-20T13:44:15.2771710' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1924, 11, 162, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:15.2799784' AS DateTime2), CAST(N'2021-11-20T14:13:19.1130752' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1925, 11, 163, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:15.2832127' AS DateTime2), CAST(N'2021-11-20T14:13:48.0930385' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1926, 11, 164, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:15.2858993' AS DateTime2), CAST(N'2021-11-20T14:13:59.5951368' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1927, 11, 165, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:15.9332108' AS DateTime2), CAST(N'2021-11-20T14:14:06.0526120' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1928, 11, 166, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9363862' AS DateTime2), CAST(N'2021-11-20T13:44:15.9363862' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1929, 11, 180, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9391871' AS DateTime2), CAST(N'2021-11-20T13:44:15.9391871' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1930, 11, 181, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9419562' AS DateTime2), CAST(N'2021-11-20T13:44:15.9419562' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1931, 11, 182, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9451527' AS DateTime2), CAST(N'2021-11-20T13:44:15.9451527' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1932, 11, 183, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9479154' AS DateTime2), CAST(N'2021-11-20T13:44:15.9479154' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1933, 11, 184, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9501792' AS DateTime2), CAST(N'2021-11-20T13:44:15.9501792' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1934, 11, 185, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9518052' AS DateTime2), CAST(N'2021-11-20T13:44:15.9518052' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1935, 11, 186, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9539072' AS DateTime2), CAST(N'2021-11-20T13:44:15.9539072' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1936, 11, 187, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9566548' AS DateTime2), CAST(N'2021-11-20T13:44:15.9566548' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1937, 11, 188, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9587832' AS DateTime2), CAST(N'2021-11-20T13:44:15.9587832' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1938, 11, 192, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9604119' AS DateTime2), CAST(N'2021-11-20T13:44:15.9604119' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1939, 11, 193, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:15.9625656' AS DateTime2), CAST(N'2021-11-20T13:44:15.9625656' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1940, 11, 194, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9647050' AS DateTime2), CAST(N'2021-11-20T13:44:15.9647050' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1941, 11, 195, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:15.9673590' AS DateTime2), CAST(N'2021-11-20T13:44:15.9673590' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1942, 11, 196, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:16.6127931' AS DateTime2), CAST(N'2021-11-20T14:14:00.0891859' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1943, 11, 197, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:16.6170209' AS DateTime2), CAST(N'2021-11-20T14:14:00.5758056' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1944, 11, 198, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:16.6186562' AS DateTime2), CAST(N'2021-11-20T14:14:06.5360393' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1945, 11, 199, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:16.6207724' AS DateTime2), CAST(N'2021-11-20T13:44:16.6207724' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1946, 11, 200, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:16.6228523' AS DateTime2), CAST(N'2021-11-20T14:13:50.9549251' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1947, 11, 201, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:16.6255583' AS DateTime2), CAST(N'2021-11-20T13:44:16.6255583' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1948, 11, 202, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:16.6276878' AS DateTime2), CAST(N'2021-11-20T13:44:16.6276878' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1949, 11, 203, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:16.6303587' AS DateTime2), CAST(N'2021-11-20T13:44:16.6303587' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1950, 11, 204, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:16.6325048' AS DateTime2), CAST(N'2021-11-20T13:44:16.6325048' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1951, 11, 205, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:16.6352418' AS DateTime2), CAST(N'2021-11-20T13:44:16.6352418' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1952, 11, 206, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:44:16.6373169' AS DateTime2), CAST(N'2021-11-20T13:44:16.6373169' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1953, 11, 207, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:44:16.6411242' AS DateTime2), CAST(N'2021-11-20T14:16:37.6202607' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1954, 11, 209, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:16.6432253' AS DateTime2), CAST(N'2021-11-20T14:13:19.6384490' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1955, 11, 210, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:44:16.6463538' AS DateTime2), CAST(N'2021-11-20T14:14:01.0844886' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1956, 11, 212, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:44:16.6490419' AS DateTime2), CAST(N'2021-11-20T13:44:16.6490419' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1957, 12, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8471843' AS DateTime2), CAST(N'2021-11-20T13:55:42.8471843' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1958, 12, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8516219' AS DateTime2), CAST(N'2021-11-20T13:55:42.8516219' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1959, 12, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8543503' AS DateTime2), CAST(N'2021-11-20T13:55:42.8543503' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1960, 12, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8581520' AS DateTime2), CAST(N'2021-11-20T13:55:42.8581520' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1961, 12, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8609042' AS DateTime2), CAST(N'2021-11-20T13:55:42.8609042' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1962, 12, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8641215' AS DateTime2), CAST(N'2021-11-20T13:55:42.8641215' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1963, 12, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8679112' AS DateTime2), CAST(N'2021-11-20T13:55:42.8679112' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1964, 12, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8716623' AS DateTime2), CAST(N'2021-11-20T13:55:42.8716623' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1965, 12, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8737881' AS DateTime2), CAST(N'2021-11-20T13:55:42.8737881' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1966, 12, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8774816' AS DateTime2), CAST(N'2021-11-20T13:55:42.8774816' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1967, 12, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8796058' AS DateTime2), CAST(N'2021-11-20T13:55:42.8796058' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1968, 12, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8834782' AS DateTime2), CAST(N'2021-11-20T13:55:42.8834782' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1969, 12, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8866297' AS DateTime2), CAST(N'2021-11-20T13:55:42.8866297' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1970, 12, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8894039' AS DateTime2), CAST(N'2021-11-20T13:55:42.8894039' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1971, 12, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:42.8931946' AS DateTime2), CAST(N'2021-11-20T13:55:42.8931946' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1972, 12, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9272778' AS DateTime2), CAST(N'2021-11-20T13:55:44.9272778' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1973, 12, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9313259' AS DateTime2), CAST(N'2021-11-20T13:55:44.9313259' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1974, 12, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9340199' AS DateTime2), CAST(N'2021-11-20T13:55:44.9340199' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1975, 12, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9362632' AS DateTime2), CAST(N'2021-11-20T13:55:44.9362632' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1976, 12, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9378850' AS DateTime2), CAST(N'2021-11-20T13:55:44.9378850' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1977, 12, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9410617' AS DateTime2), CAST(N'2021-11-20T13:55:44.9410617' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1978, 12, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9437424' AS DateTime2), CAST(N'2021-11-20T13:55:44.9437424' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1979, 12, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9458892' AS DateTime2), CAST(N'2021-11-20T13:55:44.9458892' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1980, 12, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9485883' AS DateTime2), CAST(N'2021-11-20T13:55:44.9485883' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1981, 12, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9507367' AS DateTime2), CAST(N'2021-11-20T13:55:44.9507367' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1982, 12, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9545059' AS DateTime2), CAST(N'2021-11-20T13:55:44.9545059' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1983, 12, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9566905' AS DateTime2), CAST(N'2021-11-20T13:55:44.9566905' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1984, 12, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9594012' AS DateTime2), CAST(N'2021-11-20T13:55:44.9594012' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1985, 12, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9615590' AS DateTime2), CAST(N'2021-11-20T13:55:44.9615590' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1986, 12, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:44.9644058' AS DateTime2), CAST(N'2021-11-20T13:55:44.9644058' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1987, 12, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3560709' AS DateTime2), CAST(N'2021-11-20T13:55:46.3560709' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1988, 12, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3609849' AS DateTime2), CAST(N'2021-11-20T13:55:46.3609849' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1989, 12, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3648281' AS DateTime2), CAST(N'2021-11-20T13:55:46.3648281' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1990, 12, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3687075' AS DateTime2), CAST(N'2021-11-20T13:55:46.3687075' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1991, 12, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3716430' AS DateTime2), CAST(N'2021-11-20T13:55:46.3716430' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1992, 12, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3754868' AS DateTime2), CAST(N'2021-11-20T13:55:46.3754868' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1993, 12, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3795839' AS DateTime2), CAST(N'2021-11-20T13:55:46.3795839' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1994, 12, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3823458' AS DateTime2), CAST(N'2021-11-20T13:55:46.3823458' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1995, 12, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3861806' AS DateTime2), CAST(N'2021-11-20T13:55:46.3861806' AS DateTime2), 9, 9, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1996, 12, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3899980' AS DateTime2), CAST(N'2021-11-20T13:55:46.3899980' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1997, 12, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3921938' AS DateTime2), CAST(N'2021-11-20T13:55:46.3921938' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1998, 12, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3948797' AS DateTime2), CAST(N'2021-11-20T13:55:46.3948797' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1999, 12, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3971998' AS DateTime2), CAST(N'2021-11-20T13:55:46.3971998' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2000, 12, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.3988735' AS DateTime2), CAST(N'2021-11-20T13:55:46.3988735' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2001, 12, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:46.4020219' AS DateTime2), CAST(N'2021-11-20T13:55:46.4020219' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2002, 12, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.3949267' AS DateTime2), CAST(N'2021-11-20T13:55:48.3949267' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2003, 12, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.3986715' AS DateTime2), CAST(N'2021-11-20T13:55:48.3986715' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2004, 12, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4008285' AS DateTime2), CAST(N'2021-11-20T13:55:48.4008285' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2005, 12, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4018872' AS DateTime2), CAST(N'2021-11-20T13:55:48.4018872' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2006, 12, 50, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4045501' AS DateTime2), CAST(N'2021-11-20T13:55:48.4045501' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2007, 12, 51, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4066671' AS DateTime2), CAST(N'2021-11-20T13:55:48.4066671' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2008, 12, 52, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4093128' AS DateTime2), CAST(N'2021-11-20T13:55:48.4093128' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2009, 12, 53, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:48.4125574' AS DateTime2), CAST(N'2021-11-20T13:55:48.4125574' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2010, 12, 54, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4152339' AS DateTime2), CAST(N'2021-11-20T13:55:48.4152339' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2011, 12, 55, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:48.4183735' AS DateTime2), CAST(N'2021-11-20T13:55:48.4183735' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2012, 12, 56, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4204353' AS DateTime2), CAST(N'2021-11-20T13:55:48.4204353' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2013, 12, 57, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:48.4220861' AS DateTime2), CAST(N'2021-11-20T13:55:48.4220861' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2014, 12, 58, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4241898' AS DateTime2), CAST(N'2021-11-20T13:55:48.4241898' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2015, 12, 59, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4263070' AS DateTime2), CAST(N'2021-11-20T13:55:48.4263070' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2016, 12, 60, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:48.4290421' AS DateTime2), CAST(N'2021-11-20T13:55:48.4290421' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2017, 12, 61, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5228365' AS DateTime2), CAST(N'2021-11-20T13:55:50.5228365' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2018, 12, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5255132' AS DateTime2), CAST(N'2021-11-20T13:55:50.5255132' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2019, 12, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5287123' AS DateTime2), CAST(N'2021-11-20T13:55:50.5287123' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2020, 12, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5313493' AS DateTime2), CAST(N'2021-11-20T13:55:50.5313493' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2021, 12, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5334268' AS DateTime2), CAST(N'2021-11-20T13:55:50.5334268' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2022, 12, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5366580' AS DateTime2), CAST(N'2021-11-20T13:55:50.5366580' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2023, 12, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5392698' AS DateTime2), CAST(N'2021-11-20T13:55:50.5392698' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2024, 12, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5431110' AS DateTime2), CAST(N'2021-11-20T13:55:50.5431110' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2025, 12, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5462805' AS DateTime2), CAST(N'2021-11-20T13:55:50.5462805' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2026, 12, 74, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5490450' AS DateTime2), CAST(N'2021-11-20T13:55:50.5490450' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2027, 12, 75, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5511618' AS DateTime2), CAST(N'2021-11-20T13:55:50.5511618' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2028, 12, 76, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5538429' AS DateTime2), CAST(N'2021-11-20T13:55:50.5538429' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2029, 12, 77, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:50.5578760' AS DateTime2), CAST(N'2021-11-20T13:55:50.5578760' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2030, 12, 78, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:50.5607329' AS DateTime2), CAST(N'2021-11-20T13:55:50.5607329' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2031, 12, 79, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:50.5641621' AS DateTime2), CAST(N'2021-11-20T13:55:50.5641621' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2032, 12, 80, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:52.2971108' AS DateTime2), CAST(N'2021-11-20T13:55:52.2971108' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2033, 12, 81, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:52.3008701' AS DateTime2), CAST(N'2021-11-20T13:55:52.3008701' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2034, 12, 82, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:55:52.3030447' AS DateTime2), CAST(N'2021-11-20T14:14:22.2900742' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2035, 12, 83, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3047527' AS DateTime2), CAST(N'2021-11-20T14:14:22.9172526' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2036, 12, 84, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:55:52.3078751' AS DateTime2), CAST(N'2021-11-20T14:14:28.4783888' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2037, 12, 85, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3105430' AS DateTime2), CAST(N'2021-11-20T14:14:28.9665878' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2038, 12, 86, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3137269' AS DateTime2), CAST(N'2021-11-20T14:14:33.1636826' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2039, 12, 87, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3164620' AS DateTime2), CAST(N'2021-11-20T14:14:33.6521942' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2040, 12, 88, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3196019' AS DateTime2), CAST(N'2021-11-20T14:14:34.1265299' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2041, 12, 89, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3222872' AS DateTime2), CAST(N'2021-11-20T14:14:37.2604353' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2042, 12, 90, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3244536' AS DateTime2), CAST(N'2021-11-20T14:14:37.7581660' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2043, 12, 91, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3271680' AS DateTime2), CAST(N'2021-11-20T14:14:44.2306715' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2044, 12, 92, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3293458' AS DateTime2), CAST(N'2021-11-20T14:14:44.7167524' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2045, 12, 93, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3320711' AS DateTime2), CAST(N'2021-11-20T14:14:45.2157182' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2046, 12, 94, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:52.3352756' AS DateTime2), CAST(N'2021-11-20T14:14:50.2450186' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2047, 12, 95, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:54.5499771' AS DateTime2), CAST(N'2021-11-20T14:14:50.7127108' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2048, 12, 96, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:54.5558512' AS DateTime2), CAST(N'2021-11-20T14:14:59.0940904' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2049, 12, 97, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:54.5634996' AS DateTime2), CAST(N'2021-11-20T14:14:59.5930465' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2050, 12, 98, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:54.5656253' AS DateTime2), CAST(N'2021-11-20T14:15:00.1428849' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2051, 12, 99, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5672482' AS DateTime2), CAST(N'2021-11-20T13:55:54.5672482' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2052, 12, 100, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5693536' AS DateTime2), CAST(N'2021-11-20T13:55:54.5693536' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2053, 12, 101, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5714653' AS DateTime2), CAST(N'2021-11-20T13:55:54.5714653' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2054, 12, 102, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5742001' AS DateTime2), CAST(N'2021-11-20T13:55:54.5742001' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2055, 12, 103, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5770506' AS DateTime2), CAST(N'2021-11-20T13:55:54.5770506' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2056, 12, 104, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5791561' AS DateTime2), CAST(N'2021-11-20T13:55:54.5791561' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2057, 12, 105, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5812611' AS DateTime2), CAST(N'2021-11-20T13:55:54.5812611' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2058, 12, 106, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5828832' AS DateTime2), CAST(N'2021-11-20T13:55:54.5828832' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2059, 12, 107, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:54.5861421' AS DateTime2), CAST(N'2021-11-20T13:55:54.5861421' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2060, 12, 108, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:54.5877934' AS DateTime2), CAST(N'2021-11-20T13:55:54.5877934' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2061, 12, 109, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:54.5917497' AS DateTime2), CAST(N'2021-11-20T13:55:54.5917497' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2062, 12, 110, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:56.7312058' AS DateTime2), CAST(N'2021-11-20T13:55:56.7312058' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2063, 12, 111, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7362855' AS DateTime2), CAST(N'2021-11-20T13:55:56.7362855' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2064, 12, 112, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7390216' AS DateTime2), CAST(N'2021-11-20T13:55:56.7390216' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2065, 12, 113, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7422519' AS DateTime2), CAST(N'2021-11-20T13:55:56.7422519' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2066, 12, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:56.7449882' AS DateTime2), CAST(N'2021-11-20T13:55:56.7449882' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2067, 12, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7481879' AS DateTime2), CAST(N'2021-11-20T13:55:56.7481879' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2068, 12, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:56.7498557' AS DateTime2), CAST(N'2021-11-20T13:55:56.7498557' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2069, 12, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7530124' AS DateTime2), CAST(N'2021-11-20T13:55:56.7530124' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2070, 12, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7557482' AS DateTime2), CAST(N'2021-11-20T13:55:56.7557482' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2071, 12, 119, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7578151' AS DateTime2), CAST(N'2021-11-20T13:55:56.7578151' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2072, 12, 120, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7606486' AS DateTime2), CAST(N'2021-11-20T13:55:56.7606486' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2073, 12, 121, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7638002' AS DateTime2), CAST(N'2021-11-20T13:55:56.7638002' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2074, 12, 122, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7665908' AS DateTime2), CAST(N'2021-11-20T13:55:56.7665908' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2075, 12, 123, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7695224' AS DateTime2), CAST(N'2021-11-20T13:55:56.7695224' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2076, 12, 124, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:56.7723702' AS DateTime2), CAST(N'2021-11-20T13:55:56.7723702' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2077, 12, 125, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6182154' AS DateTime2), CAST(N'2021-11-20T13:55:58.6182154' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2078, 12, 126, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6220509' AS DateTime2), CAST(N'2021-11-20T13:55:58.6220509' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2079, 12, 127, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6266878' AS DateTime2), CAST(N'2021-11-20T13:55:58.6266878' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2080, 12, 128, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6298292' AS DateTime2), CAST(N'2021-11-20T13:55:58.6298292' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2081, 12, 129, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6327000' AS DateTime2), CAST(N'2021-11-20T13:55:58.6327000' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2082, 12, 130, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6364382' AS DateTime2), CAST(N'2021-11-20T13:55:58.6364382' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2083, 12, 131, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6403561' AS DateTime2), CAST(N'2021-11-20T13:55:58.6403561' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2084, 12, 132, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6436731' AS DateTime2), CAST(N'2021-11-20T13:55:58.6436731' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2085, 12, 133, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6481451' AS DateTime2), CAST(N'2021-11-20T13:55:58.6481451' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2086, 12, 134, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:58.6519746' AS DateTime2), CAST(N'2021-11-20T13:55:58.6519746' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2087, 12, 135, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6551150' AS DateTime2), CAST(N'2021-11-20T13:55:58.6551150' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2088, 12, 137, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:58.6591886' AS DateTime2), CAST(N'2021-11-20T13:55:58.6591886' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2089, 12, 138, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:58.6629804' AS DateTime2), CAST(N'2021-11-20T13:55:58.6629804' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2090, 12, 145, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:58.6687455' AS DateTime2), CAST(N'2021-11-20T13:55:58.6687455' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2091, 12, 147, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:58.6737349' AS DateTime2), CAST(N'2021-11-20T13:55:58.6737349' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2092, 12, 148, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:59.7954361' AS DateTime2), CAST(N'2021-11-20T13:55:59.7954361' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2093, 12, 151, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:59.7985748' AS DateTime2), CAST(N'2021-11-20T13:55:59.7985748' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2094, 12, 152, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:59.8012689' AS DateTime2), CAST(N'2021-11-20T13:55:59.8012689' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2095, 12, 153, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:59.8054917' AS DateTime2), CAST(N'2021-11-20T13:55:59.8054917' AS DateTime2), 9, 9, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2096, 12, 154, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:59.8082139' AS DateTime2), CAST(N'2021-11-20T13:55:59.8082139' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2097, 12, 155, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:59.8093179' AS DateTime2), CAST(N'2021-11-20T14:14:45.7430698' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2098, 12, 156, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:59.8120592' AS DateTime2), CAST(N'2021-11-20T14:14:46.2307816' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2099, 12, 157, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:59.8141692' AS DateTime2), CAST(N'2021-11-20T13:55:59.8141692' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2100, 12, 158, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:59.8163039' AS DateTime2), CAST(N'2021-11-20T13:55:59.8163039' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2101, 12, 159, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:55:59.8180233' AS DateTime2), CAST(N'2021-11-20T13:55:59.8180233' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2102, 12, 160, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:59.8201734' AS DateTime2), CAST(N'2021-11-20T14:14:54.5131245' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2103, 12, 161, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:55:59.8230150' AS DateTime2), CAST(N'2021-11-20T14:14:55.2436829' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2104, 12, 162, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:59.8257061' AS DateTime2), CAST(N'2021-11-20T13:55:59.8257061' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2105, 12, 163, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:59.8290244' AS DateTime2), CAST(N'2021-11-20T13:55:59.8290244' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2106, 12, 164, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:55:59.8317499' AS DateTime2), CAST(N'2021-11-20T13:55:59.8317499' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2107, 12, 165, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2328783' AS DateTime2), CAST(N'2021-11-20T13:56:01.2328783' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2108, 12, 166, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2360877' AS DateTime2), CAST(N'2021-11-20T13:56:01.2360877' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2109, 12, 180, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2387764' AS DateTime2), CAST(N'2021-11-20T13:56:01.2387764' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2110, 12, 181, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2408957' AS DateTime2), CAST(N'2021-11-20T13:56:01.2408957' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2111, 12, 182, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2436235' AS DateTime2), CAST(N'2021-11-20T13:56:01.2436235' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2112, 12, 183, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2469631' AS DateTime2), CAST(N'2021-11-20T13:56:01.2469631' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2113, 12, 184, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2486662' AS DateTime2), CAST(N'2021-11-20T13:56:01.2486662' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2114, 12, 185, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2520488' AS DateTime2), CAST(N'2021-11-20T13:56:01.2520488' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2115, 12, 186, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2554088' AS DateTime2), CAST(N'2021-11-20T13:56:01.2554088' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2116, 12, 187, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2575865' AS DateTime2), CAST(N'2021-11-20T13:56:01.2575865' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2117, 12, 188, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2597220' AS DateTime2), CAST(N'2021-11-20T13:56:01.2597220' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2118, 12, 192, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2613517' AS DateTime2), CAST(N'2021-11-20T13:56:01.2613517' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2119, 12, 193, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:56:01.2645216' AS DateTime2), CAST(N'2021-11-20T13:56:01.2645216' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2120, 12, 194, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2661736' AS DateTime2), CAST(N'2021-11-20T13:56:01.2661736' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2121, 12, 195, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:01.2693772' AS DateTime2), CAST(N'2021-11-20T13:56:01.2693772' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2122, 12, 196, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7437961' AS DateTime2), CAST(N'2021-11-20T13:56:02.7437961' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2123, 12, 197, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7465452' AS DateTime2), CAST(N'2021-11-20T13:56:02.7465452' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2124, 12, 198, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7486797' AS DateTime2), CAST(N'2021-11-20T13:56:02.7486797' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2125, 12, 199, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:56:02.7507708' AS DateTime2), CAST(N'2021-11-20T14:14:46.7332986' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2126, 12, 200, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7534666' AS DateTime2), CAST(N'2021-11-20T13:56:02.7534666' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2127, 12, 201, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7545542' AS DateTime2), CAST(N'2021-11-20T13:56:02.7545542' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2128, 12, 202, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7573200' AS DateTime2), CAST(N'2021-11-20T13:56:02.7573200' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2129, 12, 203, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7594635' AS DateTime2), CAST(N'2021-11-20T13:56:02.7594635' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2130, 12, 204, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7622471' AS DateTime2), CAST(N'2021-11-20T13:56:02.7622471' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2131, 12, 205, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7644031' AS DateTime2), CAST(N'2021-11-20T13:56:02.7644031' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2132, 12, 206, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:56:02.7671095' AS DateTime2), CAST(N'2021-11-20T13:56:02.7671095' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2133, 12, 207, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:56:02.7692007' AS DateTime2), CAST(N'2021-11-20T13:56:02.7692007' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2134, 12, 209, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7708530' AS DateTime2), CAST(N'2021-11-20T13:56:02.7708530' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2135, 12, 210, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:56:02.7729671' AS DateTime2), CAST(N'2021-11-20T13:56:02.7729671' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2136, 12, 212, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:56:02.7750678' AS DateTime2), CAST(N'2021-11-20T14:14:34.6208663' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2137, 13, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3332905' AS DateTime2), CAST(N'2021-11-20T13:57:06.3332905' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2138, 13, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3359454' AS DateTime2), CAST(N'2021-11-20T13:57:06.3359454' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2139, 13, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3380607' AS DateTime2), CAST(N'2021-11-20T13:57:06.3380607' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2140, 13, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3407562' AS DateTime2), CAST(N'2021-11-20T13:57:06.3407562' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2141, 13, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3429271' AS DateTime2), CAST(N'2021-11-20T13:57:06.3429271' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2142, 13, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3456369' AS DateTime2), CAST(N'2021-11-20T13:57:06.3456369' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2143, 13, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3488611' AS DateTime2), CAST(N'2021-11-20T13:57:06.3488611' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2144, 13, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3516969' AS DateTime2), CAST(N'2021-11-20T13:57:06.3516969' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2145, 13, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3543808' AS DateTime2), CAST(N'2021-11-20T13:57:06.3543808' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2146, 13, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3568117' AS DateTime2), CAST(N'2021-11-20T13:57:06.3568117' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2147, 13, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3584751' AS DateTime2), CAST(N'2021-11-20T13:57:06.3584751' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2148, 13, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3616225' AS DateTime2), CAST(N'2021-11-20T13:57:06.3616225' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2149, 13, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3632416' AS DateTime2), CAST(N'2021-11-20T13:57:06.3632416' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2150, 13, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3654046' AS DateTime2), CAST(N'2021-11-20T13:57:06.3654046' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2151, 13, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:06.3681664' AS DateTime2), CAST(N'2021-11-20T13:57:06.3681664' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2152, 13, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1345923' AS DateTime2), CAST(N'2021-11-20T13:57:09.1345923' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2153, 13, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1367749' AS DateTime2), CAST(N'2021-11-20T13:57:09.1367749' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2154, 13, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1388526' AS DateTime2), CAST(N'2021-11-20T13:57:09.1388526' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2155, 13, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1415160' AS DateTime2), CAST(N'2021-11-20T13:57:09.1415160' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2156, 13, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1425674' AS DateTime2), CAST(N'2021-11-20T13:57:09.1425674' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2157, 13, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1453443' AS DateTime2), CAST(N'2021-11-20T13:57:09.1453443' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2158, 13, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1474495' AS DateTime2), CAST(N'2021-11-20T13:57:09.1474495' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2159, 13, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1485368' AS DateTime2), CAST(N'2021-11-20T13:57:09.1485368' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2160, 13, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1512528' AS DateTime2), CAST(N'2021-11-20T13:57:09.1512528' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2161, 13, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1534126' AS DateTime2), CAST(N'2021-11-20T13:57:09.1534126' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2162, 13, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1560720' AS DateTime2), CAST(N'2021-11-20T13:57:09.1560720' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2163, 13, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1581918' AS DateTime2), CAST(N'2021-11-20T13:57:09.1581918' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2164, 13, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1602606' AS DateTime2), CAST(N'2021-11-20T13:57:09.1602606' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2165, 13, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1629457' AS DateTime2), CAST(N'2021-11-20T13:57:09.1629457' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2166, 13, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:09.1651687' AS DateTime2), CAST(N'2021-11-20T13:57:09.1651687' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2167, 13, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8259835' AS DateTime2), CAST(N'2021-11-20T13:57:12.8259835' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2168, 13, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8298126' AS DateTime2), CAST(N'2021-11-20T13:57:12.8298126' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2169, 13, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8319345' AS DateTime2), CAST(N'2021-11-20T13:57:12.8319345' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2170, 13, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8357038' AS DateTime2), CAST(N'2021-11-20T13:57:12.8357038' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2171, 13, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8378211' AS DateTime2), CAST(N'2021-11-20T13:57:12.8378211' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2172, 13, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8394225' AS DateTime2), CAST(N'2021-11-20T13:57:12.8394225' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2173, 13, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8427079' AS DateTime2), CAST(N'2021-11-20T13:57:12.8427079' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2174, 13, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8444558' AS DateTime2), CAST(N'2021-11-20T13:57:12.8444558' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2175, 13, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8465642' AS DateTime2), CAST(N'2021-11-20T13:57:12.8465642' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2176, 13, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8494680' AS DateTime2), CAST(N'2021-11-20T13:57:12.8494680' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2177, 13, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8532621' AS DateTime2), CAST(N'2021-11-20T13:57:12.8532621' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2178, 13, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8575299' AS DateTime2), CAST(N'2021-11-20T13:57:12.8575299' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2179, 13, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8602546' AS DateTime2), CAST(N'2021-11-20T13:57:12.8602546' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2180, 13, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8640783' AS DateTime2), CAST(N'2021-11-20T13:57:12.8640783' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2181, 13, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:12.8690399' AS DateTime2), CAST(N'2021-11-20T13:57:12.8690399' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2182, 13, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4001529' AS DateTime2), CAST(N'2021-11-20T13:57:15.4001529' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2183, 13, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4039971' AS DateTime2), CAST(N'2021-11-20T13:57:15.4039971' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2184, 13, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4061002' AS DateTime2), CAST(N'2021-11-20T13:57:15.4061002' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2185, 13, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4077229' AS DateTime2), CAST(N'2021-11-20T13:57:15.4077229' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2186, 13, 50, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4109137' AS DateTime2), CAST(N'2021-11-20T13:57:15.4109137' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2187, 13, 51, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4119514' AS DateTime2), CAST(N'2021-11-20T13:57:15.4119514' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2188, 13, 52, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4145733' AS DateTime2), CAST(N'2021-11-20T13:57:15.4145733' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2189, 13, 53, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:15.4167230' AS DateTime2), CAST(N'2021-11-20T13:57:15.4167230' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2190, 13, 54, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4189217' AS DateTime2), CAST(N'2021-11-20T13:57:15.4189217' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2191, 13, 55, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:15.4205296' AS DateTime2), CAST(N'2021-11-20T13:57:15.4205296' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2192, 13, 56, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4226385' AS DateTime2), CAST(N'2021-11-20T13:57:15.4226385' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2193, 13, 57, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:15.4253939' AS DateTime2), CAST(N'2021-11-20T13:57:15.4253939' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2194, 13, 58, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4274792' AS DateTime2), CAST(N'2021-11-20T13:57:15.4274792' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2195, 13, 59, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4295870' AS DateTime2), CAST(N'2021-11-20T13:57:15.4295870' AS DateTime2), 9, 9, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2196, 13, 60, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:15.4312039' AS DateTime2), CAST(N'2021-11-20T13:57:15.4312039' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2197, 13, 61, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9242573' AS DateTime2), CAST(N'2021-11-20T13:57:17.9242573' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2198, 13, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9284991' AS DateTime2), CAST(N'2021-11-20T13:57:17.9284991' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2199, 13, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9323653' AS DateTime2), CAST(N'2021-11-20T13:57:17.9323653' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2200, 13, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9351246' AS DateTime2), CAST(N'2021-11-20T13:57:17.9351246' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2201, 13, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9383047' AS DateTime2), CAST(N'2021-11-20T13:57:17.9383047' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2202, 13, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9399368' AS DateTime2), CAST(N'2021-11-20T13:57:17.9399368' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2203, 13, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9420639' AS DateTime2), CAST(N'2021-11-20T13:57:17.9420639' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2204, 13, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9448042' AS DateTime2), CAST(N'2021-11-20T13:57:17.9448042' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2205, 13, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9469240' AS DateTime2), CAST(N'2021-11-20T13:57:17.9469240' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2206, 13, 74, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9496921' AS DateTime2), CAST(N'2021-11-20T13:57:17.9496921' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2207, 13, 75, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9517024' AS DateTime2), CAST(N'2021-11-20T13:57:17.9517024' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2208, 13, 76, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9544612' AS DateTime2), CAST(N'2021-11-20T13:57:17.9544612' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2209, 13, 77, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:17.9567818' AS DateTime2), CAST(N'2021-11-20T13:57:17.9567818' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2210, 13, 78, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:17.9594605' AS DateTime2), CAST(N'2021-11-20T13:57:17.9594605' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2211, 13, 79, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:17.9616210' AS DateTime2), CAST(N'2021-11-20T13:57:17.9616210' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2212, 13, 80, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6390931' AS DateTime2), CAST(N'2021-11-20T13:57:20.6390931' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2213, 13, 81, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:20.6430473' AS DateTime2), CAST(N'2021-11-20T13:57:20.6430473' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2214, 13, 82, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:20.6451969' AS DateTime2), CAST(N'2021-11-20T13:57:20.6451969' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2215, 13, 83, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6468387' AS DateTime2), CAST(N'2021-11-20T13:57:20.6468387' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2216, 13, 84, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:20.6502227' AS DateTime2), CAST(N'2021-11-20T13:57:20.6502227' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2217, 13, 85, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6518347' AS DateTime2), CAST(N'2021-11-20T13:57:20.6518347' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2218, 13, 86, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6545737' AS DateTime2), CAST(N'2021-11-20T13:57:20.6545737' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2219, 13, 87, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6577937' AS DateTime2), CAST(N'2021-11-20T13:57:20.6577937' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2220, 13, 88, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6594134' AS DateTime2), CAST(N'2021-11-20T13:57:20.6594134' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2221, 13, 89, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6625977' AS DateTime2), CAST(N'2021-11-20T13:57:20.6625977' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2222, 13, 90, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6647187' AS DateTime2), CAST(N'2021-11-20T13:57:20.6647187' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2223, 13, 91, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6674963' AS DateTime2), CAST(N'2021-11-20T13:57:20.6674963' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2224, 13, 92, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6695550' AS DateTime2), CAST(N'2021-11-20T13:57:20.6695550' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2225, 13, 93, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6723518' AS DateTime2), CAST(N'2021-11-20T13:57:20.6723518' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2226, 13, 94, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:20.6751494' AS DateTime2), CAST(N'2021-11-20T13:57:20.6751494' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2227, 13, 95, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6051298' AS DateTime2), CAST(N'2021-11-20T13:57:23.6051298' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2228, 13, 96, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6095541' AS DateTime2), CAST(N'2021-11-20T13:57:23.6095541' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2229, 13, 97, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6128420' AS DateTime2), CAST(N'2021-11-20T13:57:23.6128420' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2230, 13, 98, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6156623' AS DateTime2), CAST(N'2021-11-20T13:57:23.6156623' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2231, 13, 99, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6196479' AS DateTime2), CAST(N'2021-11-20T13:57:23.6196479' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2232, 13, 100, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6235176' AS DateTime2), CAST(N'2021-11-20T13:57:23.6235176' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2233, 13, 101, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6262819' AS DateTime2), CAST(N'2021-11-20T13:57:23.6262819' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2234, 13, 102, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6301074' AS DateTime2), CAST(N'2021-11-20T13:57:23.6301074' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2235, 13, 103, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6340714' AS DateTime2), CAST(N'2021-11-20T13:57:23.6340714' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2236, 13, 104, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6374116' AS DateTime2), CAST(N'2021-11-20T13:57:23.6374116' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2237, 13, 105, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6407888' AS DateTime2), CAST(N'2021-11-20T13:57:23.6407888' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2238, 13, 106, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6441080' AS DateTime2), CAST(N'2021-11-20T13:57:23.6441080' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2239, 13, 107, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:23.6468793' AS DateTime2), CAST(N'2021-11-20T13:57:23.6468793' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2240, 13, 108, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:23.6496247' AS DateTime2), CAST(N'2021-11-20T13:57:23.6496247' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2241, 13, 109, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:23.6517574' AS DateTime2), CAST(N'2021-11-20T13:57:23.6517574' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2242, 13, 110, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:30.5342132' AS DateTime2), CAST(N'2021-11-20T13:57:30.5342132' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2243, 13, 111, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5392431' AS DateTime2), CAST(N'2021-11-20T13:57:30.5392431' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2244, 13, 112, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5419365' AS DateTime2), CAST(N'2021-11-20T13:57:30.5419365' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2245, 13, 113, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5447909' AS DateTime2), CAST(N'2021-11-20T13:57:30.5447909' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2246, 13, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:30.5479514' AS DateTime2), CAST(N'2021-11-20T13:57:30.5479514' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2247, 13, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5507813' AS DateTime2), CAST(N'2021-11-20T13:57:30.5507813' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2248, 13, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:30.5535040' AS DateTime2), CAST(N'2021-11-20T13:57:30.5535040' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2249, 13, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5556578' AS DateTime2), CAST(N'2021-11-20T13:57:30.5556578' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2250, 13, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5599470' AS DateTime2), CAST(N'2021-11-20T13:57:30.5599470' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2251, 13, 119, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5648905' AS DateTime2), CAST(N'2021-11-20T13:57:30.5648905' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2252, 13, 120, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5681482' AS DateTime2), CAST(N'2021-11-20T13:57:30.5681482' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2253, 13, 121, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:30.5714060' AS DateTime2), CAST(N'2021-11-20T13:57:30.5714060' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2254, 13, 122, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:30.5742298' AS DateTime2), CAST(N'2021-11-20T14:15:13.9440450' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2255, 13, 123, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:30.5769456' AS DateTime2), CAST(N'2021-11-20T14:15:14.4632723' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2256, 13, 124, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:30.5802259' AS DateTime2), CAST(N'2021-11-20T14:15:17.7024911' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2257, 13, 125, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7131042' AS DateTime2), CAST(N'2021-11-20T14:15:18.2513365' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2258, 13, 126, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7170516' AS DateTime2), CAST(N'2021-11-20T14:15:21.7617388' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2259, 13, 127, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7197095' AS DateTime2), CAST(N'2021-11-20T14:15:22.2971691' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2260, 13, 128, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7225090' AS DateTime2), CAST(N'2021-11-20T14:15:25.6262284' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2261, 13, 129, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7252886' AS DateTime2), CAST(N'2021-11-20T14:15:26.2098267' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2262, 13, 130, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:31.7285573' AS DateTime2), CAST(N'2021-11-20T13:57:31.7285573' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2263, 13, 131, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:31.7323598' AS DateTime2), CAST(N'2021-11-20T13:57:31.7323598' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2264, 13, 132, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7361506' AS DateTime2), CAST(N'2021-11-20T14:15:30.7213602' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2265, 13, 133, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7406326' AS DateTime2), CAST(N'2021-11-20T14:15:31.2036413' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2266, 13, 134, N'', 1, 1, 1, 1, 1, 0, CAST(N'2021-11-20T13:57:31.7460527' AS DateTime2), CAST(N'2021-11-20T14:15:10.9843106' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2267, 13, 135, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:31.7509781' AS DateTime2), CAST(N'2021-11-20T14:15:11.5351160' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2268, 13, 137, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:31.7557187' AS DateTime2), CAST(N'2021-11-20T13:57:31.7557187' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2269, 13, 138, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:31.7605106' AS DateTime2), CAST(N'2021-11-20T13:57:31.7605106' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2270, 13, 145, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:31.7647349' AS DateTime2), CAST(N'2021-11-20T13:57:31.7647349' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2271, 13, 147, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:31.7696479' AS DateTime2), CAST(N'2021-11-20T13:57:31.7696479' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2272, 13, 148, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:32.8887059' AS DateTime2), CAST(N'2021-11-20T13:57:32.8887059' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2273, 13, 151, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:32.8924501' AS DateTime2), CAST(N'2021-11-20T13:57:32.8924501' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2274, 13, 152, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:32.8951653' AS DateTime2), CAST(N'2021-11-20T13:57:32.8951653' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2275, 13, 153, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.8983215' AS DateTime2), CAST(N'2021-11-20T13:57:32.8983215' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2276, 13, 154, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9010516' AS DateTime2), CAST(N'2021-11-20T13:57:32.9010516' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2277, 13, 155, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9042553' AS DateTime2), CAST(N'2021-11-20T13:57:32.9042553' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2278, 13, 156, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9070205' AS DateTime2), CAST(N'2021-11-20T13:57:32.9070205' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2279, 13, 157, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:32.9091734' AS DateTime2), CAST(N'2021-11-20T13:57:32.9091734' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2280, 13, 158, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9118980' AS DateTime2), CAST(N'2021-11-20T13:57:32.9118980' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2281, 13, 159, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:32.9139877' AS DateTime2), CAST(N'2021-11-20T13:57:32.9139877' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2282, 13, 160, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9167376' AS DateTime2), CAST(N'2021-11-20T13:57:32.9167376' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2283, 13, 161, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9188999' AS DateTime2), CAST(N'2021-11-20T13:57:32.9188999' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2284, 13, 162, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9216624' AS DateTime2), CAST(N'2021-11-20T13:57:32.9216624' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2285, 13, 163, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9237732' AS DateTime2), CAST(N'2021-11-20T13:57:32.9237732' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2286, 13, 164, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:32.9265122' AS DateTime2), CAST(N'2021-11-20T13:57:32.9265122' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2287, 13, 165, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0329134' AS DateTime2), CAST(N'2021-11-20T13:57:34.0329134' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2288, 13, 166, N'', 2, 2, 2, 1, 2, 0, CAST(N'2021-11-20T13:57:34.0366996' AS DateTime2), CAST(N'2021-11-20T14:15:31.6697738' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2289, 13, 180, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0399190' AS DateTime2), CAST(N'2021-11-20T13:57:34.0399190' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2290, 13, 181, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0426158' AS DateTime2), CAST(N'2021-11-20T13:57:34.0426158' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2291, 13, 182, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0458790' AS DateTime2), CAST(N'2021-11-20T13:57:34.0458790' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2292, 13, 183, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0496458' AS DateTime2), CAST(N'2021-11-20T13:57:34.0496458' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2293, 13, 184, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0524143' AS DateTime2), CAST(N'2021-11-20T13:57:34.0524143' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2294, 13, 185, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0556823' AS DateTime2), CAST(N'2021-11-20T13:57:34.0556823' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2295, 13, 186, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0584001' AS DateTime2), CAST(N'2021-11-20T13:57:34.0584001' AS DateTime2), 9, 9, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2296, 13, 187, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0632713' AS DateTime2), CAST(N'2021-11-20T13:57:34.0632713' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2297, 13, 188, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0654001' AS DateTime2), CAST(N'2021-11-20T13:57:34.0654001' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2298, 13, 192, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0681962' AS DateTime2), CAST(N'2021-11-20T13:57:34.0681962' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2299, 13, 193, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:34.0720528' AS DateTime2), CAST(N'2021-11-20T13:57:34.0720528' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2300, 13, 194, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0743217' AS DateTime2), CAST(N'2021-11-20T13:57:34.0743217' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2301, 13, 195, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:34.0759862' AS DateTime2), CAST(N'2021-11-20T13:57:34.0759862' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2302, 13, 196, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2154238' AS DateTime2), CAST(N'2021-11-20T13:57:35.2154238' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2303, 13, 197, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2204733' AS DateTime2), CAST(N'2021-11-20T13:57:35.2204733' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2304, 13, 198, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2253246' AS DateTime2), CAST(N'2021-11-20T13:57:35.2253246' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2305, 13, 199, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2302164' AS DateTime2), CAST(N'2021-11-20T13:57:35.2302164' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2306, 13, 200, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2340013' AS DateTime2), CAST(N'2021-11-20T13:57:35.2340013' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2307, 13, 201, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2388839' AS DateTime2), CAST(N'2021-11-20T13:57:35.2388839' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2308, 13, 202, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2431788' AS DateTime2), CAST(N'2021-11-20T13:57:35.2431788' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2309, 13, 203, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2476505' AS DateTime2), CAST(N'2021-11-20T13:57:35.2476505' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2310, 13, 204, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2524962' AS DateTime2), CAST(N'2021-11-20T13:57:35.2524962' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2311, 13, 205, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2567729' AS DateTime2), CAST(N'2021-11-20T13:57:35.2567729' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2312, 13, 206, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:35.2605464' AS DateTime2), CAST(N'2021-11-20T13:57:35.2605464' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2313, 13, 207, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-20T13:57:35.2663637' AS DateTime2), CAST(N'2021-11-20T13:57:35.2663637' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2314, 13, 209, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2700991' AS DateTime2), CAST(N'2021-11-20T13:57:35.2700991' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2315, 13, 210, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2733034' AS DateTime2), CAST(N'2021-11-20T13:57:35.2733034' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2316, 13, 212, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-20T13:57:35.2782000' AS DateTime2), CAST(N'2021-11-20T13:57:35.2782000' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2317, 15, 1, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7418398' AS DateTime2), CAST(N'2021-11-22T15:42:42.7418398' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2318, 15, 2, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7617447' AS DateTime2), CAST(N'2021-11-22T15:42:42.7617447' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2319, 15, 3, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7644947' AS DateTime2), CAST(N'2021-11-22T15:42:42.7644947' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2320, 15, 4, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7673660' AS DateTime2), CAST(N'2021-11-22T15:42:42.7673660' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2321, 15, 5, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7694439' AS DateTime2), CAST(N'2021-11-22T15:42:42.7694439' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2322, 15, 6, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7723457' AS DateTime2), CAST(N'2021-11-22T15:42:42.7723457' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2323, 15, 7, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7744146' AS DateTime2), CAST(N'2021-11-22T15:42:42.7744146' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2324, 15, 8, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7761956' AS DateTime2), CAST(N'2021-11-22T15:42:42.7761956' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2325, 15, 9, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7782805' AS DateTime2), CAST(N'2021-11-22T15:42:42.7782805' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2326, 15, 10, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7809858' AS DateTime2), CAST(N'2021-11-22T15:42:42.7809858' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2327, 15, 11, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7830925' AS DateTime2), CAST(N'2021-11-22T15:42:42.7830925' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2328, 15, 12, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7858455' AS DateTime2), CAST(N'2021-11-22T15:42:42.7858455' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2329, 15, 13, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7879684' AS DateTime2), CAST(N'2021-11-22T15:42:42.7879684' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2330, 15, 14, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7908479' AS DateTime2), CAST(N'2021-11-22T15:42:42.7908479' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2331, 15, 15, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7935738' AS DateTime2), CAST(N'2021-11-22T15:42:42.7935738' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2332, 15, 16, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7968219' AS DateTime2), CAST(N'2021-11-22T15:42:42.7968219' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2333, 15, 17, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.7984778' AS DateTime2), CAST(N'2021-11-22T15:42:42.7984778' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2334, 15, 18, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8015217' AS DateTime2), CAST(N'2021-11-22T15:42:42.8015217' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2335, 15, 19, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8036601' AS DateTime2), CAST(N'2021-11-22T15:42:42.8036601' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2336, 15, 20, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8052995' AS DateTime2), CAST(N'2021-11-22T15:42:42.8052995' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2337, 15, 21, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8074148' AS DateTime2), CAST(N'2021-11-22T15:42:42.8074148' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2338, 15, 22, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8101455' AS DateTime2), CAST(N'2021-11-22T15:42:42.8101455' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2339, 15, 23, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8122756' AS DateTime2), CAST(N'2021-11-22T15:42:42.8122756' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2340, 15, 24, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8154822' AS DateTime2), CAST(N'2021-11-22T15:42:42.8154822' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2341, 15, 25, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8183252' AS DateTime2), CAST(N'2021-11-22T15:42:42.8183252' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2342, 15, 26, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8210595' AS DateTime2), CAST(N'2021-11-22T15:42:42.8210595' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2343, 15, 27, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8231552' AS DateTime2), CAST(N'2021-11-22T15:42:42.8231552' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2344, 15, 28, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8258963' AS DateTime2), CAST(N'2021-11-22T15:42:42.8258963' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2345, 15, 29, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8296954' AS DateTime2), CAST(N'2021-11-22T15:42:42.8296954' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2346, 15, 30, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8318355' AS DateTime2), CAST(N'2021-11-22T15:42:42.8318355' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2347, 15, 31, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8369294' AS DateTime2), CAST(N'2021-11-22T15:42:42.8369294' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2348, 15, 32, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8413965' AS DateTime2), CAST(N'2021-11-22T15:42:42.8413965' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2349, 15, 33, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8435453' AS DateTime2), CAST(N'2021-11-22T15:42:42.8435453' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2350, 15, 34, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8473608' AS DateTime2), CAST(N'2021-11-22T15:42:42.8473608' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2351, 15, 35, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8512475' AS DateTime2), CAST(N'2021-11-22T15:42:42.8512475' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2352, 15, 36, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8555225' AS DateTime2), CAST(N'2021-11-22T15:42:42.8555225' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2353, 15, 37, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8592725' AS DateTime2), CAST(N'2021-11-22T15:42:42.8592725' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2354, 15, 38, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8631561' AS DateTime2), CAST(N'2021-11-22T15:42:42.8631561' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2355, 15, 39, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8658657' AS DateTime2), CAST(N'2021-11-22T15:42:42.8658657' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2356, 15, 40, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8776249' AS DateTime2), CAST(N'2021-11-22T15:42:42.8776249' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2357, 15, 41, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8814959' AS DateTime2), CAST(N'2021-11-22T15:42:42.8814959' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2358, 15, 42, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8864548' AS DateTime2), CAST(N'2021-11-22T15:42:42.8864548' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2359, 15, 43, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8913666' AS DateTime2), CAST(N'2021-11-22T15:42:42.8913666' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2360, 15, 44, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.8951951' AS DateTime2), CAST(N'2021-11-22T15:42:42.8951951' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2361, 15, 45, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9001579' AS DateTime2), CAST(N'2021-11-22T15:42:42.9001579' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2362, 15, 46, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9039858' AS DateTime2), CAST(N'2021-11-22T15:42:42.9039858' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2363, 15, 47, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9072752' AS DateTime2), CAST(N'2021-11-22T15:42:42.9072752' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2364, 15, 48, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9110541' AS DateTime2), CAST(N'2021-11-22T15:42:42.9110541' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2365, 15, 49, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9139256' AS DateTime2), CAST(N'2021-11-22T15:42:42.9139256' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2366, 15, 50, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9166679' AS DateTime2), CAST(N'2021-11-22T15:42:42.9166679' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2367, 15, 51, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9198853' AS DateTime2), CAST(N'2021-11-22T15:42:42.9198853' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2368, 15, 52, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9237887' AS DateTime2), CAST(N'2021-11-22T15:42:42.9237887' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2369, 15, 53, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:42.9275364' AS DateTime2), CAST(N'2021-11-22T15:42:42.9275364' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2370, 15, 54, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9303896' AS DateTime2), CAST(N'2021-11-22T15:42:42.9303896' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2371, 15, 55, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:42.9342502' AS DateTime2), CAST(N'2021-11-22T15:42:42.9342502' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2372, 15, 56, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9374802' AS DateTime2), CAST(N'2021-11-22T15:42:42.9374802' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2373, 15, 57, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:42.9401815' AS DateTime2), CAST(N'2021-11-22T15:42:42.9401815' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2374, 15, 58, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9450736' AS DateTime2), CAST(N'2021-11-22T15:42:42.9450736' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2375, 15, 59, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9483251' AS DateTime2), CAST(N'2021-11-22T15:42:42.9483251' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2376, 15, 60, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9499777' AS DateTime2), CAST(N'2021-11-22T15:42:42.9499777' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2377, 15, 61, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9557748' AS DateTime2), CAST(N'2021-11-22T15:42:42.9557748' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2378, 15, 63, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9596319' AS DateTime2), CAST(N'2021-11-22T15:42:42.9596319' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2379, 15, 65, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9659128' AS DateTime2), CAST(N'2021-11-22T15:42:42.9659128' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2380, 15, 67, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9703040' AS DateTime2), CAST(N'2021-11-22T15:42:42.9703040' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2381, 15, 68, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9743703' AS DateTime2), CAST(N'2021-11-22T15:42:42.9743703' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2382, 15, 69, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9774683' AS DateTime2), CAST(N'2021-11-22T15:42:42.9774683' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2383, 15, 70, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9812574' AS DateTime2), CAST(N'2021-11-22T15:42:42.9812574' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2384, 15, 71, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9840320' AS DateTime2), CAST(N'2021-11-22T15:42:42.9840320' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2385, 15, 72, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9889603' AS DateTime2), CAST(N'2021-11-22T15:42:42.9889603' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2386, 15, 74, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9910649' AS DateTime2), CAST(N'2021-11-22T15:42:42.9910649' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2387, 15, 75, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9948512' AS DateTime2), CAST(N'2021-11-22T15:42:42.9948512' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2388, 15, 76, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:42.9986318' AS DateTime2), CAST(N'2021-11-22T15:42:42.9986318' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2389, 15, 77, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.0029707' AS DateTime2), CAST(N'2021-11-22T15:42:43.0029707' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2390, 15, 78, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0078804' AS DateTime2), CAST(N'2021-11-22T15:42:43.0078804' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2391, 15, 79, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0116596' AS DateTime2), CAST(N'2021-11-22T15:42:43.0116596' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2392, 15, 80, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0163979' AS DateTime2), CAST(N'2021-11-22T15:42:43.0163979' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2393, 15, 81, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.0201749' AS DateTime2), CAST(N'2021-11-22T15:42:43.0201749' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2394, 15, 82, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.0260777' AS DateTime2), CAST(N'2021-11-22T15:42:43.0260777' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2395, 15, 83, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0312389' AS DateTime2), CAST(N'2021-11-22T15:42:43.0312389' AS DateTime2), NULL, NULL, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2396, 15, 84, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.0361002' AS DateTime2), CAST(N'2021-11-22T15:42:43.0361002' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2397, 15, 85, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0417522' AS DateTime2), CAST(N'2021-11-22T15:42:43.0417522' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2398, 15, 86, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0455175' AS DateTime2), CAST(N'2021-11-22T15:42:43.0455175' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2399, 15, 87, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0498005' AS DateTime2), CAST(N'2021-11-22T15:42:43.0498005' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2400, 15, 88, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0536455' AS DateTime2), CAST(N'2021-11-22T15:42:43.0536455' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2401, 15, 89, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0585564' AS DateTime2), CAST(N'2021-11-22T15:42:43.0585564' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2402, 15, 90, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0623166' AS DateTime2), CAST(N'2021-11-22T15:42:43.0623166' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2403, 15, 91, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0662806' AS DateTime2), CAST(N'2021-11-22T15:42:43.0662806' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2404, 15, 92, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0701097' AS DateTime2), CAST(N'2021-11-22T15:42:43.0701097' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2405, 15, 93, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0739237' AS DateTime2), CAST(N'2021-11-22T15:42:43.0739237' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2406, 15, 94, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0788111' AS DateTime2), CAST(N'2021-11-22T15:42:43.0788111' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2407, 15, 95, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0825844' AS DateTime2), CAST(N'2021-11-22T15:42:43.0825844' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2408, 15, 96, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0868186' AS DateTime2), CAST(N'2021-11-22T15:42:43.0868186' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2409, 15, 97, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0915887' AS DateTime2), CAST(N'2021-11-22T15:42:43.0915887' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2410, 15, 98, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0953271' AS DateTime2), CAST(N'2021-11-22T15:42:43.0953271' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2411, 15, 99, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.0995738' AS DateTime2), CAST(N'2021-11-22T15:42:43.0995738' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2412, 15, 100, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1033969' AS DateTime2), CAST(N'2021-11-22T15:42:43.1033969' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2413, 15, 101, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1072299' AS DateTime2), CAST(N'2021-11-22T15:42:43.1072299' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2414, 15, 102, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1120777' AS DateTime2), CAST(N'2021-11-22T15:42:43.1120777' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2415, 15, 103, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1158363' AS DateTime2), CAST(N'2021-11-22T15:42:43.1158363' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2416, 15, 104, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1201268' AS DateTime2), CAST(N'2021-11-22T15:42:43.1201268' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2417, 15, 105, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1227981' AS DateTime2), CAST(N'2021-11-22T15:42:43.1227981' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2418, 15, 106, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1265453' AS DateTime2), CAST(N'2021-11-22T15:42:43.1265453' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2419, 15, 107, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.1345048' AS DateTime2), CAST(N'2021-11-22T15:42:43.1345048' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2420, 15, 108, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.1394403' AS DateTime2), CAST(N'2021-11-22T15:42:43.1394403' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2421, 15, 109, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1489928' AS DateTime2), CAST(N'2021-11-22T15:42:43.1489928' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2422, 15, 110, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.1521668' AS DateTime2), CAST(N'2021-11-22T15:42:43.1521668' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2423, 15, 111, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1569819' AS DateTime2), CAST(N'2021-11-22T15:42:43.1569819' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2424, 15, 112, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1608389' AS DateTime2), CAST(N'2021-11-22T15:42:43.1608389' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2425, 15, 113, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1646256' AS DateTime2), CAST(N'2021-11-22T15:42:43.1646256' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2426, 15, 114, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.1695342' AS DateTime2), CAST(N'2021-11-22T15:42:43.1695342' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2427, 15, 115, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1727030' AS DateTime2), CAST(N'2021-11-22T15:42:43.1727030' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2428, 15, 116, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.1775971' AS DateTime2), CAST(N'2021-11-22T15:42:43.1775971' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2429, 15, 117, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1813394' AS DateTime2), CAST(N'2021-11-22T15:42:43.1813394' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2430, 15, 118, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1851971' AS DateTime2), CAST(N'2021-11-22T15:42:43.1851971' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2431, 15, 119, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1901248' AS DateTime2), CAST(N'2021-11-22T15:42:43.1901248' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2432, 15, 120, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1950230' AS DateTime2), CAST(N'2021-11-22T15:42:43.1950230' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2433, 15, 121, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.1988099' AS DateTime2), CAST(N'2021-11-22T15:42:43.1988099' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2434, 15, 122, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2046700' AS DateTime2), CAST(N'2021-11-22T15:42:43.2046700' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2435, 15, 123, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2095062' AS DateTime2), CAST(N'2021-11-22T15:42:43.2095062' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2436, 15, 124, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2155872' AS DateTime2), CAST(N'2021-11-22T15:42:43.2155872' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2437, 15, 125, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2214868' AS DateTime2), CAST(N'2021-11-22T15:42:43.2214868' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2438, 15, 126, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2284769' AS DateTime2), CAST(N'2021-11-22T15:42:43.2284769' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2439, 15, 127, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2344309' AS DateTime2), CAST(N'2021-11-22T15:42:43.2344309' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2440, 15, 128, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2392602' AS DateTime2), CAST(N'2021-11-22T15:42:43.2392602' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2441, 15, 129, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2440051' AS DateTime2), CAST(N'2021-11-22T15:42:43.2440051' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2442, 15, 130, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2487767' AS DateTime2), CAST(N'2021-11-22T15:42:43.2487767' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2443, 15, 131, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2535398' AS DateTime2), CAST(N'2021-11-22T15:42:43.2535398' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2444, 15, 132, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2577606' AS DateTime2), CAST(N'2021-11-22T15:42:43.2577606' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2445, 15, 133, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2625782' AS DateTime2), CAST(N'2021-11-22T15:42:43.2625782' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2446, 15, 134, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.2673934' AS DateTime2), CAST(N'2021-11-22T15:42:43.2673934' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2447, 15, 135, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2722557' AS DateTime2), CAST(N'2021-11-22T15:42:43.2722557' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2448, 15, 137, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.2771434' AS DateTime2), CAST(N'2021-11-22T15:42:43.2771434' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2449, 15, 138, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.2808588' AS DateTime2), CAST(N'2021-11-22T15:42:43.2808588' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2450, 15, 145, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.2857387' AS DateTime2), CAST(N'2021-11-22T15:42:43.2857387' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2451, 15, 147, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.2906154' AS DateTime2), CAST(N'2021-11-22T15:42:43.2906154' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2452, 15, 148, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.2955978' AS DateTime2), CAST(N'2021-11-22T15:42:43.2955978' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2453, 15, 151, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.3015357' AS DateTime2), CAST(N'2021-11-22T15:42:43.3015357' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2454, 15, 152, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.3052883' AS DateTime2), CAST(N'2021-11-22T15:42:43.3052883' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2455, 15, 153, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3105485' AS DateTime2), CAST(N'2021-11-22T15:42:43.3105485' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2456, 15, 154, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3163378' AS DateTime2), CAST(N'2021-11-22T15:42:43.3163378' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2457, 15, 155, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3200671' AS DateTime2), CAST(N'2021-11-22T15:42:43.3200671' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2458, 15, 156, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3298623' AS DateTime2), CAST(N'2021-11-22T15:42:43.3298623' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2459, 15, 157, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.3396145' AS DateTime2), CAST(N'2021-11-22T15:42:43.3396145' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2460, 15, 158, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3476231' AS DateTime2), CAST(N'2021-11-22T15:42:43.3476231' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2461, 15, 159, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.3513901' AS DateTime2), CAST(N'2021-11-22T15:42:43.3513901' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2462, 15, 160, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3562335' AS DateTime2), CAST(N'2021-11-22T15:42:43.3562335' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2463, 15, 161, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3610705' AS DateTime2), CAST(N'2021-11-22T15:42:43.3610705' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2464, 15, 162, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3649091' AS DateTime2), CAST(N'2021-11-22T15:42:43.3649091' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2465, 15, 163, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3697459' AS DateTime2), CAST(N'2021-11-22T15:42:43.3697459' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2466, 15, 164, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3747048' AS DateTime2), CAST(N'2021-11-22T15:42:43.3747048' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2467, 15, 165, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3806615' AS DateTime2), CAST(N'2021-11-22T15:42:43.3806615' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2468, 15, 166, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3853858' AS DateTime2), CAST(N'2021-11-22T15:42:43.3853858' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2469, 15, 180, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3912789' AS DateTime2), CAST(N'2021-11-22T15:42:43.3912789' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2470, 15, 181, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.3972231' AS DateTime2), CAST(N'2021-11-22T15:42:43.3972231' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2471, 15, 182, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4030452' AS DateTime2), CAST(N'2021-11-22T15:42:43.4030452' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2472, 15, 183, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4078667' AS DateTime2), CAST(N'2021-11-22T15:42:43.4078667' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2473, 15, 184, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4126911' AS DateTime2), CAST(N'2021-11-22T15:42:43.4126911' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2474, 15, 185, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4168444' AS DateTime2), CAST(N'2021-11-22T15:42:43.4168444' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2475, 15, 186, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4226118' AS DateTime2), CAST(N'2021-11-22T15:42:43.4226118' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2476, 15, 187, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4275527' AS DateTime2), CAST(N'2021-11-22T15:42:43.4275527' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2477, 15, 188, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4323434' AS DateTime2), CAST(N'2021-11-22T15:42:43.4323434' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2478, 15, 192, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4371143' AS DateTime2), CAST(N'2021-11-22T15:42:43.4371143' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2479, 15, 193, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.4429567' AS DateTime2), CAST(N'2021-11-22T15:42:43.4429567' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2480, 15, 194, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4481384' AS DateTime2), CAST(N'2021-11-22T15:42:43.4481384' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2481, 15, 195, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4539200' AS DateTime2), CAST(N'2021-11-22T15:42:43.4539200' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2482, 15, 196, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4598200' AS DateTime2), CAST(N'2021-11-22T15:42:43.4598200' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2483, 15, 197, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4647014' AS DateTime2), CAST(N'2021-11-22T15:42:43.4647014' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2484, 15, 198, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4705139' AS DateTime2), CAST(N'2021-11-22T15:42:43.4705139' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2485, 15, 199, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4773929' AS DateTime2), CAST(N'2021-11-22T15:42:43.4773929' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2486, 15, 200, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4832800' AS DateTime2), CAST(N'2021-11-22T15:42:43.4832800' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2487, 15, 201, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4890963' AS DateTime2), CAST(N'2021-11-22T15:42:43.4890963' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2488, 15, 202, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4939141' AS DateTime2), CAST(N'2021-11-22T15:42:43.4939141' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2489, 15, 203, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.4988059' AS DateTime2), CAST(N'2021-11-22T15:42:43.4988059' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2490, 15, 204, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.5036169' AS DateTime2), CAST(N'2021-11-22T15:42:43.5036169' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2491, 15, 205, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.5096429' AS DateTime2), CAST(N'2021-11-22T15:42:43.5096429' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2492, 15, 206, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.5145609' AS DateTime2), CAST(N'2021-11-22T15:42:43.5145609' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2493, 15, 207, N'', 0, 0, 0, 0, 0, 0, CAST(N'2021-11-22T15:42:43.5194394' AS DateTime2), CAST(N'2021-11-22T15:42:43.5194394' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2494, 15, 209, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.5242881' AS DateTime2), CAST(N'2021-11-22T15:42:43.5242881' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2495, 15, 210, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.5291860' AS DateTime2), CAST(N'2021-11-22T15:42:43.5291860' AS DateTime2), NULL, NULL, 1)
GO
INSERT [dbo].[groupObject] ([id], [groupId], [objectId], [notes], [addOb], [updateOb], [deleteOb], [showOb], [reportOb], [levelOb], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2496, 15, 212, N'', 2, 2, 2, 0, 2, 0, CAST(N'2021-11-22T15:42:43.5351398' AS DateTime2), CAST(N'2021-11-22T15:42:43.5351398' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[groupObject] OFF
GO
SET IDENTITY_INSERT [dbo].[groups] ON 

INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (10, N'Management', N'', CAST(N'2021-11-18T18:54:14.8061474' AS DateTime2), CAST(N'2021-11-18T18:54:14.8061474' AS DateTime2), 2, 2, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (11, N'Purchase/sale', N'', CAST(N'2021-11-20T13:44:07.4592974' AS DateTime2), CAST(N'2021-11-20T13:44:07.4592974' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (12, N'storage', N'', CAST(N'2021-11-20T13:54:57.8851425' AS DateTime2), CAST(N'2021-11-20T14:12:54.9483755' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (13, N'accounts', N'', CAST(N'2021-11-20T13:56:35.3006277' AS DateTime2), CAST(N'2021-11-20T14:13:05.0728651' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (14, N'tes1', N'', CAST(N'2021-11-22T14:14:22.9850170' AS DateTime2), CAST(N'2021-11-22T14:14:22.9850170' AS DateTime2), 9, 9, 1)
INSERT [dbo].[groups] ([groupId], [name], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (15, N'test2', N'', CAST(N'2021-11-22T15:42:42.6521676' AS DateTime2), CAST(N'2021-11-22T15:42:42.6521676' AS DateTime2), 9, 9, 1)
SET IDENTITY_INSERT [dbo].[groups] OFF
GO
SET IDENTITY_INSERT [dbo].[invoiceOrder] ON 

INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1040, 1189, 1189, 2, 1421)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1041, 1189, 1189, 3, 1422)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1042, 1189, 1189, 1, 1423)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1043, 1189, 1189, 1, 1424)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1044, 1189, 1189, 1, 1425)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1045, 1190, 1190, 2, 1426)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1046, 1190, 1190, 3, 1427)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1047, 1190, 1190, 1, 1428)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1048, 1190, 1190, 1, 1429)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1049, 1190, 1190, 1, 1430)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1050, 1191, 1191, 2, 1431)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1051, 1191, 1191, 3, 1432)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1052, 1191, 1191, 1, 1433)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1053, 1191, 1191, 1, 1434)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1054, 1191, 1191, 1, 1435)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1055, 1192, 1192, 2, 1436)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1056, 1192, 1192, 3, 1437)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1057, 1192, 1192, 1, 1438)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1058, 1192, 1192, 1, 1439)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1059, 1192, 1192, 1, 1440)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1060, 1193, 1193, 2, 1441)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1061, 1193, 1193, 3, 1442)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1062, 1193, 1193, 1, 1443)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1063, 1193, 1193, 1, 1444)
INSERT [dbo].[invoiceOrder] ([id], [invoiceId], [orderId], [quantity], [itemsTransferId]) VALUES (1064, 1193, 1193, 1, 1445)
SET IDENTITY_INSERT [dbo].[invoiceOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[invoices] ON 

INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1179, N'pi-Al-JM-B-000001', 2, 2, N'p', N'-1', NULL, CAST(5000.000 AS Decimal(20, 3)), CAST(5000.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), CAST(5000.000 AS Decimal(20, 3)), CAST(N'2021-11-30' AS Date), CAST(N'2021-11-30T19:03:40.3525606' AS DateTime2), CAST(N'2021-11-30T19:03:40.3525606' AS DateTime2), 2, NULL, NULL, CAST(N'19:03:40.3525606' AS Time), N'', N'55555', NULL, 2, 1, CAST(0.000 AS Decimal(20, 3)), 2, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), NULL, 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1180, N'pi-Al-JM-B-000002', 7, 2, N'p', N'1', CAST(250.000 AS Decimal(20, 3)), CAST(8250.000 AS Decimal(20, 3)), CAST(8000.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), CAST(8000.000 AS Decimal(20, 3)), CAST(N'2021-11-30' AS Date), CAST(N'2021-11-30T19:04:52.5401829' AS DateTime2), CAST(N'2021-11-30T19:04:52.5401829' AS DateTime2), 2, NULL, NULL, CAST(N'19:04:52.5401829' AS Time), N'', N'000', NULL, 2, 1, CAST(0.000 AS Decimal(20, 3)), 2, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), NULL, 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1181, N'pi-Al-JM-B-000003', 8, 2, N'p', N'-1', NULL, CAST(12000.000 AS Decimal(20, 3)), CAST(12000.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), CAST(12000.000 AS Decimal(20, 3)), CAST(N'2021-11-30' AS Date), CAST(N'2021-11-30T19:05:45.1653455' AS DateTime2), CAST(N'2021-11-30T19:05:45.1653455' AS DateTime2), 2, NULL, NULL, CAST(N'19:05:45.1653455' AS Time), N'', N'2', NULL, 2, 1, CAST(0.000 AS Decimal(20, 3)), 2, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), NULL, 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1182, N'si-Al-JM-B-000001', NULL, 2, N's', N'1', CAST(0.000 AS Decimal(20, 3)), CAST(1200.000 AS Decimal(20, 3)), CAST(1200.000 AS Decimal(20, 3)), CAST(1200.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-11-30T19:09:31.3373919' AS DateTime2), CAST(N'2021-11-30T19:09:38.5874983' AS DateTime2), 2, NULL, NULL, CAST(N'19:09:31.3373919' AS Time), N'', NULL, NULL, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), N'-1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1183, N'si-Al-JM-B-000002', NULL, 2, N's', N'1', CAST(0.000 AS Decimal(20, 3)), CAST(1200.000 AS Decimal(20, 3)), CAST(1000.000 AS Decimal(20, 3)), CAST(1000.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-11-30T19:18:56.8788341' AS DateTime2), CAST(N'2021-11-30T19:19:02.8634555' AS DateTime2), 2, NULL, NULL, CAST(N'19:18:56.8788341' AS Time), N'', NULL, NULL, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(200.000 AS Decimal(20, 3)), N'1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1184, N'si-Al-JM-B-000003', NULL, 3, N's', N'1', CAST(0.000 AS Decimal(20, 3)), CAST(1200.000 AS Decimal(20, 3)), CAST(1200.000 AS Decimal(20, 3)), CAST(1200.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-12-01T14:02:25.6921432' AS DateTime2), CAST(N'2021-12-01T14:02:34.5810230' AS DateTime2), 3, NULL, NULL, CAST(N'14:02:25.6921432' AS Time), N'', NULL, NULL, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), N'-1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1185, N'si-Al-JM-B-000004', NULL, 3, N's', N'1', CAST(0.000 AS Decimal(20, 3)), CAST(3600.000 AS Decimal(20, 3)), CAST(3600.000 AS Decimal(20, 3)), CAST(3600.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-12-01T14:07:43.6013584' AS DateTime2), CAST(N'2021-12-01T14:07:51.8208408' AS DateTime2), 3, NULL, NULL, CAST(N'14:07:43.6013584' AS Time), N'', NULL, NULL, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), N'-1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1186, N'si-Al-JM-B-000005', NULL, 8, N's', N'1', CAST(10.000 AS Decimal(20, 3)), CAST(2400.000 AS Decimal(20, 3)), CAST(2390.000 AS Decimal(20, 3)), CAST(2390.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-12-01T14:32:46.8343937' AS DateTime2), CAST(N'2021-12-01T14:34:10.1297617' AS DateTime2), 8, NULL, NULL, CAST(N'14:32:46.8343937' AS Time), N'', NULL, NULL, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), N'-1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 4, 0)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1187, N'si-Al-JM-B-000006', NULL, 8, N's', N'1', CAST(0.000 AS Decimal(20, 3)), CAST(2400.000 AS Decimal(20, 3)), CAST(2300.000 AS Decimal(20, 3)), CAST(2300.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-12-01T14:34:43.8252379' AS DateTime2), CAST(N'2021-12-01T14:34:50.9409374' AS DateTime2), 8, NULL, NULL, CAST(N'14:34:43.8252379' AS Time), N'', NULL, NULL, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(100.000 AS Decimal(20, 3)), N'1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 5, 0)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1188, N'si-Al-JM-B-000007', NULL, 8, N's', N'1', CAST(10.000 AS Decimal(20, 3)), CAST(2400.000 AS Decimal(20, 3)), CAST(2290.000 AS Decimal(20, 3)), CAST(2290.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-12-01T15:19:40.2238460' AS DateTime2), CAST(N'2021-12-01T15:19:47.0602735' AS DateTime2), 8, NULL, NULL, CAST(N'15:19:40.2238460' AS Time), N'', NULL, NULL, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(100.000 AS Decimal(20, 3)), N'1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 5, 0)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1189, N'ord-Al-JM-B-000001', NULL, 8, N'ord', N'1', CAST(0.000 AS Decimal(20, 3)), CAST(1805700.000 AS Decimal(20, 3)), CAST(1805000.000 AS Decimal(20, 3)), NULL, NULL, NULL, CAST(N'2021-12-01T15:21:28.2476371' AS DateTime2), CAST(N'2021-12-01T15:21:28.2476371' AS DateTime2), 8, NULL, NULL, CAST(N'15:21:28.2476371' AS Time), N'', NULL, NULL, NULL, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(700.000 AS Decimal(20, 3)), N'1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1190, N'ord-Al-JM-B-000001', NULL, 8, N'ord', N'1', CAST(0.000 AS Decimal(20, 3)), CAST(1805700.000 AS Decimal(20, 3)), CAST(1805000.000 AS Decimal(20, 3)), NULL, NULL, NULL, CAST(N'2021-12-01T15:21:35.5568793' AS DateTime2), CAST(N'2021-12-01T15:21:35.5568793' AS DateTime2), 8, NULL, NULL, CAST(N'15:21:35.5568793' AS Time), N'', NULL, NULL, NULL, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(700.000 AS Decimal(20, 3)), N'1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1191, N'ord-Al-JM-B-000001', NULL, 8, N'ord', N'1', CAST(0.000 AS Decimal(20, 3)), CAST(1805700.000 AS Decimal(20, 3)), CAST(1805700.000 AS Decimal(20, 3)), NULL, NULL, NULL, CAST(N'2021-12-01T15:22:46.4631005' AS DateTime2), CAST(N'2021-12-01T15:22:46.4631005' AS DateTime2), 8, NULL, NULL, CAST(N'15:22:46.4631005' AS Time), N'', NULL, NULL, NULL, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(700.000 AS Decimal(20, 3)), N'-1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1192, N'ord-Al-JM-B-000001', NULL, 8, N'ord', N'1', CAST(0.000 AS Decimal(20, 3)), CAST(1805700.000 AS Decimal(20, 3)), CAST(1805700.000 AS Decimal(20, 3)), NULL, NULL, NULL, CAST(N'2021-12-01T15:23:45.5589845' AS DateTime2), CAST(N'2021-12-01T15:23:45.5589845' AS DateTime2), 8, NULL, NULL, CAST(N'15:23:45.5589845' AS Time), N'', NULL, NULL, NULL, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(700.000 AS Decimal(20, 3)), N'-1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1193, N'ord-Al-JM-B-000001', NULL, 8, N'ord', N'1', CAST(0.000 AS Decimal(20, 3)), CAST(1805700.000 AS Decimal(20, 3)), CAST(1805700.000 AS Decimal(20, 3)), NULL, NULL, NULL, CAST(N'2021-12-01T15:23:49.6342435' AS DateTime2), CAST(N'2021-12-01T15:23:49.6342435' AS DateTime2), 8, NULL, NULL, CAST(N'15:23:49.6342435' AS Time), N'', NULL, NULL, NULL, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(700.000 AS Decimal(20, 3)), N'-1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1194, N'pi-Al-JM-B-000004', 2, 8, N'p', N'-1', CAST(0.000 AS Decimal(20, 3)), CAST(212000.000 AS Decimal(20, 3)), CAST(212000.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), CAST(212000.000 AS Decimal(20, 3)), CAST(N'2021-12-31' AS Date), CAST(N'2021-12-01T18:23:43.6719064' AS DateTime2), CAST(N'2021-12-01T18:28:28.9302247' AS DateTime2), 8, NULL, NULL, CAST(N'18:23:43.6719064' AS Time), N'', N'22555', CAST(N'2021-12-01T00:00:00.0000000' AS DateTime2), 2, 1, CAST(0.000 AS Decimal(20, 3)), 2, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), NULL, 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1195, N'si-Al-JM-B-000008', 11, 8, N's', N'1', CAST(0.000 AS Decimal(20, 3)), CAST(302400.000 AS Decimal(20, 3)), CAST(302000.000 AS Decimal(20, 3)), CAST(302000.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-12-01T18:31:02.8137274' AS DateTime2), CAST(N'2021-12-01T18:31:09.1951794' AS DateTime2), 8, NULL, NULL, CAST(N'18:31:02.8137274' AS Time), N'', NULL, NULL, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(400.000 AS Decimal(20, 3)), N'1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1196, N'si-Al-JM-B-000009', NULL, 8, N's', N'1', CAST(0.000 AS Decimal(20, 3)), CAST(1100.000 AS Decimal(20, 3)), CAST(1100.000 AS Decimal(20, 3)), CAST(1100.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-12-01T18:35:00.8824369' AS DateTime2), CAST(N'2021-12-01T18:35:06.7041752' AS DateTime2), 8, NULL, NULL, CAST(N'18:35:00.8824369' AS Time), N'', NULL, NULL, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), N'-1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1197, N'sd-Al-JM-B-000001', NULL, 8, N'sd', N'1', CAST(0.000 AS Decimal(20, 3)), CAST(1200.000 AS Decimal(20, 3)), CAST(1200.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), CAST(1200.000 AS Decimal(20, 3)), NULL, CAST(N'2021-12-02T19:10:29.6804875' AS DateTime2), CAST(N'2021-12-02T19:11:35.6807355' AS DateTime2), 8, NULL, NULL, CAST(N'19:10:29.6804875' AS Time), N'', NULL, NULL, NULL, 1, CAST(0.000 AS Decimal(20, 3)), NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), N'-1', 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[invoices] ([invoiceId], [invNumber], [agentId], [createUserId], [invType], [discountType], [discountValue], [total], [totalNet], [paid], [deserved], [deservedDate], [invDate], [updateDate], [updateUserId], [invoiceMainId], [invCase], [invTime], [notes], [vendorInvNum], [vendorInvDate], [branchId], [posId], [tax], [taxtype], [name], [isApproved], [shippingCompanyId], [branchCreatorId], [shipUserId], [prevStatus], [userId], [manualDiscountValue], [manualDiscountType], [isActive], [invoiceProfit], [cashReturn], [printedcount], [isOrginal]) VALUES (1198, N'pi-Al-JM-B-000005', NULL, 3, N'p', N'-1', NULL, CAST(1250.000 AS Decimal(20, 3)), CAST(1250.000 AS Decimal(20, 3)), CAST(1250.000 AS Decimal(20, 3)), CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-12-06T13:22:42.6636655' AS DateTime2), CAST(N'2021-12-06T13:22:48.7264215' AS DateTime2), 3, NULL, NULL, CAST(N'13:22:42.6636655' AS Time), N'', N'159', CAST(N'2021-12-28T00:00:00.0000000' AS DateTime2), 2, 1, CAST(0.000 AS Decimal(20, 3)), 2, NULL, NULL, NULL, 2, NULL, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), NULL, 1, NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
SET IDENTITY_INSERT [dbo].[invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[invoiceStatus] ON 

INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1206, 1182, N'pr', CAST(N'2021-11-30T19:09:34.6183331' AS DateTime2), CAST(N'2021-11-30T19:09:34.6183331' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1207, 1182, N'ex', CAST(N'2021-11-30T19:09:35.1184634' AS DateTime2), CAST(N'2021-11-30T19:09:35.1184634' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1208, 1182, N'rc', CAST(N'2021-11-30T19:09:35.6811305' AS DateTime2), CAST(N'2021-11-30T19:09:35.6811305' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1209, 1183, N'pr', CAST(N'2021-11-30T19:19:00.0289363' AS DateTime2), CAST(N'2021-11-30T19:19:00.0289363' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1210, 1183, N'ex', CAST(N'2021-11-30T19:19:00.4881807' AS DateTime2), CAST(N'2021-11-30T19:19:00.4881807' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1211, 1183, N'rc', CAST(N'2021-11-30T19:19:00.9621839' AS DateTime2), CAST(N'2021-11-30T19:19:00.9621839' AS DateTime2), 2, 2, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1212, 1184, N'pr', CAST(N'2021-12-01T14:02:30.6720614' AS DateTime2), CAST(N'2021-12-01T14:02:30.6720614' AS DateTime2), 3, 3, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1213, 1184, N'ex', CAST(N'2021-12-01T14:02:31.4035793' AS DateTime2), CAST(N'2021-12-01T14:02:31.4035793' AS DateTime2), 3, 3, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1214, 1184, N'rc', CAST(N'2021-12-01T14:02:32.1409697' AS DateTime2), CAST(N'2021-12-01T14:02:32.1409697' AS DateTime2), 3, 3, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1215, 1185, N'pr', CAST(N'2021-12-01T14:07:48.2103581' AS DateTime2), CAST(N'2021-12-01T14:07:48.2103581' AS DateTime2), 3, 3, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1216, 1185, N'ex', CAST(N'2021-12-01T14:07:48.6930024' AS DateTime2), CAST(N'2021-12-01T14:07:48.6930024' AS DateTime2), 3, 3, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1217, 1185, N'rc', CAST(N'2021-12-01T14:07:49.1969890' AS DateTime2), CAST(N'2021-12-01T14:07:49.1969890' AS DateTime2), 3, 3, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1218, 1186, N'pr', CAST(N'2021-12-01T14:34:06.9567895' AS DateTime2), CAST(N'2021-12-01T14:34:06.9567895' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1219, 1186, N'ex', CAST(N'2021-12-01T14:34:07.4675800' AS DateTime2), CAST(N'2021-12-01T14:34:07.4675800' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1220, 1186, N'rc', CAST(N'2021-12-01T14:34:07.9793161' AS DateTime2), CAST(N'2021-12-01T14:34:07.9793161' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1221, 1187, N'pr', CAST(N'2021-12-01T14:34:48.1697878' AS DateTime2), CAST(N'2021-12-01T14:34:48.1697878' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1222, 1187, N'ex', CAST(N'2021-12-01T14:34:48.5866098' AS DateTime2), CAST(N'2021-12-01T14:34:48.5866098' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1223, 1187, N'rc', CAST(N'2021-12-01T14:34:49.0670311' AS DateTime2), CAST(N'2021-12-01T14:34:49.0670311' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1224, 1188, N'pr', CAST(N'2021-12-01T15:19:44.2038725' AS DateTime2), CAST(N'2021-12-01T15:19:44.2038725' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1225, 1188, N'ex', CAST(N'2021-12-01T15:19:44.6861961' AS DateTime2), CAST(N'2021-12-01T15:19:44.6861961' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1226, 1188, N'rc', CAST(N'2021-12-01T15:19:45.1209820' AS DateTime2), CAST(N'2021-12-01T15:19:45.1209820' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1227, 1195, N'pr', CAST(N'2021-12-01T18:31:06.4300457' AS DateTime2), CAST(N'2021-12-01T18:31:06.4300457' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1228, 1195, N'ex', CAST(N'2021-12-01T18:31:06.8802764' AS DateTime2), CAST(N'2021-12-01T18:31:06.8802764' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1229, 1195, N'rc', CAST(N'2021-12-01T18:31:07.3147219' AS DateTime2), CAST(N'2021-12-01T18:31:07.3147219' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1230, 1196, N'pr', CAST(N'2021-12-01T18:35:03.7222265' AS DateTime2), CAST(N'2021-12-01T18:35:03.7222265' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1231, 1196, N'ex', CAST(N'2021-12-01T18:35:04.1665140' AS DateTime2), CAST(N'2021-12-01T18:35:04.1665140' AS DateTime2), 8, 8, NULL, 1)
INSERT [dbo].[invoiceStatus] ([invStatusId], [invoiceId], [status], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [isActive]) VALUES (1232, 1196, N'rc', CAST(N'2021-12-01T18:35:04.6038633' AS DateTime2), CAST(N'2021-12-01T18:35:04.6038633' AS DateTime2), 8, 8, NULL, 1)
SET IDENTITY_INSERT [dbo].[invoiceStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[items] ON 

INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (1, N'M-AS', N'الأسبرين ', N'', N'n', N'57440ff6b80f068efd50410ea24fd593.jpg', CAST(0.000 AS Decimal(20, 3)), 1, 1, 100, 11, NULL, CAST(N'2021-10-27T17:55:59.6465002' AS DateTime2), CAST(N'2021-10-27T17:55:59.6465002' AS DateTime2), 2, 2, 3, 3, CAST(561.111 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (2, N'M-BR', N'بروفين ', N'', N'n', N'c37858823db0093766eee74d8ee1f1e5.png', CAST(0.000 AS Decimal(20, 3)), 1, 1, 100, 11, NULL, CAST(N'2021-10-27T17:56:33.1262847' AS DateTime2), CAST(N'2021-10-27T17:57:08.8468880' AS DateTime2), 2, 2, 3, 3, CAST(3625.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (3, N'M-bS', N'باراسيتامول ', N'hhjjjkkkkkk', N'd', N'71f020248a405d21e94d1de52043bed4.png', CAST(0.000 AS Decimal(20, 3)), 1, 1, 100, 11, NULL, CAST(N'2021-10-27T17:56:57.7487007' AS DateTime2), CAST(N'2021-11-29T14:46:30.0935606' AS DateTime2), 2, 1, 3, 3, CAST(6000.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (5, N'IPH-11', N'Iphone 11', N'', N'sn', N'f96f8a89e2143f1e43a2ba7953fb5413.png', CAST(0.000 AS Decimal(20, 3)), 1, 1, 25, 4, NULL, CAST(N'2021-10-27T17:58:38.6198621' AS DateTime2), CAST(N'2021-10-30T16:41:34.8871773' AS DateTime2), 2, 9, 2, 2, CAST(257500.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (6, N'BS', N'barcode scanner', N'', N'n', N'', CAST(0.000 AS Decimal(20, 3)), 1, 1, 100, 1, NULL, CAST(N'2021-10-31T17:52:01.9799200' AS DateTime2), CAST(N'2021-10-31T17:55:53.3260636' AS DateTime2), 9, 9, 2, 2, CAST(500.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (7, N'BP', N'barcode printer', N'', N'n', N'', CAST(0.000 AS Decimal(20, 3)), 1, 1, 100, 1, NULL, CAST(N'2021-10-31T17:52:23.5742109' AS DateTime2), CAST(N'2021-10-31T17:56:02.2323409' AS DateTime2), 9, 9, 2, 2, CAST(200000.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (8, N'CDR', N'Cash Drawer', N'', N'n', N'', CAST(0.000 AS Decimal(20, 3)), 1, 1, 100, 1, NULL, CAST(N'2021-10-31T17:56:19.7326005' AS DateTime2), CAST(N'2021-10-31T17:56:19.7326005' AS DateTime2), 9, 9, 2, 2, CAST(500.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (9, N'PP2', N'POZONE-POS2', N'', N'n', N'', CAST(0.000 AS Decimal(20, 3)), 1, 1, 100, 1, NULL, CAST(N'2021-10-31T17:56:29.0762400' AS DateTime2), CAST(N'2021-10-31T17:56:29.0762400' AS DateTime2), 9, 9, 2, 2, CAST(500.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (10, N't820', N'POZONE-t820-POS', N'', N'n', N'', CAST(0.000 AS Decimal(20, 3)), 1, 1, 100, 1, NULL, CAST(N'2021-10-31T17:56:43.0609452' AS DateTime2), CAST(N'2021-10-31T17:56:43.0609452' AS DateTime2), 9, 9, 2, 2, CAST(500.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (11, N't835', N'POZONE-t835-POS', N'', N'n', N'', CAST(0.000 AS Decimal(20, 3)), 1, 1, 100, 1, NULL, CAST(N'2021-10-31T17:56:54.2954335' AS DateTime2), CAST(N'2021-10-31T17:56:54.2954335' AS DateTime2), 9, 9, 2, 2, CAST(200000.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (12, N'TR', N'Thermal-rolls', N'', N'n', N'', CAST(0.000 AS Decimal(20, 3)), 1, 1, 100, 1, NULL, CAST(N'2021-10-31T17:57:05.8735957' AS DateTime2), CAST(N'2021-10-31T17:57:05.8735957' AS DateTime2), 9, 9, 2, 2, CAST(200000.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (13, N'LCP', N'laundry-casheir-program', N'', N'n', N'', CAST(0.000 AS Decimal(20, 3)), 1, 1, 100, 1, NULL, CAST(N'2021-10-31T17:57:17.2327877' AS DateTime2), CAST(N'2021-10-31T17:57:17.2327877' AS DateTime2), 9, 9, 2, 2, CAST(200000.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (19, N'TT1', N'Package 1', N'', N'p', N'', CAST(0.000 AS Decimal(20, 3)), 1, 0, 0, 11, NULL, CAST(N'2021-11-04T15:22:50.2192089' AS DateTime2), CAST(N'2021-11-04T15:54:22.8706460' AS DateTime2), 9, 9, 1, 1, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (20, N'co', N'new item', N'details', N'n', N'', CAST(0.000 AS Decimal(20, 3)), 1, 10, 20, 2, NULL, CAST(N'2021-11-11T14:42:33.7946963' AS DateTime2), CAST(N'2021-11-11T15:05:01.9471586' AS DateTime2), 3, 9, 1, 1, CAST(225000.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (21, N'test', N'expire date', N'details', N'd', N'90f607ba318fce94cafe1571617d1b6c.jpeg', CAST(0.000 AS Decimal(20, 3)), 1, 10, 20, 11, NULL, CAST(N'2021-11-11T15:05:48.5934499' AS DateTime2), CAST(N'2021-11-22T14:10:09.6418581' AS DateTime2), 9, 9, 2, 2, CAST(215000.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (22, N'tttt', N'saddsadasd', N'', N'n', N'77d0501bbf02ad459f88ab4b7531b14d.jpg', CAST(0.000 AS Decimal(20, 3)), 1, 1, 1, 1, NULL, CAST(N'2021-11-11T17:01:11.1018238' AS DateTime2), CAST(N'2021-11-22T14:10:29.3205625' AS DateTime2), 9, 9, 2, 2, CAST(250000.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (23, N'w22', N'2e', N'', N'n', N'e8a124154d6b4436a9d47827fcd24d4d.jpeg', CAST(0.000 AS Decimal(20, 3)), 1, 1, 1, 1, NULL, CAST(N'2021-11-11T17:08:56.9978043' AS DateTime2), CAST(N'2021-11-22T14:09:34.9014866' AS DateTime2), 9, 9, 2, 2, CAST(500.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (24, N'ASDw22', N'DSAD2e', N'', N'n', N'3f85263e6e6e21f6a4057fab7f956f1b.jpg', CAST(0.000 AS Decimal(20, 3)), 1, 1, 1, 1, NULL, CAST(N'2021-11-11T17:13:03.3162407' AS DateTime2), CAST(N'2021-11-22T15:01:23.5070230' AS DateTime2), 9, 9, 2, 2, CAST(210000.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (25, N'12', N'new pack', N'', N'p', N'', CAST(0.000 AS Decimal(20, 3)), 1, 0, 0, 1, NULL, CAST(N'2021-11-14T15:34:04.3357867' AS DateTime2), CAST(N'2021-11-14T15:34:25.5151422' AS DateTime2), 8, 8, 1, 1, NULL)
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (26, N'ttt', N'tes1 service', N'78', N'sr', N'37de6228ecdaf854ca17e0abd1062763.jpg', CAST(0.000 AS Decimal(20, 3)), 0, 0, 0, 1, NULL, CAST(N'2021-11-16T15:33:36.0546799' AS DateTime2), CAST(N'2021-11-16T16:02:01.6667905' AS DateTime2), 2, 2, 1, 1, CAST(500.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (27, N'tt2', N'test2 sr', N'asd', N'sr', N'15c139cdb9cb2a3e6788751f02626b1e.jpg', CAST(0.000 AS Decimal(20, 3)), 1, 0, 0, 1, NULL, CAST(N'2021-11-16T15:37:44.6878609' AS DateTime2), CAST(N'2021-11-16T16:10:25.8317274' AS DateTime2), 2, 2, 1, 1, CAST(700.000 AS Decimal(20, 3)))
INSERT [dbo].[items] ([itemId], [code], [name], [details], [type], [image], [taxes], [isActive], [min], [max], [categoryId], [parentId], [createDate], [updateDate], [createUserId], [updateUserId], [minUnitId], [maxUnitId], [avgPurchasePrice]) VALUES (28, N'tt5', N'test5 sr', N'asd5', N'sr', N'b754f525b6f76b3c7201c0d029f5b267.jpg', CAST(0.000 AS Decimal(20, 3)), 1, 0, 0, 3, NULL, CAST(N'2021-11-16T15:38:43.1067310' AS DateTime2), CAST(N'2021-11-16T16:07:00.5377762' AS DateTime2), 2, 2, 1, 1, CAST(500.000 AS Decimal(20, 3)))
SET IDENTITY_INSERT [dbo].[items] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsLocations] ON 

INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note], [invoiceId]) VALUES (1101, 22, 43, CAST(N'2021-11-30T19:03:41.9934884' AS DateTime2), CAST(N'2021-11-30T19:05:46.3219508' AS DateTime2), 2, 2, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note], [invoiceId]) VALUES (1102, 22, 7, CAST(N'2021-11-30T19:09:32.4155512' AS DateTime2), CAST(N'2021-12-01T15:19:41.9255410' AS DateTime2), 2, 2, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note], [invoiceId]) VALUES (1103, 22, 1, CAST(N'2021-12-01T18:28:30.1804449' AS DateTime2), CAST(N'2021-12-06T13:22:44.3199200' AS DateTime2), 8, 3, NULL, NULL, 4, NULL, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note], [invoiceId]) VALUES (1104, 22, 0, CAST(N'2021-12-01T18:28:30.3993318' AS DateTime2), CAST(N'2021-12-01T18:28:30.3993318' AS DateTime2), 8, 8, NULL, NULL, 6, NULL, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note], [invoiceId]) VALUES (1105, 22, 0, CAST(N'2021-12-01T18:28:30.4330324' AS DateTime2), CAST(N'2021-12-01T18:31:04.1408844' AS DateTime2), 8, 8, NULL, NULL, 9, NULL, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note], [invoiceId]) VALUES (1106, 22, 9, CAST(N'2021-12-01T18:31:03.9086512' AS DateTime2), CAST(N'2021-12-01T18:31:03.9086512' AS DateTime2), 8, 8, NULL, NULL, 3, NULL, NULL)
INSERT [dbo].[itemsLocations] ([itemsLocId], [locationId], [quantity], [createDate], [updateDate], [createUserId], [updateUserId], [startDate], [endDate], [itemUnitId], [note], [invoiceId]) VALUES (1107, 22, 8, CAST(N'2021-12-01T18:31:04.0782043' AS DateTime2), CAST(N'2021-12-01T18:35:01.7778835' AS DateTime2), 8, 8, NULL, NULL, 5, NULL, NULL)
SET IDENTITY_INSERT [dbo].[itemsLocations] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsTransfer] ON 

INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1410, 10, 1179, NULL, NULL, CAST(N'2021-11-30T19:03:41.1496222' AS DateTime2), CAST(N'2021-11-30T19:03:41.1496222' AS DateTime2), 2, 2, NULL, CAST(500.000 AS Decimal(20, 3)), 2, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1411, 15, 1180, NULL, NULL, CAST(N'2021-11-30T19:04:53.0090691' AS DateTime2), CAST(N'2021-11-30T19:04:53.0090691' AS DateTime2), 2, 2, NULL, CAST(550.000 AS Decimal(20, 3)), 2, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1412, 20, 1181, NULL, NULL, CAST(N'2021-11-30T19:05:45.6496600' AS DateTime2), CAST(N'2021-11-30T19:05:45.6496600' AS DateTime2), 2, 2, NULL, CAST(600.000 AS Decimal(20, 3)), 2, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1413, 1, 1182, NULL, NULL, CAST(N'2021-11-30T19:09:31.8061820' AS DateTime2), CAST(N'2021-11-30T19:09:31.8061820' AS DateTime2), 2, 2, NULL, CAST(1200.000 AS Decimal(20, 3)), 1, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1414, 1, 1183, NULL, NULL, CAST(N'2021-11-30T19:18:57.4100284' AS DateTime2), CAST(N'2021-11-30T19:18:57.4100284' AS DateTime2), 2, 2, NULL, CAST(1200.000 AS Decimal(20, 3)), 1, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1415, 2, 1184, NULL, NULL, CAST(N'2021-12-01T14:02:26.7542441' AS DateTime2), CAST(N'2021-12-01T14:02:26.7542441' AS DateTime2), 3, 3, NULL, CAST(1200.000 AS Decimal(20, 3)), 1, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1416, 3, 1185, NULL, NULL, CAST(N'2021-12-01T14:07:44.6775068' AS DateTime2), CAST(N'2021-12-01T14:07:44.6775068' AS DateTime2), 3, 3, NULL, CAST(1200.000 AS Decimal(20, 3)), 1, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1418, 2, 1186, NULL, NULL, CAST(N'2021-12-01T14:34:03.3028660' AS DateTime2), CAST(N'2021-12-01T14:34:03.3028660' AS DateTime2), 8, 8, NULL, CAST(1200.000 AS Decimal(20, 3)), 1, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1419, 2, 1187, NULL, NULL, CAST(N'2021-12-01T14:34:44.3455510' AS DateTime2), CAST(N'2021-12-01T14:34:44.3455510' AS DateTime2), 8, 8, NULL, CAST(1200.000 AS Decimal(20, 3)), 1, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1420, 2, 1188, NULL, NULL, CAST(N'2021-12-01T15:19:41.1970157' AS DateTime2), CAST(N'2021-12-01T15:19:41.1970157' AS DateTime2), 8, 8, NULL, CAST(1200.000 AS Decimal(20, 3)), 1, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1421, 2, 1189, NULL, NULL, CAST(N'2021-12-01T15:21:29.5247233' AS DateTime2), CAST(N'2021-12-01T15:21:29.5247233' AS DateTime2), 8, 8, NULL, CAST(1200.000 AS Decimal(20, 3)), 1, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1422, 3, 1189, NULL, NULL, CAST(N'2021-12-01T15:21:29.5348988' AS DateTime2), CAST(N'2021-12-01T15:21:29.5348988' AS DateTime2), 8, 8, NULL, CAST(1100.000 AS Decimal(20, 3)), 5, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1423, 1, 1189, NULL, NULL, CAST(N'2021-12-01T15:21:29.5475001' AS DateTime2), CAST(N'2021-12-01T15:21:29.5475001' AS DateTime2), 8, 8, NULL, CAST(1200000.000 AS Decimal(20, 3)), 7, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1424, 1, 1189, NULL, NULL, CAST(N'2021-12-01T15:21:29.5512290' AS DateTime2), CAST(N'2021-12-01T15:21:29.5512290' AS DateTime2), 8, 8, NULL, CAST(300000.000 AS Decimal(20, 3)), 8, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1425, 1, 1189, NULL, NULL, CAST(N'2021-12-01T15:21:29.5554609' AS DateTime2), CAST(N'2021-12-01T15:21:29.5554609' AS DateTime2), 8, 8, NULL, CAST(300000.000 AS Decimal(20, 3)), 9, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1426, 2, 1190, NULL, NULL, CAST(N'2021-12-01T15:21:36.4916603' AS DateTime2), CAST(N'2021-12-01T15:21:36.4916603' AS DateTime2), 8, 8, NULL, CAST(1200.000 AS Decimal(20, 3)), 1, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1427, 3, 1190, NULL, NULL, CAST(N'2021-12-01T15:21:36.4953750' AS DateTime2), CAST(N'2021-12-01T15:21:36.4953750' AS DateTime2), 8, 8, NULL, CAST(1100.000 AS Decimal(20, 3)), 5, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1428, 1, 1190, NULL, NULL, CAST(N'2021-12-01T15:21:36.4991654' AS DateTime2), CAST(N'2021-12-01T15:21:36.4991654' AS DateTime2), 8, 8, NULL, CAST(1200000.000 AS Decimal(20, 3)), 7, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1429, 1, 1190, NULL, NULL, CAST(N'2021-12-01T15:21:36.5023289' AS DateTime2), CAST(N'2021-12-01T15:21:36.5023289' AS DateTime2), 8, 8, NULL, CAST(300000.000 AS Decimal(20, 3)), 8, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1430, 1, 1190, NULL, NULL, CAST(N'2021-12-01T15:21:36.5078861' AS DateTime2), CAST(N'2021-12-01T15:21:36.5078861' AS DateTime2), 8, 8, NULL, CAST(300000.000 AS Decimal(20, 3)), 9, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1431, 2, 1191, NULL, NULL, CAST(N'2021-12-01T15:22:47.4514185' AS DateTime2), CAST(N'2021-12-01T15:22:47.4514185' AS DateTime2), 8, 8, NULL, CAST(1200.000 AS Decimal(20, 3)), 1, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1432, 3, 1191, NULL, NULL, CAST(N'2021-12-01T15:22:47.4552196' AS DateTime2), CAST(N'2021-12-01T15:22:47.4552196' AS DateTime2), 8, 8, NULL, CAST(1100.000 AS Decimal(20, 3)), 5, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1433, 1, 1191, NULL, NULL, CAST(N'2021-12-01T15:22:47.4602527' AS DateTime2), CAST(N'2021-12-01T15:22:47.4602527' AS DateTime2), 8, 8, NULL, CAST(1200000.000 AS Decimal(20, 3)), 7, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1434, 1, 1191, NULL, NULL, CAST(N'2021-12-01T15:22:47.4657537' AS DateTime2), CAST(N'2021-12-01T15:22:47.4657537' AS DateTime2), 8, 8, NULL, CAST(300000.000 AS Decimal(20, 3)), 8, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1435, 1, 1191, NULL, NULL, CAST(N'2021-12-01T15:22:47.4700027' AS DateTime2), CAST(N'2021-12-01T15:22:47.4700027' AS DateTime2), 8, 8, NULL, CAST(300000.000 AS Decimal(20, 3)), 9, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1436, 2, 1192, NULL, NULL, CAST(N'2021-12-01T15:23:46.5775604' AS DateTime2), CAST(N'2021-12-01T15:23:46.5775604' AS DateTime2), 8, 8, NULL, CAST(1200.000 AS Decimal(20, 3)), 1, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1437, 3, 1192, NULL, NULL, CAST(N'2021-12-01T15:23:46.5813564' AS DateTime2), CAST(N'2021-12-01T15:23:46.5813564' AS DateTime2), 8, 8, NULL, CAST(1100.000 AS Decimal(20, 3)), 5, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1438, 1, 1192, NULL, NULL, CAST(N'2021-12-01T15:23:46.5856848' AS DateTime2), CAST(N'2021-12-01T15:23:46.5856848' AS DateTime2), 8, 8, NULL, CAST(1200000.000 AS Decimal(20, 3)), 7, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1439, 1, 1192, NULL, NULL, CAST(N'2021-12-01T15:23:46.5922152' AS DateTime2), CAST(N'2021-12-01T15:23:46.5922152' AS DateTime2), 8, 8, NULL, CAST(300000.000 AS Decimal(20, 3)), 8, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1440, 1, 1192, NULL, NULL, CAST(N'2021-12-01T15:23:46.5959708' AS DateTime2), CAST(N'2021-12-01T15:23:46.5959708' AS DateTime2), 8, 8, NULL, CAST(300000.000 AS Decimal(20, 3)), 9, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1441, 2, 1193, NULL, NULL, CAST(N'2021-12-01T15:23:50.5599739' AS DateTime2), CAST(N'2021-12-01T15:23:50.5599739' AS DateTime2), 8, 8, NULL, CAST(1200.000 AS Decimal(20, 3)), 1, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1442, 3, 1193, NULL, NULL, CAST(N'2021-12-01T15:23:50.5626799' AS DateTime2), CAST(N'2021-12-01T15:23:50.5626799' AS DateTime2), 8, 8, NULL, CAST(1100.000 AS Decimal(20, 3)), 5, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1443, 1, 1193, NULL, NULL, CAST(N'2021-12-01T15:23:50.5676577' AS DateTime2), CAST(N'2021-12-01T15:23:50.5676577' AS DateTime2), 8, 8, NULL, CAST(1200000.000 AS Decimal(20, 3)), 7, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1444, 1, 1193, NULL, NULL, CAST(N'2021-12-01T15:23:50.5713891' AS DateTime2), CAST(N'2021-12-01T15:23:50.5713891' AS DateTime2), 8, 8, NULL, CAST(300000.000 AS Decimal(20, 3)), 8, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1445, 1, 1193, NULL, NULL, CAST(N'2021-12-01T15:23:50.5753099' AS DateTime2), CAST(N'2021-12-01T15:23:50.5753099' AS DateTime2), 8, 8, NULL, CAST(300000.000 AS Decimal(20, 3)), 9, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1453, 1, 1194, NULL, NULL, CAST(N'2021-12-01T18:28:29.4403275' AS DateTime2), CAST(N'2021-12-01T18:28:29.4403275' AS DateTime2), 8, 8, NULL, CAST(6000.000 AS Decimal(20, 3)), 4, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1454, 1, 1194, NULL, NULL, CAST(N'2021-12-01T18:28:29.4441763' AS DateTime2), CAST(N'2021-12-01T18:28:29.4441763' AS DateTime2), 8, 8, NULL, CAST(6000.000 AS Decimal(20, 3)), 6, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1455, 1, 1194, NULL, NULL, CAST(N'2021-12-01T18:28:29.4480369' AS DateTime2), CAST(N'2021-12-01T18:28:29.4480369' AS DateTime2), 8, 8, NULL, CAST(200000.000 AS Decimal(20, 3)), 9, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1456, 1, 1195, NULL, NULL, CAST(N'2021-12-01T18:31:03.2677792' AS DateTime2), CAST(N'2021-12-01T18:31:03.2677792' AS DateTime2), 8, 8, NULL, CAST(1300.000 AS Decimal(20, 3)), 3, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1457, 1, 1195, NULL, NULL, CAST(N'2021-12-01T18:31:03.2715238' AS DateTime2), CAST(N'2021-12-01T18:31:03.2715238' AS DateTime2), 8, 8, NULL, CAST(1100.000 AS Decimal(20, 3)), 5, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1458, 1, 1195, NULL, NULL, CAST(N'2021-12-01T18:31:03.2736283' AS DateTime2), CAST(N'2021-12-01T18:31:03.2736283' AS DateTime2), 8, 8, NULL, CAST(300000.000 AS Decimal(20, 3)), 9, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1459, 1, 1196, NULL, NULL, CAST(N'2021-12-01T18:35:01.3384730' AS DateTime2), CAST(N'2021-12-01T18:35:01.3384730' AS DateTime2), 8, 8, NULL, CAST(1100.000 AS Decimal(20, 3)), 5, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1461, 1, 1197, NULL, NULL, CAST(N'2021-12-02T19:11:36.2430930' AS DateTime2), CAST(N'2021-12-02T19:11:36.2430930' AS DateTime2), 8, 8, NULL, CAST(1200.000 AS Decimal(20, 3)), 1, N'', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[itemsTransfer] ([itemsTransId], [quantity], [invoiceId], [locationIdNew], [locationIdOld], [createDate], [updateDate], [createUserId], [updateUserId], [notes], [price], [itemUnitId], [itemSerial], [inventoryItemLocId], [offerId], [profit], [purchasePrice], [cause]) VALUES (1462, 1, 1198, NULL, NULL, CAST(N'2021-12-06T13:22:43.5387186' AS DateTime2), CAST(N'2021-12-06T13:22:43.5387186' AS DateTime2), 3, 3, NULL, CAST(1250.000 AS Decimal(20, 3)), 4, N'', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[itemsTransfer] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsUnits] ON 

INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (1, 1, 2, 1, 1, 0, CAST(1200.000 AS Decimal(20, 3)), N'2079715524000', CAST(N'2021-10-28T15:21:06.7740065' AS DateTime2), CAST(N'2021-10-28T15:21:06.7740065' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (2, 1, 3, 10, 0, 1, CAST(10000.000 AS Decimal(20, 3)), N'2079715524000', CAST(N'2021-10-28T15:22:01.9995819' AS DateTime2), CAST(N'2021-10-28T15:22:01.9995819' AS DateTime2), 9, 9, 2, NULL, 2, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (3, 2, 2, 1, 1, 0, CAST(1300.000 AS Decimal(20, 3)), N'9079715537201', CAST(N'2021-10-28T15:23:30.0104139' AS DateTime2), CAST(N'2021-10-28T15:32:33.6451231' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (4, 2, 3, 10, 0, 1, CAST(10000.000 AS Decimal(20, 3)), N'3079715551203', CAST(N'2021-10-28T15:25:50.8230338' AS DateTime2), CAST(N'2021-10-28T15:25:50.8230338' AS DateTime2), 9, 9, 2, NULL, 2, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (5, 3, 2, 1, 1, 0, CAST(1100.000 AS Decimal(20, 3)), N'7079715573904', CAST(N'2021-10-28T15:29:57.8459036' AS DateTime2), CAST(N'2021-10-28T15:29:57.8459036' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (6, 3, 3, 10, 0, 1, CAST(10000.000 AS Decimal(20, 3)), N'1079715589505', CAST(N'2021-10-28T15:31:57.7965735' AS DateTime2), CAST(N'2021-11-02T15:11:04.3554075' AS DateTime2), 9, 9, 2, NULL, 2, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (7, 5, 2, 1, 1, 1, CAST(1200000.000 AS Decimal(20, 3)), N'4079715598306', CAST(N'2021-10-28T15:34:49.0237550' AS DateTime2), CAST(N'2021-10-28T15:34:49.0237550' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (8, 6, 2, 1, 1, 1, CAST(300000.000 AS Decimal(20, 3)), N'1079746105200', CAST(N'2021-10-31T17:57:50.3581515' AS DateTime2), CAST(N'2021-10-31T17:57:50.3581515' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (9, 7, 2, 1, 1, 1, CAST(300000.000 AS Decimal(20, 3)), N'1079746105200', CAST(N'2021-10-31T17:57:57.6081555' AS DateTime2), CAST(N'2021-10-31T17:57:57.6081555' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (10, 8, 2, 1, 1, 1, CAST(300000.000 AS Decimal(20, 3)), N'5079746109501', CAST(N'2021-10-31T17:58:27.0768931' AS DateTime2), CAST(N'2021-10-31T17:58:27.0768931' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (11, 9, 2, 1, 1, 1, CAST(250000.000 AS Decimal(20, 3)), N'1079746111102', CAST(N'2021-10-31T17:58:43.0300948' AS DateTime2), CAST(N'2021-10-31T17:58:43.0300948' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (12, 10, 2, 1, 1, 1, CAST(225000.000 AS Decimal(20, 3)), N'1079746112703', CAST(N'2021-10-31T17:59:03.0302907' AS DateTime2), CAST(N'2021-10-31T17:59:03.0302907' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (13, 11, 2, 1, 1, 1, CAST(1.000 AS Decimal(20, 3)), N'2079746114904', CAST(N'2021-10-31T17:59:19.3115139' AS DateTime2), CAST(N'2021-10-31T17:59:19.3115139' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (14, 12, 2, 1, 1, 1, CAST(200000.000 AS Decimal(20, 3)), N'1079746116305', CAST(N'2021-10-31T17:59:35.6869366' AS DateTime2), CAST(N'2021-10-31T17:59:35.6869366' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (15, 13, 2, 1, 1, 1, CAST(225000.000 AS Decimal(20, 3)), N'1079746117906', CAST(N'2021-10-31T17:59:54.0617662' AS DateTime2), CAST(N'2021-10-31T17:59:54.0617662' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (21, 19, 1, 1, 1, 1, CAST(3000.000 AS Decimal(20, 3)), N'079785172407', CAST(N'2021-11-04T15:22:50.8386639' AS DateTime2), CAST(N'2021-11-04T15:54:24.2137219' AS DateTime2), 9, 9, 1, NULL, NULL, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (22, 20, 2, 1, 1, 1, CAST(1200.000 AS Decimal(20, 3)), N'6079854951800', CAST(N'2021-11-11T14:45:47.0442166' AS DateTime2), CAST(N'2021-11-11T14:45:47.0442166' AS DateTime2), 3, 3, 2, NULL, 2, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (23, 21, 2, 1, 1, 1, CAST(500.000 AS Decimal(20, 3)), N'7079855080300', CAST(N'2021-11-11T15:06:58.3448346' AS DateTime2), CAST(N'2021-11-11T15:06:58.3448346' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (24, 22, 2, 1, 1, 1, CAST(5000.000 AS Decimal(20, 3)), N'6079855767400', CAST(N'2021-11-11T17:01:27.0051982' AS DateTime2), CAST(N'2021-11-11T17:01:27.0051982' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (25, 23, 2, 1, 1, 1, CAST(5000.000 AS Decimal(20, 3)), N'8079855814300', CAST(N'2021-11-11T17:09:14.9221351' AS DateTime2), CAST(N'2021-11-11T17:09:14.9221351' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (26, 24, 2, 1, 1, 1, CAST(5522.000 AS Decimal(20, 3)), N'4079855839000', CAST(N'2021-11-11T17:13:22.1945439' AS DateTime2), CAST(N'2021-11-11T17:13:22.1945439' AS DateTime2), 9, 9, 2, NULL, 1, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (27, 25, 1, 1, 1, 1, CAST(1000.000 AS Decimal(20, 3)), N'079885571000', CAST(N'2021-11-14T15:34:05.1316551' AS DateTime2), CAST(N'2021-11-14T15:34:25.8392765' AS DateTime2), 8, 8, 1, CAST(0.000 AS Decimal(20, 3)), NULL, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (28, 26, 12, 1, 1, 1, CAST(1000.000 AS Decimal(20, 3)), N'079905233901', CAST(N'2021-11-16T15:33:37.5165319' AS DateTime2), CAST(N'2021-11-16T15:42:00.2188457' AS DateTime2), 2, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (29, 27, 12, 1, 1, 1, CAST(800.000 AS Decimal(20, 3)), N'079905262100', CAST(N'2021-11-16T15:37:45.5627375' AS DateTime2), CAST(N'2021-11-16T16:10:28.9256049' AS DateTime2), 2, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL, 1)
INSERT [dbo].[itemsUnits] ([itemUnitId], [itemId], [unitId], [unitValue], [defaultSale], [defaultPurchase], [price], [barcode], [createDate], [updateDate], [createUserId], [updateUserId], [subUnitId], [purchasePrice], [storageCostId], [isActive]) VALUES (30, 28, 12, 1, 1, 1, CAST(1000.000 AS Decimal(20, 3)), N'079905262100', CAST(N'2021-11-16T15:40:20.7780668' AS DateTime2), CAST(N'2021-11-16T16:07:04.0567017' AS DateTime2), 2, 2, 1, CAST(0.000 AS Decimal(20, 3)), NULL, 1)
SET IDENTITY_INSERT [dbo].[itemsUnits] OFF
GO
SET IDENTITY_INSERT [dbo].[itemUnitUser] ON 

INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1, 9, 9, N'barcode printer-عنصر', CAST(N'2021-11-02T17:52:08.6244780' AS DateTime2), CAST(N'2021-11-02T17:52:08.6244780' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, 8, 9, N'barcode scanner-عنصر', CAST(N'2021-11-02T17:52:08.6422069' AS DateTime2), CAST(N'2021-11-02T17:52:08.6422069' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, 10, 9, N'Cash Drawer-عنصر', CAST(N'2021-11-02T17:52:08.6449252' AS DateTime2), CAST(N'2021-11-02T17:52:08.6449252' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (4, 7, 9, N'Iphone 11-عنصر', CAST(N'2021-11-02T17:52:08.6470436' AS DateTime2), CAST(N'2021-11-02T17:52:08.6470436' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (5, 15, 9, N'laundry-casheir-program-عنصر', CAST(N'2021-11-02T17:52:08.6497352' AS DateTime2), CAST(N'2021-11-02T17:52:08.6497352' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (6, 11, 9, N'POZONE-POS2-عنصر', CAST(N'2021-11-02T17:52:08.6518769' AS DateTime2), CAST(N'2021-11-02T17:52:08.6518769' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (7, 12, 9, N'POZONE-t820-POS-عنصر', CAST(N'2021-11-02T17:52:08.6539427' AS DateTime2), CAST(N'2021-11-02T17:52:08.6539427' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (8, 13, 9, N'POZONE-t835-POS-عنصر', CAST(N'2021-11-02T17:52:08.6565657' AS DateTime2), CAST(N'2021-11-02T17:52:08.6565657' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (9, 14, 9, N'Thermal-rolls-عنصر', CAST(N'2021-11-02T17:52:08.6586513' AS DateTime2), CAST(N'2021-11-02T17:52:08.6586513' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (10, 1, 9, N'الأسبرين -عنصر', CAST(N'2021-11-02T17:52:08.6607955' AS DateTime2), CAST(N'2021-11-02T17:52:08.6607955' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (11, 2, 9, N'الأسبرين -علبة', CAST(N'2021-11-02T17:52:08.6634237' AS DateTime2), CAST(N'2021-11-02T17:52:08.6634237' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (12, 5, 9, N'باراسيتامول -عنصر', CAST(N'2021-11-02T17:52:08.6655639' AS DateTime2), CAST(N'2021-11-02T17:52:08.6655639' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (13, 6, 9, N'باراسيتامول -علبة', CAST(N'2021-11-02T17:52:08.6677701' AS DateTime2), CAST(N'2021-11-02T17:52:08.6677701' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (14, 3, 9, N'بروفين -عنصر', CAST(N'2021-11-02T17:52:08.6694059' AS DateTime2), CAST(N'2021-11-02T17:52:08.6694059' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (15, 4, 9, N'بروفين -علبة', CAST(N'2021-11-02T17:52:08.6722240' AS DateTime2), CAST(N'2021-11-02T17:52:08.6722240' AS DateTime2), 9, 9, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (19, 25, 2, N'2e-Item', CAST(N'2021-11-30T19:25:52.1921075' AS DateTime2), CAST(N'2021-11-30T19:25:52.1921075' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (20, 9, 2, N'barcode printer-Item', CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (21, 8, 2, N'barcode scanner-Item', CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (22, 10, 2, N'Cash Drawer-Item', CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (23, 26, 2, N'DSAD2e-Item', CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (24, 23, 2, N'expire date-Item', CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (25, 7, 2, N'Iphone 11-Item', CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (26, 15, 2, N'laundry-casheir-program-Item', CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), CAST(N'2021-11-30T19:25:52.2077878' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (27, 22, 2, N'new item-Item', CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (28, 27, 2, N'new pack-package', CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (29, 21, 2, N'Package 1-package', CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (30, 11, 2, N'POZONE-POS2-Item', CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (31, 12, 2, N'POZONE-t820-POS-Item', CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (32, 13, 2, N'POZONE-t835-POS-Item', CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (33, 24, 2, N'saddsadasd-Item', CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (34, 28, 2, N'tes1 service-service', CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), CAST(N'2021-11-30T19:25:52.2235573' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (35, 29, 2, N'test2 sr-service', CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (36, 30, 2, N'test5 sr-service', CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (37, 14, 2, N'Thermal-rolls-Item', CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (38, 1, 2, N'الأسبرين -Item', CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (39, 2, 2, N'الأسبرين -Box', CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (40, 5, 2, N'باراسيتامول -Item', CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (41, 6, 2, N'باراسيتامول -Box', CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), CAST(N'2021-11-30T19:25:52.2392566' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (42, 3, 2, N'بروفين -Item', CAST(N'2021-11-30T19:25:52.2549569' AS DateTime2), CAST(N'2021-11-30T19:25:52.2549569' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (43, 4, 2, N'بروفين -Box', CAST(N'2021-11-30T19:25:52.2549569' AS DateTime2), CAST(N'2021-11-30T19:25:52.2549569' AS DateTime2), 2, 2, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (44, 9, 1, N'barcode printer-عنصر', CAST(N'2021-12-01T14:26:22.5622937' AS DateTime2), CAST(N'2021-12-01T14:26:22.5622937' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (45, 10, 1, N'Cash Drawer-عنصر', CAST(N'2021-12-01T14:26:22.6659694' AS DateTime2), CAST(N'2021-12-01T14:26:22.6659694' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (46, 15, 1, N'laundry-casheir-program-عنصر', CAST(N'2021-12-01T14:26:22.6686706' AS DateTime2), CAST(N'2021-12-01T14:26:22.6686706' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (47, 25, 1, N'2e-Item', CAST(N'2021-12-01T14:26:22.6708025' AS DateTime2), CAST(N'2021-12-01T14:26:22.6708025' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (48, 8, 1, N'barcode scanner-Item', CAST(N'2021-12-01T14:26:22.6736804' AS DateTime2), CAST(N'2021-12-01T14:26:22.6736804' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (49, 26, 1, N'DSAD2e-Item', CAST(N'2021-12-01T14:26:22.6758309' AS DateTime2), CAST(N'2021-12-01T14:26:22.6758309' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (50, 23, 1, N'expire date-Item', CAST(N'2021-12-01T14:26:22.6775106' AS DateTime2), CAST(N'2021-12-01T14:26:22.6775106' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (51, 7, 1, N'Iphone 11-Item', CAST(N'2021-12-01T14:26:22.6796262' AS DateTime2), CAST(N'2021-12-01T14:26:22.6796262' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (52, 22, 1, N'new item-Item', CAST(N'2021-12-01T14:26:22.6823373' AS DateTime2), CAST(N'2021-12-01T14:26:22.6823373' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (53, 27, 1, N'new pack-package', CAST(N'2021-12-01T14:26:22.6833855' AS DateTime2), CAST(N'2021-12-01T14:26:22.6833855' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (54, 21, 1, N'Package 1-package', CAST(N'2021-12-01T14:26:22.6854938' AS DateTime2), CAST(N'2021-12-01T14:26:22.6854938' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (55, 11, 1, N'POZONE-POS2-Item', CAST(N'2021-12-01T14:26:22.6871849' AS DateTime2), CAST(N'2021-12-01T14:26:22.6871849' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (56, 12, 1, N'POZONE-t820-POS-Item', CAST(N'2021-12-01T14:26:22.6903550' AS DateTime2), CAST(N'2021-12-01T14:26:22.6903550' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (57, 13, 1, N'POZONE-t835-POS-Item', CAST(N'2021-12-01T14:26:22.6920589' AS DateTime2), CAST(N'2021-12-01T14:26:22.6920589' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (58, 24, 1, N'saddsadasd-Item', CAST(N'2021-12-01T14:26:22.6942296' AS DateTime2), CAST(N'2021-12-01T14:26:22.6942296' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (59, 28, 1, N'tes1 service-service', CAST(N'2021-12-01T14:26:22.6970022' AS DateTime2), CAST(N'2021-12-01T14:26:22.6970022' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (60, 29, 1, N'test2 sr-service', CAST(N'2021-12-01T14:26:22.6991107' AS DateTime2), CAST(N'2021-12-01T14:26:22.6991107' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (61, 30, 1, N'test5 sr-service', CAST(N'2021-12-01T14:26:22.7007114' AS DateTime2), CAST(N'2021-12-01T14:26:22.7007114' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (62, 14, 1, N'Thermal-rolls-Item', CAST(N'2021-12-01T14:26:22.7027959' AS DateTime2), CAST(N'2021-12-01T14:26:22.7027959' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (63, 1, 1, N'الأسبرين -Item', CAST(N'2021-12-01T14:26:22.7048880' AS DateTime2), CAST(N'2021-12-01T14:26:22.7048880' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (64, 2, 1, N'الأسبرين -Box', CAST(N'2021-12-01T14:26:22.7077273' AS DateTime2), CAST(N'2021-12-01T14:26:22.7077273' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (65, 5, 1, N'باراسيتامول -Item', CAST(N'2021-12-01T14:26:22.7098308' AS DateTime2), CAST(N'2021-12-01T14:26:22.7098308' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (66, 6, 1, N'باراسيتامول -Box', CAST(N'2021-12-01T14:26:22.7125212' AS DateTime2), CAST(N'2021-12-01T14:26:22.7125212' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (67, 3, 1, N'بروفين -Item', CAST(N'2021-12-01T14:26:22.7136024' AS DateTime2), CAST(N'2021-12-01T14:26:22.7136024' AS DateTime2), 1, 1, 1)
INSERT [dbo].[itemUnitUser] ([id], [itemUnitId], [userId], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (68, 4, 1, N'بروفين -Box', CAST(N'2021-12-01T14:26:22.7156960' AS DateTime2), CAST(N'2021-12-01T14:26:22.7156960' AS DateTime2), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[itemUnitUser] OFF
GO
SET IDENTITY_INSERT [dbo].[locations] ON 

INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (1, N'0', N'0', N'0', CAST(N'2021-10-27T14:24:10.1324341' AS DateTime2), CAST(N'2021-10-27T14:24:10.1324341' AS DateTime2), 2, 2, 1, 1, N'', 3, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (2, N'0', N'0', N'0', CAST(N'2021-10-27T14:24:26.5182621' AS DateTime2), CAST(N'2021-10-27T14:24:26.5182621' AS DateTime2), 2, 2, 1, 2, N'', 4, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (3, N'0', N'0', N'0', CAST(N'2021-10-27T14:24:48.2845450' AS DateTime2), CAST(N'2021-10-27T14:24:48.2845450' AS DateTime2), 2, 2, 1, 3, N'', 5, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (4, N'0', N'0', N'0', CAST(N'2021-10-27T14:25:05.0038625' AS DateTime2), CAST(N'2021-10-27T14:25:05.0038625' AS DateTime2), 2, 2, 1, 4, N'', 6, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (5, N'0', N'0', N'0', CAST(N'2021-10-27T14:25:23.3740206' AS DateTime2), CAST(N'2021-10-27T14:25:23.3740206' AS DateTime2), 2, 2, 1, 5, N'', 7, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (6, N'0', N'0', N'0', CAST(N'2021-10-27T14:25:39.9169728' AS DateTime2), CAST(N'2021-10-27T14:25:39.9169728' AS DateTime2), 2, 2, 1, 6, N'', 8, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (7, N'0', N'0', N'0', CAST(N'2021-10-27T14:26:29.3774454' AS DateTime2), CAST(N'2021-10-27T14:26:29.3774454' AS DateTime2), 2, 2, 1, 7, N'', 9, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (8, N'0', N'0', N'0', CAST(N'2021-10-27T14:26:47.8100808' AS DateTime2), CAST(N'2021-10-27T14:26:47.8100808' AS DateTime2), 2, 2, 1, 8, N'', 10, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (9, N'0', N'0', N'0', CAST(N'2021-10-27T14:27:16.9653877' AS DateTime2), CAST(N'2021-10-27T14:27:16.9653877' AS DateTime2), 2, 2, 1, 9, N'', 11, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (10, N'0', N'0', N'0', CAST(N'2021-10-27T14:27:44.4980951' AS DateTime2), CAST(N'2021-10-27T14:27:44.4980951' AS DateTime2), 2, 2, 1, 10, N'', 12, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (11, N'0', N'0', N'0', CAST(N'2021-10-27T14:28:08.9172716' AS DateTime2), CAST(N'2021-10-27T14:28:08.9172716' AS DateTime2), 2, 2, 1, 11, N'', 13, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (12, N'0', N'0', N'0', CAST(N'2021-10-27T14:28:27.6526727' AS DateTime2), CAST(N'2021-10-27T14:28:27.6526727' AS DateTime2), 2, 2, 1, 12, N'', 14, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (13, N'0', N'0', N'0', CAST(N'2021-10-27T14:28:43.0800075' AS DateTime2), CAST(N'2021-10-27T14:28:43.0800075' AS DateTime2), 2, 2, 1, 13, N'', 15, 1)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (16, N'1', N'1', N'1', CAST(N'2021-10-28T15:37:09.6520277' AS DateTime2), CAST(N'2021-10-28T15:43:15.7753071' AS DateTime2), 9, 9, 1, 16, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (17, N'1', N'1', N'2', CAST(N'2021-10-28T15:41:24.7375274' AS DateTime2), CAST(N'2021-10-28T15:43:15.7811197' AS DateTime2), 9, 9, 1, 16, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (18, N'1', N'1', N'3', CAST(N'2021-10-28T15:41:31.4051849' AS DateTime2), CAST(N'2021-10-28T15:43:15.7843141' AS DateTime2), 9, 9, 1, 16, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (19, N'1', N'2', N'1', CAST(N'2021-10-28T15:41:43.4329084' AS DateTime2), CAST(N'2021-10-28T15:43:24.3998918' AS DateTime2), 9, 9, 1, 17, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (20, N'1', N'2', N'2', CAST(N'2021-10-28T15:41:48.9334963' AS DateTime2), CAST(N'2021-10-28T15:43:24.4036346' AS DateTime2), 9, 9, 1, 17, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (21, N'1', N'2', N'3', CAST(N'2021-10-28T15:41:53.2787785' AS DateTime2), CAST(N'2021-10-28T15:43:24.4068927' AS DateTime2), 9, 9, 1, 17, N'', 2, NULL)
INSERT [dbo].[locations] ([locationId], [x], [y], [z], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [sectionId], [note], [branchId], [isFreeZone]) VALUES (22, N'0', N'0', N'0', CAST(N'2021-06-29T15:23:22.5919044' AS DateTime2), CAST(N'2021-06-29T15:23:22.5919044' AS DateTime2), 1, 1, 1, 18, N'', 2, 1)
SET IDENTITY_INSERT [dbo].[locations] OFF
GO
SET IDENTITY_INSERT [dbo].[notification] ON 

INSERT [dbo].[notification] ([notId], [title], [ncontent], [side], [msgType], [path], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1036, N'trExceedMinLimitAlertTilte', N'بروفين :trExceedMinLimitAlertContent', NULL, N'alert', NULL, CAST(N'2021-12-01T18:31:03.9906294' AS DateTime2), CAST(N'2021-12-01T18:31:03.9906294' AS DateTime2), 8, 8, 1)
INSERT [dbo].[notification] ([notId], [title], [ncontent], [side], [msgType], [path], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1037, N'trExceedMinLimitAlertTilte', N'باراسيتامول :trExceedMinLimitAlertContent', NULL, N'alert', NULL, CAST(N'2021-12-01T18:31:04.1096057' AS DateTime2), CAST(N'2021-12-01T18:31:04.1096057' AS DateTime2), 8, 8, 1)
INSERT [dbo].[notification] ([notId], [title], [ncontent], [side], [msgType], [path], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1038, N'trExceedMinLimitAlertTilte', N'barcode printer:trExceedMinLimitAlertContent', NULL, N'alert', NULL, CAST(N'2021-12-01T18:31:04.2053691' AS DateTime2), CAST(N'2021-12-01T18:31:04.2053691' AS DateTime2), 8, 8, 1)
INSERT [dbo].[notification] ([notId], [title], [ncontent], [side], [msgType], [path], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1039, N'trExceedMinLimitAlertTilte', N'باراسيتامول :trExceedMinLimitAlertContent', NULL, N'alert', NULL, CAST(N'2021-12-01T18:35:01.7993149' AS DateTime2), CAST(N'2021-12-01T18:35:01.7993149' AS DateTime2), 8, 8, 1)
SET IDENTITY_INSERT [dbo].[notification] OFF
GO
SET IDENTITY_INSERT [dbo].[notificationUser] ON 

INSERT [dbo].[notificationUser] ([notUserId], [notId], [userId], [isRead], [createDate], [updateDate], [createUserId], [updateUserId], [posId]) VALUES (1083, 1036, 9, 0, CAST(N'2021-12-01T18:31:04.0176458' AS DateTime2), CAST(N'2021-12-01T18:31:04.0176458' AS DateTime2), 8, 8, NULL)
INSERT [dbo].[notificationUser] ([notUserId], [notId], [userId], [isRead], [createDate], [updateDate], [createUserId], [updateUserId], [posId]) VALUES (1084, 1036, 1, 1, CAST(N'2021-12-01T18:31:04.0293385' AS DateTime2), CAST(N'2021-12-01T19:24:05.6949793' AS DateTime2), 8, 8, NULL)
INSERT [dbo].[notificationUser] ([notUserId], [notId], [userId], [isRead], [createDate], [updateDate], [createUserId], [updateUserId], [posId]) VALUES (1085, 1036, 2, 1, CAST(N'2021-12-01T18:31:04.0303984' AS DateTime2), CAST(N'2021-12-02T16:03:50.9770187' AS DateTime2), 8, 8, NULL)
INSERT [dbo].[notificationUser] ([notUserId], [notId], [userId], [isRead], [createDate], [updateDate], [createUserId], [updateUserId], [posId]) VALUES (1086, 1037, 9, 0, CAST(N'2021-12-01T18:31:04.1214028' AS DateTime2), CAST(N'2021-12-01T18:31:04.1214028' AS DateTime2), 8, 8, NULL)
INSERT [dbo].[notificationUser] ([notUserId], [notId], [userId], [isRead], [createDate], [updateDate], [createUserId], [updateUserId], [posId]) VALUES (1087, 1037, 1, 1, CAST(N'2021-12-01T18:31:04.1251954' AS DateTime2), CAST(N'2021-12-01T19:24:05.7049985' AS DateTime2), 8, 8, NULL)
INSERT [dbo].[notificationUser] ([notUserId], [notId], [userId], [isRead], [createDate], [updateDate], [createUserId], [updateUserId], [posId]) VALUES (1088, 1037, 2, 1, CAST(N'2021-12-01T18:31:04.1251954' AS DateTime2), CAST(N'2021-12-02T16:03:50.9856830' AS DateTime2), 8, 8, NULL)
INSERT [dbo].[notificationUser] ([notUserId], [notId], [userId], [isRead], [createDate], [updateDate], [createUserId], [updateUserId], [posId]) VALUES (1089, 1038, 9, 0, CAST(N'2021-12-01T18:31:04.2239231' AS DateTime2), CAST(N'2021-12-01T18:31:04.2239231' AS DateTime2), 8, 8, NULL)
INSERT [dbo].[notificationUser] ([notUserId], [notId], [userId], [isRead], [createDate], [updateDate], [createUserId], [updateUserId], [posId]) VALUES (1090, 1038, 1, 1, CAST(N'2021-12-01T18:31:04.2266935' AS DateTime2), CAST(N'2021-12-01T19:24:05.7065839' AS DateTime2), 8, 8, NULL)
INSERT [dbo].[notificationUser] ([notUserId], [notId], [userId], [isRead], [createDate], [updateDate], [createUserId], [updateUserId], [posId]) VALUES (1091, 1038, 2, 1, CAST(N'2021-12-01T18:31:04.2266935' AS DateTime2), CAST(N'2021-12-02T16:03:50.9894748' AS DateTime2), 8, 8, NULL)
INSERT [dbo].[notificationUser] ([notUserId], [notId], [userId], [isRead], [createDate], [updateDate], [createUserId], [updateUserId], [posId]) VALUES (1092, 1039, 9, 0, CAST(N'2021-12-01T18:35:01.8091366' AS DateTime2), CAST(N'2021-12-01T18:35:01.8091366' AS DateTime2), 8, 8, NULL)
INSERT [dbo].[notificationUser] ([notUserId], [notId], [userId], [isRead], [createDate], [updateDate], [createUserId], [updateUserId], [posId]) VALUES (1093, 1039, 1, 1, CAST(N'2021-12-01T18:35:01.8118925' AS DateTime2), CAST(N'2021-12-01T19:24:05.7097126' AS DateTime2), 8, 8, NULL)
INSERT [dbo].[notificationUser] ([notUserId], [notId], [userId], [isRead], [createDate], [updateDate], [createUserId], [updateUserId], [posId]) VALUES (1094, 1039, 2, 1, CAST(N'2021-12-01T18:35:01.8118925' AS DateTime2), CAST(N'2021-12-02T16:03:50.9933439' AS DateTime2), 8, 8, NULL)
SET IDENTITY_INSERT [dbo].[notificationUser] OFF
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
SET IDENTITY_INSERT [dbo].[offers] ON 

INSERT [dbo].[offers] ([offerId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (1, N'test1', N'OFR_1', 1, N'2', CAST(10.000 AS Decimal(20, 3)), CAST(N'2021-11-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), NULL, NULL, 9, NULL, N'')
INSERT [dbo].[offers] ([offerId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (2, N'offer1', N'OFR_2', 1, N'1', CAST(10.000 AS Decimal(20, 3)), CAST(N'2021-11-07T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-13T06:29:00.0000000' AS DateTime2), NULL, NULL, 3, NULL, N'')
INSERT [dbo].[offers] ([offerId], [name], [code], [isActive], [discountType], [discountValue], [startDate], [endDate], [createDate], [updateDate], [createUserId], [updateUserId], [notes]) VALUES (3, N'offer3', N'OFR_3', 1, N'1', CAST(25.000 AS Decimal(20, 3)), CAST(N'2021-11-07T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-30T06:29:00.0000000' AS DateTime2), NULL, NULL, 3, NULL, N'')
SET IDENTITY_INSERT [dbo].[offers] OFF
GO
SET IDENTITY_INSERT [dbo].[packages] ON 

INSERT [dbo].[packages] ([packageId], [parentIUId], [childIUId], [quantity], [isActive], [notes], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (14, 21, 3, 2, 1, N'بروفين -عنصر', 9, 9, NULL, CAST(N'2021-11-04T15:23:08.1651026' AS DateTime2))
INSERT [dbo].[packages] ([packageId], [parentIUId], [childIUId], [quantity], [isActive], [notes], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (15, 21, 5, 1, 1, N'باراسيتامول -عنصر', 9, 9, NULL, CAST(N'2021-11-04T15:23:08.1651026' AS DateTime2))
INSERT [dbo].[packages] ([packageId], [parentIUId], [childIUId], [quantity], [isActive], [notes], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (16, 21, 1, 1, 1, N'الأسبرين -عنصر', 9, 9, NULL, CAST(N'2021-11-04T15:23:08.1651026' AS DateTime2))
INSERT [dbo].[packages] ([packageId], [parentIUId], [childIUId], [quantity], [isActive], [notes], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (17, 27, 8, 1, 1, N'barcode scanner-عنصر', 8, 8, NULL, CAST(N'2021-11-14T15:34:19.3227028' AS DateTime2))
INSERT [dbo].[packages] ([packageId], [parentIUId], [childIUId], [quantity], [isActive], [notes], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (18, 27, 10, 1, 1, N'Cash Drawer-عنصر', 8, 8, NULL, CAST(N'2021-11-14T15:34:19.3227028' AS DateTime2))
SET IDENTITY_INSERT [dbo].[packages] OFF
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

INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (1, N'Al-JM-B-POS-1', N'POS-1', CAST(315630.000 AS Decimal(20, 3)), 2, CAST(N'2021-06-29T16:51:49.0366461' AS DateTime2), CAST(N'2021-12-06T14:41:40.1840123' AS DateTime2), 1, 9, 1, N'', CAST(0.000 AS Decimal(20, 3)))
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (2, N'Al-FK-B-POS-2', N'POS-2', CAST(0.000 AS Decimal(20, 3)), 3, CAST(N'2021-10-27T14:30:16.9690860' AS DateTime2), CAST(N'2021-11-06T14:57:44.7616428' AS DateTime2), 2, 9, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (3, N'Al-AD-B-POS-3', N'POS-3', CAST(0.000 AS Decimal(20, 3)), 4, CAST(N'2021-10-27T14:30:40.1756774' AS DateTime2), CAST(N'2021-10-27T14:34:04.8346627' AS DateTime2), 2, 2, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (4, N'Al-JF-S-POS-1', N'POS-1', CAST(0.000 AS Decimal(20, 3)), 11, CAST(N'2021-10-27T14:31:14.0737977' AS DateTime2), CAST(N'2021-10-27T14:34:59.4406012' AS DateTime2), 2, 2, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (5, N'Al-FA-S-POS-1', N'POS-1', CAST(0.000 AS Decimal(20, 3)), 12, CAST(N'2021-10-27T14:31:51.4092346' AS DateTime2), CAST(N'2021-10-27T14:35:18.9374885' AS DateTime2), 2, 2, 1, N'', NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (6, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-11-23T13:08:32.4976453' AS DateTime2), CAST(N'2021-11-23T13:08:32.4976453' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (7, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-11-23T13:27:27.7899334' AS DateTime2), CAST(N'2021-11-23T13:27:27.7899334' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (8, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-11-23T15:54:24.6878606' AS DateTime2), CAST(N'2021-11-23T15:54:24.6878606' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[pos] ([posId], [code], [name], [balance], [branchId], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [note], [balanceAll]) VALUES (9, NULL, NULL, CAST(0.000 AS Decimal(20, 3)), NULL, CAST(N'2021-11-23T16:33:06.6695975' AS DateTime2), CAST(N'2021-11-23T16:33:06.6695975' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[pos] OFF
GO
SET IDENTITY_INSERT [dbo].[posSerials] ON 

INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (1, N'123', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (2, N'456', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (3, N'123456', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (4, N'147', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (5, N'546', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (6, N'CRN0BdwFProsQG33', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (7, N'fmxgBtoUCjliqUuI', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (8, N'1uEi7c1vkuEdibR0', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (9, N'R6qBAbCj69u1SWsT', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (10, N'BAJQKTHAJ7DEpAqG', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (11, N'77JMvBWWxLHMwcHu', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (12, N'F1yy1jCBYSIeAREJ', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (13, N'C3AtzlME0bPWxVRD', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (14, N'rKvhoIBQpkhfV36X', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (15, N'uhbTZmnfkjor2X7y', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (16, N'sACXdDEHMAjPWypL', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (17, N'WGjnPpe9nErLGrdO', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (18, N'AF3LMFQF26HEveFU', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (19, N'DNquBuW1qzgxbvA2', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (20, N'P6ZHIdkZcCmo9HgA', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (21, N'pp6H0OhLclee7uDP', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (22, N'X4Cy10JjzRYATNZE', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (23, N'HQyLAKPhqknWDqyn', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (24, N'R4jeShPFiW6UKAgW', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (25, N'SxvCs4ufUKDhMY19', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (26, N'6EBHoVY64hiPln3G', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (27, N'HlI0Hai4zWKkbeas', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (28, N'u6tCzgel69ykNnuw', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (29, N'Ts2qejlODbcKYmgM', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (30, N'm4omlqtQbtbXRmES', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (31, N'CwZnDiHgEUQYyrRz', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (32, N'YLbbzq2XT4f0mTU9', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (33, N'y1qq422UI32cMuly', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (34, N'ELcQpENWOCJ7qfgB', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (35, N'4xObopRWinkbtqhe', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (36, N'FFlnGgDgs2yaPME7', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (37, N'QhJiDAJmjniL20kK', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (38, N'YBaztZpSbP70cCBz', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (39, N'ZGpO7Xet9oi99wIB', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (40, N'oBVmWWD6ZFf6McCF', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (41, N'QMJrcWBS2vsMYTWb', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (42, N'7Yp3BOAsZmxuse6n', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (43, N'37BvyeY3CW79vhYR', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (44, N'ZzBuvSGQ7X0mrDia', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (45, N'6UCXPc4oBeEKefuI', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (46, N'taxZXSYd2Wa07zWJ', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (47, N'hRF1HbpCuUzlyZjT', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (48, N'kkIYiibUYIFMlTAc', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (49, N'G14CXkjf3SHRvBQd', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (50, N'spWvX6urQ6unpduU', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (51, N'sUqkzQX6S9VJKc4e', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (52, N'KyYW47i4HH9Deaed', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (53, N'HbCdvnSDk1Qk4gPx', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (54, N'0wQpKWWw4zh1Jadd', NULL)
INSERT [dbo].[posSerials] ([id], [posSerial], [notes]) VALUES (55, N'4dbftsZcKG3P4OEm', NULL)
SET IDENTITY_INSERT [dbo].[posSerials] OFF
GO
SET IDENTITY_INSERT [dbo].[posSetting] ON 

INSERT [dbo].[posSetting] ([posSettingId], [posId], [saleInvPrinterId], [reportPrinterId], [saleInvPapersizeId], [posSerial], [docPapersizeId], [posDeviceCode], [posSerialId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (5, 1, 5, 6, 1, NULL, 6, NULL, 1, NULL, NULL, 1, 1)
INSERT [dbo].[posSetting] ([posSettingId], [posId], [saleInvPrinterId], [reportPrinterId], [saleInvPapersizeId], [posSerial], [docPapersizeId], [posDeviceCode], [posSerialId], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (6, 2, NULL, NULL, NULL, NULL, NULL, N'None-1EAE7B7CA17220E0', 3, CAST(N'2021-11-27T16:17:06.1881567' AS DateTime2), CAST(N'2021-11-27T16:17:06.1881567' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[posSetting] OFF
GO
SET IDENTITY_INSERT [dbo].[printers] ON 

INSERT [dbo].[printers] ([printerId], [name], [printFor], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (1, N'TWljcm9zb2Z0IFByaW50IHRvIFBERg==', N'sal', CAST(N'2021-10-31T21:24:01.3421190' AS DateTime2), CAST(N'2021-10-31T21:24:01.3421190' AS DateTime2), NULL, NULL)
INSERT [dbo].[printers] ([printerId], [name], [printFor], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (2, N'TWljcm9zb2Z0IFByaW50IHRvIFBERg==', N'doc', CAST(N'2021-10-31T21:24:01.9200716' AS DateTime2), CAST(N'2021-10-31T21:24:01.9200716' AS DateTime2), NULL, NULL)
INSERT [dbo].[printers] ([printerId], [name], [printFor], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (3, N'TWljcm9zb2Z0IFByaW50IHRvIFBERg==', N'sal', CAST(N'2021-10-31T21:24:55.1859696' AS DateTime2), CAST(N'2021-10-31T21:24:55.1859696' AS DateTime2), NULL, NULL)
INSERT [dbo].[printers] ([printerId], [name], [printFor], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (4, N'TWljcm9zb2Z0IFByaW50IHRvIFBERg==', N'doc', CAST(N'2021-10-31T21:25:10.2014724' AS DateTime2), CAST(N'2021-10-31T21:25:10.2014724' AS DateTime2), NULL, NULL)
INSERT [dbo].[printers] ([printerId], [name], [printFor], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (5, N'TWljcm9zb2Z0IFByaW50IHRvIFBERg==', N'sal', CAST(N'2021-11-10T23:23:25.7064840' AS DateTime2), CAST(N'2021-12-01T15:10:44.6106154' AS DateTime2), NULL, NULL)
INSERT [dbo].[printers] ([printerId], [name], [printFor], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (6, N'TWljcm9zb2Z0IFByaW50IHRvIFBERg==', N'rep', CAST(N'2021-11-10T23:23:26.2259370' AS DateTime2), CAST(N'2021-12-01T15:10:44.0490272' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[printers] OFF
GO
INSERT [dbo].[ProgramDetails] ([id], [programName], [branchCount], [posCount], [userCount], [vendorCount], [customerCount], [itemCount], [saleinvCount], [programIncId], [versionIncId], [versionName], [storeCount], [packageSaleCode], [customerServerCode], [expireDate], [isOnlineServer], [packageNumber], [updateDate]) VALUES (1, N'pos', 5, 10, 50, 20, 50, 10000, 10000, NULL, 1, N'ver1', 2, N'xdQxOXGp4JNaUsRM', N'2C8356D0', NULL, NULL, NULL, CAST(N'2021-11-21T17:30:31.5737683' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[properties] ON 

INSERT [dbo].[properties] ([propertyId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (1, N'Colors', CAST(N'2021-10-27T17:34:44.9898673' AS DateTime2), CAST(N'2021-11-20T14:55:12.3224772' AS DateTime2), 2, 9, 1)
INSERT [dbo].[properties] ([propertyId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'Size', CAST(N'2021-10-27T17:34:57.8915060' AS DateTime2), CAST(N'2021-11-28T12:41:00.4253024' AS DateTime2), 2, 1, 1)
SET IDENTITY_INSERT [dbo].[properties] OFF
GO
SET IDENTITY_INSERT [dbo].[propertiesItems] ON 

INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (2, N'red', 1, NULL, CAST(N'2021-10-27T17:35:27.7476986' AS DateTime2), CAST(N'2021-11-20T14:25:53.7708669' AS DateTime2), 2, 9, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (3, N'Blue', 1, NULL, CAST(N'2021-10-27T17:35:39.7802301' AS DateTime2), CAST(N'2021-11-20T14:54:51.3723312' AS DateTime2), 2, 9, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (4, N'Yellow ', 1, NULL, CAST(N'2021-10-27T17:35:47.7848219' AS DateTime2), CAST(N'2021-11-20T14:27:50.2750744' AS DateTime2), 2, 9, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (5, N'Purple', 1, NULL, CAST(N'2021-10-27T17:35:53.7380560' AS DateTime2), CAST(N'2021-11-20T14:36:50.1192021' AS DateTime2), 2, 9, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (6, N'Green', 1, NULL, CAST(N'2021-10-27T17:36:09.3678435' AS DateTime2), CAST(N'2021-11-20T14:44:23.0490106' AS DateTime2), 2, 9, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (7, N'Maroon', 1, NULL, CAST(N'2021-10-27T17:36:12.3667652' AS DateTime2), CAST(N'2021-11-20T14:45:26.2790105' AS DateTime2), 2, 9, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (8, N'Aqua', 1, NULL, CAST(N'2021-10-27T17:36:20.9386710' AS DateTime2), CAST(N'2021-11-20T14:47:23.3683413' AS DateTime2), 2, 9, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (9, N'White', 1, NULL, CAST(N'2021-10-27T17:36:27.1893593' AS DateTime2), CAST(N'2021-11-20T14:53:28.7535679' AS DateTime2), 2, 9, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (10, N'Black', 1, NULL, CAST(N'2021-10-27T17:36:33.0240117' AS DateTime2), CAST(N'2021-11-20T14:53:47.1298025' AS DateTime2), 2, 9, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (13, N'S', 2, NULL, CAST(N'2021-10-27T17:36:09.3678435' AS DateTime2), CAST(N'2021-10-27T17:36:09.3678435' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (14, N'M', 2, NULL, CAST(N'2021-10-27T17:36:12.3667652' AS DateTime2), CAST(N'2021-10-27T17:36:12.3667652' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (15, N'L', 2, NULL, CAST(N'2021-10-27T17:36:20.9386710' AS DateTime2), CAST(N'2021-10-27T17:36:20.9386710' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (16, N'XL', 2, NULL, CAST(N'2021-10-27T17:36:27.1893593' AS DateTime2), CAST(N'2021-10-27T17:36:27.1893593' AS DateTime2), 2, 2, 1)
INSERT [dbo].[propertiesItems] ([propertyItemId], [name], [propertyId], [isDefault], [createDate], [updateDate], [createUserId], [updateUserId], [isActive]) VALUES (17, N'XLL', 2, NULL, CAST(N'2021-10-27T17:36:33.0240117' AS DateTime2), CAST(N'2021-10-27T17:36:33.0240117' AS DateTime2), 2, 2, 1)
SET IDENTITY_INSERT [dbo].[propertiesItems] OFF
GO
SET IDENTITY_INSERT [dbo].[sections] ON 

INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (1, N'FreeZone', CAST(N'2021-10-27T14:24:09.6148636' AS DateTime2), CAST(N'2021-10-27T14:24:09.6148636' AS DateTime2), 2, 2, 3, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (2, N'FreeZone', CAST(N'2021-10-27T14:24:26.0346580' AS DateTime2), CAST(N'2021-10-27T14:24:26.0346580' AS DateTime2), 2, 2, 4, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (3, N'FreeZone', CAST(N'2021-10-27T14:24:47.6974780' AS DateTime2), CAST(N'2021-10-27T14:24:47.6974780' AS DateTime2), 2, 2, 5, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (4, N'FreeZone', CAST(N'2021-10-27T14:25:04.2776580' AS DateTime2), CAST(N'2021-10-27T14:25:04.2776580' AS DateTime2), 2, 2, 6, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (5, N'FreeZone', CAST(N'2021-10-27T14:25:22.7207250' AS DateTime2), CAST(N'2021-10-27T14:25:22.7207250' AS DateTime2), 2, 2, 7, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (6, N'FreeZone', CAST(N'2021-10-27T14:25:39.2724663' AS DateTime2), CAST(N'2021-10-27T14:25:39.2724663' AS DateTime2), 2, 2, 8, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (7, N'FreeZone', CAST(N'2021-10-27T14:26:28.7975104' AS DateTime2), CAST(N'2021-10-27T14:26:28.7975104' AS DateTime2), 2, 2, 9, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (8, N'FreeZone', CAST(N'2021-10-27T14:26:46.5426420' AS DateTime2), CAST(N'2021-10-27T14:26:46.5426420' AS DateTime2), 2, 2, 10, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (9, N'FreeZone', CAST(N'2021-10-27T14:27:15.4520956' AS DateTime2), CAST(N'2021-10-27T14:27:15.4520956' AS DateTime2), 2, 2, 11, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (10, N'FreeZone', CAST(N'2021-10-27T14:27:44.0144404' AS DateTime2), CAST(N'2021-10-27T14:27:44.0144404' AS DateTime2), 2, 2, 12, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (11, N'FreeZone', CAST(N'2021-10-27T14:28:08.4594448' AS DateTime2), CAST(N'2021-10-27T14:28:08.4594448' AS DateTime2), 2, 2, 13, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (12, N'FreeZone', CAST(N'2021-10-27T14:28:27.1311079' AS DateTime2), CAST(N'2021-10-27T14:28:27.1311079' AS DateTime2), 2, 2, 14, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (13, N'FreeZone', CAST(N'2021-10-27T14:28:42.4768992' AS DateTime2), CAST(N'2021-10-27T14:28:42.4768992' AS DateTime2), 2, 2, 15, 1, N'', 1)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (16, N'طبية', CAST(N'2021-10-28T15:36:48.3027224' AS DateTime2), CAST(N'2021-10-28T15:36:48.3027224' AS DateTime2), 9, 9, 2, 1, N'', NULL)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (17, N'تقنية', CAST(N'2021-10-28T15:36:57.7757897' AS DateTime2), CAST(N'2021-10-28T15:36:57.7757897' AS DateTime2), 9, 9, 2, 1, N'', NULL)
INSERT [dbo].[sections] ([sectionId], [name], [createDate], [updateDate], [createUserId], [updateUserId], [branchId], [isActive], [note], [isFreeZone]) VALUES (18, N'FreeZone', CAST(N'2021-06-29T15:23:22.5233511' AS DateTime2), CAST(N'2021-06-29T15:23:22.5233511' AS DateTime2), 1, 1, 2, 1, N'', 1)
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
SET IDENTITY_INSERT [dbo].[setting] OFF
GO
SET IDENTITY_INSERT [dbo].[setValues] ON 

INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (1, N'en', NULL, NULL, NULL, 9)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (2, N'ar', NULL, NULL, NULL, 9)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (12, N'0', 1, 1, NULL, 11)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (13, N'2000', 1, 1, NULL, 12)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (14, N'ad4bfd50185ef68bce2b903aa7e10ec0.jpg', 1, 1, N'', 7)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (15, N'Purchase Order', NULL, 1, N'title', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (16, N'Please provide to us,with a price list,along with your terms and conditions of sale, applicable discounts, shipping dates and additional sales and corporate policies. Should the information you provide be acceptable and competitive.', NULL, 1, N'text1', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (17, N'Thank you for your cooperation. We have also enclosed our procurement specifications and conditions for your review', NULL, 1, N'text2', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (18, N'Support', NULL, 1, N'link1text', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (19, N'Returnpolicy ', NULL, 1, N'link2text', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (20, N'About Us', NULL, NULL, N'link3text', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (22, N'http://www.google.com', NULL, 1, N'link1url', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (23, N'http://www.google.com', NULL, 1, N'link2url', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (24, N'http://www.google.com', NULL, 1, N'link3url', 13)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (25, N'LongDatePattern', 1, 1, NULL, 14)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (26, N'Sales', NULL, 1, N'title', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (27, N'Please provide to us,with a price list,along with your terms and conditions of sale, applicable discounts, shipping dates and additional sales and corporate policies. Should the information you provide be acceptable and competitive.', NULL, 1, N'text1', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (28, N'Thank you for your cooperation. We have also enclosed our procurement specifications and conditions for your review', NULL, 1, N'text2', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (29, N'Support', NULL, 1, N'link1text', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (30, N'Returnpolicy ', NULL, 1, N'link2text', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (31, N'About Us', NULL, NULL, N'link3text', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (32, N'http://www.google.com', NULL, 1, N'link1url', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (33, N'http://www.google.com', NULL, 1, N'link2url', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (34, N'http://www.google.com', NULL, 1, N'link3url', 15)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (39, N'Sale Order', NULL, 1, N'title', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (40, N'This IS  Order,with a price list,along with your terms and conditions of sale, applicable discounts, shipping dates and additional sales and corporate policies. Should the information you provide be acceptable and competitive.', NULL, NULL, N'text1', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (41, N'Thank you for your cooperation. We have also enclosed our procurement specifications and conditions for your review', NULL, 1, N'text2', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (42, N'Support', NULL, 1, N'link1text', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (43, N'Returnpolicy ', NULL, 1, N'link2text', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (44, N'About Us', NULL, 1, N'link3text', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (45, N'http://www.google.com', NULL, 1, N'link1url', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (46, N'http://www.google.com', NULL, 1, N'link2url', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (47, N'http://www.google.com', NULL, 1, N'link3url', 16)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (48, N'Quotation', NULL, 1, N'title', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (49, N'This IS Quotation,with a price list,along with your terms and conditions of sale, applicable discounts, shipping dates and additional sales and corporate policies. Should the information you provide be acceptable and competitive.', NULL, NULL, N'text1', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (50, N'Thank you for your cooperation. We have also enclosed our procurement specifications and conditions for your review', NULL, 1, N'text2', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (51, N'Support', NULL, 1, N'link1text', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (52, N'Returnpolicy ', NULL, 1, N'link2text', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (53, N'About Us', NULL, NULL, N'link3text', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (54, N'http://www.google.com', NULL, 1, N'link1url', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (55, N'http://www.google.com', NULL, 1, N'link2url', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (56, N'http://www.google.com', NULL, 1, N'link3url', 17)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (58, N'Increase', 1, 1, NULL, 1)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (59, N'Kuwait', 1, 1, NULL, 2)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (60, N'info@Increase.com', 1, 1, NULL, 3)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (61, N'+965-098765489', 1, 1, NULL, 4)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (62, N'+965--52333333242342', 1, 1, NULL, 5)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (63, N'+965-31-544332224234', 1, 1, NULL, 6)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (64, N'Requirement', NULL, 1, N'title', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (65, N'This IS Quotation,with a price list,along with your terms and conditions of sale, applicable discounts, shipping dates and additional sales and corporate policies. Should the information you provide be acceptable and competitive.', NULL, NULL, N'text1', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (66, N'Thank you for your cooperation. We have also enclosed our procurement specifications and conditions for your review', NULL, 1, N'text2', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (67, N'Support', NULL, 1, N'link1text', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (68, N'Returnpolicy ', NULL, 1, N'link2text', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (69, N'About Us', NULL, NULL, N'link3text', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (70, N'http://www.google.com', NULL, 1, N'link1url', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (71, N'http://www.google.com', NULL, 1, N'link2url', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (72, N'http://www.google.com', NULL, 1, N'link3url', 18)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (73, N'1', NULL, 1, N'print', 19)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (74, N'1', NULL, 1, N'print', 20)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (75, N'0', NULL, 1, N'print', 21)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (76, N'0', NULL, 1, N'print', 22)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (77, N'1', NULL, 1, N'print', 23)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (78, N'1', NULL, 1, N'print', 24)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (79, N'open', NULL, NULL, NULL, 25)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (80, N'close', NULL, NULL, NULL, 25)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (81, N'en', 1, 1, NULL, 26)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (82, N'ar', 0, 1, NULL, 26)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (83, N'1', 1, 1, N'print', 27)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (84, N'first', NULL, NULL, NULL, 28)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (85, N'second', NULL, NULL, NULL, 28)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (87, N'1', 1, 1, NULL, 29)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (88, N'Purchase Invoice', NULL, 1, N'title', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (89, N'This IS  Order,with a price list,along with your terms and conditions of sale, applicable discounts, shipping dates and additional sales and corporate policies. Should the information you provide be acceptable and competitive.', NULL, NULL, N'text1', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (90, N'Thank you for your cooperation. We have also enclosed our procurement specifications and conditions for your review', NULL, 1, N'text2', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (91, N'Support', NULL, 1, N'link1text', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (92, N'Returnpolicy ', NULL, 1, N'link2text', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (93, N'About Us', NULL, 1, N'link3text', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (94, N'http://www.google.com', NULL, 1, N'link1url', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (95, N'http://www.google.com', NULL, 1, N'link2url', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (96, N'http://www.google.com', NULL, 1, N'link3url', 30)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (103, N'increase', 1, 1, NULL, 1)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (104, N'aleppo', 1, 1, NULL, 2)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (105, N'inc@gmail.com', 1, 1, NULL, 3)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (106, N'+965-12343', 1, 1, NULL, 4)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (107, N'+96534556', 1, 1, NULL, 5)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (108, N'+9653345', 1, 1, NULL, 6)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (109, N'5', 1, 1, NULL, 31)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (110, N'5', 1, 1, N'print', 32)
INSERT [dbo].[setValues] ([valId], [value], [isDefault], [isSystem], [notes], [settingId]) VALUES (111, N'500', 1, 1, NULL, 33)
SET IDENTITY_INSERT [dbo].[setValues] OFF
GO
SET IDENTITY_INSERT [dbo].[shippingCompanies] ON 

INSERT [dbo].[shippingCompanies] ([shippingCompanyId], [name], [RealDeliveryCost], [deliveryCost], [deliveryType], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [balance], [balanceType], [email], [phone], [mobile], [fax], [address]) VALUES (1, N'Local     ', CAST(1000.000 AS Decimal(20, 3)), CAST(1500.000 AS Decimal(20, 3)), N'local', N'', CAST(N'2021-10-27T17:29:10.5505682' AS DateTime2), CAST(N'2021-11-16T17:42:30.4547474' AS DateTime2), 2, 2, 1, CAST(1000.000 AS Decimal(20, 3)), 0, N'', N'', N'+965-999999999', N'', N'')
INSERT [dbo].[shippingCompanies] ([shippingCompanyId], [name], [RealDeliveryCost], [deliveryCost], [deliveryType], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [balance], [balanceType], [email], [phone], [mobile], [fax], [address]) VALUES (2, N'Haram     ', CAST(1500.000 AS Decimal(20, 3)), CAST(2000.000 AS Decimal(20, 3)), N'com', N'', CAST(N'2021-10-27T17:29:29.9155006' AS DateTime2), CAST(N'2021-11-22T15:18:13.1827492' AS DateTime2), 2, 2, 0, CAST(62800.000 AS Decimal(20, 3)), 1, N'', N'', N'+965-999999999', N'', N'')
INSERT [dbo].[shippingCompanies] ([shippingCompanyId], [name], [RealDeliveryCost], [deliveryCost], [deliveryType], [notes], [createDate], [updateDate], [createUserId], [updateUserId], [isActive], [balance], [balanceType], [email], [phone], [mobile], [fax], [address]) VALUES (3, N'Alhafez   ', CAST(1500.000 AS Decimal(20, 3)), CAST(2000.000 AS Decimal(20, 3)), N'com', N'', CAST(N'2021-10-27T17:29:29.9155006' AS DateTime2), CAST(N'2021-12-06T14:42:34.3161676' AS DateTime2), 2, 2, 0, CAST(50400.000 AS Decimal(20, 3)), 0, N'', N'', N'+965-999999999', N'', N'')
SET IDENTITY_INSERT [dbo].[shippingCompanies] OFF
GO
SET IDENTITY_INSERT [dbo].[storageCost] ON 

INSERT [dbo].[storageCost] ([storageCostId], [name], [cost], [note], [isActive], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (1, N'Smal box', CAST(0.000 AS Decimal(20, 3)), N'', 1, 2, 2, CAST(N'2021-10-27T17:38:38.9658043' AS DateTime2), CAST(N'2021-11-20T14:56:31.3418678' AS DateTime2))
INSERT [dbo].[storageCost] ([storageCostId], [name], [cost], [note], [isActive], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (2, N'Medium box', CAST(0.000 AS Decimal(20, 3)), N'', 1, 2, 2, CAST(N'2021-10-27T17:38:48.6324643' AS DateTime2), CAST(N'2021-11-20T15:05:59.9557687' AS DateTime2))
INSERT [dbo].[storageCost] ([storageCostId], [name], [cost], [note], [isActive], [createUserId], [updateUserId], [createDate], [updateDate]) VALUES (3, N'Big box', CAST(0.000 AS Decimal(20, 3)), N'', 1, 2, 2, CAST(N'2021-10-27T17:39:30.6741180' AS DateTime2), CAST(N'2021-11-20T15:05:53.2792939' AS DateTime2))
SET IDENTITY_INSERT [dbo].[storageCost] OFF
GO
SET IDENTITY_INSERT [dbo].[sysEmails] ON 

INSERT [dbo].[sysEmails] ([emailId], [name], [email], [password], [port], [isSSL], [smtpClient], [side], [notes], [branchId], [isActive], [createUserId], [updateUserId], [createDate], [updateDate], [isMajor]) VALUES (1, N'sale', N'wseetw@gmail.com', N'MjE0YTE5NjBh', 587, 1, N'smtp.gmail.com', N'sales', N'', 2, 1, 8, 8, CAST(N'2021-11-23T16:18:14.8685756' AS DateTime2), CAST(N'2021-11-23T16:18:14.8685756' AS DateTime2), 1)
INSERT [dbo].[sysEmails] ([emailId], [name], [email], [password], [port], [isSSL], [smtpClient], [side], [notes], [branchId], [isActive], [createUserId], [updateUserId], [createDate], [updateDate], [isMajor]) VALUES (2, N'purshase', N'wseetw@gmail.com', N'MjE0YTE5NjBh', 587, 1, N'smtp.gmail.com', N'purchase', N'', 2, 1, 8, 8, CAST(N'2021-11-23T16:18:34.6849362' AS DateTime2), CAST(N'2021-11-23T16:18:34.6849362' AS DateTime2), 1)
INSERT [dbo].[sysEmails] ([emailId], [name], [email], [password], [port], [isSSL], [smtpClient], [side], [notes], [branchId], [isActive], [createUserId], [updateUserId], [createDate], [updateDate], [isMajor]) VALUES (3, N'accountant', N'wseetw@gmail.com', N'MjE0YTE5NjBh', 587, 1, N'smtp.gmail.com', N'accounting', N'', 2, 1, 8, 8, CAST(N'2021-11-23T16:19:03.1893826' AS DateTime2), CAST(N'2021-11-23T16:19:03.1893826' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[sysEmails] OFF
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

INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (1, N'admin', N'1b8baf4f819e5b304e1a176e1c590c84', N'Mohammad', N'Nasani', N'System Admin', N'12', CAST(N'2021-06-28T18:38:45.0434248' AS DateTime2), CAST(N'2021-12-06T15:08:42.1524222' AS DateTime2), 2, 2, N'+963-21-2278910', N'+963-966376308', N'mohamadnasani@gmail.com', N'Halab', 1, N'', 1, N'', N'57440ff6b80f068efd50410ea24fd593.jpg', NULL, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (2, N'yasin', N'1b8baf4f819e5b304e1a176e1c590c84', N'ياسين', N'ادلبي', N'محاسب', N'8', CAST(N'2021-06-30T11:05:51.9137655' AS DateTime2), CAST(N'2021-12-05T17:56:55.9031269' AS DateTime2), 1, 1, N'+971-6-888888888888888', N'+963-966376308', N'', N'', 1, N'', 1, N'', N'c37858823db0093766eee74d8ee1f1e5.png', 10, CAST(0.000 AS Decimal(20, 3)), 0, 1)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (3, N'yasmine', N'4cdf921bfe31b594a0cc9cc555292f02', N'ياسمين', N'النجار', N'مبيعات', N'', CAST(N'2021-10-27T14:42:09.1827217' AS DateTime2), CAST(N'2021-12-06T15:08:31.1837000' AS DateTime2), 2, 1, N'', N'+965-333333333', N'', N'', 1, N'', 1, N'', NULL, 10, CAST(0.000 AS Decimal(20, 3)), 0, 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (4, N'olwani', N'7ae94a254e28a0e9a575e9669fed5684', N'محمد', N'علواني', N'مبيعات', N'', CAST(N'2021-10-27T14:43:04.2619224' AS DateTime2), CAST(N'2021-11-29T16:01:39.8279348' AS DateTime2), 2, 1, N'', N'+965-444444444', N'', N'', 0, N'', NULL, N'', NULL, 10, CAST(0.000 AS Decimal(20, 3)), 0, 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (5, N'amna', N'78fe84643f9a617ac5800771a1c3c5e9', N'آمنة', N'سعدات', N'مبيعات', N'', CAST(N'2021-10-27T14:44:02.9404452' AS DateTime2), CAST(N'2021-11-29T16:01:39.8375861' AS DateTime2), 2, 1, N'', N'+965-555555555', N'', N'', 1, N'', NULL, N'', NULL, 10, CAST(0.000 AS Decimal(20, 3)), 0, 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (6, N'basmah', N'210db3affbee2bdeb82872a7f42a970f', N'باسمة', N'قدري', N'مبيعات', N'', CAST(N'2021-10-27T14:44:25.9150776' AS DateTime2), CAST(N'2021-11-29T16:01:39.8495361' AS DateTime2), 2, 1, N'', N'+965-555555555', N'', N'', 0, N'', NULL, N'', NULL, 10, CAST(0.000 AS Decimal(20, 3)), 0, 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (7, N'bik', N'e2a603fb361ecb7b2fc6791f98382580', N'محمد', N'بيك', N'محاسب', N'', CAST(N'2021-10-27T14:45:00.4174486' AS DateTime2), CAST(N'2021-11-29T16:01:39.8592258' AS DateTime2), 2, 1, N'', N'+965-555555555', N'', N'', 1, N'', NULL, N'', NULL, 10, CAST(0.000 AS Decimal(20, 3)), 0, 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (8, N'naji', N'741e82719da67d8744fd797194aa65b0', N'ناجي', N'مصري', N'مدير', N'', CAST(N'2021-10-27T14:45:48.1895157' AS DateTime2), CAST(N'2021-12-02T19:16:04.1855253' AS DateTime2), 2, 1, N'', N'+965-555555555', N'', N'', 1, N'', 1, N'', NULL, 10, CAST(0.000 AS Decimal(20, 3)), 0, 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (9, N'aya', N'b697f68966fb214868346e83867897ab', N'آية', N'سليمان', N'مدير', N'', CAST(N'2021-10-27T14:46:33.0756936' AS DateTime2), CAST(N'2021-11-30T13:29:15.5783658' AS DateTime2), 2, 1, N'', N'+965-555555555', N'', N'', 1, N'', 1, N'', N'6eaba1dc3c031faf262149c058fea728.png', 10, CAST(0.000 AS Decimal(20, 3)), 0, 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (10, N'dina', N'513866157bae565e9e3bc02a1ca05e9d', N'دينا', N'نعمة', N'مدير', N'', CAST(N'2021-10-27T14:47:05.9472995' AS DateTime2), CAST(N'2021-11-29T16:01:39.8934690' AS DateTime2), 2, 1, N'', N'+965-555555555', N'', N'', 1, N'', 1, N'', NULL, 10, CAST(0.000 AS Decimal(20, 3)), 0, 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (11, N'saeed', N'1e920a928a6be4ea6fa634e7fa3f048b', N'سعيد', N'قطان', N'امين مستودع', N'', CAST(N'2021-10-27T14:47:40.1604865' AS DateTime2), CAST(N'2021-11-29T16:01:39.9040452' AS DateTime2), 2, 1, N'', N'+965-555555555', N'', N'', 1, N'', 1, N'', NULL, 10, CAST(0.000 AS Decimal(20, 3)), 0, 0)
INSERT [dbo].[users] ([userId], [username], [password], [name], [lastname], [job], [workHours], [createDate], [updateDate], [createUserId], [updateUserId], [phone], [mobile], [email], [address], [isActive], [notes], [isOnline], [role], [image], [groupId], [balance], [balanceType], [isAdmin]) VALUES (12, N'naser', N'9b43a5e653134fc8350ca9944eadaf2f', N'naser', N'naser', N'محاسب', N'', CAST(N'2021-11-29T15:05:38.4109368' AS DateTime2), CAST(N'2021-11-29T16:13:50.7378546' AS DateTime2), 8, 1, N'', N'+965-546464969', N'', N'', 1, N'', 1, N'', NULL, 10, CAST(0.000 AS Decimal(20, 3)), 0, 0)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
SET IDENTITY_INSERT [dbo].[userSetValues] ON 

INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (1, 2, 79, NULL, CAST(N'2021-10-27T14:28:55.8898071' AS DateTime2), CAST(N'2021-12-05T17:58:00.5912334' AS DateTime2), 2, 2)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (2, 9, 79, NULL, CAST(N'2021-10-28T15:12:32.1580746' AS DateTime2), CAST(N'2021-11-29T15:10:32.0641310' AS DateTime2), 9, 9)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (3, 3, 79, NULL, CAST(N'2021-10-28T16:03:07.7428897' AS DateTime2), CAST(N'2021-12-06T15:08:49.2118426' AS DateTime2), 3, 3)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (4, 8, 79, NULL, CAST(N'2021-10-28T16:37:55.7794863' AS DateTime2), CAST(N'2021-12-02T19:16:56.4363650' AS DateTime2), 8, 8)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (5, 1, 79, NULL, CAST(N'2021-10-30T00:18:59.7277029' AS DateTime2), CAST(N'2021-12-05T18:32:30.4075572' AS DateTime2), 1, 1)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (6, 9, 1, NULL, CAST(N'2021-10-30T18:44:01.7183026' AS DateTime2), CAST(N'2021-10-30T18:44:01.7183026' AS DateTime2), 9, 9)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (7, 9, 2, NULL, CAST(N'2021-10-30T18:44:05.9523822' AS DateTime2), CAST(N'2021-11-23T16:00:51.6577076' AS DateTime2), 9, 9)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (8, 10, 79, NULL, CAST(N'2021-11-02T01:29:30.1271074' AS DateTime2), CAST(N'2021-11-25T11:53:47.4897916' AS DateTime2), 10, 10)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (9, 8, 2, NULL, CAST(N'2021-11-08T20:05:00.1446069' AS DateTime2), CAST(N'2021-11-08T20:05:00.1446069' AS DateTime2), 8, 8)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (10, 8, 1, NULL, CAST(N'2021-11-08T20:05:08.2696282' AS DateTime2), CAST(N'2021-11-08T20:05:08.2696282' AS DateTime2), 8, 8)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (11, 8, 2, NULL, CAST(N'2021-11-08T20:05:18.3318505' AS DateTime2), CAST(N'2021-11-08T20:05:18.3318505' AS DateTime2), 8, 8)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (12, 8, 1, NULL, CAST(N'2021-11-08T20:05:23.8791564' AS DateTime2), CAST(N'2021-11-08T20:05:23.8791564' AS DateTime2), 8, 8)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (13, 1, 87, NULL, CAST(N'2021-11-10T12:55:53.5597905' AS DateTime2), CAST(N'2021-11-10T12:55:53.5597905' AS DateTime2), 1, 1)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (14, 1, 87, NULL, CAST(N'2021-11-10T12:55:58.7236183' AS DateTime2), CAST(N'2021-11-10T12:55:58.7236183' AS DateTime2), 1, 1)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (15, 1, 87, NULL, CAST(N'2021-11-10T12:56:08.8771770' AS DateTime2), CAST(N'2021-11-10T12:56:08.8771770' AS DateTime2), 1, 1)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (16, 1, 1, NULL, CAST(N'2021-11-10T13:55:31.0878535' AS DateTime2), CAST(N'2021-11-13T17:03:58.4931514' AS DateTime2), 1, 1)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (17, 1, 84, N'sales', CAST(N'2021-11-11T13:51:32.5082163' AS DateTime2), CAST(N'2021-11-11T13:51:32.5082163' AS DateTime2), 1, 1)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (18, 1, 85, N'reciptInvoice', CAST(N'2021-11-11T13:51:33.1966027' AS DateTime2), CAST(N'2021-11-11T13:51:33.1966027' AS DateTime2), 1, 1)
INSERT [dbo].[userSetValues] ([id], [userId], [valId], [note], [createDate], [updateDate], [createUserId], [updateUserId]) VALUES (19, 12, 79, NULL, CAST(N'2021-11-29T16:03:57.7834472' AS DateTime2), CAST(N'2021-11-29T16:14:20.5188050' AS DateTime2), 12, 12)
SET IDENTITY_INSERT [dbo].[userSetValues] OFF
GO
SET IDENTITY_INSERT [dbo].[usersLogs] ON 

INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2111, CAST(N'2021-11-30T18:47:26.3105283' AS DateTime2), CAST(N'2021-11-30T18:48:10.8730199' AS DateTime2), 1, 8)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2112, CAST(N'2021-11-30T18:51:22.4666721' AS DateTime2), CAST(N'2021-11-30T19:23:50.5517180' AS DateTime2), 1, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2113, CAST(N'2021-11-30T19:25:15.7705950' AS DateTime2), CAST(N'2021-11-30T19:27:40.4423380' AS DateTime2), 1, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2114, CAST(N'2021-11-30T19:34:51.7176224' AS DateTime2), CAST(N'2021-11-30T19:36:27.3279358' AS DateTime2), 1, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2115, CAST(N'2021-12-01T13:28:11.6362184' AS DateTime2), CAST(N'2021-12-01T13:28:51.9837372' AS DateTime2), 1, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2116, CAST(N'2021-12-01T13:46:49.2291535' AS DateTime2), CAST(N'2021-12-01T14:00:42.8891676' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2117, CAST(N'2021-12-01T14:00:45.5562246' AS DateTime2), CAST(N'2021-12-01T14:03:17.7058168' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2118, CAST(N'2021-12-01T14:06:05.4143780' AS DateTime2), CAST(N'2021-12-01T14:10:18.3289345' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2119, CAST(N'2021-12-01T14:11:40.2988273' AS DateTime2), CAST(N'2021-12-01T14:27:27.0060533' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2120, CAST(N'2021-12-01T14:13:25.9474279' AS DateTime2), CAST(N'2021-12-01T14:18:50.8967480' AS DateTime2), 1, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2121, CAST(N'2021-12-01T14:18:53.3037335' AS DateTime2), CAST(N'2021-12-01T14:19:20.9370975' AS DateTime2), 1, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2122, CAST(N'2021-12-01T14:24:21.1609435' AS DateTime2), CAST(N'2021-12-01T14:30:37.5506340' AS DateTime2), 1, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2123, CAST(N'2021-12-01T14:27:31.0646679' AS DateTime2), CAST(N'2021-12-01T14:50:58.9518936' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2124, CAST(N'2021-12-01T14:30:34.8565542' AS DateTime2), CAST(N'2021-12-01T14:36:19.2452279' AS DateTime2), 1, 8)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2125, CAST(N'2021-12-01T14:51:00.8266779' AS DateTime2), CAST(N'2021-12-01T14:52:56.3943932' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2126, CAST(N'2021-12-01T14:52:02.2123129' AS DateTime2), CAST(N'2021-12-01T15:09:14.6686130' AS DateTime2), 1, 8)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2127, CAST(N'2021-12-01T14:53:51.4972178' AS DateTime2), CAST(N'2021-12-01T15:01:38.3003347' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2128, CAST(N'2021-12-01T15:01:40.2622791' AS DateTime2), CAST(N'2021-12-01T15:02:15.1831779' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2129, CAST(N'2021-12-01T15:05:34.9803185' AS DateTime2), CAST(N'2021-12-01T15:10:59.1917794' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2130, CAST(N'2021-12-01T15:09:17.8189288' AS DateTime2), CAST(N'2021-12-01T15:29:55.7677510' AS DateTime2), 1, 8)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2131, CAST(N'2021-12-01T15:11:01.2257959' AS DateTime2), CAST(N'2021-12-01T15:25:12.8891673' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2132, CAST(N'2021-12-01T15:25:17.8039508' AS DateTime2), CAST(N'2021-12-01T15:26:29.1545955' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2133, CAST(N'2021-12-01T15:43:03.6183158' AS DateTime2), CAST(N'2021-12-01T15:48:31.0816979' AS DateTime2), 1, 8)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2134, CAST(N'2021-12-01T15:58:07.7991002' AS DateTime2), CAST(N'2021-12-01T16:14:34.4914946' AS DateTime2), 1, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2135, CAST(N'2021-12-01T18:21:25.4275893' AS DateTime2), CAST(N'2021-12-01T18:36:51.7045296' AS DateTime2), 1, 8)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2136, CAST(N'2021-12-01T19:11:30.7870641' AS DateTime2), CAST(N'2021-12-01T19:12:10.0516772' AS DateTime2), 1, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2137, CAST(N'2021-12-01T19:21:47.1429017' AS DateTime2), CAST(N'2021-12-01T19:24:14.0676439' AS DateTime2), 1, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2138, CAST(N'2021-12-01T19:21:58.1550620' AS DateTime2), CAST(N'2021-12-01T19:22:48.3277468' AS DateTime2), 1, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2139, CAST(N'2021-12-02T11:13:48.1680049' AS DateTime2), CAST(N'2021-12-02T11:17:43.5663473' AS DateTime2), 1, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2140, CAST(N'2021-12-02T13:07:40.7962343' AS DateTime2), CAST(N'2021-12-02T13:12:42.9079322' AS DateTime2), 1, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2141, CAST(N'2021-12-02T13:48:15.7779707' AS DateTime2), CAST(N'2021-12-02T13:49:01.1487644' AS DateTime2), 1, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2142, CAST(N'2021-12-02T16:03:41.2741778' AS DateTime2), CAST(N'2021-12-02T16:04:17.3291701' AS DateTime2), 1, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2143, CAST(N'2021-12-02T16:08:41.7121392' AS DateTime2), CAST(N'2021-12-02T17:48:44.2938474' AS DateTime2), 1, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2144, CAST(N'2021-12-02T16:13:06.3853477' AS DateTime2), CAST(N'2021-12-02T16:14:35.5293308' AS DateTime2), 1, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2145, CAST(N'2021-12-02T16:40:53.6209293' AS DateTime2), CAST(N'2021-12-02T16:50:31.9229723' AS DateTime2), 1, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2146, CAST(N'2021-12-02T18:18:35.3343659' AS DateTime2), CAST(N'2021-12-02T18:19:03.0531075' AS DateTime2), 1, 8)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2147, CAST(N'2021-12-02T19:00:22.2718086' AS DateTime2), CAST(N'2021-12-02T19:02:49.0684550' AS DateTime2), 1, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2148, CAST(N'2021-12-02T19:10:07.3677632' AS DateTime2), CAST(N'2021-12-02T19:12:26.8684533' AS DateTime2), 1, 8)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2149, CAST(N'2021-12-02T19:16:05.6857710' AS DateTime2), CAST(N'2021-12-05T17:56:33.5275347' AS DateTime2), 1, 8)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2150, CAST(N'2021-12-05T17:56:33.4341978' AS DateTime2), CAST(N'2021-12-05T18:06:36.2356381' AS DateTime2), 1, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2151, CAST(N'2021-12-05T17:56:57.9655122' AS DateTime2), CAST(N'2021-12-05T17:58:07.8414890' AS DateTime2), 1, 2)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2152, CAST(N'2021-12-05T18:29:13.1396782' AS DateTime2), CAST(N'2021-12-05T18:32:34.4389516' AS DateTime2), 1, 1)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2153, CAST(N'2021-12-06T12:29:28.3327421' AS DateTime2), CAST(N'2021-12-06T12:34:10.1793997' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2154, CAST(N'2021-12-06T12:57:03.3191003' AS DateTime2), CAST(N'2021-12-06T13:02:56.7602493' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2155, CAST(N'2021-12-06T13:07:32.8882488' AS DateTime2), CAST(N'2021-12-06T13:09:40.1712558' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2156, CAST(N'2021-12-06T13:10:20.2966212' AS DateTime2), CAST(N'2021-12-06T13:10:52.3435658' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2157, CAST(N'2021-12-06T13:12:24.5634664' AS DateTime2), CAST(N'2021-12-06T13:12:46.6104168' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2158, CAST(N'2021-12-06T13:14:22.0802785' AS DateTime2), CAST(N'2021-12-06T13:17:04.6600174' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2159, CAST(N'2021-12-06T13:19:44.6460294' AS DateTime2), CAST(N'2021-12-06T13:23:13.2734946' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2160, CAST(N'2021-12-06T13:23:15.7111963' AS DateTime2), CAST(N'2021-12-06T13:26:56.9324602' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2161, CAST(N'2021-12-06T13:32:08.9827734' AS DateTime2), CAST(N'2021-12-06T13:32:55.1390716' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2162, CAST(N'2021-12-06T13:35:53.6566175' AS DateTime2), CAST(N'2021-12-06T13:41:32.8477278' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2163, CAST(N'2021-12-06T13:43:14.0364575' AS DateTime2), CAST(N'2021-12-06T13:43:53.7868065' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2164, CAST(N'2021-12-06T13:48:14.3050955' AS DateTime2), CAST(N'2021-12-06T13:51:05.5101537' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2165, CAST(N'2021-12-06T13:51:09.6509923' AS DateTime2), CAST(N'2021-12-06T13:53:19.2301359' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2166, CAST(N'2021-12-06T13:54:34.7469588' AS DateTime2), CAST(N'2021-12-06T13:55:18.9347355' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2167, CAST(N'2021-12-06T13:56:03.1987782' AS DateTime2), CAST(N'2021-12-06T14:06:08.7277165' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2168, CAST(N'2021-12-06T14:06:10.8476068' AS DateTime2), CAST(N'2021-12-06T14:29:47.1575137' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2169, CAST(N'2021-12-06T14:29:49.2845625' AS DateTime2), CAST(N'2021-12-06T14:31:07.5715978' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2170, CAST(N'2021-12-06T14:32:30.4093521' AS DateTime2), CAST(N'2021-12-06T14:33:13.3498256' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2171, CAST(N'2021-12-06T14:35:22.0940581' AS DateTime2), CAST(N'2021-12-06T14:36:26.3515366' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2172, CAST(N'2021-12-06T14:40:36.7999087' AS DateTime2), CAST(N'2021-12-06T14:42:45.3809535' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2173, CAST(N'2021-12-06T14:44:55.6639208' AS DateTime2), CAST(N'2021-12-06T14:45:35.6296763' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2174, CAST(N'2021-12-06T14:48:12.3565948' AS DateTime2), CAST(N'2021-12-06T14:49:15.5298814' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2175, CAST(N'2021-12-06T14:50:11.8837687' AS DateTime2), CAST(N'2021-12-06T14:51:25.6226455' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2176, CAST(N'2021-12-06T14:51:58.1313086' AS DateTime2), CAST(N'2021-12-06T15:02:54.0483283' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2177, CAST(N'2021-12-06T15:02:55.9896145' AS DateTime2), CAST(N'2021-12-06T15:03:43.0847775' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2178, CAST(N'2021-12-06T15:05:49.3944507' AS DateTime2), CAST(N'2021-12-06T15:07:26.9465191' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2179, CAST(N'2021-12-06T15:07:28.9583636' AS DateTime2), CAST(N'2021-12-06T15:07:51.6424598' AS DateTime2), 1, 3)
INSERT [dbo].[usersLogs] ([logId], [sInDate], [sOutDate], [posId], [userId]) VALUES (2180, CAST(N'2021-12-06T15:08:32.8015453' AS DateTime2), NULL, 1, 3)
SET IDENTITY_INSERT [dbo].[usersLogs] OFF
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
