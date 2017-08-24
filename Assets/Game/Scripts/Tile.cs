using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tile : MonoBehaviour {
    [SerializeField] private Material matUnselect;
    [SerializeField] private Material matSelect;
    private MeshRenderer mesh;
    private bool selected = false;

    void Start() {
        mesh = GetComponent<MeshRenderer>();    
    }

    private void OnMouseDown() {
        if(selected) {
            mesh.material = matUnselect;
            selected = false;
        }
        else {
            mesh.material = matSelect;
            selected = true;
        }
    }


    /*private NavMeshAgent navMesh;

	void Start () {
        navMesh = GetComponent<NavMeshAgent>();


        NavMeshPath path = new NavMeshPath();
        Vector3 pos = new Vector3(-2.25f, 0, 0);
        navMesh.CalculatePath(pos, path);

        Debug.Log(path.status);
        navMesh.SetPath(path);
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }*/
}
