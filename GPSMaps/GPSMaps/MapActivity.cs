
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
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace GPSMaps
{
	[Activity (Label = "MapActivity")]			
	public class MapActivity : Activity
	{
		GoogleMap map;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Map);

			MapFragment mapFrag = (MapFragment)FragmentManager.FindFragmentById (Resource.Id.map);
			map = mapFrag.Map;

			if (map != null) {
				MarkerOptions opt1 = new MarkerOptions ();

				double lat = Convert.ToDouble (Intent.GetStringExtra ("Latitude"));
				double lng = Convert.ToDouble (Intent.GetStringExtra ("Longitude"));
				string address = Intent.GetStringExtra ("Address");

				LatLng location = new LatLng (lat, lng);
				opt1.SetPosition (location);
				opt1.SetTitle (address);
				map.AddMarker (opt1);

				CameraPosition.Builder builder = CameraPosition.InvokeBuilder ();
				builder.Target (location);
				builder.Zoom (15);

				CameraPosition cameraPosition = builder.Build ();
				CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition (cameraPosition);

				map.MoveCamera (cameraUpdate);
			}
		}
	}
}

