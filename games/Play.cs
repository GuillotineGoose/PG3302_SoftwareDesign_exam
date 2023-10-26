using miniGames.games.HorseGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using snake.games;
using snake.games.SnakeGame;

namespace MiniGames.games
{
    internal class Play
    {
        private string _playerInput;


        public void start()
        {
            var game = ChooseGame();
            
                Console.Write("Confirm option");
                Console.Write("(s) Start Game");
                Console.Write("(b) Back");
                Console.Write("Anything else to Quit");

                PlayerInput();
                Console.WriteLine(_playerInput);
                
                if (_playerInput == "s")
                {
                    game.StartGame();
                }
                else if (_playerInput == "b")
                {
                    start();
                }
        }

        internal IGame ChooseGame()
        {
            DisplayGameOptions();
            IGame game = null;
            while (game == null)
            {
               PlayerInput();
                game = GetGameBasedOnPlayerInput();

                if (_playerInput == "q")
                {
                    return null;
                }

                if (game == null)
                {
                    Console.WriteLine("\n" + "ERROR: Please chose a valid option" + "\n");
                }
            }

            return game;
        }

        private void DisplayGameOptions()
        {
            Console.WriteLine("\n" + "Please chose the game you want to play:");
            Console.WriteLine("(1) Snake (Singleplayer)" + "\n" +
                              "(2) Snake (Multiplayer)" + "\n" +
                              "(3) Horserace" + "\n" +
                              "(q) Quit" + "\n");
        }

        private void PlayerInput()
        {
            Console.Write("> ");
            _playerInput = Console.ReadLine();
        }

        private IGame GetGameBasedOnPlayerInput()
        {
            switch (_playerInput)
            {
                case "1":
                    return new SnakeGame();
                case "2":
                    return new SnakeGame();
                    break;
                case "3":
                    return new HorceRace();
            }

            return null;
        }
    }
}