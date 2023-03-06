using UnityEngine;

public enum TileType { Red, Blue, Green, Yellow, Orange, Cyan, White, Black, Pink, Purple}
public class Tile
{
    public TileType type;

    private int x;
    private int y;

    public int X { get => x; }
    public int Y { get => y; }

    private MahjongTable mahjongTable;

    private Transform transform;

    public Transform Transform { get => transform; set => transform = value; }

    public Tile(TileType type) //Only for Unit testing
    {
        this.type = type;
    }

    public Tile(int x, int y, TileType type, MahjongTable mahjongTable)
    {
        this.x = x;
        this.y = y;
        this.type = type;
        this.mahjongTable = mahjongTable;
    }

    public void Pick()
    {
        mahjongTable.PickTileOut(this);
    }

    public void MoveToPosition(Vector3 position)
    {
        if(transform)
            transform.localPosition = position;
    }
}