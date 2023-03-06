using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    Tile tile;

    public void Init(Tile tile)
    {
        this.tile = tile;
        tile.Transform = transform;
        Random.InitState(tile.X + tile.Y);
        tile.MoveToLocalPosition(Random.insideUnitSphere * 10f);
    }

    public void MoveToPosition(Vector3 position)
    {
        tile.MoveToLocalPosition(position);
    }

    private void Update()
    {
        tile.Update(Time.deltaTime);
    }

    private void OnMouseUpAsButton()
    {
        //Move the tile into tank
        tile.Pick();
    }
}
