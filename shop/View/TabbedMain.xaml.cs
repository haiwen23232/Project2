using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shop.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace shop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedMain : TabbedPage
    {
        public TabbedMain(int userID)
        {
            InitializeComponent();


            var shopPage = new NavigationPage(new Shop(userID));
            shopPage.IconImageSource = "home.png";
            shopPage.Title = "Shop";
            Children.Add(shopPage);

            var categoryPage = new NavigationPage(new Category(userID));
            categoryPage.IconImageSource = "basket.png";
            categoryPage.Title = "Category";
            Children.Add(categoryPage);

            var cartPage = new NavigationPage(new Cart(userID));
            cartPage.IconImageSource = "cart.png";
            cartPage.Title = "Cart";
            Children.Add(cartPage);

            var accountPage = new NavigationPage(new Account(userID));
            accountPage.IconImageSource = "person.png";
            accountPage.Title = "Account";
            Children.Add(accountPage);

        }
    }
}
