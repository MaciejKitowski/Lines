using UnityEngine;
using System.Collections;

public class arenaBlock : MonoBehaviour 
{
    NavmeshobstacleController navObstacle;

    public GameObject block;
    public bool blocked;

    void Start() { navObstacle = gameObject.transform.GetChild(1).gameObject.GetComponent<NavmeshobstacleController>(); }

    void Update()
    {
        if(block != null)
        {
            if (blocked) //Turn on navmesh obstacle
            {
                block.GetComponent<NavMeshAgent>().enabled = false;
                navObstacle.toggle(NavmeshobstacleController.turn.ON);
            }
            else navObstacle.toggle(NavmeshobstacleController.turn.OFF);
        }
    }

    void OnMouseDown()
    {
        if (!blocked && !gameManager.DebugMenu().active && !menuManager.MainMenu().active)
        {
            //Select new target for block
            if (gameManager.BlockManager().getSelectedBlock() != null) gameManager.BlockManager().getSelectedBlock().GetComponent<blockController>().setNavDestination(gameObject);
        }
    }

    public blockController BlockControl() { return block.GetComponent<blockController>(); }
}
