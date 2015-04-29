
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

namespace A5_Notes
{
	[Activity (Label = "SecondActivity")]			
	public class SecondActivity : Activity
	{
		Button btnAdd;
		Button btnEdit;
		Button btnDelete;
		Button btnPrevious;
		Button btnNext;
		EditText txtTitle;
		EditText txtDescription;
		DatabaseManager objDB;

		int noteID;
		string title;
		string description;
		bool btnEditClicked;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.NoteDetails);

			txtTitle = FindViewById<EditText> (Resource.Id.txtTitle);
			txtDescription = FindViewById<EditText> (Resource.Id.txtDescription);
			//btnPrevious = FindViewById<Button> (Resource.Id.btnPrevious);
			//btnAdd = FindViewById<Button> (Resource.Id.btnAdd);
			//btnEdit = FindViewById<Button> (Resource.Id.btnEdit);
			//btnDelete = FindViewById<Button> (Resource.Id.btnDelete);
			//btnNext = FindViewById<Button> (Resource.Id.btnNext);

			//btnPrevious.Click += OnBtnPreviousClick;
			//btnAdd.Click += OnBtnAddClick;
			//btnEdit.Click += OnBtnEditClick;
			//btnDelete.Click += OnBtnDeleteClick;
			//btnNext.Click += OnBtnNextClick;

			noteID = Intent.GetIntExtra ("noteID", 0);
			description = Intent.GetStringExtra ("description");
			title = Intent.GetStringExtra ("title");

			txtTitle.Text = title;
			txtDescription.Text = description;
			objDB = new DatabaseManager ();

			EnableDisable ();
		}

		public void EnableDisable ()
		{
			if (btnEditClicked == true) {
				txtTitle.Enabled = true;
				txtDescription.Enabled = true;
			} else {
				txtTitle.Enabled = false;
				txtDescription.Enabled = false;
			}
		}

		public void OnBtnEditClick (object sender, EventArgs e)
		{
			btnEditClicked = true;

			EnableDisable ();
		}
	}
}

