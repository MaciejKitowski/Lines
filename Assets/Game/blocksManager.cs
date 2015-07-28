using UnityEngine;
using System.Collections;

public class blocksManager : MonoBehaviour 
{
    public enum blockColor { BLUE, GREEN, YELLOW, RED, PINK, BROWN, ORANGE };
    public GameObject blockPrefab;
    public Material unselectBlue, unselectGreen, unselectYellow, unselectRed, unselectPink, unselectBrown, unselectOrange;
    public Material selectBlue, selectGreen, selectYellow, selectRed, selectPink, selectBrown, selectOrange;

    private int blockIndex = 1; //Index to naming blocks in inspector

    public blockController getSelectedBlock()
    {
        foreach (Transform block in transform) if (block.gameObject.GetComponent<blockController>().selected) return block.gameObject.GetComponent<blockController>();
        return null;
    }

    //To use in arenaBlockController
    public bool blockSelected()
    {
        foreach (Transform block in transform) if (block.gameObject.GetComponent<blockController>().selected) return true;
        return false;
    }

    //To use in blockController
    public bool blockIsSelected() 
    {
        foreach(Transform block in transform)
        {
            if (block.gameObject.GetComponent<blockController>().selected)
            {
                block.gameObject.GetComponent<blockController>().selected = false;
                block.gameObject.GetComponent<blockController>().updateMaterial();
                Debug.LogWarning("Multiple selection");
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            createNewBlock(blockColor.PINK);
        }
    }

    public void createNewBlock(blockColor col)
    {
        arenaBlockController arenaBlock = null;

        if(gameObject.transform.childCount < 42) while (arenaBlock == null || arenaBlock.block != null) arenaBlock = Manager.arena.arenaBlock[Random.Range(0, 48)];
        else
        {
            foreach(arenaBlockController it in Manager.arena.arenaBlock)
            {
                if(it.block == null)
                {
                    arenaBlock = it;
                    break;
                }
            }
        }

        GameObject newBlock = Instantiate(blockPrefab) as GameObject;
        newBlock.name = blockIndex.ToString();

        newBlock.transform.parent = gameObject.transform;
        newBlock.GetComponent<blockController>().arenaTarget = arenaBlock;
        newBlock.GetComponent<blockController>().color = col;

        newBlock.transform.localScale = blockPrefab.transform.localScale;
       // newBlock.transform.rotation = Quaternion.Euler(270, 0, 0);
        newBlock.transform.localRotation = blockPrefab.transform.localRotation;

        Vector3 pos = arenaBlock.transform.localPosition;
        pos.z = -0.639f;
        newBlock.transform.localPosition = pos;

        ++blockIndex;
    }
}
