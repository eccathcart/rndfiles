
using System;
using System.Collections.Generic;
using System.Linq;
using Parse;
using System.Threading.Tasks;

namespace DrivingTest
{		
	public class ParseHandler
	{
		static ParseHandler todoServiceInstance = new ParseHandler();
		public static ParseHandler Default { get { return todoServiceInstance; } }
		private ParseHandler() { }
		public List<Questions> Items { get; private set; }

		public async Task<List<Questions>> GetAllQuestions()
		{
			var query = ParseObject.GetQuery ("Question");
			var result = await query.FindAsync ();

			var QuestionList = new List<Questions> ();

			foreach (var obj in result) {
				Questions tempobj = new Questions ();

				tempobj.ObjectId = obj.ObjectId;

				tempobj.Question = Convert.ToString (obj ["Question"]);

				tempobj.ImagePic = obj.Get<ParseFile> ("ImagePic");

				tempobj.A = Convert.ToString (obj ["A"]);
				tempobj.B = Convert.ToString (obj ["B"]);
				tempobj.C = Convert.ToString (obj ["C"]);
				tempobj.D = Convert.ToString (obj ["D"]);

				tempobj.Answer = Convert.ToString (obj ["Answer"]);

				QuestionList.Add (tempobj);
			}

			return QuestionList;
		}
	}
}

