using UnityEngine;
using System.Collections;

public class nextBlocksController : MonoBehaviour 
{
    public int blocksToAdd = 4;

    private int[] colorIndex;
    private GameObject[] block;
    private blockManager.color[] col;
    private float timer;

	void Start () 
    {
        block = new GameObject[4];
        col = new blockManager.color[4];
        colorIndex = new int[4];

        for (int i = 0; i < 4; ++i) block[i] = gameObject.transform.GetChild(i).gameObject;

        randNewColor();
	}

    public void randNewColor()
    {
        for(int i = 0; i < 4; ++i)
        {
            colorIndex[i] = Random.Range(1, 6);

            switch(colorIndex[i])
            {
                case 1:
                    col[i] = blockManager.color.red;
                    block[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    break;
                case 2:
                    col[i] = blockManager.color.green;
                    block[i].GetComponent<MeshRenderer>().material.color = Color.green;
                    break;
                case 3:
                    col[i] = blockManager.color.blue;
                    block[i].GetComponent<MeshRenderer>().material.color = Color.blue;
                    break;
                case 4:
                    col[i] = blockManager.color.yellow;
                    block[i].GetComponent<MeshRenderer>().material.color = Color.yellow;
                    break;
                case 5:
                    col[i] = blockManager.color.magenta;
                    block[i].GetComponent<MeshRenderer>().material.color = Color.magenta;
                    break;
            }
        }
    }

    public void push()
    {
        if (blocksToAdd > 0 && !manager.menu.mainMenu.active) manager.blocks.createNewBlock(col[blocksToAdd - 1]);
        else randNewColor();
    }
	
	void Update () 
    {
        if (manager.blocks.blockCount() < 4 && !manager.menu.mainMenu.active) blocksToAdd = 4;

        if (blocksToAdd >= 0 && Time.time > timer)
        {
            timer = Time.time + 0.1f;
            push();
            blocksToAdd--;
        }
	}
}
