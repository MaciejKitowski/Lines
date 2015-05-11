using UnityEngine;
using System.Collections;

public class blockManager : MonoBehaviour 
{
    public enum color { red, green, blue, yellow, magenta };

    public GameObject blockPrefab;
    public arenaManager managerArena;
    public Material blockUnselectedMaterial;
    public Material blockSelectedMaterial;

    private int blockIndex = 1; //Index to naming blocks in inspector

	void Update () 
    {
        multipleSelection();
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
                continue;
            }
        }
    }

    //Return block count
    public int blockCount()
    {
        return gameObject.transform.childCount;
    }

    //Return block
    public GameObject getBlock(int Index)
    {
        return gameObject.transform.GetChild(Index).gameObject;
    }

    //Return selected block
    public GameObject getSelectedBlock()
    {
        for (int i = 0; i < blockCount(); ++i) if (getBlock(i).GetComponent<blockController>().selected) return getBlock(i);
        return null;
    }

    //Find multiple selection
    private void multipleSelection()
    {
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
    }
}