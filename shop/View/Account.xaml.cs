using System;
using System.Collections.Generic;
using shop.ViewModel;
using Xamarin.Forms;

namespace shop.View
{
    public partial class Account : ContentPage
    {
        private UserViewModel vm;
        private string _password;
        private string _passwordConfirm;

        public Account()
        {
            InitializeComponent();
            vm = new UserViewModel();
            BindingContext = vm;
        }

        private void Submit(object o, System.EventArgs e)
        {
            this._password = this.AccountPassword.Text;
            this._passwordConfirm = this.AccountPasswordConfirm.Text;
            if (string.IsNullOrEmpty(this._password) || string.IsNullOrEmpty(this._passwordConfirm))
                DisplayAlert("", "Please fill in all blanks", "Ok");
            else
                DisplayAlert("", "Wow", "Ok");
        }
    }
}
