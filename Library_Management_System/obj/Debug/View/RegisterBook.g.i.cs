﻿#pragma checksum "..\..\..\View\RegisterBook.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "68F11CA4089CD7961221A9CC769112D66FE58BA4E8E783B254506D52A13A866B"
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
    /// RegisterBook
    /// </summary>
    public partial class RegisterBook : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\View\RegisterBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox titleTextbox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\View\RegisterBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox autherTextbox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\View\RegisterBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ISBNTextbox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\View\RegisterBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox copyIDTextbox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\View\RegisterBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button registerBookButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\RegisterBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelBookButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Library_Management_System;component/view/registerbook.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\RegisterBook.xaml"
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
            this.titleTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.autherTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ISBNTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.copyIDTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.registerBookButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\View\RegisterBook.xaml"
            this.registerBookButton.Click += new System.Windows.RoutedEventHandler(this.registerBookButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cancelBookButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\View\RegisterBook.xaml"
            this.cancelBookButton.Click += new System.Windows.RoutedEventHandler(this.cancelBookButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

