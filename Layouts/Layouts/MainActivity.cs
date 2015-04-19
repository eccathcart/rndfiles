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
        TextView txtRegister;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            txtRegister = FindViewById<TextView>(Resource.Id.txtRegister);

            txtRegister.Click += OntxtRegisterClick;
        }

        public void OntxtRegisterClick(object sender, EventArgs e)
        {
            StartActivity(typeof(SecondActivity));
        }
    }
}

