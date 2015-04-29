
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

			ParseClient.Initialize ("7FAfM4U99caBGd9hXohkNo2xYzC7eMSnF5Cjo49H", "dGKtGcCuUiBHl2Pm7rA0XOFhjiSyk3IMeBBGkVOw");
		}
	}
}

