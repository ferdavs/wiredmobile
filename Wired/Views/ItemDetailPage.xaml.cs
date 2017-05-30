using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Wired
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        HtmlWebViewSource HtmlContent { get; set; }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            HtmlContent = new HtmlWebViewSource()
            {
                Html = @"<html><body>" + viewModel.Item.Content + "</body></html>"
            };
        }

    }
}
