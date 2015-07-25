using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour 
{
    public bool selected;

    public NavMeshAgent navAgent;
    public arenaBlockController arenaTarget;
    public bool onPosition;

	void Start ()
    {
        navAgent = gameObject.transform.GetChild(0).gameObject.GetComponent<NavMeshAgent>();
	}
	
	void Update () 
    {
        if(arenaTarget != null && !onPosition)
        {
            gameObject.transform.position = navAgent.gameObject.transform.position;
        }   
	}

    void OnMouseDown()
    {
        if (!Manager.blocks.blockIsSelected()) selected = true;
    }

    public void setPatch(arenaBlockController target)
    {
        NavMeshPath path = new NavMeshPath();
        Vector3 pos = target.transform.position;
        navAgent.gameObject.SetActive(true);
        navAgent.CalculatePath(pos, path);
        selected = false;

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            Debug.Log("Path found");
            if(arenaTarget != null)arenaTarget.block = null;
            arenaTarget = target;
            onPosition = false;
            navAgent.SetPath(path);
            navAgent.Resume();
        }

        else if (path.status == NavMeshPathStatus.PathPartial)
        {
            navAgent.gameObject.SetActive(false);
            Debug.Log("Block didn't found path");
        }
    }

    public void stopPath()
    {
        Debug.Log("Path stopped");
        onPosition = true;
        gameObject.transform.position = navAgent.pathEndPosition;
        navAgent.gameObject.SetActive(false);
    }
}
