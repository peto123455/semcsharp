﻿#pragma checksum "..\..\..\..\Windows\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4D72F3B22B028ADE6728F777841955A3290201CD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Controls.Ribbon;
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
using semestralka;


namespace semestralka {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox AvailableVehiclesList;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LeasedVehiclesList;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock VehicleInfo;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LeasesList;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/semestralka;component/windows/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 19 "..\..\..\..\Windows\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadButton);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 20 "..\..\..\..\Windows\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveButton);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 21 "..\..\..\..\Windows\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.VehicleCreateButton);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 22 "..\..\..\..\Windows\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DoubleClickOnVehicle);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AvailableVehiclesList = ((System.Windows.Controls.ListBox)(target));
            
            #line 44 "..\..\..\..\Windows\MainWindow.xaml"
            this.AvailableVehiclesList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SelectAvailableVehicle);
            
            #line default
            #line hidden
            
            #line 44 "..\..\..\..\Windows\MainWindow.xaml"
            this.AvailableVehiclesList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AvailableVehicleSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LeasedVehiclesList = ((System.Windows.Controls.ListBox)(target));
            
            #line 56 "..\..\..\..\Windows\MainWindow.xaml"
            this.LeasedVehiclesList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SelectLeasedVehicles);
            
            #line default
            #line hidden
            
            #line 56 "..\..\..\..\Windows\MainWindow.xaml"
            this.LeasedVehiclesList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LeasedVehicleSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.VehicleInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.LeasesList = ((System.Windows.Controls.ListBox)(target));
            
            #line 76 "..\..\..\..\Windows\MainWindow.xaml"
            this.LeasesList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SelectedLease);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 80 "..\..\..\..\Windows\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.VehicleAdminButton);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 81 "..\..\..\..\Windows\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.VehicleEditButton);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

