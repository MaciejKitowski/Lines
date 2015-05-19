using UnityEngine;
using System.Collections;

public class highScoresController : MonoBehaviour 
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) returnButton();
    }

    public Animator getAnim()
    {
        return gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    public void returnButton()
    {
        getAnim().SetTrigger("hideHighScores");
    }
}
