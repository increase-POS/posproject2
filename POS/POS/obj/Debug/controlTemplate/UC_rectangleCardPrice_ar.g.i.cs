﻿#pragma checksum "..\..\..\controlTemplate\UC_rectangleCardPrice_ar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1003FF55131C0449F9AACDBBBD08A3376E3CE5FE7C4FF06865A5DEA834AB44CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using POS.controlTemplate;
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


namespace POS.controlTemplate {
    
    
    /// <summary>
    /// UC_rectangleCardPrice_ar
    /// </summary>
    public partial class UC_rectangleCardPrice_ar : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\controlTemplate\UC_rectangleCardPrice_ar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.BeginStoryboard Storyboard1_BeginStoryboard;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\controlTemplate\UC_rectangleCardPrice_ar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path path_new;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\controlTemplate\UC_rectangleCardPrice_ar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rectangle;
        
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
            System.Uri resourceLocater = new System.Uri("/POS;component/controltemplate/uc_rectanglecardprice_ar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\controlTemplate\UC_rectangleCardPrice_ar.xaml"
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
            
            #line 9 "..\..\..\controlTemplate\UC_rectangleCardPrice_ar.xaml"
            ((POS.controlTemplate.UC_rectangleCardPrice_ar)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Storyboard1_BeginStoryboard = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 3:
            this.path_new = ((System.Windows.Shapes.Path)(target));
            return;
            case 4:
            this.rectangle = ((System.Windows.Shapes.Rectangle)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

