#pragma checksum "..\..\..\..\View\windows\wd_notes.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A125B8E7827DABA1AEF0AF67679230D6E2199226D3F9D35707C20790F9AEF27F"
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
    /// wd_notes
    /// </summary>
    public partial class wd_notes : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\View\windows\wd_notes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_main;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\windows\wd_notes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_colse;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\View\windows\wd_notes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_title;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\View\windows\wd_notes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_notes;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\View\windows\wd_notes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolTip tt_notes;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\View\windows\wd_notes.xaml"
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
            System.Uri resourceLocater = new System.Uri("/POS;component/view/windows/wd_notes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\windows\wd_notes.xaml"
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
            
            #line 7 "..\..\..\..\View\windows\wd_notes.xaml"
            ((POS.View.windows.wd_notes)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.HandleKeyPress);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\View\windows\wd_notes.xaml"
            ((POS.View.windows.wd_notes)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\..\View\windows\wd_notes.xaml"
            ((POS.View.windows.wd_notes)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\..\View\windows\wd_notes.xaml"
            ((POS.View.windows.wd_notes)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_main = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.btn_colse = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\View\windows\wd_notes.xaml"
            this.btn_colse.Click += new System.Windows.RoutedEventHandler(this.Btn_colse_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.tb_notes = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tt_notes = ((System.Windows.Controls.ToolTip)(target));
            return;
            case 7:
            this.btn_save = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\..\..\View\windows\wd_notes.xaml"
            this.btn_save.Click += new System.Windows.RoutedEventHandler(this.Btn_save_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

