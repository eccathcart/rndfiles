using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Linq;
using Android.Locations;

namespace GPSMaps
{
	[Activity (Label = "GPSMaps", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity , ILocationListener
	{
		LocationManager locMgr;
		EditText txtLat;
		EditText txtLong;
		EditText txtAddress;
		Button btnGetLocation;
		Button btnGetAddress;
		Button btnOpenMap;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			txtLat = FindViewById<EditText> (Resource.Id.txtLat);
			txtLong = FindViewById<EditText> (Resource.Id.txtLong);
			txtAddress = FindViewById<EditText> (Resource.Id.txtAddress);

			btnGetLocation = FindViewById<Button> (Resource.Id.btnGetLocation);
			btnGetAddress = FindViewById<Button> (Resource.Id.btnGetAddress);
			btnOpenMap = FindViewById<Button> (Resource.Id.btnShowinMap);

			btnGetLocation.Click += GetLocation;
			btnGetAddress.Click += GetAddress;
			btnOpenMap.Click += OpenMapActivity;
		}

		protected override void OnResume()
		{
			base.OnResume ();

			locMgr = GetSystemService (Context.LocationService) as LocationManager;
		}

		protected override void OnPause()
		{
			base.OnPause ();

			locMgr.RemoveUpdates (this);
		}

		void GetLocation (object sender, EventArgs e)
		{
			Criteria locationCriteria = new Criteria ();

			locationCriteria.Accuracy = Accuracy.Coarse;
			locationCriteria.PowerRequirement = Power.Medium;

			string locationProvider = locMgr.GetBestProvider (locationCriteria, true);

			if (locationProvider != null) {
				locMgr.RequestLocationUpdates (locationProvider, 2000, 1, this);
				Toast.MakeText (this, "Provider: " + locationProvider, ToastLength.Short).Show ();
			} else {
				Toast.MakeText (this, "No location providers available.", ToastLength.Short).Show ();
			}
		}

		public void OnLocationChanged (Android.Locations.Location location)
		{
			txtLat.Text = location.Latitude.ToString ();
			txtLong.Text = location.Longitude.ToString ();
		}

		public void OnProviderEnabled (string provider)
		{
			Toast.MakeText (this, "Provider Enabled", ToastLength.Short).Show ();
		}

		public void OnProviderDisabled (string provider)
		{
			Toast.MakeText (this, "Provider Disabled.", ToastLength.Short).Show ();
		}

		public void OnStatusChanged (string provider, Availability status, Bundle extras)
		{
			Toast.MakeText (this, "Provider status " + status.ToString(),ToastLength.Short).Show ();
		}

		private async void GetAddress (object sender, EventArgs e)
		{
			var geo = new Geocoder (this);
			var address = await geo.GetFromLocationAsync (Convert.ToDouble (txtLat.Text), Convert.ToDouble (txtLong.Text), 1);

			if (address.Count > 0) {
				address.ToList ().ForEach (addr => txtAddress.Text = addr.GetAddressLine (0) + "\n" + addr.GetAddressLine (1) + "\n" + addr.GetAddressLine (2));
			} else {
				Toast.MakeText (this, "No address found", ToastLength.Short).Show ();
			}
		}

		void OpenMapActivity (object sender, EventArgs e)
		{
			var mapactivity = new Intent (this, typeof(MapActivity));
			mapactivity.PutExtra ("Latitude", txtLat.Text);
			mapactivity.PutExtra ("Longitude", txtLong.Text);
			mapactivity.PutExtra ("Address", txtAddress.Text);
			StartActivity (mapactivity);
		}
	}
}


