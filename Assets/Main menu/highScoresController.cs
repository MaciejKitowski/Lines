using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class highScoresController : MonoBehaviour 
{
    private static Text[] place;

    void Start()
    {
        place = new Text[10];

        for (int i = 0, j = 2; i < 10; ++i, ++j) place[i] = gameObject.transform.GetChild(0).gameObject.transform.GetChild(j).gameObject.GetComponent<Text>();

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) returnButton();
    }

    public static void updateScores()
    {
        for (int i = 0; i < 10; ++i)
        {
            int j = i + 1;
            if (place[i] != null) place[i].text = j.ToString() + ". " + scoreManager.Score[i].Key + " " + scoreManager.Score[i].Value.ToString();
        }
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
