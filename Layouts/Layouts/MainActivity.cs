using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

namespace Layouts
{
    [Activity(Label = "Layouts", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
		Button btnLogin;
		Button btnRegister;
		EditText txtUsername;
		EditText txtPassword;
		ParseHandler objParse = ParseHandler.Default;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

			btnLogin = FindViewById<Button> (Resource.Id.btnLogin);
			btnRegister = FindViewById<Button> (Resource.Id.btnLinkToRegister);
			txtUsername = FindViewById<EditText> (Resource.Id.username);
			txtPassword = FindViewById<EditText> (Resource.Id.password);

			btnLogin.Click += LoginClick;
            btnRegister.Click += RegisterClick;
        }

        public void RegisterClick(object sender, EventArgs e)
        {
            StartActivity(typeof(SecondActivity));
        }

		public async void LoginClick(object sender, EventArgs e)
		{
			if (txtUsername.Text != "" && txtPassword.Text != "") {
				var result = await objParse.Login (txtUsername.Text, txtPassword.Text);

				if (result == true) {
					Toast.MakeText (this, "Login successful.", ToastLength.Long).Show ();
				} else {
					Toast.MakeText (this, "Login unsuccessful. Please check your username/password.", ToastLength.Long).Show ();
				}
			}
		}
    }
}

