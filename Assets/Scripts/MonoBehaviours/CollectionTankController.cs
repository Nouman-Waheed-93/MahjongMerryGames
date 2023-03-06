using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTankController : MonoBehaviour
{
    [SerializeField]
    private GameObject tankUnitPrefab;

    private CollectionTank collectionTank;

    public void Init(CollectionTank collectionTank)
    {
        this.collectionTank = collectionTank;
        collectionTank.Transform = transform;
        for(int i = 0; i < collectionTank.Capacity; i++)
        {
            GameObject tankUnit = Instantiate(tankUnitPrefab, transform);
            tankUnit.transform.localPosition = new Vector3(i, 0, 1);
        }
    }
}
