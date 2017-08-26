using UnityEngine;

public class ArenaTile : MonoBehaviour {
    private TileManager tileManager;

    void Start() {
        tileManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TileManager>();
    }

    private void OnMouseDown() {
        if (tileManager.selected != null) tileManager.selected.moveToPosition(transform.position);
    }
}
