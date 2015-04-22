
using System;
using Android.App;
using Android.Runtime;
using Parse;

namespace Layouts
{
	[Application]			
	public class App : Application
	{

		public App (IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			ParseClient.Initialize ("9stoAGBYWnw4omqqlqMbABB1Pgqh755d5RCWxpta", "lGfDgvrWtTv4NYtU2dg6evWYlHAfzeaNo5REipSo");
		}
	}
}

