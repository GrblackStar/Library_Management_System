﻿#pragma checksum "..\..\..\View\RegisterClient.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "822433AC41ED3AFA3E0AF257316B82B5DAF9A177B4847582B3A6A367C5A8DAC5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Library_Management_System.View;
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


namespace Library_Management_System.View {
    
    
    /// <summary>
    /// RegisterClient
    /// </summary>
    public partial class RegisterClient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\View\RegisterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lastNameTextbox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\View\RegisterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox firstnameTextbox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\View\RegisterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox clientIDTextbox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\View\RegisterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button registerClientButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\View\RegisterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelClientButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\View\RegisterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button generateClientButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Library_Management_System;component/view/registerclient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\RegisterClient.xaml"
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
            this.lastNameTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.firstnameTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.clientIDTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.registerClientButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\View\RegisterClient.xaml"
            this.registerClientButton.Click += new System.Windows.RoutedEventHandler(this.registerClientButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cancelClientButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\View\RegisterClient.xaml"
            this.cancelClientButton.Click += new System.Windows.RoutedEventHandler(this.cancelClientButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.generateClientButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\View\RegisterClient.xaml"
            this.generateClientButton.Click += new System.Windows.RoutedEventHandler(this.generateClientButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

