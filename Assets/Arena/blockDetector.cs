using UnityEngine;
using System.Collections;

public class blockDetector : MonoBehaviour 
{
    public GameObject block;

	void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Block")
        {
            block = obj.gameObject;
            gameObject.transform.parent.GetComponent<arenaBlock>().block = block;
        }
    }

    void OnTriggerExit(Collider obj)
    {
        block = null;
        gameObject.transform.parent.GetComponent<arenaBlock>().block = null;
        gameObject.transform.parent.GetComponent<arenaBlock>().blocked = false;
    }

	void Update () 
    {
	    if(block != null)
        {
            if(block.GetComponent<blockController>().navTarget == gameObject.transform.parent.gameObject)
            {
                //Turn off navmesh obstacle if block selected
                if (block.GetComponent<blockController>().selected) gameObject.transform.parent.GetComponent<arenaBlock>().blocked = false;
                else
                {
                    //Turn on navmesh obstacle if block is on correct position
                    if (block.transform.position.x == gameObject.transform.parent.gameObject.transform.position.x &&
                        block.transform.position.z == gameObject.transform.parent.gameObject.transform.position.z)
                    {
                        gameObject.transform.parent.GetComponent<arenaBlock>().blocked = true;
                    }
                }
            }
            //Turn off navmesh obstacle if block is going to destroy
            if(block.GetComponent<blockController>().toDestroy)
            {
                gameObject.transform.parent.GetComponent<arenaBlock>().blocked = false;
            }

            //Turn off navmesh obstacle if selected new target
            if(block.GetComponent<blockController>().navTarget != gameObject.transform.parent.gameObject)
            {
                gameObject.transform.parent.GetComponent<arenaBlock>().blocked = false;
                if (block.GetComponent<NavMeshAgent>().isOnNavMesh) block.GetComponent<NavMeshAgent>().enabled = true;
            }
        }
	}
}
