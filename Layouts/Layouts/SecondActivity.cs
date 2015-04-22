using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using System.Threading.Tasks;
using Parse;

namespace Layouts
{
    [Activity(Label = "SecondActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SecondActivity : Activity
    {
		EditText txtUsername;
		EditText txtEmail;
		EditText txtPassword;
		Button btnRegister;

		ParseHandler objParse = ParseHandler.Default;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.register);

            txtUsername = FindViewById<EditText>(Resource.Id.txtUserName);
			txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
			txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
			btnRegister = FindViewById<Button>(Resource.Id.btnRegister);

            btnRegister.Click += OnRegisterButtonClick;
        }

        public void OnRegisterButtonClick(object sender, EventArgs e)
        {
			RegisterNewUser ();
        }

		public async void RegisterNewUser()
		{
			Toast.MakeText (this, "Please wait...", ToastLength.Short).Show ();

			var result = await objParse.CheckIfUserNameExists (txtUsername.Text);

			if (result == true) {
				Toast.MakeText (this, "That username already exists.", ToastLength.Long).Show ();
			} else {
				await objParse.CreateUserAsync (txtUsername.Text, txtEmail.Text, txtPassword.Text);
				Toast.MakeText (this, "Account has successfully been created.", ToastLength.Short).Show ();
				Toast.MakeText (this, "You may now login.", ToastLength.Short).Show ();
				ClearAll ();
				StartActivity (typeof(MainActivity));
			}
		}

		void ClearAll()
		{
			txtUsername.Text = "";
			txtPassword.Text = "";
			txtEmail.Text = "";
		}
    }
}