using UnityEngine;
using System.Collections;

public class blockManager : MonoBehaviour 
{
    public enum color { red, green, blue, yellow, magenta };

    public GameObject blockPrefab;

    public Material redBlockUnselect, redBlockSelect;
    public Material greenBlockUnselect, greenBlockSelect;
    public Material blueBlockUnselect, blueBlockSelect;
    public Material yellowBlockUnselect, yellowBlockSelect;
    public Material magentaBlockUnselect, magentaBlockSelect;

    private int blockIndex = 1; //Index to naming blocks in inspector

	void Update () 
    {
        pushNewBlocks();
        multipleSelection();
	}

    public void createNewBlock(color col)
    {
        arenaBlock arena = null;

        if (blockCount() < 32) while (arena == null || arena.blocked) arena = manager.arena.arenaBlock[Random.Range(0, 39)];
        else
        {
            for (int i = 0; i < 40; ++i)
            {
                arena = manager.arena.arenaBlock[i];
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

    public void deleteAllBlocks()
    {
        for (int i = blockCount() - 1; i >= 0; --i) deleteBlock(getBlock(i));
    }

    public int blockCount() { return gameObject.transform.childCount; } //Return block count
    public GameObject getBlock(int Index) { return gameObject.transform.GetChild(Index).gameObject; } //Return block

    //Return selected block
    public GameObject getSelectedBlock()
    {
        for (int i = 0; i < blockCount(); ++i) if (getBlock(i).GetComponent<blockController>().selected) return getBlock(i);
        return null;
    }

    //Return true if any block are destroying
    public bool checkDestroy()
    {
        for (int i = 0; i < blockCount(); ++i) if (getBlock(i).GetComponent<blockController>().toDestroy) return true;
        return false;
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

    //Add new blocks for every move without points
    private void pushNewBlocks()
    {
        for (int i = 0; i < blockCount(); ++i)
        {
            if (getBlock(i).GetComponent<blockController>().moved && getBlock(i).GetComponent<blockController>().onPosition)
            {
                manager.nextBlock.blocksToAdd = 4;
                getBlock(i).GetComponent<blockController>().moved = false;
            }
        }
    }
}