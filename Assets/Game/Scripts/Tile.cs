using UnityEngine;
using UnityEngine.AI;

public class Tile : MonoBehaviour {
    [SerializeField] private Material matUnselect;
    [SerializeField] private Material matSelect;
    private MeshRenderer mesh;
    private bool _selected = false;
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
        if(navMesh.remainingDistance == Mathf.Infinity) transform.rotation = new Quaternion(); //Freeze rotation while movement
    }

    public void moveToPosition(Vector3 pos) {
        NavMeshPath path = new NavMeshPath();
        navMesh.CalculatePath(pos, path);

        if(navMesh.pathStatus == NavMeshPathStatus.PathComplete) navMesh.SetPath(path); 
        else {
            Debug.Log("Cannot reach destination.");
        }
    }

    private void OnMouseDown() {
        if(selected) selected = false;
        else selected = true;
    }
}
