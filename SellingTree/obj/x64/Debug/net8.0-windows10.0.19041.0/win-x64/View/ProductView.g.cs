﻿#pragma checksum "D:\WinUI_source\Project_WindowProgramming_2022-31\SellingTree\View\ProductView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2E61B68378CA5AE09857BB63833FE95A921833D86919E87FF7800105AEC49208"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SellingTree
{
    partial class ProductView : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2409")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // View\ProductView.xaml line 67
                {
                    global::Microsoft.UI.Xaml.Controls.Button element2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element2).Click += this.ShopList_Added;
                }
                break;
            case 3: // View\ProductView.xaml line 62
                {
                    this.QuantityBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NumberBox>(target);
                }
                break;
            case 4: // View\ProductView.xaml line 28
                {
                    this.MainImage = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Image>(target);
                }
                break;
            case 5: // View\ProductView.xaml line 39
                {
                    global::Microsoft.UI.Xaml.Controls.Image element5 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Image>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Image)element5).Loaded += this.Image_Loaded;
                    ((global::Microsoft.UI.Xaml.Controls.Image)element5).PointerEntered += this.OnPointerEntered;
                    ((global::Microsoft.UI.Xaml.Controls.Image)element5).PointerExited += this.OnPointerExited;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }


        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2409")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

