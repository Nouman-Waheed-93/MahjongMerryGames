using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public string LevelName;
    public TableSize tableSize;
    public int tankSize;
    [SerializeField]
    public List<TileTypeAndCount> tileData;
}

[System.Serializable]
public class TableSize
{
    public int x;
    public int y;
}

[System.Serializable]
public class TileTypeAndCount
{
    public TileType type;
    public int count;
}