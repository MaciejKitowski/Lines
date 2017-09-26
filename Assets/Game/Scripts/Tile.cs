using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Tile : MonoBehaviour {
    [SerializeField] private Material matUnselect;
    [SerializeField] private Material matSelect;
    private MeshRenderer mesh;
    private bool _selected = false;
    private bool _movement = false;
    private bool toRemove = false;
    private Color _color;
    private TileManager manager;
    private NavMeshAgent navMesh;
    private NavMeshObstacle navObstacle;
    private ArenaTile currentTile;
    private Arena arena;
    private Animation anim;

    public bool selected {
        get { return _selected; }
        set {
            if (value) {
                if (manager.selected != null) manager.selected.selected = false;
                mesh.material = matSelect;
                manager.selected = this;
            }
            else {
                mesh.material = matUnselect;
                manager.selected = null;
            }

            _selected = value;
            if(!toRemove) StartCoroutine(ToggleNavigation());
            mesh.material.color = color;
        }
    }

    public bool movement {
        get { return _movement; }
        private set { _movement = value; }
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
        arena = GameObject.FindGameObjectWithTag("Arena").GetComponent<Arena>();
        anim = GetComponent<Animation>();
    }

    void LateUpdate() {
        if(movement) {
            if (navMesh.remainingDistance == Mathf.Infinity) transform.rotation = new Quaternion(); //Freeze rotation while move
            else if(navMesh.remainingDistance == 0) {
                Debug.Log("Tile on position", gameObject);
                arena.CheckPoints();
                movement = false;
                selected = false;
            }
        }
    }

    void OnMouseDown() {
        if (selected && !movement) selected = false;
        else {
            if(manager.selected == null || !manager.selected.movement) selected = true;
        }
    }

    public void Initialize(ArenaTile arTile, Color col) {
        transform.position = arTile.transform.position;
        color = col;
        currentTile = arTile;
        arTile.tile = this;

        anim = GetComponent<Animation>();
        transform.localScale = new Vector3(0, transform.localScale.y, 0);   //Set scale to 0 before start animation
        anim.Play("Tile New");
    }

    public void MoveToPosition(ArenaTile tile) {
        Vector3 pos = tile.transform.position;
        NavMeshPath path = new NavMeshPath();
        navMesh.CalculatePath(pos, path);

        if(path.status == NavMeshPathStatus.PathComplete) {
            navMesh.SetPath(path);

            if (currentTile != null) currentTile.tile = null;
            currentTile = tile;
            tile.tile = this;
            movement = true;
        }
        else {
            Debug.Log("Cannot reach destination.", gameObject);
            selected = false;
        }
    }

    public void Remove() {
        Debug.Log("Remove tile", gameObject);

        toRemove = true;
        selected = false;
        currentTile.tile = null;

        anim.Play("Tile Remove");
    }

    public void Destroy() { Destroy(gameObject); }  //Used in Tile Remove animation

    private IEnumerator ToggleNavigation() {    //Toggling between Nav Mesh Agent and obstacle must be delayed because of bug (change position of selected tile)
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
