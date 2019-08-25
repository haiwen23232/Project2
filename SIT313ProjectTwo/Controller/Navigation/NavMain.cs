using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace SIT313ProjectTwo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class NavMain : AppCompatActivity
    {
        private BottomNavigationView bottomNavigation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.nav_main);

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            LoadFragment(Resource.Id.menu_home);

        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        void LoadFragment(int id)
        {
            Android.Support.V4.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.menu_home:
                    // fragment = new HomeFragment();
                    break;
                case Resource.Id.menu_category:
                    //fragment = CategoryFragment.NewInstance();
                    break;
                case Resource.Id.menu_cart:
                    //fragment = CartFragment.NewInstance();
                    break;
                case Resource.Id.menu_account:
                    //fragment = AccountFragment.NewInstance();
                    break;
            }

            if (fragment == null)
                return;
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment).Commit();
        }
    }
}