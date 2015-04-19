using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace A6_Weather
{
	[Activity (Label = "A6_Weather", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		TextView txtCity;
		TextView txtTime;

		System.Timers.Timer t;

		RESTHandler objRest;
		RootObject objRootData;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			txtCity = FindViewById<TextView> (Resource.Id.txtCity);
			txtTime = FindViewById<TextView> (Resource.Id.txtTime);

			t = new System.Timers.Timer();
			t.Interval = 1000;
			t.Elapsed += AutoTime;
			t.Start ();

			GetWeatherData ();
		}

		public void AutoTime(object sender, System.Timers.ElapsedEventArgs e)
		{
			Console.WriteLine (DateTime.Now.ToString ("h:mm:ss tt"));
			txtTime.Text = DateTime.Now.ToString ("h:mm:ss tt");
		}

		public async void GetWeatherData()
		{
			try {
				objRest = new RESTHandler (@"http://api.openweathermap.org/data/2.5/find?q=hamilton,NZ&units=metric&mode=json&APPID=c994843656995893a09a3f2f8d1451cd");

				objRest.AddParameter ("q", "hamilton,nz");
				objRest.AddParameter("units", "metric");
				objRest.AddParameter ("mode", "json");
				objRest.AddParameter ("APPID", "c994843656995893a09a3f2f8d1451cd");

				objRootData = await objRest.ExecuteRequestAsync();

				txtCity.Text = objRootData.name;

				Console.WriteLine(objRootData.name);
				Console.WriteLine(245245246426 + 653663556);
			} catch (Exception e) {
				Toast.MakeText (this, "Error: " + e.Message, ToastLength.Long);
				Console.WriteLine ("ERROR:" + e.Message);
			}
		}
	}
}