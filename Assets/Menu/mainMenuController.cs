using UnityEngine;
using System.Collections;

public class mainMenuController : utilities 
{
    private exitGameController exitGame;
    private aboutController about;
    private highScoresController highScores;
    private gameManager game;

    void Awake()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<gameManager>();
        about = GameObject.FindGameObjectWithTag("About").GetComponent<aboutController>();
        exitGame = GameObject.FindGameObjectWithTag("Exit Game").GetComponent<exitGameController>();
        highScores = GameObject.FindGameObjectWithTag("High Scores").GetComponent<highScoresController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !exitGame.active) exitGame.setActive(true);
    }

    public void button_NewGame()
    {
        Debug.Log("New Game button");
        setActive(false);
        game.setActive(true);
        gameManager.resetGame();
    }

    public void button_HighScores()
    {
        Debug.Log("High Scores button");
        highScores.setActive(true);
        highScores.updateText();
        setActive(false);
    }

    public void button_About()
    {
        if(!exitGame.active)
        {
            about.setActive(true);
            setActive(false);
        }
    }

    public void button_ExitGame() { if (!exitGame.active) exitGame.setActive(true); }
}
