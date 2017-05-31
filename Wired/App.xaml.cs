using System.Collections.Generic;
using Wired.Helpers;
using Wired.Services;
using Xamarin.Forms;

namespace Wired
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<WiredSource>();

            GoToMainPage();
        }

        public static void GoToMainPage()
        {
            Current.MainPage = new NavigationPage(new ItemsPage());
        }
    }
}
