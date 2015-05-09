using UnityEngine;
using System.Collections;

public class arenaBlock : MonoBehaviour 
{
    public arenaManager manager;
    NavmeshobstacleController navObstacle;

    public GameObject block;
    public bool blocked;

	void Start () 
    {
        navObstacle = gameObject.transform.GetChild(1).gameObject.GetComponent<NavmeshobstacleController>();
        manager = gameObject.GetComponentInParent<arenaManager>();
	}

    void Update()
    {
        if(block != null)
        {
            //Reset off mesh links
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            
            //Turn on navmesh obstacle
            if (blocked)
            {
                block.GetComponent<NavMeshAgent>().enabled = false;
                navObstacle.toggle(NavmeshobstacleController.turn.ON);
            }
            else navObstacle.toggle(NavmeshobstacleController.turn.OFF);
        }
    }

    void OnMouseDown()
    {
        if(!blocked)
        {
            //Select new target for block
            if (manager.managerBlock.blockSelected())
            {
                manager.managerBlock.blocks[manager.managerBlock.blockSelectedIndex()].GetComponent<blockController>().setNavDestination(gameObject);
            }
        }
        else
        {
            //Unselect block
            if (manager.managerBlock.blockSelected())
            {
                manager.managerBlock.blocks[manager.managerBlock.blockSelectedIndex()].GetComponent<blockController>().selected = false;
            }
        }
    }
}
