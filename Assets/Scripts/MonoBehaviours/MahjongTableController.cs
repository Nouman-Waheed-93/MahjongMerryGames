using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MahjongTableController : MonoBehaviour
{
    MahjongTable mahjongTable;
    [SerializeField]
    TileGameObjectAndType[] tiles;

    Dictionary<TileType, GameObject> tileDict;

    public UnityEvent onTableEmptied;

    public void PrepareTable(MahjongTable mahjongTable)
    {
        this.mahjongTable = mahjongTable;
        PrepareDictionary();
        InstantiateAllTiles();
    }
    
    private void PrepareDictionary()
    {
        tileDict = new Dictionary<TileType, GameObject>();
        for(int i = 0; i < tiles.Length; i++)
        {
            tileDict.Add(tiles[i].type, tiles[i].gameObject);
        }
    }

    private void InstantiateAllTiles()
    {
        for(int x = 0; x < mahjongTable.Width; x++)
        {
            for(int y = 0; y < mahjongTable.Height; y++)
            {
                TileController tile = Instantiate(tileDict[mahjongTable.Tiles[x, y].type], transform).GetComponent<TileController>();
                tile.Init(mahjongTable.Tiles[x, y]);
                tile.MoveToPosition(new Vector3(x, y, 1));
            }
        }
    }
}

[System.Serializable]
class TileGameObjectAndType 
{
    public TileType type;
    public GameObject gameObject;
}
