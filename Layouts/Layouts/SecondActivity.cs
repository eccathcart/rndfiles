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
using Android.Graphics.Drawables;
using System.IO;
using Android.Graphics;

namespace Layouts
{
    [Activity(Label = "SecondActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SecondActivity : Activity
    {
		EditText txtUsername;
		EditText txtEmail;
		EditText txtPassword;
		Button btnRegister;
		ImageButton btnProfilePic;

		ParseHandler objParse = ParseHandler.Default;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.register);

            txtUsername = FindViewById<EditText> (Resource.Id.txtUserName);
			txtEmail = FindViewById<EditText> (Resource.Id.txtEmail);
			txtPassword = FindViewById<EditText> (Resource.Id.txtPassword);
			btnRegister = FindViewById<Button> (Resource.Id.btnRegister);
			btnProfilePic = FindViewById<ImageButton> (Resource.Id.btnProfilePic);

            btnRegister.Click += OnRegisterButtonClick;
			btnProfilePic.Click += OnProfileButtonClick;
        }

        public void OnRegisterButtonClick(object sender, EventArgs e)
        {
			RegisterNewUser ();
        }

		public void OnProfileButtonClick(object sender, EventArgs e)
		{
			var imageIntent = new Intent ();
			imageIntent.SetType ("image/jpeg");
			imageIntent.SetAction (Intent.ActionGetContent);
			StartActivityForResult (Intent.CreateChooser (imageIntent, "Select an image."), 0);
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			if ((resultCode == Result.Ok) && (data != null)) {
				btnProfilePic.SetImageURI (data.Data);
			}
		}

		public byte[] GetProfilePicInBytes()
		{
			var fetchedDrawable = btnProfilePic.Drawable;
			BitmapDrawable bitmapDrawable = (BitmapDrawable)fetchedDrawable;
			var bitmap = bitmapDrawable.Bitmap;

			byte[] bitmapData;

			using (var stream = new MemoryStream ()) {
				bitmap.Compress (Bitmap.CompressFormat.Jpeg, 100, stream);
				bitmapData = stream.ToArray ();
			}

			return bitmapData;
		}

		public async void RegisterNewUser()
		{
			Toast.MakeText (this, "Please wait...", ToastLength.Short).Show ();

			//var result = await objParse.CheckIfUserNameExists (txtUsername.Text);
			var result = false;

			if (result == true) {
				Toast.MakeText (this, "That username already exists.", ToastLength.Long).Show ();
			} else {
				await objParse.CreateUserAsync (txtUsername.Text, txtEmail.Text, txtPassword.Text,GetProfilePicInBytes());
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