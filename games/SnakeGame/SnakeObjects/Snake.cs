using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Xml.Linq;
using MiniGames.Games.Enums;
using MiniGames.Render;

namespace snake.games.SnakeGame.SnakeObjects
{
    public class Snake
    {
        //Refrense to gameBoard
        /*
         To be able to play in multiplayer. Every snake needs to move independently, and therefore each snake object need to independently update it's values on the board.
         */
        private MultiPlayerBoard _board;

        //SnakeBody
        private List<Tile> _snake;

        private ConsoleColor _color; //Set Snake Color

        //if a snake is dead. The game is over
        private bool _isDead;

        public bool IsDead
        {
            get { return _isDead; }
        }

        public ConsoleColor Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Snake(int startLength, Tile position, MultiPlayerBoard board) //MM change
        {
            _snake = new List<Tile>();
            _board = board;

            CreateSnake(startLength, position);
        }
        
        private void CreateSnake(int length, Tile position)
        {
            for (int i = length; i >= 0; i--)
            {
                _board._Board[position.x - i, position.y] = TileValue.SNAKE;
                _snake.Add(new Tile(position.x - i, position.y, TileValue.SNAKE));
            }
        }

        public void Move(Direction direction)
        {
            //Get's the new snake head position and finds out the new tiles value
            var newHeadPosition = GetNewHeadPostioion(direction);
            var hitValue = HeadWillHit(newHeadPosition);


            if (hitValue == TileValue.BORDER || hitValue == TileValue.SNAKE)
            {
                _isDead = true;
            }
            else if (hitValue == TileValue.EMPTY)
            {
                RemoveTail();
                AddHead(newHeadPosition);
            }
            else if (hitValue == TileValue.GoodApple)
            {
                AddHead(newHeadPosition);
            }else if (hitValue == TileValue.BadApple)
            {
                //bad apple conditions
                RemoveTail();
                RemoveTail();
                AddHead(newHeadPosition);

            }
        }

        private Tile GetNewHeadPostioion(Direction direction)
        {
            int x = 0;
            int y = 0;

            if (direction == Direction.UP)
            {
                x = SnakeHead().x;
                y = SnakeHead().y - 1;
            }
            else if (direction == Direction.DOWN)
            {
                x = SnakeHead().x;
                y = SnakeHead().y + 1;
            }
            else if (direction == Direction.LEFT)
            {
                x = SnakeHead().x - 1;
                y = SnakeHead().y;
            }
            else if (direction == Direction.RIGHT)
            {
                x = SnakeHead().x + 1;
                y = SnakeHead().y;
            }

            return new Tile(x, y, TileValue.SnakeHead);
        }

        private TileValue HeadWillHit(Tile nextTile)
        {
            if (IsOutside(nextTile))
            {
                return TileValue.BORDER;
            }


            return _board._Board[nextTile.x, nextTile.y];
        }

        private bool IsOutside(Tile tile)
        {
            return tile.x < 0 || tile.y < 0 || tile.x >= _board._Width || tile.y >= _board._Height;
        }

        private void RemoveTail()
        {
            var tail = _snake.First();
            _board._Board[tail.x, tail.y] = TileValue.EMPTY;
            _snake.Remove(tail);
        }

        private Tile SnakeHead()
        {
            return _snake.Last();
        }

        private void AddHead(Tile tile)
        {
            _snake.Add(tile);
            _board._Board[tile.x, tile.y] = TileValue.SNAKE;
        }
    }
}