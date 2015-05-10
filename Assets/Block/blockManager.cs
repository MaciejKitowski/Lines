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
        //Find multiple selection
        for (int i = 0; i < blockCounter; ++i )
        {
            if(blocks[i].GetComponent<blockController>().selected)
            {
                for(int j = i + 1; j < blockCounter; ++j)
                {
                    if(blocks[j].GetComponent<blockController>().selected)
                    {
                        blocks[i].GetComponent<blockController>().selected = false;
                        blocks[j].GetComponent<blockController>().selected = false;
                    }
                }
            }
        }

        // [[   TEST    ]]  --  Create new blocks
        if (Input.GetKeyDown(KeyCode.A)) createNewBlock(color.blue);

        // [[   TEST    ]]  --  delete block
        if (Input.GetKeyDown(KeyCode.Space)) deleteBlock(blocks[0]);
	}

    public void createNewBlock(color col)
    {
        arenaBlock arena = null;

        if (blockCounter < 32) while (arena == null || arena.blocked) arena = managerArena.arenaBlock[Random.Range(0, 39)];
        else
        {
            for (int i = 0; i < 40; ++i)
            {
                arena = managerArena.arenaBlock[i];
                if (!arena.blocked) break;
            }
        }

        if (!arena.blocked)
        {
            ++blockCounter;

            GameObject newBlock = Instantiate(blockPrefab) as GameObject;
            newBlock.name = blockIndex.ToString(); //Change name
            newBlock.GetComponent<NavMeshAgent>().enabled = false; //Turn off Navmesh Agent

            //Set position
            Vector3 pos = arena.transform.position;
            pos.y = 0.4166f;
            newBlock.transform.position = pos;
            newBlock.GetComponent<blockController>().navTarget = arena.transform.gameObject;

            newBlock.GetComponent<blockController>().blockColor = col; //Set color
            newBlock.transform.parent = gameObject.transform; //Set as child
            newBlock.GetComponent<NavMeshAgent>().enabled = true; //Turn on Navmesh Agent
            blocks.Add(transform.GetChild(blockCounter - 1).gameObject); //Add to block list
            newBlock.GetComponent<Animator>().SetTrigger("newBlock"); //Run animation

            ++blockIndex;
        }
    }

    public void deleteBlock(GameObject obj)
    {
        for(int i = 0; i < blockCounter; ++i)
        {
            if(obj == blocks[i].gameObject)
            {
                blocks[i].GetComponent<blockController>().navTarget = null;
                blocks[i].GetComponent<blockController>().toDestroy = true;
                blocks[i].GetComponent<Animator>().SetTrigger("deleteBlock");
                --blockCounter;
                blocks.RemoveAt(i);
                continue;
            }
        }
    }
}


/*public void deleteBlock(GameObject obj)
    {
        for (int i = 0; i < blockSize;i++ )
        {
            if(obj == blocks[i].gameObject)
            {
                blocks[i].arenaBlock.GetComponent<arena>().blocked = false;
                Destroy(blocks[i].gameObject);
                blockSize--;
                blocks.RemoveAt(i);
                continue;
            }
        }
    }*/