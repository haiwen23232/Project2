using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace shop
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private string _userName;
        private string _password;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Reset(object o, System.EventArgs e)
        {
            this.LoginUserName.Text = "";
            this.LoginPassword.Text = "";
        }

        private async void Login(object o, System.EventArgs e)
        {
            this._userName = this.LoginUserName.Text.Trim();
            this._password = this.LoginPassword.Text;

            if (string.IsNullOrEmpty(this._userName) || string.IsNullOrEmpty(this._password))
                await DisplayAlert("", "Please fill all blanks", "Ok");
            else
                await Navigation.PushAsync(new TabbedMain());

        }

        private async void SignUp(object o, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }


    }
}
