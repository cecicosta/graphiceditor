﻿#pragma checksum "..\..\..\..\usercontrol\cont_propiedades.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8B0EB3F5BF7828496DD81B1CD5AC6152"
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
    /// propiedades
    /// </summary>
    public partial class propiedades : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\usercontrol\cont_propiedades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_seta;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\usercontrol\cont_propiedades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_quad;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\usercontrol\cont_propiedades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_circulo;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\usercontrol\cont_propiedades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_line;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\usercontrol\cont_propiedades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_shape;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\usercontrol\cont_propiedades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_inv1;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\usercontrol\cont_propiedades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_inv2;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\usercontrol\cont_propiedades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_inh3;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\usercontrol\cont_propiedades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_inh4;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\usercontrol\cont_propiedades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cort;
        
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
            System.Uri resourceLocater = new System.Uri("/ArteDraw;component/usercontrol/cont_propiedades.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\usercontrol\cont_propiedades.xaml"
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
            this.btn_seta = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\usercontrol\cont_propiedades.xaml"
            this.btn_seta.Click += new System.Windows.RoutedEventHandler(this.btn_seta_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_quad = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\usercontrol\cont_propiedades.xaml"
            this.btn_quad.Click += new System.Windows.RoutedEventHandler(this.InsertQuadStart);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_circulo = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\usercontrol\cont_propiedades.xaml"
            this.btn_circulo.Click += new System.Windows.RoutedEventHandler(this.InsertCircleStart);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_line = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\usercontrol\cont_propiedades.xaml"
            this.btn_line.Click += new System.Windows.RoutedEventHandler(this.InsertLineStart);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_shape = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\usercontrol\cont_propiedades.xaml"
            this.btn_shape.Click += new System.Windows.RoutedEventHandler(this.btn_shape_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_inv1 = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\usercontrol\cont_propiedades.xaml"
            this.btn_inv1.Click += new System.Windows.RoutedEventHandler(this.btn_inv1_Click_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_inv2 = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\usercontrol\cont_propiedades.xaml"
            this.btn_inv2.Click += new System.Windows.RoutedEventHandler(this.btn_inv2_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_inh3 = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\usercontrol\cont_propiedades.xaml"
            this.btn_inh3.Click += new System.Windows.RoutedEventHandler(this.btn_inh3_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_inh4 = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\usercontrol\cont_propiedades.xaml"
            this.btn_inh4.Click += new System.Windows.RoutedEventHandler(this.btn_inh4_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_cort = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\..\usercontrol\cont_propiedades.xaml"
            this.btn_cort.Click += new System.Windows.RoutedEventHandler(this.btn_cort_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

