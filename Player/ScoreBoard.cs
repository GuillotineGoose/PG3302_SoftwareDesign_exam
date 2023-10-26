using MiniGames.Player.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGames.Player
{
    public static class ScoreBoard
    {
        private static int _score = 100;
        private static int _highScore = 0;
        private static string _name = "guest";

        public static void AddPlayer(string name) 
        {
            _name = name;
        }

        public static void RetrieveSnakeScore() 
        {
            try 
            { 
                _highScore = Database.RetriveScore(_name, "snake");
            } catch
            {
                _highScore = 0;
            }

		}

        public static void WriteScore()
        {
            string scoreLine = _name + " current score:" + _score + " high score:" + _highScore;
            if (scoreLine.Length > Console.WindowWidth)
            {
                Console.SetCursorPosition(0, 0);
            }
            else
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - scoreLine.Length / 2, 0);
            }
            Console.WriteLine(scoreLine);
        }

        public static void AddScore(int score)
        {
            _score = _score + score;
            if (_score > _highScore)
            {
                _highScore = _score;
            }
            WriteScore();
        }

        public static void SaveScore(string gameType) 
        {
            Database.InsertScore(_name, gameType, _highScore);
            _score = 0;
        }
    }
}
