using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour 
{
    public blockManager.color blockColor;
    public bool selected;
    public bool toDestroy;
    NavMeshAgent navAgent;

    public GameObject navTarget;
    public bool moved;
    public bool onPosition;
	
	void Start () 
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false;
	}

    public void setNavDestination(GameObject target)
    {
        navAgent.enabled = true;
        navTarget = target;

        Vector3 pos = target.transform.position;
        pos.y = 0.4166668f;
        navAgent.SetDestination(pos);

        selected = false;
        moved = true;
        onPosition = false;
    }

    void OnMouseDown()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle") && !gameManager.DebugMenu().active && !gameManager.GameLossPanel().active) selected = !selected;
    }

	void Update ()
    {
        //Change material
        if (selected) selectBlock();
        else unselectBlock();

        //Destroy object if animation ended
        if(toDestroy)
        {
            if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("readyToDelete"))
            {
                Destroy(gameObject);
            }
        }
	}

    private void selectBlock()
    {
        switch (blockColor)
        {
            case blockManager.color.blue:
                gameObject.GetComponent<MeshRenderer>().material = gameManager.BlockManager().blueBlockSelect;
                break;

            case blockManager.color.green:
                gameObject.GetComponent<MeshRenderer>().material = gameManager.BlockManager().greenBlockSelect;
                break;

            case blockManager.color.red:
                gameObject.GetComponent<MeshRenderer>().material = gameManager.BlockManager().redBlockSelect;
                break;

            case blockManager.color.yellow:
                gameObject.GetComponent<MeshRenderer>().material = gameManager.BlockManager().yellowBlockSelect;
                break;

            case blockManager.color.magenta:
                gameObject.GetComponent<MeshRenderer>().material = gameManager.BlockManager().magentaBlockSelect;
                break;
        }
    }

    private void unselectBlock()
    {
        switch (blockColor)
        {
            case blockManager.color.blue:
                gameObject.GetComponent<MeshRenderer>().material = gameManager.BlockManager().blueBlockUnselect;
                break;

            case blockManager.color.green:
                gameObject.GetComponent<MeshRenderer>().material = gameManager.BlockManager().greenBlockUnselect;
                break;

            case blockManager.color.red:
                gameObject.GetComponent<MeshRenderer>().material = gameManager.BlockManager().redBlockUnselect;
                break;

            case blockManager.color.yellow:
                gameObject.GetComponent<MeshRenderer>().material = gameManager.BlockManager().yellowBlockUnselect;
                break;

            case blockManager.color.magenta:
                gameObject.GetComponent<MeshRenderer>().material = gameManager.BlockManager().magentaBlockUnselect;
                break;
        }
    }
}
