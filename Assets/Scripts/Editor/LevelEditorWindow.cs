using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelCreator))]
public class LevelEditorWindow : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelCreator creatorScript = (LevelCreator)target;
        if (GUILayout.Button("Save Level"))
        {
            creatorScript.SaveLevel();
        }
    }
}
