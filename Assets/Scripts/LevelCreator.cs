using UnityEngine;

public class LevelCreator : MonoBehaviour  
{
    [SerializeField]
    LevelData levelData;

    public void SaveLevel()
    {
        if (levelData.LevelName == "" || levelData.LevelName == null)
            Debug.LogError("Please enter a level name");

        if (levelData.tableSize.x <= 0 && levelData.tableSize.y <= 0)
            Debug.LogError("Please enter a valid table size");

        if (levelData.tankSize <= 3)
            Debug.LogError("Please enter a valid tank size");

        if (levelData.tileData.Count <= 0)
            Debug.LogError("Please add valid tiles");

        LevelFileHandler.SaveLevel(levelData, levelData.LevelName);

    }
}
