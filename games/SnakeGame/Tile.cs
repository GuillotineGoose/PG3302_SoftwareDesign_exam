using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using snake.games.SnakeGame;

namespace MiniGames.Render
{
    public class Tile
    {

        private int _x;
        private int _y;

        private TileValue _value;

        public int x { get { return _x; } set { _x = value; } }
        public int y { get { return _y; } set { _y = value; } }
        public TileValue value { get { return _value; } set { _value= value; } }

        public Tile(int x, int y, TileValue tileValue)
        {
            _x = x;
            _y = y;
            _value = tileValue;
        }

        /*
        public void ChangeTile(jjstring newTile)
        {
            Console.SetCursorPosition(_x, _y);
            _tileValue = newTile;
            Console.Write(_tileValue);
        }
        */
        
        //Skriver up på brett. Tenker den er redundent
        /*
        public void AddTile()
        {
			Console.SetCursorPosition(_x, _y);
			Console.Write(_tileValue);

		}
		*/
        
        /*
        public string GetTile()
        {
            return _tileValue;
        }
        */

        public void SetCordinates(int x, int y)
        {
            _x = x; _y = y;
        }
        public int[] GetCordinates()
        {
            return new int[] { _x, _y };
        }
    }


}
