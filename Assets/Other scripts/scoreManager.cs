using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class scoreManager : MonoBehaviour 
{
    public static List<KeyValuePair<string, int>> Score;

    public static void sortScore()
    {
        Score.Sort((nextPair, firstPair) => { return firstPair.Value.CompareTo(nextPair.Value); });
    }

    void Start()
    {
        PlayerPrefs.DeleteAll(); // ---------- [DEBUG] ----------

        Score = new List<KeyValuePair<string, int>>();

        loadScore(); //Load score
        sortScore(); //Sort score
        //Score[0] = new KeyValuePair<string, int>("TEST", 9999); //Change list value
    }

    public static void loadScore()
    {
        if (PlayerPrefs.HasKey("Scores")) //If playerPreft exist
        {
            for (int i = 0, j; i < 10; ++i)
            {
                j = i + 1;
                string str = PlayerPrefs.GetString("scoreDate" + j.ToString());
                int val = PlayerPrefs.GetInt("scoreValue" + j.ToString());

                Score.Add(new KeyValuePair<string, int>(str, val));
            }
        }
        else saveScore();
    }

    public static void saveScore()
    {
        if(PlayerPrefs.HasKey("Scores")) //If playerPreft exist
        {
            for (int i = 0, j; i < 10; ++i)
            {
                j = i + 1;
                PlayerPrefs.SetString("scoreDate" + j.ToString(), Score[i].Key);
                PlayerPrefs.SetInt("scoreValue" + j.ToString(), Score[i].Value);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Scores", 0);

            for (int i = 0, j; i < 10; ++i)
            {
                j = i + 1;
                PlayerPrefs.SetString("scoreDate" + j.ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
                PlayerPrefs.SetInt("scoreValue" + j.ToString(), j);
            }
            loadScore();
        }
        PlayerPrefs.Save();
    }
}
