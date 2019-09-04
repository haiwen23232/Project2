using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace shop
{
    public partial class SignUp : ContentPage
    {
        private string _userName;
        private string _email;
        private string _password;
        private string _passwordConfirm;

        public SignUp()
        {
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
            this._userName = this.SignupUserName.Text.Trim();
            this._email = this.SignupEmail.Text.Trim();
            this._password = this.SignupPassword.Text;
            this._passwordConfirm = this.SignupPasswordConfirm.Text;

            if (string.IsNullOrEmpty(this._userName) || string.IsNullOrEmpty(this._email) || string.IsNullOrEmpty(_password) || string.IsNullOrEmpty(_passwordConfirm))
                DisplayAlert("", "Please fill all blanks", "ok");
            else
                DisplayAlert("","Wow","Ok");
        }


    }
}
