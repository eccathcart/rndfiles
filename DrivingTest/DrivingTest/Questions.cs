using System;
using Parse;

namespace DrivingTest
{
	public class Questions
	{
		public string ObjectId { get; set; }
		public string Question { get; set; }
		public string A { get; set; }
		public string B { get; set; }
		public string C { get; set; }
		public string D { get; set; }
		public ParseFile ImagePic { get; set; }
		public string Answer { get; set; }

		public Questions ()
		{
		}
	}
}

