#pragma checksum "..\..\..\View\uc_storage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E9FB7B331A58D4755E725CF98F4E42D4525DB98ECEBFC9F5D898631568FAA4C9"
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
    /// uc_storage
    /// </summary>
    public partial class uc_storage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\View\uc_storage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_ucStorage;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\View\uc_storage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_locations;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\View\uc_storage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_section;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\View\uc_storage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_receiptOfPurchaseInvoice;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\View\uc_storage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_itemsStorage;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\View\uc_storage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_itemsImport;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\View\uc_storage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_itemsExport;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\View\uc_storage.xaml"
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
            System.Uri resourceLocater = new System.Uri("/POS;component/view/uc_storage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\uc_storage.xaml"
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
            
            #line 9 "..\..\..\View\uc_storage.xaml"
            ((POS.View.uc_storage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_ucStorage = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.btn_locations = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\View\uc_storage.xaml"
            this.btn_locations.Click += new System.Windows.RoutedEventHandler(this.Btn_locations_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_section = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\View\uc_storage.xaml"
            this.btn_section.Click += new System.Windows.RoutedEventHandler(this.Btn_section_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_receiptOfPurchaseInvoice = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\View\uc_storage.xaml"
            this.btn_receiptOfPurchaseInvoice.Click += new System.Windows.RoutedEventHandler(this.Btn_receiptOfPurchaseInvoice_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_itemsStorage = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\View\uc_storage.xaml"
            this.btn_itemsStorage.Click += new System.Windows.RoutedEventHandler(this.Btn_itemsStorage_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_itemsImport = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\View\uc_storage.xaml"
            this.btn_itemsImport.Click += new System.Windows.RoutedEventHandler(this.Btn_itemsImport_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_itemsExport = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\..\View\uc_storage.xaml"
            this.btn_itemsExport.Click += new System.Windows.RoutedEventHandler(this.Btn_itemsExport_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.grid_main = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

