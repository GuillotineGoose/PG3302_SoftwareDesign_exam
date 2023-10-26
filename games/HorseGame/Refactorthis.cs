using miniGames.games.HorseGame.Horses;
using miniGames.games.HorseGame.Race;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using snake.games;

namespace miniGames.games.HorseGame {
	internal class HorceRace : IGame{

		public void Refactorthis() {

			var horse1 = HorseFactory.MakeHorse();
			var horse2 = HorseFactory.MakeHorse();
			var horse3 = HorseFactory.MakeHorse();

			var horseName1 = horse1.GetName();
			var horseName2 = horse2.GetName();
			var horseName3 = horse3.GetName();

			do
			{
				horse2 = HorseFactory.MakeHorse();
				horseName2 = horse2.GetName();
			} while (horseName2 == horseName1);

			do
			{
				horse3 = HorseFactory.MakeHorse();
				horseName3 = horse3.GetName();
			} while (horseName3 == horseName1 || horseName3 == horseName2);

			var input = "";
			do
			{
			Console.WriteLine("\n" + "Welcome! Please choose a horse:" + "\n");
				Console.WriteLine("HORSE #1 - Select (1)" + "\n" + horse1.ShowHorse());
				Console.WriteLine("HORSE #2 - Select (2)" + "\n" + horse2.ShowHorse());
				Console.WriteLine("HORSE #3 - Select (3)" + "\n" + horse3.ShowHorse());

				input = Console.ReadLine();
				if (input != "1" && input != "2" && input != "3")
				{
					Console.WriteLine("\n" + "ERROR: Please chose a valid option" + "\n");
				}
			} while (input != "1" && input != "2" && input != "3");

			var Race = new RaceTrack();
			var winner = Race.Race(horse1, horse2, horse3);

			Console.WriteLine("\n" + "WE HAVE A WINNER: " + winner.GetName());
			Console.WriteLine("Press \"enter\" to quit");
			Console.ReadLine();
		}

		public void StartGame()
		{
			throw new NotImplementedException();
		}
	}
}
