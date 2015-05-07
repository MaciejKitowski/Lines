using UnityEngine;
using System.Collections;

public class NavmeshobstacleController : MonoBehaviour 
{
    NavMeshObstacle navMesh;
	
	void Start () 
    {
        navMesh = gameObject.GetComponent<NavMeshObstacle>();
	}
	
	public void toggle()
    {
        if (navMesh.enabled) navMesh.enabled = false;
        else navMesh.enabled = true;
    }
}
