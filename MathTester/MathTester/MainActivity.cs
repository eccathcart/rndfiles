using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MathTester
{
	[Activity (Label = "MathTester", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		TextView lblNum1;
		TextView lblNum2;
		TextView lblOperator;
		RadioGroup rbGroup;
		RadioButton rbA1;
		RadioButton rbA2;
		RadioButton rbA3;
		RadioButton rbA4;
		Button btnGo;
		int answer;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			InitializeControls ();
			RandomEquation ();
		}

		public void InitializeControls ()
		{
			lblNum1 = FindViewById<TextView> (Resource.Id.lblNum1);
			lblNum2 = FindViewById<TextView> (Resource.Id.lblNum2);
			lblOperator = FindViewById<TextView> (Resource.Id.lblOperator);

			rbGroup = FindViewById<RadioGroup> (Resource.Id.rbGroup);
			rbA1 = FindViewById<RadioButton> (Resource.Id.rbA1);
			rbA2 = FindViewById<RadioButton> (Resource.Id.rbA2);
			rbA3 = FindViewById<RadioButton> (Resource.Id.rbA3);
			rbA4 = FindViewById<RadioButton> (Resource.Id.rbA4);

			btnGo = FindViewById<Button> (Resource.Id.btnGo);

			btnGo.Click += OnBtnGoClick;
		}

		public void RandomEquation()
		{
			var rnd = new Random();
			var number1 = rnd.Next(1,12);
			var number2 = rnd.Next(1,12);
			var rndAnswer1 = rnd.Next (0, 145);
			var rndAnswer2 = rnd.Next (0, 145);
			var rndAnswer3 = rnd.Next (0, 145);
			var rndAnswer4 = rnd.Next (0,145);
			var operation = rnd.Next (1, 4);
			string operationString;


			switch (operation) {
			case 1:
				answer = number1 + number2;
				operationString = "+";
				break;
			case 2:
				answer = number1 - number2;
				operationString = "-";
				break;
			case 3:
				answer = number1 * number2;
				operationString = "*";
				break;
			case 4:
				answer = number1 / number2;
				operationString = "/";
				break;
			default:
				answer = 0;
				operationString = "An error has occurred.";
				break;
			}

			lblNum1.Text = Convert.ToString(number1);
			lblNum2.Text = Convert.ToString(number2);
			lblOperator.Text = operationString;

			rbA1.Text = Convert.ToString(rndAnswer1);
			rbA2.Text = Convert.ToString(rndAnswer2);
			rbA3.Text = Convert.ToString(rndAnswer3);
			rbA4.Text = Convert.ToString(rndAnswer4);

			View v = rbGroup.GetChildAt (operation);
			RadioButton test = (RadioButton)v;
			test.Text = Convert.ToString(answer);
		}

		void OnBtnGoClick (object sender, EventArgs e)
		{
			if (rbA1.Text == Convert.ToString(answer) && rbA1.Checked) {
				Toast.MakeText (this, "Correct!", ToastLength.Long).Show ();
				RandomEquation ();
			} else if (rbA2.Text == Convert.ToString(answer) && rbA2.Checked) {
				Toast.MakeText (this, "Correct!", ToastLength.Long).Show ();
				RandomEquation ();
			} else if (rbA3.Text == Convert.ToString(answer) && rbA3.Checked) {
				Toast.MakeText (this, "Correct!.", ToastLength.Long).Show ();
				RandomEquation ();
			} else if (rbA4.Text == Convert.ToString(answer) && rbA4.Checked) {
				Toast.MakeText (this, "Correct!", ToastLength.Long).Show ();
				RandomEquation ();
			} else {
				Toast.MakeText (this, "Sorry, that's not the correct answer.", ToastLength.Long).Show ();
				RandomEquation ();
			}
		}
	}
}


