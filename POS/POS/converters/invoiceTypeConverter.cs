﻿using POS.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace POS.converters
{
     
    public class invoiceTypeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                //مشتريات 
                case "p":  value = MainWindow.resourcemanager.GetString("trPurchaseInvoice");
                    break;
                //فاتورة مشتريات بانتظار الادخال
                case "pw":
                    value = MainWindow.resourcemanager.GetString("trPurchaseInvoiceWaiting");
                    break;
                //مبيعات
                case "s": value = MainWindow.resourcemanager.GetString("trSalesInvoice");
                    break;
                //مرتجع مبيعات
                case "sb": value = MainWindow.resourcemanager.GetString("trSalesReturnInvoice");
                    break;
                //مرتجع مشتريات
                case "pb": value = MainWindow.resourcemanager.GetString("trPurchaseReturnInvoice");
                    break;
                //فاتورة مرتجع مشتريات بانتظار الاخراج
                case "pbw":
                    value = MainWindow.resourcemanager.GetString("trPurchaseReturnInvoiceWaiting");
                    break;
                //مسودة مشتريات 
                case "pd": value = MainWindow.resourcemanager.GetString("trDraftPurchaseBill");
                    break;
                //مسودة مبيعات
                case "sd": value = MainWindow.resourcemanager.GetString("trSalesDraft");
                    break;
                //مسودة مرتجع مبيعات
                case "sbd": value = MainWindow.resourcemanager.GetString("trSalesReturnDraft");
                    break;
                //مسودة مرتجع مشتريات
                case "pbd": value = MainWindow.resourcemanager.GetString("trPurchaseReturnDraft");
                    break;
                // مسودة طلبية مبيعات 
                case "ord":
                    value = MainWindow.resourcemanager.GetString("trSaleOrderDraft");
                    break;
                //   طلبية مبيعات 
                case "or":
                    value = MainWindow.resourcemanager.GetString("trSaleOrder");
                    break;
                // مسودة طلبية شراء 
                case "pod":
                    value = MainWindow.resourcemanager.GetString("trPurchaceOrderDraft");
                    break;
                // طلبية شراء 
                case "po":
                    value = MainWindow.resourcemanager.GetString("trPurchaceOrder");
                    break;
                //مسودة عرض 
                case "qd":
                    value = MainWindow.resourcemanager.GetString("trQuotationsDraft");
                    break;
                //فاتورة عرض اسعار
                case "q":
                    value = MainWindow.resourcemanager.GetString("trQuotations");
                    break;
                //الإتلاف
                case "d":
                    value = MainWindow.resourcemanager.GetString("trDestructive");
                    break;
                //النواقص
                case "sh":
                    value = MainWindow.resourcemanager.GetString("trShortage");
                    break;
                default: break;
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
   

}
