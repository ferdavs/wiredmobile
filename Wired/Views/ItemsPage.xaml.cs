using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Wired.Helpers;
using Xamarin.Forms;

namespace Wired
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnCatSelect(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Categories", "Cancel", null,
                                                  "TopStories",
                                                  "Bussiness",
                                                "Desing",
                                                "Culture",
                                                "Gear",
                                                "Reviews",
                                                "Science",
                                                "ScienceBlogs",
                                                "Security",
                                                "Transportation",
                                                "Photo");

            Settings.AppSettings.AddOrUpdateValue("category", action);

            //TODO get rid if this
            switch (action)
            {
                case "TopStories":
                    Settings.AppSettings.AddOrUpdateValue("categoryUrl", WiredPages.TopStories.GetString());
                    await viewModel.ExecuteLoadItemsCommand(WiredPages.TopStories.GetString());
                    break;
                case "Bussiness":
                    Settings.AppSettings.AddOrUpdateValue("categoryUrl", WiredPages.TopStories.GetString());
                    await viewModel.ExecuteLoadItemsCommand(WiredPages.Bussiness.GetString());
                    break;
                case "Desing":
                    Settings.AppSettings.AddOrUpdateValue("categoryUrl", WiredPages.TopStories.GetString());
                    await viewModel.ExecuteLoadItemsCommand(WiredPages.Desing.GetString());
                    break;
                case "Culture":
                    Settings.AppSettings.AddOrUpdateValue("categoryUrl", WiredPages.Culture.GetString());
                    await viewModel.ExecuteLoadItemsCommand(WiredPages.Culture.GetString());
                    break;
                case "Gear":
                    Settings.AppSettings.AddOrUpdateValue("categoryUrl", WiredPages.Gear.GetString());
                    await viewModel.ExecuteLoadItemsCommand(WiredPages.Gear.GetString());
                    break;
                case "Reviews":
                    Settings.AppSettings.AddOrUpdateValue("categoryUrl", WiredPages.Reviews.GetString());
                    await viewModel.ExecuteLoadItemsCommand(WiredPages.Reviews.GetString());
                    break;
                case "Science":
                    Settings.AppSettings.AddOrUpdateValue("categoryUrl", WiredPages.Science.GetString());
                    await viewModel.ExecuteLoadItemsCommand(WiredPages.Science.GetString());
                    break;
                case "ScienceBlogs":
                    Settings.AppSettings.AddOrUpdateValue("categoryUrl", WiredPages.ScienceBlogs.GetString());
                    await viewModel.ExecuteLoadItemsCommand(WiredPages.ScienceBlogs.GetString());
                    break;
                case "Security":
                    Settings.AppSettings.AddOrUpdateValue("categoryUrl", WiredPages.Security.GetString());
                    await viewModel.ExecuteLoadItemsCommand(WiredPages.Security.GetString());
                    break;
                case "Transportation":
                    Settings.AppSettings.AddOrUpdateValue("categoryUrl", WiredPages.Transportation.GetString());
                    await viewModel.ExecuteLoadItemsCommand(WiredPages.Transportation.GetString());
                    break;
                case "Photo":
                    Settings.AppSettings.AddOrUpdateValue("categoryUrl", WiredPages.Photo.GetString());
                    await viewModel.ExecuteLoadItemsCommand(WiredPages.Photo.GetString());
                    break;
                default: return;
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

    }
}
