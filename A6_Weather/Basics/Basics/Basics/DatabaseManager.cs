using System;
using System.IO;
using System.Collections.Generic;

namespace Basics
{
	public class DatabaseManager
	{
		static string dbName = "dbCity.sqlite";
		string dbPath = Path.Combine (Android.OS.Environment.ExternalStorageDirectory.ToString (), dbName);

		public DatabaseManager ()
		{

		}

		public List<ToDo> GetCity()
		{
			try{
				using (var conn = new SQLite.SQLiteConnection (dbPath)) {
					var cmd = new SQLite.SQLiteCommand (conn);
					cmd.CommandText = "select * from tblCity where cityID=1";
					var NoteList = cmd.ExecuteQuery<ToDo> ();
					return NoteList;
				}
			} catch (Exception e) {
				Console.WriteLine ("Error:" + e.Message);
				return null;
			}
		}

		public void RememberCity(string name)
		{
			try{
				using (var conn = new SQLite.SQLiteConnection (dbPath)) {
					var cmd = new SQLite.SQLiteCommand (conn);
					cmd.CommandText = "update tblCity set name='" + name + "' where cityID=1";
					cmd.ExecuteNonQuery();
				}
			} catch (Exception e) {
				Console.WriteLine ("Error:" + e.Message);
			}
		}
	}
}

