using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class debugMenuController : utilities 
{
    public bool active;
    public int pointsChange;
    public int blocksChange;

    private Text addPoints;
    private Text subtractPoints;
    private Text removeBlocks;

    void Awake()
    {
        if (pointsChange <= 0 || blocksChange <= 0) Debug.LogError("Debug menu - to small pointsChange/blocksChange value.");
        else
        {
            addPoints = gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            subtractPoints = gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            removeBlocks = gameObject.transform.GetChild(7).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

            addPoints.text = "Add " + pointsChange.ToString() + " points";
            subtractPoints.text = "Subtract " + pointsChange.ToString() + " points";
            removeBlocks.text = "Remove " + blocksChange.ToString() + " blocks";
        }
    }

    void Start() { setActive(false); }

    override public void setActive(bool state)
    {
        active = state;
        gameObject.SetActive(state);
    }

    public void button_addPoints()
    {
        Debug.LogWarning("Debug menu - add " + pointsChange.ToString() + " points.");
        gameManager.addPoints(pointsChange);
    }

    public void button_subtractPoints()
    {
        Debug.LogWarning("Debug menu - subtract " + pointsChange.ToString() + " points.");
        gameManager.addPoints(-pointsChange);
    }

    public void button_resetPoints()
    {
        Debug.LogWarning("Debug menu - reset points.");
        gameManager.setPoints(0);
    }

    public void button_randColors()
    {
        Debug.LogWarning("Debug menu - rand new colors.");
        gameManager.nextBlock.randNewColors();
    }

    public void button_pushBlocks()
    {
        Debug.LogWarning("Debug menu - push new blocks.");
        gameManager.block.blocksToCreate = 5;
        setActive(false);
    }

    public void button_removeOneBlock()
    {
        Debug.LogWarning("Debug menu - remove 1 block.");
        gameManager.block.destroyBlock(1);
        setActive(false);
    }

    public void button_removeBlocksValue()
    {
        Debug.LogWarning("Debug menu - remove " + blocksChange.ToString() + " blocks.");
        gameManager.block.destroyBlock(blocksChange);
        setActive(false);
    }

    public void button_removeAllBlocks()
    {
        Debug.LogWarning("Debug menu - remove all block.");
        gameManager.block.destroyAllBlocks();
        setActive(false);
    }

    public void button_deletePlayerprefs()
    {
        Debug.LogWarning("Debug menu - delete playerprefs.");
        PlayerPrefs.DeleteAll();
    }

    public void button_closeDebug()
    {
        Debug.LogWarning("Debug menu - close debug menu.");
        setActive(false);
    }
}
