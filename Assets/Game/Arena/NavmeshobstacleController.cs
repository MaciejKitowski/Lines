using UnityEngine;
using System.Collections;

public class NavmeshobstacleController : MonoBehaviour 
{
    private NavMeshObstacle navMesh;

    public enum turn { ON, OFF }

    void Start() { navMesh = gameObject.GetComponent<NavMeshObstacle>(); }

	public void toggle(turn Turn)
    {
        if (Turn == turn.ON) navMesh.enabled = true;
        if (Turn == turn.OFF) navMesh.enabled = false;
    }
}
