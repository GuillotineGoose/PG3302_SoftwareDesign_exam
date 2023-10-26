using System.Diagnostics;
using MiniGames.Games.Enums;
using MiniGames.Player;

namespace snake.games.SnakeGame;

public class SnakeGame : IGame
{
    private MultiPlayerBoard _board;
    //Dao fields??
    
    
    //Settings??
    
    
    public SnakeGame() 
    {
        _board = new MultiPlayerBoard(20, 20);
    }


    public void StartGame()
    {
        //DB handeling / method?
        ScoreBoard.RetrieveSnakeScore();
        ScoreBoard.WriteScore();

        _board.GameLoop();
        
        
        //Read what does it do?
        ScoreBoard.SaveScore("snake");
        
        DisplayEndScreen();

    }

    private void DisplayEndScreen()
    {
        Console.WriteLine("Press r to play again, or anything else to stop");
        if (Console.ReadLine() == "r")
        {
            //Find better way to reset board
            //_board = new SinglePlayerBoard(20, 20);
            
            Console.Clear();
            //While loop = virgin  Recursion = Chad
            StartGame();
        }
    }
    
    
    
}