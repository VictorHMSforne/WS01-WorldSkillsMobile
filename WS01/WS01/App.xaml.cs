using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS01
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MainPage()); // (new NavigationPage) preciso colocar isso pra poder navegar mais de uma página
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
