using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour 
{
    blockManager manager;

    public blockManager.color blockColor;
    public bool selected;
    NavMeshAgent navAgent;

    public GameObject navTarget;
	
	void Start () 
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        manager = gameObject.GetComponentInParent<blockManager>();
        navAgent.updateRotation = false;
	}

    public void setNavDestination(GameObject target)
    {
        navTarget = target;

        Vector3 pos = target.transform.position;
        pos.y = 0.4166668f;
        navAgent.SetDestination(pos);

        selected = false;
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
	    if(selected)
        {
            gameObject.GetComponent<MeshRenderer>().material = manager.blockSelectedMaterial;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = manager.blockUnselectedMaterial;
        }

        //Change block color
        switch(blockColor)
        {
            case blockManager.color.blue:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;

            case blockManager.color.green:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                break;

            case blockManager.color.red:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                break;

            /*case blockManager.color.yellow:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;*/

            /*case blockManager.color.magenta:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
                break;*/
        }
	}
}
