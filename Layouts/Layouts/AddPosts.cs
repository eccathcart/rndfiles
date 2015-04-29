
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
using Android.Graphics.Drawables;
using System.IO;
using Android.Graphics;
using System.Net;
using Parse;

namespace Layouts
{
	[Activity (Label = "AddPosts")]			
	public class AddPosts : Activity
	{
		ParseHandler objParse = ParseHandler.Default;
		ImageView PostProfilePic;
		TextView PostUsrName;
		EditText PostDescription;
		TextView PostDate;
		ImageButton btnUpload;
		ImageView imgPostPic;
		Button btnPost;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.AddPost);

			PostProfilePic = FindViewById<ImageView> (Resource.Id.PostProfilePic);
			PostUsrName = FindViewById<TextView> (Resource.Id.PostUsrName);
			PostDate = FindViewById<TextView> (Resource.Id.PostDate);
			imgPostPic = FindViewById<ImageView> (Resource.Id.imgPostImage);

			btnUpload = FindViewById<ImageButton> (Resource.Id.BtnUploadPostImage);
			PostDescription = FindViewById<EditText> (Resource.Id.PostDescription);

			btnUpload.Click += OnUploadClick;

			btnPost = FindViewById<Button> (Resource.Id.btnPost);
			btnPost.Click += OnPostClick;

			LoadUserDetails ();
		}

		void OnUploadClick(object sender, EventArgs e)
		{
			var imageIntent = new Intent ();
			imageIntent.SetType ("image/jpeg");
			imageIntent.SetAction (Intent.ActionGetContent);
			StartActivityForResult (Intent.CreateChooser (imageIntent, "Select an image."), 0);
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			if ((resultCode == Result.Ok) && (data != null)) {
				imgPostPic.SetScaleType (ImageView.ScaleType.FitXy);
				imgPostPic.SetImageURI (data.Data);
			}
		}

		public async void OnPostClick(object sender, EventArgs e)
		{
			Toast.MakeText (this, "Uploading post, please wait...", ToastLength.Short).Show ();

			try {
				await objParse.AddPost (PostDescription.Text, GetPicInBytes());
				Toast.MakeText (this, "Post was successfully uploaded.", ToastLength.Short).Show ();
				StartActivity(typeof(FeedActivity));
			} catch (Exception ex) {
				Toast.MakeText (this, "Error occurred: " + ex.Message, ToastLength.Short).Show ();
			}
		}

		public byte[] GetPicInBytes()
		{
			var fetchedDrawable = imgPostPic.Drawable;
			BitmapDrawable bitmapDrawable = (BitmapDrawable)fetchedDrawable;
			var bitmap = bitmapDrawable.Bitmap;

			byte[] bitmapData;

			using (var stream = new MemoryStream ()) {
				bitmap.Compress (Bitmap.CompressFormat.Jpeg, 100, stream);
				bitmapData = stream.ToArray ();
			}

			return bitmapData;
		}

		void LoadUserDetails()
		{
			PostUsrName.Text = objParse.GetCurrentUserInstance ().Username;
			PostDate.Text = DateTime.Now.ToString ();
			var pic = objParse.GetCurrentUserInstance ().Get<ParseFile> ("ProfilePic");
			PostProfilePic.SetImageBitmap (GetImageBitmapFromUrl (pic.Url.AbsoluteUri));
		}

		private Bitmap GetImageBitmapFromUrl(string url) 
		{
			Bitmap imageBitmap = null;

			if (!(url == null))
				using (var webClient = new WebClient ()) {
					var imageBytes = webClient.DownloadData (url);
					if (imageBytes != null && imageBytes.Length > 0) {
						imageBitmap = BitmapFactory.DecodeByteArray (imageBytes, 0, imageBytes.Length);
					}
				}
			return imageBitmap;
		}
	}
}

