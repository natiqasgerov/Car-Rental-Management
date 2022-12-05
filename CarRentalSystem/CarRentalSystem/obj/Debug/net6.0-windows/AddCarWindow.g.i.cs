﻿#pragma checksum "..\..\..\AddCarWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7341E82D7501A61630187CD91B456808FD7F190A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CarRentalSystem;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace CarRentalSystem {
    
    
    /// <summary>
    /// AddCarWindow
    /// </summary>
    public partial class AddCarWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox makeCar_textbox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox modelCar_textbox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker carYear_datapicker;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox carType_comboBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox carFuel_comboBox;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox carTransmission_comboBox;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox carTank_textbox;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox carEngineSize_textbox;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox carNumber_textbox;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox carOdometer_textbox;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox carStatus_comboBox;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush carImage_imagebrush;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button carBrowse_btn;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button carDelete_btn;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\AddCarWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button carSave_btn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CarRentalSystem;component/addcarwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddCarWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\AddCarWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 13 "..\..\..\AddCarWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.makeCar_textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\..\AddCarWindow.xaml"
            this.makeCar_textbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.makeCar_textbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.modelCar_textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\..\AddCarWindow.xaml"
            this.modelCar_textbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.modelCar_textbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.carYear_datapicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 28 "..\..\..\AddCarWindow.xaml"
            this.carYear_datapicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.carYear_datapicker_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.carType_comboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\..\AddCarWindow.xaml"
            this.carType_comboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.carType_comboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.carFuel_comboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 57 "..\..\..\AddCarWindow.xaml"
            this.carFuel_comboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.carFuel_comboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.carTransmission_comboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 69 "..\..\..\AddCarWindow.xaml"
            this.carTransmission_comboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.carTransmission_comboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.carTank_textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 81 "..\..\..\AddCarWindow.xaml"
            this.carTank_textbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.carTank_textbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.carEngineSize_textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 87 "..\..\..\AddCarWindow.xaml"
            this.carEngineSize_textbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.carEngineSize_textbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.carNumber_textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 92 "..\..\..\AddCarWindow.xaml"
            this.carNumber_textbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.carNumber_textbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.carOdometer_textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 98 "..\..\..\AddCarWindow.xaml"
            this.carOdometer_textbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.carOdometer_textbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.carStatus_comboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 101 "..\..\..\AddCarWindow.xaml"
            this.carStatus_comboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.carStatus_comboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            this.carImage_imagebrush = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 15:
            this.carBrowse_btn = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\..\AddCarWindow.xaml"
            this.carBrowse_btn.Click += new System.Windows.RoutedEventHandler(this.carBrowse_btn_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.carDelete_btn = ((System.Windows.Controls.Button)(target));
            
            #line 121 "..\..\..\AddCarWindow.xaml"
            this.carDelete_btn.Click += new System.Windows.RoutedEventHandler(this.carDelete_btn_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.carSave_btn = ((System.Windows.Controls.Button)(target));
            
            #line 132 "..\..\..\AddCarWindow.xaml"
            this.carSave_btn.Click += new System.Windows.RoutedEventHandler(this.carSave_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

