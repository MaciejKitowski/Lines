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
        if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (selected) selected = false;
            else selected = true;
        }
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
                gameObject.GetComponent<MeshRenderer>().material = manager.blocks.blueBlockSelect;
                break;

            case blockManager.color.green:
                gameObject.GetComponent<MeshRenderer>().material = manager.blocks.greenBlockSelect;
                break;

            case blockManager.color.red:
                gameObject.GetComponent<MeshRenderer>().material = manager.blocks.redBlockSelect;
                break;

            case blockManager.color.yellow:
                gameObject.GetComponent<MeshRenderer>().material = manager.blocks.yellowBlockSelect;
                break;

            case blockManager.color.magenta:
                gameObject.GetComponent<MeshRenderer>().material = manager.blocks.magentaBlockSelect;
                break;
        }
    }

    private void unselectBlock()
    {
        switch (blockColor)
        {
            case blockManager.color.blue:
                gameObject.GetComponent<MeshRenderer>().material = manager.blocks.blueBlockUnselect;
                break;

            case blockManager.color.green:
                gameObject.GetComponent<MeshRenderer>().material = manager.blocks.greenBlockUnselect;
                break;

            case blockManager.color.red:
                gameObject.GetComponent<MeshRenderer>().material = manager.blocks.redBlockUnselect;
                break;

            case blockManager.color.yellow:
                gameObject.GetComponent<MeshRenderer>().material = manager.blocks.yellowBlockUnselect;
                break;

            case blockManager.color.magenta:
                gameObject.GetComponent<MeshRenderer>().material = manager.blocks.magentaBlockUnselect;
                break;
        }
    }
}
