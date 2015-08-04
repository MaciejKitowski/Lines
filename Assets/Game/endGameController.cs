using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class endGameController : MonoBehaviour 
{
    public bool active;

    private GameObject newHighScore;
    private Text UIpoints;

    void Awake()
    {
        newHighScore = gameObject.transform.GetChild(2).gameObject;
        UIpoints = gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    public void setActive(bool status)
    {
        active = status;
        gameObject.SetActive(status);

        if(status)
        {
            Manager.blocks.blocksToCreate = 0;
            UIpoints.text = arenaManager.points.ToString();
            if(Manager.highScore.compareWithlastScore(arenaManager.points))
            {
                newHighScore.SetActive(true);
                Manager.highScore.newHighScore(arenaManager.points);
            }
            else newHighScore.SetActive(false);
        }
    }

    public void button_PlayAgain()
    {
        Debug.Log("Play again button");
        Manager.blocks.destroyAllBlocks();
        Manager.nextBlocks.randNewColors();
        arenaManager.points = 0;
        arenaManager.updatePoints();
        setActive(false);
    }

    public void button_BackToMenu()
    {
        Debug.Log("Back to menu button");
        Manager.blocks.destroyAllBlocks();
        Manager.MainMenu.setActive(true);
        Manager.Game.SetActive(false);
        setActive(false);
    }
}
