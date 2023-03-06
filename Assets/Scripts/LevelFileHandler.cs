using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LevelFileHandler
{

    static string levelDirectory;

    #region Constructor

    public static void PrepareLevelDirectory()
    {

        levelDirectory = Application.dataPath + "/Resources/Levels";
        Debug.Log(levelDirectory);
        if (!Directory.Exists(levelDirectory))
        {
            Directory.CreateDirectory(levelDirectory);
        }
    }

    #endregion

    #region Public Methods

    public static void SaveLevel(LevelData levelData, string name)
    {
        PrepareLevelDirectory();
        string fileData = JsonUtility.ToJson(levelData);
        File.WriteAllText(levelDirectory + "/" + name + ".lvl", fileData);
    }

    public static string[] ListLevels()
    {
        PrepareLevelDirectory();
        string[] fileNames = Directory.GetFiles(@levelDirectory, "*.lvl");
        for (int i = 0; i < fileNames.Length; i++)
        {
            fileNames[i] = fileNames[i].Substring(fileNames[i].LastIndexOf('\\') + 1);
            fileNames[i] = fileNames[i].Substring(0, fileNames[i].Length - 4);
        }
        return fileNames;
    }

    public void DeleteLevel()
    {

    }

    public static string LoadLevel(string name)
    {
        PrepareLevelDirectory();
        string returnString = "";
        string fileName = levelDirectory + "/" + name + ".lvl";
        if (File.Exists(fileName))
            returnString = File.ReadAllText(fileName);
        return returnString;
    }
    #endregion
}
