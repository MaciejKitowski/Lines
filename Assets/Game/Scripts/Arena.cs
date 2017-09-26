using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour {
    [SerializeField] private int requiredTilesInLine = 3;
    private enum tilesCompareState { EMPTY, DIFFERENT, SAME }   //Used to prettier comparison in looking for points
    private ArenaTile[,] _tile;
    private List<ArenaTile> tileList;   //Used to found empty tiles
    private int maxX, maxY;
    private Game game;
    
    public ArenaTile[,] tile { get { return _tile; } private set { _tile = value; } }

	void Awake () {
        maxX = transform.GetChild(0).childCount;
        maxY = transform.childCount;
        tile = new ArenaTile[maxX, maxY];
        tileList = new List<ArenaTile>();
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();

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

    public void removeAllTiles() {
        Debug.Log("Remove all tiles on arena");

        foreach(var obj in tileList.FindAll(b => !b.empty)) {
            obj.tile.Remove();
        }
    }

    public void checkPoints(bool spawnCheck = false) {  //spawnCheck - avoid spawning new tiles without player move (from tile spawner)
        bool pointsRow = checkPointsRow();
        bool pointsCol = checkPointsColumn();

        if (!spawnCheck && !pointsRow && !pointsCol) game.spawner.Spawn();
    }

    private bool checkPointsRow() {
        bool achievedPoints = false;

        for (int y = 0; y < maxY; ++y) {
            int sameColor = 1, start = 0;
            
            for (int x = 1; x < maxX; ++x) {
                tilesCompareState compState = compareTiles(tile[x, y], tile[x - 1, y]);

                if (compState == tilesCompareState.SAME) {
                    ++sameColor;

                    if(x == maxX - 1 && sameColor >= requiredTilesInLine) {
                        achievedPoints = true;
                        removeRow(y, start, x);
                    }
                }
                else {
                    if (sameColor >= requiredTilesInLine) {
                        achievedPoints = true;
                        removeRow(y, start, x - 1);
                    }

                    sameColor = 1;
                    start = x;
                }
            }
        }

        return achievedPoints;
    }

    private bool checkPointsColumn() {
        bool achievedPoints = false;

        for (int x = 0; x < maxX; ++x) {
            int sameColor = 1, start = 0;

            for (int y = 1; y < maxY; ++y) {
                tilesCompareState compState = compareTiles(tile[x, y], tile[x, y - 1]);

                if (compState == tilesCompareState.SAME) {
                    ++sameColor;

                    if (y == maxY - 1 && sameColor >= requiredTilesInLine) {
                        achievedPoints = true;
                        removeColumn(x, start, y);
                    }
                }
                else {
                    if (sameColor >= requiredTilesInLine) {
                        achievedPoints = true;
                        removeColumn(x, start, y - 1);
                    }

                    sameColor = 1;
                    start = y;
                }
            }
        }

        return achievedPoints;
    }

    private tilesCompareState compareTiles(ArenaTile A, ArenaTile B) {
        if (A.empty || B.empty) return tilesCompareState.EMPTY;
        else if (A.tile.color == B.tile.color) return tilesCompareState.SAME;
        else return tilesCompareState.DIFFERENT;
    }

    private void removeRow(int row, int start, int end) {
        Debug.Log(string.Format("Remove row: {0}, start: {1}, end: {2}, total tiles: {3}", row + 1, start + 1, end + 1, end - start + 1));
        
        game.addPoints(Mathf.Abs(requiredTilesInLine - (end - start + 1)));

        for(int i = start; i <= end; ++i) tile[i, row].tile.Remove();
    }

    private void removeColumn(int col, int start, int end) {
        Debug.Log(string.Format("Remove column: {0}, start: {1}, end: {2}, total tiles: {3}", col + 1, start + 1, end + 1, end - start + 1));

        game.addPoints(Mathf.Abs(requiredTilesInLine - (end - start + 1)));

        for (int i = start; i <= end; ++i) tile[col, i].tile.Remove();
    }
}
