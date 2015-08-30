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

    private MeshRenderer render;
    private bool isNewBlock = true;
    private Animation animation;

	void Start ()
    {
        navAgent = gameObject.transform.GetChild(0).gameObject.GetComponent<NavMeshAgent>();
        animation = gameObject.GetComponent<Animation>();
        render = gameObject.GetComponent<MeshRenderer>();
        updateMaterial();
        animation.Play("New block");
	}
	
	void Update () 
    {
        if (arenaTarget != null && !onPosition) gameObject.transform.position = navAgent.gameObject.transform.position;
        if (!animation.isPlaying && toDestroy) Destroy(gameObject);
	}

    void OnMouseDown()
    {
        if (!gameManager.block.blockIsSelected() && !gameManager.block.blockIsMove() && gameManager.block.blocksToCreate == 0 && !gameManager.debugMenu.active)
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
            gameManager.block.playBadPathSound();
            Debug.Log("Block didn't found path");
        }
    }

    public void stopPath()
    {
        Debug.Log("Path stopped");
        onPosition = true;
        if (isNewBlock) isNewBlock = false;
        else
        {
            if(!toDestroy)
            {
                gameManager.block.blocksToCreate = 5;
                gameObject.transform.position = navAgent.pathEndPosition;
            }
        }
        navAgent.gameObject.SetActive(false);
    }

    public void destroyBlock()
    {
        animation.Play("Destroy block");
        toDestroy = true;
        arenaTarget.block = null;
        arenaTarget.navMeshObstacle.SetActive(false);
    }

    public void updateMaterial()
    {
        switch(color)
        {
            case blocksManager.blockColor.BLUE:
                if (selected) render.material = gameManager.block.selectBlue;
                else render.material = gameManager.block.unselectBlue;
                break;
            case blocksManager.blockColor.BROWN:
                if (selected) render.material = gameManager.block.selectBrown;
                else render.material = gameManager.block.unselectBrown;
                break;
            case blocksManager.blockColor.GREEN:
                if (selected) render.material = gameManager.block.selectGreen;
                else render.material = gameManager.block.unselectGreen;
                break;
            case blocksManager.blockColor.ORANGE:
                if (selected) render.material = gameManager.block.selectOrange;
                else render.material = gameManager.block.unselectOrange;
                break;
            case blocksManager.blockColor.PINK:
                if (selected) render.material = gameManager.block.selectPink;
                else render.material = gameManager.block.unselectPink;
                break;
            case blocksManager.blockColor.RED:
                if (selected) render.material = gameManager.block.selectRed;
                else render.material = gameManager.block.unselectRed;
                break;
            case blocksManager.blockColor.YELLOW:
                if (selected) render.material = gameManager.block.selectYellow;
                else render.material = gameManager.block.unselectYellow;
                break;
        }
    }
}
