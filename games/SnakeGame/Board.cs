namespace snake.games.SnakeGame;

public abstract class Board
{
    public int _Width;
    public int _Height;
    public TileValue[,] _Board { get; set; }


    protected Board(int width, int height)
    {
        _Width = width;
        _Height = height;
        
        _Board = new TileValue[_Width, _Height];
    }

    public abstract void GameLoop();
}