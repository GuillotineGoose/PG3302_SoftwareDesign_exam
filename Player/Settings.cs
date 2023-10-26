using MiniGames.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGames.Player.DB;

namespace snake.games.SnakeGame {
	public sealed class Settings {
		static ConsoleColor _chosenSnakeColor;
		static String _player;
		public static void SettingsDisplay() {
			string input;



			Console.WriteLine("Choose snake color: " +
				" 1.Green " +
				" 2.Red " +
				" 3.Blue "
				);
			do {
				input = Console.ReadLine();
				if (input != "1" && input != "2" && input != "3") {
					Console.WriteLine("please choose 1 ,2 or 3");
				}
			} while (input != "1" && input != "2" && input != "3");


			switch (input) {
				case "1":

					_chosenSnakeColor = ConsoleColor.Green;


					break;
				case "2":
					_chosenSnakeColor = ConsoleColor.Red;
					

					break;
				case "3":
					_chosenSnakeColor = ConsoleColor.Blue;
					
					break;
			}
			Database.InsertSnakeColor(_chosenSnakeColor, _player);

			Console.WriteLine("You chose "+_chosenSnakeColor +" Great choice! please continue to game");


		}
		public static ConsoleColor SnakeColor() {
			return _chosenSnakeColor;
		}

		public static void LoadPlayer(String player) {
			_player = player;
			_chosenSnakeColor = Database.RetriveSnakeColor(player);

		}
	}
}
