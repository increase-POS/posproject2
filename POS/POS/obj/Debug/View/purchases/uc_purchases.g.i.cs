﻿#pragma checksum "..\..\..\..\View\purchases\uc_purchases.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "01CF6D058B3B9587EB52401BD9FC04DBF8F48F868D8EB5697C07AF4DBE7E66BC"
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
    /// uc_purchases
    /// </summary>
    public partial class uc_purchases : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\View\purchases\uc_purchases.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_ucPurchases;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\View\purchases\uc_purchases.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_payInvoice;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\View\purchases\uc_purchases.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_statistic;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\View\purchases\uc_purchases.xaml"
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
            System.Uri resourceLocater = new System.Uri("/POS;component/view/purchases/uc_purchases.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\purchases\uc_purchases.xaml"
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
            
            #line 10 "..\..\..\..\View\purchases\uc_purchases.xaml"
            ((POS.View.uc_purchases)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_ucPurchases = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            
            #line 16 "..\..\..\..\View\purchases\uc_purchases.xaml"
            ((System.Windows.Controls.Expander)(target)).Expanded += new System.Windows.RoutedEventHandler(this.Expander_Expanded);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_payInvoice = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\View\purchases\uc_purchases.xaml"
            this.btn_payInvoice.Click += new System.Windows.RoutedEventHandler(this.btn_payInvoice_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_statistic = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\View\purchases\uc_purchases.xaml"
            this.btn_statistic.Click += new System.Windows.RoutedEventHandler(this.Btn_statistic_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.grid_main = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

