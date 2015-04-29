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


namespace A5_Notes
{

	public class DataAdapter : BaseAdapter<ToDo> {

		List<ToDo> notes;

		Activity context;
		public DataAdapter(Activity context, List<ToDo> notes)
			: base()
		{
			this.context = context;
			this.notes = notes;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override ToDo this[int position]
		{
			get { return notes[position]; }
		}
		public override int Count
		{
			get { return notes.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var note = notes[position];
			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);

			view.FindViewById<TextView>(Resource.Id.lbltitle).Text = note.title;
			view.FindViewById<TextView> (Resource.Id.lbldescription).Text = note.description;
			return view;
		}
			
	}
}
