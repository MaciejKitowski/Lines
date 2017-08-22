﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

[CustomEditor(typeof(Arena))]
public class ArenaEditor : Editor {
    public enum logMode { FULL, SUMMARY_ONLY, NONE }

    private bool displayOffMeshLinkButtons = false;
    private float buttonSpace = 20f;
    private logMode logmode = logMode.FULL;
    

    void OnEnable() {

    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        logmode = (logMode)EditorGUILayout.EnumPopup("Logging mode", logmode);
        displayOffMeshLinkButtons = EditorGUILayout.Foldout(displayOffMeshLinkButtons, "Off Mesh Links");

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
        if (logmode == logMode.FULL) Debug.Log("Clear all Off Mesh Links.");

        int counter = 0;

        foreach(var tile in getTiles()) {
            OffMeshLink link = tile.GetComponent<OffMeshLink>();
            if(link != null) {
                if (logmode == logMode.FULL) Debug.Log(string.Format("Clear [{0},{1}] off mesh link.", tile.name, tile.transform.parent.name), tile);
                DestroyImmediate(link);
                ++counter;
            }
        }

        if (logmode != logMode.NONE) Debug.Log(string.Format("Removed {0} Off Mesh Links.", counter));
    }

    private void generateOffMeshLinks() {

    }

    private GameObject[,] getTiles() {
        if (logmode == logMode.FULL) Debug.Log("Get arena tiles.");

        GameObject obj = ((Arena)target).gameObject;
        int maxX = obj.transform.GetChild(0).childCount;
        int maxY = obj.transform.childCount;
        GameObject[,] tiles = new GameObject[maxX, maxY];

        for(int y = 0; y < maxY; ++y) {
            for(int x = 0; x < maxX; ++x) {
                tiles[x, y] = obj.transform.GetChild(y).GetChild(x).gameObject;
                if (logmode == logMode.FULL) Debug.Log(string.Format("Loaded tile: [{0},{1}] - {2}", x, y, tiles[x, y].name), tiles[x, y]);
            }
        }

        if (logmode != logMode.NONE) Debug.Log(string.Format("Loaded {0} tiles.", tiles.Length));

        return tiles;
    }
}
