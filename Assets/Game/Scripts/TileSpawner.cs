using UnityEngine;

public class TileSpawner : MonoBehaviour {
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform tileParent;
    [SerializeField] private Color[] possibleColors;
    private Tile[] tiles;

	void Start () {
        tiles = GetComponentsInChildren<Tile>();
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

    }
}
