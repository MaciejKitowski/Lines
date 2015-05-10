using UnityEngine;
using System.Collections;

public class pointsSystem : MonoBehaviour 
{
    public arenaManager managerArena;
    public blockManager managerBlock;

    public arenaBlock[,] arena;

	void Start () 
    {
        if (managerArena == null) Debug.Log(gameObject.name + " - arenaManager empty!");
        else
        {
            arena = new arenaBlock[5, 8];

            for (int Y = 0, i = 0; Y < 8; ++Y)
            {
                for (int X = 0; X < 5; ++X, ++i) arena[X, Y] = managerArena.arenaBlock[i];
            }
        }
	}
	
	void Update () 
    {
        //Check color in lines

        //Horizontal
        for (int Y = 0; Y < 8; ++Y)
        {
            for (int X = 1, i = 1; X < 6; ++X)
            {
                //If blocks match
                if (X < 5 && arena[X - 1, Y].block != null && arena[X, Y].block != null)
                {
                    if(arena[X - 1, Y].block.GetComponent<blockController>().blockColor == arena[X, Y].block.GetComponent<blockController>().blockColor)
                    {
                        if(!arena[X - 1, Y].block.GetComponent<blockController>().toDestroy && !arena[X, Y].block.GetComponent<blockController>().toDestroy)
                        {
                            if(arena[X - 1, Y].block.GetComponent<blockController>().navTarget == arena[X - 1, Y].transform.gameObject && arena[X, Y].block.GetComponent<blockController>().navTarget == arena[X, Y].transform.gameObject)
                            {
                                ++i;
                            }
                        }
                    }
                }
                //If blocs are different
                else
                {
                    if (i >= 3)
                    {
                        //Add points
                        manager.points += 10 + ((i % 3) + 1) * 5;

                        //Delete blocks
                        for (int w = i; w > 0; w--)
                        {
                            managerBlock.deleteBlock(arena[X - w,Y].block);
                        }
                        Debug.Log(manager.points);
                    }
                    i = 1;
                }
            }
        }

        //vertical
        for (int X = 0; X < 5; ++X)
        {
            for (int Y = 1, i = 1; Y < 9; ++Y)
            {
                //If blocks match
                if (Y < 8 && arena[X , Y - 1].block != null && arena[X, Y].block != null)
                {
                    if (arena[X, Y - 1].block.GetComponent<blockController>().blockColor == arena[X, Y].block.GetComponent<blockController>().blockColor)
                    {
                        if (!arena[X, Y - 1].block.GetComponent<blockController>().toDestroy && !arena[X, Y].block.GetComponent<blockController>().toDestroy)
                        {
                            if (arena[X, Y - 1].block.GetComponent<blockController>().navTarget == arena[X, Y - 1].transform.gameObject && arena[X, Y].block.GetComponent<blockController>().navTarget == arena[X, Y].transform.gameObject)
                            {
                                ++i;
                            }
                        }
                    }
                }
                //If blocs are different
                else
                {
                    if (i >= 3)
                    {
                        //Add points
                        manager.points += 10 + ((i % 3) + 1) * 5;

                        //Delete blocks
                        for (int w = i; w > 0; w--)
                        {
                            managerBlock.deleteBlock(arena[X, Y - w].block);
                        }
                        Debug.Log(manager.points);
                    }
                    i = 1;
                }
            }
        }
    }   
}
