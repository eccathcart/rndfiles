
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

		public async Task CreateUserAsync (string username, string email, string password)
		{
			if (username != "" && email != "" && password != "") {
				var user = new ParseUser () {
					Username = username,
					Password = password,
					Email = email
				};

				await user.SignUpAsync ();
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
	}
}

