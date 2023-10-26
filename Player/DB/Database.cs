using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MiniGames.Player.DB {
	internal class Database {
		public static void createDb() {
			try {
				using SqliteConnection connection = new("Data Source = playerSqlite.db");
				connection.Open();
				var command = connection.CreateCommand();
				command.CommandText = @"
				CREATE TABLE players(
					name TEXT NOT NULL PRIMARY KEY,
					snake INTEGER,
					snakeColor VARCHAR(50) DEFAULT 'Red'
			);	
			";

				command.ExecuteNonQuery();
			}
			catch {
			}
		}

		public static void InsertPlayer(string name) {
			using SqliteConnection connection = new("Data Source = playerSqlite.db");
			connection.Open();
			var command = connection.CreateCommand();
			command.CommandText = @"
				INSERT INTO players (name)
				VALUES ($name);
			";

			command.Parameters.AddWithValue("$name", name);
			command.ExecuteNonQuery();
			connection.Close();
		}

		public static void InsertScore(string name, string gameType, int score) {

			using SqliteConnection connection = new("Data Source = playerSqlite.db");
			connection.Open();
			var command = connection.CreateCommand();
			command.CommandText = @"
				UPDATE players 
				SET " + gameType + @" = $score
				WHERE name = $name
			";

			command.Parameters.AddWithValue("$name", name);
			command.Parameters.AddWithValue("$score", score);
			command.ExecuteNonQuery();
			connection.Close();
		}

		public static String RetrivePlayer(string name) {
			var RetrivedPlayer = "";
			using SqliteConnection connection = new("Data Source = playerSqlite.db");
			connection.Open();
			var command = connection.CreateCommand();
			command.CommandText = @"
				SELECT name From players
				WHERE name = $name
			";
			command.Parameters.AddWithValue("$name", name);
			using var reader = command.ExecuteReader();
			if (reader.Read()) {
				RetrivedPlayer = reader.GetString(0);
			}
			connection.Close();
			return RetrivedPlayer;
		}

		public static int RetriveScore(string name, string gameType) {
			int RetrivedScore = 0;

			using SqliteConnection connection = new("Data Source = playerSqlite.db");
			connection.Open();
			var command = connection.CreateCommand();
			command.CommandText = @"
				SELECT " + gameType + @" From players
				WHERE name = $name
			";

			command.Parameters.AddWithValue("$name", name);
			using var reader = command.ExecuteReader();
			if (reader.Read()) {
				RetrivedScore = reader.GetInt32(0);
			}
			connection.Close();
			return RetrivedScore;
		}

		public static void InsertSnakeColor(ConsoleColor color, String name) {
			using SqliteConnection connection = new("Data Source = playerSqlite.db");
			connection.Open();
			var command = connection.CreateCommand();
			command.CommandText = @"
				UPDATE players set snakeColor = ($color)
				WHERE name = ($name);
			";

			command.Parameters.AddWithValue("$name", name);
			command.Parameters.AddWithValue("$color", (color.ToString()));
			command.ExecuteNonQuery();
			connection.Close();

		}
		public static ConsoleColor RetriveSnakeColor(string name) {
			var RetrivedColor = "";
			using SqliteConnection connection = new("Data Source = playerSqlite.db");
			connection.Open();
			var command = connection.CreateCommand();
			command.CommandText = @"
				SELECT snakeColor From players
				WHERE name = $player
			";
			command.Parameters.AddWithValue("$player", name);
			using var reader = command.ExecuteReader();
			if (reader.Read()) {
				RetrivedColor = reader.GetString(0);
			}
			connection.Close();
			return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), RetrivedColor);
		}





		public static void dropDb() {
			using SqliteConnection connection = new("Data Source = playerSqlite.db");
			connection.Open();
			var command = connection.CreateCommand();
			command.CommandText = @"
				DROP TABLE players;
			";
			command.ExecuteNonQuery();
			connection.Close();
		}




	}
}
