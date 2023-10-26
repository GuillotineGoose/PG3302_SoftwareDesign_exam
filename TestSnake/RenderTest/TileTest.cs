using NUnit.Framework;
using System;
using System.IO;
using MiniGames.Render;
using Assert = NUnit.Framework.Assert;

namespace Tests.RenderTest;

public class TileTest
{
    /*
    [Test]
    //needs to read character at consolecursor position
    public void AddTileTest()
    {
        //får IO error på Console.SetCursorPosition(x, y); i addTile();
        var tileChar = "s";
        var snakeTile = new Tile(5, 9, tileChar);

        snakeTile.AddTile();

        Assert.AreEqual(;
    }
    */

    [Test]
    public void GetCordinatesTest() 
    {
        var tile = new Tile(2, 5, "t");

        var tileCordinates = tile.GetCordinates();

        var testCordinates = new int[] { 2, 5 };

        Assert.AreEqual(tileCordinates, testCordinates);


    }

    [Test]
    public void SetCordinates() 
    {
        var tile = new Tile(2, 5, "s");

        var tileCordinates = tile.GetCordinates();

        tile.SetCordinates(3, 6);

        var newCordinates = tile.GetCordinates();

        Assert.AreNotEqual(tileCordinates, newCordinates);
    }
}