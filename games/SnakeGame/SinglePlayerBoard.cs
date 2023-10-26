using System.Diagnostics;
using MiniGames.Games.Enums;
using MiniGames.Player;
using MiniGames.Render;
using snake.games.SnakeGame.SnakeObjects;

namespace snake.games.SnakeGame
{
    public class SinglePlayerBoard 
    {
        public int _Height;
        public int _Width;
        public TileValue[,] _Board { get; set; }


        //Snake
        private Snake _snake;
        private Direction _direction = Direction.RIGHT;

        
        //Used to generate apple
        private readonly Random _random = new Random();


        //Game State
        private bool gameOver = false;
        bool pause = false;


        //Setings
        private List<ConsoleKey> _keys = new List<ConsoleKey>();
        Stopwatch timer = new Stopwatch();
        int gameTick = 500;
        


        public SinglePlayerBoard(int width, int height)
        {
            _Width = width;
            _Height = height;

            SetKeys(0);

            _Board = new TileValue[_Width, _Height];
            SetBoardBorder();

            //_snake = new Snake(7, new Tile(8, 18, TileValue.SNAKE), this); //This may be autoset to a desegnated possition
            _snake.Color = ConsoleColor.Green; //Needs to be player chois and a default value

            
            //Initilizes game before gameLoop
            AddGoodApple();
            AddBadApple();
        }
        
        
        //gameLoop
        //may move this to parent class
        public void GameLoop()
        {
            UpdateBoard();
            while (!gameOver)
            {
                //bryte ned
                
                //Check if nskae is dead
                if (_snake.IsDead)
                {
                    gameOver = true;
                }
                
                //Start timer
                timer.Start();
                
                
                //cheks how many aples on the board
                var apples = GetGoodAppleTiles();
                var badApples = GetBadAppleTiles();
                
                //Add contitions for spawning apples/obsticals 
                //Maby add them to a list or something??
                if (apples.Count == 0 || badApples.Count == 0)
                {
                    AddGoodApple();
                    AddBadApple();
                }
                
                //Check player input
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey().Key;
                    setDirection(key);
                    
                    if (key == ConsoleKey.Enter)
                    {
                        pause = !pause;
                    }
                }

                //Check if game is paused
                if (!pause)
                {
                    //Get Game tick
                    if (timer.ElapsedMilliseconds > gameTick)
                    {
                        //Give player input to snake
                        _snake.Move(_direction);
                        //update board
                        UpdateBoard();
                        //Reset timer for next game tic
                        timer.Reset();
                    }
                }

            }
            //Satt riktig??
            ScoreBoard.SaveScore("snake");
        }
        
        

        //Display methods
        //------------------------------
        private void UpdateBoard()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            for (int w = 0; w < _Width; w++)
            {
                for (int h = 0; h < _Height; h++)
                {
                    var tile = _Board[w, h];
                    Console.SetCursorPosition(w, h);

                    if (tile == TileValue.BORDER)
                    {
                        WriteBoarder(h);
                    }
                    else if (tile == TileValue.EMPTY)
                    {
                        Console.Write(" ");
                    }
                    else if (tile == TileValue.SNAKE)
                    {
                        Console.ForegroundColor = _snake.Color;
                        Console.Write("s");
                    }
                    else if (tile == TileValue.SnakeHead)
                    {
                        Console.ForegroundColor = _snake.Color;
                        Console.Write("S");
                    }
                    else if (tile == TileValue.GoodApple)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("@");
                    }else if (tile == TileValue.BadApple)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                    }
                }

                Console.Write("\n");
            }
        }

        private void WriteBoarder(int height)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            if (height == 0)
            {
                Console.Write("_");
            }
            else if (height == _Height - 1)
            {
                Console.Write("\u0305");
            }
            else
            {
                Console.Write("|");
            }
        }
        //------------------------------

        private void SetBoardBorder()
        {
            for (int w = 0; w < _Width; w++)
            {
                for (int h = 0; h < _Height; h++)
                {
                    if (w == 0 || w == (_Width - 1) || h == 0 || h == (_Height - 1))
                    {
                        _Board[w, h] = TileValue.BORDER;
                    }
                }
            }
        }

        private IEnumerable<Tile> GetEmptyTiles()
        {
            for (int w = 0; w < _Width; w++)
            {
                for (int h = 0; h < _Height; h++)
                {
                    if (_Board[w, h] == TileValue.EMPTY)
                    {
                        yield return new Tile(w, h, TileValue.EMPTY);
                    }
                }
            }
        }

        private ICollection<Tile> GetGoodAppleTiles()
        {
            ICollection<Tile> apples = new List<Tile>();

            for (int w = 0; w < _Width; w++)
            {
                for (int h = 0; h < _Height; h++)
                {
                    if (_Board[w, h] == TileValue.GoodApple)
                    {
                         apples.Add(new Tile(w, h, TileValue.GoodApple));
                    }
                }
            }

            return apples;
        }
        private ICollection<Tile> GetBadAppleTiles()
        {
            ICollection<Tile> apples = new List<Tile>();

            for (int w = 0; w < _Width; w++)
            {
                for (int h = 0; h < _Height; h++)
                {
                    if (_Board[w, h] == TileValue.BadApple)
                    {
                         apples.Add(new Tile(w, h, TileValue.BadApple));
                    }
                }
            }

            return apples;
        }


        //Apple
        public void AddGoodApple()
        {
            List<Tile> empty = new List<Tile>(GetEmptyTiles());

            Tile pos = empty[_random.Next(empty.Count)];
            _Board[pos.x, pos.y] = TileValue.GoodApple;
        }
        public void AddBadApple()
        {
            List<Tile> empty = new List<Tile>(GetEmptyTiles());

            Tile pos = empty[_random.Next(empty.Count)];
            _Board[pos.x, pos.y] = TileValue.BadApple;
        }
        
        public void setDirection(ConsoleKey key)
        {
            if (_keys.Contains(key))
            {
                if (key == _keys[0] && _direction != Direction.DOWN)
                {
                    _direction = Direction.UP;
                }
                else if (key == _keys[1] && _direction != Direction.LEFT)
                {
                    _direction = Direction.RIGHT;
                }
                else if (key == _keys[2] && _direction != Direction.UP)
                {
                    _direction = Direction.DOWN;
                }
                else if (key == _keys[3] && _direction != Direction.RIGHT)
                {
                    _direction = Direction.LEFT;
                }
            }
        }

        private void SetKeys(int snakeNumber)
        {

            //important that the movement starts with up and goes clockwise!
            switch (snakeNumber)
            {
                case 0:
                    _keys.AddRange(new ConsoleKey[]
                    {
                        ConsoleKey.UpArrow,
                        ConsoleKey.RightArrow,
                        ConsoleKey.DownArrow,
                        ConsoleKey.LeftArrow
                    });
                    break;

                case 1:
                    _keys.AddRange(new ConsoleKey[]
                    {
                        ConsoleKey.W,
                        ConsoleKey.D,
                        ConsoleKey.S,
                        ConsoleKey.A
                    });
                    break;

            }

        }


        
    }
}

