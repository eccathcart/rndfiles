using System;
using System.IO;
using System.Collections.Generic;

namespace A5_Notes
{
	public class DatabaseManager
	{
		static string dbName = "dbNotes.sqlite";
		string dbPath = Path.Combine (Android.OS.Environment.ExternalStorageDirectory.ToString (), dbName);

		public DatabaseManager ()
		{

		}

		public List<ToDo> ViewAll()
		{
			try{
				using (var conn = new SQLite.SQLiteConnection (dbPath)) {
					var cmd = new SQLite.SQLiteCommand (conn);
					cmd.CommandText = "select * from tblNotes";
					var NoteList = cmd.ExecuteQuery<ToDo> ();
					return NoteList;
				}
			} catch (Exception e) {
				Console.WriteLine ("Error:" + e.Message);
				return null;
			}
		}

		public List<ToDo> SearchNotes(string title)
		{
			try{
				using (var conn = new SQLite.SQLiteConnection (dbPath)) {
					var cmd = new SQLite.SQLiteCommand (conn);
					cmd.CommandText = "select * from tblNotes where title like '%" + title + "%'";
					var NoteList = cmd.ExecuteQuery<ToDo> ();
					return NoteList;
				}
			} catch (Exception e) {
				Console.WriteLine ("Error:" + e.Message);
				return null;
			}
		}

		public void AddNote(string title, string description)
		{
			try{
				using (var conn = new SQLite.SQLiteConnection (dbPath)) {
					var cmd = new SQLite.SQLiteCommand (conn);
					cmd.CommandText = "insert into tblNotes(title,description) values ('" + title + "','" + description + "')";
					cmd.ExecuteNonQuery();
				}
			} catch (Exception e) {
				Console.WriteLine ("Error:" + e.Message);
			}
		}

		public void EditNote(string title, string description, int noteid)
		{
			try{
				using (var conn = new SQLite.SQLiteConnection (dbPath)) {
					var cmd = new SQLite.SQLiteCommand (conn);
					cmd.CommandText = "update tblNotes set title='" + title + "', description='" + description + "' where noteID='" + noteid + "'";
					cmd.ExecuteNonQuery();
				}
			} catch (Exception e) {
				Console.WriteLine ("Error:" + e.Message);
			}
		}

		public void DeleteNote(int noteid)
		{
			try{
				using (var conn = new SQLite.SQLiteConnection (dbPath)) {
					var cmd = new SQLite.SQLiteCommand (conn);
					cmd.CommandText = "delete from tblNotes where noteID='" + noteid + "'";
					cmd.ExecuteNonQuery();
				}
			} catch (Exception e) {
				Console.WriteLine ("Error:" + e.Message);
			}
		}

		public List<ToDo> PreviousNote(int noteid)
		{
			try{
				using (var conn = new SQLite.SQLiteConnection (dbPath)) {
					var cmd = new SQLite.SQLiteCommand (conn);
					cmd.CommandText = "select * from tblNotes WHERE noteID >" + noteid;
					var NoteList = cmd.ExecuteQuery<ToDo> ();
					return NoteList;
				}
			} catch (Exception e) {
				Console.WriteLine ("Error:" + e.Message);
				return null;
			}
		}

		public List<ToDo> NextNote(int noteid)
		{
			try{
				using (var conn = new SQLite.SQLiteConnection (dbPath)) {
					var cmd = new SQLite.SQLiteCommand (conn);
					cmd.CommandText = "select * from tblNotes WHERE noteID <" + noteid;
					var NoteList = cmd.ExecuteQuery<ToDo> ();
					return NoteList;
				}
			} catch (Exception e) {
				Console.WriteLine ("Error:" + e.Message);
				return null;
			}
		}
	}
}

