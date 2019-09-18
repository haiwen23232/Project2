using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using shop.Model;
using shop.ViewModel;
using Xamarin.Forms;

namespace shop.View
{
    public partial class Account : ContentPage
    {
        private UserViewModel vm;
        private string _password;
        private string _passwordConfirm;

        public Account(int userId)
        {
            InitializeComponent();
            vm = new UserViewModel();
            vm.FetchByIdAsync(userId);
            BindingContext = vm;
        }

        private void Submit(object o, System.EventArgs e)
        {
            this._password = this.AccountPassword.Text;
            this._passwordConfirm = this.AccountPasswordConfirm.Text;

            if (string.IsNullOrEmpty(this._password) || string.IsNullOrEmpty(this._passwordConfirm))
                DisplayAlert("", "Please fill all fields", "Ok");
            else if(_password != _passwordConfirm)
                DisplayAlert("Password", "Not match!", "Ok");
            else
            {
                vm.User.Password = SimpleMD5(this._password);
                DisplayAlert("Change password","Success!","Ok");
                vm.UpdateUser(vm.User);
            }
        }

        private string SimpleMD5(string inputPwd)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(inputPwd);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));

            return sb.ToString();
        }
    }
}
