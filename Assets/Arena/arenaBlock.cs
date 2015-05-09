using UnityEngine;
using System.Collections;

public class arenaBlock : MonoBehaviour 
{
    arenaManager manager;
    NavmeshobstacleController navObstacle;

    public bool blocked;

	void Start () 
    {
        navObstacle = gameObject.transform.GetChild(1).gameObject.GetComponent<NavmeshobstacleController>();
        manager = gameObject.GetComponentInParent<arenaManager>();
	}

    void OnMouseDown()
    {
        if(!blocked)
        {
            if (manager.managerBlock.blockSelected())
            {
                manager.managerBlock.blocks[manager.managerBlock.blockSelectedIndex()].GetComponent<blockController>().setNavDestination(gameObject);
            }
        }
        else
        {
            if (manager.managerBlock.blockSelected())
            {
                manager.managerBlock.blocks[manager.managerBlock.blockSelectedIndex()].GetComponent<blockController>().selected = false;
            }
        }
        
        //in the future this method would be used to blockade arena position if block are placed
        //navObstacle.toggle();
    }
}
