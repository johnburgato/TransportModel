﻿#pragma checksum "..\..\Import.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F7E074D2624400D8623E61BB71668D45"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4211
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace TransportModel {
    
    
    /// <summary>
    /// Import
    /// </summary>
    public partial class Import : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\Import.xaml"
        internal System.Windows.Controls.Button btnImport;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Import.xaml"
        internal System.Windows.Controls.Button btnCancelImport;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Import.xaml"
        internal System.Windows.Controls.TextBox txtOutput;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Import.xaml"
        internal System.Windows.Controls.ProgressBar importProgressBar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TransportModel;component/import.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Import.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnImport = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Import.xaml"
            this.btnImport.Click += new System.Windows.RoutedEventHandler(this.btnImport_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnCancelImport = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\Import.xaml"
            this.btnCancelImport.Click += new System.Windows.RoutedEventHandler(this.btnCancelImport_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtOutput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.importProgressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}