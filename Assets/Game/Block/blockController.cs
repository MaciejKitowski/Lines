using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour 
{
    public bool selected = false;
    public bool toDestroy = false;
    public blocksManager.blockColor color;

    public NavMeshAgent navAgent;
    public arenaBlockController arenaTarget;
    public bool onPosition;

    private MeshRenderer renderer;

	void Start ()
    {
        navAgent = gameObject.transform.GetChild(0).gameObject.GetComponent<NavMeshAgent>();
        renderer = gameObject.GetComponent<MeshRenderer>();
        updateMaterial();
	}
	
	void Update () 
    {
        if (arenaTarget != null && !onPosition) gameObject.transform.position = navAgent.gameObject.transform.position; 
	}

    void OnMouseDown()
    {
        if (!Manager.blocks.blockIsSelected())
        {
            selected = true;
            updateMaterial();
        }
    }

    public void setPatch(arenaBlockController target)
    {
        NavMeshPath path = new NavMeshPath();
        Vector3 pos = target.transform.position;
        navAgent.gameObject.SetActive(true);
        navAgent.CalculatePath(pos, path);
        selected = false;
        updateMaterial();

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

    public void updateMaterial()
    {
        switch(color)
        {
            case blocksManager.blockColor.BLUE:
                if (selected) renderer.material = Manager.blocks.selectBlue;
                else renderer.material = Manager.blocks.unselectBlue;
                break;
            case blocksManager.blockColor.BROWN:
                if (selected) renderer.material = Manager.blocks.selectBrown;
                else renderer.material = Manager.blocks.unselectBrown;
                break;
            case blocksManager.blockColor.GREEN:
                if (selected) renderer.material = Manager.blocks.selectGreen;
                else renderer.material = Manager.blocks.unselectGreen;
                break;
            case blocksManager.blockColor.ORANGE:
                if (selected) renderer.material = Manager.blocks.selectOrange;
                else renderer.material = Manager.blocks.unselectOrange;
                break;
            case blocksManager.blockColor.PINK:
                if (selected) renderer.material = Manager.blocks.selectPink;
                else renderer.material = Manager.blocks.unselectPink;
                break;
            case blocksManager.blockColor.RED:
                if (selected) renderer.material = Manager.blocks.selectRed;
                else renderer.material = Manager.blocks.unselectRed;
                break;
            case blocksManager.blockColor.YELLOW:
                if (selected) renderer.material = Manager.blocks.selectYellow;
                else renderer.material = Manager.blocks.unselectYellow;
                break;
        }
    }
}
