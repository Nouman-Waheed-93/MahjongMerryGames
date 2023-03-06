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
    }

    private void OnMouseUpAsButton()
    {
        //Move the tile into tank
        tile.Pick();
    }
}
