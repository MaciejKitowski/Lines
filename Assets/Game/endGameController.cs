using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class endGameController : utilities
{
    public bool active;

    private Text UIpoints;
    private gameManager game;
    private GameObject newHighScore;
    private mainMenuController mainMenu;
    private highScoresController highScores;
    
    void Awake()
    {
        newHighScore = gameObject.transform.GetChild(2).gameObject;
        UIpoints = gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<gameManager>();
        highScores = GameObject.FindGameObjectWithTag("High Scores").GetComponent<highScoresController>();
        mainMenu = GameObject.FindGameObjectWithTag("Main Menu").GetComponent<mainMenuController>();
    }

    void Start() { setActive(false); }

    override public void setActive(bool state)
    {
        active = state;
        gameObject.SetActive(state);

        if(state)
        {
            gameManager.block.blocksToCreate = 0;
            UIpoints.text = gameManager.points.ToString();
            if (highScores.compareWithlastScore(gameManager.points))
            {
                newHighScore.SetActive(true);
                highScores.newHighScore(gameManager.points);
            }
            else newHighScore.SetActive(false);
        }
    }

    public void button_PlayAgain()
    {
        Debug.Log("Play again button");
        gameManager.resetGame();
    }

    public void button_BackToMenu()
    {
        Debug.Log("Back to menu button");
        mainMenu.setActive(true);
        game.setActive(false);
        setActive(false);
    }
}
