using UnityEngine;
using System.Collections;

public class mainMenuController : MonoBehaviour 
{
    public bool active = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!Manager.ExitGame.active)
            {
                Debug.Log("Back button");
                Manager.ExitGame.setActive(true);
            }
        }
    }

    public void setActive(bool status)
    {
        active = status;
        gameObject.SetActive(status);
    }

    public void button_NewGame()
    {
        Debug.Log("New Game button");
    }

    public void button_HighScores()
    {
        Debug.Log("High Scores button");
    }

    public void button_About()
    {
        if (!Manager.ExitGame.active)
        {
            Debug.Log("About button");
        }
    }

    public void button_ExitGame()
    {
        if (!Manager.ExitGame.active)
        {
            Debug.Log("Exit Game button");
            Manager.ExitGame.setActive(true);
        }
    }
}
