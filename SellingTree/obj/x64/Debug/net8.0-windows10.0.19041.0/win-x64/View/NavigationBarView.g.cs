﻿#pragma checksum "D:\Project_WindowProgramming_2022-31-develop\Project_WindowProgramming_2022-31-develop\SellingTree\View\NavigationBarView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "46566FC90890E59287CCACEF8DA238DADC3F04800D74F03290C322A8A38AC91E"
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
    partial class NavigationBarView : 
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
            case 2: // View\NavigationBarView.xaml line 15
                {
                    this.MainPageButton = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.MainPageButton).Click += this.MainPageButton_Click;
                }
                break;
            case 3: // View\NavigationBarView.xaml line 21
                {
                    this.ShopListButton = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.ShopListButton).Click += this.ShopListButton_Clicked;
                }
                break;
            case 4: // View\NavigationBarView.xaml line 30
                {
                    this.blogButton = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.blogButton).Click += this.blogButton_Click;
                }
                break;
            case 5: // View\NavigationBarView.xaml line 31
                {
                    this.chatButton = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.chatButton).Click += this.chatButton_Click;
                }
                break;
            case 6: // View\NavigationBarView.xaml line 32
                {
                    this.collectionButton = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.collectionButton).Click += this.collectionButton_Click;
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

