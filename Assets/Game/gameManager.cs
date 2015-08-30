using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameManager : MonoBehaviour 
{
    public static int points;
    public static arenaManager arena;
    public static blocksManager block;
    public static nextBlocksController nextBlock;
    public static endGameController endGame;
    public static debugMenuController debugMenu;

    private static Text pointsGUI;

    void Awake()
    {
        pointsGUI = transform.GetChild(0).GetChild(2).GetComponent<Text>();
        arena = transform.GetChild(1).GetComponent<arenaManager>();
        block = transform.GetChild(2).GetComponent<blocksManager>();
        nextBlock = transform.GetChild(3).GetComponent<nextBlocksController>();
        endGame = GameObject.FindGameObjectWithTag("End Game Panel").GetComponent<endGameController>();
        debugMenu = GameObject.FindGameObjectWithTag("Debug Menu").GetComponent<debugMenuController>();
    }

    void Start() { transform.gameObject.GetComponent<gameManager>().setActive(false); }

    public void setActive(bool state)
    {
        gameObject.SetActive(state);
        if (state) Debug.Log("Display: " + gameObject.name);
        else Debug.Log("Hide: " + gameObject.name);
    }

    public static void resetGame()
    {
        setPoints(0);
        nextBlock.randNewColors();
        block.destroyAllBlocks();
        endGame.setActive(false);
    }

    public static void addPoints(int val)
    {
        points += val;
        updatePoints();
    }

    public static void setPoints(int val)
    {
        points = val;
        updatePoints();
    }

    public static void updatePoints() { pointsGUI.text = points.ToString(); }
}
