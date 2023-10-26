using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniGames.Games.Enums;
using MiniGames.Games.SnakeGame;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace Tests.games.SnakeGame {
	internal class SnakeTest {

		[Test]
		public void SnakeMovesWithoutApple() {

			var snake = new Snake(5);

			var snakeHeadBefore = snake.getHead();

			snake.MoveSnake(Direction.DOWN, Ate.NOTHING);

			var snakeHeadAfter = snake.getHead();

			Assert.AreNotEqual(snakeHeadBefore, snakeHeadAfter);
			snakeHeadBefore.y = snakeHeadBefore.y + 1;
			Assert.AreEqual(snakeHeadAfter, snakeHeadAfter);

		}
	}
}
