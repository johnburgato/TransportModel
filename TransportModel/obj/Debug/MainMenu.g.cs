﻿#pragma checksum "..\..\MainMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6785A1D6F21DEC0F59D8B90BCBD13F8A"
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
    /// MainMenu
    /// </summary>
    public partial class MainMenu : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\MainMenu.xaml"
        internal System.Windows.Controls.Grid grdLayout;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainMenu.xaml"
        internal System.Windows.Controls.Button btnImport;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainMenu.xaml"
        internal System.Windows.Controls.Button btnLoad;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainMenu.xaml"
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainMenu.xaml"
        internal System.Windows.Controls.Button btnRun;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainMenu.xaml"
        internal System.Windows.Controls.Button btnQuit;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MainMenu.xaml"
        internal System.Windows.Controls.Button btnTest;
        
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
            System.Uri resourceLocater = new System.Uri("/TransportModel;component/mainmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainMenu.xaml"
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
            
            #line 4 "..\..\MainMenu.xaml"
            ((TransportModel.MainMenu)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grdLayout = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.btnImport = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\MainMenu.xaml"
            this.btnImport.Click += new System.Windows.RoutedEventHandler(this.btnImport_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnLoad = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\MainMenu.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnRun = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.btnQuit = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\MainMenu.xaml"
            this.btnQuit.Click += new System.Windows.RoutedEventHandler(this.btnQuit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnTest = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\MainMenu.xaml"
            this.btnTest.Click += new System.Windows.RoutedEventHandler(this.btnTest_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
