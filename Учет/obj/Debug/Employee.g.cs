﻿#pragma checksum "..\..\Employee.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "489FC2A9B18F6F6B606363A2F0134C670717C5925317170271EF68089EB50EAC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using System.Windows.Shell;
using Учет;


namespace Учет {
    
    
    /// <summary>
    /// Employee
    /// </summary>
    public partial class Employee : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 79 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg2;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblText;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxStatus;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbResponse;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxRequest;
        
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
            System.Uri resourceLocater = new System.Uri("/Учет;component/employee.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Employee.xaml"
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
            
            #line 72 "..\..\Employee.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit_Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 75 "..\..\Employee.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Create_Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 76 "..\..\Employee.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Update_Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 77 "..\..\Employee.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dg = ((System.Windows.Controls.DataGrid)(target));
            
            #line 79 "..\..\Employee.xaml"
            this.dg.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dg_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dg2 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 80 "..\..\Employee.xaml"
            this.dg2.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dg2_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tblText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.cbxStatus = ((System.Windows.Controls.ComboBox)(target));
            
            #line 84 "..\..\Employee.xaml"
            this.cbxStatus.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbxPriority_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tbResponse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.cbxRequest = ((System.Windows.Controls.ComboBox)(target));
            
            #line 88 "..\..\Employee.xaml"
            this.cbxRequest.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbxPriority_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 90 "..\..\Employee.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

