using UnityEngine;
using System.Collections;

public class nextBlocksController : MonoBehaviour
{
    private const int blocksCount = 5;

    public blocksManager.blockColor[] color;
    private MeshRenderer[] blockRenderer;

    void Awake()
    {
        color = new blocksManager.blockColor[blocksCount];
        blockRenderer = new MeshRenderer[blocksCount];

        for (int i = 0; i < blocksCount; ++i) blockRenderer[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>();
    }

    public void randNewColors()
    {
        for(int i = 0; i < blocksCount; ++i)
        {
            int rand = Random.Range(1, 7);

            switch(rand)
            {
                case 1:
                    color[i] = blocksManager.blockColor.BLUE;
                    blockRenderer[i].material = Manager.blocks.unselectBlue;
                    break;
                case 2:
                    color[i] = blocksManager.blockColor.BROWN;
                    blockRenderer[i].material = Manager.blocks.unselectBrown;
                    break;
                case 3:
                    color[i] = blocksManager.blockColor.GREEN;
                    blockRenderer[i].material = Manager.blocks.unselectGreen;
                    break;
                case 4:
                    color[i] = blocksManager.blockColor.ORANGE;
                    blockRenderer[i].material = Manager.blocks.unselectOrange;
                    break;
                case 5:
                    color[i] = blocksManager.blockColor.PINK;
                    blockRenderer[i].material = Manager.blocks.unselectPink;
                    break;
                case 6:
                    color[i] = blocksManager.blockColor.RED;
                    blockRenderer[i].material = Manager.blocks.unselectRed;
                    break;
                case 7:
                    color[i] = blocksManager.blockColor.YELLOW;
                    blockRenderer[i].material = Manager.blocks.unselectYellow;
                    break;
                default:
                    Debug.LogError(gameObject.name + " - Bad color assignment");
                    break;
            }
        }
    }

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.A)) randNewColors();
	}
}
