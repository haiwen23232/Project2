using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace SIT313ProjectTwo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText userNameTxt;
        private EditText passwordTxt;
        private Button resetBtn;
        private Button loginBtn;
        private Button registerBtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            this.userNameTxt = FindViewById<EditText>(Resource.Id.login_user_name);
            this.passwordTxt = FindViewById<EditText>(Resource.Id.login_password);
            this.resetBtn = FindViewById<Button>(Resource.Id.login_reset);
            this.loginBtn = FindViewById<Button>(Resource.Id.login_login);
            this.registerBtn = FindViewById<Button>(Resource.Id.login_register);

            this.resetBtn.Click += Reset;
            this.registerBtn.Click += Register;
            this.loginBtn.Click += Login;
        }

        private void Reset(object o, System.EventArgs e) 
        {
            this.userNameTxt.Text = "";
            this.passwordTxt.Text = "";
        }

        private void Register(object o, System.EventArgs e)
        {
            Intent intent = new Intent(this,typeof(Register));
            StartActivity(intent);
        }

        private void Login(object o, System.EventArgs e)
        {
            string userNameStr = this.userNameTxt.Text.Trim();
            string passwordStr = this.passwordTxt.Text;
            if (string.IsNullOrEmpty(userNameStr))
            {
                this.userNameTxt.Error = "Required";
            }
            else if (string.IsNullOrEmpty(passwordStr))
            {
                this.passwordTxt.Error = "Required";
            }
            else
            {
                Toast.MakeText(this,"Click login",ToastLength.Long).Show();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}