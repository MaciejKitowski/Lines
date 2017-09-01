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
        
    }
}
