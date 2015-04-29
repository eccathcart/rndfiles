
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

namespace DrivingTest
{
	[Activity (Label = "DrivingTest", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		TextView txtQNo;
		TextView txtQuestion;

		ImageView imgPic;

		RadioButton rbA1;
		RadioButton rbA2;
		RadioButton rbA3;
		RadioButton rbA4;

		Button btnNext;
		Button btnSkip;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it

			txtQNo = FindViewById<TextView> (Resource.Id.txtQNo);
			txtQuestion = FindViewById<TextView> (Resource.Id.txtQuestion);

			imgPic = FindViewById<ImageView> (Resource.Id.imgPic);

			rbA1 = FindViewById<RadioButton> (Resource.Id.rbA1);
			rbA2 = FindViewById<RadioButton> (Resource.Id.rbA2);
			rbA3 = FindViewById<RadioButton> (Resource.Id.rbA3);
			rbA4 = FindViewById<RadioButton> (Resource.Id.rbA4);

			btnNext = FindViewById<Button> (Resource.Id.btnNext);
			btnSkip = FindViewById<Button> (Resource.Id.btnSkip);

			btnNext.Click += OnBtnNextClick;
			btnSkip.Click += OnBtnSkipClick;

		}

		public void OnBtnNextClick(object sender, EventArgs e)
		{

		}

		public void OnBtnSkipClick(object sender, EventArgs e)
		{

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


