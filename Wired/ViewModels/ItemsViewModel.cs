using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Wired.Helpers;
using Xamarin.Forms;

namespace Wired
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "W I R E D - " + Settings.AppSettings.GetValueOrDefault("category", WiredPages.TopStories.ToString());
            Items = new ObservableRangeCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public async Task ExecuteLoadItemsCommand()
        {
            var url = Settings.AppSettings.GetValueOrDefault("categoryUrl", WiredPages.TopStories.GetString());
            await ExecuteLoadItemsCommand(url);
        }

        public async Task ExecuteLoadItemsCommand(string catUrl)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                //Items.Clear();
                //var items = await DataStore.GetLatestAsync();
                Items.ReplaceRange(await DataStore.GetLatestAsync(catUrl));
                Title = "W I R E D - " + Settings.AppSettings.GetValueOrDefault("category", WiredPages.TopStories.ToString());

                //Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
