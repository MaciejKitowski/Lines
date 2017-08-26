using UnityEngine;
using UnityEngine.AI;

public class Tile : MonoBehaviour {
    [SerializeField] private Material matUnselect;
    [SerializeField] private Material matSelect;
    private MeshRenderer mesh;
    private bool selected = false;
    private TileManager manager;
    private NavMeshAgent navMesh;

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
        if(selected) {
            mesh.material = matUnselect;
            manager.selected = null;
            selected = false;
        }
        else {
            mesh.material = matSelect;
            manager.selected = this;
            selected = true;
        }
    }
}
