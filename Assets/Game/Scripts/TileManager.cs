using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    private Tile _selected;

    public Tile selected { get { return _selected; } set { _selected = value; } }
}
