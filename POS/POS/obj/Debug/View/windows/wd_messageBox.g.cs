﻿#pragma checksum "..\..\..\..\View\windows\wd_messageBox.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "24F4B549FD5DFA08B02185D9624157940E77175F935B617E5C78890B56EDCD7C"
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
    /// wd_messageBox
    /// </summary>
    public partial class wd_messageBox : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\View\windows\wd_messageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_main;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\View\windows\wd_messageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_title;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\View\windows\wd_messageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_colse;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\View\windows\wd_messageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_mainGrid;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\View\windows\wd_messageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_ok;
        
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
            System.Uri resourceLocater = new System.Uri("/POS;component/view/windows/wd_messagebox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\windows\wd_messageBox.xaml"
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
            
            #line 7 "..\..\..\..\View\windows\wd_messageBox.xaml"
            ((POS.View.windows.wd_messageBox)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.HandleKeyPress);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\View\windows\wd_messageBox.xaml"
            ((POS.View.windows.wd_messageBox)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\View\windows\wd_messageBox.xaml"
            ((POS.View.windows.wd_messageBox)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_main = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.txt_title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.btn_colse = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\View\windows\wd_messageBox.xaml"
            this.btn_colse.Click += new System.Windows.RoutedEventHandler(this.Btn_colse_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.grid_mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.btn_ok = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\View\windows\wd_messageBox.xaml"
            this.btn_ok.Click += new System.Windows.RoutedEventHandler(this.Btn_colse_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

