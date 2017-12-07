using System;

using Xamarin.Forms;

namespace TwitterFlowList
{
    public partial class App : Application
    {
        public static string Default_Color = "#0040ff";
        public App()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new ItemsPage();
            else
                MainPage = new NavigationPage(new ItemsPage());
        }
    }
}