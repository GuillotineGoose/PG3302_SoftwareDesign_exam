using MiniGames.games;
using MiniGames.Player.DB;
using snake.games.SnakeGame;
using static System.Collections.Specialized.BitVector32;

namespace MiniGames
{
    internal class Program
    {
        public static void Main()
        {
            /* 
			// MUST: options for login, register
			// OPTIONAL: options for resize window, check highscores
			 */
            /*
            bool quit = false;
            Player.DB.Database.createDb(); //creates the database if it does not already exist
            Player.Player.Login();
            while (!quit) 
            { 
                games.Play.PlayGame();
                quit = Player.Player.Replay();
            }
            */

            var game = new SnakeGame();
            game.StartGame();

        }


	}
}
