using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

[CustomEditor(typeof(Arena))]
public class ArenaEditor : Editor {
    public enum logMode { FULL, SUMMARY_ONLY, NONE }

    private bool displayOffMeshLinkButtons = false;
    private float buttonSpace = 20f;
    private logMode logmode = logMode.SUMMARY_ONLY;
    private int maxX, maxY;
    
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
        if (logmode == logMode.FULL) Debug.Log("Clear all Off Mesh Links.", target);
        int counter = 0;

        foreach(var tile in getTiles()) {
            OffMeshLink[] links = tile.GetComponents<OffMeshLink>();

            foreach(var link in links) {
                if (link != null) {
                    if (logmode == logMode.FULL) Debug.Log(string.Format("Clear [{0},{1}] off mesh link.", tile.name, tile.transform.parent.name), tile);
                    DestroyImmediate(link);
                    ++counter;
                }
            }
        }

        if (logmode != logMode.NONE) Debug.Log(string.Format("Removed {0} Off Mesh Links.", counter), target);
    }

    private void generateOffMeshLinks() {
        if (logmode == logMode.FULL) Debug.Log("Generate Off Mesh Links.", target);
        int counter = 0;
        GameObject[,] tiles = getTiles();

        foreach (var tile in tiles) {
            int x = 0, y = 0;
            if(!int.TryParse(tile.name, out x) || !int.TryParse(tile.transform.parent.name, out y)) {
                Debug.LogError(string.Format("Cannot parse tile position [{0}, {1}]", tile.name, tile.transform.parent.name), tile);
                break;
            }
            else {
                if(tile.GetComponent<OffMeshLink>() == null) {
                    --x;
                    --y;

                    if (x - 1 >= 0) {
                        if (logmode == logMode.FULL) Debug.Log(string.Format("Create connection [{0},{1}] -> [{2},{3}]", x, y, x - 1, y), tile);
                        addOffMeshLink(tile, tiles[x - 1, y]);
                        ++counter;
                    }
                    if (x + 1 < maxX) {
                        if (logmode == logMode.FULL) Debug.Log(string.Format("Create connection [{0},{1}] -> [{2},{3}]", x, y, x + 1, y), tile);
                        addOffMeshLink(tile, tiles[x + 1, y]);
                        ++counter;
                    }
                    if (y - 1 >= 0) {
                        addOffMeshLink(tile, tiles[x, y - 1]);
                        if (logmode == logMode.FULL) Debug.Log(string.Format("Create connection [{0},{1}] -> [{2},{3}]", x, y, x, y - 1), tile);
                        ++counter;
                    }
                    if (y + 1 < maxY) {
                        if (logmode == logMode.FULL) Debug.Log(string.Format("Create connection [{0},{1}] -> [{2},{3}]", x, y, x, y + 1), tile);
                        addOffMeshLink(tile, tiles[x, y + 1]);
                        ++counter;
                    }
                }
            } 
        }

        if (logmode != logMode.NONE) Debug.Log(string.Format("Created {0} Off Mesh Links.", counter), target);
        EditorUtility.SetDirty(target);
    }

    private GameObject[,] getTiles() {
        if (logmode == logMode.FULL) Debug.Log("Get arena tiles.");

        GameObject obj = ((Arena)target).gameObject;
        maxX = obj.transform.GetChild(0).childCount;
        maxY = obj.transform.childCount;
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

    private void addOffMeshLink(GameObject tile, GameObject end) {
        OffMeshLink link = tile.AddComponent<OffMeshLink>();
        link.costOverride = 1f;
        link.startTransform = tile.transform;
        link.endTransform = end.transform;
        link.biDirectional = false;
    }
}
