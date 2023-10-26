using snake.games.SnakeGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGames.Player 
{
	internal class Player
	{
		public static void Login() 
		{
			string input;

		tryagain:
			Console.WriteLine("Welcome to MiniGames!" + "\n" 
				+ "Choose an option:" + "\n" + 
				" (1) Login " + "\n" +
				" (2) Register" + "\n");
			do
			{
				input = Console.ReadLine();
				if (input != "1" && input != "2")
				{
					Console.WriteLine("Please input 1 for login or 2 for register");
				}
			} while (input != "1" && input != "2");



			switch (input)
			{
				case "1":
				Console.WriteLine("\n" + "Please write your name");
				input = Console.ReadLine();

				//name = DB.Database.RetrivePlayer(name);

				if (input != DB.Database.RetrivePlayer(input))
				{
					Console.WriteLine("\n" + "Couldn't find " + input + ", if the username does not exist try registering it" + "\n");
					goto tryagain;
				}

				break;
				case "2":
				Console.WriteLine("\n" + "Please write your name");

				input = Console.ReadLine();
				if(input.Length > 20)
				{
					Console.WriteLine("\n" + "ERROR: Username must be less than 20 characters" + "\n");
					goto tryagain;
				}
				try
				{
					DB.Database.InsertPlayer(input);
				} catch
				{
					Console.WriteLine("\n" + "ERROR: A user named: " + input + 
						" already exists, please login or use a different name" + "\n");
					goto tryagain;
				}
				break;
			}
			ScoreBoard.AddPlayer(input);
			Settings.LoadPlayer(input);




		}

		internal static bool Replay()
		{
			Console.WriteLine("press 1 to replay or 2 to quit");
			string input;
			do
			{
				input = Console.ReadLine();
				if (input != "1" && input != "2")
				{
					Console.WriteLine("please input 1 to replay or 2 to quit");
				}
			} while (input != "1" && input != "2");
			if(input == "1")
			{
				return false;
			}
			return true;
		}
	}
}

