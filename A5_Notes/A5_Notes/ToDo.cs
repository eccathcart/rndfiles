using System;
using SQLite;

namespace A5_Notes
{
		public class ToDo
		{

			[PrimaryKey, AutoIncrement]
			public int noteID { get; set; }
			public string title{ get; set; }
			public string description{ get; set; }
			public DateTime date { get; set;}

			public ToDo ()
			{
			}
		}
}

