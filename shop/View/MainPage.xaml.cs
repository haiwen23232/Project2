using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using shop.Model;
using shop.ViewModel;
using Xamarin.Forms;

namespace shop
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private UserViewModel vm;
        private Model.User _user;
        private string _userName;
        private string _password;

        public MainPage()
        {
            vm = new UserViewModel();
            InitializeComponent();
        }

        private void Reset(object o, System.EventArgs e)
        {
            this.LoginUserName.Text = "";
            this.LoginPassword.Text = "";
        }

        private async void Login(object o, System.EventArgs e)
        {
            this._userName = this.LoginUserName.Text;
            this._password = this.LoginPassword.Text;

            if (string.IsNullOrEmpty(this._userName) || string.IsNullOrEmpty(this._password))
                await DisplayAlert("", "Please fill all fields", "Ok");
            else
            {
                vm.FetchByNameAsync(_userName);
                if (vm.User == null)
                    await DisplayAlert("", "No such user, plase sign up first", "Ok");
                else
                {
                    if (SimpleMD5(_password) == vm.User.Password)
                        await Navigation.PushAsync(new TabbedMain(vm.User.UserId));
                    else
                        await DisplayAlert("","Wrong password","Ok");
                }
            }
        }

        private async void SignUp(object o, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }

        private string SimpleMD5(string inputPwd)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(inputPwd);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

    }
}
