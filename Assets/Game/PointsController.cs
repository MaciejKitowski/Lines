using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointsController : MonoBehaviour 
{
    private static int points = 0;

    private Text text;
    private arenaBlock[,] arena;

    void Start()
    {
        arena = new arenaBlock[5, 8];

        text = gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        for (int y = 0, i = 0; y < 8; ++y) for (int x = 0; x < 5; ++x, ++i) arena[x, y] = manager.arena.arenaBlock[i];
        text.text = points.ToString();
    }

    void Update()
    {
        //Check colors
        checkColorsHorizontal();
        checkColorsVertical();
    }

    private void checkColorsHorizontal()
    {
        for (int y = 0; y < 8; ++y)
        {
            for (int x = 1, i = 1; x < 6; ++x)
            {
                //If blocks match
                if (x < 5 && (arena[x - 1, y].block != null && arena[x, y].block != null) && (arena[x - 1, y].BlockControl().blockColor == arena[x, y].BlockControl().blockColor))
                {
                    if ((!arena[x - 1, y].BlockControl().toDestroy && !arena[x, y].BlockControl().toDestroy) && arena[x - 1, y].BlockControl().navTarget == arena[x - 1, y].gameObject && arena[x, y].BlockControl().navTarget == arena[x, y].gameObject)
                    {
                        ++i;
                    }
                }
                else //If blocs are different
                {
                    if (i >= 3)
                    {
                        points += 10 + ((i % 3) + 1) * 5;
                        text.text = points.ToString(); //Update points
                        for (int w = i; w > 0; w--) manager.blocks.deleteBlock(arena[x - w, y].block); //Delete blocks
                    }
                    i = 1;
                }
            }
        }
    }

    private void checkColorsVertical()
    {
        for (int x = 0; x < 5; ++x)
        {
            for (int y = 1, i = 1; y < 9; ++y)
            {
                //If blocks match
                if (y < 8 && (arena[x, y - 1].block != null && arena[x, y].block != null) && (arena[x, y - 1].BlockControl().blockColor == arena[x, y].BlockControl().blockColor))
                {
                    if ((!arena[x, y - 1].BlockControl().toDestroy && !arena[x, y].BlockControl().toDestroy) && arena[x, y - 1].BlockControl().navTarget == arena[x, y - 1].gameObject && arena[x, y].BlockControl().navTarget == arena[x, y].gameObject)
                    {
                        ++i;
                    }
                }
                else //If blocs are different
                {
                    if (i >= 3)
                    {
                        points += 10 + ((i % 3) + 1) * 5;
                        text.text = points.ToString(); //Update points
                        for (int w = i; w > 0; w--) manager.blocks.deleteBlock(arena[x, y - w].block); //Delete blocks
                    }
                    i = 1;
                }
            }
        }
    }

    public static int getPoints()
    {
        return points;
    }

    public static void addPoints(int value)
    {
        points += value;
    }

    public static void substractPoints(int value)
    {
        points -= value;
    }

    public static void resetValue()
    {
        points = 0;
    }
}
