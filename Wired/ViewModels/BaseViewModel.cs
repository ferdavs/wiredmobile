using Xamarin.Forms;

namespace Wired
{
    public class BaseViewModel : ObservableObject
    {
        public INewsSource<Item> DataStore => DependencyService.Get<INewsSource<Item>>();

        bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
