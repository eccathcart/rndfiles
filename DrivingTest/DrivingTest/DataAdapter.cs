//
//using System;
//using System.Collections.Generic;
//using Android.App;
//using Android.Content;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using Android.OS;
//using Android.Graphics.Bitmap;

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
using Java.Net;
using Android.Graphics;
using Java.IO;
using Android.Graphics.Drawables;
using Android.Util;
using System.Net;
using System.IO;
using Parse;


namespace DrivingTest
{

	public class DataAdapter : BaseAdapter<Questions> {

		List<Questions> items;

		Activity context;
		public DataAdapter(Activity context, List<Questions> items)
			: base()
		{
			this.context = context;
			this.items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override Questions this[int position]
		{
			get { return items[position]; }
		}
		public override int Count
		{
			get { return items.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];
			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.Feed_item, null);

			view.FindViewById<TextView>(Resource.Id.txtQuestion).Text = item.Question;
			view.FindViewById<TextView> (Resource.Id.rbA1).Text = item.A;
			view.FindViewById<TextView> (Resource.Id.rbA2).Text = item.B;
			view.FindViewById<TextView> (Resource.Id.rbA3).Text = item.C;
			view.FindViewById<TextView> (Resource.Id.rbA4).Text = item.D;

			var pic = item.ImagePic;
			view.FindViewById<ImageView> (Resource.Id.profilePic).SetImageBitmap (GetImageBitmapFromUrl (pic.Url.AbsoluteUri));

			return view;
		}

		private Bitmap GetImageBitmapFromUrl(string url)
		{
			Bitmap imageBitmap = null;

			if (!(url == null))
				using (var webClient = new WebClient ()) {
					var imageBytes = webClient.DownloadData (url);
					if (imageBytes != null && imageBytes.Length > 0) {
						imageBitmap = BitmapFactory.DecodeByteArray (imageBytes, 0, imageBytes.Length);
					}
				}
			return imageBitmap;
		}
			
	}
}
