using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelLoader : MonoBehaviour
{
    [SerializeField]
    MahjongTableController tableController;

    [SerializeField]
    CollectionTankController collectionTankController;

    private void Start()
    {
        LoadRandomLevel();
    }

    private void LoadRandomLevel()
    {
        string[] allLevels = LevelFileHandler.ListLevels();
        LoadLevel(allLevels[Random.Range(0, allLevels.Length)]);
    }

    public void LoadLevel(string levelName)
    {
        if (levelName != "")
        {
            string levelString = LevelFileHandler.LoadLevel(levelName);
            LevelData levelData = JsonUtility.FromJson<LevelData>(levelString);
            CollectionTank collectionTank = new CollectionTank(levelData.tankSize);
            tableController.PrepareTable(new MahjongTable(levelData.tableSize.x, levelData.tableSize.y, levelData.tileData, collectionTank, tableController.onTableEmptied));
            collectionTankController.Init(collectionTank);
        }
    }
}
