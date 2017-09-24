using UnityEngine;

public class ArenaTile : MonoBehaviour {
    private bool _empty = true;
    private TileManager tileManager;
    private Tile _tile;

    public Tile tile {
        get { return _tile; }
        set {
            _tile = value;
            empty = (value == null);
        }
    }

    public bool empty { get { return _empty; } private set { _empty = value; } }

    void Start() {
        tileManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TileManager>();
    }

    private void OnMouseDown() {
        if (tileManager.selected != null && empty) tileManager.selected.moveToPosition(this);
    }
}
