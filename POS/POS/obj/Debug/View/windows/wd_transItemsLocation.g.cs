﻿#pragma checksum "..\..\..\..\View\windows\wd_transItemsLocation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1B94F25DC95FA98ABFD244FB46D81B5C78222023F917F5FF559B173A1940F00B"
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
    /// wd_transItemsLocation
    /// </summary>
    public partial class wd_transItemsLocation : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 24 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_colse;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_title;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_mainGrid;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_itemsStorage;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_save;
        
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
            System.Uri resourceLocater = new System.Uri("/POS;component/view/windows/wd_transitemslocation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
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
            
            #line 7 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
            ((POS.View.windows.wd_transItemsLocation)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.HandleKeyPress);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
            ((POS.View.windows.wd_transItemsLocation)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
            ((POS.View.windows.wd_transItemsLocation)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_colse = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
            this.btn_colse.Click += new System.Windows.RoutedEventHandler(this.Btn_colse_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.grid_mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.dg_itemsStorage = ((System.Windows.Controls.DataGrid)(target));
            
            #line 66 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
            this.dg_itemsStorage.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Dg_itemsStorage_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 67 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
            this.dg_itemsStorage.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.Dg_itemsStorage_CellEditEnding);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_save = ((System.Windows.Controls.Button)(target));
            
            #line 158 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
            this.btn_save.Click += new System.Windows.RoutedEventHandler(this.Btn_save_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 6:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Primitives.ToggleButton.CheckedEvent;
            
            #line 84 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.FieldDataGridChecked);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Primitives.ToggleButton.UncheckedEvent;
            
            #line 87 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.FieldDataGridUnchecked);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 7:
            
            #line 92 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.FieldDataGridChecked);
            
            #line default
            #line hidden
            
            #line 92 "..\..\..\..\View\windows\wd_transItemsLocation.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.FieldDataGridUnchecked);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

