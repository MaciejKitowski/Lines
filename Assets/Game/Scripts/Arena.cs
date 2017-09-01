using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour {
    private ArenaTile[,] _tile;
    
    public ArenaTile[,] tile { get { return _tile; } private set { _tile = value; } }

	void Start () {
        int maxX = transform.GetChild(0).childCount;
        int maxY = transform.childCount;
        tile = new ArenaTile[maxX, maxY];

        for(int y = 0; y < maxY; ++y) {
            for(int x = 0; x < maxX; ++x) {
                tile[x, y] = transform.GetChild(y).GetChild(x).GetComponent<ArenaTile>();
            }
        }
	}
}
