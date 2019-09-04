using System;

using Xamarin.Forms;

namespace shop.View
{
    public class Shop : ContentPage
    {
        public Shop()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

