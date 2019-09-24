using System;
using System.Linq;
using shop.Data;
using shop.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace shop
{
    public partial class App : Application
    {

        static string _Token;
        static int _UserId;
        public static Page myPage = new MainPage();
        public static NavigationPage NavPage = new NavigationPage(myPage);

        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
            MainPage = NavPage;
            // MainPage = new NavigationPage(new SessionsPage());
        }

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() =>
                {
                    NavPage.Navigation.PopModalAsync();
                    NavPage.Navigation.InsertPageBefore(new TabbedMain(_UserId), NavPage.Navigation.NavigationStack.First());
                    NavPage.Navigation.PopToRootAsync();
                });
            }
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

        public static void SaveToken(string token)
        {
            _Token = token;
            UsersManager um = new UsersManager();
            _UserId = um.GetFBUser(token);
        }
    }
}
