using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectionTank
{
    private int capacity;

    public int Capacity { get => capacity; }

    private Tile[] tiles;

    public Tile[] Tiles { get => tiles; }

    private int top; //the index that has yet not been filled. It is Count in a List data structure

    public int Top { get => top; }

    private Transform transform;

    public Transform Transform { get => transform; set => transform = value; }

    public CollectionTank(int capacity)
    {
        this.capacity = capacity;
        tiles = new Tile[capacity];
        top = 0;
    }

    public void PushTile(Tile tile)
    {
        if (top < capacity)
        {

            tile.Transform.parent = transform;
            int pushAtIndex = GetPushIndex(tile.type);
            PushTileAtIndex(tile, pushAtIndex);

            if (HasCollectedThreeOfAKind(pushAtIndex))
            {
                //Remove the tiles
                RemoveTiles(pushAtIndex - 2, 3);
            }

            top++;
        }
    }

    private int GetPushIndex(TileType type)
    {
        int pushAtIndex = top;
        while (pushAtIndex >= 0)
        {
            if (tiles[pushAtIndex] != null && tiles[pushAtIndex].type == type)
            {
                break;
            }
            pushAtIndex--;
        }
        pushAtIndex++;

        //It means there are tiles in the tank,
        //but we are adding a new type of tile
        if (pushAtIndex == 0 && tiles[0] != null)
            pushAtIndex = top;
        return pushAtIndex;
    }

    private void PushTileAtIndex(Tile tile, int index)
    {
        for (int i = top; i > index; i--)
        {
            tiles[i] = tiles[i - 1];
            tiles[i].MoveToPosition(new Vector3(i, 0, 0));
        }
        tiles[index] = tile;
        tiles[index].MoveToPosition(new Vector3(index, 0, 0));
    }

    private bool HasCollectedThreeOfAKind(int newTileIndex)
    {
        if (newTileIndex < 2)
            return false;

        TileType tileType = tiles[newTileIndex].type;
        if (tileType == tiles[newTileIndex - 1].type && tileType == tiles[newTileIndex - 2].type)
        {
            return true;
        }
        return false;
    }

    private void RemoveTiles(int startIndex, int numberOfTiles)
    {
        for (int i = startIndex; i < capacity; i++)
        {
            if (i + numberOfTiles < capacity && tiles[i + numberOfTiles] != null)
            {
                bool tileIsRemoved = i < startIndex + numberOfTiles;
                if (tileIsRemoved)
                    tiles[i].MoveToPosition(new Vector3(-10, 0, 0));

                tiles[i] = tiles[i + numberOfTiles];
                tiles[i + numberOfTiles] = null;

                tiles[i].MoveToPosition(new Vector3(i, 0, 0));
            }
            else
            {
                tiles[i]?.MoveToPosition(new Vector3(-10, 0, 0));
                tiles[i] = null;
            }
        }
        top = top - numberOfTiles;
    }

}
