using UnityEngine;
using UnityEngine.AI;

public class Tile : MonoBehaviour {
    [SerializeField] private Material matUnselect;
    [SerializeField] private Material matSelect;
    private MeshRenderer mesh;
    private bool _selected = false;
    private bool movement = false;
    private TileManager manager;
    private NavMeshAgent navMesh;

    private bool selected {
        get { return _selected; }
        set {
            if(value) {
                _selected = true;
                mesh.material = matSelect;
                manager.selected = this;
            }
            else {
                _selected = false;
                mesh.material = matUnselect;
                manager.selected = null;
            }
        }
    }

    void Start() {
        mesh = GetComponent<MeshRenderer>();
        navMesh = GetComponent<NavMeshAgent>();
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

    public void moveToPosition(Vector3 pos) {
        NavMeshPath path = new NavMeshPath();
        navMesh.CalculatePath(pos, path);

        if(navMesh.pathStatus == NavMeshPathStatus.PathComplete) {
            navMesh.SetPath(path);
            movement = true;
        }
        else {
            Debug.Log("Cannot reach destination.");
        }
    }

    private void OnMouseDown() {
        if(selected) selected = false;
        else selected = true;
    }
}
