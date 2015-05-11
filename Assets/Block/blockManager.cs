using UnityEngine;
using System.Collections;

public class blockManager : MonoBehaviour 
{
    public GameObject blockPrefab;
    public arenaManager managerArena;

    public enum color { red, green, blue }; //TO ADD: yellow, magenta
    public int blockIndex = 1; //Index to naming blocks int inspector

    public Material blockUnselectedMaterial;
    public Material blockSelectedMaterial;

    //Return block
    public GameObject getBlock(int Index)
    {
        return gameObject.transform.GetChild(Index).gameObject;
    }

    //Return block count
    public int blockCount()
    {
        return gameObject.transform.childCount;
    }

    //return true if any block is selected
    public bool blockSelected()
    {
        for (int i = 0; i < blockCount(); ++i) if (getBlock(i).GetComponent<blockController>().selected) return true;
        return false;
    }

    //return index of selected block
    public int blockSelectedIndex()
    {
        for (int i = 0; i < blockCount(); ++i) if (getBlock(i).GetComponent<blockController>().selected) return i;
        return 404; //404 - block not found
    }

	void Update () 
    {
        //Find multiple selection
        for (int i = 0; i < blockCount(); ++i)
        {
            if (getBlock(i).GetComponent<blockController>().selected)
            {
                for (int j = i + 1; j < blockCount(); ++j)
                {
                    if (getBlock(j).GetComponent<blockController>().selected)
                    {
                        getBlock(i).GetComponent<blockController>().selected = false;
                        getBlock(j).GetComponent<blockController>().selected = false;
                    }
                }
            }
        }

        // [[   TEST    ]]  --  Create new blocks
        //if (Input.GetKeyDown(KeyCode.A)) createNewBlock(color.blue);

        // [[   TEST    ]]  --  delete block
        if (Input.GetKeyDown(KeyCode.Space)) deleteBlock(getBlock(0));
	}

    public void createNewBlock(color col)
    {
        arenaBlock arena = null;

        if (blockCount() < 32) while (arena == null || arena.blocked) arena = managerArena.arenaBlock[Random.Range(0, 39)];
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
            //++blockCounter;

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
            //blocks.Add(transform.GetChild(blockCount()-1).gameObject); //Add to block list
            newBlock.GetComponent<Animator>().SetTrigger("newBlock"); //Run animation

            ++blockIndex;
        }
    }

    public void deleteBlock(GameObject obj)
    {
        for (int i = 0; i < blockCount(); ++i)
        {
            if(obj == getBlock(i))
            {
                getBlock(i).GetComponent<blockController>().navTarget = null;
                getBlock(i).GetComponent<blockController>().toDestroy = true;
                getBlock(i).GetComponent<Animator>().SetTrigger("deleteBlock");
                //--blockCounter;
                //blocks.RemoveAt(i);
                continue;
            }
        }
    }
}