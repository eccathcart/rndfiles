
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Basics
{
	[Activity (Label = "SecondActivity")]			
	public class SecondActivity : Activity
	{
		DatabaseManager objDatabase = new DatabaseManager ();

		ListView lstCities;
		ArrayAdapter listAdapter;

		ImageButton btnExit;

		string[] cities;
		protected override void OnCreate (Bundle bundle)
		{
			RequestWindowFeature(WindowFeatures.NoTitle);
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Cities);

			lstCities = FindViewById<ListView> (Resource.Id.lstCities);
			btnExit = FindViewById<ImageButton> (Resource.Id.btnExit);

			cities = new string[] {"North Island", "", "Auckland", "Gisborne", "Hamilton", "Hastings", "Napier", "New Plymouth", "Palmerston North", "Rotorua", "Tauranga", "Wellington", "Whanganui", "Whangarei", "", "South Island", "", "Christchurch", "Dunedin", "Invercargill", "Nelson"};
			listAdapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItem1, cities);
			lstCities.Adapter = listAdapter;

			lstCities.ItemClick += OnCitiesClick;
			btnExit.Click += OnBtnExitClick;
		}

		public void OnCitiesClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			string choosencity = Convert.ToString(lstCities.GetItemAtPosition (e.Position));
			Console.WriteLine (choosencity);
			var changecity = new Intent (this, typeof(MainActivity));

			if (choosencity == "North Island" || choosencity == "South Island" || choosencity == "") {
				//do nothing
			} else {
				try {
					objDatabase.RememberCity (choosencity);
					changecity.PutExtra ("city", choosencity);
					StartActivity (changecity);
					this.OverridePendingTransition(Resource.Drawable.slide_2_enter, Resource.Drawable.slide_2_exit);
				} catch (Exception ex) {
					Toast.MakeText (this, "Error: " + ex.Message, ToastLength.Long).Show ();
				}
			}
		}

		public void OnBtnExitClick (object sender, EventArgs e)
		{
			StartActivity (typeof(MainActivity));
			this.OverridePendingTransition(Resource.Drawable.slide_2_enter, Resource.Drawable.slide_2_exit);
		}
	}
}

