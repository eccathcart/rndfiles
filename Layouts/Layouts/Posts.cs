
using System;
using Parse;

namespace Layouts
{		
	public class Posts
	{
		public string ObjectId { get; set; }
		public string Description { get; set; }
		public ParseFile Image { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public ParseUser ParseUser { get; set; }

		public Posts()
		{

		}
	}
}

