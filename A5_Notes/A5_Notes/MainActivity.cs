using System;
using System.IO;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace A5_Notes
{
	[Activity (Label = "A5_Notes", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation=Android.Content.PM.ScreenOrientation.Landscape)]
	public class MainActivity : Activity
	{
		//Button btnAdd;
		//Button btnEdit;
		//Button btnDelete;
		//Button btnPrevious;
		//Button btnNext;
		EditText txtSearch;
		ListView lstNotes;
		List<ToDo> myNotes;
		DatabaseManager objDb;
		static string dbName = "dbNotes.sqlite";
		string dbPath = Path.Combine (Android.OS.Environment.ExternalStorageDirectory.ToString (), dbName);

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			CopyDatabase ();

			objDb = new DatabaseManager ();
			myNotes = objDb.ViewAll ();

			lstNotes = FindViewById<ListView> (Resource.Id.lstNotes);
			txtSearch = FindViewById<EditText> (Resource.Id.txtSearch);
			//btnPrevious = FindViewById<Button> (Resource.Id.btnPrevious);
			//btnAdd = FindViewById<Button> (Resource.Id.btnAdd);
			//btnEdit = FindViewById<Button> (Resource.Id.btnEdit);
			//btnDelete = FindViewById<Button> (Resource.Id.btnDelete);
			//btnNext = FindViewById<Button> (Resource.Id.btnNext);

			lstNotes.Adapter = new DataAdapter (this, myNotes);

			txtSearch.TextChanged += OnSearching;
			lstNotes.ItemClick += OnNoteClick;
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

		public void OnNoteClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var ListNote = myNotes [e.Position];
			var editnote = new Intent (this, typeof(SecondActivity));

			editnote.PutExtra ("title", ListNote.title);
			editnote.PutExtra ("description", ListNote.description);
			editnote.PutExtra ("noteID", ListNote.noteID);

			StartActivity (editnote);
		}

		public void OnSearching(object sender, Android.Text.TextChangedEventArgs e)
		{
			if (txtSearch.Text == "") {
				myNotes = objDb.ViewAll ();
			} else {
				myNotes = objDb.SearchNotes (txtSearch.Text);
			}

			lstNotes.Adapter = new DataAdapter (this, myNotes);
		}

		protected override void OnResume()
		{
			base.OnResume ();
			myNotes = objDb.ViewAll ();
			lstNotes.Adapter = new DataAdapter (this, myNotes);
		}
	}
}


