﻿#pragma checksum "..\..\..\..\View\windows\wd_invoice.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0E8684B7C16F554541AB195A25817A0425B908282BD7426B2A45D2BC61B4AEE9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using POS.View.windows;
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


namespace POS.View.windows {
    
    
    /// <summary>
    /// wd_invoice
    /// </summary>
    public partial class wd_invoice : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\View\windows\wd_invoice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_ucInvoice;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\View\windows\wd_invoice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_colse;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\View\windows\wd_invoice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_Invoices;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\View\windows\wd_invoice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_search;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\View\windows\wd_invoice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_Invoice;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\..\View\windows\wd_invoice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_select;
        
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
            System.Uri resourceLocater = new System.Uri("/POS;component/view/windows/wd_invoice.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\windows\wd_invoice.xaml"
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
            
            #line 12 "..\..\..\..\View\windows\wd_invoice.xaml"
            ((POS.View.windows.wd_invoice)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_ucInvoice = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.btn_colse = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\View\windows\wd_invoice.xaml"
            this.btn_colse.Click += new System.Windows.RoutedEventHandler(this.Btn_colse_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_Invoices = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txb_search = ((System.Windows.Controls.TextBox)(target));
            
            #line 96 "..\..\..\..\View\windows\wd_invoice.xaml"
            this.txb_search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Txb_search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dg_Invoice = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.btn_select = ((System.Windows.Controls.Button)(target));
            
            #line 135 "..\..\..\..\View\windows\wd_invoice.xaml"
            this.btn_select.Click += new System.Windows.RoutedEventHandler(this.Btn_select_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

