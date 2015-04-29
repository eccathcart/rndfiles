
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
using Android.Graphics.Drawables;
using System.IO;
using Android.Graphics;

namespace Layouts
{
	[Activity (Label = "FeedActivity")]			
	public class FeedActivity : Activity
	{
		ParseHandler objParse = ParseHandler.Default;
		ListView FeedList;
		Button btnAddPost;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.ListActivity);

			FeedList = FindViewById<ListView> (Resource.Id.Feedlist);
			btnAddPost = FindViewById<Button> (Resource.Id.btnNewPost);
			LoadFeeds ();

			btnAddPost.Click += OnAddPostClick;
		}

		private async void LoadFeeds()
		{
			List<Posts> postlist = await objParse.GetAllPosts ();
			FeedList.Adapter = new DataAdapter (this, postlist);
		}

		public void OnAddPostClick (object sender, EventArgs e)
		{
			StartActivity (typeof(AddPosts));
		}
	}
}

