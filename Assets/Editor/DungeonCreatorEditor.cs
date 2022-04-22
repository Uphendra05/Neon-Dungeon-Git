using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AI;

[CustomEditor(typeof(DungeonCreator))]
public class DungeonCreatorEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DungeonCreator dungeonCreator = (DungeonCreator)target;
        if (GUILayout.Button("CreateNewDungeon"))
        {
            dungeonCreator.CreateDungeon();
            NavMeshBuilder.ClearAllNavMeshes();
            NavMeshBuilder.BuildNavMesh();

        }
    }
}
