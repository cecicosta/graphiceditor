﻿#pragma checksum "..\..\..\cont_cor_da_linha.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4259A7224D59C8E575D8392DF664E480"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ArteDraw;
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


namespace ArteDraw {
    
    
    /// <summary>
    /// cor_da_linha
    /// </summary>
    public partial class cor_da_linha : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\cont_cor_da_linha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_black;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\cont_cor_da_linha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_red;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\cont_cor_da_linha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_verde;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\cont_cor_da_linha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_mouse;
        
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
            System.Uri resourceLocater = new System.Uri("/ArteDraw;component/cont_cor_da_linha.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\cont_cor_da_linha.xaml"
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
            this.btn_black = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\..\cont_cor_da_linha.xaml"
            this.btn_black.Click += new System.Windows.RoutedEventHandler(this.btn_black_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_red = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\cont_cor_da_linha.xaml"
            this.btn_red.Click += new System.Windows.RoutedEventHandler(this.btn_red_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_verde = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\cont_cor_da_linha.xaml"
            this.btn_verde.Click += new System.Windows.RoutedEventHandler(this.btn_verde_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_mouse = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

