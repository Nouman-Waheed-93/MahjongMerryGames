using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CollectionTankTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void CanAddCorrectNumberOfTiles()
    {
        CollectionTank myCollectionTank = new CollectionTank(10);
        myCollectionTank.PushTile(new Tile(TileType.Red));
        Assert.That(myCollectionTank.Top == 1, "Added one tile");
        myCollectionTank.PushTile(new Tile(TileType.Red));
        Assert.That(myCollectionTank.Top == 2, "Added two tiles");
    }

    [Test]
    public void AddingThreeSimilarTilesRemovesThemAll()
    {
        CollectionTank myCollectionTank = new CollectionTank(10);
        myCollectionTank.PushTile(new Tile(TileType.Red));
        myCollectionTank.PushTile(new Tile(TileType.Red));
        myCollectionTank.PushTile(new Tile(TileType.Red));
        Assert.That(myCollectionTank.Top == 0, "Three tiles were collected and removed");
        for(int i = 0; i < myCollectionTank.Tiles.Length; i++)
        {
            Assert.That(myCollectionTank.Tiles[i] == null, "Tiles[" + i + "] is null");
        }
    }

    [Test]
    public void AddingTileArbitrarilyKeepsTheCorrectTop()
    {
        CollectionTank myCollectionTank = new CollectionTank(10);

        myCollectionTank.PushTile(new Tile(TileType.Blue));
        myCollectionTank.PushTile(new Tile(TileType.Red));
        myCollectionTank.PushTile(new Tile(TileType.Green));
        myCollectionTank.PushTile(new Tile(TileType.Red));

        Assert.That(myCollectionTank.Top == 4);
    }

    [Test]
    public void AddingTileArbitrarilyStoresSimilarTilesTogether()
    {
        CollectionTank myCollectionTank = new CollectionTank(10);
        myCollectionTank.PushTile(new Tile(TileType.Blue));
        myCollectionTank.PushTile(new Tile(TileType.Red));
        myCollectionTank.PushTile(new Tile(TileType.Green));
        myCollectionTank.PushTile(new Tile(TileType.Red));

        Assert.That(myCollectionTank.Tiles[1].type == myCollectionTank.Tiles[2].type, "Red Tiles are stored together");

        myCollectionTank.PushTile(new Tile(TileType.Blue));
        Assert.That(myCollectionTank.Tiles[0].type == myCollectionTank.Tiles[1].type, "Blue Tiles are stored together");
        Assert.That(myCollectionTank.Tiles[2].type == myCollectionTank.Tiles[3].type, "Red Tiles are stored together after adding two blue tiles");
    }

    [Test]
    public void AddingThreeTilesOfAKindArbitrarilyRemovesThemAll()
    {
        CollectionTank myCollectionTank = new CollectionTank(10);
        myCollectionTank.PushTile(new Tile(TileType.Blue));
        myCollectionTank.PushTile(new Tile(TileType.Red));
        myCollectionTank.PushTile(new Tile(TileType.Green));
        myCollectionTank.PushTile(new Tile(TileType.Blue));
        myCollectionTank.PushTile(new Tile(TileType.Blue));

        Assert.That(myCollectionTank.Top == 2);
    }

    [Test]
    public void TilesAreMovedBackWhenOtherTilesAreRemoved()
    {
        CollectionTank myCollectionTank = new CollectionTank(10);
        myCollectionTank.PushTile(new Tile(TileType.Blue));
        myCollectionTank.PushTile(new Tile(TileType.Red));
        myCollectionTank.PushTile(new Tile(TileType.Green));
        myCollectionTank.PushTile(new Tile(TileType.Blue));
        myCollectionTank.PushTile(new Tile(TileType.Blue));

        Assert.That(myCollectionTank.Tiles[0].type == TileType.Red, "Red is pushed To bottom");
        Assert.That(myCollectionTank.Tiles[1].type == TileType.Green, "Green is pushed to bottom + 1");
    }

    [Test]
    public void WholeTankCanBeFilled()
    {
        CollectionTank myCollectionTank = new CollectionTank(10);
        myCollectionTank.PushTile(new Tile(TileType.Blue));
        myCollectionTank.PushTile(new Tile(TileType.Red));
        myCollectionTank.PushTile(new Tile(TileType.Green));

        myCollectionTank.PushTile(new Tile(TileType.Blue));
        myCollectionTank.PushTile(new Tile(TileType.Red));
        myCollectionTank.PushTile(new Tile(TileType.Green));

        myCollectionTank.PushTile(new Tile(TileType.Yellow));
        myCollectionTank.PushTile(new Tile(TileType.Yellow)); 
        myCollectionTank.PushTile(new Tile(TileType.Cyan));
        myCollectionTank.PushTile(new Tile(TileType.Cyan));

        Assert.That(myCollectionTank.Top == 10, "Tank is Full");
    }

    [Test]
    public void ATileCannotBePushedOnAFullTank()
    {
        CollectionTank myCollectionTank = new CollectionTank(10);
        myCollectionTank.PushTile(new Tile(TileType.Blue));
        myCollectionTank.PushTile(new Tile(TileType.Red));
        myCollectionTank.PushTile(new Tile(TileType.Green));

        myCollectionTank.PushTile(new Tile(TileType.Blue));
        myCollectionTank.PushTile(new Tile(TileType.Red));
        myCollectionTank.PushTile(new Tile(TileType.Green));

        myCollectionTank.PushTile(new Tile(TileType.Yellow));
        myCollectionTank.PushTile(new Tile(TileType.Yellow));
        myCollectionTank.PushTile(new Tile(TileType.Cyan));
        myCollectionTank.PushTile(new Tile(TileType.Cyan));

        myCollectionTank.PushTile(new Tile(TileType.Black));

        for(int i = 0; i < myCollectionTank.Top; i++)
        {
            Assert.That(myCollectionTank.Tiles[i].type != TileType.Black, "Black Tile is found. Was Added on full tank"); 
        }
    }
}
