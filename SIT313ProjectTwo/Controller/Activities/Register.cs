using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace SIT313ProjectTwo
{
    [Activity(Label = "Register", Theme = "@style/AppTheme")]
    class Register : AppCompatActivity
    {
        private EditText userNameTxt;
        private EditText passwordTxt;
        private EditText passwordConfirmTxt;
        private EditText emailTxt;
        private Button resetBtn;
        private Button registerBtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_register);

            this.userNameTxt = FindViewById<EditText>(Resource.Id.register_user_name);
            this.passwordTxt = FindViewById<EditText>(Resource.Id.register_password);
            this.passwordConfirmTxt = FindViewById<EditText>(Resource.Id.register_password_confirm);
            this.emailTxt = FindViewById<EditText>(Resource.Id.register_email);
            this.resetBtn = FindViewById<Button>(Resource.Id.register_reset);
            this.registerBtn = FindViewById<Button>(Resource.Id.register_sign_up);

            this.resetBtn.Click += Reset;
            this.registerBtn.Click += SignUp;
            
        }
        private void Reset(object o, System.EventArgs e)
        {
            this.userNameTxt.Text = "";
            this.passwordTxt.Text = "";
            this.passwordConfirmTxt.Text = "";
            this.emailTxt.Text = ""; 
        }

        private void SignUp(object o, System.EventArgs e)
        {
            string userNameStr = this.userNameTxt.Text.Trim();
            string passwordStr = this.passwordTxt.Text;
            string passwordConfirmStr = this.passwordConfirmTxt.Text;
            string emailStr = this.emailTxt.Text.Trim();
            if (CheckInput(userNameStr, passwordStr, passwordConfirmStr, emailStr))
            {
                Toast.MakeText(Application.Context, "Click sign up", ToastLength.Short).Show();
            }
        }

        private Boolean CheckInput(string userName, string password, string passwordConfirm, string email)
        {
            if (string.IsNullOrEmpty(userName))
            {
                this.userNameTxt.Error = "Required";
            }
            else if (string.IsNullOrEmpty(password))
            {
                this.passwordTxt.Error = "Required";
            }
            else if (string.IsNullOrEmpty(passwordConfirm))
            {
                this.passwordConfirmTxt.Error = "Required";
            }
            else if (string.IsNullOrEmpty(email))
            {
                this.emailTxt.Error = "Required";
            }
            else if (!password.Equals(passwordConfirm))
            {
                this.passwordTxt.Error = "Not match";
                this.passwordConfirmTxt.Error = "Not match";
            }
            else
            {
                return true;
            }

            return false;
        }
    }
}