using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MahjongTable
{
    private Tile[,] tiles;
    public Tile[,] Tiles { get => tiles; }

    private int width;
    public int Width { get => width; }

    private int height;
    public int Height { get => height; }

    //This dictionary keeps track of how many of each type of tile would be in the table
    private List<TileTypeAndCount> tilesData;

    private CollectionTank collectionTank;

    private int totalTileCount;

    private int pickedTileCount;

    private UnityEvent onTableEmptied;

    public MahjongTable(int width, int height, List<TileTypeAndCount> tilesData, CollectionTank collectionTank, UnityEvent onTableEmptied)
    {
        this.width = width;
        this.height = height;
        tiles = new Tile[width, height];
        this.tilesData = tilesData;
        this.collectionTank = collectionTank;
        this.onTableEmptied = onTableEmptied;
        PrepareTable();
    }

    public void PrepareTable()
    {
        totalTileCount = 0;
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                if (tilesData.Count <= 0)
                    return;

                int randomTileIndex = Random.Range(0, tilesData.Count);
                TileType tileType = tilesData[randomTileIndex].type;
                tilesData[randomTileIndex].count--;
                if (tilesData[randomTileIndex].count <= 0)
                    tilesData.Remove(tilesData[randomTileIndex]);
                tiles[x, y] = new Tile(x, y, tileType, this);
                totalTileCount++;
            }
        }
    }

    public void PickTileOut(Tile tile)
    {
        if (tiles[tile.X, tile.Y] == null)
            return;

        tiles[tile.X, tile.Y] = null;
        collectionTank.PushTile(tile);
        pickedTileCount++;
        if (HasPickedAllTiles())
            onTableEmptied?.Invoke();
    }

    public bool HasPickedAllTiles()
    {
        return pickedTileCount >= totalTileCount;
    }
}
