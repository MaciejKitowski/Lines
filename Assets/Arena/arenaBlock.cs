using UnityEngine;
using System.Collections;

public class arenaBlock : MonoBehaviour 
{
    NavmeshobstacleController navObstacle;

	void Start () 
    {
        navObstacle = gameObject.transform.GetChild(1).gameObject.GetComponent<NavmeshobstacleController>();
	}

    /*void OnMouseDown()
    {
        //in the future this method would be used to blockade arena position if block are placed
        navObstacle.toggle();
    }*/
}
