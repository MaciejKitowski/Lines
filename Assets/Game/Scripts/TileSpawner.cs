using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform tileParent;
    [SerializeField] private Color[] possibleColors;
    private Tile[] tiles;
    private Arena arena;

	void Start () {
        tiles = GetComponentsInChildren<Tile>();
        arena = GameObject.FindGameObjectWithTag("Arena").GetComponent<Arena>();
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) randNewTiles();
        if (Input.GetKeyDown(KeyCode.S)) spawn();
    }

    private void randNewTiles() {
        foreach(var til in tiles) {
            int rand = Random.Range(0, possibleColors.Length);
            til.color = possibleColors[rand];
        }
    }
	
	private void spawn() {
        List<ArenaTile> possibleTiles = arena.getEmptyTiles();

        if(possibleTiles.Count < 6) {
            Debug.Log("Game Lost");
        }
        else {
            foreach (var ti in tiles) {
                ArenaTile pos = possibleTiles[Random.Range(0, possibleTiles.Count)];
                possibleTiles.Remove(pos);
                Tile obj = Instantiate(tilePrefab, tileParent).GetComponent<Tile>();
                obj.initialize(pos, ti.color);
            }

            randNewTiles();
        }
    }
}
