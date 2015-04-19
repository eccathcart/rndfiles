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
using AndroidHUD;
using Android.Webkit;

namespace Basics
{
	[Activity (Label = "Basics", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		RESTHandler objRest;

		List<ImageView> lstImages = new List<ImageView> ();
		List<TextView> lstTextViews = new List<TextView> ();

		TextView txtCity;
		TextView txtTime;
		TextView txtTemperature;
		TextView txtDescription;
		TextView txtDate1;
		TextView txtDate2;
		TextView txtDate3;
		TextView txtDate4;
		TextView txtTemp1;
		TextView txtTemp2;
		TextView txtTemp3;
		TextView txtTemp4;

		ImageView imgWeather0;
		ImageView imgWeather1;
		ImageView imgWeather2;
		ImageView imgWeather3;
		ImageView imgWeather4;

		ImageButton btnChange;

		System.Timers.Timer t;

		List<ToDo> myCity;
		DatabaseManager objDb;

		string city;
		static string dbName = "dbCity.sqlite";
		string dbPath = Path.Combine (Android.OS.Environment.ExternalStorageDirectory.ToString (), dbName);

		protected override void OnCreate (Bundle bundle)
		{
			RequestWindowFeature(WindowFeatures.NoTitle);
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			CopyDatabase ();
			objDb = new DatabaseManager ();
			myCity = objDb.GetCity ();

			txtCity = FindViewById<TextView> (Resource.Id.txtCity);
			txtTime = FindViewById<TextView> (Resource.Id.txtTime);

			txtTemperature = FindViewById<TextView> (Resource.Id.txtTemperature);
			txtDescription = FindViewById<TextView> (Resource.Id.txtDescription);

			txtDate1 = FindViewById<TextView> (Resource.Id.txtDate1);
			txtDate2 = FindViewById<TextView> (Resource.Id.txtDate2);
			txtDate3 = FindViewById<TextView> (Resource.Id.txtDate3);
			txtDate4 = FindViewById<TextView> (Resource.Id.txtDate4);
			txtTemp1 = FindViewById<TextView> (Resource.Id.txtTemp1);
			txtTemp2 = FindViewById<TextView> (Resource.Id.txtTemp2);
			txtTemp3 = FindViewById<TextView> (Resource.Id.txtTemp3);
			txtTemp4 = FindViewById<TextView> (Resource.Id.txtTemp4);

			imgWeather0 = FindViewById<ImageView> (Resource.Id.imgWeather0);
			imgWeather1 = FindViewById<ImageView> (Resource.Id.imgWeather1);
			imgWeather2 = FindViewById<ImageView> (Resource.Id.imgWeather2);
			imgWeather3 = FindViewById<ImageView> (Resource.Id.imgWeather3);
			imgWeather4 = FindViewById<ImageView> (Resource.Id.imgWeather4);

			btnChange = FindViewById<ImageButton> (Resource.Id.btnChange);

			t = new System.Timers.Timer();
			t.Interval = 1000;
			t.Elapsed += AutoTime;
			t.Start ();

			btnChange.Click += OnBtnChangeClick;

			try {
			Console.WriteLine ("myCity isn't null: " + myCity[0].name);

			if (myCity[0].name == null) {
				LoadOneDayData ("Auckland");
				LoadFiveDaysData ("Auckland");
			} else {
				LoadOneDayData (Convert.ToString (myCity[0].name));
				LoadFiveDaysData (Convert.ToString (myCity[0].name));
			}
			} catch (Exception e) {
				Console.WriteLine ("ERROR: myCity is returning null / " + e.Message);
			}
		}

		public void AutoTime(object sender, System.Timers.ElapsedEventArgs e)
		{
			RunOnUiThread(() => {
				txtTime.Text = Convert.ToString(DateTime.Now.DayOfWeek) + ", " + DateTime.Now.ToString ("h:mm tt");
			});
		}

		public void OnBtnChangeClick(object sender, EventArgs e)
		{
			StartActivity (typeof(SecondActivity));
			this.OverridePendingTransition (Resource.Drawable.slide_1_enter, Resource.Drawable.slide_1_exit);
		}

		public async void LoadOneDayData(string cname)
		{
			try {
			AndHUD.Shared.Show (this, "Loading…");
			objRest = new RESTHandler (@"http://api.openweathermap.org/data/2.5/find?q=" + cname + ",NZ&units=metric&mode=xml&APPID=c994843656995893a09a3f2f8d1451cd");
			var ODResponse = await objRest.ExecuteOneDayAsync ();
				RunOnUiThread(() => {
			txtCity.Text = ODResponse.List.Item.City.Name;
				});
			txtTemperature.Text = Math.Round(Convert.ToDecimal(ODResponse.List.Item.Temperature.Value),0) + "°C";
			txtDescription.Text = ODResponse.List.Item.Weather.Value;
			
			if (ODResponse.List.Item.Weather.Icon == "01d") {
				imgWeather0.SetImageResource (Resource.Drawable.weather_clear);
			} else if (ODResponse.List.Item.Weather.Icon == "01n") {
				imgWeather0.SetImageResource (Resource.Drawable.weather_clear_night);
			}
			
			if (ODResponse.List.Item.Weather.Icon == "02d") {
			imgWeather0.SetImageResource (Resource.Drawable.weather_few_clouds);
			} else if (ODResponse.List.Item.Weather.Icon == "02n") {
			imgWeather0.SetImageResource (Resource.Drawable.weather_few_clouds_night);
			}

			if (ODResponse.List.Item.Weather.Icon == "03d") {
			imgWeather0.SetImageResource (Resource.Drawable.weather_clouds);
			} else if (ODResponse.List.Item.Weather.Icon == "03n") {
			imgWeather0.SetImageResource (Resource.Drawable.weather_clouds_night);
			}

			if (ODResponse.List.Item.Weather.Icon == "04d") {
			imgWeather0.SetImageResource (Resource.Drawable.weather_clouds);
			} else if (ODResponse.List.Item.Weather.Icon == "04n") {
			imgWeather0.SetImageResource (Resource.Drawable.weather_clouds_night);
			}

			if (ODResponse.List.Item.Weather.Icon == "09d" || ODResponse.List.Item.Weather.Icon == "09n") {
			imgWeather0.SetImageResource (Resource.Drawable.weather_showers_scattered_day);
			} 

			if (ODResponse.List.Item.Weather.Icon == "10d") {
			imgWeather0.SetImageResource (Resource.Drawable.weather_showers_day);
			} else if (ODResponse.List.Item.Weather.Icon == "10n") {
			imgWeather0.SetImageResource (Resource.Drawable.weather_showers_night);
			}

			if (ODResponse.List.Item.Weather.Icon == "11d" || ODResponse.List.Item.Weather.Icon == "11n") {
			imgWeather0.SetImageResource (Resource.Drawable.weather_storm);
			} 

			if (ODResponse.List.Item.Weather.Icon == "13d" || ODResponse.List.Item.Weather.Icon == "13n") {
			imgWeather0.SetImageResource (Resource.Drawable.weather_snow);
			} 

			if (ODResponse.List.Item.Weather.Icon == "50d" || ODResponse.List.Item.Weather.Icon == "50n") {
			imgWeather0.SetImageResource (Resource.Drawable.weather_mist);
			}

			AndHUD.Shared.Dismiss(this);
			} catch (Exception e) {
				Console.WriteLine ("OneDay Error: " + e.Message);
			}

		}

		protected async void LoadFiveDaysData(string cname)
		{
			try {
				AndHUD.Shared.Show (this, "Loading…");
				objRest = new RESTHandler (@"http://api.openweathermap.org/data/2.5/forecast/daily?q=" + cname + ",NZ&units=metric&mode=xml&APPID=c994843656995893a09a3f2f8d1451cd");
				var Response = await objRest.ExecuteFiveDaysAsync ();

				txtTemp1.Text = Math.Round(Convert.ToDecimal(Response.Forecast.Time [1].Temperature.Max), 0) + "°C / " + Math.Round(Convert.ToDecimal(Response.Forecast.Time [1].Temperature.Min),0) + "°C";
				txtTemp2.Text = Math.Round(Convert.ToDecimal(Response.Forecast.Time [2].Temperature.Max), 0) + "°C / " + Math.Round(Convert.ToDecimal(Response.Forecast.Time [2].Temperature.Min),0) + "°C";
				txtTemp3.Text = Math.Round(Convert.ToDecimal(Response.Forecast.Time [3].Temperature.Max), 0) + "°C / " + Math.Round(Convert.ToDecimal(Response.Forecast.Time [3].Temperature.Min),0) + "°C";
				txtTemp4.Text = Math.Round(Convert.ToDecimal(Response.Forecast.Time [4].Temperature.Max), 0) + "°C / " + Math.Round(Convert.ToDecimal(Response.Forecast.Time [4].Temperature.Min),0) + "°C";

				txtDate1.Text = Convert.ToDateTime(Response.Forecast.Time[1].Day).ToString("dd/MM");
				txtDate2.Text = Convert.ToDateTime(Response.Forecast.Time[2].Day).ToString("dd/MM");
				txtDate3.Text = Convert.ToDateTime(Response.Forecast.Time[3].Day).ToString("dd/MM");
				txtDate4.Text = Convert.ToDateTime(Response.Forecast.Time[4].Day).ToString("dd/MM");
				
				lstImages.Add(imgWeather0);
				lstImages.Add(imgWeather1);
				lstImages.Add(imgWeather2);
				lstImages.Add(imgWeather3);
				lstImages.Add(imgWeather4);

				lstTextViews.Add(txtTime);
				lstTextViews.Add(txtDate1);
				lstTextViews.Add(txtDate2);
				lstTextViews.Add(txtDate3);
				lstTextViews.Add(txtDate4);

				for (int i = 1; i < 5; i++) {
					if(Response.Forecast.Time[i].Symbol.Var == "01d") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_clear);
					} else if(Response.Forecast.Time[i].Symbol.Var == "01n") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_clear);
					}

					if(Response.Forecast.Time[i].Symbol.Var == "02d") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_few_clouds);
					} else if(Response.Forecast.Time[i].Symbol.Var == "02n") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_few_clouds);
					}

					if(Response.Forecast.Time[i].Symbol.Var == "03d") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_clouds);
					} else if(Response.Forecast.Time[i].Symbol.Var == "03n") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_clouds);
					}

					if(Response.Forecast.Time[i].Symbol.Var == "04d") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_clouds);
					} else if(Response.Forecast.Time[i].Symbol.Var == "04n") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_clouds);
					}

					if(Response.Forecast.Time[i].Symbol.Var == "09d" || Response.Forecast.Time[i].Symbol.Var == "09n") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_showers_scattered_day);
					}

					if(Response.Forecast.Time[i].Symbol.Var == "10d") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_showers_day);
					} else if(Response.Forecast.Time[i].Symbol.Var == "10n") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_showers_day);
					}

					if (Response.Forecast.Time[i].Symbol.Var == "11d" || Response.Forecast.Time[i].Symbol.Var == "11d") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_storm);
					} 
		
					if (Response.Forecast.Time[i].Symbol.Var == "13d" || Response.Forecast.Time[i].Symbol.Var == "13d") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_snow);
					} 
		
					if (Response.Forecast.Time[i].Symbol.Var == "50d" || Response.Forecast.Time[i].Symbol.Var == "50d") {
						lstImages[i].SetImageResource(Resource.Drawable.weather_mist);
					}

					if (Convert.ToString(Convert.ToDateTime(Response.Forecast.Time[i].Day).DayOfWeek) == "Monday") {
						lstTextViews[i].Text = "Mon";
					}

					if (Convert.ToString(Convert.ToDateTime(Response.Forecast.Time[i].Day).DayOfWeek) == "Tuesday") {
						lstTextViews[i].Text = "Tue";
					}

					if (Convert.ToString(Convert.ToDateTime(Response.Forecast.Time[i].Day).DayOfWeek) == "Wednesday") {
						lstTextViews[i].Text = "Wed";
					}

					if (Convert.ToString(Convert.ToDateTime(Response.Forecast.Time[i].Day).DayOfWeek) == "Thursday") {
						lstTextViews[i].Text = "Thu";
					}

					if (Convert.ToString(Convert.ToDateTime(Response.Forecast.Time[i].Day).DayOfWeek) == "Friday") {
						lstTextViews[i].Text = "Fri";
					}

					if (Convert.ToString(Convert.ToDateTime(Response.Forecast.Time[i].Day).DayOfWeek) == "Saturday") {
						lstTextViews[i].Text = "Sat";
					}

					if (Convert.ToString(Convert.ToDateTime(Response.Forecast.Time[i].Day).DayOfWeek) == "Sunday") {
						lstTextViews[i].Text = "Sun";
					}
				}
				AndHUD.Shared.Dismiss(this);
			} catch (Exception e) {
			Console.WriteLine ("FiveDays Error: " + e.Message);
			}
		}

		protected override void OnResume()
		{
			base.OnResume ();

			city = Intent.GetStringExtra ("city");
			if (city != null) {
				Console.WriteLine ("Intent: " + city);
				Console.Write ("Successfully edited: " + myCity [0].name);
				LoadOneDayData (city);
				LoadFiveDaysData (city);
			}
		}

		public void CopyDatabase()
		{
			if (!File.Exists (dbPath)) 
			{
				using (BinaryReader br = new BinaryReader(Assets.Open(dbName)))
				{
					using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
					{
						byte[] buffer = new byte[2048];
						int len = 0;
						while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
						{
							bw.Write(buffer,0,len);
						}
					}
				}
			}
		}
	}
}


