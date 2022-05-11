using DedAPI.Services;
using DedAPI.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DedAPI
{
    public partial class App : Application
    {
        public static RequestManager RequestManager { get; private set; }   
        public App()
        {
            InitializeComponent();

            RequestManager = new RequestManager(new RestService());
            MainPage = new NavigationPage(new EntrieListPage()) { BarBackgroundColor = Color.Red};
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
