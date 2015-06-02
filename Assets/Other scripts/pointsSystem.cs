using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pointsSystem : MonoBehaviour 
{
    public Text pointsText;
    private arenaBlock[,] arena;

	void Start () 
    {
        arena = new arenaBlock[5, 8];
        for (int y = 0, i = 0; y < 8; ++y) for (int x = 0; x < 5; ++x, ++i) arena[x, y] = manager.arena.arenaBlock[i];
	}
	
	void Update () 
    {
        //Update points
        pointsText.text = manager.points.ToString();

        //Check color in lines
        for (int Y = 0; Y < 8; ++Y) //Horizontal
        {
            for (int X = 1, i = 1; X < 6; ++X)
            {
                //If blocks match
                if (X < 5 && (arena[X - 1, Y].block != null && arena[X, Y].block != null) && 
                    (arena[X - 1, Y].BlockControl().blockColor == arena[X, Y].BlockControl().blockColor) && 
                    (!arena[X - 1, Y].BlockControl().toDestroy && !arena[X, Y].BlockControl().toDestroy) && 
                    (arena[X - 1, Y].BlockControl().navTarget == arena[X - 1, Y].gameObject && arena[X, Y].BlockControl().navTarget == arena[X, Y].gameObject))
                {
                    ++i;
                }
                else //If blocs are different
                {
                    if (i >= 3)
                    {
                        manager.points += 10 + ((i % 3) + 1) * 5; //Add points
                        for (int w = i; w > 0; w--) manager.blocks.deleteBlock(arena[X - w, Y].block); //Delete blocks
                    }
                    i = 1;
                }
            }
        }
        for (int X = 0; X < 5; ++X) //vertical
        {
            for (int Y = 1, i = 1; Y < 9; ++Y)
            {
                //If blocks match
                if (Y < 8 && (arena[X, Y - 1].block != null && arena[X, Y].block != null) && 
                    (arena[X, Y - 1].BlockControl().blockColor == arena[X, Y].BlockControl().blockColor) && 
                    (!arena[X, Y - 1].BlockControl().toDestroy && !arena[X, Y].BlockControl().toDestroy) && 
                    (arena[X, Y - 1].BlockControl().navTarget == arena[X, Y - 1].gameObject && arena[X, Y].BlockControl().navTarget == arena[X, Y].gameObject))
                {
                    ++i;
                }
                else //If blocs are different
                {
                    if (i >= 3)
                    {
                        manager.points += 10 + ((i % 3) + 1) * 5; //Add points
                        for (int w = i; w > 0; w--) manager.blocks.deleteBlock(arena[X, Y - w].block); //Delete blocks
                    }
                    i = 1;
                }
            }
        }
    }   
}
