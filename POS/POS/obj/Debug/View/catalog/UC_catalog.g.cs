﻿#pragma checksum "..\..\..\..\View\catalog\UC_catalog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FDE5CB253FCAB3462A930DD4507F687524471E4894E0CEBA158BDAF786329378"
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
    /// UC_catalog
    /// </summary>
    public partial class UC_catalog : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\View\catalog\UC_catalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_ucCatalog;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\View\catalog\UC_catalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_categories;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\View\catalog\UC_catalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_item;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\View\catalog\UC_catalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_properties;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\..\View\catalog\UC_catalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_units;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\..\View\catalog\UC_catalog.xaml"
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
            System.Uri resourceLocater = new System.Uri("/POS;component/view/catalog/uc_catalog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\catalog\UC_catalog.xaml"
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
            
            #line 11 "..\..\..\..\View\catalog\UC_catalog.xaml"
            ((POS.View.UC_catalog)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_ucCatalog = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.btn_categories = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\View\catalog\UC_catalog.xaml"
            this.btn_categories.Click += new System.Windows.RoutedEventHandler(this.Btn_categorie_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_item = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\View\catalog\UC_catalog.xaml"
            this.btn_item.Click += new System.Windows.RoutedEventHandler(this.BTN_item_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_properties = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\..\View\catalog\UC_catalog.xaml"
            this.btn_properties.Click += new System.Windows.RoutedEventHandler(this.Btn_properties_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_units = ((System.Windows.Controls.Button)(target));
            
            #line 192 "..\..\..\..\View\catalog\UC_catalog.xaml"
            this.btn_units.Click += new System.Windows.RoutedEventHandler(this.Btn_units_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.grid_main = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

