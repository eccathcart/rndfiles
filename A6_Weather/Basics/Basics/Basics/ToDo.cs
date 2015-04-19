using System;
using SQLite;

namespace Basics
{
		public class ToDo
		{

			[PrimaryKey, AutoIncrement]
			public int cityID { get; set; }
			public string name{ get; set; }

			public ToDo ()
			{
			}
		}
}

