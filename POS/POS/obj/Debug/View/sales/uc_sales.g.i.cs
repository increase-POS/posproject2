﻿#pragma checksum "..\..\..\..\View\sales\uc_sales.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9C6DBCDC2E98492FB5B9F8B3F59C8C37C07E018236632D2106C73392D57A7491"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using POS.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace POS.View {
    
    
    /// <summary>
    /// uc_sales
    /// </summary>
    public partial class uc_sales : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\View\sales\uc_sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_ucSales;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\sales\uc_sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_receiptInvoice;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\View\sales\uc_sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_statistic;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\View\sales\uc_sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_coupon;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\View\sales\uc_sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_offer;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\View\sales\uc_sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_package;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\..\View\sales\uc_sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_quotations;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\..\..\View\sales\uc_sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_membershipCard;
        
        #line default
        #line hidden
        
        
        #line 207 "..\..\..\..\View\sales\uc_sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_main;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/POS;component/view/sales/uc_sales.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\sales\uc_sales.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\View\sales\uc_sales.xaml"
            ((POS.View.uc_sales)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_ucSales = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.btn_receiptInvoice = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\View\sales\uc_sales.xaml"
            this.btn_receiptInvoice.Click += new System.Windows.RoutedEventHandler(this.Btn_receiptInvoice_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_statistic = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\View\sales\uc_sales.xaml"
            this.btn_statistic.Click += new System.Windows.RoutedEventHandler(this.Btn_statistic_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_coupon = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\..\View\sales\uc_sales.xaml"
            this.btn_coupon.Click += new System.Windows.RoutedEventHandler(this.Btn_coupon_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_offer = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\..\View\sales\uc_sales.xaml"
            this.btn_offer.Click += new System.Windows.RoutedEventHandler(this.Btn_offer_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_package = ((System.Windows.Controls.Button)(target));
            
            #line 138 "..\..\..\..\View\sales\uc_sales.xaml"
            this.btn_package.Click += new System.Windows.RoutedEventHandler(this.Btn_package_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_quotations = ((System.Windows.Controls.Button)(target));
            
            #line 169 "..\..\..\..\View\sales\uc_sales.xaml"
            this.btn_quotations.Click += new System.Windows.RoutedEventHandler(this.Btn_quotations_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_membershipCard = ((System.Windows.Controls.Button)(target));
            
            #line 197 "..\..\..\..\View\sales\uc_sales.xaml"
            this.btn_membershipCard.Click += new System.Windows.RoutedEventHandler(this.Btn_membershipCard_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.grid_main = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

