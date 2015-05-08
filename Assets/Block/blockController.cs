using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour 
{
    public bool selected;
    NavMeshAgent navAgent;
	
	void Start () 
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
	}

    void OnMouseDown()
    {
        if (selected) selected = false;
        else selected = true;
    }
	
	
	void Update ()
    {
	
	}
}
