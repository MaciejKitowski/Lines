using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Arena))]
public class ArenaEditor : Editor {
    private bool displayOffMeshLinkButtons = false;
    private float buttonSpace = 20f;
    

    void OnEnable() {

    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        displayOffMeshLinkButtons = EditorGUILayout.Foldout(displayOffMeshLinkButtons, "Off Mesh links");

        if (displayOffMeshLinkButtons) displayOffMeshLinksButtons();

        serializedObject.ApplyModifiedProperties();
    }

    private void displayOffMeshLinksButtons() {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Clear")) clearOffMeshLinks();
        GUILayout.Space(buttonSpace);
        if (GUILayout.Button("Generate")) generateOffMeshLinks();
        EditorGUILayout.EndHorizontal();
    }

    private void clearOffMeshLinks() {

    }

    private void generateOffMeshLinks() {

    }

    private GameObject[,] getTiles() {
        GameObject obj = ((Arena)target).gameObject;
        int maxX = obj.transform.GetChild(0).childCount;
        int maxY = obj.transform.childCount;
        GameObject[,] tiles = new GameObject[maxX, maxY];

        for(int y = 0; y < maxY; ++y) {
            for(int x = 0; x < maxX; ++x) {
                tiles[x, y] = obj.transform.GetChild(y).GetChild(x).gameObject;
                Debug.Log(string.Format("[{0},{1}] - {2}", x, y, tiles[x, y].name), tiles[x, y]);
            }
        }

        return tiles;
    }
}
