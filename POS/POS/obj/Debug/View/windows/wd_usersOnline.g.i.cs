﻿#pragma checksum "..\..\..\..\View\windows\wd_usersOnline.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B9740232B06D65EC445B91F6D4B15CA50580A38DF26C0EC029F2F2EA9BEE9F9A"
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
    /// wd_usersOnline
    /// </summary>
    public partial class wd_usersOnline : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\View\windows\wd_usersOnline.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_main;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\View\windows\wd_usersOnline.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_colse;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\View\windows\wd_usersOnline.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_title;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\View\windows\wd_usersOnline.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_mainGrid;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\View\windows\wd_usersOnline.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_usersOnline;
        
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
            System.Uri resourceLocater = new System.Uri("/POS;component/view/windows/wd_usersonline.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\windows\wd_usersOnline.xaml"
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
            
            #line 7 "..\..\..\..\View\windows\wd_usersOnline.xaml"
            ((POS.View.windows.wd_usersOnline)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.HandleKeyPress);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\..\View\windows\wd_usersOnline.xaml"
            ((POS.View.windows.wd_usersOnline)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\..\View\windows\wd_usersOnline.xaml"
            ((POS.View.windows.wd_usersOnline)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_main = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.btn_colse = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\View\windows\wd_usersOnline.xaml"
            this.btn_colse.Click += new System.Windows.RoutedEventHandler(this.Btn_colse_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.grid_mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.dg_usersOnline = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

