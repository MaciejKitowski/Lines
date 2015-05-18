using UnityEngine;
using System.Collections;

public class highScoresController : MonoBehaviour 
{
    public Animator getAnim()
    {
        return gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    public void returnButton()
    {
        getAnim().SetTrigger("hideHighScores");
    }
}
