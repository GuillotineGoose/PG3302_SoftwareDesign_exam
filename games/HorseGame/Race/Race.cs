using miniGames.games.HorseGame.Horses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGames.games.HorseGame.Race {
	public class RaceTrack {

		private readonly object _winnerLock = new();
		private Horse _winner;
		public Horse Race(params Horse[] horses) {

			Task[] tasks = new Task[horses.Length]; 
			for(int i = 0; i < tasks.Length; i++)
			{
				var horse = horses[i];
				tasks[i] = Task.Run(() => HorseRacing(horse));
			}
			Task.WaitAll(tasks);
			
			return _winner;
		}

		private void HorseRacing(Horse horse) 
		{
			Random rnd = new();
			Console.WriteLine(horse.GetName() + " has started!");
			Thread.Sleep(rnd.Next(10, 5000));

			lock (_winnerLock) { 
				if(_winner == null)
				{
					_winner = horse;
					Console.WriteLine(horse.GetName() + " changed the winner");
				}
			}
		}

	}
}
