
using System;
using Android.App;
using Android.Runtime;
using Parse;

namespace DrivingTest
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

			ParseClient.Initialize ("9GNXsvrjgyzbtjx2BECMWX9yMUvyFHqWE9U7gN40", "bJtnmY0hnaW8I5fof9EI8ueh1VFvGMEIXVmRl7LE");
		}
	}
}

