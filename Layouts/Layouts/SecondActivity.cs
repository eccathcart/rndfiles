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

namespace Layouts
{
    [Activity(Label = "SecondActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SecondActivity : Activity
    {
        TextView txtLogin;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            txtLogin = FindViewById<TextView>(Resource.Id.txtLogin);

            txtLogin.Click += OntxtLoginClick;
        }

        public void OntxtLoginClick(object sender, EventArgs e)
        {
            StartActivity(typeof(SecondActivity));
        }
    }
}