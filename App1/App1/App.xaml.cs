using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    

    public partial class App : Application
    {
        public App()

        {
            InitializeComponent();
            if (Device.OS != TargetPlatform.WinPhone)
            {
                Resource.Culture = DependencyService.Get<ILocalize>()
                                    .GetCurrentCultureInfo();
            }

            MainPage = new NavigationPage(new SplashPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
