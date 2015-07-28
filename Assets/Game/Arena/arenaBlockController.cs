using UnityEngine;
using System.Collections;

public class arenaBlockController : MonoBehaviour 
{
    public GameObject navMeshObstacle;
    public blockController block;
	
    void Awake()
    {
        navMeshObstacle = gameObject.transform.GetChild(2).gameObject;
        navMeshObstacle.SetActive(false);
    }

    void Update()
    {
        if (block != null && !block.selected && !navMeshObstacle.activeInHierarchy) navMeshObstacle.SetActive(true);
        else if (block != null && block.selected && navMeshObstacle.activeInHierarchy) navMeshObstacle.SetActive(false);     
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Block")
        {
            if(obj.gameObject.GetComponent<blockController>().arenaTarget.gameObject == gameObject)
            {
                obj.gameObject.GetComponent<blockController>().stopPath();
                block = obj.gameObject.GetComponent<blockController>();
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log("mouse clicked on arena: " + gameObject.name);
        if(Manager.blocks.blockSelected())Manager.blocks.getSelectedBlock().setPatch(gameObject.GetComponent<arenaBlockController>());
    }
	
}
