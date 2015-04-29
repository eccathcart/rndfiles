
using System;
using System.Collections.Generic;
using System.Linq;
using Parse;
using System.Threading.Tasks;

namespace Layouts
{		
	public class ParseHandler
	{
		static ParseHandler todoServiceInstance = new ParseHandler();
		public static ParseHandler Default { get { return todoServiceInstance; } }
		private ParseHandler() { }
		public List<Posts> Items { get; private set; }

		public async Task CreateUserAsync (string username, string email, string password,byte[] profilepic)
		{
			if (username != "" && email != "" && password != "" && profilepic != null) {
				ParseFile file = new ParseFile ("avatar.jpg", profilepic);

				try {
				await file.SaveAsync ();
				} catch (Exception ex) {
					Console.WriteLine ("Error: " + ex.Message);
				}

				var user = new ParseUser () {
					Username = username,
					Password = password,
					Email = email
				};

				user ["ProfilePic"] = file;
				try {
					await user.SignUpAsync ();
				} catch (Exception ex) {
					Console.WriteLine ("Error: " + ex.Message);
				}
			}
		}

		public async Task<Boolean> CheckIfUserNameExists (string username)
		{
			var query = ParseUser.Query;
			var queryresult = await query.WhereEqualTo ("username", username).FindAsync ();

			if (queryresult.ToList ().Count > 0) {
				return true;
			} else {
				return false;
			}
		}

		public async Task<Boolean> Login(string username, string password)
		{
			try{
				await ParseUser.LogInAsync(username, password);
				return true;
			} catch (Exception e) {
				Console.WriteLine ("Login Failed: " + e.Message);
				return false;
			}
		}

		public async Task<Boolean> AddToDoItem(string ItemDescription)
		{
			ParseObject ToDo = new ParseObject ("ToDo");
			ToDo ["ItemDescription"] = ItemDescription;
			ToDo ["User"] = ParseUser.CurrentUser;

			try{
				await ToDo.SaveAsync();
				return true;
			} catch (Exception e) {
				Console.WriteLine ("Error: " + e.Message);
				return false;
			}
		}

		public async Task<List<Posts>> GetAllPosts()
		{
			var query = ParseObject.GetQuery ("Post");
			var result = await query.FindAsync ();

			var PostList = new List<Posts> ();

			foreach (var obj in result) {
				Posts tempobj = new Posts ();

				tempobj.ObjectId = obj.ObjectId;
				tempobj.CreatedAt = obj.CreatedAt;
				tempobj.UpdatedAt = obj.UpdatedAt;

				ParseUser usrobj = obj.Get<ParseUser> ("User");
				tempobj.ParseUser = await usrobj.FetchIfNeededAsync ();

				tempobj.Image = obj.Get<ParseFile> ("Image");
				tempobj.Description = Convert.ToString (obj ["Description"]);

				PostList.Add (tempobj);
			}

			return PostList;
		}

		public ParseUser GetCurrentUserInstance()
		{
			return ParseUser.CurrentUser;
		}

		public async void DeleteItem(ToDo ToDoItem)
		{
			ParseObject ToDo = new ParseObject ("ToDo");

			ToDo.ObjectId = ToDoItem.ObjectId;
			ToDo["ItemDescription"] = ToDoItem.ItemDescription;
			ToDo ["User"] = ParseUser.CurrentUser;

			try {
				await ToDo.DeleteAsync();
			} catch (Exception e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
			}
		}

		public async Task<Boolean> AddPost (string Description, byte[] Postpic)
		{
			try {
				ParseFile file = new ParseFile("postpic.jpg",Postpic);
				await file.SaveAsync();

				ParseObject Post = new ParseObject("Post");
				Post["Description"] = Description;
				Post["Image"] = file;
				Post["User"] = ParseUser.CurrentUser;

				await Post.SaveAsync();
				return true;
			} catch (Exception e) {
				Console.WriteLine ("Error: " + e.Message);
				return false;
			}
		}
	}
}

