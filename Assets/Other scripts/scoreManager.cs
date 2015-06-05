using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class scoreManager : MonoBehaviour 
{
    public static List<KeyValuePair<string, int>> Score;

    void Start()
    {
        //PlayerPrefs.DeleteAll(); // ---------- [DEBUG] ----------

        Score = new List<KeyValuePair<string, int>>();

        loadScore();
        sortScore();
    }

    public static void addNewRecord(int value)
    {
        Score[9] = new KeyValuePair<string, int>(DateTime.Now.ToString("yyyy/MM/dd HH:mm"), value);
        sortScore();
    }

    public static void sortScore()
    {
        Score.Sort((nextPair, firstPair) => { return firstPair.Value.CompareTo(nextPair.Value); });
    }

    public static void saveScore()
    {
        if (PlayerPrefs.HasKey("Scores"))
        {
            for (int i = 0, j = 1; i < 10; ++i, ++j)
            {
                PlayerPrefs.SetString("scoreDate" + j.ToString(), Score[i].Key);
                PlayerPrefs.SetInt("scoreValue" + j.ToString(), Score[i].Value);
            }
        }
        PlayerPrefs.Save();
    }

    public static void loadScore()
    {
        if (PlayerPrefs.HasKey("Scores"))
        {
            for (int i = 0, j = 1; i < 10; ++i, ++j)
            {
                string str = PlayerPrefs.GetString("scoreDate" + j.ToString());
                int val = PlayerPrefs.GetInt("scoreValue" + j.ToString());

                Score.Add(new KeyValuePair<string, int>(str, val));
            }
        }
        else createPlayerPrefs();
    }

    //Create playerPrefs if doesn't exist
    public static void createPlayerPrefs()
    {
        PlayerPrefs.SetInt("Scores", 0);

        for (int i = 0, j = 1; i < 10; ++i, ++j)
        {
            PlayerPrefs.SetString("scoreDate" + j.ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            PlayerPrefs.SetInt("scoreValue" + j.ToString(), j);
        }
        loadScore();
    }
}
