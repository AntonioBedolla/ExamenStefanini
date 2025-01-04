using System;
using ExamenStefanini.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenStefanini
{
    public partial class App : Application
    {

        public static INavigation Navigation
        {
            get
            {
                if (Current.MainPage is NavigationPage page)
                {
                    if (page.CurrentPage is TabbedPage tabs)
                    {
                        return tabs.CurrentPage.Navigation;
                    }
                }

                return Current.MainPage.Navigation;
            }
        }

        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

