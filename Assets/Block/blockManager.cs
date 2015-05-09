using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class blockManager : MonoBehaviour 
{
    public GameObject blockPrefab;
    public List<GameObject> blocks;

    public arenaManager managerArena;

    public enum color { red, green, blue }; //TO ADD: yellow, magenta
    public int blockCounter = 0; //How much blocks already exist
    public int blockIndex = 1; //Index to naming blocks int inspector

    public Material blockUnselectedMaterial;
    public Material blockSelectedMaterial;

    //return true if any block is selected
    public bool blockSelected()
    {
        for (int i = 0; i < blockCounter; ++i) if (blocks[i].gameObject.GetComponent<blockController>().selected) return true;
        return false;
    }

    //return index of selected block
    public int blockSelectedIndex()
    {
        for (int i = 0; i < blockCounter; ++i) if (blocks[i].gameObject.GetComponent<blockController>().selected) return i;
        return 404; //404 - block not found
    }

	void Update () 
    {
	    // [[   TEST    ]]  --  Create new block
        if(blockCounter == 0)
        {
            ++blockCounter;

            GameObject newBlock = Instantiate(blockPrefab) as GameObject;

            //Change name
            newBlock.name = blockIndex.ToString();

            //Turn off Navmesh Agent
            newBlock.GetComponent<NavMeshAgent>().enabled = false;

            //Set position
            Vector3 pos = new Vector3(-30.8f, 0.4166f, 0f); //There should be randomized arena block
            newBlock.transform.position = pos;

            //Set color
            newBlock.GetComponent<blockController>().blockColor = color.green; //It should be randomized

            //Set as child
            newBlock.transform.parent = gameObject.transform;

            //Turn on Navmesh Agent
            newBlock.GetComponent<NavMeshAgent>().enabled = true;

            //Add to list
            blocks.Add(transform.GetChild(blockCounter - 1).gameObject);

            //Run animation
            newBlock.GetComponent<Animator>().SetTrigger("newBlock");

            ++blockIndex;
        }
	}
}
