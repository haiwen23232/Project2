using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using shop.Model;
using shop.ViewModel;
using Xamarin.Forms;

namespace shop
{
    public partial class SignUp : ContentPage
    {
        private UserViewModel vm;
        private string _userName;
        private string _email;
        private string _password;
        private string _passwordConfirm;

        public SignUp()
        {
            vm = new UserViewModel();
            InitializeComponent();
        }

        private void Reset(object o, System.EventArgs e)
        {
            this.SignupUserName.Text = "";
            this.SignupPassword.Text = "";
            this.SignupPasswordConfirm.Text = "";
            this.SignupEmail.Text = "";
        }

        private void SignUpClick(object o, System.EventArgs e)
        {
            this._userName = this.SignupUserName.Text;
            this._email = this.SignupEmail.Text;
            this._password = this.SignupPassword.Text;
            this._passwordConfirm = this.SignupPasswordConfirm.Text;

            if (string.IsNullOrEmpty(this._userName) || string.IsNullOrEmpty(this._email) || string.IsNullOrEmpty(_password) || string.IsNullOrEmpty(_passwordConfirm))
                DisplayAlert("", "Please fill all fields", "ok");
            else
            {
                vm.FetchByNameAsync(_userName);
                User user = vm.User;
                bool available = vm.FetchByEmailAsync(_email);

                if (user != null)
                    DisplayAlert("User name", "Already existing", "Ok");
                else if (!available)
                    DisplayAlert("Email", "Already existing", "Ok");
                else if (this._password != this._passwordConfirm)
                    DisplayAlert("Password","Not matching","Ok");
                else
                {
                    string hashedPwd = SimpleMD5(this._password);
                    User newUser = new User { Name=_userName,Email=_email,Password=hashedPwd};
                    DisplayAlert("Success", "Please go back to login", "Ok");
                    vm = new UserViewModel();

                    vm.CreateUser(newUser);
                }
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
