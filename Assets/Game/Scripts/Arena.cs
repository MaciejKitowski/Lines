using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour {
    [SerializeField] private int tilesInLineToRemove = 3;
    private ArenaTile[,] _tile;
    private List<ArenaTile> tileList;   //Used to found empty tiles
    private int maxX, maxY;
    
    public ArenaTile[,] tile { get { return _tile; } private set { _tile = value; } }

	void Start () {
        maxX = transform.GetChild(0).childCount;
        maxY = transform.childCount;
        tile = new ArenaTile[maxX, maxY];
        tileList = new List<ArenaTile>();

        for(int y = 0; y < maxY; ++y) {
            for(int x = 0; x < maxX; ++x) {
                tile[x, y] = transform.GetChild(y).GetChild(x).GetComponent<ArenaTile>();
                tileList.Add(tile[x, y]);
            }
        }
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.C)) checkPoints();
    }

    public List<ArenaTile> getEmptyTiles() {
        Debug.Log(string.Format("Found {0} empty tiles.", tileList.FindAll(b => b.empty).Count));

        return tileList.FindAll(b => b.empty);
    }

    public void checkPoints() {
        //Check rows
        for(int y = 0; y < maxY; ++y) {
            int sameColor = 1;
            for(int x = 1; x < maxX; ++x) {
                if(!tile[x, y].empty && !tile[x - 1, y].empty) {
                    if (tile[x, y].tile.color == tile[x - 1, y].tile.color) {
                        ++sameColor;
                        if (sameColor == tilesInLineToRemove) {
                            Debug.Log(string.Format("Remove row {0}", y + 1));
                        }
                    }
                    else sameColor = 1;
                }
            }
        }

        //Check columns
    }
}
