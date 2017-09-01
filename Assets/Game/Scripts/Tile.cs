using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Tile : MonoBehaviour {
    [SerializeField] private Material matUnselect;
    [SerializeField] private Material matSelect;
    private MeshRenderer mesh;
    private bool _selected = false;
    private Color _color;
    private bool movement = false;
    private TileManager manager;
    private NavMeshAgent navMesh;
    private NavMeshObstacle navObstacle;
    private ArenaTile currentTile;

    public bool selected {
        get { return _selected; }
        set {
            if(value) {
                _selected = true;
                if (manager.selected != null) manager.selected.selected = false;
                StartCoroutine(toggleNavigation());
                mesh.material = matSelect;
                manager.selected = this;
            }
            else {
                _selected = false;
                StartCoroutine(toggleNavigation());
                mesh.material = matUnselect;
                manager.selected = null;
            }
        }
    }

    public Color color {
        get { return _color; }
        set {
            _color = value;
            if (mesh != null) mesh.material.color = value;
            else {
                mesh = GetComponent<MeshRenderer>();
                color = value;
            }
        }
    }

    void Start() {
        mesh = GetComponent<MeshRenderer>();
        navMesh = GetComponent<NavMeshAgent>();
        navObstacle = GetComponent<NavMeshObstacle>();
        manager = transform.parent.GetComponent<TileManager>();
    }

    void LateUpdate() {
        if(movement) {
            if (navMesh.remainingDistance == Mathf.Infinity) transform.rotation = new Quaternion(); //Freeze rotation while move
            else if(navMesh.remainingDistance == 0) {
                Debug.Log("Tile on position");
                movement = false;
                selected = false;
            }
        }
    }

    void OnMouseDown() {
        if (selected) selected = false;
        else selected = true;
    }

    public void initialize(ArenaTile arTile, Color col) {
        transform.position = arTile.transform.position;
        color = col;
        currentTile = arTile;
        arTile.tile = this;
    }

    public void moveToPosition(ArenaTile tile) {
        Vector3 pos = tile.transform.position;
        NavMeshPath path = new NavMeshPath();
        navMesh.CalculatePath(pos, path);

        if(navMesh.pathStatus == NavMeshPathStatus.PathComplete) {
            navMesh.SetPath(path);

            if (currentTile != null) currentTile.tile = null;
            currentTile = tile;
            tile.tile = this;
            movement = true;
        }
        else {
            Debug.Log("Cannot reach destination.");
        }
    }

    private IEnumerator toggleNavigation() {    //Toggling between Nav Mesh Agent and obstacle must be delayed because of bug (change position of selected tile)
        float waitTime = 0.01f;

        if (navMesh.enabled) {
            navMesh.enabled = false;
            yield return new WaitForSeconds(waitTime);
            navObstacle.enabled = true;
        }
        else {
            navObstacle.enabled = false;
            yield return new WaitForSeconds(waitTime);
            navMesh.enabled = true;
        }
    }
}
